using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

namespace SchoolWork.Controllers
{
    public class ParentDetailsController : Controller
    {
        DataBaseAcessLayer.ParentDetailsDB dblayer2 = new DataBaseAcessLayer.ParentDetailsDB();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ParentRegister()
        {
            ParentRegistration model = new ParentRegistration();
            model.School_Name = PopulateDropDown("SELECT School_Name,School_Code FROM School_Details_Master", "School_Name", "School_Code" );
            return View(model);

           
        }
        [HttpPost]
        public ActionResult ParentRegister(FormCollection fc)
        {
            ParentModel model = new ParentModel();
            try { 
                if (ModelState.IsValid)
                {
                    ParentRegistration parreg = new ParentRegistration();
                //parreg.School_Id = Convert.ToInt32(fc["School_Id"]);
                    parreg.School_Code = fc["School_Code"];
                    parreg.ParentName = fc["ParentName"];
                    parreg.ParentContact = fc["ParentContact"];
                    parreg.ParentEmail = fc["ParentEmail"];
                    parreg.ParentPassword = fc["ParentPassword"];
                    dblayer2.Add_record(parreg);

                MailMessage mail = new MailMessage("pro@gmail.com", parreg.ParentEmail, "mailSubject2", "mailBody2");
                //mail.From = new MailAddress("denovo@gmail.com", "nameEmail aa");
                //mail.IsBodyHtml = true; // necessary if you're using html email
                mail.From = new MailAddress("pro@gmail.com", "Registration Successfull");
                //  mail.Subject = "Hii " + parreg.ParentName +"You are Registered SuccesFully on" + parreg.School_Code +"Your Email Id is"+ parreg.ParentEmail+"And Password is:"+ parreg.ParentPassword+"<br/>";
                mail.Subject = "Registration Successfull";
                mail.Body = "Hii " + parreg.ParentName + "You are Registered SuccesFully on  " + parreg.SchoolName + "  Your User \r\n Id: " + parreg.ParentEmail + "\r\n  Password:" + parreg.ParentPassword + " \r\n ";

                //new MailAddress("pro@gmail.com", "nameEmail aa");
                // NetworkCredential credential = new NetworkCredential(parreg.SchoolEmail, parreg.SchoolPassword);
                NetworkCredential credential = new NetworkCredential("schooldays2050@gmail.com", "Marine@1");
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = credential;
                smtp.Send(mail);


                TempData["msg"] = "You are Registered Successfully!! Now You have to Login with Your Email Id @ Password Given";

                   return this.RedirectToAction("ParentRegister", "ParentDetails");
                }


            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

            }

            return View(model);
           
            
        }



        public ActionResult ParentLogin()
        {
            ParentLogin model = new ParentLogin();
            model.School_Name = PopulateDropDown("SELECT School_Name,School_Code FROM School_Details_Master", "School_Name", "School_Code");
            return View(model);

        }
        [HttpPost]
        public ActionResult ParentLogin(ParentLogin fc)
        {

            ParentLogin model = new ParentLogin();
            model.School_Name = PopulateDropDown("SELECT School_Name,School_Code FROM School_Details_Master", "School_Name", "School_Code");

            String con = ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            // string sqlquery = "Select ParentID,ParentName,ParentEmail, ParentPassword,School_Code FROM [dbo].[ParentRegistration] WHERE  ParentEmail=@Email and ParentPassword=@Password";
            try { 
            // string sqlquery = "SELECT SM.*,PR.* FROM School_User_Master AS SM, ParentRegistration AS PR WHERE SM.User_Email = @Email AND SM.User_Password =@Password AND SM.School_Code =@School_Code AND SM.User_Type =@User_Type AND SM.User_Id = PR.ParentID AND SM.User_Email = PR.ParentEmail";
            string sqlquery = "SELECT SM.*,PR.*, SDM.* FROM School_User_Master AS SM, ParentRegistration AS PR , School_Details_Master AS SDM WHERE SM.User_Email =@Email AND SM.User_Password =@Password AND SM.School_Code =@School_Code AND SM.User_Type =@User_Type AND SM.User_Id = PR.ParentID AND SM.User_Email = PR.ParentEmail AND SDM.School_Code= PR.School_Code";

            sqlcon.Open();
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
                Session["School_Id"] = ds.Tables[0].Rows[0]["School_Id"].ToString();
                Session["School_Name"] = ds.Tables[0].Rows[0]["School_Name"].ToString();
                Session["School_Code"] = ds.Tables[0].Rows[0]["School_Code"].ToString();
                Session["ParentName"] = ds.Tables[0].Rows[0]["ParentName"].ToString();
                Session["ParentID"] = ds.Tables[0].Rows[0]["ParentID"].ToString();
                Session["ParentContact"] = ds.Tables[0].Rows[0]["ParentContact"].ToString();
                Session["ParentEmail"] = ds.Tables[0].Rows[0]["ParentEmail"].ToString();
                Session["ParentPassword"] = ds.Tables[0].Rows[0]["ParentPassword"].ToString();
                Session["ParentContact"] = ds.Tables[0].Rows[0]["ParentContact"].ToString();

                //ViewData["sucess_msg"] = Session["username"];

                return this.RedirectToAction("ParentHeaderBoard", "Dashboard");
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
        public ActionResult ShowallNotice()
        {
            if (Session["ParentID"] == null)
            {
                return Redirect("~/ParentDetails/ParentLogin");
            }
            else
            {
                DataBaseAcessLayer.ParentDetailsDB dbhandle = new DataBaseAcessLayer.ParentDetailsDB();
                return View(dbhandle.GetNotice());
                // DataBaseAcessLayer.BasicDetailsDB dbhandle2 = new DataBaseAcessLayer.BasicDetailsDB();
                //dbhandle2.GetAllClass();
                //return View(dbhandle2.GetAllClass());

                // return View(dbhandle2.GetAllClass());

                //DataBaseAcessLayer.ParentDetailsDB dbhandle = new DataBaseAcessLayer.ParentDetailsDB();
                // NoticeDetails CustData = new NoticeDetails();

                //List<NoticeDetails> MasterData = dbhandle.GetNotice().ToList();

                //CustData.UserList = MasterData[0].UserList;

                //CustData.CustRegions = MasterData[0].CustRegions;


                //return View(CustData);
            }
        }

        public ActionResult ShowNoticeDetails(int id)
        {
            if (Session["ParentID"] == null)
            {
                return Redirect("~/ParentDetails/ParentLogin");
            }
            else
            {
                DataBaseAcessLayer.ParentDetailsDB dbhandle = new DataBaseAcessLayer.ParentDetailsDB();
                return View(dbhandle.GetNotice().Find(smodel => smodel.Notice_Id == id));
            }
        }

        public JsonResult CheckUsernameAvailability(string useremail, string School_Code)
        {
            System.Threading.Thread.Sleep(200);
            ParentRegistration model = new ParentRegistration();
            // var SeachData = model.ParentRegistration.Where(x => x.StuName == userdata).SingleOrDefault();
            String con = ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            // string sqlquery = "Select ParentID,ParentName,ParentEmail, ParentPassword,School_Code FROM [dbo].[ParentRegistration] WHERE  ParentEmail='"+ useremail + "'";
            string sqlquery = "Select User_Email FROM [dbo].[School_User_Master] WHERE User_Email ='" + useremail + "' AND School_Code ='" + School_Code + "' AND User_Type = '1' ";

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




        [HttpGet]
        public ActionResult ShowAllStudentApplication()
        {
            if (Session["ParentID"] == null)
            {
                return Redirect("~/ParentDetails/ParentLogin");
            }
            else
            {
                DataBaseAcessLayer.ParentDetailsDB dbhandle = new DataBaseAcessLayer.ParentDetailsDB();
                return View(dbhandle.GetAllApplication());

            }
        }

        public ActionResult ShowStudentApplicationDetails(int id, FormCollection fc, int countryId = '0', int stateId = '0', int cityId = '0')
        {

            StudentFormFillup model = new StudentFormFillup();

            if (Session["ParentID"] == null)
            {
                return Redirect("~/ParentDetails/ParentLogin");
            }
            else
            {
                // HttpPostedFileBase ImageUpload
                // HttpPostedFileBase SignatureUpload
                try
                {
                    model.Countries = PopulateDropDown("SELECT CountryId, CountryName FROM country", "CountryName", "CountryId");
                    model.States = PopulateDropDown("SELECT StateId, StateName FROM state WHERE CountryId = " + countryId, "StateName", "StateId");
                    model.Cities = PopulateDropDown("SELECT CityId, CityName FROM city WHERE StateId = " + stateId, "CityName", "CityId");

                    model.School_Name = PopulateDropDown("SELECT School_Id, School_Name FROM School_Details_Master", "School_Name", "School_Id");
                    model.citizenCountry = PopulateDropDown("SELECT CountryId, CountryName FROM country", "CountryName", "CountryId");
                    model.IdProof_Type = PopulateDropDown("SELECT IdProof_Id, IdProof_Name FROM IdProof_Master", "IdProof_Name", "IdProof_Id");
                    model.BloodGroup_Name = PopulateDropDown("SELECT BloodGroup_Id, BloodGroup_Name FROM BloodGroup_Master", "BloodGroup_Name", "BloodGroup_Id");
                    model.AdmissionClass_Name = PopulateDropDown("SELECT Class_Id, Class_Name FROM Class_Master", "Class_Name", "Class_Id");
                    model.SchoolBoard_Name = PopulateDropDown("SELECT Board_Id, Board_Name FROM Board_Master", "Board_Name", "Board_Id");
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;

                }

                DataBaseAcessLayer.ParentDetailsDB dbhandle = new DataBaseAcessLayer.ParentDetailsDB();



                return View(dbhandle.GetAllApplication().Find(smodel => smodel.Student_Id == id));

                //            return View(model);
            }
        }




        public ActionResult UpdateParentInfo()
        {
            if (Session["ParentID"] == null)
            {
                return Redirect("~/ParentDetails/ParentLogin");
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult UpdateParentInfo(ParentDetails smodel)
        {
            if (Session["ParentID"] == null)
            {
                return Redirect("~/ParentDetails/ParentLogin");
            }
            else
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        DataBaseAcessLayer.ParentDetailsDB dbhandle = new DataBaseAcessLayer.ParentDetailsDB();
                        dbhandle.UpdateDetails(smodel);
                        TempData["msg"] = "Your Info is  Updated Successfully! Login With New Password to View The Updated";
                        HttpContext.Session.Clear();
                        return RedirectToAction("Startpage", "Home");
                        //return this.RedirectToAction("ParentDashBoard", "DashBoard");
                    }

                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;

                }
                return View(smodel);
            }
        }

        [HttpPost]
        public JsonResult AjaxPerformance(string School_code, int ParentId)
        {
            WorkRole_Header model = new WorkRole_Header();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);

            List<WorkRole_Header> EmpWorkRoleList = new List<WorkRole_Header>();
            SqlCommand cmd = new SqlCommand("Students_performance", con);
            cmd.CommandType = CommandType.StoredProcedure; cmd.Parameters.AddWithValue("@School_Code", School_code);
            cmd.Parameters.AddWithValue("@ParentId", ParentId);
            cmd.Parameters.AddWithValue("@Query", 1);
            SqlDataAdapter sd = new SqlDataAdapter(cmd); DataTable dt = new DataTable(); con.Open();
            sd.Fill(dt);
            con.Close(); foreach (DataRow dr in dt.Rows)
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


            return Json(model);
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

              return new JsonResult { Data = FeeList, JsonRequestBehavior = JsonRequestBehavior.AllowGet };

        }


        [HttpGet]
        public ActionResult View_Student_Attendance()
        {
            if (Session["ParentID"] == null)
            {
                return Redirect("~/ParentDetails/ParentLogin");
            }
            else
            {
                StudentAttendance model = new StudentAttendance();
                //  model.PeriodList = PopulateDropDown("SELECT Period_Id, Period_Name FROM Period_Master  WHERE School_Code='" + Session["School_Code"] + "'", "Period_Name", "Period_Id");
                model.StudentList = PopulateDropDown("SELECT Student_Id,   Isnull(first_name, '') + ' ' + Isnull(middle_name, '') + ' ' + Isnull(last_name, '') AS first_name FROM School_Student_Details WHERE  School_Code='" + Session["School_Code"] + "' AND Parent_Id='"+Session["ParentID"]+"' ", "first_name", "Student_Id");

                //model.ExamType_Name = PopulateDropDown("SELECT Exam_Term_id, Exam_Term_Name FROM School_Exam_Term_Master", "Exam_Term_Name", "Exam_Term_id");
                model.Class_Name = PopulateDropDown("SELECT Class_Id, Class_Name FROM Class_Master  WHERE School_Code='" + Session["School_Code"] + "'", "Class_Name", "Class_Id");
                model.Year_Name = PopulateDropDown("SELECT Year, Year_Name FROM Year", "Year_Name", "Year");

                // model.Section_Name = PopulateDropDown("SELECT Section_Name, Section_Name FROM School_Section_Master WHERE School_Code='" + Session["School_Code"] + "'", "Section_Name", "Section_Name");

                return View(model);
            }
        }

        [HttpPost]
        public JsonResult AjaxMethod_StudentAttendance(int Student_Id, String Start_Date, String End_Date)
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
            string sqlquery = "SELECT Period_Date, [First] As First_Period,[Second] AS Second_Period,[Third] AS Third_Period,[Fourth] AS Fourth_Period ,[Fifth] AS Fifth_Period,[Sixth] AS Sixth_Period ,[Seventh] AS Seventh_Period ,[Eighth] AS Eighth_Period ,[Nineth] AS Nineth_Period ,[Tenth] AS Tenth_Period   FROM (SELECT  SA.Period_Date, SA.[Period_Name], SA.Presence_Status FROM  Student_Attendance AS SA WHERE SA.School_Code = '" + Session["School_Code"] + "' AND  SA.Student_Id ='" + Student_Id + "'  AND  SA.Period_Date BETWEEN  '" + Start_Date + "' AND '" + End_Date + "') Tab1 PIVOT (MAX(Presence_Status) FOR[Period_Name] IN([First],[Second],[Third],[Fourth],[Fifth],[Sixth],[Seventh],[Eighth],[Nineth],[Tenth]) ) AS Tab2 ORDER BY Tab2.Period_Date";
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

        [HttpPost]
        public JsonResult Update_Student_Attendance( int Student_Id, String Period_Date, String Period_Name, String Absent_Reasons)
        {

            StudentAttendance model = new StudentAttendance();
            if (String.IsNullOrEmpty(Absent_Reasons))
            {
                Absent_Reasons = "NA";
            }
            

            String con = ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            string sqlquery = "UPDATE [dbo].[Student_Attendance] SET Absent_Reasons='" + Absent_Reasons + "' WHERE Student_Id ='" + Student_Id + "' AND Period_Date ='" + Period_Date + "' AND School_Code= '" + Session["School_Code"] + "' AND Period_Name='" + Period_Name + "'";
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

        


        [HttpPost]
        public JsonResult AjaxMethod_StudentDetails(int Student_Id)
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
            string sqlquery = "SELECT SSM.*,CM.*, SSD.*, Isnull(SSD.first_name, '') + ' ' + Isnull(SSD.middle_name, '') + ' ' + Isnull(SSD.last_name, '') AS FullName FROM School_Student_Details AS SSD, School_Section_Master AS SSM , Class_Master AS CM WHERE SSD.School_Code=SSM.School_Code  AND SSD.AdmissionClass_Id =CM.Class_Id AND SSD.Section_Id=SSM.Section_Id AND SSD.School_Code = '" + Session["School_Code"] + "' AND  SSD.Student_Id = '" + Student_Id + "' ";

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
                        Class_Id = String.IsNullOrEmpty(sdr["Class_Id"].ToString()) ? 0 : Convert.ToInt32(sdr["Class_Id"].ToString()),

                        Class_Name = String.IsNullOrEmpty(sdr["Class_Name"].ToString()) ? null : sdr["Class_Name"].ToString(),
                          Roll_Number = String.IsNullOrEmpty(sdr["Roll_Number"].ToString()) ? '0' : Convert.ToInt32(sdr["Roll_Number"]),
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


        public ActionResult Logout()
        {
            HttpContext.Session.Clear();
           // return RedirectToAction("ParentLogin");
            return RedirectToAction("Startpage", "Home");
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
                model.StudentList = PopulateDropDown("SELECT Student_Id,   Isnull(first_name, '') + ' ' + Isnull(middle_name, '') + ' ' + Isnull(last_name, '') AS first_name FROM School_Student_Details WHERE  School_Code='" + Session["School_Code"] + "' AND Parent_Id='" + Session["ParentID"] + "' ", "first_name", "Student_Id");
                model.ExamList = PopulateDropDown("SELECT Exam_Term_id, Exam_Term_Name FROM School_Exam_Term_Master", "Exam_Term_Name", "Exam_Term_id");

                model.Class_Name = PopulateDropDown("SELECT Class_Id, Class_Name FROM Class_Master  WHERE School_Code='" + Session["School_Code"] + "'", "Class_Name", "Class_Id");
                     model.Year_Name = PopulateDropDown("SELECT Year, Year_Name FROM Year", "Year_Name", "Year");

               
                return View(model);
            }
        }




        [HttpPost]
        public JsonResult AjaxMethod_StudentSyllabus( int Class_Id, String Exam_Id)
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
            string sqlquery = "SELECT SS.*,CM.Class_Name,SSM.Subject_Name,SETM.Exam_Term_Name   FROM Student_Syllabus AS SS, Class_Master AS CM ,School_Subject_Master AS SSM,School_Exam_Term_Master AS SETM  WHERE SS.School_Code ='" + School_Code + "'  AND SS.Class_Id = '"+ Class_Id + "'  AND SS.Exam_Id='" + Exam_Id + "' AND  SS.Class_Id = CM.Class_Id AND  SS.Subject_Id = SSM.Subject_Id AND SS.Exam_Id=SETM.Exam_Term_id ";

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

                        //   Student_Id = String.IsNullOrEmpty(sdr["Student_Id"].ToString()) ? '0' : Convert.ToInt32(sdr["Student_Id"]),
                        //  FullName = String.IsNullOrEmpty(sdr["FullName"].ToString()) ? null : sdr["FullName"].ToString(),

                        Class_Nam = String.IsNullOrEmpty(sdr["Class_Name"].ToString()) ? "NA" : sdr["Class_Name"].ToString(),
                        //  Section_Nam = String.IsNullOrEmpty(sdr["Section_Name"].ToString()) ? "NA" : sdr["Section_Name"].ToString(),
                        Subject_Name = String.IsNullOrEmpty(sdr["Subject_Name"].ToString()) ? "NA" : sdr["Subject_Name"].ToString(),
                        // Fourth_Period = String.IsNullOrEmpty(sdr["Fourth_Period"].ToString()) ? "NA" : sdr["Fourth_Period"].ToString(),
                        // Fifth_Period = String.IsNullOrEmpty(sdr["Fifth_Period"].ToString()) ? "NA" : sdr["Fifth_Period"].ToString(),
                        // Sixth_Period = String.IsNullOrEmpty(sdr["Sixth_Period"].ToString()) ? "NA" : sdr["Sixth_Period"].ToString(),
                        // Seventh_Period = String.IsNullOrEmpty(sdr["Seventh_Period"].ToString()) ? "NA" : sdr["Seventh_Period"].ToString(),
                        //Eighth_Period = String.IsNullOrEmpty(sdr["Eighth_Period"].ToString()) ? "NA" : sdr["Eighth_Period"].ToString(),
                        Exam_Name = String.IsNullOrEmpty(sdr["Exam_Term_Name"].ToString()) ? "NA" : sdr["Exam_Term_Name"].ToString(),
                        Syllabus_Desc = String.IsNullOrEmpty(Regex.Replace(sdr["Syllabus_Desc"].ToString(), "<.*?>", string.Empty)) ? "NA" : Regex.Replace(sdr["Syllabus_Desc"].ToString(), "<.*?>", string.Empty),
                        //Syllabus_Desc = Regex.Replace(sdr["Syllabus_Desc"].ToString(), "<.*?>", string.Empty),

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
            string sqlquery = "SELECT SS.*,CM.Class_Name,SSM.Subject_Name,SETM.Exam_Term_Name   FROM Student_Syllabus AS SS, Class_Master AS CM ,School_Subject_Master AS SSM,School_Exam_Term_Master AS SETM  WHERE SS.School_Code ='" + School_Code + "'  AND SS.Class_Id = '" +Class_Id + "' AND SS.Class_Id = CM.Class_Id AND  SS.Subject_Id = SSM.Subject_Id AND SS.Exam_Id=SETM.Exam_Term_id ";

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

                        //   Student_Id = String.IsNullOrEmpty(sdr["Student_Id"].ToString()) ? '0' : Convert.ToInt32(sdr["Student_Id"]),
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








    }



}