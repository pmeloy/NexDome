namespace ASCOM.PDM
{
    partial class ShutterSetup
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
            this.gbxVoltages = new System.Windows.Forms.GroupBox();
            this.lblLowWarn = new System.Windows.Forms.Label();
            this.tbxCutoff = new System.Windows.Forms.TextBox();
            this.btnSetCutoff = new System.Windows.Forms.Button();
            this.lblVoltage = new System.Windows.Forms.Label();
            this.lblCutOffTitle = new System.Windows.Forms.Label();
            this.lblVoltageTitle = new System.Windows.Forms.Label();
            this.gbxMotorSettings = new System.Windows.Forms.GroupBox();
            this.chkReversed = new System.Windows.Forms.CheckBox();
            this.lblMaxSpeedTitle = new System.Windows.Forms.Label();
            this.btnMaxSpeed = new System.Windows.Forms.Button();
            this.btnAcceleration = new System.Windows.Forms.Button();
            this.lblAccelerationTitle = new System.Windows.Forms.Label();
            this.tbxMaxSpeed = new System.Windows.Forms.TextBox();
            this.tbxAcceleration = new System.Windows.Forms.TextBox();
            this.tbxStepsPerRotation = new System.Windows.Forms.TextBox();
            this.btnStepsPerRotation = new System.Windows.Forms.Button();
            this.lblStepsPerTitle = new System.Windows.Forms.Label();
            this.gbxMovement = new System.Windows.Forms.GroupBox();
            this.lblRainWarn = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblAltitude = new System.Windows.Forms.Label();
            this.btnSTOP = new System.Windows.Forms.Button();
            this.btnCloseShutter = new System.Windows.Forms.Button();
            this.btnOpenShutter = new System.Windows.Forms.Button();
            this.btnCloseForm = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.gbxVoltages.SuspendLayout();
            this.gbxMotorSettings.SuspendLayout();
            this.gbxMovement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxVoltages
            // 
            this.gbxVoltages.Controls.Add(this.lblLowWarn);
            this.gbxVoltages.Controls.Add(this.tbxCutoff);
            this.gbxVoltages.Controls.Add(this.btnSetCutoff);
            this.gbxVoltages.Controls.Add(this.lblVoltage);
            this.gbxVoltages.Controls.Add(this.lblCutOffTitle);
            this.gbxVoltages.Controls.Add(this.lblVoltageTitle);
            this.gbxVoltages.Location = new System.Drawing.Point(12, 12);
            this.gbxVoltages.Name = "gbxVoltages";
            this.gbxVoltages.Size = new System.Drawing.Size(179, 71);
            this.gbxVoltages.TabIndex = 51;
            this.gbxVoltages.TabStop = false;
            this.gbxVoltages.Text = "Voltage";
            // 
            // lblLowWarn
            // 
            this.lblLowWarn.BackColor = System.Drawing.Color.Red;
            this.lblLowWarn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLowWarn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblLowWarn.Location = new System.Drawing.Point(112, 18);
            this.lblLowWarn.Name = "lblLowWarn";
            this.lblLowWarn.Size = new System.Drawing.Size(61, 19);
            this.lblLowWarn.TabIndex = 48;
            this.lblLowWarn.Text = "LOW";
            this.lblLowWarn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLowWarn.Visible = false;
            // 
            // tbxCutoff
            // 
            this.tbxCutoff.Location = new System.Drawing.Point(55, 43);
            this.tbxCutoff.Name = "tbxCutoff";
            this.tbxCutoff.Size = new System.Drawing.Size(51, 20);
            this.tbxCutoff.TabIndex = 43;
            this.tbxCutoff.Text = "0";
            this.tbxCutoff.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnSetCutoff
            // 
            this.btnSetCutoff.Location = new System.Drawing.Point(112, 41);
            this.btnSetCutoff.Name = "btnSetCutoff";
            this.btnSetCutoff.Size = new System.Drawing.Size(61, 23);
            this.btnSetCutoff.TabIndex = 43;
            this.btnSetCutoff.Text = "Set";
            this.btnSetCutoff.UseVisualStyleBackColor = true;
            this.btnSetCutoff.Click += new System.EventHandler(this.btnSetCutoff_Click);
            // 
            // lblVoltage
            // 
            this.lblVoltage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblVoltage.Location = new System.Drawing.Point(55, 18);
            this.lblVoltage.Name = "lblVoltage";
            this.lblVoltage.Size = new System.Drawing.Size(51, 19);
            this.lblVoltage.TabIndex = 47;
            this.lblVoltage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblCutOffTitle
            // 
            this.lblCutOffTitle.AutoSize = true;
            this.lblCutOffTitle.Location = new System.Drawing.Point(6, 46);
            this.lblCutOffTitle.Name = "lblCutOffTitle";
            this.lblCutOffTitle.Size = new System.Drawing.Size(37, 13);
            this.lblCutOffTitle.TabIndex = 46;
            this.lblCutOffTitle.Text = "CutOff";
            // 
            // lblVoltageTitle
            // 
            this.lblVoltageTitle.AutoSize = true;
            this.lblVoltageTitle.Location = new System.Drawing.Point(6, 19);
            this.lblVoltageTitle.Name = "lblVoltageTitle";
            this.lblVoltageTitle.Size = new System.Drawing.Size(43, 13);
            this.lblVoltageTitle.TabIndex = 45;
            this.lblVoltageTitle.Text = "Voltage";
            // 
            // gbxMotorSettings
            // 
            this.gbxMotorSettings.Controls.Add(this.chkReversed);
            this.gbxMotorSettings.Controls.Add(this.lblMaxSpeedTitle);
            this.gbxMotorSettings.Controls.Add(this.btnMaxSpeed);
            this.gbxMotorSettings.Controls.Add(this.btnAcceleration);
            this.gbxMotorSettings.Controls.Add(this.lblAccelerationTitle);
            this.gbxMotorSettings.Controls.Add(this.tbxMaxSpeed);
            this.gbxMotorSettings.Controls.Add(this.tbxAcceleration);
            this.gbxMotorSettings.Controls.Add(this.tbxStepsPerRotation);
            this.gbxMotorSettings.Controls.Add(this.btnStepsPerRotation);
            this.gbxMotorSettings.Controls.Add(this.lblStepsPerTitle);
            this.gbxMotorSettings.Location = new System.Drawing.Point(12, 89);
            this.gbxMotorSettings.Name = "gbxMotorSettings";
            this.gbxMotorSettings.Size = new System.Drawing.Size(179, 167);
            this.gbxMotorSettings.TabIndex = 50;
            this.gbxMotorSettings.TabStop = false;
            this.gbxMotorSettings.Text = "Motor Settings";
            // 
            // chkReversed
            // 
            this.chkReversed.AutoSize = true;
            this.chkReversed.Location = new System.Drawing.Point(6, 142);
            this.chkReversed.Name = "chkReversed";
            this.chkReversed.Size = new System.Drawing.Size(72, 17);
            this.chkReversed.TabIndex = 42;
            this.chkReversed.Text = "Reversed";
            this.chkReversed.UseVisualStyleBackColor = true;
            this.chkReversed.CheckedChanged += new System.EventHandler(this.chkReversed_CheckedChanged);
            // 
            // lblMaxSpeedTitle
            // 
            this.lblMaxSpeedTitle.AutoSize = true;
            this.lblMaxSpeedTitle.Location = new System.Drawing.Point(6, 20);
            this.lblMaxSpeedTitle.Name = "lblMaxSpeedTitle";
            this.lblMaxSpeedTitle.Size = new System.Drawing.Size(61, 13);
            this.lblMaxSpeedTitle.TabIndex = 34;
            this.lblMaxSpeedTitle.Text = "Max Speed";
            // 
            // btnMaxSpeed
            // 
            this.btnMaxSpeed.Location = new System.Drawing.Point(108, 34);
            this.btnMaxSpeed.Name = "btnMaxSpeed";
            this.btnMaxSpeed.Size = new System.Drawing.Size(65, 23);
            this.btnMaxSpeed.TabIndex = 33;
            this.btnMaxSpeed.Text = "Set";
            this.btnMaxSpeed.UseVisualStyleBackColor = true;
            this.btnMaxSpeed.Click += new System.EventHandler(this.btnMaxSpeed_Click);
            // 
            // btnAcceleration
            // 
            this.btnAcceleration.Location = new System.Drawing.Point(108, 73);
            this.btnAcceleration.Name = "btnAcceleration";
            this.btnAcceleration.Size = new System.Drawing.Size(65, 23);
            this.btnAcceleration.TabIndex = 36;
            this.btnAcceleration.Text = "Set";
            this.btnAcceleration.UseVisualStyleBackColor = true;
            this.btnAcceleration.Click += new System.EventHandler(this.btnAcceleration_Click);
            // 
            // lblAccelerationTitle
            // 
            this.lblAccelerationTitle.AutoSize = true;
            this.lblAccelerationTitle.Location = new System.Drawing.Point(6, 59);
            this.lblAccelerationTitle.Name = "lblAccelerationTitle";
            this.lblAccelerationTitle.Size = new System.Drawing.Size(66, 13);
            this.lblAccelerationTitle.TabIndex = 37;
            this.lblAccelerationTitle.Text = "Acceleration";
            // 
            // tbxMaxSpeed
            // 
            this.tbxMaxSpeed.Location = new System.Drawing.Point(6, 36);
            this.tbxMaxSpeed.Name = "tbxMaxSpeed";
            this.tbxMaxSpeed.Size = new System.Drawing.Size(72, 20);
            this.tbxMaxSpeed.TabIndex = 35;
            this.tbxMaxSpeed.Text = "0";
            // 
            // tbxAcceleration
            // 
            this.tbxAcceleration.Location = new System.Drawing.Point(6, 75);
            this.tbxAcceleration.Name = "tbxAcceleration";
            this.tbxAcceleration.Size = new System.Drawing.Size(72, 20);
            this.tbxAcceleration.TabIndex = 38;
            this.tbxAcceleration.Text = "0";
            // 
            // tbxStepsPerRotation
            // 
            this.tbxStepsPerRotation.Location = new System.Drawing.Point(6, 114);
            this.tbxStepsPerRotation.Name = "tbxStepsPerRotation";
            this.tbxStepsPerRotation.Size = new System.Drawing.Size(72, 20);
            this.tbxStepsPerRotation.TabIndex = 41;
            this.tbxStepsPerRotation.Text = "0";
            // 
            // btnStepsPerRotation
            // 
            this.btnStepsPerRotation.Location = new System.Drawing.Point(108, 112);
            this.btnStepsPerRotation.Name = "btnStepsPerRotation";
            this.btnStepsPerRotation.Size = new System.Drawing.Size(65, 23);
            this.btnStepsPerRotation.TabIndex = 39;
            this.btnStepsPerRotation.Text = "Set";
            this.btnStepsPerRotation.UseVisualStyleBackColor = true;
            this.btnStepsPerRotation.Click += new System.EventHandler(this.btnStepsPerRotation_Click);
            // 
            // lblStepsPerTitle
            // 
            this.lblStepsPerTitle.AutoSize = true;
            this.lblStepsPerTitle.Location = new System.Drawing.Point(6, 98);
            this.lblStepsPerTitle.Name = "lblStepsPerTitle";
            this.lblStepsPerTitle.Size = new System.Drawing.Size(52, 13);
            this.lblStepsPerTitle.TabIndex = 40;
            this.lblStepsPerTitle.Text = "Steps per";
            // 
            // gbxMovement
            // 
            this.gbxMovement.Controls.Add(this.lblRainWarn);
            this.gbxMovement.Controls.Add(this.lblStatus);
            this.gbxMovement.Controls.Add(this.lblAltitude);
            this.gbxMovement.Controls.Add(this.btnSTOP);
            this.gbxMovement.Controls.Add(this.btnCloseShutter);
            this.gbxMovement.Controls.Add(this.btnOpenShutter);
            this.gbxMovement.Location = new System.Drawing.Point(210, 12);
            this.gbxMovement.Name = "gbxMovement";
            this.gbxMovement.Size = new System.Drawing.Size(134, 210);
            this.gbxMovement.TabIndex = 52;
            this.gbxMovement.TabStop = false;
            this.gbxMovement.Text = "Movement";
            // 
            // lblRainWarn
            // 
            this.lblRainWarn.BackColor = System.Drawing.Color.Red;
            this.lblRainWarn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRainWarn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblRainWarn.Location = new System.Drawing.Point(30, 16);
            this.lblRainWarn.Name = "lblRainWarn";
            this.lblRainWarn.Size = new System.Drawing.Size(75, 19);
            this.lblRainWarn.TabIndex = 50;
            this.lblRainWarn.Text = "RAIN";
            this.lblRainWarn.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblStatus
            // 
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.Location = new System.Drawing.Point(30, 73);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(75, 19);
            this.lblStatus.TabIndex = 49;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAltitude
            // 
            this.lblAltitude.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAltitude.Location = new System.Drawing.Point(42, 99);
            this.lblAltitude.Name = "lblAltitude";
            this.lblAltitude.Size = new System.Drawing.Size(51, 19);
            this.lblAltitude.TabIndex = 48;
            this.lblAltitude.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSTOP
            // 
            this.btnSTOP.BackColor = System.Drawing.Color.Red;
            this.btnSTOP.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSTOP.Location = new System.Drawing.Point(6, 150);
            this.btnSTOP.Name = "btnSTOP";
            this.btnSTOP.Size = new System.Drawing.Size(122, 51);
            this.btnSTOP.TabIndex = 32;
            this.btnSTOP.Text = "STOP";
            this.btnSTOP.UseVisualStyleBackColor = false;
            this.btnSTOP.Click += new System.EventHandler(this.btnSTOP_Click);
            // 
            // btnCloseShutter
            // 
            this.btnCloseShutter.Location = new System.Drawing.Point(30, 121);
            this.btnCloseShutter.Name = "btnCloseShutter";
            this.btnCloseShutter.Size = new System.Drawing.Size(75, 23);
            this.btnCloseShutter.TabIndex = 2;
            this.btnCloseShutter.Text = "Close";
            this.btnCloseShutter.UseVisualStyleBackColor = true;
            this.btnCloseShutter.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOpenShutter
            // 
            this.btnOpenShutter.Location = new System.Drawing.Point(30, 47);
            this.btnOpenShutter.Name = "btnOpenShutter";
            this.btnOpenShutter.Size = new System.Drawing.Size(75, 23);
            this.btnOpenShutter.TabIndex = 0;
            this.btnOpenShutter.Text = "Open";
            this.btnOpenShutter.UseVisualStyleBackColor = true;
            this.btnOpenShutter.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnCloseForm
            // 
            this.btnCloseForm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseForm.Location = new System.Drawing.Point(269, 232);
            this.btnCloseForm.Name = "btnCloseForm";
            this.btnCloseForm.Size = new System.Drawing.Size(75, 23);
            this.btnCloseForm.TabIndex = 49;
            this.btnCloseForm.Text = "Close";
            this.btnCloseForm.UseVisualStyleBackColor = true;
            this.btnCloseForm.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick_1);
            // 
            // ShutterSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(356, 267);
            this.ControlBox = false;
            this.Controls.Add(this.btnCloseForm);
            this.Controls.Add(this.gbxMovement);
            this.Controls.Add(this.gbxVoltages);
            this.Controls.Add(this.gbxMotorSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ShutterSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ShutterSetup";
            this.Load += new System.EventHandler(this.ShutterSetup_Load);
            this.gbxVoltages.ResumeLayout(false);
            this.gbxVoltages.PerformLayout();
            this.gbxMotorSettings.ResumeLayout(false);
            this.gbxMotorSettings.PerformLayout();
            this.gbxMovement.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxVoltages;
        private System.Windows.Forms.Label lblLowWarn;
        private System.Windows.Forms.TextBox tbxCutoff;
        private System.Windows.Forms.Button btnSetCutoff;
        private System.Windows.Forms.Label lblVoltage;
        private System.Windows.Forms.Label lblCutOffTitle;
        private System.Windows.Forms.Label lblVoltageTitle;
        private System.Windows.Forms.GroupBox gbxMotorSettings;
        private System.Windows.Forms.CheckBox chkReversed;
        private System.Windows.Forms.Label lblMaxSpeedTitle;
        private System.Windows.Forms.Button btnMaxSpeed;
        private System.Windows.Forms.Button btnAcceleration;
        private System.Windows.Forms.Label lblAccelerationTitle;
        private System.Windows.Forms.TextBox tbxMaxSpeed;
        private System.Windows.Forms.TextBox tbxAcceleration;
        private System.Windows.Forms.TextBox tbxStepsPerRotation;
        private System.Windows.Forms.Button btnStepsPerRotation;
        private System.Windows.Forms.Label lblStepsPerTitle;
        private System.Windows.Forms.GroupBox gbxMovement;
        private System.Windows.Forms.Button btnCloseShutter;
        private System.Windows.Forms.Button btnOpenShutter;
        private System.Windows.Forms.Label lblAltitude;
        private System.Windows.Forms.Button btnSTOP;
        private System.Windows.Forms.Button btnCloseForm;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Label lblRainWarn;
    }
}