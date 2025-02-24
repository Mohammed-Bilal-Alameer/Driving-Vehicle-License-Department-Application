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

namespace DVLD.Applications.Detain_License
{
    public partial class frmDetainReleaseLicense : Form
    {
        clsDetainBusiness.enReasonMode _Reason;
        clsDetainBusiness _Detain;
        public frmDetainReleaseLicense(clsDetainBusiness.enReasonMode Reason)
        {
            InitializeComponent();
            _Reason = Reason;


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ctrlDrivingLicenseWithFilter1_OnLicenseSelected(int obj)
        {
            if (!ctrlDrivingLicenseWithFilter1.LicenseInfo.isActive)
            {
                MessageBox.Show("Error: This License is not Active Choose Another One!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnIssue.Enabled = false;
                return;
            }


            lblDetainDate.Text = DateTime.Now.ToString();
            lblCreatedByUserID.Text = clsGlobal.CurrentUser.UserName;
            lblLicenseID.Text = obj.ToString();



            if (_Reason == clsDetainBusiness.enReasonMode.Detain)
            {
            
             


                if (clsDetainBusiness.IsLicenseDetained(obj))
                {
                    btnIssue.Enabled = false;

                    MessageBox.Show("Error: This License already Detained Choose Another One!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

            }

            if (_Reason == clsDetainBusiness.enReasonMode.Release)
            {

                if (!clsDetainBusiness.IsLicenseDetained(obj))
                {
                    MessageBox.Show("Error: This License is not Detained Choose Another One!.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    btnIssue.Enabled = false;
                    return;
                }
                clsDetainBusiness DetainedLicense = clsDetainBusiness.GetInfoByLicenseID(obj);

                lblFineFees.Text = DetainedLicense.FineFees.ToString();
               float AppFees = clsApplicationTypes.Find((int)clsApplicationBusiness.enApplicationType.ReleaseDetainedDrivingLicsense).Fees;
                lblTotalFees.Text=(Convert.ToSingle(DetainedLicense.FineFees) + AppFees).ToString();
                lblApplicationFees.Text = AppFees.ToString();
                lblDetainID.Text = DetainedLicense.DetainID.ToString();
            }



            btnIssue.Enabled = true;



        }

        private void frmDetainReleaseLicense_Load(object sender, EventArgs e)
        {
            if (_Reason == clsDetainBusiness.enReasonMode.Detain)
            {
                lblTitle.Text = "Detain License";
                this.Text = lblTitle.Text;
                btnIssue.Text = "Detain";
                lblTitleApplicationFees.Visible = false;
                lblTitleApplicationID.Visible = false;
                lblTitleTotalFees.Visible = false;
                lblTotalFees.Visible = false;
                lblApplicationID.Visible = false;
                lblApplicationFees.Visible = false;
                lblFineFees.Visible = false;
                txtFineFees.Visible = true;



            }
            if (_Reason == clsDetainBusiness.enReasonMode.Release)
            {
                lblTitle.Text = "Release License";
                this.Text = lblTitle.Text;
                btnIssue.Text = "Release";

                
                lblTitleApplicationFees.Visible = true;
                lblTitleApplicationID.Visible = true;
                lblTitleTotalFees.Visible = true;
                lblTotalFees.Visible = true;
                lblApplicationID.Visible = true;
                lblApplicationFees.Visible = true;
                lblFineFees.Visible = true;
                txtFineFees.Visible = false;



            }


        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (_Reason == clsDetainBusiness.enReasonMode.Detain)
            {
                float Fees = Convert.ToSingle(txtFineFees.Text);
                _Detain = ctrlDrivingLicenseWithFilter1.LicenseInfo.DetainLicense(clsGlobal.CurrentUser.UserID, Fees);
                if (_Detain == null)
                {
                    MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    return;

                }
                else
                {
                    MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblDetainID.Text = _Detain.DetainID.ToString();
                    txtFineFees.Enabled = false;
                    ctrlDrivingLicenseWithFilter1.FilterEnable = false;
                    LlblShowLicenseInfo.Enabled = true;
                }
            }

            if (_Reason == clsDetainBusiness.enReasonMode.Release)
            {
                int ApplicationID = -1;
                if (ctrlDrivingLicenseWithFilter1.LicenseInfo.ReleasLicense(clsGlobal.CurrentUser.UserID,ref ApplicationID))
                {
                    lblApplicationID.Text = ApplicationID.ToString();
                  
                    
                    MessageBox.Show("This License Released.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }


            }


        }

        private void LlblShowLicenseInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo(ctrlDrivingLicenseWithFilter1.LicenseID);
            frm.ShowDialog();
        }
    }
}
