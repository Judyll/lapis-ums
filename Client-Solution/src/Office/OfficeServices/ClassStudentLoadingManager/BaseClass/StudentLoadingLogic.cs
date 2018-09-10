using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Collections;

namespace OfficeServices
{
    public class StudentLoadingLogic : BaseServices.BaseServicesLogic
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
        private DataSet _classDataSet;
        private DataTable _studentTable;
        private DataTable _studentCourseTable;
        private DataTable _studentCourseHistoryTable;
        private DataTable _studentLevelTable;
        private DataTable _changeStudentLevelTable;
        private DataTable _studentLevelHistroyTable;        
        private DataTable _loadedSubjectTable;
        private DataTable _openSubjectTable;
        private DataTable _prematureDeloadedSubjectTable;
        private DataTable _subjectScheduleDetailsTable;
        private DataTable _dayTimeScheduleTable;
        private DataTable _schoolFeeDetailsTable;
        private DataTable _optionalSchoolFeeDetailsTable;
        private DataTable _optionalFeeTable;
        private DataTable _paymentReimbursementTable;
        private DataTable _balanceForwardedTable;
        private DataTable _courseGroupTable;
        private DataTable _majorExamScheduleTable;
        private DataTable _courseMajorTable;
        private DataTable _paymentReimbursementTableTemp;
        private DataTable _specialClassTable;        
        private DataTable _subjectScheduleTable;
        private DataTable _studentTranscriptTable;

        private const String c_tbaString = "TBA";
        private String _imagePath;
        private Int64 _countLoadId;
        private Int64 _countOptionalFeeId;

        private Decimal _totalCharges;
        #endregion

        #region Class Properties Declarations
        private DataTable _studentLoadTable;
        public DataTable StudentLoadtable
        {
            get { return _studentLoadTable; }
            set { _studentLoadTable = value; }
        }

        public DataTable StudentTable
        {
            get { return _studentTable; }
        }

        public DataTable StudentPrintingStatementOfAccountTable
        {
            get
            {
                DataTable newTable = new DataTable("StudentPrintingStatementOfAccount");
                newTable.Columns.Add("checkbox_column", System.Type.GetType("System.Boolean"));
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

                return newTable;
            }
        }
        
        public DataTable SubjectTableFormat
        {
            get
            {               

                DataTable subjectTable = new DataTable("SubjectTableFormat");
                subjectTable.Columns.Add("checkbox_column", System.Type.GetType("System.Boolean"));
                subjectTable.Columns.Add("sysid_schedule", System.Type.GetType("System.String"));
                subjectTable.Columns.Add("subject_code_title", System.Type.GetType("System.String"));
                subjectTable.Columns.Add("slots_available", System.Type.GetType("System.Int16"));
                subjectTable.Columns.Add("lecture_units", System.Type.GetType("System.Byte"));
                subjectTable.Columns.Add("lab_units", System.Type.GetType("System.Byte"));
                subjectTable.Columns.Add("no_hours", System.Type.GetType("System.String"));
                subjectTable.Columns.Add("department_name", System.Type.GetType("System.String"));

                return subjectTable;
            }
        }

        public DataTable ScheduleDetailsTableFormat
        {

            get
            {
                DataTable scheduleDetailsTable = new DataTable("ScheduleDetailsTable");
                scheduleDetailsTable.Columns.Add("day_time", System.Type.GetType("System.String"));
                scheduleDetailsTable.Columns.Add("section", System.Type.GetType("System.String"));
                scheduleDetailsTable.Columns.Add("classroom_field_code", System.Type.GetType("System.String"));

                return scheduleDetailsTable;
            }
        }

        public DataTable OptinalFeeTableFormat
        {
            get
            {
                DataTable optionalFeeTable = new DataTable("OptionalFeeTableFormat");
                optionalFeeTable.Columns.Add("sysid_feedetails", System.Type.GetType("System.String"));
                optionalFeeTable.Columns.Add("particular_description", System.Type.GetType("System.String"));
                optionalFeeTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));

                return optionalFeeTable;
            }
        }

        public DataTable StudentTranscriptTable
        {
            get
            {
                DataTable transcriptTable = new DataTable("CutTranscriptDetailsTable");
                transcriptTable.Columns.Add("term_session", System.Type.GetType("System.String"));
                transcriptTable.Columns.Add("subject_code", System.Type.GetType("System.String"));
                transcriptTable.Columns.Add("descriptive_title", System.Type.GetType("System.String"));
                transcriptTable.Columns.Add("credit_units", System.Type.GetType("System.String"));
                transcriptTable.Columns.Add("final_grade", System.Type.GetType("System.String"));
                transcriptTable.Columns.Add("re_exam", System.Type.GetType("System.String"));
                transcriptTable.Columns.Add("no_of_hours", System.Type.GetType("System.String"));

                return transcriptTable;
            }
        }
        #endregion

        #region Class Constructors
        public StudentLoadingLogic(CommonExchange.SysAccess userInfo)
        {
            this.InitializeClass(userInfo);

            _imagePath = "\\StudentImages";            
        }
        #endregion

        #region Programer-Defined Void Procedures     
        //this procedure initailized the class
        private void InitializeClass(CommonExchange.SysAccess userInfo)
        {
            //get the server date and time
            using (RemoteClient.RemCntBaseManager remClient = new RemoteClient.RemCntBaseManager())
            {
                _serverDateTime = remClient.GetServerDateTime(userInfo);
            }//---------------------

            //get the dataset student manager
            using (RemoteClient.RemCntStudentLoadingManager remClient = new RemoteClient.RemCntStudentLoadingManager())
            {
                _classDataSet = remClient.GetDataSetForStudentLoad(userInfo, _serverDateTime);
            }//----------------------    

            //initialized loaded subject table
            _loadedSubjectTable = new DataTable("LoadedSubjectTable");
            _loadedSubjectTable.Columns.Add("sysid_schedule", System.Type.GetType("System.String"));
            _loadedSubjectTable.Columns.Add("sysid_subject", System.Type.GetType("System.String"));
            _loadedSubjectTable.Columns.Add("is_loaded_to_student", System.Type.GetType("System.Boolean"));
            //----------------------------

            //initialized open subject table
            _openSubjectTable = new DataTable("OpentSubjectTable");
            _openSubjectTable.Columns.Add("sysid_schedule", System.Type.GetType("System.String"));
            _openSubjectTable.Columns.Add("is_loaded_to_student", System.Type.GetType("System.Boolean"));
            //------------------------------

            //initialized premature deloaded table
            _prematureDeloadedSubjectTable = new DataTable("PrematureDeloadedTable");
            _prematureDeloadedSubjectTable.Columns.Add("sysid_schedule", System.Type.GetType("System.String"));
            _prematureDeloadedSubjectTable.Columns.Add("load_id", System.Type.GetType("System.String"));
            _prematureDeloadedSubjectTable.Columns.Add("is_loaded_to_student", System.Type.GetType("System.Boolean"));
            //--------------------------------

            //initialize student load table
            _studentLoadTable = new DataTable("StudentLoadTable");
            _studentLoadTable.Columns.Add("load_id", System.Type.GetType("System.Int64"));
            _studentLoadTable.Columns.Add("sysid_enrolmentlevel", System.Type.GetType("System.String"));
            _studentLoadTable.Columns.Add("sysid_schedule", System.Type.GetType("System.String"));
            _studentLoadTable.Columns.Add("is_loaded", System.Type.GetType("System.Boolean"));
            _studentLoadTable.Columns.Add("is_premature_deloaded", System.Type.GetType("System.Boolean"));
            //--------------------------------

            //initialize optional fee table
            _optionalFeeTable = new DataTable("OptionalFeeTable");
            _optionalFeeTable.Columns.Add("optional_fee_id", System.Type.GetType("System.Int64"));
            _optionalFeeTable.Columns.Add("sysid_enrolmentlevel", System.Type.GetType("System.String"));
            _optionalFeeTable.Columns.Add("sysid_feedetails", System.Type.GetType("System.String"));
            _optionalFeeTable.Columns.Add("fee_category_id", System.Type.GetType("System.String"));
            _optionalFeeTable.Columns.Add("sysid_feeparticular", System.Type.GetType("System.String"));
            _optionalFeeTable.Columns.Add("particular_description", System.Type.GetType("System.String"));
            _optionalFeeTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));
            _optionalFeeTable.Columns.Add("is_level_increase", System.Type.GetType("System.Boolean"));
            _optionalFeeTable.Columns.Add("is_optional_fee", System.Type.GetType("System.Boolean"));
            _optionalFeeTable.Columns.Add("is_office_access", System.Type.GetType("System.Boolean"));          
            //-------------------------------           
                   
            //initialize course group table
            _courseGroupTable = new DataTable("CourseGroupTable");
            _courseGroupTable.Columns.Add("course_group_id", System.Type.GetType("System.String"));
            //---------------------------

            //initialize major exam table
            _majorExamScheduleTable = new DataTable("MajorExamScheduleTable");
            _majorExamScheduleTable.Columns.Add("major_exam_id", System.Type.GetType("System.String"));
            _majorExamScheduleTable.Columns.Add("exam_date", System.Type.GetType("System.String"));
            _majorExamScheduleTable.Columns.Add("exam_description", System.Type.GetType("System.String"));
            _majorExamScheduleTable.Columns.Add("is_for_print", System.Type.GetType("System.Boolean"));
            _majorExamScheduleTable.Columns.Add("is_clearance_included", System.Type.GetType("System.Boolean"));
            _majorExamScheduleTable.Columns.Add("course_group_id", System.Type.GetType("System.String"));
            //-------------------------

            //initialize the temporary payment discount reimbursementa table
            _paymentReimbursementTableTemp = new DataTable("TempPaymentDiscountReimbursmenTable");
            _paymentReimbursementTableTemp.Columns.Add("payment_discount_reimbursement_id", System.Type.GetType("System.Int64"));
            _paymentReimbursementTableTemp.Columns.Add("sysid_student", System.Type.GetType("System.String"));
            _paymentReimbursementTableTemp.Columns.Add("received_date", System.Type.GetType("System.String"));
            _paymentReimbursementTableTemp.Columns.Add("receipt_no", System.Type.GetType("System.String"));
            _paymentReimbursementTableTemp.Columns.Add("remarks_discount_reimbursement_description", System.Type.GetType("System.String"));
            _paymentReimbursementTableTemp.Columns.Add("is_downpayment", System.Type.GetType("System.Boolean"));
            _paymentReimbursementTableTemp.Columns.Add("amount", System.Type.GetType("System.Decimal"));
            _paymentReimbursementTableTemp.Columns.Add("discount_amount", System.Type.GetType("System.Decimal"));
            _paymentReimbursementTableTemp.Columns.Add("is_payment", System.Type.GetType("System.Boolean"));
            _paymentReimbursementTableTemp.Columns.Add("is_discount", System.Type.GetType("System.Boolean"));
            _paymentReimbursementTableTemp.Columns.Add("is_reimbursement", System.Type.GetType("System.Boolean"));
            _paymentReimbursementTableTemp.Columns.Add("is_balance_forwarded", System.Type.GetType("System.Boolean"));
            _paymentReimbursementTableTemp.Columns.Add("is_credit_memo", System.Type.GetType("System.Boolean"));
            _paymentReimbursementTableTemp.Columns.Add("is_included_in_post", System.Type.GetType("System.Boolean"));
            //-----------------------------

            _countLoadId = 0;
            _countOptionalFeeId = 0;
            _totalCharges = 0;
        }//------------------------------

        //this procedure will print student grades
        public void PrintStudentGrade(CommonExchange.SysAccess userInfo, CommonExchange.Student studentInfo)
        {
            if (_studentTranscriptTable != null)
            {
                DataTable newTable = this.StudentTranscriptTable;

                if (_studentTranscriptTable != null)
                {
                    foreach (DataRow transRow in _studentTranscriptTable.Rows)
                    {
                        DataRow newRow = newTable.NewRow();

                        newRow["term_session"] = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "term_session", String.Empty);
                        newRow["subject_code"] = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "subject_code", String.Empty) + " " +
                            RemoteServerLib.ProcStatic.DataRowConvert(transRow, "subject_no", String.Empty);
                        newRow["descriptive_title"] = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "descriptive_title", String.Empty);
                        newRow["credit_units"] = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "credit_units", String.Empty);
                        newRow["no_of_hours"] = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "no_of_hours", String.Empty);
                        newRow["final_grade"] = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "final_grade", String.Empty);
                        newRow["re_exam"] = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "re_exam", String.Empty);

                        newTable.Rows.Add(newRow);
                    }
                }

                using (ClassStudentLoadingManager.CrystalReport.CrystalStudentGrade rptStudentGrade =
                 new OfficeServices.ClassStudentLoadingManager.CrystalReport.CrystalStudentGrade())
                {
                    rptStudentGrade.Database.Tables["transcript_details_table"].SetDataSource(newTable);
                    
                    rptStudentGrade.SetParameterValue("@school_name", CommonExchange.SchoolInformation.SchoolName);
                    rptStudentGrade.SetParameterValue("@form_name", "Student Grade List");
                    rptStudentGrade.SetParameterValue("@date", DateTime.Parse(_serverDateTime).ToLongDateString());
                    rptStudentGrade.SetParameterValue("@student_name", RemoteClient.ProcStatic.GetCompleteNameFullMiddleName(studentInfo.PersonInfo.LastName,
                        studentInfo.PersonInfo.FirstName, studentInfo.PersonInfo.MiddleName));
                    rptStudentGrade.SetParameterValue("@student_id", studentInfo.StudentId);
                    rptStudentGrade.SetParameterValue("@user_info", "Date/Time Printed: " + DateTime.Parse(_serverDateTime).ToShortDateString() + " " +
                        DateTime.Parse(_serverDateTime).ToShortTimeString() + "         Printed by: " +
                        RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName,
                        userInfo.PersonInfo.FirstName, userInfo.PersonInfo.MiddleName));

                    using (RemoteClient.CrystalReportViewer frmViewer = new RemoteClient.CrystalReportViewer(rptStudentGrade))
                    {
                        frmViewer.Text = "   Student Grade List";
                        frmViewer.ShowDialog();
                    }
                }
            }
            else
            {
                MessageBox.Show("The report is empty.", "Empty", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }//----------------------------

        //this procedure will print student list without filter
        public void PrintStudentList(CommonExchange.SysAccess userInfo, ToolStripProgressBar pgbBase, String schoolYearSemesterDescription)
        {
            DataTable studentTableMale = new DataTable("StudentTableMale");
            studentTableMale.Columns.Add("sysid_student_m", System.Type.GetType("System.String"));
            studentTableMale.Columns.Add("student_id_m", System.Type.GetType("System.String"));
            studentTableMale.Columns.Add("student_name_m", System.Type.GetType("System.String"));
            studentTableMale.Columns.Add("year_level_id", System.Type.GetType("System.String"));
            studentTableMale.Columns.Add("course_id", System.Type.GetType("System.String"));

            DataTable studentTableFemale = new DataTable("StudentTableFemale");
            studentTableFemale.Columns.Add("sysid_student_f", System.Type.GetType("System.String"));
            studentTableFemale.Columns.Add("student_id_f", System.Type.GetType("System.String"));
            studentTableFemale.Columns.Add("student_name_f", System.Type.GetType("System.String"));
            studentTableFemale.Columns.Add("year_level_id", System.Type.GetType("System.String"));
            studentTableFemale.Columns.Add("course_id", System.Type.GetType("System.String"));

            DataTable studentTableUnassign = new DataTable("StudentTableUnassign");
            studentTableUnassign.Columns.Add("sysid_student_u", System.Type.GetType("System.String"));
            studentTableUnassign.Columns.Add("student_id_u", System.Type.GetType("System.String"));
            studentTableUnassign.Columns.Add("student_name_u", System.Type.GetType("System.String"));
            studentTableUnassign.Columns.Add("year_level_id", System.Type.GetType("System.String"));
            studentTableUnassign.Columns.Add("course_id", System.Type.GetType("System.String"));


            if (_studentTable != null)
            {
                pgbBase.Maximum = _studentTable.Rows.Count;

                foreach (DataRow studRow in _studentTable.Rows)
                {
                    if (!String.Equals(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_group_id", String.Empty),
                        CommonExchange.CourseGroupId.GraduateSchoolDoctorate))
                    {
                        if (RemoteServerLib.ProcStatic.DataRowConvert(studRow, "gender_code_reference_flag", Byte.Parse("0")) == (Byte)CommonExchange.Sex.Male)
                        {
                            DataRow newRowM = studentTableMale.NewRow();

                            newRowM["sysid_student_m"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                            newRowM["student_id_m"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "student_id", "");
                            newRowM["student_name_m"] = RemoteClient.ProcStatic.GetCompleteNameFullMiddleName(
                                RemoteServerLib.ProcStatic.DataRowConvert(studRow, "last_name", ""),
                                RemoteServerLib.ProcStatic.DataRowConvert(studRow, "first_name", ""),
                                RemoteServerLib.ProcStatic.DataRowConvert(studRow, "middle_name", ""));

                            studentTableMale.Rows.Add(newRowM);
                        }
                        else if (RemoteServerLib.ProcStatic.DataRowConvert(studRow, "gender_code_reference_flag", Byte.Parse("0")) ==
                            (Byte)CommonExchange.Sex.Female)
                        {
                            DataRow newRowF = studentTableFemale.NewRow();

                            newRowF["sysid_student_f"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                            newRowF["student_id_f"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "student_id", "");
                            newRowF["student_name_f"] = RemoteClient.ProcStatic.GetCompleteNameFullMiddleName(
                                RemoteServerLib.ProcStatic.DataRowConvert(studRow, "last_name", ""),
                                RemoteServerLib.ProcStatic.DataRowConvert(studRow, "first_name", ""),
                                RemoteServerLib.ProcStatic.DataRowConvert(studRow, "middle_name", ""));

                            studentTableFemale.Rows.Add(newRowF);
                        }
                        else
                        {
                            DataRow newRowU = studentTableUnassign.NewRow();

                            newRowU["sysid_student_u"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                            newRowU["student_id_u"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "student_id", "");
                            newRowU["student_name_u"] = RemoteClient.ProcStatic.GetCompleteNameFullMiddleName(
                                RemoteServerLib.ProcStatic.DataRowConvert(studRow, "last_name", ""),
                                RemoteServerLib.ProcStatic.DataRowConvert(studRow, "first_name", ""),
                                RemoteServerLib.ProcStatic.DataRowConvert(studRow, "middle_name", ""));

                            studentTableUnassign.Rows.Add(newRowU);
                        }

                        pgbBase.PerformStep();
                    }
                }

                using (ClassStudentLoadingManager.CrystalReport.CrystalStudentList rptStudentList =
                    new OfficeServices.ClassStudentLoadingManager.CrystalReport.CrystalStudentList())
                {
                    rptStudentList.Database.Tables["student_table_male"].SetDataSource(studentTableMale);
                    rptStudentList.Database.Tables["student_table_female"].SetDataSource(studentTableFemale);
                    rptStudentList.Database.Tables["student_table_unassign"].SetDataSource(studentTableUnassign);

                    rptStudentList.SetParameterValue("@school_name", CommonExchange.SchoolInformation.SchoolName);
                    rptStudentList.SetParameterValue("@form_name", "Student List");
                    rptStudentList.SetParameterValue("@school_year_semester_description", schoolYearSemesterDescription);
                    rptStudentList.SetParameterValue("@print_info", "Date/Time Printed: " + DateTime.Parse(_serverDateTime).ToShortDateString() + " " +
                        DateTime.Parse(_serverDateTime).ToShortTimeString() + "         Printed by: " +
                        RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName,
                        userInfo.PersonInfo.FirstName, userInfo.PersonInfo.MiddleName));

                    using (RemoteClient.CrystalReportViewer frmViewer = new RemoteClient.CrystalReportViewer(rptStudentList))
                    {
                        frmViewer.Text = "   Student List";
                        frmViewer.ShowDialog();
                    }
                }
            }
        }//---------------------------

        //this procedure will print enrolment quick count (Summary of all students per cours/year level then separated with gender)
        public void PrintEnrolmentQuickCount(CheckedListBox lstCourse, CheckedListBox lstYearLevel,
           String schoolYearSemesterDescription, ToolStripProgressBar pgbBase, CommonExchange.SysAccess userInfo)
        {
            DataTable courseTable = new DataTable("CourseTable");
            courseTable.Columns.Add("course_id", System.Type.GetType("System.String"));
            courseTable.Columns.Add("course_title", System.Type.GetType("System.String"));
            courseTable.Columns.Add("course_acronym", System.Type.GetType("System.String"));
            courseTable.Columns.Add("department_name", System.Type.GetType("System.String"));
            courseTable.Columns.Add("department_acronym", System.Type.GetType("System.String"));

            DataTable yearLevelTable = new DataTable("YearLevelTable");
            yearLevelTable.Columns.Add("year_level_id", System.Type.GetType("System.String"));
            yearLevelTable.Columns.Add("year_level_description", System.Type.GetType("System.String"));
            yearLevelTable.Columns.Add("acronym", System.Type.GetType("System.String"));
            yearLevelTable.Columns.Add("sysid_no_of_students", System.Type.GetType("System.String"));

            DataTable studentSummaryTable = new DataTable("StudentSummaryTable");
            studentSummaryTable.Columns.Add("course", System.Type.GetType("System.String"));
            studentSummaryTable.Columns.Add("year_level", System.Type.GetType("System.String"));
            studentSummaryTable.Columns.Add("male", System.Type.GetType("System.Int32"));
            studentSummaryTable.Columns.Add("female", System.Type.GetType("System.Int32"));
            studentSummaryTable.Columns.Add("unassign", System.Type.GetType("System.Int32"));
            studentSummaryTable.Columns.Add("total", System.Type.GetType("System.Int32"));          
            studentSummaryTable.Columns.Add("bold", System.Type.GetType("System.String"));

            pgbBase.Maximum = _studentTable.Rows.Count;

            if (_classDataSet.Tables["CourseInformationTable"] != null && lstCourse.CheckedIndices.Count >= 1)
            {
                IEnumerator myEnum = lstCourse.CheckedIndices.GetEnumerator();
                Int32 x;
               
                while (myEnum.MoveNext() != false)
                {
                    x = (Int32)myEnum.Current;

                    DataRow courseRow = _classDataSet.Tables["CourseInformationTable"].Rows[x];

                    DataRow newRow = courseTable.NewRow();

                    newRow["course_id"] = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_id", "");
                    newRow["course_title"] = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_title", "");
                    newRow["course_acronym"] = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_acronym", "");
                    newRow["department_name"] = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "department_name", "");
                    newRow["department_acronym"] = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "department_acronym", "");

                    courseTable.Rows.Add(newRow);

                    pgbBase.PerformStep();
                }
            }

            if (_classDataSet.Tables["YearLevelInformationTable"] != null && lstYearLevel.CheckedIndices.Count >= 1)
            {
                IEnumerator myEnum = lstYearLevel.CheckedIndices.GetEnumerator();
                Int32 x;

                while (myEnum.MoveNext() != false)
                {
                    x = (Int32)myEnum.Current;

                    DataRow levelRow = _classDataSet.Tables["YearLevelInformationTable"].Rows[x];

                    DataRow newRow = yearLevelTable.NewRow();

                    newRow["year_level_id"] = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_id", "");
                    newRow["year_level_description"] = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_description", "");
                    newRow["acronym"] = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "acronym", "");

                    yearLevelTable.Rows.Add(newRow);

                    pgbBase.PerformStep();
                }
            }

            Int32 count = 1;

            foreach (DataRow courseRow in courseTable.Rows)
            {
                Int32 maleStudentCourse = 0;
                Int32 femaleStudentCourse = 0;
                Int32 unassignedStudentCourse = 0;

                DataRow cRow = studentSummaryTable.NewRow();

                cRow["course"] = count.ToString() + ". " + RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_title", "");

                studentSummaryTable.Rows.Add(cRow);

                count++;

                foreach (DataRow levelRow in yearLevelTable.Rows)
                {
                    String strFilter = "course_id = '" + RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_id", String.Empty) + "' " +
                        "AND year_level_id = '" + RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_id", String.Empty) + "'";
                    DataRow[] selectRow = _studentTable.Select(strFilter);

                    Int32 totalMaleStudent = 0;
                    Int32 totalFemaleStudent = 0;
                    Int32 totalUnassignedStudent = 0;

                    foreach (DataRow studRow in selectRow)
                    {
                        if (RemoteServerLib.ProcStatic.DataRowConvert(studRow, "gender_code_reference_flag", Byte.Parse("0")) == (Byte)CommonExchange.Sex.Male)
                        {
                            totalMaleStudent++;
                        }
                        else if (RemoteServerLib.ProcStatic.DataRowConvert(studRow, "gender_code_reference_flag", Byte.Parse("0")) == (Byte)CommonExchange.Sex.Female)
                        {
                            totalFemaleStudent++;
                        }
                        else
                        {
                            totalUnassignedStudent++;
                        }
                    }

                    if ((totalMaleStudent + totalFemaleStudent + totalUnassignedStudent) > 0)
                    {
                        DataRow newRow = studentSummaryTable.NewRow();

                        newRow["year_level"] = "     " + RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_description", String.Empty);
                        newRow["male"] = totalMaleStudent;
                        newRow["female"] = totalFemaleStudent;
                        newRow["unassign"] = totalUnassignedStudent;
                        newRow["total"] = (totalMaleStudent + totalFemaleStudent + totalUnassignedStudent);
                        newRow["bold"] = String.Empty;

                        studentSummaryTable.Rows.Add(newRow);

                        maleStudentCourse += totalMaleStudent;
                        femaleStudentCourse += totalFemaleStudent;
                        unassignedStudentCourse = totalUnassignedStudent;
                    }

                    pgbBase.PerformStep();
                }

                DataRow newRowT = studentSummaryTable.NewRow();

                newRowT["year_level"] = "               Sub Total:";
                newRowT["male"] = maleStudentCourse;
                newRowT["female"] = femaleStudentCourse;
                newRowT["unassign"] = unassignedStudentCourse;
                newRowT["total"] = (maleStudentCourse + femaleStudentCourse + unassignedStudentCourse);
                newRowT["bold"] = "<b>";

                studentSummaryTable.Rows.Add(newRowT);
            }

            using (ClassStudentLoadingManager.CrystalReport.CrystalEnrollmentQuickCount rptStudentEnrolledQuickCount =
                new OfficeServices.ClassStudentLoadingManager.CrystalReport.CrystalEnrollmentQuickCount())
            {
                //rptStudentEnrolledQuickCount.Database.Tables["year_level_table"].SetDataSource(yearLevelTable);
                //rptStudentEnrolledQuickCount.Database.Tables["course_table"].SetDataSource(courseTable);
                rptStudentEnrolledQuickCount.Database.Tables["student_summary_table"].SetDataSource(studentSummaryTable);

                rptStudentEnrolledQuickCount.SetParameterValue("@school_name", CommonExchange.SchoolInformation.SchoolName);
                rptStudentEnrolledQuickCount.SetParameterValue("@address", CommonExchange.SchoolInformation.Address);
                rptStudentEnrolledQuickCount.SetParameterValue("@form_name", "Summary of Enrolment");
                rptStudentEnrolledQuickCount.SetParameterValue("@school_year_semester", schoolYearSemesterDescription);
                rptStudentEnrolledQuickCount.SetParameterValue("@print_info", "Date/Time Printed: " + DateTime.Parse(_serverDateTime).ToShortDateString() + " " +
                    DateTime.Parse(_serverDateTime).ToShortTimeString() + "         Printed by: " +
                    RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName,
                    userInfo.PersonInfo.FirstName, userInfo.PersonInfo.MiddleName));

                using (RemoteClient.CrystalReportViewer frmViewer = new RemoteClient.CrystalReportViewer(rptStudentEnrolledQuickCount))
                {
                    frmViewer.Text = "   Summary of Enrollment";
                    frmViewer.ShowDialog();
                }
            }
        }//-----------------------

        //this procedure will print student master list per course and year level
        public void PrintStudentMasterList(CheckedListBox lstCourse, CheckedListBox lstYearLevel,
            String schoolYearSemesterDescription, ToolStripProgressBar pgbBase, CommonExchange.SysAccess userInfo)
        {
            DataTable courseTable = new DataTable("CourseTable");
            courseTable.Columns.Add("course_id", System.Type.GetType("System.String"));
            courseTable.Columns.Add("course_title", System.Type.GetType("System.String"));
            courseTable.Columns.Add("course_acronym", System.Type.GetType("System.String"));
            courseTable.Columns.Add("department_name", System.Type.GetType("System.String"));
            courseTable.Columns.Add("department_acronym", System.Type.GetType("System.String"));

            DataTable yearLevelTable = new DataTable("YearLevelTable");
            yearLevelTable.Columns.Add("year_level_id", System.Type.GetType("System.String"));
            yearLevelTable.Columns.Add("year_level_description", System.Type.GetType("System.String"));
            yearLevelTable.Columns.Add("acronym", System.Type.GetType("System.String"));
            yearLevelTable.Columns.Add("sysid_no_of_students", System.Type.GetType("System.String"));
           
            DataTable studentTableMale = new DataTable("StudentTableMale");
            studentTableMale.Columns.Add("sysid_student_m", System.Type.GetType("System.String"));
            studentTableMale.Columns.Add("student_id_m", System.Type.GetType("System.String"));
            studentTableMale.Columns.Add("student_name_m", System.Type.GetType("System.String"));
            studentTableMale.Columns.Add("year_level_id", System.Type.GetType("System.String"));
            studentTableMale.Columns.Add("course_id", System.Type.GetType("System.String"));

            DataTable studentTableFemale = new DataTable("StudentTableFemale");
            studentTableFemale.Columns.Add("sysid_student_f", System.Type.GetType("System.String"));
            studentTableFemale.Columns.Add("student_id_f", System.Type.GetType("System.String"));
            studentTableFemale.Columns.Add("student_name_f", System.Type.GetType("System.String"));
            studentTableFemale.Columns.Add("year_level_id", System.Type.GetType("System.String"));
            studentTableFemale.Columns.Add("course_id", System.Type.GetType("System.String"));

            DataTable studentTableUnassign = new DataTable("StudentTableUnassign");
            studentTableUnassign.Columns.Add("sysid_student_u", System.Type.GetType("System.String"));
            studentTableUnassign.Columns.Add("student_id_u", System.Type.GetType("System.String"));
            studentTableUnassign.Columns.Add("student_name_u", System.Type.GetType("System.String"));
            studentTableUnassign.Columns.Add("year_level_id", System.Type.GetType("System.String"));
            studentTableUnassign.Columns.Add("course_id", System.Type.GetType("System.String"));

            DataTable noOfStudentTable = new DataTable("NoOfStudentTable");
            noOfStudentTable.Columns.Add("course_id", System.Type.GetType("System.String"));
            noOfStudentTable.Columns.Add("year_level_id", System.Type.GetType("System.String"));
            noOfStudentTable.Columns.Add("no_of_students", System.Type.GetType("System.String"));

            pgbBase.Maximum = _studentTable.Rows.Count + lstCourse.CheckedIndices.Count + lstYearLevel.CheckedIndices.Count;

            if (_studentTable != null)
            {
                foreach (DataRow studRow in _studentTable.Rows)
                {
                    if (RemoteServerLib.ProcStatic.DataRowConvert(studRow, "gender_code_reference_flag", Byte.Parse("0")) == (Byte)CommonExchange.Sex.Male)
                    {
                        DataRow newRowM = studentTableMale.NewRow();

                        newRowM["sysid_student_m"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                        newRowM["student_id_m"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "student_id", "");
                        newRowM["student_name_m"] = RemoteClient.ProcStatic.GetCompleteNameFullMiddleName(
                            RemoteServerLib.ProcStatic.DataRowConvert(studRow, "last_name", ""),
                            RemoteServerLib.ProcStatic.DataRowConvert(studRow, "first_name", ""),
                            RemoteServerLib.ProcStatic.DataRowConvert(studRow, "middle_name", ""));
                        newRowM["year_level_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_level_id", "");
                        newRowM["course_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_id", "");

                        studentTableMale.Rows.Add(newRowM);
                    }
                    else if (RemoteServerLib.ProcStatic.DataRowConvert(studRow, "gender_code_reference_flag", Byte.Parse("0")) == 
                        (Byte)CommonExchange.Sex.Female)
                    {
                        DataRow newRowF = studentTableFemale.NewRow();

                        newRowF["sysid_student_f"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                        newRowF["student_id_f"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "student_id", "");
                        newRowF["student_name_f"] = RemoteClient.ProcStatic.GetCompleteNameFullMiddleName(
                            RemoteServerLib.ProcStatic.DataRowConvert(studRow, "last_name", ""),
                            RemoteServerLib.ProcStatic.DataRowConvert(studRow, "first_name", ""),
                            RemoteServerLib.ProcStatic.DataRowConvert(studRow, "middle_name", ""));
                        newRowF["year_level_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_level_id", "");
                        newRowF["course_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_id", "");

                        studentTableFemale.Rows.Add(newRowF);
                    }
                    else
                    {
                        DataRow newRowU = studentTableUnassign.NewRow();

                        newRowU["sysid_student_u"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                        newRowU["student_id_u"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "student_id", "");
                        newRowU["student_name_u"] = RemoteClient.ProcStatic.GetCompleteNameFullMiddleName(
                            RemoteServerLib.ProcStatic.DataRowConvert(studRow, "last_name", ""),
                            RemoteServerLib.ProcStatic.DataRowConvert(studRow, "first_name", ""),
                            RemoteServerLib.ProcStatic.DataRowConvert(studRow, "middle_name", ""));
                        newRowU["year_level_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_level_id", "");
                        newRowU["course_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_id", "");

                        studentTableUnassign.Rows.Add(newRowU);
                    }

                    pgbBase.PerformStep();
                }
            }

            if (_classDataSet.Tables["CourseInformationTable"] != null && lstCourse.CheckedIndices.Count >= 1)
            {
                IEnumerator myEnum = lstCourse.CheckedIndices.GetEnumerator();
                Int32 x;

                while (myEnum.MoveNext() != false)
                {
                    x = (Int32)myEnum.Current;

                    DataRow courseRow = _classDataSet.Tables["CourseInformationTable"].Rows[x];

                    DataRow newRow = courseTable.NewRow();

                    newRow["course_id"] = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_id", "");
                    newRow["course_title"] = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_title", "");
                    newRow["course_acronym"] = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_acronym", "");
                    newRow["department_name"] = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "department_name", "");
                    newRow["department_acronym"] = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "department_acronym", "");

                    courseTable.Rows.Add(newRow);

                    pgbBase.PerformStep();
                }
            }

            if (_classDataSet.Tables["YearLevelInformationTable"] != null && lstYearLevel.CheckedIndices.Count >= 1)
            {
                IEnumerator myEnum = lstYearLevel.CheckedIndices.GetEnumerator();
                Int32 x;

                while (myEnum.MoveNext() != false)
                {
                    x = (Int32)myEnum.Current;

                    DataRow levelRow = _classDataSet.Tables["YearLevelInformationTable"].Rows[x];

                    DataRow newRow = yearLevelTable.NewRow();

                    newRow["year_level_id"] = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_id", "");
                    newRow["year_level_description"] = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_description", "");
                    newRow["acronym"] = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "acronym", "");

                    yearLevelTable.Rows.Add(newRow);

                    pgbBase.PerformStep();
                }
            }

            foreach (DataRow courseRow in courseTable.Rows)
            {
                foreach (DataRow levelRow in yearLevelTable.Rows)
                {
                    String strFilter = "course_id = '" + RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_id", String.Empty) + "' " +
                        "AND year_level_id = '" + RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_id", String.Empty) + "'";
                    DataRow[] selectRow = _studentTable.Select(strFilter);

                    DataRow newRow = noOfStudentTable.NewRow();

                   newRow["course_id"] = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_id", String.Empty);
                   newRow["year_level_id"] = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_id", String.Empty);
                   newRow["no_of_students"] = "No. of students: " + selectRow.Length.ToString();

                   noOfStudentTable.Rows.Add(newRow);
               }
            }

            using (ClassStudentLoadingManager.CrystalReport.CrystalStudentMasterList rptStudentMasterList =
                new OfficeServices.ClassStudentLoadingManager.CrystalReport.CrystalStudentMasterList())
            {
                rptStudentMasterList.Database.Tables["year_level_table"].SetDataSource(yearLevelTable);
                rptStudentMasterList.Database.Tables["course_table"].SetDataSource(courseTable);
                rptStudentMasterList.Database.Tables["student_table_male"].SetDataSource(studentTableMale);
                rptStudentMasterList.Database.Tables["student_table_female"].SetDataSource(studentTableFemale);
                rptStudentMasterList.Database.Tables["student_table_unassign"].SetDataSource(studentTableUnassign);
                rptStudentMasterList.Database.Tables["no_of_student_table"].SetDataSource(noOfStudentTable);

                rptStudentMasterList.SetParameterValue("@school_name", CommonExchange.SchoolInformation.SchoolName);
                rptStudentMasterList.SetParameterValue("@form_name", "Master List");
                rptStudentMasterList.SetParameterValue("@school_year_semester_description", schoolYearSemesterDescription);
                rptStudentMasterList.SetParameterValue("@print_info", "Date/Time Printed: " + DateTime.Parse(_serverDateTime).ToShortDateString() + " " +
                    DateTime.Parse(_serverDateTime).ToShortTimeString() + "         Printed by: " +
                    RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName, 
                    userInfo.PersonInfo.FirstName, userInfo.PersonInfo.MiddleName));
                
                using (RemoteClient.CrystalReportViewer frmViewer = new RemoteClient.CrystalReportViewer(rptStudentMasterList))
                {
                    frmViewer.Text = "   Master List";
                    frmViewer.ShowDialog();
                }
            }
        }//-------------------------------

        //this procedure will print student master list per course and year level
        public void PrintStudentInsuranceList(CommonExchange.SysAccess userInfo, ToolStripProgressBar pgbBase, String schoolYearSemesterDescription)
        {
            DataTable studentTable = new DataTable("StudentTable");
            studentTable.Columns.Add("num_count", System.Type.GetType("System.String"));
            studentTable.Columns.Add("last_name", System.Type.GetType("System.String"));
            studentTable.Columns.Add("first_name", System.Type.GetType("System.String"));
            studentTable.Columns.Add("middle_name", System.Type.GetType("System.String"));
            studentTable.Columns.Add("date_of_birth", System.Type.GetType("System.String"));
            studentTable.Columns.Add("beneficiary", System.Type.GetType("System.String"));

            if (_studentTable != null)
            {
                pgbBase.Maximum = _studentTable.Rows.Count;

                Int32 count = 1;

                foreach (DataRow studRow in _studentTable.Rows)
                {
                    DataRow newRow = studentTable.NewRow();

                    newRow["num_count"] = count.ToString() + ".";
                    newRow["last_name"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "last_name", String.Empty);
                    newRow["first_name"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "first_name", String.Empty);
                    newRow["middle_name"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "middle_name", String.Empty);

                    String dateOfBirth = String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "birthdate_string", String.Empty)) ? String.Empty :
                        DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "birthdate_string", String.Empty)).ToShortDateString();

                    newRow["date_of_birth"] = dateOfBirth;

                    String beneficiary = String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "emer_last_name", String.Empty)) ? String.Empty :
                        RemoteClient.ProcStatic.GetCompleteNameFullMiddleName(studRow, "emer_last_name", "emer_first_name", "emer_middle_name");

                    newRow["beneficiary"] = beneficiary;

                    studentTable.Rows.Add(newRow);

                    count++;

                    pgbBase.PerformStep();
                }

                using (ClassStudentLoadingManager.CrystalReport.CrystalStudentInsuranceList rptStudentList =
                    new OfficeServices.ClassStudentLoadingManager.CrystalReport.CrystalStudentInsuranceList())
                {
                    rptStudentList.Database.Tables["student_table"].SetDataSource(studentTable);

                    rptStudentList.SetParameterValue("@school_name", CommonExchange.SchoolInformation.SchoolName);
                    rptStudentList.SetParameterValue("@form_name", "Student List");
                    rptStudentList.SetParameterValue("@school_year_semester_description", schoolYearSemesterDescription);
                    rptStudentList.SetParameterValue("@form_code", "SEC-REC-32000-59-00");
                    rptStudentList.SetParameterValue("@prepared_by", RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName,
                        userInfo.PersonInfo.FirstName, userInfo.PersonInfo.MiddleName));
                    rptStudentList.SetParameterValue("@school_registrar", CommonExchange.SchoolInformation.UniversityRegistrar);
                    rptStudentList.SetParameterValue("@print_info", "Date/Time Printed: " + DateTime.Parse(_serverDateTime).ToShortDateString() + " " +
                        DateTime.Parse(_serverDateTime).ToShortTimeString() + "         Printed by: " +
                        RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName,
                        userInfo.PersonInfo.FirstName, userInfo.PersonInfo.MiddleName));

                    using (RemoteClient.CrystalReportViewer frmViewer = new RemoteClient.CrystalReportViewer(rptStudentList))
                    {
                        frmViewer.Text = "   Student List";
                        frmViewer.ShowDialog();
                    }
                }
            }
        }//-------------------------------

        //this procedure will print student list
        public void PrintStudentEnrolmentList(CommonExchange.SysAccess userInfo, CheckedListBox lstCourse, CheckedListBox lstYearLevel,
            ToolStripProgressBar pgbBase, String schoolYearSemesterDescription, String dateStart, String dateEnd)
        {
            DataTable printingSubjectScheduleTable;
            //DataTable printingScheduleDetails;
            DataTable printingSpecialClassTable;

            //tables of printing
            DataTable pStudentTable = new DataTable("StudentTable");           
            pStudentTable.Columns.Add("no", System.Type.GetType("System.Int32"));
            pStudentTable.Columns.Add("last_name", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("first_name", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("middle_name", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("gender", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("student_id", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("course_title", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("year_level_description", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("sysid_student", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("course_group_id", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("year_level_id", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("course_id", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("subject_code", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("subject_lecture_units", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("subject_lab_units", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("subject_no_hours", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("subject_no_hours_string", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("line_row", System.Type.GetType("System.String"));

            DataTable courseTable = new DataTable("CourseTable");
            courseTable.Columns.Add("course_id", System.Type.GetType("System.String"));
            courseTable.Columns.Add("course_title", System.Type.GetType("System.String"));
            courseTable.Columns.Add("course_acronym", System.Type.GetType("System.String"));
            courseTable.Columns.Add("department_name", System.Type.GetType("System.String"));

            DataTable yearLevelTable = new DataTable("YearLevelTable");
            yearLevelTable.Columns.Add("year_level_id", System.Type.GetType("System.String"));
            yearLevelTable.Columns.Add("year_level_description", System.Type.GetType("System.String"));
            yearLevelTable.Columns.Add("acronym", System.Type.GetType("System.String"));

            DataTable courseLevelTable = new DataTable("CourseLevelTable");
            courseLevelTable.Columns.Add("course_id", System.Type.GetType("System.String"));
            courseLevelTable.Columns.Add("course_title", System.Type.GetType("System.String"));
            courseLevelTable.Columns.Add("year_level_id", System.Type.GetType("System.String"));
            courseLevelTable.Columns.Add("year_level_description", System.Type.GetType("System.String"));
            //------------------------

            pgbBase.Maximum = _studentTable.Rows.Count + lstCourse.CheckedIndices.Count + lstYearLevel.CheckedIndices.Count;

            if (_classDataSet.Tables["CourseInformationTable"] != null && lstCourse.CheckedIndices.Count >= 1)
            {
                IEnumerator myEnum = lstCourse.CheckedIndices.GetEnumerator();
                Int32 x;

                while (myEnum.MoveNext() != false)
                {
                    x = (Int32)myEnum.Current;

                    DataRow courseRow = _classDataSet.Tables["CourseInformationTable"].Rows[x];

                    DataRow newRow = courseTable.NewRow();

                    newRow["course_id"] = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_id", "");
                    newRow["course_title"] = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_title", "");
                    newRow["course_acronym"] = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_acronym", "");
                    newRow["department_name"] = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "department_name", "");

                    courseTable.Rows.Add(newRow);

                    pgbBase.PerformStep();
                }
            }

            if (_classDataSet.Tables["YearLevelInformationTable"] != null && lstYearLevel.CheckedIndices.Count >= 1)
            {
                IEnumerator myEnum = lstYearLevel.CheckedIndices.GetEnumerator();
                Int32 x;

                while (myEnum.MoveNext() != false)
                {
                    x = (Int32)myEnum.Current;

                    DataRow levelRow = _classDataSet.Tables["YearLevelInformationTable"].Rows[x];

                    DataRow newRow = yearLevelTable.NewRow();

                    newRow["year_level_id"] = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_id", "");
                    newRow["year_level_description"] = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_description", "");
                    newRow["acronym"] = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "acronym", "");

                    yearLevelTable.Rows.Add(newRow);

                    pgbBase.PerformStep();
                }
            }

            using (RemoteClient.RemCntStudentLoadingManager remClient = new RemoteClient.RemCntStudentLoadingManager())
            {
                printingSubjectScheduleTable = remClient.SelectBySysIDEnrolmentLevelListSubjectScheduleStudentLoad(userInfo,
                    this.GetStudentEnrolmentLevelFormat(), _serverDateTime);
            }

            using (RemoteClient.RemCntSpecialClassManager remClient = new RemoteClient.RemCntSpecialClassManager())
            {
                printingSpecialClassTable = remClient.SelectBySysIDStudentListDateStartEndSpecialClassInformation(userInfo,
                    this.GetStudentSystemIdFormat(), dateStart, dateEnd, this.ServerDateTime);
            }

            if (_studentTable != null)
            {                
                //--------------------- DON'T DELETE THIS CODE BLACK ------------------------------
                //--->Code is used durin S.Y. 2009 - 2010 as a requirements for ched enrolment list
                //--->this is using crystal report (CrystalEnrolmentListForRegistrar)
                //
                //foreach (DataRow courseRow in courseTable.Rows)
                //{
                //    foreach (DataRow levelRow in yearLevelTable.Rows)
                //    {
                //        Int32 count = 1;

                //        String strFilter = "course_id = '" + RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_id", String.Empty) + "' " +
                //            "AND year_level_id = '" + RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_id", String.Empty) + "'";
                //        DataRow[] selectRow = _studentTable.Select(strFilter, "gender_code_reference_flag ASC");                        

                //        foreach (DataRow studRow in selectRow)
                //        {
                //            if (studRow.RowState != DataRowState.Deleted &&
                //                (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_enrolmentlevel", "")) &&
                //                !String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_description", ""))))
                //            {
                //                Int32 totalNoHours = 0;
                //                Byte totalLecUnnits = 0;
                //                Byte totalLabUnits = 0;

                //                String strFilterSched = "sysid_enrolmentlevel = '" + 
                //                    RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_enrolmentlevel", "") + "'";
                //                DataRow[] selectSubjectSchedule = printingSubjectScheduleTable.Select(strFilterSched);

                //                foreach (DataRow subRow in selectSubjectSchedule)
                //                {
                //                    if (subRow.RowState != DataRowState.Deleted)
                //                    {
                //                        DateTime noHours = DateTime.MinValue;

                //                        if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_no_hours", ""), out noHours))
                //                        {
                //                            totalNoHours += noHours.Minute + (noHours.Hour * 60);
                //                        }

                //                        DataRow newRow = pStudentTable.NewRow();

                //                        newRow["no"] = count;
                //                        newRow["last_name"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "last_name", "");
                //                        newRow["first_name"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "first_name", "");
                //                        newRow["middle_name"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "middle_name", "");
                //                        newRow["gender"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "gender_code_code_description", "");
                //                        newRow["student_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "student_id", "");
                //                        newRow["course_title"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_title", "");
                //                        newRow["year_level_description"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_level_description", "");
                //                        newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                //                        newRow["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_group_id", "");
                //                        newRow["year_level_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_level_id", "");
                //                        newRow["course_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_id", "");

                //                        newRow["subject_code"] = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_code", "");
                //                        newRow["subject_lecture_units"] = RemoteServerLib.ProcStatic.DataRowConvert(subRow,
                //                            "subject_lecture_units", Byte.Parse("0"));
                //                        newRow["subject_lab_units"] = RemoteServerLib.ProcStatic.DataRowConvert(subRow,
                //                            "subject_lab_units", Byte.Parse("0"));
                //                        newRow["subject_no_hours_string"] = RemoteServerLib.ProcStatic.DataRowConvert(subRow,
                //                            "subject_no_hours", "");

                //                        totalLecUnnits += RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_lecture_units", Byte.Parse("0"));
                //                        totalLabUnits += RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_lab_units", Byte.Parse("0"));

                //                        pStudentTable.Rows.Add(newRow);

                //                        pgbBase.PerformStep();
                //                    }                                       
                //                }

                //                String strFilterSpecialClass = "sysid_student = '" + RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", String.Empty) + "'";
                //                DataRow[] selectSpecialClassRow = printingSpecialClassTable.Select(strFilterSpecialClass);

                //                if (selectSubjectSchedule.Length == 0 && selectSpecialClassRow.Length == 0)
                //                {
                //                    DataRow newRow = pStudentTable.NewRow();

                //                    newRow["no"] = count;
                //                    newRow["last_name"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "last_name", "");
                //                    newRow["first_name"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "first_name", "");
                //                    newRow["middle_name"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "middle_name", "");
                //                    newRow["gender"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "gender_code_code_description", "");
                //                    newRow["student_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "student_id", "");
                //                    newRow["course_title"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_title", "");
                //                    newRow["year_level_description"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_level_description", "");
                //                    newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                //                    newRow["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_group_id", "");
                //                    newRow["year_level_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_level_id", "");
                //                    newRow["course_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_id", "");

                //                    pStudentTable.Rows.Add(newRow);

                //                    pgbBase.PerformStep();
                //                }

                //                foreach (DataRow specialRow in selectSpecialClassRow)
                //                {
                //                    if (specialRow.RowState != DataRowState.Deleted)
                //                    {
                //                        DateTime noHours = DateTime.MinValue;

                //                        if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_no_hours", ""), out noHours))
                //                        {
                //                            totalNoHours += noHours.Minute + (noHours.Hour * 60);
                //                        }

                //                        DataRow newRow = pStudentTable.NewRow();

                //                        newRow["no"] = count;
                //                        newRow["last_name"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "last_name", "");
                //                        newRow["first_name"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "first_name", "");
                //                        newRow["middle_name"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "middle_name", "");
                //                        newRow["gender"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "gender_code_code_description", "");
                //                        newRow["student_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "student_id", "");
                //                        newRow["course_title"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_title", "");
                //                        newRow["year_level_description"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_level_description", "");
                //                        newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                //                        newRow["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_group_id", "");
                //                        newRow["year_level_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_level_id", "");
                //                        newRow["course_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_id", "");

                //                        newRow["subject_code"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_code", "");
                //                        newRow["subject_lecture_units"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow,
                //                            "subject_lecture_units", Byte.Parse("0"));
                //                        newRow["subject_lab_units"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow,
                //                            "subject_lab_units", Byte.Parse("0"));
                //                        newRow["subject_no_hours_string"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow,
                //                            "subject_no_hours", "");

                //                        totalLecUnnits += RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_lecture_units", Byte.Parse("0"));
                //                        totalLabUnits += RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_lab_units", Byte.Parse("0"));

                //                        pStudentTable.Rows.Add(newRow);
                //                    }
                //                }

                //                count++;

                //                DataRow newRowSmallLine = pStudentTable.NewRow();

                //                newRowSmallLine["year_level_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_level_id", "");
                //                newRowSmallLine["course_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_id", "");
                //                newRowSmallLine["subject_lecture_units"] = "_________________________";
                //                newRowSmallLine["subject_lab_units"] = "_________________________";
                //                newRowSmallLine["subject_no_hours_string"] = "_________________________"; ;

                //                pStudentTable.Rows.Add(newRowSmallLine);

                //                DataRow newRowTotal = pStudentTable.NewRow();

                //                newRowTotal["year_level_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_level_id", "");
                //                newRowTotal["course_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_id", "");
                //                newRowTotal["subject_code"] = "    Total";
                //                newRowTotal["subject_lecture_units"] = totalLecUnnits.ToString();
                //                newRowTotal["subject_lab_units"] = totalLabUnits.ToString();
                //                newRowTotal["subject_no_hours_string"] = totalNoHours.ToString();

                //                pStudentTable.Rows.Add(newRowTotal);

                //                DataRow newRowBigLine = pStudentTable.NewRow();

                //                newRowBigLine["year_level_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_level_id", "");
                //                newRowBigLine["course_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_id", "");
                //                newRowBigLine["line_row"] = "_____________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________________";

                //                pStudentTable.Rows.Add(newRowBigLine);
                //            }
                //        }
                //    }
                //}

                //using (ClassStudentLoadingManager.CrystalReport.CrystalEnrolmentListForRegistrar rptEnrolmentList =
                //    new OfficeServices.ClassStudentLoadingManager.CrystalReport.CrystalEnrolmentListForRegistrar())
                //{
                //    rptEnrolmentList.Database.Tables["year_level_table"].SetDataSource(yearLevelTable);
                //    rptEnrolmentList.Database.Tables["course_table"].SetDataSource(courseTable);
                //    rptEnrolmentList.Database.Tables["student_table"].SetDataSource(pStudentTable);

                //    rptEnrolmentList.SetParameterValue("@school_name", CommonExchange.SchoolInformation.SchoolName);
                //    rptEnrolmentList.SetParameterValue("@address", CommonExchange.SchoolInformation.Address);
                //    rptEnrolmentList.SetParameterValue("@institutional_indentifier", CommonExchange.SchoolInformation.InstitutionalIdentifier);
                //    rptEnrolmentList.SetParameterValue("@school_year_semester", schoolYearSemesterDescription);
                //    rptEnrolmentList.SetParameterValue("@tel_no", CommonExchange.SchoolInformation.PhoneNos);

                //    using (RemoteClient.CrystalReportViewer frmViewer = new RemoteClient.CrystalReportViewer(rptEnrolmentList))
                //    {
                //        frmViewer.Text = "   Enrolment List";
                //        frmViewer.ShowDialog();
                //    }
                //}
                //--------------------- DON'T DELETE THIS CODE BLACK ------------------------------

                //-->this code blace is for ched requirements for S.Y. 2010 - 2011 for student enrolment list
                foreach (DataRow courseRow in courseTable.Rows)
                {
                    foreach (DataRow levelRow in yearLevelTable.Rows)
                    {
                        Int32 count = 1;

                        String strFilter = "course_id = '" + RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_id", String.Empty) + "' " +
                            "AND year_level_id = '" + RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_id", String.Empty) + "'";
                        DataRow[] selectRow = _studentTable.Select(strFilter, "gender_code_reference_flag ASC");

                        if (selectRow.Length > 0)
                        {
                            foreach (DataRow studRow in selectRow)
                            {
                                Int32 noOfUnits = 0;
                                String strSubjectsEnrolled = String.Empty;

                                if (studRow.RowState != DataRowState.Deleted &&
                                    (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_enrolmentlevel", "")) &&
                                    !String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_description", ""))))
                                {
                                    String strFilterSched = "sysid_enrolmentlevel = '" +
                                        RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_enrolmentlevel", "") + "'";
                                    DataRow[] selectSubjectSchedule = printingSubjectScheduleTable.Select(strFilterSched);

                                    foreach (DataRow subRow in selectSubjectSchedule)
                                    {
                                        if (subRow.RowState != DataRowState.Deleted)
                                        {
                                            strSubjectsEnrolled += RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_code", "") + ", ";
                                            noOfUnits += RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_lecture_units", Byte.Parse("0"));
                                        }
                                    }

                                    String strFilterSpecialClass = "sysid_student = '" + RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", String.Empty) + "'";
                                    DataRow[] selectSpecialClassRow = printingSpecialClassTable.Select(strFilterSpecialClass);

                                    foreach (DataRow specialRow in selectSpecialClassRow)
                                    {
                                        if (specialRow.RowState != DataRowState.Deleted)
                                        {
                                            strSubjectsEnrolled += RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_code", "") + ", ";
                                            noOfUnits += RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_lecture_units", Byte.Parse("0"));
                                        }
                                    }

                                    DataRow newRow = pStudentTable.NewRow();

                                    newRow["no"] = count;
                                    newRow["last_name"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "last_name", "");
                                    newRow["first_name"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "first_name", "");
                                    newRow["middle_name"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "middle_name", "");
                                    newRow["gender"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "gender_code_code_description", "");
                                    newRow["student_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "student_id", "");
                                    newRow["course_title"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_title", "");
                                    newRow["year_level_description"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_level_description", "");
                                    newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                                    newRow["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_group_id", "");
                                    newRow["year_level_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_level_id", "");
                                    newRow["course_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_id", "");

                                    String strSubCode = strSubjectsEnrolled.Length > 2 ? strSubjectsEnrolled.Remove(strSubjectsEnrolled.Length - 2, 2) : strSubjectsEnrolled;

                                    newRow["subject_code"] = strSubCode;
                                    newRow["subject_lecture_units"] = noOfUnits.ToString();

                                    pStudentTable.Rows.Add(newRow);

                                    pgbBase.PerformStep();

                                    count++;
                                }
                            }

                            DataRow newCourseLevelRow = courseLevelTable.NewRow();

                            newCourseLevelRow["course_id"] = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_id", String.Empty);
                            newCourseLevelRow["course_title"] = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_title", String.Empty);
                            newCourseLevelRow["year_level_id"] = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_id", String.Empty);
                            newCourseLevelRow["year_level_description"] = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_description", String.Empty);

                            courseLevelTable.Rows.Add(newCourseLevelRow);
                        }

                    }
                }

                pStudentTable.AcceptChanges();

                using (ClassStudentLoadingManager.CrystalReport.CrystalEnrolmentListForRegistrarVersion2 rptEnrolmentList =
                    new OfficeServices.ClassStudentLoadingManager.CrystalReport.CrystalEnrolmentListForRegistrarVersion2())
                {
                    rptEnrolmentList.Database.Tables["course_level_table"].SetDataSource(courseLevelTable);
                    rptEnrolmentList.Database.Tables["student_table"].SetDataSource(pStudentTable);

                    rptEnrolmentList.SetParameterValue("@school_name", CommonExchange.SchoolInformation.SchoolName);
                    rptEnrolmentList.SetParameterValue("@address", CommonExchange.SchoolInformation.Address);
                    rptEnrolmentList.SetParameterValue("@institutional_indentifier", CommonExchange.SchoolInformation.InstitutionalIdentifier);
                    rptEnrolmentList.SetParameterValue("@school_year_semester", schoolYearSemesterDescription);
                    rptEnrolmentList.SetParameterValue("@tel_no", CommonExchange.SchoolInformation.PhoneNos);
                    rptEnrolmentList.SetParameterValue("@correctedby", CommonExchange.SchoolInformation.UniversityRegistrar);

                    using (RemoteClient.CrystalReportViewer frmViewer = new RemoteClient.CrystalReportViewer(rptEnrolmentList))
                    {
                        frmViewer.Text = "   Enrolment List";
                        frmViewer.ShowDialog();
                    }
                }                
            }
        }//-------------------------------------

        ////this procedure will print student statement of account
        //public void PrintStudentStatementOfAccount(CommonExchange.SysAccess userInfo, DataTable studentTable, String dateStar,
        //    String dateEnd, String dateEnding, ToolStripProgressBar pgbBase, Boolean isSummer)
        //{
        //    pgbBase.Style = ProgressBarStyle.Marquee;

        //    DataTable printingSubjectScheduleTable;
        //    DataTable printingScheduleDetails;
        //    DataTable printingSchoolFeeDetailsTable;
        //    DataTable paymentDiscountReimbursementTable;
        //    DataTable balanceForwardedTable;

        //    //tables of printing
        //    DataTable pStudentTable = new DataTable("StudentTable");
        //    pStudentTable.Columns.Add("student_name", System.Type.GetType("System.String"));
        //    pStudentTable.Columns.Add("student_id", System.Type.GetType("System.String"));
        //    pStudentTable.Columns.Add("course_title", System.Type.GetType("System.String"));
        //    pStudentTable.Columns.Add("year_level_description", System.Type.GetType("System.String"));
        //    pStudentTable.Columns.Add("sysid_enrolmentlevel", System.Type.GetType("System.String"));
        //    pStudentTable.Columns.Add("sysid_student", System.Type.GetType("System.String"));
        //    pStudentTable.Columns.Add("year_Semester_description", System.Type.GetType("System.String"));
        //    pStudentTable.Columns.Add("notes", System.Type.GetType("System.String"));
        //    pStudentTable.Columns.Add("course_group_id", System.Type.GetType("System.String"));

        //    DataTable pSubjecScheduleTable = new DataTable("ScheduleDetailsTable");
        //    pSubjecScheduleTable.Columns.Add("day_time", System.Type.GetType("System.String"));
        //    pSubjecScheduleTable.Columns.Add("room", System.Type.GetType("System.String"));
        //    pSubjecScheduleTable.Columns.Add("section", System.Type.GetType("System.String"));
        //    pSubjecScheduleTable.Columns.Add("instructor", System.Type.GetType("System.String"));
        //    pSubjecScheduleTable.Columns.Add("sysid_enrolmentlevel", System.Type.GetType("System.String"));
        //    pSubjecScheduleTable.Columns.Add("subject_code_title", System.Type.GetType("System.String"));
        //    pSubjecScheduleTable.Columns.Add("subject_lecture_units", System.Type.GetType("System.String"));
        //    pSubjecScheduleTable.Columns.Add("subject_lab_units", System.Type.GetType("System.String"));
        //    pSubjecScheduleTable.Columns.Add("subject_no_hours", System.Type.GetType("System.String"));

        //    DataTable chargesSummaryTable = new DataTable("ChargesSummaryTable");
        //    chargesSummaryTable.Columns.Add("sysid_student", System.Type.GetType("System.String"));
        //    chargesSummaryTable.Columns.Add("charges_description", System.Type.GetType("System.String"));
        //    chargesSummaryTable.Columns.Add("text_balance", System.Type.GetType("System.String"));
        //    chargesSummaryTable.Columns.Add("amount", System.Type.GetType("System.String"));
        //    chargesSummaryTable.Columns.Add("total_amount", System.Type.GetType("System.String"));

        //    DataTable examTable = new DataTable("ExamTable");
        //    examTable.Columns.Add("exam_id", System.Type.GetType("System.Int64"));
        //    examTable.Columns.Add("exam_date", System.Type.GetType("System.String"));
        //    examTable.Columns.Add("exam_description", System.Type.GetType("System.String"));
        //    examTable.Columns.Add("course_group_id", System.Type.GetType("System.String"));

        //    DataTable amountDueTable = new DataTable("AmountDueTable");
        //    amountDueTable.Columns.Add("exam_id", System.Type.GetType("System.Int64"));
        //    amountDueTable.Columns.Add("amount_due", System.Type.GetType("System.Decimal"));
        //    amountDueTable.Columns.Add("sysid_student", System.Type.GetType("System.String"));

        //    //create temporary table for payment reimbursement table
        //    DataTable paymentReimbursementTableTemp = new DataTable("TemporaryTable");
        //    paymentReimbursementTableTemp.Columns.Add("payment_discount_reimbursement_id", System.Type.GetType("System.String"));
        //    paymentReimbursementTableTemp.Columns.Add("sysid_student", System.Type.GetType("System.String"));
        //    paymentReimbursementTableTemp.Columns.Add("reflected_date", System.Type.GetType("System.DateTime"));
        //    paymentReimbursementTableTemp.Columns.Add("amount", System.Type.GetType("System.Decimal"));
        //    paymentReimbursementTableTemp.Columns.Add("discount_amount", System.Type.GetType("System.Decimal"));
        //    paymentReimbursementTableTemp.Columns.Add("is_payment", System.Type.GetType("System.Boolean"));
        //    paymentReimbursementTableTemp.Columns.Add("is_discount", System.Type.GetType("System.Boolean"));
        //    paymentReimbursementTableTemp.Columns.Add("is_downpayment", System.Type.GetType("System.Boolean"));
        //    paymentReimbursementTableTemp.Columns.Add("is_credit_memo", System.Type.GetType("System.Boolean"));
        //    paymentReimbursementTableTemp.Columns.Add("is_included_in_post", System.Type.GetType("System.Boolean"));
        //    //------------------------

        //    chargesSummaryTable.Clear();

        //    using (RemoteClient.RemCntStudentLoadingManager remClient = new RemoteClient.RemCntStudentLoadingManager())
        //    {
        //        balanceForwardedTable = remClient.SelectBySysIDStudentListDateEndingBalanceCarriedForwardStudentLoad(userInfo,
        //            this.GetStudentCourseGroupSystemIdFormat(true, false), this.GetStudentCourseGroupSystemIdFormat(false, true), dateEnding);
        //    }

        //    using (RemoteClient.RemCntStudentLoadingManager remClient = new RemoteClient.RemCntStudentLoadingManager())
        //    {
        //        printingSchoolFeeDetailsTable = remClient.SelectBySysIDStudentEnrolmentLevelListSchoolFeeDetailsStudentLoad(userInfo,
        //            this.GetStudentCourseGroupSystemIdFormat(true, false), this.GetStudentEnrolmentLevelFormat());
        //    }

        //    using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
        //    {
        //        paymentDiscountReimbursementTable = remClient.SelectBySysIDStudentListDateStartEndStudentPaymentsDiscountsReimbursement(userInfo,
        //            this.GetStudentCourseGroupSystemIdFormat(true, false), dateStart, dateEnd, _serverDateTime);
        //    }

        //    foreach (DataRow payRow in paymentDiscountReimbursementTable.Rows)
        //    {
        //        DataRow newRow = paymentReimbursementTableTemp.NewRow();

        //        newRow["payment_discount_reimbursement_id"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "payment_discount_reimbursement_id", "");
        //        newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "sysid_student", "");

        //        DateTime pDate = DateTime.Parse(this.ServerDateTime);

        //        if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(payRow, "reflected_date", ""), out pDate))
        //        {
        //            newRow["reflected_date"] = pDate;
        //        }

        //        newRow["amount"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "amount", Decimal.Parse("0"));
        //        newRow["discount_amount"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "discount_amount", Decimal.Parse("0"));
        //        newRow["is_payment"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_payment", false);
        //        newRow["is_discount"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_discount", false);
        //        newRow["is_downpayment"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_downpayment", false);
        //        newRow["is_credit_memo"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_credit_memo", false);
        //        newRow["is_included_in_post"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_included_in_post", false);

        //        paymentReimbursementTableTemp.Rows.Add(newRow);
        //    }

        //    Boolean isClearanceIncluded = false;

        //    using (RemoteClient.RemCntStudentLoadingManager remClient = new RemoteClient.RemCntStudentLoadingManager())
        //    {
        //        printingSubjectScheduleTable = remClient.SelectBySysIDEnrolmentLevelListSubjectScheduleStudentLoad(userInfo,
        //            this.GetStudentEnrolmentLevelFormat(), _serverDateTime);
        //        printingScheduleDetails = remClient.SelectBySysIDEnrolmentLevelListScheduleDetailsStudentLoad(userInfo,
        //            this.GetStudentEnrolmentLevelFormat());
        //    }

        //    if (_majorExamScheduleTable != null)
        //    {
        //        foreach (DataRow examRow in _majorExamScheduleTable.Rows)
        //        {
        //            if (RemoteServerLib.ProcStatic.DataRowConvert(examRow, "is_for_print", false))
        //            {
        //                isClearanceIncluded = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "is_clearance_included", false);

        //                DataRow newRowExam = examTable.NewRow();

        //                newRowExam["exam_id"] = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "major_exam_id", Int64.Parse("0"));

        //                DateTime dueDate = DateTime.Parse(this.ServerDateTime);

        //                if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(examRow, "exam_date", ""), out dueDate))
        //                {
        //                    TimeSpan oneDay = new TimeSpan(24, 0, 0);

        //                    newRowExam["exam_date"] = dueDate.Subtract(oneDay).ToLongDateString();
        //                }

        //                newRowExam["exam_description"] = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "exam_description", "");
        //                newRowExam["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "course_group_id", "");

        //                examTable.Rows.Add(newRowExam);
        //            }

        //        }
        //    }

        //    if (_studentTable != null)
        //    {
        //        StringBuilder strCourseGroup = new StringBuilder();

        //        Boolean hasEnter = false;
        //        foreach (DataRow groupRow in _majorExamScheduleTable.Rows)
        //        {
        //            if (!hasEnter && RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "is_for_print", false))
        //            {
        //                strCourseGroup.Append("course_group_id = '" + RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "") + "'");

        //                hasEnter = true;
        //            }
        //            else if (hasEnter && RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "is_for_print", false))
        //            {
        //                strCourseGroup.Append(" OR course_group_id = '" + RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "") + "'");
        //            }
        //        }

        //        DataRow[] selectStudent = _studentTable.Select(strCourseGroup.ToString());

        //        Int32 noOfDivisions = 0;

        //        Int32 noOfPages = 20;

        //        if (selectStudent.Length > 0)
        //        {
        //            noOfDivisions = selectStudent.Length / noOfPages + (selectStudent.Length % noOfPages != 0 ? 1 : 0);
        //        }

        //        for(Int32 index = 0; index < noOfDivisions;index++)
        //        {
        //            pStudentTable.Rows.Clear();

        //            pSubjecScheduleTable.Rows.Clear();

        //            chargesSummaryTable.Rows.Clear();

        //            amountDueTable.Rows.Clear();

        //            for (Int32 studentIndex = index * noOfPages; studentIndex < ((index * noOfPages) + noOfPages); studentIndex++)
        //            {
        //                if (studentIndex >= selectStudent.Length)
        //                {
        //                    break;
        //                }

        //                DataRow studRow = selectStudent[studentIndex];

        //                Decimal totalTutionFee = 0;
        //                Decimal totalMiscellaneousFee = 0;
        //                Decimal totalOtherFee = 0;
        //                Decimal totalLaboratoryFee = 0;
        //                Decimal downpayment = 0;
        //                Decimal totalCharges = 0;
        //                Decimal totalDiscountPayments = 0;
        //                Decimal totalBalanceForwarded = 0;
        //                Decimal totalReimbursement = 0;

        //                if (studRow.RowState != DataRowState.Deleted &&
        //                    (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_enrolmentlevel", "")) &&
        //                    !String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_description", ""))))
        //                {
        //                    DataRow newRow = pStudentTable.NewRow();

        //                    newRow["student_name"] = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(
        //                        RemoteServerLib.ProcStatic.DataRowConvert(studRow, "last_name", ""),
        //                        RemoteServerLib.ProcStatic.DataRowConvert(studRow, "first_name", ""),
        //                        RemoteServerLib.ProcStatic.DataRowConvert(studRow, "middle_name", ""));
        //                    newRow["student_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "student_id", "");
        //                    newRow["course_title"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_title", "");
        //                    newRow["year_level_description"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_level_description", "") + "  " +
        //                        RemoteServerLib.ProcStatic.DataRowConvert(studRow, "level_section", String.Empty);
        //                    newRow["sysid_enrolmentlevel"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_enrolmentlevel", "");
        //                    newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");

        //                    String sem = String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "semester_description", "")) ? String.Empty :
        //                        " - " + RemoteServerLib.ProcStatic.DataRowConvert(studRow, "semester_description", "");

        //                    newRow["year_semester_description"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_description", "") + sem;
        //                    newRow["notes"] = "This is to certify that " + RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(
        //                        RemoteServerLib.ProcStatic.DataRowConvert(studRow, "last_name", ""),
        //                        RemoteServerLib.ProcStatic.DataRowConvert(studRow, "first_name", ""),
        //                        RemoteServerLib.ProcStatic.DataRowConvert(studRow, "middle_name", "")) +
        //                        " is cleared of property and financial obligations in this institution.";
        //                    newRow["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_group_id", "");

        //                    pStudentTable.Rows.Add(newRow);

        //                    String strFilterBalanceForwarded = "sysid_student = '" + RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "") + "'";
        //                    DataRow[] selectBalanceForwarded = balanceForwardedTable.Select(strFilterBalanceForwarded);

        //                    foreach (DataRow bRow in selectBalanceForwarded)
        //                    {
        //                        //if (RemoteServerLib.ProcStatic.DataRowConvert(bRow, "amount", Decimal.Parse("0")) > 0)
        //                        //{
        //                        if (RemoteServerLib.ProcStatic.DataRowConvert(bRow, "amount", Decimal.Parse("0")) != 0)
        //                        {
        //                            DataRow newRowBalanceForwarded = chargesSummaryTable.NewRow();

        //                            newRowBalanceForwarded["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "sysid_student", "");
        //                            newRowBalanceForwarded["charges_description"] = "Balance Forwarded";
        //                            newRowBalanceForwarded["text_balance"] = String.Empty;
        //                            newRowBalanceForwarded["amount"] = this.GetStringAmount(RemoteServerLib.ProcStatic.DataRowConvert(bRow,
        //                                "amount", Decimal.Parse("0")));
        //                            newRowBalanceForwarded["total_amount"] = String.Empty;


        //                            chargesSummaryTable.Rows.Add(newRowBalanceForwarded);

        //                            totalBalanceForwarded = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "amount", Decimal.Parse("0"));
        //                            totalCharges += RemoteServerLib.ProcStatic.DataRowConvert(bRow, "amount", Decimal.Parse("0"));
        //                        }
        //                        //}

        //                        break;
        //                    }

        //                    String strFilter = "sysid_student = '" + RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "") + "'";
        //                    DataRow[] selectRowFeeDetails = printingSchoolFeeDetailsTable.Select(strFilter);

        //                    foreach (DataRow detailsRow in selectRowFeeDetails)
        //                    {
        //                        if (CommonExchange.SchoolFeeCategoryId.TuitionFee == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", "") &&
        //                        (RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_per_year_tuition_fee", false) ||
        //                         RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_per_unit_tuition_fee", false) ||
        //                         RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_fixed_amount_tuition_fee", false) ||
        //                         RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_special_class_tuition_fee", false)))
        //                        {
        //                            totalTutionFee += RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));
        //                        }
        //                        else if (CommonExchange.SchoolFeeCategoryId.MiscellaneousFees == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow,
        //                            "fee_category_id", ""))
        //                        {
        //                            totalMiscellaneousFee += RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));
        //                        }
        //                        else if (CommonExchange.SchoolFeeCategoryId.OtherFees == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", ""))
        //                        {
        //                            totalOtherFee += RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));
        //                        }
        //                        else if (CommonExchange.SchoolFeeCategoryId.LaboratoryFees == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow,
        //                            "fee_category_id", ""))
        //                        {
        //                            totalLaboratoryFee += RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));
        //                        }
        //                    }

        //                    if (totalTutionFee > 0)
        //                    {
        //                        DataRow newRowTuitionFee = chargesSummaryTable.NewRow();

        //                        newRowTuitionFee["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
        //                        newRowTuitionFee["charges_description"] = "Tuition Fee";
        //                        newRowTuitionFee["text_balance"] = String.Empty;
        //                        newRowTuitionFee["amount"] = this.GetStringAmount(totalTutionFee);
        //                        newRowTuitionFee["total_amount"] = String.Empty;

        //                        chargesSummaryTable.Rows.Add(newRowTuitionFee);

        //                        totalCharges += totalTutionFee;
        //                    }

        //                    if (totalMiscellaneousFee > 0)
        //                    {
        //                        DataRow newRowMiscFee = chargesSummaryTable.NewRow();

        //                        newRowMiscFee["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
        //                        newRowMiscFee["charges_description"] = "Miscellaneous Fee";
        //                        newRowMiscFee["text_balance"] = String.Empty;
        //                        newRowMiscFee["amount"] = this.GetStringAmount(totalMiscellaneousFee);
        //                        newRowMiscFee["total_amount"] = String.Empty;

        //                        chargesSummaryTable.Rows.Add(newRowMiscFee);

        //                        totalCharges += totalMiscellaneousFee;
        //                    }

        //                    if (totalOtherFee > 0)
        //                    {
        //                        DataRow newRowOtherFee = chargesSummaryTable.NewRow();

        //                        newRowOtherFee["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
        //                        newRowOtherFee["charges_description"] = "Other Fee";
        //                        newRowOtherFee["text_balance"] = String.Empty;
        //                        newRowOtherFee["amount"] = this.GetStringAmount(totalOtherFee);
        //                        newRowOtherFee["total_amount"] = String.Empty;

        //                        chargesSummaryTable.Rows.Add(newRowOtherFee);

        //                        totalCharges += totalOtherFee;
        //                    }

        //                    if (totalLaboratoryFee > 0)
        //                    {
        //                        DataRow newRowLabFee = chargesSummaryTable.NewRow();

        //                        newRowLabFee["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
        //                        newRowLabFee["charges_description"] = "Laboratory Fee";
        //                        newRowLabFee["text_balance"] = String.Empty;
        //                        newRowLabFee["amount"] = this.GetStringAmount(totalLaboratoryFee);
        //                        newRowLabFee["total_amount"] = String.Empty;

        //                        chargesSummaryTable.Rows.Add(newRowLabFee);

        //                        totalCharges += totalLaboratoryFee;
        //                    }

        //                    DataRow[] selectRowPaymentReimbursement = paymentDiscountReimbursementTable.Select(strFilter, "is_reimbursement DESC");

        //                    Boolean isFirstEntry = true;
        //                    foreach (DataRow paymentRow in selectRowPaymentReimbursement)
        //                    {
        //                        //Code added:: include only if (is_included_in_post == true) :: April 7, 2010
        //                        if (!RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_balance_forwarded", false) &&
        //                            RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_included_in_post", false))
        //                        {
        //                            String remarksDescription = String.Empty;
        //                            String paymentDiscountReimbursementDate = !String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "receipt_no", String.Empty)) ?
        //                                "(" + RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "receipt_no", String.Empty) + ") :: " : String.Empty;

        //                            if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
        //                                (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_payment", false) &&
        //                                !RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false)))
        //                            {
        //                                remarksDescription = "Payment";
        //                            }
        //                            else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow,
        //                                "remarks_discount_reimbursement_description", "")) &&
        //                                RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false))
        //                            {
        //                                remarksDescription = "Downpayment";

        //                                downpayment += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")) +
        //                                    RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0"));
        //                            }
        //                            else if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow,
        //                                "remarks_discount_reimbursement_description", "")) &&
        //                               RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false))
        //                            {
        //                                remarksDescription = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "");

        //                                downpayment += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")) +
        //                                    RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0"));
        //                            }
        //                            else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow,
        //                                "remarks_discount_reimbursement_description", "")) &&
        //                                RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_reimbursement", false))
        //                            {
        //                                remarksDescription = "Reimbursement";
        //                            }
        //                            else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow,
        //                                "remarks_discount_reimbursement_description", "")) &&
        //                                RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_credit_memo", false))
        //                            {
        //                                remarksDescription = "Credit Memo";
        //                            }
        //                            else if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow,
        //                                "remarks_discount_reimbursement_description", "")))
        //                            {
        //                                remarksDescription = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "");
        //                            }

        //                            DateTime pDate;

        //                            if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "reflected_date", ""), out pDate))
        //                            {
        //                                paymentDiscountReimbursementDate += pDate.ToShortDateString();
        //                            }

        //                            if (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_reimbursement", false))
        //                            {
        //                                DataRow newRowReimbursement = chargesSummaryTable.NewRow();

        //                                newRowReimbursement["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
        //                                newRowReimbursement["charges_description"] = remarksDescription + " - " + paymentDiscountReimbursementDate;
        //                                newRowReimbursement["text_balance"] = String.Empty;
        //                                newRowReimbursement["amount"] = this.GetStringAmount(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow,
        //                                    "amount", Decimal.Parse("0")));
        //                                newRowReimbursement["total_amount"] = String.Empty;

        //                                chargesSummaryTable.Rows.Add(newRowReimbursement);

        //                                totalReimbursement += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0"));
        //                                totalCharges += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0"));
        //                            }
        //                            else
        //                            {
        //                                if (isFirstEntry)
        //                                {
        //                                    DataRow newRowPaymentDiscount = chargesSummaryTable.NewRow();

        //                                    newRowPaymentDiscount["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
        //                                    newRowPaymentDiscount["charges_description"] = "       Sub Total";
        //                                    newRowPaymentDiscount["text_balance"] = String.Empty;
        //                                    newRowPaymentDiscount["amount"] = String.Empty;
        //                                    newRowPaymentDiscount["total_amount"] = this.GetStringAmount(totalCharges);

        //                                    chargesSummaryTable.Rows.Add(newRowPaymentDiscount);

        //                                    DataRow newLessRow = chargesSummaryTable.NewRow();

        //                                    newLessRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
        //                                    newLessRow["charges_description"] = "Less:";
        //                                    newLessRow["text_balance"] = String.Empty;
        //                                    newLessRow["amount"] = String.Empty;
        //                                    newLessRow["total_amount"] = String.Empty;

        //                                    chargesSummaryTable.Rows.Add(newLessRow);

        //                                    isFirstEntry = false;
        //                                }

        //                                DataRow newDiscountPaymentRow = chargesSummaryTable.NewRow();

        //                                newDiscountPaymentRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
        //                                newDiscountPaymentRow["charges_description"] = "   " + remarksDescription + " - " + paymentDiscountReimbursementDate;
        //                                newDiscountPaymentRow["text_balance"] = String.Empty;
        //                                newDiscountPaymentRow["amount"] = "(" + RemoteServerLib.ProcStatic.DataRowConvert(paymentRow,
        //                                    "amount", Decimal.Parse("0")).ToString("N") + ")";
        //                                newDiscountPaymentRow["total_amount"] = String.Empty;

        //                                chargesSummaryTable.Rows.Add(newDiscountPaymentRow);

        //                                if (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0")) > 0)
        //                                {
        //                                    DataRow newDiscountedAmountRow = chargesSummaryTable.NewRow();

        //                                    newDiscountedAmountRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
        //                                    newDiscountedAmountRow["charges_description"] = "   Cash Discount - " + paymentDiscountReimbursementDate;
        //                                    newDiscountedAmountRow["text_balance"] = String.Empty;
        //                                    newDiscountedAmountRow["amount"] = "(" +
        //                                        RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0")).ToString("N") + ")";
        //                                    newDiscountedAmountRow["total_amount"] = String.Empty;

        //                                    chargesSummaryTable.Rows.Add(newDiscountedAmountRow);
        //                                }

        //                                totalDiscountPayments += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")) +
        //                                    RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0"));
        //                            }
        //                        }
        //                    }

        //                    if (isFirstEntry)
        //                    {
        //                        DataRow newRowPaymentDiscount = chargesSummaryTable.NewRow();

        //                        newRowPaymentDiscount["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
        //                        newRowPaymentDiscount["charges_description"] = "       Sub Total";
        //                        newRowPaymentDiscount["text_balance"] = String.Empty;
        //                        newRowPaymentDiscount["amount"] = String.Empty;
        //                        newRowPaymentDiscount["total_amount"] = this.GetStringAmount(totalCharges);

        //                        chargesSummaryTable.Rows.Add(newRowPaymentDiscount);
        //                    }
        //                    else
        //                    {
        //                        DataRow newTotalDiscountPaymentRow = chargesSummaryTable.NewRow();

        //                        newTotalDiscountPaymentRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
        //                        newTotalDiscountPaymentRow["charges_description"] = "       Sub Total";
        //                        newTotalDiscountPaymentRow["text_balance"] = String.Empty;
        //                        newTotalDiscountPaymentRow["amount"] = String.Empty;
        //                        newTotalDiscountPaymentRow["total_amount"] = "(" + totalDiscountPayments.ToString("N") + ")";

        //                        chargesSummaryTable.Rows.Add(newTotalDiscountPaymentRow);
        //                    }

        //                    DataRow lineRow = chargesSummaryTable.NewRow();

        //                    lineRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
        //                    lineRow["charges_description"] = String.Empty;
        //                    lineRow["text_balance"] = String.Empty;
        //                    lineRow["amount"] = String.Empty;
        //                    lineRow["total_amount"] = "_________";

        //                    chargesSummaryTable.Rows.Add(lineRow);

        //                    DataRow balanceRow = chargesSummaryTable.NewRow();

        //                    balanceRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
        //                    balanceRow["charges_description"] = String.Empty;
        //                    balanceRow["text_balance"] = "Balance";
        //                    balanceRow["amount"] = String.Empty;
        //                    balanceRow["total_amount"] = (totalCharges - totalDiscountPayments).ToString("N");

        //                    chargesSummaryTable.Rows.Add(balanceRow);

        //                    String strFilterScheduleDetails = "sysid_enrolmentlevel = '" + RemoteServerLib.ProcStatic.DataRowConvert(studRow,
        //                        "sysid_enrolmentlevel", "") + "'";
        //                    DataRow[] selectScheduleDetails = printingScheduleDetails.Select(strFilterScheduleDetails);

        //                    foreach (DataRow dRow in selectScheduleDetails)
        //                    {
        //                        DataRow newRowScheduleDetails = pSubjecScheduleTable.NewRow();

        //                        newRowScheduleDetails["sysid_enrolmentlevel"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_enrolmentlevel", "");

        //                        String strFilterSched = "sysid_schedule = '" + RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_schedule", "") + "'";
        //                        DataRow[] selectSubjectSchedule = printingSubjectScheduleTable.Select(strFilterSched);

        //                        foreach (DataRow subRow in selectSubjectSchedule)
        //                        {
        //                            if (subRow.RowState != DataRowState.Deleted)
        //                            {
        //                                newRowScheduleDetails["subject_code_title"] = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_code", "") + " - " +
        //                                    RemoteServerLib.ProcStatic.DataRowConvert(subRow, "descriptive_title", "");
        //                            }

        //                            break;
        //                        }

        //                        pSubjecScheduleTable.Rows.Add(newRowScheduleDetails);
        //                    }
        //                }

        //                if (_majorExamScheduleTable != null)
        //                {
        //                    DataRow[] selectMajorExam = _majorExamScheduleTable.Select(strCourseGroup.ToString());

        //                    Decimal amountToBeAdded = 0;
        //                    Decimal minimunDownpayment = 0;

        //                    if (!isSummer)
        //                    {
        //                        if (String.Equals(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_id", String.Empty), "CRSE014"))
        //                        {
        //                            amountToBeAdded = this.GetToBeAddedAmount(5000, ref downpayment);
        //                            minimunDownpayment = 5000;
        //                        }
        //                        else if (String.Equals(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_id", String.Empty), "CRSE012") ||
        //                            String.Equals(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_id", String.Empty), "CRSE011"))
        //                        {
        //                            amountToBeAdded = this.GetToBeAddedAmount(3500, ref downpayment);
        //                            minimunDownpayment = 3500;
        //                        }
        //                        else
        //                        {
        //                            amountToBeAdded = this.GetToBeAddedAmount(2500, ref downpayment);
        //                            minimunDownpayment = 2500;
        //                        }
        //                    }
        //                    else
        //                    {
        //                        if (String.Equals(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_id", String.Empty), "CRSE014"))
        //                        {
        //                            amountToBeAdded = this.GetToBeAddedAmount(2000, ref downpayment);
        //                            minimunDownpayment = 2000;
        //                        }
        //                        else
        //                        {
        //                            amountToBeAdded = this.GetToBeAddedAmount(1500, ref downpayment);
        //                            minimunDownpayment = 1500;
        //                        }
        //                    }

        //                    amountToBeAdded += totalBalanceForwarded;

        //                    Decimal acctualAmountDue = ((totalTutionFee + totalMiscellaneousFee + totalOtherFee +
        //                       totalLaboratoryFee + totalReimbursement) - downpayment) / selectMajorExam.Length;

        //                    Decimal totalPayment = 0;
        //                    String strFilter = "is_downpayment = 0 AND sysid_student = '" +
        //                        RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "") + "'";
        //                    DataRow[] selectRow = paymentReimbursementTableTemp.Select(strFilter);

        //                    foreach (DataRow payRow in selectRow)
        //                    {
        //                        DateTime paymentDate = DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(payRow, "reflected_date", String.Empty));

        //                        //Code added:: include only if (is_included_in_post == true) :: July 6, 2010
        //                        if (RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_included_in_post", false))
        //                        {
        //                            if (RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_payment", false) ||
        //                                RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_discount", false) ||
        //                                RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_credit_memo", false))
        //                            {
        //                                totalPayment += RemoteServerLib.ProcStatic.DataRowConvert(payRow, "amount", Decimal.Parse("0")) +
        //                                    RemoteServerLib.ProcStatic.DataRowConvert(payRow, "discount_amount", Decimal.Parse("0"));
        //                            }
        //                        }
        //                    }

        //                    DateTime previousDateTime = DateTime.MinValue;
        //                    Decimal amountDuePrevious = 0;
        //                    Decimal computedAcctualAmountDue = 0;
        //                    Boolean isFirstEnter = true;

        //                    foreach (DataRow examRow in selectMajorExam)
        //                    {
        //                        Decimal amountDue = 0;

        //                        DataRow newRowAmountDue = amountDueTable.NewRow();

        //                        newRowAmountDue["exam_id"] =
        //                            RemoteServerLib.ProcStatic.DataRowConvert(examRow, "major_exam_id", Int64.Parse("0"));

        //                        DateTime dueDate = DateTime.Parse(this.ServerDateTime);

        //                        if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(examRow, "exam_date", ""), out dueDate))
        //                        {
        //                            TimeSpan oneDay = new TimeSpan(24, 0, 0);

        //                            Decimal totalPaymentByTerm = 0;

        //                            if (!RemoteServerLib.ProcStatic.DataRowConvert(examRow, "is_clearance_included", false))
        //                            {
        //                                totalPaymentByTerm = previousDateTime == DateTime.MinValue ?
        //                                        this.GetTotalPaymentByDateStartEnd(DateTime.Parse(dateStart), dueDate, paymentReimbursementTableTemp,
        //                                        RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", ""), isFirstEnter) :
        //                                        this.GetTotalPaymentByDateStartEnd(previousDateTime, dueDate, paymentReimbursementTableTemp,
        //                                        RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", ""), isFirstEnter);
        //                            }
        //                            else
        //                            {
        //                                totalPaymentByTerm =
        //                                    this.GetTotalPaymentByDateStartEnd(previousDateTime, DateTime.Parse(dateEnd), paymentReimbursementTableTemp,
        //                                    RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", ""), isFirstEnter);
        //                            }

        //                            //AD----------------------------
        //                            if (!RemoteServerLib.ProcStatic.DataRowConvert(examRow, "is_clearance_included", false))
        //                            {
        //                                if (isFirstEnter)
        //                                {
        //                                    amountDue = (acctualAmountDue + minimunDownpayment + totalBalanceForwarded) - totalPaymentByTerm;

        //                                    amountDuePrevious = (acctualAmountDue + minimunDownpayment + totalBalanceForwarded) - totalPaymentByTerm;

        //                                    isFirstEnter = false;
        //                                }
        //                                else
        //                                {
        //                                    amountDue = (acctualAmountDue + amountDuePrevious) - totalPaymentByTerm;

        //                                    amountDuePrevious = (acctualAmountDue + amountDuePrevious) - totalPaymentByTerm;
        //                                }
        //                            }
        //                            else
        //                            {
        //                                amountDue = (acctualAmountDue + amountDuePrevious) - totalPaymentByTerm;
        //                            }
        //                            //--------------------------------

        //                            previousDateTime = dueDate;
        //                        }

        //                        computedAcctualAmountDue += acctualAmountDue;

        //                        if (RemoteServerLib.ProcStatic.DataRowConvert(examRow, "is_for_print", false))
        //                        {
        //                            isClearanceIncluded = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "is_clearance_included", false);

        //                            if (!RemoteServerLib.ProcStatic.DataRowConvert(examRow, "is_clearance_included", false))
        //                            {
        //                                amountDue = ((amountDue < 0) || (totalPayment > computedAcctualAmountDue + amountToBeAdded)) ? 0 :
        //                                    (((computedAcctualAmountDue - totalPayment) + amountToBeAdded) < 0 ? 0 :
        //                                    ((computedAcctualAmountDue - totalPayment) + amountToBeAdded));
        //                            }

        //                            newRowAmountDue["amount_due"] = amountDue;
        //                            newRowAmountDue["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");

        //                            amountDueTable.Rows.Add(newRowAmountDue);
        //                        }
        //                    }
        //                }
        //            }

        //            pStudentTable.AcceptChanges();
        //            pSubjecScheduleTable.AcceptChanges();                   

        //            if (!isClearanceIncluded)
        //            {
        //                using (ClassStudentLoadingManager.CrystalReport.CrystalStudentStatementOfAccount rptStudentStatementOfAccount =
        //                    new OfficeServices.ClassStudentLoadingManager.CrystalReport.CrystalStudentStatementOfAccount())
        //                {
        //                    rptStudentStatementOfAccount.Database.Tables["student_table"].SetDataSource(pStudentTable);
        //                    rptStudentStatementOfAccount.Database.Tables["subject_schedule_details_table"].SetDataSource(pSubjecScheduleTable);
        //                    rptStudentStatementOfAccount.Database.Tables["charges_summary_table"].SetDataSource(chargesSummaryTable);
        //                    rptStudentStatementOfAccount.Database.Tables["exam_table"].SetDataSource(examTable);
        //                    rptStudentStatementOfAccount.Database.Tables["amount_due_table"].SetDataSource(amountDueTable);

        //                    rptStudentStatementOfAccount.SetParameterValue("@school_name", CommonExchange.SchoolInformation.SchoolName);
        //                    rptStudentStatementOfAccount.SetParameterValue("@form_name", "Student Statement of Account");
        //                    rptStudentStatementOfAccount.SetParameterValue("@print_info", "Date/Time Printed: " + DateTime.Parse(_serverDateTime).ToShortDateString() + " " +
        //                        DateTime.Parse(_serverDateTime).ToShortTimeString() + "         Printed by: " +
        //                        RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName,
        //                        userInfo.PersonInfo.FirstName, userInfo.PersonInfo.MiddleName));

        //                    rptStudentStatementOfAccount.PrintToPrinter(1, false, 0, 0);
        //                }
        //            }
        //            else
        //            {

        //                //create tables 
        //                DataTable lineTable = new DataTable("LineTable");
        //                lineTable.Columns.Add("line_id", System.Type.GetType("System.Byte"));
        //                lineTable.Columns.Add("col_1", System.Type.GetType("System.String"));
        //                lineTable.Columns.Add("col_2", System.Type.GetType("System.String"));
        //                lineTable.Columns.Add("col_3", System.Type.GetType("System.String"));
        //                lineTable.Columns.Add("col_4", System.Type.GetType("System.String"));
        //                lineTable.Columns.Add("col_5", System.Type.GetType("System.String"));

        //                DataRow col1 = lineTable.NewRow();

        //                col1["line_id"] = 1;
        //                col1["col_1"] = "_________________________";
        //                col1["col_2"] = "_________________________";
        //                col1["col_3"] = "_________________________";
        //                col1["col_4"] = "_________________________";
        //                col1["col_5"] = "_________________________";

        //                lineTable.Rows.Add(col1);

        //                DataRow col2 = lineTable.NewRow();

        //                col2["line_id"] = 2;
        //                col2["col_1"] = "_________________________";
        //                col2["col_2"] = "_________________________";
        //                col2["col_3"] = "_________________________";
        //                col2["col_4"] = String.Empty;
        //                col2["col_5"] = String.Empty;

        //                lineTable.Rows.Add(col2);

        //                DataRow col3 = lineTable.NewRow();

        //                col3["line_id"] = 3;
        //                col3["col_1"] = "_________________________";
        //                col3["col_2"] = "_________________________";
        //                col3["col_3"] = String.Empty;
        //                col3["col_4"] = String.Empty;
        //                col3["col_5"] = String.Empty;

        //                lineTable.Rows.Add(col3);

        //                DataRow col4 = lineTable.NewRow();

        //                col4["line_id"] = 4;
        //                col4["col_1"] = String.Empty;
        //                col4["col_2"] = String.Empty;
        //                col4["col_3"] = "_________________________";
        //                col4["col_4"] = String.Empty;
        //                col4["col_5"] = String.Empty;

        //                lineTable.Rows.Add(col4);

        //                //-------------------------
        //                DataTable clearanceTable = new DataTable("ClearanceTable");
        //                clearanceTable.Columns.Add("course_group_id", System.Type.GetType("System.String"));
        //                clearanceTable.Columns.Add("line_id", System.Type.GetType("System.Byte"));
        //                clearanceTable.Columns.Add("col_1", System.Type.GetType("System.String"));
        //                clearanceTable.Columns.Add("col_2", System.Type.GetType("System.String"));
        //                clearanceTable.Columns.Add("col_3", System.Type.GetType("System.String"));
        //                clearanceTable.Columns.Add("col_4", System.Type.GetType("System.String"));
        //                clearanceTable.Columns.Add("col_5", System.Type.GetType("System.String"));
        //                //--------------------------

        //                foreach (DataRow groupRow in _classDataSet.Tables["CourseGroupTable"].Rows)
        //                {
        //                    if (CommonExchange.CourseGroupId.College == RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", ""))
        //                    {
        //                        DataRow row2 = clearanceTable.NewRow();

        //                        row2["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
        //                        row2["line_id"] = 1;
        //                        row2["col_1"] = "Library";
        //                        row2["col_2"] = "Registrar";
        //                        row2["col_3"] = "Athletic & Prop. Custodian";
        //                        row2["col_4"] = "Student Affairs Chairperson";
        //                        row2["col_5"] = "Clinic";

        //                        clearanceTable.Rows.Add(row2);

        //                        DataRow row3 = clearanceTable.NewRow();

        //                        row3["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
        //                        row3["line_id"] = 1;
        //                        row3["col_1"] = "Adviser / Coordinator";
        //                        row3["col_2"] = "Guidance";
        //                        row3["col_3"] = "Christian Formation Office";
        //                        row3["col_4"] = "Dean";
        //                        row3["col_5"] = "Finance Officer";

        //                        clearanceTable.Rows.Add(row3);

        //                        DataRow row6 = clearanceTable.NewRow();

        //                        row6["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
        //                        row6["line_id"] = 4;
        //                        row6["col_1"] = String.Empty;
        //                        row6["col_2"] = String.Empty;
        //                        row6["col_3"] = "President";
        //                        row6["col_4"] = String.Empty;
        //                        row6["col_5"] = String.Empty;

        //                        clearanceTable.Rows.Add(row6);
        //                    }
        //                    else if (CommonExchange.CourseGroupId.HighSchool == RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", ""))
        //                    {
        //                        DataRow row2 = clearanceTable.NewRow();

        //                        row2["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
        //                        row2["line_id"] = 1;
        //                        row2["col_1"] = "Religion";
        //                        row2["col_2"] = "Filipino";
        //                        row2["col_3"] = "Aral. Pan.";
        //                        row2["col_4"] = "English";
        //                        row2["col_5"] = "Science";

        //                        clearanceTable.Rows.Add(row2);

        //                        DataRow row4 = clearanceTable.NewRow();

        //                        row4["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
        //                        row4["line_id"] = 1;
        //                        row4["col_1"] = "Math";
        //                        row4["col_2"] = "T.H.E";
        //                        row4["col_3"] = "MAPEH/CAT";
        //                        row4["col_4"] = "Club Mederator";
        //                        row4["col_5"] = "HS Librarian";

        //                        clearanceTable.Rows.Add(row4);

        //                        DataRow row6 = clearanceTable.NewRow();

        //                        row6["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
        //                        row6["line_id"] = 1;
        //                        row6["col_1"] = "Guidance Counselor";
        //                        row6["col_2"] = "Club & Orgs. In-Charge";
        //                        row6["col_3"] = "Class Treasurer";
        //                        row6["col_4"] = "Club Mederator";
        //                        row6["col_5"] = "Class Adviser";

        //                        clearanceTable.Rows.Add(row6);

        //                        DataRow row8 = clearanceTable.NewRow();

        //                        row8["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
        //                        row8["line_id"] = 2;
        //                        row8["col_1"] = "Homeroom In-Charge";
        //                        row8["col_2"] = "Science Lab. In-Charge";
        //                        row8["col_3"] = "Finance Officer";
        //                        row8["col_4"] = String.Empty;
        //                        row8["col_5"] = String.Empty;

        //                        clearanceTable.Rows.Add(row8);

        //                        DataRow row10 = clearanceTable.NewRow();

        //                        row10["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
        //                        row10["line_id"] = 4;
        //                        row10["col_1"] = String.Empty;
        //                        row10["col_2"] = String.Empty;
        //                        row10["col_3"] = "High School Principal";
        //                        row10["col_4"] = String.Empty;
        //                        row10["col_5"] = String.Empty;

        //                        clearanceTable.Rows.Add(row10);
        //                    }
        //                    else if (CommonExchange.CourseGroupId.GradeSchoolKinder == RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", ""))
        //                    {
        //                        DataRow row2 = clearanceTable.NewRow();

        //                        row2["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
        //                        row2["line_id"] = 1;
        //                        row2["col_1"] = "Religion";
        //                        row2["col_2"] = "English";
        //                        row2["col_3"] = "Math";
        //                        row2["col_4"] = "Filipino";
        //                        row2["col_5"] = "Science";

        //                        clearanceTable.Rows.Add(row2);

        //                        DataRow row4 = clearanceTable.NewRow();

        //                        row4["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
        //                        row4["line_id"] = 1;
        //                        row4["col_1"] = "Sibika/HEKASI";
        //                        row4["col_2"] = "Computer";
        //                        row4["col_3"] = "MAPE";
        //                        row4["col_4"] = "HELE";
        //                        row4["col_5"] = "Class Treasurer";

        //                        clearanceTable.Rows.Add(row4);

        //                        DataRow row6 = clearanceTable.NewRow();

        //                        row6["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
        //                        row6["line_id"] = 1;
        //                        row6["col_1"] = "AVR In-Charge";
        //                        row6["col_2"] = "H.E In-Charge";
        //                        row6["col_3"] = "Guidance In-Charge";
        //                        row6["col_4"] = "Secretary";
        //                        row6["col_5"] = "Librarian";

        //                        clearanceTable.Rows.Add(row6);

        //                        DataRow row8 = clearanceTable.NewRow();

        //                        row8["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
        //                        row8["line_id"] = 3;
        //                        row8["col_1"] = "Class Adviser";
        //                        row8["col_2"] = "Finance Officer";
        //                        row8["col_3"] = String.Empty;
        //                        row8["col_4"] = String.Empty;
        //                        row8["col_5"] = String.Empty;

        //                        clearanceTable.Rows.Add(row8);

        //                        DataRow row10 = clearanceTable.NewRow();

        //                        row10["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
        //                        row10["line_id"] = 4;
        //                        row10["col_1"] = String.Empty;
        //                        row10["col_2"] = String.Empty;
        //                        row10["col_3"] = "Grade School Principal";
        //                        row10["col_4"] = String.Empty;
        //                        row10["col_5"] = String.Empty;

        //                        clearanceTable.Rows.Add(row10);
        //                    }
        //                }

        //                using (ClassStudentLoadingManager.CrystalReport.CrystalStudentStatementOfAccountForFinals rptStudentStatementOfAccountForFinals =
        //                    new OfficeServices.ClassStudentLoadingManager.CrystalReport.CrystalStudentStatementOfAccountForFinals())
        //                {
        //                    rptStudentStatementOfAccountForFinals.Database.Tables["student_table"].SetDataSource(pStudentTable);
        //                    rptStudentStatementOfAccountForFinals.Database.Tables["subject_schedule_details_table"].SetDataSource(pSubjecScheduleTable);
        //                    rptStudentStatementOfAccountForFinals.Database.Tables["charges_summary_table"].SetDataSource(chargesSummaryTable);
        //                    rptStudentStatementOfAccountForFinals.Database.Tables["exam_table"].SetDataSource(examTable);
        //                    rptStudentStatementOfAccountForFinals.Database.Tables["amount_due_table"].SetDataSource(amountDueTable);
        //                    rptStudentStatementOfAccountForFinals.Database.Tables["clearance_table"].SetDataSource(clearanceTable);
        //                    rptStudentStatementOfAccountForFinals.Database.Tables["line_table"].SetDataSource(lineTable);

        //                    rptStudentStatementOfAccountForFinals.SetParameterValue("@school_name", CommonExchange.SchoolInformation.SchoolName);
        //                    rptStudentStatementOfAccountForFinals.SetParameterValue("@form_name", "Student Statement of Account");
        //                    rptStudentStatementOfAccountForFinals.SetParameterValue("@print_info", "Date/Time Printed: " + DateTime.Parse(_serverDateTime).ToShortDateString() + " " +
        //                        DateTime.Parse(_serverDateTime).ToShortTimeString() + "         Printed by: " +
        //                        RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName,
        //                        userInfo.PersonInfo.FirstName, userInfo.PersonInfo.MiddleName));

        //                    rptStudentStatementOfAccountForFinals.PrintToPrinter(1, false, 0, 0);                           
        //                }
        //            }
        //        }
        //    }
            
        //    pgbBase.Style = ProgressBarStyle.Blocks;
        //}//-----------------------------

        //this procedure will print student statement of account
        public void PrintStudentStatementOfAccount(CommonExchange.SysAccess userInfo, DataTable studentTable, String dateStart,
            String dateEnd, String dateEnding, ToolStripProgressBar pgbBase, Boolean isSummer)
        {
            pgbBase.Style = ProgressBarStyle.Marquee;

            DataTable printingSubjectScheduleTable;
            DataTable printingScheduleDetails;
            DataTable printingSpecialClassTable;
            DataTable printingSchoolFeeDetailsTable;
            DataTable paymentDiscountReimbursementTable;
            DataTable balanceForwardedTable;

            //tables of printing
            DataTable pStudentTable = new DataTable("StudentTable");
            pStudentTable.Columns.Add("student_name", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("student_id", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("course_title", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("year_level_description", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("sysid_enrolmentlevel", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("sysid_student", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("year_Semester_description", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("notes", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("course_group_id", System.Type.GetType("System.String"));

            DataTable pSubjecScheduleTable = new DataTable("ScheduleDetailsTable");
            pSubjecScheduleTable.Columns.Add("day_time", System.Type.GetType("System.String"));
            pSubjecScheduleTable.Columns.Add("room", System.Type.GetType("System.String"));
            pSubjecScheduleTable.Columns.Add("section", System.Type.GetType("System.String"));
            pSubjecScheduleTable.Columns.Add("instructor", System.Type.GetType("System.String"));
            pSubjecScheduleTable.Columns.Add("sysid_enrolmentlevel", System.Type.GetType("System.String"));
            pSubjecScheduleTable.Columns.Add("subject_code_title", System.Type.GetType("System.String"));
            pSubjecScheduleTable.Columns.Add("subject_lecture_units", System.Type.GetType("System.String"));
            pSubjecScheduleTable.Columns.Add("subject_lab_units", System.Type.GetType("System.String"));
            pSubjecScheduleTable.Columns.Add("subject_no_hours", System.Type.GetType("System.String"));

            DataTable chargesSummaryTable = new DataTable("ChargesSummaryTable");
            chargesSummaryTable.Columns.Add("sysid_student", System.Type.GetType("System.String"));
            chargesSummaryTable.Columns.Add("charges_description", System.Type.GetType("System.String"));
            chargesSummaryTable.Columns.Add("text_balance", System.Type.GetType("System.String"));
            chargesSummaryTable.Columns.Add("amount", System.Type.GetType("System.String"));
            chargesSummaryTable.Columns.Add("total_amount", System.Type.GetType("System.String"));

            DataTable examTable = new DataTable("ExamTable");
            examTable.Columns.Add("exam_id", System.Type.GetType("System.Int64"));
            examTable.Columns.Add("exam_date", System.Type.GetType("System.String"));
            examTable.Columns.Add("exam_description", System.Type.GetType("System.String"));
            examTable.Columns.Add("course_group_id", System.Type.GetType("System.String"));

            DataTable amountDueTable = new DataTable("AmountDueTable");
            amountDueTable.Columns.Add("exam_id", System.Type.GetType("System.Int64"));
            amountDueTable.Columns.Add("amount_due", System.Type.GetType("System.Decimal"));
            amountDueTable.Columns.Add("sysid_student", System.Type.GetType("System.String"));

            //create temporary table for payment reimbursement table
            DataTable paymentReimbursementTableTemp = new DataTable("TemporaryTable");
            paymentReimbursementTableTemp.Columns.Add("payment_discount_reimbursement_id", System.Type.GetType("System.String"));
            paymentReimbursementTableTemp.Columns.Add("sysid_student", System.Type.GetType("System.String"));
            paymentReimbursementTableTemp.Columns.Add("reflected_date", System.Type.GetType("System.DateTime"));
            paymentReimbursementTableTemp.Columns.Add("amount", System.Type.GetType("System.Decimal"));
            paymentReimbursementTableTemp.Columns.Add("discount_amount", System.Type.GetType("System.Decimal"));
            paymentReimbursementTableTemp.Columns.Add("is_payment", System.Type.GetType("System.Boolean"));
            paymentReimbursementTableTemp.Columns.Add("is_discount", System.Type.GetType("System.Boolean"));
            paymentReimbursementTableTemp.Columns.Add("is_downpayment", System.Type.GetType("System.Boolean"));
            paymentReimbursementTableTemp.Columns.Add("is_credit_memo", System.Type.GetType("System.Boolean"));
            paymentReimbursementTableTemp.Columns.Add("is_included_in_post", System.Type.GetType("System.Boolean"));
            //------------------------

            chargesSummaryTable.Clear();

            using (RemoteClient.RemCntStudentLoadingManager remClient = new RemoteClient.RemCntStudentLoadingManager())
            {
                balanceForwardedTable = remClient.SelectBySysIDStudentListDateEndingBalanceCarriedForwardStudentLoad(userInfo,
                    this.GetStudentCourseGroupSystemIdFormat(true, false, studentTable), this.GetStudentCourseGroupSystemIdFormat(false, true, studentTable), dateEnding);
            }

            using (RemoteClient.RemCntStudentLoadingManager remClient = new RemoteClient.RemCntStudentLoadingManager())
            {
                printingSchoolFeeDetailsTable = remClient.SelectBySysIDStudentEnrolmentLevelListSchoolFeeDetailsStudentLoad(userInfo,
                    this.GetStudentCourseGroupSystemIdFormat(true, false, studentTable), this.GetStudentEnrolmentLevelFormat(studentTable));
            }

            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                paymentDiscountReimbursementTable = remClient.SelectBySysIDStudentListDateStartEndStudentPaymentsDiscountsReimbursement(userInfo,
                    this.GetStudentCourseGroupSystemIdFormat(true, false, studentTable), dateStart, dateEnd, _serverDateTime);
            }

            using (RemoteClient.RemCntSpecialClassManager remClient = new RemoteClient.RemCntSpecialClassManager())
            {
                printingSpecialClassTable = remClient.SelectBySysIDStudentListDateStartEndSpecialClassInformation(userInfo,
                    this.GetStudentCourseGroupSystemIdFormat(true, false, StudentTable), dateStart, dateEnd, _serverDateTime);
            }

            foreach (DataRow payRow in paymentDiscountReimbursementTable.Rows)
            {
                DataRow newRow = paymentReimbursementTableTemp.NewRow();

                newRow["payment_discount_reimbursement_id"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "payment_discount_reimbursement_id", "");
                newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "sysid_student", "");

                DateTime pDate = DateTime.Parse(this.ServerDateTime);

                if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(payRow, "reflected_date", ""), out pDate))
                {
                    newRow["reflected_date"] = pDate;
                }

                newRow["amount"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "amount", Decimal.Parse("0"));
                newRow["discount_amount"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "discount_amount", Decimal.Parse("0"));
                newRow["is_payment"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_payment", false);
                newRow["is_discount"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_discount", false);
                newRow["is_downpayment"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_downpayment", false);
                newRow["is_credit_memo"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_credit_memo", false);
                newRow["is_included_in_post"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_included_in_post", false);

                paymentReimbursementTableTemp.Rows.Add(newRow);
            }

            Boolean isClearanceIncluded = false;

            using (RemoteClient.RemCntStudentLoadingManager remClient = new RemoteClient.RemCntStudentLoadingManager())
            {
                printingSubjectScheduleTable = remClient.SelectBySysIDEnrolmentLevelListSubjectScheduleStudentLoad(userInfo,
                    this.GetStudentEnrolmentLevelFormat(studentTable), _serverDateTime);
                printingScheduleDetails = remClient.SelectBySysIDEnrolmentLevelListScheduleDetailsStudentLoad(userInfo,
                    this.GetStudentEnrolmentLevelFormat(studentTable));
            }

            if (_majorExamScheduleTable != null)
            {
                foreach (DataRow examRow in _majorExamScheduleTable.Rows)
                {
                    if (RemoteServerLib.ProcStatic.DataRowConvert(examRow, "is_for_print", false))
                    {
                        isClearanceIncluded = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "is_clearance_included", false);

                        DataRow newRowExam = examTable.NewRow();

                        newRowExam["exam_id"] = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "major_exam_id", Int64.Parse("0"));

                        DateTime dueDate = DateTime.Parse(this.ServerDateTime);

                        if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(examRow, "exam_date", ""), out dueDate))
                        {
                            TimeSpan oneDay = new TimeSpan(24, 0, 0);

                            newRowExam["exam_date"] = dueDate.Subtract(oneDay).ToLongDateString();
                        }

                        newRowExam["exam_description"] = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "exam_description", "");
                        newRowExam["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "course_group_id", "");

                        examTable.Rows.Add(newRowExam);
                    }

                }
            }

            if (studentTable != null)
            {
                StringBuilder strCourseGroup = new StringBuilder();

                Boolean hasEnter = false;
                foreach (DataRow groupRow in _majorExamScheduleTable.Rows)
                {
                    if (!hasEnter && RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "is_for_print", false))
                    {
                        strCourseGroup.Append("course_group_id = '" + RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "") + "'");

                        hasEnter = true;
                    }
                    else if (hasEnter && RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "is_for_print", false))
                    {
                        strCourseGroup.Append(" OR course_group_id = '" + RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "") + "'");
                    }
                }

                DataRow[] selectStudent = studentTable.Select(strCourseGroup.ToString());

                Int32 noOfDivisions = 0;

                Int32 noOfPages = 20;

                if (selectStudent.Length > 0)
                {
                    noOfDivisions = selectStudent.Length / noOfPages + (selectStudent.Length % noOfPages != 0 ? 1 : 0);
                }

                for (Int32 index = 0; index < noOfDivisions; index++)
                {
                    pStudentTable.Rows.Clear();

                    pSubjecScheduleTable.Rows.Clear();

                    chargesSummaryTable.Rows.Clear();

                    amountDueTable.Rows.Clear();

                    for (Int32 studentIndex = index * noOfPages; studentIndex < ((index * noOfPages) + noOfPages); studentIndex++)
                    {
                        if (studentIndex >= selectStudent.Length)
                        {
                            break;
                        }

                        DataRow studRow = selectStudent[studentIndex];

                        Decimal totalTutionFee = 0;
                        Decimal totalMiscellaneousFee = 0;
                        Decimal totalOtherFee = 0;
                        Decimal totalLaboratoryFee = 0;
                        Decimal downpayment = 0;
                        Decimal totalCharges = 0;
                        Decimal totalDiscountPayments = 0;
                        Decimal totalBalanceForwarded = 0;
                        Decimal totalReimbursement = 0;

                        if (studRow.RowState != DataRowState.Deleted &&
                            (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_enrolmentlevel", "")) &&
                            !String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_description", ""))))
                        {
                            DataRow newRow = pStudentTable.NewRow();

                            newRow["student_name"] = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(
                                RemoteServerLib.ProcStatic.DataRowConvert(studRow, "last_name", ""),
                                RemoteServerLib.ProcStatic.DataRowConvert(studRow, "first_name", ""),
                                RemoteServerLib.ProcStatic.DataRowConvert(studRow, "middle_name", ""));
                            newRow["student_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "student_id", "");
                            newRow["course_title"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_title", "");
                            newRow["year_level_description"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_level_description", "") + "  " +
                                RemoteServerLib.ProcStatic.DataRowConvert(studRow, "level_section", String.Empty);
                            newRow["sysid_enrolmentlevel"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_enrolmentlevel", "");
                            newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");

                            String sem = String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "semester_description", "")) ? String.Empty :
                                " - " + RemoteServerLib.ProcStatic.DataRowConvert(studRow, "semester_description", "");

                            newRow["year_semester_description"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_description", "") + sem;
                            newRow["notes"] = "This is to certify that " + RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(
                                RemoteServerLib.ProcStatic.DataRowConvert(studRow, "last_name", ""),
                                RemoteServerLib.ProcStatic.DataRowConvert(studRow, "first_name", ""),
                                RemoteServerLib.ProcStatic.DataRowConvert(studRow, "middle_name", "")) +
                                " is cleared of property and financial obligations in this institution.";
                            newRow["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_group_id", "");

                            pStudentTable.Rows.Add(newRow);

                            String strFilterBalanceForwarded = "sysid_student = '" + RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "") + "'";
                            DataRow[] selectBalanceForwarded = balanceForwardedTable.Select(strFilterBalanceForwarded);

                            foreach (DataRow bRow in selectBalanceForwarded)
                            {
                                //if (RemoteServerLib.ProcStatic.DataRowConvert(bRow, "amount", Decimal.Parse("0")) > 0)
                                //{
                                if (RemoteServerLib.ProcStatic.DataRowConvert(bRow, "amount", Decimal.Parse("0")) != 0)
                                {
                                    DataRow newRowBalanceForwarded = chargesSummaryTable.NewRow();

                                    newRowBalanceForwarded["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "sysid_student", "");
                                    newRowBalanceForwarded["charges_description"] = "Balance Forwarded";
                                    newRowBalanceForwarded["text_balance"] = String.Empty;
                                    newRowBalanceForwarded["amount"] = this.GetStringAmount(RemoteServerLib.ProcStatic.DataRowConvert(bRow,
                                        "amount", Decimal.Parse("0")));
                                    newRowBalanceForwarded["total_amount"] = String.Empty;


                                    chargesSummaryTable.Rows.Add(newRowBalanceForwarded);

                                    totalBalanceForwarded = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "amount", Decimal.Parse("0"));
                                    totalCharges += RemoteServerLib.ProcStatic.DataRowConvert(bRow, "amount", Decimal.Parse("0"));
                                }
                                //}

                                break;
                            }

                            String strFilter = "sysid_student = '" + RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "") + "'";
                            DataRow[] selectRowFeeDetails = printingSchoolFeeDetailsTable.Select(strFilter);

                            foreach (DataRow detailsRow in selectRowFeeDetails)
                            {
                                if (CommonExchange.SchoolFeeCategoryId.TuitionFee == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", "") &&
                                (RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_per_year_tuition_fee", false) ||
                                 RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_per_unit_tuition_fee", false) ||
                                 RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_fixed_amount_tuition_fee", false) ||
                                 RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_special_class_tuition_fee", false)))
                                {
                                    totalTutionFee += RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));
                                }
                                else if (CommonExchange.SchoolFeeCategoryId.MiscellaneousFees == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow,
                                    "fee_category_id", ""))
                                {
                                    totalMiscellaneousFee += RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));
                                }
                                else if (CommonExchange.SchoolFeeCategoryId.OtherFees == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", ""))
                                {
                                    totalOtherFee += RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));
                                }
                                else if (CommonExchange.SchoolFeeCategoryId.LaboratoryFees == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow,
                                    "fee_category_id", ""))
                                {
                                    totalLaboratoryFee += RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));
                                }
                            }

                            if (totalTutionFee > 0)
                            {
                                DataRow newRowTuitionFee = chargesSummaryTable.NewRow();

                                newRowTuitionFee["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                                newRowTuitionFee["charges_description"] = "Tuition Fee";
                                newRowTuitionFee["text_balance"] = String.Empty;
                                newRowTuitionFee["amount"] = this.GetStringAmount(totalTutionFee);
                                newRowTuitionFee["total_amount"] = String.Empty;

                                chargesSummaryTable.Rows.Add(newRowTuitionFee);

                                totalCharges += totalTutionFee;
                            }

                            if (totalMiscellaneousFee > 0)
                            {
                                DataRow newRowMiscFee = chargesSummaryTable.NewRow();

                                newRowMiscFee["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                                newRowMiscFee["charges_description"] = "Miscellaneous Fee";
                                newRowMiscFee["text_balance"] = String.Empty;
                                newRowMiscFee["amount"] = this.GetStringAmount(totalMiscellaneousFee);
                                newRowMiscFee["total_amount"] = String.Empty;

                                chargesSummaryTable.Rows.Add(newRowMiscFee);

                                totalCharges += totalMiscellaneousFee;
                            }

                            if (totalOtherFee > 0)
                            {
                                DataRow newRowOtherFee = chargesSummaryTable.NewRow();

                                newRowOtherFee["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                                newRowOtherFee["charges_description"] = "Other Fee";
                                newRowOtherFee["text_balance"] = String.Empty;
                                newRowOtherFee["amount"] = this.GetStringAmount(totalOtherFee);
                                newRowOtherFee["total_amount"] = String.Empty;

                                chargesSummaryTable.Rows.Add(newRowOtherFee);

                                totalCharges += totalOtherFee;
                            }

                            if (totalLaboratoryFee > 0)
                            {
                                DataRow newRowLabFee = chargesSummaryTable.NewRow();

                                newRowLabFee["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                                newRowLabFee["charges_description"] = "Laboratory Fee";
                                newRowLabFee["text_balance"] = String.Empty;
                                newRowLabFee["amount"] = this.GetStringAmount(totalLaboratoryFee);
                                newRowLabFee["total_amount"] = String.Empty;

                                chargesSummaryTable.Rows.Add(newRowLabFee);

                                totalCharges += totalLaboratoryFee;
                            }

                            DataRow[] selectRowPaymentReimbursement = paymentDiscountReimbursementTable.Select(strFilter, "is_reimbursement DESC");

                            Boolean isFirstEntry = true;
                            foreach (DataRow paymentRow in selectRowPaymentReimbursement)
                            {
                                //Code added:: include only if (is_included_in_post == true) :: April 7, 2010
                                if (!RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_balance_forwarded", false) &&
                                    RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_included_in_post", false))
                                {
                                    String remarksDescription = String.Empty;
                                    String paymentDiscountReimbursementDate = !String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "receipt_no", String.Empty)) ?
                                        "(" + RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "receipt_no", String.Empty) + ") :: " : String.Empty;

                                    if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                                        (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_payment", false) &&
                                        !RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false)))
                                    {
                                        remarksDescription = "Payment";
                                    }
                                    else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow,
                                        "remarks_discount_reimbursement_description", "")) &&
                                        RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false))
                                    {
                                        remarksDescription = "Downpayment";

                                        downpayment += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")) +
                                            RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0"));
                                    }
                                    else if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow,
                                        "remarks_discount_reimbursement_description", "")) &&
                                       RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false))
                                    {
                                        remarksDescription = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "");

                                        downpayment += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")) +
                                            RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0"));
                                    }
                                    else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow,
                                        "remarks_discount_reimbursement_description", "")) &&
                                        RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_reimbursement", false))
                                    {
                                        remarksDescription = "Reimbursement";
                                    }
                                    else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow,
                                        "remarks_discount_reimbursement_description", "")) &&
                                        RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_credit_memo", false))
                                    {
                                        remarksDescription = "Credit Memo";
                                    }
                                    else if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow,
                                        "remarks_discount_reimbursement_description", "")))
                                    {
                                        remarksDescription = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "");
                                    }

                                    DateTime pDate;

                                    if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "reflected_date", ""), out pDate))
                                    {
                                        paymentDiscountReimbursementDate += pDate.ToShortDateString();
                                    }

                                    if (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_reimbursement", false))
                                    {
                                        DataRow newRowReimbursement = chargesSummaryTable.NewRow();

                                        newRowReimbursement["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                                        newRowReimbursement["charges_description"] = remarksDescription + " - " + paymentDiscountReimbursementDate;
                                        newRowReimbursement["text_balance"] = String.Empty;
                                        newRowReimbursement["amount"] = this.GetStringAmount(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow,
                                            "amount", Decimal.Parse("0")));
                                        newRowReimbursement["total_amount"] = String.Empty;

                                        chargesSummaryTable.Rows.Add(newRowReimbursement);

                                        totalReimbursement += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0"));
                                        totalCharges += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0"));
                                    }
                                    else
                                    {
                                        if (isFirstEntry)
                                        {
                                            DataRow newRowPaymentDiscount = chargesSummaryTable.NewRow();

                                            newRowPaymentDiscount["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                                            newRowPaymentDiscount["charges_description"] = "       Sub Total";
                                            newRowPaymentDiscount["text_balance"] = String.Empty;
                                            newRowPaymentDiscount["amount"] = String.Empty;
                                            newRowPaymentDiscount["total_amount"] = this.GetStringAmount(totalCharges);

                                            chargesSummaryTable.Rows.Add(newRowPaymentDiscount);

                                            DataRow newLessRow = chargesSummaryTable.NewRow();

                                            newLessRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                                            newLessRow["charges_description"] = "Less:";
                                            newLessRow["text_balance"] = String.Empty;
                                            newLessRow["amount"] = String.Empty;
                                            newLessRow["total_amount"] = String.Empty;

                                            chargesSummaryTable.Rows.Add(newLessRow);

                                            isFirstEntry = false;
                                        }

                                        DataRow newDiscountPaymentRow = chargesSummaryTable.NewRow();

                                        newDiscountPaymentRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                                        newDiscountPaymentRow["charges_description"] = "   " + remarksDescription + " - " + paymentDiscountReimbursementDate;
                                        newDiscountPaymentRow["text_balance"] = String.Empty;
                                        newDiscountPaymentRow["amount"] = "(" + RemoteServerLib.ProcStatic.DataRowConvert(paymentRow,
                                            "amount", Decimal.Parse("0")).ToString("N") + ")";
                                        newDiscountPaymentRow["total_amount"] = String.Empty;

                                        chargesSummaryTable.Rows.Add(newDiscountPaymentRow);

                                        if (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0")) > 0)
                                        {
                                            DataRow newDiscountedAmountRow = chargesSummaryTable.NewRow();

                                            newDiscountedAmountRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                                            newDiscountedAmountRow["charges_description"] = "   Cash Discount - " + paymentDiscountReimbursementDate;
                                            newDiscountedAmountRow["text_balance"] = String.Empty;
                                            newDiscountedAmountRow["amount"] = "(" +
                                                RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0")).ToString("N") + ")";
                                            newDiscountedAmountRow["total_amount"] = String.Empty;

                                            chargesSummaryTable.Rows.Add(newDiscountedAmountRow);
                                        }

                                        totalDiscountPayments += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")) +
                                            RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0"));
                                    }
                                }
                            }

                            if (isFirstEntry)
                            {
                                DataRow newRowPaymentDiscount = chargesSummaryTable.NewRow();

                                newRowPaymentDiscount["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                                newRowPaymentDiscount["charges_description"] = "       Sub Total";
                                newRowPaymentDiscount["text_balance"] = String.Empty;
                                newRowPaymentDiscount["amount"] = String.Empty;
                                newRowPaymentDiscount["total_amount"] = this.GetStringAmount(totalCharges);

                                chargesSummaryTable.Rows.Add(newRowPaymentDiscount);
                            }
                            else
                            {
                                DataRow newTotalDiscountPaymentRow = chargesSummaryTable.NewRow();

                                newTotalDiscountPaymentRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                                newTotalDiscountPaymentRow["charges_description"] = "       Sub Total";
                                newTotalDiscountPaymentRow["text_balance"] = String.Empty;
                                newTotalDiscountPaymentRow["amount"] = String.Empty;
                                newTotalDiscountPaymentRow["total_amount"] = "(" + totalDiscountPayments.ToString("N") + ")";

                                chargesSummaryTable.Rows.Add(newTotalDiscountPaymentRow);
                            }

                            DataRow lineRow = chargesSummaryTable.NewRow();

                            lineRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                            lineRow["charges_description"] = String.Empty;
                            lineRow["text_balance"] = String.Empty;
                            lineRow["amount"] = String.Empty;
                            lineRow["total_amount"] = "_________";

                            chargesSummaryTable.Rows.Add(lineRow);

                            DataRow balanceRow = chargesSummaryTable.NewRow();

                            balanceRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                            balanceRow["charges_description"] = String.Empty;
                            balanceRow["text_balance"] = "Balance";
                            balanceRow["amount"] = String.Empty;
                            balanceRow["total_amount"] = (totalCharges - totalDiscountPayments).ToString("N");

                            chargesSummaryTable.Rows.Add(balanceRow);

                            String strFilterScheduleDetails = "sysid_enrolmentlevel = '" + RemoteServerLib.ProcStatic.DataRowConvert(studRow,
                                "sysid_enrolmentlevel", "") + "'";
                            DataRow[] selectScheduleDetails = printingScheduleDetails.Select(strFilterScheduleDetails);

                            foreach (DataRow dRow in selectScheduleDetails)
                            {
                                DataRow newRowScheduleDetails = pSubjecScheduleTable.NewRow();

                                newRowScheduleDetails["sysid_enrolmentlevel"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_enrolmentlevel", "");

                                String strFilterSched = "sysid_schedule = '" + RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_schedule", "") + "'";
                                DataRow[] selectSubjectSchedule = printingSubjectScheduleTable.Select(strFilterSched);

                                foreach (DataRow subRow in selectSubjectSchedule)
                                {
                                    if (subRow.RowState != DataRowState.Deleted)
                                    {
                                        newRowScheduleDetails["subject_code_title"] = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_code", "") + " - " +
                                            RemoteServerLib.ProcStatic.DataRowConvert(subRow, "descriptive_title", "");
                                    }

                                    break;
                                }

                                pSubjecScheduleTable.Rows.Add(newRowScheduleDetails);
                            }

                            String strFilterSpecialClass = "sysid_student = '" + RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", String.Empty) + "'";
                            DataRow[] selectSpecialClass = printingSpecialClassTable.Select(strFilterSpecialClass);

                            foreach (DataRow specialRow in selectSpecialClass)
                            {
                                DataRow newRowSpecialRow = pSubjecScheduleTable.NewRow();

                                newRowSpecialRow["sysid_enrolmentlevel"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_enrolmentlevel", "");
                                newRowSpecialRow["subject_code_title"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_code", "") + " - " +
                                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "descriptive_title", "");

                                pSubjecScheduleTable.Rows.Add(newRowSpecialRow);
                            }
                        }

                        if (_majorExamScheduleTable != null)
                        {
                            DataRow[] selectMajorExam = _majorExamScheduleTable.Select(strCourseGroup.ToString());

                            Decimal amountToBeAdded = 0;
                            Decimal minimunDownpayment = 0;

                            if (!isSummer)
                            {
                                if (String.Equals(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_id", String.Empty), "CRSE014"))
                                {
                                    amountToBeAdded = this.GetToBeAddedAmount(5000, ref downpayment);
                                    minimunDownpayment = 5000;
                                }
                                else if (String.Equals(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_id", String.Empty), "CRSE012") ||
                                    String.Equals(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_id", String.Empty), "CRSE011"))
                                {
                                    amountToBeAdded = this.GetToBeAddedAmount(3500, ref downpayment);
                                    minimunDownpayment = 3500;
                                }
                                else
                                {
                                    amountToBeAdded = this.GetToBeAddedAmount(2500, ref downpayment);
                                    minimunDownpayment = 2500;
                                }
                            }
                            else
                            {
                                if (String.Equals(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_id", String.Empty), "CRSE014"))
                                {
                                    amountToBeAdded = this.GetToBeAddedAmount(2000, ref downpayment);
                                    minimunDownpayment = 2000;
                                }
                                else
                                {
                                    amountToBeAdded = this.GetToBeAddedAmount(1500, ref downpayment);
                                    minimunDownpayment = 1500;
                                }
                            }

                            amountToBeAdded += totalBalanceForwarded;

                            Decimal acctualAmountDue = 0;

                            if (selectMajorExam.Length > 1)
                            {
                                acctualAmountDue = ((totalTutionFee + totalMiscellaneousFee + totalOtherFee +
                                   totalLaboratoryFee + totalReimbursement) - downpayment) / selectMajorExam.Length;
                            }
                            else if (selectMajorExam.Length == 1)
                            {
                                acctualAmountDue = (totalTutionFee + totalMiscellaneousFee + totalOtherFee + totalLaboratoryFee + totalReimbursement + totalBalanceForwarded);
                            }

                            Decimal totalPayment = 0;
                            String strFilter = "is_downpayment = 0 AND sysid_student = '" +
                                RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "") + "'";
                            DataRow[] selectRow = paymentReimbursementTableTemp.Select(strFilter);

                            foreach (DataRow payRow in selectRow)
                            {
                                DateTime paymentDate = DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(payRow, "reflected_date", String.Empty));

                                //Code added:: include only if (is_included_in_post == true) :: July 6, 2010
                                if (RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_included_in_post", false))
                                {
                                    if (RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_payment", false) ||
                                        RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_discount", false) ||
                                        RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_credit_memo", false))
                                    {
                                        totalPayment += RemoteServerLib.ProcStatic.DataRowConvert(payRow, "amount", Decimal.Parse("0")) +
                                            RemoteServerLib.ProcStatic.DataRowConvert(payRow, "discount_amount", Decimal.Parse("0"));
                                    }
                                }
                            }

                            DateTime previousDateTime = DateTime.MinValue;
                            Decimal amountDuePrevious = 0;
                            Decimal computedAcctualAmountDue = 0;
                            Boolean isFirstEnter = true;

                            foreach (DataRow examRow in selectMajorExam)
                            {
                                Decimal amountDue = 0;

                                DataRow newRowAmountDue = amountDueTable.NewRow();

                                newRowAmountDue["exam_id"] =
                                    RemoteServerLib.ProcStatic.DataRowConvert(examRow, "major_exam_id", Int64.Parse("0"));

                                DateTime dueDate = DateTime.Parse(this.ServerDateTime);

                                if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(examRow, "exam_date", ""), out dueDate))
                                {
                                    TimeSpan oneDay = new TimeSpan(24, 0, 0);

                                    Decimal totalPaymentByTerm = 0;

                                    if (!RemoteServerLib.ProcStatic.DataRowConvert(examRow, "is_clearance_included", false))
                                    {
                                        totalPaymentByTerm = previousDateTime == DateTime.MinValue ?
                                                this.GetTotalPaymentByDateStartEnd(DateTime.Parse(dateStart), dueDate, paymentReimbursementTableTemp,
                                                RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", ""), isFirstEnter) :
                                                this.GetTotalPaymentByDateStartEnd(previousDateTime, dueDate, paymentReimbursementTableTemp,
                                                RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", ""), isFirstEnter);
                                    }
                                    else
                                    {
                                        totalPaymentByTerm = previousDateTime == DateTime.MinValue ?
                                            this.GetTotalPaymentByDateStartEnd(DateTime.Parse(dateStart), DateTime.Parse(dateEnd), paymentReimbursementTableTemp, 
                                            RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", ""), isFirstEnter) :
                                            this.GetTotalPaymentByDateStartEnd(previousDateTime, DateTime.Parse(dateEnd), paymentReimbursementTableTemp,
                                            RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", ""), isFirstEnter);
                                    }

                                    //AD----------------------------
                                    if (!RemoteServerLib.ProcStatic.DataRowConvert(examRow, "is_clearance_included", false))
                                    {
                                        if (isFirstEnter)
                                        {
                                            amountDue = (acctualAmountDue + minimunDownpayment + totalBalanceForwarded) - totalPaymentByTerm;

                                            amountDuePrevious = (acctualAmountDue + minimunDownpayment + totalBalanceForwarded) - totalPaymentByTerm;

                                            isFirstEnter = false;
                                        }
                                        else
                                        {
                                            amountDue = (acctualAmountDue + amountDuePrevious) - totalPaymentByTerm;

                                            amountDuePrevious = (acctualAmountDue + amountDuePrevious) - totalPaymentByTerm;
                                        }
                                    }
                                    else
                                    {
                                        amountDue = (acctualAmountDue + amountDuePrevious) - totalPaymentByTerm;
                                    }
                                    //--------------------------------

                                    previousDateTime = dueDate;
                                }

                                computedAcctualAmountDue += acctualAmountDue;

                                if (RemoteServerLib.ProcStatic.DataRowConvert(examRow, "is_for_print", false))
                                {
                                    isClearanceIncluded = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "is_clearance_included", false);

                                    if (!RemoteServerLib.ProcStatic.DataRowConvert(examRow, "is_clearance_included", false))
                                    {
                                        amountDue = ((amountDue < 0) || (totalPayment > computedAcctualAmountDue + amountToBeAdded)) ? 0 :
                                            (((computedAcctualAmountDue - totalPayment) + amountToBeAdded) < 0 ? 0 :
                                            ((computedAcctualAmountDue - totalPayment) + amountToBeAdded));
                                    }

                                    newRowAmountDue["amount_due"] = amountDue;
                                    newRowAmountDue["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");

                                    amountDueTable.Rows.Add(newRowAmountDue);
                                }
                            }
                        }
                    }

                    pStudentTable.AcceptChanges();
                    pSubjecScheduleTable.AcceptChanges();

                    if (!isClearanceIncluded)
                    {
                        using (ClassStudentLoadingManager.CrystalReport.CrystalStudentStatementOfAccount rptStudentStatementOfAccount =
                            new OfficeServices.ClassStudentLoadingManager.CrystalReport.CrystalStudentStatementOfAccount())
                        {
                            rptStudentStatementOfAccount.Database.Tables["student_table"].SetDataSource(pStudentTable);
                            rptStudentStatementOfAccount.Database.Tables["subject_schedule_details_table"].SetDataSource(pSubjecScheduleTable);
                            rptStudentStatementOfAccount.Database.Tables["charges_summary_table"].SetDataSource(chargesSummaryTable);
                            rptStudentStatementOfAccount.Database.Tables["exam_table"].SetDataSource(examTable);
                            rptStudentStatementOfAccount.Database.Tables["amount_due_table"].SetDataSource(amountDueTable);

                            rptStudentStatementOfAccount.SetParameterValue("@school_name", CommonExchange.SchoolInformation.SchoolName);
                            rptStudentStatementOfAccount.SetParameterValue("@form_name", "Student Statement of Account");
                            rptStudentStatementOfAccount.SetParameterValue("@print_info", "Date/Time Printed: " + DateTime.Parse(_serverDateTime).ToShortDateString() + " " +
                                DateTime.Parse(_serverDateTime).ToShortTimeString() + "         Printed by: " +
                                RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName,
                                userInfo.PersonInfo.FirstName, userInfo.PersonInfo.MiddleName));

                            rptStudentStatementOfAccount.PrintToPrinter(1, false, 0, 0);
                        }
                    }
                    else
                    {

                        //create tables 
                        DataTable lineTable = new DataTable("LineTable");
                        lineTable.Columns.Add("line_id", System.Type.GetType("System.Byte"));
                        lineTable.Columns.Add("col_1", System.Type.GetType("System.String"));
                        lineTable.Columns.Add("col_2", System.Type.GetType("System.String"));
                        lineTable.Columns.Add("col_3", System.Type.GetType("System.String"));
                        lineTable.Columns.Add("col_4", System.Type.GetType("System.String"));
                        lineTable.Columns.Add("col_5", System.Type.GetType("System.String"));

                        DataRow col1 = lineTable.NewRow();

                        col1["line_id"] = 1;
                        col1["col_1"] = "_________________________";
                        col1["col_2"] = "_________________________";
                        col1["col_3"] = "_________________________";
                        col1["col_4"] = "_________________________";
                        col1["col_5"] = "_________________________";

                        lineTable.Rows.Add(col1);

                        DataRow col2 = lineTable.NewRow();

                        col2["line_id"] = 2;
                        col2["col_1"] = "_________________________";
                        col2["col_2"] = "_________________________";
                        col2["col_3"] = "_________________________";
                        col2["col_4"] = String.Empty;
                        col2["col_5"] = String.Empty;

                        lineTable.Rows.Add(col2);

                        DataRow col3 = lineTable.NewRow();

                        col3["line_id"] = 3;
                        col3["col_1"] = "_________________________";
                        col3["col_2"] = "_________________________";
                        col3["col_3"] = String.Empty;
                        col3["col_4"] = String.Empty;
                        col3["col_5"] = String.Empty;

                        lineTable.Rows.Add(col3);

                        DataRow col4 = lineTable.NewRow();

                        col4["line_id"] = 4;
                        col4["col_1"] = "_________________________";
                        col4["col_2"] = String.Empty;
                        col4["col_3"] = String.Empty;
                        col4["col_4"] = String.Empty;
                        col4["col_5"] = String.Empty;

                        lineTable.Rows.Add(col4);

                        DataRow col5 = lineTable.NewRow();

                        col5["line_id"] = 5;
                        col5["col_1"] = String.Empty;
                        col5["col_2"] = String.Empty;
                        col5["col_3"] = "_________________________";
                        col5["col_4"] = String.Empty;
                        col5["col_5"] = String.Empty;

                        lineTable.Rows.Add(col5);
                        //-------------------------
                        DataTable clearanceTable = new DataTable("ClearanceTable");
                        clearanceTable.Columns.Add("course_group_id", System.Type.GetType("System.String"));
                        clearanceTable.Columns.Add("line_id", System.Type.GetType("System.Byte"));
                        clearanceTable.Columns.Add("col_1", System.Type.GetType("System.String"));
                        clearanceTable.Columns.Add("col_2", System.Type.GetType("System.String"));
                        clearanceTable.Columns.Add("col_3", System.Type.GetType("System.String"));
                        clearanceTable.Columns.Add("col_4", System.Type.GetType("System.String"));
                        clearanceTable.Columns.Add("col_5", System.Type.GetType("System.String"));
                        //--------------------------

                        foreach (DataRow groupRow in _classDataSet.Tables["CourseGroupTable"].Rows)
                        {
                            if (CommonExchange.CourseGroupId.College == RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "") ||
                                CommonExchange.CourseGroupId.GraduateSchoolDoctorate == RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", ""))
                            {
                                DataRow row2 = clearanceTable.NewRow();

                                row2["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                                row2["line_id"] = 1;
                                row2["col_1"] = "Library";
                                row2["col_2"] = "Registrar";
                                row2["col_3"] = "Athletic & Prop. Custodian";
                                row2["col_4"] = "Student Affairs Chairperson";
                                row2["col_5"] = "Clinic";

                                clearanceTable.Rows.Add(row2);

                                DataRow row3 = clearanceTable.NewRow();

                                row3["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                                row3["line_id"] = 1;
                                row3["col_1"] = "Adviser / Coordinator";
                                row3["col_2"] = "Guidance";
                                row3["col_3"] = "Christian Formation Office";
                                row3["col_4"] = "Dean";
                                row3["col_5"] = "Finance Officer";

                                clearanceTable.Rows.Add(row3);

                                DataRow row4 = clearanceTable.NewRow();

                                row4["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                                row4["line_id"] = 4;
                                row4["col_1"] = "Alumni Director";
                                row4["col_2"] = String.Empty;
                                row4["col_3"] = String.Empty;
                                row4["col_4"] = String.Empty;
                                row4["col_5"] = String.Empty;

                                clearanceTable.Rows.Add(row4);

                                DataRow row6 = clearanceTable.NewRow();

                                row6["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                                row6["line_id"] = 5;
                                row6["col_1"] = String.Empty;
                                row6["col_2"] = String.Empty;
                                row6["col_3"] = "President";
                                row6["col_4"] = String.Empty;
                                row6["col_5"] = String.Empty;

                                clearanceTable.Rows.Add(row6);
                            }
                            else if (CommonExchange.CourseGroupId.HighSchool == RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", ""))
                            {
                                DataRow row2 = clearanceTable.NewRow();

                                row2["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                                row2["line_id"] = 1;
                                row2["col_1"] = "Religion";
                                row2["col_2"] = "Filipino";
                                row2["col_3"] = "Aral. Pan.";
                                row2["col_4"] = "English";
                                row2["col_5"] = "Science";

                                clearanceTable.Rows.Add(row2);

                                DataRow row4 = clearanceTable.NewRow();

                                row4["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                                row4["line_id"] = 1;
                                row4["col_1"] = "Math";
                                row4["col_2"] = "T.L.E";
                                row4["col_3"] = "MAPEH/CAT";
                                row4["col_4"] = "Club Moderator";
                                row4["col_5"] = "HS Librarian";

                                clearanceTable.Rows.Add(row4);

                                DataRow row6 = clearanceTable.NewRow();

                                row6["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                                row6["line_id"] = 1;
                                row6["col_1"] = "Guidance Counselor";
                                row6["col_2"] = "Club & Orgs. In-Charge";
                                row6["col_3"] = "Class Treasurer";
                                row6["col_4"] = "Class Adviser";
                                row6["col_5"] = "Homeroom In-Charge";

                                clearanceTable.Rows.Add(row6);

                                DataRow row8 = clearanceTable.NewRow();

                                row8["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                                row8["line_id"] = 2;
                                row8["col_1"] = "Science Lab. In-Charge";
                                row8["col_2"] = "Finance Officer";
                                row8["col_3"] = "Alumni Director";
                                row8["col_4"] = String.Empty;
                                row8["col_5"] = String.Empty;

                                clearanceTable.Rows.Add(row8);

                                DataRow row10 = clearanceTable.NewRow();

                                row10["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                                row10["line_id"] = 5;
                                row10["col_1"] = String.Empty;
                                row10["col_2"] = String.Empty;
                                row10["col_3"] = "High School Principal";
                                row10["col_4"] = String.Empty;
                                row10["col_5"] = String.Empty;

                                clearanceTable.Rows.Add(row10);
                            }
                            else if (CommonExchange.CourseGroupId.GradeSchoolKinder == RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", ""))
                            {
                                DataRow row2 = clearanceTable.NewRow();

                                row2["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                                row2["line_id"] = 1;
                                row2["col_1"] = "Religion";
                                row2["col_2"] = "English";
                                row2["col_3"] = "Math";
                                row2["col_4"] = "Filipino";
                                row2["col_5"] = "Science";

                                clearanceTable.Rows.Add(row2);

                                DataRow row4 = clearanceTable.NewRow();

                                row4["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                                row4["line_id"] = 1;
                                row4["col_1"] = "Sibika/HEKASI";
                                row4["col_2"] = "Computer";
                                row4["col_3"] = "MAPE";
                                row4["col_4"] = "HELE";
                                row4["col_5"] = "Class Treasurer";

                                clearanceTable.Rows.Add(row4);

                                DataRow row6 = clearanceTable.NewRow();

                                row6["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                                row6["line_id"] = 1;
                                row6["col_1"] = "AVR In-Charge";
                                row6["col_2"] = "H.E In-Charge";
                                row6["col_3"] = "Guidance In-Charge";
                                row6["col_4"] = "Secretary";
                                row6["col_5"] = "Librarian";

                                clearanceTable.Rows.Add(row6);

                                DataRow row8 = clearanceTable.NewRow();

                                row8["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                                row8["line_id"] = 2;
                                row8["col_1"] = "Class Adviser";
                                row8["col_2"] = "Finance Officer";
                                row8["col_3"] = "Alumni Director";
                                row8["col_4"] = String.Empty;
                                row8["col_5"] = String.Empty;

                                clearanceTable.Rows.Add(row8);

                                DataRow row10 = clearanceTable.NewRow();

                                row10["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                                row10["line_id"] = 5;
                                row10["col_1"] = String.Empty;
                                row10["col_2"] = String.Empty;
                                row10["col_3"] = "Grade School Principal";
                                row10["col_4"] = String.Empty;
                                row10["col_5"] = String.Empty;

                                clearanceTable.Rows.Add(row10);
                            }
                        }

                        using (ClassStudentLoadingManager.CrystalReport.CrystalStudentStatementOfAccountForFinals rptStudentStatementOfAccountForFinals =
                            new OfficeServices.ClassStudentLoadingManager.CrystalReport.CrystalStudentStatementOfAccountForFinals())
                        {
                            rptStudentStatementOfAccountForFinals.Database.Tables["student_table"].SetDataSource(pStudentTable);
                            rptStudentStatementOfAccountForFinals.Database.Tables["subject_schedule_details_table"].SetDataSource(pSubjecScheduleTable);
                            rptStudentStatementOfAccountForFinals.Database.Tables["charges_summary_table"].SetDataSource(chargesSummaryTable);
                            rptStudentStatementOfAccountForFinals.Database.Tables["exam_table"].SetDataSource(examTable);
                            rptStudentStatementOfAccountForFinals.Database.Tables["amount_due_table"].SetDataSource(amountDueTable);
                            rptStudentStatementOfAccountForFinals.Database.Tables["clearance_table"].SetDataSource(clearanceTable);
                            rptStudentStatementOfAccountForFinals.Database.Tables["line_table"].SetDataSource(lineTable);

                            rptStudentStatementOfAccountForFinals.SetParameterValue("@school_name", CommonExchange.SchoolInformation.SchoolName);
                            rptStudentStatementOfAccountForFinals.SetParameterValue("@form_name", "Student Statement of Account");
                            rptStudentStatementOfAccountForFinals.SetParameterValue("@print_info", "Date/Time Printed: " + DateTime.Parse(_serverDateTime).ToShortDateString() + " " +
                                DateTime.Parse(_serverDateTime).ToShortTimeString() + "         Printed by: " +
                                RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName,
                                userInfo.PersonInfo.FirstName, userInfo.PersonInfo.MiddleName));

                            rptStudentStatementOfAccountForFinals.PrintToPrinter(1, false, 0, 0);
                        }
                    }
                }
            }

            pgbBase.Style = ProgressBarStyle.Blocks;
        }//-----------------------------

        //this procedure will print student statement of account
        public void PrintStudentStatementOfAccount(CommonExchange.SysAccess userInfo, String studentSysId, String schoolYear, 
            String sysIdEnrolmentLevel, String sysIdFeeLevel, String enrolmentCourseSysId, DateTime dateStart, DateTime dateEnd, Boolean isSummer)
        {
            //tables of printing
            DataTable pStudentTable = new DataTable("StudentTable");
            pStudentTable.Columns.Add("student_name", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("student_id", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("course_title", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("year_level_description", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("sysid_enrolmentlevel", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("sysid_student", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("year_Semester_description", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("notes", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("course_group_id", System.Type.GetType("System.String"));

            DataTable pSubjecScheduleTable = new DataTable("ScheduleDetailsTable");        
            pSubjecScheduleTable.Columns.Add("day_time", System.Type.GetType("System.String"));
            pSubjecScheduleTable.Columns.Add("room", System.Type.GetType("System.String"));
            pSubjecScheduleTable.Columns.Add("section", System.Type.GetType("System.String"));
            pSubjecScheduleTable.Columns.Add("instructor", System.Type.GetType("System.String"));
            pSubjecScheduleTable.Columns.Add("sysid_enrolmentlevel", System.Type.GetType("System.String"));
            pSubjecScheduleTable.Columns.Add("subject_code_title", System.Type.GetType("System.String"));
            pSubjecScheduleTable.Columns.Add("subject_lecture_units", System.Type.GetType("System.String"));
            pSubjecScheduleTable.Columns.Add("subject_lab_units", System.Type.GetType("System.String"));
            pSubjecScheduleTable.Columns.Add("subject_no_hours", System.Type.GetType("System.String"));            

            DataTable chargesSummaryTable = new DataTable("ChargesSummaryTable");
            chargesSummaryTable.Columns.Add("sysid_student", System.Type.GetType("System.String"));
            chargesSummaryTable.Columns.Add("charges_description", System.Type.GetType("System.String"));
            chargesSummaryTable.Columns.Add("text_balance", System.Type.GetType("System.String"));
            chargesSummaryTable.Columns.Add("amount", System.Type.GetType("System.String"));
            chargesSummaryTable.Columns.Add("total_amount", System.Type.GetType("System.String"));

            DataTable examTable = new DataTable("ExamTable");
            examTable.Columns.Add("exam_id", System.Type.GetType("System.Int64"));
            examTable.Columns.Add("exam_date", System.Type.GetType("System.String"));
            examTable.Columns.Add("exam_description", System.Type.GetType("System.String"));
            examTable.Columns.Add("course_group_id", System.Type.GetType("System.String"));

            DataTable amountDueTable = new DataTable("AmountDueTable");
            amountDueTable.Columns.Add("exam_id", System.Type.GetType("System.Int64"));
            amountDueTable.Columns.Add("amount_due", System.Type.GetType("System.Decimal"));
            amountDueTable.Columns.Add("sysid_student", System.Type.GetType("System.String"));
            //------------------------

            chargesSummaryTable.Clear();

            String strCourseId = String.Empty;

            if (_studentTable != null)
            {
                String strFilter = "sysid_student = '" + studentSysId + "'";
                DataRow[] selectRow = _studentTable.Select(strFilter);

                foreach (DataRow studRow in selectRow)
                {
                    DataRow newRow = pStudentTable.NewRow();

                    newRow["student_name"] = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(
                        RemoteServerLib.ProcStatic.DataRowConvert(studRow, "last_name", ""),
                        RemoteServerLib.ProcStatic.DataRowConvert(studRow, "first_name", ""),
                        RemoteServerLib.ProcStatic.DataRowConvert(studRow, "middle_name", ""));
                    newRow["student_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "student_id", "");
                    newRow["course_title"] = this.GetCourseTitleCourseGroup(enrolmentCourseSysId);
                    newRow["year_level_description"] = this.GetYearLevelDescriptionCourseGroup(sysIdFeeLevel, true) + "  " +
                        RemoteServerLib.ProcStatic.DataRowConvert(studRow, "level_section", String.Empty);
                    newRow["sysid_enrolmentlevel"] = sysIdEnrolmentLevel;
                    newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                    newRow["year_semester_description"] = schoolYear;
                    newRow["notes"] = "This is to certify that " + RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(
                           RemoteServerLib.ProcStatic.DataRowConvert(studRow, "last_name", ""),
                           RemoteServerLib.ProcStatic.DataRowConvert(studRow, "first_name", ""),
                           RemoteServerLib.ProcStatic.DataRowConvert(studRow, "middle_name", "")) + 
                           " is cleared of property and financial obligations in this institution.";
                    newRow["course_group_id"] = this.GetYearLevelDescriptionCourseGroup(sysIdFeeLevel, false);

                    pStudentTable.Rows.Add(newRow);

                    strCourseId = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_id", String.Empty);

                    break;
                }
            }

            if (_studentLoadTable != null)
            {   
                foreach (DataRow loadRow in _studentLoadTable.Rows)
                {
                    if (loadRow.RowState != DataRowState.Deleted)
                    {
                        String strFilter = "sysid_schedule = '" + RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "sysid_schedule", "") + "'";
                        DataRow[] selectScheduleDetails = _subjectScheduleDetailsTable.Select(strFilter);

                        foreach (DataRow schedRow in selectScheduleDetails)
                        {
                            DataRow newRow = pSubjecScheduleTable.NewRow();

                            newRow["sysid_enrolmentlevel"] = sysIdEnrolmentLevel;

                            String strFilterSched = "sysid_schedule = '" + RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "sysid_schedule", "") + "'";
                            DataRow[] selectSubjectSchedule = _subjectScheduleTable.Select(strFilter);

                            foreach (DataRow subRow in selectSubjectSchedule)
                            {
                                if (subRow.RowState != DataRowState.Deleted)
                                {
                                    newRow["subject_code_title"] = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_code", "") + " - " +
                                        RemoteServerLib.ProcStatic.DataRowConvert(subRow, "descriptive_title", "");

                                    break;
                                }
                            }

                            pSubjecScheduleTable.Rows.Add(newRow);
                        }
                    }
                }
            }

            if (_specialClassTable != null)
            {
                foreach (DataRow specialRow in _specialClassTable.Rows)
                {
                    if (specialRow.RowState != DataRowState.Deleted)
                    {
                        DataRow newRow = pSubjecScheduleTable.NewRow();

                        newRow["sysid_enrolmentlevel"] = sysIdEnrolmentLevel;
                        newRow["subject_code_title"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_code", "") + " - " +
                                       RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "descriptive_title", "");

                        pSubjecScheduleTable.Rows.Add(newRow);
                    }
                }
            }
            

            pStudentTable.AcceptChanges();
            pSubjecScheduleTable.AcceptChanges();

            Decimal totalTutionFee = 0;
            Decimal totalMiscellaneousFee = 0;
            Decimal totalOtherFee = 0;
            Decimal totalLaboratoryFee = 0;
            Decimal downpayment = 0;
            Decimal totalCharges = 0;
            Decimal totalDiscountPayments = 0;
            Decimal totalBalanceForwarded = 0;
            Decimal totalReimbursement = 0;

            foreach (DataRow bRow in _balanceForwardedTable.Rows)
            {
                //if (RemoteServerLib.ProcStatic.DataRowConvert(bRow, "amount", Decimal.Parse("0")) > 0)
                //{
                if (RemoteServerLib.ProcStatic.DataRowConvert(bRow, "amount", Decimal.Parse("0")) != 0)
                {
                    DataRow newRow = chargesSummaryTable.NewRow();

                    newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "sysid_student", "");
                    newRow["charges_description"] = "Balance Forwarded";
                    newRow["text_balance"] = String.Empty;
                    newRow["amount"] = this.GetStringAmount(RemoteServerLib.ProcStatic.DataRowConvert(bRow, "amount", Decimal.Parse("0")));
                    newRow["total_amount"] = String.Empty;

                    chargesSummaryTable.Rows.Add(newRow);

                    totalBalanceForwarded = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "amount", Decimal.Parse("0"));
                    totalCharges += RemoteServerLib.ProcStatic.DataRowConvert(bRow, "amount", Decimal.Parse("0"));
                }
                //}

                break;
            }

            if (_schoolFeeDetailsTable != null)
            {
                foreach (DataRow detailsRow in _schoolFeeDetailsTable.Rows)
                {
                    if (detailsRow.RowState != DataRowState.Deleted)
                    {
                        if (CommonExchange.SchoolFeeCategoryId.TuitionFee == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", "") &&
                        (RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_per_year_tuition_fee", false) ||
                         RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_per_unit_tuition_fee", false) ||
                         RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_fixed_amount_tuition_fee", false) ||
                         RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_special_class_tuition_fee", false)))
                        {
                            totalTutionFee += RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));
                        }
                        else if (CommonExchange.SchoolFeeCategoryId.MiscellaneousFees == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, 
                            "fee_category_id", ""))
                        {
                            totalMiscellaneousFee += RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));
                        }
                        else if (CommonExchange.SchoolFeeCategoryId.OtherFees == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", ""))
                        {
                            totalOtherFee += RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));
                        }
                        else if (CommonExchange.SchoolFeeCategoryId.LaboratoryFees == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", ""))
                        {
                            totalLaboratoryFee += RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));
                        }                        
                    }
                }
            }

            if (totalTutionFee > 0)
            {
                DataRow newRow = chargesSummaryTable.NewRow();

                newRow["sysid_student"] = studentSysId;
                newRow["charges_description"] = "Tuition Fee";
                newRow["text_balance"] = String.Empty;
                newRow["amount"] = this.GetStringAmount(totalTutionFee);
                newRow["total_amount"] = String.Empty;

                chargesSummaryTable.Rows.Add(newRow);

                totalCharges += totalTutionFee;
            }

            if (totalMiscellaneousFee > 0)
            {
                DataRow newRow = chargesSummaryTable.NewRow();

                newRow["sysid_student"] = studentSysId;
                newRow["charges_description"] = "Miscellaneous Fee";
                newRow["text_balance"] = String.Empty;
                newRow["amount"] = this.GetStringAmount(totalMiscellaneousFee);
                newRow["total_amount"] = String.Empty;

                chargesSummaryTable.Rows.Add(newRow);

                totalCharges += totalMiscellaneousFee;
            }

            if (totalOtherFee > 0)
            {
                DataRow newRow = chargesSummaryTable.NewRow();

                newRow["sysid_student"] = studentSysId;
                newRow["charges_description"] = "Other Fee";
                newRow["text_balance"] = String.Empty;
                newRow["amount"] = this.GetStringAmount(totalOtherFee);
                newRow["total_amount"] = String.Empty;

                chargesSummaryTable.Rows.Add(newRow);

                totalCharges += totalOtherFee;
            }

            if (totalLaboratoryFee > 0)
            {
                DataRow newRow = chargesSummaryTable.NewRow();

                newRow["sysid_student"] = studentSysId;
                newRow["charges_description"] = "Laboratory Fee";
                newRow["text_balance"] = String.Empty;
                newRow["amount"] = this.GetStringAmount(totalLaboratoryFee);
                newRow["total_amount"] = String.Empty;

                chargesSummaryTable.Rows.Add(newRow);

                totalCharges += totalLaboratoryFee;
            }

            DataRow[] selectPaymentReimbursement = _paymentReimbursementTable.Select(String.Empty, "is_reimbursement DESC");

            Boolean isFirstEntry = true;
            foreach (DataRow paymentRow in selectPaymentReimbursement)
            {
                //Code added:: include only if (is_included_in_post == true) :: April 7, 2010
                if (!RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_balance_forwarded", false) &&
                    RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_included_in_post", false))
                {
                    String remarksDescription = String.Empty;
                    String paymentDiscountReimbursementDate = !String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "receipt_no", String.Empty)) ?
                        "(" + RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "receipt_no", String.Empty) + ") :: " : String.Empty;

                    if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                        (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_payment", false) &&
                        !RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false)))
                    {
                        remarksDescription = "Payment";
                    }
                    else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                        RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false))
                    {
                        remarksDescription = "Downpayment";

                        downpayment += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")) +
                            RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0"));
                    }
                    else if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                       RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false))
                    {
                        remarksDescription = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "");

                        downpayment += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")) +
                            RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0"));
                    }
                    else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                        RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_reimbursement", false))
                    {
                        remarksDescription = "Reimbursement";
                    }
                    else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                           RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_credit_memo", false))
                    {
                        remarksDescription = "Credit Memo";
                    }
                    else if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")))
                    {
                        remarksDescription = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "");
                    }

                    DateTime pDate;

                    if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "received_date", ""), out pDate))
                    {
                        paymentDiscountReimbursementDate += pDate.ToShortDateString();
                    }

                    if (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_reimbursement", false))
                    {
                        DataRow newRow = chargesSummaryTable.NewRow();

                        newRow["sysid_student"] = studentSysId;
                        newRow["charges_description"] = remarksDescription + " - " + paymentDiscountReimbursementDate;
                        newRow["text_balance"] = String.Empty;
                        newRow["amount"] = this.GetStringAmount(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")));
                        newRow["total_amount"] = String.Empty;

                        chargesSummaryTable.Rows.Add(newRow);

                        totalReimbursement += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0"));
                        totalCharges += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0"));
                    }
                    else
                    {
                        if (isFirstEntry)
                        {
                            DataRow newRow = chargesSummaryTable.NewRow();

                            newRow["sysid_student"] = studentSysId;
                            newRow["charges_description"] = "       Sub Total";
                            newRow["text_balance"] = String.Empty;
                            newRow["amount"] = String.Empty;
                            newRow["total_amount"] = this.GetStringAmount(totalCharges);

                            chargesSummaryTable.Rows.Add(newRow);

                            DataRow newLessRow = chargesSummaryTable.NewRow();

                            newLessRow["sysid_student"] = studentSysId;
                            newLessRow["charges_description"] = "Less:";
                            newLessRow["text_balance"] = String.Empty;
                            newLessRow["amount"] = String.Empty;
                            newLessRow["total_amount"] = String.Empty;

                            chargesSummaryTable.Rows.Add(newLessRow);

                            isFirstEntry = false;
                        }

                        DataRow newDiscountPaymentRow = chargesSummaryTable.NewRow();

                        newDiscountPaymentRow["sysid_student"] = studentSysId;
                        newDiscountPaymentRow["charges_description"] = "   " + remarksDescription + " - " + paymentDiscountReimbursementDate;
                        newDiscountPaymentRow["text_balance"] = String.Empty;
                        newDiscountPaymentRow["amount"] = "(" + RemoteServerLib.ProcStatic.DataRowConvert(paymentRow,
                            "amount", Decimal.Parse("0")).ToString("N") + ")";
                        newDiscountPaymentRow["total_amount"] = String.Empty;

                        chargesSummaryTable.Rows.Add(newDiscountPaymentRow);

                        if (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0")) > 0)
                        {
                            DataRow newDiscountedAmountRow = chargesSummaryTable.NewRow();

                            newDiscountedAmountRow["sysid_student"] = studentSysId; 
                            newDiscountedAmountRow["charges_description"] = "   Cash Discount - " + paymentDiscountReimbursementDate;
                            newDiscountedAmountRow["text_balance"] = String.Empty;
                            newDiscountedAmountRow["amount"] = "(" +
                                RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0")).ToString("N") + ")";
                            newDiscountedAmountRow["total_amount"] = String.Empty;

                            chargesSummaryTable.Rows.Add(newDiscountedAmountRow);
                        }

                        totalDiscountPayments += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")) +
                            RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0"));
                    }
                }
            }

            if (isFirstEntry)
            {
                DataRow newRowPaymentDiscount = chargesSummaryTable.NewRow();

                newRowPaymentDiscount["sysid_student"] = studentSysId;
                newRowPaymentDiscount["charges_description"] = "       Sub Total";
                newRowPaymentDiscount["text_balance"] = String.Empty;
                newRowPaymentDiscount["amount"] = String.Empty;
                newRowPaymentDiscount["total_amount"] = this.GetStringAmount(totalCharges);

                chargesSummaryTable.Rows.Add(newRowPaymentDiscount);
            }
            else
            {
                DataRow newTotalDiscountPaymentRow = chargesSummaryTable.NewRow();

                newTotalDiscountPaymentRow["sysid_student"] = studentSysId;
                newTotalDiscountPaymentRow["charges_description"] = "       Sub Total";
                newTotalDiscountPaymentRow["text_balance"] = String.Empty;
                newTotalDiscountPaymentRow["amount"] = String.Empty;
                newTotalDiscountPaymentRow["total_amount"] = "(" + totalDiscountPayments.ToString("N") + ")";

                chargesSummaryTable.Rows.Add(newTotalDiscountPaymentRow);
            }           

            DataRow lineRow = chargesSummaryTable.NewRow();

            lineRow["sysid_student"] = studentSysId;
            lineRow["charges_description"] = String.Empty;
            lineRow["text_balance"] = String.Empty;
            lineRow["amount"] = String.Empty;
            lineRow["total_amount"] = "_________";

            chargesSummaryTable.Rows.Add(lineRow);

            DataRow balanceRow = chargesSummaryTable.NewRow();

            balanceRow["sysid_student"] = studentSysId;
            balanceRow["charges_description"] = String.Empty;
            balanceRow["text_balance"] = "Balance";
            balanceRow["amount"] = String.Empty;
            balanceRow["total_amount"] = (totalCharges - totalDiscountPayments).ToString("N");

            chargesSummaryTable.Rows.Add(balanceRow);

            Boolean isClearanceIncluded = false;

            if (_majorExamScheduleTable != null)
            {
                //create temporary table for payment reimbursement table
                DataTable paymentReimbursementTableTemp = new DataTable("TemporaryTable");
                paymentReimbursementTableTemp.Columns.Add("payment_discount_reimbursement_id", System.Type.GetType("System.String"));
                paymentReimbursementTableTemp.Columns.Add("reflected_date", System.Type.GetType("System.DateTime"));
                paymentReimbursementTableTemp.Columns.Add("amount", System.Type.GetType("System.Decimal"));
                paymentReimbursementTableTemp.Columns.Add("discount_amount", System.Type.GetType("System.Decimal"));
                paymentReimbursementTableTemp.Columns.Add("is_payment", System.Type.GetType("System.Boolean"));
                paymentReimbursementTableTemp.Columns.Add("is_discount", System.Type.GetType("System.Boolean"));
                paymentReimbursementTableTemp.Columns.Add("is_downpayment", System.Type.GetType("System.Boolean"));
                paymentReimbursementTableTemp.Columns.Add("is_credit_memo", System.Type.GetType("System.Boolean"));
                paymentReimbursementTableTemp.Columns.Add("is_included_in_post", System.Type.GetType("System.Boolean"));

                foreach (DataRow payRow in _paymentReimbursementTable.Rows)
                {
                    DataRow newRow = paymentReimbursementTableTemp.NewRow();

                    newRow["payment_discount_reimbursement_id"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "payment_discount_reimbursement_id", "");

                    DateTime pDate = DateTime.Parse(this.ServerDateTime);

                    if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(payRow, "reflected_date", ""), out pDate))
                    {
                        newRow["reflected_date"] = pDate;
                    }

                    newRow["amount"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "amount", Decimal.Parse("0"));
                    newRow["discount_amount"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "discount_amount", Decimal.Parse("0"));
                    newRow["is_payment"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_payment", false);
                    newRow["is_discount"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_discount", false);
                    newRow["is_downpayment"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_downpayment", false);
                    newRow["is_credit_memo"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_credit_memo", false);
                    newRow["is_included_in_post"] = RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_included_in_post", false);

                    paymentReimbursementTableTemp.Rows.Add(newRow);
                }
                //------------------------

                StringBuilder strCourseGroup = new StringBuilder();

                Boolean hasEnter = false;
                foreach (DataRow groupRow in _majorExamScheduleTable.Rows)
                {
                    if (!hasEnter && RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "is_for_print", false))
                    {
                        strCourseGroup.Append("course_group_id = '" + RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "") + "'");

                        hasEnter = true;
                    }
                    else if (hasEnter && RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "is_for_print", false))
                    {
                        strCourseGroup.Append(" OR course_group_id = '" + RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "") + "'");
                    }
                }

                DataRow[] selectMajorExam = _majorExamScheduleTable.Select(strCourseGroup.ToString());

                Decimal amountToBeAdded = 0;
                Decimal minimunDownpayment = 0;


                if (!isSummer)
                {
                    if (String.Equals(strCourseId, "CRSE014"))
                    {
                        amountToBeAdded = this.GetToBeAddedAmount(5000, ref downpayment);
                        minimunDownpayment = 5000;
                    }
                    else if (String.Equals(strCourseId, "CRSE012") || String.Equals(strCourseId, "CRSE011"))
                    {
                        amountToBeAdded = this.GetToBeAddedAmount(3500, ref downpayment);
                        minimunDownpayment = 3500;
                    }
                    else
                    {
                        amountToBeAdded = this.GetToBeAddedAmount(2500, ref downpayment);
                        minimunDownpayment = 2500;
                    }
                }
                else
                {
                    if (String.Equals(strCourseId, "CRSE014"))
                    {
                        amountToBeAdded = this.GetToBeAddedAmount(2000, ref downpayment);
                        minimunDownpayment = 2000;
                    }
                    else
                    {
                        amountToBeAdded = this.GetToBeAddedAmount(1500, ref downpayment);
                        minimunDownpayment = 1500;
                    }
                }

                amountToBeAdded += totalBalanceForwarded;

                Decimal acctualAmountDue = 0;

                if (selectMajorExam.Length > 1)
                {
                    acctualAmountDue = ((totalTutionFee + totalMiscellaneousFee + totalOtherFee +
                       totalLaboratoryFee + totalReimbursement) - downpayment) / selectMajorExam.Length;
                }
                else if (selectMajorExam.Length == 1)
                {
                    acctualAmountDue = (totalTutionFee + totalMiscellaneousFee + totalOtherFee + totalLaboratoryFee + totalReimbursement + totalBalanceForwarded);
                }

                Decimal totalPayment = 0;
                String strFilter = "is_downpayment = 0";
                DataRow[] selectRow = paymentReimbursementTableTemp.Select(strFilter);

                foreach (DataRow payRow in selectRow)
                {
                    DateTime paymentDate = DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(payRow, "reflected_date", String.Empty));

                    //Code added:: include only if (is_included_in_post == true) :: July 6, 2010
                    if (RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_included_in_post", false))
                    {
                        if (RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_payment", false) ||
                            RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_discount", false) ||
                            RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_credit_memo", false))
                        {
                            totalPayment += RemoteServerLib.ProcStatic.DataRowConvert(payRow, "amount", Decimal.Parse("0")) +
                                RemoteServerLib.ProcStatic.DataRowConvert(payRow, "discount_amount", Decimal.Parse("0"));
                        }
                    }
                }

                DateTime previousDateTime = DateTime.MinValue;
                Decimal amountDuePrevious = 0;
                Decimal computedAcctualAmountDue = 0;
                Boolean isFirstEnter = true;

                foreach (DataRow examRow in selectMajorExam)
                {
                    Decimal amountDue = 0;

                    DataRow newRowExam = examTable.NewRow();
                    DataRow newRowAmountDue = amountDueTable.NewRow();

                    newRowExam["exam_id"] = newRowAmountDue["exam_id"] = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "major_exam_id", Int64.Parse("0"));

                    DateTime dueDate = DateTime.Parse(this.ServerDateTime);

                    if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(examRow, "exam_date", ""), out dueDate))
                    {
                        TimeSpan oneDay = new TimeSpan(24, 0, 0);
                        
                        newRowExam["exam_date"] = dueDate.Subtract(oneDay).ToLongDateString();

                        Decimal totalPaymentByTerm = 0;

                        if (!RemoteServerLib.ProcStatic.DataRowConvert(examRow, "is_clearance_included", false))
                        {
                            totalPaymentByTerm = previousDateTime == DateTime.MinValue ?
                                    this.GetTotalPaymentByDateStartEnd(dateStart, dueDate, paymentReimbursementTableTemp, isFirstEnter) :
                                    this.GetTotalPaymentByDateStartEnd(previousDateTime, dueDate, paymentReimbursementTableTemp, isFirstEnter);
                        }
                        else
                        {
                            totalPaymentByTerm = previousDateTime == DateTime.MinValue ?
                                this.GetTotalPaymentByDateStartEnd(dateStart, dateEnd, paymentReimbursementTableTemp, isFirstEnter) :
                                this.GetTotalPaymentByDateStartEnd(previousDateTime, dateEnd, paymentReimbursementTableTemp, isFirstEnter);
                        }


                        //AD----------------------------
                        if (!RemoteServerLib.ProcStatic.DataRowConvert(examRow, "is_clearance_included", false))
                        {
                            if (isFirstEnter)
                            {
                                amountDue = (acctualAmountDue + minimunDownpayment + totalBalanceForwarded) - totalPaymentByTerm;

                                amountDuePrevious = (acctualAmountDue + minimunDownpayment + totalBalanceForwarded) - totalPaymentByTerm;

                                isFirstEnter = false;
                            }
                            else
                            {
                                amountDue = (acctualAmountDue + amountDuePrevious) - totalPaymentByTerm;

                                amountDuePrevious = (acctualAmountDue + amountDuePrevious) - totalPaymentByTerm;
                            }
                        }
                        else
                        {
                            amountDue = (acctualAmountDue + amountDuePrevious) - totalPaymentByTerm;
                        }
                        //--------------------------------

                        previousDateTime = dueDate;
                    }

                    computedAcctualAmountDue += acctualAmountDue;

                    if (RemoteServerLib.ProcStatic.DataRowConvert(examRow, "is_for_print", false))
                    {
                        isClearanceIncluded = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "is_clearance_included", false);

                        if (!RemoteServerLib.ProcStatic.DataRowConvert(examRow, "is_clearance_included", false))
                        {
                            amountDue = ((amountDue < 0) || (totalPayment > computedAcctualAmountDue + amountToBeAdded)) ? 0 :
                                (((computedAcctualAmountDue - totalPayment) + amountToBeAdded) < 0 ? 0 :
                                ((computedAcctualAmountDue - totalPayment) + amountToBeAdded));
                        }

                        newRowExam["exam_description"] = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "exam_description", "");
                        newRowExam["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "course_group_id", "");
                        
                        newRowAmountDue["amount_due"] = amountDue;
                        newRowAmountDue["sysid_student"] = studentSysId;

                        examTable.Rows.Add(newRowExam);
                        amountDueTable.Rows.Add(newRowAmountDue);
                    }
                }
            }
            
            if (!isClearanceIncluded)
            {
                using (ClassStudentLoadingManager.CrystalReport.CrystalStudentStatementOfAccount rptStudentStatementOfAccount =
                    new OfficeServices.ClassStudentLoadingManager.CrystalReport.CrystalStudentStatementOfAccount())
                {                         
                    rptStudentStatementOfAccount.Database.Tables["student_table"].SetDataSource(pStudentTable);
                    rptStudentStatementOfAccount.Database.Tables["subject_schedule_details_table"].SetDataSource(pSubjecScheduleTable);
                    rptStudentStatementOfAccount.Database.Tables["charges_summary_table"].SetDataSource(chargesSummaryTable);  
                    rptStudentStatementOfAccount.Database.Tables["amount_due_table"].SetDataSource(amountDueTable);
                    rptStudentStatementOfAccount.Database.Tables["exam_table"].SetDataSource(examTable);

                    rptStudentStatementOfAccount.SetParameterValue("@school_name", CommonExchange.SchoolInformation.SchoolName);
                    rptStudentStatementOfAccount.SetParameterValue("@school_year", schoolYear);
                    rptStudentStatementOfAccount.SetParameterValue("@form_name", "Student Statement of Account");
                    rptStudentStatementOfAccount.SetParameterValue("@print_info", "Date/Time Printed: " + DateTime.Parse(_serverDateTime).ToShortDateString() + " " +
                        DateTime.Parse(_serverDateTime).ToShortTimeString() + "         Printed by: " +
                        RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName,
                        userInfo.PersonInfo.FirstName, userInfo.PersonInfo.MiddleName));

                    using (RemoteClient.CrystalReportViewer frmViewer = new RemoteClient.CrystalReportViewer(rptStudentStatementOfAccount))
                    {
                        frmViewer.Text = "   Student Statement of Account";                        
                        frmViewer.ShowDialog();
                    }
                }
            }
            else
            {                
                //create tables 
                DataTable lineTable = new DataTable("LineTable");
                lineTable.Columns.Add("line_id", System.Type.GetType("System.Byte"));
                lineTable.Columns.Add("col_1", System.Type.GetType("System.String"));
                lineTable.Columns.Add("col_2", System.Type.GetType("System.String"));
                lineTable.Columns.Add("col_3", System.Type.GetType("System.String"));
                lineTable.Columns.Add("col_4", System.Type.GetType("System.String"));
                lineTable.Columns.Add("col_5", System.Type.GetType("System.String"));

                DataRow col1 = lineTable.NewRow();

                col1["line_id"] = 1;
                col1["col_1"] = "_________________________";
                col1["col_2"] = "_________________________";
                col1["col_3"] = "_________________________";
                col1["col_4"] = "_________________________";
                col1["col_5"] = "_________________________";

                lineTable.Rows.Add(col1);

                DataRow col2 = lineTable.NewRow();

                col2["line_id"] = 2;
                col2["col_1"] = "_________________________";
                col2["col_2"] = "_________________________";
                col2["col_3"] = "_________________________";
                col2["col_4"] = String.Empty;
                col2["col_5"] = String.Empty;

                lineTable.Rows.Add(col2);

                DataRow col3 = lineTable.NewRow();

                col3["line_id"] = 3;
                col3["col_1"] = "_________________________";
                col3["col_2"] = "_________________________";
                col3["col_3"] = String.Empty;
                col3["col_4"] = String.Empty;
                col3["col_5"] = String.Empty;

                lineTable.Rows.Add(col3);

                DataRow col4 = lineTable.NewRow();

                col4["line_id"] = 4;
                col4["col_1"] = "_________________________";
                col4["col_2"] = String.Empty;
                col4["col_3"] = String.Empty;
                col4["col_4"] = String.Empty;
                col4["col_5"] = String.Empty;

                lineTable.Rows.Add(col4);

                DataRow col5 = lineTable.NewRow();

                col5["line_id"] = 5;
                col5["col_1"] = String.Empty;
                col5["col_2"] = String.Empty;
                col5["col_3"] = "_________________________";
                col5["col_4"] = String.Empty;
                col5["col_5"] = String.Empty;

                lineTable.Rows.Add(col5);

                //-------------------------
                DataTable clearanceTable = new DataTable("ClearanceTable");
                clearanceTable.Columns.Add("course_group_id", System.Type.GetType("System.String"));
                clearanceTable.Columns.Add("line_id", System.Type.GetType("System.Byte"));
                clearanceTable.Columns.Add("col_1", System.Type.GetType("System.String"));
                clearanceTable.Columns.Add("col_2", System.Type.GetType("System.String"));
                clearanceTable.Columns.Add("col_3", System.Type.GetType("System.String"));
                clearanceTable.Columns.Add("col_4", System.Type.GetType("System.String"));
                clearanceTable.Columns.Add("col_5", System.Type.GetType("System.String"));
                //--------------------------

                foreach (DataRow groupRow in _classDataSet.Tables["CourseGroupTable"].Rows)
                {
                    if (CommonExchange.CourseGroupId.College == RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "") ||
                        CommonExchange.CourseGroupId.GraduateSchoolDoctorate == RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", ""))
                    {
                        DataRow row2 = clearanceTable.NewRow();

                        row2["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                        row2["line_id"] = 1;
                        row2["col_1"] = "Library";
                        row2["col_2"] = "Registrar";
                        row2["col_3"] = "Athletic & Prop. Custodian";
                        row2["col_4"] = "Student Affairs Chairperson";
                        row2["col_5"] = "Clinic";

                        clearanceTable.Rows.Add(row2);

                        DataRow row3 = clearanceTable.NewRow();

                        row3["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                        row3["line_id"] = 1;
                        row3["col_1"] = "Adviser / Coordinator";
                        row3["col_2"] = "Guidance";
                        row3["col_3"] = "Christian Formation Office";
                        row3["col_4"] = "Dean";
                        row3["col_5"] = "Finance Officer";

                        clearanceTable.Rows.Add(row3);

                        DataRow row4 = clearanceTable.NewRow();

                        row4["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                        row4["line_id"] = 4;
                        row4["col_1"] = "Alumni Director";
                        row4["col_2"] = String.Empty;
                        row4["col_3"] = String.Empty;
                        row4["col_4"] = String.Empty;
                        row4["col_5"] = String.Empty;

                        clearanceTable.Rows.Add(row4);

                        DataRow row6 = clearanceTable.NewRow();

                        row6["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                        row6["line_id"] = 5;
                        row6["col_1"] = String.Empty;
                        row6["col_2"] = String.Empty;
                        row6["col_3"] = "President";
                        row6["col_4"] = String.Empty;
                        row6["col_5"] = String.Empty;

                        clearanceTable.Rows.Add(row6);
                    }
                    else if (CommonExchange.CourseGroupId.HighSchool == RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", ""))
                    {
                        DataRow row2 = clearanceTable.NewRow();

                        row2["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                        row2["line_id"] = 1;
                        row2["col_1"] = "Religion";
                        row2["col_2"] = "Filipino";
                        row2["col_3"] = "Aral. Pan.";
                        row2["col_4"] = "English";
                        row2["col_5"] = "Science";

                        clearanceTable.Rows.Add(row2);

                        DataRow row4 = clearanceTable.NewRow();

                        row4["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                        row4["line_id"] = 1;
                        row4["col_1"] = "Math";
                        row4["col_2"] = "T.L.E";
                        row4["col_3"] = "MAPEH/CAT";
                        row4["col_4"] = "Club Moderator";
                        row4["col_5"] = "HS Librarian";

                        clearanceTable.Rows.Add(row4);

                        DataRow row6 = clearanceTable.NewRow();

                        row6["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                        row6["line_id"] = 1;
                        row6["col_1"] = "Guidance Counselor";
                        row6["col_2"] = "Club & Orgs. In-Charge";
                        row6["col_3"] = "Class Treasurer";
                        row6["col_4"] = "Class Adviser";
                        row6["col_5"] = "Homeroom In-Charge";

                        clearanceTable.Rows.Add(row6);

                        DataRow row8 = clearanceTable.NewRow();

                        row8["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                        row8["line_id"] = 2;
                        row8["col_1"] = "Science Lab. In-Charge";
                        row8["col_2"] = "Finance Officer";
                        row8["col_3"] = "Alumni Director";
                        row8["col_4"] = String.Empty;
                        row8["col_5"] = String.Empty;

                        clearanceTable.Rows.Add(row8);

                        DataRow row10 = clearanceTable.NewRow();

                        row10["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                        row10["line_id"] = 5;
                        row10["col_1"] = String.Empty;
                        row10["col_2"] = String.Empty;
                        row10["col_3"] = "High School Principal";
                        row10["col_4"] = String.Empty;
                        row10["col_5"] = String.Empty;

                        clearanceTable.Rows.Add(row10);
                    }
                    else if (CommonExchange.CourseGroupId.GradeSchoolKinder == RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", ""))
                    {
                        DataRow row2 = clearanceTable.NewRow();

                        row2["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                        row2["line_id"] = 1;
                        row2["col_1"] = "Religion";
                        row2["col_2"] = "English";
                        row2["col_3"] = "Math";
                        row2["col_4"] = "Filipino";
                        row2["col_5"] = "Science";

                        clearanceTable.Rows.Add(row2);

                        DataRow row4 = clearanceTable.NewRow();

                        row4["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                        row4["line_id"] = 1;
                        row4["col_1"] = "Sibika/HEKASI";
                        row4["col_2"] = "Computer";
                        row4["col_3"] = "MAPE";
                        row4["col_4"] = "HELE";
                        row4["col_5"] = "Class Treasurer";

                        clearanceTable.Rows.Add(row4);

                        DataRow row6 = clearanceTable.NewRow();

                        row6["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                        row6["line_id"] = 1;
                        row6["col_1"] = "AVR In-Charge";
                        row6["col_2"] = "H.E In-Charge";
                        row6["col_3"] = "Guidance In-Charge";
                        row6["col_4"] = "Secretary";
                        row6["col_5"] = "Librarian";

                        clearanceTable.Rows.Add(row6);

                        DataRow row8 = clearanceTable.NewRow();

                        row8["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                        row8["line_id"] = 2;
                        row8["col_1"] = "Class Adviser";
                        row8["col_2"] = "Finance Officer";
                        row8["col_3"] = "Alumni Director";
                        row8["col_4"] = String.Empty;
                        row8["col_5"] = String.Empty;

                        clearanceTable.Rows.Add(row8);

                        DataRow row10 = clearanceTable.NewRow();

                        row10["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "");
                        row10["line_id"] = 5;
                        row10["col_1"] = String.Empty;
                        row10["col_2"] = String.Empty;
                        row10["col_3"] = "Grade School Principal";
                        row10["col_4"] = String.Empty;
                        row10["col_5"] = String.Empty;

                        clearanceTable.Rows.Add(row10);
                    }
                }

                using (ClassStudentLoadingManager.CrystalReport.CrystalStudentStatementOfAccountForFinals rptStudentStatementOfAccountForFinals =
                    new OfficeServices.ClassStudentLoadingManager.CrystalReport.CrystalStudentStatementOfAccountForFinals())
                {
                    rptStudentStatementOfAccountForFinals.Database.Tables["student_table"].SetDataSource(pStudentTable);
                    rptStudentStatementOfAccountForFinals.Database.Tables["subject_schedule_details_table"].SetDataSource(pSubjecScheduleTable);
                    rptStudentStatementOfAccountForFinals.Database.Tables["charges_summary_table"].SetDataSource(chargesSummaryTable);                    
                    rptStudentStatementOfAccountForFinals.Database.Tables["exam_table"].SetDataSource(examTable);
                    rptStudentStatementOfAccountForFinals.Database.Tables["amount_due_table"].SetDataSource(amountDueTable);
                    rptStudentStatementOfAccountForFinals.Database.Tables["clearance_table"].SetDataSource(clearanceTable);
                    rptStudentStatementOfAccountForFinals.Database.Tables["line_table"].SetDataSource(lineTable);

                    rptStudentStatementOfAccountForFinals.SetParameterValue("@school_name", CommonExchange.SchoolInformation.SchoolName);
                    rptStudentStatementOfAccountForFinals.SetParameterValue("@form_name", "Student Statement of Account");
                    rptStudentStatementOfAccountForFinals.SetParameterValue("@print_info", "Date/Time Printed: " + DateTime.Parse(_serverDateTime).ToShortDateString() + " " +
                        DateTime.Parse(_serverDateTime).ToShortTimeString() + "         Printed by: " +
                        RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName,
                        userInfo.PersonInfo.FirstName, userInfo.PersonInfo.MiddleName));

                    using (RemoteClient.CrystalReportViewer frmViewer = new RemoteClient.CrystalReportViewer(rptStudentStatementOfAccountForFinals))
                    {
                        frmViewer.Text = "   Student Statement of Account";
                        frmViewer.ShowDialog();
                    }
                }
            }
        }//--------------------------

        //this procedure will print student load
        public void PrintStudentLoad(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd, String dateEnding, ToolStripProgressBar pgbBase)
        {
            DataTable printingSubjectScheduleTable = new DataTable("SubjectScheduleTable");
            DataTable printingScheduleDetails = new DataTable("ScheduleDetailsTable");
            DataTable printingSpecialClassTable;
            DataTable printingSchoolFeeDetailsTable;
            DataTable paymentDiscountReimbursementTable;
            DataTable balanceForwardedTable;
            
            //tables of printing
            DataTable pStudentTable = new DataTable("StudentTable");
            pStudentTable.Columns.Add("student_name", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("student_id", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("course_title", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("year_level_description", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("sysid_enrolmentlevel", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("sysid_student", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("year_Semester_description", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("gender_code_code_description", System.Type.GetType("System.String"));

            DataTable pScheduleDetailsTable = new DataTable("ScheduleDetailsTable");
            pScheduleDetailsTable.Columns.Add("day_time", System.Type.GetType("System.String"));
            pScheduleDetailsTable.Columns.Add("room", System.Type.GetType("System.String"));
            pScheduleDetailsTable.Columns.Add("section", System.Type.GetType("System.String"));
            pScheduleDetailsTable.Columns.Add("instructor", System.Type.GetType("System.String"));
            pScheduleDetailsTable.Columns.Add("sysid_enrolmentlevel", System.Type.GetType("System.String"));
            pScheduleDetailsTable.Columns.Add("subject_code_title", System.Type.GetType("System.String"));
            pScheduleDetailsTable.Columns.Add("subject_lecture_units", System.Type.GetType("System.Byte"));
            pScheduleDetailsTable.Columns.Add("subject_lab_units", System.Type.GetType("System.Byte"));
            pScheduleDetailsTable.Columns.Add("subject_no_hours", System.Type.GetType("System.Int32"));
            pScheduleDetailsTable.Columns.Add("subject_no_hours_string", System.Type.GetType("System.String"));

            DataTable pChargesTable = new DataTable("ChargesTable");
            pChargesTable.Columns.Add("sysid_student", System.Type.GetType("System.String"));
            pChargesTable.Columns.Add("sysid_enrolmentlevel", System.Type.GetType("System.String"));
            pChargesTable.Columns.Add("sysid_feedetails", System.Type.GetType("System.String"));
            pChargesTable.Columns.Add("particular_description", System.Type.GetType("System.String"));
            pChargesTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));
            pChargesTable.Columns.Add("fee_category_id", System.Type.GetType("System.String"));
            pChargesTable.Columns.Add("category_description", System.Type.GetType("System.String"));
            pChargesTable.Columns.Add("is_level_increase", System.Type.GetType("System.Boolean"));
            
            DataTable chargesSummaryTable = new DataTable("ChargesSummaryTable");
            chargesSummaryTable.Columns.Add("sysid_student", System.Type.GetType("System.String"));
            chargesSummaryTable.Columns.Add("charges_description", System.Type.GetType("System.String"));
            chargesSummaryTable.Columns.Add("text_balance", System.Type.GetType("System.String"));
            chargesSummaryTable.Columns.Add("amount", System.Type.GetType("System.String"));
            chargesSummaryTable.Columns.Add("total_amount", System.Type.GetType("System.String"));

            DataTable totalBalanceTable = new DataTable("BalanceTable");
            totalBalanceTable.Columns.Add("sysid_student", System.Type.GetType("System.String"));
            totalBalanceTable.Columns.Add("amount", System.Type.GetType("System.String"));
            //------------------------

            chargesSummaryTable.Clear();           
            
            using (RemoteClient.RemCntStudentLoadingManager remClient = new RemoteClient.RemCntStudentLoadingManager())
            {
                balanceForwardedTable = remClient.SelectBySysIDStudentListDateEndingBalanceCarriedForwardStudentLoad(userInfo, 
                    this.GetStudentCourseGroupSystemIdFormat(true, false), this.GetStudentCourseGroupSystemIdFormat(false, true), dateEnding);
            }            

            using (RemoteClient.RemCntStudentLoadingManager remClient = new RemoteClient.RemCntStudentLoadingManager())
            {
                printingSchoolFeeDetailsTable = remClient.SelectBySysIDStudentEnrolmentLevelListSchoolFeeDetailsStudentLoad(userInfo,
                    this.GetStudentCourseGroupSystemIdFormat(true, false), this.GetStudentEnrolmentLevelFormat());
            }

            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                paymentDiscountReimbursementTable = remClient.SelectBySysIDStudentListDateStartEndStudentPaymentsDiscountsReimbursement(userInfo,
                    this.GetStudentCourseGroupSystemIdFormat(true, false), dateStart, dateEnd, _serverDateTime);
            }

            //Boolean hasEnterGenerateTable = false;

            //if (!hasEnterGenerateTable)
            //{
            using (RemoteClient.RemCntStudentLoadingManager remClient = new RemoteClient.RemCntStudentLoadingManager())
            {
                printingSubjectScheduleTable = remClient.SelectBySysIDEnrolmentLevelListSubjectScheduleStudentLoad(userInfo,
                    this.GetStudentEnrolmentLevelFormat(), _serverDateTime);
                printingScheduleDetails = remClient.SelectBySysIDEnrolmentLevelListScheduleDetailsStudentLoad(userInfo,
                    this.GetStudentEnrolmentLevelFormat());         

                pgbBase.Maximum = printingScheduleDetails.Rows.Count + printingSubjectScheduleTable.Rows.Count +
                    printingSchoolFeeDetailsTable.Rows.Count + _studentTable.Rows.Count;
            }

            using (RemoteClient.RemCntSpecialClassManager remClient = new RemoteClient.RemCntSpecialClassManager())
            {
                printingSpecialClassTable = remClient.SelectBySysIDStudentListDateStartEndSpecialClassInformation(userInfo,
                    this.GetStudentCourseGroupSystemIdFormat(true, false), dateStart, dateEnd, _serverDateTime);
            }

            using (RemoteClient.RemCntSubjectSchedulingManager remSubject = new RemoteClient.RemCntSubjectSchedulingManager())
            {
                _dayTimeScheduleTable = remSubject.SelectBySysIDScheduleDetailsListSubjectSchedule(userInfo,
                    this.GetScheduleDetailsSysIdList(printingScheduleDetails, true));
            }

            //    hasEnterGenerateTable = true;
            //}

            if (_studentTable != null)
            {
                foreach (DataRow studRow in _studentTable.Rows)
                {
                    Decimal totalTutionFee = 0;
                    Decimal totalMiscellaneousFee = 0;
                    Decimal totalOtherFee = 0;
                    Decimal totalLaboratoryFee = 0;
                    Decimal downpayment = 0;
                    Decimal totalCharges = 0;
                    Decimal totalDiscountPayments = 0;
                    Decimal totalBalanceForwarded = 0;
                    Decimal totalReimbursement = 0;

                    if (studRow.RowState != DataRowState.Deleted &&
                        (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_enrolmentlevel", "")) &&
                        !String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_description", ""))))
                    {
                        DataRow newRow = pStudentTable.NewRow();

                        newRow["student_name"] = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(
                            RemoteServerLib.ProcStatic.DataRowConvert(studRow, "last_name", ""),
                            RemoteServerLib.ProcStatic.DataRowConvert(studRow, "first_name", ""), String.Empty) + " " +
                            RemoteServerLib.ProcStatic.DataRowConvert(studRow, "middle_name", "");
                        newRow["student_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "student_id", "");
                        newRow["gender_code_code_description"] =
                            !String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "gender_code_code_description", String.Empty)) ?
                            RemoteServerLib.ProcStatic.DataRowConvert(studRow, "gender_code_code_description", String.Empty) :
                            "Unassigned";
                        newRow["course_title"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_title", "");
                        newRow["year_level_description"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_level_description", "");
                        newRow["sysid_enrolmentlevel"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_enrolmentlevel", "");
                        newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");

                        String sem = String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "semester_description", "")) ? String.Empty :
                            " - " + RemoteServerLib.ProcStatic.DataRowConvert(studRow, "semester_description", "");

                        newRow["year_semester_description"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_description", "") + sem;

                        pStudentTable.Rows.Add(newRow);                        

                        String strFilterBalanceForwarded = "sysid_student = '" + RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "") + "'";
                        DataRow[] selectBalanceForwarded = balanceForwardedTable.Select(strFilterBalanceForwarded);

                        foreach (DataRow bRow in selectBalanceForwarded)
                        {
                            //if (RemoteServerLib.ProcStatic.DataRowConvert(bRow, "amount", Decimal.Parse("0")) > 0)
                            //{
                            if (RemoteServerLib.ProcStatic.DataRowConvert(bRow, "amount", Decimal.Parse("0")) != 0)
                            {
                                DataRow newRowBalanceForwarded = chargesSummaryTable.NewRow();

                                newRowBalanceForwarded["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "sysid_student", "");
                                newRowBalanceForwarded["charges_description"] = "Balance Forwarded";
                                newRowBalanceForwarded["text_balance"] = String.Empty;
                                newRowBalanceForwarded["amount"] = this.GetStringAmount(RemoteServerLib.ProcStatic.DataRowConvert(bRow,
                                    "amount", Decimal.Parse("0")));
                                newRowBalanceForwarded["total_amount"] = String.Empty;

                                chargesSummaryTable.Rows.Add(newRowBalanceForwarded);

                                totalBalanceForwarded = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "amount", Decimal.Parse("0"));
                                totalCharges += RemoteServerLib.ProcStatic.DataRowConvert(bRow, "amount", Decimal.Parse("0"));
                            }
                            //}

                            break;
                        }

                        String strFilter = "sysid_student = '" + RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "") + "'";
                        DataRow[] selectRowFeeDetails = printingSchoolFeeDetailsTable.Select(strFilter);                       
                      
                        foreach (DataRow detailsRow in selectRowFeeDetails)
                        {
                            if (CommonExchange.SchoolFeeCategoryId.TuitionFee == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", "") &&
                            (RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_per_year_tuition_fee", false) ||
                             RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_per_unit_tuition_fee", false) ||
                             RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_fixed_amount_tuition_fee", false) ||
                             RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_special_class_tuition_fee", false)))
                            {
                                totalTutionFee += RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));
                            }
                            else if (CommonExchange.SchoolFeeCategoryId.MiscellaneousFees == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow,
                                "fee_category_id", ""))
                            {
                                totalMiscellaneousFee += RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));
                            }
                            else if (CommonExchange.SchoolFeeCategoryId.OtherFees == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", ""))
                            {
                                totalOtherFee += RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));
                            }
                            else if (CommonExchange.SchoolFeeCategoryId.LaboratoryFees == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, 
                                "fee_category_id", ""))
                            {
                                totalLaboratoryFee += RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));
                            }                           
                        }

                        if (totalTutionFee > 0)
                        {
                            DataRow newRowTuitionFee = chargesSummaryTable.NewRow();

                            newRowTuitionFee["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                            newRowTuitionFee["charges_description"] = "Tuition Fee";
                            newRowTuitionFee["text_balance"] = String.Empty;
                            newRowTuitionFee["amount"] = this.GetStringAmount(totalTutionFee);
                            newRowTuitionFee["total_amount"] = String.Empty;

                            chargesSummaryTable.Rows.Add(newRowTuitionFee);

                            totalCharges += totalTutionFee;
                        }

                        if (totalMiscellaneousFee > 0)
                        {
                            DataRow newRowMiscFee = chargesSummaryTable.NewRow();

                            newRowMiscFee["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                            newRowMiscFee["charges_description"] = "Miscellaneous Fee";
                            newRowMiscFee["text_balance"] = String.Empty;
                            newRowMiscFee["amount"] = this.GetStringAmount(totalMiscellaneousFee);
                            newRowMiscFee["total_amount"] = String.Empty;

                            chargesSummaryTable.Rows.Add(newRowMiscFee);

                            totalCharges += totalMiscellaneousFee;
                        }

                        if (totalOtherFee > 0)
                        {
                            DataRow newRowOtherFee = chargesSummaryTable.NewRow();

                            newRowOtherFee["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                            newRowOtherFee["charges_description"] = "Other Fee";
                            newRowOtherFee["text_balance"] = String.Empty;
                            newRowOtherFee["amount"] = this.GetStringAmount(totalOtherFee);
                            newRowOtherFee["total_amount"] = String.Empty;

                            chargesSummaryTable.Rows.Add(newRowOtherFee);

                            totalCharges += totalOtherFee;
                        }

                        if (totalLaboratoryFee > 0)
                        {
                            DataRow newRowLabFee = chargesSummaryTable.NewRow();

                            newRowLabFee["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                            newRowLabFee["charges_description"] = "Laboratory Fee";
                            newRowLabFee["text_balance"] = String.Empty;
                            newRowLabFee["amount"] = this.GetStringAmount(totalLaboratoryFee);
                            newRowLabFee["total_amount"] = String.Empty;

                            chargesSummaryTable.Rows.Add(newRowLabFee);

                            totalCharges += totalLaboratoryFee;
                        }

                        DataRow[] selectRowPaymentReimbursement = paymentDiscountReimbursementTable.Select(strFilter, "is_reimbursement DESC");

                        Boolean isFirstEntry = true;
                        foreach (DataRow paymentRow in selectRowPaymentReimbursement)
                        {
                            //Code added:: include only if (is_included_in_post == true) :: April 7, 2010
                            if (!RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_balance_forwarded", false) &&
                                RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_included_in_post", false))
                            {
                                String remarksDescription = String.Empty;
                                String paymentDiscountReimbursementDate = !String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "receipt_no", String.Empty)) ?
                                    "(" + RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "receipt_no", String.Empty) + ") :: " : String.Empty;

                                if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                                    (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_payment", false) &&
                                    !RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false)))
                                {
                                    remarksDescription = "Payment";
                                }
                                else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, 
                                    "remarks_discount_reimbursement_description", "")) &&
                                    RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false))
                                {
                                    remarksDescription = "Downpayment";

                                    downpayment += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0"));
                                }
                                else if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow,
                                    "remarks_discount_reimbursement_description", "")) &&
                                   RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false))
                                {
                                    remarksDescription = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "");

                                    downpayment += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0"));
                                }
                                else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, 
                                    "remarks_discount_reimbursement_description", "")) &&
                                    RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_reimbursement", false))
                                {
                                    remarksDescription = "Reimbursement";
                                }
                                else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow,
                                    "remarks_discount_reimbursement_description", "")) &&
                                    RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_credit_memo", false))
                                {
                                    remarksDescription = "Credit Memo";
                                }
                                else if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow,
                                    "remarks_discount_reimbursement_description", "")))
                                {
                                    remarksDescription = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "");
                                }

                                DateTime pDate;

                                if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "received_date", ""), out pDate))
                                {
                                    paymentDiscountReimbursementDate += pDate.ToShortDateString();
                                }

                                if (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_reimbursement", false))
                                {
                                    DataRow newRowReimbursement = chargesSummaryTable.NewRow();

                                    newRowReimbursement["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                                    newRowReimbursement["charges_description"] = remarksDescription + " - " + paymentDiscountReimbursementDate;
                                    newRowReimbursement["text_balance"] = String.Empty;
                                    newRowReimbursement["amount"] = this.GetStringAmount(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow,
                                        "amount", Decimal.Parse("0")));
                                    newRowReimbursement["total_amount"] = String.Empty;

                                    chargesSummaryTable.Rows.Add(newRowReimbursement);

                                    totalReimbursement += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0"));
                                    totalCharges += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0"));
                                }
                                else
                                {
                                    if (isFirstEntry)
                                    {
                                        DataRow newRowPaymentDiscount = chargesSummaryTable.NewRow();

                                        newRowPaymentDiscount["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                                        newRowPaymentDiscount["charges_description"] = "       Sub Total";
                                        newRowPaymentDiscount["text_balance"] = String.Empty;
                                        newRowPaymentDiscount["amount"] = String.Empty;
                                        newRowPaymentDiscount["total_amount"] = this.GetStringAmount(totalCharges);

                                        chargesSummaryTable.Rows.Add(newRowPaymentDiscount);

                                        DataRow newLessRow = chargesSummaryTable.NewRow();

                                        newLessRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                                        newLessRow["charges_description"] = "Less:";
                                        newLessRow["text_balance"] = String.Empty;
                                        newLessRow["amount"] = String.Empty;
                                        newLessRow["total_amount"] = String.Empty;

                                        chargesSummaryTable.Rows.Add(newLessRow);

                                        isFirstEntry = false;
                                    }

                                    DataRow newDiscountPaymentRow = chargesSummaryTable.NewRow();

                                    newDiscountPaymentRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                                    newDiscountPaymentRow["charges_description"] = "   " + remarksDescription + " - " + paymentDiscountReimbursementDate;
                                    newDiscountPaymentRow["text_balance"] = String.Empty;
                                    newDiscountPaymentRow["amount"] = "(" + RemoteServerLib.ProcStatic.DataRowConvert(paymentRow,
                                        "amount", Decimal.Parse("0")).ToString("N") + ")";
                                    newDiscountPaymentRow["total_amount"] = String.Empty;

                                    chargesSummaryTable.Rows.Add(newDiscountPaymentRow);

                                    if (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0")) > 0)
                                    {
                                        DataRow newDiscountedAmountRow = chargesSummaryTable.NewRow();

                                        newDiscountedAmountRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                                        newDiscountedAmountRow["charges_description"] = "   Cash Discount - " + paymentDiscountReimbursementDate;
                                        newDiscountedAmountRow["text_balance"] = String.Empty;
                                        newDiscountedAmountRow["amount"] = "(" +
                                            RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0")).ToString("N") + ")";
                                        newDiscountedAmountRow["total_amount"] = String.Empty;

                                        chargesSummaryTable.Rows.Add(newDiscountedAmountRow);
                                    }

                                    totalDiscountPayments += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")) +
                                        RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0"));
                                }
                            }
                        }

                        if (isFirstEntry)
                        {
                            DataRow newRowPaymentDiscount = chargesSummaryTable.NewRow();

                            newRowPaymentDiscount["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                            newRowPaymentDiscount["charges_description"] = "       Sub Total";
                            newRowPaymentDiscount["text_balance"] = String.Empty;
                            newRowPaymentDiscount["amount"] = String.Empty;
                            newRowPaymentDiscount["total_amount"] = this.GetStringAmount(totalCharges);

                            chargesSummaryTable.Rows.Add(newRowPaymentDiscount);
                        }
                        else
                        {
                            DataRow newTotalDiscountPaymentRow = chargesSummaryTable.NewRow();

                            newTotalDiscountPaymentRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                            newTotalDiscountPaymentRow["charges_description"] = "       Sub Total";
                            newTotalDiscountPaymentRow["text_balance"] = String.Empty;
                            newTotalDiscountPaymentRow["amount"] = String.Empty;
                            newTotalDiscountPaymentRow["total_amount"] = "(" + totalDiscountPayments.ToString("N") + ")";

                            chargesSummaryTable.Rows.Add(newTotalDiscountPaymentRow);
                        }
                       
                       
                        DataRow balanceRow = totalBalanceTable.NewRow();

                        balanceRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                        balanceRow["amount"] = (totalCharges - totalDiscountPayments).ToString("N");
                        
                        totalBalanceTable.Rows.Add(balanceRow);                       

                        String strFilterScheduleDetails = "sysid_enrolmentlevel = '" + RemoteServerLib.ProcStatic.DataRowConvert(studRow, 
                            "sysid_enrolmentlevel", "") + "'";
                        DataRow[] selectScheduleDetails = printingScheduleDetails.Select(strFilterScheduleDetails);

                        Int32 index = 0;

                        Boolean hasEnter = false;
                        String sysIdSchedTemp = String.Empty;

                        foreach (DataRow dRow in selectScheduleDetails)
                        {                            
                            String sysIdSchedDetails = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_scheddetails", "");

                            DataRow editRow = printingScheduleDetails.Rows[index];

                            editRow.BeginEdit();

                            String strManulaSched = String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(dRow, "manual_schedule", String.Empty)) ?
                                    "TBA" : RemoteServerLib.ProcStatic.DataRowConvert(dRow, "manual_schedule", String.Empty);

                            String dayTime = String.Empty;

                            if (!RemoteServerLib.ProcStatic.DataRowConvert(dRow, "is_irregular_modular", false))
                            {
                                Boolean isFirstEnter = true;

                                Char[] splitChar = new Char[] { ' ', ';' };
                                String[] rowDayTime = (this.GetDayTimeString(this.GenerateScheduleTable(sysIdSchedDetails),
                                    _classDataSet.Tables["WeekDayTable"], _classDataSet.Tables["WeekTimeTable"]).ToString()).Split(splitChar);

                                foreach (String strSplit in rowDayTime)
                                {
                                    if (isFirstEnter)
                                    {
                                        dayTime += strSplit + " ";

                                        isFirstEnter = false;
                                    }
                                    else if (String.IsNullOrEmpty(strSplit))
                                    {
                                        dayTime += "; ";
                                        isFirstEnter = true;
                                    }
                                    else
                                    {
                                        DateTime dTime = DateTime.MinValue;

                                        if (DateTime.TryParse(strSplit, out dTime))
                                        {
                                            dayTime += dTime.ToShortTimeString();
                                        }
                                        else
                                        {
                                            dayTime += " - ";
                                        }
                                    }
                                }
                            }
                            else
                            {
                                dayTime = "** " + strManulaSched;
                            }

                            editRow["day_time"] = dayTime;

                            //editRow["day_time"] = dayTime = !RemoteServerLib.ProcStatic.DataRowConvert(dRow, "is_irregular_modular", false) ?
                            //        this.GetDayTimeString(this.GenerateScheduleTable(sysIdSchedDetails),
                            //        _classDataSet.Tables["WeekDayTable"], _classDataSet.Tables["WeekTimeTable"]) :
                            //        "** " + strManulaSched; 

                            editRow.EndEdit();

                            index++;

                            printingScheduleDetails.AcceptChanges();

                            String room = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "is_classroom", false) ?
                                RemoteServerLib.ProcStatic.DataRowConvert(dRow, "classroom_code", "") :
                                RemoteServerLib.ProcStatic.DataRowConvert(dRow, "field_room", "");

                            room = String.IsNullOrEmpty(room) ? "TBA" : room;

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

                            DataRow newRowScheduleDetails = pScheduleDetailsTable.NewRow();

                            newRowScheduleDetails["day_time"] = dayTime;
                            newRowScheduleDetails["room"] = room;
                            newRowScheduleDetails["section"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "section", "");
                            newRowScheduleDetails["instructor"] = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(
                                RemoteServerLib.ProcStatic.DataRowConvert(dRow, "last_name", ""), fName, mName);
                            newRowScheduleDetails["sysid_enrolmentlevel"] = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_enrolmentlevel", "");

                            String strFilterSched = "sysid_schedule = '" + RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_schedule", "") + "'";
                            DataRow[] selectSubjectSchedule = printingSubjectScheduleTable.Select(strFilterSched);


                            if (!String.Equals(sysIdSchedTemp, RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_schedule", "")))
                            {
                                sysIdSchedTemp = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_schedule", "");
                                hasEnter = false;
                            }

                            foreach (DataRow subRow in selectSubjectSchedule)
                            {
                                if (subRow.RowState != DataRowState.Deleted)
                                {                                   
                                    if (!hasEnter)
                                    {
                                        Int32 totalNoHours = 0;

                                        DateTime noHours = DateTime.MinValue;

                                        if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_no_hours", ""), out noHours))
                                        {
                                            totalNoHours = noHours.Minute + (noHours.Hour * 60);
                                        }
                                        else if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_no_hours", "")))
                                        {
                                            Int32 hours = 0, minutes = 0, count = 1;

                                            String[] strSplit = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_no_hours", "").Split(':');

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

                                        newRowScheduleDetails["subject_code_title"] = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_code", "") +
                                            " - " + RemoteServerLib.ProcStatic.DataRowConvert(subRow, "descriptive_title", "");
                                        newRowScheduleDetails["subject_lecture_units"] = RemoteServerLib.ProcStatic.DataRowConvert(subRow, 
                                            "subject_lecture_units", Byte.Parse("0"));
                                        newRowScheduleDetails["subject_lab_units"] = RemoteServerLib.ProcStatic.DataRowConvert(subRow, 
                                            "subject_lab_units", Byte.Parse("0"));
                                        newRowScheduleDetails["subject_no_hours_string"] = RemoteServerLib.ProcStatic.DataRowConvert(subRow, 
                                            "subject_no_hours", "");
                                        newRowScheduleDetails["subject_no_hours"] = totalNoHours;
                                    }
                                }

                                hasEnter = true;

                                break;
                            }

                            pScheduleDetailsTable.Rows.Add(newRowScheduleDetails);

                            pgbBase.PerformStep();
                        }

                        String strFilterSpecialClass = "sysid_student = '" + RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", String.Empty) + "'";
                        DataRow[] selectSpecialClassRow = printingSpecialClassTable.Select(strFilter);

                        foreach (DataRow specialRow in selectSpecialClassRow)
                        {
                            DataRow newRowSpecial = pScheduleDetailsTable.NewRow();

                            newRowSpecial["day_time"] = "TBA";
                            newRowSpecial["room"] = "TBA";
                            newRowSpecial["section"] = String.Empty;
                            newRowSpecial["instructor"] = RemoteClient.ProcStatic.GetCompleteNameFullMiddleName(specialRow, "last_name", "first_name", "middle_name");
                            newRowSpecial["sysid_enrolmentlevel"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_enrolmentlevel", String.Empty);
                            newRowSpecial["subject_code_title"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_code", "") + " - " +
                                RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "descriptive_title", "");
                            newRowSpecial["subject_lecture_units"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_lecture_units", Byte.Parse("0"));
                            newRowSpecial["subject_lab_units"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_lab_units", Byte.Parse("0"));
                            newRowSpecial["subject_no_hours_string"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_no_hours", "");

                            pScheduleDetailsTable.Rows.Add(newRowSpecial);
                        }
                    }                   

                        pgbBase.PerformStep();
                }
            }

            if (printingSchoolFeeDetailsTable != null)
            {
                foreach (DataRow detailsRow in printingSchoolFeeDetailsTable.Rows)
                {
                    if (detailsRow.RowState != DataRowState.Deleted &&
                         ((CommonExchange.SchoolFeeCategoryId.TuitionFee == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", "") &&
                        (RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_per_year_tuition_fee", false) ||
                         RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_per_unit_tuition_fee", false) ||
                         RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_fixed_amount_tuition_fee", false) ||
                         RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_special_class_tuition_fee", false))) ||
                        CommonExchange.SchoolFeeCategoryId.MiscellaneousFees == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", "") ||
                        CommonExchange.SchoolFeeCategoryId.OtherFees == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", "") ||
                        CommonExchange.SchoolFeeCategoryId.LaboratoryFees == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", "")))
                    {
                        if (RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0")) > 0)
                        {
                            DataRow newRow = pChargesTable.NewRow();

                            newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "sysid_student", "");
                            newRow["sysid_enrolmentlevel"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "sysid_enrolmentlevel", "");
                            newRow["sysid_feedetails"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "sysid_feedetails", "");
                            newRow["particular_description"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "particular_description", "");
                            newRow["amount"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));
                            newRow["fee_category_id"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", "");
                            newRow["category_description"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "category_description", "");
                            newRow["is_level_increase"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_level_increase", false);

                            pChargesTable.Rows.Add(newRow);
                        }
                    }

                    pgbBase.PerformStep();
                }
            }

            pStudentTable.AcceptChanges();
            pScheduleDetailsTable.AcceptChanges();
            pChargesTable.AcceptChanges();

            using (ClassStudentLoadingManager.CrystalReport.CrystalStudentLoad rptStudentLoad =
                new OfficeServices.ClassStudentLoadingManager.CrystalReport.CrystalStudentLoad())
            {
                rptStudentLoad.Database.Tables["student_table"].SetDataSource(pStudentTable);
                rptStudentLoad.Database.Tables["subject_schedule_details_table"].SetDataSource(pScheduleDetailsTable);
                rptStudentLoad.Database.Tables["charges_table"].SetDataSource(pChargesTable);
                rptStudentLoad.Database.Tables["charges_summary_table"].SetDataSource(chargesSummaryTable);
                rptStudentLoad.Database.Tables["total_balance_table"].SetDataSource(totalBalanceTable);

                rptStudentLoad.SetParameterValue("@school_name", CommonExchange.SchoolInformation.SchoolName);
                rptStudentLoad.SetParameterValue("@address", CommonExchange.SchoolInformation.Address);
                rptStudentLoad.SetParameterValue("@form_name", "Student Enrolment Record");
                rptStudentLoad.SetParameterValue("@print_info", "Date/Time Printed: " + DateTime.Parse(_serverDateTime).ToShortDateString() + " " +
                    DateTime.Parse(_serverDateTime).ToShortTimeString() + "         Printed by: " +
                    RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName, userInfo.PersonInfo.FirstName, 
                    userInfo.PersonInfo.MiddleName));

                using (RemoteClient.CrystalReportViewer frmViewer = new RemoteClient.CrystalReportViewer(rptStudentLoad))
                {
                    frmViewer.Text = "Student Enrolment Record";
                    frmViewer.ShowDialog();
                }
            }
        }//-------------------------------

        //this procedure will print student load
        public void PrintStudentLoad(CommonExchange.SysAccess userInfo, String studentSysId, String schoolYear,
            String sysIdEnrolmentLevel, String enrolmentCourseSysId, String feeLevelSysId)
        {
            //tables of printing
            DataTable pStudentTable = new DataTable("StudentTable");
            pStudentTable.Columns.Add("student_name", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("student_id", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("gender_code_code_description", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("course_title", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("year_level_description", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("sysid_enrolmentlevel", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("sysid_student", System.Type.GetType("System.String"));
            pStudentTable.Columns.Add("year_Semester_description", System.Type.GetType("System.String"));
            
            DataTable pScheduleDetailsTable = new DataTable("ScheduleDetailsTable");
            pScheduleDetailsTable.Columns.Add("day_time", System.Type.GetType("System.String"));
            pScheduleDetailsTable.Columns.Add("room", System.Type.GetType("System.String"));
            pScheduleDetailsTable.Columns.Add("section", System.Type.GetType("System.String"));
            pScheduleDetailsTable.Columns.Add("instructor", System.Type.GetType("System.String"));
            pScheduleDetailsTable.Columns.Add("sysid_enrolmentlevel", System.Type.GetType("System.String"));
            pScheduleDetailsTable.Columns.Add("subject_code_title", System.Type.GetType("System.String"));
            pScheduleDetailsTable.Columns.Add("subject_lecture_units", System.Type.GetType("System.Byte"));
            pScheduleDetailsTable.Columns.Add("subject_lab_units", System.Type.GetType("System.Byte"));
            pScheduleDetailsTable.Columns.Add("subject_no_hours", System.Type.GetType("System.Int32"));
            pScheduleDetailsTable.Columns.Add("subject_no_hours_string", System.Type.GetType("System.String"));

            DataTable pChargesTable = new DataTable("ChargesTable");
            pChargesTable.Columns.Add("sysid_student", System.Type.GetType("System.String"));
            pChargesTable.Columns.Add("sysid_enrolmentlevel", System.Type.GetType("System.String"));
            pChargesTable.Columns.Add("sysid_feedetails", System.Type.GetType("System.String"));
            pChargesTable.Columns.Add("particular_description", System.Type.GetType("System.String"));
            pChargesTable.Columns.Add("amount", System.Type.GetType("System.Decimal"));
            pChargesTable.Columns.Add("fee_category_id", System.Type.GetType("System.String"));
            pChargesTable.Columns.Add("category_description", System.Type.GetType("System.String"));
            pChargesTable.Columns.Add("is_level_increase", System.Type.GetType("System.Boolean"));

            DataTable chargesSummaryTable = new DataTable("ChargesSummaryTable");
            chargesSummaryTable.Columns.Add("sysid_student", System.Type.GetType("System.String"));
            chargesSummaryTable.Columns.Add("charges_description", System.Type.GetType("System.String"));
            chargesSummaryTable.Columns.Add("text_balance", System.Type.GetType("System.String"));
            chargesSummaryTable.Columns.Add("amount", System.Type.GetType("System.String"));
            chargesSummaryTable.Columns.Add("total_amount", System.Type.GetType("System.String"));

            DataTable totalBalanceTable = new DataTable("BalanceTable");
            totalBalanceTable.Columns.Add("sysid_student", System.Type.GetType("System.String"));
            totalBalanceTable.Columns.Add("amount", System.Type.GetType("System.String"));
            //------------------------

            chargesSummaryTable.Clear();

            if (_studentTable != null)
            {
                String strFilter = "sysid_student = '" + studentSysId + "'";
                DataRow[] selectRow = _studentTable.Select(strFilter);

                foreach (DataRow studRow in selectRow)
                {
                    DataRow newRow = pStudentTable.NewRow();

                    newRow["student_name"] = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(
                        RemoteServerLib.ProcStatic.DataRowConvert(studRow, "last_name", ""),
                        RemoteServerLib.ProcStatic.DataRowConvert(studRow, "first_name", ""), String.Empty ) + " " +
                        RemoteServerLib.ProcStatic.DataRowConvert(studRow, "middle_name", "");
                    newRow["student_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "student_id", "");
                    newRow["gender_code_code_description"] = 
                        !String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "gender_code_code_description", String.Empty)) ?
                        RemoteServerLib.ProcStatic.DataRowConvert(studRow, "gender_code_code_description", String.Empty) :
                        "Unassigned";
                    newRow["course_title"] = this.GetCourseTitleCourseGroup(enrolmentCourseSysId);
                    newRow["year_level_description"] = this.GetYearLevelDescriptionCourseGroup(feeLevelSysId, true);
                    newRow["sysid_enrolmentlevel"] = sysIdEnrolmentLevel;
                    newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                    newRow["year_semester_description"] = schoolYear;

                    pStudentTable.Rows.Add(newRow);

                    break;
                }
            }

            if (_studentLoadTable != null)
            {
                foreach (DataRow loadRow in _studentLoadTable.Rows)
                {
                    if (loadRow.RowState != DataRowState.Deleted)
                    {
                        String strFilter = "sysid_schedule = '" + RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "sysid_schedule", "") + "'";
                        DataRow[] selectScheduleDetails = _subjectScheduleDetailsTable.Select(strFilter);

                        Boolean hasEnter = false;

                        foreach (DataRow schedRow in selectScheduleDetails)
                        {
                            String room = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "is_classroom", false) ?
                                RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "classroom_code", "") :
                                RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "field_room", "");
                            room = String.IsNullOrEmpty(room) ? "TBA" : room;

                            String fName = String.Empty;
                            String mName = String.Empty;

                            if (!String.IsNullOrEmpty( RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "first_name", "")))
                            {
                                String temp = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "first_name", "").Substring(0, 1);

                                fName =  RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "first_name", "").Substring(0,1) + ".";
                            }

                            if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "middle_name", "")))
                            {
                                mName = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "middle_name", "").Substring(0, 1) + ".";
                            }

                            DataRow newRow = pScheduleDetailsTable.NewRow();

                            String strManulaSched = String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "manual_schedule", String.Empty)) ?
                                    "TBA" : RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "manual_schedule", String.Empty);

                            String dayTime = String.Empty;

                            if (!RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "is_irregular_modular", false))
                            {
                                Boolean isFirstEnter = true;

                                Char[] splitChar = new Char[] { ' ', ';' };
                                String[] rowDayTime = (RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "day_time", String.Empty).ToString()).Split(splitChar);

                                foreach (String strSplit in rowDayTime)
                                {
                                    if (isFirstEnter)
                                    {
                                        dayTime += strSplit + " ";

                                        isFirstEnter = false;
                                    }
                                    else if (String.IsNullOrEmpty(strSplit))
                                    {
                                        dayTime += "; ";
                                        isFirstEnter = true;
                                    }
                                    else
                                    {
                                        DateTime dTime = DateTime.MinValue;

                                        if (DateTime.TryParse(strSplit, out dTime))
                                        {
                                            dayTime += dTime.ToShortTimeString();
                                        }
                                        else
                                        {
                                            dayTime += " - ";
                                        }
                                    }
                                }
                            }
                            else
                            {
                                dayTime = "** " + strManulaSched;
                            }

                            newRow["day_time"] = dayTime;

                            //newRow["day_time"] = !RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "is_irregular_modular", false) ?
                            //    RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "day_time", "") :
                            //    "** " + strManulaSched;

                            newRow["room"] = room;
                            newRow["section"] = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "section", "");
                            newRow["instructor"] = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(
                                RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "last_name", ""), fName , mName);
                            newRow["sysid_enrolmentlevel"] = sysIdEnrolmentLevel;

                            String strFilterSched = "sysid_schedule = '" + RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "sysid_schedule", "") + "'";
                            DataRow[] selectSubjectSchedule = _subjectScheduleTable.Select(strFilter);

                            foreach (DataRow subRow in selectSubjectSchedule)
                            {
                                if (subRow.RowState != DataRowState.Deleted)
                                {
                                    if (!hasEnter)
                                    {
                                        Int32 totalNoHours = 0;

                                        DateTime noHours = DateTime.MinValue;

                                        if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_no_hours", ""), out noHours))
                                        {
                                            totalNoHours = noHours.Minute + (noHours.Hour * 60);
                                        }
                                        else if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_no_hours", "")))
                                        {
                                            Int32 hours = 0, minutes = 0, count = 1;

                                            String[] strSplit = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_no_hours", "").Split(':');

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

                                        newRow["subject_code_title"] = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_code", "") + " - " +
                                            RemoteServerLib.ProcStatic.DataRowConvert(subRow, "descriptive_title", "");
                                        newRow["subject_lecture_units"] = RemoteServerLib.ProcStatic.DataRowConvert(subRow, 
                                            "subject_lecture_units", Byte.Parse("0"));
                                        newRow["subject_lab_units"] = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_lab_units", Byte.Parse("0"));
                                        newRow["subject_no_hours_string"] = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_no_hours", "");
                                        newRow["subject_no_hours"] = RemoteServerLib.ProcStatic.TwoDigitZero(totalNoHours);

                                    }

                                    hasEnter = true;

                                    break;
                                }
                            }

                            pScheduleDetailsTable.Rows.Add(newRow);
                        }
                    }
                }
            }

            if (_specialClassTable != null)
            {
                foreach (DataRow specialRow in _specialClassTable.Rows)
                {
                     DataRow newRow = pScheduleDetailsTable.NewRow();

                    newRow["day_time"] = "TBA";
                    newRow["room"] = "TBA";
                    newRow["section"] = String.Empty;
                    newRow["instructor"] = RemoteClient.ProcStatic.GetCompleteNameFullMiddleName(specialRow, "last_name", "first_name", "middle_name");
                    newRow["sysid_enrolmentlevel"] = sysIdEnrolmentLevel;
                    newRow["subject_code_title"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_code", "") + " - " +
                        RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "descriptive_title", "");
                    newRow["subject_lecture_units"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_lecture_units", Byte.Parse("0"));
                    newRow["subject_lab_units"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_lab_units", Byte.Parse("0"));
                    newRow["subject_no_hours_string"] = RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_no_hours", "");

                    pScheduleDetailsTable.Rows.Add(newRow);
                }
            }

            Decimal totalTutionFee = 0;
            Decimal totalMiscellaneousFee = 0;
            Decimal totalOtherFee = 0;
            Decimal totalLaboratoryFee = 0;
            Decimal downpayment = 0;
            Decimal totalCharges = 0;
            Decimal totalDiscountPayments = 0;
            Decimal totalBalanceForwarded = 0;
            Decimal totalReimbursement = 0;

            foreach (DataRow bRow in _balanceForwardedTable.Rows)
            {
                //if (RemoteServerLib.ProcStatic.DataRowConvert(bRow, "amount", Decimal.Parse("0")) > 0)
                //{
                if (RemoteServerLib.ProcStatic.DataRowConvert(bRow, "amount", Decimal.Parse("0")) != 0)
                {
                    DataRow newRow = chargesSummaryTable.NewRow();

                    newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "sysid_student", "");
                    newRow["charges_description"] = "Balance Forwarded";
                    newRow["text_balance"] = String.Empty;
                    newRow["amount"] = this.GetStringAmount(RemoteServerLib.ProcStatic.DataRowConvert(bRow, "amount", Decimal.Parse("0")));
                    newRow["total_amount"] = String.Empty;

                    chargesSummaryTable.Rows.Add(newRow);

                    totalBalanceForwarded = RemoteServerLib.ProcStatic.DataRowConvert(bRow, "amount", Decimal.Parse("0"));
                    totalCharges += RemoteServerLib.ProcStatic.DataRowConvert(bRow, "amount", Decimal.Parse("0"));
                }
                //}

                break;
            }            
            
            if (_schoolFeeDetailsTable != null)
            {
                foreach (DataRow detailsRow in _schoolFeeDetailsTable.Rows)
                {
                    if (detailsRow.RowState != DataRowState.Deleted &&
                         ((CommonExchange.SchoolFeeCategoryId.TuitionFee == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", "") &&
                        (RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_per_year_tuition_fee", false) ||
                         RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_per_unit_tuition_fee", false) ||
                         RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_fixed_amount_tuition_fee", false) ||
                         RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_special_class_tuition_fee", false))) ||
                        CommonExchange.SchoolFeeCategoryId.MiscellaneousFees == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", "") ||
                        CommonExchange.SchoolFeeCategoryId.OtherFees == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", "") ||
                        CommonExchange.SchoolFeeCategoryId.LaboratoryFees == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", "")))
                    {
                        if (RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0")) > 0)
                        {
                            DataRow newRow = pChargesTable.NewRow();

                            newRow["sysid_student"] = studentSysId;
                            newRow["sysid_enrolmentlevel"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "sysid_enrolmentlevel", "");
                            newRow["sysid_feedetails"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "sysid_feedetails", "");
                            newRow["particular_description"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "particular_description", "");
                            newRow["amount"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));
                            newRow["fee_category_id"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", "");
                            newRow["category_description"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "category_description", "");
                            newRow["is_level_increase"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_level_increase", false);

                            pChargesTable.Rows.Add(newRow);
                        }

                        if (CommonExchange.SchoolFeeCategoryId.TuitionFee == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", "") &&
                        (RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_per_year_tuition_fee", false) ||
                         RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_per_unit_tuition_fee", false) ||
                         RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_fixed_amount_tuition_fee", false) ||
                         RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_special_class_tuition_fee", false)))
                        {
                            totalTutionFee += RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));
                        }
                        else if (CommonExchange.SchoolFeeCategoryId.MiscellaneousFees == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow,
                            "fee_category_id", ""))
                        {
                            totalMiscellaneousFee += RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));
                        }
                        else if (CommonExchange.SchoolFeeCategoryId.OtherFees == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", ""))
                        {
                            totalOtherFee += RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));
                        }
                        else if (CommonExchange.SchoolFeeCategoryId.LaboratoryFees == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", ""))
                        {
                            totalLaboratoryFee += RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));
                        }
                    }
                }
            }

            if (totalTutionFee > 0)
            {
                DataRow newRow = chargesSummaryTable.NewRow();

                newRow["sysid_student"] = studentSysId;
                newRow["charges_description"] = "Tuition Fee";
                newRow["text_balance"] = String.Empty;
                newRow["amount"] = this.GetStringAmount(totalTutionFee);
                newRow["total_amount"] = String.Empty;

                chargesSummaryTable.Rows.Add(newRow);

                totalCharges += totalTutionFee;
            }

            if (totalMiscellaneousFee > 0)
            {
                DataRow newRow = chargesSummaryTable.NewRow();

                newRow["sysid_student"] = studentSysId;
                newRow["charges_description"] = "Miscellaneous Fee";
                newRow["text_balance"] = String.Empty;
                newRow["amount"] = this.GetStringAmount(totalMiscellaneousFee);
                newRow["total_amount"] = String.Empty;

                chargesSummaryTable.Rows.Add(newRow);

                totalCharges += totalMiscellaneousFee;
            }

            if (totalOtherFee > 0)
            {
                DataRow newRow = chargesSummaryTable.NewRow();

                newRow["sysid_student"] = studentSysId;
                newRow["charges_description"] = "Other Fee";
                newRow["text_balance"] = String.Empty;
                newRow["amount"] = this.GetStringAmount(totalOtherFee);
                newRow["total_amount"] = String.Empty;

                chargesSummaryTable.Rows.Add(newRow);

                totalCharges += totalOtherFee;
            }

            if (totalLaboratoryFee > 0)
            {
                DataRow newRow = chargesSummaryTable.NewRow();

                newRow["sysid_student"] = studentSysId;
                newRow["charges_description"] = "Laboratory Fee";
                newRow["text_balance"] = String.Empty;
                newRow["amount"] = this.GetStringAmount(totalLaboratoryFee);
                newRow["total_amount"] = String.Empty;

                chargesSummaryTable.Rows.Add(newRow);

                totalCharges += totalLaboratoryFee;
            }

            pStudentTable.AcceptChanges();
            pScheduleDetailsTable.AcceptChanges();
            pChargesTable.AcceptChanges();

            DataRow[] selectPaymentReimbursement = _paymentReimbursementTable.Select(String.Empty, "is_reimbursement DESC");

            Boolean isFirstEntry = true;
            foreach (DataRow paymentRow in selectPaymentReimbursement)
            {
                //Code added:: include only if (is_included_in_post == true) :: April 7, 2010
                if (!RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_balance_forwarded", false) &&
                    RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_included_in_post", false))
                {
                    String remarksDescription = String.Empty;
                    String paymentDiscountReimbursementDate = !String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "receipt_no", String.Empty)) ?
                        "(" + RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "receipt_no", String.Empty) + ") :: " : String.Empty;

                    if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                        (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_payment", false) &&
                        !RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false)))
                    {
                        remarksDescription = "Payment";
                    }
                    else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                        RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false))
                    {
                        remarksDescription = "Downpayment";

                        downpayment += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0"));
                    }
                    else if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                       RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false))
                    {
                        remarksDescription = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "");

                        downpayment += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0"));
                    }
                    else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                        RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_reimbursement", false))
                    {
                        remarksDescription = "Reimbursement";
                    }
                    else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                      RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_credit_memo", false))
                    {
                        remarksDescription = "Credit Memo";
                    }
                    else if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")))
                    {
                        remarksDescription = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "");
                    }

                    DateTime pDate;

                    if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "received_date", ""), out pDate))
                    {
                        paymentDiscountReimbursementDate += pDate.ToShortDateString();
                    }

                    if (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_reimbursement", false))
                    {
                        DataRow newRow = chargesSummaryTable.NewRow();

                        newRow["sysid_student"] = studentSysId;
                        newRow["charges_description"] = remarksDescription + " - " + paymentDiscountReimbursementDate;
                        newRow["text_balance"] = String.Empty;
                        newRow["amount"] = this.GetStringAmount(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")));
                        newRow["total_amount"] = String.Empty;

                        chargesSummaryTable.Rows.Add(newRow);

                        totalReimbursement += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0"));
                        totalCharges += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0"));
                    }
                    else
                    {
                        if (isFirstEntry)
                        {
                            DataRow newRow = chargesSummaryTable.NewRow();

                            newRow["sysid_student"] = studentSysId;
                            newRow["charges_description"] = "       Sub Total";
                            newRow["text_balance"] = String.Empty;
                            newRow["amount"] = String.Empty;
                            newRow["total_amount"] = this.GetStringAmount(totalCharges);

                            chargesSummaryTable.Rows.Add(newRow);

                            DataRow newLessRow = chargesSummaryTable.NewRow();

                            newLessRow["sysid_student"] = studentSysId;
                            newLessRow["charges_description"] = "Less:";
                            newLessRow["text_balance"] = String.Empty;
                            newLessRow["amount"] = String.Empty;
                            newLessRow["total_amount"] = String.Empty;

                            chargesSummaryTable.Rows.Add(newLessRow);

                            isFirstEntry = false;
                        }

                        DataRow newDiscountPaymentRow = chargesSummaryTable.NewRow();

                        newDiscountPaymentRow["sysid_student"] = studentSysId;
                        newDiscountPaymentRow["charges_description"] = "   " + remarksDescription + " - " + paymentDiscountReimbursementDate;
                        newDiscountPaymentRow["text_balance"] = String.Empty;
                        newDiscountPaymentRow["amount"] = "(" + RemoteServerLib.ProcStatic.DataRowConvert(paymentRow,
                            "amount", Decimal.Parse("0")).ToString("N") + ")";
                        newDiscountPaymentRow["total_amount"] = String.Empty;

                        chargesSummaryTable.Rows.Add(newDiscountPaymentRow);

                        if (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0")) > 0)
                        {
                            DataRow newDiscountedAmountRow = chargesSummaryTable.NewRow();

                            newDiscountedAmountRow["sysid_student"] = studentSysId;
                            newDiscountedAmountRow["charges_description"] = "   Cash Discount - " + paymentDiscountReimbursementDate;
                            newDiscountedAmountRow["text_balance"] = String.Empty;
                            newDiscountedAmountRow["amount"] = "(" + 
                                RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0")).ToString("N") + ")";
                            newDiscountedAmountRow["total_amount"] = String.Empty;

                            chargesSummaryTable.Rows.Add(newDiscountedAmountRow);
                        }

                        totalDiscountPayments += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")) +
                            RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0"));
                    }
                }
            }

            if (isFirstEntry)
            {
                DataRow newRowPaymentDiscount = chargesSummaryTable.NewRow();

                newRowPaymentDiscount["sysid_student"] = studentSysId;
                newRowPaymentDiscount["charges_description"] = "       Sub Total";
                newRowPaymentDiscount["text_balance"] = String.Empty;
                newRowPaymentDiscount["amount"] = String.Empty;
                newRowPaymentDiscount["total_amount"] = this.GetStringAmount(totalCharges);

                chargesSummaryTable.Rows.Add(newRowPaymentDiscount);
            }
            else
            {
                DataRow newTotalDiscountPaymentRow = chargesSummaryTable.NewRow();

                newTotalDiscountPaymentRow["sysid_student"] = studentSysId;
                newTotalDiscountPaymentRow["charges_description"] = "       Sub Total";
                newTotalDiscountPaymentRow["text_balance"] = String.Empty;
                newTotalDiscountPaymentRow["amount"] = String.Empty;
                newTotalDiscountPaymentRow["total_amount"] = "(" + totalDiscountPayments.ToString("N") + ")";

                chargesSummaryTable.Rows.Add(newTotalDiscountPaymentRow);
            }          

            DataRow balanceRow = totalBalanceTable.NewRow();

            balanceRow["sysid_student"] = studentSysId;
            balanceRow["amount"] = (totalCharges - totalDiscountPayments).ToString("N");

            totalBalanceTable.Rows.Add(balanceRow);

            using (ClassStudentLoadingManager.CrystalReport.CrystalStudentLoad rptStudentLoad =
                new OfficeServices.ClassStudentLoadingManager.CrystalReport.CrystalStudentLoad())
            {
                rptStudentLoad.Database.Tables["student_table"].SetDataSource(pStudentTable);
                rptStudentLoad.Database.Tables["subject_schedule_details_table"].SetDataSource(pScheduleDetailsTable);
                rptStudentLoad.Database.Tables["charges_table"].SetDataSource(pChargesTable);
                rptStudentLoad.Database.Tables["charges_summary_table"].SetDataSource(chargesSummaryTable);
                rptStudentLoad.Database.Tables["total_balance_table"].SetDataSource(totalBalanceTable);

                rptStudentLoad.SetParameterValue("@school_name", CommonExchange.SchoolInformation.SchoolName);
                rptStudentLoad.SetParameterValue("@address", CommonExchange.SchoolInformation.Address);
                rptStudentLoad.SetParameterValue("@form_name", "Student Enrolment Record");
                rptStudentLoad.SetParameterValue("@print_info", "Date/Time Printed: " + DateTime.Parse(_serverDateTime).ToShortDateString() + " " +
                    DateTime.Parse(_serverDateTime).ToShortTimeString() + "         Printed by: " +
                    RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(userInfo.PersonInfo.LastName, 
                    userInfo.PersonInfo.FirstName, userInfo.PersonInfo.MiddleName));

                using (RemoteClient.CrystalReportViewer frmViewer = new RemoteClient.CrystalReportViewer(rptStudentLoad))
                {
                    frmViewer.Text = "Student Enrolment Record";
                    frmViewer.ShowDialog();
                }
            }            
        }//------------------------------
     
        //this procedure will record student subject load
        public void RecordStudentLoad(CommonExchange.SysAccess userInfo, ref CommonExchange.StudentEnrolmentLevel enrolmentLevelInfo, Boolean isEnrolled)
        {
            using (RemoteClient.RemCntStudentEnrolmentManager remClient = new RemoteClient.RemCntStudentEnrolmentManager())
            {
                if (!isEnrolled)
                {
                    remClient.InsertStudentEnrolmentLevel(userInfo, ref enrolmentLevelInfo);
                }
                else
                {
                    remClient.UpdateStudentEnrolmentLevel(userInfo, enrolmentLevelInfo);
                }

                //CREATE temporary student load table for inserting and deleting
                DataTable tempStudentLoadTable = new DataTable("TempStudentLoadTable");
                tempStudentLoadTable.Columns.Add("load_id", System.Type.GetType("System.Int64"));
                tempStudentLoadTable.Columns.Add("sysid_enrolmentlevel", System.Type.GetType("System.String"));
                tempStudentLoadTable.Columns.Add("sysid_schedule", System.Type.GetType("System.String"));
                tempStudentLoadTable.Columns.Add("is_loaded", System.Type.GetType("System.String"));
                tempStudentLoadTable.Columns.Add("is_premature_deloaded", System.Type.GetType("System.Boolean"));
                //END CREATE---------------------------

                Int32 index = 0;

                foreach (DataRow loadRow in _studentLoadTable.Rows)
                {
                    if (loadRow.RowState != DataRowState.Deleted &&
                        (!RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "is_premature_deloaded", false) &&
                        !RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "is_loaded", false)))
                    {
                        DataRow newRow = tempStudentLoadTable.NewRow();

                        newRow["load_id"] = RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "load_id", Int64.Parse("0"));
                        newRow["sysid_enrolmentlevel"] = enrolmentLevelInfo.EnrolmentLevelSysId;
                        newRow["sysid_schedule"] = RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "sysid_schedule", "");
                        newRow["is_loaded"] = true;
                        newRow["is_premature_deloaded"] = RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "is_premature_deloaded", false);

                        tempStudentLoadTable.Rows.Add(newRow);

                        DataRow modRow = tempStudentLoadTable.Rows[index];

                        modRow.AcceptChanges();

                        modRow.BeginEdit();
                        modRow.EndEdit();

                        index++;
                    }
                    else if (loadRow.RowState != DataRowState.Deleted && loadRow.RowState == DataRowState.Added)
                    {
                        DataRow newRow = tempStudentLoadTable.NewRow();

                        newRow["load_id"] = RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "load_id", Int64.Parse("0"));
                        newRow["sysid_enrolmentlevel"] = enrolmentLevelInfo.EnrolmentLevelSysId;
                        newRow["sysid_schedule"] = RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "sysid_schedule", "");
                        newRow["is_loaded"] = true;

                        tempStudentLoadTable.Rows.Add(newRow);

                        index++;
                    }
                    else if (loadRow.RowState == DataRowState.Deleted)
                    {
                        DataRow newRow = tempStudentLoadTable.NewRow();

                        newRow["load_id"] = Int64.Parse(loadRow["load_id", DataRowVersion.Original].ToString());
                        newRow["sysid_enrolmentlevel"] = enrolmentLevelInfo.EnrolmentLevelSysId;
                        newRow["sysid_schedule"] = loadRow["sysid_schedule", DataRowVersion.Original].ToString();
                        newRow["is_loaded"] = false;

                        tempStudentLoadTable.Rows.Add(newRow);

                        DataRow delRow = tempStudentLoadTable.Rows[index];

                        delRow.AcceptChanges();

                        delRow.Delete();

                        index++;
                    }
                }

                using (RemoteClient.RemCntStudentLoadingManager remLoading = new RemoteClient.RemCntStudentLoadingManager())
                {
                    remLoading.InsertUpdateDeleteStudentLoad(userInfo, tempStudentLoadTable);
                }

                _studentLoadTable.Rows.Clear();             
            }

            if (_optionalFeeTable != null)
            {
                Int32 feeIndex = 0;

                foreach (DataRow feeRow in _optionalFeeTable.Rows)
                {
                    if (feeRow.RowState != DataRowState.Deleted && 
                        String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "sysid_enrolmentlevel", String.Empty)))
                    {
                        DataRow editRow = _optionalFeeTable.Rows[feeIndex];

                        editRow.BeginEdit();

                        editRow["sysid_enrolmentlevel"] = enrolmentLevelInfo.EnrolmentLevelSysId;

                        editRow.EndEdit();

                        if (feeRow.RowState == DataRowState.Added)
                        {
                            editRow.AcceptChanges();
                            editRow.SetAdded();
                        }
                    }

                    feeIndex++;
                }
            }
                        
            using (RemoteClient.RemCntSchoolFeeManager remClient = new RemoteClient.RemCntSchoolFeeManager())
            {
                remClient.InsertDeleteStudentOptionalFee(userInfo, _optionalFeeTable);
            }


            foreach (CommonExchange.EnrolmentCourseMajor list in enrolmentLevelInfo.EnrolmentCourseMajorList)
            {
                if (list.IsCurrentMajor)
                {
                    if (_courseMajorTable != null)
                    {
                        Int32 index = 0;

                        foreach (DataRow majorRow in _courseMajorTable.Rows)
                        {
                            if ((list.CourseMajorId == RemoteServerLib.ProcStatic.DataRowConvert(majorRow, "course_major_id", Int64.Parse("0"))) &&
                                RemoteServerLib.ProcStatic.DataRowConvert(majorRow, "is_current_major", false))
                            {
                                DataRow editRow = _courseMajorTable.Rows[index];

                                editRow.BeginEdit();

                                editRow["is_current_major"] = true;

                                editRow.EndEdit();
                            }
                            else
                            {
                                DataRow editRow = _courseMajorTable.Rows[index];

                                editRow.BeginEdit();

                                editRow["is_current_major"] = false;

                                editRow.EndEdit();
                            }

                            index++;
                        }
                    }
                }
            }

            _studentLoadTable.AcceptChanges();
            _optionalFeeTable.AcceptChanges();                        
        }//------------------------------        

        //this procedure will update student enrollment record
        public void UpdateStudentEnrollmentLevel(CommonExchange.SysAccess userInfo, CommonExchange.StudentEnrolmentLevel enrolmentLevelInfo)
        {
            using (RemoteClient.RemCntStudentEnrolmentManager remClient = new RemoteClient.RemCntStudentEnrolmentManager())
            {
                remClient.UpdateStudentEnrolmentLevel(userInfo, enrolmentLevelInfo);
            }
        }//----------------------------

        //this procedure will reaload the withdrawn student load
        public void RealoadWithdrawnStudentLoad(String sysIdSchedule)
        {
            Int32 index = 0;

            foreach (DataRow withdrawnRow in _prematureDeloadedSubjectTable.Rows)
            {
                if (withdrawnRow.RowState != DataRowState.Deleted &&
                    String.Equals(sysIdSchedule, RemoteServerLib.ProcStatic.DataRowConvert(withdrawnRow, "sysid_schedule", String.Empty)))
                {
                    Boolean isExistSubjectLoad = !this.IsExistStudentLoadDeleted(RemoteServerLib.ProcStatic.DataRowConvert(withdrawnRow, "sysid_schedule", String.Empty));

                    if (!isExistSubjectLoad)
                    {
                        DataRow newRow = _studentLoadTable.NewRow();

                        newRow["sysid_schedule"] = RemoteServerLib.ProcStatic.DataRowConvert(withdrawnRow, "sysid_schedule", "");
                        newRow["load_id"] = RemoteServerLib.ProcStatic.DataRowConvert(withdrawnRow, "load_id", Int64.Parse("0"));
                        newRow["is_premature_deloaded"] = false;

                        _studentLoadTable.Rows.Add(newRow);
                    }
                    else
                    {
                        DataRow newRow = _studentLoadTable.NewRow();

                        newRow["sysid_schedule"] = RemoteServerLib.ProcStatic.DataRowConvert(withdrawnRow, "sysid_schedule", "");
                        newRow["load_id"] = RemoteServerLib.ProcStatic.DataRowConvert(withdrawnRow, "load_id", Int64.Parse("0"));
                        newRow["is_premature_deloaded"] = false;

                        _studentLoadTable.Rows.Add(newRow);

                        Int32 loadIndex = 0;

                        foreach (DataRow loadRow in _studentLoadTable.Rows)
                        {
                            if (loadRow.RowState != DataRowState.Deleted &&
                                String.Equals(RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "sysid_schedule", String.Empty), 
                                RemoteServerLib.ProcStatic.DataRowConvert(withdrawnRow, "sysid_schedule", String.Empty)))
                            {
                                DataRow editLoadRow = _studentLoadTable.Rows[loadIndex];

                                editLoadRow.EndEdit();

                                editLoadRow["is_premature_deloaded"] = false;

                                editLoadRow.EndEdit();

                                break;
                            }

                            loadIndex++;
                        }
                    }

                    DataRow delRow = _prematureDeloadedSubjectTable.Rows[index];

                    if (delRow.RowState == DataRowState.Modified || delRow.RowState == DataRowState.Added)
                    {
                        delRow.AcceptChanges();
                    }

                    delRow.Delete();

                    break;
                }

                index++;
            }

            Int32 y = 0;

            foreach (DataRow subRow in _subjectScheduleTable.Rows)
            {
                if (subRow.RowState != DataRowState.Deleted &&
                    String.Equals(sysIdSchedule, RemoteServerLib.ProcStatic.DataRowConvert(subRow, "sysid_schedule", "")))
                {
                    DataRow editRow = _subjectScheduleTable.Rows[y];                   

                    if (RemoteServerLib.ProcStatic.DataRowConvert(editRow, "is_premature_deloaded", false))
                    {
                        DataRow newRow = _subjectScheduleTable.NewRow();

                        newRow["sysid_schedule"] = editRow["sysid_schedule"];
                        newRow["subject_code"] = editRow["subject_code"];
                        newRow["descriptive_title"] = editRow["descriptive_title"];
                        newRow["subject_lecture_units"] = editRow["subject_lecture_units"];
                        newRow["subject_lab_units"] = editRow["subject_lab_units"];
                        newRow["subject_no_hours"] = editRow["subject_no_hours"];
                        newRow["is_premature_deloaded"] = false;
                        newRow["is_loaded_to_student"] = true;

                        _subjectScheduleTable.Rows.Add(newRow);
                    }

                    editRow.Delete();

                    break;
                }

                y++;
            }
        }//--------------------------

        //this procedure will withdraw student subject load
        public void WithdrawStudentSubjectLoad(String sysIdSchedule)
        {
            Int32 index = 0;

            foreach (DataRow loadRow in _studentLoadTable.Rows)
            {
                if (loadRow.RowState != DataRowState.Deleted &&
                    String.Equals(sysIdSchedule, RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "sysid_schedule", "")))
                {
                    DataRow newRow = _prematureDeloadedSubjectTable.NewRow();

                    newRow["sysid_schedule"] = RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "sysid_schedule", "");

                    _prematureDeloadedSubjectTable.Rows.Add(newRow);

                    DataRow delRow = _studentLoadTable.Rows[index];

                    if (delRow.RowState == DataRowState.Modified || delRow.RowState == DataRowState.Added)
                    {
                        delRow.AcceptChanges();
                    }

                    delRow.Delete();
                    
                    break;
                }

                index++;
            }

            Int32 y = 0;

            foreach (DataRow subRow in _subjectScheduleTable.Rows)
            {
                if (subRow.RowState != DataRowState.Deleted &&
                    String.Equals(sysIdSchedule, RemoteServerLib.ProcStatic.DataRowConvert(subRow, "sysid_schedule", "")))
                {
                    DataRow editRow = _subjectScheduleTable.Rows[y];

                    if (!RemoteServerLib.ProcStatic.DataRowConvert(editRow, "is_premature_deloaded", false))
                    {
                        DataRow newRow = _subjectScheduleTable.NewRow();

                        newRow["sysid_schedule"] = editRow["sysid_schedule"];
                        newRow["subject_code"] = editRow["subject_code"];
                        newRow["descriptive_title"] = editRow["descriptive_title"];
                        newRow["subject_lecture_units"] = editRow["subject_lecture_units"];
                        newRow["subject_lab_units"] = editRow["subject_lab_units"];
                        newRow["subject_no_hours"] = editRow["subject_no_hours"];
                        newRow["is_premature_deloaded"] = true;
                        newRow["is_loaded_to_student"] = true;

                        _subjectScheduleTable.Rows.Add(newRow);
                    }                   

                    editRow.Delete();                    

                    break;
                }

                y++;
            }
        }//--------------------------------

        //this procedure will Insert Optional Fee
        public void InsertOptionalFee(String sysIdFeeDetails, String sysIdEnrolmentLevel)
        {
            if (_optionalSchoolFeeDetailsTable != null)
            {
                String strFilter = "sysid_feedetails = '" + sysIdFeeDetails + "'";
                DataRow[] selectRow = _optionalSchoolFeeDetailsTable.Select(strFilter);

                foreach (DataRow feeRow in selectRow)
                {
                    DataRow newRowOptional = _optionalFeeTable.NewRow();
                    DataRow newRowDetails = _schoolFeeDetailsTable.NewRow();

                    newRowOptional["optional_fee_id"] = newRowDetails["optional_fee_id"] = _countOptionalFeeId--;
                    newRowOptional["sysid_enrolmentlevel"] = newRowDetails["sysid_enrolmentlevel"] = sysIdEnrolmentLevel;
                    newRowOptional["sysid_feedetails"] = newRowDetails["sysid_feedetails"] = 
                        RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "sysid_feedetails", "");
                    newRowOptional["is_level_increase"] = newRowDetails["is_level_increase"] = 
                        RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_level_increase", false);
                    newRowOptional["amount"] = newRowDetails["amount"] = 
                        RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "amount", Decimal.Parse("0"));
                    newRowOptional["fee_category_id"] = newRowDetails["fee_category_id"] = 
                        RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "fee_category_id", "");
                    newRowOptional["particular_description"] = newRowDetails["particular_description"] = 
                        RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "particular_description", "");
                    newRowOptional["is_office_access"] = newRowDetails["is_office_access"] = 
                        RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_office_access", false);
                    newRowOptional["is_optional_fee"] = newRowDetails["is_optional_fee"] = true;
                    newRowDetails["category_description"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "category_description", String.Empty);

                    newRowOptional["sysid_feeparticular"] = newRowDetails["sysid_feeparticular"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "sysid_feeparticular", String.Empty);
                   
                    _optionalFeeTable.Rows.Add(newRowOptional);
                    _schoolFeeDetailsTable.Rows.Add(newRowDetails);

                    break;
                }
            }
        }//--------------------------------

        //this procedure will detele student enrolment level
        public void DeleteStudentEnrolmentLevel(CommonExchange.SysAccess userInfo, CommonExchange.StudentEnrolmentLevel enrolmentLevelInfo)
        {
            using (RemoteClient.RemCntStudentEnrolmentManager remClient = new RemoteClient.RemCntStudentEnrolmentManager())
            {
                remClient.DeleteStudentEnrolmentLevel(userInfo, enrolmentLevelInfo);
            }
        }//-----------------------------

        //this procedure will delete optional fee
        public void DeleteOptionalFee(Int64 optionalFeeId)
        {
            if (_optionalFeeTable != null)
            {
                Int32 index = 0;
                
                foreach (DataRow optionalRow in _optionalFeeTable.Rows)
                {
                    if (optionalRow.RowState != DataRowState.Deleted &&
                        optionalFeeId == RemoteServerLib.ProcStatic.DataRowConvert(optionalRow, "optional_fee_id", Int64.Parse("0")))
                    {
                        DataRow delRow = _optionalFeeTable.Rows[index];

                        if (delRow.RowState == DataRowState.Modified || delRow.RowState == DataRowState.Added)
                        {
                            delRow.AcceptChanges();
                        }

                        delRow.Delete();

                        break;
                    }

                    index++;
                }

                index = 0;
               
                foreach (DataRow optionalRow in _schoolFeeDetailsTable.Rows)
                {
                    if (optionalRow.RowState != DataRowState.Deleted &&
                     optionalFeeId == RemoteServerLib.ProcStatic.DataRowConvert(optionalRow, "optional_fee_id", Int64.Parse("0")))
                    {
                        DataRow delRow = _schoolFeeDetailsTable.Rows[index];

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
        }//-------------------------------

        //this procedure gets the student enrolment course by student system id date start and date end
        public void SelectBySysIDStudentDateStartEndStudentEnrolmentCourse(CommonExchange.SysAccess userInfo, 
            String studentSysId, String dateStart, String dateEnd)
        {
            using (RemoteClient.RemCntStudentEnrolmentManager remClient = new RemoteClient.RemCntStudentEnrolmentManager())
            {
                _studentCourseTable = remClient.SelectBySysIDStudentDateStartEndStudentEnrolmentCourse(userInfo, studentSysId, dateStart, dateEnd);                
            }
        }//--------------------------

        //this procedure gets the student enrolment course / level histroy by student system id 
        public void SelectBySysIDStudentForEnrolmentHistoryEnrolmentCourseLevel(CommonExchange.SysAccess userInfo, String studentSysId)
        {
            using (RemoteClient.RemCntStudentEnrolmentManager remClient = new RemoteClient.RemCntStudentEnrolmentManager())
            {
                _studentCourseHistoryTable = remClient.SelectBySysIDStudentForEnrolmentHistoryEnrolmentCourse(userInfo, studentSysId);

                _studentLevelHistroyTable = remClient.SelectBySysIDStudentForEnrolmentHistoryEnrolmentLevel(userInfo, studentSysId);
            }
        }//----------------------------

        //this procedure gets the student enrolment level by student system id, year id, semester id, ismarked deleted level
        public void SelectBySysIDStudentYearIDSemesterStudentEnrolmentLevel(CommonExchange.SysAccess userInfo, String studentSysId,
            String yearId, String sysIdSemester, String sysIdEnrolmentCourse, String enrolmentLevelSysIdExcludeList)
        {
            using (RemoteClient.RemCntStudentEnrolmentManager remClient = new RemoteClient.RemCntStudentEnrolmentManager())
            {
                _studentLevelTable = remClient.SelectBySysIDStudentYearIDSemesterStudentEnrolmentLevel(userInfo, studentSysId, yearId,
                    sysIdSemester, sysIdEnrolmentCourse, true, true, enrolmentLevelSysIdExcludeList);
            }
        }//----------------------------

        //this procedure gets the student enrolment level by student system id, year id, semester id, ismarked deleted level (for change student enrollment level)
        public void SelectBySysIDStudentYearIDSemesterStudentEnrolmentLevelForChangeStudentEnrollmentLevel(CommonExchange.SysAccess userInfo, String studentSysId,
            String yearId, String sysIdSemester, String sysIdEnrolmentCourse, String enrolmentLevelSysIdExcludeList)
        {
            using (RemoteClient.RemCntStudentEnrolmentManager remClient = new RemoteClient.RemCntStudentEnrolmentManager())
            {
                _changeStudentLevelTable = remClient.SelectBySysIDStudentYearIDSemesterStudentEnrolmentLevel(userInfo, studentSysId, yearId,
                    sysIdSemester, sysIdEnrolmentCourse, true, true, enrolmentLevelSysIdExcludeList);
            }
        }//----------------------------

        //this procedure gets the student payment and discount by date start end and student list
        public void SelectBySysIDStudentListDateStartEndStudentPaymentsDiscounts(CommonExchange.SysAccess userInfo, String studentSysIdList,
            String dateStart, String dateEnd)
        {
            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                _paymentReimbursementTable = remClient.SelectBySysIDStudentListDateStartEndStudentPaymentsDiscountsReimbursement(userInfo, 
                    studentSysIdList, dateStart, dateEnd, _serverDateTime);
            }
        }//---------------------------  

        //this procedure gets the balance carried forward by student list and date ending
        public void SelectBySysIDStudentListDateEndingBalanceCarriedForwardStudentLoad(CommonExchange.SysAccess userInfo, String studentSysIdList,
            String enrolmentLevelSysIdList, String dateEnding)
        {
            using (RemoteClient.RemCntStudentLoadingManager remClient = new RemoteClient.RemCntStudentLoadingManager())
            {
                _balanceForwardedTable = remClient.SelectBySysIDStudentListDateEndingBalanceCarriedForwardStudentLoad(userInfo, studentSysIdList,
                    enrolmentLevelSysIdList, dateEnding);
            }
        }//-------------------------

        //this procedure get the school fee details by student, fee level, semester and is graduating student
        public void SelectBySysIDStudentFeeLevelSemesterSchoolFeeDetailsStudentLoad(CommonExchange.SysAccess userInfo, String studentSysId,
            String enrolmentLevelSysId, String feelevelSysId, String semesterSysId, Boolean isGraduateStudent, Boolean isInternational, 
            Boolean isEnrolled, Boolean isMarkedDeleted, Boolean isPreviousCharge)
        {
            using (RemoteClient.RemCntStudentLoadingManager remClient = new RemoteClient.RemCntStudentLoadingManager())
            {
                _schoolFeeDetailsTable = remClient.SelectBySysIDStudentFeeLevelSemesterSchoolFeeDetailsStudentLoad(userInfo, studentSysId, enrolmentLevelSysId,
                    feelevelSysId, semesterSysId, isGraduateStudent, isInternational, isEnrolled, isMarkedDeleted, isPreviousCharge);

                foreach (DataRow feeRow in _schoolFeeDetailsTable.Rows)
                {
                    if (RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_optional_fee", false))
                    {
                        DataRow newRow = _optionalFeeTable.NewRow();

                        newRow["optional_fee_id"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "optional_fee_id", Int64.Parse("0"));
                        newRow["sysid_enrolmentlevel"] = enrolmentLevelSysId;
                        newRow["sysid_feedetails"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "sysid_feedetails", "");
                        newRow["is_level_increase"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_level_increase", false);
                        newRow["amount"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "amount", Decimal.Parse("0"));
                        newRow["fee_category_id"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "fee_category_id", "");
                        newRow["particular_description"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "particular_description", "");
                        newRow["is_office_access"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_office_access", false);
                        newRow["is_optional_fee"] = true;
                
                        _optionalFeeTable.Rows.Add(newRow);
                    }
                }

                _optionalFeeTable.AcceptChanges();
            }
        }//---------------------------------

        //this procedure will get optional school fees
        public void SelectBySysIDStudentFeeLevelSemesterForOptionalFeeDetailsStudentOptionalFee(CommonExchange.SysAccess userInfo, String studentSysId,
            String feeLevelSysId, String semesterSysId, Boolean isInternational)
        {
            using (RemoteClient.RemCntSchoolFeeManager remClient = new RemoteClient.RemCntSchoolFeeManager())
            {
                _optionalSchoolFeeDetailsTable = remClient.SelectBySysIDStudentFeeLevelSemesterForOptionalFeeDetailsStudentOptionalFee(userInfo,
                    studentSysId, feeLevelSysId, semesterSysId, isInternational);
            }
        }//---------------------------

        //this procedure gets the subject schedule details by date start end
        public void SelectBySysIDEnrolmentLevelDateStartEndScheduleDetailsStudentLoad(CommonExchange.SysAccess userInfo, String enrolmentLevelSysId, 
            String dateStart, String dateEnd, String sysIdEnrolmentLeve)
        {
            using (RemoteClient.RemCntStudentLoadingManager remClient = new RemoteClient.RemCntStudentLoadingManager())
            {
                _subjectScheduleDetailsTable = remClient.SelectBySysIDEnrolmentLevelDateStartEndScheduleDetailsStudentLoad(userInfo, 
                    enrolmentLevelSysId, dateStart, dateEnd);

                if (_subjectScheduleDetailsTable != null)
                {
                    using (RemoteClient.RemCntSubjectSchedulingManager remSubject = new RemoteClient.RemCntSubjectSchedulingManager())
                    {
                        _dayTimeScheduleTable = remSubject.SelectBySysIDScheduleDetailsListSubjectSchedule(userInfo, 
                            this.GetScheduleDetailsSysIdList(_subjectScheduleDetailsTable, false));
                    }

                    Int32 index = 0;

                    foreach (DataRow dRow in _subjectScheduleDetailsTable.Rows)
                    {
                        if (dRow.RowState != DataRowState.Deleted)
                        {
                            String sysIdSchedDetails = RemoteServerLib.ProcStatic.DataRowConvert(dRow, "sysid_scheddetails", "");

                            DataRow editRow = _subjectScheduleDetailsTable.Rows[index];

                            editRow.BeginEdit();

                            editRow["day_time"] = this.GetDayTimeString(this.GenerateScheduleTable(sysIdSchedDetails),
                                _classDataSet.Tables["WeekDayTable"], _classDataSet.Tables["WeekTimeTable"]);

                            editRow.EndEdit();
                           
                        }

                        index++;
                    }
                }

                _subjectScheduleDetailsTable.AcceptChanges();
            }
        }//----------------------------

        //this procedure get the special class by student by date start date end
        public void SelectBySysIDStudentListDateStartEndSpecialClassInformation(CommonExchange.SysAccess userInfo, String studentSysIdList,
            String dateStart, String dateEnd)
        {
            using (RemoteClient.RemCntSpecialClassManager remClient = new RemoteClient.RemCntSpecialClassManager())
            {
                _specialClassTable = remClient.SelectBySysIDStudentListDateStartEndSpecialClassInformation(userInfo, studentSysIdList, dateStart,
                    dateEnd, _serverDateTime);
            }
        }//---------------------------------------

        //this procedure gets the subject schedule student load by date start end
        public void SelectBySysIDEnrolmentLevelDateStartEndSubjectScheduleStudentLoad(CommonExchange.SysAccess userInfo, String studentSysId,
            String enrolmentLevelSysId, String feelevelSysId, String semesterSysId, Boolean isGraduateStudent, Boolean isInternational, Boolean isForStudentTab,
            Boolean isEnrolled, String dateStart, String dateEnd)
        {
            using (RemoteClient.RemCntStudentLoadingManager remClient = new RemoteClient.RemCntStudentLoadingManager())
            {
                _subjectScheduleTable = remClient.SelectBySysIDEnrolmentLevelDateStartEndSubjectScheduleStudentLoad(userInfo, studentSysId, enrolmentLevelSysId,
                    feelevelSysId, semesterSysId, isGraduateStudent, isInternational, isEnrolled, isForStudentTab, dateStart, dateEnd, _serverDateTime);
            }
            
            foreach (DataRow schedRow in _subjectScheduleTable.Rows)
            {
                Boolean isLoadedToStudent = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "is_loaded_to_student", false);
                Boolean isPrematureDeloaded = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "is_premature_deloaded", false);

                if (!isLoadedToStudent && !isPrematureDeloaded)
                {
                    Boolean isLocked = false;

                    if (RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "is_semestral", false))
                    {
                        isLocked = RemoteClient.ProcStatic.IsRecordLocked(
                            this.GetSemesterDateStart(RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "year_semester_id", String.Empty)),
                            this.GetSemesterDateEnd(RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "year_semester_id", String.Empty)),
                            DateTime.Parse(this.ServerDateTime), (Int32)CommonExchange.SystemRange.MonthAllowance);
                    }

                    if (!isLocked)
                    {
                        DataRow newRow = _openSubjectTable.NewRow();

                        newRow["sysid_schedule"] = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_schedule", "");
                        newRow["is_loaded_to_student"] = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "is_loaded_to_student", false);

                        _openSubjectTable.Rows.Add(newRow);
                    }
                }
                else if (isLoadedToStudent && !isPrematureDeloaded)
                {
                    DataRow newRow = _loadedSubjectTable.NewRow();
                    DataRow newRowStudentLoad = _studentLoadTable.NewRow();

                    newRow["sysid_schedule"] = newRowStudentLoad["sysid_schedule"] = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_schedule", "");
                    newRow["is_loaded_to_student"] = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "is_loaded_to_student", false);
                    newRowStudentLoad["is_premature_deloaded"] = isPrematureDeloaded;

                    newRowStudentLoad["load_id"] = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "load_id", Int64.Parse("0"));
                    newRowStudentLoad["is_loaded"] = true;

                    foreach (DataRow levelRow in _studentLevelTable.Rows)
                    {
                        if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "sysid_enrolmentlevel", "")))
                        {
                            newRowStudentLoad["sysid_enrolmentlevel"] = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "sysid_enrolmentlevel", "");

                            break;
                        }
                    }

                    _loadedSubjectTable.Rows.Add(newRow);
                    _studentLoadTable.Rows.Add(newRowStudentLoad);
                }
                else if (isLoadedToStudent && isPrematureDeloaded)
                {
                    DataRow newRow = _prematureDeloadedSubjectTable.NewRow();

                    newRow["sysid_schedule"] = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_schedule", "");
                    newRow["load_id"] = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "load_id", Int64.Parse("0"));
                    newRow["is_loaded_to_student"] = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "is_loaded_to_student", false);

                    _prematureDeloadedSubjectTable.Rows.Add(newRow);
                }              
            }

            _studentLoadTable.AcceptChanges();
        }//-----------------------------       

        //this procedure will intialize major exam schedule table
        public void SelectMajorExamScheduleTable(CommonExchange.SysAccess userInfo, String dateStart, String dateEnd, 
            String courseGroupList, Boolean isMultiplePrint)
        {
            DataTable tempTable = new DataTable("TempTable");

            if (isMultiplePrint)
            {
                courseGroupList = this.GetStudentCourseGroupSystemIdFormat(false, false);
            }

            using (RemoteClient.RemCntMajorExamScheduleManager remClient = new RemoteClient.RemCntMajorExamScheduleManager())
            {
                tempTable = remClient.SelectMajorExamSchedule(userInfo, dateStart, dateEnd, courseGroupList, String.Empty, _serverDateTime);
            }

            _majorExamScheduleTable.Clear();

            foreach (DataRow examRow in tempTable.Rows)
            {
                DataRow newRow = _majorExamScheduleTable.NewRow();

                newRow["major_exam_id"] = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "major_exam_id", Int64.Parse("0")).ToString();

                DateTime eDate;

                if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(examRow, "exam_date", ""), out eDate))
                {
                    newRow["exam_date"] = eDate.ToLongDateString();
                }

                newRow["exam_description"] = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "exam_description", "") + " - " +
                    RemoteServerLib.ProcStatic.DataRowConvert(examRow, "group_description", "");
                newRow["is_for_print"] = false;
                newRow["is_clearance_included"] = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "is_clearance_included", false);
                newRow["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "course_group_id", "");

                _majorExamScheduleTable.Rows.Add(newRow);
            }
        }//----------------------------

        //this procedure will select student course major
        public void SelectByCourseIDSysIDEnrolmentLevelEnrolmentCourseMajor(CommonExchange.SysAccess userInfo, String studentSysId, String courseId,
            String enrolmentLevelSysId)
        {
            using (RemoteClient.RemCntStudentEnrolmentManager remClient = new RemoteClient.RemCntStudentEnrolmentManager())
            {
                _courseMajorTable = remClient.SelectByCourseIDSysIDEnrolmentLevelEnrolmentCourseMajor(userInfo, studentSysId, courseId, enrolmentLevelSysId);
            }
        }//--------------------------

        //this procedure will select student informtion by student id (for transcript)
        public void SelectStudentInformation(CommonExchange.SysAccess userInfo, String studentId)
        {
            if (!String.IsNullOrEmpty(studentId))
            {
                using (RemoteClient.RemCntStudentManager remClient = new RemoteClient.RemCntStudentManager())
                {
                    _studentTable = remClient.SelectStudentInformation(userInfo, studentId, String.Empty, String.Empty, String.Empty, String.Empty);
                }
            }
        }//---------------------------

        //this procedure will select student transcript details
        public void SelectByStudentIDTranscriptDetails(CommonExchange.SysAccess userInfo, String studentId)
        {
            using (RemoteClient.RemCntTranscriptManager remClient = new RemoteClient.RemCntTranscriptManager())
            {
                _studentTranscriptTable = remClient.SelectByStudentIDTranscriptDetails(userInfo, studentId);
            }
        }//--------------------------

        //this procedure will edit major exam table
        public void EditMajorExamTable(String majorExamId, String date)
        {
            if (_majorExamScheduleTable != null)
            {
                Int32 index = 0;

                foreach (DataRow examRow in _majorExamScheduleTable.Rows)
                {
                    if (String.Equals(majorExamId, RemoteServerLib.ProcStatic.DataRowConvert(examRow, "major_exam_id", Int64.Parse("0")).ToString()))
                    {
                        DataRow editRow = _majorExamScheduleTable.Rows[index];

                        editRow.BeginEdit();

                        editRow["exam_date"] = date;

                        editRow.EndEdit();

                        break;
                    }

                    index++;
                }
            }
        }//--------------------------

        //this procedure will initialize student course major combo
        public void InitializeCourseMajorCombo(ComboBox cboBase)
        {
            cboBase.Items.Clear();

            if (_courseMajorTable != null)
            {
                Int32 index = 0;
                Boolean isIndex = false;

                foreach (DataRow majorRow in _courseMajorTable.Rows)
                {
                    cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(majorRow, "course_major_title", "") + "  [" +
                        RemoteServerLib.ProcStatic.DataRowConvert(majorRow, "acronym", "") + "]");

                    if (RemoteServerLib.ProcStatic.DataRowConvert(majorRow, "is_current_major", false))
                    {
                        cboBase.SelectedIndex = index;

                        isIndex = true;
                    }

                    index++;
                }

                if (!isIndex)
                {
                    cboBase.SelectedIndex = -1;
                }
            }
        }//-------------------------

        //this procedure will initialize inserted exam schedule
        public void InitializeInsertedExamSchedule(String majorExamId, Boolean printValue)
        {
            if (_majorExamScheduleTable != null)
            {
                Int32 index = 0;

                foreach (DataRow examRow in _majorExamScheduleTable.Rows)
                {
                    if (String.Equals(majorExamId, RemoteServerLib.ProcStatic.DataRowConvert(examRow, "major_exam_id", "")))
                    {
                        DataRow editRow = _majorExamScheduleTable.Rows[index];

                        editRow.BeginEdit();

                        editRow["is_for_print"] = printValue;

                        editRow.EndEdit();

                        break;
                    }

                    index++;
                }
            }
        }//----------------------------

        //this procedure will initialize the major exam schedule list view
        public void InitializeMajorExamListView(ListView lsvBase)
        {
            lsvBase.Items.Clear();

            if (_majorExamScheduleTable != null)
            {
                foreach (DataRow examRow in _majorExamScheduleTable.Rows)
                {
                    ListViewItem addItem = new ListViewItem(new String[] {"",
                        RemoteServerLib.ProcStatic.DataRowConvert(examRow, "major_exam_id", Int64.Parse("0")).ToString(),
                        RemoteServerLib.ProcStatic.DataRowConvert(examRow, "exam_date", ""),
                        RemoteServerLib.ProcStatic.DataRowConvert(examRow, "exam_description", "")});

                    lsvBase.Items.Add(addItem);
                }
            }
        }//---------------------------

        //this procedure initialized the student charges list view
        public void InitializeStudentChargesListView(ListView lsvBase, ToolStripLabel lblBase, String sysIdStudent)
        {
            lsvBase.Items.Clear();

            _paymentReimbursementTableTemp.Rows.Clear();

            Decimal balanceForwarded = 0;
            Decimal balanceForwardedForSummary = 0;

            if (_balanceForwardedTable != null && _balanceForwardedTable.Rows.Count > 0)
            {
                DataRow balRow = _balanceForwardedTable.Rows[0];

                balanceForwarded = balanceForwardedForSummary = RemoteServerLib.ProcStatic.DataRowConvert(balRow, "amount", Decimal.Parse("0"));
            }

            if (balanceForwarded < 0)
            {
                DataRow newRow = _paymentReimbursementTableTemp.NewRow();

                newRow["remarks_discount_reimbursement_description"] = "Forwarded Balance";
                newRow["amount"] = balanceForwarded * (-1);
                newRow["is_payment"] = true;
                //newRow["is_discount"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_discount", false);
                //newRow["is_reimbursement"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_discount", false);
                //newRow["is_balance_forwarded"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_balance_forwarded", false);
                //newRow["is_credit_memo"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_credit_memo", false);
                newRow["is_included_in_post"] = true;

                _paymentReimbursementTableTemp.Rows.Add(newRow);
            }

            foreach (DataRow payDiscountRem in _paymentReimbursementTable.Rows)
            {
                DataRow newRow = _paymentReimbursementTableTemp.NewRow();

                newRow["payment_discount_reimbursement_id"] =
                    RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "payment_discount_reimbursement_id", Int64.Parse("0"));
                newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "sysid_student", String.Empty);
                newRow["received_date"] =
                    RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "received_date", String.Empty);
                newRow["receipt_no"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "receipt_no", String.Empty);
                newRow["remarks_discount_reimbursement_description"] =
                    RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "remarks_discount_reimbursement_description", String.Empty);
                newRow["is_downpayment"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_downpayment", false);
                newRow["amount"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "amount", Decimal.Parse("0"));
                newRow["discount_amount"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "discount_amount", Decimal.Parse("0"));
                newRow["is_payment"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_payment", false);
                newRow["is_discount"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_discount", false);
                newRow["is_reimbursement"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_discount", false);
                newRow["is_balance_forwarded"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_balance_forwarded", false);
                newRow["is_credit_memo"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_credit_memo", false);
                newRow["is_included_in_post"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_included_in_post", false);

                _paymentReimbursementTableTemp.Rows.Add(newRow);

                if (RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "discount_amount", Decimal.Parse("0")) > 0)
                {
                    DataRow newRowDiscountedAmount = _paymentReimbursementTableTemp.NewRow();

                    newRowDiscountedAmount["payment_discount_reimbursement_id"] =
                        RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "payment_discount_reimbursement_id", Int64.Parse("0"));
                    newRowDiscountedAmount["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "sysid_student", String.Empty);
                    newRowDiscountedAmount["received_date"] =
                        RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "received_date", String.Empty);
                    newRowDiscountedAmount["receipt_no"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "receipt_no", String.Empty);
                    newRowDiscountedAmount["remarks_discount_reimbursement_description"] = "Cash Discount";
                    newRowDiscountedAmount["is_downpayment"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_downpayment", false);
                    newRowDiscountedAmount["amount"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "discount_amount", Decimal.Parse("0"));
                    newRowDiscountedAmount["discount_amount"] = 0;
                    newRowDiscountedAmount["is_payment"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_payment", false);
                    newRowDiscountedAmount["is_discount"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_discount", false);
                    newRowDiscountedAmount["is_discount"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_discount", false);
                    newRowDiscountedAmount["is_reimbursement"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_discount", false);
                    newRowDiscountedAmount["is_balance_forwarded"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_balance_forwarded", false);
                    newRowDiscountedAmount["is_credit_memo"] = RemoteServerLib.ProcStatic.DataRowConvert(payDiscountRem, "is_credit_memo", false);


                    _paymentReimbursementTableTemp.Rows.Add(newRowDiscountedAmount);
                }
            }    

            if (balanceForwarded != 0)
            {
                ListViewItem categoryItem = new ListViewItem(new String[] {"      " + "Back Accounts", String.Empty, String.Empty}, lsvBase.Groups[1]);
                categoryItem.ForeColor = Color.Red;
                lsvBase.Items.Add(categoryItem);

                ListViewItem forwardedItem = new ListViewItem(new String[] { "                   Balance Carried Forward ",
                    balanceForwarded.ToString("N"), String.Empty}, lsvBase.Groups[1]);
                lsvBase.Items.Add(forwardedItem);

                ListViewItem lessItem = new ListViewItem(new String[] { "                   Less:", String.Empty, String.Empty }, lsvBase.Groups[1]);
                lessItem.ForeColor = Color.Orange;
                lsvBase.Items.Add(lessItem);

                Boolean hasPayments = false;

                Int32 paymentIndex = 0;

                foreach (DataRow paymentRow in _paymentReimbursementTableTemp.Rows)
                {
                    //Code added:: include only if (is_included_in_post == true) :: April 7, 2010
                    if (paymentRow.RowState != DataRowState.Deleted &&
                        (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")) > 0 &&
                        ((RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_payment", false) ||
                        RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_discount", false) ||
                        RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_credit_memo", false)) &&
                        RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_included_in_post", false))))
                    {
                        if (balanceForwarded > 0)
                        {
                            ListViewItem paymentItem;

                            Decimal addedAmount = 0;
                            Decimal deductedAmount = 0;

                            if (balanceForwarded >= RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")))
                            {
                                balanceForwarded -= RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0"));

                                addedAmount = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0"));

                                deductedAmount = 0;
                            }
                            else
                            {
                                addedAmount = balanceForwarded;
                               
                                deductedAmount = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")) - balanceForwarded;    

                                balanceForwarded = 0;                               
                            }

                            String remarksDescription = String.Empty;
                            String paymentDiscountReimbursementDate = String.Empty;

                            if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                                (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_payment", false) &&
                                !RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false)))
                            {
                                remarksDescription = "Payment";
                            }
                            else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, 
                                "remarks_discount_reimbursement_description", "")) &&
                                RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false))
                            {
                                remarksDescription = "Downpayment";
                            }
                            else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, 
                                "remarks_discount_reimbursement_description", "")) &&
                                RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_reimbursement", false))
                            {
                                remarksDescription = "Reimbursement";
                            }
                            else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, 
                                "remarks_discount_reimbursement_description", "")) &&
                                RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_credit_memo", false))
                            {
                                remarksDescription = "Credit Memo";
                            }
                            else if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, 
                                "remarks_discount_reimbursement_description", "")))
                            {
                                remarksDescription = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "");
                            }

                            DateTime pDate;

                            if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "received_date", ""), out pDate))
                            {
                                paymentDiscountReimbursementDate = pDate.ToShortDateString();
                            }

                            paymentItem = new ListViewItem(new String[] { "                         " + remarksDescription + " - " 
                                    + paymentDiscountReimbursementDate, "(" + addedAmount.ToString("N") + ")", String.Empty}, lsvBase.Groups[1]);

                            lsvBase.Items.Add(paymentItem);

                            DataRow editRow = _paymentReimbursementTableTemp.Rows[paymentIndex];

                            editRow.BeginEdit();

                            editRow["amount"] = deductedAmount;

                            editRow.EndEdit();

                            hasPayments = true;
                        }
                        else
                            break;
                    }

                    paymentIndex++;
                }

                _paymentReimbursementTable.AcceptChanges();

                if (!hasPayments)
                {
                    lsvBase.Items.Remove(lessItem);

                    ListViewItem totalItem = new ListViewItem(new String[] {"                                       Sub Total" ,
                        balanceForwarded.ToString("N"), String.Empty}, lsvBase.Groups[1]);

                    totalItem.ForeColor = Color.LightCoral;

                    lsvBase.Items.Add(totalItem);

                    ListViewItem emptyItem = new ListViewItem(new String[] { String.Empty, String.Empty, String.Empty },
                        lsvBase.Groups[1]);

                    lsvBase.Items.Add(emptyItem);
                }
                else
                {
                    ListViewItem totalItem = new ListViewItem(new String[] {"                                       Sub Total" ,
                        balanceForwarded.ToString("N"), String.Empty}, lsvBase.Groups[1]);

                    totalItem.ForeColor = Color.LightCoral;

                    lsvBase.Items.Add(totalItem);

                    ListViewItem emptyItem = new ListViewItem(new String[] { String.Empty, String.Empty, String.Empty },
                        lsvBase.Groups[1]);

                    lsvBase.Items.Add(emptyItem);
                }
            }

            Decimal totalCharges = 0;

            //-------------Populate School Fee Details
            foreach (DataRow categoryRow in _classDataSet.Tables["SchoolFeeCategoryTable"].Rows)
            {
                Int32 categoryItemCount = 0;

                ListViewItem categoryItem = new ListViewItem(new String[] {"      " + 
                    RemoteServerLib.ProcStatic.DataRowConvert(categoryRow, "category_description", ""), String.Empty, String.Empty}, lsvBase.Groups[1]);

                categoryItem.ForeColor = Color.Red;

                lsvBase.Items.Add(categoryItem);

                String strFilter = "fee_category_id = '" + RemoteServerLib.ProcStatic.DataRowConvert(categoryRow, "fee_category_id", "") + "'";
                DataRow[] selectRow = _schoolFeeDetailsTable.Select(strFilter);

                Decimal subTotal = 0;
                Int16 index = 0;

                foreach (DataRow detailsRow in selectRow)
                {
                    if (detailsRow.RowState != DataRowState.Deleted &&
                        ((CommonExchange.SchoolFeeCategoryId.TuitionFee == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", "") &&
                       (RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_per_year_tuition_fee", false) ||
                        RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_per_unit_tuition_fee", false) ||
                        RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_fixed_amount_tuition_fee", false) ||
                        RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_special_class_tuition_fee", false))) ||
                       CommonExchange.SchoolFeeCategoryId.MiscellaneousFees == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", "") ||
                       CommonExchange.SchoolFeeCategoryId.OtherFees == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", "") ||
                       CommonExchange.SchoolFeeCategoryId.LaboratoryFees == RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "fee_category_id", "")))
                    {
                        if (RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0")) > 0)
                        {
                            ListViewItem item = new ListViewItem(new String[] { "                   " + 
                                RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "particular_description", ""),
                                RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0")).ToString("N"), 
                                RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "optional_fee_id", ""),
                                RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "sysid_feedetails", "")},
                                lsvBase.Groups[1]);

                            if (RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_level_increase", false))
                            {
                                item.ForeColor = Color.Orange;
                            }
                            else if (RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_added_level_fee", false))
                            {
                                item.ForeColor = Color.Olive;
                            }
                            else if (RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_additional_fee", false))
                            {
                                item.ForeColor = Color.Brown;
                            }
                            else if (RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_optional_fee", false))
                            {
                                item.ForeColor = Color.CadetBlue;
                            }

                            lsvBase.Items.Add(item);

                            subTotal += RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "amount", Decimal.Parse("0"));

                            categoryItemCount++;
                        }
                    }

                    index++;
                }

                totalCharges += subTotal;

                if (index != 0)
                {
                    ListViewItem lessItem = new ListViewItem(new String[] { "                   Less:", String.Empty, String.Empty }, lsvBase.Groups[1]);
                    lessItem.ForeColor = Color.Orange;
                    lsvBase.Items.Add(lessItem);

                    Boolean hasPayments = false;

                    Int32 paymentIndex = 0;

                    foreach (DataRow paymentRow in _paymentReimbursementTableTemp.Rows)
                    {
                        //Code added:: include only if (is_included_in_post == true) :: April 7, 2010
                        if (paymentRow.RowState != DataRowState.Deleted &&
                            (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")) > 0 &&
                            ((RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_payment", false) ||
                            RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_discount", false) ||
                            RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_credit_memo", false)) &&
                            RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_included_in_post", false))))
                        {
                            if (subTotal > 0)
                            {
                                ListViewItem paymentItem;

                                Decimal addedAmount = 0;
                                Decimal deductedAmount = 0;

                                if (subTotal >= RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")))
                                {
                                    subTotal -= RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0"));

                                    addedAmount = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0"));

                                    deductedAmount = 0;
                                }
                                else
                                {
                                    addedAmount = subTotal;

                                    deductedAmount = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")) - subTotal;

                                    subTotal = 0;
                                }

                                String remarksDescription = String.Empty;
                                String paymentDiscountReimbursementDate = String.Empty;

                                if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                                    (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_payment", false) &&
                                    !RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false)))
                                {
                                    remarksDescription = "Payment";
                                }
                                else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, 
                                    "remarks_discount_reimbursement_description", "")) &&
                                    RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false))
                                {
                                    remarksDescription = "Downpayment";
                                }
                                else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, 
                                    "remarks_discount_reimbursement_description", "")) &&
                                    RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_reimbursement", false))
                                {
                                    remarksDescription = "Reimbursement";
                                }
                                else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, 
                                    "remarks_discount_reimbursement_description", "")) &&
                                    RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_credit_memo", false))
                                {
                                    remarksDescription = "Credit Memo";
                                }
                                else if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, 
                                    "remarks_discount_reimbursement_description", "")))
                                {
                                    remarksDescription = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "");
                                }

                                DateTime pDate;

                                if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "received_date", ""), out pDate))
                                {
                                    paymentDiscountReimbursementDate = pDate.ToShortDateString();
                                }

                                paymentItem = new ListViewItem(new String[] { "                         " + remarksDescription + " - " 
                                    + paymentDiscountReimbursementDate, "(" + addedAmount.ToString("N") + ")", String.Empty}, lsvBase.Groups[1]);

                                lsvBase.Items.Add(paymentItem);

                                DataRow editRow = _paymentReimbursementTableTemp.Rows[paymentIndex];

                                editRow.BeginEdit();

                                editRow["amount"] = deductedAmount;

                                editRow.EndEdit();

                                hasPayments = true;
                            }
                            else
                                break;
                        }

                        paymentIndex++;
                    }

                    _paymentReimbursementTable.AcceptChanges();

                    if (!hasPayments)
                    {
                        lsvBase.Items.Remove(lessItem);
                    }

                    if (categoryItemCount > 0)
                    {
                        ListViewItem totalItem = new ListViewItem(new String[] {"                                       Sub Total" ,
                        subTotal.ToString("N"), String.Empty}, lsvBase.Groups[1]);

                        totalItem.ForeColor = Color.LightCoral;

                        lsvBase.Items.Add(totalItem);

                        ListViewItem emptyItem = new ListViewItem(new String[] { String.Empty, String.Empty, String.Empty },
                            lsvBase.Groups[1]);

                        lsvBase.Items.Add(emptyItem);
                    }
                    else
                    {
                        lsvBase.Items.Remove(categoryItem);
                    }
                }
                else
                    lsvBase.Items.Remove(categoryItem);
            }
            //------------End Populate School Fee Details

            //-------------Populate Charges Summary 
            Decimal totalReimbursement = 0;
            Decimal discountAmount = 0;

            if (balanceForwardedForSummary != 0)
            {
                ListViewItem forwardedItem = new ListViewItem(new String[] { "                   Balance Carried Forward: ",
                balanceForwardedForSummary.ToString("N"), String.Empty}, lsvBase.Groups[0]);
                lsvBase.Items.Add(forwardedItem);
            }

            ListViewItem balanceItem = new ListViewItem(new String[] { "                   Total Charges: ", totalCharges.ToString("N"), String.Empty },
                lsvBase.Groups[0]);
            lsvBase.Items.Add(balanceItem);

            foreach (DataRow paymentRow in _paymentReimbursementTable.Rows)
            {
                //Code added:: include only if (is_included_in_post == true) :: April 7, 2010
                if (paymentRow.RowState != DataRowState.Deleted && 
                    (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_reimbursement", false) &&
                    RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_included_in_post", false)))
                {
                    String remarksDescription = String.Empty;
                    String paymentDiscountReimbursementDate = String.Empty;

                    if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                        (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_payment", false) &&
                        !RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false)))
                    {
                        remarksDescription = "Payment";
                    }
                    else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                        RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false))
                    {
                        remarksDescription = "Downpayment";
                    }
                    else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                        RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_reimbursement", false))
                    {
                        remarksDescription = "Reimbursement";
                    }
                    else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                           RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_credit_memo", false))
                    {
                        remarksDescription = "Credit Memo";
                    }
                    else if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")))
                    {
                        remarksDescription = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "");
                    }

                    DateTime pDate;

                    if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "received_date", ""), out pDate))
                    {
                        paymentDiscountReimbursementDate = pDate.ToShortDateString();
                    }

                    ListViewItem rItem = new ListViewItem(new String[] {"                   " + remarksDescription + " - " + paymentDiscountReimbursementDate,
                        RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")).ToString("N"), String.Empty}, lsvBase.Groups[0]);

                    lsvBase.Items.Add(rItem);

                    totalReimbursement += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0"));
                }
            }

            ListViewItem lessPaymentItem = new ListViewItem(new String[] { "                   Less:", String.Empty, String.Empty }, lsvBase.Groups[0]);
            lessPaymentItem.ForeColor = Color.Orange;
            lsvBase.Items.Add(lessPaymentItem);

            Boolean hasPaymentSummary = false;

            foreach (DataRow paymentRow in _paymentReimbursementTable.Rows)
            {
                //Code added:: include only if (is_included_in_post == true) :: April 7, 2010
                if (paymentRow.RowState != DataRowState.Deleted && (!RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_reimbursement", false) &&
                    !RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_balance_forwarded", false) &&
                    RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_included_in_post", false)))
                {
                    String remarksDescription = String.Empty;
                    String paymentDiscountReimbursementDate = String.Empty;

                    if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                        (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_payment", false) &&
                        !RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false)))
                    {
                        remarksDescription = "Payment";
                    }
                    else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                        RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_downpayment", false))
                    {
                        remarksDescription = "Downpayment";
                    }
                    else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                        RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_reimbursement", false))
                    {
                        remarksDescription = "Reimbursement";
                    }
                    else if (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")) &&
                           RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "is_credit_memo", false))
                    {
                        remarksDescription = "Credit Memo";
                    }
                    else if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "")))
                    {
                        remarksDescription = RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "remarks_discount_reimbursement_description", "");
                    }

                    DateTime pDate;

                    if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "received_date", ""), out pDate))
                    {
                        paymentDiscountReimbursementDate = pDate.ToShortDateString();
                    }

                    ListViewItem discountItem = new ListViewItem(new String[] { "                         " + remarksDescription + " - " + 
                        paymentDiscountReimbursementDate, 
                        "(" + RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")).ToString("N") + ")", String.Empty},
                            lsvBase.Groups[0]);

                    lsvBase.Items.Add(discountItem);

                    discountItem = null;

                    if (RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0")) > 0)
                    {
                        discountItem = new ListViewItem(new String[] { "                         Cash Discount - " + 
                            paymentDiscountReimbursementDate, 
                            "(" + RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0")).ToString("N") + ")", String.Empty},
                            lsvBase.Groups[0]);

                        lsvBase.Items.Add(discountItem);
                    }

                    discountAmount += RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "amount", Decimal.Parse("0")) +
                        RemoteServerLib.ProcStatic.DataRowConvert(paymentRow, "discount_amount", Decimal.Parse("0"));

                    hasPaymentSummary = true;
                }
            }

            if (!hasPaymentSummary)
            {
                lsvBase.Items.Remove(lessPaymentItem);
            }
            //-------------End

            lblBase.Text = "  Balance : " + String.Format("{0:#,##0.00;(#,##0.00)}", ((balanceForwardedForSummary + totalCharges + totalReimbursement) - (discountAmount)));

            _totalCharges = totalCharges;
        }//-------------------------

        //this procedure initialized the subject load list view
        public void InitializeSubjectLoadListViewTranscript(ListView lsvBase, ToolStripLabel lblTotalStudentLoad, TabPage tblBase)
        {
            lsvBase.Items.Clear();

            Int32 totalLab = 0, totalLec = 0, totalHours = 0, totalMin = 0, totalNonAcad = 0;

            DateTime noHoursLoaded = DateTime.MinValue;

            foreach (DataRow schedRow in _studentLoadTable.Rows)
            {
                if (schedRow.RowState != DataRowState.Deleted)
                {
                    String strFilter = "sysid_schedule = '" + RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_schedule", "") + "'" +
                         " AND (is_loaded_to_student = 1 AND is_premature_deloaded = 0)";
                    DataRow[] selectRow = _subjectScheduleTable.Select(strFilter);

                    foreach (DataRow subRow in selectRow)
                    {
                        ListViewItem addItem = new ListViewItem(new String[] {String.Empty,
                            RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_code", "") + " - " +
                            RemoteServerLib.ProcStatic.DataRowConvert(subRow, "descriptive_title", ""),
                            RemoteServerLib.ProcStatic.DataRowConvert(subRow, "load_lecture_units", Byte.Parse("0")).ToString(),
                            RemoteServerLib.ProcStatic.DataRowConvert(subRow, "load_lab_units", Byte.Parse("0")).ToString(),
                            RemoteServerLib.ProcStatic.DataRowConvert(subRow, "load_no_hours", ""),
                            RemoteServerLib.ProcStatic.DataRowConvert(subRow, "is_non_academic", false).ToString(),
                            RemoteServerLib.ProcStatic.DataRowConvert(subRow, "department_name", ""),
                            RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_schedule", "")});

                        Boolean isFixedAmount = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "is_fixed_amount", false);
                        Boolean isTeamTeaching = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "is_team_teaching", false);
                        Boolean isIrregularModular = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "is_irregular_modular", false);

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
                        //else for white which is a default color

                        lsvBase.Items.Add(addItem);

                        totalLab += RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_lab_units", Byte.Parse("0"));

                        if (RemoteServerLib.ProcStatic.DataRowConvert(subRow, "is_non_academic", false))
                        {
                            totalNonAcad += RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_lecture_units", Byte.Parse("0"));
                        }
                        else
                        {
                            totalLec += RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_lecture_units", Byte.Parse("0"));
                        }

                        if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_no_hours", ""), out noHoursLoaded))
                        {
                            totalHours += noHoursLoaded.Minute + (noHoursLoaded.Hour * 60);
                        }
                    }
                }
            }

            totalMin = totalHours % 60;
            totalHours /= 60;

            lblTotalStudentLoad.Text = "  " + this.GetSubjectUnitsHours(totalLec, totalNonAcad, totalLab,
                RemoteServerLib.ProcStatic.TwoDigitZero(totalHours) + ":" + RemoteServerLib.ProcStatic.TwoDigitZero(totalMin));

            if (tblBase != null)
            {
                tblBase.Text = lsvBase.Items.Count > 0 ? "** Subject Load" : "Subject Load";
            }
        }//-------------------------------

        //this procedure initialized the subject load list view
        public void InitializeSubjectLoadListView(ListView lsvBase, ToolStripLabel lblTotalStudentLoad, TabPage tblBase)
        {
            lsvBase.Items.Clear();

            Int32 totalLab = 0, totalLec = 0, totalHours = 0, totalMin = 0, totalNonAcad = 0;

            DateTime noHoursLoaded = DateTime.MinValue;

            foreach (DataRow schedRow in _studentLoadTable.Rows)
            {
                if (schedRow.RowState != DataRowState.Deleted)
                {
                    String strFilter = "sysid_schedule = '" + RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_schedule", "") + "'" +
                         " AND (is_loaded_to_student = 1 AND is_premature_deloaded = 0)";
                    DataRow[] selectRow = _subjectScheduleTable.Select(strFilter);

                    foreach (DataRow subRow in selectRow)
                    {
                        String amount = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "is_fixed_amount", false) ?
                            RemoteServerLib.ProcStatic.DataRowConvert(subRow, "amount", Decimal.Parse("0")).ToString("N") :
                            RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_amount", Decimal.Parse("0")).ToString("N");

                        ListViewItem addItem = new ListViewItem(new String[] {RemoteServerLib.ProcStatic.DataRowConvert(subRow, "sysid_schedule", ""),
                            RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_code", "") + " - " +
                            RemoteServerLib.ProcStatic.DataRowConvert(subRow, "descriptive_title", ""),
                            RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_lecture_units", Byte.Parse("0")).ToString(),
                            RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_lab_units", Byte.Parse("0")).ToString(),
                            RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_no_hours", ""), amount,
                            RemoteServerLib.ProcStatic.DataRowConvert(subRow, "department_name", "")});

                        Boolean isFixedAmount = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "is_fixed_amount", false);
                        Boolean isTeamTeaching = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "is_team_teaching", false);
                        Boolean isIrregularModular = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "is_irregular_modular", false);

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
                        //else for white which is a default color

                        lsvBase.Items.Add(addItem);
                      
                        totalLab += RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_lab_units", Byte.Parse("0"));

                        if (RemoteServerLib.ProcStatic.DataRowConvert(subRow, "is_non_academic", false))
                        {
                            totalNonAcad += RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_lecture_units", Byte.Parse("0"));
                        }
                        else
                        {
                            totalLec += RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_lecture_units", Byte.Parse("0"));
                        }

                        if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_no_hours", ""), out noHoursLoaded))
                        {           
                            totalHours += noHoursLoaded.Minute + (noHoursLoaded.Hour * 60);
                        }
                    }
                }
            }

            totalMin = totalHours % 60;
            totalHours /= 60;

            lblTotalStudentLoad.Text = "  " + this.GetSubjectUnitsHours(totalLec, totalNonAcad, totalLab,
                RemoteServerLib.ProcStatic.TwoDigitZero(totalHours) + ":" + RemoteServerLib.ProcStatic.TwoDigitZero(totalMin));

            if (tblBase != null)
            {
                tblBase.Text = lsvBase.Items.Count > 0 ? "** Subject Load" : "Subject Load";
            }
        }//-------------------------------

        //this procedure initialized the withdrawn subject list view
        public void InitializeWithdrawSubjectLoadListViewTranscript(ListView lsvBase, TabPage tblBase)
        {
            lsvBase.Items.Clear();

            foreach (DataRow schedRow in _prematureDeloadedSubjectTable.Rows)
            {
                if (schedRow.RowState != DataRowState.Deleted)
                {
                    String strFilter = "sysid_schedule = '" + RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_schedule", "") +
                        "' AND (is_premature_deloaded = 1 AND is_loaded_to_student = 1)";
                    DataRow[] selectRow = _subjectScheduleTable.Select(strFilter);

                    foreach (DataRow subRow in selectRow)
                    {
                        if (subRow.RowState != DataRowState.Deleted)
                        {
                            String loadDate = !String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(subRow, "load_date", "")) ?
                                DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(subRow, "load_date", "").ToString()).ToShortDateString() :
                                String.Empty;
                            String deloadDate = !String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(subRow, "deload_date", "")) ?
                                DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(subRow, "deload_date", "").ToString()).ToShortDateString() :
                                String.Empty;

                            ListViewItem addItem = new ListViewItem(new String[] {String.Empty,
                                RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_code", "") + " - " +
                                RemoteServerLib.ProcStatic.DataRowConvert(subRow, "descriptive_title", ""),
                                RemoteServerLib.ProcStatic.DataRowConvert(subRow, "load_lecture_units", Byte.Parse("0")).ToString(),
                                RemoteServerLib.ProcStatic.DataRowConvert(subRow, "load_lab_units", Byte.Parse("0")).ToString(),
                                RemoteServerLib.ProcStatic.DataRowConvert(subRow, "load_no_hours", ""), 
                                RemoteServerLib.ProcStatic.DataRowConvert(subRow, "is_non_academic", false).ToString(),
                                loadDate, RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_schedule", ""), deloadDate,
                                RemoteServerLib.ProcStatic.DataRowConvert(subRow, "department_name", "")});

                            Boolean isFixedAmount = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "is_fixed_amount", false);
                            Boolean isTeamTeaching = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "is_team_teaching", false);
                            Boolean isIrregularModular = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "is_irregular_modular", false);

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
                                addItem.ForeColor = Color.Wheat;
                            }
                            else if (isFixedAmount && !isTeamTeaching && !isIrregularModular)
                            {
                                addItem.ForeColor = Color.RosyBrown;
                            }
                            else if (isFixedAmount && !isTeamTeaching && isIrregularModular)
                            {
                                addItem.ForeColor = Color.LemonChiffon;
                            }
                            else if (isFixedAmount && isTeamTeaching && !isIrregularModular)
                            {
                                addItem.ForeColor = Color.LimeGreen;
                            }
                            else if (isFixedAmount && isTeamTeaching && isIrregularModular)
                            {
                                addItem.ForeColor = Color.Plum;
                            }
                            //else for white which is a default color

                            lsvBase.Items.Add(addItem);
                        }
                    }
                }
            }

            tblBase.Text = lsvBase.Items.Count > 0 ? "** Withdrawn Subjects" : "Withdrawn Subjects";
        }//------------------------------

        //this procedure initialized the withdrawn subject list view
        public void InitializeWithdrawSubjectLoadListView(ListView lsvBase, TabPage tblBase)
        {
            lsvBase.Items.Clear();

            foreach (DataRow schedRow in _prematureDeloadedSubjectTable.Rows)
            {
                if (schedRow.RowState != DataRowState.Deleted)
                {
                    String strFilter = "sysid_schedule = '" + RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_schedule", "") + 
                        "' AND (is_premature_deloaded = 1 AND is_loaded_to_student = 1)";
                    DataRow[] selectRow = _subjectScheduleTable.Select(strFilter);

                    foreach (DataRow subRow in selectRow)
                    {
                        if (subRow.RowState != DataRowState.Deleted)
                        {
                            String amount = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "is_fixed_amount", false) ?
                            RemoteServerLib.ProcStatic.DataRowConvert(subRow, "amount", Decimal.Parse("0")).ToString("N") :
                            RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_amount", Decimal.Parse("0")).ToString("N");

                            String loadDate = !String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(subRow, "load_date", "")) ?
                                DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(subRow, "load_date", "").ToString()).ToShortDateString() :
                                String.Empty;
                            String deloadDate = !String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(subRow, "deload_date", "")) ?
                                DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(subRow, "deload_date", "").ToString()).ToShortDateString() :
                                String.Empty;

                            ListViewItem addItem = new ListViewItem(new String[] {RemoteServerLib.ProcStatic.DataRowConvert(subRow, "sysid_schedule", ""),
                                RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_code", "") + " - " +
                                RemoteServerLib.ProcStatic.DataRowConvert(subRow, "descriptive_title", ""),
                                RemoteServerLib.ProcStatic.DataRowConvert(subRow, "load_lecture_units", Byte.Parse("0")).ToString(),
                                RemoteServerLib.ProcStatic.DataRowConvert(subRow, "load_lab_units", Byte.Parse("0")).ToString(),
                                RemoteServerLib.ProcStatic.DataRowConvert(subRow, "load_no_hours", ""), amount,
                                loadDate, deloadDate,
                                RemoteServerLib.ProcStatic.DataRowConvert(subRow, "department_name", "")});

                            Boolean isFixedAmount = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "is_fixed_amount", false);
                            Boolean isTeamTeaching = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "is_team_teaching", false);
                            Boolean isIrregularModular = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "is_irregular_modular", false);

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
                                addItem.ForeColor = Color.Wheat;
                            }
                            else if (isFixedAmount && !isTeamTeaching && !isIrregularModular)
                            {
                                addItem.ForeColor = Color.RosyBrown;
                            }
                            else if (isFixedAmount && !isTeamTeaching && isIrregularModular)
                            {
                                addItem.ForeColor = Color.LemonChiffon;
                            }
                            else if (isFixedAmount && isTeamTeaching && !isIrregularModular)
                            {
                                addItem.ForeColor = Color.LimeGreen;
                            }
                            else if (isFixedAmount && isTeamTeaching && isIrregularModular)
                            {
                                addItem.ForeColor = Color.Plum;
                            }
                            //else for white which is a default color

                            lsvBase.Items.Add(addItem);
                        }
                    }
                }
            }

            tblBase.Text = lsvBase.Items.Count > 0 ? "** Withdrawn Subjects" : "Withdrawn Subjects";
        }//------------------------------

        //this procedure will initialize the speical class list view
        public void InitializeSpecialClassLoadedWithdrawnListViewTranscript(ListView lsvBase, Label lblBase, TabPage tblBase, Boolean isPrematureDeloaded)
        {
            lsvBase.Items.Clear();

            Int32 totalLab = 0, totalLec = 0, totalHours = 0, totalMin = 0, totalNonAcad = 0;

            DateTime noHoursLoaded = DateTime.MinValue;

            String strFilter = "is_premature_deloaded = " + isPrematureDeloaded;
            DataRow[] selectRow = _specialClassTable.Select(strFilter);

            if (_specialClassTable != null)
            {
                if (!isPrematureDeloaded)
                {
                    foreach (DataRow specialRow in selectRow)
                    {
                        ListViewItem lstItem = new ListViewItem(new String[] { String.Empty,
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_code", String.Empty) + " - " +
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "descriptive_title", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_lecture_units", Byte.Parse("0")).ToString(),
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_lab_units", Byte.Parse("0")).ToString(),
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_no_hours", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "is_non_academic", false).ToString(),
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_department_name", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "sysid_special", String.Empty),
                            RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "last_name", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "first_name", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "middle_name", String.Empty)), String.Empty});

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
                        String loadDate = !String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "load_date", "")) ?
                                   DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "load_date", "").ToString()).ToShortDateString() :
                                   String.Empty;
                        String deloadDate = !String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "deload_date", "")) ?
                            DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "deload_date", "").ToString()).ToShortDateString() :
                            String.Empty;

                        ListViewItem lstItem = new ListViewItem(new String[] { RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "sysid_special", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_code", String.Empty) + " - " +
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "descriptive_title", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_lecture_units", Byte.Parse("0")).ToString(),
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_lab_units", Byte.Parse("0")).ToString(),
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_no_hours", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "is_non_academic", false).ToString(),
                            loadDate, RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "sysid_special", String.Empty).ToString(), deloadDate,
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

                    tblBase.Text = lsvBase.Items.Count > 0 ? "** Withdrawn Special Class" : "Withdrawn Special Class";
                }
            }
        }//-------------------------------

        //this procedure will initialize the speical class list view
        public void InitializeSpecialClassLoadedWithdrawnListView(ListView lsvBase, Label lblBase, TabPage tblBase, Boolean isPrematureDeloaded)
        {
            lsvBase.Items.Clear();

            Int32 totalLab = 0, totalLec = 0, totalHours = 0, totalMin = 0, totalNonAcad = 0;

            DateTime noHoursLoaded = DateTime.MinValue;

            String strFilter = "is_premature_deloaded = " + isPrematureDeloaded;
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

                    tblBase.Text = lsvBase.Items.Count > 0 ? "** Special Class" : "Special Class";
                }
                else
                {
                    foreach (DataRow specialRow in selectRow)
                    {
                        String loadDate = !String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "load_date", "")) ?
                                   DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "load_date", "").ToString()).ToShortDateString() :
                                   String.Empty;
                        String deloadDate = !String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "deload_date", "")) ?
                            DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "deload_date", "").ToString()).ToShortDateString() :
                            String.Empty;

                        ListViewItem lstItem = new ListViewItem(new String[] { RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "sysid_special", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_code", String.Empty) + " - " +
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "descriptive_title", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_lecture_units", Byte.Parse("0")).ToString(),
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_lab_units", Byte.Parse("0")).ToString(),
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "subject_no_hours", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "amount", Decimal.Parse("0")).ToString("N"),
                            loadDate, deloadDate,
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

                    tblBase.Text = lsvBase.Items.Count > 0 ? "** Withdrawn Special Class" : "Withdrawn Special Class";
                }
            }
        }//-------------------------------

        //this procedure initialized the subject details list view
        public void InitializeSubjectLoadWithdrawDetailsListViewDataGridView(ListView lsvBase, String sysIdSchedule, Boolean isForListView, DataGridView dgvBase)
        {
            DataTable newTable = new DataTable("TempDetailsTable");

            if (isForListView)
            {
                lsvBase.Items.Clear();
            }
            else
            {
                newTable.Columns.Add("day_time", System.Type.GetType("System.String"));
                newTable.Columns.Add("section", System.Type.GetType("System.String"));
                newTable.Columns.Add("classroom_field_code", System.Type.GetType("System.String"));
            }

            String strFilter = "sysid_schedule = '" + sysIdSchedule + "'";
            DataRow[] selectRow = _subjectScheduleDetailsTable.Select(strFilter);

            foreach (DataRow detailsRow in selectRow)
            {
                if (detailsRow.RowState != DataRowState.Deleted)
                {
                    String room = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_classroom", false) ?
                        RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "classroom_code", "") :
                        RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "field_room", "");

                    if (isForListView)
                    {
                        String instructorsName = String.Equals(RemoteClient.ProcStatic.TrimStartEndString(RemoteClient.ProcStatic.GetCompleteNameMiddleInitial
                            (RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "last_name", ""),
                            RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "first_name", ""),
                            RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "middle_name", ""))), ",") ? String.Empty :
                            RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "last_name", ""),
                            RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "first_name", ""),
                            RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "middle_name", ""));

                        ListViewItem addItem = new ListViewItem(new String[] {"", 
                            !RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_irregular_modular", false) ? 
                            RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "day_time", "") : 
                            RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "manual_schedule", String.Empty),
                            RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "section", ""), room, instructorsName});

                        lsvBase.Items.Add(addItem);
                    }
                    else
                    {
                        DataRow newRow = newTable.NewRow();

                        newRow["day_time"] =  !RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "is_irregular_modular", false) ? 
                            RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "day_time", "") :
                            RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "manual_schedule", String.Empty);
                        newRow["section"] = RemoteServerLib.ProcStatic.DataRowConvert(detailsRow, "section", "");
                        newRow["classroom_field_code"] = room;

                        newTable.Rows.Add(newRow);
                    }
                }
            }

            if (!isForListView)
                dgvBase.DataSource = newTable;
        }//---------------------------

        //this procedure initialized the course checked list box
        public void InitializeCourseCheckedListBox(CheckedListBox cbxBase)
        {
            cbxBase.Items.Clear();

            if (_classDataSet.Tables["CourseInformationTable"] != null)
            {
                foreach (DataRow courseRow in _classDataSet.Tables["CourseInformationTable"].Rows)
                {
                    cbxBase.Items.Add(courseRow["course_title"].ToString() + " [" + courseRow["course_acronym"].ToString() + "]");
                }
            }
        }//-----------------------------------

        //this procedure initialize the year level list box
        public void InitializeYearLevelCheckedListBox(CheckedListBox cbxBase)
        {
            cbxBase.Items.Clear();

            if (_classDataSet.Tables["YearLevelInformationTable"] != null)
            {
                foreach (DataRow levelRow in _classDataSet.Tables["YearLevelInformationTable"].Rows)
                {
                    cbxBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "group_description", "") + " - " +
                        RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_description", ""));
                }
            }
        }//-----------------------------

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

        //this procedure initializes the school year combo box
        public void InitializeSchoolYearComboManager(ComboBox cboBase)
        {
            cboBase.Items.Clear();

            foreach (DataRow yearRow in _classDataSet.Tables["SchoolFeeInformationTable"].Rows)
            {
                cboBase.Items.Add(yearRow["year_description"].ToString());
            }

            cboBase.SelectedIndex = -1;
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
        }//-----------------------------

        //AD Code
        //this procedure initialized the student course combo
        public void InitializedCourseCombo(ComboBox cboBaseCourse, String sysIdSemester, Boolean isSemestral)
        {
            cboBaseCourse.Items.Clear();

            Boolean hasEnter = false;

            Int32 index = 0;

            if (!this.HasCurrentCourse() && _studentCourseTable.Rows.Count != 0)
            {
                cboBaseCourse.Items.Add("-- Select a Course --");
                cboBaseCourse.SelectedIndex = 0;
            }
            else if (_studentCourseTable.Rows.Count == 0)
            {
                cboBaseCourse.Items.Add("-- No course enrolled in the current school year / semester --");
                cboBaseCourse.SelectedIndex = 0;
            }
            else
            {
                cboBaseCourse.Items.Add("-- Select a Course --");
                index++;
            }

            foreach (DataRow courseRow in _studentCourseTable.Rows)
            {
                if (RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "is_current_course", false) && !hasEnter)
                {
                    cboBaseCourse.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_title", "") + "  [" +
                        RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_acronym", "") + "] - Current Course");

                    hasEnter = true;

                    cboBaseCourse.SelectedIndex = index;
                }
                else
                {
                    cboBaseCourse.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_title", "") + "  [" +
                        RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_acronym", "") + "]");
                }

                index++;
            }

            if (!hasEnter && _studentCourseTable.Rows.Count == 1)
            {
                cboBaseCourse.SelectedIndex = 1;
            }
        }//---------------------------------

        //this procedure initialized the student course textBox (for transcript)
        public void InitializedCourseTextBox(TextBox txtBaseCourse, String sysIdSemester, Boolean isSemestral, ref String enrolmentCourseSysId)
        {
            txtBaseCourse.Text = String.Empty;

            if (_studentCourseTable.Rows.Count == 0)
            {
                txtBaseCourse.Text = "No course enrolled in the current school year / semester";
            }
            
            foreach (DataRow courseRow in _studentCourseTable.Rows)
            {  
                txtBaseCourse.Text = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_acronym", "");

                enrolmentCourseSysId = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "sysid_enrolmentcourse", String.Empty);
            }
        }//---------------------------------

        //this procedure initialized the year level textbox (for transcript)
        public void InitializedYearLevelTextBox(TextBox txtBase, ref String enrolmentLevelSysId)
        {
            txtBase.Text = String.Empty;

            String enrolStatus = String.Empty;

            if (_studentLevelTable.Rows.Count < 1)
            {
                txtBase.Text = "No year level enabled for this course";
            }

            foreach (DataRow levelRow in _studentLevelTable.Rows)
            {
                if (levelRow.RowState != DataRowState.Deleted)
                {
                    Boolean isEntryLevel = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "is_entry_level", false);
                    Boolean isEnrolled = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "is_enrolled", false);
                    Boolean isMarkedDeleted = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "is_marked_deleted", false);

                    if (!isEntryLevel && isEnrolled && !isMarkedDeleted)
                    {
                        txtBase.Text = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_description", "");

                        enrolmentLevelSysId = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "sysid_enrolmentlevel", String.Empty);

                        break;
                    }
                    else if (isEntryLevel && isEnrolled && !isMarkedDeleted)
                    {
                        txtBase.Text = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_description", "");

                        enrolmentLevelSysId = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "sysid_enrolmentlevel", String.Empty);

                        break;
                    }
                }
            }           
        }//---------------------------------

        //this procedure initialized the year level combo
        public void InitializedYearLevelCombo(ComboBox cboBase)
        {
            cboBase.Items.Clear();

            String enrolStatus = String.Empty;

            if (_studentLevelTable.Rows.Count >= 1)
            {
                cboBase.Items.Add("-- Select a Year Level --");
            }
            else
            {
                cboBase.Items.Add("-- No year level enabled for this course --");
            }

            Int32 count = 1;
            Int32 focusIndex = -1;

            foreach (DataRow levelRow in _studentLevelTable.Rows)
            {
                if (levelRow.RowState != DataRowState.Deleted)
                {
                    Boolean isEntryLevel = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "is_entry_level", false);
                    Boolean isEnrolled = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "is_enrolled", false);
                    Boolean isMarkedDeleted = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "is_marked_deleted", false);

                    if ((!isEntryLevel && !isEnrolled) || (isMarkedDeleted && !isMarkedDeleted))
                    {
                        enrolStatus = " [Open for Enrolment]";
                    }
                    else if (!isEntryLevel && isEnrolled && !isMarkedDeleted)
                    {
                        enrolStatus = " [Enrolled]";

                        focusIndex = count;
                    }
                    else if (!isEntryLevel && isEnrolled && isMarkedDeleted)
                    {
                        enrolStatus = " [Withdrawn - "+ RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "last_transaction_date_string", String.Empty) + "]";
                    }
                    else if (isEntryLevel && isEnrolled && !isMarkedDeleted)
                    {
                        enrolStatus = " [Enrolled as Entry Level]";

                        focusIndex = count;
                    }
                    else if (isEntryLevel && isEnrolled && isMarkedDeleted)
                    {
                        enrolStatus = " [Withdrawn by Finance Cashier]";
                    }

                    cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_description", "") + enrolStatus);

                    count++;
                }
            }

            if (focusIndex != -1)
            {
                cboBase.SelectedIndex = focusIndex;
            }
            else
            {
                cboBase.SelectedIndex = 0;
            }
        }//---------------------------------

        //this procedure initialized the year level combo
        public void InitializedForChangeStudentEnrollmentLevelYearLevelCombo(ComboBox cboBase)
        {
            cboBase.Items.Clear();

            String enrolStatus = String.Empty;

            if (_changeStudentLevelTable.Rows.Count >= 1)
            {
                cboBase.Items.Add("-- Select a Year Level --");
            }
            else
            {
                cboBase.Items.Add("-- No year level enabled for this course --");
            }

            Int32 count = 1;
            Int32 focusIndex = -1;

            foreach (DataRow levelRow in _changeStudentLevelTable.Rows)
            {
                if (levelRow.RowState != DataRowState.Deleted)
                {
                    Boolean isEntryLevel = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "is_entry_level", false);
                    Boolean isEnrolled = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "is_enrolled", false);
                    Boolean isMarkedDeleted = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "is_marked_deleted", false);

                    if ((!isEntryLevel && !isEnrolled) || (isMarkedDeleted && !isMarkedDeleted))
                    {
                        enrolStatus = " [Open for Enrolment]";
                    }
                    else if (!isEntryLevel && isEnrolled && !isMarkedDeleted)
                    {
                        enrolStatus = " [Enrolled]";

                        focusIndex = count;
                    }
                    else if (!isEntryLevel && isEnrolled && isMarkedDeleted)
                    {
                        enrolStatus = " [Withdrawn - " + RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "last_transaction_date_string", String.Empty) + "]";
                    }
                    else if (isEntryLevel && isEnrolled && !isMarkedDeleted)
                    {
                        enrolStatus = " [Enrolled as Entry Level]";

                        focusIndex = count;
                    }
                    else if (isEntryLevel && isEnrolled && isMarkedDeleted)
                    {
                        enrolStatus = " [Withdrawn by Finance Cashier]";
                    }

                    cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_description", "") + enrolStatus);

                    count++;
                }
            }

            if (focusIndex != -1)
            {
                cboBase.SelectedIndex = focusIndex;
            }
            else
            {
                cboBase.SelectedIndex = 0;
            }
        }//---------------------------------

        //this procedure initialized the treeview control
        public void InitializeTreeViewControl(TreeView trvBase)
        {
            trvBase.Nodes.Clear();

            TreeNode courseGroupNode;
            TreeNode createdCourses;
            TreeNode createdLevel;

            Int32 x = 0;
            Int32 y = 0;

            Boolean hasCurrentCourse = false;

            foreach (DataRow groupRow in _classDataSet.Tables["CourseGroupTable"].Rows)
            {
                courseGroupNode = new TreeNode(RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "group_description", ""));

                String strFilterCourse = "course_group_id = '" + RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "") + "'";
                DataRow[] selectCourse = _studentCourseHistoryTable.Select(strFilterCourse);

                foreach (DataRow courseRow in selectCourse)
                {
                    createdCourses = new TreeNode(RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_title", "") + " [" +
                        this.GetSemesterDescription(RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "sysid_semester", "")) + "  " +
                        this.GetYearLevelDescription(RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "sysid_schoolfee", "")) + " ]");

                    if (RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "is_current_course", false))
                    {
                        createdCourses.ForeColor = courseGroupNode.ForeColor = Color.Red;

                        y = x;

                        hasCurrentCourse = true;
                    }

                    courseGroupNode.Nodes.Add(createdCourses);

                    String strFilterLevel = "sysid_enrolmentcourse = '" + RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "sysid_enrolmentcourse", "") + "'";
                    DataRow[] selectLevel = _studentLevelHistroyTable.Select(strFilterLevel);

                    foreach (DataRow levelRow in selectLevel)
                    {
                        String levelInfo = this.GetSemesterDescription(RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "sysid_semester", "")) + " " +
                                this.GetYearLevelDescription(RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "sysid_schoolfee", "")) + "   " +
                                RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "group_description", "") + " - " +
                                RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_description", "");

                        if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "sysid_enrolmentlevel", "")))
                        {
                            Boolean isEntryLevel = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "is_entry_level", false);
                            Boolean isMarkedDeleted = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "is_marked_deleted", false);

                            String strCon = String.Empty;

                            if (isEntryLevel && !isMarkedDeleted)
                            {
                                strCon = " [Enrolled as Entry Level]";
                            }
                            else if (!isEntryLevel && isMarkedDeleted)
                            {
                                strCon = " [Withdrawn]";
                            }
                            else if (isEntryLevel && isMarkedDeleted)
                            {
                                strCon = " [Withdrawn by Finance Cashier]";
                            }
                            else if (!isEntryLevel && !isMarkedDeleted)
                            {
                                strCon = " [Enrolled]";
                            }

                            createdLevel = new TreeNode(levelInfo + strCon);

                            createdCourses.Nodes.Add(createdLevel);
                        }
                    }
                }

                if (courseGroupNode.ForeColor != Color.Red && courseGroupNode.Nodes.Count >= 1)
                {
                    courseGroupNode.ForeColor = Color.Orange;
                }

                trvBase.Nodes.Add(courseGroupNode);

                x++;
            }

            if (hasCurrentCourse)
            {
                trvBase.Nodes[y].Expand();
            }
        }//---------------------------

        //this procedure refreshes the data
        public void RefreshStudentData(CommonExchange.SysAccess userInfo)
        {
            this.InitializeClass(userInfo);
        }//-------------------------------

        //this procedure deletes the image directory
        public void DeleteImageDirectory(String startUp)
        {
            String imagePath = startUp + _imagePath;

            RemoteClient.ProcStatic.DeleteDirectory(imagePath);
        }//--------------------------------

        //this procedure will clear student load table
        public void ClearStudentLoadTable()
        {
            _studentLoadTable.Rows.Clear();
        }//---------------

        //this procedure will clear cached data
        public void ClearCachedData()
        {
            if (_studentLoadTable != null)
            {
                _studentLoadTable.Clear();
                _openSubjectTable.Clear();
                _prematureDeloadedSubjectTable.Clear();
                _optionalFeeTable.Clear();
            }
        }//--------------------------------       
 
        //this procedure will clear change year level table
        public void ClearChangeYearLevelTable()
        {
            if (_changeStudentLevelTable != null)
            {
                _changeStudentLevelTable.Clear();
            }
        }//----------------------
        #endregion

        #region Programer-Defined Functions
        //this fucntion will determine if the subject loade has a conflict schedule
        public Boolean HasConflictSchedule(DataTable schedTable, String sysIdSchedule, ref String scheduleInformation)
        {
            Boolean isConflict = false;

            String value = String.Empty;

            foreach (DataRow schedRow in schedTable.Rows)
            {
                if (RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "checkbox_column", false) &&
                    !String.Equals(RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_schedule", ""), sysIdSchedule))
                {
                    if (this.GetConflictSchdule(RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_schedule", ""), sysIdSchedule, ref value))
                    {
                        isConflict = true;

                        scheduleInformation += "This schedule conflicts with another SELECTED schedule. [" + 
                            this.GetSubjectCodeTitleBySchedDetails(value) + "]; ";
                    }
                }
            }

            String strFilter = "sysid_schedule = '" + sysIdSchedule + "'";
            DataRow[] selectRow = _studentLoadTable.Select(strFilter);

            if (selectRow.Length <= 0)
            {
                foreach (DataRow loadRow in _studentLoadTable.Rows)
                {
                    if (loadRow.RowState != DataRowState.Deleted &&
                        this.GetConflictSchdule(RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "sysid_schedule", ""), sysIdSchedule, ref value))
                    {
                        isConflict = true;

                        scheduleInformation += "This schedule conflicts with another LOADED schedule. [" + 
                            this.GetSubjectCodeTitleBySchedDetails(value) + "]; ";
                    }
                }
            }

            return isConflict;
        }//-------------------

        //this fucntion will determine if the subject loade has a conflict schedule
        public Boolean HasConflictSchedule(String sysIdSchedule, ref String scheduleInformation)
        {
            Boolean isConflict = false;

            String value = String.Empty;

            String strFilter = "sysid_schedule = '" + sysIdSchedule + "'";
            DataRow[] selectRow = _studentLoadTable.Select(strFilter);

            if (selectRow.Length <= 0)
            {
                foreach (DataRow loadRow in _studentLoadTable.Rows)
                {
                    if (loadRow.RowState != DataRowState.Deleted &&
                        this.GetConflictSchdule(RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "sysid_schedule", ""), sysIdSchedule, ref value))
                    {
                        isConflict = true;

                        scheduleInformation += "This schedule conflicts with another LOADED schedule. [" +
                            this.GetSubjectCodeTitleBySchedDetails(value) + "]; ";
                    }
                }
            }

            return isConflict;
        }//-------------------

        //this function will Insert Student Subject Load and retrun conflict schedule
        public Boolean InsertStudentLoad(String sysIdSchedule, Boolean isInternational)
        {
            Int32 index = 0;
             
            Boolean isValid = true;

            String strFilter = "sysid_schedule = '" + sysIdSchedule + "'";
            DataRow[] selectRow = _studentLoadTable.Select(strFilter);

            if (selectRow.Length <= 0)
            {
                foreach (DataRow loadRow in _studentLoadTable.Rows)
                {
                    String strTemp = String.Empty;

                    if (loadRow.RowState != DataRowState.Deleted &&
                        this.GetConflictSchdule(RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "sysid_schedule", ""), sysIdSchedule, ref strTemp))
                    {
                        isValid = false;
                    }
                }

                if (isValid)
                {
                    Boolean hasLoaded = false;

                    foreach (DataRow schedRow in _openSubjectTable.Rows)
                    {
                        if (schedRow.RowState != DataRowState.Deleted &&
                            String.Equals(sysIdSchedule, RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_schedule", "")))
                        {
                            DataRow editRow = _openSubjectTable.Rows[index];

                            editRow.BeginEdit();

                            editRow["is_loaded_to_student"] = true;

                            editRow.EndEdit();

                            DataRow newRow = _studentLoadTable.NewRow();

                            newRow["load_id"] = --_countLoadId;
                            newRow["sysid_schedule"] = sysIdSchedule;
                            newRow["is_loaded"] = false;
                            newRow["is_premature_deloaded"] = true;

                            _studentLoadTable.Rows.Add(newRow);

                            Int32 x = 0;

                            Boolean isFixedAmount = this.IsFixedAmountSubject(sysIdSchedule);

                            foreach (DataRow feeRow in _schoolFeeDetailsTable.Rows)
                            {
                                if (feeRow.RowState != DataRowState.Deleted &&
                                    CommonExchange.SchoolFeeCategoryId.TuitionFee == RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "fee_category_id", ""))
                                {
                                    DataRow editAmountRow = _schoolFeeDetailsTable.Rows[x];

                                    editAmountRow.BeginEdit();

                                    if (RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_fixed_amount_tuition_fee", false))
                                    {
                                        if (isFixedAmount)
                                        {
                                            editAmountRow["amount"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "amount", Decimal.Parse("0")) +
                                                this.GetFixedAmount(this.GetInternationalPercentage(), sysIdSchedule, isInternational);

                                            editAmountRow.EndEdit();

                                            break;
                                        }
                                    }
                                    else if (RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_per_unit_tuition_fee", false))
                                    {
                                        if (!isFixedAmount)
                                        {
                                            editAmountRow["amount"] = this.InsertWithdrawTuitionFee(this.TotalSubjectUnits(sysIdSchedule), 
                                                true, isInternational);

                                            editAmountRow.EndEdit();

                                            break;
                                        }
                                    }
                                }
                                else if (CommonExchange.SchoolFeeCategoryId.TuitionFee != 
                                    RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "fee_category_id", ""))
                                {
                                    break;
                                }

                                x++;
                            }

                            hasLoaded = true;
                            break;
                        }

                        index++;
                    }

                    if (!hasLoaded)
                    {
                        index = 0;

                        foreach (DataRow schedRow in _prematureDeloadedSubjectTable.Rows)
                        {
                            if (schedRow.RowState != DataRowState.Deleted &&
                                String.Equals(sysIdSchedule, RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_schedule", "")))
                            {
                                DataRow delRow = _prematureDeloadedSubjectTable.Rows[index];

                                if (delRow.RowState == DataRowState.Modified || delRow.RowState == DataRowState.Added)
                                {
                                    _prematureDeloadedSubjectTable.AcceptChanges();
                                }

                                delRow.Delete();

                                DataRow newRow = _studentLoadTable.NewRow();

                                newRow["load_id"] = --_countLoadId;
                                newRow["sysid_schedule"] = sysIdSchedule;
                                newRow["is_loaded"] = false;

                                _studentLoadTable.Rows.Add(newRow);                                

                                Int32 x = 0;

                                Boolean isFixedAmount = this.IsFixedAmountSubject(sysIdSchedule);

                                foreach (DataRow feeRow in _schoolFeeDetailsTable.Rows)
                                {
                                    if (feeRow.RowState != DataRowState.Deleted &&
                                        CommonExchange.SchoolFeeCategoryId.TuitionFee == 
                                        RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "fee_category_id", ""))
                                    {
                                        DataRow editAmountRow = _schoolFeeDetailsTable.Rows[x];

                                        editAmountRow.BeginEdit();

                                        if (RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_fixed_amount_tuition_fee", false))
                                        {
                                            if (isFixedAmount)
                                            {
                                                editAmountRow["amount"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "amount", Decimal.Parse("0")) +
                                                    this.GetFixedAmount(this.GetInternationalPercentage(), sysIdSchedule, isInternational);

                                                editAmountRow.EndEdit();

                                                break;
                                            }
                                        }
                                        else if (RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_per_unit_tuition_fee", false))
                                        {
                                            if (!isFixedAmount)
                                            {
                                                editAmountRow["amount"] = this.InsertWithdrawTuitionFee(this.TotalSubjectUnits(sysIdSchedule), 
                                                    true, isInternational);

                                                editAmountRow.EndEdit();

                                                break;
                                            }
                                        }
                                    }
                                    else if (CommonExchange.SchoolFeeCategoryId.TuitionFee != 
                                        RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "fee_category_id", ""))
                                    {
                                        break;
                                    }

                                    x++;
                                }

                                break;
                            }

                            index++;
                        }
                    }

                    index = 0;

                    foreach (DataRow schedRow in _subjectScheduleTable.Rows)
                    {
                        if (schedRow.RowState != DataRowState.Deleted &&
                            (String.Equals(sysIdSchedule, RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_schedule", "")) &&
                            (!RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "is_loaded_to_student", false) &&
                            !RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "is_premature_deloaded", false))))
                        {
                            DataRow editRow = _subjectScheduleTable.Rows[index];

                            editRow.BeginEdit();

                            editRow["is_loaded_to_student"] = true;
                            editRow["is_premature_deloaded"] = false;

                            editRow.EndEdit();

                            break;
                        }

                        index++;
                    }
                }
            }

            return isValid;
        }//----------------------------

        //this function gets the selected student
        public DataTable GetSearchedStudentInformation(CommonExchange.SysAccess userInfo,
            String queryString, String dateStart, String dateEnd, String yearLevelId, String courseId)
        {
            DataTable newTable = new DataTable("StudentSearchByStudentNameIdCardNumberTable");
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

            using (RemoteClient.RemCntStudentManager remClient = new RemoteClient.RemCntStudentManager())
            {
                _studentTable = remClient.SelectStudentInformation(userInfo, queryString, dateStart, dateEnd, courseId, yearLevelId);
            }

            foreach (DataRow studentRow in _studentTable.Rows)
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
                newRow["emer_relationship_description"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "emer_relationship_description", String.Empty);
                newRow["emer_present_address"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "emer_present_address", String.Empty);
                newRow["emer_present_phone_nos"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "emer_present_phone_nos", String.Empty);
                newRow["emer_home_address"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "emer_home_address", String.Empty);
                newRow["emer_home_phone_nos"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "emer_home_phone_nos", String.Empty);

                newTable.Rows.Add(newRow);

                String strFilter = "course_group_id = '" + RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "course_group_id", "") + "'";
                DataRow[] selectRow = _courseGroupTable.Select(strFilter);

                if (selectRow.Length < 1)
                {
                    DataRow newRowCourse = _courseGroupTable.NewRow();

                    newRowCourse["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "course_group_id", "");

                    _courseGroupTable.Rows.Add(newRowCourse);
                }
            }

            newTable.AcceptChanges();                    

            return newTable;
        }//-----------------------------     

        //this function returns seacrch subject information
        public DataTable GetSearchedSubjectInformation(String queryString)
        {
            DataTable newTable = new DataTable("SubjectTableTemp");
            newTable.Columns.Add("checkbox_column", System.Type.GetType("System.Boolean"));
            newTable.Columns.Add("sysid_schedule", System.Type.GetType("System.String"));
            newTable.Columns.Add("subject_code_title", System.Type.GetType("System.String"));
            newTable.Columns.Add("lecture_units", System.Type.GetType("System.Byte"));
            newTable.Columns.Add("lab_units", System.Type.GetType("System.Byte"));
            newTable.Columns.Add("no_hours", System.Type.GetType("System.String"));
            newTable.Columns.Add("slots_available", System.Type.GetType("System.String"));
            newTable.Columns.Add("department_name", System.Type.GetType("System.String"));

            if (_subjectScheduleDetailsTable != null && _openSubjectTable != null)
            {
                queryString = queryString.Replace("*", "").Replace("%", "").Replace("'","''");

                foreach (DataRow openRow in _openSubjectTable.Rows)
                {  
                    String strFilter = "sysid_schedule = '" + RemoteServerLib.ProcStatic.DataRowConvert(openRow, "sysid_schedule", "") + "'" + 
                        " AND is_loaded_to_student = 0";
                    DataRow[] scheduleRows = _subjectScheduleTable.Select(strFilter);

                    foreach (DataRow schedRow in scheduleRows)
                    {
                        strFilter = "sysid_schedule = '" + RemoteServerLib.ProcStatic.DataRowConvert(openRow, "sysid_schedule", "") + "'" + 
                            " AND (section LIKE '%" + queryString + "%' OR subject_code LIKE '%" + queryString + 
                            "%' OR descriptive_title LIKE '%" + queryString + "%')";
                        DataRow[] detailsRows = _subjectScheduleDetailsTable.Select(strFilter);

                        foreach (DataRow subRow in detailsRows)
                        {
                            DataRow newRow = newTable.NewRow();

                            newRow["checkbox_column"] = false;
                            newRow["sysid_schedule"] = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "sysid_schedule", "");
                            newRow["subject_code_title"] = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_code", "") + " - " +
                                RemoteServerLib.ProcStatic.DataRowConvert(subRow, "descriptive_title", "");
                            newRow["lecture_units"] = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "subject_lecture_units", Byte.Parse("0"));
                            newRow["lab_units"] = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "subject_lab_units", Byte.Parse("0"));
                            newRow["no_hours"] = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "subject_no_hours", "");

                            Int16 totalRoomCapacity = (Int16)(RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "maximum_capacity", Byte.Parse("0")) +
                                RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "additional_slots", Int16.Parse("0")));

                            newRow["slots_available"] = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "slots_available", Int16.Parse("0")) == -32768 ?
                                "TBA/F" : (totalRoomCapacity -
                                (totalRoomCapacity - RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "slots_available", Int16.Parse("0")))) <= 0 ?
                                totalRoomCapacity.ToString() + "/" + totalRoomCapacity.ToString() :
                                (totalRoomCapacity - RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "slots_available", Int16.Parse("0"))).ToString() + "/" +
                                totalRoomCapacity.ToString();

                            newTable.Rows.Add(newRow);

                            break;
                        }
                    }                    
                }
            }

            return newTable;
        }//------------------------------

        //this fucntion returns searched Additional Fee
        public DataTable GetSearchedOptinalFee(String queryString)
        {
            DataTable newTable = new DataTable("OptionalFeeTable");
            newTable.Columns.Add("sysid_feedetails", System.Type.GetType("System.String"));
            newTable.Columns.Add("particular_description", System.Type.GetType("System.String"));
            newTable.Columns.Add("amount", System.Type.GetType("System.String"));

            if (_optionalSchoolFeeDetailsTable != null)
            {
                queryString = queryString.Replace("*", "").Replace("%", "").Replace("'", "''");

                String strFilter = "particular_description LIKE '%" + queryString + "%'";
                DataRow[] selectRow = _optionalSchoolFeeDetailsTable.Select(strFilter);

                foreach (DataRow feeRow in selectRow)
                {
                    if (feeRow.RowState != DataRowState.Deleted &&
                        !this.IsOptionalFeeExistCharge(RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "sysid_feeparticular", "")))
                    {
                        DataRow newRow = newTable.NewRow();

                        newRow["sysid_feedetails"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "sysid_feedetails", "");
                        newRow["particular_description"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "particular_description", "");
                        newRow["amount"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "amount", Decimal.Parse("0")).ToString("N");

                        newTable.Rows.Add(newRow);
                    }
                }

                newTable.AcceptChanges();
            }

            return newTable;
        }//-----------------------------

        //this function will get student Grades from student transcript table
        public DataTable GetStudentGrades()
        {
            DataTable newTable = this.StudentTranscriptTable;

            if (_studentTranscriptTable != null)
            {
                foreach (DataRow transRow in _studentTranscriptTable.Rows)
                {
                    DataRow newRow = newTable.NewRow();

                    newRow["term_session"] = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "term_session", String.Empty);
                    newRow["subject_code"] = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "subject_code", String.Empty) + " " +
                        RemoteServerLib.ProcStatic.DataRowConvert(transRow, "subject_no", String.Empty);
                    newRow["descriptive_title"] = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "descriptive_title", String.Empty);
                    newRow["credit_units"] = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "credit_units", String.Empty);
                    newRow["no_of_hours"] = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "no_of_hours", String.Empty);
                    newRow["final_grade"] = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "final_grade", String.Empty);
                    newRow["re_exam"] = RemoteServerLib.ProcStatic.DataRowConvert(transRow, "re_exam", String.Empty);

                    newTable.Rows.Add(newRow);
                }
            }

            return newTable;
        }//-----------------------------

        //this function returns the student details
        public CommonExchange.Student GetDetailsStudentInformation(CommonExchange.SysAccess userInfo, String studentId, String startUp)
        {
            CommonExchange.Student studentInfo = new CommonExchange.Student();

            if (!String.IsNullOrEmpty(studentId))
            {
                String strFilter = "student_id = '" + studentId + "'";
                DataRow[] selectRow = _studentTable.Select(strFilter);

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
                    studentInfo.IsNoDownpaymentRequired = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "is_no_downpayment_required", false);

                    break;
                }

                studentInfo.PersonInfo.FilePath = base.GetPersonImagePath(userInfo, studentInfo.PersonInfo.PersonSysId, 
                    studentInfo.PersonInfo.PersonImagesFolder(startUp));
            }

            return studentInfo;
        }//---------------------------- 

        //this function returns the student details
        public CommonExchange.Student GetDetailsStudentInformation(CommonExchange.SysAccess userInfo, String studentId)
        {
            CommonExchange.Student studentInfo = new CommonExchange.Student();

            if (!String.IsNullOrEmpty(studentId))
            {
                String strFilter = "student_id = '" + studentId + "'";
                DataRow[] selectRow = _studentTable.Select(strFilter);

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
                    studentInfo.IsNoDownpaymentRequired = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "is_no_downpayment_required", false);

                    break;
                }
            }

            return studentInfo;
        }//----------------------------

        //this function get student enrolment level information
        public CommonExchange.StudentEnrolmentLevel GetStudentEnrolmentLevelInfo(Int32 index)
        {
            CommonExchange.StudentEnrolmentLevel enrolmentLevelInfo = new CommonExchange.StudentEnrolmentLevel();

            if (index != 0)
            {
                DataRow studRow = _studentLevelTable.Rows[index - 1];

                enrolmentLevelInfo.EnrolmentLevelSysId = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_enrolmentlevel", "");
                enrolmentLevelInfo.SchoolFeeLevelInfo.FeeLevelSysId = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_feelevel", "");
                enrolmentLevelInfo.IsGraduateStudent = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "is_graduate_student", false);
                enrolmentLevelInfo.IsInternational = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "is_international", false);
                enrolmentLevelInfo.IsMarkedDeleted = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "is_marked_deleted", false);
                enrolmentLevelInfo.IsEntryLevel = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "is_entry_level", false);
                enrolmentLevelInfo.LevelSection = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "level_section", "");
                enrolmentLevelInfo.SemesterInfo.SemesterSysId = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_semester", String.Empty);
                enrolmentLevelInfo.SchoolFeeLevelInfo.YearLevelInfo.YearLevelDescription =
                    RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_level_description", "");
                enrolmentLevelInfo.StudentEnrolmentCourseInfo.EnrolmentCourseSysId =
                    RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_enrolmentcourse", String.Empty);
                enrolmentLevelInfo.StudentEnrolmentCourseInfo.CourseInfo.CourseId =
                    RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_id", String.Empty);
            }

            return enrolmentLevelInfo;
        }//------------------------

        //this function get student enrolment level information
        public CommonExchange.StudentEnrolmentLevel GetStudentEnrolmentLevelInfo(String enrolmentLevelSysId)
        {
            CommonExchange.StudentEnrolmentLevel enrolmentLevelInfo = new CommonExchange.StudentEnrolmentLevel();

            String strFilter = "sysid_enrolmentlevel = '" + enrolmentLevelSysId + "'";
            DataRow[] selectRow = _studentLevelTable.Select(strFilter);

            foreach (DataRow studRow in selectRow)
            {
                enrolmentLevelInfo.EnrolmentLevelSysId = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_enrolmentlevel", "");
                enrolmentLevelInfo.SchoolFeeLevelInfo.FeeLevelSysId = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_feelevel", "");
                enrolmentLevelInfo.IsGraduateStudent = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "is_graduate_student", false);
                enrolmentLevelInfo.IsInternational = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "is_international", false);
                enrolmentLevelInfo.IsMarkedDeleted = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "is_marked_deleted", false);
                enrolmentLevelInfo.IsEntryLevel = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "is_entry_level", false);
                enrolmentLevelInfo.LevelSection = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "level_section", "");
                enrolmentLevelInfo.SemesterInfo.SemesterSysId = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_semester", String.Empty);
            }

            return enrolmentLevelInfo;
        }//------------------------

        //this fucntion gets the subject code title
        public String GetSubjectCodeTitle(String sysIdSchedule)
        {
            String value = String.Empty;

            String strFilter = "sysid_schedule = '" + sysIdSchedule + "'";
            DataRow[] selectRow = _subjectScheduleTable.Select(strFilter);

            foreach (DataRow subRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_code", "") + " - " +
                    RemoteServerLib.ProcStatic.DataRowConvert(subRow, "descriptive_title", "");

                break;
            }

            return value;
        }//-------------------------

        //this fucntion gets the subject code title by sysid schedule details
        public String GetSubjectCodeTitleBySchedDetails(String sysidScheduleDetails)
        {
            String value = String.Empty;

            String strFilter = "sysid_scheddetails = '" + sysidScheduleDetails + "'";
            DataRow[] selectRow = _subjectScheduleDetailsTable.Select(strFilter);

            foreach (DataRow subRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(subRow, "subject_code", "") + " - " +
                    RemoteServerLib.ProcStatic.DataRowConvert(subRow, "descriptive_title", "");

                break;
            }

            return value;
        }//-------------------------

        //this function gets the particula description
        public String GetParticularDescription(String sysIdFeeDetails)
        {
            String value = String.Empty;

            String strFilter = "sysid_feedetails = '" + sysIdFeeDetails + "'";
            DataRow[] selectRow = _optionalSchoolFeeDetailsTable.Select(strFilter);

            foreach (DataRow feeRow in selectRow)
            {
                if (feeRow.RowState != DataRowState.Deleted)
                {
                    value = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "particular_description", "") + " - " +
                        RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "amount", Decimal.Parse("0")).ToString("N");

                    break;
                }
            }

            return value;
        }//---------------------------

        //AC
        //this function gets the enrolemt course sysmtem id
        public String GetEnrolmentCourseSysId(Int32 index, String sysIdSemester, Boolean isSemestral, ref String courseId, ref Boolean isCurrentCourse)
        {
            String value = String.Empty;

            if (index != 0)
            {
                DataRow resultrow = _studentCourseTable.Rows[index - 1];

                value = RemoteServerLib.ProcStatic.DataRowConvert(resultrow, "sysid_enrolmentcourse", "");

                courseId = RemoteServerLib.ProcStatic.DataRowConvert(resultrow, "course_id", "");

                isCurrentCourse = RemoteServerLib.ProcStatic.DataRowConvert(resultrow, "is_current_course", false);

            }

            return value;
        }//---------------------------
       
        //this function gets the school year date start
        public DateTime GetSchoolYearDateStart(String yearId)
        {
            DateTime dateStart = DateTime.Parse(_serverDateTime);

            foreach (DataRow yearRow in _classDataSet.Tables["SchoolFeeInformationTable"].Rows)
            {
                if (String.Equals(yearId, yearRow["year_id"].ToString()) && DateTime.TryParse(yearRow["date_start"].ToString(), out dateStart))
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
        public DateTime GetSemesterDateStart(String sysIdSemester)
        {
            DateTime dateStart = DateTime.Parse(_serverDateTime);

            foreach (DataRow semRow in _classDataSet.Tables["SemesterInformationTable"].Rows)
            {
                if (String.Equals(sysIdSemester, semRow["sysid_semester"].ToString()) &&
                    DateTime.TryParse(semRow["date_start"].ToString(), out dateStart))
                {
                    break;
                }
            }

            return dateStart;
        }//----------------------------------------    

        //this function gets the semester date end
        public DateTime GetSemesterDateEnd(String sysIdSemester)
        {
            DateTime dateEnd = DateTime.Parse(_serverDateTime);

            foreach (DataRow yearRow in _classDataSet.Tables["SemesterInformationTable"].Rows)
            {
                if (String.Equals(sysIdSemester, yearRow["sysid_semester"].ToString()) &&
                    DateTime.TryParse(yearRow["date_end"].ToString(), out dateEnd))
                {
                    break;
                }
            }

            return dateEnd;
        }//------------------------------

        //this function gets the school year year id
        public String GetSchoolYearYearId(Int32 index)
        {
            DataRow yearRow = _classDataSet.Tables["SchoolFeeInformationTable"].Rows[index];

            return yearRow["year_id"].ToString();
        }//----------------------------

        //this function gets the semester system id
        public String GetSemesterSystemId(Int32 yearIndex, Int32 semIndex)
        {
            DataRow yearRow = _classDataSet.Tables["SchoolFeeInformationTable"].Rows[yearIndex];
          
            String strFilter = "year_id = '" + yearRow["year_id"].ToString() + "'";
            DataRow[] selectRow = _classDataSet.Tables["SemesterInformationTable"].Select(strFilter);

            if (semIndex >= 0)
            {
                DataRow semRow = selectRow[semIndex];

                return RemoteServerLib.ProcStatic.DataRowConvert(semRow, "sysid_semester", "");
            }
            else
            {
                return String.Empty;
            }            
        }//-----------------------------------------

        //this function gets the school fee information system id
        public String GetFeeInformationSysId(Int32 index)
        {
            DataRow feeRow = _classDataSet.Tables["SchoolFeeInformationTable"].Rows[index];

            return feeRow["sysid_schoolfee"].ToString();
        }//----------------------------

        //this function gets the course id
        public String GetCourseId(String sysIdSemester, Boolean isSemestral, Boolean isCurrentCourse)
        {
            String value = String.Empty;
            String strFilter = String.Empty;

            if (isSemestral)
            {
                strFilter = "sysid_semester = '" + sysIdSemester + "' AND is_current_course = " + isCurrentCourse;
            }

            DataRow[] selectRow = _studentCourseTable.Select(strFilter);

            foreach (DataRow courseRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_id", "");

                break;
            }

            return value;
        }//------------------------    

        //this fucntion will get course description by course system id
        public String GetCourseDescription(String enrollmentCourseSysID)
        {
            String courseDescription = String.Empty;


            if (_studentCourseTable != null)
            {
                String strFilter = "sysid_enrolmentcourse = '" + enrollmentCourseSysID + "'";
                DataRow[] selectRow = _studentCourseTable.Select(strFilter);

                foreach (DataRow courseRow in selectRow)
                {
                    courseDescription = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_title", String.Empty) + " - [" +
                        RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_acronym", String.Empty) + "]";

                    break;
                }
            }

            return courseDescription;
        }//-------------------------

        //this function will gets current course system id
        public String GetStudentCurrentCourseSystemIdDescripton(Boolean isForSystemId)
        {
            String enrolmentCourseSysIdDescription = String.Empty;

            if (_studentCourseTable != null)
            {
                String strFilter = "is_current_course = 1";
                DataRow[] selectRow = _studentCourseTable.Select(strFilter);

                foreach (DataRow courseRow in selectRow)
                {
                    enrolmentCourseSysIdDescription = isForSystemId ?
                        RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "sysid_enrolmentcourse", String.Empty) :
                        RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_title", String.Empty) + " - [" +
                        RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_acronym", String.Empty) + "]";

                    break;
                }
            }

            return enrolmentCourseSysIdDescription;
        }//------------------------
           
        //this function determines if is semestral
        public Boolean IsSemestral()
        {
            Boolean isSemestral = false;

            if (_studentCourseTable != null)
            {
                foreach (DataRow semRow in _studentCourseTable.Rows)
                {
                    if (RemoteServerLib.ProcStatic.DataRowConvert(semRow, "is_current_course", false))
                    {
                        isSemestral = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "is_semestral", false);

                        break;
                    }
                }
            }

            return isSemestral;
        }//------------------------      

        //this fucntion determines if year level is enrolled
        public Boolean IsEnrolled(Int32 index)
        {
            Boolean isEnrolled = false;

            if (index != 0)
            {
                DataRow studRow = _studentLevelTable.Rows[index - 1];

                isEnrolled = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "is_enrolled", false);
            }

            return isEnrolled;
        }//--------------------------      

        //this fucntion determins if year level is graudate level
        public Boolean IsGraduateLevel(Int32 index)
        {
            Boolean isGraduateLevel = false;

            if (index != 0 && index != -1)
            {
                DataRow levelRow = _studentLevelTable.Rows[index - 1];

                isGraduateLevel = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "is_graduate_level", false);
            }

            return isGraduateLevel;
        }//---------------------------        

        //this procedure will determine if the examination schedule is clearance included
        public Boolean IsClearanceIncluded(String majorExamId)
        {
            Boolean value = false;

            if (_majorExamScheduleTable != null)
            {
                String strFilter = "major_exam_id = '" + majorExamId + "'";
                DataRow[] selectRow = _majorExamScheduleTable.Select(strFilter);

                foreach (DataRow examRow in selectRow)
                {
                    value = RemoteServerLib.ProcStatic.DataRowConvert(examRow, "is_clearance_included", false);
                }
            }

            return value;

        }//----------------------------

        //this function will determine the current course
        public Boolean IsCurrentCourse(String sysIdEnrolmentCourse)
        {
            Boolean value = false;

            String strFilter = "sysid_enrolmentcourse = '" + sysIdEnrolmentCourse + "'";
            DataRow[] selectRow = _studentCourseTable.Select(strFilter);

            foreach (DataRow courseRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "is_current_course", false);
            }

            return value;
        }//---------------------
        
        //this procedure will get student course group id by student system id
        public String GetStudentCourseGroupId(String studentSysId)
        {
            String value = String.Empty;

            String strFilter = "sysid_student = '" + studentSysId + "'";
            DataRow[] selectRow = _studentTable.Select(strFilter);

            foreach (DataRow studRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_group_id", "");

                break;
            }

            return value;
        }//-----------------------         
        
        //this fucntion gets the course yearlevel string format
        public String GetCourseYearLevelStringFormat(CheckedListBox cbXBase, Boolean isCourse)
        {
            StringBuilder strValue = new StringBuilder();

            if (cbXBase.CheckedIndices.Count >= 1)
            {
                IEnumerator myEnum = cbXBase.CheckedIndices.GetEnumerator();
                Int32 x;
                
                while (myEnum.MoveNext() != false)
                {
                    x = (Int32)myEnum.Current;
                    
                    if (isCourse)
                    {
                        strValue.Append(this.GetCourseId(x) + ", ");
                    }
                    else
                    {
                        strValue.Append(this.GetYearLevelId(x) + ", ");
                    }
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
        }//-------------------------

        //this fucntion determines if the school fee details is optional and is office access
        public Boolean IsOptionalFeeAndIsOfficeAccess(Int64 opionalFeeId)
        {
            Boolean isValid = false;

            String strFilter = "optional_fee_id = " + opionalFeeId;
            DataRow[] selectRow = _optionalFeeTable.Select(strFilter);

            foreach (DataRow feeRow in selectRow)
            {
                if (feeRow.RowState != DataRowState.Deleted && (RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_optional_fee", false) &&
                    RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_office_access", false)))
                {
                    isValid = true;
                }

                break;
            }

            DataRow[] selectSchoolFeeDetails = _schoolFeeDetailsTable.Select(strFilter);

            foreach (DataRow feeRow in selectSchoolFeeDetails)
            {
                if (feeRow.RowState != DataRowState.Deleted && (RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_optional_fee", false) &&
                    RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_office_access", false)))
                {
                    isValid = true;
                }

                break;
            }

            return isValid;
        }//--------------------------

        //this fucntion determins if there are already schedule loaded
        public Boolean HasUnrecordedSubjectLoad()
        {
            Boolean isValid = false;

            foreach (DataRow loadRow in _studentLoadTable.Rows)
            {
                if (loadRow.RowState != DataRowState.Deleted && !RemoteServerLib.ProcStatic.DataRowConvert(loadRow, "is_loaded", false))
                {
                    isValid = true;

                    break;
                }
                else if (loadRow.RowState == DataRowState.Deleted)
                {
                    isValid = true;

                    break;
                }
            }

            return isValid;
        }//------------------------

        //determines if the student has payment made by date start end
        public Boolean IsExistsPaymentBySysIDStudentDateStartEndStudentPayments(CommonExchange.SysAccess userInfo, String studentSysId,
            String dateStart, String dateEnd)
        {
            Boolean value = false;

            using (RemoteClient.RemCntCashieringManager remClient = new RemoteClient.RemCntCashieringManager())
            {
                value = remClient.IsExistsPaymentBySysIDStudentDateStartEndStudentPayments(userInfo, studentSysId, dateStart, dateEnd);
            }

            return value;
        }//-----------------------

        //this function gets the semester description
        public String GetSemesterDescription(String sysIdSemester)
        {
            String value = String.Empty;

            String strFilter = "sysid_semester = '" + sysIdSemester + "'";
            DataRow[] selectRow = _classDataSet.Tables["SemesterInformationTable"].Select(strFilter);

            foreach (DataRow semRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "semester_description", "");
            }

            return value;
        }//------------------------------------

        //this function gets the year level description
        public String GetYearLevelDescription(String sysIdSchoolFee)
        {
            String value = String.Empty;

            String strFilter = "sysid_schoolfee = '" + sysIdSchoolFee + "'";
            DataRow[] selectRow = _classDataSet.Tables["SchoolFeeInformationTable"].Select(strFilter);

            foreach (DataRow yearRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "year_description", "");
            }

            return value;
        }//----------------------------

        //this function get the student enrolmentlevel list format
        public String GetStudentEnrolmentLevelFormatForChangeStudentEnrolmentLevel()
        {
            StringBuilder strValue = new StringBuilder();

            if (_studentLevelTable != null)
            {
                foreach (DataRow studRow in _studentLevelTable.Rows)
                {
                    if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_enrolmentlevel", "")))
                    {
                        strValue.Append(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_enrolmentlevel", "") + ", ");
                    }
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
        }//------------------------------   
                
        //this fucntion will compute for additional/withdrawn tuition fee
        private Decimal InsertWithdrawTuitionFee(Int32 subjectUnits, Boolean isInsert, Boolean isInternational)
        {
            Decimal amountPerUnit = 0;
            Decimal computedTuitionFee = 0;

            Single internationalPercentage = 0;

            foreach (DataRow feeRow in _schoolFeeDetailsTable.Rows)
            {
                if (CommonExchange.SchoolFeeCategoryId.TuitionFee == RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "fee_category_id", ""))
                {
                    if (feeRow.RowState != DataRowState.Deleted &&
                        (!RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_per_unit_tuition_fee", false) &&
                        !RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_per_year_tuition_fee", false) &&
                        !RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_fixed_amount_tuition_fee", false) &&
                        !RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_special_class_tuition_fee", false)))
                    {
                        amountPerUnit = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "amount", Decimal.Parse("0"));
                    }
                    else if (feeRow.RowState != DataRowState.Deleted &&
                       RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_per_unit_tuition_fee", false))
                    {
                        computedTuitionFee = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "amount", Decimal.Parse("0"));

                        internationalPercentage = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "international_percentage", Single.Parse("0"));
                    }
                }
                else
                {
                    break;
                }
            }

            if (isInsert)
            {
                if (isInternational)
                {
                    Decimal computedAmount = 0;

                    computedAmount = (amountPerUnit * subjectUnits) * (Decimal)((internationalPercentage / 100) + 1);

                    return computedTuitionFee + computedAmount;
                }
                else
                    return computedTuitionFee + (amountPerUnit * subjectUnits);
            }
            else
            {
                if (isInternational)
                {
                    Decimal computedAmount = 0;

                    computedAmount = (amountPerUnit * subjectUnits) * (Decimal)((internationalPercentage / 100) + 1);

                    return computedTuitionFee - computedAmount;
                }
                else
                    return computedTuitionFee - (amountPerUnit * subjectUnits);
            }
        }//------------------------------

        //this fucntion computes the total subject units by sysid_schedule
        private Int32 TotalSubjectUnits(String sysIdSchedule)
        {
            Int32 totalUnits = 0;

            String strFilter = "sysid_schedule = '" + sysIdSchedule + "'";
            DataRow[] selectRow = _subjectScheduleTable.Select(strFilter);

            foreach (DataRow schedRow in selectRow)
            {
                if (schedRow.RowState != DataRowState.Deleted)
                {
                    totalUnits = (Int32)RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "subject_lecture_units", Byte.Parse("0")) +
                        (Int32)RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "subject_lab_units", Byte.Parse("0"));

                    break;
                }
            }

            return totalUnits;
        }//------------------------

        //this function determines if thee subject is fixed amount
        private Boolean IsFixedAmountSubject(String sysIdSchedule)
        {
            Boolean value = false;

            String strFilter = "sysid_schedule = '" + sysIdSchedule + "'";
            DataRow[] selectRow = _subjectScheduleTable.Select(strFilter);

            foreach (DataRow schedRow in selectRow)
            {
                if (schedRow.RowState != DataRowState.Deleted)
                {
                    value = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "is_fixed_amount", false);

                    break;
                }
            }

            return value;
        }//--------------------------

        //this fucntion gets international percentage
        private Single GetInternationalPercentage()
        {
            Single amount = 0;

            foreach (DataRow feeRow in _schoolFeeDetailsTable.Rows)
            {
                if (feeRow.RowState != DataRowState.Deleted &&
                    RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_per_unit_tuition_fee", false))
                {
                    amount = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "international_percentage", Single.Parse("0"));

                    break;
                }
            }

            return amount;
        }//--------------------------

        //this function gets fixed amount
        private Decimal GetFixedAmount(Single internationalPercentage, String sysIdSchedule, Boolean isInternational)
        {
            Decimal amount = 0;

            String strFilter = "sysid_schedule = '" + sysIdSchedule + "'";
            DataRow[] selectRow = _subjectScheduleTable.Select(strFilter);

            foreach (DataRow schedRow in selectRow)
            {
                if (schedRow.RowState != DataRowState.Deleted && RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "is_fixed_amount", false))
                {
                    if (isInternational)
                        amount = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "amount", Decimal.Parse("0")) *
                            (Decimal)((internationalPercentage / 100) + 1);
                    else
                        amount = RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "amount", Decimal.Parse("0"));
                }

                break;
            }

            return amount;
        }//--------------------------

        //this function get schedule details sysmte id....used to generate day time schedule table
        private Boolean GetConflictSchdule(String sysIdScheduleLoaded, String sysIdScheduleCached, ref String value)
        {
            Boolean isConflict = false;

            if (_subjectScheduleDetailsTable != null)
            {
                String strFilter = "sysid_schedule = '" + sysIdScheduleLoaded + "'";
                DataRow[] selectRow = _subjectScheduleDetailsTable.Select(strFilter);

                foreach (DataRow schedRow in selectRow)
                {
                    if (schedRow.RowState != DataRowState.Deleted)
                    {
                        DataTable loadedTable = this.GenerateScheduleTable(RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_scheddetails", ""));

                        strFilter = "sysid_schedule = '" + sysIdScheduleCached + "'";
                        DataRow[] selectRowCached = _subjectScheduleDetailsTable.Select(strFilter);

                        foreach(DataRow cachedRow in selectRowCached)
                        {
                             if (this.IsConflict(loadedTable, 
                                 this.GenerateScheduleTable(RemoteServerLib.ProcStatic.DataRowConvert(cachedRow, "sysid_scheddetails", "")), ref value))
                             {
                                 isConflict = true;
                             }
                        }                                              
                    }
                }
            }

            return isConflict;
        }//-------------------------    

        //this function gets the course id
        private String GetCourseId(Int32 index)
        {
            if (_classDataSet.Tables["CourseInformationTable"] != null)
            {
                DataRow courseRow = _classDataSet.Tables["CourseInformationTable"].Rows[index];

                return courseRow["course_id"].ToString();
            }
            else
            {
                return String.Empty;
            }
        }//----------------------------

        //this rucntion will determines if opetional fee already exist in student charges
        private Boolean IsOptionalFeeExistCharge(String sysIdFeeParticular)
        {
            Boolean isExist = false;

            String strFilter = "sysid_feeparticular = '" + sysIdFeeParticular + "'";
            DataRow[] selectRow = _schoolFeeDetailsTable.Select(strFilter);

            if (selectRow.Length >= 1)
            {
                isExist = true;
            }

            return isExist;
        }//--------------------------

        //this function gets the year level id -- based on checklistbox
        private String GetYearLevelId(Int32 index)
        {
            if (_classDataSet.Tables["YearLevelInformationTable"] != null)
            {
                DataRow levelRow = _classDataSet.Tables["YearLevelInformationTable"].Rows[index];

                return RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_id", "");
            }
            else
            {
                return String.Empty;
            }
        }//----------------------------

        //this procedure will get selected course major
        public CommonExchange.EnrolmentCourseMajor GetSelectedCourseMajor(Int32 index)
        {
            CommonExchange.EnrolmentCourseMajor enrolmentCourseMajor = new CommonExchange.EnrolmentCourseMajor();

            if (_courseMajorTable != null)
            {
                DataRow majorRow = _courseMajorTable.Rows[index];

                enrolmentCourseMajor.CourseMajorId = RemoteServerLib.ProcStatic.DataRowConvert(majorRow, "course_major_id", Int64.Parse("0"));
                enrolmentCourseMajor.CourseMajorInfo.MajorInformationId =
                    RemoteServerLib.ProcStatic.DataRowConvert(majorRow, "major_information_id", String.Empty);
                enrolmentCourseMajor.IsCurrentMajor = true;
                enrolmentCourseMajor.ObjectState = DataRowState.Added;
            }

            return enrolmentCourseMajor;
        }//---------------------

        //this procedure will get current course major
        public CommonExchange.EnrolmentCourseMajor GetCurrentCourseMajor()
        {
            CommonExchange.EnrolmentCourseMajor enrolmentCourseMajor = new CommonExchange.EnrolmentCourseMajor();

            if (_courseMajorTable != null)
            {
                String strFilter = "is_current_major = 1";
                DataRow[] selectRow = _courseMajorTable.Select(strFilter);

                foreach (DataRow majorRow in selectRow)
                {
                    enrolmentCourseMajor.CourseMajorId = RemoteServerLib.ProcStatic.DataRowConvert(majorRow, "course_major_id", Int64.Parse("0"));
                    enrolmentCourseMajor.CourseMajorInfo.MajorInformationId =
                        RemoteServerLib.ProcStatic.DataRowConvert(majorRow, "major_information_id", String.Empty);
                    enrolmentCourseMajor.IsCurrentMajor = false;
                    enrolmentCourseMajor.ObjectState = DataRowState.Deleted;

                    break;
                }
            }

            return enrolmentCourseMajor;
        }//----------------------
        
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

                        String endTime = String.Empty;

                        DateTime dbEnd = DateTime.MinValue;

                        if (DateTime.TryParse(weekTimeTable.Rows[timeList[x].EndTime]["time_description"].ToString(), out dbEnd))
                        {
                            if (weekTimeTable.Rows[timeList[x].StartTime] == weekTimeTable.Rows[timeList[x].EndTime])
                            {
                                //daytime control (9 is the same value of time time interval in daytime control used in subject scheduling).
                                endTime = DateTime.Parse(dbEnd.AddMinutes(9).ToString()).ToString("HH:mm") + "; ";
                            }
                            else
                            {
                                endTime = DateTime.Parse(weekTimeTable.Rows[timeList[x].EndTime]["time_description"].ToString()).ToString("HH:mm") + "; ";
                            }
                        }

                        schedDayTime.Append(" " + DateTime.Parse(weekTimeTable.Rows[timeList[x].StartTime]["time_description"].ToString()).ToString("HH:mm") +
                            " - " + endTime);
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
        }//--------------------------------

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

        //this function will determines if the user has access to deloadsubject
        public Boolean HassAccessToDeloadReaload(CommonExchange.SysAccess userInfo, String scheduleSysId)
        {
            Boolean value = false;

            String strFilter = "sysid_schedule = '" + scheduleSysId + "'";
            DataRow[] selectRow = _subjectScheduleDetailsTable.Select(strFilter);

            foreach (DataRow schedRow in selectRow)
            {
                if (RemoteServerLib.ProcStatic.IsSystemAccessOfficeUser(userInfo,
                    RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "department_id", "")))
                {
                    value = true;

                    break;
                }
            }

            return value = RemoteServerLib.ProcStatic.IsSystemAccessAdmin(userInfo) ? true : value;
        }//------------------------------

        //this function will determine if the school year is for summer
        public Boolean IsSchoolYearForSummer(String yearId)
        {
            Boolean isSummer = false;

            String strFilter = "year_id = '" + yearId + "'";
            DataRow[] selectRow = _classDataSet.Tables["SchoolFeeInformationTable"].Select(strFilter);

            foreach (DataRow yearRow in selectRow)
            {
                isSummer = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "is_summer", false);
            }

            return isSummer;
        }//------------------------

        //this function will get department id
        public String GetDepartmentId(String courseId)
        {
            String value = String.Empty;

            String strFilter = "course_id = '" + courseId + "'";
            DataRow[] selectRow = _classDataSet.Tables["CourseInformationTable"].Select(strFilter);

            foreach (DataRow depRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(depRow, "department_id", String.Empty);
            }

            return value;
        }//-------------------

        //this function will get department description
        public String GetDepartmentDescription(String courseId)
        {
            String value = String.Empty;

            String strFilter = "course_id = '" + courseId + "'";
            DataRow[] selectRow = _classDataSet.Tables["CourseInformationTable"].Select(strFilter);

            foreach (DataRow depRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(depRow, "department_name", String.Empty);
            }

            return value;
        }//-------------------

        //this function get student school fee level system id (used for changing student enrollment year level)
        public String GetStudentSchoolFeeLevelSysId(Int32 index)
        {
            String feeLevelSysId = String.Empty;

            if (index != 0)
            {
                DataRow studRow = _changeStudentLevelTable.Rows[index - 1];

                feeLevelSysId = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_feelevel", "");             
            }

            return feeLevelSysId;
        }//------------------------

        //this procedure will determine if the level is allowed to shift
        public Boolean IsValidForShiftToCurrentCourseStudentEnrolmentLevel(CommonExchange.SysAccess userInfo, String enrolmentLevelSysId,
            String toShiftEnrolmentCourseSysId)
        {
            Boolean isAllowed = false;

            using (RemoteClient.RemCntStudentEnrolmentManager remClient = new RemoteClient.RemCntStudentEnrolmentManager())
            {
                isAllowed = remClient.IsValidForShiftToCurrentCourseStudentEnrolmentLevel(userInfo, enrolmentLevelSysId, toShiftEnrolmentCourseSysId);
            }

            return isAllowed;
        }//----------------------

        //this function will determine if the schedule has slots available
        public Boolean IsNoHasSlotsAvailable(String scheduleSysId)
        {
            Boolean noAvailable = false;

            if (_subjectScheduleTable != null)
            {
                String strFilter = "sysid_schedule = '" + scheduleSysId + "'";
                DataRow[] selectRow = _subjectScheduleTable.Select(strFilter);

                foreach (DataRow schedRow in selectRow)
                {
                    if (RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "slots_available", Int16.Parse("0")) == -32768)
                    {
                        noAvailable = false;
                    }
                    else if (RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "slots_available", Int16.Parse("0")) <= 0)
                    {
                        noAvailable = true;
                    }

                    break;
                }
            }

            return noAvailable;
        }//-----------------------

        //this function will determine if the year level is valid for level change
        public Boolean IsValidForYearLevelChange(CommonExchange.SysAccess userInfo, String studentSysId, String enrolmentLevelSysId)
        {
            Boolean isValid = false;

            using (RemoteClient.RemCntStudentEnrolmentManager remClient = new RemoteClient.RemCntStudentEnrolmentManager())
            {
                isValid = remClient.IsValidForYearLevelChangeEnrolmentLevel(userInfo, studentSysId, enrolmentLevelSysId);
            }

            return isValid;
        }//------------------

        //this fucntion will determines if it has a conflict schedule
        private Boolean IsConflict(DataTable loadedScheduleTable, DataTable cachedScheduleTable, ref String sysIdSchedDetails)
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

                        sysIdSchedDetails = RemoteServerLib.ProcStatic.DataRowConvert(loadedRow, "sysid_scheddetails", String.Empty);
                    }
                }

                if (isValid)
                {
                    break;
                }
            }

            return isValid;
        }//-------------------      
                      
        //this function gets the schedule details id list format
        private String GetScheduleDetailsSysIdList(DataTable scheduleDetailsTable, Boolean isMultiplePrint)
        {
            StringBuilder strValue = new StringBuilder();

            if (scheduleDetailsTable != null)
            {
                if (isMultiplePrint)
                {
                    DataTable tempTable = new DataTable();

                    tempTable = scheduleDetailsTable.DefaultView.ToTable(true, new String[1] { "sysid_scheddetails" });

                    foreach (DataRow schedRow in tempTable.Rows)
                    {
                        strValue.Append(RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_scheddetails", "") + ", ");
                    }
                }
                else
                {
                    foreach (DataRow schedRow in scheduleDetailsTable.Rows)
                    {
                        strValue.Append(RemoteServerLib.ProcStatic.DataRowConvert(schedRow, "sysid_scheddetails", "") + ", ");
                    }
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

        //this function get the student system id list format
        private String GetStudentSystemIdFormat()
        {
            StringBuilder strValue = new StringBuilder();

            if (_studentTable != null)
            {
                foreach (DataRow studRow in _studentTable.Rows)
                {
                    if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "")))
                    {
                        strValue.Append(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "") + ", ");
                    }
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
        }//------------------------------ 

        //this function get the student enrolmentlevel list format
        private String GetStudentEnrolmentLevelFormat()
        {
            StringBuilder strValue = new StringBuilder();

            if (_studentTable != null)
            {                
                foreach (DataRow studRow in _studentTable.Rows)
                {
                    if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_enrolmentlevel", "")))
                    {
                        strValue.Append(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_enrolmentlevel", "") + ", ");
                    }
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
        }//------------------------------  

        //this function get the student enrolmentlevel list format
        private String GetStudentEnrolmentLevelFormat(DataTable studentTable)
        {
            StringBuilder strValue = new StringBuilder();

            if (studentTable != null)
            {
                foreach (DataRow studRow in studentTable.Rows)
                {
                    if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_enrolmentlevel", "")))
                    {
                        strValue.Append(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_enrolmentlevel", "") + ", ");
                    }
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
        }//------------------------------  

        //this function get the student system id list format
        private String GetStudentCourseGroupSystemIdFormat(Boolean isStudent, Boolean isEnrolmentLevel)
        {
            StringBuilder strValue = new StringBuilder();

            DataTable tempTable = new DataTable("TemporaryTable");
            tempTable.Columns.Add("course_group_id", System.Type.GetType("System.String"));

            if (_studentTable != null)
            {
                foreach (DataRow studRow in _studentTable.Rows)
                {
                    if (isStudent && !isEnrolmentLevel)
                    {
                        if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "")))
                        {
                            strValue.Append(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "") + ", ");
                        }
                    }
                    else if (!isStudent && isEnrolmentLevel)
                    {
                        if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "")))
                        {
                            strValue.Append(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_enrolmentlevel", "") + ", ");
                        }
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_group_id", "")))
                        {
                            String strFilter = "course_group_id = '" + RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_group_id", "") + "'";
                            DataRow[] selectRow = tempTable.Select(strFilter);

                            if (selectRow.Length == 0)
                            {
                                strValue.Append(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_group_id", "") + ", ");

                                DataRow newRow = tempTable.NewRow();

                                newRow["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_group_id", "");

                                tempTable.Rows.Add(newRow);
                            }
                        }
                    }
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
        }//------------------------------

        //this function get the student system id list format
        private String GetStudentCourseGroupSystemIdFormat(Boolean isStudent, Boolean isEnrolmentLevel, DataTable studentTable)
        {
            StringBuilder strValue = new StringBuilder();

            DataTable tempTable = new DataTable("TemporaryTable");
            tempTable.Columns.Add("course_group_id", System.Type.GetType("System.String"));

            if (studentTable != null)
            {
                foreach (DataRow studRow in studentTable.Rows)
                {
                    if (isStudent && !isEnrolmentLevel)
                    {
                        if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "")))
                        {
                            strValue.Append(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "") + ", ");
                        }
                    }
                    else if (!isStudent && isEnrolmentLevel)
                    {
                        if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "")))
                        {
                            strValue.Append(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_enrolmentlevel", "") + ", ");
                        }
                    }
                    else
                    {
                        if (!String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_group_id", "")))
                        {
                            String strFilter = "course_group_id = '" + RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_group_id", "") + "'";
                            DataRow[] selectRow = tempTable.Select(strFilter);

                            if (selectRow.Length == 0)
                            {
                                strValue.Append(RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_group_id", "") + ", ");

                                DataRow newRow = tempTable.NewRow();

                                newRow["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_group_id", "");

                                tempTable.Rows.Add(newRow);
                            }
                        }
                    }
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
        }//------------------------------

        //this function determines if the student has current couse
        private Boolean HasCurrentCourse()
        {
            Boolean hasCurrentCourse = false;

            if (_studentCourseTable != null)
            {
                foreach (DataRow courseRow in _studentCourseTable.Rows)
                {
                    if (RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "is_current_course", true))
                    {
                        hasCurrentCourse = true;

                        break;
                    }
                }
            }

            return hasCurrentCourse;
        }//---------------------------

        //this function gets the units hours string
        private String GetSubjectUnitsHours(Int32 lectUnits, Int32 nonAcad, Int32 labUnits, String noHours)
        {
            return "Lec: " + lectUnits.ToString() + (nonAcad > 0 ? " (" + nonAcad + ")  " : String.Empty + "  ") + 
                ((lectUnits > 1) ? "units" : "unit") + "     " +
                "Lab / RLE: " + labUnits.ToString() + " " + ((labUnits > 1) ? "units" : "unit") + "     " +
                "No.Hours: " + noHours;
        }//-----------------------------------       

        //this fucntion will return String amount
        private String GetStringAmount(Decimal amount)
        {
            return amount > 0 ? amount.ToString("N") : "(" + amount.ToString("N").Remove(0,1) + ")";
        }//-----------------------------

        //this function will get course title
        public String GetCourseTitleCourseGroup(String sysIdEnrolmentCourse)
        {
            String value = String.Empty;

            String strFilter = "sysid_enrolmentcourse = '" + sysIdEnrolmentCourse + "'";
            DataRow[] selectRow = _studentCourseTable.Select(strFilter);

            foreach (DataRow courseRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_title", String.Empty);

                break;
            }

            return value;
        }//--------------------

        //this function will  year level description and course group
        private String GetYearLevelDescriptionCourseGroup(String sysiFeeLevel, Boolean isYearLevel)
        {
            String value = String.Empty;

            String strFilter = "sysid_feelevel = '" + sysiFeeLevel + "'";
            DataRow[] selectRow = _studentLevelTable.Select(strFilter);

            foreach (DataRow courseRow in selectRow)
            {
                if (isYearLevel)
                {
                    value = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "year_level_description", String.Empty);
                }
                else
                {
                    value = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_group_id", String.Empty);
                }

                break;
            }

            return value;
        }//-----------------------

        //private Boolean determine if the subject is already loaded
        private Boolean IsExistStudentLoadDeleted(String sysIdSchedule)
        {
            Boolean isExist = false;

            if (_studentLoadTable != null)
            {
                foreach (DataRow loadRow in _studentLoadTable.Rows)
                {
                    if (loadRow.RowState == DataRowState.Deleted &&
                        String.Equals(sysIdSchedule, loadRow["sysid_schedule", DataRowVersion.Original].ToString()))
                    {
                        loadRow.AcceptChanges();
                        isExist = true;

                        break;
                    }
                }
            }

            return isExist;
        }//-----------------------

        //this function will get amount to be added
        private Decimal GetToBeAddedAmount(Decimal amountBase, ref Decimal downpayment)
        {
            Decimal amountToBeAdded = 0;
        
            amountToBeAdded = amountBase - downpayment;
            downpayment = amountBase;

            return amountToBeAdded;
        }//-----------------------------

        //this function will get total payment between the date start and ende
        private Decimal GetTotalPaymentByDateStartEnd(DateTime dateStart, DateTime dateEnd, DataTable paymentReimbursemenTableTemp, Boolean isFirstEnter)
        {
            Decimal totalPayment = 0;

            foreach (DataRow payRow in paymentReimbursemenTableTemp.Rows)
            {
                DateTime paymentDate = DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(payRow, "reflected_date", String.Empty));

                if (RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_payment", false) ||
                    RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_discount", false) ||
                    RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_credit_memo", false))
                {
                    if (!isFirstEnter)
                    {
                        if (DateTime.Compare(paymentDate, dateStart) > 0 && DateTime.Compare(paymentDate, dateEnd) <= 0)
                        {
                            totalPayment += RemoteServerLib.ProcStatic.DataRowConvert(payRow, "amount", Decimal.Parse("0")) +
                                RemoteServerLib.ProcStatic.DataRowConvert(payRow, "discount_amount", Decimal.Parse("0"));
                        }
                    }
                    else
                    {
                        if (DateTime.Compare(paymentDate, dateStart) >= 0 && DateTime.Compare(paymentDate, dateEnd) <= 0)
                        {
                            totalPayment += RemoteServerLib.ProcStatic.DataRowConvert(payRow, "amount", Decimal.Parse("0")) +
                                RemoteServerLib.ProcStatic.DataRowConvert(payRow, "discount_amount", Decimal.Parse("0"));
                        }
                    }
                }
            }

            return totalPayment;
        }//----------------------

        //this function will get total payment between the date start and ende
        private Decimal GetTotalPaymentByDateStartEnd(DateTime dateStart, DateTime dateEnd, DataTable paymentReimbursemenTableTemp, 
            String sysIdStudent, Boolean isFirstEnter)
        {
            Decimal totalPayment = 0;

            String strFilter = "sysid_student = '" + sysIdStudent + "'";
            DataRow[] selectRow = paymentReimbursemenTableTemp.Select(strFilter);

            foreach (DataRow payRow in selectRow)
            {
                DateTime paymentDate = DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(payRow, "reflected_date", String.Empty));
                
                if (RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_payment", false) ||
                    RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_discount", false) ||
                    RemoteServerLib.ProcStatic.DataRowConvert(payRow, "is_credit_memo", false))
                {
                    if (!isFirstEnter)
                    {
                        if (DateTime.Compare(paymentDate, dateStart) > 0 && DateTime.Compare(paymentDate, dateEnd) <= 0)
                        {
                            totalPayment += RemoteServerLib.ProcStatic.DataRowConvert(payRow, "amount", Decimal.Parse("0")) +
                                RemoteServerLib.ProcStatic.DataRowConvert(payRow, "discount_amount", Decimal.Parse("0"));
                        }
                    }
                    else
                    {
                        if (DateTime.Compare(paymentDate, dateStart) >= 0 && DateTime.Compare(paymentDate, dateEnd) <= 0)
                        {
                            totalPayment += RemoteServerLib.ProcStatic.DataRowConvert(payRow, "amount", Decimal.Parse("0")) +
                                RemoteServerLib.ProcStatic.DataRowConvert(payRow, "discount_amount", Decimal.Parse("0"));
                        }
                    }
                }
            }

            return totalPayment;

        }//----------------------

        //this function will initialize the student filter printing for statement of account
        public DataTable InitializeFilterPrintStatementOfAccount()
        {
            DataTable newTable = this.StudentPrintingStatementOfAccountTable;

            if (_studentTable != null)
            {
                foreach (DataRow studentRow in _studentTable.Rows)
                {
                    DataRow newRow = newTable.NewRow();

                    newRow["checkbox_column"] = true;
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
                    newRow["emer_relationship_description"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "emer_relationship_description", String.Empty);
                    newRow["emer_present_address"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "emer_present_address", String.Empty);
                    newRow["emer_present_phone_nos"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "emer_present_phone_nos", String.Empty);
                    newRow["emer_home_address"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "emer_home_address", String.Empty);
                    newRow["emer_home_phone_nos"] = RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "emer_home_phone_nos", String.Empty);

                    newTable.Rows.Add(newRow);
                }
            }
            return newTable;
        }//-----------------------

        //this function will get the filtered student for student statement of account printing
        public DataTable GetFilteredStudentStatementOfAccount(DataTable sourceTable)
        {
            DataTable newTable = null;

            if (sourceTable != null && _studentTable != null)
            {
                newTable = (DataTable)_studentTable.Clone();

                newTable.Rows.Clear();

                foreach (DataRow sourceRow in sourceTable.Rows)
                {
                    if (RemoteServerLib.ProcStatic.DataRowConvert(sourceRow, "checkbox_column", false))
                    {
                        String strFilter = "student_id = '" + RemoteServerLib.ProcStatic.DataRowConvert(sourceRow, "student_id", "") + "'";
                        DataRow[] selectRow = _studentTable.Select(strFilter);

                        foreach (DataRow studRow in selectRow)
                        {
                            DataRow newRow = newTable.NewRow();

                            newRow["sysid_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_student", "");
                            newRow["student_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "student_id", "");
                            newRow["last_name"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "last_name", "");
                            newRow["first_name"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "first_name", "");
                            newRow["middle_name"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "middle_name", "");
                            newRow["card_number"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "card_number", "");
                            newRow["course_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_id", "");
                            newRow["sysid_enrolmentlevel"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_enrolmentlevel", "");
                            newRow["sysid_feelevel"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_feelevel", "");
                            newRow["sysid_semester"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "sysid_semester", "");
                            newRow["course_group_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_group_id", "");
                            newRow["year_description"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_description", "");
                            newRow["year_level_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_level_id", "");
                            newRow["level_section"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "level_section", "");
                            newRow["is_graduate_student"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "is_graduate_student", false);
                            newRow["year_level_description"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_level_description", "");
                            newRow["year_level_acronym"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "year_level_acronym", "");
                            newRow["department_id"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "department_id", "");
                            newRow["course_title"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_title", "");
                            newRow["course_acronym"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "course_acronym", "");
                            newRow["department_name"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "department_name", "");
                            newRow["department_acronym"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "department_acronym", "");
                            newRow["group_description"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "group_description", "");
                            newRow["semester_description"] = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "semester_description", "");

                            newTable.Rows.Add(newRow);
                        }
                    }
                }
            }

            return newTable;
        }//--------------------------
        #endregion
    }
}
