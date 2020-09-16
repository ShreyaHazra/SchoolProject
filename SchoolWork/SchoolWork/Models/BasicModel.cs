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
    public class BasicModel
    {
    }

    public class ClassDetailsMaster
    {
        public int Class_Id { get; set; }
        //public String School_Code { get; set; }
        public String Class_Name { get; set; }
        

    }

    //public class UserTypeMaster
    //{
    //    public UserTypeMaster()
    //    {

    //        this.UserList = new List<SelectListItem>();
    //        this.CustRegions = new List<SelectListItem>();

    //    }
    //    public List<SelectListItem> UserList { get; set; }

    //    public List<SelectListItem> CustRegions { get; set; }



    //}
}