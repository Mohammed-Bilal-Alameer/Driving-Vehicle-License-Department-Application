using DVLD.Applications.Tests.Controls;
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
using static DVLD_Business.clsTestType;

namespace DVLD.Applications.Tests
{
    public partial class frmScheduleTestAppointments : Form
    {

        int _LocalDriving=-1;
        clsTestType.enTestType _enTestType;
        int _AppointmentID = -1;
      
        public frmScheduleTestAppointments(int LLDID,clsTestType.enTestType TestType,int AppointmentID=-1)
        {
            InitializeComponent();
            _LocalDriving = LLDID;
            _enTestType = TestType;
            _AppointmentID=AppointmentID;
        }



        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmScheduleTestAppointments_Load(object sender, EventArgs e)
        {
            ctrlScheduleTest1.TestTypeID = _enTestType;
            ctrlScheduleTest1.LoadScheduleTestInfo(_LocalDriving, _AppointmentID);
         // حط الكونترول يلي عملتو مع هدهود لان فيه retake Test

            
        }

        private void ctrlScheduleTest1_Load(object sender, EventArgs e)
        {

        }
    }
}
