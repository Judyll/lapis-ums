using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace MemberServices
{
    internal class MemberLogic : BaseServices.BaseServicesLogic
    {
        #region Class Data Member Decleration
        private DataSet _memberClassDataSet;
        private DataTable _memberInfoTable;
        private DataTable _officeEmployerTable;
        #endregion

        #region Class Properties Decleration
       
        #endregion

        #region Class Constructors
        public MemberLogic(CommonExchange.SysAccess userInfo)
            : base(userInfo)
        {
            this.InitializeMemberClass(userInfo);
        }
        #endregion

        #region Programmers-Defined Void Procedures
        //this procedure will initialize member logic class
        private void InitializeMemberClass(CommonExchange.SysAccess userInfo)
        {
            using (RemoteClient.RemCntMemberManager remClient = new RemoteClient.RemCntMemberManager())
            {
                _memberClassDataSet = remClient.GetDataSetForMemberManager(userInfo);
            }

            //initialize office employer table
            using (RemoteClient.RemCntBaseManager remClient = new RemoteClient.RemCntBaseManager())
            {
                _officeEmployerTable = remClient.SelectOfficeEmployerInformation(userInfo, "*", false);
            }
        }//-------------------------

        //this procedure will insert member information
        public void InsertMemberInformation(CommonExchange.SysAccess userInfo, CommonExchange.Member memberInfo)
        {
            using (RemoteClient.RemCntMemberManager remClient = new RemoteClient.RemCntMemberManager())
            {
                remClient.InsertMemberInformation(userInfo, ref memberInfo);
            }

            using (RemoteClient.RemCntBaseManager remClient = new RemoteClient.RemCntBaseManager())
            {
                if (_persontDocumentTable != null)
                {
                    Int32 index = 0;

                    foreach (DataRow docRow in _persontDocumentTable.Rows)
                    {
                        if (docRow.RowState != DataRowState.Deleted &&
                            String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(docRow, "sysid_person", String.Empty)))
                        {
                            DataRow editRow = _persontDocumentTable.Rows[index];

                            editRow.BeginEdit();

                            editRow["sysid_person"] = memberInfo.PersonInfo.PersonSysId;

                            editRow.EndEdit();

                            if (docRow.RowState == DataRowState.Added)
                            {
                                editRow.AcceptChanges();
                                editRow.SetAdded();
                            }
                        }

                        index++;
                    }

                    //insert, update and delete Person Document Information
                    remClient.InsertUpdateDeletePersonDocument(userInfo, _persontDocumentTable);
                    //-----------------------------
                }
            }

            if (_memberInfoTable != null)
            {
                DataRow newRow = _memberInfoTable.NewRow();

                newRow["member_id"] = memberInfo.MemberId;
                newRow["occupation"] = memberInfo.PersonInfo.Occupation;
                newRow["last_name"] = memberInfo.PersonInfo.LastName;
                newRow["first_name"] = memberInfo.PersonInfo.FirstName;
                newRow["middle_name"] = memberInfo.PersonInfo.MiddleName;
                newRow["present_address"] = memberInfo.PersonInfo.PresentAddress;
                newRow["present_phone_nos"] = memberInfo.PersonInfo.PresentPhoneNos;
                newRow["home_address"] = memberInfo.PersonInfo.HomeAddress;
                newRow["home_phone_nos"] = memberInfo.PersonInfo.HomePhoneNos;
                newRow["office_employer_name"] = memberInfo.PersonInfo.OfficeEmployerInfo.OfficeEmployerName;
                newRow["office_office_employer_acronym"] = memberInfo.PersonInfo.OfficeEmployerInfo.OfficeEmployerAcronym;

                _memberInfoTable.Rows.Add(newRow);
            }
        }//--------------------------

        //this procedure will update member information
        public void UpdateMemberInformation(CommonExchange.SysAccess userInfo, CommonExchange.Member memberInfo)
        {
            using (RemoteClient.RemCntMemberManager remClient = new RemoteClient.RemCntMemberManager())
            {
                remClient.UpdateMemberInformation(userInfo, memberInfo);
            }

            using (RemoteClient.RemCntBaseManager remClient = new RemoteClient.RemCntBaseManager())
            {
                if (_persontDocumentTable != null)
                {
                    Int32 index = 0;

                    foreach (DataRow docRow in _persontDocumentTable.Rows)
                    {
                        if (docRow.RowState != DataRowState.Deleted &&
                            String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(docRow, "sysid_person", String.Empty)))
                        {
                            DataRow editRow = _persontDocumentTable.Rows[index];

                            editRow.BeginEdit();

                            editRow["sysid_person"] = memberInfo.PersonInfo.PersonSysId;

                            editRow.EndEdit();

                            if (docRow.RowState == DataRowState.Added)
                            {
                                editRow.AcceptChanges();
                                editRow.SetAdded();
                            }
                        }

                        index++;
                    }

                    //insert, update and delete Person Document Information
                    remClient.InsertUpdateDeletePersonDocument(userInfo, _persontDocumentTable);
                    //-----------------------------
                }
            }

            if (_memberInfoTable != null)
            {
                Int32 index = 0;

                foreach (DataRow memRow in _memberInfoTable.Rows)
                {
                    if (memRow.RowState != DataRowState.Deleted &&
                        String.Equals(RemoteServerLib.ProcStatic.DataRowConvert(memRow, "sysid_member", String.Empty), memberInfo.MemberSysId))
                    {
                        DataRow editRow = _memberInfoTable.Rows[index];

                        editRow.BeginEdit();

                        editRow["member_id"] = memberInfo.MemberId;
                        editRow["occupation"] = memberInfo.PersonInfo.Occupation;
                        editRow["last_name"] = memberInfo.PersonInfo.LastName;
                        editRow["first_name"] = memberInfo.PersonInfo.FirstName;
                        editRow["middle_name"] = memberInfo.PersonInfo.MiddleName;
                        editRow["present_address"] = memberInfo.PersonInfo.PresentAddress;
                        editRow["present_phone_nos"] = memberInfo.PersonInfo.PresentPhoneNos;
                        editRow["home_address"] = memberInfo.PersonInfo.HomeAddress;
                        editRow["home_phone_nos"] = memberInfo.PersonInfo.HomePhoneNos;
                        editRow["office_employer_name"] = memberInfo.PersonInfo.OfficeEmployerInfo.OfficeEmployerName;
                        editRow["office_office_employer_acronym"] = memberInfo.PersonInfo.OfficeEmployerInfo.OfficeEmployerAcronym;

                        editRow.EndEdit();
                    }

                    index++;
                }
            }
        }//---------------------

        //this procedure will initialize clasification combobox
        public void InitializeClassificationCombo(ComboBox cboBase)
        {
            cboBase.Items.Clear();

            if (_memberClassDataSet.Tables["MemberClassificationTable"] != null)
            {
                foreach (DataRow cRow in _memberClassDataSet.Tables["MemberClassificationTable"].Rows)
                {
                    cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(cRow, "classification_description", String.Empty));
                }
            }

            cboBase.SelectedIndex = -1;
        }//----------------------

        //this procedure will initialize clasification combobox
        public void InitializeClassificationCombo(ComboBox cboBase, String classificationId)
        {
            cboBase.Items.Clear();

            Int32 index = 0;
            Boolean isIndexed = false;

            if (_memberClassDataSet.Tables["MemberClassificationTable"] != null)
            {
                foreach (DataRow cRow in _memberClassDataSet.Tables["MemberClassificationTable"].Rows)
                {
                    cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(cRow, "classification_description", String.Empty));

                    if (!isIndexed)
                    {
                        if (String.Equals(RemoteServerLib.ProcStatic.DataRowConvert(cRow, "classification_id", String.Empty), classificationId))
                        {
                            cboBase.SelectedIndex = index;
                            isIndexed = true;
                        }

                        index++;
                    }
                }
            }
        }//----------------------

        //this procedure will initialize member type combobox
        public void InitializeMemberTypeComboBox(ComboBox cboBase)
        {
            cboBase.Items.Clear();

            if (_memberClassDataSet.Tables["MemberTypeTable"] != null)
            {
                foreach (DataRow cRow in _memberClassDataSet.Tables["MemberTypeTable"].Rows)
                {
                    cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(cRow, "member_type_description", String.Empty));
                }
            }

            cboBase.SelectedIndex = -1;
        }//---------------------------

        //this procedure will initialize member type combobox
        public void InitializeMemberTypeComboBox(ComboBox cboBase, String typeId)
        {
            cboBase.Items.Clear();

            Int32 index = 0;
            Boolean isIndexed = false;

            if (_memberClassDataSet.Tables["MemberTypeTable"] != null)
            {
                foreach (DataRow cRow in _memberClassDataSet.Tables["MemberTypeTable"].Rows)
                {
                    cboBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(cRow, "member_type_description", String.Empty));

                    if (!isIndexed)
                    {
                        if (String.Equals(RemoteServerLib.ProcStatic.DataRowConvert(cRow, "member_type_id", String.Empty), typeId))
                        {
                            cboBase.SelectedIndex = index;
                            isIndexed = true;
                        }

                        index++;
                    }
                }
            }
        }//------------------------------

        //this procedure will initialize office employer checked list box
        public void InitializeOfficeEmployerCheckedListBox(CheckedListBox cbxBase)
        {
            cbxBase.Items.Clear();

            if (_officeEmployerTable != null)
            {
                foreach (DataRow officeRow in _officeEmployerTable.Rows)
                {
                    cbxBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(officeRow, "office_employer_name", String.Empty) + " [" +
                        RemoteServerLib.ProcStatic.DataRowConvert(officeRow, "office_employer_acronym", String.Empty) + "]");
                }
            }
        }//--------------------------

        //this procedure will initialize member classification checked list box
        public void InitializeMemberClassificationCheckedListBox(CheckedListBox cbxBase)
        {
            cbxBase.Items.Clear();

            if (_memberClassDataSet.Tables["MemberClassificationTable"] != null)
            {
                foreach (DataRow memRow in _memberClassDataSet.Tables["MemberClassificationTable"].Rows)
                {
                    cbxBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(memRow, "classification_description", String.Empty));
                }
            }
        }//------------------------

        //this procedure will initialize member type checked list box
        public void InitializeMemberTypeCheckedListBox(CheckedListBox cbxBase)
        {
            cbxBase.Items.Clear();

            if (_memberClassDataSet.Tables["MemberTypeTable"] != null)
            {
                foreach (DataRow memRow in _memberClassDataSet.Tables["MemberTypeTable"].Rows)
                {
                    cbxBase.Items.Add(RemoteServerLib.ProcStatic.DataRowConvert(memRow, "member_type_description", String.Empty));
                }
            }
        }//-----------------------

        //this procedure will refresh member logic class
        public void ReferesData(CommonExchange.SysAccess userInfo)
        {
            this.InitializeMemberClass(userInfo);
        }//-------------------------
        #endregion

        #region Programmers-Defined Function
        //this fucntion will get office employer id by current index
        private String GetOfficeEmployerId(Int32 index)
        {
            String value = String.Empty;

            if (_officeEmployerTable != null)
            {
                DataRow officeRow = _officeEmployerTable.Rows[index];

                value = RemoteServerLib.ProcStatic.DataRowConvert(officeRow, "office_employer_id", String.Empty);
            }

            return value;
        }//----------------------

        //this function will get member classification and member type id by current index
        private String GetMemberClassificationTypeId(Int32 index, Boolean isMemberClassification)
        {
            String value = String.Empty;

            if (isMemberClassification && _memberClassDataSet.Tables["MemberClassificationTable"] != null)
            {
                DataRow memRow = _memberClassDataSet.Tables["MemberClassificationTable"].Rows[index];

                value = RemoteServerLib.ProcStatic.DataRowConvert(memRow, "classification_id", String.Empty);
            }
            else if (!isMemberClassification && _memberClassDataSet.Tables["MemberTypeTable"] != null)
            {
                DataRow memRow = _memberClassDataSet.Tables["MemberTypeTable"].Rows[index];

                value = RemoteServerLib.ProcStatic.DataRowConvert(memRow, "member_type_id", String.Empty);
            }

            return value;
        }//----------------------

        //this fucntion will get searched member information table
        public DataTable GetSearchedMemberInformationTable(CommonExchange.SysAccess userInfo, String queryString, String officeEmployerIdList,
            String classificationIdList, String memberSysIdExcludeList, String memberTypeIdList, Boolean includeMemberStatus, Boolean isActive, Boolean isNewQuery)

        {
            DataTable newTable = new DataTable("MemberTable");
            newTable.Columns.Add("member_id", System.Type.GetType("System.String"));
            newTable.Columns.Add("occupation", System.Type.GetType("System.String"));
            newTable.Columns.Add("member_name", System.Type.GetType("System.String"));
            newTable.Columns.Add("present_address", System.Type.GetType("System.String"));
            newTable.Columns.Add("present_phone_nos", System.Type.GetType("System.String"));
            newTable.Columns.Add("home_address", System.Type.GetType("System.String"));
            newTable.Columns.Add("home_phone_nos", System.Type.GetType("System.String"));
            newTable.Columns.Add("office_name_acronym", System.Type.GetType("System.String"));

            if (isNewQuery)
            {
                using (RemoteClient.RemCntMemberManager remClient = new RemoteClient.RemCntMemberManager())
                {
                    _memberInfoTable = remClient.SelectMemberInformation(userInfo, queryString, officeEmployerIdList, memberTypeIdList, classificationIdList, 
                        memberSysIdExcludeList, includeMemberStatus, isActive);
                }
            }

            if (_memberInfoTable != null)
            {
                foreach (DataRow memRow in _memberInfoTable.Rows)
                {
                    DataRow newRow = newTable.NewRow();

                    newRow["member_id"] = RemoteServerLib.ProcStatic.DataRowConvert(memRow, "member_id", String.Empty);
                    newRow["occupation"] = RemoteServerLib.ProcStatic.DataRowConvert(memRow, "occupation", String.Empty);
                    newRow["member_name"] = BaseServices.ProcStatic.GetCompleteNameMiddleInitial(memRow, "last_name", "first_name", "middle_name");
                    newRow["present_address"] = RemoteServerLib.ProcStatic.DataRowConvert(memRow, "present_address", String.Empty);
                    newRow["present_phone_nos"] = RemoteServerLib.ProcStatic.DataRowConvert(memRow, "present_phone_nos", String.Empty);
                    newRow["home_address"] = RemoteServerLib.ProcStatic.DataRowConvert(memRow, "home_address", String.Empty);
                    newRow["home_phone_nos"] = RemoteServerLib.ProcStatic.DataRowConvert(memRow, "home_phone_nos", String.Empty);
                    newRow["office_name_acronym"] = RemoteServerLib.ProcStatic.DataRowConvert(memRow, "office_employer_name", String.Empty) + " [" +
                        RemoteServerLib.ProcStatic.DataRowConvert(memRow, "office_office_employer_acronym", String.Empty) + "]";

                    newTable.Rows.Add(newRow);
                }
            }

            return newTable;
        }//----------------------

        //this fucntion will get member classification information
        public CommonExchange.MemberClassification GetMemberClassificationInformation(Int32 index)
        {
            CommonExchange.MemberClassification memberClassificationInfo = new CommonExchange.MemberClassification();

            DataRow cRow = _memberClassDataSet.Tables["MemberClassificationTable"].Rows[index];

            memberClassificationInfo.ClassificationId = RemoteServerLib.ProcStatic.DataRowConvert(cRow, "classification_id", String.Empty);
            memberClassificationInfo.ClassificationDescription = RemoteServerLib.ProcStatic.DataRowConvert(cRow, "classification_description", String.Empty);

            return memberClassificationInfo;
        }//----------------------

        //this function will get member type information
        public CommonExchange.MemberType GetMemberTypeInformation(Int32 index)
        {
            CommonExchange.MemberType memberTypeInfo = new CommonExchange.MemberType();

            DataRow memRow = _memberClassDataSet.Tables["MemberTypeTable"].Rows[index];

            memberTypeInfo.MemberTypeId = RemoteServerLib.ProcStatic.DataRowConvert(memRow, "member_type_id", String.Empty);
            memberTypeInfo.MemberTypeDescription = RemoteServerLib.ProcStatic.DataRowConvert(memRow, "member_type_description", String.Empty);

            return memberTypeInfo;
        }//-------------------------

        //this function will get member information details by member id
        public CommonExchange.Member GetMemberInformationDetailsByMemberId(CommonExchange.SysAccess userInfo, String memberId)
        {
            CommonExchange.Member memberInfo = new CommonExchange.Member();

            using (RemoteClient.RemCntMemberManager remClient = new RemoteClient.RemCntMemberManager())
            {
                memberInfo = remClient.SelectByMemberIDMemberInformation(userInfo, memberId);
            }

            if (!String.IsNullOrEmpty(memberInfo.PersonInfo.BirthDate))
            {
                DateTime bDate = DateTime.Parse(memberInfo.PersonInfo.BirthDate);

                if (DateTime.Compare(bDate, DateTime.MinValue) == 0)
                {
                    memberInfo.PersonInfo.BirthDate = String.Empty;
                }
            }

            if (!String.IsNullOrEmpty(memberInfo.PersonInfo.MarriageDate))
            {
                DateTime mDate = DateTime.Parse(memberInfo.PersonInfo.MarriageDate);

                if (DateTime.Compare(mDate, DateTime.MinValue) == 0)
                {
                    memberInfo.PersonInfo.MarriageDate = String.Empty;
                }
            }

            if (!String.IsNullOrEmpty(memberInfo.PersonInfo.EmploymentDate))
            {
                DateTime mDate = DateTime.Parse(memberInfo.PersonInfo.EmploymentDate);

                if (DateTime.Compare(mDate, DateTime.MinValue) == 0)
                {
                    memberInfo.PersonInfo.EmploymentDate = String.Empty;
                }
            }

            return memberInfo;
        }//-----------------------------

        //this function will get member information details by person id
        public CommonExchange.Member GetMemberInformationDetailsByPersonId(CommonExchange.SysAccess userInfo, String personSysId)
        {
            CommonExchange.Member memberInfo = new CommonExchange.Member();

            using (RemoteClient.RemCntMemberManager remClient = new RemoteClient.RemCntMemberManager())
            {
                memberInfo = remClient.SelectBySysIDPersonMemberInformation(userInfo, personSysId);
            }

            return memberInfo;
        }//---------------------------------       
 
        //this fucntion will determine if the member information already exist
        public Boolean IsExistsMemberIDMemberInformation(CommonExchange.SysAccess userInfo, String memberId, String memberSysId)
        {
            Boolean isExist = false;

            using (RemoteClient.RemCntMemberManager remClient = new RemoteClient.RemCntMemberManager())
            {
                isExist = remClient.IsExistsMemberIDMemberInformation(userInfo, memberId, memberSysId);
            }

            return isExist;
        }//------------------------------

        //this fucntion gets the course yearlevel string format
        public String GetOfficeEmployerStringFormat(CheckedListBox cbXBase, Boolean isOfficeEmployer, Boolean isMemberClassification, Boolean isMemberType)
        {
            StringBuilder strValue = new StringBuilder();

            if (cbXBase.CheckedIndices.Count >= 1)
            {
                IEnumerator myEnum = cbXBase.CheckedIndices.GetEnumerator();
                Int32 x;

                if (isOfficeEmployer)
                {
                    while (myEnum.MoveNext() != false)
                    {
                        x = (Int32)myEnum.Current;

                        strValue.Append(this.GetOfficeEmployerId(x) + ", ");
                    }
                }
                else if (isMemberClassification)
                {
                    while (myEnum.MoveNext() != false)
                    {
                        x = (Int32)myEnum.Current;

                        strValue.Append(this.GetMemberClassificationTypeId(x, true) + ", ");
                    }
                }
                else if (isMemberType)
                {
                    while (myEnum.MoveNext() != false)
                    {
                        x = (Int32)myEnum.Current;

                        strValue.Append(this.GetMemberClassificationTypeId(x, false) + ", ");
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
