using System;
using System.Collections.Generic;
using System.Text;

namespace BaseServices
{
    internal partial class OfficeEmployerSearchOnTextBoxList : SearchOnTextboxList
    {
        protected System.Windows.Forms.LinkLabel lnkUpdateOfficeEmployer;
        protected System.Windows.Forms.LinkLabel lnkCreateOfficeEmployer;
    
        private void InitializeComponent()
        {
            this.lnkCreateOfficeEmployer = new System.Windows.Forms.LinkLabel();
            this.lnkUpdateOfficeEmployer = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDone)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRefresh)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(243, 12);
            // 
            // pbxDone
            // 
            this.pbxDone.Location = new System.Drawing.Point(605, 9);
            // 
            // pbxRefresh
            // 
            this.pbxRefresh.Location = new System.Drawing.Point(566, 9);
            // 
            // lnkCreateOfficeEmployer
            // 
            this.lnkCreateOfficeEmployer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkCreateOfficeEmployer.AutoSize = true;
            this.lnkCreateOfficeEmployer.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCreateOfficeEmployer.ForeColor = System.Drawing.Color.DarkBlue;
            this.lnkCreateOfficeEmployer.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkCreateOfficeEmployer.Location = new System.Drawing.Point(489, 287);
            this.lnkCreateOfficeEmployer.Name = "lnkCreateOfficeEmployer";
            this.lnkCreateOfficeEmployer.Size = new System.Drawing.Size(152, 15);
            this.lnkCreateOfficeEmployer.TabIndex = 73;
            this.lnkCreateOfficeEmployer.TabStop = true;
            this.lnkCreateOfficeEmployer.Text = "[ Create Office/Employer ]";
            this.lnkCreateOfficeEmployer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lnkUpdateOfficeEmployer
            // 
            this.lnkUpdateOfficeEmployer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkUpdateOfficeEmployer.AutoSize = true;
            this.lnkUpdateOfficeEmployer.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkUpdateOfficeEmployer.ForeColor = System.Drawing.Color.DarkBlue;
            this.lnkUpdateOfficeEmployer.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkUpdateOfficeEmployer.Location = new System.Drawing.Point(331, 287);
            this.lnkUpdateOfficeEmployer.Name = "lnkUpdateOfficeEmployer";
            this.lnkUpdateOfficeEmployer.Size = new System.Drawing.Size(154, 15);
            this.lnkUpdateOfficeEmployer.TabIndex = 74;
            this.lnkUpdateOfficeEmployer.TabStop = true;
            this.lnkUpdateOfficeEmployer.Text = "[ Update Office/Employer ]";
            this.lnkUpdateOfficeEmployer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OfficeEmployerSearchOnTextBoxList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(649, 309);
            this.Controls.Add(this.lnkUpdateOfficeEmployer);
            this.Controls.Add(this.lnkCreateOfficeEmployer);
            this.Name = "OfficeEmployerSearchOnTextBoxList";
            this.Text = "   Office/Employer List";
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.pbxRefresh, 0);
            this.Controls.SetChildIndex(this.pbxDone, 0);
            this.Controls.SetChildIndex(this.lnkCreateOfficeEmployer, 0);
            this.Controls.SetChildIndex(this.lnkUpdateOfficeEmployer, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbxDone)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRefresh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
