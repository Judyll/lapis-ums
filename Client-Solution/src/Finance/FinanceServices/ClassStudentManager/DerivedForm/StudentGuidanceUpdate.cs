using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceServices
{
    internal partial class StudentGuidanceUpdate : BaseServices.PersonInformationWithRelationship
    {
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.GroupBox gbxPersonalInfo;
        public System.Windows.Forms.Label lblStdScholarship;
        public System.Windows.Forms.Label lblStdCourse;
        public System.Windows.Forms.Label lblMiddleName;
        public System.Windows.Forms.Label lblStdFirstName;
        public System.Windows.Forms.Label lblStdLastName;
        public System.Windows.Forms.Label lblStdStudentId;
        public System.Windows.Forms.Label label117;
        public System.Windows.Forms.Label label115;
        public System.Windows.Forms.Label label18;
        public System.Windows.Forms.Label label116;
        public System.Windows.Forms.Label label19;
        public System.Windows.Forms.Label label20;
        protected System.Windows.Forms.CheckBox chkIsInternational;
        protected System.Windows.Forms.TextBox txtStudentOtherInformation;
        protected System.Windows.Forms.Button btnClose;
        protected System.Windows.Forms.Button btnUpdate;
        protected System.Windows.Forms.TabControl tabControl1;
        protected System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        protected System.Windows.Forms.CheckBox chkGoodMoral;
        protected System.Windows.Forms.CheckBox chkTranscriptOfRecords;
        protected System.Windows.Forms.CheckBox chkHonorableDismissal;
        protected System.Windows.Forms.CheckBox chkForm138;
        protected System.Windows.Forms.CheckBox chkNCAE;
        protected System.Windows.Forms.CheckBox chkPhoto;
        protected System.Windows.Forms.CheckBox chkMarriageContract;
        protected System.Windows.Forms.CheckBox chkBirthCertificate;
        private System.Windows.Forms.TabPage tblStudent;
    
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentGuidanceUpdate));
            this.tblStudent = new System.Windows.Forms.TabPage();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtStudentOtherInformation = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.chkNCAE = new System.Windows.Forms.CheckBox();
            this.chkPhoto = new System.Windows.Forms.CheckBox();
            this.chkMarriageContract = new System.Windows.Forms.CheckBox();
            this.chkBirthCertificate = new System.Windows.Forms.CheckBox();
            this.chkGoodMoral = new System.Windows.Forms.CheckBox();
            this.chkTranscriptOfRecords = new System.Windows.Forms.CheckBox();
            this.chkHonorableDismissal = new System.Windows.Forms.CheckBox();
            this.chkForm138 = new System.Windows.Forms.CheckBox();
            this.gbxPersonalInfo = new System.Windows.Forms.GroupBox();
            this.chkIsInternational = new System.Windows.Forms.CheckBox();
            this.lblStdScholarship = new System.Windows.Forms.Label();
            this.lblStdCourse = new System.Windows.Forms.Label();
            this.lblMiddleName = new System.Windows.Forms.Label();
            this.lblStdFirstName = new System.Windows.Forms.Label();
            this.lblStdLastName = new System.Windows.Forms.Label();
            this.lblStdStudentId = new System.Windows.Forms.Label();
            this.label117 = new System.Windows.Forms.Label();
            this.label115 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label116 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.tblRelationship.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPerson)).BeginInit();
            this.TabCntPerson.SuspendLayout();
            this.tblPersonalDetails.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errProvider)).BeginInit();
            this.tblStudent.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.gbxPersonalInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnClose);
            this.panel3.Controls.Add(this.btnUpdate);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            // 
            // lnkPersonArchive
            // 
            this.lnkPersonArchive.Enabled = false;
            // 
            // txtMiddleName
            // 
            this.txtMiddleName.Enabled = false;
            // 
            // txtFirstName
            // 
            this.txtFirstName.Enabled = false;
            // 
            // txtLastName
            // 
            this.txtLastName.Enabled = false;
            // 
            // TabCntPerson
            // 
            this.TabCntPerson.Controls.Add(this.tblStudent);
            this.TabCntPerson.Controls.SetChildIndex(this.tblStudent, 0);
            this.TabCntPerson.Controls.SetChildIndex(this.tblRelationship, 0);
            this.TabCntPerson.Controls.SetChildIndex(this.tblPerson, 0);
            // 
            // tblStudent
            // 
            this.tblStudent.Controls.Add(this.tabControl1);
            this.tblStudent.Controls.Add(this.gbxPersonalInfo);
            this.tblStudent.Controls.Add(this.label16);
            this.tblStudent.Location = new System.Drawing.Point(4, 24);
            this.tblStudent.Name = "tblStudent";
            this.tblStudent.Padding = new System.Windows.Forms.Padding(3);
            this.tblStudent.Size = new System.Drawing.Size(744, 430);
            this.tblStudent.TabIndex = 2;
            this.tblStudent.Text = "Student";
            this.tblStudent.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(6, 230);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(726, 197);
            this.tabControl1.TabIndex = 77;
            // 
            // tabPage3
            // 
            this.tabPage3.BackColor = System.Drawing.Color.GhostWhite;
            this.tabPage3.Controls.Add(this.txtStudentOtherInformation);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(718, 169);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Student Other Information";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtStudentOtherInformation
            // 
            this.txtStudentOtherInformation.BackColor = System.Drawing.Color.White;
            this.txtStudentOtherInformation.Location = new System.Drawing.Point(6, 6);
            this.txtStudentOtherInformation.MaxLength = 10000;
            this.txtStudentOtherInformation.Multiline = true;
            this.txtStudentOtherInformation.Name = "txtStudentOtherInformation";
            this.txtStudentOtherInformation.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtStudentOtherInformation.Size = new System.Drawing.Size(706, 157);
            this.txtStudentOtherInformation.TabIndex = 8;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.chkNCAE);
            this.tabPage4.Controls.Add(this.chkPhoto);
            this.tabPage4.Controls.Add(this.chkMarriageContract);
            this.tabPage4.Controls.Add(this.chkBirthCertificate);
            this.tabPage4.Controls.Add(this.chkGoodMoral);
            this.tabPage4.Controls.Add(this.chkTranscriptOfRecords);
            this.tabPage4.Controls.Add(this.chkHonorableDismissal);
            this.tabPage4.Controls.Add(this.chkForm138);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(718, 169);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Admission Checklist";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // chkNCAE
            // 
            this.chkNCAE.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkNCAE.AutoSize = true;
            this.chkNCAE.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNCAE.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkNCAE.Location = new System.Drawing.Point(384, 122);
            this.chkNCAE.Name = "chkNCAE";
            this.chkNCAE.Size = new System.Drawing.Size(285, 19);
            this.chkNCAE.TabIndex = 83;
            this.chkNCAE.Text = "NCAE Result (National Career Assesment Exam)";
            this.chkNCAE.UseVisualStyleBackColor = true;
            // 
            // chkPhoto
            // 
            this.chkPhoto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkPhoto.AutoSize = true;
            this.chkPhoto.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPhoto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkPhoto.Location = new System.Drawing.Point(384, 89);
            this.chkPhoto.Name = "chkPhoto";
            this.chkPhoto.Size = new System.Drawing.Size(217, 19);
            this.chkPhoto.TabIndex = 82;
            this.chkPhoto.Text = "2\" X 2\" latest photo with name tag";
            this.chkPhoto.UseVisualStyleBackColor = true;
            // 
            // chkMarriageContract
            // 
            this.chkMarriageContract.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkMarriageContract.AutoSize = true;
            this.chkMarriageContract.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMarriageContract.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkMarriageContract.Location = new System.Drawing.Point(384, 56);
            this.chkMarriageContract.Name = "chkMarriageContract";
            this.chkMarriageContract.Size = new System.Drawing.Size(282, 19);
            this.chkMarriageContract.TabIndex = 81;
            this.chkMarriageContract.Text = "Authenticated Marriage Contract (if applicable)";
            this.chkMarriageContract.UseVisualStyleBackColor = true;
            // 
            // chkBirthCertificate
            // 
            this.chkBirthCertificate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkBirthCertificate.AutoSize = true;
            this.chkBirthCertificate.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBirthCertificate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkBirthCertificate.Location = new System.Drawing.Point(384, 23);
            this.chkBirthCertificate.Name = "chkBirthCertificate";
            this.chkBirthCertificate.Size = new System.Drawing.Size(195, 19);
            this.chkBirthCertificate.TabIndex = 80;
            this.chkBirthCertificate.Text = "Authenticated Birth Certificate";
            this.chkBirthCertificate.UseVisualStyleBackColor = true;
            // 
            // chkGoodMoral
            // 
            this.chkGoodMoral.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkGoodMoral.AutoSize = true;
            this.chkGoodMoral.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGoodMoral.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkGoodMoral.Location = new System.Drawing.Point(41, 122);
            this.chkGoodMoral.Name = "chkGoodMoral";
            this.chkGoodMoral.Size = new System.Drawing.Size(220, 19);
            this.chkGoodMoral.TabIndex = 79;
            this.chkGoodMoral.Text = "Certificate of Good Moral Character";
            this.chkGoodMoral.UseVisualStyleBackColor = true;
            // 
            // chkTranscriptOfRecords
            // 
            this.chkTranscriptOfRecords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkTranscriptOfRecords.AutoSize = true;
            this.chkTranscriptOfRecords.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTranscriptOfRecords.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkTranscriptOfRecords.Location = new System.Drawing.Point(41, 89);
            this.chkTranscriptOfRecords.Name = "chkTranscriptOfRecords";
            this.chkTranscriptOfRecords.Size = new System.Drawing.Size(248, 19);
            this.chkTranscriptOfRecords.TabIndex = 78;
            this.chkTranscriptOfRecords.Text = "Informative copy of Transcript of Records";
            this.chkTranscriptOfRecords.UseVisualStyleBackColor = true;
            // 
            // chkHonorableDismissal
            // 
            this.chkHonorableDismissal.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkHonorableDismissal.AutoSize = true;
            this.chkHonorableDismissal.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkHonorableDismissal.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkHonorableDismissal.Location = new System.Drawing.Point(41, 56);
            this.chkHonorableDismissal.Name = "chkHonorableDismissal";
            this.chkHonorableDismissal.Size = new System.Drawing.Size(242, 19);
            this.chkHonorableDismissal.TabIndex = 77;
            this.chkHonorableDismissal.Text = "Transfer Credential Honorable Dismissal";
            this.chkHonorableDismissal.UseVisualStyleBackColor = true;
            // 
            // chkForm138
            // 
            this.chkForm138.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkForm138.AutoSize = true;
            this.chkForm138.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkForm138.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkForm138.Location = new System.Drawing.Point(41, 23);
            this.chkForm138.Name = "chkForm138";
            this.chkForm138.Size = new System.Drawing.Size(180, 19);
            this.chkForm138.TabIndex = 76;
            this.chkForm138.Text = "High School Card (Form 138)";
            this.chkForm138.UseVisualStyleBackColor = true;
            // 
            // gbxPersonalInfo
            // 
            this.gbxPersonalInfo.Controls.Add(this.chkIsInternational);
            this.gbxPersonalInfo.Controls.Add(this.lblStdScholarship);
            this.gbxPersonalInfo.Controls.Add(this.lblStdCourse);
            this.gbxPersonalInfo.Controls.Add(this.lblMiddleName);
            this.gbxPersonalInfo.Controls.Add(this.lblStdFirstName);
            this.gbxPersonalInfo.Controls.Add(this.lblStdLastName);
            this.gbxPersonalInfo.Controls.Add(this.lblStdStudentId);
            this.gbxPersonalInfo.Controls.Add(this.label117);
            this.gbxPersonalInfo.Controls.Add(this.label115);
            this.gbxPersonalInfo.Controls.Add(this.label18);
            this.gbxPersonalInfo.Controls.Add(this.label116);
            this.gbxPersonalInfo.Controls.Add(this.label19);
            this.gbxPersonalInfo.Controls.Add(this.label20);
            this.gbxPersonalInfo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxPersonalInfo.ForeColor = System.Drawing.Color.Navy;
            this.gbxPersonalInfo.Location = new System.Drawing.Point(6, 39);
            this.gbxPersonalInfo.Name = "gbxPersonalInfo";
            this.gbxPersonalInfo.Size = new System.Drawing.Size(732, 191);
            this.gbxPersonalInfo.TabIndex = 7;
            this.gbxPersonalInfo.TabStop = false;
            this.gbxPersonalInfo.Text = " EDUCATIONAL INFORMATION ";
            // 
            // chkIsInternational
            // 
            this.chkIsInternational.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIsInternational.AutoSize = true;
            this.chkIsInternational.Enabled = false;
            this.chkIsInternational.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsInternational.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.chkIsInternational.Location = new System.Drawing.Point(113, 163);
            this.chkIsInternational.Name = "chkIsInternational";
            this.chkIsInternational.Size = new System.Drawing.Size(155, 19);
            this.chkIsInternational.TabIndex = 75;
            this.chkIsInternational.Text = "Is International Student";
            this.chkIsInternational.UseVisualStyleBackColor = true;
            // 
            // lblStdScholarship
            // 
            this.lblStdScholarship.AutoSize = true;
            this.lblStdScholarship.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStdScholarship.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStdScholarship.Location = new System.Drawing.Point(110, 140);
            this.lblStdScholarship.Name = "lblStdScholarship";
            this.lblStdScholarship.Size = new System.Drawing.Size(11, 15);
            this.lblStdScholarship.TabIndex = 30;
            this.lblStdScholarship.Text = "-";
            // 
            // lblStdCourse
            // 
            this.lblStdCourse.AutoSize = true;
            this.lblStdCourse.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStdCourse.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStdCourse.Location = new System.Drawing.Point(110, 117);
            this.lblStdCourse.Name = "lblStdCourse";
            this.lblStdCourse.Size = new System.Drawing.Size(11, 15);
            this.lblStdCourse.TabIndex = 29;
            this.lblStdCourse.Text = "-";
            // 
            // lblMiddleName
            // 
            this.lblMiddleName.AutoSize = true;
            this.lblMiddleName.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMiddleName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblMiddleName.Location = new System.Drawing.Point(110, 94);
            this.lblMiddleName.Name = "lblMiddleName";
            this.lblMiddleName.Size = new System.Drawing.Size(11, 15);
            this.lblMiddleName.TabIndex = 28;
            this.lblMiddleName.Text = "-";
            // 
            // lblStdFirstName
            // 
            this.lblStdFirstName.AutoSize = true;
            this.lblStdFirstName.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStdFirstName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStdFirstName.Location = new System.Drawing.Point(110, 71);
            this.lblStdFirstName.Name = "lblStdFirstName";
            this.lblStdFirstName.Size = new System.Drawing.Size(11, 15);
            this.lblStdFirstName.TabIndex = 27;
            this.lblStdFirstName.Text = "-";
            // 
            // lblStdLastName
            // 
            this.lblStdLastName.AutoSize = true;
            this.lblStdLastName.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStdLastName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStdLastName.Location = new System.Drawing.Point(110, 48);
            this.lblStdLastName.Name = "lblStdLastName";
            this.lblStdLastName.Size = new System.Drawing.Size(11, 15);
            this.lblStdLastName.TabIndex = 26;
            this.lblStdLastName.Text = "-";
            // 
            // lblStdStudentId
            // 
            this.lblStdStudentId.AutoSize = true;
            this.lblStdStudentId.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStdStudentId.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblStdStudentId.Location = new System.Drawing.Point(110, 24);
            this.lblStdStudentId.Name = "lblStdStudentId";
            this.lblStdStudentId.Size = new System.Drawing.Size(11, 15);
            this.lblStdStudentId.TabIndex = 25;
            this.lblStdStudentId.Text = "-";
            // 
            // label117
            // 
            this.label117.AutoSize = true;
            this.label117.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label117.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label117.Location = new System.Drawing.Point(19, 140);
            this.label117.Name = "label117";
            this.label117.Size = new System.Drawing.Size(72, 15);
            this.label117.TabIndex = 24;
            this.label117.Text = "Scholarship:";
            // 
            // label115
            // 
            this.label115.AutoSize = true;
            this.label115.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label115.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label115.Location = new System.Drawing.Point(42, 117);
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(49, 15);
            this.label115.TabIndex = 23;
            this.label115.Text = "Course:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label18.Location = new System.Drawing.Point(6, 94);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(85, 15);
            this.label18.TabIndex = 22;
            this.label18.Text = "Middle Name:";
            // 
            // label116
            // 
            this.label116.AutoSize = true;
            this.label116.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label116.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label116.Location = new System.Drawing.Point(23, 24);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(68, 15);
            this.label116.TabIndex = 21;
            this.label116.Text = "Student Id:";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label19.Location = new System.Drawing.Point(22, 48);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(69, 15);
            this.label19.TabIndex = 17;
            this.label19.Text = "Last Name:";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.DarkMagenta;
            this.label20.Location = new System.Drawing.Point(22, 71);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(71, 15);
            this.label20.TabIndex = 18;
            this.label20.Text = "First Name:";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Orange;
            this.label16.Location = new System.Drawing.Point(564, 15);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(170, 20);
            this.label16.TabIndex = 6;
            this.label16.Text = "Student Information";
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(680, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 23);
            this.btnClose.TabIndex = 95;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUpdate.BackgroundImage")));
            this.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(588, 7);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(86, 23);
            this.btnUpdate.TabIndex = 94;
            this.btnUpdate.Text = "  Update";
            this.btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // StudentGuidanceUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(780, 575);
            this.Name = "StudentGuidanceUpdate";
            this.tblRelationship.ResumeLayout(false);
            this.tblRelationship.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxPerson)).EndInit();
            this.TabCntPerson.ResumeLayout(false);
            this.tblPersonalDetails.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._errProvider)).EndInit();
            this.tblStudent.ResumeLayout(false);
            this.tblStudent.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.gbxPersonalInfo.ResumeLayout(false);
            this.gbxPersonalInfo.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
