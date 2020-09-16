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
    public class ParentModel
    {

    }


    public class ParentRegistration
    {

        public int parentid { get; set; }


        public ParentRegistration()
        {

            this.School_Name = new List<SelectListItem>();

        }
        public List<SelectListItem> School_Name { get; set; }

        [Required(ErrorMessage = "School  is required.")]
        public String School_Code { get; set; }

        // public int School_Id { get; set; }

        [Required(ErrorMessage = "Parent Name is required.")]

        public String ParentName { get; set; }

        [Required(ErrorMessage = "Parent Contact is required.")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Wrong mobile")]

        public String ParentContact { get; set; }

        [Required(ErrorMessage = "Parent Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]

        public String ParentEmail { get; set; }

        [Required(ErrorMessage = "Parent Confirm Email is required.")]
        [Compare("ParentEmail", ErrorMessage = "ParentEmail and Confirmation Email must match.")]

        public String ParentConEmail { get; set; }

        [Required(ErrorMessage = "Password is required.")]

        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8}$", ErrorMessage = "Password must meet requirements[Must be 8 Digit Long & contains 1 Capital Letter, 1 Small Letter,1 Special Characrter]")]

        public String ParentPassword { get; set; }


        [Required(ErrorMessage = "Parent Confirm Password is required.")]
        [Compare("ParentPassword", ErrorMessage = "Password and Confirm Password must match.")]

        public String ParentConPassword { get; set; }

        public int New_Id { get; set; }

        public String SchoolEmail { get; set; }

        public String SchoolPassword { get; set; }

        public String SchoolName { get; set; }

    }



    public class ParentLogin
    {

        [Display(Prompt = "Enter Your First Name")]
        [Required(ErrorMessage = "UserName is required.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]

        public string Password { get; set; }

        public string ParentName { get; set; }

        public int ParentID { get; set; }

        public string RememberMe { get; set; }
        public int User_Type { get; set; }

        public ParentLogin()
        {

            this.School_Name = new List<SelectListItem>();

        }
        public List<SelectListItem> School_Name { get; set; }

        [Required(ErrorMessage = "School  is required.")]
        public String School_Code { get; set; }


    }

    public class NoticeDetails
    {
        public int Notice_Id { get; set; }
        public String School_Code { get; set; }
        public String School_Name { get; set; }
        public String Notice_Title { get; set; }
        public String Notice_Description { get; set; }
        public String User_Id { get; set; }
        public String Notice_Published_On { get; set; }
        public String Notice_Status { get; set; }

        //public NoticeDetails()
        //{

        //    this.UserList = new List<SelectListItem>();
        //    this.CustRegions = new List<SelectListItem>();

        //}
        //public List<SelectListItem> UserList { get; set; }

        //public List<SelectListItem> CustRegions { get; set; }



    }

}