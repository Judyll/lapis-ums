namespace FinanceServices
{
    partial class FeeRegisterDetailedReportControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeeRegisterDetailedReportControl));
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboSemester = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.gbxScholarship = new System.Windows.Forms.GroupBox();
            this.lnkYearLevelAll = new System.Windows.Forms.LinkLabel();
            this.lnkYearLevelNone = new System.Windows.Forms.LinkLabel();
            this.lblYearLevelCount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxYearLevel = new System.Windows.Forms.CheckedListBox();
            this.gbxCourse = new System.Windows.Forms.GroupBox();
            this.lnkCourseAll = new System.Windows.Forms.LinkLabel();
            this.lnkCourseNone = new System.Windows.Forms.LinkLabel();
            this.lblCourseCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxCourse = new System.Windows.Forms.CheckedListBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbxScholarship.SuspendLayout();
            this.gbxCourse.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(10, 290);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(635, 23);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 92;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(179)))), ((int)(((byte)(133)))));
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnGenerateReport);
            this.panel2.Location = new System.Drawing.Point(-2, 322);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(665, 35);
            this.panel2.TabIndex = 91;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(560, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 24);
            this.btnClose.TabIndex = 103;
            this.btnClose.Text = "Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnGenerateReport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGenerateReport.Enabled = false;
            this.btnGenerateReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateReport.Location = new System.Drawing.Point(414, 6);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(140, 24);
            this.btnGenerateReport.TabIndex = 102;
            this.btnGenerateReport.Text = "Generate Report";
            this.btnGenerateReport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGenerateReport.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.Controls.Add(this.cboYear);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.cboSemester);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Location = new System.Drawing.Point(-2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(665, 75);
            this.panel1.TabIndex = 90;
            // 
            // cboYear
            // 
            this.cboYear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboYear.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYear.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(424, 6);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(223, 27);
            this.cboYear.TabIndex = 11;
            // 
            // label9
            // 
            this.label9.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(332, 43);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(76, 19);
            this.label9.TabIndex = 14;
            this.label9.Text = "Semester:";
            // 
            // cboSemester
            // 
            this.cboSemester.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cboSemester.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cboSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSemester.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSemester.FormattingEnabled = true;
            this.cboSemester.Location = new System.Drawing.Point(424, 40);
            this.cboSemester.Name = "cboSemester";
            this.cboSemester.Size = new System.Drawing.Size(223, 27);
            this.cboSemester.TabIndex = 12;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(315, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(93, 19);
            this.label10.TabIndex = 13;
            this.label10.Text = "School Year:";
            // 
            // gbxScholarship
            // 
            this.gbxScholarship.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbxScholarship.Controls.Add(this.lnkYearLevelAll);
            this.gbxScholarship.Controls.Add(this.lnkYearLevelNone);
            this.gbxScholarship.Controls.Add(this.lblYearLevelCount);
            this.gbxScholarship.Controls.Add(this.label6);
            this.gbxScholarship.Controls.Add(this.cbxYearLevel);
            this.gbxScholarship.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxScholarship.Location = new System.Drawing.Point(330, 83);
            this.gbxScholarship.Name = "gbxScholarship";
            this.gbxScholarship.Size = new System.Drawing.Size(315, 199);
            this.gbxScholarship.TabIndex = 89;
            this.gbxScholarship.TabStop = false;
            this.gbxScholarship.Text = "Query by Year Level";
            // 
            // lnkYearLevelAll
            // 
            this.lnkYearLevelAll.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lnkYearLevelAll.AutoSize = true;
            this.lnkYearLevelAll.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkYearLevelAll.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkYearLevelAll.LinkColor = System.Drawing.Color.DarkBlue;
            this.lnkYearLevelAll.Location = new System.Drawing.Point(149, 172);
            this.lnkYearLevelAll.Name = "lnkYearLevelAll";
            this.lnkYearLevelAll.Size = new System.Drawing.Size(70, 14);
            this.lnkYearLevelAll.TabIndex = 26;
            this.lnkYearLevelAll.TabStop = true;
            this.lnkYearLevelAll.Text = "| Select All |";
            // 
            // lnkYearLevelNone
            // 
            this.lnkYearLevelNone.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lnkYearLevelNone.AutoSize = true;
            this.lnkYearLevelNone.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkYearLevelNone.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkYearLevelNone.LinkColor = System.Drawing.Color.DarkBlue;
            this.lnkYearLevelNone.Location = new System.Drawing.Point(225, 172);
            this.lnkYearLevelNone.Name = "lnkYearLevelNone";
            this.lnkYearLevelNone.Size = new System.Drawing.Size(84, 14);
            this.lnkYearLevelNone.TabIndex = 13;
            this.lnkYearLevelNone.TabStop = true;
            this.lnkYearLevelNone.Text = "| Select None |";
            // 
            // lblYearLevelCount
            // 
            this.lblYearLevelCount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblYearLevelCount.AutoSize = true;
            this.lblYearLevelCount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYearLevelCount.ForeColor = System.Drawing.Color.Red;
            this.lblYearLevelCount.Location = new System.Drawing.Point(62, 172);
            this.lblYearLevelCount.Name = "lblYearLevelCount";
            this.lblYearLevelCount.Size = new System.Drawing.Size(18, 19);
            this.lblYearLevelCount.TabIndex = 12;
            this.lblYearLevelCount.Text = "0";
            this.lblYearLevelCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkBlue;
            this.label6.Location = new System.Drawing.Point(6, 175);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 14);
            this.label6.TabIndex = 11;
            this.label6.Text = "Selected:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxYearLevel
            // 
            this.cbxYearLevel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbxYearLevel.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cbxYearLevel.CheckOnClick = true;
            this.cbxYearLevel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxYearLevel.FormattingEnabled = true;
            this.cbxYearLevel.HorizontalScrollbar = true;
            this.cbxYearLevel.Location = new System.Drawing.Point(6, 16);
            this.cbxYearLevel.Name = "cbxYearLevel";
            this.cbxYearLevel.Size = new System.Drawing.Size(303, 148);
            this.cbxYearLevel.TabIndex = 3;
            this.cbxYearLevel.ThreeDCheckBoxes = true;
            // 
            // gbxCourse
            // 
            this.gbxCourse.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbxCourse.Controls.Add(this.lnkCourseAll);
            this.gbxCourse.Controls.Add(this.lnkCourseNone);
            this.gbxCourse.Controls.Add(this.lblCourseCount);
            this.gbxCourse.Controls.Add(this.label1);
            this.gbxCourse.Controls.Add(this.cbxCourse);
            this.gbxCourse.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxCourse.Location = new System.Drawing.Point(10, 83);
            this.gbxCourse.Name = "gbxCourse";
            this.gbxCourse.Size = new System.Drawing.Size(315, 199);
            this.gbxCourse.TabIndex = 88;
            this.gbxCourse.TabStop = false;
            this.gbxCourse.Text = "Query by Course";
            // 
            // lnkCourseAll
            // 
            this.lnkCourseAll.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lnkCourseAll.AutoSize = true;
            this.lnkCourseAll.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCourseAll.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkCourseAll.LinkColor = System.Drawing.Color.DarkBlue;
            this.lnkCourseAll.Location = new System.Drawing.Point(149, 172);
            this.lnkCourseAll.Name = "lnkCourseAll";
            this.lnkCourseAll.Size = new System.Drawing.Size(70, 14);
            this.lnkCourseAll.TabIndex = 26;
            this.lnkCourseAll.TabStop = true;
            this.lnkCourseAll.Text = "| Select All |";
            // 
            // lnkCourseNone
            // 
            this.lnkCourseNone.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lnkCourseNone.AutoSize = true;
            this.lnkCourseNone.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCourseNone.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkCourseNone.LinkColor = System.Drawing.Color.DarkBlue;
            this.lnkCourseNone.Location = new System.Drawing.Point(225, 172);
            this.lnkCourseNone.Name = "lnkCourseNone";
            this.lnkCourseNone.Size = new System.Drawing.Size(84, 14);
            this.lnkCourseNone.TabIndex = 13;
            this.lnkCourseNone.TabStop = true;
            this.lnkCourseNone.Text = "| Select None |";
            // 
            // lblCourseCount
            // 
            this.lblCourseCount.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblCourseCount.AutoSize = true;
            this.lblCourseCount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourseCount.ForeColor = System.Drawing.Color.Red;
            this.lblCourseCount.Location = new System.Drawing.Point(64, 169);
            this.lblCourseCount.Name = "lblCourseCount";
            this.lblCourseCount.Size = new System.Drawing.Size(18, 19);
            this.lblCourseCount.TabIndex = 12;
            this.lblCourseCount.Text = "0";
            this.lblCourseCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(8, 172);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 14);
            this.label1.TabIndex = 11;
            this.label1.Text = "Selected:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxCourse
            // 
            this.cbxCourse.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbxCourse.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cbxCourse.CheckOnClick = true;
            this.cbxCourse.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCourse.FormattingEnabled = true;
            this.cbxCourse.HorizontalScrollbar = true;
            this.cbxCourse.Location = new System.Drawing.Point(6, 17);
            this.cbxCourse.Name = "cbxCourse";
            this.cbxCourse.Size = new System.Drawing.Size(303, 148);
            this.cbxCourse.TabIndex = 3;
            this.cbxCourse.ThreeDCheckBoxes = true;
            // 
            // FeeRegisterDetailedReportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(661, 356);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gbxScholarship);
            this.Controls.Add(this.gbxCourse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FeeRegisterDetailedReportControl";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbxScholarship.ResumeLayout(false);
            this.gbxScholarship.PerformLayout();
            this.gbxCourse.ResumeLayout(false);
            this.gbxCourse.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        protected System.Windows.Forms.GroupBox gbxScholarship;
        protected System.Windows.Forms.LinkLabel lnkYearLevelAll;
        protected System.Windows.Forms.LinkLabel lnkYearLevelNone;
        protected System.Windows.Forms.Label lblYearLevelCount;
        protected System.Windows.Forms.Label label6;
        protected System.Windows.Forms.CheckedListBox cbxYearLevel;
        protected System.Windows.Forms.GroupBox gbxCourse;
        protected System.Windows.Forms.LinkLabel lnkCourseAll;
        protected System.Windows.Forms.LinkLabel lnkCourseNone;
        protected System.Windows.Forms.Label lblCourseCount;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.CheckedListBox cbxCourse;
        protected System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnGenerateReport;
        protected System.Windows.Forms.ProgressBar progressBar;
        protected System.Windows.Forms.ComboBox cboYear;
        protected System.Windows.Forms.ComboBox cboSemester;
        protected System.Windows.Forms.Panel panel1;
    }
}