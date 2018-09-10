using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeServices
{
    internal partial class EmployeeSearchList: SearchList
    {
        internal System.Windows.Forms.ToolStrip tspCreate;
        private System.Windows.Forms.ToolStripLabel lblQuery;
        private System.Windows.Forms.ToolStripLabel lblResult;
        private System.Windows.Forms.ToolStripLabel lblSpacer;
    
        private void InitializeComponent()
        {
            this.tspCreate = new System.Windows.Forms.ToolStrip();
            this.lblQuery = new System.Windows.Forms.ToolStripLabel();
            this.lblResult = new System.Windows.Forms.ToolStripLabel();
            this.lblSpacer = new System.Windows.Forms.ToolStripLabel();
            this.tspCreate.SuspendLayout();
            this.SuspendLayout();
            // 
            // tspCreate
            // 
            this.tspCreate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tspCreate.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.tspCreate.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblQuery,
            this.lblResult,
            this.lblSpacer});
            this.tspCreate.Location = new System.Drawing.Point(0, 259);
            this.tspCreate.Name = "tspCreate";
            this.tspCreate.Size = new System.Drawing.Size(463, 25);
            this.tspCreate.TabIndex = 65;
            this.tspCreate.Text = "toolStrip1";
            // 
            // lblQuery
            // 
            this.lblQuery.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuery.ForeColor = System.Drawing.Color.Maroon;
            this.lblQuery.Name = "lblQuery";
            this.lblQuery.Size = new System.Drawing.Size(51, 22);
            this.lblQuery.Text = "  Query:";
            // 
            // lblResult
            // 
            this.lblResult.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.Color.Maroon;
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(41, 22);
            this.lblResult.Text = "Result";
            // 
            // lblSpacer
            // 
            this.lblSpacer.Name = "lblSpacer";
            this.lblSpacer.Size = new System.Drawing.Size(0, 22);
            // 
            // EmployeeSearchList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(463, 284);
            this.Controls.Add(this.tspCreate);
            this.Name = "EmployeeSearchList";
            this.Text = "  Employee List";
            this.Controls.SetChildIndex(this.tspCreate, 0);
            this.tspCreate.ResumeLayout(false);
            this.tspCreate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
