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
    public partial class ctrlCalculater : UserControl
    {
        public ctrlCalculater()
        {
            InitializeComponent();
        }



        public class ClsCalculat : EventArgs
        {
            public int Val1 { get; }
            public int Val2 { get; }
            public int Resulte { get; }


            public ClsCalculat(int Val1,int Val2,int Resulte)
            {
                this.Val1 = Val1;
                this.Val2 = Val2;
                this.Resulte = Resulte;
            }
        }

        public event EventHandler<ClsCalculat> OnCalulate;

        protected virtual void RaiseOnCalulationComplete(ClsCalculat e)
        {
            OnCalulate?.Invoke(this, e);
        }


        public void RaiseOnCalulationComplete(int Val1,int Val2,int Resulte)
        {
            RaiseOnCalulationComplete(new ClsCalculat(Val1, Val2, Resulte));
        }

        private void btnCalc_Click(object sender, EventArgs e)
        {
            int Val1, Val2;
            Val1 = Convert.ToInt32(textBox1.Text);
            Val2 = Convert.ToInt32(textBox2.Text);

            int Result = Val1 + Val2;
            lblResulte.Text = Result.ToString();

            if (OnCalulate != null)
                // Raise the event with a parameter
                RaiseOnCalulationComplete( Val1, Val2, Result);

        }
    }
}
