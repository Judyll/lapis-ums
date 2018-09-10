namespace RegistrarServices
{
    partial class Subject
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.gbxCourseGroup = new System.Windows.Forms.GroupBox();
            this.cboCourseGroup = new System.Windows.Forms.ComboBox();
            this.gbxDepartment = new System.Windows.Forms.GroupBox();
            this.chkIsOpenAccess = new System.Windows.Forms.CheckBox();
            this.cboDepartment = new System.Windows.Forms.ComboBox();
            this.gbxSubject = new System.Windows.Forms.GroupBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.gbxDescriptive = new System.Windows.Forms.GroupBox();
            this.lnkOtherInfo = new System.Windows.Forms.LinkLabel();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.gbxUnits = new System.Windows.Forms.GroupBox();
            this.lblHours = new System.Windows.Forms.Label();
            this.lblLaboratory = new System.Windows.Forms.Label();
            this.lblLecture = new System.Windows.Forms.Label();
            this.optHours = new System.Windows.Forms.RadioButton();
            this.txtLaboratory = new System.Windows.Forms.TextBox();
            this.optUnits = new System.Windows.Forms.RadioButton();
            this.txtLecture = new System.Windows.Forms.TextBox();
            this.gbxPreRequisites = new System.Windows.Forms.GroupBox();
            this.lblResult = new System.Windows.Forms.Label();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.lnkRemove = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.lnkAdd = new System.Windows.Forms.LinkLabel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chkNonAcademic = new System.Windows.Forms.CheckBox();
            this.hrmHours = new RemoteClient.HourMinute();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboSubjectCategory = new System.Windows.Forms.ComboBox();
            this.gbxCourseGroup.SuspendLayout();
            this.gbxDepartment.SuspendLayout();
            this.gbxSubject.SuspendLayout();
            this.gbxDescriptive.SuspendLayout();
            this.gbxUnits.SuspendLayout();
            this.gbxPreRequisites.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(-2, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(575, 58);
            this.panel1.TabIndex = 12;
            // 
            // gbxCourseGroup
            // 
            this.gbxCourseGroup.Controls.Add(this.cboCourseGroup);
            this.gbxCourseGroup.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxCourseGroup.ForeColor = System.Drawing.Color.Navy;
            this.gbxCourseGroup.Location = new System.Drawing.Point(12, 71);
            this.gbxCourseGroup.Name = "gbxCourseGroup";
            this.gbxCourseGroup.Size = new System.Drawing.Size(270, 72);
            this.gbxCourseGroup.TabIndex = 3;
            this.gbxCourseGroup.TabStop = false;
            this.gbxCourseGroup.Text = " COURSE GROUP ";
            // 
            // cboCourseGroup
            // 
            this.cboCourseGroup.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cboCourseGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCourseGroup.FormattingEnabled = true;
            this.cboCourseGroup.Location = new System.Drawing.Point(15, 29);
            this.cboCourseGroup.Name = "cboCourseGroup";
            this.cboCourseGroup.Size = new System.Drawing.Size(236, 23);
            this.cboCourseGroup.TabIndex = 0;
            // 
            // gbxDepartment
            // 
            this.gbxDepartment.Controls.Add(this.chkIsOpenAccess);
            this.gbxDepartment.Controls.Add(this.cboDepartment);
            this.gbxDepartment.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxDepartment.ForeColor = System.Drawing.Color.Navy;
            this.gbxDepartment.Location = new System.Drawing.Point(12, 152);
            this.gbxDepartment.Name = "gbxDepartment";
            this.gbxDepartment.Size = new System.Drawing.Size(270, 85);
            this.gbxDepartment.TabIndex = 0;
            this.gbxDepartment.TabStop = false;
            this.gbxDepartment.Text = " DEPARTMENT ";
            // 
            // chkIsOpenAccess
            // 
            this.chkIsOpenAccess.AutoSize = true;
            this.chkIsOpenAccess.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsOpenAccess.ForeColor = System.Drawing.Color.Maroon;
            this.chkIsOpenAccess.Location = new System.Drawing.Point(15, 58);
            this.chkIsOpenAccess.Name = "chkIsOpenAccess";
            this.chkIsOpenAccess.Size = new System.Drawing.Size(101, 19);
            this.chkIsOpenAccess.TabIndex = 73;
            this.chkIsOpenAccess.Text = "Is open access";
            this.chkIsOpenAccess.UseVisualStyleBackColor = true;
            // 
            // cboDepartment
            // 
            this.cboDepartment.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDepartment.FormattingEnabled = true;
            this.cboDepartment.Location = new System.Drawing.Point(15, 26);
            this.cboDepartment.Name = "cboDepartment";
            this.cboDepartment.Size = new System.Drawing.Size(239, 23);
            this.cboDepartment.TabIndex = 0;
            // 
            // gbxSubject
            // 
            this.gbxSubject.Controls.Add(this.txtCode);
            this.gbxSubject.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxSubject.ForeColor = System.Drawing.Color.Navy;
            this.gbxSubject.Location = new System.Drawing.Point(12, 243);
            this.gbxSubject.Name = "gbxSubject";
            this.gbxSubject.Size = new System.Drawing.Size(270, 72);
            this.gbxSubject.TabIndex = 1;
            this.gbxSubject.TabStop = false;
            this.gbxSubject.Text = " SUBJECT CODE ";
            // 
            // txtCode
            // 
            this.txtCode.BackColor = System.Drawing.Color.White;
            this.txtCode.Location = new System.Drawing.Point(15, 31);
            this.txtCode.MaxLength = 9;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(239, 23);
            this.txtCode.TabIndex = 0;
            this.txtCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbxDescriptive
            // 
            this.gbxDescriptive.Controls.Add(this.lnkOtherInfo);
            this.gbxDescriptive.Controls.Add(this.txtTitle);
            this.gbxDescriptive.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxDescriptive.ForeColor = System.Drawing.Color.Navy;
            this.gbxDescriptive.Location = new System.Drawing.Point(12, 321);
            this.gbxDescriptive.Name = "gbxDescriptive";
            this.gbxDescriptive.Size = new System.Drawing.Size(546, 72);
            this.gbxDescriptive.TabIndex = 2;
            this.gbxDescriptive.TabStop = false;
            this.gbxDescriptive.Text = " DESCRIPTIVE TITLE ";
            // 
            // lnkOtherInfo
            // 
            this.lnkOtherInfo.AutoSize = true;
            this.lnkOtherInfo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkOtherInfo.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkOtherInfo.Location = new System.Drawing.Point(412, 34);
            this.lnkOtherInfo.Name = "lnkOtherInfo";
            this.lnkOtherInfo.Size = new System.Drawing.Size(120, 15);
            this.lnkOtherInfo.TabIndex = 1;
            this.lnkOtherInfo.TabStop = true;
            this.lnkOtherInfo.Text = "[ Other Information ]";
            // 
            // txtTitle
            // 
            this.txtTitle.BackColor = System.Drawing.Color.White;
            this.txtTitle.Location = new System.Drawing.Point(15, 31);
            this.txtTitle.MaxLength = 100;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(383, 23);
            this.txtTitle.TabIndex = 0;
            this.txtTitle.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // gbxUnits
            // 
            this.gbxUnits.Controls.Add(this.lblHours);
            this.gbxUnits.Controls.Add(this.lblLaboratory);
            this.gbxUnits.Controls.Add(this.lblLecture);
            this.gbxUnits.Controls.Add(this.optHours);
            this.gbxUnits.Controls.Add(this.txtLaboratory);
            this.gbxUnits.Controls.Add(this.optUnits);
            this.gbxUnits.Controls.Add(this.txtLecture);
            this.gbxUnits.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxUnits.ForeColor = System.Drawing.Color.Navy;
            this.gbxUnits.Location = new System.Drawing.Point(288, 71);
            this.gbxUnits.Name = "gbxUnits";
            this.gbxUnits.Size = new System.Drawing.Size(270, 166);
            this.gbxUnits.TabIndex = 4;
            this.gbxUnits.TabStop = false;
            this.gbxUnits.Text = " UNITS/HOURS EQUIVALENT ";
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHours.ForeColor = System.Drawing.Color.Black;
            this.lblHours.Location = new System.Drawing.Point(164, 126);
            this.lblHours.Name = "lblHours";
            this.lblHours.Size = new System.Drawing.Size(90, 15);
            this.lblHours.TabIndex = 6;
            this.lblHours.Text = "Hours/Minutes";
            // 
            // lblLaboratory
            // 
            this.lblLaboratory.AutoSize = true;
            this.lblLaboratory.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLaboratory.ForeColor = System.Drawing.Color.Black;
            this.lblLaboratory.Location = new System.Drawing.Point(164, 62);
            this.lblLaboratory.Name = "lblLaboratory";
            this.lblLaboratory.Size = new System.Drawing.Size(96, 15);
            this.lblLaboratory.TabIndex = 5;
            this.lblLaboratory.Text = "Laboratory / RLE";
            // 
            // lblLecture
            // 
            this.lblLecture.AutoSize = true;
            this.lblLecture.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLecture.ForeColor = System.Drawing.Color.Black;
            this.lblLecture.Location = new System.Drawing.Point(164, 36);
            this.lblLecture.Name = "lblLecture";
            this.lblLecture.Size = new System.Drawing.Size(46, 15);
            this.lblLecture.TabIndex = 4;
            this.lblLecture.Text = "Lecture";
            // 
            // optHours
            // 
            this.optHours.AutoSize = true;
            this.optHours.Location = new System.Drawing.Point(31, 96);
            this.optHours.Name = "optHours";
            this.optHours.Size = new System.Drawing.Size(70, 19);
            this.optHours.TabIndex = 3;
            this.optHours.Text = "In Hours";
            this.optHours.UseVisualStyleBackColor = true;
            // 
            // txtLaboratory
            // 
            this.txtLaboratory.BackColor = System.Drawing.Color.White;
            this.txtLaboratory.Location = new System.Drawing.Point(130, 60);
            this.txtLaboratory.MaxLength = 2;
            this.txtLaboratory.Name = "txtLaboratory";
            this.txtLaboratory.Size = new System.Drawing.Size(28, 23);
            this.txtLaboratory.TabIndex = 2;
            this.txtLaboratory.Text = "0";
            this.txtLaboratory.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // optUnits
            // 
            this.optUnits.AutoSize = true;
            this.optUnits.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optUnits.Location = new System.Drawing.Point(31, 32);
            this.optUnits.Name = "optUnits";
            this.optUnits.Size = new System.Drawing.Size(66, 19);
            this.optUnits.TabIndex = 0;
            this.optUnits.Text = "In Units";
            this.optUnits.UseVisualStyleBackColor = true;
            // 
            // txtLecture
            // 
            this.txtLecture.BackColor = System.Drawing.Color.White;
            this.txtLecture.Location = new System.Drawing.Point(130, 33);
            this.txtLecture.MaxLength = 2;
            this.txtLecture.Name = "txtLecture";
            this.txtLecture.Size = new System.Drawing.Size(28, 23);
            this.txtLecture.TabIndex = 1;
            this.txtLecture.Text = "0";
            this.txtLecture.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gbxPreRequisites
            // 
            this.gbxPreRequisites.Controls.Add(this.lblResult);
            this.gbxPreRequisites.Controls.Add(this.dgvList);
            this.gbxPreRequisites.Controls.Add(this.lnkRemove);
            this.gbxPreRequisites.Controls.Add(this.label1);
            this.gbxPreRequisites.Controls.Add(this.lnkAdd);
            this.gbxPreRequisites.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxPreRequisites.ForeColor = System.Drawing.Color.Navy;
            this.gbxPreRequisites.Location = new System.Drawing.Point(12, 399);
            this.gbxPreRequisites.Name = "gbxPreRequisites";
            this.gbxPreRequisites.Size = new System.Drawing.Size(546, 227);
            this.gbxPreRequisites.TabIndex = 6;
            this.gbxPreRequisites.TabStop = false;
            this.gbxPreRequisites.Text = " PRE-REQUISITES ";
            // 
            // lblResult
            // 
            this.lblResult.AllowDrop = true;
            this.lblResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lblResult.AutoSize = true;
            this.lblResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.ForeColor = System.Drawing.Color.Maroon;
            this.lblResult.Location = new System.Drawing.Point(49, 207);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(47, 13);
            this.lblResult.TabIndex = 63;
            this.lblResult.Text = "Result:";
            // 
            // dgvList
            // 
            this.dgvList.AllowDrop = true;
            this.dgvList.AllowUserToAddRows = false;
            this.dgvList.AllowUserToDeleteRows = false;
            this.dgvList.AllowUserToResizeColumns = false;
            this.dgvList.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgvList.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvList.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgvList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvList.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.DarkSlateBlue;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Location = new System.Drawing.Point(15, 22);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowHeadersWidth = 15;
            this.dgvList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.Lavender;
            this.dgvList.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvList.Size = new System.Drawing.Size(518, 182);
            this.dgvList.TabIndex = 2;
            // 
            // lnkRemove
            // 
            this.lnkRemove.AllowDrop = true;
            this.lnkRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkRemove.AutoSize = true;
            this.lnkRemove.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkRemove.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkRemove.Location = new System.Drawing.Point(467, 207);
            this.lnkRemove.Name = "lnkRemove";
            this.lnkRemove.Size = new System.Drawing.Size(63, 15);
            this.lnkRemove.TabIndex = 1;
            this.lnkRemove.TabStop = true;
            this.lnkRemove.Text = "[ Remove ]";
            // 
            // label1
            // 
            this.label1.AllowDrop = true;
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Maroon;
            this.label1.Location = new System.Drawing.Point(6, 207);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 62;
            this.label1.Text = "Count:";
            // 
            // lnkAdd
            // 
            this.lnkAdd.AllowDrop = true;
            this.lnkAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkAdd.AutoSize = true;
            this.lnkAdd.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkAdd.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkAdd.Location = new System.Drawing.Point(428, 207);
            this.lnkAdd.Name = "lnkAdd";
            this.lnkAdd.Size = new System.Drawing.Size(42, 15);
            this.lnkAdd.TabIndex = 0;
            this.lnkAdd.TabStop = true;
            this.lnkAdd.Text = "[ Add ]";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.chkNonAcademic);
            this.panel2.Location = new System.Drawing.Point(-2, 638);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(575, 40);
            this.panel2.TabIndex = 7;
            // 
            // chkNonAcademic
            // 
            this.chkNonAcademic.AutoSize = true;
            this.chkNonAcademic.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkNonAcademic.ForeColor = System.Drawing.Color.Maroon;
            this.chkNonAcademic.Location = new System.Drawing.Point(14, 13);
            this.chkNonAcademic.Name = "chkNonAcademic";
            this.chkNonAcademic.Size = new System.Drawing.Size(154, 19);
            this.chkNonAcademic.TabIndex = 72;
            this.chkNonAcademic.Text = "Non - Academic Subject";
            this.chkNonAcademic.UseVisualStyleBackColor = true;
            // 
            // hrmHours
            // 
            this.hrmHours.Hours = 0;
            this.hrmHours.Location = new System.Drawing.Point(347, 189);
            this.hrmHours.Minutes = 0;
            this.hrmHours.Name = "hrmHours";
            this.hrmHours.Size = new System.Drawing.Size(105, 30);
            this.hrmHours.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboSubjectCategory);
            this.groupBox1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.Navy;
            this.groupBox1.Location = new System.Drawing.Point(288, 243);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(270, 72);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " SUBJECT CATEGORY ";
            // 
            // cboSubjectCategory
            // 
            this.cboSubjectCategory.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.cboSubjectCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubjectCategory.FormattingEnabled = true;
            this.cboSubjectCategory.Location = new System.Drawing.Point(15, 29);
            this.cboSubjectCategory.Name = "cboSubjectCategory";
            this.cboSubjectCategory.Size = new System.Drawing.Size(236, 23);
            this.cboSubjectCategory.TabIndex = 0;
            // 
            // Subject
            // 
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(570, 678);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.hrmHours);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.gbxPreRequisites);
            this.Controls.Add(this.gbxUnits);
            this.Controls.Add(this.gbxDepartment);
            this.Controls.Add(this.gbxDescriptive);
            this.Controls.Add(this.gbxSubject);
            this.Controls.Add(this.gbxCourseGroup);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Subject";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.gbxCourseGroup.ResumeLayout(false);
            this.gbxDepartment.ResumeLayout(false);
            this.gbxDepartment.PerformLayout();
            this.gbxSubject.ResumeLayout(false);
            this.gbxSubject.PerformLayout();
            this.gbxDescriptive.ResumeLayout(false);
            this.gbxDescriptive.PerformLayout();
            this.gbxUnits.ResumeLayout(false);
            this.gbxUnits.PerformLayout();
            this.gbxPreRequisites.ResumeLayout(false);
            this.gbxPreRequisites.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxCourseGroup;
        private System.Windows.Forms.GroupBox gbxDepartment;
        private System.Windows.Forms.GroupBox gbxSubject;
        private System.Windows.Forms.GroupBox gbxDescriptive;
        private System.Windows.Forms.GroupBox gbxUnits;
        private System.Windows.Forms.Label lblLaboratory;
        private System.Windows.Forms.Label lblLecture;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.GroupBox gbxPreRequisites;
        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.ComboBox cboCourseGroup;
        protected System.Windows.Forms.ComboBox cboDepartment;
        protected System.Windows.Forms.TextBox txtCode;
        protected System.Windows.Forms.TextBox txtTitle;
        protected System.Windows.Forms.RadioButton optHours;
        protected System.Windows.Forms.RadioButton optUnits;
        protected System.Windows.Forms.TextBox txtLecture;
        protected System.Windows.Forms.TextBox txtLaboratory;
        protected System.Windows.Forms.Panel panel2;
        protected System.Windows.Forms.LinkLabel lnkOtherInfo;
        protected RemoteClient.HourMinute hrmHours;
        protected System.Windows.Forms.LinkLabel lnkRemove;
        protected System.Windows.Forms.LinkLabel lnkAdd;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label label1;
        protected System.Windows.Forms.DataGridView dgvList;
        protected System.Windows.Forms.CheckBox chkNonAcademic;
        protected System.Windows.Forms.CheckBox chkIsOpenAccess;
        private System.Windows.Forms.GroupBox groupBox1;
        protected System.Windows.Forms.ComboBox cboSubjectCategory;
    }
}