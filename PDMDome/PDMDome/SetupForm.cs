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
    public partial class SetupForm : Form
    {
        internal Dome myDome;
        private bool doneLoading = false;

        public SetupForm()
        {
            InitializeComponent();
            InitUI();
        }

        private void SetupForm_Load(object sender, EventArgs e)
        {
            this.Text = myDome.DriverInfo;
            doneLoading = true;
        }

        private void InitUI()
        {
            gbxRotVersion.Text = GlobalStrings.RotatorText;
            gbxShutVersion.Text = GlobalStrings.ShutterText;
            gbxCapabilities.Text = GlobalStrings.CapabilitiesText;
            lblVersionText1.Text = GlobalStrings.VersionText;
            lblVersionText2.Text = GlobalStrings.VersionText;
            btnRotatorSettings.Text = GlobalStrings.SettingsText;
            btnShutterSettings.Text = GlobalStrings.SettingsText;
            btnSave.Text = GlobalStrings.SaveText;
            btnCancel.Text = GlobalStrings.CancelText;
            chkCanFindHome.Text = GlobalStrings.CanFindHomeText;
            chkCanPark.Text = GlobalStrings.CanParkText;
            chkCanSetAltitude.Text = GlobalStrings.CanSetAltitudeText;
            chkCanSetAzimuth.Text = GlobalStrings.CanSetAzimuthText;
            chkCanSetPark.Text = GlobalStrings.CanSetParkText;
            chkCanSetShutter.Text = GlobalStrings.CanSetShutterText;
            chkCanSyncAz.Text = GlobalStrings.CanSyncAzimuthText;

            chkCanFindHome.Checked = Dome.canFindHome;
            chkCanPark.Checked = Dome.canPark;
            chkCanSetAltitude.Checked = Dome.canSetAltitude;
            chkCanSetAzimuth.Checked = Dome.canSetAzimuth;
            chkCanSetPark.Checked = Dome.canSetPark;
            chkCanSetShutter.Checked = Dome.canSetShutter;
            chkCanSyncAz.Checked = Dome.canSyncAzimuth;

            lblRotatorVersion.Text = Dome.rotatorVersion;

            SetShutterBox(Dome.canSetShutter);
        }

        #region "CheckBox Changes"

        private void chkBoxChanged(object sender, EventArgs e)
        {
            if (doneLoading == true)
            {
                btnSave.Enabled = true;
                btnRotatorSettings.Enabled = false;
                btnShutterSettings.Enabled = false;
            }
        }

        #endregion

        private void SetShutterBox(bool enabled)
        {
            
            if (enabled == true)
            {
                lblShutterVersion.Text = Dome.shutterVersion;
            }
            else
            {
                lblShutterVersion.Text = "N/A";
            }
            gbxShutVersion.Enabled = enabled;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Dome.canFindHome = chkCanFindHome.Checked;
            Dome.canPark = chkCanPark.Checked;
            Dome.canSetAltitude = chkCanSetAltitude.Checked;
            Dome.canSetAzimuth = chkCanSetAzimuth.Checked;
            Dome.canSetPark = chkCanSetPark.Checked;
            Dome.canSetShutter = chkCanSetShutter.Checked;
            Dome.canSyncAzimuth = chkCanSyncAz.Checked;
        }

        private void btnRotatorSettings_Click(object sender, EventArgs e)
        {
            using (RotatorSetup F = new RotatorSetup())
            {
                F.myDome = myDome;
                F.ShowDialog();
            }
        }

        private void btnShutterSettings_Click(object sender, EventArgs e)
        {
            using (ShutterSetup F = new ShutterSetup())
            {
                Dome.tl.LogMessage("Setup Show", "Shutter");
                F.myDome = myDome;
                F.ShowDialog();
            }
        }
    }
}
