using DVLD.Licenses;
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

namespace DVLD.Applications.InternationalDrivingLicense
{
    public partial class frmNewInternationalLicense : Form
    {
        clsLicenseBusniess _License;
        clsInternationalDrivingLicenseApplicaitonBusiness _InternationalLicense;
        public frmNewInternationalLicense()
        {
            InitializeComponent();
        }

        private void ctrlDrivingLicenseWithFilter1_OnLicenseSelected(int obj)
        {
            _License=clsLicenseBusniess.GetLicenseInfoByLicenseID(obj);
            if( _License==null )
            {
                return;
            }
            lblApplicationDate.Text = DateTime.Now.ToString();
            lblILApplicationID.Text = "[???]";
            lblApplicationTypeFees.Text= clsApplicationTypes.Find((int)clsApplicationBusiness.enApplicationType.NewInternationalLicense).Fees.ToString();
            lblIssueDate.Text = DateTime.Now.ToString();
            lblLocalLicenseID.Text = obj.ToString();
            lblExpDate.Text=DateTime.Now.ToString();
            lblCreatedByUserName.Text=clsGlobal.CurrentUser.UserName;

            if (_License.LicenseClassID != 3)
            {
                MessageBox.Show("Error: You need Local License First.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                btnIssue.Enabled = false;
                return;
            }


            if(_License.IsLicenseExpired() || !_License.isActive)
            {
                MessageBox.Show("Error: Your License is Expired.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                btnIssue.Enabled = false;
                return;
            }


            if (clsInternationalDrivingLicenseApplicaitonBusiness.DoesHaveAnActiveInternationalLicense(obj))
            {
                MessageBox.Show("Error: You have an active License.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                btnIssue.Enabled = false;

                return;
            }
            btnIssue.Enabled = true;

        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            _InternationalLicense=new clsInternationalDrivingLicenseApplicaitonBusiness();

            _InternationalLicense.DriverID= _License.DriverID;
            _InternationalLicense.IssuedUsingLocalLicenseID = _License.LicenseID;
            _InternationalLicense.IssueDate = DateTime.Now;
            _InternationalLicense.ExpirationDate=DateTime.Now.AddYears(_License.LicenseClassInfo.DefaultValidityLength);
            _InternationalLicense.IsActive = true;
            _InternationalLicense.ApplicationPersonID = _License.DriverInfo.PersonID;
            _InternationalLicense.ApplicationDate=DateTime.Now;
            _InternationalLicense.ApplicationTypeID =(int) clsApplicationBusiness.enApplicationType.NewInternationalLicense;
            _InternationalLicense.ApplicationStatus = clsApplicationBusiness.enApplicationStatus.New;
            _InternationalLicense.LastStatusDate= DateTime.Now;
            _InternationalLicense.PaidFees = clsApplicationTypes.Find((int)clsApplicationBusiness.enApplicationType.NewInternationalLicense).Fees;
            _InternationalLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            _InternationalLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            if (_InternationalLicense.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblILApplicationID.Text=_InternationalLicense.ApplicationID.ToString();
                lblILLicenseID.Text=_InternationalLicense.InternationalLicenseID.ToString();
                LlblShowLicenseInfo.Enabled = true;
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LlblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(_InternationalLicense.InternationalLicenseID);
            frm.ShowDialog();
        }

        private void LlblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicensesHistory frm = new frmLicensesHistory(_InternationalLicense.DriverID);
            frm.ShowDialog();
        }
    }
}
