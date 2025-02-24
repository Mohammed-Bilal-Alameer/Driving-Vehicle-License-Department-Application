using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business;


namespace DVLD.People
{
    public partial class frmListPeople : Form
    {

        private static DataTable _DataListOfPeople= clsPerson.GetAllPeople();
      
        private static DataTable _dtPeople = _DataListOfPeople.DefaultView.ToTable(false, "PersonID", "FirstName", "SecondName", "ThirdName", "LastName");
        private static DataView _DataViewOfPeople = _DataListOfPeople.DefaultView;
        public frmListPeople()
        {
            InitializeComponent();
        }




        private void frmListPeople_Load(object sender, EventArgs e)
        {
            dgvPeople.DataSource = _dtPeople;
            cbFillter.SelectedIndex = 0;
        }
        private void _RefreshPeoplesList()
        {
           _DataListOfPeople = clsPerson.GetAllPeople();

        _dtPeople = _DataListOfPeople.DefaultView.ToTable(false, "PersonID", "FirstName", "SecondName", "ThirdName", "LastName");


            dgvPeople.DataSource = _dtPeople;



            if (dgvPeople.RowCount==1)
            lblPeopleNumber.Text="#"+ dgvPeople.RowCount.ToString()+" Record";


            else lblPeopleNumber.Text = "#" + dgvPeople.RowCount.ToString() + " Records";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frmAddEditPerson = new frmAddEditPerson(-1);
            frmAddEditPerson.ShowDialog();
            _RefreshPeoplesList();
        }

        private void contextMenuStrip1_MouseHover(object sender, EventArgs e)
        {
            BackColor = Color.AliceBlue;
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson(-1);
            frmListPeople_Load(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmListPeople_Load(null, null);

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
           if( MessageBox.Show("Are you sure you want to delete this Person?", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                

                if (clsPerson.DeletePerson((int)dgvPeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Deleted Successfully.");
                    _RefreshPeoplesList();
                }
            }

            else
            {
                MessageBox.Show("Person is not deleted.");

            }
            frmListPeople_Load(null, null);

        }

        private void cbFillter_SelectedIndexChanged(object sender, EventArgs e)
        {


            if( cbFillter.SelectedIndex != 0 )
            {
                txtFillter.Visible = true;
                txtFillter.Focus();
            }
            else
            {
                txtFillter.Visible = false;
                dgvPeople.DataSource = _DataViewOfPeople;
            }



        }

        private void txtFillter_TextChanged(object sender, EventArgs e)
        {
            switch (cbFillter.SelectedItem)
            {
                case "Person ID":
                    {
                        if (int.TryParse(txtFillter.Text, out int ID))
                        {
                            _DataViewOfPeople.RowFilter = $"[PersonID]  = '{ID}'";

                            
                        }
                  

                        break;
                    }
                case "FirstName":
                    {
                        _DataViewOfPeople.RowFilter = $"FirstName Like '{txtFillter.Text}%'";
                        break;
                    }
                case "LastName":
                    {
                        _DataViewOfPeople.RowFilter = $"LastName Like '{txtFillter.Text}%'";
                        break;
                    }
             

                default:
                    {
                        dgvPeople.DataSource = _DataViewOfPeople;
                        break;

                    }


            }
      

        }

        private void showDetalisToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowDetails frm= new ShowDetails((int)dgvPeople.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmListPeople_Load(null, null);

        }

        private void txtFillter_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (cbFillter.SelectedIndex == 1)
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            }
        }

        private void findPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFindPerson frm = new frmFindPerson();
            frm.ShowDialog();
        }
    }
}
