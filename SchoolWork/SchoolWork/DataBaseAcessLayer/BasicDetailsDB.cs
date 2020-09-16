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
    public class BasicDetailsDB
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);

        public List<ClassDetailsMaster> GetAllClass()
        {
            //String School_Code = HttpContext.Current.Session["School_Code"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            List<ClassDetailsMaster> Classlist = new List<ClassDetailsMaster>();

            SqlCommand cmd = new SqlCommand("Select_ALL_Class", con);
            cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@School_Code", School_Code);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Classlist.Add(
                    new ClassDetailsMaster
                    {
                        Class_Id = Convert.ToInt32(dr["Class_Id"]),
                        Class_Name = Convert.ToString(dr["Class_Name"])
                   
                    });
            }
            return Classlist;
        }

        public List<WorkRole> GetAdminWorkRole(int id)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            List<WorkRole> RoleList = new List<WorkRole>();
            SqlCommand cmd = new SqlCommand("WorkRole_Fetch", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Parent_Menu", id);
            cmd.Parameters.AddWithValue("@Query", 1);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                RoleList.Add(
                    new WorkRole
                    {
                        Role_Id = Convert.ToInt32(dr["id"]),
                        Parent_Menu_Order = Convert.ToString(dr["Parent_Menu_Order"]),
                        Parent_Menu = Convert.ToInt32(dr["Parent_Menu"]),
                        Sub_Menu = Convert.ToString(dr["Sub_Menu"]),
                        Sub_Menu_Cn = Convert.ToString(dr["Sub_Menu_Cn"]),
                        Sub_Menu_Fn = Convert.ToString(dr["Sub_Menu_Fn"]),
                        User_Type_Id = Convert.ToString(dr["User_Type_Id"]),


                    });
            }
            return RoleList;
        }




        public List<WorkRole_Header> GetAdminWorkRoleHeader()
        {
            //String School_Code = HttpContext.Current.Session["School_Code"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            List<WorkRole_Header> RoleList = new List<WorkRole_Header>();

            SqlCommand cmd = new SqlCommand("WorkRole_Fetch", con);
            cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@School_Code", School_Code);
            cmd.Parameters.AddWithValue("@Query", 2);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                RoleList.Add(
                    new WorkRole_Header
                    {
                        WorkGroup_Id = Convert.ToInt32(dr["WorkGroup_Id"]),
                        WorkGroup_Name = Convert.ToString(dr["WorkGroup_Name"]),
                        Parent_Menu_Cn = Convert.ToString(dr["Parent_Menu_Cn"]),
                        Parent_Menu_Fn = Convert.ToString(dr["Parent_Menu_Fn"]),
                        User_Type = Convert.ToString(dr["User_Type"]),


                    });
            }
            return RoleList;
        }


        public List<WorkRole_Header> GetEmployeeWorkRoleHeader()
        {
            //String School_Code = HttpContext.Current.Session["School_Code"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            List<WorkRole_Header> RoleList = new List<WorkRole_Header>();

            SqlCommand cmd = new SqlCommand("WorkRole_Fetch", con);
            cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@School_Code", School_Code);
            cmd.Parameters.AddWithValue("@Query", 8);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                RoleList.Add(
                    new WorkRole_Header
                    {
                        WorkGroup_Id = Convert.ToInt32(dr["WorkGroup_Id"]),
                        WorkGroup_Name = Convert.ToString(dr["WorkGroup_Name"]),
                        Parent_Menu_Cn = Convert.ToString(dr["Parent_Menu_Cn"]),
                        Parent_Menu_Fn = Convert.ToString(dr["Parent_Menu_Fn"]),
                        User_Type = Convert.ToString(dr["User_Type"]),


                    });
            }
            return RoleList;
        }


        public List<WorkRole> GetEmployeeWorkRole(int id)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            List<WorkRole> RoleList = new List<WorkRole>();
            SqlCommand cmd = new SqlCommand("WorkRole_Fetch", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Parent_Menu", id);
            cmd.Parameters.AddWithValue("@Query", 9);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                RoleList.Add(
                    new WorkRole
                    {
                        Role_Id = Convert.ToInt32(dr["id"]),
                        Parent_Menu_Order = Convert.ToString(dr["Parent_Menu_Order"]),
                        Parent_Menu = Convert.ToInt32(dr["Parent_Menu"]),
                        Sub_Menu = Convert.ToString(dr["Sub_Menu"]),
                        Sub_Menu_Cn = Convert.ToString(dr["Sub_Menu_Cn"]),
                        Sub_Menu_Fn = Convert.ToString(dr["Sub_Menu_Fn"]),
                        User_Type_Id = Convert.ToString(dr["User_Type_Id"]),


                    });
            }
            return RoleList;
        }


        public List<WorkRole_Header> GetParentWorkRoleHeader()
        {
            //String School_Code = HttpContext.Current.Session["School_Code"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            List<WorkRole_Header> RoleList = new List<WorkRole_Header>();

            SqlCommand cmd = new SqlCommand("WorkRole_Fetch", con);
            cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@School_Code", School_Code);
            cmd.Parameters.AddWithValue("@Query", 3);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                RoleList.Add(
                    new WorkRole_Header
                    {
                        WorkGroup_Id = Convert.ToInt32(dr["WorkGroup_Id"]),
                        WorkGroup_Name = Convert.ToString(dr["WorkGroup_Name"]),
                        Parent_Menu_Cn = Convert.ToString(dr["Parent_Menu_Cn"]),
                        Parent_Menu_Fn = Convert.ToString(dr["Parent_Menu_Fn"]),
                        User_Type = Convert.ToString(dr["User_Type"]),


                    });
            }
            return RoleList;
        }



        public List<WorkRole> GetParentWorkRole(int id)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            List<WorkRole> RoleList = new List<WorkRole>();
            SqlCommand cmd = new SqlCommand("WorkRole_Fetch", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Parent_Menu", id);
            cmd.Parameters.AddWithValue("@Query", 4);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                RoleList.Add(
                    new WorkRole
                    {
                        Role_Id = Convert.ToInt32(dr["id"]),
                        Parent_Menu_Order = Convert.ToString(dr["Parent_Menu_Order"]),
                        Parent_Menu = Convert.ToInt32(dr["Parent_Menu"]),
                        Sub_Menu = Convert.ToString(dr["Sub_Menu"]),
                        Sub_Menu_Cn = Convert.ToString(dr["Sub_Menu_Cn"]),
                        Sub_Menu_Fn = Convert.ToString(dr["Sub_Menu_Fn"]),
                        User_Type_Id = Convert.ToString(dr["User_Type_Id"]),


                    });
            }
            return RoleList;
        }



        public List<WorkRole_Header> GetStudentWorkRoleHeader()
        {
            //String School_Code = HttpContext.Current.Session["School_Code"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            List<WorkRole_Header> RoleList = new List<WorkRole_Header>();

            SqlCommand cmd = new SqlCommand("WorkRole_Fetch", con);
            cmd.CommandType = CommandType.StoredProcedure;

            //cmd.Parameters.AddWithValue("@School_Code", School_Code);
            cmd.Parameters.AddWithValue("@Query", 6);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                RoleList.Add(
                    new WorkRole_Header
                    {
                        WorkGroup_Id = Convert.ToInt32(dr["WorkGroup_Id"]),
                        WorkGroup_Name = Convert.ToString(dr["WorkGroup_Name"]),
                        Parent_Menu_Cn = Convert.ToString(dr["Parent_Menu_Cn"]),
                        Parent_Menu_Fn = Convert.ToString(dr["Parent_Menu_Fn"]),
                        User_Type = Convert.ToString(dr["User_Type"]),


                    });
            }
            return RoleList;
        }



        public List<WorkRole> GetStudentWorkRole(int id)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            List<WorkRole> RoleList = new List<WorkRole>();
            SqlCommand cmd = new SqlCommand("WorkRole_Fetch", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Parent_Menu", id);
            cmd.Parameters.AddWithValue("@Query", 7);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                RoleList.Add(
                    new WorkRole
                    {
                        Role_Id = Convert.ToInt32(dr["id"]),
                        Parent_Menu_Order = Convert.ToString(dr["Parent_Menu_Order"]),
                        Parent_Menu = Convert.ToInt32(dr["Parent_Menu"]),
                        Sub_Menu = Convert.ToString(dr["Sub_Menu"]),
                        Sub_Menu_Cn = Convert.ToString(dr["Sub_Menu_Cn"]),
                        Sub_Menu_Fn = Convert.ToString(dr["Sub_Menu_Fn"]),
                        User_Type_Id = Convert.ToString(dr["User_Type_Id"]),


                    });
            }
            return RoleList;
        }



    }
}