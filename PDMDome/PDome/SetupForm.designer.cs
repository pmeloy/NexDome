namespace ASCOM.PDome
{
    partial class SetupForm
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
            this.cmdOK = new System.Windows.Forms.Button();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.picASCOM = new System.Windows.Forms.PictureBox();
            this.gbRotatorVersion = new System.Windows.Forms.GroupBox();
            this.lblRotatorStepPos = new System.Windows.Forms.Label();
            this.lblRotatorHeading = new System.Windows.Forms.Label();
            this.lblRotatorSeekMode = new System.Windows.Forms.Label();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnCalibrateRotator = new System.Windows.Forms.Button();
            this.chkRotatorReversed = new System.Windows.Forms.CheckBox();
            this.lblHomeStatus = new System.Windows.Forms.Label();
            this.lblRotatorVolts = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxRotatorCutOff = new System.Windows.Forms.TextBox();
            this.tbxRotatorHomePos = new System.Windows.Forms.TextBox();
            this.tbxRotatorParkPos = new System.Windows.Forms.TextBox();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.gbShutterVersion = new System.Windows.Forms.GroupBox();
            this.btnCloseShutter = new System.Windows.Forms.Button();
            this.lblShutterStepPos = new System.Windows.Forms.Label();
            this.lblShutterElevation = new System.Windows.Forms.Label();
            this.lblShutterState = new System.Windows.Forms.Label();
            this.btnOpenShutter = new System.Windows.Forms.Button();
            this.chkShutterReversed = new System.Windows.Forms.CheckBox();
            this.lblShutterVolts = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblMinElevation = new System.Windows.Forms.Label();
            this.tbxShutterCutOff = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.chkCanSlave = new System.Windows.Forms.CheckBox();
            this.chkCanFindHome = new System.Windows.Forms.CheckBox();
            this.chkCanSetShutter = new System.Windows.Forms.CheckBox();
            this.chkCanSetAltitude = new System.Windows.Forms.CheckBox();
            this.chkCanPark = new System.Windows.Forms.CheckBox();
            this.chkCanSetPark = new System.Windows.Forms.CheckBox();
            this.chkCanSyncAz = new System.Windows.Forms.CheckBox();
            this.chkCanSetAzimuth = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbxRotatorStepsPer = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxRainCheckPeriod = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbxRotatorStepRate = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbxRotatorAcceleration = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gbShutterSettings = new System.Windows.Forms.GroupBox();
            this.tbxShutterStepsPer = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tbxShutterInactive = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.chkShutterSleepEnabled = new System.Windows.Forms.CheckBox();
            this.tbxShutterSleepDelay = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbxShutterSleepPeriod = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbxShutterStepRate = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbxShutterAcceleration = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblMaxElevation = new System.Windows.Forms.Label();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).BeginInit();
            this.gbRotatorVersion.SuspendLayout();
            this.gbShutterVersion.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbShutterSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // cmdOK
            // 
            this.cmdOK.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cmdOK.CausesValidation = false;
            this.cmdOK.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdOK.Location = new System.Drawing.Point(437, 405);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(59, 24);
            this.cmdOK.TabIndex = 0;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = false;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // cmdCancel
            // 
            this.cmdCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cmdCancel.Location = new System.Drawing.Point(502, 405);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(59, 24);
            this.cmdCancel.TabIndex = 1;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = false;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // picASCOM
            // 
            this.picASCOM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picASCOM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picASCOM.Image = global::ASCOM.PDome.Properties.Resources.ASCOM;
            this.picASCOM.Location = new System.Drawing.Point(518, 12);
            this.picASCOM.Name = "picASCOM";
            this.picASCOM.Size = new System.Drawing.Size(48, 56);
            this.picASCOM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picASCOM.TabIndex = 3;
            this.picASCOM.TabStop = false;
            this.picASCOM.Click += new System.EventHandler(this.BrowseToAscom);
            this.picASCOM.DoubleClick += new System.EventHandler(this.BrowseToAscom);
            // 
            // gbRotatorVersion
            // 
            this.gbRotatorVersion.Controls.Add(this.lblRotatorStepPos);
            this.gbRotatorVersion.Controls.Add(this.lblRotatorHeading);
            this.gbRotatorVersion.Controls.Add(this.lblRotatorSeekMode);
            this.gbRotatorVersion.Controls.Add(this.btnHome);
            this.gbRotatorVersion.Controls.Add(this.btnCalibrateRotator);
            this.gbRotatorVersion.Controls.Add(this.chkRotatorReversed);
            this.gbRotatorVersion.Controls.Add(this.lblHomeStatus);
            this.gbRotatorVersion.Controls.Add(this.lblRotatorVolts);
            this.gbRotatorVersion.Controls.Add(this.label7);
            this.gbRotatorVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRotatorVersion.ForeColor = System.Drawing.Color.White;
            this.gbRotatorVersion.Location = new System.Drawing.Point(12, 12);
            this.gbRotatorVersion.Name = "gbRotatorVersion";
            this.gbRotatorVersion.Size = new System.Drawing.Size(235, 127);
            this.gbRotatorVersion.TabIndex = 4;
            this.gbRotatorVersion.TabStop = false;
            this.gbRotatorVersion.Text = "Rotator";
            // 
            // lblRotatorStepPos
            // 
            this.lblRotatorStepPos.BackColor = System.Drawing.Color.Black;
            this.lblRotatorStepPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRotatorStepPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRotatorStepPos.ForeColor = System.Drawing.Color.White;
            this.lblRotatorStepPos.Location = new System.Drawing.Point(135, 96);
            this.lblRotatorStepPos.Name = "lblRotatorStepPos";
            this.lblRotatorStepPos.Size = new System.Drawing.Size(68, 23);
            this.lblRotatorStepPos.TabIndex = 12;
            this.lblRotatorStepPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRotatorHeading
            // 
            this.lblRotatorHeading.BackColor = System.Drawing.Color.Black;
            this.lblRotatorHeading.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRotatorHeading.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRotatorHeading.ForeColor = System.Drawing.Color.White;
            this.lblRotatorHeading.Location = new System.Drawing.Point(30, 96);
            this.lblRotatorHeading.Name = "lblRotatorHeading";
            this.lblRotatorHeading.Size = new System.Drawing.Size(68, 23);
            this.lblRotatorHeading.TabIndex = 11;
            this.lblRotatorHeading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRotatorSeekMode
            // 
            this.lblRotatorSeekMode.BackColor = System.Drawing.Color.Black;
            this.lblRotatorSeekMode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRotatorSeekMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRotatorSeekMode.ForeColor = System.Drawing.Color.White;
            this.lblRotatorSeekMode.Location = new System.Drawing.Point(120, 67);
            this.lblRotatorSeekMode.Name = "lblRotatorSeekMode";
            this.lblRotatorSeekMode.Size = new System.Drawing.Size(99, 23);
            this.lblRotatorSeekMode.TabIndex = 10;
            this.lblRotatorSeekMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnHome.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHome.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnHome.Location = new System.Drawing.Point(15, 39);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(99, 23);
            this.btnHome.TabIndex = 7;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = false;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnCalibrateRotator
            // 
            this.btnCalibrateRotator.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCalibrateRotator.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalibrateRotator.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCalibrateRotator.Location = new System.Drawing.Point(120, 39);
            this.btnCalibrateRotator.Name = "btnCalibrateRotator";
            this.btnCalibrateRotator.Size = new System.Drawing.Size(99, 23);
            this.btnCalibrateRotator.TabIndex = 8;
            this.btnCalibrateRotator.Text = "Calibrate";
            this.btnCalibrateRotator.UseVisualStyleBackColor = false;
            this.btnCalibrateRotator.Click += new System.EventHandler(this.btnCalibrateRotator_Click);
            // 
            // chkRotatorReversed
            // 
            this.chkRotatorReversed.AutoSize = true;
            this.chkRotatorReversed.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRotatorReversed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRotatorReversed.ForeColor = System.Drawing.Color.White;
            this.chkRotatorReversed.Location = new System.Drawing.Point(140, 19);
            this.chkRotatorReversed.Name = "chkRotatorReversed";
            this.chkRotatorReversed.Size = new System.Drawing.Size(72, 17);
            this.chkRotatorReversed.TabIndex = 8;
            this.chkRotatorReversed.Text = "Reversed";
            this.toolTip1.SetToolTip(this.chkRotatorReversed, "Set rotator motor direction");
            this.chkRotatorReversed.UseVisualStyleBackColor = true;
            // 
            // lblHomeStatus
            // 
            this.lblHomeStatus.BackColor = System.Drawing.Color.Black;
            this.lblHomeStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblHomeStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHomeStatus.ForeColor = System.Drawing.Color.White;
            this.lblHomeStatus.Location = new System.Drawing.Point(15, 67);
            this.lblHomeStatus.Name = "lblHomeStatus";
            this.lblHomeStatus.Size = new System.Drawing.Size(99, 23);
            this.lblHomeStatus.TabIndex = 9;
            this.lblHomeStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblRotatorVolts
            // 
            this.lblRotatorVolts.BackColor = System.Drawing.Color.Black;
            this.lblRotatorVolts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRotatorVolts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRotatorVolts.ForeColor = System.Drawing.Color.White;
            this.lblRotatorVolts.Location = new System.Drawing.Point(51, 16);
            this.lblRotatorVolts.Name = "lblRotatorVolts";
            this.lblRotatorVolts.Size = new System.Drawing.Size(63, 20);
            this.lblRotatorVolts.TabIndex = 7;
            this.lblRotatorVolts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(15, 20);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(30, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Volts";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Park Pos";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(6, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Low Cutoff";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Home Pos";
            // 
            // tbxRotatorCutOff
            // 
            this.tbxRotatorCutOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxRotatorCutOff.Location = new System.Drawing.Point(78, 19);
            this.tbxRotatorCutOff.Name = "tbxRotatorCutOff";
            this.tbxRotatorCutOff.Size = new System.Drawing.Size(55, 20);
            this.tbxRotatorCutOff.TabIndex = 20;
            this.tbxRotatorCutOff.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.tbxRotatorCutOff, "Below this voltage the dome will not move");
            this.tbxRotatorCutOff.Validating += new System.ComponentModel.CancelEventHandler(this.Double_Validation);
            // 
            // tbxRotatorHomePos
            // 
            this.tbxRotatorHomePos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxRotatorHomePos.Location = new System.Drawing.Point(78, 45);
            this.tbxRotatorHomePos.Name = "tbxRotatorHomePos";
            this.tbxRotatorHomePos.Size = new System.Drawing.Size(55, 20);
            this.tbxRotatorHomePos.TabIndex = 21;
            this.tbxRotatorHomePos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.tbxRotatorHomePos, "Home position, 0 - 359.99 degrees");
            this.tbxRotatorHomePos.Validating += new System.ComponentModel.CancelEventHandler(this.Double_Validation);
            // 
            // tbxRotatorParkPos
            // 
            this.tbxRotatorParkPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxRotatorParkPos.Location = new System.Drawing.Point(78, 71);
            this.tbxRotatorParkPos.Name = "tbxRotatorParkPos";
            this.tbxRotatorParkPos.Size = new System.Drawing.Size(55, 20);
            this.tbxRotatorParkPos.TabIndex = 22;
            this.tbxRotatorParkPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.tbxRotatorParkPos, "Park position, 0 - 359.99 degrees");
            this.tbxRotatorParkPos.Validating += new System.ComponentModel.CancelEventHandler(this.Double_Validation);
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Enabled = true;
            this.UpdateTimer.Interval = 1000;
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // gbShutterVersion
            // 
            this.gbShutterVersion.Controls.Add(this.btnCloseShutter);
            this.gbShutterVersion.Controls.Add(this.lblShutterStepPos);
            this.gbShutterVersion.Controls.Add(this.lblShutterElevation);
            this.gbShutterVersion.Controls.Add(this.lblShutterState);
            this.gbShutterVersion.Controls.Add(this.btnOpenShutter);
            this.gbShutterVersion.Controls.Add(this.chkShutterReversed);
            this.gbShutterVersion.Controls.Add(this.lblShutterVolts);
            this.gbShutterVersion.Controls.Add(this.label6);
            this.gbShutterVersion.Enabled = false;
            this.gbShutterVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbShutterVersion.ForeColor = System.Drawing.Color.White;
            this.gbShutterVersion.Location = new System.Drawing.Point(12, 145);
            this.gbShutterVersion.Name = "gbShutterVersion";
            this.gbShutterVersion.Size = new System.Drawing.Size(235, 103);
            this.gbShutterVersion.TabIndex = 5;
            this.gbShutterVersion.TabStop = false;
            this.gbShutterVersion.Text = "Shutter";
            this.toolTip1.SetToolTip(this.gbShutterVersion, "Set shutter motor direction");
            // 
            // btnCloseShutter
            // 
            this.btnCloseShutter.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnCloseShutter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseShutter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCloseShutter.Location = new System.Drawing.Point(111, 39);
            this.btnCloseShutter.Name = "btnCloseShutter";
            this.btnCloseShutter.Size = new System.Drawing.Size(99, 23);
            this.btnCloseShutter.TabIndex = 13;
            this.btnCloseShutter.Text = "Close";
            this.btnCloseShutter.UseVisualStyleBackColor = false;
            this.btnCloseShutter.Click += new System.EventHandler(this.btnCloseShutter_Click);
            // 
            // lblShutterStepPos
            // 
            this.lblShutterStepPos.BackColor = System.Drawing.Color.Black;
            this.lblShutterStepPos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShutterStepPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShutterStepPos.Location = new System.Drawing.Point(154, 70);
            this.lblShutterStepPos.Name = "lblShutterStepPos";
            this.lblShutterStepPos.Size = new System.Drawing.Size(56, 23);
            this.lblShutterStepPos.TabIndex = 15;
            this.lblShutterStepPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblShutterElevation
            // 
            this.lblShutterElevation.BackColor = System.Drawing.Color.Black;
            this.lblShutterElevation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShutterElevation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShutterElevation.Location = new System.Drawing.Point(97, 70);
            this.lblShutterElevation.Name = "lblShutterElevation";
            this.lblShutterElevation.Size = new System.Drawing.Size(51, 23);
            this.lblShutterElevation.TabIndex = 14;
            this.lblShutterElevation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblShutterState
            // 
            this.lblShutterState.BackColor = System.Drawing.Color.Black;
            this.lblShutterState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShutterState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShutterState.ForeColor = System.Drawing.Color.White;
            this.lblShutterState.Location = new System.Drawing.Point(6, 70);
            this.lblShutterState.Name = "lblShutterState";
            this.lblShutterState.Size = new System.Drawing.Size(85, 23);
            this.lblShutterState.TabIndex = 13;
            this.lblShutterState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOpenShutter
            // 
            this.btnOpenShutter.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnOpenShutter.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenShutter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnOpenShutter.Location = new System.Drawing.Point(6, 39);
            this.btnOpenShutter.Name = "btnOpenShutter";
            this.btnOpenShutter.Size = new System.Drawing.Size(99, 23);
            this.btnOpenShutter.TabIndex = 12;
            this.btnOpenShutter.Text = "Open";
            this.btnOpenShutter.UseVisualStyleBackColor = false;
            this.btnOpenShutter.Click += new System.EventHandler(this.btnOpenShutter_Click);
            // 
            // chkShutterReversed
            // 
            this.chkShutterReversed.AutoSize = true;
            this.chkShutterReversed.BackColor = System.Drawing.Color.Black;
            this.chkShutterReversed.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkShutterReversed.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkShutterReversed.Location = new System.Drawing.Point(131, 20);
            this.chkShutterReversed.Name = "chkShutterReversed";
            this.chkShutterReversed.Size = new System.Drawing.Size(72, 17);
            this.chkShutterReversed.TabIndex = 11;
            this.chkShutterReversed.Text = "Reversed";
            this.chkShutterReversed.UseVisualStyleBackColor = false;
            // 
            // lblShutterVolts
            // 
            this.lblShutterVolts.BackColor = System.Drawing.Color.Black;
            this.lblShutterVolts.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShutterVolts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShutterVolts.Location = new System.Drawing.Point(42, 16);
            this.lblShutterVolts.Name = "lblShutterVolts";
            this.lblShutterVolts.Size = new System.Drawing.Size(63, 20);
            this.lblShutterVolts.TabIndex = 7;
            this.lblShutterVolts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(6, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(30, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Volts";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(6, 74);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(51, 13);
            this.label8.TabIndex = 4;
            this.label8.Text = "Min Elev.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(6, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(54, 13);
            this.label12.TabIndex = 2;
            this.label12.Text = "Max Elev.";
            // 
            // lblMinElevation
            // 
            this.lblMinElevation.BackColor = System.Drawing.Color.Black;
            this.lblMinElevation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMinElevation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMinElevation.ForeColor = System.Drawing.Color.White;
            this.lblMinElevation.Location = new System.Drawing.Point(78, 70);
            this.lblMinElevation.Name = "lblMinElevation";
            this.lblMinElevation.Size = new System.Drawing.Size(55, 20);
            this.lblMinElevation.TabIndex = 18;
            this.lblMinElevation.Text = "0.00";
            this.lblMinElevation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.lblMinElevation, "Future property");
            // 
            // tbxShutterCutOff
            // 
            this.tbxShutterCutOff.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxShutterCutOff.Location = new System.Drawing.Point(78, 19);
            this.tbxShutterCutOff.Name = "tbxShutterCutOff";
            this.tbxShutterCutOff.Size = new System.Drawing.Size(55, 20);
            this.tbxShutterCutOff.TabIndex = 19;
            this.tbxShutterCutOff.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.tbxShutterCutOff, "Below this voltage the shutter will not move");
            this.tbxShutterCutOff.Validating += new System.ComponentModel.CancelEventHandler(this.Double_Validation);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkCanSlave);
            this.groupBox3.Controls.Add(this.chkCanFindHome);
            this.groupBox3.Controls.Add(this.chkCanSetShutter);
            this.groupBox3.Controls.Add(this.chkCanSetAltitude);
            this.groupBox3.Controls.Add(this.chkCanPark);
            this.groupBox3.Controls.Add(this.chkCanSetPark);
            this.groupBox3.Controls.Add(this.chkCanSyncAz);
            this.groupBox3.Controls.Add(this.chkCanSetAzimuth);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(12, 254);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(235, 132);
            this.groupBox3.TabIndex = 6;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Capabilities";
            // 
            // chkCanSlave
            // 
            this.chkCanSlave.AutoSize = true;
            this.chkCanSlave.ForeColor = System.Drawing.Color.White;
            this.chkCanSlave.Location = new System.Drawing.Point(116, 95);
            this.chkCanSlave.Name = "chkCanSlave";
            this.chkCanSlave.Size = new System.Drawing.Size(75, 17);
            this.chkCanSlave.TabIndex = 7;
            this.chkCanSlave.Text = "Can Slave";
            this.chkCanSlave.UseVisualStyleBackColor = true;
            // 
            // chkCanFindHome
            // 
            this.chkCanFindHome.AutoSize = true;
            this.chkCanFindHome.ForeColor = System.Drawing.Color.White;
            this.chkCanFindHome.Location = new System.Drawing.Point(6, 26);
            this.chkCanFindHome.Name = "chkCanFindHome";
            this.chkCanFindHome.Size = new System.Drawing.Size(99, 17);
            this.chkCanFindHome.TabIndex = 0;
            this.chkCanFindHome.Text = "Can Find Home";
            this.chkCanFindHome.UseVisualStyleBackColor = true;
            // 
            // chkCanSetShutter
            // 
            this.chkCanSetShutter.AutoSize = true;
            this.chkCanSetShutter.ForeColor = System.Drawing.Color.White;
            this.chkCanSetShutter.Location = new System.Drawing.Point(116, 26);
            this.chkCanSetShutter.Name = "chkCanSetShutter";
            this.chkCanSetShutter.Size = new System.Drawing.Size(101, 17);
            this.chkCanSetShutter.TabIndex = 1;
            this.chkCanSetShutter.Text = "Can Set Shutter";
            this.chkCanSetShutter.UseVisualStyleBackColor = true;
            // 
            // chkCanSetAltitude
            // 
            this.chkCanSetAltitude.AutoSize = true;
            this.chkCanSetAltitude.Enabled = false;
            this.chkCanSetAltitude.ForeColor = System.Drawing.Color.White;
            this.chkCanSetAltitude.Location = new System.Drawing.Point(6, 95);
            this.chkCanSetAltitude.Name = "chkCanSetAltitude";
            this.chkCanSetAltitude.Size = new System.Drawing.Size(102, 17);
            this.chkCanSetAltitude.TabIndex = 6;
            this.chkCanSetAltitude.Text = "Can Set Altitude";
            this.toolTip1.SetToolTip(this.chkCanSetAltitude, "Future property");
            this.chkCanSetAltitude.UseVisualStyleBackColor = true;
            // 
            // chkCanPark
            // 
            this.chkCanPark.AutoSize = true;
            this.chkCanPark.ForeColor = System.Drawing.Color.White;
            this.chkCanPark.Location = new System.Drawing.Point(6, 49);
            this.chkCanPark.Name = "chkCanPark";
            this.chkCanPark.Size = new System.Drawing.Size(70, 17);
            this.chkCanPark.TabIndex = 2;
            this.chkCanPark.Text = "Can Park";
            this.chkCanPark.UseVisualStyleBackColor = true;
            // 
            // chkCanSetPark
            // 
            this.chkCanSetPark.AutoSize = true;
            this.chkCanSetPark.ForeColor = System.Drawing.Color.White;
            this.chkCanSetPark.Location = new System.Drawing.Point(116, 49);
            this.chkCanSetPark.Name = "chkCanSetPark";
            this.chkCanSetPark.Size = new System.Drawing.Size(89, 17);
            this.chkCanSetPark.TabIndex = 3;
            this.chkCanSetPark.Text = "Can Set Park";
            this.chkCanSetPark.UseVisualStyleBackColor = true;
            // 
            // chkCanSyncAz
            // 
            this.chkCanSyncAz.AutoSize = true;
            this.chkCanSyncAz.ForeColor = System.Drawing.Color.White;
            this.chkCanSyncAz.Location = new System.Drawing.Point(116, 72);
            this.chkCanSyncAz.Name = "chkCanSyncAz";
            this.chkCanSyncAz.Size = new System.Drawing.Size(112, 17);
            this.chkCanSyncAz.TabIndex = 5;
            this.chkCanSyncAz.Text = "Can Sync Azimuth";
            this.chkCanSyncAz.UseVisualStyleBackColor = true;
            // 
            // chkCanSetAzimuth
            // 
            this.chkCanSetAzimuth.AutoSize = true;
            this.chkCanSetAzimuth.ForeColor = System.Drawing.Color.White;
            this.chkCanSetAzimuth.Location = new System.Drawing.Point(6, 72);
            this.chkCanSetAzimuth.Name = "chkCanSetAzimuth";
            this.chkCanSetAzimuth.Size = new System.Drawing.Size(104, 17);
            this.chkCanSetAzimuth.TabIndex = 4;
            this.chkCanSetAzimuth.Text = "Can Set Azimuth";
            this.chkCanSetAzimuth.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbxRotatorStepsPer);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.tbxRainCheckPeriod);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.tbxRotatorCutOff);
            this.groupBox2.Controls.Add(this.tbxRotatorStepRate);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.tbxRotatorHomePos);
            this.groupBox2.Controls.Add(this.tbxRotatorAcceleration);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tbxRotatorParkPos);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(253, 74);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(317, 125);
            this.groupBox2.TabIndex = 23;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Rotator Settings";
            // 
            // tbxRotatorStepsPer
            // 
            this.tbxRotatorStepsPer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxRotatorStepsPer.Location = new System.Drawing.Point(108, 98);
            this.tbxRotatorStepsPer.Name = "tbxRotatorStepsPer";
            this.tbxRotatorStepsPer.Size = new System.Drawing.Size(69, 20);
            this.tbxRotatorStepsPer.TabIndex = 32;
            this.tbxRotatorStepsPer.Text = "444444";
            this.tbxRotatorStepsPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.tbxRotatorStepsPer, "Park position, 0 - 359.99 degrees");
            this.tbxRotatorStepsPer.Validating += new System.ComponentModel.CancelEventHandler(this.Int_Validation);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Steps Per Rotation";
            // 
            // tbxRainCheckPeriod
            // 
            this.tbxRainCheckPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxRainCheckPeriod.Location = new System.Drawing.Point(243, 71);
            this.tbxRainCheckPeriod.Name = "tbxRainCheckPeriod";
            this.tbxRainCheckPeriod.Size = new System.Drawing.Size(55, 20);
            this.tbxRainCheckPeriod.TabIndex = 30;
            this.tbxRainCheckPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.tbxRainCheckPeriod, "How many seconds between checks on the rain sensor. 30 should be fine.");
            this.tbxRainCheckPeriod.Validating += new System.ComponentModel.CancelEventHandler(this.Int_Validation);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(139, 74);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 13);
            this.label13.TabIndex = 29;
            this.label13.Text = "Rain Check Interval";
            // 
            // tbxRotatorStepRate
            // 
            this.tbxRotatorStepRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxRotatorStepRate.Location = new System.Drawing.Point(243, 45);
            this.tbxRotatorStepRate.Name = "tbxRotatorStepRate";
            this.tbxRotatorStepRate.Size = new System.Drawing.Size(55, 20);
            this.tbxRotatorStepRate.TabIndex = 28;
            this.tbxRotatorStepRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.tbxRotatorStepRate, "Max about 5000, if it starts bouncing or stalling, try 4000");
            this.tbxRotatorStepRate.Validating += new System.ComponentModel.CancelEventHandler(this.Int_Validation);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(139, 48);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(38, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "Speed";
            // 
            // tbxRotatorAcceleration
            // 
            this.tbxRotatorAcceleration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxRotatorAcceleration.Location = new System.Drawing.Point(243, 19);
            this.tbxRotatorAcceleration.Name = "tbxRotatorAcceleration";
            this.tbxRotatorAcceleration.Size = new System.Drawing.Size(55, 20);
            this.tbxRotatorAcceleration.TabIndex = 24;
            this.tbxRotatorAcceleration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.tbxRotatorAcceleration, "Max about 7000, if motor stalls try 5000");
            this.tbxRotatorAcceleration.Validating += new System.ComponentModel.CancelEventHandler(this.Int_Validation);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(139, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 23;
            this.label4.Text = "Acceleration";
            // 
            // gbShutterSettings
            // 
            this.gbShutterSettings.Controls.Add(this.tbxShutterStepsPer);
            this.gbShutterSettings.Controls.Add(this.label19);
            this.gbShutterSettings.Controls.Add(this.tbxShutterInactive);
            this.gbShutterSettings.Controls.Add(this.label21);
            this.gbShutterSettings.Controls.Add(this.chkShutterSleepEnabled);
            this.gbShutterSettings.Controls.Add(this.tbxShutterSleepDelay);
            this.gbShutterSettings.Controls.Add(this.label15);
            this.gbShutterSettings.Controls.Add(this.tbxShutterSleepPeriod);
            this.gbShutterSettings.Controls.Add(this.label11);
            this.gbShutterSettings.Controls.Add(this.tbxShutterStepRate);
            this.gbShutterSettings.Controls.Add(this.label18);
            this.gbShutterSettings.Controls.Add(this.tbxShutterAcceleration);
            this.gbShutterSettings.Controls.Add(this.label17);
            this.gbShutterSettings.Controls.Add(this.label14);
            this.gbShutterSettings.Controls.Add(this.tbxShutterCutOff);
            this.gbShutterSettings.Controls.Add(this.lblMinElevation);
            this.gbShutterSettings.Controls.Add(this.label8);
            this.gbShutterSettings.Controls.Add(this.label12);
            this.gbShutterSettings.Controls.Add(this.lblMaxElevation);
            this.gbShutterSettings.Enabled = false;
            this.gbShutterSettings.ForeColor = System.Drawing.Color.White;
            this.gbShutterSettings.Location = new System.Drawing.Point(253, 205);
            this.gbShutterSettings.Name = "gbShutterSettings";
            this.gbShutterSettings.Size = new System.Drawing.Size(317, 181);
            this.gbShutterSettings.TabIndex = 24;
            this.gbShutterSettings.TabStop = false;
            this.gbShutterSettings.Text = "Shutter Settings";
            // 
            // tbxShutterStepsPer
            // 
            this.tbxShutterStepsPer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxShutterStepsPer.Location = new System.Drawing.Point(108, 147);
            this.tbxShutterStepsPer.Name = "tbxShutterStepsPer";
            this.tbxShutterStepsPer.Size = new System.Drawing.Size(69, 20);
            this.tbxShutterStepsPer.TabIndex = 35;
            this.tbxShutterStepsPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.tbxShutterStepsPer, "Park position, 0 - 359.99 degrees");
            this.tbxShutterStepsPer.Validating += new System.ComponentModel.CancelEventHandler(this.Int_Validation);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(6, 150);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(96, 13);
            this.label19.TabIndex = 34;
            this.label19.Text = "Steps Per Rotation";
            // 
            // tbxShutterInactive
            // 
            this.tbxShutterInactive.Enabled = false;
            this.tbxShutterInactive.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxShutterInactive.Location = new System.Drawing.Point(243, 95);
            this.tbxShutterInactive.Name = "tbxShutterInactive";
            this.tbxShutterInactive.Size = new System.Drawing.Size(55, 20);
            this.tbxShutterInactive.TabIndex = 33;
            this.tbxShutterInactive.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.tbxShutterInactive, "After this many minutes of no use, shutter will close.");
            this.tbxShutterInactive.Validating += new System.ComponentModel.CancelEventHandler(this.Int_Validation);
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(142, 98);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(78, 13);
            this.label21.TabIndex = 32;
            this.label21.Text = "Inactivity Timer";
            this.label21.Validating += new System.ComponentModel.CancelEventHandler(this.Int_Validation);
            // 
            // chkShutterSleepEnabled
            // 
            this.chkShutterSleepEnabled.AutoSize = true;
            this.chkShutterSleepEnabled.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkShutterSleepEnabled.Enabled = false;
            this.chkShutterSleepEnabled.Location = new System.Drawing.Point(169, 22);
            this.chkShutterSleepEnabled.Name = "chkShutterSleepEnabled";
            this.chkShutterSleepEnabled.Size = new System.Drawing.Size(89, 17);
            this.chkShutterSleepEnabled.TabIndex = 31;
            this.chkShutterSleepEnabled.Text = "Enable Sleep";
            this.toolTip1.SetToolTip(this.chkShutterSleepEnabled, "Future property. ");
            this.chkShutterSleepEnabled.UseVisualStyleBackColor = true;
            // 
            // tbxShutterSleepDelay
            // 
            this.tbxShutterSleepDelay.Enabled = false;
            this.tbxShutterSleepDelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxShutterSleepDelay.Location = new System.Drawing.Point(243, 71);
            this.tbxShutterSleepDelay.Name = "tbxShutterSleepDelay";
            this.tbxShutterSleepDelay.Size = new System.Drawing.Size(55, 20);
            this.tbxShutterSleepDelay.TabIndex = 29;
            this.tbxShutterSleepDelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.tbxShutterSleepDelay, "Future property");
            this.tbxShutterSleepDelay.Validating += new System.ComponentModel.CancelEventHandler(this.Int_Validation);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(141, 74);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 13);
            this.label15.TabIndex = 28;
            this.label15.Text = "Sleep Delay";
            // 
            // tbxShutterSleepPeriod
            // 
            this.tbxShutterSleepPeriod.Enabled = false;
            this.tbxShutterSleepPeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxShutterSleepPeriod.Location = new System.Drawing.Point(243, 45);
            this.tbxShutterSleepPeriod.Name = "tbxShutterSleepPeriod";
            this.tbxShutterSleepPeriod.Size = new System.Drawing.Size(55, 20);
            this.tbxShutterSleepPeriod.TabIndex = 27;
            this.tbxShutterSleepPeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.tbxShutterSleepPeriod, "Future property");
            this.tbxShutterSleepPeriod.Validating += new System.ComponentModel.CancelEventHandler(this.Int_Validation);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(141, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 13);
            this.label11.TabIndex = 26;
            this.label11.Text = "Sleep Period";
            // 
            // tbxShutterStepRate
            // 
            this.tbxShutterStepRate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxShutterStepRate.Location = new System.Drawing.Point(78, 121);
            this.tbxShutterStepRate.Name = "tbxShutterStepRate";
            this.tbxShutterStepRate.Size = new System.Drawing.Size(55, 20);
            this.tbxShutterStepRate.TabIndex = 25;
            this.tbxShutterStepRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.tbxShutterStepRate, "Max about 5000, if it starts bouncing or stalling, try 4000");
            this.tbxShutterStepRate.Validating += new System.ComponentModel.CancelEventHandler(this.Int_Validation);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(6, 124);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(55, 13);
            this.label18.TabIndex = 24;
            this.label18.Text = "Step Rate";
            // 
            // tbxShutterAcceleration
            // 
            this.tbxShutterAcceleration.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxShutterAcceleration.Location = new System.Drawing.Point(78, 95);
            this.tbxShutterAcceleration.Name = "tbxShutterAcceleration";
            this.tbxShutterAcceleration.Size = new System.Drawing.Size(55, 20);
            this.tbxShutterAcceleration.TabIndex = 24;
            this.tbxShutterAcceleration.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.tbxShutterAcceleration, "Max about 7000, if motor stalls try 5000");
            this.tbxShutterAcceleration.Validating += new System.ComponentModel.CancelEventHandler(this.Int_Validation);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(6, 98);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(66, 13);
            this.label17.TabIndex = 23;
            this.label17.Text = "Acceleration";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(6, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(58, 13);
            this.label14.TabIndex = 8;
            this.label14.Text = "Low Cutoff";
            // 
            // lblMaxElevation
            // 
            this.lblMaxElevation.BackColor = System.Drawing.Color.Black;
            this.lblMaxElevation.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMaxElevation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxElevation.ForeColor = System.Drawing.Color.White;
            this.lblMaxElevation.Location = new System.Drawing.Point(78, 44);
            this.lblMaxElevation.Name = "lblMaxElevation";
            this.lblMaxElevation.Size = new System.Drawing.Size(55, 20);
            this.lblMaxElevation.TabIndex = 17;
            this.lblMaxElevation.Text = "90.00";
            this.lblMaxElevation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.lblMaxElevation, "Future property");
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(579, 441);
            this.ControlBox = false;
            this.Controls.Add(this.gbShutterSettings);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gbShutterVersion);
            this.Controls.Add(this.gbRotatorVersion);
            this.Controls.Add(this.picASCOM);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.cmdOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "SetupForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDM NexDome Setup";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SetupForm_FormClosing);
            this.Load += new System.EventHandler(this.SetupDialogForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picASCOM)).EndInit();
            this.gbRotatorVersion.ResumeLayout(false);
            this.gbRotatorVersion.PerformLayout();
            this.gbShutterVersion.ResumeLayout(false);
            this.gbShutterVersion.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbShutterSettings.ResumeLayout(false);
            this.gbShutterSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.PictureBox picASCOM;
        private System.Windows.Forms.GroupBox gbRotatorVersion;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblRotatorVolts;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer UpdateTimer;
        private System.Windows.Forms.GroupBox gbShutterVersion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblShutterVolts;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox chkCanSlave;
        private System.Windows.Forms.CheckBox chkCanSetAltitude;
        private System.Windows.Forms.CheckBox chkCanSyncAz;
        private System.Windows.Forms.CheckBox chkCanSetAzimuth;
        private System.Windows.Forms.CheckBox chkCanSetPark;
        private System.Windows.Forms.CheckBox chkCanPark;
        private System.Windows.Forms.CheckBox chkCanSetShutter;
        private System.Windows.Forms.CheckBox chkCanFindHome;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnCalibrateRotator;
        private System.Windows.Forms.Label lblRotatorSeekMode;
        private System.Windows.Forms.Label lblHomeStatus;
        private System.Windows.Forms.Label lblMinElevation;
        private System.Windows.Forms.TextBox tbxRotatorCutOff;
        private System.Windows.Forms.TextBox tbxRotatorHomePos;
        private System.Windows.Forms.TextBox tbxRotatorParkPos;
        private System.Windows.Forms.TextBox tbxShutterCutOff;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxRotatorAcceleration;
        private System.Windows.Forms.GroupBox gbShutterSettings;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbxShutterAcceleration;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbxShutterStepRate;
        private System.Windows.Forms.Label lblMaxElevation;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbxShutterSleepDelay;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbxShutterSleepPeriod;
        private System.Windows.Forms.CheckBox chkRotatorReversed;
        private System.Windows.Forms.CheckBox chkShutterReversed;
        private System.Windows.Forms.TextBox tbxRainCheckPeriod;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbxRotatorStepRate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.CheckBox chkShutterSleepEnabled;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TextBox tbxShutterInactive;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label lblShutterState;
        private System.Windows.Forms.Button btnOpenShutter;
        private System.Windows.Forms.Label lblRotatorHeading;
        private System.Windows.Forms.Label lblShutterElevation;
        private System.Windows.Forms.TextBox tbxRotatorStepsPer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxShutterStepsPer;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lblRotatorStepPos;
        private System.Windows.Forms.Label lblShutterStepPos;
        private System.Windows.Forms.Button btnCloseShutter;
    }
}