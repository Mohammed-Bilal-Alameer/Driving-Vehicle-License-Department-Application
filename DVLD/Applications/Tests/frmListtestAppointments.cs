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

namespace DVLD.Applications.Tests
{
    public partial class frmListtestAppointments : Form
    {
        DataTable dtAppointmentList=new DataTable();
        int _LocalID;
       static clsTestType.enTestType _TestType;
        public frmListtestAppointments(int LocalID,clsTestType.enTestType Type)
        {
            InitializeComponent();
            this._LocalID = LocalID;
            _TestType = Type;
             dtAppointmentList = clsTestApplointmentsBusiness.GetAllApplointments((byte)Type, _LocalID);

        }

     


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddTest_Click(object sender, EventArgs e)
        {



            /// كود للتأكد اذا كان يوجد موعد لنفس نوع التيسيت وغير مكتمل ام لا
            if (clsTestApplointmentsBusiness.DoesLocalApplicationHasAnActiveAppionment((int)_TestType, _LocalID))
            {
                MessageBox.Show("You have an Active Appoientment", "Error");
                return;
            }
            //كود للتأكد اذا كان ناجح بالامتحان نفسو 
            if (clsTestApplointmentsBusiness.DoesLocalApplicationPassedTest((int)_TestType, _LocalID))
            {
                MessageBox.Show("You Already Passed This Test", "Error");
                return;
            }

            // كتوب كود مشان اعادة الامتحان

            //frmScheduleTestAppointments frmSec = new frmScheduleTestAppointments(_LocalID, _TestType);
            //frmSec.ShowDialog();
            frmScheduleTestWithHadhoud frm=new frmScheduleTestWithHadhoud(_LocalID, _TestType);
            frm.ShowDialog();

            frmVisionTest_Load(null, null);

        }

        private void frmVisionTest_Load(object sender, EventArgs e)
        {
            ctrlApplicationInfo1.LoadLocalApplicationInfo(_LocalID);

            if(_TestType==clsTestType.enTestType.VisionTest)
            {

                lblHeader.Text = "Vision Test";
            }
            else if(_TestType == clsTestType.enTestType.StreetTest)
            {
                lblHeader.Text = "Street Test";


            }
            else
            {
                lblHeader.Text = "Written Test";

            }
            dtAppointmentList = clsTestApplointmentsBusiness.GetAllApplointments((byte)_TestType, _LocalID);

            dgvAppointmentList.DataSource = clsTestApplointmentsBusiness.GetAllApplointments((byte)_TestType, _LocalID); 
            
           

        }

        private void eidtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //frmScheduleTestAppointments frm = new frmScheduleTestAppointments(_LocalID, _TestType, (int)dgvAppointmentList.CurrentRow.Cells[0].Value);
            //frm.ShowDialog();


            frmScheduleTestWithHadhoud frm = new frmScheduleTestWithHadhoud(_LocalID, _TestType, (int)dgvAppointmentList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmVisionTest_Load(null, null);
        }

        private void takeTheTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (clsTestsBusniess.FindByAppoientmentID((int)dgvAppointmentList.CurrentRow.Cells[0].Value).TestResult==true|| clsTestsBusniess.FindByAppoientmentID((int)dgvAppointmentList.CurrentRow.Cells[0].Value).TestResult == false)
            //{
            //    takeTheTestToolStripMenuItem.Enabled = false;
            //}
            frmTakeTest frm = new frmTakeTest(_LocalID, _TestType, (int)dgvAppointmentList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmVisionTest_Load(null, null);
        }



    }
}
