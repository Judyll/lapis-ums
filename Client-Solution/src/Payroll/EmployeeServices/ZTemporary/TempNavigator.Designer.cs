namespace EmployeeServices
{
    partial class TempNavigator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnEmployee = new System.Windows.Forms.Button();
            this.btnDeduction = new System.Windows.Forms.Button();
            this.btnEarning = new System.Windows.Forms.Button();
            this.btnLoan = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnEmployee
            // 
            this.btnEmployee.Location = new System.Drawing.Point(20, 19);
            this.btnEmployee.Name = "btnEmployee";
            this.btnEmployee.Size = new System.Drawing.Size(171, 35);
            this.btnEmployee.TabIndex = 0;
            this.btnEmployee.Text = "Employee Manager";
            this.btnEmployee.UseVisualStyleBackColor = true;
            // 
            // btnDeduction
            // 
            this.btnDeduction.Location = new System.Drawing.Point(20, 60);
            this.btnDeduction.Name = "btnDeduction";
            this.btnDeduction.Size = new System.Drawing.Size(171, 35);
            this.btnDeduction.TabIndex = 1;
            this.btnDeduction.Text = "Deduction Manager";
            this.btnDeduction.UseVisualStyleBackColor = true;
            // 
            // btnEarning
            // 
            this.btnEarning.Location = new System.Drawing.Point(20, 101);
            this.btnEarning.Name = "btnEarning";
            this.btnEarning.Size = new System.Drawing.Size(171, 35);
            this.btnEarning.TabIndex = 2;
            this.btnEarning.Text = "Earning Manager";
            this.btnEarning.UseVisualStyleBackColor = true;
            // 
            // btnLoan
            // 
            this.btnLoan.Location = new System.Drawing.Point(20, 142);
            this.btnLoan.Name = "btnLoan";
            this.btnLoan.Size = new System.Drawing.Size(171, 35);
            this.btnLoan.TabIndex = 3;
            this.btnLoan.Text = "Loan Remittance Manager";
            this.btnLoan.UseVisualStyleBackColor = true;
            // 
            // TempNavigator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(211, 193);
            this.Controls.Add(this.btnLoan);
            this.Controls.Add(this.btnEarning);
            this.Controls.Add(this.btnDeduction);
            this.Controls.Add(this.btnEmployee);
            this.Name = "TempNavigator";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TempNavigator";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnEmployee;
        private System.Windows.Forms.Button btnDeduction;
        private System.Windows.Forms.Button btnEarning;
        private System.Windows.Forms.Button btnLoan;
    }
}