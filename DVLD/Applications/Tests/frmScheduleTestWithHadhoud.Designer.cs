namespace DVLD.Applications.Tests
{
    partial class frmScheduleTestWithHadhoud
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
            this.ctrlScheduleTestWithHadhoud1 = new DVLD.Applications.Tests.Controls.ctrlScheduleTestWithHadhoud();
            this.SuspendLayout();
            // 
            // ctrlScheduleTestWithHadhoud1
            // 
            this.ctrlScheduleTestWithHadhoud1.Location = new System.Drawing.Point(3, 2);
            this.ctrlScheduleTestWithHadhoud1.Name = "ctrlScheduleTestWithHadhoud1";
            this.ctrlScheduleTestWithHadhoud1.Size = new System.Drawing.Size(487, 569);
            this.ctrlScheduleTestWithHadhoud1.TabIndex = 0;
            this.ctrlScheduleTestWithHadhoud1.TestTypeID = DVLD_Business.clsTestType.enTestType.VisionTest;
            // 
            // frmScheduleTestWithHadhoud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 565);
            this.Controls.Add(this.ctrlScheduleTestWithHadhoud1);
            this.Name = "frmScheduleTestWithHadhoud";
            this.Text = "frmScheduleTestWithHadhoud";
            this.Load += new System.EventHandler(this.frmScheduleTestWithHadhoud_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.ctrlScheduleTestWithHadhoud ctrlScheduleTestWithHadhoud1;
    }
}