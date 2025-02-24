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

namespace DVLD.Applications.Replacement_for_Damaged_or_Lost_Licenses
{
    public partial class frmReplacementforDamagedorLostLicenses : Form
    {
        clsLicenseBusniess _NewLicense;
        clsLicenseBusniess.enIssueReason Reason;
        public frmReplacementforDamagedorLostLicenses()
        {
            InitializeComponent();
        }

        private void ctrlDrivingLicenseWithFilter1_OnLicenseSelected(int obj)
        {
            if(obj == -1)
            {
                return;
            }
           

            lblApplicationDate.Text = DateTime.Now.ToString();
         
           
            lblLocalLicenseID.Text = obj.ToString();
            lblCreatedByUserID.Text = clsGlobal.CurrentUser.UserName;

            if (!ctrlDrivingLicenseWithFilter1.LicenseInfo.isActive)
            {
                MessageBox.Show("Selected License is not Not Active, choose an active license."
                  , "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnReplacement.Enabled = false;
                return;
            }

            btnReplacement.Enabled = true;


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private int GetApplicationTypeID()
        {
            if (rdDamagedLicense.Checked)
            {
                return (int)clsApplicationBusiness.enApplicationType.ReplaceDamagedDrivingLicense;
            }
            else
            {
                return (int)clsApplicationBusiness.enApplicationType.ReplaceLostDrivingLicense;
            }
        }
        private clsLicenseBusniess.enIssueReason GetIssueReason()
        {
            if (rdDamagedLicense.Checked)
            {
                return clsLicenseBusniess.enIssueReason.DamagedReplacement;
            }
            else
            {
                return clsLicenseBusniess.enIssueReason.LostReplacement;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(_NewLicense.LicenseID);
            frm.ShowDialog();
        }

        private void LlblShowLicensesHistory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmLicensesHistory frm= new frmLicensesHistory(_NewLicense.DriverID);
            frm.ShowDialog();
        }

        private void btnReplacement_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Issue a Replacement for the license?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }


            _NewLicense = ctrlDrivingLicenseWithFilter1.LicenseInfo.ReplacementforDamagedOrLost(GetIssueReason(), clsGlobal.CurrentUser.UserID);
            if (_NewLicense == null)
            {
                MessageBox.Show("Faild.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return;
            }
            
            
                lblApplicationID.Text = _NewLicense.ApplicationID.ToString();
                lblReplacementLicenseID.Text = _NewLicense.LicenseID.ToString();
                ctrlDrivingLicenseWithFilter1.FilterEnable = false;
                gbApplicationType.Enabled = false;
                btnReplacement.Enabled = false;
                lnkShowLicenseInfo.Enabled = true;
            MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);



        }

        private void rdDamagedLicense_CheckedChanged(object sender, EventArgs e)
        {
            lblApplicationFees.Text = clsApplicationTypes.Find(GetApplicationTypeID()).Fees.ToString();
        }

        private void frmReplacementforDamagedorLostLicenses_Load(object sender, EventArgs e)
        {
            rdDamagedLicense.Checked = true;
        }

        private void rdLostLicense_CheckedChanged(object sender, EventArgs e)
        {
            lblApplicationFees.Text = clsApplicationTypes.Find(GetApplicationTypeID()).Fees.ToString();

        }
    }
}
