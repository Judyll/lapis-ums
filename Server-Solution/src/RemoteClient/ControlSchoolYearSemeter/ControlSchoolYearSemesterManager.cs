using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RemoteClient
{
    public partial class ControlSchoolYearSemesterManager : ControlManager
    {
        private GroupBox groupBox1;
        private RadioButton optSchoolYear;
        private RadioButton optSemester;
    
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optSchoolYear = new System.Windows.Forms.RadioButton();
            this.optSemester = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRefresh)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
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
            this.pbxFind.Location = new System.Drawing.Point(8, 72);
            // 
            // pbxClose
            // 
            this.pbxClose.Location = new System.Drawing.Point(214, 34);
            this.ttpMain.SetToolTip(this.pbxClose, "Close");
            // 
            // pbxRefresh
            // 
            this.pbxRefresh.Location = new System.Drawing.Point(175, 34);
            this.ttpMain.SetToolTip(this.pbxRefresh, "Refresh");
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(52, 79);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.groupBox1);
            this.pnlMain.Size = new System.Drawing.Size(255, 183);
            this.pnlMain.Controls.SetChildIndex(this.txtSearch, 0);
            this.pnlMain.Controls.SetChildIndex(this.groupBox1, 0);
            this.pnlMain.Controls.SetChildIndex(this.pbxRefresh, 0);
            this.pnlMain.Controls.SetChildIndex(this.pbxClose, 0);
            this.pnlMain.Controls.SetChildIndex(this.pbxFind, 0);
            this.pnlMain.Controls.SetChildIndex(this.pnlHeader, 0);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox1.Controls.Add(this.optSchoolYear);
            this.groupBox1.Controls.Add(this.optSemester);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 109);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 68);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mode";
            // 
            // optSchoolYear
            // 
            this.optSchoolYear.AutoSize = true;
            this.optSchoolYear.Checked = true;
            this.optSchoolYear.Location = new System.Drawing.Point(51, 19);
            this.optSchoolYear.Name = "optSchoolYear";
            this.optSchoolYear.Size = new System.Drawing.Size(141, 17);
            this.optSchoolYear.TabIndex = 2;
            this.optSchoolYear.TabStop = true;
            this.optSchoolYear.Text = "Open/View a School Year";
            this.optSchoolYear.UseVisualStyleBackColor = true;
            // 
            // optSemester
            // 
            this.optSemester.AutoSize = true;
            this.optSemester.Location = new System.Drawing.Point(51, 42);
            this.optSemester.Name = "optSemester";
            this.optSemester.Size = new System.Drawing.Size(132, 17);
            this.optSemester.TabIndex = 3;
            this.optSemester.Text = "Open/View a Semester";
            this.optSemester.UseVisualStyleBackColor = true;
            // 
            // ControlSchoolYearSemesterManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "ControlSchoolYearSemesterManager";
            this.Size = new System.Drawing.Size(255, 183);
            ((System.ComponentModel.ISupportInitialize)(this.pbxFind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRefresh)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
