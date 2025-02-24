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
    public partial class frmTestTypes : Form
    {

        DataTable _dtAllTestType;
        public frmTestTypes()
        {
            InitializeComponent();
        }

        private void frmTestTypes_Load(object sender, EventArgs e)
        {
            _dtAllTestType=clsTestType.GetAllTestTypes();
            dgvTestType.DataSource = _dtAllTestType;
            lblRecordsNumber.Text = "#" + (dgvTestType.RowCount -1);

            dgvTestType.Columns[0].HeaderText = "ID";
            dgvTestType.Columns[0].Width = 110;

            dgvTestType.Columns[1].HeaderText = "Title";
            dgvTestType.Columns[1].Width = 250;
            dgvTestType.Columns[2].HeaderText = "Description";
            dgvTestType.Columns[2].Width = 450;
            dgvTestType.Columns[3].HeaderText = "Fees";
            dgvTestType.Columns[3].Width = 100;
        }

        private void editTestTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditTestType frm = new frmEditTestType((clsTestType.enTestType)dgvTestType.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmTestTypes_Load(null, null);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
