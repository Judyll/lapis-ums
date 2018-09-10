using System;
using System.Collections.Generic;
using System.Text;

namespace FinanceServices
{
    internal partial class ParticularSearchOnTextBoxList : SearchOnTextboxList
    {
        private System.Windows.Forms.LinkLabel lnkCreate;
    
        private void InitializeComponent()
        {
            this.lnkCreate = new System.Windows.Forms.LinkLabel();
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
            // lnkCreate
            // 
            this.lnkCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkCreate.AutoSize = true;
            this.lnkCreate.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCreate.ForeColor = System.Drawing.Color.DarkBlue;
            this.lnkCreate.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkCreate.Location = new System.Drawing.Point(431, 287);
            this.lnkCreate.Name = "lnkCreate";
            this.lnkCreate.Size = new System.Drawing.Size(210, 15);
            this.lnkCreate.TabIndex = 72;
            this.lnkCreate.TabStop = true;
            this.lnkCreate.Text = "[ Create a new School Fee Particular ]";
            this.lnkCreate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ParticularSearchOnTextBoxList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(649, 309);
            this.Controls.Add(this.lnkCreate);
            this.Name = "ParticularSearchOnTextBoxList";
            this.Text = "   Particular Search List";
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.pbxRefresh, 0);
            this.Controls.SetChildIndex(this.lnkCreate, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbxRefresh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
