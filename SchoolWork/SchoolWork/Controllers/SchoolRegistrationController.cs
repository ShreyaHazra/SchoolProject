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
using System.IO;

using System.Net;
using System.Net.Mail;

namespace SchoolWork.Controllers
{
    public class SchoolRegistrationController : Controller

    {
       // DataBaseAcessLayer.StudentAdmissionDB dblayer2 = new DataBaseAcessLayer.StudentAdmissionDB();
        DataBaseAcessLayer.SuperAdminDB dblayer2 = new DataBaseAcessLayer.SuperAdminDB();

        // GET: SchoolRegistration
        public ActionResult SchoolRegister()
        {

            SchoolRegistration model = new SchoolRegistration();
            model.Countries = PopulateDropDown("SELECT CountryId, CountryName FROM country", "CountryName", "CountryId");
            model.Board_Name = PopulateDropDown("SELECT Board_Id, Board_Name FROM Board_Master", "Board_Name", "Board_Id");

            return View(model);

        }




        public ActionResult SchoolLogin()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AjaxMethod(string type, int value)
        {
            SchoolRegistration model = new SchoolRegistration();
            switch (type)
            {
                case "CountryId":
                    model.States = PopulateDropDown("SELECT StateId, StateName FROM state WHERE CountryId = " + value, "StateName", "StateId");
                    break;
                case "StateId":
                    model.Cities = PopulateDropDown("SELECT CityId, CityName FROM city  WHERE StateId = " + value, "CityName", "CityId");
                    break;
            }
            return Json(model);
        }

        [HttpPost]
        public ActionResult SchoolRegister(int countryId, int stateId, int cityId, FormCollection fc)
        {
            SchoolRegistration model = new SchoolRegistration();
            model.Countries = PopulateDropDown("SELECT CountryId, CountryName FROM country", "CountryName", "CountryId");
            model.States = PopulateDropDown("SELECT StateId, StateName FROM state WHERE CountryId = " + countryId, "StateName", "StateId");
            model.Cities = PopulateDropDown("SELECT CityId, CityName FROM city WHERE StateId = " + stateId, "CityName", "CityId");

            try { 

            if (ModelState.IsValid)
            {
                SchoolRegistration stdsch = new SchoolRegistration();
                stdsch.SchoolName = fc["SchoolName"];
                stdsch.SchoolCode = fc["SchoolCode"];
                stdsch.SchoolEmail = fc["SchoolEmail"];
                stdsch.SchoolPassword = fc["SchoolPassword"];
                stdsch.SchoolPhone = fc["SchoolPhone"];
                stdsch.SchoolContactPerson = fc["SchoolContactPerson"];
                stdsch.SchoolContactPersonEmail = fc["SchoolContactPersonEmail"];
                stdsch.SchoolContactPersonPhone = fc["SchoolContactPersonPhone"];
                stdsch.SchoolAddress1 = fc["SchoolAddress1"];
                stdsch.SchoolAddress2 = fc["SchoolAddress2"];
                stdsch.CountryId = Convert.ToInt32(fc["CountryId"]);
                stdsch.StateId = Convert.ToInt32(fc["StateId"]);
                stdsch.CityId = Convert.ToInt32(fc["CityId"]);
                stdsch.Board_Id = Convert.ToInt32(fc["Board_Id"]);
               // stdsch.SchoolAddress1 = fc["SchoolAddress1"];
                //stdsch.SchoolAddress2 = fc["SchoolAddress2"];
                dblayer2.Add_School(stdsch);
                MailMessage mail = new MailMessage("pro@gmail.com", stdsch.SchoolEmail, "mailSubject2", "mailBody2");
                //mail.From = new MailAddress("denovo@gmail.com", "nameEmail aa");
                //mail.IsBodyHtml = true; // necessary if you're using html email
                mail.From = new MailAddress("pro@gmail.com", "Registration Successfull");
                //  mail.Subject = "Hii " + parreg.ParentName +"You are Registered SuccesFully on" + parreg.School_Code +"Your Email Id is"+ parreg.ParentEmail+"And Password is:"+ parreg.ParentPassword+"<br/>";
                mail.Subject = "Registration Successfull";
                mail.Body = "Hii " + stdsch.SchoolName + "You are Registered SuccesFully on  School Days .  Your User \r\n Id: " + stdsch.SchoolEmail + "\r\n  Password:" + stdsch.SchoolPassword + " \r\n ";

                //new MailAddress("pro@gmail.com", "nameEmail aa");
                NetworkCredential credential = new NetworkCredential("schooldays2050@gmail.com", "Marine@1");
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = credential;
                smtp.Send(mail);



                TempData["msg"] = "Student Registration Successful!";
            }
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;

            }
            return this.RedirectToAction("Startpage", "Home");
           // return View(model);
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


        public JsonResult CheckUsernameAvailability(string useremail)
        {
            System.Threading.Thread.Sleep(200);
            //ParentRegistration model = new ParentRegistration();
            SchoolRegistration model = new SchoolRegistration();
            
            String con = ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString;
            SqlConnection sqlcon = new SqlConnection(con);
            string sqlquery = "Select School_Email FROM [dbo].[School_Details_Master] WHERE School_Email ='" + useremail + "' ";
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


    }
}