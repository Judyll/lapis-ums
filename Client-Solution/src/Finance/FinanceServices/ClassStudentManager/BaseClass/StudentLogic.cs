using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Collections;

namespace FinanceServices
{
    internal class StudentLogic : BaseServices.BaseServicesLogic
    {
        #region Class Nested Classes
        internal class StudentEnrolmentList
        {
            public StudentEnrolmentList()
            {
                _enrolmentCourseInfo = new CommonExchange.StudentEnrolmentCourse();
                _enrolmentLevelInfo = new CommonExchange.StudentEnrolmentLevel();
            }

            private Boolean _isCourse = false;
            public Boolean IsCourse
            {
                get { return _isCourse; }
                set { _isCourse = value; }
            }

            private DataRowState _rowState;
            public DataRowState RowState
            {
                get { return _rowState; }
                set { _rowState = value; }
            }

            private CommonExchange.StudentEnrolmentCourse _enrolmentCourseInfo;
            public CommonExchange.StudentEnrolmentCourse EnrolmentCourseInfo
            {
                get { return _enrolmentCourseInfo; }
                set { _enrolmentCourseInfo = value; }
            }

            private CommonExchange.StudentEnrolmentLevel _enrolmentLevelInfo;
            public CommonExchange.StudentEnrolmentLevel EnrolmentLevelInfo
            {
                get { return _enrolmentLevelInfo; }
                set { _enrolmentLevelInfo = value; }
            }

            private String _enrolmentCourseSysIdTemp;
            public String EnrolmentCourseSysIdTemp
            {
                get { return _enrolmentCourseSysIdTemp; }
                set { _enrolmentCourseSysIdTemp = value; }
            }
        }
        #endregion

        #region Class General Variable Declarations
        private DataSet _classDataSet;
        private DataTable _studentTable;
        private DataTable _studentCourseTable;
        private DataTable _studentLevelTable;
        private DataTable _schoolFeeLevelTable;
        private DataTable _studentLevelHistroyTable;
        private DataTable _studentCourseHistoryTable;
        private DataTable _schoolYearSemesterForIdTable;
        private DataTable _specialClassTable;

        private Int32 _courseCounter = 0;
        private Int32 _levelCounter = 0;
        private Int32 _enrolmentLevelNo = 0;

        private String _imagePath;

        private List<StudentEnrolmentList> _studentEnrolmentCourseLevelList = new List<StudentEnrolmentList>();
        #endregion

        #region Class Constructor
        public StudentLogic(CommonExchange.SysAccess userInfo)
        {
            
            this.InitializeClass(userInfo);

            _imagePath = "\\StudentImages";
        }
        #endregion

        #region Programmer-Defined Void Procedures
        //this procedure inserts a new student information
        public void InsertStudentInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.Student studentInfo)
        {
            using (RemoteClient.RemCntStudentManager remClient = new RemoteClient.RemCntStudentManager())
            {
                remClient.InsertStudentInformation(userInfo, ref studentInfo);
            }

            if (_studentTable != null)
            {
                DataRow newRow = _studentTable.NewRow();

                newRow["sysid_student"] = studentInfo.StudentSysId;
                newRow["student_id"] = studentInfo.StudentId;
                newRow["card_number"] = studentInfo.CardNumber;
                newRow["last_name"] = studentInfo.PersonInfo.LastName;
                newRow["first_name"] = studentInfo.PersonInfo.FirstName;
                newRow["middle_name"] = studentInfo.PersonInfo.MiddleName;
                                
                _studentTable.Rows.Add(newRow);
                _studentTable.AcceptChanges();

                if (_studentEnrolmentCourseLevelList != null && _studentEnrolmentCourseLevelList != null)
                {
                    using (RemoteClient.RemCntStudentEnrolmentManager remClient = new RemoteClient.RemCntStudentEnrolmentManager())
                    {
                        foreach (DataRow groupRow in _classDataSet.Tables["CourseGroupTable"].Rows)
                        {
                            String enrolmentCourseSysIdTemp = "";

                            foreach (StudentEnrolmentList list in _studentEnrolmentCourseLevelList)
                            {
                                if (list.IsCourse && list.RowState == DataRowState.Added &&
                                    String.Equals(RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", ""),
                                    this.GetCourseGroupIdByCourse(list.EnrolmentCourseInfo.CourseInfo.CourseId)))
                                {
                                    CommonExchange.StudentEnrolmentCourse enrolmentCourseInfo = list.EnrolmentCourseInfo;

                                    enrolmentCourseInfo.StudentInfo.StudentSysId = studentInfo.StudentSysId;

                                    remClient.InsertStudentEnrolmentCourse(userInfo, ref enrolmentCourseInfo);

                                    enrolmentCourseSysIdTemp = enrolmentCourseInfo.EnrolmentCourseSysId;                    
                                }
                            }

                            foreach (StudentEnrolmentList levelList in _studentEnrolmentCourseLevelList)
                            {
                                if ((!levelList.IsCourse && !levelList.EnrolmentLevelInfo.IsMarkedDeleted) && (levelList.RowState == DataRowState.Added &&
                                    String.Equals(RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", ""),
                                    this.GetCourseGroupIdByLevel(levelList.EnrolmentLevelInfo.SchoolFeeLevelInfo.FeeLevelSysId))))
                                {
                                    CommonExchange.StudentEnrolmentLevel enrolmentLevelInfo = levelList.EnrolmentLevelInfo;

                                    enrolmentLevelInfo.StudentEnrolmentCourseInfo.EnrolmentCourseSysId = enrolmentCourseSysIdTemp;

                                    remClient.InsertStudentEnrolmentLevel(userInfo, ref enrolmentLevelInfo);
                                }
                            }
                        }
                    }
                }
            }
        }//--------------------------

        //this procedure will insert new student enrolment level
        public void InsertStudentEnrolmentLevel(CommonExchange.StudentEnrolmentLevel enrolmentLevelInfo)
        {
            if (_studentEnrolmentCourseLevelList != null)
            {
                enrolmentLevelInfo.EnrolmentLevelSysId = "SYSTMP" + RemoteServerLib.ProcStatic.NineDigitZero(++_levelCounter);

                StudentEnrolmentList list = new StudentEnrolmentList();
                
                list.IsCourse = false;
                list.RowState = DataRowState.Added;
                list.EnrolmentLevelInfo = enrolmentLevelInfo;
                list.EnrolmentCourseSysIdTemp = enrolmentLevelInfo.StudentEnrolmentCourseInfo.EnrolmentCourseSysId;
                
                _studentEnrolmentCourseLevelList.Add(list);

                if (_studentLevelTable != null)
                {                   
                    DataRow newRow = _studentLevelTable.NewRow();
                   
                    newRow["sysid_enrolmentlevel"] = enrolmentLevelInfo.EnrolmentLevelSysId;
                    newRow["sysid_enrolmentcourse"] = enrolmentLevelInfo.StudentEnrolmentCourseInfo.EnrolmentCourseSysId;
                    newRow["sysid_feelevel"] = enrolmentLevelInfo.SchoolFeeLevelInfo.FeeLevelSysId;
                    newRow["sysid_semester"] = enrolmentLevelInfo.SemesterInfo.SemesterSysId;
                    newRow["semester_description"] = this.GetSemesterDescription(enrolmentLevelInfo.SemesterInfo.SemesterSysId);
                    newRow["is_entry_level"] = enrolmentLevelInfo.IsEntryLevel;
                    newRow["year_description"] = this.GetYearDescriptionByFeeLevelSystemId(enrolmentLevelInfo.SchoolFeeLevelInfo.FeeLevelSysId);
                    newRow["year_id"] = this.GetYearId(enrolmentLevelInfo.SchoolFeeLevelInfo.FeeLevelSysId);
                    newRow["year_level_description"] = this.GetYearLevelDescription(enrolmentLevelInfo.SchoolFeeLevelInfo.FeeLevelSysId);
                    newRow["course_group_id"] = this.GetCourseGroupIdByLevel(enrolmentLevelInfo.SchoolFeeLevelInfo.FeeLevelSysId);
                    newRow["group_description"] = this.GetGroupDescription(enrolmentLevelInfo.SchoolFeeLevelInfo.FeeLevelSysId);
                    newRow["enrolment_level_no"] = ++_enrolmentLevelNo;
                    
                    _studentLevelTable.Rows.Add(newRow);
                    _studentLevelTable.AcceptChanges();
                }
            }
        }//---------------------------

        //this procedure will insert new student enrolment course
        public void InsertStudentEnrolmentCourse(ref CommonExchange.StudentEnrolmentCourse enrolmentCourseInfo)
        {
            if (_studentEnrolmentCourseLevelList != null)
            {
                enrolmentCourseInfo.EnrolmentCourseSysId = "SYSTMP" + RemoteServerLib.ProcStatic.NineDigitZero(++_courseCounter);                

                StudentEnrolmentList list = new StudentEnrolmentList();

                list.IsCourse = true;
                list.RowState = DataRowState.Added;
                list.EnrolmentCourseInfo = enrolmentCourseInfo;
               
                _studentEnrolmentCourseLevelList.Add(list);

                if (_studentCourseTable != null)
                {
                    if (list.EnrolmentCourseInfo.IsCurrentCourse)
                    {
                        Int32 index = 0;

                        foreach (DataRow courseRow in _studentCourseTable.Rows)
                        {
                            if (courseRow.RowState != DataRowState.Deleted)
                            {
                                DataRow editRow = _studentCourseTable.Rows[index];

                                editRow.BeginEdit();

                                editRow["is_current_course"] = false;

                                editRow.EndEdit();

                                index++;
                            }
                        }
                    }

                    _studentCourseTable.AcceptChanges();

                    DataRow newRow = _studentCourseTable.NewRow();

                    newRow["sysid_enrolmentcourse"] = list.EnrolmentCourseInfo.EnrolmentCourseSysId;
                    newRow["sysid_student"] = list.EnrolmentCourseInfo.StudentInfo.StudentSysId;
                    newRow["course_id"] = list.EnrolmentCourseInfo.CourseInfo.CourseId;
                    newRow["sysid_schoolfee"] = list.EnrolmentCourseInfo.SchoolFeeInfo.FeeInformationSysId;
                    newRow["sysid_semester"] = list.EnrolmentCourseInfo.SemesterInfo.SemesterSysId;
                    newRow["course_title"] = this.GetCourseTitle(list.EnrolmentCourseInfo.CourseInfo.CourseId);
                    newRow["course_group_id"] = this.GetCourseGroupIdByCourse(list.EnrolmentCourseInfo.CourseInfo.CourseId);
                    newRow["year_description"] = this.GetYearDescriptionByFeeInformationSystemId(list.EnrolmentCourseInfo.SchoolFeeInfo.FeeInformationSysId);
                    newRow["semester_description"] = this.GetSemesterDescription(list.EnrolmentCourseInfo.SemesterInfo.SemesterSysId);
                    newRow["is_current_course"] = list.EnrolmentCourseInfo.IsCurrentCourse;
                    
                    _studentCourseTable.Rows.Add(newRow);
                    _studentCourseTable.AcceptChanges();
                }    
            }
        }//-----------------------------
       
        //this procedure updates a student information
        public void UpdateStudentInformation(CommonExchange.SysAccess userInfo, CommonExchange.Student studentInfo, Boolean fromCashiering, ref DataTable studentTable)
        {
            using (RemoteClient.RemCntStudentManager remClient = new RemoteClient.RemCntStudentManager())
            {
                remClient.UpdateStudentInformation(userInfo, studentInfo);
            }

            if (fromCashiering)
                _studentTable = studentTable;

            if (_studentTable != null)
            {
                Int32 index = 0;

                foreach (DataRow studentRow in _studentTable.Rows)
                {
                    if (String.Equals(studentInfo.StudentSysId, studentRow["sysid_student"].ToString()))
                    {
                        DataRow editRow = _studentTable.Rows[index];
                        
                        editRow.BeginEdit();

                        editRow["sysid_student"] = studentInfo.StudentSysId;
                        editRow["student_id"] = studentInfo.StudentId;
                        editRow["card_number"] = studentInfo.CardNumber;
                        editRow["last_name"] = studentInfo.PersonInfo.LastName;
                        editRow["first_name"] = studentInfo.PersonInfo.FirstName;
                        editRow["middle_name"] = studentInfo.PersonInfo.MiddleName;
                                               
                        editRow.EndEdit();

                        break;
                    }

                    index++;
                }

                _studentTable.AcceptChanges();

                if (fromCashiering)
                    studentTable = _studentTable;

                if (_studentEnrolmentCourseLevelList != null)
                {
                    using (RemoteClient.RemCntStudentEnrolmentManager remClient = new RemoteClient.RemCntStudentEnrolmentManager())
                    {
                        foreach (StudentEnrolmentList list in _studentEnrolmentCourseLevelList)
                        {
                            if (!list.IsCourse && list.RowState == DataRowState.Deleted)
                            {
                                CommonExchange.StudentEnrolmentLevel enrolmentLevelInfo = list.EnrolmentLevelInfo;
                                
                                remClient.DeleteStudentEnrolmentLevel(userInfo, enrolmentLevelInfo);
                            }
                        }
                         
                        foreach (StudentEnrolmentList list in _studentEnrolmentCourseLevelList)
                        {
                            if (list.IsCourse && list.RowState == DataRowState.Modified)
                            {
                                CommonExchange.StudentEnrolmentCourse enrolmentCourseInfo = list.EnrolmentCourseInfo;

                                enrolmentCourseInfo.StudentInfo.StudentSysId = studentInfo.StudentSysId;

                                remClient.UpdateStudentEnrolmentCourse(userInfo, enrolmentCourseInfo);
                            }
                            else if (list.IsCourse && list.RowState == DataRowState.Added)
                            {
                                CommonExchange.StudentEnrolmentCourse enrolmentCourseInfo = list.EnrolmentCourseInfo;

                                enrolmentCourseInfo.StudentInfo.StudentSysId = studentInfo.StudentSysId;

                                String enrolmentCourseSysIdTemp = enrolmentCourseInfo.EnrolmentCourseSysId;

                                remClient.InsertStudentEnrolmentCourse(userInfo, ref enrolmentCourseInfo);

                                foreach (StudentEnrolmentList levelList in _studentEnrolmentCourseLevelList)
                                {
                                    if (String.Equals(enrolmentCourseSysIdTemp, levelList.EnrolmentLevelInfo.StudentEnrolmentCourseInfo.EnrolmentCourseSysId) &&
                                        !levelList.IsCourse && !levelList.EnrolmentLevelInfo.IsMarkedDeleted && list.RowState == DataRowState.Added)
                                    {
                                        CommonExchange.StudentEnrolmentLevel enrolmentLevelInfo = levelList.EnrolmentLevelInfo;

                                        enrolmentLevelInfo.StudentEnrolmentCourseInfo.EnrolmentCourseSysId = enrolmentCourseInfo.EnrolmentCourseSysId;

                                        remClient.InsertStudentEnrolmentLevel(userInfo, ref enrolmentLevelInfo);

                                        break;
                                    }
                                }
                            }                                            
                        }

                        foreach (StudentEnrolmentList list in _studentEnrolmentCourseLevelList)
                        {
                            if (!list.IsCourse && list.RowState == DataRowState.Added)
                            {
                                CommonExchange.StudentEnrolmentLevel enrolmentLevelInfo = list.EnrolmentLevelInfo;

                                remClient.InsertStudentEnrolmentLevel(userInfo, ref enrolmentLevelInfo);
                            }
                        }
                    }
                }
            }
        }//---------------------------------

        //this procedure will update student enrolment course
        public void UpdateStudentEnrolmentCourse(CommonExchange.StudentEnrolmentCourse enrolmentCourseInfo)
        {
            if (_studentEnrolmentCourseLevelList != null)
            {
                Int32 index = 0;

                foreach (StudentEnrolmentList studentList in _studentEnrolmentCourseLevelList)
                {
                    if (String.Equals(studentList.EnrolmentCourseInfo.EnrolmentCourseSysId, enrolmentCourseInfo.EnrolmentCourseSysId))
                    {
                        _studentEnrolmentCourseLevelList.RemoveAt(index);
                        
                        break;
                    }

                    index++;
                }

                StudentEnrolmentList list = new StudentEnrolmentList();

                list.IsCourse = true;

                if (String.Equals(enrolmentCourseInfo.EnrolmentCourseSysId.Substring(0, 6), "SYSTMP"))
                {
                    list.RowState = DataRowState.Added;
                }
                else
                {
                    list.RowState = DataRowState.Modified;
                }

                list.EnrolmentCourseInfo = enrolmentCourseInfo;
                
                _studentEnrolmentCourseLevelList.Add(list);

                if (_studentCourseTable != null)
                {
                    Int32 editIndex = 0;

                    foreach (DataRow courseRow in _studentCourseTable.Rows)
                    {
                        DataRow editRow = _studentCourseTable.Rows[editIndex];

                        editRow.BeginEdit();

                        editRow["sysid_schoolfee"] = enrolmentCourseInfo.SchoolFeeInfo.FeeInformationSysId;
                        editRow["sysid_semester"] = enrolmentCourseInfo.SemesterInfo.SemesterSysId;
                        editRow["year_description"] = this.GetYearDescription(enrolmentCourseInfo.SchoolFeeInfo.FeeInformationSysId);
                        editRow["semester_description"] = this.GetSemesterDescription(enrolmentCourseInfo.SemesterInfo.SemesterSysId);

                        if (list.EnrolmentCourseInfo.IsCurrentCourse &&
                                String.Equals(list.EnrolmentCourseInfo.CourseInfo.CourseId, RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_id", "")))
                        {                            
                            editRow["is_current_course"] = true;                            
                        }
                        else
                        {                           
                            editRow["is_current_course"] = false;                            
                        }

                        editRow.EndEdit();

                        editIndex++;
                    }

                    _studentCourseTable.AcceptChanges();
                }
            }
        }//---------------------------     
   
        //this procedure will delete student enrolment level
        public void DeleteStudentEnrolmentLevel(CommonExchange.SysAccess userInfo, CommonExchange.StudentEnrolmentLevel enrolmentLevelInfo)
        {
            if (_studentEnrolmentCourseLevelList != null)
            {
                //AC
                using (RemoteClient.RemCntStudentEnrolmentManager remClient = new RemoteClient.RemCntStudentEnrolmentManager())
                {                   
                    remClient.DeleteStudentEnrolmentLevel(userInfo, enrolmentLevelInfo);
                }

                //DC------------
                //Int32 index = 0;

                //foreach (StudentEnrolmentList studentList in _studentEnrolmentCourseLevelList)
                //{    
                //    if (studentList.RowState != DataRowState.Deleted &&
                //        String.Equals(studentList.EnrolmentLevelInfo.EnrolmentLevelSysId, enrolmentLevelInfo.EnrolmentLevelSysId))
                //    {
                //        _studentEnrolmentCourseLevelList.RemoveAt(index);

                //        break;
                //    }

                //    index++;
                //}


                if (_studentLevelTable != null)
                {
                    Int32 indexLevel = 0;

                    foreach (DataRow levelRow in _studentLevelTable.Rows)
                    {  
                        if (levelRow.RowState != DataRowState.Deleted &&
                            String.Equals(enrolmentLevelInfo.EnrolmentLevelSysId, RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "sysid_enrolmentlevel", "")))
                        {
                            DataRow delRow = _studentLevelTable.Rows[indexLevel];

                            delRow.Delete();

                            break;
                        }

                        indexLevel++;
                    }
                }

                _studentLevelTable.AcceptChanges();

                //DC
                //StudentEnrolmentList list = new StudentEnrolmentList();

                //list.IsCourse = false;
                //list.RowState = DataRowState.Deleted;
                //list.EnrolmentLevelInfo = enrolmentLevelInfo;

                //_studentEnrolmentCourseLevelList.Add(list);                
            }
        }//--------------------------
    
        //this procedure initialized the treeview control
        public void InitializeTreeViewControl(TreeView trvBase, ContextMenuStrip mnuCreateCourse, 
            ContextMenuStrip mnuUpdateCourse, ContextMenuStrip mnuDeleteLevel, ContextMenuStrip mnuCreateEntryLevel, Boolean hasGeneratedStudentId, String courseGroupId)
        {
            trvBase.Nodes.Clear();

            TreeNode courseGroupNode;
            TreeNode courseTakenNode;
            TreeNode createdCourses;
            TreeNode entryLevel;
            TreeNode createdEntryLevel;

            Int32 x = 0;
            Int32 y = 0;

            Boolean hasCurrentCourse = false;

            foreach (DataRow groupRow in _classDataSet.Tables["CourseGroupTable"].Rows)
            {
                entryLevel = new TreeNode("Student Entry Levels [" + RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "") + "]");
                                                
                courseTakenNode = new TreeNode("Courses Taken [" + RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "") + "]");

                if (!hasGeneratedStudentId)
                {
                    courseTakenNode.ContextMenuStrip = mnuCreateCourse;
                }
                else if (hasGeneratedStudentId && (String.Equals(RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", ""), courseGroupId)))
                {
                    courseTakenNode.ContextMenuStrip = mnuCreateCourse;
                }

                courseGroupNode = new TreeNode(RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "group_description", ""));                
                                        
                String strFilterCourse = "course_group_id = '" + RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "") + "'";
                DataRow[] selectCourse = _studentCourseTable.Select(strFilterCourse);
                                        
                foreach (DataRow courseRow in selectCourse)
                {           
                    createdCourses = new TreeNode(RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_title", "") + " {" +
                        RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "semester_description", "") + "  " +
                        RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "year_description", "") + "} - [" + 
                        RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_id", "") + "]");
                    createdCourses.ContextMenuStrip = mnuUpdateCourse;

                    if (RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "is_current_course", false))
                    {
                        createdCourses.ForeColor = courseGroupNode.ForeColor = Color.Red;
                                                                            
                        entryLevel.ContextMenuStrip = mnuCreateEntryLevel;
                                            
                        y = x;
            
                        hasCurrentCourse = true;
                    }          

                    courseTakenNode.Nodes.Add(createdCourses);
                }               

                String strFilterLevel = "course_group_id = '" + RemoteServerLib.ProcStatic.DataRowConvert(groupRow, "course_group_id", "") + "'";
                DataRow[] selectLevel = _studentLevelTable.Select(strFilterLevel);

                String enrolmentLevelSysId = this.GetMaxEnrolmentLevelNoBySysId(selectLevel);

                foreach (DataRow levelRow in selectLevel)
                {
                    if (levelRow.RowState != DataRowState.Deleted)
                    {
                        String levelInfo = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "semester_description", "") + " " +
                                RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_description", "") + "   " +                                
                                RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "group_description", "") + " - " +
                                RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_description", "") + " [" +
                                RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "sysid_enrolmentlevel", "") + "]";

                        if (!String.IsNullOrEmpty(levelInfo))
                        {
                            createdEntryLevel = new TreeNode(levelInfo);
                            createdEntryLevel.ContextMenuStrip = mnuDeleteLevel;

                            if (String.Equals(RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "sysid_enrolmentlevel", ""), enrolmentLevelSysId))
                            {
                                createdEntryLevel.ForeColor = Color.Magenta;
                            }

                            entryLevel.Nodes.Add(createdEntryLevel);                           
                        }
                    }
                }               
              
                if (courseGroupNode.ForeColor != Color.Red && courseTakenNode.Nodes.Count >= 1)
                {
                    courseGroupNode.ForeColor = Color.Orange;
                }
               
                courseGroupNode.Nodes.Add(courseTakenNode);
                courseGroupNode.Nodes.Add(entryLevel);
                courseGroupNode.Nodes[0].Expand();
                courseGroupNode.Nodes[1].Expand();

                trvBase.Nodes.Add(courseGroupNode);

                x++;
            }

            if (hasCurrentCourse)
            {
                trvBase.Nodes[y].Expand();
            } 
        }//---------------------------

        //this procedure initialized the treeview control
        public void InitializeTreeViewControl(CommonExchange.SysAccess userInfo, TreeView trvBase)
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
                        this.GetYearDescription(RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "sysid_schoolfee", "")) + " ]");

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
                                this.GetYearDescription(RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "sysid_schoolfee", "")) + "   " +
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

                    //if ((DateTime.Compare(serverDateTime, dateStart) >= 0 && DateTime.Compare(serverDateTime, dateEnd) <= 0))
                    //{
                    //    cboBase.SelectedIndex = index;
                    //    isIndexed = true;

                    //    break;
                    //}

                    index++;
                }
            }
        } //---------------------------   

        //this procedure initializes the school year combo box
        public void InitializeSchoolYearForIdCombo(ComboBox cboBase)
        {
            cboBase.Items.Clear();

            foreach (DataRow yearRow in _schoolYearSemesterForIdTable.Rows)
            {
                cboBase.Items.Add(yearRow["year_description"].ToString());

                //if (!isIndexed)
                //{
                //    DateTime serverDateTime = DateTime.Parse(_serverDateTime);
                //    DateTime dateStart = serverDateTime;
                //    DateTime dateEnd = serverDateTime;

                //    DateTime.TryParse(yearRow["date_start"].ToString(), out dateStart);
                //    DateTime.TryParse(yearRow["date_end"].ToString(), out dateEnd);

                //    if ((DateTime.Compare(serverDateTime, dateStart) <= 0 && DateTime.Compare(serverDateTime, dateEnd) >= 0))// ||
                //        //(DateTime.Compare(serverDateTime.AddMonths((Int32)CommonExchange.SystemRange.MonthAllowance), dateStart) >= 0 &&
                //         //DateTime.Compare(serverDateTime.AddMonths((Int32)CommonExchange.SystemRange.MonthAllowance), dateEnd) <= 0))
                //    {
                //        cboBase.SelectedIndex = index;
                //        isIndexed = true;
                //    }

                //    index++;
                //}
            }

            cboBase.SelectedIndex = -1;
        }//--------------------------- 

        //this procedure initializes the school year combo box
        public void InitializeSchoolYearComboLevelCreate(ComboBox cboBase, DateTime dateStart)
        {
            cboBase.Items.Clear();

            DataTable newTable = new DataTable("SchoolFeeTempTable");
            newTable.Columns.Add("sysid_schoolfee", System.Type.GetType("System.String"));
            newTable.Columns.Add("year_id", System.Type.GetType("System.String"));
            newTable.Columns.Add("year_description", System.Type.GetType("System.String"));
            newTable.Columns.Add("date_start", System.Type.GetType("System.DateTime"));
            newTable.Columns.Add("date_end", System.Type.GetType("System.DateTime"));
            newTable.Columns.Add("is_summer", System.Type.GetType("System.Boolean"));

            foreach (DataRow feeRow in _classDataSet.Tables["SchoolFeeInformationTable"].Rows)
            {
                DataRow newRow = newTable.NewRow();

                newRow["sysid_schoolfee"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "sysid_schoolfee", String.Empty);
                newRow["year_id"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "year_id", String.Empty);
                newRow["year_description"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "year_description", String.Empty);
                newRow["date_start"] = DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "date_start", String.Empty));
                newRow["date_end"] = DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "date_end", String.Empty));
                newRow["is_summer"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_summer", false);

                newTable.Rows.Add(newRow);
            }

            String strFilter = "date_start >= '" + dateStart + "'";
            DataRow[] selectRow = newTable.Select(strFilter, "date_start DESC");

            foreach (DataRow yearRow in selectRow)
            {
                cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "year_description", String.Empty));               
            }

            cboBase.SelectedIndex = selectRow.Length - 1;
        } //---------------------------   

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

        //this procedure initialized the school year combo course
        public void InitializeSchoolYearComboCourse(ComboBox cboBase, String sysIdFeeInformation)
        {
            cboBase.Items.Clear();

            Int32 index = 0;

            Boolean hasEnter = false;

            foreach (DataRow feeRow in _classDataSet.Tables["SchoolFeeInformationTable"].Rows)
            {
                cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "year_description", ""));

                if (!hasEnter)
                {
                    if (String.Equals(sysIdFeeInformation, RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "sysid_schoolfee", String.Empty)))
                    {
                        cboBase.SelectedIndex = index;
                        hasEnter = true;
                    }

                    index++;
                }
            }
        }//-----------------------  

        //this procedure initialized the school year combo level
        public void InitializeSchoolYearComboLevelUpdate(ComboBox cboBase, String yearId)
        {
            cboBase.Items.Clear();

            String strFilter = "year_id = '" + yearId + "'";
            DataRow[] selectRow = _classDataSet.Tables["SchoolFeeInformationTable"].Select(strFilter);

            foreach (DataRow feeRow in selectRow)
            {
                cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "year_description", ""));

                break;
            }

            cboBase.SelectedIndex = 0;
        }//----------------------- 

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

        //this procedure initializes the semester combo box
        public void InitializeSemesterComboLevelCreate(ComboBox cboBase, Int32 yearIndex, DateTime dateStart)
        {
            cboBase.Items.Clear();

            //transfer year table
            DataTable newTableYear = new DataTable("SchoolFeeTempTable");
            newTableYear.Columns.Add("sysid_schoolfee", System.Type.GetType("System.String"));
            newTableYear.Columns.Add("year_id", System.Type.GetType("System.String"));
            newTableYear.Columns.Add("year_description", System.Type.GetType("System.String"));
            newTableYear.Columns.Add("date_start", System.Type.GetType("System.DateTime"));
            newTableYear.Columns.Add("date_end", System.Type.GetType("System.DateTime"));
            newTableYear.Columns.Add("is_summer", System.Type.GetType("System.Boolean"));

            foreach (DataRow feeRow in _classDataSet.Tables["SchoolFeeInformationTable"].Rows)
            {
                DataRow newRow = newTableYear.NewRow();

                newRow["sysid_schoolfee"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "sysid_schoolfee", String.Empty);
                newRow["year_id"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "year_id", String.Empty);
                newRow["year_description"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "year_description", String.Empty);
                newRow["date_start"] = DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "date_start", String.Empty));
                newRow["date_end"] = DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "date_end", String.Empty));
                newRow["is_summer"] = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "is_summer", false);

                newTableYear.Rows.Add(newRow);
            }
            //-----------------------

            //transfer semster table
            DataTable newTableSemester = new DataTable("SemesterTempTable");
            newTableSemester.Columns.Add("sysid_semester", System.Type.GetType("System.String"));
            newTableSemester.Columns.Add("year_id", System.Type.GetType("System.String"));
            newTableSemester.Columns.Add("semester_id", System.Type.GetType("System.String"));
            newTableSemester.Columns.Add("year_description", System.Type.GetType("System.String"));
            newTableSemester.Columns.Add("semester_description", System.Type.GetType("System.String"));
            newTableSemester.Columns.Add("date_start", System.Type.GetType("System.DateTime"));
            newTableSemester.Columns.Add("date_end", System.Type.GetType("System.DateTime"));
            newTableSemester.Columns.Add("is_summer", System.Type.GetType("System.Boolean"));

            foreach (DataRow semRow in _classDataSet.Tables["SemesterInformationTable"].Rows)
            {
                DataRow newRow = newTableSemester.NewRow();

                newRow["sysid_semester"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "sysid_semester", String.Empty);
                newRow["year_id"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "year_id", String.Empty);
                newRow["semester_id"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "semester_id", String.Empty);
                newRow["year_description"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "year_description", String.Empty);
                newRow["semester_description"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "semester_description", String.Empty);
                newRow["date_start"] = DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(semRow, "date_start", String.Empty));
                newRow["date_end"] = DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(semRow, "date_end", String.Empty));
                newRow["is_summer"] = RemoteServerLib.ProcStatic.DataRowConvert(semRow, "is_summer", false);

                newTableSemester.Rows.Add(newRow);
            }
            //--------------------

            DataRow yearRow = newTableYear.Rows[yearIndex];

            String strFilter = "date_start >= '" + dateStart + "' AND year_id = '" + yearRow["year_id"].ToString() + "'";
            DataRow[] selectRow = newTableSemester.Select(strFilter, "date_start DESC");

            foreach (DataRow sRow in selectRow)
            {
                cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(sRow, "semester_description", String.Empty));
            }

            cboBase.SelectedIndex = selectRow.Length - 1;
        }//-----------------------------   

        //this procedure initializes the semester combo update
        public void InitializeSemesterComboUpdateCourse(ComboBox cboBase, Int32 yearIndex, String sysIdSemester)
        {
            cboBase.Items.Clear();

            DataRow yearRow = _classDataSet.Tables["SchoolFeeInformationTable"].Rows[yearIndex];

            String strFilter = "year_id = '" + yearRow["year_id"].ToString() + "'";
            DataRow[] selectRow = _classDataSet.Tables["SemesterInformationTable"].Select(strFilter);

            Int32 index = 0;

            Boolean hasEnter = false;

            foreach (DataRow semRow in selectRow)
            {
                cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(semRow, "semester_description", ""));

                if (!hasEnter)
                {
                    if (String.Equals(sysIdSemester, RemoteServerLib.ProcStatic.DataRowConvert(semRow, "sysid_semester", String.Empty)))
                    {
                        cboBase.SelectedIndex = index;
                        hasEnter = true;
                    }

                    index++;
                }
            }
        }//-----------------------

        //this procedure initializes the semester combo update
        public void InitializeSemesterComboUpdateLevel(ComboBox cboBase, String sysIdSemester)
        {
            cboBase.Items.Clear();

            String strFilter = "sysid_semester = '" + sysIdSemester + "'";
            DataRow[] selectRow = _classDataSet.Tables["SemesterInformationTable"].Select(strFilter);

            foreach (DataRow semRow in selectRow)
            {
                cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(semRow, "semester_description", ""));

                break;
            }

            cboBase.SelectedIndex = 0;
        }//-----------------------

        //this procedure initialized the year level combo
        public void InitializeYearLevelCombo(ComboBox cboBase)
        {
            cboBase.Items.Clear();

            if (_schoolFeeLevelTable != null)
            {
                foreach (DataRow levelRow in _schoolFeeLevelTable.Rows)
                {
                    cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "group_description", "") + " - " +
                        RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_description", ""));
                }
            }

            cboBase.SelectedIndex = -1;
        }//------------------------------

        //this procedure initialized the year level combo
        public void InitializeYearLevelCombo(ComboBox cboBase, String courseId, String yearLevelId)
        {
            cboBase.Items.Clear();

            String strFilter = "course_id = '" + courseId + "'";
            DataRow[] selectRow = _classDataSet.Tables["CourseYearLevelTable"].Select(strFilter);

            Int32 index = 0;

            foreach (DataRow courseRow in selectRow)
            {
                cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "group_description", "") + " - " +
                       RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "year_level_description", ""));

                if (String.Equals(yearLevelId, RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "year_level_id", "")))
                {
                    cboBase.SelectedIndex = index;
                }

                index++;
            }           
        }//----------------------------------

        //this procedure initialized the year level combo update
        public void InitializeYearLevelComboUpdate(ComboBox cboBase, String sysIdEnrolmentLevel)
        {
            cboBase.Items.Clear();

            String strFilter = "sysid_enrolmentlevel = '" + sysIdEnrolmentLevel + "'";
            DataRow[] selectRow = _studentLevelTable.Select(strFilter);

            foreach (DataRow levelRow in selectRow)
            {
                cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "group_description", "") + " - " +
                       RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_description", ""));

                break;
            }

            cboBase.SelectedIndex = 0;
        }//-----------------------------------

        //this procedure initialized the course checked list box
        public void InitializeCourseCheckedListBox(CheckedListBox cbxBase)
        {
            cbxBase.Items.Clear();

            if (_classDataSet.Tables["CourseInformationTable"] != null)
            {
                foreach (DataRow courseRow in _classDataSet.Tables["CourseInformationTable"].Rows)
                {
                    cbxBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_title", "") + " [" + 
                        RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_acronym", "") + "]");
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

        //this procedure deletes the image directory
        public void DeleteImageDirectory(String startUp)
        {
            String imagePath = startUp + _imagePath;

            RemoteClient.ProcStatic.DeleteDirectory(imagePath);
        }//--------------------------------

        //this procedure refreshes the data
        public void RefreshStudentData(CommonExchange.SysAccess userInfo)
        {
            this.InitializeClass(userInfo);
        }//-------------------------------

        //this procedure initializes the class
        private void InitializeClass(CommonExchange.SysAccess userInfo)
        {
            //gets the server date and time
            using (RemoteClient.RemCntBaseManager remClient = new RemoteClient.RemCntBaseManager())
            {
                _serverDateTime = remClient.GetServerDateTime(userInfo);
            } //--------------------------------

            //gets the dataset for the student information
            using (RemoteClient.RemCntStudentManager remClient = new RemoteClient.RemCntStudentManager())
            {
                _classDataSet = remClient.GetDataSetForStudentInformation(userInfo, _serverDateTime);
            } //---------------------------------                  

            _schoolYearSemesterForIdTable = new DataTable("SchoolYearSemesterTable");
            _schoolYearSemesterForIdTable.Columns.Add("sysid_schoolfee", System.Type.GetType("System.String"));
            _schoolYearSemesterForIdTable.Columns.Add("year_id", System.Type.GetType("System.String"));
            _schoolYearSemesterForIdTable.Columns.Add("year_description", System.Type.GetType("System.String"));
            _schoolYearSemesterForIdTable.Columns.Add("date_start", System.Type.GetType("System.String"));
            _schoolYearSemesterForIdTable.Columns.Add("date_end", System.Type.GetType("System.String"));

            foreach (DataRow yearRow in _classDataSet.Tables["SchoolFeeInformationTable"].Rows)
            {
                if (!RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "is_summer", false))
                {
                    DataRow newRow = _schoolYearSemesterForIdTable.NewRow();

                    newRow["sysid_schoolfee"] = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "sysid_schoolfee", String.Empty);
                    newRow["year_id"] = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "year_id", String.Empty);
                    newRow["year_description"] = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "year_description", String.Empty);
                    newRow["date_start"] = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "date_start", String.Empty);
                    newRow["date_end"] = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "date_end", String.Empty);

                    _schoolYearSemesterForIdTable.Rows.Add(newRow);
                }
            }
        }//--------------------------

        //this procedure will initialized the school fee level table
        public void SelectBySysIDSchoolFeeSchoolFeeLevel(CommonExchange.SysAccess userInfo, String sysIdSchoolFee)
        {
            using (RemoteClient.RemCntSchoolFeeManager remClient = new RemoteClient.RemCntSchoolFeeManager())
            {
                _schoolFeeLevelTable = remClient.SelectBySysIDSchoolFeeSchoolFeeLevel(userInfo, sysIdSchoolFee);
            }
        }//---------------------------------

        //this procedure will initialized student enrolment course and enrolment level table
        public void InitializeStudentEnrolmentCourseLevelTable(CommonExchange.SysAccess userInfo, String studentSysId)
        {
            using (RemoteClient.RemCntStudentEnrolmentManager remClient = new RemoteClient.RemCntStudentEnrolmentManager())
            {
                //gets student enrolment course
                _studentCourseTable = remClient.SelectBySysIDStudentStudentEnrolmentCourse(userInfo, studentSysId);
                //------------------
                
                //gets student enrolment level
                _studentLevelTable = remClient.SelectBySysIDStudentStudentEnrolmentLevel(userInfo, studentSysId);
                //------------------
            }
        }//------------------------------

        //this procedure gets the student enrolment course / level histroy by student system id 
        public void SelectBySysIDStudentForEnrolmentHistoryEnrolmentCourseLevel(CommonExchange.SysAccess userInfo, String studentSysId)
        {
            using (RemoteClient.RemCntStudentEnrolmentManager remClient = new RemoteClient.RemCntStudentEnrolmentManager())
            {
                _studentCourseHistoryTable = remClient.SelectBySysIDStudentForEnrolmentHistoryEnrolmentCourse(userInfo, studentSysId);

                _studentLevelHistroyTable = remClient.SelectBySysIDStudentForEnrolmentHistoryEnrolmentLevel(userInfo, studentSysId);
            }
        }//----------------------------

        //this procedure will clear cached data
        public void ClearCachedData()
        {
            if (_studentCourseTable != null)
            {
                _studentCourseTable.Clear();
            }

            if (_studentLevelTable != null)
            {
                _studentLevelTable.Clear();
            }

            if (_schoolFeeLevelTable != null)
            {
                _schoolFeeLevelTable.Clear();
            }

            if (_studentEnrolmentCourseLevelList != null)
            {
                _studentEnrolmentCourseLevelList.Clear();
            }
        }//-----------------------------
        #endregion

        #region Programmer-Defined Function Procedures          
        //this fucntion gets the maximun enrolment level no
        private String GetMaxEnrolmentLevelNoBySysId(DataRow[] selectRow)
        {
            String value = String.Empty;

            Int32 index = 0;
            Int16 enrolmentLevelNo = 0;

            foreach (DataRow enrolmentRow in selectRow)
            {

                if (index == 0)
                {
                    enrolmentLevelNo = RemoteServerLib.ProcStatic.DataRowConvert(enrolmentRow, "enrolment_level_no", Int16.Parse("0"));
                    value = RemoteServerLib.ProcStatic.DataRowConvert(enrolmentRow, "sysid_enrolmentlevel", "");
                }
                else if (RemoteServerLib.ProcStatic.DataRowConvert(enrolmentRow, "enrolment_level_no", Int32.Parse("0")) > enrolmentLevelNo)
                {
                    enrolmentLevelNo = RemoteServerLib.ProcStatic.DataRowConvert(enrolmentRow, "enrolment_level_no", Int16.Parse("0"));
                    value = RemoteServerLib.ProcStatic.DataRowConvert(enrolmentRow, "sysid_enrolmentlevel", "");
                }

                index++;
            }

            return value;
        }//----------------------------      
      
        //this fucntion gets the course group id by Level
        private String GetCourseGroupIdByLevel(String sysidFeeLevel)
        {
            String value = String.Empty;

            String strFilter = "sysid_feelevel = '" + sysidFeeLevel + "'";
            DataRow[] selectRow = _schoolFeeLevelTable.Select(strFilter);

            foreach (DataRow feeRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "course_group_id", "");
            }

            return value;
        }//---------------------------

        //this fucntion gets the course group id by course
        private String GetCourseGroupIdByCourse(String courseId)
        {
            String value = String.Empty;

            String strFilter = "course_id = '" + courseId + "'";
            DataRow[] selectRow = _classDataSet.Tables["CourseInformationTable"].Select(strFilter);

            foreach (DataRow courseRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_group_id", "");
            }

            return value;
        }//---------------------------

        //this fucntion gets the year descrition by system id school fee
        private String GetYearDescriptionByFeeLevelSystemId(String sysIdFeeLevel)
        {
            String value = String.Empty;

            String strFilter = "sysid_feelevel = '" + sysIdFeeLevel + "'";
            DataRow[] selectRow = _schoolFeeLevelTable.Select(strFilter);

            foreach (DataRow levelRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_description", "");
            }

            return value;
        }//-------------------------       

        //this fucntion gets the year level description by fee level system id
        private String GetYearLevelDescription(String sysIdFeeLevel)
        {
            String value = String.Empty;

            String strFilter = "sysid_feelevel = '" + sysIdFeeLevel + "'";
            DataRow[] selectRow = _schoolFeeLevelTable.Select(strFilter);

            foreach (DataRow feeRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "year_level_description", "");
            }

            return value;
        }//----------------------

        //this function gets the year level description
        private String GetYearDescription(String sysIdSchoolFee)
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

        //this fucntion gets the group description by fee level system id
        private String GetGroupDescription(String sysIdFeeLevel)
        {
            String value = String.Empty;

            String strFilter = "sysid_feelevel = '" + sysIdFeeLevel + "'";
            DataRow[] selectRow = _schoolFeeLevelTable.Select(strFilter);

            foreach (DataRow feeRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "group_description", "");
            }

            return value;
        }//----------------------

        //this function gets the year decricption by system id fee information
        public String GetYearDescriptionByFeeInformationSystemId(String sysIdFeeInformation)
        {
            String value = String.Empty;

            String strFilter = "sysid_schoolfee = '" + sysIdFeeInformation + "'";
            DataRow[] selectRow = _classDataSet.Tables["SchoolFeeInformationTable"].Select(strFilter);

            foreach (DataRow yearRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "year_description", "");
            }

            return value;
        }//----------------------------------

        //this fucntion gets the semester description
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
        }//-------------------

        //this function gets the year system id
        public String GetYearId(Int32 index)
        {
            DataRow yearRow = _classDataSet.Tables["SchoolFeeInformationTable"].Rows[index];

            return RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "year_id", String.Empty);
        }//-----------------------

        //this fucntion gets the year syste id by sysid school fee
        public String GetYearIdBySysIdSchoolFee(String sysIdSchoolFee)
        {
            String value = String.Empty;

            String strFilter = "sysid_schoolfee = '" + sysIdSchoolFee + "'";
            DataRow[] selectRow = _classDataSet.Tables["SchoolFeeInformationTable"].Select(strFilter);

            foreach (DataRow yearRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "year_id", String.Empty);

                break;
            }

            return value;
        }//---------------------

        //this fucntion gets the year id
        public String GetYearId(String sysIdFeeLevel)
        {
            String value = String.Empty;

            String strFilter = "sysid_feelevel = '" + sysIdFeeLevel + "'";
            DataRow[] selectRow = _schoolFeeLevelTable.Select(strFilter);

            foreach (DataRow levelRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_id", "");
            }

            return value;
        }//------------------------

        //this fucntion gets the year id by enrolment level system id
        public String GetYearIdByEnrolmentLevelSysId(String enrolmentlevelSysId)
        {
            String value = String.Empty;

            String strFilter = "sysid_enrolmentlevel = '" + enrolmentlevelSysId + "'";
            DataRow[] selectRow = _studentLevelTable.Select(strFilter);

            foreach (DataRow levelRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_id", "");
            }

            return value;
        }//------------------------

        //this function gets the school fee information system id
        public String GetFeeInformationSysId(Int32 index)
        {
            DataRow feeRow = _classDataSet.Tables["SchoolFeeInformationTable"].Rows[index];

            return feeRow["sysid_schoolfee"].ToString();
        }//----------------------------

        //this function gets the school fee information system id no summer
        public String GetFeeInformationSysIdNoSummer(Int32 index)
        {
            String strFilter = "is_summer = 0";
            DataRow[] selectRow = _classDataSet.Tables["SchoolFeeInformationTable"].Select(strFilter);
            DataRow feeRow = selectRow[index];

            String feeInformationSysIDList = String.Empty; //feeRow["sysid_schoolfee"].ToString();

            //String dateStart = DateTime.Parse(feeRow["date_start"].ToString()).AddDays(-10).ToShortDateString() + " 12:00:00 AM";
            //String dateEnd = DateTime.Parse(feeRow["date_end"].ToString()).ToShortDateString() + " 11:59:59 PM";
           
            //String strFilterDate = "date_end >= #" + dateStart + "# AND date_end <= #" + dateEnd + "#";
            //DataRow[] selectRowDate = _classDataSet.Tables["SchoolFeeInformationTable"].Select(strFilterDate);

            //foreach (DataRow schoolFeeRow in selectRowDate)
            //{
            //    feeInformationSysIDList += RemoteServerLib.ProcStatic.DataRowConvert(schoolFeeRow, "sysid_schoolfee", String.Empty) + ", ";
            //}

            DateTime dateStart = DateTime.Parse(feeRow["date_start"].ToString()).AddDays(-10);
            DateTime dateEnd = DateTime.Parse(feeRow["date_end"].ToString());

            foreach (DataRow schoolFeeRow in _classDataSet.Tables["SchoolFeeInformationTable"].Rows)
            {
                if ((DateTime.Compare(dateStart, DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(schoolFeeRow, "date_end", String.Empty))) <= 0) &&
                    (DateTime.Compare(dateEnd, DateTime.Parse(RemoteServerLib.ProcStatic.DataRowConvert(schoolFeeRow, "date_end", String.Empty))) >= 0))
                {
                    feeInformationSysIDList += RemoteServerLib.ProcStatic.DataRowConvert(schoolFeeRow, "sysid_schoolfee", String.Empty) + ", ";
                }
            }

            if (feeInformationSysIDList.Length >= 2)
            {
                return feeInformationSysIDList.ToString().Substring(0, feeInformationSysIDList.Length - 2);
            }
            else
            {
                return String.Empty;
            }            
        }//----------------------------

        //this function gets the school fee information system id
        public String GetFeeInformationSysIdForId(Int32 index)
        {
            DataRow feeRow = _schoolYearSemesterForIdTable.Rows[index];

            return feeRow["sysid_schoolfee"].ToString();
        }//----------------------------
       
        //this function gets the semester system id
        public String GetSemesterSystemId(Int32 yearIndex, Int32 semIndex)
        {
            DataRow yearRow = _classDataSet.Tables["SchoolFeeInformationTable"].Rows[yearIndex];

            String strFilter = "year_id = '" + yearRow["year_id"].ToString() + "'";
            DataRow[] selectRow = _classDataSet.Tables["SemesterInformationTable"].Select(strFilter);

            DataRow semRow = selectRow[semIndex];

            return RemoteServerLib.ProcStatic.DataRowConvert(semRow, "sysid_semester", "");
        } //-----------------------------------------

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
       
        //this fucntion get the year level prefix
        public String GetYearLevelPrefix(Int32 levelIndex)
        {
            DataRow levelRow = _schoolFeeLevelTable.Rows[levelIndex];

            return RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "id_prefix", "");
        }//----------------------------

        //this function gets the school year year id
        public String GetSchoolYearYearId(Int32 index)
        {
            DataRow _yearRow = _classDataSet.Tables["SchoolFeeInformationTable"].Rows[index];

            return _yearRow["year_id"].ToString();
        }//----------------------------

        //this function gets the school year year id no summer
        public String GetSchoolYearYearIdNoSummer(Int32 index)
        {
            String strFilter = "is_summer = 0";
            DataRow[] selectRow = _classDataSet.Tables["SchoolFeeInformationTable"].Select(strFilter);
            DataRow yearRow = selectRow[index];

            return yearRow["year_id"].ToString();
        }//----------------------------

        //this function gets the course id
        public String GetCourseId(Int32 index)
        {
            if (_classDataSet.Tables["CourseInformationTable"] != null)
            {
                DataRow courseRow = _classDataSet.Tables["CourseInformationTable"].Rows[index];

                return RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_id", "");
            }
            else
            {
                return String.Empty;
            }
        } //----------------------------     

        //this function gets the course id
        public String GetSysIdEnrolmentCourse(String enrolmentLevel)
        {
            String value = String.Empty;

            String strFilter = "sysid_enrolmentlevel = '" + enrolmentLevel + "'";
            DataRow[] selectRow = _studentLevelTable.Select(strFilter);

            foreach (DataRow courseRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "sysid_enrolmentcourse", String.Empty);
            }

            return value;
        } //----------------------------    

        //this function gets year level id
        public String GetYearLevelId(String courseId, Int32 index)
        {
            DataTable newTable = new DataTable("NewTable");
            newTable.Columns.Add("year_level_id", System.Type.GetType("System.String"));

            String strFilter = "course_id = '" + courseId + "'";
            DataRow[] selectRow = _classDataSet.Tables["CourseYearLevelTable"].Select(strFilter);

            foreach (DataRow yearRow in selectRow)
            {
                DataRow newRow = newTable.NewRow();

                newRow["year_level_id"] = RemoteServerLib.ProcStatic.DataRowConvert(yearRow, "year_level_id", "");

                newTable.Rows.Add(newRow);
            }

            newTable.AcceptChanges();

            DataRow levelRow = newTable.Rows[index];

            return RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "year_level_id", "");
        }//-------------------------------

        //this function gets year level id
        public String GetYearLevelId(Int32 index)
        {
            DataRow levelRow = _classDataSet.Tables["YearLevelInformationTable"].Rows[index];

            return levelRow["year_level_id"].ToString();
        }//-------------------------------

        //this function gets year level id
        public String GetYearLevelIdBySchoolFeeTable(Int32 index)
        {
            String levelId = String.Empty;

            if (_schoolFeeLevelTable != null)
            {
                DataRow levelRow = _schoolFeeLevelTable.Rows[index];
                
                levelId = levelRow["year_level_id"].ToString();
            }

            return levelId;
        }//------------------------------

        //this function gets course group id
        public String GetCourseGroupIDBySchoolFeeTable(Int32 index)
        {
            String courseGroupId = String.Empty;

            if (_schoolFeeLevelTable != null)
            {
                DataRow courseRow = _schoolFeeLevelTable.Rows[index];

                courseGroupId = courseRow["course_group_id"].ToString();
            }

            return courseGroupId;
        }//------------------------------

        //this function gets system id fee level
        public String GetFeeLevelSysId(String yearLevelId)
        {
            String value = String.Empty;

            String strFilter = "year_level_id = '" + yearLevelId + "'";
            DataRow[] selectRow = _schoolFeeLevelTable.Select(strFilter);

            foreach (DataRow feeRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(feeRow, "sysid_feelevel", "");
            }

            return value;
        }//----------------------------

        //this function gets count of student id
        public String GetCountForStudentIDStudentInformation(CommonExchange.SysAccess userInfo, String schoolFeeSysId, String yearLevelId)
        {
            Int32 count = 0;

            using (RemoteClient.RemCntStudentManager remClient = new RemoteClient.RemCntStudentManager())
            {
                count = remClient.GetCountForStudentIDStudentInformation(userInfo, schoolFeeSysId, yearLevelId);
            }

            return RemoteServerLib.ProcStatic.ThreeDigitZero(count + 1).ToString();
        }//-------------------------------
      
        //this function get the course department
        public String GetCourseDepartmentName(String courseId)
        {
            String value = String.Empty;

            String strFilter = "course_id = '" + courseId + "'";
            DataRow[] selectRow = _classDataSet.Tables["CourseInformationTable"].Select(strFilter);

            foreach (DataRow courseRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "department_name", "");
            }

            return value;
        }//-------------------------

        //this function get the course title
        public String GetCourseTitle(String courseId)
        {
            String value = String.Empty;

            String strFilter = "course_id = '" + courseId + "'";
            DataRow[] selectRow = _classDataSet.Tables["CourseInformationTable"].Select(strFilter);

            foreach (DataRow courseRow in selectRow)
            {
                value = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_title", "");
            }
             
            return value;
        }//-------------------------     

        //this function is used to determine if the student id exists
        public Boolean IsExistStudentIdStudentInformation(CommonExchange.SysAccess userInfo, String studentId, String studentSysId)
        {
            Boolean isExist = false;

            using (RemoteClient.RemCntStudentManager remClient = new RemoteClient.RemCntStudentManager())
            {
                isExist = remClient.IsExistsStudentIdStudentInformation(userInfo, studentId, studentSysId);
            }

            return isExist;
        } //-------------------------------

        //this function gets the seacrched course information
        public DataTable GetSearchedCourseInformation(String strCriteria, String courseGroupId)
        {
            DataTable newTable = new DataTable("CourseInformationSearch");
            newTable.Columns.Add("course_id", System.Type.GetType("System.String"));
            newTable.Columns.Add("course_title", System.Type.GetType("System.String"));
            newTable.Columns.Add("department_name", System.Type.GetType("System.String"));

            strCriteria = strCriteria.Replace("*", "").Replace("%", "").Replace("'", "''");
            
            String strFiler = "course_group_id = '" + courseGroupId + "' AND  (course_id LIKE '%" + strCriteria 
                + "%' OR course_title LIKE '%" + strCriteria + "%' OR course_acronym LIKE '%" +
                strCriteria + "%' OR department_acronym LIKE '%" + strCriteria + "%' OR department_name LIKE '%" + strCriteria + "%')";
            DataRow[] selectRow = _classDataSet.Tables["CourseInformationTable"].Select(strFiler, "course_title ASC");

            foreach (DataRow courseRow in selectRow)
            {
                DataRow newRow = newTable.NewRow();

                newRow["course_id"] = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_id", "");
                newRow["course_title"] = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_title", "") + "  [" +
                    RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_acronym", "") + "]";
                newRow["department_name"] = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "department_name", "");

                newTable.Rows.Add(newRow);
            }

            newTable.AcceptChanges();

            return newTable;
        }//----------------------------

        //this fucntion get the student enrolment level infromation
        public CommonExchange.StudentEnrolmentLevel GetDetailsStudentEnrolmentLevel(String enrolmentLevelSysId)
        {
            CommonExchange.StudentEnrolmentLevel enrolmentLevelInfo = new CommonExchange.StudentEnrolmentLevel();

            String strFilter = "sysid_enrolmentlevel = '" + enrolmentLevelSysId + "'";
            DataRow[] selectRow = _studentLevelTable.Select(strFilter);

            foreach (DataRow levelRow in selectRow)
            {
                enrolmentLevelInfo.EnrolmentLevelSysId = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "sysid_enrolmentlevel", "");
                enrolmentLevelInfo.StudentEnrolmentCourseInfo.EnrolmentCourseSysId =
                    RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "sysid_enrolmentcourse", "");
                enrolmentLevelInfo.SchoolFeeLevelInfo.FeeLevelSysId = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "sysid_feelevel", "");

                String strFilterLevel = "course_group_id = '" + RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "course_group_id", "") + "'";
                DataRow[] selectLevel = _studentLevelTable.Select(strFilterLevel);

                String enrolmentLevelSysIdForIsEntryLevl = this.GetMaxEnrolmentLevelNoBySysId(selectLevel);

                enrolmentLevelInfo.IsEntryLevel = String.Equals(RemoteServerLib.ProcStatic.DataRowConvert(levelRow,
                    "sysid_enrolmentlevel", ""), enrolmentLevelSysIdForIsEntryLevl) ? true : false;
                enrolmentLevelInfo.SemesterInfo.SemesterSysId = RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "sysid_semester", "");
            }

            return enrolmentLevelInfo;
        }//----------------------------

        //this fucntion get the student enrolment course information for creation
        public CommonExchange.StudentEnrolmentCourse GetDetailsStudentCourseInfo(String courseGroupId)
        {
            CommonExchange.StudentEnrolmentCourse courseInfo = new CommonExchange.StudentEnrolmentCourse();

            foreach (DataRow courseRow in _studentCourseTable.Rows)
            {                
                if (String.Equals(RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_group_id", ""), courseGroupId) &&
                    RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "is_current_course", false))
                {
                    courseInfo.EnrolmentCourseSysId = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "sysid_enrolmentcourse", "");
                    courseInfo.CourseInfo.CourseId = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_id", "");
                    courseInfo.IsCurrentCourse = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "is_current_course", false);
                    courseInfo.StudentInfo.StudentSysId = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "sysid_student", "");
                    courseInfo.SchoolFeeInfo.FeeInformationSysId = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "sysid_schoolfee", "");
                    courseInfo.SemesterInfo.SemesterSysId = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "sysid_semester", "");
                }
            }

            return courseInfo;
        }//-------------------------------

        //this fucntion get the student course information for course update
        public CommonExchange.StudentEnrolmentCourse GetDetailsStudentCourseInfoByCourseId(String sysIdCourse)
        {
            CommonExchange.StudentEnrolmentCourse courseInfo = new CommonExchange.StudentEnrolmentCourse();

            String strFilter = "course_id = '" + sysIdCourse + "'";
            DataRow[] selectRow = _studentCourseTable.Select(strFilter);

            foreach (DataRow courseRow in selectRow)
            {
                courseInfo.EnrolmentCourseSysId = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "sysid_enrolmentcourse", "");
                courseInfo.StudentInfo.StudentSysId = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "sysid_student", "");
                courseInfo.CourseInfo.CourseId = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_id", "");
                courseInfo.SchoolFeeInfo.FeeInformationSysId = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "sysid_schoolfee", "");
                courseInfo.SemesterInfo.SemesterSysId = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "sysid_semester", "");
                courseInfo.IsCurrentCourse = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "is_current_course", false);
            }

            return courseInfo;
        }//--------------------------

        //this fucntion get the student course information for course update
        public CommonExchange.StudentEnrolmentCourse GetDetailsStudentCourseInfoByEnrolmentCourse(String enrolmentCourseSysId)
        {
            CommonExchange.StudentEnrolmentCourse courseInfo = new CommonExchange.StudentEnrolmentCourse();

            String strFilter = "sysid_enrolmentcourse = '" + enrolmentCourseSysId + "'";
            DataRow[] selectRow = _studentCourseTable.Select(strFilter);

            foreach (DataRow courseRow in selectRow)
            {
                courseInfo.EnrolmentCourseSysId = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "sysid_enrolmentcourse", "");
                courseInfo.StudentInfo.StudentSysId = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "sysid_student", "");
                courseInfo.CourseInfo.CourseId = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_id", "");
                courseInfo.SchoolFeeInfo.FeeInformationSysId = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "sysid_schoolfee", "");
                courseInfo.SemesterInfo.SemesterSysId = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "sysid_semester", "");
                courseInfo.IsCurrentCourse = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "is_current_course", false);
            }

            return courseInfo;
        }//--------------------------

        //this fucntion gets the selected course
        public CommonExchange.CourseInformation GetSelectedCourse(String sysIdCourse)
        {
            CommonExchange.CourseInformation courseInfo = new CommonExchange.CourseInformation();

            String strFiler = "course_id = '" + sysIdCourse + "'";
            DataRow[] selectRow = _classDataSet.Tables["CourseInformationTable"].Select(strFiler);

            foreach (DataRow courseRow in selectRow)
            {
                courseInfo.CourseId = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_id", "");
                courseInfo.CourseTitle = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_title", "");            
            }

            return courseInfo;
        }//------------------------

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
            }

            newTable.AcceptChanges();                 
            
            return newTable;
        }//-----------------------------

        //this function returns the student details
        public CommonExchange.Student GetDetailsStudentInformation(CommonExchange.SysAccess userInfo, String studentId, String startUp)
        {
            CommonExchange.Student studentInfo = new CommonExchange.Student();

            using (RemoteClient.RemCntStudentManager remClient = new RemoteClient.RemCntStudentManager())
            {               
                studentInfo = remClient.SelectByStudentIDStudentInformation(userInfo, studentId);

                DateTime bDate = DateTime.Parse(studentInfo.PersonInfo.BirthDate);
                DateTime mDate = DateTime.Parse(studentInfo.PersonInfo.MarriageDate);

                if (DateTime.Compare(bDate, DateTime.MinValue) == 0)
                    studentInfo.PersonInfo.BirthDate = String.Empty;

                if (DateTime.Compare(mDate, DateTime.MinValue) == 0)
                    studentInfo.PersonInfo.MarriageDate = String.Empty;

                studentInfo.PersonInfo.FilePath = base.GetPersonImagePath(userInfo, studentInfo.PersonInfo.PersonSysId,
                    studentInfo.PersonInfo.PersonImagesFolder(startUp));
            }

            return studentInfo;
        }//----------------------------

        //this fucntion determines if a studnet course already exist
        public Boolean IsExistsStudentCourseStudentEnrolmentCourse(CommonExchange.SysAccess userInfo, String studentSysId, String courseId)
        {
            Boolean isExist = false;

            using (RemoteClient.RemCntStudentEnrolmentManager remClient = new RemoteClient.RemCntStudentEnrolmentManager())
            {
                isExist = remClient.IsExistsStudentCourseStudentEnrolmentCourse(userInfo, studentSysId, courseId);
            }

            if (_studentCourseTable != null && !isExist)
            {
                String strFilter = "sysid_student = '" + studentSysId + "' AND course_id = '" + courseId + "'";
                DataRow[] selectRow = _studentCourseTable.Select(strFilter);

                if (selectRow.Length >= 1)
                {
                    isExist = true;
                }
            }

            return isExist;
        }//--------------------------

        //this function determines if IsNotValidForCourseSchoolFeeSysIDSemesterStudentEnrolmentLevel
        public Boolean IsNotValidForCourseSchoolFeeSysIDSemesterStudentEnrolmentLevel(CommonExchange.SysAccess userInfo,
            String enrolmentCourseSysId, String schoolFeeSysId, String semesterSysId)
        {
            Boolean isNotValid = false;

            using (RemoteClient.RemCntStudentEnrolmentManager remClient = new RemoteClient.RemCntStudentEnrolmentManager())
            {
                isNotValid = remClient.IsNotValidForCourseSchoolFeeSysIDSemesterStudentEnrolmentLevel(userInfo, enrolmentCourseSysId, schoolFeeSysId, semesterSysId);
            }

            return isNotValid;
        }//---------------------
              
        //this function determines if the course isSemestral
        public Boolean IsSemestralByCourse(String courseId)
        {
            Boolean isSemestral = false;

            String strFilter = "course_id = '" + courseId + "'";
            DataRow[] selectRow = _classDataSet.Tables["CourseInformationTable"].Select(strFilter);

            foreach (DataRow courseRow in selectRow)
            {
                isSemestral = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "is_semestral", false);
            }

            return isSemestral;
        }//----------------------

        //this function determins if the course group isSemestral
        public Boolean IsSemestralByCourseGroup(String courseGroupId)
        {
            Boolean isSemestral = false;

            String strFilter = "course_group_id = '" + courseGroupId + "'";
            DataRow[] selectRow = _classDataSet.Tables["CourseGroupTable"].Select(strFilter);

            foreach (DataRow courseRow in selectRow)
            {
                isSemestral = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "is_semestral", false);
            }

            return isSemestral;
        }//-------------------------

        //this function determines if current course has created entry level
        public Boolean HasCurrentCourseEntryLevelCreated()
        {
            Boolean hasEntryLevel = false;

            String courseGroupId = String.Empty;

            if (_studentCourseTable != null)
            {
                foreach (DataRow courseRow in _studentCourseTable.Rows)
                {
                    if (RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "is_current_course", true))
                    {
                        courseGroupId = RemoteServerLib.ProcStatic.DataRowConvert(courseRow, "course_group_id", "");

                        break;
                    }
                }

                foreach (DataRow levelRow in _studentLevelTable.Rows)
                {
                    if (levelRow.RowState != DataRowState.Deleted)
                    {
                        if (String.Equals(courseGroupId, RemoteServerLib.ProcStatic.DataRowConvert(levelRow, "course_group_id", "")))
                        {
                            hasEntryLevel = true;
                        }
                    }
                }
            }

            return hasEntryLevel;
        }//----------------------

        //this function determines if the student has current couse
        public Boolean HasCurrentCourse()
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

        //this function will determine if the student has a special class load       
        public Boolean HasSpecialClassLoad(CommonExchange.SysAccess userInfo, String studentSysIdList,
            String dateStart, String dateEnd)
        {
            Boolean hasLoad = false;

            using (RemoteClient.RemCntSpecialClassManager remClient = new RemoteClient.RemCntSpecialClassManager())
            {
                _specialClassTable = remClient.SelectBySysIDStudentListDateStartEndSpecialClassInformation(userInfo, studentSysIdList, dateStart,
                    dateEnd, _serverDateTime);
            }

            if (_specialClassTable != null)
            {
                foreach (DataRow specialRow in _specialClassTable.Rows)
                {
                    if (!RemoteServerLib.ProcStatic.DataRowConvert(specialRow, "is_premature_deloaded", false))
                    {
                        hasLoad = true;

                        break;
                    }
                }
            }            

            return hasLoad;
        }//---------------------------------------

        //this function determins if IsCourseYearLevelNoLesserStudentEnrolmentLevel
        public Boolean IsCourseYearLevelNoLesserStudentEnrolmentLevel(CommonExchange.SysAccess userInfo, String studentSysId, String courseId, String yearLevelId)
        {
            Boolean hasEnrolmentLevel = false;

            using (RemoteClient.RemCntStudentEnrolmentManager remClient = new RemoteClient.RemCntStudentEnrolmentManager())
            {
                hasEnrolmentLevel = remClient.IsCourseYearLevelNoLesserStudentEnrolmentLevel(userInfo, studentSysId, courseId, yearLevelId, String.Empty);
            }

            return hasEnrolmentLevel;
        }//--------------------------

        //this fucntion determins if IsExistSysIDStudentCourseLevelSemesterEnrolmentLevel
        public Boolean IsExistSysIDStudentCourseLevelSemesterEnrolmentLevel(CommonExchange.SysAccess userInfo, 
            CommonExchange.StudentEnrolmentLevel enrolmentLevelInfo, String studentSysId, String enrolmentCourseSysId,
            String feeLevelSysId, String semesterSysId)
        {
            Boolean isExist = false, isFound = false;

            foreach (StudentEnrolmentList list in _studentEnrolmentCourseLevelList)
            {
                if ((String.Equals(list.EnrolmentLevelInfo.SchoolFeeLevelInfo.FeeLevelSysId, enrolmentLevelInfo.SchoolFeeLevelInfo.FeeLevelSysId) &&
                    String.Equals(list.EnrolmentLevelInfo.SemesterInfo.SemesterSysId, enrolmentLevelInfo.SemesterInfo.SemesterSysId)) &&
                    !list.EnrolmentLevelInfo.IsMarkedDeleted)
                {
                    isFound = true;

                    break;
                }
            }

            if (!isFound)
            {
                using (RemoteClient.RemCntStudentEnrolmentManager remClient = new RemoteClient.RemCntStudentEnrolmentManager())
                {
                    isExist = remClient.IsExistSysIDStudentCourseLevelSemesterEnrolmentLevel(userInfo, studentSysId, enrolmentCourseSysId, feeLevelSysId, semesterSysId);
                }

                if (_studentLevelTable != null && !isExist)
                {
                    String strFilter = "sysid_feelevel = '" + feeLevelSysId + "' OR sysid_semester = '" + semesterSysId + "'";
                    DataRow[] selectRow = _studentLevelTable.Select(strFilter);

                    if (selectRow.Length >= 1)
                    {
                        isExist = true;
                    }
                }
            }

            return isExist;
        }//-------------------------

        //this function determins if IsValidByCourseInformationSchoolFeeSysIDSemesterStudentEnrolmentCourse
        public Boolean IsValidByCourseInformationSchoolFeeSysIDSemesterStudentEnrolmentCourse(CommonExchange.SysAccess userInfo,
            String enrolmentCourseSysId, String schoolFeeSysId, String semesterSysId)
        {
            Boolean isValid = false;

            using (RemoteClient.RemCntStudentEnrolmentManager remClient = new RemoteClient.RemCntStudentEnrolmentManager())
            {
                isValid = remClient.IsValidByCourseInformationSchoolFeeSysIDSemesterStudentEnrolmentCourse(userInfo, enrolmentCourseSysId, schoolFeeSysId, semesterSysId);
            }

            return isValid;
        }//------------------------

        //this fucntion determins if Is Exist Year Level in semester and year
        public Boolean IsExistLevelSemesterYear(String semesterSysId, String yearId)
        {
            Boolean isExist = false;

            String strFilter = String.IsNullOrEmpty(semesterSysId) ? "year_id = '" + yearId + "'" : "year_id = '" + yearId + 
                "' AND sysid_semester = '" + semesterSysId + "'";
            DataRow[] selectRow = _studentLevelTable.Select(strFilter);

            if (selectRow.Length >= 1)
            {
                isExist = true;
            }

            return isExist;
        }//---------------------------

        //this fucntion will get Employee and Subject Schedule System Id
        public String GetSystemId(String strValue)
        {
            return strValue.Substring(strValue.IndexOf("[") + 1, strValue.IndexOf("]") - strValue.IndexOf("[") - 1);
        }//-------------------------

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
        
        #endregion
    }
}
