using SchoolWork.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Web.Mvc;
using System.Linq;
using System.Web;
using System.IO;
using System.Text.RegularExpressions;
namespace SchoolWork.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee


        DataBaseAcessLayer.EmployeeDetailsDB dblayer3 = new DataBaseAcessLayer.EmployeeDetailsDB();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EmployeeLogin()
        {
            EmployeeLogin model = new EmployeeLogin();
            model.School_Name = PopulateDropDown("SELECT School_Name,School_Code FROM School_Details_Master", "School_Name", "School_Code");
            return View(model);


        }

        [HttpPost]
        public ActionResult EmployeeLogin(ParentLogin fc)
        {
            EmployeeLogin model = new EmployeeLogin();
            model.School_Name = PopulateDropDown("SELECT School_Name,School_Code FROM School_Details_Master", "School_Name", "School_Code");
            try
            {
                String con = ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString;
                SqlConnection sqlcon = new SqlConnection(con);
                //string sqlquery = "Select Employee_Id,EmpType_Id,Employee_Name, Employee_Code,School_Code,School_Id,School_Name FROM [dbo].[School_Employee_Details] WHERE  Employee_Email=@Email and Employee_Password=@Password";

                sqlcon.Open(); string sqlquery = "SELECT SM.*,PR.* FROM School_User_Master AS SM, School_Employee_Details AS PR WHERE SM.User_Email = @Email AND SM.User_Password =@Password AND SM.School_Code =@School_Code AND SM.User_Type =@User_Type AND SM.User_Id = PR.Employee_Id AND SM.User_Email = PR.Employee_Email";
                SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon);
                sqlcom.Parameters.AddWithValue("@Email", fc.UserName);
                sqlcom.Parameters.AddWithValue("@Password", fc.Password);
                sqlcom.Parameters.AddWithValue("@School_Code", fc.School_Code);
                sqlcom.Parameters.AddWithValue("@User_Type", fc.User_Type);
                SqlDataAdapter da = new SqlDataAdapter();
                da.SelectCommand = sqlcom;
                DataSet ds = new DataSet();
                da.Fill(ds);

                SqlDataReader sdr = sqlcom.ExecuteReader();
                if (sdr.Read())
                {
                    //Session["username"] = fc.UserName.ToString();
                    Session["Employee_Id"] = ds.Tables[0].Rows[0]["Employee_Id"].ToString();
                    Session["EmpType_Id"] = ds.Tables[0].Rows[0]["EmpType_Id"].ToString();
                    Session["Employee_Name"] = ds.Tables[0].Rows[0]["Employee_Name"].ToString();
                    Session["Employee_Email"] = ds.Tables[0].Rows[0]["Employee_Email"].ToString();
                    Session["Employee_Password"] = ds.Tables[0].Rows[0]["Employee_Password"].ToString();
                    Session["Employee_Code"] = ds.Tables[0].Rows[0]["Employee_Code"].ToString();
                    Session["School_Code"] = ds.Tables[0].Rows[0]["School_Code"].ToString();
                    Session["School_Id"] = ds.Tables[0].Rows[0]["School_Id"].ToString();
                    Session["School_Name"] = ds.Tables[0].Rows[0]["School_Name"].ToString();
                    //ViewData["sucess_msg"] = Session["username"];

                    return this.RedirectToAction("EmployeeHeaderBoard", "Dashboard");

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

        [HttpGet]
        public ActionResult ShowallEmpNotice()
        {

            DataBaseAcessLayer.EmployeeDetailsDB dbhandle = new DataBaseAcessLayer.EmployeeDetailsDB();

            if (Session["Employee_Id"] == null)
            {
                return Redirect("~/Employee/EmployeeLogin");
            }
            else
            {

                return View(dbhandle.GetEmpNotice());

            }
        }


        [HttpGet]
        public ActionResult ShowNoticeDetails(int id) {

            ViewBag.PreviousUrl = System.Web.HttpContext.Current.Request.UrlReferrer;
            DataBaseAcessLayer.EmployeeDetailsDB dbhandle = new DataBaseAcessLayer.EmployeeDetailsDB();
            if (Session["Employee_Id"] == null)
            {
                return Redirect("~/Employee/EmployeeLogin");
            }
            else
            {
                return View(dbhandle.GetEmpNotice().Find(smodel => smodel.Notice_Id == id));
            }

        }
        public ActionResult ShowEmpNoticeDetails(int id)
        {

            DataBaseAcessLayer.EmployeeDetailsDB dbhandle = new DataBaseAcessLayer.EmployeeDetailsDB();
            if (Session["Employee_Id"] == null)
            {
                return Redirect("~/Employee/EmployeeLogin");
            }
            else
            {
                return View(dbhandle.GetEmpNotice().Find(smodel => smodel.Notice_Id == id));
            }
        }


        //[HttpGet]
        //public ActionResult ShowaEmpAllDetails()
        //{

        //    DataBaseAcessLayer.EmployeeDetailsDB dbhandle = new DataBaseAcessLayer.EmployeeDetailsDB();
        //    return View(dbhandle.GetEmpAllDetails());
        //}

        //public ActionResult ShowaEmpAllDetails(int id)
        //{

        //    DataBaseAcessLayer.EmployeeDetailsDB dbhandle = new DataBaseAcessLayer.EmployeeDetailsDB();
        //    return View(dbhandle.GetEmpAllDetails().Find(smodel => smodel.Notice_Id == id));
        //}



        public ActionResult StudentAllList()
        {
            dynamic model = new ExpandoObject();
            if (Session["Employee_Id"] == null)
            {
                return Redirect("~/Employee/EmployeeLogin");
            }
            else
            {
                model.AllClasses = GetAllClassess();
                model.Students = GetStudents();
                return View(model);
            }

        }


        private static List<ClassesModel> GetAllClassess()
        {
            List<ClassesModel> allclassses = new List<ClassesModel>();

            string query = "SELECT Class_Id, Class_Name FROM Class_Master";
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
                            allclassses.Add(new ClassesModel
                            {
                                Class_Id = Convert.ToInt32(sdr["Class_Id"]),
                                Class_Name = sdr["Class_Name"].ToString(),

                            });
                        }
                    }
                    con.Close();
                    return allclassses;
                }
            }


        }

        private static List<StudentModel> GetStudents()
        {
            List<StudentModel> students = new List<StudentModel>();
            string query = "SELECT ST_Id, (ST_First_Name + ' ' + ST_Last_Name) [Name], SCHL_Code, ST_Class FROM Student_Master";
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
                            students.Add(new StudentModel
                            {
                                //  EmployeeId = sdr["EmployeeID"].ToString(),
                                //   EmployeeName = sdr["Name"].ToString(),
                                // City = sdr["City"].ToString(),
                                // Country = sdr["Country"].ToString()
                                ST_Id = sdr["ST_Id"].ToString(),
                                ST_First_Name = sdr["Name"].ToString(),
                                SCHL_Code = sdr["SCHL_Code"].ToString(),
                                ST_Class = Convert.ToInt32(sdr["ST_Class"])
                            });
                        }
                        con.Close();
                        return students;
                    }
                }
            }

        }

        public ActionResult UpdateEmployeeInfo()
        {
            //return View();
            if (Session["Employee_Id"] == null)
            {
                return Redirect("~/Employee/EmployeeLogin");
            }
            else
            {
                int Employeeid = Convert.ToInt32(Session["Employee_Id"].ToString());
                DataBaseAcessLayer.EmployeeDetailsDB dbhandle = new DataBaseAcessLayer.EmployeeDetailsDB();
                //EmployeeDetails model = new EmployeeDetails();
                // model.employeeDetails = dbhandle.GetEmployeeInfo();
                return View(dbhandle.GetEmployeeInfo().Find(smodel => smodel.Employee_Id == Employeeid));
            }
        }

        [HttpPost]
        public ActionResult UpdateEmployeeInfo(EmployeeDetails smodel, FormCollection fc)
        {
            if (Session["Employee_Id"] == null)
            {
                return Redirect("~/Employee/EmployeeLogin");
            }
            else
            {

                try
                {
                    if (ModelState.IsValid)
                    {
                        DataBaseAcessLayer.EmployeeDetailsDB dbhandle = new DataBaseAcessLayer.EmployeeDetailsDB();
                        dbhandle.UpdateDetails(smodel);
                        TempData["msg"] = "Your Info is  Updated Successfully! Login With New Password to View The Updated";
                        return this.RedirectToAction("EmployeeHeaderBoard", "DashBoard");
                    }

                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;

                }

                return View(smodel);
            }
        }

        public JsonResult CheckEmployeeUsernameAvailability(string useremail, string School_Code)
        {
            System.Threading.Thread.Sleep(200);
            ParentRegistration model = new ParentRegistration();
            // var SeachData = model.ParentRegistration.Where(x => x.StuName == userdata).SingleOrDefault();
            String con = ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            // string sqlquery = "Select ParentID,ParentName,ParentEmail, ParentPassword,School_Code FROM [dbo].[ParentRegistration] WHERE  ParentEmail='"+ useremail + "'";

            string sqlquery = "Select User_Email FROM [dbo].[School_User_Master] WHERE User_Email ='" + useremail + "' AND School_Code ='" + School_Code + "' AND User_Type = '3' ";

            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon);
            // sqlcom.Parameters.AddWithValue("@Email", fc.UserName);
            // sqlcom.Parameters.AddWithValue("@Password", fc.Password);
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



        public ActionResult AddClassNote()
        {
            if (Session["Employee_Id"] == null)
            {
                return Redirect("~/Employee/EmployeeLogin");
            }
            else
            {
                ViewBag.PreviousUrl = System.Web.HttpContext.Current.Request.UrlReferrer;
                ClassNoteModule model = new ClassNoteModule();


                try
                {
                    model.Section_Name = PopulateDropDown("SELECT Section_Id,Section_Name FROM School_Section_Master", "Section_Name", "Section_Id");
                    model.Class_Name = PopulateDropDown("SELECT Class_Id, Class_Name FROM Class_Master", "Class_Name", "Class_Id");
                    model.Subject_Name = PopulateDropDown("SELECT Subject_Id,Subject_Name FROM School_Subject_Master", "Subject_Name", "Subject_Id");
                    model.Note_Type_Name = PopulateDropDown("SELECT Note_Type_Id,Note_Type_Name FROM Note_Type_Master", "Note_Type_Name", "Note_Type_Id");
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;

                }
                return View(model);

            }
        }
        [HttpPost]
        public ActionResult AddClassNote(FormCollection fc)
        {
            if (Session["Employee_Id"] == null)
            {
                return Redirect("~/Employee/EmployeeLogin");
            }
            else
            {
                EmployeeModel model = new EmployeeModel();

                if (ModelState.IsValid)
                {
                    try
                    {
                        ClassNoteModule schfees = new ClassNoteModule();
                        schfees.School_Id = Convert.ToInt32(fc["School_Id"]);
                        schfees.School_Code = fc["School_Code"];
                        schfees.School_Name = fc["School_Name"];
                        schfees.Class_Id = Convert.ToInt32(fc["Class_Id"]);
                        schfees.Employee_Id = Convert.ToInt32(fc["Employee_Id"]);
                        schfees.Section_Id = Convert.ToInt32(fc["Section_Id"]);
                        schfees.Subject_Id = Convert.ToInt32(fc["Subject_Id"]);
                        schfees.Topic_Name = fc["Topic_Name"];
                        schfees.Note_Description = fc["Note_Description"];
                        schfees.Note_Date = fc["Note_Date"];
                        schfees.Note_Type_Id = Convert.ToInt32(fc["Note_Type_Id"]);

                        dblayer3.Add_Class_Note(schfees);
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Error = ex.Message;

                    }

                    TempData["msg"] = "School  Class Note Added Successfully!";

                    return this.RedirectToAction("ShowallClassNoteData", "Employee");
                }
                return View(model);
            }
        }

        [HttpGet]

        public ActionResult NoteDetails(int id) {
            if (Session["Employee_Id"] == null)
            {
                return Redirect("~/Employee/EmployeeLogin");
            }
            else
            {
                ViewBag.PreviousUrl = System.Web.HttpContext.Current.Request.UrlReferrer;

                DataBaseAcessLayer.EmployeeDetailsDB dbhandle = new DataBaseAcessLayer.EmployeeDetailsDB();
                return View(dbhandle.GetallClassNote().Find(smodel => smodel.Note_Id == id));

            }
        }
        [HttpPost]

        public JsonResult AjaxDelDetails(int id) {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);


            SqlCommand cmd = new SqlCommand("ClassNote_InsertUpdateDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@id", id);


            cmd.Parameters.AddWithValue("@Query", 3);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();



            return Json("Note Deleted");
        }



        [HttpGet]
        public ActionResult ShowallClassNoteData()
        {

            DataBaseAcessLayer.EmployeeDetailsDB dbhandle = new DataBaseAcessLayer.EmployeeDetailsDB();
            if (Session["Employee_Id"] == null)
            {
                return Redirect("~/Employee/EmployeeLogin");
            }
            else
            {
                return View(dbhandle.GetallClassNote());
                //return View(dbhandle.GetAdminNotice());
            }
        }


        /*  public bool UpdateNoticeDetails(AdminNoticeDetails smodel)
          {

              SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
              SqlCommand cmd = new SqlCommand("Notice_InsertUpdateDelete", con);
              cmd.CommandType = CommandType.StoredProcedure;

              cmd.Parameters.AddWithValue("@Notice_Id", smodel.Notice_Id);
              cmd.Parameters.AddWithValue("@Notice_Published_On", smodel.Notice_Published_On);
              cmd.Parameters.AddWithValue("@Notice_Description", smodel.Notice_Description);
              cmd.Parameters.AddWithValue("@Notice_Title", smodel.Notice_Title);
              cmd.Parameters.AddWithValue("@School_Code", smodel.School_Code);

              cmd.Parameters.AddWithValue("@Query", 2);
              con.Open();
              int i = cmd.ExecuteNonQuery();
              con.Close();

              if (i >= 1)
                  return true;
              else
                  return false;
          }
          */

        [HttpGet]
        public ActionResult ShowallEligibleStudents()
        {

            StudentAdmission model = new StudentAdmission();

            DataBaseAcessLayer.EmployeeDetailsDB dbhandle = new DataBaseAcessLayer.EmployeeDetailsDB();
            if (Session["Employee_Id"] == null)
            {
                return Redirect("~/Employee/EmployeeLogin");
            }
            else
            {
                model.Section_Name = PopulateDropDown("SELECT Section_Id,Section_Name FROM School_Section_Master ", "Section_Name", "Section_Id");

                return View(dbhandle.GetEligibleStuentDetails());
                //model.StudentDetails = dbhandle.GetEligibleStuentDetails();
                //return View(model);
            }
        }


        [HttpPost]
        public JsonResult AjaxMethod_SectionList(string type, int Class_Id)
        {
            StudentSyllabus model = new StudentSyllabus();
            switch (type)
            {
                case "Class_Id":

                  //  model.SubjectList = PopulateDropDown("SELECT Subject_id, Subject_Name FROM School_Subject_Master WHERE School_Code='" + Session["School_Code"] + "' AND Class_Id='" + value + "' AND Exam_Sub_Type='Theory' ", "Subject_Name", "Subject_id");
                    // break;

                    // case "Period_Id":

                    model.SectionList = PopulateDropDown("SELECT Section_Id, Section_Name FROM School_Section_Master WHERE School_Code ='" + Session["School_Code"] + "' AND Class_Id ='" + Class_Id + "' ", "Section_Name", "Section_Id");

                  //  model.ExamList = PopulateDropDown("SELECT Exam_Term_id, Exam_Term_Name FROM School_Exam_Term_Master WHERE School_Code='" + Session["School_Code"] + "'", "Exam_Term_Name", "Exam_Term_id");

                    break;

            }
            return Json(model);
        }

        /*  public ActionResult ShowallEligibleStudentsDetails(int id)
         {

             DataBaseAcessLayer.EmployeeDetailsDB dbhandle = new DataBaseAcessLayer.EmployeeDetailsDB();
             StudentRegistrationDetails model = new StudentRegistrationDetails();

             model.StudentDetails = dbhandle.GetEligibleStuentDetails().Where(smodel => smodel.Student_Id == id);

             model.StudentFeesDetails = dbhandle.GetAllFees();


             return View(model);
         }*/

        public ActionResult ShowallEligibleStudentsDetails(int id)
        {

            DataBaseAcessLayer.EmployeeDetailsDB dbhandle = new DataBaseAcessLayer.EmployeeDetailsDB();
            //StudentRegistrationDetails model = new StudentRegistrationDetails();

            // model.StudentDetails = dbhandle.GetEligibleStuentDetails().Where(smodel => smodel.Student_Id == id);

            //  model.StudentFeesDetails = dbhandle.GetAllFees();
            if (Session["Employee_Id"] == null)
            {
                return Redirect("~/Employee/EmployeeLogin");
            }
            else
            {
                return View(dbhandle.GetEligibleStuentDetails().Find(smodel => smodel.Student_Id == id));
                // return View(dbhandle.GetEligibleStuentDetails().Find(smodel => smodel.Student_Id == id));

            }
        }




        [HttpPost]
        public JsonResult AjaxMethod(string Schoolcode, int Classid)
        {

            List<SchoolFeesAdd> FeeList = new List<SchoolFeesAdd>();
            String con = ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);

            try {
                string sqlquery = "SELECT * FROM [dbo].[School_Fees_Master] WHERE School_Code ='" + Schoolcode + "' AND Class_Id = '" + Classid + "' ";///WHERE ST_Section = '"+ value + "'
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
                    new SchoolFeesAdd
                    {
                        Fees_Id = Convert.ToInt32(dr["id"]),
                        School_Code = Convert.ToString(dr["School_Code"]),
                        Fees_Name = Convert.ToString(dr["Fees_Name"]),
                        Fees_Desc = Convert.ToString(dr["Fees_Desc"]),
                        Amount = Convert.ToString(dr["Amount"])

                    });
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

            }
            return Json(FeeList, JsonRequestBehavior.AllowGet);


        }


        [HttpPost]
        public ActionResult TookStudentadmission(StudentFeesDetails smodel, int[] Fees_Idd, String[] School_codee, String[] Fees_Namee, String[] Fees_Descc, String[] Amountt, String[] Paid_Statuss, String remark_notee, FormCollection fc)
        {
            if (Session["Employee_Id"] == null)
            {
                return Redirect("~/Employee/EmployeeLogin");
            }
            else
            {

                if (ModelState.IsValid)
                {
                    List<StudentFeesDetails> FeeList = new List<StudentFeesDetails>();

                    DataBaseAcessLayer.EmployeeDetailsDB dbhandle = new DataBaseAcessLayer.EmployeeDetailsDB();

                    try
                    {
                        //   string[] arrayIds = idproof_val.Split(',');

                        //  foreach (string item in idproof_vall)
                        // {
                        //  var id = item;

                        //  foreach (var f in idproof_val)
                        //   {
                        //   foreach (StudentFeesDetails smodel in smodel.FeeList)
                        // {idproof_val  
                        //for (var i = 0; i < smodel.FeeListt.Count(); i++)

                        smodel.School_Code = Convert.ToString(Session["School_Code"]);
                        smodel.Student_Id = Convert.ToInt32(fc["Student_Id"]);
                        smodel.Class_Id = Convert.ToInt32(fc["Class_Id"]);
                        smodel.Section_Id = Convert.ToInt32(fc["Class_Id"]);
                        dbhandle.UpdateStudentDetails(smodel);
                        int j = 1;
                        for (var i = 0; i < Fees_Idd.Length; i++)
                        {

                            /* smodel.Fees_Id = fc["FeeList[i].['Fees_Id']"];
                                 smodel.Fees_Name = fc["FeeList[i].['Fees_Name']"];
                                 smodel.Fees_Desc = fc["FeeList[i].['Fees_Desc']"];
                                 smodel.Amount = fc["FeeList[i].['Amount']"];
                                 smodel.remark_note = fc["FeeList[i].['remark_note']"];
                                 smodel.Amount = fc["FeeList[i].['Amount']"];
                                 smodel.School_Code = fc["School_Code"];
                                 smodel.Student_Id = Convert.ToInt32(fc["Student_Id"]);
                                 smodel.Class_Id = Convert.ToInt32(fc["Class_Id"]);*/


                            //  smodel.Fees_Name = fc["Fees_Name"][i];
                            /*  smodel.Fees_Id = fee.Fees_Id;
                              smodel.Fees_Name = fee.Fees_Name;
                              smodel.Fees_Desc = fee.Fees_Desc;
                              smodel.Amount = fee.Amount;                   
                              smodel.remark_note = fee.remark_note;*/

                            // smodel.Fees_Id = Convert.ToInt32(Fees_Idd[i]);
                            smodel.Fees_Id = Convert.ToString(Fees_Idd[i]);
                            smodel.School_Code = School_codee[i];
                            smodel.Student_Id = Convert.ToInt32(fc["Student_Id"]);
                            smodel.Class_Id = Convert.ToInt32(fc["Class_Id"]);
                            smodel.Fees_Name = Fees_Namee[i];
                            smodel.Fees_Desc = Fees_Descc[i];
                            smodel.Amount = Amountt[i];
                            smodel.Paid_Status = Paid_Statuss[i];
                            // if (!String.IsNullOrEmpty(remark_notee[i])) {
                            //String remark_notte = "";
                            //remark_notte = fc["remark_notee" + j];

                            if (!String.IsNullOrEmpty(fc["remark_notee" + j]))
                            {

                            smodel.remark_note = fc["remark_notee" + j];

                            }
                            j++;

                            dbhandle.UpdateFeesDetails(smodel);
                        }

                       
                    }
                    catch (Exception ex)
                    {
                        ViewBag.Error = ex.Message;

                    }

                    TempData["msg"] = "Fees  Details Updated Successfully!";
                    return this.RedirectToAction("ShowallEligibleStudents", "Employee");
                }
                return View(smodel);
            }

        }


        [HttpGet]
        public ActionResult StudentMarksEntry()
        {

            if (Session["Employee_Id"] == null)
            {
                return Redirect("~/Employee/EmployeeLogin");
            }
            else
            {
                StudentMarks model = new StudentMarks();
                //    model.ExamType_Name = PopulateDropDown("SELECT Exam_Term_id, Exam_Term_Name FROM School_Exam_Term_Master  WHERE School_Code='" + Session["School_Code"] + "'", "Exam_Term_Name", "Exam_Term_id");

                model.Class_Name = PopulateDropDown("SELECT Class_Id, Class_Name FROM Class_Master WHERE School_Code='" + Session["School_Code"] + "'", "Class_Name", "Class_Id");
                model.Year_Name = PopulateDropDown("SELECT Year, Year_Name FROM Year", "Year_Name", "Year");

                // model.Section_Name = PopulateDropDown("SELECT Section_Name, Section_Id FROM School_Section_Master WHERE School_Code='"+Session["School_Code"] +"'", "Section_Name", "Section_Id");

                return View(model);
            }
        }


        [HttpPost]
        //  public ActionResult StudentMarksEntry(StudentMarks smodel,  String[] School_codee, int[] Student_Idd, int[] Class_Idd, String[] Class_Namee, int[] Section_Idd, String[] Section_Namee, String[] student_markss, FormCollection fc)
        public ActionResult StudentMarksEntry(StudentMarks smodel, FormCollection fc, String[] School_codee, int[] Class_Idd, String[] Class_Namee, int[] ExamTerm_Idd, String[] Section_Namee, String[] Session_Yearr, int[] Subject_Id, String[] student_markss, int[] Student_Idd)
        {
            if (Session["Employee_Id"] == null)
            {
                return Redirect("~/Employee/EmployeeLogin");
            }
            else
            {
                StudentMarks model = new StudentMarks();


                //try
                //{
                DataBaseAcessLayer.EmployeeDetailsDB dbhandle = new DataBaseAcessLayer.EmployeeDetailsDB();

                for (var i = 0; i < student_markss.Length; i++)
                {

                    // smodel.School_Code = Convert.ToString(Session["School_Code"]);
                    // smodel.Student_Id = Convert.ToInt32(fc["Student_Idd"]);
                    //smodel.Class_Id = System.Convert.ToInt32(fc["Class_Id"]);                        

                    //smodel.Section_Nam = Convert.ToString(fc["Section_Name"]);
                    //smodel.ExamType_Id = Convert.ToInt32(fc["ExamTeype_Id"]);
                    //smodel.Exam_Year = Convert.ToString(fc["Exam_Year"]);


                    //smodel.School_Code = student_markss[i];
                    smodel.Student_Id = Student_Idd[i];
                    smodel.Class_Id = Class_Idd[i];
                    smodel.Section_Nam = Section_Namee[i];
                    smodel.ExamType_Id = ExamTerm_Idd[i];
                    smodel.Session_Year = Session_Yearr[i];
                    smodel.Subject_Id = Subject_Id[i];
                    smodel.student_marks = student_markss[i];


                    dbhandle.AddStudentMarks(smodel);
                }

                //  }
                //catch (Exception ex)
                //{
                //    ViewBag.Error = ex.Message;

                //}

                TempData["msg"] = "Marks Entry done Successfully!";
                return this.RedirectToAction("StudentMarksEntry", "Employee");

            }
            ///  return View(smodel);
        }

        [HttpGet]
        public ActionResult ViewStudentMarks()
        {

            if (Session["Employee_Id"] == null)
            {
                return Redirect("~/Employee/EmployeeLogin");
            }
            else
            {
                StudentMarks model = new StudentMarks();
                model.ExamType_Name = PopulateDropDown("SELECT Exam_Term_id, Exam_Term_Name FROM School_Exam_Term_Master", "Exam_Term_Name", "Exam_Term_id");

                model.Class_Name = PopulateDropDown("SELECT Class_Id, Class_Name FROM Class_Master", "Class_Name", "Class_Id");
                model.Year_Name = PopulateDropDown("SELECT Year, Year_Name FROM Year", "Year_Name", "Year");

                //  model.Section_Name = PopulateDropDown("SELECT Section_Id, Section_Name FROM School_Section_Master WHERE School_Code='" + Session["School_Code"] + "'", "Section_Name", "Section_Id");

                return View(model);
            }
        }
        [HttpPost]
        public JsonResult AjaxMethod_studentList(string type, int value, int Section_Id = 0)
        {
            StudentMarks model = new StudentMarks();
            switch (type)
            {
                case "Class_Id":
                    if (Section_Id == 0)
                    //  if(String.IsNullOrEmpty(Section_Id))
                    {
                        model.StudentList = PopulateDropDown("SELECT Student_Id,   Isnull(first_name, '') + ' ' + Isnull(middle_name, '') + ' ' + Isnull(last_name, '') AS first_name FROM School_Student_Details WHERE  School_Code='" + Session["School_Code"] + "' AND AdmissionClass_Id=" + value, "first_name", "Student_Id");
                        model.Section_Name = PopulateDropDown("SELECT Section_Id, Section_Name FROM School_Section_Master WHERE School_Code='" + Session["School_Code"] + "'   AND Class_Id='" + value + "' ", "Section_Name", "Section_Id");
                        model.ExamType_Name = PopulateDropDown("SELECT Exam_Term_id, Exam_Term_Name FROM School_Exam_Term_Master WHERE School_Code='" + Session["School_Code"] + "' AND Class_Id='" + value + "' ", "Exam_Term_Name", "Exam_Term_id");

                    }
                    else
                    {
                        model.StudentList = PopulateDropDown("SELECT Student_Id,  Isnull(first_name, '') + ' ' + Isnull(middle_name, '') + ' ' + Isnull(last_name, '') AS first_name FROM School_Student_Details WHERE  School_Code='" + Session["School_Code"] + "' AND Section_Id='" + Section_Id + "' AND AdmissionClass_Id = " + value, "first_name", "Student_Id");
                        model.Section_Name = PopulateDropDown("SELECT Section_Id, Section_Name FROM School_Section_Master WHERE School_Code='" + Session["School_Code"] + "' AND Class_Id='" + value + "' ", "Section_Name", "Section_Id");
                        model.ExamType_Name = PopulateDropDown("SELECT Exam_Term_id, Exam_Term_Name FROM School_Exam_Term_Master WHERE School_Code='" + Session["School_Code"] + "' AND Class_Id='" + value + "' ", "Exam_Term_Name", "Exam_Term_id");

                    }

                    break;
                case "Section_Id":
                    model.StudentList = PopulateDropDown("SELECT Student_Id,  Isnull(first_name, '') + ' ' + Isnull(middle_name, '') + ' ' + Isnull(last_name, '') AS first_name FROM School_Student_Details WHERE  School_Code='" + Session["School_Code"] + "' AND Section_Id='" + Section_Id + "' AND AdmissionClass_Id = " + value, "first_name", "Student_Id");
                    model.Section_Name = PopulateDropDown("SELECT Section_Id, Section_Name FROM School_Section_Master WHERE School_Code='" + Session["School_Code"] + "' AND Class_Id='" + value + "' ", "Section_Name", "Section_Id");
                    model.ExamType_Name = PopulateDropDown("SELECT Exam_Term_id, Exam_Term_Name FROM School_Exam_Term_Master WHERE School_Code='" + Session["School_Code"] + "' AND Class_Id='" + value + "' ", "Exam_Term_Name", "Exam_Term_id");

                    break;
            }
            return Json(model);
        }


        [HttpPost]
        public JsonResult AjaxMethod_FetchStudentMarks(String examtype_id, String year_name, int class_id, int student_id, int Section_Id = 0, String rollnumber = null)
        {
            String School_Code = Session["School_Code"].ToString();

            //if (Session["Employee_Id"] == null)
            //{
            //    return Redirect("~/Employee/EmployeeLogin");

            //}
            //else
            //{

            //  SchoolRegistration model = new SchoolRegistration();
            List<StudentMarks> StudentMarksList = new List<StudentMarks>();
            String con = ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            try
            {
                //string sqlquery = "SELECT SM.*,CM.*, SSD.*, Isnull(SSD.first_name, '') + ' ' + Isnull(SSD.middle_name, '') + ' ' + Isnull(SSD.last_name, '') AS FullName FROM School_Student_Details AS SSD, School_Section_Master AS SSM , Class_Master AS CM WHERE SSD.School_Code=SSM.School_Code  AND SSD.AdmissionClass_Id =CM.Class_Id AND SSD.SectionName=SSM.Section_Name AND SSD.School_Code = '" + School_Code + "' AND  SSD.AdmissionClass_Id = '" + ClassName + "' AND SSM.Section_Name='" + SectionName + "' ";
                string sqlquery = "SELECT SSM.*,SM.* FROM Student_Score_Master AS SSM,School_Subject_Master AS SM WHERE SSM.School_Code=SM.School_Code AND SSM.Subject_Id=SM.Subject_Id AND  SM.School_Code='" + Session["School_Code"] + "' AND SSM.Session_Year='" + year_name + "' AND SSM.ExamTerm_Id='" + examtype_id + "' AND SSM.Class_Id='" + class_id + "' AND SSM.Student_Id='" + student_id + "' ";
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
                    StudentMarksList.Add(
                        new StudentMarks
                        {

                            Subject_Name = String.IsNullOrEmpty(sdr["Subject_Name"].ToString()) ? null : sdr["Subject_Name"].ToString(),
                            Subject_Type = String.IsNullOrEmpty(sdr["Subject_Type"].ToString()) ? null : sdr["Subject_Type"].ToString(),
                            Exam_Subject_Type = String.IsNullOrEmpty(sdr["Exam_Sub_Type"].ToString()) ? null : sdr["Exam_Sub_Type"].ToString(),
                            priority_val = String.IsNullOrEmpty(sdr["Priority_Value"].ToString()) ? 0 : Convert.ToInt32(sdr["Priority_Value"].ToString()),
                            FullMarks = String.IsNullOrEmpty(sdr["FullMarks"].ToString()) ? 0 : Convert.ToInt32(sdr["FullMarks"].ToString()),
                            PassMarks = String.IsNullOrEmpty(sdr["PassMarks"].ToString()) ? 0 : Convert.ToInt32(sdr["PassMarks"].ToString()),
                            PracticalMarks = String.IsNullOrEmpty(sdr["PracticalMarks"].ToString()) ? 0 : Convert.ToInt32(sdr["PracticalMarks"].ToString()),
                            Additional_Subject = String.IsNullOrEmpty(sdr["AdditionalSubject"].ToString()) ? null : sdr["AdditionalSubject"].ToString(),

                            Score = String.IsNullOrEmpty(sdr["Score"].ToString()) ? '0' : Convert.ToInt32(sdr["Score"])

                        });
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

            }
            return Json(StudentMarksList, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public JsonResult AjaxMethod_FetchStudent(int Class_Id, String Section_Id)
        {
            String School_Code = Session["School_Code"].ToString();

            //if (Session["Employee_Id"] == null)
            //{
            //    return Redirect("~/Employee/EmployeeLogin");

            //}
            //else
            //{

            //  SchoolRegistration model = new SchoolRegistration();
            List<StudentAllList> StuentList = new List<StudentAllList>();
            String con = ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            try
            {
                string sqlquery = "SELECT SSM.*,CM.*, SSD.*, Isnull(SSD.first_name, '') + ' ' + Isnull(SSD.middle_name, '') + ' ' + Isnull(SSD.last_name, '') AS FullName FROM School_Student_Details AS SSD, School_Section_Master AS SSM , Class_Master AS CM WHERE SSD.School_Code=SSM.School_Code  AND SSD.AdmissionClass_Id =CM.Class_Id AND SSD.Section_Id=SSM.Section_Id AND SSD.School_Code = '" + School_Code + "' AND  SSD.AdmissionClass_Id = '" + Class_Id + "' AND SSM.Section_Id='" + Section_Id + "' ";


                //  string sqlquery = "SELECT SSM.*,CM.*, SSD.*, Isnull(SSD.first_name, '') + ' ' + Isnull(SSD.middle_name, '') + ' ' + Isnull(SSD.last_name, '') AS FullName FROM School_Student_Details AS SSD, School_Section_Master AS SSM , Class_Master AS CM WHERE SSD.School_Code=SSM.School_Code  AND SSD.AdmissionClass_Id =CM.Class_Id AND SSD.SectionName=SSM.Section_Name AND SSD.School_Code = '" + School_Code + "' AND  SSD.AdmissionClass_Id = '" + ClassName + "' AND SSM.Section_Name='" + SectionName +"' ";

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
                            Parent_Id = String.IsNullOrEmpty(sdr["Parent_Id"].ToString()) ? '0' : Convert.ToInt32(sdr["Parent_Id"]),
                            School_Code = String.IsNullOrEmpty(sdr["School_Code"].ToString()) ? null : sdr["School_Code"].ToString(),
                            CountryId = String.IsNullOrEmpty(sdr["CountryId"].ToString()) ? '0' : Convert.ToInt32(sdr["CountryId"]),
                            StateId = String.IsNullOrEmpty(sdr["StateId"].ToString()) ? '0' : Convert.ToInt32(sdr["StateId"]),
                            CityId = String.IsNullOrEmpty(sdr["CityId"].ToString()) ? '0' : Convert.ToInt32(sdr["CityId"]),
                            CitizenCountryId = String.IsNullOrEmpty(sdr["CitizenCountryId"].ToString()) ? '0' : Convert.ToInt32(sdr["CitizenCountryId"]),
                            IdProof_Id = String.IsNullOrEmpty(sdr["IdProof_Id"].ToString()) ? '0' : Convert.ToInt32(sdr["IdProof_Id"]),
                            Gender_Id = String.IsNullOrEmpty(sdr["Gender_Id"].ToString()) ? '0' : Convert.ToInt32(sdr["Gender_Id"]),
                            BloodGroup_Id = String.IsNullOrEmpty(sdr["BloodGroup_Id"].ToString()) ? '0' : Convert.ToInt32(sdr["BloodGroup_Id"]),





                            FullName = String.IsNullOrEmpty(sdr["FullName"].ToString()) ? null : sdr["FullName"].ToString(),
                            first_name = String.IsNullOrEmpty(sdr["first_name"].ToString()) ? null : sdr["first_name"].ToString(),
                            middle_name = String.IsNullOrEmpty(sdr["middle_name"].ToString()) ? null : sdr["middle_name"].ToString(),
                            last_name = String.IsNullOrEmpty(sdr["last_name"].ToString()) ? null : sdr["last_name"].ToString(),

                            CurrentAddress1 = String.IsNullOrEmpty(sdr["CurrentAddress1"].ToString()) ? null : sdr["CurrentAddress1"].ToString(),
                            CurrentAddress2 = String.IsNullOrEmpty(sdr["CurrentAddress2"].ToString()) ? null : sdr["CurrentAddress2"].ToString(),
                            currentzipcode = String.IsNullOrEmpty(sdr["currentzipcode"].ToString()) ? null : sdr["currentzipcode"].ToString(),
                            PermanentAddress1 = String.IsNullOrEmpty(sdr["PermanentAddress1"].ToString()) ? null : sdr["PermanentAddress1"].ToString(),
                            PermanentAddress2 = String.IsNullOrEmpty(sdr["PermanentAddress2"].ToString()) ? null : sdr["PermanentAddress2"].ToString(),
                            permanentzipcode = String.IsNullOrEmpty(sdr["permanentzipcode"].ToString()) ? null : sdr["permanentzipcode"].ToString(),

                            BirthCertificate_Name = String.IsNullOrEmpty(sdr["BirthCertificate_Name"].ToString()) ? null : sdr["BirthCertificate_Name"].ToString(),

                            BirthCertificatePath = String.IsNullOrEmpty(sdr["BirthCertificatePath"].ToString()) ? null : sdr["BirthCertificatePath"].ToString(),
                            Special_Care = String.IsNullOrEmpty(sdr["Special_Care"].ToString()) ? '0' : Convert.ToInt32(sdr["Special_Care"]),
                            Special_Care_Description = String.IsNullOrEmpty(sdr["Special_Care_Description"].ToString()) ? null : sdr["Special_Care_Description"].ToString(),
                            Disability = String.IsNullOrEmpty(sdr["Disability"].ToString()) ? '0' : Convert.ToInt32(sdr["Disability"]),
                            Disability_Percentage = String.IsNullOrEmpty(sdr["Disability_Percentage"].ToString()) ? null : sdr["Disability_Percentage"].ToString(),
                            Disability_Description = String.IsNullOrEmpty(sdr["Disability_Description"].ToString()) ? null : sdr["Disability_Description"].ToString(),
                            Disability_Certificate_Number = String.IsNullOrEmpty(sdr["Disability_Certificate_Number"].ToString()) ? null : sdr["Disability_Certificate_Number"].ToString(),
                            DisabilityCertificat_Name = String.IsNullOrEmpty(sdr["DisabilityCertificat_Name"].ToString()) ? null : sdr["DisabilityCertificat_Name"].ToString(),
                            DisabilityCertificatePath = String.IsNullOrEmpty(sdr["DisabilityCertificatePath"].ToString()) ? null : sdr["DisabilityCertificatePath"].ToString(),
                            DOB = String.IsNullOrEmpty(sdr["DOB"].ToString()) ? null : sdr["DOB"].ToString(),
                            POB = String.IsNullOrEmpty(sdr["POB"].ToString()) ? null : sdr["POB"].ToString(),
                            BCN = String.IsNullOrEmpty(sdr["BCN"].ToString()) ? null : sdr["BCN"].ToString(),
                            IdProof_Number = String.IsNullOrEmpty(sdr["IdProof_Number"].ToString()) ? null : sdr["IdProof_Number"].ToString(),
                            PassPort_Number = String.IsNullOrEmpty(sdr["PassPort_Number"].ToString()) ? null : sdr["PassPort_Number"].ToString(),


                            FatherName = String.IsNullOrEmpty(sdr["FatherName"].ToString()) ? null : sdr["FatherName"].ToString(),
                            FatherContactNumber = String.IsNullOrEmpty(sdr["FatherContactNumber"].ToString()) ? null : sdr["FatherContactNumber"].ToString(),
                            FatherEmail = String.IsNullOrEmpty(sdr["FatherEmail"].ToString()) ? null : sdr["FatherEmail"].ToString(),
                            MotherName = String.IsNullOrEmpty(sdr["MotherName"].ToString()) ? null : sdr["MotherName"].ToString(),
                            MotherContactNumber = String.IsNullOrEmpty(sdr["MotherContactNumber"].ToString()) ? null : sdr["MotherContactNumber"].ToString(),
                            MotherEmail = String.IsNullOrEmpty(sdr["MotherEmail"].ToString()) ? null : sdr["MotherEmail"].ToString(),
                            HomeContactNumber = String.IsNullOrEmpty(sdr["HomeContactNumber"].ToString()) ? null : sdr["HomeContactNumber"].ToString(),
                            LocalGurdianValue = String.IsNullOrEmpty(sdr["LocalGurdianValue"].ToString()) ? null : sdr["LocalGurdianValue"].ToString(),
                            LocalGurdianEmail = String.IsNullOrEmpty(sdr["LocalGurdianEmail"].ToString()) ? null : sdr["LocalGurdianEmail"].ToString(),
                            LocalGurdianName = String.IsNullOrEmpty(sdr["LocalGurdianName"].ToString()) ? null : sdr["LocalGurdianName"].ToString(),
                            LocalGurdianPhone = String.IsNullOrEmpty(sdr["LocalGurdianPhone"].ToString()) ? null : sdr["LocalGurdianPhone"].ToString(),


                            AdmissionClass_Id = String.IsNullOrEmpty(sdr["AdmissionClass_Id"].ToString()) ? '0' : Convert.ToInt32(sdr["AdmissionClass_Id"]),
                            Last_School_Name = String.IsNullOrEmpty(sdr["Last_School_Name"].ToString()) ? null : sdr["Last_School_Name"].ToString(),
                            SchoolBoard_Id = String.IsNullOrEmpty(sdr["SchoolBoard_Id"].ToString()) ? '0' : Convert.ToInt32(sdr["SchoolBoard_Id"]),
                            Last_School_Year = String.IsNullOrEmpty(sdr["Last_School_Year"].ToString()) ? null : sdr["Last_School_Year"].ToString(),
                            Last_School_Class = String.IsNullOrEmpty(sdr["Last_School_Class"].ToString()) ? null : sdr["Last_School_Class"].ToString(),
                            School_Transfer_Certifiate_Number = String.IsNullOrEmpty(sdr["School_Transfer_Certifiate_Number"].ToString()) ? null : sdr["School_Transfer_Certifiate_Number"].ToString(),
                            SchoolTransferCertificate_Name = String.IsNullOrEmpty(sdr["SchoolTransferCertificate_Name"].ToString()) ? null : sdr["SchoolTransferCertificate_Name"].ToString(),
                            SchoolTransferCertificatePath = String.IsNullOrEmpty(sdr["SchoolTransferCertificatePath"].ToString()) ? null : sdr["SchoolTransferCertificatePath"].ToString(),
                            Last_School_Exam_Marks = String.IsNullOrEmpty(sdr["Last_School_Exam_Marks"].ToString()) ? null : sdr["Last_School_Exam_Marks"].ToString(),
                            Last_School_Total_Marks = String.IsNullOrEmpty(sdr["Last_School_Total_Marks"].ToString()) ? null : sdr["Last_School_Total_Marks"].ToString(),
                            Last_School_Marks_Percentage = String.IsNullOrEmpty(sdr["Last_School_Marks_Percentage"].ToString()) ? null : sdr["Last_School_Marks_Percentage"].ToString(),
                            FinalExamResult_Name = String.IsNullOrEmpty(sdr["FinalExamResult_Name"].ToString()) ? null : sdr["FinalExamResult_Name"].ToString(),
                            FinalExamResultPath = String.IsNullOrEmpty(sdr["FinalExamResultPath"].ToString()) ? null : sdr["FinalExamResultPath"].ToString(),
                            Board_Exam_Marks = String.IsNullOrEmpty(sdr["Board_Exam_Marks"].ToString()) ? null : sdr["Board_Exam_Marks"].ToString(),
                            Board_Total_Marks = String.IsNullOrEmpty(sdr["Board_Total_Marks"].ToString()) ? null : sdr["Board_Total_Marks"].ToString(),
                            Marks_Percentage = String.IsNullOrEmpty(sdr["Marks_Percentage"].ToString()) ? null : sdr["Marks_Percentage"].ToString(),
                            Board_Certificate_Number = String.IsNullOrEmpty(sdr["Board_Certificate_Number"].ToString()) ? null : sdr["Board_Certificate_Number"].ToString(),
                            BoardExamCertificate_Name = String.IsNullOrEmpty(sdr["BoardExamCertificate_Name"].ToString()) ? null : sdr["BoardExamCertificate_Name"].ToString(),
                            BoardExamCertificatePath = String.IsNullOrEmpty(sdr["BoardExamCertificatePath"].ToString()) ? null : sdr["BoardExamCertificatePath"].ToString(),
                            BoardExamResultName = String.IsNullOrEmpty(sdr["BoardExamResultName"].ToString()) ? null : sdr["BoardExamResultName"].ToString(),
                            BoardExamResultPath = String.IsNullOrEmpty(sdr["BoardExamResultPath"].ToString()) ? null : sdr["BoardExamResultPath"].ToString(),
                            ImagePath = String.IsNullOrEmpty(sdr["ImagePath"].ToString()) ? null : sdr["ImagePath"].ToString(),
                            SignaturePath = String.IsNullOrEmpty(sdr["SignaturePath"].ToString()) ? null : sdr["SignaturePath"].ToString(),



                                //  Class_Id = String.IsNullOrEmpty(sdr["Class_Id"].ToString()) ? '0' : Convert.ToInt32(sdr["Class_Id"]),
                                Class_Name = String.IsNullOrEmpty(sdr["Class_Name"].ToString()) ? null : sdr["Class_Name"].ToString(),
                                //   Section_Id = String.IsNullOrEmpty(sdr["Section_Id"].ToString()) ? '0' : Convert.ToInt32(sdr["Section_Id"]),
                                Section_Name = String.IsNullOrEmpty(sdr["Section_Name"].ToString()) ? null : sdr["Section_Name"].ToString(),


                                // CountryName = String.IsNullOrEmpty(sdr["CountryName"].ToString()) ? null : sdr["CountryName"].ToString(),
                                // StateName = String.IsNullOrEmpty(sdr["StateName"].ToString()) ? null : sdr["StateName"].ToString(),
                                //  CityName = String.IsNullOrEmpty(sdr["CityName"].ToString()) ? null : sdr["CityName"].ToString(),
                                // IdProof_Name = String.IsNullOrEmpty(sdr["IdProof_Name"].ToString()) ? null : sdr["IdProof_Name"].ToString(),
                                // Board_Name = String.IsNullOrEmpty(sdr["Board_Name"].ToString()) ? null : sdr["Board_Name"].ToString(),
                                // Class_Name = String.IsNullOrEmpty(sdr["Class_Name"].ToString()) ? null : sdr["Class_Name"].ToString(),
                                // Application_Status = String.IsNullOrEmpty(sdr["Application_Status"].ToString()) ? null : sdr["Application_Status"].ToString()



                            });
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

            }
            return Json(StuentList, JsonRequestBehavior.AllowGet);
        }

        // }

        [HttpPost]
        public JsonResult AjaxMethod_AllStudentList(int ClassName, int SectionName)
        {
            String School_Code = Session["School_Code"].ToString();

            List<StudentAllList> StuentList = new List<StudentAllList>();
            String con = ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            //try
            //{
            string sqlquery = "SELECT SSM.*,CM.*, SSD.*, Isnull(SSD.first_name, '') + ' ' + Isnull(SSD.middle_name, '') + ' ' + Isnull(SSD.last_name, '') AS FullName FROM School_Student_Details AS SSD, School_Section_Master AS SSM , Class_Master AS CM WHERE SSD.School_Code=SSM.School_Code  AND SSD.AdmissionClass_Id =CM.Class_Id AND SSD.Section_Id=SSM.Section_Id AND SSD.School_Code = '" + School_Code + "' AND  SSD.AdmissionClass_Id = '" + ClassName + "' AND SSM.Section_Id='" + SectionName + "' ";

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
                        Parent_Id = String.IsNullOrEmpty(sdr["Parent_Id"].ToString()) ? '0' : Convert.ToInt32(sdr["Parent_Id"]),
                        School_Code = String.IsNullOrEmpty(sdr["School_Code"].ToString()) ? null : sdr["School_Code"].ToString(),
                        FullName = String.IsNullOrEmpty(sdr["FullName"].ToString()) ? null : sdr["FullName"].ToString(),
                        Class_Name = String.IsNullOrEmpty(sdr["Class_Name"].ToString()) ? null : sdr["Class_Name"].ToString(),
                            //   Section_Id = String.IsNullOrEmpty(sdr["Section_Id"].ToString()) ? '0' : Convert.ToInt32(sdr["Section_Id"]),
                            Section_Name = String.IsNullOrEmpty(sdr["Section_Name"].ToString()) ? null : sdr["Section_Name"].ToString(),






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
        public JsonResult AjaxMethod_StudentAttentdanceList(int ClassName, int SectionName, String Period_Name, String Period_Date)
        {
            String School_Code = Session["School_Code"].ToString();

            List<StudentAllList> StuentList = new List<StudentAllList>();
            String con = ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            //try
            //{
            // string sqlquery = "SELECT SSM.Sectiion_Name,CM.Class_Name, SSD.Student_Id, SSD.Parent_Id,Isnull(SSD.first_name, '') + ' ' + Isnull(SSD.middle_name, '') + ' ' + Isnull(SSD.last_name, '') AS FullName FROM School_Student_Details AS SSD,Student_Attendance AS SA, School_Section_Master AS SSM , Class_Master AS CM WHERE SSD.School_Code=SSM.School_Code  AND SSD.AdmissionClass_Id =CM.Class_Id AND SSD.Section_Id=SSM.Section_Id AND SSD.School_Code = '" + School_Code + "' AND  SSD.AdmissionClass_Id = '" + ClassName + "' AND SSM.Section_Id='" + SectionName + "' AND  ";
            string sqlquery = "SELECT SSM.Section_Name,CM.Class_Name,SSD.Roll_Number, SSD.Student_Id, SSD.Parent_Id,Isnull(SSD.first_name, '') + ' ' + Isnull(SSD.middle_name, '') + ' ' + Isnull(SSD.last_name, '') AS FullName ,SA.Att_Id,SA.Presence_Status,SA.Absent_Reasons FROM School_Student_Details AS SSD,Student_Attendance AS SA, School_Section_Master AS SSM , Class_Master AS CM WHERE SSD.School_Code=SSM.School_Code  AND SSD.AdmissionClass_Id =CM.Class_Id AND SSD.Section_Id=SSM.Section_Id AND SSD.Student_Id=SA.Student_Id AND SSD.School_Code = '" + School_Code + "' AND  SSD.AdmissionClass_Id = '" + ClassName + "' AND SSM.Section_Id='" + SectionName + "' AND   SA.Period_Name='" + Period_Name + "' AND SA.Period_Date= '" + Period_Date + "' ";

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
                        Att_Id = String.IsNullOrEmpty(sdr["Att_Id"].ToString()) ? '0' : Convert.ToInt32(sdr["Att_Id"]),
                        Roll_Number = String.IsNullOrEmpty(sdr["Roll_Number"].ToString()) ? '0' : Convert.ToInt32(sdr["Roll_Number"]),

                        Student_Id = String.IsNullOrEmpty(sdr["Student_Id"].ToString()) ? '0' : Convert.ToInt32(sdr["Student_Id"]),
                        Parent_Id = String.IsNullOrEmpty(sdr["Parent_Id"].ToString()) ? '0' : Convert.ToInt32(sdr["Parent_Id"]),
                        // School_Code = String.IsNullOrEmpty(sdr["School_Code"].ToString()) ? null : sdr["School_Code"].ToString(),
                        FullName = String.IsNullOrEmpty(sdr["FullName"].ToString()) ? null : sdr["FullName"].ToString(),
                        Class_Name = String.IsNullOrEmpty(sdr["Class_Name"].ToString()) ? null : sdr["Class_Name"].ToString(),
                        //   Section_Id = String.IsNullOrEmpty(sdr["Section_Id"].ToString()) ? '0' : Convert.ToInt32(sdr["Section_Id"]),
                        Section_Name = String.IsNullOrEmpty(sdr["Section_Name"].ToString()) ? null : sdr["Section_Name"].ToString(),
                        Absent_Reasons = String.IsNullOrEmpty(sdr["Absent_Reasons"].ToString()) ? null : sdr["Absent_Reasons"].ToString(),

                        Presence_Status = String.IsNullOrEmpty(sdr["Presence_Status"].ToString()) ? null : sdr["Presence_Status"].ToString(),






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
        public JsonResult AjaxMethod_FetchExamSubject(int ExamType_Id, String exam_year, int Class_Id, String Section_Id)
        {
            String School_Code = Session["School_Code"].ToString();

            List<CreateExamSchedule> SubjectList = new List<CreateExamSchedule>();
            String con = ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            try
            {
                //  string sqlquery = "SELECT SSM.*,CM.*, SSD.*, Isnull(SSD.first_name, '') + ' ' + Isnull(SSD.middle_name, '') + ' ' + Isnull(SSD.last_name, '') AS FullName FROM School_Student_Details AS SSD, School_Section_Master AS SSM , Class_Master AS CM WHERE SSD.School_Code=SSM.School_Code  AND SSD.AdmissionClass_Id =CM.Class_Id AND SSD.SectionName=SSM.Section_Name AND SSD.School_Code = '" + School_Code + "' AND  SSD.AdmissionClass_Id = '" + ClassName + "' AND SSM.Section_Name='" + SectionName + "' ";
                // string sqlquery = "SELECT ES.*,ETM.Exam_Term_Name,CM.Class_Name,SM.Section_Name,SSM.Subject_Name  FROM Exam_Schedule AS ES, Class_Master AS CM ,School_Exam_Term_Master AS ETM,School_Section_Master AS SM,School_Subject_Master AS SSM WHERE ES.School_Code ='" + School_Code + "'  AND ES.Class_Id = '" + ClassName + "' AND ES.ExamTerm_Id ='" + ExamType_Id + "' AND ES.Year ='" + exam_year + "' AND ES.ExamTerm_Id = ETM.Exam_Term_id AND ES.Class_Id = CM.Class_Id AND ES.Section_Id = SM.Section_Id AND ES.Subject_Id = SSM.Subject_Id";

                string sqlquery = "SELECT ES.*,ETM.Exam_Term_Name,CM.Class_Name,SM.Section_Name,SSM.Subject_Name  FROM Exam_Schedule AS ES, Class_Master AS CM ,School_Exam_Term_Master AS ETM,School_Section_Master AS SM,School_Subject_Master AS SSM WHERE ES.School_Code ='" + School_Code + "'  AND ES.Class_Id = '" + Class_Id + "' AND ES.ExamTerm_Id ='" + ExamType_Id + "' AND ES.Year ='" + exam_year + "' AND ES.ExamTerm_Id = ETM.Exam_Term_id AND ES.Class_Id = CM.Class_Id AND ES.Section_Id = SM.Section_Id AND ES.Subject_Id = SSM.Subject_Id";
                //  string sqlquery = "SELECT ES.*,ETM.Exam_Term_Name,CM.Class_Name,SM.Section_Name,SSM.Subject_Name  FROM Exam_Schedule AS ES, Class_Master AS CM ,School_Exam_Term_Master AS ETM,School_Section_Master AS SM,School_Subject_Master AS SSM WHERE ES.School_Code ='EC60JFWPWCVQ'  AND ES.Class_Id = '10' AND ES.ExamTerm_Id ='6' AND ES.Year ='2020' AND ES.ExamTerm_Id = ETM.Exam_Term_id  AND ES.Class_Id = CM.Class_Id AND ES.Section_Id = SM.Section_Id AND ES.Subject_Id = SSM.Subject_Id";
                sqlcon.Open();
                SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon);

                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = sqlcom;

                DataTable dt = new DataTable();

                //  sqlcon.Open();
                da.Fill(dt);

                sqlcon.Close();


                foreach (DataRow sdrr in dt.Rows)
                {

                    SubjectList.Add(
                        new CreateExamSchedule
                        {
                            // Student_Id = String.IsNullOrEmpty(sdr["Student_Id"].ToString()) ? '0' : Convert.ToInt32(sdr["Student_Id"]),
                            ExamSchedule_Id = Convert.ToInt32(sdrr["ExamSchedule_Id"]),
                            ExamTerm_Id = Convert.ToInt32(sdrr["ExamTerm_Id"]),
                            School_Code = Convert.ToString(sdrr["School_Code"]),
                            Exm_Term_Name = Convert.ToString(sdrr["Exam_Term_Name"]),
                            Year = Convert.ToString(sdrr["Year"]),
                            Class = Convert.ToString(sdrr["Class_Name"]),



                            Subject_id = Convert.ToInt32(sdrr["Subject_Id"]),
                            Subject_Namee = Convert.ToString(sdrr["Subject_Name"]),
                            //  Day_Namee = Convert.ToString(sdrr["Day_Name"]),
                            Exam_Date = Convert.ToString(sdrr["Exam_Date"]),


                            Start_Time = Convert.ToString(sdrr["Start_Time"]),
                            End_Time = Convert.ToString(sdrr["End_Time"]),




                        });
                }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

            }
            return Json(SubjectList, JsonRequestBehavior.AllowGet);

            // Data = FeeList, JsonRequestBehavior =
            //return Json(SubjectList, JsonRequestBehavior.AllowGet);
            //  return new JsonResult( Data = SubjectList, JsonRequestBehavior=JsonRequestBehavior.AllowGet);
            //return new JsonResult { Data = SubjectList, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }


        [HttpGet]
        public ActionResult AddStudentExamattendance()
        {
            if (Session["Employee_Id"] == null)
            {
                return Redirect("~/Employee/EmployeeLogin");
            }
            else
            {
                StudentMarks model = new StudentMarks();
                model.ExamType_Name = PopulateDropDown("SELECT Exam_Term_id, Exam_Term_Name FROM School_Exam_Term_Master", "Exam_Term_Name", "Exam_Term_id");

                model.Class_Name = PopulateDropDown("SELECT Class_Id, Class_Name FROM Class_Master", "Class_Name", "Class_Id");

                model.Section_Name = PopulateDropDown("SELECT Section_Id, Section_Name FROM School_Section_Master", "Section_Name", "Section_Id");

                return View(model);
            }
        }

        [HttpPost]
        public ActionResult AddStudentExamattendance(StudentMarks smodel, String[] School_codee, int[] Student_Idd, int[] Class_Idd, String[] Class_Namee, int[] Section_Idd, String[] Section_Namee, String[] student_markss, FormCollection fc)
        {

            StudentMarks model = new StudentMarks();
            if (Session["Employee_Id"] == null)
            {
                return Redirect("~/Employee/EmployeeLogin");
            }
            else
            {


                DataBaseAcessLayer.EmployeeDetailsDB dbhandle = new DataBaseAcessLayer.EmployeeDetailsDB();
                try
                {

                    for (var i = 0; i < student_markss.Length; i++)
                    {

                        //  smodel.Fees_Id = Convert.ToString(Fees_Idd[i]);
                        //smodel.School_Code = School_codee[i];
                        smodel.Student_Id = Student_Idd[i];
                        //  smodel.Class_Id = Convert.ToInt32(fc["Class_Id"]);

                        //   smodel.Class_Id = Class_Idd[i];
                        //  smodel.Class_Nam = Class_Namee[i];
                        //  smodel.Section_Id = Section_Idd[i];             
                        //   smodel.Section_Nam = Section_Namee[i];


                        smodel.student_marks = student_markss[i];
                        // String remark_notte = "remark_notee" + i;
                        //   remark_notte = Request["remark_notte"];

                        dbhandle.AddStudentMarks(smodel);
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;

                }
                TempData["msg"] = "Fees  Details Updated Successfully!";
                return this.RedirectToAction("StudentMarksEntry", "Employee");
            }

            ///  return View(smodel);
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


        //public ActionResult HomeWorkAssigned()
        //{
        //    Homework model = new Homework();


        //    model.Class_Name = PopulateDropDown("select Class_Id, Class_Name from Class_Master", "Class_Name", "Class_Id");

        //    model.Section_Name = PopulateDropDown("select Section_Id, Section_Name from School_Section_Master", "Section_Name", "Section_Id");
        //    model.Subject_Name = PopulateDropDown("select Distinct  Subject_Name, Subject_ID from School_Subject_Master ", "Subject_Name", "Subject_ID");


        //    return View(model);

        //}

        //[HttpPost]
        //public ActionResult HomeWorkAssigned(FormCollection fc, HttpPostedFileBase File_Name)
        //{
        //    SchoolAssignment model = new SchoolAssignment();

        //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
        //    SqlCommand cmd = new SqlCommand("HomeAssignment", con);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    ///cmd.Parameters.AddWithValue("@Student_Id", fc["Student_Id"]);
        //    cmd.Parameters.AddWithValue("@sub_id", fc["sub_id"]);
        //    cmd.Parameters.AddWithValue("@class_id", fc["class_id"]);
        //    cmd.Parameters.AddWithValue("@sec_id", fc["sec_id"]);
        //    cmd.Parameters.AddWithValue("@topic", fc["topic"]);
        //    cmd.Parameters.AddWithValue("@Home_Desc", fc["Home_Desc"]);
        //    cmd.Parameters.AddWithValue("@date_assigned", Convert.ToDateTime(fc["date_assigned"]));
        //    cmd.Parameters.AddWithValue("@due_date", Convert.ToDateTime(fc["due_date"]));
        //    cmd.Parameters.AddWithValue("@status", fc["status"]);



        //    cmd.Parameters.AddWithValue("@Query", 1);



        //    if (File_Name != null)
        //    {
        //        string fileName_bordexamcer = Path.GetFileNameWithoutExtension(File_Name.FileName);
        //        string extension = Path.GetExtension(File_Name.FileName);
        //        String flname = fileName_bordexamcer + extension;
        //        flname = fileName_bordexamcer + DateTime.Now.ToString("yymmssff") + extension;

        //        cmd.Parameters.AddWithValue("@File_Path", "../AppFiles/Images/");
        //        cmd.Parameters.AddWithValue("@File_Name", flname);

        //        File_Name.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), flname));

        //    }






        //    SqlDataAdapter sd = new SqlDataAdapter(cmd);
        //    con.Open();
        //    cmd.ExecuteNonQuery();
        //    con.Close();

        //    TempData["msg"] = "Information Successfully Inserted!";
        //    return this.RedirectToAction("HomeWorkAssigned", "Employee");


        //}

        [HttpGet]
        public ActionResult Add_Student_Attendance()
        {
            if (Session["Employee_Id"] == null)
            {
                return Redirect("~/Employee/EmployeeLogin");
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


        [HttpGet]
        public ActionResult Update_Attendance()
        {
            if (Session["Employee_Id"] == null)
            {
                return Redirect("~/Employee/EmployeeLogin");
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




        [HttpGet]
        public ActionResult View_Student_Attendance()
        {
            if (Session["Employee_Id"] == null)
            {
                return Redirect("~/Employee/EmployeeLogin");
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



        public JsonResult CheckAttendanceTaken(int Class_Id, int Section_Id, string Session_year, string Period_Date, String Period_Name)
        {
            //System.Threading.Thread.Sleep(200);
            //ParentRegistration model = new ParentRegistration();
            SchoolRegistration model = new SchoolRegistration();

            String con = ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            string sqlquery = "Select * FROM [dbo].[Student_Attendance] WHERE School_code='" + Session["School_code"] + "' AND Session_Year ='" + Session_year + "' AND Class_Id='" + Class_Id + "' AND Section_Id='" + Section_Id + "' AND Period_Date='" + Period_Date + "' AND Period_Name='" + Period_Name + "' ";
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
            string sqlquery = "SELECT  FullName,Student_Id, [First] As First_Period,[Second] AS Second_Period,[Third] AS Third_Period,[Fourth] AS Fourth_Period ,[Fifth] AS Fifth_Period,[Sixth] AS Sixth_Period ,[Seventh] AS Seventh_Period ,[Eighth] AS Eighth_Period ,[Nineth] AS Nineth_Period ,[Tenth] AS Tenth_Period   FROM (SELECT  Isnull(SSD.first_name, '') + ' ' + Isnull(SSD.middle_name, '') + ' ' + Isnull(SSD.last_name, '') AS FullName, SA.Student_Id, SA.[Period_Name], SA.Presence_Status FROM School_Student_Details AS SSD, Student_Attendance AS SA WHERE SA.School_Code = SSD.School_Code AND SSD.AdmissionClass_Id = SA.Class_Id AND SSD.Section_Id = SA.Section_Id AND SSD.Student_Id = SA.Student_Id AND SA.School_Code = '" + School_Code + "' AND  SA.Class_Id = '" + Class_Id + "' AND SSD.Section_Id ='" + Section_Id + "' AND  SA.Period_Date='" + Period_Date + "'  AND  SA.Session_Year='" + Session_year + "') Tab1 PIVOT (MAX(Presence_Status) FOR[Period_Name] IN([First],[Second],[Third],[Fourth],[Fifth],[Sixth],[Seventh],[Eighth],[Nineth],[Tenth]) ) AS Tab2 ORDER BY Tab2.Student_Id";

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



        [HttpPost]
        public JsonResult AjaxMethod_PeriodList(string type, int value, String Section_Id)
        {
            StudentAttendance model = new StudentAttendance();
            switch (type)
            {
                case "Class_Id":

                    model.PeriodList = PopulateDropDown("SELECT Period_Name, Period_Name FROM Period_Master WHERE School_Code='" + Session["School_Code"] + "' AND Class_Id='" + value + "' ", "Period_Name", "Period_Name");
                    // break;

                    // case "Period_Id":

                    model.SectionList = PopulateDropDown("SELECT Section_Id, Section_Name FROM School_Section_Master WHERE School_Code ='" + Session["School_Code"] + "' AND Class_Id ='" + value + "' ", "Section_Name", "Section_Id");
                    break;

            }
            return Json(model);
        }

        [HttpPost]
        public ActionResult Add_Student_Attendance(StudentAttendance smodel, FormCollection fc, String[] Session_Year, String[] School_codee, int[] Student_Idd, String[] Period_Namee, int[] Class_Idd, String[] Class_Namee, int[] Section_Idd, int[] Subject_Id, int[] Period_Idd, String[] Period_Date, String[] present_statuss, String[] Absent_Reasons)
        {
            if (Session["Employee_Id"] == null)
            {
                return Redirect("~/Employee/EmployeeLogin");
            }
            else
            {
                StudentAttendance model = new StudentAttendance();


                try
                {
                    DataBaseAcessLayer.EmployeeDetailsDB dbhandle = new DataBaseAcessLayer.EmployeeDetailsDB();
                    var p = 1;
                    for (int i = 0; i < Student_Idd.Length; i++)
                    {
                        //  p = p + i;
                        smodel.Session_Year = Session_Year[i];
                        smodel.Student_Id = Student_Idd[i];
                        smodel.Class_Id = Class_Idd[i];
                        smodel.Section_Id = Section_Idd[i];
                        smodel.Period_Name = Period_Namee[i];
                        smodel.Period_Date = Period_Date[i];
                        // smodel.Employee_Id = Convert.ToInt32(Session["Employee_Id"]);
                        if (fc["present_status" + p] == "on")
                        {
                            smodel.Presence_Status = "Present";
                        }
                        else
                        {
                            smodel.Presence_Status = "Absent";

                        }

                        if (!String.IsNullOrEmpty(fc["Absent_Reasons" + p])) {
                            smodel.Absent_Reasons = fc["Absent_Reasons" + p];
                        }
                        else
                        {
                            smodel.Absent_Reasons = "NA";
                        }

                        dbhandle.AddStudentAttendance(smodel);
                        p++;

                    }

                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;

                }

                TempData["msg"] = "Attendsnce Inserted done Successfully!";
                return this.RedirectToAction("Add_Student_Attendance", "Employee");
                //return View(smodel);
            }

        }

        // [HttpPost]
        public JsonResult Update_Student_Attendance(FormCollection fc, int Attendance_Id, String Presence_Status, String Absent_Reasons)
        {

            StudentAttendance model = new StudentAttendance();
            if (String.IsNullOrEmpty(Absent_Reasons))
            {
                Absent_Reasons = "NA";
            }
            //else
            //{
            //    model.Presence_Status = "Absent";

            //}
            //  SchoolRegistration model = new SchoolRegistration();

            String con = ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            string sqlquery = "UPDATE [dbo].[Student_Attendance] SET Presence_Status = '" + Presence_Status + "',Absent_Reasons='" + Absent_Reasons + "' WHERE Att_Id='" + Attendance_Id + "' ";
            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon);
            //SqlDataAdapter da = new SqlDataAdapter();
            //da.SelectCommand = sqlcom;
            //DataSet ds = new DataSet();
            //da.Fill(ds);

            //SqlDataReader sdr = sqlcom.ExecuteReader();

            int i = sqlcom.ExecuteNonQuery();
            sqlcon.Close();
            if (i >= 1)
            //  if (sdr.Read())
            {
                return Json(1);
            }
            else
            {
                return Json(0);
            }

        }

        //////////////////////////////Home Work//////////////////////////////////////////////
        ///controller function

         [HttpGet]
        public ActionResult HomeWorkAssigned(int id)
        {

            //Employee / EmployeeLogin
            if (Session["School_Code"] == null)
            {
                return Redirect("~/Employee/EmployeeLogin");
            }

            else
            {


                Homework model = new Homework();
                model.id = id;

                model.Class_Name = PopulateDropDown("select Class_Id, Class_Name from Class_Master where School_Code='" + Session["School_Code"] + "'", "Class_Name", "Class_Id");

                //model.Section_Name = PopulateDropDown("select Section_Id, Section_Name from School_Section_Master where School_Code='" + Session["School_Code"] + "'", "Section_Name", "Section_Id");
                //model.Subject_Name = PopulateDropDown("select Distinct  Subject_Name, Subject_ID from School_Subject_Master where School_Code='" + Session["School_Code"] + "'", "Subject_Name", "Subject_ID");


                return View(model);
            }
        }



        public ActionResult EditHomeWork(int id)
        {
            int classid = 0;
            Homework model = new Homework();
            List<Homework> Templist = new List<Homework>();
            List<Homework> Filelist = new List<Homework>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("GetHomeWork", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", id);
            cmd.Parameters.AddWithValue("@Query", 2);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();
            foreach (DataRow dr in dt.Rows)
            {
                Templist.Add(new Homework
                {
                    ID = id,
                    class_id = Convert.ToInt32(dr["Class_ID"]),
                    sec_id = Convert.ToInt32(dr["Section_ID"]),
                    sub_id = Convert.ToInt32(dr["Subject_ID"]),
                    topic = Convert.ToString(dr["Topic"]),
                    Home_Desc = Convert.ToString(dr["Description"]),
                    date_assigned = Convert.ToString(dr["Assigned_Date"]),
                    due_date = Convert.ToString(dr["Due_Date"]),
                    status = Convert.ToString(dr["Status"]),

                });
                Filelist.Add(new Homework
                {

                    FID = Convert.ToInt32(dr["FID"]),
                    HomeID = Convert.ToInt32(dr["Home_ID"]),
                    File_Path = Convert.ToString(dr["FilePath"]) + Convert.ToString(dr["FileName"]),
                    File_Name = Convert.ToString(dr["FileName"])
                });
                classid = Convert.ToInt32(dr["Class_ID"]);
            }

            model.Templist = Templist;
            model.Filelist = Filelist;
            model.Class_Name = PopulateDropDown("select Class_Id, Class_Name from Class_Master where School_Code='" + Session["School_Code"] + "'", "Class_Name", "Class_Id");
            model.Section_Name = PopulateDropDown("select Section_Id, Section_Name from School_Section_Master where School_Code='" + Session["School_Code"] + "' and Class_Id=" + classid, "Section_Name", "Section_Id");
            model.Subject_Name = PopulateDropDown("select Distinct  Subject_Name, Subject_ID from School_Subject_Master where School_Code='" + Session["School_Code"] + "' and Class_Id=" + classid, "Subject_Name", "Subject_ID");


            return View(model);
        }


        [HttpPost]
        public ActionResult EditHomeWork(FormCollection fc, HttpPostedFileBase File_Name)
        {

            SchoolAssignment model = new SchoolAssignment();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("HomeAssignment", con);
            cmd.CommandType = CommandType.StoredProcedure;

            ///cmd.Parameters.AddWithValue("@Student_Id", fc["Student_Id"]);

            cmd.Parameters.AddWithValue("@ID", fc["ID"]);
            cmd.Parameters.AddWithValue("@sub_id", fc["sub_id"]);
            cmd.Parameters.AddWithValue("@class_id", fc["class_id"]);
            cmd.Parameters.AddWithValue("@sec_id", fc["sec_id"]);
            cmd.Parameters.AddWithValue("@topic", fc["topic"]);
            cmd.Parameters.AddWithValue("@Home_Desc", fc["Home_Desc"]);
            cmd.Parameters.AddWithValue("@date_assigned", Convert.ToDateTime(fc["date_assigned"]));
            cmd.Parameters.AddWithValue("@due_date", Convert.ToDateTime(fc["due_date"]));
            cmd.Parameters.AddWithValue("@status", fc["status"]);



            cmd.Parameters.AddWithValue("@Query", 2);



            /* if (File_Name != null)
             {
                 string fileName_bordexamcer = Path.GetFileNameWithoutExtension(File_Name.FileName);
                 string extension = Path.GetExtension(File_Name.FileName);
                 String flname = fileName_bordexamcer + extension;
                 flname = fileName_bordexamcer + DateTime.Now.ToString("yymmssff") + extension;

                 cmd.Parameters.AddWithValue("@File_Path", "../AppFiles/Images/");
                 cmd.Parameters.AddWithValue("@File_Name", flname);

                 File_Name.SaveAs(Path.Combine(Server.MapPath("AppFiles/Images/"), flname));

             }*/






            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            TempData["msg"] = "Information Successfully Edited!";
            return this.RedirectToAction("HomeWorkAssigned", "Employee", new { @id = 1 });



        }


        [HttpPost]
        public ActionResult HomeWorkAssigned(FormCollection fc, HttpPostedFileBase File_Name, int id)
        {
            SchoolAssignment model = new SchoolAssignment();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("HomeWorkAssigned", con);
            cmd.CommandType = CommandType.StoredProcedure;


            cmd.Parameters.AddWithValue("@sub_id", fc["sub_id"]);
            cmd.Parameters.AddWithValue("@class_id", fc["class_id"]);
            cmd.Parameters.AddWithValue("@sec_id", fc["sec_id"]);
            cmd.Parameters.AddWithValue("@topic", fc["topic"]);
            cmd.Parameters.AddWithValue("@Home_Desc", fc["Home_Desc"]);
            cmd.Parameters.AddWithValue("@date_assigned", Convert.ToDateTime(fc["date_assigned"]));
            cmd.Parameters.AddWithValue("@due_date", Convert.ToDateTime(fc["due_date"]));
            cmd.Parameters.AddWithValue("@status", "Due");
            cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);
            cmd.Parameters.AddWithValue("@Teacher_ID", Session["Employee_Id"]);


            cmd.Parameters.AddWithValue("@Query", 1);

            if (id == 2)
            {

                //cmd.Parameters.AddWithValue("@remarks", fc["remarks"]);
                //cmd.Parameters.AddWithValue("@rem_desc", fc["rem_desc"]);
                cmd.Parameters.AddWithValue("@hwass", "A");

            }
            if (id == 1)
            {
                cmd.Parameters.AddWithValue("@hwass", "H");


            }

            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();








            TempData["msg"] = AjaxUploadFiles();
            return this.RedirectToAction("HomeWorkAssigned", "Employee", new { @id = id });


        }




        public ActionResult AjaxUploadFiles()
        {
            string fname = "", fpath = "";
            int RowID = 0;
            String con = ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);

            string sqlquery = "SELECT Max(ID) as ID FROM [dbo].[Homework_Assigned] where School_Code='" + Session["School_Code"] + "' and Teacher_ID=" + Session["Employee_Id"];///WHERE ST_Section = '"+ value + "'
            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlcom;
            DataTable dt = new DataTable();
            da.Fill(dt);
            sqlcon.Close();
            foreach (DataRow dr in dt.Rows)
            {
                RowID = (dr["ID"] == DBNull.Value ? 1 : Convert.ToInt32(dr["ID"]));
            }
            // Checking no of files injected in Request object 
            if (Request.Files.Count > 0)
            {
                try
                {
                    //  Get all files from Request object 
                    HttpFileCollectionBase files = Request.Files;
                    HttpPostedFileBase file;
                    int cnt = files.Count;
                    for (int i = 0; i < cnt; i++)
                    {

                        file = files[i];

                        // Checking for Internet Explorer 
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }
                        fname = "F_" + DateTime.Now.ToString("yymmssff").Trim() + fname;
                        // ViewBag.fname = fname;
                        fname = fname.Replace(":", "_");
                        fname = fname.Replace(" ", "_");

                        ////////inserting into backend table

                        con = ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString;
                        sqlcon = new SqlConnection(con);
                        String path = "../AppFiles/Images/";
                        sqlquery = "Insert into File_Assigned(Home_ID,FileName,FilePath) values (" + RowID + ",'" + fname + "','" + path + "')";
                        sqlcon.Open();
                        sqlcom = new SqlCommand(sqlquery, sqlcon);
                        da = new SqlDataAdapter();
                        da.SelectCommand = sqlcom;

                        sqlcom.ExecuteNonQuery();
                        sqlcon.Close();

                        fname = Path.Combine(Server.MapPath("../../AppFiles/Images/"), fname);
                        files[i].SaveAs(fname);


                    }

                    //HttpFileCollectionBase files2 = Request.Files;
                    //HttpPostedFileBase file2;
                    //string fname2 = "", fpath2 = "";
                    //for (int j = 0; j < cnt; j++)
                    //{
                    //    // Get the complete folder path and store the file inside it.
                    //    file2 = files2[j];

                    //    // Checking for Internet Explorer 
                    //    if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                    //    {
                    //        string[] testfiles2 = file2.FileName.Split(new char[] { '\\' });
                    //        fname2 = testfiles2[testfiles2.Length - 1];
                    //    }
                    //    else
                    //    {
                    //        fname2 = file2.FileName;
                    //    }
                    //    fname2 = "F_" + DateTime.Now.ToString("yymmssff").Trim() + fname2;
                    //    // ViewBag.fname = fname;
                    //    fname2 = fname2.Replace(":", "_");
                    //    fname2 = fname2.Replace(" ", "_");


                    //}
                    // Returns message that successfully uploaded 
                    //return Json(Convert.ToString(Server.MapPath("../AppFiles/Images/")));
                    return Json("Files Uploaded!!");
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }


        public JsonResult GetSection(int class_id)
                    {

                        if (Session["School_Code"] == null)
                        {
                            return Json(Redirect("~/Employee/EmployeeLogin"));
                        }
                        else
                        {
                            Homework model = new Homework();

                            model.Section_Name = PopulateDropDown("select Section_Id, Section_Name from School_Section_Master where School_Code='" + Session["School_Code"] + "' and Class_Id=" + class_id, "Section_Name", "Section_Id");
                            model.Subject_Name = PopulateDropDown("select Distinct  Subject_Name, Subject_ID from School_Subject_Master where School_Code='" + Session["School_Code"] + "' and Class_Id=" + class_id, "Subject_Name", "Subject_ID");

                            return Json(model);
                        }




                    }


                    //for homework upload


                    public JsonResult AjaxReplaceFiles()
                    {



                        string fname = "";

                        string filenm = "";
                        // Checking no of files injected in Request object  
                        if (Request.Files.Count > 0)
                        {
                            try
                            {
                                //  Get all files from Request object  
                                HttpFileCollectionBase files = Request.Files;
                                for (int i = 0; i < files.Count; i++)
                                {
                                    //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                                    //string filename = Path.GetFileName(Request.Files[i].FileName);  

                                    HttpPostedFileBase file = files[i];


                                    // Checking for Internet Explorer  
                                    if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                                    {
                                        string[] testfiles = file.FileName.Split(new char[] { '\\' });
                                        fname = testfiles[testfiles.Length - 1];
                                    }
                                    else
                                    {
                                        fname = file.FileName;

                                    }

                                    fname = "F_" + Convert.ToString(DateTime.Now).Trim() + fname;

                                    fname = fname.Replace(":", "_");
                                    filenm = fname = fname.Replace(" ", "_");

                                    // Get the complete folder path and store the file inside it.  
                                    fname = Path.Combine(Server.MapPath("../AppFiles/Images/"), fname);
                                    file.SaveAs(fname);

                                    //string fileNamee = Path.GetFileNameWithoutExtension(Report.FileName);
                                    //string extension = Path.GetExtension(Report.FileName);
                                }
                                // Returns message that successfully uploaded  
                                //return Json(Convert.ToString(Server.MapPath("~/UploadedFiles/")));


                                return Json(filenm);
                            }
                            catch (Exception ex)
                            {
                                return Json("Error occurred. Error details: " + ex.Message);
                            }
                        }
                        else
                        {
                            return Json("No files selected.");
                        }




                    }
                    // edit filename
                    public JsonResult UpdateData(int id, String filename)
                    {



                        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
                        SqlCommand cmd = new SqlCommand("HomeAssignment", con);
                        cmd.CommandType = CommandType.StoredProcedure;


                        cmd.Parameters.AddWithValue("@fid", id);

                        cmd.Parameters.AddWithValue("@File_Name", filename);

                        cmd.Parameters.AddWithValue("@Query", 6);

                        SqlDataAdapter sd = new SqlDataAdapter(cmd);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();




                        return Json("Updated Filename!!");

                    }

        [HttpGet]
        public ActionResult TeacherViewHomework(int id)
        {

            if (Session["School_Code"] == null)
            {
                return Json(Redirect("~/Employee/EmployeeLogin"));
            }
            else
            {
                Homework model = new Homework();

                String str = "Select Distinct Class_Master.Class_Id,Class_Master.Class_Name  ";
                str += "from((Homework_Assigned Join Class_Master on Homework_Assigned.Class_ID = Class_Master.Class_Id)";
                str += " Join School_Employee_Details on School_Employee_Details.Employee_Id = Homework_Assigned.Teacher_ID)";
                str += "where Homework_Assigned.School_Code ='" + Session["School_Code"] + "'";

                model.Class_Name = PopulateDropDown(str, "Class_Name", "Class_Id");
                model.id = id;




                return View(model);
            }
        }
        public JsonResult GetSectionTeacher(int class_id)
        {

            if (Session["School_Code"] == null)
            {
                return Json(Redirect("~/Employee/EmployeeLogin"));
            }
            else
            {
                Homework model = new Homework();


                String str = "Select Distinct  School_Section_Master.Section_Id, School_Section_Master.Section_Name ";
                str += "from((Homework_Assigned Join School_Section_Master on Homework_Assigned.Section_ID = School_Section_Master.Section_Id) ";
                str += "Join School_Employee_Details on School_Employee_Details.Employee_Id = Homework_Assigned.Teacher_ID) ";
                str += "where Homework_Assigned.School_Code ='" + Session["School_Code"] + "' and Homework_Assigned.Class_ID=" + class_id;
                model.Section_Name = PopulateDropDown(str, "Section_Name", "Section_Id");



                str = " Select Distinct  School_Subject_Master.Subject_id, School_Subject_Master.Subject_Name ";
                str += "from((Homework_Assigned Join School_Subject_Master on Homework_Assigned.Subject_ID = School_Subject_Master.Subject_id)";
                str += "Join School_Employee_Details on School_Employee_Details.Employee_Id = Homework_Assigned.Teacher_ID)";
                model.Subject_Name = PopulateDropDown(str, "Subject_Name", "Subject_ID"); return Json(model);
            }




        }

        [HttpPost]

        public JsonResult GetTableTeacher(int class_id, int sec_id, int sub_id)
        {
            Homework model = new Homework();

            List<Homework> Templist = new List<Homework>();

            String con = ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            string sqlquery = "";
            if (class_id != 0)
            {

                sqlquery = "Select * ";
                sqlquery += "from(((Homework_Assigned join Class_Master on Homework_Assigned.Class_ID = Class_Master.Class_Id)";

                sqlquery += "Join School_Section_Master on Homework_Assigned.Section_ID = School_Section_Master.Section_Id)";
                sqlquery += " Join School_Subject_Master on Homework_Assigned.Subject_ID = School_Subject_Master.Subject_id)";
                sqlquery += " where Homework_Assigned.School_Code='" + Session["School_Code"] + "' And  Homework_Assigned.Class_ID=" + class_id;
                sqlquery += " And Homework_Assigned.Section_ID=" + sec_id + " And Homework_Assigned.Subject_ID=" + sub_id;
                sqlquery += " And Homework_Assigned.Teacher_ID=" + Session["Employee_Id"];
                sqlquery += "Order By Homework_Assigned.Assigned_Date desc";

            }
            if (class_id == 0)
            {
                sqlquery = "Select * ";
                sqlquery += "from(((Homework_Assigned join Class_Master on Homework_Assigned.Class_ID = Class_Master.Class_Id)";

                sqlquery += "Join School_Section_Master on Homework_Assigned.Section_ID = School_Section_Master.Section_Id)";
                sqlquery += " Join School_Subject_Master on Homework_Assigned.Subject_ID = School_Subject_Master.Subject_id)";
                sqlquery += " where Homework_Assigned.School_Code='" + Session["School_Code"] + "'";
                //sqlquery += " And Homework_Assigned.Section_ID=" + sec_id + " And Homework_Assigned.Subject_ID=" + sub_id;
                sqlquery += " And Homework_Assigned.Teacher_ID=" + Session["Employee_Id"];
                sqlquery += " Order By Homework_Assigned.Assigned_Date desc";


            }
            //string sqlquery = "SELECT Max(Home_Response_ID) as ID FROM [dbo].[Homework_Response] where  Student_ID=" + Session["Student_Id"];///WHERE ST_Section = '"+ value + "'
            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlcom;
            DataTable dt = new DataTable();
            da.Fill(dt);
            sqlcon.Close();



            foreach (DataRow dr in dt.Rows)
            {
                Templist.Add(new Homework
                {
                    ID = Convert.ToInt32(dr["ID"]),

                    ClassName = Convert.ToString(dr["Class_Name"]),
                    subject_name = Convert.ToString(dr["subject_name"]),
                    topic = Convert.ToString(dr["Topic"]),
                    SectionName = Convert.ToString(dr["Section_Name"]),
                    Home_Desc = Convert.ToString(dr["Description"]),
                    date_assigned = Convert.ToString(dr["Assigned_Date"]).Substring(0, 10),
                    due_date = Convert.ToString(dr["Due_Date"]).Substring(0, 10),

                    status = Convert.ToString(dr["Status"]),
                    // File_Name= Convert.ToString(dr["File_Path"])+ Convert.ToString(dr["File_Name"]),

                    class_id = Convert.ToInt32(dr["Class_ID"]),

                    sec_id = Convert.ToInt32(dr["Section_ID"])
                });

            }


            model.Templist = Templist;




            return Json(model);
        }

        public JsonResult GetDetailTeacher(int Id)
        {

            Homework model = new Homework();
            List<Homework> Templist = new List<Homework>();
            List<Homework> NameRoll = new List<Homework>();


            List<Homework> Filelist = new List<Homework>();

            List<Homework> Fileresponse = new List<Homework>();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("HomeAssignment", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Teacher_Id", Session["Employee_Id"]);

            cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);

            cmd.Parameters.AddWithValue("@Id", Id);



            cmd.Parameters.AddWithValue("@Query", 8);



            SqlDataAdapter sd = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            con.Open();
            sd.Fill(ds);
            con.Close();



            for (int i = 0; i < ds.Tables.Count; i++)
            {
                if (i == 0)
                {
                    foreach (DataRow dr in ds.Tables[i].Rows)
                    {
                        Templist.Add(new Homework
                        {

                            subject_name = Convert.ToString(dr["Subject_Name"]),
                            topic = Convert.ToString(dr["Topic"]),
                            ClassName = Convert.ToString(dr["Class_Name"]),
                            SectionName = Convert.ToString(dr["Section_Name"]),
                            Home_Desc = Convert.ToString(dr["Description"]),
                            date_assigned = Convert.ToString(dr["Assigned_Date"]).Substring(0, 10),
                            due_date = Convert.ToString(dr["Due_Date"]).Substring(0, 10),
                            class_id = Convert.ToInt32(dr["Class_ID"]),

                            sec_id = Convert.ToInt32(dr["Section_ID"])
                        });
                    }
                }
                if (i == 1)
                {
                    foreach (DataRow dr in ds.Tables[i].Rows)
                    {
                        Filelist.Add(new Homework
                        {

                            File_Name = Convert.ToString(dr["FilePath"]) + Convert.ToString(dr["FileName"]),

                            F_Name = Convert.ToString(dr["FileName"])

                        });

                    }


                }
                if (i == 2)
                {
                    foreach (DataRow dr in ds.Tables[i].Rows)
                    {
                        Fileresponse.Add(new Homework
                        {

                            File_Name = Convert.ToString(dr["FilePath"]) + Convert.ToString(dr["FileName"]),

                            F_Name = Convert.ToString(dr["FileName"])

                        });

                    }


                }

                if (i == 3)
                {
                    foreach (DataRow dr in ds.Tables[i].Rows)
                    {
                        NameRoll.Add(new Homework
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            Name = Convert.ToString(dr["Name"]),

                            RollNo = (dr["RollNo"] == DBNull.Value ? 0 : Convert.ToInt32(dr["RollNo"])),
                            status = Convert.ToString(dr["Status"]),

                            OverDue = Convert.ToInt32(dr["OverDue"])


                        });

                    }


                }




            }


            model.Fileresponse = Fileresponse;
            model.Templist = Templist;

            model.NameRoll = NameRoll;
            model.Filelist = Filelist;
            return Json(model);
        }

        public JsonResult AjaxAddRemark(String remark, int ID)
        {
            String con = ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);



            string sqlquery = "Update Homework_Response set RemDesc='" + remark + "' where Home_Response_ID=" + ID;
            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlcom;

            sqlcom.ExecuteNonQuery();
            sqlcon.Close();

            return Json("Remark added!!");
        }
        public JsonResult publishhw(int ID, String clss, String Section)
        {
            String con = ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);



            string sqlquery = "Update Homework_Assigned set Status='Published' where ID=" + ID + " and School_Code='" + Session["School_Code"] + "'";
            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlcom;

            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
            ////Inserting Into Homework Response
            ///Adding all student's record in hw response


            con = ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString;
            sqlcon = new SqlConnection(con);

            sqlquery = "Insert into Homework_Response(Home_Assigned_ID, Status, Student_ID)";
            sqlquery += "((Select Home_Assigned_ID =" + ID + " , Status = 'Pending', Student_Id from School_Student_Details where School_Code ='" + Session["School_Code"] + "' and AdmissionClass_Id =" + clss + " and Section_Id =" + Section + " ))";


            sqlcon.Open();
            sqlcom = new SqlCommand(sqlquery, sqlcon);
            da = new SqlDataAdapter();
            da.SelectCommand = sqlcom;

            sqlcom.ExecuteNonQuery();
            sqlcon.Close();

            return Json("Published For Students!!");
        }

        //////////////////////////////////Home Work///////////////////////////////////////
        ///



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

                    model.ExamList = PopulateDropDown("SELECT Exam_Term_id, Exam_Term_Name FROM School_Exam_Term_Master", "Exam_Term_Name", "Exam_Term_id");

                    break;

            }
            return Json(model);
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
                model.Class_Name = PopulateDropDown("SELECT Class_Id, Class_Name FROM Class_Master  WHERE School_Code='" + Session["School_Code"] + "'", "Class_Name", "Class_Id");
                model.Year_Name = PopulateDropDown("SELECT Year, Year_Name FROM Year", "Year_Name", "Year");

              
                return View(model);
            }
        }

        [HttpPost]
        public JsonResult AjaxMethod_StudentSyllabus(String Session_year, int Class_Id, String Exam_Id)
        {
            String School_Code = Session["School_Code"].ToString();

            List<StudentSyllabus> StuentList = new List<StudentSyllabus>();
            String con = ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            string sqlquery = "SELECT SS.*,CM.Class_Name,SSM.Subject_Name,SETM.Exam_Term_Name   FROM Student_Syllabus AS SS, Class_Master AS CM ,School_Subject_Master AS SSM,School_Exam_Term_Master AS SETM  WHERE SS.School_Code ='" + School_Code + "'  AND SS.Class_Id = '" + Class_Id + "'  AND SS.Exam_Id='" + Exam_Id + "' AND  SS.Class_Id = CM.Class_Id  AND SS.Subject_Id = SSM.Subject_Id AND SS.Exam_Id=SETM.Exam_Term_id ";

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

                       
                        Class_Nam = String.IsNullOrEmpty(sdr["Class_Name"].ToString()) ? "NA" : sdr["Class_Name"].ToString(),
                       // Section_Nam = String.IsNullOrEmpty(sdr["Section_Name"].ToString()) ? "NA" : sdr["Section_Name"].ToString(),
                        Subject_Name = String.IsNullOrEmpty(sdr["Subject_Name"].ToString()) ? "NA" : sdr["Subject_Name"].ToString(),
                        //Syllabus_Desc = String.IsNullOrEmpty(sdr["Syllabus_Desc"].ToString()) ? "NA" : sdr["Syllabus_Desc"].ToString(),
                        Syllabus_Desc = String.IsNullOrEmpty(Regex.Replace(sdr["Syllabus_Desc"].ToString(), "<.*?>", string.Empty)) ? "NA" : Regex.Replace(sdr["Syllabus_Desc"].ToString(), "<.*?>", string.Empty),

                        Syllabus_Attachment_name = String.IsNullOrEmpty(sdr["Attachement_Name"].ToString()) ? "NA" : sdr["Attachement_Name"].ToString(),
                        Syllabus_Attachment_Path = String.IsNullOrEmpty(sdr["Attachedment_Path"].ToString()) ? "NA" : sdr["Attachedment_Path"].ToString()


                    });
            }

            return Json(StuentList, JsonRequestBehavior.AllowGet);
        }








    }
}