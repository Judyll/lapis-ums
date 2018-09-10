using System;
using System.Collections.Generic;
using System.Text;

namespace RegistrarServices
{
    internal partial class SchoolYearView : SchoolYear
    {
        private System.Windows.Forms.Button btnDone;

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SchoolYearView));
            this.btnDone = new System.Windows.Forms.Button();
            this.gbxSysID.SuspendLayout();
            this.gbxDescription.SuspendLayout();
            this.gbxDateStart.SuspendLayout();
            this.gbxDateEnd.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDone);
            // 
            // btnDone
            // 
            this.btnDone.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDone.BackgroundImage")));
            this.btnDone.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnDone.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDone.Location = new System.Drawing.Point(480, 5);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(86, 23);
            this.btnDone.TabIndex = 35;
            this.btnDone.Text = "Close";
            this.btnDone.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDone.UseVisualStyleBackColor = true;
            // 
            // SchoolYearView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(570, 316);
            this.Name = "SchoolYearView";
            this.gbxSysID.ResumeLayout(false);
            this.gbxDescription.ResumeLayout(false);
            this.gbxDateStart.ResumeLayout(false);
            this.gbxDateEnd.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }
    }
}
