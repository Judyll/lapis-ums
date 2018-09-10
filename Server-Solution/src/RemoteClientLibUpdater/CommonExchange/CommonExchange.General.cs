using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using System.Collections;

namespace CommonExchange
{
    #region Common Structure Exchange

    [Serializable()]
    public class SchoolInformation
    {
        private SchoolInformation() { }

        public static String SchoolName
        {
            get { return "One Lapis University Philippines"; }
        }

        public static String Address
        {
            get { return "North Road, Bantayan, Dumaguete City"; }
        }

        public static String Province
        {
            get { return "Negros Oriental, Philippines"; }
        }

        public static String PhoneNos
        {
            get { return "(035) 225-1506"; }
        }

        public static String TeacherLoadFormCode
        {
            get { return "F-CDO-010-1999"; }
        }

        public static String LicenseExpire
        {
            get { return "07/16/2050"; }
        }
        
        public static String InstitutionalIdentifier
        {
            get { return "07062"; }
        }

        public static String UniversityRegistrar
        {
            get { return "Dr. Batchiba R. Lacdo-o\nVP, ACADEMIC AFFAIRS"; }
        }

        public static String RegistrarClerk
        {
            get { return "GALERA, Mary Jane B."; }
        }

        public static String DCRNo
        {
            get { return "01537"; }
        }

        public static String BookKeeper
        {
            get { return "Mr. Junrey F. Garibay"; }
        }

        public static String VPOfFinanceAffairs
        {
            get { return "Sr. Angely Malan, SPC"; }
        }

        public static String PresidentDirector
        {
            get { return "President"; }
        }

        public static String VPOfAcademicAffairs
        {
            get { return "VP of Academic Affairs"; }
        }

        public static String TranscriptFormCode
        {
            get { return "F-0FR-027-2010"; }
        }

        public static String StudentMasterListCode
        {
            get { return "Student Master List Code"; }
        }

        public static String ClassListCode
        {
            get { return "Class List Code"; }
        }

        public static String CollegeGradingSheetCode
        {
            get { return "College Grading Sheet Code"; }
        }

        public static String StudentStudyLoadCode
        {
            get { return "Student Study Load Code"; }
        }

        public static String SummaryOfEnrolmentCode
        {
            get { return "Summary Of Enrolment Code"; }
        }

        public static String StudentCredentialsChecklistCode
        {
            get { return "Student Credentials Checklist Code"; }
        }

        public static String CollegiateStudentPermanentRecordCode
        {
            get { return "Collegiate Student Permanent Record Code"; }
        }

        public static String CollegeClearanceFormCode
        {
            get { return "College Clearnce From Code"; }
        }

        public static String ClassScheduleCode
        {
            get { return "Class Schedule Code"; }
        }
    }
    
    [Serializable()]
    public class CodeEntityId
    {
        private CodeEntityId() { }

        public static String Gender
        {
            get { return "ETID001"; }
        }

        public static String MaritalStatus
        {
            get { return "ETID002"; }
        }

        public static String LifeStatus
        {
            get { return "ETID003"; }
        }        
    }

    [Serializable()]
    public class CodeReference : BaseObject
    {
        public CodeReference()
        {
            _codeReferenceId = String.Empty;
            _codeEntityId = String.Empty;
            _referenceCode = String.Empty;
            _codeDescription = String.Empty;
        }

        public Boolean Equals(CodeReference obj)
        {
            if (base.Equals<CodeReference>(obj))
            {
                return true;
            }

            return false;

        }

        private String _codeReferenceId;
        public String CodeReferenceId
        {
            get { return _codeReferenceId; }
            set { _codeReferenceId = value; }
        }

        private String _codeEntityId;
        public String CodeEntityId
        {
            get { return _codeEntityId; }
            set { _codeEntityId = value; }
        }

        private String _referenceCode;
        public String ReferenceCode
        {
            get { return _referenceCode; }
            set { _referenceCode = value; }
        }

        private String _codeDescription;
        public String CodeDescription
        {
            get { return _codeDescription; }
            set { _codeDescription = value; }
        }
        
    }

    [Serializable()]
    public class RelationshipType : BaseObject
    {
        public RelationshipType()
        {
            _relationshipTypeId = String.Empty;
            _relationshipDescription = String.Empty;
            _isParent = false;
            _isSpouse = false;
            _isSibling = false;
            _isInLaw = false;
            _isBloodLine = false;
            _isFriend = false;

        }

        public Boolean Equals(RelationshipType obj)
        {
            if (base.Equals<RelationshipType>(obj))
            {
                return true;
            }

            return false;
        }

        private String _relationshipTypeId;
        public String RelationshipTypeId
        {
            get { return _relationshipTypeId; }
            set { _relationshipTypeId = value; }
        }

        private String _relationshipDescription;
        public String RelationshipDescription
        {
            get { return _relationshipDescription; }
            set { _relationshipDescription = value; }
        }

        private Boolean _isParent;
        public Boolean IsParent
        {
            get { return _isParent; }
            set { _isParent = value; }
        }

        private Boolean _isSpouse;
        public Boolean IsSpouse
        {
            get { return _isSpouse; }
            set { _isSpouse = value; }
        }

        private Boolean _isSibling;
        public Boolean IsSibling
        {
            get { return _isSibling; }
            set { _isSibling = value; }
        }

        private Boolean _isInLaw;
        public Boolean IsInLaw
        {
            get { return _isInLaw; }
            set { _isInLaw = value; }
        }

        private Boolean _isBloodLine;
        public Boolean IsBloodLine
        {
            get { return _isBloodLine; }
            set { _isBloodLine = value; }
        }

        private Boolean _isFriend;
        public Boolean IsFriend
        {
            get { return _isFriend; }
            set { _isFriend = value; }
        }
    }

    [Serializable()]
    public class Person : BaseObject
    {
        public Person()
        {
            _personSysId = String.Empty;
            _eCode = String.Empty;
            _lastName = String.Empty;
            _firstName = String.Empty;
            _middleName = String.Empty;
            _lifeStatusCode = new CodeReference();
            _genderCode = new CodeReference();
            _birthDate = String.Empty;
            _placeOfBirth = String.Empty;
            _eMailAddress = String.Empty;
            _presentAddress = String.Empty;
            _presentPhoneNos = String.Empty;
            _homeAddress = String.Empty;
            _homePhoneNos = String.Empty;
            _citizenship = String.Empty;
            _nationality = String.Empty;
            _religion = String.Empty;
            _maritalStatusCode = new CodeReference();
            _marriageDate = String.Empty;
            _otherPersonInformation = String.Empty;
            _forEmployee = false;
            _forStudent = false;
            _forLogin = false;
            _filePath = String.Empty;
            _fileName = String.Empty;
            _fileExtension = String.Empty;
            _personRelationshipList = new CloneableDictionaryList<PersonRelationship>();

        }

        public Boolean Equals(Person obj)
        {
            if (base.Equals<Person>(obj) &&
                _lifeStatusCode.Equals(obj.LifeStatusCode) &&
                _genderCode.Equals(obj.GenderCode) &&
                _maritalStatusCode.Equals(obj.MaritalStatusCode) &&
                this.Equals(obj.PersonRelationshipList))
            {
                return true;
            }

            return false;
        }

        private Boolean Equals(CloneableDictionaryList<PersonRelationship> list)
        {
            Int32 i = 0;

            foreach (PersonRelationship pRelationship in _personRelationshipList)
            {
                if ((i < list.Count) && (!pRelationship.Equals(list[i])))
                {
                    return false;
                }

                i++;
            }

            if (i != list.Count)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private String _personSysId;
        public String PersonSysId
        {
            get { return _personSysId; }
            set { _personSysId = value; }
        }

        private String _eCode;
        public String ECode
        {
            get { return _eCode; }
            set { _eCode = value; }
        }

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

        private String _middleName;
        public String MiddleName
        {
            get { return _middleName; }
            set { _middleName = value; }
        }

        private CodeReference _lifeStatusCode;
        public CodeReference LifeStatusCode
        {
            get { return _lifeStatusCode; }
            set { _lifeStatusCode = value; }
        }

        private CodeReference _genderCode;
        public CodeReference GenderCode
        {
            get { return _genderCode; }
            set { _genderCode = value; }
        }

        private String _birthDate;
        public String BirthDate
        {
            get { return _birthDate; }
            set { _birthDate = value; }
        }

        private String _placeOfBirth;
        public String PlaceOfBirth
        {
            get { return _placeOfBirth; }
            set { _placeOfBirth = value; }
        }

        private String _eMailAddress;
        public String EMailAddress
        {
            get { return _eMailAddress; }
            set { _eMailAddress = value; }
        }

        private String _presentAddress;
        public String PresentAddress
        {
            get { return _presentAddress; }
            set { _presentAddress = value; }
        }

        private String _presentPhoneNos;
        public String PresentPhoneNos
        {
            get { return _presentPhoneNos; }
            set { _presentPhoneNos = value; }
        }

        private String _homeAddress;
        public String HomeAddress
        {
            get { return _homeAddress; }
            set { _homeAddress = value; }
        }

        private String _homePhoneNos;
        public String HomePhoneNos
        {
            get { return _homePhoneNos; }
            set { _homePhoneNos = value; }
        }

        private String _citizenship;
        public String Citizenship
        {
            get { return _citizenship; }
            set { _citizenship = value; }
        }

        private String _nationality;
        public String Nationality
        {
            get { return _nationality; }
            set { _nationality = value; }
        }

        private String _religion;
        public String Religion
        {
            get { return _religion; }
            set { _religion = value; }
        }

        private CodeReference _maritalStatusCode;
        public CodeReference MaritalStatusCode
        {
            get { return _maritalStatusCode; }
            set { _maritalStatusCode = value; }
        }

        private String _marriageDate;
        public String MarriageDate
        {
            get { return _marriageDate; }
            set { _marriageDate = value; }
        }

        private String _otherPersonInformation;
        public String OtherPersonInformation
        {
            get { return _otherPersonInformation; }
            set { _otherPersonInformation = value; }
        }

        private Boolean _forEmployee;
        public Boolean ForEmployee
        {
            get { return _forEmployee; }
            set { _forEmployee = value; }
        }

        private Boolean _forStudent;
        public Boolean ForStudent
        {
            get { return _forStudent; }
            set { _forStudent = value; }
        }

        private Boolean _forLogin;
        public Boolean ForLogin
        {
            get { return _forLogin; }
            set { _forLogin = value; }
        }

        private String _filePath;
        public String FilePath
        {
            get { return _filePath; }
            set { _filePath = value; }
        }

        private String _fileName;
        public String FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        private String _fileExtension;
        public String FileExtension
        {
            get { return _fileExtension; }
            set { _fileExtension = value; }
        }

        private Byte[] _fileData;
        public Byte[] FileData
        {
            get { return _fileData; }
            set { _fileData = value; }
        }

        private CloneableDictionaryList<PersonRelationship> _personRelationshipList;
        public CloneableDictionaryList<PersonRelationship> PersonRelationshipList
        {
            get { return _personRelationshipList; }
            set { _personRelationshipList = value; }
        }

        /// <summary>
        /// If the PersonSysId is NULL or Empty, a TEMP folder is created
        /// </summary>
        /// <param name="startUpPath"></param>
        /// <returns></returns>
        public String PersonImagesFolder(String startUpPath)
        {
            return SystemConfiguration.ApplicationDocumentsFolder(startUpPath) + @"\" +
                (!String.IsNullOrEmpty(_personSysId) ? _personSysId : "Temp") + @"\PersonImages\";
        }
    }

    [Serializable()]
    public class PersonRelationship : BaseObject
    {
        public PersonRelationship()
        {
            _relationshipId = 0;
            _personInRelationshipWith = new Person();
            _relationshipTypeInfo = new RelationshipType();
            _isEmergencyContact = false;
        }

        public Boolean Equals(PersonRelationship obj)
        {
            if (base.Equals<PersonRelationship>(obj) &&
                _personInRelationshipWith.Equals(obj.PersonInRelationshipWith) &&
                _relationshipTypeInfo.Equals(obj.RelationshipTypeInfo))
            {
                return true;
            }

            return false;
        }

        private Int64 _relationshipId;
        public Int64 RelationshipId
        {
            get { return _relationshipId; }
            set { _relationshipId = value; }
        }

        private Person _personInRelationshipWith;
        public Person PersonInRelationshipWith
        {
            get { return _personInRelationshipWith; }
            set { _personInRelationshipWith = value; }
        }

        private RelationshipType _relationshipTypeInfo;
        public RelationshipType RelationshipTypeInfo
        {
            get { return _relationshipTypeInfo; }
            set { _relationshipTypeInfo = value; }
        }

        private Boolean _isEmergencyContact;
        public Boolean IsEmergencyContact
        {
            get { return _isEmergencyContact; }
            set { _isEmergencyContact = value; }
        }

    }

    [Serializable()]
    public class SysAccess : BaseObject
    {
        public SysAccess()
        {
            _userId = String.Empty;
            _userName = String.Empty;
            _password = String.Empty;
            _userStatus = false;
            _personInfo = new Person();
            _networkInfo = String.Empty;
            _installationDate = String.Empty;
            _accessRightsGrantedList = new CloneableDictionaryList<AccessRightsGranted>();
        }

        public Boolean Equals(SysAccess obj)
        {
            if (base.Equals<SysAccess>(obj) &&
                _personInfo.Equals(obj.PersonInfo) &&
                this.Equals(obj.AccessRightsGrantedList))
            {
                return true;
            }

            return false;
        }

        private Boolean Equals(CloneableDictionaryList<AccessRightsGranted> list)
        {
            Int32 i = 0;

            foreach (AccessRightsGranted rightGranted in _accessRightsGrantedList)
            {
                if ((i < list.Count) && (!rightGranted.Equals(list[i])))
                {
                    return false;
                }

                i++;
            }

            if (i != list.Count)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private String _userId;
        public String UserId
        {
            get { return _userId; }
            set { _userId = value; }
        }

        private String _userName;
        public String UserName
        {
            get { return _userName; }
            set { _userName = value; }
        }

        private String _password;
        public String Password
        {
            get { return _password; }
            set { _password = value; }
        }

        private Boolean _userStatus;
        public Boolean UserStatus
        {
            get { return _userStatus; }
            set { _userStatus = value; }
        }

        private Person _personInfo;
        public Person PersonInfo
        {
            get { return _personInfo; }
            set { _personInfo = value; }
        }

        private String _networkInfo;
        public String NetworkInformation
        {
            get { return _networkInfo; }
            set { _networkInfo = value; }
        }

        private String _installationDate;
        public String InstallationDate
        {
            get { return _installationDate; }
            set { _installationDate = value; }
        }

        private CloneableDictionaryList<AccessRightsGranted> _accessRightsGrantedList;
        public CloneableDictionaryList<AccessRightsGranted> AccessRightsGrantedList
        {
            get { return _accessRightsGrantedList; }
            set { _accessRightsGrantedList = value; }
        }
               
    }

    [Serializable()]
    public class AccessRightsGranted : BaseObject
    {
        public AccessRightsGranted()
        {
            _rightsGrantedId = 0;
            _accessRightsInfo = new SystemAccessRights();
            _departmentInfo = new Department();
        }

        public Boolean Equals(AccessRightsGranted obj)
        {
            if (base.Equals<AccessRightsGranted>(obj) &&
                _accessRightsInfo.Equals(obj.AccessRightsInfo) &&
                _departmentInfo.Equals(obj.DepartmentInfo))
            {
                return true;
            }

            return false;
        }

        private Int64 _rightsGrantedId;
        public Int64 RightsGrantedId
        {
            get { return _rightsGrantedId; }
            set { _rightsGrantedId = value; }
        }

        private SystemAccessRights _accessRightsInfo;
        public SystemAccessRights AccessRightsInfo
        {
            get { return _accessRightsInfo; }
            set { _accessRightsInfo = value; }
        }

        private Department _departmentInfo;
        public Department DepartmentInfo
        {
            get { return _departmentInfo; }
            set { _departmentInfo = value; }
        }
    }

    [Serializable()]
    public class SystemAccessRights : BaseObject
    {
        public SystemAccessRights()
        {
            _accessRights = String.Empty;
            _accessIndex = 0;
            _accessDescription = String.Empty;
        }

        public Boolean Equals(SystemAccessRights obj)
        {
            if (base.Equals<SystemAccessRights>(obj))
            {
                return true;
            }

            return false;
        }

        private String _accessRights;
        public String AccessRights
        {
            get { return _accessRights; }
            set { _accessRights = value; }
        }

        private Byte _accessIndex;
        public Byte AccessIndex
        {
            get { return _accessIndex; }
            set { _accessIndex = value; }
        }

        private String _accessDescription;
        public String AccessDescription
        {
            get { return _accessDescription; }
            set { _accessDescription = value; }
        }
    }

    [Serializable()]
    public class Department : BaseObject
    {
        public Department()
        {
            _departmentId = String.Empty;
            _departmentName = String.Empty;
            _acronym = String.Empty;
            _idPrefix = String.Empty;
        }

        public Boolean Equals(Department obj)
        {
            if (base.Equals<Department>(obj))
            {
                return true;
            }

            return false;
        }

        private String _departmentId;
        public String DepartmentId
        {
            get { return _departmentId; }
            set { _departmentId = value; }
        }

        private String _departmentName;
        public String DepartmentName
        {
            get { return _departmentName; }
            set { _departmentName = value; }
        }

        private String _acronym;
        public String Acronym
        {
            get { return _acronym; }
            set { _acronym = value; }
        }

        private String _idPrefix;
        public String IdPrefix
        {
            get { return _idPrefix; }
            set { _idPrefix = value; }
        }
    }

    [Serializable()]
    public class PayrollStandard : BaseObject
    {
        public PayrollStandard()
        {
            _payrollStandardSysId = String.Empty;
            _payrollCutOffDay = 0;
        }

        public Boolean Equals(PayrollStandard obj)
        {
            if (base.Equals<PayrollStandard>(obj))
            {
                return true;
            }

            return false;
        }

        private String _payrollStandardSysId;
        public String PayrollStandardSysId
        {
            get { return _payrollStandardSysId; }
            set { _payrollStandardSysId = value; }
        }

        private Byte _payrollCutOffDay;
        public Byte PayrollCutOffDay
        {
            get { return _payrollCutOffDay; }
            set { _payrollCutOffDay = value; }
        }
    }

    [Serializable()]
    public class FinanceStandard : BaseObject
    {
        public FinanceStandard()
        {
            _financeStandardSysId = String.Empty;
            _internationalPercentage = 0.0F;
            _enrolmentCutOffDay = 0;
        }

        public Boolean Equals(FinanceStandard obj)
        {
            if (base.Equals<FinanceStandard>(obj))
            {
                return true;
            }

            return false;

        }

        private String _financeStandardSysId;
        public String FinanceStandardSysId
        {
            get { return _financeStandardSysId; }
            set { _financeStandardSysId = value; }
        }

        private Single _internationalPercentage;
        public Single InternationalPercentage
        {
            get { return _internationalPercentage; }
            set { _internationalPercentage = value; }
        }

        private Byte _enrolmentCutOffDay;
        public Byte EnrolmentCutOffDay
        {
            get { return _enrolmentCutOffDay; }
            set { _enrolmentCutOffDay = value; }
        }
    }

    [Serializable()]
    public class RegistrarStandard : BaseObject
    {
        public RegistrarStandard()
        {
            _registrarStandardSysId = String.Empty;
            _schoolYearStart = 0;
            _semesterMonths = 0;
            _summerMonths = 0;
        }

        public Boolean Equals(RegistrarStandard obj)
        {
            if (base.Equals<RegistrarStandard>(obj))
            {
                return true;
            }

            return false;
        }

        private String _registrarStandardSysId;
        public String RegistrarStandardSysId
        {
            get { return _registrarStandardSysId; }
            set { _registrarStandardSysId = value; }
        }

        private Byte _schoolYearStart;
        public Byte SchoolYearStart
        {
            get { return _schoolYearStart; }
            set { _schoolYearStart = value; }
        }

        private Byte _semesterMonths;
        public Byte SemesterMonths
        {
            get { return _semesterMonths; }
            set { _semesterMonths = value; }
        }

        private Byte _summerMonths;
        public Byte SummerMonths
        {
            get { return _summerMonths; }
            set { _summerMonths = value; }
        }
    }

    [Serializable()]
    public class TransactionLog
    {
        public TransactionLog()
        {
            _userInfo = new SysAccess();
        }

        private Int64 _transactionId;
        public Int64 TransactionId
        {
            get { return _transactionId; }
            set { _transactionId = value; }
        }

        private String _transactionDate;
        public String TransactionDate
        {
            get { return _transactionDate; }
            set { _transactionDate = value; }
        }

        private SysAccess _userInfo;
        public SysAccess UserInfo
        {
            get { return _userInfo; }
            set { _userInfo = value; }
        }

        private String _networkInformation;
        public String NetworkInformation
        {
            get { return _networkInformation; }
            set { _networkInformation = value; }
        }

        private String _transactionDone;
        public String TransactionDone
        {
            get { return _transactionDone; }
            set { _transactionDone = value; }
        }

        private String _userStatusString;
        public String UserStatusString
        {
            get { return _userStatusString; }
            set { _userStatusString = value; }
        }

        private String _accessDescription;
        public String AccessDescription
        {
            get { return _accessDescription; }
            set { _accessDescription = value; }
        }
    }

    [Serializable()]
    public class SystemConfiguration
    {
        public static String ApplicationDocumentsFolder(String startUpPath)
        {
            return startUpPath + @"\AppDocuments";
        }

        public static String GoogleMapsWebAddress(String query)
        {
            return @"http://maps.google.com/maps?hl=en&q=" + query;
        }

        public static String TreeViewNodeTextSpace
        {
            get { return @"  ::  "; }
        }

        public static String UpdatedBinaryFolder(String startUpPath)
        {
            return startUpPath + @"\UMS Binaries";
        }

        public static String UpdatedCampusAccessBinaryFolder(String startUpPath)
        {
            return startUpPath + @"\UMS Campus Access Binaries";
        }

        public static String PersonImagesFolder(String startUpPath)
        {
            return startUpPath + @"\PersonImages";
        }

        public static String XmlFolder(String startUpPath)
        {
            return startUpPath + @"\Xml";
        }
    }

    [Serializable()]
    public class TransactionSource
    {
        public TransactionSource() { }

        public TransactionSource(Boolean isSystemUser, Boolean isInstructorUser, Boolean isStudentUser, Boolean isForLogIn)
        {
            if (isSystemUser)
            {
                _isSystemUser = isSystemUser;
                _isInstructorUser = !isSystemUser;
                _isStudentUser = !isSystemUser;
            }
            else if (isInstructorUser)
            {
                _isSystemUser = !isInstructorUser;
                _isInstructorUser = isInstructorUser;
                _isStudentUser = !isInstructorUser;
            }
            else if (isStudentUser)
            {
                _isSystemUser = !isStudentUser;
                _isInstructorUser = !isStudentUser;
                _isStudentUser = isStudentUser;
            }

            _isForLogIn = isForLogIn;

        }

        private Boolean _isSystemUser;
        public Boolean IsSystemUser
        {
            get { return _isSystemUser; }
            set { 
                    _isSystemUser = value;
                    _isInstructorUser = !value;
                    _isStudentUser = !value; 
                }
        }

        private Boolean _isInstructorUser;
        public Boolean IsInstructorUser
        {
            get { return _isInstructorUser; }
            set {
                    _isSystemUser = !value;
                    _isInstructorUser = value;
                    _isStudentUser = !value; 
                }
        }

        private Boolean _isStudentUser;
        public Boolean IsStudentUser
        {
            get { return _isStudentUser; }
            set {
                    _isSystemUser = !value;
                    _isInstructorUser = !value;
                    _isStudentUser = value; 
                }
        }

        private Boolean _isForLogIn;
        public Boolean IsForLogIn
        {
            get { return _isForLogIn; }
            set { _isForLogIn = value; }
        }
    }

    [Serializable()]
    public class UmsBinaries
    {
        public UmsBinaries() { }

        private String _fileName;
        public String FileName
        {
            get { return _fileName; }
            set { _fileName = value; }
        }

        private Byte[] _fileBytes;
        public Byte[] FileBytes
        {
            get { return _fileBytes; }
            set { _fileBytes = value; }
        }
    }

    /// <summary>
    /// This class is used for list that needs to be cloned. Source: http://programmingcorner.blogspot.com/2007_01_01_programmingcorner_archive.html
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable()]
    public class CloneableDictionaryList<T> : List<T>, ICloneable where T : class
    {
        public virtual Object Clone()
        {
            CloneableDictionaryList<T> newList = new CloneableDictionaryList<T>();

            if (this.Count > 0)
            {
                Type iCloneType = this[0].GetType().GetInterface("ICloneable", true);

                if (iCloneType != null)
                {
                    foreach (T value in this)
                    {
                        newList.Add((T)((ICloneable)value).Clone());
                    }
                }
                else
                {
                    foreach (T value in this)
                    {
                        newList.Add(value);
                    }
                }

                return newList;
            }
            else
            {
                return newList;
            }

        }
    }

    [Serializable()]
    public abstract class BaseObject : ICloneable
    {
        protected DataRowState _objectState;    //must be declared as protected in order for the data member to be include in the cloning.
        public DataRowState ObjectState
        {
            get { return _objectState; }
            set { _objectState = value; }
        }

        /// <summary>
        /// Clone the object, and returning a reference to a cloned object.
        /// Source: http://www.codeproject.com/KB/cs/cloneimpl_class.aspx
        /// </summary>
        /// <returns>reference to the new cloned object</returns>
        public Object Clone()
        {
            //create an instance of this specific type
            Object newObject = Activator.CreateInstance(this.GetType());

            //get the array of fields for the new type instance
            FieldInfo[] fields = newObject.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | 
                BindingFlags.Public | BindingFlags.Static);

            Int32 i = 0;

            //foreach (FieldInfo fi in this.GetType().GetFields())
            foreach (FieldInfo fi in newObject.GetType().GetFields(BindingFlags.NonPublic | BindingFlags.Instance | 
                BindingFlags.Public | BindingFlags.Static))
            {
                //query if the fields support the ICloneable interface.
                Type ICloneType = fi.FieldType.GetInterface("ICloneable", true);

                if (ICloneType != null)
                {
                    //getting the ICloneable interface from the object
                    ICloneable IClone = (ICloneable)fi.GetValue(this);

                    if (fi.GetValue(this) != null)
                    {
                        //use the clone method to set the new value to the field.
                        fields[i].SetValue(newObject, IClone.Clone());
                    }
                }
                else
                {
                    if (fi.GetValue(this) != null)
                    {
                        //if the field doesn't support the ICloneable interface then just set it.
                        fields[i].SetValue(newObject, fi.GetValue(this));
                    }
                }

                //check if the object support the IEnumerable interface, so if it does
                //we need to enumerate all its items and check if they support the ICloneable interface
                Type IEnumerableType = fi.FieldType.GetInterface("IEnumerable", true);

                if (IEnumerableType != null)
                {
                    //get the IEnumerable interface from the field.
                    IEnumerable IEnum = (IEnumerable)fi.GetValue(this);

                    //this version support the IList and the IDictionary interfaces to iterate on collections.
                    Type IListType = fields[i].FieldType.GetInterface("IList", true);

                    Type IDicType = fields[i].FieldType.GetInterface("IDictionary", true);

                    Int32 j = 0;

                    if (IListType != null)
                    {
                        //getting the IList interface
                        IList list = (IList)fields[i].GetValue(newObject);

                        if (IEnum != null && list != null)
                        {
                            foreach (Object obj in IEnum)
                            {
                                //checks to see if the current item support the ICloneable interface
                                ICloneType = obj.GetType().GetInterface("ICloneable", true);

                                if (ICloneType != null)
                                {
                                    //if it does support the ICloneable interface, we use it to set the clone of the object in the list
                                    ICloneable clone = (ICloneable)obj;

                                    list[j] = clone.Clone();
                                }

                                //NOTE: If the item in the list is does not
                                //support the ICloneable interface then in the cloned list this item
                                //will be the same item as in the original list (as long as this type is a reference type).

                                j++;
                            }
                        }
                    }
                    else if (IDicType != null)
                    {
                        //getting the dictionary interface
                        IDictionary dic = (IDictionary)fields[i].GetValue(newObject);

                        if (dic != null)
                        {
                            j = 0;

                            foreach (DictionaryEntry de in IEnum)
                            {
                                //checking to see if the item support the ICloneable interface.
                                ICloneType = de.Value.GetType().GetInterface("ICloneable", true);

                                if (ICloneType != null)
                                {
                                    ICloneable clone = (ICloneable)de.Value;

                                    dic[de.Key] = clone.Clone();
                                }

                                j++;
                            }
                        }
                    }
                }

                i++;
            }

            return newObject;

        }

        protected Boolean Equals<T>(T obj) where T : class
        {
            if (obj != null)
            {
                PropertyInfo[] sourceProperties = this.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance |
                    BindingFlags.Public | BindingFlags.Static);

                foreach (PropertyInfo pi in sourceProperties)
                {
                    if (!(this.GetType().GetProperty(pi.Name).GetValue(this, null) == null ||
                        obj.GetType().GetProperty(pi.Name).GetValue(obj, null) == null) &&
                        !(String.Equals(this.GetType().GetProperty(pi.Name).GetValue(this, null).ToString(),
                        obj.GetType().GetProperty(pi.Name).GetValue(obj, null).ToString())))
                    {
                        return false;
                    }
                }

                return true;
            }

            return this == obj;
        }
    }

    [Serializable()]
    public enum SystemRange
    {
        MonthAllowance = 1,         //refer to ums.IsRecordLockByYearSemesterID, ums.InsertStudentPayments, 
                                    //          ums.InsertStudentDiscounts, ums.InsertStudentReimbursements, 
                                    //          ums.IsScheduleConflictsWithAnotherEmployeeLoadedSchedule
        ReceivedDateAllowance = 4   //IsRecordLockByReflectedCreatedDate
    }

    [Serializable()]
    public enum ServerCode
    {
        PrimaryServer = 1,
        FailOverServer = 2
    }
    #endregion

}
