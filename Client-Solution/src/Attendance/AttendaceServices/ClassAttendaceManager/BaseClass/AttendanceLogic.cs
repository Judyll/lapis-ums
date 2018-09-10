using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Drawing;

namespace AttendaceServices
{
    internal class AttendanceLogic
    {
        #region Class Decleration
        private DataTable _studentEmployeeTable;
        #endregion

        #region Class Properties Decleration
        private String _serverDateTime;
        public String ServerDateTime
        {
            get { return _serverDateTime; }
        }

        public DataTable CampusAccessDetailsTable
        {
            get
            {
                DataTable newTable = new DataTable("CampusAccessDetailsTable");
				newTable.Columns.Add("access_date_time", System.Type.GetType("System.String"));
				newTable.Columns.Add("access_description", System.Type.GetType("System.String"));

                return newTable;
            }
        }
        #endregion  

        #region Class Constructors
        public AttendanceLogic(CommonExchange.SysAccess userInfo)
        {
            this.InitializeClass(userInfo);
        }//-------------------------
        #endregion

        #region Programmers Defined Functions
        public void InitializeClass(CommonExchange.SysAccess userInfo)
        {
            //get the server Date and Time
            using (RemoteClient.RemCntBaseManager remClient = new RemoteClient.RemCntBaseManager())
            {
                _serverDateTime = remClient.GetServerDateTime(userInfo);
            }//---------------------
        }//----------------------

        //this function will get searched employee student information
        public DataTable GetSearchedEmployeeStudentInformation(CommonExchange.SysAccess userInfo, String queryString, Boolean isNewQuery)
        {
            if (isNewQuery)
            {
                using (RemoteClient.RemCntCampusAccessManager remClient = new RemoteClient.RemCntCampusAccessManager())
                {
                    _studentEmployeeTable = remClient.SelectForCampusAccessStudentEmployeeInformation(userInfo, queryString);
                }

            }

            DataTable newTable = new DataTable("EmployeeStudentSearchByNameID");
            newTable.Columns.Add("student_employee_id", System.Type.GetType("System.String"));
            newTable.Columns.Add("student_employee_name", System.Type.GetType("System.String"));
            newTable.Columns.Add("card_number", System.Type.GetType("System.String"));        

            if (_studentEmployeeTable != null)
            {
                foreach (DataRow row in _studentEmployeeTable.Rows)
                {
                    DataRow newRow = newTable.NewRow();

                    newRow["student_employee_id"] = RemoteServerLib.ProcStatic.DataRowConvert(row, "student_employee_id", "");
                    newRow["student_employee_name"] = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(row, "last_name", "first_name", "middle_name");
                    newRow["card_number"] = RemoteServerLib.ProcStatic.DataRowConvert(row, "card_number", "");
               
                    newTable.Rows.Add(newRow);
                }
            }

            newTable.AcceptChanges();

            return newTable;
        }//-------------------------

        //this function will get searched campus access details information
        public DataTable GetSearchedCampusAccessDetails(CommonExchange.SysAccess userInfo, String personSysIdList,
            String dateStart, String dateEnd)
        {
            DataTable newTable = new DataTable("TemporaryTable");
            newTable.Columns.Add("access_date_time", System.Type.GetType("System.String"));
            newTable.Columns.Add("access_description", System.Type.GetType("System.String"));

            DataTable tempTable;

            using (RemoteClient.RemCntCampusAccessManager remClient = new RemoteClient.RemCntCampusAccessManager())
            {
                tempTable = remClient.SelectByPersonSysIDListDateStartEndCampusAccessDetails(userInfo, personSysIdList, dateStart, dateEnd);
            }

            if (tempTable != null)
            {
                foreach (DataRow accessRow in tempTable.Rows)
                {
                    DataRow newRow = newTable.NewRow();

                    DateTime accessDate = DateTime.MinValue;

                    newRow["access_date_time"] =
                        DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(accessRow, "access_date_time", String.Empty), out accessDate) ?
                        accessDate.ToLongDateString() + " - " + accessDate.ToLongTimeString() : String.Empty;

                    newRow["access_description"] = RemoteServerLib.ProcStatic.DataRowConvert(accessRow, "access_description", String.Empty); 

                    newTable.Rows.Add(newRow);
                }
            }

            return newTable;
        }//-------------------------

        //this fucntion will returns Student Details
        public CommonExchange.Student GetDetailsStudentInformation(CommonExchange.SysAccess userInfo, String studentEmployeeId, String startUp)
        {

            CommonExchange.Student studentInfo = new CommonExchange.Student();

            String strFilter = "student_employee_id = '" + studentEmployeeId + "'";
            DataRow[] selectRow = _studentEmployeeTable.Select(strFilter, "student_employee_id ASC");

            foreach (DataRow row in selectRow)
            {
                studentInfo.StudentSysId = RemoteServerLib.ProcStatic.DataRowConvert(row, "sysid_student_employee", "");
                studentInfo.StudentId = RemoteServerLib.ProcStatic.DataRowConvert(row, "student_employee_id", "");
                studentInfo.CardNumber = RemoteServerLib.ProcStatic.DataRowConvert(row, "card_number", "");
                studentInfo.PersonInfo.PersonSysId = RemoteServerLib.ProcStatic.DataRowConvert(row, "sysid_person", "");
                studentInfo.PersonInfo.LastName = RemoteServerLib.ProcStatic.DataRowConvert(row, "last_name", "");
                studentInfo.PersonInfo.FirstName = RemoteServerLib.ProcStatic.DataRowConvert(row, "first_name", "");
                studentInfo.PersonInfo.MiddleName = RemoteServerLib.ProcStatic.DataRowConvert(row, "middle_name", "");

                break;
            }

            studentInfo.PersonInfo.FilePath = this.GetPersonImagePath(userInfo, studentInfo.PersonInfo.PersonSysId,
                studentInfo.PersonInfo.PersonImagesFolder(startUp));

            return studentInfo;
        }//------------------------

        //this fucntion will returns Employee Details
        public CommonExchange.Employee GetDetailsEmployeeInformation(CommonExchange.SysAccess userInfo, String studentEmployeeId, String startUp)
        {

            CommonExchange.Employee employeeInfo = new CommonExchange.Employee();

            String strFilter = "student_employee_id = '" + studentEmployeeId + "'";
            DataRow[] selectRow = _studentEmployeeTable.Select(strFilter, "student_employee_id ASC");

            foreach (DataRow row in selectRow)
            {
                employeeInfo.EmployeeSysId = RemoteServerLib.ProcStatic.DataRowConvert(row, "sysid_student_employee", "");
                employeeInfo.EmployeeId = RemoteServerLib.ProcStatic.DataRowConvert(row, "student_employee_id", "");
                employeeInfo.CardNumber = RemoteServerLib.ProcStatic.DataRowConvert(row, "card_number", "");
                employeeInfo.PersonInfo.PersonSysId = RemoteServerLib.ProcStatic.DataRowConvert(row, "sysid_person", "");
                employeeInfo.PersonInfo.LastName = RemoteServerLib.ProcStatic.DataRowConvert(row, "last_name", "");
                employeeInfo.PersonInfo.FirstName = RemoteServerLib.ProcStatic.DataRowConvert(row, "first_name", "");
                employeeInfo.PersonInfo.MiddleName = RemoteServerLib.ProcStatic.DataRowConvert(row, "middle_name", "");
                               
                break;
            }

            employeeInfo.PersonInfo.FilePath = this.GetPersonImagePath(userInfo, employeeInfo.PersonInfo.PersonSysId,
                employeeInfo.PersonInfo.PersonImagesFolder(startUp));

            return employeeInfo;
        }//------------------------

        //this fucntion will determine if the person is student or employee
        public Boolean IsStudent(String studentEmployeeId)
        {
            Boolean value = false;

            if (_studentEmployeeTable != null)
            {
                String strFilter = "student_employee_id = '" + studentEmployeeId + "'";
                DataRow[] selectRow = _studentEmployeeTable.Select(strFilter, "student_employee_id ASC");

                foreach (DataRow row in selectRow)
                {
                    value = RemoteServerLib.ProcStatic.DataRowConvert(row, "is_student", true);

                    break;
                }
            }

            return value;
        }//--------------------------

        //this function gets the student image path
        public String GetPersonImagePath(CommonExchange.SysAccess userInfo, String personSysIdList, String imagePath)
        {
            RemoteClient.ProcStatic.DeleteDirectory(imagePath);

            //creates the directory
            DirectoryInfo dirInfo = new DirectoryInfo(imagePath);
            dirInfo.Create();
            dirInfo.Attributes = FileAttributes.Hidden;

            DataTable imageTable;

            using (RemoteClient.RemCntBaseManager remClient = new RemoteClient.RemCntBaseManager())
            {
                imageTable = remClient.SelectPersonImagesPersonInformation(userInfo, personSysIdList);
            }

            using (DataTableReader tableReader = new DataTableReader(imageTable))
            {
                if (tableReader.HasRows)
                {
                    Int32 picColumn = 1;

                    while (tableReader.Read())
                    {
                        if (!tableReader.IsDBNull(picColumn))
                        {
                            imagePath += tableReader["original_name"].ToString();

                            long len = tableReader.GetBytes(picColumn, 0, null, 0, 0);
                            // Create a buffer to hold the bytes, and then
                            // read the bytes from the DataTableReader.
                            Byte[] buffer = new Byte[len];
                            tableReader.GetBytes(picColumn, 0, buffer, 0, (int)len);

                            // Create a new Bitmap object, passing the array 
                            // of bytes to the constructor of a MemoryStream.
                            using (Bitmap studentImage = new Bitmap(new MemoryStream(buffer)))
                            {
                                studentImage.Save(imagePath);
                            }
                        }
                    }
                }
                else
                {
                    imagePath = null;
                }

                tableReader.Close();
            }

            return imagePath;
        } //------------------------------       

        //this function returns the extension name of the file
        public String GetImageExtensionName(String imagePath)
        {
            String strExt = "";

            if (File.Exists(imagePath))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(imagePath);
                strExt = dirInfo.Extension;
            }

            return strExt;
        } //----------------------------------
        #endregion

    }
}
