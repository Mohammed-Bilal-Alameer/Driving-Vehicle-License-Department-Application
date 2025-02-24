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

namespace DVLD.Licenses.Controls
{
    public partial class ctrlInternationalLicenseInfo : UserControl
    {
        int _InternationalID;
        clsInternationalDrivingLicenseApplicaitonBusiness _InterNationalLicense;
        clsLicenseBusniess _LocalLicense;
        public ctrlInternationalLicenseInfo()
        {
            InitializeComponent();
        }


        public void LoadInternationalLicenseInfo(int InternationalLicenseID)
        {
            _InternationalID= InternationalLicenseID;
            _InterNationalLicense = clsInternationalDrivingLicenseApplicaitonBusiness.FindByInternationalApplicationID(_InternationalID);
            if(_InterNationalLicense == null)
            {
                MessageBox.Show("Error: Didn't Find The License With ID= "+ InternationalLicenseID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _LocalLicense = clsLicenseBusniess.GetLicenseInfoByLicenseID(_InterNationalLicense.IssuedUsingLocalLicenseID);
            lblApplicationID.Text = _InterNationalLicense.ApplicationID.ToString();
            lblDateOfBirth.Text= _LocalLicense.DriverInfo.PersonInfo.DateOfBirth.ToString();
            lblName.Text = _LocalLicense.DriverInfo.PersonInfo.FullName();
            lblLocalLicenseID.Text = _LocalLicense.LicenseID.ToString();
            lblIntLicenseID.Text = _InternationalID.ToString();
            lblIsActive.Text = _InterNationalLicense.IsActive.ToString();
            lblIssueDate.Text = _InterNationalLicense.IssueDate.ToString();
            lblExpDate.Text=_InterNationalLicense.ExpirationDate.ToString();
            lblNationalNo.Text = _LocalLicense.DriverInfo.PersonInfo.TheIDNumber;
            if(_LocalLicense.DriverInfo.PersonInfo.Gendor == true)
            {
                lblGender.Text = "Male";
            }
            else
            {
                lblGender.Text = "Female";
            }
            lblDriverID.Text = _InterNationalLicense.DriverID.ToString();

            pcPersonImage.ImageLocation = _LocalLicense.DriverInfo.PersonInfo.ImagePath;


        }

    }
}
