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
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkReversed = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMaxSpeed = new System.Windows.Forms.Button();
            this.btnAcceleration = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tbxMaxSpeed = new System.Windows.Forms.TextBox();
            this.tbxAcceleration = new System.Windows.Forms.TextBox();
            this.tbxStepsPerRotation = new System.Windows.Forms.TextBox();
            this.btnStepsPerRotation = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.Movement = new System.Windows.Forms.GroupBox();
            this.btnFullTurn = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.btnSync = new System.Windows.Forms.Button();
            this.lblSeekMode = new System.Windows.Forms.Label();
            this.btnSTOP = new System.Windows.Forms.Button();
            this.btnCalibrate = new System.Windows.Forms.Button();
            this.lblMultiStatus = new System.Windows.Forms.Label();
            this.btnGoToAz = new System.Windows.Forms.Button();
            this.btnRotateCCW = new System.Windows.Forms.Button();
            this.btnRotateCW = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.btnGoToPos = new System.Windows.Forms.Button();
            this.btnHome = new System.Windows.Forms.Button();
            this.btnPark = new System.Windows.Forms.Button();
            this.lblHomedState = new System.Windows.Forms.Label();
            this.lblPosition = new System.Windows.Forms.Label();
            this.tbxGotoAz = new System.Windows.Forms.TextBox();
            this.tbxGotoPos = new System.Windows.Forms.TextBox();
            this.lblAzimuth = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblLowWarn = new System.Windows.Forms.Label();
            this.tbxCutoff = new System.Windows.Forms.TextBox();
            this.btnSetCutoff = new System.Windows.Forms.Button();
            this.lblVoltage = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSetHome = new System.Windows.Forms.Button();
            this.btnSetPark = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tbxHomeAz = new System.Windows.Forms.TextBox();
            this.tbxParkAz = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox1.SuspendLayout();
            this.Movement.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(387, 366);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(57, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Exit";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkReversed);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnMaxSpeed);
            this.groupBox1.Controls.Add(this.btnAcceleration);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tbxMaxSpeed);
            this.groupBox1.Controls.Add(this.tbxAcceleration);
            this.groupBox1.Controls.Add(this.tbxStepsPerRotation);
            this.groupBox1.Controls.Add(this.btnStepsPerRotation);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 89);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(162, 167);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Motor Settings";
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 34;
            this.label1.Text = "Max Speed";
            // 
            // btnMaxSpeed
            // 
            this.btnMaxSpeed.Location = new System.Drawing.Point(84, 34);
            this.btnMaxSpeed.Name = "btnMaxSpeed";
            this.btnMaxSpeed.Size = new System.Drawing.Size(65, 23);
            this.btnMaxSpeed.TabIndex = 33;
            this.btnMaxSpeed.Text = "Set";
            this.btnMaxSpeed.UseVisualStyleBackColor = true;
            this.btnMaxSpeed.Click += new System.EventHandler(this.btnMaxSpeed_Click);
            // 
            // btnAcceleration
            // 
            this.btnAcceleration.Location = new System.Drawing.Point(84, 73);
            this.btnAcceleration.Name = "btnAcceleration";
            this.btnAcceleration.Size = new System.Drawing.Size(65, 23);
            this.btnAcceleration.TabIndex = 36;
            this.btnAcceleration.Text = "Set";
            this.btnAcceleration.UseVisualStyleBackColor = true;
            this.btnAcceleration.Click += new System.EventHandler(this.btnAcceleration_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 37;
            this.label3.Text = "Acceleration";
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
            this.btnStepsPerRotation.Location = new System.Drawing.Point(84, 112);
            this.btnStepsPerRotation.Name = "btnStepsPerRotation";
            this.btnStepsPerRotation.Size = new System.Drawing.Size(65, 23);
            this.btnStepsPerRotation.TabIndex = 39;
            this.btnStepsPerRotation.Text = "Set";
            this.btnStepsPerRotation.UseVisualStyleBackColor = true;
            this.btnStepsPerRotation.Click += new System.EventHandler(this.btnStepsPerRotation_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "Steps per";
            // 
            // Movement
            // 
            this.Movement.Controls.Add(this.btnFullTurn);
            this.Movement.Controls.Add(this.label16);
            this.Movement.Controls.Add(this.btnSync);
            this.Movement.Controls.Add(this.lblSeekMode);
            this.Movement.Controls.Add(this.btnSTOP);
            this.Movement.Controls.Add(this.btnCalibrate);
            this.Movement.Controls.Add(this.lblMultiStatus);
            this.Movement.Controls.Add(this.btnGoToAz);
            this.Movement.Controls.Add(this.btnRotateCCW);
            this.Movement.Controls.Add(this.btnRotateCW);
            this.Movement.Controls.Add(this.label15);
            this.Movement.Controls.Add(this.btnGoToPos);
            this.Movement.Controls.Add(this.btnHome);
            this.Movement.Controls.Add(this.btnPark);
            this.Movement.Controls.Add(this.lblHomedState);
            this.Movement.Controls.Add(this.lblPosition);
            this.Movement.Controls.Add(this.tbxGotoAz);
            this.Movement.Controls.Add(this.tbxGotoPos);
            this.Movement.Controls.Add(this.lblAzimuth);
            this.Movement.Location = new System.Drawing.Point(180, 12);
            this.Movement.Name = "Movement";
            this.Movement.Size = new System.Drawing.Size(264, 347);
            this.Movement.TabIndex = 48;
            this.Movement.TabStop = false;
            this.Movement.Text = "Movement";
            // 
            // btnFullTurn
            // 
            this.btnFullTurn.Location = new System.Drawing.Point(6, 154);
            this.btnFullTurn.Name = "btnFullTurn";
            this.btnFullTurn.Size = new System.Drawing.Size(66, 27);
            this.btnFullTurn.TabIndex = 51;
            this.btnFullTurn.Text = "Full Turn";
            this.btnFullTurn.UseVisualStyleBackColor = true;
            this.btnFullTurn.Click += new System.EventHandler(this.btnFullTurn_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(7, 308);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(62, 13);
            this.label16.TabIndex = 52;
            this.label16.Text = "Seek Mode";
            // 
            // btnSync
            // 
            this.btnSync.Location = new System.Drawing.Point(6, 44);
            this.btnSync.Name = "btnSync";
            this.btnSync.Size = new System.Drawing.Size(66, 27);
            this.btnSync.TabIndex = 39;
            this.btnSync.Text = "Sync Az";
            this.btnSync.UseVisualStyleBackColor = true;
            this.btnSync.Click += new System.EventHandler(this.btnSync_Click);
            // 
            // lblSeekMode
            // 
            this.lblSeekMode.BackColor = System.Drawing.Color.White;
            this.lblSeekMode.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblSeekMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeekMode.Location = new System.Drawing.Point(140, 301);
            this.lblSeekMode.Name = "lblSeekMode";
            this.lblSeekMode.Size = new System.Drawing.Size(100, 20);
            this.lblSeekMode.TabIndex = 50;
            this.lblSeekMode.Text = "0";
            this.lblSeekMode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSTOP
            // 
            this.btnSTOP.BackColor = System.Drawing.Color.Red;
            this.btnSTOP.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSTOP.Location = new System.Drawing.Point(69, 184);
            this.btnSTOP.Name = "btnSTOP";
            this.btnSTOP.Size = new System.Drawing.Size(109, 51);
            this.btnSTOP.TabIndex = 31;
            this.btnSTOP.Text = "STOP";
            this.btnSTOP.UseVisualStyleBackColor = false;
            this.btnSTOP.Click += new System.EventHandler(this.btnSTOP_Click);
            // 
            // btnCalibrate
            // 
            this.btnCalibrate.Location = new System.Drawing.Point(175, 241);
            this.btnCalibrate.Name = "btnCalibrate";
            this.btnCalibrate.Size = new System.Drawing.Size(65, 23);
            this.btnCalibrate.TabIndex = 42;
            this.btnCalibrate.Text = "Calibrate";
            this.btnCalibrate.UseVisualStyleBackColor = true;
            this.btnCalibrate.Click += new System.EventHandler(this.btnCalibrate_Click);
            // 
            // lblMultiStatus
            // 
            this.lblMultiStatus.BackColor = System.Drawing.Color.White;
            this.lblMultiStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblMultiStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMultiStatus.Location = new System.Drawing.Point(90, 96);
            this.lblMultiStatus.Name = "lblMultiStatus";
            this.lblMultiStatus.Size = new System.Drawing.Size(66, 26);
            this.lblMultiStatus.TabIndex = 30;
            this.lblMultiStatus.Text = "---";
            this.lblMultiStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnGoToAz
            // 
            this.btnGoToAz.Location = new System.Drawing.Point(174, 43);
            this.btnGoToAz.Name = "btnGoToAz";
            this.btnGoToAz.Size = new System.Drawing.Size(66, 27);
            this.btnGoToAz.TabIndex = 15;
            this.btnGoToAz.Text = "Go to Az";
            this.btnGoToAz.UseVisualStyleBackColor = true;
            this.btnGoToAz.Click += new System.EventHandler(this.btnGotoAz_Click);
            // 
            // btnRotateCCW
            // 
            this.btnRotateCCW.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRotateCCW.Location = new System.Drawing.Point(6, 72);
            this.btnRotateCCW.Name = "btnRotateCCW";
            this.btnRotateCCW.Size = new System.Drawing.Size(66, 79);
            this.btnRotateCCW.TabIndex = 13;
            this.btnRotateCCW.Text = "<";
            this.btnRotateCCW.UseVisualStyleBackColor = true;
            this.btnRotateCCW.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRotateCCW_MouseDown);
            this.btnRotateCCW.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnRotate_UP);
            // 
            // btnRotateCW
            // 
            this.btnRotateCW.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRotateCW.Location = new System.Drawing.Point(174, 72);
            this.btnRotateCW.Name = "btnRotateCW";
            this.btnRotateCW.Size = new System.Drawing.Size(66, 77);
            this.btnRotateCW.TabIndex = 14;
            this.btnRotateCW.Text = ">";
            this.btnRotateCW.UseVisualStyleBackColor = true;
            this.btnRotateCW.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnRotateCW_MouseDown);
            this.btnRotateCW.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnRotate_UP);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(7, 284);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(68, 13);
            this.label15.TabIndex = 51;
            this.label15.Text = "Home Status";
            // 
            // btnGoToPos
            // 
            this.btnGoToPos.Location = new System.Drawing.Point(174, 154);
            this.btnGoToPos.Name = "btnGoToPos";
            this.btnGoToPos.Size = new System.Drawing.Size(66, 27);
            this.btnGoToPos.TabIndex = 16;
            this.btnGoToPos.Text = "Go to Pos";
            this.btnGoToPos.UseVisualStyleBackColor = true;
            this.btnGoToPos.Click += new System.EventHandler(this.btnGoToPos_Click);
            // 
            // btnHome
            // 
            this.btnHome.Location = new System.Drawing.Point(6, 241);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(65, 23);
            this.btnHome.TabIndex = 37;
            this.btnHome.Text = "Home";
            this.btnHome.UseVisualStyleBackColor = true;
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnPark
            // 
            this.btnPark.Location = new System.Drawing.Point(87, 14);
            this.btnPark.Name = "btnPark";
            this.btnPark.Size = new System.Drawing.Size(72, 23);
            this.btnPark.TabIndex = 38;
            this.btnPark.Text = "Park";
            this.btnPark.UseVisualStyleBackColor = true;
            this.btnPark.Click += new System.EventHandler(this.btnPark_Click);
            // 
            // lblHomedState
            // 
            this.lblHomedState.BackColor = System.Drawing.Color.White;
            this.lblHomedState.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblHomedState.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHomedState.Location = new System.Drawing.Point(140, 277);
            this.lblHomedState.Name = "lblHomedState";
            this.lblHomedState.Size = new System.Drawing.Size(100, 20);
            this.lblHomedState.TabIndex = 32;
            this.lblHomedState.Text = "0";
            this.lblHomedState.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPosition
            // 
            this.lblPosition.BackColor = System.Drawing.Color.White;
            this.lblPosition.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblPosition.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPosition.Location = new System.Drawing.Point(90, 125);
            this.lblPosition.Name = "lblPosition";
            this.lblPosition.Size = new System.Drawing.Size(66, 26);
            this.lblPosition.TabIndex = 29;
            this.lblPosition.Text = "0";
            this.lblPosition.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbxGotoAz
            // 
            this.tbxGotoAz.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxGotoAz.Location = new System.Drawing.Point(90, 43);
            this.tbxGotoAz.Name = "tbxGotoAz";
            this.tbxGotoAz.Size = new System.Drawing.Size(66, 26);
            this.tbxGotoAz.TabIndex = 17;
            this.tbxGotoAz.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxGotoPos
            // 
            this.tbxGotoPos.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxGotoPos.Location = new System.Drawing.Point(90, 154);
            this.tbxGotoPos.Name = "tbxGotoPos";
            this.tbxGotoPos.Size = new System.Drawing.Size(66, 26);
            this.tbxGotoPos.TabIndex = 18;
            this.tbxGotoPos.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblAzimuth
            // 
            this.lblAzimuth.BackColor = System.Drawing.Color.White;
            this.lblAzimuth.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblAzimuth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAzimuth.Location = new System.Drawing.Point(90, 72);
            this.lblAzimuth.Name = "lblAzimuth";
            this.lblAzimuth.Size = new System.Drawing.Size(66, 26);
            this.lblAzimuth.TabIndex = 19;
            this.lblAzimuth.Text = "0";
            this.lblAzimuth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblLowWarn);
            this.groupBox2.Controls.Add(this.tbxCutoff);
            this.groupBox2.Controls.Add(this.btnSetCutoff);
            this.groupBox2.Controls.Add(this.lblVoltage);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(162, 71);
            this.groupBox2.TabIndex = 49;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Voltage";
            // 
            // lblLowWarn
            // 
            this.lblLowWarn.BackColor = System.Drawing.Color.Red;
            this.lblLowWarn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblLowWarn.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblLowWarn.Location = new System.Drawing.Point(112, 18);
            this.lblLowWarn.Name = "lblLowWarn";
            this.lblLowWarn.Size = new System.Drawing.Size(44, 19);
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
            this.btnSetCutoff.Size = new System.Drawing.Size(44, 23);
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
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 46;
            this.label4.Text = "CutOff";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 45;
            this.label2.Text = "Voltage";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.btnSetHome);
            this.groupBox3.Controls.Add(this.btnSetPark);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.tbxHomeAz);
            this.groupBox3.Controls.Add(this.tbxParkAz);
            this.groupBox3.Location = new System.Drawing.Point(12, 262);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(162, 97);
            this.groupBox3.TabIndex = 50;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Home and Park";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 40;
            this.label6.Text = "Home";
            // 
            // btnSetHome
            // 
            this.btnSetHome.Location = new System.Drawing.Point(84, 30);
            this.btnSetHome.Name = "btnSetHome";
            this.btnSetHome.Size = new System.Drawing.Size(65, 23);
            this.btnSetHome.TabIndex = 39;
            this.btnSetHome.Text = "Set";
            this.btnSetHome.UseVisualStyleBackColor = true;
            this.btnSetHome.Click += new System.EventHandler(this.btnSetHome_Click);
            // 
            // btnSetPark
            // 
            this.btnSetPark.Location = new System.Drawing.Point(84, 69);
            this.btnSetPark.Name = "btnSetPark";
            this.btnSetPark.Size = new System.Drawing.Size(65, 23);
            this.btnSetPark.TabIndex = 42;
            this.btnSetPark.Text = "Set";
            this.btnSetPark.UseVisualStyleBackColor = true;
            this.btnSetPark.Click += new System.EventHandler(this.btnSetPark_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 55);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 43;
            this.label7.Text = "Park";
            // 
            // tbxHomeAz
            // 
            this.tbxHomeAz.Location = new System.Drawing.Point(6, 32);
            this.tbxHomeAz.Name = "tbxHomeAz";
            this.tbxHomeAz.Size = new System.Drawing.Size(72, 20);
            this.tbxHomeAz.TabIndex = 41;
            this.tbxHomeAz.Text = "0";
            // 
            // tbxParkAz
            // 
            this.tbxParkAz.Location = new System.Drawing.Point(6, 71);
            this.tbxParkAz.Name = "tbxParkAz";
            this.tbxParkAz.Size = new System.Drawing.Size(72, 20);
            this.tbxParkAz.TabIndex = 44;
            this.tbxParkAz.Text = "0";
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
            // RotatorSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 401);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.Movement);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Name = "RotatorSetup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "RotatorSetup";
            this.Load += new System.EventHandler(this.RotatorSetup_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Movement.ResumeLayout(false);
            this.Movement.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkReversed;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMaxSpeed;
        private System.Windows.Forms.Button btnAcceleration;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbxMaxSpeed;
        private System.Windows.Forms.TextBox tbxAcceleration;
        private System.Windows.Forms.TextBox tbxStepsPerRotation;
        private System.Windows.Forms.Button btnStepsPerRotation;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox Movement;
        private System.Windows.Forms.Button btnFullTurn;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btnSync;
        private System.Windows.Forms.Label lblSeekMode;
        private System.Windows.Forms.Button btnSTOP;
        private System.Windows.Forms.Button btnCalibrate;
        private System.Windows.Forms.Label lblMultiStatus;
        private System.Windows.Forms.Button btnGoToAz;
        private System.Windows.Forms.Button btnRotateCCW;
        private System.Windows.Forms.Button btnRotateCW;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnGoToPos;
        private System.Windows.Forms.Button btnHome;
        private System.Windows.Forms.Button btnPark;
        private System.Windows.Forms.Label lblHomedState;
        private System.Windows.Forms.Label lblPosition;
        private System.Windows.Forms.TextBox tbxGotoAz;
        private System.Windows.Forms.TextBox tbxGotoPos;
        private System.Windows.Forms.Label lblAzimuth;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnSetHome;
        private System.Windows.Forms.Button btnSetPark;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbxHomeAz;
        private System.Windows.Forms.TextBox tbxParkAz;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnSetCutoff;
        private System.Windows.Forms.Label lblVoltage;
        private System.Windows.Forms.TextBox tbxCutoff;
        private System.Windows.Forms.Label lblLowWarn;
    }
}