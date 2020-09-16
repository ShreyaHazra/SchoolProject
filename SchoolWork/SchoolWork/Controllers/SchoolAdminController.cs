using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using SchoolWork.Models;
using System.Dynamic;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using System.Net.Mail;
using CrystalDecisions.Shared;
using CrystalDecisions.ReportSource;
using CrystalDecisions.CrystalReports.Engine;


namespace SchoolWork.Controllers
{
    public class SchoolAdminController : Controller
    {
        //DataBaseAcessLayer.StudentAdmissionDB dblayer2 = new DataBaseAcessLayer.StudentAdmissionDB();
        DataBaseAcessLayer.SchoolAdminDB dblayer3 = new DataBaseAcessLayer.SchoolAdminDB();
        // GET: SchoolAdmin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SchoolAdminLogin()
        {

            return View();


        }


        [HttpPost]
        public ActionResult SchoolAdminLogin(SchoolAdminLogin fc)
        {
            try
            {
                String con = ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString;
                SqlConnection sqlcon = new SqlConnection(con);
                string sqlquery = "Select School_Id,School_Group_Code,School_Code,School_Name,School_Email, School_Password FROM [dbo].[School_Details_Master] WHERE  School_Email=@Email and School_Password=@Password";
                sqlcon.Open();
                SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon);
                sqlcom.Parameters.AddWithValue("@Email", fc.UserName);
                sqlcom.Parameters.AddWithValue("@Password", fc.Password);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlcom;
                DataSet ds = new DataSet();
                da.Fill(ds);

                SqlDataReader sdr = sqlcom.ExecuteReader();
                if (sdr.Read())
                {
                    Session["School_Name"] = ds.Tables[0].Rows[0]["School_Name"].ToString();
                    Session["School_Group_Code"] = ds.Tables[0].Rows[0]["School_Group_Code"].ToString();
                    Session["School_Code"] = ds.Tables[0].Rows[0]["School_Code"].ToString();
                    Session["School_Id"] = ds.Tables[0].Rows[0]["School_Id"].ToString();
                    Session["School_Email"] = ds.Tables[0].Rows[0]["School_Email"].ToString();
                    Session["School_Password"] = ds.Tables[0].Rows[0]["School_Password"].ToString();
                   // Session.Timeout = 1;

                    return this.RedirectToAction("AdminHeaderBoard", "Dashboard");
                }
                else
                {
                    ViewData["message"] = "Wrong Credentials!";
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

            }

            return View();
        }

        [HttpPost]
        public JsonResult CheckUsernameAvailability(string ClassId, string SubjectName, string School_Code)
        {
           // System.Threading.Thread.Sleep(200);
            ParentRegistration model = new ParentRegistration();
            String con = ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            string sqlquery = "Select Subject_Name FROM [dbo].[School_Subject_Master] WHERE Class_Id = '" + ClassId + "' AND Subject_Name ='" + SubjectName + "' AND School_Code ='" +Session["School_Code"]+ "'  ";

            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon);
             SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlcom;
            DataSet ds = new DataSet();
            da.Fill(ds);
            SqlDataReader sdr = sqlcom.ExecuteReader();
            if (sdr.Read())
            {
                return Json(1);
            }
            else
            {
                return Json(0);
            }


        }


        public ActionResult StudentGroupMaster()
        {

            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {

                return View();
            }


        }


        [HttpPost]
        public ActionResult StudentGroupMaster(FormCollection fc)
        {
            SchoolAdminModel model = new SchoolAdminModel();
         try { 
            if (ModelState.IsValid)
            {
                StudentGroupMaster stdgrp = new StudentGroupMaster();
                stdgrp.School_Id = Convert.ToInt32(fc["School_Id"]);
                stdgrp.School_Code = fc["School_Code"];
                stdgrp.School_Name = fc["School_Name"];
                stdgrp.Group_Name = fc["Group_Name"];
                dblayer3.Add_Student_Group(stdgrp);

                TempData["msg"] = "Student Group Register Successful!";

                return this.RedirectToAction("AdminDashBoard", "Dashboard");
            }
           }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

            }

            return View(model);
        }

        public ActionResult AddSection()
        {

            SchoolSectionMaster model = new SchoolSectionMaster();
            model.Class_Name = PopulateDropDown("SELECT Class_Id, Class_Name FROM Class_Master WHERE School_Code='" + Session["School_Code"] + "'", "Class_Name", "Class_Id");
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                return View(model);
            }

        }

        [HttpPost]
        public ActionResult AddSection(FormCollection fc)
        {
            SchoolAdminModel model = new SchoolAdminModel();
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {

                try
                {
                    //if (ModelState.IsValid)
                    //{
                        SchoolSectionMaster schsec = new SchoolSectionMaster();
                        schsec.School_Id = Convert.ToInt32(fc["School_Id"]);
                        schsec.School_Code = fc["School_Code"];
                        schsec.School_Name = fc["School_Name"];
                        schsec.Class_Id = Convert.ToInt32(fc["Class_Id"]);
                        schsec.Section_Name = fc["Section_Name"];
                        schsec.Section_Room_Number = Convert.ToInt32(fc["Section_Room_Number"]);

                        dblayer3.Add_School_Section(schsec);

                        TempData["msg"] = "School Section Created Successfully!";

                        return this.RedirectToAction("AdminHeaderBoard", "Dashboard");
                   // }
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;

                }
                return View(model);
            }
        }

        public ActionResult AddSubject()
        {
            SchoolSubjectMaster model = new SchoolSubjectMaster();
            model.Class_Name = PopulateDropDown("SELECT Class_Id, Class_Name FROM Class_Master", "Class_Name", "Class_Id");
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {

                return View(model);

            }
        }

        [HttpPost]
        public ActionResult AddSubject(FormCollection fc)
        {
            SchoolSubjectMaster model = new SchoolSubjectMaster();
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {

                try
                {
                    if (ModelState.IsValid)
                    {
                        SchoolSubjectMaster schsub = new SchoolSubjectMaster();
                        schsub.School_Id = Convert.ToInt32(fc["School_Id"]);
                        schsub.School_Code = fc["School_Code"];
                        schsub.School_Name = fc["School_Name"];
                        schsub.Class_Id = Convert.ToInt32(fc["Class_Id"]);
                        schsub.subject_type = fc["subject_type"];
                        if (schsub.subject_type == "A")
                        {
                            schsub.Additional_Subject = "Yes";
                        }
                        schsub.Subject_Name = fc["Subject_Name"];
                        if (!String.IsNullOrEmpty(fc["priority_val"]))
                        {
                            schsub.priority_val = Convert.ToInt32(fc["priority_val"]);
                        }
                        schsub.exam_sub_type = fc["exam_sub_type"];
                        schsub.Subject_Code = fc["Subject_Code"];
                        schsub.FullMarks = Convert.ToInt32(fc["FullMarks"]);
                        if (!String.IsNullOrEmpty(fc["PracticalMarks"]))
                        {
                            schsub.PracticalMarks = Convert.ToInt32(fc["PracticalMarks"]);
                        }
                            schsub.PassMarks = Convert.ToInt32(fc["PassMarks"]);

                        dblayer3.Add_School_Subject(schsub);

                        TempData["msg"] = "School Subject Added Successfully!";

                        return this.RedirectToAction("AdminHeaderBoard", "Dashboard");
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;

                }

                return View(model);
            }
        }


        //[HttpGet]
        //public ActionResult showallparents()
        //{
           
        //    DataBaseAcessLayer.ParentDetailsDB dbhandle = new DataBaseAcessLayer.ParentDetailsDB();
        //    return View(dbhandle.GetParent());
        //}


       


        public ActionResult SchoolNoticeAdd()
        {

            SchoolNoticeAdd model = new SchoolNoticeAdd();

            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                model.User_Type_Name = PopulateDropDown("SELECT  User_Type_Id ,User_Type_Name FROM School_User_Type_Master", "User_Type_Name", "User_Type_Id");
                return View(model);

            }

        }
        [HttpPost]
        public ActionResult SchoolNoticeAdd(FormCollection fc)
        {
            SchoolAdminModel model = new SchoolAdminModel();
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {

                try
                {
                    if (ModelState.IsValid)
                    {
                        SchoolNoticeAdd schnot = new SchoolNoticeAdd();
                        schnot.School_Id = Convert.ToInt32(fc["School_Id"]);
                        schnot.School_Code = fc["School_Code"];
                        schnot.School_Name = fc["School_Name"];
                        schnot.Notice_Title = fc["Notice_Title"];
                        schnot.Notice_Description = fc["Notice_Description"];
                        schnot.User_Type_Id = Convert.ToInt32(fc["User_Type_Id"]);
                        schnot.Notice_Published_On = fc["Notice_Published_On"];

                        dblayer3.Add_School_Notice(schnot);

                        TempData["msg"] = "Notice   Published Successfully!";

                        return this.RedirectToAction("ShowallAdminNotice", "SchoolAdmin");
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;

                }

                return View(model);

            }
        }


        [HttpGet]
        public ActionResult ShowallAdminNotice()
        {

            DataBaseAcessLayer.SchoolAdminDB dbhandle = new DataBaseAcessLayer.SchoolAdminDB();
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                return View(dbhandle.GetAdminNotice());
                //return View(dbhandle.GetAdminNotice());
            }
         }

        public ActionResult ShowAdminNoticeDetails(int id)
        {

            DataBaseAcessLayer.SchoolAdminDB dbhandle = new DataBaseAcessLayer.SchoolAdminDB();
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                return View(dbhandle.GetAdminNotice().Find(smodel => smodel.Notice_Id == id));
            }
        }




        public ActionResult UpdateNoticeDetails(int id)
        {

            DataBaseAcessLayer.SchoolAdminDB dbhandle = new DataBaseAcessLayer.SchoolAdminDB();
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                return View(dbhandle.GetAdminNotice().Find(smodel => smodel.Notice_Id == id));
            }
        }

        [HttpPost]
        public ActionResult UpdateNoticeDetails(int id, AdminNoticeDetails smodel, FormCollection fc)
        {
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        DataBaseAcessLayer.SchoolAdminDB dbhandle = new DataBaseAcessLayer.SchoolAdminDB();
                        smodel.Notice_Id = Convert.ToInt32(fc["Notice_Id"]);
                        smodel.Notice_Published_On = fc["Notice_Published_On"];
                        smodel.Notice_Description = fc["Notice_Description"];
                        smodel.Notice_Title = fc["Notice_Title"];
                        smodel.School_Code = fc["School_Code"];
                        dbhandle.UpdateNoticeDetails(smodel);
                        TempData["msg"] = "Notice  Details Updated Successfully!";
                        return this.RedirectToAction("ShowallAdminNotice", "SchoolAdmin");
                    }

                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;

                }

                return View(smodel);
            }

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

        [HttpGet]
        public ActionResult ShowallParents()
        {
            DataBaseAcessLayer.SchoolAdminDB dbhandle = new DataBaseAcessLayer.SchoolAdminDB();
            //DataBaseAcessLayer.ParentDetailsDB dbhandle = new DataBaseAcessLayer.ParentDetailsDB();

            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                return View(dbhandle.GetParentDetails());
            }
        }

        public ActionResult UpdateParentDetails(int id)
        {
            DataBaseAcessLayer.SchoolAdminDB dbhandle = new DataBaseAcessLayer.SchoolAdminDB();

            //DataBaseAcessLayer.ParentDetailsDB dbhandle = new DataBaseAcessLayer.ParentDetailsDB();
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                return View(dbhandle.GetParentDetails().Find(smodel => smodel.ParentID == id));
            }
        }

        [HttpPost]
        public ActionResult UpdateParentDetails(int id, ParentDetails smodel)
        {
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    DataBaseAcessLayer.ParentDetailsDB dbhandle = new DataBaseAcessLayer.ParentDetailsDB();
                    dbhandle.UpdateDetails(smodel);
                    TempData["msg"] = "Parent  Info Updated Successfully!";
                    return this.RedirectToAction("ShowallParents", "SchoolAdmin");
                }
                return View(smodel);
            }
        }





        public ActionResult SchoolEmpTypeMaster()
        {
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]

        public ActionResult SchoolEmpTypeMaster(FormCollection fc)
        {
            SchoolAdminModel model = new SchoolAdminModel();
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        SchoolEmpTypeMaster schemptype = new SchoolEmpTypeMaster();
                        schemptype.School_Id = Convert.ToInt32(fc["School_Id"]);
                        schemptype.School_Code = fc["School_Code"];
                        schemptype.School_Name = fc["School_Name"];
                        schemptype.EmpType_Name = fc["EmpType_Name"];
                        dblayer3.Add_School_EmpType(schemptype);

                        TempData["msg"] = "School Employee Designation Added Successfully!";

                        return this.RedirectToAction("ShowallEmpDesignation", "SchoolAdmin");

                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;

                }
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult ShowallEmpDesignation()
        {

            DataBaseAcessLayer.SchoolAdminDB dbhandle = new DataBaseAcessLayer.SchoolAdminDB();
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                return View(dbhandle.GetEmpDesignationDetails());
            }
        }

      
        public ActionResult SchoolEmployeeMaster(String School_Code)
        {

            SchoolEmployeeMaster model = new SchoolEmployeeMaster();
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                model.EmpType_Name = PopulateDropDown("SELECT  EmpType_Name ,Type_Id FROM School_EmpType_Master WHERE School_Code= '" + Session["School_Code"] + "' ", "EmpType_Name", "Type_Id");
                return View(model);
            }

        }
        [HttpPost]
        public ActionResult SchoolEmployeeMaster(FormCollection fc)
        {
            SchoolAdminModel model = new SchoolAdminModel();

            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {

                try
                {
                    if (ModelState.IsValid)
                    {
                        SchoolEmployeeMaster schemp = new SchoolEmployeeMaster();
                        schemp.School_Id = Convert.ToInt32(fc["School_Id"]);
                        schemp.School_Code = fc["School_Code"];
                        schemp.School_Name = fc["School_Name"];
                        schemp.EmpType_Id = Convert.ToInt32(fc["EmpType_Id"]);
                        schemp.Employee_Name = fc["Employee_Name"];
                        schemp.Employee_Code = fc["Employee_Code"];
                        schemp.Employee_Email = fc["Employee_Email"];
                        schemp.Employee_Password = fc["Employee_Password"];
                        schemp.Employee_Mobile_Number = fc["Employee_Mobile_Number"];
                        schemp.Employee_Alt_Number = fc["Employee_Alt_Number"];
                        schemp.Employee_DOB = fc["Employee_DOB"];

                        schemp.School_Email = fc["School_Email"];
                        schemp.School_Password = fc["School_Password"];


                        dblayer3.Add_School_Employee(schemp);


                        /*  MailMessage mail = new MailMessage("pro@gmail.com", schemp.Employee_Email, "Your User id is created ", "Thanks You.");
                          //mail.From = new MailAddress("denovo@gmail.com", "nameEmail aa");
                          //   mail.IsBodyHtml = true; // necessary if you're using html email
                          mail.From = new MailAddress("pro@gmail.com", "nameEmail aa");
                          NetworkCredential credential = new NetworkCredential(schemp.School_Email, schemp.School_Password);
                          SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                          smtp.EnableSsl = true;
                          smtp.UseDefaultCredentials = false;
                          smtp.Credentials = credential;
                          smtp.Send(mail);*/

                        MailMessage mail = new MailMessage("pro@gmail.com", schemp.Employee_Email, "mailSubject2", "mailBody2");
                        //mail.From = new MailAddress("denovo@gmail.com", "nameEmail aa");
                        //mail.IsBodyHtml = true; // necessary if you're using html email
                        mail.From = new MailAddress("pro@gmail.com", "Registration Successfull");
                        mail.Subject = "Registration Successfull";
                        //NetworkCredential credential = new NetworkCredential(schemp.School_Email, schemp.School_Password);


                        NetworkCredential credential = new NetworkCredential("schooldays2050@gmail.com", "Marine@1");
                        SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                        smtp.EnableSsl = true;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = credential;
                        smtp.Send(mail);








                        TempData["msg"] = "School Employee  Added Successfully!";

                        return this.RedirectToAction("ShowallEmp", "SchoolAdmin");
                    }
                }

                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;

                }
                return View(model);

            }
        }

        [HttpGet]
        public ActionResult ShowallEmp()
        {

            DataBaseAcessLayer.SchoolAdminDB dbhandle = new DataBaseAcessLayer.SchoolAdminDB();
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                return View(dbhandle.GetEmpDetails());
            }
        }

        public ActionResult UpdateEmployeeDetails(int id)
        {

            DataBaseAcessLayer.SchoolAdminDB dbhandle = new DataBaseAcessLayer.SchoolAdminDB();
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                return View(dbhandle.GetEmpDetails().Find(smodel => smodel.Employee_Id == id));
            }
        }

        [HttpPost]
        public ActionResult UpdateEmployeeDetails(int id, EmployeeDetails smodel)
        {
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {

                if (ModelState.IsValid)
                {
                    DataBaseAcessLayer.EmployeeDetailsDB dbhandle = new DataBaseAcessLayer.EmployeeDetailsDB();
                    dbhandle.UpdateDetails(smodel);
                    TempData["msg"] = "Employee  Details Updated Successfully!";
                    return this.RedirectToAction("ShowallEmp", "SchoolAdmin");
                }
                return View(smodel);
            }

        }

        [HttpGet]
        public ActionResult ShowallappliedStudent()
        {

            DataBaseAcessLayer.SchoolAdminDB dbhandle = new DataBaseAcessLayer.SchoolAdminDB();
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                return View(dbhandle.GetAppliedStuentDetails());
            }
        }

        public ActionResult ShowAppliedStudentDetails(int id)
        {

            DataBaseAcessLayer.SchoolAdminDB dbhandle = new DataBaseAcessLayer.SchoolAdminDB();
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                return View(dbhandle.GetAppliedStuentDetails().Find(smodel => smodel.Student_Id == id));
            }
        }


        [HttpGet]
        public ActionResult ShowalladmittedStudents(int id = 0, String School_Codee = null)
        {

            DataBaseAcessLayer.SchoolAdminDB dbhandle = new DataBaseAcessLayer.SchoolAdminDB();
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                return View(dbhandle.GetStuentDetails(id, School_Codee));
            }
        }

        public ActionResult ShowalladmittedStudentsDetails(int id, String School_Codee)
        {
            StudentAdmission model = new StudentAdmission();
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                try
                {
                    DataBaseAcessLayer.SchoolAdminDB dbhandle = new DataBaseAcessLayer.SchoolAdminDB();
                    model.Section_Name = PopulateDropDown("SELECT Section_Id, Section_Name FROM School_Section_Master WHERE School_Code='" + Session["School_Code"] + "'", "Section_Name", "Section_Id");



                    School_Codee = Session["School_Code"].ToString();
                    model.StudentDetails = dbhandle.GetStuentDetails(id, School_Codee);
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;

                }
                // return View(dbhandle.GetStuentDetails().Find(smodel => smodel.Student_Id == id));
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult UpdateStudentRollSection( FormCollection fc)
        {
            StudentAdmission schemp = new StudentAdmission();
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        DataBaseAcessLayer.SchoolAdminDB dbhandle = new DataBaseAcessLayer.SchoolAdminDB();

                        // SchoolEmployeeMaster schemp = new SchoolEmployeeMaster();

                        //smodel.School_Code = fc["School_Code"];
                        schemp.Student_Id = Convert.ToInt32(fc["Student_Id"]);
                        schemp.Assign_Roll_Number = fc["Assign_Roll_Number"];
                        schemp.Section_Id = Convert.ToInt32(fc["Section_Id"]);

                        dbhandle.UpdateRollSection(schemp);
                        TempData["msg"] = "Roll and section  assign Successfully!";
                        return this.RedirectToAction("ShowalladmittedStudents", "SchoolAdmin");

                    }

                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;

                }
                return View(schemp);
            }
        }

        [HttpPost]
        public ActionResult StudentEligilbiltystatus(StudentAdmission smodel)
        {
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    DataBaseAcessLayer.StudentAdmissionDB dbhandle = new DataBaseAcessLayer.StudentAdmissionDB();
                    dbhandle.StudentEligiblity(smodel);
                    //TempData["msg"] = "Parent  Details Updated Successfully!";
                    return this.RedirectToAction("ShowallappliedStudent", "SchoolAdmin");
                }
                return View(smodel);
            }
        }

        [HttpPost]
        public ActionResult UploadStudentAttachement(StudentAdmission smodel, IEnumerable<HttpPostedFileBase> StudentfileUpload)
        {
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        DataBaseAcessLayer.StudentAdmissionDB dbhandle = new DataBaseAcessLayer.StudentAdmissionDB();


                        //   dbhandle.StudentEligiblity(smodel, ImageUpload);

                        // return this.RedirectToAction("ShowallappliedStudent", "SchoolAdmin");
                        if (StudentfileUpload != null)
                        {
                            foreach (var file in StudentfileUpload)
                            {
                                if (file != null && file.ContentLength > 0)
                                {
                                    file.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), Guid.NewGuid() + Path.GetExtension(file.FileName)));

                                    string Student_fileName = Path.GetFileNameWithoutExtension(file.FileName);
                                    string extension = Path.GetExtension(file.FileName);
                                    Student_fileName = Student_fileName + DateTime.Now.ToString("yymmssff") + extension;
                                    file.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), Student_fileName));
                                    smodel.StudentfilePath = "~/AppFiles/Images/" + Student_fileName;
                                }

                                dbhandle.StudentEligiblity(smodel);
                            }
                        }

                        return this.RedirectToAction("ShowallappliedStudent", "SchoolAdmin");

                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;

                }
                return View(smodel);
            }
        }

        public ActionResult SchoolFeesMaster()
        {

            SchoolFeesAdd model = new SchoolFeesAdd();
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                model.Class_Name = PopulateDropDown("SELECT Class_Id, Class_Name FROM Class_Master WHERE School_Code='"+Session["School_Code"]+"'", "Class_Name", "Class_Id");
                model.Year_Name = PopulateDropDown("SELECT Year, Year_Name FROM Year", "Year_Name", "Year");
                return View(model);
            }

        }


        [HttpPost]
        public ActionResult SchoolFeesMaster(FormCollection fc)
        {
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                SchoolFeesAdd model = new SchoolFeesAdd();
                try
                {
                    if (ModelState.IsValid)
                    {
                        SchoolFeesAdd schfees = new SchoolFeesAdd();
                        schfees.School_Id = Convert.ToInt32(fc["School_Id"]);
                        schfees.School_Code = fc["School_Code"];
                        schfees.Class_Id = Convert.ToInt32(fc["Class_Id"]);
                        schfees.Fees_Name = fc["Fees_Name"];
                        schfees.Fees_Desc = fc["Fees_Desc"];
                        schfees.Amount = fc["Amount"];
                        schfees.Year = Convert.ToInt32(fc["Year"]);
                        dblayer3.Add_School_Fees(schfees);
                        TempData["msg"] = "School Fees Info Created Successfully!";
                        return this.RedirectToAction("ShowallFees", "SchoolAdmin");

                    }

                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;

                }
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult ShowallFees()
        {

            DataBaseAcessLayer.SchoolAdminDB dbhandle = new DataBaseAcessLayer.SchoolAdminDB();
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                return View(dbhandle.GetAllFees());
                //return View(dbhandle.GetAdminNotice());
            }
            }

        public ActionResult UpdateFeesDetails(int id)
        {

            DataBaseAcessLayer.SchoolAdminDB dbhandle = new DataBaseAcessLayer.SchoolAdminDB();
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                return View(dbhandle.GetAllFees().Find(smodel => smodel.Fees_Id == id));
            }
        }

        [HttpPost]
        public ActionResult UpdateFeesDetails(int id, SchoolFeesAdd smodel)
        {
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                if (ModelState.IsValid)
                {
                    DataBaseAcessLayer.SchoolAdminDB dbhandle = new DataBaseAcessLayer.SchoolAdminDB();
                    dbhandle.UpdateFeesDetails(smodel);
                    TempData["msg"] = "Fees  Info  Updated Successfully!";
                    return this.RedirectToAction("ShowallFees", "SchoolAdmin");

                }
                return View(smodel);
            }
        }

        public ActionResult DeleteFeesDetails(int id)
        {
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                try
                {
                    DataBaseAcessLayer.SchoolAdminDB dbhandle = new DataBaseAcessLayer.SchoolAdminDB();
                    if (dbhandle.DeleteFees(id))
                    {
                        TempData["msg"] = "Student Deleted Successfully";
                    }

                    return this.RedirectToAction("ShowallFees", "SchoolAdmin");
                }
                catch
                {
                    return View();
                }
            }
        }


        public ActionResult SchoolExamTermAdd()
        {
            SyllabusModule model = new SyllabusModule();
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                model.Class_Name = PopulateDropDown("SELECT Class_Id, Class_Name FROM Class_Master WHERE school_Code='" + Session["School_Code"]+"'", "Class_Name", "Class_Id");
                return View(model);
            }


        }
        [HttpPost]
        public ActionResult SchoolExamTermAdd(FormCollection fc)
        {
            SchoolAdminModel model = new SchoolAdminModel();
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        SyllabusModule exmtrm = new SyllabusModule();
                        exmtrm.School_Id = Convert.ToInt32(fc["School_Id"]);
                        exmtrm.School_Code = fc["School_Code"];
                        exmtrm.School_Name = fc["School_Name"];
                        exmtrm.Exam_Term_Name = fc["Exam_Term_Name"];
                        exmtrm.Class_Id = Convert.ToInt32(fc["Class_Id"]);
                        //  dblayer3.Add_School_Exam_Term(exmtrm);
                        dblayer3.Add_School_Exam_Term(exmtrm);

                        TempData["msg"] = "Exam Term Added Successful!";

                        return this.RedirectToAction("ShowallExamTerm", "SchoolAdmin");
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;

                }
                return View(model);

            }
        }

        [HttpGet]
        public ActionResult ShowallExamTerm()
        {

            DataBaseAcessLayer.SchoolAdminDB dbhandle = new DataBaseAcessLayer.SchoolAdminDB();
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                return View(dbhandle.GetAllExmTerm());
                //return View(dbhandle.GetAdminNotice());
            }
        }

        public ActionResult SchoolRoutineData()
        {

            SchoolRoutine model = new SchoolRoutine();
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                model.Section_Name = PopulateDropDown("SELECT Section_Id,Section_Name FROM School_Section_Master WHERE School_Code='" + Session["School_Code"] + "'", "Section_Name", "Section_Id");
                model.Class_Name = PopulateDropDown("SELECT Class_Id, Class_Name FROM Class_Master WHERE School_Code='" + Session["School_Code"] + "'", "Class_Name", "Class_Id");
                model.Subject_Name = PopulateDropDown("SELECT  Subject_Name ,Subject_Id FROM School_Subject_Master WHERE School_Code= '" + Session["School_Code"] + "' ", "Subject_Name", "Subject_Id");
                model.Room_Name = PopulateDropDown("SELECT  Room_Name ,Room_Id FROM School_Room_Master WHERE School_Code= '" + Session["School_Code"] + "' ", "Room_Name", "Room_Id");
                model.Employee_Name = PopulateDropDown("SELECT  Employee_Name ,Employee_Id FROM School_Employee_Details WHERE School_Code= '" + Session["School_Code"] + "' ", "Employee_Name", "Employee_Id");
                model.Year_Name = PopulateDropDown("SELECT Year,Year_Name FROM Year", "Year_Name", "Year");
                model.Day_Name = PopulateDropDown("SELECT Day_Id,Day_Name FROM Day", "Day_Name", "Day_Id");
                model.Period_Name = PopulateDropDown("SELECT Period_Id,Period_Name FROM Period_Master", "Period_Name", "Period_Id");


                return View(model);
            }
        }
        [HttpPost]
        public ActionResult SchoolRoutineData(FormCollection fc)
        {
            SchoolAdminModel model = new SchoolAdminModel();
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {

                try
                {
                    if (ModelState.IsValid)
                    {
                        SchoolRoutine schrout = new SchoolRoutine();
                        schrout.School_Id = Convert.ToInt32(fc["School_Id"]);
                        schrout.School_Code = fc["School_Code"];
                        schrout.School_Name = fc["School_Name"];
                        schrout.Start_Time = fc["Start_Time"];
                        schrout.End_Time = fc["End_Time"];
                        schrout.Class_Id = Convert.ToInt32(fc["Class_Id"]);
                        schrout.Section_Id = Convert.ToInt32(fc["Section_Id"]);
                        schrout.Employee_Id = Convert.ToInt32(fc["Employee_Id"]);
                        schrout.Subject_Id = Convert.ToInt32(fc["Subject_Id"]);
                        schrout.Room_Id = Convert.ToInt32(fc["Room_Id"]);
                        schrout.Year = Convert.ToInt32(fc["Year"]);
                        schrout.Day_Id = Convert.ToInt32(fc["Day_Id"]);
                        schrout.Period_Id = Convert.ToInt32(fc["Period_Id"]);
                        schrout.Routine_Id = Convert.ToInt32(fc["Routine_Id"]);

                        dblayer3.Add_Class_Routine(schrout);

                        TempData["msg"] = "School Class Routine Created Successfully!";

                        return this.RedirectToAction("ShowallRoutineData", "SchoolAdmin");
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;

                }
                return View(model);
            }
        }



        [HttpGet]
        public ActionResult ShowallRoutineData()
        {

            DataBaseAcessLayer.SchoolAdminDB dbhandle = new DataBaseAcessLayer.SchoolAdminDB();
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                return View(dbhandle.GetAllRoutineData());
                //return View(dbhandle.GetAdminNotice());
            }
        }




        public ActionResult EmployeeWorkRole()
        {


            DataBaseAcessLayer.SchoolAdminDB dbhandle = new DataBaseAcessLayer.SchoolAdminDB();
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                return View(dbhandle.GetEmpWorkRole());
            }
        }


     
            public FileResult DownLoad(string filenamee)
        {
            
            var FileVirtualPath = "~/AppFiles/Images/" + filenamee;
            Console.WriteLine(FileVirtualPath);
            return File(FileVirtualPath, "application/force-download", Path.GetFileName(FileVirtualPath));

            //   DownLoad(Filpath);
        }


        [HttpGet]
        public ActionResult CreateExamSchedule()
        {

            CreateExamSchedule model = new CreateExamSchedule();
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
               // model.Exam_Term_Name = PopulateDropDown("SELECT Exam_Term_id, Exam_Term_Name FROM School_Exam_Term_Master", "Exam_Term_Name", "Exam_Term_id");

                model.Year_Name = PopulateDropDown("SELECT Year, Year_Name FROM Year", "Year_Name", "Year");

                model.Class_Name = PopulateDropDown("SELECT Class_Id, Class_Name FROM Class_Master WHERE School_Code='" + Session["School_Code"] + "'", "Class_Name", "Class_Id");

               // model.Section_Name = PopulateDropDown("SELECT Section_Id, Section_Name FROM School_Section_Master", "Section_Name", "Section_Id");

                //   model.Subject_Name = PopulateDropDown("SELECT Subject_id, Subject_Name FROM School_Subject_Master", "Subject_Name", "Subject_id");
               // model.Subject_Name = PopulateDropDown("SELECT  Subject_Name ,Subject_Id FROM School_Subject_Master WHERE School_Code= '" + Session["School_Code"] + "' ", "Subject_Name", "Subject_Id");

                model.Day_Name = PopulateDropDown("SELECT Day_Id, Day_Name FROM Day", "Day_Name", "Day_Id");




                //model.User_Type_Name = PopulateDropDown("SELECT  User_Type_Id ,User_Type_Name FROM School_User_Type_Master", "User_Type_Name", "User_Type_Id");

                return View(model);
            }
        }



        [HttpPost]
        public ActionResult CreateExamSchedule(FormCollection fc)
        {

            CreateExamSchedule model = new CreateExamSchedule();
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                try
                {
                    if (ModelState.IsValid)
                    {

                        CreateExamSchedule examschd = new CreateExamSchedule();
                        examschd.Exam_Term_id = Convert.ToInt32(fc["Exam_Term_id"]);
                        examschd.Year = fc["Year"];
                        examschd.School_Code = fc["School_Code"];
                        examschd.School_Id = Convert.ToInt32(fc["School_Id"]);
                        examschd.Class_Id = Convert.ToInt32(fc["Class_Id"]);
                        examschd.Section_Id = Convert.ToInt32(fc["Section_Id"]);
                        examschd.Exam_Subject_Type =fc["Exam_Subject_Type"];
                        examschd.Subject_id = Convert.ToInt32(fc["Subject_id"]);
                        examschd.Day_Id = Convert.ToInt32(fc["Day_Id"]);
                        examschd.Exam_Date = fc["Exam_Date"];
                        // examschd.Year = Convert.ToInt32(fc["Year"]);
                        examschd.Start_Time = fc["Start_Time"];
                        examschd.End_Time = fc["End_Time"];

                        dblayer3.Add_Exam_Schedule(examschd);

                        TempData["msg"] = "Exam Schedule Created Successfully!";

                        return this.RedirectToAction("AdminHeaderBoard", "Dashboard");
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;

                }
                return View(model);

            }

        }


        //[HttpGet]
        //public ActionResult ViewExamSchedule()
        //{
        //    CreateExamSchedule model = new CreateExamSchedule();

        //    DataBaseAcessLayer.SchoolAdminDB dbhandle = new DataBaseAcessLayer.SchoolAdminDB();
        //    if (Session["School_Code"] == null)
        //    {
        //        return Redirect("~/SchoolAdmin/SchoolAdminLogin");
        //    }
        //    else
        //    {
        //        model.Class_Name = PopulateDropDown("SELECT Class_Id, Class_Name FROM Class_Master", "Class_Name", "Class_Id");

        //        model.Section_Name = PopulateDropDown("SELECT Section_Id, Section_Name FROM School_Section_Master", "Section_Name", "Section_Id");
        //        model.Exam_Term_Name = PopulateDropDown("SELECT Exam_Term_id, Exam_Term_Name FROM School_Exam_Term_Master", "Exam_Term_Name", "Exam_Term_id");


        //        return View(dbhandle.GetAllExamRoutine());
        //    }
        //}

        [HttpGet]
        public ActionResult ViewExamSchedule()
        {
            CreateExamSchedule model = new CreateExamSchedule();

            DataBaseAcessLayer.SchoolAdminDB dbhandle = new DataBaseAcessLayer.SchoolAdminDB();
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                model.Class_Name = PopulateDropDown("SELECT Class_Id, Class_Name FROM Class_Master", "Class_Name", "Class_Id");

                //model.Section_Name = PopulateDropDown("SELECT Section_Id, Section_Name FROM School_Section_Master", "Section_Name", "Section_Id");
                //model.Exam_Term_Name = PopulateDropDown("SELECT Exam_Term_id, Exam_Term_Name FROM School_Exam_Term_Master", "Exam_Term_Name", "Exam_Term_id");
                model.Year_Name = PopulateDropDown("SELECT Year, Year_Name FROM Year", "Year_Name", "Year");

                return View(model);
               // return View(dbhandle.GetAllExamRoutine());
            }
        }

        public ActionResult ParentDetails(int id)
        {
            DataBaseAcessLayer.SchoolAdminDB dbhandle = new DataBaseAcessLayer.SchoolAdminDB();
            //DataBaseAcessLayer.ParentDetailsDB dbhandle = new DataBaseAcessLayer.ParentDetailsDB();
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                return View(dbhandle.GetParentDetails().Find(smodel => smodel.ParentID == id));
            }
        }


        [HttpGet]
        public ActionResult AssignJobRole()
        {

            DataBaseAcessLayer.SchoolAdminDB dbhandle = new DataBaseAcessLayer.SchoolAdminDB();
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                return View(dbhandle.GetEmpDetails());
            }

        }

        [HttpGet]
        public ActionResult AssignRole()
        {

            DataBaseAcessLayer.SchoolAdminDB dbhandle = new DataBaseAcessLayer.SchoolAdminDB();
            SchoolEmpTypeMaster model = new SchoolEmpTypeMaster();

            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                // return View(dbhandle.GetEmpDetails());
                model.EmpTypeMasteRList = dbhandle.GetEmpAllDesignation();
               return View(model);
            }

        }

        [HttpGet]
        public ActionResult SubjectAdd()
        {
            SchoolSectionMaster model = new SchoolSectionMaster();
            //model.EmpType_Name = PopulateDropDown("select Distinct EmpType_Name, Type_Id from School_EmpType_Master", "EmpType_Name", "Type_Id");
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                //model.Emp_Name = PopulateDropDown("select Distinct Employee_Name, Employee_id from School_Employee_Details", "Employee_Name", "Employee_id");
                //model.Class_Name = PopulateDropDown("select Distinct Subject_id, Subject_Name from School_Subject_Master", "Subject_Name", "Subject_id");
                model.Class_Name = PopulateDropDown("select Distinct Class_Id,Class_Name from Class_Master WHERE School_Code='" + Session["School_Code"] + "'", "Class_Name", "Class_Id");

                return View(model);

            }
        }

        ////////Subject to Teacher/////
        [HttpGet]
        public ActionResult SubjectsAssigned()
        {
            RoleAssigned model = new RoleAssigned();

            model.EmpType_Name = PopulateDropDown("select Distinct EmpType_Name, Type_Id from School_EmpType_Master WHERE School_Code='" + Session["School_Code"] + "'", "EmpType_Name", "Type_Id");
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {

                //model.Emp_Name = PopulateDropDown("select Distinct Employee_Name, Employee_id from School_Employee_Details where School_Code=" + Session["School_Code"], "Employee_Name", "Employee_id");

                model.Emp_Name = PopulateDropDown("select SED.Employee_Name Employee_Name, SED.Employee_id Employee_id from School_Employee_Details as SED ,School_EmpType_Master AS SEM WHERE SED.EmpType_Id = SEM.Type_Id AND SEM.EmpType_Name like '%Teacher%' And SED.School_Code='" + Session["School_Code"] + "'", "Employee_Name", "Employee_id");
                model.Sub_Name = PopulateDropDown("select Distinct Subject_id, Subject_Name from School_Subject_Master where School_Code='" + Session["School_Code"] + "'", "Subject_Name", "Subject_id");
                model.Class_ID = PopulateDropDown("select Distinct Class_Id,Class_Name from Class_Master WHERE School_Code='" + Session["School_Code"] + "'", "Class_Name", "Class_Id");
                model.Sec_ID = PopulateDropDown("select Distinct Section_Name,Section_Id from School_Section_Master where School_Code='" + Session["School_Code"] + "'", "Section_Name", "Section_Id");

                return View(model);

            }
        }
        //eid=' + eid + '&sec=' + sec+ '&cls=' +cls+ '&sub=' +sub;

        [HttpGet]
        public ActionResult EditSubject(int eid, int ID)
        {
            RoleAssigned model = new RoleAssigned();

            List<RoleAssigned> Rolelist = new List<RoleAssigned>();

            //model.EmpType_Name = PopulateDropDown("select Distinct EmpType_Name, Type_Id from School_EmpType_Master", "EmpType_Name", "Type_Id");
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                model.Emp_Name = PopulateDropDown("select Distinct Employee_Name, Employee_id from School_Employee_Details WHERE School_Code='" + Session["School_Code"] + "'", "Employee_Name", "Employee_id");
                model.Sub_Name = PopulateDropDown("select Distinct Subject_id, Subject_Name from School_Subject_Master WHERE School_Code='" + Session["School_Code"] + "'", "Subject_Name", "Subject_id");
                model.Class_ID = PopulateDropDown("select Distinct Class_Id,Class_Name from Class_Master WHERE School_Code='" + Session["School_Code"] + "'", "Class_Name", "Class_Id");
                model.Sec_ID = PopulateDropDown("select Distinct Section_Name,Section_Id from School_Section_Master WHERE School_Code='" + Session["School_Code"] + "'", "Section_Name", "Section_Id");

                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);

                SqlCommand cmd = new SqlCommand("RoleAssigned", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@ID", ID);
                //cmd.Parameters.AddWithValue("@EmpType_ID", Convert.ToInt32(fc["EmpType_ID"]));

                cmd.Parameters.AddWithValue("@Query", 5);
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                con.Open();
                sd.Fill(dt);
                con.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    Rolelist.Add(
                      new RoleAssigned
                      {
                          ID = ID,
                          eid = eid,
                          Sub_ID = Convert.ToInt32(dr["Sub_ID"]),
                          class_id = Convert.ToInt32(dr["Class_ID"]),
                          sec_id = Convert.ToInt32(dr["Section_ID"])
                      });
                }


                //Rolelist.Add(
                //  new RoleAssigned
                //  {
                //      eid = eid,
                //      subject_name = sub,
                //      class_name = cls,
                //      sec_name = sec
                //  }); ;


                model.RoleList = Rolelist;
                return View(model);

            }


        }

        [HttpPost]
        public ActionResult EditSubject(FormCollection fc)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("RoleAssigned", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Emp_ID", fc["eid"]);

            cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);



            cmd.Parameters.AddWithValue("@ID", Convert.ToInt32(fc["ID"]));
            cmd.Parameters.AddWithValue("@Class_ID", fc["class_name"]);
            cmd.Parameters.AddWithValue("@Sub_ID", fc["Sub_ID"]);
            cmd.Parameters.AddWithValue("@Section_ID", fc["sec_name"]);
            cmd.Parameters.AddWithValue("@Query", 6);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();



            return this.RedirectToAction("SubjectAssignedList", "SchoolAdmin");
        }

        [HttpPost]

        public ActionResult SubjectsAssigned(FormCollection fc)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("RoleAssigned", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Emp_ID", fc["Emp_Code"]);

            cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);



            cmd.Parameters.AddWithValue("@Sub_ID", Convert.ToInt32(fc["Sub_ID"]));
            cmd.Parameters.AddWithValue("@Class_ID", fc["class_name"]);

            cmd.Parameters.AddWithValue("@Section_ID", fc["sec_name"]);
            cmd.Parameters.AddWithValue("@Query", 1);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


            return this.RedirectToAction("SubjectsAssigned", "SchoolAdmin");


        }

        //[HttpPost]
        //public ActionResult RoleAssigned(FormCollection fc)
        //{
        //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
        //    SqlCommand cmd = new SqlCommand("RoleAssigned", con);
        //    cmd.CommandType = CommandType.StoredProcedure; cmd.Parameters.AddWithValue("@Emp_Code", fc["Emp_Code"]);
        //    cmd.Parameters.AddWithValue("@EmpType_ID", Convert.ToInt32(fc["EmpType_ID"]));
        //    cmd.Parameters.AddWithValue("@Sub_ID", Convert.ToInt32(fc["Sub_ID"]));
        //    cmd.Parameters.AddWithValue("@Class_ID", fc["Class_ID"]);
        //    cmd.Parameters.AddWithValue("@Query", 1);
        //    SqlDataAdapter sd = new SqlDataAdapter(cmd); con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close(); return this.RedirectToAction("RoleAssigned", "SchoolAdmin");
        //}
        ////[HttpPost]
        ////public ActionResult SubjectAssigned(FormCollection fc)
        ////{
        ////    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
        ////    SqlCommand cmd = new SqlCommand("RoleAssigned", con);
        ////    cmd.CommandType = CommandType.StoredProcedure; cmd.Parameters.AddWithValue("@Emp_Code", fc["Emp_Code"]);
        ////   // cmd.Parameters.AddWithValue("@EmpType_ID", Convert.ToInt32(fc["EmpType_ID"]));
        ////    cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);
        ////   // cmd.Parameters.AddWithValue("@Emp_ID", fc["Emp_Id"]);
        ////    cmd.Parameters.AddWithValue("@Emp_ID", fc["Emp_Code"]);

        ////    cmd.Parameters.AddWithValue("@Sub_ID", Convert.ToInt32(fc["Sub_ID"]));
        ////    cmd.Parameters.AddWithValue("@Class_ID", fc["Class_ID"]);
        ////    cmd.Parameters.AddWithValue("@Query", 1);
        ////    SqlDataAdapter sd = new SqlDataAdapter(cmd);
        ////    con.Open();
        ////    cmd.ExecuteNonQuery();
        ////    con.Close();

        ////    int len = Convert.ToInt32(fc["noofsub"]);

        ////    for (int i = 1; i <= len; i++)
        ////    {
        ////        cmd = new SqlCommand("RoleAssigned", con);
        ////        cmd.CommandType = CommandType.StoredProcedure;
        ////        cmd.Parameters.AddWithValue("@Emp_ID", fc["Emp_Code"]);

        ////       // cmd.Parameters.AddWithValue("@Emp_ID", fc["Emp_Id"]);
        ////         cmd.Parameters.AddWithValue("@School_Code",Session["School_Code"]);
        ////        cmd.Parameters.AddWithValue("@Sub_ID", Convert.ToInt32((fc["subject" + i]).Substring(0, (fc["subject" + i]).IndexOf(",")).Replace(" ", "")));
        ////        cmd.Parameters.AddWithValue("@Class_ID", fc["class" + i]);
        ////        cmd.Parameters.AddWithValue("@Query", 1);
        ////        SqlDataAdapter sd1 = new SqlDataAdapter(cmd);     

        ////        con.Open();
        ////        cmd.ExecuteNonQuery();
        ////        con.Close();
        ////    }
        ////    return this.RedirectToAction("RoleAssigned", "SchoolAdmin");
        ////}

        [HttpPost]
        public ActionResult SubjectAssigned(FormCollection fc)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("RoleAssigned", con);
            cmd.CommandType = CommandType.StoredProcedure; cmd.Parameters.AddWithValue("@Emp_ID", fc["Emp_Code"]);

            cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);

            cmd.Parameters.AddWithValue("@Sub_ID", Convert.ToInt32(fc["Sub_ID"]));
            cmd.Parameters.AddWithValue("@Class_ID", fc["Class_ID"]);
            cmd.Parameters.AddWithValue("@Query", 1);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close(); int len = (fc["noofsub"] == "" ? 0 : Convert.ToInt32(fc["noofsub"])); for (int i = 1; i <= len; i++)
            {
                cmd = new SqlCommand("RoleAssigned", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Emp_ID", fc["Emp_Code"]);               // cmd.Parameters.AddWithValue("@Emp_ID", fc["Emp_Id"]);
                cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);
                cmd.Parameters.AddWithValue("@Sub_ID", Convert.ToInt32((fc["subject" + i]).Substring(0, (fc["subject" + i]).IndexOf(",")).Replace(" ", "")));
                cmd.Parameters.AddWithValue("@Class_ID", fc["class" + i]);
                cmd.Parameters.AddWithValue("@Query", 1);
                SqlDataAdapter sd1 = new SqlDataAdapter(cmd); con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
            return this.RedirectToAction("SubjectAssigned", "SchoolAdmin");
        }


        [HttpGet]
        public ActionResult SubjectAssignedList()
        {
            RoleAssigned model = new RoleAssigned();
            model.EmpType_Name = PopulateDropDown("select Distinct EmpType_Name, Type_Id from School_EmpType_Master WHERE School_Code='" + Session["School_Code"] + "'", "EmpType_Name", "Type_Id");
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                model.Emp_Name = PopulateDropDown("select Distinct Employee_Name, Employee_id from School_Employee_Details WHERE School_Code='" + Session["School_Code"] + "'", "Employee_Name", "Employee_id");
                model.Sub_Name = PopulateDropDown("select Distinct Subject_id, Subject_Name from School_Subject_Master WHERE School_Code='" + Session["School_Code"] + "'", "Subject_Name", "Subject_id");
                model.Class_ID = PopulateDropDown("select Distinct Class_Id,Class_Name from Class_Master WHERE School_Code='" + Session["School_Code"] + "'", "Class_Name", "Class_Id");

                return View(model);

            }
        }

        public JsonResult AjaxGetEmployee(String emp)
        {
            RoleAssigned model = new RoleAssigned(); SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            List<RoleAssigned> Rolelist = new List<RoleAssigned>(); SqlCommand cmd = new SqlCommand("RoleAssigned", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Emp_Code", Convert.ToInt32(emp));
            //cmd.Parameters.AddWithValue("@EmpType_ID", Convert.ToInt32(fc["EmpType_ID"]));    
            cmd.Parameters.AddWithValue("@Query", 3);
            SqlDataAdapter sd = new SqlDataAdapter(cmd); DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                Rolelist.Add(
                  new RoleAssigned
                  {
                      subject_name = Convert.ToString(dr["subject_name"]),
                      class_name = Convert.ToString(dr["class_name"])
                  });
            }
            model.RoleList = Rolelist;
            return Json(model);
        }
        [HttpPost]
        public JsonResult AjaxDelClass(String emp, String sub, String cls)
        {
            RoleAssigned model = new RoleAssigned();


            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString); List<RoleAssigned> Rolelist = new List<RoleAssigned>();

            SqlCommand cmd = new SqlCommand("RoleAssigned", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Emp_Code", Convert.ToInt32(emp)); cmd.Parameters.AddWithValue("@sub_name", sub);
            cmd.Parameters.AddWithValue("@class_name", cls);

            cmd.Parameters.AddWithValue("@Query", 4);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close(); return Json(model);
        }





        public ActionResult EventCalendar()
        {
            return View();
        }

        public JsonResult GetEvents()
        {
            //using (MyDatabaseEntities dc = new MyDatabaseEntities())
            //{
            //    var events = dc.Events.ToList();
            //    return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
            //}

            List<Event_Calendar> FeeList = new List<Event_Calendar>();
            String con = ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);

           
                string sqlquery = "SELECT * FROM [dbo].[Event_Calendar] ";///WHERE ST_Section = '"+ value + "'
                sqlcon.Open();
                SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlcom;
                DataTable dt = new DataTable();
                da.Fill(dt);
                sqlcon.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    FeeList.Add(
                    new Event_Calendar
                    {
                        Event_ID = Convert.ToInt32(dr["Event_ID"]),
                        Subject = Convert.ToString(dr["Subject"]),
                        Description = Convert.ToString(dr["Description"]),
                        Start_Date = Convert.ToString(dr["Start_Date"]),
                        End_Date = Convert.ToString(dr["End_Date"]),
                        Theme_Color = Convert.ToString(dr["Theme_Color"]),
                        Is_Full_Day = Convert.ToString(dr["Is_Full_Day"]),
                    });
                }

            //  return Json(FeeList, JsonRequestBehavior.AllowGet);
                return new JsonResult { Data = FeeList, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }

        public JsonResult AjaxPerformance(string School_code, int ParentId)
        {
            WorkRole_Header model = new WorkRole_Header();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);

            List<WorkRole_Header> EmpWorkRoleList = new List<WorkRole_Header>();
            List<WorkRole_Header> StudentList = new List<WorkRole_Header>();

            SqlCommand cmd = new SqlCommand("Students_performance", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@School_Code", School_code);
            cmd.Parameters.AddWithValue("@ParentId", ParentId);
            cmd.Parameters.AddWithValue("@Query", 1);
            SqlDataAdapter sd = new SqlDataAdapter(cmd); DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                EmpWorkRoleList.Add(
                    new WorkRole_Header
                    {
                        marks = Convert.ToInt32(dr["Marks"]),
                        date = Convert.ToString(dr["Date_Exam"]),
                        sub_id = Convert.ToInt32(dr["Subject_ID"])
                    });
            }
            model.marklist = EmpWorkRoleList;


            cmd = new SqlCommand("Students_performance", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@School_Code", School_code);
            cmd.Parameters.AddWithValue("@ParentId", ParentId);
            cmd.Parameters.AddWithValue("@Query", 2);
            sd = new SqlDataAdapter(cmd);
            dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                StudentList.Add(
                    new WorkRole_Header
                    {

                        std_name = Convert.ToString(dr["std_name"]),
                        std_id = Convert.ToInt32(dr["std_id"])
                    });
            }
            model.marklist = EmpWorkRoleList;
            model.studentlist = StudentList;
            return Json(model);
        }
        public JsonResult AjaxStudentGraph(int Student_ID)
        {

            WorkRole_Header model = new WorkRole_Header();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);

            List<WorkRole_Header> EmpWorkRoleList = new List<WorkRole_Header>();

            List<WorkRole_Header> homeworklist = new List<WorkRole_Header>();
            SqlCommand cmd = new SqlCommand("Students_performance", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Student_ID", Student_ID);

            cmd.Parameters.AddWithValue("@Query", 3);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                EmpWorkRoleList.Add(
                    new WorkRole_Header
                    {
                        marks = Convert.ToInt32(dr["Marks"]),
                        date = Convert.ToString(dr["Date_Exam"]),
                        sub_id = Convert.ToInt32(dr["Subject_ID"])
                    });
            }
            model.marklist = EmpWorkRoleList;


            cmd = new SqlCommand("Students_performance", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Student_ID", Student_ID);

            cmd.Parameters.AddWithValue("@Query", 4);
            sd = new SqlDataAdapter(cmd);
            dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                homeworklist.Add(
                    new WorkRole_Header
                    {

                        subject = Convert.ToString(dr["subject"]),
                        status = Convert.ToString(dr["status"]),

                        Description = Convert.ToString(dr["Description"])

                    });
            }
            model.homeworklist = homeworklist;



            return Json(model);
        }





        [HttpPost]
        public JsonResult ViewExamScheduled(String class_id, String exam_term_id, String exam_year)
        {
            //    List<CreateExamSchedule> StudentList = new List<CreateExamSchedule>();
            ////try
            ////{
            //    String School_Code = Session["School_Code"].ToString();
            //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);

            //    SqlCommand cmd = new SqlCommand("Exam_Schedule_Insert_Update", con);
            //    cmd.CommandType = CommandType.StoredProcedure;
            //    cmd.Parameters.AddWithValue("@School_Code", School_Code);
            //    cmd.Parameters.AddWithValue("@Query", 3);
            //    SqlDataAdapter sd = new SqlDataAdapter(cmd);

            //    DataTable dt = new DataTable();

            //    con.Open();
            //    sd.Fill(dt);
            //    con.Close();

            //    foreach (DataRow dr in dt.Rows)
            //    {
            //    StudentList.Add(
            //         new CreateExamSchedule
            //         {

            List<CreateExamSchedule> StudentList = new List<CreateExamSchedule>();
            String con = ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);

            //String School_Code = Session["School_Code"].ToString();
            String School_Code = Session["School_Code"].ToString();

            string sqlquery = "SELECT ES.*,ETM.Exam_Term_Name,CM.Class_Name,SM.Section_Name,SSM.Subject_Name  FROM Exam_Schedule AS ES, Class_Master AS CM ,School_Exam_Term_Master AS ETM,School_Section_Master AS SM,School_Subject_Master AS SSM WHERE ES.School_Code ='" + School_Code + "'  AND ES.Class_Id = '"+ class_id + "' AND ES.ExamTerm_Id ='"+ exam_term_id + "' AND ES.Year ='"+ exam_year + "' AND ES.ExamTerm_Id = ETM.Exam_Term_id AND ES.Class_Id = CM.Class_Id AND ES.Section_Id = SM.Section_Id AND ES.Subject_Id = SSM.Subject_Id  ";
            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlcom;
            DataTable dt = new DataTable();
            da.Fill(dt);
            sqlcon.Close();
            foreach (DataRow dr in dt.Rows)
            {
                StudentList.Add(
                new CreateExamSchedule
                {

                         ExamSchedule_Id = Convert.ToInt32(dr["ExamSchedule_Id"]),
                         ExamTerm_Id = Convert.ToInt32(dr["ExamTerm_Id"]),
                         School_Code = Convert.ToString(dr["School_Code"]),
                         Exm_Term_Name = Convert.ToString(dr["Exam_Term_Name"]),
                         Year = Convert.ToString(dr["Year"]),
                         Class = Convert.ToString(dr["Class_Name"]),



                         Subject_Namee = Convert.ToString(dr["Subject_Name"]),
                        // Day_Namee = Convert.ToString(dr["Day_Name"]),
                         Exam_Date = Convert.ToString(dr["Exam_Date"]),


                         Start_Time = Convert.ToString(dr["Start_Time"]),
                         End_Time = Convert.ToString(dr["End_Time"])



                     });
                }

            return Json(new { StudentList = StudentList}, JsonRequestBehavior.AllowGet);

            // return Json(StudentList, JsonRequestBehavior.AllowGet);
           // return new JsonResult { Data = StudentList, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }

        [HttpGet]
        public ActionResult ExamScheduleDetails(int ExamScheduleId)
        {
            CreateExamSchedule model = new CreateExamSchedule();

            DataBaseAcessLayer.SchoolAdminDB dbhandle = new DataBaseAcessLayer.SchoolAdminDB();
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                model.Exam_Term_Name = PopulateDropDown("SELECT Exam_Term_id, Exam_Term_Name FROM School_Exam_Term_Master WHERE School_Code='" + Session["School_Code"] + "'", "Exam_Term_Name", "Exam_Term_id");

                model.Year_Name = PopulateDropDown("SELECT Year, Year_Name FROM Year", "Year_Name", "Year");

                model.Class_Name = PopulateDropDown("SELECT Class_Id, Class_Name FROM Class_Master WHERE School_Code='" + Session["School_Code"] + "'", "Class_Name", "Class_Id");

                model.Section_Name = PopulateDropDown("SELECT Section_Id, Section_Name FROM School_Section_Master WHERE School_Code='" + Session["School_Code"] + "'", "Section_Name", "Section_Id");

                //   model.Subject_Name = PopulateDropDown("SELECT Subject_id, Subject_Name FROM School_Subject_Master", "Subject_Name", "Subject_id");
                model.Subject_Name = PopulateDropDown("SELECT  Subject_Name ,Subject_Id FROM School_Subject_Master WHERE School_Code= '" + Session["School_Code"] + "' ", "Subject_Name", "Subject_Id");

                model.Day_Name = PopulateDropDown("SELECT Day_Id, Day_Name FROM Day", "Day_Name", "Day_Id");


                model.ExamSchduleList = dbhandle.ExamSchedukeList1(ExamScheduleId);

                return View(model);
                // return View(dbhandle.GetAllExamRoutine());
            }
        }

        [HttpPost]
        public ActionResult Update_ExamSchedule(FormCollection fc)
        {
            DataBaseAcessLayer.SchoolAdminDB dbhandle = new DataBaseAcessLayer.SchoolAdminDB();

            CreateExamSchedule model = new CreateExamSchedule();
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                try
                {
                    //if (ModelState.IsValid)
                    //{

                        CreateExamSchedule examschd = new CreateExamSchedule();
                        //examschd.Exam_Term_id = Convert.ToInt32(fc["Exam_Term_id"]);
                        //examschd.Year = fc["Year"];
                        //examschd.School_Code = fc["School_Code"];
                        //examschd.School_Id = Convert.ToInt32(fc["School_Id"]);
                        //examschd.Class_Id = Convert.ToInt32(fc["Class_Id"]);
                        //examschd.Section_Id = Convert.ToInt32(fc["Section_Id"]);
                        //examschd.Subject_id = Convert.ToInt32(fc["Subject_id"]);
                        //examschd.Day_Id = Convert.ToInt32(fc["Day_Id"]);
                        examschd.ExamSchedule_Id = Convert.ToInt32(fc["ExamSchedule_Id"]);
                        // examschd.Year = Convert.ToInt32(fc["Year"]);
                        examschd.Exam_Date = fc["Exam_Date"];
                        examschd.Start_Time = fc["Start_Time"];
                        examschd.End_Time = fc["End_Time"];

                        dbhandle.Update_ExamSchedule(examschd);

                        TempData["msg"] = "Exam Re-Schedule done Successfully!";

                        return this.RedirectToAction("AdminHeaderBoard", "Dashboard");
                    //}
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;

                }
                // return View(model);
                return this.RedirectToAction("AdminHeaderBoard", "Dashboard");


            }

        }


        public ActionResult CreateExamSchedule_Report(String class_id, String exam_term_id, String exam_year)
        {
            
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {

                CreateExamSchedule examschd = new CreateExamSchedule();
                //examschd.Exam_Term_id = Convert.ToInt32(fc["Exam_Term_id"]);
                //examschd.Year = fc["Year"];
                //examschd.Class_Id = Convert.ToInt32(fc["Class_Id"]);

                List<CreateExamSchedule> AllExamList = new List<CreateExamSchedule>();
                String con = ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString;
                SqlConnection sqlcon = new SqlConnection(con);

                String School_Code = Session["School_Code"].ToString();

                // string sqlquery = "SELECT ES.*,ETM.Exam_Term_Name,CM.Class_Name,SM.Section_Name,SSM.Subject_Name,DY.Day_Name  FROM Exam_Schedule AS ES, Class_Master AS CM ,School_Exam_Term_Master AS ETM,School_Section_Master AS SM,School_Subject_Master AS SSM,Day AS DY WHERE ES.School_Code ='" + School_Code + "'  AND ES.Class_Id = '" + examschd.Class_Id + "' AND ES.ExamTerm_Id ='" + examschd.Exam_Term_id + "' AND ES.Year ='" + examschd.Year + "' AND ES.ExamTerm_Id = ETM.Exam_Term_id AND ES.Class_Id = CM.Class_Id AND ES.Section_Id = SM.Section_Id AND ES.Subject_Id = SSM.Subject_Id AND ES.Day_Id = DY.Day_Id ";
                string sqlquery = "SELECT ES.*,ETM.Exam_Term_Name,CM.Class_Name,SM.Section_Name,SSM.Subject_Name  FROM Exam_Schedule AS ES, Class_Master AS CM ,School_Exam_Term_Master AS ETM,School_Section_Master AS SM,School_Subject_Master AS SSM WHERE ES.School_Code ='" + School_Code + "'  AND ES.Class_Id = '" + class_id + "' AND ES.ExamTerm_Id ='" + exam_term_id + "' AND ES.Year ='" + exam_year + "' AND ES.ExamTerm_Id = ETM.Exam_Term_id AND ES.Class_Id = CM.Class_Id AND ES.Section_Id = SM.Section_Id AND ES.Subject_Id = SSM.Subject_Id ";

                sqlcon.Open();
                SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlcom;
                DataTable dt = new DataTable();
                da.Fill(dt);
                sqlcon.Close();
                foreach (DataRow dr in dt.Rows)
                {
                    AllExamList.Add(
                    new CreateExamSchedule
                    {

                        ExamSchedule_Id = Convert.ToInt32(dr["ExamSchedule_Id"]),
                        ExamTerm_Id = Convert.ToInt32(dr["ExamSchedule_Id"]),
                        School_Code = Convert.ToString(dr["School_Code"]),
                        Exm_Term_Name = Convert.ToString(dr["Exam_Term_Name"]),
                       // Year = Convert.ToString(dr["Year"]),
                       // Class = Convert.ToString(dr["Class_Name"]),



                        Subject_Namee = Convert.ToString(dr["Subject_Name"]),
                       // Day_Namee = Convert.ToString(dr["Day_Name"]),
                        Exam_Date = Convert.ToString(dr["Exam_Date"]),


                        Start_Time = Convert.ToString(dr["Start_Time"]),
                        End_Time = Convert.ToString(dr["End_Time"])



                    });
                }

                ReportDocument rd = new ReportDocument();
                rd.Load(Path.Combine(Server.MapPath("~/Reports"), "ExamScheduleReport.rpt"));
                rd.SetDataSource(AllExamList);

                Response.Buffer = false;
                Response.ClearContent();
                Response.ClearHeaders();
                try
                {
                    Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                    stream.Seek(0, SeekOrigin.Begin);
                    return File(stream, "application/pdf", "ExamSchedule.pdf");
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
        }


        [HttpPost]
        public JsonResult AjaxMethod_SectionList(string type, int value, String Section_Id)
        {
            CreateExamSchedule model = new CreateExamSchedule();

            switch (type)
            {
                case "Class_Id":

                    //  model.PeriodList = PopulateDropDown("SELECT Period_Name, Period_Name FROM Period_Master WHERE School_Code='" + Session["School_Code"] + "' AND Class_Id='" + value + "' ", "Period_Name", "Period_Name");
                    // break;

                    // case "Period_Id":

                    model.Exam_Term_Name = PopulateDropDown("SELECT Exam_Term_id, Exam_Term_Name FROM School_Exam_Term_Master WHERE School_Code='" + Session["School_Code"] + "' AND Class_Id='" + value + "' ", "Exam_Term_Name", "Exam_Term_id");

                    //  model.SectionList = PopulateDropDown("SELECT Section_Id, Section_Name FROM School_Section_Master WHERE School_Code ='" + Session["School_Code"] + "' AND Class_Id ='" + value + "' ", "Section_Name", "Section_Id");
                    model.Section_Name = PopulateDropDown("SELECT Section_Id, Section_Name FROM School_Section_Master WHERE  School_Code='" + Session["School_Code"] + "' AND Class_Id='" + value + "' ", "Section_Name", "Section_Id");

                    break;

            }
            return Json(model);
        }


        [HttpPost]
        public JsonResult AjaxMethod_Subject(string type, int Class_Id, String value=null)
        {
            CreateExamSchedule model = new CreateExamSchedule();
           // int Beng = value;
            switch (type)
            {
                case "Exam_Subject_Type":
                    // model.States = PopulateDropDown("SELECT StateId, StateName FROM state WHERE CountryId = " + value, "StateName", "StateId");
                    model.Subject_Name = PopulateDropDown("SELECT  Subject_Name ,Subject_Id FROM School_Subject_Master WHERE School_Code= '" + Session["School_Code"] + "' AND Exam_Sub_Type='"+value+"' AND Class_Id='"+Class_Id+"' ", "Subject_Name", "Subject_Id");

                    break;
                
            }
            return Json(model);
        }

        [HttpPost]


        public JsonResult AjaxDataTable()
        {

            Routine model = new Routine();
            List<Routine> Templist = new List<Routine>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Routine", con);
            cmd.CommandType = CommandType.StoredProcedure;



            cmd.Parameters.AddWithValue("@School_Group_Code", Session["School_Group_Code"]);

            cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);



            cmd.Parameters.AddWithValue("@Query", 3);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();


            foreach (DataRow dr in dt.Rows)
            {
                Templist.Add(new Routine
                {
                    Category_ID = Convert.ToInt32(dr["Category_ID"]),
                    Categoryname = Convert.ToString(dr["Category_Name"]),
                    CategoryDescription = Convert.ToString(dr["Category_Description"])
                });




            }

            model.Templist = Templist;
            return Json(model);



        }

        public ActionResult School_RoomCategory(int id)
        {

            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                Routine model = new Routine();

                model.id = id;
                if (id > 0)
                {

                    List<Routine> Templist = new List<Routine>();
                    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
                    SqlCommand cmd = new SqlCommand("Routine", con);
                    cmd.CommandType = CommandType.StoredProcedure;



                    cmd.Parameters.AddWithValue("@School_Group_Code", Session["School_Group_Code"]);

                    cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);

                    cmd.Parameters.AddWithValue("@category_id", id);

                    cmd.Parameters.AddWithValue("@Query", 4);

                    SqlDataAdapter sd = new SqlDataAdapter(cmd);

                    DataTable dt = new DataTable();
                    con.Open();
                    sd.Fill(dt);
                    con.Close();


                    foreach (DataRow dr in dt.Rows)
                    {

                        model.Category_ID = Convert.ToInt32(dr["Category_ID"]);
                        model.Categoryname = Convert.ToString(dr["Category_Name"]);
                        model.CategoryDescription = Convert.ToString(dr["Category_Description"]);




                    }







                }//endif


                return View(model);
            }
        }

        [HttpPost]
        public JsonResult AjaxRoomCategory(String categoryname)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Routine", con);
            cmd.CommandType = CommandType.StoredProcedure;



            cmd.Parameters.AddWithValue("@School_Group_Code", Session["School_Group_Code"]);

            cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);




            cmd.Parameters.AddWithValue("@category_name", categoryname);


            cmd.Parameters.AddWithValue("@Query", 2);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();
            int i = 0;

            foreach (DataRow dr in dt.Rows)
            {

                i = Convert.ToInt32(dr["cnt"]);



            }

            if (i > 0)
                return Json("Data Exists!!");
            else
                return Json("");
        }
        [HttpPost]
        public JsonResult AjaxInsert(String categoryname, String CategoryDescription)
        {


            Routine model = new Routine();


            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Routine", con);
            cmd.CommandType = CommandType.StoredProcedure;



            cmd.Parameters.AddWithValue("@School_Group_Code", Session["School_Group_Code"]);

            cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);
            cmd.Parameters.AddWithValue("@category_description", CategoryDescription);



            cmd.Parameters.AddWithValue("@category_name", categoryname);


            cmd.Parameters.AddWithValue("@Query", 1);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


            return Json("Data Inserted!!");
            //(, , , )





        }
        [HttpPost]

        public JsonResult AjaxDeleteRow(int category_id)
        {


            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Routine", con);
            cmd.CommandType = CommandType.StoredProcedure;




            cmd.Parameters.AddWithValue("@category_id", category_id);





            cmd.Parameters.AddWithValue("@Query", 6);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


            return Json("Data Deleted!!");


        }

        [HttpPost]

        public JsonResult AjaxUpdate(String categoryname, String CategoryDescription, int categoryId)
        {


            Routine model = new Routine();


            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Routine", con);
            cmd.CommandType = CommandType.StoredProcedure;



            cmd.Parameters.AddWithValue("@School_Group_Code", Session["School_Group_Code"]);

            cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);
            cmd.Parameters.AddWithValue("@category_description", CategoryDescription);
            cmd.Parameters.AddWithValue("@category_id", categoryId);
            cmd.Parameters.AddWithValue("@category_name", categoryname);
            cmd.Parameters.AddWithValue("@Query", 5);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return Json("Data Updated!!");
            //(, , , )


        }




        public ActionResult RoomMaster(int id)
        {


            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {

                Routine model = new Routine();
                model.RoomCategory = PopulateDropDown("Select Category_Name from School_RoomCategory where School_Code='" + Session["School_Code"] + "' And School_Group_Code='" + Session["School_Group_Code"] + "'", "Category_Name", "Category_Name");

                List<Routine> Templist = new List<Routine>();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
                SqlCommand cmd = new SqlCommand("Routine", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@School_Group_Code", Session["School_Group_Code"]);

                cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);
                DataTable dt = new DataTable();

                cmd.Parameters.AddWithValue("@Query", 7);

                SqlDataAdapter sd = new SqlDataAdapter(cmd);


                con.Open();
                sd.Fill(dt);
                con.Close();
                ////for view 
                ///


                foreach (DataRow dr in dt.Rows)
                {
                    Templist.Add(new Routine
                    {

                        RoomName = Convert.ToString(dr["Room_Name"]),
                        RoomNo = Convert.ToString(dr["Room_no"]),
                        Room = Convert.ToString(dr["Room_Category"]),
                        Occupied = Convert.ToString(dr["Occupied"]),
                        id = Convert.ToInt32(dr["Room_Id"])

                    });




                }

                model.Templist = Templist;


                if (id != 0)
                {
                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
                    cmd = new SqlCommand("Routine", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@School_Group_Code", Session["School_Group_Code"]);

                    cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);


                    cmd.Parameters.AddWithValue("@id", id);
                    dt = new DataTable();

                    cmd.Parameters.AddWithValue("@Query", 10);

                    sd = new SqlDataAdapter(cmd);


                    con.Open();
                    sd.Fill(dt);
                    con.Close();
                    foreach (DataRow dr in dt.Rows)
                    {

                        model.id = Convert.ToInt32(dr["Room_Id"]);
                        model.RoomName = Convert.ToString(dr["Room_Name"]);
                        model.RoomNo = Convert.ToString(dr["Room_no"]);
                        model.Room = Convert.ToString(dr["Room_Category"]);
                        model.Occupied = Convert.ToString(dr["Occupied"]);
                        model.Floor = Convert.ToInt32(dr["Floor"]);





                    }



                }



                return View(model);

            }//endif



        }

        [HttpPost]

        public ActionResult RoomMaster(FormCollection fc, int id)
        {




            Routine model = new Routine();


            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);



            SqlCommand cmd = new SqlCommand("Routine", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);

            cmd.Parameters.AddWithValue("@School_Group_Code", Session["School_Group_Code"]);

            cmd.Parameters.AddWithValue("@RoomName", fc["RoomName"]);
            cmd.Parameters.AddWithValue("@RoomNo", fc["RoomNo"]);
            cmd.Parameters.AddWithValue("@Floor", fc["Floor"]);
            cmd.Parameters.AddWithValue("@RoomCategory", fc["Room"]);
            cmd.Parameters.AddWithValue("@Occupied", fc["Occupied"]);



            if (id == 0)
            {
                cmd.Parameters.AddWithValue("@Query", 8);
            }
            else
            {
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@Query", 9);

            }

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            return RoomMaster(id);
        }

        public JsonResult AjaxCheckRoomName(String RoomName)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Routine", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@School_Group_Code", Session["School_Group_Code"]);

            cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);

            cmd.Parameters.AddWithValue("@RoomName", RoomName);


            DataTable dt = new DataTable();

            cmd.Parameters.AddWithValue("@Query", 11);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);


            con.Open();
            sd.Fill(dt);
            con.Close();
            ////for view 
            ///
            int cnt = 0;

            foreach (DataRow dr in dt.Rows)
            {


                cnt = Convert.ToInt32(dr["count"]);


            }
            if (cnt == 0)
                return Json("");

            else
                return Json("Room Name already exists!!");
        }


        [HttpPost]



        public JsonResult AjaxCheckRoomNumber(int RoomNumber)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Routine", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@School_Group_Code", Session["School_Group_Code"]);

            cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);

            cmd.Parameters.AddWithValue("@RoomNo", RoomNumber);


            DataTable dt = new DataTable();

            cmd.Parameters.AddWithValue("@Query", 12);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);


            con.Open();
            sd.Fill(dt);
            con.Close();
            ////for view 
            ///
            int cnt = 0;

            foreach (DataRow dr in dt.Rows)
            {


                cnt = Convert.ToInt32(dr["count"]);


            }
            if (cnt == 0)
                return Json("");

            else
                return Json("Room Number already exists!!");
        }

        [HttpPost]
        public JsonResult AjaxDeleteRoom(int RoomId)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Routine", con);
            cmd.CommandType = CommandType.StoredProcedure;




            cmd.Parameters.AddWithValue("@id", RoomId);





            cmd.Parameters.AddWithValue("@Query", 13);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


            return Json("Data Deleted!!");



        }
        //////////////holidays start//////////

        ///Holiday Controller


        [HttpGet]
        public ActionResult CreateHoliday()
        {

            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                //Routine model = new Routine();


                //model.Class_Name = PopulateDropDown("SELECT Class_Id, Class_Name FROM Class_Master where School_Code='" + Session["School_Code"] + "'", "Class_Name", "Class_Id");

                //return View(model);


                Routine model = new Routine();



                return View(model);

            }



        }
        [HttpPost]
        public JsonResult Ajaxcheckholiday()
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);

            List<Routine> Templist = new List<Routine>();


            Routine model = new Routine();

            SqlCommand cmd = new SqlCommand("Routine", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);
            cmd.Parameters.AddWithValue("@School_Group_Code", Session["School_Group_Code"]);
            cmd.Parameters.AddWithValue("@Query", 36);


            DataTable dt = new DataTable();



            SqlDataAdapter sd = new SqlDataAdapter(cmd);


            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Templist.Add(new Routine
                {
                    Event_ID = Convert.ToInt32(dr["Event_ID"]),


                    StartDate = (Convert.ToString(dr["Start_Date"])).Substring(0, 10),
                    EndDate = Convert.ToString(dr["End_Date"]).Substring(0, 10),
                    Subject = Convert.ToString(dr["Subject"]),
                    Description = Convert.ToString(dr["Description"]),
                    full_day = Convert.ToString(dr["IS_Full_Day"]),

                    EventType = Convert.ToString(dr["Event_Type"]),
                });




            }

            model.TempHoliday = Templist;



            return Json(model);

        }

        [HttpPost]

        public JsonResult AjaxDeleteHoliday(int Event_ID)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Routine", con);
            cmd.CommandType = CommandType.StoredProcedure;



            cmd.Parameters.AddWithValue("@Event_ID", Event_ID);

            cmd.Parameters.AddWithValue("@Query", 39);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


            return Json("Data Deleted!!");
        }


        [HttpPost]

        public JsonResult AjaxEditholiday(int Event_ID, String fullday, String holidayname, String htype, String SDate, String EDate, String description)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Routine", con);
            cmd.CommandType = CommandType.StoredProcedure;



            cmd.Parameters.AddWithValue("@Event_ID", Event_ID);
            cmd.Parameters.AddWithValue("@fullday", fullday);
            cmd.Parameters.AddWithValue("@holidayname", holidayname);
            cmd.Parameters.AddWithValue("@htype", htype);
            cmd.Parameters.AddWithValue("@SDate", SDate);
            cmd.Parameters.AddWithValue("@EDate", EDate);
            //cmd.Parameters.AddWithValue("@daytype", daytype);
            // cmd.Parameters.AddWithValue("@themecolor", themecolor);
            cmd.Parameters.AddWithValue("@description", description);



            cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);
            cmd.Parameters.AddWithValue("@School_Group_Code", Session["School_Group_Code"]);



            cmd.Parameters.AddWithValue("@Query", 38);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            return Json("Data Updated Successfully");
        }

        [HttpPost]
        public JsonResult Ajaxaddholiday(String fullday, String holidayname, String htype, String SDate, String EDate, String daytype, String themecolor, String description)
        {



            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Routine", con);
            cmd.CommandType = CommandType.StoredProcedure;




            cmd.Parameters.AddWithValue("@fullday", fullday);
            cmd.Parameters.AddWithValue("@holidayname", holidayname);
            cmd.Parameters.AddWithValue("@htype", htype);
            cmd.Parameters.AddWithValue("@SDate", SDate);
            cmd.Parameters.AddWithValue("@EDate", EDate);
            cmd.Parameters.AddWithValue("@daytype", daytype);
            cmd.Parameters.AddWithValue("@themecolor", themecolor);
            cmd.Parameters.AddWithValue("@description", description);



            cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);
            cmd.Parameters.AddWithValue("@School_Group_Code", Session["School_Group_Code"]);



            cmd.Parameters.AddWithValue("@Query", 37);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return Json("Data Inserted Successfully");
        }

        [HttpPost]

        public JsonResult AjaxgetList()
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);

            List<Routine> Templist = new List<Routine>();


            Routine model = new Routine();

            SqlCommand cmd = new SqlCommand("Routine", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);
            cmd.Parameters.AddWithValue("@School_Group_Code", Session["School_Group_Code"]);
            cmd.Parameters.AddWithValue("@Query", 35);


            DataTable dt = new DataTable();



            SqlDataAdapter sd = new SqlDataAdapter(cmd);


            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Templist.Add(new Routine
                {
                    Event_ID = Convert.ToInt32(dr["Event_ID"]),
                    StartDate = (Convert.ToString(dr["Start_Date"])).Substring(0, 10),
                    EndDate = Convert.ToString(dr["End_Date"]).Substring(0, 10),
                    Subject = Convert.ToString(dr["Subject"]),
                    Description = Convert.ToString(dr["Description"]),
                    full_day = Convert.ToString(dr["IS_Full_Day"]),

                    EventType = Convert.ToString(dr["Event_Type"]),
                });




            }

            model.TempHoliday = Templist;



            return Json(model);






        }

        ///////holiday end///////////////////////

        ////////////// Controller for creating period

        //////creating period
        ///
        public ActionResult PeriodMaster()
        {
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                Routine model = new Routine();


                model.Class_Name = PopulateDropDown("SELECT Class_Id, Class_Name FROM Class_Master where School_Code='" + Session["School_Code"] + "'", "Class_Name", "Class_Id");

                return View(model);

            }
        }


        public JsonResult AjaxCreateForm(int cname)
        {

            Routine model = new Routine();
            String Stime = null;
            List<Routine> TemplistChild = new List<Routine>();

            List<Routine> TemplistParent = new List<Routine>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Routine", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@School_Group_Code", Session["School_Group_Code"]);

            cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);

            cmd.Parameters.AddWithValue("@id", cname);


            DataTable dt = new DataTable();

            cmd.Parameters.AddWithValue("@Query", 26);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);


            con.Open();
            sd.Fill(dt);
            con.Close();
            ////for view 
            ///
            int cnt = 0;

            foreach (DataRow dr in dt.Rows)
            {


                cnt = Convert.ToInt32(dr["cnt"] == DBNull.Value ? 0 : dr["cnt"]);


            }
            if (cnt == 0)
            {

                ///Temporary table empty. Have to check in parent table
                ///


                con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
                cmd = new SqlCommand("Routine", con);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@School_Group_Code", Session["School_Group_Code"]);

                cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);

                cmd.Parameters.AddWithValue("@id", cname);


                dt = new DataTable();

                cmd.Parameters.AddWithValue("@Query", 27);

                sd = new SqlDataAdapter(cmd);


                con.Open();
                sd.Fill(dt);
                con.Close();
                ////for view 
                ///
                int count = 0;

                foreach (DataRow dr in dt.Rows)
                {


                    count = Convert.ToInt32(dr["cnt"] == DBNull.Value ? 0 : dr["cnt"]);


                }
                if (count == 0)
                {
                    //master table empty
                    ///have to check class master for start time
                    ///
                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
                    cmd = new SqlCommand("Routine", con);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@School_Group_Code", Session["School_Group_Code"]);

                    cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);

                    cmd.Parameters.AddWithValue("@id", cname);


                    dt = new DataTable();

                    cmd.Parameters.AddWithValue("@Query", 30);

                    sd = new SqlDataAdapter(cmd);


                    con.Open();
                    sd.Fill(dt);
                    con.Close();
                    ////for view 
                    ///
                    //DateTime startTime;

                    foreach (DataRow dr in dt.Rows)
                    {


                        Stime = Convert.ToString(dr["STime"]);

                        model.Stime = Stime;
                    }

                }


                else
                {
                    ///templist has to be fed with data from master table



                    con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
                    cmd = new SqlCommand("Routine", con);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.AddWithValue("@School_Group_Code", Session["School_Group_Code"]);

                    cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);

                    cmd.Parameters.AddWithValue("@id", cname);


                    dt = new DataTable();

                    cmd.Parameters.AddWithValue("@Query", 28);

                    sd = new SqlDataAdapter(cmd);


                    con.Open();
                    sd.Fill(dt);
                    con.Close();
                    foreach (DataRow dr in dt.Rows)
                    {
                        TemplistParent.Add(new Routine
                        {
                            starttime = Convert.ToString(dr["STime"]),
                            endtime = Convert.ToString(dr["ETime"]),
                            //for period

                            Duration = Convert.ToInt32(dr["Duration"]),

                            period_name = Convert.ToString(dr["Period_Name"]),

                            period_type = Convert.ToString(dr["Period_Type"]),
                            period_order = Convert.ToInt32(dr["Order_period"])


                        });

                    }

                    model.TemplistParent = TemplistParent;
                }

            }

            else
            {

                ///templist has to be fed with data from child table
                ///


                con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
                cmd = new SqlCommand("Routine", con);
                cmd.CommandType = CommandType.StoredProcedure;


                cmd.Parameters.AddWithValue("@School_Group_Code", Session["School_Group_Code"]);

                cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);

                cmd.Parameters.AddWithValue("@id", cname);


                dt = new DataTable();

                cmd.Parameters.AddWithValue("@Query", 29);

                sd = new SqlDataAdapter(cmd);


                con.Open();
                sd.Fill(dt);
                con.Close();





                foreach (DataRow dr in dt.Rows)
                {
                    TemplistChild.Add(new Routine
                    {
                        starttime = Convert.ToString(dr["STime"]),
                        endtime = Convert.ToString(dr["ETime"]),
                        //for period

                        Duration = Convert.ToInt32(dr["Duration"]),

                        period_name = Convert.ToString(dr["Period_Name"]),

                        period_type = Convert.ToString(dr["Period_Type"]),
                        period_order = Convert.ToInt32(dr["Order_period"])


                    });

                }

                model.TemplistChild = TemplistChild;

            }

            return Json(model);
        }


        public JsonResult AjaxSavePeriodChild(String pname, int period, String ST, String ptype, int cname, String ET, int duration)
        {


            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Routine", con);
            cmd.CommandType = CommandType.StoredProcedure;



            //String pname, String period, String ST, String ptype,int cname, String ET,int duration


            cmd.Parameters.AddWithValue("@pname", pname);
            cmd.Parameters.AddWithValue("@period", period);
            cmd.Parameters.AddWithValue("@ptype", ptype);
            cmd.Parameters.AddWithValue("@cname", cname);
            cmd.Parameters.AddWithValue("@duration", duration);
            cmd.Parameters.AddWithValue("@Stime", Convert.ToDateTime(ST));
            cmd.Parameters.AddWithValue("@Etime", Convert.ToDateTime(ET));

            cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);
            cmd.Parameters.AddWithValue("@School_Group_Code", Session["School_Group_Code"]);



            cmd.Parameters.AddWithValue("@Query", 31);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


            return Json("Data Inserted!!");
        }

        public JsonResult AjaxDeleteAllPeriod(int cname)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Routine", con);
            cmd.CommandType = CommandType.StoredProcedure;



            //String pname, String period, String ST, String ptype,int cname, String ET,int duration



            cmd.Parameters.AddWithValue("@cname", cname);


            cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);
            cmd.Parameters.AddWithValue("@School_Group_Code", Session["School_Group_Code"]);



            cmd.Parameters.AddWithValue("@Query", 32);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();




            return Json("All Records Deleted!!");
        }


        [HttpPost]

        public JsonResult AjaxDeleteAllMaster(int cname)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Routine", con);
            cmd.CommandType = CommandType.StoredProcedure;



            //String pname, String period, String ST, String ptype,int cname, String ET,int duration



            cmd.Parameters.AddWithValue("@cname", cname);


            cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);
            cmd.Parameters.AddWithValue("@School_Group_Code", Session["School_Group_Code"]);



            cmd.Parameters.AddWithValue("@Query", 34);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();




            return Json("All Records Deleted!!");
        }


        public JsonResult AjaxSaveAllPeriod(int cname)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Routine", con);
            cmd.CommandType = CommandType.StoredProcedure;



            //String pname, String period, String ST, String ptype,int cname, String ET,int duration



            cmd.Parameters.AddWithValue("@cname", cname);


            cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);
            cmd.Parameters.AddWithValue("@School_Group_Code", Session["School_Group_Code"]);



            cmd.Parameters.AddWithValue("@Query", 33);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();




            return Json("All Records has been saved!!");
        }
        /////////////////End Period///////////////////


        [HttpGet]
        public ActionResult Routine()
        {

            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                Routine model = new Routine();
                model.ClassList = PopulateDropDown("SELECT Class_Id, Class_Name FROM Class_Master where School_Code='" + Session["School_Code"] + "'", "Class_Name", "Class_Name");


                model.TeacherList = PopulateDropDown("select SED.Employee_Name Employee_Name, SED.Employee_id Employee_id from School_Employee_Details as SED ,School_EmpType_Master AS SEM WHERE SED.EmpType_Id = SEM.Type_Id AND SEM.EmpType_Name like '%Teacher%' And SED.School_Code='" + Session["School_Code"] + "'", "Employee_Name", "Employee_Name");
                model.SubjectList = PopulateDropDown("select Distinct Subject_id, Subject_Name from School_Subject_Master where School_Code='" + Session["School_Code"] + "'", "Subject_Name", "Subject_Name");
                //model.Class_ID = PopulateDropDown("select Distinct Class_Id,Class_Name from Class_Master", "Class_Name", "Class_Id");
                model.SectionList = PopulateDropDown("select Distinct Section_Name,Section_Id from School_Section_Master where School_Code='" + Session["School_Code"] + "'", "Section_Name", "Section_Name");

                model.DayList = PopulateDropDown("SELECT Day_Id,Day_Name FROM Day", "Day_Name", "Day_Name");
                model.PeriodList = PopulateDropDown("SELECT distinct Period_Name FROM Period_Master where School_Code='" + Session["School_Code"] + "'", "Period_Name", "Period_Name");

                model.RoomList = PopulateRoom("SELECT  Room_no, Occupied,Room_Category FROM School_Room_Master where School_Code='" + Session["School_Code"] + "'", "Room_no", "Room_Category", "Occupied", "Room_no");



                return View(model);
            }


        }

        private static List<SelectListItem> PopulateRoom(string query, string textColumn1, string textColumn2, string textColumn3, string valueColumn)
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
                                Text = sdr[textColumn2].ToString() + "(" + sdr[textColumn1].ToString() + ")" + "->" + sdr[textColumn3].ToString(),
                                Value = sdr[valueColumn].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }
            return items;
        }


        [HttpPost]
        public ActionResult RoutineAdd(FormCollection fc)
        {

            Routine model = new Routine();


            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Routine", con);
            cmd.CommandType = CommandType.StoredProcedure;

            //@class,@section,@teacher,@subject,@room,@day,@period_r


            cmd.Parameters.AddWithValue("@School_Group_Code", Session["School_Group_Code"]);

            cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);

            cmd.Parameters.AddWithValue("@class", fc["Class"]);

            cmd.Parameters.AddWithValue("@section", fc["SectionId"]);

            cmd.Parameters.AddWithValue("@teacher", fc["Teacher"]);

            cmd.Parameters.AddWithValue("@subject", fc["SubjectId"]);
            cmd.Parameters.AddWithValue("@room", fc["RoomId"]);

            cmd.Parameters.AddWithValue("@day", fc["DayId"]);



            cmd.Parameters.AddWithValue("@period_r", fc["PeriodId"]);



            cmd.Parameters.AddWithValue("@Query", 40);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            TempData["msg"] = "Data Inserted Successfully!";
            return this.RedirectToAction("Routine", "SchoolAdmin");

        }


        public JsonResult AjaxCreatePeriod(String clsv, String scv)
        {

            Routine model = new Routine();


            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Routine", con);
            cmd.CommandType = CommandType.StoredProcedure;


            List<Routine> Templist = new List<Routine>();
            //@class,@section,@teacher,@subject,@room,@day,@period_r


            cmd.Parameters.AddWithValue("@School_Group_Code", Session["School_Group_Code"]);

            cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);

            cmd.Parameters.AddWithValue("@class", clsv);

            cmd.Parameters.AddWithValue("@section", scv);


            cmd.Parameters.AddWithValue("@Query", 42);


            SqlDataAdapter sd = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Templist.Add(new Routine(Convert.ToString(dr["Period"])));

                // String DayName, String PeriodName,String Teacher, String RoomNo

            }


            model.TempRoutine = Templist;


            return Json(model);
        }

        public JsonResult AjaxCreateRoutine(String clsv, String scv)
        {

            Routine model = new Routine();


            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Routine", con);
            cmd.CommandType = CommandType.StoredProcedure;


            List<Routine> Templist = new List<Routine>();
            //@class,@section,@teacher,@subject,@room,@day,@period_r


            cmd.Parameters.AddWithValue("@School_Group_Code", Session["School_Group_Code"]);

            cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);

            cmd.Parameters.AddWithValue("@class", clsv);

            cmd.Parameters.AddWithValue("@section", scv);


            cmd.Parameters.AddWithValue("@Query", 41);


            SqlDataAdapter sd = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Templist.Add(new Routine(Convert.ToInt32(dr["Routine_Id"]), Convert.ToString(dr["Day"]), Convert.ToString(dr["Subject"]), Convert.ToString(dr["Teacher"]), Convert.ToString(dr["Room"])));

                // String DayName, String PeriodName,String Teacher, String RoomNo

            }


            model.TempRoutine = Templist;


            return Json(model);
        }

        public JsonResult AjaxDeletePeriod(String clsv, String scv)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Routine", con);
            cmd.CommandType = CommandType.StoredProcedure;





            cmd.Parameters.AddWithValue("@School_Group_Code", Session["School_Group_Code"]);

            cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);

            cmd.Parameters.AddWithValue("@class", clsv);

            cmd.Parameters.AddWithValue("@section", scv);


            cmd.Parameters.AddWithValue("@Query", 43);


            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            return Json("Data has been Deleted!!");

        }

        public JsonResult AjaxClearPeriod(String clsv, String scv)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Routine", con);
            cmd.CommandType = CommandType.StoredProcedure;





            cmd.Parameters.AddWithValue("@School_Group_Code", Session["School_Group_Code"]);

            cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);

            cmd.Parameters.AddWithValue("@class", clsv);

            cmd.Parameters.AddWithValue("@section", scv);


            cmd.Parameters.AddWithValue("@Query", 44);


            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            return Json("All Data cleared!!");
        }

        public JsonResult AjaxUpdateRoutine(int RNo, String tname, String Sub, int Routine_Id)
        {


            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Routine", con);
            cmd.CommandType = CommandType.StoredProcedure;





            cmd.Parameters.AddWithValue("@School_Group_Code", Session["School_Group_Code"]);

            cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);

            cmd.Parameters.AddWithValue("@RNo", RNo);

            cmd.Parameters.AddWithValue("@subject", Sub);
            cmd.Parameters.AddWithValue("@Routine_Id", Routine_Id);

            cmd.Parameters.AddWithValue("@teacher", tname);

            cmd.Parameters.AddWithValue("@Query", 45);


            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            return Json("Data Updated!!");
        }

        public JsonResult AjaxHolidayList()
        {
            Routine model = new Routine();
            DateTime StartDate = Convert.ToDateTime("02/02/1900"), EndDate = Convert.ToDateTime("02/02/1900");

            String NoHolidays = "";

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Routine", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@School_Group_Code", Session["School_Group_Code"]);

            cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);

            cmd.Parameters.AddWithValue("@Query", 46);


            SqlDataAdapter sd = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                //Templist.Add(new Routine(Convert.ToInt32(dr["Routine_Id"]), Convert.ToString(dr["Day"]), Convert.ToString(dr["Subject"]), Convert.ToString(dr["Teacher"]), Convert.ToString(dr["Room"])));

                // String DayName, String PeriodName,String Teacher, String RoomNo



                StartDate = Convert.ToDateTime(dr["Start_Date"]);

                EndDate = Convert.ToDateTime(dr["End_Date"]);


            }
            for (int i = 1; ((EndDate - StartDate).TotalDays) >= 0; i++)
            {




                DateTime sdt = StartDate;
                DayOfWeek dow = sdt.DayOfWeek; //enum
                string str = dow.ToString(); //string
                NoHolidays += str + ", ";
                StartDate = StartDate.AddDays(1);

            }

            model.holidays = NoHolidays;
            return Json(model);
        }


        public ActionResult CreateClass()
        {

            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                Routine model = new Routine();

                return View(model);

            }
        }

        public JsonResult Ajaxaddclass(String classname, String Stime, String Etime)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Routine", con);
            cmd.CommandType = CommandType.StoredProcedure;



            cmd.Parameters.AddWithValue("@School_Group_Code", Session["School_Group_Code"]);

            cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);

            cmd.Parameters.AddWithValue("@class_name", classname);
            cmd.Parameters.AddWithValue("@Stime", Convert.ToDateTime(Stime));



            cmd.Parameters.AddWithValue("@Etime", Convert.ToDateTime(Etime));


            cmd.Parameters.AddWithValue("@Query", 20);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();




            return Json("Data inserted!!");


        }
        public JsonResult AjaxclassName(String cname)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Routine", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@School_Group_Code", Session["School_Group_Code"]);

            cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);

            cmd.Parameters.AddWithValue("@class_name", cname);


            DataTable dt = new DataTable();

            cmd.Parameters.AddWithValue("@Query", 21);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);


            con.Open();
            sd.Fill(dt);
            con.Close();
            ////for view 
            ///
            int cnt = 0;

            foreach (DataRow dr in dt.Rows)
            {


                cnt = Convert.ToInt32(dr["cnt"]);


            }
            if (cnt == 0)
                return Json("");

            else
                return Json("class  already exists!!");



        }
        public JsonResult AjaxcreateClassTable()
        {
            Routine model = new Routine();


            List<Routine> Templist = new List<Routine>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Routine", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@School_Group_Code", Session["School_Group_Code"]);

            cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);


            DataTable dt = new DataTable();

            cmd.Parameters.AddWithValue("@Query", 22);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);


            con.Open();
            sd.Fill(dt);
            con.Close();
            ////for view 
            ///


            foreach (DataRow dr in dt.Rows)
            {
                Templist.Add(new Routine
                {
                    Stime = Convert.ToString(dr["STime"]),
                    Etime = Convert.ToString(dr["ETime"]),
                    ClassName = Convert.ToString(dr["Class_Name"]),
                    id = Convert.ToInt32(dr["Class_Id"])

                });




            }

            model.Templist = Templist;



            return Json(model);
        }

        public JsonResult AjaxDeleteClass(int Class_Id)
        {



            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Routine", con);
            cmd.CommandType = CommandType.StoredProcedure;




            cmd.Parameters.AddWithValue("@Class_id", Class_Id);





            cmd.Parameters.AddWithValue("@Query", 23);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


            return Json("Data Deleted!!");


        }

        public JsonResult AjaxUpdateClass(int Class_Id, String Class_Name, String STime, String ETime)
        {



            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Routine", con);
            cmd.CommandType = CommandType.StoredProcedure;




            cmd.Parameters.AddWithValue("@Class_id", Class_Id);
            cmd.Parameters.AddWithValue("@class_name", Class_Name);
            cmd.Parameters.AddWithValue("@Stime", STime);
            cmd.Parameters.AddWithValue("@Etime", ETime);




            cmd.Parameters.AddWithValue("@Query", 24);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();


            return Json("Data Updated!!");



        }

        [HttpGet]
        public ActionResult View_Student_Attendance()
        {
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                StudentAttendance model = new StudentAttendance();
                //  model.PeriodList = PopulateDropDown("SELECT Period_Id, Period_Name FROM Period_Master  WHERE School_Code='" + Session["School_Code"] + "'", "Period_Name", "Period_Id");

                //model.ExamType_Name = PopulateDropDown("SELECT Exam_Term_id, Exam_Term_Name FROM School_Exam_Term_Master", "Exam_Term_Name", "Exam_Term_id");
                model.Class_Name = PopulateDropDown("SELECT Class_Id, Class_Name FROM Class_Master  WHERE School_Code='" + Session["School_Code"] + "'", "Class_Name", "Class_Id");
                model.Year_Name = PopulateDropDown("SELECT Year, Year_Name FROM Year", "Year_Name", "Year");

                // model.Section_Name = PopulateDropDown("SELECT Section_Name, Section_Name FROM School_Section_Master WHERE School_Code='" + Session["School_Code"] + "'", "Section_Name", "Section_Name");

                return View(model);
            }
        }

        [HttpPost]
        public JsonResult AjaxMethod_StudentAttendance(String Session_year, int Class_Id, int Section_Id, String Period_Date)
        {
            String School_Code = Session["School_Code"].ToString();

            List<StudentAllList> StuentList = new List<StudentAllList>();
            String con = ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            //try
            //{
            // string sqlquery = "SELECT SA.*, Isnull(SSD.first_name, '') + ' ' + Isnull(SSD.middle_name, '') + ' ' + Isnull(SSD.last_name, '') AS FullName FROM School_Student_Details AS SSD,Student_Attendance AS SA WHERE SA.School_Code=SSD.School_Code AND SSD.AdmissionClass_Id=SA.Class_Id AND SSD.Section_Id=SA.Section_Id AND SSD.Student_Id=SA.Student_Id AND SA.School_Code = '"+ School_Code + "' AND  SA.Class_Id = '"+ Class_Id + "' AND  SA.Period_Date='"+ Period_Date + "'  AND  SA.Session_Year='"+ Session_year + "' ORDER BY (SA.Student_Id)";
            //string sqlquery = "SELECT  FullName,Student_Id, [1] As First_Period,[2] AS Second_Period,[3] AS Third_Period,[4] AS Fourth_Period ,[5] AS Fifth_Period,[6] AS Sixth_Period ,[7] AS Seven_Period  FROM (SELECT  Isnull(SSD.first_name, '') + ' ' + Isnull(SSD.middle_name, '') + ' ' + Isnull(SSD.last_name, '') AS FullName, SA.Student_Id, SA.[Period_Id], SA.Presence_Status FROM School_Student_Details AS SSD, Student_Attendance AS SA WHERE SA.School_Code = SSD.School_Code AND SSD.AdmissionClass_Id = SA.Class_Id AND SSD.Section_Id = SA.Section_Id AND SSD.Student_Id = SA.Student_Id AND SA.School_Code = '" + School_Code + "' AND  SA.Class_Id = '" + Class_Id + "' AND  SA.Period_Date='" + Period_Date + "'  AND  SA.Session_Year='" + Session_year + "') Tab1 PIVOT (MAX(Presence_Status) FOR[Period_Id] IN([1],[2],[3],[4],[5],[6],[7]) ) AS Tab2 ORDER BY Tab2.Student_Id";
            string sqlquery = "SELECT  FullName,Student_Id, [First] As First_Period,[Second] AS Second_Period,[Third] AS Third_Period,[Fourth] AS Fourth_Period ,[Fifth] AS Fifth_Period,[Sixth] AS Sixth_Period ,[Seventh] AS Seventh_Period ,[Eighth] AS Eighth_Period ,[Nineth] AS Nineth_Period ,[Tenth] AS Tenth_Period   FROM (SELECT  Isnull(SSD.first_name, '') + ' ' + Isnull(SSD.middle_name, '') + ' ' + Isnull(SSD.last_name, '') AS FullName, SA.Student_Id, SA.[Period_Name], SA.Presence_Status FROM School_Student_Details AS SSD, Student_Attendance AS SA WHERE SA.School_Code = SSD.School_Code AND SSD.AdmissionClass_Id = SA.Class_Id AND SSD.Section_Id = SA.Section_Id AND SSD.Student_Id = SA.Student_Id AND SA.School_Code = '" + School_Code + "' AND  SA.Class_Id = '" + Class_Id + "' AND SSD.Section_Id ='"+Section_Id+"' AND  SA.Period_Date='" + Period_Date + "'  AND  SA.Session_Year='" + Session_year + "') Tab1 PIVOT (MAX(Presence_Status) FOR[Period_Name] IN([First],[Second],[Third],[Fourth],[Fifth],[Sixth],[Seventh],[Eighth],[Nineth],[Tenth]) ) AS Tab2 ORDER BY Tab2.Student_Id";

            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon);

            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = sqlcom;

            DataTable dt = new DataTable();

            //  sqlcon.Open();
            da.Fill(dt);

            sqlcon.Close();


            foreach (DataRow sdr in dt.Rows)
            {
                StuentList.Add(
                    new StudentAllList
                    {

                        Student_Id = String.IsNullOrEmpty(sdr["Student_Id"].ToString()) ? '0' : Convert.ToInt32(sdr["Student_Id"]),
                        // Parent_Id = String.IsNullOrEmpty(sdr["Parent_Id"].ToString()) ? '0' : Convert.ToInt32(sdr["Parent_Id"]),
                        //School_Code = String.IsNullOrEmpty(sdr["School_Code"].ToString()) ? null : sdr["School_Code"].ToString(),
                        FullName = String.IsNullOrEmpty(sdr["FullName"].ToString()) ? null : sdr["FullName"].ToString(),
                        //Present_Status = String.IsNullOrEmpty(sdr["Presence_Status"].ToString()) ? null : sdr["Presence_Status"].ToString(),
                        //Period_Id = String.IsNullOrEmpty(sdr["Period_Id"].ToString()) ? '0' : Convert.ToInt32(sdr["Period_Id"]),
                        // Class_Name = String.IsNullOrEmpty(sdr["Class_Name"].ToString()) ? null : sdr["Class_Name"].ToString(),
                        //   Section_Id = String.IsNullOrEmpty(sdr["Section_Id"].ToString()) ? '0' : Convert.ToInt32(sdr["Section_Id"]),
                        // Section_Name = String.IsNullOrEmpty(sdr["Section_Name"].ToString()) ? null : sdr["Section_Name"].ToString(),
                        First_Period = String.IsNullOrEmpty(sdr["First_Period"].ToString()) ? "NA" : sdr["First_Period"].ToString(),
                        Second_Period = String.IsNullOrEmpty(sdr["Second_Period"].ToString()) ? "NA" : sdr["Second_Period"].ToString(),
                        Third_Period = String.IsNullOrEmpty(sdr["Third_Period"].ToString()) ? "NA" : sdr["Third_Period"].ToString(),
                        Fourth_Period = String.IsNullOrEmpty(sdr["Fourth_Period"].ToString()) ? "NA" : sdr["Fourth_Period"].ToString(),
                        Fifth_Period = String.IsNullOrEmpty(sdr["Fifth_Period"].ToString()) ? "NA" : sdr["Fifth_Period"].ToString(),
                        Sixth_Period = String.IsNullOrEmpty(sdr["Sixth_Period"].ToString()) ? "NA" : sdr["Sixth_Period"].ToString(),
                        Seventh_Period = String.IsNullOrEmpty(sdr["Seventh_Period"].ToString()) ? "NA" : sdr["Seventh_Period"].ToString(),
                        Eighth_Period = String.IsNullOrEmpty(sdr["Eighth_Period"].ToString()) ? "NA" : sdr["Eighth_Period"].ToString(),
                        Nineth_Period = String.IsNullOrEmpty(sdr["Nineth_Period"].ToString()) ? "NA" : sdr["Nineth_Period"].ToString(),
                        Tenth_Period = String.IsNullOrEmpty(sdr["Tenth_Period"].ToString()) ? "NA" : sdr["Tenth_Period"].ToString()







                    });
            }
            //}
            //catch (Exception ex)
            //{
            //    ViewBag.Error = ex.Message;

            //}
            return Json(StuentList, JsonRequestBehavior.AllowGet);
        }

        

        [HttpGet]
        public ActionResult View_AStudent_Attendance()
        {
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                StudentAttendance model = new StudentAttendance();
                //  model.PeriodList = PopulateDropDown("SELECT Period_Id, Period_Name FROM Period_Master  WHERE School_Code='" + Session["School_Code"] + "'", "Period_Name", "Period_Id");

                //model.ExamType_Name = PopulateDropDown("SELECT Exam_Term_id, Exam_Term_Name FROM School_Exam_Term_Master", "Exam_Term_Name", "Exam_Term_id");
                model.Class_Name = PopulateDropDown("SELECT Class_Id, Class_Name FROM Class_Master  WHERE School_Code='" + Session["School_Code"] + "'", "Class_Name", "Class_Id");
                model.Year_Name = PopulateDropDown("SELECT Year, Year_Name FROM Year", "Year_Name", "Year");

                // model.Section_Name = PopulateDropDown("SELECT Section_Name, Section_Name FROM School_Section_Master WHERE School_Code='" + Session["School_Code"] + "'", "Section_Name", "Section_Name");

                return View(model);
            }
        }


        [HttpPost]
        public JsonResult AjaxMethod_StudentList(string type, int value, String Section_Id)
        {
            StudentAttendance model = new StudentAttendance();
            // List<StudentAllList> StuentList = new List<StudentAllList>();

            switch (type)
            {
                case "Class_Id":

                    model.StudentList = PopulateDropDown("SELECT  Student_Id,Isnull(first_name, '') + ' ' + Isnull(middle_name, '') + ' ' + Isnull(last_name, '') AS FullName FROM School_Student_Details WHERE School_Code='" + Session["School_Code"] + "' AND AdmissionClass_Id='" + value + "'  ",  "FullName","Student_Id");

                    break;

            }
            return Json(model);
        }

        [HttpPost]
        public JsonResult AjaxMethod_AStudentAttendance(String Session_Year, int Class_Id,String Start_Date, String End_Date,int Student_Id)
        {
            String School_Code = Session["School_Code"].ToString();

            List<StudentAllList> StuentList = new List<StudentAllList>();
            String con = ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            //try
            //{
            // string sqlquery = "SELECT SA.*, Isnull(SSD.first_name, '') + ' ' + Isnull(SSD.middle_name, '') + ' ' + Isnull(SSD.last_name, '') AS FullName FROM School_Student_Details AS SSD,Student_Attendance AS SA WHERE SA.School_Code=SSD.School_Code AND SSD.AdmissionClass_Id=SA.Class_Id AND SSD.Section_Id=SA.Section_Id AND SSD.Student_Id=SA.Student_Id AND SA.School_Code = '"+ School_Code + "' AND  SA.Class_Id = '"+ Class_Id + "' AND  SA.Period_Date='"+ Period_Date + "'  AND  SA.Session_Year='"+ Session_year + "' ORDER BY (SA.Student_Id)";
            //string sqlquery = "SELECT  FullName,Student_Id, [1] As First_Period,[2] AS Second_Period,[3] AS Third_Period,[4] AS Fourth_Period ,[5] AS Fifth_Period,[6] AS Sixth_Period ,[7] AS Seven_Period  FROM (SELECT  Isnull(SSD.first_name, '') + ' ' + Isnull(SSD.middle_name, '') + ' ' + Isnull(SSD.last_name, '') AS FullName, SA.Student_Id, SA.[Period_Id], SA.Presence_Status FROM School_Student_Details AS SSD, Student_Attendance AS SA WHERE SA.School_Code = SSD.School_Code AND SSD.AdmissionClass_Id = SA.Class_Id AND SSD.Section_Id = SA.Section_Id AND SSD.Student_Id = SA.Student_Id AND SA.School_Code = '" + School_Code + "' AND  SA.Class_Id = '" + Class_Id + "' AND  SA.Period_Date='" + Period_Date + "'  AND  SA.Session_Year='" + Session_year + "') Tab1 PIVOT (MAX(Presence_Status) FOR[Period_Id] IN([1],[2],[3],[4],[5],[6],[7]) ) AS Tab2 ORDER BY Tab2.Student_Id";
            // string sqlquery = "SELECT  FullName,Student_Id, [First] As First_Period,[Second] AS Second_Period,[Third] AS Third_Period,[Fourth] AS Fourth_Period ,[Fifth] AS Fifth_Period,[Sixth] AS Sixth_Period ,[Seventh] AS Seventh_Period ,[Eighth] AS Eighth_Period ,[Nineth] AS Nineth_Period ,[Tenth] AS Tenth_Period   FROM (SELECT  Isnull(SSD.first_name, '') + ' ' + Isnull(SSD.middle_name, '') + ' ' + Isnull(SSD.last_name, '') AS FullName, SA.Student_Id, SA.[Period_Name], SA.Presence_Status FROM School_Student_Details AS SSD, Student_Attendance AS SA WHERE SA.School_Code = SSD.School_Code AND SSD.AdmissionClass_Id = SA.Class_Id AND SSD.Section_Id = SA.Section_Id AND SSD.Student_Id = SA.Student_Id AND SA.School_Code = '" + School_Code + "' AND  SA.Class_Id = '" + Class_Id + "' AND  SA.Period_Date='" + Period_Date + "'  AND  SA.Session_Year='" + Session_year + "') Tab1 PIVOT (MAX(Presence_Status) FOR[Period_Name] IN([First],[Second],[Third],[Fourth],[Fifth],[Sixth],[Seventh],[Eighth],[Nineth],[Tenth]) ) AS Tab2 ORDER BY Tab2.Student_Id";
            string sqlquery = "SELECT Period_Date, [First] As First_Period,[Second] AS Second_Period,[Third] AS Third_Period,[Fourth] AS Fourth_Period ,[Fifth] AS Fifth_Period,[Sixth] AS Sixth_Period ,[Seventh] AS Seventh_Period ,[Eighth] AS Eighth_Period ,[Nineth] AS Nineth_Period ,[Tenth] AS Tenth_Period   FROM (SELECT  SA.Period_Date, SA.[Period_Name], SA.Presence_Status FROM  Student_Attendance AS SA WHERE SA.School_Code = '" + Session["School_Code"] + "' AND  SA.Student_Id ='" +Student_Id + "' AND  SA.Class_Id = '" +Class_Id + "'   AND  SA.Period_Date BETWEEN  '" + Start_Date + "' AND '" + End_Date + "') Tab1 PIVOT (MAX(Presence_Status) FOR[Period_Name] IN([First],[Second],[Third],[Fourth],[Fifth],[Sixth],[Seventh],[Eighth],[Nineth],[Tenth]) ) AS Tab2 ORDER BY Tab2.Period_Date";
            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon);

            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = sqlcom;

            DataTable dt = new DataTable();

            //  sqlcon.Open();
            da.Fill(dt);

            sqlcon.Close();


            foreach (DataRow sdr in dt.Rows)
            {
                StuentList.Add(
                    new StudentAllList
                    {

                        //  Student_Id = String.IsNullOrEmpty(sdr["Student_Id"].ToString()) ? '0' : Convert.ToInt32(sdr["Student_Id"]),
                        // Parent_Id = String.IsNullOrEmpty(sdr["Parent_Id"].ToString()) ? '0' : Convert.ToInt32(sdr["Parent_Id"]),
                        //School_Code = String.IsNullOrEmpty(sdr["School_Code"].ToString()) ? null : sdr["School_Code"].ToString(),
                        //FullName = String.IsNullOrEmpty(sdr["FullName"].ToString()) ? null : sdr["FullName"].ToString(),
                        //Present_Status = String.IsNullOrEmpty(sdr["Presence_Status"].ToString()) ? null : sdr["Presence_Status"].ToString(),
                        //Period_Id = String.IsNullOrEmpty(sdr["Period_Id"].ToString()) ? '0' : Convert.ToInt32(sdr["Period_Id"]),
                        // Class_Name = String.IsNullOrEmpty(sdr["Class_Name"].ToString()) ? null : sdr["Class_Name"].ToString(),
                        //   Section_Id = String.IsNullOrEmpty(sdr["Section_Id"].ToString()) ? '0' : Convert.ToInt32(sdr["Section_Id"]),
                        // Section_Name = String.IsNullOrEmpty(sdr["Section_Name"].ToString()) ? null : sdr["Section_Name"].ToString(),
                        Period_Date = String.IsNullOrEmpty(sdr["Period_Date"].ToString()) ? "NA" : sdr["Period_Date"].ToString(),
                        First_Period = String.IsNullOrEmpty(sdr["First_Period"].ToString()) ? "NA" : sdr["First_Period"].ToString(),
                        Second_Period = String.IsNullOrEmpty(sdr["Second_Period"].ToString()) ? "NA" : sdr["Second_Period"].ToString(),
                        Third_Period = String.IsNullOrEmpty(sdr["Third_Period"].ToString()) ? "NA" : sdr["Third_Period"].ToString(),
                        Fourth_Period = String.IsNullOrEmpty(sdr["Fourth_Period"].ToString()) ? "NA" : sdr["Fourth_Period"].ToString(),
                        Fifth_Period = String.IsNullOrEmpty(sdr["Fifth_Period"].ToString()) ? "NA" : sdr["Fifth_Period"].ToString(),
                        Sixth_Period = String.IsNullOrEmpty(sdr["Sixth_Period"].ToString()) ? "NA" : sdr["Sixth_Period"].ToString(),
                        Seventh_Period = String.IsNullOrEmpty(sdr["Seventh_Period"].ToString()) ? "NA" : sdr["Seventh_Period"].ToString(),
                        Eighth_Period = String.IsNullOrEmpty(sdr["Eighth_Period"].ToString()) ? "NA" : sdr["Eighth_Period"].ToString(),
                        Nineth_Period = String.IsNullOrEmpty(sdr["Nineth_Period"].ToString()) ? "NA" : sdr["Nineth_Period"].ToString(),
                        Tenth_Period = String.IsNullOrEmpty(sdr["Tenth_Period"].ToString()) ? "NA" : sdr["Tenth_Period"].ToString()







                    });
            }
            //}
            //catch (Exception ex)
            //{
            //    ViewBag.Error = ex.Message;

            //}
            return Json(StuentList, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Add_Syllabus()
        {
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                StudentSyllabus model = new StudentSyllabus();
                //  model.PeriodList = PopulateDropDown("SELECT Period_Id, Period_Name FROM Period_Master  WHERE School_Code='" + Session["School_Code"] + "'", "Period_Name", "Period_Id");
                //model.Year_Name = PopulateDropDown("SELECT Year, Year_Name FROM Year", "Year_Name", "Year");

                //model.ExamList = PopulateDropDown("SELECT Exam_Term_id, Exam_Term_Name FROM School_Exam_Term_Master", "Exam_Term_Name", "Exam_Term_id");
                model.Class_Name = PopulateDropDown("SELECT Class_Id, Class_Name FROM Class_Master  WHERE School_Code='" + Session["School_Code"] + "'", "Class_Name", "Class_Id");
                model.Year_Name = PopulateDropDown("SELECT Year, Year_Name FROM Year", "Year_Name", "Year");

                //model.SectionList = PopulateDropDown("SELECT Section_Name, Section_Id FROM School_Section_Master WHERE School_Code='" + Session["School_Code"] + "'", "Section_Name", "Section_Id");

                return View(model);
            }
        }



        [HttpPost]
        public JsonResult AjaxMethod_DropDownList(string type, int value, String Section_Id)
        {
            StudentSyllabus model = new StudentSyllabus();
            switch (type)
            {
                case "Class_Id":

                    model.SubjectList = PopulateDropDown("SELECT Subject_id, Subject_Name FROM School_Subject_Master WHERE School_Code='" + Session["School_Code"] + "' AND Class_Id='" + value + "' AND Exam_Sub_Type='Theory' ", "Subject_Name", "Subject_id");
                    // break;

                    // case "Period_Id":

                    model.SectionList = PopulateDropDown("SELECT Section_Id, Section_Name FROM School_Section_Master WHERE School_Code ='" + Session["School_Code"] + "' AND Class_Id ='" + value + "' ", "Section_Name", "Section_Id");

                    model.ExamList = PopulateDropDown("SELECT Exam_Term_id, Exam_Term_Name FROM School_Exam_Term_Master WHERE School_Code='" + Session["School_Code"] + "'", "Exam_Term_Name", "Exam_Term_id");
                  
                    break;

            }
            return Json(model);
        }


        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add_Syllabus(StudentSyllabus smodel,FormCollection fc, HttpPostedFileBase Syllabus_Attachment)
        {
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
              //  StudentSyllabus smodel = new StudentSyllabus();

                var nvc = Request.Unvalidated().Form;
                //try
                //{
                DataBaseAcessLayer.SchoolAdminDB dbhandle = new DataBaseAcessLayer.SchoolAdminDB();
                  
                
                        smodel.Session_Year = fc["Session_Year"];
                        smodel.Student_Id = Convert.ToInt32(fc["Student_Id"]);
                        smodel.Class_Id = Convert.ToInt32(fc["Class_Id"]);
                        smodel.Section_Id = Convert.ToInt32(fc["Section_Id"]);
                         smodel.Subject_Id = Convert.ToInt32(fc["Subject_Id"]);
                         smodel.Exam_Id = Convert.ToInt32(fc["Exam_Id"]);
                smodel.Syllabus_Desc = fc["Syllabus_Desc"];

                //smodel.Syllabus_Desc = nvc["Syllabus_Desc"];

                //HttpRequestBase request = controllerContext.HttpContext.Request;
                //string re = request.Unvalidated.Form.Get("ConfirmationMessage")

                if (Syllabus_Attachment != null)
                    {

                        string fileNamee = Path.GetFileNameWithoutExtension(Syllabus_Attachment.FileName);
                        string extension = Path.GetExtension(Syllabus_Attachment.FileName);
                        smodel.Syllabus_Attachment_name = fileNamee + extension;
                        fileNamee = fileNamee + DateTime.Now.ToString("yymmssff") + extension;
                        Syllabus_Attachment.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Syllabus/"), fileNamee));
                        // stdsch.BirthCertificatePath = "~/AppFiles/Images/"+ fileName;
                        smodel.Syllabus_Attachment_Path = fileNamee;

                
                    }



                    dbhandle.Add_Syllabus(smodel);


              //  }
                //catch (Exception ex)
                //{
                //    ViewBag.Error = ex.Message;

                //}

                TempData["msg"] = "Attendsnce Inserted done Successfully!";
                return this.RedirectToAction("Add_Syllabus", "SchoolAdmin");
                //return View(smodel);
            }

        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Update_Syllabus(StudentSyllabus smodel, FormCollection fc, HttpPostedFileBase Syllabus_Attachment)
        {
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                //  StudentSyllabus smodel = new StudentSyllabus();

                var nvc = Request.Unvalidated().Form;
                //try
                //{
                DataBaseAcessLayer.SchoolAdminDB dbhandle = new DataBaseAcessLayer.SchoolAdminDB();


                //smodel.Session_Year = fc["Session_Year"];
                smodel.Syllabus_Id = Convert.ToInt32(fc["Syllabus_Id"]);
                //smodel.Class_Id = Convert.ToInt32(fc["Class_Id"]);
                //smodel.Section_Id = Convert.ToInt32(fc["Section_Id"]);
                //smodel.Subject_Id = Convert.ToInt32(fc["Subject_Id"]);
                //smodel.Exam_Id = Convert.ToInt32(fc["Exam_Id"]);
                smodel.Syllabus_Desc = fc["Syllabus_Desc"];
                

                if (Syllabus_Attachment != null)
                {

                    string fileNamee = Path.GetFileNameWithoutExtension(Syllabus_Attachment.FileName);
                    string extension = Path.GetExtension(Syllabus_Attachment.FileName);
                    smodel.Syllabus_Attachment_name = fileNamee + extension;
                    fileNamee = fileNamee + DateTime.Now.ToString("yymmssff") + extension;
                    Syllabus_Attachment.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Syllabus/"), fileNamee));
                    // stdsch.BirthCertificatePath = "~/AppFiles/Images/"+ fileName;
                    smodel.Syllabus_Attachment_Path = fileNamee;


                }

                dbhandle.Update_Syllabus(smodel);


                //  }
                //catch (Exception ex)
                //{
                //    ViewBag.Error = ex.Message;

                //}

                TempData["msg"] = "Attendsnce Inserted done Successfully!";
               return this.RedirectToAction("View_Syllabus", "SchoolAdmin");
              // return View(smodel);
            }

        }

        [HttpGet]
        public ActionResult View_Syllabus()
        {
            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }
            else
            {
                StudentSyllabus model = new StudentSyllabus();
                //  model.PeriodList = PopulateDropDown("SELECT Period_Id, Period_Name FROM Period_Master  WHERE School_Code='" + Session["School_Code"] + "'", "Period_Name", "Period_Id");
                //model.Year_Name = PopulateDropDown("SELECT Year, Year_Name FROM Year", "Year_Name", "Year");

                //model.ExamList = PopulateDropDown("SELECT Exam_Term_id, Exam_Term_Name FROM School_Exam_Term_Master", "Exam_Term_Name", "Exam_Term_id");
                model.Class_Name = PopulateDropDown("SELECT Class_Id, Class_Name FROM Class_Master  WHERE School_Code='" + Session["School_Code"] + "'", "Class_Name", "Class_Id");
               // model.Class_Name = PopulateDropDown("SELECT Class_Id, Class_Name FROM Class_Master  WHERE School_Code='" + Session["School_Code"] + "'", "Class_Name", "Class_Idd");

                model.Year_Name = PopulateDropDown("SELECT Year, Year_Name FROM Year", "Year_Name", "Year");

                //model.SectionList = PopulateDropDown("SELECT Section_Name, Section_Id FROM School_Section_Master WHERE School_Code='" + Session["School_Code"] + "'", "Section_Name", "Section_Id");

                return View(model);
            }
        }

        [HttpGet]
        public ActionResult AddSessionYear()
        {
            School_Session_Year model1 = new School_Session_Year();

            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }

            else
            {

             
                //  model.RoomCategory = PopulateDropDown("Select Category_Name from School_RoomCategory where School_Code='" + Session["School_Code"] + "' And School_Group_Code='" + Session["School_Group_Code"] + "'", "Category_Name", "Category_Name");

                List<School_Session_Year> SessionYearList = new List<School_Session_Year>();
                School_Session_Year model = new School_Session_Year();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
                SqlCommand cmd = new SqlCommand("Session_Year", con);
                cmd.CommandType = CommandType.StoredProcedure;
              //  cmd.Parameters.AddWithValue("@School_Group_Code", Session["School_Group_Code"]);

                cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);
                DataTable dt = new DataTable();
                cmd.Parameters.AddWithValue("@Query", 2);
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                con.Open();
                sd.Fill(dt);
                con.Close();
               foreach (DataRow dr in dt.Rows)
                {
                    SessionYearList.Add(new School_Session_Year
                    {

                        Start_Month = Convert.ToString(dr["Start_Month"]),
                        Start_Year = Convert.ToString(dr["Start_Year"]),
                        End_Month = Convert.ToString(dr["End_Month"]),
                        End_Year = Convert.ToString(dr["End_Year"])
                       // id = Convert.ToInt32(dr["Room_Id"])

                    });




                }

                model.SessionYearList = SessionYearList;


                return View(model);



            }
           
        }

        [HttpPost]
        public ActionResult AddSessionYear(FormCollection fc)
        {
            School_Session_Year model1 = new School_Session_Year();

            if (Session["School_Code"] == null)
            {
                return Redirect("~/SchoolAdmin/SchoolAdminLogin");
            }

            else
            {


                //  model.RoomCategory = PopulateDropDown("Select Category_Name from School_RoomCategory where School_Code='" + Session["School_Code"] + "' And School_Group_Code='" + Session["School_Group_Code"] + "'", "Category_Name", "Category_Name");

                //List<School_Session_Year> SessionYearList = new List<School_Session_Year>();
                School_Session_Year model = new School_Session_Year();
                //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
                //SqlCommand cmd = new SqlCommand("Session_Year", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                ////  cmd.Parameters.AddWithValue("@School_Group_Code", Session["School_Group_Code"]);

                //cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);
                //DataTable dt = new DataTable();
                //cmd.Parameters.AddWithValue("@Query", 2);
                //SqlDataAdapter sd = new SqlDataAdapter(cmd);
                //con.Open();
                //sd.Fill(dt);
                //con.Close();
                //foreach (DataRow dr in dt.Rows)
                //{
                //    SessionYearList.Add(new School_Session_Year
                //    {

                //        Start_Month = Convert.ToString(dr["Start_Month"]),
                //        Start_Year = Convert.ToString(dr["Start_Year"]),
                //        End_Month = Convert.ToString(dr["End_Month"]),
                //        End_Year = Convert.ToString(dr["End_Year"])
                //        // id = Convert.ToInt32(dr["Room_Id"])

                //    });




                //}

                //model.SessionYearList = SessionYearList;


                DataTable DT = new DataTable();
            //    DT.Columns.Add("Session_Year_Id", typeof(string));
              //  DT.Columns.Add("Session_End_Date", typeof(string));
                //DT.Columns.Add("Session_Start_Date", typeof(string));
                DT.Columns.Add("School_Code", typeof(string));
                DT.Columns.Add("Start_Month", typeof(string));
                DT.Columns.Add("Start_Year", typeof(string));
                DT.Columns.Add("End_Month", typeof(string));
                DT.Columns.Add("End_Year", typeof(string));
                DT.Columns.Add("Session_Name", typeof(string));
                // DT.Columns.Add("Vid", typeof(int));

                DataRow DR = DT.NewRow();
               // DR["Session_Year_Id"] = "";
               // DR["Session_Start_Date"] = fc["Start_Year"];
               // DR["Session_End_Date"] = fc["Start_Year"];
                DR["School_Code"] =Session["School_Code"];
                DR["Start_Month"] = fc["Start_Month"];
                DR["Start_Year"] = fc["Start_Year"];
                DR["End_Month"] = fc["End_Month"];
                DR["End_Year"] = fc["End_Year"];
                if (fc["Start_Year"]== fc["End_Year"]) {
                    DR["Session_Name"] = fc["Start_Year"];
                }
                else
                {
                    DR["Session_Name"] = fc["Start_Year"]+"-"+ fc["Start_Year"];
                }
                //  DR["Vid"] = 1;
                DT.Rows.Add(DR);
                DatasetInsert(DT); //calling datatable met


                TempData["msg"] = "Session Year Added Successfully!";
                return this.RedirectToAction("AddSessionYear", "SchoolAdmin");



            }

        }
        public void DatasetInsert(DataTable dt)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);

            con.Open();
            SqlCommand cmd = new SqlCommand("USP_Insert_Session_Year", con);
            cmd.Parameters.AddWithValue("@Session_Year_Details", dt); // passing Datatable 
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            con.Close();
        }
        //public JsonResult AjaxaddSessionYear(String classname, String Stime, String Etime)
        //{
        //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
        //    SqlCommand cmd = new SqlCommand("Routine", con);
        //    cmd.CommandType = CommandType.StoredProcedure;



        //    cmd.Parameters.AddWithValue("@School_Group_Code", Session["School_Group_Code"]);

        //    cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);

        //    cmd.Parameters.AddWithValue("@class_name", classname);
        //    cmd.Parameters.AddWithValue("@Stime", Convert.ToDateTime(Stime));



        //    cmd.Parameters.AddWithValue("@Etime", Convert.ToDateTime(Etime));


        //    cmd.Parameters.AddWithValue("@Query", 20);

        //    SqlDataAdapter sd = new SqlDataAdapter(cmd);
        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close();
        //    return Json("Data inserted!!");


        //}
        //public JsonResult AjaxSessionYearName(String cname)
        //{
        //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
        //    SqlCommand cmd = new SqlCommand("Routine", con);
        //    cmd.CommandType = CommandType.StoredProcedure;


        //    cmd.Parameters.AddWithValue("@School_Group_Code", Session["School_Group_Code"]);

        //    cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);

        //    cmd.Parameters.AddWithValue("@class_name", cname);


        //    DataTable dt = new DataTable();

        //    cmd.Parameters.AddWithValue("@Query", 21);

        //    SqlDataAdapter sd = new SqlDataAdapter(cmd);


        //    con.Open();
        //    sd.Fill(dt);
        //    con.Close();
        //    ////for view 
        //    ///
        //    int cnt = 0;

        //    foreach (DataRow dr in dt.Rows)
        //    {


        //        cnt = Convert.ToInt32(dr["cnt"]);


        //    }
        //    if (cnt == 0)
        //        return Json("");

        //    else
        //        return Json("class  already exists!!");



        //}


        [HttpPost]
        public JsonResult AjaxMethod_StudentSyllabus(String Session_year, int Class_Id, String Exam_Id)
        {
            String School_Code = Session["School_Code"].ToString();

            List<StudentSyllabus> StuentList = new List<StudentSyllabus>();
            String con = ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            //try
            //{
            // string sqlquery = "SELECT SA.*, Isnull(SSD.first_name, '') + ' ' + Isnull(SSD.middle_name, '') + ' ' + Isnull(SSD.last_name, '') AS FullName FROM School_Student_Details AS SSD,Student_Attendance AS SA WHERE SA.School_Code=SSD.School_Code AND SSD.AdmissionClass_Id=SA.Class_Id AND SSD.Section_Id=SA.Section_Id AND SSD.Student_Id=SA.Student_Id AND SA.School_Code = '"+ School_Code + "' AND  SA.Class_Id = '"+ Class_Id + "' AND  SA.Period_Date='"+ Period_Date + "'  AND  SA.Session_Year='"+ Session_year + "' ORDER BY (SA.Student_Id)";
            //string sqlquery = "SELECT  FullName,Student_Id, [1] As First_Period,[2] AS Second_Period,[3] AS Third_Period,[4] AS Fourth_Period ,[5] AS Fifth_Period,[6] AS Sixth_Period ,[7] AS Seven_Period  FROM (SELECT  Isnull(SSD.first_name, '') + ' ' + Isnull(SSD.middle_name, '') + ' ' + Isnull(SSD.last_name, '') AS FullName, SA.Student_Id, SA.[Period_Id], SA.Presence_Status FROM School_Student_Details AS SSD, Student_Attendance AS SA WHERE SA.School_Code = SSD.School_Code AND SSD.AdmissionClass_Id = SA.Class_Id AND SSD.Section_Id = SA.Section_Id AND SSD.Student_Id = SA.Student_Id AND SA.School_Code = '" + School_Code + "' AND  SA.Class_Id = '" + Class_Id + "' AND  SA.Period_Date='" + Period_Date + "'  AND  SA.Session_Year='" + Session_year + "') Tab1 PIVOT (MAX(Presence_Status) FOR[Period_Id] IN([1],[2],[3],[4],[5],[6],[7]) ) AS Tab2 ORDER BY Tab2.Student_Id";
            // string sqlquery = "SELECT  FullName,Student_Id, [First] As First_Period,[Second] AS Second_Period,[Third] AS Third_Period,[Fourth] AS Fourth_Period ,[Fifth] AS Fifth_Period,[Sixth] AS Sixth_Period ,[Seventh] AS Seventh_Period ,[Eighth] AS Eighth_Period ,[Nineth] AS Nineth_Period ,[Tenth] AS Tenth_Period   FROM (SELECT  Isnull(SSD.first_name, '') + ' ' + Isnull(SSD.middle_name, '') + ' ' + Isnull(SSD.last_name, '') AS FullName, SA.Student_Id, SA.[Period_Name], SA.Presence_Status FROM School_Student_Details AS SSD, Student_Attendance AS SA WHERE SA.School_Code = SSD.School_Code AND SSD.AdmissionClass_Id = SA.Class_Id AND SSD.Section_Id = SA.Section_Id AND SSD.Student_Id = SA.Student_Id AND SA.School_Code = '" + School_Code + "' AND  SA.Class_Id = '" + Class_Id + "' AND SSD.Section_Id ='" + Section_Id + "' AND  SA.Period_Date='" + Period_Date + "'  AND  SA.Session_Year='" + Session_year + "') Tab1 PIVOT (MAX(Presence_Status) FOR[Period_Name] IN([First],[Second],[Third],[Fourth],[Fifth],[Sixth],[Seventh],[Eighth],[Nineth],[Tenth]) ) AS Tab2 ORDER BY Tab2.Student_Id";
            string sqlquery = "SELECT SS.*,CM.Class_Name,SSM.Subject_Name,SETM.Exam_Term_Name   FROM Student_Syllabus AS SS, Class_Master AS CM ,School_Subject_Master AS SSM,School_Exam_Term_Master AS SETM  WHERE SS.School_Code ='" + School_Code + "'  AND SS.Class_Id = '" + Class_Id + "'  AND SS.Exam_Id='"+Exam_Id +"' AND  SS.Class_Id = CM.Class_Id AND  SS.Subject_Id = SSM.Subject_Id AND SS.Exam_Id=SETM.Exam_Term_id ";
           
            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon);

            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = sqlcom;

            DataTable dt = new DataTable();

            //  sqlcon.Open();
            da.Fill(dt);

            sqlcon.Close();


            foreach (DataRow sdr in dt.Rows)
            {
                StuentList.Add(
                    new StudentSyllabus
                    {
                        Syllabus_Id = String.IsNullOrEmpty(sdr["Syllabus_Id"].ToString()) ? '0' : Convert.ToInt32(sdr["Syllabus_Id"]),

                        Class_Nam = String.IsNullOrEmpty(sdr["Class_Name"].ToString()) ? "NA" : sdr["Class_Name"].ToString(),
                       Subject_Name = String.IsNullOrEmpty(sdr["Subject_Name"].ToString()) ? "NA" : sdr["Subject_Name"].ToString(),
                           Exam_Name = String.IsNullOrEmpty(sdr["Exam_Term_Name"].ToString()) ? "NA" : sdr["Exam_Term_Name"].ToString(),
                         Syllabus_Desc = String.IsNullOrEmpty(Regex.Replace(sdr["Syllabus_Desc"].ToString(), "<.*?>", string.Empty)) ? "NA" : Regex.Replace(sdr["Syllabus_Desc"].ToString(), "<.*?>", string.Empty),
                       
                        Syllabus_Attachment_name = String.IsNullOrEmpty(sdr["Attachement_Name"].ToString()) ? "NA" : sdr["Attachement_Name"].ToString(),
                        Syllabus_Attachment_Path = String.IsNullOrEmpty(sdr["Attachedment_Path"].ToString()) ? "NA" : sdr["Attachedment_Path"].ToString()








                    });
            }
            //}
            //catch (Exception ex)
            //{
            //    ViewBag.Error = ex.Message;

            //}
            return Json(StuentList, JsonRequestBehavior.AllowGet);
        }






        [HttpPost]
        public JsonResult Ajax_SyllabusExamWise(int Class_Id)
        {
            String School_Code = Session["School_Code"].ToString();
       
            List<StudentSyllabus> StuentList1 = new List<StudentSyllabus>();
            String con = ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            //try
            //{
            // string sqlquery = "SELECT SA.*, Isnull(SSD.first_name, '') + ' ' + Isnull(SSD.middle_name, '') + ' ' + Isnull(SSD.last_name, '') AS FullName FROM School_Student_Details AS SSD,Student_Attendance AS SA WHERE SA.School_Code=SSD.School_Code AND SSD.AdmissionClass_Id=SA.Class_Id AND SSD.Section_Id=SA.Section_Id AND SSD.Student_Id=SA.Student_Id AND SA.School_Code = '"+ School_Code + "' AND  SA.Class_Id = '"+ Class_Id + "' AND  SA.Period_Date='"+ Period_Date + "'  AND  SA.Session_Year='"+ Session_year + "' ORDER BY (SA.Student_Id)";
            //string sqlquery = "SELECT  FullName,Student_Id, [1] As First_Period,[2] AS Second_Period,[3] AS Third_Period,[4] AS Fourth_Period ,[5] AS Fifth_Period,[6] AS Sixth_Period ,[7] AS Seven_Period  FROM (SELECT  Isnull(SSD.first_name, '') + ' ' + Isnull(SSD.middle_name, '') + ' ' + Isnull(SSD.last_name, '') AS FullName, SA.Student_Id, SA.[Period_Id], SA.Presence_Status FROM School_Student_Details AS SSD, Student_Attendance AS SA WHERE SA.School_Code = SSD.School_Code AND SSD.AdmissionClass_Id = SA.Class_Id AND SSD.Section_Id = SA.Section_Id AND SSD.Student_Id = SA.Student_Id AND SA.School_Code = '" + School_Code + "' AND  SA.Class_Id = '" + Class_Id + "' AND  SA.Period_Date='" + Period_Date + "'  AND  SA.Session_Year='" + Session_year + "') Tab1 PIVOT (MAX(Presence_Status) FOR[Period_Id] IN([1],[2],[3],[4],[5],[6],[7]) ) AS Tab2 ORDER BY Tab2.Student_Id";
            // string sqlquery = "SELECT  FullName,Student_Id, [First] As First_Period,[Second] AS Second_Period,[Third] AS Third_Period,[Fourth] AS Fourth_Period ,[Fifth] AS Fifth_Period,[Sixth] AS Sixth_Period ,[Seventh] AS Seventh_Period ,[Eighth] AS Eighth_Period ,[Nineth] AS Nineth_Period ,[Tenth] AS Tenth_Period   FROM (SELECT  Isnull(SSD.first_name, '') + ' ' + Isnull(SSD.middle_name, '') + ' ' + Isnull(SSD.last_name, '') AS FullName, SA.Student_Id, SA.[Period_Name], SA.Presence_Status FROM School_Student_Details AS SSD, Student_Attendance AS SA WHERE SA.School_Code = SSD.School_Code AND SSD.AdmissionClass_Id = SA.Class_Id AND SSD.Section_Id = SA.Section_Id AND SSD.Student_Id = SA.Student_Id AND SA.School_Code = '" + School_Code + "' AND  SA.Class_Id = '" + Class_Id + "' AND SSD.Section_Id ='" + Section_Id + "' AND  SA.Period_Date='" + Period_Date + "'  AND  SA.Session_Year='" + Session_year + "') Tab1 PIVOT (MAX(Presence_Status) FOR[Period_Name] IN([First],[Second],[Third],[Fourth],[Fifth],[Sixth],[Seventh],[Eighth],[Nineth],[Tenth]) ) AS Tab2 ORDER BY Tab2.Student_Id";
            string sqlquery = "SELECT SS.*,CM.Class_Name,SSM.Subject_Name,SETM.Exam_Term_Name   FROM Student_Syllabus AS SS, Class_Master AS CM ,School_Subject_Master AS SSM,School_Exam_Term_Master AS SETM  WHERE SS.School_Code ='" + School_Code + "'  AND SS.Class_Id = '" + Class_Id + "' AND SS.Class_Id = CM.Class_Id AND  SS.Subject_Id = SSM.Subject_Id AND SS.Exam_Id=SETM.Exam_Term_id ";

            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon);

            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = sqlcom;

            DataTable dt = new DataTable();

            //  sqlcon.Open();
            da.Fill(dt);

            sqlcon.Close();


            foreach (DataRow sdr in dt.Rows)
            {
                StuentList1.Add(
                    new StudentSyllabus
                    {

                        Syllabus_Id = String.IsNullOrEmpty(sdr["Syllabus_Id"].ToString()) ? '0' : Convert.ToInt32(sdr["Syllabus_Id"]),
                        //  FullName = String.IsNullOrEmpty(sdr["FullName"].ToString()) ? null : sdr["FullName"].ToString(),

                        Class_Nam = String.IsNullOrEmpty(sdr["Class_Name"].ToString()) ? "NA" : sdr["Class_Name"].ToString(),
                        //  Section_Nam = String.IsNullOrEmpty(sdr["Section_Name"].ToString()) ? "NA" : sdr["Section_Name"].ToString(),
                        Subject_Name = String.IsNullOrEmpty(sdr["Subject_Name"].ToString()) ? "NA" : sdr["Subject_Name"].ToString(),
                         Exam_Name = String.IsNullOrEmpty(sdr["Exam_Term_Name"].ToString()) ? "NA" : sdr["Exam_Term_Name"].ToString(),
                        // Fifth_Period = String.IsNullOrEmpty(sdr["Fifth_Period"].ToString()) ? "NA" : sdr["Fifth_Period"].ToString(),
                        // Sixth_Period = String.IsNullOrEmpty(sdr["Sixth_Period"].ToString()) ? "NA" : sdr["Sixth_Period"].ToString(),
                        // Seventh_Period = String.IsNullOrEmpty(sdr["Seventh_Period"].ToString()) ? "NA" : sdr["Seventh_Period"].ToString(),
                        //Eighth_Period = String.IsNullOrEmpty(sdr["Eighth_Period"].ToString()) ? "NA" : sdr["Eighth_Period"].ToString(),
                        //   Syllabus_Desc = String.IsNullOrEmpty(sdr["Syllabus_Desc"].ToString()) ? "NA" : sdr["Syllabus_Desc"].ToString(),
                        //  Syllabus_Desc = Regex.Replace(sdr["Syllabus_Desc"].ToString(), "<.*?>", string.Empty),
                        Syllabus_Desc = String.IsNullOrEmpty(Regex.Replace(sdr["Syllabus_Desc"].ToString(), "<.*?>", string.Empty)) ? "NA" : Regex.Replace(sdr["Syllabus_Desc"].ToString(), "<.*?>", string.Empty),

                        Syllabus_Attachment_name = String.IsNullOrEmpty(sdr["Attachement_Name"].ToString()) ? "NA" : sdr["Attachement_Name"].ToString(),
                        Syllabus_Attachment_Path = String.IsNullOrEmpty(sdr["Attachedment_Path"].ToString()) ? "NA" : sdr["Attachedment_Path"].ToString()








                    });
            }
            //}
            //catch (Exception ex)
            //{
            //    ViewBag.Error = ex.Message;

            //}
            return Json(StuentList1, JsonRequestBehavior.AllowGet);
        }






        public JsonResult CheckSyllabusTaken(int Class_Id,  string Session_year,int Subject_Id, string Exam_Id)
        {
            //System.Threading.Thread.Sleep(200);
            //ParentRegistration model = new ParentRegistration();
            SchoolRegistration model = new SchoolRegistration();

            String con = ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            string sqlquery = "Select * FROM [dbo].[Student_Syllabus] WHERE School_code='" + Session["School_code"] + "' AND Class_Id='" + Class_Id + "'  AND Subject_Id='"+Subject_Id+"' AND Exam_Id ='" + Exam_Id + "'  ";
            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlcom;
            DataSet ds = new DataSet();
            da.Fill(ds);

            SqlDataReader sdr = sqlcom.ExecuteReader();
            if (sdr.Read())
            {
                return Json(1);
            }
            else
            {
                return Json(0);
            }

        }


        [HttpPost]
        public JsonResult AjaxMethod_ViewSyllabus( int Syllabus_Id)
        {
            String School_Code = Session["School_Code"].ToString();

            List<StudentSyllabus> StuentList = new List<StudentSyllabus>();
            String con = ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            //try
            //{
            //   string sqlquery = "SELECT SS.*,CM.Class_Name,SSM.Subject_Name,SETM.Exam_Term_Name   FROM Student_Syllabus AS SS, Class_Master AS CM ,School_Subject_Master AS SSM,School_Exam_Term_Master AS SETM  WHERE SS.School_Code ='" + School_Code + "'  AND SS.Class_Id = '" + Class_Id + "'  AND SS.Exam_Id='" + Exam_Id + "' AND  SS.Class_Id = CM.Class_Id AND  SS.Subject_Id = SSM.Subject_Id AND SS.Exam_Id=SETM.Exam_Term_id ";

            string sqlquery = "SELECT SS.*   FROM Student_Syllabus AS SS WHERE SS.School_Code ='" + School_Code + "' AND  SS.Syllabus_Id ='" + Syllabus_Id + "' ";

            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon);

            SqlDataAdapter da = new SqlDataAdapter();

            da.SelectCommand = sqlcom;

            DataTable dt = new DataTable();

            //  sqlcon.Open();
            da.Fill(dt);

            sqlcon.Close();


            foreach (DataRow sdr in dt.Rows)
            {
                StuentList.Add(
                    new StudentSyllabus
                    {

                      //  Class_Nam = String.IsNullOrEmpty(sdr["Class_Name"].ToString()) ? "NA" : sdr["Class_Name"].ToString(),
                       // Subject_Name = String.IsNullOrEmpty(sdr["Subject_Name"].ToString()) ? "NA" : sdr["Subject_Name"].ToString(),
                      //  Exam_Name = String.IsNullOrEmpty(sdr["Exam_Term_Name"].ToString()) ? "NA" : sdr["Exam_Term_Name"].ToString(),
                        Syllabus_Desc = String.IsNullOrEmpty(Regex.Replace(sdr["Syllabus_Desc"].ToString(), "<.*?>", string.Empty)) ? "NA" : Regex.Replace(sdr["Syllabus_Desc"].ToString(), "<.*?>", string.Empty),
                        
                        Syllabus_Attachment_name = String.IsNullOrEmpty(sdr["Attachement_Name"].ToString()) ? "NA" : sdr["Attachement_Name"].ToString(),
                        Syllabus_Attachment_Path = String.IsNullOrEmpty(sdr["Attachedment_Path"].ToString()) ? "NA" : sdr["Attachedment_Path"].ToString()

                    });
            }
            //}
            //catch (Exception ex)
            //{
            //    ViewBag.Error = ex.Message;

            //}
            return Json(StuentList, JsonRequestBehavior.AllowGet);
        }





    }

}