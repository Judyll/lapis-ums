using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceServices
{
    internal partial class ChartOfAccountSearchedOnTextBoxList : SearchOnTextboxListChartOfAccount
    {
        private System.Windows.Forms.CheckBox chkAllowMultipleInsert;
    
        private void InitializeComponent()
        {
            this.chkAllowMultipleInsert = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRefresh)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(511, 12);
            // 
            // pbxDone
            // 
            this.pbxDone.Location = new System.Drawing.Point(873, 9);
            // 
            // pbxRefresh
            // 
            this.pbxRefresh.Location = new System.Drawing.Point(834, 9);
            // 
            // chkAllowMultipleInsert
            // 
            this.chkAllowMultipleInsert.AutoSize = true;
            this.chkAllowMultipleInsert.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAllowMultipleInsert.ForeColor = System.Drawing.Color.Maroon;
            this.chkAllowMultipleInsert.Location = new System.Drawing.Point(12, 18);
            this.chkAllowMultipleInsert.Name = "chkAllowMultipleInsert";
            this.chkAllowMultipleInsert.Size = new System.Drawing.Size(170, 23);
            this.chkAllowMultipleInsert.TabIndex = 71;
            this.chkAllowMultipleInsert.Text = "Allow multiple insert";
            this.chkAllowMultipleInsert.UseVisualStyleBackColor = true;
            this.chkAllowMultipleInsert.Visible = false;
            // 
            // ChartOfAccountSearchedOnTextBoxList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(921, 314);
            this.Controls.Add(this.chkAllowMultipleInsert);
            this.Name = "ChartOfAccountSearchedOnTextBoxList";
            this.Text = "   Chart of Account List";
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.pbxRefresh, 0);
            this.Controls.SetChildIndex(this.pbxDone, 0);
            this.Controls.SetChildIndex(this.chkAllowMultipleInsert, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbxDone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRefresh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
