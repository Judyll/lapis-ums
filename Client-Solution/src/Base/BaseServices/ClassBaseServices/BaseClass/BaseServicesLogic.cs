using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BaseServices
{
    public class BaseServicesLogic
    {
        #region Class Data Member Declaration
        private DataSet _classDataSet;
        private DataTable _personTable;
        #endregion

        #region Class Properties Declaration
        private static Int32 _receiptNumber = 0;
        public static Int32 ReceiptNumber
        {
            get { return _receiptNumber; }
            set { _receiptNumber = value; }
        }

        private static String _receiptDate;
        public static String ReceiptDate
        {
            get { return _receiptDate; }
            set { _receiptDate = value; }
        }

        private static CommonExchange.ChartOfAccount _chartOfAccountInfo = new CommonExchange.ChartOfAccount();
        public static CommonExchange.ChartOfAccount ChartOfAccountInformation
        {
            get { return _chartOfAccountInfo; }
            set { _chartOfAccountInfo = value; }
        }

        private CommonExchange.ChartOfAccount _miscellaneousChartOfAccountInfo = new CommonExchange.ChartOfAccount();
        public CommonExchange.ChartOfAccount MiscellaneousChartOfAccountInfo
        {
            get { return _miscellaneousChartOfAccountInfo; }
            set { _miscellaneousChartOfAccountInfo = value; }
        }

        protected String _serverDateTime;
        public String ServerDateTime
        {
            get { return _serverDateTime; }
        }        

        public DataTable PersonTable
        {
            get
            {
                DataTable newTable = new DataTable("PersonTable");
                newTable.Columns.Add("person_name", System.Type.GetType("System.String"));
                newTable.Columns.Add("birthdate", System.Type.GetType("System.String"));
                newTable.Columns.Add("present_address", System.Type.GetType("System.String"));
                newTable.Columns.Add("present_phone_nos", System.Type.GetType("System.String"));
                newTable.Columns.Add("life_status_code_code_description", System.Type.GetType("System.String"));
                newTable.Columns.Add("gender_code_code_description", System.Type.GetType("System.String"));

                return newTable;

            }
        }

        public DataTable PersonRelationshipTable
        {
            get
            {
                DataTable newTable = new DataTable("PersonRelationshipTable");
                newTable.Columns.Add("relationship_id", System.Type.GetType("System.String"));
                newTable.Columns.Add("person_name", System.Type.GetType("System.String"));
                newTable.Columns.Add("relationship_description", System.Type.GetType("System.String"));
                newTable.Columns.Add("birthdate", System.Type.GetType("System.String"));
                newTable.Columns.Add("present_address", System.Type.GetType("System.String"));
                newTable.Columns.Add("present_phone_nos", System.Type.GetType("System.String"));
                newTable.Columns.Add("life_status_code_code_description", System.Type.GetType("System.String"));
                newTable.Columns.Add("gender_code_code_description", System.Type.GetType("System.String"));

                return newTable;
            }
        }

        private Int64 _relationshipIdCount = 0;
        public Int64 RelationshipIdCount
        {
            get { return _relationshipIdCount; }
            set { _relationshipIdCount = value; }
        }

        #endregion

        #region Class Constructors
        public BaseServicesLogic()
        {
        }

        public BaseServicesLogic(CommonExchange.SysAccess userInfo)
        {
            //get the server date and time and class dataset
            using (RemoteClient.RemCntBaseManager remClient = new RemoteClient.RemCntBaseManager())
            {
                _serverDateTime = remClient.GetServerDateTime(userInfo);

                _classDataSet = remClient.GetDataSetForBaseServices(userInfo);
            }//---------------------          
        }
        #endregion

        #region Programmer-Defined Void Procedures
        //this procedure will insert update personal information
        public void InsertUpdatePersonInformation(CommonExchange.SysAccess userInfo, ref CommonExchange.Person personInfo)
        {
            using (RemoteClient.RemCntBaseManager remClient = new RemoteClient.RemCntBaseManager())
            {
                remClient.InsertUpdatePersonInformation(userInfo, ref personInfo);
            }      
        }//--------------------------

        //this procedure will initialize code reference combo
        public void InitializeCodeReferenceCombo(ComboBox cboBase, String codeEntityId)
        {
            cboBase.Items.Clear();

            String strFilter = "code_entity_id = '" + codeEntityId + "'";
            DataRow[] selectRow = _classDataSet.Tables["CodeReferenceTable"].Select(strFilter);

            foreach (DataRow codeRow in selectRow)
            {
                cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(codeRow, "code_description", ""));
            }

            cboBase.SelectedIndex = -1;
        }//----------------------------

        //this procedure will initialize code reference combo
        public void InitializeCodeReferenceCombo(ComboBox cboBase, String codeEntityId, String codeReferenceId)
        {
            cboBase.Items.Clear();

            String strFilter = "code_entity_id = '" + codeEntityId + "'";
            DataRow[] selectRow = _classDataSet.Tables["CodeReferenceTable"].Select(strFilter);
            Int32 index = 0;

            foreach (DataRow codeRow in selectRow)
            {
                cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(codeRow, "code_description", ""));

                if (String.Equals(codeReferenceId, RemoteServerLib.ProcStatic.DataRowConvert(codeRow, "code_reference_id", "")))
                {
                    cboBase.SelectedIndex = index;
                }

                index++;
            }
        }//-----------------------------

        //this procedure will initialize person relationship type combo
        public void InitializePersonRelationshipTypeCombo(ComboBox cboBase)
        {
            cboBase.Items.Clear();

            if (_classDataSet.Tables["RelationshipTypeTable"] != null)
            {
                foreach (DataRow relationshipRow in _classDataSet.Tables["RelationshipTypeTable"].Rows)
                {
                    cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(relationshipRow, "relationship_description", ""));
                }
            }

            cboBase.SelectedIndex = -1;
        }//------------------------

        //this procedure will initialize person relationship type combo
        public void InitializePersonRelationshipTypeCombo(ComboBox cboBase, String relationshipTypeId)
        {
            cboBase.Items.Clear();

            Int32 index = 0;
            Boolean isIndexed = false;

            if (_classDataSet.Tables["RelationshipTypeTable"] != null)
            {
                foreach (DataRow relationshipRow in _classDataSet.Tables["RelationshipTypeTable"].Rows)
                {
                    cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(relationshipRow, "relationship_description", ""));

                    if (!isIndexed)
                    {
                        if (String.Equals(RemoteServerLib.ProcStatic.DataRowConvert(relationshipRow, "relationship_type_id", ""), relationshipTypeId))
                        {
                            cboBase.SelectedIndex = index;
                            isIndexed = true;
                        }

                        index++;
                    }
                }
            }
        }//-------------------------
        
        //this procedure will initialize person relationship datagridview
        public void InitializePersonRelationshipDataGridView(DataGridView dgvBase, List<CommonExchange.PersonRelationship> personRelationshipList, 
            Label lblBase)
        {
            Boolean hasEnter = false;

            DataTable newTable = this.PersonRelationshipTable;

            foreach (CommonExchange.PersonRelationship list in personRelationshipList)
            {
                if (list.ObjectState != DataRowState.Deleted)
                {
                    DataRow relationshipRow = newTable.NewRow();

                    relationshipRow["relationship_id"] = list.RelationshipId;
                    relationshipRow["person_name"] = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(list.PersonInRelationshipWith.LastName,
                        list.PersonInRelationshipWith.FirstName, list.PersonInRelationshipWith.MiddleName);
                    relationshipRow["relationship_description"] = list.RelationshipTypeInfo.RelationshipDescription;

                    DateTime bDate = DateTime.MinValue;

                    if (DateTime.TryParse(list.PersonInRelationshipWith.BirthDate, out bDate))
                    {
                        relationshipRow["birthdate"] = bDate.ToLongDateString();
                    }

                    relationshipRow["present_address"] = list.PersonInRelationshipWith.PresentAddress;
                    relationshipRow["present_phone_nos"] = list.PersonInRelationshipWith.PresentPhoneNos;
                    relationshipRow["life_status_code_code_description"] = list.PersonInRelationshipWith.LifeStatusCode.CodeDescription;
                    relationshipRow["gender_code_code_description"] = list.PersonInRelationshipWith.GenderCode.CodeDescription;

                    newTable.Rows.Add(relationshipRow);

                    if (!hasEnter && list.IsEmergencyContact)
                    {
                        hasEnter = true;
                    }
                }
            }

            lblBase.Visible = !hasEnter;

            dgvBase.DataSource = newTable;
        }//-------------------------

        //this procedure will update person relationship information
        public void UpdatePersonRelationship(List<CommonExchange.PersonRelationship> personRelationshipList,
            CommonExchange.PersonRelationship personRelationshipInfo)
        {
            Int32 index = 0;

            if (personRelationshipInfo.IsEmergencyContact)
            {
                foreach (CommonExchange.PersonRelationship list in personRelationshipList)
                {
                    if (list.RelationshipId != personRelationshipInfo.RelationshipId)
                        list.IsEmergencyContact = false;
                }
            }

            foreach (CommonExchange.PersonRelationship list in personRelationshipList)
            {
                if (list.RelationshipId == personRelationshipInfo.RelationshipId)
                {
                    personRelationshipList.RemoveAt(index);

                    break;
                }

                index++;
            }

            personRelationshipList.Add(personRelationshipInfo);               
        }//-------------------------
        #endregion

        #region Programmer-Defined Functions
        //this function will get searched person information
        public DataTable GetSearchPersonInformation(CommonExchange.SysAccess userInfo, String queryString, String lastName,
            String firstName, String personSysIdExcludedList, Boolean isNewQuery)
        {
            if (isNewQuery)
            {
                using (RemoteClient.RemCntBaseManager remClient = new RemoteClient.RemCntBaseManager())
                {
                    _personTable = remClient.SelectPersonInformation(userInfo, queryString, lastName, firstName, personSysIdExcludedList);
                }
            }

            DataTable newTable = new DataTable("PersonTable");
			newTable.Columns.Add("person_name", System.Type.GetType("System.String"));
		    newTable.Columns.Add("birthdate", System.Type.GetType("System.String"));
		    newTable.Columns.Add("present_address", System.Type.GetType("System.String"));
		    newTable.Columns.Add("present_phone_nos", System.Type.GetType("System.String"));
			newTable.Columns.Add("life_status_code_code_description", System.Type.GetType("System.String"));
			newTable.Columns.Add("gender_code_code_description", System.Type.GetType("System.String"));

            if (_personTable != null)
            {
                foreach (DataRow pRow in _personTable.Rows)
                {
                    DataRow newRow = newTable.NewRow();

                    newRow["person_name"] = RemoteClient.ProcStatic.GetCompleteNameMiddleInitial(pRow, "last_name", "first_name", "middle_name");

                    DateTime dValue = DateTime.Parse(_serverDateTime);

                    if (DateTime.TryParse(RemoteServerLib.ProcStatic.DataRowConvert(pRow, "birthdate", ""), out dValue))
                    {

                        newRow["birthdate"] = DateTime.Compare(dValue, DateTime.MinValue) == 0 ? String.Empty :
                           dValue.ToLongDateString();
                    }

                    newRow["present_address"] = RemoteServerLib.ProcStatic.DataRowConvert(pRow, "present_address", "");
                    newRow["present_phone_nos"] = RemoteServerLib.ProcStatic.DataRowConvert(pRow, "present_phone_nos", "");
                    newRow["life_status_code_code_description"] = RemoteServerLib.ProcStatic.DataRowConvert(pRow, "life_status_code_code_description", "");
                    newRow["gender_code_code_description"] = RemoteServerLib.ProcStatic.DataRowConvert(pRow, "gender_code_code_description", "");

                    newTable.Rows.Add(newRow);
                }
            }

            return newTable;
        }//----------------------------

        //this function will get person details
        public CommonExchange.Person GetPersonDetails(CommonExchange.SysAccess userInfo, String personSysId, String startUp)
        {
            CommonExchange.Person personInfo = new CommonExchange.Person();

            using (RemoteClient.RemCntBaseManager remClient = new RemoteClient.RemCntBaseManager())
            {
                personInfo = remClient.SelectBySysIDPersonInformation(userInfo, personSysId);

                if (!String.IsNullOrEmpty(personInfo.BirthDate))
                {
                    DateTime bDate = DateTime.Parse(personInfo.BirthDate);

                    if (DateTime.Compare(bDate, DateTime.MinValue) == 0)
                        personInfo.BirthDate = String.Empty;                    
                }

                if (!String.IsNullOrEmpty(personInfo.MarriageDate))
                {
                    DateTime mDate = DateTime.Parse(personInfo.MarriageDate);

                    if (DateTime.Compare(mDate, DateTime.MinValue) == 0)
                        personInfo.MarriageDate = String.Empty;
                }
            }

            personInfo.FilePath = this.GetPersonImagePath(userInfo, personSysId, personInfo.PersonImagesFolder(startUp));

            return personInfo;
        }//---------------------

        //this function will get student information by person system id
        public CommonExchange.Student SelectBySysIDPersonStudentInformation(CommonExchange.SysAccess userInfo, String personSysId, String startUp)
        {
            CommonExchange.Student studentInfo = new CommonExchange.Student();

            using (RemoteClient.RemCntStudentManager remClient = new RemoteClient.RemCntStudentManager())
            {
                studentInfo = remClient.SelectBySysIDPersonStudentInformation(userInfo, personSysId);
            }

            studentInfo.PersonInfo.FilePath = this.GetPersonImagePath(userInfo, studentInfo.PersonInfo.PersonSysId,
                studentInfo.PersonInfo.PersonImagesFolder(startUp));

            return studentInfo;
        }//------------------

        //this function will get emplyee information by person system id
        public CommonExchange.Employee SelectBySysIDPersonEmployeeInformation(CommonExchange.SysAccess userInfo, String personSysId, String startUp)
        {
            CommonExchange.Employee employeeInfo = new CommonExchange.Employee();

            using (RemoteClient.RemCntEmployeeManager remClient = new RemoteClient.RemCntEmployeeManager())
            {
                employeeInfo = remClient.SelectBySysIDPersonEmployeeInformation(userInfo, personSysId);
            }

            employeeInfo.PersonInfo.FilePath = this.GetPersonImagePath(userInfo, employeeInfo.PersonInfo.PersonSysId,
              employeeInfo.PersonInfo.PersonImagesFolder(startUp));

            return employeeInfo;
        }//---------------------

        //this fucntion will get new user information by person system id
        public CommonExchange.SysAccess SelectBySysIDPersonSystemUserInfo(CommonExchange.SysAccess userInfo, String personSysId, String startUp)
        {
            CommonExchange.SysAccess newUserInfo = new CommonExchange.SysAccess();

            using (RemoteClient.RemCntAdministratorManager remClient = new RemoteClient.RemCntAdministratorManager())
            {
                newUserInfo = remClient.SelectBySysIDPersonSystemUserInfo(userInfo, personSysId);
            }

            newUserInfo.PersonInfo.FilePath = this.GetPersonImagePath(userInfo, newUserInfo.PersonInfo.PersonSysId,
                newUserInfo.PersonInfo.PersonImagesFolder(startUp));

            return newUserInfo;
        }//-------------------

        //this procedure will get code reference details
        public CommonExchange.CodeReference GetCodeReference(String codeEntityId, Int32 index)
        {
            CommonExchange.CodeReference codeReferenceInfo = new CommonExchange.CodeReference();

            String strFilter = "code_entity_id = '" + codeEntityId + "'";
            DataRow[] selectRow = _classDataSet.Tables["CodeReferenceTable"].Select(strFilter);

            Int32 count = 0;

            foreach (DataRow codeRow in selectRow)
            {
                if (count == index)
                {
                    codeReferenceInfo.CodeReferenceId = RemoteServerLib.ProcStatic.DataRowConvert(codeRow, "code_reference_id", "");
                    codeReferenceInfo.CodeEntityId = RemoteServerLib.ProcStatic.DataRowConvert(codeRow, "code_entity_id", "");
                    codeReferenceInfo.ReferenceCode = RemoteServerLib.ProcStatic.DataRowConvert(codeRow, "reference_code", "");
                    codeReferenceInfo.CodeDescription = RemoteServerLib.ProcStatic.DataRowConvert(codeRow, "code_description", "");

                    break;
                }

                count++;
            }

            return codeReferenceInfo;
        }//-----------------------

        //this fuction get person system id
        public String GetPersonSysId(Int32 index)
        {
            String value = String.Empty;

            if (_personTable != null && index >= 0)
            {
                DataRow pRow = _personTable.Rows[index];

                value = RemoteServerLib.ProcStatic.DataRowConvert(pRow, "sysid_person", "");
            }

            return value;
        }//----------------------

        //this function returns the extension name of the file
        public String GetImageExtensionName(String imagePath)
        {
            String strExt = String.Empty;

            if (File.Exists(imagePath))
            {
                DirectoryInfo dirInfo = new DirectoryInfo(imagePath);
                strExt = dirInfo.Extension;
            }

            return strExt;
        } //----------------------------------

        //this function gets the student image path
        public String GetPersonImagePath(CommonExchange.SysAccess userInfo, String personSysIdList, String imagePath)
        {
            try
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
                                    if (!File.Exists(imagePath))
                                    {
                                        studentImage.Save(imagePath);
                                    }
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
            }
            catch(Exception ex)
            {
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
                                    if (!File.Exists(imagePath))
                                    {
                                        studentImage.Save(imagePath);
                                    }
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
            }            

            return imagePath;
        }//------------------------------

        //this function gets the student image path
        public void InitializePersonImages(CommonExchange.SysAccess userInfo, String personSysIdList, List<CommonExchange.Person> personInfoList, String startUp)
        {
            try
            {
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
                            CommonExchange.Person personInfo = new CommonExchange.Person();

                            String imagePath = String.Empty;

                            foreach (CommonExchange.Person list in personInfoList)
                            {
                                if (String.Equals(tableReader["sysid_person"].ToString(), list.PersonSysId))
                                {
                                    personInfo = list;

                                    imagePath = personInfo.PersonImagesFolder(startUp);

                                    break;
                                }
                            }

                            RemoteClient.ProcStatic.DeleteDirectory(imagePath);

                            //creates the directory
                            DirectoryInfo dirInfo = new DirectoryInfo(imagePath);
                            dirInfo.Create();
                            dirInfo.Attributes = FileAttributes.Hidden;


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
                                    if (!File.Exists(imagePath))
                                    {
                                        studentImage.Save(imagePath);
                                    }
                                }
                            }
                        }
                    }
                   

                    tableReader.Close();
                }
            }
            catch// (Exception ex)
            {
                //DataTable imageTable;

                //using (RemoteClient.RemCntBaseManager remClient = new RemoteClient.RemCntBaseManager())
                //{
                //    imageTable = remClient.SelectPersonImagesPersonInformation(userInfo, personSysIdList);
                //}

                //using (DataTableReader tableReader = new DataTableReader(imageTable))
                //{
                //    if (tableReader.HasRows)
                //    {
                //        Int32 picColumn = 1;

                //        while (tableReader.Read())
                //        {
                //            CommonExchange.Person personInfo = new CommonExchange.Person();

                //            String imagePath = String.Empty;

                //            foreach (CommonExchange.Person list in personInfoList)
                //            {
                //                if (String.Equals(tableReader["sysid_person"].ToString(), list.PersonSysId))
                //                {
                //                    personInfo = list;

                //                    imagePath = personInfo.PersonImagesFolder(startUp);

                //                    break;
                //                }
                //            }

                //            if (!tableReader.IsDBNull(picColumn))
                //            {
                //                imagePath += tableReader["original_name"].ToString();

                //                long len = tableReader.GetBytes(picColumn, 0, null, 0, 0);
                //                // Create a buffer to hold the bytes, and then
                //                // read the bytes from the DataTableReader.
                //                Byte[] buffer = new Byte[len];
                //                tableReader.GetBytes(picColumn, 0, buffer, 0, (int)len);

                //                // Create a new Bitmap object, passing the array 
                //                // of bytes to the constructor of a MemoryStream.
                //                using (Bitmap studentImage = new Bitmap(new MemoryStream(buffer)))
                //                {                                   
                //                    if (!File.Exists(imagePath))
                //                    {
                //                        studentImage.Save(imagePath);
                //                    }
                //                }
                //            }
                //        }
                //    }                   

                //    tableReader.Close();
                //}
            }
        }//------------------------------

        //this fucntion will get person relationship type
        public CommonExchange.RelationshipType GetPersonRelationshipType(Int32 index)
        {
            CommonExchange.RelationshipType relationshipTypeInfo = new CommonExchange.RelationshipType();

            if (_classDataSet.Tables["RelationshipTypeTable"] != null)
            {
                DataRow relationshipRow = _classDataSet.Tables["RelationshipTypeTable"].Rows[index];

                relationshipTypeInfo.RelationshipTypeId = RemoteServerLib.ProcStatic.DataRowConvert(relationshipRow, "relationship_type_id", "");
                relationshipTypeInfo.RelationshipDescription = RemoteServerLib.ProcStatic.DataRowConvert(relationshipRow, "relationship_description", "");
                relationshipTypeInfo.IsSpouse = RemoteServerLib.ProcStatic.DataRowConvert(relationshipRow, "is_spouse", false);
                relationshipTypeInfo.IsSibling = RemoteServerLib.ProcStatic.DataRowConvert(relationshipRow, "is_sibling", false);
                relationshipTypeInfo.IsParent = RemoteServerLib.ProcStatic.DataRowConvert(relationshipRow, "is_parent", false);
                relationshipTypeInfo.IsInLaw = RemoteServerLib.ProcStatic.DataRowConvert(relationshipRow, "is_in_law", false);
                relationshipTypeInfo.IsFriend = RemoteServerLib.ProcStatic.DataRowConvert(relationshipRow, "is_friend", false);
                relationshipTypeInfo.IsBloodLine = RemoteServerLib.ProcStatic.DataRowConvert(relationshipRow, "is_blood_line", false); 
            }

            return relationshipTypeInfo;
        }//-------------------------

        //this fucntion will get person relationship
        public CommonExchange.PersonRelationship GetDetailsPersonRelationship(CommonExchange.SysAccess userInfo,
            List<CommonExchange.PersonRelationship> personRelationshipList, String relationshipId, String startUp)
        {
            CommonExchange.PersonRelationship personRelationship = new CommonExchange.PersonRelationship();

            foreach (CommonExchange.PersonRelationship list in personRelationshipList)
            {
                if (String.Equals(list.RelationshipId.ToString(), relationshipId))
                {
                    personRelationship = list;

                    personRelationship.PersonInRelationshipWith.FilePath = this.GetPersonImagePath(userInfo, 
                        personRelationship.PersonInRelationshipWith.PersonSysId, personRelationship.PersonInRelationshipWith.PersonImagesFolder(startUp));

                    break;
                }
            }

            return personRelationship;
        }//-----------------------------

        //this will generate person relationship exclude list
        public String GetPersonRelationshipExcludeListStringFormat(List<CommonExchange.PersonRelationship> personRelationshipList, String personSysId)
        {
            StringBuilder strValue = new StringBuilder();

            foreach (CommonExchange.PersonRelationship list in personRelationshipList)
            {
                strValue.Append(list.PersonInRelationshipWith.PersonSysId + ", ");
            }

            strValue.Append(personSysId + ", ");

            if (strValue.Length >= 2)
            {
                return strValue.ToString().Substring(0, strValue.Length - 2);
            }
            else
            {
                return String.Empty;
            }
        }//-------------------------

        //this fucntion will determine if the person is already a student or employee
        public Boolean IsExistsSysIDPersonStudentEmployeeInformation(CommonExchange.SysAccess userInfo, String sysIdPerson, ref Boolean isEmployee)
        {
            Boolean value = false;

            using (RemoteClient.RemCntBaseManager remClient = new RemoteClient.RemCntBaseManager())
            {
                value = remClient.IsExistsSysIDPersonStudentEmployeeInformation(userInfo, sysIdPerson, ref isEmployee);
            }

            return value;
        }//-------------------------
        #endregion
    }
}
