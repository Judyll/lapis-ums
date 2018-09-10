using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CommonExchange
{
    #region Common Structure Exchange

    [Serializable()]
    public class RankGroup : BaseObject
    {
        public RankGroup()
        {
            _rankGroupId = String.Empty;
            _groupNo = RankGroupNo.HighSchoolGradeSchoolFaculty;
            _groupDescription = String.Empty;
        }

        public Boolean Equals(RankGroup obj)
        {
            if (base.Equals<RankGroup>(obj))
            {
                return true;
            }

            return false;
        }

        private String _rankGroupId;
        public String RankGroupId
        {
            get { return _rankGroupId; }
            set { _rankGroupId = value; }
        }

        private RankGroupNo _groupNo;
        public RankGroupNo GroupNo
        {
            get { return _groupNo; }
            set { _groupNo = value; }
        }

        private String _groupDescription;
        public String GroupDescription
        {
            get { return _groupDescription; }
            set { _groupDescription = value; }
        }
    }

    [Serializable()]
    public class EmploymentType : BaseObject
    {
        public EmploymentType()
        {
            _employmentId = String.Empty;
            _rankGroupInfo = new RankGroup();
            _typeNo = EmploymentTypeNo.GradeKinderFaculty;
            _typeDescription = String.Empty;
            _typeAcronym = String.Empty;
        }

        public Boolean Equals(EmploymentType obj)
        {
            if (base.Equals<EmploymentType>(obj) &&
                _rankGroupInfo.Equals(obj.RankGroupInfo))
            {
                return true;
            }

            return false;
        }

        private String _employmentId;
        public String EmploymentId
        {
            get { return _employmentId; }
            set { _employmentId = value; }
        }

        private RankGroup _rankGroupInfo;
        public RankGroup RankGroupInfo
        {
            get { return _rankGroupInfo; }
            set { _rankGroupInfo = value; }
        }

        private EmploymentTypeNo _typeNo;
        public EmploymentTypeNo TypeNo
        {
            get { return _typeNo; }
            set { _typeNo = value; }
        }

        private String _typeDescription;
        public String TypeDescription
        {
            get { return _typeDescription; }
            set { _typeDescription = value; }
        }

        private String _typeAcronym;
        public String TypeAcronym
        {
            get { return _typeAcronym; }
            set { _typeAcronym = value; }
        }
    }

    [Serializable()]
    public class RankLevel : BaseObject
    {
        public RankLevel()
        {
            _levelId = String.Empty;
            _rankGroupInfo = new RankGroup();
            _levelNo = 0;
            _levelDescription = String.Empty;
        }

        public Boolean Equals(RankLevel obj)
        {
            if (base.Equals<RankLevel>(obj) &&
                _rankGroupInfo.Equals(obj.RankGroupInfo))
            {
                return true;
            }

            return false;
        }

        private String _levelId;
        public String LevelId
        {
            get { return _levelId; }
            set { _levelId = value; }
        }

        private RankGroup _rankGroupInfo;
        public RankGroup RankGroupInfo
        {
            get { return _rankGroupInfo; }
            set { _rankGroupInfo = value; }
        }

        private Byte _levelNo;
        public Byte LevelNo
        {
            get { return _levelNo; }
            set { _levelNo = value; }
        }

        private String _levelDescription;
        public String LevelDescription
        {
            get { return _levelDescription; }
            set { _levelDescription = value; }
        }
    }

    [Serializable()]
    public class RankCategory : BaseObject
    {
        public RankCategory()
        {
            _categoryId = String.Empty;
            _rankLevelInfo = new RankLevel();
            _categoryNo = 0;
            _categoryDescription = String.Empty;
        }

        public Boolean Equals(RankCategory obj)
        {
            if (base.Equals<RankCategory>(obj) &&
                _rankLevelInfo.Equals(obj.RankLevelInfo))
            {
                return true;
            }

            return false;
        }

        private String _categoryId;
        public String CategoryId
        {
            get { return _categoryId; }
            set { _categoryId = value; }
        }

        private RankLevel _rankLevelInfo;
        public RankLevel RankLevelInfo
        {
            get { return _rankLevelInfo; }
            set { _rankLevelInfo = value; }
        }

        private Byte _categoryNo;
        public Byte CategoryNo
        {
            get { return _categoryNo; }
            set { _categoryNo = value; }
        }

        private String _categoryDescription;
        public String CategoryDescription
        {
            get { return _categoryDescription; }
            set { _categoryDescription = value; }
        }
    }

    [Serializable()]
    public class RankDegree : BaseObject
    {
        public RankDegree()
        {
            _degreeId = String.Empty;
            _rankCategoryInfo = new RankCategory();
            _degreeNo = 0;
            _degreeDescription = String.Empty;
        }

        public Boolean Equals(RankDegree obj)
        {
            if (base.Equals<RankDegree>(obj) &&
                _rankCategoryInfo.Equals(obj.RankCategoryInfo))
            {
                return true;
            }

            return false;
        }

        private String _degreeId;
        public String DegreeId
        {
            get { return _degreeId; }
            set { _degreeId = value; }
        }

        private RankCategory _rankCategoryInfo;
        public RankCategory RankCategoryInfo
        {
            get { return _rankCategoryInfo; }
            set { _rankCategoryInfo = value; }
        }

        private Byte _degreeNo;
        public Byte DegreeNo
        {
            get { return _degreeNo; }
            set { _degreeNo = value; }
        }

        private String _degreeDescription;
        public String DegreeDescription
        {
            get { return _degreeDescription; }
            set { _degreeDescription = value; }
        }
    }

    [Serializable()]
    public class RankSalaryRate : BaseObject
    {
        public RankSalaryRate()
        {
            _rateId = 0;
            _rankDegreeInfo = new RankDegree();
            _effectivityDate = String.Empty;
            _levelPoints = String.Empty;
            _previousRate = 0.0M;
            _increaseRate = 0.0M;
        }

        public Boolean Equals(RankSalaryRate obj)
        {
            if (base.Equals<RankSalaryRate>(obj) &&
                _rankDegreeInfo.Equals(obj.RankDegreeInfo))
            {
                return true;
            }

            return false;
        }

        private Int64 _rateId;
        public Int64 RateId
        {
            get { return _rateId; }
            set { _rateId = value; }
        }

        private RankDegree _rankDegreeInfo;
        public RankDegree RankDegreeInfo
        {
            get { return _rankDegreeInfo; }
            set { _rankDegreeInfo = value; }
        }

        private String _effectivityDate;
        public String EffectivityDate
        {
            get { return _effectivityDate; }
            set { _effectivityDate = value; }
        }

        private String _levelPoints;
        public String LevelPoints
        {
            get { return _levelPoints; }
            set { _levelPoints = value; }
        }

        private Decimal _previousRate;
        public Decimal PreviousRate
        {
            get { return _previousRate; }
            set { _previousRate = value; }
        }

        private Decimal _increaseRate;
        public Decimal IncreaseRate
        {
            get { return _increaseRate; }
            set { _increaseRate = value; }
        }
    }

    [Serializable()]
    public class SssInformation : BaseObject
    {
        public SssInformation()
        {
            _sssId = String.Empty;
            _effectivityDate = String.Empty;
        }

        public Boolean Equals(SssInformation obj)
        {
            if (base.Equals<SssInformation>(obj))
            {
                return true;
            }

            return false;
        }

        private String _sssId;
        public String SssId
        {
            get { return _sssId; }
            set { _sssId = value; }
        }

        private String _effectivityDate;
        public String EffectivityDate
        {
            get { return _effectivityDate; }
            set { _effectivityDate = value; }
        }
    }

    [Serializable()]
    public class SssRange : BaseObject
    {
        public SssRange()
        {
            _rangeId = 0;
            _sssInfo = new SssInformation();
            _minimumSalary = 0.0M;
            _maximumSalary = 0.0M;
            _contribution = 0.0M;
        }

        public Boolean Equals(SssRange obj)
        {
            if (base.Equals<SssRange>(obj) &&
                _sssInfo.Equals(obj.SssInfo))
            {
                return true;
            }

            return false;
        }

        private Int64 _rangeId;
        public Int64 RangeId
        {
            get { return _rangeId; }
            set { _rangeId = value; }
        }

        private SssInformation _sssInfo;
        public SssInformation SssInfo
        {
            get { return _sssInfo; }
            set { _sssInfo = value; }
        }

        private Decimal _minimumSalary;
        public Decimal MinimumSalary
        {
            get { return _minimumSalary; }
            set { _minimumSalary = value; }
        }

        private Decimal _maximumSalary;
        public Decimal MaximumSalary
        {
            get { return _maximumSalary; }
            set { _maximumSalary = value; }
        }

        private Decimal _contribution;
        public Decimal Contribution
        {
            get { return _contribution; }
            set { _contribution = value; }
        }
    }

    [Serializable()]
    public class PhilHealthInformation : BaseObject
    {
        public PhilHealthInformation()
        {
            _philHealthId = String.Empty;
            _effectivityDate = String.Empty;
        }

        public Boolean Equals(PhilHealthInformation obj)
        {
            if (base.Equals<PhilHealthInformation>(obj))
            {
                return true;
            }

            return false;
        }

        private String _philHealthId;
        public String PhilHealthId
        {
            get { return _philHealthId; }
            set { _philHealthId = value; }
        }

        private String _effectivityDate;
        public String EffectivityDate
        {
            get { return _effectivityDate; }
            set { _effectivityDate = value; }
        }
    }

    [Serializable()]
    public class PhilHealthRange : BaseObject
    {
        public PhilHealthRange()
        {
            _rangeId = 0;
            _philHealthInfo = new PhilHealthInformation();
            _minimumSalary = 0.0M;
            _maximumSalary = 0.0M;
            _contribution = 0.0M;
        }

        public Boolean Equals(PhilHealthRange obj)
        {
            if (base.Equals<PhilHealthRange>(obj) &&
                _philHealthInfo.Equals(obj.PhilHealthInfo))
            {
                return true;
            }

            return false;

        }

        private Int64 _rangeId;
        public Int64 RangeId
        {
            get { return _rangeId; }
            set { _rangeId = value; }
        }

        private PhilHealthInformation _philHealthInfo;
        public PhilHealthInformation PhilHealthInfo
        {
            get { return _philHealthInfo; }
            set { _philHealthInfo = value; }
        }

        private Decimal _minimumSalary;
        public Decimal MinimumSalary
        {
            get { return _minimumSalary; }
            set { _minimumSalary = value; }
        }

        private Decimal _maximumSalary;
        public Decimal MaximumSalary
        {
            get { return _maximumSalary; }
            set { _maximumSalary = value; }
        }

        private Decimal _contribution;
        public Decimal Contribution
        {
            get { return _contribution; }
            set { _contribution = value; }
        }
       
    }

    [Serializable()]
    public class WeekDay : BaseObject
    {
        public WeekDay()
        {
            _weekId = DayOfWeek.Sunday;
            _weekDescription = String.Empty;
            _acronym = String.Empty;
        }

        public Boolean Equals(WeekDay obj)
        {
            if (base.Equals<WeekDay>(obj))
            {
                return true;
            }

            return false;
        }

        private DayOfWeek _weekId;
        public DayOfWeek WeekId
        {
            get { return _weekId; }
            set { _weekId = value; }
        }

        private String _weekDescription;
        public String WeekDescription
        {
            get { return _weekDescription; }
            set { _weekDescription = value; }
        }

        private String _acronym;
        public String Acronym
        {
            get { return _acronym; }
            set { _acronym = value; }
        }
    }

    [Serializable()]
    public class EmployeeStatus : BaseObject
    {
        public EmployeeStatus()
        {
            _statusId = 0;
            _statusDescription = String.Empty;
        }

        public Boolean Equals(EmployeeStatus obj)
        {
            if (base.Equals<EmployeeStatus>(obj))
            {
                return true;
            }

            return false;
        }

        private Byte _statusId;
        public Byte StatusId
        {
            get { return _statusId; }
            set { _statusId = value; }
        }

        private String _statusDescription;
        public String StatusDescription
        {
            get { return _statusDescription; }
            set { _statusDescription = value; }
        }
    }

    [Serializable()]
    public class Employee : BaseObject
    {
        public Employee()
        {
            _employeeSysId = String.Empty;
            _personInfo = new Person();
            _employeeId = String.Empty;
            _cardNumber = String.Empty;
            _pagibigMembershipId = String.Empty;
            _sssMembershipId = String.Empty;
            _philHealthMembershipId = String.Empty;
            _otherEmployeeInformation = String.Empty;
            _salaryInfo = new SalaryInformation();
        }

        public Boolean Equals(Employee obj)
        {
            if (base.Equals<Employee>(obj) &&
                _personInfo.Equals(obj.PersonInfo) &&
                _salaryInfo.Equals(obj.SalaryInfo))
            {
                return true;
            }

            return false;
        }

        private String _employeeSysId;
        public String EmployeeSysId
        {
            get { return _employeeSysId; }
            set { _employeeSysId = value; }
        }

        private Person _personInfo;
        public Person PersonInfo
        {
            get { return _personInfo; }
            set { _personInfo = value; }
        }

        private String _employeeId;
        public String EmployeeId
        {
            get { return _employeeId; }
            set { _employeeId = value; }
        }

        private String _cardNumber;
        public String CardNumber
        {
            get { return _cardNumber; }
            set { _cardNumber = value; }
        }

        private String _pagibigMembershipId;
        public String PagibigMembershipId
        {
            get { return _pagibigMembershipId; }
            set { _pagibigMembershipId = value; }
        }

        private String _sssMembershipId;
        public String SssMembershipId
        {
            get { return _sssMembershipId; }
            set { _sssMembershipId = value; }
        }

        private String _philHealthMembershipId;
        public String PhilHealthMembershipId
        {
            get { return _philHealthMembershipId; }
            set { _philHealthMembershipId = value; }
        }

        private String _otherEmployeeInformation;
        public String OtherEmployeeInformation
        {
            get { return _otherEmployeeInformation; }
            set { _otherEmployeeInformation = value; }
        }

        private SalaryInformation _salaryInfo;
        public SalaryInformation SalaryInfo
        {
            get { return _salaryInfo; }
            set { _salaryInfo = value; }
        }

    }

    [Serializable()]
    public class SalaryInformation : BaseObject
    {
        public SalaryInformation()
        {
            _salaryId = 0;
            _effectivityDate = String.Empty;
            _employmentTypeInfo = new EmploymentType();
            _departmentInfo = new Department();
            _employeeStatusInfo = new EmployeeStatus();
            _rankLevelInfo = new RankLevel();
            _rankCategoryInfo = new RankCategory();
            _rankDegreeInfo = new RankDegree();
            _rankDegreeLevelPointsInfo = new RankDegree();
            _rankSalaryRateInfo = new RankSalaryRate();
            _isFixedLogInOut = false;
            _firstIn = String.Empty;
            _firstOut = String.Empty;
            _secondIn = String.Empty;
            _secondOut = String.Empty;
            _restDay = new WeekDay();
        }

        public Boolean Equals(SalaryInformation obj)
        {
            if (base.Equals<SalaryInformation>(obj) &&
                _employmentTypeInfo.Equals(obj.EmploymentTypeInfo) &&
                _departmentInfo.Equals(obj.DepartmentInfo) &&
                _employeeStatusInfo.Equals(obj.EmployeeStatusInfo) &&
                _rankLevelInfo.Equals(obj.RankLevelInfo) &&
                _rankCategoryInfo.Equals(obj.RankCategoryInfo) &&
                _rankDegreeInfo.Equals(obj.RankDegreeInfo) &&
                _rankDegreeLevelPointsInfo.Equals(obj.RankDegreeLevelPointsInfo) &&
                _rankSalaryRateInfo.Equals(obj.RankSalaryRateInfo) &&
                _restDay.Equals(obj.RestDay))
            {
                return true;
            }

            return false;
        }

        private Int64 _salaryId;
        public Int64 SalaryId
        {
            get { return _salaryId; }
            set { _salaryId = value; }
        }

        private String _effectivityDate;
        public String EffectivityDate
        {
            get { return _effectivityDate; }
            set { _effectivityDate = value; }
        }

        private EmploymentType _employmentTypeInfo;
        public EmploymentType EmploymentTypeInfo
        {
            get { return _employmentTypeInfo; }
            set { _employmentTypeInfo = value; }
        }

        private Department _departmentInfo;
        public Department DepartmentInfo
        {
            get { return _departmentInfo; }
            set { _departmentInfo = value; }
        }

        private EmployeeStatus _employeeStatusInfo;
        public EmployeeStatus EmployeeStatusInfo
        {
            get { return _employeeStatusInfo; }
            set { _employeeStatusInfo = value; }
        }

        private RankLevel _rankLevelInfo;
        public RankLevel RankLevelInfo
        {
            get { return _rankLevelInfo; }
            set { _rankLevelInfo = value; }
        }

        private RankCategory _rankCategoryInfo;
        public RankCategory RankCategoryInfo
        {
            get { return _rankCategoryInfo; }
            set { _rankCategoryInfo = value; }
        }

        private RankDegree _rankDegreeInfo;
        public RankDegree RankDegreeInfo
        {
            get { return _rankDegreeInfo; }
            set { _rankDegreeInfo = value; }
        }

        private RankDegree _rankDegreeLevelPointsInfo;
        public RankDegree RankDegreeLevelPointsInfo
        {
            get { return _rankDegreeLevelPointsInfo; }
            set { _rankDegreeLevelPointsInfo = value; }
        }

        private RankSalaryRate _rankSalaryRateInfo;
        public RankSalaryRate RankSalaryRateInfo
        {
            get { return _rankSalaryRateInfo; }
            set { _rankSalaryRateInfo = value; }
        }

        private Boolean _isFixedLogInOut;
        public Boolean IsFixedLogInOut
        {
            get { return _isFixedLogInOut; }
            set { _isFixedLogInOut = value; }
        }

        private String _firstIn;
        public String FirstIn
        {
            get { return _firstIn; }
            set { _firstIn = value; }
        }

        private String _firstOut;
        public String FirstOut
        {
            get { return _firstOut; }
            set { _firstOut = value; }
        }

        private String _secondIn;
        public String SecondIn
        {
            get { return _secondIn; }
            set { _secondIn = value; }
        }

        private String _secondOut;
        public String SecondOut
        {
            get { return _secondOut; }
            set { _secondOut = value; }
        }

        private WeekDay _restDay;
        public WeekDay RestDay
        {
            get { return _restDay; }
            set { _restDay = value; }
        }
    }

    [Serializable()]
    public class DeductionInformation : BaseObject
    {
        public DeductionInformation()
        {
            _deductionSysId = String.Empty;
            _deductionId = 0;
            _deductionDate = String.Empty;
            _employeeInfo = new Employee();
            _description = String.Empty;
            _amount = 0.0M;
        }

        public Boolean Equals(DeductionInformation obj)
        {
            if (base.Equals<DeductionInformation>(obj) &&
                _employeeInfo.Equals(obj.EmployeeInfo))
            {
                return true;
            }

            return false;
        }

        private String _deductionSysId;
        public String DeductionSysId
        {
            get { return _deductionSysId; }
            set { _deductionSysId = value; }
        }

        private Int64 _deductionId;
        public Int64 DeductionId
        {
            get { return _deductionId; }
            set { _deductionId = value; }
        }

        private String _deductionDate;
        public String DeductionDate
        {
            get { return _deductionDate; }
            set { _deductionDate = value; }
        }

        private Employee _employeeInfo;
        public Employee EmployeeInfo
        {
            get { return _employeeInfo; }
            set { _employeeInfo = value; }
        }

        private String _description;
        public String Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private Decimal _amount;
        public Decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
    }

    [Serializable()]
    public class EarningInformation : BaseObject
    {
        public EarningInformation()
        {
            _earningSysId = String.Empty;
            _earningId = 0;
            _employeeInfo = new Employee();
            _earningDate = String.Empty;
            _description = String.Empty;
            _amount = 0.0M;
        }

        public Boolean Equals(EarningInformation obj)
        {
            if (base.Equals<EarningInformation>(obj) &&
                _employeeInfo.Equals(obj.EmployeeInfo))
            {
                return true;
            }

            return false;
        }

        private String _earningSysId;
        public String EarningSysId
        {
            get { return _earningSysId; }
            set { _earningSysId = value; }
        }

        private Int64 _earningId;
        public Int64 EarningId
        {
            get { return _earningId; }
            set { _earningId = value; }
        }

        private Employee _employeeInfo;
        public Employee EmployeeInfo
        {
            get { return _employeeInfo; }
            set { _employeeInfo = value; }
        }

        private String _earningDate;
        public String EarningDate
        {
            get { return _earningDate; }
            set { _earningDate = value; }
        }

        private String _description;
        public String Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private Decimal _amount;
        public Decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }
    }

    [Serializable()]
    public class LoanInformation : BaseObject
    {
        public LoanInformation()
        {
            _loanSysId = String.Empty;
            _description = String.Empty;
            _remittanceSysId = String.Empty;
            _employeeInfo = new Employee();
            _referenceNo = String.Empty;
            _releaseDate = String.Empty;
            _maturityDate = String.Empty;
            _principalInterest = 0.0M;
            _monthlyAmmortization = 0.0M;
        }

        public Boolean Equals(LoanInformation obj)
        {
            if (base.Equals<LoanInformation>(obj) &&
                _employeeInfo.Equals(obj.EmployeeInfo))
            {
                return true;
            }

            return false;
        }

        private String _loanSysId;
        public String LoanSysId
        {
            get { return _loanSysId; }
            set { _loanSysId = value; }
        }

        private String _description;
        public String Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private String _remittanceSysId;
        public String RemittanceSysId
        {
            get { return _remittanceSysId; }
            set { _remittanceSysId = value; }
        }

        private Employee _employeeInfo;
        public Employee EmployeeInfo
        {
            get { return _employeeInfo; }
            set { _employeeInfo = value; }
        }

        private String _referenceNo;
        public String ReferenceNo
        {
            get { return _referenceNo; }
            set { _referenceNo = value; }
        }

        private String _releaseDate;
        public String ReleaseDate
        {
            get { return _releaseDate; }
            set { _releaseDate = value; }
        }

        private String _maturityDate;
        public String MaturityDate
        {
            get { return _maturityDate; }
            set { _maturityDate = value; }
        }

        private Decimal _principalInterest;
        public Decimal PrincipalInterest
        {
            get { return _principalInterest; }
            set { _principalInterest = value; }
        }

        private Decimal _monthlyAmmortization;
        public Decimal MonthlyAmmortization
        {
            get { return _monthlyAmmortization; }
            set { _monthlyAmmortization = value; }
        }
    }

    [Serializable()]
    public class EmployeeLoanRemittance : BaseObject
    {
        public EmployeeLoanRemittance()
        {
            _remittanceId = 0;
            _loanInfo = new LoanInformation();
            _remittanceDate = String.Empty;
            _payMonth = 0;
            _payBalance = 0;
            _amountPaid = 0.0M;
            _amountBalance = 0.0M;
        }

        public Boolean Equals(EmployeeLoanRemittance obj)
        {
            if (base.Equals<EmployeeLoanRemittance>(obj) &&
                _loanInfo.Equals(obj.LoanInfo))
            {
                return true;
            }

            return false;
        }

        private Int64 _remittanceId;
        public Int64 RemittanceId
        {
            get { return _remittanceId; }
            set { _remittanceId = value; }
        }

        private LoanInformation _loanInfo;
        public LoanInformation LoanInfo
        {
            get { return _loanInfo; }
            set { _loanInfo = value; }
        }

        private String _remittanceDate;
        public String RemittanceDate
        {
            get { return _remittanceDate; }
            set { _remittanceDate = value; }
        }

        private Int16 _payMonth;
        public Int16 PayMonth
        {
            get { return _payMonth; }
            set { _payMonth = value; }
        }

        private Int16 _payBalance;
        public Int16 PayBalance
        {
            get { return _payBalance; }
            set { _payBalance = value; }
        }

        private Decimal _amountPaid;
        public Decimal AmountPaid
        {
            get { return _amountPaid; }
            set { _amountPaid = value; }
        }

        private Decimal _amountBalance;
        public Decimal AmountBalance
        {
            get { return _amountBalance; }
            set { _amountBalance = value; }
        }
    }

    [Serializable()]
    public enum EmploymentTypeNo
    {
        GraduateSchoolFaculty = 1,
        GraduateSchoolCollegeFaculty = 2,
        GraduateSchoolHighSchoolFaculty = 3,
        GraduateSchoolGradeKinderFaculty = 4,
        CollegeFaculty = 5,
        HighSchoolFaculty = 6,
        GradeKinderFaculty = 7,
        NonTeachingStaff = 8,
        AcademicNonTeaching = 9,
        Maintenance = 10
    }

    [Serializable()]
    public enum EmploymentStatusNo
    {
        TemporaryPartTime = 1,
        Probationary = 2,
        Regular = 3,
        LayOff = 4
    }

    [Serializable()]
    public enum RankGroupNo
    {
        CollegeFaculty = 1,
        HighSchoolGradeSchoolFaculty = 2,
        StaffAcademicNonTeaching = 3,
        Maintenance = 4
    }

    #endregion
}
