using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Text.RegularExpressions;
using System.Data.SqlClient;
using System.Configuration;
using SchoolWork.Models;

namespace SchoolWork.Controllers
{
    public class StudentDetailController : Controller
    {

        DataBaseAcessLayer.StudentDetailsDB dblayer2 = new DataBaseAcessLayer.StudentDetailsDB();

        // GET: StudentDetail
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult StudentLogin()
        {
            StudentLogin model = new StudentLogin();
            model.School_Name = PopulateDropDown("SELECT School_Name,School_Code FROM School_Details_Master", "School_Name", "School_Code");
            return View(model);

        }
        [HttpPost]
        public ActionResult StudentLogin(ParentLogin fc)
        {

            StudentLogin model = new StudentLogin();
            model.School_Name = PopulateDropDown("SELECT School_Name,School_Code FROM School_Details_Master", "School_Name", "School_Code");

            try { 
            String con = ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            // string sqlquery = "Select ParentID,ParentName,ParentEmail, ParentPassword,School_Code FROM [dbo].[ParentRegistration] WHERE  ParentEmail=@Email and ParentPassword=@Password";

            // string sqlquery = "SELECT SM.*,PR.* FROM School_User_Master AS SM, ParentRegistration AS PR WHERE SM.User_Email = @Email AND SM.User_Password =@Password AND SM.School_Code =@School_Code AND SM.User_Type =@User_Type AND SM.User_Id = PR.ParentID AND SM.User_Email = PR.ParentEmail";
            string sqlquery = "SELECT SM.*,SR.*, SDM.* FROM School_User_Master AS SM, School_Student_Details AS SR , School_Details_Master AS SDM WHERE SM.User_Email =@Email AND SM.User_Password =@Password AND SM.School_Code =@School_Code AND SM.User_Type =@User_Type AND SM.User_Id = SR.Student_Id AND SM.User_Email = SR.Student_Email AND SDM.School_Code= SR.School_Code";

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
                Session["first_name"] = ds.Tables[0].Rows[0]["first_name"].ToString();
                Session["Student_Id"] = ds.Tables[0].Rows[0]["Student_Id"].ToString();
               // Session["ParentContact"] = ds.Tables[0].Rows[0]["ParentContact"].ToString();
                Session["Student_Email"] = ds.Tables[0].Rows[0]["Student_Email"].ToString();
                Session["Password"] = ds.Tables[0].Rows[0]["Password"].ToString();
                Session["Class_Id"] = ds.Tables[0].Rows[0]["AdmissionClass_Id"].ToString(); 
                Session["Section_Id"] = ds.Tables[0].Rows[0]["Section_Id"].ToString();
                Session["Session_Year"] = ds.Tables[0].Rows[0]["Current_Session_Year"].ToString();
                Session["Section_Id"] = ds.Tables[0].Rows[0]["Section_Id"].ToString();



                    return this.RedirectToAction("StudentHeaderBoard", "Dashboard");
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
        public ActionResult ShowallStudentNotice()
        {

            DataBaseAcessLayer.StudentDetailsDB dbhandle = new DataBaseAcessLayer.StudentDetailsDB();
            return View(dbhandle.GetStudentNotice());

        }

        public ActionResult ShowStudentNoticeDetails(int id)
        {

            DataBaseAcessLayer.StudentDetailsDB dbhandle = new DataBaseAcessLayer.StudentDetailsDB();
            return View(dbhandle.GetStudentNotice().Find(smodel => smodel.Notice_Id == id));

        }

         public ActionResult StudentIndexPage()
        {

            //DataBaseAcessLayer.StudentDetailsDB dbhandle = new DataBaseAcessLayer.StudentDetailsDB();
            // return View(dbhandle.GetStudentNotice());
            return View();
        }

        public ActionResult StudentRegisterBoard()
        {
            StudentRegistration model = new StudentRegistration();
            model.School_Name = PopulateDropDown("SELECT School_Name,School_Code FROM School_Details_Master", "School_Name", "School_Code");
            return View(model);

        }


        [HttpPost]
        public ActionResult StudentRegisterBoard(FormCollection fc)
        {

            StudentRegistration model = new StudentRegistration();

            try
            {
                model.School_Name = PopulateDropDown("SELECT School_Name,School_Code FROM School_Details_Master", "School_Name", "School_Code");

            String con = ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            // string sqlquery = "Select ParentID,ParentName,ParentEmail, ParentPassword,School_Code FROM [dbo].[ParentRegistration] WHERE  ParentEmail=@Email and ParentPassword=@Password";

            // string sqlquery = "SELECT SM.*,PR.* FROM School_User_Master AS SM, ParentRegistration AS PR WHERE SM.User_Email = @Email AND SM.User_Password =@Password AND SM.School_Code =@School_Code AND SM.User_Type =@User_Type AND SM.User_Id = PR.ParentID AND SM.User_Email = PR.ParentEmail";
            // string sqlquery = "SELECT SM.*,SR.*, SDM.* FROM School_User_Master AS SM, School_Student_Details AS SR , School_Details_Master AS SDM WHERE SM.User_Email =@Email AND SM.User_Password =@Password AND SM.School_Code =@School_Code AND SM.User_Type =@User_Type AND SM.User_Id = SR.Student_Id AND SM.User_Email = SR.Student_Email AND SDM.School_Code= SR.School_Code";
            string sqlquery = "SELECT SDM.*, S.*, Isnull(S.first_name, '') + ' ' + Isnull(S.middle_name, '') + ' ' + Isnull(S.last_name, '') AS FullName FROM School_Student_Details AS S ,School_Details_Master AS SDM  WHERE S.School_Code =@School_Code AND S.Application_Id=@Application_Id  AND SDM.School_Code=S.School_Code";
            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon);
            sqlcom.Parameters.AddWithValue("@Application_Id", fc["Application_Id"]);
            //sqlcom.Parameters.AddWithValue("@Password", fc.Password);
            sqlcom.Parameters.AddWithValue("@School_Code", fc["School_Code"]);
            //  sqlcom.Parameters.AddWithValue("@User_Type", fc.User_Type);
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
                Session["FullName"] = ds.Tables[0].Rows[0]["FullName"].ToString();
                Session["Application_Id"] = ds.Tables[0].Rows[0]["Application_Id"].ToString();
                Session["Student_Id"] = ds.Tables[0].Rows[0]["Student_Id"].ToString();
                Session["FatherName"] = ds.Tables[0].Rows[0]["FatherName"].ToString();
                Session["FatherContactNumber"] = ds.Tables[0].Rows[0]["FatherContactNumber"].ToString();
                Session["FatherEmail"] = ds.Tables[0].Rows[0]["FatherEmail"].ToString();
                Session["MotherName"] = ds.Tables[0].Rows[0]["MotherName"].ToString();
                Session["MotherContactNumber"] = ds.Tables[0].Rows[0]["MotherContactNumber"].ToString();
                Session["MotherEmail"] = ds.Tables[0].Rows[0]["MotherEmail"].ToString();
                Session["HomeContactNumber"] = ds.Tables[0].Rows[0]["HomeContactNumber"].ToString();
                Session["Student_Email"] = ds.Tables[0].Rows[0]["Student_Email"].ToString();
                Session["Password"] = ds.Tables[0].Rows[0]["Password"].ToString();
                Session["DOB"] = ds.Tables[0].Rows[0]["DOB"].ToString();
                //Session["MotherContactName"] = ds.Tables[0].Rows[0]["MotherContactName"].ToString();
                // Session["MotherEmail"] = ds.Tables[0].Rows[0]["MotherEmail"].ToString();
                //Session["ParentContact"] = ds.Tables[0].Rows[0]["ParentContact"].ToString();

                //ViewData["sucess_msg"] = Session["username"];

                return this.RedirectToAction("StudentRegistrationForm", "StudentDetail");
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



        public ActionResult StudentRegistrationForm()
        {
            // DataBaseAcessLayer.SchoolAdminDB dbhandle = new DataBaseAcessLayer.SchoolAdminDB();
            //DataBaseAcessLayer.ParentDetailsDB dbhandle = new DataBaseAcessLayer.ParentDetailsDB();
            return View();
        }
        [HttpPost]
        public ActionResult StudentRegistrationForm(StudentRegistration smodel)
        {

           // if (ModelState.IsValid)
           // {
                DataBaseAcessLayer.StudentDetailsDB dbhandle = new DataBaseAcessLayer.StudentDetailsDB();
                dbhandle.StudentRegister(smodel);
                TempData["msg"] = "Parent  Details Updated Successfully!";
                return this.RedirectToAction("StudentIndexPage", "StudentDetail");
           // }
           // return View();

        }

        public JsonResult CheckUsernameAvailability(string Student_Email, string School_Code)
        {
            System.Threading.Thread.Sleep(200);
            ParentRegistration model = new ParentRegistration();
            // var SeachData = model.ParentRegistration.Where(x => x.StuName == userdata).SingleOrDefault();
            String con = ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            // string sqlquery = "Select ParentID,ParentName,ParentEmail, ParentPassword,School_Code FROM [dbo].[ParentRegistration] WHERE  ParentEmail='"+ useremail + "'";
            string sqlquery = "Select Student_Email FROM [dbo].[School_Student_Details] WHERE Student_Email ='" + Student_Email + "' AND School_Code ='" + School_Code + "'";

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
        public ActionResult View_Attendance()
        {
            if (Session["Student_Id"] == null)
            {
                return Redirect("~/StudentDetail/StudentLogin");
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
        public JsonResult AjaxMethod_StudentAttendance(String Start_Date,String End_Date)
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
            string sqlquery = "SELECT Period_Date, [First] As First_Period,[Second] AS Second_Period,[Third] AS Third_Period,[Fourth] AS Fourth_Period ,[Fifth] AS Fifth_Period,[Sixth] AS Sixth_Period ,[Seventh] AS Seventh_Period ,[Eighth] AS Eighth_Period ,[Nineth] AS Nineth_Period ,[Tenth] AS Tenth_Period   FROM (SELECT  SA.Period_Date, SA.[Period_Name], SA.Presence_Status FROM  Student_Attendance AS SA WHERE SA.School_Code = '"+Session["School_Code"]+"' AND  SA.Student_Id ='"+Session["Student_Id"]+"' AND  SA.Class_Id = '"+Session["Class_Id"]+"'   AND  SA.Session_Year='"+Session["Session_Year"]+"' AND  SA.Period_Date BETWEEN  '" + Start_Date + "' AND '" + End_Date+"') Tab1 PIVOT (MAX(Presence_Status) FOR[Period_Name] IN([First],[Second],[Third],[Fourth],[Fifth],[Sixth],[Seventh],[Eighth],[Nineth],[Tenth]) ) AS Tab2 ORDER BY Tab2.Period_Date";
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


        ////////////Student Home Work////////////////////////////////////
        public JsonResult AjaxgetDetail(int Id)
        {

            Homework model = new Homework();
            List<Homework> Templist = new List<Homework>();

            List<Homework> Filelist = new List<Homework>();

            List<Homework> Fileresponse = new List<Homework>();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("HomeAssignment", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Student_Id", Session["Student_Id"]);

            cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);

            cmd.Parameters.AddWithValue("@Id", Id);



            cmd.Parameters.AddWithValue("@Query", 7);



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


                            Teacher_Name = Convert.ToString(dr["Employee_Name"]),
                            ClassName = Convert.ToString(dr["Class_Name"]),
                            SectionName = Convert.ToString(dr["Section_Name"]),
                            Home_Desc = Convert.ToString(dr["Description"]),

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
                        model.status = (dr["Status"] == DBNull.Value ? "N/A" : Convert.ToString(dr["Status"]));
                        model.Subm_Date = (dr["Subm_Date"] == DBNull.Value ? "N/A" : Convert.ToString(dr["Subm_Date"]).Substring(0, 10));
                    }
                }
                if (i == 3)
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



            }



            model.Templist = Templist;
            model.Fileresponse = Fileresponse;
            model.Filelist = Filelist;
            return Json(model);
        }

        /////For files to be uploaded
        ///



        [HttpPost]

        public JsonResult AjaxuploadDetail(int id)
        {
            Homework model = new Homework();



            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("HomeWorkAssigned", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);
            cmd.Parameters.AddWithValue("@Student_ID", Session["Student_Id"]);

            cmd.Parameters.AddWithValue("@ID", id);


            cmd.Parameters.AddWithValue("@Query", 2);


            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();



            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            cmd = new SqlCommand("HomeWorkAssigned", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);
            cmd.Parameters.AddWithValue("@Student_ID", Session["Student_Id"]);

            cmd.Parameters.AddWithValue("@ID", id);


            cmd.Parameters.AddWithValue("@Query", 3);



            DataTable dt = new DataTable();

            sd = new SqlDataAdapter(cmd);


            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {

                model.FID = Convert.ToInt32(dr["Home_Response_ID"]);

            }




            return Json(model);
        }


        [HttpPost]
        public JsonResult AjaxUploadFile()
        {
            string fname = "", fpath = "";

            int File_ID = 0;

            String con = ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);

            string sqlquery = "SELECT Max(Home_Response_ID) as ID FROM [dbo].[Homework_Response] where  Student_ID=" + Session["Student_Id"];///WHERE ST_Section = '"+ value + "'
            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlcom;
            DataTable dt = new DataTable();
            da.Fill(dt);
            sqlcon.Close();
            foreach (DataRow dr in dt.Rows)
            {

                File_ID = (dr["ID"] == DBNull.Value ? 1 : Convert.ToInt32(dr["ID"]));
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

                        sqlquery = "Insert into File_Response(ResponseID,FileName,FilePath) values (" + File_ID + ",'" + fname + "','" + path + "')";
                        sqlcon.Open();
                        sqlcom = new SqlCommand(sqlquery, sqlcon);
                        da = new SqlDataAdapter();
                        da.SelectCommand = sqlcom;

                        sqlcom.ExecuteNonQuery();
                        sqlcon.Close();


                        fname = Path.Combine(Server.MapPath("../AppFiles/Images/"), fname);
                        files[i].SaveAs(fname);




                    }




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


        ///////////////////////////////

        public ActionResult HomeWorkUpload()
        {

            if (Session["School_Code"] == null)
            {
                return Redirect("~/StudentDetail/StudentLogin");
            }

            else
            {

                Homework model = new Homework();


                List<Homework> Templist = new List<Homework>();


                /*model.Class_Name = PopulateDropDown("select Class_Id, Class_Name from Class_Master", "Class_Name", "Class_Id");

                model.Section_Name = PopulateDropDown("select Section_Id, Section_Name from School_Section_Master where School_Code='"+Session["School_Code"]+"'", "Section_Name", "Section_Id");
                model.Subject_Name = PopulateDropDown("select Distinct  Subject_Name, Subject_ID from School_Subject_Master Where School_Code='" + Session["School_Code"] + "'", "Subject_Name", "Subject_ID");
                */


                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
                SqlCommand cmd = new SqlCommand("HomeAssignment", con);
                cmd.CommandType = CommandType.StoredProcedure;

                ///cmd.Parameters.AddWithValue("@Student_Id", fc["Student_Id"]);

                cmd.Parameters.AddWithValue("@School_Code", Session["School_Code"]);
                cmd.Parameters.AddWithValue("@Query", 4);



                SqlDataAdapter sd = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    Templist.Add(new Homework
                    {
                        ID = Convert.ToInt32(dr["ID"]),
                        Teacher_ID = (dr["Teacher_ID"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Teacher_ID"])),
                        sub_id = Convert.ToInt32(dr["Subject_ID"]),

                        class_id = Convert.ToInt32(dr["Class_ID"]),
                        sec_id = Convert.ToInt32(dr["Section_ID"]),
                        //SectionName= Convert.ToString(dr["Section_Name"]),
                        subject_name = Convert.ToString(dr["subject_name"]),
                        topic = Convert.ToString(dr["Topic"]),
                        Home_Desc = Convert.ToString(dr["Description"]),
                        date_assigned = Convert.ToString(dr["Assigned_Date"]).Substring(0, 10),
                        due_date = Convert.ToString(dr["Due_Date"]).Substring(0, 10),
                        // File_Name= Convert.ToString(dr["File_Path"])+ Convert.ToString(dr["File_Name"]),


                    });

                }

                model.Templist = Templist;


                return View(model);
            }
        }
        [HttpPost]
        public ActionResult AjaxUploadFiles()
        {
            string fname = "";
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
                        fname = fname.Replace(" ", "_");

                        // Get the complete folder path and store the file inside it.  
                        fname = Path.Combine(Server.MapPath("../AppFiles/Images/"), fname);
                        file.SaveAs(fname);

                        //string fileNamee = Path.GetFileNameWithoutExtension(Report.FileName);
                        //string extension = Path.GetExtension(Report.FileName);
                    }
                    // Returns message that successfully uploaded  
                    return Json(Convert.ToString(Server.MapPath("../AppFiles/Images/")));
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


        /////////////////////Student HomeWork///////////////////////////////

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
                return Redirect("~/StudentDetail/StudentLogin");
            }
            else
            {
                StudentSyllabus model = new StudentSyllabus();
                //  model.PeriodList = PopulateDropDown("SELECT Period_Id, Period_Name FROM Period_Master  WHERE School_Code='" + Session["School_Code"] + "'", "Period_Name", "Period_Id");
                //model.Year_Name = PopulateDropDown("SELECT Year, Year_Name FROM Year", "Year_Name", "Year");

               model.ExamList = PopulateDropDown("SELECT Exam_Term_id, Exam_Term_Name FROM School_Exam_Term_Master", "Exam_Term_Name", "Exam_Term_id");
             //   model.Class_Name = PopulateDropDown("SELECT Class_Id, Class_Name FROM Class_Master  WHERE School_Code='" + Session["School_Code"] + "'", "Class_Name", "Class_Id");
              //  model.Year_Name = PopulateDropDown("SELECT Year, Year_Name FROM Year", "Year_Name", "Year");

                //model.SectionList = PopulateDropDown("SELECT Section_Name, Section_Id FROM School_Section_Master WHERE School_Code='" + Session["School_Code"] + "'", "Section_Name", "Section_Id");

                return View(model);
            }
        }



        [HttpPost]
        public JsonResult AjaxMethod_StudentSyllabus( String Exam_Id)
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
            string sqlquery = "SELECT SS.*,CM.Class_Name,SSM.Subject_Name,SETM.Exam_Term_Name   FROM Student_Syllabus AS SS, Class_Master AS CM , School_Subject_Master AS SSM,School_Exam_Term_Master AS SETM  WHERE SS.School_Code ='" + School_Code + "'  AND SS.Class_Id = '" + Session["Class_Id"] + "'  AND SS.Exam_Id='" + Exam_Id + "' AND  SS.Class_Id = CM.Class_Id AND SS.Subject_Id = SSM.Subject_Id AND SS.Exam_Id=SETM.Exam_Term_id ";

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
                       // Section_Nam = String.IsNullOrEmpty(sdr["Section_Name"].ToString()) ? "NA" : sdr["Section_Name"].ToString(),
                        Subject_Name = String.IsNullOrEmpty(sdr["Subject_Name"].ToString()) ? "NA" : sdr["Subject_Name"].ToString(),
                        // Fourth_Period = String.IsNullOrEmpty(sdr["Fourth_Period"].ToString()) ? "NA" : sdr["Fourth_Period"].ToString(),
                        // Fifth_Period = String.IsNullOrEmpty(sdr["Fifth_Period"].ToString()) ? "NA" : sdr["Fifth_Period"].ToString(),
                        // Sixth_Period = String.IsNullOrEmpty(sdr["Sixth_Period"].ToString()) ? "NA" : sdr["Sixth_Period"].ToString(),
                        // Seventh_Period = String.IsNullOrEmpty(sdr["Seventh_Period"].ToString()) ? "NA" : sdr["Seventh_Period"].ToString(),
                        //Eighth_Period = String.IsNullOrEmpty(sdr["Eighth_Period"].ToString()) ? "NA" : sdr["Eighth_Period"].ToString(),
                        Syllabus_Desc = String.IsNullOrEmpty(sdr["Syllabus_Desc"].ToString()) ? "NA" : sdr["Syllabus_Desc"].ToString(),
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
            string sqlquery = "SELECT SS.*,CM.Class_Name,SSM.Subject_Name,SETM.Exam_Term_Name   FROM Student_Syllabus AS SS, Class_Master AS CM ,School_Subject_Master AS SSM,School_Exam_Term_Master AS SETM  WHERE SS.School_Code ='" + School_Code + "'  AND SS.Class_Id = '" + Session["Class_Id"] + "' AND SS.Class_Id = CM.Class_Id AND  SS.Subject_Id = SSM.Subject_Id AND SS.Exam_Id=SETM.Exam_Term_id ";

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