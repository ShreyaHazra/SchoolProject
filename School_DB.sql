USE [School_DB]
GO
/****** Object:  Table [dbo].[BloodGroup_Master]    Script Date: 2020-03-24 9:44:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BloodGroup_Master](
	[BloodGroup_Id] [int] IDENTITY(1,1) NOT NULL,
	[BloodGroup_Name] [varchar](50) NULL,
 CONSTRAINT [PK_BloodGroup_Master] PRIMARY KEY CLUSTERED 
(
	[BloodGroup_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Board_Master]    Script Date: 2020-03-24 9:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Board_Master](
	[Board_Id] [int] IDENTITY(1,1) NOT NULL,
	[Board_Name] [varchar](50) NULL,
 CONSTRAINT [PK_Board_Master] PRIMARY KEY CLUSTERED 
(
	[Board_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[city]    Script Date: 2020-03-24 9:44:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[city](
	[CityId] [int] NOT NULL,
	[CityName] [varchar](50) NULL,
	[StateId] [int] NULL,
	[CountryId] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Class_Master]    Script Date: 2020-03-24 9:44:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Class_Master](
	[Class_Id] [int] IDENTITY(1,1) NOT NULL,
	[Class_Name] [varchar](50) NULL,
	[School_Code] [varchar](50) NULL,
	[School_Group_Code] [varchar](50) NULL,
	[STime] [time](7) NULL,
	[ETime] [time](7) NULL,
 CONSTRAINT [PK_School_Class_Master] PRIMARY KEY CLUSTERED 
(
	[Class_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[country]    Script Date: 2020-03-24 9:44:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[country](
	[CountryId] [int] IDENTITY(1,1) NOT NULL,
	[CountryName] [varchar](50) NULL,
 CONSTRAINT [PK_country] PRIMARY KEY CLUSTERED 
(
	[CountryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Day]    Script Date: 2020-03-24 9:44:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Day](
	[Day_Id] [int] IDENTITY(1,1) NOT NULL,
	[Day_Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Day] PRIMARY KEY CLUSTERED 
(
	[Day_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Event_Calendar]    Script Date: 2020-03-24 9:44:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Event_Calendar](
	[Event_ID] [int] IDENTITY(1,1) NOT NULL,
	[School_Code] [varchar](50) NULL,
	[School_Group_Code] [varchar](50) NULL,
	[Subject] [varchar](max) NULL,
	[Description] [text] NULL,
	[Start_Date] [date] NULL,
	[End_Date] [date] NULL,
	[Theme_Color] [varchar](50) NULL,
	[IS_Full_Day] [varchar](50) NULL,
	[Event_Type] [varchar](50) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Exam_Schedule]    Script Date: 2020-03-24 9:44:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exam_Schedule](
	[ExamSchedule_Id] [int] IDENTITY(1,1) NOT NULL,
	[ExamTerm_Id] [int] NULL,
	[Year] [varchar](50) NULL,
	[School_Code] [varchar](50) NULL,
	[School_Id] [int] NULL,
	[Class_Id] [int] NULL,
	[Section_Id] [int] NULL,
	[Subject_Id] [int] NULL,
	[Exam_Subject_Type] [varchar](50) NULL,
	[Day_Id] [int] NULL,
	[Exam_Day] [varchar](50) NULL,
	[Exam_Date] [varchar](50) NULL,
	[Start_Time] [varchar](50) NULL,
	[End_Time] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IdProof_Master]    Script Date: 2020-03-24 9:44:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IdProof_Master](
	[IdProof_Id] [int] IDENTITY(1,1) NOT NULL,
	[IdProof_Name] [varchar](50) NULL,
 CONSTRAINT [PK_dbo.IdProof_Master] PRIMARY KEY CLUSTERED 
(
	[IdProof_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Note_Type_Master]    Script Date: 2020-03-24 9:44:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Note_Type_Master](
	[Note_Type_Id] [int] IDENTITY(1,1) NOT NULL,
	[Note_Type_Name] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ParentRegistration]    Script Date: 2020-03-24 9:44:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ParentRegistration](
	[ParentID] [int] IDENTITY(1,1) NOT NULL,
	[School_Code] [varchar](50) NULL,
	[ParentName] [varchar](50) NULL,
	[ParentContact] [varchar](50) NULL,
	[ParentEmail] [varchar](50) NULL,
	[ParentPassword] [varchar](50) NULL,
	[ParentOTP] [varchar](50) NULL,
	[OTPGenerateTime] [timestamp] NULL,
	[OTPActiveStatus] [varchar](50) NULL,
 CONSTRAINT [PK_ParentRegistration] PRIMARY KEY CLUSTERED 
(
	[ParentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Performance_Report]    Script Date: 2020-03-24 9:44:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Performance_Report](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[School_Code] [varchar](50) NULL,
	[Parent_ID] [int] NULL,
	[Student_ID] [int] NULL,
	[Exam_ID] [int] NULL,
	[Subject_ID] [int] NULL,
	[Class_ID] [int] NULL,
	[Marks] [decimal](6, 2) NULL,
	[Date_Exam] [date] NULL,
	[Session] [varchar](50) NULL,
 CONSTRAINT [PK_Performance_Report] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Period_Child]    Script Date: 2020-03-24 9:44:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Period_Child](
	[Period_Id] [int] IDENTITY(1,1) NOT NULL,
	[Period_Name] [varchar](50) NULL,
	[Period_Type] [varchar](50) NULL,
	[Stime] [time](7) NULL,
	[Duration] [int] NULL,
	[Etime] [time](7) NULL,
	[Class_Id] [int] NULL,
	[School_Code] [varchar](50) NULL,
	[School_Group_Code] [varchar](50) NULL,
	[Order_period] [int] NULL,
 CONSTRAINT [PK_Period_Child] PRIMARY KEY CLUSTERED 
(
	[Period_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Period_Master]    Script Date: 2020-03-24 9:44:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Period_Master](
	[Period_Id] [int] IDENTITY(1,1) NOT NULL,
	[Period_Name] [varchar](50) NULL,
	[Period_Type] [varchar](50) NULL,
	[Stime] [time](7) NULL,
	[Duration] [int] NULL,
	[Etime] [time](7) NULL,
	[Class_Id] [int] NULL,
	[School_Code] [varchar](50) NULL,
	[School_Group_Code] [varchar](50) NULL,
	[Order_period] [int] NULL,
 CONSTRAINT [PK_Period_Master] PRIMARY KEY CLUSTERED 
(
	[Period_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[School_Class_Note]    Script Date: 2020-03-24 9:44:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[School_Class_Note](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[School_Id] [varchar](50) NOT NULL,
	[School_Code] [varchar](max) NULL,
	[School_Name] [varchar](max) NULL,
	[Employee_Id] [varchar](50) NULL,
	[Class_Id] [varchar](max) NULL,
	[Section_Id] [varchar](max) NULL,
	[Subject_Id] [varchar](max) NULL,
	[Topic_Name] [text] NULL,
	[Note_Description] [text] NOT NULL,
	[Note_Date] [varchar](50) NULL,
	[Note_Type_Id] [varchar](50) NULL,
 CONSTRAINT [PK_School_Class_Note] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[School_Class_Routine]    Script Date: 2020-03-24 9:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[School_Class_Routine](
	[Routine_Id] [int] IDENTITY(1,1) NOT NULL,
	[School_Id] [varchar](50) NULL,
	[School_Code] [varchar](max) NULL,
	[School_Name] [varchar](max) NULL,
	[Start_Time] [varchar](50) NULL,
	[End_Time] [varchar](50) NULL,
	[Class_Id] [varchar](50) NULL,
	[Section_Id] [varchar](50) NULL,
	[Employee_Id] [varchar](50) NULL,
	[Subject_Id] [varchar](50) NULL,
	[Room_Id] [varchar](50) NULL,
	[Year_Name] [varchar](50) NULL,
	[Day_Id] [varchar](50) NULL,
	[Period_Id] [varchar](50) NULL,
 CONSTRAINT [PK_School_Class_Routine] PRIMARY KEY CLUSTERED 
(
	[Routine_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[School_Details_Master]    Script Date: 2020-03-24 9:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[School_Details_Master](
	[School_Id] [int] IDENTITY(1,1) NOT NULL,
	[School_Group_Code] [varchar](50) NULL,
	[School_Code] [varchar](50) NULL,
	[School_Name] [varchar](max) NULL,
	[School_Email] [varchar](max) NULL,
	[School_Password] [varchar](max) NULL,
	[School_Phone] [varchar](max) NULL,
	[School_Contact_Person] [varchar](max) NULL,
	[School_Contact_Person_Email] [varchar](max) NULL,
	[School_Contact_Person_Phone] [varchar](max) NULL,
	[SchoolAddress1] [varchar](max) NULL,
	[SchoolAddress2] [varchar](max) NULL,
	[Country_Id] [int] NULL,
	[State_Id] [int] NULL,
	[City_Id] [int] NULL,
	[Board_Id] [int] NULL,
 CONSTRAINT [PK_School_Details_Master] PRIMARY KEY CLUSTERED 
(
	[School_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[School_Employee_Details]    Script Date: 2020-03-24 9:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[School_Employee_Details](
	[Employee_Id] [int] IDENTITY(1,1) NOT NULL,
	[School_Id] [int] NULL,
	[School_Code] [varchar](50) NULL,
	[School_Name] [varchar](50) NULL,
	[EmpType_Id] [int] NULL,
	[Employee_Name] [varchar](50) NULL,
	[Employee_Code] [varchar](50) NULL,
	[Employee_Email] [varchar](50) NULL,
	[Employee_Password] [varchar](50) NULL,
	[Employee_Mobile_Number] [varchar](50) NULL,
	[Employee_Alt_Number] [varchar](50) NULL,
	[Employee_DOB] [varchar](50) NULL,
 CONSTRAINT [PK_School_Employee_Details] PRIMARY KEY CLUSTERED 
(
	[Employee_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[School_EmpType_Master]    Script Date: 2020-03-24 9:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[School_EmpType_Master](
	[Type_Id] [int] IDENTITY(1,1) NOT NULL,
	[School_Id] [int] NULL,
	[School_Code] [varchar](50) NULL,
	[School_Name] [varchar](50) NULL,
	[EmpType_Name] [varchar](50) NULL,
	[User_Type] [varchar](50) NULL,
 CONSTRAINT [PK_School_EmpType_Master] PRIMARY KEY CLUSTERED 
(
	[Type_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[School_Exam_Term_Master]    Script Date: 2020-03-24 9:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[School_Exam_Term_Master](
	[Exam_Term_id] [int] IDENTITY(1,1) NOT NULL,
	[School_Id] [varchar](50) NULL,
	[School_Name] [varchar](max) NULL,
	[School_Code] [varchar](50) NULL,
	[Exam_Term_Name] [varchar](max) NULL,
	[Class_Id] [int] NULL,
 CONSTRAINT [PK_School_Fees_Term_Master] PRIMARY KEY CLUSTERED 
(
	[Exam_Term_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[School_Fees_Master]    Script Date: 2020-03-24 9:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[School_Fees_Master](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[School_Code] [varchar](max) NULL,
	[School_Id] [varchar](max) NULL,
	[Class_Id] [varchar](max) NULL,
	[Fees_Name] [varchar](max) NULL,
	[Fees_Desc] [text] NULL,
	[Amount] [varchar](max) NULL,
	[Fees_Year] [varchar](max) NULL,
 CONSTRAINT [PK_School_Fees_Master] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[School_House_Master]    Script Date: 2020-03-24 9:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[School_House_Master](
	[Section_Id] [int] IDENTITY(1,1) NOT NULL,
	[School_Id] [int] NULL,
	[School_Code] [varchar](50) NULL,
	[School_Name] [varchar](50) NULL,
	[House_Name] [varchar](50) NULL,
 CONSTRAINT [PK_School_House_Master] PRIMARY KEY CLUSTERED 
(
	[Section_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[School_Notice_Master]    Script Date: 2020-03-24 9:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[School_Notice_Master](
	[Notice_Id] [int] IDENTITY(1,1) NOT NULL,
	[School_Id] [int] NULL,
	[School_Code] [varchar](50) NULL,
	[School_Name] [varchar](50) NULL,
	[Notice_Title] [varchar](50) NULL,
	[Notice_Description] [text] NULL,
	[User_Type_Id] [int] NULL,
	[Notice_Published_On] [varchar](50) NULL,
	[Notice_Status] [varchar](50) NULL,
 CONSTRAINT [PK_School_Notice_Master] PRIMARY KEY CLUSTERED 
(
	[Notice_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[School_Room_Master]    Script Date: 2020-03-24 9:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[School_Room_Master](
	[Room_Id] [int] IDENTITY(1,1) NOT NULL,
	[School_Code] [varchar](50) NULL,
	[School_Group_Code] [varchar](50) NULL,
	[Room_Name] [nvarchar](max) NULL,
	[Room_no] [int] NULL,
	[Floor] [int] NULL,
	[Room_Category] [varchar](50) NULL,
	[Occupied] [varchar](50) NULL,
 CONSTRAINT [PK_School_Room_Master] PRIMARY KEY CLUSTERED 
(
	[Room_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[School_RoomCategory]    Script Date: 2020-03-24 9:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[School_RoomCategory](
	[Category_id] [int] IDENTITY(1,1) NOT NULL,
	[Category_Name] [varchar](max) NOT NULL,
	[Category_Description] [varchar](max) NULL,
	[School_Code] [varchar](50) NULL,
	[School_Group_Code] [varchar](50) NULL,
 CONSTRAINT [PK_School_Category] PRIMARY KEY CLUSTERED 
(
	[Category_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[School_Section_Master]    Script Date: 2020-03-24 9:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[School_Section_Master](
	[Section_Id] [int] IDENTITY(1,1) NOT NULL,
	[School_Id] [int] NULL,
	[School_Code] [varchar](50) NULL,
	[Class_Id] [int] NULL,
	[School_Name] [varchar](50) NULL,
	[Section_Name] [varchar](50) NULL,
	[Section_Room_Number] [varchar](50) NULL,
 CONSTRAINT [PK_School_Section_Master] PRIMARY KEY CLUSTERED 
(
	[Section_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[School_Student_Details]    Script Date: 2020-03-24 9:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[School_Student_Details](
	[Student_Id] [int] IDENTITY(1,1) NOT NULL,
	[Parent_Id] [int] NULL,
	[Application_Id] [varchar](50) NULL,
	[School_Code] [varchar](50) NULL,
	[first_name] [varchar](50) NULL,
	[last_name] [varchar](50) NULL,
	[middle_name] [varchar](50) NULL,
	[Student_Email] [varchar](max) NULL,
	[Password] [varchar](50) NULL,
	[FatherName] [varchar](50) NULL,
	[FatherContactNumber] [varchar](50) NULL,
	[FatherEmail] [varchar](50) NULL,
	[MotherName] [varchar](50) NULL,
	[MotherContactNumber] [varchar](50) NULL,
	[MotherEmail] [varchar](50) NULL,
	[HomeContactNumber] [varchar](50) NULL,
	[LocalGurdianValue] [varchar](50) NULL,
	[LocalGurdianName] [varchar](50) NULL,
	[LocalGurdianEmail] [varchar](50) NULL,
	[LocalGurdianPhone] [varchar](50) NULL,
	[Gender_Id] [varchar](50) NULL,
	[DOB] [varchar](50) NULL,
	[POB] [varchar](50) NULL,
	[PermanentAddress1] [varchar](50) NULL,
	[PermanentAddress2] [varchar](50) NULL,
	[permanentzipcode] [varchar](50) NULL,
	[PerCountryId] [int] NULL,
	[Per_District] [int] NULL,
	[PerStateId] [int] NULL,
	[PerCityId] [int] NULL,
	[CurrentAddress1] [varchar](50) NULL,
	[CurrentAddress2] [varchar](50) NULL,
	[currentzipcode] [varchar](50) NULL,
	[CountryId] [int] NULL,
	[StateId] [int] NULL,
	[District] [int] NULL,
	[CityId] [int] NULL,
	[Zip] [int] NULL,
	[Cur_Landmark] [varchar](max) NULL,
	[Per_Landmark] [varchar](max) NULL,
	[Email] [varchar](50) NULL,
	[Phone] [int] NULL,
	[BloodGroup_Id] [int] NULL,
	[BirthCertificatePath] [varchar](max) NULL,
	[BirthCertificate_Name] [nchar](10) NULL,
	[IdProof_Id] [int] NULL,
	[IdProof_Number] [varchar](50) NULL,
	[Passport_Number] [varchar](50) NULL,
	[CitizenCountryId] [int] NULL,
	[BCN] [varchar](50) NULL,
	[BCN_Attachment] [varchar](max) NULL,
	[Special_Care] [int] NULL,
	[Special_Care_Description] [varchar](50) NULL,
	[Disability] [int] NULL,
	[Disability_Percentage] [varchar](50) NULL,
	[Disability_Description] [varchar](50) NULL,
	[Disability_Certificate_Number] [varchar](50) NULL,
	[DisabilityCertificat_Name] [varchar](max) NULL,
	[DisabilityCertificatePath] [varchar](max) NULL,
	[Caste] [int] NULL,
	[Religion] [int] NULL,
	[Special] [binary](50) NULL,
	[Details] [varchar](50) NULL,
	[Physically_Hdc] [binary](50) NULL,
	[Hdc_Percent] [float] NULL,
	[Is_Monitor] [binary](50) NULL,
	[Status] [binary](50) NULL,
	[AdmissionClass_Id] [int] NULL,
	[Section_Id] [int] NULL,
	[SectionName] [varchar](50) NULL,
	[Last_School_Name] [varchar](50) NULL,
	[SchoolBoard_Id] [int] NULL,
	[Last_School_Year] [varchar](50) NULL,
	[Last_School_Class] [varchar](50) NULL,
	[School_Transfer_Certifiate_Number] [varchar](50) NULL,
	[SchoolTransferCertificate_Name] [varchar](50) NULL,
	[SchoolTransferCertificatePath] [varchar](max) NULL,
	[Last_School_Exam_Marks] [varchar](50) NULL,
	[Last_School_Total_Marks] [varchar](50) NULL,
	[Last_School_Marks_Percentage] [varchar](50) NULL,
	[FinalExamResult_Name] [varchar](max) NULL,
	[FinalExamResultPath] [varchar](max) NULL,
	[Board_Exam_Marks] [varchar](50) NULL,
	[Board_Total_Marks] [varchar](50) NULL,
	[Marks_Percentage] [varchar](50) NULL,
	[Board_Certificate_Number] [varchar](50) NULL,
	[BoardExamResultName] [varchar](max) NULL,
	[BoardExamResultPath] [varchar](max) NULL,
	[BoardExamCertificate_Name] [varchar](max) NULL,
	[BoardExamCertificatePath] [varchar](max) NULL,
	[ImagePath] [varchar](max) NULL,
	[SignaturePath] [varchar](max) NULL,
	[TermsAndConditions] [bit] NULL,
	[Application_Status] [varchar](max) NULL,
	[Registration_Status] [varchar](50) NULL,
 CONSTRAINT [PK_School_Student_Details] PRIMARY KEY CLUSTERED 
(
	[Student_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[School_Subject_Master]    Script Date: 2020-03-24 9:44:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[School_Subject_Master](
	[Subject_id] [int] IDENTITY(1,1) NOT NULL,
	[School_Id] [int] NULL,
	[School_Code] [varchar](50) NULL,
	[School_Name] [varchar](50) NULL,
	[Class_Id] [int] NULL,
	[Subject_Type] [varchar](50) NULL,
	[Subject_Name] [varchar](50) NULL,
	[Priority_Value] [int] NULL,
	[Exam_Sub_Type] [varchar](50) NULL,
	[Subject_Code] [varchar](50) NULL,
	[FullMarks] [int] NULL,
	[PracticalMarks] [int] NULL,
	[PassMarks] [int] NULL,
	[AdditionalSubject] [varchar](50) NULL,
	[Language_Preference] [int] NULL,
	[Status] [varchar](50) NULL,
 CONSTRAINT [PK_Subject_Master] PRIMARY KEY CLUSTERED 
(
	[Subject_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[School_User_Master]    Script Date: 2020-03-24 9:44:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[School_User_Master](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[User_Id] [int] NULL,
	[User_Email] [varchar](50) NULL,
	[User_Password] [varchar](50) NULL,
	[School_Code] [varchar](50) NULL,
	[School_Group_Code] [varchar](50) NULL,
	[User_Type] [int] NULL,
 CONSTRAINT [PK_School_User_Master] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[School_User_Type_Master]    Script Date: 2020-03-24 9:44:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[School_User_Type_Master](
	[User_Type_Id] [int] IDENTITY(1,1) NOT NULL,
	[User_Type_Name] [varchar](50) NULL,
 CONSTRAINT [PK_School_User_Type_Master] PRIMARY KEY CLUSTERED 
(
	[User_Type_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[state]    Script Date: 2020-03-24 9:44:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[state](
	[StateId] [int] NOT NULL,
	[CountryId] [int] NULL,
	[StateName] [varchar](50) NULL,
 CONSTRAINT [PK_state] PRIMARY KEY CLUSTERED 
(
	[StateId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student_Attendance]    Script Date: 2020-03-24 9:44:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student_Attendance](
	[Att_Id] [int] IDENTITY(1,1) NOT NULL,
	[Session_Year] [varchar](50) NULL,
	[School_Code] [varchar](50) NULL,
	[Student_Id] [int] NULL,
	[Class_Id] [int] NULL,
	[Section_Id] [int] NULL,
	[Period_Date] [varchar](50) NULL,
	[Subject_Id] [int] NULL,
	[Period_Id] [int] NULL,
	[Presence_Status] [varchar](50) NULL,
 CONSTRAINT [PK_Student_Attendance] PRIMARY KEY CLUSTERED 
(
	[Att_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student_Fees_Master]    Script Date: 2020-03-24 9:44:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student_Fees_Master](
	[F_id] [int] IDENTITY(1,1) NOT NULL,
	[School_Code] [varchar](max) NULL,
	[School_Id] [varchar](max) NULL,
	[Student_Id] [int] NULL,
	[Fees_Id] [int] NULL,
	[Class_Id] [varchar](max) NULL,
	[Fees_Name] [varchar](max) NULL,
	[Fees_Desc] [text] NULL,
	[Amount] [varchar](max) NULL,
	[Fees_Year] [varchar](max) NULL,
	[Paid_Status] [varchar](max) NULL,
	[remark_note] [varchar](max) NULL,
 CONSTRAINT [PK_Student_Fees_Master_1] PRIMARY KEY CLUSTERED 
(
	[F_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student_file_Attachemnt]    Script Date: 2020-03-24 9:44:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student_file_Attachemnt](
	[Attachment_Id] [int] IDENTITY(1,1) NOT NULL,
	[School_Code] [varchar](50) NULL,
	[Student_Id] [int] NULL,
	[StudentfilePath] [varchar](max) NULL,
	[interview_note] [nchar](10) NULL,
 CONSTRAINT [PK_Student_file_Attachemnt] PRIMARY KEY CLUSTERED 
(
	[Attachment_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student_Group_Master]    Script Date: 2020-03-24 9:44:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student_Group_Master](
	[Group_Id] [int] IDENTITY(1,1) NOT NULL,
	[School_Id] [int] NULL,
	[School_Code] [varchar](50) NULL,
	[School_Name] [varchar](50) NULL,
	[Group_Name] [varchar](50) NULL,
 CONSTRAINT [PK_Student_Group_Master] PRIMARY KEY CLUSTERED 
(
	[Group_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student_Homework]    Script Date: 2020-03-24 9:44:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student_Homework](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Student_ID] [int] NULL,
	[Teacher_ID] [int] NULL,
	[Assigned_Date] [date] NULL,
	[Due_Date] [date] NULL,
	[Subm_Date] [date] NULL,
	[Subject_ID] [int] NULL,
	[Description] [varchar](max) NULL,
	[Status] [varchar](50) NULL,
	[Class_ID] [int] NULL,
	[Section_ID] [int] NULL,
	[Topic] [varchar](50) NULL,
	[File_Name] [varchar](50) NULL,
	[File_Path] [varchar](200) NULL,
 CONSTRAINT [PK_Student_Homework] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student_Master]    Script Date: 2020-03-24 9:44:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student_Master](
	[Student_Id] [int] IDENTITY(1,1) NOT NULL,
	[Parent_Id] [int] NULL,
	[School_Code] [varchar](50) NULL,
	[Application_Id] [varchar](max) NULL,
	[first_name] [varchar](50) NULL,
	[last_name] [varchar](50) NULL,
	[middle_name] [varchar](50) NULL,
	[FatherName] [varchar](50) NULL,
	[FatherContactNumber] [varchar](50) NULL,
	[FatherEmail] [varchar](50) NULL,
	[MotherName] [varchar](50) NULL,
	[MotherContactNumber] [varchar](50) NULL,
	[MotherEmail] [varchar](50) NULL,
	[HomeContactNumber] [varchar](50) NULL,
	[LocalGurdianValue] [varchar](50) NOT NULL,
	[LocalGurdianName] [varchar](50) NULL,
	[LocalGurdianEmail] [varchar](50) NULL,
	[LocalGurdianPhone] [varchar](50) NULL,
	[Gender_Id] [varchar](50) NULL,
	[DOB] [varchar](50) NULL,
	[POB] [varchar](50) NULL,
	[PermanentAddress1] [varchar](50) NULL,
	[PermanentAddress2] [varchar](50) NULL,
	[permanentzipcode] [varchar](50) NULL,
	[PerCountryId] [int] NULL,
	[Per_District] [int] NULL,
	[PerStateId] [int] NULL,
	[PerCityId] [int] NULL,
	[CurrentAddress1] [varchar](50) NULL,
	[CurrentAddress2] [varchar](50) NULL,
	[currentzipcode] [varchar](50) NULL,
	[CountryId] [int] NULL,
	[StateId] [int] NULL,
	[District] [int] NULL,
	[CityId] [int] NULL,
	[Zip] [int] NULL,
	[Cur_Landmark] [varchar](max) NULL,
	[Per_Landmark] [varchar](max) NULL,
	[Email] [varchar](50) NULL,
	[Phone] [int] NULL,
	[BloodGroup_Id] [int] NULL,
	[BirthCertificate_Name] [varchar](max) NULL,
	[BirthCertificatePath] [varchar](max) NULL,
	[IdProof_Id] [int] NULL,
	[IdProof_Number] [varchar](50) NULL,
	[Passport_Number] [varchar](50) NULL,
	[CitizenCountryId] [int] NULL,
	[BCN] [varchar](50) NULL,
	[BCN_Attachment_Name] [varchar](max) NULL,
	[BCN_Attachment] [varchar](max) NULL,
	[Special_Care] [int] NULL,
	[Special_Care_Description] [varchar](50) NULL,
	[Disability] [int] NULL,
	[Disability_Percentage] [varchar](50) NULL,
	[Disability_Description] [varchar](50) NULL,
	[Disability_Certificate_Number] [varchar](50) NULL,
	[DisabilityCertificat_Name] [varchar](max) NULL,
	[DisabilityCertificatePath] [varchar](max) NULL,
	[Caste] [int] NULL,
	[Religion] [int] NULL,
	[Special] [binary](50) NULL,
	[Physically_Hdc] [binary](50) NULL,
	[Hdc_Percent] [float] NULL,
	[Is_Monitor] [binary](50) NULL,
	[Status] [binary](50) NULL,
	[AdmissionClass_Id] [int] NULL,
	[Last_School_Name] [varchar](50) NULL,
	[SchoolBoard_Id] [int] NULL,
	[Last_School_Year] [varchar](50) NULL,
	[Last_School_Class] [varchar](50) NULL,
	[School_Transfer_Certifiate_Number] [varchar](50) NULL,
	[SchoolTransferCertificate_Name] [varchar](max) NULL,
	[SchoolTransferCertificatePath] [varchar](max) NULL,
	[Last_School_Exam_Marks] [varchar](50) NULL,
	[Last_School_Total_Marks] [varchar](50) NULL,
	[Last_School_Marks_Percentage] [varchar](50) NULL,
	[FinalExamResult_Name] [varchar](max) NULL,
	[FinalExamResultPath] [varchar](max) NULL,
	[Board_Exam_Marks] [varchar](50) NULL,
	[Board_Total_Marks] [varchar](50) NULL,
	[Marks_Percentage] [varchar](50) NULL,
	[Board_Certificate_Number] [varchar](50) NULL,
	[BoardExamResultName] [varchar](max) NULL,
	[BoardExamResultPath] [varchar](max) NULL,
	[BoardExamCertificate_Name] [varchar](max) NULL,
	[BoardExamCertificatePath] [varchar](max) NULL,
	[ImagePath] [varchar](max) NULL,
	[SignaturePath] [varchar](max) NULL,
	[Step_Complete] [varchar](50) NULL,
	[TermsAndConditions] [bit] NULL,
	[Application_Status] [varchar](max) NULL,
	[interview_note] [varchar](max) NULL,
 CONSTRAINT [PK_STD_MASTER_DB] PRIMARY KEY CLUSTERED 
(
	[Student_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Student_Score_Master]    Script Date: 2020-03-24 9:44:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Student_Score_Master](
	[Student_Score_Id] [int] IDENTITY(1,1) NOT NULL,
	[Session_Year] [varchar](50) NULL,
	[School_Code] [varchar](50) NULL,
	[School_Id] [int] NULL,
	[Student_Id] [int] NULL,
	[Class_Id] [int] NULL,
	[Section_Id] [varchar](50) NULL,
	[ExamTerm_Id] [int] NULL,
	[Subject_Id] [int] NULL,
	[Score] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teacher_Subject_Assign]    Script Date: 2020-03-24 9:44:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teacher_Subject_Assign](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[School_Code] [varchar](50) NULL,
	[Emp_ID] [int] NULL,
	[EmpType_ID] [int] NULL,
	[Emp_Code] [varchar](50) NULL,
	[Sub_ID] [int] NULL,
	[Class_ID] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Test_Type_Master]    Script Date: 2020-03-24 9:44:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Test_Type_Master](
	[Test_Type_Id] [int] IDENTITY(1,1) NOT NULL,
	[Test_Type_Desc] [varchar](50) NULL,
 CONSTRAINT [PK_Test_Type_Master] PRIMARY KEY CLUSTERED 
(
	[Test_Type_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Topic_Master]    Script Date: 2020-03-24 9:44:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Topic_Master](
	[Topic_id] [int] IDENTITY(1,1) NOT NULL,
	[Subject_id] [int] NULL,
	[Topic_Name] [varchar](50) NULL,
 CONSTRAINT [PK_Topic_Master] PRIMARY KEY CLUSTERED 
(
	[Topic_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Work_Role_Master]    Script Date: 2020-03-24 9:44:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Work_Role_Master](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Parent_Menu_Order] [int] NULL,
	[Parent_Menu] [varchar](50) NOT NULL,
	[Sub_Menu] [varchar](max) NULL,
	[Sub_Menu_Cn] [varchar](max) NULL,
	[Sub_Menu_Fn] [varchar](max) NULL,
	[User_Type_Id] [int] NULL,
 CONSTRAINT [PK_School_Work_Role_Master_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkGroup_Master]    Script Date: 2020-03-24 9:44:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkGroup_Master](
	[WorkGroup_Id] [int] IDENTITY(1,1) NOT NULL,
	[WorkGroup_Name] [varchar](max) NULL,
	[User_Type] [varchar](50) NULL,
	[Parent_Menu_Cn] [varchar](max) NULL,
	[Parent_Menu_Fn] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Year]    Script Date: 2020-03-24 9:44:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Year](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Year] [varchar](max) NULL,
	[Year_Name] [varchar](max) NULL,
 CONSTRAINT [PK_Year] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[BloodGroup_Master] ON 

INSERT [dbo].[BloodGroup_Master] ([BloodGroup_Id], [BloodGroup_Name]) VALUES (2, N'A+')
INSERT [dbo].[BloodGroup_Master] ([BloodGroup_Id], [BloodGroup_Name]) VALUES (3, N'A-')
INSERT [dbo].[BloodGroup_Master] ([BloodGroup_Id], [BloodGroup_Name]) VALUES (4, N'B+')
INSERT [dbo].[BloodGroup_Master] ([BloodGroup_Id], [BloodGroup_Name]) VALUES (5, N'B-')
INSERT [dbo].[BloodGroup_Master] ([BloodGroup_Id], [BloodGroup_Name]) VALUES (6, N'AB')
INSERT [dbo].[BloodGroup_Master] ([BloodGroup_Id], [BloodGroup_Name]) VALUES (7, N'AB+')
INSERT [dbo].[BloodGroup_Master] ([BloodGroup_Id], [BloodGroup_Name]) VALUES (8, N'AB-')
INSERT [dbo].[BloodGroup_Master] ([BloodGroup_Id], [BloodGroup_Name]) VALUES (9, N'O')
SET IDENTITY_INSERT [dbo].[BloodGroup_Master] OFF
SET IDENTITY_INSERT [dbo].[Board_Master] ON 

INSERT [dbo].[Board_Master] ([Board_Id], [Board_Name]) VALUES (1, N'CBSE')
INSERT [dbo].[Board_Master] ([Board_Id], [Board_Name]) VALUES (2, N'ICSE')
INSERT [dbo].[Board_Master] ([Board_Id], [Board_Name]) VALUES (3, N'State Board')
INSERT [dbo].[Board_Master] ([Board_Id], [Board_Name]) VALUES (4, N'Sainik School')
INSERT [dbo].[Board_Master] ([Board_Id], [Board_Name]) VALUES (5, N'Kendriya Vidyalaya')
SET IDENTITY_INSERT [dbo].[Board_Master] OFF
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1, N'Kolhapur', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (2, N'Port Blair', 5, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (3, N'Adilabad', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (4, N'Adoni', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (5, N'Amadalavalasa', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (6, N'Amalapuram', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (7, N'Anakapalle', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (8, N'Anantapur', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (9, N'Badepalle', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (10, N'Banganapalle', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (11, N'Bapatla', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (12, N'Bellampalle', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (13, N'Bethamcherla', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (14, N'Bhadrachalam', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (15, N'Bhainsa', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (16, N'Bheemunipatnam', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (17, N'Bhimavaram', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (18, N'Bhongir', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (19, N'Bobbili', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (20, N'Bodhan', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (21, N'Chilakaluripet', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (22, N'Chirala', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (23, N'Chittoor', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (24, N'Cuddapah', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (25, N'Devarakonda', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (26, N'Dharmavaram', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (27, N'Eluru', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (28, N'Farooqnagar', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (29, N'Gadwal', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (30, N'Gooty', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (31, N'Gudivada', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (32, N'Gudur', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (33, N'Guntakal', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (34, N'Guntur', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (35, N'Hanuman Junction', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (36, N'Hindupur', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (37, N'Hyderabad', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (38, N'Ichchapuram', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (39, N'Jaggaiahpet', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (40, N'Jagtial', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (41, N'Jammalamadugu', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (42, N'Jangaon', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (43, N'Kadapa', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (44, N'Kadiri', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (45, N'Kagaznagar', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (46, N'Kakinada', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (47, N'Kalyandurg', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (48, N'Kamareddy', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (49, N'Kandukur', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (50, N'Karimnagar', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (51, N'Kavali', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (52, N'Khammam', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (53, N'Koratla', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (54, N'Kothagudem', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (55, N'Kothapeta', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (56, N'Kovvur', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (57, N'Kurnool', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (58, N'Kyathampalle', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (59, N'Macherla', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (60, N'Machilipatnam', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (61, N'Madanapalle', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (62, N'Mahbubnagar', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (63, N'Mancherial', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (64, N'Mandamarri', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (65, N'Mandapeta', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (66, N'Manuguru', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (67, N'Markapur', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (68, N'Medak', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (69, N'Miryalaguda', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (70, N'Mogalthur', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (71, N'Nagari', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (72, N'Nagarkurnool', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (73, N'Nandyal', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (74, N'Narasapur', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (75, N'Narasaraopet', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (76, N'Narayanpet', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (77, N'Narsipatnam', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (78, N'Nellore', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (79, N'Nidadavole', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (80, N'Nirmal', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (81, N'Nizamabad', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (82, N'Nuzvid', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (83, N'Ongole', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (84, N'Palacole', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (85, N'Palasa Kasibugga', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (86, N'Palwancha', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (87, N'Parvathipuram', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (88, N'Pedana', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (89, N'Peddapuram', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (90, N'Pithapuram', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (91, N'Pondur', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (92, N'Ponnur', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (93, N'Proddatur', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (94, N'Punganur', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (95, N'Puttur', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (96, N'Rajahmundry', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (97, N'Rajam', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (98, N'Ramachandrapuram', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (99, N'Ramagundam', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (100, N'Rayachoti', 6, NULL)
GO
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (101, N'Rayadurg', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (102, N'Renigunta', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (103, N'Repalle', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (104, N'Sadasivpet', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (105, N'Salur', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (106, N'Samalkot', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (107, N'Sangareddy', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (108, N'Sattenapalle', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (109, N'Siddipet', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (110, N'Singapur', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (111, N'Sircilla', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (112, N'Srikakulam', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (113, N'Srikalahasti', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (115, N'Suryapet', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (116, N'Tadepalligudem', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (117, N'Tadpatri', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (118, N'Tandur', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (119, N'Tanuku', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (120, N'Tenali', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (121, N'Tirupati', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (122, N'Tuni', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (123, N'Uravakonda', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (124, N'Venkatagiri', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (125, N'Vicarabad', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (126, N'Vijayawada', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (127, N'Vinukonda', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (128, N'Visakhapatnam', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (129, N'Vizianagaram', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (130, N'Wanaparthy', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (131, N'Warangal', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (132, N'Yellandu', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (133, N'Yemmiganur', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (134, N'Yerraguntla', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (135, N'Zahirabad', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (136, N'Rajampet', 6, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (137, N'Along', 7, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (138, N'Bomdila', 7, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (139, N'Itanagar', 7, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (140, N'Naharlagun', 7, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (141, N'Pasighat', 7, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (142, N'Abhayapuri', 8, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (143, N'Amguri', 8, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (144, N'Anandnagaar', 8, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (145, N'Barpeta', 8, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (146, N'Barpeta Road', 8, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (147, N'Bilasipara', 8, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (148, N'Bongaigaon', 8, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (149, N'Dhekiajuli', 8, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (150, N'Dhubri', 8, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (151, N'Dibrugarh', 8, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (152, N'Digboi', 8, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (153, N'Diphu', 8, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (154, N'Dispur', 8, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (156, N'Gauripur', 8, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (157, N'Goalpara', 8, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (158, N'Golaghat', 8, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (159, N'Guwahati', 8, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (160, N'Haflong', 8, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (161, N'Hailakandi', 8, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (162, N'Hojai', 8, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (163, N'Jorhat', 8, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (164, N'Karimganj', 8, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (165, N'Kokrajhar', 8, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (166, N'Lanka', 8, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (167, N'Lumding', 8, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (168, N'Mangaldoi', 8, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (169, N'Mankachar', 8, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (170, N'Margherita', 8, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (171, N'Mariani', 8, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (172, N'Marigaon', 8, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (173, N'Nagaon', 8, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (174, N'Nalbari', 8, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (175, N'North Lakhimpur', 8, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (176, N'Rangia', 8, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (177, N'Sibsagar', 8, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (178, N'Silapathar', 8, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (179, N'Silchar', 8, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (180, N'Tezpur', 8, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (181, N'Tinsukia', 8, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (182, N'Amarpur', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (183, N'Araria', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (184, N'Areraj', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (185, N'Arrah', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (186, N'Asarganj', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (187, N'Aurangabad', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (188, N'Bagaha', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (189, N'Bahadurganj', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (190, N'Bairgania', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (191, N'Bakhtiarpur', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (192, N'Banka', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (193, N'Banmankhi Bazar', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (194, N'Barahiya', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (195, N'Barauli', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (196, N'Barbigha', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (197, N'Barh', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (198, N'Begusarai', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (199, N'Behea', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (200, N'Bettiah', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (201, N'Bhabua', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (202, N'Bhagalpur', 9, NULL)
GO
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (203, N'Bihar Sharif', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (204, N'Bikramganj', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (205, N'Bodh Gaya', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (206, N'Buxar', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (207, N'Chandan Bara', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (208, N'Chanpatia', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (209, N'Chhapra', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (210, N'Colgong', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (211, N'Dalsinghsarai', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (212, N'Darbhanga', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (213, N'Daudnagar', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (214, N'Dehri-on-Sone', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (215, N'Dhaka', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (216, N'Dighwara', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (217, N'Dumraon', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (218, N'Fatwah', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (219, N'Forbesganj', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (220, N'Gaya', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (221, N'Gogri Jamalpur', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (222, N'Gopalganj', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (223, N'Hajipur', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (224, N'Hilsa', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (225, N'Hisua', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (226, N'Islampur', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (227, N'Jagdispur', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (228, N'Jamalpur', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (229, N'Jamui', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (230, N'Jehanabad', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (231, N'Jhajha', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (232, N'Jhanjharpur', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (233, N'Jogabani', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (234, N'Kanti', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (235, N'Katihar', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (236, N'Khagaria', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (237, N'Kharagpur', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (238, N'Kishanganj', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (239, N'Lakhisarai', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (240, N'Lalganj', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (241, N'Madhepura', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (242, N'Madhubani', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (243, N'Maharajganj', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (244, N'Mahnar Bazar', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (245, N'Makhdumpur', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (246, N'Maner', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (247, N'Manihari', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (248, N'Marhaura', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (249, N'Masaurhi', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (250, N'Mirganj', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (251, N'Mokameh', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (252, N'Motihari', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (253, N'Motipur', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (254, N'Munger', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (255, N'Murliganj', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (256, N'Muzaffarpur', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (257, N'Narkatiaganj', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (258, N'Naugachhia', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (259, N'Nawada', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (260, N'Nokha', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (261, N'Patna', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (262, N'Piro', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (263, N'Purnia', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (264, N'Rafiganj', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (265, N'Rajgir', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (266, N'Ramnagar', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (267, N'Raxaul Bazar', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (268, N'Revelganj', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (269, N'Rosera', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (270, N'Saharsa', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (271, N'Samastipur', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (272, N'Sasaram', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (273, N'Sheikhpura', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (274, N'Sheohar', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (275, N'Sherghati', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (276, N'Silao', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (277, N'Sitamarhi', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (278, N'Siwan', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (279, N'Sonepur', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (280, N'Sugauli', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (281, N'Sultanganj', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (282, N'Supaul', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (283, N'Warisaliganj', 9, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (284, N'Ahiwara', 10, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (285, N'Akaltara', 10, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (286, N'Ambagarh Chowki', 10, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (287, N'Ambikapur', 10, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (288, N'Arang', 10, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (289, N'Bade Bacheli', 10, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (290, N'Balod', 10, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (291, N'Baloda Bazar', 10, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (292, N'Bemetra', 10, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (293, N'Bhatapara', 10, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (294, N'Bilaspur', 10, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (295, N'Birgaon', 10, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (296, N'Champa', 10, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (297, N'Chirmiri', 10, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (298, N'Dalli-Rajhara', 10, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (299, N'Dhamtari', 10, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (300, N'Dipka', 10, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (301, N'Dongargarh', 10, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (302, N'Durg-Bhilai Nagar', 10, NULL)
GO
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (303, N'Gobranawapara', 10, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (304, N'Jagdalpur', 10, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (305, N'Janjgir', 10, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (306, N'Jashpurnagar', 10, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (307, N'Kanker', 10, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (308, N'Kawardha', 10, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (309, N'Kondagaon', 10, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (310, N'Korba', 10, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (311, N'Mahasamund', 10, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (312, N'Mahendragarh', 10, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (313, N'Mungeli', 10, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (314, N'Naila Janjgir', 10, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (315, N'Raigarh', 10, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (316, N'Raipur', 10, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (317, N'Rajnandgaon', 10, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (318, N'Sakti', 10, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (319, N'Tilda Newra', 10, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (320, N'Amli', 11, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (321, N'Silvassa', 11, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (322, N'Daman and Diu', 12, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (323, N'Daman and Diu', 12, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (324, N'Asola', 13, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (325, N'Delhi', 13, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (326, N'Aldona', 14, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (327, N'Curchorem Cacora', 14, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (328, N'Madgaon', 14, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (329, N'Mapusa', 14, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (330, N'Margao', 14, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (331, N'Marmagao', 14, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (332, N'Panaji', 14, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (333, N'Ahmedabad', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (334, N'Amreli', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (335, N'Anand', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (336, N'Ankleshwar', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (337, N'Bharuch', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (338, N'Bhavnagar', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (339, N'Bhuj', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (340, N'Cambay', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (341, N'Dahod', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (342, N'Deesa', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (343, N'Dharampur', 16, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (344, N'Dholka', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (345, N'Gandhinagar', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (346, N'Godhra', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (347, N'Himatnagar', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (348, N'Idar', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (349, N'Jamnagar', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (350, N'Junagadh', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (351, N'Kadi', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (352, N'Kalavad', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (353, N'Kalol', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (354, N'Kapadvanj', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (355, N'Karjan', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (356, N'Keshod', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (357, N'Khambhalia', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (358, N'Khambhat', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (359, N'Kheda', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (360, N'Khedbrahma', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (361, N'Kheralu', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (362, N'Kodinar', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (363, N'Lathi', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (364, N'Limbdi', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (365, N'Lunawada', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (366, N'Mahesana', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (367, N'Mahuva', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (368, N'Manavadar', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (369, N'Mandvi', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (370, N'Mangrol', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (371, N'Mansa', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (372, N'Mehmedabad', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (373, N'Modasa', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (374, N'Morvi', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (375, N'Nadiad', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (376, N'Navsari', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (377, N'Padra', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (378, N'Palanpur', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (379, N'Palitana', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (380, N'Pardi', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (381, N'Patan', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (382, N'Petlad', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (383, N'Porbandar', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (384, N'Radhanpur', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (385, N'Rajkot', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (386, N'Rajpipla', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (387, N'Rajula', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (388, N'Ranavav', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (389, N'Rapar', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (390, N'Salaya', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (391, N'Sanand', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (392, N'Savarkundla', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (393, N'Sidhpur', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (394, N'Sihor', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (395, N'Songadh', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (396, N'Surat', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (397, N'Talaja', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (398, N'Thangadh', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (399, N'Tharad', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (400, N'Umbergaon', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (401, N'Umreth', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (402, N'Una', 15, NULL)
GO
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (403, N'Unjha', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (404, N'Upleta', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (405, N'Vadnagar', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (406, N'Vadodara', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (407, N'Valsad', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (408, N'Vapi', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (409, N'Vapi', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (410, N'Veraval', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (411, N'Vijapur', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (412, N'Viramgam', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (413, N'Visnagar', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (414, N'Vyara', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (415, N'Wadhwan', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (416, N'Wankaner', 15, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (417, N'Adalaj', 17, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (418, N'Adityana', 17, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (419, N'Alang', 17, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (420, N'Ambaji', 17, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (421, N'Ambaliyasan', 17, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (422, N'Andada', 17, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (423, N'Anjar', 17, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (424, N'Anklav', 17, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (425, N'Antaliya', 17, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (426, N'Arambhada', 17, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (427, N'Atul', 17, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (428, N'Ballabhgarh', 18, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (429, N'Ambala', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (430, N'Ambala', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (431, N'Asankhurd', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (432, N'Assandh', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (433, N'Ateli', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (434, N'Babiyal', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (435, N'Bahadurgarh', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (436, N'Barwala', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (437, N'Bhiwani', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (438, N'Charkhi Dadri', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (439, N'Cheeka', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (440, N'Ellenabad 2', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (441, N'Faridabad', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (442, N'Fatehabad', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (443, N'Ganaur', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (444, N'Gharaunda', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (445, N'Gohana', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (446, N'Gurgaon', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (447, N'Haibat(Yamuna Nagar)', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (448, N'Hansi', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (449, N'Hisar', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (450, N'Hodal', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (451, N'Jhajjar', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (452, N'Jind', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (453, N'Kaithal', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (454, N'Kalan Wali', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (455, N'Kalka', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (456, N'Karnal', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (457, N'Ladwa', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (458, N'Mahendragarh', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (459, N'Mandi Dabwali', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (460, N'Narnaul', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (461, N'Narwana', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (462, N'Palwal', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (463, N'Panchkula', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (464, N'Panipat', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (465, N'Pehowa', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (466, N'Pinjore', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (467, N'Rania', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (468, N'Ratia', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (469, N'Rewari', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (470, N'Rohtak', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (471, N'Safidon', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (472, N'Samalkha', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (473, N'Shahbad', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (474, N'Sirsa', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (475, N'Sohna', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (476, N'Sonipat', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (477, N'Taraori', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (478, N'Thanesar', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (479, N'Tohana', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (480, N'Yamunanagar', 19, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (481, N'Arki', 20, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (482, N'Baddi', 20, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (483, N'Bilaspur', 20, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (484, N'Chamba', 20, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (485, N'Dalhousie', 20, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (486, N'Dharamsala', 20, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (487, N'Hamirpur', 20, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (488, N'Mandi', 20, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (489, N'Nahan', 20, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (490, N'Shimla', 20, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (491, N'Solan', 20, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (492, N'Sundarnagar', 20, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (493, N'Jammu', 21, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (494, N'Achabbal', 21, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (495, N'Akhnoor', 21, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (496, N'Anantnag', 21, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (497, N'Arnia', 21, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (498, N'Awantipora', 21, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (499, N'Bandipore', 21, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (500, N'Baramula', 21, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (501, N'Kathua', 21, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (502, N'Leh', 21, NULL)
GO
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (503, N'Punch', 21, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (504, N'Rajauri', 21, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (505, N'Sopore', 21, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (506, N'Srinagar', 21, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (507, N'Udhampur', 21, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (508, N'Amlabad', 22, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (509, N'Ara', 22, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (510, N'Barughutu', 22, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (511, N'Bokaro Steel City', 22, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (512, N'Chaibasa', 22, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (513, N'Chakradharpur', 22, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (514, N'Chandrapura', 22, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (515, N'Chatra', 22, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (516, N'Chirkunda', 22, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (517, N'Churi', 22, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (518, N'Daltonganj', 22, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (519, N'Deoghar', 22, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (520, N'Dhanbad', 22, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (521, N'Dumka', 22, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (522, N'Garhwa', 22, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (523, N'Ghatshila', 22, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (524, N'Giridih', 22, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (525, N'Godda', 22, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (526, N'Gomoh', 22, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (527, N'Gumia', 22, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (528, N'Gumla', 22, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (529, N'Hazaribag', 22, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (530, N'Hussainabad', 22, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (531, N'Jamshedpur', 22, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (532, N'Jamtara', 22, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (533, N'Jhumri Tilaiya', 22, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (534, N'Khunti', 22, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (535, N'Lohardaga', 22, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (536, N'Madhupur', 22, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (537, N'Mihijam', 22, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (538, N'Musabani', 22, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (539, N'Pakaur', 22, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (540, N'Patratu', 22, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (541, N'Phusro', 22, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (542, N'Ramngarh', 22, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (543, N'Ranchi', 22, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (544, N'Sahibganj', 22, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (545, N'Saunda', 22, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (546, N'Simdega', 22, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (547, N'Tenu Dam-cum- Kathhara', 22, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (548, N'Arasikere', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (549, N'Bangalore', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (550, N'Belgaum', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (551, N'Bellary', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (552, N'Chamrajnagar', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (553, N'Chikkaballapur', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (554, N'Chintamani', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (555, N'Chitradurga', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (556, N'Gulbarga', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (557, N'Gundlupet', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (558, N'Hassan', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (559, N'Hospet', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (560, N'Hubli', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (561, N'Karkala', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (562, N'Karwar', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (563, N'Kolar', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (564, N'Kota', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (565, N'Lakshmeshwar', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (566, N'Lingsugur', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (567, N'Maddur', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (568, N'Madhugiri', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (569, N'Madikeri', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (570, N'Magadi', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (571, N'Mahalingpur', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (572, N'Malavalli', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (573, N'Malur', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (574, N'Mandya', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (575, N'Mangalore', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (576, N'Manvi', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (577, N'Mudalgi', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (578, N'Mudbidri', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (579, N'Muddebihal', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (580, N'Mudhol', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (581, N'Mulbagal', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (582, N'Mundargi', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (583, N'Mysore', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (584, N'Nanjangud', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (585, N'Pavagada', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (586, N'Puttur', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (587, N'Rabkavi Banhatti', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (588, N'Raichur', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (589, N'Ramanagaram', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (590, N'Ramdurg', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (591, N'Ranibennur', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (592, N'Robertson Pet', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (593, N'Ron', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (594, N'Sadalgi', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (595, N'Sagar', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (596, N'Sakleshpur', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (597, N'Sandur', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (598, N'Sankeshwar', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (599, N'Saundatti-Yellamma', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (600, N'Savanur', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (601, N'Sedam', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (602, N'Shahabad', 23, NULL)
GO
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (603, N'Shahpur', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (604, N'Shiggaon', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (605, N'Shikapur', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (606, N'Shimoga', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (607, N'Shorapur', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (608, N'Shrirangapattana', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (609, N'Sidlaghatta', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (610, N'Sindgi', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (611, N'Sindhnur', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (612, N'Sira', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (613, N'Sirsi', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (614, N'Siruguppa', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (615, N'Srinivaspur', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (616, N'Talikota', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (617, N'Tarikere', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (618, N'Tekkalakota', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (619, N'Terdal', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (620, N'Tiptur', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (621, N'Tumkur', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (622, N'Udupi', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (623, N'Vijayapura', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (624, N'Wadi', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (625, N'Yadgir', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (626, N'Adoor', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (627, N'Akathiyoor', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (628, N'Alappuzha', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (629, N'Ancharakandy', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (630, N'Aroor', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (631, N'Ashtamichira', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (632, N'Attingal', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (633, N'Avinissery', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (634, N'Chalakudy', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (635, N'Changanassery', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (636, N'Chendamangalam', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (637, N'Chengannur', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (638, N'Cherthala', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (639, N'Cheruthazham', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (640, N'Chittur-Thathamangalam', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (641, N'Chockli', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (642, N'Erattupetta', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (643, N'Guruvayoor', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (644, N'Irinjalakuda', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (645, N'Kadirur', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (646, N'Kalliasseri', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (647, N'Kalpetta', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (648, N'Kanhangad', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (649, N'Kanjikkuzhi', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (650, N'Kannur', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (651, N'Kasaragod', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (652, N'Kayamkulam', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (653, N'Kochi', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (654, N'Kodungallur', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (655, N'Kollam', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (656, N'Koothuparamba', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (657, N'Kothamangalam', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (658, N'Kottayam', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (659, N'Kozhikode', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (660, N'Kunnamkulam', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (661, N'Malappuram', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (662, N'Mattannur', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (663, N'Mavelikkara', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (664, N'Mavoor', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (665, N'Muvattupuzha', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (666, N'Nedumangad', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (667, N'Neyyattinkara', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (668, N'Ottappalam', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (669, N'Palai', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (670, N'Palakkad', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (671, N'Panniyannur', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (672, N'Pappinisseri', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (673, N'Paravoor', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (674, N'Pathanamthitta', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (675, N'Payyannur', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (676, N'Peringathur', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (677, N'Perinthalmanna', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (678, N'Perumbavoor', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (679, N'Ponnani', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (680, N'Punalur', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (681, N'Quilandy', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (682, N'Shoranur', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (683, N'Taliparamba', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (684, N'Thiruvalla', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (685, N'Thiruvananthapuram', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (686, N'Thodupuzha', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (687, N'Thrissur', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (688, N'Tirur', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (689, N'Vadakara', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (690, N'Vaikom', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (691, N'Varkala', 24, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (692, N'Kavaratti', 25, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (693, N'Ashok Nagar', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (694, N'Balaghat', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (695, N'Betul', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (696, N'Bhopal', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (697, N'Burhanpur', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (698, N'Chhatarpur', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (699, N'Dabra', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (700, N'Datia', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (701, N'Dewas', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (702, N'Dhar', 26, NULL)
GO
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (703, N'Fatehabad', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (704, N'Gwalior', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (705, N'Indore', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (706, N'Itarsi', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (707, N'Jabalpur', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (708, N'Katni', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (709, N'Kotma', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (710, N'Lahar', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (711, N'Lundi', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (712, N'Maharajpur', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (713, N'Mahidpur', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (714, N'Maihar', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (715, N'Malajkhand', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (716, N'Manasa', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (717, N'Manawar', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (718, N'Mandideep', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (719, N'Mandla', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (720, N'Mandsaur', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (721, N'Mauganj', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (722, N'Mhow Cantonment', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (723, N'Mhowgaon', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (724, N'Morena', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (725, N'Multai', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (726, N'Murwara', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (727, N'Nagda', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (728, N'Nainpur', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (729, N'Narsinghgarh', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (730, N'Narsinghgarh', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (731, N'Neemuch', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (732, N'Nepanagar', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (733, N'Niwari', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (734, N'Nowgong', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (735, N'Nowrozabad', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (736, N'Pachore', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (737, N'Pali', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (738, N'Panagar', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (739, N'Pandhurna', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (740, N'Panna', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (741, N'Pasan', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (742, N'Pipariya', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (743, N'Pithampur', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (744, N'Porsa', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (745, N'Prithvipur', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (746, N'Raghogarh-Vijaypur', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (747, N'Rahatgarh', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (748, N'Raisen', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (749, N'Rajgarh', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (750, N'Ratlam', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (751, N'Rau', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (752, N'Rehli', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (753, N'Rewa', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (754, N'Sabalgarh', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (755, N'Sagar', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (756, N'Sanawad', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (757, N'Sarangpur', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (758, N'Sarni', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (759, N'Satna', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (760, N'Sausar', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (761, N'Sehore', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (762, N'Sendhwa', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (763, N'Seoni', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (764, N'Seoni-Malwa', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (765, N'Shahdol', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (766, N'Shajapur', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (767, N'Shamgarh', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (768, N'Sheopur', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (769, N'Shivpuri', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (770, N'Shujalpur', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (771, N'Sidhi', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (772, N'Sihora', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (773, N'Singrauli', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (774, N'Sironj', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (775, N'Sohagpur', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (776, N'Tarana', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (777, N'Tikamgarh', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (778, N'Ujhani', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (779, N'Ujjain', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (780, N'Umaria', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (781, N'Vidisha', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (782, N'Wara Seoni', 26, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (783, N'Ahmednagar', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (784, N'Akola', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (785, N'Amravati', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (786, N'Aurangabad', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (787, N'Baramati', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (788, N'Chalisgaon', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (789, N'Chinchani', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (790, N'Devgarh', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (791, N'Dhule', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (792, N'Dombivli', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (793, N'Durgapur', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (794, N'Ichalkaranji', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (795, N'Jalna', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (796, N'Kalyan', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (797, N'Latur', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (798, N'Loha', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (799, N'Lonar', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (800, N'Lonavla', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (801, N'Mahad', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (802, N'Mahuli', 4, NULL)
GO
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (803, N'Malegaon', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (804, N'Malkapur', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (805, N'Manchar', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (806, N'Mangalvedhe', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (807, N'Mangrulpir', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (808, N'Manjlegaon', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (809, N'Manmad', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (810, N'Manwath', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (811, N'Mehkar', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (812, N'Mhaswad', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (813, N'Miraj', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (814, N'Morshi', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (815, N'Mukhed', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (816, N'Mul', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (817, N'Mumbai', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (818, N'Murtijapur', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (819, N'Nagpur', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (820, N'Nalasopara', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (821, N'Nanded-Waghala', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (822, N'Nandgaon', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (823, N'Nandura', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (824, N'Nandurbar', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (825, N'Narkhed', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (826, N'Nashik', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (827, N'Navi Mumbai', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (828, N'Nawapur', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (829, N'Nilanga', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (830, N'Osmanabad', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (831, N'Ozar', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (832, N'Pachora', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (833, N'Paithan', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (834, N'Palghar', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (835, N'Pandharkaoda', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (836, N'Pandharpur', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (837, N'Panvel', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (838, N'Parbhani', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (839, N'Parli', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (840, N'Parola', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (841, N'Partur', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (842, N'Pathardi', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (843, N'Pathri', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (844, N'Patur', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (845, N'Pauni', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (846, N'Pen', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (847, N'Phaltan', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (848, N'Pulgaon', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (849, N'Pune', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (850, N'Purna', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (851, N'Pusad', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (852, N'Rahuri', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (853, N'Rajura', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (854, N'Ramtek', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (855, N'Ratnagiri', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (856, N'Raver', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (857, N'Risod', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (858, N'Sailu', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (859, N'Sangamner', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (860, N'Sangli', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (861, N'Sangole', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (862, N'Sasvad', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (863, N'Satana', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (864, N'Satara', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (865, N'Savner', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (866, N'Sawantwadi', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (867, N'Shahade', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (868, N'Shegaon', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (869, N'Shendurjana', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (870, N'Shirdi', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (871, N'Shirpur-Warwade', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (872, N'Shirur', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (873, N'Shrigonda', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (874, N'Shrirampur', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (875, N'Sillod', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (876, N'Sinnar', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (877, N'Solapur', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (878, N'Soyagaon', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (879, N'Talegaon Dabhade', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (880, N'Talode', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (881, N'Tasgaon', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (882, N'Tirora', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (883, N'Tuljapur', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (884, N'Tumsar', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (885, N'Uran', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (886, N'Uran Islampur', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (887, N'Wadgaon Road', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (888, N'Wai', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (889, N'Wani', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (890, N'Wardha', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (891, N'Warora', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (892, N'Warud', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (893, N'Washim', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (894, N'Yevla', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (895, N'Uchgaon', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (896, N'Udgir', 4, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (897, N'Umarga', 27, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (898, N'Umarkhed', 27, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (899, N'Umred', 27, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (900, N'Vadgaon Kasba', 27, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (901, N'Vaijapur', 27, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (902, N'Vasai', 27, NULL)
GO
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (903, N'Virar', 27, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (904, N'Vita', 27, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (905, N'Yavatmal', 27, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (906, N'Yawal', 27, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (907, N'Imphal', 28, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (908, N'Kakching', 28, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (909, N'Lilong', 28, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (910, N'Mayang Imphal', 28, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (911, N'Thoubal', 28, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (912, N'Jowai', 29, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (913, N'Nongstoin', 29, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (914, N'Shillong', 29, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (915, N'Tura', 29, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (916, N'Aizawl', 30, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (917, N'Champhai', 30, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (918, N'Lunglei', 30, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (919, N'Saiha', 30, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (920, N'Dimapur', 31, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (921, N'Kohima', 31, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (922, N'Mokokchung', 31, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (923, N'Tuensang', 31, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (924, N'Wokha', 31, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (925, N'Zunheboto', 31, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (950, N'Anandapur', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (951, N'Anugul', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (952, N'Asika', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (953, N'Balangir', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (954, N'Balasore', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (955, N'Baleshwar', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (956, N'Bamra', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (957, N'Barbil', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (958, N'Bargarh', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (959, N'Bargarh', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (960, N'Baripada', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (961, N'Basudebpur', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (962, N'Belpahar', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (963, N'Bhadrak', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (964, N'Bhawanipatna', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (965, N'Bhuban', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (966, N'Bhubaneswar', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (967, N'Biramitrapur', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (968, N'Brahmapur', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (969, N'Brajrajnagar', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (970, N'Byasanagar', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (971, N'Cuttack', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (972, N'Debagarh', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (973, N'Dhenkanal', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (974, N'Gunupur', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (975, N'Hinjilicut', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (976, N'Jagatsinghapur', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (977, N'Jajapur', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (978, N'Jaleswar', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (979, N'Jatani', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (980, N'Jeypur', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (981, N'Jharsuguda', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (982, N'Joda', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (983, N'Kantabanji', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (984, N'Karanjia', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (985, N'Kendrapara', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (986, N'Kendujhar', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (987, N'Khordha', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (988, N'Koraput', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (989, N'Malkangiri', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (990, N'Nabarangapur', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (991, N'Paradip', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (992, N'Parlakhemundi', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (993, N'Pattamundai', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (994, N'Phulabani', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (995, N'Puri', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (996, N'Rairangpur', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (997, N'Rajagangapur', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (998, N'Raurkela', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (999, N'Rayagada', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1000, N'Sambalpur', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1001, N'Soro', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1002, N'Sunabeda', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1003, N'Sundargarh', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1004, N'Talcher', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1005, N'Titlagarh', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1006, N'Umarkote', 32, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1007, N'Karaikal', 33, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1008, N'Mahe', 33, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1009, N'Pondicherry', 33, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1010, N'Yanam', 33, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1011, N'Ahmedgarh', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1012, N'Amritsar', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1013, N'Barnala', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1014, N'Batala', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1015, N'Bathinda', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1016, N'Bhagha Purana', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1017, N'Budhlada', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1018, N'Chandigarh', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1019, N'Dasua', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1020, N'Dhuri', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1021, N'Dinanagar', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1022, N'Faridkot', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1023, N'Fazilka', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1024, N'Firozpur', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1025, N'Firozpur Cantt.', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1026, N'Giddarbaha', 34, NULL)
GO
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1027, N'Gobindgarh', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1028, N'Gurdaspur', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1029, N'Hoshiarpur', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1030, N'Jagraon', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1031, N'Jaitu', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1032, N'Jalalabad', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1033, N'Jalandhar', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1034, N'Jalandhar Cantt.', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1035, N'Jandiala', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1036, N'Kapurthala', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1037, N'Karoran', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1038, N'Kartarpur', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1039, N'Khanna', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1040, N'Kharar', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1041, N'Kot Kapura', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1042, N'Kurali', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1043, N'Longowal', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1044, N'Ludhiana', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1045, N'Malerkotla', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1046, N'Malout', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1047, N'Mansa', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1048, N'Maur', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1049, N'Moga', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1050, N'Mohali', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1051, N'Morinda', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1052, N'Mukerian', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1053, N'Muktsar', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1054, N'Nabha', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1055, N'Nakodar', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1056, N'Nangal', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1057, N'Nawanshahr', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1058, N'Pathankot', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1059, N'Patiala', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1060, N'Patran', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1061, N'Patti', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1062, N'Phagwara', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1063, N'Phillaur', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1064, N'Qadian', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1065, N'Raikot', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1066, N'Rajpura', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1067, N'Rampura Phul', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1068, N'Rupnagar', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1069, N'Samana', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1070, N'Sangrur', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1071, N'Sirhind Fatehgarh Sahib', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1072, N'Sujanpur', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1073, N'Sunam', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1074, N'Talwara', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1075, N'Tarn Taran', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1076, N'Urmar Tanda', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1077, N'Zira', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1078, N'Zirakpur', 34, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1079, N'Bali', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1080, N'Banswara', 36, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1081, N'Ajmer', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1082, N'Alwar', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1083, N'Bandikui', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1084, N'Baran', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1085, N'Barmer', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1086, N'Bikaner', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1087, N'Fatehpur', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1088, N'Jaipur', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1089, N'Jaisalmer', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1090, N'Jodhpur', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1091, N'Kota', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1092, N'Lachhmangarh', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1093, N'Ladnu', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1094, N'Lakheri', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1095, N'Lalsot', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1096, N'Losal', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1097, N'Makrana', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1098, N'Malpura', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1099, N'Mandalgarh', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1100, N'Mandawa', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1101, N'Mangrol', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1102, N'Merta City', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1103, N'Mount Abu', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1104, N'Nadbai', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1105, N'Nagar', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1106, N'Nagaur', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1107, N'Nargund', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1108, N'Nasirabad', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1109, N'Nathdwara', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1110, N'Navalgund', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1111, N'Nawalgarh', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1112, N'Neem-Ka-Thana', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1113, N'Nelamangala', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1114, N'Nimbahera', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1115, N'Nipani', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1116, N'Niwai', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1117, N'Nohar', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1118, N'Nokha', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1119, N'Pali', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1120, N'Phalodi', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1121, N'Phulera', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1122, N'Pilani', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1123, N'Pilibanga', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1124, N'Pindwara', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1125, N'Pipar City', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1126, N'Prantij', 35, NULL)
GO
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1127, N'Pratapgarh', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1128, N'Raisinghnagar', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1129, N'Rajakhera', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1130, N'Rajaldesar', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1131, N'Rajgarh (Alwar)', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1132, N'Rajgarh (Churu', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1133, N'Rajsamand', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1134, N'Ramganj Mandi', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1135, N'Ramngarh', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1136, N'Ratangarh', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1137, N'Rawatbhata', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1138, N'Rawatsar', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1139, N'Reengus', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1140, N'Sadri', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1141, N'Sadulshahar', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1142, N'Sagwara', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1143, N'Sambhar', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1144, N'Sanchore', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1145, N'Sangaria', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1146, N'Sardarshahar', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1147, N'Sawai Madhopur', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1148, N'Shahpura', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1149, N'Shahpura', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1150, N'Sheoganj', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1151, N'Sikar', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1152, N'Sirohi', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1153, N'Sojat', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1154, N'Sri Madhopur', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1155, N'Sujangarh', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1156, N'Sumerpur', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1157, N'Suratgarh', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1158, N'Taranagar', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1159, N'Todabhim', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1160, N'Todaraisingh', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1161, N'Tonk', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1162, N'Udaipur', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1163, N'Udaipurwati', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1164, N'Vijainagar', 35, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1165, N'Gangtok', 37, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1166, N'Calcutta', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1167, N'Arakkonam', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1168, N'Arcot', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1169, N'Aruppukkottai', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1170, N'Bhavani', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1171, N'Chengalpattu', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1172, N'Chennai', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1173, N'Chinna salem', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1174, N'Coimbatore', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1175, N'Coonoor', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1176, N'Cuddalore', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1177, N'Dharmapuri', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1178, N'Dindigul', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1179, N'Erode', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1180, N'Gudalur', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1181, N'Gudalur', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1182, N'Gudalur', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1183, N'Kanchipuram', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1184, N'Karaikudi', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1185, N'Karungal', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1186, N'Karur', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1187, N'Kollankodu', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1188, N'Lalgudi', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1189, N'Madurai', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1190, N'Nagapattinam', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1191, N'Nagercoil', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1192, N'Namagiripettai', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1193, N'Namakkal', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1194, N'Nandivaram-Guduvancheri', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1195, N'Nanjikottai', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1196, N'Natham', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1197, N'Nellikuppam', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1198, N'Neyveli', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1199, N'O Valley', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1200, N'Oddanchatram', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1201, N'P.N.Patti', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1202, N'Pacode', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1203, N'Padmanabhapuram', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1204, N'Palani', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1205, N'Palladam', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1206, N'Pallapatti', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1207, N'Pallikonda', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1208, N'Panagudi', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1209, N'Panruti', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1210, N'Paramakudi', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1211, N'Parangipettai', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1212, N'Pattukkottai', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1213, N'Perambalur', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1214, N'Peravurani', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1215, N'Periyakulam', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1216, N'Periyasemur', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1217, N'Pernampattu', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1218, N'Pollachi', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1219, N'Polur', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1220, N'Ponneri', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1221, N'Pudukkottai', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1222, N'Pudupattinam', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1223, N'Puliyankudi', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1224, N'Punjaipugalur', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1225, N'Rajapalayam', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1226, N'Ramanathapuram', 39, NULL)
GO
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1227, N'Rameshwaram', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1228, N'Rasipuram', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1229, N'Salem', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1230, N'Sankarankoil', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1231, N'Sankari', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1232, N'Sathyamangalam', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1233, N'Sattur', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1234, N'Shenkottai', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1235, N'Sholavandan', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1236, N'Sholingur', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1237, N'Sirkali', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1238, N'Sivaganga', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1239, N'Sivagiri', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1240, N'Sivakasi', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1241, N'Srivilliputhur', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1242, N'Surandai', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1243, N'Suriyampalayam', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1244, N'Tenkasi', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1245, N'Thammampatti', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1246, N'Thanjavur', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1247, N'Tharamangalam', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1248, N'Tharangambadi', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1249, N'Theni Allinagaram', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1250, N'Thirumangalam', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1251, N'Thirunindravur', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1252, N'Thiruparappu', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1253, N'Thirupuvanam', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1254, N'Thiruthuraipoondi', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1255, N'Thiruvallur', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1256, N'Thiruvarur', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1257, N'Thoothukudi', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1258, N'Thuraiyur', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1259, N'Tindivanam', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1260, N'Tiruchendur', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1261, N'Tiruchengode', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1262, N'Tiruchirappalli', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1263, N'Tirukalukundram', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1264, N'Tirukkoyilur', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1265, N'Tirunelveli', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1266, N'Tirupathur', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1267, N'Tirupathur', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1268, N'Tiruppur', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1269, N'Tiruttani', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1270, N'Tiruvannamalai', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1271, N'Tiruvethipuram', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1272, N'Tittakudi', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1273, N'Udhagamandalam', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1274, N'Udumalaipettai', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1275, N'Unnamalaikadai', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1276, N'Usilampatti', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1277, N'Uthamapalayam', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1278, N'Uthiramerur', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1279, N'Vadakkuvalliyur', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1280, N'Vadalur', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1281, N'Vadipatti', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1282, N'Valparai', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1283, N'Vandavasi', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1284, N'Vaniyambadi', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1285, N'Vedaranyam', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1286, N'Vellakoil', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1287, N'Vellore', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1288, N'Vikramasingapuram', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1289, N'Viluppuram', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1290, N'Virudhachalam', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1291, N'Virudhunagar', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1292, N'Viswanatham', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1293, N'Agartala', 40, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1294, N'Badharghat', 40, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1295, N'Dharmanagar', 40, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1296, N'Indranagar', 40, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1297, N'Jogendranagar', 40, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1298, N'Kailasahar', 40, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1299, N'Khowai', 40, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1300, N'Pratapgarh', 40, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1301, N'Udaipur', 40, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1302, N'Achhnera', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1303, N'Adari', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1304, N'Agra', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1305, N'Aligarh', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1306, N'Allahabad', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1307, N'Amroha', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1308, N'Azamgarh', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1309, N'Bahraich', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1310, N'Ballia', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1311, N'Balrampur', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1312, N'Banda', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1313, N'Bareilly', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1314, N'Chandausi', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1315, N'Dadri', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1316, N'Deoria', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1317, N'Etawah', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1318, N'Fatehabad', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1319, N'Fatehpur', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1320, N'Fatehpur', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1321, N'Greater Noida', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1322, N'Hamirpur', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1323, N'Hardoi', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1324, N'Jajmau', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1325, N'Jaunpur', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1326, N'Jhansi', 41, NULL)
GO
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1327, N'Kalpi', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1328, N'Kanpur', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1329, N'Kota', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1330, N'Laharpur', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1331, N'Lakhimpur', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1332, N'Lal Gopalganj Nindaura', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1333, N'Lalganj', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1334, N'Lalitpur', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1335, N'Lar', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1336, N'Loni', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1337, N'Lucknow', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1338, N'Mathura', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1339, N'Meerut', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1340, N'Modinagar', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1341, N'Muradnagar', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1342, N'Nagina', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1343, N'Najibabad', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1344, N'Nakur', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1345, N'Nanpara', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1346, N'Naraura', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1347, N'Naugawan Sadat', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1348, N'Nautanwa', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1349, N'Nawabganj', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1350, N'Nehtaur', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1351, N'NOIDA', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1352, N'Noorpur', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1353, N'Obra', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1354, N'Orai', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1355, N'Padrauna', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1356, N'Palia Kalan', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1357, N'Parasi', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1358, N'Phulpur', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1359, N'Pihani', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1360, N'Pilibhit', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1361, N'Pilkhuwa', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1362, N'Powayan', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1363, N'Pukhrayan', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1364, N'Puranpur', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1365, N'Purquazi', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1366, N'Purwa', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1367, N'Rae Bareli', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1368, N'Rampur', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1369, N'Rampur Maniharan', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1370, N'Rasra', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1371, N'Rath', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1372, N'Renukoot', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1373, N'Reoti', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1374, N'Robertsganj', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1375, N'Rudauli', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1376, N'Rudrapur', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1377, N'Sadabad', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1378, N'Safipur', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1379, N'Saharanpur', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1380, N'Sahaspur', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1381, N'Sahaswan', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1382, N'Sahawar', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1383, N'Sahjanwa', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1384, N'Saidpur', 42, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1385, N'Sambhal', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1386, N'Samdhan', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1387, N'Samthar', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1388, N'Sandi', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1389, N'Sandila', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1390, N'Sardhana', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1391, N'Seohara', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1392, N'Shahabad', 43, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1393, N'Shahabad', 44, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1394, N'Shahganj', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1395, N'Shahjahanpur', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1396, N'Shamli', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1397, N'Shamsabad', 45, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1398, N'Shamsabad', 46, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1399, N'Sherkot', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1400, N'Shikarpur', 47, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1401, N'Shikohabad', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1402, N'Shishgarh', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1403, N'Siana', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1404, N'Sikanderpur', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1405, N'Sikandra Rao', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1406, N'Sikandrabad', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1407, N'Sirsaganj', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1408, N'Sirsi', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1409, N'Sitapur', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1410, N'Soron', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1411, N'Suar', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1412, N'Sultanpur', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1413, N'Sumerpur', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1414, N'Tanda', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1415, N'Tanda', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1416, N'Tetri Bazar', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1417, N'Thakurdwara', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1418, N'Thana Bhawan', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1419, N'Tilhar', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1420, N'Tirwaganj', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1421, N'Tulsipur', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1422, N'Tundla', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1423, N'Unnao', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1424, N'Utraula', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1425, N'Varanasi', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1426, N'Vrindavan', 41, NULL)
GO
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1427, N'Warhapur', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1428, N'Zaidpur', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1429, N'Zamania', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1430, N'Almora', 48, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1431, N'Bazpur', 48, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1432, N'Chamba', 48, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1433, N'Dehradun', 48, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1434, N'Haldwani', 48, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1435, N'Haridwar', 48, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1436, N'Jaspur', 48, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1437, N'Kashipur', 48, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1438, N'kichha', 48, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1439, N'Kotdwara', 48, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1440, N'Manglaur', 48, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1441, N'Mussoorie', 48, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1442, N'Nagla', 48, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1443, N'Nainital', 48, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1444, N'Pauri', 48, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1445, N'Pithoragarh', 48, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1446, N'Ramnagar', 48, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1447, N'Rishikesh', 48, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1448, N'Roorkee', 48, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1449, N'Rudrapur', 48, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1450, N'Sitarganj', 48, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1451, N'Tehri', 48, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1452, N'Muzaffarnagar', 41, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1453, N'Adra', 49, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1454, N'Alipurduar', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1455, N'Arambagh', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1456, N'Asansol', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1457, N'Baharampur', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1458, N'Bally', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1459, N'Balurghat', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1460, N'Bankura', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1461, N'Barakar', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1462, N'Barasat', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1463, N'Bardhaman', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1464, N'Bidhan Nagar', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1465, N'Chinsura', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1466, N'Contai', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1467, N'Cooch Behar', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1468, N'Darjeeling', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1469, N'Durgapur', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1470, N'Haldia', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1471, N'Howrah', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1472, N'Islampur', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1473, N'Jhargram', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1474, N'Kharagpur', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1475, N'Kolkata', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1476, N'Mainaguri', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1477, N'Mal', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1478, N'Mathabhanga', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1479, N'Medinipur', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1480, N'Memari', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1481, N'Monoharpur', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1482, N'Murshidabad', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1483, N'Nabadwip', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1484, N'Naihati', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1485, N'Panchla', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1486, N'Pandua', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1487, N'Paschim Punropara', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1488, N'Purulia', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1489, N'Raghunathpur', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1490, N'Raiganj', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1491, N'Rampurhat', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1492, N'Ranaghat', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1493, N'Sainthia', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1494, N'Santipur', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1495, N'Siliguri', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1496, N'Sonamukhi', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1497, N'Srirampore', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1498, N'Suri', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1499, N'Taki', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1500, N'Tamluk', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1501, N'Tarakeswar', 38, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1502, N'Chikmagalur', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1503, N'Davanagere', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1504, N'Dharwad', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1505, N'Gadag', 23, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1506, N'Chennai', 39, NULL)
INSERT [dbo].[city] ([CityId], [CityName], [StateId], [CountryId]) VALUES (1507, N'Coimbatore', 39, NULL)
SET IDENTITY_INSERT [dbo].[Class_Master] ON 

INSERT [dbo].[Class_Master] ([Class_Id], [Class_Name], [School_Code], [School_Group_Code], [STime], [ETime]) VALUES (1, N'One', N'EC60JFWPWCVQ', NULL, NULL, NULL)
INSERT [dbo].[Class_Master] ([Class_Id], [Class_Name], [School_Code], [School_Group_Code], [STime], [ETime]) VALUES (2, N'Two', N'EC60JFWPWCVQ', NULL, NULL, NULL)
INSERT [dbo].[Class_Master] ([Class_Id], [Class_Name], [School_Code], [School_Group_Code], [STime], [ETime]) VALUES (3, N'Three', N'EC60JFWPWCVQ', NULL, NULL, NULL)
INSERT [dbo].[Class_Master] ([Class_Id], [Class_Name], [School_Code], [School_Group_Code], [STime], [ETime]) VALUES (4, N'Four', N'EC60JFWPWCVQ', NULL, NULL, NULL)
INSERT [dbo].[Class_Master] ([Class_Id], [Class_Name], [School_Code], [School_Group_Code], [STime], [ETime]) VALUES (5, N'Five', N'EC60JFWPWCVQ', NULL, NULL, NULL)
INSERT [dbo].[Class_Master] ([Class_Id], [Class_Name], [School_Code], [School_Group_Code], [STime], [ETime]) VALUES (6, N'Six', N'EC60JFWPWCVQ', NULL, NULL, NULL)
INSERT [dbo].[Class_Master] ([Class_Id], [Class_Name], [School_Code], [School_Group_Code], [STime], [ETime]) VALUES (7, N'Seven', N'EC60JFWPWCVQ', NULL, NULL, NULL)
INSERT [dbo].[Class_Master] ([Class_Id], [Class_Name], [School_Code], [School_Group_Code], [STime], [ETime]) VALUES (8, N'Eight', N'EC60JFWPWCVQ', NULL, NULL, NULL)
INSERT [dbo].[Class_Master] ([Class_Id], [Class_Name], [School_Code], [School_Group_Code], [STime], [ETime]) VALUES (9, N'Nine', N'EC60JFWPWCVQ', NULL, NULL, NULL)
INSERT [dbo].[Class_Master] ([Class_Id], [Class_Name], [School_Code], [School_Group_Code], [STime], [ETime]) VALUES (10, N'Ten', N'EC60JFWPWCVQ', NULL, NULL, NULL)
INSERT [dbo].[Class_Master] ([Class_Id], [Class_Name], [School_Code], [School_Group_Code], [STime], [ETime]) VALUES (11, N'Eleven', N'EC60JFWPWCVQ', NULL, NULL, NULL)
INSERT [dbo].[Class_Master] ([Class_Id], [Class_Name], [School_Code], [School_Group_Code], [STime], [ETime]) VALUES (12, N'Twelve', N'EC60JFWPWCVQ', NULL, NULL, NULL)
INSERT [dbo].[Class_Master] ([Class_Id], [Class_Name], [School_Code], [School_Group_Code], [STime], [ETime]) VALUES (13, N'Nursery', N'EC60JFWPWCVQ', NULL, NULL, NULL)
INSERT [dbo].[Class_Master] ([Class_Id], [Class_Name], [School_Code], [School_Group_Code], [STime], [ETime]) VALUES (14, N'Lower-KG', N'EC60JFWPWCVQ', NULL, NULL, NULL)
INSERT [dbo].[Class_Master] ([Class_Id], [Class_Name], [School_Code], [School_Group_Code], [STime], [ETime]) VALUES (15, N'Upper-KG', N'EC60JFWPWCVQ', NULL, NULL, NULL)
INSERT [dbo].[Class_Master] ([Class_Id], [Class_Name], [School_Code], [School_Group_Code], [STime], [ETime]) VALUES (18, N'KG', N'EC60JFWPWCVQ', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Class_Master] OFF
SET IDENTITY_INSERT [dbo].[country] ON 

INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (1, N'India')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (2, N'England')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (3, N'Germany')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (4, N'Afghanistan')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (5, N'Aland Islands')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (6, N'Albania')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (7, N'Algeria')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (8, N'American Samoa')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (9, N'Andorra')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (10, N'Angola')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (11, N'Anguilla')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (12, N'Antarctica')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (13, N'Antigua and Barbuda')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (14, N'Argentina')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (15, N'Armenia')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (16, N'Aruba')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (17, N'Australia')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (18, N'Austria')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (19, N'Azerbaijan')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (20, N'Bahamas')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (21, N'Bahrain')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (22, N'Bangladesh')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (23, N'Barbados')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (24, N'Belarus')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (25, N'Belgium')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (26, N'Belize')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (27, N'Benin')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (28, N'Bermuda')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (29, N'Bhutan')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (30, N'Bolivia')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (31, N'Bonaire, Sint Eustatius and Saba')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (32, N'Bosnia and Herzegovina')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (33, N'Botswana')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (34, N'Bouvet Island')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (35, N'Brazil')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (36, N'British Indian Ocean Territory')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (37, N'Brunei')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (38, N'Bulgaria')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (39, N'Burkina Faso')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (40, N'Burundi')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (41, N'Cambodia')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (42, N'Cameroon')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (43, N'Canada')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (44, N'Cape Verde')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (45, N'Cayman Islands')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (46, N'Central African Republic')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (47, N'Chad')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (48, N'Chile')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (49, N'China')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (50, N'Christmas Island')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (51, N'Cocos (Keeling) Islands')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (52, N'Colombia')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (53, N'Comoros')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (54, N'Congo')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (55, N'Cook Islands')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (56, N'Costa Rica')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (57, N'Ivory Coast')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (58, N'Croatia')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (59, N'Cuba')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (60, N'Curacao')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (61, N'Cyprus')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (62, N'Czech Republic')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (63, N'Democratic Republic of the Congo')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (64, N'Denmark')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (65, N'Djibouti')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (66, N'Dominican Republic')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (67, N'Ecuador')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (68, N'Egypt')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (69, N'El Salvador')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (70, N'Equatorial Guinea')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (71, N'Eritrea')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (72, N'Estonia')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (73, N'Ethiopia')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (74, N'Falkland Islands (Malvinas)')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (75, N'Faroe Islands')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (76, N'Fiji')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (77, N'Finland')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (78, N'France')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (79, N'French Guiana')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (80, N'French Polynesia')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (81, N'French Southern Territories')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (82, N'Gabon')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (83, N'Georgia')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (84, N'Ghana')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (85, N'Gibraltar')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (86, N'Greece')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (87, N'Greenland')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (88, N'Grenada')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (89, N'Guadaloupe')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (90, N'Guam')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (91, N'Guatemala')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (92, N'Guernsey')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (93, N'Guinea')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (94, N'Guinea-Bissau')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (95, N'Guyana')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (96, N'Haiti')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (97, N'Heard Island and McDonald Islands')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (98, N'Honduras')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (99, N'Hong Kong')
GO
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (100, N'Hungary')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (101, N'Iceland')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (102, N'Indonesia')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (103, N'Iran')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (104, N'Iraq')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (105, N'Ireland')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (106, N'Isle of Man')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (107, N'Israel')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (108, N'Italy')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (109, N'Jamaica')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (110, N'Japan')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (111, N'Jersey')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (112, N'Jordan')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (113, N'Kazakhstan')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (114, N'Kenya')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (115, N'Kiribati')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (116, N'Kosovo')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (117, N'Kuwait')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (118, N'Kyrgyzstan')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (119, N'Laos')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (120, N'Latvia')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (121, N'Lebanon')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (122, N'Lesotho')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (123, N'Liberia')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (124, N'Libya')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (125, N'Liechtenstein')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (126, N'Lithuania')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (127, N'Luxembourg')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (128, N'Macao')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (129, N'Macedonia')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (130, N'Madagascar')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (131, N'Malawi')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (132, N'Malaysia')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (133, N'Maldives')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (134, N'Mali')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (135, N'Malta')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (136, N'Marshall Islands')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (137, N'Martinique')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (138, N'Mauritania')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (139, N'Mauritius')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (140, N'Mayotte')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (141, N'Mexico')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (142, N'Micronesia')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (143, N'Moldava')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (144, N'Monaco')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (145, N'Mongolia')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (146, N'Montenegro')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (147, N'Montserrat')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (148, N'Morocco')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (149, N'Mozambique')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (150, N'Myanmar (Burma)')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (151, N'Namibia')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (152, N'Nauru')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (153, N'Nepal')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (154, N'Netherlands')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (155, N'New Caledonia')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (156, N'New Zealand')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (157, N'Nicaragua')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (158, N'Niger')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (159, N'Nigeria')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (160, N'Niue')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (161, N'Norfolk Island')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (162, N'North Korea')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (163, N'Northern Mariana Islands')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (164, N'Norway')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (165, N'Oman')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (166, N'Pakistan')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (167, N'Palau')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (168, N'Palestine')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (169, N'Panama')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (170, N'Papua New Guinea')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (171, N'Paraguay')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (172, N'Peru')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (173, N'Phillipines')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (174, N'Pitcairn')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (175, N'Poland')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (176, N'Portugal')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (177, N'Puerto Rico')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (178, N'Qatar')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (179, N'Reunion')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (180, N'Romania')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (181, N'Russia')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (182, N'Rwanda')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (183, N'Saint Barthelemy')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (184, N'Saint Helena')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (185, N'Saint Kitts and Nevis')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (186, N'Saint Lucia')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (187, N'Saint Martin')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (188, N'Saint Pierre and Miquelon')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (189, N'Saint Vincent and the Grenadines')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (190, N'Samoa')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (191, N'San Marino')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (192, N'Sao Tome and Principe')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (193, N'Saudi Arabia')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (194, N'Senegal')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (195, N'Serbia')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (196, N'Seychelles')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (197, N'Sierra Leone')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (198, N'Singapore')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (199, N'Sint Maarten')
GO
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (200, N'Slovakia')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (201, N'Slovenia')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (202, N'Solomon Islands')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (203, N'Somalia')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (204, N'South Africa')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (205, N'South Georgia and the South Sandwich Islands')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (206, N'South Korea')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (207, N'South Sudan')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (208, N'Spain')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (209, N'Sri Lanka')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (210, N'Sudan')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (211, N'Suriname')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (212, N'Svalbard and Jan Mayen')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (213, N'Swaziland')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (214, N'Sweden')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (215, N'Switzerland')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (216, N'Syria')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (217, N'Taiwan')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (218, N'Tajikistan')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (219, N'Tanzania')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (220, N'Thailand')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (221, N'Timor-Leste (East Timor)')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (222, N'Togo')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (223, N'Tokelau')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (224, N'Tonga')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (225, N'Trinidad and Tobago')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (226, N'Tunisia')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (227, N'Turkey')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (228, N'Turkmenistan')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (229, N'Turks and Caicos Islands')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (230, N'Tuvalu')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (231, N'Uganda')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (232, N'Ukraine')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (233, N'United Arab Emirates')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (234, N'United Kingdom')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (235, N'United States of America')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (236, N'United States Minor Outlying Islands')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (237, N'Uruguay')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (238, N'Uzbekistan')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (239, N'Vanuatu')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (240, N'Vatican City')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (241, N'Venezuela')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (242, N'Vietnam')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (243, N'Virgin Islands, British')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (244, N'Virgin Islands')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (245, N'Wallis and Futuna')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (246, N'Western Sahara')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (247, N'Yemen')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (248, N'Zambia')
INSERT [dbo].[country] ([CountryId], [CountryName]) VALUES (249, N'Zimbabwe')
SET IDENTITY_INSERT [dbo].[country] OFF
SET IDENTITY_INSERT [dbo].[Day] ON 

INSERT [dbo].[Day] ([Day_Id], [Day_Name]) VALUES (1, N'SUNDAY')
INSERT [dbo].[Day] ([Day_Id], [Day_Name]) VALUES (2, N'MONDAY')
INSERT [dbo].[Day] ([Day_Id], [Day_Name]) VALUES (3, N'TUESDAY')
INSERT [dbo].[Day] ([Day_Id], [Day_Name]) VALUES (4, N'WEDNESDAY')
INSERT [dbo].[Day] ([Day_Id], [Day_Name]) VALUES (5, N'THURSDAY')
INSERT [dbo].[Day] ([Day_Id], [Day_Name]) VALUES (6, N'FRIDAY')
SET IDENTITY_INSERT [dbo].[Day] OFF
SET IDENTITY_INSERT [dbo].[Event_Calendar] ON 

INSERT [dbo].[Event_Calendar] ([Event_ID], [School_Code], [School_Group_Code], [Subject], [Description], [Start_Date], [End_Date], [Theme_Color], [IS_Full_Day], [Event_Type]) VALUES (1, NULL, NULL, N'Repulic Day ', N'Office will remain close', CAST(N'2020-01-26' AS Date), CAST(N'2020-01-26' AS Date), N'Green', N'Yes', NULL)
INSERT [dbo].[Event_Calendar] ([Event_ID], [School_Code], [School_Group_Code], [Subject], [Description], [Start_Date], [End_Date], [Theme_Color], [IS_Full_Day], [Event_Type]) VALUES (2, NULL, NULL, N'Parent Meeting', N'Parent Should come School ', CAST(N'2020-01-27' AS Date), CAST(N'2020-01-27' AS Date), N'Blue', N'No', NULL)
INSERT [dbo].[Event_Calendar] ([Event_ID], [School_Code], [School_Group_Code], [Subject], [Description], [Start_Date], [End_Date], [Theme_Color], [IS_Full_Day], [Event_Type]) VALUES (3, NULL, NULL, N'Sports', N'Student Yearly Sport will be held', CAST(N'2020-01-28' AS Date), CAST(N'2020-01-28' AS Date), N'Blue', N'No', NULL)
INSERT [dbo].[Event_Calendar] ([Event_ID], [School_Code], [School_Group_Code], [Subject], [Description], [Start_Date], [End_Date], [Theme_Color], [IS_Full_Day], [Event_Type]) VALUES (4, NULL, NULL, N'Grand Parent Days', N'This day we celebrate grand Parent Day', CAST(N'2020-01-01' AS Date), CAST(N'2020-01-02' AS Date), N'Green', N'No', NULL)
INSERT [dbo].[Event_Calendar] ([Event_ID], [School_Code], [School_Group_Code], [Subject], [Description], [Start_Date], [End_Date], [Theme_Color], [IS_Full_Day], [Event_Type]) VALUES (7, N'EC60JFWPWCVQ', N'400', N'Durga', N'durga', CAST(N'2020-03-21' AS Date), CAST(N'2020-03-31' AS Date), N'white', N'full DAY', N'Holiday')
INSERT [dbo].[Event_Calendar] ([Event_ID], [School_Code], [School_Group_Code], [Subject], [Description], [Start_Date], [End_Date], [Theme_Color], [IS_Full_Day], [Event_Type]) VALUES (6, N'EC60JFWPWCVQ', N'400', N'Anual Sports', N'Annual Sport will be held in our  school premises', CAST(N'2020-03-18' AS Date), CAST(N'2020-03-20' AS Date), N'yellow', N'full day', N'Event')
INSERT [dbo].[Event_Calendar] ([Event_ID], [School_Code], [School_Group_Code], [Subject], [Description], [Start_Date], [End_Date], [Theme_Color], [IS_Full_Day], [Event_Type]) VALUES (9, N'EC60JFWPWCVQ', N'400', N'Parent Meeting', N'meeting', CAST(N'2020-03-18' AS Date), CAST(N'2020-03-18' AS Date), N'yellow', N'full day', N'Event')
INSERT [dbo].[Event_Calendar] ([Event_ID], [School_Code], [School_Group_Code], [Subject], [Description], [Start_Date], [End_Date], [Theme_Color], [IS_Full_Day], [Event_Type]) VALUES (10, N'EC60JFWPWCVQ', N'400', N'Parent Meeting', N'meeting meeting', CAST(N'2020-03-18' AS Date), CAST(N'2020-03-18' AS Date), N'yellow', N'full day', N'Event')
INSERT [dbo].[Event_Calendar] ([Event_ID], [School_Code], [School_Group_Code], [Subject], [Description], [Start_Date], [End_Date], [Theme_Color], [IS_Full_Day], [Event_Type]) VALUES (11, N'EC60JFWPWCVQ', N'400', N'Parent Meeting4', N'descriptionns', CAST(N'2020-03-18' AS Date), CAST(N'2020-03-18' AS Date), N'yellow', N'half day', N'Event')
INSERT [dbo].[Event_Calendar] ([Event_ID], [School_Code], [School_Group_Code], [Subject], [Description], [Start_Date], [End_Date], [Theme_Color], [IS_Full_Day], [Event_Type]) VALUES (12, N'EC60JFWPWCVQ', N'400', N'Parent Meeting4 trtrt shjsjsj', N'description fdrerer fgfgfg', CAST(N'2020-03-18' AS Date), CAST(N'2020-03-18' AS Date), N'yellow', N'half day', N'Event')
INSERT [dbo].[Event_Calendar] ([Event_ID], [School_Code], [School_Group_Code], [Subject], [Description], [Start_Date], [End_Date], [Theme_Color], [IS_Full_Day], [Event_Type]) VALUES (13, N'EC60JFWPWCVQ', N'400', N'Parent Meeting5', N'descrioption', CAST(N'2020-03-18' AS Date), CAST(N'2020-03-18' AS Date), N'yellow', N'half day', N'Event')
INSERT [dbo].[Event_Calendar] ([Event_ID], [School_Code], [School_Group_Code], [Subject], [Description], [Start_Date], [End_Date], [Theme_Color], [IS_Full_Day], [Event_Type]) VALUES (14, N'EC60JFWPWCVQ', N'400', N'Parent Meeting6', N'descrioption3', CAST(N'2020-03-18' AS Date), CAST(N'2020-03-18' AS Date), N'yellow', N'half day', N'Event')
INSERT [dbo].[Event_Calendar] ([Event_ID], [School_Code], [School_Group_Code], [Subject], [Description], [Start_Date], [End_Date], [Theme_Color], [IS_Full_Day], [Event_Type]) VALUES (15, N'EC60JFWPWCVQ', N'400', N'Parent Meeting7', N'descrioption77', CAST(N'2020-03-18' AS Date), CAST(N'2020-03-18' AS Date), N'yellow', N'half day', N'Event')
INSERT [dbo].[Event_Calendar] ([Event_ID], [School_Code], [School_Group_Code], [Subject], [Description], [Start_Date], [End_Date], [Theme_Color], [IS_Full_Day], [Event_Type]) VALUES (16, N'EC60JFWPWCVQ', N'400', N'Parent Meeting8', N'descrioption8', CAST(N'2020-03-18' AS Date), CAST(N'2020-03-18' AS Date), N'yellow', N'half day', N'Event')
INSERT [dbo].[Event_Calendar] ([Event_ID], [School_Code], [School_Group_Code], [Subject], [Description], [Start_Date], [End_Date], [Theme_Color], [IS_Full_Day], [Event_Type]) VALUES (17, N'EC60JFWPWCVQ', N'400', N'Parent Meeting9', N'descrioption9', CAST(N'2020-03-18' AS Date), CAST(N'2020-03-18' AS Date), N'yellow', N'half day', N'Event')
SET IDENTITY_INSERT [dbo].[Event_Calendar] OFF
SET IDENTITY_INSERT [dbo].[Exam_Schedule] ON 

INSERT [dbo].[Exam_Schedule] ([ExamSchedule_Id], [ExamTerm_Id], [Year], [School_Code], [School_Id], [Class_Id], [Section_Id], [Subject_Id], [Exam_Subject_Type], [Day_Id], [Exam_Day], [Exam_Date], [Start_Time], [End_Time]) VALUES (3, 2, N'2018', N'EC60JFWPWCVQ', 2, 12, 2, 1, NULL, 3, NULL, N'27/04/2019', N'12:30', N'15:00')
INSERT [dbo].[Exam_Schedule] ([ExamSchedule_Id], [ExamTerm_Id], [Year], [School_Code], [School_Id], [Class_Id], [Section_Id], [Subject_Id], [Exam_Subject_Type], [Day_Id], [Exam_Day], [Exam_Date], [Start_Time], [End_Time]) VALUES (4, 1, N'2018', N'EC60JFWPWCVQ', 2, 12, 1, 1, NULL, 5, NULL, N'29/04/2019', N'15:30', N'17:30')
INSERT [dbo].[Exam_Schedule] ([ExamSchedule_Id], [ExamTerm_Id], [Year], [School_Code], [School_Id], [Class_Id], [Section_Id], [Subject_Id], [Exam_Subject_Type], [Day_Id], [Exam_Day], [Exam_Date], [Start_Time], [End_Time]) VALUES (5, 1, N'1981', N'EC60JFWPWCVQ', 2, 12, 1, 4, NULL, 3, NULL, N'26/04/2019', N'14:30', N'15:30')
INSERT [dbo].[Exam_Schedule] ([ExamSchedule_Id], [ExamTerm_Id], [Year], [School_Code], [School_Id], [Class_Id], [Section_Id], [Subject_Id], [Exam_Subject_Type], [Day_Id], [Exam_Day], [Exam_Date], [Start_Time], [End_Time]) VALUES (6, 2, N'2018', N'EC60JFWPWCVQ', 2, 12, 2, 2, NULL, 3, NULL, N'27/04/2019', N'12:30', N'13:03')
INSERT [dbo].[Exam_Schedule] ([ExamSchedule_Id], [ExamTerm_Id], [Year], [School_Code], [School_Id], [Class_Id], [Section_Id], [Subject_Id], [Exam_Subject_Type], [Day_Id], [Exam_Day], [Exam_Date], [Start_Time], [End_Time]) VALUES (8, 1, N'2019', N'EC60JFWPWCVQ', 2, 2, 1, 2, NULL, 3, NULL, N'08/01/2020', N'06:05', N'09:09')
INSERT [dbo].[Exam_Schedule] ([ExamSchedule_Id], [ExamTerm_Id], [Year], [School_Code], [School_Id], [Class_Id], [Section_Id], [Subject_Id], [Exam_Subject_Type], [Day_Id], [Exam_Day], [Exam_Date], [Start_Time], [End_Time]) VALUES (9, 1, N'2019', N'EC60JFWPWCVQ', 2, 12, 1, 1, NULL, 2, NULL, N'29/01/2020', N'11:30', N'12:30')
INSERT [dbo].[Exam_Schedule] ([ExamSchedule_Id], [ExamTerm_Id], [Year], [School_Code], [School_Id], [Class_Id], [Section_Id], [Subject_Id], [Exam_Subject_Type], [Day_Id], [Exam_Day], [Exam_Date], [Start_Time], [End_Time]) VALUES (10, 1, N'2019', N'EC60JFWPWCVQ', 2, 12, 1, 2, NULL, 3, NULL, N'2020-01-10', N'12:12', N'01:20')
INSERT [dbo].[Exam_Schedule] ([ExamSchedule_Id], [ExamTerm_Id], [Year], [School_Code], [School_Id], [Class_Id], [Section_Id], [Subject_Id], [Exam_Subject_Type], [Day_Id], [Exam_Day], [Exam_Date], [Start_Time], [End_Time]) VALUES (11, 1, N'2019', N'EC60JFWPWCVQ', 2, 12, 1, 3, NULL, 4, NULL, N'29/01/2020', N'11:30', N'12:30')
INSERT [dbo].[Exam_Schedule] ([ExamSchedule_Id], [ExamTerm_Id], [Year], [School_Code], [School_Id], [Class_Id], [Section_Id], [Subject_Id], [Exam_Subject_Type], [Day_Id], [Exam_Day], [Exam_Date], [Start_Time], [End_Time]) VALUES (12, 1, N'2019', N'EC60JFWPWCVQ', 2, 12, 1, 4, NULL, 5, NULL, N'2020-02-15', N'11:30', N'04:20')
INSERT [dbo].[Exam_Schedule] ([ExamSchedule_Id], [ExamTerm_Id], [Year], [School_Code], [School_Id], [Class_Id], [Section_Id], [Subject_Id], [Exam_Subject_Type], [Day_Id], [Exam_Day], [Exam_Date], [Start_Time], [End_Time]) VALUES (13, 1, N'2019', N'EC60JFWPWCVQ', 2, 12, 1, 5, NULL, 5, NULL, N'2020-02-29', N'12:30', N'15:30')
INSERT [dbo].[Exam_Schedule] ([ExamSchedule_Id], [ExamTerm_Id], [Year], [School_Code], [School_Id], [Class_Id], [Section_Id], [Subject_Id], [Exam_Subject_Type], [Day_Id], [Exam_Day], [Exam_Date], [Start_Time], [End_Time]) VALUES (14, 1, N'2019', N'EC60JFWPWCVQ', 2, 12, 1, 6, NULL, 6, NULL, N'2010-2-9', N'11:30', N'12:30')
INSERT [dbo].[Exam_Schedule] ([ExamSchedule_Id], [ExamTerm_Id], [Year], [School_Code], [School_Id], [Class_Id], [Section_Id], [Subject_Id], [Exam_Subject_Type], [Day_Id], [Exam_Day], [Exam_Date], [Start_Time], [End_Time]) VALUES (15, 2, N'2020', N'EC60JFWPWCVQ', 2, 5, 1, 17, N'Theory', 0, NULL, N'23/01/2020', N'11.30', N'12.30')
INSERT [dbo].[Exam_Schedule] ([ExamSchedule_Id], [ExamTerm_Id], [Year], [School_Code], [School_Id], [Class_Id], [Section_Id], [Subject_Id], [Exam_Subject_Type], [Day_Id], [Exam_Day], [Exam_Date], [Start_Time], [End_Time]) VALUES (16, 2, N'2020', N'EC60JFWPWCVQ', 2, 3, 1, 14, N'Practical', 0, NULL, N'17/01/2020', N'10.00', N'11.00')
INSERT [dbo].[Exam_Schedule] ([ExamSchedule_Id], [ExamTerm_Id], [Year], [School_Code], [School_Id], [Class_Id], [Section_Id], [Subject_Id], [Exam_Subject_Type], [Day_Id], [Exam_Day], [Exam_Date], [Start_Time], [End_Time]) VALUES (1015, 2, N'2020', N'EC60JFWPWCVQ', 2, 8, 1, 17, N'Theory', 0, NULL, N'2020-02-19', N'12.00', N'13.00')
INSERT [dbo].[Exam_Schedule] ([ExamSchedule_Id], [ExamTerm_Id], [Year], [School_Code], [School_Id], [Class_Id], [Section_Id], [Subject_Id], [Exam_Subject_Type], [Day_Id], [Exam_Day], [Exam_Date], [Start_Time], [End_Time]) VALUES (1016, 1, N'2020', N'EC60JFWPWCVQ', 2, 8, 1, 15, N'Practical', 0, NULL, N'2020-02-26', N'10:00', N'12:00')
INSERT [dbo].[Exam_Schedule] ([ExamSchedule_Id], [ExamTerm_Id], [Year], [School_Code], [School_Id], [Class_Id], [Section_Id], [Subject_Id], [Exam_Subject_Type], [Day_Id], [Exam_Day], [Exam_Date], [Start_Time], [End_Time]) VALUES (1017, 2, N'2020', N'EC60JFWPWCVQ', 2, 8, 1, 14, N'Practical', 0, NULL, N'2020-02-28', N'14.00', N'16.00')
INSERT [dbo].[Exam_Schedule] ([ExamSchedule_Id], [ExamTerm_Id], [Year], [School_Code], [School_Id], [Class_Id], [Section_Id], [Subject_Id], [Exam_Subject_Type], [Day_Id], [Exam_Day], [Exam_Date], [Start_Time], [End_Time]) VALUES (1018, 1, N'2020', N'EC60JFWPWCVQ', 2, 8, 1, 16, N'Practical', 0, NULL, N'2020-01-28', N'02:00', N'03:00')
INSERT [dbo].[Exam_Schedule] ([ExamSchedule_Id], [ExamTerm_Id], [Year], [School_Code], [School_Id], [Class_Id], [Section_Id], [Subject_Id], [Exam_Subject_Type], [Day_Id], [Exam_Day], [Exam_Date], [Start_Time], [End_Time]) VALUES (1019, 3, N'2020', N'EC60JFWPWCVQ', 2, 10, 1, 3, N'Practical', 0, NULL, N'2020-03-15', N'10.30', N'11.30')
INSERT [dbo].[Exam_Schedule] ([ExamSchedule_Id], [ExamTerm_Id], [Year], [School_Code], [School_Id], [Class_Id], [Section_Id], [Subject_Id], [Exam_Subject_Type], [Day_Id], [Exam_Day], [Exam_Date], [Start_Time], [End_Time]) VALUES (1020, 3, N'2020', N'EC60JFWPWCVQ', 2, 10, 1, 1, N'Theory', 0, NULL, N'2020-03-16', N'10.45', N'11.45')
INSERT [dbo].[Exam_Schedule] ([ExamSchedule_Id], [ExamTerm_Id], [Year], [School_Code], [School_Id], [Class_Id], [Section_Id], [Subject_Id], [Exam_Subject_Type], [Day_Id], [Exam_Day], [Exam_Date], [Start_Time], [End_Time]) VALUES (1021, 3, N'2020', N'EC60JFWPWCVQ', 2, 10, 1, 4, N'Theory', 0, NULL, N'2020-03-18', N'10.30', N'11.30')
INSERT [dbo].[Exam_Schedule] ([ExamSchedule_Id], [ExamTerm_Id], [Year], [School_Code], [School_Id], [Class_Id], [Section_Id], [Subject_Id], [Exam_Subject_Type], [Day_Id], [Exam_Day], [Exam_Date], [Start_Time], [End_Time]) VALUES (1022, 3, N'2020', N'EC60JFWPWCVQ', 2, 10, 1, 15, N'Practical', 0, NULL, N'2020-03-19', N'10.30', N'11.30')
INSERT [dbo].[Exam_Schedule] ([ExamSchedule_Id], [ExamTerm_Id], [Year], [School_Code], [School_Id], [Class_Id], [Section_Id], [Subject_Id], [Exam_Subject_Type], [Day_Id], [Exam_Day], [Exam_Date], [Start_Time], [End_Time]) VALUES (1023, 3, N'2020', N'EC60JFWPWCVQ', 2, 10, 1, 10, N'Theory', 0, NULL, N'2020-03-20', N'11.30', N'12.30')
INSERT [dbo].[Exam_Schedule] ([ExamSchedule_Id], [ExamTerm_Id], [Year], [School_Code], [School_Id], [Class_Id], [Section_Id], [Subject_Id], [Exam_Subject_Type], [Day_Id], [Exam_Day], [Exam_Date], [Start_Time], [End_Time]) VALUES (1028, 2, N'2020', N'EC60JFWPWCVQ', 2, 10, 1, 8, N'Theory', 0, NULL, N'2020-03-19', N'11.00', N'11.30')
INSERT [dbo].[Exam_Schedule] ([ExamSchedule_Id], [ExamTerm_Id], [Year], [School_Code], [School_Id], [Class_Id], [Section_Id], [Subject_Id], [Exam_Subject_Type], [Day_Id], [Exam_Day], [Exam_Date], [Start_Time], [End_Time]) VALUES (1029, 2, N'2020', N'EC60JFWPWCVQ', 2, 10, 2, 10, N'Theory', 0, NULL, N'2020-03-20', N'12.00', N'12.30')
INSERT [dbo].[Exam_Schedule] ([ExamSchedule_Id], [ExamTerm_Id], [Year], [School_Code], [School_Id], [Class_Id], [Section_Id], [Subject_Id], [Exam_Subject_Type], [Day_Id], [Exam_Day], [Exam_Date], [Start_Time], [End_Time]) VALUES (1030, 2, N'2020', N'EC60JFWPWCVQ', 2, 10, 2, 15, N'Practical', 0, NULL, N'2020-03-19', N'11', N'12')
INSERT [dbo].[Exam_Schedule] ([ExamSchedule_Id], [ExamTerm_Id], [Year], [School_Code], [School_Id], [Class_Id], [Section_Id], [Subject_Id], [Exam_Subject_Type], [Day_Id], [Exam_Day], [Exam_Date], [Start_Time], [End_Time]) VALUES (1031, 3, N'2020', N'EC60JFWPWCVQ', 2, 11, 3, 8, N'Theory', 0, NULL, N'2020-03-25', N'12', N'13')
INSERT [dbo].[Exam_Schedule] ([ExamSchedule_Id], [ExamTerm_Id], [Year], [School_Code], [School_Id], [Class_Id], [Section_Id], [Subject_Id], [Exam_Subject_Type], [Day_Id], [Exam_Day], [Exam_Date], [Start_Time], [End_Time]) VALUES (1032, 3, N'2013', N'EC60JFWPWCVQ', 2, 3, 3, 6, N'Theory', 0, NULL, N'2020-03-24', N'dsfd', N'WEWEW')
INSERT [dbo].[Exam_Schedule] ([ExamSchedule_Id], [ExamTerm_Id], [Year], [School_Code], [School_Id], [Class_Id], [Section_Id], [Subject_Id], [Exam_Subject_Type], [Day_Id], [Exam_Day], [Exam_Date], [Start_Time], [End_Time]) VALUES (1033, 5, N'2020', N'EC60JFWPWCVQ', 2, 8, 3, 7, N'Theory', 0, NULL, N'2020-03-23', N'WREWRE', N'SFSFDF')
INSERT [dbo].[Exam_Schedule] ([ExamSchedule_Id], [ExamTerm_Id], [Year], [School_Code], [School_Id], [Class_Id], [Section_Id], [Subject_Id], [Exam_Subject_Type], [Day_Id], [Exam_Day], [Exam_Date], [Start_Time], [End_Time]) VALUES (1034, 3, N'2020', N'EC60JFWPWCVQ', 2, 7, 3, 6, N'Theory', 0, NULL, N'2020-03-19', N'TRRR', N'RRRR')
INSERT [dbo].[Exam_Schedule] ([ExamSchedule_Id], [ExamTerm_Id], [Year], [School_Code], [School_Id], [Class_Id], [Section_Id], [Subject_Id], [Exam_Subject_Type], [Day_Id], [Exam_Day], [Exam_Date], [Start_Time], [End_Time]) VALUES (1035, 2, N'2020', N'EC60JFWPWCVQ', 2, 10, 2, 10, N'Theory', 0, NULL, N'2020-03-25', N'12', N'14')
INSERT [dbo].[Exam_Schedule] ([ExamSchedule_Id], [ExamTerm_Id], [Year], [School_Code], [School_Id], [Class_Id], [Section_Id], [Subject_Id], [Exam_Subject_Type], [Day_Id], [Exam_Day], [Exam_Date], [Start_Time], [End_Time]) VALUES (1036, 1, N'2020', N'EC60JFWPWCVQ', 2, 10, 1, 1, N'Theory', 0, NULL, N'2020-03-19', N'11', N'12')
INSERT [dbo].[Exam_Schedule] ([ExamSchedule_Id], [ExamTerm_Id], [Year], [School_Code], [School_Id], [Class_Id], [Section_Id], [Subject_Id], [Exam_Subject_Type], [Day_Id], [Exam_Day], [Exam_Date], [Start_Time], [End_Time]) VALUES (1037, 1, N'2020', N'EC60JFWPWCVQ', 2, 10, 1, 2, N'Theory', 0, NULL, N'2020-03-19', N'11', N'12')
INSERT [dbo].[Exam_Schedule] ([ExamSchedule_Id], [ExamTerm_Id], [Year], [School_Code], [School_Id], [Class_Id], [Section_Id], [Subject_Id], [Exam_Subject_Type], [Day_Id], [Exam_Day], [Exam_Date], [Start_Time], [End_Time]) VALUES (1038, 1, N'2020', N'EC60JFWPWCVQ', 2, 10, 1, 4, N'Theory', 0, NULL, N'2020-03-20', N'11', N'12')
INSERT [dbo].[Exam_Schedule] ([ExamSchedule_Id], [ExamTerm_Id], [Year], [School_Code], [School_Id], [Class_Id], [Section_Id], [Subject_Id], [Exam_Subject_Type], [Day_Id], [Exam_Day], [Exam_Date], [Start_Time], [End_Time]) VALUES (1024, 6, N'2020', N'EC60JFWPWCVQ', 2, 10, 2, 1, N'Theory', 0, NULL, N'2020-03-14', N'10', N'11')
INSERT [dbo].[Exam_Schedule] ([ExamSchedule_Id], [ExamTerm_Id], [Year], [School_Code], [School_Id], [Class_Id], [Section_Id], [Subject_Id], [Exam_Subject_Type], [Day_Id], [Exam_Day], [Exam_Date], [Start_Time], [End_Time]) VALUES (1025, 6, N'2020', N'EC60JFWPWCVQ', 2, 10, 1, 1015, N'Practical', 0, NULL, N'2020-03-19', N'12', N'12.30')
INSERT [dbo].[Exam_Schedule] ([ExamSchedule_Id], [ExamTerm_Id], [Year], [School_Code], [School_Id], [Class_Id], [Section_Id], [Subject_Id], [Exam_Subject_Type], [Day_Id], [Exam_Day], [Exam_Date], [Start_Time], [End_Time]) VALUES (1026, 6, N'2020', N'EC60JFWPWCVQ', 2, 10, 1, 1018, N'Theory', 0, NULL, N'2020-03-19', N'12', N'13')
INSERT [dbo].[Exam_Schedule] ([ExamSchedule_Id], [ExamTerm_Id], [Year], [School_Code], [School_Id], [Class_Id], [Section_Id], [Subject_Id], [Exam_Subject_Type], [Day_Id], [Exam_Day], [Exam_Date], [Start_Time], [End_Time]) VALUES (1027, 6, N'2020', N'EC60JFWPWCVQ', 2, 10, 1, 1016, N'Practical', 0, NULL, N'2020-03-27', N'14', N'15')
SET IDENTITY_INSERT [dbo].[Exam_Schedule] OFF
SET IDENTITY_INSERT [dbo].[IdProof_Master] ON 

INSERT [dbo].[IdProof_Master] ([IdProof_Id], [IdProof_Name]) VALUES (1, N'PAN CARD')
INSERT [dbo].[IdProof_Master] ([IdProof_Id], [IdProof_Name]) VALUES (2, N'ADHAR CARD')
INSERT [dbo].[IdProof_Master] ([IdProof_Id], [IdProof_Name]) VALUES (3, N'DRIVING LICENCE')
INSERT [dbo].[IdProof_Master] ([IdProof_Id], [IdProof_Name]) VALUES (4, N'VOTER-ID CARD')
INSERT [dbo].[IdProof_Master] ([IdProof_Id], [IdProof_Name]) VALUES (5, N'RATION CARD')
INSERT [dbo].[IdProof_Master] ([IdProof_Id], [IdProof_Name]) VALUES (6, N'Not Avaliable')
SET IDENTITY_INSERT [dbo].[IdProof_Master] OFF
SET IDENTITY_INSERT [dbo].[Note_Type_Master] ON 

INSERT [dbo].[Note_Type_Master] ([Note_Type_Id], [Note_Type_Name]) VALUES (1, N'Critical')
INSERT [dbo].[Note_Type_Master] ([Note_Type_Id], [Note_Type_Name]) VALUES (2, N'General')
SET IDENTITY_INSERT [dbo].[Note_Type_Master] OFF
SET IDENTITY_INSERT [dbo].[ParentRegistration] ON 

INSERT [dbo].[ParentRegistration] ([ParentID], [School_Code], [ParentName], [ParentContact], [ParentEmail], [ParentPassword], [ParentOTP], [OTPActiveStatus]) VALUES (16, N'JKIUR8CSCJZ1', N'Prasenjit Saha', N'8013437503', N'prasenjit2005@gmail.com', N'Marine@1', NULL, NULL)
INSERT [dbo].[ParentRegistration] ([ParentID], [School_Code], [ParentName], [ParentContact], [ParentEmail], [ParentPassword], [ParentOTP], [OTPActiveStatus]) VALUES (17, N'JKIUR8CSCJZ1', N'Shankha  Chatterjee', N'8013437504', N'sahaniloy24@gmail.com', N'Marine@90', NULL, NULL)
INSERT [dbo].[ParentRegistration] ([ParentID], [School_Code], [ParentName], [ParentContact], [ParentEmail], [ParentPassword], [ParentOTP], [OTPActiveStatus]) VALUES (18, N'JKIUR8CSCJZ1', N'sahaniloy24@gmail.com', N'1234567891', N'niloy@protistatech.com', N'Marine@0', NULL, NULL)
INSERT [dbo].[ParentRegistration] ([ParentID], [School_Code], [ParentName], [ParentContact], [ParentEmail], [ParentPassword], [ParentOTP], [OTPActiveStatus]) VALUES (19, N'HZXFDMKHFTK7', N'Animesh Kanjilal', N'123456789', N'niloy@protistatech.com', N'Marine@0', NULL, NULL)
INSERT [dbo].[ParentRegistration] ([ParentID], [School_Code], [ParentName], [ParentContact], [ParentEmail], [ParentPassword], [ParentOTP], [OTPActiveStatus]) VALUES (1018, N'E3TQTHFGNEFI', N'Animesh Kanjilal', N'1234567890', N'sahaniloy24@gmail.com', N'Marine@0', NULL, NULL)
INSERT [dbo].[ParentRegistration] ([ParentID], [School_Code], [ParentName], [ParentContact], [ParentEmail], [ParentPassword], [ParentOTP], [OTPActiveStatus]) VALUES (2018, N'EC60JFWPWCVQ', N'Niloy', N'1234789123', N'sahaniloy90@gmail.com', N'Marine@0', NULL, NULL)
INSERT [dbo].[ParentRegistration] ([ParentID], [School_Code], [ParentName], [ParentContact], [ParentEmail], [ParentPassword], [ParentOTP], [OTPActiveStatus]) VALUES (2019, N'057KLZQ6Q68F', N'palash Kar', N'1234567890', N'palash@gmail.com', N'Marine@0', NULL, NULL)
INSERT [dbo].[ParentRegistration] ([ParentID], [School_Code], [ParentName], [ParentContact], [ParentEmail], [ParentPassword], [ParentOTP], [OTPActiveStatus]) VALUES (2020, N'ZVX5OGG335O4', N'animesh11@gmail.com', N'1234567890', N'animesh11@gmail.com', N'Marine@1', NULL, NULL)
INSERT [dbo].[ParentRegistration] ([ParentID], [School_Code], [ParentName], [ParentContact], [ParentEmail], [ParentPassword], [ParentOTP], [OTPActiveStatus]) VALUES (2021, N'ZVX5OGG335O4', N'sukk@gmail.com', N'1234567899', N'sukk@gmail.com', N'Marine@1', NULL, NULL)
INSERT [dbo].[ParentRegistration] ([ParentID], [School_Code], [ParentName], [ParentContact], [ParentEmail], [ParentPassword], [ParentOTP], [OTPActiveStatus]) VALUES (2022, N'E3TQTHFGNEFI', N'test20', N'0898234546', N'test20@gmail.com', N'Marine@1', NULL, NULL)
INSERT [dbo].[ParentRegistration] ([ParentID], [School_Code], [ParentName], [ParentContact], [ParentEmail], [ParentPassword], [ParentOTP], [OTPActiveStatus]) VALUES (2023, N'E3TQTHFGNEFI', N'test20', N'0898234546', N'test20@gmail.com', N'Marine@1', NULL, NULL)
INSERT [dbo].[ParentRegistration] ([ParentID], [School_Code], [ParentName], [ParentContact], [ParentEmail], [ParentPassword], [ParentOTP], [OTPActiveStatus]) VALUES (2024, N'E3TQTHFGNEFI', N'test20', N'0898234546', N'parenttest20@gmail.com', N'Marine@1', NULL, NULL)
SET IDENTITY_INSERT [dbo].[ParentRegistration] OFF
SET IDENTITY_INSERT [dbo].[Performance_Report] ON 

INSERT [dbo].[Performance_Report] ([ID], [School_Code], [Parent_ID], [Student_ID], [Exam_ID], [Subject_ID], [Class_ID], [Marks], [Date_Exam], [Session]) VALUES (1, N'EC60JFWPWCVQ', 2018, 2027, 13, 1, 1, CAST(69.00 AS Decimal(6, 2)), CAST(N'2019-01-01' AS Date), N'2019-20')
INSERT [dbo].[Performance_Report] ([ID], [School_Code], [Parent_ID], [Student_ID], [Exam_ID], [Subject_ID], [Class_ID], [Marks], [Date_Exam], [Session]) VALUES (2, N'EC60JFWPWCVQ', 2018, 2027, 13, 2, 1, CAST(80.00 AS Decimal(6, 2)), CAST(N'2019-01-02' AS Date), N'2019-20')
INSERT [dbo].[Performance_Report] ([ID], [School_Code], [Parent_ID], [Student_ID], [Exam_ID], [Subject_ID], [Class_ID], [Marks], [Date_Exam], [Session]) VALUES (3, N'EC60JFWPWCVQ', 2018, 2027, 13, 3, 1, CAST(56.00 AS Decimal(6, 2)), CAST(N'2019-01-03' AS Date), N'2019-20')
INSERT [dbo].[Performance_Report] ([ID], [School_Code], [Parent_ID], [Student_ID], [Exam_ID], [Subject_ID], [Class_ID], [Marks], [Date_Exam], [Session]) VALUES (4, N'EC60JFWPWCVQ', 2018, 2027, 13, 4, 1, CAST(60.00 AS Decimal(6, 2)), CAST(N'2019-01-04' AS Date), N'2019-20')
INSERT [dbo].[Performance_Report] ([ID], [School_Code], [Parent_ID], [Student_ID], [Exam_ID], [Subject_ID], [Class_ID], [Marks], [Date_Exam], [Session]) VALUES (5, N'EC60JFWPWCVQ', 2018, 2027, 13, 5, 1, CAST(75.00 AS Decimal(6, 2)), CAST(N'2019-01-05' AS Date), N'2019-20')
INSERT [dbo].[Performance_Report] ([ID], [School_Code], [Parent_ID], [Student_ID], [Exam_ID], [Subject_ID], [Class_ID], [Marks], [Date_Exam], [Session]) VALUES (6, N'EC60JFWPWCVQ', 2018, 2027, 14, 1, 1, CAST(78.00 AS Decimal(6, 2)), CAST(N'2019-10-02' AS Date), N'2019-20')
INSERT [dbo].[Performance_Report] ([ID], [School_Code], [Parent_ID], [Student_ID], [Exam_ID], [Subject_ID], [Class_ID], [Marks], [Date_Exam], [Session]) VALUES (7, N'EC60JFWPWCVQ', 2018, 2027, 14, 2, 1, CAST(67.00 AS Decimal(6, 2)), CAST(N'2019-10-03' AS Date), N'2019-20')
INSERT [dbo].[Performance_Report] ([ID], [School_Code], [Parent_ID], [Student_ID], [Exam_ID], [Subject_ID], [Class_ID], [Marks], [Date_Exam], [Session]) VALUES (8, N'EC60JFWPWCVQ', 2018, 2027, 14, 3, 1, CAST(87.00 AS Decimal(6, 2)), CAST(N'2019-10-04' AS Date), N'2019-20')
INSERT [dbo].[Performance_Report] ([ID], [School_Code], [Parent_ID], [Student_ID], [Exam_ID], [Subject_ID], [Class_ID], [Marks], [Date_Exam], [Session]) VALUES (9, N'EC60JFWPWCVQ', 2018, 2027, 14, 4, 1, CAST(76.00 AS Decimal(6, 2)), CAST(N'2019-10-05' AS Date), N'2019-20')
INSERT [dbo].[Performance_Report] ([ID], [School_Code], [Parent_ID], [Student_ID], [Exam_ID], [Subject_ID], [Class_ID], [Marks], [Date_Exam], [Session]) VALUES (10, N'EC60JFWPWCVQ', 2018, 2027, 14, 5, 1, CAST(80.00 AS Decimal(6, 2)), CAST(N'2019-10-06' AS Date), N'2019-20')
INSERT [dbo].[Performance_Report] ([ID], [School_Code], [Parent_ID], [Student_ID], [Exam_ID], [Subject_ID], [Class_ID], [Marks], [Date_Exam], [Session]) VALUES (11, N'EC60JFWPWCVQ', 2018, 2027, 15, 1, 1, CAST(78.00 AS Decimal(6, 2)), CAST(N'2019-12-31' AS Date), N'2019-20')
INSERT [dbo].[Performance_Report] ([ID], [School_Code], [Parent_ID], [Student_ID], [Exam_ID], [Subject_ID], [Class_ID], [Marks], [Date_Exam], [Session]) VALUES (12, N'EC60JFWPWCVQ', 2018, 2027, 15, 2, 1, CAST(67.00 AS Decimal(6, 2)), CAST(N'2019-12-01' AS Date), N'2019-20')
INSERT [dbo].[Performance_Report] ([ID], [School_Code], [Parent_ID], [Student_ID], [Exam_ID], [Subject_ID], [Class_ID], [Marks], [Date_Exam], [Session]) VALUES (14, N'EC60JFWPWCVQ', 2018, 2027, 15, 3, 1, CAST(54.00 AS Decimal(6, 2)), CAST(N'2019-12-04' AS Date), N'2019-20')
INSERT [dbo].[Performance_Report] ([ID], [School_Code], [Parent_ID], [Student_ID], [Exam_ID], [Subject_ID], [Class_ID], [Marks], [Date_Exam], [Session]) VALUES (15, N'EC60JFWPWCVQ', 2018, 2027, 15, 4, 1, CAST(45.00 AS Decimal(6, 2)), CAST(N'2019-12-05' AS Date), N'2019-20')
INSERT [dbo].[Performance_Report] ([ID], [School_Code], [Parent_ID], [Student_ID], [Exam_ID], [Subject_ID], [Class_ID], [Marks], [Date_Exam], [Session]) VALUES (16, N'EC60JFWPWCVQ', 2018, 2027, 15, 5, 1, CAST(89.00 AS Decimal(6, 2)), CAST(N'2019-12-05' AS Date), N'2019-20')
SET IDENTITY_INSERT [dbo].[Performance_Report] OFF
SET IDENTITY_INSERT [dbo].[Period_Master] ON 

INSERT [dbo].[Period_Master] ([Period_Id], [Period_Name], [Period_Type], [Stime], [Duration], [Etime], [Class_Id], [School_Code], [School_Group_Code], [Order_period]) VALUES (1, N'First ', N'Class', CAST(N'10:00:00' AS Time), 30, CAST(N'10:30:20' AS Time), 10, N'EC60JFWPWCVQ', N'DPS', 1)
INSERT [dbo].[Period_Master] ([Period_Id], [Period_Name], [Period_Type], [Stime], [Duration], [Etime], [Class_Id], [School_Code], [School_Group_Code], [Order_period]) VALUES (2, N'Second', N'Class', CAST(N'10:30:00' AS Time), 30, CAST(N'11:00:00' AS Time), 10, N'EC60JFWPWCVQ', N'DPS', 2)
INSERT [dbo].[Period_Master] ([Period_Id], [Period_Name], [Period_Type], [Stime], [Duration], [Etime], [Class_Id], [School_Code], [School_Group_Code], [Order_period]) VALUES (14, N'third', N'undefined', CAST(N'11:00:00' AS Time), 60, CAST(N'12:00:00' AS Time), 10, N'EC60JFWPWCVQ', N'400', 3)
INSERT [dbo].[Period_Master] ([Period_Id], [Period_Name], [Period_Type], [Stime], [Duration], [Etime], [Class_Id], [School_Code], [School_Group_Code], [Order_period]) VALUES (15, N'Fourth', N'Period', CAST(N'12:00:00' AS Time), 60, CAST(N'13:00:00' AS Time), 10, N'EC60JFWPWCVQ', N'400', 4)
INSERT [dbo].[Period_Master] ([Period_Id], [Period_Name], [Period_Type], [Stime], [Duration], [Etime], [Class_Id], [School_Code], [School_Group_Code], [Order_period]) VALUES (16, N'Fifth', N'Period', CAST(N'13:00:00' AS Time), 60, CAST(N'14:00:00' AS Time), 10, N'EC60JFWPWCVQ', N'400', 5)
INSERT [dbo].[Period_Master] ([Period_Id], [Period_Name], [Period_Type], [Stime], [Duration], [Etime], [Class_Id], [School_Code], [School_Group_Code], [Order_period]) VALUES (17, N'Sixth', N'Period', CAST(N'14:00:00' AS Time), 30, CAST(N'14:30:00' AS Time), 10, N'EC60JFWPWCVQ', N'400', 6)
SET IDENTITY_INSERT [dbo].[Period_Master] OFF
SET IDENTITY_INSERT [dbo].[School_Class_Note] ON 

INSERT [dbo].[School_Class_Note] ([id], [School_Id], [School_Code], [School_Name], [Employee_Id], [Class_Id], [Section_Id], [Subject_Id], [Topic_Name], [Note_Description], [Note_Date], [Note_Type_Id]) VALUES (1, N'3', N'JKIUR8CSCJZ1', N'QATAR INC PVT LTD', NULL, N'3', N'1', NULL, N'fsvsvaz', N'svbvxczv', N'23-04-2019', NULL)
INSERT [dbo].[School_Class_Note] ([id], [School_Id], [School_Code], [School_Name], [Employee_Id], [Class_Id], [Section_Id], [Subject_Id], [Topic_Name], [Note_Description], [Note_Date], [Note_Type_Id]) VALUES (2, N'3', N'JKIUR8CSCJZ1', N'South Point', NULL, N'1', N'2', NULL, N'Life Science', N'Photo Synthesis', N'24-04-2019', NULL)
INSERT [dbo].[School_Class_Note] ([id], [School_Id], [School_Code], [School_Name], [Employee_Id], [Class_Id], [Section_Id], [Subject_Id], [Topic_Name], [Note_Description], [Note_Date], [Note_Type_Id]) VALUES (3, N'3', N'JKIUR8CSCJZ1', N'South Point', NULL, N'2', N'2', NULL, N'csscvsvsvsv', N'svvvvsv', N'16/05/2019', N'2')
INSERT [dbo].[School_Class_Note] ([id], [School_Id], [School_Code], [School_Name], [Employee_Id], [Class_Id], [Section_Id], [Subject_Id], [Topic_Name], [Note_Description], [Note_Date], [Note_Type_Id]) VALUES (4, N'3', N'JKIUR8CSCJZ1', N'South Point', N'2026', N'10', N'1', NULL, N'vhgjgdjgdjgvjvhdjsvsvsvvsv', N'Photo Synthesis', N'17/05/2019', N'2')
INSERT [dbo].[School_Class_Note] ([id], [School_Id], [School_Code], [School_Name], [Employee_Id], [Class_Id], [Section_Id], [Subject_Id], [Topic_Name], [Note_Description], [Note_Date], [Note_Type_Id]) VALUES (5, N'3', N'JKIUR8CSCJZ1', N'South Point', N'2026', N'3', N'2', N'3', N'xvxvsv', N'svsvsv', N'13/05/2019', N'2')
INSERT [dbo].[School_Class_Note] ([id], [School_Id], [School_Code], [School_Name], [Employee_Id], [Class_Id], [Section_Id], [Subject_Id], [Topic_Name], [Note_Description], [Note_Date], [Note_Type_Id]) VALUES (6, N'2', N'EC60JFWPWCVQ', N'Dev', N'1012', N'4', N'1', N'1', N'Themodynsmics', N'test test', N'17/01/2020', N'1')
INSERT [dbo].[School_Class_Note] ([id], [School_Id], [School_Code], [School_Name], [Employee_Id], [Class_Id], [Section_Id], [Subject_Id], [Topic_Name], [Note_Description], [Note_Date], [Note_Type_Id]) VALUES (7, N'2', N'EC60JFWPWCVQ', N'Dev', N'1012', N'4', N'3', N'6', N'Light', N'refraction', N'06/02/2020', N'2')
SET IDENTITY_INSERT [dbo].[School_Class_Note] OFF
SET IDENTITY_INSERT [dbo].[School_Class_Routine] ON 

INSERT [dbo].[School_Class_Routine] ([Routine_Id], [School_Id], [School_Code], [School_Name], [Start_Time], [End_Time], [Class_Id], [Section_Id], [Employee_Id], [Subject_Id], [Room_Id], [Year_Name], [Day_Id], [Period_Id]) VALUES (1003, N'5', N'LTWVD0HZXDKE', N'Jadavpur BidhyaPith', N'10:00', N'10:45', N'2', N'1', N'21', N'1', N'1', N'2019', N'2', N'1')
INSERT [dbo].[School_Class_Routine] ([Routine_Id], [School_Id], [School_Code], [School_Name], [Start_Time], [End_Time], [Class_Id], [Section_Id], [Employee_Id], [Subject_Id], [Room_Id], [Year_Name], [Day_Id], [Period_Id]) VALUES (1004, N'5', N'LTWVD0HZXDKE', N'Jadavpur BidhyaPith', N'10:45', N'11:30', N'1', N'2', N'23', N'2', N'2', N'2019', N'1', N'1')
INSERT [dbo].[School_Class_Routine] ([Routine_Id], [School_Id], [School_Code], [School_Name], [Start_Time], [End_Time], [Class_Id], [Section_Id], [Employee_Id], [Subject_Id], [Room_Id], [Year_Name], [Day_Id], [Period_Id]) VALUES (1005, N'5', N'LTWVD0HZXDKE', N'Jadavpur BidhyaPith', N'10:30', N'11:15', N'2', N'2', N'23', N'2', N'2', N'2019', N'3', N'2')
INSERT [dbo].[School_Class_Routine] ([Routine_Id], [School_Id], [School_Code], [School_Name], [Start_Time], [End_Time], [Class_Id], [Section_Id], [Employee_Id], [Subject_Id], [Room_Id], [Year_Name], [Day_Id], [Period_Id]) VALUES (1006, N'5', N'LTWVD0HZXDKE', N'Jadavpur BidhyaPith', N'10:15', N'11:30', N'3', N'1', N'23', N'4', N'2', N'2019', N'3', N'3')
INSERT [dbo].[School_Class_Routine] ([Routine_Id], [School_Id], [School_Code], [School_Name], [Start_Time], [End_Time], [Class_Id], [Section_Id], [Employee_Id], [Subject_Id], [Room_Id], [Year_Name], [Day_Id], [Period_Id]) VALUES (1007, N'5', N'LTWVD0HZXDKE', N'Jadavpur BidhyaPith', N'12:45', N'13:15', N'1', N'2', N'23', N'2', N'3', N'2019', N'2', N'8')
INSERT [dbo].[School_Class_Routine] ([Routine_Id], [School_Id], [School_Code], [School_Name], [Start_Time], [End_Time], [Class_Id], [Section_Id], [Employee_Id], [Subject_Id], [Room_Id], [Year_Name], [Day_Id], [Period_Id]) VALUES (1008, N'2', N'EC60JFWPWCVQ', N'Delhi Public School', N'11:11', N'11:11', N'2', N'1', N'2012', N'1', N'2', N'2019', N'1', N'1')
INSERT [dbo].[School_Class_Routine] ([Routine_Id], [School_Id], [School_Code], [School_Name], [Start_Time], [End_Time], [Class_Id], [Section_Id], [Employee_Id], [Subject_Id], [Room_Id], [Year_Name], [Day_Id], [Period_Id]) VALUES (1009, N'2', N'EC60JFWPWCVQ', N'Delhi Public School', N'11:11', N'11:11', N'2', N'1', N'2012', N'2', N'2', N'2018', N'2', N'2')
SET IDENTITY_INSERT [dbo].[School_Class_Routine] OFF
SET IDENTITY_INSERT [dbo].[School_Details_Master] ON 

INSERT [dbo].[School_Details_Master] ([School_Id], [School_Group_Code], [School_Code], [School_Name], [School_Email], [School_Password], [School_Phone], [School_Contact_Person], [School_Contact_Person_Email], [School_Contact_Person_Phone], [SchoolAddress1], [SchoolAddress2], [Country_Id], [State_Id], [City_Id], [Board_Id]) VALUES (1, N'300', N'E3TQTHFGNEFI', N'Jagadbandhu Institution', N'sahaniloy24@gmail.com', N'Marine@0', N'8013437504', N'Nirmal Kumar  Saha', N'ani@gmail.com', N'9013437504', N'28/7 New Ballygunge Road ', N'Kolkata  700039', 1, 38, 1475, 2)
INSERT [dbo].[School_Details_Master] ([School_Id], [School_Group_Code], [School_Code], [School_Name], [School_Email], [School_Password], [School_Phone], [School_Contact_Person], [School_Contact_Person_Email], [School_Contact_Person_Phone], [SchoolAddress1], [SchoolAddress2], [Country_Id], [State_Id], [City_Id], [Board_Id]) VALUES (2, N'400', N'EC60JFWPWCVQ', N'Delhi Public School', N'sahaniloy80@gmail.com', N'Marine@0', N'1234567890', N'Biplab Kanti Sen', N'biplab@gmail.com', N'1234567890', N'Bani Niketan Vidyapith Road', N'NA', 1, 38, 1166, 1)
INSERT [dbo].[School_Details_Master] ([School_Id], [School_Group_Code], [School_Code], [School_Name], [School_Email], [School_Password], [School_Phone], [School_Contact_Person], [School_Contact_Person_Email], [School_Contact_Person_Phone], [SchoolAddress1], [SchoolAddress2], [Country_Id], [State_Id], [City_Id], [Board_Id]) VALUES (3, N'500', N'057KLZQ6Q68F', N'Newtown Public ', N'animeh@gmail.com', N'Marine@0', N'8013437333', N'Niloy Saha', N'ani@gmail.com', N'1234567891', N'28/7 New Ballygunge Road', N'', 1, 38, 1166, 5)
INSERT [dbo].[School_Details_Master] ([School_Id], [School_Group_Code], [School_Code], [School_Name], [School_Email], [School_Password], [School_Phone], [School_Contact_Person], [School_Contact_Person_Email], [School_Contact_Person_Phone], [SchoolAddress1], [SchoolAddress2], [Country_Id], [State_Id], [City_Id], [Board_Id]) VALUES (4, N'600', N'ZVX5OGG335O4', N'Kendriya Vidyalaya', N'denovo84@gmail.com', N'FOOTBALL@123', N'1233456789', N'A k s', N'animesh@gmail.com', N'0898234546', N'Barasat', N'', 1, 38, 1475, 2)
SET IDENTITY_INSERT [dbo].[School_Details_Master] OFF
SET IDENTITY_INSERT [dbo].[School_Employee_Details] ON 

INSERT [dbo].[School_Employee_Details] ([Employee_Id], [School_Id], [School_Code], [School_Name], [EmpType_Id], [Employee_Name], [Employee_Code], [Employee_Email], [Employee_Password], [Employee_Mobile_Number], [Employee_Alt_Number], [Employee_DOB]) VALUES (10, 2, N'HZXFDMKHFTK7', N'Delhi Public School', 4, N'Shankha Chatterjee', N'T0T8LCEVG0', N'sahaniloy24@gmail.com', N'2N8SNEQW', N'8013437504', N'8013437504', N'25/01/2019')
INSERT [dbo].[School_Employee_Details] ([Employee_Id], [School_Id], [School_Code], [School_Name], [EmpType_Id], [Employee_Name], [Employee_Code], [Employee_Email], [Employee_Password], [Employee_Mobile_Number], [Employee_Alt_Number], [Employee_DOB]) VALUES (11, 2, N'HZXFDMKHFTK7', N'Delhi Public School', 4, N'Prasenjit Sengupta', N'QDRS3BO2AR', N'prasenjit@gmail.com', N'&8I41SR4', N'8013437504', N'8013437504', N'25/01/2019')
INSERT [dbo].[School_Employee_Details] ([Employee_Id], [School_Id], [School_Code], [School_Name], [EmpType_Id], [Employee_Name], [Employee_Code], [Employee_Email], [Employee_Password], [Employee_Mobile_Number], [Employee_Alt_Number], [Employee_DOB]) VALUES (12, 1, N'E3TQTHFGNEFI', N'Dev', 6, N'Shyam', N'LKSDXMC65T', N'sahaniloy24@gmail.com', N'TBWIL92E', N'1234567890', N'1245698300', N'21/03/2019')
INSERT [dbo].[School_Employee_Details] ([Employee_Id], [School_Id], [School_Code], [School_Name], [EmpType_Id], [Employee_Name], [Employee_Code], [Employee_Email], [Employee_Password], [Employee_Mobile_Number], [Employee_Alt_Number], [Employee_DOB]) VALUES (13, 1, N'E3TQTHFGNEFI', N'Dev', 6, N'Niloy', N'417QWGE&17', N'sahaniloy24@gmail.com', N'QZ9O827R', N'1234567890', N'1245678900', N'20/03/2019')
INSERT [dbo].[School_Employee_Details] ([Employee_Id], [School_Id], [School_Code], [School_Name], [EmpType_Id], [Employee_Name], [Employee_Code], [Employee_Email], [Employee_Password], [Employee_Mobile_Number], [Employee_Alt_Number], [Employee_DOB]) VALUES (14, 1, N'E3TQTHFGNEFI', N'Dev', 11, N'Niloy', N'FNERZQXB4S', N'niloy@gmail.com', N'WA1A8J3T', N'1234567890', N'1245678900', N'20/03/2019')
INSERT [dbo].[School_Employee_Details] ([Employee_Id], [School_Id], [School_Code], [School_Name], [EmpType_Id], [Employee_Name], [Employee_Code], [Employee_Email], [Employee_Password], [Employee_Mobile_Number], [Employee_Alt_Number], [Employee_DOB]) VALUES (15, 1, N'E3TQTHFGNEFI', N'Dev', 6, N'Niloy', N'DUKJMJWR4S', N'anik@gmail.com', N'Marine@0', N'1234567890', N'1245678900', N'22/03/2019')
INSERT [dbo].[School_Employee_Details] ([Employee_Id], [School_Id], [School_Code], [School_Name], [EmpType_Id], [Employee_Name], [Employee_Code], [Employee_Email], [Employee_Password], [Employee_Mobile_Number], [Employee_Alt_Number], [Employee_DOB]) VALUES (1012, 2, N'EC60JFWPWCVQ', N'Dev', 1007, N'Jogeshdfdfdf', N'AQ&4GVBRTZ', N'sahaniloy81@gmail.com', N'Marine@9', N'9876543219', N'979996767676', N'24/04/2019')
INSERT [dbo].[School_Employee_Details] ([Employee_Id], [School_Id], [School_Code], [School_Name], [EmpType_Id], [Employee_Name], [Employee_Code], [Employee_Email], [Employee_Password], [Employee_Mobile_Number], [Employee_Alt_Number], [Employee_DOB]) VALUES (1013, 3, N'057KLZQ6Q68F', N'Dev', 1008, N'Niloy Debnath', N'DK46C03GAO', N'ani200@gmail.com', N'Marine@0', N'1234567890', N'9820114222', N'24/04/2019')
INSERT [dbo].[School_Employee_Details] ([Employee_Id], [School_Id], [School_Code], [School_Name], [EmpType_Id], [Employee_Name], [Employee_Code], [Employee_Email], [Employee_Password], [Employee_Mobile_Number], [Employee_Alt_Number], [Employee_DOB]) VALUES (2012, 2, N'EC60JFWPWCVQ', N'Dev', 1007, N'Raj kumar Rajput', N'HC1H7X&N&V', N'lagnajit@gmail.com', N'Marine@7', N'1234567890', N'1234567890', N'1234567890')
SET IDENTITY_INSERT [dbo].[School_Employee_Details] OFF
SET IDENTITY_INSERT [dbo].[School_EmpType_Master] ON 

INSERT [dbo].[School_EmpType_Master] ([Type_Id], [School_Id], [School_Code], [School_Name], [EmpType_Name], [User_Type]) VALUES (1, 2, N'HZXFDMKHFTK7', N'Delhi Public School', N'Assistant Teacher', NULL)
INSERT [dbo].[School_EmpType_Master] ([Type_Id], [School_Id], [School_Code], [School_Name], [EmpType_Name], [User_Type]) VALUES (2, 3, N'JKIUR8CSCJZ1', N'South Point', N'Assistant Head Master', NULL)
INSERT [dbo].[School_EmpType_Master] ([Type_Id], [School_Id], [School_Code], [School_Name], [EmpType_Name], [User_Type]) VALUES (3, 3, N'JKIUR8CSCJZ1', N'South Point', N'Assistant Clark', NULL)
INSERT [dbo].[School_EmpType_Master] ([Type_Id], [School_Id], [School_Code], [School_Name], [EmpType_Name], [User_Type]) VALUES (4, 2, N'HZXFDMKHFTK7', N'Delhi Public School', N'Accounts Head', NULL)
INSERT [dbo].[School_EmpType_Master] ([Type_Id], [School_Id], [School_Code], [School_Name], [EmpType_Name], [User_Type]) VALUES (5, 4, N'6V9OIO0U8ZLR', N'JAGADBANDHU INSTITUTION', N'Assistant Teacher', NULL)
INSERT [dbo].[School_EmpType_Master] ([Type_Id], [School_Id], [School_Code], [School_Name], [EmpType_Name], [User_Type]) VALUES (6, 1, N'E3TQTHFGNEFI', N'Jagadbandhu Institution', N'Clerk', NULL)
INSERT [dbo].[School_EmpType_Master] ([Type_Id], [School_Id], [School_Code], [School_Name], [EmpType_Name], [User_Type]) VALUES (7, 1, N'E3TQTHFGNEFI', N'Jagadbandhu Institution', N'Clerk', NULL)
INSERT [dbo].[School_EmpType_Master] ([Type_Id], [School_Id], [School_Code], [School_Name], [EmpType_Name], [User_Type]) VALUES (8, 1, N'E3TQTHFGNEFI', N'Jagadbandhu Institution', N'Clerk', NULL)
INSERT [dbo].[School_EmpType_Master] ([Type_Id], [School_Id], [School_Code], [School_Name], [EmpType_Name], [User_Type]) VALUES (9, 1, N'E3TQTHFGNEFI', N'Jagadbandhu Institution', N'Clerk', NULL)
INSERT [dbo].[School_EmpType_Master] ([Type_Id], [School_Id], [School_Code], [School_Name], [EmpType_Name], [User_Type]) VALUES (10, 1, N'E3TQTHFGNEFI', N'Jagadbandhu Institution', N'Clerk', NULL)
INSERT [dbo].[School_EmpType_Master] ([Type_Id], [School_Id], [School_Code], [School_Name], [EmpType_Name], [User_Type]) VALUES (11, 1, N'E3TQTHFGNEFI', N'Jagadbandhu Institution', N'Librayan', NULL)
INSERT [dbo].[School_EmpType_Master] ([Type_Id], [School_Id], [School_Code], [School_Name], [EmpType_Name], [User_Type]) VALUES (1006, 2, N'EC60JFWPWCVQ', N'Delhi Public School', N'Clerk', NULL)
INSERT [dbo].[School_EmpType_Master] ([Type_Id], [School_Id], [School_Code], [School_Name], [EmpType_Name], [User_Type]) VALUES (1007, 2, N'EC60JFWPWCVQ', N'Delhi Public School', N'Office Staff', NULL)
INSERT [dbo].[School_EmpType_Master] ([Type_Id], [School_Id], [School_Code], [School_Name], [EmpType_Name], [User_Type]) VALUES (1008, 3, N'057KLZQ6Q68F', N'Newtown Public ', N'Office Staff', NULL)
INSERT [dbo].[School_EmpType_Master] ([Type_Id], [School_Id], [School_Code], [School_Name], [EmpType_Name], [User_Type]) VALUES (2006, 2, N'EC60JFWPWCVQ', N'Delhi Public School', N'Librariyan', NULL)
INSERT [dbo].[School_EmpType_Master] ([Type_Id], [School_Id], [School_Code], [School_Name], [EmpType_Name], [User_Type]) VALUES (2007, 2, N'EC60JFWPWCVQ', N'Delhi Public School', N'Librariyan', NULL)
INSERT [dbo].[School_EmpType_Master] ([Type_Id], [School_Id], [School_Code], [School_Name], [EmpType_Name], [User_Type]) VALUES (2008, 2, N'EC60JFWPWCVQ', N'Delhi Public School', N'Librariyan', NULL)
INSERT [dbo].[School_EmpType_Master] ([Type_Id], [School_Id], [School_Code], [School_Name], [EmpType_Name], [User_Type]) VALUES (2009, 2, N'EC60JFWPWCVQ', N'Delhi Public School', N'Librariyan', NULL)
INSERT [dbo].[School_EmpType_Master] ([Type_Id], [School_Id], [School_Code], [School_Name], [EmpType_Name], [User_Type]) VALUES (2010, 2, N'EC60JFWPWCVQ', N'Delhi Public School', N'Librariyan', NULL)
INSERT [dbo].[School_EmpType_Master] ([Type_Id], [School_Id], [School_Code], [School_Name], [EmpType_Name], [User_Type]) VALUES (2011, 2, N'EC60JFWPWCVQ', N'Delhi Public School', N'Teacher', NULL)
INSERT [dbo].[School_EmpType_Master] ([Type_Id], [School_Id], [School_Code], [School_Name], [EmpType_Name], [User_Type]) VALUES (2012, 2, N'EC60JFWPWCVQ', N'Delhi Public School', N'LT', NULL)
INSERT [dbo].[School_EmpType_Master] ([Type_Id], [School_Id], [School_Code], [School_Name], [EmpType_Name], [User_Type]) VALUES (2013, 2, N'EC60JFWPWCVQ', N'Delhi Public School', N'LT', NULL)
INSERT [dbo].[School_EmpType_Master] ([Type_Id], [School_Id], [School_Code], [School_Name], [EmpType_Name], [User_Type]) VALUES (2014, 2, N'EC60JFWPWCVQ', N'Delhi Public School', N'Office Staff', NULL)
INSERT [dbo].[School_EmpType_Master] ([Type_Id], [School_Id], [School_Code], [School_Name], [EmpType_Name], [User_Type]) VALUES (2015, 2, N'EC60JFWPWCVQ', N'Delhi Public School', N'Librariyan', NULL)
INSERT [dbo].[School_EmpType_Master] ([Type_Id], [School_Id], [School_Code], [School_Name], [EmpType_Name], [User_Type]) VALUES (2016, 2, N'EC60JFWPWCVQ', N'Delhi Public School', N'Clerk Read', NULL)
INSERT [dbo].[School_EmpType_Master] ([Type_Id], [School_Id], [School_Code], [School_Name], [EmpType_Name], [User_Type]) VALUES (2017, 2, N'EC60JFWPWCVQ', N'Delhi Public School', N'Office Staff', N'3')
INSERT [dbo].[School_EmpType_Master] ([Type_Id], [School_Id], [School_Code], [School_Name], [EmpType_Name], [User_Type]) VALUES (2018, 2, N'EC60JFWPWCVQ', N'Delhi Public School', N'Bowler', N'3')
INSERT [dbo].[School_EmpType_Master] ([Type_Id], [School_Id], [School_Code], [School_Name], [EmpType_Name], [User_Type]) VALUES (2019, 2, N'EC60JFWPWCVQ', N'Delhi Public School', N'Teacher', N'3')
SET IDENTITY_INSERT [dbo].[School_EmpType_Master] OFF
SET IDENTITY_INSERT [dbo].[School_Exam_Term_Master] ON 

INSERT [dbo].[School_Exam_Term_Master] ([Exam_Term_id], [School_Id], [School_Name], [School_Code], [Exam_Term_Name], [Class_Id]) VALUES (1, N'2', N'Delhi Public School', N'EC60JFWPWCVQ', N'First Term', 12)
INSERT [dbo].[School_Exam_Term_Master] ([Exam_Term_id], [School_Id], [School_Name], [School_Code], [Exam_Term_Name], [Class_Id]) VALUES (2, N'2', N'Delhi Public School', N'EC60JFWPWCVQ', N'Second Term', 7)
INSERT [dbo].[School_Exam_Term_Master] ([Exam_Term_id], [School_Id], [School_Name], [School_Code], [Exam_Term_Name], [Class_Id]) VALUES (3, N'2', N'Delhi Public School', N'EC60JFWPWCVQ', N'Summer Term', 10)
INSERT [dbo].[School_Exam_Term_Master] ([Exam_Term_id], [School_Id], [School_Name], [School_Code], [Exam_Term_Name], [Class_Id]) VALUES (4, N'2', N'Delhi Public School', N'EC60JFWPWCVQ1', N'Half Yearly', 5)
INSERT [dbo].[School_Exam_Term_Master] ([Exam_Term_id], [School_Id], [School_Name], [School_Code], [Exam_Term_Name], [Class_Id]) VALUES (5, N'2', N'Delhi Public School', N'EC60JFWPWCVQ', N'Mid Term', 10)
INSERT [dbo].[School_Exam_Term_Master] ([Exam_Term_id], [School_Id], [School_Name], [School_Code], [Exam_Term_Name], [Class_Id]) VALUES (6, N'2', N'Delhi Public School', N'EC60JFWPWCVQ1', N'Half Yearly', 10)
SET IDENTITY_INSERT [dbo].[School_Exam_Term_Master] OFF
SET IDENTITY_INSERT [dbo].[School_Fees_Master] ON 

INSERT [dbo].[School_Fees_Master] ([id], [School_Code], [School_Id], [Class_Id], [Fees_Name], [Fees_Desc], [Amount], [Fees_Year]) VALUES (1, N'HZXFDMKHFTK7', N'2', N'12', N'Admission Fees', N'Admission Fee', N'2000', N'2019')
INSERT [dbo].[School_Fees_Master] ([id], [School_Code], [School_Id], [Class_Id], [Fees_Name], [Fees_Desc], [Amount], [Fees_Year]) VALUES (2, N'HZXFDMKHFTK7', N'2', N'12', N'Exam Fees', N'Exam Fees', N'2000', N'2019')
INSERT [dbo].[School_Fees_Master] ([id], [School_Code], [School_Id], [Class_Id], [Fees_Name], [Fees_Desc], [Amount], [Fees_Year]) VALUES (3, N'HZXFDMKHFTK7', N'2', N'10', N'Admission Fees', N'Sport Description', N'2000', N'1983')
INSERT [dbo].[School_Fees_Master] ([id], [School_Code], [School_Id], [Class_Id], [Fees_Name], [Fees_Desc], [Amount], [Fees_Year]) VALUES (4, N'EW0DV&VOFFV5', N'1', N'12', N'Admission Fees', N'Sport Description', N'2000', N'1980')
INSERT [dbo].[School_Fees_Master] ([id], [School_Code], [School_Id], [Class_Id], [Fees_Name], [Fees_Desc], [Amount], [Fees_Year]) VALUES (5, N'EW0DV&VOFFV5', N'1', N'12', N'Exam Fees', N'Fees Description', N'2011', N'1980')
INSERT [dbo].[School_Fees_Master] ([id], [School_Code], [School_Id], [Class_Id], [Fees_Name], [Fees_Desc], [Amount], [Fees_Year]) VALUES (1002, N'E3TQTHFGNEFI', N'1', N'12', N'Admission Fees', N'Sport Description', N'2000', N'1982')
INSERT [dbo].[School_Fees_Master] ([id], [School_Code], [School_Id], [Class_Id], [Fees_Name], [Fees_Desc], [Amount], [Fees_Year]) VALUES (1003, N'E3TQTHFGNEFI', N'1', N'12', N'Exam Fees', N'Sport Description', N'2000', N'1986')
INSERT [dbo].[School_Fees_Master] ([id], [School_Code], [School_Id], [Class_Id], [Fees_Name], [Fees_Desc], [Amount], [Fees_Year]) VALUES (2004, N'057KLZQ6Q68F', N'3', N'12', N'Admission Fees', N'admission fees dec', N'5000', N'2019')
INSERT [dbo].[School_Fees_Master] ([id], [School_Code], [School_Id], [Class_Id], [Fees_Name], [Fees_Desc], [Amount], [Fees_Year]) VALUES (3003, N'EC60JFWPWCVQ', N'2', N'9', N'Exam Fees', N'Sport DescriptionS', N'2011', N'2019')
SET IDENTITY_INSERT [dbo].[School_Fees_Master] OFF
SET IDENTITY_INSERT [dbo].[School_House_Master] ON 

INSERT [dbo].[School_House_Master] ([Section_Id], [School_Id], [School_Code], [School_Name], [House_Name]) VALUES (1, 2, N'EC60JFWPWCVQ', N'Delhi Public School', N'Red')
INSERT [dbo].[School_House_Master] ([Section_Id], [School_Id], [School_Code], [School_Name], [House_Name]) VALUES (2, 2, N'EC60JFWPWCVQ', N'Delhi Public School', N'Blue')
SET IDENTITY_INSERT [dbo].[School_House_Master] OFF
SET IDENTITY_INSERT [dbo].[School_Notice_Master] ON 

INSERT [dbo].[School_Notice_Master] ([Notice_Id], [School_Id], [School_Code], [School_Name], [Notice_Title], [Notice_Description], [User_Type_Id], [Notice_Published_On], [Notice_Status]) VALUES (4, 2, N'HZXFDMKHFTK7', N'Delhi Public School', N'Holiday on 23/01/2019', N'Holiday For Birthday of Subhas Chandra Bose   on  sxfbj,lkc fdfvfds', 1, N'10/01/2019', N'Active')
INSERT [dbo].[School_Notice_Master] ([Notice_Id], [School_Id], [School_Code], [School_Name], [Notice_Title], [Notice_Description], [User_Type_Id], [Notice_Published_On], [Notice_Status]) VALUES (5, 2, N'HZXFDMKHFTK7', N'Delhi Public School', N'Holiday in 26 jan 2018', N'Holiday  on 26th Jan 2019c v ', 2, N'10/01/2019', N'Active')
INSERT [dbo].[School_Notice_Master] ([Notice_Id], [School_Id], [School_Code], [School_Name], [Notice_Title], [Notice_Description], [User_Type_Id], [Notice_Published_On], [Notice_Status]) VALUES (6, 2, N'HZXFDMKHFTK7', N'Delhi Public School', N'Holiday on 1st May', N'This is A Test Notice.This is A Test Notice.This i', 2, N'10/01/2019', N'Active')
INSERT [dbo].[School_Notice_Master] ([Notice_Id], [School_Id], [School_Code], [School_Name], [Notice_Title], [Notice_Description], [User_Type_Id], [Notice_Published_On], [Notice_Status]) VALUES (7, 2, N'HZXFDMKHFTK7', N'Delhi Public School', N'Parent Notice', N'All Parent need 20019', 2, N'25/01/2019', N'Active')
INSERT [dbo].[School_Notice_Master] ([Notice_Id], [School_Id], [School_Code], [School_Name], [Notice_Title], [Notice_Description], [User_Type_Id], [Notice_Published_On], [Notice_Status]) VALUES (8, 2, N'HZXFDMKHFTK7', N'Delhi Public School', N'Thedf', N'This is A Test Notice.This is A Test Notice.This i', 2, N'26/01/2019', N'Active')
INSERT [dbo].[School_Notice_Master] ([Notice_Id], [School_Id], [School_Code], [School_Name], [Notice_Title], [Notice_Description], [User_Type_Id], [Notice_Published_On], [Notice_Status]) VALUES (9, 1, N'E3TQTHFGNEFI', N'Jagadbandhu Institution', N'demmo notice title', N'demmo notice descritionn', 1, N'20/03/2019', N'Active')
INSERT [dbo].[School_Notice_Master] ([Notice_Id], [School_Id], [School_Code], [School_Name], [Notice_Title], [Notice_Description], [User_Type_Id], [Notice_Published_On], [Notice_Status]) VALUES (1009, 3, N'057KLZQ6Q68F', N'Newtown Public ', N'Notice  for 1st may', N'Notice  for 1st may i a holiday', 1, N'19/04/2019', N'Active')
INSERT [dbo].[School_Notice_Master] ([Notice_Id], [School_Id], [School_Code], [School_Name], [Notice_Title], [Notice_Description], [User_Type_Id], [Notice_Published_On], [Notice_Status]) VALUES (1010, 3, N'057KLZQ6Q68F', N'Newtown Public ', N'demmo notice title', N'Holiday  on May Day', 2, N'25/03/2019', N'Active')
INSERT [dbo].[School_Notice_Master] ([Notice_Id], [School_Id], [School_Code], [School_Name], [Notice_Title], [Notice_Description], [User_Type_Id], [Notice_Published_On], [Notice_Status]) VALUES (2009, 2, N'EC60JFWPWCVQ', N'Delhi Public School', N'demmo notice', N'Holiday  on 26th Jan 2020', 1, N'21/03/2020', N'Active')
SET IDENTITY_INSERT [dbo].[School_Notice_Master] OFF
SET IDENTITY_INSERT [dbo].[School_Room_Master] ON 

INSERT [dbo].[School_Room_Master] ([Room_Id], [School_Code], [School_Group_Code], [Room_Name], [Room_no], [Floor], [Room_Category], [Occupied]) VALUES (1, N'EC60JFWPWCVQ', N'400', N'vidyasagar Hall', 240, 4, N'Library', N'occupied')
INSERT [dbo].[School_Room_Master] ([Room_Id], [School_Code], [School_Group_Code], [Room_Name], [Room_no], [Floor], [Room_Category], [Occupied]) VALUES (2, N'EC60JFWPWCVQ', N'400', N'RamMohal Hal 2', 980, 8, N'Library', N'Empty')
SET IDENTITY_INSERT [dbo].[School_Room_Master] OFF
SET IDENTITY_INSERT [dbo].[School_RoomCategory] ON 

INSERT [dbo].[School_RoomCategory] ([Category_id], [Category_Name], [Category_Description], [School_Code], [School_Group_Code]) VALUES (1, N'Yoga Room', N'We can do Yoga .', N'EC60JFWPWCVQ', NULL)
INSERT [dbo].[School_RoomCategory] ([Category_id], [Category_Name], [Category_Description], [School_Code], [School_Group_Code]) VALUES (2, N'Library Room', N'Book are avaible here', N'EC60JFWPWCVQ', NULL)
INSERT [dbo].[School_RoomCategory] ([Category_id], [Category_Name], [Category_Description], [School_Code], [School_Group_Code]) VALUES (3, N'Yoga Room', N'To do yoga', N'EC60JFWPWCVQ', NULL)
INSERT [dbo].[School_RoomCategory] ([Category_id], [Category_Name], [Category_Description], [School_Code], [School_Group_Code]) VALUES (4, N'hall room', N'test', N'EC60JFWPWCVQ', NULL)
INSERT [dbo].[School_RoomCategory] ([Category_id], [Category_Name], [Category_Description], [School_Code], [School_Group_Code]) VALUES (5, N'Library', N'Add Book', N'EC60JFWPWCVQ', N'400')
INSERT [dbo].[School_RoomCategory] ([Category_id], [Category_Name], [Category_Description], [School_Code], [School_Group_Code]) VALUES (6, N'Lbratary', N'chemical test', N'EC60JFWPWCVQ', N'400')
INSERT [dbo].[School_RoomCategory] ([Category_id], [Category_Name], [Category_Description], [School_Code], [School_Group_Code]) VALUES (7, N'study room', N'class', N'EC60JFWPWCVQ', N'400')
SET IDENTITY_INSERT [dbo].[School_RoomCategory] OFF
SET IDENTITY_INSERT [dbo].[School_Section_Master] ON 

INSERT [dbo].[School_Section_Master] ([Section_Id], [School_Id], [School_Code], [Class_Id], [School_Name], [Section_Name], [Section_Room_Number]) VALUES (1, 2, N'EC60JFWPWCVQ', 10, N'Delhi Public School', N'A', N'120')
INSERT [dbo].[School_Section_Master] ([Section_Id], [School_Id], [School_Code], [Class_Id], [School_Name], [Section_Name], [Section_Room_Number]) VALUES (2, 2, N'EC60JFWPWCVQ', 10, N'Delhi Public School', N'B', N'125')
INSERT [dbo].[School_Section_Master] ([Section_Id], [School_Id], [School_Code], [Class_Id], [School_Name], [Section_Name], [Section_Room_Number]) VALUES (3, 2, N'EC60JFWPWCVQ', 10, N'Delhi Public School', N'C', NULL)
INSERT [dbo].[School_Section_Master] ([Section_Id], [School_Id], [School_Code], [Class_Id], [School_Name], [Section_Name], [Section_Room_Number]) VALUES (4, 2, N'EC60JFWPWCVQ', 12, N'Delhi Public School', N'A', NULL)
INSERT [dbo].[School_Section_Master] ([Section_Id], [School_Id], [School_Code], [Class_Id], [School_Name], [Section_Name], [Section_Room_Number]) VALUES (5, 2, N'EC60JFWPWCVQ', 12, N'Delhi Public School', N'A', NULL)
INSERT [dbo].[School_Section_Master] ([Section_Id], [School_Id], [School_Code], [Class_Id], [School_Name], [Section_Name], [Section_Room_Number]) VALUES (6, 2, N'EC60JFWPWCVQ', 12, N'Delhi Public School', N'A', NULL)
SET IDENTITY_INSERT [dbo].[School_Section_Master] OFF
SET IDENTITY_INSERT [dbo].[School_Student_Details] ON 

INSERT [dbo].[School_Student_Details] ([Student_Id], [Parent_Id], [Application_Id], [School_Code], [first_name], [last_name], [middle_name], [Student_Email], [Password], [FatherName], [FatherContactNumber], [FatherEmail], [MotherName], [MotherContactNumber], [MotherEmail], [HomeContactNumber], [LocalGurdianValue], [LocalGurdianName], [LocalGurdianEmail], [LocalGurdianPhone], [Gender_Id], [DOB], [POB], [PermanentAddress1], [PermanentAddress2], [permanentzipcode], [PerCountryId], [Per_District], [PerStateId], [PerCityId], [CurrentAddress1], [CurrentAddress2], [currentzipcode], [CountryId], [StateId], [District], [CityId], [Zip], [Cur_Landmark], [Per_Landmark], [Email], [Phone], [BloodGroup_Id], [BirthCertificatePath], [BirthCertificate_Name], [IdProof_Id], [IdProof_Number], [Passport_Number], [CitizenCountryId], [BCN], [BCN_Attachment], [Special_Care], [Special_Care_Description], [Disability], [Disability_Percentage], [Disability_Description], [Disability_Certificate_Number], [DisabilityCertificat_Name], [DisabilityCertificatePath], [Caste], [Religion], [Special], [Details], [Physically_Hdc], [Hdc_Percent], [Is_Monitor], [Status], [AdmissionClass_Id], [Section_Id], [SectionName], [Last_School_Name], [SchoolBoard_Id], [Last_School_Year], [Last_School_Class], [School_Transfer_Certifiate_Number], [SchoolTransferCertificate_Name], [SchoolTransferCertificatePath], [Last_School_Exam_Marks], [Last_School_Total_Marks], [Last_School_Marks_Percentage], [FinalExamResult_Name], [FinalExamResultPath], [Board_Exam_Marks], [Board_Total_Marks], [Marks_Percentage], [Board_Certificate_Number], [BoardExamResultName], [BoardExamResultPath], [BoardExamCertificate_Name], [BoardExamCertificatePath], [ImagePath], [SignaturePath], [TermsAndConditions], [Application_Status], [Registration_Status]) VALUES (1, 17, N'EN201931192552270', N'EC60JFWPWCVQ', N'Niloy', N'Saha5', N'', N'', N'', N'', N'9876543210', N'abc@gmail.com', N'L . Ray', N'1234567895', N'palas@gmail.com', N'9876543000', N'No', N'null', N'null', N'null', NULL, N'23/03/2019', N'Kolkata', N'28/7 New Ballygunge Road', N' Kolkata-700039', N'700126', NULL, NULL, NULL, NULL, N'28/7 New Ballygunge Road d', N' Kolkata-700039', N'700126', 1, 38, NULL, 1166, NULL, NULL, NULL, NULL, NULL, 6, N'ERD_Exam_Schedule19184040.docx', NULL, 2, N'12345687nbb', N'123456588', 1, N'987654310', NULL, 1, N'4566', 1, N'70', N'Disability Desc Description', N'DESC123456', NULL, N'ERD_For_Attendance19184040.docx', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 9, 2, N'B', N'Nabapally Boys School', 3, N'2004', N'Eleven', N'58666666', NULL, N'null', N'', N'AdmissionClass_Id', N'', NULL, N'null', N'615', NULL, N'175.71', N'Bordcer123456', NULL, N'ERD_For_Attendance19353971.docx', NULL, N'ERD_Exam_Schedule19353971.docx', N'~/AppFiles/Images/Yellowstone National Park 0119174910.jpg', N'~/AppFiles/Images/park-0119174910.jpg', NULL, N'Complete', N'Yes')
INSERT [dbo].[School_Student_Details] ([Student_Id], [Parent_Id], [Application_Id], [School_Code], [first_name], [last_name], [middle_name], [Student_Email], [Password], [FatherName], [FatherContactNumber], [FatherEmail], [MotherName], [MotherContactNumber], [MotherEmail], [HomeContactNumber], [LocalGurdianValue], [LocalGurdianName], [LocalGurdianEmail], [LocalGurdianPhone], [Gender_Id], [DOB], [POB], [PermanentAddress1], [PermanentAddress2], [permanentzipcode], [PerCountryId], [Per_District], [PerStateId], [PerCityId], [CurrentAddress1], [CurrentAddress2], [currentzipcode], [CountryId], [StateId], [District], [CityId], [Zip], [Cur_Landmark], [Per_Landmark], [Email], [Phone], [BloodGroup_Id], [BirthCertificatePath], [BirthCertificate_Name], [IdProof_Id], [IdProof_Number], [Passport_Number], [CitizenCountryId], [BCN], [BCN_Attachment], [Special_Care], [Special_Care_Description], [Disability], [Disability_Percentage], [Disability_Description], [Disability_Certificate_Number], [DisabilityCertificat_Name], [DisabilityCertificatePath], [Caste], [Religion], [Special], [Details], [Physically_Hdc], [Hdc_Percent], [Is_Monitor], [Status], [AdmissionClass_Id], [Section_Id], [SectionName], [Last_School_Name], [SchoolBoard_Id], [Last_School_Year], [Last_School_Class], [School_Transfer_Certifiate_Number], [SchoolTransferCertificate_Name], [SchoolTransferCertificatePath], [Last_School_Exam_Marks], [Last_School_Total_Marks], [Last_School_Marks_Percentage], [FinalExamResult_Name], [FinalExamResultPath], [Board_Exam_Marks], [Board_Total_Marks], [Marks_Percentage], [Board_Certificate_Number], [BoardExamResultName], [BoardExamResultPath], [BoardExamCertificate_Name], [BoardExamCertificatePath], [ImagePath], [SignaturePath], [TermsAndConditions], [Application_Status], [Registration_Status]) VALUES (2, 1018, N'EN2019319204839280', N'EC60JFWPWCVQ', N'Jitendra', N'Rajput', N'kumar', N'', N'', N'', N'1234567890', N'ani@gmail.com', N'L . Ray', N'1234567890', N'ani@gmail.com', N'1234567890', N'Yes', N'Sukumar hazra', N'kanak@gmail.comm', N'1234567890', NULL, N'10/01/2019', N'Kolkata', N'Central London', N'123456', N'123456', NULL, NULL, NULL, NULL, N'Central London', N'123456', N'123456', 1, 38, NULL, 1166, NULL, NULL, NULL, NULL, NULL, 4, N'~/AppFiles/Images/ERD_For_Attendance19483918.docx', NULL, 1, N'12345644', N'', 1, N'16/01/2019', NULL, 1, N'Yes', 1, N'45', N'Disability Description. ', N'DESC123456', NULL, N'~/AppFiles/Images/ERD_For_Attendance19483918.docx', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 9, 1, N'A', N'Nabapally Boys School', 2, N'2004', N'Eleven', N'58666666', NULL, N'null', N'', N'', N'', NULL, N'null', N'80', NULL, N'66.67', N'Bordcer123456', NULL, N'~/AppFiles/Images/ERD_For_Attendance19505627.docx', NULL, N'~/AppFiles/Images/ERD_Exam_Schedule19505628.docx', N'~/AppFiles/Images/Cancun-Mexico-219575291.jpg', N'~/AppFiles/Images/th8XVU7L7F19575291.jpg', 1, N'Complete', N'Yes')
INSERT [dbo].[School_Student_Details] ([Student_Id], [Parent_Id], [Application_Id], [School_Code], [first_name], [last_name], [middle_name], [Student_Email], [Password], [FatherName], [FatherContactNumber], [FatherEmail], [MotherName], [MotherContactNumber], [MotherEmail], [HomeContactNumber], [LocalGurdianValue], [LocalGurdianName], [LocalGurdianEmail], [LocalGurdianPhone], [Gender_Id], [DOB], [POB], [PermanentAddress1], [PermanentAddress2], [permanentzipcode], [PerCountryId], [Per_District], [PerStateId], [PerCityId], [CurrentAddress1], [CurrentAddress2], [currentzipcode], [CountryId], [StateId], [District], [CityId], [Zip], [Cur_Landmark], [Per_Landmark], [Email], [Phone], [BloodGroup_Id], [BirthCertificatePath], [BirthCertificate_Name], [IdProof_Id], [IdProof_Number], [Passport_Number], [CitizenCountryId], [BCN], [BCN_Attachment], [Special_Care], [Special_Care_Description], [Disability], [Disability_Percentage], [Disability_Description], [Disability_Certificate_Number], [DisabilityCertificat_Name], [DisabilityCertificatePath], [Caste], [Religion], [Special], [Details], [Physically_Hdc], [Hdc_Percent], [Is_Monitor], [Status], [AdmissionClass_Id], [Section_Id], [SectionName], [Last_School_Name], [SchoolBoard_Id], [Last_School_Year], [Last_School_Class], [School_Transfer_Certifiate_Number], [SchoolTransferCertificate_Name], [SchoolTransferCertificatePath], [Last_School_Exam_Marks], [Last_School_Total_Marks], [Last_School_Marks_Percentage], [FinalExamResult_Name], [FinalExamResultPath], [Board_Exam_Marks], [Board_Total_Marks], [Marks_Percentage], [Board_Certificate_Number], [BoardExamResultName], [BoardExamResultPath], [BoardExamCertificate_Name], [BoardExamCertificatePath], [ImagePath], [SignaturePath], [TermsAndConditions], [Application_Status], [Registration_Status]) VALUES (3, 1018, N'EN2019319204839280', N'EC60JFWPWCVQ', N'Jayanto', N'Rajput', N'kumar', N'', N'', N'', N'1234567890', N'ani@gmail.com', N'L . Ray', N'1234567890', N'ani@gmail.com', N'1234567890', N'Yes', N'Sukumar hazra', N'kanak@gmail.comm', N'1234567890', NULL, N'10/01/2019', N'Kolkata', N'Central London', N'123456', N'123456', NULL, NULL, NULL, NULL, N'Central London', N'123456', N'123456', 1, 38, NULL, 1166, NULL, NULL, NULL, NULL, NULL, 4, N'~/AppFiles/Images/ERD_For_Attendance19483918.docx', NULL, 1, N'12345644', N'', 1, N'16/01/2019', NULL, 1, N'Yes', 1, N'45', N'Disability Description. ', N'DESC123456', NULL, N'~/AppFiles/Images/ERD_For_Attendance19483918.docx', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 10, 1, N'A', N'Nabapally Boys School', 2, N'2004', N'Eleven', N'58666666', NULL, N'null', N'', N'', N'', NULL, N'null', N'80', NULL, N'66.67', N'Bordcer123456', NULL, N'~/AppFiles/Images/ERD_For_Attendance19505627.docx', NULL, N'~/AppFiles/Images/ERD_Exam_Schedule19505628.docx', N'~/AppFiles/Images/Cancun-Mexico-219575291.jpg', N'~/AppFiles/Images/th8XVU7L7F19575291.jpg', 1, N'Complete', N'Yes')
INSERT [dbo].[School_Student_Details] ([Student_Id], [Parent_Id], [Application_Id], [School_Code], [first_name], [last_name], [middle_name], [Student_Email], [Password], [FatherName], [FatherContactNumber], [FatherEmail], [MotherName], [MotherContactNumber], [MotherEmail], [HomeContactNumber], [LocalGurdianValue], [LocalGurdianName], [LocalGurdianEmail], [LocalGurdianPhone], [Gender_Id], [DOB], [POB], [PermanentAddress1], [PermanentAddress2], [permanentzipcode], [PerCountryId], [Per_District], [PerStateId], [PerCityId], [CurrentAddress1], [CurrentAddress2], [currentzipcode], [CountryId], [StateId], [District], [CityId], [Zip], [Cur_Landmark], [Per_Landmark], [Email], [Phone], [BloodGroup_Id], [BirthCertificatePath], [BirthCertificate_Name], [IdProof_Id], [IdProof_Number], [Passport_Number], [CitizenCountryId], [BCN], [BCN_Attachment], [Special_Care], [Special_Care_Description], [Disability], [Disability_Percentage], [Disability_Description], [Disability_Certificate_Number], [DisabilityCertificat_Name], [DisabilityCertificatePath], [Caste], [Religion], [Special], [Details], [Physically_Hdc], [Hdc_Percent], [Is_Monitor], [Status], [AdmissionClass_Id], [Section_Id], [SectionName], [Last_School_Name], [SchoolBoard_Id], [Last_School_Year], [Last_School_Class], [School_Transfer_Certifiate_Number], [SchoolTransferCertificate_Name], [SchoolTransferCertificatePath], [Last_School_Exam_Marks], [Last_School_Total_Marks], [Last_School_Marks_Percentage], [FinalExamResult_Name], [FinalExamResultPath], [Board_Exam_Marks], [Board_Total_Marks], [Marks_Percentage], [Board_Certificate_Number], [BoardExamResultName], [BoardExamResultPath], [BoardExamCertificate_Name], [BoardExamCertificatePath], [ImagePath], [SignaturePath], [TermsAndConditions], [Application_Status], [Registration_Status]) VALUES (6, 2019, N'EN2019424185021830', N'EC60JFWPWCVQ', N'Raj', N'Kar', N'Kumar', N'raj@gmail.com', N'Marine@0', N'Mr P K Dey', N'1234567890', N'pk@gmail.com', N'Mrs K Dey', N'1234567890', N'kk@gmail.com', N'1234567890', N'Yes', N'T K Dey', N'tk@gmail.com', N'1234567890', NULL, N'24/07/2018', N'Kolkata', N'Central London', N'NA', N'700126', NULL, NULL, NULL, NULL, N'Central London', N'NA', N'700126', 1, 38, NULL, 1166, NULL, NULL, NULL, NULL, NULL, 2, N'th8XVU7L7F19502155.jpg', NULL, 4, N'146565656565', N'', 1, N'bvcc1231', NULL, 2, N'', 1, N'78', N'Disability Description. ', N'1284456', NULL, N'14441095_690410431115853_4316648889443898504_n19502158.jpg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 10, 1, N'A', N'Nabapally Boys School', 3, N'2004', N'Eleven', N'58666666', NULL, N'14517643_690410474449182_1216285545864557781_n19550387.jpg', N'', N'', N'', NULL, N'null', N'650', NULL, N'72.22', N'Bordcer123456', NULL, N'14433107_690410614449168_3019422085748242928_n19550392.jpg', NULL, N'14440702_690410484449181_7485634482134664735_n19550393.jpg', N'Yellowstone National Park 0119553590.jpg', N'yellowstone_519553593.jpg', 1, N'Admitted', N'Yes')
INSERT [dbo].[School_Student_Details] ([Student_Id], [Parent_Id], [Application_Id], [School_Code], [first_name], [last_name], [middle_name], [Student_Email], [Password], [FatherName], [FatherContactNumber], [FatherEmail], [MotherName], [MotherContactNumber], [MotherEmail], [HomeContactNumber], [LocalGurdianValue], [LocalGurdianName], [LocalGurdianEmail], [LocalGurdianPhone], [Gender_Id], [DOB], [POB], [PermanentAddress1], [PermanentAddress2], [permanentzipcode], [PerCountryId], [Per_District], [PerStateId], [PerCityId], [CurrentAddress1], [CurrentAddress2], [currentzipcode], [CountryId], [StateId], [District], [CityId], [Zip], [Cur_Landmark], [Per_Landmark], [Email], [Phone], [BloodGroup_Id], [BirthCertificatePath], [BirthCertificate_Name], [IdProof_Id], [IdProof_Number], [Passport_Number], [CitizenCountryId], [BCN], [BCN_Attachment], [Special_Care], [Special_Care_Description], [Disability], [Disability_Percentage], [Disability_Description], [Disability_Certificate_Number], [DisabilityCertificat_Name], [DisabilityCertificatePath], [Caste], [Religion], [Special], [Details], [Physically_Hdc], [Hdc_Percent], [Is_Monitor], [Status], [AdmissionClass_Id], [Section_Id], [SectionName], [Last_School_Name], [SchoolBoard_Id], [Last_School_Year], [Last_School_Class], [School_Transfer_Certifiate_Number], [SchoolTransferCertificate_Name], [SchoolTransferCertificatePath], [Last_School_Exam_Marks], [Last_School_Total_Marks], [Last_School_Marks_Percentage], [FinalExamResult_Name], [FinalExamResultPath], [Board_Exam_Marks], [Board_Total_Marks], [Marks_Percentage], [Board_Certificate_Number], [BoardExamResultName], [BoardExamResultPath], [BoardExamCertificate_Name], [BoardExamCertificatePath], [ImagePath], [SignaturePath], [TermsAndConditions], [Application_Status], [Registration_Status]) VALUES (7, 2018, N'EN2020110163712936', N'EC60JFWPWCVQ', N'Prantik', N'Saha', N'', NULL, NULL, N'R Kumar', N'0700374821', N'sahaniloy24@gmail.com', N'A kumar', N'0898234546', N'raj@gmail.com', N'0700374821', N'Yes', N'P Saha', N'raj@gmail.com', N'0700374821', NULL, N'03/01/2020', N'kolkata', N'Ballygunge', N'', N'700039', NULL, NULL, NULL, NULL, N'Ballygunge', N'', N'700039', 1, 38, NULL, 1166, NULL, NULL, NULL, NULL, NULL, 4, N'changerequestfromchange20370658.php', NULL, 2, N'sretrytu', N'rererer434', 1, N'65hhh', NULL, 1, N'65', 1, N'40', N'desc', N'nb454', NULL, N'null', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 12, 2, N'B', N'Nabapally', 3, N'2001', N'ten', N'CER123555', NULL, N'f1e47792540d5d1d7657e04d54e96fb720075075.jpg', N'615', N'800', N'76.88', NULL, N'ERD_For_Attendance20075075.docx', N'null', NULL, N'null', N'null', NULL, N'null', NULL, N'null', N'varwwwclientsclient1web2tmpphp0y4IuD20161166.jpg', N'iso-metrics20161168.jpg', 1, N'Admitted', NULL)
INSERT [dbo].[School_Student_Details] ([Student_Id], [Parent_Id], [Application_Id], [School_Code], [first_name], [last_name], [middle_name], [Student_Email], [Password], [FatherName], [FatherContactNumber], [FatherEmail], [MotherName], [MotherContactNumber], [MotherEmail], [HomeContactNumber], [LocalGurdianValue], [LocalGurdianName], [LocalGurdianEmail], [LocalGurdianPhone], [Gender_Id], [DOB], [POB], [PermanentAddress1], [PermanentAddress2], [permanentzipcode], [PerCountryId], [Per_District], [PerStateId], [PerCityId], [CurrentAddress1], [CurrentAddress2], [currentzipcode], [CountryId], [StateId], [District], [CityId], [Zip], [Cur_Landmark], [Per_Landmark], [Email], [Phone], [BloodGroup_Id], [BirthCertificatePath], [BirthCertificate_Name], [IdProof_Id], [IdProof_Number], [Passport_Number], [CitizenCountryId], [BCN], [BCN_Attachment], [Special_Care], [Special_Care_Description], [Disability], [Disability_Percentage], [Disability_Description], [Disability_Certificate_Number], [DisabilityCertificat_Name], [DisabilityCertificatePath], [Caste], [Religion], [Special], [Details], [Physically_Hdc], [Hdc_Percent], [Is_Monitor], [Status], [AdmissionClass_Id], [Section_Id], [SectionName], [Last_School_Name], [SchoolBoard_Id], [Last_School_Year], [Last_School_Class], [School_Transfer_Certifiate_Number], [SchoolTransferCertificate_Name], [SchoolTransferCertificatePath], [Last_School_Exam_Marks], [Last_School_Total_Marks], [Last_School_Marks_Percentage], [FinalExamResult_Name], [FinalExamResultPath], [Board_Exam_Marks], [Board_Total_Marks], [Marks_Percentage], [Board_Certificate_Number], [BoardExamResultName], [BoardExamResultPath], [BoardExamCertificate_Name], [BoardExamCertificatePath], [ImagePath], [SignaturePath], [TermsAndConditions], [Application_Status], [Registration_Status]) VALUES (8, 2018, N'EN2020110163712936', N'EC60JFWPWCVQ', N'Rishikesh', N'Saha', N'', NULL, NULL, N'R Kumar', N'0700374821', N'sahaniloy24@gmail.com', N'A kumar', N'0898234546', N'raj@gmail.com', N'0700374821', N'Yes', N'P Saha', N'raj@gmail.com', N'0700374821', NULL, N'03/01/2020', N'kolkata', N'Ballygunge', N'', N'700039', NULL, NULL, NULL, NULL, N'Ballygunge', N'', N'700039', 1, 38, NULL, 1166, NULL, NULL, NULL, NULL, NULL, 4, N'changerequestfromchange20370658.php', NULL, 2, N'sretrytu', N'rererer434', 1, N'65hhh', NULL, 1, N'65', 1, N'40', N'desc', N'nb454', NULL, N'null', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 12, 1, N'A', N'Nabapally', 3, N'2001', N'ten', N'CER123555', NULL, N'f1e47792540d5d1d7657e04d54e96fb720075075.jpg', N'615', N'800', N'76.88', NULL, N'ERD_For_Attendance20075075.docx', N'null', NULL, N'null', N'null', NULL, N'null', NULL, N'null', N'varwwwclientsclient1web2tmpphp0y4IuD20161166.jpg', N'iso-metrics20161168.jpg', 1, N'Admitted', NULL)
INSERT [dbo].[School_Student_Details] ([Student_Id], [Parent_Id], [Application_Id], [School_Code], [first_name], [last_name], [middle_name], [Student_Email], [Password], [FatherName], [FatherContactNumber], [FatherEmail], [MotherName], [MotherContactNumber], [MotherEmail], [HomeContactNumber], [LocalGurdianValue], [LocalGurdianName], [LocalGurdianEmail], [LocalGurdianPhone], [Gender_Id], [DOB], [POB], [PermanentAddress1], [PermanentAddress2], [permanentzipcode], [PerCountryId], [Per_District], [PerStateId], [PerCityId], [CurrentAddress1], [CurrentAddress2], [currentzipcode], [CountryId], [StateId], [District], [CityId], [Zip], [Cur_Landmark], [Per_Landmark], [Email], [Phone], [BloodGroup_Id], [BirthCertificatePath], [BirthCertificate_Name], [IdProof_Id], [IdProof_Number], [Passport_Number], [CitizenCountryId], [BCN], [BCN_Attachment], [Special_Care], [Special_Care_Description], [Disability], [Disability_Percentage], [Disability_Description], [Disability_Certificate_Number], [DisabilityCertificat_Name], [DisabilityCertificatePath], [Caste], [Religion], [Special], [Details], [Physically_Hdc], [Hdc_Percent], [Is_Monitor], [Status], [AdmissionClass_Id], [Section_Id], [SectionName], [Last_School_Name], [SchoolBoard_Id], [Last_School_Year], [Last_School_Class], [School_Transfer_Certifiate_Number], [SchoolTransferCertificate_Name], [SchoolTransferCertificatePath], [Last_School_Exam_Marks], [Last_School_Total_Marks], [Last_School_Marks_Percentage], [FinalExamResult_Name], [FinalExamResultPath], [Board_Exam_Marks], [Board_Total_Marks], [Marks_Percentage], [Board_Certificate_Number], [BoardExamResultName], [BoardExamResultPath], [BoardExamCertificate_Name], [BoardExamCertificatePath], [ImagePath], [SignaturePath], [TermsAndConditions], [Application_Status], [Registration_Status]) VALUES (9, 2018, N'EN202013161549920', N'EC60JFWPWCVQ', N'Raghab', N'Saha', N'', N'sush@gmail.com', N'Marine@0', N'R Kumar', N'0700374821', N'sahaniloy24@gmail.com', N'A kumar', N'0898234546', N'raj@gmail.com', N'0700374821', N'Yes', N'P Saha', N'raj@gmail.com', N'0700374821', NULL, N'03/01/2020', N'kolkata', N'Ballygunge', N'', N'700039', NULL, NULL, NULL, NULL, N'Ballygunge', N'', N'700039', 1, 38, NULL, 1166, NULL, NULL, NULL, NULL, NULL, 4, N'changerequestfromchange20370658.php', NULL, 2, N'sretrytu', N'rererer434', 1, N'65hhh', NULL, 1, N'65', 1, N'40', N'desc', N'nb454', NULL, N'null', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 12, 2, N'B', N'Nabapally', 3, N'2001', N'ten', N'CER123555', NULL, N'f1e47792540d5d1d7657e04d54e96fb720075075.jpg', N'615', N'800', N'76.88', NULL, N'ERD_For_Attendance20075075.docx', N'null', NULL, N'null', N'null', NULL, N'null', NULL, N'null', N'varwwwclientsclient1web2tmpphp0y4IuD20161166.jpg', N'iso-metrics20161168.jpg', 1, N'Admitted', N'Yes')
INSERT [dbo].[School_Student_Details] ([Student_Id], [Parent_Id], [Application_Id], [School_Code], [first_name], [last_name], [middle_name], [Student_Email], [Password], [FatherName], [FatherContactNumber], [FatherEmail], [MotherName], [MotherContactNumber], [MotherEmail], [HomeContactNumber], [LocalGurdianValue], [LocalGurdianName], [LocalGurdianEmail], [LocalGurdianPhone], [Gender_Id], [DOB], [POB], [PermanentAddress1], [PermanentAddress2], [permanentzipcode], [PerCountryId], [Per_District], [PerStateId], [PerCityId], [CurrentAddress1], [CurrentAddress2], [currentzipcode], [CountryId], [StateId], [District], [CityId], [Zip], [Cur_Landmark], [Per_Landmark], [Email], [Phone], [BloodGroup_Id], [BirthCertificatePath], [BirthCertificate_Name], [IdProof_Id], [IdProof_Number], [Passport_Number], [CitizenCountryId], [BCN], [BCN_Attachment], [Special_Care], [Special_Care_Description], [Disability], [Disability_Percentage], [Disability_Description], [Disability_Certificate_Number], [DisabilityCertificat_Name], [DisabilityCertificatePath], [Caste], [Religion], [Special], [Details], [Physically_Hdc], [Hdc_Percent], [Is_Monitor], [Status], [AdmissionClass_Id], [Section_Id], [SectionName], [Last_School_Name], [SchoolBoard_Id], [Last_School_Year], [Last_School_Class], [School_Transfer_Certifiate_Number], [SchoolTransferCertificate_Name], [SchoolTransferCertificatePath], [Last_School_Exam_Marks], [Last_School_Total_Marks], [Last_School_Marks_Percentage], [FinalExamResult_Name], [FinalExamResultPath], [Board_Exam_Marks], [Board_Total_Marks], [Marks_Percentage], [Board_Certificate_Number], [BoardExamResultName], [BoardExamResultPath], [BoardExamCertificate_Name], [BoardExamCertificatePath], [ImagePath], [SignaturePath], [TermsAndConditions], [Application_Status], [Registration_Status]) VALUES (10, 2018, N'EN202013161549920', N'EC60JFWPWCVQ', N'Rana', N'Saha', N'', N'sush@gmail.com', N'Marine@0', N'R Kumar', N'0700374821', N'sahaniloy24@gmail.com', N'A kumar', N'0898234546', N'raj@gmail.com', N'0700374821', N'Yes', N'P Saha', N'raj@gmail.com', N'0700374821', NULL, N'03/01/2020', N'kolkata', N'Ballygunge', N'', N'700039', NULL, NULL, NULL, NULL, N'Ballygunge', N'', N'700039', 1, 38, NULL, 1166, NULL, NULL, NULL, NULL, NULL, 4, N'changerequestfromchange20370658.php', NULL, 2, N'sretrytu', N'rererer434', 1, N'65hhh', NULL, 1, N'65', 1, N'40', N'desc', N'nb454', NULL, N'null', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 12, 2, N'B', N'Nabapally', 3, N'2001', N'ten', N'CER123555', NULL, N'f1e47792540d5d1d7657e04d54e96fb720075075.jpg', N'615', N'800', N'76.88', NULL, N'ERD_For_Attendance20075075.docx', N'null', NULL, N'null', N'null', NULL, N'null', NULL, N'null', N'varwwwclientsclient1web2tmpphp0y4IuD20161166.jpg', N'iso-metrics20161168.jpg', 1, N'Admitted', N'Yes')
SET IDENTITY_INSERT [dbo].[School_Student_Details] OFF
SET IDENTITY_INSERT [dbo].[School_Subject_Master] ON 

INSERT [dbo].[School_Subject_Master] ([Subject_id], [School_Id], [School_Code], [School_Name], [Class_Id], [Subject_Type], [Subject_Name], [Priority_Value], [Exam_Sub_Type], [Subject_Code], [FullMarks], [PracticalMarks], [PassMarks], [AdditionalSubject], [Language_Preference], [Status]) VALUES (1, 3, N'EC60JFWPWCVQ', N'Delhi Public School', 12, NULL, N'Bengali', NULL, N'Theory', N'BN1001', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[School_Subject_Master] ([Subject_id], [School_Id], [School_Code], [School_Name], [Class_Id], [Subject_Type], [Subject_Name], [Priority_Value], [Exam_Sub_Type], [Subject_Code], [FullMarks], [PracticalMarks], [PassMarks], [AdditionalSubject], [Language_Preference], [Status]) VALUES (2, 3, N'EC60JFWPWCVQ', N'Delhi Public School', 12, NULL, N'English', NULL, N'Theory', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[School_Subject_Master] ([Subject_id], [School_Id], [School_Code], [School_Name], [Class_Id], [Subject_Type], [Subject_Name], [Priority_Value], [Exam_Sub_Type], [Subject_Code], [FullMarks], [PracticalMarks], [PassMarks], [AdditionalSubject], [Language_Preference], [Status]) VALUES (3, 3, N'EC60JFWPWCVQ', N'Delhi Public School', 12, NULL, N'Biology', NULL, N'Practical', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[School_Subject_Master] ([Subject_id], [School_Id], [School_Code], [School_Name], [Class_Id], [Subject_Type], [Subject_Name], [Priority_Value], [Exam_Sub_Type], [Subject_Code], [FullMarks], [PracticalMarks], [PassMarks], [AdditionalSubject], [Language_Preference], [Status]) VALUES (4, 3, N'EC60JFWPWCVQ', N'Delhi Public School', 12, NULL, N'Chemistry', NULL, N'Theory', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[School_Subject_Master] ([Subject_id], [School_Id], [School_Code], [School_Name], [Class_Id], [Subject_Type], [Subject_Name], [Priority_Value], [Exam_Sub_Type], [Subject_Code], [FullMarks], [PracticalMarks], [PassMarks], [AdditionalSubject], [Language_Preference], [Status]) VALUES (5, 3, N'EC60JFWPWCVQ', N'Delhi Public School', 12, NULL, N'Physics', NULL, N'Theory', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[School_Subject_Master] ([Subject_id], [School_Id], [School_Code], [School_Name], [Class_Id], [Subject_Type], [Subject_Name], [Priority_Value], [Exam_Sub_Type], [Subject_Code], [FullMarks], [PracticalMarks], [PassMarks], [AdditionalSubject], [Language_Preference], [Status]) VALUES (6, 4, N'EC60JFWPWCVQ', N'Delhi Public School', 12, NULL, N'Mathematics', NULL, N'Theory', NULL, NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[School_Subject_Master] ([Subject_id], [School_Id], [School_Code], [School_Name], [Class_Id], [Subject_Type], [Subject_Name], [Priority_Value], [Exam_Sub_Type], [Subject_Code], [FullMarks], [PracticalMarks], [PassMarks], [AdditionalSubject], [Language_Preference], [Status]) VALUES (7, 2, N'EC60JFWPWCVQ', N'Delhi Public School', 8, NULL, N'Sanskrit', NULL, N'Theory', N'SNC303', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[School_Subject_Master] ([Subject_id], [School_Id], [School_Code], [School_Name], [Class_Id], [Subject_Type], [Subject_Name], [Priority_Value], [Exam_Sub_Type], [Subject_Code], [FullMarks], [PracticalMarks], [PassMarks], [AdditionalSubject], [Language_Preference], [Status]) VALUES (8, 2, N'EC60JFWPWCVQ', N'Delhi Public School', 8, NULL, N'English', NULL, N'Theory', N'EN091', NULL, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[School_Subject_Master] ([Subject_id], [School_Id], [School_Code], [School_Name], [Class_Id], [Subject_Type], [Subject_Name], [Priority_Value], [Exam_Sub_Type], [Subject_Code], [FullMarks], [PracticalMarks], [PassMarks], [AdditionalSubject], [Language_Preference], [Status]) VALUES (9, 2, N'EC60JFWPWCVQ', N'Delhi Public School', 4, NULL, N'English', NULL, N'Theory', N'ENG101', 0, NULL, 0, NULL, NULL, NULL)
INSERT [dbo].[School_Subject_Master] ([Subject_id], [School_Id], [School_Code], [School_Name], [Class_Id], [Subject_Type], [Subject_Name], [Priority_Value], [Exam_Sub_Type], [Subject_Code], [FullMarks], [PracticalMarks], [PassMarks], [AdditionalSubject], [Language_Preference], [Status]) VALUES (10, 2, N'EC60JFWPWCVQ', N'Delhi Public School', 8, NULL, N'Geography', NULL, N'Theory', N'GEO120', 0, NULL, 150, NULL, NULL, NULL)
INSERT [dbo].[School_Subject_Master] ([Subject_id], [School_Id], [School_Code], [School_Name], [Class_Id], [Subject_Type], [Subject_Name], [Priority_Value], [Exam_Sub_Type], [Subject_Code], [FullMarks], [PracticalMarks], [PassMarks], [AdditionalSubject], [Language_Preference], [Status]) VALUES (11, 2, N'EC60JFWPWCVQ', N'Delhi Public School', 8, NULL, N'English', NULL, N'Theory', N'SNC303', 500, NULL, 300, NULL, NULL, NULL)
INSERT [dbo].[School_Subject_Master] ([Subject_id], [School_Id], [School_Code], [School_Name], [Class_Id], [Subject_Type], [Subject_Name], [Priority_Value], [Exam_Sub_Type], [Subject_Code], [FullMarks], [PracticalMarks], [PassMarks], [AdditionalSubject], [Language_Preference], [Status]) VALUES (12, 2, N'EC60JFWPWCVQ', N'Delhi Public School', 8, N'L', N'Bengali', 5, N'Theory', N'SNC303', 100, NULL, 60, NULL, NULL, NULL)
INSERT [dbo].[School_Subject_Master] ([Subject_id], [School_Id], [School_Code], [School_Name], [Class_Id], [Subject_Type], [Subject_Name], [Priority_Value], [Exam_Sub_Type], [Subject_Code], [FullMarks], [PracticalMarks], [PassMarks], [AdditionalSubject], [Language_Preference], [Status]) VALUES (13, 2, N'EC60JFWPWCVQ', N'Delhi Public School', 5, N'A', N'Bengali', 2, N'Theory', N'ENG101', 1000, NULL, 199, NULL, NULL, NULL)
INSERT [dbo].[School_Subject_Master] ([Subject_id], [School_Id], [School_Code], [School_Name], [Class_Id], [Subject_Type], [Subject_Name], [Priority_Value], [Exam_Sub_Type], [Subject_Code], [FullMarks], [PracticalMarks], [PassMarks], [AdditionalSubject], [Language_Preference], [Status]) VALUES (14, 2, N'EC60JFWPWCVQ', N'Delhi Public School', 5, N'L', N'Physics', 4, N'Practical', N'HIS101', 100, 20, 30, NULL, NULL, NULL)
INSERT [dbo].[School_Subject_Master] ([Subject_id], [School_Id], [School_Code], [School_Name], [Class_Id], [Subject_Type], [Subject_Name], [Priority_Value], [Exam_Sub_Type], [Subject_Code], [FullMarks], [PracticalMarks], [PassMarks], [AdditionalSubject], [Language_Preference], [Status]) VALUES (15, 2, N'EC60JFWPWCVQ', N'Delhi Public School', 9, N'L', N'Chemistry', 4, N'Practical', N'CHEM101', 100, 20, 30, NULL, NULL, NULL)
INSERT [dbo].[School_Subject_Master] ([Subject_id], [School_Id], [School_Code], [School_Name], [Class_Id], [Subject_Type], [Subject_Name], [Priority_Value], [Exam_Sub_Type], [Subject_Code], [FullMarks], [PracticalMarks], [PassMarks], [AdditionalSubject], [Language_Preference], [Status]) VALUES (16, 2, N'EC60JFWPWCVQ', N'Delhi Public School', 11, N'L', N'Geography', 4, N'Practical', N'GEO101', 100, 20, 30, NULL, NULL, NULL)
INSERT [dbo].[School_Subject_Master] ([Subject_id], [School_Id], [School_Code], [School_Name], [Class_Id], [Subject_Type], [Subject_Name], [Priority_Value], [Exam_Sub_Type], [Subject_Code], [FullMarks], [PracticalMarks], [PassMarks], [AdditionalSubject], [Language_Preference], [Status]) VALUES (17, 2, N'EC60JFWPWCVQ', N'Delhi Public School', 10, N'P', N'Mathematics', 4, N'Theory', N'MATH101', 100, 20, 30, NULL, NULL, NULL)
INSERT [dbo].[School_Subject_Master] ([Subject_id], [School_Id], [School_Code], [School_Name], [Class_Id], [Subject_Type], [Subject_Name], [Priority_Value], [Exam_Sub_Type], [Subject_Code], [FullMarks], [PracticalMarks], [PassMarks], [AdditionalSubject], [Language_Preference], [Status]) VALUES (1014, 2, N'EC60JFWPWCVQ', N'Delhi Public School', 11, N'L', N'Computer Science and Engineering', 2, N'Practical', N'COMP10-10', 80, 20, 30, NULL, NULL, NULL)
INSERT [dbo].[School_Subject_Master] ([Subject_id], [School_Id], [School_Code], [School_Name], [Class_Id], [Subject_Type], [Subject_Name], [Priority_Value], [Exam_Sub_Type], [Subject_Code], [FullMarks], [PracticalMarks], [PassMarks], [AdditionalSubject], [Language_Preference], [Status]) VALUES (1015, 2, N'EC60JFWPWCVQ', N'Delhi Public School', 12, N'A', N'Computer Science and Technology', 0, N'Practical', N'COMP1', 75, 25, 30, NULL, NULL, NULL)
INSERT [dbo].[School_Subject_Master] ([Subject_id], [School_Id], [School_Code], [School_Name], [Class_Id], [Subject_Type], [Subject_Name], [Priority_Value], [Exam_Sub_Type], [Subject_Code], [FullMarks], [PracticalMarks], [PassMarks], [AdditionalSubject], [Language_Preference], [Status]) VALUES (1016, 2, N'EC60JFWPWCVQ', N'Delhi Public School', 8, N'A', N'Computer Technology', 0, N'Practical', N'COMP102', 70, 30, 30, N'Yes', NULL, NULL)
INSERT [dbo].[School_Subject_Master] ([Subject_id], [School_Id], [School_Code], [School_Name], [Class_Id], [Subject_Type], [Subject_Name], [Priority_Value], [Exam_Sub_Type], [Subject_Code], [FullMarks], [PracticalMarks], [PassMarks], [AdditionalSubject], [Language_Preference], [Status]) VALUES (1017, 2, N'EC60JFWPWCVQ', N'Delhi Public School', 7, N'L', N'Computer Science and Engineering', 1, N'Practical', N'MATH101', 100, 100, 100, N'No', NULL, NULL)
INSERT [dbo].[School_Subject_Master] ([Subject_id], [School_Id], [School_Code], [School_Name], [Class_Id], [Subject_Type], [Subject_Name], [Priority_Value], [Exam_Sub_Type], [Subject_Code], [FullMarks], [PracticalMarks], [PassMarks], [AdditionalSubject], [Language_Preference], [Status]) VALUES (1018, 2, N'EC60JFWPWCVQ', N'Delhi Public School', 7, N'A', N'Computer Science and Technology', 0, N'Theory', N'com30', 100, 0, 30, N'Yes', NULL, NULL)
SET IDENTITY_INSERT [dbo].[School_Subject_Master] OFF
SET IDENTITY_INSERT [dbo].[School_User_Master] ON 

INSERT [dbo].[School_User_Master] ([Id], [User_Id], [User_Email], [User_Password], [School_Code], [School_Group_Code], [User_Type]) VALUES (4, 12, N'ani@gmail.com', N'Marine@0', N'HZXFDMKHFTK7', NULL, 1)
INSERT [dbo].[School_User_Master] ([Id], [User_Id], [User_Email], [User_Password], [School_Code], [School_Group_Code], [User_Type]) VALUES (5, 13, N'sahaniloy24@gmail.com', N'Marine@0', N'E3TQTHFGNEFI', NULL, 1)
INSERT [dbo].[School_User_Master] ([Id], [User_Id], [User_Email], [User_Password], [School_Code], [School_Group_Code], [User_Type]) VALUES (6, 10, N'sahaniloy24@gmail.com', N'2N8SNEQW', N'E3TQTHFGNEFI', NULL, 3)
INSERT [dbo].[School_User_Master] ([Id], [User_Id], [User_Email], [User_Password], [School_Code], [School_Group_Code], [User_Type]) VALUES (7, 14, N'shankhachatt@gmail.com', N'Marine@0', N'HZXFDMKHFTK7', NULL, 1)
INSERT [dbo].[School_User_Master] ([Id], [User_Id], [User_Email], [User_Password], [School_Code], [School_Group_Code], [User_Type]) VALUES (8, 16, N'prasenjit2005@gmail.com', N'Marine@1', N'JKIUR8CSCJZ1', NULL, 1)
INSERT [dbo].[School_User_Master] ([Id], [User_Id], [User_Email], [User_Password], [School_Code], [School_Group_Code], [User_Type]) VALUES (9, 11, N'prasenjit@gmail.com', N'&8I41SR4', N'HZXFDMKHFTK7', NULL, 3)
INSERT [dbo].[School_User_Master] ([Id], [User_Id], [User_Email], [User_Password], [School_Code], [School_Group_Code], [User_Type]) VALUES (10, 17, N'sahaniloy24@gmail.com', N'Marine@90', N'JKIUR8CSCJZ1', NULL, 1)
INSERT [dbo].[School_User_Master] ([Id], [User_Id], [User_Email], [User_Password], [School_Code], [School_Group_Code], [User_Type]) VALUES (11, 18, N'niloy@protistatech.com', N'Marine@0', N'JKIUR8CSCJZ1', NULL, 1)
INSERT [dbo].[School_User_Master] ([Id], [User_Id], [User_Email], [User_Password], [School_Code], [School_Group_Code], [User_Type]) VALUES (12, 19, N'niloy@protistatech.com', N'Marine@0', N'HZXFDMKHFTK7', NULL, 1)
INSERT [dbo].[School_User_Master] ([Id], [User_Id], [User_Email], [User_Password], [School_Code], [School_Group_Code], [User_Type]) VALUES (1011, 1018, N'sahaniloy24@gmail.com', N'Marine@0', N'E3TQTHFGNEFI', NULL, 1)
INSERT [dbo].[School_User_Master] ([Id], [User_Id], [User_Email], [User_Password], [School_Code], [School_Group_Code], [User_Type]) VALUES (1012, 12, N'sahaniloy24@gmail.com', N'TBWIL92E', N'E3TQTHFGNEFI', NULL, 3)
INSERT [dbo].[School_User_Master] ([Id], [User_Id], [User_Email], [User_Password], [School_Code], [School_Group_Code], [User_Type]) VALUES (1013, 13, N'sahaniloy24@gmail.com', N'Marine@0', N'E3TQTHFGNEFI', NULL, 3)
INSERT [dbo].[School_User_Master] ([Id], [User_Id], [User_Email], [User_Password], [School_Code], [School_Group_Code], [User_Type]) VALUES (1014, 14, N'niloy@gmail.com', N'WA1A8J3T', N'E3TQTHFGNEFI', NULL, 3)
INSERT [dbo].[School_User_Master] ([Id], [User_Id], [User_Email], [User_Password], [School_Code], [School_Group_Code], [User_Type]) VALUES (1015, 1, N'animesh@gmail.com', N'Marine@0', N'E3TQTHFGNEFI', NULL, 2)
INSERT [dbo].[School_User_Master] ([Id], [User_Id], [User_Email], [User_Password], [School_Code], [School_Group_Code], [User_Type]) VALUES (1016, 15, N'anik@gmail.com', N'Marine@0', N'E3TQTHFGNEFI', NULL, 3)
INSERT [dbo].[School_User_Master] ([Id], [User_Id], [User_Email], [User_Password], [School_Code], [School_Group_Code], [User_Type]) VALUES (2011, 2, N'sahaniloy24@gmail.com', N'Marine@0', N'E3TQTHFGNEFI', NULL, 2)
INSERT [dbo].[School_User_Master] ([Id], [User_Id], [User_Email], [User_Password], [School_Code], [School_Group_Code], [User_Type]) VALUES (2012, 1, N'sahaniloy24@gmail.com', N'Marine@0', N'E3TQTHFGNEFI', NULL, 2)
INSERT [dbo].[School_User_Master] ([Id], [User_Id], [User_Email], [User_Password], [School_Code], [School_Group_Code], [User_Type]) VALUES (2013, 2, N'sahaniloy24@gmail.com', N'Marine@0', N'E3TQTHFGNEFI', NULL, 2)
INSERT [dbo].[School_User_Master] ([Id], [User_Id], [User_Email], [User_Password], [School_Code], [School_Group_Code], [User_Type]) VALUES (2014, 1, N'animesh@gmail.com', N'Marine@0', N'E3TQTHFGNEFI', NULL, 2)
INSERT [dbo].[School_User_Master] ([Id], [User_Id], [User_Email], [User_Password], [School_Code], [School_Group_Code], [User_Type]) VALUES (2015, 2, N'sahaniloy25@gmail.com', N'Marine@0', N'E3TQTHFGNEFI', NULL, 2)
INSERT [dbo].[School_User_Master] ([Id], [User_Id], [User_Email], [User_Password], [School_Code], [School_Group_Code], [User_Type]) VALUES (2016, 2018, N'sahaniloy90@gmail.com', N'Marine@0', N'EC60JFWPWCVQ', N'400', 1)
INSERT [dbo].[School_User_Master] ([Id], [User_Id], [User_Email], [User_Password], [School_Code], [School_Group_Code], [User_Type]) VALUES (2017, 1012, N'sahaniloy81@gmail.com', N'Marine@9', N'EC60JFWPWCVQ', N'400', 3)
INSERT [dbo].[School_User_Master] ([Id], [User_Id], [User_Email], [User_Password], [School_Code], [School_Group_Code], [User_Type]) VALUES (2018, 5, N'sahaniloy82@gmail.com', N'Marine@0', N'EC60JFWPWCVQ', N'400', 2)
INSERT [dbo].[School_User_Master] ([Id], [User_Id], [User_Email], [User_Password], [School_Code], [School_Group_Code], [User_Type]) VALUES (2019, 2019, N'palash@gmail.com', N'Marine@0', N'057KLZQ6Q68F', NULL, 1)
INSERT [dbo].[School_User_Master] ([Id], [User_Id], [User_Email], [User_Password], [School_Code], [School_Group_Code], [User_Type]) VALUES (2020, 1013, N'ani200@gmail.com', N'Marine@0', N'057KLZQ6Q68F', NULL, 3)
INSERT [dbo].[School_User_Master] ([Id], [User_Id], [User_Email], [User_Password], [School_Code], [School_Group_Code], [User_Type]) VALUES (2021, 6, N'raj@gmail.com', N'Marine@0', N'057KLZQ6Q68F', NULL, 2)
INSERT [dbo].[School_User_Master] ([Id], [User_Id], [User_Email], [User_Password], [School_Code], [School_Group_Code], [User_Type]) VALUES (3015, 2012, N'lagnajit@gmail.com', N'Marine@7', N'EC60JFWPWCVQ', N'400', 3)
INSERT [dbo].[School_User_Master] ([Id], [User_Id], [User_Email], [User_Password], [School_Code], [School_Group_Code], [User_Type]) VALUES (3016, 2020, N'animesh11@gmail.com', N'Marine@1', N'ZVX5OGG335O4', NULL, 1)
INSERT [dbo].[School_User_Master] ([Id], [User_Id], [User_Email], [User_Password], [School_Code], [School_Group_Code], [User_Type]) VALUES (3017, 2021, N'sukk@gmail.com', N'Marine@1', N'ZVX5OGG335O4', NULL, 1)
INSERT [dbo].[School_User_Master] ([Id], [User_Id], [User_Email], [User_Password], [School_Code], [School_Group_Code], [User_Type]) VALUES (3018, 2022, N'test20@gmail.com', N'Marine@1', N'E3TQTHFGNEFI', NULL, 1)
INSERT [dbo].[School_User_Master] ([Id], [User_Id], [User_Email], [User_Password], [School_Code], [School_Group_Code], [User_Type]) VALUES (3019, 2023, N'test20@gmail.com', N'Marine@1', N'E3TQTHFGNEFI', NULL, 1)
INSERT [dbo].[School_User_Master] ([Id], [User_Id], [User_Email], [User_Password], [School_Code], [School_Group_Code], [User_Type]) VALUES (3020, 2024, N'parenttest20@gmail.com', N'Marine@1', N'E3TQTHFGNEFI', NULL, 1)
INSERT [dbo].[School_User_Master] ([Id], [User_Id], [User_Email], [User_Password], [School_Code], [School_Group_Code], [User_Type]) VALUES (4016, 9, N'sush@gmail.com', N'Marine@0', N'EC60JFWPWCVQ', N'400', 2)
SET IDENTITY_INSERT [dbo].[School_User_Master] OFF
SET IDENTITY_INSERT [dbo].[School_User_Type_Master] ON 

INSERT [dbo].[School_User_Type_Master] ([User_Type_Id], [User_Type_Name]) VALUES (1, N'Parent')
INSERT [dbo].[School_User_Type_Master] ([User_Type_Id], [User_Type_Name]) VALUES (2, N'Student')
INSERT [dbo].[School_User_Type_Master] ([User_Type_Id], [User_Type_Name]) VALUES (3, N'Employee')
INSERT [dbo].[School_User_Type_Master] ([User_Type_Id], [User_Type_Name]) VALUES (4, N'School_Admin')
SET IDENTITY_INSERT [dbo].[School_User_Type_Master] OFF
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (4, 1, N'Maharashtra')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (5, 1, N'Andaman & Nicobar Islands')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (6, 1, N'Andhra Pradesh')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (7, 1, N'Arunachal Pradesh')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (8, 1, N'Assam')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (9, 1, N'Bihar')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (10, 1, N'Chhattisgarh')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (11, 1, N'Dadra & Nagar Haveli')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (12, 1, N'Daman & Diu')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (13, 1, N'Delhi')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (14, 1, N'Goa')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (15, 1, N'Gujarat')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (16, 1, N' India')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (17, 1, N'Gujrat')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (18, 1, N'Hariyana')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (19, 1, N'Haryana')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (20, 1, N'Himachal Pradesh')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (21, 1, N'Jammu & Kashmir')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (22, 1, N'Jharkhand')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (23, 1, N'Karnataka')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (24, 1, N'Kerala')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (25, 1, N'Lakshadweep')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (26, 1, N'Madhya Pradesh')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (27, 1, N'Maharastra')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (28, 1, N'Manipur')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (29, 1, N'Meghalaya')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (30, 1, N'Mizoram')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (31, 1, N'Nagaland')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (32, 1, N'Orissa')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (33, 1, N'Pondicherry')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (34, 1, N'Punjab')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (35, 1, N'Rajasthan')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (36, 1, N'Rajastan')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (37, 1, N'Sikkim')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (38, 1, N'West Bengal')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (39, 1, N'Tamil Nadu')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (40, 1, N'Tripura')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (41, 1, N'Uttar Pradesh')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (42, 1, N' Ghazipur')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (43, 1, N' Hardoi')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (44, 1, N' Rampur')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (45, 1, N' Agra')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (46, 1, N' Farrukhabad')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (47, 1, N' Bulandshahr')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (48, 1, N'Uttarakhand')
INSERT [dbo].[state] ([StateId], [CountryId], [StateName]) VALUES (49, 1, N' Purulia')
SET IDENTITY_INSERT [dbo].[Student_Attendance] ON 

INSERT [dbo].[Student_Attendance] ([Att_Id], [Session_Year], [School_Code], [Student_Id], [Class_Id], [Section_Id], [Period_Date], [Subject_Id], [Period_Id], [Presence_Status]) VALUES (1, N'2020', N'EC60JFWPWCVQ', 3, 10, 1, N'2020-03-19', NULL, 1, N'Present')
INSERT [dbo].[Student_Attendance] ([Att_Id], [Session_Year], [School_Code], [Student_Id], [Class_Id], [Section_Id], [Period_Date], [Subject_Id], [Period_Id], [Presence_Status]) VALUES (2, N'2020', N'EC60JFWPWCVQ', 6, 10, 1, N'2020-03-19', NULL, 1, N'Present')
INSERT [dbo].[Student_Attendance] ([Att_Id], [Session_Year], [School_Code], [Student_Id], [Class_Id], [Section_Id], [Period_Date], [Subject_Id], [Period_Id], [Presence_Status]) VALUES (3, N'2020', N'EC60JFWPWCVQ', 3, 10, 1, N'2020-03-19', NULL, 1, N'Present')
INSERT [dbo].[Student_Attendance] ([Att_Id], [Session_Year], [School_Code], [Student_Id], [Class_Id], [Section_Id], [Period_Date], [Subject_Id], [Period_Id], [Presence_Status]) VALUES (4, N'2020', N'EC60JFWPWCVQ', 6, 10, 1, N'2020-03-19', NULL, 1, N'Present')
INSERT [dbo].[Student_Attendance] ([Att_Id], [Session_Year], [School_Code], [Student_Id], [Class_Id], [Section_Id], [Period_Date], [Subject_Id], [Period_Id], [Presence_Status]) VALUES (5, N'2020', N'EC60JFWPWCVQ', 3, 10, 1, N'2020-03-25', NULL, 1, N'Absent')
INSERT [dbo].[Student_Attendance] ([Att_Id], [Session_Year], [School_Code], [Student_Id], [Class_Id], [Section_Id], [Period_Date], [Subject_Id], [Period_Id], [Presence_Status]) VALUES (6, N'2020', N'EC60JFWPWCVQ', 6, 10, 1, N'2020-03-25', NULL, 1, N'Absent')
SET IDENTITY_INSERT [dbo].[Student_Attendance] OFF
SET IDENTITY_INSERT [dbo].[Student_Fees_Master] ON 

INSERT [dbo].[Student_Fees_Master] ([F_id], [School_Code], [School_Id], [Student_Id], [Fees_Id], [Class_Id], [Fees_Name], [Fees_Desc], [Amount], [Fees_Year], [Paid_Status], [remark_note]) VALUES (1, N'HZXFDMKHFTK7', N'0', 4, 1, N'12', N'Admission Fees', N'Admission Fee', N'2000', N'0', NULL, NULL)
INSERT [dbo].[Student_Fees_Master] ([F_id], [School_Code], [School_Id], [Student_Id], [Fees_Id], [Class_Id], [Fees_Name], [Fees_Desc], [Amount], [Fees_Year], [Paid_Status], [remark_note]) VALUES (2, N'HZXFDMKHFTK7', N'0', 4, 2, N'12', N'Exam Fees', N'Exam Fees', N'2000', N'0', NULL, NULL)
INSERT [dbo].[Student_Fees_Master] ([F_id], [School_Code], [School_Id], [Student_Id], [Fees_Id], [Class_Id], [Fees_Name], [Fees_Desc], [Amount], [Fees_Year], [Paid_Status], [remark_note]) VALUES (3, N'HZXFDMKHFTK7', N'0', 4, 1, N'12', N'Admission Fees', N'Admission Fee', N'2000', N'0', NULL, NULL)
INSERT [dbo].[Student_Fees_Master] ([F_id], [School_Code], [School_Id], [Student_Id], [Fees_Id], [Class_Id], [Fees_Name], [Fees_Desc], [Amount], [Fees_Year], [Paid_Status], [remark_note]) VALUES (4, N'HZXFDMKHFTK7', N'0', 4, 2, N'12', N'Exam Fees', N'Exam Fees', N'2000', N'0', NULL, NULL)
INSERT [dbo].[Student_Fees_Master] ([F_id], [School_Code], [School_Id], [Student_Id], [Fees_Id], [Class_Id], [Fees_Name], [Fees_Desc], [Amount], [Fees_Year], [Paid_Status], [remark_note]) VALUES (5, N'HZXFDMKHFTK7', N'0', 4, 1, N'12', N'Admission Fees', N'Admission Fee', N'2000', N'0', NULL, N'null')
INSERT [dbo].[Student_Fees_Master] ([F_id], [School_Code], [School_Id], [Student_Id], [Fees_Id], [Class_Id], [Fees_Name], [Fees_Desc], [Amount], [Fees_Year], [Paid_Status], [remark_note]) VALUES (6, N'HZXFDMKHFTK7', N'0', 4, 2, N'12', N'Exam Fees', N'Exam Fees', N'2000', N'0', NULL, N'null')
INSERT [dbo].[Student_Fees_Master] ([F_id], [School_Code], [School_Id], [Student_Id], [Fees_Id], [Class_Id], [Fees_Name], [Fees_Desc], [Amount], [Fees_Year], [Paid_Status], [remark_note]) VALUES (7, N'HZXFDMKHFTK7', N'0', 4, 1, N'12', N'Admission Fees', N'Admission Fee', N'2000', N'0', NULL, N'null')
INSERT [dbo].[Student_Fees_Master] ([F_id], [School_Code], [School_Id], [Student_Id], [Fees_Id], [Class_Id], [Fees_Name], [Fees_Desc], [Amount], [Fees_Year], [Paid_Status], [remark_note]) VALUES (8, N'HZXFDMKHFTK7', N'0', 4, 2, N'12', N'Exam Fees', N'Exam Fees', N'2000', N'0', NULL, N'null')
INSERT [dbo].[Student_Fees_Master] ([F_id], [School_Code], [School_Id], [Student_Id], [Fees_Id], [Class_Id], [Fees_Name], [Fees_Desc], [Amount], [Fees_Year], [Paid_Status], [remark_note]) VALUES (9, N'HZXFDMKHFTK7', N'0', 4, 1, N'12', N'Admission Fees', N'Admission Fee', N'2000', N'0', NULL, N'null')
INSERT [dbo].[Student_Fees_Master] ([F_id], [School_Code], [School_Id], [Student_Id], [Fees_Id], [Class_Id], [Fees_Name], [Fees_Desc], [Amount], [Fees_Year], [Paid_Status], [remark_note]) VALUES (10, N'HZXFDMKHFTK7', N'0', 4, 2, N'12', N'Exam Fees', N'Exam Fees', N'2000', N'0', NULL, N'null')
INSERT [dbo].[Student_Fees_Master] ([F_id], [School_Code], [School_Id], [Student_Id], [Fees_Id], [Class_Id], [Fees_Name], [Fees_Desc], [Amount], [Fees_Year], [Paid_Status], [remark_note]) VALUES (11, N'HZXFDMKHFTK7', N'0', 4, 1, N'12', N'Admission Fees', N'Admission Fee', N'2000', N'0', N'un-paid', N'null')
INSERT [dbo].[Student_Fees_Master] ([F_id], [School_Code], [School_Id], [Student_Id], [Fees_Id], [Class_Id], [Fees_Name], [Fees_Desc], [Amount], [Fees_Year], [Paid_Status], [remark_note]) VALUES (12, N'HZXFDMKHFTK7', N'0', 4, 2, N'12', N'Exam Fees', N'Exam Fees', N'2000', N'0', N'un-paid', N'null')
INSERT [dbo].[Student_Fees_Master] ([F_id], [School_Code], [School_Id], [Student_Id], [Fees_Id], [Class_Id], [Fees_Name], [Fees_Desc], [Amount], [Fees_Year], [Paid_Status], [remark_note]) VALUES (13, N'HZXFDMKHFTK7', N'0', 3, 1, N'12', N'Admission Fees', N'Admission Fee', N'2000', N'0', N'un-paid', N'null')
INSERT [dbo].[Student_Fees_Master] ([F_id], [School_Code], [School_Id], [Student_Id], [Fees_Id], [Class_Id], [Fees_Name], [Fees_Desc], [Amount], [Fees_Year], [Paid_Status], [remark_note]) VALUES (14, N'HZXFDMKHFTK7', N'0', 3, 2, N'12', N'Exam Fees', N'Exam Fees', N'2000', N'0', N'un-paid', N'null')
INSERT [dbo].[Student_Fees_Master] ([F_id], [School_Code], [School_Id], [Student_Id], [Fees_Id], [Class_Id], [Fees_Name], [Fees_Desc], [Amount], [Fees_Year], [Paid_Status], [remark_note]) VALUES (15, N'HZXFDMKHFTK7', N'0', 4, 1, N'12', N'Admission Fees', N'Admission Fee', N'2000', N'0', N'un-paid', N'null')
INSERT [dbo].[Student_Fees_Master] ([F_id], [School_Code], [School_Id], [Student_Id], [Fees_Id], [Class_Id], [Fees_Name], [Fees_Desc], [Amount], [Fees_Year], [Paid_Status], [remark_note]) VALUES (16, N'HZXFDMKHFTK7', N'0', 4, 2, N'12', N'Exam Fees', N'Exam Fees', N'2000', N'0', N'paid', N'null')
INSERT [dbo].[Student_Fees_Master] ([F_id], [School_Code], [School_Id], [Student_Id], [Fees_Id], [Class_Id], [Fees_Name], [Fees_Desc], [Amount], [Fees_Year], [Paid_Status], [remark_note]) VALUES (1011, N'E3TQTHFGNEFI', N'0', 7, 1002, N'12', N'Admission Fees', N'Sport Description', N'2000', N'0', N'un-paid', N'null')
INSERT [dbo].[Student_Fees_Master] ([F_id], [School_Code], [School_Id], [Student_Id], [Fees_Id], [Class_Id], [Fees_Name], [Fees_Desc], [Amount], [Fees_Year], [Paid_Status], [remark_note]) VALUES (1012, N'E3TQTHFGNEFI', N'0', 7, 1003, N'12', N'Exam Fees', N'Sport Description', N'2000', N'0', N'un-paid', N'null')
INSERT [dbo].[Student_Fees_Master] ([F_id], [School_Code], [School_Id], [Student_Id], [Fees_Id], [Class_Id], [Fees_Name], [Fees_Desc], [Amount], [Fees_Year], [Paid_Status], [remark_note]) VALUES (2011, N'EC60JFWPWCVQ', N'0', 2021, 2003, N'5', N'Admission Fees', N'admission fees dec', N'2000', N'0', N'paid', N'null')
INSERT [dbo].[Student_Fees_Master] ([F_id], [School_Code], [School_Id], [Student_Id], [Fees_Id], [Class_Id], [Fees_Name], [Fees_Desc], [Amount], [Fees_Year], [Paid_Status], [remark_note]) VALUES (2012, N'EC60JFWPWCVQ', N'0', 2021, 2003, N'5', N'Admission Fees', N'admission fees dec', N'2000', N'0', N'paid', N'null')
INSERT [dbo].[Student_Fees_Master] ([F_id], [School_Code], [School_Id], [Student_Id], [Fees_Id], [Class_Id], [Fees_Name], [Fees_Desc], [Amount], [Fees_Year], [Paid_Status], [remark_note]) VALUES (2013, N'057KLZQ6Q68F', N'0', 2023, 2004, N'12', N'Admission Fees', N'admission fees dec', N'5000', N'0', N'paid', N'null')
INSERT [dbo].[Student_Fees_Master] ([F_id], [School_Code], [School_Id], [Student_Id], [Fees_Id], [Class_Id], [Fees_Name], [Fees_Desc], [Amount], [Fees_Year], [Paid_Status], [remark_note]) VALUES (2014, N'EC60JFWPWCVQ', N'0', 2025, 3003, N'9', N'Exam Fees', N'Sport DescriptionS', N'2011', N'0', N'paid', N'null')
INSERT [dbo].[Student_Fees_Master] ([F_id], [School_Code], [School_Id], [Student_Id], [Fees_Id], [Class_Id], [Fees_Name], [Fees_Desc], [Amount], [Fees_Year], [Paid_Status], [remark_note]) VALUES (2015, N'EC60JFWPWCVQ', N'0', 2025, 3004, N'9', N'Admission Fees', N'Sport Description', N'2011', N'0', N'paid', N'null')
INSERT [dbo].[Student_Fees_Master] ([F_id], [School_Code], [School_Id], [Student_Id], [Fees_Id], [Class_Id], [Fees_Name], [Fees_Desc], [Amount], [Fees_Year], [Paid_Status], [remark_note]) VALUES (2016, N'EC60JFWPWCVQ', N'0', 2024, 3003, N'9', N'Exam Fees', N'Sport DescriptionS', N'2011', N'0', N'un-paid', N'null')
INSERT [dbo].[Student_Fees_Master] ([F_id], [School_Code], [School_Id], [Student_Id], [Fees_Id], [Class_Id], [Fees_Name], [Fees_Desc], [Amount], [Fees_Year], [Paid_Status], [remark_note]) VALUES (2017, N'EC60JFWPWCVQ', N'0', 2024, 3004, N'9', N'Admission Fees', N'Sport Description', N'2011', N'0', N'paid', N'null')
SET IDENTITY_INSERT [dbo].[Student_Fees_Master] OFF
SET IDENTITY_INSERT [dbo].[Student_Homework] ON 

INSERT [dbo].[Student_Homework] ([ID], [Student_ID], [Teacher_ID], [Assigned_Date], [Due_Date], [Subm_Date], [Subject_ID], [Description], [Status], [Class_ID], [Section_ID], [Topic], [File_Name], [File_Path]) VALUES (1, 6, 2, CAST(N'2020-08-09' AS Date), CAST(N'2020-08-09' AS Date), CAST(N'2020-08-09' AS Date), 2, N'Text', N'true', 2, 2, N'topic', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Student_Homework] OFF
SET IDENTITY_INSERT [dbo].[Student_Master] ON 

INSERT [dbo].[Student_Master] ([Student_Id], [Parent_Id], [School_Code], [Application_Id], [first_name], [last_name], [middle_name], [FatherName], [FatherContactNumber], [FatherEmail], [MotherName], [MotherContactNumber], [MotherEmail], [HomeContactNumber], [LocalGurdianValue], [LocalGurdianName], [LocalGurdianEmail], [LocalGurdianPhone], [Gender_Id], [DOB], [POB], [PermanentAddress1], [PermanentAddress2], [permanentzipcode], [PerCountryId], [Per_District], [PerStateId], [PerCityId], [CurrentAddress1], [CurrentAddress2], [currentzipcode], [CountryId], [StateId], [District], [CityId], [Zip], [Cur_Landmark], [Per_Landmark], [Email], [Phone], [BloodGroup_Id], [BirthCertificate_Name], [BirthCertificatePath], [IdProof_Id], [IdProof_Number], [Passport_Number], [CitizenCountryId], [BCN], [BCN_Attachment_Name], [BCN_Attachment], [Special_Care], [Special_Care_Description], [Disability], [Disability_Percentage], [Disability_Description], [Disability_Certificate_Number], [DisabilityCertificat_Name], [DisabilityCertificatePath], [Caste], [Religion], [Special], [Physically_Hdc], [Hdc_Percent], [Is_Monitor], [Status], [AdmissionClass_Id], [Last_School_Name], [SchoolBoard_Id], [Last_School_Year], [Last_School_Class], [School_Transfer_Certifiate_Number], [SchoolTransferCertificate_Name], [SchoolTransferCertificatePath], [Last_School_Exam_Marks], [Last_School_Total_Marks], [Last_School_Marks_Percentage], [FinalExamResult_Name], [FinalExamResultPath], [Board_Exam_Marks], [Board_Total_Marks], [Marks_Percentage], [Board_Certificate_Number], [BoardExamResultName], [BoardExamResultPath], [BoardExamCertificate_Name], [BoardExamCertificatePath], [ImagePath], [SignaturePath], [Step_Complete], [TermsAndConditions], [Application_Status], [interview_note]) VALUES (1, 17, N'JKIUR8CSCJZ1', N'EN201931192552270', N'Niloy', N'Saha5', N'', N'Prakassh', N'9876543210', N'abc@gmail.com', N'L . Ray', N'1234567895', N'palas@gmail.com', N'9876543000', N'No', N'null', N'null', N'null', NULL, N'23/03/2019', N'Kolkata', N'28/7 New Ballygunge Road', N' Kolkata-700039', N'700126', NULL, NULL, NULL, NULL, N'28/7 New Ballygunge Road d', N' Kolkata-700039', N'700126', 1, 38, NULL, 1166, NULL, NULL, NULL, NULL, NULL, 6, NULL, N'ERD_Exam_Schedule19184040.docx', 2, N'12345687nbb', N'123456588', 1, N'987654310', NULL, NULL, 1, N'4566', 1, N'70', N'Disability Desc Description', N'DESC123456', NULL, N'ERD_For_Attendance19184040.docx', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 12, N'Nabapally Boys School', 3, N'2004', N'Eleven', N'58666666', NULL, N'null', N'', N'AdmissionClass_Id', N'', NULL, N'null', N'615', NULL, N'175.71', N'Bordcer123456', NULL, N'ERD_For_Attendance19353971.docx', NULL, N'ERD_Exam_Schedule19353971.docx', N'~/AppFiles/Images/Yellowstone National Park 0119174910.jpg', N'~/AppFiles/Images/park-0119174910.jpg', N'Step1', NULL, N'In-Progress', NULL)
INSERT [dbo].[Student_Master] ([Student_Id], [Parent_Id], [School_Code], [Application_Id], [first_name], [last_name], [middle_name], [FatherName], [FatherContactNumber], [FatherEmail], [MotherName], [MotherContactNumber], [MotherEmail], [HomeContactNumber], [LocalGurdianValue], [LocalGurdianName], [LocalGurdianEmail], [LocalGurdianPhone], [Gender_Id], [DOB], [POB], [PermanentAddress1], [PermanentAddress2], [permanentzipcode], [PerCountryId], [Per_District], [PerStateId], [PerCityId], [CurrentAddress1], [CurrentAddress2], [currentzipcode], [CountryId], [StateId], [District], [CityId], [Zip], [Cur_Landmark], [Per_Landmark], [Email], [Phone], [BloodGroup_Id], [BirthCertificate_Name], [BirthCertificatePath], [IdProof_Id], [IdProof_Number], [Passport_Number], [CitizenCountryId], [BCN], [BCN_Attachment_Name], [BCN_Attachment], [Special_Care], [Special_Care_Description], [Disability], [Disability_Percentage], [Disability_Description], [Disability_Certificate_Number], [DisabilityCertificat_Name], [DisabilityCertificatePath], [Caste], [Religion], [Special], [Physically_Hdc], [Hdc_Percent], [Is_Monitor], [Status], [AdmissionClass_Id], [Last_School_Name], [SchoolBoard_Id], [Last_School_Year], [Last_School_Class], [School_Transfer_Certifiate_Number], [SchoolTransferCertificate_Name], [SchoolTransferCertificatePath], [Last_School_Exam_Marks], [Last_School_Total_Marks], [Last_School_Marks_Percentage], [FinalExamResult_Name], [FinalExamResultPath], [Board_Exam_Marks], [Board_Total_Marks], [Marks_Percentage], [Board_Certificate_Number], [BoardExamResultName], [BoardExamResultPath], [BoardExamCertificate_Name], [BoardExamCertificatePath], [ImagePath], [SignaturePath], [Step_Complete], [TermsAndConditions], [Application_Status], [interview_note]) VALUES (2, 17, N'JKIUR8CSCJZ1', N'EN201931201523206', N'Niloy', N'Saha5', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'No', NULL, NULL, NULL, NULL, N'23/03/2019', N'Kolkata', N'28/7 New Ballygunge Road', N' Kolkata-700039', N'700126', NULL, NULL, NULL, NULL, N'28/7 New Ballygunge Road d', N' Kolkata-700039', N'700126', 1, 38, NULL, 1166, NULL, NULL, NULL, NULL, NULL, 6, NULL, N'ERD_Exam_Schedule19184040.docx', 2, N'12345687nbb', N'123456588', 1, N'987654310', NULL, NULL, 1, N'4566', 1, N'70', N'Disability Desc Description', N'DESC123456', NULL, N'ERD_For_Attendance19184040.docx', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 12, NULL, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'~/AppFiles/Images/Yellowstone National Park 0119174910.jpg', N'~/AppFiles/Images/Yellowstone National Park 0119174910.jpg', N'Step1', NULL, N'In-Progress', NULL)
INSERT [dbo].[Student_Master] ([Student_Id], [Parent_Id], [School_Code], [Application_Id], [first_name], [last_name], [middle_name], [FatherName], [FatherContactNumber], [FatherEmail], [MotherName], [MotherContactNumber], [MotherEmail], [HomeContactNumber], [LocalGurdianValue], [LocalGurdianName], [LocalGurdianEmail], [LocalGurdianPhone], [Gender_Id], [DOB], [POB], [PermanentAddress1], [PermanentAddress2], [permanentzipcode], [PerCountryId], [Per_District], [PerStateId], [PerCityId], [CurrentAddress1], [CurrentAddress2], [currentzipcode], [CountryId], [StateId], [District], [CityId], [Zip], [Cur_Landmark], [Per_Landmark], [Email], [Phone], [BloodGroup_Id], [BirthCertificate_Name], [BirthCertificatePath], [IdProof_Id], [IdProof_Number], [Passport_Number], [CitizenCountryId], [BCN], [BCN_Attachment_Name], [BCN_Attachment], [Special_Care], [Special_Care_Description], [Disability], [Disability_Percentage], [Disability_Description], [Disability_Certificate_Number], [DisabilityCertificat_Name], [DisabilityCertificatePath], [Caste], [Religion], [Special], [Physically_Hdc], [Hdc_Percent], [Is_Monitor], [Status], [AdmissionClass_Id], [Last_School_Name], [SchoolBoard_Id], [Last_School_Year], [Last_School_Class], [School_Transfer_Certifiate_Number], [SchoolTransferCertificate_Name], [SchoolTransferCertificatePath], [Last_School_Exam_Marks], [Last_School_Total_Marks], [Last_School_Marks_Percentage], [FinalExamResult_Name], [FinalExamResultPath], [Board_Exam_Marks], [Board_Total_Marks], [Marks_Percentage], [Board_Certificate_Number], [BoardExamResultName], [BoardExamResultPath], [BoardExamCertificate_Name], [BoardExamCertificatePath], [ImagePath], [SignaturePath], [Step_Complete], [TermsAndConditions], [Application_Status], [interview_note]) VALUES (3, 17, N'HZXFDMKHFTK7', N'EN201931201528950', N'Niloy', N'Saha5', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'No', NULL, NULL, NULL, NULL, N'23/03/2019', N'Kolkata', N'28/7 New Ballygunge Road', N' Kolkata-700039', N'700126', NULL, NULL, NULL, NULL, N'28/7 New Ballygunge Road d', N' Kolkata-700039', N'700126', 1, 38, NULL, 1166, NULL, NULL, NULL, NULL, NULL, 6, NULL, N'ERD_Exam_Schedule19184040.docx', 2, N'12345687nbb', N'123456588', 1, N'987654310', NULL, NULL, 1, N'4566', 1, N'70', N'Disability Desc Description', N'DESC123456', NULL, N'ERD_For_Attendance19184040.docx', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 12, NULL, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'~/AppFiles/Images/Yellowstone National Park 0119174910.jpg', N'~/AppFiles/Images/Yellowstone National Park 0119174910.jpg', N'Step1', NULL, N'Eligible-Admission', NULL)
INSERT [dbo].[Student_Master] ([Student_Id], [Parent_Id], [School_Code], [Application_Id], [first_name], [last_name], [middle_name], [FatherName], [FatherContactNumber], [FatherEmail], [MotherName], [MotherContactNumber], [MotherEmail], [HomeContactNumber], [LocalGurdianValue], [LocalGurdianName], [LocalGurdianEmail], [LocalGurdianPhone], [Gender_Id], [DOB], [POB], [PermanentAddress1], [PermanentAddress2], [permanentzipcode], [PerCountryId], [Per_District], [PerStateId], [PerCityId], [CurrentAddress1], [CurrentAddress2], [currentzipcode], [CountryId], [StateId], [District], [CityId], [Zip], [Cur_Landmark], [Per_Landmark], [Email], [Phone], [BloodGroup_Id], [BirthCertificate_Name], [BirthCertificatePath], [IdProof_Id], [IdProof_Number], [Passport_Number], [CitizenCountryId], [BCN], [BCN_Attachment_Name], [BCN_Attachment], [Special_Care], [Special_Care_Description], [Disability], [Disability_Percentage], [Disability_Description], [Disability_Certificate_Number], [DisabilityCertificat_Name], [DisabilityCertificatePath], [Caste], [Religion], [Special], [Physically_Hdc], [Hdc_Percent], [Is_Monitor], [Status], [AdmissionClass_Id], [Last_School_Name], [SchoolBoard_Id], [Last_School_Year], [Last_School_Class], [School_Transfer_Certifiate_Number], [SchoolTransferCertificate_Name], [SchoolTransferCertificatePath], [Last_School_Exam_Marks], [Last_School_Total_Marks], [Last_School_Marks_Percentage], [FinalExamResult_Name], [FinalExamResultPath], [Board_Exam_Marks], [Board_Total_Marks], [Marks_Percentage], [Board_Certificate_Number], [BoardExamResultName], [BoardExamResultPath], [BoardExamCertificate_Name], [BoardExamCertificatePath], [ImagePath], [SignaturePath], [Step_Complete], [TermsAndConditions], [Application_Status], [interview_note]) VALUES (4, 17, N'HZXFDMKHFTK7', N'EN201931201820940', N'Niloy', N'Saha5', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'No', NULL, NULL, NULL, NULL, N'23/03/2019', N'Kolkata', N'28/7 New Ballygunge Road', N' Kolkata-700039', N'700126', NULL, NULL, NULL, NULL, N'28/7 New Ballygunge Road d', N' Kolkata-700039', N'700126', 1, 38, NULL, 1166, NULL, NULL, NULL, NULL, NULL, 6, NULL, N'ERD_Exam_Schedule19184040.docx', 2, N'12345687nbb', N'123456588', 1, N'987654310', NULL, NULL, 1, N'4566', 1, N'70', N'Disability Desc Description', N'DESC123456', NULL, N'ERD_For_Attendance19184040.docx', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 12, NULL, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'~/AppFiles/Images/Yellowstone National Park 0119174910.jpg', N'~/AppFiles/Images/Yellowstone National Park 0119174910.jpg', N'Step1', NULL, N'Eligible-Admission', N'gfgggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg')
INSERT [dbo].[Student_Master] ([Student_Id], [Parent_Id], [School_Code], [Application_Id], [first_name], [last_name], [middle_name], [FatherName], [FatherContactNumber], [FatherEmail], [MotherName], [MotherContactNumber], [MotherEmail], [HomeContactNumber], [LocalGurdianValue], [LocalGurdianName], [LocalGurdianEmail], [LocalGurdianPhone], [Gender_Id], [DOB], [POB], [PermanentAddress1], [PermanentAddress2], [permanentzipcode], [PerCountryId], [Per_District], [PerStateId], [PerCityId], [CurrentAddress1], [CurrentAddress2], [currentzipcode], [CountryId], [StateId], [District], [CityId], [Zip], [Cur_Landmark], [Per_Landmark], [Email], [Phone], [BloodGroup_Id], [BirthCertificate_Name], [BirthCertificatePath], [IdProof_Id], [IdProof_Number], [Passport_Number], [CitizenCountryId], [BCN], [BCN_Attachment_Name], [BCN_Attachment], [Special_Care], [Special_Care_Description], [Disability], [Disability_Percentage], [Disability_Description], [Disability_Certificate_Number], [DisabilityCertificat_Name], [DisabilityCertificatePath], [Caste], [Religion], [Special], [Physically_Hdc], [Hdc_Percent], [Is_Monitor], [Status], [AdmissionClass_Id], [Last_School_Name], [SchoolBoard_Id], [Last_School_Year], [Last_School_Class], [School_Transfer_Certifiate_Number], [SchoolTransferCertificate_Name], [SchoolTransferCertificatePath], [Last_School_Exam_Marks], [Last_School_Total_Marks], [Last_School_Marks_Percentage], [FinalExamResult_Name], [FinalExamResultPath], [Board_Exam_Marks], [Board_Total_Marks], [Marks_Percentage], [Board_Certificate_Number], [BoardExamResultName], [BoardExamResultPath], [BoardExamCertificate_Name], [BoardExamCertificatePath], [ImagePath], [SignaturePath], [Step_Complete], [TermsAndConditions], [Application_Status], [interview_note]) VALUES (5, 17, N'JKIUR8CSCJZ1', N'EN201931201840410', N'Niloy', N'Saha5', N'', NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'No', NULL, NULL, NULL, NULL, N'23/03/2019', N'Kolkata', N'28/7 New Ballygunge Road', N' Kolkata-700039', N'700126', NULL, NULL, NULL, NULL, N'28/7 New Ballygunge Road d', N' Kolkata-700039', N'700126', 1, 38, NULL, 1166, NULL, NULL, NULL, NULL, NULL, 6, NULL, N'ERD_Exam_Schedule19184040.docx', 2, N'12345687nbb', N'123456588', 1, N'987654310', NULL, NULL, 1, N'4566', 1, N'70', N'Disability Desc Description', N'DESC123456', NULL, N'ERD_For_Attendance19184040.docx', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 12, NULL, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'~/AppFiles/Images/Yellowstone National Park 0119174910.jpg', N'~/AppFiles/Images/Yellowstone National Park 0119174910.jpg', N'Step1', NULL, N'In-Progress', NULL)
INSERT [dbo].[Student_Master] ([Student_Id], [Parent_Id], [School_Code], [Application_Id], [first_name], [last_name], [middle_name], [FatherName], [FatherContactNumber], [FatherEmail], [MotherName], [MotherContactNumber], [MotherEmail], [HomeContactNumber], [LocalGurdianValue], [LocalGurdianName], [LocalGurdianEmail], [LocalGurdianPhone], [Gender_Id], [DOB], [POB], [PermanentAddress1], [PermanentAddress2], [permanentzipcode], [PerCountryId], [Per_District], [PerStateId], [PerCityId], [CurrentAddress1], [CurrentAddress2], [currentzipcode], [CountryId], [StateId], [District], [CityId], [Zip], [Cur_Landmark], [Per_Landmark], [Email], [Phone], [BloodGroup_Id], [BirthCertificate_Name], [BirthCertificatePath], [IdProof_Id], [IdProof_Number], [Passport_Number], [CitizenCountryId], [BCN], [BCN_Attachment_Name], [BCN_Attachment], [Special_Care], [Special_Care_Description], [Disability], [Disability_Percentage], [Disability_Description], [Disability_Certificate_Number], [DisabilityCertificat_Name], [DisabilityCertificatePath], [Caste], [Religion], [Special], [Physically_Hdc], [Hdc_Percent], [Is_Monitor], [Status], [AdmissionClass_Id], [Last_School_Name], [SchoolBoard_Id], [Last_School_Year], [Last_School_Class], [School_Transfer_Certifiate_Number], [SchoolTransferCertificate_Name], [SchoolTransferCertificatePath], [Last_School_Exam_Marks], [Last_School_Total_Marks], [Last_School_Marks_Percentage], [FinalExamResult_Name], [FinalExamResultPath], [Board_Exam_Marks], [Board_Total_Marks], [Marks_Percentage], [Board_Certificate_Number], [BoardExamResultName], [BoardExamResultPath], [BoardExamCertificate_Name], [BoardExamCertificatePath], [ImagePath], [SignaturePath], [Step_Complete], [TermsAndConditions], [Application_Status], [interview_note]) VALUES (6, 1018, N'E3TQTHFGNEFI', N'EN2019319204821783', N'Narendra', N'Rajput', N'kumar', N'Rathindra Nath', N'1234567890', N'ani@gmail.com', N'L . Ray', N'1234567890', N'ani@gmail.com', N'1234567890', N'Yes', N'Sukumar panda', N'don@gmail.comm', N'1234567890', NULL, N'23/03/2019', N'Kolkata', N'Central London', N'123456', N'123456', NULL, NULL, NULL, NULL, N'Central London', N'123456', N'123456', 1, 38, NULL, 1166, NULL, NULL, NULL, NULL, NULL, 4, N'New Microsoft Office Word Document.docx', N'New Microsoft Office Word Document19364102.docx', 0, N'null', N'123456', 5, N'bvcc1231', NULL, NULL, 1, N'k', 2, N'70', N'Disability Description. ', N'12844560', N'null', N'null', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 7, N'Nabapally Boys School up', 1, N'2004', N'Five', N'58666666', N'null', N'null', N'750', N'630', N'119.05', N'yellowstone_5.jpg', N'yellowstone_519213258.jpg', N'', NULL, N'', N'', N'null', N'null', N'null', N'null', N'14479722_690410627782500_430618591424097528_n19050221.jpg', N'14446192_690410584449171_5507852671185493852_n19050230.jpg', N'Step1', 1, N'Complete', NULL)
INSERT [dbo].[Student_Master] ([Student_Id], [Parent_Id], [School_Code], [Application_Id], [first_name], [last_name], [middle_name], [FatherName], [FatherContactNumber], [FatherEmail], [MotherName], [MotherContactNumber], [MotherEmail], [HomeContactNumber], [LocalGurdianValue], [LocalGurdianName], [LocalGurdianEmail], [LocalGurdianPhone], [Gender_Id], [DOB], [POB], [PermanentAddress1], [PermanentAddress2], [permanentzipcode], [PerCountryId], [Per_District], [PerStateId], [PerCityId], [CurrentAddress1], [CurrentAddress2], [currentzipcode], [CountryId], [StateId], [District], [CityId], [Zip], [Cur_Landmark], [Per_Landmark], [Email], [Phone], [BloodGroup_Id], [BirthCertificate_Name], [BirthCertificatePath], [IdProof_Id], [IdProof_Number], [Passport_Number], [CitizenCountryId], [BCN], [BCN_Attachment_Name], [BCN_Attachment], [Special_Care], [Special_Care_Description], [Disability], [Disability_Percentage], [Disability_Description], [Disability_Certificate_Number], [DisabilityCertificat_Name], [DisabilityCertificatePath], [Caste], [Religion], [Special], [Physically_Hdc], [Hdc_Percent], [Is_Monitor], [Status], [AdmissionClass_Id], [Last_School_Name], [SchoolBoard_Id], [Last_School_Year], [Last_School_Class], [School_Transfer_Certifiate_Number], [SchoolTransferCertificate_Name], [SchoolTransferCertificatePath], [Last_School_Exam_Marks], [Last_School_Total_Marks], [Last_School_Marks_Percentage], [FinalExamResult_Name], [FinalExamResultPath], [Board_Exam_Marks], [Board_Total_Marks], [Marks_Percentage], [Board_Certificate_Number], [BoardExamResultName], [BoardExamResultPath], [BoardExamCertificate_Name], [BoardExamCertificatePath], [ImagePath], [SignaturePath], [Step_Complete], [TermsAndConditions], [Application_Status], [interview_note]) VALUES (7, 1018, N'E3TQTHFGNEFI', N'EN2019319204839280', N'Narendra', N'Rajput', N'kumar', N'Rathindra Nath', N'1234567890', N'ani@gmail.com', N'L . Ray', N'1234567890', N'ani@gmail.com', N'1234567890', N'Yes', N'Sukumar panda', N'don@gmail.comm', N'1234567890', NULL, N'23/03/2019', N'Kolkata', N'Central London', N'123456', N'123456', NULL, NULL, NULL, NULL, N'Central London', N'123456', N'123456', 1, 38, NULL, 1166, NULL, NULL, NULL, NULL, NULL, 4, N'New Microsoft Office Word Document.docx', N'New Microsoft Office Word Document19364102.docx', 0, N'null', N'123456', 5, N'bvcc1231', NULL, NULL, 1, N'k', 2, N'70', N'Disability Description. ', N'12844560', N'null', N'null', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 7, N'Nabapally Boys School up', 1, N'2004', N'Five', N'58666666', N'null', N'null', N'750', N'630', N'119.05', N'yellowstone_5.jpg', N'yellowstone_519213258.jpg', N'', NULL, N'', N'', N'null', N'null', N'null', N'null', N'14479722_690410627782500_430618591424097528_n19050221.jpg', N'14446192_690410584449171_5507852671185493852_n19050230.jpg', N'Step1', 1, N'Eligible-Admission', N'interview demo note')
INSERT [dbo].[Student_Master] ([Student_Id], [Parent_Id], [School_Code], [Application_Id], [first_name], [last_name], [middle_name], [FatherName], [FatherContactNumber], [FatherEmail], [MotherName], [MotherContactNumber], [MotherEmail], [HomeContactNumber], [LocalGurdianValue], [LocalGurdianName], [LocalGurdianEmail], [LocalGurdianPhone], [Gender_Id], [DOB], [POB], [PermanentAddress1], [PermanentAddress2], [permanentzipcode], [PerCountryId], [Per_District], [PerStateId], [PerCityId], [CurrentAddress1], [CurrentAddress2], [currentzipcode], [CountryId], [StateId], [District], [CityId], [Zip], [Cur_Landmark], [Per_Landmark], [Email], [Phone], [BloodGroup_Id], [BirthCertificate_Name], [BirthCertificatePath], [IdProof_Id], [IdProof_Number], [Passport_Number], [CitizenCountryId], [BCN], [BCN_Attachment_Name], [BCN_Attachment], [Special_Care], [Special_Care_Description], [Disability], [Disability_Percentage], [Disability_Description], [Disability_Certificate_Number], [DisabilityCertificat_Name], [DisabilityCertificatePath], [Caste], [Religion], [Special], [Physically_Hdc], [Hdc_Percent], [Is_Monitor], [Status], [AdmissionClass_Id], [Last_School_Name], [SchoolBoard_Id], [Last_School_Year], [Last_School_Class], [School_Transfer_Certifiate_Number], [SchoolTransferCertificate_Name], [SchoolTransferCertificatePath], [Last_School_Exam_Marks], [Last_School_Total_Marks], [Last_School_Marks_Percentage], [FinalExamResult_Name], [FinalExamResultPath], [Board_Exam_Marks], [Board_Total_Marks], [Marks_Percentage], [Board_Certificate_Number], [BoardExamResultName], [BoardExamResultPath], [BoardExamCertificate_Name], [BoardExamCertificatePath], [ImagePath], [SignaturePath], [Step_Complete], [TermsAndConditions], [Application_Status], [interview_note]) VALUES (8, 1018, N'E3TQTHFGNEFI', N'EN20193222019806', N'Narendra', N'Rajput', N'kumar', N'Rathindra Nath', N'1234567890', N'ani@gmail.com', N'L . Ray', N'1234567890', N'ani@gmail.com', N'1234567890', N'Yes', N'Sukumar panda', N'don@gmail.comm', N'1234567890', NULL, N'23/03/2019', N'Kolkata', N'Central London', N'123456', N'123456', NULL, NULL, NULL, NULL, N'Central London', N'123456', N'123456', 1, 38, NULL, 1166, NULL, NULL, NULL, NULL, NULL, 4, N'New Microsoft Office Word Document.docx', N'New Microsoft Office Word Document19364102.docx', 0, N'null', N'123456', 5, N'bvcc1231', NULL, NULL, 1, N'k', 2, N'70', N'Disability Description. ', N'12844560', N'null', N'null', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 7, N'Nabapally Boys School up', 1, N'2004', N'Five', N'58666666', N'null', N'null', N'750', N'630', N'119.05', N'yellowstone_5.jpg', N'yellowstone_519213258.jpg', N'', NULL, N'', N'', N'null', N'null', N'null', N'null', N'14479722_690410627782500_430618591424097528_n19050221.jpg', N'14446192_690410584449171_5507852671185493852_n19050230.jpg', N'Step1', 1, N'Complete', NULL)
INSERT [dbo].[Student_Master] ([Student_Id], [Parent_Id], [School_Code], [Application_Id], [first_name], [last_name], [middle_name], [FatherName], [FatherContactNumber], [FatherEmail], [MotherName], [MotherContactNumber], [MotherEmail], [HomeContactNumber], [LocalGurdianValue], [LocalGurdianName], [LocalGurdianEmail], [LocalGurdianPhone], [Gender_Id], [DOB], [POB], [PermanentAddress1], [PermanentAddress2], [permanentzipcode], [PerCountryId], [Per_District], [PerStateId], [PerCityId], [CurrentAddress1], [CurrentAddress2], [currentzipcode], [CountryId], [StateId], [District], [CityId], [Zip], [Cur_Landmark], [Per_Landmark], [Email], [Phone], [BloodGroup_Id], [BirthCertificate_Name], [BirthCertificatePath], [IdProof_Id], [IdProof_Number], [Passport_Number], [CitizenCountryId], [BCN], [BCN_Attachment_Name], [BCN_Attachment], [Special_Care], [Special_Care_Description], [Disability], [Disability_Percentage], [Disability_Description], [Disability_Certificate_Number], [DisabilityCertificat_Name], [DisabilityCertificatePath], [Caste], [Religion], [Special], [Physically_Hdc], [Hdc_Percent], [Is_Monitor], [Status], [AdmissionClass_Id], [Last_School_Name], [SchoolBoard_Id], [Last_School_Year], [Last_School_Class], [School_Transfer_Certifiate_Number], [SchoolTransferCertificate_Name], [SchoolTransferCertificatePath], [Last_School_Exam_Marks], [Last_School_Total_Marks], [Last_School_Marks_Percentage], [FinalExamResult_Name], [FinalExamResultPath], [Board_Exam_Marks], [Board_Total_Marks], [Marks_Percentage], [Board_Certificate_Number], [BoardExamResultName], [BoardExamResultPath], [BoardExamCertificate_Name], [BoardExamCertificatePath], [ImagePath], [SignaturePath], [Step_Complete], [TermsAndConditions], [Application_Status], [interview_note]) VALUES (1006, 1018, N'E3TQTHFGNEFI', N'EN2019325154147886', N'Narendra', N'Rajput', N'kumar', N'Rathindra Nath', N'1234567890', N'ani@gmail.com', N'L . Ray', N'1234567890', N'ani@gmail.com', N'1234567890', N'Yes', N'Sukumar panda', N'don@gmail.comm', N'1234567890', NULL, N'23/03/2019', N'Kolkata', N'Central London', N'123456', N'123456', NULL, NULL, NULL, NULL, N'Central London', N'123456', N'123456', 1, 38, NULL, 1166, NULL, NULL, NULL, NULL, NULL, 4, N'New Microsoft Office Word Document.docx', N'New Microsoft Office Word Document19364102.docx', 0, N'null', N'123456', 5, N'bvcc1231', NULL, NULL, 1, N'k', 2, N'70', N'Disability Description. ', N'12844560', N'null', N'null', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 7, N'Nabapally Boys School up', 1, N'2004', N'Five', N'58666666', N'null', N'null', N'750', N'630', N'119.05', N'yellowstone_5.jpg', N'yellowstone_519213258.jpg', N'', NULL, N'', N'', N'null', N'null', N'null', N'null', N'14479722_690410627782500_430618591424097528_n19050221.jpg', N'14446192_690410584449171_5507852671185493852_n19050230.jpg', N'Step1', 1, N'Complete', NULL)
INSERT [dbo].[Student_Master] ([Student_Id], [Parent_Id], [School_Code], [Application_Id], [first_name], [last_name], [middle_name], [FatherName], [FatherContactNumber], [FatherEmail], [MotherName], [MotherContactNumber], [MotherEmail], [HomeContactNumber], [LocalGurdianValue], [LocalGurdianName], [LocalGurdianEmail], [LocalGurdianPhone], [Gender_Id], [DOB], [POB], [PermanentAddress1], [PermanentAddress2], [permanentzipcode], [PerCountryId], [Per_District], [PerStateId], [PerCityId], [CurrentAddress1], [CurrentAddress2], [currentzipcode], [CountryId], [StateId], [District], [CityId], [Zip], [Cur_Landmark], [Per_Landmark], [Email], [Phone], [BloodGroup_Id], [BirthCertificate_Name], [BirthCertificatePath], [IdProof_Id], [IdProof_Number], [Passport_Number], [CitizenCountryId], [BCN], [BCN_Attachment_Name], [BCN_Attachment], [Special_Care], [Special_Care_Description], [Disability], [Disability_Percentage], [Disability_Description], [Disability_Certificate_Number], [DisabilityCertificat_Name], [DisabilityCertificatePath], [Caste], [Religion], [Special], [Physically_Hdc], [Hdc_Percent], [Is_Monitor], [Status], [AdmissionClass_Id], [Last_School_Name], [SchoolBoard_Id], [Last_School_Year], [Last_School_Class], [School_Transfer_Certifiate_Number], [SchoolTransferCertificate_Name], [SchoolTransferCertificatePath], [Last_School_Exam_Marks], [Last_School_Total_Marks], [Last_School_Marks_Percentage], [FinalExamResult_Name], [FinalExamResultPath], [Board_Exam_Marks], [Board_Total_Marks], [Marks_Percentage], [Board_Certificate_Number], [BoardExamResultName], [BoardExamResultPath], [BoardExamCertificate_Name], [BoardExamCertificatePath], [ImagePath], [SignaturePath], [Step_Complete], [TermsAndConditions], [Application_Status], [interview_note]) VALUES (1007, 1018, N'E3TQTHFGNEFI', N'EN2019325154156343', N'Narendra', N'Rajput', N'kumar', N'Rathindra Nath', N'1234567890', N'ani@gmail.com', N'L . Ray', N'1234567890', N'ani@gmail.com', N'1234567890', N'Yes', N'Sukumar panda', N'don@gmail.comm', N'1234567890', NULL, N'23/03/2019', N'Kolkata', N'Central London', N'123456', N'123456', NULL, NULL, NULL, NULL, N'Central London', N'123456', N'123456', 1, 38, NULL, 1166, NULL, NULL, NULL, NULL, NULL, 4, N'New Microsoft Office Word Document.docx', N'New Microsoft Office Word Document19364102.docx', 0, N'null', N'123456', 5, N'bvcc1231', NULL, NULL, 1, N'k', 2, N'70', N'Disability Description. ', N'12844560', N'null', N'null', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 7, N'Nabapally Boys School up', 1, N'2004', N'Five', N'58666666', N'null', N'null', N'750', N'630', N'119.05', N'yellowstone_5.jpg', N'yellowstone_519213258.jpg', N'', NULL, N'', N'', N'null', N'null', N'null', N'null', N'14479722_690410627782500_430618591424097528_n19050221.jpg', N'14446192_690410584449171_5507852671185493852_n19050230.jpg', N'Step1', 1, N'Complete', NULL)
INSERT [dbo].[Student_Master] ([Student_Id], [Parent_Id], [School_Code], [Application_Id], [first_name], [last_name], [middle_name], [FatherName], [FatherContactNumber], [FatherEmail], [MotherName], [MotherContactNumber], [MotherEmail], [HomeContactNumber], [LocalGurdianValue], [LocalGurdianName], [LocalGurdianEmail], [LocalGurdianPhone], [Gender_Id], [DOB], [POB], [PermanentAddress1], [PermanentAddress2], [permanentzipcode], [PerCountryId], [Per_District], [PerStateId], [PerCityId], [CurrentAddress1], [CurrentAddress2], [currentzipcode], [CountryId], [StateId], [District], [CityId], [Zip], [Cur_Landmark], [Per_Landmark], [Email], [Phone], [BloodGroup_Id], [BirthCertificate_Name], [BirthCertificatePath], [IdProof_Id], [IdProof_Number], [Passport_Number], [CitizenCountryId], [BCN], [BCN_Attachment_Name], [BCN_Attachment], [Special_Care], [Special_Care_Description], [Disability], [Disability_Percentage], [Disability_Description], [Disability_Certificate_Number], [DisabilityCertificat_Name], [DisabilityCertificatePath], [Caste], [Religion], [Special], [Physically_Hdc], [Hdc_Percent], [Is_Monitor], [Status], [AdmissionClass_Id], [Last_School_Name], [SchoolBoard_Id], [Last_School_Year], [Last_School_Class], [School_Transfer_Certifiate_Number], [SchoolTransferCertificate_Name], [SchoolTransferCertificatePath], [Last_School_Exam_Marks], [Last_School_Total_Marks], [Last_School_Marks_Percentage], [FinalExamResult_Name], [FinalExamResultPath], [Board_Exam_Marks], [Board_Total_Marks], [Marks_Percentage], [Board_Certificate_Number], [BoardExamResultName], [BoardExamResultPath], [BoardExamCertificate_Name], [BoardExamCertificatePath], [ImagePath], [SignaturePath], [Step_Complete], [TermsAndConditions], [Application_Status], [interview_note]) VALUES (1008, 1018, N'E3TQTHFGNEFI', N'EN201932516121486', N'Narendra', N'Rajput', N'kumar', N'Rathindra Nath', N'1234567890', N'ani@gmail.com', N'L . Ray', N'1234567890', N'ani@gmail.com', N'1234567890', N'Yes', N'Sukumar panda', N'don@gmail.comm', N'1234567890', NULL, N'23/03/2019', N'Kolkata', N'Central London', N'123456', N'123456', NULL, NULL, NULL, NULL, N'Central London', N'123456', N'123456', 1, 38, NULL, 1166, NULL, NULL, NULL, NULL, NULL, 4, N'New Microsoft Office Word Document.docx', N'New Microsoft Office Word Document19364102.docx', 0, N'null', N'123456', 5, N'bvcc1231', NULL, NULL, 1, N'k', 2, N'70', N'Disability Description. ', N'12844560', N'null', N'null', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 7, N'Nabapally Boys School up', 1, N'2004', N'Five', N'58666666', N'null', N'null', N'750', N'630', N'119.05', N'yellowstone_5.jpg', N'yellowstone_519213258.jpg', N'', NULL, N'', N'', N'null', N'null', N'null', N'null', N'14479722_690410627782500_430618591424097528_n19050221.jpg', N'14446192_690410584449171_5507852671185493852_n19050230.jpg', N'Step1', 1, N'Complete', NULL)
INSERT [dbo].[Student_Master] ([Student_Id], [Parent_Id], [School_Code], [Application_Id], [first_name], [last_name], [middle_name], [FatherName], [FatherContactNumber], [FatherEmail], [MotherName], [MotherContactNumber], [MotherEmail], [HomeContactNumber], [LocalGurdianValue], [LocalGurdianName], [LocalGurdianEmail], [LocalGurdianPhone], [Gender_Id], [DOB], [POB], [PermanentAddress1], [PermanentAddress2], [permanentzipcode], [PerCountryId], [Per_District], [PerStateId], [PerCityId], [CurrentAddress1], [CurrentAddress2], [currentzipcode], [CountryId], [StateId], [District], [CityId], [Zip], [Cur_Landmark], [Per_Landmark], [Email], [Phone], [BloodGroup_Id], [BirthCertificate_Name], [BirthCertificatePath], [IdProof_Id], [IdProof_Number], [Passport_Number], [CitizenCountryId], [BCN], [BCN_Attachment_Name], [BCN_Attachment], [Special_Care], [Special_Care_Description], [Disability], [Disability_Percentage], [Disability_Description], [Disability_Certificate_Number], [DisabilityCertificat_Name], [DisabilityCertificatePath], [Caste], [Religion], [Special], [Physically_Hdc], [Hdc_Percent], [Is_Monitor], [Status], [AdmissionClass_Id], [Last_School_Name], [SchoolBoard_Id], [Last_School_Year], [Last_School_Class], [School_Transfer_Certifiate_Number], [SchoolTransferCertificate_Name], [SchoolTransferCertificatePath], [Last_School_Exam_Marks], [Last_School_Total_Marks], [Last_School_Marks_Percentage], [FinalExamResult_Name], [FinalExamResultPath], [Board_Exam_Marks], [Board_Total_Marks], [Marks_Percentage], [Board_Certificate_Number], [BoardExamResultName], [BoardExamResultPath], [BoardExamCertificate_Name], [BoardExamCertificatePath], [ImagePath], [SignaturePath], [Step_Complete], [TermsAndConditions], [Application_Status], [interview_note]) VALUES (1009, 1018, N'E3TQTHFGNEFI', N'EN201932517169260', N'Narendra', N'Rajput', N'kumar', N'Rathindra Nath', N'1234567890', N'ani@gmail.com', N'L . Ray', N'1234567890', N'ani@gmail.com', N'1234567890', N'Yes', N'Sukumar panda', N'don@gmail.comm', N'1234567890', NULL, N'23/03/2019', N'Kolkata', N'Central London', N'123456', N'123456', NULL, NULL, NULL, NULL, N'Central London', N'123456', N'123456', 1, 38, NULL, 1166, NULL, NULL, NULL, NULL, NULL, 4, N'New Microsoft Office Word Document.docx', N'New Microsoft Office Word Document19364102.docx', 0, N'null', N'123456', 5, N'bvcc1231', NULL, NULL, 1, N'k', 2, N'70', N'Disability Description. ', N'12844560', N'null', N'null', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 7, N'Nabapally Boys School up', 1, N'2004', N'Five', N'58666666', N'null', N'null', N'750', N'630', N'119.05', N'yellowstone_5.jpg', N'yellowstone_519213258.jpg', N'', NULL, N'', N'', N'null', N'null', N'null', N'null', N'14479722_690410627782500_430618591424097528_n19050221.jpg', N'14446192_690410584449171_5507852671185493852_n19050230.jpg', N'Step1', 1, N'Complete', NULL)
INSERT [dbo].[Student_Master] ([Student_Id], [Parent_Id], [School_Code], [Application_Id], [first_name], [last_name], [middle_name], [FatherName], [FatherContactNumber], [FatherEmail], [MotherName], [MotherContactNumber], [MotherEmail], [HomeContactNumber], [LocalGurdianValue], [LocalGurdianName], [LocalGurdianEmail], [LocalGurdianPhone], [Gender_Id], [DOB], [POB], [PermanentAddress1], [PermanentAddress2], [permanentzipcode], [PerCountryId], [Per_District], [PerStateId], [PerCityId], [CurrentAddress1], [CurrentAddress2], [currentzipcode], [CountryId], [StateId], [District], [CityId], [Zip], [Cur_Landmark], [Per_Landmark], [Email], [Phone], [BloodGroup_Id], [BirthCertificate_Name], [BirthCertificatePath], [IdProof_Id], [IdProof_Number], [Passport_Number], [CitizenCountryId], [BCN], [BCN_Attachment_Name], [BCN_Attachment], [Special_Care], [Special_Care_Description], [Disability], [Disability_Percentage], [Disability_Description], [Disability_Certificate_Number], [DisabilityCertificat_Name], [DisabilityCertificatePath], [Caste], [Religion], [Special], [Physically_Hdc], [Hdc_Percent], [Is_Monitor], [Status], [AdmissionClass_Id], [Last_School_Name], [SchoolBoard_Id], [Last_School_Year], [Last_School_Class], [School_Transfer_Certifiate_Number], [SchoolTransferCertificate_Name], [SchoolTransferCertificatePath], [Last_School_Exam_Marks], [Last_School_Total_Marks], [Last_School_Marks_Percentage], [FinalExamResult_Name], [FinalExamResultPath], [Board_Exam_Marks], [Board_Total_Marks], [Marks_Percentage], [Board_Certificate_Number], [BoardExamResultName], [BoardExamResultPath], [BoardExamCertificate_Name], [BoardExamCertificatePath], [ImagePath], [SignaturePath], [Step_Complete], [TermsAndConditions], [Application_Status], [interview_note]) VALUES (1010, 1018, N'E3TQTHFGNEFI', N'EN201932518111480', N'Narendra', N'Rajput', N'kumar', N'Rathindra Nath', N'1234567890', N'ani@gmail.com', N'L . Ray', N'1234567890', N'ani@gmail.com', N'1234567890', N'Yes', N'Sukumar panda', N'don@gmail.comm', N'1234567890', NULL, N'23/03/2019', N'Kolkata', N'Central London', N'123456', N'123456', NULL, NULL, NULL, NULL, N'Central London', N'123456', N'123456', 1, 38, NULL, 1166, NULL, NULL, NULL, NULL, NULL, 4, N'New Microsoft Office Word Document.docx', N'New Microsoft Office Word Document19364102.docx', 0, N'null', N'123456', 5, N'bvcc1231', NULL, NULL, 1, N'k', 2, N'70', N'Disability Description. ', N'12844560', N'null', N'null', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 7, N'Nabapally Boys School up', 1, N'2004', N'Five', N'58666666', N'null', N'null', N'750', N'630', N'119.05', N'yellowstone_5.jpg', N'yellowstone_519213258.jpg', N'', NULL, N'', N'', N'null', N'null', N'null', N'null', N'14479722_690410627782500_430618591424097528_n19050221.jpg', N'14446192_690410584449171_5507852671185493852_n19050230.jpg', N'Step1', 1, N'Complete', NULL)
INSERT [dbo].[Student_Master] ([Student_Id], [Parent_Id], [School_Code], [Application_Id], [first_name], [last_name], [middle_name], [FatherName], [FatherContactNumber], [FatherEmail], [MotherName], [MotherContactNumber], [MotherEmail], [HomeContactNumber], [LocalGurdianValue], [LocalGurdianName], [LocalGurdianEmail], [LocalGurdianPhone], [Gender_Id], [DOB], [POB], [PermanentAddress1], [PermanentAddress2], [permanentzipcode], [PerCountryId], [Per_District], [PerStateId], [PerCityId], [CurrentAddress1], [CurrentAddress2], [currentzipcode], [CountryId], [StateId], [District], [CityId], [Zip], [Cur_Landmark], [Per_Landmark], [Email], [Phone], [BloodGroup_Id], [BirthCertificate_Name], [BirthCertificatePath], [IdProof_Id], [IdProof_Number], [Passport_Number], [CitizenCountryId], [BCN], [BCN_Attachment_Name], [BCN_Attachment], [Special_Care], [Special_Care_Description], [Disability], [Disability_Percentage], [Disability_Description], [Disability_Certificate_Number], [DisabilityCertificat_Name], [DisabilityCertificatePath], [Caste], [Religion], [Special], [Physically_Hdc], [Hdc_Percent], [Is_Monitor], [Status], [AdmissionClass_Id], [Last_School_Name], [SchoolBoard_Id], [Last_School_Year], [Last_School_Class], [School_Transfer_Certifiate_Number], [SchoolTransferCertificate_Name], [SchoolTransferCertificatePath], [Last_School_Exam_Marks], [Last_School_Total_Marks], [Last_School_Marks_Percentage], [FinalExamResult_Name], [FinalExamResultPath], [Board_Exam_Marks], [Board_Total_Marks], [Marks_Percentage], [Board_Certificate_Number], [BoardExamResultName], [BoardExamResultPath], [BoardExamCertificate_Name], [BoardExamCertificatePath], [ImagePath], [SignaturePath], [Step_Complete], [TermsAndConditions], [Application_Status], [interview_note]) VALUES (1011, 1018, N'E3TQTHFGNEFI', N'EN2019325184838383', N'Narendra', N'Rajput', N'kumar', N'Rathindra Nath', N'1234567890', N'ani@gmail.com', N'L . Ray', N'1234567890', N'ani@gmail.com', N'1234567890', N'Yes', N'Sukumar panda', N'don@gmail.comm', N'1234567890', NULL, N'23/03/2019', N'Kolkata', N'Central London', N'123456', N'123456', NULL, NULL, NULL, NULL, N'Central London', N'123456', N'123456', 1, 38, NULL, 1166, NULL, NULL, NULL, NULL, NULL, 4, N'New Microsoft Office Word Document.docx', N'New Microsoft Office Word Document19364102.docx', 0, N'null', N'123456', 5, N'bvcc1231', NULL, NULL, 1, N'k', 2, N'70', N'Disability Description. ', N'12844560', N'null', N'null', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 7, N'Nabapally Boys School up', 1, N'2004', N'Five', N'58666666', N'null', N'null', N'750', N'630', N'119.05', N'yellowstone_5.jpg', N'yellowstone_519213258.jpg', N'', NULL, N'', N'', N'null', N'null', N'null', N'null', N'14479722_690410627782500_430618591424097528_n19050221.jpg', N'14446192_690410584449171_5507852671185493852_n19050230.jpg', N'Step1', 1, N'Complete', NULL)
INSERT [dbo].[Student_Master] ([Student_Id], [Parent_Id], [School_Code], [Application_Id], [first_name], [last_name], [middle_name], [FatherName], [FatherContactNumber], [FatherEmail], [MotherName], [MotherContactNumber], [MotherEmail], [HomeContactNumber], [LocalGurdianValue], [LocalGurdianName], [LocalGurdianEmail], [LocalGurdianPhone], [Gender_Id], [DOB], [POB], [PermanentAddress1], [PermanentAddress2], [permanentzipcode], [PerCountryId], [Per_District], [PerStateId], [PerCityId], [CurrentAddress1], [CurrentAddress2], [currentzipcode], [CountryId], [StateId], [District], [CityId], [Zip], [Cur_Landmark], [Per_Landmark], [Email], [Phone], [BloodGroup_Id], [BirthCertificate_Name], [BirthCertificatePath], [IdProof_Id], [IdProof_Number], [Passport_Number], [CitizenCountryId], [BCN], [BCN_Attachment_Name], [BCN_Attachment], [Special_Care], [Special_Care_Description], [Disability], [Disability_Percentage], [Disability_Description], [Disability_Certificate_Number], [DisabilityCertificat_Name], [DisabilityCertificatePath], [Caste], [Religion], [Special], [Physically_Hdc], [Hdc_Percent], [Is_Monitor], [Status], [AdmissionClass_Id], [Last_School_Name], [SchoolBoard_Id], [Last_School_Year], [Last_School_Class], [School_Transfer_Certifiate_Number], [SchoolTransferCertificate_Name], [SchoolTransferCertificatePath], [Last_School_Exam_Marks], [Last_School_Total_Marks], [Last_School_Marks_Percentage], [FinalExamResult_Name], [FinalExamResultPath], [Board_Exam_Marks], [Board_Total_Marks], [Marks_Percentage], [Board_Certificate_Number], [BoardExamResultName], [BoardExamResultPath], [BoardExamCertificate_Name], [BoardExamCertificatePath], [ImagePath], [SignaturePath], [Step_Complete], [TermsAndConditions], [Application_Status], [interview_note]) VALUES (1012, 1018, N'E3TQTHFGNEFI', N'EN2019325184848440', N'Narendra', N'Rajput', N'kumar', N'Rathindra Nath', N'1234567890', N'ani@gmail.com', N'L . Ray', N'1234567890', N'ani@gmail.com', N'1234567890', N'Yes', N'Sukumar panda', N'don@gmail.comm', N'1234567890', NULL, N'23/03/2019', N'Kolkata', N'Central London', N'123456', N'123456', NULL, NULL, NULL, NULL, N'Central London', N'123456', N'123456', 1, 38, NULL, 1166, NULL, NULL, NULL, NULL, NULL, 4, N'New Microsoft Office Word Document.docx', N'New Microsoft Office Word Document19364102.docx', 0, N'null', N'123456', 5, N'bvcc1231', NULL, NULL, 1, N'k', 2, N'70', N'Disability Description. ', N'12844560', N'null', N'null', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 7, N'Nabapally Boys School up', 1, N'2004', N'Five', N'58666666', N'null', N'null', N'750', N'630', N'119.05', N'yellowstone_5.jpg', N'yellowstone_519213258.jpg', N'', NULL, N'', N'', N'null', N'null', N'null', N'null', N'14479722_690410627782500_430618591424097528_n19050221.jpg', N'14446192_690410584449171_5507852671185493852_n19050230.jpg', N'Step1', 1, N'Complete', NULL)
INSERT [dbo].[Student_Master] ([Student_Id], [Parent_Id], [School_Code], [Application_Id], [first_name], [last_name], [middle_name], [FatherName], [FatherContactNumber], [FatherEmail], [MotherName], [MotherContactNumber], [MotherEmail], [HomeContactNumber], [LocalGurdianValue], [LocalGurdianName], [LocalGurdianEmail], [LocalGurdianPhone], [Gender_Id], [DOB], [POB], [PermanentAddress1], [PermanentAddress2], [permanentzipcode], [PerCountryId], [Per_District], [PerStateId], [PerCityId], [CurrentAddress1], [CurrentAddress2], [currentzipcode], [CountryId], [StateId], [District], [CityId], [Zip], [Cur_Landmark], [Per_Landmark], [Email], [Phone], [BloodGroup_Id], [BirthCertificate_Name], [BirthCertificatePath], [IdProof_Id], [IdProof_Number], [Passport_Number], [CitizenCountryId], [BCN], [BCN_Attachment_Name], [BCN_Attachment], [Special_Care], [Special_Care_Description], [Disability], [Disability_Percentage], [Disability_Description], [Disability_Certificate_Number], [DisabilityCertificat_Name], [DisabilityCertificatePath], [Caste], [Religion], [Special], [Physically_Hdc], [Hdc_Percent], [Is_Monitor], [Status], [AdmissionClass_Id], [Last_School_Name], [SchoolBoard_Id], [Last_School_Year], [Last_School_Class], [School_Transfer_Certifiate_Number], [SchoolTransferCertificate_Name], [SchoolTransferCertificatePath], [Last_School_Exam_Marks], [Last_School_Total_Marks], [Last_School_Marks_Percentage], [FinalExamResult_Name], [FinalExamResultPath], [Board_Exam_Marks], [Board_Total_Marks], [Marks_Percentage], [Board_Certificate_Number], [BoardExamResultName], [BoardExamResultPath], [BoardExamCertificate_Name], [BoardExamCertificatePath], [ImagePath], [SignaturePath], [Step_Complete], [TermsAndConditions], [Application_Status], [interview_note]) VALUES (1016, 1018, N'E3TQTHFGNEFI', N'EN2019326141845513', N'Narendra', N'Rajput', N'kumar', N'Rathindra Nath', N'1234567890', N'ani@gmail.com', N'L . Ray', N'1234567890', N'ani@gmail.com', N'1234567890', N'Yes', N'Sukumar panda', N'don@gmail.comm', N'1234567890', NULL, N'23/03/2019', N'Kolkata', N'Central London', N'123456', N'123456', NULL, NULL, NULL, NULL, N'Central London', N'123456', N'123456', 1, 38, NULL, 1166, NULL, NULL, NULL, NULL, NULL, 4, N'New Microsoft Office Word Document.docx', N'New Microsoft Office Word Document19364102.docx', 0, N'null', N'123456', 5, N'bvcc1231', NULL, NULL, 1, N'k', 2, N'70', N'Disability Description. ', N'12844560', N'null', N'null', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 7, N'Nabapally Boys School up', 1, N'2004', N'Five', N'58666666', N'null', N'null', N'750', N'630', N'119.05', N'yellowstone_5.jpg', N'yellowstone_519213258.jpg', N'', NULL, N'', N'', N'null', N'null', N'null', N'null', N'14479722_690410627782500_430618591424097528_n19050221.jpg', N'14446192_690410584449171_5507852671185493852_n19050230.jpg', N'Step1', 1, N'In-Progress', NULL)
INSERT [dbo].[Student_Master] ([Student_Id], [Parent_Id], [School_Code], [Application_Id], [first_name], [last_name], [middle_name], [FatherName], [FatherContactNumber], [FatherEmail], [MotherName], [MotherContactNumber], [MotherEmail], [HomeContactNumber], [LocalGurdianValue], [LocalGurdianName], [LocalGurdianEmail], [LocalGurdianPhone], [Gender_Id], [DOB], [POB], [PermanentAddress1], [PermanentAddress2], [permanentzipcode], [PerCountryId], [Per_District], [PerStateId], [PerCityId], [CurrentAddress1], [CurrentAddress2], [currentzipcode], [CountryId], [StateId], [District], [CityId], [Zip], [Cur_Landmark], [Per_Landmark], [Email], [Phone], [BloodGroup_Id], [BirthCertificate_Name], [BirthCertificatePath], [IdProof_Id], [IdProof_Number], [Passport_Number], [CitizenCountryId], [BCN], [BCN_Attachment_Name], [BCN_Attachment], [Special_Care], [Special_Care_Description], [Disability], [Disability_Percentage], [Disability_Description], [Disability_Certificate_Number], [DisabilityCertificat_Name], [DisabilityCertificatePath], [Caste], [Religion], [Special], [Physically_Hdc], [Hdc_Percent], [Is_Monitor], [Status], [AdmissionClass_Id], [Last_School_Name], [SchoolBoard_Id], [Last_School_Year], [Last_School_Class], [School_Transfer_Certifiate_Number], [SchoolTransferCertificate_Name], [SchoolTransferCertificatePath], [Last_School_Exam_Marks], [Last_School_Total_Marks], [Last_School_Marks_Percentage], [FinalExamResult_Name], [FinalExamResultPath], [Board_Exam_Marks], [Board_Total_Marks], [Marks_Percentage], [Board_Certificate_Number], [BoardExamResultName], [BoardExamResultPath], [BoardExamCertificate_Name], [BoardExamCertificatePath], [ImagePath], [SignaturePath], [Step_Complete], [TermsAndConditions], [Application_Status], [interview_note]) VALUES (1017, 1018, N'E3TQTHFGNEFI', N'EN201942145759923', N'Narendra', N'Rajput', N'kumar', N'Rathindra Nath', N'1234567890', N'ani@gmail.com', N'L . Ray', N'1234567890', N'ani@gmail.com', N'1234567890', N'Yes', N'Sukumar panda', N'don@gmail.comm', N'1234567890', NULL, N'23/03/2019', N'Kolkata', N'Central London', N'123456', N'123456', NULL, NULL, NULL, NULL, N'Central London', N'123456', N'123456', 1, 38, NULL, 1166, NULL, NULL, NULL, NULL, NULL, 4, N'New Microsoft Office Word Document.docx', N'New Microsoft Office Word Document19364102.docx', 0, N'null', N'123456', 5, N'bvcc1231', NULL, NULL, 1, N'k', 2, N'70', N'Disability Description. ', N'12844560', N'null', N'null', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 7, N'Nabapally Boys School up', 1, N'2004', N'Five', N'58666666', N'null', N'null', N'750', N'630', N'119.05', N'yellowstone_5.jpg', N'yellowstone_519213258.jpg', N'', NULL, N'', N'', N'null', N'null', N'null', N'null', N'14479722_690410627782500_430618591424097528_n19050221.jpg', N'14446192_690410584449171_5507852671185493852_n19050230.jpg', N'Step1', 1, N'Complete', NULL)
INSERT [dbo].[Student_Master] ([Student_Id], [Parent_Id], [School_Code], [Application_Id], [first_name], [last_name], [middle_name], [FatherName], [FatherContactNumber], [FatherEmail], [MotherName], [MotherContactNumber], [MotherEmail], [HomeContactNumber], [LocalGurdianValue], [LocalGurdianName], [LocalGurdianEmail], [LocalGurdianPhone], [Gender_Id], [DOB], [POB], [PermanentAddress1], [PermanentAddress2], [permanentzipcode], [PerCountryId], [Per_District], [PerStateId], [PerCityId], [CurrentAddress1], [CurrentAddress2], [currentzipcode], [CountryId], [StateId], [District], [CityId], [Zip], [Cur_Landmark], [Per_Landmark], [Email], [Phone], [BloodGroup_Id], [BirthCertificate_Name], [BirthCertificatePath], [IdProof_Id], [IdProof_Number], [Passport_Number], [CitizenCountryId], [BCN], [BCN_Attachment_Name], [BCN_Attachment], [Special_Care], [Special_Care_Description], [Disability], [Disability_Percentage], [Disability_Description], [Disability_Certificate_Number], [DisabilityCertificat_Name], [DisabilityCertificatePath], [Caste], [Religion], [Special], [Physically_Hdc], [Hdc_Percent], [Is_Monitor], [Status], [AdmissionClass_Id], [Last_School_Name], [SchoolBoard_Id], [Last_School_Year], [Last_School_Class], [School_Transfer_Certifiate_Number], [SchoolTransferCertificate_Name], [SchoolTransferCertificatePath], [Last_School_Exam_Marks], [Last_School_Total_Marks], [Last_School_Marks_Percentage], [FinalExamResult_Name], [FinalExamResultPath], [Board_Exam_Marks], [Board_Total_Marks], [Marks_Percentage], [Board_Certificate_Number], [BoardExamResultName], [BoardExamResultPath], [BoardExamCertificate_Name], [BoardExamCertificatePath], [ImagePath], [SignaturePath], [Step_Complete], [TermsAndConditions], [Application_Status], [interview_note]) VALUES (1018, 1018, N'E3TQTHFGNEFI', N'EN20194219239930', N'Narendra', N'Rajput', N'kumar', N'Rathindra Nath', N'1234567890', N'ani@gmail.com', N'L . Ray', N'1234567890', N'ani@gmail.com', N'1234567890', N'Yes', N'Sukumar panda', N'don@gmail.comm', N'1234567890', NULL, N'23/03/2019', N'Kolkata', N'Central London', N'123456', N'123456', NULL, NULL, NULL, NULL, N'Central London', N'123456', N'123456', 1, 38, NULL, 1166, NULL, NULL, NULL, NULL, NULL, 4, N'New Microsoft Office Word Document.docx', N'New Microsoft Office Word Document19364102.docx', 0, N'null', N'123456', 5, N'bvcc1231', NULL, NULL, 1, N'k', 2, N'70', N'Disability Description. ', N'12844560', N'null', N'null', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 7, N'Nabapally Boys School up', 1, N'2004', N'Five', N'58666666', N'null', N'null', N'750', N'630', N'119.05', N'yellowstone_5.jpg', N'yellowstone_519213258.jpg', N'', NULL, N'', N'', N'null', N'null', N'null', N'null', N'14479722_690410627782500_430618591424097528_n19050221.jpg', N'14446192_690410584449171_5507852671185493852_n19050230.jpg', N'Step1', 1, N'Complete', NULL)
INSERT [dbo].[Student_Master] ([Student_Id], [Parent_Id], [School_Code], [Application_Id], [first_name], [last_name], [middle_name], [FatherName], [FatherContactNumber], [FatherEmail], [MotherName], [MotherContactNumber], [MotherEmail], [HomeContactNumber], [LocalGurdianValue], [LocalGurdianName], [LocalGurdianEmail], [LocalGurdianPhone], [Gender_Id], [DOB], [POB], [PermanentAddress1], [PermanentAddress2], [permanentzipcode], [PerCountryId], [Per_District], [PerStateId], [PerCityId], [CurrentAddress1], [CurrentAddress2], [currentzipcode], [CountryId], [StateId], [District], [CityId], [Zip], [Cur_Landmark], [Per_Landmark], [Email], [Phone], [BloodGroup_Id], [BirthCertificate_Name], [BirthCertificatePath], [IdProof_Id], [IdProof_Number], [Passport_Number], [CitizenCountryId], [BCN], [BCN_Attachment_Name], [BCN_Attachment], [Special_Care], [Special_Care_Description], [Disability], [Disability_Percentage], [Disability_Description], [Disability_Certificate_Number], [DisabilityCertificat_Name], [DisabilityCertificatePath], [Caste], [Religion], [Special], [Physically_Hdc], [Hdc_Percent], [Is_Monitor], [Status], [AdmissionClass_Id], [Last_School_Name], [SchoolBoard_Id], [Last_School_Year], [Last_School_Class], [School_Transfer_Certifiate_Number], [SchoolTransferCertificate_Name], [SchoolTransferCertificatePath], [Last_School_Exam_Marks], [Last_School_Total_Marks], [Last_School_Marks_Percentage], [FinalExamResult_Name], [FinalExamResultPath], [Board_Exam_Marks], [Board_Total_Marks], [Marks_Percentage], [Board_Certificate_Number], [BoardExamResultName], [BoardExamResultPath], [BoardExamCertificate_Name], [BoardExamCertificatePath], [ImagePath], [SignaturePath], [Step_Complete], [TermsAndConditions], [Application_Status], [interview_note]) VALUES (1019, 1018, N'E3TQTHFGNEFI', N'EN2019416191550196', N'Narendra', N'Rajput', N'kumar', N'Rathindra Nath', N'1234567890', N'ani@gmail.com', N'L . Ray', N'1234567890', N'ani@gmail.com', N'1234567890', N'Yes', N'Sukumar panda', N'don@gmail.comm', N'1234567890', NULL, N'23/03/2019', N'Kolkata', N'Central London', N'123456', N'123456', NULL, NULL, NULL, NULL, N'Central London', N'123456', N'123456', 1, 38, NULL, 1166, NULL, NULL, NULL, NULL, NULL, 4, N'New Microsoft Office Word Document.docx', N'New Microsoft Office Word Document19364102.docx', 0, N'null', N'123456', 5, N'bvcc1231', NULL, NULL, 1, N'k', 2, N'70', N'Disability Description. ', N'12844560', N'null', N'null', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 7, N'Nabapally Boys School up', 1, N'2004', N'Five', N'58666666', N'null', N'null', N'750', N'630', N'119.05', N'yellowstone_5.jpg', N'yellowstone_519213258.jpg', N'', NULL, N'', N'', N'null', N'null', N'null', N'null', N'14479722_690410627782500_430618591424097528_n19050221.jpg', N'14446192_690410584449171_5507852671185493852_n19050230.jpg', N'Step1', 1, N'Complete', NULL)
INSERT [dbo].[Student_Master] ([Student_Id], [Parent_Id], [School_Code], [Application_Id], [first_name], [last_name], [middle_name], [FatherName], [FatherContactNumber], [FatherEmail], [MotherName], [MotherContactNumber], [MotherEmail], [HomeContactNumber], [LocalGurdianValue], [LocalGurdianName], [LocalGurdianEmail], [LocalGurdianPhone], [Gender_Id], [DOB], [POB], [PermanentAddress1], [PermanentAddress2], [permanentzipcode], [PerCountryId], [Per_District], [PerStateId], [PerCityId], [CurrentAddress1], [CurrentAddress2], [currentzipcode], [CountryId], [StateId], [District], [CityId], [Zip], [Cur_Landmark], [Per_Landmark], [Email], [Phone], [BloodGroup_Id], [BirthCertificate_Name], [BirthCertificatePath], [IdProof_Id], [IdProof_Number], [Passport_Number], [CitizenCountryId], [BCN], [BCN_Attachment_Name], [BCN_Attachment], [Special_Care], [Special_Care_Description], [Disability], [Disability_Percentage], [Disability_Description], [Disability_Certificate_Number], [DisabilityCertificat_Name], [DisabilityCertificatePath], [Caste], [Religion], [Special], [Physically_Hdc], [Hdc_Percent], [Is_Monitor], [Status], [AdmissionClass_Id], [Last_School_Name], [SchoolBoard_Id], [Last_School_Year], [Last_School_Class], [School_Transfer_Certifiate_Number], [SchoolTransferCertificate_Name], [SchoolTransferCertificatePath], [Last_School_Exam_Marks], [Last_School_Total_Marks], [Last_School_Marks_Percentage], [FinalExamResult_Name], [FinalExamResultPath], [Board_Exam_Marks], [Board_Total_Marks], [Marks_Percentage], [Board_Certificate_Number], [BoardExamResultName], [BoardExamResultPath], [BoardExamCertificate_Name], [BoardExamCertificatePath], [ImagePath], [SignaturePath], [Step_Complete], [TermsAndConditions], [Application_Status], [interview_note]) VALUES (1020, 1018, N'E3TQTHFGNEFI', N'EN2019416193540856', N'Narendra', N'Rajput', N'kumar', N'Rathindra Nath', N'1234567890', N'ani@gmail.com', N'L . Ray', N'1234567890', N'ani@gmail.com', N'1234567890', N'Yes', N'Sukumar panda', N'don@gmail.comm', N'1234567890', NULL, N'23/03/2019', N'Kolkata', N'Central London', N'123456', N'123456', NULL, NULL, NULL, NULL, N'Central London', N'123456', N'123456', 1, 38, NULL, 1166, NULL, NULL, NULL, NULL, NULL, 4, N'New Microsoft Office Word Document.docx', N'New Microsoft Office Word Document19364102.docx', 0, N'null', N'123456', 5, N'bvcc1231', NULL, NULL, 1, N'k', 2, N'70', N'Disability Description. ', N'12844560', N'null', N'null', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 7, N'Nabapally Boys School up', 1, N'2004', N'Five', N'58666666', N'null', N'null', N'750', N'630', N'119.05', N'yellowstone_5.jpg', N'yellowstone_519213258.jpg', N'', NULL, N'', N'', N'null', N'null', N'null', N'null', N'14479722_690410627782500_430618591424097528_n19050221.jpg', N'14446192_690410584449171_5507852671185493852_n19050230.jpg', N'Step1', 1, N'Complete', NULL)
INSERT [dbo].[Student_Master] ([Student_Id], [Parent_Id], [School_Code], [Application_Id], [first_name], [last_name], [middle_name], [FatherName], [FatherContactNumber], [FatherEmail], [MotherName], [MotherContactNumber], [MotherEmail], [HomeContactNumber], [LocalGurdianValue], [LocalGurdianName], [LocalGurdianEmail], [LocalGurdianPhone], [Gender_Id], [DOB], [POB], [PermanentAddress1], [PermanentAddress2], [permanentzipcode], [PerCountryId], [Per_District], [PerStateId], [PerCityId], [CurrentAddress1], [CurrentAddress2], [currentzipcode], [CountryId], [StateId], [District], [CityId], [Zip], [Cur_Landmark], [Per_Landmark], [Email], [Phone], [BloodGroup_Id], [BirthCertificate_Name], [BirthCertificatePath], [IdProof_Id], [IdProof_Number], [Passport_Number], [CitizenCountryId], [BCN], [BCN_Attachment_Name], [BCN_Attachment], [Special_Care], [Special_Care_Description], [Disability], [Disability_Percentage], [Disability_Description], [Disability_Certificate_Number], [DisabilityCertificat_Name], [DisabilityCertificatePath], [Caste], [Religion], [Special], [Physically_Hdc], [Hdc_Percent], [Is_Monitor], [Status], [AdmissionClass_Id], [Last_School_Name], [SchoolBoard_Id], [Last_School_Year], [Last_School_Class], [School_Transfer_Certifiate_Number], [SchoolTransferCertificate_Name], [SchoolTransferCertificatePath], [Last_School_Exam_Marks], [Last_School_Total_Marks], [Last_School_Marks_Percentage], [FinalExamResult_Name], [FinalExamResultPath], [Board_Exam_Marks], [Board_Total_Marks], [Marks_Percentage], [Board_Certificate_Number], [BoardExamResultName], [BoardExamResultPath], [BoardExamCertificate_Name], [BoardExamCertificatePath], [ImagePath], [SignaturePath], [Step_Complete], [TermsAndConditions], [Application_Status], [interview_note]) VALUES (1021, 1018, N'E3TQTHFGNEFI', N'EN2019417133412866', N'Narendra', N'Rajput', N'kumar', N'Rathindra Nath', N'1234567890', N'ani@gmail.com', N'L . Ray', N'1234567890', N'ani@gmail.com', N'1234567890', N'Yes', N'Sukumar panda', N'don@gmail.comm', N'1234567890', NULL, N'23/03/2019', N'Kolkata', N'Central London', N'123456', N'123456', NULL, NULL, NULL, NULL, N'Central London', N'123456', N'123456', 1, 38, NULL, 1166, NULL, NULL, NULL, NULL, NULL, 4, N'New Microsoft Office Word Document.docx', N'New Microsoft Office Word Document19364102.docx', 0, N'null', N'123456', 5, N'bvcc1231', NULL, NULL, 1, N'k', 2, N'70', N'Disability Description. ', N'12844560', N'null', N'null', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 7, N'Nabapally Boys School up', 1, N'2004', N'Five', N'58666666', N'null', N'null', N'750', N'630', N'119.05', N'yellowstone_5.jpg', N'yellowstone_519213258.jpg', N'', NULL, N'', N'', N'null', N'null', N'null', N'null', N'14479722_690410627782500_430618591424097528_n19050221.jpg', N'14446192_690410584449171_5507852671185493852_n19050230.jpg', N'Step1', 1, N'Complete', NULL)
INSERT [dbo].[Student_Master] ([Student_Id], [Parent_Id], [School_Code], [Application_Id], [first_name], [last_name], [middle_name], [FatherName], [FatherContactNumber], [FatherEmail], [MotherName], [MotherContactNumber], [MotherEmail], [HomeContactNumber], [LocalGurdianValue], [LocalGurdianName], [LocalGurdianEmail], [LocalGurdianPhone], [Gender_Id], [DOB], [POB], [PermanentAddress1], [PermanentAddress2], [permanentzipcode], [PerCountryId], [Per_District], [PerStateId], [PerCityId], [CurrentAddress1], [CurrentAddress2], [currentzipcode], [CountryId], [StateId], [District], [CityId], [Zip], [Cur_Landmark], [Per_Landmark], [Email], [Phone], [BloodGroup_Id], [BirthCertificate_Name], [BirthCertificatePath], [IdProof_Id], [IdProof_Number], [Passport_Number], [CitizenCountryId], [BCN], [BCN_Attachment_Name], [BCN_Attachment], [Special_Care], [Special_Care_Description], [Disability], [Disability_Percentage], [Disability_Description], [Disability_Certificate_Number], [DisabilityCertificat_Name], [DisabilityCertificatePath], [Caste], [Religion], [Special], [Physically_Hdc], [Hdc_Percent], [Is_Monitor], [Status], [AdmissionClass_Id], [Last_School_Name], [SchoolBoard_Id], [Last_School_Year], [Last_School_Class], [School_Transfer_Certifiate_Number], [SchoolTransferCertificate_Name], [SchoolTransferCertificatePath], [Last_School_Exam_Marks], [Last_School_Total_Marks], [Last_School_Marks_Percentage], [FinalExamResult_Name], [FinalExamResultPath], [Board_Exam_Marks], [Board_Total_Marks], [Marks_Percentage], [Board_Certificate_Number], [BoardExamResultName], [BoardExamResultPath], [BoardExamCertificate_Name], [BoardExamCertificatePath], [ImagePath], [SignaturePath], [Step_Complete], [TermsAndConditions], [Application_Status], [interview_note]) VALUES (2023, 2019, N'057KLZQ6Q68F', N'EN2019424185021830', N'Raj', N'Kar', N'Kumar', N'Mr P K Dey', N'1234567890', N'pk@gmail.com', N'Mrs K Dey', N'1234567890', N'kk@gmail.com', N'1234567890', N'Yes', N'T K Dey', N'tk@gmail.com', N'1234567890', NULL, N'24/07/2018', N'Kolkata', N'Central London', N'NA', N'700126', NULL, NULL, NULL, NULL, N'Central London', N'NA', N'700126', 1, 38, NULL, 1166, NULL, NULL, NULL, NULL, NULL, 2, N'th8XVU7L7F.jpg', N'th8XVU7L7F19502155.jpg', 4, N'146565656565', N'', 1, N'bvcc1231', NULL, NULL, 2, N'', 1, N'78', N'Disability Description. ', N'1284456', NULL, N'14441095_690410431115853_4316648889443898504_n19502158.jpg', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 12, N'Nabapally Boys School', 3, N'2004', N'Eleven', N'58666666', N'14517643_690410474449182_1216285545864557781_n.jpg', N'14517643_690410474449182_1216285545864557781_n19550387.jpg', N'', N'', N'', N'null', N'null', N'650', NULL, N'72.22', N'Bordcer123456', N'14433107_690410614449168_3019422085748242928_n.jpg', N'14433107_690410614449168_3019422085748242928_n19550392.jpg', N'14440702_690410484449181_7485634482134664735_n.jpg', N'14440702_690410484449181_7485634482134664735_n19550393.jpg', N'Yellowstone National Park 0119553590.jpg', N'yellowstone_519553593.jpg', N'Step5', 1, N'Eligible-Admission', N'retrtr')
INSERT [dbo].[Student_Master] ([Student_Id], [Parent_Id], [School_Code], [Application_Id], [first_name], [last_name], [middle_name], [FatherName], [FatherContactNumber], [FatherEmail], [MotherName], [MotherContactNumber], [MotherEmail], [HomeContactNumber], [LocalGurdianValue], [LocalGurdianName], [LocalGurdianEmail], [LocalGurdianPhone], [Gender_Id], [DOB], [POB], [PermanentAddress1], [PermanentAddress2], [permanentzipcode], [PerCountryId], [Per_District], [PerStateId], [PerCityId], [CurrentAddress1], [CurrentAddress2], [currentzipcode], [CountryId], [StateId], [District], [CityId], [Zip], [Cur_Landmark], [Per_Landmark], [Email], [Phone], [BloodGroup_Id], [BirthCertificate_Name], [BirthCertificatePath], [IdProof_Id], [IdProof_Number], [Passport_Number], [CitizenCountryId], [BCN], [BCN_Attachment_Name], [BCN_Attachment], [Special_Care], [Special_Care_Description], [Disability], [Disability_Percentage], [Disability_Description], [Disability_Certificate_Number], [DisabilityCertificat_Name], [DisabilityCertificatePath], [Caste], [Religion], [Special], [Physically_Hdc], [Hdc_Percent], [Is_Monitor], [Status], [AdmissionClass_Id], [Last_School_Name], [SchoolBoard_Id], [Last_School_Year], [Last_School_Class], [School_Transfer_Certifiate_Number], [SchoolTransferCertificate_Name], [SchoolTransferCertificatePath], [Last_School_Exam_Marks], [Last_School_Total_Marks], [Last_School_Marks_Percentage], [FinalExamResult_Name], [FinalExamResultPath], [Board_Exam_Marks], [Board_Total_Marks], [Marks_Percentage], [Board_Certificate_Number], [BoardExamResultName], [BoardExamResultPath], [BoardExamCertificate_Name], [BoardExamCertificatePath], [ImagePath], [SignaturePath], [Step_Complete], [TermsAndConditions], [Application_Status], [interview_note]) VALUES (2024, 2018, N'EC60JFWPWCVQ', N'EN202013161549920', N'Prantik', N'Saha', N'', N'R Kumar', N'0898234546', N'animesh@gmail.com', N'A kumar', N'0898234546', N'mother@gmail.com', N'0898234546', N'Yes', N'P Saha', N'sahaniloy24@gmail.com', N'0700374821', NULL, N'03/01/2020', N'kolkata', N'Ballygunge', N'', N'700039', NULL, NULL, NULL, NULL, N'Ballygunge', N'', N'700039', 1, 38, NULL, 1166, NULL, NULL, NULL, NULL, NULL, 4, N'changerequestfromchange.php', N'changerequestfromchange20370658.php', 2, N'sretrytu', N'rererer434', 1, N'65hhh', NULL, NULL, 1, N'65', 1, N'40', N'desc', N'nb454', N'null', N'null', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 9, N'Nabapally', 3, N'2001', N'ten', N'CER123555', N'f1e47792540d5d1d7657e04d54e96fb7.jpg', N'f1e47792540d5d1d7657e04d54e96fb720075075.jpg', N'615', N'800', N'76.88', N'ERD_For_Attendance.docx', N'ERD_For_Attendance20075075.docx', N'null', NULL, N'null', N'null', N'null', N'null', N'null', N'null', N'varwwwclientsclient1web2tmpphp0y4IuD20161166.jpg', N'iso-metrics20161168.jpg', N'Step2', 1, N'Admitted', NULL)
INSERT [dbo].[Student_Master] ([Student_Id], [Parent_Id], [School_Code], [Application_Id], [first_name], [last_name], [middle_name], [FatherName], [FatherContactNumber], [FatherEmail], [MotherName], [MotherContactNumber], [MotherEmail], [HomeContactNumber], [LocalGurdianValue], [LocalGurdianName], [LocalGurdianEmail], [LocalGurdianPhone], [Gender_Id], [DOB], [POB], [PermanentAddress1], [PermanentAddress2], [permanentzipcode], [PerCountryId], [Per_District], [PerStateId], [PerCityId], [CurrentAddress1], [CurrentAddress2], [currentzipcode], [CountryId], [StateId], [District], [CityId], [Zip], [Cur_Landmark], [Per_Landmark], [Email], [Phone], [BloodGroup_Id], [BirthCertificate_Name], [BirthCertificatePath], [IdProof_Id], [IdProof_Number], [Passport_Number], [CitizenCountryId], [BCN], [BCN_Attachment_Name], [BCN_Attachment], [Special_Care], [Special_Care_Description], [Disability], [Disability_Percentage], [Disability_Description], [Disability_Certificate_Number], [DisabilityCertificat_Name], [DisabilityCertificatePath], [Caste], [Religion], [Special], [Physically_Hdc], [Hdc_Percent], [Is_Monitor], [Status], [AdmissionClass_Id], [Last_School_Name], [SchoolBoard_Id], [Last_School_Year], [Last_School_Class], [School_Transfer_Certifiate_Number], [SchoolTransferCertificate_Name], [SchoolTransferCertificatePath], [Last_School_Exam_Marks], [Last_School_Total_Marks], [Last_School_Marks_Percentage], [FinalExamResult_Name], [FinalExamResultPath], [Board_Exam_Marks], [Board_Total_Marks], [Marks_Percentage], [Board_Certificate_Number], [BoardExamResultName], [BoardExamResultPath], [BoardExamCertificate_Name], [BoardExamCertificatePath], [ImagePath], [SignaturePath], [Step_Complete], [TermsAndConditions], [Application_Status], [interview_note]) VALUES (2025, 2018, N'EC60JFWPWCVQ', N'EN2020110163712936', N'Prantik', N'Saha', N'', N'R Kumar', N'0898234546', N'animesh@gmail.com', N'A kumar', N'0898234546', N'mother@gmail.com', N'0898234546', N'Yes', N'P Saha', N'sahaniloy24@gmail.com', N'0700374821', NULL, N'03/01/2020', N'kolkata', N'Ballygunge', N'', N'700039', NULL, NULL, NULL, NULL, N'Ballygunge', N'', N'700039', 1, 38, NULL, 1166, NULL, NULL, NULL, NULL, NULL, 4, N'changerequestfromchange.php', N'changerequestfromchange20370658.php', 2, N'sretrytu', N'rererer434', 1, N'65hhh', NULL, NULL, 1, N'65', 1, N'40', N'desc', N'nb454', N'null', N'null', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 9, N'Nabapally', 3, N'2001', N'ten', N'CER123555', N'f1e47792540d5d1d7657e04d54e96fb7.jpg', N'f1e47792540d5d1d7657e04d54e96fb720075075.jpg', N'615', N'800', N'76.88', N'ERD_For_Attendance.docx', N'ERD_For_Attendance20075075.docx', N'null', NULL, N'null', N'null', N'null', N'null', N'null', N'null', N'varwwwclientsclient1web2tmpphp0y4IuD20161166.jpg', N'iso-metrics20161168.jpg', N'Step2', 1, N'Admitted', NULL)
INSERT [dbo].[Student_Master] ([Student_Id], [Parent_Id], [School_Code], [Application_Id], [first_name], [last_name], [middle_name], [FatherName], [FatherContactNumber], [FatherEmail], [MotherName], [MotherContactNumber], [MotherEmail], [HomeContactNumber], [LocalGurdianValue], [LocalGurdianName], [LocalGurdianEmail], [LocalGurdianPhone], [Gender_Id], [DOB], [POB], [PermanentAddress1], [PermanentAddress2], [permanentzipcode], [PerCountryId], [Per_District], [PerStateId], [PerCityId], [CurrentAddress1], [CurrentAddress2], [currentzipcode], [CountryId], [StateId], [District], [CityId], [Zip], [Cur_Landmark], [Per_Landmark], [Email], [Phone], [BloodGroup_Id], [BirthCertificate_Name], [BirthCertificatePath], [IdProof_Id], [IdProof_Number], [Passport_Number], [CitizenCountryId], [BCN], [BCN_Attachment_Name], [BCN_Attachment], [Special_Care], [Special_Care_Description], [Disability], [Disability_Percentage], [Disability_Description], [Disability_Certificate_Number], [DisabilityCertificat_Name], [DisabilityCertificatePath], [Caste], [Religion], [Special], [Physically_Hdc], [Hdc_Percent], [Is_Monitor], [Status], [AdmissionClass_Id], [Last_School_Name], [SchoolBoard_Id], [Last_School_Year], [Last_School_Class], [School_Transfer_Certifiate_Number], [SchoolTransferCertificate_Name], [SchoolTransferCertificatePath], [Last_School_Exam_Marks], [Last_School_Total_Marks], [Last_School_Marks_Percentage], [FinalExamResult_Name], [FinalExamResultPath], [Board_Exam_Marks], [Board_Total_Marks], [Marks_Percentage], [Board_Certificate_Number], [BoardExamResultName], [BoardExamResultPath], [BoardExamCertificate_Name], [BoardExamCertificatePath], [ImagePath], [SignaturePath], [Step_Complete], [TermsAndConditions], [Application_Status], [interview_note]) VALUES (2026, 2018, N'EC60JFWPWCVQ', N'EN2020110194757980', N'Animesh', N'Kanjilal', N'', N'R Kumar', N'0898234546', N'animesh@gmail.com', N'A kumar', N'0898234546', N'mother@gmail.com', N'0898234546', N'Yes', N'P Saha', N'sahaniloy24@gmail.com', N'0700374821', NULL, N'10/01/2020', N'kolkata', N'Barasat', N'', N'700117', NULL, NULL, NULL, NULL, N'Barasat', N'', N'700117', 1, 38, NULL, 1166, NULL, NULL, NULL, NULL, NULL, 2, N'Imapct factor-1.jpg', N'Imapct factor-120475789.jpg', 1, N'sretrytu', N'rererer434', 1, N'65hhh', NULL, NULL, 1, N'65', 1, N'54', N'desc', N'54666', NULL, N'ERD_For_Attendance20475791.docx', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, N'Step2', NULL, N'In-Progress', NULL)
SET IDENTITY_INSERT [dbo].[Student_Master] OFF
SET IDENTITY_INSERT [dbo].[Student_Score_Master] ON 

INSERT [dbo].[Student_Score_Master] ([Student_Score_Id], [Session_Year], [School_Code], [School_Id], [Student_Id], [Class_Id], [Section_Id], [ExamTerm_Id], [Subject_Id], [Score]) VALUES (4, N'2020', N'EC60JFWPWCVQ', NULL, 6, 10, N'1', 1, 1, 90)
INSERT [dbo].[Student_Score_Master] ([Student_Score_Id], [Session_Year], [School_Code], [School_Id], [Student_Id], [Class_Id], [Section_Id], [ExamTerm_Id], [Subject_Id], [Score]) VALUES (5, N'2020', N'EC60JFWPWCVQ', NULL, 6, 10, N'1', 1, 2, 90)
INSERT [dbo].[Student_Score_Master] ([Student_Score_Id], [Session_Year], [School_Code], [School_Id], [Student_Id], [Class_Id], [Section_Id], [ExamTerm_Id], [Subject_Id], [Score]) VALUES (6, N'2020', N'EC60JFWPWCVQ', NULL, 6, 10, N'1', 1, 4, 90)
INSERT [dbo].[Student_Score_Master] ([Student_Score_Id], [Session_Year], [School_Code], [School_Id], [Student_Id], [Class_Id], [Section_Id], [ExamTerm_Id], [Subject_Id], [Score]) VALUES (7, N'2020', N'EC60JFWPWCVQ', NULL, 6, 10, N'1', 1, 1, 85)
INSERT [dbo].[Student_Score_Master] ([Student_Score_Id], [Session_Year], [School_Code], [School_Id], [Student_Id], [Class_Id], [Section_Id], [ExamTerm_Id], [Subject_Id], [Score]) VALUES (8, N'2020', N'EC60JFWPWCVQ', NULL, 6, 10, N'1', 1, 2, 85)
INSERT [dbo].[Student_Score_Master] ([Student_Score_Id], [Session_Year], [School_Code], [School_Id], [Student_Id], [Class_Id], [Section_Id], [ExamTerm_Id], [Subject_Id], [Score]) VALUES (9, N'2020', N'EC60JFWPWCVQ', NULL, 6, 10, N'1', 1, 4, 85)
INSERT [dbo].[Student_Score_Master] ([Student_Score_Id], [Session_Year], [School_Code], [School_Id], [Student_Id], [Class_Id], [Section_Id], [ExamTerm_Id], [Subject_Id], [Score]) VALUES (10, N'2020', N'EC60JFWPWCVQ', NULL, 6, 10, N'1', 1, 1, 100)
INSERT [dbo].[Student_Score_Master] ([Student_Score_Id], [Session_Year], [School_Code], [School_Id], [Student_Id], [Class_Id], [Section_Id], [ExamTerm_Id], [Subject_Id], [Score]) VALUES (11, N'2020', N'EC60JFWPWCVQ', NULL, 6, 10, N'1', 1, 2, 100)
INSERT [dbo].[Student_Score_Master] ([Student_Score_Id], [Session_Year], [School_Code], [School_Id], [Student_Id], [Class_Id], [Section_Id], [ExamTerm_Id], [Subject_Id], [Score]) VALUES (12, N'2020', N'EC60JFWPWCVQ', NULL, 6, 10, N'1', 1, 4, 100)
INSERT [dbo].[Student_Score_Master] ([Student_Score_Id], [Session_Year], [School_Code], [School_Id], [Student_Id], [Class_Id], [Section_Id], [ExamTerm_Id], [Subject_Id], [Score]) VALUES (13, N'2020', N'EC60JFWPWCVQ', NULL, 3, 10, N'1', 1, 1, 100)
INSERT [dbo].[Student_Score_Master] ([Student_Score_Id], [Session_Year], [School_Code], [School_Id], [Student_Id], [Class_Id], [Section_Id], [ExamTerm_Id], [Subject_Id], [Score]) VALUES (14, N'2020', N'EC60JFWPWCVQ', NULL, 3, 10, N'1', 1, 2, 100)
INSERT [dbo].[Student_Score_Master] ([Student_Score_Id], [Session_Year], [School_Code], [School_Id], [Student_Id], [Class_Id], [Section_Id], [ExamTerm_Id], [Subject_Id], [Score]) VALUES (15, N'2020', N'EC60JFWPWCVQ', NULL, 3, 10, N'1', 1, 4, 100)
SET IDENTITY_INSERT [dbo].[Student_Score_Master] OFF
SET IDENTITY_INSERT [dbo].[Teacher_Subject_Assign] ON 

INSERT [dbo].[Teacher_Subject_Assign] ([ID], [School_Code], [Emp_ID], [EmpType_ID], [Emp_Code], [Sub_ID], [Class_ID]) VALUES (1, N'EC60JFWPWCVQ', 10, NULL, NULL, 1, N',2,3,')
INSERT [dbo].[Teacher_Subject_Assign] ([ID], [School_Code], [Emp_ID], [EmpType_ID], [Emp_Code], [Sub_ID], [Class_ID]) VALUES (2, N'EC60JFWPWCVQ', 10, NULL, NULL, 2, N',1')
INSERT [dbo].[Teacher_Subject_Assign] ([ID], [School_Code], [Emp_ID], [EmpType_ID], [Emp_Code], [Sub_ID], [Class_ID]) VALUES (3, N'EC60JFWPWCVQ', 10, NULL, NULL, 5, N'2')
INSERT [dbo].[Teacher_Subject_Assign] ([ID], [School_Code], [Emp_ID], [EmpType_ID], [Emp_Code], [Sub_ID], [Class_ID]) VALUES (4, N'EC60JFWPWCVQ', 12, NULL, NULL, 1, N'1,2')
INSERT [dbo].[Teacher_Subject_Assign] ([ID], [School_Code], [Emp_ID], [EmpType_ID], [Emp_Code], [Sub_ID], [Class_ID]) VALUES (5, N'EC60JFWPWCVQ', 12, NULL, NULL, 2, N'4,5')
INSERT [dbo].[Teacher_Subject_Assign] ([ID], [School_Code], [Emp_ID], [EmpType_ID], [Emp_Code], [Sub_ID], [Class_ID]) VALUES (6, N'EC60JFWPWCVQ', 12, NULL, NULL, 3, N'1,2,3,4,5')
SET IDENTITY_INSERT [dbo].[Teacher_Subject_Assign] OFF
SET IDENTITY_INSERT [dbo].[Test_Type_Master] ON 

INSERT [dbo].[Test_Type_Master] ([Test_Type_Id], [Test_Type_Desc]) VALUES (1, N'Annual Exam')
INSERT [dbo].[Test_Type_Master] ([Test_Type_Id], [Test_Type_Desc]) VALUES (2, N'Half Yearly Exam')
INSERT [dbo].[Test_Type_Master] ([Test_Type_Id], [Test_Type_Desc]) VALUES (3, N'Class Test')
INSERT [dbo].[Test_Type_Master] ([Test_Type_Id], [Test_Type_Desc]) VALUES (4, N'Assignment')
INSERT [dbo].[Test_Type_Master] ([Test_Type_Id], [Test_Type_Desc]) VALUES (5, N'Home Work')
SET IDENTITY_INSERT [dbo].[Test_Type_Master] OFF
SET IDENTITY_INSERT [dbo].[Work_Role_Master] ON 

INSERT [dbo].[Work_Role_Master] ([id], [Parent_Menu_Order], [Parent_Menu], [Sub_Menu], [Sub_Menu_Cn], [Sub_Menu_Fn], [User_Type_Id]) VALUES (1, 1, N'1', N'Add  New Notice', N'SchoolAdmin', N'SchoolNoticeAdd', 4)
INSERT [dbo].[Work_Role_Master] ([id], [Parent_Menu_Order], [Parent_Menu], [Sub_Menu], [Sub_Menu_Cn], [Sub_Menu_Fn], [User_Type_Id]) VALUES (5, 1, N'1', N'Notice Listing', N'SchoolAdmin', N'ShowAllAdminNotice', 4)
INSERT [dbo].[Work_Role_Master] ([id], [Parent_Menu_Order], [Parent_Menu], [Sub_Menu], [Sub_Menu_Cn], [Sub_Menu_Fn], [User_Type_Id]) VALUES (7, 2, N'2', N'Fee Structure Listing', N'SchoolAdmin', N'ShowallFees', 4)
INSERT [dbo].[Work_Role_Master] ([id], [Parent_Menu_Order], [Parent_Menu], [Sub_Menu], [Sub_Menu_Cn], [Sub_Menu_Fn], [User_Type_Id]) VALUES (8, 2, N'2', N'Add New  Fees', N'SchoolAdmin', N'SchoolFeesMaster', 4)
INSERT [dbo].[Work_Role_Master] ([id], [Parent_Menu_Order], [Parent_Menu], [Sub_Menu], [Sub_Menu_Cn], [Sub_Menu_Fn], [User_Type_Id]) VALUES (15, 6, N'6', N'Parent Listing', N'SchoolAdmin', N'showallparents', 4)
INSERT [dbo].[Work_Role_Master] ([id], [Parent_Menu_Order], [Parent_Menu], [Sub_Menu], [Sub_Menu_Cn], [Sub_Menu_Fn], [User_Type_Id]) VALUES (16, 4, N'4', N'Employee Listing', N'SchoolAdmin', N'ShowallEmp', 4)
INSERT [dbo].[Work_Role_Master] ([id], [Parent_Menu_Order], [Parent_Menu], [Sub_Menu], [Sub_Menu_Cn], [Sub_Menu_Fn], [User_Type_Id]) VALUES (17, 4, N'4', N'Add New Employee', N'SchoolAdmin', N'SchoolEmployeeMaster', 4)
INSERT [dbo].[Work_Role_Master] ([id], [Parent_Menu_Order], [Parent_Menu], [Sub_Menu], [Sub_Menu_Cn], [Sub_Menu_Fn], [User_Type_Id]) VALUES (18, 8, N'8', N'Notice Listing', N'ParentDetails', N'ShowallNotice', 1)
INSERT [dbo].[Work_Role_Master] ([id], [Parent_Menu_Order], [Parent_Menu], [Sub_Menu], [Sub_Menu_Cn], [Sub_Menu_Fn], [User_Type_Id]) VALUES (19, 9, N'9', N'Update Profile Information', N'ParentDetails', N'UpdateParentInfo', 1)
INSERT [dbo].[Work_Role_Master] ([id], [Parent_Menu_Order], [Parent_Menu], [Sub_Menu], [Sub_Menu_Cn], [Sub_Menu_Fn], [User_Type_Id]) VALUES (20, 10, N'10', N'Fill New Application', N'StudentAdmission', N'StudentFormFillUp', 1)
INSERT [dbo].[Work_Role_Master] ([id], [Parent_Menu_Order], [Parent_Menu], [Sub_Menu], [Sub_Menu_Cn], [Sub_Menu_Fn], [User_Type_Id]) VALUES (21, 10, N'10', N'Application Listing', N'ParentDetails', N'ShowAllStudentApplication', 1)
INSERT [dbo].[Work_Role_Master] ([id], [Parent_Menu_Order], [Parent_Menu], [Sub_Menu], [Sub_Menu_Cn], [Sub_Menu_Fn], [User_Type_Id]) VALUES (22, 4, N'4', N'Employee Designation Listing', N'SchoolAdmin', N'ShowallEmpDesignation', 4)
INSERT [dbo].[Work_Role_Master] ([id], [Parent_Menu_Order], [Parent_Menu], [Sub_Menu], [Sub_Menu_Cn], [Sub_Menu_Fn], [User_Type_Id]) VALUES (23, 4, N'4', N'Add New Designation', N'SchoolAdmin', N'SchoolEmpTypeMaster', 4)
INSERT [dbo].[Work_Role_Master] ([id], [Parent_Menu_Order], [Parent_Menu], [Sub_Menu], [Sub_Menu_Cn], [Sub_Menu_Fn], [User_Type_Id]) VALUES (24, 12, N'12', N'Update Profile Information', N'Employee', N'UpdateEmployeeInfo', 3)
INSERT [dbo].[Work_Role_Master] ([id], [Parent_Menu_Order], [Parent_Menu], [Sub_Menu], [Sub_Menu_Cn], [Sub_Menu_Fn], [User_Type_Id]) VALUES (25, 11, N'11', N'Notice Listing', N'Employee', N'ShowallEmpNotice', 3)
INSERT [dbo].[Work_Role_Master] ([id], [Parent_Menu_Order], [Parent_Menu], [Sub_Menu], [Sub_Menu_Cn], [Sub_Menu_Fn], [User_Type_Id]) VALUES (26, 13, N'13', N'Notice Board', N'StudentDetail', N'ShowallStudentNotice', 2)
INSERT [dbo].[Work_Role_Master] ([id], [Parent_Menu_Order], [Parent_Menu], [Sub_Menu], [Sub_Menu_Cn], [Sub_Menu_Fn], [User_Type_Id]) VALUES (27, 5, N'5', N'Student Application Listing', N'SchoolAdmin', N'ShowallappliedStudent', 4)
INSERT [dbo].[Work_Role_Master] ([id], [Parent_Menu_Order], [Parent_Menu], [Sub_Menu], [Sub_Menu_Cn], [Sub_Menu_Fn], [User_Type_Id]) VALUES (29, 14, N'14', N'Add New Exam Term', N'SchoolAdmin', N'SchoolExamTermAdd', 4)
INSERT [dbo].[Work_Role_Master] ([id], [Parent_Menu_Order], [Parent_Menu], [Sub_Menu], [Sub_Menu_Cn], [Sub_Menu_Fn], [User_Type_Id]) VALUES (30, 14, N'14', N'Exam Term Listing', N'SchoolAdmin', N'ShowallExamTerm', 4)
INSERT [dbo].[Work_Role_Master] ([id], [Parent_Menu_Order], [Parent_Menu], [Sub_Menu], [Sub_Menu_Cn], [Sub_Menu_Fn], [User_Type_Id]) VALUES (31, 15, N'15', N'Class Note Add', N'Employee', N'AddClassNote', 3)
INSERT [dbo].[Work_Role_Master] ([id], [Parent_Menu_Order], [Parent_Menu], [Sub_Menu], [Sub_Menu_Cn], [Sub_Menu_Fn], [User_Type_Id]) VALUES (32, 16, N'16', N'Class Routine  Add', N'SchoolAdmin', N'SchoolRoutineData', 4)
INSERT [dbo].[Work_Role_Master] ([id], [Parent_Menu_Order], [Parent_Menu], [Sub_Menu], [Sub_Menu_Cn], [Sub_Menu_Fn], [User_Type_Id]) VALUES (33, 16, N'16', N'Class Routine Data Listing', N'SchoolAdmin', N'ShowallRoutineData', 4)
INSERT [dbo].[Work_Role_Master] ([id], [Parent_Menu_Order], [Parent_Menu], [Sub_Menu], [Sub_Menu_Cn], [Sub_Menu_Fn], [User_Type_Id]) VALUES (1033, 15, N'15', N'Class Note Listing', N'Employee', N'ShowallClassNoteData', 3)
INSERT [dbo].[Work_Role_Master] ([id], [Parent_Menu_Order], [Parent_Menu], [Sub_Menu], [Sub_Menu_Cn], [Sub_Menu_Fn], [User_Type_Id]) VALUES (1034, 14, N'14', N'Add Exam Schedule', N'SchoolAdmin', N'CreateExamSchedule', 4)
INSERT [dbo].[Work_Role_Master] ([id], [Parent_Menu_Order], [Parent_Menu], [Sub_Menu], [Sub_Menu_Cn], [Sub_Menu_Fn], [User_Type_Id]) VALUES (1035, 14, N'14', N'Exam Schedule Listing', N'SchoolAdmin', N'ViewExamSchedule', 4)
INSERT [dbo].[Work_Role_Master] ([id], [Parent_Menu_Order], [Parent_Menu], [Sub_Menu], [Sub_Menu_Cn], [Sub_Menu_Fn], [User_Type_Id]) VALUES (1036, 18, N'18', N'Add Exam Score', N'Employee', N'StudentMarksEntry', 3)
INSERT [dbo].[Work_Role_Master] ([id], [Parent_Menu_Order], [Parent_Menu], [Sub_Menu], [Sub_Menu_Cn], [Sub_Menu_Fn], [User_Type_Id]) VALUES (1037, 18, N'18', N'View Exam Score', N'Employee', N'ViewStudentMarks', 3)
INSERT [dbo].[Work_Role_Master] ([id], [Parent_Menu_Order], [Parent_Menu], [Sub_Menu], [Sub_Menu_Cn], [Sub_Menu_Fn], [User_Type_Id]) VALUES (1038, 19, N'19', N'Assign Subject to Teacher', N'SchoolAdmin', N'SubjectAssigned', 4)
INSERT [dbo].[Work_Role_Master] ([id], [Parent_Menu_Order], [Parent_Menu], [Sub_Menu], [Sub_Menu_Cn], [Sub_Menu_Fn], [User_Type_Id]) VALUES (1039, 19, N'19', N'View Subject Assigned', N'SchoolAdmin', N'SubjectAssignedList', 4)
INSERT [dbo].[Work_Role_Master] ([id], [Parent_Menu_Order], [Parent_Menu], [Sub_Menu], [Sub_Menu_Cn], [Sub_Menu_Fn], [User_Type_Id]) VALUES (1040, 20, N'20', N'Eligible Student', N'Employee', N'ShowallEligibleStudents', 3)
INSERT [dbo].[Work_Role_Master] ([id], [Parent_Menu_Order], [Parent_Menu], [Sub_Menu], [Sub_Menu_Cn], [Sub_Menu_Fn], [User_Type_Id]) VALUES (2041, 19, N'19', N'Add Subject', N'SchoolAdmin', N'AddSubject', 4)
INSERT [dbo].[Work_Role_Master] ([id], [Parent_Menu_Order], [Parent_Menu], [Sub_Menu], [Sub_Menu_Cn], [Sub_Menu_Fn], [User_Type_Id]) VALUES (2042, 19, N'19', N'Add Section', N'SchoolAdmin', N'AddSection', 4)
INSERT [dbo].[Work_Role_Master] ([id], [Parent_Menu_Order], [Parent_Menu], [Sub_Menu], [Sub_Menu_Cn], [Sub_Menu_Fn], [User_Type_Id]) VALUES (2043, 1023, N'1023', N'Add Room', N'SchoolAdmin', N'RoomMaster/0', 4)
INSERT [dbo].[Work_Role_Master] ([id], [Parent_Menu_Order], [Parent_Menu], [Sub_Menu], [Sub_Menu_Cn], [Sub_Menu_Fn], [User_Type_Id]) VALUES (2044, 1023, N'1023', N'Add Room Category', N'SchoolAdmin', N'School_RoomCategory/0', 4)
INSERT [dbo].[Work_Role_Master] ([id], [Parent_Menu_Order], [Parent_Menu], [Sub_Menu], [Sub_Menu_Cn], [Sub_Menu_Fn], [User_Type_Id]) VALUES (2045, 1024, N'1024', N'Add Student Attendance', N'Employee', N'Add_Student_Attendance', 3)
INSERT [dbo].[Work_Role_Master] ([id], [Parent_Menu_Order], [Parent_Menu], [Sub_Menu], [Sub_Menu_Cn], [Sub_Menu_Fn], [User_Type_Id]) VALUES (2046, 1025, N'1025', N'Period Master', N'SchoolAdmin', N'PeriodMaster', 4)
INSERT [dbo].[Work_Role_Master] ([id], [Parent_Menu_Order], [Parent_Menu], [Sub_Menu], [Sub_Menu_Cn], [Sub_Menu_Fn], [User_Type_Id]) VALUES (2047, 1026, N'1026', N'Holi Day/ Event', N'SchoolAdmin', N'CreateHoliday', 4)
INSERT [dbo].[Work_Role_Master] ([id], [Parent_Menu_Order], [Parent_Menu], [Sub_Menu], [Sub_Menu_Cn], [Sub_Menu_Fn], [User_Type_Id]) VALUES (2048, 1024, N'1024', N'View Student Attendance', N'Employee', N'View_Student_Attendance', 3)
SET IDENTITY_INSERT [dbo].[Work_Role_Master] OFF
SET IDENTITY_INSERT [dbo].[WorkGroup_Master] ON 

INSERT [dbo].[WorkGroup_Master] ([WorkGroup_Id], [WorkGroup_Name], [User_Type], [Parent_Menu_Cn], [Parent_Menu_Fn]) VALUES (1, N'Admin Notice ', N'4', N'DashBoard', N'AdminDashBoard')
INSERT [dbo].[WorkGroup_Master] ([WorkGroup_Id], [WorkGroup_Name], [User_Type], [Parent_Menu_Cn], [Parent_Menu_Fn]) VALUES (2, N'School Fees Structure', N'4', N'DashBoard', N'AdminDashBoard')
INSERT [dbo].[WorkGroup_Master] ([WorkGroup_Id], [WorkGroup_Name], [User_Type], [Parent_Menu_Cn], [Parent_Menu_Fn]) VALUES (3, N'', N'', N'', N'')
INSERT [dbo].[WorkGroup_Master] ([WorkGroup_Id], [WorkGroup_Name], [User_Type], [Parent_Menu_Cn], [Parent_Menu_Fn]) VALUES (4, N'Employee Information', N'4', N'DashBoard', N'AdminDashBoard')
INSERT [dbo].[WorkGroup_Master] ([WorkGroup_Id], [WorkGroup_Name], [User_Type], [Parent_Menu_Cn], [Parent_Menu_Fn]) VALUES (5, N'Student Application Details', N'4', N'DashBoard', N'AdminDashBoard')
INSERT [dbo].[WorkGroup_Master] ([WorkGroup_Id], [WorkGroup_Name], [User_Type], [Parent_Menu_Cn], [Parent_Menu_Fn]) VALUES (6, N'Parent Information', N'4', N'DashBoard', N'AdminDashBoard')
INSERT [dbo].[WorkGroup_Master] ([WorkGroup_Id], [WorkGroup_Name], [User_Type], [Parent_Menu_Cn], [Parent_Menu_Fn]) VALUES (8, N'Notice Board', N'1', N'DashBoard', N'ParentDashBoard')
INSERT [dbo].[WorkGroup_Master] ([WorkGroup_Id], [WorkGroup_Name], [User_Type], [Parent_Menu_Cn], [Parent_Menu_Fn]) VALUES (9, N'Profile Information', N'1', N'DashBoard', N'ParentDashBoard')
INSERT [dbo].[WorkGroup_Master] ([WorkGroup_Id], [WorkGroup_Name], [User_Type], [Parent_Menu_Cn], [Parent_Menu_Fn]) VALUES (10, N'Student Application Form', N'1', N'DashBoard', N'ParentDashBoard')
INSERT [dbo].[WorkGroup_Master] ([WorkGroup_Id], [WorkGroup_Name], [User_Type], [Parent_Menu_Cn], [Parent_Menu_Fn]) VALUES (11, N'Notice Board', N'3', N'DashBoard', N'EmployeeDashBoard')
INSERT [dbo].[WorkGroup_Master] ([WorkGroup_Id], [WorkGroup_Name], [User_Type], [Parent_Menu_Cn], [Parent_Menu_Fn]) VALUES (12, N'Profile Information', N'3', N'DashBoard', N'EmployeeDashBoard')
INSERT [dbo].[WorkGroup_Master] ([WorkGroup_Id], [WorkGroup_Name], [User_Type], [Parent_Menu_Cn], [Parent_Menu_Fn]) VALUES (13, N'Notice Board', N'2', N'DashBoard', N'StudentDashBoard')
INSERT [dbo].[WorkGroup_Master] ([WorkGroup_Id], [WorkGroup_Name], [User_Type], [Parent_Menu_Cn], [Parent_Menu_Fn]) VALUES (14, N'Examination', N'4', N'DashBoard', N'AdminDashBoard')
INSERT [dbo].[WorkGroup_Master] ([WorkGroup_Id], [WorkGroup_Name], [User_Type], [Parent_Menu_Cn], [Parent_Menu_Fn]) VALUES (15, N'Class Note Module', N'3', N'DashBoard', N'EmployeeDashBoard')
INSERT [dbo].[WorkGroup_Master] ([WorkGroup_Id], [WorkGroup_Name], [User_Type], [Parent_Menu_Cn], [Parent_Menu_Fn]) VALUES (16, N'Class Routine Module', N'4', N'DashBoard', N'AdminDashBoard')
INSERT [dbo].[WorkGroup_Master] ([WorkGroup_Id], [WorkGroup_Name], [User_Type], [Parent_Menu_Cn], [Parent_Menu_Fn]) VALUES (17, N'', N'', N'', N'')
INSERT [dbo].[WorkGroup_Master] ([WorkGroup_Id], [WorkGroup_Name], [User_Type], [Parent_Menu_Cn], [Parent_Menu_Fn]) VALUES (18, N'Exam Score Entry', N'3', N'DashBoard', N'EmployeeDashBoard')
INSERT [dbo].[WorkGroup_Master] ([WorkGroup_Id], [WorkGroup_Name], [User_Type], [Parent_Menu_Cn], [Parent_Menu_Fn]) VALUES (19, N'Assign Subject ', N'4', N'DashBoard', N'AdminDashBoard')
INSERT [dbo].[WorkGroup_Master] ([WorkGroup_Id], [WorkGroup_Name], [User_Type], [Parent_Menu_Cn], [Parent_Menu_Fn]) VALUES (20, N'Student Information', N'3', N'DashBoard', N'EmployeeDashBoard')
INSERT [dbo].[WorkGroup_Master] ([WorkGroup_Id], [WorkGroup_Name], [User_Type], [Parent_Menu_Cn], [Parent_Menu_Fn]) VALUES (21, N'Student Performance Graph', N'1', N'DashBoard', N'ParentDashBoard')
INSERT [dbo].[WorkGroup_Master] ([WorkGroup_Id], [WorkGroup_Name], [User_Type], [Parent_Menu_Cn], [Parent_Menu_Fn]) VALUES (22, N'School Calendar', N'1', N'DashBoard', N'ParentDashBoard')
INSERT [dbo].[WorkGroup_Master] ([WorkGroup_Id], [WorkGroup_Name], [User_Type], [Parent_Menu_Cn], [Parent_Menu_Fn]) VALUES (1023, N'School Room', N'4', N'DashBoard', N'AdminDashBoard')
INSERT [dbo].[WorkGroup_Master] ([WorkGroup_Id], [WorkGroup_Name], [User_Type], [Parent_Menu_Cn], [Parent_Menu_Fn]) VALUES (1024, N'Student Attendance', N'3', N'DashBoard', N'EmployeeDashBoard')
INSERT [dbo].[WorkGroup_Master] ([WorkGroup_Id], [WorkGroup_Name], [User_Type], [Parent_Menu_Cn], [Parent_Menu_Fn]) VALUES (1025, N'Creat Class Period ', N'4', N'DashBoard', N'AdminDashBoard')
INSERT [dbo].[WorkGroup_Master] ([WorkGroup_Id], [WorkGroup_Name], [User_Type], [Parent_Menu_Cn], [Parent_Menu_Fn]) VALUES (1026, N'Holi Day/Event', N'4', N'DashBoard', N'AdminDashBoard')
SET IDENTITY_INSERT [dbo].[WorkGroup_Master] OFF
SET IDENTITY_INSERT [dbo].[Year] ON 

INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (35, N'2010', N'2010')
INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (36, N'2011', N'2011')
INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (37, N'2012', N'2012')
INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (38, N'2013', N'2013')
INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (39, N'2014', N'2014')
INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (40, N'2015', N'2015')
INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (41, N'2016', N'2016')
INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (42, N'2017', N'2017')
INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (43, N'2018', N'2018')
INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (44, N'2019', N'2019')
INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (45, N'2020', N'2020')
INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (46, N'2021', N'2021')
INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (47, N'2022', N'2022')
INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (48, N'2023', N'2023')
INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (49, N'2024', N'2024')
INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (50, N'2025', N'2025')
INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (51, N'2026', N'2026')
INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (52, N'2027', N'2027')
INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (53, N'2028', N'2028')
INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (54, N'2029', N'2029')
INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (55, N'2030', N'2030')
INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (56, N'2031', N'2031')
INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (57, N'2032', N'2032')
INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (58, N'2033', N'2033')
INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (59, N'2034', N'2034')
INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (60, N'2035', N'2035')
INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (61, N'2036', N'2036')
INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (62, N'2037', N'2037')
INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (63, N'2038', N'2038')
INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (64, N'2039', N'2039')
INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (65, N'2040', N'2040')
INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (66, N'2041', N'2041')
INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (67, N'2042', N'2042')
INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (68, N'2043', N'2043')
INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (69, N'2044', N'2044')
INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (70, N'2045', N'2045')
INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (71, N'2046', N'2046')
INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (72, N'2047', N'2047')
INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (73, N'2048', N'2048')
INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (74, N'2049', N'2049')
INSERT [dbo].[Year] ([id], [Year], [Year_Name]) VALUES (75, N'2050', N'2050')
SET IDENTITY_INSERT [dbo].[Year] OFF
ALTER TABLE [dbo].[Student_Master] ADD  CONSTRAINT [DF_Student_Master_Local_gurdian]  DEFAULT ('No') FOR [LocalGurdianValue]
GO
/****** Object:  StoredProcedure [dbo].[ClassNote_InsertUpdateDelete]    Script Date: 2020-03-24 9:44:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ClassNote_InsertUpdateDelete]

@School_Id varchar(50)='null',
@School_Name varchar(MAX) = 'null',
@School_Code varchar(MAX) = 'null',
@Class_Id  varchar(MAX) = 'null',
@Section_Id varchar(MAX) = 'null',
@Subject_Id varchar(MAX) = 'null',
@Employee_Id varchar(50)='null',
@Topic_Name Text='null',
@Note_Description Text='null',
@Note_Date Text='null',
@Note_Type_Id varchar(50) = 'null',
@Query int

AS  
BEGIN  
IF (@Query = 1)  
BEGIN
  
INSERT INTO School_Class_Note(School_Id,School_Code,School_Name,Class_Id ,Section_Id,Subject_Id,Note_Date, Topic_Name,Employee_Id,Note_Description,Note_Type_Id)VALUES(@School_Id,@School_Code,@School_Name,@Class_Id,@Section_Id,@Subject_Id,@Note_Date,@Topic_Name,@Employee_Id,@Note_Description,@Note_Type_Id) 
--SELECT @New_Id=SCOPE_IDENTITY()
--INSERT INTO School_User_Master(User_Id, User_Email,User_Password,School_Code,User_Type)VALUES(@New_Id,@Employee_Email,@Employee_Password,@School_Code,@User_Type)

IF (@@ROWCOUNT > 0)  
BEGIN  
SELECT 'Insert'  
END  
END

--IF (@Query = 2)  
--BEGIN  
--UPDATE School_Fees_Master 
--SET Fees_Name =@Fees_Name,Fees_Desc=@Fees_Desc,Amount=@Amount  WHERE id=@Fees_Id AND School_Code=@School_Code   
------SELECT @New_Id=SCOPE_IDENTITY()
----UPDATE School_User_Master SET User_Email=@Employee_Email, User_Password=@Employee_Password WHERE User_Id=@Employee_Id AND User_Type='3'
--SELECT 'Update'  
--END

IF (@Query = 2)  
BEGIN  
--SELECT CN.id, CN.Topic_Name,CN.Note_Date,CN.Note_Description,CN.School_Name, CN.School_Id,CN.School_Code, EMP.Employee_Name, CM.Class_Name,ST.Section_Name ,NTP.Note_Type_Name FROM School_Class_Note AS CN, School_Employee_Details AS EMP, Class_Master AS CM, School_Section_Master AS ST,Note_Type_Master AS NTP WHERE CN.School_Code=@School_Code AND CN.Employee_Id=@Employee_Id AND CN.Class_Id= CM.Class_Id AND CN.Section_Id=ST.Section_Id AND CN.Note_Type_Id=NTP.Note_Type_Id AND CN.Employee_Id=EMP.Employee_Id
SELECT CN.id,CN.Topic_Name,CN.Note_Date,CN.Note_Description,CN.School_Name, CN.School_Id,CN.School_Code, EMP.Employee_Name, CM.Class_Name,ST.Section_Name ,NTP.Note_Type_Name , SB.Subject_Name FROM School_Class_Note AS CN, School_Employee_Details AS EMP, Class_Master AS CM, School_Section_Master AS ST,Note_Type_Master AS NTP ,School_Subject_Master AS SB WHERE CN.School_Code=@School_Code AND CN.Employee_Id=@Employee_Id AND CN.Class_Id= CM.Class_Id AND CN.Section_Id=ST.Section_Id AND CN.Note_Type_Id=NTP.Note_Type_Id AND CN.Employee_Id=EMP.Employee_Id AND CN.Subject_Id= SB.Subject_Id  ORDER BY CN.Note_Date DESC
SELECT 'Fetch'  
END

   
END 
GO
/****** Object:  StoredProcedure [dbo].[ClassRoutine_InsertUpdateDelete]    Script Date: 2020-03-24 9:44:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ClassRoutine_InsertUpdateDelete]

@School_Id varchar(50)='null',
@School_Name varchar(MAX) = 'null',
@School_Code varchar(MAX) = 'null',
@Start_Time  varchar(50) = 'null',
@End_Time varchar(50) = 'null',
@Class_Id varchar(50)='null',
@Section_Id varchar(50) = 'null',
@Employee_Id varchar(50) = 'null',
@Subject_Id varchar(50) = 'null',
@Room_Id varchar(50) = 'null',
@Year_Name varchar(50) = 'null',
@Day_Id varchar(50) = 'null',
@Period_Id varchar(50)= 'null',
@Query int

AS  
BEGIN  
IF (@Query = 1)  
BEGIN
  
INSERT INTO School_Class_Routine(School_Id,School_Code,School_Name,Start_Time, End_Time,Class_Id ,Section_Id,Employee_Id, Subject_Id,Room_Id,Year_Name,Day_Id,Period_Id)VALUES(@School_Id,@School_Code,@School_Name,@Start_Time,@End_Time,@Class_Id,@Section_Id,@Employee_Id,@Subject_Id,@Room_Id,@Year_Name,@Day_Id,@Period_Id) 
--SELECT @New_Id=SCOPE_IDENTITY()
--INSERT INTO School_User_Master(User_Id, User_Email,User_Password,School_Code,User_Type)VALUES(@New_Id,@Employee_Email,@Employee_Password,@School_Code,@User_Type)

IF (@@ROWCOUNT > 0)  
BEGIN  
SELECT 'Insert'  
END  
END

--IF (@Query = 2)  
--BEGIN  
--UPDATE School_Fees_Master 
--SET Fees_Name =@Fees_Name,Fees_Desc=@Fees_Desc,Amount=@Amount  WHERE id=@Fees_Id AND School_Code=@School_Code   
------SELECT @New_Id=SCOPE_IDENTITY()
----UPDATE School_User_Master SET User_Email=@Employee_Email, User_Password=@Employee_Password WHERE User_Id=@Employee_Id AND User_Type='3'
--SELECT 'Update'  
--END

IF (@Query = 2)  
BEGIN  
SELECT CS.Class_Name, ST.Section_Name , EMP.Employee_Name, SB.Subject_Name,SB.Subject_Code, RM.Room_Name ,DT.Day_Name , PM.Period_Name, CR.Class_Id, CR.Section_Id, CR.Day_Id ,CR.Start_Time,CR.End_Time,CR.Year_Name, CR.Routine_Id ,CR.School_Id, CR.School_Code, CR.School_Name FROM Class_Master AS CS, School_Section_Master AS ST , School_Employee_Details AS EMP , School_Subject_Master AS SB , School_Room_Master AS RM , DAY AS DT , Period_Master AS PM,  School_Class_Routine AS CR   WHERE  CR.School_Code=@School_Code AND  CR.Class_Id= CS.Class_Id AND CR.Section_Id= ST.Section_Id AND  CR.Employee_Id= EMP.Employee_Id AND CR.Subject_Id= SB.Subject_id AND CR.Room_Id= RM.Room_Id AND  CR.Day_Id= DT.Day_Id  AND CR.Period_Id= PM.Period_Id  GROUP BY CR.Class_Id,CR.Section_Id,  CS.Class_Name, ST.Section_Name , EMP.Employee_Name, SB.Subject_Name,SB.Subject_Code, RM.Room_Name ,DT.Day_Name , PM.Period_Name, CR.Class_Id, CR.Section_Id, CR.Day_Id ,CR.Start_Time,CR.End_Time,CR.Year_Name, CR.Routine_Id ,CR.School_Id, CR.School_Code, CR.School_Name ORDER BY CR.Day_Id ASC
SELECT 'Fetch'  
END

   
END 
GO
/****** Object:  StoredProcedure [dbo].[Designation_Fetch]    Script Date: 2020-03-24 9:44:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Designation_Fetch]


@School_Code varchar(MAX) = 'null',

 
@Query int

AS  
BEGIN  
--IF (@Query = 1)  
--BEGIN  
--INSERT INTO School_Fees_Master(School_Id,School_Code,Class_Id,Fees_Name, Fees_Desc,Amount,Fees_Year)VALUES(@School_Id,@School_Code,@Class_Id,@Fees_Name,@Fees_Desc,@Amount,@Year) 
----SELECT @New_Id=SCOPE_IDENTITY()
----INSERT INTO School_User_Master(User_Id, User_Email,User_Password,School_Code,User_Type)VALUES(@New_Id,@Employee_Email,@Employee_Password,@School_Code,@User_Type)

--IF (@@ROWCOUNT > 0)  
--BEGIN  
--SELECT 'Insert'  
--END  
--END

--IF (@Query = 2)  
--BEGIN  
--UPDATE School_Fees_Master 
--SET Fees_Name =@Fees_Name,Fees_Desc=@Fees_Desc,Amount=@Amount  WHERE id=@Fees_Id AND School_Code=@School_Code   
------SELECT @New_Id=SCOPE_IDENTITY()
----UPDATE School_User_Master SET User_Email=@Employee_Email, User_Password=@Employee_Password WHERE User_Id=@Employee_Id AND User_Type='3'
--SELECT 'Update'  
--END

IF (@Query = 1)  
BEGIN  
SELECT EMPT.* , UTM.*  FROM  School_EmpType_Master AS EMPT , School_User_Type_Master AS UTM   WHERE EMPT.School_Code = @School_Code  AND  EMPT.User_Type= UTM.User_Type_Id 
SELECT 'Fetch'  
END

IF (@Query = 2)  
BEGIN  
SELECT EMPT.*   FROM  School_EmpType_Master AS EMPT   WHERE EMPT.School_Code = @School_Code  

SELECT 'Fetch'  
END

   
END 
GO
/****** Object:  StoredProcedure [dbo].[Employee_InsertUpdateDelete]    Script Date: 2020-03-24 9:44:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Employee_InsertUpdateDelete]

@School_Id int='0',
@School_Code varchar(50) = 'null',
@School_Name varchar(50)='null',
@EmpType_Id int='0',
@Employee_Name  varchar(50)='null',
@Employee_Code  varchar(50)='null',
@Employee_Email varchar(50)='null',
@Employee_Password varchar(50)='null',
@Employee_Mobile_Number varchar(50)='null',
@Employee_Alt_Number varchar(50)='null' ,
@Employee_DOB varchar(50)='null' ,
@Employee_Id int='0',
@Query int,
@New_Id int ='0',
@User_Type int ='3'
AS  
BEGIN  
IF (@Query = 1)  
BEGIN  
INSERT INTO School_Employee_Details(School_Id,School_Code,School_Name,EmpType_Id, Employee_Name,Employee_Code,Employee_Email,Employee_Password,Employee_Mobile_Number,Employee_Alt_Number,Employee_DOB)VALUES(@School_Id,@School_Code,@School_Name,@EmpType_Id,@Employee_Name,@Employee_Code,@Employee_Email,@Employee_Password,@Employee_Mobile_Number,@Employee_Alt_Number,@Employee_DOB) 
SELECT @New_Id=SCOPE_IDENTITY()
INSERT INTO School_User_Master(User_Id, User_Email,User_Password,School_Code,User_Type)VALUES(@New_Id,@Employee_Email,@Employee_Password,@School_Code,@User_Type)

IF (@@ROWCOUNT > 0)  
BEGIN  
SELECT 'Insert'  
END  
END

IF (@Query = 2)  
BEGIN  
UPDATE School_Employee_Details  
SET Employee_Name =@Employee_Name,Employee_Email=@Employee_Email,Employee_Password=@Employee_Password ,Employee_Mobile_Number=@Employee_Mobile_Number,Employee_Alt_Number=@Employee_Alt_Number WHERE Employee_Id=@Employee_Id   
--SELECT @New_Id=SCOPE_IDENTITY()
UPDATE School_User_Master SET User_Email=@Employee_Email, User_Password=@Employee_Password WHERE User_Id=@Employee_Id AND User_Type='3'
SELECT 'Update'  
END

IF (@Query = 3)  
BEGIN  
SELECT ED.* , USM.* , ETM.* FROM  School_Employee_Details AS ED , School_User_Master AS USM  , School_EmpType_Master AS ETM where USM.School_Code = @School_Code AND USM.User_Email=@Employee_Email   AND USM.User_Id=@Employee_Id AND USM.User_Id= ED.Employee_Id AND ED.EmpType_Id=ETM.Type_Id AND USM.User_Type='3'
SELECT 'Fetch'  
END

   
END 

GO
/****** Object:  StoredProcedure [dbo].[Exam_Schedule_Insert_Update]    Script Date: 2020-03-24 9:44:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Exam_Schedule_Insert_Update]
@School_Id int='0',
@School_Code varchar(50) = 'null',
@Exam_Term_id int='0',
@Year varchar(50)='null' ,
@Class_Id   int='0',
@Section_Id int='0',
@Exam_Subject_Type varchar(50)=null,
@Subject_id int='0',
@Day_Id int='0',
@Exam_Date varchar(50)='null',
@Start_Time varchar(50)='null',
@End_Time varchar(50)='null',
@ExamSchedule_Idd int ='0',
@Class varchar(50)='null',
@Query int

AS  
BEGIN 
IF (@Query = 1)  
BEGIN TRY

INSERT INTO Exam_Schedule(School_Id,School_Code,ExamTerm_Id,Year,Class_Id,Section_Id,Exam_Subject_Type,Subject_Id,Day_Id,Exam_Date,Start_Time,End_Time)VALUES(@School_Id,@School_Code,@Exam_Term_id,@Year,@Class_Id,@Section_Id,@Exam_Subject_Type,@Subject_Id,@Day_Id,@Exam_Date,@Start_Time,@End_Time) 
--SELECT @New_Id=SCOPE_IDENTITY()
--INSERT INTO School_User_Master(User_Id, User_Email,User_Password,School_Code,User_Type)VALUES(@New_Id,@Employee_Email,@Employee_Password,@School_Code,@User_Type)

IF (@@ROWCOUNT > 0)  
BEGIN  
SELECT 'Insert'  
END  
END TRY 
BEGIN CATCH  
Print 'Error Occur that is:'  
Print Error_Message()  
END CATCH   

IF (@Query = 3)  
BEGIN  
SELECT ES.*,ETM.Exam_Term_Name,CM.Class_Name,SM.Section_Name,SSM.Subject_Name,DY.Day_Name  FROM Exam_Schedule AS ES, Class_Master AS CM ,School_Exam_Term_Master AS ETM,School_Section_Master AS SM,School_Subject_Master AS SSM,Day AS DY WHERE ES.School_Code =@School_Code AND
ES.ExamTerm_Id = ETM.Exam_Term_id AND 
ES.Class_Id= CM.Class_Id AND 
ES.Section_Id= SM.Section_Id AND
ES.Subject_Id = SSM.Subject_Id AND
ES.Day_Id = DY.Day_Id 

SELECT 'Fetch'  
END

IF (@Query = 4)  
BEGIN 

SELECT ES.*,ETM.Exam_Term_Name,CM.Class_Name,SM.Section_Name,SSM.Subject_Name  FROM Exam_Schedule AS ES, Class_Master AS CM ,School_Exam_Term_Master AS ETM,School_Section_Master AS SM,School_Subject_Master AS SSM WHERE ES.ExamTerm_Id = @ExamSchedule_Idd AND ES.ExamTerm_Id = ETM.Exam_Term_id AND ES.Class_Id = CM.Class_Id AND ES.Section_Id = SM.Section_Id AND ES.Subject_Id = SSM.Subject_Id  
         

SELECT 'Fetch'  
END
IF(@Query=5)
BEGIN
UPDATE Exam_Schedule SET Exam_Date = @Exam_Date,Start_Time = @Start_Time,End_Time = @End_Time WHERE ExamSchedule_Id=@ExamSchedule_Idd
SELECT 'UPDATE'  
END


   
END 
GO
/****** Object:  StoredProcedure [dbo].[ExamTerm_InsertUpdateDelete]    Script Date: 2020-03-24 9:44:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ExamTerm_InsertUpdateDelete]

@School_Id int='0',
@School_Name varchar(MAX) = 'null',
@School_Code varchar(50) = 'null',
@Class_Id  int='0',
@Exam_Term_Name varchar(MAX)='null',
@Query int

AS  
BEGIN  
IF (@Query = 1)  
BEGIN  
INSERT INTO School_Exam_Term_Master(School_Id,School_Code,School_Name,Class_Id ,Exam_Term_Name)VALUES(@School_Id,@School_Code,@School_Name,@Class_Id,@Exam_Term_Name) 
--SELECT @New_Id=SCOPE_IDENTITY()
--INSERT INTO School_User_Master(User_Id, User_Email,User_Password,School_Code,User_Type)VALUES(@New_Id,@Employee_Email,@Employee_Password,@School_Code,@User_Type)

IF (@@ROWCOUNT > 0)  
BEGIN  
SELECT 'Insert'  
END  
END

--IF (@Query = 2)  
--BEGIN  
--UPDATE School_Fees_Master 
--SET Fees_Name =@Fees_Name,Fees_Desc=@Fees_Desc,Amount=@Amount  WHERE id=@Fees_Id AND School_Code=@School_Code   
------SELECT @New_Id=SCOPE_IDENTITY()
----UPDATE School_User_Master SET User_Email=@Employee_Email, User_Password=@Employee_Password WHERE User_Id=@Employee_Id AND User_Type='3'
--SELECT 'Update'  
--END

IF (@Query = 2)  
BEGIN  
SELECT CM.* , SE.*  FROM  School_Exam_Term_Master AS SE , Class_Master AS CM   WHERE SE.School_Code = @School_Code  AND  SE.Class_Id= CM.Class_Id 
SELECT 'Fetch'  
END

  
END 
GO
/****** Object:  StoredProcedure [dbo].[Fees_InsertUpdateDelete]    Script Date: 2020-03-24 9:44:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Fees_InsertUpdateDelete]

@School_Id int='0',
@Fees_Id int='0',
@School_Code varchar(MAX) = 'null',
@Class_Id  varchar(MAX)='null',
@Fees_Name varchar(MAX)='null',
@Fees_Desc text ='null',
@Amount varchar(MAX)='null',
@Year varchar(MAX)='null' ,
@Class varchar(MAX)='null' ,
@Query int

AS  
BEGIN  
IF (@Query = 1)  
BEGIN  
INSERT INTO School_Fees_Master(School_Id,School_Code,Class_Id,Fees_Name, Fees_Desc,Amount,Fees_Year)VALUES(@School_Id,@School_Code,@Class_Id,@Fees_Name,@Fees_Desc,@Amount,@Year) 
--SELECT @New_Id=SCOPE_IDENTITY()
--INSERT INTO School_User_Master(User_Id, User_Email,User_Password,School_Code,User_Type)VALUES(@New_Id,@Employee_Email,@Employee_Password,@School_Code,@User_Type)

IF (@@ROWCOUNT > 0)  
BEGIN  
SELECT 'Insert'  
END  
END

IF (@Query = 2)  
BEGIN  
UPDATE School_Fees_Master 
SET Fees_Name =@Fees_Name,Fees_Desc=@Fees_Desc,Amount=@Amount  WHERE id=@Fees_Id AND School_Code=@School_Code   
----SELECT @New_Id=SCOPE_IDENTITY()
--UPDATE School_User_Master SET User_Email=@Employee_Email, User_Password=@Employee_Password WHERE User_Id=@Employee_Id AND User_Type='3'
SELECT 'Update'  
END

IF (@Query = 3)  
BEGIN  
SELECT SF.* , CM.*  FROM  School_Fees_Master AS SF , Class_Master AS CM   WHERE SF.School_Code = @School_Code  AND  SF.Class_Id= CM.Class_Id 
SELECT 'Fetch'  
END


IF (@Query = 4)  
BEGIN  
DELETE FROM School_Fees_Master  WHERE id=@Fees_Id AND School_Code=@School_Code
SELECT 'Delete'  
END

   
END 
GO
/****** Object:  StoredProcedure [dbo].[FETCH_STUDENT_APPLICATION_DETAILS]    Script Date: 2020-03-24 9:44:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[FETCH_STUDENT_APPLICATION_DETAILS]

@School_Code varchar(50),
@ParentID  int

AS
BEGIN

SELECT  SDT.*,CNT.CountryName,ST.StateName,CT.CityName,IDP.IdProof_Name,BRD.Board_Name,CLM.Class_Name, Isnull(SDT.first_name, '') + ' ' + Isnull(SDT.middle_name, '') + ' ' + Isnull(SDT.last_name, '') AS FullName

FROM

Student_Master AS SDT,

country AS CNT,

state AS ST,

city AS CT,

IdProof_Master AS IDP,

Class_Master AS CLM,

Board_Master AS BRD

WHERE 

SDT.School_Code= @School_Code  AND SDT.Parent_Id=@ParentID AND

SDT.CountryId=CNT.CountryId AND

SDT.StateId = ST.StateId AND

SDT.CityId = CT.CityId AND

SDT.IdProof_Id = IDP.IdProof_Id AND

SDT.AdmissionClass_Id=CLM.Class_Id ANd

SDT.SchoolBoard_Id = BRD.Board_Id AND

SDT.Application_Status = 'Complete'


END
GO
/****** Object:  StoredProcedure [dbo].[Notice_InsertUpdateDelete]    Script Date: 2020-03-24 9:44:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Notice_InsertUpdateDelete]

@School_Id int='0',
@School_Code varchar(50)=null,
@School_Name varchar(50)=null,
@Notice_Id int='0',
@Notice_Title  varchar(50)= null,
@Notice_Description  text = null,
@User_Type_Id int='0',
@Notice_Published_On varchar(50)=null,
@Notice_Status varchar(50)= 'Active',
@Query int
AS  
BEGIN  
IF (@Query = 1)  
BEGIN  
INSERT INTO School_Notice_Master (School_Id,School_Code,School_Name,Notice_Title, Notice_Description,User_Type_Id,Notice_Published_On,Notice_Status)VALUES(@School_Id,@School_Code, @School_Name,@Notice_Title,@Notice_Description,@User_Type_Id,@Notice_Published_On,@Notice_Status)
   
IF (@@ROWCOUNT > 0)  
BEGIN  
SELECT 'Insert'  
END  
END

IF(@Query = 2)  
BEGIN  
UPDATE School_Notice_Master  
SET Notice_Title = @Notice_Title,Notice_Description=@Notice_Description,Notice_Published_On=@Notice_Published_On WHERE Notice_Id=@Notice_Id  AND School_Code=@School_Code
SELECT 'Update'  
END   
END 
GO
/****** Object:  StoredProcedure [dbo].[Parent_InsertUpdateDelete]    Script Date: 2020-03-24 9:44:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Parent_InsertUpdateDelete]
 

@School_Code varchar(50)='null',
@ParentName varchar(50),  
@ParentContact varchar(50) ,  
@ParentEmail varchar(50),  
@ParentPassword varchar(50) ,
@ParentID int='0',
@Query int,  
@New_Id int ='0',
@User_Type int ='1'
AS  
BEGIN  
IF (@Query = 1)  
BEGIN  
INSERT INTO ParentRegistration(School_Code,ParentName, ParentContact, ParentEmail,ParentPassword) 
VALUES (@School_Code, @ParentName,@ParentContact,@ParentEmail,@ParentPassword)  
SELECT @New_Id=SCOPE_IDENTITY()
INSERT INTO School_User_Master(User_Id, User_Email,User_Password,School_Code,User_Type)VALUES(@New_Id,@ParentEmail,@ParentPassword,@School_Code,@User_Type)

   
IF (@@ROWCOUNT > 0)  
BEGIN  
SELECT 'Insert'  
END  
END
IF (@Query = 2)  
BEGIN  
UPDATE ParentRegistration  
SET ParentName = @ParentName,ParentContact=@ParentContact,ParentEmail=@ParentEmail,ParentPassword=@ParentPassword WHERE ParentID=@ParentID  
UPDATE School_User_Master SET User_Email=@ParentEmail, User_Password=@ParentPassword WHERE User_Id=@ParentID AND User_Type='1'
SELECT 'Update'  
END   
END 
GO
/****** Object:  StoredProcedure [dbo].[Parent_Registration]    Script Date: 2020-03-24 9:44:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[Parent_Registration]

@School_Code varchar(50),
@ParentName varchar(50),
@ParentContact varchar(50),
@ParentEmail varchar(50),
@ParentPassword varchar(50),
@New_Id int output,
@User_Type int ='1'

As 
BEGIN
INSERT INTO ParentRegistration(School_Code, ParentName,ParentContact,ParentEmail, ParentPassword)VALUES(@School_Code, @ParentName,@ParentContact, @ParentEmail,
@ParentPassword)

SELECT @New_Id=SCOPE_IDENTITY()
INSERT INTO School_User_Master(User_Id, User_Email,User_Password,School_Code,User_Type)VALUES(@New_Id,@ParentEmail,@ParentPassword,@School_Code,@User_Type)

END

GO
/****** Object:  StoredProcedure [dbo].[RoleAssigned]    Script Date: 2020-03-24 9:44:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RoleAssigned]
@Class_Id  varchar(50) = null,
@Emp_Type_Id  int=0,
@Sub_Id  int = 0,
@Emp_ID  varchar(50) = null,
@School_code varchar(50)=null,
@Emp_Code varchar(50)=null,
@sub_name varchar(50)=null,
@class_name varchar(50)=null,
@Query int
AS 
BEGIN 
IF (@Query = 1) 
BEGIN
 
INSERT INTO Teacher_Subject_Assign(Emp_ID,School_code,Sub_ID,Class_ID)
VALUES(@Emp_ID,@School_code,@Sub_ID,@Class_ID)
END
IF (@Query=3)
 BEGIN
  SELECT distinct sub.Subject_Name as subject_name, cls.Class_Name as class_name
 
  FROM Teacher_Subject_Assign as tsa, School_Subject_Master as sub, Class_Master as cls
  WHERE tsa.Emp_ID=@Emp_Code and tsa.Sub_ID=sub.Subject_id and CHARINDEX(CAST(cls.Class_Id AS varchar(50)), tsa.Class_ID)>0 
 END
 
  
IF (@Query=4)
 BEGIN
  Delete FROM Teacher_Subject_Assign
  WHERE Emp_ID=@Emp_Code and Sub_ID=(select Subject_id from School_Subject_Master where Subject_Name=@sub_name)
  and CHARINDEX(Cast((select Class_Id from Class_Master where Class_Name=@class_name) AS varchar(50)), Class_ID)>1
 END
 
END
GO
/****** Object:  StoredProcedure [dbo].[Routine]    Script Date: 2020-03-24 9:44:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Routine]

@category_id int=0,
@category_name varchar(max)=null,
@category_description varchar(max)=null,
@School_Code varchar(50)=null,
@School_Group_Code varchar(50)=null,
@id int=0,

@RoomName varchar(50)=null,
@RoomNo int=0,
@Floor int=0,
@RoomCategory varchar(50)=null,
@Occupied varchar(50)=null,
@class_name varchar(50)=null,
@Stime datetime=null,
@Etime datetime=null,
@Query int=0,
@Class_id int=0,

---for period
@pname varchar(50)=null,

@period int=0, 
@ptype varchar(50)=null,
@cname int=0, 
@duration int=0,

------Holiday
@fullday varchar(50)=null,
@holidayname varchar(50) =null,
@htype varchar(50)=null,
@description varchar(max)=null,
@SDate date=null,
@EDate date=null,
@themecolor varchar(50)=null,
@daytype varchar(50)=null,
@Event_ID int=0

AS  
BEGIN  
IF (@Query = 1)  
BEGIN
  
Insert into School_RoomCategory(Category_Name,Category_Description,School_Code,School_Group_Code)
values(@category_name,@category_description,@School_Code,@School_Group_Code)

END

IF (@Query = 2)  
BEGIN
  
Select Count(*) as cnt 
From School_RoomCategory
Where (Category_Name=@category_name and School_Code=@School_Code and School_Group_Code=@School_Group_Code)

END

IF (@Query = 3)  
BEGIN
  
Select * 
From School_RoomCategory
Where ( School_Code=@School_Code and School_Group_Code=@School_Group_Code)

END
IF (@Query=4)
BEGIN
     SELECT *
	 FROM School_RoomCategory
	 WHERE Category_id=@category_id

END
If (@Query=5)
BEGIN
Update School_RoomCategory
Set Category_Name= @category_name,
    Category_Description=@category_description
Where ( Category_id=@category_id)

END

If (@Query=6)
BEGIN
Delete from School_RoomCategory
Where ( Category_id=@category_id)

END 


if(@Query=7)
Begin

select *
from School_Room_Master

where ( School_Code=@School_Code and School_Group_Code=@School_Group_Code)
End

if(@Query=8)
Begin

insert into School_Room_Master(School_Code,School_Group_Code,Room_Name,Room_no,Floor,Room_Category,Occupied)
values(@School_Code,@School_Group_Code,@RoomName,@RoomNo,@Floor,@RoomCategory,@Occupied)

End

if(@Query=9)
Begin

Update School_Room_Master set
		School_Code = @School_Code,
		School_Group_Code=@School_Group_Code,
		Room_Name=@RoomName,

		Room_no=@RoomNo,
		Floor=@Floor,
		Room_Category=@RoomCategory,
		Occupied=@Occupied
		Where Room_ID=@id

End



if(@Query=10)
Begin

Select * from School_Room_Master 
		Where Room_ID=@id

End

if(@Query=11)
Begin

Select Count(*) as count 
from School_Room_Master 
Where Room_Name=@RoomName

End

if(@Query=12)
Begin

Select Count(*) as count 
from School_Room_Master 
Where Room_no=@RoomNo

End

if(@Query=13)
Begin
  Delete from School_Room_Master
  where Room_Id=@id


End



--inserting into class_master


if(@Query=20)
Begin
  insert into Class_Master(Class_Name,School_code,School_Group_Code,STime,ETime)
  values(@class_name,@School_Code,@School_Group_Code,@Stime,@Etime)


End


if(@Query=21)
Begin
  select count(*) as cnt
  from Class_Master
  where Class_Name=@class_name
  and School_code=@School_Code


End

if(@Query=22)
Begin
  select *
  from Class_Master
  where  School_code=@School_Code
  and School_Group_Code=@School_Group_Code


End


if(@Query=23)
Begin
  Delete from Class_Master
  where  Class_Id=@Class_id


End


if(@Query=24)
Begin
  Update Class_Master
  set Class_Name=@class_name,
  STime=@Stime,
  ETime=@Etime
  
  where  Class_Id=@Class_id


End
--------for period-------

  
  
if(@Query=26)
Begin
  select MAX(Order_period) as cnt
   from Period_Child
  where Class_Id=@id and School_Code=@School_Code


End

if(@Query=27)
Begin
  select MAX(Order_period) as cnt
   from Period_Master
  where Class_Id=@id and School_Code=@School_Code


End

if(@Query=28)
Begin
  select *
   from Period_Master
  where Class_Id=@id and School_Code=@School_Code


End

if(@Query=29)
Begin
  select *
   from Period_Child
  where Class_Id=@id and School_Code=@School_Code


End


if(@Query=30)
Begin
  select STime
   from Class_Master
  where Class_Id=@id and School_Code=@School_Code


End
if(@Query=31)
Begin
  
  insert into Period_Child(Period_Name,Order_period,Stime, Period_Type,Class_Id, Etime,Duration,School_Code,School_Group_Code)
  values(@pname,@period, @STime,@ptype,@cname,@ETime,@duration,@School_Code,@School_Group_Code)



End

if(@Query=32)
Begin
  
  Delete From Period_Child
  where Class_Id=@cname and School_Code=@School_Code and School_Group_Code=@School_Group_Code

End

if(@Query=33)
Begin
  
  insert into Period_Master(Period_Name,Period_type,Stime,Duration,Etime,Class_Id,School_Code,School_Group_Code,Order_period)
  select Period_Name,Period_type,Stime,Duration,Etime,Class_Id,School_Code,School_Group_Code,Order_period from Period_Child 
  where Class_Id=@cname and School_Code=@School_Code and School_Group_Code=@School_Group_Code

  Delete From Period_Child
  where Class_Id=@cname and School_Code=@School_Code and School_Group_Code=@School_Group_Code

End

if(@Query=34)
Begin
  
  
  Delete From Period_Master
  where Class_Id=@cname and School_Code=@School_Code and School_Group_Code=@School_Group_Code

End


---------for Holiday---





if(@Query=35)
Begin

select *
from Event_Calendar
where School_Code=@School_Code and School_Group_Code=@School_Group_Code

End
if(@Query=36)
Begin

select *
from Event_Calendar
where School_Code=@School_Code and School_Group_Code=@School_Group_Code

End



if(@Query=37)
Begin

insert into Event_Calendar(Subject,Description,IS_Full_Day,Start_Date,End_Date,Theme_Color,Event_Type,School_Code,School_Group_Code)


values (@holidayname,@description,@fullday,@SDate,@EDate,@themecolor,@htype,@School_Code,@School_Group_Code)

End
if(@Query=38)
Begin
		update Event_Calendar

		set Subject=@holidayname,
		Description=@description,
		IS_Full_Day=@fullday,
		Start_Date=@SDate,
		End_Date=@EDate,
		Event_type=@htype
		

		where Event_ID=@Event_ID
End


If(@Query=39)
Begin

		Delete From Event_Calendar
		where Event_ID=@Event_ID
End

END 


GO
/****** Object:  StoredProcedure [dbo].[School_Employee]    Script Date: 2020-03-24 9:44:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[School_Employee]


@School_Id int,
@School_Code varchar(50),
@School_Name varchar(50),
@EmpType_Id int,
@Employee_Name  varchar(50),
@Employee_Code  varchar(50),
@Employee_Email varchar(50),
@Employee_Password varchar(50),
@Employee_Mobile_Number varchar(50),
@Employee_Alt_Number varchar(50) ,
@Employee_DOB varchar(50) ,
@New_Id int output,
@User_Type int ='3'
As 
BEGIN
INSERT INTO School_Employee_Details(School_Id,School_Code,School_Name,EmpType_Id, Employee_Name,Employee_Code,Employee_Email,Employee_Password,Employee_Mobile_Number,Employee_Alt_Number,Employee_DOB)VALUES(@School_Id,@School_Code, @School_Name,@EmpType_Id,@Employee_Name,@Employee_Code,@Employee_Email,@Employee_Password,@Employee_Mobile_Number,@Employee_Alt_Number,@Employee_DOB)
SELECT @New_Id=SCOPE_IDENTITY()
INSERT INTO School_User_Master(User_Id, User_Email,User_Password,School_Code,User_Type)VALUES(@New_Id,@Employee_Email,@Employee_Password,@School_Code,@User_Type)

END
GO
/****** Object:  StoredProcedure [dbo].[School_EmpType]    Script Date: 2020-03-24 9:44:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[School_EmpType]

@School_Id int,
@School_Code varchar(50),
@School_Name varchar(50),
@EmpType_Name  varchar(50),
@User_Type varchar(MAX)='3'

As 
BEGIN
INSERT INTO School_EmpType_Master (School_Id,School_Code,School_Name,EmpType_Name,User_Type)VALUES(@School_Id,@School_Code, @School_Name,@EmpType_Name,@User_Type)
END

GO
/****** Object:  StoredProcedure [dbo].[School_InsertUpdateDelete]    Script Date: 2020-03-24 9:44:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[School_InsertUpdateDelete]
 
@SchoolName varchar(MAX),
@SchoolCode varchar(MAX),
@SchoolEmail varchar(MAX),
@SchoolPassword varchar(MAX),
@SchoolPhone varchar(MAX),
@SchoolContactPerson varchar(MAX),
@SchoolContactPersonEmail varchar(MAX),
@SchoolContactPersonPhone varchar(MAX),
@SchoolAddress1 varchar(MAX),
@SchoolAddress2  varchar(MAX),
@CountryId int,
@StateId int,
@CityId int,
@Board_Id int,
@Query int
AS  
BEGIN  
IF (@Query = 1)  
BEGIN  
INSERT INTO School_Details_Master(School_Code
           ,School_Name
           ,School_Email
           ,School_Password
           ,School_Phone
           ,School_Contact_Person
           ,School_Contact_Person_Email
           ,School_Contact_Person_Phone
           ,SchoolAddress1
           ,SchoolAddress2
           ,Country_Id
           ,State_Id
           ,City_Id
           ,Board_Id) 
VALUES (@SchoolCode,@SchoolName, @SchoolEmail,@SchoolPassword,@SchoolPhone,@SchoolContactPerson,@SchoolContactPersonEmail,@SchoolContactPersonPhone,@SchoolAddress1,@SchoolAddress2,@CountryId,@StateId,@CityId,@Board_Id) 
IF (@@ROWCOUNT > 0)  
BEGIN  
SELECT 'Insert'  
END  
END
--IF (@Query = 2)  
--BEGIN  
--UPDATE ParentRegistration  
--SET ParentName = @ParentName,ParentContact=@ParentContact,ParentEmail=@ParentEmail,ParentPassword=@ParentPassword WHERE ParentID=@Parent_Id   
--SELECT 'Update'  
--END   
END 
GO
/****** Object:  StoredProcedure [dbo].[School_Notice]    Script Date: 2020-03-24 9:44:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE Procedure [dbo].[School_Notice]
(

@School_Id int,
@School_Code varchar(50),
@School_Name varchar(50),
@Notice_Title  varchar(50),
@Notice_Description  varchar(50),
@User_Type_Id int,
@Notice_Published_On varchar(50),
@Notice_Status varchar(50)= 'Active'
)
As 
BEGIN
INSERT INTO School_Notice_Master (School_Id,School_Code,School_Name,Notice_Title, Notice_Description,User_Type_Id,Notice_Published_On,Notice_Status)VALUES(@School_Id,@School_Code, @School_Name,@Notice_Title,@Notice_Description,@User_Type_Id,@Notice_Published_On,@Notice_Status)
END
GO
/****** Object:  StoredProcedure [dbo].[School_Notice_Fetch]    Script Date: 2020-03-24 9:44:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[School_Notice_Fetch]

@School_Code varchar(50),
@Query int

AS  
BEGIN  
IF (@Query = 1)  
BEGIN  
 SET NOCOUNT ON;
SELECT * FROM School_Notice_Master where School_Code = @School_Code ORDER BY Notice_Published_On DESC
END
IF (@Query = 2) 
BEGIN
SET NOCOUNT ON;
SELECT * FROM School_Notice_Master where School_Code = @School_Code and User_Type_Id='3'  or User_Type_Id='2' ORDER BY Notice_Published_On DESC
END
IF (@Query = 3) 
BEGIN 
SELECT * FROM School_Notice_Master where School_Code = @School_Code and User_Type_Id='1' or User_Type_Id='2' ORDER BY Notice_Published_On DESC
END
IF (@Query = 4) 
BEGIN 
SELECT * FROM School_Notice_Master where School_Code = @School_Code and User_Type_Id='2' ORDER BY Notice_Published_On DESC
END
END
GO
/****** Object:  StoredProcedure [dbo].[School_Section]    Script Date: 2020-03-24 9:44:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[School_Section]
(

@School_Id int,
@School_Code varchar(50),
@School_Name varchar(50),
@Class_Id int,
@Section_Name  varchar(50),
@Section_Room_Number  int
)
As 
BEGIN
INSERT INTO School_Section_Master (School_Id,School_Code,School_Name,Class_Id, Section_Name,Section_Room_Number)VALUES(@School_Id,@School_Code, @School_Name,@Class_Id,@Section_Name,@Section_Room_Number)
END
GO
/****** Object:  StoredProcedure [dbo].[School_Subject]    Script Date: 2020-03-24 9:44:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[School_Subject]
(

@School_Id int,
@School_Code varchar(50),
@School_Name varchar(50),
@Class_Id int,
@subject_type varchar(50)=null,
@Additional_Subject varchar(50)='No',
@Subject_Name  varchar(50),
@priority_val int=0,
@exam_sub_type varchar(50)=null,
@Subject_Code  varchar(50),
@FullMarks int,
@PracticalMarks int=0,
@PassMarks int=0	
)
As 
BEGIN
INSERT INTO School_Subject_Master(School_Id,School_Code,School_Name,Class_Id,Subject_Type ,Subject_Name,Priority_Value,Exam_Sub_Type, Subject_Code,FullMarks,PracticalMarks,PassMarks,AdditionalSubject)VALUES(@School_Id,@School_Code, @School_Name,@Class_Id,@subject_type,@Subject_Name, @priority_val,@exam_sub_type,@Subject_Code,@FullMarks,@PracticalMarks,@PassMarks,@Additional_Subject)
END
GO
/****** Object:  StoredProcedure [dbo].[Select_ALL_ADMIN_Notice]    Script Date: 2020-03-24 9:44:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Select_ALL_ADMIN_Notice]
-- Add the parameters for the stored procedure here

@School_Code varchar(50) = null


AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;

   -- Insert statements for procedure here
SELECT * FROM School_Notice_Master where School_Code = @School_Code ORDER BY Notice_Published_On DESC
END
GO
/****** Object:  StoredProcedure [dbo].[Select_ALL_AppliedStudent]    Script Date: 2020-03-24 9:44:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Select_ALL_AppliedStudent]
(	-- Add the parameters for the stored procedure here

@School_Code varchar(50) = null
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.


    -- Insert statements for procedure here
SELECT  SDT.*,CNT.CountryName,ST.StateName,CT.CityName,IDP.IdProof_Name,BRD.Board_Name,CLM.Class_Name, Isnull(SDT.first_name, '') + ' ' + Isnull(SDT.middle_name, '') + ' ' + Isnull(SDT.last_name, '') AS FullName

FROM

Student_Master AS SDT,

country AS CNT,

state AS ST,

city AS CT,

IdProof_Master AS IDP,

Class_Master AS CLM,

Board_Master AS BRD
 
WHERE 

SDT.School_Code= @School_Code  AND
 
 SDT.CountryId=CNT.CountryId AND
 
 SDT.StateId = ST.StateId AND
 
 SDT.CityId = CT.CityId AND
 
 SDT.IdProof_Id = IDP.IdProof_Id AND
 
 SDT.AdmissionClass_Id=CLM.Class_Id ANd
 
 SDT.SchoolBoard_Id = BRD.Board_Id


END
GO
/****** Object:  StoredProcedure [dbo].[Select_ALL_Class]    Script Date: 2020-03-24 9:44:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Select_ALL_Class]


AS
BEGIN

SET NOCOUNT ON;

  
SELECT * FROM Class_Master 
END
GO
/****** Object:  StoredProcedure [dbo].[Select_ALL_EligiblityStudent]    Script Date: 2020-03-24 9:44:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[Select_ALL_EligiblityStudent]
(	-- Add the parameters for the stored procedure here

@School_Code varchar(50) = null
)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.


    -- Insert statements for procedure here
SELECT  SDT.*,  CNT.CountryName,ST.StateName,CT.CityName,IDP.IdProof_Name,BRD.Board_Name,CLM.Class_Name, Isnull(SDT.first_name, '') + ' ' + Isnull(SDT.middle_name, '') + ' ' + Isnull(SDT.last_name, '') AS FullName

FROM

Student_Master AS SDT,

country AS CNT,

state AS ST,

city AS CT,

IdProof_Master AS IDP,

Class_Master AS CLM,

Board_Master AS BRD
 
WHERE 

SDT.School_Code = @School_Code  AND
 
 SDT.CountryId=CNT.CountryId AND
 
 SDT.StateId = ST.StateId AND
 
 SDT.CityId = CT.CityId AND
 
 SDT.IdProof_Id = IDP.IdProof_Id AND
 
 SDT.AdmissionClass_Id=CLM.Class_Id ANd
 
 SDT.SchoolBoard_Id = BRD.Board_Id AND
 
 SDT.Application_Status = 'Eligible-Admission'

END
GO
/****** Object:  StoredProcedure [dbo].[Select_ALL_EMP_Notice]    Script Date: 2020-03-24 9:44:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Select_ALL_EMP_Notice]
-- Add the parameters for the stored procedure here

@School_Code varchar(50) = null


AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;

   -- Insert statements for procedure here
SELECT * FROM School_Notice_Master where School_Code = @School_Code and User_Type_Id='3'  or User_Type_Id='2' ORDER BY Notice_Published_On DESC
END
GO
/****** Object:  StoredProcedure [dbo].[Select_ALL_Employee]    Script Date: 2020-03-24 9:44:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Select_ALL_Employee]
-- Add the parameters for the stored procedure here

@School_Code varchar(50) = null


AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;

   -- Insert statements for procedure here
SELECT * FROM School_Employee_Details where School_Code = @School_Code ORDER BY Employee_Name DESC
END
GO
/****** Object:  StoredProcedure [dbo].[Select_ALL_Employee2]    Script Date: 2020-03-24 9:44:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[Select_ALL_Employee2]
-- Add the parameters for the stored procedure here

@School_Code varchar(50) = null


AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;

  -- Insert statements for procedure here
SELECT * FROM School_Employee_Details,School_EmpType_Master where  School_Employee_Details.EmpType_Id=School_EmpType_Master.Type_Id AND School_Employee_Details.School_Code = @School_Code ORDER BY Employee_Name DESC
END
GO
/****** Object:  StoredProcedure [dbo].[Select_ALL_Notice]    Script Date: 2020-03-24 9:44:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Select_ALL_Notice] 
-- Add the parameters for the stored procedure here
(
@School_Code varchar(50) = null
)

AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;

   -- Insert statements for procedure here
SELECT * FROM School_Notice_Master where School_Code = @School_Code and User_Type_Id='1' or User_Type_Id='2'
END
GO
/****** Object:  StoredProcedure [dbo].[Select_ALL_Parent]    Script Date: 2020-03-24 9:44:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[Select_ALL_Parent] 
-- Add the parameters for the stored procedure here
(
@SchoolCode varchar(50) = null
)

AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;

   -- Insert statements for procedure here
SELECT * FROM ParentRegistration where School_Code = @SchoolCode
END
GO
/****** Object:  StoredProcedure [dbo].[SELECT_EMPLOYEE_DETAILS]    Script Date: 2020-03-24 9:44:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SELECT_EMPLOYEE_DETAILS]
(
@Employee_Id int=null,
@School_Code varchar(50) = null,
@Employee_Name varchar(50)=null,
@Employee_Email varchar(50)=null,
@Employee_Password varchar(50)=null
)

AS
BEGIN
-- SET NOCOUNT ON added to prevent extra result sets from
-- interfering with SELECT statements.
SET NOCOUNT ON;

   -- Insert statements for procedure here
SELECT ED.* , USM.* , ETM.* FROM  School_Employee_Details AS ED , School_User_Master AS USM  , School_EmpType_Master AS ETM where USM.School_Code = @School_Code AND USM.User_Email=@Employee_Email   AND USM.User_Id=@Employee_Id AND USM.User_Id= ED.Employee_Id AND ED.EmpType_Id=ETM.Type_Id AND USM.User_Type='3'
END
GO
/****** Object:  StoredProcedure [dbo].[std_Parent_Registration]    Script Date: 2020-03-24 9:44:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE Procedure [dbo].[std_Parent_Registration]
(
@School_Id varchar(50),
@ParentName varchar(50),
@ParentContact varchar(50),
@ParentEmail varchar(50),
@ParentPassword varchar(50)
)
As 
BEGIN
INSERT INTO ParentRegistration(School_Code, ParentName,ParentContact,ParentEmail, ParentPassword)VALUES(@School_Id, @ParentName,@ParentContact, @ParentEmail,
@ParentPassword)
END

GO
/****** Object:  StoredProcedure [dbo].[std_School_Registration]    Script Date: 2020-03-24 9:44:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[std_School_Registration]
@SchoolName varchar(MAX),
@SchoolCode varchar(MAX),
@SchoolEmail varchar(MAX),
@SchoolPassword varchar(MAX),
@SchoolPhone varchar(MAX),
@SchoolContactPerson varchar(MAX),
@SchoolContactPersonEmail varchar(MAX),
@SchoolContactPersonPhone varchar(MAX),
@SchoolAddress1 varchar(MAX),
@SchoolAddress2  varchar(MAX),
@CountryId int,
@StateId int,
@CityId int,
@Board_Id int
AS
BEGIN
INSERT INTO School_Details_Master
           (School_Code
           ,School_Name
           ,School_Email
           ,School_Password
           ,School_Phone
           ,School_Contact_Person
           ,School_Contact_Person_Email
           ,School_Contact_Person_Phone
           ,SchoolAddress1
           ,SchoolAddress2
           ,Country_Id
           ,State_Id
           ,City_Id
           ,Board_Id)
     VALUES(@SchoolCode,@SchoolName, @SchoolEmail,@SchoolPassword,@SchoolPhone,@SchoolContactPerson,@SchoolContactPersonEmail,@SchoolContactPersonPhone,@SchoolAddress1,@SchoolAddress2,@CountryId,@StateId,@CityId,@Board_Id)


END
GO
/****** Object:  StoredProcedure [dbo].[STUDENT_APLLICATION_STATUS]    Script Date: 2020-03-24 9:44:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[STUDENT_APLLICATION_STATUS](
@Student_Id  int,
@Application_Status varchar(50)='null',
@School_Code varchar(50),
@Parent_Id  int,
@interview_note varchar(MAX)='null',
@StudentfilePath varchar(MAX)='null'
)
AS
BEGIN
IF(@Application_Status!='null')
UPDATE Student_Master SET 
Application_Status = @Application_Status
WHERE Student_Id=@Student_Id 
SELECT 'Update'  
END

BEGIN
IF(@interview_note !='null')
UPDATE Student_Master SET 
Application_Status = @Application_Status,
interview_note = @interview_note
WHERE Student_Id=@Student_Id 
SELECT 'Update'  
INSERT INTO Student_file_Attachemnt(School_Code,Student_Id,StudentfilePath)VALUES(@School_Code,@Student_Id,@StudentfilePath)
IF (@@ROWCOUNT > 0)  
BEGIN  
SELECT 'Insert'  

END
END
GO
/****** Object:  StoredProcedure [dbo].[Student_Attendance_InsertUpdate]    Script Date: 2020-03-24 9:44:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Student_Attendance_InsertUpdate]
@School_Id int='0',
@School_Name varchar(50) = 'null',
@School_Code varchar(50) = 'null',
@Session_Year varchar(50) ='null',
@Student_Id int='0',
@Class_Id  int='0',
@Section_Id int='0',
@Section_Name varchar(50)='null',
@Period_Date varchar(50)='null',
@Period_Id int ='0',
@Presence_Status varchar(50)='Absent',
@Query int

AS  
BEGIN  
IF (@Query = 1)  
BEGIN
---INSERT INTO Student_Attendance(School_Code,Student_Id,Class_Id,Section_Id)VALUES(@School_Code,@Student_Id,@Class_Id,@Section_Name)
INSERT INTO Student_Attendance(School_Code,Session_Year,Student_Id,Class_Id,Section_Id,Period_Date,Period_Id,Presence_Status)VALUES(@School_Code,@Session_Year,@Student_Id,@Class_Id,@Section_Id,@Period_Date,@Period_Id,@Presence_Status)
IF (@@ROWCOUNT > 0)  
BEGIN  
SELECT 'Insert'  
END  
END

   
END 
GO
/****** Object:  StoredProcedure [dbo].[Student_Group]    Script Date: 2020-03-24 9:44:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE Procedure [dbo].[Student_Group]
(
 @School_Id int,
@School_Code varchar(50),
@School_Name varchar(50),
@Group_Name  varchar(50)
)
As 
BEGIN
INSERT INTO Student_Group_Master(School_Id,School_Code,School_Name, Group_Name)VALUES(@School_Id,@School_Code, @School_Name,@Group_Name)
END

GO
/****** Object:  StoredProcedure [dbo].[Student_InsertUpdateDelete]    Script Date: 2020-03-24 9:44:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Student_InsertUpdateDelete]

@Student_Id int,
@School_Code varchar(50),
@Student_Email varchar(50),  
@Password varchar(50) ,  
@Application_Id varchar(MAX),  
@Query int,  
@New_Id int ='0',
@User_Type int ='2'
AS  
BEGIN  
IF (@Query = 1)  
BEGIN  
UPDATE School_Student_Details SET Student_Email=@Student_Email , Password=@Password , Registration_Status='Yes'  WHERE School_Code=@School_Code AND  Application_Id=@Application_Id
SELECT 'Update' 
SELECT @New_Id=SCOPE_IDENTITY()

INSERT INTO School_User_Master(User_Id, User_Email,User_Password,School_Code,User_Type)VALUES(@Student_Id,@Student_Email,@Password,@School_Code,@User_Type)

SELECT 'Insert'     



END
--IF (@Query = 2)  
--BEGIN  
--UPDATE ParentRegistration  
--SET ParentName = @ParentName,ParentContact=@ParentContact,ParentEmail=@ParentEmail,ParentPassword=@ParentPassword WHERE ParentID=@ParentID  
--UPDATE School_User_Master SET User_Email=@ParentEmail, User_Password=@ParentPassword WHERE User_Id=@ParentID AND User_Type='1'
--SELECT 'Update'  
--END   
END
GO
/****** Object:  StoredProcedure [dbo].[Student_Score_InsertUpdateDelete]    Script Date: 2020-03-24 9:44:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Student_Score_InsertUpdateDelete]

@School_Id int='0',
@School_Name varchar(50) = 'null',
@School_Code varchar(50) = 'null',
@Student_Id int='0',
@Class_Id  int='0',
@Section_Id int='0',
@Exam_Term_Name varchar(50) = 'null',
@ExamType_Id int='0',
@Session_Year varchar(50)='null',
@Section_Name varchar(50)='null',
@Subject_Id int='0',
@Score int='0',
@Query int

AS  
BEGIN  
IF (@Query = 1)  
BEGIN
INSERT INTO Student_Score_Master(Session_year,School_Code,Student_Id,Class_Id,Section_Id, ExamTerm_Id,Subject_Id,Score)VALUES(@Session_Year,@School_Code,@Student_Id,@Class_Id,@Section_Name, @ExamType_Id,@Subject_Id, @Score)
---INSERT INTO Student_Score_Master(School_Code,Student_Id)VALUES(@School_Code,@Student_Id)
IF (@@ROWCOUNT > 0)  
BEGIN  
SELECT 'Insert'  
END  
END

   
END 
GO
/****** Object:  StoredProcedure [dbo].[StudentAdmission_Formfillup]    Script Date: 2020-03-24 9:44:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[StudentAdmission_Formfillup]
(

@Query_step varchar(50),
@StepOne_status varchar(50)='null',
@Parent_Id int='0',
@School_Code varchar(50)='null',
@first_name varchar(50)='null',  
@middle_name varchar(50)='null' ,  
@last_name varchar(50)='null',  
@CurrentAddress1 varchar(50)='null',
@CurrentAddress2 varchar(50)='null',
@currentzipcode varchar(50)='null',
@CountryId int='0', 
@StateId int='0',
@CityId int='0',
@PermanentAddress1 varchar(50)='null',
@PermanentAddress2 varchar(50)='null',
@permanentzipcode varchar(50)='null',
@DOB varchar(50)='null',
@POB varchar(50)='null',
@BCN varchar(50)='null',
@CitizenCountryId int='0',

@BirthCertificate_Name varchar(MAX)='null',
@BirthCertificatePath varchar(MAX)='null',
@IdProof_Id int='0', 
@IdProof_Number varchar(50)='null',
@PassPort_Number varchar(50)='null',
@BloodGroup_Id int='0',
@Special_Care int='0',
@Special_Care_Description varchar(50)='null',
@Disability int='0',
@Disability_Percentage varchar(50)='null',
@Disability_Description varchar(50)='null', 
@Disability_Certificate_Number varchar(50)='null',
@DisabilityCertificat_Name varchar(MAX)='null',
@DisabilityCertificatePath varchar(MAX)='null',
 

@FatherName varchar(50)='null',
@FatherContactNumber varchar(50)='null',
@FatherEmail varchar(50)='null',
@MotherName varchar(50)='null',
@MotherContactNumber varchar(50)='null',
@MotherEmail varchar(50)='null',
@HomeContactNumber varchar(50)='null',
@LocalGurdianValue varchar(50)='No',
@LocalGurdianName varchar(50)='null',
@LocalGurdianEmail varchar(50)='null',
@LocalGurdianPhone varchar(50)='null',

@AdmissionClass_Id int='0',
@Last_School_Name varchar(50)='null',
@SchoolBoard_Id int='0',
@Last_School_Year varchar(50)='null',
@Last_School_Class varchar(50)='null',

@School_Transfer_Certifiate_Number varchar(50)='null',
@SchoolTransferCertificate_Name varchar(MAX)='null',
@SchoolTransferCertificatePath varchar(MAX)='null',
@Last_School_Exam_Marks varchar(50)='null',
@Last_School_Total_Marks varchar(50)='null',
@Last_School_Marks_Percentage varchar(50)='null',
@FinalExamResultPath varchar(MAX)='null',
@FinalExamResult_Name varchar(MAX)='null',
@Board_Exam_Marks varchar(50)='null',
@Board_Total_Marks varchar(50)='null',
@Marks_Percentage varchar(50)='null',
@Board_Certificate_Number varchar(50)='null',
@BoardExamResultName varchar(MAX)='null',
@BoardExamResultPath varchar(MAX)='null',
@BoardExamCertificate_Name varchar(MAX)='null',
@BoardExamCertificatePath varchar(MAX)='null',

@ImagePath varchar(MAX)='null',
@SignaturePath varchar(MAX)='null',
@TermsAndConditions bit ='0',
@Application_Status varchar(MAX)='In-Progress',
@Application_Id varchar(50)='null',


@School_Id int='0',
@Student_Id int='0',
@Class_Id  varchar(MAX)='null',
@Fees_Id int='0',
@Fees_Name varchar(MAX)='null',
@Fees_Desc text ='null',
@Amount varchar(MAX)='null',
@Year varchar(MAX)='null' ,
@Class varchar(MAX)='null',
@Paid_Status varchar(MAX)= 'null',
@remark_note varchar(MAX)= 'null'
/*@retValue int output*/  


)
AS  
BEGIN  
IF (@Query_step = 'Step1')  
BEGIN  
INSERT INTO Student_Master(Parent_Id,School_Code,Application_Id, first_name, middle_name, last_name, CurrentAddress1,CurrentAddress2,currentzipcode, CountryId, StateId, CityId,PermanentAddress1, PermanentAddress2,permanentzipcode, DOB,POB,BCN, CitizenCountryId,BirthCertificate_Name,BirthCertificatePath,IdProof_Id,IdProof_Number,PassPort_Number,BloodGroup_Id,Special_Care,Special_Care_Description,Disability,Disability_Percentage,Disability_Description,Disability_Certificate_Number,DisabilityCertificatePath,Step_Complete,Application_Status) 
VALUES (@Parent_Id,@School_Code,

(Select 'EN'+CONVERT(varchar,DATEPART(yy,getdate()))+
CONVERT(varchar,datepart(mm,getdate())) +
CONVERT(varchar,datepart(dd,getdate()))+
CONVERT(varchar,datepart(HH,getdate()))+
CONVERT(varchar,datepart(MI,getdate()))+
CONVERT(varchar,datepart(SS,getdate()))+
CONVERT(varchar,datepart(MS,getdate()))),

@first_name,@middle_name,@last_name,@CurrentAddress1,@CurrentAddress2,@currentzipcode,@CountryId,@StateId,@CityId,@PermanentAddress1,@PermanentAddress2,@permanentzipcode,@DOB,@POB,@BCN,@CitizenCountryId,@BirthCertificate_Name,@BirthCertificatePath,@IdProof_Id,@IdProof_Number ,@PassPort_Number ,@BloodGroup_Id,@Special_Care,@Special_Care_Description,@Disability,@Disability_Percentage,@Disability_Description,@Disability_Certificate_Number,@DisabilityCertificatePath,@Query_step,@Application_status )  
/*SELECT @retValue=SCOPE_IDENTITY()
Return @retValue*/
IF (@@ROWCOUNT > 0)  
BEGIN  
SELECT 'Insert'  

END



END


IF (@Query_step = 'Step1' AND @StepOne_status= 'In-Progress' )  
BEGIN  
/*First_Name = @first_name,Middle_Name=@middle_name,Last_Name=@last_name,Cur_Address1=@CurrentAddress1 */
UPDATE Student_Master SET 
first_name = @first_name, 
middle_name = @middle_name,
last_name = @last_name,
CurrentAddress1 = @CurrentAddress1,
CurrentAddress2 = @CurrentAddress2,
currentzipcode = @currentzipcode,
CountryId = @CountryId,
StateId = @StateId,
CityId = @CityId,
PermanentAddress1 = @PermanentAddress1,
PermanentAddress2 = @PermanentAddress2,
permanentzipcode=@permanentzipcode,
DOB=@DOB,
POB=@POB,
BCN=@BCN,
CitizenCountryId=@CitizenCountryId,
BirthCertificate_Name=@BirthCertificate_Name,
BirthCertificatePath=@BirthCertificatePath,
IdProof_Id=@IdProof_Id,
IdProof_Number=@IdProof_Number,
PassPort_Number=@PassPort_Number,
BloodGroup_Id=@BloodGroup_Id,
Special_Care=@Special_Care,
Special_Care_Description=@Special_Care_Description,
Disability=@Disability,
Disability_Percentage=@Disability_Percentage,
Disability_Description=@Disability_Description,
Disability_Certificate_Number=@Disability_Certificate_Number,
DisabilityCertificat_Name=@DisabilityCertificat_Name,
DisabilityCertificatePath=@DisabilityCertificatePath,
Step_Complete=@Query_step
WHERE Parent_Id = @Parent_Id AND School_Code = @School_Code

SELECT 'Update'  
END   



IF (@Query_step = 'Step2')  
BEGIN  
/*First_Name = @first_name,Middle_Name=@middle_name,Last_Name=@last_name,Cur_Address1=@CurrentAddress1 */
UPDATE Student_Master SET 
FatherName = @FatherName, 
FatherContactNumber = @FatherContactNumber,
FatherEmail = @FatherEmail,
MotherName = @MotherName,
MotherContactNumber = @MotherContactNumber,
MotherEmail = @MotherEmail,
HomeContactNumber = @HomeContactNumber,
LocalGurdianValue = @LocalGurdianValue,
LocalGurdianName = @LocalGurdianName,
LocalGurdianEmail = @LocalGurdianEmail,
LocalGurdianPhone = @LocalGurdianPhone,
Step_Complete=@Query_step
WHERE Parent_Id = @Parent_Id AND School_Code = @School_Code

SELECT 'Update'  
END   

IF (@Query_step = 'Step3')  
BEGIN  
/*First_Name = @first_name,Middle_Name=@middle_name,Last_Name=@last_name,Cur_Address1=@CurrentAddress1 */
UPDATE Student_Master SET 
AdmissionClass_Id = @AdmissionClass_Id, 
Last_School_Name = @Last_School_Name,
SchoolBoard_Id = @SchoolBoard_Id,
Last_School_Year = @Last_School_Year,
Last_School_Class = @Last_School_Class,
School_Transfer_Certifiate_Number = @School_Transfer_Certifiate_Number,
SchoolTransferCertificate_Name=@SchoolTransferCertificate_Name,
SchoolTransferCertificatePath=@SchoolTransferCertificatePath,
Last_School_Exam_Marks = @Last_School_Exam_Marks,
Last_School_Total_Marks = @Last_School_Total_Marks,
Last_School_Marks_Percentage = @Last_School_Marks_Percentage,
FinalExamResult_Name= @FinalExamResult_Name,
FinalExamResultPath= @FinalExamResultPath,
Board_Exam_Marks = @Board_Exam_Marks,
Marks_Percentage = @Marks_Percentage,
Board_Certificate_Number = @Board_Certificate_Number,
BoardExamResultName=@BoardExamResultName,
BoardExamResultPath=@BoardExamResultPath,
BoardExamCertificate_Name=@BoardExamCertificate_Name,
BoardExamCertificatePath=@BoardExamCertificatePath,
Step_Complete=@Query_step

WHERE Parent_Id = @Parent_Id AND School_Code = @School_Code

SELECT 'Update'  
END  

IF (@Query_step = 'Step4')  
BEGIN  
/*First_Name = @first_name,Middle_Name=@middle_name,Last_Name=@last_name,Cur_Address1=@CurrentAddress1 */
UPDATE Student_Master SET 
ImagePath = @ImagePath, 
SignaturePath = @SignaturePath,
Step_Complete = @Query_step
WHERE Parent_Id = @Parent_Id AND School_Code = @School_Code

SELECT 'Update'  
END    

IF (@Query_step = 'Step5')  
BEGIN  
/*First_Name = @first_name,Middle_Name=@middle_name,Last_Name=@last_name,Cur_Address1=@CurrentAddress1 */
UPDATE Student_Master SET 
TermsAndConditions = 1,
Step_Complete = @Query_step,
Application_Status = 'Complete' 
WHERE Parent_Id = @Parent_Id AND School_Code = @School_Code

SELECT 'Update'  
END  






IF (@Query_step = 'step6')  
BEGIN  
UPDATE Student_Master 
SET Application_Status = 'Admitted' WHERE School_Code = @School_Code AND Student_Id = @Student_Id
SELECT 'Update'  

INSERT  School_Student_Details       
       (Parent_Id
      ,School_Code
      ,Application_Id
      ,first_name
      ,last_name
      ,middle_name
      ,FatherName
      ,FatherContactNumber
      ,FatherEmail
      ,MotherName
      ,MotherContactNumber
      ,MotherEmail
      ,HomeContactNumber
      ,LocalGurdianValue
      ,LocalGurdianName
      ,LocalGurdianEmail
      ,LocalGurdianPhone
      ,Gender_Id
      ,DOB
      ,POB
      ,PermanentAddress1
      ,PermanentAddress2
      ,permanentzipcode
      ,PerCountryId
      ,Per_District
      ,PerStateId
      ,PerCityId
      ,CurrentAddress1
      ,CurrentAddress2
      ,currentzipcode
      ,CountryId
      ,StateId
      ,District
      ,CityId
      ,Zip
      ,Cur_Landmark
      ,Per_Landmark
      ,Email
      ,Phone
      ,BloodGroup_Id
      ,BirthCertificatePath
      ,IdProof_Id
      ,IdProof_Number
      ,Passport_Number
      ,CitizenCountryId
      ,BCN
      ,BCN_Attachment
      ,Special_Care
      ,Special_Care_Description
      ,Disability
      ,Disability_Percentage
      ,Disability_Description
      ,Disability_Certificate_Number
      ,DisabilityCertificatePath
      ,Caste
      ,Religion
      ,Special
      ,Physically_Hdc
      ,Hdc_Percent
      ,Is_Monitor
      ,[Status]
      ,AdmissionClass_Id
      ,Last_School_Name
      ,SchoolBoard_Id
      ,Last_School_Year
      ,Last_School_Class
      ,School_Transfer_Certifiate_Number
      ,SchoolTransferCertificatePath
      ,Last_School_Exam_Marks
      ,Last_School_Total_Marks
      ,Last_School_Marks_Percentage
      ,FinalExamResultPath
      ,Board_Exam_Marks
      ,Board_Total_Marks
      ,Marks_Percentage
      ,Board_Certificate_Number
      ,BoardExamResultPath
      ,BoardExamCertificatePath
      ,ImagePath
      ,SignaturePath      
      ,TermsAndConditions
      ,Application_Status)   	  
	  SELECT Parent_Id
      ,School_Code
      ,Application_Id
      ,first_name
      ,last_name
      ,middle_name
      ,FatherName
      ,FatherContactNumber
      ,FatherEmail
      ,MotherName
      ,MotherContactNumber
      ,MotherEmail
      ,HomeContactNumber
      ,LocalGurdianValue
      ,LocalGurdianName
      ,LocalGurdianEmail
      ,LocalGurdianPhone
      ,Gender_Id
      ,DOB
      ,POB
      ,PermanentAddress1
      ,PermanentAddress2
      ,permanentzipcode
      ,PerCountryId
      ,Per_District
      ,PerStateId
      ,PerCityId
      ,CurrentAddress1
      ,CurrentAddress2
      ,currentzipcode
      ,CountryId
      ,StateId
      ,District
      ,CityId
      ,Zip
      ,Cur_Landmark
      ,Per_Landmark
      ,Email
      ,Phone
      ,BloodGroup_Id
      ,BirthCertificatePath
      ,IdProof_Id
      ,IdProof_Number
      ,Passport_Number
      ,CitizenCountryId
      ,BCN
      ,BCN_Attachment
      ,Special_Care
      ,Special_Care_Description
      ,Disability
      ,Disability_Percentage
      ,Disability_Description
      ,Disability_Certificate_Number
      ,DisabilityCertificatePath
      ,Caste
      ,Religion
      ,Special
      ,Physically_Hdc
      ,Hdc_Percent
      ,Is_Monitor
      ,[Status]
      ,AdmissionClass_Id
      ,Last_School_Name
      ,SchoolBoard_Id
      ,Last_School_Year
      ,Last_School_Class
      ,School_Transfer_Certifiate_Number
      ,SchoolTransferCertificatePath
      ,Last_School_Exam_Marks
      ,Last_School_Total_Marks
      ,Last_School_Marks_Percentage
      ,FinalExamResultPath
      ,Board_Exam_Marks
      ,Board_Total_Marks
      ,Marks_Percentage
      ,Board_Certificate_Number
      ,BoardExamResultPath
      ,BoardExamCertificatePath
      ,ImagePath
      ,SignaturePath     
      ,TermsAndConditions
      ,Application_Status
      
FROM Student_Master WHERE School_Code = @School_Code AND Student_Id = @Student_Id

INSERT INTO Student_Fees_Master(student_id, School_Id, School_Code, Class_Id,Fees_Id, Fees_Name, Fees_Desc, Amount, Fees_Year,Paid_Status,remark_note)VALUES(@student_id,@School_Id,@School_Code,@Class_Id,@Fees_Id,@Fees_Name,@Fees_Desc,@Amount,@Year,@Paid_Status, @remark_note) 


IF (@@ROWCOUNT > 0)  
BEGIN  
SELECT 'Insert'  
END  
END




END 

GO
/****** Object:  StoredProcedure [dbo].[Students_performance]    Script Date: 2020-03-24 9:44:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[Students_performance]

@School_Code varchar(MAX) = 'null',
@ParentId  int=0,
@Query int,
@Student_ID int=0
AS  
BEGIN  
IF (@Query = 1)  
BEGIN
  select  * from Performance_Report
  where School_Code=@School_Code
  and Parent_ID=@ParentId
  and Student_ID=(select MIN(Student_ID) 
					from Performance_Report
					where School_Code=@School_Code
					and Parent_ID=@ParentId)

END

 
 IF (@Query = 2)  
BEGIN
  select distinct CONCAT(ssd.first_name,' ',ssd.middle_name,' ',ssd.last_name) as std_name, ssd.Student_Id as std_id
from Performance_Report pr, School_Student_Details ssd
where pr.School_Code=ssd.School_Code and pr.Parent_ID=ssd.Parent_Id
  and pr.School_Code=@School_Code
  and pr.Parent_ID=@ParentId

END
IF (@Query = 3)  
BEGIN
  select * from Performance_Report
  where Student_ID=@Student_ID

END   


END 
GO
/****** Object:  StoredProcedure [dbo].[WorkRole_Fetch]    Script Date: 2020-03-24 9:44:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[WorkRole_Fetch]

@Parent_Menu varchar(50)='null',
@Query int

AS  
BEGIN  
IF (@Query = 1)  
BEGIN  
SELECT id,Parent_Menu_Order,  Parent_Menu, Sub_Menu , Sub_Menu_Cn,Sub_Menu_Fn, User_Type_Id FROM Work_Role_Master WHERE  Parent_Menu=@Parent_Menu AND User_Type_Id='4'  GROUP BY Parent_Menu , Sub_Menu, Sub_Menu_Cn, Sub_Menu_Fn, User_Type_Id, id, Parent_Menu_Order ORDER BY Parent_Menu_Order ASC  

IF (@@ROWCOUNT > 0)  
BEGIN  
SELECT 'Fetch'  
END  
END

  
IF (@Query = 2)  
BEGIN  
SELECT *  FROM  WorkGroup_Master WHERE  User_Type='4'  

IF (@@ROWCOUNT > 0)  
BEGIN  
SELECT 'Fetch'  
END  
END

IF (@Query = 3)  
BEGIN  
SELECT *  FROM  WorkGroup_Master WHERE  User_Type='1'  

IF (@@ROWCOUNT > 0)  
BEGIN  
SELECT 'Fetch'  
END  
END






IF (@Query = 4)  
BEGIN  
SELECT id,Parent_Menu_Order,  Parent_Menu, Sub_Menu , Sub_Menu_Cn,Sub_Menu_Fn, User_Type_Id FROM Work_Role_Master WHERE  Parent_Menu=@Parent_Menu AND User_Type_Id='1'  GROUP BY Parent_Menu , Sub_Menu, Sub_Menu_Cn, Sub_Menu_Fn, User_Type_Id, id, Parent_Menu_Order ORDER BY Parent_Menu_Order ASC  

IF (@@ROWCOUNT > 0)  
BEGIN  
SELECT 'Fetch'  
END  
END

IF (@Query = 5)  
BEGIN  
SELECT id,Parent_Menu_Order,  Parent_Menu, Sub_Menu , Sub_Menu_Cn,Sub_Menu_Fn, User_Type_Id FROM Work_Role_Master WHERE  User_Type_Id='3'  GROUP BY Parent_Menu , Sub_Menu, Sub_Menu_Cn, Sub_Menu_Fn, User_Type_Id, id, Parent_Menu_Order ORDER BY Parent_Menu_Order ASC  

IF (@@ROWCOUNT > 0)  
BEGIN  
SELECT 'Fetch'  
END  
END


IF (@Query = 6)  
BEGIN  
SELECT *  FROM  WorkGroup_Master WHERE  User_Type='2'  

IF (@@ROWCOUNT > 0)  
BEGIN  
SELECT 'Fetch'  
END  
END



IF (@Query = 7)  
BEGIN  
SELECT id,Parent_Menu_Order,  Parent_Menu, Sub_Menu , Sub_Menu_Cn,Sub_Menu_Fn, User_Type_Id FROM Work_Role_Master WHERE  User_Type_Id='2'  GROUP BY Parent_Menu , Sub_Menu, Sub_Menu_Cn, Sub_Menu_Fn, User_Type_Id, id, Parent_Menu_Order ORDER BY Parent_Menu_Order ASC  

IF (@@ROWCOUNT > 0)  
BEGIN  
SELECT 'Fetch'  
END  
END


IF (@Query = 8)  
BEGIN  
SELECT *  FROM  WorkGroup_Master WHERE  User_Type='3'  

IF (@@ROWCOUNT > 0)  
BEGIN  
SELECT 'Fetch'  
END  
END



IF (@Query = 9)  
BEGIN  
SELECT id,Parent_Menu_Order,  Parent_Menu, Sub_Menu , Sub_Menu_Cn,Sub_Menu_Fn, User_Type_Id FROM Work_Role_Master WHERE  Parent_Menu=@Parent_Menu AND User_Type_Id='3'  GROUP BY Parent_Menu , Sub_Menu, Sub_Menu_Cn, Sub_Menu_Fn, User_Type_Id, id, Parent_Menu_Order ORDER BY Parent_Menu_Order ASC  

IF (@@ROWCOUNT > 0)  
BEGIN  
SELECT 'Fetch'  
END  
END


   
END 

GO
