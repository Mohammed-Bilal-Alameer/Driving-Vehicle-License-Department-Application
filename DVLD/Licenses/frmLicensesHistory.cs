using DVLD.Applications.InternationalDrivingLicense;
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
    public partial class frmLicensesHistory : Form
    {
        int _DriverID;
        clsDriverBusiness _DriverBusiness;
        public frmLicensesHistory(int DriverID)
        {
            InitializeComponent();
            _DriverID = DriverID;
        }

        private void frmLicensesHistory_Load(object sender, EventArgs e)
        {
            _DriverBusiness=clsDriverBusiness.FindByDriverID(_DriverID);
            if (_DriverBusiness == null)
            {
                return;
            }
            dgvInternational.DataSource = clsInternationalDrivingLicenseApplicaitonBusiness.GetAllInternationaDrivingApplicationsForDriver(_DriverID);
            dgvLocal.DataSource = clsLocalDrivingApplicationsBusiness.GetAllLocalApplicationsForDriver(_DriverID);
            ctrlPersonCardWithFilter1.LoadPersonInfo(_DriverBusiness.PersonID);
            ctrlPersonCardWithFilter1.FilterEnabled = false;

        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo((int)dgvLocal.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void showLicenseInfoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmShowInternationalLicenseInfo frm = new frmShowInternationalLicenseInfo((int)dgvInternational.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}
