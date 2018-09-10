using System;
using System.Collections.Generic;
using System.Text;

namespace AttendaceServices
{
    internal partial class LogInLogOutEmployeeInformation : LogInLogOutInformation
    {

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogInLogOutEmployeeInformation));
            this.panel3.SuspendLayout();
            this.grpStudentInfromation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPhoto)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            // 
            // LogInLogOutEmployeeInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(778, 659);
            this.Name = "LogInLogOutEmployeeInformation";
            this.panel3.ResumeLayout(false);
            this.grpStudentInfromation.ResumeLayout(false);
            this.grpStudentInfromation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPhoto)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
