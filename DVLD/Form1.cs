using DVLD.Applications.Detain_License;
using DVLD.Applications.InternationalDrivingLicense;
using DVLD.Applications.Local_Driving_Application;
using DVLD.Applications.Renew_Driving_License;
using DVLD.Applications.Replacement_for_Damaged_or_Lost_Licenses;
using DVLD.Login;
using DVLD.People;
using DVLD.User;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class frmDVLDMain : Form
    {
        frmLoginScreen _LoginForm;
        public frmDVLDMain(frmLoginScreen frm)
        {
            InitializeComponent();
            _LoginForm = frm;

        }
        public frmDVLDMain()
        {
            InitializeComponent();
       

        }
        private void frmDVLDMain_MouseHover(object sender, EventArgs e)
        {
            BackColor = Color.Silver;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmListPeople frmListPeople = new frmListPeople();
            frmListPeople.ShowDialog();
        }

        private void frmDVLDMain_Load(object sender, EventArgs e)
        {
           lblCurrentUser.Text=clsGlobal.CurrentUser.UserName;
        }

        private void logOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsGlobal.CurrentUser = null;
            _LoginForm.Show();

            this.Close();


        }

        private void button4_Click(object sender, EventArgs e)
        {

            cmsSettings.Show();
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            UsersList usersList = new UsersList();
            usersList.ShowDialog();
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            frmShowUserInfo frm = new frmShowUserInfo(clsGlobal.CurrentUser.UserID);
            frm.ShowDialog();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            frmChangePassword ChangeMyPassword=new frmChangePassword(clsGlobal.CurrentUser.UserID);
            ChangeMyPassword.ShowDialog();
        }

    

        private void frmDVLDMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            _LoginForm.Close();
        }

        private void localDrivingLicensesApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageLocalApplications frm=new frmManageLocalApplications();
            frm.ShowDialog();
        }

        private void localDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingApplication frm = new frmNewLocalDrivingApplication();
            frm.ShowDialog();
        }

        private void internationalDrivingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicense frm=new frmNewInternationalLicense();
            frm.ShowDialog();
        }

        private void interToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageInternationalLicenseList frm=new frmManageInternationalLicenseList();
            frm.ShowDialog();
        }

        private void renewDrivingLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenewLicense frm=new frmRenewLicense();
            frm.ShowDialog();
        }

        private void replacementForDamagedOrLostLicensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReplacementforDamagedorLostLicenses frm = new frmReplacementforDamagedorLostLicenses();
            frm.ShowDialog();
        }

        private void detainLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainReleaseLicense frm = new frmDetainReleaseLicense(DVLD_Business.clsDetainBusiness.enReasonMode.Detain);
            frm.ShowDialog();
        }

        private void relToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDetainReleaseLicense frm = new frmDetainReleaseLicense(DVLD_Business.clsDetainBusiness.enReasonMode.Release);
            frm.ShowDialog();
        }
    }
}
