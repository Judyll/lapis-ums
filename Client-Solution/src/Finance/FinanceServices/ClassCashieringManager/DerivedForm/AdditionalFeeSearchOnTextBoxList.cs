using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceServices
{
    internal partial class AdditionalFeeSearchOnTextBoxList : SearchOnTextboxList
    {
    
        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this.pbxRefresh)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(243, 12);
            // 
            // pbxRefresh
            // 
            this.pbxRefresh.Location = new System.Drawing.Point(567, 9);
            // 
            // AdditionalFeeSearchOnTextBoxList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(649, 310);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AdditionalFeeSearchOnTextBoxList";
            this.Text = "   Additional Fee List";
            ((System.ComponentModel.ISupportInitialize)(this.pbxRefresh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
