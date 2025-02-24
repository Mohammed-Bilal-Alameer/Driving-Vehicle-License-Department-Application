namespace DVLD.Applications.Local_Driving_Application
{
    partial class frmManageLocalApplications
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
            this.components = new System.ComponentModel.Container();
            this.dgvLocalApplications = new System.Windows.Forms.DataGridView();
            this.cmsLocalApplicationList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.showLocalDrivingApplicationDetailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.canceldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleVisionTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleWrittenTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scheduleStreetTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.issuDrivingLicenceFirstTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showPersonLicenseHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtFillter = new System.Windows.Forms.TextBox();
            this.cbFillter = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnAddLocalApplication = new System.Windows.Forms.Button();
            this.lblLocalApplicationsCount = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalApplications)).BeginInit();
            this.cmsLocalApplicationList.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLocalApplications
            // 
            this.dgvLocalApplications.AllowUserToAddRows = false;
            this.dgvLocalApplications.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            this.dgvLocalApplications.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLocalApplications.ContextMenuStrip = this.cmsLocalApplicationList;
            this.dgvLocalApplications.Location = new System.Drawing.Point(12, 173);
            this.dgvLocalApplications.Name = "dgvLocalApplications";
            this.dgvLocalApplications.ReadOnly = true;
            this.dgvLocalApplications.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLocalApplications.Size = new System.Drawing.Size(970, 224);
            this.dgvLocalApplications.TabIndex = 0;
            // 
            // cmsLocalApplicationList
            // 
            this.cmsLocalApplicationList.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmsLocalApplicationList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showLocalDrivingApplicationDetailToolStripMenuItem,
            this.editApplicationToolStripMenuItem,
            this.deleteApplicationToolStripMenuItem,
            this.canceldToolStripMenuItem,
            this.scheToolStripMenuItem,
            this.issuDrivingLicenceFirstTimeToolStripMenuItem,
            this.showLicenseToolStripMenuItem,
            this.showPersonLicenseHistoryToolStripMenuItem});
            this.cmsLocalApplicationList.Name = "cmsLocalApplicationList";
            this.cmsLocalApplicationList.Size = new System.Drawing.Size(306, 218);
            this.cmsLocalApplicationList.Opening += new System.ComponentModel.CancelEventHandler(this.cmsLocalApplicationList_Opening);
            // 
            // showLocalDrivingApplicationDetailToolStripMenuItem
            // 
            this.showLocalDrivingApplicationDetailToolStripMenuItem.Name = "showLocalDrivingApplicationDetailToolStripMenuItem";
            this.showLocalDrivingApplicationDetailToolStripMenuItem.Size = new System.Drawing.Size(305, 24);
            this.showLocalDrivingApplicationDetailToolStripMenuItem.Text = "Show Local Driving Application Detail";
            this.showLocalDrivingApplicationDetailToolStripMenuItem.Click += new System.EventHandler(this.showLocalDrivingApplicationDetailToolStripMenuItem_Click);
            // 
            // editApplicationToolStripMenuItem
            // 
            this.editApplicationToolStripMenuItem.Name = "editApplicationToolStripMenuItem";
            this.editApplicationToolStripMenuItem.Size = new System.Drawing.Size(305, 24);
            this.editApplicationToolStripMenuItem.Text = "Edit Application";
            this.editApplicationToolStripMenuItem.Click += new System.EventHandler(this.editApplicationToolStripMenuItem_Click);
            // 
            // deleteApplicationToolStripMenuItem
            // 
            this.deleteApplicationToolStripMenuItem.Name = "deleteApplicationToolStripMenuItem";
            this.deleteApplicationToolStripMenuItem.Size = new System.Drawing.Size(305, 24);
            this.deleteApplicationToolStripMenuItem.Text = "Delete Application";
            this.deleteApplicationToolStripMenuItem.Click += new System.EventHandler(this.deleteApplicationToolStripMenuItem_Click);
            // 
            // canceldToolStripMenuItem
            // 
            this.canceldToolStripMenuItem.Name = "canceldToolStripMenuItem";
            this.canceldToolStripMenuItem.Size = new System.Drawing.Size(305, 24);
            this.canceldToolStripMenuItem.Text = "Cancel Application";
            this.canceldToolStripMenuItem.Click += new System.EventHandler(this.canceldToolStripMenuItem_Click);
            // 
            // scheToolStripMenuItem
            // 
            this.scheToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scheduleVisionTestToolStripMenuItem,
            this.scheduleWrittenTestToolStripMenuItem,
            this.scheduleStreetTestToolStripMenuItem});
            this.scheToolStripMenuItem.Name = "scheToolStripMenuItem";
            this.scheToolStripMenuItem.Size = new System.Drawing.Size(305, 24);
            this.scheToolStripMenuItem.Text = "Schedule Tests";
            // 
            // scheduleVisionTestToolStripMenuItem
            // 
            this.scheduleVisionTestToolStripMenuItem.Name = "scheduleVisionTestToolStripMenuItem";
            this.scheduleVisionTestToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.scheduleVisionTestToolStripMenuItem.Text = "Schedule Vision Test";
            this.scheduleVisionTestToolStripMenuItem.Click += new System.EventHandler(this.scheduleVisionTestToolStripMenuItem_Click);
            // 
            // scheduleWrittenTestToolStripMenuItem
            // 
            this.scheduleWrittenTestToolStripMenuItem.Name = "scheduleWrittenTestToolStripMenuItem";
            this.scheduleWrittenTestToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.scheduleWrittenTestToolStripMenuItem.Text = "Schedule Written Test";
            this.scheduleWrittenTestToolStripMenuItem.Click += new System.EventHandler(this.scheduleWrittenTestToolStripMenuItem_Click);
            // 
            // scheduleStreetTestToolStripMenuItem
            // 
            this.scheduleStreetTestToolStripMenuItem.Name = "scheduleStreetTestToolStripMenuItem";
            this.scheduleStreetTestToolStripMenuItem.Size = new System.Drawing.Size(210, 24);
            this.scheduleStreetTestToolStripMenuItem.Text = "Schedule Street Test";
            this.scheduleStreetTestToolStripMenuItem.Click += new System.EventHandler(this.scheduleStreetTestToolStripMenuItem_Click);
            // 
            // issuDrivingLicenceFirstTimeToolStripMenuItem
            // 
            this.issuDrivingLicenceFirstTimeToolStripMenuItem.Enabled = false;
            this.issuDrivingLicenceFirstTimeToolStripMenuItem.Name = "issuDrivingLicenceFirstTimeToolStripMenuItem";
            this.issuDrivingLicenceFirstTimeToolStripMenuItem.Size = new System.Drawing.Size(305, 24);
            this.issuDrivingLicenceFirstTimeToolStripMenuItem.Text = "Issue Driving License(First Time)";
            this.issuDrivingLicenceFirstTimeToolStripMenuItem.Click += new System.EventHandler(this.issuDrivingLicenceFirstTimeToolStripMenuItem_Click);
            // 
            // showLicenseToolStripMenuItem
            // 
            this.showLicenseToolStripMenuItem.Name = "showLicenseToolStripMenuItem";
            this.showLicenseToolStripMenuItem.Size = new System.Drawing.Size(305, 24);
            this.showLicenseToolStripMenuItem.Text = "Show License";
            this.showLicenseToolStripMenuItem.Click += new System.EventHandler(this.showLicenseToolStripMenuItem_Click);
            // 
            // showPersonLicenseHistoryToolStripMenuItem
            // 
            this.showPersonLicenseHistoryToolStripMenuItem.Name = "showPersonLicenseHistoryToolStripMenuItem";
            this.showPersonLicenseHistoryToolStripMenuItem.Size = new System.Drawing.Size(305, 24);
            this.showPersonLicenseHistoryToolStripMenuItem.Text = "Show Person License History";
            this.showPersonLicenseHistoryToolStripMenuItem.Click += new System.EventHandler(this.showPersonLicenseHistoryToolStripMenuItem_Click);
            // 
            // txtFillter
            // 
            this.txtFillter.Location = new System.Drawing.Point(248, 147);
            this.txtFillter.Name = "txtFillter";
            this.txtFillter.Size = new System.Drawing.Size(157, 20);
            this.txtFillter.TabIndex = 15;
            this.txtFillter.TextChanged += new System.EventHandler(this.txtFillter_TextChanged);
            // 
            // cbFillter
            // 
            this.cbFillter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFillter.FormattingEnabled = true;
            this.cbFillter.Items.AddRange(new object[] {
            "None",
            "L.D.L.AppID",
            "NationalNo.",
            "FullName",
            "Status"});
            this.cbFillter.Location = new System.Drawing.Point(91, 146);
            this.cbFillter.Name = "cbFillter";
            this.cbFillter.Size = new System.Drawing.Size(141, 21);
            this.cbFillter.TabIndex = 14;
            this.cbFillter.SelectedIndexChanged += new System.EventHandler(this.cbFillter_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(14, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Fillter By: ";
            // 
            // btnAddLocalApplication
            // 
            this.btnAddLocalApplication.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnAddLocalApplication.Location = new System.Drawing.Point(914, 123);
            this.btnAddLocalApplication.Name = "btnAddLocalApplication";
            this.btnAddLocalApplication.Size = new System.Drawing.Size(68, 39);
            this.btnAddLocalApplication.TabIndex = 12;
            this.btnAddLocalApplication.Text = "Add";
            this.btnAddLocalApplication.UseVisualStyleBackColor = true;
            this.btnAddLocalApplication.Click += new System.EventHandler(this.btnAddLocalApplication_Click);
            // 
            // lblLocalApplicationsCount
            // 
            this.lblLocalApplicationsCount.AutoSize = true;
            this.lblLocalApplicationsCount.Font = new System.Drawing.Font("Tahoma", 12F);
            this.lblLocalApplicationsCount.Location = new System.Drawing.Point(34, 461);
            this.lblLocalApplicationsCount.Name = "lblLocalApplicationsCount";
            this.lblLocalApplicationsCount.Size = new System.Drawing.Size(33, 19);
            this.lblLocalApplicationsCount.TabIndex = 11;
            this.lblLocalApplicationsCount.Text = "???";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 12F);
            this.button1.Location = new System.Drawing.Point(824, 436);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 44);
            this.button1.TabIndex = 10;
            this.button1.Text = "Close";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(328, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(371, 25);
            this.label1.TabIndex = 9;
            this.label1.Text = "Manage Local Driving Applications";
            // 
            // frmManageLocalApplications
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 492);
            this.Controls.Add(this.txtFillter);
            this.Controls.Add(this.cbFillter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAddLocalApplication);
            this.Controls.Add(this.lblLocalApplicationsCount);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvLocalApplications);
            this.Name = "frmManageLocalApplications";
            this.Text = "frmManageLocalApplications";
            this.Load += new System.EventHandler(this.frmManageLocalApplications_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLocalApplications)).EndInit();
            this.cmsLocalApplicationList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLocalApplications;
        private System.Windows.Forms.TextBox txtFillter;
        private System.Windows.Forms.ComboBox cbFillter;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnAddLocalApplication;
        private System.Windows.Forms.Label lblLocalApplicationsCount;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip cmsLocalApplicationList;
        private System.Windows.Forms.ToolStripMenuItem showLocalDrivingApplicationDetailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem canceldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleVisionTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleWrittenTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem scheduleStreetTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem issuDrivingLicenceFirstTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showPersonLicenseHistoryToolStripMenuItem;
    }
}