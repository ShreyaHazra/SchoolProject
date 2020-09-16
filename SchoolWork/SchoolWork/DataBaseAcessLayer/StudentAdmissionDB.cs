using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
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

namespace SchoolWork.DataBaseAcessLayer
{
    public class StudentAdmissionDB
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);

        //public void Add_record(StudentAdmission stdadm)
        //{
        //    SqlCommand com = new SqlCommand("std_Parent_Registration", con);
        //    com.CommandType = CommandType.StoredProcedure;
        //    com.Parameters.AddWithValue("@ParentName", stdadm.ParentName);
        //    com.Parameters.AddWithValue("@ParentContact", stdadm.ParentContact);
        //    com.Parameters.AddWithValue("@ParentEmail", stdadm.ParentEmail);
        //    com.Parameters.AddWithValue("@ParentPassword", stdadm.ParentPassword);       
        //    con.Open();
        //    com.ExecuteNonQuery();
        //    con.Close();
        //}

        //public void Add_School(SchoolRegistration stdsch)
        //{
        //    //SqlCommand com = new SqlCommand("std_School_Registration", con);
        //    SqlCommand com = new SqlCommand("School_InsertUpdateDelete", con);
        //    com.CommandType = CommandType.StoredProcedure;
        //    com.Parameters.AddWithValue("@SchoolName", stdsch.SchoolName);
        //    com.Parameters.AddWithValue("@SchoolCode", stdsch.SchoolCode);
        //    com.Parameters.AddWithValue("@SchoolEmail", stdsch.SchoolEmail);
        //    com.Parameters.AddWithValue("@SchoolPassword", stdsch.SchoolPassword);
        //    com.Parameters.AddWithValue("@SchoolPhone", stdsch.SchoolPhone);
        //    com.Parameters.AddWithValue("@SchoolContactPerson", stdsch.SchoolContactPerson);
        //    com.Parameters.AddWithValue("@SchoolContactPersonEmail", stdsch.SchoolContactPersonEmail);
        //    com.Parameters.AddWithValue("@SchoolContactPersonPhone", stdsch.SchoolContactPersonPhone);
        //    com.Parameters.AddWithValue("@SchoolAddress1", stdsch.SchoolAddress1);
        //    com.Parameters.AddWithValue("@SchoolAddress2", stdsch.SchoolAddress2);
        //    com.Parameters.AddWithValue("@CountryId", stdsch.CountryId);
        //    com.Parameters.AddWithValue("@StateId", stdsch.StateId);
        //    com.Parameters.AddWithValue("@CityId", stdsch.CityId);
        //    com.Parameters.AddWithValue("@Board_Id", stdsch.Board_Id);
        //    com.Parameters.AddWithValue("@Query", 1);

        //    con.Open();
        //    com.ExecuteNonQuery();
        //    con.Close();
        //}

        public void Add_student_step1(StudentFormFillup stdsch)
        {

            try { 
            String School_Code = HttpContext.Current.Session["School_Code"].ToString();
            int Parent_Id = Convert.ToInt32(HttpContext.Current.Session["ParentID"]);
            //SqlCommand com = new SqlCommand("std_School_Registration", con);
            SqlCommand com = new SqlCommand("StudentAdmission_Formfillup", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Query_step", stdsch.Query_step);
            com.Parameters.AddWithValue("@StepOne_status", stdsch.StepOne_status);
            com.Parameters.AddWithValue("@Parent_Id", Parent_Id);
            com.Parameters.AddWithValue("@School_Code", School_Code);
            com.Parameters.AddWithValue("@first_name", stdsch.first_name);
            com.Parameters.AddWithValue("@middle_name", stdsch.middle_name);
            com.Parameters.AddWithValue("@last_name", stdsch.last_name);
            com.Parameters.AddWithValue("@CurrentAddress1", stdsch.CurrentAddress1);
            com.Parameters.AddWithValue("@CurrentAddress2", stdsch.CurrentAddress2);
            com.Parameters.AddWithValue("@currentzipcode", stdsch.currentzipcode);

            com.Parameters.AddWithValue("@CountryId", stdsch.CountryId);
            com.Parameters.AddWithValue("@StateId", stdsch.StateId);
            com.Parameters.AddWithValue("@CityId", stdsch.CityId);
            com.Parameters.AddWithValue("@PermanentAddress1", stdsch.PermanentAddress1);
            com.Parameters.AddWithValue("@PermanentAddress2", stdsch.PermanentAddress2);
            com.Parameters.AddWithValue("@permanentzipcode", stdsch.permanentzipcode);

            com.Parameters.AddWithValue("@DOB", stdsch.DOB);
            com.Parameters.AddWithValue("@POB", stdsch.POB);
            com.Parameters.AddWithValue("@BCN", stdsch.BCN);
            com.Parameters.AddWithValue("@CitizenCountryId", stdsch.CitizenCountryId);
            com.Parameters.AddWithValue("@BirthCertificate_Name", stdsch.BirthCertificate_Name); 
            com.Parameters.AddWithValue("@BirthCertificatePath", stdsch.BirthCertificatePath);


            if (stdsch.IdProof_Id != 0)
            {
                com.Parameters.AddWithValue("@IdProof_Id", stdsch.IdProof_Id);
                com.Parameters.AddWithValue("@IdProof_Number", stdsch.IdProof_Number);
            }
            com.Parameters.AddWithValue("@PassPort_Number", stdsch.PassPort_Number);
            com.Parameters.AddWithValue("@BloodGroup_Id", stdsch.BloodGroup_Id);

            if (stdsch.Special_Care != 0)
            {
                com.Parameters.AddWithValue("@Special_Care", stdsch.Special_Care);
                com.Parameters.AddWithValue("@Special_Care_Description", stdsch.Special_Care_Description);
            }

            if (stdsch.Disability != 0)
            {
                com.Parameters.AddWithValue("@Disability", stdsch.Disability);
                com.Parameters.AddWithValue("@Disability_Percentage", stdsch.Disability_Percentage);
                com.Parameters.AddWithValue("@Disability_Description", stdsch.Disability_Description);
                com.Parameters.AddWithValue("@Disability_Certificate_Number", stdsch.Disability_Certificate_Number);
                com.Parameters.AddWithValue("@DisabilityCertificat_Name", stdsch.DisabilityCertificat_Name);
                com.Parameters.AddWithValue("@DisabilityCertificatePath", stdsch.DisabilityCertificatePath);
              
            }

            //com.Parameters.Add("@retValue", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.ReturnValue;
            //int retval = (Int32)com.Parameters["@retValue"].Value;
            // Session["retval"] = retval;
            // SessionStateStoreData["retval"] = retval;
            // retval
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            }
            catch (Exception ex)
            {
                // ViewBag.Error = ex.Message;

            }
            /// return retval;
        }

        public void Add_student_step2(StudentFormFillup stdsch2)
        {
            try { 
            String School_Code = HttpContext.Current.Session["School_Code"].ToString();
            int Parent_Id = Convert.ToInt32(HttpContext.Current.Session["ParentID"]);
            //SqlCommand com = new SqlCommand("std_School_Registration", con);
            SqlCommand com = new SqlCommand("StudentAdmission_Formfillup", con);
            com.CommandType = CommandType.StoredProcedure;
            //  com.Parameters.AddWithValue("@SchoolName", stdsch.SchoolName);
            com.Parameters.AddWithValue("@Query_step", stdsch2.Query_step);
            com.Parameters.AddWithValue("@Parent_Id", Parent_Id);
            com.Parameters.AddWithValue("@School_Code", School_Code);
            com.Parameters.AddWithValue("@FatherName", stdsch2.FatherName);
            com.Parameters.AddWithValue("@FatherContactNumber", stdsch2.FatherContactNumber);
            com.Parameters.AddWithValue("@FatherEmail", stdsch2.FatherEmail);
            com.Parameters.AddWithValue("@MotherName", stdsch2.MotherName);
            com.Parameters.AddWithValue("@MotherContactNumber", stdsch2.MotherContactNumber);
            com.Parameters.AddWithValue("@MotherEmail", stdsch2.MotherEmail);
            com.Parameters.AddWithValue("@HomeContactNumber", stdsch2.HomeContactNumber);
            com.Parameters.AddWithValue("@LocalGurdianValue", stdsch2.LocalGurdianValue);
            com.Parameters.AddWithValue("@LocalGurdianName", stdsch2.LocalGurdianName);
            com.Parameters.AddWithValue("@LocalGurdianEmail", stdsch2.LocalGurdianEmail);
            com.Parameters.AddWithValue("@LocalGurdianPhone", stdsch2.LocalGurdianPhone);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

            }
            catch (Exception ex)
            {
                // ViewBag.Error = ex.Message;

            }

        }


        public void Add_student_step3(StudentFormFillup stdsch3)
        {
            try { 
            String School_Code = HttpContext.Current.Session["School_Code"].ToString();
            int Parent_Id = Convert.ToInt32(HttpContext.Current.Session["ParentID"]);
            //SqlCommand com = new SqlCommand("std_School_Registration", con);
            SqlCommand com = new SqlCommand("StudentAdmission_Formfillup", con);
            com.CommandType = CommandType.StoredProcedure;
            //  com.Parameters.AddWithValue("@SchoolName", stdsch.SchoolName);
            com.Parameters.AddWithValue("@Query_step", stdsch3.Query_step);
            com.Parameters.AddWithValue("@Parent_Id", Parent_Id);
            com.Parameters.AddWithValue("@School_Code", School_Code);

            com.Parameters.AddWithValue("@AdmissionClass_Id", stdsch3.AdmissionClass_Id);
            com.Parameters.AddWithValue("@Last_School_Name", stdsch3.Last_School_Name);
            com.Parameters.AddWithValue("@SchoolBoard_Id", stdsch3.SchoolBoard_Id);
            com.Parameters.AddWithValue("@Last_School_Year", stdsch3.Last_School_Year);
            com.Parameters.AddWithValue("@Last_School_Class", stdsch3.Last_School_Class);
            com.Parameters.AddWithValue("@School_Transfer_Certifiate_Number", stdsch3.School_Transfer_Certifiate_Number);
            com.Parameters.AddWithValue("@SchoolTransferCertificate_Name", stdsch3.SchoolTransferCertificate_Name);
            com.Parameters.AddWithValue("@SchoolTransferCertificatePath", stdsch3.SchoolTransferCertificatePath); 
            com.Parameters.AddWithValue("@Last_School_Exam_Marks", stdsch3.Last_School_Exam_Marks);
            com.Parameters.AddWithValue("@Last_School_Total_Marks", stdsch3.Last_School_Total_Marks);
            com.Parameters.AddWithValue("@Last_School_Marks_Percentage", stdsch3.Last_School_Marks_Percentage);
            com.Parameters.AddWithValue("@FinalExamResult_Name", stdsch3.FinalExamResult_Name); 
            com.Parameters.AddWithValue("@FinalExamResultPath", stdsch3.FinalExamResultPath);
            com.Parameters.AddWithValue("@Board_Exam_Marks", stdsch3.Board_Exam_Marks);
            com.Parameters.AddWithValue("@Board_Total_Marks", stdsch3.Board_Total_Marks);
            com.Parameters.AddWithValue("@Marks_Percentage", stdsch3.Marks_Percentage);
            com.Parameters.AddWithValue("@Board_Certificate_Number", stdsch3.Board_Certificate_Number);
            com.Parameters.AddWithValue("@BoardExamResultName", stdsch3.BoardExamResultName);            
            com.Parameters.AddWithValue("@BoardExamResultPath", stdsch3.BoardExamResultPath);
            com.Parameters.AddWithValue("@BoardExamCertificate_Name", stdsch3.BoardExamCertificate_Name);
            com.Parameters.AddWithValue("@BoardExamCertificatePath", stdsch3.BoardExamCertificatePath);


            con.Open();
            com.ExecuteNonQuery();
            con.Close();

            }
            catch (Exception ex)
            {
                // ViewBag.Error = ex.Message;

            }

        }


        public void Add_student_step4(StudentFormFillup stdsch4)
        {
            try { 
            String School_Code = HttpContext.Current.Session["School_Code"].ToString();
            int Parent_Id = Convert.ToInt32(HttpContext.Current.Session["ParentID"]);
            //SqlCommand com = new SqlCommand("std_School_Registration", con);
            SqlCommand com = new SqlCommand("StudentAdmission_Formfillup", con);
            com.CommandType = CommandType.StoredProcedure;
            //  com.Parameters.AddWithValue("@SchoolName", stdsch.SchoolName);
            com.Parameters.AddWithValue("@Query_step", stdsch4.Query_step);
            com.Parameters.AddWithValue("@Parent_Id", Parent_Id);
            com.Parameters.AddWithValue("@School_Code", School_Code);
            com.Parameters.AddWithValue("@ImagePath", stdsch4.ImagePath);
            com.Parameters.AddWithValue("@SignaturePath", stdsch4.SignaturePath);
           
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            }
            catch (Exception ex)
            {
                // ViewBag.Error = ex.Message;

            }

        }

        public void Add_student_step5(StudentFormFillup stdsch5)
        {
            try { 
            String School_Code = HttpContext.Current.Session["School_Code"].ToString();
            int Parent_Id = Convert.ToInt32(HttpContext.Current.Session["ParentID"]);
            //SqlCommand com = new SqlCommand("std_School_Registration", con);
            SqlCommand com = new SqlCommand("StudentAdmission_Formfillup", con);
            com.CommandType = CommandType.StoredProcedure;
            //  com.Parameters.AddWithValue("@SchoolName", stdsch.SchoolName);
            com.Parameters.AddWithValue("@Query_step", stdsch5.Query_step);
            com.Parameters.AddWithValue("@Parent_Id", Parent_Id);
            com.Parameters.AddWithValue("@School_Code", School_Code);
            com.Parameters.AddWithValue("@TermsAndConditions", stdsch5.TermsAndConditions);
          

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
            }
            catch (Exception ex)
            {
                // ViewBag.Error = ex.Message;

            }
        }

        public bool StudentEligiblity(StudentAdmission smodel)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand com = new SqlCommand("[STUDENT_APLLICATION_STATUS]", con);
            com.CommandType = CommandType.StoredProcedure;

            String School_Code = HttpContext.Current.Session["School_Code"].ToString();
            int Parent_Id = Convert.ToInt32(HttpContext.Current.Session["ParentID"]);;
            com.Parameters.AddWithValue("@Parent_Id", Parent_Id);
            com.Parameters.AddWithValue("@School_Code", School_Code);
            com.Parameters.AddWithValue("@Student_Id", smodel.Student_Id);
            com.Parameters.AddWithValue("@Application_Status", smodel.Application_Status);
            if (smodel.interview_note != null) {
                com.Parameters.AddWithValue("@interview_note", smodel.interview_note);
                com.Parameters.AddWithValue("@StudentfilePath", smodel.StudentfilePath);
                /*  if (ImageUpload != null)
                  {
                      string fileName_bordexamres = Path.GetFileNameWithoutExtension(ImageUpload.FileName);
                      string extension = Path.GetExtension(ImageUpload.FileName);
                      fileName_bordexamres = fileName_bordexamres + DateTime.Now.ToString("yymmssff") + extension;
                      ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/Images/"), fileName_bordexamres));
                      smodel.ImagePath = "~/AppFiles/Images/" + fileName_bordexamres;
                      //stdsch4.ImagePath = fileName_bordexamres;
                  }*/


            }

            con.Open();
            int i = com.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }




    }
}