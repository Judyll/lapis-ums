using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Reflection;

namespace CommonExchange
{
    #region Common Exchange Structure

    [Serializable()]
    public class ScheduleInformation : BaseObject
    {
        public ScheduleInformation()
        {
            _scheduleSysId = String.Empty;
            _subjectInfo = new SubjectInformation();
            _schoolYearInfo = new SchoolYear();
            _semesterInfo = new SemesterInformation();
            _isMarkedDeleted = false;
            _isTeamTeaching = false;
            _isIrregularModular = false;
            _isFixedAmount = false;
            _amount = 0.0M;
            _additionalSlots = 0;
        }

        public Boolean Equals(ScheduleInformation obj)
        {
            if (base.Equals<ScheduleInformation>(obj) &&
                _subjectInfo.Equals(obj.SubjectInfo) &&
                _schoolYearInfo.Equals(obj.SchoolYearInfo) &&
                _semesterInfo.Equals(obj.SemesterInfo))
            {
                return true;
            }

            return false;
        }

        private String _scheduleSysId;
        public String ScheduleSysId
        {
            get { return _scheduleSysId; }
            set { _scheduleSysId = value; }
        }

        private SubjectInformation _subjectInfo;
        public SubjectInformation SubjectInfo
        {
            get { return _subjectInfo; }
            set { _subjectInfo = value; }
        }

        private SchoolYear _schoolYearInfo;
        public SchoolYear SchoolYearInfo
        {
            get { return _schoolYearInfo; }
            set { _schoolYearInfo = value; }
        }

        private SemesterInformation _semesterInfo;
        public SemesterInformation SemesterInfo
        {
            get { return _semesterInfo; }
            set { _semesterInfo = value; }
        }

        private Boolean _isMarkedDeleted;
        public Boolean IsMarkedDeleted
        {
            get { return _isMarkedDeleted; }
            set { _isMarkedDeleted = value; }
        }

        private Boolean _isTeamTeaching;
        public Boolean IsTeamTeaching
        {
            get { return _isTeamTeaching; }
            set { _isTeamTeaching = value; }
        }

        private Boolean _isIrregularModular;
        public Boolean IsIrregularModular
        {
            get { return _isIrregularModular; }
            set { _isIrregularModular = value; }
        }

        private Boolean _isFixedAmount;
        public Boolean IsFixedAmount
        {
            get { return _isFixedAmount; }
            set { _isFixedAmount = value; }
        }

        private Decimal _amount;
        public Decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        private Int16 _additionalSlots;
        public Int16 AdditionalSlots
        {
            get { return _additionalSlots; }
            set { _additionalSlots = value; }
        }
        
    }

    [Serializable()]
    public class ScheduleInformationDetails : BaseObject
    {
        public ScheduleInformationDetails()
        {
            _scheduleDetailsSysId = String.Empty;
            _scheduleInfo = new ScheduleInformation();
            _classroomInfo = new ClassroomInformation();
            _employeeInfo = new Employee();
            _fieldRoom = String.Empty;
            _manualSchedule = String.Empty;
            _isClassroom = false;
            _isMarkedDeleted = false;
            _lectureUnits = 0.0F;
            _labUnits = 0.0F;
            _noHours = String.Empty;
            _section = String.Empty;
            _dayTime = String.Empty;
            _dayTimeClassroom = String.Empty;
            _dayTimeFieldRoom = String.Empty;
            _manualScheduleClassroom = String.Empty;
            _manualScheduleFieldRoom = String.Empty;
        }

        public Boolean Equals(ScheduleInformationDetails obj)
        {
            if (base.Equals<ScheduleInformationDetails>(obj) &&
                _scheduleInfo.Equals(obj.ScheduleInfo) &&
                _classroomInfo.Equals(obj.ClassroomInfo) &&
                _employeeInfo.Equals(obj.EmployeeInfo))
            {
                return true;
            }

            return false;
        }

        private String _scheduleDetailsSysId;
        public String ScheduleDetailsSysId
        {
            get { return _scheduleDetailsSysId; }
            set { _scheduleDetailsSysId = value; }
        }

        private ScheduleInformation _scheduleInfo;
        public ScheduleInformation ScheduleInfo
        {
            get { return _scheduleInfo; }
            set { _scheduleInfo = value; }
        }

        private ClassroomInformation _classroomInfo;
        public ClassroomInformation ClassroomInfo
        {
            get { return _classroomInfo; }
            set { _classroomInfo = value; }
        }

        private Employee _employeeInfo;
        public Employee EmployeeInfo
        {
            get { return _employeeInfo; }
            set { _employeeInfo = value; }
        }

        private String _fieldRoom;
        public String FieldRoom
        {
            get { return _fieldRoom; }
            set { _fieldRoom = value; }
        }

        private String _manualSchedule;
        public String ManualSchedule
        {
            get { return _manualSchedule; }
            set { _manualSchedule = value; }
        }

        private Boolean _isClassroom;
        public Boolean IsClassroom
        {
            get { return _isClassroom; }
            set { _isClassroom = value; }
        }

        private Boolean _isMarkedDeleted;
        public Boolean IsMarkedDeleted
        {
            get { return _isMarkedDeleted; }
            set { _isMarkedDeleted = value; }
        }

        private Single _lectureUnits;
        public Single LectureUnits
        {
            get { return _lectureUnits; }
            set { _lectureUnits = value; }
        }

        private Single _labUnits;
        public Single LabUnits
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

        private String _section;
        public String Section
        {
            get { return _section; }
            set { _section = value; }
        }

        private String _dayTime;
        public String DayTime
        {
            get { return _dayTime; }
            set { _dayTime = value; }
        }

        private String _dayTimeClassroom;
        public String DayTimeClassroom
        {
            get { return _dayTimeClassroom; }
            set { _dayTimeClassroom = value; }
        }

        private String _dayTimeFieldRoom;
        public String DayTimeFieldRoom
        {
            get { return _dayTimeFieldRoom; }
            set { _dayTimeFieldRoom = value; }
        }

        private String _manualScheduleClassroom;
        public String ManualScheduleClassroom
        {
            get { return _manualScheduleClassroom; }
            set { _manualScheduleClassroom = value; }
        }

        private String _manualScheduleFieldRoom;
        public String ManualScheduleFieldRoom
        {
            get { return _manualScheduleFieldRoom; }
            set { _manualScheduleFieldRoom = value; }
        }

    }

    [Serializable()]
    public class AuxiliaryServiceInformation : BaseObject
    {
        public AuxiliaryServiceInformation()
        {
            _auxServiceSysId = String.Empty;
            _courseGroupInfo = new CourseGroup();
            _departmentInfo = new Department();
            _serviceCode = String.Empty;
            _descriptiveTitle = String.Empty;
            _lectureUnits = 0;
            _labUnits = 0;
            _noHours = String.Empty;
            _otherInformation = String.Empty;
        }

        public Boolean Equals(AuxiliaryServiceInformation obj)
        {
            if (base.Equals<AuxiliaryServiceInformation>(obj) &&
                _courseGroupInfo.Equals(obj.CourseGroupInfo) &&
                _departmentInfo.Equals(obj.DepartmentInfo))
            {
                return true;
            }

            return false;
                
        }

        private String _auxServiceSysId;
        public String AuxServiceSysId
        {
            get { return _auxServiceSysId; }
            set { _auxServiceSysId = value; }
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

        private String _serviceCode;
        public String ServiceCode
        {
            get { return _serviceCode; }
            set { _serviceCode = value; }
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
    }

    [Serializable()]
    public class AuxiliaryServiceSchedule : BaseObject
    {
        public AuxiliaryServiceSchedule()
        {
            _auxServiceScheduleSysId = String.Empty;
            _auxiliaryServiceInfo = new AuxiliaryServiceInformation();
            _schoolYearInfo = new SchoolYear();
            _semesterInfo = new SemesterInformation();
            _isMarkedDeleted = false;
            _isFixedAmount = false;
            _amount = 0.0M;
        }

        public Boolean Equals(AuxiliaryServiceSchedule obj)
        {
            if (base.Equals<AuxiliaryServiceSchedule>(obj) &&
                _auxiliaryServiceInfo.Equals(obj.AuxiliaryServiceInfo) &&
                _schoolYearInfo.Equals(obj.SchoolYearInfo) &&
                _semesterInfo.Equals(obj.SemesterInfo))
            {
                return true;
            }

            return false;
        }

        private String _auxServiceScheduleSysId;
        public String AuxServiceScheduleSysId
        {
            get { return _auxServiceScheduleSysId; }
            set { _auxServiceScheduleSysId = value; }
        }

        private AuxiliaryServiceInformation _auxiliaryServiceInfo;
        public AuxiliaryServiceInformation AuxiliaryServiceInfo
        {
            get { return _auxiliaryServiceInfo; }
            set { _auxiliaryServiceInfo = value; }
        }

        private SchoolYear _schoolYearInfo;
        public SchoolYear SchoolYearInfo
        {
            get { return _schoolYearInfo; }
            set { _schoolYearInfo = value; }
        }

        private SemesterInformation _semesterInfo;
        public SemesterInformation SemesterInfo
        {
            get { return _semesterInfo; }
            set { _semesterInfo = value; }
        }

        private Boolean _isMarkedDeleted;
        public Boolean IsMarkedDeleted
        {
            get { return _isMarkedDeleted; }
            set { _isMarkedDeleted = value; }
        }      

        private Boolean _isFixedAmount;
        public Boolean IsFixedAmount
        {
            get { return _isFixedAmount; }
            set { _isFixedAmount = value; }
        }

        private Decimal _amount;
        public Decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

    }

    [Serializable()]
    public class AuxiliaryServiceDetails : BaseObject
    {
        public AuxiliaryServiceDetails()
        {
            _auxServiceDetailsSysId = String.Empty;
            _auxiliaryServiceScheduleInfo = new AuxiliaryServiceSchedule();
            _employeeInfo = new Employee();
            _isMarkedDeleted = false;
            _lectureUnits = 0.0F;
            _labUnits = 0.0F;
            _noHours = String.Empty;
        }

        public Boolean Equals(AuxiliaryServiceDetails obj)
        {
            if (base.Equals<AuxiliaryServiceDetails>(obj) &&
                _auxiliaryServiceScheduleInfo.Equals(obj.AuxiliaryServiceScheduleInfo) &&
                _employeeInfo.Equals(obj.EmployeeInfo))
            {
                return true;
            }

            return false;
        }

        private String _auxServiceDetailsSysId;
        public String AuxServiceDetailsSysId
        {
            get { return _auxServiceDetailsSysId; }
            set { _auxServiceDetailsSysId = value; }
        }

        private AuxiliaryServiceSchedule _auxiliaryServiceScheduleInfo;
        public AuxiliaryServiceSchedule AuxiliaryServiceScheduleInfo
        {
            get { return _auxiliaryServiceScheduleInfo; }
            set { _auxiliaryServiceScheduleInfo = value; }
        }

        private Employee _employeeInfo;
        public Employee EmployeeInfo
        {
            get { return _employeeInfo; }
            set { _employeeInfo = value; }
        }

        private Boolean _isMarkedDeleted;
        public Boolean IsMarkedDeleted
        {
            get { return _isMarkedDeleted; }
            set { _isMarkedDeleted = value; }
        }

        private Single _lectureUnits;
        public Single LectureUnits
        {
            get { return _lectureUnits; }
            set { _lectureUnits = value; }
        }

        private Single _labUnits;
        public Single LabUnits
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

    }

    [Serializable()]
    public class TeacherLoad : BaseObject
    {
        public TeacherLoad()
        {
            _loadId = 0;
            _scheduleInfoDetails = new ScheduleInformationDetails();
            _auxiliaryServiceDetailsInfo = new AuxiliaryServiceDetails();
            _employeeInfo = new Employee();
            _loadDate = String.Empty;
            _deloadDate = String.Empty;
            _lectureUnits = 0.0F;
            _labUnits = 0.0F;
            _noHours = String.Empty;
            _isAuxiliary = false;
            _isPrematureDeloaded = false;
        }

        public Boolean Equals(TeacherLoad obj)
        {
            if (base.Equals<TeacherLoad>(obj) &&
                _scheduleInfoDetails.Equals(obj.ScheduleInfoDetails) &&
                _auxiliaryServiceDetailsInfo.Equals(obj.AuxiliaryServiceDetailsInfo) &&
                _employeeInfo.Equals(obj.EmployeeInfo))
            {
                return true;
            }

            return false;
        }

        private Int64 _loadId;
        public Int64 LoadId
        {
            get { return _loadId; }
            set { _loadId = value; }
        }

        private ScheduleInformationDetails _scheduleInfoDetails;
        public ScheduleInformationDetails ScheduleInfoDetails
        {
            get { return _scheduleInfoDetails; }
            set { _scheduleInfoDetails = value; }
        }

        private AuxiliaryServiceDetails _auxiliaryServiceDetailsInfo;
        public AuxiliaryServiceDetails AuxiliaryServiceDetailsInfo
        {
            get { return _auxiliaryServiceDetailsInfo; }
            set { _auxiliaryServiceDetailsInfo = value; }
        }

        private Employee _employeeInfo;
        public Employee EmployeeInfo
        {
            get { return _employeeInfo; }
            set { _employeeInfo = value; }
        }

        private String _loadDate;
        public String LoadDate
        {
            get { return _loadDate; }
            set { _loadDate = value; }
        }

        private String _deloadDate;
        public String DeloadDate
        {
            get { return _deloadDate; }
            set { _deloadDate = value; }
        }

        private Single _lectureUnits;
        public Single LectureUnits
        {
            get { return _lectureUnits; }
            set { _lectureUnits = value; }
        }

        private Single _labUnits;
        public Single LabUnits
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

        private Boolean _isAuxiliary;
        public Boolean IsAuxiliary
        {
            get { return _isAuxiliary; }
            set { _isAuxiliary = value; }
        }

        private Boolean _isPrematureDeloaded;
        public Boolean IsPrematureDeloaded
        {
            get { return _isPrematureDeloaded; }
            set { _isPrematureDeloaded = value; }
        }
    }

    [Serializable()]
    public class StudentLoad : BaseObject
    {
        public StudentLoad()
        {
            _loadId = 0;
            _studentEnrolmentLevelInfo = new StudentEnrolmentLevel();
            _scheduleInfo = new ScheduleInformation();
            _loadDate = String.Empty;
            _deloadDate = String.Empty;
        }

        public Boolean Equals(StudentLoad obj)
        {
            if (base.Equals<StudentLoad>(obj) &&
                _studentEnrolmentLevelInfo.Equals(obj.StudentEnrolmentLevelInfo) &&
                _scheduleInfo.Equals(obj.ScheduleInfo))
            {
                return true;
            }

            return false;
        }

        private Int64 _loadId;
        public Int64 LoadId
        {
            get { return _loadId; }
            set { _loadId = value; }
        }

        private StudentEnrolmentLevel _studentEnrolmentLevelInfo;
        public StudentEnrolmentLevel StudentEnrolmentLevelInfo
        {
            get { return _studentEnrolmentLevelInfo; }
            set { _studentEnrolmentLevelInfo = value; }
        }

        private ScheduleInformation _scheduleInfo;
        public ScheduleInformation ScheduleInfo
        {
            get { return _scheduleInfo; }
            set { _scheduleInfo = value; }
        }

        private String _loadDate;
        public String LoadDate
        {
            get { return _loadDate; }
            set { _loadDate = value; }
        }

        private String _deloadDate;
        public String DeloadDate
        {
            get { return _deloadDate; }
            set { _deloadDate = value; }
        }
    }

    [Serializable()]
    public class ScholarshipInformation : BaseObject
    {
        public ScholarshipInformation()
        {
            _scholarshipSysId = String.Empty;
            _courseGroupInfo = new CourseGroup();
            _departmentInfo = new Department();
            _scholarshipDescription = String.Empty;
            _isNonAcademic = false;
        }

        public Boolean Equals(ScholarshipInformation obj)
        {
            if (base.Equals<ScholarshipInformation>(obj) &&
                _courseGroupInfo.Equals(obj.CourseGroupInfo) &&
                _departmentInfo.Equals(obj.DepartmentInfo))
            {
                return true;
            }

            return false;
        }

        private String _scholarshipSysId;
        public String ScholarshipSysId
        {
            get { return _scholarshipSysId; }
            set { _scholarshipSysId = value; }
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

        private String _scholarshipDescription;
        public String ScholarshipDescription
        {
            get { return _scholarshipDescription; }
            set { _scholarshipDescription = value; }
        }

        private Boolean _isNonAcademic;
        public Boolean IsNonAcademic
        {
            get { return _isNonAcademic; }
            set { _isNonAcademic = value; }
        }

    }

    [Serializable()]
    public class StudentScholarship : BaseObject
    {
        public StudentScholarship()
        {
            _studentScholarshipSysId = String.Empty;
            _scholarshipInfo = new ScholarshipInformation();
            _studentEnrolmentLevelInfo = new StudentEnrolmentLevel();
            _isMarkedDeleted = false;
        }

        public Boolean Equals(StudentScholarship obj)
        {
            if (base.Equals<StudentScholarship>(obj) &&
                _scholarshipInfo.Equals(obj.ScholarshipInfo) &&
                _studentEnrolmentLevelInfo.Equals(obj.StudentEnrolmentLevelInfo))
            {
                return true;
            }

            return false;
        }

        private String _studentScholarshipSysId;
        public String StudentScholarshipSysId
        {
            get { return _studentScholarshipSysId; }
            set { _studentScholarshipSysId = value; }
        }

        private ScholarshipInformation _scholarshipInfo;
        public ScholarshipInformation ScholarshipInfo
        {
            get { return _scholarshipInfo; }
            set { _scholarshipInfo = value; }
        }

        private StudentEnrolmentLevel _studentEnrolmentLevelInfo;
        public StudentEnrolmentLevel StudentEnrolmentLevelInfo
        {
            get { return _studentEnrolmentLevelInfo; }
            set { _studentEnrolmentLevelInfo = value; }
        }

        private Boolean _isMarkedDeleted;
        public Boolean IsMarkedDeleted
        {
            get { return _isMarkedDeleted; }
            set { _isMarkedDeleted = value; }
        }

    }

    #endregion
}
