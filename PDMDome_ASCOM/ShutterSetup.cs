using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ASCOM.PDM
{
    public partial class ShutterSetup : Form
    {
        internal Dome myDome;
        private bool isLoading = true;

        public ShutterSetup()
        {
            InitializeComponent();
            InitUI();
        }

        private void ShutterSetup_Load(object sender, EventArgs e)
        {
            this.Text = GlobalStrings.ShutterVersionText + " " + Dome.shutterVersion;
            isLoading = false;
            timer1.Enabled = true;
        }

        private void InitUI()
        {
            gbxVoltages.Text = GlobalStrings.VoltagesBoxTitle;
            lblVoltageTitle.Text = GlobalStrings.VoltageText;
            lblCutOffTitle.Text = GlobalStrings.CutOffText;
            btnSetCutoff.Text = GlobalStrings.SetText;

            lblLowWarn.Text = GlobalStrings.LowText;

            gbxMotorSettings.Text = GlobalStrings.MotorSettingsText;
            lblMaxSpeedTitle.Text = GlobalStrings.MaxSpeedText;
            btnMaxSpeed.Text = GlobalStrings.SetText;
            lblAccelerationTitle.Text = GlobalStrings.AccelerationText;
            btnAcceleration.Text = GlobalStrings.SetText;
            lblStepsPerTitle.Text = GlobalStrings.StepPerText;
            btnStepsPerRotation.Text = GlobalStrings.SetText;
            chkReversed.Text = GlobalStrings.ReversedText;
            chkCloseImmediate.Text = GlobalStrings.ShutterCloseLowText;

            lblRainWarn.Text = GlobalStrings.RainStateNotRainingText;
            lblRainWarn.Visible = true;
            gbxMovement.Text = GlobalStrings.MovementText;
            btnOpenShutter.Text = GlobalStrings.OpenShutterText;
            btnCloseShutter.Text = GlobalStrings.CloseShutterText;
            btnSTOP.Text = GlobalStrings.StopText;

            btnCloseForm.Text = GlobalStrings.CloseFormText;

            tbxCutoff.Text = (Dome.shutterCutoff / 100.0).ToString("0,0.00");
            tbxMaxSpeed.Text = Dome.shutterMaxSpeed.ToString();
            tbxAcceleration.Text = Dome.shutterAcceleration.ToString();
            tbxStepsPerRotation.Text = Dome.shutterStepsPer.ToString();
            chkReversed.Checked = Dome.shutterReversed;
            chkCloseImmediate.Checked = Dome.shutterCloseOnLowVoltage;

        }

        private void btnSetCutoff_Click(object sender, EventArgs e)
        {
            double cutoff;
            if (double.TryParse(tbxCutoff.Text, out cutoff) == true)
            {
                tbxCutoff.Text = cutoff.ToString("0,0.00");
                cutoff *= 100.0;
                Dome.shutterCutoff = (int)cutoff;
                myDome.SendSerial(Dome.VOLTS_SHUTTER_CMD + Dome.shutterCutoff.ToString(Dome.sourceCulture));
                Dome.LogMessage("Shutter SET", "CutOff Voltage ({0})", Dome.shutterCutoff);
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
                Dome.shutterMaxSpeed = value;
                myDome.SendSerial(Dome.SPEED_SHUTTER_CMD + value.ToString(Dome.sourceCulture));
                errorProvider1.SetError(tbxMaxSpeed, "");
                Dome.LogMessage("Shutter SET", "Max Speed ({0})", value);
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
                Dome.shutterAcceleration = value;
                myDome.SendSerial(Dome.ACCELERATION_SHUTTER_CMD + value.ToString(Dome.sourceCulture));
                errorProvider1.SetError(tbxAcceleration, "");
                Dome.LogMessage("Shutter SET", "Acceleration ({0})", value);

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
                Dome.shutterStepsPer = value;
                myDome.SendSerial(Dome.STEPSPER_SHUTTER_CMD + value.ToString(Dome.sourceCulture));
                errorProvider1.SetError(tbxStepsPerRotation, "");
                Dome.LogMessage("Shutter SET", "Steps Per Rotation ({0})", value);
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

                Dome.LogMessage("Shutter SET", "Reversed ({0})", reversed);
                Dome.shutterReversed = chkReversed.Checked;
                myDome.SendSerial(Dome.REVERSED_SHUTTER_CMD + reversed);
            }
        }
        private void btnSTOP_Click(object sender, EventArgs e)
        {
            myDome.AbortSlew();
        }
        private void btnOpen_Click(object sender, EventArgs e)
        {
            Dome.tl.LogMessage("Shutter Props Set", "Open Shutter");
            myDome.OpenShutter();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            myDome.CloseShutter();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private string StatusText(int state)
        {
            string returnString = GlobalStrings.ErrorText;
            switch (state)
            {
                case 0:
                    returnString = GlobalStrings.ShutterOpenText;
                    break;
                case 1:
                    returnString = GlobalStrings.ShutterClosedText;
                    break;
                case 2:
                    returnString = GlobalStrings.ShutterOpeningText;
                    break;
                case 3:
                    returnString = GlobalStrings.ShutterClosingText;
                    break;
                case 4:
                    returnString = GlobalStrings.ShutterUnknownText;
                    break;
            }
            return returnString;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {

            lblVoltage.Text = (Dome.shutterVoltage / 100.0).ToString("0.00");
            if (Dome.shutterVoltage <= Dome.shutterCutoff)
            {
                lblLowWarn.Visible = true;
            }
            else
            {
                lblLowWarn.Visible = false;
            }
            if ((int)Dome.domeShutterState == 4)
            {
                lblStatus.BackColor = Color.Orange;
            }
            else
            {
                lblStatus.BackColor = SystemColors.Control;
            }
            lblStatus.Text = StatusText((int)Dome.domeShutterState);
            if ((int)Dome.domeShutterState == 4 || Dome.shutterVoltage <= Dome.shutterCutoff || Dome.isRaining)
            {
                btnOpenShutter.Enabled = false;
            }
            else
            {
                btnOpenShutter.Enabled = true;
            }
            lblAltitude.Text = Dome.altitude.ToString("0.00");

            if (Dome.isRaining == true)
            {
                lblRainWarn.Text = GlobalStrings.RainStateRainingText;
                lblRainWarn.BackColor = Color.Red;
                lblRainWarn.ForeColor = Color.White;
            }
            else
            {
                lblRainWarn.Text = GlobalStrings.RainStateNotRainingText;
                lblRainWarn.BackColor = SystemColors.Control;
                lblRainWarn.ForeColor = SystemColors.ControlText;
            }
        }

        private void chkCloseImmediate_CheckedChanged(object sender, EventArgs e)
        {
            if (isLoading == true) return;
            int val = 0;
            if (chkCloseImmediate.Checked == true) val = 1;
            Dome.shutterCloseOnLowVoltage = chkCloseImmediate.Checked;
            myDome.SendSerial(Dome.LOWCLOSE_SHUTTER_CMD + val.ToString(Dome.sourceCulture));
        }
    }
}
