using DVLD.People;
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
    public partial class AddUpdateUser : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };
        enMode _Mode;

        clsUser _User;
        int _UserID = -1;
        public AddUpdateUser(int UserID)
        {
            InitializeComponent();
          
                _Mode = enMode.Update;
                _UserID = UserID;
            
        }
        public AddUpdateUser()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;

        }
        int _PersonDeleget=0;
        private void btnCloseAddUser_Click(object sender, EventArgs e)
        {
            this.Close();
            
        }

        private void btnSelectPerson_Click(object sender, EventArgs e)
        {
            frmFindPerson frmFindPerson = new frmFindPerson();
            frmFindPerson.DataBack += _DataBack;
            frmFindPerson.ShowDialog();
        }

        private void _DataBack(object sender,int PersonID)
        {
            _PersonDeleget= PersonID;
            ctrlPersonCard2.LoadPersonInfo(PersonID);
        }

 

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (clsUser.IsUserIDExist(_PersonDeleget))
            {
                MessageBox.Show("This user already has a User");
            }
            else if( _PersonDeleget == 0)
            {
                MessageBox.Show("You Should Choose Person First");

            }
            else
            {
                tcPersonInfo.SelectedIndex = 1;
            }
        }

        private void tabLoginInfo_MouseClick(object sender, MouseEventArgs e)
        {
            btnSave.Enabled = true;
        }



        private void tcPersonInfo_SelectedIndexChanged(object sender, EventArgs e)
        {

            if(tcPersonInfo.SelectedIndex == 0)
            {
                btnSave.Enabled= false;
            }

            if (tcPersonInfo.SelectedIndex == 1)
            {

                btnSave.Enabled = true;
            }
        }


    
        private void btnSave_Click(object sender, EventArgs e)
        {
           

            if (txtConfirmPassword.Text != txtPassword.Text)
            {
                MessageBox.Show("Password Failds is not the same");
                return;
            }



            _User.UserName = txtUserName.Text.Trim();
            _User.Password = txtPassword.Text.Trim();
            _User.IsActive = cbIsActive.Checked;
            _User.PersonID = _PersonDeleget;

            if (_User.Save())
            {
                lblUserID.Text = _User.UserID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lblHeader.Text = "Update User";
                this.Text = "Update User";
                MessageBox.Show("Data Saved Successfully.");

            }
            else
            {
                MessageBox.Show("Error: Data Is not Saved Successfully.");

            }
        }

        private void _FillInfoForUpdate()
        {
            _User = clsUser.Find(_UserID);
                lblUserID.Text=_UserID.ToString(); 
                txtUserName.Text= _User.UserName;
                txtPassword.Text= _User.Password;
                if (cbIsActive.Checked == true)
                {                      
                    _User.IsActive = true;
                }
                else
                {
                _User.IsActive = false;
            }
            ctrlPersonCard2.LoadPersonInfo(_User.PersonID);
        }


        private void AddUpdateUser_Load(object sender, EventArgs e)
        {

            _ResetDefualtValues();

            if (_Mode == enMode.Update)
            {

                _FillInfoForUpdate();
            }

        }
        private void _ResetDefualtValues()
        {
            if (_Mode == enMode.AddNew)
            {
                lblHeader.Text = "Add New User";
                this.Text = "Add New User";
                llblEditPerson.Visible = false;

                _User = new clsUser();


                
            }
            else
            {
                lblHeader.Text = "Update User";
                this.Text = "Update User";
                llblEditPerson.Visible = true;

                btnSave.Enabled = true;


            }

            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            cbIsActive.Checked = true;
        }
     

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUserName.Text))
            {
                e.Cancel = true;
                txtUserName.Focus();
                errorProvider1.SetError(txtUserName, "This Fails is Req");
            }
            else
            {
                e.Cancel= false;
                errorProvider1.SetError(txtUserName, "");

            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                e.Cancel = true;
                txtUserName.Focus();
                errorProvider1.SetError(txtConfirmPassword, "Password is not the same");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirmPassword, "");

            }
        }

        private void llblEditPerson_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPerson Edit = new frmAddEditPerson(_User.PersonID);
            Edit.ShowDialog();
        }
    }
}
