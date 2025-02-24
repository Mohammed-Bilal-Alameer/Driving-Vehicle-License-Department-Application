using DVLD.Controls;
using DVLD.People;
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
    public partial class frmShowLocalApplicationInfo : Form
    {
        int _LocalID = 0;
        public frmShowLocalApplicationInfo(int LocalID)
        {
            InitializeComponent();
            _LocalID = LocalID;
        }

        private void frmShowLocalApplicationInfo_Load(object sender, EventArgs e)
        {
            ctrlApplicationInfo1.LoadLocalApplicationInfo(_LocalID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
