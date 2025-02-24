using DVLD.Applications.Tests;
using DVLD.Licenses;
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

namespace DVLD.Applications.Local_Driving_Application
{
    public partial class frmManageLocalApplications : Form
    {
       static DataTable _dtLocalList=clsLocalDrivingApplicationsBusiness.GetAllLocalApplications();
        static DataView _dvLocalList = _dtLocalList.DefaultView;




        public frmManageLocalApplications()
        {
            InitializeComponent();
        }

        private void btnAddLocalApplication_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingApplication frm=new frmNewLocalDrivingApplication();
            frm.ShowDialog();
        }

        private void frmManageLocalApplications_Load(object sender, EventArgs e)
        {
            _RefreshList();

            if (dgvLocalApplications.Rows.Count > 0 )
            {
                dgvLocalApplications.Columns[0].HeaderText = "L.D.L.AppID";
                dgvLocalApplications.Columns[0].Width = 100;

                dgvLocalApplications.Columns[1].HeaderText = "Driving Classes";
                dgvLocalApplications.Columns[1].Width = 250;

                dgvLocalApplications.Columns[2].HeaderText = "NationalNo.";
                dgvLocalApplications.Columns[2].Width = 100;

                dgvLocalApplications.Columns[3].HeaderText = "Full Name";
                dgvLocalApplications.Columns[3].Width = 150;


                dgvLocalApplications.Columns[4].HeaderText = "Application Date";
                dgvLocalApplications.Columns[4].Width = 150;


                dgvLocalApplications.Columns[5].HeaderText = "Passed Test";
                dgvLocalApplications.Columns[5].Width = 50;

                dgvLocalApplications.Columns[6].HeaderText = "Application Statu";
                dgvLocalApplications.Columns[6].Width = 100;
                
            }
            cbFillter.SelectedIndex = 0;
            _RefreshList();

         


        }


        private void _RefreshList()
        {

            dgvLocalApplications.DataSource = clsLocalDrivingApplicationsBusiness.GetAllLocalApplications();
            lblLocalApplicationsCount.Text = "#" + dgvLocalApplications.RowCount.ToString();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtFillter_TextChanged(object sender, EventArgs e)
        {
            switch(cbFillter.SelectedItem)
            {
                case "L.D.L.AppID":
                    {
                        if (int.TryParse(txtFillter.Text, out int ID))
                        {
                            _dvLocalList.RowFilter = $"[LocalDrivingLicenseApplicationID]  = '{ID}'";


                        }
                        break;
                    }                           
                case "NationalNo.":
                            {
                                _dvLocalList.RowFilter = $"TheIDNumber Like '{txtFillter.Text}%'";
                                break;
                            }
            

                default:
                    {
                        dgvLocalApplications.DataSource = _dvLocalList;
                        break;

                    }

            }




        }

        private void cbFillter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFillter.SelectedIndex != 0)
            {
                txtFillter.Visible = true;
                txtFillter.Focus();
            }
            else
            {
                txtFillter.Visible=false;
                dgvLocalApplications.DataSource=_dvLocalList;
            }
        }

        private void showLocalDrivingApplicationDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLocalApplicationInfo frm = new frmShowLocalApplicationInfo((int)dgvLocalApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();

        }

        private void editApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingApplication frm=new frmNewLocalDrivingApplication((int)dgvLocalApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmManageLocalApplications_Load(null, null);

        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Application?", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {


                if (clsLocalDrivingApplicationsBusiness.DeleteLocalDrivingApplication((int)dgvLocalApplications.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Application Deleted Successfully.");
                    _RefreshList();
                }
            }

            else
            {
                MessageBox.Show("Application is not deleted.");

            }
            frmManageLocalApplications_Load(null, null);
        }

        private void canceldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to Cancel this Application?", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {

               clsLocalDrivingApplicationsBusiness LocalInfo= clsLocalDrivingApplicationsBusiness.Find((int)dgvLocalApplications.CurrentRow.Cells[0].Value);
                if (clsApplicationBusiness.CancelApplication(LocalInfo.ApplicationID,2))
                {
                    MessageBox.Show("Application Canceld Successfully.");
                    _RefreshList();
                }
            }

            else
            {
                MessageBox.Show("Application is not Canceld.");

            }
            frmManageLocalApplications_Load(null, null);
        }


        void _ScheduleTest(clsTestType.enTestType TestType)
        {

            frmListtestAppointments frm = new frmListtestAppointments((int)dgvLocalApplications.CurrentRow.Cells[0].Value, TestType);
            frm.ShowDialog();
            frmManageLocalApplications_Load(null, null);

        }


        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestType.enTestType.VisionTest);
        }

        private void scheduleWrittenTestToolStripMenuItem_Click(object sender, EventArgs e)
        {

            _ScheduleTest(clsTestType.enTestType.WrittenTest);

        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _ScheduleTest(clsTestType.enTestType.StreetTest);
     
        }



        private void cmsLocalApplicationList_Opening(object sender, CancelEventArgs e)
        {
            int LocalDriverLicenseID = (int)dgvLocalApplications.CurrentRow.Cells[0].Value;
            clsLocalDrivingApplicationsBusiness LocalDrivingLicense = clsLocalDrivingApplicationsBusiness.Find(LocalDriverLicenseID);


            bool IsLicenseExit = LocalDrivingLicense.IsLicenseIssued();

            int PassedTests = (int)dgvLocalApplications.CurrentRow.Cells[5].Value;
         
                scheduleVisionTestToolStripMenuItem.Enabled = (PassedTests == 0);
                
                scheduleWrittenTestToolStripMenuItem.Enabled = (PassedTests == 1);
      
                scheduleStreetTestToolStripMenuItem.Enabled = (PassedTests == 2);

            issuDrivingLicenceFirstTimeToolStripMenuItem.Enabled = (PassedTests == 3)&& !IsLicenseExit;
            showLicenseToolStripMenuItem.Enabled = IsLicenseExit;
            if ((PassedTests == 3) )
            {
                issuDrivingLicenceFirstTimeToolStripMenuItem.Enabled =true;
                scheToolStripMenuItem.Enabled = false;
                canceldToolStripMenuItem.Enabled = false;
                deleteApplicationToolStripMenuItem.Enabled = false;
                editApplicationToolStripMenuItem.Enabled= false;
            }
            else
            {
                issuDrivingLicenceFirstTimeToolStripMenuItem.Enabled = false;
                scheToolStripMenuItem.Enabled = true;
                canceldToolStripMenuItem.Enabled = true;
                deleteApplicationToolStripMenuItem.Enabled = true;
                editApplicationToolStripMenuItem.Enabled = true;
            }



            if ((string)dgvLocalApplications.CurrentRow.Cells[6].Value == "Cancelled")
            {
                scheToolStripMenuItem.Enabled = false;
                editApplicationToolStripMenuItem.Enabled = false;
                canceldToolStripMenuItem.Enabled = false;
            }





        }

        private void issuDrivingLicenceFirstTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmIssuLicenseFirstTime frm = new frmIssuLicenseFirstTime((int)dgvLocalApplications.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmManageLocalApplications_Load(null, null);

        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = clsLocalDrivingApplicationsBusiness.Find((int)dgvLocalApplications.CurrentRow.Cells[0].Value).GetActiveLicenseID();

            if (LicenseID != -1)
            {
                frmShowLicenseInfo frm = new frmShowLicenseInfo(LicenseID);
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No License Found!", "No License", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = clsLocalDrivingApplicationsBusiness.Find((int)dgvLocalApplications.CurrentRow.Cells[0].Value).GetActiveLicenseID();
            clsLicenseBusniess _Licens=clsLicenseBusniess.GetLicenseInfoByLicenseID(LicenseID);

            if (_Licens == null)
            {
                MessageBox.Show("This Person Dont have Licenses");
                return;
            }
            frmLicensesHistory frm = new frmLicensesHistory(_Licens.DriverID);
            frm.ShowDialog();
        }
    }
}
