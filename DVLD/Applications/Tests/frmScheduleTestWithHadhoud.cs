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
    public partial class frmScheduleTestWithHadhoud : Form
    {

        int _LocalDriving = -1;
        clsTestType.enTestType _enTestType;
        int _AppointmentID = -1;

        public frmScheduleTestWithHadhoud(int LLDID, clsTestType.enTestType TestType, int AppointmentID = -1)
        {
            InitializeComponent();
            _LocalDriving = LLDID;
            _enTestType = TestType;
            _AppointmentID = AppointmentID;
        }

        private void frmScheduleTestWithHadhoud_Load(object sender, EventArgs e)
        {
            ctrlScheduleTestWithHadhoud1.TestTypeID = _enTestType;
            ctrlScheduleTestWithHadhoud1.LoadInfo(_LocalDriving, _AppointmentID);
        }
    }
}
