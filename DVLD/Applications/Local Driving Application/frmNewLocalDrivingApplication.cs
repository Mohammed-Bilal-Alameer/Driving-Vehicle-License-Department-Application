using DVLD.Login;
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


namespace DVLD.Applications.Local_Driving_Application
{
    public partial class frmNewLocalDrivingApplication : Form
    {

        public enum enMode { AddNew = 0, Update = 1 };
        enMode _Mode;
        int _LDAppID;
        clsLocalDrivingApplicationsBusiness _LDA;

        public frmNewLocalDrivingApplication()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }

        public frmNewLocalDrivingApplication(int ID)
        {
            InitializeComponent();
            _LDAppID = ID;

            _Mode = enMode.Update;
        }
       

        private void frmNewLocalDrivingApplication_Load(object sender, EventArgs e)
        {

            _ResetDefaultValue();
            if (_Mode == enMode.Update)
            {
                _LoadData();
            }

        }

        void FillCoboBoxWithLicenceClass()
        {
        DataTable dtClasses=clsLicensesClassesBusiness.GetAllLicensesClasses();
            foreach (DataRow row in dtClasses.Rows)
            {
                cbLicenceClass.Items.Add(row["ClassName"]);
            }
            cbLicenceClass.SelectedIndex = 2;
        }


        void _ResetDefaultValue()
        {
            FillCoboBoxWithLicenceClass();

            if (_Mode == enMode.AddNew)
            {
                lblHeader.Text = "Add New Local Driving Application ";
                _LDA = new clsLocalDrivingApplicationsBusiness();
                tabLDAInfo.Enabled = false;
                ctrlPersonCardWithFilter1.FilterFoucs();
                lblCreatedByUserName.Text = clsGlobal.CurrentUser.UserName;

                lblAppFees.Text = clsApplicationTypes.Find((int)clsApplicationBusiness.enApplicationType.NewDrivingLicense).Fees.ToString();
                lblAppDate.Text = DateTime.Now.ToString();
                
                this.Text = "Add New";
            }
            else
            {
                lblHeader.Text = "Update Local Driving Application ";
                tabLDAInfo.Enabled = true ;
                this.Text = "Update";
                ctrlPersonCardWithFilter1.FilterFoucs();
            }




        }


        void _LoadData()
        {
            _LDA = clsLocalDrivingApplicationsBusiness.Find(_LDAppID) ;
            if (_LDA != null)
            {
                ctrlPersonCardWithFilter1.LoadPersonInfo(_LDA.ApplicationPersonID);
                lblAppDate.Text=_LDA.ApplicationDate.ToString();
                lblAppFees.Text=_LDA.PaidFees.ToString();
                lblCreatedByUserName.Text=_LDA.CreatedByUserID.ToString();
                lblDLApplicationID.Text = _LDAppID.ToString();
                cbLicenceClass.SelectedIndex = _LDA.LicenseClassID-1;
                tabLDAInfo.Enabled = true;

            }

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            _LDA.ApplicationDate = DateTime.Parse(lblAppDate.Text);
                _LDA.ApplicationPersonID = ctrlPersonCardWithFilter1.PersonID;
                _LDA.ApplicationTypeID = 1;
                _LDA.PaidFees = Convert.ToInt32(lblAppFees.Text);
                _LDA.CreatedByUserID = clsGlobal.CurrentUser.UserID;
                _LDA.LicenseClassID = cbLicenceClass.SelectedIndex+1;
                _LDA.ApplicationStatus = clsApplicationBusiness.enApplicationStatus.New;
            if (clsApplicationBusiness.DoesPersonHaveActiveApplication(_LDA.ApplicationPersonID, _LDA.ApplicationTypeID, _LDA.LicenseClassID))
            {
                MessageBox.Show("Data Is not Saved Successfully You have an active Application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_LDA.Save())
                {
                    lblHeader.Text = "Update Local Driving";
                    lblDLApplicationID.Text = _LDA.LocalDrivingLicenseApplicationID.ToString();
                    _Mode = enMode.Update;
                    MessageBox.Show("Data Saved Successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Error: Data Is not Saved Successfully.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            

        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            if(_Mode == enMode.Update)
            {
                btnSave.Enabled = true ;
                tabLDAInfo.Enabled = true;
                tcLocalPersonInfo.SelectedTab = tcLocalPersonInfo.TabPages["tabLDAInfo"];
            }
            if (ctrlPersonCardWithFilter1.PersonID != -1)
            {

             
                    btnSave.Enabled = true;
                    tabLDAInfo.Enabled = true;
                    tcLocalPersonInfo.SelectedTab = tcLocalPersonInfo.TabPages["tabLDAInfo"];
                
            }
            else

            {
                MessageBox.Show("Please Select a Person", "Select a Person", MessageBoxButtons.OK, MessageBoxIcon.Error);
               

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmNewLocalDrivingApplication_Activated(object sender, EventArgs e)
        {
            ctrlPersonCardWithFilter1.FilterFoucs();
        }
    }
}
