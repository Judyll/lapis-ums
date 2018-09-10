using System;
using System.Collections.Generic;
using System.Text;

namespace BaseServices
{
    public partial class PersonSearchOnTextBoxList : SearchOnTextboxList
    {
        protected System.Windows.Forms.LinkLabel lnkCreatePerson;
    
        private void InitializeComponent()
        {
            this.lnkCreatePerson = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRefresh)).BeginInit();
            this.SuspendLayout();
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(246, 12);
            // 
            // pbxRefresh
            // 
            this.pbxRefresh.Location = new System.Drawing.Point(570, 9);
            // 
            // lnkCreatePerson
            // 
            this.lnkCreatePerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkCreatePerson.AutoSize = true;
            this.lnkCreatePerson.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCreatePerson.ForeColor = System.Drawing.Color.DarkBlue;
            this.lnkCreatePerson.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkCreatePerson.Location = new System.Drawing.Point(538, 289);
            this.lnkCreatePerson.Name = "lnkCreatePerson";
            this.lnkCreatePerson.Size = new System.Drawing.Size(103, 15);
            this.lnkCreatePerson.TabIndex = 72;
            this.lnkCreatePerson.TabStop = true;
            this.lnkCreatePerson.Text = "[ Create Person ]";
            this.lnkCreatePerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PersonSearchOnTextBoxList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(652, 310);
            this.Controls.Add(this.lnkCreatePerson);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PersonSearchOnTextBoxList";
            this.Text = "   Person List";
            this.Controls.SetChildIndex(this.txtSearch, 0);
            this.Controls.SetChildIndex(this.pbxRefresh, 0);
            this.Controls.SetChildIndex(this.lnkCreatePerson, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pbxRefresh)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }       
    }
}
