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
    public class EmployeeDetailsDB
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);

        public List<EmpNoticeDetails> GetEmpNotice()
        {

            List<EmpNoticeDetails> Noticelist = new List<EmpNoticeDetails>();
            try
            {
                String School_Code = HttpContext.Current.Session["School_Code"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
         
            //SqlCommand cmd = new SqlCommand("Select_ALL_EMP_Notice", con);
            SqlCommand cmd = new SqlCommand("School_Notice_Fetch", con);
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
                Noticelist.Add(
                    new EmpNoticeDetails
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

        //public List<EmpNoticeDetails> GetEmpAllDetails()
        //{
        //    String School_Code = HttpContext.Current.Session["School_Code"].ToString();
        //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
        //    List<EmpNoticeDetails> Noticelist = new List<EmpNoticeDetails>();

        //    SqlCommand cmd = new SqlCommand("Select_ALL_EMP_Notice", con);
        //    cmd.CommandType = CommandType.StoredProcedure;

        //    cmd.Parameters.AddWithValue("@School_Code", School_Code);

        //    SqlDataAdapter sd = new SqlDataAdapter(cmd);

        //    DataTable dt = new DataTable();

        //    con.Open();
        //    sd.Fill(dt);
        //    con.Close();

        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        Noticelist.Add(
        //            new EmpNoticeDetails
        //            {
        //                Notice_Id = Convert.ToInt32(dr["Notice_Id"]),
        //                School_Code = Convert.ToString(dr["School_Code"]),
        //                Notice_Title = Convert.ToString(dr["Notice_Title"]),
        //                Notice_Description = Convert.ToString(dr["Notice_Description"]),
        //                Notice_Published_On = Convert.ToString(dr["Notice_Published_On"])


        //            });
        //    }
        //    return Noticelist;
        //}


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


        public List<EmployeeDetails> GetEmployeeInfo()
        {
            List<EmployeeDetails> EmpDetailslist = new List<EmployeeDetails>();
            try
            {
            String School_Code = HttpContext.Current.Session["School_Code"].ToString();
            String Employee_Email = HttpContext.Current.Session["Employee_Email"].ToString();
            String Employee_Password = HttpContext.Current.Session["Employee_Password"].ToString();
            String Employee_Id = HttpContext.Current.Session["Employee_Id"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
           
            SqlCommand cmd = new SqlCommand("Employee_InsertUpdateDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@School_Code", School_Code);
            cmd.Parameters.AddWithValue("@Employee_Email", Employee_Email);
            cmd.Parameters.AddWithValue("@Employee_Password", Employee_Password);
            cmd.Parameters.AddWithValue("@Employee_Id", Employee_Id);
            cmd.Parameters.AddWithValue("@Query", 3);
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

        public bool UpdateDetails(EmployeeDetails smodel)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Employee_InsertUpdateDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Employee_Id", smodel.Employee_Id);
            cmd.Parameters.AddWithValue("@Employee_Name", smodel.Employee_Name);
            cmd.Parameters.AddWithValue("@Employee_Email", smodel.Employee_Email);
            cmd.Parameters.AddWithValue("@Employee_Password", smodel.Employee_Password);
            cmd.Parameters.AddWithValue("@Employee_Mobile_Number", smodel.Employee_Mobile_Number);
            cmd.Parameters.AddWithValue("@Employee_Alt_Number", smodel.Employee_Alt_Number);
            cmd.Parameters.AddWithValue("@Employee_DOB", smodel.Employee_DOB);
            cmd.Parameters.AddWithValue("@Query", 2);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();

            if (i >= 1)
                return true;
            else
                return false;
        }


        public List<StudentAdmission> GetEligibleStuentDetails()
        {
            List<StudentAdmission> StuDetailslist = new List<StudentAdmission>();
            try
            {
                String School_Code = HttpContext.Current.Session["School_Code"].ToString();
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            
            SqlCommand cmd = new SqlCommand("[Select_ALL_EligiblityStudent]", con);

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
                        SignaturePath = String.IsNullOrEmpty(sdr["SignaturePath"].ToString()) ? null : sdr["SignaturePath"].ToString(),

                        CountryName = String.IsNullOrEmpty(sdr["CountryName"].ToString()) ? null : sdr["CountryName"].ToString(),
                        StateName = String.IsNullOrEmpty(sdr["StateName"].ToString()) ? null : sdr["StateName"].ToString(),
                        CityName = String.IsNullOrEmpty(sdr["CityName"].ToString()) ? null : sdr["CityName"].ToString(),
                        IdProof_Name = String.IsNullOrEmpty(sdr["IdProof_Name"].ToString()) ? null : sdr["IdProof_Name"].ToString(),
                        Board_Name = String.IsNullOrEmpty(sdr["Board_Name"].ToString()) ? null : sdr["Board_Name"].ToString(),
                        Class_Name = String.IsNullOrEmpty(sdr["Class_Name"].ToString()) ? null : sdr["Class_Name"].ToString(),
                        Application_Status = String.IsNullOrEmpty(sdr["Application_Status"].ToString()) ? null : sdr["Application_Status"].ToString()

                       // Fees_Name = String.IsNullOrEmpty(sdr["Fees_Name"].ToString()) ? null : sdr["Fees_Name"].ToString(),
                       // Fees_Desc = String.IsNullOrEmpty(sdr["Fees_Desc"].ToString()) ? null : sdr["Fees_Desc"].ToString(),
                       // Amount = String.IsNullOrEmpty(sdr["Amount"].ToString()) ? null : sdr["Amount"].ToString()



                    });
            }

        }
            catch (Exception ex)
            {
                // ViewBag.Error = ex.Message;

            }
           
            return StuDetailslist;
        }



        public bool UpdateFeesDetails(StudentFeesDetails smodel)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("StudentAdmission_Formfillup", con);
            cmd.CommandType = CommandType.StoredProcedure;
         
                cmd.Parameters.AddWithValue("@Fees_Id", smodel.Fees_Id);
                cmd.Parameters.AddWithValue("@Year", smodel.Year);
                cmd.Parameters.AddWithValue("@Class_Id", smodel.Class_Id);
                cmd.Parameters.AddWithValue("@Fees_Name", smodel.Fees_Name);
                cmd.Parameters.AddWithValue("@Fees_Desc", smodel.Fees_Desc);
                cmd.Parameters.AddWithValue("@Amount", smodel.Amount);
                cmd.Parameters.AddWithValue("@School_Code", smodel.School_Code);
                cmd.Parameters.AddWithValue("@Student_Id", smodel.Student_Id);
                cmd.Parameters.AddWithValue("@School_Id", smodel.School_Id);
                cmd.Parameters.AddWithValue("@Paid_Status", smodel.Paid_Status);
                cmd.Parameters.AddWithValue("@remark_note", smodel.remark_note); 
                cmd.Parameters.AddWithValue("@Query_step", "Step7");
         
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }

        public bool UpdateStudentDetails(StudentFeesDetails smodel)
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("StudentAdmission_Formfillup", con);
            cmd.CommandType = CommandType.StoredProcedure;

           // cmd.Parameters.AddWithValue("@Fees_Id", smodel.Fees_Id);
            cmd.Parameters.AddWithValue("@Year", smodel.Year);
            cmd.Parameters.AddWithValue("@Class_Id", smodel.Class_Id);
           // cmd.Parameters.AddWithValue("@Fees_Name", smodel.Fees_Name);
          //  cmd.Parameters.AddWithValue("@Fees_Desc", smodel.Fees_Desc);
           // cmd.Parameters.AddWithValue("@Amount", smodel.Amount);
            cmd.Parameters.AddWithValue("@School_Code", smodel.School_Code);
            cmd.Parameters.AddWithValue("@Student_Id", smodel.Student_Id);
            cmd.Parameters.AddWithValue("@School_Id", smodel.School_Id);
          //  cmd.Parameters.AddWithValue("@Paid_Status", smodel.Paid_Status);
           // cmd.Parameters.AddWithValue("@remark_note", smodel.remark_note);
            cmd.Parameters.AddWithValue("@Query_step", "Step6");

            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }




        public void Add_Class_Note(ClassNoteModule schfees)
        {
            // SqlCommand com = new SqlCommand("Parent_Registration", con);
            SqlCommand com = new SqlCommand("ClassNote_InsertUpdateDelete", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@School_Code", schfees.School_Code);
            com.Parameters.AddWithValue("@School_Id", schfees.School_Id);
            com.Parameters.AddWithValue("@School_Name", schfees.School_Name);
            com.Parameters.AddWithValue("@Class_Id", schfees.Class_Id);
            com.Parameters.AddWithValue("@Employee_Id", schfees.Employee_Id);
            com.Parameters.AddWithValue("@Section_Id", schfees.Section_Id);
            com.Parameters.AddWithValue("@Subject_Id", schfees.Subject_Id);
            com.Parameters.AddWithValue("@Topic_Name", schfees.Topic_Name);
            com.Parameters.AddWithValue("@Note_Date", schfees.Note_Date);
            com.Parameters.AddWithValue("@Note_Description", schfees.Note_Description);
            com.Parameters.AddWithValue("@Note_Type_Id", schfees.Note_Type_Id);
            com.Parameters.AddWithValue("@Query", 1);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }

        public List<ClassNoteModule> GetallClassNote()
        {
            List<ClassNoteModule> Notelist = new List<ClassNoteModule>();
            try
            {
                String School_Code = HttpContext.Current.Session["School_Code"].ToString();
            String Employee_Id = HttpContext.Current.Session["Employee_Id"].ToString();
            //String Employee_Email = HttpContext.Current.Session["Employee_Email"].ToString();
            // String Employee_Password = HttpContext.Current.Session["Employee_Password"].ToString();

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            
            SqlCommand cmd = new SqlCommand("ClassNote_InsertUpdateDelete", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@School_Code", School_Code);
            cmd.Parameters.AddWithValue("@Employee_Id", Employee_Id);
            //cmd.Parameters.AddWithValue("@Employee_Email", Employee_Email);
            //cmd.Parameters.AddWithValue("@Employee_Password", Employee_Password);

            cmd.Parameters.AddWithValue("@Query", 2);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            con.Open();
            sd.Fill(dt);
            con.Close();

            foreach (DataRow dr in dt.Rows)
            {
                Notelist.Add(
                    new ClassNoteModule
                    {
                        Note_Id = Convert.ToInt32(dr["id"]),
                        School_Id = Convert.ToInt32(dr["School_Id"]),
                        School_Code = Convert.ToString(dr["School_Code"]),
                        School_Name = Convert.ToString(dr["School_Name"]),
                        Employee_Namee = Convert.ToString(dr["Employee_Name"]),
                        Class_Namee = Convert.ToString(dr["Class_Name"]),
                        Section_Namee = Convert.ToString(dr["Section_Name"]),
                        Subject_Namee = Convert.ToString(dr["Subject_Name"]),
                        Note_Type_Namee = Convert.ToString(dr["Note_Type_Name"]),
                        Topic_Name = Convert.ToString(dr["Topic_Name"]),
                        Note_Description = Convert.ToString(dr["Note_Description"]),
                        Note_Date = Convert.ToString(dr["Note_Date"]),


                        //Employee_Mobile_Number = Convert.ToString(dr["Employee_Mobile_Number"]),
                        //Employee_Alt_Number = Convert.ToString(dr["Employee_Alt_Number"]),
                        //Employee_DOB = Convert.ToString(dr["Employee_DOB"])
                    });
            }

            }
            catch (Exception ex)
            {
                // ViewBag.Error = ex.Message;

            }

            return Notelist;
        }

        public bool AddStudentMarks(StudentMarks smodel)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Student_Score_InsertUpdateDelete", con);
            //try
            //{ 
            String School_Code = HttpContext.Current.Session["School_Code"].ToString();
            cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@School_Code",School_Code);
                cmd.Parameters.AddWithValue("@Student_Id", smodel.Student_Id);
                cmd.Parameters.AddWithValue("@Class_Id", smodel.Class_Id);
                cmd.Parameters.AddWithValue("@Session_Year", smodel.Session_Year);
                cmd.Parameters.AddWithValue("@ExamType_Id", smodel.ExamType_Id);
                cmd.Parameters.AddWithValue("@Section_Name", smodel.Section_Nam);
                cmd.Parameters.AddWithValue("@Subject_Id", smodel.Subject_Id);
                cmd.Parameters.AddWithValue("@Score", smodel.student_marks);
                cmd.Parameters.AddWithValue("@Query", "1");

            con.Open();
         

       // }
            //catch (Exception ex)
            //{
            //    // ViewBag.Error = ex.Message;

            //}

            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i >= 1)
                return true;
            else
                return false;
        }




        public bool AddStudentAttendance(StudentAttendance smodel)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DataSchoolDB"].ConnectionString);
            SqlCommand cmd = new SqlCommand("Student_Attendance_InsertUpdate", con);
            try
            {
                String School_Code = HttpContext.Current.Session["School_Code"].ToString();
               int Employee_Id = Convert.ToInt32(HttpContext.Current.Session["Employee_Id"]);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Session_Year", smodel.Session_Year);
                cmd.Parameters.AddWithValue("@School_Code", School_Code);
                cmd.Parameters.AddWithValue("@Student_Id", smodel.Student_Id);
               cmd.Parameters.AddWithValue("@Class_Id", smodel.Class_Id);        
               cmd.Parameters.AddWithValue("@Section_Id", smodel.Section_Id);
                cmd.Parameters.AddWithValue("@Period_Name", smodel.Period_Name);
                cmd.Parameters.AddWithValue("@Period_Date",smodel.Period_Date);
                cmd.Parameters.AddWithValue("@Presence_Status", smodel.Presence_Status);
                cmd.Parameters.AddWithValue("@Employee_Id", Employee_Id);
                cmd.Parameters.AddWithValue("@absent_reasons", smodel.Absent_Reasons);
                cmd.Parameters.AddWithValue("@Query", "1");

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