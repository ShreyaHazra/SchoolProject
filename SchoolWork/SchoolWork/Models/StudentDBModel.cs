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
    public class StudentDBModel
    {

     
    }

    public class StudentLogin
    {

        [Display(Prompt = "Enter Your First Name")]
        [Required(ErrorMessage = "UserName is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]

        public string Password { get; set; }

        public string first_name { get; set; }

        public int Student_Id { get; set; }

        public string RememberMe { get; set; }
        public int User_Type { get; set; }

        public StudentLogin()
        {

            this.School_Name = new List<SelectListItem>();

        }
        public List<SelectListItem> School_Name { get; set; }

        [Required(ErrorMessage = "School  is required.")]
        public String School_Code { get; set; }


    }


    public class StudentRegistration
    {

        public int Student_Id { get; set; }


        public StudentRegistration()
        {

            this.School_Name = new List<SelectListItem>();

        }
        public List<SelectListItem> School_Name { get; set; }

        [Required(ErrorMessage = "School  is required.")]
        public String School_Code { get; set; }

        public int School_Id { get; set; }

        [Required(ErrorMessage = "Application Number  is required.")]

        public String Application_Id { get; set; }


        public int New_Id { get; set; }

        public String FullName { get; set; }


        public String FatherName { get; set; }

        public String FatherContactNumber { get; set; }

        public String FatherEmail { get; set; }



        public String MotherName { get; set; }

        public String MotherContactNumber { get; set; }

        public String MotherEmail { get; set; }

        public String HomeContactNumber { get; set; }

        public String DOB { get; set; }

        [Required(ErrorMessage = "Parent Confirm Email is required.")]
        public String Student_Email { get; set; }

        [Required(ErrorMessage = "Parent Confirm Email is required.")]
        [Compare("Student_Email", ErrorMessage = "ParentEmail and Confirmation Email must match.")]

        public String Student_ConEmail { get; set; }

        [Required(ErrorMessage = "Password is required.")]

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8}$", ErrorMessage = "Password must meet requirements[Must be 8 Digit Long & contains 1 Capital Letter, 1 Small Letter,1 Special Characrter]")]

        public String Password { get; set; }

        [Required(ErrorMessage = "Parent Confirm Password is required.")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password must match.")]

        public String ConPassword { get; set; }



    }

}