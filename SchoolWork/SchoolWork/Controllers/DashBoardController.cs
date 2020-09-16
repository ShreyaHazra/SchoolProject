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
    public class DashBoardController : Controller
    {
        // GET: DashBoard
        public ActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public ActionResult AdminDashBoard(int id)
        {
            DataBaseAcessLayer.BasicDetailsDB dbhandle = new DataBaseAcessLayer.BasicDetailsDB();
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                return View(dbhandle.GetAdminWorkRole(id));
            }
        }

        public ActionResult ParentDashBoard(int id)
        {
            if (Session["ParentID"] == null)
            {
                return Redirect("~/ParentDetails/ParentLogin");
            }
            else
            {
                DataBaseAcessLayer.BasicDetailsDB dbhandle = new DataBaseAcessLayer.BasicDetailsDB();
                return View(dbhandle.GetParentWorkRole(id));

            }
        }


        public ActionResult StudentDashBoard(int id)
        {

            DataBaseAcessLayer.BasicDetailsDB dbhandle = new DataBaseAcessLayer.BasicDetailsDB();
            return View(dbhandle.GetStudentWorkRole(id));

        }


        public ActionResult EmployeeDashBoard(int id)
        {
            //return View();

            //ViewBag.workgroup_id = id;
            if (Session["Employee_Id"] == null)
            {
                return Redirect("~/Employee/EmployeeLogin");
            }
            else
            {
                ViewBag.PreviousUrl = System.Web.HttpContext.Current.Request.UrlReferrer;
                DataBaseAcessLayer.BasicDetailsDB dbhandle = new DataBaseAcessLayer.BasicDetailsDB();
                return View(dbhandle.GetEmployeeWorkRole(id));
            }
        }

        public ActionResult AdminHeaderBoard()
        {
            DataBaseAcessLayer.BasicDetailsDB dbhandle = new DataBaseAcessLayer.BasicDetailsDB();
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                return View(dbhandle.GetAdminWorkRoleHeader());
            }
            //return View();
        }

        public ActionResult ParentHeaderBoard()
        {
            if (Session["ParentID"] == null)
            {
                return Redirect("~/ParentDetails/ParentLogin");
            }
            else
            {
                DataBaseAcessLayer.BasicDetailsDB dbhandle = new DataBaseAcessLayer.BasicDetailsDB();
                return View(dbhandle.GetParentWorkRoleHeader());
            }
            //return View();
        }

        public ActionResult StudentHeaderBoard()
        {
            DataBaseAcessLayer.BasicDetailsDB dbhandle = new DataBaseAcessLayer.BasicDetailsDB();
            return View(dbhandle.GetStudentWorkRoleHeader());

            //return View();
        }

        public ActionResult EmployeeHeaderBoard()
        {
            if (Session["Employee_Id"] == null)
            {
                return Redirect("~/Employee/EmployeeLogin");
            }
            else
            {
                DataBaseAcessLayer.BasicDetailsDB dbhandle = new DataBaseAcessLayer.BasicDetailsDB();
                return View(dbhandle.GetEmployeeWorkRoleHeader());

                //return View();
            }
        }


    }
}