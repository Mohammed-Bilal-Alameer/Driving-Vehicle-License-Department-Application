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

namespace DVLD.User
{
    public partial class UsersList : Form
    {
          static DataTable _dtUsersList=clsUser.GetAllUsers();
          static DataView _dvUser = _dtUsersList.DefaultView;
        public UsersList()
        {
            InitializeComponent();
        }

        private void UsersList_Load(object sender, EventArgs e)
        {
            _RefreshUsers();
            _dtUsersList = clsUser.GetAllUsers();
            dgvUsers.DataSource = _dtUsersList;
            cbFillter.SelectedIndex = 0;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void _RefreshUsers()
        {
            dgvUsers.DataSource=clsUser.GetAllUsers();
            lblUsersNumbers.Text ="#"+ dgvUsers.RowCount.ToString()+" Records";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //AddUpdateUser addUpdateUser = new AddUpdateUser();
            //addUpdateUser.ShowDialog();


            frmAddUpdateUserWithHadhoud frm=new frmAddUpdateUserWithHadhoud();
            frm.ShowDialog();
            UsersList_Load(null, null);

        }

        private void updateUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdateUserWithHadhoud frm = new frmAddUpdateUserWithHadhoud((int)dgvUsers.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            UsersList_Load(null, null);

        }

        private void cbFillter_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbFillter.SelectedIndex != 0)
            {
                txtFillter.Visible = true;
                txtFillter.Focus();
            }
            else
            {
                txtFillter.Visible = false;
            }
        }

        private void txtFillter_TextChanged(object sender, EventArgs e)
        {
            switch (cbFillter.SelectedItem)
            {
                case "User ID":
                    {
                        if (int.TryParse(txtFillter.Text, out int ID))
                        {
                            _dvUser.RowFilter = $"[UserID]='{ID}'";
                        
                        }
                     
                        break;
                    }
                case "Person ID":
                    {
                        if (int.TryParse(txtFillter.Text, out int ID))
                        {
                     
                            _dvUser.RowFilter = $"[PersonID]='{ID}'";
                         
                        }
                     

                        break;
                    }
                case "UserName":
                    {
                      
                            _dvUser.RowFilter = $"UserName like '{txtFillter.Text}%'";

                        

                        break;
                    }

                default:
                    {
                        _dvUser = _dtUsersList.DefaultView;

                        break;
                    }
            }
            if (string.IsNullOrEmpty(txtFillter.Text))
            {
                dgvUsers.DataSource = _dvUser;

            }
        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this User?", "Confirm Delete", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {


                if (clsUser.DeleteUser((int)dgvUsers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("User Deleted Successfully.");
                   _RefreshUsers();
                }
            }

            else
            {
                MessageBox.Show("User is not deleted.");

            }
            _RefreshUsers();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword Change=new frmChangePassword((int)dgvUsers.CurrentRow.Cells[0].Value);
            Change.ShowDialog();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowUserInfo frmShowUserInfo = new frmShowUserInfo((int)dgvUsers.CurrentRow.Cells[0].Value);
            frmShowUserInfo.ShowDialog();
        }
    }
}
