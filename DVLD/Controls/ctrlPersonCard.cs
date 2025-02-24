using DVLD.Properties;
using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DVLD.People;


namespace DVLD.Controls
{
    public partial class ctrlPersonCard : UserControl
    {
        private clsPerson _CurrentPerson;


        private int _PersonID=-1;
        public ctrlPersonCard()
        {
            InitializeComponent();
         

        }
        public clsPerson SelectedPersonInfo
        {
        get { return _CurrentPerson; }
        }
        public int PersonID {
            get { return _PersonID; }
        }


        

        private void ctrlPersonCard_Load(object sender, EventArgs e)
        {
       
        }
        private void _FillPersonInfo()
        {
            if (_CurrentPerson != null)
            {
                _PersonID = _CurrentPerson.PersonID;
                lblPersonID.Text = _CurrentPerson.PersonID.ToString();
                lblName.Text = _CurrentPerson.FullName();
                lblPhone.Text = _CurrentPerson.PhoneNumber;
                lblTheIDNumber.Text= _CurrentPerson.TheIDNumber;
                lblDateOfBirth.Text= _CurrentPerson.DateOfBirth.ToString();
                if (_CurrentPerson.Gendor == false)
                {
                    lblGender.Text = "Female";
                }
                else
                {
                    lblGender.Text = "Male";

                }
                lblCountry.Text=_CurrentPerson.CountryID.ToString();
                lblAddress.Text = _CurrentPerson.Address;
                lblEmail.Text=_CurrentPerson.Email;
                _LoadPersonImage();


            }
        }
        public void LoadPersonInfo(int PersonID)
        {
            _CurrentPerson = clsPerson.Find(PersonID);
            if( _CurrentPerson == null ) { 
            ResetPersonInfo();
                MessageBox.Show("No Person with Person ID = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _FillPersonInfo();
        }

        public void LoadPersonInfo(string NationalNo)
        {
            _CurrentPerson = clsPerson.Find(NationalNo);
            if (_CurrentPerson == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with NationalNo  = " + NationalNo, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;

            }

            _FillPersonInfo();
        }

        public void ResetPersonInfo()
        {

            _PersonID = -1;
            lblPersonID.Text = "[????]";
            lblTheIDNumber.Text = "[????]";
            lblName.Text = "[????]";
            pbCard.Image = Resources.flight_attendant_male;
            lblGender.Text = "[????]";
            lblEmail.Text = "[????]";
            lblPhone.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblCountry.Text = "[????]";
            lblAddress.Text = "[????]";
            pbCard.Image = Resources.flight_attendant_male;


        }


        private void _LoadPersonImage()
        {
            if (_CurrentPerson.Gendor == true)
            {
                pbCard.Image = Resources.flight_attendant_male;
            }
            else
            {
                pbCard.Image = Resources.admin_female;
            }
            string ImagePath=_CurrentPerson.ImagePath;
            if(ImagePath != "")
            {
                if (File.Exists(ImagePath))
                {
                    pbCard.ImageLocation = ImagePath;
                }
                else
                {
                    MessageBox.Show("Could not find this image: = " + ImagePath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
        }

        private void llbEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson(_PersonID);
            frm.ShowDialog();
            LoadPersonInfo(_PersonID);
        }
    }
}
