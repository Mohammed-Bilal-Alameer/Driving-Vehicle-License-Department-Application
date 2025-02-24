using DVLD.Licenses;
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

namespace DVLD.Applications.InternationalDrivingLicense
{
    public partial class frmManageInternationalLicenseList : Form
    {
        clsInternationalDrivingLicenseApplicaitonBusiness _License;
        int _InternationalLicenseID;
        public frmManageInternationalLicenseList()
        {
            InitializeComponent();
        }

        private void frmManageInternationalLicenseList_Load(object sender, EventArgs e)
        {
            dgvInternationalLicenseList.DataSource=clsInternationalDrivingLicenseApplicaitonBusiness.GetAllInternationalApplications();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicense frm=new frmNewInternationalLicense();
            frm.ShowDialog();
        }

        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            ShowDetails frm=new ShowDetails(_License.DriverInfo.PersonID);
            frm.ShowDialog();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            _InternationalLicenseID = (int)dgvInternationalLicenseList.CurrentRow.Cells[0].Value;
            _License=clsInternationalDrivingLicenseApplicaitonBusiness.FindByInternationalApplicationID(_InternationalLicenseID);


        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo(_InternationalLicenseID);
            frm.ShowDialog();

        }

        private void showDriverLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicensesHistory frm = new frmLicensesHistory(_License.DriverID);
            frm.ShowDialog();
        }
    }
}
