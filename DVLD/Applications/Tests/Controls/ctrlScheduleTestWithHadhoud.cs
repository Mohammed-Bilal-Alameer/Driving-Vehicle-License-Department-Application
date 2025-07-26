using DVLD.Login;
using DVLD.Properties;
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

namespace DVLD.Applications.Tests.Controls
{
    public partial class ctrlScheduleTestWithHadhoud : UserControl
    {
        public ctrlScheduleTestWithHadhoud()
        {
            InitializeComponent();
        }
        public enum enMode { AddNew = 0, Update = 1 };
        enMode _Mode = enMode.AddNew;

        private enum enCreationMode { FristTimeSchedule = 0, RetakeTestSchedule = 1 };
        private enCreationMode _CreationMode = enCreationMode.FristTimeSchedule;

        clsTestType.enTestType _TestTypeID = clsTestType.enTestType.VisionTest;

        clsLocalDrivingApplicationsBusiness _LocalDrivingLicenseApplication;
        int _LocalDrivingLicenseApplicationID = -1;

        clsTestApplointmentsBusiness _TestApplointment;
        int _TestApplointmentID = -1;


        public clsTestType.enTestType TestTypeID
        {
            get { return _TestTypeID; }
            set
            {
                _TestTypeID = value;
                switch (_TestTypeID)
                {
                    case clsTestType.enTestType.VisionTest:
                        {
                            gbTestName.Text = "Vision Test";
                            pbTestType.Image = Resources.VisionTest;

                            break;
                        }
                    case clsTestType.enTestType.WrittenTest:
                        {
                            gbTestName.Text = "Written Test";
                            pbTestType.Image = Resources.WrittenTest;

                            break;
                        }
                    case clsTestType.enTestType.StreetTest:
                        {
                            gbTestName.Text = "Street Test";
                            pbTestType.Image = Resources.StreetTest;

                            break;
                        }
                }




            }
        }

        public void LoadInfo(int LocalDrivingApplicationID, int AppointmentID = -1)
        {
            //if no appointment id this means AddNew mode otherwise it's update mode.
            if (AppointmentID == -1)
                _Mode = enMode.AddNew;
            else
                _Mode = enMode.Update;


            _LocalDrivingLicenseApplicationID = LocalDrivingApplicationID;
            _TestApplointmentID = AppointmentID;
            _LocalDrivingLicenseApplication = clsLocalDrivingApplicationsBusiness.Find(_LocalDrivingLicenseApplicationID);

            if (_LocalDrivingLicenseApplication == null)
            {
                MessageBox.Show("Error: No Local Driving License Application with ID = " + _LocalDrivingLicenseApplicationID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return;
            }

            if (_LocalDrivingLicenseApplication.DoesAttendTestType(_TestTypeID))
            {
                _CreationMode = enCreationMode.RetakeTestSchedule;
            }
            else
            {
                _CreationMode = enCreationMode.FristTimeSchedule;

            }


            if (_CreationMode == enCreationMode.RetakeTestSchedule)
            {
                lblRAppFees.Text = clsApplicationTypes.Find((int)clsApplicationBusiness.enApplicationType.RetakeTest).Fees.ToString();
                gbRetakeTest.Enabled = true;
                lblTitleName.Text = "Schedule Retake Test";
                lblRTestAppID.Text = "0";
            }
            else
            {
                gbRetakeTest.Enabled = false;
                lblTitleName.Text = "Schedule Test";
                lblRTestAppID.Text = "N/A";
                lblRAppFees.Text = "0";
            }
            lblDLAPPID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();
            lblClass.Text = _LocalDrivingLicenseApplication.LicensInfo.ClassName;
            lblName.Text = _LocalDrivingLicenseApplication.ApplicantFullName;
            lblTrail.Text = clsTestApplointmentsBusiness.GetCountTrail(_LocalDrivingLicenseApplicationID, (byte)_TestTypeID).ToString();


            if (_Mode == enMode.AddNew)
            {
                lblFees.Text = clsTestType.Find(TestTypeID).TestTypeFees.ToString();
                dtpDate.MinDate = DateTime.Now;
                lblRTestAppID.Text = "N/A";
                _TestApplointment = new clsTestApplointmentsBusiness();
            }
            else
            {
                if (!_LoadTestAppointmentData())
                {
                    return;

                }
            }
            lblTotalFees.Text = (Convert.ToSingle(lblFees.Text) + Convert.ToSingle(lblRAppFees.Text)).ToString();

            if (!_HandleActiveTestAppointmentConstraint())
                return;
            if (!_HandleAppointmentLockedConstraint())
                return;

            if (!_HandlePrviousTestConstraint())
                return;


        }
        private bool _LoadTestAppointmentData()
        {
            _TestApplointment = clsTestApplointmentsBusiness.Find(_TestApplointmentID);

            if (_TestApplointment == null)
            {
                MessageBox.Show("Error: No Appointment with ID = " + _TestApplointmentID.ToString(),
             "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = false;
                return false;
            }
            lblFees.Text = _TestApplointment.PaidFees.ToString();

            //we compare the current date with the appointment date to set the min date.
            if (DateTime.Compare(DateTime.Now, _TestApplointment.ApplointmentDate) < 0)
            {
                dtpDate.MinDate = DateTime.Now;
            }
            else
            {
                dtpDate.MinDate = _TestApplointment.ApplointmentDate;
            }

            if (_TestApplointment.RetakeTestApplicationID == -1)
            {
                lblRAppFees.Text = "0";
                lblRTestAppID.Text = "N/A";
            }
            else
            {
                gbRetakeTest.Enabled = true;
                lblRAppFees.Text = _TestApplointment.RetakeTestAppInfo.PaidFees.ToString();
                lblRTestAppID.Text = _TestApplointment.RetakeTestApplicationID.ToString();
                lblTitleName.Text = "Schedule Retake Test";

            }
            return true;


        }
        private bool _HandleActiveTestAppointmentConstraint()
        {
            if (_Mode == enMode.AddNew && clsTestApplointmentsBusiness.DoesLocalApplicationHasAnActiveAppionment((int)_TestTypeID, _LocalDrivingLicenseApplicationID))
            {
                lblUserMessege.Text = "Person Already have an active appointment for this test";
                btnSave.Enabled = false;
                dtpDate.Enabled = false;
                return false;
            }

            return true;
        }

        private bool _HandleAppointmentLockedConstraint()
        {
            //if appointment is locked that means the person already sat for this test
            //we cannot update locked appointment
            if (_TestApplointment.isLocked)
            {
                lblUserMessege.Visible = true;
                lblUserMessege.Text = "Person already sat for the test, appointment loacked.";
                dtpDate.Enabled = false;
                btnSave.Enabled = false;
                return false;

            }
            else
                lblUserMessege.Visible = false;

            return true;
        }

        private bool _HandlePrviousTestConstraint()
        {
            switch (_TestTypeID)
            {
                case clsTestType.enTestType.VisionTest:
                    {
                        lblUserMessege.Visible = false;

                        return true;
                    }
                case clsTestType.enTestType.WrittenTest:
                    {
                        if (!clsTestApplointmentsBusiness.DoesLocalApplicationPassedTest((int)clsTestType.enTestType.VisionTest, _LocalDrivingLicenseApplicationID))
                        {
                            lblUserMessege.Text = "Cannot Sechule, Vision Test should be passed first";
                            lblUserMessege.Visible = true;
                            btnSave.Enabled = false;
                            dtpDate.Enabled = false;
                            return false;
                        }
                        else
                        {
                            lblUserMessege.Visible = false;
                            btnSave.Enabled = true;
                            dtpDate.Enabled = true;
                        }
                        return true;
                    }
                case clsTestType.enTestType.StreetTest:
                    {
                        if (!clsTestApplointmentsBusiness.DoesLocalApplicationPassedTest((int)clsTestType.enTestType.WrittenTest, _LocalDrivingLicenseApplicationID))
                        {
                            lblUserMessege.Text = "Cannot Sechule, Written Test should be passed first";
                            lblUserMessege.Visible = true;
                            btnSave.Enabled = false;
                            dtpDate.Enabled = false;
                            return false;
                        }
                        else
                        {
                            lblUserMessege.Visible = false;
                            btnSave.Enabled = true;
                            dtpDate.Enabled = true;
                        }
                        return true;
                    }
            }

            return true;



        }

        private bool _HandleRetakeApplication()
        {
            if (_Mode == enMode.AddNew && _CreationMode == enCreationMode.RetakeTestSchedule)
            {
                clsApplicationBusiness RetakeApplication = new clsApplicationBusiness();


                RetakeApplication.ApplicationPersonID = _LocalDrivingLicenseApplication.ApplicationPersonID;
                RetakeApplication.ApplicationDate = DateTime.Now;
                RetakeApplication.ApplicationTypeID = (int)clsApplicationBusiness.enApplicationType.RetakeTest;
                RetakeApplication.ApplicationStatus = clsApplicationBusiness.enApplicationStatus.Completed;
                RetakeApplication.LastStatusDate = DateTime.Now;
                RetakeApplication.PaidFees = clsApplicationTypes.Find((int)clsApplicationBusiness.enApplicationType.RetakeTest).Fees;
                RetakeApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;

                if (!RetakeApplication.Save())
                {
                    _TestApplointment.RetakeTestApplicationID = -1;
                    MessageBox.Show("Faild to Create application", "Faild", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                _TestApplointment.RetakeTestApplicationID = RetakeApplication.ApplicationID;

            }
            return true;


        }




    

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_HandleRetakeApplication())
            {
                return;
            }



            _TestApplointment.TestTypeID =(int) _TestTypeID;
            _TestApplointment.LocalDrivingLicenseApplicationsID = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID;
            _TestApplointment.ApplointmentDate = dtpDate.Value;
            _TestApplointment.PaidFees = Convert.ToSingle(lblFees.Text);
            _TestApplointment.CreatedByUserID = clsGlobal.CurrentUser.UserID;

            if (_TestApplointment.Save())
            {
                _Mode = enMode.Update;
                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
               
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);



        }
    }
}
