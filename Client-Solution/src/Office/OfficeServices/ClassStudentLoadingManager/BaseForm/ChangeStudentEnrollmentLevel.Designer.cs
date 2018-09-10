namespace OfficeServices
{
    partial class ChangeStudentEnrollmentLevel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeStudentEnrollmentLevel));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblSchoolYearSemester = new System.Windows.Forms.Label();
            this.lblSysIdCourse = new System.Windows.Forms.Label();
            this.lblDepartmentName = new System.Windows.Forms.Label();
            this.lblCourseTitle = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cboYearLevel = new System.Windows.Forms.ComboBox();
            this.gbxSysID = new System.Windows.Forms.GroupBox();
            this.lblCurrentYearLevel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbxSysID.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.Color.Transparent;
            this.groupBox4.Controls.Add(this.lblSchoolYearSemester);
            this.groupBox4.Controls.Add(this.lblSysIdCourse);
            this.groupBox4.Controls.Add(this.lblDepartmentName);
            this.groupBox4.Controls.Add(this.lblCourseTitle);
            this.groupBox4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.Navy;
            this.groupBox4.Location = new System.Drawing.Point(10, 64);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(509, 124);
            this.groupBox4.TabIndex = 98;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = " COURSE INFORMATION ";
            // 
            // lblSchoolYearSemester
            // 
            this.lblSchoolYearSemester.AutoSize = true;
            this.lblSchoolYearSemester.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSchoolYearSemester.ForeColor = System.Drawing.Color.DimGray;
            this.lblSchoolYearSemester.Location = new System.Drawing.Point(18, 95);
            this.lblSchoolYearSemester.Name = "lblSchoolYearSemester";
            this.lblSchoolYearSemester.Size = new System.Drawing.Size(18, 16);
            this.lblSchoolYearSemester.TabIndex = 22;
            this.lblSchoolYearSemester.Text = "--";
            // 
            // lblSysIdCourse
            // 
            this.lblSysIdCourse.AutoSize = true;
            this.lblSysIdCourse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSysIdCourse.ForeColor = System.Drawing.Color.Black;
            this.lblSysIdCourse.Location = new System.Drawing.Point(18, 24);
            this.lblSysIdCourse.Name = "lblSysIdCourse";
            this.lblSysIdCourse.Size = new System.Drawing.Size(16, 16);
            this.lblSysIdCourse.TabIndex = 18;
            this.lblSysIdCourse.Text = "--";
            // 
            // lblDepartmentName
            // 
            this.lblDepartmentName.AutoSize = true;
            this.lblDepartmentName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartmentName.ForeColor = System.Drawing.Color.DimGray;
            this.lblDepartmentName.Location = new System.Drawing.Point(18, 74);
            this.lblDepartmentName.Name = "lblDepartmentName";
            this.lblDepartmentName.Size = new System.Drawing.Size(18, 16);
            this.lblDepartmentName.TabIndex = 21;
            this.lblDepartmentName.Text = "--";
            // 
            // lblCourseTitle
            // 
            this.lblCourseTitle.AutoSize = true;
            this.lblCourseTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourseTitle.ForeColor = System.Drawing.Color.Black;
            this.lblCourseTitle.Location = new System.Drawing.Point(18, 48);
            this.lblCourseTitle.Name = "lblCourseTitle";
            this.lblCourseTitle.Size = new System.Drawing.Size(180, 18);
            this.lblCourseTitle.TabIndex = 19;
            this.lblCourseTitle.Text = "Please select a course";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cboYearLevel);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(10, 263);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(509, 104);
            this.groupBox2.TabIndex = 97;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " CHANGE TO ";
            // 
            // cboYearLevel
            // 
            this.cboYearLevel.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cboYearLevel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYearLevel.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboYearLevel.FormattingEnabled = true;
            this.cboYearLevel.Location = new System.Drawing.Point(9, 33);
            this.cboYearLevel.Name = "cboYearLevel";
            this.cboYearLevel.Size = new System.Drawing.Size(494, 47);
            this.cboYearLevel.TabIndex = 0;
            // 
            // gbxSysID
            // 
            this.gbxSysID.Controls.Add(this.lblCurrentYearLevel);
            this.gbxSysID.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxSysID.ForeColor = System.Drawing.Color.Navy;
            this.gbxSysID.Location = new System.Drawing.Point(10, 194);
            this.gbxSysID.Name = "gbxSysID";
            this.gbxSysID.Size = new System.Drawing.Size(509, 63);
            this.gbxSysID.TabIndex = 96;
            this.gbxSysID.TabStop = false;
            this.gbxSysID.Text = " CURRENT YEAR LEVEL ";
            // 
            // lblCurrentYearLevel
            // 
            this.lblCurrentYearLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentYearLevel.ForeColor = System.Drawing.Color.Black;
            this.lblCurrentYearLevel.Location = new System.Drawing.Point(6, 17);
            this.lblCurrentYearLevel.Name = "lblCurrentYearLevel";
            this.lblCurrentYearLevel.Size = new System.Drawing.Size(497, 38);
            this.lblCurrentYearLevel.TabIndex = 1;
            this.lblCurrentYearLevel.Text = "-";
            this.lblCurrentYearLevel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(179)))), ((int)(((byte)(133)))));
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnUpdate);
            this.panel2.Location = new System.Drawing.Point(-2, 385);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(539, 35);
            this.panel2.TabIndex = 95;
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(435, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 23);
            this.btnClose.TabIndex = 97;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUpdate.BackgroundImage")));
            this.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnUpdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.Location = new System.Drawing.Point(343, 7);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(86, 23);
            this.btnUpdate.TabIndex = 96;
            this.btnUpdate.Text = "  Update";
            this.btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Location = new System.Drawing.Point(-2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(539, 58);
            this.panel1.TabIndex = 94;
            // 
            // ChangeStudentEnrollmentLevel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(535, 420);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbxSysID);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChangeStudentEnrollmentLevel";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.gbxSysID.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.GroupBox groupBox4;
        protected System.Windows.Forms.Label lblSchoolYearSemester;
        protected System.Windows.Forms.Label lblSysIdCourse;
        protected System.Windows.Forms.Label lblDepartmentName;
        protected System.Windows.Forms.Label lblCourseTitle;
        protected System.Windows.Forms.GroupBox groupBox2;
        protected System.Windows.Forms.ComboBox cboYearLevel;
        protected System.Windows.Forms.GroupBox gbxSysID;
        protected System.Windows.Forms.Label lblCurrentYearLevel;
        protected System.Windows.Forms.Panel panel2;
        protected System.Windows.Forms.Button btnClose;
        protected System.Windows.Forms.Button btnUpdate;
        protected System.Windows.Forms.Panel panel1;
    }
}