using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeServices
{
    internal partial class ApplyEarning : ApplyEarningDeduction
    {
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApplyEarning));
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Size = new System.Drawing.Size(584, 58);
            // 
            // groupBox3
            // 
            this.groupBox3.Text = "EARNING INFORMATION";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(179)))), ((int)(((byte)(133)))));
            // 
            // ApplyEarning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(578, 643);
            this.Name = "ApplyEarning";
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
