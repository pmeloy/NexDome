namespace ASCOM.PDM
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
            this.chkCanFindHome = new System.Windows.Forms.CheckBox();
            this.chkCanSetShutter = new System.Windows.Forms.CheckBox();
            this.chkCanSetAltitude = new System.Windows.Forms.CheckBox();
            this.chkCanPark = new System.Windows.Forms.CheckBox();
            this.chkCanSetPark = new System.Windows.Forms.CheckBox();
            this.chkCanSyncAz = new System.Windows.Forms.CheckBox();
            this.chkCanSetAzimuth = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRotatorSettings = new System.Windows.Forms.Button();
            this.lblRotatorVersion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gbxShutter = new System.Windows.Forms.GroupBox();
            this.btnShutterSettings = new System.Windows.Forms.Button();
            this.lblShutterVersion = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbxShutter.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkCanFindHome
            // 
            this.chkCanFindHome.AutoSize = true;
            this.chkCanFindHome.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkCanFindHome.Location = new System.Drawing.Point(6, 19);
            this.chkCanFindHome.Name = "chkCanFindHome";
            this.chkCanFindHome.Size = new System.Drawing.Size(99, 17);
            this.chkCanFindHome.TabIndex = 0;
            this.chkCanFindHome.Text = "Can Find Home";
            this.chkCanFindHome.UseVisualStyleBackColor = true;
            this.chkCanFindHome.CheckedChanged += new System.EventHandler(this.chkBoxChanged);
            // 
            // chkCanSetShutter
            // 
            this.chkCanSetShutter.AutoSize = true;
            this.chkCanSetShutter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkCanSetShutter.Location = new System.Drawing.Point(234, 19);
            this.chkCanSetShutter.Name = "chkCanSetShutter";
            this.chkCanSetShutter.Size = new System.Drawing.Size(101, 17);
            this.chkCanSetShutter.TabIndex = 1;
            this.chkCanSetShutter.Text = "Can Set Shutter";
            this.chkCanSetShutter.UseVisualStyleBackColor = true;
            this.chkCanSetShutter.CheckedChanged += new System.EventHandler(this.chkBoxChanged);
            // 
            // chkCanSetAltitude
            // 
            this.chkCanSetAltitude.AutoSize = true;
            this.chkCanSetAltitude.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkCanSetAltitude.Location = new System.Drawing.Point(234, 42);
            this.chkCanSetAltitude.Name = "chkCanSetAltitude";
            this.chkCanSetAltitude.Size = new System.Drawing.Size(102, 17);
            this.chkCanSetAltitude.TabIndex = 6;
            this.chkCanSetAltitude.Text = "Can Set Altitude";
            this.chkCanSetAltitude.UseVisualStyleBackColor = true;
            this.chkCanSetAltitude.CheckedChanged += new System.EventHandler(this.chkBoxChanged);
            // 
            // chkCanPark
            // 
            this.chkCanPark.AutoSize = true;
            this.chkCanPark.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkCanPark.Location = new System.Drawing.Point(6, 42);
            this.chkCanPark.Name = "chkCanPark";
            this.chkCanPark.Size = new System.Drawing.Size(70, 17);
            this.chkCanPark.TabIndex = 2;
            this.chkCanPark.Text = "Can Park";
            this.chkCanPark.UseVisualStyleBackColor = true;
            this.chkCanPark.CheckedChanged += new System.EventHandler(this.chkBoxChanged);
            // 
            // chkCanSetPark
            // 
            this.chkCanSetPark.AutoSize = true;
            this.chkCanSetPark.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkCanSetPark.Location = new System.Drawing.Point(6, 65);
            this.chkCanSetPark.Name = "chkCanSetPark";
            this.chkCanSetPark.Size = new System.Drawing.Size(89, 17);
            this.chkCanSetPark.TabIndex = 3;
            this.chkCanSetPark.Text = "Can Set Park";
            this.chkCanSetPark.UseVisualStyleBackColor = true;
            this.chkCanSetPark.CheckedChanged += new System.EventHandler(this.chkBoxChanged);
            // 
            // chkCanSyncAz
            // 
            this.chkCanSyncAz.AutoSize = true;
            this.chkCanSyncAz.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkCanSyncAz.Location = new System.Drawing.Point(116, 42);
            this.chkCanSyncAz.Name = "chkCanSyncAz";
            this.chkCanSyncAz.Size = new System.Drawing.Size(112, 17);
            this.chkCanSyncAz.TabIndex = 5;
            this.chkCanSyncAz.Text = "Can Sync Azimuth";
            this.chkCanSyncAz.UseVisualStyleBackColor = true;
            this.chkCanSyncAz.CheckedChanged += new System.EventHandler(this.chkBoxChanged);
            // 
            // chkCanSetAzimuth
            // 
            this.chkCanSetAzimuth.AutoSize = true;
            this.chkCanSetAzimuth.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkCanSetAzimuth.Location = new System.Drawing.Point(116, 19);
            this.chkCanSetAzimuth.Name = "chkCanSetAzimuth";
            this.chkCanSetAzimuth.Size = new System.Drawing.Size(104, 17);
            this.chkCanSetAzimuth.TabIndex = 4;
            this.chkCanSetAzimuth.Text = "Can Set Azimuth";
            this.chkCanSetAzimuth.UseVisualStyleBackColor = true;
            this.chkCanSetAzimuth.CheckedChanged += new System.EventHandler(this.chkBoxChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRotatorSettings);
            this.groupBox1.Controls.Add(this.lblRotatorVersion);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 42);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rotator";
            // 
            // btnRotatorSettings
            // 
            this.btnRotatorSettings.Location = new System.Drawing.Point(109, 11);
            this.btnRotatorSettings.Name = "btnRotatorSettings";
            this.btnRotatorSettings.Size = new System.Drawing.Size(57, 23);
            this.btnRotatorSettings.TabIndex = 9;
            this.btnRotatorSettings.Text = "Settings";
            this.btnRotatorSettings.UseVisualStyleBackColor = true;
            this.btnRotatorSettings.Click += new System.EventHandler(this.btnRotatorSettings_Click);
            // 
            // lblRotatorVersion
            // 
            this.lblRotatorVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblRotatorVersion.Location = new System.Drawing.Point(54, 15);
            this.lblRotatorVersion.Name = "lblRotatorVersion";
            this.lblRotatorVersion.Size = new System.Drawing.Size(49, 16);
            this.lblRotatorVersion.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Version";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.chkCanFindHome);
            this.groupBox3.Controls.Add(this.chkCanSetPark);
            this.groupBox3.Controls.Add(this.chkCanSyncAz);
            this.groupBox3.Controls.Add(this.chkCanSetShutter);
            this.groupBox3.Controls.Add(this.chkCanPark);
            this.groupBox3.Controls.Add(this.chkCanSetAzimuth);
            this.groupBox3.Controls.Add(this.chkCanSetAltitude);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox3.Location = new System.Drawing.Point(12, 61);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(358, 91);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Capabilities (Sets Immediately";
            // 
            // gbxShutter
            // 
            this.gbxShutter.Controls.Add(this.btnShutterSettings);
            this.gbxShutter.Controls.Add(this.lblShutterVersion);
            this.gbxShutter.Controls.Add(this.label4);
            this.gbxShutter.Location = new System.Drawing.Point(194, 13);
            this.gbxShutter.Name = "gbxShutter";
            this.gbxShutter.Size = new System.Drawing.Size(176, 42);
            this.gbxShutter.TabIndex = 11;
            this.gbxShutter.TabStop = false;
            this.gbxShutter.Text = "Shutter";
            // 
            // btnShutterSettings
            // 
            this.btnShutterSettings.Location = new System.Drawing.Point(109, 11);
            this.btnShutterSettings.Name = "btnShutterSettings";
            this.btnShutterSettings.Size = new System.Drawing.Size(57, 23);
            this.btnShutterSettings.TabIndex = 9;
            this.btnShutterSettings.Text = "Settings";
            this.btnShutterSettings.UseVisualStyleBackColor = true;
            this.btnShutterSettings.Click += new System.EventHandler(this.btnShutterSettings_Click);
            // 
            // lblShutterVersion
            // 
            this.lblShutterVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblShutterVersion.Location = new System.Drawing.Point(54, 15);
            this.lblShutterVersion.Name = "lblShutterVersion";
            this.lblShutterVersion.Size = new System.Drawing.Size(49, 16);
            this.lblShutterVersion.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Version";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(313, 158);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(57, 23);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(250, 158);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(57, 23);
            this.btnSave.TabIndex = 12;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // SetupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(383, 189);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbxShutter);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Name = "SetupForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SetupForm";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbxShutter.ResumeLayout(false);
            this.gbxShutter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox chkCanFindHome;
        private System.Windows.Forms.CheckBox chkCanSetShutter;
        private System.Windows.Forms.CheckBox chkCanSetAltitude;
        private System.Windows.Forms.CheckBox chkCanPark;
        private System.Windows.Forms.CheckBox chkCanSetPark;
        private System.Windows.Forms.CheckBox chkCanSyncAz;
        private System.Windows.Forms.CheckBox chkCanSetAzimuth;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnRotatorSettings;
        private System.Windows.Forms.Label lblRotatorVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox gbxShutter;
        private System.Windows.Forms.Button btnShutterSettings;
        private System.Windows.Forms.Label lblShutterVersion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}