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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SetupForm));
            this.chkCanFindHome = new System.Windows.Forms.CheckBox();
            this.chkCanSetShutter = new System.Windows.Forms.CheckBox();
            this.chkCanSetAltitude = new System.Windows.Forms.CheckBox();
            this.chkCanPark = new System.Windows.Forms.CheckBox();
            this.chkCanSetPark = new System.Windows.Forms.CheckBox();
            this.chkCanSyncAz = new System.Windows.Forms.CheckBox();
            this.chkCanSetAzimuth = new System.Windows.Forms.CheckBox();
            this.gbxRotVersion = new System.Windows.Forms.GroupBox();
            this.btnRotatorSettings = new System.Windows.Forms.Button();
            this.lblRotatorVersion = new System.Windows.Forms.Label();
            this.lblVersionText1 = new System.Windows.Forms.Label();
            this.gbxCapabilities = new System.Windows.Forms.GroupBox();
            this.gbxShutVersion = new System.Windows.Forms.GroupBox();
            this.btnShutterSettings = new System.Windows.Forms.Button();
            this.lblShutterVersion = new System.Windows.Forms.Label();
            this.lblVersionText2 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.gbxRotVersion.SuspendLayout();
            this.gbxCapabilities.SuspendLayout();
            this.gbxShutVersion.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkCanFindHome
            // 
            resources.ApplyResources(this.chkCanFindHome, "chkCanFindHome");
            this.chkCanFindHome.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkCanFindHome.Name = "chkCanFindHome";
            this.chkCanFindHome.UseVisualStyleBackColor = true;
            this.chkCanFindHome.CheckedChanged += new System.EventHandler(this.chkBoxChanged);
            // 
            // chkCanSetShutter
            // 
            resources.ApplyResources(this.chkCanSetShutter, "chkCanSetShutter");
            this.chkCanSetShutter.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkCanSetShutter.Name = "chkCanSetShutter";
            this.chkCanSetShutter.UseVisualStyleBackColor = true;
            this.chkCanSetShutter.CheckedChanged += new System.EventHandler(this.chkBoxChanged);
            // 
            // chkCanSetAltitude
            // 
            resources.ApplyResources(this.chkCanSetAltitude, "chkCanSetAltitude");
            this.chkCanSetAltitude.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkCanSetAltitude.Name = "chkCanSetAltitude";
            this.chkCanSetAltitude.UseVisualStyleBackColor = true;
            this.chkCanSetAltitude.CheckedChanged += new System.EventHandler(this.chkBoxChanged);
            // 
            // chkCanPark
            // 
            resources.ApplyResources(this.chkCanPark, "chkCanPark");
            this.chkCanPark.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkCanPark.Name = "chkCanPark";
            this.chkCanPark.UseVisualStyleBackColor = true;
            this.chkCanPark.CheckedChanged += new System.EventHandler(this.chkBoxChanged);
            // 
            // chkCanSetPark
            // 
            resources.ApplyResources(this.chkCanSetPark, "chkCanSetPark");
            this.chkCanSetPark.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkCanSetPark.Name = "chkCanSetPark";
            this.chkCanSetPark.UseVisualStyleBackColor = true;
            this.chkCanSetPark.CheckedChanged += new System.EventHandler(this.chkBoxChanged);
            // 
            // chkCanSyncAz
            // 
            resources.ApplyResources(this.chkCanSyncAz, "chkCanSyncAz");
            this.chkCanSyncAz.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkCanSyncAz.Name = "chkCanSyncAz";
            this.chkCanSyncAz.UseVisualStyleBackColor = true;
            this.chkCanSyncAz.CheckedChanged += new System.EventHandler(this.chkBoxChanged);
            // 
            // chkCanSetAzimuth
            // 
            resources.ApplyResources(this.chkCanSetAzimuth, "chkCanSetAzimuth");
            this.chkCanSetAzimuth.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkCanSetAzimuth.Name = "chkCanSetAzimuth";
            this.chkCanSetAzimuth.UseVisualStyleBackColor = true;
            this.chkCanSetAzimuth.CheckedChanged += new System.EventHandler(this.chkBoxChanged);
            // 
            // gbxRotVersion
            // 
            this.gbxRotVersion.Controls.Add(this.btnRotatorSettings);
            this.gbxRotVersion.Controls.Add(this.lblRotatorVersion);
            this.gbxRotVersion.Controls.Add(this.lblVersionText1);
            resources.ApplyResources(this.gbxRotVersion, "gbxRotVersion");
            this.gbxRotVersion.Name = "gbxRotVersion";
            this.gbxRotVersion.TabStop = false;
            // 
            // btnRotatorSettings
            // 
            resources.ApplyResources(this.btnRotatorSettings, "btnRotatorSettings");
            this.btnRotatorSettings.Name = "btnRotatorSettings";
            this.btnRotatorSettings.UseVisualStyleBackColor = true;
            this.btnRotatorSettings.Click += new System.EventHandler(this.btnRotatorSettings_Click);
            // 
            // lblRotatorVersion
            // 
            this.lblRotatorVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lblRotatorVersion, "lblRotatorVersion");
            this.lblRotatorVersion.Name = "lblRotatorVersion";
            // 
            // lblVersionText1
            // 
            resources.ApplyResources(this.lblVersionText1, "lblVersionText1");
            this.lblVersionText1.Name = "lblVersionText1";
            // 
            // gbxCapabilities
            // 
            this.gbxCapabilities.Controls.Add(this.chkCanFindHome);
            this.gbxCapabilities.Controls.Add(this.chkCanSetPark);
            this.gbxCapabilities.Controls.Add(this.chkCanSyncAz);
            this.gbxCapabilities.Controls.Add(this.chkCanSetShutter);
            this.gbxCapabilities.Controls.Add(this.chkCanPark);
            this.gbxCapabilities.Controls.Add(this.chkCanSetAzimuth);
            this.gbxCapabilities.Controls.Add(this.chkCanSetAltitude);
            this.gbxCapabilities.ForeColor = System.Drawing.SystemColors.ControlText;
            resources.ApplyResources(this.gbxCapabilities, "gbxCapabilities");
            this.gbxCapabilities.Name = "gbxCapabilities";
            this.gbxCapabilities.TabStop = false;
            // 
            // gbxShutVersion
            // 
            this.gbxShutVersion.Controls.Add(this.btnShutterSettings);
            this.gbxShutVersion.Controls.Add(this.lblShutterVersion);
            this.gbxShutVersion.Controls.Add(this.lblVersionText2);
            resources.ApplyResources(this.gbxShutVersion, "gbxShutVersion");
            this.gbxShutVersion.Name = "gbxShutVersion";
            this.gbxShutVersion.TabStop = false;
            // 
            // btnShutterSettings
            // 
            resources.ApplyResources(this.btnShutterSettings, "btnShutterSettings");
            this.btnShutterSettings.Name = "btnShutterSettings";
            this.btnShutterSettings.UseVisualStyleBackColor = true;
            this.btnShutterSettings.Click += new System.EventHandler(this.btnShutterSettings_Click);
            // 
            // lblShutterVersion
            // 
            this.lblShutterVersion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.lblShutterVersion, "lblShutterVersion");
            this.lblShutterVersion.Name = "lblShutterVersion";
            // 
            // lblVersionText2
            // 
            resources.ApplyResources(this.lblVersionText2, "lblVersionText2");
            this.lblVersionText2.Name = "lblVersionText2";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            resources.ApplyResources(this.btnCancel, "btnCancel");
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.Name = "btnSave";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // SetupForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ControlBox = false;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbxShutVersion);
            this.Controls.Add(this.gbxRotVersion);
            this.Controls.Add(this.gbxCapabilities);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "SetupForm";
            this.Load += new System.EventHandler(this.SetupForm_Load);
            this.gbxRotVersion.ResumeLayout(false);
            this.gbxRotVersion.PerformLayout();
            this.gbxCapabilities.ResumeLayout(false);
            this.gbxCapabilities.PerformLayout();
            this.gbxShutVersion.ResumeLayout(false);
            this.gbxShutVersion.PerformLayout();
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
        private System.Windows.Forms.GroupBox gbxRotVersion;
        private System.Windows.Forms.GroupBox gbxCapabilities;
        private System.Windows.Forms.Button btnRotatorSettings;
        private System.Windows.Forms.Label lblRotatorVersion;
        private System.Windows.Forms.Label lblVersionText1;
        private System.Windows.Forms.GroupBox gbxShutVersion;
        private System.Windows.Forms.Button btnShutterSettings;
        private System.Windows.Forms.Label lblShutterVersion;
        private System.Windows.Forms.Label lblVersionText2;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}