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
    public class MasterData
    {

    }
    public class GroupMaster
    {


        public GroupMaster()
        {
            this.School_Name = new List<SelectListItem>();

        }

        public List<SelectListItem> School_Name { get; set; }


        [Required(ErrorMessage = "School Name is required.")]
        public int School_Id { get; set; }


        [Required(ErrorMessage = "Group Name is required.")]

        public String GroupName { get; set; }

       
       


    }
    public class EmpTypeMaster
    {
        public int Type_Id { get; set; }

        [Required(ErrorMessage = "Emp Type Name is required.")]

        public String Emp_Type_Name { get; set; }

        public EmpTypeMaster()
        {

            this.School_Name = new List<SelectListItem>();
        
        }

        public List<SelectListItem> School_Name { get; set; }

        [Required(ErrorMessage = "School Country is required.")]
        public int School_Id { get; set; }
    }

    public class SectionMaster
    {
        public int Section_Id { get; set; }

        [Required(ErrorMessage = "Section Name is required.")]

        public String Section_Name { get; set; }

        [Required(ErrorMessage = "Section Room Number is required.")]

        public String Section_Room_Number{ get; set; }

        public SectionMaster()
        {

            this.School_Name = new List<SelectListItem>();
            this.Class_Name = new List<SelectListItem>();

        }

        public List<SelectListItem> School_Name { get; set; }

        public List<SelectListItem> Class_Name { get; set; }

        [Required(ErrorMessage = "School  is required.")]
        public int School_Id { get; set; }
        [Required(ErrorMessage = "Class  is required.")]
        public int Class_Id { get; set; }


    }

    public class ClassMaster
    {
        public int Class_Id { get; set; }

        [Required(ErrorMessage = "Class Name is required.")]

        public String Class_Name { get; set; }

        public ClassMaster()
        {

            this.School_Name = new List<SelectListItem>();

        }

        public List<SelectListItem> School_Name { get; set; }

        [Required(ErrorMessage = "School  is required.")]
        public int School_Id { get; set; }

    }
}