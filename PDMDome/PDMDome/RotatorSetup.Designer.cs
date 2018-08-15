namespace ASCOM.PDM
{
    partial class RotatorSetup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RotatorSetup));
            this.btnClose = new System.Windows.Forms.Button();
            this.gbxMotorSettings = new System.Windows.Forms.GroupBox();
            this.chkReversed = new System.Windows.Forms.CheckBox();
            this.lblMaxSpeed = new System.Windows.Forms.Label();
            this.btnMaxSpeed = new System.Windows.Forms.Button();
            this.btnAcceleration = new System.Windows.Forms.Button();
            this.lblAcceleration = new System.Windows.Forms.Label();
            this.tbxMaxSpeed = new System.Windows.Forms.TextBox();
            this.tbxAcceleration = new System.Windows.Forms.TextBox();
            this.tbxStepsPerRotation = new System.Windows.Forms.TextBox();
            this.btnStepsPerRotation = new System.Windows.Forms.Button();
            this.lblStepsPer = new System.Windows.Forms.Label();
            this.gbxMovement = new System.Windows.Forms.GroupBox();
            this.lblAtPark = new System.Windows.Forms.Label();
            this.btnFullTurn = new System.Windows.Forms.Button();
            this.lblSeekModeTitle = new System.Windows.Forms.Label();
            this.btnSync = new System.Windows.Forms.Button();
            this.lblSeekMode = new System.Windows.Forms.Label();
            this.btnSTOP = new System.Windows.Forms.Button();
            this.btnCalibrate = new System.Windows.Forms.Button();
            this.lblMultiStatus = new System.Windows.Forms.Label();
            this.btnGoToAz = new System.Windows.Forms.Button();
            this.btnRotateCCW = new System.Windows.Forms.Button();
            this.btnRotateCW = new System.Windows.Forms.Button();
            this.lblHomeStatusTitle = new System.Windows.Forms.Label();
            this.btnGoToPos = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnPark = new System.Windows.Forms.Button();
            this.lblHomedState = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.tbxGotoAz = new System.Windows.Forms.TextBox();
            this.tbxGotoPos = new System.Windows.Forms.TextBox();
            this.lblAzimuth = new System.Windows.Forms.Label();
            this.gbxVoltages = new System.Windows.Forms.GroupBox();
            this.lblLowWarn = new System.Windows.Forms.Label();
            this.tbxCutoff = new System.Windows.Forms.TextBox();
            this.btnSetCutoff = new System.Windows.Forms.Button();
            this.lblVoltageBox = new System.Windows.Forms.Label();
            this.lblCutOffTitle = new System.Windows.Forms.Label();
            this.lblVoltageTitle = new System.Windows.Forms.Label();
            this.gbxHomeandPark = new System.Windows.Forms.GroupBox();
            this.lblHomePosTitle = new System.Windows.Forms.Label();
            this.btnSetHome = new System.Windows.Forms.Button();
            this.btnSetPark = new System.Windows.Forms.Button();
            this.lblParkPosTitle = new System.Windows.Forms.Label();
            this.tbxHomeAz = new System.Windows.Forms.TextBox();
            this.tbxParkAz = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.gbxRain = new System.Windows.Forms.GroupBox();
            this.chkRainRequireTwice = new System.Windows.Forms.CheckBox();
            this.lblRainInterval = new System.Windows.Forms.Label();
            this.tbxRainInterval = new System.Windows.Forms.TextBox();
            this.lblRainState = new System.Windows.Forms.Label();
            this.btnSetRainInterval = new System.Windows.Forms.Button();
            this.gbxAutoClose = new System.Windows.Forms.GroupBox();
            this.lblAutoCloseAction = new System.Windows.Forms.Label();
            this.cbxRainAction = new System.Windows.Forms.ComboBox();
            this.gbxMotorSettings.SuspendLayout();
            this.gbxMovement.SuspendLayout();
            this.gbxVoltages.SuspendLayout();
            this.gbxHomeandPark.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.gbxRain.SuspendLayout();
            this.gbxAutoClose.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            resources.ApplyResources(this.btnClose, "btnClose");
            this.btnClose.Name = "btnClose";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // gbxMotorSettings
            // 
            this.gbxMotorSettings.Controls.Add(this.chkReversed);
            this.gbxMotorSettings.Controls.Add(this.lblMaxSpeed);
            this.gbxMotorSettings.Controls.Add(this.btnMaxSpeed);
            this.gbxMotorSettings.Controls.Add(this.btnAcceleration);
            this.gbxMotorSettings.Controls.Add(this.lblAcceleration);
            this.gbxMotorSettings.Controls.Add(this.tbxMaxSpeed);
            this.gbxMotorSettings.Controls.Add(this.tbxAcceleration);
            this.gbxMotorSettings.Controls.Add(this.tbxStepsPerRotation);
            this.gbxMotorSettings.Controls.Add(this.btnStepsPerRotation);
            this.gbxMotorSettings.Controls.Add(this.lblStepsPer);
            resources.ApplyResources(this.gbxMotorSettings, "gbxMotorSettings");
            this.gbxMotorSettings.Name = "gbxMotorSettings";
            this.gbxMotorSettings.TabStop = false;
            // 
            // chkReversed
            // 
            resources.ApplyResources(this.chkReversed, "chkReversed");
            this.chkReversed.Name = "chkReversed";
            this.chkReversed.UseVisualStyleBackColor = true;
            this.chkReversed.CheckedChanged += new System.EventHandler(this.chkReversed_CheckedChanged);
            // 
            // lblMaxSpeed
            // 
            resources.ApplyResources(this.lblMaxSpeed, "lblMaxSpeed");
            this.lblMaxSpeed.Name = "lblMaxSpeed";
            // 
            // btnMaxSpeed
            // 
            resources.ApplyResources(this.btnMaxSpeed, "btnMaxSpeed");
            this.btnMaxSpeed.Name = "btnMaxSpeed";
            this.btnMaxSpeed.UseVisualStyleBackColor = true;
            this.btnMaxSpeed.Click += new System.EventHandler(this.btnMaxSpeed_Click);
            // 
            // btnAcceleration
            // 
            resources.ApplyResources(this.btnAcceleration, "btnAcceleration");
            this.btnAcceleration.Name = "btnAcceleration";
            this.btnAcceleration.UseVisualStyleBackColor = true;
            this.btnAcceleration.Click += new System.EventHandler(this.btnAcceleration_Click);
            // 
            // lblAcceleration
            // 
            resources.ApplyResources(this.lblAcceleration, "lblAcceleration");
            this.lblAcceleration.Name = "lblAcceleration";
            // 
            // tbxMaxSpeed
            // 
            resources.ApplyResources(this.tbxMaxSpeed, "tbxMaxSpeed");
            this.tbxMaxSpeed.Name = "tbxMaxSpeed";
            // 
            // tbxAcceleration
            // 
            resources.ApplyResources(this.tbxAcceleration, "tbxAcceleration");
            this.tbxAcceleration.Name = "tbxAcceleration";
            // 
            // tbxStepsPerRotation
            // 
            resources.ApplyResources(this.tbxStepsPerRotation, "tbxStepsPerRotation");
            this.tbxStepsPerRotation.Name = "tbxStepsPerRotation";
            // 
            // btnStepsPerRotation
            // 
            resources.ApplyResources(this.btnStepsPerRotation, "btnStepsPerRotation");
            this.btnStepsPerRotation.Name = "btnStepsPerRotation";
            this.btnStepsPerRotation.UseVisualStyleBackColor = true;
            this.btnStepsPerRotation.Click += new System.EventHandler(this.btnStepsPerRotation_Click);
            // 
            // lblStepsPer
            // 
            resources.ApplyResources(this.lblStepsPer, "lblStepsPer");
            this.lblStepsPer.Name = "lblStepsPer";
            // 
            // gbxMovement
            // 
            this.gbxMovement.Controls.Add(this.lblAtPark);
            this.gbxMovement.Controls.Add(this.btnFullTurn);
            this.gbxMovement.Controls.Add(this.lblSeekModeTitle);
            this.gbxMovement.Controls.Add(this.btnSync);
            this.gbxMovement.Controls.Add(this.lblSeekMode);
            this.gbxMovement.Controls.Add(this.btnSTOP);
            this.gbxMovement.Controls.Add(this.btnCalibrate);
            this.gbxMovement.Controls.Add(this.lblMultiStatus);
            this.gbxMovement.Controls.Add(this.btnGoToAz);
            this.gbxMovement.Controls.Add(this.btnRotateCCW);
            this.gbxMovement.Controls.Add(this.btnRotateCW);
            this.gbxMovement.Controls.Add(this.lblHomeStatusTitle);
            this.gbxMovement.Controls.Add(this.btnGoToPos);
            this.gbxMovement.Controls.Add(this.btnHome);
            this.gbxMovement.Controls.Add(this.btnPark);
            this.gbxMovement.Controls.Add(this.lblHomedState);
            this.gbxMovement.Controls.Add(this.lblPosition);
            this.gbxMovement.Controls.Add(this.tbxGotoAz);
            this.gbxMovement.Controls.Add(this.tbxGotoPos);
            this.gbxMovement.Controls.Add(this.lblAzimuth);
            resources.ApplyResources(this.gbxMovement, "gbxMovement");
            this.gbxMovement.Name = "gbxMovement";
            this.gbxMovement.TabStop = false;
            // 
            // lblAtPark
            // 
            this.lblAtPark.BackColor = System.Drawing.Color.LightGreen;
            resources.ApplyResources(this.lblAtPark, "lblAtPark");
            this.lblAtPark.Name = "lblAtPark";
            // 
            // btnFullTurn
            // 
            resources.ApplyResources(this.btnFullTurn, "btnFullTurn");
            this.btnFullTurn.Name = "btnFullTurn";
            this.btnFullTurn.UseVisualStyleBackColor = true;
            this.btnFullTurn.Click += new System.EventHandler(this.btnFullTurn_Click);
            // 
            // lblSeekModeTitle
            // 
            resources.ApplyResources(this.lblSeekModeTitle, "lblSeekModeTitle");
            this.lblSeekModeTitle.Name = "lblSeekModeTitle";
            // 
            // btnSync
            // 
            resources.ApplyResources(this.btnSync, "btnSync");
            this.btnSync.Name = "btnSync";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // lblSeekMode
            // 
            this.lblSeekMode.BackColor = System.Drawing.Color.White;
            this.lblSeekMode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.lblSeekMode, "lblSeekMode");
            this.lblSeekMode.Name = "lblSeekMode";
            // 
            // btnSTOP
            // 
            this.btnSTOP.BackColor = System.Drawing.Color.Red;
            resources.ApplyResources(this.btnSTOP, "btnSTOP");
            this.btnSTOP.Name = "btnSTOP";
            this.btnSTOP.UseVisualStyleBackColor = false;
            this.btnSTOP.Click += new System.EventHandler(this.btnSTOP_Click);
            // 
            // btnCalibrate
            // 
            resources.ApplyResources(this.btnCalibrate, "btnCalibrate");
            this.btnCalibrate.Name = "btnCalibrate";
            this.btnCalibrate.UseVisualStyleBackColor = true;
            this.btnCalibrate.Click += new System.EventHandler(this.btnCalibrate_Click);
            // 
            // lblMultiStatus
            // 
            this.lblMultiStatus.BackColor = System.Drawing.Color.White;
            this.lblMultiStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.lblMultiStatus, "lblMultiStatus");
            this.lblMultiStatus.Name = "lblMultiStatus";
            // 
            // btnGoToAz
            // 
            resources.ApplyResources(this.btnGoToAz, "btnGoToAz");
            this.btnGoToAz.Name = "btnGoToAz";
            this.btnGoToAz.UseVisualStyleBackColor = true;
            this.btnGoToAz.Click += new System.EventHandler(this.btnGotoAz_Click);
            // 
            // btnRotateCCW
            // 
            resources.ApplyResources(this.btnRotateCCW, "btnRotateCCW");
            this.btnRotateCCW.Name = "btnRotateCCW";
            this.btnRotateCCW.UseVisualStyleBackColor = true;
            this.btnRotateCCW.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRotateCCW_MouseDown);
            this.btnRotateCCW.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnRotate_UP);
            // 
            // btnRotateCW
            // 
            resources.ApplyResources(this.btnRotateCW, "btnRotateCW");
            this.btnRotateCW.Name = "btnRotateCW";
            this.btnRotateCW.UseVisualStyleBackColor = true;
            this.btnRotateCW.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRotateCW_MouseDown);
            this.btnRotateCW.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnRotate_UP);
            // 
            // lblHomeStatusTitle
            // 
            resources.ApplyResources(this.lblHomeStatusTitle, "lblHomeStatusTitle");
            this.lblHomeStatusTitle.Name = "lblHomeStatusTitle";
            // 
            // btnGoToPos
            // 
            resources.ApplyResources(this.btnGoToPos, "btnGoToPos");
            this.btnGoToPos.Name = "btnGoToPos";
            this.btnGoToPos.UseVisualStyleBackColor = true;
            this.btnGoToPos.Click += new System.EventHandler(this.btnGoToPos_Click);
            // 
            // btnHome
            // 
            resources.ApplyResources(this.btnHome, "btnHome");
            this.btnHome.Name = "btnHome";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnPark
            // 
            resources.ApplyResources(this.btnPark, "btnPark");
            this.btnPark.Name = "btnPark";
            this.btnPark.UseVisualStyleBackColor = true;
            this.btnPark.Click += new System.EventHandler(this.btnPark_Click);
            // 
            // lblHomedState
            // 
            this.lblHomedState.BackColor = System.Drawing.Color.White;
            this.lblHomedState.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.lblHomedState, "lblHomedState");
            this.lblHomedState.Name = "lblHomedState";
            // 
            // lblPosition
            // 
            this.lblPosition.BackColor = System.Drawing.Color.White;
            this.lblPosition.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.lblPosition, "lblPosition");
            this.lblPosition.Name = "lblPosition";
            // 
            // tbxGotoAz
            // 
            resources.ApplyResources(this.tbxGotoAz, "tbxGotoAz");
            this.tbxGotoAz.Name = "tbxGotoAz";
            // 
            // tbxGotoPos
            // 
            resources.ApplyResources(this.tbxGotoPos, "tbxGotoPos");
            this.tbxGotoPos.Name = "tbxGotoPos";
            // 
            // lblAzimuth
            // 
            this.lblAzimuth.BackColor = System.Drawing.Color.White;
            this.lblAzimuth.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.lblAzimuth, "lblAzimuth");
            this.lblAzimuth.Name = "lblAzimuth";
            // 
            // gbxVoltages
            // 
            this.gbxVoltages.Controls.Add(this.lblLowWarn);
            this.gbxVoltages.Controls.Add(this.tbxCutoff);
            this.gbxVoltages.Controls.Add(this.btnSetCutoff);
            this.gbxVoltages.Controls.Add(this.lblVoltageBox);
            this.gbxVoltages.Controls.Add(this.lblCutOffTitle);
            this.gbxVoltages.Controls.Add(this.lblVoltageTitle);
            resources.ApplyResources(this.gbxVoltages, "gbxVoltages");
            this.gbxVoltages.Name = "gbxVoltages";
            this.gbxVoltages.TabStop = false;
            // 
            // lblLowWarn
            // 
            this.lblLowWarn.BackColor = System.Drawing.Color.Red;
            this.lblLowWarn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLowWarn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.lblLowWarn, "lblLowWarn");
            this.lblLowWarn.Name = "lblLowWarn";
            // 
            // tbxCutoff
            // 
            resources.ApplyResources(this.tbxCutoff, "tbxCutoff");
            this.tbxCutoff.Name = "tbxCutoff";
            // 
            // btnSetCutoff
            // 
            resources.ApplyResources(this.btnSetCutoff, "btnSetCutoff");
            this.btnSetCutoff.Name = "btnSetCutoff";
            this.btnSetCutoff.UseVisualStyleBackColor = true;
            this.btnSetCutoff.Click += new System.EventHandler(this.btnSetCutoff_Click);
            // 
            // lblVoltageBox
            // 
            this.lblVoltageBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lblVoltageBox, "lblVoltageBox");
            this.lblVoltageBox.Name = "lblVoltageBox";
            // 
            // lblCutOffTitle
            // 
            resources.ApplyResources(this.lblCutOffTitle, "lblCutOffTitle");
            this.lblCutOffTitle.Name = "lblCutOffTitle";
            // 
            // lblVoltageTitle
            // 
            resources.ApplyResources(this.lblVoltageTitle, "lblVoltageTitle");
            this.lblVoltageTitle.Name = "lblVoltageTitle";
            // 
            // gbxHomeandPark
            // 
            this.gbxHomeandPark.Controls.Add(this.lblHomePosTitle);
            this.gbxHomeandPark.Controls.Add(this.btnSetHome);
            this.gbxHomeandPark.Controls.Add(this.btnSetPark);
            this.gbxHomeandPark.Controls.Add(this.lblParkPosTitle);
            this.gbxHomeandPark.Controls.Add(this.tbxHomeAz);
            this.gbxHomeandPark.Controls.Add(this.tbxParkAz);
            resources.ApplyResources(this.gbxHomeandPark, "gbxHomeandPark");
            this.gbxHomeandPark.Name = "gbxHomeandPark";
            this.gbxHomeandPark.TabStop = false;
            // 
            // lblHomePosTitle
            // 
            resources.ApplyResources(this.lblHomePosTitle, "lblHomePosTitle");
            this.lblHomePosTitle.Name = "lblHomePosTitle";
            // 
            // btnSetHome
            // 
            resources.ApplyResources(this.btnSetHome, "btnSetHome");
            this.btnSetHome.Name = "btnSetHome";
            this.btnSetHome.UseVisualStyleBackColor = true;
            this.btnSetHome.Click += new System.EventHandler(this.btnSetHome_Click);
            // 
            // btnSetPark
            // 
            resources.ApplyResources(this.btnSetPark, "btnSetPark");
            this.btnSetPark.Name = "btnSetPark";
            this.btnSetPark.UseVisualStyleBackColor = true;
            this.btnSetPark.Click += new System.EventHandler(this.btnSetPark_Click);
            // 
            // lblParkPosTitle
            // 
            resources.ApplyResources(this.lblParkPosTitle, "lblParkPosTitle");
            this.lblParkPosTitle.Name = "lblParkPosTitle";
            // 
            // tbxHomeAz
            // 
            resources.ApplyResources(this.tbxHomeAz, "tbxHomeAz");
            this.tbxHomeAz.Name = "tbxHomeAz";
            // 
            // tbxParkAz
            // 
            resources.ApplyResources(this.tbxParkAz, "tbxParkAz");
            this.tbxParkAz.Name = "tbxParkAz";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // gbxRain
            // 
            this.gbxRain.Controls.Add(this.chkRainRequireTwice);
            this.gbxRain.Controls.Add(this.lblRainInterval);
            this.gbxRain.Controls.Add(this.tbxRainInterval);
            this.gbxRain.Controls.Add(this.lblRainState);
            this.gbxRain.Controls.Add(this.btnSetRainInterval);
            resources.ApplyResources(this.gbxRain, "gbxRain");
            this.gbxRain.Name = "gbxRain";
            this.gbxRain.TabStop = false;
            // 
            // chkRainRequireTwice
            // 
            resources.ApplyResources(this.chkRainRequireTwice, "chkRainRequireTwice");
            this.chkRainRequireTwice.Name = "chkRainRequireTwice";
            this.chkRainRequireTwice.UseVisualStyleBackColor = true;
            // 
            // lblRainInterval
            // 
            resources.ApplyResources(this.lblRainInterval, "lblRainInterval");
            this.lblRainInterval.Name = "lblRainInterval";
            // 
            // tbxRainInterval
            // 
            resources.ApplyResources(this.tbxRainInterval, "tbxRainInterval");
            this.tbxRainInterval.Name = "tbxRainInterval";
            // 
            // lblRainState
            // 
            this.lblRainState.BackColor = System.Drawing.Color.Red;
            this.lblRainState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRainState.ForeColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.lblRainState, "lblRainState");
            this.lblRainState.Name = "lblRainState";
            // 
            // btnSetRainInterval
            // 
            resources.ApplyResources(this.btnSetRainInterval, "btnSetRainInterval");
            this.btnSetRainInterval.Name = "btnSetRainInterval";
            this.btnSetRainInterval.UseVisualStyleBackColor = true;
            this.btnSetRainInterval.Click += new System.EventHandler(this.btnSetRainInterval_Click);
            // 
            // gbxAutoClose
            // 
            this.gbxAutoClose.Controls.Add(this.lblAutoCloseAction);
            this.gbxAutoClose.Controls.Add(this.cbxRainAction);
            resources.ApplyResources(this.gbxAutoClose, "gbxAutoClose");
            this.gbxAutoClose.Name = "gbxAutoClose";
            this.gbxAutoClose.TabStop = false;
            // 
            // lblAutoCloseAction
            // 
            resources.ApplyResources(this.lblAutoCloseAction, "lblAutoCloseAction");
            this.lblAutoCloseAction.Name = "lblAutoCloseAction";
            // 
            // cbxRainAction
            // 
            this.cbxRainAction.FormattingEnabled = true;
            this.cbxRainAction.Items.AddRange(new object[] {
            resources.GetString("cbxRainAction.Items"),
            resources.GetString("cbxRainAction.Items1"),
            resources.GetString("cbxRainAction.Items2")});
            resources.ApplyResources(this.cbxRainAction, "cbxRainAction");
            this.cbxRainAction.Name = "cbxRainAction";
            // 
            // RotatorSetup
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ControlBox = false;
            this.Controls.Add(this.gbxAutoClose);
            this.Controls.Add(this.gbxRain);
            this.Controls.Add(this.gbxHomeandPark);
            this.Controls.Add(this.gbxVoltages);
            this.Controls.Add(this.gbxMovement);
            this.Controls.Add(this.gbxMotorSettings);
            this.Controls.Add(this.btnClose);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "RotatorSetup";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Load += new System.EventHandler(this.RotatorSetup_Load);
            this.gbxMotorSettings.ResumeLayout(false);
            this.gbxMotorSettings.PerformLayout();
            this.gbxMovement.ResumeLayout(false);
            this.gbxMovement.PerformLayout();
            this.gbxVoltages.ResumeLayout(false);
            this.gbxVoltages.PerformLayout();
            this.gbxHomeandPark.ResumeLayout(false);
            this.gbxHomeandPark.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.gbxRain.ResumeLayout(false);
            this.gbxRain.PerformLayout();
            this.gbxAutoClose.ResumeLayout(false);
            this.gbxAutoClose.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox gbxMotorSettings;
        private System.Windows.Forms.CheckBox chkReversed;
        private System.Windows.Forms.Label lblMaxSpeed;
        private System.Windows.Forms.Button btnMaxSpeed;
        private System.Windows.Forms.Button btnAcceleration;
        private System.Windows.Forms.Label lblAcceleration;
        private System.Windows.Forms.TextBox tbxMaxSpeed;
        private System.Windows.Forms.TextBox tbxAcceleration;
        private System.Windows.Forms.TextBox tbxStepsPerRotation;
        private System.Windows.Forms.Button btnStepsPerRotation;
        private System.Windows.Forms.Label lblStepsPer;
        private System.Windows.Forms.GroupBox gbxMovement;
        private System.Windows.Forms.Button btnFullTurn;
        private System.Windows.Forms.Label lblSeekModeTitle;
        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.Label lblSeekMode;
        private System.Windows.Forms.Button btnSTOP;
        private System.Windows.Forms.Button btnCalibrate;
        private System.Windows.Forms.Label lblMultiStatus;
        private System.Windows.Forms.Button btnGoToAz;
        private System.Windows.Forms.Button btnRotateCCW;
        private System.Windows.Forms.Button btnRotateCW;
        private System.Windows.Forms.Label lblHomeStatusTitle;
        private System.Windows.Forms.Button btnGoToPos;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnPark;
        private System.Windows.Forms.Label lblHomedState;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.TextBox tbxGotoAz;
        private System.Windows.Forms.TextBox tbxGotoPos;
        private System.Windows.Forms.Label lblAzimuth;
        private System.Windows.Forms.GroupBox gbxVoltages;
        private System.Windows.Forms.Label lblCutOffTitle;
        private System.Windows.Forms.Label lblVoltageTitle;
        private System.Windows.Forms.GroupBox gbxHomeandPark;
        private System.Windows.Forms.Label lblHomePosTitle;
        private System.Windows.Forms.Button btnSetHome;
        private System.Windows.Forms.Button btnSetPark;
        private System.Windows.Forms.Label lblParkPosTitle;
        private System.Windows.Forms.TextBox tbxHomeAz;
        private System.Windows.Forms.TextBox tbxParkAz;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnSetCutoff;
        private System.Windows.Forms.Label lblVoltageBox;
        private System.Windows.Forms.TextBox tbxCutoff;
        private System.Windows.Forms.Label lblLowWarn;
        private System.Windows.Forms.Label lblAtPark;
        private System.Windows.Forms.GroupBox gbxRain;
        private System.Windows.Forms.CheckBox chkRainRequireTwice;
        private System.Windows.Forms.Label lblRainInterval;
        private System.Windows.Forms.TextBox tbxRainInterval;
        private System.Windows.Forms.Label lblRainState;
        private System.Windows.Forms.Button btnSetRainInterval;
        private System.Windows.Forms.GroupBox gbxAutoClose;
        private System.Windows.Forms.Label lblAutoCloseAction;
        private System.Windows.Forms.ComboBox cbxRainAction;
    }
}