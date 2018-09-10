namespace OfficeServices
{
    partial class SubjectScheduleDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SubjectScheduleDetails));
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tblRoomUnits = new System.Windows.Forms.TabPage();
            this.pbxUnlock = new System.Windows.Forms.PictureBox();
            this.label16 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblUnitsLabHours = new System.Windows.Forms.Label();
            this.lblSysIdSubject = new System.Windows.Forms.Label();
            this.lblSubjectDepartment = new System.Windows.Forms.Label();
            this.lblSubjectCodeDescription = new System.Windows.Forms.Label();
            this.gbxClassroom = new System.Windows.Forms.GroupBox();
            this.pnlFieldRoom = new System.Windows.Forms.Panel();
            this.lblFieldRoomTime = new System.Windows.Forms.Label();
            this.lnkEditTimeFieldRoom = new System.Windows.Forms.LinkLabel();
            this.pnlClassroomBased = new System.Windows.Forms.Panel();
            this.lblEditTimeClassroomBased = new System.Windows.Forms.Label();
            this.lnkEdit = new System.Windows.Forms.LinkLabel();
            this.optTBA = new System.Windows.Forms.RadioButton();
            this.lblMaxCapacity = new System.Windows.Forms.Label();
            this.lblClassroomCode = new System.Windows.Forms.Label();
            this.lblMCapacity = new System.Windows.Forms.Label();
            this.lblClassCode = new System.Windows.Forms.Label();
            this.txtFieldRoom = new System.Windows.Forms.TextBox();
            this.optCampus = new System.Windows.Forms.RadioButton();
            this.optField = new System.Windows.Forms.RadioButton();
            this.gbxUnits = new System.Windows.Forms.GroupBox();
            this.hrmHours = new RemoteClient.HourMinute();
            this.lblHours = new System.Windows.Forms.Label();
            this.lblLaboratory = new System.Windows.Forms.Label();
            this.lblLecture = new System.Windows.Forms.Label();
            this.optHours = new System.Windows.Forms.RadioButton();
            this.txtLaboratory = new System.Windows.Forms.TextBox();
            this.optUnits = new System.Windows.Forms.RadioButton();
            this.txtLecture = new System.Windows.Forms.TextBox();
            this.gbxSection = new System.Windows.Forms.GroupBox();
            this.txtSection = new System.Windows.Forms.TextBox();
            this.pbxLocked = new System.Windows.Forms.PictureBox();
            this.tabDetails = new System.Windows.Forms.TabControl();
            this.tblRoomUnits.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUnlock)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.gbxClassroom.SuspendLayout();
            this.pnlFieldRoom.SuspendLayout();
            this.pnlClassroomBased.SuspendLayout();
            this.gbxUnits.SuspendLayout();
            this.gbxSection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLocked)).BeginInit();
            this.tabDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(594, 58);
            this.panel1.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Location = new System.Drawing.Point(1, 561);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(593, 34);
            this.panel2.TabIndex = 9;
            // 
            // tblRoomUnits
            // 
            this.tblRoomUnits.Controls.Add(this.pbxUnlock);
            this.tblRoomUnits.Controls.Add(this.label16);
            this.tblRoomUnits.Controls.Add(this.lblStatus);
            this.tblRoomUnits.Controls.Add(this.groupBox2);
            this.tblRoomUnits.Controls.Add(this.gbxClassroom);
            this.tblRoomUnits.Controls.Add(this.gbxUnits);
            this.tblRoomUnits.Controls.Add(this.gbxSection);
            this.tblRoomUnits.Controls.Add(this.pbxLocked);
            this.tblRoomUnits.Location = new System.Drawing.Point(4, 23);
            this.tblRoomUnits.Name = "tblRoomUnits";
            this.tblRoomUnits.Padding = new System.Windows.Forms.Padding(3);
            this.tblRoomUnits.Size = new System.Drawing.Size(560, 464);
            this.tblRoomUnits.TabIndex = 0;
            this.tblRoomUnits.Text = "Room and Units / Hours Equivalent";
            this.tblRoomUnits.UseVisualStyleBackColor = true;
            // 
            // pbxUnlock
            // 
            this.pbxUnlock.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbxUnlock.BackgroundImage")));
            this.pbxUnlock.Location = new System.Drawing.Point(10, 437);
            this.pbxUnlock.Name = "pbxUnlock";
            this.pbxUnlock.Size = new System.Drawing.Size(24, 24);
            this.pbxUnlock.TabIndex = 89;
            this.pbxUnlock.TabStop = false;
            this.pbxUnlock.Visible = false;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.Orange;
            this.label16.Location = new System.Drawing.Point(261, 7);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(290, 20);
            this.label16.TabIndex = 88;
            this.label16.Text = "Room and Units / Hours Equivalent";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.ForeColor = System.Drawing.Color.Red;
            this.lblStatus.Location = new System.Drawing.Point(33, 446);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(126, 13);
            this.lblStatus.TabIndex = 73;
            this.lblStatus.Text = "This record is OPEN.";
            this.lblStatus.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.lblUnitsLabHours);
            this.groupBox2.Controls.Add(this.lblSysIdSubject);
            this.groupBox2.Controls.Add(this.lblSubjectDepartment);
            this.groupBox2.Controls.Add(this.lblSubjectCodeDescription);
            this.groupBox2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Navy;
            this.groupBox2.Location = new System.Drawing.Point(7, 23);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(544, 130);
            this.groupBox2.TabIndex = 20;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = " SUBJECT ";
            // 
            // lblUnitsLabHours
            // 
            this.lblUnitsLabHours.AutoSize = true;
            this.lblUnitsLabHours.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUnitsLabHours.ForeColor = System.Drawing.Color.Black;
            this.lblUnitsLabHours.Location = new System.Drawing.Point(16, 99);
            this.lblUnitsLabHours.Name = "lblUnitsLabHours";
            this.lblUnitsLabHours.Size = new System.Drawing.Size(16, 16);
            this.lblUnitsLabHours.TabIndex = 20;
            this.lblUnitsLabHours.Text = "--";
            // 
            // lblSysIdSubject
            // 
            this.lblSysIdSubject.AutoSize = true;
            this.lblSysIdSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSysIdSubject.ForeColor = System.Drawing.Color.Black;
            this.lblSysIdSubject.Location = new System.Drawing.Point(16, 25);
            this.lblSysIdSubject.Name = "lblSysIdSubject";
            this.lblSysIdSubject.Size = new System.Drawing.Size(16, 16);
            this.lblSysIdSubject.TabIndex = 18;
            this.lblSysIdSubject.Text = "--";
            // 
            // lblSubjectDepartment
            // 
            this.lblSubjectDepartment.AutoSize = true;
            this.lblSubjectDepartment.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubjectDepartment.ForeColor = System.Drawing.Color.DimGray;
            this.lblSubjectDepartment.Location = new System.Drawing.Point(16, 75);
            this.lblSubjectDepartment.Name = "lblSubjectDepartment";
            this.lblSubjectDepartment.Size = new System.Drawing.Size(18, 16);
            this.lblSubjectDepartment.TabIndex = 21;
            this.lblSubjectDepartment.Text = "--";
            // 
            // lblSubjectCodeDescription
            // 
            this.lblSubjectCodeDescription.AutoSize = true;
            this.lblSubjectCodeDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubjectCodeDescription.ForeColor = System.Drawing.Color.Black;
            this.lblSubjectCodeDescription.Location = new System.Drawing.Point(16, 49);
            this.lblSubjectCodeDescription.Name = "lblSubjectCodeDescription";
            this.lblSubjectCodeDescription.Size = new System.Drawing.Size(187, 18);
            this.lblSubjectCodeDescription.TabIndex = 19;
            this.lblSubjectCodeDescription.Text = "Please select a subject.";
            // 
            // gbxClassroom
            // 
            this.gbxClassroom.BackColor = System.Drawing.Color.Transparent;
            this.gbxClassroom.Controls.Add(this.pnlFieldRoom);
            this.gbxClassroom.Controls.Add(this.lnkEditTimeFieldRoom);
            this.gbxClassroom.Controls.Add(this.pnlClassroomBased);
            this.gbxClassroom.Controls.Add(this.lnkEdit);
            this.gbxClassroom.Controls.Add(this.optTBA);
            this.gbxClassroom.Controls.Add(this.lblMaxCapacity);
            this.gbxClassroom.Controls.Add(this.lblClassroomCode);
            this.gbxClassroom.Controls.Add(this.lblMCapacity);
            this.gbxClassroom.Controls.Add(this.lblClassCode);
            this.gbxClassroom.Controls.Add(this.txtFieldRoom);
            this.gbxClassroom.Controls.Add(this.optCampus);
            this.gbxClassroom.Controls.Add(this.optField);
            this.gbxClassroom.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxClassroom.ForeColor = System.Drawing.Color.Navy;
            this.gbxClassroom.Location = new System.Drawing.Point(8, 159);
            this.gbxClassroom.Name = "gbxClassroom";
            this.gbxClassroom.Size = new System.Drawing.Size(270, 272);
            this.gbxClassroom.TabIndex = 7;
            this.gbxClassroom.TabStop = false;
            this.gbxClassroom.Text = " CLASSROOM ";
            // 
            // pnlFieldRoom
            // 
            this.pnlFieldRoom.AutoScroll = true;
            this.pnlFieldRoom.BackColor = System.Drawing.Color.White;
            this.pnlFieldRoom.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlFieldRoom.Controls.Add(this.lblFieldRoomTime);
            this.pnlFieldRoom.Location = new System.Drawing.Point(36, 106);
            this.pnlFieldRoom.Name = "pnlFieldRoom";
            this.pnlFieldRoom.Size = new System.Drawing.Size(184, 43);
            this.pnlFieldRoom.TabIndex = 76;
            // 
            // lblFieldRoomTime
            // 
            this.lblFieldRoomTime.AutoSize = true;
            this.lblFieldRoomTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFieldRoomTime.ForeColor = System.Drawing.Color.Maroon;
            this.lblFieldRoomTime.Location = new System.Drawing.Point(6, 5);
            this.lblFieldRoomTime.Name = "lblFieldRoomTime";
            this.lblFieldRoomTime.Size = new System.Drawing.Size(11, 13);
            this.lblFieldRoomTime.TabIndex = 23;
            this.lblFieldRoomTime.Text = "-";
            this.lblFieldRoomTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lnkEditTimeFieldRoom
            // 
            this.lnkEditTimeFieldRoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkEditTimeFieldRoom.AutoSize = true;
            this.lnkEditTimeFieldRoom.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkEditTimeFieldRoom.ForeColor = System.Drawing.Color.DarkBlue;
            this.lnkEditTimeFieldRoom.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkEditTimeFieldRoom.Location = new System.Drawing.Point(220, 132);
            this.lnkEditTimeFieldRoom.Name = "lnkEditTimeFieldRoom";
            this.lnkEditTimeFieldRoom.Size = new System.Drawing.Size(49, 15);
            this.lnkEditTimeFieldRoom.TabIndex = 75;
            this.lnkEditTimeFieldRoom.TabStop = true;
            this.lnkEditTimeFieldRoom.Text = "[ Time ]";
            this.lnkEditTimeFieldRoom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnkEditTimeFieldRoom.Visible = false;
            // 
            // pnlClassroomBased
            // 
            this.pnlClassroomBased.AutoScroll = true;
            this.pnlClassroomBased.BackColor = System.Drawing.Color.White;
            this.pnlClassroomBased.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlClassroomBased.Controls.Add(this.lblEditTimeClassroomBased);
            this.pnlClassroomBased.Location = new System.Drawing.Point(36, 220);
            this.pnlClassroomBased.Name = "pnlClassroomBased";
            this.pnlClassroomBased.Size = new System.Drawing.Size(184, 43);
            this.pnlClassroomBased.TabIndex = 74;
            // 
            // lblEditTimeClassroomBased
            // 
            this.lblEditTimeClassroomBased.AutoSize = true;
            this.lblEditTimeClassroomBased.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEditTimeClassroomBased.ForeColor = System.Drawing.Color.Maroon;
            this.lblEditTimeClassroomBased.Location = new System.Drawing.Point(6, 5);
            this.lblEditTimeClassroomBased.Name = "lblEditTimeClassroomBased";
            this.lblEditTimeClassroomBased.Size = new System.Drawing.Size(11, 13);
            this.lblEditTimeClassroomBased.TabIndex = 23;
            this.lblEditTimeClassroomBased.Text = "-";
            this.lblEditTimeClassroomBased.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lnkEdit
            // 
            this.lnkEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkEdit.AutoSize = true;
            this.lnkEdit.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkEdit.ForeColor = System.Drawing.Color.DarkBlue;
            this.lnkEdit.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkEdit.Location = new System.Drawing.Point(220, 244);
            this.lnkEdit.Name = "lnkEdit";
            this.lnkEdit.Size = new System.Drawing.Size(49, 15);
            this.lnkEdit.TabIndex = 73;
            this.lnkEdit.TabStop = true;
            this.lnkEdit.Text = "[ Time ]";
            this.lnkEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnkEdit.Visible = false;
            // 
            // optTBA
            // 
            this.optTBA.AutoSize = true;
            this.optTBA.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optTBA.ForeColor = System.Drawing.Color.Maroon;
            this.optTBA.Location = new System.Drawing.Point(12, 19);
            this.optTBA.Name = "optTBA";
            this.optTBA.Size = new System.Drawing.Size(133, 23);
            this.optTBA.TabIndex = 25;
            this.optTBA.Text = "To be Arranged";
            this.optTBA.UseVisualStyleBackColor = true;
            // 
            // lblMaxCapacity
            // 
            this.lblMaxCapacity.AutoSize = true;
            this.lblMaxCapacity.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaxCapacity.ForeColor = System.Drawing.Color.Black;
            this.lblMaxCapacity.Location = new System.Drawing.Point(139, 201);
            this.lblMaxCapacity.Name = "lblMaxCapacity";
            this.lblMaxCapacity.Size = new System.Drawing.Size(16, 16);
            this.lblMaxCapacity.TabIndex = 24;
            this.lblMaxCapacity.Text = "--";
            this.lblMaxCapacity.Visible = false;
            // 
            // lblClassroomCode
            // 
            this.lblClassroomCode.AutoSize = true;
            this.lblClassroomCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassroomCode.ForeColor = System.Drawing.Color.Black;
            this.lblClassroomCode.Location = new System.Drawing.Point(139, 183);
            this.lblClassroomCode.Name = "lblClassroomCode";
            this.lblClassroomCode.Size = new System.Drawing.Size(16, 16);
            this.lblClassroomCode.TabIndex = 23;
            this.lblClassroomCode.Text = "--";
            this.lblClassroomCode.Visible = false;
            // 
            // lblMCapacity
            // 
            this.lblMCapacity.AutoSize = true;
            this.lblMCapacity.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMCapacity.ForeColor = System.Drawing.Color.DimGray;
            this.lblMCapacity.Location = new System.Drawing.Point(33, 204);
            this.lblMCapacity.Name = "lblMCapacity";
            this.lblMCapacity.Size = new System.Drawing.Size(95, 13);
            this.lblMCapacity.TabIndex = 22;
            this.lblMCapacity.Text = "Max. Capacity :";
            this.lblMCapacity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblMCapacity.Visible = false;
            // 
            // lblClassCode
            // 
            this.lblClassCode.AutoSize = true;
            this.lblClassCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClassCode.ForeColor = System.Drawing.Color.DimGray;
            this.lblClassCode.Location = new System.Drawing.Point(33, 186);
            this.lblClassCode.Name = "lblClassCode";
            this.lblClassCode.Size = new System.Drawing.Size(105, 13);
            this.lblClassCode.TabIndex = 21;
            this.lblClassCode.Text = "Classroom Code :";
            this.lblClassCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblClassCode.Visible = false;
            // 
            // txtFieldRoom
            // 
            this.txtFieldRoom.BackColor = System.Drawing.Color.White;
            this.txtFieldRoom.Location = new System.Drawing.Point(36, 74);
            this.txtFieldRoom.MaxLength = 50;
            this.txtFieldRoom.Name = "txtFieldRoom";
            this.txtFieldRoom.Size = new System.Drawing.Size(217, 23);
            this.txtFieldRoom.TabIndex = 1;
            this.txtFieldRoom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFieldRoom.Visible = false;
            this.txtFieldRoom.WordWrap = false;
            // 
            // optCampus
            // 
            this.optCampus.AutoSize = true;
            this.optCampus.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optCampus.ForeColor = System.Drawing.Color.Maroon;
            this.optCampus.Location = new System.Drawing.Point(12, 161);
            this.optCampus.Name = "optCampus";
            this.optCampus.Size = new System.Drawing.Size(141, 23);
            this.optCampus.TabIndex = 2;
            this.optCampus.Text = "Classroom-Based";
            this.optCampus.UseVisualStyleBackColor = true;
            // 
            // optField
            // 
            this.optField.AutoSize = true;
            this.optField.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optField.ForeColor = System.Drawing.Color.Maroon;
            this.optField.Location = new System.Drawing.Point(12, 47);
            this.optField.Name = "optField";
            this.optField.Size = new System.Drawing.Size(98, 23);
            this.optField.TabIndex = 0;
            this.optField.Text = "Field / OJT";
            this.optField.UseVisualStyleBackColor = true;
            // 
            // gbxUnits
            // 
            this.gbxUnits.Controls.Add(this.hrmHours);
            this.gbxUnits.Controls.Add(this.lblHours);
            this.gbxUnits.Controls.Add(this.lblLaboratory);
            this.gbxUnits.Controls.Add(this.lblLecture);
            this.gbxUnits.Controls.Add(this.optHours);
            this.gbxUnits.Controls.Add(this.txtLaboratory);
            this.gbxUnits.Controls.Add(this.optUnits);
            this.gbxUnits.Controls.Add(this.txtLecture);
            this.gbxUnits.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxUnits.ForeColor = System.Drawing.Color.Navy;
            this.gbxUnits.Location = new System.Drawing.Point(284, 159);
            this.gbxUnits.Name = "gbxUnits";
            this.gbxUnits.Size = new System.Drawing.Size(270, 149);
            this.gbxUnits.TabIndex = 5;
            this.gbxUnits.TabStop = false;
            this.gbxUnits.Text = " UNITS/HOURS EQUIVALENT ";
            // 
            // hrmHours
            // 
            this.hrmHours.Enabled = false;
            this.hrmHours.Location = new System.Drawing.Point(40, 97);
            this.hrmHours.Name = "hrmHours";
            this.hrmHours.Size = new System.Drawing.Size(122, 35);
            this.hrmHours.TabIndex = 7;
            // 
            // lblHours
            // 
            this.lblHours.AutoSize = true;
            this.lblHours.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHours.ForeColor = System.Drawing.Color.Black;
            this.lblHours.Location = new System.Drawing.Point(164, 107);
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
            this.lblLaboratory.Location = new System.Drawing.Point(164, 55);
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
            this.lblLecture.Location = new System.Drawing.Point(164, 29);
            this.lblLecture.Name = "lblLecture";
            this.lblLecture.Size = new System.Drawing.Size(46, 15);
            this.lblLecture.TabIndex = 4;
            this.lblLecture.Text = "Lecture";
            // 
            // optHours
            // 
            this.optHours.AutoSize = true;
            this.optHours.Location = new System.Drawing.Point(31, 78);
            this.optHours.Name = "optHours";
            this.optHours.Size = new System.Drawing.Size(70, 19);
            this.optHours.TabIndex = 3;
            this.optHours.Text = "In Hours";
            this.optHours.UseVisualStyleBackColor = true;
            // 
            // txtLaboratory
            // 
            this.txtLaboratory.BackColor = System.Drawing.Color.White;
            this.txtLaboratory.Enabled = false;
            this.txtLaboratory.Location = new System.Drawing.Point(114, 51);
            this.txtLaboratory.MaxLength = 5;
            this.txtLaboratory.Name = "txtLaboratory";
            this.txtLaboratory.Size = new System.Drawing.Size(44, 23);
            this.txtLaboratory.TabIndex = 2;
            this.txtLaboratory.Text = "0";
            this.txtLaboratory.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // optUnits
            // 
            this.optUnits.AutoSize = true;
            this.optUnits.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optUnits.Location = new System.Drawing.Point(31, 22);
            this.optUnits.Name = "optUnits";
            this.optUnits.Size = new System.Drawing.Size(66, 19);
            this.optUnits.TabIndex = 0;
            this.optUnits.Text = "In Units";
            this.optUnits.UseVisualStyleBackColor = true;
            // 
            // txtLecture
            // 
            this.txtLecture.BackColor = System.Drawing.Color.White;
            this.txtLecture.Enabled = false;
            this.txtLecture.Location = new System.Drawing.Point(114, 24);
            this.txtLecture.MaxLength = 5;
            this.txtLecture.Name = "txtLecture";
            this.txtLecture.Size = new System.Drawing.Size(44, 23);
            this.txtLecture.TabIndex = 1;
            this.txtLecture.Text = "0";
            this.txtLecture.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // gbxSection
            // 
            this.gbxSection.Controls.Add(this.txtSection);
            this.gbxSection.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbxSection.ForeColor = System.Drawing.Color.Navy;
            this.gbxSection.Location = new System.Drawing.Point(284, 314);
            this.gbxSection.Name = "gbxSection";
            this.gbxSection.Size = new System.Drawing.Size(270, 54);
            this.gbxSection.TabIndex = 6;
            this.gbxSection.TabStop = false;
            this.gbxSection.Text = " SECTION ";
            // 
            // txtSection
            // 
            this.txtSection.BackColor = System.Drawing.Color.White;
            this.txtSection.Location = new System.Drawing.Point(15, 21);
            this.txtSection.MaxLength = 50;
            this.txtSection.Name = "txtSection";
            this.txtSection.Size = new System.Drawing.Size(239, 23);
            this.txtSection.TabIndex = 0;
            this.txtSection.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pbxLocked
            // 
            this.pbxLocked.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pbxLocked.BackgroundImage")));
            this.pbxLocked.Location = new System.Drawing.Point(10, 437);
            this.pbxLocked.Name = "pbxLocked";
            this.pbxLocked.Size = new System.Drawing.Size(24, 24);
            this.pbxLocked.TabIndex = 90;
            this.pbxLocked.TabStop = false;
            this.pbxLocked.Visible = false;
            // 
            // tabDetails
            // 
            this.tabDetails.Controls.Add(this.tblRoomUnits);
            this.tabDetails.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabDetails.Location = new System.Drawing.Point(12, 64);
            this.tabDetails.Name = "tabDetails";
            this.tabDetails.SelectedIndex = 0;
            this.tabDetails.Size = new System.Drawing.Size(568, 491);
            this.tabDetails.TabIndex = 71;
            // 
            // SubjectScheduleDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(592, 595);
            this.Controls.Add(this.tabDetails);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SubjectScheduleDetails";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.tblRoomUnits.ResumeLayout(false);
            this.tblRoomUnits.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxUnlock)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.gbxClassroom.ResumeLayout(false);
            this.gbxClassroom.PerformLayout();
            this.pnlFieldRoom.ResumeLayout(false);
            this.pnlFieldRoom.PerformLayout();
            this.pnlClassroomBased.ResumeLayout(false);
            this.pnlClassroomBased.PerformLayout();
            this.gbxUnits.ResumeLayout(false);
            this.gbxUnits.PerformLayout();
            this.gbxSection.ResumeLayout(false);
            this.gbxSection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbxLocked)).EndInit();
            this.tabDetails.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.Panel panel1;
        protected System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabPage tblRoomUnits;
        private System.Windows.Forms.Label label16;
        protected System.Windows.Forms.Label lblStatus;
        protected System.Windows.Forms.GroupBox groupBox2;
        protected System.Windows.Forms.Label lblUnitsLabHours;
        protected System.Windows.Forms.Label lblSysIdSubject;
        protected System.Windows.Forms.Label lblSubjectDepartment;
        protected System.Windows.Forms.Label lblSubjectCodeDescription;
        protected System.Windows.Forms.GroupBox gbxClassroom;
        protected System.Windows.Forms.RadioButton optTBA;
        protected System.Windows.Forms.Label lblMaxCapacity;
        protected System.Windows.Forms.Label lblClassroomCode;
        protected System.Windows.Forms.Label lblMCapacity;
        protected System.Windows.Forms.Label lblClassCode;
        protected System.Windows.Forms.TextBox txtFieldRoom;
        protected System.Windows.Forms.RadioButton optCampus;
        protected System.Windows.Forms.RadioButton optField;
        private System.Windows.Forms.GroupBox gbxUnits;
        protected RemoteClient.HourMinute hrmHours;
        private System.Windows.Forms.Label lblHours;
        private System.Windows.Forms.Label lblLaboratory;
        private System.Windows.Forms.Label lblLecture;
        protected System.Windows.Forms.RadioButton optHours;
        protected System.Windows.Forms.TextBox txtLaboratory;
        protected System.Windows.Forms.RadioButton optUnits;
        protected System.Windows.Forms.TextBox txtLecture;
        private System.Windows.Forms.GroupBox gbxSection;
        protected System.Windows.Forms.TextBox txtSection;
        protected System.Windows.Forms.TabControl tabDetails;
        protected System.Windows.Forms.LinkLabel lnkEdit;
        protected System.Windows.Forms.Label lblEditTimeClassroomBased;
        protected System.Windows.Forms.Panel pnlClassroomBased;
        protected System.Windows.Forms.PictureBox pbxUnlock;
        protected System.Windows.Forms.PictureBox pbxLocked;
        protected System.Windows.Forms.Panel pnlFieldRoom;
        protected System.Windows.Forms.Label lblFieldRoomTime;
        protected System.Windows.Forms.LinkLabel lnkEditTimeFieldRoom;
    }
}