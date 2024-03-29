USE [master]
GO
/****** Object:  Database [Proyecto_Educacion]    Script Date: 28/03/2024 20:13:40 ******/
CREATE DATABASE [Proyecto_Educacion]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Proyecto_Educacion', FILENAME = N'C:\SQLData\Proyecto_Educacion.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Proyecto_Educacion_log', FILENAME = N'C:\SQLData\Logs\Proyecto_Educacion_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Proyecto_Educacion] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Proyecto_Educacion].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Proyecto_Educacion] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Proyecto_Educacion] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Proyecto_Educacion] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Proyecto_Educacion] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Proyecto_Educacion] SET ARITHABORT OFF 
GO
ALTER DATABASE [Proyecto_Educacion] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Proyecto_Educacion] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Proyecto_Educacion] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Proyecto_Educacion] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Proyecto_Educacion] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Proyecto_Educacion] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Proyecto_Educacion] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Proyecto_Educacion] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Proyecto_Educacion] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Proyecto_Educacion] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Proyecto_Educacion] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Proyecto_Educacion] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Proyecto_Educacion] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Proyecto_Educacion] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Proyecto_Educacion] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Proyecto_Educacion] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Proyecto_Educacion] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Proyecto_Educacion] SET RECOVERY FULL 
GO
ALTER DATABASE [Proyecto_Educacion] SET  MULTI_USER 
GO
ALTER DATABASE [Proyecto_Educacion] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Proyecto_Educacion] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Proyecto_Educacion] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Proyecto_Educacion] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Proyecto_Educacion] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Proyecto_Educacion] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Proyecto_Educacion', N'ON'
GO
ALTER DATABASE [Proyecto_Educacion] SET QUERY_STORE = ON
GO
ALTER DATABASE [Proyecto_Educacion] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Proyecto_Educacion]
GO
/****** Object:  Table [dbo].[PAW_Answer]    Script Date: 28/03/2024 20:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PAW_Answer](
	[AnswerID] [int] IDENTITY(1,1) NOT NULL,
	[AssesmentID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AnswerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PAW_Assesment]    Script Date: 28/03/2024 20:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PAW_Assesment](
	[AssesmentID] [int] IDENTITY(1,1) NOT NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[MinimumGrade] [decimal](2, 2) NOT NULL,
	[CourseID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AssesmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paw_Course]    Script Date: 28/03/2024 20:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paw_Course](
	[CourseID] [int] IDENTITY(1,1) NOT NULL,
	[CourseTitle] [varchar](100) NOT NULL,
	[CourseDescription] [varchar](250) NOT NULL,
	[Estado] [bit] NOT NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PAW_ERROR]    Script Date: 28/03/2024 20:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PAW_ERROR](
	[ErrorID] [int] IDENTITY(1,1) NOT NULL,
	[ErrorName] [varchar](30) NULL,
PRIMARY KEY CLUSTERED 
(
	[ErrorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PAW_Lesson]    Script Date: 28/03/2024 20:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PAW_Lesson](
	[LessonID] [int] IDENTITY(1,1) NOT NULL,
	[LessonTitle] [varchar](100) NOT NULL,
	[LessonDescription] [varchar](1000) NOT NULL,
	[Estado] [bit] NOT NULL,
	[CourseID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[LessonID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PAW_Question]    Script Date: 28/03/2024 20:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PAW_Question](
	[QuestionID] [int] IDENTITY(1,1) NOT NULL,
	[AssesmentID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[QuestionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paw_Role]    Script Date: 28/03/2024 20:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paw_Role](
	[RoleID] [int] IDENTITY(1,1) NOT NULL,
	[NameRole] [varchar](45) NOT NULL,
	[Estado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PAW_SubHistory]    Script Date: 28/03/2024 20:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PAW_SubHistory](
	[SubHistoryID] [int] IDENTITY(1,1) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[SubscriptionID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SubHistoryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paw_Subscription]    Script Date: 28/03/2024 20:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paw_Subscription](
	[SubscriptionID] [int] IDENTITY(1,1) NOT NULL,
	[SubscriptionType] [varchar](25) NOT NULL,
	[SubscriptionPrice] [decimal](6, 2) NOT NULL,
	[Estado] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[SubscriptionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paw_User]    Script Date: 28/03/2024 20:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Paw_User](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[FirstNameUser] [varchar](45) NOT NULL,
	[LastNameUser] [varchar](45) NOT NULL,
	[EmailUser] [varchar](45) NOT NULL,
	[PasswordUser] [varchar](45) NOT NULL,
	[RoleID] [int] NOT NULL,
	[SubscriptionID] [int] NOT NULL,
	[Estado] [bit] NOT NULL,
	[Temporary] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PAW_User_Course]    Script Date: 28/03/2024 20:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PAW_User_Course](
	[UserCourseID] [int] IDENTITY(1,1) NOT NULL,
	[Estado] [bit] NOT NULL,
	[UserID] [int] NOT NULL,
	[CourseID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserCourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PAW_Video]    Script Date: 28/03/2024 20:13:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PAW_Video](
	[VideoID] [int] IDENTITY(1,1) NOT NULL,
	[VideoUrl] [varchar](1000) NOT NULL,
	[MiniPictureUrl] [varchar](1000) NOT NULL,
	[LessonID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[VideoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Paw_Role] ON 

INSERT [dbo].[Paw_Role] ([RoleID], [NameRole], [Estado]) VALUES (1, N'Profesor', 1)
INSERT [dbo].[Paw_Role] ([RoleID], [NameRole], [Estado]) VALUES (2, N'Estudiante', 1)
INSERT [dbo].[Paw_Role] ([RoleID], [NameRole], [Estado]) VALUES (3, N'Admin', 1)
SET IDENTITY_INSERT [dbo].[Paw_Role] OFF
GO
SET IDENTITY_INSERT [dbo].[Paw_Subscription] ON 

INSERT [dbo].[Paw_Subscription] ([SubscriptionID], [SubscriptionType], [SubscriptionPrice], [Estado]) VALUES (1, N'Regular', CAST(2500.00 AS Decimal(6, 2)), 1)
INSERT [dbo].[Paw_Subscription] ([SubscriptionID], [SubscriptionType], [SubscriptionPrice], [Estado]) VALUES (2, N'Premium', CAST(7500.00 AS Decimal(6, 2)), 1)
INSERT [dbo].[Paw_Subscription] ([SubscriptionID], [SubscriptionType], [SubscriptionPrice], [Estado]) VALUES (3, N'Premium Extra', CAST(9000.00 AS Decimal(6, 2)), 1)
INSERT [dbo].[Paw_Subscription] ([SubscriptionID], [SubscriptionType], [SubscriptionPrice], [Estado]) VALUES (4, N'Sin Subscripcion', CAST(0.00 AS Decimal(6, 2)), 1)
SET IDENTITY_INSERT [dbo].[Paw_Subscription] OFF
GO
SET IDENTITY_INSERT [dbo].[Paw_User] ON 

INSERT [dbo].[Paw_User] ([UserID], [FirstNameUser], [LastNameUser], [EmailUser], [PasswordUser], [RoleID], [SubscriptionID], [Estado], [Temporary]) VALUES (23, N'Bryan', N'Cantillo', N'bryandc681@gmail.com', N'uzwF1n+m1Y0ePgdPZpCTfg==', 1, 4, 1, 0)
SET IDENTITY_INSERT [dbo].[Paw_User] OFF
GO
ALTER TABLE [dbo].[PAW_Answer]  WITH CHECK ADD  CONSTRAINT [FK_ASSESMENT_ANSWER] FOREIGN KEY([AssesmentID])
REFERENCES [dbo].[PAW_Assesment] ([AssesmentID])
GO
ALTER TABLE [dbo].[PAW_Answer] CHECK CONSTRAINT [FK_ASSESMENT_ANSWER]
GO
ALTER TABLE [dbo].[PAW_Assesment]  WITH CHECK ADD  CONSTRAINT [FK_Lesson_Assesment] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Paw_Course] ([CourseID])
GO
ALTER TABLE [dbo].[PAW_Assesment] CHECK CONSTRAINT [FK_Lesson_Assesment]
GO
ALTER TABLE [dbo].[PAW_Lesson]  WITH CHECK ADD  CONSTRAINT [FK_COURSE_LESSON] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Paw_Course] ([CourseID])
GO
ALTER TABLE [dbo].[PAW_Lesson] CHECK CONSTRAINT [FK_COURSE_LESSON]
GO
ALTER TABLE [dbo].[PAW_Question]  WITH CHECK ADD  CONSTRAINT [FK_ASSESMENT_QUESTION] FOREIGN KEY([AssesmentID])
REFERENCES [dbo].[PAW_Assesment] ([AssesmentID])
GO
ALTER TABLE [dbo].[PAW_Question] CHECK CONSTRAINT [FK_ASSESMENT_QUESTION]
GO
ALTER TABLE [dbo].[PAW_SubHistory]  WITH CHECK ADD  CONSTRAINT [FK_SUBSCRIPTION_ID_HISTORY] FOREIGN KEY([SubscriptionID])
REFERENCES [dbo].[Paw_Subscription] ([SubscriptionID])
GO
ALTER TABLE [dbo].[PAW_SubHistory] CHECK CONSTRAINT [FK_SUBSCRIPTION_ID_HISTORY]
GO
ALTER TABLE [dbo].[PAW_SubHistory]  WITH CHECK ADD  CONSTRAINT [FK_USER_ID] FOREIGN KEY([UserID])
REFERENCES [dbo].[Paw_User] ([UserID])
GO
ALTER TABLE [dbo].[PAW_SubHistory] CHECK CONSTRAINT [FK_USER_ID]
GO
ALTER TABLE [dbo].[Paw_User]  WITH CHECK ADD  CONSTRAINT [FK_ROLE_ID] FOREIGN KEY([RoleID])
REFERENCES [dbo].[Paw_Role] ([RoleID])
GO
ALTER TABLE [dbo].[Paw_User] CHECK CONSTRAINT [FK_ROLE_ID]
GO
ALTER TABLE [dbo].[Paw_User]  WITH CHECK ADD  CONSTRAINT [FK_Subscription_ID] FOREIGN KEY([SubscriptionID])
REFERENCES [dbo].[Paw_Subscription] ([SubscriptionID])
GO
ALTER TABLE [dbo].[Paw_User] CHECK CONSTRAINT [FK_Subscription_ID]
GO
ALTER TABLE [dbo].[PAW_User_Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_User] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Paw_Course] ([CourseID])
GO
ALTER TABLE [dbo].[PAW_User_Course] CHECK CONSTRAINT [FK_Course_User]
GO
ALTER TABLE [dbo].[PAW_User_Course]  WITH CHECK ADD  CONSTRAINT [FK_USER_COURSE] FOREIGN KEY([UserID])
REFERENCES [dbo].[Paw_User] ([UserID])
GO
ALTER TABLE [dbo].[PAW_User_Course] CHECK CONSTRAINT [FK_USER_COURSE]
GO
ALTER TABLE [dbo].[PAW_Video]  WITH CHECK ADD  CONSTRAINT [FK_LESSON_VIDEO] FOREIGN KEY([LessonID])
REFERENCES [dbo].[PAW_Lesson] ([LessonID])
GO
ALTER TABLE [dbo].[PAW_Video] CHECK CONSTRAINT [FK_LESSON_VIDEO]
GO
/****** Object:  StoredProcedure [dbo].[ChangePassword]    Script Date: 28/03/2024 20:13:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE    PROCEDURE [dbo].[ChangePassword]
	@EmailUser				VARCHAR(200),
	@PasswordUser			VARCHAR(200),
	@TemporalPassword			VARCHAR(200),
	@Temporary				BIT
AS
BEGIN

	DECLARE @Consecutive BIGINT
	
	SELECT  @Consecutive = UserID
	FROM	Paw_User
	WHERE	EmailUser = @EmailUser
		AND PasswordUser = @TemporalPassword
		AND Estado = 1

	IF @Consecutive IS NOT NULL
	BEGIN
		UPDATE Paw_User
		SET PasswordUser = @PasswordUser,
			Temporary = @Temporary
		WHERE EmailUser = @EmailUser
	END

	SELECT	UserID,EmailUser,U.FirstNameUser 'FirstNameUser',U.RoleID,R.NameRole 'NameRole', U.Estado,Temporary
	  FROM	Paw_User U
	  INNER JOIN Paw_Role R ON U.RoleID = R.RoleID
	  WHERE	EmailUser = @EmailUser
		AND U.Estado = 1

END
GO
/****** Object:  StoredProcedure [dbo].[Login]    Script Date: 28/03/2024 20:13:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE     PROCEDURE [dbo].[Login]
	@EmailUser		VARCHAR(200),
    @PasswordUser	VARCHAR(200)
AS
BEGIN
	
	SELECT	U.UserID,U.EmailUser,U.FirstNameUser 'FirstNameUser',U.RoleID,R.NameRole 'NameRole',U.Estado,U.Temporary
	  FROM	Paw_User U
	  INNER JOIN Paw_Role R ON U.RoleID = R.RoleID
	  WHERE	EmailUser = @EmailUser
		AND PasswordUser = @PasswordUser
		AND U.Estado = 1

END
GO
/****** Object:  StoredProcedure [dbo].[RecoverAccess]    Script Date: 28/03/2024 20:13:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE     PROCEDURE [dbo].[RecoverAccess]
	@EmailUser			VARCHAR(200),
	@PasswordUser	VARCHAR(200),
	@Temporary		BIT
AS
BEGIN

	DECLARE @Consecutivo BIGINT
	
	SELECT  @Consecutivo = UserID
	FROM	PAW_USER
	WHERE	EmailUser = EmailUser
		AND Estado = 1

	IF @Consecutivo IS NOT NULL
	BEGIN
		UPDATE PAW_USER
		SET PasswordUser = @PasswordUser,
			Temporary = @Temporary
		WHERE EmailUser = EmailUser
	END

	SELECT	UserID,EmailUser,U.FirstNameUser 'FirstNameUser',U.RoleID,R.Estado 'NombreRol',U.Estado,Temporary
	  FROM	PAW_USER U
	  INNER JOIN Paw_Role R ON U.RoleID = R.RoleID
	  WHERE	EmailUser = @EmailUser
		AND U.Estado = 1

END
GO
/****** Object:  StoredProcedure [dbo].[RegisterUser]    Script Date: 28/03/2024 20:13:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[RegisterUser]
	@FirstNameUser	VARCHAR(45),
    @LastNameUser	VARCHAR(45),
    @EmailUser	VARCHAR(45),
	@PasswordUser	VARCHAR(45)
AS
BEGIN
	IF NOT EXISTS(SELECT 1 FROM Paw_User WHERE EmailUser = @EmailUser)
	BEGIN
		INSERT INTO dbo.Paw_User(FirstNameUser, LastNameUser, EmailUser, PasswordUser, RoleID, SubscriptionID, Estado, Temporary )
		VALUES (@FirstNameUser,@LastNameUser,@EmailUser, @PasswordUser, 1,4,1,0);
	END
END
GO
USE [master]
GO
ALTER DATABASE [Proyecto_Educacion] SET  READ_WRITE 
GO
