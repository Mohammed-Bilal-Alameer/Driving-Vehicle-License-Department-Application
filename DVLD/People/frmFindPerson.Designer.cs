namespace DVLD.People
{
    partial class frmFindPerson
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ctrlPersonCard1 = new DVLD.Controls.ctrlPersonCard();
            this.btnCloseFindPerson = new System.Windows.Forms.Button();
            this.txtFindPerson = new System.Windows.Forms.TextBox();
            this.cbFillter = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ctrlPersonCard1);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 119);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(823, 375);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Person Information";
            // 
            // ctrlPersonCard1
            // 
            this.ctrlPersonCard1.Font = new System.Drawing.Font("Tahoma", 10F);
            this.ctrlPersonCard1.Location = new System.Drawing.Point(7, 23);
            this.ctrlPersonCard1.Margin = new System.Windows.Forms.Padding(4);
            this.ctrlPersonCard1.Name = "ctrlPersonCard1";
            this.ctrlPersonCard1.Size = new System.Drawing.Size(754, 343);
            this.ctrlPersonCard1.TabIndex = 0;
            // 
            // btnCloseFindPerson
            // 
            this.btnCloseFindPerson.Location = new System.Drawing.Point(575, 500);
            this.btnCloseFindPerson.Name = "btnCloseFindPerson";
            this.btnCloseFindPerson.Size = new System.Drawing.Size(106, 38);
            this.btnCloseFindPerson.TabIndex = 55;
            this.btnCloseFindPerson.Text = "Close";
            this.btnCloseFindPerson.UseVisualStyleBackColor = true;
            this.btnCloseFindPerson.Click += new System.EventHandler(this.btnCloseFindPerson_Click);
            // 
            // txtFindPerson
            // 
            this.txtFindPerson.Location = new System.Drawing.Point(254, 93);
            this.txtFindPerson.Name = "txtFindPerson";
            this.txtFindPerson.Size = new System.Drawing.Size(157, 20);
            this.txtFindPerson.TabIndex = 58;
            // 
            // cbFillter
            // 
            this.cbFillter.FormattingEnabled = true;
            this.cbFillter.Items.AddRange(new object[] {
            "National Number",
            "Person ID"});
            this.cbFillter.Location = new System.Drawing.Point(97, 92);
            this.cbFillter.Name = "cbFillter";
            this.cbFillter.Size = new System.Drawing.Size(141, 21);
            this.cbFillter.TabIndex = 57;
            this.cbFillter.SelectedIndexChanged += new System.EventHandler(this.cbFillter_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(20, 92);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 16);
            this.label10.TabIndex = 56;
            this.label10.Text = "Find  By: ";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(437, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(52, 38);
            this.button1.TabIndex = 59;
            this.button1.Text = "Find";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(629, 81);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(52, 38);
            this.button2.TabIndex = 60;
            this.button2.Text = "Add";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmFindPerson
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 540);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtFindPerson);
            this.Controls.Add(this.cbFillter);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCloseFindPerson);
            this.Name = "frmFindPerson";
            this.Text = "frmFindPerson";
            this.Load += new System.EventHandler(this.frmFindPerson_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCloseFindPerson;
        private System.Windows.Forms.TextBox txtFindPerson;
        private System.Windows.Forms.ComboBox cbFillter;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private Controls.ctrlPersonCard ctrlPersonCard1;
    }
}