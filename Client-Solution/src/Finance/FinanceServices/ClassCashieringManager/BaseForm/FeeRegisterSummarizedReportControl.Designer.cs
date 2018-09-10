namespace FinanceServices
{
    partial class FeeRegisterSummarizedReportControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeeRegisterSummarizedReportControl));
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboSemester = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.gbxCourse = new System.Windows.Forms.GroupBox();
            this.lnkCourseGroupAll = new System.Windows.Forms.LinkLabel();
            this.lnkCourseGroupNone = new System.Windows.Forms.LinkLabel();
            this.lblCourseCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxCourseGroup = new System.Windows.Forms.CheckedListBox();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbxCourse.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(9, 289);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(635, 23);
            this.progressBar.Step = 1;
            this.progressBar.TabIndex = 96;
            // 
            // panel2
            // 
            this.panel2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(179)))), ((int)(((byte)(133)))));
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Controls.Add(this.btnGenerateReport);
            this.panel2.Location = new System.Drawing.Point(-2, 321);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(665, 35);
            this.panel2.TabIndex = 95;
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
            this.panel1.Location = new System.Drawing.Point(-2, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(665, 75);
            this.panel1.TabIndex = 94;
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
            // gbxCourse
            // 
            this.gbxCourse.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.gbxCourse.Controls.Add(this.lnkCourseGroupAll);
            this.gbxCourse.Controls.Add(this.lnkCourseGroupNone);
            this.gbxCourse.Controls.Add(this.lblCourseCount);
            this.gbxCourse.Controls.Add(this.label1);
            this.gbxCourse.Controls.Add(this.cbxCourseGroup);
            this.gbxCourse.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxCourse.Location = new System.Drawing.Point(329, 84);
            this.gbxCourse.Name = "gbxCourse";
            this.gbxCourse.Size = new System.Drawing.Size(315, 199);
            this.gbxCourse.TabIndex = 93;
            this.gbxCourse.TabStop = false;
            this.gbxCourse.Text = "Query by Course Group";
            // 
            // lnkCourseGroupAll
            // 
            this.lnkCourseGroupAll.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lnkCourseGroupAll.AutoSize = true;
            this.lnkCourseGroupAll.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCourseGroupAll.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkCourseGroupAll.LinkColor = System.Drawing.Color.DarkBlue;
            this.lnkCourseGroupAll.Location = new System.Drawing.Point(149, 172);
            this.lnkCourseGroupAll.Name = "lnkCourseGroupAll";
            this.lnkCourseGroupAll.Size = new System.Drawing.Size(70, 14);
            this.lnkCourseGroupAll.TabIndex = 26;
            this.lnkCourseGroupAll.TabStop = true;
            this.lnkCourseGroupAll.Text = "| Select All |";
            // 
            // lnkCourseGroupNone
            // 
            this.lnkCourseGroupNone.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lnkCourseGroupNone.AutoSize = true;
            this.lnkCourseGroupNone.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCourseGroupNone.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkCourseGroupNone.LinkColor = System.Drawing.Color.DarkBlue;
            this.lnkCourseGroupNone.Location = new System.Drawing.Point(225, 172);
            this.lnkCourseGroupNone.Name = "lnkCourseGroupNone";
            this.lnkCourseGroupNone.Size = new System.Drawing.Size(84, 14);
            this.lnkCourseGroupNone.TabIndex = 13;
            this.lnkCourseGroupNone.TabStop = true;
            this.lnkCourseGroupNone.Text = "| Select None |";
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
            // cbxCourseGroup
            // 
            this.cbxCourseGroup.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.cbxCourseGroup.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cbxCourseGroup.CheckOnClick = true;
            this.cbxCourseGroup.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCourseGroup.FormattingEnabled = true;
            this.cbxCourseGroup.HorizontalScrollbar = true;
            this.cbxCourseGroup.Location = new System.Drawing.Point(6, 17);
            this.cbxCourseGroup.Name = "cbxCourseGroup";
            this.cbxCourseGroup.Size = new System.Drawing.Size(303, 148);
            this.cbxCourseGroup.TabIndex = 3;
            this.cbxCourseGroup.ThreeDCheckBoxes = true;
            // 
            // FeeRegisterSummarizedReportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(661, 356);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gbxCourse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FeeRegisterSummarizedReportControl";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbxCourse.ResumeLayout(false);
            this.gbxCourse.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        protected System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnGenerateReport;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cboYear;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboSemester;
        private System.Windows.Forms.Label label10;
        protected System.Windows.Forms.GroupBox gbxCourse;
        protected System.Windows.Forms.LinkLabel lnkCourseGroupAll;
        protected System.Windows.Forms.LinkLabel lnkCourseGroupNone;
        protected System.Windows.Forms.Label lblCourseCount;
        protected System.Windows.Forms.Label label1;
        protected System.Windows.Forms.CheckedListBox cbxCourseGroup;
    }
}