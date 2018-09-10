using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net.NetworkInformation;
using System.Net;
using System.Windows.Forms;
using System.Drawing;
using System.Data;

namespace RemoteClient
{
    [Serializable()]
    public partial class ProcStatic
    {

        #region Programmer-Defined Void Procedures

        //this procedure sets the dataview headers
        public static void SetDataGridViewColumns(DataGridView dgvBase, Boolean useSize)
        {
            Int32 width = 0;

            //general datagridview settings
            dgvBase.ReadOnly = true;
            dgvBase.MultiSelect = false;
            //----------------------

            foreach (DataGridViewColumn column in dgvBase.Columns)
            {
                //general column settings
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                //----------------------------

                //individual column setting
                switch (column.HeaderText)
                {
                    case "employee_id":
                        column.HeaderText = "Employee ID";
                        column.Width = 100;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        break;
                    case "employee_name":
                        column.HeaderText = "Employee Name";
                        column.Width = 225;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        column.Frozen = true;
                        break;
                    case "faculty_name":
                        column.HeaderText = "Faculty Name";
                        column.Width = 225;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        column.Frozen = true;
                        break;
                    case "instructor":
                        column.HeaderText = "Instructor";
                        column.Width = 300;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        column.Frozen = true;
                        break;
                    case "instructor_no_freeze":
                        column.HeaderText = "Instructor";
                        column.Width = 300;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        break;
                    case "card_number":
                        column.HeaderText = "Card Number";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "sysid_deduction":
                        column.HeaderText = "Deduction ID";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "sysid_earning":
                        column.HeaderText = "Earning ID";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "sysid_loan":
                        column.HeaderText = "System ID";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "deduction_description":
                        column.HeaderText = "Description";
                        column.Width = 300;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        column.Frozen = true;
                        break;
                    case "earning_description":
                        column.HeaderText = "Description";
                        column.Width = 300;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        column.Frozen = true;
                        break;
                    case "loan_description":
                        column.HeaderText = "Description";
                        column.Width = 300;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        column.Frozen = true;
                        break;    
                    case "deduction_id":
                        column.HeaderText = "System ID";
                        column.Width = 100;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "earning_id":
                        column.HeaderText = "System ID";
                        column.Width = 100;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "deduction_date":
                        column.HeaderText = "Deduction Date";
                        column.Width = 130;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "earning_date":
                        column.HeaderText = "Earning Date";
                        column.Width = 130;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "amount":
                        column.HeaderText = "Amount";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        break;
                    case "outstanding_loans":
                        column.HeaderText = "Outstanding Loans";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "sysid_remittance":
                        column.HeaderText = "System ID";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "reference_no":
                        column.HeaderText = "Reference No.";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "loan_status":
                        column.HeaderText = "Status";
                        column.Width = 110;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "remittance_id":
                        column.HeaderText = "System ID";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "remittance_date":
                        column.HeaderText = "Remittance Date";
                        column.Width = 130;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "pay_month":
                        column.HeaderText = "Month Payment";
                        column.Width = 130;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "amount_paid":
                        column.HeaderText = "Amount Paid";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        break;
                    case "amount_balance":
                        column.HeaderText = "Amount Balance";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        break;
                    case "year_id":
                        column.HeaderText = "School Year ID";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        break;
                    case "year_description":
                        column.HeaderText = "School Year";
                        column.Width = 300;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        column.Frozen = true;
                        break;
                    case "sysid_semester":
                        column.HeaderText = "Semester ID";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        break;
                    case "semester_description":
                        column.HeaderText = "Semester";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        column.Frozen = true;
                        break;
                    case "sysid_classroom":
                        column.HeaderText = "System ID";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        break;
                    case "classroom_code":
                        column.HeaderText = "Classroom Code";
                        column.Width = 200;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        column.Frozen = true;
                        break;
                    case "classroom_code_no_freeze":
                        column.HeaderText = "Classroom Code";
                        column.Width = 200;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "classroom_description":
                        column.HeaderText = "Classroom Description";
                        column.Width = 300;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "maximum_capacity":
                        column.HeaderText = "Max. Cap.";
                        column.Width = 100;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "classroom_field_code":
                        column.HeaderText = "Classroom Code/Field";
                        column.Width = 200;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "sysid_subject":
                        column.HeaderText = "System ID";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        break;
                    case "subject_code":
                        column.HeaderText = "Subject Code";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        column.Frozen = true;
                        break;
                    case "descriptive_title":
                        column.HeaderText = "Descriptive Title";
                        column.Width = 300;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        column.Frozen = true;
                        break;
                    case "descriptive_title_no_freeze":
                        column.HeaderText = "Descriptive Title";
                        column.Width = 300;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        break;
                    case "department_name":
                        column.HeaderText = "Department Name";
                        column.Width = 300;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        break;
                    case "category_name":
                        column.HeaderText = "Category";
                        column.Width = 200;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        break;
                    case "prerequisite_id":
                        column.HeaderText = "System ID";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "course_id":
                        column.HeaderText = "Course ID";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "course_title":
                        column.HeaderText = "Course Title";
                        column.Width = 400;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        break;
                    case "acronym":
                        column.HeaderText = "Acronym";
                        column.Width = 100;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "student_id":
                        column.HeaderText = "Student ID";
                        column.Width = 100;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        break;
                    case "student_name":
                        column.HeaderText = "Student Name";
                        column.Width = 225;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        column.Frozen = true;
                        break;
                    case "present_address":
                        column.HeaderText = "Present Address";
                        column.Width = 350;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        break;
                    case "present_phone_nos":
                        column.HeaderText = "Present Phone Nos.";
                        column.Width = 250;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        break;
                    case "home_address":
                        column.HeaderText = "Home Address";
                        column.Width = 350;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        break;
                    case "home_phone_nos":
                        column.HeaderText = "Home Phone Nos.";
                        column.Width = 250;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        break;
                    case "emer_contact_name":
                        column.HeaderText = "Emergency Contact Person";
                        column.Width = 225;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        break;
                    case "emer_present_address":
                        column.HeaderText = "Contact Present Address";
                        column.Width = 350;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        break;
                    case "emer_present_phone_nos":
                        column.HeaderText = "Contact Present Phone Nos.";
                        column.Width = 250;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        break;
                    case "emer_relationship_description":
                        column.HeaderText = "Contact Relationship Description";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "emer_home_address":
                        column.HeaderText = "Contact Home Address";
                        column.Width = 350;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        break;
                    case "emer_home_phone_nos":
                        column.HeaderText = "Contact Home Phone Nos.";
                        column.Width = 250;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        break;
                    case "subject_code_title":
                        column.HeaderText = "Subject Code and Title";
                        column.Width = 330;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        column.Frozen = true;
                        break;
                    case "sysid_special":
                        column.HeaderText = "System ID";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        column.Frozen = true;
                        break;
                    case "sysid_special_no_freeze":
                        column.HeaderText = "System ID";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "load_id":
                        column.HeaderText = "System ID";
                        column.Width = 75;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "load_date":
                        column.HeaderText = "Load Date";
                        column.Width = 130;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "deload_date":
                        column.HeaderText = "DeLoad Date";
                        column.Width = 130;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "sysid_schedule":
                        column.HeaderText = "System ID";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        column.Frozen = true;
                        break;
                    case "sysid_schedule_no_freeze":
                        column.HeaderText = "System ID";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "sysid_scheddetails":
                        column.HeaderText = "System ID";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        column.Frozen = true;
                        break;
                    case "lecture_units":
                        column.HeaderText = "Lecture Units";
                        column.Width = 100;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        break;
                    case "lab_units":
                        column.HeaderText = "Lab/RLE Units";
                        column.Width = 100;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        break;
                    case "no_hours":
                        column.HeaderText = "No. of Hours";
                        column.Width = 100;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "student_employee_name":
                        column.HeaderText = "Student/Employee Name";
                        column.Width = 225;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        column.Frozen = true;
                        break;
                    case "student_employee_id":
                        column.HeaderText = "ID";
                        column.Width = 100;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        column.Frozen = true;
                        break;
                    case "course_title_department_name":
                        column.HeaderText = "Course Title/Department Name";
                        column.Width = 400;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        break;
                    case "day_time":
                        column.HeaderText = "Day/Time";
                        column.Width = 250;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        column.Frozen = true;
                        break;
                    case "day_time_no_freeze":
                        column.HeaderText = "Day/Time";
                        column.Width = 250;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "section":
                        column.HeaderText = "Section";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "service_code_title":
                        column.HeaderText = "Service Code and Title";
                        column.Width = 330;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        column.Frozen = true;
                        break;
                    case "sysid_auxservice":
                        column.HeaderText = "System ID";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        break;
                    case "sysid_auxdetails":
                        column.HeaderText = "System ID";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        column.Frozen = true;
                        break;
                    case "sysid_auxserviceschedule":
                        column.HeaderText = "System ID";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        column.Frozen = true;
                        break;
                    case "sysid_feeparticular":
                        column.HeaderText = "System ID";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        column.Frozen = true;
                        break;
                    case "particular_description":
                        column.HeaderText = "Particular Description";
                        column.Width = 300;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        column.Frozen = true;
                        break;
                    case "particular_description_for_multiple":
                        column.HeaderText = "Particular Description";
                        column.Width = 300;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        break;
                    case "year_level_description":
                        column.HeaderText = "Year Level";
                        column.Width = 200;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        break;
                    case "category_description":
                        column.HeaderText = "Category";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        break;
                    case "sysid_feedetails":
                        column.HeaderText = "System ID";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        column.Frozen = true;
                        break;
                    case "sysid_schoolfee":
                        column.HeaderText = "System ID";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "is_optional":
                        column.HeaderText = "Is Optional";
                        column.Width = 70;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "is_office_access":
                        column.HeaderText = "Is Office Access";
                        column.Width = 70;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "is_entry_level_included":
                        column.HeaderText = "Is Entry Level Included";
                        column.Width = 70;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "is_graduation_fee":
                        column.HeaderText = "Is Graduation Fee";
                        column.Width = 70;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "additional_fee_id":
                        column.HeaderText = "System ID";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "fee_date":
                        column.HeaderText = "Fee Date";
                        column.Width = 130;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "checkbox_column":
                        column.HeaderText = "";
                        column.Width = 30;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "slots_available":
                        column.HeaderText = "Slots Available";
                        column.Width = 70;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.DefaultCellStyle.ForeColor = Color.Red;
                        column.Frozen = true;
                        break;
                    case "slots_available_no_freeze":
                        column.HeaderText = "Slots Available";
                        column.Width = 70;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.DefaultCellStyle.ForeColor = Color.Red;
                        break;
                    case "sysid_studentscholarship":
                        column.HeaderText = "System ID";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "scholarship_description":
                        column.HeaderText = "Scholarship Description";
                        column.Width = 300;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        break;
                    case "sysid_enrolmentlevel":
                        column.HeaderText = "System ID";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "major_exam_id":
                        column.HeaderText = "System ID";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        column.Frozen = true;
                        break;
                    case "exam_date":
                        column.HeaderText = "Exam Date";
                        column.Width = 200;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        column.Frozen = true;
                        break;
                    case "exam_description":
                        column.HeaderText = "Exam Description";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        break;
                    case "group_description":
                        column.HeaderText = "Course Group";
                        column.Width = 200;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        break;
                    case "system_user_id":
                        column.HeaderText = "System ID";
                        column.Width = 50;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        break;
                    case "system_user_name":
                        column.HeaderText = "User Name";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        column.Frozen = true;
                        break;
                    case "user_name":
                        column.HeaderText = "Complete Name";
                        column.Width = 225;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        column.Frozen = true;
                        break;
                    case "access_description":
                        column.HeaderText = "Access Level";
                        column.Width = 450;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        break;
                    case "transaction_id":
                        column.HeaderText = "System ID";
                        column.Width = 75;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        column.Frozen = true;
                        break;
                    case "transaction_date_string":
                        column.HeaderText = "Transaction Date";
                        column.Width = 170;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        column.Frozen = true;
                        break;
                    case "network_information":
                        column.HeaderText = "Network Information";
                        column.Width = 300;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        break;
                    case "transaction_done":
                        column.HeaderText = "Transaction Done";
                        column.Width = 2000;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        break;
                    case "sysid_person":
                        column.HeaderText = "System ID";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        break;
                    case "person_name":
                        column.HeaderText = "Person Name";
                        column.Width = 225;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        column.Frozen = true;
                        break;
                    case "birthdate":
                        column.HeaderText = "Birthdate";
                        column.Width = 170;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "life_status_code_code_description":
                        column.HeaderText = "Life Status";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "gender_code_code_description":
                        column.HeaderText = "Gender";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "relationship_description":
                        column.HeaderText = "Relationship Description";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "relationship_type_id":
                        column.HeaderText = "Relationship Type ID";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "is_emergency_contact":
                        column.HeaderText = "Is Emergency Contact";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "relationship_id":
                        column.HeaderText = "System ID";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "remarks":
                        column.HeaderText = "Remarks";
                        column.Width = 300;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        break;
                    case "sysid_transcript":
                        column.HeaderText = "System ID";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        column.Frozen = true;
                        break;
                    case "transcript_id":
                        column.HeaderText = "System ID";
                        column.Width = 75;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "term_session":
                        column.HeaderText = "Term / Session";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        column.Frozen = true;
                        break;
                    case "subject_no":
                        column.HeaderText = "Subject No.";
                        column.Width = 75;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        column.Frozen = true;
                        break;
                    case "credit_units":
                        column.HeaderText = "Credit Units";
                        column.Width = 75;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        break;
                    case "final_grade":
                        column.HeaderText = "Final Grades";
                        column.Width = 75;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        break;
                    case "re_exam":
                        column.HeaderText = "Re Exam";
                        column.Width = 75;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        break;
                    case "no_of_hours":
                        column.HeaderText = "No. of Hours";
                        column.Width = 75;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        break;
                    case "sequence_no":
                        column.HeaderText = "Sequence No.";
                        column.Width = 75;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "receipt_no":
                        column.HeaderText = "Receipt No.";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        column.Frozen = true;
                        break;
                    case "date_cancelled":
                        column.HeaderText = "Date Cancelled";
                        column.Width = 130;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "access_date_time":
                        column.HeaderText = "Access Date and Time";
                        column.Width = 300;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        column.Frozen = true;
                        break;
                    case "account_code_name":
                        column.HeaderText = "Account Code and Name";
                        column.Width = 330;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        column.DefaultCellStyle.ForeColor = Color.Maroon;
                        column.Frozen = true;
                        break;
                    case "account_code_name_summary":
                        column.HeaderText = "Summary Account";
                        column.Width = 330;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        break;
                    case "category_description_summary":
                        column.HeaderText = "Summary Category";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                        break;
                    case "sysid_account":
                        column.HeaderText = "System ID";
                        column.Width = 150;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    case "category_id":
                        column.HeaderText = "Category";
                        column.Width = 200;
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        break;
                    default:
                        column.Visible = false;
                        column.Width = 0;
                        break;
                }

                width += column.Width;
            }

            if (useSize)
            {
                dgvBase.Width = width;
            }

        } //---------------------------        

        //this procedure sets the textbox initial message
        public static void TextBoxMessageTip(TextBox txtInput, String strMessage, Boolean showMessage)
        {
            String strInput = txtInput.Text.Trim();

            if (showMessage && (String.IsNullOrEmpty(strInput)))
            {
                txtInput.Text = strMessage;
                txtInput.Font = new Font(txtInput.Font, FontStyle.Italic);
                txtInput.ForeColor = Color.DarkCyan;
            }
            else
            {
                if (String.IsNullOrEmpty(strInput))
                {
                    txtInput.Text = String.Empty;
                }

                txtInput.Font = new Font(txtInput.Font, FontStyle.Regular);
                txtInput.ForeColor = Color.Black;
            }

        } //--------------------------

        //this proceudre makes the textbox accept only for the username and password
        public static void TextBoxForUserNamePassword(KeyPressEventArgs e)
        {
            if ((Convert.ToInt32(e.KeyChar) < 32 || Convert.ToInt32(e.KeyChar) > 126) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        } //----------------------------------

        //this procedure makes the textbox accept on numbers
        public static void TextBoxAmountOnly(KeyPressEventArgs e)
        {
            if (e.KeyChar != '.' && e.KeyChar != ',' && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        } //------------------------------

        //this procedure makes the textbox accept on float
        public static void TextBoxFloatDecimalOnly(KeyPressEventArgs e)
        {
            if (e.KeyChar != '.' && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        } //------------------------------

        //this procedure makes the textbox accept letters only
        public static void TextBoxLettersOnly(KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && e.KeyChar != '-' &&
                e.KeyChar != '.')
            {
                e.Handled = true;
            }
        } //-----------------------------

        //this procedure makes the textbox accept integers only
        public static void TextBoxIntegersOnly(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }

        } //------------------------------

        //this procedure makes the textbox accept integers only
        public static void TextBoxIntegersWithNegationOnly(KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != '-')
            {
                e.Handled = true;
            }

        } //------------------------------

        //this procedure validates the textbox
        public static void TextBoxValidateAmount(TextBox txtInput)
        {
            Decimal input;

            if (Decimal.TryParse(txtInput.Text, out input))
            {
                txtInput.Text = input.ToString("N");
            }
            else
            {
                txtInput.Text = "0.00";
            }

        } //--------------------------------------

        //this procedure validates the textbox
        public static void TextBoxValidateFloatMaxTwoDecimal(TextBox txtInput)
        {
            Single input;

            if (Single.TryParse(txtInput.Text, out input))
            {
                txtInput.Text = input.ToString("0.##");
            }
            else
            {
                txtInput.Text = "0.00";
            }

        } //--------------------------------------

        //this procedure validates the textbox
        public static void TextBoxValidateInteger(TextBox txtInput)
        {
            Int32 input;

            if (Int32.TryParse(txtInput.Text, out input))
            {
                txtInput.Text = input.ToString();
            }
            else
            {
                txtInput.Text = "0";
            }

        } //--------------------------------------

        //this procedure validates the textbox
        public static void TextBoxValidateInt16(TextBox txtInput)
        {
            Int16 input;

            if (Int16.TryParse(txtInput.Text, out input))
            {
                txtInput.Text = input.ToString();
            }
            else
            {
                txtInput.Text = "0";
            }

        } //--------------------------------------

        //this function deletes a specified directory
        public static void DeleteDirectory(String dirPath)
        {

            DirectoryInfo infoDir = new DirectoryInfo(dirPath);

            if (infoDir.Exists)
            {
                infoDir.Delete(true);
            }

        } //-----------------------------------

        //this function shows an error message
        public static void ShowErrorDialog(String errMsg, String errCaption)
        {
            MessageBox.Show("A business rule has been violated... \nDetails: " + errMsg, errCaption,
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        } //-------------------------

        //this function return a six digit number
        public static String SixDigitZero(Int32 numBase)
        {
            String strPrefix = "";

            if (numBase > 99999)
            {
                strPrefix = "";
            }
            else if (numBase > 9999)
            {
                strPrefix = "0";
            }
            else if (numBase > 999)
            {
                strPrefix = "00";
            }
            else if (numBase > 99)
            {
                strPrefix = "000";
            }
            else if (numBase > 9)
            {
                strPrefix = "0000";
            }
            else
            {
                strPrefix = "00000";
            }

            return strPrefix + numBase.ToString();
        } //---------------------------------------

        #endregion

        #region Programmer-Defined Function Procedures

        //this function returns the payroll pre-terminated load date
        public static DateTime GetPayrollPreTerminatedLoadDate(Byte payrollCutOffDay, String serverDateTime)
        {
            DateTime sDateTime = DateTime.Parse(DateTime.Parse(serverDateTime).ToShortDateString() + " 11:59:59 PM");
            DateTime deloadDate = DateTime.MinValue;

            if (sDateTime.Day > payrollCutOffDay)
            {
                deloadDate = sDateTime;
            }
            else
            {
                deloadDate = sDateTime.AddMonths(-1);
            }

            return deloadDate.AddDays(DateTime.DaysInMonth(deloadDate.Year, deloadDate.Month) - deloadDate.Day);
        } //-------------------------------------

        //this function determines if the record is locked for optional, additional, and discount fees   
        //Database Function:    ums.IsRecordLockForOptionalAdditionalDiscountFee
        public static Boolean IsRecordLockForOptionalAdditionalDiscountFee(DateTime dateStart, DateTime dateEnd, DateTime serverDateTime, Int32 addMonths,
            Boolean isEnrolmentLevelMarkedDeleted, Boolean isCurrentCourse, Boolean forOptionalFee, Boolean forAdditionalFee, Boolean forDiscount)
        {
            Boolean isLocked = false;
            Boolean isYearSemesterLocked = true;

            if ((forOptionalFee) && ((!forAdditionalFee) && (!forDiscount)))
            {
                isYearSemesterLocked = IsRecordLocked(dateStart, dateEnd, serverDateTime, addMonths);
            }
            else if (((forAdditionalFee) || (forDiscount)) && (!forOptionalFee))
            {
                isYearSemesterLocked = IsRecordLocked(dateEnd, serverDateTime, addMonths);
            }

            if ((isYearSemesterLocked) ||
                (((isEnrolmentLevelMarkedDeleted) && ((!isCurrentCourse) || (isCurrentCourse))) &&
                ((forOptionalFee) || (forDiscount))) ||
                (((!isEnrolmentLevelMarkedDeleted) && (!isCurrentCourse)) &&
                ((forOptionalFee) || (forDiscount))))
            {
                isLocked = !isLocked;
            }
            

            return isLocked;

        } //-----------------------------

        //this function determines if the record is locked by date start and date end     
        //Database Function:    ums.IsRecordLockByYearSemesterID
        public static Boolean IsRecordLocked(DateTime dateStart, DateTime dateEnd, DateTime serverDateTime, Int32 addMonths)
        {
            Boolean isLocked = true;

            if ((DateTime.Compare(serverDateTime.AddMonths(addMonths), dateStart) >= 0) &&
                (DateTime.Compare(serverDateTime.AddMonths(addMonths), dateEnd) <= 0))
            {
                isLocked = !isLocked;
            }

            return isLocked;

        } //-----------------------------

        //this function determines if the record is locked by date start and date end no advance date       
        //Database Function:    ums.IsRecordLockByYearSemesterIDNoAdvance
        public static Boolean IsRecordLocked(DateTime dateEnd, DateTime serverDateTime, Int32 addMonths)
        {
            Boolean isLocked = true;

            if (DateTime.Compare(serverDateTime.AddMonths(addMonths), dateEnd) <= 0)
            {
                isLocked = !isLocked;
            }

            return isLocked;

        } //-----------------------------

        //this function determines if the record is locked by date start and date end no add months
        //Database Function:    ums.IsRecordLockByYearSemesterIDNoAddMonths
        public static Boolean IsRecordLocked(DateTime dateStart, DateTime dateEnd, DateTime serverDateTime)
        {
            Boolean isLocked = true;

            if ((DateTime.Compare(serverDateTime, dateStart) >= 0) &&
                (DateTime.Compare(serverDateTime, dateEnd) <= 0))
            {
                isLocked = !isLocked;
            }

            return isLocked;

        } //-----------------------------

        //this function determines if the record is locked by reflected date and received date
        //Database Function:    ums.IsRecordLockByReflectedCreatedDate
        public static Boolean IsRecordLocked(Int32 addMonths, DateTime createdDate, DateTime serverDateTime)
        {
            Boolean isLocked = true;

            if (DateTime.Compare(serverDateTime, createdDate.AddMonths(addMonths)) <= 0)
            {
                isLocked = !isLocked;
            }

            return isLocked;

        } //-----------------------------

        //this function determines if the record is locked by reflected date and received date
        //Database Function:    ums.IsRecordLockByReflectedCreatedDate
        public static Boolean IsRecordLocked(Int32 addMonths, DateTime receiptDate, DateTime createdDate, DateTime serverDateTime)
        {
            Boolean isLocked = true;

            if ((DateTime.Compare(receiptDate, createdDate.AddMonths(addMonths)) <= 0) &&
                (DateTime.Compare(receiptDate, createdDate.AddMonths(addMonths - (addMonths * 2))) >= 0) &&
                (DateTime.Compare(serverDateTime, createdDate.AddMonths(addMonths)) <= 0))
            {
                isLocked = !isLocked;
            }

            return isLocked;

        } //-----------------------------
      
        //this function returns the network information
        public static String GetNetworkInformation()
        {
            StringBuilder strNetInfo = new StringBuilder();

            if (NetworkInterface.GetIsNetworkAvailable())
            {
                IPGlobalProperties computerProperties = IPGlobalProperties.GetIPGlobalProperties();
                NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

                strNetInfo.Append("Windows IP Configuration: " + "\n\n");
                strNetInfo.Append("\t" + "Host Name...........................: " + computerProperties.HostName + "\n");
                strNetInfo.Append("\t" + "Domain Name.........................: " + computerProperties.DomainName + "\n");

                if (nics == null || nics.Length < 1)
                {
                    strNetInfo.Append("\n" + "No network interface found.");
                }
                else
                {
                    foreach (NetworkInterface adapter in nics)
                    {
                        if (!adapter.Supports(NetworkInterfaceComponent.IPv4))
                        {
                            continue;
                        }

                        IPInterfaceProperties properties = adapter.GetIPProperties();
                        IPv4InterfaceProperties ipV4 = properties.GetIPv4Properties();

                        strNetInfo.Append("\n" + adapter.NetworkInterfaceType + " Adapter " + adapter.Name + "\n");
                        strNetInfo.Append("\t" + "Description.........................: " + adapter.Description + "\n");
                        strNetInfo.Append("\t" + "Physical Address....................: ");

                        PhysicalAddress address = adapter.GetPhysicalAddress();
                        Byte[] bytes = address.GetAddressBytes();

                        for (int i = 0; i < bytes.Length; i++)
                        {
                            strNetInfo.Append(bytes[i].ToString("X2"));

                            if (i != bytes.Length - 1)
                            {
                                strNetInfo.Append("-");
                            }
                        }

                        if (ipV4 == null)
                        {
                            strNetInfo.Append("\n");
                            strNetInfo.Append("\t" + "No IPv4 information is available for this interface.");
                            continue;
                        }

                        strNetInfo.Append("\n");
                        strNetInfo.Append("\t" + "IP Address..........................: ");

                        foreach (UnicastIPAddressInformation ipInfo in properties.UnicastAddresses)
                        {
                            strNetInfo.Append(ipInfo.Address);
                            strNetInfo.Append("   ");
                        }

                        strNetInfo.Append("\n");
                        strNetInfo.Append("\t" + "Gateway Addresses...................: ");

                        foreach (GatewayIPAddressInformation gateway in properties.GatewayAddresses)
                        {
                            strNetInfo.Append(gateway.Address);
                            strNetInfo.Append("   ");
                        }
                        strNetInfo.Append("\n");
                        strNetInfo.Append("\t" + "DNS Servers.........................: ");

                        foreach (IPAddress ipInfo in properties.DnsAddresses)
                        {
                            bytes = ipInfo.GetAddressBytes();

                            for (int i = 0; i < bytes.Length; i++)
                            {
                                strNetInfo.Append(bytes[i].ToString());

                                if (i != bytes.Length - 1)
                                {
                                    strNetInfo.Append(".");
                                }
                            }

                            strNetInfo.Append("   ");
                        }

                        strNetInfo.Append("\n");
                    }
                }

            }
            else
            {
                strNetInfo.Append("Using LOCALHOST network information");
            }

            return strNetInfo.ToString();

        } //----------------------------

        //this function returns the extension name of the file
        public static String GetFilenameExtension(String filePath)
        {
            String strExt = String.Empty;

            if (File.Exists(filePath))
            {
                FileInfo file = new FileInfo(filePath);
                strExt = file.Extension;
            }

            return strExt;
        } //----------------------------------

        //this function gets the array of bytes of a file
        public static Byte[] GetFileArrayBytes(String filePath)
        {
            FileStream fileStr = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            BinaryReader binReader = new BinaryReader(fileStr);

            Byte[] fileByte = binReader.ReadBytes((Int32)fileStr.Length);

            fileStr.Close();
            binReader.Close();

            fileStr = null;
            binReader = null;

            return fileByte;

        } //--------------------------

        //this function trims the special characters
        public static String TrimStartEndString(String strBase)
        {
            if (!String.IsNullOrEmpty(strBase))
            {
                return strBase.TrimStart(null).TrimEnd(null);
            }
            else
            {
                return "";
            }

        } //-----------------------

        //this function gets the complete name
        public static String GetCompleteNameMiddleInitial(DataRow srcRow, String colLName, String colFName, String colMName)
        {
            return RemoteServerLib.ProcStatic.DataRowConvert(srcRow, colLName, String.Empty).ToUpper() + ", " +
                RemoteServerLib.ProcStatic.DataRowConvert(srcRow, colFName, String.Empty) + " " +
                (String.IsNullOrEmpty(RemoteServerLib.ProcStatic.DataRowConvert(srcRow, colMName, String.Empty)) ? "" :
                (RemoteServerLib.ProcStatic.DataRowConvert(srcRow, colMName, String.Empty).Substring(0, 1).ToUpper() + "."));
        } //------------------------------        

        //this function gets the complete name
        public static String GetCompleteNameMiddleInitial(String lName, String fName, String mName)
        {
            return lName.ToUpper() +  ", " + fName + " " + (String.IsNullOrEmpty(mName) ? "" : (mName.Substring(0, 1).ToUpper() + "."));
        } //------------------------------   

        //this function gets the complete name
        public static String GetCompleteNameFullMiddleName(DataRow srcRow, String colLName, String colFName, String colMName)
        {
            return RemoteServerLib.ProcStatic.DataRowConvert(srcRow, colLName, String.Empty).ToUpper() + ", " +
                RemoteServerLib.ProcStatic.DataRowConvert(srcRow, colFName, String.Empty) + " " +
                RemoteServerLib.ProcStatic.DataRowConvert(srcRow, colMName, String.Empty);
        } //------------------------------        

        //this function gets the complete name
        public static String GetCompleteNameFullMiddleName(String lName, String fName, String mName)
        {
            return lName.ToUpper() + ", " + fName + " " + mName;
        } //------------------------------   

        #endregion
    }
}
