using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RemoteClient
{
    public partial class ControlCourseManager : ControlManager
    {
        private GroupBox groupBox1;
        private RadioButton optClassroom;
        private RadioButton optCourse;
        private RadioButton optSubject;
    
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optCourse = new System.Windows.Forms.RadioButton();
            this.optClassroom = new System.Windows.Forms.RadioButton();
            this.optSubject = new System.Windows.Forms.RadioButton();
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
            this.pnlMain.Controls.Add(this.groupBox1);
            this.pnlMain.Size = new System.Drawing.Size(255, 214);
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
            this.groupBox1.Controls.Add(this.optCourse);
            this.groupBox1.Controls.Add(this.optClassroom);
            this.groupBox1.Controls.Add(this.optSubject);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 112);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 93);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mode";
            // 
            // optCourse
            // 
            this.optCourse.AutoSize = true;
            this.optCourse.Location = new System.Drawing.Point(44, 66);
            this.optCourse.Name = "optCourse";
            this.optCourse.Size = new System.Drawing.Size(88, 17);
            this.optCourse.TabIndex = 4;
            this.optCourse.Text = "View Courses";
            this.optCourse.UseVisualStyleBackColor = true;
            // 
            // optClassroom
            // 
            this.optClassroom.AutoSize = true;
            this.optClassroom.Location = new System.Drawing.Point(44, 43);
            this.optClassroom.Name = "optClassroom";
            this.optClassroom.Size = new System.Drawing.Size(180, 17);
            this.optClassroom.TabIndex = 2;
            this.optClassroom.Text = "Create/Update/View Classrooms";
            this.optClassroom.UseVisualStyleBackColor = true;
            // 
            // optSubject
            // 
            this.optSubject.AutoSize = true;
            this.optSubject.Checked = true;
            this.optSubject.Location = new System.Drawing.Point(44, 20);
            this.optSubject.Name = "optSubject";
            this.optSubject.Size = new System.Drawing.Size(165, 17);
            this.optSubject.TabIndex = 3;
            this.optSubject.TabStop = true;
            this.optSubject.Text = "Create/Update/View Subjects";
            this.optSubject.UseVisualStyleBackColor = true;
            // 
            // ControlCourseManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "ControlCourseManager";
            this.Size = new System.Drawing.Size(255, 214);
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
