namespace RemoteClient
{
    partial class DateRangePicker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DateRangePicker));
            this.btnUse = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lnkDateFrom = new System.Windows.Forms.LinkLabel();
            this.lblDateFrom = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lnkDateTo = new System.Windows.Forms.LinkLabel();
            this.lblDateTo = new System.Windows.Forms.Label();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUse
            // 
            this.btnUse.Image = ((System.Drawing.Image)(resources.GetObject("btnUse.Image")));
            this.btnUse.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUse.Location = new System.Drawing.Point(385, 94);
            this.btnUse.Name = "btnUse";
            this.btnUse.Size = new System.Drawing.Size(107, 25);
            this.btnUse.TabIndex = 2;
            this.btnUse.Text = "Use Range";
            this.btnUse.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Location = new System.Drawing.Point(-1, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(525, 29);
            this.panel1.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lnkDateFrom);
            this.groupBox3.Controls.Add(this.lblDateFrom);
            this.groupBox3.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.Navy;
            this.groupBox3.Location = new System.Drawing.Point(5, 34);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(242, 55);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DATE FROM";
            // 
            // lnkDateFrom
            // 
            this.lnkDateFrom.AutoSize = true;
            this.lnkDateFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkDateFrom.Location = new System.Drawing.Point(184, 36);
            this.lnkDateFrom.Name = "lnkDateFrom";
            this.lnkDateFrom.Size = new System.Drawing.Size(43, 13);
            this.lnkDateFrom.TabIndex = 1;
            this.lnkDateFrom.TabStop = true;
            this.lnkDateFrom.Text = "change";
            // 
            // lblDateFrom
            // 
            this.lblDateFrom.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateFrom.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblDateFrom.Location = new System.Drawing.Point(6, 18);
            this.lblDateFrom.Name = "lblDateFrom";
            this.lblDateFrom.Size = new System.Drawing.Size(233, 19);
            this.lblDateFrom.TabIndex = 1;
            this.lblDateFrom.Text = "ID Label";
            this.lblDateFrom.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lnkDateTo);
            this.groupBox1.Controls.Add(this.lblDateTo);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(250, 33);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(242, 55);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "DATE TO";
            // 
            // lnkDateTo
            // 
            this.lnkDateTo.AutoSize = true;
            this.lnkDateTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkDateTo.Location = new System.Drawing.Point(183, 36);
            this.lnkDateTo.Name = "lnkDateTo";
            this.lnkDateTo.Size = new System.Drawing.Size(43, 13);
            this.lnkDateTo.TabIndex = 1;
            this.lnkDateTo.TabStop = true;
            this.lnkDateTo.Text = "change";
            // 
            // lblDateTo
            // 
            this.lblDateTo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateTo.ForeColor = System.Drawing.Color.OrangeRed;
            this.lblDateTo.Location = new System.Drawing.Point(5, 18);
            this.lblDateTo.Name = "lblDateTo";
            this.lblDateTo.Size = new System.Drawing.Size(233, 19);
            this.lblDateTo.TabIndex = 0;
            this.lblDateTo.Text = "ID Label";
            this.lblDateTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DateRangePicker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(496, 124);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnUse);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DateRangePicker";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Button btnUse;
        protected System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox3;
        protected System.Windows.Forms.Label lblDateFrom;
        private System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.LinkLabel lnkDateFrom;
        protected System.Windows.Forms.LinkLabel lnkDateTo;
        protected System.Windows.Forms.Label lblDateTo;
    }
}