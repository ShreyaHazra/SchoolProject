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
    public class StudentAdmission
    {

        public int Student_Id { get; set; }

   

        public int School_Id { get; set; }


        public String School_Code { get; set; }

        public String Query_step { get; set; }

        public String StepOne_status { get; set; }


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

        public  String LocalGurdianValue { get; set; }

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

        public String Assign_Roll_Number { get; set; }

        public String Assign_Section { get; set; }

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
        public string Class_Name { get; set; }

        public string Application_Status { get; set; }

        public string interview_note { get; set; }

        public string interview_marks { get; set; }

        public String BirthCertificate_Name { get; set; }
        public String DisabilityCertificat_Name { get; set; }
        public String SchoolTransferCertificate_Name { get; set; }
        public String FinalExamResult_Name { get; set; }
        public String BoardExamResultName { get; set; }
        public String BoardExamCertificate_Name { get; set; }


        [Required(ErrorMessage = "Section Name is required.")]
        public int Section_Id { get; set; }
        public StudentAdmission()
        {
            this.Section_Name = new List<SelectListItem>();

        }
        public List<SelectListItem> Section_Name { get; set; }

        public IEnumerable<StudentAdmission> StudentDetails { get; set; }

    }



    public class StudentFormFillup
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

        public StudentFormFillup()
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

        [Required(ErrorMessage = "Please Select Disablity Test")]
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


        [DisplayName("Last Exam  Certificate Upload")]
        public string BoardExamCertificatePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase BoardExamCertificateUpload { get; set; }


        [DisplayName("Last Exam  Result Upload")]
        public string FinalExamResultPath { get; set; }

        [NotMapped]
        public HttpPostedFileBase FinalExamResultUpload { get; set; }

        public IEnumerable<StudentAdmission> StudentDetails { get; set; }

        public String BirthCertificate_Name { get; set; }
        public String DisabilityCertificat_Name { get; set; }
        public String SchoolTransferCertificate_Name { get; set; }
        public String FinalExamResult_Name { get; set; }
        public String BoardExamResultName { get; set; }
        public String BoardExamCertificate_Name { get; set; }
  
    }


}