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
    public partial class frmAddUpdateUserWithHadhoud : Form
    {

       public enum enMode {AddNew = 0,Update=1 };
        enMode _Mode= enMode.AddNew;
        private int _UserID = -1;
        clsUsersWithHadhuad _User;



        public frmAddUpdateUserWithHadhoud()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddUpdateUserWithHadhoud(int UserID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _UserID = UserID;

        }



        private void _ResetDefualtValue()
        {
            if(_Mode == enMode.AddNew)
            {
                lblHeader.Text = "Add New User";
                this.Text = lblHeader.Text;
                _User=new clsUsersWithHadhuad();
                tabLoginInfo.Enabled = false;
                ctrlPersonCardWithFilter1.FilterFoucs();
            }
            else
            {
                lblHeader.Text = "Update User";
                this.Text = "Update User";

                tcPersonInfo.Enabled = true;
                btnSave.Enabled = true;
            }


            txtUserName.Text = "";
            txtPassword.Text = "";
            txtConfirmPassword.Text = "";
            cbIsActive.Checked = true;


        }

        private void frmAddUpdateUserWithHadhoud_Load(object sender, EventArgs e)
        {
            _ResetDefualtValue();

            if (_Mode == enMode.Update)
            {
                _LoadData();
            }
        }


        private void _LoadData()
        {
            _User = clsUsersWithHadhuad.FindByUserID(_UserID);
            ctrlPersonCardWithFilter1.FilterEnabled = false;

            if (_User == null)
            {
                MessageBox.Show("No User with ID = " + _User, "User Not Found", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();

                return;
            }

            lblUserID.Text = _User.UserID.ToString();
            txtUserName.Text = _User.UserName;
            txtPassword.Text = _User.Password;
            txtConfirmPassword.Text = _User.Password;
            cbIsActive.Checked = _User.IsActive;
            ctrlPersonCardWithFilter1.LoadPersonInfo(_User.PersonID);


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }



            _User.PersonID = ctrlPersonCardWithFilter1.PersonID;
            _User.UserName = txtUserName.Text.Trim();
            _User.Password = txtPassword.Text.Trim();
            _User.IsActive = cbIsActive.Checked;


            if (_User.Save())
            {
                lblUserID.Text = _User.UserID.ToString();
                //change form mode to update.
                _Mode = enMode.Update;
                lblHeader.Text = "Update User";
                this.Text = "Update User";

                MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_Mode == enMode.Update)
            {
                btnSave.Enabled = true;
                tcPersonInfo.Enabled = true;
                tcPersonInfo.SelectedTab = tcPersonInfo.TabPages["tabLoginInfo"];
                return;
            }

            if (ctrlPersonCardWithFilter1.PersonID != -1)
            {

                if (clsUsersWithHadhuad.isUserExistForPersonID(ctrlPersonCardWithFilter1.PersonID))
                {

                    MessageBox.Show("Selected Person already has a user, choose another one.", "Select another Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ctrlPersonCardWithFilter1.FilterFoucs();
                }

                else
                {
                    btnSave.Enabled = true;
                    tabLoginInfo.Enabled = true;
                    tcPersonInfo.SelectedTab = tcPersonInfo.TabPages["tabLoginInfo"];
                }
            }
            else

            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ctrlPersonCardWithFilter1.FilterFoucs();

            }


        }

        private void btnCloseAddUser_Click(object sender, EventArgs e)
        {
            this.Close  ();
        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            //رجعلا لا تنساها
        }
    }
}
