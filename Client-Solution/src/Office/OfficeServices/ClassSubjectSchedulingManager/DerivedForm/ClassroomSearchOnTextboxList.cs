using System;
using System.Collections.Generic;
using System.Text;

namespace OfficeServices
{
    internal partial class ClassroomSearchOnTextboxList : SearchOnTextboxList
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
            // ClassroomSearchOnTextboxList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(649, 308);
            this.Name = "ClassroomSearchOnTextboxList";
            this.Text = "  Classroom List";
            ((System.ComponentModel.ISupportInitialize)(this.pbxRefresh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
