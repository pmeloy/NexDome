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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblLowWarn = new System.Windows.Forms.Label();
            this.tbxCutoff = new System.Windows.Forms.TextBox();
            this.btnSetCutoff = new System.Windows.Forms.Button();
            this.lblVoltage = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.lblAltitude = new System.Windows.Forms.Label();
            this.btnSTOP = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
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
            this.groupBox2.TabIndex = 51;
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
            this.groupBox1.TabIndex = 50;
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
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lblStatus);
            this.groupBox3.Controls.Add(this.lblAltitude);
            this.groupBox3.Controls.Add(this.btnSTOP);
            this.groupBox3.Controls.Add(this.btnClose);
            this.groupBox3.Controls.Add(this.btnOpen);
            this.groupBox3.Location = new System.Drawing.Point(181, 13);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(123, 210);
            this.groupBox3.TabIndex = 52;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Movement";
            // 
            // lblStatus
            // 
            this.lblStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStatus.Location = new System.Drawing.Point(23, 50);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(75, 19);
            this.lblStatus.TabIndex = 49;
            this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblAltitude
            // 
            this.lblAltitude.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblAltitude.Location = new System.Drawing.Point(35, 76);
            this.lblAltitude.Name = "lblAltitude";
            this.lblAltitude.Size = new System.Drawing.Size(51, 19);
            this.lblAltitude.TabIndex = 48;
            this.lblAltitude.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSTOP
            // 
            this.btnSTOP.BackColor = System.Drawing.Color.Red;
            this.btnSTOP.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSTOP.Location = new System.Drawing.Point(6, 127);
            this.btnSTOP.Name = "btnSTOP";
            this.btnSTOP.Size = new System.Drawing.Size(109, 51);
            this.btnSTOP.TabIndex = 32;
            this.btnSTOP.Text = "STOP";
            this.btnSTOP.UseVisualStyleBackColor = false;
            this.btnSTOP.Click += new System.EventHandler(this.btnSTOP_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(23, 98);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(23, 24);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(75, 23);
            this.btnOpen.TabIndex = 0;
            this.btnOpen.Text = "Open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Location = new System.Drawing.Point(229, 232);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 49;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // ShutterSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(316, 267);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ShutterSetup";
            this.Text = "ShutterSetup";
            this.Load += new System.EventHandler(this.ShutterSetup_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblLowWarn;
        private System.Windows.Forms.TextBox tbxCutoff;
        private System.Windows.Forms.Button btnSetCutoff;
        private System.Windows.Forms.Label lblVoltage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
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
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label lblAltitude;
        private System.Windows.Forms.Button btnSTOP;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblStatus;
    }
}