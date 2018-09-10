using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RemoteClient
{
    public partial class ControlMajorExamScheduleManager : ControlManager
    {
        protected GroupBox groupBox3;
        private Label label2;
        private ComboBox cboSemester;
        private Label label4;
        protected GroupBox gbxCourseGroup;
        protected LinkLabel lnkCourseGroupNone;
        protected Label lblCourseGroupCount;
        protected Label label1;
        protected CheckedListBox cbxCourseGroup;
        protected GroupBox gbxExam;
        protected LinkLabel lnkExamNone;
        protected Label lblExamCount;
        protected Label label3;
        protected CheckedListBox cbxExam;
        protected LinkLabel lnkResetQuery;
        private ComboBox cboYear;
    
        private void InitializeComponent()
        {
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboSemester = new System.Windows.Forms.ComboBox();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gbxCourseGroup = new System.Windows.Forms.GroupBox();
            this.lnkCourseGroupNone = new System.Windows.Forms.LinkLabel();
            this.lblCourseGroupCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxCourseGroup = new System.Windows.Forms.CheckedListBox();
            this.gbxExam = new System.Windows.Forms.GroupBox();
            this.lnkExamNone = new System.Windows.Forms.LinkLabel();
            this.lblExamCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxExam = new System.Windows.Forms.CheckedListBox();
            this.lnkResetQuery = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRefresh)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.gbxCourseGroup.SuspendLayout();
            this.gbxExam.SuspendLayout();
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
            this.pbxFind.Visible = false;
            // 
            // pbxClose
            // 
            this.ttpMain.SetToolTip(this.pbxClose, "Done");
            // 
            // pbxRefresh
            // 
            this.ttpMain.SetToolTip(this.pbxRefresh, "Refresh");
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.lnkResetQuery);
            this.pnlMain.Controls.Add(this.gbxExam);
            this.pnlMain.Controls.Add(this.gbxCourseGroup);
            this.pnlMain.Controls.Add(this.groupBox3);
            this.pnlMain.Size = new System.Drawing.Size(255, 580);
            this.pnlMain.Controls.SetChildIndex(this.pbxFind, 0);
            this.pnlMain.Controls.SetChildIndex(this.txtSearch, 0);
            this.pnlMain.Controls.SetChildIndex(this.groupBox3, 0);
            this.pnlMain.Controls.SetChildIndex(this.gbxCourseGroup, 0);
            this.pnlMain.Controls.SetChildIndex(this.gbxExam, 0);
            this.pnlMain.Controls.SetChildIndex(this.lnkResetQuery, 0);
            this.pnlMain.Controls.SetChildIndex(this.pbxRefresh, 0);
            this.pnlMain.Controls.SetChildIndex(this.pbxClose, 0);
            this.pnlMain.Controls.SetChildIndex(this.pnlHeader, 0);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.cboSemester);
            this.groupBox3.Controls.Add(this.cboYear);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(8, 82);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(238, 114);
            this.groupBox3.TabIndex = 25;
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
            // gbxCourseGroup
            // 
            this.gbxCourseGroup.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.gbxCourseGroup.Controls.Add(this.lnkCourseGroupNone);
            this.gbxCourseGroup.Controls.Add(this.lblCourseGroupCount);
            this.gbxCourseGroup.Controls.Add(this.label1);
            this.gbxCourseGroup.Controls.Add(this.cbxCourseGroup);
            this.gbxCourseGroup.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxCourseGroup.Location = new System.Drawing.Point(8, 202);
            this.gbxCourseGroup.Name = "gbxCourseGroup";
            this.gbxCourseGroup.Size = new System.Drawing.Size(238, 154);
            this.gbxCourseGroup.TabIndex = 26;
            this.gbxCourseGroup.TabStop = false;
            this.gbxCourseGroup.Text = "Query by Course Group";
            // 
            // lnkCourseGroupNone
            // 
            this.lnkCourseGroupNone.AutoSize = true;
            this.lnkCourseGroupNone.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCourseGroupNone.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkCourseGroupNone.LinkColor = System.Drawing.Color.DarkBlue;
            this.lnkCourseGroupNone.Location = new System.Drawing.Point(152, 134);
            this.lnkCourseGroupNone.Name = "lnkCourseGroupNone";
            this.lnkCourseGroupNone.Size = new System.Drawing.Size(84, 14);
            this.lnkCourseGroupNone.TabIndex = 13;
            this.lnkCourseGroupNone.TabStop = true;
            this.lnkCourseGroupNone.Text = "| Select None |";
            // 
            // lblCourseGroupCount
            // 
            this.lblCourseGroupCount.AutoSize = true;
            this.lblCourseGroupCount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCourseGroupCount.ForeColor = System.Drawing.Color.Red;
            this.lblCourseGroupCount.Location = new System.Drawing.Point(62, 131);
            this.lblCourseGroupCount.Name = "lblCourseGroupCount";
            this.lblCourseGroupCount.Size = new System.Drawing.Size(18, 19);
            this.lblCourseGroupCount.TabIndex = 12;
            this.lblCourseGroupCount.Text = "0";
            this.lblCourseGroupCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(6, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 14);
            this.label1.TabIndex = 11;
            this.label1.Text = "Selected:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxCourseGroup
            // 
            this.cbxCourseGroup.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cbxCourseGroup.CheckOnClick = true;
            this.cbxCourseGroup.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxCourseGroup.FormattingEnabled = true;
            this.cbxCourseGroup.HorizontalScrollbar = true;
            this.cbxCourseGroup.Location = new System.Drawing.Point(6, 17);
            this.cbxCourseGroup.Name = "cbxCourseGroup";
            this.cbxCourseGroup.Size = new System.Drawing.Size(226, 112);
            this.cbxCourseGroup.TabIndex = 3;
            this.cbxCourseGroup.ThreeDCheckBoxes = true;
            // 
            // gbxExam
            // 
            this.gbxExam.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.gbxExam.Controls.Add(this.lnkExamNone);
            this.gbxExam.Controls.Add(this.lblExamCount);
            this.gbxExam.Controls.Add(this.label3);
            this.gbxExam.Controls.Add(this.cbxExam);
            this.gbxExam.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxExam.Location = new System.Drawing.Point(9, 362);
            this.gbxExam.Name = "gbxExam";
            this.gbxExam.Size = new System.Drawing.Size(238, 188);
            this.gbxExam.TabIndex = 27;
            this.gbxExam.TabStop = false;
            this.gbxExam.Text = "Query by Exam Information";
            // 
            // lnkExamNone
            // 
            this.lnkExamNone.AutoSize = true;
            this.lnkExamNone.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkExamNone.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkExamNone.LinkColor = System.Drawing.Color.DarkBlue;
            this.lnkExamNone.Location = new System.Drawing.Point(152, 169);
            this.lnkExamNone.Name = "lnkExamNone";
            this.lnkExamNone.Size = new System.Drawing.Size(84, 14);
            this.lnkExamNone.TabIndex = 13;
            this.lnkExamNone.TabStop = true;
            this.lnkExamNone.Text = "| Select None |";
            // 
            // lblExamCount
            // 
            this.lblExamCount.AutoSize = true;
            this.lblExamCount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExamCount.ForeColor = System.Drawing.Color.Red;
            this.lblExamCount.Location = new System.Drawing.Point(62, 166);
            this.lblExamCount.Name = "lblExamCount";
            this.lblExamCount.Size = new System.Drawing.Size(18, 19);
            this.lblExamCount.TabIndex = 12;
            this.lblExamCount.Text = "0";
            this.lblExamCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DarkBlue;
            this.label3.Location = new System.Drawing.Point(6, 169);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 14);
            this.label3.TabIndex = 11;
            this.label3.Text = "Selected:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxExam
            // 
            this.cbxExam.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cbxExam.CheckOnClick = true;
            this.cbxExam.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxExam.FormattingEnabled = true;
            this.cbxExam.HorizontalScrollbar = true;
            this.cbxExam.Location = new System.Drawing.Point(6, 16);
            this.cbxExam.Name = "cbxExam";
            this.cbxExam.Size = new System.Drawing.Size(226, 148);
            this.cbxExam.TabIndex = 3;
            this.cbxExam.ThreeDCheckBoxes = true;
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
            this.lnkResetQuery.TabIndex = 28;
            this.lnkResetQuery.TabStop = true;
            this.lnkResetQuery.Text = "| RESET QUERY |";
            // 
            // ControlMajorExamScheduleManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "ControlMajorExamScheduleManager";
            this.Size = new System.Drawing.Size(255, 580);
            ((System.ComponentModel.ISupportInitialize)(this.pbxFind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRefresh)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.gbxCourseGroup.ResumeLayout(false);
            this.gbxCourseGroup.PerformLayout();
            this.gbxExam.ResumeLayout(false);
            this.gbxExam.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
