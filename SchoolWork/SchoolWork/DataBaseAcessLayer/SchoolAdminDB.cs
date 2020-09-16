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
    public class SchoolAdminDB
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);

        public void Add_Student_Group(StudentGroupMaster stdgrp)
        {
            SqlCommand com = new SqlCommand("Student_Group", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@School_Id", stdgrp.School_Id);
            com.Parameters.AddWithValue("@School_Code", stdgrp.School_Code);
            com.Parameters.AddWithValue("@School_Name", stdgrp.School_Name);
            com.Parameters.AddWithValue("@Group_Name", stdgrp.Group_Name);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        public void Add_School_Section(SchoolSectionMaster schsec)
        {
            SqlCommand com = new SqlCommand("School_Section", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@School_Id", schsec.School_Id);
            com.Parameters.AddWithValue("@School_Code", schsec.School_Code);
            com.Parameters.AddWithValue("@School_Name", schsec.School_Name);
            com.Parameters.AddWithValue("@Class_Id", schsec.Class_Id);
               com.Parameters.AddWithValue("@Section_Name", schsec.Section_Name);
            com.Parameters.AddWithValue("@Section_Room_Number", schsec.Section_Room_Number);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        public void Add_School_Subject(SchoolSubjectMaster schsub)
        {
            SqlCommand com = new SqlCommand("School_Subject", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@School_Id", schsub.School_Id);
            com.Parameters.AddWithValue("@School_Code", schsub.School_Code);
            com.Parameters.AddWithValue("@School_Name", schsub.School_Name);
            com.Parameters.AddWithValue("@Class_Id", schsub.Class_Id);
            com.Parameters.AddWithValue("@subject_type", schsub.subject_type);
            if (schsub.subject_type == "A")
            {
                com.Parameters.AddWithValue("@Additional_Subject", schsub.Additional_Subject);
            }
            com.Parameters.AddWithValue("@Subject_Name", schsub.Subject_Name);
            if (schsub.priority_val!=0) {
                com.Parameters.AddWithValue("@priority_val", schsub.priority_val);
            }
            com.Parameters.AddWithValue("@exam_sub_type", schsub.exam_sub_type);
            com.Parameters.AddWithValue("@Subject_Code", schsub.Subject_Code);
            com.Parameters.AddWithValue("@FullMarks", schsub.FullMarks);
            if (schsub.PracticalMarks!=0) {
                com.Parameters.AddWithValue("@PracticalMarks", schsub.PracticalMarks);

            }
            com.Parameters.AddWithValue("@PassMarks", schsub.PassMarks);

            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        public void Add_School_EmpType(SchoolEmpTypeMaster schemptype)
        {
            SqlCommand com = new SqlCommand("School_EmpType", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@School_Id", schemptype.School_Id);
            com.Parameters.AddWithValue("@School_Code", schemptype.School_Code);
            com.Parameters.AddWithValue("@School_Name", schemptype.School_Name);
            com.Parameters.AddWithValue("@EmpType_Name", schemptype.EmpType_Name);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }


        public void Add_School_Employee(SchoolEmployeeMaster schemp)
        {
            //SqlCommand com = new SqlCommand("School_Employee", con);
            SqlCommand com = new SqlCommand("Employee_InsertUpdateDelete", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@School_Id", schemp.School_Id);
            com.Parameters.AddWithValue("@School_Code", schemp.School_Code);
            com.Parameters.AddWithValue("@School_Name", schemp.School_Name);
            com.Parameters.AddWithValue("@EmpType_Id", schemp.EmpType_Id);
            com.Parameters.AddWithValue("@Employee_Name", schemp.Employee_Name);
            com.Parameters.AddWithValue("@Employee_Code", schemp.Employee_Code);
            com.Parameters.AddWithValue("@Employee_Email", schemp.Employee_Email);
            com.Parameters.AddWithValue("@Employee_Password", schemp.Employee_Password);
            com.Parameters.AddWithValue("@Employee_Mobile_Number", schemp.Employee_Mobile_Number);
            com.Parameters.AddWithValue("@Employee_Alt_Number", schemp.Employee_Alt_Number);
            com.Parameters.AddWithValue("@Employee_DOB", schemp.Employee_DOB);
            //com.Parameters.AddWithValue("@Employee_DOB", schemp.Employee_DOB);
            com.Parameters.AddWithValue("@New_Id", schemp.New_Id);
            com.Parameters.AddWithValue("@Query", 1);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        public void Add_School_Notice(SchoolNoticeAdd schnot)
        {
            //SqlCommand com = new SqlCommand("School_Notice", con);
            SqlCommand com = new SqlCommand("Notice_InsertUpdateDelete", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@School_Id", schnot.School_Id);
            com.Parameters.AddWithValue("@School_Code", schnot.School_Code);
            com.Parameters.AddWithValue("@School_Name", schnot.School_Name);
            com.Parameters.AddWithValue("@Notice_Title", schnot.Notice_Title);
            com.Parameters.AddWithValue("@Notice_Description", schnot.Notice_Description);
            com.Parameters.AddWithValue("@User_Type_Id", schnot.User_Type_Id);
            com.Parameters.AddWithValue("@Notice_Published_On", schnot.Notice_Published_On);
            com.Parameters.AddWithValue("@Query",1);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        public List<AdminNoticeDetails> GetAdminNotice()
        {
            List<AdminNoticeDetails> Noticelist = new List<AdminNoticeDetails>();
            try
            {
            String School_Code = HttpContext.Current.Session["School_Code"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
           
            //SqlCommand cmd = new SqlCommand("Select_ALL_ADMIN_Notice", con);
            SqlCommand cmd = new SqlCommand("School_Notice_Fetch", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@School_Code", School_Code);
            cmd.Parameters.AddWithValue("@Query", 1);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Noticelist.Add(
                    new AdminNoticeDetails
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

        public List<EmployeeDetails> GetEmpDetails()
        {
            List<EmployeeDetails> EmpDetailslist = new List<EmployeeDetails>();
            try
            {
                String School_Code = HttpContext.Current.Session["School_Code"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            
            SqlCommand cmd = new SqlCommand("Select_ALL_Employee2", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@School_Code", School_Code);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                EmpDetailslist.Add(
                    new EmployeeDetails
                    {
                        Employee_Id = Convert.ToInt32(dr["Employee_Id"]),
                        School_Code = Convert.ToString(dr["School_Code"]),
                        School_Name = Convert.ToString(dr["School_Name"]),
                        EmpType_Id = Convert.ToInt32(dr["EmpType_Id"]),
                        EmpType_Name = Convert.ToString(dr["EmpType_Name"]),
                        Employee_Name = Convert.ToString(dr["Employee_Name"]),
                        Employee_Code = Convert.ToString(dr["Employee_Code"]),
                        Employee_Email = Convert.ToString(dr["Employee_Email"]),
                        Employee_Password = Convert.ToString(dr["Employee_Password"]),
                        Employee_Mobile_Number = Convert.ToString(dr["Employee_Mobile_Number"]),
                        Employee_Alt_Number = Convert.ToString(dr["Employee_Alt_Number"]),
                        Employee_DOB = Convert.ToString(dr["Employee_DOB"])
                    });
            }

        }
            catch (Exception ex)
            {
                // ViewBag.Error = ex.Message;

            }
            return EmpDetailslist;
        }

        public List<StudentAdmission> GetAppliedStuentDetails()
        {
            List<StudentAdmission> StuDetailslist = new List<StudentAdmission>();
            try
            {
                String School_Code = HttpContext.Current.Session["School_Code"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            
            SqlCommand cmd = new SqlCommand("[Select_ALL_AppliedStudent]", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@School_Code", School_Code);

           
            SqlDataAdapter sd = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow sdr in dt.Rows)
            {
                StuDetailslist.Add(
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

                        CountryName = String.IsNullOrEmpty(sdr["CountryName"].ToString()) ? null : sdr["CountryName"].ToString(),
                        StateName = String.IsNullOrEmpty(sdr["StateName"].ToString()) ? null : sdr["StateName"].ToString(),
                        CityName = String.IsNullOrEmpty(sdr["CityName"].ToString()) ? null : sdr["CityName"].ToString(),
                        IdProof_Name = String.IsNullOrEmpty(sdr["IdProof_Name"].ToString()) ? null : sdr["IdProof_Name"].ToString(),
                        Board_Name = String.IsNullOrEmpty(sdr["Board_Name"].ToString()) ? null : sdr["Board_Name"].ToString(),
                        Class_Name = String.IsNullOrEmpty(sdr["Class_Name"].ToString()) ? null : sdr["Class_Name"].ToString(),
                        Application_Status = String.IsNullOrEmpty(sdr["Application_Status"].ToString()) ? null : sdr["Application_Status"].ToString()


                    });
            }
        }
            catch (Exception ex)
            {
                // ViewBag.Error = ex.Message;

            }

            return StuDetailslist;
        }



        public List<StudentAdmission> GetStuentDetails(int id, String School_Codee)
        {
            List<StudentAdmission> StuDetailslist = new List<StudentAdmission>();

            try { 
            String School_Code = HttpContext.Current.Session["School_Code"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
           
            SqlCommand cmd = new SqlCommand("[Student_InsertUpdateDelete]", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@School_Code", School_Code);

            cmd.Parameters.AddWithValue("@Query", 3);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow sdr in dt.Rows)
            {
                StuDetailslist.Add(
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

                        CountryName = String.IsNullOrEmpty(sdr["CountryName"].ToString()) ? null : sdr["CountryName"].ToString(),
                        StateName = String.IsNullOrEmpty(sdr["StateName"].ToString()) ? null : sdr["StateName"].ToString(),
                        CityName = String.IsNullOrEmpty(sdr["CityName"].ToString()) ? null : sdr["CityName"].ToString(),
                        IdProof_Name = String.IsNullOrEmpty(sdr["IdProof_Name"].ToString()) ? null : sdr["IdProof_Name"].ToString(),
                        Board_Name = String.IsNullOrEmpty(sdr["Board_Name"].ToString()) ? null : sdr["Board_Name"].ToString(),
                        Class_Name = String.IsNullOrEmpty(sdr["Class_Name"].ToString()) ? null : sdr["Class_Name"].ToString(),
                        Application_Status = String.IsNullOrEmpty(sdr["Application_Status"].ToString()) ? null : sdr["Application_Status"].ToString()


                    });
            }

            }
            catch (Exception ex)
            {
                // ViewBag.Error = ex.Message;

            }
           
            return StuDetailslist;
        }





        public bool UpdateNoticeDetails(AdminNoticeDetails smodel)
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

        public List<ParentDetails> GetParentDetails()
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
                            ParentID = Convert.ToInt32(dr["ParentID"]),
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


        public void Add_School_Fees(SchoolFeesAdd schfees)
        {
            SqlCommand com = new SqlCommand("Fees_InsertUpdateDelete", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@School_Id", schfees.School_Id);
            com.Parameters.AddWithValue("@School_Code", schfees.School_Code);
            com.Parameters.AddWithValue("@Class_Id", schfees.Class_Id);
            com.Parameters.AddWithValue("@Fees_Name", schfees.Fees_Name);
            com.Parameters.AddWithValue("@Fees_Desc", schfees.Fees_Desc);
            com.Parameters.AddWithValue("@Amount", schfees.Amount);
            com.Parameters.AddWithValue("@Year", schfees.Year);
            com.Parameters.AddWithValue("@Query", 1);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }


        public List<SchoolFeesAdd> GetAllFees()
        {
            List<SchoolFeesAdd> FeeList = new List<SchoolFeesAdd>();
            try
            {
            String School_Code = HttpContext.Current.Session["School_Code"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            
            //SqlCommand cmd = new SqlCommand("Select_ALL_ADMIN_Notice", con);
            SqlCommand cmd = new SqlCommand("Fees_InsertUpdateDelete", con);
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
                FeeList.Add(
                    new SchoolFeesAdd
                    {
                        Fees_Id = Convert.ToInt32(dr["id"]),
                        School_Code = Convert.ToString(dr["School_Code"]),
                        Fees_Name = Convert.ToString(dr["Fees_Name"]),
                        Fees_Desc = Convert.ToString(dr["Fees_Desc"]),
                        Amount = Convert.ToString(dr["Amount"]),
                        Year = Convert.ToInt32(dr["Fees_Year"]),
                        Class = Convert.ToString(dr["Class_Name"]),

                    });
            }

            }
            catch (Exception ex)
            {
                // ViewBag.Error = ex.Message;

            }

            return FeeList;
        }


        public bool UpdateFeesDetails(SchoolFeesAdd smodel)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Fees_InsertUpdateDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Fees_Id", smodel.Fees_Id);
            cmd.Parameters.AddWithValue("@Year", smodel.Year);
            cmd.Parameters.AddWithValue("@Class", smodel.Class);
            cmd.Parameters.AddWithValue("@Fees_Name", smodel.Fees_Name);
            cmd.Parameters.AddWithValue("@Fees_Desc", smodel.Fees_Desc);
            cmd.Parameters.AddWithValue("@Amount", smodel.Amount);
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



        public bool UpdateRollSection(StudentAdmission schemp)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Student_InsertUpdateDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;

           
           // cmd.Parameters.AddWithValue("@Fees_Name", smodel.Fees_Name);
          //  cmd.Parameters.AddWithValue("@Fees_Desc", smodel.Fees_Desc);
            cmd.Parameters.AddWithValue("@Student_Id", schemp.Student_Id); 
            cmd.Parameters.AddWithValue("@Assign_Roll_Number", schemp.Assign_Roll_Number); 
            cmd.Parameters.AddWithValue("@Section_Id", schemp.Section_Id); 
            //cmd.Parameters.AddWithValue("@School_Code", smodel.School_Code);
            cmd.Parameters.AddWithValue("@Query", 4);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }


        public List<SchoolEmpTypeMaster> GetEmpDesignationDetails()
        {
            List<SchoolEmpTypeMaster> DesignationList = new List<SchoolEmpTypeMaster>();
            try
            {
                String School_Code = HttpContext.Current.Session["School_Code"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            
            //SqlCommand cmd = new SqlCommand("Select_ALL_ADMIN_Notice", con);
            SqlCommand cmd = new SqlCommand("Designation_Fetch", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@School_Code", School_Code);
            cmd.Parameters.AddWithValue("@Query", 1);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                DesignationList.Add(
                    new SchoolEmpTypeMaster
                    {
                        Type_Id = Convert.ToInt32(dr["Type_Id"]),
                        School_Code = Convert.ToString(dr["School_Code"]),
                        School_Name = Convert.ToString(dr["School_Name"]),
                        EmpType_Name = Convert.ToString(dr["EmpType_Name"]),
                        Type_Name = Convert.ToString(dr["User_Type_Name"]),
                        // Year = Convert.ToInt32(dr["Fees_Year"]),
                        // Class = Convert.ToString(dr["Class_Name"]),

                    });
            }
            }
            catch (Exception ex)
            {
                // ViewBag.Error = ex.Message;

            }

            return DesignationList;
        }

        public List<SchoolEmpTypeMaster> GetEmpAllDesignation()
        {
            List<SchoolEmpTypeMaster> DesignationList = new List<SchoolEmpTypeMaster>();
            try
            {
                String School_Code = HttpContext.Current.Session["School_Code"].ToString();
                SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);

                //SqlCommand cmd = new SqlCommand("Select_ALL_ADMIN_Notice", con);
                SqlCommand cmd = new SqlCommand("Designation_Fetch", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@School_Code", School_Code);
                cmd.Parameters.AddWithValue("@Query", 2);
                SqlDataAdapter sd = new SqlDataAdapter(cmd);

                DataTable dt = new DataTable();

                con.Open();
                sd.Fill(dt);
                con.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    DesignationList.Add(
                        new SchoolEmpTypeMaster
                        {
                            Type_Id = Convert.ToInt32(dr["Type_Id"]),
                            School_Code = Convert.ToString(dr["School_Code"]),
                            School_Name = Convert.ToString(dr["School_Name"]),
                            EmpType_Name = Convert.ToString(dr["EmpType_Name"]),
                            Type_Name = Convert.ToString(dr["User_Type_Name"]),
                        // Year = Convert.ToInt32(dr["Fees_Year"]),
                        // Class = Convert.ToString(dr["Class_Name"]),

                    });
                }
            }
            catch (Exception ex)
            {
                // ViewBag.Error = ex.Message;

            }

            return DesignationList;
        }


        public List<WorkRole> GetEmpWorkRole()
        {

            List<WorkRole> EmpWorkRoleList = new List<WorkRole>();
            try
            {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
             
            SqlCommand cmd = new SqlCommand("WorkRole_Fetch", con);
            cmd.CommandType = CommandType.StoredProcedure;

            // cmd.Parameters.AddWithValue("@School_Code", School_Code);
            cmd.Parameters.AddWithValue("@Query", 1);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                EmpWorkRoleList.Add(
                    new WorkRole
                    {
                        Role_Id = Convert.ToInt32(dr["id"]),
                        Parent_Menu_Order = Convert.ToString(dr["Parent_Menu_Order"]),
                        Parent_Menu = Convert.ToInt32(dr["Parent_Menu"]),
                        Sub_Menu = Convert.ToString(dr["Sub_Menu"]),
                        Sub_Menu_Cn = Convert.ToString(dr["Sub_Menu_Cn"]),
                        Sub_Menu_Fn = Convert.ToString(dr["Sub_Menu_Fn"]),
                        User_Type_Id = Convert.ToString(dr["User_Type_Id"]),
                       // Year = Convert.ToInt32(dr["Fees_Year"]),
                       // Class = Convert.ToString(dr["Class_Name"]),

                   });
            }

            }
            catch (Exception ex)
            {
                // ViewBag.Error = ex.Message;

            }

            return EmpWorkRoleList;
        }



        public void Add_Exam_Schedule(CreateExamSchedule examschd)
        {
            SqlCommand com = new SqlCommand("Exam_Schedule_Insert_Update", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@School_Id", examschd.School_Id);
            com.Parameters.AddWithValue("@School_Code", examschd.School_Code);
            com.Parameters.AddWithValue("@Exam_Term_id", examschd.Exam_Term_id);
            com.Parameters.AddWithValue("@Year", examschd.Year);
            com.Parameters.AddWithValue("@Class_Id", examschd.Class_Id); 
            com.Parameters.AddWithValue("@Section_Id", examschd.Section_Id);
            com.Parameters.AddWithValue("@Exam_Subject_Type", examschd.Exam_Subject_Type);
            com.Parameters.AddWithValue("@Subject_id", examschd.Subject_id);
            com.Parameters.AddWithValue("@Day_Id", examschd.Day_Id);
            com.Parameters.AddWithValue("@Exam_Date", examschd.Exam_Date);
            com.Parameters.AddWithValue("@Start_Time", examschd.Start_Time);
            com.Parameters.AddWithValue("@End_Time", examschd.End_Time);
            com.Parameters.AddWithValue("@Query", 1);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        
            }

        public void Update_ExamSchedule(CreateExamSchedule examschd)
        {
            SqlCommand com = new SqlCommand("Exam_Schedule_Insert_Update", con);
            com.CommandType = CommandType.StoredProcedure;
            //com.Parameters.AddWithValue("@School_Id", examschd.School_Id);
            //com.Parameters.AddWithValue("@School_Code", examschd.School_Code);
            //com.Parameters.AddWithValue("@Exam_Term_id", examschd.Exam_Term_id);
            //com.Parameters.AddWithValue("@Year", examschd.Year);
            //com.Parameters.AddWithValue("@Class_Id", examschd.Class_Id);
            //com.Parameters.AddWithValue("@Section_Id", examschd.Section_Id);
            //com.Parameters.AddWithValue("@Subject_id", examschd.Subject_id);
            com.Parameters.AddWithValue("@ExamSchedule_Idd", examschd.ExamSchedule_Id);
            com.Parameters.AddWithValue("@Exam_Date", examschd.Exam_Date);
            com.Parameters.AddWithValue("@Start_Time", examschd.Start_Time);
            com.Parameters.AddWithValue("@End_Time", examschd.End_Time);
            com.Parameters.AddWithValue("@Query", 5);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

        }

        public List<CreateExamSchedule> GetAllExamRoutine()
        {
            List<CreateExamSchedule> FeeList = new List<CreateExamSchedule>();
            try
            {
                String School_Code = HttpContext.Current.Session["School_Code"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            
            SqlCommand cmd = new SqlCommand("Exam_Schedule_Insert_Update", con);
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
                FeeList.Add(
                    new CreateExamSchedule
                    {

                        ExamTerm_Id = Convert.ToInt32(dr["ExamTerm_Id"]),
                        School_Code = Convert.ToString(dr["School_Code"]),
                        Exm_Term_Name = Convert.ToString(dr["Exam_Term_Name"]),
                        Year = Convert.ToString(dr["Year"]),
                        Class = Convert.ToString(dr["Class_Name"]),



                        Subject_Namee = Convert.ToString(dr["Subject_Name"]),         
                        Day_Namee = Convert.ToString(dr["Day_Name"]),
                        Exam_Date = Convert.ToString(dr["Exam_Date"]),


                        Start_Time = Convert.ToString(dr["Start_Time"]),
                        End_Time = Convert.ToString(dr["End_Time"])                      
                      




            });
            }

            }
            catch (Exception ex)
            {
                // ViewBag.Error = ex.Message;

            }
            return FeeList;
        }


        public bool DeleteFees(int id)
        {
            // connection();
          
             SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Fees_InsertUpdateDelete", con);

            try {
                String School_Code = HttpContext.Current.Session["School_Code"].ToString();

                cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Fees_Id", id);
            cmd.Parameters.AddWithValue("@School_Code", School_Code);
            cmd.Parameters.AddWithValue("@Query", 4);

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


        public void Add_School_Exam_Term(SyllabusModule schsyl)
        {
            //SqlCommand com = new SqlCommand("School_Notice", con);
         
            SqlCommand com = new SqlCommand("ExamTerm_InsertUpdateDelete", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@School_Id", schsyl.School_Id);
            com.Parameters.AddWithValue("@School_Code", schsyl.School_Code);
            com.Parameters.AddWithValue("@School_Name", schsyl.School_Name);
            com.Parameters.AddWithValue("@Exam_Term_Name", schsyl.Exam_Term_Name);
            com.Parameters.AddWithValue("@Class_Id", schsyl.Class_Id);


            com.Parameters.AddWithValue("@Query", 1);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }



        public List<SyllabusModule> GetAllExmTerm()
        {
            List<SyllabusModule> SyllabusList = new List<SyllabusModule>();
            try
            {
                String School_Code = HttpContext.Current.Session["School_Code"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            
            //SqlCommand cmd = new SqlCommand("Select_ALL_ADMIN_Notice", con);
            SqlCommand cmd = new SqlCommand("ExamTerm_InsertUpdateDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@School_Code", School_Code);
            cmd.Parameters.AddWithValue("@Query", 2);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                SyllabusList.Add(
                    new SyllabusModule
                    {
                        Exam_Term_id = Convert.ToInt32(dr["Exam_Term_id"]),
                        School_Code = Convert.ToString(dr["School_Code"]),
                        Exam_Term_Name = Convert.ToString(dr["Exam_Term_Name"]),
                        Class = Convert.ToString(dr["Class_Name"]),
                       // Amount = Convert.ToString(dr["Amount"]),
                       // Year = Convert.ToInt32(dr["Fees_Year"]),
                       // Class = Convert.ToString(dr["Class_Name"]),

                   });
            }
            }
            catch (Exception ex)
            {
                // ViewBag.Error = ex.Message;

            }

            return SyllabusList;
        }

       

        public void Add_Class_Routine(SchoolRoutine schrout)
        {
            //SqlCommand com = new SqlCommand("School_Notice", con);
            SqlCommand com = new SqlCommand("ClassRoutine_InsertUpdateDelete", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@School_Id", schrout.School_Id);
            com.Parameters.AddWithValue("@School_Code", schrout.School_Code);
            com.Parameters.AddWithValue("@School_Name", schrout.School_Name);
            com.Parameters.AddWithValue("@Start_Time", schrout.Start_Time);
            com.Parameters.AddWithValue("@End_Time", schrout.End_Time);
            com.Parameters.AddWithValue("@Class_Id", schrout.Class_Id);
            com.Parameters.AddWithValue("@Section_Id", schrout.Section_Id);
            com.Parameters.AddWithValue("@Employee_Id", schrout.Employee_Id);
            com.Parameters.AddWithValue("@Subject_Id", schrout.Subject_Id);
            com.Parameters.AddWithValue("@Room_Id", schrout.Room_Id);
            com.Parameters.AddWithValue("@Year_Name", schrout.Year);
            com.Parameters.AddWithValue("@Day_Id", schrout.Day_Id);
            com.Parameters.AddWithValue("@Period_Id", schrout.Period_Id);
            com.Parameters.AddWithValue("@Query", 1);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }






        public List<SchoolRoutine> GetAllRoutineData()
        {
            List<SchoolRoutine> RoutineList = new List<SchoolRoutine>();
            try
            {
                String School_Code = HttpContext.Current.Session["School_Code"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            
            //SqlCommand cmd = new SqlCommand("Select_ALL_ADMIN_Notice", con);
            SqlCommand cmd = new SqlCommand("ClassRoutine_InsertUpdateDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@School_Code", School_Code);
            cmd.Parameters.AddWithValue("@Query", 2);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                RoutineList.Add(
                    new SchoolRoutine
                    {
                        Routine_Id = Convert.ToInt32(dr["Routine_Id"]),
                        School_Id = Convert.ToInt32(dr["School_Id"]),
                        School_Code = Convert.ToString(dr["School_Code"]),
                        School_Name = Convert.ToString(dr["School_Name"]),
                        Start_Time = Convert.ToString(dr["Start_Time"]),
                        End_Time = Convert.ToString(dr["End_Time"]),
                        Class_Namee = Convert.ToString(dr["Class_Name"]),
                        Section_Namee = Convert.ToString(dr["Section_Name"]),
                        Employee_Namee = Convert.ToString(dr["Employee_Name"]),
                        Subject_Namee = Convert.ToString(dr["Subject_Name"]),
                        Subject_Code = Convert.ToString(dr["Subject_Code"]),
                        Room_Namee = Convert.ToString(dr["Room_Name"]),
                        Day_Namee = Convert.ToString(dr["Day_Name"]),
                        Period_Namee = Convert.ToString(dr["Period_Name"]),


                    });
            }
            }
            catch (Exception ex)
            {
                // ViewBag.Error = ex.Message;

            }

            return RoutineList;
        }

        public List<CreateExamSchedule> ExamSchedukeList1(int ExamSchedule_Id)
        {
             SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
             List<CreateExamSchedule> examList = new List<CreateExamSchedule>();

            SqlCommand cmd = new SqlCommand("Exam_Schedule_Insert_Update", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@ExamSchedule_Idd", ExamSchedule_Id);
            cmd.Parameters.AddWithValue("@Query", 4);

            SqlDataAdapter sd = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                examList.Add(
                    new CreateExamSchedule
                    {
                        ExamSchedule_Id = Convert.ToInt32(dr["ExamSchedule_Id"]),
                        School_Code = Convert.ToString(dr["School_Code"]),
                        Exm_Term_Name = Convert.ToString(dr["Exam_Term_Name"]),
                        Year = Convert.ToString(dr["Year"]),
                        Class = Convert.ToString(dr["Class_Name"]),

                        Subject_Namee = Convert.ToString(dr["Subject_Name"]),
                        //Day_Namee = Convert.ToString(dr["Day_Name"]),
                        Exam_Date = Convert.ToString(dr["Exam_Date"]),


                        Start_Time = Convert.ToString(dr["Start_Time"]),
                        End_Time = Convert.ToString(dr["End_Time"])


                    });
            }
            return examList;
        }


        public void Add_Syllabus(StudentSyllabus model)
        {
            String School_Code = HttpContext.Current.Session["School_Code"].ToString();
            SqlCommand com = new SqlCommand("Syllabus", con);
            com.CommandType = CommandType.StoredProcedure;
         
           com.Parameters.AddWithValue("@School_Code", School_Code);
            com.Parameters.AddWithValue("@Session_Year", model.Session_Year);
       
            com.Parameters.AddWithValue("@Class_Id", model.Class_Id);
            //com.Parameters.AddWithValue("@Section_Id", model.Section_Id);
            com.Parameters.AddWithValue("@Subject_Id", model.Subject_Id);
            com.Parameters.AddWithValue("@Exam_Id", model.Exam_Id);
            com.Parameters.AddWithValue("@Syllabus_Desc", model.Syllabus_Desc);
            com.Parameters.AddWithValue("@Syllabus_Attachment_name", model.Syllabus_Attachment_name);
            com.Parameters.AddWithValue("@Syllabus_Attachment_Path", model.Syllabus_Attachment_Path);


            com.Parameters.AddWithValue("@Query", 1);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }


        public void Update_Syllabus(StudentSyllabus model)
        {
            String School_Code = HttpContext.Current.Session["School_Code"].ToString();
            SqlCommand com = new SqlCommand("Syllabus", con);
            com.CommandType = CommandType.StoredProcedure;

            //com.Parameters.AddWithValue("@School_Code", School_Code);
            //com.Parameters.AddWithValue("@Session_Year", model.Session_Year);

            //com.Parameters.AddWithValue("@Class_Id", model.Class_Id);
            ////com.Parameters.AddWithValue("@Section_Id", model.Section_Id);
            //com.Parameters.AddWithValue("@Subject_Id", model.Subject_Id);
            com.Parameters.AddWithValue("@Syllabus_Id", model.Syllabus_Id);
            com.Parameters.AddWithValue("@Syllabus_Desc", model.Syllabus_Desc);
            
            com.Parameters.AddWithValue("@Syllabus_Attachment_name", model.Syllabus_Attachment_name);
            com.Parameters.AddWithValue("@Syllabus_Attachment_Path", model.Syllabus_Attachment_Path);
            if (model.Syllabus_Attachment_name == null)
            {
                com.Parameters.AddWithValue("@Query", 2);

            }

            else
            {
                com.Parameters.AddWithValue("@Query", 3);
            }

           
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }






    }

}