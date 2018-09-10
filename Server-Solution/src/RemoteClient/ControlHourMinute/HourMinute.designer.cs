namespace RemoteClient
{
    partial class HourMinute
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HourMinute));
            this.txtHour = new System.Windows.Forms.TextBox();
            this.lblSep = new System.Windows.Forms.Label();
            this.txtMinute = new System.Windows.Forms.TextBox();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.pnlBack = new System.Windows.Forms.Panel();
            this.pnlBack.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtHour
            // 
            this.txtHour.BackColor = System.Drawing.Color.GhostWhite;
            this.txtHour.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtHour.Location = new System.Drawing.Point(8, 1);
            this.txtHour.MaxLength = 2;
            this.txtHour.Name = "txtHour";
            this.txtHour.Size = new System.Drawing.Size(20, 15);
            this.txtHour.TabIndex = 1;
            this.txtHour.Text = "00";
            this.txtHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblSep
            // 
            this.lblSep.BackColor = System.Drawing.Color.GhostWhite;
            this.lblSep.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSep.ForeColor = System.Drawing.Color.Black;
            this.lblSep.Location = new System.Drawing.Point(26, 0);
            this.lblSep.Name = "lblSep";
            this.lblSep.Size = new System.Drawing.Size(12, 16);
            this.lblSep.TabIndex = 1;
            this.lblSep.Text = ":";
            this.lblSep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMinute
            // 
            this.txtMinute.BackColor = System.Drawing.Color.GhostWhite;
            this.txtMinute.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMinute.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinute.Location = new System.Drawing.Point(41, 8);
            this.txtMinute.MaxLength = 2;
            this.txtMinute.Name = "txtMinute";
            this.txtMinute.Size = new System.Drawing.Size(20, 15);
            this.txtMinute.TabIndex = 10;
            this.txtMinute.Text = "00";
            this.txtMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnDown
            // 
            this.btnDown.BackColor = System.Drawing.Color.Transparent;
            this.btnDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDown.BackgroundImage")));
            this.btnDown.Location = new System.Drawing.Point(76, 15);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(24, 12);
            this.btnDown.TabIndex = 13;
            this.btnDown.UseVisualStyleBackColor = false;
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.Color.Transparent;
            this.btnUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUp.BackgroundImage")));
            this.btnUp.Location = new System.Drawing.Point(76, 4);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(24, 12);
            this.btnUp.TabIndex = 12;
            this.btnUp.UseVisualStyleBackColor = false;
            // 
            // pnlBack
            // 
            this.pnlBack.BackColor = System.Drawing.Color.GhostWhite;
            this.pnlBack.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlBack.Controls.Add(this.txtHour);
            this.pnlBack.Controls.Add(this.lblSep);
            this.pnlBack.ForeColor = System.Drawing.Color.DarkGray;
            this.pnlBack.Location = new System.Drawing.Point(4, 5);
            this.pnlBack.Name = "pnlBack";
            this.pnlBack.Size = new System.Drawing.Size(67, 21);
            this.pnlBack.TabIndex = 14;
            // 
            // HourMinute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtMinute);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.pnlBack);
            this.Name = "HourMinute";
            this.Size = new System.Drawing.Size(105, 30);
            this.pnlBack.ResumeLayout(false);
            this.pnlBack.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox txtHour;
        public System.Windows.Forms.Label lblSep;
        public System.Windows.Forms.TextBox txtMinute;
        public System.Windows.Forms.Button btnDown;
        public System.Windows.Forms.Button btnUp;
        public System.Windows.Forms.Panel pnlBack;

    }
}
