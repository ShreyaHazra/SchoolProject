using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolWork.Models;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using Compare = System.ComponentModel.DataAnnotations.CompareAttribute;


namespace SchoolWork.Models
{
    public class EmployeeModel
    {

    }
    public class EmployeeLogin
    {
        [Display(Prompt = "Enter Your First Name")]
        [Required(ErrorMessage = "UserName is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]

        public string Password { get; set; }

        public string EmployeeName { get; set; }

        public int EmployeeID { get; set; }

        public string RememberMe { get; set; }
        public int User_Type { get; set; }

        public EmployeeLogin()
        {

            this.School_Name = new List<SelectListItem>();

        }
        public List<SelectListItem> School_Name { get; set; }

        [Required(ErrorMessage = "School  is required.")]
        public String School_Code { get; set; }


    }

    public class EmpNoticeDetails
    {
        public int    Notice_Id { get; set; }
        public String School_Code { get; set; }
        public String School_Name { get; set; }
        public String Notice_Title { get; set; }
        public String Notice_Description { get; set; }
        public String User_Id { get; set; }
        public String Notice_Published_On { get; set; }
        public String Notice_Status { get; set; }


    }



    public class StudentModel
    {
        // public string EmployeeId { get; set; }
        //  public string EmployeeName { get; set; }
        // public string City { get; set; }
        //  public string Country { get; set; }

        public string ST_Id { get; set; }

        public string SCHL_Code { get; set; }

        public string ST_First_Name { get; set; }

        public string ST_Last_Name { get; set; }

        public string ST_Middle_Name { get; set; }

        public string ST_Gender { get; set; }

        public string ST_DOB { get; set; }

        public int ST_Section { get; set; }
        public int ST_Class { get; set; }

    }

    public class ClassesModel
    {
        //   public string CustomerId { get; set; }
        //   public string CustomerName { get; set; }
        public int Class_Id { get; set; }
        public string Class_Name { get; set; }


    }


    public class SchoolALLFees
    {
        public int School_Id { get; set; }

        public int Student_Id { get; set; }

        public String School_Code { get; set; }

        public int Fees_Id { get; set; }

        public String Class { get; set; }

        [Required(ErrorMessage = "Fees Name is required.")]
        public String Fees_Name { get; set; }

        [Required(ErrorMessage = "Fees Description is required.")]
        public String Fees_Desc { get; set; }

        [Required(ErrorMessage = "Fees Amount is required.")]
        public String Amount { get; set; }

        public SchoolALLFees()
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

        public IEnumerable<SchoolALLFees> StudentFeesDetails { get; set; }





    }




    public class StudentRegistrationDetails
    {


        public int Student_Id { get; set; }
        public int School_Id { get; set; }
        public int Parent_Id { get; set; }
        public String Query_step { get; set; }
        public String StepOne_status { get; set; }
        public String School_Code { get; set; }
        [Required(ErrorMessage = "First Name is required.")]


        public String FullName { get; set; }

        public String first_name { get; set; }


        public String middle_name { get; set; }

        [Required(ErrorMessage = "Last Name is required.")]
        public String last_name { get; set; }

        //public String admission_for { get; set; }

        public StudentRegistrationDetails()
        {

            this.School_Name = new List<SelectListItem>();
            this.Countries = new List<SelectListItem>();
            this.States = new List<SelectListItem>();
            this.Cities = new List<SelectListItem>();
            this.citizenCountry = new List<SelectListItem>();
            this.IdProof_Type = new List<SelectListItem>();
            this.Gender_Name = new List<SelectListItem>();
            this.BloodGroup_Name = new List<SelectListItem>();
            this.AdmissionClass_Name = new List<SelectListItem>();
            this.SchoolBoard_Name = new List<SelectListItem>();

       
            this.Year_Name = new List<SelectListItem>();

            ImagePath = "~/AppFiles/Images/default.png";

            SignaturePath = "~/AppFiles/Images/default.png";


            // BirthCertificatePath = "~/AppFiles/Images/default.png";
        }
        public List<SelectListItem> SchoolBoard_Name { get; set; }

        public List<SelectListItem> AdmissionClass_Name { get; set; }

        public List<SelectListItem> School_Name { get; set; }

        public List<SelectListItem> Countries { get; set; }

        public List<SelectListItem> States { get; set; }

        public List<SelectListItem> Cities { get; set; }

        public List<SelectListItem> citizenCountry { get; set; }

        public List<SelectListItem> IdProof_Type { get; set; }

        public List<SelectListItem> Gender_Name { get; set; }

        public List<SelectListItem> BloodGroup_Name { get; set; }



        public List<SelectListItem> Year_Name { get; set; }

        [Required(ErrorMessage = "School Country is required.")]

        public int CountryId { get; set; }

        [Required(ErrorMessage = "School State is required.")]

        public int StateId { get; set; }

        [Required(ErrorMessage = "School City is required.")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "Current Address  is required.")]
        public String CurrentAddress1 { get; set; }

        public String CurrentAddress2 { get; set; }

        [Required(ErrorMessage = "ZipCode is required.")]
        [RegularExpression(@"^(\d{6})$", ErrorMessage = "Wrong ZipCode")]
        public String currentzipcode { get; set; }

        [Required(ErrorMessage = "Permanent Address is required.")]
        public String PermanentAddress1 { get; set; }

        public String PermanentAddress2 { get; set; }

        [Required(ErrorMessage = "ZipCode is required.")]
        [RegularExpression(@"^(\d{6})$", ErrorMessage = "Wrong ZipCode")]
        public String permanentzipcode { get; set; }

        [Required(ErrorMessage = "Father's Name is required.")]
        public String FatherName { get; set; }

        [Required(ErrorMessage = "Mother's Name is required.")]
        public String MotherName { get; set; }

        [Required(ErrorMessage = "Father's Contact Number is required.")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong mobile")]
        public String FatherContactNumber { get; set; }

        [Required(ErrorMessage = "Mother's Contact Number is required.")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong mobile")]
        public String MotherContactNumber { get; set; }

        [Required(ErrorMessage = "Home Contact Number is required.")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong mobile")]
        public String HomeContactNumber { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public String FatherEmail { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public String LocalGurdianEmail { get; set; }


        public bool LocalGurdian { get; set; }

        public String LocalGurdianValue { get; set; }

        [Required(ErrorMessage = "Gurdian Name is required.")]
        public String LocalGurdianName { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public String MotherEmail { get; set; }

        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong mobile")]
        public String LocalGurdianPhone { get; set; }

        [Required(ErrorMessage = "Date of Birth is required.")]
        public String DOB { get; set; }

        [Required(ErrorMessage = "Place of Birth is required.")]
        public String POB { get; set; }

        [Required(ErrorMessage = "Birth  Certificate Number is required.")]
        public String BCN { get; set; }

        [Required(ErrorMessage = "Identity Proof  is required.")]
        public String IdProof_Number { get; set; }

        [Required(ErrorMessage = "Passport Number is required.")]
        public String PassPort_Number { get; set; }

        [Required(ErrorMessage = "Citizen Country is required.")]
        public int CitizenCountryId { get; set; }

        [Required(ErrorMessage = "Identity Proof is required.")]
        public int IdProof_Id { get; set; }

        [Required(ErrorMessage = "Gender is required.")]
        public int Gender_Id { get; set; }

        [Required(ErrorMessage = "Blood Group is required.")]
        public int BloodGroup_Id { get; set; }

        [Required(ErrorMessage = "Admission Class is required.")]
        public int AdmissionClass_Id { get; set; }

        [Required(ErrorMessage = "School Board is required.")]
        public int SchoolBoard_Id { get; set; }

        [DisplayName("Image")]
        public string ImagePath { get; set; }

        [DisplayName("Signature")]
        public string SignaturePath { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "This Field  is required.")]
        public HttpPostedFileBase ImageUpload { get; set; }

        [NotMapped]
        public HttpPostedFileBase SignatureUpload { get; set; }

        [Required(ErrorMessage = "Last School Name  is required.")]
        public String Last_School_Name { get; set; }

        [Required(ErrorMessage = "Last School Year  is required.")]
        public String Last_School_Year { get; set; }

        [Required(ErrorMessage = "Last School Class  is required.")]
        public String Last_School_Class { get; set; }

        [Required(ErrorMessage = "Last School Exam Marks  is required.")]
        public String Last_School_Exam_Marks { get; set; }

        [Required(ErrorMessage = "Last School Total Exam Marks  is required.")]
        public String Last_School_Total_Marks { get; set; }

        [Required(ErrorMessage = "Last School Total Exam Marks  is required.")]
        public String Last_School_Marks_Percentage { get; set; }

        [Required(ErrorMessage = "School Transfer Certificate Number  is required.")]
        public String School_Transfer_Certifiate_Number { get; set; }

        [Required(ErrorMessage = "School Transfer Certificate Number  is required.")]
        public String Board_Certificate_Number { get; set; }

        [Required(ErrorMessage = "Board Exam Marks Percenage  is required.")]
        public String Board_Exam_Marks { get; set; }

        [Required(ErrorMessage = "Board Exam Marks Percenage  is required.")]
        public String Board_Total_Marks { get; set; }

        public String Marks_Percentage { get; set; }

        [Required(ErrorMessage = "This Field  is required.")]
        public int Disability { get; set; }

        [Required(ErrorMessage = "This Field  is required.")]
        public String Disability_Percentage { get; set; }

        [Required(ErrorMessage = "This Field  is required.")]
        public String Disability_Description { get; set; }

        [Required(ErrorMessage = "This Field  is required.")]
        public String Disability_Certificate_Number { get; set; }

        [Required(ErrorMessage = "This Field  is required.")]
        public int Special_Care { get; set; }

        [Required(ErrorMessage = "This Field  is required.")]
        public String Special_Care_Description { get; set; }

        [Required(ErrorMessage = "This Field  is required.")]
        public bool FormCheck { get; set; }

        [Display(Name = " I Accept All Terms and Conditions")]
        public bool TermsAndConditions { get; set; }

        [DisplayName("Birth Certificate Upload")]
        public string BirthCertificatePath { get; set; }


        public HttpPostedFileBase BirthCertificateUpload { get; set; }

        [DisplayName("Disability Certificate Upload")]
        public string DisabilityCertificatePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase DisabilityCertificateUpload { get; set; }

        [DisplayName("School Transfer Certificate Upload")]
        public string SchoolTransferCertificatePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase SchoolTransferCertificateUpload { get; set; }

        [DisplayName("School Transfer Certificate Upload")]
        public string BoardExamResultPath { get; set; }

        [NotMapped]
        public HttpPostedFileBase BoardExamResultUpload { get; set; }


        [DisplayName("10th Board Exam  Certificate Upload")]
        public string BoardExamCertificatePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase BoardExamCertificateUpload { get; set; }


        [DisplayName("10th Board Exam  Result Upload")]
        public string FinalExamResultPath { get; set; }

        [NotMapped]
        public HttpPostedFileBase FinalExamResultUpload { get; set; }

        public IEnumerable<StudentRegistrationDetails> StudentDetails { get; set; }


        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public string IdProof_Name { get; set; }
        public string Board_Name { get; set; }
        public string Class_Name { get; set; }


        public string Application_Status { get; set; }

        public string interview_note { get; set; }

        public string interview_marks { get; set; }







        public int Fees_Id { get; set; }

        public String Class { get; set; }

        [Required(ErrorMessage = "Fees Name is required.")]
        public String Fees_Name { get; set; }

        [Required(ErrorMessage = "Fees Description is required.")]
        public String Fees_Desc { get; set; }

        [Required(ErrorMessage = "Fees Amount is required.")]
        public String Amount { get; set; }


       [Required(ErrorMessage = "Class Id is required.")]
        public int Class_Id { get; set; }

        [Required(ErrorMessage = "Year is required.")]
        public int Year { get; set; }

        public IEnumerable<StudentRegistrationDetails> StudentFeesDetails { get; set; }
    }


    public class StudentFeesDetails
    {

        //   public int Fees_Id { get; set; }

        //   public String Class { get; set; }

        //   [Required(ErrorMessage = "Fees Name is required.")]
        //  public String Fees_Name { get; set; }

        //    [Required(ErrorMessage = "Fees Description is required.")]
        // public String Fees_Desc { get; set; }

        // [Required(ErrorMessage = "Fees Amount is required.")]
        //  public String Amount { get; set; }

        public int School_Id { get; set; }

        public int Student_Id { get; set; }

        public int Section_Id { get; set; }

        public String School_Code { get; set; }

        public String Fees_Id { get; set; }

        public String Class { get; set; }


        public StudentFeesDetails()
        {

            this.FeeListt = new List<SelectListItem>();
        }
        //  public IEnumerable<StudentFeesDetails> Fees_Name { get; set; }

        public List<SelectListItem> FeeListt { get; set; }
  

       // [Required(ErrorMessage = "Fees Name is required.")]
        public String Fees_Name { get; set; }

        //[Required(ErrorMessage = "Fees Description is required.")]
        public String Fees_Desc { get; set; }

      //  [Required(ErrorMessage = "Fees Amount is required.")]
        public String Amount { get; set; }

        public String Class_Name { get; set; }

        public String Year_Name { get; set; }

       // [Required(ErrorMessage = "Class Id is required.")]
        public int Class_Id { get; set; }

       // [Required(ErrorMessage = "Year is required.")]
        public int Year { get; set; }

        public String Paid_Status { get; set; }

        public String remark_note { get; set; }
        


    }

    public class StudentAllList
    {



        public int Student_Id { get; set; }

        public int School_Id { get; set; }


        public String School_Code { get; set; }

        public String Query_step { get; set; }

        public String StepOne_status { get; set; }

        public int Class_Id { get; set; }
        public int Roll_Number { get; set; }
        public String Class_Name { get; set; }
        public int Section_Id { get; set; }
        public String Section_Name { get; set; }
        public int ExamTerm_Id { get; set; }
        public int ExamTerm_Id_Name { get; set; }


        public int Parent_Id { get; set; }

        public String FullName { get; set; }

        public String first_name { get; set; }


        public String middle_name { get; set; }

        public String last_name { get; set; }


        public int CountryId { get; set; }


        public int StateId { get; set; }

        public int CityId { get; set; }

        public String CurrentAddress1 { get; set; }


        public String CurrentAddress2 { get; set; }

        public String currentzipcode { get; set; }

        public String PermanentAddress1 { get; set; }

        public String PermanentAddress2 { get; set; }

        public String permanentzipcode { get; set; }

        public String FatherName { get; set; }


        public String MotherName { get; set; }


        public String FatherContactNumber { get; set; }

        public String MotherContactNumber { get; set; }

        public String HomeContactNumber { get; set; }


        public String FatherEmail { get; set; }

        public bool LocalGurdian { get; set; }

        public String LocalGurdianValue { get; set; }

        public String LocalGurdianEmail { get; set; }

        public String LocalGurdianName { get; set; }


        public String MotherEmail { get; set; }

        public String LocalGurdianPhone { get; set; }


        public String DOB { get; set; }


        public String POB { get; set; }


        public String BCN { get; set; }


        public String IdProof_Number { get; set; }


        public String PassPort_Number { get; set; }


        public int CitizenCountryId { get; set; }

        public int IdProof_Id { get; set; }

        public int Gender_Id { get; set; }

        public int BloodGroup_Id { get; set; }


        public int AdmissionClass_Id { get; set; }
        public int SchoolBoard_Id { get; set; }

        public string ImagePath { get; set; }

        public string SignaturePath { get; set; }

        public string StudentfilePath { get; set; }

        public HttpPostedFileBase ImageUpload { get; set; }

        public IEnumerable<HttpPostedFileBase> StudentfileUpload { get; set; }

        public HttpPostedFileBase SignatureUpload { get; set; }


        public String Last_School_Name { get; set; }


        public String Last_School_Year { get; set; }

        public String Last_School_Class { get; set; }

        public String Last_School_Exam_Marks { get; set; }


        public String Last_School_Total_Marks { get; set; }


        public String Last_School_Marks_Percentage { get; set; }

        public String School_Transfer_Certifiate_Number { get; set; }


        public String Board_Certificate_Number { get; set; }

        public String Board_Exam_Marks { get; set; }


        public String Board_Total_Marks { get; set; }

        public String Marks_Percentage { get; set; }


        public int Disability { get; set; }

        public String Disability_Percentage { get; set; }


        public String Disability_Description { get; set; }

        public String Disability_Certificate_Number { get; set; }


        public int Special_Care { get; set; }


        public String Special_Care_Description { get; set; }


        public bool FormCheck { get; set; }


        public bool TermsAndConditions { get; set; }


        public string BirthCertificatePath { get; set; }


        public HttpPostedFileBase BirthCertificateUpload { get; set; }


        public string DisabilityCertificatePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase DisabilityCertificateUpload { get; set; }


        public string SchoolTransferCertificatePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase SchoolTransferCertificateUpload { get; set; }


        public string BoardExamResultPath { get; set; }

        public HttpPostedFileBase BoardExamResultUpload { get; set; }



        public string BoardExamCertificatePath { get; set; }


        public HttpPostedFileBase BoardExamCertificateUpload { get; set; }



        public string FinalExamResultPath { get; set; }


        public HttpPostedFileBase FinalExamResultUpload { get; set; }



        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string CityName { get; set; }
        public string IdProof_Name { get; set; }
        public string Board_Name { get; set; }


        public string Application_Status { get; set; }

        public string interview_note { get; set; }

        public string interview_marks { get; set; }

        public String BirthCertificate_Name { get; set; }
        public String DisabilityCertificat_Name { get; set; }
        public String SchoolTransferCertificate_Name { get; set; }
        public String FinalExamResult_Name { get; set; }
        public String BoardExamResultName { get; set; }
        public String BoardExamCertificate_Name { get; set; }






        public StudentAllList()
        {
            this.StdList = new List<SelectListItem>();

        }

        public List<SelectListItem> StdList { get; set; }
        public String Present_Status { get; set; }
        public int Period_Id { get; set; }
        public string Period_Date{get;set;}
        public String First_Period { get; set; }
        public String Second_Period { get; set; }
        public String Third_Period { get; set; }

        public String Fourth_Period { get; set; }
        public String Fifth_Period { get; set; }
        public String Sixth_Period { get; set; }
        public String Seventh_Period { get; set; }
        public String Eighth_Period { get; set; }
        public String Nineth_Period { get; set; }
        public String Tenth_Period { get; set; }
        public String Absent_Reasons { get; set; }
        public String Presence_Status { get; set; }
        public  int Att_Id { get; set; }
       // public int Roll_Number { }
       
    }


    public class ClassNoteModule
    {
        public int Note_Id { get; set; }

        public int School_Id { get; set; }

        public String School_Name { get; set; }

        public String School_Code { get; set; }

        public int Employee_Id { get; set; }

        public String Class_Namee { get; set; }

        public String Employee_Namee { get; set; }

        public String Note_Type_Namee { get; set; }

        public String Section_Namee { get; set; }

        public String Subject_Namee { get; set; }

        public String Class { get; set; }

        public ClassNoteModule()
        {

            this.Class_Name = new List<SelectListItem>();
            this.Teacher_Name = new List<SelectListItem>();
            this.Section_Name = new List<SelectListItem>();
            this.Subject_Name = new List<SelectListItem>();
            this.Note_Type_Name = new List<SelectListItem>();


        }
        public List<SelectListItem> Class_Name { get; set; }

        public List<SelectListItem> Teacher_Name { get; set; }

        public List<SelectListItem> Section_Name { get; set; }

        public List<SelectListItem> Subject_Name { get; set; }

        public List<SelectListItem> Note_Type_Name { get; set; }

        [Required(ErrorMessage = "Class  is required.")]
        public int Class_Id { get; set; }


        [Required(ErrorMessage = "Teacher is required.")]
        public int Teacher_Id { get; set; }

        [Required(ErrorMessage = "Section is required.")]
        public int Section_Id { get; set; }

        [Required(ErrorMessage = "Section is required.")]
        public int Subject_Id { get; set; }

        //[Required(ErrorMessage = "Note Type  Name is required.")]
        public int Note_Type_Id { get; set; }

        [Required(ErrorMessage = "Topic Name is required.")]
        public String Topic_Name { get; set; }

        [Required(ErrorMessage = "Notice Description is required.")]
        public String Note_Description { get; set; }


        [Required(ErrorMessage = "Notice Description is required.")]
        public String Note_Date { get; set; }


    }

    public class StudentMarks
    {

        [Required(ErrorMessage = "Exam Name is required.")]
        public int ExamType_Id { get; set; }
        public String Session_Year { get; set; }
        public String School_Code { get; set; }
        [Required(ErrorMessage = "Exam Year is required.")]
        public String Exam_Year { get; set; }

        public int Class_Id { get; set; }
        [Required(ErrorMessage = "Class Name is required.")]

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

        public int Subject_Id {  get; set; }
        public String Subject_Name { get; set; }
        public int Score { get; set; }
        public StudentMarks()
        {

            this.ExamType_Name = new List<SelectListItem>();
            this.Class_Name = new List<SelectListItem>();
            this.Section_Name = new List<SelectListItem>();
            this.Year_Name = new List<SelectListItem>();
            this.StudentList = new List<SelectListItem>();
            this.StudentMarksList = new List<SelectListItem>();
            this.Exam_Term_Name = new List<SelectListItem>();
        }



        public List<SelectListItem> ExamType_Name { get; set; }
        public List<SelectListItem> Class_Name { get; set; }
        public List<SelectListItem> Section_Name { get; set; }
        public List<SelectListItem> Year_Name { get; set; }
        public List<SelectListItem> StudentList { get; set; }
        public List<SelectListItem> StudentMarksList {get; set;}
        public List<SelectListItem> Exam_Term_Name { get; set; }

        public String Subject_Type { get; set; }
        public String Exam_Subject_Type { get; set; }

        public int priority_val { get; set; }
        [Required(ErrorMessage = "Full Marks is Require")]
        public int FullMarks { get; set; }

        [Required(ErrorMessage = "Pass Marks is require")]
        public int PassMarks { get; set; }

        [Required]
        [Display(Name = "Input practical Marks")]
        public int PracticalMarks { set; get; }

        public String Additional_Subject { get; set; }


    }
    public class Homework
    {
        public List<SelectListItem> Subject_Name { get; set; }
        public List<SelectListItem> Class_Name { get; set; }
        public List<SelectListItem> Section_Name { get; set; }

        public List<SelectListItem> Student_Name { get; set; }
        public List<Homework> NameRoll { get; set; }
        public List<Homework> Templist { get; set; }
        public List<Homework> Fileresponse { get; set; }
        public List<Homework> Filelist { get; set; }
        public String remarks;
        public String rem_desc;
        public int id { get; set; }
        public int stu_id { get; set; }
        public int sub_id { get; set; }
        [Required(ErrorMessage = "Class is required.")]
        public int class_id { get; set; }

        [Required(ErrorMessage = "Section is required.")]
        public int sec_id { get; set; }
        public string topic { get; set; }
        public int Teacher_ID { get; set; }
        public string Subm_Date = "N/A";
        public string Home_Desc { get; set; }
        public string File_Name { get; set; }
        public string F_Name { get; set; }
        public string File_Path { get; set; }
        public int OverDue { get; set; }
        public string Name { get; set; }
        public int RollNo { get; set; }
        public string Teacher_Name { get; set; }
        public string date_assigned { get; set; }
        public string due_date { get; set; }
        public String ClassName { get; set; }
        public String SectionName { get; set; }
        public int ID;
        public int FID { get; set; }
        public int HomeID { get; set; }
        public string sub_date { get; set; }
        public string subject_name { get; set; }
        public string status = "N/A";
        public Homework()
        {
            this.Filelist = new List<Homework>();
            this.Templist = new List<Homework>();
            this.Subject_Name = new List<SelectListItem>();
            this.Section_Name = new List<SelectListItem>();
            this.Class_Name = new List<SelectListItem>();
            this.Student_Name = new List<SelectListItem>();
        }
        public Homework(int stu_id, int class_id, int sec_id, string due_date, string date_assigned)
        {
            this.stu_id = stu_id;
            this.class_id = class_id;
            this.sec_id = sec_id;
            this.due_date = due_date;
            this.date_assigned = date_assigned;
        }
        public Homework(int ID, String ClassName, String SectionName, String File_Path, String File_Name)
        {
            this.ID = ID;
            this.SectionName = SectionName;
            this.ClassName = ClassName;
            this.File_Path = File_Path;
            this.File_Name = File_Name;
        }
        public Homework(int Class_ID, int Section_ID, int Subject_ID, String Topic, String Description, String Assigned_Date, String Due_Date, String Status)
        {
            this.sub_id = Subject_ID;
            this.topic = Topic;
            this.Home_Desc = Description;

            this.status = Status;
            this.class_id = Class_ID;
            this.sec_id = Section_ID;
            this.due_date = Due_Date;
            this.date_assigned = Assigned_Date;
        }



    }


    public class StudentAttendance
    {

        [Required(ErrorMessage = "Exam Name is required.")]
        public int ExamType_Id { get; set; }
        public int Employee_Id { get; set; }
        public String School_Code { get; set; }
        [Required(ErrorMessage = "Exam Year is required.")]
        public String Exam_Year { get; set; }
        public String Session_Year { get; set; }
        public int Class_Id { get; set; }
        [Required(ErrorMessage = "Class Name is required.")]

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
        public StudentAttendance()
        {

            this.ExamType_Name = new List<SelectListItem>();
            this.Class_Name = new List<SelectListItem>();
            this.Section_Name = new List<SelectListItem>();
            this.Year_Name = new List<SelectListItem>();
            this.StudentList = new List<SelectListItem>();
            this.StudentMarksList = new List<SelectListItem>();
            this.PeriodList = new List<SelectListItem>();
            this.SectionList = new List<SelectListItem>();

        }



        public List<SelectListItem> ExamType_Name { get; set; }
        public List<SelectListItem> Class_Name { get; set; }
        public List<SelectListItem> Section_Name { get; set; }
        public List<SelectListItem> Year_Name { get; set; }
        public List<SelectListItem> StudentList { get; set; }
        public List<SelectListItem> StudentMarksList { get; set; }
        public List<SelectListItem> PeriodList { get; set; }
        public List<SelectListItem> SectionList { get; set; }

        public String Subject_Type { get; set; }
        public String Exam_Subject_Type { get; set; }

        public int priority_val { get; set; }
        [Required(ErrorMessage = "Full Marks is Require")]
        public int FullMarks { get; set; }

        [Required(ErrorMessage = "Pass Marks is require")]
        public int PassMarks { get; set; }

        [Required]
        [Display(Name = "Input practical Marks")]
        public int PracticalMarks { set; get; }

        public String Additional_Subject { get; set; }
        public String Absent_Reasons { get; set; }

        public bool Present_Check { get; set; }


    }


}
