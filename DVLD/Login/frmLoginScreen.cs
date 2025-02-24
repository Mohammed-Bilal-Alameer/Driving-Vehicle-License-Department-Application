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
using DVLD.Login;

namespace DVLD.Login
{
    public partial class frmLoginScreen : Form
    {
        public frmLoginScreen()
        {
            InitializeComponent();
        }

        private void clsLogin_Click(object sender, EventArgs e)
        {
            clsUsersWithHadhuad User=clsUsersWithHadhuad.FindByUsernameAndPassword(txtUserName.Text.Trim(),txtPassword.Text.Trim());


            if(User!=null)
            {
                if (!User.IsActive)
                {
                    txtUserName.Focus();
                    MessageBox.Show("Your accound is not Active, Contact Admin.", "In Active Account", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                clsGlobal.CurrentUser = User;




                this.Hide();
                    frmDVLDMain Open = new frmDVLDMain(this);
                    Open.ShowDialog();
              
             
            }
            else
            {
                MessageBox.Show("UserName Or Password is not exist");
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void ckShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if(ckShowPassword.Checked==true) {
            txtPassword.UseSystemPasswordChar= false;
            
            }
            else
            {
                txtPassword.UseSystemPasswordChar = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
