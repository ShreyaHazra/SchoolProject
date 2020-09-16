using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolWork.Models;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using Compare = System.ComponentModel.DataAnnotations.CompareAttribute;

namespace SchoolWork.Models
{
    public class SchoolAdminModel
    {


    }

    public class SchoolAdminLogin
    {

        [Display(Prompt = "Enter Your First Name")]
        [Required(ErrorMessage = "UserName is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]

        public string Password { get; set; }

        public string School_Name { get; set; }

        public string School_Code { get; set; }

        public int School_Id { get; set; }


        public string RememberMe { get; set; }


    }
    public class StudentGroupMaster
    {
        public int School_Id { get; set; }

        public string School_Name { get; set; }

        public string School_Code { get; set; }

        public int Group_Id { get; set; }

        [Required(ErrorMessage = "Group Name is required.")]

        public String Group_Name { get; set; }

    }

    public class SchoolSectionMaster
    {
        public int School_Id { get; set; }

        public string School_Name { get; set; }

        public string School_Code { get; set; }

        public SchoolSectionMaster()
        {

            this.Class_Name = new List<SelectListItem>();

        }
        public List<SelectListItem> Class_Name { get; set; }

        [Required(ErrorMessage = "Class  is required.")]
        public int Class_Id { get; set; }

        public int Section_Id { get; set; }

        [Required(ErrorMessage = "Section Name is required.")]

        public String Section_Name { get; set; }

        [Required(ErrorMessage = "Section Room Number is required.")]

        public int Section_Room_Number { get; set; }

    }

    public class SchoolSubjectMaster
    {
        public int School_Id { get; set; }

        public String School_Name { get; set; }

        public String School_Code { get; set; }

        public String subject_type { get; set; }
        public int priority_val { get; set; }


        // public string[] subject_type = new[] { "Primary", "Additional", "Language" };


        public SchoolSubjectMaster()
        {

            this.Class_Name = new List<SelectListItem>();

        }
        public List<SelectListItem> Class_Name { get; set; }

        [Required(ErrorMessage = "Class  is required.")]
        public int Class_Id { get; set; }

        public String Subject_Id { get; set; }

        [Required(ErrorMessage = "Subject Name is required.")]

        public String Subject_Name { get; set; }

        public String exam_sub_type { set; get; }

        [Required(ErrorMessage = "Subject Code is required.")]

        public String Subject_Code { get; set; }

        [Required(ErrorMessage = "Full Marks is Require")]
        public int FullMarks { get; set; }

        [Required(ErrorMessage = "Pass Marks is require")]
        public int PassMarks { get; set; }

        [Required]
        [Display(Name = "Input practical Marks")]
        public int PracticalMarks { set; get; }

        public String Additional_Subject { get; set; }

    }



    public class SchoolEmpTypeMaster
    {
        public int Type_Id { get; set; }

        public int School_Id { get; set; }

        public String School_Name { get; set; }

        public String Type_Name { get; set; }

        public String School_Code { get; set; }

        //  public int EmpType_Id { get; set; }

        [Required(ErrorMessage = "Employee Type is required.")]

        public String EmpType_Name { get; set; }

        public IEnumerable<SchoolEmpTypeMaster> EmpTypeMasteRList { get; set; }


        //public SchoolEmpTypeMaster()
        //{

        //    this.EmpTypeMasteRList = new List<SelectListItem>();

        //}
        //public List<SelectListItem> EmpTypeMasteRList { get; set; }

    }

    public class SchoolEmployeeMaster
    {


        public int School_Id { get; set; }

        public String School_Name { get; set; }

        public String School_Code { get; set; }

        public SchoolEmployeeMaster()
        {

            this.EmpType_Name = new List<SelectListItem>();

        }
        public List<SelectListItem> EmpType_Name { get; set; }

        [Required(ErrorMessage = "Employee Type  is required.")]

        public int EmpType_Id { get; set; }

        // public int Employee_Id { get; set; }

        [Required(ErrorMessage = "Subject Name is required.")]
        public String Employee_Name { get; set; }

        [Required(ErrorMessage = "Subject Code is required.")]
        public String Employee_Code { get; set; }

        [Required(ErrorMessage = "Employee  Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public String Employee_Email { get; set; }

        [Required(ErrorMessage = "Employee Confirm  Email is required.")]
        [Compare("Employee_Email", ErrorMessage = "EmployeeEmail and Confirmation Email must match.")]
        public String Employee_Confirm_Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        public String Employee_Password { get; set; }

        [Required(ErrorMessage = "Employee Mobile Number is required.")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Please Input a Valid  Phone Number")]
        public String Employee_Mobile_Number { get; set; }

        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Please Input a Valid  Phone Number")]
        public String Employee_Alt_Number { get; set; }

        [Required(ErrorMessage = "Employee Address is required.")]
        public String Employee_Address { get; set; }

        [Required(ErrorMessage = "Employee DOB is required.")]
        public String Employee_DOB { get; set; }

        public int New_Id { get; set; }

        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public String School_Email { get; set; }

        public String School_Password { get; set; }



    }

    public class ParentDetails
    {
        public int ParentID { get; set; }

        public String ParentName { get; set; }

        public String ParentContact { get; set; }

        public String ParentEmail { get; set; }

        public String ParentPassword { get; set; }

        public String School_Name { get; set; }

        public String School_Code { get; set; }

        public int School_Id { get; set; }


    }

    public class SchoolNoticeAdd
    {
        public int School_Id { get; set; }

        public String School_Name { get; set; }

        public String School_Code { get; set; }

        public int Notice_Id { get; set; }

        [Required(ErrorMessage = "Notice Title is required.")]
        public String Notice_Title { get; set; }

        [Required(ErrorMessage = "Notice Description is required.")]
        public String Notice_Description { get; set; }

        [Required(ErrorMessage = "Notice Published Date required.")]
        public String Notice_Published_On { get; set; }

        public String Notice_Status { get; set; }

        public SchoolNoticeAdd()
        {

            this.User_Type_Name = new List<SelectListItem>();

        }
        public List<SelectListItem> User_Type_Name { get; set; }

        [Required(ErrorMessage = "Employee Type  is required.")]
        public int User_Type_Id { get; set; }
    }

    public class AdminNoticeDetails
    {
        public int Notice_Id { get; set; }
        public String School_Code { get; set; }
        public String School_Name { get; set; }
        public String Notice_Title { get; set; }
        public String Notice_Description { get; set; }
        public String User_Id { get; set; }
        public String Notice_Published_On { get; set; }
        public String Notice_Status { get; set; }
    }


    public class EmployeeDetails
    {
        public int Employee_Id { get; set; }
        public String School_Code { get; set; }
        public String School_Name { get; set; }
        public int EmpType_Id { get; set; }
        public String EmpType_Name { get; set; }
        [Required(ErrorMessage = "Password is required.")]
        public String Employee_Name { get; set; }
        public String Employee_Code { get; set; }
        public String Employee_Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8}$", ErrorMessage = "Password must meet requirements[Must be 8 Digit Long & contains 1 Capital Letter, 1 Small Letter,1 Special Characrter]")]
        public String Employee_Password { get; set; }

        public String Employee_Password2 { get; set; }

        public String Employee_Confirm_Password { get; set; }

        [Required(ErrorMessage = "Mobile Number  is required.")]

        public String Employee_Mobile_Number { get; set; }

        public String Employee_Alt_Number { get; set; }

        [Required(ErrorMessage = "Employee DOB  is required.")]
        public String Employee_DOB { get; set; }

        public IEnumerable<EmployeeDetails> employeeDetails { get; set; }

    }

    public class SchoolFeesAdd
    {
        public int School_Id { get; set; }

        [Display(Name = "School Code")]
        public String School_Code { get; set; }
        [Display(Name = "Fees Id")]
        public int Fees_Id { get; set; }

        public String Class { get; set; }
        [Display(Name = "Fees Name")]
        [Required(ErrorMessage = "Fees Name is required.")]
        public String Fees_Name { get; set; }

        [Display(Name = "Fees Description")]
        [Required(ErrorMessage = "Fees Description is required.")]
        public String Fees_Desc { get; set; }

        [Required(ErrorMessage = "Fees Amount is required.")]
        public String Amount { get; set; }

        public SchoolFeesAdd()
        {

            this.Class_Name = new List<SelectListItem>();
            this.Year_Name = new List<SelectListItem>();
        }
        public List<SelectListItem> Class_Name { get; set; }

        public List<SelectListItem> Year_Name { get; set; }

        [Required(ErrorMessage = "Class Id is required.")]
        public int Class_Id { get; set; }

        [Required(ErrorMessage = "Year is required.")]
        public int Year { get; set; }
    }




    public class WorkRole
    {


        public int Role_Id { get; set; }

        public String Parent_Menu_Order { get; set; }


        public int Parent_Menu { get; set; }


        public String Sub_Menu { get; set; }

        public String Sub_Menu_Cn { get; set; }

        public String Sub_Menu_Fn { get; set; }

        public String User_Type_Id { get; set; }

        public String Class_Name { get; set; }

        public bool RoleCheckUnchecK { get; set; }

        public IEnumerable<WorkRole> workroleinfo { get; set; }

    }

    //public class WorkRole_Header
    //{

    //    public int WorkGroup_Id { get; set; }

    //    public String WorkGroup_Name { get; set; }

    //    public String Parent_Menu_Fn { get; set; }

    //    public String Parent_Menu_Cn { get; set; }

    //    public String User_Type { get; set; }

    //    public List<WorkRole_Header> marklist;

    //    public double marks { get; set; }

    //    public String date { get; set; }

    //    public int sub_id { get; set; }
    //}

    public class WorkRole_Header
    {
        public int WorkGroup_Id { get; set; }
        public String WorkGroup_Name { get; set; }
        public String Parent_Menu_Fn { get; set; }
        public String Parent_Menu_Cn { get; set; }
        public String User_Type { get; set; }
        public List<WorkRole_Header> marklist; public List<WorkRole_Header> studentlist; public List<WorkRole_Header> homeworklist; public String subject { get; set; }
        public String status { get; set; }
        public String Description { get; set; }
        public int std_id;
        public string std_name;
        public double marks { get; set; }
        public String date { get; set; }
        public int sub_id { get; set; }
    }


    public class CreateExamSchedule
    {
        public int School_Id { get; set; }

        public String School_Code { get; set; }
        public String InputTime { get; set; }
        public String InputTimeA { get; set; }

        public int ExamSchedule_Id { get; set; }

        public String Class { get; set; }


        public String Exm_Term_Name { get; set; }

        public String Subject_Namee { get; set; }

        public String Day_Namee { get; set; }

        [Required(ErrorMessage = "Exam Day is required.")]
        public String Exam_Date { get; set; }

        [Required(ErrorMessage = "Start Time is required.")]
        public String Start_Time { get; set; }

        [Required(ErrorMessage = "End Time is required.")]
        public String End_Time { get; set; }



        public CreateExamSchedule()
        {


            this.Class_Name = new List<SelectListItem>();


            this.Year_Name = new List<SelectListItem>();

            this.Section_Name = new List<SelectListItem>();

            this.Exam_Term_Name = new List<SelectListItem>();

            this.Subject_Name = new List<SelectListItem>();

            this.Day_Name = new List<SelectListItem>();

        }

        public List<SelectListItem> Exam_Term_Name { get; set; }

        public List<SelectListItem> Year_Name { get; set; }

        public List<SelectListItem> Class_Name { get; set; }

        public List<SelectListItem> Section_Name { get; set; }



        public List<SelectListItem> Subject_Name { get; set; }

        public List<SelectListItem> Day_Name { get; set; }

        [Required(ErrorMessage = "Exam Term Id is required.")]
        public int Exam_Term_id { get; set; }


        [Required(ErrorMessage = "Year is required.")]
        public String Year { get; set; }

        [Required(ErrorMessage = "Class Id is required.")]
        public int Class_Id { get; set; }

        [Required(ErrorMessage = "Section Id is required.")]
        public int Section_Id { get; set; }

        [Required(ErrorMessage = "Exam Term Id is required.")]
        public int ExamTerm_Id { get; set; }

        [Required(ErrorMessage = "Subject Id is required.")]
        public int Subject_id { get; set; }

        [Required(ErrorMessage = "Day is required.")]
        public int Day_Id { get; set; }

        public IEnumerable<CreateExamSchedule> ExamSchduleList { get; set; }
        [Required]
        [Display(Name = "Input Full Marks")]
        public int FullMarks { get; set; }
        [Required]
        [Display(Name = "Input Pass Marks")]
        public int PassMarks { set; get; }

        [Required]
        [Display(Name = "Input practical Marks")]
        public int PracticalMarks { set; get; }

        public String Exam_Subject_Type { get; set; }

    }


    public class Routine
    {

        public int Category_ID { get; set; }
        public String Categoryname { get; set; }
        public String CategoryDescription { get; set; }
        public int id { get; set; }
        public String RoomName { get; set; }
        public String RoomNo { get; set; }
        public List<SelectListItem> Class_Name { get; set; }
        [Required(ErrorMessage = "Class  is required.")]


        public String Period_type { get; set; }
        public String Period_Name { get; set; }
        public String Occupied { get; set; }
        public int Floor { get; set; }
        public String Room { get; set; }
        public List<SelectListItem> RoomCategory { get; set; }
        public List<SelectListItem> StatusCategory { get; set; }
        public List<Routine> Templist { get; set; }
        //for creating class
        public int Class_ID { get; set; }
        public String ClassName { get; set; }
        public String Stime { get; set; }
        public String Etime { get; set; }
        //for period
        public String starttime { get; set; }
        public String endtime { get; set; }
        public int Duration { get; set; }
        public String period_name { get; set; }
        public String period_type { get; set; }
        public int period_order { get; set; }
        public List<Routine> TemplistChild { get; set; }
        public List<Routine> TemplistParent { get; set; }

        //// for holiday
        /// <summary>
        ///
        public int Event_ID { get; set; }
        public List<Routine> TempHoliday { get; set; }
        public String StartDate { get; set; }
        public String EndDate { get; set; }
        public String Subject { get; set; }
        public String Description { get; set; }
        public String full_day { get; set; }
        public String theme_color { get; set; }
        public String EventType { get; set; }
        //Routine
        public List<SelectListItem> ClassList { get; set; }
        [Required]
        public String Class { get; set; }

        [Required]
        public String ClassView { get; set; }
        public List<SelectListItem> TeacherList { get; set; }
        [Required]
        public String Teacher { get; set; }
        public List<SelectListItem> RoomList { get; set; }
        [Required]
        public String RoomId { get; set; }
        public List<SelectListItem> SubjectList { get; set; }
        [Required]
        public String SubjectId { get; set; }
        [Required]
        public String SectionView { get; set; }
        public List<SelectListItem> SectionList { get; set; }
        [Required]
        public String SectionId { get; set; }
        public List<SelectListItem> DayList { get; set; }
        [Required]
        public String DayId { get; set; }
        public List<SelectListItem> PeriodList { get; set; }
        [Required]
        public String PeriodId { get; set; }

        public List<Routine> TempRoutine { get; set; }
        public int Routine_Id { get; set; }
        public String holidays;

        public Routine(String PeriodName)
        {

            this.PeriodId = PeriodName;

        }
        public Routine(int Routine_Id, String DayName, String PeriodName, String Teacher, String RoomNo)
        {
            this.Routine_Id = Routine_Id;
            this.DayId = DayName;
            this.PeriodId = PeriodName;
            this.Teacher = Teacher;
            this.RoomId = RoomNo;
        }
        public Routine()
        {
        }
    }
    ////////School Routine

    public class SchoolRoutine
    {
        public int Routine_Id { get; set; }
        public int Row_Id { get; set; }
        public int School_Id { get; set; }
        public String School_Name { get; set; }

        public String Class_Namee { get; set; }
        public String Section_Namee { get; set; }
        public String Employee_Namee { get; set; }
        public String Subject_Namee { get; set; }
        public String Room_Namee { get; set; }
        public String Day_Namee { get; set; }
        public String Period_Namee { get; set; }
        public String School_Code { get; set; }
        public String Start_Time { get; set; }
        public String End_Time { get; set; }
        public SchoolRoutine()
        {
            this.Class_Name = new List<SelectListItem>();
            this.Section_Name = new List<SelectListItem>();
            this.Subject_Name = new List<SelectListItem>();
            this.Employee_Name = new List<SelectListItem>();
            this.Room_Name = new List<SelectListItem>();
            this.Day_Name = new List<SelectListItem>();
            this.Year_Name = new List<SelectListItem>();
            this.Period_Name = new List<SelectListItem>();

        }
        public List<SelectListItem> Period_Name { get; set; }
        public List<SelectListItem> Class_Name { get; set; }
        public List<SelectListItem> Room_Name { get; set; }
        public List<SelectListItem> Section_Name { get; set; }
        public List<SelectListItem> Subject_Name { get; set; }
        public List<SelectListItem> Employee_Name { get; set; }
        public List<SelectListItem> Day_Name { get; set; }
        public List<SelectListItem> Year_Name { get; set; }
        [Required(ErrorMessage = "Class  is required.")]
        public int Class_Id { get; set; }

        [Required(ErrorMessage = "Period  is required.")]
        public int Period_Id { get; set; }
        [Required(ErrorMessage = "Room  is required.")]
        public int Room_Id { get; set; }
        [Required(ErrorMessage = "Section  is required.")]
        public int Section_Id { get; set; }
        [Required(ErrorMessage = "Subject  is required.")]
        public int Subject_Id { get; set; }
        [Required(ErrorMessage = "Employee  is required.")]
        public int Employee_Id { get; set; }
        [Required(ErrorMessage = "Day  is required.")]
        public int Day_Id { get; set; }
        [Required(ErrorMessage = "Year  is required.")]
        public int Year { get; set; }
        // [Required(ErrorMessage = "Subject Name is required.")]
        //  public String Subject_Name { get; set; }
        [Required(ErrorMessage = "Subject Code is required.")]
        public String Subject_Code { get; set; }
    }




    public class SyllabusModule
    {
        public int Exam_Term_id { get; set; }

        public int School_Id { get; set; }

        public String School_Name { get; set; }

        public String School_Code { get; set; }

        public String Class { get; set; }

        public String Exam_Term_Name { get; set; }

        public SyllabusModule()
        {

            this.Class_Name = new List<SelectListItem>();


        }
        public List<SelectListItem> Class_Name { get; set; }

        [Required(ErrorMessage = "Class  is required.")]
        public int Class_Id { get; set; }

    }

    public class RoleAssigned
    {

        public int ID { get; set; }
        public String Emp_Code { get; set; }
        public int eid { get; set; }
        public int Sub_ID { get; set; }

        public int class_id { get; set; }
        public int sec_id { get; set; }
        public int EmpType_ID { get; set; }
        public List<SelectListItem> Emp_Name { get; set; }
        public List<SelectListItem> Class_ID { get; set; }

        public List<SelectListItem> Sec_ID { get; set; }
        public List<SelectListItem> Sub_Name { get; set; }
        public List<SelectListItem> EmpType_Name { get; set; }
        public List<RoleAssigned> RoleList { get; set; }

        public RoleAssigned()
        {
            this.Emp_Name = new List<SelectListItem>();
            this.Class_ID = new List<SelectListItem>();
            this.Sec_ID = new List<SelectListItem>();
            this.Sub_Name = new List<SelectListItem>();
            this.EmpType_Name = new List<SelectListItem>();
            this.RoleList = new List<RoleAssigned>();

        }
        public String subject_name { get; set; }

        public String class_name { get; set; }

        public String sec_name { get; set; }
    }

    public class PositionAssessmentView
    {
        public string Id { get; set; }

        public IEnumerable<SelectListItem> Data { get; set; }

        public string SelectedId { get; set; }
    }

    public class Event_Calendar
    {
        public int Event_ID { get; set; }
        public String Subject { get; set; }
        public String Description { get; set; }
        public String Start_Date { get; set; }
        public String End_Date { get; set; }
        public String Theme_Color { get; set; }
        public String Is_Full_Day { get; set; }

    }

    public class SchoolAssignment
    {
        public int assign_ID { get; set; }
        public String School_code { get; set; }
        public String A_Topic { get; set; }
        public String assign_Name { get; set; }
        public int class_Id { get; set; }
        public List<SelectListItem> Class_Name { get; set; }
        public List<SelectListItem> Section_Name { get; set; }
        public List<SelectListItem> Subject_Name { get; set; }
        public List<SelectListItem> Stu_Name { get; set; }
        public int sec_id { get; set; }
        public int sub_id { get; set; }
        public string session { get; set; }
        public int stu_id { get; set; }
        public string issue_date { get; set; }
        public string date_to { get; set; }
        public string subm_date { get; set; }
        public String Description { get; set; }
        public String Status { get; set; }
        public String remarks { get; set; }
        public SchoolAssignment()
        {
            this.Stu_Name = new List<SelectListItem>(); this.Class_Name = new List<SelectListItem>();
            this.Section_Name = new List<SelectListItem>();
            this.Subject_Name = new List<SelectListItem>();
        }
    }

    //public class Routine
    //{

    //    public List<Routine> Templist { get; set; }
    //    public int Category_ID { get; set; }
    //    public String Categoryname { get; set; }

    //    public String CategoryDescription { get; set; }

    //    public int id { get; set; }

    //    public String RoomName { get; set; }

    //    public String RoomNo { get; set; }


    //    public String Occupied { get; set; }

    //    public int Floor { get; set; }

    //    public String Room { get; set; }
    //    public List<SelectListItem> RoomCategory { get; set; }

    //    public List<SelectListItem> StatusCategory { get; set; }
    //}

    //public class Routine
    //{


    //    public int Category_ID { get; set; }
    //    public String Categoryname { get; set; }

    //    public String CategoryDescription { get; set; }

    //    public int id { get; set; }

    //    public String RoomName { get; set; }

    //    public String RoomNo { get; set; }
    //    public List<SelectListItem> Class_Name { get; set; }

    //    [Required(ErrorMessage = "Class  is required.")]




    //    public String Period_type { get; set; }

    //    public String Period_Name { get; set; }
    //    public String Occupied { get; set; }

    //    public int Floor { get; set; }

    //    public String Room { get; set; }
    //    public List<SelectListItem> RoomCategory { get; set; }

    //    public List<SelectListItem> StatusCategory { get; set; }
    //    public List<Routine> Templist { get; set; }

    //    //for creating class
    //    public int Class_ID { get; set; }
    //    public String ClassName { get; set; }

    //    public String Stime { get; set; }
    //    public String Etime { get; set; }
    //    //for period

    //    public String starttime { get; set; }

    //    public String endtime { get; set; }
    //    public int Duration { get; set; }

    //    public String period_name { get; set; }

    //    public String period_type { get; set; }
    //    public int period_order { get; set; }

    //    public List<Routine> TemplistChild { get; set; }
    //    public List<Routine> TemplistParent { get; set; }


    //    //// for holiday
    //    /// <summary>
    //    /// 

    //    public int Event_ID { get; set; }
    //    public List<Routine> TempHoliday { get; set; }
    //    public String StartDate { get; set; }
    //    public String EndDate { get; set; }

    //    public String Subject { get; set; }
    //    public String Description { get; set; }
    //    public String full_day { get; set; }

    //    public String EventType { get; set; }


    //}

    //public class Routine
    //{


    //    public int Category_ID { get; set; }
    //    public String Categoryname { get; set; }

    //    public String CategoryDescription { get; set; }

    //    public int id { get; set; }

    //    public String RoomName { get; set; }

    //    public String RoomNo { get; set; }
    //    public List<SelectListItem> Class_Name { get; set; }

    //    [Required(ErrorMessage = "Class  is required.")]




    //    public String Period_type { get; set; }

    //    public String Period_Name { get; set; }
    //    public String Occupied { get; set; }

    //    public int Floor { get; set; }

    //    public String Room { get; set; }
    //    public List<SelectListItem> RoomCategory { get; set; }

    //    public List<SelectListItem> StatusCategory { get; set; }
    //    public List<Routine> Templist { get; set; }

    //    //for creating class
    //    public int Class_ID { get; set; }
    //    public String ClassName { get; set; }

    //    public String Stime { get; set; }
    //    public String Etime { get; set; }
    //    //for period

    //    public String starttime { get; set; }

    //    public String endtime { get; set; }
    //    public int Duration { get; set; }

    //    public String period_name { get; set; }

    //    public String period_type { get; set; }
    //    public int period_order { get; set; }

    //    public List<Routine> TemplistChild { get; set; }
    //    public List<Routine> TemplistParent { get; set; }


    //    //// for holiday
    //    /// <summary>
    //    /// 

    //    public int Event_ID { get; set; }
    //    public List<Routine> TempHoliday { get; set; }
    //    public String StartDate { get; set; }
    //    public String EndDate { get; set; }

    //    public String Subject { get; set; }
    //    public String Description { get; set; }
    //    public String full_day { get; set; }

    //    public String EventType { get; set; }

    //    //Routine

    //    public List<SelectListItem> ClassList { get; set; }

    //    [Required]
    //    public String Class { get; set; }


    //    [Required]
    //    public String ClassView { get; set; }
    //    public List<SelectListItem> TeacherList { get; set; }
    //    [Required]
    //    public String Teacher { get; set; }
    //    public List<SelectListItem> RoomList { get; set; }
    //    [Required]
    //    public String RoomId { get; set; }
    //    public List<SelectListItem> SubjectList { get; set; }
    //    [Required]
    //    public String SubjectId { get; set; }

    //    [Required]
    //    public String SectionView { get; set; }
    //    public List<SelectListItem> SectionList { get; set; }

    //    [Required]
    //    public String SectionId { get; set; }
    //    public List<SelectListItem> DayList { get; set; }
    //    [Required]
    //    public String DayId { get; set; }
    //    public List<SelectListItem> PeriodList { get; set; }

    //    [Required]
    //    public String PeriodId { get; set; }


    //    public List<Routine> TempRoutine { get; set; }

    //    public int Routine_Id { get; set; }

    //    public String holidays;

    //    public Routine(String PeriodName)
    //    {


    //        this.PeriodId = PeriodName;

    //    }
    //    public Routine(int Routine_Id, String DayName, String PeriodName, String Teacher, String RoomNo)
    //    {
    //        this.Routine_Id = Routine_Id;
    //        this.DayId = DayName;

    //        this.PeriodId = PeriodName;
    //        this.Teacher = Teacher;
    //        this.RoomId = RoomNo;
    //    }
    //    public Routine()
    //    {

    //    }
    //  //  public List<School_Session_Year> SessionYearList { get; set; }
    //}
    public class School_Session_Year
    {
        public int Session_Year_Id { get; set; } 
        public String Start_Month { get; set; }
        public String Start_Year { get; set; }
        public String End_Month { get; set; }
        public String End_Year { get; set; }
        public String Session_Name { get; set; }

 
              public List<School_Session_Year> SessionYearList { get; set; }


      
    }

   
    public class StudentSyllabus
    {
        public int Syllabus_Id { get; set; }
        [Required(ErrorMessage = "Exam Name is required.")]
        public int Exam_Id { get; set; }
        public int Employee_Id { get; set; }
        public String School_Code { get; set; }
        [Required(ErrorMessage = "Exam Year is required.")]
        public String Exam_Year { get; set; }
        public String Session_Year { get; set; }
        public int Class_Id { get; set; }
        public int Class_Idd { get; set; }
        [Required(ErrorMessage = "Class Name is required.")]
        [AllowHtml]
        public String Syllabus_Desc { get; set; }
        public int Student_Id { get; set; }

        [Required(ErrorMessage = "Section Name is required.")]
        public int Section_Id { get; set; }

        [Display(Prompt = "Enter Exam Year")]
        [Required(ErrorMessage = "Exam Year is required.")]
        public string ExamYear { get; set; }

        [Display(Prompt = "Enter Class Name")]
        [Required(ErrorMessage = "Class Name is required.")]
        public string ClassName { get; set; }

        public string Class_Nam { get; set; }

        public string Section_Nam { get; set; }

        public string student_marks { get; set; }

        public int Subject_Id { get; set; }
        public String Subject_Name { get; set; }
        public int Score { get; set; }
        public int Period_Id { get; set; }
        public String Period_Name { get; set; }
        public String Presence_Status { get; set; }
        public String Period_Date { get; set; }
        public String Exam_Name { get; set; }
        //[Display(Name = "Start Date")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime Start_Date { get; set; }
        public String Start_Date { get; set; }
        public String End_Date { get; set; }
        //[Display(Name = "End Date")]
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //public DateTime End_Date { get; set; }
        public StudentSyllabus()
        {

            this.ExamType_Name = new List<SelectListItem>();
            this.Class_Name = new List<SelectListItem>();
            this.Section_Name = new List<SelectListItem>();
            this.Year_Name = new List<SelectListItem>();
            this.StudentList = new List<SelectListItem>();
            this.StudentMarksList = new List<SelectListItem>();
            this.PeriodList = new List<SelectListItem>();
            this.SectionList = new List<SelectListItem>();
            this.SubjectList = new List<SelectListItem>();
            this.ExamList = new List<SelectListItem>();

        }



        public List<SelectListItem> ExamType_Name { get; set; }
        public List<SelectListItem> Class_Name { get; set; }
        public List<SelectListItem> Section_Name { get; set; }
        public List<SelectListItem> Year_Name { get; set; }
        public List<SelectListItem> StudentList { get; set; }
        public List<SelectListItem> StudentMarksList { get; set; }
        public List<SelectListItem> PeriodList { get; set; }
        public List<SelectListItem> SectionList { get; set; }
        public List<SelectListItem> SubjectList { get; set; }
        public String Subject_Type { get; set; }
        public String Exam_Subject_Type { get; set; }
        public List<SelectListItem> ExamList { get; set; }

        public int priority_val { get; set; }
        [Required(ErrorMessage = "Full Marks is Require")]
        public int FullMarks { get; set; }

        [Required(ErrorMessage = "Pass Marks is require")]
        public int PassMarks { get; set; }

        [Required]
        [Display(Name = "Input practical Marks")]
        public int PracticalMarks { set; get; }

        public String Additional_Subject { get; set; }

        public String Syllabus_Attachment_name { get; set; }
        public String Syllabus_Attachment_Path { get; set; }


    }




}