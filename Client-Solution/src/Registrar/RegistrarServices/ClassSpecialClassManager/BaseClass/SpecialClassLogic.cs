using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace RegistrarServices
{
    internal class SpecialClassLogic
    {
        #region Class General Variable Declarations
        private DataSet _classDataSet;
        private Int64 _loadCounter;
        private DataTable _loadDeloadTable;
        private DataTable _prematureDeloadedTable;
        private DataTable _specialClassTable;
        private DataTable _semesterTable;
        private DataTable _yearTable;

        private DataTable _studentTable;
        private DataTable _subjectTable;

        #endregion

        #region Class Properties Declarations
        private String _serverDateTime;
        public String ServerDateTime
        {
            get { return _serverDateTime; }
        }
                
        public DataTable StudentSearchFormat
        {
            get
            {
                DataTable studentTable = new DataTable("StudentWithConcatenateNameTable");
                studentTable.Columns.Add("student_id", System.Type.GetType("System.String"));
                studentTable.Columns.Add("student_name", System.Type.GetType("System.String"));
                studentTable.Columns.Add("card_number", System.Type.GetType("System.String"));
                studentTable.Columns.Add("course_title", System.Type.GetType("System.String"));
                studentTable.Columns.Add("year_level_description", System.Type.GetType("System.String"));
                studentTable.Columns.Add("section", System.Type.GetType("System.String"));
                studentTable.Columns.Add("department_name", System.Type.GetType("System.String"));

                return studentTable;
            }
        }

        public DataTable SubjectTableFormat
        {
            get
            {
                DataTable subjectTable = new DataTable("SubjectFormatTable");
                subjectTable.Columns.Add("sysid_subject", System.Type.GetType("System.String"));
                subjectTable.Columns.Add("subject_code_title", System.Type.GetType("System.String"));
                subjectTable.Columns.Add("department_name", System.Type.GetType("System.String"));

                return subjectTable;
            }
        }

        public DataTable EmployeeTableFormat
        {
            get
            {
                DataTable employeeTable = new DataTable("EmployeeSearchByEmployeeNameIdTable");
                employeeTable.Columns.Add("employee_id", System.Type.GetType("System.String"));
                employeeTable.Columns.Add("employee_name", System.Type.GetType("System.String"));
                employeeTable.Columns.Add("department_name", System.Type.GetType("System.String"));

                return employeeTable;
            }
        }

        #endregion

        #region Class Constructor

        public SpecialClassLogic(CommonExchange.SysAccess userInfo)
        {
            this.InitializeClass(userInfo);          

            _loadCounter = 0;            
        }       

        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure inserts a new special class information
        public void InsertSpecialClassInformation(CommonExchange.SysAccess userInfo, CommonExchange.SpecialClassInformation specialInfo,
                                        CommonExchange.SubjectInformation subjectInfo, CommonExchange.Employee employeeInfo)
        {
            using (RemoteClient.RemCntSpecialClassManager remClient = new RemoteClient.RemCntSpecialClassManager())
            {
                remClient.InsertSpecialClassInformation(userInfo, ref specialInfo, _loadDeloadTable);
            }

            if (_specialClassTable != null)
            {
                DataRow newRow = _specialClassTable.NewRow();

                newRow["sysid_special"] = specialInfo.SpecialClassSysId;
                newRow["sysid_subject"] = specialInfo.SubjectSysId;
                newRow["sysid_employee"] = specialInfo.EmployeeSysId;

                if (!String.IsNullOrEmpty(specialInfo.YearId))
                {
                    newRow["year_semester_id"] = specialInfo.YearId;
                }
                else if (!String.IsNullOrEmpty(specialInfo.SemesterSysId))
                {
                    newRow["year_semester_id"] = specialInfo.SemesterSysId;
                }

                newRow["is_semestral"] = specialInfo.IsSemestral;
                newRow["amount"] = specialInfo.Amount;
                newRow["is_marked_deleted"] = false;
                newRow["department_id"] = subjectInfo.DepartmentInfo.DepartmentId;
                newRow["subject_code"] = subjectInfo.SubjectCode;
                newRow["descriptive_title"] = subjectInfo.DescriptiveTitle;
                newRow["lecture_units"] = subjectInfo.LectureUnits;
                newRow["lab_units"] = subjectInfo.LabUnits;
                newRow["no_hours"] = subjectInfo.NoHours;
                newRow["employee_id"] = employeeInfo.EmployeeId;
                newRow["last_name"] = employeeInfo.PersonInfo.LastName;
                newRow["first_name"] = employeeInfo.PersonInfo.FirstName;
                newRow["middle_name"] = employeeInfo.PersonInfo.MiddleName;
                newRow["status_id"] = employeeInfo.SalaryInfo.EmployeeStatusInfo.StatusId;
                newRow["type_description"] = employeeInfo.SalaryInfo.EmploymentTypeInfo.TypeDescription;
                newRow["status_description"] = employeeInfo.SalaryInfo.EmployeeStatusInfo.StatusDescription;
                newRow["subject_department_name"] = subjectInfo.DepartmentInfo.DepartmentName;
                newRow["employee_department_name"] = employeeInfo.SalaryInfo.DepartmentInfo.DepartmentName;

                _specialClassTable.Rows.Add(newRow);

                _specialClassTable.AcceptChanges();
            }

            if (_loadDeloadTable != null)
            {
                _loadDeloadTable.AcceptChanges();
            }

        } //----------------------------------------

        //this procedure updates a special class information
        public void UpdateSpecialClassInformation(CommonExchange.SysAccess userInfo, CommonExchange.SpecialClassInformation specialInfo)
        {
            using (RemoteClient.RemCntSpecialClassManager remClient = new RemoteClient.RemCntSpecialClassManager())
            {
                remClient.UpdateSpecialClassInformation(userInfo, specialInfo, _loadDeloadTable);
            }

            if (_specialClassTable != null)
            {
                Int32 count = 0;

                foreach (DataRow specialRow in _specialClassTable.Rows)
                {
                    if (String.Equals(specialInfo.SpecialClassSysId, RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "sysid_special", "")))
                    {
                        DataRow editRow = _specialClassTable.Rows[count];

                        editRow.BeginEdit();

                        editRow["sysid_special"] =  specialInfo.SpecialClassSysId;
                        editRow["sysid_subject"] = specialInfo.SubjectSysId;
                        editRow["sysid_employee"] = specialInfo.EmployeeSysId;

                        if (specialInfo.IsSemestral)
                        {
                            specialInfo.YearId = "";
                            editRow["year_semester_id"] = specialInfo.SemesterSysId;
                        }
                        else
                        {
                            editRow["year_semester_id"] = specialInfo.YearId;
                            specialInfo.SemesterSysId = "";
                        }

                        editRow["amount"] = specialInfo.Amount;
                        editRow["is_marked_deleted"] = specialInfo.IsMarkedDeleted;
                        editRow["department_id"] = specialInfo.DepartmentId;
                        editRow["subject_code"] = specialInfo.SubjectCode;
                        editRow["descriptive_title"] = specialInfo.DescriptiveTitle;
                        editRow["lecture_units"] = specialInfo.LectureUnits;
                        editRow["lab_units"] = specialInfo.LabUnits;
                        editRow["no_hours"] = specialInfo.NoHours;
                        editRow["employee_id"] = specialInfo.EmployeeId;
                        editRow["last_name"] = specialInfo.LastName;
                        editRow["first_name"] = specialInfo.FirstName;
                        editRow["middle_name"] = specialInfo.MiddleName;
                        editRow["type_description"] = specialInfo.TypeDescription;
                        editRow["status_description"] = specialInfo.StatusDescription;
                        editRow["subject_department_name"] = specialInfo.SubjectDepartmentName;
                        editRow["employee_department_name"] = specialInfo.EmployeeDepartmentName;

                        editRow.EndEdit();
                    }

                    count++;
                }
            }

            if (_loadDeloadTable != null)
            {
                _loadDeloadTable.AcceptChanges();
            }

        } //---------------------------------------

        //this procedure deletes a special class information
        public void DeleteSpecialClassInformation(CommonExchange.SysAccess userInfo, String specialSysId)
        {
            //gets the special class by date start and date end
            using (RemoteClient.RemCntSpecialClassManager remClient = new RemoteClient.RemCntSpecialClassManager())
            {
                remClient.DeleteSpecialClassInformation(userInfo, specialSysId);
            } //-----------------------

            if (_specialClassTable != null)
            {
                Int32 index = 0;

                foreach (DataRow specialRow in _specialClassTable.Rows)
                {
                    if (String.Equals(specialSysId, specialRow["sysid_special"].ToString()))
                    {
                        DataRow delRow = _specialClassTable.Rows[index];

                        delRow.Delete();

                        break;
                    }

                    index++;
                }

                _specialClassTable.AcceptChanges();
            }

        } //----------------------------

        //this procedure gets the special class table by date start and date end
        public void GetByDateStartEndSpecialClassInformationTable(CommonExchange.SysAccess userInfo, String dateStart,
                                                        String dateEnd, Boolean isMarkedDeleted)
        {
            //gets the special class by date start and date end
            using (RemoteClient.RemCntSpecialClassManager remClient = new RemoteClient.RemCntSpecialClassManager())
            {
                _specialClassTable = remClient.SelectByDateStartEndSpecialClassInformation(userInfo, dateStart, dateEnd, isMarkedDeleted);
            } //-----------------------

        } //------------------------------

        //this procedure gets the special class load table by special class system id
        public void GetBySpecialClassIdSpecialClassLoadTable(CommonExchange.SysAccess userInfo, String specialSysId)
        {
            //gets the special class load by special system id
            using (RemoteClient.RemCntSpecialClassManager remClient = new RemoteClient.RemCntSpecialClassManager())
            {
                DataTable specialClassLoadTable = new DataTable("SpecialClassLoadTable");

                specialClassLoadTable = remClient.SelectBySysIDSpecialSpecialClassLoad(userInfo, specialSysId, _serverDateTime);

                _loadDeloadTable.Rows.Clear();
                _prematureDeloadedTable.Rows.Clear();

                foreach (DataRow specialRow in specialClassLoadTable.Rows)
                {
                    Boolean isPreMatureDeloaded = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "is_premature_deloaded", false);

                    if (!isPreMatureDeloaded)
                    {
                        DataRow newRow = _loadDeloadTable.NewRow();

                        newRow["load_id"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "load_id", Int64.Parse("0"));
                        newRow["load_date"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "load_date", String.Empty);
                        newRow["deload_date"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "deload_date", String.Empty);
                        newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "sysid_student", String.Empty);
                        newRow["student_id"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "student_id", String.Empty);
                        newRow["last_name"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "last_name", String.Empty);
                        newRow["first_name"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "first_name", String.Empty);
                        newRow["middle_name"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow,"middle_name", String.Empty);
                        newRow["course_title"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "course_title", String.Empty);
                        newRow["year_level_description"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "year_level_description", String.Empty);
                        newRow["level_section"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "level_section", String.Empty);
                        newRow["department_name"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "department_name", String.Empty);
                        newRow["is_premature_deloaded"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "is_premature_deloaded", false);

                        _loadDeloadTable.Rows.Add(newRow);
                    }
                    else 
                    {
                        DataRow newRow = _prematureDeloadedTable.NewRow();

                        newRow["load_id"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "load_id", Int64.Parse("0"));
                        newRow["load_date"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "load_date", String.Empty);
                        newRow["deload_date"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "deload_date", String.Empty);
                        newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "sysid_student", String.Empty);
                        newRow["student_id"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "student_id", String.Empty);
                        newRow["last_name"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "last_name", String.Empty);
                        newRow["first_name"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "first_name", String.Empty);
                        newRow["middle_name"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "middle_name", String.Empty);
                        newRow["course_title"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "course_title", String.Empty);
                        newRow["year_level_description"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "year_level_description", String.Empty);
                        newRow["level_section"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "level_section", String.Empty);
                        newRow["department_name"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "department_name", String.Empty);
                        newRow["is_premature_deloaded"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "is_premature_deloaded", false);

                        _prematureDeloadedTable.Rows.Add(newRow);
                    }
                }

                _loadDeloadTable.AcceptChanges();
                _prematureDeloadedTable.AcceptChanges();
            } //-----------------------

        } //----------------------------

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

        //this procedure sets the tables to null
        public void SetSelectedDataTableToNull()
        {
            _subjectTable = null;
            _studentTable = null;
        } //------------------------------

        //this procedure sets the load/deload table to null
        public void SetLoadDeloadTableToNull()
        {
            _loadDeloadTable = null;
        } //--------------------------------

        //this procedure initializes the load/deload table
        public void InitializeLoadDeLoadPrematureDeloadedTable()
        {
            _loadDeloadTable = new DataTable("SpecialClassLoadBySpecialClassIdTable");
            _loadDeloadTable.Columns.Add("load_id", System.Type.GetType("System.Int64"));
            _loadDeloadTable.Columns.Add("load_date", System.Type.GetType("System.String"));
            _loadDeloadTable.Columns.Add("deload_date", System.Type.GetType("System.String"));
            _loadDeloadTable.Columns.Add("sysid_student", System.Type.GetType("System.String"));
            _loadDeloadTable.Columns.Add("student_id", System.Type.GetType("System.String"));
            _loadDeloadTable.Columns.Add("last_name", System.Type.GetType("System.String"));
            _loadDeloadTable.Columns.Add("first_name", System.Type.GetType("System.String"));
            _loadDeloadTable.Columns.Add("middle_name", System.Type.GetType("System.String"));
            _loadDeloadTable.Columns.Add("course_title", System.Type.GetType("System.String"));
            _loadDeloadTable.Columns.Add("year_level_description", System.Type.GetType("System.String"));
            _loadDeloadTable.Columns.Add("level_section", System.Type.GetType("System.String"));
            _loadDeloadTable.Columns.Add("department_name", System.Type.GetType("System.String"));
            _loadDeloadTable.Columns.Add("is_premature_deloaded", System.Type.GetType("System.Boolean"));

            _prematureDeloadedTable = new DataTable("SpecialClassPrematureDeloadedTable");
            _prematureDeloadedTable.Columns.Add("load_id", System.Type.GetType("System.Int64"));
            _prematureDeloadedTable.Columns.Add("load_date", System.Type.GetType("System.String"));
            _prematureDeloadedTable.Columns.Add("deload_date", System.Type.GetType("System.String"));
            _prematureDeloadedTable.Columns.Add("sysid_student", System.Type.GetType("System.String"));
            _prematureDeloadedTable.Columns.Add("student_id", System.Type.GetType("System.String"));
            _prematureDeloadedTable.Columns.Add("last_name", System.Type.GetType("System.String"));
            _prematureDeloadedTable.Columns.Add("first_name", System.Type.GetType("System.String"));
            _prematureDeloadedTable.Columns.Add("middle_name", System.Type.GetType("System.String"));
            _prematureDeloadedTable.Columns.Add("course_title", System.Type.GetType("System.String"));
            _prematureDeloadedTable.Columns.Add("year_level_description", System.Type.GetType("System.String"));
            _prematureDeloadedTable.Columns.Add("level_section", System.Type.GetType("System.String"));
            _prematureDeloadedTable.Columns.Add("department_name", System.Type.GetType("System.String"));
            _prematureDeloadedTable.Columns.Add("is_premature_deloaded", System.Type.GetType("System.Boolean"));
        } //---------------------------------

               
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

            //gets the dataset for the special class information
            using (RemoteClient.RemCntSpecialClassManager remClient = new RemoteClient.RemCntSpecialClassManager())
            {
                _classDataSet = remClient.GetDataSetForSpecialClassInformation(userInfo, _serverDateTime);
            } //-----------------------


        } //-----------------------

        #endregion

        #region Programmer-Defined Function Procedures

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

        //this function returns the special class load table
        public DataTable GetEnrolledWithdrawnSpecialClassLoadTable(Boolean isEnrolled)
        {
            DataTable newTable = new DataTable("SpecialClassBySystemIdEnrolledWithdrawnTable");         
            newTable.Columns.Add("load_id", System.Type.GetType("System.Int64"));
            newTable.Columns.Add("student_id", System.Type.GetType("System.String"));
            newTable.Columns.Add("student_name", System.Type.GetType("System.String"));
            newTable.Columns.Add("course_title", System.Type.GetType("System.String"));
            newTable.Columns.Add("year_level_description", System.Type.GetType("System.String"));
            newTable.Columns.Add("level_section", System.Type.GetType("System.String"));
            newTable.Columns.Add("department_name", System.Type.GetType("System.String"));

            if (!isEnrolled)
            {
                newTable.Columns.Add("load_date", System.Type.GetType("System.String"));
                newTable.Columns.Add("deload_date", System.Type.GetType("System.String"));
            }

            if (_loadDeloadTable != null)
            {
                if (isEnrolled)
                {
                    foreach (DataRow specialRow in _loadDeloadTable.Rows)
                    {
                        if (specialRow.RowState != DataRowState.Deleted)
                        {

                            DataRow newRow = newTable.NewRow();

                            newRow["load_id"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "load_id", Int64.Parse("0"));
                            newRow["student_id"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "student_id", "");
                            newRow["student_name"] = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(specialRow, "last_name", "first_name", "middle_name");
                            newRow["course_title"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "course_title", String.Empty);
                            newRow["year_level_description"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "year_level_description", String.Empty);
                            newRow["level_section"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "level_section", String.Empty);
                            newRow["department_name"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "department_name", String.Empty);

                            newTable.Rows.Add(newRow);
                        }
                    }
                }
                else
                {
                    foreach (DataRow specialRow in _prematureDeloadedTable.Rows)
                    {
                        if (specialRow.RowState != DataRowState.Deleted)
                        {
                            String loadDate = !String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "load_date", "")) ?
                               DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "load_date", "").ToString()).ToShortDateString() :
                               String.Empty;
                            String deloadDate = !String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "deload_date", "")) ?
                                DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "deload_date", "").ToString()).ToShortDateString() :
                                String.Empty;

                            DataRow newRow = newTable.NewRow();

                            newRow["load_id"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "load_id", Int64.Parse("0"));
                            newRow["student_id"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "student_id", "");
                            newRow["student_name"] = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(specialRow, "last_name", "first_name", "middle_name");
                            newRow["course_title"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "course_title", String.Empty);
                            newRow["year_level_description"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "year_level_description", String.Empty);
                            newRow["level_section"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "level_section", String.Empty);
                            newRow["department_name"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "department_name", String.Empty);
                            newRow["load_date"] = loadDate;
                            newRow["deload_date"] = deloadDate;

                            newTable.Rows.Add(newRow);
                        }
                    }
                }
            }

            newTable.AcceptChanges();

            return newTable;
        } //-----------------------

        //this function determines if the enrolled students has changes
        public Boolean HasEnrollWithdrawChanges()
        {
            Boolean hasChanges = false;

            if (_loadDeloadTable != null)
            {
                foreach (DataRow loadRow in _loadDeloadTable.Rows)
                {
                    if (loadRow.RowState == DataRowState.Deleted || loadRow.RowState != DataRowState.Unchanged)
                    {
                        hasChanges = true;
                        break;
                    }
                }
            }

            return hasChanges;
        } //----------------------------

        //this function enrolls a student to the special class
        public DataTable EnrollSpecialClassLoad(CommonExchange.StudentEnrolmentLevel studentEnrolmentLevelInfo)
        {
            if (_loadDeloadTable != null)
            {
                DataRow newRow = _loadDeloadTable.NewRow();

                newRow["load_id"] = --_loadCounter;
                newRow["load_date"] = String.Empty;
                newRow["deload_date"] = String.Empty;
                newRow["sysid_student"] = studentEnrolmentLevelInfo.StudentEnrolmentCourseInfo.StudentInfo.StudentSysId;
                newRow["student_id"] = studentEnrolmentLevelInfo.StudentEnrolmentCourseInfo.StudentInfo.StudentId;
                newRow["last_name"] = studentEnrolmentLevelInfo.StudentEnrolmentCourseInfo.StudentInfo.PersonInfo.LastName;
                newRow["first_name"] = studentEnrolmentLevelInfo.StudentEnrolmentCourseInfo.StudentInfo.PersonInfo.FirstName;
                newRow["middle_name"] = studentEnrolmentLevelInfo.StudentEnrolmentCourseInfo.StudentInfo.PersonInfo.MiddleName;
                newRow["course_title"] = studentEnrolmentLevelInfo.StudentEnrolmentCourseInfo.CourseInfo.CourseTitle;
                newRow["year_level_description"] = studentEnrolmentLevelInfo.SchoolFeeLevelInfo.YearLevelInfo.YearLevelDescription;
                newRow["level_section"] = studentEnrolmentLevelInfo.LevelSection;
                newRow["department_name"] = studentEnrolmentLevelInfo.StudentEnrolmentCourseInfo.CourseInfo.DepartmentInfo.DepartmentName;
                newRow["is_premature_deloaded"] = false;

                _loadDeloadTable.Rows.Add(newRow);

            }
            
            return this.GetEnrolledWithdrawnSpecialClassLoadTable(true);

        } //--------------------------------

        //this function determines if the student is already enrolled in the special class
        public Boolean IsAlreadyEnrolled(String studentId)
        {
            Boolean isEnrolled = false;

            if (_loadDeloadTable != null)
            {
                String strFilter = "student_id = '" + studentId + "' AND is_premature_deloaded = 0";
                DataRow[] selectRow = _loadDeloadTable.Select(strFilter, "sysid_student ASC");

                foreach (DataRow loadRow in selectRow)
                {
                    isEnrolled = true;
                    break;
                }
            }            

            return isEnrolled;
        } //----------------------------------

        //this procedure will Reaload Special Class
        public DataTable RealoadSpecialClassLoad(Int64 loadId)
        {
            if (_loadDeloadTable != null)
            {
                Boolean hasRealoaded = false;

                Int32 count = 0;

                foreach (DataRow specialRow in _prematureDeloadedTable.Rows)
                {
                    if (specialRow.RowState != DataRowState.Deleted &&
                        (RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "load_id", Int64.Parse("0")) == loadId))
                    {
                        if (!this.IsAlreadyEnrolled(RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "student_id", String.Empty)))
                        {
                            if (!this.IsExistSpecialClassLoadDeletedRow(RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "load_id", Int64.Parse("0"))))
                            {
                                DataRow newRow = _loadDeloadTable.NewRow();

                                newRow["load_id"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "load_id", Int64.Parse("0"));
                                newRow["load_date"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "load_date", String.Empty);
                                newRow["deload_date"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "deload_date", String.Empty);
                                newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "sysid_student", String.Empty);
                                newRow["student_id"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "student_id", String.Empty);
                                newRow["last_name"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "last_name", String.Empty);
                                newRow["first_name"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "middle_name", String.Empty);
                                newRow["middle_name"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "middle_name", String.Empty);
                                newRow["is_premature_deloaded"] = false;

                                _loadDeloadTable.Rows.Add(newRow);

                                hasRealoaded = true;
                            }
                        }
                        else
                        {
                            MessageBox.Show("The student is already enrolled in the special class.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        if (hasRealoaded)
                        {
                            DataRow delRow = _prematureDeloadedTable.Rows[count];

                            if (delRow.RowState == DataRowState.Modified || delRow.RowState == DataRowState.Added)
                            {
                                delRow.AcceptChanges();
                            }

                            delRow.Delete();
                        }

                        break;
                    }

                    count++;
                }
                
                if (hasRealoaded)
                {
                    Int32 index = 0;

                    foreach (DataRow loadRow in _loadDeloadTable.Rows)
                    {
                        if (loadRow.RowState != DataRowState.Deleted &&
                            (loadId > 0 && loadId == RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "load_id", Int64.Parse("0"))))
                        {
                            if (loadRow.RowState == DataRowState.Added)
                            {
                                loadRow.AcceptChanges();
                            }

                            if (!this.IsExistSpecialClassLoadDeletedRow(RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "load_id", Int64.Parse("0"))))
                            {
                                DataRow editRow = _loadDeloadTable.Rows[index];

                                editRow.BeginEdit();

                                editRow["is_premature_deloaded"] = false;

                                editRow.EndEdit();
                            }

                            break;
                        }
                        //else if (loadRow.RowState == DataRowState.Deleted &&
                        //    (loadId > 0 && loadId == Int64.Parse(loadRow["load_id", DataRowVersion.Original].ToString())))
                        //{
                        //    DataRow delRow = _loadDeloadTable.Rows[index];

                        //    delRow.AcceptChanges();

                        //    break;
                        //}

                        index++;
                    }
                }                
            }

            return this.GetEnrolledWithdrawnSpecialClassLoadTable(true);
        }//-----------------------

        //this function withdraw a student to the special class
        public DataTable WithdrawSpecialClassLoad(Int64 loadId)
        {
            if (_loadDeloadTable != null)
            {
                Int32 index = 0;

                foreach (DataRow specialRow in _loadDeloadTable.Rows)
                {
                    if (specialRow.RowState != DataRowState.Deleted &&
                        RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "load_id", Int64.Parse("0")) == loadId)
                    {
                        DataRow newRow = _prematureDeloadedTable.NewRow();

                        newRow["load_id"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "load_id", Int64.Parse("0"));
                        newRow["load_date"] =  RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "load_date", String.Empty);
                        newRow["deload_date"] =  RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "deload_date", String.Empty);
                        newRow["sysid_student"] =  RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "sysid_student", String.Empty);
                        newRow["student_id"] =  RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "student_id", String.Empty);
                        newRow["last_name"] =  RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "last_name", String.Empty);
                        newRow["first_name"] =  RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "first_name", String.Empty);
                        newRow["middle_name"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "middle_name", String.Empty);
                        newRow["is_premature_deloaded"] = true;

                        _prematureDeloadedTable.Rows.Add(newRow);                        

                        DataRow delRow = _loadDeloadTable.Rows[index];

                        if (delRow.RowState == DataRowState.Modified || delRow.RowState == DataRowState.Added)
                        {
                            specialRow.AcceptChanges();
                        }

                        delRow.Delete();

                        break;
                    }

                    index++;
                    
                }
            }

            return this.GetEnrolledWithdrawnSpecialClassLoadTable(true);

        } //---------------------------

        //this function returns a special class information details
        public CommonExchange.SpecialClassInformation GetDetailsSpecialClassInformation(String specialSysId)
        {
            CommonExchange.SpecialClassInformation specialInfo = new CommonExchange.SpecialClassInformation();

            if (_specialClassTable != null)
            {
                String strFilter = "sysid_special = '" + specialSysId + "'";
                DataRow[] selectRow = _specialClassTable.Select(strFilter, "sysid_special ASC");

                foreach (DataRow specialRow in selectRow)
                {
                    specialInfo.SpecialClassSysId = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "sysid_special", "");
                    specialInfo.SubjectSysId = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "sysid_subject", "");
                    specialInfo.EmployeeSysId = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "sysid_employee", "");

                    specialInfo.IsSemestral = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "is_semestral", false);

                    if (specialInfo.IsSemestral)
                    {
                        specialInfo.YearId = "";
                        specialInfo.SemesterSysId = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "year_semester_id", "");
                    }
                    else
                    {
                        specialInfo.YearId = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "year_semester_id", "");
                        specialInfo.SemesterSysId = "";
                    }

                    specialInfo.Amount = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "amount", Decimal.Parse("0"));
                    specialInfo.IsMarkedDeleted = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "is_marked_deleted", true);
                    specialInfo.DepartmentId = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "department_id", "");
                    specialInfo.SubjectCode = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_code", "");
                    specialInfo.DescriptiveTitle = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "descriptive_title", "");
                    specialInfo.LectureUnits = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "lecture_units", Byte.Parse("0"));
                    specialInfo.LabUnits = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "lab_units", Byte.Parse("0"));
                    specialInfo.NoHours = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "no_hours", "");
                    specialInfo.EmployeeId = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "employee_id", "");
                    specialInfo.LastName = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "last_name", "");
                    specialInfo.FirstName = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "first_name", "");
                    specialInfo.MiddleName = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "middle_name", "");
                    specialInfo.TypeDescription = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "type_description", "");
                    specialInfo.StatusDescription = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "status_description", "");                    
                    specialInfo.SubjectDepartmentName = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_department_name", "");
                    specialInfo.EmployeeDepartmentName = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "employee_department_name", "");

                }
            }            

            return specialInfo;
        } //---------------------------------------
        
        //this function returns a searched special class information
        public DataTable GetSearchedSpecialClassInformation(String queryString)
        {
            DataTable specialTable = new DataTable("SpecialClassWithConcatTable");
            specialTable.Columns.Add("sysid_special", System.Type.GetType("System.String"));
            specialTable.Columns.Add("subject_code_title", System.Type.GetType("System.String"));
            specialTable.Columns.Add("instructor", System.Type.GetType("System.String"));

            if (_specialClassTable != null)
            {
                foreach (DataRow specialRow in _specialClassTable.Rows)
                {
                    DataRow newRow = specialTable.NewRow();

                    newRow["sysid_special"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "sysid_special", "");
                    newRow["subject_code_title"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_code", "") + " - " +
                        RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "descriptive_title", "");
                    newRow["instructor"] = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(specialRow, "last_name", "first_name", "middle_name");

                    specialTable.Rows.Add(newRow);
                }
            }

            specialTable.AcceptChanges();

            DataTable newTable = new DataTable("SpecialClassInformationSearchTable");
            newTable.Columns.Add("sysid_special", System.Type.GetType("System.String"));
            newTable.Columns.Add("subject_code_title", System.Type.GetType("System.String"));
            newTable.Columns.Add("instructor", System.Type.GetType("System.String"));

            queryString = queryString.Replace("*", "").Replace("%", "").Replace("'", "''");

            String strFilter = "sysid_special LIKE '%" + queryString + "%' OR subject_code_title LIKE '%" + queryString + 
                                    "%' OR instructor LIKE '%" + queryString + "%'";
            DataRow[] selectRow = specialTable.Select(strFilter, "subject_code_title ASC");

            foreach (DataRow specialRow in selectRow)
            {
                DataRow newRow = newTable.NewRow();

                newRow["sysid_special"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "sysid_special", "");
                newRow["subject_code_title"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_code_title", "");
                newRow["instructor"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "instructor", "");

                newTable.Rows.Add(newRow);
            }            

            newTable.AcceptChanges();

            return newTable;
        } //-------------------------------------   

        //this function returns a searched special class information
        public DataTable GetSearchedSpecialClassInformation(String queryString, String semesterSysId)
        {
            DataTable specialTable = new DataTable("SpecialClassWithConcatTable");
            specialTable.Columns.Add("sysid_special", System.Type.GetType("System.String"));
            specialTable.Columns.Add("subject_code_title", System.Type.GetType("System.String"));
            specialTable.Columns.Add("instructor", System.Type.GetType("System.String"));
            specialTable.Columns.Add("year_semester_id", System.Type.GetType("System.String"));

            if (_specialClassTable != null)
            {
                foreach (DataRow specialRow in _specialClassTable.Rows)
                {
                    DataRow newRow = specialTable.NewRow();

                    newRow["sysid_special"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "sysid_special", "");
                    newRow["subject_code_title"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_code", "") + " - " +
                        RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "descriptive_title", "");
                    newRow["instructor"] = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(specialRow, "last_name", "first_name", "middle_name");
                    newRow["year_semester_id"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "year_semester_id", "");

                    specialTable.Rows.Add(newRow);
                }
            }

            specialTable.AcceptChanges();

            DataTable newTable = new DataTable("SpecialClassInformationSearchTable");
            newTable.Columns.Add("sysid_special", System.Type.GetType("System.String"));
            newTable.Columns.Add("subject_code_title", System.Type.GetType("System.String"));
            newTable.Columns.Add("instructor", System.Type.GetType("System.String"));

            queryString = queryString.Replace("*", "").Replace("%", "").Replace("'", "''");

            String strFilter = "(sysid_special LIKE '%" + queryString + "%' OR subject_code_title LIKE '%" + queryString +
                                    "%' OR instructor LIKE '%" + queryString + "%') AND (year_semester_id = '" + semesterSysId + "')";
            DataRow[] selectRow = specialTable.Select(strFilter, "subject_code_title ASC");

            foreach (DataRow specialRow in selectRow)
            {
                DataRow newRow = newTable.NewRow();

                newRow["sysid_special"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "sysid_special", "");
                newRow["subject_code_title"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_code_title", "");
                newRow["instructor"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "instructor", "");

                newTable.Rows.Add(newRow);
            }

            newTable.AcceptChanges();

            return newTable;
        } //-------------------------------------      

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
                    subjectInfo.CourseGroupInfo.GroupNo = RemoteServerLib.ProcStatic.DataRowConvert(subjectRow, "group_no", Byte.Parse("0"));
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

        //this function gets the employee information
        public CommonExchange.Employee GetDetailsBySystemIdEmployeeInformation(String employeeSysId)
        {
            CommonExchange.Employee empInfo = new CommonExchange.Employee();
            
            String strFilter = "sysid_employee = '" + employeeSysId + "'";
            DataRow[] selectRow = _classDataSet.Tables["EmployeeInformationTable"].Select(strFilter, "sysid_employee ASC");

            foreach (DataRow empRow in selectRow)
            {
                empInfo.EmployeeSysId = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "sysid_employee", "");
                empInfo.EmployeeId = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "employee_id", "");
                empInfo.CardNumber = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "card_number", "");
                empInfo.PersonInfo.LastName = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "last_name", "");
                empInfo.PersonInfo.FirstName = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "first_name", "");
                empInfo.PersonInfo.MiddleName = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "middle_name", "");
                empInfo.SalaryInfo.EmploymentTypeInfo.TypeDescription = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "type_description", "");
                empInfo.SalaryInfo.EmployeeStatusInfo.StatusDescription = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "status_description", "");
            }
            
            return empInfo;
        } //-----------------------    

        //this function gets the employee information
        public CommonExchange.Employee GetDetailsByEmployeeIdEmployeeInformation(String employeeId)
        {
            CommonExchange.Employee empInfo = new CommonExchange.Employee();

            String strFilter = "employee_id = '" + employeeId + "'";
            DataRow[] selectRow = _classDataSet.Tables["EmployeeInformationTable"].Select(strFilter, "sysid_employee ASC");

            foreach (DataRow empRow in selectRow)
            {
                empInfo.EmployeeSysId = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "sysid_employee", "");
                empInfo.EmployeeId = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "employee_id", "");
                empInfo.CardNumber = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "card_number", "");
                empInfo.PersonInfo.LastName = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "last_name", "");
                empInfo.PersonInfo.FirstName = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "first_name", "");
                empInfo.PersonInfo.MiddleName = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "middle_name", "");
                empInfo.SalaryInfo.EmploymentTypeInfo.TypeDescription = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "type_description", "");
                empInfo.SalaryInfo.EmployeeStatusInfo.StatusDescription = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "status_description", "");
                empInfo.SalaryInfo.DepartmentInfo.DepartmentName = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "department_name", "");
            }
            
            return empInfo;
        } //-----------------------    

        //this function gets the selected employee
        public DataTable GetSearchedEmployeeInformation(String strCriteria)
        {
            DataTable employeeTable = new DataTable("EmployeeWithConcatenateNameTable");
            employeeTable.Columns.Add("employee_id", System.Type.GetType("System.String"));
            employeeTable.Columns.Add("employee_name", System.Type.GetType("System.String"));
            employeeTable.Columns.Add("status_id", System.Type.GetType("System.Byte"));
            employeeTable.Columns.Add("department_name", System.Type.GetType("System.String"));
            
            foreach (DataRow empRow in _classDataSet.Tables["EmployeeInformationTable"].Rows)
            {
                DataRow newRow = employeeTable.NewRow();

                newRow["employee_id"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "employee_id", "");
                newRow["employee_name"] = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(empRow, "last_name", "first_name", "middle_name");
                newRow["status_id"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "status_id", Byte.Parse("0"));
                newRow["department_name"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "department_name", "");

                employeeTable.Rows.Add(newRow);
            }       

            employeeTable.AcceptChanges();

            DataTable newTable = new DataTable("EmployeeSearchByEmployeeNameIdTable");
            newTable.Columns.Add("employee_id", System.Type.GetType("System.String"));
            newTable.Columns.Add("employee_name", System.Type.GetType("System.String"));
            newTable.Columns.Add("department_name", System.Type.GetType("System.String"));

            strCriteria = strCriteria.Replace("*", "").Replace("%", "").Replace("'", "''");

            String strFilter = "(employee_id LIKE '%" + strCriteria + "%' OR " +
                        "employee_name LIKE '%" + strCriteria + "%') AND NOT status_id = '" + (Byte)CommonExchange.EmploymentStatusNo.LayOff + "'";

            DataRow[] selectRow = employeeTable.Select(strFilter, "employee_name ASC");

            foreach (DataRow empRow in selectRow)
            {
                DataRow newRow = newTable.NewRow();

                newRow["employee_id"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "employee_id", "");
                newRow["employee_name"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "employee_name", "");
                newRow["department_name"] = RemoteServerLib.ProcStatic.DataRowConvert(empRow, "department_name", "");

                newTable.Rows.Add(newRow);
            }

            newTable.AcceptChanges();

            return newTable;

        } //-------------------------------

        //this function returns the student details
        public CommonExchange.Student GetDetailsBySystemIdStudentInformation(String studentSysId)
        {
            CommonExchange.Student studentInfo = new CommonExchange.Student();

            if (_studentTable != null)
            {
                String strFilter = "sysid_student = '" + studentSysId + "'";
                DataRow[] selectRow = _studentTable.Select(strFilter, "sysid_student ASC");

                foreach (DataRow studentRow in selectRow)
                {
                    studentInfo.StudentSysId = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "sysid_student", "");
                    studentInfo.StudentId = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "student_id", "");
                    studentInfo.CardNumber = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "card_number", "");
                    studentInfo.CourseInfo.CourseId = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "course_id", "");
                    studentInfo.PersonInfo.LastName = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "last_name", "");
                    studentInfo.PersonInfo.FirstName = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "first_name", "");
                    studentInfo.PersonInfo.MiddleName = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "middle_name", "");
                }
            }            

            return studentInfo;
        } //----------------------------

        //this function returns the student details
        public CommonExchange.StudentEnrolmentLevel GetDetailsByStudentIdStudentInformation(String studentId)
        {
            CommonExchange.StudentEnrolmentLevel studentEnrolmentLevelInfo = new CommonExchange.StudentEnrolmentLevel();

            if (_studentTable != null)
            {
                String strFilter = "student_id = '" + studentId + "'";
                DataRow[] selectRow = _studentTable.Select(strFilter, "sysid_student ASC");

                foreach (DataRow studentRow in selectRow)
                {
                    studentEnrolmentLevelInfo.StudentEnrolmentCourseInfo.StudentInfo.StudentSysId = 
                        RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "sysid_student", "");
                    studentEnrolmentLevelInfo.StudentEnrolmentCourseInfo.StudentInfo.StudentId = 
                        RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "student_id", "");
                    studentEnrolmentLevelInfo.StudentEnrolmentCourseInfo.StudentInfo.CardNumber = 
                        RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "card_number", "");
                    studentEnrolmentLevelInfo.StudentEnrolmentCourseInfo.CourseInfo.CourseId = 
                        RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "course_id", "");
                    studentEnrolmentLevelInfo.StudentEnrolmentCourseInfo.StudentInfo.PersonInfo.LastName 
                        = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "last_name", "");
                    studentEnrolmentLevelInfo.StudentEnrolmentCourseInfo.StudentInfo.PersonInfo.FirstName = 
                        RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "first_name", "");
                    studentEnrolmentLevelInfo.StudentEnrolmentCourseInfo.StudentInfo.PersonInfo.MiddleName = 
                        RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "middle_name", "");
                    studentEnrolmentLevelInfo.StudentEnrolmentCourseInfo.CourseInfo.CourseTitle =
                        RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "course_title", "");
                    studentEnrolmentLevelInfo.SchoolFeeLevelInfo.YearLevelInfo.YearLevelDescription =
                        RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "year_level_description", "");
                    studentEnrolmentLevelInfo.LevelSection = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "level_section", "");
                    studentEnrolmentLevelInfo.StudentEnrolmentCourseInfo.CourseInfo.DepartmentInfo.DepartmentName =
                        RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "department_name", "");
                }

            }
            
            return studentEnrolmentLevelInfo;
        } //----------------------------

        //this function gets the selected student
        public DataTable GetSearchedStudentInformation(CommonExchange.SysAccess userInfo, String queryString, Boolean isNewQuery,
            String dateStart, String dateEnd)
        {
            if (isNewQuery)
            {
                using (RemoteClient.RemCntStudentManager remClient = new RemoteClient.RemCntStudentManager())
                {
                    _studentTable = remClient.SelectStudentInformation(userInfo, queryString, dateStart, dateEnd, String.Empty, String.Empty);
                }
            }
            
            DataTable studentTable = new DataTable("StudentWithConcatenateNameTable");
            studentTable.Columns.Add("student_id", System.Type.GetType("System.String"));
            studentTable.Columns.Add("student_name", System.Type.GetType("System.String"));
            studentTable.Columns.Add("card_number", System.Type.GetType("System.String"));
            studentTable.Columns.Add("course_title", System.Type.GetType("System.String"));
            studentTable.Columns.Add("year_level_description", System.Type.GetType("System.String"));
            studentTable.Columns.Add("level_section", System.Type.GetType("System.String"));
            studentTable.Columns.Add("department_name", System.Type.GetType("System.String"));

            if (_studentTable != null)
            {
                foreach (DataRow studentRow in _studentTable.Rows)
                {
                    DataRow newRow = studentTable.NewRow();

                    newRow["student_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "student_id", "");
                    newRow["student_name"] = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(studentRow, "last_name", "first_name", "middle_name");
                    newRow["card_number"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "card_number", "");
                    newRow["course_title"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "course_title", "");
                    newRow["year_level_description"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "year_level_description", "");
                    newRow["level_section"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "level_section", "");
                    newRow["department_name"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "department_name", "");

                    studentTable.Rows.Add(newRow);
                }
            }            

            studentTable.AcceptChanges();

            return studentTable;

        } //----------------------------------

        //this function determines if the special class information already exists
        public Boolean IsExistsInformationSpecialClassInformation(CommonExchange.SysAccess userInfo,
                                                                    CommonExchange.SpecialClassInformation specialInfo)
        {
            Boolean isExist = false;

            //determines if the special class information already exists
            using (RemoteClient.RemCntSpecialClassManager remClient = new RemoteClient.RemCntSpecialClassManager())
            {
                isExist = remClient.IsExistsInformationSpecialClassInformation(userInfo, specialInfo);
            } //-----------------------

            return isExist;
        } //--------------------------------------------------

        //this function gets the units hours string
        public String GetSubjectUnitsHours(Byte lectUnits, Byte labUnits, String noHours)
        {
            return "Lecture: " + lectUnits.ToString() + " " + ((lectUnits > 1) ? "units" : "unit") + "     " +
                "Laboratory / RLE: " + labUnits.ToString() + " " + ((labUnits > 1) ? "units" : "unit") + "     " +
                "No. of Hours: " + noHours;
        } //-----------------------------------
        
        private Boolean IsExistSpecialClassLoadDeletedRow(Int64 loadId)
        {
            Boolean isExist = false;

            if (_loadDeloadTable != null)
            {
                foreach (DataRow loadRow in _loadDeloadTable.Rows)
                {
                    if (loadRow.RowState == DataRowState.Deleted &&
                        loadId == Int64.Parse(loadRow["load_id", DataRowVersion.Original].ToString()))
                    {
                        loadRow.AcceptChanges();
                        isExist = true;

                        break;
                    }
                }
            }

            return isExist;
        }//--------------------

        #endregion
    }
}
