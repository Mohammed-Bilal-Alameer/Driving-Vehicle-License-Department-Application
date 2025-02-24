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

namespace DVLD.Applications.Renew_Driving_License
{
    public partial class frmRenewLicense : Form
    {
        clsLicenseBusniess _RenewLicense = new clsLicenseBusniess();
        clsApplicationBusiness _NewApplication = new clsApplicationBusiness();

        int _OldDriverID;

        public frmRenewLicense()
        {
            InitializeComponent();
        }

        private void ctrlDrivingLicenseWithFilter1_OnLicenseSelected(int obj)
        {

            if (obj == -1)
            {
                return;
            }
            

            lblApplicationDate.Text = DateTime.Now.ToString();
            lblLocalLicenseID.Text = obj.ToString();
            lblIssueDate.Text = DateTime.Now.ToString();
            lblExpDate.Text = DateTime.Now.AddYears(clsLicensesClassesBusiness.Find(ctrlDrivingLicenseWithFilter1.LicenseInfo.LicenseClassID).DefaultValidityLength).ToString();
            lblApplicationTypeFees.Text = clsApplicationTypes.Find((int)clsApplicationBusiness.enApplicationType.RenewDrivingLicense).Fees.ToString();
            lblCreatedByUserName.Text = clsGlobal.CurrentUser.UserName;
            lblLicenseFees.Text = ctrlDrivingLicenseWithFilter1.LicenseInfo.PaidFees.ToString();
            lblTotalFees.Text = (int.Parse(lblLicenseFees.Text) + int.Parse(lblApplicationTypeFees.Text)).ToString();
            if (!ctrlDrivingLicenseWithFilter1.LicenseInfo.IsLicenseExpired())
            {
                MessageBox.Show("Error: This License is not Expired. It will Expire in"+ ctrlDrivingLicenseWithFilter1.LicenseInfo.ExpirationDate, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;
                return;
            }
            if (!ctrlDrivingLicenseWithFilter1.LicenseInfo.isActive)
            {
                MessageBox.Show("Error: This License is not Active.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnRenew.Enabled = false;
                return;
            }
            btnRenew.Enabled = true;

        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            clsLicenseBusniess OldLicense = ctrlDrivingLicenseWithFilter1.LicenseInfo;
         


            _RenewLicense.DriverID = OldLicense.DriverID;
            _RenewLicense.LicenseClassID= OldLicense.LicenseClassID;
            _RenewLicense.IssueDate = DateTime.Now;
            _RenewLicense.ExpirationDate = DateTime.Now.AddYears(clsLicensesClassesBusiness.Find(_RenewLicense.LicenseClassID).DefaultValidityLength);
            _RenewLicense.PaidFees= clsLicensesClassesBusiness.Find(_RenewLicense.LicenseClassID).ClassFees;
            _RenewLicense.isActive = true;
            _RenewLicense.IssueReason = clsLicenseBusniess.enIssueReason.Renew;
            _RenewLicense.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            _NewApplication.ApplicationPersonID = OldLicense.DriverInfo.PersonID;
            _NewApplication.ApplicationDate= DateTime.Now;
            _NewApplication.ApplicationTypeID =(int) clsApplicationBusiness.enApplicationType.RenewDrivingLicense;
            _NewApplication.ApplicationStatus = clsApplicationBusiness.enApplicationStatus.Completed;
            _NewApplication.LastStatusDate= DateTime.Now;
            _NewApplication.PaidFees = clsApplicationTypes.Find(_NewApplication.ApplicationTypeID).Fees;
            _NewApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (!_NewApplication.Save())
            {
                return;
            }
            _RenewLicense.ApplicationID= _NewApplication.ApplicationID;
            if (_RenewLicense.Save())
            {
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
               lblApplicationID.Text = _RenewLicense.ApplicationID.ToString();
                lblRenewLicenseID.Text = _RenewLicense.LicenseID.ToString();
                LlblShowLicenseInfo.Enabled = true;
                btnRenew.Enabled = false;
                ctrlDrivingLicenseWithFilter1.FilterEnable = false;
                OldLicense.DeActivateLicense();
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }






        }

        private void LlblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_RenewLicense.LicenseID);
            frm.ShowDialog();
        }

        private void LlblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicensesHistory frm=new frmLicensesHistory(ctrlDrivingLicenseWithFilter1.LicenseInfo.DriverID);
            frm.ShowDialog();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
