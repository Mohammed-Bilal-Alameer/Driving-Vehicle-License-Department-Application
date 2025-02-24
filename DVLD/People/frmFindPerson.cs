using DVLD.Controls;
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

namespace DVLD.People
{
    public partial class frmFindPerson : Form
    {
        public frmFindPerson()
        {
            InitializeComponent();
        }

        public delegate void DataBackEventHandler(object sender, int PersonID);
        public event DataBackEventHandler DataBack;
        int _PersonID = 0;

        private void frmFindPerson_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmAddEditPerson frm = new frmAddEditPerson(-1);
            frm.DataBack += _DataBackFrmAdd;
            frm.ShowDialog();
        }

        private void cbFillter_SelectedIndexChanged(object sender, EventArgs e)
        {
      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbFillter.SelectedIndex == 1)
            {
                ctrlPersonCard1.LoadPersonInfo(int.Parse(txtFindPerson.Text));
                _PersonID = int.Parse(txtFindPerson.Text);

            }

        }

        private void btnCloseFindPerson_Click(object sender, EventArgs e)
        {
            
            DataBack?.Invoke(this, _PersonID);
            this.Close();
        }

        private void _DataBackFrmAdd(object sender,int PersonID)
        {



            _PersonID = PersonID;
            ctrlPersonCard1.LoadPersonInfo(PersonID);
        }



    }
}
