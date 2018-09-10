using System;
using System.Collections.Generic;
using System.Text;

namespace RemoteClient
{
    public partial class ControlLoanRemittance : ControlManager
    {
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton optLoanType;
        private System.Windows.Forms.RadioButton optLoanRemittance;
    
        private void InitializeComponent()
        {
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.optLoanType = new System.Windows.Forms.RadioButton();
            this.optLoanRemittance = new System.Windows.Forms.RadioButton();
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
            this.ttpMain.SetToolTip(this.pbxClose, "Close");
            // 
            // pbxRefresh
            // 
            this.ttpMain.SetToolTip(this.pbxRefresh, "Refresh");
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.groupBox1);
            this.pnlMain.Size = new System.Drawing.Size(255, 189);
            this.pnlMain.Controls.SetChildIndex(this.txtSearch, 0);
            this.pnlMain.Controls.SetChildIndex(this.pbxRefresh, 0);
            this.pnlMain.Controls.SetChildIndex(this.pbxClose, 0);
            this.pnlMain.Controls.SetChildIndex(this.pbxFind, 0);
            this.pnlMain.Controls.SetChildIndex(this.groupBox1, 0);
            this.pnlMain.Controls.SetChildIndex(this.pnlHeader, 0);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox1.Controls.Add(this.optLoanType);
            this.groupBox1.Controls.Add(this.optLoanRemittance);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(8, 113);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 68);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mode";
            // 
            // optLoanType
            // 
            this.optLoanType.AutoSize = true;
            this.optLoanType.Checked = true;
            this.optLoanType.Location = new System.Drawing.Point(51, 19);
            this.optLoanType.Name = "optLoanType";
            this.optLoanType.Size = new System.Drawing.Size(130, 17);
            this.optLoanType.TabIndex = 2;
            this.optLoanType.TabStop = true;
            this.optLoanType.Text = "Loan Type Information";
            this.optLoanType.UseVisualStyleBackColor = true;
            // 
            // optLoanRemittance
            // 
            this.optLoanRemittance.AutoSize = true;
            this.optLoanRemittance.Location = new System.Drawing.Point(51, 42);
            this.optLoanRemittance.Name = "optLoanRemittance";
            this.optLoanRemittance.Size = new System.Drawing.Size(153, 17);
            this.optLoanRemittance.TabIndex = 3;
            this.optLoanRemittance.Text = "Employee Loan Remittance";
            this.optLoanRemittance.UseVisualStyleBackColor = true;
            // 
            // ControlLoanRemittance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "ControlLoanRemittance";
            this.Size = new System.Drawing.Size(255, 189);
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
