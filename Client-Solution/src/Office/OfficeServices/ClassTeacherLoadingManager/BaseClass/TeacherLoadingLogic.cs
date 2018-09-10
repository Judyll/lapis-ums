using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace OfficeServices
{
    internal class TeacherLoadingLogic : BaseServices.BaseServicesLogic
    {
        #region Class Nested Classes

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

        #region Class Data Member Declaration
        private const String c_tbaString = "TBA";
        private String _imagePath;

        private DataSet _classDataSet;

        private DataTable _employeeTable;
        private DataTable _scheduleDetailsTable;
        private DataTable _teacherLoadTable;
        private DataTable _teacherDeloadTable;
        private DataTable _dayTimeScheduleTable;
        private DataTable _studentEnrolledTable;
        private DataTable _specialClassTable;

        private Int64 _loadId = 0;
        #endregion

        #region Class Properties Declarations
        public DataTable SubjectServiceTableFormat
        {
            get
            {
                DataTable subjectServiceTable = new DataTable();
                subjectServiceTable.Columns.Add("checkbox_column", System.Type.GetType("System.Boolean"));
                subjectServiceTable.Columns.Add("sysid_schedule", System.Type.GetType("System.String"));
                subjectServiceTable.Columns.Add("subject_code_title", System.Type.GetType("System.String"));
                subjectServiceTable.Columns.Add("day_time", System.Type.GetType("System.String"));
                subjectServiceTable.Columns.Add("section", System.Type.GetType("System.String"));
                subjectServiceTable.Columns.Add("classroom_code_no_freeze", System.Type.GetType("System.String"));
                subjectServiceTable.Columns.Add("lecture_units", System.Type.GetType("System.Single"));
                subjectServiceTable.Columns.Add("lab_units", System.Type.GetType("System.Single"));
                subjectServiceTable.Columns.Add("no_hours", System.Type.GetType("System.String"));

                return subjectServiceTable;
            }
        }
        #endregion

        #region Class Constructor

        public TeacherLoadingLogic(CommonExchange.SysAccess userInfo)
        {
            this.InitializeClass(userInfo);

            _employeeTable = new DataTable("EmployeeTable");
            _employeeTable.Columns.Add("sysid_employee", System.Type.GetType("System.String"));
            _employeeTable.Columns.Add("name", System.Type.GetType("System.String"));
            _employeeTable.Columns.Add("emp_name", System.Type.GetType("System.String"));
            _employeeTable.Columns.Add("department_id", System.Type.GetType("System.String"));
            _employeeTable.Columns.Add("department_name", System.Type.GetType("System.String"));
            _employeeTable.Columns.Add("employee_id", System.Type.GetType("System.String"));
            _employeeTable.Columns.Add("type_no", System.Type.GetType("System.Byte"));
            _employeeTable.Columns.Add("status_description", System.Type.GetType("System.String"));
            _employeeTable.Columns.Add("type_description", System.Type.GetType("System.String"));

            _teacherLoadTable = new DataTable("TeacherLoadTable");
            _teacherLoadTable.Columns.Add("load_id", System.Type.GetType("System.Int64"));
            _teacherLoadTable.Columns.Add("sysid_scheddetails_auxdetails", System.Type.GetType("System.String"));
            _teacherLoadTable.Columns.Add("sysid_scheddetails", System.Type.GetType("System.String"));
            _teacherLoadTable.Columns.Add("subject_service_code_title", System.Type.GetType("System.String"));
            _teacherLoadTable.Columns.Add("sysid_auxdetails", System.Type.GetType("System.String"));
            _teacherLoadTable.Columns.Add("is_auxiliary", System.Type.GetType("System.Boolean"));
            _teacherLoadTable.Columns.Add("year_semester_id", System.Type.GetType("System.String"));
            _teacherLoadTable.Columns.Add("sysid_subject_auxservice", System.Type.GetType("System.String"));
            _teacherLoadTable.Columns.Add("day_time", System.Type.GetType("System.String"));
            _teacherLoadTable.Columns.Add("section", System.Type.GetType("System.String"));
            _teacherLoadTable.Columns.Add("descriptive_title", System.Type.GetType("System.String"));
            _teacherLoadTable.Columns.Add("classroom_code", System.Type.GetType("System.String"));
            _teacherLoadTable.Columns.Add("load_date", System.Type.GetType("System.String"));
            _teacherLoadTable.Columns.Add("deload_date", System.Type.GetType("System.String"));
            _teacherLoadTable.Columns.Add("lecture_units", System.Type.GetType("System.Single"));
            _teacherLoadTable.Columns.Add("lab_units", System.Type.GetType("System.Single"));
            _teacherLoadTable.Columns.Add("no_hours", System.Type.GetType("System.String"));
            _teacherLoadTable.Columns.Add("is_recorded", System.Type.GetType("System.Boolean"));
            _teacherLoadTable.Columns.Add("sysid_employee", System.Type.GetType("System.String"));
            _teacherLoadTable.Columns.Add("is_classroom", System.Type.GetType("System.Boolean"));
            _teacherLoadTable.Columns.Add("field_room", System.Type.GetType("System.String"));
            _teacherLoadTable.Columns.Add("subject_auxiliary_department_name", System.Type.GetType("System.String"));
            _teacherLoadTable.Columns.Add("is_irregular_modular", System.Type.GetType("System.Boolean"));
            _teacherLoadTable.Columns.Add("is_team_teaching", System.Type.GetType("System.Boolean"));
            _teacherLoadTable.Columns.Add("is_fixed_amount", System.Type.GetType("System.Boolean"));
            _teacherLoadTable.Columns.Add("manual_schedule", System.Type.GetType("System.String"));
            _teacherLoadTable.Columns.Add("is_semestral", System.Type.GetType("System.Boolean"));

            _teacherDeloadTable = new DataTable("TeacherDeloadTable");
            _teacherDeloadTable.Columns.Add("load_id", System.Type.GetType("System.Int64"));
            _teacherDeloadTable.Columns.Add("sysid_scheddetails_auxdetails", System.Type.GetType("System.String"));
            _teacherDeloadTable.Columns.Add("sysid_scheddetails", System.Type.GetType("System.String"));
            _teacherDeloadTable.Columns.Add("subject_service_code_title", System.Type.GetType("System.String"));
            _teacherDeloadTable.Columns.Add("sysid_auxdetails", System.Type.GetType("System.String"));
            _teacherDeloadTable.Columns.Add("is_auxiliary", System.Type.GetType("System.Boolean"));
            _teacherDeloadTable.Columns.Add("year_semester_id", System.Type.GetType("System.String"));
            _teacherDeloadTable.Columns.Add("day_time", System.Type.GetType("System.String"));
            _teacherDeloadTable.Columns.Add("section", System.Type.GetType("System.String"));
            _teacherDeloadTable.Columns.Add("descriptive_title", System.Type.GetType("System.String"));
            _teacherDeloadTable.Columns.Add("classroom_code", System.Type.GetType("System.String"));
            _teacherDeloadTable.Columns.Add("load_date", System.Type.GetType("System.String"));
            _teacherDeloadTable.Columns.Add("deload_date", System.Type.GetType("System.String"));
            _teacherDeloadTable.Columns.Add("lecture_units", System.Type.GetType("System.Single"));
            _teacherDeloadTable.Columns.Add("lab_units", System.Type.GetType("System.Single"));
            _teacherDeloadTable.Columns.Add("no_hours", System.Type.GetType("System.String"));
            _teacherDeloadTable.Columns.Add("is_recorded", System.Type.GetType("System.Boolean"));
            _teacherDeloadTable.Columns.Add("sysid_employee", System.Type.GetType("System.String"));
            _teacherDeloadTable.Columns.Add("is_classroom", System.Type.GetType("System.Boolean"));
            _teacherDeloadTable.Columns.Add("field_room", System.Type.GetType("System.String"));
            _teacherDeloadTable.Columns.Add("subject_auxiliary_department_name", System.Type.GetType("System.String"));
            _teacherDeloadTable.Columns.Add("is_irregular_modular", System.Type.GetType("System.Boolean"));
            _teacherDeloadTable.Columns.Add("is_team_teaching", System.Type.GetType("System.Boolean"));
            _teacherDeloadTable.Columns.Add("is_fixed_amount", System.Type.GetType("System.Boolean"));
            _teacherDeloadTable.Columns.Add("manual_schedule", System.Type.GetType("System.String"));
            _teacherDeloadTable.Columns.Add("is_semestral", System.Type.GetType("System.Boolean"));

            _imagePath = "\\StudentImages";            
        }
        #endregion

        #region Programer-Defined Void Procedures
        //this procedure initializes the class
        private void InitializeClass(CommonExchange.SysAccess userInfo)
        {
            //gets the server date and time
            using (RemoteClient.RemCntBaseManager remClient = new RemoteClient.RemCntBaseManager())
            {
                _serverDateTime = remClient.GetServerDateTime(userInfo);
            } //----------------------

            //gets the dataset for the DataSet For Teacher Loading
            using (RemoteClient.RemCntTeacherLoadingManager remClient = new RemoteClient.RemCntTeacherLoadingManager())
            {
                _classDataSet = remClient.GetDataSetForTeacherLoad(userInfo, _serverDateTime);
            } //-----------------------
        } //----------------------- 

        //this procedure will Print Teacher Load
        public void PrintTeacherLoad(CommonExchange.SysAccess userInfo, String schoolYearSemester, String yearId,
            String semesterSysId, String strCriteria, Boolean printAll)
        {
            String strFilterLoad = "";

            //TABLES FOR PRINGTING
            DataTable employeeInformation = new DataTable("EmployeeInformationTable");
            employeeInformation.Columns.Add("sysid_employee", System.Type.GetType("System.String"));
            employeeInformation.Columns.Add("employee_name", System.Type.GetType("System.String"));
            employeeInformation.Columns.Add("department_name", System.Type.GetType("System.String"));
            employeeInformation.Columns.Add("employee_id", System.Type.GetType("System.String"));
            employeeInformation.Columns.Add("status_type_description", System.Type.GetType("System.String"));
            employeeInformation.Columns.Add("type_description", System.Type.GetType("System.String"));
            employeeInformation.Columns.Add("no_of_preparation", System.Type.GetType("System.String"));
            employeeInformation.Columns.Add("no_load", System.Type.GetType("System.String"));

            DataTable teacherLoadSubject = new DataTable("TeacherLoadSubjectTable");
            teacherLoadSubject.Columns.Add("load_id", System.Type.GetType("System.String"));
            teacherLoadSubject.Columns.Add("sysid_scheddetails", System.Type.GetType("System.String"));
            teacherLoadSubject.Columns.Add("subject_service_code_title", System.Type.GetType("System.String"));
            teacherLoadSubject.Columns.Add("day_time", System.Type.GetType("System.String"));
            teacherLoadSubject.Columns.Add("section", System.Type.GetType("System.String"));
            teacherLoadSubject.Columns.Add("classroom_code", System.Type.GetType("System.String"));
            teacherLoadSubject.Columns.Add("lecture_units", System.Type.GetType("System.Single"));
            teacherLoadSubject.Columns.Add("lab_units", System.Type.GetType("System.Single"));
            teacherLoadSubject.Columns.Add("no_hours", System.Type.GetType("System.String"));
            teacherLoadSubject.Columns.Add("sysid_employee", System.Type.GetType("System.String"));

            DataTable teacherLoadAuxiliary = new DataTable("TeacherLoadAuxiliaryTable");
            teacherLoadAuxiliary.Columns.Add("load_id", System.Type.GetType("System.String"));
            teacherLoadAuxiliary.Columns.Add("subject_service_code_title", System.Type.GetType("System.String"));
            teacherLoadAuxiliary.Columns.Add("sysid_auxdetails", System.Type.GetType("System.String"));
            teacherLoadAuxiliary.Columns.Add("lecture_units", System.Type.GetType("System.Single"));
            teacherLoadAuxiliary.Columns.Add("lab_units", System.Type.GetType("System.Single"));
            teacherLoadAuxiliary.Columns.Add("no_hours", System.Type.GetType("System.String"));
            teacherLoadAuxiliary.Columns.Add("sysid_employee", System.Type.GetType("System.String"));

            DataTable teacherLoadSubjectAuxiliary = new DataTable("TeacherLoadSubjectAuxiliaryTable");
            teacherLoadSubjectAuxiliary.Columns.Add("load_id", System.Type.GetType("System.String"));
            teacherLoadSubjectAuxiliary.Columns.Add("lecture_units", System.Type.GetType("System.Single"));
            teacherLoadSubjectAuxiliary.Columns.Add("lab_units", System.Type.GetType("System.Single"));
            teacherLoadSubjectAuxiliary.Columns.Add("no_hours", System.Type.GetType("System.Int32"));
            teacherLoadSubjectAuxiliary.Columns.Add("sysid_employee", System.Type.GetType("System.String"));
            //----------------------------

            if (printAll)
            {
                String strFilter = "name LIKE '%" + strCriteria + "%'";
                DataRow[] selectEmployeeRow = _employeeTable.Select(strFilter, "name ASC");

                foreach (DataRow empRow in selectEmployeeRow)
                {
                    if (this.HasEmployeeLoad(RemoteServerLib.ProcStatic.DataRowConvert(empRow, "sysid_employee", ""), yearId, semesterSysId))
                    {
                        DataRow newRow = employeeInformation.NewRow();

                        newRow["sysid_employee"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "sysid_employee", "");
                        newRow["employee_name"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "emp_name", "");
                        newRow["department_name"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "department_name", "");
                        newRow["employee_id"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "employee_id", "");
                        newRow["status_type_description"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "status_description", "") + ", " +
                            RemoteServerLib.ProcStatic.DataRowConvert(empRow, "type_description", "");
                        newRow["type_description"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "type_description", "");
                        newRow["no_of_preparation"] = this.GetNumberOfPreperation(RemoteServerLib.ProcStatic.DataRowConvert(empRow, "sysid_employee", ""), yearId, semesterSysId);
                        newRow["no_load"] = this.GetNumberOfLoad(RemoteServerLib.ProcStatic.DataRowConvert(empRow, "sysid_employee", ""), yearId, semesterSysId);

                        employeeInformation.Rows.Add(newRow);
                    }
                }

                strFilterLoad = "year_semester_id = '" + yearId + "' OR year_semester_id = '" + semesterSysId + "'";
            }
            else
            {
                String strFilterEmployee = "sysid_employee = '" + this.GetEmployeeScheduleSysId(strCriteria) + "'";
                DataRow[] selectRowEmployee = _classDataSet.Tables["EmployeeInformationTable"].Select(strFilterEmployee);

                foreach (DataRow empRow in selectRowEmployee)
                {
                    if (this.HasEmployeeLoad(RemoteServerLib.ProcStatic.DataRowConvert(empRow, "sysid_employee", ""), yearId, semesterSysId))
                    {
                        DataRow newRow = employeeInformation.NewRow();

                        newRow["sysid_employee"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "sysid_employee", "");
                        newRow["employee_name"] = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(
                            RemoteServerLib.ProcStatic.DataRowConvert(empRow, "last_name", ""),
                            RemoteServerLib.ProcStatic.DataRowConvert(empRow, "first_name", ""),
                            RemoteServerLib.ProcStatic.DataRowConvert(empRow, "middle_name", ""));
                        newRow["department_name"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "department_name", "");
                        newRow["employee_id"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "employee_id", "");
                        newRow["status_type_description"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "status_description", "") + ", " +
                            RemoteServerLib.ProcStatic.DataRowConvert(empRow, "type_description", "");
                        newRow["type_description"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "type_description", "");
                        newRow["no_of_preparation"] = this.GetNumberOfPreperation(RemoteServerLib.ProcStatic.DataRowConvert(empRow, "sysid_employee", ""), yearId, semesterSysId);
                        newRow["no_load"] = this.GetNumberOfLoad(RemoteServerLib.ProcStatic.DataRowConvert(empRow, "sysid_employee", ""), yearId, semesterSysId);

                        employeeInformation.Rows.Add(newRow);
                    }
                }

                strFilterLoad = "sysid_employee = '" + this.GetEmployeeScheduleSysId(strCriteria) +
                    "' AND (year_semester_id = '" + yearId + "' OR year_semester_id = '" + semesterSysId + "')";
            }

            DataRow[] selectRow = _teacherLoadTable.Select(strFilterLoad, "subject_service_code_title ASC");

            foreach (DataRow empRow in selectRow)
            {
                if (RemoteServerLib.ProcStatic.DataRowConvert(empRow, "is_auxiliary", false))
                {
                    DataRow newRow = teacherLoadAuxiliary.NewRow();

                    newRow["load_id"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "load_id", "");
                    newRow["subject_service_code_title"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "subject_service_code_title", "");
                    newRow["sysid_auxdetails"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "sysid_auxdetails", "");
                    newRow["lecture_units"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "lecture_units", Single.Parse("0"));
                    newRow["lab_units"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "lab_units", Single.Parse("0"));
                    newRow["no_hours"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "no_hours", "");
                    newRow["sysid_employee"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "sysid_employee", "");

                    teacherLoadAuxiliary.Rows.Add(newRow);
                }
                else
                {
                    DataRow newRow = teacherLoadSubject.NewRow();

                    newRow["load_id"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "load_id", "");
                    newRow["sysid_scheddetails"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "sysid_scheddetails", "");
                    newRow["subject_service_code_title"] = !RemoteServerLib.ProcStatic.DataRowConvert(empRow, "is_irregular_modular", false) ?
                        RemoteServerLib.ProcStatic.DataRowConvert(empRow, "subject_service_code_title", "") :
                        "** " + RemoteServerLib.ProcStatic.DataRowConvert(empRow, "subject_service_code_title", "");
                    newRow["day_time"] = !RemoteServerLib.ProcStatic.DataRowConvert(empRow, "is_irregular_modular", false) ?
                        RemoteServerLib.ProcStatic.DataRowConvert(empRow, "day_time", "") :
                        RemoteServerLib.ProcStatic.DataRowConvert(empRow, "manual_schedule", String.Empty);
                    newRow["section"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "section", "");

                    if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(empRow, "classroom_code", "")))
                    {
                        newRow["classroom_code"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "classroom_code", "");
                    }
                    else
                    {
                        newRow["classroom_code"] = c_tbaString;
                    }

                    newRow["lecture_units"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "lecture_units", Single.Parse("0"));
                    newRow["lab_units"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "lab_units", Single.Parse("0"));
                    newRow["no_hours"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "no_hours", "");
                    newRow["sysid_employee"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "sysid_employee", "");

                    teacherLoadSubject.Rows.Add(newRow);
                }

                Int32 totalNoHours = 0;

                DateTime noHours = DateTime.MinValue;

                if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(empRow, "no_hours", ""), out noHours))
                {
                    totalNoHours = noHours.Minute + (noHours.Hour * 60);                   
                }
                else if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(empRow, "no_hours", "")))
                {
                    Int32 hours = 0, minutes = 0, count = 1;

                    String[] strSplit = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "no_hours", "").Split(':');

                    foreach (String value in strSplit)
                    {
                        if (!String.IsNullOrEmpty(value))
                        {
                            if (count == 1)
                            {
                                hours = Int32.Parse(value);
                            }
                            else
                            {
                                minutes = Int32.Parse(value);
                            }
                        }

                        count++;
                    }

                    totalNoHours = minutes + (hours * 60);
                }

                DataRow newRowLoadAux = teacherLoadSubjectAuxiliary.NewRow();

                newRowLoadAux["load_id"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "load_id", "");
                newRowLoadAux["lecture_units"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "lecture_units", Single.Parse("0"));
                newRowLoadAux["lab_units"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "lab_units", Single.Parse("0"));
                newRowLoadAux["no_hours"] = totalNoHours;
                newRowLoadAux["sysid_employee"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "sysid_employee", "");

                teacherLoadSubjectAuxiliary.Rows.Add(newRowLoadAux);
            }

            employeeInformation.AcceptChanges();
            teacherLoadAuxiliary.AcceptChanges();
            teacherLoadSubject.AcceptChanges();
            teacherLoadSubjectAuxiliary.AcceptChanges();

            using (ClassTeacherLoadingManager.CrystalReport.CrystalTeacherLoad rptTeacherLoad =
                new OfficeServices.ClassTeacherLoadingManager.CrystalReport.CrystalTeacherLoad())
            {
                rptTeacherLoad.Database.Tables["employee_information"].SetDataSource(employeeInformation);
                rptTeacherLoad.Database.Tables["teacher_load_subject"].SetDataSource(teacherLoadSubject);
                rptTeacherLoad.Database.Tables["teacher_load_auxiliary"].SetDataSource(teacherLoadAuxiliary);
                rptTeacherLoad.Database.Tables["teacher_load_subject_auxiliary"].SetDataSource(teacherLoadSubjectAuxiliary);

                rptTeacherLoad.SetParameterValue("@school_name", CommonExchange.SchoolInformation.SchoolName);
                rptTeacherLoad.SetParameterValue("@teacher_load_form_code", CommonExchange.SchoolInformation.TeacherLoadFormCode);
                rptTeacherLoad.SetParameterValue("@school_year_semester", schoolYearSemester);
                rptTeacherLoad.SetParameterValue("@print_info", "Date/Time Printed: " + DateTime.Parse(_serverDateTime).ToShortDateString() + " " +
                    DateTime.Parse(_serverDateTime).ToShortTimeString() + "         Printed by: " +
                    RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName, userInfo.PersonInfo.FirstName,
                    userInfo.PersonInfo.MiddleName));

                using (RemoteClient.CrystalReportViewer frmViewer = new RemoteClient.CrystalReportViewer(rptTeacherLoad))
                {
                    frmViewer.Text = "Teacher Load";
                    frmViewer.ShowDialog();
                }
            }
        }//---------------------------

        //this procedure will print list of student enrolled in a particular subject
        public void PrintStudentEnrolledList(CommonExchange.SysAccess userInfo, String sysIdScheduleDetails, String schoolYearSemesterDescription)
        {

            String sysIdSchedule = this.GetScheduleSystemId(sysIdScheduleDetails);

            CommonExchange.ScheduleInformation scheduleInfo = this.GetDetailsScheduleInformation(sysIdSchedule);

            DataTable classRoomTimeTable = this.GetBySysIdScheduleScheduleDetailsTable(sysIdScheduleDetails);

            using (RemoteClient.RemCntStudentLoadingManager remClient = new RemoteClient.RemCntStudentLoadingManager())
            {
                _studentEnrolledTable = remClient.SelectBySysIDScheduleListStudentLoad(userInfo, sysIdSchedule);
            }

            //-----------------------
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
            //--------------------------------------


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
        }//--------------------

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

        }//---------------------------    

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

        //this procedure will initialize subject / service load listview
        public void InitializeSubjectServiceLoadListView(ListView lstLoadedSchedule, ListView lstDeloadedSchedule, 
            TabPage tblLoadedSchedule, TabPage tblDeloadedSchedule,
            String sysIdEmployee, String yearId, String semesterSysId)
        {
            lstLoadedSchedule.Items.Clear();
            
            String strFilter = "sysid_employee = '" + sysIdEmployee + 
                "' AND (year_semester_id = '" + yearId + "' OR year_semester_id = '" + semesterSysId + "')";
            DataRow[] selectRow = _teacherLoadTable.Select(strFilter);
            
            foreach (DataRow loadRow in selectRow)
            {
                String dayTimeLoad = String.Empty;

                if (!RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "is_irregular_modular", false))
                {
                    dayTimeLoad = String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "day_time", "")) ?
                       c_tbaString : RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "day_time", "");
                }
                else
                {
                    dayTimeLoad = String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "manual_schedule", String.Empty)) ?
                        c_tbaString : RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "manual_schedule", String.Empty);
                }

                ListViewItem addItem = new ListViewItem(new String[] {RemoteServerLib.ProcStatic.DataRowConvert(loadRow,"sysid_scheddetails_auxdetails",""),
                        RemoteServerLib.ProcStatic.DataRowConvert(loadRow,"subject_service_code_title",""), dayTimeLoad, 
                        RemoteServerLib.ProcStatic.DataRowConvert(loadRow,"section",""), 
                        RemoteServerLib.ProcStatic.DataRowConvert(loadRow,"classroom_code",""),
                        RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "lecture_units", Single.Parse("0")).ToString(),
                        RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "lab_units", Single.Parse("0")).ToString(),
                        RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "no_hours", ""),
                        RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "subject_auxiliary_department_name", String.Empty)});

                Boolean isFixedAmount = RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "is_fixed_amount", false);
                Boolean isTeamTeaching = RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "is_team_teaching", false);
                Boolean isIrregularModular = RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "is_irregular_modular", false);

                if (!isFixedAmount && !isTeamTeaching && isIrregularModular)
                {
                    addItem.ForeColor = Color.Peru;
                }
                else if (!isFixedAmount && isTeamTeaching && !isIrregularModular)
                {
                    addItem.ForeColor = Color.Tomato;
                }
                else if (!isFixedAmount && isTeamTeaching && isIrregularModular)
                {
                    addItem.ForeColor = Color.DarkSlateBlue;
                }
                else if (isFixedAmount && !isTeamTeaching && !isIrregularModular)
                {
                    addItem.ForeColor = Color.RosyBrown;
                }
                else if (isFixedAmount && !isTeamTeaching && isIrregularModular)
                {
                    addItem.ForeColor = Color.Olive;
                }
                else if (isFixedAmount && isTeamTeaching && !isIrregularModular)
                {
                    addItem.ForeColor = Color.LimeGreen;
                }
                else if (isFixedAmount && isTeamTeaching && isIrregularModular)
                {
                    addItem.ForeColor = Color.Plum;
                }

                if (RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "load_id", Int64.Parse("0")) < 0)
                {
                    addItem.BackColor = Color.Pink;
                }
               
                lstLoadedSchedule.Items.Add(addItem);
            }

            tblLoadedSchedule.Text = lstLoadedSchedule.Items.Count == 0 ? "Loaded Schedule" : "** Loaded Schedule";

            lstDeloadedSchedule.Items.Clear();

            DataRow[] selectDeloaded = _teacherDeloadTable.Select(strFilter);

            foreach (DataRow deloadedRow in selectDeloaded)
            {
                String dayTimeDeLoad = String.Empty;

                if (!RemoteServerLib.ProcStatic.DataRowConvert(deloadedRow, "is_irregular_modular", false))
                {
                    dayTimeDeLoad = String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(deloadedRow, "day_time", "")) ?
                       c_tbaString : RemoteServerLib.ProcStatic.DataRowConvert(deloadedRow, "day_time", "");
                }
                else
                {
                    dayTimeDeLoad = String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(deloadedRow, "manual_schedule", String.Empty)) ?
                        c_tbaString : RemoteServerLib.ProcStatic.DataRowConvert(deloadedRow, "manual_schedule", String.Empty);
                }

                ListViewItem addItem = new ListViewItem(new String[] {RemoteServerLib.ProcStatic.DataRowConvert(deloadedRow,"sysid_scheddetails_auxdetails",""),
                        RemoteServerLib.ProcStatic.DataRowConvert(deloadedRow,"subject_service_code_title",""), dayTimeDeLoad, 
                        RemoteServerLib.ProcStatic.DataRowConvert(deloadedRow,"section",""), 
                        RemoteServerLib.ProcStatic.DataRowConvert(deloadedRow,"classroom_code",""),
                        RemoteServerLib.ProcStatic.DataRowConvert(deloadedRow, "lecture_units", Single.Parse("0")).ToString(),
                        RemoteServerLib.ProcStatic.DataRowConvert(deloadedRow, "lab_units", Single.Parse("0")).ToString(),
                        RemoteServerLib.ProcStatic.DataRowConvert(deloadedRow, "no_hours", ""),
                        RemoteServerLib.ProcStatic.DataRowConvert(deloadedRow, "subject_auxiliary_department_name", String.Empty),
                        DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(deloadedRow, "load_date", "")).ToShortDateString(),
                        DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(deloadedRow, "deload_date", "")).ToShortDateString()});               

                lstDeloadedSchedule.Items.Add(addItem);
            }

            tblDeloadedSchedule.Text = lstDeloadedSchedule.Items.Count == 0 ? "Deloaded Schedule" : "** Deloaded Schedule";
        }//------------------------

        //this procedure will initialize the speical class list view
        public void InitializeSpecialClassLoadedWithdrawnListView(ListView lsvBase, Label lblBase, TabPage tblBase, 
            String sysIdEmployee, Boolean isPrematureDeloaded)
        {
            lsvBase.Items.Clear();

            Int32 totalLab = 0, totalLec = 0, totalHours = 0, totalMin = 0, totalNonAcad = 0;

            DateTime noHoursLoaded = DateTime.MinValue;

            String strFilter = "sysid_employee = '" + sysIdEmployee + "' AND is_marked_deleted = " + isPrematureDeloaded;
            DataRow[] selectRow = _specialClassTable.Select(strFilter);

            if (_specialClassTable != null)
            {
                if (!isPrematureDeloaded)
                {
                    foreach (DataRow specialRow in selectRow)
                    {
                        ListViewItem lstItem = new ListViewItem(new String[] { RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "sysid_special", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_code", String.Empty) + " - " +
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "descriptive_title", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_lecture_units", Byte.Parse("0")).ToString(),
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_lab_units", Byte.Parse("0")).ToString(),
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_no_hours", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "amount", Decimal.Parse("0")).ToString("N"),
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_department_name", String.Empty)});

                        lsvBase.Items.Add(lstItem);

                        totalLab += RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_lab_units", Byte.Parse("0"));

                        if (RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "is_non_academic", false))
                        {
                            totalNonAcad += RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_lecture_units", Byte.Parse("0"));
                        }
                        else
                        {
                            totalLec += RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_lecture_units", Byte.Parse("0"));
                        }

                        if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_no_hours", ""), out noHoursLoaded))
                        {
                            totalHours += noHoursLoaded.Minute + (noHoursLoaded.Hour * 60);
                        }
                    }

                    totalMin = totalHours % 60;
                    totalHours /= 60;

                    lblBase.Text = "  " + this.GetSubjectUnitsHours(totalLec, totalNonAcad, totalLab,
                        RemoteServerLib.ProcStatic.TwoDigitZero(totalHours) + ":" + RemoteServerLib.ProcStatic.TwoDigitZero(totalMin));

                    tblBase.Text = lsvBase.Items.Count > 0 ? "** Special Class" : "Special Class";
                }
                else
                {
                    foreach (DataRow specialRow in selectRow)
                    {
                        ListViewItem lstItem = new ListViewItem(new String[] { RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "sysid_special", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_code", String.Empty) + " - " +
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "descriptive_title", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_lecture_units", Byte.Parse("0")).ToString(),
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_lab_units", Byte.Parse("0")).ToString(),
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_no_hours", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "amount", Decimal.Parse("0")).ToString("N"),
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_department_name", String.Empty),
                            RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "last_name", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "first_name", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "middle_name", String.Empty))});

                        lsvBase.Items.Add(lstItem);

                        totalLab += RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_lab_units", Byte.Parse("0"));

                        if (RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "is_non_academic", false))
                        {
                            totalNonAcad += RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_lecture_units", Byte.Parse("0"));
                        }
                        else
                        {
                            totalLec += RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_lecture_units", Byte.Parse("0"));
                        }

                        if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_no_hours", ""), out noHoursLoaded))
                        {
                            totalHours += noHoursLoaded.Minute + (noHoursLoaded.Hour * 60);
                        }
                    }

                    totalMin = totalHours % 60;
                    totalHours /= 60;

                    lblBase.Text = "  " + this.GetSubjectUnitsHours(totalLec, totalNonAcad, totalLab,
                        RemoteServerLib.ProcStatic.TwoDigitZero(totalHours) + ":" + RemoteServerLib.ProcStatic.TwoDigitZero(totalMin));

                    tblBase.Text = lsvBase.Items.Count > 0 ? "** Deloaded Special Class" : "Deloaded Special Class";
                }
            }
        }//-------------------------------

        //this procedure is used to get SUBJECT SCHEDULE DETAILS WITH AND WITHOUT TEACHER LOAD
        public void SelectByDateStartEndForTeacherLoadingTeacherLoad(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd)
        {
            _teacherDeloadTable.Clear();
            _teacherLoadTable.Clear();

            using (RemoteClient.RemCntTeacherLoadingManager remClient = new RemoteClient.RemCntTeacherLoadingManager())
            {
                _scheduleDetailsTable = remClient.SelectByDateStartEndForTeacherLoadingTeacherLoad(userInfo, dateStart, dateEnd, _serverDateTime);

                if (_scheduleDetailsTable != null)
                {
                    using (RemoteClient.RemCntSubjectSchedulingManager remSubject = new RemoteClient.RemCntSubjectSchedulingManager())
                    {
                        _dayTimeScheduleTable = remSubject.SelectBySysIDScheduleDetailsListSubjectSchedule(userInfo, this.GetScheduleDetailsSysIdList());
                    }

                    Int32 index = 0;

                    foreach (DataRow dRow in _scheduleDetailsTable.Rows)
                    {
                        String detailsSysId = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_scheddetails_auxdetails", "");

                        DataRow editRow = _scheduleDetailsTable.Rows[index];

                        editRow.BeginEdit();

                        editRow["day_time"] = this.GetDayTimeString(this.GenerateScheduleTable(detailsSysId),
                            _classDataSet.Tables["WeekDayTable"], _classDataSet.Tables["WeekTimeTable"]);

                        editRow.EndEdit();

                        if (!RemoteServerLib.ProcStatic.DataRowConvert(dRow, "is_premature_deloaded", false) &&
                            !String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_employee", "")))
                        {
                            DataRow newRow = _teacherLoadTable.NewRow();

                            newRow["load_id"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "load_id", Int64.Parse("0"));
                            newRow["sysid_scheddetails_auxdetails"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_scheddetails_auxdetails", "");
                            newRow["subject_service_code_title"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "subject_service_code", "") + " - " +
                                RemoteServerLib.ProcStatic.DataRowConvert(dRow, "descriptive_title", "");

                            if (RemoteServerLib.ProcStatic.DataRowConvert(dRow, "is_auxiliary", false))
                            {
                                newRow["sysid_scheddetails"] = DBNull.Value;
                                newRow["sysid_auxdetails"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_scheddetails_auxdetails", "");
                            }
                            else
                            {
                                newRow["sysid_scheddetails"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_scheddetails_auxdetails", "");
                                newRow["sysid_auxdetails"] = DBNull.Value;
                            }

                            newRow["is_auxiliary"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "is_auxiliary", false);
                            newRow["year_semester_id"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "year_semester_id", "");
                            newRow["sysid_subject_auxservice"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_subject_auxservice", String.Empty);
                            newRow["day_time"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "day_time", "");
                            newRow["section"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "section", "");
                            newRow["descriptive_title"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "descriptive_title", "");
                            newRow["classroom_code"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "classroom_code", "");
                            newRow["load_date"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "load_date", "");
                            newRow["deload_date"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "deload_date", "");
                            newRow["lecture_units"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "lecture_units", Single.Parse("0"));
                            newRow["lab_units"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "lab_units", Single.Parse("0"));
                            newRow["no_hours"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "no_hours", "00:00");
                            newRow["is_recorded"] = true;
                            newRow["sysid_employee"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_employee", "");
                            newRow["day_time"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "day_time", "");
                            newRow["is_classroom"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "is_classroom", false);
                            newRow["field_room"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "field_room", "");
                            newRow["subject_auxiliary_department_name"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "subject_auxiliary_department_name", "");
                            newRow["is_irregular_modular"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "is_irregular_modular", false);
                            newRow["is_team_teaching"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "is_team_teaching", String.Empty);
                            newRow["is_fixed_amount"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "is_fixed_amount", String.Empty);
                            newRow["manual_schedule"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "manual_schedule", String.Empty);
                            newRow["is_semestral"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "is_semestral", false);

                            _teacherLoadTable.Rows.Add(newRow);
                        }
                        else if (RemoteServerLib.ProcStatic.DataRowConvert(dRow, "is_premature_deloaded", false) &&
                            !String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_employee", "")))
                        {
                            DataRow newRow = _teacherDeloadTable.NewRow();

                            newRow["load_id"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "load_id", Int64.Parse("0"));
                            newRow["sysid_scheddetails_auxdetails"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_scheddetails_auxdetails", "");
                            newRow["subject_service_code_title"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "subject_service_code", "") + " - " +
                                RemoteServerLib.ProcStatic.DataRowConvert(dRow, "descriptive_title", "");

                            if (RemoteServerLib.ProcStatic.DataRowConvert(dRow, "is_auxiliary", false))
                            {
                                newRow["sysid_scheddetails"] = DBNull.Value;
                                newRow["sysid_auxdetails"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_scheddetails_auxdetails", "");
                            }
                            else
                            {
                                newRow["sysid_scheddetails"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_scheddetails_auxdetails", "");
                                newRow["sysid_auxdetails"] = DBNull.Value;
                            }

                            newRow["is_auxiliary"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "is_auxiliary", false);
                            newRow["year_semester_id"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "year_semester_id", "");
                            newRow["day_time"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "day_time", "");
                            newRow["section"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "section", "");
                            newRow["descriptive_title"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "descriptive_title", "");
                            newRow["classroom_code"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "classroom_code", "");
                            newRow["load_date"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "load_date", "");
                            newRow["deload_date"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "deload_date", "");
                            newRow["lecture_units"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "lecture_units", Single.Parse("0"));
                            newRow["lab_units"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "lab_units", Single.Parse("0"));
                            newRow["no_hours"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "no_hours", "00:00");
                            newRow["is_recorded"] = true;
                            newRow["sysid_employee"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_employee", "");
                            newRow["subject_auxiliary_department_name"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "subject_auxiliary_department_name", "");
                            newRow["is_irregular_modular"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "is_irregular_modular", false);
                            newRow["is_team_teaching"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "is_team_teaching", String.Empty);
                            newRow["is_fixed_amount"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "is_fixed_amount", String.Empty);
                            newRow["manual_schedule"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "manual_schedule", String.Empty);
                            newRow["is_semestral"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "is_semestral", false);

                            _teacherDeloadTable.Rows.Add(newRow);
                        }

                        index++;
                    }

                    _teacherLoadTable.AcceptChanges();
                    _teacherDeloadTable.AcceptChanges();
                    _scheduleDetailsTable.AcceptChanges();
                }
            }
            
        }//-------------------------------------

        //this procedure will get special call for all instructors
        public void SelectBySysIDEmployeeListDateStartEndSpecialClassInformation(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd)
        {
            using (RemoteClient.RemCntSpecialClassManager remClient = new RemoteClient.RemCntSpecialClassManager())
            {
                _specialClassTable = remClient.SelectBySysIDEmployeeListDateStartEndSpecialClassInformation(userInfo,
                    this.GetEmployeeSysIdList(), dateStart, dateEnd);
            }
        }//-----------------------------------

        //this procedure will get searched employee
        public void GetSearchedEmployee(TreeView trvEmployee, String strCriteria, String yearId, String semesterSysId)
        {
            trvEmployee.Nodes.Clear();
            _employeeTable.Clear();

            if (_classDataSet.Tables["EmployeeInformationTable"] != null)
            {
                foreach (DataRow empRow in _classDataSet.Tables["EmployeeInformationTable"].Rows)
                {
                    if (RemoteServerLib.ProcStatic.DataRowConvert(empRow, "status_id", Byte.Parse("0")) != (Byte)CommonExchange.EmploymentStatusNo.LayOff)
                    {
                        DataRow newRow = _employeeTable.NewRow();

                        newRow["sysid_employee"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "sysid_employee", "");
                        newRow["name"] = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(RemoteServerLib.ProcStatic.DataRowConvert(empRow,
                            "last_name", ""), RemoteServerLib.ProcStatic.DataRowConvert(empRow, "first_name", ""),
                            RemoteServerLib.ProcStatic.DataRowConvert(empRow, "middle_name", "")) + " [" +
                            RemoteServerLib.ProcStatic.DataRowConvert(empRow, "sysid_employee", "") + "]";
                        newRow["emp_name"] = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(RemoteServerLib.ProcStatic.DataRowConvert(empRow,
                            "last_name", ""), RemoteServerLib.ProcStatic.DataRowConvert(empRow, "first_name", ""),
                            RemoteServerLib.ProcStatic.DataRowConvert(empRow, "middle_name", ""));
                        newRow["department_id"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "department_id", "");
                        newRow["type_no"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "type_no", "");
                        newRow["department_name"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "department_name", "");
                        newRow["employee_id"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "employee_id", "");
                        newRow["status_description"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "status_description", "");
                        newRow["type_description"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "type_description", "");

                        _employeeTable.Rows.Add(newRow);
                    }
                }

                _employeeTable.AcceptChanges();

                strCriteria = strCriteria.Replace("*", "").Replace("%", "").Replace("'", "''");

                String strFilter = "name LIKE '%" + strCriteria + "%'";
                DataRow[] selectRow = _employeeTable.Select(strFilter, "name ASC");

                foreach (DataRow empRow in selectRow)
                {
                    TreeNode employeeNode = new TreeNode(RemoteServerLib.ProcStatic.DataRowConvert(empRow, "name", ""));

                    if (RemoteServerLib.ProcStatic.DataRowConvert(empRow, "type_no", Byte.Parse("0")) == (Byte)CommonExchange.EmploymentTypeNo.GraduateSchoolCollegeFaculty ||
                        RemoteServerLib.ProcStatic.DataRowConvert(empRow, "type_no", Byte.Parse("0")) == (Byte)CommonExchange.EmploymentTypeNo.GraduateSchoolFaculty ||
                        RemoteServerLib.ProcStatic.DataRowConvert(empRow, "type_no", Byte.Parse("0")) == (Byte)CommonExchange.EmploymentTypeNo.GraduateSchoolHighSchoolFaculty ||
                        RemoteServerLib.ProcStatic.DataRowConvert(empRow, "type_no", Byte.Parse("0")) == (Byte)CommonExchange.EmploymentTypeNo.GraduateSchoolGradeKinderFaculty)
                    {
                        employeeNode.ImageIndex = 2;
                    }
                    else if (RemoteServerLib.ProcStatic.DataRowConvert(empRow, "type_no", Byte.Parse("0")) == (Byte)CommonExchange.EmploymentTypeNo.CollegeFaculty)
                    {
                        employeeNode.ImageIndex = 3;
                    }
                    else if (RemoteServerLib.ProcStatic.DataRowConvert(empRow, "type_no", Byte.Parse("0")) == (Byte)CommonExchange.EmploymentTypeNo.HighSchoolFaculty)
                    {
                        employeeNode.ImageIndex = 4;
                    }
                    else if (RemoteServerLib.ProcStatic.DataRowConvert(empRow, "type_no", Byte.Parse("0")) == (Byte)CommonExchange.EmploymentTypeNo.GradeKinderFaculty)
                    {
                        employeeNode.ImageIndex = 5;
                    }
                    else if (RemoteServerLib.ProcStatic.DataRowConvert(empRow, "type_no", Byte.Parse("0")) == (Byte)CommonExchange.EmploymentTypeNo.NonTeachingStaff)
                    {
                        employeeNode.ImageIndex = 6;
                    }
                    else if (RemoteServerLib.ProcStatic.DataRowConvert(empRow, "type_no", Byte.Parse("0")) == (Byte)CommonExchange.EmploymentTypeNo.AcademicNonTeaching)
                    {
                        employeeNode.ImageIndex = 7;
                    }
                    else if (RemoteServerLib.ProcStatic.DataRowConvert(empRow, "type_no", Byte.Parse("0")) == (Byte)CommonExchange.EmploymentTypeNo.Maintenance)
                    {
                        employeeNode.ImageIndex = 8;
                    }

                    trvEmployee.Nodes.Add(employeeNode);
                }
            }
        }//--------------------------       

        //this procedure will Set Message Board Group Box
        public void SetInstructorInformationControls(String sysIdEmployee, Label lblUnitsLabHoursLoaded, Label lblUnitsLabHoursDeloaded, String yearId, String semesterSysId)
        {
            Single lecUnitsLoaded = 0;
            Single labUnitsLoaded = 0;
            Single lecUnitsDeloaded = 0;
            Single labUnitsDeloaded = 0;

            Int32 totalHoursLoaded = 0;
            Int32 totalHoursDeloaded = 0;
            Int32 totalMinLoaded = 0;
            Int32 totalMinDeloaded = 0;
            Int32 totalMinLoadLoaded = 0;
            Int32 totalMinLoadDeloaded = 0;


            DateTime noHoursLoaded = DateTime.MinValue;
            DateTime noHoursDeloaded = DateTime.MinValue;

            String strFilterLoadRow = "sysid_employee = '" + sysIdEmployee + 
                "' AND (year_semester_id = '" + yearId + "' OR year_semester_id = '" + semesterSysId + "')";
            DataRow[] selectLoadRow = _teacherLoadTable.Select(strFilterLoadRow);

            foreach (DataRow schedRow in selectLoadRow)
            {
                lecUnitsLoaded += RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "lecture_units", Single.Parse("0"));
                labUnitsLoaded += RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "lab_units", Single.Parse("0"));

                if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "no_hours", ""), out noHoursLoaded))
                {
                    totalHoursLoaded += noHoursLoaded.Minute + (noHoursLoaded.Hour * 60);

                    if (RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "is_semestral", false) &&
                        (RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "lecture_units", Single.Parse("0")) == 0 &&
                        RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "lab_units", Single.Parse("0")) ==0 ))
                    {
                        totalMinLoadLoaded += noHoursLoaded.Minute + (noHoursLoaded.Hour * 60);
                    }
                }
                else if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "no_hours", "")))
                {
                    Int32 hours = 0, minutes = 0, count = 1;

                    String[] strSplit = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "no_hours", "").Split(':');

                    foreach (String value in strSplit)
                    {
                        if (!String.IsNullOrEmpty(value))
                        {
                            if (count == 1)
                            {
                                hours = Int32.Parse(value);
                            }
                            else
                            {
                                minutes = Int32.Parse(value);
                            }
                        }

                        count++;
                    }

                    totalHoursLoaded += minutes + (hours * 60);

                    totalMinLoadLoaded += minutes + (hours * 60);
                }
            }

            String strFilterDeloadRow = "sysid_employee = '" + sysIdEmployee + "'";
            DataRow[] selectDeloadRow = _teacherDeloadTable.Select(strFilterDeloadRow);

            foreach (DataRow schedRow in selectDeloadRow)
            {
                lecUnitsDeloaded += RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "lecture_units", Single.Parse("0"));
                labUnitsDeloaded += RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "lab_units", Single.Parse("0"));

                if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "no_hours", ""), out noHoursDeloaded))
                {
                    totalHoursDeloaded += noHoursDeloaded.Minute + (noHoursDeloaded.Hour * 60);

                    if (RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "is_semestral", false) &&
                        (RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "lecture_units", Single.Parse("0")) == 0 &&
                        RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "lab_units", Single.Parse("0")) == 0))
                    {
                        totalMinLoadDeloaded += noHoursDeloaded.Minute + (noHoursDeloaded.Hour * 60);
                    }
                }
                else if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "no_hours", "")))
                {
                    Int32 hours = 0, minutes = 0, count = 1;

                    String[] strSplit = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "no_hours", "").Split(':');

                    foreach (String value in strSplit)
                    {
                        if (!String.IsNullOrEmpty(value))
                        {
                            if (count == 1)
                            {
                                hours = Int32.Parse(value);
                            }
                            else
                            {
                                minutes = Int32.Parse(value);
                            }
                        }

                        count++;
                    }

                    totalHoursDeloaded += minutes + (hours * 60);

                    totalMinLoadDeloaded += minutes + (hours * 60);
                }
            }            

            totalMinLoaded = totalHoursLoaded % 60;
            totalHoursLoaded /= 60;

            //total minutes is divided by 60 so that we could get the number of hours then it is divided by 3 so that we could come up with number of loads.
            Double noLoadLoaded = ((totalMinLoadLoaded / 60.0) / 3.0);

            totalMinDeloaded = totalHoursDeloaded % 60;
            totalHoursDeloaded /= 60;

            //total minutes is divided by 60 so that we could get the number of hours then it is divided by 3 so that we could come up with number of loads.
            Double noLoadDeloaded = ((totalMinLoadDeloaded / 60.0) / 3.0);

            lblUnitsLabHoursLoaded.Text = this.GetSubjectUnitsHours(lecUnitsLoaded, labUnitsLoaded,
                RemoteServerLib.ProcStatic.TwoDigitZero(totalHoursLoaded) + ":" + RemoteServerLib.ProcStatic.TwoDigitZero(totalMinLoaded)) + "     No. Load: " +
                (Math.Floor(noLoadLoaded * 100) / 100).ToString("N");
            lblUnitsLabHoursDeloaded.Text = this.GetSubjectUnitsHours(lecUnitsDeloaded, labUnitsDeloaded,
                RemoteServerLib.ProcStatic.TwoDigitZero(totalHoursDeloaded) + ":" + RemoteServerLib.ProcStatic.TwoDigitZero(totalMinDeloaded)) + "     No. Load: " +
                (Math.Floor(noLoadDeloaded * 100) / 100).ToString("N");
        }//----------------------------

        //this procedure will Insert or Delete Teacher Load
        public void InsertDeleteTeacherLoad(CommonExchange.SysAccess userInfo)
        {
            if (_teacherLoadTable != null)
            {
                using (RemoteClient.RemCntTeacherLoadingManager remClient = new RemoteClient.RemCntTeacherLoadingManager())
                {
                    remClient.InsertDeleteTeacherLoad(userInfo, _teacherLoadTable);
                }
            }
        }//----------------------------

        //this procedure will insert teacher load
        public void InsertTeacherLoadCached(String sysIdEmployee, String sysIdSchedDetailsAuxDetails)
        {
            if (_teacherLoadTable != null)
            {
                String strFilter = "sysid_scheddetails_auxdetails = '" + sysIdSchedDetailsAuxDetails + "'";
                DataRow[] selectRow = _scheduleDetailsTable.Select(strFilter);

                foreach (DataRow empRow in selectRow)
                {
                    DataRow newRow = _teacherLoadTable.NewRow();

                    newRow["load_id"] = --_loadId;

                    if (RemoteServerLib.ProcStatic.DataRowConvert(empRow, "is_auxiliary", false))
                    {
                        newRow["sysid_scheddetails"] = DBNull.Value;
                        newRow["sysid_auxdetails"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "sysid_scheddetails_auxdetails", "");
                    }
                    else
                    {
                        newRow["sysid_scheddetails"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "sysid_scheddetails_auxdetails", "");
                        newRow["sysid_auxdetails"] = DBNull.Value;
                    }

                    newRow["sysid_subject_auxservice"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "sysid_subject_auxservice", String.Empty);
                    newRow["sysid_scheddetails_auxdetails"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "sysid_scheddetails_auxdetails", "");
                    newRow["subject_service_code_title"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "subject_service_code", "") + " - " +
                        RemoteServerLib.ProcStatic.DataRowConvert(empRow, "descriptive_title", "");
                    newRow["day_time"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "day_time", "");
                    newRow["section"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "section", "");
                    newRow["descriptive_title"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "descriptive_title", "");
                    newRow["classroom_code"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "classroom_code", "");
                    newRow["year_semester_id"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "year_semester_id", "");
                    newRow["is_auxiliary"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "is_auxiliary", false);
                    newRow["lecture_units"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "lecture_units", Single.Parse("0"));
                    newRow["lab_units"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "lab_units", Single.Parse("0"));
                    newRow["no_hours"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "no_hours", "00:00");
                    newRow["is_irregular_modular"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "is_irregular_modular", false);
                    newRow["is_team_teaching"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "is_team_teaching", String.Empty);
                    newRow["is_fixed_amount"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "is_fixed_amount", String.Empty);
                    newRow["manual_schedule"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "manual_schedule", String.Empty);
                    newRow["is_semestral"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "is_semestral", false);
                    newRow["is_recorded"] = false;
                    newRow["sysid_employee"] = sysIdEmployee;

                    _teacherLoadTable.Rows.Add(newRow);
                }

                Int32 indexSysId = 0;

                foreach (DataRow schedRow in _scheduleDetailsTable.Rows)
                {
                    if (String.Equals(sysIdSchedDetailsAuxDetails,
                        RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_scheddetails_auxdetails", "")))
                    {
                        DataRow editRow = _scheduleDetailsTable.Rows[indexSysId];

                        if (editRow.RowState == DataRowState.Modified)
                        {
                            editRow.AcceptChanges();
                        }

                        editRow.BeginEdit();

                        editRow["sysid_employee"] = sysIdEmployee;

                        editRow.EndEdit();
                    }

                    indexSysId++;
                }
            }
        }//------------------------

        //this procedure will delete teacher load
        public void DeleteTeacherLoad(String sysIdSchedDetails)
        {
            if (!String.IsNullOrEmpty(sysIdSchedDetails))
            {
                Int32 index = 0;

                foreach (DataRow schedRow in _scheduleDetailsTable.Rows)
                {
                    if (String.Equals(sysIdSchedDetails, RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_scheddetails_auxdetails", "")))
                    {
                        DataRow editRow = _scheduleDetailsTable.Rows[index];

                        if (editRow.RowState == DataRowState.Modified || editRow.RowState == DataRowState.Added)
                        {
                            editRow.AcceptChanges();
                        }

                        editRow.BeginEdit();

                        editRow["sysid_employee"] = DBNull.Value;

                        editRow.EndEdit();

                        break;
                    }

                    index++;
                }

                index = 0;

                foreach (DataRow teacherRow in _teacherLoadTable.Rows)
                {
                    if (teacherRow.RowState != DataRowState.Deleted && (String.Equals(sysIdSchedDetails,
                        RemoteServerLib.ProcStatic.DataRowConvert(teacherRow, "sysid_scheddetails_auxdetails", ""))))
                    {
                        DataRow delRow = _teacherLoadTable.Rows[index];

                        if (delRow.RowState == DataRowState.Modified || delRow.RowState == DataRowState.Added)
                        {
                            delRow.AcceptChanges();
                        }

                        delRow.Delete();

                        break;
                    }

                    index++;
                }
            }
        }//-------------------------

        //this procedure will initialize person image table
        public void InitializePersonImageTable(CommonExchange.SysAccess userInfo, String startUp)
        {
            CommonExchange.Person personInfo = new CommonExchange.Person();

            base.InitializePersonImages(userInfo, this.GetPersonSysIdListByEmployeeTable(), this.GetPersonInfoListByEmployeeTable(), startUp);
        }//-------------------------

        //this procedure deletes the image directory
        public void DeleteImageDirectory(String startUp)
        {
            String imagePath = startUp + _imagePath;

            RemoteClient.ProcStatic.DeleteDirectory(imagePath);
        }//--------------------------------
        #endregion

        #region Programer-Defined Functions  
        //this fucntion returns schedule information system id
        private String GetScheduleSystemId(String sysIdSchedDetails)
        {
            String value = String.Empty;

            if (_scheduleDetailsTable != null)
            {
                String strFilter = "sysid_scheddetails_auxdetails = '" + sysIdSchedDetails + "'";
                DataRow[] selectRow = _scheduleDetailsTable.Select(strFilter);

                foreach (DataRow schedRow in selectRow)
                {
                    value = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_schedule_auxserviceschedule", "");

                    break;
                }
            }

            return value;
        }//------------------------

        //this function gets the schedule details id list format
        private String GetScheduleDetailsSysIdList()
        {
            StringBuilder strValue = new StringBuilder();

            if (_scheduleDetailsTable != null)
            {
                foreach (DataRow schedRow in _scheduleDetailsTable.Rows)
                {
                    strValue.Append(RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_scheddetails_auxdetails", "") + ", ");
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

        //this fucntion well get sysidscheduledetails list
        private String GetScheduleDetailsSysIdList(DataTable scheduleDetailsTable)
        {
            String sysIdSchedDetailsList = String.Empty;

            foreach (DataRow schedRow in scheduleDetailsTable.Rows)
            {
                if (RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "checkbox_column", false))
                {
                    sysIdSchedDetailsList += RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_schedule", String.Empty) + ", ";
                }
            }

            if (sysIdSchedDetailsList.Length >= 2)
            {
                return sysIdSchedDetailsList.Substring(0, sysIdSchedDetailsList.Length - 2);
            }
            else
            {
                return String.Empty;
            }
        }//---------------------------

        //this function will return schedule of Day Time String
        private String GetDayTimeString(DataTable scheduleTable, DataTable weekDayTable, DataTable weekTimeTable)
        {
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

                        schedDayTime.Append(" " + weekTimeTable.Rows[timeList[x].StartTime]["time_description"].ToString() + "-" +
                            weekTimeTable.Rows[timeList[x].EndTime]["time_description"].ToString() + "; ");
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

        //this function gets the units hours string
        private String GetSubjectUnitsHours(Int32 lectUnits, Int32 nonAcad, Int32 labUnits, String noHours)
        {
            return "Lec: " + lectUnits.ToString() + (nonAcad > 0 ? " (" + nonAcad + ")  " : String.Empty + "  ") +
                ((lectUnits > 1) ? "units" : "unit") + "     " +
                "Lab / RLE: " + labUnits.ToString() + " " + ((labUnits > 1) ? "units" : "unit") + "     " +
                "No.Hours: " + noHours;
        }//-----------------------------------  

        //this fucntion will determines if it has a conflict schedule
        private Boolean IsConflict(DataTable loadedScheduleTable, DataTable cachedScheduleTable, ref String sysIsSchedDetails)
        {
            Boolean isValid = false;

            foreach (DataRow loadedRow in loadedScheduleTable.Rows)
            {
                foreach (DataRow cachedRow in cachedScheduleTable.Rows)
                {
                    if ((RemoteServerLib.ProcStatic.DataRowConvert(loadedRow, "week_id", Byte.Parse("0")) ==
                        RemoteServerLib.ProcStatic.DataRowConvert(cachedRow, "week_id", Byte.Parse("0"))) &&
                        (RemoteServerLib.ProcStatic.DataRowConvert(loadedRow, "time_id", Byte.Parse("0")) ==
                        RemoteServerLib.ProcStatic.DataRowConvert(cachedRow, "time_id", Byte.Parse("0"))))
                    {
                        isValid = true;

                        sysIsSchedDetails = RemoteServerLib.ProcStatic.DataRowConvert(loadedRow, "sysid_scheddetails", "");

                        break;
                    }
                }

                if (isValid)
                {
                    break;
                }
            }

            return isValid;
        }//-------------------        

        //this function gets the units hours string
        private String GetSubjectUnitsHours(Single lectUnits, Single labUnits, String noHours)
        {
            return "Lecture: " + lectUnits.ToString() + " " + ((lectUnits > 1) ? "units" : "unit") + "     " +
                "Laboratory / RLE: " + labUnits.ToString() + " " + ((labUnits > 1) ? "units" : "unit") + "     " +
                "No. of Hours: " + noHours;
        } //-----------------------------------              

        //this function sets the subject schedule table
        private DataTable GenerateScheduleTable(String sysidSchedDetails)
        {
            DataTable schedTable = new DataTable("SubjectScheduleTable");
            schedTable.Columns.Add("sysid_scheddetails", System.Type.GetType("System.String"));
            schedTable.Columns.Add("week_id", System.Type.GetType("System.Byte"));
            schedTable.Columns.Add("time_id", System.Type.GetType("System.Byte"));

            if (_dayTimeScheduleTable != null)
            {
                String strFilter = "sysid_scheddetails = '" + sysidSchedDetails + "'";
                DataRow[] selectRow = _dayTimeScheduleTable.Select(strFilter);

                foreach (DataRow schedRow in selectRow)
                {
                    DataRow newRow = schedTable.NewRow();

                    newRow["sysid_scheddetails"] = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_scheddetails", "");
                    newRow["week_id"] = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "week_id", Byte.Parse("0"));
                    newRow["time_id"] = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "time_id", Byte.Parse("0"));

                    schedTable.Rows.Add(newRow);
                }

            }

            schedTable.AcceptChanges();

            return schedTable;
        } //-----------------------------------------

        //this function returns the schedule details for a schedule information
        private DataTable GetBySysIdScheduleScheduleDetailsTable(String sysIdSchedDetails)
        {
            DataTable classRoomTimeTable = new DataTable("ClassRoomTimeTable");
            classRoomTimeTable.Columns.Add("date_time", System.Type.GetType("System.String"));
            classRoomTimeTable.Columns.Add("section", System.Type.GetType("System.String"));
            classRoomTimeTable.Columns.Add("class_room", System.Type.GetType("System.String"));

            if (_teacherLoadTable != null)
            {
                String strFilter = "sysid_scheddetails_auxdetails = '" + sysIdSchedDetails + "'";
                DataRow[] selectRow = _teacherLoadTable.Select(strFilter);

                foreach (DataRow schedRow in selectRow)
                {
                    DataRow newRow = classRoomTimeTable.NewRow();

                    newRow["date_time"] = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "day_time", "");
                    newRow["section"] = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "section", "");
                    newRow["class_room"] = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "is_classroom", false) ?
                        RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "classroom_code", "") :
                        RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "field_room", "");

                    classRoomTimeTable.Rows.Add(newRow);
                }
            }

            return classRoomTimeTable;
        } //----------------------------------

        //this function will determines if the subject is Valid for teacher Loading
        private Boolean IsValidSubjectScheduleForTeacherLoading(String empSysId, String schedSysId)
        {
            Byte typeNo = 0;
            Byte groupNo = 0;

            String strFilterEmployee = "sysid_employee = '" + empSysId + "'";
            DataRow[] selectRowEmployee = _classDataSet.Tables["EmployeeInformationTable"].Select(strFilterEmployee);

            foreach (DataRow empRow in selectRowEmployee)
            {
                typeNo = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "type_no", Byte.Parse("0"));

                break;
            }

            String strFilterSched = "sysid_scheddetails_auxdetails = '" + schedSysId + "'";
            DataRow[] selectRowSchedule = _scheduleDetailsTable.Select(strFilterSched);

            foreach (DataRow schedRow in selectRowSchedule)
            {
                groupNo = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "group_no", Byte.Parse("0"));

                break;
            }

            return ((typeNo >= (Byte)CommonExchange.EmploymentTypeNo.CollegeFaculty && typeNo <= (Byte)CommonExchange.EmploymentTypeNo.Maintenance) &&
                groupNo == (Byte)CommonExchange.CourseGroupNo.GraduateSchoolDoctorate) ? false : true;

        }//--------------------

        //this function determines if the employee has a load
        private Boolean HasEmployeeLoad(String empSysId, String yearId, String semesterId)
        {
            Boolean hasLoad = false;

            if (_teacherLoadTable != null)
            {
                String strFilter = "sysid_employee = '" + empSysId + "' AND (year_semester_id = '" + yearId + "' OR year_semester_id = '" + semesterId + "')";
                DataRow[] selectRow = _teacherLoadTable.Select(strFilter);

                if (selectRow.Length >= 1)
                {
                    hasLoad = true;
                }
            }

            return hasLoad;
        } //--------------------------------

        //this function returns a schedule information details
        private CommonExchange.ScheduleInformation GetDetailsScheduleInformation(String scheduleSysId)
        {
            CommonExchange.ScheduleInformation schedInfo = new CommonExchange.ScheduleInformation();

            if (_scheduleDetailsTable != null)
            {
                String strFilter = "sysid_schedule_auxserviceschedule = '" + scheduleSysId + "'";
                DataRow[] selectRow = _scheduleDetailsTable.Select(strFilter, "sysid_schedule_auxserviceschedule ASC");

                foreach (DataRow schedRow in selectRow)
                {
                    schedInfo.ScheduleSysId = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_schedule_auxserviceschedule", "");

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

                    schedInfo.SubjectInfo.SubjectCode = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "subject_service_code", "");
                    schedInfo.SubjectInfo.DescriptiveTitle = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "descriptive_title", "");
                    schedInfo.SubjectInfo.LectureUnits = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "lecture_units_schedule", Byte.Parse("0"));
                    schedInfo.SubjectInfo.LabUnits = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "lab_units_schedule", Byte.Parse("0"));
                    schedInfo.SubjectInfo.NoHours = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "no_hours_schedule", "");
                    schedInfo.SubjectInfo.DepartmentInfo.DepartmentName = RemoteServerLib.ProcStatic.DataRowConvert(schedRow,
                        "subject_auxiliary_department_name", "");

                    break;
                }
            }

            return schedInfo;
        } //------------------------------

        //this function will get person sysid list by employee information
        private String GetPersonSysIdListByEmployeeTable()
        {
            String sysIdPersonList = String.Empty;

            if (_classDataSet.Tables["EmployeeInformationTable"] != null)
            {
                foreach (DataRow empRow in _classDataSet.Tables["EmployeeInformationTable"].Rows)
                {
                    sysIdPersonList += RemoteServerLib.ProcStatic.DataRowConvert(empRow, "sysid_person", String.Empty) + ",";
                }
            }

            return sysIdPersonList.Remove(sysIdPersonList.Length - 1, 1);
        }//----------------------------

        //this function will get employee sysid list
        private String GetEmployeeSysIdList()
        {
            String sysIdEmployeeList = String.Empty;

            if (_classDataSet.Tables["EmployeeInformationTable"] != null)
            {
                foreach (DataRow empRow in _classDataSet.Tables["EmployeeInformationTable"].Rows)
                {
                    sysIdEmployeeList += RemoteServerLib.ProcStatic.DataRowConvert(empRow, "sysid_employee", String.Empty) + ",";
                }
            }

            return sysIdEmployeeList.Remove(sysIdEmployeeList.Length - 1, 1);
        }//---------------------------------------

        //this fucntion will get list of person based on employee information
        private List<CommonExchange.Person> GetPersonInfoListByEmployeeTable()
        {
            List<CommonExchange.Person> personInfoList = new List<CommonExchange.Person>();

            if (_classDataSet.Tables["EmployeeInformationTable"] != null)
            {
                foreach (DataRow empRow in _classDataSet.Tables["EmployeeInformationTable"].Rows)
                {
                    CommonExchange.Person personInfo = new CommonExchange.Person();

                    personInfo.PersonSysId = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "sysid_person", String.Empty);
                    personInfo.LastName = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "last_name", "");
                    personInfo.FirstName = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "first_name", "");
                    personInfo.MiddleName = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "middle_name", "");

                    personInfoList.Add(personInfo);
                }
            }

            return personInfoList;
        }//------------------------------

        //this function will get employee information
        public CommonExchange.Employee GetEmployeeInformation(CommonExchange.SysAccess userInfo, String sysIdEmployee)
        {
            CommonExchange.Employee empInfo = new CommonExchange.Employee();

            String strFilter = "sysid_employee = '" + sysIdEmployee + "'";
            DataRow[] selectRow = _classDataSet.Tables["EmployeeInformationTable"].Select(strFilter);

            foreach (DataRow empRow in selectRow)
            {
                empInfo.EmployeeId = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "employee_id", "");
                empInfo.PersonInfo.PersonSysId = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "sysid_person", String.Empty);
                empInfo.PersonInfo.LastName = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "last_name", "");
                empInfo.PersonInfo.FirstName = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "first_name", "");
                empInfo.PersonInfo.MiddleName = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "middle_name", "");
                empInfo.SalaryInfo.DepartmentInfo.DepartmentName = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "department_name", "");
                empInfo.SalaryInfo.EmployeeStatusInfo.StatusDescription = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "status_description", "");
                empInfo.SalaryInfo.EmploymentTypeInfo.TypeDescription = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "type_description", "");
            }

            return empInfo;
        }//---------------------------

        //this function get the searched subject schedule / service information
        public DataTable GetSearchedSubjectScheduleServiceInformation(String strCriteria, String yearId, String semesterSysId)
        {
            DataTable newTable = new DataTable();
            newTable.Columns.Add("checkbox_column", System.Type.GetType("System.Boolean"));
            newTable.Columns.Add("sysid_schedule", System.Type.GetType("System.String"));
            newTable.Columns.Add("subject_code_title", System.Type.GetType("System.String"));
            newTable.Columns.Add("day_time", System.Type.GetType("System.String"));
            newTable.Columns.Add("section", System.Type.GetType("System.String"));
            newTable.Columns.Add("classroom_code_no_freeze", System.Type.GetType("System.String"));
            newTable.Columns.Add("lecture_units", System.Type.GetType("System.Single"));
            newTable.Columns.Add("lab_units", System.Type.GetType("System.Single"));
            newTable.Columns.Add("no_hours", System.Type.GetType("System.String"));

            if (_scheduleDetailsTable != null)
            {
                strCriteria = strCriteria.Replace("*", "").Replace("%", "").Replace("'", "''");

                String strFilter = "(subject_service_code LIKE '%" + strCriteria +
                                    "%' OR classroom_code LIKE '%" + strCriteria + "%' OR section LIKE '%" + strCriteria + "%')" +
                                     "AND (year_semester_id = '" + yearId + "' OR year_semester_id = '" + semesterSysId + "')";
                DataRow[] selectRow = _scheduleDetailsTable.Select(strFilter, "subject_service_code ASC");

                foreach (DataRow subRow in selectRow)
                {
                    if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(subRow, "sysid_employee", String.Empty)))
                    {
                        DataRow newRow = newTable.NewRow();

                        newRow["checkbox_column"] = false;
                        newRow["sysid_schedule"] = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "sysid_scheddetails_auxdetails", String.Empty);
                        newRow["subject_code_title"] = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_service_code", String.Empty) + " - " +
                            RemoteServerLib.ProcStatic.DataRowConvert(subRow, "descriptive_title", String.Empty);

                        if (!RemoteServerLib.ProcStatic.DataRowConvert(subRow, "is_irregular_modular", false))
                        {
                            newRow["day_time"] = String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(subRow, "day_time", "")) ?
                               c_tbaString : RemoteServerLib.ProcStatic.DataRowConvert(subRow, "day_time", "");
                        }
                        else
                        {
                            newRow["day_time"] = String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(subRow, "manual_schedule", String.Empty)) ?
                                c_tbaString : RemoteServerLib.ProcStatic.DataRowConvert(subRow, "manual_schedule", String.Empty);
                        }

                        newRow["section"] = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "section", String.Empty);
                        newRow["classroom_code_no_freeze"] = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "classroom_code", String.Empty);
                        newRow["lecture_units"] = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "lecture_units", Single.Parse("0"));
                        newRow["lab_units"] = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "lab_units", Single.Parse("0"));
                        newRow["no_hours"] = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "no_hours", String.Empty);

                        newTable.Rows.Add(newRow);
                    }
                }
            }

            return newTable;
        }//----------------------------------------

        //this funtion gets the searched schedule information details
        public DataTable SelectByDateStartEndScheduleInformationDetails(CommonExchange.SysAccess userInfo, String queryString, String dateStart, String dateEnd)
        {
            DataTable resultTable = new DataTable("ScheduleDetailsTable");

            using (RemoteClient.RemCntSubjectSchedulingManager remClient = new RemoteClient.RemCntSubjectSchedulingManager())
            {
                resultTable = remClient.SelectByDateStartEndScheduleInformationDetails(userInfo, queryString, dateStart, dateEnd, false);
            }

            DataTable detailsTable = new DataTable("ScheduleDetailsTableFormat");
            detailsTable.Columns.Add("subject_code_title", System.Type.GetType("System.String"));
            detailsTable.Columns.Add("day_time", System.Type.GetType("System.String"));
            detailsTable.Columns.Add("section", System.Type.GetType("System.String"));
            detailsTable.Columns.Add("classroom_field_code", System.Type.GetType("System.String"));
            detailsTable.Columns.Add("instructor_no_freeze", System.Type.GetType("System.String"));

            foreach (DataRow detailsRow in resultTable.Rows)
            {
                DataRow newRow = detailsTable.NewRow();

                newRow["subject_code_title"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "subject_code", String.Empty) + " - " +
                    RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "descriptive_title", String.Empty);

                if (!RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_irregular_modular", false))
                {
                     newRow["day_time"] = String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "day_time", "")) ?
                        c_tbaString : RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "day_time", "");
                }
                else
                {
                    newRow["day_time"] = String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "manual_schedule", String.Empty)) ?
                        c_tbaString : RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "manual_schedule", String.Empty);
                }

               newRow["section"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "section", String.Empty);
               newRow["classroom_field_code"] = String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "field_room", "")) ?
                    (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "classroom_code", "")) ? c_tbaString :
                    RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "classroom_code", "")) :
                    RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "field_room", "");
               newRow["instructor_no_freeze"] = RemoteClient.ProcStatic.GetCompleteNameFullMiddleName(
                   RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "last_name", String.Empty),
                   RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "first_name", String.Empty),
                   RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "middle_name", String.Empty));

                detailsTable.Rows.Add(newRow);
            }

            return detailsTable;
        }//----------------------------------

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
        }//----------------------------------------

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
        }//------------------------------

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
        }//----------------------------------------

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

        //this function gets the semester system id
        public String GetSemesterSystemId(Int32 yearIndex, Int32 semIndex)
        {
            DataRow yearRow = _classDataSet.Tables["SchoolFeeInformationTable"].Rows[yearIndex];

            String strFilter = "year_id = '" + yearRow["year_id"].ToString() + "'";
            DataRow[] selectRow = _classDataSet.Tables["SemesterInformationTable"].Select(strFilter);

            DataRow semRow = selectRow[semIndex];

            return semRow["sysid_semester"].ToString();
        } //-----------------------------------------

        //this function gets the school year year id
        public String GetSchoolYearYearId(Int32 index)
        {
            DataRow _yearRow = _classDataSet.Tables["SchoolFeeInformationTable"].Rows[index];

            return _yearRow["year_id"].ToString();
        }//----------------------------

        //this fucntion will get Employee and Subject Schedule System Id
        public String GetEmployeeScheduleSysId(String strValue)
        {
            return strValue.Substring(strValue.IndexOf("[") + 1, strValue.IndexOf("]") - strValue.IndexOf("[") - 1);
        }//------------------------

        //this fucntion gets the subject code title by sysid schedule details
        public String GetSubjectCodeTitleBySchedDetails(String sysidScheduleDetails)
        {
            String value = String.Empty;

            String strFilter = "sysid_scheddetails_auxdetails = '" + sysidScheduleDetails + "'";
            DataRow[] selectRow = _scheduleDetailsTable.Select(strFilter);

            foreach (DataRow subRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_service_code", "") + " - " +
                    RemoteServerLib.ProcStatic.DataRowConvert(subRow, "descriptive_title", "");

                break;
            }

            return value;
        }//-------------------------

        //this function will get conflict schedule with another department
        public DataTable SelectByScheduleDetailsListConflictsWithAnotherScheduleTeacherLoad(CommonExchange.SysAccess userInfo,
            DataTable scheduleDetailsTable, String employeeId)
        {
            DataTable newTable = new DataTable();

            using (RemoteClient.RemCntTeacherLoadingManager remClient = new RemoteClient.RemCntTeacherLoadingManager())
            {
                newTable = remClient.SelectByScheduleDetailsListConflictsWithAnotherScheduleTeacherLoad(userInfo,
                    this.GetScheduleDetailsSysIdList(scheduleDetailsTable), employeeId);
            }

            return newTable;
        }//---------------------------

        //this fucntion determins if there is a teacher load
        public Boolean HasTeacherLoad(String yearId, String semesterSysId)
        {
            String strFilter = "year_semester_id = '" + yearId + "' OR year_semester_id = '" + semesterSysId + "'";
            DataRow[] selectRow = _teacherLoadTable.Select(strFilter);

            return selectRow.Length > 1 ? true : false;
        }//--------------------------

        //this function determins if the subject schedule has conflict with another schedule in another department
        public Boolean HasConflictSchedule(DataTable scheduleDetailsTableWithConflicts, String sysIdScheduleDetails)
        {
            String strFilter = "sysid_scheddetails = '" + sysIdScheduleDetails + "'";
            DataRow[] selectRow = scheduleDetailsTableWithConflicts.Select(strFilter);

            return selectRow.Length == 0 ? false : true;
        }//-----------------------

        //this function determines if the subject schedule has a conflict schedule
        public Boolean HasConflictSchedule(DataTable scheduleDetailsTable, String sysIdScheduleDetails, String sysIdEmployee, ref String scheduleInformation)
        {
            Boolean isConflict = false;

            String value = String.Empty;

            if (this.IsValidSubjectScheduleForTeacherLoading(sysIdEmployee, sysIdScheduleDetails))
            {
                foreach (DataRow schedRow in scheduleDetailsTable.Rows)
                {
                    if (RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "checkbox_column", false) &&
                        (!String.Equals(RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_schedule", ""), sysIdScheduleDetails) &&
                        this.IsConflict(this.GenerateScheduleTable(RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_schedule", String.Empty)),
                        this.GenerateScheduleTable(sysIdScheduleDetails), ref value)))
                    {
                        isConflict = true;

                        scheduleInformation += "This schedule conflicts with another SELECTED schedule. [" +
                            this.GetSubjectCodeTitleBySchedDetails(value) + "]; ";
                       
                    }
                }
             
                String strFilterEmp = "sysid_employee = '" + sysIdEmployee + "'";
                DataRow[] selectRowEmp = _teacherLoadTable.Select(strFilterEmp);

                foreach (DataRow schedRow in selectRowEmp)
                {
                    if (!String.Equals(RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_scheddetails", ""), sysIdScheduleDetails) &&
                        this.IsConflict(this.GenerateScheduleTable(RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_scheddetails", "")),
                        this.GenerateScheduleTable(sysIdScheduleDetails), ref value))
                    {
                        isConflict = true;

                        scheduleInformation += "This schedule conflicts with another LOADED schedule. [" +
                            this.GetSubjectCodeTitleBySchedDetails(value) + "]; ";
                    }
                }
            }
            else
            {
                isConflict = true;

                scheduleInformation += "The instructor is not qualified to teach this subject., ";
            }

            return isConflict;
        }//-------------------------------     

        //this function will get number of load
        private String GetNumberOfLoad(String sysIdEmployee, String yearId, String semesterSysId)
        {
            String strFilter = "(sysid_employee = '" + sysIdEmployee + "'" +
                " AND (year_semester_id = '" + semesterSysId + "' OR year_semester_id = '" + yearId + "'))";
            DataRow[] selectRow = _teacherLoadTable.Select(strFilter);

            Int32 totalMinLoadAux = 0;

            DateTime noHoursLoaded = DateTime.MinValue;

            foreach (DataRow loadRow in selectRow)
            {
                if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "no_hours", ""), out noHoursLoaded))
                {
                    if (RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "is_semestral", false) &&
                        (RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "lecture_units", Single.Parse("0")) == 0 &&
                        RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "lab_units", Single.Parse("0")) == 0))
                    {
                        totalMinLoadAux += noHoursLoaded.Minute + (noHoursLoaded.Hour * 60);
                    }
                }
                else if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "no_hours", "")))
                {
                    Int32 hours = 0, minutes = 0, count = 1;

                    String[] strSplit = RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "no_hours", "").Split(':');

                    foreach (String value in strSplit)
                    {
                        if (!String.IsNullOrEmpty(value))
                        {
                            if (count == 1)
                            {
                                hours = Int32.Parse(value);
                            }
                            else
                            {
                                minutes = Int32.Parse(value);
                            }
                        }

                        count++;
                    }

                    totalMinLoadAux += minutes + (hours * 60);
                }
            }

            //total minutes is divided by 60 so that we could get the number of hours then it is divided by 3 so that we could come up with number of loads.
            Double noLoadLoadedAux = ((totalMinLoadAux / 60.0) / 3.0);

            return (Math.Floor(noLoadLoadedAux * 100) / 100).ToString("N");
        }//------------------------
       
        //this fucntion will get number of preparation
        public Int32 GetNumberOfPreperation(String sysIdEmployee, String yearId, String semesterSysId)
        {
            String strFilter = "((sysid_employee = '" + sysIdEmployee + "'" +
                " AND (year_semester_id = '" + semesterSysId + "' OR year_semester_id = '" + yearId + "')) AND is_auxiliary = 0)";

            DataTable newTable = _teacherLoadTable.DefaultView.ToTable(true, new String[] { "sysid_subject_auxservice", 
                "sysid_employee", "year_semester_id", "is_auxiliary" });
            DataRow[] selectRow = newTable.Select(strFilter);

            return selectRow.Length;
        }//----------------------------
        #endregion
    }
}
