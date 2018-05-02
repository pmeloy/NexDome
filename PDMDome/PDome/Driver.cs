//tabs=4
// --------------------------------------------------------------------------------
//
// PDM ASCOM NexDome driver
//
// Description: Driver for the NexDome observatory rotation and shutter
//				kits. 
//
// Implements:	ASCOM Dome interface version: 2
// Author:		Pat Meloy <pmeloy@shaw.ca>
//
// Edit Log:
//
// Date			Who	Vers	Description
// -----------	---	-----	-------------------------------------------------------
// 08-Apr-2018	PDM	6.2.0	Initial edit, created from ASCOM driver template
// --------------------------------------------------------------------------------
//


// This is used to define code in the template that is specific to one class implementation
// unused code canbe deleted and this definition removed.
#define Dome

using System;
using System.Timers;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using ASCOM;
using ASCOM.Astrometry;
using ASCOM.Astrometry.AstroUtils;
using ASCOM.Utilities;
using ASCOM.DeviceInterface;
using System.Globalization;
using System.Collections;
using System.Windows.Forms;


namespace ASCOM.PDome
{
    //
    // Your driver's DeviceID is ASCOM.PDome.Dome
    //
    // The Guid attribute sets the CLSID for ASCOM.PDome.Dome
    // The ClassInterface/None addribute prevents an empty interface called
    // _PDome from being created and used as the [default] interface
    //
    // TODO Replace the not implemented exceptions with code to implement the function or
    // throw the appropriate ASCOM exception.
    //

    /// <summary>
    /// PDome
    /// </summary>
    [Guid("12c17cd4-c9b5-4621-a51b-814e48595e26")]
    [ClassInterface(ClassInterfaceType.None)]
    public class Dome : IDomeV2
    {
        #region "ASCOM Stuff"
        /// <summary>
        /// ASCOM DeviceID (COM ProgID) for this driver.
        /// The DeviceID is used by ASCOM applications to load the driver at runtime.
        /// </summary>
        internal static string driverID = "ASCOM.PDome.Dome";
        private static string driverDescription = "PDM NexDome";

        internal static string comPortProfileName = "COM Port"; // Constants used for Profile persistence
        internal static string comPortDefault = "COM3";
        internal static string traceStateProfileName = "Trace Level";
        internal static string traceStateDefault = "true";
        internal static string canFindHomeProfileName = "CanFindHome";
        internal static string canParkProfileName = "CanPark";
        internal static string canSetAltitudeProfileName = "CanSetAltitude";
        internal static string canSetAzimuthProfileName = "CanSetAzimuth";
        internal static string canSetParkProfileName = "CanSetPark";
        internal static string canSetShutterProfileName = "CanSetShutter";
        internal static string canSlaveProfileName = "CanSlave";
        internal static string canSyncAzimuthProfileName = "CanSync";
        internal static string rainIntervalProfileName = "RainInterval";

        internal static string comPort; // Variables to hold the current device configuration

        ASCOM.Utilities.Serial serialPort;

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

        #region "Setup"
        /// <summary>
        /// Initializes a new instance of the <see cref="PDome"/> class.
        /// Must be public for COM registration.
        /// </summary>
        public Dome()
        {
            #region "ASCOM setup"
            tl = new TraceLogger("", "PDome");
            tl.LogMessage("Dome", "Starting initialisation");
            connectedState = false; // Initialise connected to false
            utilities = new Util(); //Initialise util object
            astroUtilities = new AstroUtils(); // Initialise astro utilities object
            ReadProfile();
            tl.LogMessage("Dome", "Completed initialisation");
            #endregion

        }
        #endregion

        #region "My variables"

        internal static bool canFindHome, canPark, canSetPark, canSetAltitude, canSetAzimuth, canSetShutter, canSlave, canSyncAzimuth;
        internal enum SeekStates
        {
            HOMING_NONE, // Not homing or calibrating
            HOMING_HOME, // Homing
            CALIBRATION_MOVEOFF, // Ignore home until we've moved off while measuring the dome.
            CALIBRATION_MEASURE // Measu
        }
        internal static double azimuth, altitude;
        internal bool isHome, isRaining;
        internal static int rainCheckInterval;
        internal long nextRainCheck;
        internal static int rotatorHomedStatus;
        internal static SeekStates rotatorSeekState;
        internal int domeDirection;

        // Rotator local values
        internal static string rotatorVersion="";
        internal static double rotatorVolts, rotatorCutoffVolts; 
        internal static double rotatorHomePosition, rotatorParkPosition;
        internal static long rotatorStepsPer, rotatorAcceleration, rotatorSpeed, rotatorStepPosition;
        internal static bool rotatorReversed;

        // Shutter local values
        internal static string shutterVersion = "";
        internal static double shutterVolts, shutterCutoffVolts, shutterElevation, shutterMax, shutterMin;
        internal static long shutterStepsPer, shutterAcceleration, shutterSpeed, shutterPosition;
        internal static int shutterSleepPeriod, shutterSleepDelay;
        internal static bool shutterReversed, shutterSleepEnabled;
        internal static ShutterState shutterState;

        #region Serial command character constants
        internal const string ACCEL_ROT_CMD = "e"; // Get/Set stepper acceleration
        internal const string ABORT_MOVE_CMD = "a"; // Tell everything to STOP!
        internal const string CAL_ROT_CMD = "c"; // Calibrate the dome
        internal const string ERROR_ROT_AZ = "o"; // Azimuth error when I finally implement it
        internal const string GOTO_ROT_CMD = "g"; // Get/set dome azimuth
        internal const string HELLO_CMD = "H";
        internal const string HOME_ROT_CMD = "h"; // Home the dome
        internal const string HOMEAZ_ROT_CMD = "i"; // Get/Set home position
        internal const string HOMED_ROT_STATUS = "z"; // Get homed status
        internal const string MOVEREL_ROT_CMD = "b"; // Move relative - steps from current position +/-
        internal const string PARKAZ_ROT_CMD = "l"; // Get/Set park azimuth
        internal const string POS_ROT_CMD = "p"; // Get/Set step position
        internal const string RAIN_ROT_CMD = "f"; // Get rain sensor state
        internal const string SPEED_ROT_CMD = "r"; // Get/Set step rate (speed)
        internal const string REV_ROT_CMD = "y"; // Get/Set stepper reversed status 
        internal const string SEEKSTATE_GET = "d"; // Get seek mode (homing, calibrating etc)
        internal const string SLEW_ROT_STATUS = "m"; // Get Slewing status/direction
        internal const string STEPS_ROT_CMD = "t"; // GetSteps per rotation
        internal const string SYNC_ROT_CMD = "s"; // Sync to telescope
        internal const string VERS_ROT_GET = "v"; // Get Version string
        internal const string VOLTS_ROT_CMD = "k"; // Get volts and get/set cutoff

        internal const string ACCEL_SHUT_CMD = "E"; // Get/Set stepper acceleration
        internal const string CAL_SHUT_CMD = "L"; // Calibrate the shutter
        internal const string CLOSE_SHUTTER_CMD = "C"; // Close shutter
        internal const string ELEVATION_SHUTTER_CMD = "G"; // Get/Set altitude
        internal const string HOMED_SHUT_GET = "Z"; // Get homed status (has it been closed)
        internal const string OPEN_SHUTTER_CMD = "O"; // Open the shutter
        internal const string POS_SHUT_GET = "P"; // Get step position
        internal const string SPEED_SHUT_CMD = "R"; // Get/Set step rate (speed)
        internal const string REV_SHUT_CMD = "Y"; // Get/Set stepper reversed status
        internal const string SLEEP_SHUT_CMD = "S"; // Get/Set radio sleep settings
        internal const string STATE_SHUT_GET = "M"; // Get shutter state
        internal const string STEPS_SHUT_CMD = "T"; // Get/Set steps per stroke
        internal const string VERS_SHUT_GET = "V"; // Get version string
        internal const string VOLTS_SHUT_CMD = "K"; // Get volts and get/set cutoff
        #endregion
        #endregion

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
        public void SetupDialog()
        {
            if (IsConnected)
            {
                GetUnpolledRotatorValues();
                GetUnPolledShutterValues();

                using (SetupForm F = new SetupForm())
                {
                    F.myDome = this;
                    DialogResult result = DialogResult.Cancel;
                    try
                    {
                        result = F.ShowDialog();
                    }
                    catch(Exception ex)
                    {
                        tl.LogMessage("Show Setup", "Exception:" + ex.GetType().FullName.ToString());
                    }
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        tl.LogMessage("Setup complete", "Write Profile");
                        WriteProfile(); // Persist device configuration values to the ASCOM Profile store
                    }
                }
            }
            else
            {
                using (ComportDialogForm F = new ComportDialogForm())
                {
                    var result = F.ShowDialog();
                    if (result == System.Windows.Forms.DialogResult.OK)
                    {
                        WriteProfile(); // Persist device configuration values to the ASCOM Profile store
                    }
                }
            }
        }
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
        public void CommandBlind(string command, bool raw = true)
        {
            CheckConnected("CommandBlind");
            // Call CommandString and return as soon as it finishes
            this.CommandString(command, raw);
        }
        public bool CommandBool(string command, bool raw = true)
        {
            CheckConnected("CommandBool");
            string ret = CommandString(command, raw);
            // TODO decode the return string and return true or false
            // or
            throw new ASCOM.MethodNotImplementedException("CommandBool");
            // DO NOT have both these sections!  One or the other
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
        public bool Connected
        {
            get
            {
                LogMessage("Connected GET", IsConnected.ToString());
                return IsConnected;
            }
            set
            {
                tl.LogMessage("Connected Set", "{0}", value);
                if (value == IsConnected)
                    return;

                if (value)
                {
                    connectedState = true;
                    LogMessage("Connected Set", "Connecting to port {0}", comPort);
                    // TODO connect to the device
                    serialPort = new ASCOM.Utilities.Serial();
                    serialPort.PortName = comPort;
                    serialPort.Speed = SerialSpeed.ps9600;
                    serialPort.DataBits = 8;
                    serialPort.Parity =  SerialParity.None;
                    serialPort.StopBits = SerialStopBits.One;
                    serialPort.DTREnable = true;
                    serialPort.Handshake = SerialHandshake.None;

                    serialPort.ReceiveTimeoutMs = 500;

                    try
                    {
                        // now open the com port
                        serialPort.Connected = true;
                        connectedState = true;
                        // clear any garbage from the buffers that may be there
                        serialPort.ClearBuffers();
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
                    LogMessage("Connected Set", "Disconnecting from port {0}", comPort);
                    // TODO disconnect from the device
                    serialPort.Connected = false;
                    serialPort.Dispose();
                }
            }
        }
        public string Description
        {
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
                Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                // TODO customise this driver description
                string driverInfo = "PDM NexDome Version: " + String.Format(CultureInfo.InvariantCulture, "{0}.{1}", version.Major, version.Minor);
                tl.LogMessage("DriverInfo Get", driverInfo);
                return driverInfo;
            }
        }
        public string DriverVersion
        {
            get
            {
                Version version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
                string driverVersion = String.Format(CultureInfo.InvariantCulture, "{0}.{1}", version.Major, version.Minor);
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
                string name = "PDM NexDome";
                tl.LogMessage("Name Get", name);
                return name;
            }
        }
        #endregion

        public string CommandString(string command, bool raw = true)
        {
            string value = "";
            // it's a good idea to put all the low level communication with the device here,
            // then all communication calls this function
            // you need something to ensure that only one command is in progress at a time

            if (raw == true) command = command + "#";
            CheckConnected("CommandString");
            serialPort.ClearBuffers();
            serialPort.Transmit(command);
            try
            {
                value = serialPort.ReceiveTerminated("#");
                // Strip command string and terminator
                value = value.Substring(1, value.Length - 2);
            }
            catch (Exception)
            {
                return "";
            }
            return value;
        }

        #region "My Dome Functions"
        void GetUnpolledRotatorValues()
        {
            string value;
            bool res;

            rotatorVersion = CommandString(VERS_ROT_GET);

            value = CommandString(PARKAZ_ROT_CMD);
            res = double.TryParse(value, out rotatorParkPosition);
            if (res == false) LogMessage("Rotator values", "Invalid park position ({0})", value);

            value = CommandString(HOMEAZ_ROT_CMD);
            res = double.TryParse(value, out rotatorHomePosition);
            if (res == false) LogMessage("Rotator Value", "Invalid home position ({0})", value);

            value = CommandString(VOLTS_ROT_CMD);
            ParseVoltStrings(value, out rotatorVolts, out rotatorCutoffVolts);
            if (res == false) LogMessage("Rotator Values", "Rotator Volts invalid ({0})", value);

            value = CommandString(STEPS_ROT_CMD);
            res = long.TryParse(value, out rotatorStepsPer);
            if (res == false) LogMessage("Rotator Values", "Steps Per Rotation invalid ({0})", value);

            value = CommandString(ACCEL_ROT_CMD);
            res = long.TryParse(value, out rotatorAcceleration);
            if (res == false) LogMessage("Rotator Values", "Acceleration invalid ({0})", value);

            value = CommandString(SPEED_ROT_CMD);
            res = long.TryParse(value, out rotatorSpeed);
            if (res == false) LogMessage("Rotator Values", "Step Rate invalid ({0})", value);

            value = CommandString(REV_ROT_CMD);
            if (!value.Equals("0") && !value.Equals("1"))
            {
                LogMessage("Rotator Settings", "Reversed invalid ({0})", value);
            }
            else
            {
                rotatorReversed = (!value.Equals("0"));
            }
        }
        void GetUnPolledShutterValues()
        {
            string value;
            bool res;

            shutterVersion = CommandString(VERS_SHUT_GET);
            LogMessage("Shutter Settings", "Version ({0})", shutterVersion);
            value = CommandString(REV_SHUT_CMD);

            value = CommandString(VOLTS_SHUT_CMD);
            ParseVoltStrings(value, out shutterVolts, out shutterCutoffVolts);
            LogMessage("Shutter Settings", "Shutter Volts ({0:0.00}) Cutoff ({1:0.00})", shutterVolts, shutterCutoffVolts);

            value = CommandString(STEPS_SHUT_CMD);
            res = long.TryParse(value, out shutterStepsPer);
            if (res == false) LogMessage("Shutter Settings", "Steps Per Stroke invalid ({0})", value);

            value = CommandString(ACCEL_SHUT_CMD);
            res = long.TryParse(value, out shutterAcceleration);
            if (res == false) LogMessage("Shutter Settings", "Acceleration invalid ({0})", value);

            value = CommandString(SPEED_SHUT_CMD);
            res = long.TryParse(value, out shutterSpeed);
            if (res == false) LogMessage("Shutter Settings", "Speed invalid ({0})", value);

            value = CommandString(REV_SHUT_CMD);
            if (!value.Equals("0") && !value.Equals("1"))
            {
                LogMessage("Shutter Settings", "Reversed invalid ({0})", value);
            }
            else
            {
                shutterReversed = (!value.Equals("0"));
            }

            value = CommandString(SLEEP_SHUT_CMD);
            if (value.Equals("") == true)
            {
                LogMessage("Unpolled Shutter GET", "Sleep invalid ({0})", value);
                value = "0,0,0";
            }
            ParseSleepStrings(value, out shutterSleepPeriod, out shutterSleepDelay);

        }
        public string BoolToNumberString(bool val)
        {
            return (val == true) ? "1" : "0";
        }
        void ParseVoltStrings(string value, out double volts, out double cutoff)
        {
            int v=0, c=0;
            if (value.IndexOf(',') > 0)
            {
                string[] values = value.Split(',');
                if (values.Length > 1)
                {
                    int.TryParse(values[0], out v);
                    int.TryParse(values[1], out c);
                }
            }
            else
            {
                LogMessage("Get Unpolled Shutter Values", "Volts string invalid " + value);
            }
            volts = v / 100.0;
            cutoff = c / 100.0;

        }
        #endregion

        void ParseSleepStrings(string value, out int period, out int delay)
        {
            string[] values = value.Split(',');

            if (!values[0].Equals(""))
            {
                shutterSleepEnabled = (!values[0].Equals("0"));
            }
            else
            {
                LogMessage("Shutter Settings","Sleep Enabled invalid ({0})",values[0]);
            }
            if (int.TryParse(values[1], out period) == false)
            {
                LogMessage("Shutter Settings", "Sleep Period Invalid ({0})", values[0]);
            }

            if (int.TryParse(values[2], out delay)==false)
            {
                LogMessage("Shutter Settings", "Sleep Delay Invalid ({0})", values[0]);
            }
        }
        #region "Cans"
        public bool CanFindHome
        {
            get
            {
                return canFindHome;
            }
            set
            {
                canFindHome = value;
            }
        }
        public bool CanPark
        {
            get
            {
                return canPark;
            }
            set
            {
                canPark = value;
            }
        }
        public bool CanSetAltitude
        {
            get
            {
                return canSetAltitude;
            }
            set
            {

            }
        }
        public bool CanSetAzimuth
        {
            get
            {
                return canSetAzimuth;
            }
            set
            {
                CanSetAzimuth = value;
            }
        }
        public bool CanSetPark
        {
            get
            {
                return canSetPark;
            }
            set
            {
                canSetPark = value;
            }
        }
        public bool CanSetShutter
        {
            get
            {
                return canSetShutter;
            }
            set
            {
                canSetShutter = value;
            }
        }
        public bool CanSlave
        {
            get
            {
                return canSlave;
            }
            set
            {
                CanSlave = value;
            }
        }
        public bool CanSyncAzimuth
        {
            get
            {
                return canSyncAzimuth;
            }
            set
            {
                CanSyncAzimuth = value;
            }
        }
        #endregion

        #region IDome Implementation

        public void AbortSlew()
        {
            // This is a mandatory parameter but we have no action to take in this simple driver
            CommandBlind("a");
        }
        public double Altitude
        {
            get
            {

                throw new ASCOM.PropertyNotImplementedException("Altitude");
            }
        }
        public bool AtHome
        {
            get
            {
                if (Slewing == false)
                {
                    return isHome;
                }
                return false;
            }
        }
        public bool AtPark
        {
            get
            {
                if (CanSetPark == true)
                {
                    if (Math.Abs(azimuth - rotatorParkPosition) < 0.2)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
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

                    bool res, slew = Slewing;
                    int status, seek;
                    Double az;
                    string value;

                    value = CommandString(HOMED_ROT_STATUS);
                    res = int.TryParse(value, out status);
                    if (res == false || status < -1 || status > 1)
                    {
                        LogMessage("Azimuth GET", "Homed status invalid {1}", status);
                    }
                    else
                    {
                        rotatorHomedStatus = status;
                        isHome = (rotatorHomedStatus == 1);
                    }

                    value = CommandString(SEEKSTATE_GET);
                    res = int.TryParse(value, out seek);
                    if (res == false)
                    {
                        LogMessage("Azimuth GET", "SEEK Mode invalid ({0})", value);
                    }
                    else
                    {
                        rotatorSeekState = (SeekStates)seek;
                    }

                    value = CommandString(GOTO_ROT_CMD);
                    res = Double.TryParse(value, out az);
                    if (res == false)
                    {
                        LogMessage("Azimuth GET", "Invalid value: ({0})", value);
                        return 0; // don't change the az value
                    }

                    value = CommandString(POS_ROT_CMD);
                    if (long.TryParse(value, out rotatorStepPosition) == false)
                    {
                        LogMessage("Azimuth GET", "Step position invalid ({0})", value);
                    }

                    if (nextRainCheck <= 0 && rainCheckInterval > 0)
                    {
                        value = CommandString(RAIN_ROT_CMD);
                        isRaining = value.Equals("1");
                        nextRainCheck = rainCheckInterval;
                    }
                    nextRainCheck--;


                    azimuth = az;
                    return az;
                }
                else
                {
                    throw new ASCOM.MethodNotImplementedException("Azimuth");
                }
            }
        }
        public void CloseShutter()
        {
            if (CanSetShutter == true)
            {
                if (shutterState != ShutterState.shutterClosed && shutterState != ShutterState.shutterClosing)
                {
                    CommandString(CLOSE_SHUTTER_CMD);
                    LogMessage("Shutter Move", "Close");
                }
            }
            else
            {
                throw new ASCOM.MethodNotImplementedException("CloseShutter");
            }
        }
        public void FindHome()
        {
            if (CanFindHome)
            {
                CommandBlind("h",true);
            }
            else
            {
                throw new ASCOM.MethodNotImplementedException("FindHome");
            }

        }
        public void OpenShutter()
        {
            if (CanSetShutter == true)
            {
                if (shutterState != ShutterState.shutterOpen && shutterState != ShutterState.shutterOpening)
                {
                    CommandString(OPEN_SHUTTER_CMD);
                    tl.LogMessage("Shutter Move", "Open");
                    shutterState = ShutterState.shutterOpening;
                }
                else
                {
                    LogMessage("Shutter OPEN", "Already Open or Opening");
                }
            }
            else
            {
                throw new ASCOM.MethodNotImplementedException("Open Shutter");
            }
        }
        public void Park()
        {
            if (CanSetPark == true)
            {
                SlewToAzimuth(rotatorParkPosition);
            }
            else
            {
                tl.LogMessage("Park", "Not implemented");
                throw new ASCOM.MethodNotImplementedException("Park");
            }
        }
        public void SetPark()
        {
            if (CanSetPark == true)
            {
                if (Slewing == false)
                {
                    CommandString(PARKAZ_ROT_CMD + Azimuth.ToString());
                }
                return;
            }
            tl.LogMessage("SetPark", "Not implemented");
            throw new ASCOM.MethodNotImplementedException("SetPark");
        }
        public ShutterState ShutterStatus
        {
            get
            {
                if (shutterVersion.Equals("")==false)
                {
                    string value;
                    byte val;
                    ShutterState state;

                    value = CommandString(STATE_SHUT_GET);
                    bool res = byte.TryParse(value, out val);
                    if (res == false)
                    {
                        LogMessage("Shutterstate", "Invalid {0}", value);
                        return ShutterState.shutterError;
                    }
                    state = (ShutterState)val;
                    shutterState = state;

                    value = CommandString(POS_SHUT_GET);
                    if (long.TryParse(value, out shutterPosition) == false) LogMessage("Shutterstate GET", "Position invalid ({0})", value);

                    value = CommandString(ELEVATION_SHUTTER_CMD);
                    if (double.TryParse(value, out shutterElevation) == false) LogMessage("Shutterstate GET", "Elevation invalid ({0})", value);

                    return state;
                }
                else
                {
                    throw new ASCOM.PropertyNotImplementedException("ShutterStatus");
                }
            }
        }
        public bool Slaved
        {
            get
            {
                tl.LogMessage("Slaved Get", false.ToString());
                return false;
            }
            set
            {
                tl.LogMessage("Slaved Set", true.ToString());
                Slaved = true;
            }
        }
        public void SlewToAltitude(double Altitude)
        {
            if (CanSetAltitude)
            {
                CommandBlind("f" + Altitude.ToString());
                tl.LogMessage("SlewToAltitude", Altitude.ToString());
            }
            else
            {
                throw new ASCOM.PropertyNotImplementedException("SlewToAltitude");
            }
        }
        public void SlewToAzimuth(double Azimuth)
        {
            string command = GOTO_ROT_CMD + Azimuth.ToString();
            tl.LogMessage("SlewToAzimuth", Azimuth.ToString("F"));
            string value = CommandString(command);
        }
        public bool Slewing
        {
            get
            {
                int direction;
                string value = CommandString(SLEW_ROT_STATUS);
                bool res = int.TryParse(value, out direction);
                if (res == false)
                {
                    LogMessage("Slewing Direction", "Invalid " + value);
                    return false;
                }
                domeDirection = direction;
                return !(direction == 0);
            }
        }
        public void SyncToAzimuth(double Azimuth)
        {
            if (CanSyncAzimuth)
            {
                CommandBlind("s");
            }
            else
            {
                tl.LogMessage("SyncToAzimuth", "Not implemented");
                throw new ASCOM.MethodNotImplementedException("SyncToAzimuth");
            }
        }
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
                // Cans
                canFindHome = Convert.ToBoolean(driverProfile.GetValue(driverID, canFindHomeProfileName, "cans", "true"));
                canPark = Convert.ToBoolean(driverProfile.GetValue(driverID, canParkProfileName, "cans", "true"));
                canSetAltitude = Convert.ToBoolean(driverProfile.GetValue(driverID, canSetAltitudeProfileName, "cans", "false"));
                canSetAzimuth = Convert.ToBoolean(driverProfile.GetValue(driverID, canSetAzimuthProfileName, "cans", "true"));
                canSetPark = Convert.ToBoolean(driverProfile.GetValue(driverID, canSetParkProfileName, "cans", "true"));
                canSetShutter = Convert.ToBoolean(driverProfile.GetValue(driverID, canSetShutterProfileName, "cans", "false"));
                canSlave = Convert.ToBoolean(driverProfile.GetValue(driverID, canSlaveProfileName, "cans", "true"));
                canSyncAzimuth = Convert.ToBoolean(driverProfile.GetValue(driverID, canSyncAzimuthProfileName, "cans", "true"));
                rainCheckInterval = Convert.ToInt32(driverProfile.GetValue(driverID, rainIntervalProfileName, "settings", "30"));
                tl.LogMessage("WriteProfile", "Completed");
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
                driverProfile.WriteValue(driverID, traceStateProfileName, tl.Enabled.ToString(),string.Empty);
                driverProfile.WriteValue(driverID, comPortProfileName, comPort.ToString(),string.Empty);
                driverProfile.WriteValue(driverID, canFindHomeProfileName, canFindHome.ToString(), "cans");
                driverProfile.WriteValue(driverID, canParkProfileName, canPark.ToString(), "cans");
                driverProfile.WriteValue(driverID, canSetAltitudeProfileName, canSetAltitude.ToString(), "cans");
                driverProfile.WriteValue(driverID, canSetAzimuthProfileName, canSetAzimuth.ToString(), "cans");
                driverProfile.WriteValue(driverID, canSetParkProfileName, canSetPark.ToString(), "cans");
                driverProfile.WriteValue(driverID, canSetShutterProfileName, canSetShutter.ToString(), "cans");
                driverProfile.WriteValue(driverID, canSlaveProfileName, canSlave.ToString(), "cans");
                driverProfile.WriteValue(driverID, canSyncAzimuthProfileName, canSyncAzimuth.ToString(), "cans");
                driverProfile.WriteValue(driverID, rainIntervalProfileName, rainCheckInterval.ToString(), "settings");
                tl.LogMessage("WriteProfile", "Completed");
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
