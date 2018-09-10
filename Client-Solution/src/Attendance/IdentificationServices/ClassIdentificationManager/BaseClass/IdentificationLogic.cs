using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Collections;

namespace IdentificationServices
{
    internal class IdentificationLogic
    {
        #region Class General Variable Declaration
        private DataTable _studentEmployeeTable;
        #endregion

        #region Class Properties Declarations
        private String _serverDateTime;
        public String ServerDateTime
        {
            get { return _serverDateTime; }
        }

        #endregion

        #region Class Constructor
        public IdentificationLogic(CommonExchange.SysAccess userInfo)
        {
            this.InitializeClass(userInfo);
        }
        #endregion

        #region Programer-Defined Void Procedures

        //this procedure deletes the image directory
        public void DeleteImageDirectory(String imagePath)
        {
            RemoteClient.ProcStatic.DeleteDirectory(imagePath);
        } //--------------------

        //this procedure will initialize class
        public void InitializeClass(CommonExchange.SysAccess userInfo)
        {
            //get the server Date and Time
            using (RemoteClient.RemCntBaseManager remClient = new RemoteClient.RemCntBaseManager())
            {
                _serverDateTime = remClient.GetServerDateTime(userInfo);
            }
        }//-----------------------------
        #endregion

        #region Programer-Define Void Procedures

        //this procedure will Update Employee Information
        public void UpdateForIdMakerEmployeeInformation(CommonExchange.SysAccess userInfo, CommonExchange.Employee employeeInfo)
        {
            using (RemoteClient.RemCntIdMakerManager remClient = new RemoteClient.RemCntIdMakerManager())
            {
                remClient.UpdateForIdMakerEmployeeInformation(userInfo, employeeInfo);
            }

            EditStudentEmployeeDataTable(null, employeeInfo, this.IsStudent(employeeInfo.EmployeeId));
        }//-----------------

        //this procedure will Update Student Information
        public void UpdateForIdMakerStudentInformation(CommonExchange.SysAccess userInfo, CommonExchange.Student studentInfo)
        {
            using (RemoteClient.RemCntIdMakerManager remClient = new RemoteClient.RemCntIdMakerManager())
            {
                remClient.UpdateForIdMakerStudentInformation(userInfo, studentInfo);
            }

            EditStudentEmployeeDataTable(studentInfo, null, this.IsStudent(studentInfo.StudentId));
        }//--------------------------

        //this procedure will Edit StudentEmployee Data Table
        private void EditStudentEmployeeDataTable(CommonExchange.Student studentInfo, CommonExchange.Employee employeeInfo, Boolean isStudent)
        {
            if (_studentEmployeeTable != null)
            {
                Int32 index = 0;

                foreach (DataRow studentRow in _studentEmployeeTable.Rows)
                {
                    if (isStudent && String.Equals(studentInfo.StudentSysId, 
                        RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "sysid_student_employee", String.Empty)))
                    {
                        DataRow editRow = _studentEmployeeTable.Rows[index];

                        editRow.BeginEdit();

                        editRow["sysid_student_employee"] = studentInfo.StudentSysId;
                        editRow["student_employee_id"] = studentInfo.StudentId;
                        editRow["card_number"] = studentInfo.CardNumber;
                        editRow["last_name"] = studentInfo.PersonInfo.LastName;
                        editRow["first_name"] = studentInfo.PersonInfo.FirstName;
                        editRow["middle_name"] = studentInfo.PersonInfo.MiddleName;
                        editRow["present_address"] = studentInfo.PersonInfo.PresentAddress;
                        editRow["course_title_department_name"] = studentInfo.CourseInfo.CourseTitle;
                        editRow["acronym_employment_type"] = studentInfo.CourseInfo.Acronym;

                        CommonExchange.PersonRelationship personRelationship = this.GetPersonEmergencyContact(studentInfo.PersonInfo.PersonRelationshipList);

                        editRow["emer_last_name"] = personRelationship.PersonInRelationshipWith.LastName;
                        editRow["emer_first_name"] = personRelationship.PersonInRelationshipWith.FirstName;
                        editRow["emer_middle_name"] = personRelationship.PersonInRelationshipWith.MiddleName;
                        editRow["emer_present_address"] = personRelationship.PersonInRelationshipWith.PresentAddress;
                        editRow["emer_present_phone_nos"] = personRelationship.PersonInRelationshipWith.PresentPhoneNos;
                        editRow["emer_relationship_description"] = personRelationship.RelationshipTypeInfo.RelationshipDescription;

                        editRow["is_student"] = true;

                        editRow.EndEdit();

                        break;
                    }
                    else if (!isStudent && String.Equals(employeeInfo.EmployeeSysId,
                        RemoteServerLib.ProcStatic.DataRowConvert(studentRow, "sysid_student_employee", String.Empty)))
                    {
                        DataRow editRow = _studentEmployeeTable.Rows[index];

                        editRow.BeginEdit();

                        editRow["sysid_student_employee"] = employeeInfo.EmployeeSysId;
                        editRow["student_employee_id"] = employeeInfo.EmployeeId;
                        editRow["card_number"] = employeeInfo.CardNumber;
                        editRow["last_name"] = employeeInfo.PersonInfo.LastName;
                        editRow["first_name"] = employeeInfo.PersonInfo.FirstName;
                        editRow["middle_name"] = employeeInfo.PersonInfo.MiddleName;
                        editRow["present_address"] = employeeInfo.PersonInfo.PresentAddress;
                        editRow["course_title_department_name"] = employeeInfo.SalaryInfo.DepartmentInfo.DepartmentName;
                        editRow["acronym_employment_type"] = employeeInfo.SalaryInfo.DepartmentInfo.Acronym;

                        CommonExchange.PersonRelationship personRelationship = this.GetPersonEmergencyContact(employeeInfo.PersonInfo.PersonRelationshipList);

                        editRow["emer_last_name"] = personRelationship.PersonInRelationshipWith.LastName;
                        editRow["emer_first_name"] = personRelationship.PersonInRelationshipWith.FirstName;
                        editRow["emer_middle_name"] = personRelationship.PersonInRelationshipWith.MiddleName;
                        editRow["emer_present_address"] = personRelationship.PersonInRelationshipWith.PresentAddress;
                        editRow["emer_present_phone_nos"] = personRelationship.PersonInRelationshipWith.PresentPhoneNos;
                        editRow["emer_relationship_description"] = personRelationship.RelationshipTypeInfo.RelationshipDescription;

                        editRow["is_student"] = false;

                        editRow.EndEdit();

                        break;
                    }

                    index++;
                }

                _studentEmployeeTable.AcceptChanges();
            }
        }//-----------------

        #endregion

        #region Programer-Define Function Procedures

        //this funtion gets the select Employee or Student
        public DataTable GetSearchEmployeeStudentInformation(CommonExchange.SysAccess userInfo, String queryString,
            Boolean isNewQuery)
        {
            if (isNewQuery)
            {
                using (RemoteClient.RemCntIdMakerManager remClient = new RemoteClient.RemCntIdMakerManager())
                {
                    _studentEmployeeTable = remClient.SelectByQueryStringStudentEmployeeInformation(userInfo, queryString, true);
                }
            }

            DataTable newTable = new DataTable("EmployeeStudentSearchByNameID");
            newTable.Columns.Add("student_employee_id", System.Type.GetType("System.String"));
            newTable.Columns.Add("student_employee_name", System.Type.GetType("System.String"));
            newTable.Columns.Add("card_number", System.Type.GetType("System.String"));
            newTable.Columns.Add("acronym", System.Type.GetType("System.String"));
            newTable.Columns.Add("course_title_department_name", System.Type.GetType("System.String"));
            newTable.Columns.Add("present_address", System.Type.GetType("System.String"));
            newTable.Columns.Add("present_phone_nos", System.Type.GetType("System.String"));

            if (_studentEmployeeTable != null)
            {
                foreach (DataRow row in _studentEmployeeTable.Rows)
                {
                    DataRow newRow = newTable.NewRow();

                    newRow["student_employee_id"] = RemoteServerLib.ProcStatic.DataRowConvert(row, "student_employee_id", "");
                    newRow["student_employee_name"] = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(row, "last_name", "first_name", "middle_name");
                    newRow["card_number"] = RemoteServerLib.ProcStatic.DataRowConvert(row, "card_number", "");
                    newRow["acronym"] = RemoteServerLib.ProcStatic.DataRowConvert(row, "acronym_employment_type", "");
                    newRow["course_title_department_name"] = RemoteServerLib.ProcStatic.DataRowConvert(row, "course_title_department_name", String.Empty);
                    newRow["present_address"] = RemoteServerLib.ProcStatic.DataRowConvert(row, "present_address", String.Empty);
                    newRow["present_phone_nos"] = RemoteServerLib.ProcStatic.DataRowConvert(row, "present_phone_nos", String.Empty);

                    newTable.Rows.Add(newRow);
                }
                
            }

            newTable.AcceptChanges();
            
            return newTable;
        }//------------------

        //this fucntion will returns Student Detailss
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
                studentInfo.PersonInfo.LastName = RemoteServerLib.ProcStatic.DataRowConvert(row, "last_name", "");
                studentInfo.PersonInfo.FirstName = RemoteServerLib.ProcStatic.DataRowConvert(row, "first_name", "");
                studentInfo.PersonInfo.MiddleName = RemoteServerLib.ProcStatic.DataRowConvert(row, "middle_name", "");
                studentInfo.PersonInfo.PresentAddress = RemoteServerLib.ProcStatic.DataRowConvert(row, "present_address", "");
                studentInfo.CourseInfo.CourseTitle = RemoteServerLib.ProcStatic.DataRowConvert(row, "course_title_department_name", "");
                studentInfo.CourseInfo.Acronym = RemoteServerLib.ProcStatic.DataRowConvert(row, "acronym_employment_type", "");
                studentInfo.PersonInfo.PersonSysId = RemoteServerLib.ProcStatic.DataRowConvert(row, "sysid_person", "");

                if (studentInfo.PersonInfo.PersonRelationshipList.Count < 1)
                {
                    CommonExchange.PersonRelationship personRelationshipInfo = new CommonExchange.PersonRelationship();

                    personRelationshipInfo.IsEmergencyContact = true;
                    personRelationshipInfo.PersonInRelationshipWith.LastName = RemoteServerLib.ProcStatic.DataRowConvert(row, "emer_last_name", "");
                    personRelationshipInfo.PersonInRelationshipWith.FirstName = RemoteServerLib.ProcStatic.DataRowConvert(row, "emer_first_name", "");
                    personRelationshipInfo.PersonInRelationshipWith.MiddleName = RemoteServerLib.ProcStatic.DataRowConvert(row, "emer_middle_name", "");
                    personRelationshipInfo.PersonInRelationshipWith.PresentAddress = RemoteServerLib.ProcStatic.DataRowConvert(row, "emer_present_address", "");
                    personRelationshipInfo.PersonInRelationshipWith.PresentPhoneNos = RemoteServerLib.ProcStatic.DataRowConvert(row, "emer_present_phone_nos", "");
                    personRelationshipInfo.PersonInRelationshipWith.HomeAddress = RemoteServerLib.ProcStatic.DataRowConvert(row, "emer_home_address", "");
                    personRelationshipInfo.PersonInRelationshipWith.HomePhoneNos = RemoteServerLib.ProcStatic.DataRowConvert(row, "emer_home_phone_nos", "");
                    personRelationshipInfo.RelationshipTypeInfo.RelationshipDescription =
                        RemoteServerLib.ProcStatic.DataRowConvert(row, "emer_relationship_description", "");

                    studentInfo.PersonInfo.PersonRelationshipList.Add(personRelationshipInfo);
                }
                              
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
                employeeInfo.PersonInfo.LastName = RemoteServerLib.ProcStatic.DataRowConvert(row, "last_name", "");
                employeeInfo.PersonInfo.FirstName = RemoteServerLib.ProcStatic.DataRowConvert(row, "first_name", "");
                employeeInfo.PersonInfo.MiddleName = RemoteServerLib.ProcStatic.DataRowConvert(row, "middle_name", "");
                employeeInfo.PersonInfo.PresentAddress = RemoteServerLib.ProcStatic.DataRowConvert(row, "present_address", "");
                employeeInfo.SalaryInfo.DepartmentInfo.DepartmentName = RemoteServerLib.ProcStatic.DataRowConvert(row, "course_title_department_name", "");
                employeeInfo.SalaryInfo.DepartmentInfo.Acronym = RemoteServerLib.ProcStatic.DataRowConvert(row, "acronym_employment_type", "");
                employeeInfo.PersonInfo.PersonSysId = RemoteServerLib.ProcStatic.DataRowConvert(row, "sysid_person", "");

                if (employeeInfo.PersonInfo.PersonRelationshipList.Count < 1)
                {
                    CommonExchange.PersonRelationship personRelationshipInfo = new CommonExchange.PersonRelationship();

                    personRelationshipInfo.IsEmergencyContact = true;
                    personRelationshipInfo.PersonInRelationshipWith.LastName = RemoteServerLib.ProcStatic.DataRowConvert(row, "emer_last_name", "");
                    personRelationshipInfo.PersonInRelationshipWith.FirstName = RemoteServerLib.ProcStatic.DataRowConvert(row, "emer_first_name", "");
                    personRelationshipInfo.PersonInRelationshipWith.MiddleName = RemoteServerLib.ProcStatic.DataRowConvert(row, "emer_middle_name", "");
                    personRelationshipInfo.PersonInRelationshipWith.PresentAddress = RemoteServerLib.ProcStatic.DataRowConvert(row, "emer_present_address", "");
                    personRelationshipInfo.PersonInRelationshipWith.PresentPhoneNos = RemoteServerLib.ProcStatic.DataRowConvert(row, "emer_present_phone_nos", "");
                    personRelationshipInfo.PersonInRelationshipWith.HomeAddress = RemoteServerLib.ProcStatic.DataRowConvert(row, "emer_home_address", "");
                    personRelationshipInfo.PersonInRelationshipWith.HomePhoneNos = RemoteServerLib.ProcStatic.DataRowConvert(row, "emer_home_phone_nos", "");
                    personRelationshipInfo.RelationshipTypeInfo.RelationshipDescription =
                        RemoteServerLib.ProcStatic.DataRowConvert(row, "emer_relationship_description", "");

                    employeeInfo.PersonInfo.PersonRelationshipList.Add(personRelationshipInfo);
                }

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

        //this function will get person emergency contact
        public CommonExchange.PersonRelationship GetPersonEmergencyContact(List<CommonExchange.PersonRelationship> personRelationshipList)
        {
            CommonExchange.PersonRelationship personRelationshipInfo = new CommonExchange.PersonRelationship();

            foreach (CommonExchange.PersonRelationship list in personRelationshipList)
            {
                if (list.IsEmergencyContact)
                {
                    personRelationshipInfo = list;

                    break;
                }
            }

            return personRelationshipInfo;
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

        //this fucntion will determine if the card number is already exist
        public Boolean IsExistCardNumber(CommonExchange.SysAccess userInfo, String cardNumber, String id, Boolean isStudent)
        {
            Boolean value = false;

            if (isStudent)
            {
                using (RemoteClient.RemCntIdMakerManager remClient = new RemoteClient.RemCntIdMakerManager())
                {
                    value = remClient.IsExistsCardNumberStudentInformation(userInfo, cardNumber, id);
                }
            }
            else
            {
                using (RemoteClient.RemCntIdMakerManager remClient = new RemoteClient.RemCntIdMakerManager())
                {
                    value = remClient.IsExistsCardNumberEmployeeInformation(userInfo, cardNumber, id);
                }
            }

            return value;
        }//----------------------------
        
        #endregion
    }
}
