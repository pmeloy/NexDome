//tabs=4
// --------------------------------------------------------------------------------
// TODO fill in this information for your driver, then remove this line!
//
// ASCOM Dome driver for PDM
//
// Description:	Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam
//				nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam
//				erat, sed diam voluptua. At vero eos et accusam et justo duo
//				dolores et ea rebum. Stet clita kasd gubergren, no sea takimata
//				sanctus est Lorem ipsum dolor sit amet.
//
// Implements:	ASCOM Dome interface version: 2
// Author:		Pat Meloy
//
// Edit Log:
//
// Date			Who	Vers	Description
// -----------	---	-----	-------------------------------------------------------
// 06-05-2018	PDM	6.3.2	Initial edit, created from ASCOM driver template
// --------------------------------------------------------------------------------
//


// This is used to define code in the template that is specific to one class implementation
// unused code canbe deleted and this definition removed.
#define Dome

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Runtime.InteropServices;
using System.Reflection;
using System.Text;
using System.Threading;

using ASCOM;
using ASCOM.Astrometry;
using ASCOM.Astrometry.AstroUtils;
using ASCOM.Utilities;
using ASCOM.DeviceInterface;
using System.Globalization;
using System.Collections;

namespace ASCOM.PDM
{
    //
    // Your driver's DeviceID is ASCOM.PDM.Dome
    //
    // The Guid attribute sets the CLSID for ASCOM.PDM.Dome
    // The ClassInterface/None addribute prevents an empty interface called
    // _PDM from being created and used as the [default] interface
    //
    // TODO Replace the not implemented exceptions with code to implement the function or
    // throw the appropriate ASCOM exception.
    //

    /// <summary>
    /// PDM NexDome Driver
    /// </summary>
    [Guid("2e7b0c64-b9d3-41ab-9a59-9a991519c521")]
    [ClassInterface(ClassInterfaceType.None)]
    public class Dome : IDomeV2
    {
        #region "ASCOM default variables etc"
        /// <summary>
        /// ASCOM DeviceID (COM ProgID) for this driver.
        /// The DeviceID is used by ASCOM applications to load the driver at runtime.
        /// </summary>
        internal static string driverID = "ASCOM.PDM.Dome";
        // TODO Change the descriptive string for your driver then remove this line
        /// <summary>
        /// Driver description that displays in the ASCOM Chooser.
        /// </summary>
        private static string driverDescription = "PDM NexDome Driver";

        internal static string comPortProfileName = "COM Port"; // Constants used for Profile persistence
        internal static string comPortDefault = "COM3";
        internal static string traceStateProfileName = "Trace Level";
        internal static string traceStateDefault = "true";

        internal static string comPort; // Variables to hold the currrent device configuration

        /// <summary>
        /// Private variable to hold the connected state
        /// </summary>
        private bool connectedState;

        /// <summary>
        /// Private variable to hold an ASCOM Utilities object
        /// </summary>
        private Util utilities;

        /// <summary>
        /// Private variable to hold an ASCOM AstroUtilities object to provide the Range method
        /// </summary>
        private AstroUtils astroUtilities;

        /// <summary>
        /// Variable to hold the trace logger object (creates a diagnostic log file with information that you specify)
        /// </summary>
        internal static TraceLogger tl;

        #endregion

        #region "My variables"

        // Timers
        System.Windows.Forms.Timer SerialMessageTimer, StatusUpdateTimer;
        private int slowUpdateCounter =31;

        internal static bool canFindHome, canPark, canSetPark, canSetShutter, canSetAltitude, canSetAzimuth, canSlave, canSyncAzimuth;
        //Rotator values
        internal static long rotatorPosition, rotatorStepsPer, rotatorMaxSpeed, rotatorAcceleration;
        internal static double azimuth, rotatorHomeAz, rotatorParkAz;
        internal static bool atHome, atPark, isSlaved, rotatorReversed = false, isRaining = false, rainSensorTwice = false;
        internal static string rotatorVersion;
        internal static int rotatorSlewDirection, rotatorHomedStatus, rotatorSeekState, rotatorVoltage, rotatorCutoff, rotatorRainInterval, rotatorRainAction;

        // Shutter values
        internal static string shutterVersion;
        internal static long shutterPosition, shutterStepsPer, shutterMaxSpeed, shutterAcceleration;
        internal static double altitude;
        internal static bool shutterReversed = false, shutterCloseOnLowVoltage = false;
        internal static int shutterVoltage, shutterCutoff;

        #region Serial command character constants
        internal const string COMMENT_CMD = "%";
        internal const string ACCELERATION_ROTATOR_CMD  = "e"; // Get/Set stepper acceleration
        internal const string ABORT_MOVE_CMD            = "a"; // Tell everything to STOP!
        internal const string CALIBRATE_ROTATOR_CMD     = "c"; // Calibrate the dome
        internal const string ERROR_ROTATOR_AZ          = "o"; // Azimuth error when I finally implement it
        internal const string GOTO_ROTATOR_CMD          = "g"; // Get/set dome azimuth
        internal const string HOME_ROTATOR_CMD          = "h"; // Home the dome
        internal const string HOMEAZ_ROTATOR_CMD        = "i"; // Get/Set home position
        internal const string HOMED_ROTATOR_STATUS      = "z"; // Get homed status
        internal const string MOVE_RELATIVE_ROTATOR_CMD  = "b"; // Move relative - steps from current position +/-
        internal const string PARKAZ_ROTATOR_CMD        = "l"; // Get/Set park azimuth
        internal const string POSITION_ROTATOR_CMD      = "p"; // Get/Set step position
        internal const string RAIN_ROTATOR_ACTION       = "n";
        internal const string RAIN_ROTATOR_CMD          = "f"; // Get rain sensor state
        internal const string RAIN_ROTATOR_TWICE_CMD    = "j"; // Get/Set rain sensor needs to positives to trigger
        internal const string REVERSED_ROTATOR_CMD      = "y"; // Get/Set stepper reversed status
        internal const string SEEKSTATE_GET             = "d"; // Get seek mode (homing, calibrating etc)
        internal const string SLEW_ROTATOR_STATUS       = "m"; // Get Slewing status/direction
        internal const string SPEED_ROTATOR_CMD         = "r"; // Get/Set step rate (speed)
        internal const string STEPSPER_ROTATOR_CMD      = "t"; // GetSteps per rotation
        internal const string SYNC_ROTATOR_CMD          = "s"; // Sync to telescope
        internal const string VERSION_ROTATOR_GET       = "v"; // Get Version string
        internal const string VOLTS_ROTATOR_CMD         = "k"; // Get volts and get/set cutoff

        internal const string ACCELERATION_SHUTTER_CMD = "E"; // Get/Set stepper acceleration
        internal const string CAL_SHUTTER_CMD = "L"; // Calibrate the shutter
        internal const string CLOSE_SHUTTER_CMD = "C"; // Close shutter
        internal const string ELEVATION_SHUTTER_CMD = "G"; // Get/Set altitude
        internal const string HELLO_CMD = "H"; // Let shutter know we're here
        internal const string HOMED_SHUTTER_GET = "Z"; // Get homed status (has it been closed)
        internal const string OPEN_SHUTTER_CMD = "O"; // Open the shutter
        internal const string POSITION_SHUTTER_GET = "P"; // Get step position
        internal const string RAIN_ROTATOR_GET = "F"; // Get rain status
        internal const string SPEED_SHUTTER_CMD = "R"; // Get/Set step rate (speed)
        internal const string REVERSED_SHUTTER_CMD = "Y"; // Get/Set stepper reversed status
        internal const string SLEEP_SHUTTER_CMD = "S"; // Get/Set radio sleep settings
        internal const string STATE_SHUTTER_GET = "M"; // Get shutter state
        internal const string STEPSPER_SHUTTER_CMD = "T"; // Get/Set steps per stroke
        internal const string VERSION_SHUTTER_GET = "V"; // Get version string
        internal const string VOLTS_SHUTTER_CMD = "K"; // Get volts and get/set cutoff
        internal const string LOWCLOSE_SHUTTER_CMD = "B"; // Get/Set close shutter on low voltage setting
        #endregion

        internal enum HomeStatus
        {
            NEVER_HOMED,
            HOMED,
            ATHOME
        };

        List<string> serialMessageList;

        SerialPort  serialPort = new SerialPort();

        string serialBuffer; // For holding serial data

        internal static CultureInfo sourceCulture;
        internal static NumberStyles numberStyle;
        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="PDM"/> class.
        /// Must be public for COM registration.
        /// </summary>
        public Dome()
        {
            // For forcing locales so I can test different languages

            //Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("fr");
            //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fr");

            //sourceCulture = CultureInfo.CreateSpecificCulture("en-US");
            sourceCulture = CultureInfo.InvariantCulture;
            numberStyle = NumberStyles.Number;

            tl = new TraceLogger("", "PDM");
            ReadProfile(); // Read device configuration from the ASCOM Profile store

            tl.LogMessage("Dome", "Starting initialisation");

            connectedState = false; // Initialise connected to false
            utilities = new Util(); //Initialise util object
            astroUtilities = new AstroUtils(); // Initialise astro utilities object
            //TODO: Implement your additional construction here
            tl.LogMessage("Dome", "Completed initialisation");
            SerialMessageTimer = new System.Windows.Forms.Timer();
            SerialMessageTimer.Tick += new EventHandler(OnSerialTimer);
            SerialMessageTimer.Interval = 100;
            SerialMessageTimer.Enabled = false;
            serialMessageList = new List<string>();
            StatusUpdateTimer = new System.Windows.Forms.Timer();
            StatusUpdateTimer.Tick += new EventHandler(OnStatusUpdateTimer);
            StatusUpdateTimer.Interval = 1000;
            StatusUpdateTimer.Enabled = false;
        }


        //
        // PUBLIC COM INTERFACE IDomeV2 IMPLEMENTATION
        //
        #region Common properties and methods.

        /// <summary>
        /// Displays the Setup Dialog form.
        /// If the user clicks the OK button to dismiss the form, then
        /// the new settings are saved, otherwise the old values are reloaded.
        /// THIS IS THE ONLY PLACE WHERE SHOWING USER INTERFACE IS ALLOWED!
        /// </summary>
        public bool Connected
        {
            get
            {

                return serialPort.IsOpen;
            }
            set
            {
                tl.LogMessage("Connected Set", value.ToString());
                if (value == IsConnected)
                    return;

                if (value)
                {
                    connectedState = true;
                    LogMessage("Connected Set", "Connecting to port {0}", comPort);
                    serialPort.DataReceived += new SerialDataReceivedEventHandler(SerialDataReceived);
                    serialPort.PortName = comPort;
                    serialPort.BaudRate = 9600;
                    serialPort.DataBits = 8;
                    serialPort.Handshake = Handshake.None;
                    serialPort.StopBits = StopBits.One;
                    serialPort.DtrEnable = true;


                    try
                    {
                        // now open the com port
                        serialPort.Open();
                        connectedState = true;
                        // clear any garbage from the buffers that may be there
                        serialPort.DiscardInBuffer();
                        GetSetupInfo();
                        SerialMessageTimer.Enabled = true;
                        StatusUpdateTimer.Enabled = true;
                    }
                    catch (Exception ex)
                    {
                        connectedState = false;
                        throw new ASCOM.NotConnectedException("Connection failed " + ex.GetType().FullName);
                    }
                }
                else
                {
                    connectedState = false;
                    serialPort.Close();
                    SerialMessageTimer.Enabled = false;
                    StatusUpdateTimer.Enabled = false;
                    LogMessage("Connected Set", "Disconnecting from port {0}", comPort);
                    // TODO disconnect from the device
                }
            }
        }

        public void SetupDialog()
        {
            // consider only showing the setup dialog if not connected
            // or call a different dialog if connected
            if (IsConnected == true)
            {
                CheckConnected("Setup Dialog");
                tl.LogMessage("Setup Dialog","Show");
                using (SetupForm F = new SetupForm())
                {
                    F.myDome = this;
                    try
                    {
                        if (F.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            LogMessage("Setup Dialog", "Write Profile");
                            GetSetupInfo();
                            WriteProfile();
                        }
                    }
                    catch (Exception ex)
                    {
                        LogMessage("Load Setup Failed ", ex.GetType().FullName.ToString());
                    }
                }
            }
            else
            {
                using (ComportChooser F = new ComportChooser())
                {
                    var result = F.ShowDialog();
                    if (result == System.Windows.Forms.DialogResult.OK) WriteProfile(); // Persist device configuration values to the ASCOM Profile store
                }
            }
        }
        #endregion

        #region "Other ASCOM stuff"
        public ArrayList SupportedActions
        {
            get
            {
                tl.LogMessage("SupportedActions Get", "Returning empty arraylist");
                return new ArrayList();
            }
        }

        public string Action(string actionName, string actionParameters)
        {
            LogMessage("", "Action {0}, parameters {1} not implemented", actionName, actionParameters);
            throw new ASCOM.ActionNotImplementedException("Action " + actionName + " is not implemented by this driver");
        }

        public void CommandBlind(string command, bool raw)
        {
            CheckConnected("CommandBlind");

        }

        public bool CommandBool(string command, bool raw)
        {
            //CheckConnected("CommandBool");
            //string ret = CommandString(command, raw);
            // TODO decode the return string and return true or false
            // or
            throw new ASCOM.MethodNotImplementedException("CommandBool");
            // DO NOT have both these sections!  One or the other
        }

        public string CommandString(string command, bool raw)
        {
            //CheckConnected("CommandString");
            // it's a good idea to put all the low level communication with the device here,
            // then all communication calls this function
            // you need something to ensure that only one command is in progress at a time

            throw new ASCOM.MethodNotImplementedException("CommandString");

        }

        public void Dispose()
        {
            // Clean up the tracelogger and util objects
            tl.Enabled = false;
            tl.Dispose();
            tl = null;
            utilities.Dispose();
            utilities = null;
            astroUtilities.Dispose();
            astroUtilities = null;
        }

        public string Description
        {
            // TODO customise this device description
            get
            {
                tl.LogMessage("Description Get", driverDescription);
                return driverDescription;
            }
        }

        public string DriverInfo
        {
            get
            {
                string version = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
                // TODO customise this driver description
                string driverInfo = GlobalStrings.DriverVersionText + " " + version; // String.Format(CultureInfo.InvariantCulture, "{0}.{1}.{2}.{3}", version.Major, version.Minor, version.Build, version.Revision);
                return driverInfo;
            }
        }

        public string DriverVersion
        {
            get
            {
                //Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                string driverVersion = FileVersionInfo.GetVersionInfo(Assembly.GetExecutingAssembly().Location).FileVersion;
                tl.LogMessage("DriverVersion Get", driverVersion);
                return driverVersion;
            }
        }

        public short InterfaceVersion
        {
            // set by the driver wizard
            get
            {
                LogMessage("InterfaceVersion Get", "2");
                return Convert.ToInt16("2");
            }
        }

        public string Name
        {
            get
            {
                string name = "PDMDome " + DriverVersion;
                tl.LogMessage("Name Get", name);
                return name;
            }
        }

        #endregion

        #region "Serial handling"

        internal void SendSerial(String command)
        {
            try
            {
                serialPort.Write(command + "#");
            }
            catch (Exception ex)
            {
                LogMessage("SendSerial()","Exception ", ex.GetType().FullName.ToString());
            }
        }

        private void SerialDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string part = "";
            int where = 0;
            try
            {
                serialBuffer += serialPort.ReadExisting();
                while (serialBuffer.IndexOf("#") != -1)
                {
                    where = serialBuffer.IndexOf("#");
                    part = serialBuffer.Substring(0, where);
                    serialBuffer = serialBuffer.Substring(where + 1);
                    if (String.IsNullOrEmpty(part) == false)
                    {
                        serialMessageList.Add(part);
                        tl.LogMessage("serialMessageList part", part);
                    }
                }
            }
            catch (Exception ex)
            {
                LogMessage("Serial Receive Exception", ex.ToString());
            }
        }
        #endregion

        #region "Timer and serial buffer processing"

        private void OnStatusUpdateTimer(Object source, EventArgs e)
        {
            SendSerial(POSITION_ROTATOR_CMD);
            SendSerial(HOMED_ROTATOR_STATUS);
            SendSerial(SEEKSTATE_GET);
            SendSerial(SLEW_ROTATOR_STATUS);

            if (slowUpdateCounter >= 30)
            {
                tl.LogMessage("Slow update","Get");
					 if (canSetShutter == true)
					 {
						 SendSerial(POSITION_SHUTTER_GET);
						 SendSerial(STATE_SHUTTER_GET);
					 }
                SendSerial(RAIN_ROTATOR_GET);
                SendSerial(VOLTS_ROTATOR_CMD);
                slowUpdateCounter = 0;
                if (canSetShutter) SendSerial(VOLTS_SHUTTER_CMD);
            }
            slowUpdateCounter++;
        }

        private void OnSerialTimer(Object source, EventArgs e)
        {
            string message = "", command = "", value = "";
            int localInt;
            // Check for complete serial messages in messageList
            while(serialMessageList.Count > 0)
            {
                message = serialMessageList.FirstOrDefault();
                serialMessageList.RemoveAt(0);
                if (String.IsNullOrEmpty(message) == true)
                {
                    LogMessage("Serial Receive", "Null Message");
                    return;
                }

                if (message.Length < 2)
                {
                    LogMessage("Serial Receive", "Short message ({0})", message);
                    return;
                }
                message.Trim();

                command = message.Substring(0, 1);
                value = message.Substring(1);

                switch (command)
                {
                    case COMMENT_CMD:
                        tl.LogMessage("Comment", value);
                        break;
                    case ACCELERATION_ROTATOR_CMD:
                        if (long.TryParse(value, numberStyle, sourceCulture, out rotatorAcceleration) == true)
                        {
                            LogMessage("Rotator Get", "Acceleration ({0})", rotatorAcceleration);
                        }
                        else
                        {
                            LogMessage("Rotator Get", "Acceleration Invalid ({0})", value);
                        }
                        break;
                    case ACCELERATION_SHUTTER_CMD:
                        if (long.TryParse(value, numberStyle, sourceCulture, out shutterAcceleration) == true)
                        {
                            LogMessage("Shutter Get", "Acceleration ({0})", shutterAcceleration);
                        }
                        else
                        {
                            LogMessage("Shutter Get", "Acceleration Invalid ({0})", value);
                        }

                        break;
                    case HOMEAZ_ROTATOR_CMD:
                        if (double.TryParse(value, numberStyle, sourceCulture, out rotatorHomeAz) == true)
                        {
                            LogMessage("Rotator Get", "Home Azimuth ({0})", rotatorHomeAz);
                        }
                        else
                        {
                            LogMessage("Rotator Get", "Home Azimuth Invalid ({0})", value);
                        }
                        break;
                    case HOMED_ROTATOR_STATUS:
                        if (int.TryParse(value, numberStyle, sourceCulture, out rotatorHomedStatus) == false)
                        {
                            LogMessage("Rotator Get", "Homed Status Invalid ({0})", value);
                        }
                        break;
                    case MOVE_RELATIVE_ROTATOR_CMD:
                        if (value.Equals("L") == true)
                        {
                            tl.LogMessage("Rotator SET", "Abort, low voltage");
                        }
                        break;
                    case OPEN_SHUTTER_CMD:
                        if (value.Equals("R") == true)
                        {
                            tl.LogMessage("Shutter Set", "Open failed: rain");
                        }
                        if (value.Equals("N") == true)
                        {
                            tl.LogMessage("Shutter SET", "Open failed: Position unknown, must close first");
                        }
                        if (value.Equals("V") == true)
                        {
                            tl.LogMessage("Shutter SET", "Open failed: Voltage too low");
                        }
                        break;
                    case PARKAZ_ROTATOR_CMD:
                        if (double.TryParse(value, numberStyle, sourceCulture, out rotatorParkAz) == true)
                        {
                            LogMessage("Rotator Get", "Park Azimuth ({0})", rotatorParkAz);
                        }
                        else
                        {
                            LogMessage("Rotator Get", "Park Azimuth Invalid ({0})", value);
                        }
                        break;
                    case POSITION_ROTATOR_CMD:
                        if (value.Equals("L") == false)
                        {

                            if (long.TryParse(value, numberStyle, sourceCulture, out rotatorPosition) == true)
                            {
                                if (rotatorStepsPer > 0)
                                {
                                    azimuth = Math.Round(360.0 * (double)rotatorPosition / (double)rotatorStepsPer, 2);
                                }

                            }
                            else
                            {
                                LogMessage("Rotator Position", "Invalid ({0})", value);
                            }
                        }
                        else
                        {
                            tl.LogMessage("Rotator SET", "Move Cancelled: LOW VOLTAGE");
                            throw new ASCOM.InvalidOperationException("Positioning Failed: Rotator voltage too low");
                        }
                        break;
                    case POSITION_SHUTTER_GET:
                        if (long.TryParse(value, numberStyle, sourceCulture, out shutterPosition) == true)
                        {
                            if (shutterStepsPer > 0)
                            {
                                altitude = Math.Round(90.0 * (double)shutterPosition / (double) shutterStepsPer,2);
                            }
                        }
                        else
                        {
                            LogMessage("Shutter Position", "Invalid ({0})", value);
                        }
                        break;
                    case RAIN_ROTATOR_ACTION:
                        if (int.TryParse(value, numberStyle, sourceCulture, out rotatorRainAction) == true)
                        {
                            LogMessage("Rotator Get", "Rain action ({0})", rotatorRainAction);
                            if (rotatorRainAction > 2) rotatorRainAction = 0;
                        }
                        else
                        {
                            LogMessage("Rotator Get", "Rain action invalid ({0})", value);
                        }
                        break;
                    case RAIN_ROTATOR_CMD:
                        if (int.TryParse(value, numberStyle,sourceCulture, out rotatorRainInterval) == true)
                        {
                            LogMessage("Rotator Get", "Rain check interval ({0})", rotatorRainInterval);
                        }
                        else
                        {
                            LogMessage("Rotator Get", "Rain check interval invalid ({value})", value);
                        }
                        break;
                    case RAIN_ROTATOR_GET:
                        if (value.Equals("1") == true)
                        {
                            isRaining = true;
                        }
                        else
                        {
                            isRaining = false;
                        }
                        LogMessage("Rotator Get", "Raining = ({0})", value);
                        break;
                    case RAIN_ROTATOR_TWICE_CMD:
                        rainSensorTwice = (value.Equals("1"));
                        LogMessage("Rotator Get", "Rain sensor twice ({0})", value);
                        break;
                    case REVERSED_ROTATOR_CMD:
                        if (value.Equals("0") == true)
                        {
                            rotatorReversed = false;
                            LogMessage("Rotator Get", "Reversed false");
                        }
                        else if (value.Equals("1") == true)
                        {
                            rotatorReversed = true;
                            LogMessage("Rotator Get", "Reversed true");
                        }
                        else
                        {
                            LogMessage("Rotator Get", "Reversed invalid ({0})", value);
                        }
                        break;
                    case REVERSED_SHUTTER_CMD:
                        if (value.Equals("0") == true)
                        {
                            LogMessage("Shutter Get", "Reversed false");
                            rotatorReversed = false;
                        }
                        else if (value.Equals("1") == true)
                        {
                            LogMessage("Shutter Get", "Reversed true");
                            rotatorReversed = false;
                        }
                        else
                        {
                            LogMessage("Shutter Get", "Reversed invalid ({0})", value);
                        }
                        break;
                    case SEEKSTATE_GET:
                        if (int.TryParse(value, numberStyle, sourceCulture, out rotatorSeekState) == false)
                        {
                            LogMessage("Rotator Get", "Seek Status Invalid ({0})", value);
                        }
                        break;
                    case SLEW_ROTATOR_STATUS:
                        if (int.TryParse(value, numberStyle, sourceCulture, out rotatorSlewDirection) == false)
                        {
                            LogMessage("Rotator Get", "Slewing Invalid ({0})", value);
                        }
                        break;
                    case SPEED_ROTATOR_CMD:
                        if (long.TryParse(value, numberStyle, sourceCulture, out rotatorMaxSpeed) == true)
                        {
                            LogMessage("Rotator Get", "Speed ({0})", rotatorMaxSpeed);
                        }
                        else
                        {
                            LogMessage("Rotator Get", "Speed Invalid ({0})", value);
                        }
                        break;
                    case SPEED_SHUTTER_CMD:
                        if (long.TryParse(value, numberStyle, sourceCulture, out shutterMaxSpeed) == true)
                        {
                            LogMessage("Shutter Get", "Speed ({0})", shutterMaxSpeed);
                        }
                        else
                        {
                            LogMessage("Shutter Get", "Speed Invalid ({0})", value);
                        }
                        break;
                    case STATE_SHUTTER_GET:
                        tl.LogMessage("OnSerialTimer STATE_SHUTTER_GET value :", value);
                        if (int.TryParse(value, numberStyle, sourceCulture, out localInt) == true)
                        {
                            domeShutterState = (ShutterState)localInt;
                            if (localInt < 0 || localInt > 4) {
                                LogMessage("Shutter Get", "State invalid ({0})", localInt);
                                tl.LogMessage("OnSerialTimer STATE_SHUTTER_GET State invalid", value);
                            }
                            
                        }
                        else
                        {
                            LogMessage("ShutterState Get", "Invalid ({0})", value);
                        }
                        break;
                    case STEPSPER_ROTATOR_CMD:
                        if (long.TryParse(value, numberStyle, sourceCulture, out rotatorStepsPer) == true)
                        {
                            LogMessage("Rotator Get", "Steps Per ({0})", rotatorStepsPer);
                        }
                        else
                        {
                            LogMessage("Rotator StepsPer", "Invalid ({0})", value);
                        }
                        break;
                    case STEPSPER_SHUTTER_CMD:
                        if (long.TryParse(value, numberStyle, sourceCulture, out shutterStepsPer) == true)
                        {
                            //LogMessage("Shutter Get", "Steps Per ({0})", shutterStepsPer);
                        }
                        else
                        {
                            LogMessage("Shutter Steps Per", "Invalid ({0})", value);
                        }
                        break;
                    case VERSION_ROTATOR_GET:
                        rotatorVersion = value;
                        LogMessage("Rotator Get", "Version ({0})", value);
                        break;
                    case VERSION_SHUTTER_GET:
                        shutterVersion = value;
                        LogMessage("Shutter Get", "Version ({0})", value);
                        break;
                    case VOLTS_ROTATOR_CMD:
                        if (ParseVoltsMessage(value, out rotatorVoltage, out rotatorCutoff) == false)
                        {
                            LogMessage("Rotator Voltage", "Invalid ({0})", value);
                        }
                        break;
                    case VOLTS_SHUTTER_CMD:
                        if (ParseVoltsMessage(value, out shutterVoltage, out shutterCutoff) == false)
                        {
                            LogMessage("Shutter Voltage", "Invalid ({0})", value);
                        }
                        else
                        {
                            LogMessage("Shutter Voltage", "({0})", value);
                        }
                        break;
                    case LOWCLOSE_SHUTTER_CMD:
                        shutterCloseOnLowVoltage = (value.Equals("1"));
                        LogMessage("Shutter Get", "Close on low voltage ({0})", shutterCloseOnLowVoltage.ToString());
                        break;
                    default:
                        tl.LogMessage("Unknown command", command + ":" + value);
                        break;
                }
            }
        }

        private bool ParseVoltsMessage(String value, out int volts, out int cutoff)
        {
            bool tryRes = false, result = false;
            int commaPosition;
            string voltString = "", cutoffString = "";
            volts = 0; cutoff = 0;

            commaPosition = value.IndexOf(',');
            if (commaPosition > -1)
            {
                result = true;
                voltString = value.Substring(0, commaPosition);
                cutoffString = value.Substring(commaPosition+1);
                tryRes = int.TryParse(voltString, numberStyle, sourceCulture, out volts);
                if (tryRes == false) result = false;
                tryRes = int.TryParse(cutoffString, numberStyle, sourceCulture, out cutoff);
                if (tryRes == false) result = false;
            }
            return result;
        }
        #endregion

        #region "Get initial unpolled values"
        internal void GetSetupInfo()
        {
            LogMessage("Rotator Get", "Setup Info");
			SendSerial(HELLO_CMD);		// send hello to shutter, if it's present it'll reply
            SendSerial(VERSION_ROTATOR_GET);
            SendSerial(VOLTS_ROTATOR_CMD);
            SendSerial(STEPSPER_ROTATOR_CMD);
            SendSerial(POSITION_ROTATOR_CMD);
            SendSerial(SPEED_ROTATOR_CMD);
            SendSerial(ACCELERATION_ROTATOR_CMD);
            SendSerial(REVERSED_ROTATOR_CMD);
            SendSerial(HOMEAZ_ROTATOR_CMD);
            SendSerial(PARKAZ_ROTATOR_CMD);
            SendSerial(HOMED_ROTATOR_STATUS);
            SendSerial(SEEKSTATE_GET);
            SendSerial(RAIN_ROTATOR_CMD);
            SendSerial(RAIN_ROTATOR_TWICE_CMD);
            SendSerial(RAIN_ROTATOR_ACTION);

            if (canSetShutter == true)
            {
                LogMessage("Shutter Get", "Setup Info");
                SendSerial(STATE_SHUTTER_GET);
                SendSerial(VERSION_SHUTTER_GET);
                SendSerial(VOLTS_SHUTTER_CMD);
                SendSerial(POSITION_SHUTTER_GET);
                SendSerial(STEPSPER_SHUTTER_CMD);
                SendSerial(SPEED_SHUTTER_CMD);
                SendSerial(ACCELERATION_SHUTTER_CMD);
                SendSerial(REVERSED_SHUTTER_CMD);
                SendSerial(LOWCLOSE_SHUTTER_CMD);

            }
        }
        #endregion

        #region IDome Implementation

        #region "Cans"
        public bool CanFindHome
        {
            get
            {
                return canFindHome;
            }
        }

        public bool CanPark
        {
            get
            {
                return canPark;
            }
        }

        public bool CanSetAltitude
        {
            get
            {
                return canSetAltitude;
            }
        }

        public bool CanSetAzimuth
        {
            get
            {
                return canSetAzimuth;
            }
        }

        public bool CanSetPark
        {
            get
            {
                return canSetPark;
            }
        }

        public bool CanSetShutter
        {
            get
            {
                return canSetShutter;
            }
        }

        public bool CanSlave
        {
            get
            {
                canSlave = true;
                return canSlave;
            }
        }

        public bool CanSyncAzimuth
        {
            get
            {
                return canSyncAzimuth;
            }
        }
        #endregion

        #region properties
        internal static ShutterState domeShutterState = ShutterState.shutterError; // Variable to hold the open/closed status of the shutter, true = Open
        public ShutterState ShutterStatus
        {
            get
            {
                if (canSetShutter == true)
                {

                    return domeShutterState;
                }
                else
                {
                    throw new PropertyNotImplementedException("ShutterState");
                }
            }
        }

        public double Altitude
        {
            get
            {
                if (CanSetAltitude == true)
                {
                    return altitude;
                }
                else
                {
                    tl.LogMessage("Altitude Get", "Not implemented");
                    throw new ASCOM.PropertyNotImplementedException("Altitude", false);
                }
            }
        }

        public bool AtHome
        {
            get
            {
                if (CanFindHome == true)
                {
                    if ( (HomeStatus)rotatorHomedStatus == HomeStatus.ATHOME )
                    {
	                      atHome = true;
	                }
	                else
	                {
	                      atHome = false;
	                }
                }
                else
                {
                    atHome = false;
                    tl.LogMessage("AtHome Get", "Not implemented");
                    throw new ASCOM.PropertyNotImplementedException("AtHome", false);
                }
            return atHome;
            }
        }

        public bool AtPark
        {
            get
            {
                if (canPark == true)
                {
                    LogMessage("Rotator Get", "Slewing ({0})", rotatorSlewDirection);
                    if (rotatorSlewDirection == 0)
                    {
                        double parkDiff = azimuth - rotatorParkAz;
                        if (Math.Abs(parkDiff) < 0.1)
                        {
                            atPark = true;
                        }
                        else
                        {
                            atPark = false;
                        }
                    }

                    return atPark;
                }
                else
                {
                    tl.LogMessage("AtPark Get", "Not implemented");
                    throw new ASCOM.PropertyNotImplementedException("AtPark", false);
                }
            }
        }

        public double Azimuth
        {
            get
            {
                if (CanSetAzimuth == true)
                {
                    return azimuth;
                }
                else
                {
                    tl.LogMessage("Azimuth Get", "Not implemented");
                    throw new ASCOM.PropertyNotImplementedException("Azimuth", false);
                }
            }
        }

        public bool Slaved
        {
            get
            {
                if (canSlave == true)
                {

                    return isSlaved;
                }
                else
                {
                    throw new ASCOM.PropertyNotImplementedException("Slaved", true);
                }
            }
            set
            {
                if (canSlave == true)
                {
                    isSlaved = value;
                    tl.LogMessage("Slaved Set", value.ToString());
                }
                else
                {
                    throw new ASCOM.PropertyNotImplementedException("Slaved", true);
                }
            }
        }

        public bool Slewing
        {
            get
            {
                if (CanSetAzimuth == true)
                {
                    return rotatorSlewDirection != 0;
                }
                else
                {
                    throw new ASCOM.PropertyNotImplementedException("Slewing", true);
                }
            }
        }
        #endregion

        #region "Methods"
        public void AbortSlew()
        {
            SendSerial(ABORT_MOVE_CMD);
            tl.LogMessage("Movement","Aborted");
        }

        public void CloseShutter()
        {
            if (canSetShutter ==true)
            {
                SendSerial(CLOSE_SHUTTER_CMD);
                tl.LogMessage("Close Shutter", "Started");
            }
            else
            {
                tl.LogMessage("Close Shutter", "Method not implemented");
                throw new MethodNotImplementedException("Close Shutter");
            }
        }

        public void FindHome()
        {
            if (canFindHome == true)
            {
                SendSerial(HOME_ROTATOR_CMD);
                tl.LogMessage("Rotator", "Find Home");
            }
            else
            {
                tl.LogMessage("FindHome", "Not implemented");
                throw new ASCOM.MethodNotImplementedException("FindHome");
            }
        }

        public void OpenShutter()
        {
            if (canSetShutter == true)
            {
                if (isRaining == true)
                {
                    throw new ASCOM.InvalidOperationException("Rain prevents opening");
                }
                else if (shutterVoltage < shutterCutoff)
                {
                    throw new ASCOM.InvalidOperationException("Low voltage prevents opening");
                }
                else
                {
                    SendSerial(OPEN_SHUTTER_CMD);
                    tl.LogMessage("Open Shutter", "Started");
                }
            }
            else
            {
                tl.LogMessage("OpenShutter", "Method not implemented");
                throw new MethodNotImplementedException("Open Shutter");
            }
        }

        public void Park()
        {
            if (canPark == true)
            {
                SendSerial(GOTO_ROTATOR_CMD + rotatorParkAz.ToString(sourceCulture));
                tl.LogMessage("Rotator", "Go to Park");
            }
            else
            {
                tl.LogMessage("Park", "Not implemented");
                throw new ASCOM.MethodNotImplementedException("Park");
            }
        }

        public void SetPark()
        {
            if (canSetPark == true)
            {
                SendSerial(PARKAZ_ROTATOR_CMD + azimuth.ToString(sourceCulture));
                LogMessage("Rotator SET", "Park at ({0})", azimuth);
            }
            else
            {
                tl.LogMessage("SetPark", "Not implemented");
                throw new ASCOM.MethodNotImplementedException("SetPark");
            }
        }

        public void SlewToAltitude(double Altitude)
        {
            tl.LogMessage("SlewToAltitude", "Not implemented");
            throw new ASCOM.MethodNotImplementedException("SlewToAltitude");
        }

        public void SlewToAzimuth(double Azimuth)
        {
            if (CanSetAzimuth == true)
            {
                if (rotatorVoltage > rotatorCutoff)
                {
                    SendSerial(GOTO_ROTATOR_CMD + Azimuth.ToString(sourceCulture));
                    LogMessage("Rotator", "Slew from ({0:0.00}) to ({1:0.00})",azimuth, Azimuth);
                }
                else
                {
                    tl.LogMessage("Rotator", "Slew aborted: low voltage");
                    throw new ASCOM.InvalidOperationException("Rotator voltage too low");
                }
            }
            else
            {
                tl.LogMessage("SlewToAzimuth", "Not implemented");
                throw new ASCOM.MethodNotImplementedException("SlewToAzimuth");
            }
        }

        public void SyncToAzimuth(double Azimuth)
        {
            if (CanSyncAzimuth == true)
            {
                SendSerial(SYNC_ROTATOR_CMD + Azimuth.ToString(sourceCulture));
                LogMessage("Rotator","Sync to ({0})", Azimuth);
            }
            else
            {
                tl.LogMessage("SyncToAzimuth", "Not implemented");
                throw new ASCOM.MethodNotImplementedException("SyncToAzimuth");
            }
        }
        #endregion
        #endregion

        #region Private properties and methods
        // here are some useful properties and methods that can be used as required
        // to help with driver development

        #region ASCOM Registration

        // Register or unregister driver for ASCOM. This is harmless if already
        // registered or unregistered.
        //
        /// <summary>
        /// Register or unregister the driver with the ASCOM Platform.
        /// This is harmless if the driver is already registered/unregistered.
        /// </summary>
        /// <param name="bRegister">If <c>true</c>, registers the driver, otherwise unregisters it.</param>
        private static void RegUnregASCOM(bool bRegister)
        {
            using (var P = new ASCOM.Utilities.Profile())
            {
                P.DeviceType = "Dome";
                if (bRegister)
                {
                    P.Register(driverID, driverDescription);
                }
                else
                {
                    P.Unregister(driverID);
                }
            }
        }

        /// <summary>
        /// This function registers the driver with the ASCOM Chooser and
        /// is called automatically whenever this class is registered for COM Interop.
        /// </summary>
        /// <param name="t">Type of the class being registered, not used.</param>
        /// <remarks>
        /// This method typically runs in two distinct situations:
        /// <list type="numbered">
        /// <item>
        /// In Visual Studio, when the project is successfully built.
        /// For this to work correctly, the option <c>Register for COM Interop</c>
        /// must be enabled in the project settings.
        /// </item>
        /// <item>During setup, when the installer registers the assembly for COM Interop.</item>
        /// </list>
        /// This technique should mean that it is never necessary to manually register a driver with ASCOM.
        /// </remarks>
        [ComRegisterFunction]
        public static void RegisterASCOM(Type t)
        {
            RegUnregASCOM(true);
        }

        /// <summary>
        /// This function unregisters the driver from the ASCOM Chooser and
        /// is called automatically whenever this class is unregistered from COM Interop.
        /// </summary>
        /// <param name="t">Type of the class being registered, not used.</param>
        /// <remarks>
        /// This method typically runs in two distinct situations:
        /// <list type="numbered">
        /// <item>
        /// In Visual Studio, when the project is cleaned or prior to rebuilding.
        /// For this to work correctly, the option <c>Register for COM Interop</c>
        /// must be enabled in the project settings.
        /// </item>
        /// <item>During uninstall, when the installer unregisters the assembly from COM Interop.</item>
        /// </list>
        /// This technique should mean that it is never necessary to manually unregister a driver from ASCOM.
        /// </remarks>
        [ComUnregisterFunction]
        public static void UnregisterASCOM(Type t)
        {
            RegUnregASCOM(false);
        }

        #endregion

        /// <summary>
        /// Returns true if there is a valid connection to the driver hardware
        /// </summary>
        private bool IsConnected
        {
            get
            {
                // TODO check that the driver hardware connection exists and is connected to the hardware
                return connectedState;
            }
        }

        /// <summary>
        /// Use this function to throw an exception if we aren't connected to the hardware
        /// </summary>
        /// <param name="message"></param>
        private void CheckConnected(string message)
        {
            if (!IsConnected)
            {
                throw new ASCOM.NotConnectedException(message);
            }
        }

        /// <summary>
        /// Read the device configuration from the ASCOM Profile store
        /// </summary>
        internal void ReadProfile()
        {
            using (Profile driverProfile = new Profile())
            {
                driverProfile.DeviceType = "Dome";
                tl.Enabled = Convert.ToBoolean(driverProfile.GetValue(driverID, traceStateProfileName, string.Empty, traceStateDefault));
                comPort = driverProfile.GetValue(driverID, comPortProfileName, string.Empty, comPortDefault);
                canFindHome = Convert.ToBoolean(driverProfile.GetValue(driverID, "canFindHome", "Cans", "true"));
                canPark = Convert.ToBoolean(driverProfile.GetValue(driverID, "canPark", "Cans", "true"));
                canSetAltitude = Convert.ToBoolean(driverProfile.GetValue(driverID, "canSetAltitude", "Cans", "false"));
                canSetAzimuth = Convert.ToBoolean(driverProfile.GetValue(driverID, "canSetAzimuth", "Cans", "true"));
                canSetPark = Convert.ToBoolean(driverProfile.GetValue(driverID, "canSetPark", "Cans", "true"));
                canSetShutter = Convert.ToBoolean(driverProfile.GetValue(driverID, "canSetShutter", "Cans", "false"));
                canSyncAzimuth = Convert.ToBoolean(driverProfile.GetValue(driverID, "canSyncAzimuth", "Cans", "true"));
            }
        }

        /// <summary>
        /// Write the device configuration to the  ASCOM  Profile store
        /// </summary>
        internal void WriteProfile()
        {
            using (Profile driverProfile = new Profile())
            {
                driverProfile.DeviceType = "Dome";
                driverProfile.WriteValue(driverID, traceStateProfileName, tl.Enabled.ToString());
                driverProfile.WriteValue(driverID, comPortProfileName, comPort.ToString());
                driverProfile.WriteValue(driverID, "canFindHome", canFindHome.ToString(),"Cans");
                driverProfile.WriteValue(driverID, "canPark", canPark.ToString(), "Cans");
                driverProfile.WriteValue(driverID, "canSetAltitude", canSetAltitude.ToString(), "Cans");
                driverProfile.WriteValue(driverID, "canSetAzimuth", canSetAzimuth.ToString(), "Cans");
                driverProfile.WriteValue(driverID, "canSetPark", canSetPark.ToString(), "Cans");
                driverProfile.WriteValue(driverID, "canSetShutter", canSetShutter.ToString(), "Cans");
                driverProfile.WriteValue(driverID, "canSyncAzimuth", canSyncAzimuth.ToString(), "Cans");
            }
        }

        /// <summary>
        /// Log helper function that takes formatted strings and arguments
        /// </summary>
        /// <param name="identifier"></param>
        /// <param name="message"></param>
        /// <param name="args"></param>
        internal static void LogMessage(string identifier, string message, params object[] args)
        {
            var msg = string.Format(message, args);
            tl.LogMessage(identifier, msg);
        }
        #endregion
    }
}
