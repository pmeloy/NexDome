using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ASCOM.PDM
{
    public partial class RotatorSetup : Form
    {
        internal Dome myDome;
        private bool isLoading = true, isHoming = false;
        private long _stepsPer = 0;
        internal enum HomeStatuses
        {
            NEVER_HOMED,
            HOMED,
            ATHOME
        };
        internal enum Seeks
        {
            HOMING_NONE, // Not homing or calibrating
            HOMING_HOME, // Homing
            CALIBRATION_MOVEOFF, // Ignore home until we've moved off while measuring the dome.
            CALIBRATION_MEASURE // Measuring dome until home hit again.
        };

        public RotatorSetup()
        {
            InitializeComponent();
            InitUI();
        }

        private void RotatorSetup_Load(object sender, EventArgs e)
        {
            this.Text = GlobalStrings.RotatorVersionText+ " " + Dome.rotatorVersion;
            isLoading = false;
        }

        private void InitUI()
        {
            
            gbxVoltages.Text = GlobalStrings.VoltagesBoxTitle;
            btnSetCutoff.Text = GlobalStrings.SetText;
            lblVoltageTitle.Text = GlobalStrings.VoltageText;
            lblCutOffTitle.Text = GlobalStrings.CutOffText;
            lblLowWarn.Text = GlobalStrings.LowText;

            gbxMotorSettings.Text = GlobalStrings.MotorSettingsText;
            lblAcceleration.Text = GlobalStrings.AccelerationText;
            btnAcceleration.Text = GlobalStrings.SetText;
            lblMaxSpeed.Text = GlobalStrings.MaxSpeedText;
            btnMaxSpeed.Text = GlobalStrings.SetText;
            lblStepsPer.Text = GlobalStrings.StepPerText;
            btnStepsPerRotation.Text = GlobalStrings.SetText;
            chkReversed.Text = GlobalStrings.ReversedText;
            gbxHomeandPark.Text = GlobalStrings.HomeAndParkText;
            lblHomePosTitle.Text = GlobalStrings.HomeText;
            btnSetHome.Text = GlobalStrings.SetText;
            btnSetPark.Text = GlobalStrings.SetText;
            lblParkPosTitle.Text = GlobalStrings.ParkText;

            gbxMovement.Text = GlobalStrings.MovementText;
            btnPark.Text = GlobalStrings.GoParkText;
            btnGoToAz.Text = GlobalStrings.GoToAzText;
            btnSync.Text = GlobalStrings.SyncAzText;
            btnFullTurn.Text = GlobalStrings.FullTurnText;
            btnGoToPos.Text = GlobalStrings.GoToPosText;
            btnSTOP.Text = GlobalStrings.StopText;
            btnHome.Text = GlobalStrings.GoHomeText;
            btnCalibrate.Text = GlobalStrings.DoCalibrateText;
            lblHomeStatusTitle.Text = GlobalStrings.HomeStatusText;
            lblSeekModeTitle.Text = GlobalStrings.SeekModeText;
            btnClose.Text = GlobalStrings.CloseText;

            lblAtPark.Text = GlobalStrings.AtParkText;

            gbxRain.Text = GlobalStrings.RainBoxTitle;
            lblRainState.Text = GlobalStrings.RainStateRainingText;
            lblRainInterval.Text = GlobalStrings.RainIntervalText;
            chkRainRequireTwice.Text = GlobalStrings.RainRequireTwiceText;
            btnSetRainInterval.Text = GlobalStrings.SetText;
            tbxRainInterval.Text = Dome.rotatorRainInterval.ToString();
            chkRainRequireTwice.Checked = Dome.rainSensorTwice;
            cbxRainAction.SelectedIndex = Dome.rotatorRainAction;


            tbxCutoff.Text = (Dome.rotatorCutoff / 100.0).ToString("0,0.00");
            tbxMaxSpeed.Text = Dome.rotatorMaxSpeed.ToString();
            tbxAcceleration.Text = Dome.rotatorAcceleration.ToString();
            _stepsPer = Dome.rotatorStepsPer;
            tbxStepsPerRotation.Text = _stepsPer.ToString();
            chkReversed.Checked = Dome.rotatorReversed;
            tbxHomeAz.Text = Dome.rotatorHomeAz.ToString("0,0.00");
            tbxParkAz.Text = Dome.rotatorParkAz.ToString("0,0.00");
            lblSeekMode.Text = SeekText(Dome.rotatorSeekState);
            lblHomedState.Text = HomedText(Dome.rotatorHomedStatus);
        }

        private string HomedText(int mode)
        {
            string homedText = "Error";
            switch ((HomeStatuses)mode)
            {
                case HomeStatuses.NEVER_HOMED:
                    homedText = GlobalStrings.NeverHomedText;
                    break;
                case HomeStatuses.HOMED:
                    homedText = GlobalStrings.HasHomedText;
                    break;
                case HomeStatuses.ATHOME:
                    homedText = GlobalStrings.AtHomeText;
                    break;
            }

            return homedText;
        }
        private string SeekText(int mode)
        {
            string seekText ="Error";
            switch ((Seeks)mode)
            {
                case Seeks.HOMING_NONE:
                    seekText = GlobalStrings.SeekNoneText;
                    break;
                case Seeks.HOMING_HOME:
                    seekText = GlobalStrings.SeekHomeText;
                    break;
                case Seeks.CALIBRATION_MOVEOFF:
                    seekText = GlobalStrings.SeekMoveOff;
                    break;
                case Seeks.CALIBRATION_MEASURE:
                    seekText = GlobalStrings.SeekMeasuring;
                    break;
            }
            return seekText;
        }

        #region "Buttons"

        private void btnSetCutoff_Click(object sender, EventArgs e)
        {
            double cutoff;
            if (double.TryParse(tbxCutoff.Text, out cutoff) == true)
            {
                tbxCutoff.Text = cutoff.ToString("0,0.00");
                cutoff *= 100.0;
                Dome.rotatorCutoff = (int)cutoff;
                myDome.SendSerial(Dome.VOLTS_ROTATOR_CMD + Dome.rotatorCutoff.ToString(Dome.sourceCulture));
                Dome.LogMessage("Rotator SET", "CutOff Voltage ({0})", Dome.rotatorCutoff);
                errorProvider1.SetError(tbxCutoff, "");
            }
            else
            {
                errorProvider1.SetError(tbxCutoff, GlobalStrings.InvalidNumberText);
            }
        }
        private void btnMaxSpeed_Click(object sender, EventArgs e)
        {
            long value;
            if (long.TryParse(tbxMaxSpeed.Text, out value) == true)
            {
                Dome.rotatorMaxSpeed = value;
                myDome.SendSerial(Dome.SPEED_ROTATOR_CMD + value.ToString(Dome.sourceCulture));
                errorProvider1.SetError(tbxMaxSpeed, "");
                Dome.LogMessage("Rotator SET", "Max Speed ({0})", value);
            }
            else
            {
                errorProvider1.SetError(tbxMaxSpeed, GlobalStrings.InvalidNumberText);
            }
        }
        private void btnAcceleration_Click(object sender, EventArgs e)
        {
            long value;

            if (long.TryParse(tbxAcceleration.Text, out value) == true)
            {
                Dome.rotatorAcceleration = value;
                myDome.SendSerial(Dome.ACCELERATION_ROTATOR_CMD + value.ToString(Dome.sourceCulture));
                errorProvider1.SetError(tbxAcceleration, "");
                Dome.LogMessage("Rotator SET", "Acceleration ({0})", value);

            }
            else
            {
                errorProvider1.SetError(tbxAcceleration, GlobalStrings.InvalidNumberText);
            }

        }
        private void btnStepsPerRotation_Click(object sender, EventArgs e)
        {
            long value;

            if (long.TryParse(tbxStepsPerRotation.Text, out value) == true)
            {
                Dome.rotatorStepsPer = value;
                _stepsPer = value;
                myDome.SendSerial(Dome.STEPSPER_ROTATOR_CMD + value.ToString(Dome.sourceCulture));
                errorProvider1.SetError(tbxStepsPerRotation, "");
                Dome.LogMessage("Rotator SET", "Steps Per Rotation ({0})", value);
            }
            else
            {
                errorProvider1.SetError(tbxStepsPerRotation, GlobalStrings.InvalidNumberText);
            }

        }
        private void chkReversed_CheckedChanged(object sender, EventArgs e)
        {
            if (isLoading == false)
            {
                string reversed = "0";
                if (chkReversed.Checked == true) reversed = "1";

                Dome.LogMessage("Rotator SET", "Reversed ({0})", reversed);
                Dome.rotatorReversed = chkReversed.Checked;
                myDome.SendSerial(Dome.REVERSED_ROTATOR_CMD + reversed);
            }
        }
        private void btnSetHome_Click(object sender, EventArgs e)
        {
            double az;
            if (double.TryParse(tbxHomeAz.Text, out az) == true)
            {
                tbxHomeAz.Text = az.ToString("0,0.00");
                Dome.rotatorHomeAz = az;
                myDome.SendSerial(Dome.HOMEAZ_ROTATOR_CMD + az.ToString(Dome.sourceCulture));
                Dome.LogMessage("Rotator SET", "Home Azimuth ({0})", az);
            }
            else
            {
                errorProvider1.SetError(tbxHomeAz, "Invalid Azimuth");
            }
        }
        private void btnSetPark_Click(object sender, EventArgs e)
        {
            double az;
            if (double.TryParse(tbxParkAz.Text, out az) == true)
            {
                tbxParkAz.Text = az.ToString("0,0.00");
                Dome.rotatorParkAz = az;
                myDome.SendSerial(Dome.PARKAZ_ROTATOR_CMD + az.ToString(Dome.sourceCulture));
                Dome.LogMessage("Rotator SET", "Park Azimuth ({0})", az);
            }
            else
            {
                errorProvider1.SetError(tbxParkAz, "Invalid Azimuth");
            }
        }
        private void btnPark_Click(object sender, EventArgs e)
        {
            myDome.SlewToAzimuth(Dome.rotatorParkAz);
        }
        private void btnSync_Click(object sender, EventArgs e)
        {
            double az;
            if (double.TryParse(tbxGotoAz.Text, out az) == true)
            {
                myDome.SyncToAzimuth(az);
                errorProvider1.SetError(tbxGotoAz, "");
                Dome.LogMessage("Rotator SET", "Sync to ({0})", az);
                tbxGotoAz.Text = "";
            }
            else
            {
                errorProvider1.SetError(tbxGotoAz, "Invalid Azimuth");
            }
        }
        private void btnGotoAz_Click(object sender, EventArgs e)
        {
            double az;
            if (double.TryParse(tbxGotoAz.Text, out az))
            {
                myDome.SlewToAzimuth(az);
                errorProvider1.SetError(tbxGotoAz, "");
                Dome.LogMessage("Rotator SET", "Go to azimuth ({0})", az);
                tbxGotoAz.Text = "";
            }
            else
            {
                errorProvider1.SetError(tbxGotoAz, "Invalid Azimuth");
            }
        }
        private void btnFullTurn_Click(object sender, EventArgs e)
        {
            myDome.SendSerial(Dome.MOVE_RELATIVE_ROTATOR_CMD + (Dome.rotatorStepsPer - 1).ToString(Dome.sourceCulture));
            
        }
        private void btnGoToPos_Click(object sender, EventArgs e)
        {
            long pos;
            if (long.TryParse(tbxGotoPos.Text, out pos))
            {
                myDome.SendSerial(Dome.POSITION_ROTATOR_CMD + pos.ToString(Dome.sourceCulture));
                errorProvider1.SetError(tbxGotoPos, "");
                Dome.LogMessage("Rotator SET", "Go to position ({0})", pos);
                tbxGotoPos.Text = "";
            }
            else
            {
                errorProvider1.SetError(tbxGotoPos, "Invalid Azimuth");
            }
        }
        private void btnSTOP_Click(object sender, EventArgs e)
        {
            myDome.AbortSlew();
            Dome.tl.LogMessage("Rotator SET", "Manual STOP");
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            myDome.FindHome();
            isHoming = true;
            Dome.tl.LogMessage("Rotator SET", "Homing");
        }
        private void btnCalibrate_Click(object sender, EventArgs e)
        {
            myDome.SendSerial(Dome.CALIBRATE_ROTATOR_CMD);
            Dome.tl.LogMessage("Rotator SET", "Calibration Start");
        }
        private void btnRotateCCW_MouseDown(object sender, MouseEventArgs e)
        {
            myDome.SendSerial(Dome.MOVE_RELATIVE_ROTATOR_CMD + "-250000");
            Dome.tl.LogMessage("Rotator SET", "Move Relative -250000");
        }
        private void btnRotateCW_MouseDown(object sender, MouseEventArgs e)
        {
            myDome.SendSerial(Dome.MOVE_RELATIVE_ROTATOR_CMD + "250000");
            Dome.tl.LogMessage("Rotator SET", "Move Relative +250000");
            lblMultiStatus.Text = ">>>";
        }
        private void btnRotate_UP(object sender, MouseEventArgs e)
        {
            myDome.AbortSlew();
            lblMultiStatus.Text = "---";
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSetRainInterval_Click(object sender, EventArgs e)
        {
            int rainInterval = 0;
            if (int.TryParse(tbxRainInterval.Text, out rainInterval) == true)
            {
                myDome.SendSerial(Dome.RAIN_ROTATOR_CMD + rainInterval.ToString(Dome.sourceCulture));
                errorProvider1.SetError(tbxRainInterval, "");
            }
            else
            {
                errorProvider1.SetError(tbxRainInterval, GlobalStrings.InvalidNumberText);
            }
        }

        private void chkRainRequireTwice_CheckedChanged(object sender, EventArgs e)
        {
            if (isLoading == false)
            {
                Dome.rainSensorTwice = chkRainRequireTwice.Checked;
                Dome.LogMessage("Rotator Get", "Require rain twice ({0})", Dome.rainSensorTwice.ToString());
                if (Dome.rainSensorTwice == true)
                {
                    myDome.SendSerial(Dome.RAIN_ROTATOR_TWICE_CMD + "1");
                }
                else
                {
                    myDome.SendSerial(Dome.RAIN_ROTATOR_TWICE_CMD + "0");
                }
            }
        }

        #endregion

        private void cbxRainAction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isLoading == true) return;
            Dome.rotatorRainAction = cbxRainAction.SelectedIndex;
            Dome.LogMessage("Rotator SET", "Rain action ({0})", Dome.rotatorRainAction);
            myDome.SendSerial(Dome.RAIN_ROTATOR_ACTION + Dome.rotatorRainAction.ToString(Dome.sourceCulture));
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblVoltageBox.Text = (Dome.rotatorVoltage / 100.0).ToString("0,0.00");
            if (Dome.rotatorVoltage <= Dome.rotatorCutoff)
            {
                lblLowWarn.Visible = true;
            }
            else
            {
                lblLowWarn.Visible = false;
            }
            lblPosition.Text = Dome.rotatorPosition.ToString();
            lblAzimuth.Text = Dome.azimuth.ToString("0,0.00");
            lblHomedState.Text = HomedText(Dome.rotatorHomedStatus);
            lblSeekMode.Text = SeekText(Dome.rotatorSeekState);
            if (Dome.rotatorHomedStatus == (int)HomeStatuses.ATHOME)
            {
                btnCalibrate.Enabled = true;
            }
            else
            {
                btnCalibrate.Enabled = false;
            }
            if (Dome.rotatorSeekState == (int)Seeks.HOMING_NONE || Dome.rotatorSeekState > (int)Seeks.HOMING_HOME) isHoming = false;
            Dome.LogMessage("Rotator Settings Get","Slew Direction ({0})",Dome.rotatorSlewDirection);

            if (Dome.rotatorSlewDirection == -1)
            {
                lblMultiStatus.Text = "<<<";
            }
            else if (Dome.rotatorSlewDirection == 1)
            {
                lblMultiStatus.Text = ">>>";
            }
            else
            {
                lblMultiStatus.Text = "---";
            }
            if (Dome.rotatorStepsPer != _stepsPer)
            {
                _stepsPer = Dome.rotatorStepsPer;
                Dome.tl.LogMessage("Rotator", "Calibration completed");
                tbxStepsPerRotation.Text = Dome.rotatorStepsPer.ToString();
            }
            if (myDome.AtPark == true)
            {
                lblAtPark.Visible = true;
            }
            else
            {
                lblAtPark.Visible = false;
            }
            if (Dome.isRaining == true)
            {
                lblRainState.Text = GlobalStrings.RainStateRainingText;
                lblRainState.ForeColor = Color.White;
                lblRainState.BackColor = Color.Red;
            }
            else
            {
                lblRainState.Text = GlobalStrings.RainStateNotRainingText;
                lblRainState.ForeColor = SystemColors.ControlText;
                lblRainState.BackColor = SystemColors.Control;
            }

        }

    }
}
