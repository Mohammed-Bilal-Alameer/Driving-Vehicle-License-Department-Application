namespace DVLD.Applications.Local_Driving_Application
{
    partial class frmNewLocalDrivingApplication
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
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tcLocalPersonInfo = new System.Windows.Forms.TabControl();
            this.tabPersonInfo = new System.Windows.Forms.TabPage();
            this.btnNext = new System.Windows.Forms.Button();
            this.ctrlPersonCardWithFilter1 = new DVLD.Controls.CtrlPersonCardWithFilter();
            this.tabLDAInfo = new System.Windows.Forms.TabPage();
            this.cbLicenceClass = new System.Windows.Forms.ComboBox();
            this.lblCreatedByUserName = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lblAppDate = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblAppFees = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDLApplicationID = new System.Windows.Forms.Label();
            this.lable2 = new System.Windows.Forms.Label();
            this.tcLocalPersonInfo.SuspendLayout();
            this.tabPersonInfo.SuspendLayout();
            this.tabLDAInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblHeader
            // 
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.Color.Maroon;
            this.lblHeader.Location = new System.Drawing.Point(244, 31);
            this.lblHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(419, 33);
            this.lblHeader.TabIndex = 0;
            this.lblHeader.Text = "New Local Driving Application";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(587, 620);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(124, 43);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(731, 620);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(124, 43);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tcLocalPersonInfo
            // 
            this.tcLocalPersonInfo.Controls.Add(this.tabPersonInfo);
            this.tcLocalPersonInfo.Controls.Add(this.tabLDAInfo);
            this.tcLocalPersonInfo.Location = new System.Drawing.Point(4, 65);
            this.tcLocalPersonInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tcLocalPersonInfo.Name = "tcLocalPersonInfo";
            this.tcLocalPersonInfo.SelectedIndex = 0;
            this.tcLocalPersonInfo.Size = new System.Drawing.Size(913, 553);
            this.tcLocalPersonInfo.TabIndex = 5;
            // 
            // tabPersonInfo
            // 
            this.tabPersonInfo.Controls.Add(this.btnNext);
            this.tabPersonInfo.Controls.Add(this.ctrlPersonCardWithFilter1);
            this.tabPersonInfo.Location = new System.Drawing.Point(4, 25);
            this.tabPersonInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPersonInfo.Name = "tabPersonInfo";
            this.tabPersonInfo.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPersonInfo.Size = new System.Drawing.Size(905, 524);
            this.tabPersonInfo.TabIndex = 0;
            this.tabPersonInfo.Text = "Person Info";
            this.tabPersonInfo.UseVisualStyleBackColor = true;
            // 
            // btnNext
            // 
            this.btnNext.Location = new System.Drawing.Point(721, 463);
            this.btnNext.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(124, 43);
            this.btnNext.TabIndex = 4;
            this.btnNext.Text = "Next";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // ctrlPersonCardWithFilter1
            // 
            this.ctrlPersonCardWithFilter1.FilterEnabled = true;
            this.ctrlPersonCardWithFilter1.Location = new System.Drawing.Point(0, 9);
            this.ctrlPersonCardWithFilter1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.ctrlPersonCardWithFilter1.Name = "ctrlPersonCardWithFilter1";
            this.ctrlPersonCardWithFilter1.ShowAddPerson = true;
            this.ctrlPersonCardWithFilter1.Size = new System.Drawing.Size(1063, 613);
            this.ctrlPersonCardWithFilter1.TabIndex = 3;
            // 
            // tabLDAInfo
            // 
            this.tabLDAInfo.Controls.Add(this.cbLicenceClass);
            this.tabLDAInfo.Controls.Add(this.lblCreatedByUserName);
            this.tabLDAInfo.Controls.Add(this.label10);
            this.tabLDAInfo.Controls.Add(this.lblAppDate);
            this.tabLDAInfo.Controls.Add(this.label8);
            this.tabLDAInfo.Controls.Add(this.label7);
            this.tabLDAInfo.Controls.Add(this.lblAppFees);
            this.tabLDAInfo.Controls.Add(this.label5);
            this.tabLDAInfo.Controls.Add(this.lblDLApplicationID);
            this.tabLDAInfo.Controls.Add(this.lable2);
            this.tabLDAInfo.Location = new System.Drawing.Point(4, 25);
            this.tabLDAInfo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabLDAInfo.Name = "tabLDAInfo";
            this.tabLDAInfo.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabLDAInfo.Size = new System.Drawing.Size(905, 524);
            this.tabLDAInfo.TabIndex = 1;
            this.tabLDAInfo.Text = "Application Info";
            this.tabLDAInfo.UseVisualStyleBackColor = true;
            // 
            // cbLicenceClass
            // 
            this.cbLicenceClass.FormattingEnabled = true;
            this.cbLicenceClass.Location = new System.Drawing.Point(287, 191);
            this.cbLicenceClass.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbLicenceClass.Name = "cbLicenceClass";
            this.cbLicenceClass.Size = new System.Drawing.Size(345, 24);
            this.cbLicenceClass.TabIndex = 10;
            this.cbLicenceClass.SelectedIndexChanged += new System.EventHandler(this.cbLicenceClass_SelectedIndexChanged);
            // 
            // lblCreatedByUserName
            // 
            this.lblCreatedByUserName.AutoSize = true;
            this.lblCreatedByUserName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCreatedByUserName.Location = new System.Drawing.Point(283, 331);
            this.lblCreatedByUserName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCreatedByUserName.Name = "lblCreatedByUserName";
            this.lblCreatedByUserName.Size = new System.Drawing.Size(56, 21);
            this.lblCreatedByUserName.TabIndex = 9;
            this.lblCreatedByUserName.Text = "[???]";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(53, 135);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(152, 21);
            this.label10.TabIndex = 8;
            this.label10.Text = "Application Date";
            // 
            // lblAppDate
            // 
            this.lblAppDate.AutoSize = true;
            this.lblAppDate.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppDate.Location = new System.Drawing.Point(283, 135);
            this.lblAppDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAppDate.Name = "lblAppDate";
            this.lblAppDate.Size = new System.Drawing.Size(56, 21);
            this.lblAppDate.TabIndex = 7;
            this.lblAppDate.Text = "[???]";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(53, 192);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(123, 21);
            this.label8.TabIndex = 6;
            this.label8.Text = "Licence Class";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(53, 266);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(151, 21);
            this.label7.TabIndex = 5;
            this.label7.Text = "Application Fees";
            // 
            // lblAppFees
            // 
            this.lblAppFees.AutoSize = true;
            this.lblAppFees.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppFees.Location = new System.Drawing.Point(283, 266);
            this.lblAppFees.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAppFees.Name = "lblAppFees";
            this.lblAppFees.Size = new System.Drawing.Size(56, 21);
            this.lblAppFees.TabIndex = 4;
            this.lblAppFees.Text = "[???]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(53, 331);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 21);
            this.label5.TabIndex = 3;
            this.label5.Text = "Created By:";
            // 
            // lblDLApplicationID
            // 
            this.lblDLApplicationID.AutoSize = true;
            this.lblDLApplicationID.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDLApplicationID.Location = new System.Drawing.Point(283, 68);
            this.lblDLApplicationID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDLApplicationID.Name = "lblDLApplicationID";
            this.lblDLApplicationID.Size = new System.Drawing.Size(56, 21);
            this.lblDLApplicationID.TabIndex = 1;
            this.lblDLApplicationID.Text = "[???]";
            // 
            // lable2
            // 
            this.lable2.AutoSize = true;
            this.lable2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lable2.Location = new System.Drawing.Point(53, 68);
            this.lable2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lable2.Name = "lable2";
            this.lable2.Size = new System.Drawing.Size(166, 21);
            this.lable2.TabIndex = 0;
            this.lable2.Text = "D.L Application ID";
            // 
            // frmNewLocalDrivingApplication
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 670);
            this.Controls.Add(this.tcLocalPersonInfo);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblHeader);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmNewLocalDrivingApplication";
            this.Text = "frmLocalDrivingApplication";
            this.Activated += new System.EventHandler(this.frmNewLocalDrivingApplication_Activated);
            this.Load += new System.EventHandler(this.frmNewLocalDrivingApplication_Load);
            this.tcLocalPersonInfo.ResumeLayout(false);
            this.tabPersonInfo.ResumeLayout(false);
            this.tabLDAInfo.ResumeLayout(false);
            this.tabLDAInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TabControl tcLocalPersonInfo;
        private System.Windows.Forms.TabPage tabPersonInfo;
        private System.Windows.Forms.Button btnNext;
        private Controls.CtrlPersonCardWithFilter ctrlPersonCardWithFilter1;
        private System.Windows.Forms.TabPage tabLDAInfo;
        private System.Windows.Forms.Label lblCreatedByUserName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lblAppDate;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblAppFees;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDLApplicationID;
        private System.Windows.Forms.Label lable2;
        private System.Windows.Forms.ComboBox cbLicenceClass;
    }
}