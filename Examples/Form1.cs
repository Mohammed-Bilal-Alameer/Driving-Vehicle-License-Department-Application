using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examples
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm=new Form2();
            //ماتحط قوسين للفانكشن المنادى
            frm.SendDataBack += Form2_SendDataBack;
            frm.ShowDialog();
        }



        private void Form2_SendDataBack(object sender , int PersonID, string Read)
        {


            MessageBox.Show(Read + PersonID);
        }

        private void ctrlCalculater1_OnCalulate(object sender, ctrlCalculater.ClsCalculat e)
        {
            MessageBox.Show($"Results={e.Resulte} , val1 = {e.Val1}, vale2 = {e.Val2}");

        }
    }
}
