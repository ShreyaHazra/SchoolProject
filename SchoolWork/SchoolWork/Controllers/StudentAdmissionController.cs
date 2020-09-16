using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using SchoolWork.Models;
using System.IO;
using System.Web.SessionState;


using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;


namespace SchoolWork.Controllers
{
    public class StudentAdmissionController : Controller
    {
       
        DataBaseAcessLayer.StudentAdmissionDB dblayer = new DataBaseAcessLayer.StudentAdmissionDB();
        //  DataBaseAcessLayer.ParentDetailsDB dblayer2 = new DataBaseAcessLayer.ParentDetailsDB();
        //  // GET: StudentAdmission
        //  public ActionResult Index()
        //  {
        //      return View();
        //  }

        //  public ActionResult ParentRegister()
        //  {

        //      return View();
        //  }
        //  [HttpPost]
        //  public ActionResult ParentRegister(FormCollection fc)
        //  {
        //      try
        //      {
        //          if (ModelState.IsValid)
        //          {
        //              StudentAdmission stdadm = new StudentAdmission();
        //              stdadm.ParentName = fc["ParentName"];
        //              stdadm.ParentName = fc["ParentContact"];
        //              stdadm.ParentEmail = fc["ParentEmail"];
        //              stdadm.ParentPassword = fc["ParentPassword"];
        //              dblayer2.Add_record(stdadm);
        //              TempData["msg"] = "Student Registration Successful!";
        //          }

        //          return View();
        //      }
        //      catch
        //      {

        //          return View();
        //      }
        //  }



        //  public ActionResult ParentLogin()
        //  {

        //      return View();


        //  }
        //[HttpPost]
        //  public ActionResult ParentLogin(UserLogin fc)
        //  {
        //      String con = ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString;
        //      SqlConnection sqlcon = new SqlConnection(con);
        //      string sqlquery = "Select ParentID,ParentName,ParentEmail, ParentPassword FROM [dbo].[ParentRegistration] WHERE  ParentEmail=@Email and ParentPassword=@Password";
        //      sqlcon.Open();
        //      SqlCommand sqlcom = new SqlCommand(sqlquery, sqlcon);
        //      sqlcom.Parameters.AddWithValue("@Email", fc.UserName);
        //      sqlcom.Parameters.AddWithValue("@Password", fc.Password);
        //      SqlDataAdapter da = new SqlDataAdapter();
        //      da.SelectCommand = sqlcom;
        //      DataSet ds = new DataSet();
        //      da.Fill(ds);

        //      SqlDataReader sdr = sqlcom.ExecuteReader();
        //      if (sdr.Read())
        //      {
        //          //Session["username"] = fc.UserName.ToString();
        //          Session["ParentName"] = ds.Tables[0].Rows[0]["ParentName"].ToString();
        //          Session["ParentID"] = ds.Tables[0].Rows[0]["ParentID"].ToString();

        //          //ViewData["sucess_msg"] = Session["username"];

        //          return this.RedirectToAction("ParentDashBoard", "Dashboard");
        //      }
        //      else
        //      {
        //          ViewData["message"] = "Wrong Credentials!";
        //      }

        //      return View();
        //  }

        [HttpGet]
        public ActionResult StudentFormFillup()
        {
            if (Session["ParentID"] == null)
            {
                return Redirect("~/ParentDetails/ParentLogin");
            }
            else
            {
                StudentFormFillup model = new StudentFormFillup();

                try
                {
                    model.Countries = PopulateDropDown("SELECT CountryId, CountryName FROM country", "CountryName", "CountryId");
                    model.School_Name = PopulateDropDown("SELECT School_Id, School_Name FROM School_Details_Master", "School_Name", "School_Id");
                    model.citizenCountry = PopulateDropDown("SELECT CountryId, CountryName FROM country", "CountryName", "CountryId");
                    model.IdProof_Type = PopulateDropDown("SELECT IdProof_Id, IdProof_Name FROM IdProof_Master", "IdProof_Name", "IdProof_Id");
                    model.BloodGroup_Name = PopulateDropDown("SELECT BloodGroup_Id, BloodGroup_Name FROM BloodGroup_Master", "BloodGroup_Name", "BloodGroup_Id");
                    model.AdmissionClass_Name = PopulateDropDown("SELECT Class_Id, Class_Name FROM Class_Master", "Class_Name", "Class_Id");
                    model.SchoolBoard_Name = PopulateDropDown("SELECT Board_Id, Board_Name FROM Board_Master", "Board_Name", "Board_Id");

                    if (Session["ParentID"] != null)
                    {
                        int Parent_Iddd = Convert.ToInt32(Session["ParentID"]);
                        String School_Codee = Session["School_Code"].ToString();
                        model.StudentDetails = GetStudentDetails(Parent_Iddd, School_Codee);
                    }

                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;

                }

                return View(model);
            }

        }

        [HttpPost]
        public ActionResult StudentFormFillup(HttpPostedFileBase BirthCertificateUpload, HttpPostedFileBase DisabilityCertificateUpload, HttpPostedFileBase SchoolTransferCertificateUpload, HttpPostedFileBase FinalExamResultUpload, HttpPostedFileBase BoardExamCertificateUpload, HttpPostedFileBase BoardExamResultUpload, HttpPostedFileBase ImageUpload, HttpPostedFileBase SignatureUpload, FormCollection fc, int countryId = '0', int stateId = '0', int cityId = '0')
        {
            StudentFormFillup model = new StudentFormFillup();

            try { 
            // HttpPostedFileBase ImageUpload
            // HttpPostedFileBase SignatureUpload
            model.Countries = PopulateDropDown("SELECT CountryId, CountryName FROM country", "CountryName", "CountryId");
            model.States = PopulateDropDown("SELECT StateId, StateName FROM state WHERE CountryId = " + countryId, "StateName", "StateId");
            model.Cities = PopulateDropDown("SELECT CityId, CityName FROM city WHERE StateId = " + stateId, "CityName", "CityId");

            model.School_Name = PopulateDropDown("SELECT School_Id, School_Name FROM School_Details_Master", "School_Name", "School_Id");
            model.citizenCountry = PopulateDropDown("SELECT CountryId, CountryName FROM country", "CountryName", "CountryId");
            model.IdProof_Type = PopulateDropDown("SELECT IdProof_Id, IdProof_Name FROM IdProof_Master", "IdProof_Name", "IdProof_Id");
            model.BloodGroup_Name = PopulateDropDown("SELECT BloodGroup_Id, BloodGroup_Name FROM BloodGroup_Master", "BloodGroup_Name", "BloodGroup_Id");
            model.AdmissionClass_Name = PopulateDropDown("SELECT Class_Id, Class_Name FROM Class_Master", "Class_Name", "Class_Id");
            model.SchoolBoard_Name = PopulateDropDown("SELECT Board_Id, Board_Name FROM Board_Master", "Board_Name", "Board_Id");

           if (Session["ParentID"] != null)
           {
                int Parent_Iddd = Convert.ToInt32(Session["ParentID"]);
                String School_Codee = Session["School_Code"].ToString();
                model.StudentDetails = GetStudentDetails(Parent_Iddd, School_Codee);
           }

            if (ModelState.IsValid)
            {

                StudentFormFillup stdsch = new StudentFormFillup();
                String form_step = Request["Query_step"];
                switch (form_step)
                {

                    case "Step1":

                        // stdsch.SchoolName = fc["SchoolName"];
                        //stdsch.Query_step = fc["Query_step"];
                        stdsch.Query_step = "Step1";
                        stdsch.StepOne_status = fc["StepOne_status"];
                        stdsch.first_name = fc["first_name"];
                        stdsch.middle_name = fc["middle_name"];
                        stdsch.last_name = fc["last_name"];
                        stdsch.CurrentAddress1 = fc["CurrentAddress1"];
                        stdsch.CurrentAddress2 = fc["CurrentAddress2"];
                        stdsch.currentzipcode = fc["currentzipcode"]; 

                        stdsch.CountryId = Convert.ToInt32(fc["CountryId"]);
                        stdsch.StateId = Convert.ToInt32(fc["StateId"]);
                        stdsch.CityId = Convert.ToInt32(fc["CityId"]);
                        stdsch.PermanentAddress1 = fc["PermanentAddress1"];
                        stdsch.PermanentAddress2 = fc["PermanentAddress2"];
                        stdsch.permanentzipcode = fc["permanentzipcode"];
                        stdsch.DOB = fc["DOB"];
                        stdsch.POB = fc["POB"];
                        stdsch.BCN = fc["BCN"];
                        stdsch.CitizenCountryId = Convert.ToInt32(fc["CitizenCountryId"]);
                        String idproof_val = Request["IdProof_Id"];
                        if (!String.IsNullOrEmpty(idproof_val))
                        {
                            // param is set
                            stdsch.IdProof_Id = Convert.ToInt32(fc["IdProof_Id"]);
                            stdsch.IdProof_Number = fc["IdProof_Number"];
                        }

                        stdsch.PassPort_Number = fc["PassPort_Number"];
                        stdsch.BloodGroup_Id = Convert.ToInt32(fc["BloodGroup_Id"]);

                        //  if (model.BirthCertificateUpload != null && model.BirthCertificateUpload.ContentLength > 0)
                        //  
                        //  if ( Request.Files["BirthCertificateUpload"] != null)
                        if (BirthCertificateUpload != null)
                        {

                            string fileNamee = Path.GetFileNameWithoutExtension(BirthCertificateUpload.FileName);                          
                            string extension = Path.GetExtension(BirthCertificateUpload.FileName);
                            stdsch.BirthCertificate_Name = fileNamee + extension;
                            fileNamee = fileNamee + DateTime.Now.ToString("yymmssff") + extension;
                             BirthCertificateUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileNamee));
                            // stdsch.BirthCertificatePath = "~/AppFiles/Images/"+ fileName;
                            stdsch.BirthCertificatePath =  fileNamee;

                            //stdsch.BirthCertificatePath =  fileName;
                            /* var postedFile = Request.Files["BirthCertificateUpload"];
                              string fileName = postedFile.FileName;
                              string extension = Path.GetExtension(postedFile.FileName);
                              fileName = fileName + DateTime.Now.ToString("yymmssff") + extension;
                              var filePath = Server.MapPath("~/AppFiles/Images/" + fileName);
                              postedFile.SaveAs(filePath);
                              stdsch.BirthCertificatePath = fileName;*/
                        }

                        String Special_Care_val = Request["Special_Care"];
                        if (!String.IsNullOrEmpty(Special_Care_val)) 
                        {
                            stdsch.Special_Care = Convert.ToInt32(fc["Special_Care"]);
                            stdsch.Special_Care_Description = fc["Special_Care_Description"];
                      
                        }

                        String Disability_val = Request["Disability"];
                        if (!String.IsNullOrEmpty(Disability_val))
                        {
                            stdsch.Disability = Convert.ToInt32(fc["Disability"]);
                            stdsch.Disability_Percentage = fc["Disability_Percentage"];
                            stdsch.Disability_Description = fc["Disability_Description"];
                            stdsch.Disability_Certificate_Number = fc["Disability_Certificate_Number"];
                          //  stdsch.DisabilityCertificatePath = fc["DisabilityCertificatePath"];
                            if(DisabilityCertificateUpload != null)
                            {
                            string fileName_disable = Path.GetFileNameWithoutExtension(DisabilityCertificateUpload.FileName);                           
                            string extension = Path.GetExtension(DisabilityCertificateUpload.FileName);
                            stdsch.DisabilityCertificat_Name = fileName_disable + extension;
                            fileName_disable = fileName_disable + DateTime.Now.ToString("yymmssff") + extension;
                            DisabilityCertificateUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName_disable));
                                //  stdsch.DisabilityCertificatePath = "~/AppFiles/Images/" + fileName_disable;
                                stdsch.DisabilityCertificatePath = fileName_disable;
                                /// stdsch.DisabilityCertificatePath =  fileName_disable;
                            }


                        }
                            dblayer.Add_student_step1(stdsch);
                        TempData["msg"] = "Step 1 Successfully!";
                        break;
                    case "Step2":
                        StudentFormFillup stdsch2 = new StudentFormFillup();
                        // stdsch2.Query_step = fc["Query_step"];Step2
                        stdsch2.Query_step = "Step2";
                        stdsch2.FatherName = fc["FatherName"];
                        stdsch2.FatherContactNumber = fc["FatherContactNumber"];
                        stdsch2.FatherEmail = fc["FatherEmail"];
                        stdsch2.MotherName = fc["MotherName"];
                        stdsch2.MotherContactNumber = fc["MotherContactNumber"];
                        stdsch2.MotherEmail = fc["MotherEmail"];
                        stdsch2.HomeContactNumber = fc["HomeContactNumber"];
                        if (!string.IsNullOrEmpty(fc["LocalGurdian"]))
                        {
                           // stdsch2.LocalGurdian = true; 
                        stdsch2.LocalGurdianValue = fc["LocalGurdian"];
                        stdsch2.LocalGurdianName = fc["LocalGurdianName"];
                        stdsch2.LocalGurdianEmail = fc["LocalGurdianEmail"];
                        stdsch2.LocalGurdianPhone = fc["LocalGurdianPhone"];
                        }
                        dblayer.Add_student_step2(stdsch2);
                        TempData["msg"] = "Step 2 Successfully!";
                        break;

                    case "Step3":

                        StudentFormFillup stdsch3 = new StudentFormFillup();
                        stdsch3.Query_step = fc["Query_step"];
                        stdsch3.AdmissionClass_Id = Convert.ToInt32(fc["AdmissionClass_Id"]);
                        stdsch3.Last_School_Name = fc["Last_School_Name"];
                        stdsch3.SchoolBoard_Id = Convert.ToInt32(fc["SchoolBoard_Id"]);
                        stdsch3.Last_School_Year = fc["Last_School_Year"];
                        stdsch3.Last_School_Class = fc["Last_School_Class"];
                        stdsch3.School_Transfer_Certifiate_Number = fc["School_Transfer_Certifiate_Number"];
                        // stdsch3.SchoolTransferCertificateUpload = fc["SchoolTransferCertificateUpload"];
                        if(SchoolTransferCertificateUpload != null)
                        {
                            string fileName_trans = Path.GetFileNameWithoutExtension(SchoolTransferCertificateUpload.FileName);                         
                            string extension = Path.GetExtension(SchoolTransferCertificateUpload.FileName);
                            stdsch3.SchoolTransferCertificate_Name = fileName_trans + extension;
                            fileName_trans = fileName_trans + DateTime.Now.ToString("yymmssff") + extension;
                            SchoolTransferCertificateUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName_trans));
                           // stdsch.SchoolTransferCertificatePath = "~/AppFiles/Images/" + fileName_trans;
                            stdsch3.SchoolTransferCertificatePath =  fileName_trans;
                            // stdsch.SchoolTransferCertificatePath = fileName_trans;
                        }

                        stdsch3.Last_School_Exam_Marks = fc["Last_School_Exam_Marks"];
                        stdsch3.Last_School_Total_Marks = fc["Last_School_Total_Marks"];
                        stdsch3.Last_School_Marks_Percentage = fc["Last_School_Marks_Percentage"];
                        // stdsch3.FinalExamResultUpload = fc["FinalExamResultUpload"];
                        if(FinalExamResultUpload != null)
                        {
                            string fileName_finalres = Path.GetFileNameWithoutExtension(FinalExamResultUpload.FileName);                            
                            string extension = Path.GetExtension(FinalExamResultUpload.FileName);
                            stdsch3.FinalExamResult_Name = fileName_finalres + extension;
                            fileName_finalres = fileName_finalres + DateTime.Now.ToString("yymmssff") + extension;
                            FinalExamResultUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName_finalres));
                        //    stdsch3.FinalExamResultPath = "~/AppFiles/Images/" + fileName_finalres;

                            stdsch3.FinalExamResultPath =  fileName_finalres;
                            //stdsch3.FinalExamResultPath = fileName_finalres;
                        }
                        stdsch3.Board_Exam_Marks = fc["Board_Exam_Marks"];
                        stdsch3.Board_Total_Marks = fc["Board_Total_Marks"];
                        stdsch3.Marks_Percentage = fc["Marks_Percentage"];
                        stdsch3.Board_Certificate_Number = fc["Board_Certificate_Number"];
                        // stdsch3.BoardExamCertificateUpload = fc["BoardExamCertificateUpload"];

                        if(BoardExamResultUpload != null)
                        {
                            string fileName_bordexamres = Path.GetFileNameWithoutExtension(BoardExamResultUpload.FileName);
                          //  stdsch3.BoardExamResultName = fileName_bordexamres;
                            string extension = Path.GetExtension(BoardExamResultUpload.FileName);
                            stdsch3.BoardExamResultName = fileName_bordexamres + extension;
                            fileName_bordexamres = fileName_bordexamres + DateTime.Now.ToString("yymmssff") + extension;
                            BoardExamResultUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName_bordexamres));
                           // stdsch3.BoardExamResultPath = "~/AppFiles/Images/" + fileName_bordexamres;

                            stdsch3.BoardExamResultPath =  fileName_bordexamres;
                            // stdsch3.BoardExamResultPath =  fileName_bordexamres;
                        }
                        if(BoardExamCertificateUpload != null)
                        {
                            string fileName_bordexamcer = Path.GetFileNameWithoutExtension(BoardExamCertificateUpload.FileName);                           
                            string extension = Path.GetExtension(BoardExamCertificateUpload.FileName);
                            stdsch3.BoardExamCertificate_Name = fileName_bordexamcer + extension;
                            fileName_bordexamcer = fileName_bordexamcer + DateTime.Now.ToString("yymmssff") + extension;
                            BoardExamCertificateUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName_bordexamcer));
                         /////   stdsch3.BoardExamCertificatePath = "~/AppFiles/Images/" + fileName_bordexamcer;
                            stdsch3.BoardExamCertificatePath =  fileName_bordexamcer;
                         ///// stdsch3.BoardExamCertificatePath = fileName_bordexamcer;
                        }
                        dblayer.Add_student_step3(stdsch3);
                        TempData["msg"] = "Step 3 Successfully!";
                        break;


                    case "Step4":
                        StudentFormFillup stdsch4 = new StudentFormFillup();
                        stdsch4.Query_step = fc["Query_step"];
                     
                        if (ImageUpload != null)
                        {
                            string fileName_Image = Path.GetFileNameWithoutExtension(ImageUpload.FileName);
                            string extension = Path.GetExtension(ImageUpload.FileName);
                            fileName_Image = fileName_Image + DateTime.Now.ToString("yymmssff") + extension;
                            ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName_Image));
                           // stdsch4.ImagePath = "~/AppFiles/Images/" + fileName_bordexamres;
                            stdsch4.ImagePath = fileName_Image;
                        }
                        if (SignatureUpload != null)
                        {
                            string fileName_Signature = Path.GetFileNameWithoutExtension(SignatureUpload.FileName);
                            string extension = Path.GetExtension(SignatureUpload.FileName);
                            fileName_Signature = fileName_Signature + DateTime.Now.ToString("yymmssff") + extension;
                            SignatureUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName_Signature));
                          // stdsch4.SignaturePath = "~/AppFiles/Images/" + fileName_bordexamcer;
                            stdsch4.SignaturePath = fileName_Signature;
                        }

                        dblayer.Add_student_step4(stdsch4);
                        TempData["msg"] = "Step 4 Successfully!";
                        break;

                    case "Step5":
                        StudentFormFillup stdsch5 = new StudentFormFillup();
                        stdsch5.Query_step = fc["Query_step"];
                        //stdsch5.TermsAndConditions = fc["TermsAndConditions"];
                        //                        stdsch5.TermsAndConditions = fields["TermsAndConditions"] != "false";

                        if (!string.IsNullOrEmpty(fc["TermsAndConditions"]))
                         {
                            //  string TermsAndConditionss = fc["TermsAndConditions"];
                            // bool checkRespB = Convert.ToBoolean(TermsAndConditions);
                            // bool TermsAndConditionsss = true;
                            //stdsch5.TermsAndConditions= Convert.ToBoolean(fc["TermsAndConditions"]);
                            stdsch5.TermsAndConditions = true;
                           }
                        dblayer.Add_student_step5(stdsch5);
                        TempData["msg"] = "Your Application is Submitted Successfully!";


                        return this.RedirectToAction("ShowAllStudentApplication", "ParentDetails");
                       
                        //
                        // break;
                }

            }

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

            }

            //TempData["msg"] = "Student Registration Successful!";
            ///Session["retval"] = model.retval;



            // return View(model);
            return this.RedirectToAction("StudentFormFillup", "StudentAdmission");

        }

      /*  [HttpPost]
        public ActionResult StudentFormFillup(HttpPostedFileBase ImageUpload)
        {
            StudentFormFillup model = new StudentFormFillup();
            if (ImageUpload != null)
            {
                string path = Server.MapPath("~/AppFiles/Images");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                ImageUpload.SaveAs(path + Path.GetFileName(ImageUpload.FileName));
                ViewBag.Message = "File uploaded successfully.";
            }

            return View(model);
        }*/

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

                            /*bool isSelected = false;
                         

                            if (Convert.ToInt32(sdr[valueColumn])== 4)
                            {
                                isSelected = true;
                            }*/

                            items.Add(new SelectListItem
                                    {
                                        Text = sdr[textColumn].ToString(),
                                        Value = sdr[valueColumn].ToString(),
                                       // Selected = isSelected

                                    });
                                }
                            }
                            con.Close();
                        }
                    }

                    return items;
                }



       private IEnumerable<StudentAdmission> GetStudentDetails(int Parent_Idd, string School_Codee)
            {

            List<StudentAdmission> students = new List<StudentAdmission>();
            // List<StudentFormFillup> students = new List<StudentFormFillup>();
            // List<SelectListItem> students = new List<SelectListItem>();

            try { 
            String con = ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            //  string query = "SELECT S.*, Isnull(S.first_name, '') + ' ' + Isnull(S.middle_name, '') + ' ' + Isnull(S.last_name, '') AS FullName FROM Student_Master AS S WHERE Parent_Id='" + ParentID + "' AND School_Code = '" + School_Code + "'";
           string query = "SELECT TOP 1 S.*, Isnull(S.first_name, '') + ' ' + Isnull(S.middle_name, '') + ' ' + Isnull(S.last_name, '') AS FullName FROM Student_Master AS S  WHERE S.Parent_Id='" + Parent_Idd + "' AND S.School_Code = '" + School_Codee + "' AND S.Application_Status='In-Progress' ORDER BY S.Student_Id  DESC";
           // string query = "SELECT SDT.*,CNT.CountryName,ST.StateName,CT.CityName,IDP.IdProof_Name,BRD.Board_Name,CLM.Class_Name, Isnull(SDT.first_name, '') + ' ' + Isnull(SDT.middle_name, '') + ' ' + Isnull(SDT.last_name, '') AS FullNam FROM Student_Master AS SDT, country AS CNT, state AS ST,city AS CT, IdProof_Master AS IDP, Class_Master AS CLM, Board_Master AS BRD WHERE SDT.Parent_Id='" + Parent_Idd + "' AND SDT.School_Code = '" + School_Codee + "'  AND  SDT.CountryId = CNT.CountryId AND SDT.StateId = ST.StateId AND SDT.CityId = CT.CityId AND  SDT.IdProof_Id = IDP.IdProof_Id AND SDT.AdmissionClass_Id = CLM.Class_Id AND SDT.SchoolBoard_Id = BRD.Board_Id";


            sqlcon.Open();
            SqlCommand sqlcom = new SqlCommand(query, sqlcon);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = sqlcom;
            //    DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            //  sqlcon.Open();
            da.Fill(dt);
            sqlcon.Close();
            //  SqlDataReader sdr = sqlcom.ExecuteReader();
            foreach (DataRow sdr in dt.Rows)
            {
                students.Add(
                   new StudentAdmission
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





                       StepOne_status = String.IsNullOrEmpty(sdr["Application_Status"].ToString()) ? null : sdr["Application_Status"].ToString(),

                       first_name = String.IsNullOrEmpty(sdr["first_name"].ToString()) ? null : sdr["first_name"].ToString(),
                       middle_name = String.IsNullOrEmpty(sdr["middle_name"].ToString()) ? null : sdr["middle_name"].ToString(),
                       last_name = String.IsNullOrEmpty(sdr["last_name"].ToString()) ? null : sdr["last_name"].ToString(),

                       CurrentAddress1 = String.IsNullOrEmpty(sdr["CurrentAddress1"].ToString()) ? null : sdr["CurrentAddress1"].ToString(),
                       CurrentAddress2 = String.IsNullOrEmpty(sdr["CurrentAddress2"].ToString()) ? null : sdr["CurrentAddress2"].ToString(),
                       currentzipcode = String.IsNullOrEmpty(sdr["currentzipcode"].ToString()) ? null : sdr["currentzipcode"].ToString(),
                       PermanentAddress1 = String.IsNullOrEmpty(sdr["PermanentAddress1"].ToString()) ? null : sdr["PermanentAddress1"].ToString(),
                       PermanentAddress2 = String.IsNullOrEmpty(sdr["PermanentAddress2"].ToString()) ? null : sdr["PermanentAddress2"].ToString(),
                       permanentzipcode = String.IsNullOrEmpty(sdr["permanentzipcode"].ToString()) ? null : sdr["permanentzipcode"].ToString(),
                       BirthCertificatePath = String.IsNullOrEmpty(sdr["BirthCertificatePath"].ToString()) ? null : sdr["BirthCertificatePath"].ToString(),
                       Special_Care = String.IsNullOrEmpty(sdr["Special_Care"].ToString()) ? '0' : Convert.ToInt32(sdr["Special_Care"]),
                       Special_Care_Description = String.IsNullOrEmpty(sdr["Special_Care_Description"].ToString()) ? null : sdr["Special_Care_Description"].ToString(),
                       Disability = String.IsNullOrEmpty(sdr["Disability"].ToString()) ? '0' : Convert.ToInt32(sdr["Disability"]),
                       Disability_Percentage = String.IsNullOrEmpty(sdr["Disability_Percentage"].ToString()) ? null : sdr["Disability_Percentage"].ToString(),
                       Disability_Description = String.IsNullOrEmpty(sdr["Disability_Description"].ToString()) ? null : sdr["Disability_Description"].ToString(),
                       Disability_Certificate_Number = String.IsNullOrEmpty(sdr["Disability_Certificate_Number"].ToString()) ? null : sdr["Disability_Certificate_Number"].ToString(),
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
                       SchoolTransferCertificatePath = String.IsNullOrEmpty(sdr["SchoolTransferCertificatePath"].ToString()) ? null : sdr["SchoolTransferCertificatePath"].ToString(),
                       Last_School_Exam_Marks = String.IsNullOrEmpty(sdr["Last_School_Exam_Marks"].ToString()) ? null : sdr["Last_School_Exam_Marks"].ToString(),
                       Last_School_Total_Marks = String.IsNullOrEmpty(sdr["Last_School_Total_Marks"].ToString()) ? null : sdr["Last_School_Total_Marks"].ToString(),
                       Last_School_Marks_Percentage = String.IsNullOrEmpty(sdr["Last_School_Marks_Percentage"].ToString()) ? null : sdr["Last_School_Marks_Percentage"].ToString(),
                       FinalExamResultPath = String.IsNullOrEmpty(sdr["FinalExamResultPath"].ToString()) ? null : sdr["FinalExamResultPath"].ToString(),
                       Board_Exam_Marks = String.IsNullOrEmpty(sdr["Board_Exam_Marks"].ToString()) ? null : sdr["Board_Exam_Marks"].ToString(),
                       Board_Total_Marks = String.IsNullOrEmpty(sdr["Board_Total_Marks"].ToString()) ? null : sdr["Board_Total_Marks"].ToString(),
                       Marks_Percentage = String.IsNullOrEmpty(sdr["Marks_Percentage"].ToString()) ? null : sdr["Marks_Percentage"].ToString(),
                       Board_Certificate_Number = String.IsNullOrEmpty(sdr["Board_Certificate_Number"].ToString()) ? null : sdr["Board_Certificate_Number"].ToString(),
                       BoardExamCertificatePath = String.IsNullOrEmpty(sdr["BoardExamCertificatePath"].ToString()) ? null : sdr["BoardExamCertificatePath"].ToString(),
                       BoardExamResultPath = String.IsNullOrEmpty(sdr["BoardExamResultPath"].ToString()) ? null : sdr["BoardExamResultPath"].ToString(),
                       ImagePath = String.IsNullOrEmpty(sdr["ImagePath"].ToString()) ? null : sdr["ImagePath"].ToString(),
                       SignaturePath = String.IsNullOrEmpty(sdr["SignaturePath"].ToString()) ? null : sdr["SignaturePath"].ToString()


                   });
            }

            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

            }

            return students;
        }





    }
}