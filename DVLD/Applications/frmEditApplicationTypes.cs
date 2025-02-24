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

namespace DVLD.Applications
{
    public partial class frmEditApplicationTypes : Form
    {
        int _ID;
        clsApplicationTypes _ApplicationType;
        public frmEditApplicationTypes(int ID)
        {
            InitializeComponent();
            _ID = ID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _ApplicationType.Title=txtTitle.Text;
            _ApplicationType.Fees =Convert.ToSingle(txtFees.Text);

            if (_ApplicationType != null)
            {
                _ApplicationType.Save();
                MessageBox.Show("Data Saved Successfully.");
            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.");

            }
           
        }
        private void _LoadData()
        {
            _ApplicationType = clsApplicationTypes.Find(_ID);
            lblIDResult.Text = _ID.ToString();
            txtTitle.Text = _ApplicationType.Title;
            txtFees.Text=_ApplicationType.Fees.ToString();
        }
        private void frmEditApplicationTypes_Load(object sender, EventArgs e)
        {
            _LoadData();

        }
    }
}
