using System;
using System.Collections.Generic;
using System.Text;

namespace ClientExchange
{
    #region Common Structure Exchange

    [Serializable()]
    public class RoomSubjectCourseFilter
    {
        private Boolean _forRoom;
        public Boolean ForRoom
        {
            get { return _forRoom; }
            set { _forRoom = value; }
        }

        private Boolean _forSubject;
        public Boolean ForSubject
        {
            get { return _forSubject; }
            set { _forSubject = value; }
        }

        private Boolean _forCourse;
        public Boolean ForCourse
        {
            get { return _forCourse; }
            set { _forCourse = value; }
        }

    }

    [Serializable()]
    public class EmployeeSearchFilter
    {
        private String _strSearch;
        public String StringSearch
        {
            get { return _strSearch; }
            set { _strSearch = value; }
        }

        private Boolean _includePartTime;
        public Boolean IncludePartTime
        {
            get { return _includePartTime; }
            set { _includePartTime = value; }
        }

        private Boolean _includeProbationary;
        public Boolean IncludeProbationary
        {
            get { return _includeProbationary; }
            set { _includeProbationary = value; }
        }

        private Boolean _includeRegular;
        public Boolean IncludeRegular
        {
            get { return _includeRegular; }
            set { _includeRegular = value; }
        }

        private Boolean _includeLayOff;
        public Boolean IncludeLayOff
        {
            get { return _includeLayOff; }
            set { _includeLayOff = value; }
        }

        private Boolean _includeGraduateSchoolFaculty;
        public Boolean IncludeGraduateSchoolFaculty
        {
            get { return _includeGraduateSchoolFaculty; }
            set { _includeGraduateSchoolFaculty = value; }
        }

        private Boolean _includeGraduateSchoolCollegeFaculty;
        public Boolean IncludeGraduateSchoolCollegeFaculty
        {
            get { return _includeGraduateSchoolCollegeFaculty; }
            set { _includeGraduateSchoolCollegeFaculty = value; }
        }

        private Boolean _includeGraduateSchoolHighSchoolFaculty;
        public Boolean IncludeGraduateSchoolHighSchoolFaculty
        {
            get { return _includeGraduateSchoolHighSchoolFaculty; }
            set { _includeGraduateSchoolHighSchoolFaculty = value; }
        }

        private Boolean _includeGraduateSchoolGradeKinderFaculty;
        public Boolean IncludeGraduateSchoolGradeKinderFaculty
        {
            get { return _includeGraduateSchoolGradeKinderFaculty; }
            set { _includeGraduateSchoolGradeKinderFaculty = value; }
        }

        private Boolean _includeCollegeFaculty;
        public Boolean IncludeCollegeFaculty
        {
            get { return _includeCollegeFaculty; }
            set { _includeCollegeFaculty = value; }
        }

        private Boolean _includeHighSchoolFaculty;
        public Boolean IncludeHighSchoolFaculty
        {
            get { return _includeHighSchoolFaculty; }
            set { _includeHighSchoolFaculty = value; }
        }

        private Boolean _includeGradeKinderFaculty;
        public Boolean IncludeGradeKinderFaculty
        {
            get { return _includeGradeKinderFaculty; }
            set { _includeGradeKinderFaculty = value; }
        }

        private Boolean _includeStaff;
        public Boolean IncludeStaff
        {
            get { return _includeStaff; }
            set { _includeStaff = value; }
        }

        private Boolean _includeAcademic;
        public Boolean IncludeAcademic
        {
            get { return _includeAcademic; }
            set { _includeAcademic = value; }
        }

        private Boolean _includeMaintenance;
        public Boolean IncludeMaintenance
        {
            get { return _includeMaintenance; }
            set { _includeMaintenance = value; }
        }
    }   

    #endregion
}
