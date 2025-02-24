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

namespace DVLD.Applications.Tests
{
    public partial class frmTakeTest : Form
    {
        int _LocalID = -1;
        clsTestType.enTestType _TestType;
        int _AppoientmentID = -1;
        clsTestApplointmentsBusiness AppionementInfo;
        clsTestsBusniess _NewTest;
        int _TestID = -1;
        public frmTakeTest(int LocalID,clsTestType.enTestType TestType,int Appoientment)
        {
            InitializeComponent();
            _LocalID = LocalID;
            _TestType = TestType;
            _AppoientmentID =Appoientment;
        }

        private void frmTakeTest_Load(object sender, EventArgs e)
        {
            ctrlScheduleTestWithoutSaveButtn1.TestTypeID= _TestType;
            ctrlScheduleTestWithoutSaveButtn1.LoadScheduleTestInfo(_LocalID, _AppoientmentID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _NewTest=new clsTestsBusniess();
            _NewTest.AppoientmentID = _AppoientmentID;
            _NewTest.CreatedByUserID = clsGlobal.CurrentUser.UserID; 
            // if rdPass Checked then will return true = pass
            _NewTest.TestResult=rdPass.Checked;
            if (_NewTest.Save())
            {
                // فينك تعمل لوك من الداتا بيز بعد ماتعمل ادد لتيست
                clsTestApplointmentsBusiness.LockAppointment(_AppoientmentID);

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
