namespace OfficeServices
{
    partial class MajorExamSchedule
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ColumnHeader clhSystemInd;
            System.Windows.Forms.ColumnHeader clhExamDate;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MajorExamSchedule));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.lsvMajorExam = new System.Windows.Forms.ListView();
            this.clhCheckBox = new System.Windows.Forms.ColumnHeader(0);
            this.clhExamDescription = new System.Windows.Forms.ColumnHeader();
            this.imgList = new System.Windows.Forms.ImageList(this.components);
            this.gbxEnrolmentInfo = new System.Windows.Forms.GroupBox();
            this.cmsChangeExamDate = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.lblChangeExamDate = new System.Windows.Forms.ToolStripMenuItem();
            this.lnkFilter = new System.Windows.Forms.LinkLabel();
            clhSystemInd = new System.Windows.Forms.ColumnHeader();
            clhExamDate = new System.Windows.Forms.ColumnHeader();
            this.panel2.SuspendLayout();
            this.gbxEnrolmentInfo.SuspendLayout();
            this.cmsChangeExamDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // clhSystemInd
            // 
            clhSystemInd.Text = "System ID";
            clhSystemInd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            clhSystemInd.Width = 80;
            // 
            // clhExamDate
            // 
            clhExamDate.Text = "Exam Date";
            clhExamDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            clhExamDate.Width = 219;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(612, 58);
            this.panel1.TabIndex = 24;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(165)))), ((int)(((byte)(179)))), ((int)(((byte)(133)))));
            this.panel2.Controls.Add(this.lnkFilter);
            this.panel2.Controls.Add(this.btnPrint);
            this.panel2.Controls.Add(this.btnClose);
            this.panel2.Location = new System.Drawing.Point(0, 318);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(612, 35);
            this.panel2.TabIndex = 25;
            // 
            // btnPrint
            // 
            this.btnPrint.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnPrint.BackgroundImage")));
            this.btnPrint.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnPrint.Enabled = false;
            this.btnPrint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(417, 6);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(86, 23);
            this.btnPrint.TabIndex = 71;
            this.btnPrint.Text = "Print";
            this.btnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnClose.BackgroundImage")));
            this.btnClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(509, 6);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(86, 23);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "  Close";
            this.btnClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // lsvMajorExam
            // 
            this.lsvMajorExam.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lsvMajorExam.CheckBoxes = true;
            this.lsvMajorExam.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.clhCheckBox,
            clhSystemInd,
            clhExamDate,
            this.clhExamDescription});
            this.lsvMajorExam.Cursor = System.Windows.Forms.Cursors.Default;
            this.lsvMajorExam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lsvMajorExam.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvMajorExam.FullRowSelect = true;
            this.lsvMajorExam.GridLines = true;
            this.lsvMajorExam.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvMajorExam.HideSelection = false;
            this.lsvMajorExam.Location = new System.Drawing.Point(3, 18);
            this.lsvMajorExam.MultiSelect = false;
            this.lsvMajorExam.Name = "lsvMajorExam";
            this.lsvMajorExam.ShowGroups = false;
            this.lsvMajorExam.ShowItemToolTips = true;
            this.lsvMajorExam.Size = new System.Drawing.Size(577, 218);
            this.lsvMajorExam.SmallImageList = this.imgList;
            this.lsvMajorExam.TabIndex = 26;
            this.lsvMajorExam.UseCompatibleStateImageBehavior = false;
            this.lsvMajorExam.View = System.Windows.Forms.View.Details;
            // 
            // clhCheckBox
            // 
            this.clhCheckBox.Text = "";
            this.clhCheckBox.Width = 37;
            // 
            // clhExamDescription
            // 
            this.clhExamDescription.Text = "                            Exam Description";
            this.clhExamDescription.Width = 303;
            // 
            // imgList
            // 
            this.imgList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList.ImageStream")));
            this.imgList.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList.Images.SetKeyName(0, "");
            // 
            // gbxEnrolmentInfo
            // 
            this.gbxEnrolmentInfo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gbxEnrolmentInfo.Controls.Add(this.lsvMajorExam);
            this.gbxEnrolmentInfo.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxEnrolmentInfo.ForeColor = System.Drawing.Color.Navy;
            this.gbxEnrolmentInfo.Location = new System.Drawing.Point(12, 68);
            this.gbxEnrolmentInfo.Name = "gbxEnrolmentInfo";
            this.gbxEnrolmentInfo.Size = new System.Drawing.Size(583, 239);
            this.gbxEnrolmentInfo.TabIndex = 35;
            this.gbxEnrolmentInfo.TabStop = false;
            this.gbxEnrolmentInfo.Text = " EXAM SCHEDULES ";
            // 
            // cmsChangeExamDate
            // 
            this.cmsChangeExamDate.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsChangeExamDate.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblChangeExamDate});
            this.cmsChangeExamDate.Name = "cmsChangeExamDate";
            this.cmsChangeExamDate.Size = new System.Drawing.Size(182, 26);
            // 
            // lblChangeExamDate
            // 
            this.lblChangeExamDate.Name = "lblChangeExamDate";
            this.lblChangeExamDate.Size = new System.Drawing.Size(181, 22);
            this.lblChangeExamDate.Text = "Change Exam Date";
            // 
            // lnkFilter
            // 
            this.lnkFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkFilter.AutoSize = true;
            this.lnkFilter.Enabled = false;
            this.lnkFilter.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkFilter.ForeColor = System.Drawing.Color.Navy;
            this.lnkFilter.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkFilter.Location = new System.Drawing.Point(9, 10);
            this.lnkFilter.Name = "lnkFilter";
            this.lnkFilter.Size = new System.Drawing.Size(134, 15);
            this.lnkFilter.TabIndex = 72;
            this.lnkFilter.TabStop = true;
            this.lnkFilter.Text = "[ Filter Student Result ]";
            this.lnkFilter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnkFilter.Visible = false;
            // 
            // MajorExamSchedule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(609, 352);
            this.Controls.Add(this.gbxEnrolmentInfo);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MajorExamSchedule";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.gbxEnrolmentInfo.ResumeLayout(false);
            this.cmsChangeExamDate.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ListView lsvMajorExam;
        private System.Windows.Forms.ColumnHeader clhCheckBox;
        private System.Windows.Forms.ColumnHeader clhExamDescription;
        private System.Windows.Forms.ImageList imgList;
        public System.Windows.Forms.GroupBox gbxEnrolmentInfo;
        protected System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.ContextMenuStrip cmsChangeExamDate;
        private System.Windows.Forms.ToolStripMenuItem lblChangeExamDate;
        protected System.Windows.Forms.LinkLabel lnkFilter;
    }
}