namespace NexDomeRotatorConfigurator
{
    partial class frmMain
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
            this.btnMaxSpeed = new System.Windows.Forms.Button();
            this.cbxStepMode = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxMaxSpeed = new System.Windows.Forms.TextBox();
            this.tbxAcceleration = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAcceleration = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.btnStepMode = new System.Windows.Forms.Button();
            this.tbxStepsPerRotation = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnStepsPerRotation = new System.Windows.Forms.Button();
            this.btnRotateCCW = new System.Windows.Forms.Button();
            this.btnRotateCW = new System.Windows.Forms.Button();
            this.btnGoToAz = new System.Windows.Forms.Button();
            this.btnGoToPos = new System.Windows.Forms.Button();
            this.tbxGotoAz = new System.Windows.Forms.TextBox();
            this.tbxGotoPos = new System.Windows.Forms.TextBox();
            this.lblDisplayAz = new System.Windows.Forms.Label();
            this.lblControllerVersion = new System.Windows.Forms.Label();
            this.ArduinoPort = new System.IO.Ports.SerialPort(this.components);
            this.cbxPorts = new System.Windows.Forms.ComboBox();
            this.cbxBaudRates = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.tbxTerminal = new System.Windows.Forms.TextBox();
            this.tbxCommand = new System.Windows.Forms.TextBox();
            this.btnCommand = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.ParseTimer = new System.Windows.Forms.Timer(this.components);
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.lblDisplayPos = new System.Windows.Forms.Label();
            this.tbxHomeAzimuth = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnHomeAzimuth = new System.Windows.Forms.Button();
            this.tbxParkAzimuth = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnParkAzimuth = new System.Windows.Forms.Button();
            this.lblRotVolts = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblShutVolts = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblCutVolts = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tbxHomeCenter = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnHomeCenter = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.lblSeekMode = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblHomedState = new System.Windows.Forms.Label();
            this.btnDoCalibrate = new System.Windows.Forms.Button();
            this.btnDoHoming = new System.Windows.Forms.Button();
            this.btnParkDome = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Movement = new System.Windows.Forms.GroupBox();
            this.btnFullTurn = new System.Windows.Forms.Button();
            this.btnSync = new System.Windows.Forms.Button();
            this.btnSTOP = new System.Windows.Forms.Button();
            this.lblMultiStatus = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnSaveSettings = new System.Windows.Forms.Button();
            this.btnLoadSettings = new System.Windows.Forms.Button();
            this.chkReversed = new System.Windows.Forms.CheckBox();
            this.RotateTimer = new System.Windows.Forms.Timer(this.components);
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.cbxUpdateRate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.Movement.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMaxSpeed
            // 
            this.btnMaxSpeed.Location = new System.Drawing.Point(122, 70);
            this.btnMaxSpeed.Name = "btnMaxSpeed";
            this.btnMaxSpeed.Size = new System.Drawing.Size(65, 23);
            this.btnMaxSpeed.TabIndex = 0;
            this.btnMaxSpeed.Text = "Set";
            this.toolTip1.SetToolTip(this.btnMaxSpeed, "How fast motor runs. At 8 and microsteps 5000 is about the fastest. Lower steps r" +
        "equirer lower speeds.");
            this.btnMaxSpeed.UseVisualStyleBackColor = true;
            this.btnMaxSpeed.Click += new System.EventHandler(this.btnMaxSpeed_Click);
            // 
            // cbxStepMode
            // 
            this.cbxStepMode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxStepMode.FormattingEnabled = true;
            this.cbxStepMode.Items.AddRange(new object[] {
            "Microsteps...",
            "1",
            "2",
            "4",
            "8",
            "16"});
            this.cbxStepMode.Location = new System.Drawing.Point(6, 32);
            this.cbxStepMode.Name = "cbxStepMode";
            this.cbxStepMode.Size = new System.Drawing.Size(100, 21);
            this.cbxStepMode.TabIndex = 1;
            this.toolTip1.SetToolTip(this.cbxStepMode, "Set to match dip switch settings on NexDome controller.");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Maximum Speed";
            // 
            // tbxMaxSpeed
            // 
            this.tbxMaxSpeed.Location = new System.Drawing.Point(6, 72);
            this.tbxMaxSpeed.Name = "tbxMaxSpeed";
            this.tbxMaxSpeed.Size = new System.Drawing.Size(100, 20);
            this.tbxMaxSpeed.TabIndex = 4;
            this.toolTip1.SetToolTip(this.tbxMaxSpeed, "How fast motor runs. At 8 microsteps 5000 is about the fastest. Half the steps me" +
        "ans roughly half the speed so 2500 at 4 etc. Lower steps also means lower torque" +
        " which may stall the motor.");
            // 
            // tbxAcceleration
            // 
            this.tbxAcceleration.Location = new System.Drawing.Point(6, 111);
            this.tbxAcceleration.Name = "tbxAcceleration";
            this.tbxAcceleration.Size = new System.Drawing.Size(100, 20);
            this.tbxAcceleration.TabIndex = 7;
            this.toolTip1.SetToolTip(this.tbxAcceleration, "How fast motor speeds up. At 8 microsteps 6000 is about the fastest. Like maximum" +
        " speed, lower steps requirer half or less of next higher rate.");
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Acceleration";
            // 
            // btnAcceleration
            // 
            this.btnAcceleration.Location = new System.Drawing.Point(122, 109);
            this.btnAcceleration.Name = "btnAcceleration";
            this.btnAcceleration.Size = new System.Drawing.Size(65, 23);
            this.btnAcceleration.TabIndex = 5;
            this.btnAcceleration.Text = "Set";
            this.toolTip1.SetToolTip(this.btnAcceleration, "How fast motor speeds up. At 8 microsteps 6000 is about the fastest. Lower steps " +
        "requirer lower rates.");
            this.btnAcceleration.UseVisualStyleBackColor = true;
            this.btnAcceleration.Click += new System.EventHandler(this.btnAcceleration_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Step mode";
            // 
            // btnStepMode
            // 
            this.btnStepMode.Location = new System.Drawing.Point(122, 30);
            this.btnStepMode.Name = "btnStepMode";
            this.btnStepMode.Size = new System.Drawing.Size(65, 23);
            this.btnStepMode.TabIndex = 8;
            this.btnStepMode.Text = "Set";
            this.toolTip1.SetToolTip(this.btnStepMode, "WARNING: MUST be set to match dip switch settings on NexDome controller.");
            this.btnStepMode.UseVisualStyleBackColor = true;
            this.btnStepMode.Click += new System.EventHandler(this.btnStepMode_Click);
            // 
            // tbxStepsPerRotation
            // 
            this.tbxStepsPerRotation.Location = new System.Drawing.Point(6, 150);
            this.tbxStepsPerRotation.Name = "tbxStepsPerRotation";
            this.tbxStepsPerRotation.Size = new System.Drawing.Size(100, 20);
            this.tbxStepsPerRotation.TabIndex = 12;
            this.toolTip1.SetToolTip(this.tbxStepsPerRotation, "Number of steps required for a full rotation of the dome. At 8 microsteps that is" +
        " somewhere around 440000.");
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Steps per Rotation";
            // 
            // btnStepsPerRotation
            // 
            this.btnStepsPerRotation.Location = new System.Drawing.Point(122, 148);
            this.btnStepsPerRotation.Name = "btnStepsPerRotation";
            this.btnStepsPerRotation.Size = new System.Drawing.Size(65, 23);
            this.btnStepsPerRotation.TabIndex = 10;
            this.btnStepsPerRotation.Text = "Set";
            this.toolTip1.SetToolTip(this.btnStepsPerRotation, "Number of steps required for a full rotation of the dome. At 8 microsteps that is" +
        " somewhere around 440000.");
            this.btnStepsPerRotation.UseVisualStyleBackColor = true;
            this.btnStepsPerRotation.Click += new System.EventHandler(this.btnStepsPerRotation_Click);
            // 
            // btnRotateCCW
            // 
            this.btnRotateCCW.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRotateCCW.Location = new System.Drawing.Point(5, 117);
            this.btnRotateCCW.Name = "btnRotateCCW";
            this.btnRotateCCW.Size = new System.Drawing.Size(66, 79);
            this.btnRotateCCW.TabIndex = 13;
            this.btnRotateCCW.Text = "<";
            this.toolTip1.SetToolTip(this.btnRotateCCW, "Rotate counterclockwise.");
            this.btnRotateCCW.UseVisualStyleBackColor = true;
            this.btnRotateCCW.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRotateCCW_MouseDown);
            this.btnRotateCCW.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnRotateCCW_MouseUp);
            // 
            // btnRotateCW
            // 
            this.btnRotateCW.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRotateCW.Location = new System.Drawing.Point(149, 117);
            this.btnRotateCW.Name = "btnRotateCW";
            this.btnRotateCW.Size = new System.Drawing.Size(66, 77);
            this.btnRotateCW.TabIndex = 14;
            this.btnRotateCW.Text = ">";
            this.toolTip1.SetToolTip(this.btnRotateCW, "Rotate clockwise.");
            this.btnRotateCW.UseVisualStyleBackColor = true;
            this.btnRotateCW.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRotateCW_MouseDown);
            this.btnRotateCW.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnRotateCW_MouseUp);
            // 
            // btnGoToAz
            // 
            this.btnGoToAz.Location = new System.Drawing.Point(149, 88);
            this.btnGoToAz.Name = "btnGoToAz";
            this.btnGoToAz.Size = new System.Drawing.Size(66, 27);
            this.btnGoToAz.TabIndex = 15;
            this.btnGoToAz.Text = "Go to Az";
            this.toolTip1.SetToolTip(this.btnGoToAz, "Go to azimuth supplied.");
            this.btnGoToAz.UseVisualStyleBackColor = true;
            this.btnGoToAz.Click += new System.EventHandler(this.btnGoToAz_Click);
            // 
            // btnGoToPos
            // 
            this.btnGoToPos.Location = new System.Drawing.Point(149, 199);
            this.btnGoToPos.Name = "btnGoToPos";
            this.btnGoToPos.Size = new System.Drawing.Size(66, 27);
            this.btnGoToPos.TabIndex = 16;
            this.btnGoToPos.Text = "Go to Pos";
            this.toolTip1.SetToolTip(this.btnGoToPos, "Go to stepper position supplied.");
            this.btnGoToPos.UseVisualStyleBackColor = true;
            this.btnGoToPos.Click += new System.EventHandler(this.btnGoToPos_Click);
            // 
            // tbxGotoAz
            // 
            this.tbxGotoAz.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxGotoAz.Location = new System.Drawing.Point(77, 88);
            this.tbxGotoAz.Name = "tbxGotoAz";
            this.tbxGotoAz.Size = new System.Drawing.Size(66, 26);
            this.tbxGotoAz.TabIndex = 17;
            this.tbxGotoAz.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.tbxGotoAz, "Enter manual azimuth numbers here.");
            // 
            // tbxGotoPos
            // 
            this.tbxGotoPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxGotoPos.Location = new System.Drawing.Point(77, 199);
            this.tbxGotoPos.Name = "tbxGotoPos";
            this.tbxGotoPos.Size = new System.Drawing.Size(66, 26);
            this.tbxGotoPos.TabIndex = 18;
            this.tbxGotoPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip1.SetToolTip(this.tbxGotoPos, "Enter manual position values here.");
            // 
            // lblDisplayAz
            // 
            this.lblDisplayAz.BackColor = System.Drawing.Color.White;
            this.lblDisplayAz.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDisplayAz.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayAz.Location = new System.Drawing.Point(77, 117);
            this.lblDisplayAz.Name = "lblDisplayAz";
            this.lblDisplayAz.Size = new System.Drawing.Size(66, 26);
            this.lblDisplayAz.TabIndex = 19;
            this.lblDisplayAz.Text = "0";
            this.lblDisplayAz.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.lblDisplayAz, "Rotator\'s current azimuth.");
            // 
            // lblControllerVersion
            // 
            this.lblControllerVersion.BackColor = System.Drawing.Color.White;
            this.lblControllerVersion.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblControllerVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblControllerVersion.Location = new System.Drawing.Point(6, 16);
            this.lblControllerVersion.Name = "lblControllerVersion";
            this.lblControllerVersion.Size = new System.Drawing.Size(187, 23);
            this.lblControllerVersion.TabIndex = 20;
            this.lblControllerVersion.Text = "0";
            // 
            // ArduinoPort
            // 
            this.ArduinoPort.ReadTimeout = 1000;
            this.ArduinoPort.RtsEnable = true;
            this.ArduinoPort.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialDataReceived);
            // 
            // cbxPorts
            // 
            this.cbxPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxPorts.FormattingEnabled = true;
            this.cbxPorts.Location = new System.Drawing.Point(6, 19);
            this.cbxPorts.Name = "cbxPorts";
            this.cbxPorts.Size = new System.Drawing.Size(203, 21);
            this.cbxPorts.TabIndex = 21;
            // 
            // cbxBaudRates
            // 
            this.cbxBaudRates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBaudRates.FormattingEnabled = true;
            this.cbxBaudRates.Location = new System.Drawing.Point(215, 19);
            this.cbxBaudRates.Name = "cbxBaudRates";
            this.cbxBaudRates.Size = new System.Drawing.Size(90, 21);
            this.cbxBaudRates.TabIndex = 22;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(311, 19);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(81, 21);
            this.btnConnect.TabIndex = 23;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // tbxTerminal
            // 
            this.tbxTerminal.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.tbxTerminal.Location = new System.Drawing.Point(9, 83);
            this.tbxTerminal.Multiline = true;
            this.tbxTerminal.Name = "tbxTerminal";
            this.tbxTerminal.ReadOnly = true;
            this.tbxTerminal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbxTerminal.Size = new System.Drawing.Size(383, 143);
            this.tbxTerminal.TabIndex = 24;
            // 
            // tbxCommand
            // 
            this.tbxCommand.Location = new System.Drawing.Point(9, 58);
            this.tbxCommand.Name = "tbxCommand";
            this.tbxCommand.Size = new System.Drawing.Size(113, 20);
            this.tbxCommand.TabIndex = 25;
            this.toolTip1.SetToolTip(this.tbxCommand, "Enter known serial commands here. Don\'t type random stuff!");
            // 
            // btnCommand
            // 
            this.btnCommand.Location = new System.Drawing.Point(128, 58);
            this.btnCommand.Name = "btnCommand";
            this.btnCommand.Size = new System.Drawing.Size(81, 20);
            this.btnCommand.TabIndex = 26;
            this.btnCommand.Text = "Send";
            this.toolTip1.SetToolTip(this.btnCommand, "Enter known serial commands here. Don\'t type random stuff!");
            this.btnCommand.UseVisualStyleBackColor = true;
            this.btnCommand.Click += new System.EventHandler(this.btnCommand_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 13);
            this.label6.TabIndex = 27;
            this.label6.Text = "Manual command";
            // 
            // ReceiveTimer
            // 
            this.ParseTimer.Enabled = true;
            this.ParseTimer.Tick += new System.EventHandler(this.ParseTimer_Tick);
            // 
            // StatusTimer
            // 
            this.UpdateTimer.Interval = 1000;
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateTimer_Tick);
            // 
            // lblDisplayPos
            // 
            this.lblDisplayPos.BackColor = System.Drawing.Color.White;
            this.lblDisplayPos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblDisplayPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisplayPos.Location = new System.Drawing.Point(77, 170);
            this.lblDisplayPos.Name = "lblDisplayPos";
            this.lblDisplayPos.Size = new System.Drawing.Size(66, 26);
            this.lblDisplayPos.TabIndex = 29;
            this.lblDisplayPos.Text = "0";
            this.lblDisplayPos.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.lblDisplayPos, "Rotator\'s current step position (0 - Steps per Rotation);.");
            // 
            // tbxHomeAzimuth
            // 
            this.tbxHomeAzimuth.Location = new System.Drawing.Point(9, 32);
            this.tbxHomeAzimuth.Name = "tbxHomeAzimuth";
            this.tbxHomeAzimuth.Size = new System.Drawing.Size(100, 20);
            this.tbxHomeAzimuth.TabIndex = 33;
            this.toolTip1.SetToolTip(this.tbxHomeAzimuth, "Set home switch azimuth. Must be 0 to 359");
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Home Azimuth";
            // 
            // btnHomeAzimuth
            // 
            this.btnHomeAzimuth.Location = new System.Drawing.Point(118, 30);
            this.btnHomeAzimuth.Name = "btnHomeAzimuth";
            this.btnHomeAzimuth.Size = new System.Drawing.Size(75, 23);
            this.btnHomeAzimuth.TabIndex = 31;
            this.btnHomeAzimuth.Text = "Set";
            this.toolTip1.SetToolTip(this.btnHomeAzimuth, "Set home switch azimuth. Must be 0 to 359");
            this.btnHomeAzimuth.UseVisualStyleBackColor = true;
            this.btnHomeAzimuth.Click += new System.EventHandler(this.btnHomeAzimuth_Click);
            // 
            // tbxParkAzimuth
            // 
            this.tbxParkAzimuth.Location = new System.Drawing.Point(9, 71);
            this.tbxParkAzimuth.Name = "tbxParkAzimuth";
            this.tbxParkAzimuth.Size = new System.Drawing.Size(100, 20);
            this.tbxParkAzimuth.TabIndex = 36;
            this.toolTip1.SetToolTip(this.tbxParkAzimuth, "Set parking azimuth. Must be 0 to 359");
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 55);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "Park Azimuth";
            // 
            // btnParkAzimuth
            // 
            this.btnParkAzimuth.Location = new System.Drawing.Point(118, 69);
            this.btnParkAzimuth.Name = "btnParkAzimuth";
            this.btnParkAzimuth.Size = new System.Drawing.Size(75, 23);
            this.btnParkAzimuth.TabIndex = 34;
            this.btnParkAzimuth.Text = "Set";
            this.toolTip1.SetToolTip(this.btnParkAzimuth, "Set parking azimuth. Must be 0 to 359");
            this.btnParkAzimuth.UseVisualStyleBackColor = true;
            this.btnParkAzimuth.Click += new System.EventHandler(this.btnParkAzimuth_Click);
            // 
            // lblRotVolts
            // 
            this.lblRotVolts.BackColor = System.Drawing.Color.White;
            this.lblRotVolts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblRotVolts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRotVolts.Location = new System.Drawing.Point(4, 58);
            this.lblRotVolts.Name = "lblRotVolts";
            this.lblRotVolts.Size = new System.Drawing.Size(51, 19);
            this.lblRotVolts.TabIndex = 38;
            this.lblRotVolts.Text = "0";
            this.lblRotVolts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(42, 13);
            this.label11.TabIndex = 39;
            this.label11.Text = "Rotator";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(79, 44);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(41, 13);
            this.label12.TabIndex = 41;
            this.label12.Text = "Shutter";
            // 
            // lblShutVolts
            // 
            this.lblShutVolts.BackColor = System.Drawing.Color.White;
            this.lblShutVolts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblShutVolts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblShutVolts.Location = new System.Drawing.Point(74, 58);
            this.lblShutVolts.Name = "lblShutVolts";
            this.lblShutVolts.Size = new System.Drawing.Size(51, 19);
            this.lblShutVolts.TabIndex = 40;
            this.lblShutVolts.Text = "0";
            this.lblShutVolts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(148, 42);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(38, 13);
            this.label14.TabIndex = 43;
            this.label14.Text = "Cut-off";
            // 
            // lblCutVolts
            // 
            this.lblCutVolts.BackColor = System.Drawing.Color.White;
            this.lblCutVolts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblCutVolts.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCutVolts.Location = new System.Drawing.Point(142, 58);
            this.lblCutVolts.Name = "lblCutVolts";
            this.lblCutVolts.Size = new System.Drawing.Size(51, 19);
            this.lblCutVolts.TabIndex = 42;
            this.lblCutVolts.Text = "0";
            this.lblCutVolts.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.lblRotVolts);
            this.groupBox1.Controls.Add(this.lblCutVolts);
            this.groupBox1.Controls.Add(this.lblShutVolts);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lblControllerVersion);
            this.groupBox1.Location = new System.Drawing.Point(211, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(199, 92);
            this.groupBox1.TabIndex = 44;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Information";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbxHomeCenter);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.btnHomeCenter);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btnHomeAzimuth);
            this.groupBox2.Controls.Add(this.tbxHomeAzimuth);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.btnParkAzimuth);
            this.groupBox2.Controls.Add(this.tbxParkAzimuth);
            this.groupBox2.Location = new System.Drawing.Point(211, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(199, 141);
            this.groupBox2.TabIndex = 45;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Home and Park";
            // 
            // tbxHomeCenter
            // 
            this.tbxHomeCenter.Location = new System.Drawing.Point(9, 110);
            this.tbxHomeCenter.Name = "tbxHomeCenter";
            this.tbxHomeCenter.Size = new System.Drawing.Size(100, 20);
            this.tbxHomeCenter.TabIndex = 41;
            this.toolTip1.SetToolTip(this.tbxHomeCenter, "Most likely this will be removed in the next version. Steps to the center of the " +
        "home switch magnetic field.");
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 94);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(69, 13);
            this.label10.TabIndex = 40;
            this.label10.Text = "Home Center";
            // 
            // btnHomeCenter
            // 
            this.btnHomeCenter.Location = new System.Drawing.Point(118, 108);
            this.btnHomeCenter.Name = "btnHomeCenter";
            this.btnHomeCenter.Size = new System.Drawing.Size(75, 23);
            this.btnHomeCenter.TabIndex = 39;
            this.btnHomeCenter.Text = "Set";
            this.toolTip1.SetToolTip(this.btnHomeCenter, "Most likely this will be removed in the next version. Steps to the center of the " +
        "home switch magnetic field.");
            this.btnHomeCenter.UseVisualStyleBackColor = true;
            this.btnHomeCenter.Click += new System.EventHandler(this.btnHomeCenter_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(6, 353);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 13);
            this.label16.TabIndex = 52;
            this.label16.Text = "Seek Mode";
            // 
            // lblSeekMode
            // 
            this.lblSeekMode.BackColor = System.Drawing.Color.White;
            this.lblSeekMode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSeekMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeekMode.Location = new System.Drawing.Point(115, 349);
            this.lblSeekMode.Name = "lblSeekMode";
            this.lblSeekMode.Size = new System.Drawing.Size(100, 20);
            this.lblSeekMode.TabIndex = 50;
            this.lblSeekMode.Text = "0";
            this.lblSeekMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.lblSeekMode, "Shows current seeking state if homing or calibrating.");
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(6, 329);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(68, 13);
            this.label15.TabIndex = 51;
            this.label15.Text = "Home Status";
            // 
            // lblHomedState
            // 
            this.lblHomedState.BackColor = System.Drawing.Color.White;
            this.lblHomedState.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHomedState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHomedState.Location = new System.Drawing.Point(115, 325);
            this.lblHomedState.Name = "lblHomedState";
            this.lblHomedState.Size = new System.Drawing.Size(100, 20);
            this.lblHomedState.TabIndex = 32;
            this.lblHomedState.Text = "0";
            this.lblHomedState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.lblHomedState, "Shows the rotator\'s status in relation to homing.");
            // 
            // btnDoCalibrate
            // 
            this.btnDoCalibrate.Location = new System.Drawing.Point(150, 286);
            this.btnDoCalibrate.Name = "btnDoCalibrate";
            this.btnDoCalibrate.Size = new System.Drawing.Size(65, 23);
            this.btnDoCalibrate.TabIndex = 42;
            this.btnDoCalibrate.Text = "Calibrate";
            this.toolTip1.SetToolTip(this.btnDoCalibrate, "Perform calibration to determine steps required for a full rotation.");
            this.btnDoCalibrate.UseVisualStyleBackColor = true;
            this.btnDoCalibrate.Click += new System.EventHandler(this.btnDoCalibrate_Click);
            // 
            // btnDoHoming
            // 
            this.btnDoHoming.Location = new System.Drawing.Point(5, 286);
            this.btnDoHoming.Name = "btnDoHoming";
            this.btnDoHoming.Size = new System.Drawing.Size(65, 23);
            this.btnDoHoming.TabIndex = 37;
            this.btnDoHoming.Text = "Home";
            this.toolTip1.SetToolTip(this.btnDoHoming, "Perform homing operation.");
            this.btnDoHoming.UseVisualStyleBackColor = true;
            this.btnDoHoming.Click += new System.EventHandler(this.btnDoHoming_Click);
            // 
            // btnParkDome
            // 
            this.btnParkDome.Location = new System.Drawing.Point(74, 59);
            this.btnParkDome.Name = "btnParkDome";
            this.btnParkDome.Size = new System.Drawing.Size(72, 23);
            this.btnParkDome.TabIndex = 38;
            this.btnParkDome.Text = "Park";
            this.toolTip1.SetToolTip(this.btnParkDome, "Go to parking azimuth");
            this.btnParkDome.UseVisualStyleBackColor = true;
            this.btnParkDome.Click += new System.EventHandler(this.btnParkDome_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbxPorts);
            this.groupBox3.Controls.Add(this.cbxBaudRates);
            this.groupBox3.Controls.Add(this.btnConnect);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.tbxTerminal);
            this.groupBox3.Controls.Add(this.tbxCommand);
            this.groupBox3.Controls.Add(this.btnCommand);
            this.groupBox3.Location = new System.Drawing.Point(12, 257);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(398, 234);
            this.groupBox3.TabIndex = 46;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Serial";
            // 
            // Movement
            // 
            this.Movement.Controls.Add(this.label2);
            this.Movement.Controls.Add(this.cbxUpdateRate);
            this.Movement.Controls.Add(this.btnFullTurn);
            this.Movement.Controls.Add(this.label16);
            this.Movement.Controls.Add(this.btnSync);
            this.Movement.Controls.Add(this.lblSeekMode);
            this.Movement.Controls.Add(this.btnSTOP);
            this.Movement.Controls.Add(this.btnDoCalibrate);
            this.Movement.Controls.Add(this.lblMultiStatus);
            this.Movement.Controls.Add(this.btnGoToAz);
            this.Movement.Controls.Add(this.btnRotateCCW);
            this.Movement.Controls.Add(this.btnRotateCW);
            this.Movement.Controls.Add(this.label15);
            this.Movement.Controls.Add(this.btnGoToPos);
            this.Movement.Controls.Add(this.btnDoHoming);
            this.Movement.Controls.Add(this.btnParkDome);
            this.Movement.Controls.Add(this.lblHomedState);
            this.Movement.Controls.Add(this.lblDisplayPos);
            this.Movement.Controls.Add(this.tbxGotoAz);
            this.Movement.Controls.Add(this.tbxGotoPos);
            this.Movement.Controls.Add(this.lblDisplayAz);
            this.Movement.Location = new System.Drawing.Point(416, 28);
            this.Movement.Name = "Movement";
            this.Movement.Size = new System.Drawing.Size(222, 377);
            this.Movement.TabIndex = 47;
            this.Movement.TabStop = false;
            this.Movement.Text = "Movement";
            // 
            // btnFullTurn
            // 
            this.btnFullTurn.Location = new System.Drawing.Point(5, 199);
            this.btnFullTurn.Name = "btnFullTurn";
            this.btnFullTurn.Size = new System.Drawing.Size(66, 27);
            this.btnFullTurn.TabIndex = 51;
            this.btnFullTurn.Text = "Full Turn";
            this.toolTip1.SetToolTip(this.btnFullTurn, "Number of steps required for a full rotation of the dome. At 8 microsteps that is" +
        " somewhere around 440000.");
            this.btnFullTurn.UseVisualStyleBackColor = true;
            this.btnFullTurn.Click += new System.EventHandler(this.btnFullTurn_Click);
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(5, 89);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(66, 27);
            this.btnSync.TabIndex = 39;
            this.btnSync.Text = "Sync Az";
            this.toolTip1.SetToolTip(this.btnSync, "Sets azimuth, usually to match telescope azimuth. Home switch azimuth will be aut" +
        "omatically adjusted to remain at the same relative position.");
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // btnSTOP
            // 
            this.btnSTOP.BackColor = System.Drawing.Color.Red;
            this.btnSTOP.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSTOP.Location = new System.Drawing.Point(56, 229);
            this.btnSTOP.Name = "btnSTOP";
            this.btnSTOP.Size = new System.Drawing.Size(109, 51);
            this.btnSTOP.TabIndex = 31;
            this.btnSTOP.Text = "STOP";
            this.toolTip1.SetToolTip(this.btnSTOP, "STOP!");
            this.btnSTOP.UseVisualStyleBackColor = false;
            this.btnSTOP.Click += new System.EventHandler(this.btnSTOP_Click);
            // 
            // lblMultiStatus
            // 
            this.lblMultiStatus.BackColor = System.Drawing.Color.White;
            this.lblMultiStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMultiStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMultiStatus.Location = new System.Drawing.Point(77, 141);
            this.lblMultiStatus.Name = "lblMultiStatus";
            this.lblMultiStatus.Size = new System.Drawing.Size(66, 26);
            this.lblMultiStatus.TabIndex = 30;
            this.lblMultiStatus.Text = "0";
            this.lblMultiStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.toolTip1.SetToolTip(this.lblMultiStatus, "Rotator state and direction.");
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnSaveSettings);
            this.groupBox4.Controls.Add(this.btnLoadSettings);
            this.groupBox4.Controls.Add(this.chkReversed);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.cbxStepMode);
            this.groupBox4.Controls.Add(this.btnMaxSpeed);
            this.groupBox4.Controls.Add(this.btnAcceleration);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.tbxMaxSpeed);
            this.groupBox4.Controls.Add(this.tbxAcceleration);
            this.groupBox4.Controls.Add(this.btnStepMode);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.tbxStepsPerRotation);
            this.groupBox4.Controls.Add(this.btnStepsPerRotation);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(12, 12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(193, 239);
            this.groupBox4.TabIndex = 48;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Stepper Settings";
            // 
            // btnSaveSettings
            // 
            this.btnSaveSettings.Location = new System.Drawing.Point(97, 199);
            this.btnSaveSettings.Name = "btnSaveSettings";
            this.btnSaveSettings.Size = new System.Drawing.Size(90, 34);
            this.btnSaveSettings.TabIndex = 43;
            this.btnSaveSettings.Text = "Save Settings";
            this.btnSaveSettings.UseVisualStyleBackColor = true;
            this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
            // 
            // btnLoadSettings
            // 
            this.btnLoadSettings.Location = new System.Drawing.Point(6, 199);
            this.btnLoadSettings.Name = "btnLoadSettings";
            this.btnLoadSettings.Size = new System.Drawing.Size(90, 34);
            this.btnLoadSettings.TabIndex = 50;
            this.btnLoadSettings.Text = "Load Settings";
            this.btnLoadSettings.UseVisualStyleBackColor = true;
            this.btnLoadSettings.Click += new System.EventHandler(this.btnLoadSettings_Click);
            // 
            // chkReversed
            // 
            this.chkReversed.AutoSize = true;
            this.chkReversed.Location = new System.Drawing.Point(6, 178);
            this.chkReversed.Name = "chkReversed";
            this.chkReversed.Size = new System.Drawing.Size(72, 17);
            this.chkReversed.TabIndex = 32;
            this.chkReversed.Text = "Reversed";
            this.toolTip1.SetToolTip(this.chkReversed, "If the dome is running in the opposite direction that it should be, change this s" +
        "etting.");
            this.chkReversed.UseVisualStyleBackColor = true;
            this.chkReversed.Click += new System.EventHandler(this.chkReversed_Click);
            // 
            // RotateTimer
            // 
            this.RotateTimer.Enabled = true;
            this.RotateTimer.Interval = 250;
            this.RotateTimer.Tick += new System.EventHandler(this.Rotate_Timer_Tick);
            // 
            // cbxUpdateRate
            // 
            this.cbxUpdateRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxUpdateRate.FormattingEnabled = true;
            this.cbxUpdateRate.Items.AddRange(new object[] {
            "500",
            "1000",
            "2000",
            "3000",
            "4000",
            "5000"});
            this.cbxUpdateRate.Location = new System.Drawing.Point(149, 32);
            this.cbxUpdateRate.Name = "cbxUpdateRate";
            this.cbxUpdateRate.Size = new System.Drawing.Size(64, 21);
            this.cbxUpdateRate.TabIndex = 51;
            this.toolTip1.SetToolTip(this.cbxUpdateRate, "Set to match dip switch settings on NexDome controller.");
            this.cbxUpdateRate.SelectedIndexChanged += new System.EventHandler(this.cbxUpdateRate_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 13);
            this.label2.TabIndex = 51;
            this.label2.Text = "Update Rate in milliseconds";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(656, 503);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.Movement);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PDM NexDome Configurator";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.Movement.ResumeLayout(false);
            this.Movement.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMaxSpeed;
        private System.Windows.Forms.ComboBox cbxStepMode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxMaxSpeed;
        private System.Windows.Forms.TextBox tbxAcceleration;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAcceleration;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnStepMode;
        private System.Windows.Forms.TextBox tbxStepsPerRotation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnStepsPerRotation;
        private System.Windows.Forms.Button btnRotateCCW;
        private System.Windows.Forms.Button btnRotateCW;
        private System.Windows.Forms.Button btnGoToAz;
        private System.Windows.Forms.Button btnGoToPos;
        private System.Windows.Forms.TextBox tbxGotoAz;
        private System.Windows.Forms.TextBox tbxGotoPos;
        private System.Windows.Forms.Label lblDisplayAz;
        private System.Windows.Forms.Label lblControllerVersion;
        private System.IO.Ports.SerialPort ArduinoPort;
        private System.Windows.Forms.ComboBox cbxPorts;
        private System.Windows.Forms.ComboBox cbxBaudRates;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox tbxTerminal;
        private System.Windows.Forms.TextBox tbxCommand;
        private System.Windows.Forms.Button btnCommand;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Timer ParseTimer;
        private System.Windows.Forms.Timer UpdateTimer;
        private System.Windows.Forms.Label lblDisplayPos;
        private System.Windows.Forms.TextBox tbxHomeAzimuth;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnHomeAzimuth;
        private System.Windows.Forms.TextBox tbxParkAzimuth;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnParkAzimuth;
        private System.Windows.Forms.Label lblRotVolts;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblShutVolts;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblCutVolts;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbxHomeCenter;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnHomeCenter;
        private System.Windows.Forms.Button btnParkDome;
        private System.Windows.Forms.Button btnDoHoming;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox Movement;
        private System.Windows.Forms.Button btnDoCalibrate;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblMultiStatus;
        private System.Windows.Forms.Button btnSTOP;
        private System.Windows.Forms.CheckBox chkReversed;
        private System.Windows.Forms.Button btnSaveSettings;
        private System.Windows.Forms.Label lblHomedState;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblSeekMode;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnLoadSettings;
        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.Timer RotateTimer;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnFullTurn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbxUpdateRate;
    }
}

