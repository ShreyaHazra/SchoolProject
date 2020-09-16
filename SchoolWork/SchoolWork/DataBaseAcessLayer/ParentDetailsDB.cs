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
    public class ParentDetailsDB
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);

        public void Add_record(ParentRegistration parreg)
        {
           // SqlCommand com = new SqlCommand("Parent_Registration", con);
            SqlCommand com = new SqlCommand("Parent_InsertUpdateDelete", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@School_Code", parreg.School_Code);
            com.Parameters.AddWithValue("@ParentName", parreg.ParentName);
            com.Parameters.AddWithValue("@ParentContact", parreg.ParentContact);
            com.Parameters.AddWithValue("@ParentEmail", parreg.ParentEmail);
            com.Parameters.AddWithValue("@ParentPassword", parreg.ParentPassword);
            com.Parameters.AddWithValue("@New_Id", parreg.New_Id);
            com.Parameters.AddWithValue("@Query", 1);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }




        // ***************** UPDATE PARENTS DETAILS *********************
        public bool UpdateDetails(ParentDetails smodel)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Parent_InsertUpdateDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ParentID", smodel.ParentID);
            cmd.Parameters.AddWithValue("@ParentName", smodel.ParentName);
            cmd.Parameters.AddWithValue("@ParentContact", smodel.ParentContact);
            cmd.Parameters.AddWithValue("@ParentEmail", smodel.ParentEmail);
            cmd.Parameters.AddWithValue("@ParentPassword", smodel.ParentPassword);
            cmd.Parameters.AddWithValue("@Query",2 );
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }


        public List<ParentDetails> GetParent()
        {
            List<ParentDetails> Parentlist = new List<ParentDetails>();
            try
            {
                String School_Code = HttpContext.Current.Session["School_Code"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            
            SqlCommand cmd = new SqlCommand("Select_ALL_Parent", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@SchoolCode", School_Code);
            // cmd.Parameters.AddWithValue("@Query", 4);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            // sd.SelectCommand.Parameters.AddWithValue("@School_Code", School_Code);
            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Parentlist.Add(
                    new ParentDetails
                    {
                        //Parent_Id = Convert.ToInt32(dr["ParentID"]),
                        ParentName = Convert.ToString(dr["ParentName"]),
                        ParentContact = Convert.ToString(dr["ParentContact"]),
                        ParentEmail = Convert.ToString(dr["ParentEmail"]),
                        ParentPassword = Convert.ToString(dr["ParentPassword"])


                    });
            }
            }
            catch (Exception ex)
            {
                // ViewBag.Error = ex.Message;

            }

            return Parentlist;
        }




        public List<NoticeDetails> GetNotice()
        {
            List<NoticeDetails> Noticelist = new List<NoticeDetails>();
            try
            {
                String School_Code = HttpContext.Current.Session["School_Code"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            
            SqlCommand cmd = new SqlCommand("School_Notice_Fetch", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@School_Code", School_Code);
            cmd.Parameters.AddWithValue("@Query", 3);

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


        public List<StudentAdmission> GetAllApplication()
        {
            List<StudentAdmission> ApplicantList = new List<StudentAdmission>();
            try
            {
                String School_Code = HttpContext.Current.Session["School_Code"].ToString();
            String ParentID = HttpContext.Current.Session["ParentID"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            
            SqlCommand cmd = new SqlCommand("FETCH_STUDENT_APPLICATION_DETAILS", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@School_Code", School_Code);
            cmd.Parameters.AddWithValue("@ParentID", ParentID);
            //cmd.Parameters.AddWithValue("@Query", 3);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow sdr in dt.Rows)
            {
                ApplicantList.Add(
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
                        BirthCertificate_Name = String.IsNullOrEmpty(sdr["BirthCertificate_Name"].ToString()) ? null : sdr["BirthCertificatePath"].ToString(),
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
                        CountryName = String.IsNullOrEmpty(sdr["CountryName"].ToString()) ? null : sdr["CountryName"].ToString(),
                        StateName = String.IsNullOrEmpty(sdr["StateName"].ToString()) ? null : sdr["StateName"].ToString(),
                        CityName = String.IsNullOrEmpty(sdr["CityName"].ToString()) ? null : sdr["CityName"].ToString(),
                        IdProof_Name = String.IsNullOrEmpty(sdr["IdProof_Name"].ToString()) ? null : sdr["IdProof_Name"].ToString(),
                        Board_Name = String.IsNullOrEmpty(sdr["Board_Name"].ToString()) ? null : sdr["Board_Name"].ToString(),
                        Class_Name = String.IsNullOrEmpty(sdr["Class_Name"].ToString()) ? null : sdr["Class_Name"].ToString()


                    });
            }

            }
            catch (Exception ex)
            {
                // ViewBag.Error = ex.Message;

            }
            return ApplicantList;
        }







    }


}