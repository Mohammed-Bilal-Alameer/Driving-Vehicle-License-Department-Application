namespace DVLD.Applications.Replacement_for_Damaged_or_Lost_Licenses
{
    partial class frmReplacementforDamagedorLostLicenses
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
            this.gbApplicationType = new System.Windows.Forms.GroupBox();
            this.rdLostLicense = new System.Windows.Forms.RadioButton();
            this.rdDamagedLicense = new System.Windows.Forms.RadioButton();
            this.LlblShowLicensesHistory = new System.Windows.Forms.LinkLabel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReplacement = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblReplacementLicenseID = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblLocalLicenseID = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblCreatedByUserID = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblApplicationID = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblApplicationDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblApplicationFees = new System.Windows.Forms.Label();
            this.lable = new System.Windows.Forms.Label();
            this.lnkShowLicenseInfo = new System.Windows.Forms.LinkLabel();
            this.gbApplicationType.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ctrlDrivingLicenseWithFilter1
            // 
            this.ctrlDrivingLicenseWithFilter1.FilterEnable = true;
            this.ctrlDrivingLicenseWithFilter1.Location = new System.Drawing.Point(12, 12);
            this.ctrlDrivingLicenseWithFilter1.Name = "ctrlDrivingLicenseWithFilter1";
            this.ctrlDrivingLicenseWithFilter1.Size = new System.Drawing.Size(662, 437);
            this.ctrlDrivingLicenseWithFilter1.TabIndex = 0;
            this.ctrlDrivingLicenseWithFilter1.OnLicenseSelected += new System.Action<int>(this.ctrlDrivingLicenseWithFilter1_OnLicenseSelected);
            // 
            // gbApplicationType
            // 
            this.gbApplicationType.Controls.Add(this.rdLostLicense);
            this.gbApplicationType.Controls.Add(this.rdDamagedLicense);
            this.gbApplicationType.Location = new System.Drawing.Point(498, 21);
            this.gbApplicationType.Name = "gbApplicationType";
            this.gbApplicationType.Size = new System.Drawing.Size(176, 95);
            this.gbApplicationType.TabIndex = 1;
            this.gbApplicationType.TabStop = false;
            this.gbApplicationType.Text = "Replacement For:";
            // 
            // rdLostLicense
            // 
            this.rdLostLicense.AutoSize = true;
            this.rdLostLicense.Location = new System.Drawing.Point(22, 54);
            this.rdLostLicense.Name = "rdLostLicense";
            this.rdLostLicense.Size = new System.Drawing.Size(83, 17);
            this.rdLostLicense.TabIndex = 1;
            this.rdLostLicense.TabStop = true;
            this.rdLostLicense.Text = "Lost License";
            this.rdLostLicense.UseVisualStyleBackColor = true;
            this.rdLostLicense.CheckedChanged += new System.EventHandler(this.rdLostLicense_CheckedChanged);
            // 
            // rdDamagedLicense
            // 
            this.rdDamagedLicense.AutoSize = true;
            this.rdDamagedLicense.Location = new System.Drawing.Point(22, 19);
            this.rdDamagedLicense.Name = "rdDamagedLicense";
            this.rdDamagedLicense.Size = new System.Drawing.Size(108, 17);
            this.rdDamagedLicense.TabIndex = 0;
            this.rdDamagedLicense.TabStop = true;
            this.rdDamagedLicense.Text = "Damaged License";
            this.rdDamagedLicense.UseVisualStyleBackColor = true;
            this.rdDamagedLicense.CheckedChanged += new System.EventHandler(this.rdDamagedLicense_CheckedChanged);
            // 
            // LlblShowLicensesHistory
            // 
            this.LlblShowLicensesHistory.AutoSize = true;
            this.LlblShowLicensesHistory.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LlblShowLicensesHistory.Location = new System.Drawing.Point(21, 592);
            this.LlblShowLicensesHistory.Name = "LlblShowLicensesHistory";
            this.LlblShowLicensesHistory.Size = new System.Drawing.Size(128, 14);
            this.LlblShowLicensesHistory.TabIndex = 14;
            this.LlblShowLicensesHistory.TabStop = true;
            this.LlblShowLicensesHistory.Text = "Show Licenses History";
            this.LlblShowLicensesHistory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LlblShowLicensesHistory_LinkClicked);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(388, 580);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(92, 35);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReplacement
            // 
            this.btnReplacement.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReplacement.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.btnReplacement.Location = new System.Drawing.Point(486, 580);
            this.btnReplacement.Name = "btnReplacement";
            this.btnReplacement.Size = new System.Drawing.Size(163, 35);
            this.btnReplacement.TabIndex = 12;
            this.btnReplacement.Text = "Issue Replacement";
            this.btnReplacement.UseVisualStyleBackColor = true;
            this.btnReplacement.Click += new System.EventHandler(this.btnReplacement_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblReplacementLicenseID);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.lblLocalLicenseID);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.lblCreatedByUserID);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.lblApplicationID);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.lblApplicationDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblApplicationFees);
            this.groupBox1.Controls.Add(this.lable);
            this.groupBox1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 436);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(652, 138);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Application Info For Replacement License:";
            // 
            // lblReplacementLicenseID
            // 
            this.lblReplacementLicenseID.AutoSize = true;
            this.lblReplacementLicenseID.Location = new System.Drawing.Point(495, 33);
            this.lblReplacementLicenseID.Name = "lblReplacementLicenseID";
            this.lblReplacementLicenseID.Size = new System.Drawing.Size(38, 14);
            this.lblReplacementLicenseID.TabIndex = 13;
            this.lblReplacementLicenseID.Text = "[???]";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(336, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(132, 14);
            this.label12.TabIndex = 12;
            this.label12.Text = "Old Local License ID:";
            // 
            // lblLocalLicenseID
            // 
            this.lblLocalLicenseID.AutoSize = true;
            this.lblLocalLicenseID.Location = new System.Drawing.Point(495, 73);
            this.lblLocalLicenseID.Name = "lblLocalLicenseID";
            this.lblLocalLicenseID.Size = new System.Drawing.Size(38, 14);
            this.lblLocalLicenseID.TabIndex = 11;
            this.lblLocalLicenseID.Text = "[???]";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(336, 111);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(78, 14);
            this.label14.TabIndex = 10;
            this.label14.Text = "Created By:";
            // 
            // lblCreatedByUserID
            // 
            this.lblCreatedByUserID.AutoSize = true;
            this.lblCreatedByUserID.Location = new System.Drawing.Point(495, 111);
            this.lblCreatedByUserID.Name = "lblCreatedByUserID";
            this.lblCreatedByUserID.Size = new System.Drawing.Size(38, 14);
            this.lblCreatedByUserID.TabIndex = 9;
            this.lblCreatedByUserID.Text = "[???]";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(336, 33);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(132, 14);
            this.label16.TabIndex = 8;
            this.label16.Text = "Replaced License ID:";
            // 
            // lblApplicationID
            // 
            this.lblApplicationID.AutoSize = true;
            this.lblApplicationID.Location = new System.Drawing.Point(135, 33);
            this.lblApplicationID.Name = "lblApplicationID";
            this.lblApplicationID.Size = new System.Drawing.Size(38, 14);
            this.lblApplicationID.TabIndex = 5;
            this.lblApplicationID.Text = "[???]";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 14);
            this.label5.TabIndex = 4;
            this.label5.Text = "Application Date:";
            // 
            // lblApplicationDate
            // 
            this.lblApplicationDate.AutoSize = true;
            this.lblApplicationDate.Location = new System.Drawing.Point(135, 73);
            this.lblApplicationDate.Name = "lblApplicationDate";
            this.lblApplicationDate.Size = new System.Drawing.Size(38, 14);
            this.lblApplicationDate.TabIndex = 3;
            this.lblApplicationDate.Text = "[???]";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 111);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 14);
            this.label3.TabIndex = 2;
            this.label3.Text = "Application Fees:";
            // 
            // lblApplicationFees
            // 
            this.lblApplicationFees.AutoSize = true;
            this.lblApplicationFees.Location = new System.Drawing.Point(135, 111);
            this.lblApplicationFees.Name = "lblApplicationFees";
            this.lblApplicationFees.Size = new System.Drawing.Size(38, 14);
            this.lblApplicationFees.TabIndex = 1;
            this.lblApplicationFees.Text = "[???]";
            // 
            // lable
            // 
            this.lable.AutoSize = true;
            this.lable.Location = new System.Drawing.Point(9, 33);
            this.lable.Name = "lable";
            this.lable.Size = new System.Drawing.Size(118, 14);
            this.lable.TabIndex = 0;
            this.lable.Text = "L.R.ApplicationID:";
            // 
            // lnkShowLicenseInfo
            // 
            this.lnkShowLicenseInfo.AutoSize = true;
            this.lnkShowLicenseInfo.Enabled = false;
            this.lnkShowLicenseInfo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkShowLicenseInfo.Location = new System.Drawing.Point(202, 592);
            this.lnkShowLicenseInfo.Name = "lnkShowLicenseInfo";
            this.lnkShowLicenseInfo.Size = new System.Drawing.Size(108, 14);
            this.lnkShowLicenseInfo.TabIndex = 15;
            this.lnkShowLicenseInfo.TabStop = true;
            this.lnkShowLicenseInfo.Text = "Show License Info";
            this.lnkShowLicenseInfo.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // frmReplacementforDamagedorLostLicenses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 615);
            this.Controls.Add(this.lnkShowLicenseInfo);
            this.Controls.Add(this.LlblShowLicensesHistory);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReplacement);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbApplicationType);
            this.Controls.Add(this.ctrlDrivingLicenseWithFilter1);
            this.Name = "frmReplacementforDamagedorLostLicenses";
            this.Text = "frmReplacementforDamagedorLostLicenses";
            this.Load += new System.EventHandler(this.frmReplacementforDamagedorLostLicenses_Load);
            this.gbApplicationType.ResumeLayout(false);
            this.gbApplicationType.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Licenses.Controls.ctrlDrivingLicenseWithFilter ctrlDrivingLicenseWithFilter1;
        private System.Windows.Forms.GroupBox gbApplicationType;
        private System.Windows.Forms.RadioButton rdLostLicense;
        private System.Windows.Forms.RadioButton rdDamagedLicense;
        private System.Windows.Forms.LinkLabel LlblShowLicensesHistory;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReplacement;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblReplacementLicenseID;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblLocalLicenseID;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lblCreatedByUserID;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblApplicationID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblApplicationDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblApplicationFees;
        private System.Windows.Forms.Label lable;
        private System.Windows.Forms.LinkLabel lnkShowLicenseInfo;
    }
}