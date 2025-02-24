using DVLD.Login;
using DVLD.Properties;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static DVLD_Business.clsTestType;

namespace DVLD.Applications.Tests.Controls
{
    public partial class ctrlScheduleTest : UserControl
    {
        public enum enMode { AddNew = 0, Update = 1 };
        public enMode Mode = enMode.AddNew;



        
        public ctrlScheduleTest()
        {
            InitializeComponent();



        }
        public clsTestType TestTypeInfo;
        public enTestType TestTypeID;
        int _LAppID = -1;
        clsLocalDrivingApplicationsBusiness _LocalApp;
        clsTestApplointmentsBusiness _Appoitment;
        int _AppointmentID=-1;
    

     

        public void LoadScheduleTestInfo(int LocalID, int AppointmentID)
        {
            

            _AppointmentID=AppointmentID;

    


            _LocalApp = clsLocalDrivingApplicationsBusiness.Find(LocalID);
            TestTypeInfo = clsTestType.Find(TestTypeID);
            _LAppID = LocalID;
            if (_LocalApp == null)
            {
                MessageBox.Show("The Application is not found", "Error");
            }
            else
            {
                lblDLAPPID.Text= LocalID.ToString();
                lblName.Text = _LocalApp.ApplicantFullName;
                lblClass.Text = _LocalApp.LicensInfo.ClassName;
                dtpDate.Value = DateTime.Now;
                lblTrail.Text = clsTestApplointmentsBusiness.GetCountTrail(_LAppID,(byte) TestTypeID).ToString();
                lblFees.Text = TestTypeInfo.TestTypeFees.ToString();
                gbTestName.Text = TestTypeInfo.TestTitle;


                if (TestTypeID == clsTestType.enTestType.VisionTest)
                {
                    pbTestType.Image = Resources.VisionTest;
                }

                if (TestTypeID == clsTestType.enTestType.WrittenTest)
                {
                    pbTestType.Image = Resources.WrittenTest;
                }
                if (TestTypeID == clsTestType.enTestType.StreetTest)
                {
                    pbTestType.Image = Resources.StreetTest;

                }
        

            }
            if (_AppointmentID == -1)
            {
                Mode = enMode.AddNew;
                _Appoitment = new clsTestApplointmentsBusiness();

            }
            else
            {
                Mode = enMode.Update;
                
                _LoadData();

                clsTestsBusniess TestInfo = clsTestsBusniess.FindByAppoientmentID(_AppointmentID);


                if (TestInfo == null)
                {
                    return;
                }

                if (TestInfo.TestResult == false)
                {
                    dtpDate.Enabled = false;
                    lblFaildTest.Visible = true;
                    btnSave.Enabled = false;
                }
                if (TestInfo.TestResult == true)
                {
                    dtpDate.Enabled = false;
                    lblFaildTest.Text = "You Passed This Test";
                    lblFaildTest.Visible = true;
                    btnSave.Enabled = false;
                }

            }



        }


        private void _LoadData()
        {
            _Appoitment = clsTestApplointmentsBusiness.Find(_AppointmentID);


            lblDLAPPID.Text = _Appoitment.LocalDrivingLicenseApplicationsID.ToString();
            lblName.Text = _LocalApp.ApplicantFullName;
            lblClass.Text = _LocalApp.LicensInfo.ClassName;
            dtpDate.Value = _Appoitment.ApplointmentDate;
            lblFees.Text = TestTypeInfo.TestTypeFees.ToString();
            gbTestName.Text = TestTypeInfo.TestTitle;


        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            _Appoitment.LocalDrivingLicenseApplicationsID = _LAppID;
            _Appoitment.ApplointmentDate = dtpDate.Value;
            _Appoitment.PaidFees= TestTypeInfo.TestTypeFees;
            _Appoitment.CreatedByUserID=clsGlobal.CurrentUser.UserID;
            _Appoitment.isLocked = false;
            _Appoitment.TestTypeID = (int)TestTypeID;





            if (_Appoitment.Save())
            {
               

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }



    }
    }

