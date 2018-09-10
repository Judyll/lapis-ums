namespace AttendaceServices
{
    partial class AttendaceManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttendaceManager));
            this.lblRecordDate = new System.Windows.Forms.Label();
            this.ctlManager = new RemoteClient.ControlIdentificationManager();
            this.SuspendLayout();
            // 
            // lblRecordDate
            // 
            this.lblRecordDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblRecordDate.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblRecordDate.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRecordDate.ForeColor = System.Drawing.Color.DimGray;
            this.lblRecordDate.Location = new System.Drawing.Point(0, 701);
            this.lblRecordDate.Name = "lblRecordDate";
            this.lblRecordDate.Size = new System.Drawing.Size(1018, 13);
            this.lblRecordDate.TabIndex = 12;
            this.lblRecordDate.Text = "label1";
            this.lblRecordDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ctlManager
            // 
            this.ctlManager.BackColor = System.Drawing.Color.Transparent;
            this.ctlManager.Location = new System.Drawing.Point(752, 111);
            this.ctlManager.Name = "ctlManager";
            this.ctlManager.Size = new System.Drawing.Size(255, 125);
            this.ctlManager.TabIndex = 14;
            // 
            // AttendaceManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1018, 714);
            this.Controls.Add(this.ctlManager);
            this.Controls.Add(this.lblRecordDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AttendaceManager";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblRecordDate;
        private RemoteClient.ControlIdentificationManager ctlManager;
    }
}