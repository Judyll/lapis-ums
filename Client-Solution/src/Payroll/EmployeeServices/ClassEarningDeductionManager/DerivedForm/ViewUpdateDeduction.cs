using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeServices
{
    internal partial class ViewUpdateDeduction: ViewUpdateEarningDeduction
    {
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewUpdateDeduction));
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            // 
            // ViewUpdateDeduction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(423, 368);
            this.Name = "ViewUpdateDeduction";
            this.Text = "";
            this.ResumeLayout(false);

        }
    }
}
