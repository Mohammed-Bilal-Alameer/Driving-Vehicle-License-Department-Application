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
    public partial class frmShowInternationalLicenseInfo : Form
    {
        int _InternationalID;
        public frmShowInternationalLicenseInfo(int internationalID)
        {
            InitializeComponent();
            _InternationalID = internationalID;
        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmShowInternationalLicenseInfo_Load(object sender, EventArgs e)
        {
            ctrlInternationalLicenseInfo1.LoadInternationalLicenseInfo(_InternationalID);

        }
    }
}
