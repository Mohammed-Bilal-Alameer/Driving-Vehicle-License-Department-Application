using DVLD_Business;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Licenses.Controls
{
    public partial class ctrlDriverLicenseInfo : UserControl
    {
        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
        }
        clsLicenseBusniess _LicenseInfo;
        private int _LicenseID;

        public int LicenseID
        {
            get { return _LicenseID; }
        }

        public clsLicenseBusniess SelectedLicenseInfo
        { get { return _LicenseInfo; } }

        public void LoadLicenseInfo(int LicenseID)
        {
            _LicenseID = LicenseID;
          _LicenseInfo =clsLicenseBusniess.GetLicenseInfoByLicenseID(_LicenseID);
            if (_LicenseInfo == null)
            {
                MessageBox.Show("Could not find License ID = " + _LicenseID.ToString(),
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _LicenseID = -1;
                return;
            }

            if (clsDetainBusiness.IsLicenseDetained(_LicenseID))
            {
                lblisDetained.Text = "Yes";
            }
            else
            {
                lblisDetained.Text = "No";

            }




            lblClassName.Text = _LicenseInfo.LicenseClassInfo.ClassName;
            lblPersonName.Text = _LicenseInfo.DriverInfo.PersonInfo.FullName();
            lblLicenseID.Text = _LicenseInfo.LicenseID.ToString();
            lblNationalNo.Text = _LicenseInfo.DriverInfo.PersonInfo.TheIDNumber;
            if (_LicenseInfo.DriverInfo.PersonInfo.Gendor == true)
            {
                lblGender.Text = "M";
            }
            else
            {
                lblGender.Text = "F";
            }
            lblIssueDate.Text= _LicenseInfo.IssueDate.ToString();
            lblReason.Text = _LicenseInfo.IssueReasonText;
            lblNotes.Text= _LicenseInfo.Notes;
            // لازم تتحول لyes or no

            lblisActive.Text = _LicenseInfo.isActive.ToString();
            lblDateOfBirth.Text = _LicenseInfo.DriverInfo.PersonInfo.DateOfBirth.ToString();
            lblDriverID.Text = _LicenseInfo.DriverID.ToString();
            lblExpDate.Text = _LicenseInfo.ExpirationDate.ToString();

            pbPerson.ImageLocation = _LicenseInfo.DriverInfo.PersonInfo.ImagePath;





        }



    }
}
