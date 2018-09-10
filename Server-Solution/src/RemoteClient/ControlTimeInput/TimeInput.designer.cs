namespace RemoteClient
{
    partial class TimeInput
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeInput));
            this.lblSep = new System.Windows.Forms.Label();
            this.txtMinute = new System.Windows.Forms.TextBox();
            this.btnUp = new System.Windows.Forms.Button();
            this.txtHour = new System.Windows.Forms.TextBox();
            this.txtAmPm = new System.Windows.Forms.TextBox();
            this.pnlBack = new System.Windows.Forms.Panel();
            this.btnDown = new System.Windows.Forms.Button();
            this.pnlBack.SuspendLayout();
            this.SuspendLayout();
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
            this.txtMinute.TabIndex = 2;
            this.txtMinute.Text = "00";
            this.txtMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.Color.Transparent;
            this.btnUp.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnUp.BackgroundImage")));
            this.btnUp.Location = new System.Drawing.Point(102, 4);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(24, 12);
            this.btnUp.TabIndex = 4;
            this.btnUp.UseVisualStyleBackColor = false;
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
            this.txtHour.Text = "12";
            this.txtHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtAmPm
            // 
            this.txtAmPm.BackColor = System.Drawing.Color.GhostWhite;
            this.txtAmPm.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtAmPm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAmPm.Location = new System.Drawing.Point(64, 8);
            this.txtAmPm.MaxLength = 2;
            this.txtAmPm.Name = "txtAmPm";
            this.txtAmPm.ReadOnly = true;
            this.txtAmPm.Size = new System.Drawing.Size(24, 15);
            this.txtAmPm.TabIndex = 3;
            this.txtAmPm.Text = "AM";
            this.txtAmPm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            this.pnlBack.Size = new System.Drawing.Size(93, 21);
            this.pnlBack.TabIndex = 9;
            // 
            // btnDown
            // 
            this.btnDown.BackColor = System.Drawing.Color.Transparent;
            this.btnDown.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnDown.BackgroundImage")));
            this.btnDown.Location = new System.Drawing.Point(102, 15);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(24, 12);
            this.btnDown.TabIndex = 5;
            this.btnDown.UseVisualStyleBackColor = false;
            // 
            // TimeInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtMinute);
            this.Controls.Add(this.btnDown);
            this.Controls.Add(this.txtAmPm);
            this.Controls.Add(this.btnUp);
            this.Controls.Add(this.pnlBack);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "TimeInput";
            this.Size = new System.Drawing.Size(130, 30);
            this.pnlBack.ResumeLayout(false);
            this.pnlBack.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label lblSep;
        public System.Windows.Forms.TextBox txtMinute;
        public System.Windows.Forms.Button btnUp;
        public System.Windows.Forms.TextBox txtHour;
        public System.Windows.Forms.TextBox txtAmPm;
        public System.Windows.Forms.Panel pnlBack;
        public System.Windows.Forms.Button btnDown;

    }
}
