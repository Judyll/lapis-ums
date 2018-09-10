using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CommonExchange
{
    #region Common Exchange Structure

    [Serializable()]
    public class Student : BaseObject
    {
        public Student()
        {
            _studentSysId = String.Empty;
            _personInfo = new Person();
            _studentId = String.Empty;
            _cardNumber = String.Empty;
            _scholarship = String.Empty;
            _isInternational = false;
            _isNoDownpaymentRequired = false;
            _otherStudentInformation = String.Empty;
            _hasHsCard = false;
            _hasHonDismissal = false;
            _hasTor = false;
            _hasGoodMoral = false;
            _hasBirthCert = false;
            _hasMarriageContract = false;
            _hasLatestPhoto = false;
            _hasNcaeResult = false;
            _courseInfo = new CourseInformation();
        }

        public Boolean Equals(Student obj)
        {
            if (base.Equals<Student>(obj) &&
                _personInfo.Equals(obj.PersonInfo) &&
                _courseInfo.Equals(obj.CourseInfo))
            {
                return true;
            }

            return false;
        }

        private String _studentSysId;
        public String StudentSysId
        {
            get { return _studentSysId; }
            set { _studentSysId = value; }
        }

        private Person _personInfo;
        public Person PersonInfo
        {
            get { return _personInfo; }
            set { _personInfo = value; }
        }

        private String _studentId;
        public String StudentId
        {
            get { return _studentId; }
            set { _studentId = value; }
        }

        private String _cardNumber;
        public String CardNumber
        {
            get { return _cardNumber; }
            set { _cardNumber = value; }
        }

        private String _scholarship;
        public String Scholarship
        {
            get { return _scholarship; }
            set { _scholarship = value; }
        }

        private Boolean _isInternational;
        public Boolean IsInternational
        {
            get { return _isInternational; }
            set { _isInternational = value; }
        }

        private Boolean _isNoDownpaymentRequired;
        public Boolean IsNoDownpaymentRequired
        {
            get { return _isNoDownpaymentRequired; }
            set { _isNoDownpaymentRequired = value; }
        }

        private String _otherStudentInformation;
        public String OtherStudentInformation
        {
            get { return _otherStudentInformation; }
            set { _otherStudentInformation = value; }
        }

        private Boolean _hasHsCard;
        public Boolean HasHsCard
        {
            get { return _hasHsCard; }
            set { _hasHsCard = value; }
        }

        private Boolean _hasHonDismissal;
        public Boolean HasHonDismissal
        {
            get { return _hasHonDismissal; }
            set { _hasHonDismissal = value; }
        }

        private Boolean _hasTor;
        public Boolean HasTor
        {
            get { return _hasTor; }
            set { _hasTor = value; }
        }
	
	    private Boolean _hasGoodMoral;
        public Boolean HasGoodMoral
        {
            get { return _hasGoodMoral; }
            set { _hasGoodMoral = value; }
        }

        private Boolean _hasBirthCert;
        public Boolean HasBirthCert
        {
            get { return _hasBirthCert; }
            set { _hasBirthCert = value; }
        }
	
        private Boolean _hasMarriageContract;
        public Boolean HasMarriageContract
        {
            get { return _hasMarriageContract; }
            set { _hasMarriageContract = value; }
        }
	
        private Boolean _hasLatestPhoto;
        public Boolean HasLatestPhoto
        {
            get { return _hasLatestPhoto; }
            set { _hasLatestPhoto = value; }
        }
	
        private Boolean _hasNcaeResult;
        public Boolean HasNcaeResult
        {
            get { return _hasNcaeResult; }
            set { _hasNcaeResult = value; }
        }

        private CourseInformation _courseInfo;
        public CourseInformation CourseInfo
        {
            get { return _courseInfo; }
            set { _courseInfo = value; }
        }
    }

    [Serializable()]
    public class SchoolFeeParticular : BaseObject
    {
        public SchoolFeeParticular()
        {
            _feeParticularSysId = String.Empty;
            _schoolFeeCategoryInfo = new SchoolFeeCategory();
            _particularDescription = String.Empty;
            _isOptional = false;
            _isOfficeAccess = false;
            _isEntryLevelIncluded = false;
            _isGraduationFee = false;
        }

        public Boolean Equals(SchoolFeeParticular obj)
        {
            if (base.Equals<SchoolFeeParticular>(obj) &&
                _schoolFeeCategoryInfo.Equals(obj.SchoolFeeCategoryInfo))
            {
                return true;
            }

            return false;
        }

        private String _feeParticularSysId;
        public String FeeParticularSysId
        {
            get { return _feeParticularSysId; }
            set { _feeParticularSysId = value; }
        }

        private SchoolFeeCategory _schoolFeeCategoryInfo;
        public SchoolFeeCategory SchoolFeeCategoryInfo
        {
            get { return _schoolFeeCategoryInfo; }
            set { _schoolFeeCategoryInfo = value; }
        }

        private String _particularDescription;
        public String ParticularDescription
        {
            get { return _particularDescription; }
            set { _particularDescription = value; }
        }

        private Boolean _isOptional;
        public Boolean IsOptional
        {
            get { return _isOptional; }
            set { _isOptional = value; }
        }

        private Boolean _isOfficeAccess;
        public Boolean IsOfficeAccess
        {
            get { return _isOfficeAccess; }
            set { _isOfficeAccess = value; }
        }

        private Boolean _isEntryLevelIncluded;
        public Boolean IsEntryLevelIncluded
        {
            get { return _isEntryLevelIncluded; }
            set { _isEntryLevelIncluded = value; }
        }

        private Boolean _isGraduationFee;
        public Boolean IsGraduationFee
        {
            get { return _isGraduationFee; }
            set { _isGraduationFee = value; }
        }
    }

    [Serializable()]
    public class SchoolFeeInformation : BaseObject
    {
        public SchoolFeeInformation()
        {
            _feeInformationSysId = String.Empty;
            _schoolYearInfo = new SchoolYear();
        }

        public Boolean Equals(SchoolFeeInformation obj)
        {
            if (base.Equals<SchoolFeeInformation>(obj) &&
                _schoolYearInfo.Equals(obj.SchoolYearInfo))
            {
                return true;
            }

            return false;
        }

        private String _feeInformationSysId;
        public String FeeInformationSysId
        {
            get { return _feeInformationSysId; }
            set { _feeInformationSysId = value; }
        }

        private SchoolYear _schoolYearInfo;
        public SchoolYear SchoolYearInfo
        {
            get { return _schoolYearInfo; }
            set { _schoolYearInfo = value; }
        }
    }

    [Serializable()]
    public class SchoolFeeLevel : BaseObject
    {
        public SchoolFeeLevel()
        {
            _feeLevelSysId = String.Empty;
            _schoolFeeInfo = new SchoolFeeInformation();
            _yearLevelInfo = new YearLevelInformation();
        }

        public Boolean Equals(SchoolFeeLevel obj)
        {
            if (base.Equals<SchoolFeeLevel>(obj) &&
                _schoolFeeInfo.Equals(obj.SchoolFeeInfo) &&
                _yearLevelInfo.Equals(obj.YearLevelInfo))
            {
                return true;
            }

            return false;
        }

        private String _feeLevelSysId;
        public String FeeLevelSysId
        {
            get { return _feeLevelSysId; }
            set { _feeLevelSysId = value; }
        }

        private SchoolFeeInformation _schoolFeeInfo;
        public SchoolFeeInformation SchoolFeeInfo
        {
            get { return _schoolFeeInfo; }
            set { _schoolFeeInfo = value; }
        }

        private YearLevelInformation _yearLevelInfo;
        public YearLevelInformation YearLevelInfo
        {
            get { return _yearLevelInfo; }
            set { _yearLevelInfo = value; }
        }
        
    }

    [Serializable()]
    public class StudentEnrolmentCourse : BaseObject
    {
        public StudentEnrolmentCourse()
        {
            _enrolmentCourseSysId = String.Empty;
            _studentInfo = new Student();
            _courseInfo = new CourseInformation();
            _schoolFeeInfo = new SchoolFeeInformation();
            _semesterInfo = new SemesterInformation();
            _isCurrentCourse = false;
        }

        public Boolean Equals(StudentEnrolmentCourse obj)
        {
            if (base.Equals<StudentEnrolmentCourse>(obj) &&
                _studentInfo.Equals(obj.StudentInfo) &&
                _courseInfo.Equals(obj.CourseInfo) &&
                _schoolFeeInfo.Equals(obj.SchoolFeeInfo) &&
                _semesterInfo.Equals(obj.SemesterInfo))
            {
                return true;
            }

            return false;
        }

        private String _enrolmentCourseSysId;
        public String EnrolmentCourseSysId
        {
            get { return _enrolmentCourseSysId; }
            set { _enrolmentCourseSysId = value; }
        }

        private Student _studentInfo;
        public Student StudentInfo
        {
            get { return _studentInfo; }
            set { _studentInfo = value; }
        }

        private CourseInformation _courseInfo;
        public CourseInformation CourseInfo
        {
            get { return _courseInfo; }
            set { _courseInfo = value; }
        }

        private SchoolFeeInformation _schoolFeeInfo;
        public SchoolFeeInformation SchoolFeeInfo
        {
            get { return _schoolFeeInfo; }
            set { _schoolFeeInfo = value; }
        }

        private SemesterInformation _semesterInfo;
        public SemesterInformation SemesterInfo
        {
            get { return _semesterInfo; }
            set { _semesterInfo = value; }
        }

        private Boolean _isCurrentCourse;
        public Boolean IsCurrentCourse
        {
            get { return _isCurrentCourse; }
            set { _isCurrentCourse = value; }
        }
    }

    [Serializable()]
    public class StudentEnrolmentLevel : BaseObject
    {
        public StudentEnrolmentLevel()
        {
            _enrolmentLevelSysId = String.Empty;
            _studentEnrolmentCourseInfo = new StudentEnrolmentCourse();
            _schoolFeeLevelInfo = new SchoolFeeLevel();
            _semesterInfo = new SemesterInformation();
            _financeStandardInfo = new FinanceStandard();
            _levelSection = String.Empty;
            _isEntryLevel = false;
            _isGraduateStudent = false;
            _isInternational = false;
            _isMarkedDeleted = false;
            _enrolmentLevelNo = 0;
            _enrolmentCourseMajorList = new CloneableDictionaryList<EnrolmentCourseMajor>();
        }

        public Boolean Equals(StudentEnrolmentLevel obj)
        {
            if (base.Equals<StudentEnrolmentLevel>(obj) &&
                _studentEnrolmentCourseInfo.Equals(obj.StudentEnrolmentCourseInfo) &&
                _schoolFeeLevelInfo.Equals(obj.SchoolFeeLevelInfo) &&
                _semesterInfo.Equals(obj.SemesterInfo) &&
                _financeStandardInfo.Equals(obj.FinanceStandardInfo) &&
                this.Equals(_enrolmentCourseMajorList))
            {
                return true;
            }

            return false;
        }

        private Boolean Equals(CloneableDictionaryList<EnrolmentCourseMajor> list)
        {
            Int32 i = 0;

            foreach (EnrolmentCourseMajor courseMajor in _enrolmentCourseMajorList)
            {
                if ((i < list.Count) && (!courseMajor.Equals(list[i])))
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

        private String _enrolmentLevelSysId;
        public String EnrolmentLevelSysId
        {
            get { return _enrolmentLevelSysId; }
            set { _enrolmentLevelSysId = value; }
        }

        private StudentEnrolmentCourse _studentEnrolmentCourseInfo;
        public StudentEnrolmentCourse StudentEnrolmentCourseInfo
        {
            get { return _studentEnrolmentCourseInfo; }
            set { _studentEnrolmentCourseInfo = value; }
        }

        private SchoolFeeLevel _schoolFeeLevelInfo;
        public SchoolFeeLevel SchoolFeeLevelInfo
        {
            get { return _schoolFeeLevelInfo; }
            set { _schoolFeeLevelInfo = value; }
        }

        private SemesterInformation _semesterInfo;
        public SemesterInformation SemesterInfo
        {
            get { return _semesterInfo; }
            set { _semesterInfo = value; }
        }

        private FinanceStandard _financeStandardInfo;
        public FinanceStandard FinanceStandardInfo
        {
            get { return _financeStandardInfo; }
            set { _financeStandardInfo = value; }
        }

        private String _levelSection;
        public String LevelSection
        {
            get { return _levelSection; }
            set { _levelSection = value; }
        }

        private Boolean _isEntryLevel;
        public Boolean IsEntryLevel
        {
            get { return _isEntryLevel; }
            set { _isEntryLevel = value; }
        }

        private Boolean _isGraduateStudent;
        public Boolean IsGraduateStudent
        {
            get { return _isGraduateStudent; }
            set { _isGraduateStudent = value; }
        }

        private Boolean _isInternational;
        public Boolean IsInternational
        {
            get { return _isInternational; }
            set { _isInternational = value; }
        }

        private Boolean _isMarkedDeleted;
        public Boolean IsMarkedDeleted
        {
            get { return _isMarkedDeleted; }
            set { _isMarkedDeleted = value; }
        }

        private Int32 _enrolmentLevelNo;
        public Int32 EnrolmentLevelNo
        {
            get { return _enrolmentLevelNo; }
            set { _enrolmentLevelNo = value; }           
        }

        private CloneableDictionaryList<EnrolmentCourseMajor> _enrolmentCourseMajorList;
        public CloneableDictionaryList<EnrolmentCourseMajor> EnrolmentCourseMajorList
        {
            get { return _enrolmentCourseMajorList; }
            set { _enrolmentCourseMajorList = value; }
        }
    }

    [Serializable()]
    public class SchoolFeeDetails : BaseObject
    {
        public SchoolFeeDetails()
        {
            _feeDetailsSysId = String.Empty;
            _schoolFeeLevelInfo = new SchoolFeeLevel();
            _schoolFeeParticularInfo = new SchoolFeeParticular();
            _isLevelIncrease = false;
            _amount = 0.0M;
            _isOptional = false;
            _isOfficeAccess = false;
            _isEntryLevelIncluded = false;
            _isGraduationFee = false;
            _includeFirstSemester = false;
            _includeSecondSemester = false;
            _includeSummer = false;
            _includeMale = false;
            _includeFemale = false;
            _isMarkedDeleted = false;
        }

        public Boolean Equals(SchoolFeeDetails obj)
        {
            if (base.Equals<SchoolFeeDetails>(obj) &&
                _schoolFeeLevelInfo.Equals(obj.SchoolFeeLevelInfo) &&
                _schoolFeeParticularInfo.Equals(obj.SchoolFeeParticularInfo))
            {
                return true;
            }

            return false;
        }

        private String _feeDetailsSysId;
        public String FeeDetailsSysId
        {
            get { return _feeDetailsSysId; }
            set { _feeDetailsSysId = value; }
        }

        private SchoolFeeLevel _schoolFeeLevelInfo;
        public SchoolFeeLevel SchoolFeeLevelInfo
        {
            get { return _schoolFeeLevelInfo; }
            set { _schoolFeeLevelInfo = value; }
        }

        private SchoolFeeParticular _schoolFeeParticularInfo;
        public SchoolFeeParticular SchoolFeeParticularInfo
        {
            get { return _schoolFeeParticularInfo; }
            set { _schoolFeeParticularInfo = value; }
        }
        
        private Boolean _isLevelIncrease;
        public Boolean IsLevelIncrease
        {
            get { return _isLevelIncrease; }
            set { _isLevelIncrease = value; }
        }

        private Decimal _amount;
        public Decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        private Boolean _isOptional;
        public Boolean IsOptional
        {
            get { return _isOptional; }
            set { _isOptional = value; }
        }

        private Boolean _isOfficeAccess;
        public Boolean IsOfficeAccess
        {
            get { return _isOfficeAccess; }
            set { _isOfficeAccess = value; }
        }

        private Boolean _isEntryLevelIncluded;
        public Boolean IsEntryLevelIncluded
        {
            get { return _isEntryLevelIncluded; }
            set { _isEntryLevelIncluded = value; }
        }

        private Boolean _isGraduationFee;
        public Boolean IsGraduationFee
        {
            get { return _isGraduationFee; }
            set { _isGraduationFee = value; }
        }

        private Boolean _includeFirstSemester;
        public Boolean IncludeFirstSemester
        {
            get { return _includeFirstSemester; }
            set { _includeFirstSemester = value; }
        }

        private Boolean _includeSecondSemester;
        public Boolean IncludeSecondSemester
        {
            get { return _includeSecondSemester; }
            set { _includeSecondSemester = value; }
        }

        private Boolean _includeSummer;
        public Boolean IncludeSummer
        {
            get { return _includeSummer; }
            set { _includeSummer = value; }
        }

        private Boolean _includeMale;
        public Boolean IncludeMale
        {
            get { return _includeMale; }
            set { _includeMale = value; }
        }

        private Boolean _includeFemale;
        public Boolean IncludeFemale
        {
            get { return _includeFemale; }
            set { _includeFemale = value; }
        }

        private Boolean _isMarkedDeleted;
        public Boolean IsMarkedDeleted
        {
            get { return _isMarkedDeleted; }
            set { _isMarkedDeleted = value; }
        }
        
    }

    [Serializable()]
    public class StudentAdditionalFee : BaseObject
    {
        public StudentAdditionalFee()
        {
            _additionalFeeId = 0;
            _studentEnrolmentLevelInfo = new StudentEnrolmentLevel();
            _schoolFeeParticularInfo = new SchoolFeeParticular();
            _amount = 0.0M;
            _remarks = String.Empty;
        }

        public Boolean Equals(StudentAdditionalFee obj)
        {
            if (base.Equals<StudentAdditionalFee>(obj) &&
                _studentEnrolmentLevelInfo.Equals(obj.StudentEnrolmentLevelInfo) &&
                _schoolFeeParticularInfo.Equals(obj.SchoolFeeParticularInfo))
            {
                return true;
            }

            return false;
        }

        private Int64 _additionalFeeId;
        public Int64 AdditionalFeeId
        {
            get { return _additionalFeeId; }
            set { _additionalFeeId = value; }
        }

        private StudentEnrolmentLevel _studentEnrolmentLevelInfo;
        public StudentEnrolmentLevel StudentEnrolmentLevelInfo
        {
            get { return _studentEnrolmentLevelInfo; }
            set { _studentEnrolmentLevelInfo = value; }
        }

        private SchoolFeeParticular _schoolFeeParticularInfo;
        public SchoolFeeParticular SchoolFeeParticularInfo
        {
            get { return _schoolFeeParticularInfo; }
            set { _schoolFeeParticularInfo = value; }
        }

        private Decimal _amount;
        public Decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        private String _remarks;
        public String Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }

    }

    [Serializable()]
    public class StudentOptionalFee : BaseObject
    {
        public StudentOptionalFee()
        {
            _optionalFeeId = 0;
            _studentEnrolmentLevelInfo = new StudentEnrolmentLevel();
            _schoolFeeDetailsInfo = new SchoolFeeDetails();
        }

        public Boolean Equals(StudentOptionalFee obj)
        {
            if (base.Equals<StudentOptionalFee>(obj) &&
                _studentEnrolmentLevelInfo.Equals(obj.StudentEnrolmentLevelInfo) &&
                _schoolFeeDetailsInfo.Equals(obj.SchoolFeeDetailsInfo))
            {
                return true;
            }

            return false;
        }

        private Int64 _optionalFeeId;
        public Int64 OptionalFeeId
        {
            get { return _optionalFeeId; }
            set { _optionalFeeId = value; }
        }

        private StudentEnrolmentLevel _studentEnrolmentLevelInfo;
        public StudentEnrolmentLevel StudentEnrolmentLevelInfo
        {
            get { return _studentEnrolmentLevelInfo; }
            set { _studentEnrolmentLevelInfo = value; }
        }

        private SchoolFeeDetails _schoolFeeDetailsInfo;
        public SchoolFeeDetails SchoolFeeDetailsInfo
        {
            get { return _schoolFeeDetailsInfo; }
            set { _schoolFeeDetailsInfo = value; }
        }

    }

    [Serializable()]
    public class StudentPayments : BaseObject
    {
        public StudentPayments()
        {
            _paymentId = 0;
            _studentInfo = new Student();
            _reflectedDate = String.Empty;
            _receiptDate = String.Empty;
            _receivedDate = String.Empty;
            _receiptNo = String.Empty;
            _remarks = String.Empty;
            _isDownpayment = false;
            _amount = 0.0M;
            _discountAmount = 0.0M;
            _amountTendered = 0.0M;
            _bank = String.Empty;
            _checkNo = String.Empty;
            _accountCreditInfo = new ChartOfAccount();
            _isMiscellaneousIncome = false;
        }

        public Boolean Equals(StudentPayments obj)
        {
            if (base.Equals<StudentPayments>(obj) &&
                _studentInfo.Equals(obj.StudentInfo) &&
                _accountCreditInfo.Equals(obj.AccountCreditInfo))
            {
                return true;
            }

            return false;
        }

        private Int64 _paymentId;
        public Int64 PaymentId
        {
            get { return _paymentId; }
            set { _paymentId = value; }
        }

        private Student _studentInfo;
        public Student StudentInfo
        {
            get { return _studentInfo; }
            set { _studentInfo = value; }
        }

        private String _reflectedDate;
        public String ReflectedDate
        {
            get { return _reflectedDate; }
            set { _reflectedDate = value; }
        }

        private String _receiptDate;
        public String ReceiptDate
        {
            get { return _receiptDate; }
            set { _receiptDate = value; }
        }

        private String _receivedDate;
        public String ReceivedDate
        {
            get { return _receivedDate; }
            set { _receivedDate = value; }
        }

        private String _receiptNo;
        public String ReceiptNo
        {
            get { return _receiptNo; }
            set { _receiptNo = value; }
        }

        private String _remarks;
        public String Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }

        private Boolean _isDownpayment;
        public Boolean IsDownpayment
        {
            get { return _isDownpayment; }
            set { _isDownpayment = value; }
        }

        private Decimal _amount;
        public Decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        private Decimal _discountAmount;
        public Decimal DiscountAmount
        {
            get { return _discountAmount; }
            set { _discountAmount = value; }
        }

        private Decimal _amountTendered;
        public Decimal AmountTendered
        {
            get { return _amountTendered; }
            set { _amountTendered = value; }
        }

        private String _bank;
        public String Bank
        {
            get { return _bank; }
            set { _bank = value; }
        }

        private String _checkNo;
        public String CheckNo
        {
            get { return _checkNo; }
            set { _checkNo = value; }
        }

        private ChartOfAccount _accountCreditInfo;
        public ChartOfAccount AccountCreditInfo
        {
            get { return _accountCreditInfo; }
            set { _accountCreditInfo = value; }
        }

        private Boolean _isMiscellaneousIncome;
        public Boolean IsMiscellaneousIncome
        {
            get { return _isMiscellaneousIncome; }
            set { _isMiscellaneousIncome = value; }
        }

    }    

    [Serializable()]
    public class StudentDiscounts : BaseObject
    {
        public StudentDiscounts()
        {
            _discountId = 0;
            _studentScholarshipInfo = new StudentScholarship();
            _reflectedDate = String.Empty;
            _receivedDate = String.Empty;
            _remarks = String.Empty;
            _amount = 0.0M;
            _isDownpayment = false;
        }

        public Boolean Equals(StudentDiscounts obj)
        {
            if (base.Equals<StudentDiscounts>(obj) &&
                _studentScholarshipInfo.Equals(obj.StudentScholarshipInfo))
            {
                return true;
            }

            return false;
        }

        private Int64 _discountId;
        public Int64 DiscountId
        {
            get { return _discountId; }
            set { _discountId = value; }
        }

        private StudentScholarship _studentScholarshipInfo;
        public StudentScholarship StudentScholarshipInfo
        {
            get { return _studentScholarshipInfo; }
            set { _studentScholarshipInfo = value; }
        }

        private String _reflectedDate;
        public String ReflectedDate
        {
            get { return _reflectedDate; }
            set { _reflectedDate = value; }
        }

        private String _receivedDate;
        public String ReceivedDate
        {
            get { return _receivedDate; }
            set { _receivedDate = value; }
        }

        private String _remarks;
        public String Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }

        private Decimal _amount;
        public Decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        private Boolean _isDownpayment;
        public Boolean IsDownpayment
        {
            get { return _isDownpayment; }
            set { _isDownpayment = value; }
        }

    }

    [Serializable()]
    public class StudentReimbursements : BaseObject
    {
        public StudentReimbursements()
        {
            _reimbursementId = 0;
            _studentInfo = new Student();
            _reflectedDate = String.Empty;
            _receivedDate = String.Empty;
            _remarks = String.Empty;
            _amount = 0.0M;
            _isDownpayment = false;
        }

        public Boolean Equals(StudentReimbursements obj)
        {
            if (base.Equals<StudentReimbursements>(obj) &&
                _studentInfo.Equals(obj.StudentInfo))
            {
                return true;
            }

            return false;
        }

        private Int64 _reimbursementId;
        public Int64 ReimbursementId
        {
            get { return _reimbursementId; }
            set { _reimbursementId = value; }
        }

        private Student _studentInfo;
        public Student StudentInfo
        {
            get { return _studentInfo; }
            set { _studentInfo = value; }
        }

        private String _reflectedDate;
        public String ReflectedDate
        {
            get { return _reflectedDate; }
            set { _reflectedDate = value; }
        }

        private String _receivedDate;
        public String ReceivedDate
        {
            get { return _receivedDate; }
            set { _receivedDate = value; }
        }

        private String _remarks;
        public String Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }

        private Decimal _amount;
        public Decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        private Boolean _isDownpayment;
        public Boolean IsDownpayment
        {
            get { return _isDownpayment; }
            set { _isDownpayment = value; }
        }

    }

    [Serializable()]
    public class StudentCreditMemo : BaseObject
    {
        public StudentCreditMemo()
        {
            _memoId = 0;
            _studentInfo = new Student();
            _reflectedDate = String.Empty;
            _receivedDate = String.Empty;
            _remarks = String.Empty;
            _amount = 0.0M;
            _isDownpayment = false;
        }

        public Boolean Equals(StudentCreditMemo obj)
        {
            if (base.Equals<StudentCreditMemo>(obj) &&
                _studentInfo.Equals(obj.StudentInfo))
            {
                return true;
            }

            return false;
        }

        private Int64 _memoId;
        public Int64 MemoId
        {
            get { return _memoId; }
            set { _memoId = value; }
        }

        private Student _studentInfo;
        public Student StudentInfo
        {
            get { return _studentInfo; }
            set { _studentInfo = value; }
        }

        private String _reflectedDate;
        public String ReflectedDate
        {
            get { return _reflectedDate; }
            set { _reflectedDate = value; }
        }

        private String _receivedDate;
        public String ReceivedDate
        {
            get { return _receivedDate; }
            set { _receivedDate = value; }
        }

        private String _remarks;
        public String Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }

        private Decimal _amount;
        public Decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        private Boolean _isDownpayment;
        public Boolean IsDownpayment
        {
            get { return _isDownpayment; }
            set { _isDownpayment = value; }
        }

    }

    [Serializable()]
    public class StudentPromissoryNote : BaseObject
    {
        public StudentPromissoryNote()
        {
            _promissoryNoteId = 0;
            _studentInfo = new Student();
            _reflectedDate = String.Empty;
            _receivedDate = String.Empty;
            _referenceNo = String.Empty;
            _promissoryNote = String.Empty;
            _isDownpayment = false;
        }

        public Boolean Equals(StudentPromissoryNote obj)
        {
            if (base.Equals<StudentPromissoryNote>(obj) &&
                _studentInfo.Equals(obj.StudentInfo))
            {
                return true;
            }

            return false;
        }

        private Int64 _promissoryNoteId;
        public Int64 PromissoryNoteId
        {
            get { return _promissoryNoteId; }
            set { _promissoryNoteId = value; }
        }

        private Student _studentInfo;
        public Student StudentInfo
        {
            get { return _studentInfo; }
            set { _studentInfo = value; }
        }

        private String _reflectedDate;
        public String ReflectedDate
        {
            get { return _reflectedDate; }
            set { _reflectedDate = value; }
        }

        private String _receivedDate;
        public String ReceivedDate
        {
            get { return _receivedDate; }
            set { _receivedDate = value; }
        }

        private String _referenceNo;
        public String ReferenceNo
        {
            get { return _referenceNo; }
            set { _referenceNo = value; }
        }

        private String _promissoryNote;
        public String PromissoryNote
        {
            get { return _promissoryNote; }
            set { _promissoryNote = value; }
        }

        private Boolean _isDownpayment;
        public Boolean IsDownpayment
        {
            get { return _isDownpayment; }
            set { _isDownpayment = value; }
        }

    }

    [Serializable()]
    public class MiscellaneousIncome : BaseObject
    {
        public MiscellaneousIncome()
        {
            _paymentId = 0;
            _receivedFrom = String.Empty;
            _studentInfo = new Student();
            _employeeInfo = new Employee();
            _reflectedDate = String.Empty;
            _receiptDate = String.Empty;
            _receivedDate = String.Empty;
            _receiptNo = String.Empty;
            _remarks = String.Empty;
            _amount = 0.0M;
            _discountAmount = 0.0M;
            _amountTendered = 0.0M;
            _bank = String.Empty;
            _checkNo = String.Empty;
            _accountCreditInfo = new ChartOfAccount();
        }

        public Boolean Equals(MiscellaneousIncome obj)
        {
            if (base.Equals<MiscellaneousIncome>(obj) &&
                _studentInfo.Equals(obj.StudentInfo) &&
                _accountCreditInfo.Equals(obj.AccountCreditInfo))
            {
                return true;
            }

            return false;
        }

        private Int64 _paymentId;
        public Int64 PaymentId
        {
            get { return _paymentId; }
            set { _paymentId = value; }
        }

        private String _receivedFrom;
        public String ReceivedFrom
        {
            get { return _receivedFrom; }
            set { _receivedFrom = value; }
        }

        private Student _studentInfo;
        public Student StudentInfo
        {
            get { return _studentInfo; }
            set { _studentInfo = value; }
        }

        private Employee _employeeInfo;
        public Employee EmployeeInfo
        {
            get { return _employeeInfo; }
            set { _employeeInfo = value; }
        }

        private String _reflectedDate;
        public String ReflectedDate
        {
            get { return _reflectedDate; }
            set { _reflectedDate = value; }
        }

        private String _receiptDate;
        public String ReceiptDate
        {
            get { return _receiptDate; }
            set { _receiptDate = value; }
        }

        private String _receivedDate;
        public String ReceivedDate
        {
            get { return _receivedDate; }
            set { _receivedDate = value; }
        }

        private String _receiptNo;
        public String ReceiptNo
        {
            get { return _receiptNo; }
            set { _receiptNo = value; }
        }

        private String _remarks;
        public String Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }

        private Decimal _amount;
        public Decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        private Decimal _discountAmount;
        public Decimal DiscountAmount
        {
            get { return _discountAmount; }
            set { _discountAmount = value; }
        }

        private Decimal _amountTendered;
        public Decimal AmountTendered
        {
            get { return _amountTendered; }
            set { _amountTendered = value; }
        }

        private String _bank;
        public String Bank
        {
            get { return _bank; }
            set { _bank = value; }
        }

        private String _checkNo;
        public String CheckNo
        {
            get { return _checkNo; }
            set { _checkNo = value; }
        }

        private ChartOfAccount _accountCreditInfo;
        public ChartOfAccount AccountCreditInfo
        {
            get { return _accountCreditInfo; }
            set { _accountCreditInfo = value; }
        }

    }

    [Serializable()]
    public class BreakdownBankDeposit : BaseObject
    {
        public BreakdownBankDeposit()
        {
            _breakdownId = 0;
            _dateStart = String.Empty;
            _dateEnd = String.Empty;
            _amount = 0.0M;
            _accountInfo = new ChartOfAccount();
        }

        public Boolean Equals(BreakdownBankDeposit obj)
        {
            if (base.Equals<BreakdownBankDeposit>(obj) &&
                _accountInfo.Equals(obj.AccountInfo))
            {
                return true;
            }

            return false;
        }

        private Int64 _breakdownId;
        public Int64 BreakdownId
        {
            get { return _breakdownId; }
            set { _breakdownId = value; }
        }

        private String _dateStart;
        public String DateStart
        {
            get { return _dateStart; }
            set { _dateStart = value; }
        }

        private String _dateEnd;
        public String DateEnd
        {
            get { return _dateEnd; }
            set { _dateEnd = value; }
        }

        private Decimal _amount;
        public Decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        private ChartOfAccount _accountInfo;
        public ChartOfAccount AccountInfo
        {
            get { return _accountInfo; }
            set { _accountInfo = value; }
        }

    }    

    [Serializable()]
    public class StudentBalanceForwarded : BaseObject
    {
        public StudentBalanceForwarded()
        {
            _balanceId = 0;
            _studentInfo = new Student();
            _amount = 0.0M;
        }

        public Boolean Equals(StudentBalanceForwarded obj)
        {
            if (base.Equals<StudentBalanceForwarded>(obj) &&
                _studentInfo.Equals(obj.StudentInfo))
            {
                return true;
            }

            return false;
        }

        private Int64 _balanceId;
        public Int64 BalanceId
        {
            get { return _balanceId; }
            set { _balanceId = value; }
        }

        private Student _studentInfo;
        public Student StudentInfo
        {
            get { return _studentInfo; }
            set { _studentInfo = value; }
        }

        private Decimal _amount;
        public Decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
    }

    [Serializable()]
    public class SchoolFeeCategory : BaseObject
    {
        public SchoolFeeCategory()
        {
            _feeCategoryId = String.Empty;
            _categoryDescription = String.Empty;
            _categoryNo = 0;
        }

        public Boolean Equals(SchoolFeeCategory obj)
        {
            if (base.Equals<SchoolFeeCategory>(obj))
            {
                return true;
            }

            return false;
        }

        private String _feeCategoryId;
        public String FeeCategoryId
        {
            get { return _feeCategoryId; }
            set { _feeCategoryId = value; }
        }

        private String _categoryDescription;
        public String CategoryDescription
        {
            get { return _categoryDescription; }
            set { _categoryDescription = value; }
        }

        private Byte _categoryNo;
        public Byte CategoryNo
        {
            get { return _categoryNo; }
            set { _categoryNo = value; }
        }

    }

    [Serializable()]
    public class CancelledReceiptNo : BaseObject
    {
        public CancelledReceiptNo()
        {
            _receiptNo = String.Empty;
            _receiptDate = String.Empty;
            _dateCancelled = String.Empty;
            _remarks = String.Empty;
        }

        public Boolean Equals(CancelledReceiptNo obj)
        {
            if (base.Equals<CancelledReceiptNo>(obj))
            {
                return true;
            }

            return false;
        }

        private String _receiptNo;
        public String ReceiptNo
        {
            get { return _receiptNo; }
            set { _receiptNo = value; }
        }

        private String _receiptDate;
        public String ReceiptDate
        {
            get { return _receiptDate; }
            set { _receiptDate = value; }
        }

        private String _dateCancelled;
        public String DateCancelled
        {
            get { return _dateCancelled; }
            set { _dateCancelled = value; }
        }

        private String _remarks;
        public String Remarks
        {
            get { return _remarks; }
            set { _remarks = value; }
        }

    }

    [Serializable()]
    public class SchoolFeeCategoryId : BaseObject
    {
        public static String TuitionFee
        {
            get { return "FCID01"; }
        }

        public static String MiscellaneousFees
        {
            get { return "FCID02"; }
        }

        public static String OtherFees
        {
            get { return "FCID03"; }
        }

        public static String LaboratoryFees
        {
            get { return "FCID04"; }
        }
    }

    [Serializable()]
    public enum LifeStatus
    {
        Living = 1,
        Deceased = 2
    }

    [Serializable()]
    public enum Sex
    {
        Male = 1,
        Female = 2
    }

    [Serializable()]
    public enum SchoolFeeCategoryNo
    {
        TuitionFee = 1,
        MiscellaneousFees = 2,
        OtherFees = 3,
        LaboratoryFees = 4
    }

    #endregion
}
