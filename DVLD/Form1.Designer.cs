namespace DVLD
{
    partial class frmDVLDMain
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblCurrentUser = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.cmsSettings = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.logOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnUsers = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.driveingLiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newDrivingLicencToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.internationalDrivingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renewDrivingLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.replacementForDamagedOrLostLicensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageApplicationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.localDrivingLicensesApplicationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.interToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detainReleaseLicensesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.detainLicenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.relToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            this.panel1.SuspendLayout();
            this.cmsSettings.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lblCurrentUser);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.btnUsers);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1619, 100);
            this.panel1.TabIndex = 0;
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.AutoSize = true;
            this.lblCurrentUser.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblCurrentUser.Location = new System.Drawing.Point(1519, 42);
            this.lblCurrentUser.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(0, 21);
            this.lblCurrentUser.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(1396, 42);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "logged in By:";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button4.ContextMenuStrip = this.cmsSettings;
            this.button4.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(548, 0);
            this.button4.Margin = new System.Windows.Forms.Padding(4);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(185, 100);
            this.button4.TabIndex = 3;
            this.button4.Text = "Settings";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // cmsSettings
            // 
            this.cmsSettings.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsSettings.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.logOutToolStripMenuItem});
            this.cmsSettings.Name = "cmsSettings";
            this.cmsSettings.Size = new System.Drawing.Size(218, 76);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(217, 24);
            this.toolStripMenuItem2.Text = "My Info";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(217, 24);
            this.toolStripMenuItem3.Text = "Change My Password";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // logOutToolStripMenuItem
            // 
            this.logOutToolStripMenuItem.Name = "logOutToolStripMenuItem";
            this.logOutToolStripMenuItem.Size = new System.Drawing.Size(217, 24);
            this.logOutToolStripMenuItem.Text = "LogOut";
            this.logOutToolStripMenuItem.Click += new System.EventHandler(this.logOutToolStripMenuItem_Click);
            // 
            // btnUsers
            // 
            this.btnUsers.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnUsers.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsers.ForeColor = System.Drawing.Color.White;
            this.btnUsers.Image = global::DVLD.Properties.Resources.american;
            this.btnUsers.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUsers.Location = new System.Drawing.Point(364, 0);
            this.btnUsers.Margin = new System.Windows.Forms.Padding(4);
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.Size = new System.Drawing.Size(185, 100);
            this.btnUsers.TabIndex = 2;
            this.btnUsers.Text = "      Users";
            this.btnUsers.UseVisualStyleBackColor = false;
            this.btnUsers.Click += new System.EventHandler(this.btnUsers_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = global::DVLD.Properties.Resources.american;
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(181, 0);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(185, 100);
            this.button2.TabIndex = 2;
            this.button2.Text = "         Drivers";
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.button1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::DVLD.Properties.Resources.american;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 100);
            this.button1.TabIndex = 1;
            this.button1.Text = "         People";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 100);
            this.menuStrip1.Margin = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.menuStrip1.Size = new System.Drawing.Size(1619, 53);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.driveingLiToolStripMenuItem,
            this.manageApplicationToolStripMenuItem,
            this.detainReleaseLicensesToolStripMenuItem});
            this.toolStripMenuItem1.ForeColor = System.Drawing.Color.Gainsboro;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(167, 41);
            this.toolStripMenuItem1.Text = "Application";
            // 
            // driveingLiToolStripMenuItem
            // 
            this.driveingLiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newDrivingLicencToolStripMenuItem,
            this.renewDrivingLicenseToolStripMenuItem,
            this.replacementForDamagedOrLostLicensesToolStripMenuItem});
            this.driveingLiToolStripMenuItem.Name = "driveingLiToolStripMenuItem";
            this.driveingLiToolStripMenuItem.Size = new System.Drawing.Size(441, 42);
            this.driveingLiToolStripMenuItem.Text = "driving Licenses Services";
            // 
            // newDrivingLicencToolStripMenuItem
            // 
            this.newDrivingLicencToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localDrivingLicenseToolStripMenuItem,
            this.internationalDrivingToolStripMenuItem});
            this.newDrivingLicencToolStripMenuItem.Name = "newDrivingLicencToolStripMenuItem";
            this.newDrivingLicencToolStripMenuItem.Size = new System.Drawing.Size(616, 42);
            this.newDrivingLicencToolStripMenuItem.Text = "New Driving License";
            // 
            // localDrivingLicenseToolStripMenuItem
            // 
            this.localDrivingLicenseToolStripMenuItem.Name = "localDrivingLicenseToolStripMenuItem";
            this.localDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(445, 42);
            this.localDrivingLicenseToolStripMenuItem.Text = "Local Driving License";
            this.localDrivingLicenseToolStripMenuItem.Click += new System.EventHandler(this.localDrivingLicenseToolStripMenuItem_Click);
            // 
            // internationalDrivingToolStripMenuItem
            // 
            this.internationalDrivingToolStripMenuItem.Name = "internationalDrivingToolStripMenuItem";
            this.internationalDrivingToolStripMenuItem.Size = new System.Drawing.Size(445, 42);
            this.internationalDrivingToolStripMenuItem.Text = "International Driving License";
            this.internationalDrivingToolStripMenuItem.Click += new System.EventHandler(this.internationalDrivingToolStripMenuItem_Click);
            // 
            // renewDrivingLicenseToolStripMenuItem
            // 
            this.renewDrivingLicenseToolStripMenuItem.Name = "renewDrivingLicenseToolStripMenuItem";
            this.renewDrivingLicenseToolStripMenuItem.Size = new System.Drawing.Size(616, 42);
            this.renewDrivingLicenseToolStripMenuItem.Text = "Renew Driving License";
            this.renewDrivingLicenseToolStripMenuItem.Click += new System.EventHandler(this.renewDrivingLicenseToolStripMenuItem_Click);
            // 
            // replacementForDamagedOrLostLicensesToolStripMenuItem
            // 
            this.replacementForDamagedOrLostLicensesToolStripMenuItem.Name = "replacementForDamagedOrLostLicensesToolStripMenuItem";
            this.replacementForDamagedOrLostLicensesToolStripMenuItem.Size = new System.Drawing.Size(616, 42);
            this.replacementForDamagedOrLostLicensesToolStripMenuItem.Text = "Replacement for Damaged or Lost Licenses";
            this.replacementForDamagedOrLostLicensesToolStripMenuItem.Click += new System.EventHandler(this.replacementForDamagedOrLostLicensesToolStripMenuItem_Click);
            // 
            // manageApplicationToolStripMenuItem
            // 
            this.manageApplicationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.localDrivingLicensesApplicationsToolStripMenuItem,
            this.interToolStripMenuItem});
            this.manageApplicationToolStripMenuItem.Name = "manageApplicationToolStripMenuItem";
            this.manageApplicationToolStripMenuItem.Size = new System.Drawing.Size(441, 42);
            this.manageApplicationToolStripMenuItem.Text = "Manage Application";
            // 
            // localDrivingLicensesApplicationsToolStripMenuItem
            // 
            this.localDrivingLicensesApplicationsToolStripMenuItem.Name = "localDrivingLicensesApplicationsToolStripMenuItem";
            this.localDrivingLicensesApplicationsToolStripMenuItem.Size = new System.Drawing.Size(588, 42);
            this.localDrivingLicensesApplicationsToolStripMenuItem.Text = "Local Driving Licenses Applications";
            this.localDrivingLicensesApplicationsToolStripMenuItem.Click += new System.EventHandler(this.localDrivingLicensesApplicationsToolStripMenuItem_Click);
            // 
            // interToolStripMenuItem
            // 
            this.interToolStripMenuItem.Name = "interToolStripMenuItem";
            this.interToolStripMenuItem.Size = new System.Drawing.Size(588, 42);
            this.interToolStripMenuItem.Text = "International Driving License Applicaiton";
            this.interToolStripMenuItem.Click += new System.EventHandler(this.interToolStripMenuItem_Click);
            // 
            // detainReleaseLicensesToolStripMenuItem
            // 
            this.detainReleaseLicensesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manageToolStripMenuItem,
            this.detainLicenseToolStripMenuItem,
            this.relToolStripMenuItem});
            this.detainReleaseLicensesToolStripMenuItem.Name = "detainReleaseLicensesToolStripMenuItem";
            this.detainReleaseLicensesToolStripMenuItem.Size = new System.Drawing.Size(441, 42);
            this.detainReleaseLicensesToolStripMenuItem.Text = "Detain And Release Licenses";
            // 
            // manageToolStripMenuItem
            // 
            this.manageToolStripMenuItem.Name = "manageToolStripMenuItem";
            this.manageToolStripMenuItem.Size = new System.Drawing.Size(413, 42);
            this.manageToolStripMenuItem.Text = "Manage Detained License";
            // 
            // detainLicenseToolStripMenuItem
            // 
            this.detainLicenseToolStripMenuItem.Name = "detainLicenseToolStripMenuItem";
            this.detainLicenseToolStripMenuItem.Size = new System.Drawing.Size(413, 42);
            this.detainLicenseToolStripMenuItem.Text = "Detain License";
            this.detainLicenseToolStripMenuItem.Click += new System.EventHandler(this.detainLicenseToolStripMenuItem_Click);
            // 
            // relToolStripMenuItem
            // 
            this.relToolStripMenuItem.Name = "relToolStripMenuItem";
            this.relToolStripMenuItem.Size = new System.Drawing.Size(413, 42);
            this.relToolStripMenuItem.Text = "Release License";
            this.relToolStripMenuItem.Click += new System.EventHandler(this.relToolStripMenuItem_Click);
            // 
            // guna2PictureBox1
            // 
            this.guna2PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.guna2PictureBox1.Image = global::DVLD.Properties.Resources.e6ec4896_3114_431f_b95e_06515a939f43;
            this.guna2PictureBox1.ImageRotate = 0F;
            this.guna2PictureBox1.Location = new System.Drawing.Point(0, 153);
            this.guna2PictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.guna2PictureBox1.Name = "guna2PictureBox1";
            this.guna2PictureBox1.Size = new System.Drawing.Size(1619, 519);
            this.guna2PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.guna2PictureBox1.TabIndex = 2;
            this.guna2PictureBox1.TabStop = false;
            // 
            // frmDVLDMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1619, 672);
            this.Controls.Add(this.guna2PictureBox1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmDVLDMain";
            this.Text = "DVLD";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmDVLDMain_FormClosed);
            this.Load += new System.EventHandler(this.frmDVLDMain_Load);
            this.MouseHover += new System.EventHandler(this.frmDVLDMain_MouseHover);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.cmsSettings.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.guna2PictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnUsers;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lblCurrentUser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ContextMenuStrip cmsSettings;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem logOutToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem driveingLiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newDrivingLicencToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageApplicationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localDrivingLicensesApplicationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem localDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem internationalDrivingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem interToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renewDrivingLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem replacementForDamagedOrLostLicensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detainReleaseLicensesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem detainLicenseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem relToolStripMenuItem;
        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;
    }
}

