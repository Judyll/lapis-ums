namespace RegistrarServices
{
    partial class OtherInformation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OtherInformation));
            this.txtOtherInfo = new System.Windows.Forms.TextBox();
            this.pbxDone = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbxDone)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtOtherInfo
            // 
            this.txtOtherInfo.BackColor = System.Drawing.Color.White;
            this.txtOtherInfo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOtherInfo.ForeColor = System.Drawing.Color.Black;
            this.txtOtherInfo.Location = new System.Drawing.Point(6, 30);
            this.txtOtherInfo.MaxLength = 1000;
            this.txtOtherInfo.Multiline = true;
            this.txtOtherInfo.Name = "txtOtherInfo";
            this.txtOtherInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOtherInfo.Size = new System.Drawing.Size(318, 162);
            this.txtOtherInfo.TabIndex = 0;
            // 
            // pbxDone
            // 
            this.pbxDone.BackColor = System.Drawing.Color.Transparent;
            this.pbxDone.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxDone.Image = ((System.Drawing.Image)(resources.GetObject("pbxDone.Image")));
            this.pbxDone.Location = new System.Drawing.Point(307, 5);
            this.pbxDone.Name = "pbxDone";
            this.pbxDone.Size = new System.Drawing.Size(20, 20);
            this.pbxDone.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbxDone.TabIndex = 5;
            this.pbxDone.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.SteelBlue;
            this.panel1.Controls.Add(this.pbxDone);
            this.panel1.Controls.Add(this.label1);
            this.panel1.ForeColor = System.Drawing.Color.DarkCyan;
            this.panel1.Location = new System.Drawing.Point(-4, -3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(346, 27);
            this.panel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(8, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Other Information";
            // 
            // OtherInformation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Teal;
            this.ClientSize = new System.Drawing.Size(330, 200);
            this.Controls.Add(this.txtOtherInfo);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OtherInformation";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MasteralRate";
            ((System.ComponentModel.ISupportInitialize)(this.pbxDone)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtOtherInfo;
        private System.Windows.Forms.PictureBox pbxDone;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}