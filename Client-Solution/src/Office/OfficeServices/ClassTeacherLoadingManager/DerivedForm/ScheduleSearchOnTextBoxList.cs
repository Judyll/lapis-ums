using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeServices
{
    internal partial class ScheduleSearchOnTextBoxList : SearchOnTextboxListTeacherLoading
    {
        private void InitializeComponent()
        {
            ((System.ComponentModel.ISupportInitialize)(this.pbxDone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRefresh)).BeginInit();
            this.SuspendLayout();
            // 
            // pbxRefresh
            // 
            this.pbxRefresh.WaitOnLoad = true;
            // 
            // ScheduleSearchOnTextBoxList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(879, 312);
            this.Name = "ScheduleSearchOnTextBoxList";
            this.Text = "   Schedule List";
            ((System.ComponentModel.ISupportInitialize)(this.pbxDone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRefresh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
