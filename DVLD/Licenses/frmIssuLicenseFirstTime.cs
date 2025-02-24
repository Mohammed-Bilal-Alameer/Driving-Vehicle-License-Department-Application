using DVLD.Login;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Licenses
{
    public partial class frmIssuLicenseFirstTime : Form
    {
        int _LocalAppID;
        clsLicenseBusniess _NewLicense;
        clsDriverBusiness _NewDriver;
        clsLocalDrivingApplicationsBusiness _LDLApp;
        int _DriverID;
        public frmIssuLicenseFirstTime(int localAppID)
        {
            InitializeComponent();
            _LocalAppID = localAppID;
        }

        private void frmIssuLicenseFirstTime_Load(object sender, EventArgs e)
        {
            _LDLApp = clsLocalDrivingApplicationsBusiness.Find(_LocalAppID);



            if (_LDLApp == null)
            {
                MessageBox.Show("No Applicaiton with ID=" + _LocalAppID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }

            if (clsTestApplointmentsBusiness.GetPassedTests(_LocalAppID,true) != 3)
            {
                MessageBox.Show("Person Should Pass All Tests First.", "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }


            int LicenseID = _LDLApp.GetActiveLicenseID();
            if (LicenseID != -1)
            {

                MessageBox.Show("Person already has License before with License ID=" + LicenseID.ToString(), "Not Allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;

            }

            ctrlApplicationInfo1.LoadLocalApplicationInfo(_LocalAppID);

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int LicenseID = _LDLApp.IssueLicenseForTheFirstTime(rtNotes.Text, clsGlobal.CurrentUser.UserID);

            if (LicenseID != -1)
            {
                MessageBox.Show("License Issued Successfully with License ID = " + LicenseID.ToString(),
            "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);

                clsApplicationBusiness.CompletApplication(_LDLApp.ApplicationID, 3);

                this.Close();
            }
            else
            {

                MessageBox.Show("License Was not Issued ! ",
                 "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }








        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
