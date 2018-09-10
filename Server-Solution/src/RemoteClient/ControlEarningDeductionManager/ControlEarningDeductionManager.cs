using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace RemoteClient
{
    public partial class ControlEarningDeductionManager: ControlManager
    {
        private RadioButton optApply;
        private RadioButton optView;
        private GroupBox groupBox1;
    
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optApply = new System.Windows.Forms.RadioButton();
            this.optView = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pbxFind)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRefresh)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ttpMain
            // 
            this.ttpMain.AutoPopDelay = 3000;
            this.ttpMain.InitialDelay = 500;
            this.ttpMain.IsBalloon = true;
            this.ttpMain.ReshowDelay = 100;
            this.ttpMain.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.ttpMain.ToolTipTitle = "Console";
            // 
            // pbxClose
            // 
            this.ttpMain.SetToolTip(this.pbxClose, "Done");
            // 
            // pbxRefresh
            // 
            this.ttpMain.SetToolTip(this.pbxRefresh, "Refresh");
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.groupBox1);
            this.pnlMain.Size = new System.Drawing.Size(255, 196);
            this.pnlMain.Controls.SetChildIndex(this.txtSearch, 0);
            this.pnlMain.Controls.SetChildIndex(this.pbxRefresh, 0);
            this.pnlMain.Controls.SetChildIndex(this.groupBox1, 0);
            this.pnlMain.Controls.SetChildIndex(this.pbxClose, 0);
            this.pnlMain.Controls.SetChildIndex(this.pbxFind, 0);
            this.pnlMain.Controls.SetChildIndex(this.pnlHeader, 0);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox1.Controls.Add(this.optApply);
            this.groupBox1.Controls.Add(this.optView);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 118);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 68);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mode";
            // 
            // optApply
            // 
            this.optApply.AutoSize = true;
            this.optApply.Checked = true;
            this.optApply.Location = new System.Drawing.Point(51, 19);
            this.optApply.Name = "optApply";
            this.optApply.Size = new System.Drawing.Size(181, 17);
            this.optApply.TabIndex = 2;
            this.optApply.TabStop = true;
            this.optApply.Text = "Apply a deduction to employee(s)";
            this.optApply.UseVisualStyleBackColor = true;
            // 
            // optView
            // 
            this.optView.AutoSize = true;
            this.optView.Location = new System.Drawing.Point(51, 42);
            this.optView.Name = "optView";
            this.optView.Size = new System.Drawing.Size(158, 17);
            this.optView.TabIndex = 3;
            this.optView.Text = "View employee deduction(s)";
            this.optView.UseVisualStyleBackColor = true;
            // 
            // ControlEarningDeductionManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "ControlEarningDeductionManager";
            this.Size = new System.Drawing.Size(255, 196);
            ((System.ComponentModel.ISupportInitialize)(this.pbxFind)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxRefresh)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.pnlMain.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
    }
}
