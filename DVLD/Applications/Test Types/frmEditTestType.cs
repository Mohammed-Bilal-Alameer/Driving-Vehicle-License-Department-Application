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

namespace DVLD.Applications.Test_Types
{
    public partial class frmEditTestType : Form
    {
        clsTestType.enTestType _ID;
        clsTestType _TestType;
        public frmEditTestType(clsTestType.enTestType ID)
        {
            InitializeComponent();
            _ID = ID;
        }

        private void frmEditTestType_Load(object sender, EventArgs e)
        {
            _LoadData();

        }


        private void _LoadData()
        {
            _TestType = clsTestType.Find(_ID);
            lblIDResult.Text = ((int)_ID).ToString();
            txtTitle.Text = _TestType.TestTitle;
            rtxtDescription.Text = _TestType.TestDescription;
            txtFees.Text = _TestType.TestTypeFees.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _TestType.TestTitle = txtTitle.Text;
            _TestType.TestDescription = rtxtDescription.Text;
            _TestType.TestTypeFees = Convert.ToSingle(txtFees.Text);

            if (_TestType != null)
            {
                _TestType.Save();
                MessageBox.Show("Data Saved Successfully.");
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.");

            }
        }
    }
}
