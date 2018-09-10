using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace CommonExchange
{
    #region Common Exchange Structure

    [Serializable()]
    public class SchoolYear : BaseObject
    {
        public SchoolYear()
        {
            _yearId = String.Empty;
            _description = String.Empty;
            _dateStart = String.Empty;
            _dateEnd = String.Empty;
            _isSummer = false;
        }

        public Boolean Equals(SchoolYear obj)
        {
            if (base.Equals<SchoolYear>(obj))
            {
                return true;
            }

            return false;
        }

        private String _yearId;
        public String YearId
        {
            get { return _yearId; }
            set { _yearId = value; }
        }

        private String _description;
        public String Description
        {
            get { return _description; }
            set { _description = value; }
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

        private Boolean _isSummer;
        public Boolean IsSummer
        {
            get { return _isSummer; }
            set { _isSummer = value; }
        }
    }

    [Serializable()]
    public class SemesterInformation : BaseObject
    {
        public SemesterInformation()
        {
            _semesterSysId = String.Empty;
            _schoolYearInfo = new SchoolYear();
            _semesterId = 0;
            _dateStart = String.Empty;
            _dateEnd = String.Empty;
            _schoolYearDescription = String.Empty;
            _schoolSemesterDescription = String.Empty;
        }

        public Boolean Equals(SemesterInformation obj)
        {
            if (base.Equals<SemesterInformation>(obj) &&
                _schoolYearInfo.Equals(obj.SchoolYearInfo))
            {
                return true;
            }

            return false;
        }

        private String _semesterSysId;
        public String SemesterSysId
        {
            get { return _semesterSysId; }
            set { _semesterSysId = value; }
        }

        private SchoolYear _schoolYearInfo;
        public SchoolYear SchoolYearInfo
        {
            get { return _schoolYearInfo; }
            set { _schoolYearInfo = value; }
        }

        private Byte _semesterId;
        public Byte SemesterId
        {
            get { return _semesterId; }
            set { _semesterId = value; }
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

        private String _schoolYearDescription;
        public String SchoolYearDescription
        {
            get { return _schoolYearDescription; }
            set { _schoolYearDescription = value; }
        }

        private String _schoolSemesterDescription;
        public String SchoolSemesterDescription
        {
            get { return _schoolSemesterDescription; }
            set { _schoolSemesterDescription = value; }
        }
    }

    [Serializable()]
    public class ClassroomInformation : BaseObject
    {
        public ClassroomInformation()
        {
            _classroomSysId = String.Empty;
            _classroomCode = String.Empty;
            _description = String.Empty;
            _maximumCapacity = 0;
            _otherInformation = String.Empty;
        }

        public Boolean Equals(ClassroomInformation obj)
        {
            if (base.Equals<ClassroomInformation>(obj))
            {
                return true;
            }

            return false;
        }

        private String _classroomSysId;
        public String ClassroomSysId
        {
            get { return _classroomSysId; }
            set { _classroomSysId = value; }
        }

        private String _classroomCode;
        public String ClassroomCode
        {
            get { return _classroomCode; }
            set { _classroomCode = value; }
        }

        private String _description;
        public String Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private Byte _maximumCapacity;
        public Byte MaximumCapacity
        {
            get { return _maximumCapacity; }
            set { _maximumCapacity = value; }
        }

        private String _otherInformation;
        public String OtherInformation
        {
            get { return _otherInformation; }
            set { _otherInformation = value; }
        }
    }

    [Serializable()]
    public class SubjectCategory : BaseObject
    {
        public SubjectCategory()
        {
            _categoryId = String.Empty;
            _categoryName = String.Empty;
            _acronym = String.Empty;
            _categoryNo = 0;
        }

        public Boolean Equals(SubjectCategory obj)
        {
            if (base.Equals<SubjectCategory>(obj))
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

        private String _categoryName;
        public String CategoryName
        {
            get { return _categoryName; }
            set { _categoryName = value; }
        }

        private String _acronym;
        public String Acronym
        {
            get { return _acronym; }
            set { _acronym = value; }
        }

        private Byte _categoryNo;
        public Byte CategoryNo
        {
            get { return _categoryNo; }
            set { _categoryNo = value; }
        }

        public static String LanguageId
        {
            get { return "CAT001"; }
        }

        public static String CompMathScienceId
        {
            get { return "CAT002"; }
        }

        public static String MandatedId
        {
            get { return "CAT003"; }
        }

        public static String SocialScienceId
        {
            get { return "CAT004"; }
        }

        public static String BusinessEdId
        {
            get { return "CAT005"; }
        }

        public static String ProfessionalId
        {
            get { return "CAT006"; }
        }

        public static String PhysicalEdId
        {
            get { return "CAT007"; }
        }

        public static String OthersId
        {
            get { return "CAT008"; }
        }
    }

    [Serializable()]
    public class SubjectInformation : BaseObject
    {
        public SubjectInformation()
        {
            _subjectSysId = String.Empty;
            _courseGroupInfo = new CourseGroup();
            _departmentInfo = new Department();
            _categoryInfo = new SubjectCategory();
            _subjectCode = String.Empty;
            _descriptiveTitle = String.Empty;
            _lectureUnits = 0;
            _labUnits = 0;
            _noHours = String.Empty;
            _otherInformation = String.Empty;
            _isNonAcademic = false;
            _isOpenAccess = false;
        }

        public Boolean Equals(SubjectInformation obj)
        {
            if (base.Equals<SubjectInformation>(obj) &&
                _courseGroupInfo.Equals(obj.CourseGroupInfo) &&
                _departmentInfo.Equals(obj.DepartmentInfo) &&
                _categoryInfo.Equals(obj.CategoryInfo))
            {
                return true;
            }

            return false;
        }

        private String _subjectSysId;
        public String SubjectSysId
        {
            get { return _subjectSysId; }
            set { _subjectSysId = value; }
        }

        private CourseGroup _courseGroupInfo;
        public CourseGroup CourseGroupInfo
        {
            get { return _courseGroupInfo; }
            set { _courseGroupInfo = value; }
        }

        private Department _departmentInfo;
        public Department DepartmentInfo
        {
            get { return _departmentInfo; }
            set { _departmentInfo = value; }
        }

        private SubjectCategory _categoryInfo;
        public SubjectCategory CategoryInfo
        {
            get { return _categoryInfo; }
            set { _categoryInfo = value; }
        }

        private String _subjectCode;
        public String SubjectCode
        {
            get { return _subjectCode; }
            set { _subjectCode = value; }
        }

        private String _descriptiveTitle;
        public String DescriptiveTitle
        {
            get { return _descriptiveTitle; }
            set { _descriptiveTitle = value; }
        }

        private Byte _lectureUnits;
        public Byte LectureUnits
        {
            get { return _lectureUnits; }
            set { _lectureUnits = value; }
        }

        private Byte _labUnits;
        public Byte LabUnits
        {
            get { return _labUnits; }
            set { _labUnits = value; }
        }

        private String _noHours;
        public String NoHours
        {
            get { return _noHours; }
            set { _noHours = value; }
        }

        private String _otherInformation;
        public String OtherInformation
        {
            get { return _otherInformation; }
            set { _otherInformation = value; }
        }

        private Boolean _isNonAcademic;
        public Boolean IsNonAcademic
        {
            get { return _isNonAcademic; }
            set { _isNonAcademic = value; }
        }

        private Boolean _isOpenAccess;
        public Boolean IsOpenAccess
        {
            get { return _isOpenAccess; }
            set { _isOpenAccess = value; }
        }        

    }

    [Serializable()]
    public class SubjectPreRequisite : BaseObject
    {
        public SubjectPreRequisite()
        {
            _preRequisiteId = 0;
            _subjectSysId = String.Empty;
            _preRequisiteSubject = String.Empty;
        }

        public Boolean Equals(SubjectPreRequisite obj)
        {
            if (base.Equals<SubjectPreRequisite>(obj))
            {
                return true;
            }

            return false;
        }

        private Int64 _preRequisiteId;
        public Int64 PreRequisiteId
        {
            get { return _preRequisiteId; }
            set { _preRequisiteId = value; }
        }

        private String _subjectSysId;
        public String SubjectSysId
        {
            get { return _subjectSysId; }
            set { _subjectSysId = value; }
        }

        private String _preRequisiteSubject;
        public String PreRequisiteSubject
        {
            get { return _preRequisiteSubject; }
            set { _preRequisiteSubject = value; }
        }
    }

    [Serializable()]
    public class CourseInformation : BaseObject
    {
        public CourseInformation()
        {
            _courseId = String.Empty;
            _courseGroupInfo = new CourseGroup();
            _departmentInfo = new Department();
            _courseTitle = String.Empty;
            _acronym = String.Empty;
            _isStillOffered = false;
        }

        public Boolean Equals(CourseInformation obj)
        {
            if (base.Equals<CourseInformation>(obj) &&
                _courseGroupInfo.Equals(obj.CourseGroupInfo) &&
                _departmentInfo.Equals(obj.DepartmentInfo))
            {
                return true;
            }

            return false;
        }

        private String _courseId;
        public String CourseId
        {
            get { return _courseId; }
            set { _courseId = value; }
        }

        private CourseGroup _courseGroupInfo;
        public CourseGroup CourseGroupInfo
        {
            get { return _courseGroupInfo; }
            set { _courseGroupInfo = value; }
        }

        private Department _departmentInfo;
        public Department DepartmentInfo
        {
            get { return _departmentInfo; }
            set { _departmentInfo = value; }
        }

        private String _courseTitle;
        public String CourseTitle
        {
            get { return _courseTitle; }
            set { _courseTitle = value; }
        }

        private String _acronym;
        public String Acronym
        {
            get { return _acronym; }
            set { _acronym = value; }
        }

        private Boolean _isStillOffered;
        public Boolean IsStillOffered
        {
            get { return _isStillOffered; }
            set { _isStillOffered = value; }
        }
    }

    [Serializable()]
    public class CourseYearLevel : BaseObject
    {
        public CourseYearLevel()
        {
            _courseYearLevelId = String.Empty;
            _courseInfo = new CourseInformation();
            _courseGroupInfo = new CourseGroup();
            _yearLevelInfo = new YearLevelInformation();
            _isGraduateLevel = false;
        }

        public Boolean Equals(CourseYearLevel obj)
        {
            if (base.Equals<CourseYearLevel>(obj) &&
                _courseInfo.Equals(obj.CourseInfo) &&
                _courseGroupInfo.Equals(obj.CourseGroupInfo) &&
                _yearLevelInfo.Equals(obj.YearLevelInfo))
            {
                return true;
            }

            return false;
        }

        private String _courseYearLevelId;
        public String CourseYearLevelId
        {
            get { return _courseYearLevelId; }
            set { _courseYearLevelId = value; }
        }

        private CourseInformation _courseInfo;
        public CourseInformation CourseInfo
        {
            get { return _courseInfo; }
            set { _courseInfo = value; }
        }

        private CourseGroup _courseGroupInfo;
        public CourseGroup CourseGroupInfo
        {
            get { return _courseGroupInfo; }
            set { _courseGroupInfo = value; }
        }

        private YearLevelInformation _yearLevelInfo;
        public YearLevelInformation YearLevelInfo
        {
            get { return _yearLevelInfo; }
            set { _yearLevelInfo = value; }
        }

        private Boolean _isGraduateLevel;
        public Boolean IsGraduateLevel
        {
            get { return _isGraduateLevel; }
            set { _isGraduateLevel = value; }
        }

    }

    [Serializable()]
    public class CourseMajorInformation : BaseObject
    {
        public CourseMajorInformation()
        {
            _majorInformationId = String.Empty;
            _courseInfo = new CourseInformation();
            _courseMajorTitle = String.Empty;
            _acronym = String.Empty;
            _isStillOffered = false;
        }

        public Boolean Equals(CourseMajorInformation obj)
        {
            if (base.Equals<CourseMajorInformation>(obj) &&
                _courseInfo.Equals(obj.CourseInfo))
            {
                return true;
            }

            return false;
        }

        private String _majorInformationId;
        public String MajorInformationId
        {
            get { return _majorInformationId; }
            set { _majorInformationId = value; }
        }

        private CourseInformation _courseInfo;
        public CourseInformation CourseInfo
        {
            get { return _courseInfo; }
            set { _courseInfo = value; }
        }

        private String _courseMajorTitle;
        public String CourseMajorTitle
        {
            get { return _courseMajorTitle; }
            set { _courseMajorTitle = value; }
        }

        private String _acronym;
        public String Acronym
        {
            get { return _acronym; }
            set { _acronym = value; }
        }

        private Boolean _isStillOffered;
        public Boolean IsStillOffered
        {
            get { return _isStillOffered; }
            set { _isStillOffered = value; }
        }
    }

    [Serializable()]
    public class EnrolmentCourseMajor : BaseObject
    {
        public EnrolmentCourseMajor()
        {
            _courseMajorId = 0;
            _courseMajorInfo = new CourseMajorInformation();
            _isCurrentMajor = false;
        }

        public Boolean Equals(EnrolmentCourseMajor obj)
        {
            if (base.Equals<EnrolmentCourseMajor>(obj) &&
                _courseMajorInfo.Equals(obj.CourseMajorInfo))
            {
                return true;
            }

            return false;
        }

        private Int64 _courseMajorId;
        public Int64 CourseMajorId
        {
            get { return _courseMajorId; }
            set { _courseMajorId = value; }
        }

        private CourseMajorInformation _courseMajorInfo;
        public CourseMajorInformation CourseMajorInfo
        {
            get { return _courseMajorInfo; }
            set { _courseMajorInfo = value; }
        }

        private Boolean _isCurrentMajor;
        public Boolean IsCurrentMajor
        {
            get { return _isCurrentMajor; }
            set { _isCurrentMajor = value; }
        }        
    }

    [Serializable()]
    public class SpecialClassInformation : BaseObject
    {
        public SpecialClassInformation()
        {
            _specialClassSysId = String.Empty;
            _subjectSysId = String.Empty;
            _employeeSysId = String.Empty;
            _yearId = String.Empty;
            _semesterSysId = String.Empty;
            _isSemestral = false;
            _amount = 0.0M;
            _isMarkedDeleted = false;
            _departmentId = String.Empty;
            _subjectCode = String.Empty;
            _descriptiveTitle = String.Empty;
            _lectureUnits = 0;
            _labUnits = 0;
            _noHours = String.Empty;
            _employeeId = String.Empty;
            _lastName = String.Empty;
            _firstName = String.Empty;
            _middleName = String.Empty;
            _typeDescription = String.Empty;
            _statusDescription = String.Empty;
            _subjectDepartmentName = String.Empty;
            _employeeDepartmentName = String.Empty;
        }

        public Boolean Equals(SpecialClassInformation obj)
        {
            if (base.Equals<SpecialClassInformation>(obj))
            {
                return true;
            }

            return false;
        }

        private String _specialClassSysId;
        public String SpecialClassSysId
        {
            get { return _specialClassSysId; }
            set { _specialClassSysId = value; }
        }

        private String _subjectSysId;
        public String SubjectSysId
        {
            get { return _subjectSysId; }
            set { _subjectSysId = value; }
        }

        private String _employeeSysId;
        public String EmployeeSysId
        {
            get { return _employeeSysId; }
            set { _employeeSysId = value; }
        }

        private String _yearId;
        public String YearId
        {
            get { return _yearId; }
            set { _yearId = value; }
        }

        private String _semesterSysId;
        public String SemesterSysId
        {
            get { return _semesterSysId; }
            set { _semesterSysId = value; }
        }

        private Boolean _isSemestral;
        public Boolean IsSemestral
        {
            get { return _isSemestral; }
            set { _isSemestral = value; }
        }

        private Decimal _amount;
        public Decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        private Boolean _isMarkedDeleted;
        public Boolean IsMarkedDeleted
        {
            get { return _isMarkedDeleted; }
            set { _isMarkedDeleted = value; }
        }

        private String _departmentId;
        public String DepartmentId
        {
            get { return _departmentId; }
            set { _departmentId = value; }
        }

        private String _subjectCode;
        public String SubjectCode
        {
            get { return _subjectCode; }
            set { _subjectCode = value; }
        }

        private String _descriptiveTitle;
        public String DescriptiveTitle
        {
            get { return _descriptiveTitle; }
            set { _descriptiveTitle = value; }
        }

        private Byte _lectureUnits;
        public Byte LectureUnits
        {
            get { return _lectureUnits; }
            set { _lectureUnits = value; }
        }

        private Byte _labUnits;
        public Byte LabUnits
        {
            get { return _labUnits; }
            set { _labUnits = value; }
        }

        private String _noHours;
        public String NoHours
        {
            get { return _noHours; }
            set { _noHours = value; }
        }

        private String _employeeId;
        public String EmployeeId
        {
            get { return _employeeId; }
            set { _employeeId = value; }
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

        private String _typeDescription;
        public String TypeDescription
        {
            get { return _typeDescription; }
            set { _typeDescription = value; }
        }

        private String _statusDescription;
        public String StatusDescription
        {
            get { return _statusDescription; }
            set { _statusDescription = value; }
        }

        private String _subjectDepartmentName;
        public String SubjectDepartmentName
        {
            get { return _subjectDepartmentName; }
            set { _subjectDepartmentName = value; }
        }

        private String _employeeDepartmentName;
        public String EmployeeDepartmentName
        {
            get { return _employeeDepartmentName; }
            set { _employeeDepartmentName = value; }
        }
    }

    [Serializable()]
    public class MajorExamSchedule : BaseObject
    {
        public MajorExamSchedule()
        {
            _majorExamId = 0;
            _yearId = String.Empty;
            _semesterSysId = String.Empty;
            _examInformationId = String.Empty;
            _examDate = String.Empty;
            _examDescription = String.Empty;
            _courseGroupId = String.Empty;
            _groupDescription = String.Empty;
            _groupNo = 0;
            _isSemestral = false;
        }

        public Boolean Equals(MajorExamSchedule obj)
        {
            if (base.Equals<MajorExamSchedule>(obj))
            {
                return true;
            }

            return false;
        }

        private Int64 _majorExamId;
        public Int64 MajorExamId
        {
            get { return _majorExamId; }
            set { _majorExamId = value; }
        }

        private String _yearId;
        public String YearId
        {
            get { return _yearId; }
            set { _yearId = value; }
        }

        private String _semesterSysId;
        public String SemesterSysId
        {
            get { return _semesterSysId; }
            set { _semesterSysId = value; }
        }

        private String _examInformationId;
        public String ExamInformationId
        {
            get { return _examInformationId; }
            set { _examInformationId = value; }
        }

        private String _examDate;
        public String ExamDate
        {
            get { return _examDate; }
            set { _examDate = value; }
        }

        private String _examDescription;
        public String ExamDescription
        {
            get { return _examDescription; }
            set { _examDescription = value; }
        }

        private String _courseGroupId;
        public String CourseGroupId
        {
            get { return _courseGroupId; }
            set { _courseGroupId = value; }
        }

        private String _groupDescription;
        public String GroupDescription
        {
            get { return _groupDescription; }
            set { _groupDescription = value; }
        }

        private Byte _groupNo;
        public Byte GroupNo
        {
            get { return _groupNo; }
            set { _groupNo = value; }
        }

        private Boolean _isSemestral;
        public Boolean IsSemestral
        {
            get { return _isSemestral; }
            set { _isSemestral = value; }
        }


    }

    [Serializable()]
    public class CourseGroup : BaseObject
    {
        public CourseGroup()
        {
            _courseGroupId = String.Empty;
            _groupNo = 0;
            _groupDescription = String.Empty;
            _isSemestral = false;
            _isPerUnit = false;
        }

        public Boolean Equals(CourseGroup obj)
        {
            if (base.Equals<CourseGroup>(obj))
            {
                return true;
            }

            return false;
        }

        private String _courseGroupId;
        public String CourseGroupId
        {
            get { return _courseGroupId; }
            set { _courseGroupId = value; }
        }

        private Byte _groupNo;
        public Byte GroupNo
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

        private Boolean _isSemestral;
        public Boolean IsSemestral
        {
            get { return _isSemestral; }
            set { _isSemestral = value; }
        }

        private Boolean _isPerUnit;
        public Boolean IsPerUnit
        {
            get { return _isPerUnit; }
            set { _isPerUnit = value; }
        }
    }

    [Serializable()]
    public class CourseGroupId
    {
        private CourseGroupId() { }

        public static String GradeSchoolKinder
        {
            get { return "CG01"; }
        }

        public static String HighSchool
        {
            get { return "CG02"; }
        }

        public static String College
        {
            get { return "CG03"; }
        }

        public static String GraduateSchoolDoctorate
        {
            get { return "CG04"; }
        }

        public static String CrashCourse
        {
            get { return "CG05"; }
        }
    }

    [Serializable()]
    public class EnrolmentComponent
    {
        private EnrolmentComponent() { }

        public static Boolean IncludeGradeSchoolKinder
        {
            get { return true; }
        }

        public static Boolean IncludeHighSchool
        {
            get { return true; }
        }

        public static Boolean IncludeCollege
        {
            get { return true; }
        }

        public static Boolean IncludeGraduateSchoolDoctorate
        {
            get { return true; }
        }

        public static Boolean IncludeCrashCourse
        {
            get { return true; }
        }
    }

    [Serializable()]
    public class YearLevelInformation : BaseObject
    {
        public YearLevelInformation()
        {
            _yearLevelId = String.Empty;
            _courseGroupInfo = new CourseGroup();
            _yearLevelDescription = String.Empty;
            _acronym = String.Empty;
            _idPrefix = String.Empty;
            _yearLevelNo = 0;
        }

        public Boolean Equals(YearLevelInformation obj)
        {
            if (base.Equals<YearLevelInformation>(obj) &&
                _courseGroupInfo.Equals(obj.CourseGroupInfo))
            {
                return true;
            }

            return false;
        }

        private String _yearLevelId;
        public String YearLevelId
        {
            get { return _yearLevelId; }
            set { _yearLevelId = value; }
        }

        private CourseGroup _courseGroupInfo;
        public CourseGroup CourseGroupInfo
        {
            get { return _courseGroupInfo; }
            set { _courseGroupInfo = value; }
        }

        private String _yearLevelDescription;
        public String YearLevelDescription
        {
            get { return _yearLevelDescription; }
            set { _yearLevelDescription = value; }
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

        private Int16 _yearLevelNo;
        public Int16 YearLevelNo
        {
            get { return _yearLevelNo; }
            set { _yearLevelNo = value; }
        }

    }

    [Serializable()]
    public class YearLevelId
    {
        private YearLevelId() { }

        public static String Nursery
        {
            get { return "YRLV01"; }
        }

        public static String KinderOne
        {
            get { return "YRLV02"; }
        }

        public static String KinderTwo
        {
            get { return "YRLV03"; }
        }

        public static String GradeOne
        {
            get { return "YRLV04"; }
        }

        public static String GradeTwo
        {
            get { return "YRLV05"; }
        }

        public static String GradeThree
        {
            get { return "YRLV06"; }
        }

        public static String GradeFour
        {
            get { return "YRLV07"; }
        }

        public static String GradeFive
        {
            get { return "YRLV08"; }
        }

        public static String GradeSix
        {
            get { return "YRLV09"; }
        }

        public static String FirstYearHighSchool
        {
            get { return "YRLV10"; }
        }

        public static String SecondYearHighSchool
        {
            get { return "YRLV11"; }
        }

        public static String ThirdYearHighSchool
        {
            get { return "YRLV12"; }
        }

        public static String FourthYearHighSchool
        {
            get { return "YRLV13"; }
        }

        public static String FirstYearCollege
        {
            get { return "YRLV14"; }
        }

        public static String SecondYearCollege
        {
            get { return "YRLV15"; }
        }

        public static String ThirdYearCollege
        {
            get { return "YRLV16"; }
        }

        public static String FourthYearCollege
        {
            get { return "YRLV17"; }
        }

        public static String FifthYearCollege
        {
            get { return "YRLV18"; }
        }

        public static String GraduateSchool
        {
            get { return "YRLV19"; }
        }

        public static String Doctorate
        {
            get { return "YRLV20"; }
        }
        
    }

    [Serializable()]
    public class TranscriptInformation : BaseObject
    {
        public TranscriptInformation()
        {
            _transcriptSysId = String.Empty;
            _studentId = String.Empty;
            _lastName = String.Empty;
            _firstName = String.Empty;
            _middleName = String.Empty;
            _departmentName = String.Empty;
            _courseTitle = String.Empty;
            _entranceData = String.Empty;
            _recordsOfGraduation = String.Empty;
            _purposeOfRequest = String.Empty;
            _filePath = String.Empty;
            _fileName = String.Empty;
            _fileExtension = String.Empty;
        }

        public Boolean Equals(TranscriptInformation obj)
        {
            if (base.Equals<TranscriptInformation>(obj))
            {
                return true;
            }

            return false;
        }

        private String _transcriptSysId;
        public String TranscriptSysId
        {
            get { return _transcriptSysId; }
            set { _transcriptSysId = value; }
        }

        private String _studentId;
        public String StudentId
        {
            get { return _studentId; }
            set { _studentId = value; }
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

        private String _departmentName;
        public String DepartmentName
        {
            get { return _departmentName; }
            set { _departmentName = value; }
        }

        private String _courseTitle;
        public String CourseTitle
        {
            get { return _courseTitle; }
            set { _courseTitle = value; }
        }

        private String _entranceData;
        public String EntranceData
        {
            get { return _entranceData; }
            set { _entranceData = value; }
        }

        private String _recordsOfGraduation;
        public String RecordsOfGraduation
        {
            get { return _recordsOfGraduation; }
            set { _recordsOfGraduation = value; }
        }

        private String _purposeOfRequest;
        public String PurposeOfRequest
        {
            get { return _purposeOfRequest; }
            set { _purposeOfRequest = value; }
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

        /// <summary>
        /// If the PersonSysId is NULL or Empty, a TEMP folder is created
        /// </summary>
        /// <param name="startUpPath"></param>
        /// <returns></returns>
        public String PersonImagesFolder(String startUpPath)
        {
            return SystemConfiguration.ApplicationDocumentsFolder(startUpPath) + @"\" +
                (!String.IsNullOrEmpty(_transcriptSysId) ? _transcriptSysId : "Temp") + @"\PersonImages\";
        }

    }
    
    [Serializable()]
    public class TranscriptDetails : BaseObject
    {
        public TranscriptDetails()
        {
            _transcriptId = 0;
            _transcriptInfo = new CommonExchange.TranscriptInformation();
            _termSession = String.Empty;
            _subjectCode = String.Empty;
            _subjectNo = String.Empty;
            _descriptiveTitle = String.Empty;
            _creditUnits = String.Empty;
            _finalGrade = String.Empty;
            _reExam = String.Empty;
            _noOfHours = String.Empty;
            _sequenceNo = 0;
            _scheduleInfo = new ScheduleInformation();
            _specialClassInfo = new SpecialClassInformation();
            _subjectCategoryInfo = new SubjectCategory();            
        }

        public Boolean Equals(TranscriptDetails obj)
        {
            if (base.Equals<TranscriptDetails>(obj) &&
                _transcriptInfo.Equals(obj.TranscriptInfo) &&
                _scheduleInfo.Equals(obj.ScheduleInfo) &&
                _specialClassInfo.Equals(obj.SpecialClassInfo) &&
                _subjectCategoryInfo.Equals(obj.SubjectCategoryInfo))
            {
                return true;
            }

            return false;
        }

        private Int64 _transcriptId;
        public Int64 TranscriptId
        {
            get { return _transcriptId; }
            set { _transcriptId = value; }
        }

        private CommonExchange.TranscriptInformation _transcriptInfo;
        public CommonExchange.TranscriptInformation TranscriptInfo
        {
            get { return _transcriptInfo; }
            set { _transcriptInfo = value; }
        }

        private String _termSession;
        public String TermSession
        {
            get { return _termSession; }
            set { _termSession = value; }
        }

        private String _subjectCode;
        public String SubjectCode
        {
            get { return _subjectCode; }
            set { _subjectCode = value; }
        }

        private String _subjectNo;
        public String SubjectNo
        {
            get { return _subjectNo; }
            set { _subjectNo = value; }
        }

        private String _descriptiveTitle;
        public String DescriptiveTitle
        {
            get { return _descriptiveTitle; }
            set { _descriptiveTitle = value; }
        }

        private String _creditUnits;
        public String CreditUnits
        {
            get { return _creditUnits; }
            set { _creditUnits = value; }
        }

        private String _finalGrade;
        public String FinalGrade
        {
            get { return _finalGrade; }
            set { _finalGrade = value; }
        }

        private String _reExam;
        public String ReExam
        {
            get { return _reExam; }
            set { _reExam = value; }
        }

        private String _noOfHours;
        public String NoOfHours
        {
            get { return _noOfHours; }
            set { _noOfHours = value; }
        }

        private Int16 _sequenceNo;
        public Int16 SequenceNo
        {
            get { return _sequenceNo; }
            set { _sequenceNo = value; }
        }

        private ScheduleInformation _scheduleInfo;
        public ScheduleInformation ScheduleInfo
        {
            get { return _scheduleInfo; }
            set { _scheduleInfo = value; }
        }

        private SpecialClassInformation _specialClassInfo;
        public SpecialClassInformation SpecialClassInfo
        {
            get { return _specialClassInfo; }
            set { _specialClassInfo = value; }
        }

        private SubjectCategory _subjectCategoryInfo;
        public SubjectCategory SubjectCategoryInfo
        {
            get { return _subjectCategoryInfo; }
            set { _subjectCategoryInfo = value; }
        }
    }

    [Serializable()]
    public enum SchoolSemester
    {
        FirstSemester = 1,
        SecondSemester = 2,
        Summer = 3
    }

    [Serializable()]
    public enum CourseGroupNo
    {
        GradeSchool = 1,
        HighSchool = 2,
        College = 3,
        GraduateSchoolDoctorate = 4
    }

    #endregion
}
