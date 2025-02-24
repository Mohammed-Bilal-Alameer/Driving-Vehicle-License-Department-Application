namespace DVLD.Applications.Detain_License
{
    partial class frmDetainReleaseLicense
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
            this.ctrlDrivingLicenseWithFilter1 = new DVLD.Licenses.Controls.ctrlDrivingLicenseWithFilter();
            this.gbDetainRelease = new System.Windows.Forms.GroupBox();
            this.lblApplicationID = new System.Windows.Forms.Label();
            this.lblTitleApplicationID = new System.Windows.Forms.Label();
            this.lblTotalFees = new System.Windows.Forms.Label();
            this.lblTitleTotalFees = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.lblTitleApplicationFees = new System.Windows.Forms.Label();
            this.lblFineFees = new System.Windows.Forms.Label();
            this.lblLicenseID = new System.Windows.Forms.Label();
            this.txtFineFees = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.lblCreatedByUserID = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblDetainID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDetainDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.LlblShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.LlblShowLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnIssue = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.gbDetainRelease.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlDrivingLicenseWithFilter1
            // 
            this.ctrlDrivingLicenseWithFilter1.FilterEnable = true;
            this.ctrlDrivingLicenseWithFilter1.Location = new System.Drawing.Point(11, 49);
            this.ctrlDrivingLicenseWithFilter1.Name = "ctrlDrivingLicenseWithFilter1";
            this.ctrlDrivingLicenseWithFilter1.Size = new System.Drawing.Size(646, 437);
            this.ctrlDrivingLicenseWithFilter1.TabIndex = 0;
            this.ctrlDrivingLicenseWithFilter1.OnLicenseSelected += new System.Action<int>(this.ctrlDrivingLicenseWithFilter1_OnLicenseSelected);
            // 
            // gbDetainRelease
            // 
            this.gbDetainRelease.Controls.Add(this.lblApplicationID);
            this.gbDetainRelease.Controls.Add(this.lblTitleApplicationID);
            this.gbDetainRelease.Controls.Add(this.lblTotalFees);
            this.gbDetainRelease.Controls.Add(this.lblTitleTotalFees);
            this.gbDetainRelease.Controls.Add(this.lblApplicationFees);
            this.gbDetainRelease.Controls.Add(this.lblTitleApplicationFees);
            this.gbDetainRelease.Controls.Add(this.lblFineFees);
            this.gbDetainRelease.Controls.Add(this.lblLicenseID);
            this.gbDetainRelease.Controls.Add(this.txtFineFees);
            this.gbDetainRelease.Controls.Add(this.label12);
            this.gbDetainRelease.Controls.Add(this.lblCreatedByUserID);
            this.gbDetainRelease.Controls.Add(this.label16);
            this.gbDetainRelease.Controls.Add(this.lblDetainID);
            this.gbDetainRelease.Controls.Add(this.label5);
            this.gbDetainRelease.Controls.Add(this.lblDetainDate);
            this.gbDetainRelease.Controls.Add(this.label3);
            this.gbDetainRelease.Controls.Add(this.label1);
            this.gbDetainRelease.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDetainRelease.Location = new System.Drawing.Point(11, 465);
            this.gbDetainRelease.Name = "gbDetainRelease";
            this.gbDetainRelease.Size = new System.Drawing.Size(652, 184);
            this.gbDetainRelease.TabIndex = 2;
            this.gbDetainRelease.TabStop = false;
            this.gbDetainRelease.Text = "Detain Info:";
            // 
            // lblApplicationID
            // 
            this.lblApplicationID.AutoSize = true;
            this.lblApplicationID.Location = new System.Drawing.Point(455, 157);
            this.lblApplicationID.Name = "lblApplicationID";
            this.lblApplicationID.Size = new System.Drawing.Size(38, 14);
            this.lblApplicationID.TabIndex = 21;
            this.lblApplicationID.Text = "[???]";
            this.lblApplicationID.Visible = false;
            // 
            // lblTitleApplicationID
            // 
            this.lblTitleApplicationID.AutoSize = true;
            this.lblTitleApplicationID.Location = new System.Drawing.Point(339, 157);
            this.lblTitleApplicationID.Name = "lblTitleApplicationID";
            this.lblTitleApplicationID.Size = new System.Drawing.Size(98, 14);
            this.lblTitleApplicationID.TabIndex = 20;
            this.lblTitleApplicationID.Text = "Application ID:";
            this.lblTitleApplicationID.Visible = false;
            // 
            // lblTotalFees
            // 
            this.lblTotalFees.AutoSize = true;
            this.lblTotalFees.Location = new System.Drawing.Point(135, 157);
            this.lblTotalFees.Name = "lblTotalFees";
            this.lblTotalFees.Size = new System.Drawing.Size(38, 14);
            this.lblTotalFees.TabIndex = 19;
            this.lblTotalFees.Text = "[???]";
            this.lblTotalFees.Visible = false;
            // 
            // lblTitleTotalFees
            // 
            this.lblTitleTotalFees.AutoSize = true;
            this.lblTitleTotalFees.Location = new System.Drawing.Point(9, 157);
            this.lblTitleTotalFees.Name = "lblTitleTotalFees";
            this.lblTitleTotalFees.Size = new System.Drawing.Size(72, 14);
            this.lblTitleTotalFees.TabIndex = 18;
            this.lblTitleTotalFees.Text = "Total Fees:";
            this.lblTitleTotalFees.Visible = false;
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Location = new System.Drawing.Point(455, 116);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(38, 14);
            this.lblApplicationFees.TabIndex = 17;
            this.lblApplicationFees.Text = "[???]";
            this.lblApplicationFees.Visible = false;
            // 
            // lblTitleApplicationFees
            // 
            this.lblTitleApplicationFees.AutoSize = true;
            this.lblTitleApplicationFees.Location = new System.Drawing.Point(339, 116);
            this.lblTitleApplicationFees.Name = "lblTitleApplicationFees";
            this.lblTitleApplicationFees.Size = new System.Drawing.Size(110, 14);
            this.lblTitleApplicationFees.TabIndex = 16;
            this.lblTitleApplicationFees.Text = "Application Fees:";
            this.lblTitleApplicationFees.Visible = false;
            // 
            // lblFineFees
            // 
            this.lblFineFees.AutoSize = true;
            this.lblFineFees.Location = new System.Drawing.Point(135, 111);
            this.lblFineFees.Name = "lblFineFees";
            this.lblFineFees.Size = new System.Drawing.Size(38, 14);
            this.lblFineFees.TabIndex = 15;
            this.lblFineFees.Text = "[???]";
            this.lblFineFees.Visible = false;
            // 
            // lblLicenseID
            // 
            this.lblLicenseID.AutoSize = true;
            this.lblLicenseID.Location = new System.Drawing.Point(457, 33);
            this.lblLicenseID.Name = "lblLicenseID";
            this.lblLicenseID.Size = new System.Drawing.Size(38, 14);
            this.lblLicenseID.TabIndex = 14;
            this.lblLicenseID.Text = "[???]";
            // 
            // txtFineFees
            // 
            this.txtFineFees.Location = new System.Drawing.Point(110, 108);
            this.txtFineFees.Name = "txtFineFees";
            this.txtFineFees.Size = new System.Drawing.Size(100, 22);
            this.txtFineFees.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(339, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 14);
            this.label12.TabIndex = 12;
            this.label12.Text = "Created By:";
            // 
            // lblCreatedByUserID
            // 
            this.lblCreatedByUserID.AutoSize = true;
            this.lblCreatedByUserID.Location = new System.Drawing.Point(457, 73);
            this.lblCreatedByUserID.Name = "lblCreatedByUserID";
            this.lblCreatedByUserID.Size = new System.Drawing.Size(38, 14);
            this.lblCreatedByUserID.TabIndex = 11;
            this.lblCreatedByUserID.Text = "[???]";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(339, 33);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(73, 14);
            this.label16.TabIndex = 8;
            this.label16.Text = "License ID:";
            // 
            // lblDetainID
            // 
            this.lblDetainID.AutoSize = true;
            this.lblDetainID.Location = new System.Drawing.Point(135, 33);
            this.lblDetainID.Name = "lblDetainID";
            this.lblDetainID.Size = new System.Drawing.Size(38, 14);
            this.lblDetainID.TabIndex = 5;
            this.lblDetainID.Text = "[???]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "Detain Date:";
            // 
            // lblDetainDate
            // 
            this.lblDetainDate.AutoSize = true;
            this.lblDetainDate.Location = new System.Drawing.Point(135, 73);
            this.lblDetainDate.Name = "lblDetainDate";
            this.lblDetainDate.Size = new System.Drawing.Size(38, 14);
            this.lblDetainDate.TabIndex = 3;
            this.lblDetainDate.Text = "[???]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Fine Fees:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "Detain ID:";
            // 
            // LlblShowLicenseInfo
            // 
            this.LlblShowLicenseInfo.AutoSize = true;
            this.LlblShowLicenseInfo.Enabled = false;
            this.LlblShowLicenseInfo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LlblShowLicenseInfo.Location = new System.Drawing.Point(206, 665);
            this.LlblShowLicenseInfo.Name = "LlblShowLicenseInfo";
            this.LlblShowLicenseInfo.Size = new System.Drawing.Size(108, 14);
            this.LlblShowLicenseInfo.TabIndex = 9;
            this.LlblShowLicenseInfo.TabStop = true;
            this.LlblShowLicenseInfo.Text = "Show License Info";
            this.LlblShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LlblShowLicenseInfo_LinkClicked);
            // 
            // LlblShowLicensesHistory
            // 
            this.LlblShowLicensesHistory.AutoSize = true;
            this.LlblShowLicensesHistory.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LlblShowLicensesHistory.Location = new System.Drawing.Point(41, 666);
            this.LlblShowLicensesHistory.Name = "LlblShowLicensesHistory";
            this.LlblShowLicensesHistory.Size = new System.Drawing.Size(128, 14);
            this.LlblShowLicensesHistory.TabIndex = 8;
            this.LlblShowLicensesHistory.TabStop = true;
            this.LlblShowLicensesHistory.Text = "Show Licenses History";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(474, 655);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 35);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnIssue
            // 
            this.btnIssue.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIssue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnIssue.Location = new System.Drawing.Point(571, 655);
            this.btnIssue.Name = "btnIssue";
            this.btnIssue.Size = new System.Drawing.Size(92, 35);
            this.btnIssue.TabIndex = 6;
            this.btnIssue.Text = "Detain";
            this.btnIssue.UseVisualStyleBackColor = true;
            this.btnIssue.Click += new System.EventHandler(this.btnIssue_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(242, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(149, 23);
            this.lblTitle.TabIndex = 10;
            this.lblTitle.Text = "Detain License";
            // 
            // frmDetainReleaseLicense
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(675, 688);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.LlblShowLicenseInfo);
            this.Controls.Add(this.LlblShowLicensesHistory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnIssue);
            this.Controls.Add(this.gbDetainRelease);
            this.Controls.Add(this.ctrlDrivingLicenseWithFilter1);
            this.Name = "frmDetainReleaseLicense";
            this.Text = "frmDetainLicense";
            this.Load += new System.EventHandler(this.frmDetainReleaseLicense_Load);
            this.gbDetainRelease.ResumeLayout(false);
            this.gbDetainRelease.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Licenses.Controls.ctrlDrivingLicenseWithFilter ctrlDrivingLicenseWithFilter1;
        private System.Windows.Forms.GroupBox gbDetainRelease;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblCreatedByUserID;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblDetainID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblDetainDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel LlblShowLicenseInfo;
        private System.Windows.Forms.LinkLabel LlblShowLicensesHistory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnIssue;
        private System.Windows.Forms.Label lblLicenseID;
        private System.Windows.Forms.TextBox txtFineFees;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblTotalFees;
        private System.Windows.Forms.Label lblTitleTotalFees;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label lblTitleApplicationFees;
        private System.Windows.Forms.Label lblFineFees;
        private System.Windows.Forms.Label lblApplicationID;
        private System.Windows.Forms.Label lblTitleApplicationID;
    }
}