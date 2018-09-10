using System;
using System.Collections.Generic;
using System.Text;

namespace BaseServices
{
    public partial class PersonInformationWithBeneficiaryReference : PersonInformation
    {
        private System.Windows.Forms.TabPage tblPersonDocument;
        private System.Windows.Forms.TabPage tblPersonBeneficiaries;
        private System.Windows.Forms.TabPage tblPersonReferences;
        private System.Windows.Forms.ToolStrip toolSubjectLoad;
        private System.Windows.Forms.ToolStripSplitButton btnDropDownIcon;
        private System.Windows.Forms.ToolStripMenuItem btnIcon;
        private System.Windows.Forms.ToolStripMenuItem btnList;
        private System.Windows.Forms.ListView lsvFileList;
        protected System.Windows.Forms.Label lblBeneficiariesStatus;
        private System.Windows.Forms.Label lblBeneficiaries;
        protected System.Windows.Forms.DataGridView dgvPersonBenificiaries;
        protected System.Windows.Forms.LinkLabel lnkCreateBeneficiary;
        protected System.Windows.Forms.DataGridView dgvPersonReference;
        protected System.Windows.Forms.LinkLabel lnkCreateReference;
        private System.Windows.Forms.ImageList imgIcon;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ToolStripButton btnAddDocument;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnShowDocument;
        private System.Windows.Forms.Label lblReference;
        protected System.Windows.Forms.PictureBox pbxReferences;
        private System.Windows.Forms.Label label20;
        protected System.Windows.Forms.PictureBox pbxBeneficiaries;
        protected System.Windows.Forms.PictureBox pbxPersonalDocument;
        private System.Windows.Forms.TextBox txtPersonDocumentRemarks;
        private System.Windows.Forms.Button btnInsertRemarks;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PersonInformationWithBeneficiaryReference));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tblPersonDocument = new System.Windows.Forms.TabPage();
            this.btnInsertRemarks = new System.Windows.Forms.Button();
            this.txtPersonDocumentRemarks = new System.Windows.Forms.TextBox();
            this.lsvFileList = new System.Windows.Forms.ListView();
            this.toolSubjectLoad = new System.Windows.Forms.ToolStrip();
            this.btnShowDocument = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnAddDocument = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnDropDownIcon = new System.Windows.Forms.ToolStripSplitButton();
            this.btnIcon = new System.Windows.Forms.ToolStripMenuItem();
            this.btnList = new System.Windows.Forms.ToolStripMenuItem();
            this.tblPersonBeneficiaries = new System.Windows.Forms.TabPage();
            this.lblBeneficiariesStatus = new System.Windows.Forms.Label();
            this.lblBeneficiaries = new System.Windows.Forms.Label();
            this.dgvPersonBenificiaries = new System.Windows.Forms.DataGridView();
            this.lnkCreateBeneficiary = new System.Windows.Forms.LinkLabel();
            this.tblPersonReferences = new System.Windows.Forms.TabPage();
            this.lblReference = new System.Windows.Forms.Label();
            this.dgvPersonReference = new System.Windows.Forms.DataGridView();
            this.lnkCreateReference = new System.Windows.Forms.LinkLabel();
            this.imgIcon = new System.Windows.Forms.ImageList(this.components);
            this.label20 = new System.Windows.Forms.Label();
            this.pbxBeneficiaries = new System.Windows.Forms.PictureBox();
            this.pbxReferences = new System.Windows.Forms.PictureBox();
            this.pbxPersonalDocument = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this._errProvider)).BeginInit();
            this.tblPerson.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxGeneralInformation)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPersonImage)).BeginInit();
            this.tabCntPerson.SuspendLayout();
            this.tblPersonDocument.SuspendLayout();
            this.toolSubjectLoad.SuspendLayout();
            this.tblPersonBeneficiaries.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonBenificiaries)).BeginInit();
            this.tblPersonReferences.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonReference)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBeneficiaries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxReferences)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPersonalDocument)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::BaseServices.Properties.Resources.lmsmemberinformationviewupdate;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightSteelBlue;
            this.panel2.Controls.Add(this.pbxPersonalDocument);
            this.panel2.Controls.Add(this.pbxReferences);
            this.panel2.Controls.Add(this.label20);
            this.panel2.Controls.Add(this.pbxBeneficiaries);
            this.panel2.Controls.SetChildIndex(this.pbxBeneficiaries, 0);
            this.panel2.Controls.SetChildIndex(this.label20, 0);
            this.panel2.Controls.SetChildIndex(this.pbxReferences, 0);
            this.panel2.Controls.SetChildIndex(this.pbxPersonalDocument, 0);
            this.panel2.Controls.SetChildIndex(this.pbxGeneralInformation, 0);
            this.panel2.Controls.SetChildIndex(this.label19, 0);
            // 
            // pbxGeneralInformation
            // 
            this.pbxGeneralInformation.BackColor = System.Drawing.Color.Transparent;
            this.pbxGeneralInformation.BackgroundImage = global::BaseServices.Properties.Resources.General_Information4;
            // 
            // panel4
            // 
            this.panel4.BackgroundImage = global::BaseServices.Properties.Resources.Sidebar2;
            // 
            // lblPersonName
            // 
            this.lblPersonName.BackColor = System.Drawing.Color.Transparent;
            // 
            // tabCntPerson
            // 
            this.tabCntPerson.Controls.Add(this.tblPersonBeneficiaries);
            this.tabCntPerson.Controls.Add(this.tblPersonReferences);
            this.tabCntPerson.Controls.Add(this.tblPersonDocument);
            this.tabCntPerson.Controls.SetChildIndex(this.tblPersonDocument, 0);
            this.tabCntPerson.Controls.SetChildIndex(this.tblPersonReferences, 0);
            this.tabCntPerson.Controls.SetChildIndex(this.tblPersonBeneficiaries, 0);
            this.tabCntPerson.Controls.SetChildIndex(this.tblPerson, 0);
            // 
            // label19
            // 
            this.label19.Size = new System.Drawing.Size(0, 13);
            this.label19.Text = "";
            // 
            // tblPersonDocument
            // 
            this.tblPersonDocument.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tblPersonDocument.Controls.Add(this.btnInsertRemarks);
            this.tblPersonDocument.Controls.Add(this.txtPersonDocumentRemarks);
            this.tblPersonDocument.Controls.Add(this.lsvFileList);
            this.tblPersonDocument.Controls.Add(this.toolSubjectLoad);
            this.tblPersonDocument.Location = new System.Drawing.Point(4, 22);
            this.tblPersonDocument.Name = "tblPersonDocument";
            this.tblPersonDocument.Padding = new System.Windows.Forms.Padding(3);
            this.tblPersonDocument.Size = new System.Drawing.Size(812, 581);
            this.tblPersonDocument.TabIndex = 1;
            this.tblPersonDocument.Text = "Personal Document";
            this.tblPersonDocument.UseVisualStyleBackColor = true;
            // 
            // btnInsertRemarks
            // 
            this.btnInsertRemarks.AutoSize = true;
            this.btnInsertRemarks.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnInsertRemarks.BackgroundImage")));
            this.btnInsertRemarks.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnInsertRemarks.Enabled = false;
            this.btnInsertRemarks.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInsertRemarks.Location = new System.Drawing.Point(705, 518);
            this.btnInsertRemarks.Name = "btnInsertRemarks";
            this.btnInsertRemarks.Size = new System.Drawing.Size(100, 53);
            this.btnInsertRemarks.TabIndex = 7;
            this.btnInsertRemarks.Text = "  Insert";
            this.btnInsertRemarks.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnInsertRemarks.UseVisualStyleBackColor = true;
            // 
            // txtPersonDocumentRemarks
            // 
            this.txtPersonDocumentRemarks.Location = new System.Drawing.Point(6, 518);
            this.txtPersonDocumentRemarks.Multiline = true;
            this.txtPersonDocumentRemarks.Name = "txtPersonDocumentRemarks";
            this.txtPersonDocumentRemarks.Size = new System.Drawing.Size(693, 53);
            this.txtPersonDocumentRemarks.TabIndex = 2;
            // 
            // lsvFileList
            // 
            this.lsvFileList.Cursor = System.Windows.Forms.Cursors.Default;
            this.lsvFileList.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsvFileList.FullRowSelect = true;
            this.lsvFileList.GridLines = true;
            this.lsvFileList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lsvFileList.HideSelection = false;
            this.lsvFileList.Location = new System.Drawing.Point(6, 31);
            this.lsvFileList.MultiSelect = false;
            this.lsvFileList.Name = "lsvFileList";
            this.lsvFileList.ShowGroups = false;
            this.lsvFileList.ShowItemToolTips = true;
            this.lsvFileList.Size = new System.Drawing.Size(799, 481);
            this.lsvFileList.TabIndex = 1;
            this.lsvFileList.UseCompatibleStateImageBehavior = false;
            // 
            // toolSubjectLoad
            // 
            this.toolSubjectLoad.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolSubjectLoad.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnShowDocument,
            this.toolStripSeparator2,
            this.btnAddDocument,
            this.toolStripSeparator1,
            this.btnDropDownIcon});
            this.toolSubjectLoad.Location = new System.Drawing.Point(3, 3);
            this.toolSubjectLoad.Name = "toolSubjectLoad";
            this.toolSubjectLoad.Size = new System.Drawing.Size(802, 25);
            this.toolSubjectLoad.TabIndex = 0;
            // 
            // btnShowDocument
            // 
            this.btnShowDocument.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnShowDocument.Image = ((System.Drawing.Image)(resources.GetObject("btnShowDocument.Image")));
            this.btnShowDocument.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnShowDocument.Name = "btnShowDocument";
            this.btnShowDocument.Size = new System.Drawing.Size(23, 22);
            this.btnShowDocument.Text = "Show person Document";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnAddDocument
            // 
            this.btnAddDocument.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAddDocument.Enabled = false;
            this.btnAddDocument.Image = ((System.Drawing.Image)(resources.GetObject("btnAddDocument.Image")));
            this.btnAddDocument.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddDocument.Name = "btnAddDocument";
            this.btnAddDocument.Size = new System.Drawing.Size(23, 22);
            this.btnAddDocument.Text = "Add Document";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnDropDownIcon
            // 
            this.btnDropDownIcon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnDropDownIcon.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnIcon,
            this.btnList});
            this.btnDropDownIcon.Enabled = false;
            this.btnDropDownIcon.Image = ((System.Drawing.Image)(resources.GetObject("btnDropDownIcon.Image")));
            this.btnDropDownIcon.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDropDownIcon.Name = "btnDropDownIcon";
            this.btnDropDownIcon.Size = new System.Drawing.Size(32, 22);
            this.btnDropDownIcon.Text = "toolStripSplitButton1";
            // 
            // btnIcon
            // 
            this.btnIcon.Name = "btnIcon";
            this.btnIcon.Size = new System.Drawing.Size(111, 22);
            this.btnIcon.Text = "Icons";
            // 
            // btnList
            // 
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(111, 22);
            this.btnList.Text = "List";
            // 
            // tblPersonBeneficiaries
            // 
            this.tblPersonBeneficiaries.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tblPersonBeneficiaries.Controls.Add(this.lblBeneficiariesStatus);
            this.tblPersonBeneficiaries.Controls.Add(this.lblBeneficiaries);
            this.tblPersonBeneficiaries.Controls.Add(this.dgvPersonBenificiaries);
            this.tblPersonBeneficiaries.Controls.Add(this.lnkCreateBeneficiary);
            this.tblPersonBeneficiaries.Location = new System.Drawing.Point(4, 22);
            this.tblPersonBeneficiaries.Name = "tblPersonBeneficiaries";
            this.tblPersonBeneficiaries.Padding = new System.Windows.Forms.Padding(3);
            this.tblPersonBeneficiaries.Size = new System.Drawing.Size(812, 581);
            this.tblPersonBeneficiaries.TabIndex = 2;
            this.tblPersonBeneficiaries.Text = "Beneficiaries";
            this.tblPersonBeneficiaries.UseVisualStyleBackColor = true;
            // 
            // lblBeneficiariesStatus
            // 
            this.lblBeneficiariesStatus.AutoSize = true;
            this.lblBeneficiariesStatus.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBeneficiariesStatus.ForeColor = System.Drawing.Color.Red;
            this.lblBeneficiariesStatus.Location = new System.Drawing.Point(3, 559);
            this.lblBeneficiariesStatus.Name = "lblBeneficiariesStatus";
            this.lblBeneficiariesStatus.Size = new System.Drawing.Size(189, 15);
            this.lblBeneficiariesStatus.TabIndex = 111;
            this.lblBeneficiariesStatus.Text = "No primary beneficiary assigned.";
            this.lblBeneficiariesStatus.Visible = false;
            // 
            // lblBeneficiaries
            // 
            this.lblBeneficiaries.AutoSize = true;
            this.lblBeneficiaries.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBeneficiaries.ForeColor = System.Drawing.Color.Orange;
            this.lblBeneficiaries.Location = new System.Drawing.Point(596, 6);
            this.lblBeneficiaries.Name = "lblBeneficiaries";
            this.lblBeneficiaries.Size = new System.Drawing.Size(210, 20);
            this.lblBeneficiaries.TabIndex = 110;
            this.lblBeneficiaries.Text = "Beneficiaries Information";
            // 
            // dgvPersonBenificiaries
            // 
            this.dgvPersonBenificiaries.AllowUserToAddRows = false;
            this.dgvPersonBenificiaries.AllowUserToDeleteRows = false;
            this.dgvPersonBenificiaries.AllowUserToResizeColumns = false;
            this.dgvPersonBenificiaries.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPersonBenificiaries.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPersonBenificiaries.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dgvPersonBenificiaries.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPersonBenificiaries.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPersonBenificiaries.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPersonBenificiaries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonBenificiaries.Location = new System.Drawing.Point(6, 38);
            this.dgvPersonBenificiaries.Name = "dgvPersonBenificiaries";
            this.dgvPersonBenificiaries.RowHeadersVisible = false;
            this.dgvPersonBenificiaries.RowHeadersWidth = 15;
            this.dgvPersonBenificiaries.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Lavender;
            this.dgvPersonBenificiaries.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPersonBenificiaries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPersonBenificiaries.Size = new System.Drawing.Size(799, 518);
            this.dgvPersonBenificiaries.TabIndex = 0;
            // 
            // lnkCreateBeneficiary
            // 
            this.lnkCreateBeneficiary.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lnkCreateBeneficiary.AutoSize = true;
            this.lnkCreateBeneficiary.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCreateBeneficiary.ForeColor = System.Drawing.Color.DarkBlue;
            this.lnkCreateBeneficiary.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkCreateBeneficiary.Location = new System.Drawing.Point(678, 559);
            this.lnkCreateBeneficiary.Name = "lnkCreateBeneficiary";
            this.lnkCreateBeneficiary.Size = new System.Drawing.Size(126, 15);
            this.lnkCreateBeneficiary.TabIndex = 1;
            this.lnkCreateBeneficiary.TabStop = true;
            this.lnkCreateBeneficiary.Text = "[ Create Beneficiary ]";
            this.lnkCreateBeneficiary.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tblPersonReferences
            // 
            this.tblPersonReferences.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tblPersonReferences.Controls.Add(this.lblReference);
            this.tblPersonReferences.Controls.Add(this.dgvPersonReference);
            this.tblPersonReferences.Controls.Add(this.lnkCreateReference);
            this.tblPersonReferences.Location = new System.Drawing.Point(4, 22);
            this.tblPersonReferences.Name = "tblPersonReferences";
            this.tblPersonReferences.Padding = new System.Windows.Forms.Padding(3);
            this.tblPersonReferences.Size = new System.Drawing.Size(812, 581);
            this.tblPersonReferences.TabIndex = 3;
            this.tblPersonReferences.Text = "References";
            this.tblPersonReferences.UseVisualStyleBackColor = true;
            // 
            // lblReference
            // 
            this.lblReference.AutoSize = true;
            this.lblReference.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReference.ForeColor = System.Drawing.Color.Orange;
            this.lblReference.Location = new System.Drawing.Point(606, 6);
            this.lblReference.Name = "lblReference";
            this.lblReference.Size = new System.Drawing.Size(199, 20);
            this.lblReference.TabIndex = 113;
            this.lblReference.Text = "References Information";
            // 
            // dgvPersonReference
            // 
            this.dgvPersonReference.AllowUserToAddRows = false;
            this.dgvPersonReference.AllowUserToDeleteRows = false;
            this.dgvPersonReference.AllowUserToResizeColumns = false;
            this.dgvPersonReference.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPersonReference.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPersonReference.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dgvPersonReference.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvPersonReference.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPersonReference.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPersonReference.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPersonReference.Location = new System.Drawing.Point(6, 38);
            this.dgvPersonReference.Name = "dgvPersonReference";
            this.dgvPersonReference.RowHeadersVisible = false;
            this.dgvPersonReference.RowHeadersWidth = 15;
            this.dgvPersonReference.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.Lavender;
            this.dgvPersonReference.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPersonReference.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPersonReference.Size = new System.Drawing.Size(799, 518);
            this.dgvPersonReference.TabIndex = 0;
            // 
            // lnkCreateReference
            // 
            this.lnkCreateReference.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lnkCreateReference.AutoSize = true;
            this.lnkCreateReference.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCreateReference.ForeColor = System.Drawing.Color.DarkBlue;
            this.lnkCreateReference.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkCreateReference.Location = new System.Drawing.Point(684, 559);
            this.lnkCreateReference.Name = "lnkCreateReference";
            this.lnkCreateReference.Size = new System.Drawing.Size(121, 15);
            this.lnkCreateReference.TabIndex = 1;
            this.lnkCreateReference.TabStop = true;
            this.lnkCreateReference.Text = "[ Create Reference ]";
            this.lnkCreateReference.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // imgIcon
            // 
            this.imgIcon.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imgIcon.ImageSize = new System.Drawing.Size(50, 50);
            this.imgIcon.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(30, 36);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(0, 13);
            this.label20.TabIndex = 3;
            // 
            // pbxBeneficiaries
            // 
            this.pbxBeneficiaries.BackColor = System.Drawing.Color.Transparent;
            this.pbxBeneficiaries.BackgroundImage = global::BaseServices.Properties.Resources.Beneficiaries3;
            this.pbxBeneficiaries.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxBeneficiaries.Location = new System.Drawing.Point(0, 30);
            this.pbxBeneficiaries.Name = "pbxBeneficiaries";
            this.pbxBeneficiaries.Size = new System.Drawing.Size(161, 25);
            this.pbxBeneficiaries.TabIndex = 2;
            this.pbxBeneficiaries.TabStop = false;
            // 
            // pbxReferences
            // 
            this.pbxReferences.BackColor = System.Drawing.Color.Transparent;
            this.pbxReferences.BackgroundImage = global::BaseServices.Properties.Resources.References1;
            this.pbxReferences.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxReferences.Location = new System.Drawing.Point(0, 58);
            this.pbxReferences.Name = "pbxReferences";
            this.pbxReferences.Size = new System.Drawing.Size(161, 25);
            this.pbxReferences.TabIndex = 4;
            this.pbxReferences.TabStop = false;
            // 
            // pbxPersonalDocument
            // 
            this.pbxPersonalDocument.BackColor = System.Drawing.Color.Transparent;
            this.pbxPersonalDocument.BackgroundImage = global::BaseServices.Properties.Resources.Personal_Documents1;
            this.pbxPersonalDocument.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pbxPersonalDocument.Location = new System.Drawing.Point(0, 86);
            this.pbxPersonalDocument.Name = "pbxPersonalDocument";
            this.pbxPersonalDocument.Size = new System.Drawing.Size(161, 25);
            this.pbxPersonalDocument.TabIndex = 6;
            this.pbxPersonalDocument.TabStop = false;
            // 
            // PersonInformationWithBeneficiaryReference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(994, 712);
            this.Name = "PersonInformationWithBeneficiaryReference";
            ((System.ComponentModel.ISupportInitialize)(this._errProvider)).EndInit();
            this.tblPerson.ResumeLayout(false);
            this.tblPerson.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxGeneralInformation)).EndInit();
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbxPersonImage)).EndInit();
            this.tabCntPerson.ResumeLayout(false);
            this.tblPersonDocument.ResumeLayout(false);
            this.tblPersonDocument.PerformLayout();
            this.toolSubjectLoad.ResumeLayout(false);
            this.toolSubjectLoad.PerformLayout();
            this.tblPersonBeneficiaries.ResumeLayout(false);
            this.tblPersonBeneficiaries.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonBenificiaries)).EndInit();
            this.tblPersonReferences.ResumeLayout(false);
            this.tblPersonReferences.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPersonReference)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxBeneficiaries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxReferences)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbxPersonalDocument)).EndInit();
            this.ResumeLayout(false);

        }

       
       
    }
}
