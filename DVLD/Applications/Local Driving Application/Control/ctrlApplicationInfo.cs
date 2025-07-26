using DVLD.People;
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

namespace DVLD.Applications.Local_Driving_Application.Control
{
    public partial class ctrlApplicationInfo : UserControl
    {
        public ctrlApplicationInfo()
        {
            InitializeComponent();
        }

        int _LAppID = -1;
        public int LAppID { get; private set; }
        clsLocalDrivingApplicationsBusiness _LocalApp;


        void _ResetDefaultValue()
        {
            lblApplicationID.Text = "???";
            lblApplicationDate.Text = "???";
            lblClassName.Text = "???";
            lblCreatedByUserName.Text = "???";
            lblDLAPPID.Text = "???";
            lblPassedTests.Text = "???";
            lblStatus.Text = "???";
            lblStatusDate.Text = "???";
            lblType.Text = "???";
            lblFees.Text = "???";
            lblApplicant.Text = "???";

        }

        public void LoadLocalApplicationInfo(int LocalID)
        {
            _LocalApp = clsLocalDrivingApplicationsBusiness.Find(LocalID);

            if (_LocalApp == null)
            {
                MessageBox.Show("The Application is not found", "Error");
                _ResetDefaultValue();
            }
            else
            {
                lblApplicationID.Text =_LocalApp.ApplicationID.ToString();
                lblApplicationDate.Text = _LocalApp.ApplicationDate.ToString();
                lblClassName.Text = _LocalApp.LicensInfo.ClassName;
                lblCreatedByUserName.Text = "";
                lblDLAPPID.Text = _LocalApp.LocalDrivingLicenseApplicationID.ToString();
                lblPassedTests.Text =clsTestApplointmentsBusiness.GetPassedTests(LocalID,true) + "/3";
                lblStatus.Text = _LocalApp.StatusText.ToString();
                lblStatusDate.Text = _LocalApp.LastStatusDate.ToString();
                lblApplicant.Text = _LocalApp.ApplicantFullName;

                lblType.Text = _LocalApp.ApplicationTitle;
                lblFees.Text = _LocalApp.PaidFees.ToString();
            }




        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ShowDetails frm = new ShowDetails(_LocalApp.ApplicationPersonID);
            frm.ShowDialog();
        }
    }
}
