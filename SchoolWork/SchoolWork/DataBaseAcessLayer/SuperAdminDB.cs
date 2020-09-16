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
    public class SuperAdminDB
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);

        public void Add_School(SchoolRegistration stdsch)
        {
            //SqlCommand com = new SqlCommand("std_School_Registration", con);
            SqlCommand com = new SqlCommand("School_InsertUpdateDelete", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@SchoolName", stdsch.SchoolName);
            com.Parameters.AddWithValue("@SchoolCode", stdsch.SchoolCode);
            com.Parameters.AddWithValue("@SchoolEmail", stdsch.SchoolEmail);
            com.Parameters.AddWithValue("@SchoolPassword", stdsch.SchoolPassword);
            com.Parameters.AddWithValue("@SchoolPhone", stdsch.SchoolPhone);
            com.Parameters.AddWithValue("@SchoolContactPerson", stdsch.SchoolContactPerson);
            com.Parameters.AddWithValue("@SchoolContactPersonEmail", stdsch.SchoolContactPersonEmail);
            com.Parameters.AddWithValue("@SchoolContactPersonPhone", stdsch.SchoolContactPersonPhone);
            com.Parameters.AddWithValue("@SchoolAddress1", stdsch.SchoolAddress1);
            com.Parameters.AddWithValue("@SchoolAddress2", stdsch.SchoolAddress2);
            com.Parameters.AddWithValue("@CountryId", stdsch.CountryId);
            com.Parameters.AddWithValue("@StateId", stdsch.StateId);
            com.Parameters.AddWithValue("@CityId", stdsch.CityId);
            com.Parameters.AddWithValue("@Board_Id", stdsch.Board_Id);
            com.Parameters.AddWithValue("@Query", 1);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }





    }
}