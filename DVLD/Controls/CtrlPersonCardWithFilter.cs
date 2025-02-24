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

namespace DVLD.Controls
{
    public partial class CtrlPersonCardWithFilter : UserControl
    {

        public event Action<int> OnPersonSelected;
        protected virtual void PersonSelected (int PersonID)
        {
            Action<int> handler = OnPersonSelected;
            if(handler != null)
            {
                handler (PersonID);
            }
        }


        private bool _ShowAddPerson = true;
        public bool ShowAddPerson
        {
            get { return _ShowAddPerson; }
            set { _ShowAddPerson = value;
                btnAdd.Visible=_ShowAddPerson;
                                        }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilter.Enabled = _FilterEnabled;
            }
        }

        public CtrlPersonCardWithFilter()
        {
            InitializeComponent();
        }

        public int PersonID
        {
            get { return ctrlPersonCard1.PersonID; }
        }
        public clsPerson SelectedPersonInfo
        {
            get {return ctrlPersonCard1.SelectedPersonInfo; }
        }

        public void FilterFoucs()
        {
            txtFindPerson.Focus();
        }
        public void LoadPersonInfo(int PersonID)
        {
            cbFillter.SelectedIndex = 1;
            txtFindPerson.Text = PersonID.ToString();
            FindNow();
        }
        private void FindNow()
        {
            switch (cbFillter.Text)
            {
                case "National Number":
                    {

                        ctrlPersonCard1.LoadPersonInfo(txtFindPerson.Text);

                        break;
                    }
                case "Person ID":
                    {
                        ctrlPersonCard1.LoadPersonInfo(int.Parse(txtFindPerson.Text));


                        break;
                    }
                    default:
                    {
                        break;
                    }





            }
            if (OnPersonSelected != null && FilterEnabled)
                // Raise the event with a parameter
                OnPersonSelected(ctrlPersonCard1.PersonID);


        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            FindNow();
        }

        private void CtrlPersonCardWithFilter_Load(object sender, EventArgs e)
        {
            cbFillter.SelectedIndex = 0;
            cbFillter.Focus();
        }

        private void DataBackEvent(object sender, int PersonID)
        {
            // Handle the data received
            
            cbFillter.SelectedIndex = 1;
            txtFindPerson.Text = PersonID.ToString();
            ctrlPersonCard1.LoadPersonInfo(PersonID);
        }

        private void cbFillter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm=new frmAddEditPerson(-1);
            frm.DataBack += DataBackEvent;
            frm.ShowDialog();
        }
    }
}
