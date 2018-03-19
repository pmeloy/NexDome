using System;
using System.Diagnostics;
using System.Management;
using System.Collections.Generic;
using System.Media;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;
using System.IO.Ports;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Reflection;


/*  Serial Commands
 *  a   Stop()                                  %   Command is from configurator
 *  b   Get Shutter Position                    [   Move relative
 *  c   Calibrate                               #   Get or Set max speed
 *  d   Open Shutter                            ^   Get rotation direction
 *  e   Close Shutter                           $   Get or Set step mode
 *  f   Set Shutter Position                    *   Get or Set acceleration
 *  g   Goto Azimuth                            |   Get or Set home center
 *  h   Home                                    !   Get or Set steps to stop
 *  I   Get Home Azimuth                        (   Get seek mode
 *  j   Set Home Azimuth                        C   Comment to show in configurator
 *  k   Get voltages                            ?   Load config from EEPROM
 *  l   Set Park Azimuth                        /   Save config to EEPROM
 *  m   Motion status                           W 1 Wipe EEPROM (requires the 1).
 *  n   Get Park Azimuth
 *  o   Get Last Azimuth Error
 *  p   Get current Rotator position
 *  q   Get current asimuth
 *  r   Get or Set Shutter hibernate timer
 *  s   Sync to azimuth
 *  t   Get or Set steps per rotation
 *  u   Get Shutter/Rain status
 *  v   Get Firmware Version
 *  w   Restart wireless
 *  x   Wake shutter
 *  y   Get or Set reverse motion
 *  z   Home status
 */

namespace NexDomeRotatorConfigurator
{
    public partial class frmMain : Form
    {
        internal class ProcessConnection
        {

            public static ConnectionOptions ProcessConnectionOptions()
            {
                ConnectionOptions options = new ConnectionOptions();
                options.Impersonation = ImpersonationLevel.Impersonate;
                options.Authentication = AuthenticationLevel.Default;
                options.EnablePrivileges = true;
                return options;
            }

            public static ManagementScope ConnectionScope(string machineName, ConnectionOptions options, string path)
            {
                ManagementScope connectScope = new ManagementScope();
                connectScope.Path = new ManagementPath(@"\\" + machineName + path);
                connectScope.Options = options;
                connectScope.Connect();
                return connectScope;
            }
        }
        public class COMPortInfo
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public int Index { get; set; }

            public COMPortInfo() { }

            public static List<COMPortInfo> GetCOMPortsInfo()
            {
                List<COMPortInfo> comPortInfoList = new List<COMPortInfo>();

                ConnectionOptions options = ProcessConnection.ProcessConnectionOptions();
                ManagementScope connectionScope = ProcessConnection.ConnectionScope(Environment.MachineName, options, @"\root\CIMV2");

                ObjectQuery objectQuery = new ObjectQuery("SELECT * FROM Win32_PnPEntity WHERE ConfigManagerErrorCode = 0");
                ManagementObjectSearcher comPortSearcher = new ManagementObjectSearcher(connectionScope, objectQuery);

                using (comPortSearcher)
                {
                    string caption = null;
                    foreach (ManagementObject obj in comPortSearcher.Get())
                    {
                        if (obj != null)
                        {
                            object captionObj = obj["Caption"];
                            if (captionObj != null)
                            {
                                caption = captionObj.ToString();
                                if (caption.Contains("(COM"))
                                {
                                    COMPortInfo comPortInfo = new COMPortInfo();
                                    comPortInfo.Name = caption.Substring(caption.LastIndexOf("(COM")).Replace("(", string.Empty).Replace(")",
                                                                         string.Empty);
                                    comPortInfo.Description = caption;
                                    comPortInfoList.Add(comPortInfo);
                                }
                            }
                        }
                    }
                }
                return comPortInfoList;
            }
        }
        const string CMD_STOP = "a", CMD_GETSHUTTERPOS = "b", CMD_CALIBRATE = "c", CMD_OPENSHUTTER = "d", CMD_CLOSESHUTTER = "e", CMD_SETSHUTTERPOS = "f";
        const string CMD_GOTOAZ = "g", CMD_HOME = "h", CMD_GETHOME = "i", CMD_SETHOME = "j", CMD_GETVOLTS = "k", CMD_SETPARK = "l", CMD_MOVESTATUS = "m";
        const string CMD_GETPARKAZ = "n", CMD_GETLASTERR = "o", CMD_POS = "p", CMD_GETAZ = "q", CMD_SHUTTERTIMER = "r", CMD_SYNC = "s", CMD_STEPSPERROT = "t";
        const string CMD_SHUTTRAINSTAT = "u", CMD_GETVERSION = "v", CMD_RESTARTWIRELESS = "w", CMD_WAKESHUTTER = "x", CMD_REVERSED = "y", CMD_HOMESTATUS = "z";
        const string CMD_MOVERELATIVE = "[", CMD_MAXSPEED = "#", CMD_DIRECTION = "^", CMD_STEPMODE = "$", CMD_ACCEL = "*", CMD_CENTER = "|";
        const string CMD_STEPSSTOP = "!", CMD_GETSEEKMODE = "(", CMD_LOADEEPROM = "?", CMD_SAVEEEPROM = "/",CMD_VERSION = "v";

        Version version = Assembly.GetEntryAssembly().GetName().Version;
        string serialBuffer = "";
        int changesMade = 0;
        int lastStepMode;
        int seekStatus;
        bool cwButtonDown,ccwButtonDown;
        long rotateButtonSteps = 2000;
        long DIRECTION_POSITIVE = 1, DIRECTION_NEGATIVE = -1;

        long stepsPerRotation;
        const int TYPE_FLOAT = 0;
        const int TYPE_LONG = 1;
        List<COMPortInfo> tList = new List<COMPortInfo>();
        List<string> messageList = new List<string>();
        String[] homeStates = new String[] { "Not homed", "Homed", "At Home" };
        String[] seekStates = new String[] { "None", "Homing", "Move Off", "Find Home", "Measure Switch", "Measure Dome" };

        public static readonly List<string> SupportedBaudRates = new List<string>
        {"300","600","1200","2400","4800","9600","19200","38400","57600","115200","230400","460800","921600"};

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Text = "NexDome Configurator v" + version;
            FillPortList();
            cbxPorts.DataSource = tList;
            cbxPorts.DisplayMember = "Description";
            cbxPorts.ValueMember = "Name";
            cbxPorts.SelectedIndex = cbxPorts.FindString("Arduino");

            foreach (string b in SupportedBaudRates)
            {
                cbxBaudRates.Items.Add(b);
                cbxBaudRates.SelectedIndex = cbxBaudRates.FindString("9600");
            }
            SetControlsConnectStatus(false);
        }

        private void FillPortList()
        {
            foreach (COMPortInfo comPort in COMPortInfo.GetCOMPortsInfo())
            {
                tList.Add(comPort);
            }
        }
        public void AddTextToTerminal(string addition)
        {
            tbxTerminal.Text += addition + Environment.NewLine;
            if (tbxTerminal.TextLength > 500)
            {
                tbxTerminal.Text = RemoveFirstLines(tbxTerminal.Text, 5);
            }
            tbxTerminal.SelectionStart = tbxTerminal.TextLength - 1;
            tbxTerminal.SelectionLength = 0;
        }
        private String IntToMillivolts(string mv)
        {
            Single res = Convert.ToSingle(mv);
            res /= 100;
            return res.ToString();
        }
        public static string RemoveFirstLines(string text, int linesCount)
        {
            var lines = Regex.Split(text, "\r\n|\r|\n").Skip(linesCount);
            return string.Join(Environment.NewLine, lines.ToArray());
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            int baudRate;
            string comPort = "";

            if (!ArduinoPort.IsOpen)
            {
                if (cbxPorts.SelectedIndex > -1)
                {
                    comPort = cbxPorts.SelectedValue.ToString();
                }
                else
                {
                    AddTextToTerminal("ERR: Select a Com Port");
                    return;
                }
                if (cbxBaudRates.SelectedIndex > -1)
                {
                    if (!int.TryParse(cbxBaudRates.SelectedItem.ToString(), out baudRate))
                    {
                        baudRate = -1;
                        AddTextToTerminal("ERR: Invalid Baud Rate.");
                        return;
                    }
                }
                else
                {
                    AddTextToTerminal("ERR: Select a Baud Rate.");
                    return;
                }

                ArduinoPort.BaudRate = baudRate;
                ArduinoPort.PortName = comPort;
                try
                {
                    ArduinoPort.Open();
                    AddTextToTerminal("## " + comPort + "@" + baudRate + " opened.");
                }
                catch (Exception ex)
                {
                    if (ex is UnauthorizedAccessException)
                    {
                        MessageBox.Show("Can't open " + comPort + " is it in use?",
                            ex.GetType().FullName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (ex is IOException)
                    {
                        MessageBox.Show("Can't open " + comPort + "\nPort name or settings invalid.", ex.GetType().FullName,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("Can't open " + comPort, ex.GetType().FullName,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    return;
                }
                // Immediately ask for version information as proof of connect and to make sure
                // it's one we can actually command
                btnConnect.Text = "Disconnect";
                SetControlsConnectStatus(true);
                GetNexDomeSettings();
                ReceiveTimer.Enabled = true;
                StatusTimer.Enabled = true;
            }
            else
            {
                if (changesMade > 0) UnsavedChanges("Disconnecting");
                ArduinoPort.Close();
                btnConnect.Text = "Connect";
                ReceiveTimer.Enabled = false;
                StatusTimer.Enabled = false;
                SetControlsConnectStatus(false);
            }
        }
        private void SetControlsConnectStatus(bool connected)
        {
            lblControllerVersion.Text = "";
            lblControllerVersion.Enabled = connected;
            lblRotVolts.Text = "";
            lblRotVolts.Enabled = connected;
            lblShutVolts.Text = "";
            lblShutVolts.Enabled = connected;
            lblCutVolts.Text = "";
            lblCutVolts.Enabled = connected;
            cbxPorts.Enabled = !connected;
            cbxBaudRates.Enabled = !connected;
            if (connected == false) cbxStepMode.SelectedIndex = 0;
            cbxStepMode.Enabled = connected;
            btnStepMode.Enabled = connected;
            tbxMaxSpeed.Text = "";
            tbxMaxSpeed.Enabled = connected;
            btnMaxSpeed.Enabled = connected;
            tbxAcceleration.Text = "";
            tbxAcceleration.Enabled = connected;
            btnAcceleration.Enabled = connected;
            tbxStepsPerRotation.Text = "";
            tbxStepsPerRotation.Enabled = connected;
            btnStepsPerRotation.Enabled = connected;
            chkReversed.Checked = connected;
            chkReversed.Enabled = connected;
            tbxCommand.Text = "";
            tbxCommand.Enabled = connected;
            btnCommand.Enabled = connected;
            tbxTerminal.Enabled = connected;
            tbxHomeAzimuth.Text = "";
            tbxHomeAzimuth.Enabled = connected;
            btnHomeAzimuth.Enabled = connected;
            tbxParkAzimuth.Text = "";
            tbxParkAzimuth.Enabled = connected;
            btnParkAzimuth.Enabled = connected;
            tbxHomeCenter.Text = "";
            tbxHomeCenter.Enabled = connected;
            btnHomeCenter.Enabled = connected;
            btnDoHoming.Enabled = connected;
            btnDoCalibrate.Enabled = connected;
            btnParkDome.Enabled = connected;
            btnSaveSettings.Enabled = connected;
            tbxGotoAz.Text = "";
            tbxGotoAz.Enabled = connected;
            btnGoToAz.Enabled = connected;
            tbxGotoPos.Text = "";
            tbxGotoPos.Enabled = connected;
            btnGoToPos.Enabled = connected;
            btnRotateCCW.Enabled = connected;
            btnRotateCW.Enabled = connected;
            lblDisplayAz.Text = "";
            lblDisplayPos.Text = "";
            lblMultiStatus.Text = "";
            btnSTOP.Enabled = connected;
            lastStepMode = 0;
            lblHomedState.Enabled = connected;
            lblSeekMode.Enabled = connected;
        }
        private void SerialDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string part = "";
            int where = 0;
            serialBuffer += ArduinoPort.ReadExisting();
            while (serialBuffer.IndexOf("\r") != -1)
            {
                where = serialBuffer.IndexOf("\r");
                part = serialBuffer.Substring(0, where);
                serialBuffer = serialBuffer.Substring(where + 2);
                messageList.Add(part);
            }
        }

        private void btnFullTurn_Click(object sender, EventArgs e)
        {
            long fullTurn;

            if (long.TryParse(tbxStepsPerRotation.Text, out fullTurn))
            {
                fullTurn -= 1;
                Debug.Print(fullTurn.ToString());
                SendCommand(CMD_MOVERELATIVE, fullTurn.ToString());
            }
            else
            {
                AddTextToTerminal("ERR: Invalid value");
            }
        }

        public void ParseSerialMessage()
        {
            string message, cmd, value;
            int localInt;
            while (messageList.Count > 0)
            {
                message = messageList.First();
                messageList.RemoveAt(0);

                if (message == null) return;
                cmd = message.Substring(0, 1);
                if (cmd == "%")
                {
                    message = message.Substring(1);
                }
                else
                {
                    Debug.Print(message);
                }
                cmd = message.Substring(0, 1);
                value = message.Substring(1).Trim();

                switch (cmd)
                {
                    case "_":
                        GetNexDomeSettings();
                        break;
                    case "/":
                        AddTextToTerminal("<- Settings saved to controller EEPROM.");
                        break;
                    case "-":
                        AddTextToTerminal(value);
                        break;
                    case "C":
                        AddTextToTerminal("<- " + message.Substring(1));
                        break;
                    case "|":
                        tbxHomeCenter.Text = value;
                        break;
                    case "*":
                        tbxAcceleration.Text = value;
                        break;
                    case "$":
                        localInt = cbxStepMode.FindStringExact(value);
                        if (localInt != lastStepMode)
                        {
                            lastStepMode = Convert.ToInt32(value);
                            cbxStepMode.SelectedIndex = localInt;
                        }
                        break;
                    case "#":
                        tbxMaxSpeed.Text = value;
                        break;
                    case "^":
                        int dir;
                        if (!int.TryParse(value, out dir)) return;
                        if (dir == -1)
                        {
                            lblMultiStatus.Text = "<<<";
                        }
                        else if (dir == 1)
                        {
                            lblMultiStatus.Text = ">>>";
                        }
                        else
                        {
                            lblMultiStatus.Text = "---";
                        }
                        break;
                    case "(":
                        seekStatus = Convert.ToInt32(value);
                        lblSeekMode.Text = seekStates[seekStatus];
                        break;
                    case "I":
                        tbxHomeAzimuth.Text = value;
                        break;
                    case "K":
                        string[] volts = value.Split(' ');
                        lblRotVolts.Text = IntToMillivolts(volts[0]);
                        lblShutVolts.Text = volts[1];
                        lblCutVolts.Text = volts[2];
                        break;
                    case "M":
                        //todo: Set stop to red or gray
                        // = value;
                        break;
                    case "N":
                        tbxParkAzimuth.Text = value;
                        break;
                    case "Q":
                        lblDisplayAz.Text = value;
                        break;
                    case "P":
                        lblDisplayPos.Text = value;
                        break;
                    case "S":
                        AddTextToTerminal("<- Synchonized to " + value + (char)176);
                        break;
                    case "T":
                        stepsPerRotation = Convert.ToInt64(value);
                        tbxStepsPerRotation.Text = value;
                        break;
                    case "V":
                        Debug.Print("Version info");
                        lblControllerVersion.Text = value;
                        break;
                    case "Y":
                        int.TryParse(value, out localInt);
                        if (localInt == 1)
                        {
                            chkReversed.Checked = true;
                        }
                        else
                        {
                            chkReversed.Checked = false;
                        }
                        break;
                    case "Z":
                        //todo: Convert to words
                        localInt = Convert.ToInt32(value);
                        lblHomedState.Text = homeStates[localInt + 1];
                        break;
                }
            }
        }

        private void GetNexDomeSettings()
        {
            AddTextToTerminal("-> Get controller settings.");

            SendCommand(CMD_VERSION);
            SendCommand(CMD_GETHOME);
            SendCommand(CMD_GETPARKAZ);
            SendCommand(CMD_MAXSPEED);
            SendCommand(CMD_STEPMODE);
            SendCommand(CMD_ACCEL);
            SendCommand(CMD_STEPSPERROT);
            SendCommand(CMD_REVERSED);
            SendCommand(CMD_CENTER);
            SendCommand(CMD_HOMESTATUS);
            SendCommand(CMD_GETVOLTS);
            AddTextToTerminal("<- Settings loaded from controller EEPROM.");
        }

        private void receiveTimer_Tick(object sender, EventArgs e)
        {
            if (messageList.Count > 0)
            {
                ParseSerialMessage();
            }
        }
        private void statusTime_Tick(object sender, EventArgs e)
        {
            if (ArduinoPort.IsOpen == true)
            {
                ArduinoPort.WriteLine("%^");
                ArduinoPort.WriteLine("%q");
                ArduinoPort.WriteLine("%p");
                ArduinoPort.WriteLine("%m");
                ArduinoPort.WriteLine("%(");
                ArduinoPort.WriteLine("%z");

            }
        }

        private void SendCommand(string command, string value = "")
        {
            if (ArduinoPort.IsOpen)
            {
                try
                {
                    if (value.Length > 0) command += " " + value;
                    command = "%" + command; // All commands from configurator have this first for extra feedback ASCOM can't handle.
                    ArduinoPort.WriteLine(command);
                }
                catch (Exception ex)
                {
                    if (ex is InvalidOperationException)
                    {
                        MessageBox.Show(ArduinoPort.PortName + " not open. is it in use?",
                            ex.GetType().FullName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (ex is ArgumentNullException)
                    {
                        MessageBox.Show("Attempt to send null value", ex.GetType().FullName,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(ArduinoPort.PortName + " error.", ex.GetType().FullName,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            else
            {
                AddTextToTerminal("Serial port not open. (" + command + ")");
            }
        }
        private bool IsFloat(string strValue)
        {
            float value;
            string sRes = "";
            bool res = false;

            if (strValue.Length > 0)
            {
                if (!float.TryParse(strValue, out value))
                {
                    sRes = "Invalid value";
                }
                else
                {
                    res = true;
                }
            }
            else
            {
                sRes = "Empty value";

            }
            if (res == false)
            {
                AddTextToTerminal("ERR: " + sRes);
            }
            return res;
        }
        private bool IsLong(string strValue)
        {
            long value;
            string sRes = "";
            bool res = false;

            if (strValue.Length > 0)
            {
                if (!long.TryParse(strValue, out value))
                {
                    sRes = "Invalid value";
                }
                else
                {
                    res = true;
                }
            }
            else
            {
                sRes = "Empty value";

            }
            if (res == false)
            {
                AddTextToTerminal("ERR: " + sRes);
            }
            return res;
        }
        private void btnStepMode_Click(object sender, EventArgs e)
        {
            int newSteps;

            if (cbxStepMode.SelectedIndex > 0)
            {
                newSteps = Convert.ToInt32(cbxStepMode.SelectedItem.ToString());
                if (newSteps != lastStepMode)
                {
                    lastStepMode = newSteps;
                    SendCommand(CMD_STEPMODE, newSteps.ToString());
                    changesMade++;
                }
            }

        }
        private void btnMaxSpeed_Click(object sender, EventArgs e)
        {
            if (IsFloat(tbxMaxSpeed.Text))
            {
                SendCommand(CMD_MAXSPEED, tbxMaxSpeed.Text);
                changesMade++;
            }
        }
        private void btnAcceleration_Click(object sender, EventArgs e)
        {
            if (IsFloat(tbxAcceleration.Text))
            {
                SendCommand(CMD_ACCEL, tbxAcceleration.Text);
                changesMade++;
            }
        }
        private void btnStepsPerRotation_Click(object sender, EventArgs e)
        {
            if (IsLong(tbxStepsPerRotation.Text))
            {
                SendCommand(CMD_STEPSPERROT, tbxStepsPerRotation.Text);
                changesMade++;

            }
        }
        private void btnSTOP_Click(object sender, EventArgs e)
        {
            SendCommand(CMD_STOP);
            AddTextToTerminal("-> Stop!");
        }
        private void chkReversed_Click(object sender, EventArgs e)
        {
            int state = 0;
            string msg;
            if (chkReversed.Checked == true) state = 1;
            if (state == 0)
            {
                msg = "Rotator set to forward.";
            }
            else
            {
                msg = "Rotator set to reverse.";
            }
            AddTextToTerminal(msg);
            SendCommand(CMD_REVERSED, state.ToString());
            changesMade++;
        }
        private void btnCommand_Click(object sender, EventArgs e)
        {
            string cmd = tbxCommand.Text;
            if (cmd.Length > 0)
            {
                SendCommand(cmd);
                AddTextToTerminal("-> " + cmd);
                changesMade++;
            }
            else
            {
                AddTextToTerminal("Empty command string.");
            }
        }
        private void btnHomeAzimuth_Click(object sender, EventArgs e)
        {
            if (IsFloat(tbxHomeAzimuth.Text))
            {
                SendCommand(CMD_SETHOME, tbxHomeAzimuth.Text);
                changesMade++;
            }
        }
        private void btnParkAzimuth_Click(object sender, EventArgs e)
        {
            if (IsFloat(tbxParkAzimuth.Text))
            {
                SendCommand(CMD_SETPARK, tbxParkAzimuth.Text);
                changesMade++;
            }
        }
        private void btnParkDome_Click(object sender, EventArgs e)
        {
            if (IsFloat(tbxParkAzimuth.Text))
            {
                SendCommand(CMD_GOTOAZ, tbxParkAzimuth.Text);
            }
        }
        private void btnHomeCenter_Click(object sender, EventArgs e)
        {
            if (IsLong(tbxHomeCenter.Text))
            {
                SendCommand(CMD_CENTER, tbxHomeCenter.Text);
                changesMade++;
            }
        }
        private void btnDoHoming_Click(object sender, EventArgs e)
        {
            SendCommand("h");

        }
        private void btnDoCalibrate_Click(object sender, EventArgs e)
        {
            SendCommand(CMD_CALIBRATE);
            changesMade++;
        }
        private void btnSync_Click(object sender, EventArgs e)
        {
            if (IsFloat(tbxGotoAz.Text))
            {
                SendCommand(CMD_SYNC, tbxGotoAz.Text);
            }
        }
        private void btnGoToAz_Click(object sender, EventArgs e)
        {
            if (IsFloat(tbxGotoAz.Text))
            {
                SendCommand(CMD_GOTOAZ, tbxGotoAz.Text);
            }
        }
        private void RotateButton(long direction)
        {
            SendCommand(CMD_MOVERELATIVE, (direction * rotateButtonSteps).ToString());
        }
        private void btnRotateCW_MouseDown(object sender, MouseEventArgs e)
        {
            RotateButton(DIRECTION_POSITIVE);
            cwButtonDown = true;
        }
        private void btnRotateCW_MouseUp(object sender, MouseEventArgs e)
        {
            cwButtonDown = false;
        }
        private void btnRotateCCW_MouseDown(object sender, MouseEventArgs e)
        {
            RotateButton(DIRECTION_NEGATIVE);
            ccwButtonDown = true;
        }
        private void btnRotateCCW_MouseUp(object sender, MouseEventArgs e)
        {
            ccwButtonDown = false;
        }
        private void btnGoToPos_Click(object sender, EventArgs e)
        {
            if (IsLong(tbxGotoPos.Text))
            {
                SendCommand(CMD_POS, tbxGotoPos.Text);
            }
        }
        private void UnsavedChanges(string reason)
        {
            DialogResult res = MessageBox.Show("You have unsaved changes, Save them now?", reason + "...", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);
            if (res == DialogResult.Yes)
            {
                changesMade = 0;
                SendCommand("/");
            }
        }
        private void btnSaveSettings_Click(object sender, EventArgs e)
        {
            SendCommand("/");
            changesMade = 0;
            AddTextToTerminal("-> Save Your Settings");
        }
        private void btnLoadSettings_Click(object sender, EventArgs e)
        {
            GetNexDomeSettings();
        }
        private void Rotate_Timer_Tick(object sender, EventArgs e)
        {
            if (cwButtonDown == true)
            {
                RotateButton(DIRECTION_POSITIVE);
            }
            else if (ccwButtonDown == true)
            {
                RotateButton(DIRECTION_NEGATIVE);
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (changesMade > 0) UnsavedChanges("Exiting");
        }
    }
}
