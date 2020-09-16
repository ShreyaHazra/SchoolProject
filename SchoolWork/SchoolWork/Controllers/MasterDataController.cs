using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using SchoolWork.Models;

namespace SchoolWork.Controllers
{
    public class MasterDataController : Controller
    {
        // GET: MasterData
        public ActionResult GroupMaster()
        {
            GroupMaster model = new GroupMaster();
            model.School_Name = PopulateDropDown("SELECT School_Id, School_Name FROM School_Details_Master", "School_Name", "School_Id");


            return View(model);
        }

        public ActionResult EmpTypeMaster()
        {
            EmpTypeMaster model = new EmpTypeMaster();
            model.School_Name = PopulateDropDown("SELECT School_Id, School_Name FROM School_Details_Master", "School_Name", "School_Id");
            return View(model);
        }

        public ActionResult SectionMaster()
        {
            SectionMaster model = new SectionMaster();
            model.School_Name = PopulateDropDown("SELECT School_Id, School_Name FROM School_Details_Master", "School_Name", "School_Id");
            model.Class_Name = PopulateDropDown("SELECT Class_Id, Class_Name FROM Class_Master", "Class_Name", "Class_Id");
            return View(model);
        }

        private static List<SelectListItem> PopulateDropDown(string query, string textColumn, string valueColumn)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            string constr = ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader sdr = cmd.ExecuteReader())
                    {
                        while (sdr.Read())
                        {
                            items.Add(new SelectListItem
                            {
                                Text = sdr[textColumn].ToString(),
                                Value = sdr[valueColumn].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }

            return items;
        }


        public ActionResult ClassMaster()
        {
            ClassMaster model = new ClassMaster();
            model.School_Name = PopulateDropDown("SELECT School_Id, School_Name FROM School_Details_Master", "School_Name", "School_Id");
            return View(model);
        }

    }
}