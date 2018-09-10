namespace FinanceServices
{
    partial class StudentCashier
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
            this.pbxStudent = new System.Windows.Forms.PictureBox();
            this.gbxPersonalInfo = new System.Windows.Forms.GroupBox();
            this.chkRequiredDownPayment = new System.Windows.Forms.CheckBox();
            this.lnkPersonArchive = new System.Windows.Forms.LinkLabel();
            this.lnkVerify = new System.Windows.Forms.LinkLabel();
            this.chkIsInternational = new System.Windows.Forms.CheckBox();
            this.txtScholarship = new System.Windows.Forms.TextBox();
            this.txtMiddleName = new System.Windows.Forms.TextBox();
            this.lnkGenerateStudentId = new System.Windows.Forms.LinkLabel();
            this.txtStudentFirstName = new System.Windows.Forms.TextBox();
            this.txtStudentLastName = new System.Windows.Forms.TextBox();
            this.txtStudentId = new System.Windows.Forms.TextBox();
            this.lblScholarship = new System.Windows.Forms.Label();
            this.lblMiddleName = new System.Windows.Forms.Label();
            this.lblStudentId = new System.Windows.Forms.Label();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblFirstName = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.trvStudentEnrolment = new System.Windows.Forms.TreeView();
            this.gbxEnrolmentInfo = new System.Windows.Forms.GroupBox();
            this.mnuCreateCourse = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lnkCreateCourse = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuUpdateCourse = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lnkUpdateCourse = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDelete = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lnkUpdateStudentEntryLevel = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCreateEntryLevel = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lnkCreateStudentEntryLevel = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pbxStudent)).BeginInit();
            this.gbxPersonalInfo.SuspendLayout();
            this.gbxEnrolmentInfo.SuspendLayout();
            this.mnuCreateCourse.SuspendLayout();
            this.mnuUpdateCourse.SuspendLayout();
            this.mnuDelete.SuspendLayout();
            this.mnuCreateEntryLevel.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbxStudent
            // 
            this.pbxStudent.BackColor = System.Drawing.Color.DarkGray;
            this.pbxStudent.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pbxStudent.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.pbxStudent.Location = new System.Drawing.Point(498, 21);
            this.pbxStudent.Name = "pbxStudent";
            this.pbxStudent.Size = new System.Drawing.Size(87, 85);
            this.pbxStudent.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxStudent.TabIndex = 15;
            this.pbxStudent.TabStop = false;
            // 
            // gbxPersonalInfo
            // 
            this.gbxPersonalInfo.Controls.Add(this.chkRequiredDownPayment);
            this.gbxPersonalInfo.Controls.Add(this.lnkPersonArchive);
            this.gbxPersonalInfo.Controls.Add(this.lnkVerify);
            this.gbxPersonalInfo.Controls.Add(this.chkIsInternational);
            this.gbxPersonalInfo.Controls.Add(this.pbxStudent);
            this.gbxPersonalInfo.Controls.Add(this.txtScholarship);
            this.gbxPersonalInfo.Controls.Add(this.txtMiddleName);
            this.gbxPersonalInfo.Controls.Add(this.lnkGenerateStudentId);
            this.gbxPersonalInfo.Controls.Add(this.txtStudentFirstName);
            this.gbxPersonalInfo.Controls.Add(this.txtStudentLastName);
            this.gbxPersonalInfo.Controls.Add(this.txtStudentId);
            this.gbxPersonalInfo.Controls.Add(this.lblScholarship);
            this.gbxPersonalInfo.Controls.Add(this.lblMiddleName);
            this.gbxPersonalInfo.Controls.Add(this.lblStudentId);
            this.gbxPersonalInfo.Controls.Add(this.lblLastName);
            this.gbxPersonalInfo.Controls.Add(this.lblFirstName);
            this.gbxPersonalInfo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxPersonalInfo.ForeColor = System.Drawing.Color.Navy;
            this.gbxPersonalInfo.Location = new System.Drawing.Point(15, 67);
            this.gbxPersonalInfo.Name = "gbxPersonalInfo";
            this.gbxPersonalInfo.Size = new System.Drawing.Size(596, 198);
            this.gbxPersonalInfo.TabIndex = 0;
            this.gbxPersonalInfo.TabStop = false;
            this.gbxPersonalInfo.Text = " PERSONAL INFORMATION ";
            // 
            // chkRequiredDownPayment
            // 
            this.chkRequiredDownPayment.AutoSize = true;
            this.chkRequiredDownPayment.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRequiredDownPayment.ForeColor = System.Drawing.Color.Navy;
            this.chkRequiredDownPayment.Location = new System.Drawing.Point(309, 168);
            this.chkRequiredDownPayment.Name = "chkRequiredDownPayment";
            this.chkRequiredDownPayment.Size = new System.Drawing.Size(212, 22);
            this.chkRequiredDownPayment.TabIndex = 76;
            this.chkRequiredDownPayment.Text = "Is No Downpayment Required";
            this.chkRequiredDownPayment.UseVisualStyleBackColor = true;
            // 
            // lnkPersonArchive
            // 
            this.lnkPersonArchive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkPersonArchive.AutoSize = true;
            this.lnkPersonArchive.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkPersonArchive.ForeColor = System.Drawing.Color.DarkBlue;
            this.lnkPersonArchive.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkPersonArchive.Location = new System.Drawing.Point(225, 118);
            this.lnkPersonArchive.Name = "lnkPersonArchive";
            this.lnkPersonArchive.Size = new System.Drawing.Size(126, 15);
            this.lnkPersonArchive.TabIndex = 75;
            this.lnkPersonArchive.TabStop = true;
            this.lnkPersonArchive.Text = "[ Go Person Archive ]";
            this.lnkPersonArchive.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lnkVerify
            // 
            this.lnkVerify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkVerify.AutoSize = true;
            this.lnkVerify.Enabled = false;
            this.lnkVerify.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkVerify.ForeColor = System.Drawing.Color.DarkBlue;
            this.lnkVerify.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkVerify.Location = new System.Drawing.Point(106, 118);
            this.lnkVerify.Name = "lnkVerify";
            this.lnkVerify.Size = new System.Drawing.Size(113, 15);
            this.lnkVerify.TabIndex = 74;
            this.lnkVerify.TabStop = true;
            this.lnkVerify.Text = "[ Verify Existence ]";
            this.lnkVerify.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkIsInternational
            // 
            this.chkIsInternational.AutoSize = true;
            this.chkIsInternational.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsInternational.ForeColor = System.Drawing.Color.Navy;
            this.chkIsInternational.Location = new System.Drawing.Point(106, 168);
            this.chkIsInternational.Name = "chkIsInternational";
            this.chkIsInternational.Size = new System.Drawing.Size(173, 22);
            this.chkIsInternational.TabIndex = 73;
            this.chkIsInternational.Text = "Is International Student";
            this.chkIsInternational.UseVisualStyleBackColor = true;
            // 
            // txtScholarship
            // 
            this.txtScholarship.BackColor = System.Drawing.Color.White;
            this.txtScholarship.Location = new System.Drawing.Point(106, 141);
            this.txtScholarship.MaxLength = 50;
            this.txtScholarship.Name = "txtScholarship";
            this.txtScholarship.Size = new System.Drawing.Size(479, 22);
            this.txtScholarship.TabIndex = 5;
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.BackColor = System.Drawing.Color.White;
            this.txtMiddleName.Location = new System.Drawing.Point(106, 93);
            this.txtMiddleName.MaxLength = 50;
            this.txtMiddleName.Name = "txtMiddleName";
            this.txtMiddleName.Size = new System.Drawing.Size(376, 22);
            this.txtMiddleName.TabIndex = 4;
            // 
            // lnkGenerateStudentId
            // 
            this.lnkGenerateStudentId.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkGenerateStudentId.AutoSize = true;
            this.lnkGenerateStudentId.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkGenerateStudentId.ForeColor = System.Drawing.Color.DarkBlue;
            this.lnkGenerateStudentId.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkGenerateStudentId.Location = new System.Drawing.Point(348, 23);
            this.lnkGenerateStudentId.Name = "lnkGenerateStudentId";
            this.lnkGenerateStudentId.Size = new System.Drawing.Size(134, 15);
            this.lnkGenerateStudentId.TabIndex = 0;
            this.lnkGenerateStudentId.TabStop = true;
            this.lnkGenerateStudentId.Text = "[ Generate Student ID ]";
            this.lnkGenerateStudentId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtStudentFirstName
            // 
            this.txtStudentFirstName.BackColor = System.Drawing.Color.White;
            this.txtStudentFirstName.Location = new System.Drawing.Point(106, 69);
            this.txtStudentFirstName.MaxLength = 50;
            this.txtStudentFirstName.Name = "txtStudentFirstName";
            this.txtStudentFirstName.Size = new System.Drawing.Size(376, 22);
            this.txtStudentFirstName.TabIndex = 3;
            // 
            // txtStudentLastName
            // 
            this.txtStudentLastName.BackColor = System.Drawing.Color.White;
            this.txtStudentLastName.Location = new System.Drawing.Point(106, 45);
            this.txtStudentLastName.MaxLength = 50;
            this.txtStudentLastName.Name = "txtStudentLastName";
            this.txtStudentLastName.Size = new System.Drawing.Size(376, 22);
            this.txtStudentLastName.TabIndex = 2;
            // 
            // txtStudentId
            // 
            this.txtStudentId.BackColor = System.Drawing.Color.White;
            this.txtStudentId.Location = new System.Drawing.Point(106, 21);
            this.txtStudentId.MaxLength = 50;
            this.txtStudentId.Name = "txtStudentId";
            this.txtStudentId.Size = new System.Drawing.Size(236, 22);
            this.txtStudentId.TabIndex = 1;
            // 
            // lblScholarship
            // 
            this.lblScholarship.AutoSize = true;
            this.lblScholarship.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScholarship.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblScholarship.Location = new System.Drawing.Point(18, 142);
            this.lblScholarship.Name = "lblScholarship";
            this.lblScholarship.Size = new System.Drawing.Size(72, 15);
            this.lblScholarship.TabIndex = 24;
            this.lblScholarship.Text = "Scholarship:";
            // 
            // lblMiddleName
            // 
            this.lblMiddleName.AutoSize = true;
            this.lblMiddleName.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMiddleName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMiddleName.Location = new System.Drawing.Point(5, 92);
            this.lblMiddleName.Name = "lblMiddleName";
            this.lblMiddleName.Size = new System.Drawing.Size(85, 15);
            this.lblMiddleName.TabIndex = 22;
            this.lblMiddleName.Text = "Middle Name:";
            // 
            // lblStudentId
            // 
            this.lblStudentId.AutoSize = true;
            this.lblStudentId.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStudentId.ForeColor = System.Drawing.Color.DarkMagenta;
            this.lblStudentId.Location = new System.Drawing.Point(22, 22);
            this.lblStudentId.Name = "lblStudentId";
            this.lblStudentId.Size = new System.Drawing.Size(68, 15);
            this.lblStudentId.TabIndex = 21;
            this.lblStudentId.Text = "Student Id:";
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLastName.ForeColor = System.Drawing.Color.DarkMagenta;
            this.lblLastName.Location = new System.Drawing.Point(21, 46);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(69, 15);
            this.lblLastName.TabIndex = 17;
            this.lblLastName.Text = "Last Name:";
            // 
            // lblFirstName
            // 
            this.lblFirstName.AutoSize = true;
            this.lblFirstName.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFirstName.ForeColor = System.Drawing.Color.DarkMagenta;
            this.lblFirstName.Location = new System.Drawing.Point(19, 69);
            this.lblFirstName.Name = "lblFirstName";
            this.lblFirstName.Size = new System.Drawing.Size(71, 15);
            this.lblFirstName.TabIndex = 18;
            this.lblFirstName.Text = "First Name:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(630, 58);
            this.panel1.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(179)))), ((int)(((byte)(133)))));
            this.panel2.Location = new System.Drawing.Point(0, 616);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(630, 35);
            this.panel2.TabIndex = 18;
            // 
            // trvStudentEnrolment
            // 
            this.trvStudentEnrolment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trvStudentEnrolment.BackColor = System.Drawing.Color.White;
            this.trvStudentEnrolment.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trvStudentEnrolment.Indent = 20;
            this.trvStudentEnrolment.ItemHeight = 25;
            this.trvStudentEnrolment.Location = new System.Drawing.Point(21, 33);
            this.trvStudentEnrolment.Name = "trvStudentEnrolment";
            this.trvStudentEnrolment.ShowNodeToolTips = true;
            this.trvStudentEnrolment.Size = new System.Drawing.Size(554, 271);
            this.trvStudentEnrolment.TabIndex = 20;
            // 
            // gbxEnrolmentInfo
            // 
            this.gbxEnrolmentInfo.Controls.Add(this.trvStudentEnrolment);
            this.gbxEnrolmentInfo.Enabled = false;
            this.gbxEnrolmentInfo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxEnrolmentInfo.ForeColor = System.Drawing.Color.DarkMagenta;
            this.gbxEnrolmentInfo.Location = new System.Drawing.Point(15, 271);
            this.gbxEnrolmentInfo.Name = "gbxEnrolmentInfo";
            this.gbxEnrolmentInfo.Size = new System.Drawing.Size(596, 328);
            this.gbxEnrolmentInfo.TabIndex = 21;
            this.gbxEnrolmentInfo.TabStop = false;
            this.gbxEnrolmentInfo.Text = " STUDENT ENROLMENT INFORMATION ";
            // 
            // mnuCreateCourse
            // 
            this.mnuCreateCourse.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lnkCreateCourse});
            this.mnuCreateCourse.Name = "mnuCreateCourse";
            this.mnuCreateCourse.Size = new System.Drawing.Size(156, 26);
            // 
            // lnkCreateCourse
            // 
            this.lnkCreateCourse.Name = "lnkCreateCourse";
            this.lnkCreateCourse.Size = new System.Drawing.Size(155, 22);
            this.lnkCreateCourse.Text = "Create Course";
            // 
            // mnuUpdateCourse
            // 
            this.mnuUpdateCourse.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lnkUpdateCourse});
            this.mnuUpdateCourse.Name = "mnuUpdateCourse";
            this.mnuUpdateCourse.Size = new System.Drawing.Size(158, 26);
            // 
            // lnkUpdateCourse
            // 
            this.lnkUpdateCourse.Name = "lnkUpdateCourse";
            this.lnkUpdateCourse.Size = new System.Drawing.Size(157, 22);
            this.lnkUpdateCourse.Text = "Update Course";
            // 
            // mnuDelete
            // 
            this.mnuDelete.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lnkUpdateStudentEntryLevel});
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.Size = new System.Drawing.Size(219, 26);
            // 
            // lnkUpdateStudentEntryLevel
            // 
            this.lnkUpdateStudentEntryLevel.Name = "lnkUpdateStudentEntryLevel";
            this.lnkUpdateStudentEntryLevel.Size = new System.Drawing.Size(218, 22);
            this.lnkUpdateStudentEntryLevel.Text = "Update Student Entry Level";
            // 
            // mnuCreateEntryLevel
            // 
            this.mnuCreateEntryLevel.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lnkCreateStudentEntryLevel});
            this.mnuCreateEntryLevel.Name = "mnuCreateEntryLevel";
            this.mnuCreateEntryLevel.Size = new System.Drawing.Size(176, 26);
            // 
            // lnkCreateStudentEntryLevel
            // 
            this.lnkCreateStudentEntryLevel.Name = "lnkCreateStudentEntryLevel";
            this.lnkCreateStudentEntryLevel.Size = new System.Drawing.Size(175, 22);
            this.lnkCreateStudentEntryLevel.Text = "Create Entry Level";
            // 
            // StudentCashier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(626, 651);
            this.Controls.Add(this.gbxPersonalInfo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.gbxEnrolmentInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StudentCashier";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.pbxStudent)).EndInit();
            this.gbxPersonalInfo.ResumeLayout(false);
            this.gbxPersonalInfo.PerformLayout();
            this.gbxEnrolmentInfo.ResumeLayout(false);
            this.mnuCreateCourse.ResumeLayout(false);
            this.mnuUpdateCourse.ResumeLayout(false);
            this.mnuDelete.ResumeLayout(false);
            this.mnuCreateEntryLevel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.PictureBox pbxStudent;
        public System.Windows.Forms.GroupBox gbxPersonalInfo;
        public System.Windows.Forms.Label lblScholarship;
        public System.Windows.Forms.Label lblMiddleName;
        public System.Windows.Forms.Label lblStudentId;
        public System.Windows.Forms.Label lblLastName;
        public System.Windows.Forms.Label lblFirstName;
        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.TextBox txtScholarship;
        protected System.Windows.Forms.TextBox txtMiddleName;
        protected System.Windows.Forms.TextBox txtStudentFirstName;
        protected System.Windows.Forms.TextBox txtStudentLastName;
        protected System.Windows.Forms.TextBox txtStudentId;
        protected System.Windows.Forms.Panel panel2;
        protected System.Windows.Forms.LinkLabel lnkGenerateStudentId;
        protected System.Windows.Forms.CheckBox chkIsInternational;
        protected System.Windows.Forms.GroupBox gbxEnrolmentInfo;
        private System.Windows.Forms.ToolStripMenuItem lnkCreateCourse;
        private System.Windows.Forms.ToolStripMenuItem lnkUpdateCourse;
        private System.Windows.Forms.ToolStripMenuItem lnkUpdateStudentEntryLevel;
        private System.Windows.Forms.ToolStripMenuItem lnkCreateStudentEntryLevel;
        protected System.Windows.Forms.TreeView trvStudentEnrolment;
        protected System.Windows.Forms.ContextMenuStrip mnuCreateCourse;
        protected System.Windows.Forms.ContextMenuStrip mnuUpdateCourse;
        protected System.Windows.Forms.ContextMenuStrip mnuDelete;
        protected System.Windows.Forms.ContextMenuStrip mnuCreateEntryLevel;
        protected System.Windows.Forms.LinkLabel lnkVerify;
        protected System.Windows.Forms.LinkLabel lnkPersonArchive;
        protected System.Windows.Forms.CheckBox chkRequiredDownPayment;
    }
}