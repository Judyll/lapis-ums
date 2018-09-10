using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RemoteClient
{
    public partial class ControlStudentManager : ControlManager
    {
        protected CheckedListBox cbxCourse;
        protected Label lblCourseCount;
        protected Label label1;
        protected LinkLabel lnkCourseNone;
        protected GroupBox gbxYearLevel;
        protected LinkLabel lnkYearNone;
        protected Label lblYearCount;
        protected Label label3;
        protected CheckedListBox cbxYearLevel;
        protected GroupBox groupBox3;
        private Label label2;
        private ComboBox cboSemester;
        private Label label4;
        private ComboBox cboYear;
        protected LinkLabel lnkResetQuery;
        protected GroupBox gbxCourse;
    
        private void InitializeComponent()
        {
            this.gbxCourse = new System.Windows.Forms.GroupBox();
            this.lnkCourseNone = new System.Windows.Forms.LinkLabel();
            this.lblCourseCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxCourse = new System.Windows.Forms.CheckedListBox();
            this.gbxYearLevel = new System.Windows.Forms.GroupBox();
            this.lnkYearNone = new System.Windows.Forms.LinkLabel();
            this.lblYearCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxYearLevel = new System.Windows.Forms.CheckedListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboSemester = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.lnkResetQuery = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRefresh)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.gbxCourse.SuspendLayout();
            this.gbxYearLevel.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // ttpMain
            // 
            this.ttpMain.AutoPopDelay = 3000;
            this.ttpMain.InitialDelay = 500;
            this.ttpMain.IsBalloon = true;
            this.ttpMain.ReshowDelay = 100;
            this.ttpMain.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpMain.ToolTipTitle = "Console";
            // 
            // pbxFind
            // 
            this.pbxFind.Location = new System.Drawing.Point(8, 77);
            // 
            // pbxClose
            // 
            this.pbxClose.Location = new System.Drawing.Point(214, 39);
            this.ttpMain.SetToolTip(this.pbxClose, "Close");
            // 
            // pbxRefresh
            // 
            this.pbxRefresh.Location = new System.Drawing.Point(175, 39);
            this.ttpMain.SetToolTip(this.pbxRefresh, "Refresh");
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(52, 84);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.gbxCourse);
            this.pnlMain.Controls.Add(this.gbxYearLevel);
            this.pnlMain.Controls.Add(this.groupBox3);
            this.pnlMain.Controls.Add(this.lnkResetQuery);
            this.pnlMain.Size = new System.Drawing.Size(255, 580);
            this.pnlMain.Controls.SetChildIndex(this.txtSearch, 0);
            this.pnlMain.Controls.SetChildIndex(this.lnkResetQuery, 0);
            this.pnlMain.Controls.SetChildIndex(this.groupBox3, 0);
            this.pnlMain.Controls.SetChildIndex(this.gbxYearLevel, 0);
            this.pnlMain.Controls.SetChildIndex(this.gbxCourse, 0);
            this.pnlMain.Controls.SetChildIndex(this.pbxRefresh, 0);
            this.pnlMain.Controls.SetChildIndex(this.pbxClose, 0);
            this.pnlMain.Controls.SetChildIndex(this.pbxFind, 0);
            this.pnlMain.Controls.SetChildIndex(this.pnlHeader, 0);
            // 
            // gbxCourse
            // 
            this.gbxCourse.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.gbxCourse.Controls.Add(this.lnkCourseNone);
            this.gbxCourse.Controls.Add(this.lblCourseCount);
            this.gbxCourse.Controls.Add(this.label1);
            this.gbxCourse.Controls.Add(this.cbxCourse);
            this.gbxCourse.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxCourse.Location = new System.Drawing.Point(9, 244);
            this.gbxCourse.Name = "gbxCourse";
            this.gbxCourse.Size = new System.Drawing.Size(238, 172);
            this.gbxCourse.TabIndex = 15;
            this.gbxCourse.TabStop = false;
            this.gbxCourse.Text = "Query by Course";
            // 
            // lnkCourseNone
            // 
            this.lnkCourseNone.AutoSize = true;
            this.lnkCourseNone.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCourseNone.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkCourseNone.LinkColor = System.Drawing.Color.DarkBlue;
            this.lnkCourseNone.Location = new System.Drawing.Point(152, 152);
            this.lnkCourseNone.Name = "lnkCourseNone";
            this.lnkCourseNone.Size = new System.Drawing.Size(84, 14);
            this.lnkCourseNone.TabIndex = 13;
            this.lnkCourseNone.TabStop = true;
            this.lnkCourseNone.Text = "| Select None |";
            // 
            // lblCourseCount
            // 
            this.lblCourseCount.AutoSize = true;
            this.lblCourseCount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourseCount.ForeColor = System.Drawing.Color.Red;
            this.lblCourseCount.Location = new System.Drawing.Point(62, 149);
            this.lblCourseCount.Name = "lblCourseCount";
            this.lblCourseCount.Size = new System.Drawing.Size(18, 19);
            this.lblCourseCount.TabIndex = 12;
            this.lblCourseCount.Text = "0";
            this.lblCourseCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(6, 152);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 14);
            this.label1.TabIndex = 11;
            this.label1.Text = "Selected:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxCourse
            // 
            this.cbxCourse.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cbxCourse.CheckOnClick = true;
            this.cbxCourse.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCourse.FormattingEnabled = true;
            this.cbxCourse.HorizontalScrollbar = true;
            this.cbxCourse.Location = new System.Drawing.Point(6, 17);
            this.cbxCourse.Name = "cbxCourse";
            this.cbxCourse.Size = new System.Drawing.Size(226, 130);
            this.cbxCourse.TabIndex = 3;
            this.cbxCourse.ThreeDCheckBoxes = true;
            // 
            // gbxYearLevel
            // 
            this.gbxYearLevel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.gbxYearLevel.Controls.Add(this.lnkYearNone);
            this.gbxYearLevel.Controls.Add(this.lblYearCount);
            this.gbxYearLevel.Controls.Add(this.label3);
            this.gbxYearLevel.Controls.Add(this.cbxYearLevel);
            this.gbxYearLevel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxYearLevel.Location = new System.Drawing.Point(9, 422);
            this.gbxYearLevel.Name = "gbxYearLevel";
            this.gbxYearLevel.Size = new System.Drawing.Size(238, 134);
            this.gbxYearLevel.TabIndex = 16;
            this.gbxYearLevel.TabStop = false;
            this.gbxYearLevel.Text = "Query by Year Level";
            // 
            // lnkYearNone
            // 
            this.lnkYearNone.AutoSize = true;
            this.lnkYearNone.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkYearNone.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkYearNone.LinkColor = System.Drawing.Color.DarkBlue;
            this.lnkYearNone.Location = new System.Drawing.Point(152, 115);
            this.lnkYearNone.Name = "lnkYearNone";
            this.lnkYearNone.Size = new System.Drawing.Size(84, 14);
            this.lnkYearNone.TabIndex = 13;
            this.lnkYearNone.TabStop = true;
            this.lnkYearNone.Text = "| Select None |";
            // 
            // lblYearCount
            // 
            this.lblYearCount.AutoSize = true;
            this.lblYearCount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblYearCount.ForeColor = System.Drawing.Color.Red;
            this.lblYearCount.Location = new System.Drawing.Point(62, 112);
            this.lblYearCount.Name = "lblYearCount";
            this.lblYearCount.Size = new System.Drawing.Size(18, 19);
            this.lblYearCount.TabIndex = 12;
            this.lblYearCount.Text = "0";
            this.lblYearCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(6, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "Selected:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxYearLevel
            // 
            this.cbxYearLevel.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cbxYearLevel.CheckOnClick = true;
            this.cbxYearLevel.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxYearLevel.FormattingEnabled = true;
            this.cbxYearLevel.HorizontalScrollbar = true;
            this.cbxYearLevel.Location = new System.Drawing.Point(6, 16);
            this.cbxYearLevel.Name = "cbxYearLevel";
            this.cbxYearLevel.Size = new System.Drawing.Size(226, 94);
            this.cbxYearLevel.TabIndex = 3;
            this.cbxYearLevel.ThreeDCheckBoxes = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.cboSemester);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.cboYear);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(9, 124);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(238, 114);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Query by School Year / Semester";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(6, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Semester";
            // 
            // cboSemester
            // 
            this.cboSemester.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cboSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSemester.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSemester.FormattingEnabled = true;
            this.cboSemester.Location = new System.Drawing.Point(9, 77);
            this.cboSemester.Name = "cboSemester";
            this.cboSemester.Size = new System.Drawing.Size(223, 27);
            this.cboSemester.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(6, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "School Year";
            // 
            // cboYear
            // 
            this.cboYear.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboYear.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboYear.FormattingEnabled = true;
            this.cboYear.Location = new System.Drawing.Point(9, 29);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(223, 27);
            this.cboYear.TabIndex = 16;
            // 
            // lnkResetQuery
            // 
            this.lnkResetQuery.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lnkResetQuery.AutoSize = true;
            this.lnkResetQuery.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkResetQuery.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkResetQuery.LinkColor = System.Drawing.Color.DarkBlue;
            this.lnkResetQuery.Location = new System.Drawing.Point(82, 560);
            this.lnkResetQuery.Name = "lnkResetQuery";
            this.lnkResetQuery.Size = new System.Drawing.Size(90, 14);
            this.lnkResetQuery.TabIndex = 14;
            this.lnkResetQuery.TabStop = true;
            this.lnkResetQuery.Text = "| RESET QUERY |";
            // 
            // ControlStudentManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "ControlStudentManager";
            this.Size = new System.Drawing.Size(255, 580);
            ((System.ComponentModel.ISupportInitialize)(this.pbxFind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRefresh)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.gbxCourse.ResumeLayout(false);
            this.gbxCourse.PerformLayout();
            this.gbxYearLevel.ResumeLayout(false);
            this.gbxYearLevel.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
