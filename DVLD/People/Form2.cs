using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD.Properties;
using DVLD_Business;
using System.IO;
using DVLD.Global_Classes;

namespace DVLD.People
{
    public partial class frmAddEditPerson : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);
        public event DataBackEventHandler DataBack;
        public enum enMode { AddNew=0,Update=1};
        enMode _Mode;
        
        clsPerson _Person;
        int _PersonID=-1;


        public frmAddEditPerson(int PersonID)
        {
            InitializeComponent();
       
            if(PersonID == -1)
            {
            _Mode = enMode.AddNew;
            }
            else
            {
                _Mode = enMode.Update;
                _PersonID = PersonID;
            }

        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            DataBack?.Invoke(this, _Person.PersonID);

            this.Close();
            
        }

        private void _FillComboBoxWithCountries()
        {
            cbCountry.DisplayMember = "CountryName";
            cbCountry.ValueMember = "CountryID";
            cbCountry.DataSource = clsCountries.GetAllCountries();
            cbCountry.SelectedIndex = 83;
        }

        private void _ChangeFormHeader()
        {
            if(_Mode == enMode.Update) {
                lblPersonID.Text = _Person.PersonID.ToString();
            }


            lbHeader.Text=(_Mode==enMode.AddNew)?"Add New Person":"Update Person";
        }


        private void _FillPersonData()
        {
            _Person.FirstName   = txtFirstName.Text;
            _Person.LastName    = txtLastName.Text;
            _Person.Email       = txtEmail.Text;
            _Person.SecondName  = txtSecondName.Text;
            _Person.ThirdName   = txtThirdName.Text;
            _Person.TheIDNumber = txtTheIdNumber.Text;
            _Person.Address     = rtbAddress.Text;
            if (rdMale.Checked)
            {
                _Person.Gendor = true;
            }
            else
            {
                _Person.Gendor = false;
            }     
            _Person.DateOfBirth = dtpDateOfBirth.Value;
            _Person.PhoneNumber = txtPhoneNumber.Text;
            _Person.CountryID   = Convert.ToInt32(cbCountry.SelectedValue);
            if(pbPerson.ImageLocation!=null)
            {
                _Person.ImagePath = pbPerson.ImageLocation;

            }
            else
            {
                _Person.ImagePath = "";
            }

        }
        private void _FillInfoForUpdate()
        {
            txtFirstName.Text = _Person.FirstName;
            txtLastName.Text = _Person.LastName;
            txtEmail.Text = _Person.Email;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtTheIdNumber.Text = _Person.TheIDNumber;
            rtbAddress.Text = _Person.Address;
            dtpDateOfBirth.Value = _Person.DateOfBirth;
            txtPhoneNumber.Text = _Person.PhoneNumber;
            cbCountry.SelectedValue = _Person.CountryID;
            


            if (_Person.Gendor)
            {
                rdMale.Checked = true;
            }
            else
            {
                rdFemale.Checked = true;
            }

            if(_Person.ImagePath!= "")
            {
                pbPerson.ImageLocation = _Person.ImagePath;
            }

            llblRemovePic.Visible = _Person.ImagePath != "";



        }
        private void frmAddEditPerson_Load(object sender, EventArgs e)
        {
            switch (_Mode)
            {
                case enMode.AddNew:
                    {
                        _Person = new clsPerson();
                        break;
                    }
                case enMode.Update:
                {
                        _Person = clsPerson.Find(_PersonID);
                        _FillInfoForUpdate();
                        break;
                }

            }
            _ChangeFormHeader();
            _FillComboBoxWithCountries();
            
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            //if (!_HandlePersonImage())
            //    return;


            _FillPersonData();
     

            if (_Person.Save())
            {
                _Mode = enMode.Update;
                _ChangeFormHeader();
                MessageBox.Show("Data Saved Successfully.");
                DataBack?.Invoke(this, _Person.PersonID);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.");




        }

        private void LkLPhoto_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Choose Picture";
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath=openFileDialog.FileName;
                pbPerson.Image=Image.FromFile(filePath);
                pbPerson.ImageLocation = filePath;

                if(pbPerson.ImageLocation != "")
                {
                    llblRemovePic.Visible = true;
                }
            }

           

        }


        private bool _HandlePersonImage()
        {



            if(_Person.ImagePath != pbPerson.ImageLocation)
            {
                if (_Person.ImagePath != "")
                {
                    try
                    {
                        File.Delete(_Person.ImagePath);

                    }
                    catch (IOException)
                    {

                    }
                }


            }

            if (pbPerson.ImageLocation != null)
            {
                string SourceFile=pbPerson.ImageLocation.ToString();
                if(clsUtil.CopyImageToProjectImagesFolder(ref SourceFile))
                {
                    pbPerson.ImageLocation = SourceFile;
                    return true;
                }
            }
            else
            {
                MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return false;

        }

        private void rdMale_CheckedChanged(object sender, EventArgs e)
        {
            _ChangeGenderStatus();

        }

        private void rdFemale_CheckedChanged(object sender, EventArgs e)
        {
            _ChangeGenderStatus();
        }
        private void _ChangeGenderStatus()
        {
            if (string.IsNullOrEmpty(pbPerson.ImageLocation))
            {
                pbPerson.Image = (rdMale.Checked) ? Resources.flight_attendant_male : Resources.admin_female;
            }
        }

        private void pbPerson_Click(object sender, EventArgs e)
        {

        }

        private void txtTheIdNumber_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtTheIdNumber.Text)||clsPerson.IsNationalNoExist(txtTheIdNumber.Text))
            {
                e.Cancel= true;
                txtTheIdNumber.Focus();
                errorProvider1.SetError(txtTheIdNumber,"This Faild is Empty or already Exist");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtTheIdNumber, "");

            }
           
        }

    private bool IsTheCharExist(string S1,char CharToFind)
        {

            for(int i = 0; i < S1.Length; i++)
            {
                if (S1[i] == CharToFind)
                {
                    return true;
                }
            }
            return false;
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {


           
            if (!IsTheCharExist(txtEmail.Text, '@')||!IsTheCharExist(txtEmail.Text,'.'))
            {
                e.Cancel = true;
                txtEmail.Focus();
                errorProvider1.SetError(txtEmail, "False Format For Email");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEmail, "");

            }



        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtTheIdNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void llblRemovePic_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPerson.ImageLocation = null;
            if (rdMale.Checked)
                pbPerson.Image = Resources.flight_attendant_male;
            else
                pbPerson.Image = Resources.admin_female;
            llblRemovePic.Visible=false;
        }

        private void frmAddEditPerson_EnabledChanged(object sender, EventArgs e)
        {

        }

        private void dtpDateOfBirth_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
