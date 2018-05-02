/*
 * Copyright © 2018 Patrick Meloy
 * Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation
 *  files (the “Software”), to deal in the Software without restriction, including without limitation the rights to use, copy,
 *  modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software
 *  is furnished to do so, subject to the following conditions:
 *  The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
 *  
 *  THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
 *  OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS
 *  BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF
 *  OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
 *  
 *  Inspired by the original official NexDome ASCOM Driver by grozzie2
 *  https://github.com/grozzie2/NexDome
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using ASCOM.Utilities;
using ASCOM.DeviceInterface;
using ASCOM.PDome;

namespace ASCOM.PDome
{
    [ComVisible(false)]					// Form not registered for COM!
    public partial class SetupForm : Form
    {
        public Dome myDome;
        private double _rotatorCutoffVolts, _shutterCutoffVolts;
        private long _rotatorAcceleration, _rotatorSpeed, _shutterAcceleration, _shutterSpeed, _rotatorStepsPer, _shutterStepsPer;
        private int _shutterSleepPeriod, _shutterSleepDelay;
        private double _rotatorHomePosition, _rotatorParkPosition, _shutterMaxElevation, _shutterMinElevation;
        private int _rainCheckPeriod;
        bool hasError, isCalibrating = false;


        private void btnHome_Click(object sender, EventArgs e)
        {
            if (btnHome.Text.Equals("Home") == true)
            {
                myDome.CommandBlind(Dome.HOME_ROT_CMD);
                btnHome.Text = "Cancel";
            }
            else
            {
                myDome.CommandBlind(Dome.ABORT_MOVE_CMD);
                btnHome.Text = "Home";
            }
        }

        private void btnCalibrateRotator_Click(object sender, EventArgs e)
        {
            if (btnCalibrateRotator.Text.Equals("Calibrate") == true)
            {
                myDome.CommandBlind(Dome.CAL_ROT_CMD);
                btnCalibrateRotator.Text = "Cancel";
                isCalibrating = true;
            }
            else
            {
                myDome.CommandBlind(Dome.ABORT_MOVE_CMD);
                btnCalibrateRotator.Text = "Calibrate";
                isCalibrating = false;
            }
        }

        private void SetupForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            myDome.CommandBlind(Dome.ABORT_MOVE_CMD);
        }

        private void btnOpenShutter_Click(object sender, EventArgs e)
        {
            if (btnOpenShutter.Text.Equals( "Open"))
            {
                myDome.OpenShutter();
                btnOpenShutter.Text = "STOP";
                btnCloseShutter.Enabled = false;
            }
            else
            {
                myDome.AbortSlew();
                btnOpenShutter.Text = "Open";
                btnCloseShutter.Enabled = true;
            }
        }

        private void btnCloseShutter_Click(object sender, EventArgs e)
        {
            if (btnCloseShutter.Text.Equals("Close"))
            {
                myDome.CloseShutter();
                btnCloseShutter.Text = "STOP";
                btnOpenShutter.Enabled = false;
            }
            else
            {
                myDome.AbortSlew();
                btnCloseShutter.Text = "Close";
                btnOpenShutter.Enabled = true;
            }
        }

        private void Double_Validation(object sender, CancelEventArgs e)
        {
            double temp;
            hasError = false;
            TextBox tbx = (TextBox)sender;
            if (double.TryParse(tbx.Text, out temp) == false) hasError = true;

            if (hasError == true)
            {
                errorProvider1.SetError((TextBox)sender, "Invalid entry");
            }
            else
            {
                errorProvider1.SetError(tbx, "");
            }

        }
        private void Int_Validation(object sender, CancelEventArgs e)
        {
            int temp;
            hasError = false;
            TextBox tbx = (TextBox)sender;
            if (int.TryParse(tbx.Text, out temp) == false) hasError = true;
            if (temp < 0) hasError = true;
            if (hasError == true)
            {
                errorProvider1.SetError((TextBox)sender, "Invalid entry");
            }
            else
            {
                errorProvider1.SetError(tbx, "");
            }
        }

        public SetupForm()
        {
            InitializeComponent();
            //Initialise current values of user settings from the ASCOM Profile
            InitUI();
        }

        private void cmdOK_Click(object sender, EventArgs e) // OK button event handler
        {
            //todo: Check for negative values
            int errorcount = 0;
            if (double.TryParse(tbxRotatorCutOff.Text, out _rotatorCutoffVolts) == false) errorcount++;
            if (long.TryParse(tbxRotatorStepsPer.Text, out _rotatorStepsPer) == false) errorcount++;
            if (double.TryParse(tbxRotatorHomePos.Text, out _rotatorHomePosition) == false) errorcount++;
            if (double.TryParse(tbxRotatorParkPos.Text, out _rotatorParkPosition) == false) errorcount++;
            if (long.TryParse(tbxRotatorAcceleration.Text, out _rotatorAcceleration) == false) errorcount++;
            if (long.TryParse(tbxRotatorStepRate.Text, out _rotatorSpeed) == false) errorcount++;
            if (int.TryParse(tbxRainCheckPeriod.Text, out _rainCheckPeriod) == false) errorcount++;

            if (Dome.canSetShutter == true)
            {
                if (double.TryParse(tbxShutterCutOff.Text, out _shutterCutoffVolts) == false) errorcount++;
                if (long.TryParse(tbxShutterAcceleration.Text, out _shutterAcceleration) == false) errorcount++;
                if (long.TryParse(tbxShutterStepRate.Text, out _shutterSpeed) == false) errorcount++;
                if (long.TryParse(tbxShutterStepsPer.Text, out _shutterStepsPer) == false) errorcount++;
                if (int.TryParse(tbxShutterSleepPeriod.Text, out _shutterSleepPeriod) == false) errorcount++;
                if (int.TryParse(tbxShutterSleepDelay.Text, out _shutterSleepDelay) == false) errorcount++;
            }
            if (errorcount > 0) return; // No use proceeding if there are errors.

            if (_rotatorHomePosition < 0.0 || _rotatorHomePosition >= 360.0) errorcount++;
            if (_rotatorParkPosition < 0.0 || _rotatorParkPosition >= 360.0) errorcount++;

            if (errorcount > 0) return;
            // All good! Now fire off those values to the controllers.

            if (chkRotatorReversed.Checked != Dome.rotatorReversed) myDome.CommandBlind(Dome.REV_ROT_CMD + myDome.BoolToNumberString(chkRotatorReversed.Checked));
            if (_rotatorStepsPer != Dome.rotatorStepsPer) myDome.CommandBlind(Dome.STEPS_ROT_CMD + _rotatorStepsPer.ToString());
            if (_rotatorHomePosition != Dome.rotatorHomePosition) myDome.CommandBlind(Dome.HOMEAZ_ROT_CMD + _rotatorHomePosition.ToString());
            if (_rotatorParkPosition != Dome.rotatorParkPosition) myDome.CommandBlind(Dome.PARKAZ_ROT_CMD + _rotatorParkPosition.ToString());
            if (_rotatorCutoffVolts != Dome.rotatorCutoffVolts) myDome.CommandBlind(Dome.VOLTS_ROT_CMD + ((int)(_rotatorCutoffVolts * 100)).ToString());
            if (_rotatorAcceleration != Dome.rotatorAcceleration) myDome.CommandBlind(Dome.ACCEL_ROT_CMD + _rotatorAcceleration.ToString());
            if (_rotatorSpeed != Dome.rotatorSpeed) myDome.CommandBlind(Dome.SPEED_ROT_CMD + _rotatorSpeed.ToString());
            if (_rainCheckPeriod != Dome.rainCheckInterval)
            {
                Dome.rainCheckInterval = _rainCheckPeriod;
                myDome.CommandBlind(Dome.RAIN_ROT_CMD + _rainCheckPeriod.ToString());
            }
            Dome.LogMessage("Shutter Version", "Equals ({0})", Dome.shutterVersion);
            if (Dome.canSetShutter == true)
            {

                Dome.canSetAltitude = chkCanSetAltitude.Checked;
                if (chkShutterReversed.Checked != Dome.shutterReversed) myDome.CommandBlind(Dome.REV_SHUT_CMD + myDome.BoolToNumberString(chkShutterReversed.Checked));
                if (_shutterCutoffVolts != Dome.shutterCutoffVolts) myDome.CommandBlind(Dome.VOLTS_SHUT_CMD + _shutterCutoffVolts.ToString());
                if (_shutterAcceleration != Dome.shutterAcceleration) myDome.CommandBlind(Dome.ACCEL_SHUT_CMD + _shutterAcceleration.ToString());
                if (_shutterSpeed != Dome.rotatorSpeed) myDome.CommandBlind(Dome.SPEED_SHUT_CMD + _shutterSpeed.ToString());
                if (_shutterStepsPer != Dome.shutterStepsPer) myDome.CommandBlind(Dome.STEPS_SHUT_CMD + _shutterStepsPer.ToString());
                if (chkShutterSleepEnabled.Checked != Dome.shutterSleepEnabled || _shutterSleepPeriod != Dome.shutterSleepPeriod || _shutterSleepDelay != Dome.shutterSleepDelay)
                {
                    string sleepstring = myDome.BoolToNumberString(chkShutterSleepEnabled.Checked) + "," + _shutterSleepPeriod.ToString() + "," + _shutterSleepDelay.ToString();
                    myDome.CommandBlind(Dome.SLEEP_SHUT_CMD + sleepstring);
                }
            }

            Dome.canSetShutter = chkCanSetShutter.Checked;
            Dome.canFindHome = chkCanFindHome.Checked;
            Dome.canPark = chkCanPark.Checked;
            Dome.canSetAzimuth = chkCanSetAzimuth.Checked;
            Dome.canSetPark = chkCanSetPark.Checked;
            Dome.canSyncAzimuth = chkCanSyncAz.Checked;
            Dome.canSlave = chkCanSlave.Checked;


            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e) // Cancel button event handler
        {
            Close();
        }

        private void BrowseToAscom(object sender, EventArgs e) // Click on ASCOM logo event handler
        {
            try
            {
                System.Diagnostics.Process.Start("http://ascom-standards.org/");
            }
            catch (System.ComponentModel.Win32Exception noBrowser)
            {
                if (noBrowser.ErrorCode == -2147467259)
                    MessageBox.Show(noBrowser.Message);
            }
            catch (System.Exception other)
            {
                MessageBox.Show(other.Message);
            }
        }

        private void InitUI()
        {
            gbRotatorVersion.Text = "Rotator Version " + Dome.rotatorVersion;
            chkRotatorReversed.Checked = Dome.rotatorReversed;
            lblRotatorVolts.Text = Dome.rotatorVolts.ToString();
            tbxRotatorStepsPer.Text = Dome.rotatorStepsPer.ToString();
            tbxRotatorCutOff.Text = Dome.rotatorCutoffVolts.ToString();
            tbxRotatorHomePos.Text = Dome.rotatorHomePosition.ToString();
            tbxRotatorParkPos.Text = Dome.rotatorParkPosition.ToString();
            tbxRotatorAcceleration.Text = Dome.rotatorAcceleration.ToString();
            tbxRotatorStepRate.Text = Dome.rotatorSpeed.ToString();
            tbxRainCheckPeriod.Text = Dome.rainCheckInterval.ToString();


            if (Dome.canSetShutter == true)
            {

                string shutterText = "";
                lblShutterStepPos.Text = Dome.shutterPosition.ToString();
                gbShutterVersion.Text = "Shutter Version " + Dome.shutterVersion;
                gbShutterVersion.Enabled = true;
                gbShutterSettings.Enabled = true;
                chkCanSetShutter.Enabled = true;
                chkShutterReversed.Checked = Dome.shutterReversed;
                lblShutterVolts.Text = Dome.shutterVolts.ToString();
                tbxShutterStepsPer.Text = Dome.shutterStepsPer.ToString();
                tbxShutterCutOff.Text = Dome.shutterCutoffVolts.ToString();
                tbxShutterAcceleration.Text = Dome.shutterAcceleration.ToString();
                tbxShutterStepRate.Text = Dome.shutterSpeed.ToString();
                tbxRainCheckPeriod.Text = Dome.rainCheckInterval.ToString();
                tbxShutterSleepPeriod.Text = Dome.shutterSleepPeriod.ToString();
                tbxShutterSleepDelay.Text = Dome.shutterSleepDelay.ToString();
                chkShutterSleepEnabled.Checked = Dome.shutterSleepEnabled;

                switch (Dome.shutterState)
                {
                    case ShutterState.shutterOpen:
                        shutterText = "Open";
                        break;
                    case ShutterState.shutterClosed:
                        shutterText = "Closed";
                        break;
                    case ShutterState.shutterOpening:
                        shutterText = "Opening";
                        break;
                    case ShutterState.shutterClosing:
                        shutterText = "Closing";
                        break;
                    default:
                        shutterText = "Error";
                        break;
                }
                lblShutterState.Text = shutterText;
            }

            chkCanFindHome.Checked = Dome.canFindHome;
            chkCanPark.Checked = Dome.canPark;
            chkCanSetAzimuth.Checked = Dome.canSetAzimuth;
            chkCanSetPark.Checked = Dome.canSetPark;
            chkCanSetShutter.Checked = Dome.canSetShutter;
            chkCanSyncAz.Checked = Dome.canSyncAzimuth;
            chkCanSlave.Checked = Dome.canSlave;
        }

        private void SetupDialogForm_Load(object sender, EventArgs e)
        {

        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            string homeText = "", seekText = "";
            string shutterText;
            #region "Rotator"
            switch (Dome.rotatorSeekState)
            {
                case Dome.SeekStates.CALIBRATION_MEASURE:
                    seekText = "Measuring dome";
                    break;
                case Dome.SeekStates.CALIBRATION_MOVEOFF:
                    seekText = "Move off home";
                    break;
                case Dome.SeekStates.HOMING_HOME:
                    seekText = "Finding home";
                    break;
                case Dome.SeekStates.HOMING_NONE:
                    if (isCalibrating == true)
                    {
                        isCalibrating = false;
                        tbxRotatorStepsPer.Text = myDome.CommandString(Dome.STEPS_ROT_CMD);
                    }
                    seekText = "---";
                    break;
            }

            lblRotatorSeekMode.Text = seekText;

            if (Dome.rotatorHomedStatus == -1)
            {
                homeText = "Requires homing";
            }
            else if (Dome.rotatorHomedStatus == 0)
            {
                homeText = "Has homed";
            }
            else if (Dome.rotatorHomedStatus == 1)
            {
                homeText = "At home";
                if (btnHome.Text.Equals("Cancel"))
                {
                    btnHome.Text = "Home";
                    btnCalibrateRotator.Enabled = true;
                }
            }
            lblHomeStatus.Text = homeText;

            lblRotatorHeading.Text = Dome.azimuth.ToString();
            lblRotatorStepPos.Text = Dome.rotatorStepPosition.ToString();
            #endregion

            #region "Shutter"

            if (Dome.canSetShutter == true)
            {
                lblShutterStepPos.Text = Dome.shutterPosition.ToString();
                lblShutterElevation.Text = Dome.shutterElevation.ToString();

                switch (Dome.shutterState)
                {
                    case ShutterState.shutterOpen:
                        shutterText = "Open";
                        if (btnOpenShutter.Text.Equals("STOP"))
                        {
                            btnOpenShutter.Text = "Open";
                            btnCloseShutter.Enabled = true;
                        }
                        break;
                    case ShutterState.shutterClosed:
                        shutterText = "Closed";
                        if (btnCloseShutter.Text.Equals("STOP"))
                        {
                            btnCloseShutter.Text = "Close";
                            btnOpenShutter.Enabled = true;
                        }
                        break;
                    case ShutterState.shutterOpening:
                        shutterText = "Opening";
                        break;
                    case ShutterState.shutterClosing:
                        shutterText = "Closing";
                        break;
                    default:
                        shutterText = "Unknown";
                        break;
                }
                lblShutterState.Text = shutterText;
            }
            #endregion
        }
    }
}