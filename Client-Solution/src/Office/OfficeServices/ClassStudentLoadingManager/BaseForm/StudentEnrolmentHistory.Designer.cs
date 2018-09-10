namespace OfficeServices
{
    partial class StudentEnrolmentHistory
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StudentEnrolmentHistory));
            this.gbxEnrolmentInfo = new System.Windows.Forms.GroupBox();
            this.trvStudentEnrolment = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.cachedCrystalStudentStatementOfAccountForFinals1 = new OfficeServices.ClassStudentLoadingManager.CrystalReport.CachedCrystalStudentStatementOfAccountForFinals();
            this.gbxEnrolmentInfo.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxEnrolmentInfo
            // 
            this.gbxEnrolmentInfo.Controls.Add(this.trvStudentEnrolment);
            this.gbxEnrolmentInfo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxEnrolmentInfo.ForeColor = System.Drawing.Color.DarkMagenta;
            this.gbxEnrolmentInfo.Location = new System.Drawing.Point(12, 75);
            this.gbxEnrolmentInfo.Name = "gbxEnrolmentInfo";
            this.gbxEnrolmentInfo.Size = new System.Drawing.Size(596, 328);
            this.gbxEnrolmentInfo.TabIndex = 22;
            this.gbxEnrolmentInfo.TabStop = false;
            this.gbxEnrolmentInfo.Text = " STUDENT ENROLMENT INFORMATION ";
            // 
            // trvStudentEnrolment
            // 
            this.trvStudentEnrolment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.trvStudentEnrolment.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trvStudentEnrolment.Indent = 20;
            this.trvStudentEnrolment.ItemHeight = 25;
            this.trvStudentEnrolment.Location = new System.Drawing.Point(21, 34);
            this.trvStudentEnrolment.Name = "trvStudentEnrolment";
            this.trvStudentEnrolment.ShowNodeToolTips = true;
            this.trvStudentEnrolment.Size = new System.Drawing.Size(554, 271);
            this.trvStudentEnrolment.TabIndex = 20;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(627, 58);
            this.panel1.TabIndex = 23;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(179)))), ((int)(((byte)(133)))));
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Location = new System.Drawing.Point(0, 417);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(630, 35);
            this.panel2.TabIndex = 24;
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(522, 7);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 23);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "  Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // StudentEnrolmentHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(623, 451);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.gbxEnrolmentInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StudentEnrolmentHistory";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.gbxEnrolmentInfo.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.GroupBox gbxEnrolmentInfo;
        protected System.Windows.Forms.TreeView trvStudentEnrolment;
        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private OfficeServices.ClassStudentLoadingManager.CrystalReport.CachedCrystalStudentStatementOfAccountForFinals cachedCrystalStudentStatementOfAccountForFinals1;
    }
}