using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RemoteClient
{
    public partial class ControlScholarshipManager : ControlManager
    {
        protected GroupBox gbxDepartment;
        protected LinkLabel lnkDepartmentNone;
        protected Label lblDepartmentCount;
        protected Label label1;
        protected CheckedListBox cbxDepartment;
        protected GroupBox gbxYearLevel;
        protected LinkLabel lnkYearNone;
        protected Label lblYearCount;
        protected Label label3;
        protected CheckedListBox cbxYearLevel;
        protected GroupBox gbxScholarship;
        protected LinkLabel lnkScholarshipNone;
        protected Label lblScholarshipCount;
        protected Label label6;
        protected CheckedListBox cbxScholarship;
        protected GroupBox groupBox3;
        private Label label2;
        private ComboBox cboSemester;
        private Label label4;
        private ComboBox cboYear;
        protected PictureBox pbxScholarship;
        protected LinkLabel lnkResetQuery;
    
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ControlScholarshipManager));
            this.gbxDepartment = new System.Windows.Forms.GroupBox();
            this.lnkDepartmentNone = new System.Windows.Forms.LinkLabel();
            this.lblDepartmentCount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxDepartment = new System.Windows.Forms.CheckedListBox();
            this.gbxYearLevel = new System.Windows.Forms.GroupBox();
            this.lnkYearNone = new System.Windows.Forms.LinkLabel();
            this.lblYearCount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxYearLevel = new System.Windows.Forms.CheckedListBox();
            this.lnkResetQuery = new System.Windows.Forms.LinkLabel();
            this.gbxScholarship = new System.Windows.Forms.GroupBox();
            this.lnkScholarshipNone = new System.Windows.Forms.LinkLabel();
            this.lblScholarshipCount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxScholarship = new System.Windows.Forms.CheckedListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboSemester = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.pbxScholarship = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRefresh)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.gbxDepartment.SuspendLayout();
            this.gbxYearLevel.SuspendLayout();
            this.gbxScholarship.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxScholarship)).BeginInit();
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
            this.pnlMain.Controls.Add(this.pbxScholarship);
            this.pnlMain.Controls.Add(this.groupBox3);
            this.pnlMain.Controls.Add(this.gbxScholarship);
            this.pnlMain.Controls.Add(this.lnkResetQuery);
            this.pnlMain.Controls.Add(this.gbxYearLevel);
            this.pnlMain.Controls.Add(this.gbxDepartment);
            this.pnlMain.Size = new System.Drawing.Size(255, 580);
            this.pnlMain.Controls.SetChildIndex(this.txtSearch, 0);
            this.pnlMain.Controls.SetChildIndex(this.pbxRefresh, 0);
            this.pnlMain.Controls.SetChildIndex(this.pbxClose, 0);
            this.pnlMain.Controls.SetChildIndex(this.pbxFind, 0);
            this.pnlMain.Controls.SetChildIndex(this.gbxDepartment, 0);
            this.pnlMain.Controls.SetChildIndex(this.gbxYearLevel, 0);
            this.pnlMain.Controls.SetChildIndex(this.lnkResetQuery, 0);
            this.pnlMain.Controls.SetChildIndex(this.gbxScholarship, 0);
            this.pnlMain.Controls.SetChildIndex(this.groupBox3, 0);
            this.pnlMain.Controls.SetChildIndex(this.pbxScholarship, 0);
            this.pnlMain.Controls.SetChildIndex(this.pnlHeader, 0);
            // 
            // gbxDepartment
            // 
            this.gbxDepartment.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.gbxDepartment.Controls.Add(this.lnkDepartmentNone);
            this.gbxDepartment.Controls.Add(this.lblDepartmentCount);
            this.gbxDepartment.Controls.Add(this.label1);
            this.gbxDepartment.Controls.Add(this.cbxDepartment);
            this.gbxDepartment.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxDepartment.Location = new System.Drawing.Point(9, 244);
            this.gbxDepartment.Name = "gbxDepartment";
            this.gbxDepartment.Size = new System.Drawing.Size(238, 99);
            this.gbxDepartment.TabIndex = 20;
            this.gbxDepartment.TabStop = false;
            this.gbxDepartment.Text = "Query by Department";
            // 
            // lnkDepartmentNone
            // 
            this.lnkDepartmentNone.AutoSize = true;
            this.lnkDepartmentNone.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkDepartmentNone.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkDepartmentNone.LinkColor = System.Drawing.Color.DarkBlue;
            this.lnkDepartmentNone.Location = new System.Drawing.Point(152, 80);
            this.lnkDepartmentNone.Name = "lnkDepartmentNone";
            this.lnkDepartmentNone.Size = new System.Drawing.Size(84, 14);
            this.lnkDepartmentNone.TabIndex = 13;
            this.lnkDepartmentNone.TabStop = true;
            this.lnkDepartmentNone.Text = "| Select None |";
            // 
            // lblDepartmentCount
            // 
            this.lblDepartmentCount.AutoSize = true;
            this.lblDepartmentCount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDepartmentCount.ForeColor = System.Drawing.Color.Red;
            this.lblDepartmentCount.Location = new System.Drawing.Point(62, 77);
            this.lblDepartmentCount.Name = "lblDepartmentCount";
            this.lblDepartmentCount.Size = new System.Drawing.Size(18, 19);
            this.lblDepartmentCount.TabIndex = 12;
            this.lblDepartmentCount.Text = "0";
            this.lblDepartmentCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DarkBlue;
            this.label1.Location = new System.Drawing.Point(6, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 14);
            this.label1.TabIndex = 11;
            this.label1.Text = "Selected:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxDepartment
            // 
            this.cbxDepartment.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cbxDepartment.CheckOnClick = true;
            this.cbxDepartment.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxDepartment.FormattingEnabled = true;
            this.cbxDepartment.HorizontalScrollbar = true;
            this.cbxDepartment.Location = new System.Drawing.Point(6, 17);
            this.cbxDepartment.Name = "cbxDepartment";
            this.cbxDepartment.Size = new System.Drawing.Size(226, 58);
            this.cbxDepartment.TabIndex = 3;
            this.cbxDepartment.ThreeDCheckBoxes = true;
            // 
            // gbxYearLevel
            // 
            this.gbxYearLevel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.gbxYearLevel.Controls.Add(this.lnkYearNone);
            this.gbxYearLevel.Controls.Add(this.lblYearCount);
            this.gbxYearLevel.Controls.Add(this.label3);
            this.gbxYearLevel.Controls.Add(this.cbxYearLevel);
            this.gbxYearLevel.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxYearLevel.Location = new System.Drawing.Point(8, 349);
            this.gbxYearLevel.Name = "gbxYearLevel";
            this.gbxYearLevel.Size = new System.Drawing.Size(238, 99);
            this.gbxYearLevel.TabIndex = 21;
            this.gbxYearLevel.TabStop = false;
            this.gbxYearLevel.Text = "Query by Year Level";
            // 
            // lnkYearNone
            // 
            this.lnkYearNone.AutoSize = true;
            this.lnkYearNone.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkYearNone.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkYearNone.LinkColor = System.Drawing.Color.DarkBlue;
            this.lnkYearNone.Location = new System.Drawing.Point(152, 79);
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
            this.lblYearCount.Location = new System.Drawing.Point(62, 76);
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
            this.label3.Location = new System.Drawing.Point(6, 79);
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
            this.cbxYearLevel.Size = new System.Drawing.Size(226, 58);
            this.cbxYearLevel.TabIndex = 3;
            this.cbxYearLevel.ThreeDCheckBoxes = true;
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
            this.lnkResetQuery.TabIndex = 22;
            this.lnkResetQuery.TabStop = true;
            this.lnkResetQuery.Text = "| RESET QUERY |";
            // 
            // gbxScholarship
            // 
            this.gbxScholarship.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.gbxScholarship.Controls.Add(this.lnkScholarshipNone);
            this.gbxScholarship.Controls.Add(this.lblScholarshipCount);
            this.gbxScholarship.Controls.Add(this.label6);
            this.gbxScholarship.Controls.Add(this.cbxScholarship);
            this.gbxScholarship.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxScholarship.Location = new System.Drawing.Point(9, 454);
            this.gbxScholarship.Name = "gbxScholarship";
            this.gbxScholarship.Size = new System.Drawing.Size(238, 99);
            this.gbxScholarship.TabIndex = 23;
            this.gbxScholarship.TabStop = false;
            this.gbxScholarship.Text = "Query by Scholarship";
            // 
            // lnkScholarshipNone
            // 
            this.lnkScholarshipNone.AutoSize = true;
            this.lnkScholarshipNone.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkScholarshipNone.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkScholarshipNone.LinkColor = System.Drawing.Color.DarkBlue;
            this.lnkScholarshipNone.Location = new System.Drawing.Point(152, 79);
            this.lnkScholarshipNone.Name = "lnkScholarshipNone";
            this.lnkScholarshipNone.Size = new System.Drawing.Size(84, 14);
            this.lnkScholarshipNone.TabIndex = 13;
            this.lnkScholarshipNone.TabStop = true;
            this.lnkScholarshipNone.Text = "| Select None |";
            // 
            // lblScholarshipCount
            // 
            this.lblScholarshipCount.AutoSize = true;
            this.lblScholarshipCount.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblScholarshipCount.ForeColor = System.Drawing.Color.Red;
            this.lblScholarshipCount.Location = new System.Drawing.Point(62, 76);
            this.lblScholarshipCount.Name = "lblScholarshipCount";
            this.lblScholarshipCount.Size = new System.Drawing.Size(18, 19);
            this.lblScholarshipCount.TabIndex = 12;
            this.lblScholarshipCount.Text = "0";
            this.lblScholarshipCount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DarkBlue;
            this.label6.Location = new System.Drawing.Point(6, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 14);
            this.label6.TabIndex = 11;
            this.label6.Text = "Selected:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbxScholarship
            // 
            this.cbxScholarship.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cbxScholarship.CheckOnClick = true;
            this.cbxScholarship.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxScholarship.FormattingEnabled = true;
            this.cbxScholarship.HorizontalScrollbar = true;
            this.cbxScholarship.Location = new System.Drawing.Point(6, 16);
            this.cbxScholarship.Name = "cbxScholarship";
            this.cbxScholarship.Size = new System.Drawing.Size(226, 58);
            this.cbxScholarship.TabIndex = 3;
            this.cbxScholarship.ThreeDCheckBoxes = true;
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
            this.groupBox3.TabIndex = 24;
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
            // pbxScholarship
            // 
            this.pbxScholarship.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.pbxScholarship.BackColor = System.Drawing.Color.Transparent;
            this.pbxScholarship.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbxScholarship.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxScholarship.Image = ((System.Drawing.Image)(resources.GetObject("pbxScholarship.Image")));
            this.pbxScholarship.Location = new System.Drawing.Point(136, 37);
            this.pbxScholarship.Name = "pbxScholarship";
            this.pbxScholarship.Size = new System.Drawing.Size(33, 41);
            this.pbxScholarship.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbxScholarship.TabIndex = 25;
            this.pbxScholarship.TabStop = false;
            // 
            // ControlScholarshipManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "ControlScholarshipManager";
            this.Size = new System.Drawing.Size(255, 580);
            ((System.ComponentModel.ISupportInitialize)(this.pbxFind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRefresh)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.gbxDepartment.ResumeLayout(false);
            this.gbxDepartment.PerformLayout();
            this.gbxYearLevel.ResumeLayout(false);
            this.gbxYearLevel.PerformLayout();
            this.gbxScholarship.ResumeLayout(false);
            this.gbxScholarship.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxScholarship)).EndInit();
            this.ResumeLayout(false);

        }
    }
}
