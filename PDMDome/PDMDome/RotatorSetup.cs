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
            this.Text = "Rotator version " + Dome.rotatorVersion;
            isLoading = false;
        }

        private void InitUI()
        {
            tbxCutoff.Text = (Dome.rotatorCutoff / 100.0).ToString("0,0.00");
            tbxMaxSpeed.Text = Dome.rotatorMaxSpeed.ToString();
            tbxAcceleration.Text = Dome.rotatorAcceleration.ToString();
            _stepsPer = Dome.rotatorStepsPer;
            tbxStepsPerRotation.Text = _stepsPer.ToString();
            chkReversed.Checked = Dome.rotatorReversed;
            tbxHomeAz.Text = Dome.rotatorHomeAz.ToString();
            tbxParkAz.Text = Dome.rotatorParkAz.ToString();
            lblSeekMode.Text = SeekText(Dome.rotatorSeekState);
            lblHomedState.Text = HomedText(Dome.rotatorHomedStatus);
        }

        private string HomedText(int mode)
        {
            string homedText = "Error";
            switch ((HomeStatuses)mode)
            {
                case HomeStatuses.NEVER_HOMED:
                    homedText = "Has not homed";
                    break;
                case HomeStatuses.HOMED:
                    homedText = "Has homed";
                    break;
                case HomeStatuses.ATHOME:
                    homedText = "At home";
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
                    seekText = "None";
                    break;
                case Seeks.HOMING_HOME:
                    seekText = "Homing";
                    break;
                case Seeks.CALIBRATION_MOVEOFF:
                    seekText = "Move off home";
                    break;
                case Seeks.CALIBRATION_MEASURE:
                    seekText = "Measuring Dome";
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
                cutoff *= 100.0;
                Dome.rotatorCutoff = (int)cutoff;
                myDome.SendSerial(Dome.VOLTS_ROTATOR_CMD + Dome.rotatorCutoff.ToString());
                Dome.LogMessage("Rotator SET", "CutOff Voltage ({0})", Dome.rotatorCutoff);
                errorProvider1.SetError(tbxCutoff, "");
            }
            else
            {
                errorProvider1.SetError(tbxCutoff, "Invalid voltage");
            }
        }
        private void btnMaxSpeed_Click(object sender, EventArgs e)
        {
            long value;
            if (long.TryParse(tbxMaxSpeed.Text, out value) == true)
            {
                Dome.rotatorMaxSpeed = value;
                myDome.SendSerial(Dome.SPEED_ROTATOR_CMD + value.ToString());
                errorProvider1.SetError(tbxMaxSpeed, "");
                Dome.LogMessage("Rotator SET", "Max Speed ({0})", value);
            }
            else
            {
                errorProvider1.SetError(tbxMaxSpeed, "Invalid value");
            }
        }
        private void btnAcceleration_Click(object sender, EventArgs e)
        {
            long value;

            if (long.TryParse(tbxAcceleration.Text, out value) == true)
            {
                Dome.rotatorAcceleration = value;
                myDome.SendSerial(Dome.ACCELERATION_ROTATOR_CMD + value.ToString());
                errorProvider1.SetError(tbxAcceleration, "");
                Dome.LogMessage("Rotator SET", "Acceleration ({0})", value);

            }
            else
            {
                errorProvider1.SetError(tbxAcceleration, "Invalid value");
            }

        }
        private void btnStepsPerRotation_Click(object sender, EventArgs e)
        {
            long value;

            if (long.TryParse(tbxStepsPerRotation.Text, out value) == true)
            {
                Dome.rotatorStepsPer = value;
                _stepsPer = value;
                myDome.SendSerial(Dome.STEPSPER_ROTATOR_CMD + value.ToString());
                errorProvider1.SetError(tbxStepsPerRotation, "");
                Dome.LogMessage("Rotator SET", "Steps Per Rotation ({0})", value);
            }
            else
            {
                errorProvider1.SetError(tbxStepsPerRotation, "Invalid value");
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
                Dome.rotatorHomeAz = az;
                myDome.SendSerial(Dome.HOMEAZ_ROTATOR_CMD + az.ToString());
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
                Dome.rotatorParkAz = az;
                myDome.SendSerial(Dome.PARKAZ_ROTATOR_CMD + az.ToString());
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
            myDome.SendSerial(Dome.MOVERELATIVE_ROTATOR_CMD + (Dome.rotatorStepsPer - 1).ToString());
            
        }
        private void btnGoToPos_Click(object sender, EventArgs e)
        {
            long pos;
            if (long.TryParse(tbxGotoPos.Text, out pos))
            {
                myDome.SendSerial(Dome.POSITION_ROTATOR_CMD + pos.ToString());
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
            myDome.SendSerial(Dome.MOVERELATIVE_ROTATOR_CMD + "-250000");
            Dome.tl.LogMessage("Rotator SET", "Move Relative -250000");
        }
        private void btnRotateCW_MouseDown(object sender, MouseEventArgs e)
        {
            myDome.SendSerial(Dome.MOVERELATIVE_ROTATOR_CMD + "250000");
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

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblVoltage.Text = (Dome.rotatorVoltage / 100.0).ToString("0,0.00");
            if (Dome.rotatorVoltage <= Dome.rotatorCutoff)
            {
                lblLowWarn.Visible = true;
            }
            else
            {
                lblLowWarn.Visible = false;
            }
            lblPosition.Text = Dome.rotatorPosition.ToString();
            lblAzimuth.Text = Dome.azimuth.ToString();
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

        }

    }
}
