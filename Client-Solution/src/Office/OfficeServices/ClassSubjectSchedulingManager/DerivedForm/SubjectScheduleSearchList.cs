using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace OfficeServices
{
    internal partial class SubjectScheduleSearchList : SearchList
    {
        internal ToolStrip tspCreate;
        private ToolStripLabel lblQuery;
        private ToolStripLabel lblResult;
        private ToolStripLabel lblSpacer;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton btnPrintScheduleList;
        private ToolStripButton btnCreate;
    
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubjectScheduleSearchList));
            this.tspCreate = new System.Windows.Forms.ToolStrip();
            this.lblQuery = new System.Windows.Forms.ToolStripLabel();
            this.lblResult = new System.Windows.Forms.ToolStripLabel();
            this.lblSpacer = new System.Windows.Forms.ToolStripLabel();
            this.btnCreate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrintScheduleList = new System.Windows.Forms.ToolStripButton();
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
            this.lblSpacer,
            this.btnCreate,
            this.toolStripSeparator1,
            this.btnPrintScheduleList});
            this.tspCreate.Location = new System.Drawing.Point(0, 243);
            this.tspCreate.Name = "tspCreate";
            this.tspCreate.Size = new System.Drawing.Size(981, 25);
            this.tspCreate.TabIndex = 64;
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
            // btnCreate
            // 
            this.btnCreate.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnCreate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCreate.Image = ((System.Drawing.Image)(resources.GetObject("btnCreate.Image")));
            this.btnCreate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(23, 22);
            this.btnCreate.ToolTipText = "Create a subject schedule";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnPrintScheduleList
            // 
            this.btnPrintScheduleList.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.btnPrintScheduleList.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPrintScheduleList.Image = ((System.Drawing.Image)(resources.GetObject("btnPrintScheduleList.Image")));
            this.btnPrintScheduleList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrintScheduleList.Name = "btnPrintScheduleList";
            this.btnPrintScheduleList.Size = new System.Drawing.Size(23, 22);
            this.btnPrintScheduleList.Text = "Print subject schedule list";
            // 
            // SubjectScheduleSearchList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(981, 268);
            this.Controls.Add(this.tspCreate);
            this.Name = "SubjectScheduleSearchList";
            this.Text = "  Subject Schedule List";
            this.Controls.SetChildIndex(this.tspCreate, 0);
            this.tspCreate.ResumeLayout(false);
            this.tspCreate.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
