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
    public partial class ctrlDrivingLicenseWithFilter : UserControl
    {
        clsInternationalDrivingLicenseApplicaitonBusiness _InternationalLicense;
        clsLicenseBusniess _License;
       public int LicenseID
        {
            get { return ctrlDriverLicenseInfo1.LicenseID; }
        }
        int _LicenseID = -1;
        public clsLicenseBusniess LicenseInfo
        {
            get { return ctrlDriverLicenseInfo1.SelectedLicenseInfo; }
        }

        public event Action<int> OnLicenseSelected;
        protected virtual void LicenseSelected(int LicenseID)
        {
            Action<int> Handler = OnLicenseSelected;
            if(Handler != null)
            {
                Handler(LicenseID);
            }
        }
        bool _FitlerEnabile=true;
        public bool FilterEnable
        {
            set { _FitlerEnabile = value;
                txtFindLicense.Enabled = _FitlerEnabile; }
            get {return _FitlerEnabile; }
        }

        public void LoadLicenseInfo(int LicenseID)
        {
            txtFindLicense.Text = LicenseID.ToString();
            ctrlDriverLicenseInfo1.LoadLicenseInfo(LicenseID);
            _LicenseID = ctrlDriverLicenseInfo1.LicenseID;
       
            if (OnLicenseSelected != null)
            {
                OnLicenseSelected(ctrlDriverLicenseInfo1.LicenseID);
            }

        }

        public void txtLicenseIDFocus()
        {
            txtFindLicense.Focus();
        }


        public ctrlDrivingLicenseWithFilter()
        {
            InitializeComponent();
        }



        private void btnFind_Click(object sender, EventArgs e)
        {
            _LicenseID = int.Parse(txtFindLicense.Text);
            LoadLicenseInfo(_LicenseID);

        }
    }
}
