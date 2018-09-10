using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace OfficeServices
{   

    internal class SubjectSchedulingLogic : BaseServices.BaseServicesLogic
    {
        #region Class Nested Classes

        internal class ScheduleList
        {
            public ScheduleList()
            {
            }

            private DataRowState _rowState;
            public DataRowState RowState
            {
                get { return _rowState; }
                set { _rowState = value; }
            }

            private Boolean _isIrregularModular;
            public Boolean IsIrregularModular
            {
                get { return _isIrregularModular; }
                set { _isIrregularModular = value; }
            }           

            private Int32[][][] _timeFrame;
            public Int32[][][] TimeFrame
            {
                get { return _timeFrame; }
                set { _timeFrame = value; }
            }

            private CommonExchange.ScheduleInformationDetails _scheduleDetailsInfo;
            public CommonExchange.ScheduleInformationDetails ScheduleDetailsInfo
            {
                get { return _scheduleDetailsInfo; }
                set { _scheduleDetailsInfo = value; }
            }

            private DataTable _schedTable;
            public DataTable ScheduleTable
            {
                get { return _schedTable; }
                set { _schedTable = value; }
            }

            private Int32 _numDays;
            public Int32 NumberOfDaysDisplayed
            {
                get { return _numDays; }
                set { _numDays = value; }
            }

            private Int32 _numTimeSlots;
            public Int32 NumberOfTimeSlotsDisplayed
            {
                get { return _numTimeSlots; }
                set { _numTimeSlots = value; }
            }

            private Int32 _selectedIndex;
            public Int32 SelectedIndex
            {
                get { return _selectedIndex; }
                set { _selectedIndex = value; }
            }

            private Int32 _readOnlyIndex;
            public Int32 ReadOnlyIndex
            {
                get { return _readOnlyIndex; }
                set { _readOnlyIndex = value; }
            }

            private Int32 _selectedValue;
            public Int32 SelectedValue
            {
                get { return _selectedValue; }
                set { _selectedValue = value; }
            }

            private Int32 _readOnlyValue;
            public Int32 ReadOnlyValue
            {
                get { return _readOnlyValue; }
                set { _readOnlyValue = value; }
            }            
        }

        internal class WeekDayTime
        {
            public WeekDayTime()
            {
            }

            private Byte _weekId;
            public Byte WeekId
            {
                get { return _weekId; }
                set { _weekId = value; }
            }

            private Byte _startTime;
            public Byte StartTime
            {
                get { return _startTime; }
                set { _startTime = value; }
            }

            private Byte _endTime;
            public Byte EndTime
            {
                get { return _endTime; }
                set { _endTime = value; }
            }

            private Boolean _isAdded;
            public Boolean IsAdded
            {
                get { return _isAdded; }
                set { _isAdded = value; }
            }

        }

        #endregion

        #region Class Data Member Declarations
        private const String c_tbaString = "TBA";

        private DataSet _classDataSet;
        private DataTable _scheduleDetailsTable;        //used for the subject schedule details
        private DataTable _dayTimeScheduleTable;        //used for the day and time schedule for the subject details
        private DataTable _subjectScheduleTable;
        private DataTable _studentEnrolledTable;
        private DataTable _semesterTable;
        private DataTable _yearTable;
        private DataTable _subjectTable;

        private Int32 _detailsCounter = 0;
        private Int32 _scheduleId = 0;

        private List<ScheduleList> _schedList = new List<ScheduleList>();
        #endregion

        #region Class Properties Declarations
        public DataTable SubjectTableFormat
        {
            get
            {
                DataTable subjectTable = new DataTable("SubjectTableFormat");
                subjectTable.Columns.Add("sysid_subject", System.Type.GetType("System.String"));
                subjectTable.Columns.Add("subject_code_title", System.Type.GetType("System.String"));
                subjectTable.Columns.Add("department_name", System.Type.GetType("System.String"));
                
                return subjectTable;
            }
        }        

        public DataTable ClassroomTableFormat
        {
            get
            {
                DataTable classroomTable = new DataTable("ClassroomInformationTableFormat");
                classroomTable.Columns.Add("sysid_classroom", System.Type.GetType("System.String"));
                classroomTable.Columns.Add("classroom_code", System.Type.GetType("System.String"));
                classroomTable.Columns.Add("classroom_description", System.Type.GetType("System.String"));
                classroomTable.Columns.Add("maximum_capacity", System.Type.GetType("System.Byte"));

                return classroomTable;
            }
        }

        public DataTable ScheduleDetailsTableFormat
        {
            get
            {
                DataTable detailsTable = new DataTable("ScheduleDetailsTableFormat");
                detailsTable.Columns.Add("sysid_scheddetails", System.Type.GetType("System.String"));
                detailsTable.Columns.Add("day_time", System.Type.GetType("System.String"));
                detailsTable.Columns.Add("section", System.Type.GetType("System.String"));
                detailsTable.Columns.Add("classroom_field_code", System.Type.GetType("System.String"));
                detailsTable.Columns.Add("lecture_units", System.Type.GetType("System.Byte"));
                detailsTable.Columns.Add("lab_units", System.Type.GetType("System.Byte"));
                detailsTable.Columns.Add("no_hours", System.Type.GetType("System.String"));

                return detailsTable;
            }
        }

        #endregion

        #region Class Constructor
        public SubjectSchedulingLogic(CommonExchange.SysAccess userInfo)
        {
            this.InitializeClass(userInfo);
        }
        #endregion

        #region Programmer-Defined Void Procedures
        //this procedure will print list of schedule details
        public void PrintScheduleDetailsList(CommonExchange.SysAccess userInfo, String schoolYearSemesterDescription)
        {
            DataTable tempTable = new DataTable("ScheduleDetailsTable");
            tempTable.Columns.Add("subject_code_title", System.Type.GetType("System.String"));
            tempTable.Columns.Add("day_time", System.Type.GetType("System.String"));
            tempTable.Columns.Add("section", System.Type.GetType("System.String"));
            tempTable.Columns.Add("classroom_field_code", System.Type.GetType("System.String"));
            tempTable.Columns.Add("instructor", System.Type.GetType("System.String"));
            tempTable.Columns.Add("slots", System.Type.GetType("System.String"));

            if (_scheduleDetailsTable != null)
            {

                foreach (DataRow dRow in _scheduleDetailsTable.Rows)
                {
                    DataRow newRow = tempTable.NewRow();

                    newRow["subject_code_title"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "subject_code", "") + " - " +
                        RemoteServerLib.ProcStatic.DataRowConvert(dRow, "descriptive_title", "");
                    newRow["day_time"] = !RemoteServerLib.ProcStatic.DataRowConvert(dRow, "is_irregular_modular", false) ?
                        RemoteServerLib.ProcStatic.DataRowConvert(dRow, "day_time", "") :
                        RemoteServerLib.ProcStatic.DataRowConvert(dRow, "manual_schedule", String.Empty);
                    newRow["section"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "section", "");
                    newRow["classroom_field_code"] = String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "field_room", "")) ?
                        (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "classroom_code", "")) ? c_tbaString :
                        RemoteServerLib.ProcStatic.DataRowConvert(dRow, "classroom_code", "")) :
                        RemoteServerLib.ProcStatic.DataRowConvert(dRow, "field_room", "");

                    String fName = String.Empty;
                    String mName = String.Empty;
                    String lName = String.Empty;

                    if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "first_name", "")))
                    {
                        fName = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "first_name", "").Substring(0, 1) + ".";
                    }

                    if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "middle_name", "")))
                    {
                        mName = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "middle_name", "").Substring(0, 1) + ".";
                    }

                    newRow["instructor"] = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(
                                RemoteServerLib.ProcStatic.DataRowConvert(dRow, "last_name", ""), fName, mName);
                    newRow["slots"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "slots_available", Int16.Parse("0")) == -32768 ?
                                "TBA/F" : RemoteServerLib.ProcStatic.DataRowConvert(dRow, "slots_available", Int16.Parse("0")).ToString();

                    tempTable.Rows.Add(newRow);
                }
            }

            using (ClassSubjectSchedulingManager.CrystalReport.CrystalSubjectScheduleList rptScheduleList = new 
                OfficeServices.ClassSubjectSchedulingManager.CrystalReport.CrystalSubjectScheduleList())
            {
                rptScheduleList.Database.Tables["schedule_details_table"].SetDataSource(tempTable);

                rptScheduleList.SetParameterValue("@school_name", CommonExchange.SchoolInformation.SchoolName);
                rptScheduleList.SetParameterValue("@form_name", "Subject Schedule List");
                rptScheduleList.SetParameterValue("@school_year_semester_description", schoolYearSemesterDescription);
                rptScheduleList.SetParameterValue("@print_info", "Date/Time Printed: " + DateTime.Parse(_serverDateTime).ToShortDateString() + " " +
                    DateTime.Parse(_serverDateTime).ToShortTimeString() + "         Printed by: " +
                    RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName,
                    userInfo.PersonInfo.FirstName, userInfo.PersonInfo.MiddleName));

                using (RemoteClient.CrystalReportViewer frmViewer = new RemoteClient.CrystalReportViewer(rptScheduleList))
                {
                    frmViewer.Text = "   Subject Schedule List";
                    frmViewer.ShowDialog();
                }
            }

        }//-----------------------------

        //this procedure will print list of student enrolled in a particular subject
        public void PrintStudentEnrolledList(CommonExchange.SysAccess userInfo, CommonExchange.ScheduleInformation scheduleInfo,
            String schoolYearSemesterDescription, DataTable classRoomTimeTable)
        {
            DataTable newTableMale = new DataTable("PrintTableMale");
            newTableMale.Columns.Add("student_name", System.Type.GetType("System.String"));
            newTableMale.Columns.Add("course_year_level", System.Type.GetType("System.String"));
            newTableMale.Columns.Add("enrolled_date", System.Type.GetType("System.String"));

            DataTable newTableFemale = new DataTable("PrintTableFemale");
            newTableFemale.Columns.Add("student_name", System.Type.GetType("System.String"));
            newTableFemale.Columns.Add("course_year_level", System.Type.GetType("System.String"));
            newTableFemale.Columns.Add("enrolled_date", System.Type.GetType("System.String"));

            DataTable newTableUnAssign = new DataTable("PrintTableUnassign");
            newTableUnAssign.Columns.Add("student_name", System.Type.GetType("System.String"));
            newTableUnAssign.Columns.Add("course_year_level", System.Type.GetType("System.String"));
            newTableUnAssign.Columns.Add("enrolled_date", System.Type.GetType("System.String"));

            if (_studentEnrolledTable != null)
            {
                foreach (DataRow studRow in _studentEnrolledTable.Rows)
                {
                    if (!RemoteServerLib.ProcStatic.DataRowConvert(studRow, "is_premature_deloaded", false))
                    {
                        if (RemoteServerLib.ProcStatic.DataRowConvert(studRow, "gender_code_reference_flag", Byte.Parse("0")) == (Byte)CommonExchange.Sex.Male)
                        {
                            DataRow newRow = newTableMale.NewRow();

                            newRow["student_name"] = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(studRow, "last_name", "first_name", "middle_name");
                            newRow["course_year_level"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_acronym", "") + " - " +
                                RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_level_description", "");
                            newRow["enrolled_date"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "enrolled_date", "");

                            newTableMale.Rows.Add(newRow);
                        }
                        else if (RemoteServerLib.ProcStatic.DataRowConvert(studRow, "gender_code_reference_flag", Byte.Parse("0")) ==
                            (Byte)CommonExchange.Sex.Female)
                        {
                            DataRow newRow = newTableFemale.NewRow();

                            newRow["student_name"] = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(studRow, "last_name", "first_name", "middle_name");
                            newRow["course_year_level"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_acronym", "") + " - " +
                                RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_level_description", "");
                            newRow["enrolled_date"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "enrolled_date", "");

                            newTableFemale.Rows.Add(newRow);
                        }
                        else
                        {
                            DataRow newRow = newTableUnAssign.NewRow();

                            newRow["student_name"] = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(studRow, "last_name", "first_name", "middle_name");
                            newRow["course_year_level"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_acronym", "") + " - " +
                                RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_level_description", "");
                            newRow["enrolled_date"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "enrolled_date", "");

                            newTableUnAssign.Rows.Add(newRow);
                        }
                    }
                }
            }

            using (ClassSubjectSchedulingManager.CrystalReport.CrystalStudentEnrolledList rptStudentEnrolledList = new
                OfficeServices.ClassSubjectSchedulingManager.CrystalReport.CrystalStudentEnrolledList())
            {
                rptStudentEnrolledList.Database.Tables["student_table_male"].SetDataSource(newTableMale);
                rptStudentEnrolledList.Database.Tables["student_table_female"].SetDataSource(newTableFemale);
                rptStudentEnrolledList.Database.Tables["student_table_unassign"].SetDataSource(newTableUnAssign);
                rptStudentEnrolledList.Database.Tables["class_room_time_table"].SetDataSource(classRoomTimeTable);

                rptStudentEnrolledList.SetParameterValue("@subject_code_title", scheduleInfo.SubjectInfo.SubjectCode + " - " +
                    scheduleInfo.SubjectInfo.DescriptiveTitle);
                rptStudentEnrolledList.SetParameterValue("@department_name", scheduleInfo.SubjectInfo.DepartmentInfo.DepartmentName);
                rptStudentEnrolledList.SetParameterValue("@lecture_lab_hours",
                    this.GetSubjectUnitsHours(scheduleInfo.SubjectInfo.LectureUnits, scheduleInfo.SubjectInfo.LabUnits, scheduleInfo.SubjectInfo.NoHours));
                rptStudentEnrolledList.SetParameterValue("@school_year_description", schoolYearSemesterDescription);
                rptStudentEnrolledList.SetParameterValue("@print_info", "Date/Time Printed: " + DateTime.Parse(_serverDateTime).ToShortDateString() + " " +
                    DateTime.Parse(_serverDateTime).ToShortTimeString() + "         Printed by: " +
                    RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName, 
                    userInfo.PersonInfo.FirstName, userInfo.PersonInfo.MiddleName));

                using (RemoteClient.CrystalReportViewer frmViewer = new RemoteClient.CrystalReportViewer(rptStudentEnrolledList))
                {
                    frmViewer.Text = "   Students' Enrolled List";
                    frmViewer.ShowDialog();
                }
            }
        }//----------------------------

        //this procedure inserts a new schedule information
        public void InsertScheduleInformation(CommonExchange.SysAccess userInfo, CommonExchange.ScheduleInformation scheduleInfo)
        {
            if (this.HasValidCountOfScheduleDetails(scheduleInfo.ScheduleSysId, scheduleInfo.IsTeamTeaching))
            {
                using (RemoteClient.RemCntSubjectSchedulingManager remClient = new RemoteClient.RemCntSubjectSchedulingManager())
                {
                    remClient.InsertScheduleInformation(userInfo, ref scheduleInfo);

                    if (_schedList != null)
                    {
                        foreach (ScheduleList schedList in _schedList)
                        {
                            if (String.Equals(schedList.ScheduleDetailsInfo.ScheduleDetailsSysId.Substring(0, 6), "SYSTMP") &&
                                schedList.RowState != DataRowState.Deleted)
                            {
                                CommonExchange.ScheduleInformationDetails schedDetails = schedList.ScheduleDetailsInfo;

                                schedDetails.ScheduleInfo.ScheduleSysId = scheduleInfo.ScheduleSysId;

                                schedDetails.DayTime = schedDetails.IsClassroom ?
                                    schedDetails.DayTimeClassroom : schedDetails.DayTimeFieldRoom;

                                remClient.InsertScheduleInformationDetails(userInfo, ref schedDetails,
                                    this.GenerateScheduleTable(schedList.ScheduleDetailsInfo.ScheduleDetailsSysId, schedList.TimeFrame,
                                    schedList.NumberOfDaysDisplayed, schedList.NumberOfTimeSlotsDisplayed, schedList.SelectedIndex,
                                    schedList.ReadOnlyIndex, schedList.SelectedValue, schedList.ReadOnlyValue, schedList.ScheduleTable));

                                if (_scheduleDetailsTable != null)
                                {
                                    DataRow newRow = _scheduleDetailsTable.NewRow();

                                    newRow["sysid_scheddetails"] = schedDetails.ScheduleDetailsSysId;
                                    newRow["sysid_schedule"] = scheduleInfo.ScheduleSysId;
                                    newRow["sysid_classroom"] = schedDetails.ClassroomInfo.ClassroomSysId;
                                    newRow["field_room"] = schedDetails.FieldRoom;
                                    newRow["is_classroom"] = schedDetails.IsClassroom;
                                    newRow["lecture_units_details"] = schedDetails.LectureUnits;
                                    newRow["lab_units_details"] = schedDetails.LabUnits;
                                    newRow["no_hours_details"] = schedDetails.NoHours;
                                    newRow["section"] = schedDetails.Section;
                                    newRow["manual_schedule"] = schedDetails.ManualSchedule;
                                    newRow["is_irregular_modular"] = scheduleInfo.IsIrregularModular;
                                    newRow["is_marked_deleted_details"] = false;
                                    newRow["classroom_code"] = schedDetails.ClassroomInfo.ClassroomCode;
                                    newRow["maximum_capacity"] = schedDetails.ClassroomInfo.MaximumCapacity;
                                    newRow["subject_code"] = schedDetails.ScheduleInfo.SubjectInfo.SubjectCode;
                                    newRow["descriptive_title"] = schedDetails.ScheduleInfo.SubjectInfo.DescriptiveTitle;
                                    newRow["department_id"] = schedDetails.ScheduleInfo.SubjectInfo.DepartmentInfo.DepartmentId;
                                    newRow["lecture_units_schedule"] = scheduleInfo.SubjectInfo.LectureUnits;
                                    newRow["lab_units_schedule"] = scheduleInfo.SubjectInfo.LabUnits;
                                    newRow["no_hours_schedule"] = scheduleInfo.SubjectInfo.NoHours;
                                    newRow["is_semestral"] = scheduleInfo.SubjectInfo.CourseGroupInfo.IsSemestral;
                                    newRow["sysid_subject"] = scheduleInfo.SubjectInfo.SubjectSysId;

                                    if (!String.IsNullOrEmpty(scheduleInfo.SchoolYearInfo.YearId))
                                    {
                                        newRow["year_semester_id"] = scheduleInfo.SchoolYearInfo.YearId;
                                    }
                                    else if (!String.IsNullOrEmpty(scheduleInfo.SemesterInfo.SemesterSysId))
                                    {
                                        newRow["year_semester_id"] = scheduleInfo.SemesterInfo.SemesterSysId;
                                    }

                                    newRow["is_marked_deleted_schedule"] = false;
                                    newRow["is_team_teaching"] = scheduleInfo.IsTeamTeaching;
                                    newRow["is_fixed_amount"] = scheduleInfo.IsFixedAmount;
                                    newRow["amount"] = scheduleInfo.Amount;
                                    newRow["subject_department_name"] = scheduleInfo.SubjectInfo.DepartmentInfo.DepartmentName;

                                    String dayTime = schedDetails.IsClassroom ? schedDetails.DayTimeClassroom : schedDetails.DayTimeFieldRoom;

                                    newRow["day_time"] = dayTime;
                                    newRow["sysid_employee"] = DBNull.Value;
				                    newRow["last_name"] = DBNull.Value;
				                    newRow["first_name"] = DBNull.Value;
				                    newRow["middle_name"] = DBNull.Value;
				                    newRow["type_description"] = DBNull.Value;
				                    newRow["status_description"] = DBNull.Value;
                                    newRow["employee_department_name"] = DBNull.Value;

                                    _scheduleDetailsTable.Rows.Add(newRow);
                                    _scheduleDetailsTable.AcceptChanges();
                                }                                
                            }
                        }
                    }
                }
            }

            this.ClearCachedData();

        }//-----------------------------------

        //this procedure inserts a updates schedule information
        public void UpdateScheduleInformation(CommonExchange.SysAccess userInfo, CommonExchange.ScheduleInformation scheduleInfo)
        {
            if (this.HasValidCountOfScheduleDetails(scheduleInfo.ScheduleSysId, scheduleInfo.IsTeamTeaching))
            {
                using (RemoteClient.RemCntSubjectSchedulingManager remClient = new RemoteClient.RemCntSubjectSchedulingManager())
                {
                    remClient.UpdateScheduleInformation(userInfo, scheduleInfo);

                    if (_scheduleDetailsTable != null)
                    {
                        Int32 index = 0;

                        foreach (DataRow dRow in _scheduleDetailsTable.Rows)
                        {
                            if (String.Equals(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_schedule", ""), 
                                scheduleInfo.ScheduleSysId))
                            {
                                DataRow editRow = _scheduleDetailsTable.Rows[index];

                                editRow.BeginEdit();

                                editRow["lecture_units_schedule"] = scheduleInfo.SubjectInfo.LectureUnits;
                                editRow["lab_units_schedule"] = scheduleInfo.SubjectInfo.LabUnits;
                                editRow["no_hours_schedule"] = scheduleInfo.SubjectInfo.NoHours;
                                editRow["is_semestral"] = scheduleInfo.SubjectInfo.CourseGroupInfo.IsSemestral;
                                editRow["sysid_subject"] = scheduleInfo.SubjectInfo.SubjectSysId;

                                if (!String.IsNullOrEmpty(scheduleInfo.SchoolYearInfo.YearId))
                                {
                                    editRow["year_semester_id"] = scheduleInfo.SchoolYearInfo.YearId;
                                }
                                else if (!String.IsNullOrEmpty(scheduleInfo.SemesterInfo.SemesterSysId))
                                {
                                    editRow["year_semester_id"] = scheduleInfo.SemesterInfo.SemesterSysId;
                                }

                                editRow["is_irregular_modular"] = scheduleInfo.IsIrregularModular;
                                editRow["is_marked_deleted_schedule"] = false;
                                editRow["is_team_teaching"] = scheduleInfo.IsTeamTeaching;
                                editRow["is_fixed_amount"] = scheduleInfo.IsFixedAmount;
                                editRow["amount"] = scheduleInfo.Amount;
                                editRow["subject_department_name"] = scheduleInfo.SubjectInfo.DepartmentInfo.DepartmentName;

                                editRow.EndEdit();

                                break;
                            }

                            index++;
                        }

                        _scheduleDetailsTable.AcceptChanges();
                    }

                    if (_schedList != null)
                    {
                        foreach (ScheduleList schedList in _schedList)
                        {
                            if (schedList.RowState == DataRowState.Added && String.Equals(schedList.ScheduleDetailsInfo.ScheduleInfo.ScheduleSysId, 
                                scheduleInfo.ScheduleSysId) && String.Equals(schedList.ScheduleDetailsInfo.ScheduleDetailsSysId.Substring(0, 6), "SYSTMP"))
                            {

                                CommonExchange.ScheduleInformationDetails schedDetails = schedList.ScheduleDetailsInfo;

                                schedDetails.ScheduleInfo.ScheduleSysId = scheduleInfo.ScheduleSysId;

                                schedDetails.DayTime = schedDetails.IsClassroom ?
                                    schedDetails.DayTimeClassroom : schedDetails.DayTimeFieldRoom;

                                remClient.InsertScheduleInformationDetails(userInfo, ref schedDetails,
                                    this.GenerateScheduleTable(schedList.ScheduleDetailsInfo.ScheduleDetailsSysId, schedList.TimeFrame,
                                    schedList.NumberOfDaysDisplayed, schedList.NumberOfTimeSlotsDisplayed, schedList.SelectedIndex,
                                    schedList.ReadOnlyIndex, schedList.SelectedValue, schedList.ReadOnlyValue, schedList.ScheduleTable));

                                if (_scheduleDetailsTable != null)
                                {
                                    DataRow newRow = _scheduleDetailsTable.NewRow();

                                    newRow["sysid_scheddetails"] = schedDetails.ScheduleDetailsSysId;
                                    newRow["sysid_schedule"] = scheduleInfo.ScheduleSysId;
                                    newRow["sysid_classroom"] = schedDetails.ClassroomInfo.ClassroomSysId;
                                    newRow["field_room"] = schedDetails.FieldRoom;
                                    newRow["is_classroom"] = schedDetails.IsClassroom;
                                    newRow["lecture_units_details"] = schedDetails.LectureUnits;
                                    newRow["lab_units_details"] = schedDetails.LabUnits;
                                    newRow["no_hours_details"] = schedDetails.NoHours;
                                    newRow["section"] = schedDetails.Section;
                                    newRow["manual_schedule"] = schedDetails.ManualSchedule;
                                    newRow["is_irregular_modular"] = scheduleInfo.IsIrregularModular;
                                    newRow["is_marked_deleted_details"] = false;
                                    newRow["classroom_code"] = schedDetails.ClassroomInfo.ClassroomCode;
                                    newRow["maximum_capacity"] = schedDetails.ClassroomInfo.MaximumCapacity;
                                    newRow["subject_code"] = schedDetails.ScheduleInfo.SubjectInfo.SubjectCode;
                                    newRow["descriptive_title"] = schedDetails.ScheduleInfo.SubjectInfo.DescriptiveTitle;
                                    newRow["department_id"] = schedDetails.ScheduleInfo.SubjectInfo.DepartmentInfo.DepartmentId;
                                    newRow["lecture_units_schedule"] = scheduleInfo.SubjectInfo.LectureUnits;
                                    newRow["lab_units_schedule"] = scheduleInfo.SubjectInfo.LabUnits;
                                    newRow["no_hours_schedule"] = scheduleInfo.SubjectInfo.NoHours;
                                    newRow["is_semestral"] = scheduleInfo.SubjectInfo.CourseGroupInfo.IsSemestral;
                                    newRow["sysid_subject"] = scheduleInfo.SubjectInfo.SubjectSysId;

                                    if (!String.IsNullOrEmpty(scheduleInfo.SchoolYearInfo.YearId))
                                    {
                                        newRow["year_semester_id"] = scheduleInfo.SchoolYearInfo.YearId;
                                    }
                                    else if (!String.IsNullOrEmpty(scheduleInfo.SemesterInfo.SemesterSysId))
                                    {
                                        newRow["year_semester_id"] = scheduleInfo.SemesterInfo.SemesterSysId;
                                    }

                                    newRow["is_marked_deleted_schedule"] = false;
                                    newRow["is_team_teaching"] = scheduleInfo.IsTeamTeaching;
                                    newRow["subject_department_name"] = scheduleInfo.SubjectInfo.DepartmentInfo.DepartmentName;

                                    String dayTime = schedDetails.IsClassroom ? schedDetails.DayTimeClassroom : schedDetails.DayTimeFieldRoom;

                                    newRow["day_time"] = dayTime;
                                    newRow["sysid_employee"] = DBNull.Value;
                                    newRow["last_name"] = DBNull.Value;
                                    newRow["first_name"] = DBNull.Value;
                                    newRow["middle_name"] = DBNull.Value;
                                    newRow["type_description"] = DBNull.Value;
                                    newRow["status_description"] = DBNull.Value;
                                    newRow["employee_department_name"] = DBNull.Value;

                                    _scheduleDetailsTable.Rows.Add(newRow);
                                    _scheduleDetailsTable.AcceptChanges();
                                }
                            }
                            else if (schedList.RowState == DataRowState.Modified && String.Equals(schedList.ScheduleDetailsInfo.ScheduleInfo.ScheduleSysId, 
                                scheduleInfo.ScheduleSysId))
                            {
                                CommonExchange.ScheduleInformationDetails schedDetails = schedList.ScheduleDetailsInfo;

                                schedDetails.DayTime = schedDetails.IsClassroom ?
                                    schedDetails.DayTimeClassroom : schedDetails.DayTimeFieldRoom;

                                remClient.UpdateScheduleInformationDetails(userInfo, schedList.ScheduleDetailsInfo,
                                    this.GenerateScheduleTable(schedList.ScheduleDetailsInfo.ScheduleDetailsSysId, schedList.TimeFrame,
                                    schedList.NumberOfDaysDisplayed, schedList.NumberOfTimeSlotsDisplayed, schedList.SelectedIndex,
                                    schedList.ReadOnlyIndex, schedList.SelectedValue, schedList.ReadOnlyValue, schedList.ScheduleTable));
                                
                                if (_scheduleDetailsTable != null)
                                {
                                    Int32 index = 0;

                                    foreach (DataRow dRow in _scheduleDetailsTable.Rows)
                                    {
                                        if (String.Equals(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_scheddetails", ""),
                                            schedDetails.ScheduleDetailsSysId))
                                        {
                                            DataRow editRow = _scheduleDetailsTable.Rows[index];

                                            editRow.BeginEdit();

                                            editRow["sysid_scheddetails"] = schedDetails.ScheduleDetailsSysId;
                                            editRow["sysid_classroom"] = schedDetails.ClassroomInfo.ClassroomSysId;
                                            editRow["field_room"] = schedDetails.FieldRoom;
                                            editRow["is_classroom"] = schedDetails.IsClassroom;
                                            editRow["lecture_units_details"] = schedDetails.LectureUnits;
                                            editRow["lab_units_details"] = schedDetails.LabUnits;
                                            editRow["no_hours_details"] = schedDetails.NoHours;
                                            editRow["section"] = schedDetails.Section;
                                            editRow["is_marked_deleted_details"] = false;
                                            editRow["classroom_code"] = schedDetails.ClassroomInfo.ClassroomCode;
                                            editRow["maximum_capacity"] = schedDetails.ClassroomInfo.MaximumCapacity;
                                            editRow["subject_code"] = schedDetails.ScheduleInfo.SubjectInfo.SubjectCode;
                                            editRow["descriptive_title"] = schedDetails.ScheduleInfo.SubjectInfo.DescriptiveTitle;
                                            editRow["department_id"] = schedDetails.ScheduleInfo.SubjectInfo.DepartmentInfo.DepartmentId;

                                            String dayTime = schedDetails.IsClassroom ? schedDetails.DayTimeClassroom : schedDetails.DayTimeFieldRoom;

                                            editRow["day_time"] = dayTime;
                                            editRow["manual_schedule"] = schedDetails.ManualSchedule;

                                            editRow.EndEdit();

                                            break;
                                        }

                                        index++;
                                    }

                                    _scheduleDetailsTable.AcceptChanges();
                                }
                            }
                            else if (schedList.RowState == DataRowState.Deleted && String.Equals(schedList.ScheduleDetailsInfo.ScheduleInfo.ScheduleSysId, 
                                scheduleInfo.ScheduleSysId))
                            {
                                CommonExchange.ScheduleInformationDetails schedDetails = schedList.ScheduleDetailsInfo;

                                remClient.DeleteScheduleInformationDetails(userInfo, schedDetails);

                                if (_scheduleDetailsTable != null)
                                {
                                    Int32 index = 0;

                                    foreach (DataRow dRow in _scheduleDetailsTable.Rows)
                                    {
                                        if (String.Equals(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_scheddetails", ""),
                                            schedDetails.ScheduleDetailsSysId))
                                        {
                                            DataRow editRow = _scheduleDetailsTable.Rows[index];

                                            editRow.BeginEdit();

                                            editRow["is_marked_deleted_details"] = true;

                                            editRow.EndEdit();

                                            break;
                                        }

                                        index++;
                                    }

                                    _scheduleDetailsTable.AcceptChanges();
                                }
                            }
                        }
                    }
                }
            }

            this.ClearCachedData();

        } //------------------------------

        //this procedure inserts a deletes schedule information
        public void DeleteScheduleInformation(CommonExchange.SysAccess userInfo, CommonExchange.ScheduleInformation scheduleInfo)
        {
            using (RemoteClient.RemCntSubjectSchedulingManager remClient = new RemoteClient.RemCntSubjectSchedulingManager())
            {
                remClient.DeleteScheduleInformation(userInfo, scheduleInfo);
            }

            if (_scheduleDetailsTable != null)
            {
                Int32 index = 0;

                foreach (DataRow dRow in _scheduleDetailsTable.Rows)
                {
                    if (String.Equals(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_schedule", ""),
                        scheduleInfo.ScheduleSysId))
                    {
                        DataRow editRow = _scheduleDetailsTable.Rows[index];

                        editRow.BeginEdit();

                        editRow["is_marked_deleted_details"] = true;
                        editRow["is_marked_deleted_schedule"] = true;

                        editRow.EndEdit();

                        break;
                    }

                    index++;
                }

                _scheduleDetailsTable.AcceptChanges();
            }

            this.ClearCachedData();
            
        } //----------------------------------

        //this procedure inserts a new schedule information details for modular schedule
        public void InsertScheduleInformationDetails(ref CommonExchange.ScheduleInformationDetails scheduleDetailsInfo, Boolean isIrregualrModular)
        {
            if (_schedList != null)
            {
                if (!String.IsNullOrEmpty(scheduleDetailsInfo.ScheduleDetailsSysId))
                {
                    Int32 index = 0;

                    foreach (ScheduleList schedList in _schedList)
                    {
                        if (String.Equals(schedList.ScheduleDetailsInfo.ScheduleDetailsSysId, scheduleDetailsInfo.ScheduleDetailsSysId))
                        {
                            _schedList.RemoveAt(index);

                            break;
                        }

                        index++;
                    }
                }

                scheduleDetailsInfo.ScheduleDetailsSysId = "SYSTMP" + RemoteServerLib.ProcStatic.NineDigitZero(++_detailsCounter);
                scheduleDetailsInfo.IsMarkedDeleted = false;

                ScheduleList list = new ScheduleList();

                list.RowState = DataRowState.Added;
                list.ScheduleDetailsInfo = scheduleDetailsInfo;
                list.IsIrregularModular = isIrregualrModular;
               
                _schedList.Add(list);
            }
        }//-------------------------------

        //this procedure inserts a new schedule information details
        public void InsertScheduleInformationDetails(ref CommonExchange.ScheduleInformationDetails scheduleDetailsInfo,
            Int32[][][] tFrames, Int32 noOfDaysDisplayed, Int32 noOfTimeSlotsDisplayed, Int32 selectedIndex, Int32 readOnlyIndex,
            Int32 selectedValue, Int32 readOnlyValue, Boolean isIrregularModular)
        {

            if (_schedList != null)
            {
                if (!String.IsNullOrEmpty(scheduleDetailsInfo.ScheduleDetailsSysId))
                {
                    Int32 index = 0;

                    foreach (ScheduleList schedList in _schedList)
                    {
                        if (String.Equals(schedList.ScheduleDetailsInfo.ScheduleDetailsSysId, scheduleDetailsInfo.ScheduleDetailsSysId))
                        {
                            _schedList.RemoveAt(index);

                            break;
                        }

                        index++;
                    }
                }

                scheduleDetailsInfo.ScheduleDetailsSysId = "SYSTMP" + RemoteServerLib.ProcStatic.NineDigitZero(++_detailsCounter);
                scheduleDetailsInfo.IsMarkedDeleted = false;

                ScheduleList list = new ScheduleList();

                list.RowState = DataRowState.Added;
                list.TimeFrame = tFrames;
                list.ScheduleDetailsInfo = scheduleDetailsInfo;
                list.NumberOfDaysDisplayed = noOfDaysDisplayed;
                list.NumberOfTimeSlotsDisplayed = noOfTimeSlotsDisplayed;
                list.SelectedIndex = selectedIndex;
                list.ReadOnlyIndex = readOnlyIndex;
                list.SelectedValue = selectedValue;
                list.ReadOnlyValue = readOnlyValue;

                if (isIrregularModular)
                {
                    list.IsIrregularModular = true;
                }
                else
                {
                    //to edit day time shcedule table so that it will reflect in classroom shceduler control
                    DataTable dayTimeTable = this.GenerateScheduleTable(list.TimeFrame, list.NumberOfDaysDisplayed, list.NumberOfTimeSlotsDisplayed,
                                    list.SelectedIndex, list.ReadOnlyIndex, list.SelectedValue, list.ReadOnlyValue);

                    if (_dayTimeScheduleTable != null)
                    {
                        Int32 dayTimeIndex = 0;

                        foreach (DataRow dayTimeRow in _dayTimeScheduleTable.Rows)
                        {
                            foreach (DataRow selectedRow in dayTimeTable.Rows)
                            {
                                if ((RemoteServerLib.ProcStatic.DataRowConvert(dayTimeRow, "week_id", Byte.Parse("0")) ==
                                    RemoteServerLib.ProcStatic.DataRowConvert(selectedRow, "week_id", Byte.Parse("0"))) &&
                                    (RemoteServerLib.ProcStatic.DataRowConvert(dayTimeRow, "time_id", Byte.Parse("0")) ==
                                    RemoteServerLib.ProcStatic.DataRowConvert(selectedRow, "time_id", Byte.Parse("0"))))
                                {
                                    DataRow editRow = _dayTimeScheduleTable.Rows[dayTimeIndex];

                                    editRow.BeginEdit();

                                    editRow["is_read_only"] = true;

                                    editRow.EndEdit();
                                }
                            }

                            dayTimeIndex++;
                        }//-------------------
                    }
                }

                list.ScheduleTable = _dayTimeScheduleTable;

                _schedList.Add(list);
            }
        } //-----------------------------------------

        //this procedure updates a schedule information details for modular schedule
        public void UpdateScheduleInformationDetails(CommonExchange.ScheduleInformationDetails scheduleDetailsInfo, Boolean isIrregularModular)
        {
            if (_schedList != null && !String.IsNullOrEmpty(scheduleDetailsInfo.ScheduleDetailsSysId))
            {
                Int32 index = 0;

                foreach (ScheduleList schedlist in _schedList)
                {
                    if (String.Equals(schedlist.ScheduleDetailsInfo.ScheduleDetailsSysId, scheduleDetailsInfo.ScheduleDetailsSysId))
                    {
                        _schedList.RemoveAt(index);

                        break;
                    }

                    index++;
                }

                scheduleDetailsInfo.IsMarkedDeleted = false;

                ScheduleList list = new ScheduleList();

                list.RowState = DataRowState.Modified;
                list.ScheduleDetailsInfo = scheduleDetailsInfo;
                list.IsIrregularModular = isIrregularModular;
                
                _schedList.Add(list);

            }
        } //----------------------------------

        //this procedure updates a schedule information details
        public void UpdateScheduleInformationDetails(CommonExchange.ScheduleInformationDetails scheduleDetailsInfo,
            Int32[][][] tFrames, Int32 noOfDaysDisplayed, Int32 noOfTimeSlotsDisplayed, Int32 selectedIndex, Int32 readOnlyIndex,
            Int32 selectedValue, Int32 readOnlyValue, Boolean isIrregularModular)
        {
            if (_schedList != null && !String.IsNullOrEmpty(scheduleDetailsInfo.ScheduleDetailsSysId))
            {
                Int32 index = 0;

                foreach (ScheduleList schedlist in _schedList)
                {
                    if (String.Equals(schedlist.ScheduleDetailsInfo.ScheduleDetailsSysId, scheduleDetailsInfo.ScheduleDetailsSysId))
                    {
                        _schedList.RemoveAt(index); 

                        break;
                    }

                    index++;
                }

                scheduleDetailsInfo.IsMarkedDeleted = false;

                ScheduleList list = new ScheduleList();

                list.RowState = DataRowState.Modified;
                list.TimeFrame = tFrames;
                list.ScheduleDetailsInfo = scheduleDetailsInfo;
                list.ScheduleTable = _dayTimeScheduleTable;
                list.NumberOfDaysDisplayed = noOfDaysDisplayed;
                list.NumberOfTimeSlotsDisplayed = noOfTimeSlotsDisplayed;
                list.SelectedIndex = selectedIndex;
                list.ReadOnlyIndex = readOnlyIndex;
                list.SelectedValue = selectedValue;
                list.ReadOnlyValue = readOnlyValue;

                if (isIrregularModular)
                {
                    list.IsIrregularModular = true;
                }

                _schedList.Add(list);
                           
            }
            
        } //----------------------------------

        //this procedure deletes a schedule information details
        public void DeleteScheduleInformationDetails(CommonExchange.ScheduleInformationDetails scheduleDetailsInfo,
            Int32[][][] tFrames, Int32 noOfDaysDisplayed, Int32 noOfTimeSlotsDisplayed, Int32 selectedIndex, Int32 readOnlyIndex,
            Int32 selectedValue, Int32 readOnlyValue)
        {
            if (_schedList != null)
            {
                Int32 index = 0;

                foreach (ScheduleList schedlist in _schedList)
                {
                    if (schedlist.ScheduleDetailsInfo.ScheduleDetailsSysId == scheduleDetailsInfo.ScheduleDetailsSysId)
                    {
                        _schedList.RemoveAt(index);

                        break;
                    }

                    index++;
                }

                scheduleDetailsInfo.IsMarkedDeleted = true;

                ScheduleList list = new ScheduleList();

                list.RowState = DataRowState.Deleted;
                list.TimeFrame = tFrames;
                list.ScheduleDetailsInfo = scheduleDetailsInfo;
                list.ScheduleTable = _dayTimeScheduleTable;
                list.NumberOfDaysDisplayed = noOfDaysDisplayed;
                list.NumberOfTimeSlotsDisplayed = noOfTimeSlotsDisplayed;
                list.SelectedIndex = selectedIndex;
                list.ReadOnlyIndex = readOnlyIndex;
                list.SelectedValue = selectedValue;
                list.ReadOnlyValue = readOnlyValue;

                _schedList.Add(list);
            }

            
        } //----------------------------------------------

        //this procedure is used to get the subject schedule by classroom code
        public void SelectByClassroomCodeSubjectSchedule(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd,
            String classroomSysId, String scheduleDetailsSysId)
        {
            using (RemoteClient.RemCntSubjectSchedulingManager remClient = new RemoteClient.RemCntSubjectSchedulingManager())
            {
                _dayTimeScheduleTable = remClient.SelectByClassroomCodeSubjectSchedule(userInfo, dateStart, dateEnd, classroomSysId, scheduleDetailsSysId);
            }

            if (_dayTimeScheduleTable != null && _schedList != null)
            {
                foreach (ScheduleList schedList in _schedList)
                {
                    if (schedList.ScheduleDetailsInfo.ClassroomInfo.ClassroomSysId == classroomSysId)
                    {
                        DataTable dayTimeTable = this.GenerateScheduleTable(schedList.TimeFrame, 
                            schedList.NumberOfDaysDisplayed, schedList.NumberOfTimeSlotsDisplayed,
                            schedList.SelectedIndex, schedList.ReadOnlyIndex, schedList.SelectedValue, schedList.ReadOnlyValue);

                        foreach (DataRow dayTimeRow in dayTimeTable.Rows)
                        {
                            //AC
                            String strFilter = "week_id = " + dayTimeRow["week_id"] + " AND time_id = " + dayTimeRow["time_id"];
                            DataRow[] selectRow = _dayTimeScheduleTable.Select(strFilter);
                            //------------

                            if (selectRow.Length == 0)
                            {
                                DataRow newRow = _dayTimeScheduleTable.NewRow();

                                newRow["schedule_id"] = --_scheduleId;
                                newRow["sysid_scheddetails"] = schedList.ScheduleDetailsInfo.ScheduleDetailsSysId;
                                newRow["week_id"] = dayTimeRow["week_id"];
                                newRow["time_id"] = dayTimeRow["time_id"];
                                newRow["subject_code"] = schedList.ScheduleDetailsInfo.ScheduleInfo.SubjectInfo.SubjectCode;

                                if (!String.Equals(schedList.ScheduleDetailsInfo.ScheduleDetailsSysId, scheduleDetailsSysId))
                                {
                                    newRow["is_read_only"] = true;
                                }
                                else
                                {
                                    newRow["is_read_only"] = false;
                                }

                                _dayTimeScheduleTable.Rows.Add(newRow);
                            }
                        }
                    }
                }
            }

            _dayTimeScheduleTable.AcceptChanges();
        } //----------------------------------

        //this procedure gets the schedule information details by date start and end
        public void SelectByDateStartEndScheduleInformationDetails(CommonExchange.SysAccess userInfo, String queryString, String dateStart, 
            String dateEnd, Boolean isMarkedDeleted)
        {
            using (RemoteClient.RemCntSubjectSchedulingManager remClient = new RemoteClient.RemCntSubjectSchedulingManager())
            {
                _scheduleDetailsTable = remClient.SelectByDateStartEndScheduleInformationDetails(userInfo, queryString, dateStart, dateEnd, isMarkedDeleted);
            }
        }//-------------------------------------------------

        //this procedure will get student enrolled list
        public void SelectBySysIDScheduleListStudentLoad(CommonExchange.SysAccess userInfo, String scheduleSysIdList)
        {
            using (RemoteClient.RemCntStudentLoadingManager remClient = new RemoteClient.RemCntStudentLoadingManager())
            {
                _studentEnrolledTable = remClient.SelectBySysIDScheduleListStudentLoad(userInfo, scheduleSysIdList);
            }
        }//--------------------------------

        //this procedure initializes the school year combo box
        public void InitializeSchoolYearCombo(ComboBox cboBase)
        {
            cboBase.Items.Clear();

            Int32 index = 0;
            Boolean isIndexed = false;

            foreach (DataRow yearRow in _classDataSet.Tables["SchoolFeeInformationTable"].Rows)
            {
                cboBase.Items.Add(yearRow["year_description"].ToString());

                if (!isIndexed)
                {
                    DateTime serverDateTime = DateTime.Parse(_serverDateTime);
                    DateTime dateStart = serverDateTime;
                    DateTime dateEnd = serverDateTime;

                    DateTime.TryParse(yearRow["date_start"].ToString(), out dateStart);
                    DateTime.TryParse(yearRow["date_end"].ToString(), out dateEnd);

                    if ((DateTime.Compare(serverDateTime, dateStart) >= 0 && DateTime.Compare(serverDateTime, dateEnd) <= 0) ||
                        (DateTime.Compare(serverDateTime.AddMonths((Int32)CommonExchange.SystemRange.MonthAllowance), dateStart) >= 0 &&
                         DateTime.Compare(serverDateTime.AddMonths((Int32)CommonExchange.SystemRange.MonthAllowance), dateEnd) <= 0))
                    {
                        cboBase.SelectedIndex = index;
                        isIndexed = true;
                    }

                    index++;
                }
            }
        } //---------------------------

        //this procedure initializes the semester combo box
        public void InitializeSemesterCombo(ComboBox cboBase, Int32 yearIndex)
        {
            cboBase.Items.Clear();

            DataRow yearRow = _classDataSet.Tables["SchoolFeeInformationTable"].Rows[yearIndex];

            String strFilter = "year_id = '" + yearRow["year_id"].ToString() + "'";
            DataRow[] selectRow = _classDataSet.Tables["SemesterInformationTable"].Select(strFilter);

            foreach (DataRow semRow in selectRow)
            {
                cboBase.Items.Add(semRow["semester_description"].ToString());
            }

            cboBase.SelectedIndex = -1;
        } //-----------------------------

        //this procedure initializes the school year and semester combo box
        public void InitializeSchoolYearSemesterCombo(ComboBox cboBase, Boolean isSemester)
        {
            cboBase.Items.Clear();

            DateTime serverDate = DateTime.Parse(_serverDateTime);

            if (isSemester)
            {
                DataTable newTable = new DataTable("SemesterWithDateStartEndInformationTable");
                newTable.Columns.Add("sysid_semester", System.Type.GetType("System.String"));
                newTable.Columns.Add("year_id", System.Type.GetType("System.String"));
                newTable.Columns.Add("semester_id", System.Type.GetType("System.Byte"));
                newTable.Columns.Add("date_start", System.Type.GetType("System.DateTime"));
                newTable.Columns.Add("date_end", System.Type.GetType("System.DateTime"));
                newTable.Columns.Add("year_description", System.Type.GetType("System.String"));
                newTable.Columns.Add("semester_description", System.Type.GetType("System.String"));

                foreach (DataRow semRow in _classDataSet.Tables["SemesterInformationTable"].Rows)
                {
                    DataRow newRow = newTable.NewRow();

                    newRow["sysid_semester"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "sysid_semester", "");
                    newRow["year_id"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "year_id", "");
                    newRow["semester_id"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "semester_id", Byte.Parse("0"));
                    newRow["date_start"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "date_start", DateTime.Parse(_serverDateTime));
                    newRow["date_end"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "date_end", DateTime.Parse(_serverDateTime));
                    newRow["year_description"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "year_description", "");
                    newRow["semester_description"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "semester_description", "");

                    newTable.Rows.Add(newRow);
                }

                newTable.AcceptChanges();

                _semesterTable = new DataTable("SemesterSelectedDateStartEndInformationTable");
                _semesterTable.Columns.Add("sysid_semester", System.Type.GetType("System.String"));
                _semesterTable.Columns.Add("year_id", System.Type.GetType("System.String"));
                _semesterTable.Columns.Add("semester_id", System.Type.GetType("System.Byte"));
                _semesterTable.Columns.Add("date_start", System.Type.GetType("System.DateTime"));
                _semesterTable.Columns.Add("date_end", System.Type.GetType("System.DateTime"));
                _semesterTable.Columns.Add("year_description", System.Type.GetType("System.String"));
                _semesterTable.Columns.Add("semester_description", System.Type.GetType("System.String"));

                String strFilter = "(date_end >= '" + serverDate.AddMonths((Int32)CommonExchange.SystemRange.MonthAllowance).ToShortDateString() + "') AND " +
                    "(date_start <= '" + serverDate.ToShortDateString() +
                    "' OR date_start <= '" + serverDate.AddMonths((Int32)CommonExchange.SystemRange.MonthAllowance).ToShortDateString() + "')";
                DataRow[] selectRow = newTable.Select(strFilter);

                foreach (DataRow semRow in selectRow)
                {
                    DataRow newRow = _semesterTable.NewRow();

                    newRow["sysid_semester"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "sysid_semester", "");
                    newRow["year_id"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "year_id", "");
                    newRow["semester_id"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "semester_id", Byte.Parse("0"));
                    newRow["date_start"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "date_start", DateTime.Parse(_serverDateTime));
                    newRow["date_end"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "date_end", DateTime.Parse(_serverDateTime));
                    newRow["year_description"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "year_description", "");
                    newRow["semester_description"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "semester_description", "");

                    _semesterTable.Rows.Add(newRow);

                    cboBase.Items.Add(semRow["year_description"].ToString() + " - " + semRow["semester_description"].ToString());
                }

                _semesterTable.AcceptChanges();

            }
            else
            {
                DataTable newTable = new DataTable("SchoolYearWithDateStartEndInformationTable");
                newTable.Columns.Add("year_id", System.Type.GetType("System.String"));
                newTable.Columns.Add("year_description", System.Type.GetType("System.String"));
                newTable.Columns.Add("date_start", System.Type.GetType("System.DateTime"));
                newTable.Columns.Add("date_end", System.Type.GetType("System.DateTime"));

                foreach (DataRow yearRow in _classDataSet.Tables["SchoolFeeInformationTable"].Rows)
                {
                    DataRow newRow = newTable.NewRow();

                    newRow["year_id"] = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "year_id", "");
                    newRow["year_description"] = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "year_description", "");
                    newRow["date_start"] = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "date_start", DateTime.Parse(_serverDateTime));
                    newRow["date_end"] = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "date_end", DateTime.Parse(_serverDateTime));

                    newTable.Rows.Add(newRow);
                }

                newTable.AcceptChanges();

                _yearTable = new DataTable("SchoolYearSelectedDateStartEndInformationTable");
                _yearTable.Columns.Add("year_id", System.Type.GetType("System.String"));
                _yearTable.Columns.Add("year_description", System.Type.GetType("System.String"));
                _yearTable.Columns.Add("date_start", System.Type.GetType("System.DateTime"));
                _yearTable.Columns.Add("date_end", System.Type.GetType("System.DateTime"));

                String strFilter = "(date_end >= '" + serverDate.AddMonths((Int32)CommonExchange.SystemRange.MonthAllowance).ToShortDateString() + "') AND " +
                    "(date_start <= '" + serverDate.ToShortDateString() +
                    "' OR date_start <= '" + serverDate.AddMonths((Int32)CommonExchange.SystemRange.MonthAllowance).ToShortDateString() + "')";
                DataRow[] selectRow = newTable.Select(strFilter);

                foreach (DataRow yearRow in selectRow)
                {
                    DataRow newRow = _yearTable.NewRow();

                    newRow["year_id"] = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "year_id", "");
                    newRow["year_description"] = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "year_description", "");
                    newRow["date_start"] = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "date_start", DateTime.Parse(_serverDateTime));
                    newRow["date_end"] = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "date_end", DateTime.Parse(_serverDateTime));

                    _yearTable.Rows.Add(newRow);

                    cboBase.Items.Add(yearRow["year_description"].ToString());
                }

                _yearTable.AcceptChanges();

            }

            if (cboBase.Items.Count > 0)
            {
                cboBase.SelectedIndex = 0;
            }
        } //-----------------------------

        //this procedure initializes the school year and semester combo box
        public void InitializeSchoolYearSemesterCombo(ComboBox cboBase, Boolean isSemester, String yearId, String semesterSysId)
        {
            cboBase.Items.Clear();

            if (isSemester && !String.IsNullOrEmpty(semesterSysId))
            {
                foreach (DataRow semRow in _classDataSet.Tables["SemesterInformationTable"].Rows)
                {
                    if (String.Equals(semesterSysId, semRow["sysid_semester"].ToString()))
                    {
                        cboBase.Items.Add(semRow["year_description"].ToString() + " - " + semRow["semester_description"].ToString());

                        cboBase.SelectedIndex = 0;

                        break;
                    }
                }

            }
            else if (!isSemester && !String.IsNullOrEmpty(yearId))
            {
                foreach (DataRow yearRow in _classDataSet.Tables["SchoolFeeInformationTable"].Rows)
                {
                    if (String.Equals(yearId, yearRow["year_id"].ToString()))
                    {
                        cboBase.Items.Add(yearRow["year_description"].ToString());

                        cboBase.SelectedIndex = 0;

                        break;
                    }
                }
            }

        } //-----------------------------

        //this procedure clears datatime table
        public void ClearDayTimeTable()
        {
            if (_dayTimeScheduleTable != null)
            {
                _dayTimeScheduleTable.Clear();
                _dayTimeScheduleTable.AcceptChanges();
            }
        }//----------------------------

        //this procedure clears schedule list for details
        public void ClearScheduleList(String sysIdScheduleDetails)
        {
            if (_schedList != null)
            {
                Int32 index = 0;

                foreach (ScheduleList schedList in _schedList)
                {
                    if (String.Equals(schedList.ScheduleDetailsInfo.ScheduleDetailsSysId, sysIdScheduleDetails))
                    {
                        _schedList.RemoveAt(index);

                        break;
                    }

                    index++;
                }
            }
        }//------------------

        //this procedure clears the cached data
        public void ClearCachedData()
        {
            if (_dayTimeScheduleTable != null)
            {
                _dayTimeScheduleTable.Clear();
                _dayTimeScheduleTable.AcceptChanges();
            }

            if (_schedList != null)
            {
                _schedList.Clear();
            }

        } //-----------------------------------

        //this procedure refreshes the special class data
        public void RefreshSpecialClassData(CommonExchange.SysAccess userInfo)
        {
            this.InitializeClass(userInfo);
        } //--------------------------------

        //this procedure initializes the class
        private void InitializeClass(CommonExchange.SysAccess userInfo)
        {
            //gets the server date and time
            using (RemoteClient.RemCntBaseManager remClient = new RemoteClient.RemCntBaseManager())
            {
                _serverDateTime = remClient.GetServerDateTime(userInfo);
            } //----------------------

            //gets the dataset for the schedule information
            using (RemoteClient.RemCntSubjectSchedulingManager remClient = new RemoteClient.RemCntSubjectSchedulingManager())
            {
                _classDataSet = remClient.GetDataSetForScheduleInformation(userInfo, _serverDateTime);
            } //-----------------------


        } //-----------------------        

        #endregion

        #region Programmer-Defined Function Procedures
        //this function will get the students enrolled in a particular schedule
        public DataTable GetStudentEnrolled(Boolean isEnrolled)
        {
            DataTable newTable = new DataTable("StudentSearchByStudentNameIdCardNumberTable");

            if (isEnrolled)
            {
                newTable.Columns.Add("student_id", System.Type.GetType("System.String"));
                newTable.Columns.Add("student_name", System.Type.GetType("System.String"));
                newTable.Columns.Add("card_number", System.Type.GetType("System.String"));
                newTable.Columns.Add("course_title", System.Type.GetType("System.String"));
                newTable.Columns.Add("year_level_description", System.Type.GetType("System.String"));
                newTable.Columns.Add("section", System.Type.GetType("System.String"));
                newTable.Columns.Add("department_name", System.Type.GetType("System.String"));
                newTable.Columns.Add("present_address", System.Type.GetType("System.String"));
                newTable.Columns.Add("present_phone_nos", System.Type.GetType("System.String"));
                newTable.Columns.Add("home_address", System.Type.GetType("System.String"));
                newTable.Columns.Add("home_phone_nos", System.Type.GetType("System.String"));
                newTable.Columns.Add("emer_contact_name", System.Type.GetType("System.String"));
                newTable.Columns.Add("emer_relationship_description", System.Type.GetType("System.String"));
                newTable.Columns.Add("emer_present_address", System.Type.GetType("System.String"));
                newTable.Columns.Add("emer_present_phone_nos", System.Type.GetType("System.String"));
                newTable.Columns.Add("emer_home_address", System.Type.GetType("System.String"));
                newTable.Columns.Add("emer_home_phone_nos", System.Type.GetType("System.String"));

                String strFilter = "is_premature_deloaded = 0";
                DataRow[] selectRow = _studentEnrolledTable.Select(strFilter);

                foreach (DataRow studentRow in selectRow)
                {
                    DataRow newRow = newTable.NewRow();

                    newRow["student_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "student_id", "");
                    newRow["student_name"] = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(studentRow, "last_name", "first_name", "middle_name");
                    newRow["card_number"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "card_number", "");
                    newRow["course_title"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "course_title", "") + " - " +
                        RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "course_acronym", "");
                    newRow["year_level_description"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "year_level_description", "");
                    newRow["section"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "level_section", "");
                    newRow["department_name"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "department_name", "") + " - " +
                        RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "department_acronym", "");
                    newRow["present_address"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "present_address", "");
                    newRow["present_phone_nos"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "present_phone_nos", "");
                    newRow["home_address"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "home_address", "");
                    newRow["home_phone_nos"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "home_phone_nos", "");
                    newRow["emer_contact_name"] = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(studentRow, "emer_last_name", "emer_first_name",
                        "emer_middle_name");
                    newRow["emer_relationship_description"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "emer_relationship_description",
                        String.Empty);
                    newRow["emer_present_address"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "emer_present_address", String.Empty);
                    newRow["emer_present_phone_nos"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "emer_present_phone_nos", String.Empty);
                    newRow["emer_home_address"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "emer_home_address", String.Empty);
                    newRow["emer_home_phone_nos"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "emer_home_phone_nos", String.Empty);

                    newTable.Rows.Add(newRow);
                }

                newTable.AcceptChanges();
            }
            else
            {
                newTable.Columns.Add("student_id", System.Type.GetType("System.String"));
                newTable.Columns.Add("student_name", System.Type.GetType("System.String"));
                newTable.Columns.Add("card_number", System.Type.GetType("System.String"));
                newTable.Columns.Add("course_title", System.Type.GetType("System.String"));
                newTable.Columns.Add("year_level_description", System.Type.GetType("System.String"));
                newTable.Columns.Add("section", System.Type.GetType("System.String"));
                newTable.Columns.Add("department_name", System.Type.GetType("System.String"));
                newTable.Columns.Add("load_date", System.Type.GetType("System.String"));
                newTable.Columns.Add("deload_date", System.Type.GetType("System.String"));
                newTable.Columns.Add("present_address", System.Type.GetType("System.String"));
                newTable.Columns.Add("present_phone_nos", System.Type.GetType("System.String"));
                newTable.Columns.Add("home_address", System.Type.GetType("System.String"));
                newTable.Columns.Add("home_phone_nos", System.Type.GetType("System.String"));
                newTable.Columns.Add("emer_contact_name", System.Type.GetType("System.String"));
                newTable.Columns.Add("emer_relationship_description", System.Type.GetType("System.String"));
                newTable.Columns.Add("emer_present_address", System.Type.GetType("System.String"));
                newTable.Columns.Add("emer_present_phone_nos", System.Type.GetType("System.String"));
                newTable.Columns.Add("emer_home_address", System.Type.GetType("System.String"));
                newTable.Columns.Add("emer_home_phone_nos", System.Type.GetType("System.String"));

                String strFilter = "is_premature_deloaded = 1";
                DataRow[] selectRow = _studentEnrolledTable.Select(strFilter);

                foreach (DataRow studentRow in selectRow)
                {
                    String loadDate = !String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "load_date", "")) ?
                        DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "load_date", "").ToString()).ToShortDateString() :
                        String.Empty;
                    String deloadDate = !String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "deload_date", "")) ?
                        DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "deload_date", "").ToString()).ToShortDateString() :
                        String.Empty;

                    DataRow newRow = newTable.NewRow();

                    newRow["student_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "student_id", "");
                    newRow["student_name"] = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(studentRow, "last_name", "first_name", "middle_name");
                    newRow["card_number"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "card_number", "");
                    newRow["course_title"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "course_title", "") + " - " +
                        RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "course_acronym", "");
                    newRow["year_level_description"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "year_level_description", "");
                    newRow["section"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "level_section", "");
                    newRow["department_name"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "department_name", "") + " - " +
                        RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "department_acronym", "");
                    newRow["load_date"] = loadDate;
                    newRow["deload_date"] = deloadDate;
                    newRow["present_address"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "present_address", "");
                    newRow["present_phone_nos"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "present_phone_nos", "");
                    newRow["home_address"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "home_address", "");
                    newRow["home_phone_nos"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "home_phone_nos", "");
                    newRow["emer_contact_name"] = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(studentRow, "emer_last_name", "emer_first_name",
                        "emer_middle_name");
                    newRow["emer_relationship_description"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "emer_relationship_description",
                        String.Empty);
                    newRow["emer_present_address"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "emer_present_address", String.Empty);
                    newRow["emer_present_phone_nos"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "emer_present_phone_nos", String.Empty);
                    newRow["emer_home_address"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "emer_home_address", String.Empty);
                    newRow["emer_home_phone_nos"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "emer_home_phone_nos", String.Empty);

                    newTable.Rows.Add(newRow);
                }

                newTable.AcceptChanges();
            }

            return newTable;
        }//--------------------

        //this function returns the week day table
        public DataTable GetWeekDayTable(String idFieldName, String descriptionFieldName, String acronymFieldName)
        {
            DataTable weekDayTable = new DataTable("WeekDayNewTable");
            weekDayTable.Columns.Add(idFieldName, System.Type.GetType("System.Byte"));
            weekDayTable.Columns.Add(descriptionFieldName, System.Type.GetType("System.String"));
            weekDayTable.Columns.Add(acronymFieldName, System.Type.GetType("System.String"));

            foreach (DataRow weekRow in _classDataSet.Tables["WeekDayTable"].Rows)
            {
                DataRow newRow = weekDayTable.NewRow();

                newRow[idFieldName] = weekRow["week_id"];
                newRow[descriptionFieldName] = weekRow["week_description"];
                newRow[acronymFieldName] = weekRow["acronym"];

                weekDayTable.Rows.Add(newRow);
            }

            weekDayTable.AcceptChanges();

            return weekDayTable;
        }//---------------------

        //this function returns the week time table
        public DataTable GetWeekTimeTable(String idFieldName, String descriptionFieldName)
        {
            DataTable timeSlotTable = new DataTable("TimeSlotNewTable");
            timeSlotTable.Columns.Add(idFieldName, System.Type.GetType("System.Byte"));
            timeSlotTable.Columns.Add(descriptionFieldName, System.Type.GetType("System.String"));

            foreach (DataRow weekRow in _classDataSet.Tables["WeekTimeTable"].Rows)
            {
                DataRow newRow = timeSlotTable.NewRow();

                newRow[idFieldName] = weekRow["time_id"];
                newRow[descriptionFieldName] = weekRow["time_description"];

                timeSlotTable.Rows.Add(newRow);
            }

            timeSlotTable.AcceptChanges();

            return timeSlotTable;
        }//---------------------------------

        //this function returns the readonly slot table
        public DataTable GetReadOnlySlotTable(String subjectCodeFieldName, String timeIdFieldName, String weekIdFieldName)
        {
            DataTable readOnlySlotTable = new DataTable("ReadOnlySlotTable");
            readOnlySlotTable.Columns.Add(subjectCodeFieldName, System.Type.GetType("System.String"));
            readOnlySlotTable.Columns.Add(timeIdFieldName, System.Type.GetType("System.Byte"));
            readOnlySlotTable.Columns.Add(weekIdFieldName, System.Type.GetType("System.Byte"));

            if (_dayTimeScheduleTable != null)
            {
                foreach (DataRow readRow in _dayTimeScheduleTable.Rows)
                {
                    if (RemoteServerLib.ProcStatic.DataRowConvert(readRow, "is_read_only", false))
                    {
                        DataRow newRow = readOnlySlotTable.NewRow();

                        newRow[subjectCodeFieldName] = readRow["subject_code"];
                        newRow[timeIdFieldName] = readRow["time_id"];
                        newRow[weekIdFieldName] = readRow["week_id"];

                        readOnlySlotTable.Rows.Add(newRow);
                    }
                }
            }

            readOnlySlotTable.AcceptChanges();

            return readOnlySlotTable;
        }//---------------------------

        //this function gets the time frames
        public Int32[][][] GetTimeFrames(Int32 noOfDaysDisplayed, Int32 noOfTimeSlotsDisplayed, Int32 selectedIndex, 
            Int32 readOnlyIndex, Int32 selectedValue, Int32 readOnlyValue, Int32 notSelectedValue, Int32 notReadOnlyValue)
        {
            //initialize days array
            Int32[][][] tFrames = new Int32[noOfDaysDisplayed][][];

            //initialize the time array
            for (Int32 i = 0; i < noOfDaysDisplayed; i++)
            {
                tFrames[i] = new Int32[noOfTimeSlotsDisplayed][];

                //initialize the selected and readonly array
                for (Int32 j = 0; j < noOfTimeSlotsDisplayed; j++)
                {
                    tFrames[i][j] = new Int32[2];
                } //--------------------
            } //-----------------------------

            for (Int32 i = 0; i < noOfDaysDisplayed; i++)
            {
                for (Int32 j = 0; j < noOfTimeSlotsDisplayed; j++)
                {
                    if (this.IsSelectedTimeFrame(i, j))
                    {
                        tFrames[i][j][selectedIndex] = selectedValue;
                    }
                    else
                    {
                        tFrames[i][j][selectedIndex] = notSelectedValue;
                    }

                    if (this.IsReadOnlyTimeFrame(i, j))
                    {
                        tFrames[i][j][readOnlyIndex] = readOnlyValue;
                    }
                    else
                    {
                        tFrames[i][j][readOnlyIndex] = notReadOnlyValue;
                    }
                }
            }

            return tFrames;
        }//--------------------

        //this function determines if the school year / semester must be opened
        public Boolean MustOpenSchoolYearSemester()
        {
            Boolean mustOpen = false;

            DateTime serverDate = DateTime.Parse(_serverDateTime);

            DataTable semTable = new DataTable("SemesterWithDateStartEndInformationTable");
            semTable.Columns.Add("sysid_semester", System.Type.GetType("System.String"));
            semTable.Columns.Add("year_id", System.Type.GetType("System.String"));
            semTable.Columns.Add("semester_id", System.Type.GetType("System.Byte"));
            semTable.Columns.Add("date_start", System.Type.GetType("System.DateTime"));
            semTable.Columns.Add("date_end", System.Type.GetType("System.DateTime"));
            semTable.Columns.Add("year_description", System.Type.GetType("System.String"));
            semTable.Columns.Add("semester_description", System.Type.GetType("System.String"));

            foreach (DataRow semRow in _classDataSet.Tables["SemesterInformationTable"].Rows)
            {
                DataRow newRow = semTable.NewRow();

                newRow["sysid_semester"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "sysid_semester", "");
                newRow["year_id"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "year_id", "");
                newRow["semester_id"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "semester_id", Byte.Parse("0"));
                newRow["date_start"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "date_start", DateTime.Parse(_serverDateTime));
                newRow["date_end"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "date_end", DateTime.Parse(_serverDateTime));
                newRow["year_description"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "year_description", "");
                newRow["semester_description"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "semester_description", "");

                semTable.Rows.Add(newRow);
            }

            semTable.AcceptChanges();

            String semFilter = "(date_end >= '" + serverDate.AddMonths((Int32)CommonExchange.SystemRange.MonthAllowance).ToShortDateString() + "') AND " +
                "(date_start <= '" + serverDate.ToShortDateString() +
                "' OR date_start <= '" + serverDate.AddMonths((Int32)CommonExchange.SystemRange.MonthAllowance).ToShortDateString() + "')";
            DataRow[] selectSemRow = semTable.Select(semFilter);

            if (selectSemRow.Length == 0)
            {
                mustOpen = true;
            }

            DataTable yearTable = new DataTable("SchoolYearWithDateStartEndInformationTable");
            yearTable.Columns.Add("year_id", System.Type.GetType("System.String"));
            yearTable.Columns.Add("year_description", System.Type.GetType("System.String"));
            yearTable.Columns.Add("date_start", System.Type.GetType("System.DateTime"));
            yearTable.Columns.Add("date_end", System.Type.GetType("System.DateTime"));

            foreach (DataRow yearRow in _classDataSet.Tables["SchoolFeeInformationTable"].Rows)
            {
                DataRow newRow = yearTable.NewRow();

                newRow["year_id"] = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "year_id", "");
                newRow["year_description"] = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "year_description", "");
                newRow["date_start"] = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "date_start", DateTime.Parse(_serverDateTime));
                newRow["date_end"] = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "date_end", DateTime.Parse(_serverDateTime));

                yearTable.Rows.Add(newRow);
            }

            yearTable.AcceptChanges();

            String yearFilter = "(date_end >= '" + serverDate.AddMonths((Int32)CommonExchange.SystemRange.MonthAllowance).ToShortDateString() + "') AND " +
                "(date_start <= '" + serverDate.ToShortDateString() +
                "' OR date_start <= '" + serverDate.AddMonths((Int32)CommonExchange.SystemRange.MonthAllowance).ToShortDateString() + "')";
            DataRow[] selectYearRow = yearTable.Select(yearFilter);

            if (selectYearRow.Length == 0)
            {
                mustOpen = true;
            }

            return mustOpen;
        } //--------------------------------------------

        //this function determines if the schedule information has more than one details
        public Boolean HasValidCountOfScheduleDetails(String scheduleSysId, Boolean isTeamTeaching)
        {
            Int32 count = 0;

            if (_scheduleDetailsTable != null && _schedList != null)
            {
                String strFilter = "sysid_schedule = '" + scheduleSysId + "' AND is_marked_deleted_details = '" + false.ToString() + "'";
                DataRow[] selectRow = _scheduleDetailsTable.Select(strFilter, "sysid_scheddetails ASC");

                foreach (DataRow schedRow in selectRow)
                {
                    Boolean isFound = false;

                    foreach (ScheduleList schedList in _schedList)
                    {
                        if (String.Equals(schedList.ScheduleDetailsInfo.ScheduleDetailsSysId,
                            RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_scheddetails", "")))
                        {
                            isFound = true;
                            break;
                        }
                    }

                    if (!isFound)
                    {
                        count++;
                    }
                }

                foreach (ScheduleList schedList in _schedList)
                {
                    if (schedList.RowState != DataRowState.Deleted)
                    {
                        count++;
                    }
                }                
            }

            return ((isTeamTeaching && count > 1) || (!isTeamTeaching && count >= 1)) ? true : false;
        } //------------------------------------------           

        //this function gets the school year year id
        public String GetSchoolYearYearId(Int32 index)
        {
            DataRow _yearRow = _classDataSet.Tables["SchoolFeeInformationTable"].Rows[index];

            return _yearRow["year_id"].ToString();
        } //----------------------------

        //this function gets the school year date start
        public DateTime GetSchoolYearDateStart(String yearId)
        {
            DateTime dateStart = DateTime.Parse(_serverDateTime);

            foreach (DataRow yearRow in _classDataSet.Tables["SchoolFeeInformationTable"].Rows)
            {
                if (String.Equals(yearId, yearRow["year_id"].ToString()) &&
                    DateTime.TryParse(yearRow["date_start"].ToString(), out dateStart))
                {
                    break;
                }
            }

            return dateStart;
        } //----------------------------------------

        //this function gets the school year date end
        public DateTime GetSchoolYearDateEnd(String yearId)
        {
            DateTime dateEnd = DateTime.Parse(_serverDateTime);

            foreach (DataRow yearRow in _classDataSet.Tables["SchoolFeeInformationTable"].Rows)
            {
                if (String.Equals(yearId, yearRow["year_id"].ToString()) &&
                    DateTime.TryParse(yearRow["date_end"].ToString(), out dateEnd))
                {
                    break;
                }
            }

            return dateEnd;
        } //------------------------------

        //this function gets the semester date start
        public DateTime GetSemesterDateStart(String semSysId)
        {
            DateTime dateStart = DateTime.Parse(_serverDateTime);

            foreach (DataRow semRow in _classDataSet.Tables["SemesterInformationTable"].Rows)
            {
                if (String.Equals(semSysId, semRow["sysid_semester"].ToString()) &&
                    DateTime.TryParse(semRow["date_start"].ToString(), out dateStart))
                {
                    break;
                }
            }

            return dateStart;
        } //----------------------------------------

        //this function gets the semester date end
        public DateTime GetSemesterDateEnd(String semSysId)
        {
            DateTime dateEnd = DateTime.Parse(_serverDateTime);

            foreach (DataRow semRow in _classDataSet.Tables["SemesterInformationTable"].Rows)
            {
                if (String.Equals(semSysId, semRow["sysid_semester"].ToString()) &&
                    DateTime.TryParse(semRow["date_end"].ToString(), out dateEnd))
                {
                    break;
                }
            }

            return dateEnd;
        } //------------------------------

        //this function gets the year or semester id
        public String GetYearSemesterId(Boolean isSemester, Int32 index)
        {
            String yearSemesterId = "";

            if (isSemester && _semesterTable != null)
            {
                DataRow semRow = _semesterTable.Rows[index];

                yearSemesterId = semRow["sysid_semester"].ToString();
            }
            else if (!isSemester && _yearTable != null)
            {
                DataRow yearRow = _yearTable.Rows[index];

                yearSemesterId = yearRow["year_id"].ToString();
            }

            return yearSemesterId;
        } //-------------------------------

        //this function gets the semester system id
        public String GetSemesterSystemId(Int32 yearIndex, Int32 semIndex)
        {
            DataRow yearRow = _classDataSet.Tables["SchoolFeeInformationTable"].Rows[yearIndex];

            String strFilter = "year_id = '" + yearRow["year_id"].ToString() + "'";
            DataRow[] selectRow = _classDataSet.Tables["SemesterInformationTable"].Select(strFilter);

            DataRow semRow = selectRow[semIndex];

            return semRow["sysid_semester"].ToString();
        } //-----------------------------------------

        //this function gets the units hours string
        public String GetSubjectUnitsHours(Byte lectUnits, Byte labUnits, String noHours)
        {
            return "Lecture: " + lectUnits.ToString() + " " + ((lectUnits > 1) ? "units" : "unit") + "     " +
                "Laboratory / RLE: " + labUnits.ToString() + " " + ((labUnits > 1) ? "units" : "unit") + "     " +
                "No. of Hours: " + noHours;
        } //-----------------------------------

        //this function returns a schedule information details
        public CommonExchange.ScheduleInformationDetails GetDetailsScheduleInformationDetails(String scheduleDetailsSysId)
        {
            CommonExchange.ScheduleInformationDetails scheduleDetailsInfo = new CommonExchange.ScheduleInformationDetails();
            Boolean isFound = false;            

            if (_schedList != null)
            {
                foreach (ScheduleList schedList in _schedList)
                {
                    if (String.Equals(schedList.ScheduleDetailsInfo.ScheduleDetailsSysId, scheduleDetailsSysId))
                    {
                        scheduleDetailsInfo.ScheduleDetailsSysId = schedList.ScheduleDetailsInfo.ScheduleDetailsSysId;
                        scheduleDetailsInfo.ScheduleInfo.ScheduleSysId = schedList.ScheduleDetailsInfo.ScheduleInfo.ScheduleSysId;
                        scheduleDetailsInfo.ClassroomInfo.ClassroomSysId = schedList.ScheduleDetailsInfo.ClassroomInfo.ClassroomSysId;
                        scheduleDetailsInfo.FieldRoom = schedList.ScheduleDetailsInfo.FieldRoom;
                        scheduleDetailsInfo.IsClassroom = schedList.ScheduleDetailsInfo.IsClassroom;
                        scheduleDetailsInfo.LectureUnits = schedList.ScheduleDetailsInfo.LectureUnits;
                        scheduleDetailsInfo.LabUnits = schedList.ScheduleDetailsInfo.LabUnits;
                        scheduleDetailsInfo.NoHours = schedList.ScheduleDetailsInfo.NoHours;
                        scheduleDetailsInfo.Section = schedList.ScheduleDetailsInfo.Section;
                        scheduleDetailsInfo.IsMarkedDeleted = schedList.ScheduleDetailsInfo.IsMarkedDeleted;
                        scheduleDetailsInfo.ClassroomInfo.ClassroomCode = schedList.ScheduleDetailsInfo.ClassroomInfo.ClassroomCode;
                        scheduleDetailsInfo.ClassroomInfo.MaximumCapacity = schedList.ScheduleDetailsInfo.ClassroomInfo.MaximumCapacity;
                        scheduleDetailsInfo.DayTimeClassroom = schedList.ScheduleDetailsInfo.DayTimeClassroom;
                        scheduleDetailsInfo.DayTimeFieldRoom = schedList.ScheduleDetailsInfo.DayTimeFieldRoom;
                        scheduleDetailsInfo.EmployeeInfo.EmployeeSysId = schedList.ScheduleDetailsInfo.EmployeeInfo.EmployeeSysId;
                        scheduleDetailsInfo.EmployeeInfo.PersonInfo.LastName = schedList.ScheduleDetailsInfo.EmployeeInfo.PersonInfo.LastName;
                        scheduleDetailsInfo.EmployeeInfo.PersonInfo.FirstName = schedList.ScheduleDetailsInfo.EmployeeInfo.PersonInfo.FirstName;
                        scheduleDetailsInfo.EmployeeInfo.PersonInfo.MiddleName = schedList.ScheduleDetailsInfo.EmployeeInfo.PersonInfo.MiddleName;
                        scheduleDetailsInfo.EmployeeInfo.SalaryInfo.EmploymentTypeInfo.TypeDescription = 
                            schedList.ScheduleDetailsInfo.EmployeeInfo.SalaryInfo.EmploymentTypeInfo.TypeDescription;
                        scheduleDetailsInfo.EmployeeInfo.SalaryInfo.EmployeeStatusInfo.StatusDescription = 
                            schedList.ScheduleDetailsInfo.EmployeeInfo.SalaryInfo.EmployeeStatusInfo.StatusDescription;
                        scheduleDetailsInfo.EmployeeInfo.SalaryInfo.DepartmentInfo.DepartmentName =
                            schedList.ScheduleDetailsInfo.EmployeeInfo.SalaryInfo.DepartmentInfo.DepartmentName;
                        scheduleDetailsInfo.ManualSchedule = schedList.ScheduleDetailsInfo.ManualSchedule;
                        scheduleDetailsInfo.ManualScheduleClassroom = schedList.ScheduleDetailsInfo.ManualScheduleClassroom;
                        scheduleDetailsInfo.ManualScheduleFieldRoom = schedList.ScheduleDetailsInfo.ManualScheduleFieldRoom;

                        isFound = true;

                        break;
                    }
                }
            }

            if (!isFound && _scheduleDetailsTable != null)
            {
                String strFilter = "sysid_scheddetails = '" + scheduleDetailsSysId + "'";
                DataRow[] selectRow = _scheduleDetailsTable.Select(strFilter, "sysid_scheddetails ASC");

                foreach (DataRow detailsRow in selectRow)
                {
                    scheduleDetailsInfo.ScheduleDetailsSysId = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "sysid_scheddetails", "");
                    scheduleDetailsInfo.ScheduleInfo.ScheduleSysId = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "sysid_schedule", "");
                    scheduleDetailsInfo.ClassroomInfo.ClassroomSysId = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "sysid_classroom", "");
                    scheduleDetailsInfo.FieldRoom = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "field_room", "");
                    scheduleDetailsInfo.IsClassroom = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_classroom", true);
                    scheduleDetailsInfo.LectureUnits = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "lecture_units_details", Single.Parse("0"));
                    scheduleDetailsInfo.LabUnits = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "lab_units_details", Single.Parse("0"));
                    scheduleDetailsInfo.NoHours = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "no_hours_details", "");
                    scheduleDetailsInfo.Section = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "section", "");
                    scheduleDetailsInfo.IsMarkedDeleted = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_marked_deleted_details", true);
                    scheduleDetailsInfo.ClassroomInfo.ClassroomCode = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "classroom_code", "");
                    scheduleDetailsInfo.ClassroomInfo.MaximumCapacity = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "maximum_capacity", Byte.Parse("0"));

                    if (scheduleDetailsInfo.IsClassroom)
                    {
                        scheduleDetailsInfo.DayTimeClassroom = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "day_time", "");
                    }
                    else
                    {
                        scheduleDetailsInfo.DayTimeFieldRoom = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "day_time", ""); 
                    }

                    scheduleDetailsInfo.EmployeeInfo.EmployeeSysId = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "sysid_employee", "");
				    scheduleDetailsInfo.EmployeeInfo.PersonInfo.LastName = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "last_name", "");
				    scheduleDetailsInfo.EmployeeInfo.PersonInfo.FirstName = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "first_name", "");
				    scheduleDetailsInfo.EmployeeInfo.PersonInfo.MiddleName = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "middle_name", "");
				    scheduleDetailsInfo.EmployeeInfo.SalaryInfo.EmploymentTypeInfo.TypeDescription = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, 
                        "type_description", "");
				    scheduleDetailsInfo.EmployeeInfo.SalaryInfo.EmployeeStatusInfo.StatusDescription = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow,
                        "status_description", "");
                    scheduleDetailsInfo.EmployeeInfo.SalaryInfo.DepartmentInfo.DepartmentName = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow,
                        "employee_department_name", "");
                    scheduleDetailsInfo.ManualSchedule = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "manual_schedule", String.Empty);
                    scheduleDetailsInfo.ManualScheduleClassroom = scheduleDetailsInfo.IsClassroom ?
                        scheduleDetailsInfo.ManualSchedule : String.Empty;
                    scheduleDetailsInfo.ManualScheduleFieldRoom = scheduleDetailsInfo.IsClassroom ?
                        String.Empty : scheduleDetailsInfo.ManualSchedule;

                    break;
                }
            }

            return scheduleDetailsInfo;
        } //-------------------------------------

        //this function returns the schedule details for a schedule information
        public DataTable GetBySysIdScheduleScheduleDetailsTable(String scheduleSysId, Boolean isIrregualarModular)
        {
            DataTable classRoomTimeTable = new DataTable("ClassRoomTimeTable");
            classRoomTimeTable.Columns.Add("date_time", System.Type.GetType("System.String"));
            classRoomTimeTable.Columns.Add("section", System.Type.GetType("System.String"));
            classRoomTimeTable.Columns.Add("class_room", System.Type.GetType("System.String"));

            if (_scheduleDetailsTable != null)
            {
                String strFilter = "sysid_schedule = '" + scheduleSysId + "'";
                DataRow[] selectRow = _scheduleDetailsTable.Select(strFilter, "sysid_scheddetails DESC");

                foreach (DataRow dRow in selectRow)
                {
                    if ((dRow.RowState != DataRowState.Deleted) && !RemoteServerLib.ProcStatic.DataRowConvert(dRow, "is_marked_deleted_details", true))
                    {
                        Boolean isFound = false;

                        if (_schedList != null)
                        {
                            foreach (ScheduleList list in _schedList)
                            {
                                if (String.Equals(list.ScheduleDetailsInfo.ScheduleDetailsSysId,
                                    RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_scheddetails", "")))
                                {
                                    isFound = true;

                                    break;
                                }
                            }
                        }

                        if (!isFound)
                        {
                            DataRow newRow = classRoomTimeTable.NewRow();

                            newRow["date_time"] = isIrregualarModular ? RemoteServerLib.ProcStatic.DataRowConvert(dRow, "manual_schedule", "") : 
                                RemoteServerLib.ProcStatic.DataRowConvert(dRow, "day_time", "");
                            newRow["date_time"] = String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(newRow, "date_time", String.Empty)) ?
                                "TBA" : RemoteServerLib.ProcStatic.DataRowConvert(newRow, "date_time", String.Empty);
                            newRow["section"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "section", "");
                            newRow["class_room"] = String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "field_room", "")) ?
                                (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "classroom_code", "")) ? c_tbaString :
                                RemoteServerLib.ProcStatic.DataRowConvert(dRow, "classroom_code", "")) :
                                RemoteServerLib.ProcStatic.DataRowConvert(dRow, "field_room", "");

                            classRoomTimeTable.Rows.Add(newRow);
                        }
                    }
                }
            }

            if (_schedList != null)
            {
                foreach (ScheduleList schedList in _schedList)
                {
                    if (schedList.RowState == DataRowState.Added || schedList.RowState == DataRowState.Modified)
                    {
                        CommonExchange.ScheduleInformationDetails detailsInfo = schedList.ScheduleDetailsInfo;

                        DataRow newRow = classRoomTimeTable.NewRow();

                        newRow["date_time"] = detailsInfo.IsClassroom ? detailsInfo.DayTimeClassroom : detailsInfo.DayTimeFieldRoom;
                        newRow["date_time"] = String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(newRow, "date_time", String.Empty)) ?
                               "TBA" : RemoteServerLib.ProcStatic.DataRowConvert(newRow, "date_time", String.Empty);
                        newRow["section"] = detailsInfo.Section;
                        newRow["class_room"] = String.IsNullOrEmpty(detailsInfo.FieldRoom) ?
                            (String.IsNullOrEmpty(detailsInfo.ClassroomInfo.ClassroomCode) ?
                            c_tbaString : detailsInfo.ClassroomInfo.ClassroomCode) : detailsInfo.FieldRoom;

                        classRoomTimeTable.Rows.Add(newRow);
                    }
                }
            }

            return classRoomTimeTable;
        } //----------------------------------

        //this function returns a schedule information details
        public CommonExchange.ScheduleInformation GetDetailsScheduleInformation(String scheduleSysId)
        {
            CommonExchange.ScheduleInformation schedInfo = new CommonExchange.ScheduleInformation();

            if (_scheduleDetailsTable != null)
            {
                String strFilter = "sysid_schedule = '" + scheduleSysId + "'";
                DataRow[] selectRow = _scheduleDetailsTable.Select(strFilter, "sysid_schedule ASC");

                foreach (DataRow schedRow in selectRow)
                {
                    schedInfo.ScheduleSysId = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_schedule", "");
                    schedInfo.SubjectInfo.SubjectSysId = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_subject", "");

                    schedInfo.SubjectInfo.CourseGroupInfo.IsSemestral = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "is_semestral", false);

                    if (schedInfo.SubjectInfo.CourseGroupInfo.IsSemestral)
                    {
                        schedInfo.SchoolYearInfo.YearId = "";
                        schedInfo.SemesterInfo.SemesterSysId = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "year_semester_id", "");
                    }
                    else
                    {
                        schedInfo.SchoolYearInfo.YearId = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "year_semester_id", "");
                        schedInfo.SemesterInfo.SemesterSysId = "";
                    }

                    schedInfo.Amount = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "amount", Decimal.Parse("0"));
                    schedInfo.IsFixedAmount = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "is_fixed_amount", false);
                    schedInfo.IsMarkedDeleted = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "is_marked_deleted_schedule", true);
                    schedInfo.SubjectInfo.SubjectCode = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "subject_code", "");
                    schedInfo.SubjectInfo.DescriptiveTitle = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "descriptive_title", "");
                    schedInfo.SubjectInfo.LectureUnits = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "lecture_units_schedule", Byte.Parse("0"));
                    schedInfo.SubjectInfo.LabUnits = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "lab_units_schedule", Byte.Parse("0"));
                    schedInfo.SubjectInfo.NoHours = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "no_hours_schedule", "");
                    schedInfo.SubjectInfo.DepartmentInfo.DepartmentName = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "subject_department_name", "");
                    schedInfo.IsTeamTeaching = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "is_team_teaching", false);
                    schedInfo.SubjectInfo.DepartmentInfo.DepartmentId = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "department_id", "");
                    schedInfo.IsIrregularModular = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "is_irregular_modular", false);
                    schedInfo.AdditionalSlots = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "additional_slots", Int16.Parse("0"));

                    break;

                }
            }

            return schedInfo;
        } //------------------------------

        //this function returns the schedule details for a schedule information
        public DataTable GetBySysIdScheduleScheduleDetailsTable(String scheduleSysId, Boolean isMarkedDeleted, ref Int32 detailsLoaded)
        {
            DataTable detailsTable = new DataTable("ScheduleDetailsBySysIdTable");
            detailsTable.Columns.Add("sysid_scheddetails", System.Type.GetType("System.String"));
            detailsTable.Columns.Add("day_time", System.Type.GetType("System.String"));
            detailsTable.Columns.Add("section", System.Type.GetType("System.String"));
            detailsTable.Columns.Add("classroom_field_code", System.Type.GetType("System.String"));
            detailsTable.Columns.Add("lecture_units", System.Type.GetType("System.Single"));
            detailsTable.Columns.Add("lab_units", System.Type.GetType("System.Single"));
            detailsTable.Columns.Add("no_hours", System.Type.GetType("System.String"));

            if (_scheduleDetailsTable != null)
            {
                String strFilter = "sysid_schedule = '" + scheduleSysId + "'";
                DataRow[] selectRow = _scheduleDetailsTable.Select(strFilter, "sysid_scheddetails DESC");

                foreach (DataRow dRow in selectRow)
                {
                    if (dRow.RowState != DataRowState.Deleted &&
                        RemoteServerLib.ProcStatic.DataRowConvert(dRow, "is_marked_deleted_details", true) == isMarkedDeleted)
                    {                        
                        Boolean isFound = false;

                        if (_schedList != null)
                        {
                            foreach (ScheduleList list in _schedList)
                            {
                                if (String.Equals(list.ScheduleDetailsInfo.ScheduleDetailsSysId, 
                                    RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_scheddetails", "")))
                                {
                                    isFound = true;

                                    break;
                                }
                            }
                        }

                        if (!isFound)
                        {
                            if (dRow.RowState != DataRowState.Deleted)
                            {
                                DataRow newRow = detailsTable.NewRow();

                                newRow["sysid_scheddetails"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_scheddetails", "");

                                if (!RemoteServerLib.ProcStatic.DataRowConvert(dRow, "is_irregular_modular", false))
                                {
                                    //DD Code
                                    //newRow["day_time"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "is_classroom", false) ?
                                    //    (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "day_time", "")) ?
                                    //    c_tbaString : RemoteServerLib.ProcStatic.DataRowConvert(dRow, "day_time", "")) : c_tbaString;

                                    //AD Code
                                    newRow["day_time"] = String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "day_time", "")) ?
                                        c_tbaString : RemoteServerLib.ProcStatic.DataRowConvert(dRow, "day_time", "");
                                }
                                else
                                {
                                    newRow["day_time"] = String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "manual_schedule", String.Empty)) ?
                                        c_tbaString : RemoteServerLib.ProcStatic.DataRowConvert(dRow, "manual_schedule", String.Empty);
                                }

                                newRow["section"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "section", "");
                                newRow["classroom_field_code"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "is_classroom", false) ?
                                    (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "classroom_code", "")) ? c_tbaString :
                                    RemoteServerLib.ProcStatic.DataRowConvert(dRow, "classroom_code", "")) :
                                    String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "field_room", "")) ? c_tbaString :
                                    RemoteServerLib.ProcStatic.DataRowConvert(dRow, "field_room", "");
                                newRow["lecture_units"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "lecture_units_details", Single.Parse("0"));
                                newRow["lab_units"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "lab_units_details", Single.Parse("0"));
                                newRow["no_hours"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "no_hours_details", "");
                                                                
                                detailsTable.Rows.Add(newRow);

                                if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_employee", "")))
                                {
                                    detailsLoaded++;
                                }
                            }
                        }
                    }
                }
            }

            if (_schedList != null && !isMarkedDeleted)
            {
                foreach (ScheduleList schedList in _schedList)
                {
                    if (schedList.RowState == DataRowState.Added || schedList.RowState == DataRowState.Modified)
                    {
                        CommonExchange.ScheduleInformationDetails detailsInfo = schedList.ScheduleDetailsInfo;

                        DataRow newRow = detailsTable.NewRow();

                        newRow["sysid_scheddetails"] = detailsInfo.ScheduleDetailsSysId;

                        if (!schedList.IsIrregularModular)
                        {
                            //DD Code
                            //newRow["day_time"] = detailsInfo.IsClassroom ?
                            //    (String.IsNullOrEmpty(detailsInfo.DayTime) ? c_tbaString : detailsInfo.DayTime) : c_tbaString;

                            //AD Code
                            newRow["day_time"] = String.IsNullOrEmpty(detailsInfo.DayTimeClassroom) && String.IsNullOrEmpty(detailsInfo.DayTimeFieldRoom) ?
                                c_tbaString : (detailsInfo.IsClassroom ? detailsInfo.DayTimeClassroom : detailsInfo.DayTimeFieldRoom);
                        }
                        else
                        {
                            newRow["day_time"] = String.IsNullOrEmpty(schedList.ScheduleDetailsInfo.ManualSchedule) ? 
                                c_tbaString : schedList.ScheduleDetailsInfo.ManualSchedule;
                        }

                        newRow["section"] = detailsInfo.Section;
                        newRow["classroom_field_code"] = detailsInfo.IsClassroom ?  
                            (String.IsNullOrEmpty(detailsInfo.ClassroomInfo.ClassroomCode) ? c_tbaString : detailsInfo.ClassroomInfo.ClassroomCode) :
                            (String.IsNullOrEmpty(detailsInfo.FieldRoom) ? c_tbaString : detailsInfo.FieldRoom);
                        newRow["lecture_units"] = detailsInfo.LectureUnits;
                        newRow["lab_units"] = detailsInfo.LabUnits;
                        newRow["no_hours"] = detailsInfo.NoHours;

                        detailsTable.Rows.Add(newRow);

                        if (!String.IsNullOrEmpty(detailsInfo.EmployeeInfo.EmployeeSysId))
                        {
                            detailsLoaded++;
                        }
                    }
                }
            }
            else if (_schedList != null && isMarkedDeleted)
            {
                foreach (ScheduleList schedList in _schedList)
                {
                    if (schedList.RowState == DataRowState.Deleted)
                    {
                        CommonExchange.ScheduleInformationDetails detailsInfo = schedList.ScheduleDetailsInfo;

                        DataRow newRow = detailsTable.NewRow();

                        newRow["sysid_scheddetails"] = detailsInfo.ScheduleDetailsSysId;

                        if (!schedList.IsIrregularModular)
                        {
                            //DD Code
                            //newRow["day_time"] = detailsInfo.IsClassroom ?
                            //    (String.IsNullOrEmpty(detailsInfo.DayTime) ? c_tbaString : detailsInfo.DayTime) : c_tbaString;

                            //AD Code
                            newRow["day_time"] = String.IsNullOrEmpty(detailsInfo.DayTimeClassroom) && String.IsNullOrEmpty(detailsInfo.DayTimeFieldRoom) ?
                                c_tbaString : (detailsInfo.IsClassroom ? detailsInfo.DayTimeClassroom : detailsInfo.DayTimeFieldRoom);
                        }
                        else
                        {
                            newRow["day_time"] = String.IsNullOrEmpty(schedList.ScheduleDetailsInfo.ManualSchedule) ?
                                c_tbaString : schedList.ScheduleDetailsInfo.ManualSchedule;
                        }

                        newRow["section"] = detailsInfo.Section;
                        newRow["classroom_field_code"] = detailsInfo.IsClassroom ?  
                            (String.IsNullOrEmpty(detailsInfo.ClassroomInfo.ClassroomCode) ? c_tbaString : detailsInfo.ClassroomInfo.ClassroomCode) :
                            (String.IsNullOrEmpty(detailsInfo.FieldRoom) ? c_tbaString : detailsInfo.FieldRoom);
                        newRow["lecture_units"] = detailsInfo.LectureUnits;
                        newRow["lab_units"] = detailsInfo.LabUnits;
                        newRow["no_hours"] = detailsInfo.NoHours;
                       
                        detailsTable.Rows.Add(newRow);
                    }
                }
            }

            detailsTable.AcceptChanges();

            DataTable newTable = new DataTable("ScheduleDetailsBySysIdTable");
            newTable.Columns.Add("sysid_scheddetails", System.Type.GetType("System.String"));
            newTable.Columns.Add("day_time", System.Type.GetType("System.String"));
            newTable.Columns.Add("section", System.Type.GetType("System.String"));
            newTable.Columns.Add("classroom_field_code", System.Type.GetType("System.String"));
            newTable.Columns.Add("lecture_units", System.Type.GetType("System.Single"));
            newTable.Columns.Add("lab_units", System.Type.GetType("System.Single"));
            newTable.Columns.Add("no_hours", System.Type.GetType("System.String"));

            DataRow[] detailsRow = detailsTable.Select("", "sysid_scheddetails DESC");

            foreach (DataRow dRow in detailsRow)
            {
                DataRow newRow = newTable.NewRow();

                newRow["sysid_scheddetails"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_scheddetails", "");
                newRow["day_time"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "day_time", "");
                newRow["section"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "section", "");
                newRow["classroom_field_code"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "classroom_field_code", "");
                newRow["lecture_units"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "lecture_units", Single.Parse("0"));
                newRow["lab_units"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "lab_units", Single.Parse("0"));
                newRow["no_hours"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "no_hours", "");

                newTable.Rows.Add(newRow);
            }


            return newTable;
        } //----------------------------------        

        //this function determines if there is a schedule details that has a load
        public Boolean IsScheduleHasScheduleDetailsLoaded(String scheduleSysId)
        {
            Boolean hasLoad = false;

            if (_scheduleDetailsTable != null)
            {
                String strFilter = "sysid_schedule = '" + scheduleSysId + "'";
                DataRow[] selectRow = _scheduleDetailsTable.Select(strFilter, "sysid_schedule ASC");

                foreach (DataRow schedRow in selectRow)
                {
                    if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_employee", "")))
                    {
                        hasLoad = true;
                        break;
                    }
                }
            }

            return hasLoad;
        } //--------------------------

        //this function returns a searched schedule information
        public DataTable GetSearchedScheduleInformationDetails()
        {
            DataTable newTable = new DataTable("ScheduleInformationDetailsSearchedTable");
            newTable.Columns.Add("sysid_schedule", System.Type.GetType("System.String"));
            newTable.Columns.Add("subject_code_title", System.Type.GetType("System.String"));
            newTable.Columns.Add("day_time", System.Type.GetType("System.String"));
            newTable.Columns.Add("section", System.Type.GetType("System.String"));
            newTable.Columns.Add("classroom_field_code", System.Type.GetType("System.String"));
            newTable.Columns.Add("slots_available_no_freeze", System.Type.GetType("System.String"));
                        
            foreach (DataRow dRow in _scheduleDetailsTable.Rows)
            {
                DataRow newRow = newTable.NewRow();

                newRow["sysid_schedule"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_schedule", "");
                newRow["subject_code_title"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "subject_code", "") + " - " +
                    RemoteServerLib.ProcStatic.DataRowConvert(dRow, "descriptive_title", "");
                newRow["day_time"] = !RemoteServerLib.ProcStatic.DataRowConvert(dRow, "is_irregular_modular", false) ?
                    RemoteServerLib.ProcStatic.DataRowConvert(dRow, "day_time", "") :
                    RemoteServerLib.ProcStatic.DataRowConvert(dRow, "manual_schedule", String.Empty);
                newRow["section"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "section", "");
                newRow["classroom_field_code"] = String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "field_room", "")) ?
                    (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "classroom_code", "")) ? c_tbaString :
                    RemoteServerLib.ProcStatic.DataRowConvert(dRow, "classroom_code", "")) :
                    RemoteServerLib.ProcStatic.DataRowConvert(dRow, "field_room", "");

                Int16 totalRoomCapacity = (Int16)(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "maximum_capacity", Byte.Parse("0")) + 
                    RemoteServerLib.ProcStatic.DataRowConvert(dRow, "additional_slots", Int16.Parse("0")));

                newRow["slots_available_no_freeze"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "slots_available", Int16.Parse("0")) == -32768 ?
                    "TBA/F" : (totalRoomCapacity -
                    (totalRoomCapacity - RemoteServerLib.ProcStatic.DataRowConvert(dRow, "slots_available", Int16.Parse("0")))) <= 0 ?
                    totalRoomCapacity.ToString() + "/" + totalRoomCapacity.ToString() :
                    (totalRoomCapacity - RemoteServerLib.ProcStatic.DataRowConvert(dRow, "slots_available", Int16.Parse("0"))).ToString() + "/" + 
                    totalRoomCapacity.ToString();

                newTable.Rows.Add(newRow);
            }

            newTable.AcceptChanges();

            return newTable;
        }//---------------------------------

        //this function returns the student details
        public CommonExchange.Student GetDetailsStudentInformation(CommonExchange.SysAccess userInfo, String studentId, String startUp)
        {
            CommonExchange.Student studentInfo = new CommonExchange.Student();

            if (!String.IsNullOrEmpty(studentId))
            {
                String strFilter = "student_id = '" + studentId + "'";
                DataRow[] selectRow = _studentEnrolledTable.Select(strFilter);

                foreach (DataRow studRow in selectRow)
                {
                    studentInfo.StudentSysId = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", String.Empty);
                    studentInfo.StudentId = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "student_id", "");
                    studentInfo.CardNumber = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "card_number", String.Empty);
                    studentInfo.PersonInfo.LastName = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "last_name", String.Empty);
                    studentInfo.PersonInfo.FirstName = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "first_name", String.Empty);
                    studentInfo.PersonInfo.MiddleName = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "middle_name", String.Empty);
                    studentInfo.IsInternational = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "is_international", false);
                    studentInfo.CourseInfo.CourseId = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_id", String.Empty);
                    studentInfo.PersonInfo.PersonSysId = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_person", String.Empty);

                    break;
                }

                studentInfo.PersonInfo.FilePath = base.GetPersonImagePath(userInfo, studentInfo.PersonInfo.PersonSysId,
                    studentInfo.PersonInfo.PersonImagesFolder(startUp));
            }

            return studentInfo;
        }//----------------------------        

        //this function returns a subject information details
        public CommonExchange.SubjectInformation GetDetailsSubjectInformation(String subjectSysId)
        {
            CommonExchange.SubjectInformation subjectInfo = new CommonExchange.SubjectInformation();

            if (_subjectTable != null)
            {
                String strFilter = "sysid_subject = '" + subjectSysId + "'";
                DataRow[] selectRow = _subjectTable.Select(strFilter, "subject_code ASC");

                foreach (DataRow subjectRow in selectRow)
                {
                    subjectInfo.SubjectSysId = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "sysid_subject", "");
                    subjectInfo.CourseGroupInfo.CourseGroupId = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "course_group_id", "");
                    subjectInfo.DepartmentInfo.DepartmentId = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "department_id", "");
                    subjectInfo.SubjectCode = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "subject_code", "");
                    subjectInfo.DescriptiveTitle = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "descriptive_title", "");
                    subjectInfo.LectureUnits = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "lecture_units", Byte.Parse("0"));
                    subjectInfo.LabUnits = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "lab_units", Byte.Parse("0"));
                    subjectInfo.NoHours = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "no_hours", "");
                    subjectInfo.OtherInformation = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "other_information", "");
                    subjectInfo.CourseGroupInfo.IsSemestral = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "is_semestral", false);
                    subjectInfo.DepartmentInfo.DepartmentName = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "department_name", "");
                }
            }

            return subjectInfo;
        } //--------------------------------------

        //this function returns a searched subject information
        public DataTable GetSearchedSubjectInformation(CommonExchange.SysAccess userInfo, String queryString, Boolean isNewQuery)
        {
            if (isNewQuery)
            {
                using (RemoteClient.RemCntCourseManager remClient = new RemoteClient.RemCntCourseManager())
                {
                    _subjectTable = remClient.SelectSubjectInformation(userInfo, queryString);
                }
            }

            DataTable subjectTable = new DataTable("SubjectConcatCodeTitleTable");
            subjectTable.Columns.Add("sysid_subject", System.Type.GetType("System.String"));
            subjectTable.Columns.Add("subject_code_title", System.Type.GetType("System.String"));
            subjectTable.Columns.Add("department_name", System.Type.GetType("System.String"));

            if (_subjectTable != null)
            {
                foreach (DataRow subjectRow in _subjectTable.Rows)
                {
                    DataRow newRow = subjectTable.NewRow();

                    newRow["sysid_subject"] = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "sysid_subject", "");
                    newRow["subject_code_title"] = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "subject_code", "") + " - " +
                                            RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "descriptive_title", "");
                    newRow["department_name"] = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "department_name", "");

                    subjectTable.Rows.Add(newRow);
                }
            }

            subjectTable.AcceptChanges();

            return subjectTable;
        } //--------------------------- 

        //this function returns a classroom information details
        public CommonExchange.ClassroomInformation GetDetailsClassroomInformation(String roomId)
        {
            CommonExchange.ClassroomInformation roomInfo = new CommonExchange.ClassroomInformation();

            String strFilter = "sysid_classroom = '" + roomId + "'";
            DataRow[] selectRow = _classDataSet.Tables["ClassroomInformationTable"].Select(strFilter, "classroom_code ASC");

            foreach (DataRow roomRow in selectRow)
            {
                roomInfo.ClassroomSysId = RemoteServerLib.ProcStatic.DataRowConvert(roomRow, "sysid_classroom", "");
                roomInfo.ClassroomCode = RemoteServerLib.ProcStatic.DataRowConvert(roomRow, "classroom_code", "");
                roomInfo.Description = RemoteServerLib.ProcStatic.DataRowConvert(roomRow, "classroom_description", "");
                roomInfo.MaximumCapacity = RemoteServerLib.ProcStatic.DataRowConvert(roomRow, "maximum_capacity", Byte.Parse("0"));
                roomInfo.OtherInformation = RemoteServerLib.ProcStatic.DataRowConvert(roomRow, "other_information", "");
            }

            return roomInfo;
        } //--------------------------------------

        //this function returns a searched classroom information
        public DataTable GetSearchedClassroomInformation(String strCriteria)
        {
            DataTable newTable = new DataTable("ClassroomInformationSearchTable");
            newTable.Columns.Add("sysid_classroom", System.Type.GetType("System.String"));
            newTable.Columns.Add("classroom_code", System.Type.GetType("System.String"));
            newTable.Columns.Add("classroom_description", System.Type.GetType("System.String"));
            newTable.Columns.Add("maximum_capacity", System.Type.GetType("System.Byte"));

            strCriteria = strCriteria.Replace("*", "").Replace("%", "").Replace("'", "''");

            String strFilter = "classroom_code LIKE '%" + strCriteria + "%'";
            DataRow[] selectRow = _classDataSet.Tables["ClassroomInformationTable"].Select(strFilter, "classroom_code ASC");

            foreach (DataRow roomRow in selectRow)
            {
                DataRow newRow = newTable.NewRow();

                newRow["sysid_classroom"] = roomRow["sysid_classroom"].ToString();
                newRow["classroom_code"] = roomRow["classroom_code"].ToString();
                newRow["classroom_description"] = roomRow["classroom_description"].ToString();
                newRow["maximum_capacity"] = roomRow["maximum_capacity"].ToString();

                newTable.Rows.Add(newRow);
            }

            newTable.AcceptChanges();

            return newTable;

        } //---------------------------   
 
        //this function sets the subject schedule table
        private DataTable GenerateScheduleTable(String scheduleDetailsSysId, Int32[][][] tFrames, Int32 noOfDaysDisplayed,
            Int32 noOfTimeSlotsDisplayed, Int32 selectedIndex, Int32 readOnlyIndex, Int32 selectedValue, Int32 readOnlyValue, DataTable scheduleTable)
        {
            DataTable schedTable = new DataTable("SubjectScheduleInsertUpdateDeleteTable");
            schedTable.Columns.Add("schedule_id", System.Type.GetType("System.Int64"));
            schedTable.Columns.Add("week_id", System.Type.GetType("System.Byte"));
            schedTable.Columns.Add("time_id", System.Type.GetType("System.Byte"));

            if (tFrames != null)
            {
                Int32 index = -1;

                for (Int32 i = 0; i < noOfDaysDisplayed; i++)
                {
                    for (Int32 j = 0; j < noOfTimeSlotsDisplayed; j++)
                    {
                        if (tFrames[i][j][selectedIndex] == selectedValue &&
                            tFrames[i][j][readOnlyIndex] != readOnlyValue)
                        {
                            if (this.IsNewSchedule(scheduleDetailsSysId, i, j, scheduleTable))
                            {
                                index++;

                                DataRow newRow = schedTable.NewRow();

                                newRow["week_id"] = i;
                                newRow["time_id"] = j;

                                schedTable.Rows.Add(newRow);
                            }
                        }
                        else if (tFrames[i][j][selectedIndex] != selectedValue &&
                            tFrames[i][j][readOnlyIndex] != readOnlyValue)
                        {
                            Int64 scheduleId = 0;

                            if (this.IsDeletedSchedule(scheduleDetailsSysId, i, j, ref scheduleId, scheduleTable))
                            {
                                index++;

                                DataRow newRow = schedTable.NewRow();

                                newRow["schedule_id"] = scheduleId;
                                newRow["week_id"] = i;
                                newRow["time_id"] = j;

                                schedTable.Rows.Add(newRow);
                                schedTable.Rows[index].AcceptChanges();

                                DataRow delRow = schedTable.Rows[index];

                                delRow.Delete();
                            }
                        }
                    }
                }
            }

            return schedTable;
        } //---------------------------------------

        //this function sets the subject schedule table
        public DataTable GenerateScheduleTable(Int32[][][] tFrames, Int32 noOfDaysDisplayed, Int32 noOfTimeSlotsDisplayed, 
            Int32 selectedIndex, Int32 readOnlyIndex, Int32 selectedValue, Int32 readOnlyValue)
        {
            DataTable schedTable = new DataTable("SubjectScheduleTable");
            schedTable.Columns.Add("week_id", System.Type.GetType("System.Byte"));
            schedTable.Columns.Add("time_id", System.Type.GetType("System.Byte"));

            if (tFrames != null)
            {
                for (Int32 i = 0; i < noOfDaysDisplayed; i++)
                {
                    for (Int32 j = 0; j < noOfTimeSlotsDisplayed; j++)
                    {
                        if (tFrames[i][j][selectedIndex] == selectedValue &&
                            tFrames[i][j][readOnlyIndex] != readOnlyValue)
                        {
                            DataRow newRow = schedTable.NewRow();

                            newRow["week_id"] = i;
                            newRow["time_id"] = j;

                            schedTable.Rows.Add(newRow);
                            
                        }                        
                    }
                }
            }

            schedTable.AcceptChanges();

            return schedTable;
        }//----------------------------------------------------------

        //this function sets the subject schedule table
        private DataTable GenerateScheduleTable(String detailsSysId)
        {
            DataTable schedTable = new DataTable("SubjectScheduleTable");
            schedTable.Columns.Add("week_id", System.Type.GetType("System.Byte"));
            schedTable.Columns.Add("time_id", System.Type.GetType("System.Byte"));

            if (_subjectScheduleTable != null)
            {
                String strFilter = "sysid_scheddetails = '" + detailsSysId + "'";
                DataRow[] selectRow = _subjectScheduleTable.Select(strFilter, "week_id ASC");

                foreach (DataRow dRow in selectRow)
                {
                    DataRow newRow = schedTable.NewRow();

                    newRow["week_id"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "week_id", Byte.Parse("0"));
                    newRow["time_id"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "time_id", Byte.Parse("0"));

                    schedTable.Rows.Add(newRow);
                }
            }          

            schedTable.AcceptChanges();

            return schedTable;
        }//----------------------------------------------------------

        //this function determines if the schedule is new schedule
        private Boolean IsNewSchedule(String scheduleDetailsSysId, Int32 weekDayId, Int32 weekTimeId, DataTable scheduleTable)
        {
            Boolean isNew = true;

            if (scheduleTable != null)
            {
                String strFilter = "sysid_scheddetails = '" + scheduleDetailsSysId + "'";
                DataRow[] selectRow = scheduleTable.Select(strFilter);

                foreach (DataRow schedRow in selectRow)
                {
                    if ((!RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "is_read_only", false) &&
                        RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "week_id", Byte.Parse("0")) == (Byte)weekDayId &&
                        RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "time_id", Byte.Parse("0")) == (Byte)weekTimeId) &&
                        RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "schedule_id", Int64.Parse("0")) > 0)
                    {
                        isNew = false;
                        break;
                    }
                }
            }

            return isNew;
        }//--------------------------

        //this function determines if the schedule is deleted
        private Boolean IsDeletedSchedule(String schedulDetailsSysId, Int32 weekDayId, Int32 weekTimeId, ref Int64 scheduleId, DataTable scheduleTable)
        {
            Boolean isDeleted = false;

            if (scheduleTable != null)
            {
                String strFilter = "sysid_scheddetails = '" + schedulDetailsSysId + "'";
                DataRow[] selectRow = scheduleTable.Select(strFilter);

                foreach (DataRow schedRow in selectRow)
                {
                    if (!RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "is_read_only", false) &&
                        RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "week_id", Byte.Parse("0")) == (Byte)weekDayId &&
                        RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "time_id", Byte.Parse("0")) == (Byte)weekTimeId)
                    {
                        scheduleId = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "schedule_id", Int64.Parse("0"));

                        isDeleted = true;
                        break;
                    }
                }
            }

            return isDeleted;
        }//-------------------------

        //this function determines if the time frame is selected
        private Boolean IsSelectedTimeFrame(Int32 weekDayId, Int32 weekTimeId)
        {
            Boolean isSelected = false;

            if (_dayTimeScheduleTable != null)
            {
                foreach (DataRow schedRow in _dayTimeScheduleTable.Rows)
                {
                    if (!RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "is_read_only", false) &&
                        RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "week_id", Byte.Parse("0")) == (Byte)weekDayId &&
                        RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "time_id", Byte.Parse("0")) == (Byte)weekTimeId)
                    {
                        isSelected = true;
                        break;
                    }
                }
            }

            return isSelected;
        }//--------------------

        //this function determines if the time frame is readonly
        private Boolean IsReadOnlyTimeFrame(Int32 weekDayId, Int32 weekTimeId)
        {
            Boolean isReadOnly = false;

            if (_dayTimeScheduleTable != null)
            {
                foreach (DataRow schedRow in _dayTimeScheduleTable.Rows)
                {
                    if (RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "is_read_only", false) &&
                        RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "week_id", Byte.Parse("0")) == (Byte)weekDayId &&
                        RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "time_id", Byte.Parse("0")) == (Byte)weekTimeId)
                    {
                        isReadOnly = true;
                        break;
                    }
                }
            }

            return isReadOnly;
        }//--------------------

        //this function will return schedule of Day Time String
        public String GetDayTimeString(DataTable scheduleTable, Int32 timeInterval)
        {
            DataTable weekDayTable = _classDataSet.Tables["WeekDayTable"];
            DataTable weekTimeTable = _classDataSet.Tables["WeekTimeTable"];

            StringBuilder schedDayTime = new StringBuilder();

            if (scheduleTable != null && weekDayTable != null && weekTimeTable != null)
            {

                List<WeekDayTime> timeList = new List<WeekDayTime>();

                //populate timeList values
                for (Int32 x = 0; x <= 6; x++)
                {
                    String strFilter = "week_id = '" + x.ToString() + "'";
                    DataRow[] selectRow = scheduleTable.Select(strFilter, "time_id ASC");

                    Int32 index = 0;
                    WeekDayTime dayTime = null;

                    while (this.HasOtherTime(selectRow, ref dayTime, ref index))
                    {
                        timeList.Add(dayTime);
                    }
                }//-------------------

                //compare timeList values
                for (Int32 x = 0; x < timeList.Count; x++)
                {
                    if (!timeList[x].IsAdded)
                    {
                        WeekDayTime baseTime = timeList[x];

                        schedDayTime.Append(weekDayTable.Rows[timeList[x].WeekId]["acronym"].ToString());

                        for (Int32 y = (x + 1); y < timeList.Count; y++)
                        {
                            if (baseTime.StartTime == timeList[y].StartTime && baseTime.EndTime == timeList[y].EndTime &&
                                !timeList[y].IsAdded)
                            {
                                schedDayTime.Append(weekDayTable.Rows[timeList[y].WeekId]["acronym"].ToString());

                                timeList[y].IsAdded = true;
                            }
                        }

                        String endTime = String.Empty;

                        DateTime dbEnd = DateTime.MinValue;

                        if (DateTime.TryParse(weekTimeTable.Rows[timeList[x].EndTime]["time_description"].ToString(), out dbEnd))
                        {
                            if (weekTimeTable.Rows[timeList[x].StartTime] == weekTimeTable.Rows[timeList[x].EndTime])
                            {
                                endTime = DateTime.Parse(dbEnd.AddMinutes((Double)timeInterval - 1).ToString()).ToString("HH:mm") + "; ";
                            }
                            else
                            {
                                endTime = DateTime.Parse(weekTimeTable.Rows[timeList[x].EndTime]["time_description"].ToString()).ToString("HH:mm") + "; ";
                            }
                        }

                        schedDayTime.Append(" " + weekTimeTable.Rows[timeList[x].StartTime]["time_description"].ToString()
                            + " - " + endTime);
                    }
                }//--------------------------
            }

            if (schedDayTime.ToString().Length > 0)
            {
                return schedDayTime.ToString().Substring(0, schedDayTime.ToString().Length - 2);
            }
            else
            {
                return c_tbaString;
            }
        }//---------------------------

        //this function will validate has other time
        private Boolean HasOtherTime(DataRow[] selectRow, ref WeekDayTime dayTime, ref Int32 index)
        {
            Boolean hasOtherTime = false;

            dayTime = new WeekDayTime();

            if (selectRow.Length == 0 || index >= selectRow.Length)
            {
                hasOtherTime = false;
            }
            else
            {
                Boolean flag = false;

                Byte timeId = RemoteServerLib.ProcStatic.DataRowConvert(selectRow[index], "time_id", Byte.Parse("0"));

                //AC
                if (index > 0 && ((timeId - 1) == RemoteServerLib.ProcStatic.DataRowConvert(selectRow[index - 1], "time_id", Byte.Parse("0"))))
                {
                    index -= 1;

                    timeId = RemoteServerLib.ProcStatic.DataRowConvert(selectRow[index], "time_id", Byte.Parse("0"));
                }
                //---------------

                for (Int32 x = index; x < selectRow.Length; x++)
                {
                    if (!flag)
                    {
                        flag = true;

                        dayTime.WeekId = RemoteServerLib.ProcStatic.DataRowConvert(selectRow[x], "week_id", Byte.Parse("0"));
                        dayTime.StartTime = RemoteServerLib.ProcStatic.DataRowConvert(selectRow[x], "time_id", Byte.Parse("0"));
                        dayTime.EndTime = RemoteServerLib.ProcStatic.DataRowConvert(selectRow[x], "time_id", Byte.Parse("0"));

                        hasOtherTime = true;
                        index = selectRow.Length + 1;
                    }
                    else
                    {
                        if ((timeId + 1) == RemoteServerLib.ProcStatic.DataRowConvert(selectRow[x], "time_id", Byte.Parse("0")))
                        {
                            dayTime.EndTime = RemoteServerLib.ProcStatic.DataRowConvert(selectRow[x], "time_id", Byte.Parse("0"));

                            hasOtherTime = true;

                            index = x + 1;
                        }
                        else
                        {
                            hasOtherTime = true;

                            index = x + 1;

                            break;
                        }

                        timeId++;
                    }
                }

                dayTime.IsAdded = false;
            }

            return hasOtherTime;
        }//------------------------------

        //this function gets the schedule details id list format
        private String GetScheduleDetailsSysIdList()
        {
            StringBuilder strValue = new StringBuilder();

            if (_scheduleDetailsTable != null)
            {
                foreach (DataRow schedRow in _scheduleDetailsTable.Rows)
                {
                    strValue.Append(RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_scheddetails", "") + ", ");
                }
            }

            if (strValue.Length >= 2)
            {
                return strValue.ToString().Substring(0, strValue.Length - 2);
            }
            else
            {
                return String.Empty;
            }
        }//-------------------------------

        #endregion

    }
}
