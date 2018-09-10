namespace OfficeServices
{
    partial class Service
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbxDepartment = new System.Windows.Forms.GroupBox();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.gbxDescriptive = new System.Windows.Forms.GroupBox();
            this.lnkOtherInfo = new System.Windows.Forms.LinkLabel();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.gbxSubject = new System.Windows.Forms.GroupBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.gbxCourseGroup = new System.Windows.Forms.GroupBox();
            this.cboCourseGroup = new System.Windows.Forms.ComboBox();
            this.gbxSysID = new System.Windows.Forms.GroupBox();
            this.lblSysID = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.hrmHours = new RemoteClient.HourMinute();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optHours = new System.Windows.Forms.RadioButton();
            this.lblHours = new System.Windows.Forms.Label();
            this.lblLaboratory = new System.Windows.Forms.Label();
            this.lblLecture = new System.Windows.Forms.Label();
            this.txtLaboratory = new System.Windows.Forms.TextBox();
            this.optUnits = new System.Windows.Forms.RadioButton();
            this.txtLecture = new System.Windows.Forms.TextBox();
            this.gbxDepartment.SuspendLayout();
            this.gbxDescriptive.SuspendLayout();
            this.gbxSubject.SuspendLayout();
            this.gbxCourseGroup.SuspendLayout();
            this.gbxSysID.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(-3, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(575, 58);
            this.panel1.TabIndex = 13;
            // 
            // gbxDepartment
            // 
            this.gbxDepartment.Controls.Add(this.cboDepartment);
            this.gbxDepartment.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxDepartment.ForeColor = System.Drawing.Color.Navy;
            this.gbxDepartment.Location = new System.Drawing.Point(11, 140);
            this.gbxDepartment.Name = "gbxDepartment";
            this.gbxDepartment.Size = new System.Drawing.Size(270, 72);
            this.gbxDepartment.TabIndex = 1;
            this.gbxDepartment.TabStop = false;
            this.gbxDepartment.Text = " DEPARTMENT ";
            // 
            // cboDepartment
            // 
            this.cboDepartment.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(15, 31);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(239, 23);
            this.cboDepartment.TabIndex = 0;
            // 
            // gbxDescriptive
            // 
            this.gbxDescriptive.Controls.Add(this.lnkOtherInfo);
            this.gbxDescriptive.Controls.Add(this.txtTitle);
            this.gbxDescriptive.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxDescriptive.ForeColor = System.Drawing.Color.Navy;
            this.gbxDescriptive.Location = new System.Drawing.Point(11, 296);
            this.gbxDescriptive.Name = "gbxDescriptive";
            this.gbxDescriptive.Size = new System.Drawing.Size(546, 72);
            this.gbxDescriptive.TabIndex = 4;
            this.gbxDescriptive.TabStop = false;
            this.gbxDescriptive.Text = " DESCRIPTIVE TITLE ";
            // 
            // lnkOtherInfo
            // 
            this.lnkOtherInfo.AutoSize = true;
            this.lnkOtherInfo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkOtherInfo.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkOtherInfo.Location = new System.Drawing.Point(412, 34);
            this.lnkOtherInfo.Name = "lnkOtherInfo";
            this.lnkOtherInfo.Size = new System.Drawing.Size(121, 15);
            this.lnkOtherInfo.TabIndex = 1;
            this.lnkOtherInfo.TabStop = true;
            this.lnkOtherInfo.Text = "[ Other Information ]";
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.White;
            this.txtTitle.Location = new System.Drawing.Point(15, 31);
            this.txtTitle.MaxLength = 100;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(383, 23);
            this.txtTitle.TabIndex = 0;
            this.txtTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbxSubject
            // 
            this.gbxSubject.Controls.Add(this.txtCode);
            this.gbxSubject.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxSubject.ForeColor = System.Drawing.Color.Navy;
            this.gbxSubject.Location = new System.Drawing.Point(11, 218);
            this.gbxSubject.Name = "gbxSubject";
            this.gbxSubject.Size = new System.Drawing.Size(270, 72);
            this.gbxSubject.TabIndex = 2;
            this.gbxSubject.TabStop = false;
            this.gbxSubject.Text = " SERVICE CODE ";
            // 
            // txtCode
            // 
            this.txtCode.BackColor = System.Drawing.Color.White;
            this.txtCode.Location = new System.Drawing.Point(15, 31);
            this.txtCode.MaxLength = 50;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(239, 23);
            this.txtCode.TabIndex = 0;
            this.txtCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbxCourseGroup
            // 
            this.gbxCourseGroup.Controls.Add(this.cboCourseGroup);
            this.gbxCourseGroup.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxCourseGroup.ForeColor = System.Drawing.Color.Navy;
            this.gbxCourseGroup.Location = new System.Drawing.Point(287, 62);
            this.gbxCourseGroup.Name = "gbxCourseGroup";
            this.gbxCourseGroup.Size = new System.Drawing.Size(270, 72);
            this.gbxCourseGroup.TabIndex = 0;
            this.gbxCourseGroup.TabStop = false;
            this.gbxCourseGroup.Text = " COURSE GROUP ";
            // 
            // cboCourseGroup
            // 
            this.cboCourseGroup.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cboCourseGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCourseGroup.FormattingEnabled = true;
            this.cboCourseGroup.Location = new System.Drawing.Point(15, 29);
            this.cboCourseGroup.Name = "cboCourseGroup";
            this.cboCourseGroup.Size = new System.Drawing.Size(236, 23);
            this.cboCourseGroup.TabIndex = 0;
            // 
            // gbxSysID
            // 
            this.gbxSysID.Controls.Add(this.lblSysID);
            this.gbxSysID.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxSysID.ForeColor = System.Drawing.Color.Navy;
            this.gbxSysID.Location = new System.Drawing.Point(11, 62);
            this.gbxSysID.Name = "gbxSysID";
            this.gbxSysID.Size = new System.Drawing.Size(270, 72);
            this.gbxSysID.TabIndex = 19;
            this.gbxSysID.TabStop = false;
            this.gbxSysID.Text = " SYSTEM ID ";
            // 
            // lblSysID
            // 
            this.lblSysID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSysID.ForeColor = System.Drawing.Color.Black;
            this.lblSysID.Location = new System.Drawing.Point(6, 31);
            this.lblSysID.Name = "lblSysID";
            this.lblSysID.Size = new System.Drawing.Size(258, 18);
            this.lblSysID.TabIndex = 1;
            this.lblSysID.Text = "Processing...";
            this.lblSysID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Location = new System.Drawing.Point(-3, 374);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(575, 40);
            this.panel2.TabIndex = 20;
            // 
            // hrmHours
            // 
            this.hrmHours.Location = new System.Drawing.Point(345, 242);
            this.hrmHours.Name = "hrmHours";
            this.hrmHours.Size = new System.Drawing.Size(105, 30);
            this.hrmHours.TabIndex = 22;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.optHours);
            this.groupBox1.Controls.Add(this.lblHours);
            this.groupBox1.Controls.Add(this.lblLaboratory);
            this.groupBox1.Controls.Add(this.lblLecture);
            this.groupBox1.Controls.Add(this.txtLaboratory);
            this.groupBox1.Controls.Add(this.optUnits);
            this.groupBox1.Controls.Add(this.txtLecture);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(286, 140);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 150);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " UNITS/HOURS EQUIVALENT ";
            // 
            // optHours
            // 
            this.optHours.AutoSize = true;
            this.optHours.Location = new System.Drawing.Point(31, 86);
            this.optHours.Name = "optHours";
            this.optHours.Size = new System.Drawing.Size(70, 19);
            this.optHours.TabIndex = 3;
            this.optHours.Text = "In Hours";
            this.optHours.UseVisualStyleBackColor = true;
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHours.ForeColor = System.Drawing.Color.Black;
            this.lblHours.Location = new System.Drawing.Point(164, 119);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(90, 15);
            this.lblHours.TabIndex = 6;
            this.lblHours.Text = "Hours/Minutes";
            // 
            // lblLaboratory
            // 
            this.lblLaboratory.AutoSize = true;
            this.lblLaboratory.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLaboratory.ForeColor = System.Drawing.Color.Black;
            this.lblLaboratory.Location = new System.Drawing.Point(164, 62);
            this.lblLaboratory.Name = "lblLaboratory";
            this.lblLaboratory.Size = new System.Drawing.Size(96, 15);
            this.lblLaboratory.TabIndex = 5;
            this.lblLaboratory.Text = "Laboratory / RLE";
            // 
            // lblLecture
            // 
            this.lblLecture.AutoSize = true;
            this.lblLecture.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLecture.ForeColor = System.Drawing.Color.Black;
            this.lblLecture.Location = new System.Drawing.Point(164, 36);
            this.lblLecture.Name = "lblLecture";
            this.lblLecture.Size = new System.Drawing.Size(46, 15);
            this.lblLecture.TabIndex = 4;
            this.lblLecture.Text = "Lecture";
            // 
            // txtLaboratory
            // 
            this.txtLaboratory.BackColor = System.Drawing.Color.White;
            this.txtLaboratory.Location = new System.Drawing.Point(130, 60);
            this.txtLaboratory.MaxLength = 2;
            this.txtLaboratory.Name = "txtLaboratory";
            this.txtLaboratory.Size = new System.Drawing.Size(28, 23);
            this.txtLaboratory.TabIndex = 2;
            this.txtLaboratory.Text = "0";
            this.txtLaboratory.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // optUnits
            // 
            this.optUnits.AutoSize = true;
            this.optUnits.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optUnits.Location = new System.Drawing.Point(31, 32);
            this.optUnits.Name = "optUnits";
            this.optUnits.Size = new System.Drawing.Size(66, 19);
            this.optUnits.TabIndex = 0;
            this.optUnits.Text = "In Units";
            this.optUnits.UseVisualStyleBackColor = true;
            // 
            // txtLecture
            // 
            this.txtLecture.BackColor = System.Drawing.Color.White;
            this.txtLecture.Location = new System.Drawing.Point(130, 33);
            this.txtLecture.MaxLength = 2;
            this.txtLecture.Name = "txtLecture";
            this.txtLecture.Size = new System.Drawing.Size(28, 23);
            this.txtLecture.TabIndex = 1;
            this.txtLecture.Text = "0";
            this.txtLecture.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Service
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(568, 413);
            this.Controls.Add(this.hrmHours);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.gbxDepartment);
            this.Controls.Add(this.gbxDescriptive);
            this.Controls.Add(this.gbxSubject);
            this.Controls.Add(this.gbxCourseGroup);
            this.Controls.Add(this.gbxSysID);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Service";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.gbxDepartment.ResumeLayout(false);
            this.gbxDescriptive.ResumeLayout(false);
            this.gbxDescriptive.PerformLayout();
            this.gbxSubject.ResumeLayout(false);
            this.gbxSubject.PerformLayout();
            this.gbxCourseGroup.ResumeLayout(false);
            this.gbxSysID.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbxDepartment;
        protected System.Windows.Forms.ComboBox cboDepartment;
        private System.Windows.Forms.GroupBox gbxDescriptive;
        protected System.Windows.Forms.LinkLabel lnkOtherInfo;
        protected System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.GroupBox gbxSubject;
        protected System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.GroupBox gbxCourseGroup;
        protected System.Windows.Forms.ComboBox cboCourseGroup;
        private System.Windows.Forms.GroupBox gbxSysID;
        protected System.Windows.Forms.Label lblSysID;
        protected System.Windows.Forms.Panel panel2;
        protected RemoteClient.HourMinute hrmHours;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.Label lblLaboratory;
        private System.Windows.Forms.Label lblLecture;
        protected System.Windows.Forms.RadioButton optHours;
        protected System.Windows.Forms.TextBox txtLaboratory;
        protected System.Windows.Forms.RadioButton optUnits;
        protected System.Windows.Forms.TextBox txtLecture;
    }
}