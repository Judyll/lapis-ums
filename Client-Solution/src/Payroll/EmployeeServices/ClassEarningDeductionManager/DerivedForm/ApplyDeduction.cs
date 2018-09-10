using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeServices
{
    internal partial class ApplyDeduction: ApplyEarningDeduction
    {


        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplyDeduction));
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Size = new System.Drawing.Size(584, 58);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(179)))), ((int)(((byte)(133)))));
            // 
            // ApplyDeduction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(578, 643);
            this.Name = "ApplyDeduction";
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
