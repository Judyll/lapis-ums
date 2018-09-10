using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceServices
{
    internal partial class ARStudentsPerTerm : FeeRegisterDetailedReportControl
    {
        private System.Windows.Forms.GroupBox gbxDateRage;
        protected System.Windows.Forms.DateTimePicker dtpCutOfDate;
    
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ARStudentsPerTerm));
            this.gbxDateRage = new System.Windows.Forms.GroupBox();
            this.dtpCutOfDate = new System.Windows.Forms.DateTimePicker();
            this.gbxScholarship.SuspendLayout();
            this.gbxCourse.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbxDateRage.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxScholarship
            // 
            this.gbxScholarship.Location = new System.Drawing.Point(330, 149);
            // 
            // gbxCourse
            // 
            this.gbxCourse.Size = new System.Drawing.Size(315, 265);
            // 
            // lnkCourseAll
            // 
            this.lnkCourseAll.Location = new System.Drawing.Point(147, 238);
            // 
            // lnkCourseNone
            // 
            this.lnkCourseNone.Location = new System.Drawing.Point(223, 238);
            // 
            // lblCourseCount
            // 
            this.lblCourseCount.Location = new System.Drawing.Point(62, 235);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(6, 238);
            // 
            // cbxCourse
            // 
            this.cbxCourse.Location = new System.Drawing.Point(6, 27);
            this.cbxCourse.Size = new System.Drawing.Size(303, 202);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(-2, 391);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(10, 357);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            // 
            // gbxDateRage
            // 
            this.gbxDateRage.Controls.Add(this.dtpCutOfDate);
            this.gbxDateRage.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxDateRage.Location = new System.Drawing.Point(330, 83);
            this.gbxDateRage.Name = "gbxDateRage";
            this.gbxDateRage.Size = new System.Drawing.Size(315, 62);
            this.gbxDateRage.TabIndex = 105;
            this.gbxDateRage.TabStop = false;
            this.gbxDateRage.Text = " Cut-Off Date ";
            // 
            // dtpCutOfDate
            // 
            this.dtpCutOfDate.Checked = false;
            this.dtpCutOfDate.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpCutOfDate.Location = new System.Drawing.Point(21, 23);
            this.dtpCutOfDate.Name = "dtpCutOfDate";
            this.dtpCutOfDate.Size = new System.Drawing.Size(271, 26);
            this.dtpCutOfDate.TabIndex = 0;
            // 
            // ARStudentsPerTerm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(661, 426);
            this.Controls.Add(this.gbxDateRage);
            this.Name = "ARStudentsPerTerm";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.gbxCourse, 0);
            this.Controls.SetChildIndex(this.gbxScholarship, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.progressBar, 0);
            this.Controls.SetChildIndex(this.gbxDateRage, 0);
            this.gbxScholarship.ResumeLayout(false);
            this.gbxScholarship.PerformLayout();
            this.gbxCourse.ResumeLayout(false);
            this.gbxCourse.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbxDateRage.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
