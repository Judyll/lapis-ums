using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace ImportInterBaseStudentData
{
    partial class StudentImport
    {
        #region Class Structure Declarations

        private struct RemarksDetails
        {
            private String _courseName;
            public String CourseName
            {
                get { return _courseName; }
                set { _courseName = value; }
            }

            private String _otherInformation;
            public String OtherInformation
            {
                get { return _otherInformation; }
                set { _otherInformation = value; }
            }
        }

        private struct StudentName
        {
            private String _lastName;
            public String LastName
            {
                get { return _lastName; }
                set { _lastName = value; }
            }

            private String _firstName;
            public String FirstName
            {
                get { return _firstName; }
                set { _firstName = value; }
            }

            private String _scholarship;
            public String Scholoarship
            {
                get { return _scholarship; }
                set { _scholarship = value; }
            }

        }

        private struct StudentImage
        {
            private String _imagePath;
            public String ImagePath
            {
                get { return _imagePath; }
                set { _imagePath = value; }
            }

            private String _imageExtension;
            public String ImageExtension
            {
                get { return _imageExtension; }
                set { _imageExtension = value; }
            }
        }

        #endregion

        #region Programmer-Defined Void Procedures

        //this procedure initializes the student data table
        private void InitializeStudentDataTable()
        {
            _studentTable = new DataTable("StudentsTable");
            _studentTable.Columns.Add("CLASSIF", System.Type.GetType("System.String"));
            _studentTable.Columns.Add("TITLE", System.Type.GetType("System.String"));
            _studentTable.Columns.Add("TITLE0", System.Type.GetType("System.String"));
            _studentTable.Columns.Add("AUTHORS", System.Type.GetType("System.String"));
            _studentTable.Columns.Add("EDITORS", System.Type.GetType("System.String"));
            _studentTable.Columns.Add("XLATORS", System.Type.GetType("System.String"));
            _studentTable.Columns.Add("SUBJECTS", System.Type.GetType("System.String"));
            _studentTable.Columns.Add("PUBLISHER", System.Type.GetType("System.String"));
            _studentTable.Columns.Add("EDITION", System.Type.GetType("System.String"));
            _studentTable.Columns.Add("VOLUME", System.Type.GetType("System.String"));
            _studentTable.Columns.Add("NOPAGES", System.Type.GetType("System.String"));
            _studentTable.Columns.Add("ISSUANCE", System.Type.GetType("System.String"));
            _studentTable.Columns.Add("LENDING", System.Type.GetType("System.String"));
            _studentTable.Columns.Add("PENALTY", System.Type.GetType("System.String"));
            _studentTable.Columns.Add("RENTAL", System.Type.GetType("System.String"));
            _studentTable.Columns.Add("PRICE", System.Type.GetType("System.String"));
            _studentTable.Columns.Add("KEYWORDS", System.Type.GetType("System.String"));
            _studentTable.Columns.Add("REMARKS", System.Type.GetType("System.String"));
            _studentTable.Columns.Add("BORROWER", System.Type.GetType("System.String"));
            _studentTable.Columns.Add("BORROWERDATE", System.Type.GetType("System.DateTime"));
            _studentTable.Columns.Add("PWORD", System.Type.GetType("System.String"));
            _studentTable.Columns.Add("DTYPE", System.Type.GetType("System.String"));
            _studentTable.Columns.Add("DYEAR", System.Type.GetType("System.String"));
            _studentTable.Columns.Add("LASTUPDATE", System.Type.GetType("System.DateTime"));
            _studentTable.Columns.Add("ACCTEMP", System.Type.GetType("System.String"));
            _studentTable.Columns.Add("ACCESSION", System.Type.GetType("System.String"));
  
        } //--------------------------

        //this procedure imports student data from an XML file
        private void ImportStudentDataFromXml()
        {
            try
            {
                using (OpenFileDialog frmOpen = new OpenFileDialog())
                {
                    frmOpen.Title = "Select an XML file";
                    frmOpen.Filter = "XML Files (*.xml) | *.xml";
                    frmOpen.Multiselect = false;
                    frmOpen.CheckFileExists = true;
                    frmOpen.CheckPathExists = true;

                    //determines if an xml file has been selected
                    if (frmOpen.ShowDialog() == DialogResult.OK)
                    {
                        this.Cursor = Cursors.WaitCursor;

                        _studentTable.Clear();
                        _studentTable.ReadXml(frmOpen.FileName);

                        this.dgvList.DataSource = null;
                        this.dgvList.DataSource = _studentTable;

                        this.btnExport.Enabled = true;

                        
                    } //---------------------------
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in importing: " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }


        } //--------------------------------

        //this procedure sets the datagridview behavior
        private void SetDataGridViewBehavior(Int32 rowCount)
        {
            this.dgvList.Rows[rowCount].Selected = true;
            this.dgvList.FirstDisplayedScrollingRowIndex = rowCount;

            this.dgvList.Refresh();
            
        } //------------------------

        //this procedure exports the student data to the sql server
        private void ExportStudentDataToSqlServer()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;

                Int32 deniedCount = 0;
                Int32 successCount = 0;
                Int32 rowCount = 0;

                pgbImport.Step = 1;
                pgbImport.Maximum = this.dgvList.Rows.Count;

                foreach (DataRow studRow in _studentTable.Rows)
                {
                    this.SetDataGridViewBehavior(rowCount);

                    String studentId = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "ACCESSION", "");
                    String cardNumber = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "KEYWORDS", "");
                    String studentName = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "TITLE0", "");

                    if (!this.IsExistStudentIdStudentInformation(_userInfo, studentId, "") &&
                        !this.IsExistCardNumberStudentInformation(_userInfo, cardNumber, "") &&
                        !String.Equals("(blank)", studentName) &&
                        !String.IsNullOrEmpty(RemoteClient.ProcStatic.TrimStartEndString(cardNumber)) &&
                        !String.IsNullOrEmpty(RemoteClient.ProcStatic.TrimStartEndString(studentId)))
                    {

                        String remarks = RemoteServerLib.ProcStatic.DataRowConvert(studRow, "REMARKS", "");

                        CommonExchange.Student studentInfo = new CommonExchange.Student();

                        studentInfo.ObjectState = DataRowState.Added;
                        studentInfo.PersonInfo.ObjectState = DataRowState.Added;
                        
                        StudentName studName = this.GetStudentNameDetails(studentName);
                        RemarksDetails remarkInfo = this.GetRemarksDetails(remarks);

                        studentInfo.StudentId = RemoteClient.ProcStatic.TrimStartEndString(studentId);
                        studentInfo.PersonInfo.LastName = studName.LastName;
                        studentInfo.PersonInfo.FirstName = studName.FirstName;
                        studentInfo.CardNumber = cardNumber;
                        studentInfo.Scholarship = studName.Scholoarship;
                        studentInfo.CourseInfo.CourseId = this.GetCourseId(remarkInfo.CourseName);
                        studentInfo.PersonInfo.OtherPersonInformation = remarkInfo.OtherInformation;
                        studentInfo.PersonInfo.BirthDate = String.Empty;                        

                        if (!String.IsNullOrEmpty(_imagePath) && this.chkImage.Checked)
                        {
                            StudentImage imageInfo = this.GetStudentImageDetails(studentId);

                            if (!String.IsNullOrEmpty(imageInfo.ImagePath))
                            {
                                studentInfo.PersonInfo.FilePath = imageInfo.ImagePath;
                                studentInfo.PersonInfo.FileData = RemoteClient.ProcStatic.GetFileArrayBytes(imageInfo.ImagePath);
                                studentInfo.PersonInfo.FileExtension = imageInfo.ImageExtension;
                                studentInfo.PersonInfo.FileName = Path.GetFileName(imageInfo.ImagePath);

                                this.txtDirectory.Text = imageInfo.ImagePath;                                
                            }
                        }

                        using (RemoteClient.RemCntStudentManager remClient = new RemoteClient.RemCntStudentManager())
                        {
                            remClient.InsertStudentInformation(_userInfo, ref studentInfo);
                        }

                        using (RemoteClient.RemCntIdMakerManager remClient = new RemoteClient.RemCntIdMakerManager())
                        {
                            remClient.UpdateForIdMakerStudentInformation(_userInfo, studentInfo);
                        }

                        successCount++;
                    }
                    else
                    {
                        deniedCount++;
                    }
                    
                    pgbImport.PerformStep();

                    rowCount++;

                    Application.DoEvents();
                    this.Refresh();
                }

                MessageBox.Show("Student data has been successfully exported to the SQL Server" + "\n\nSuccess: " + successCount.ToString() + " Record(s)" +
                    "\nDenied: " + deniedCount.ToString() + " Record(s)", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

                pgbImport.Value = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error in exporting: " + ex.Message, "Error");
            }
            finally
            {
                this.Cursor = Cursors.Arrow;
            }

        } //--------------------------------------

        #endregion

        #region Programmer-Defined Function Procedures

        //this function gets the student image details
        private StudentImage GetStudentImageDetails(String studentId)
        {
            StudentImage imageInfo = new StudentImage();

            DirectoryInfo dirInfo = new DirectoryInfo(_imagePath);
            FileInfo[] fileInfo = dirInfo.GetFiles(studentId + "*", SearchOption.AllDirectories);

            foreach (FileInfo fi in fileInfo)
            {
                if (String.Equals(fi.Name.Substring(0, fi.Name.Length - fi.Extension.Length), studentId))
                {
                    imageInfo.ImagePath = fi.FullName;
                    imageInfo.ImageExtension = fi.Extension;
                    break;
                }
            }

            return imageInfo;
        } //-------------------------------------

        //this function returns the course id
        private String GetCourseId(String courseName)
        {
            String courseId = "";

            if (!String.IsNullOrEmpty(courseName))
            {
                courseName = courseName.ToUpper();
            }

            if (String.IsNullOrEmpty(courseName))
            {
                courseId = "CRSE001";
            }
            else if (String.Equals(courseName, "DPA"))
            {
                courseId = "CRSE002";
            }
            else if (String.Equals(courseName, "DBA"))
            {
                courseId = "CRSE003";
            }
            else if (String.Equals(courseName, "ED.D"))
            {
                courseId = "CRSE004";
            }
            else if (String.Equals(courseName, "MA"))
            {
                courseId = "CRSE005";
            }
            else if (String.Equals(courseName, "MBA"))
            {
                courseId = "CRSE006";
            }
            else if (String.Equals(courseName, "MIT"))
            {
                courseId = "CRSE007";
            }
            else if (String.Equals(courseName, "MPA"))
            {
                courseId = "CRSE008";
            }
            else if (String.Equals(courseName, "MRED"))
            {
                courseId = "CRSE009";
            }
            else if (String.Equals(courseName, "MSN"))
            {
                courseId = "CRSE010";
            }
            else if (String.Equals(courseName, "DPM"))
            {
                courseId = "CRSE011";
            }
            else if (String.Equals(courseName, "BSCS"))
            {
                courseId = "CRSE012";
            }
            else if (String.Equals(courseName, "BSIT"))
            {
                courseId = "CRSE013";
            }
            else if (String.Equals(courseName, "BSA"))
            {
                courseId = "CRSE014";
            }
            else if (String.Equals(courseName, "BSN"))
            {
                courseId = "CRSE015";
            }
            else if (String.Equals(courseName, "BSIME"))
            {
                courseId = "CRSE016";
            }
            else if (String.Equals(courseName, "BST"))
            {
                courseId = "CRSE017";
            }
            else if (String.Equals(courseName, "BSHRM"))
            {
                courseId = "CRSE018";
            }
            else if (String.Equals(courseName, "BBA"))
            {
                courseId = "CRSE019";
            }
            else if (String.Equals(courseName, "AB"))
            {
                courseId = "CRSE020";
            }
            else if (String.Equals(courseName, "BSED"))
            {
                courseId = "CRSE021";
            }
            else if (String.Equals(courseName, "BEED"))
            {
                courseId = "CRSE022";
            }
            else if (String.Equals(courseName, "ACS"))
            {
                courseId = "CRSE023";
            }
            else if (String.Equals(courseName, "HS") || String.Equals(courseName, "HIGH SCHOOL"))
            {
                courseId = "CRSE024";
            }
            else if (String.Equals(courseName, "GS") || String.Equals(courseName, "ELEM") || String.Equals(courseName, "GRADE SCHOOL"))
            {
                courseId = "CRSE025";
            }
            else if (String.Equals(courseName, "KN") || String.Equals(courseName, "KINDER") || String.Equals(courseName, "KII") ||
           String.Equals(courseName, "KI") || String.Equals(courseName, "NURSERY"))
            {
                courseId = "CRSE026";
            }
            else
            {
                courseId = "CRSE001";
            }


            return courseId;
        } //---------------------------

        //this function returns the remarks details
        private RemarksDetails GetRemarksDetails(String remarks)
        {
            RemarksDetails remarkInfo = new RemarksDetails();

            if (!String.IsNullOrEmpty(remarks))
            {
                remarks = RemoteClient.ProcStatic.TrimStartEndString(remarks);

                Int32 indexCourse = remarks.IndexOf("Course", 0);

                if (indexCourse == -1)
                {
                    remarkInfo.CourseName = "";
                    remarkInfo.OtherInformation = "";
                }
                else
                {
                    String[] splitString = remarks.Split(":\r\n".ToCharArray());

                    for (Int32 i = 0; i <= splitString.Length - 1; i++)
                    {
                        String strTemp = splitString[i];

                        if (i == 0)
                        {
                            continue;
                        }
                        else if (i == 1)
                        {
                            remarkInfo.CourseName = RemoteClient.ProcStatic.TrimStartEndString(strTemp);
                            continue;
                        }
                        else if (String.Equals("COURSE", strTemp.ToUpper()) ||
                            String.Equals("YEAR", strTemp.ToUpper()) ||
                            String.Equals("SEX", strTemp.ToUpper()) ||
                            String.Equals("STATUS", strTemp.ToUpper()) ||
                            String.Equals("SECTION", strTemp.ToUpper()) ||
                            String.Equals("OLD/NEW", strTemp.ToUpper()))
                        {
                            strTemp += ": ";
                        }
                        else if (!String.IsNullOrEmpty(strTemp))
                        {
                            strTemp += "\n";
                        }

                        if (!String.IsNullOrEmpty(strTemp))
                        {
                            remarkInfo.OtherInformation += strTemp;
                        }

                    }
                }
                
            }     
       

            return remarkInfo;
        } //------------------------------

        //this function returns the student name details
        private StudentName GetStudentNameDetails(String studentName)
        {
            if (!String.IsNullOrEmpty(studentName))
            {
                studentName = RemoteClient.ProcStatic.TrimStartEndString(studentName);
            }

            StudentName studInfo = new StudentName();

            String[] splitString = studentName.Split(",(".ToCharArray());

            if (splitString.Length == 1)
            {
                String[] tempString = studentName.Split(" ".ToCharArray());

                for (Int32 i = 0; i <= tempString.Length - 1; i++)
                {
                    if (i == 0)
                    {
                        studInfo.LastName = this.SetFirstLetterToUpper(RemoteClient.ProcStatic.TrimStartEndString(tempString[i]));
                    }
                    else
                    {
                        studInfo.FirstName += this.SetFirstLetterToUpper(tempString[i]) + " ";
                    }
                }

                studInfo.FirstName = RemoteClient.ProcStatic.TrimStartEndString(studInfo.FirstName);
            }
            else
            {
                for (Int32 i = 0; i <= splitString.Length - 1; i++)
                {
                    if (i == 0)
                    {
                        studInfo.LastName = this.SetFirstLetterToUpper(RemoteClient.ProcStatic.TrimStartEndString(splitString[i]));
                    }
                    else if (i == 1)
                    {
                        studInfo.FirstName = this.SetFirstLetterToUpper(RemoteClient.ProcStatic.TrimStartEndString(splitString[i]));
                    }
                    else
                    {
                        String temp = RemoteClient.ProcStatic.TrimStartEndString(splitString[i]);

                        if (temp.Length > 0)
                        {
                            studInfo.Scholoarship += temp.Substring(0, temp.Length - 1) + " ";
                        }                        
                    }
                }

                if (!String.IsNullOrEmpty(studInfo.Scholoarship))
                {
                    studInfo.Scholoarship = RemoteClient.ProcStatic.TrimStartEndString(studInfo.Scholoarship);
                }

            }            

            return studInfo;
        }//--------------------------

        private String SetFirstLetterToUpper(String strBase)
        {
            StringBuilder strBlock = new StringBuilder();
            Boolean forUpper = false;
            Boolean isWhiteSpace = false;

            for (Int32 i = 0; i <= strBase.Length - 1; i++)
            {
                if (i == 0 || (forUpper && strBase[i] != ' '))
                {
                    strBlock.Append(strBase[i].ToString().ToUpper());
                    forUpper = false;
                    isWhiteSpace = false;
                }
                else if (strBase[i] == ' ' && !isWhiteSpace)
                {
                    strBlock.Append(strBase[i]);
                    forUpper = true;
                    isWhiteSpace = true;
                }
                else if (!isWhiteSpace)
                {
                    strBlock.Append(strBase[i].ToString().ToLower());
                    isWhiteSpace = false;
                }
            }

            return strBlock.ToString();
        }

        //this function is used to determine if the student id exists
        private Boolean IsExistStudentIdStudentInformation(CommonExchange.SysAccess userInfo, String studentId, String studentSysId)
        {
            Boolean isExist = false;

            using (RemoteClient.RemCntStudentManager remClient = new RemoteClient.RemCntStudentManager())
            {
                isExist = remClient.IsExistsStudentIdStudentInformation(userInfo, studentId, studentSysId);
            }

            return isExist;
        } //-------------------------------

        //this function is used to determine if the student card number exists
        private Boolean IsExistCardNumberStudentInformation(CommonExchange.SysAccess userInfo, String cardNumber, String studentSysId)
        {
            Boolean isExist = false;

            using (RemoteClient.RemCntIdMakerManager remClient = new RemoteClient.RemCntIdMakerManager())
            {
                isExist = remClient.IsExistsCardNumberStudentInformation(userInfo, cardNumber, studentSysId);
            }

            return isExist;
        } //------------------------------

        #endregion
    }
}
