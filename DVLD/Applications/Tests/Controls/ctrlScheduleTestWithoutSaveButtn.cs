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
using static DVLD_Business.clsTestType;

namespace DVLD.Applications.Tests.Controls
{
    public partial class ctrlScheduleTestWithoutSaveButtn : UserControl
    {
        public clsTestType TestTypeInfo;
        public enTestType TestTypeID;
        int _LAppID = -1;
        clsLocalDrivingApplicationsBusiness _LocalApp;
        clsTestApplointmentsBusiness _Appoitment;
        int _AppointmentID = -1;


        public ctrlScheduleTestWithoutSaveButtn()
        {
            InitializeComponent();
        }
        public void LoadScheduleTestInfo(int LocalID, int AppointmentID)
        {


            _AppointmentID = AppointmentID;



            _Appoitment = clsTestApplointmentsBusiness.Find(_AppointmentID);
            _LocalApp = clsLocalDrivingApplicationsBusiness.Find(LocalID);
            TestTypeInfo = clsTestType.Find(TestTypeID);
            _LAppID = LocalID;
            if (_LocalApp == null)
            {
                MessageBox.Show("The Application is not found", "Error");
            }
            else
            {
                lblDLAPPID.Text = LocalID.ToString();
                lblName.Text = _LocalApp.ApplicantFullName;
                lblClass.Text = _LocalApp.LicensInfo.ClassName;
                lblDate.Text = _Appoitment.ApplointmentDate.ToString();
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












        }
    }
}
