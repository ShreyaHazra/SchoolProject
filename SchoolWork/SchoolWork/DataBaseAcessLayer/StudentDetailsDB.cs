using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using SchoolWork.Models;


namespace SchoolWork.DataBaseAcessLayer
{
    public class StudentDetailsDB
    {


        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);

        public List<NoticeDetails> GetStudentNotice()
        {
            String School_Code = HttpContext.Current.Session["School_Code"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            List<NoticeDetails> Noticelist = new List<NoticeDetails>();
            try { 
            SqlCommand cmd = new SqlCommand("School_Notice_Fetch", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@School_Code", School_Code);
            cmd.Parameters.AddWithValue("@Query", 4);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Noticelist.Add(
                    new NoticeDetails
                    {
                        Notice_Id = Convert.ToInt32(dr["Notice_Id"]),
                        School_Code = Convert.ToString(dr["School_Code"]),
                        Notice_Title = Convert.ToString(dr["Notice_Title"]),
                        Notice_Description = Convert.ToString(dr["Notice_Description"]),
                        Notice_Published_On = Convert.ToString(dr["Notice_Published_On"])


                    });
            }

            }
            catch (Exception ex)
            {
                // ViewBag.Error = ex.Message;

            }
            return Noticelist;
        }


        public bool StudentRegister(StudentRegistration smodel)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Student_InsertUpdateDelete", con);

            try
            { 
            String School_Code = HttpContext.Current.Session["School_Code"].ToString();
            String Application_Id = HttpContext.Current.Session["Application_Id"].ToString();
             cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Student_Id", smodel.Student_Id);
            cmd.Parameters.AddWithValue("@Student_Email", smodel.Student_Email);
            cmd.Parameters.AddWithValue("@Password", smodel.Password);
            cmd.Parameters.AddWithValue("@School_Code", smodel.School_Code);
            cmd.Parameters.AddWithValue("@Application_Id", smodel.Application_Id);
            cmd.Parameters.AddWithValue("@Query", 1);
            con.Open();

            }
            catch (Exception ex)
            {
                // ViewBag.Error = ex.Message;

            }
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }



    }
}
