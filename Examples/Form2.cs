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
    public partial class Form2 : Form
    {

        public delegate void DataBackEventHandler(object sender, int PersonID,string Read);

        public event DataBackEventHandler SendDataBack;


        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int PersonID=int.Parse(textBox1.Text);
            string Read = "Hello I'm The Deleget Func After Form2 Close and The PersonID is ";
            SendDataBack?.Invoke(this, PersonID, Read);
            this.Close();

        }
    }
}
