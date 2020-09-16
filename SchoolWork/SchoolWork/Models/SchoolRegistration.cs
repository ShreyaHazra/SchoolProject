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
    public class SchoolRegistration
    {
        public int SchoolId { get; set; }

        [Required(ErrorMessage = "School Name is required.")]

        public String SchoolName { get; set; }

        [Required(ErrorMessage = "School Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]

        public String SchoolEmail { get; set; }

        [Required(ErrorMessage = "School Phone Number is required.")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Please Input a Valid  Phone Number")]

        public String SchoolPhone { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8}$", ErrorMessage = "Password must meet requirements[Must be 8 Digit Long & contains 1 Capital Letter, 1 Small Letter,1 Special Characrter]")]

        public String SchoolPassword { get; set; }

        [Required(ErrorMessage = "School Code is required.")]
        

        public String SchoolCode { get; set; }

        [Required(ErrorMessage = "School Contact Person Name is required.")]

        public String SchoolContactPerson { get; set; }

        [Required(ErrorMessage = "Contact Person  Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]

        public String SchoolContactPersonEmail { get; set; }

        [Required(ErrorMessage = "Contact Person Phone Number is required.")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Please Input a Valid  Phone Number")]

        public String SchoolContactPersonPhone { get; set; }

        [Required(ErrorMessage = "School Address is required.")]

        public String SchoolAddress1 { get; set; }

        public String SchoolAddress2 { get; set; }

        [Required(ErrorMessage = "School Pincode is required.")]
        [RegularExpression(@"^(\d{6})$", ErrorMessage = "Please Input a Valid  Pincode")]

        public String SchoolZip { get; set; }

        public SchoolRegistration()
        {
            this.Countries = new List<SelectListItem>();
            this.States = new List<SelectListItem>();
            this.Cities = new List<SelectListItem>();
            this.Board_Name = new List<SelectListItem>();
        }

      

        public List<SelectListItem> Countries { get; set; }

      

        public List<SelectListItem> States { get; set; }

       
        public List<SelectListItem> Cities { get; set; }

        public List<SelectListItem> Board_Name { get; set; }

        [Required(ErrorMessage = "School Country is required.")]
        public int CountryId { get; set; }

        [Required(ErrorMessage = "School State is required.")]

        public int StateId { get; set; }

        [Required(ErrorMessage = "School City is required.")]
        public int CityId { get; set; }

        [Required(ErrorMessage = "School Board is required.")]
        public int Board_Id { get; set; }


    }

    public class SchoolLogin
    {
        public String SchoolUserName { get; set; }

        public String SchoolPassword { get; set; }
    }


   // public class SchoolRegistrationdropdwn
   // {




   // }

}