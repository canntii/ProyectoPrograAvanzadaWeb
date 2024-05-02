USE [master]
GO
/****** Object:  Database [Proyecto_Educacion]    Script Date: 4/27/2024 6:49:09 AM ******/
CREATE DATABASE [Proyecto_Educacion]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Proyecto_Educacion', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Proyecto_Educacion.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Proyecto_Educacion_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\Proyecto_Educacion_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
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
ALTER DATABASE [Proyecto_Educacion] SET  DISABLE_BROKER 
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
/****** Object:  Table [dbo].[PAW_Assesment]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PAW_Assesment](
	[AssesmentID] [int] IDENTITY(1,1) NOT NULL,
	[StartDate] [date] NULL,
	[EndDate] [date] NULL,
	[MinimumGrade] [decimal](18, 0) NULL,
	[CourseID] [int] NOT NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[AssesmentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paw_Course]    Script Date: 4/27/2024 6:49:09 AM ******/
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
	[PictureUrl] [varchar](1000) NULL,
	[UserId] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CourseID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PAW_ERROR]    Script Date: 4/27/2024 6:49:09 AM ******/
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
/****** Object:  Table [dbo].[PAW_Lesson]    Script Date: 4/27/2024 6:49:09 AM ******/
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
/****** Object:  Table [dbo].[PAW_Question]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PAW_Question](
	[QuestionID] [int] IDENTITY(1,1) NOT NULL,
	[AssesmentID] [int] NOT NULL,
	[QuestionDesc] [varchar](500) NULL,
	[Correct] [varchar](500) NULL,
	[Estado] [bit] NULL,
PRIMARY KEY CLUSTERED 
(
	[QuestionID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Paw_Role]    Script Date: 4/27/2024 6:49:09 AM ******/
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
/****** Object:  Table [dbo].[PAW_SubHistory]    Script Date: 4/27/2024 6:49:09 AM ******/
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
/****** Object:  Table [dbo].[Paw_Subscription]    Script Date: 4/27/2024 6:49:09 AM ******/
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
/****** Object:  Table [dbo].[Paw_User]    Script Date: 4/27/2024 6:49:09 AM ******/
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
	[IsTeacher] [int] NULL,
	[PictureUrl] [varchar](1000) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PAW_User_Course]    Script Date: 4/27/2024 6:49:09 AM ******/
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
/****** Object:  Table [dbo].[PAW_Video]    Script Date: 4/27/2024 6:49:09 AM ******/
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
ALTER TABLE [dbo].[PAW_Assesment]  WITH CHECK ADD  CONSTRAINT [FK_Lesson_Assesment] FOREIGN KEY([CourseID])
REFERENCES [dbo].[Paw_Course] ([CourseID])
GO
ALTER TABLE [dbo].[PAW_Assesment] CHECK CONSTRAINT [FK_Lesson_Assesment]
GO
ALTER TABLE [dbo].[Paw_Course]  WITH CHECK ADD  CONSTRAINT [FK_Paw_CourseCreate_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[Paw_User] ([UserID])
GO
ALTER TABLE [dbo].[Paw_Course] CHECK CONSTRAINT [FK_Paw_CourseCreate_User]
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
/****** Object:  StoredProcedure [dbo].[AcceptOrRejectProfessor]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AcceptOrRejectProfessor]

    @UserID INT,
	@AcceptOrReject INT

AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM PAW_USER
        WHERE UserID = @UserID
    )
    BEGIN

		IF(@AcceptOrReject = 3) --SI ACEPTAMOS, ENTONCES EL USUARIO CONSERVA SU IMAGEN
		BEGIN
			UPDATE PAW_USER 
			SET IsTeacher = @AcceptOrReject ,
			RoleId = 2
			WHERE UserID = @UserID;

			SELECT * 
			FROM PAW_USER
			WHERE UserID = @UserID;
		END
		ELSE  --DE LO CONTRARIO PASAMOS LA IMAGEN A NULL
		BEGIN
			UPDATE PAW_USER 
			SET IsTeacher = @AcceptOrReject, PictureUrl = NULL, RoleID = 1 -- Quitamos la foto del profesor 
			WHERE UserID = @UserID;

			SELECT * 
			FROM PAW_USER
			WHERE UserID = @UserID;
		END
        
    END
END
GO
/****** Object:  StoredProcedure [dbo].[AddAssesment]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[AddAssesment](
	@StartDate DATE,
	@EndDate DATE, 
	@MinimumGrade DECIMAL,
	@CourseID INT
)AS


BEGIN 
	INSERT INTO PAW_Assesment(StartDate, EndDate, MinimumGrade, CourseID, Estado) VALUES
	(@StartDate, @EndDate, @MinimumGrade, @CourseID, 1)

END

GO
/****** Object:  StoredProcedure [dbo].[BecomeProfessor]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[BecomeProfessor]
(
    @UserID INT,
	@PictureUrl VARCHAR(1000)
)
AS
BEGIN
    -- Verifica si el UserID existe en la tabla
    IF EXISTS (
        SELECT 1
        FROM PAW_USER
        WHERE UserID = @UserID
    )
    BEGIN
        -- Si el UserID existe, actualiza para indicar "en espera de ser aprobado"
        UPDATE PAW_USER 
        SET IsTeacher = 2, PictureUrl = @PictureUrl -- El valor que indicaste
        WHERE UserID = @UserID;

        -- Seleccionar el objeto actualizado
        SELECT * -- O solo las columnas necesarias
        FROM PAW_USER
        WHERE UserID = @UserID;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[BecomeStudent]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[BecomeStudent]
    @UserID INT
AS
BEGIN
    -- Verifica si el UserID existe en la tabla
    IF EXISTS (
        SELECT 1
        FROM PAW_USER
        WHERE UserID = @UserID
    )
    BEGIN
        -- Si el UserID existe, actualiza para indicar "rol estudiante"
        UPDATE PAW_USER 
        SET IsTeacher = 0, RoleID = 2 -- El valor que indicaste
        WHERE UserID = @UserID;

        -- Seleccionar el objeto actualizado
        SELECT * -- O solo las columnas necesarias
        FROM PAW_USER
        WHERE UserID = @UserID;
    END
END
GO
/****** Object:  StoredProcedure [dbo].[ChangePassword]    Script Date: 4/27/2024 6:49:09 AM ******/
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
/****** Object:  StoredProcedure [dbo].[CountCourses]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CountCourses]
AS
BEGIN
	SELECT COUNT(*) AS "Cursos" FROM Paw_Course WHERE Estado = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[CountProfessors]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CountProfessors]
AS 
BEGIN
	SELECT COUNT(*) AS "Profesores" FROM Paw_User WHERE RoleID = 2;
END
GO
/****** Object:  StoredProcedure [dbo].[CountStudents]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CountStudents]
AS
BEGIN
	SELECT COUNT(*) AS "Estudiates" FROM Paw_User WHERE RoleID = 1;
END
GO
/****** Object:  StoredProcedure [dbo].[CourseUser]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
--Todos los cursos asociados a un usuario
CREATE   PROCEDURE [dbo].[CourseUser]
	@UserID int
AS
BEGIN

	SELECT 
	A.CourseID, CourseTitle, CourseDescription, A.Estado, A.StartDate, A.EndDate,
	B.CourseID
	FROM Paw_Course A
	INNER JOIN PAW_User_Course B
	ON A.CourseID = B.CourseID
	INNER JOIN PAW_USER C
	ON B.UserID = @UserID

END
GO
/****** Object:  StoredProcedure [dbo].[CreateQuestion]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[CreateQuestion](
	@AssesmentID  INT,
	@QuestionDesc VARCHAR(500),
	@Correct VARCHAR (500)
)AS 
BEGIN 
IF EXISTS (
    SELECT 1
    FROM PAW_Assesment
    WHERE AssesmentID = @AssesmentID
)
BEGIN
    -- Si existe, insertar en PAW_Question
    INSERT INTO PAW_Question(AssesmentID, QuestionDesc, Correct, Estado)
    VALUES (@AssesmentID, @QuestionDesc, @Correct, 1);
END
END 
GO
/****** Object:  StoredProcedure [dbo].[DeleteAssesment]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteAssesment](
	@ID int
)
AS
BEGIN
	UPDATE PAW_Assesment
	SET Estado = 0
	WHERE AssesmentID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteCourse]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[DeleteCourse]
	@CourseID int
AS
BEGIN

	UPDATE Paw_Course
	   SET Estado = 0	   
	 WHERE CourseID = @CourseID
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteLesson]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[DeleteLesson]
	@LessonID int
AS
BEGIN

	UPDATE PAW_Lesson
	   SET Estado = 0	   
	 WHERE LessonID = @LessonID

END
GO
/****** Object:  StoredProcedure [dbo].[DeleteQuestion]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[DeleteQuestion](
	@QuestionID INT
)AS 
BEGIN 
	UPDATE PAW_Question
	SET Estado = 0
	WHERE QuestionID = @QuestionID;
END
GO
/****** Object:  StoredProcedure [dbo].[DeleteSuscription]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[DeleteSuscription](
	@ID int
)
AS
BEGIN
	UPDATE Paw_Subscription
	SET Estado = 0
	WHERE SubscriptionID = @ID
END
GO
/****** Object:  StoredProcedure [dbo].[EnrollUser]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[EnrollUser] ---validar si ya el usuario existe en este curso
    @UserID INT, 
    @CourseID INT
AS 
BEGIN 
    IF NOT EXISTS (
        SELECT 1 
        FROM [dbo].PAW_User_Course 
        WHERE UserID = @UserID AND CourseID = @CourseID
    )
    BEGIN 
        INSERT INTO PAW_USER_COURSE (Estado, UserID, CourseID) 
        VALUES (1, @UserID, @CourseID);
    END
END
GO
/****** Object:  StoredProcedure [dbo].[LastInsert]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[LastInsert](
	@CourseID INT
)
AS 
BEGIN
	SELECT TOP 1 *
	FROM PAW_Lesson
	WHERE CourseID = @CourseID
	ORDER BY LessonID DESC;
END
GO
/****** Object:  StoredProcedure [dbo].[LessonsPerCourse]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LessonsPerCourse](
	@CourseID int
) AS

BEGIN

	SELECT * FROM PAW_Lesson 
	WHERE CourseID = @CourseID;

END
GO
/****** Object:  StoredProcedure [dbo].[ListCourses]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[ListCourses]

AS
BEGIN

	SELECT * 
	FROM Paw_Course;
END
GO
/****** Object:  StoredProcedure [dbo].[ListMyCourses]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListMyCourses]
	@UserId INT
AS
BEGIN
	SELECT * FROM Paw_Course
	WHERE UserId = @UserId
END
GO
/****** Object:  StoredProcedure [dbo].[ListMySuscriptionCourses]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListMySuscriptionCourses]
	@UserId INT
AS
BEGIN
	SELECT *
	FROM Paw_Course c
	INNER JOIN PAW_User_Course uc ON uc.CourseID = c.CourseID
	WHERE uc.UserID = @UserId AND uc.Estado = 1
END
GO
/****** Object:  StoredProcedure [dbo].[ListProfessor]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[ListProfessor]
AS
BEGIN
	SELECT * 
	FROM Paw_User 
	WHERE IsTeacher = 3;
END
GO
/****** Object:  StoredProcedure [dbo].[ListSuscriptions]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[ListSuscriptions] 
AS
BEGIN
	SELECT * FROM Paw_Subscription WHERE Estado = 1
END
GO
/****** Object:  StoredProcedure [dbo].[Login]    Script Date: 4/27/2024 6:49:09 AM ******/
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
/****** Object:  StoredProcedure [dbo].[PopularCourses]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PopularCourses]
AS
BEGIN
	SELECT TOP 3
    C.CourseID,
    C.CourseTitle,
    C.CourseDescription,
    C.PictureUrl,
	C.UserId,
    COUNT(UC.UserCourseID) AS Subscripciones
	FROM
		Paw_Course C
	JOIN
		PAW_User_Course UC ON C.CourseID = UC.CourseID
	WHERE
		C.Estado = 1 
	GROUP BY
		C.CourseID,
		C.CourseTitle,
		C.CourseDescription,
		C.PictureUrl,
		C.UserId
	ORDER BY
		Subscripciones DESC
END
GO
/****** Object:  StoredProcedure [dbo].[PopularProfessors]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[PopularProfessors]
AS
BEGIN
	SELECT TOP 3
		U.UserID,
		U.FirstNameUser,
		U.LastNameUser,
		U.PictureUrl,
		COUNT(UC.UserCourseID) AS Subscripciones
	FROM
		Paw_User U
	JOIN
		Paw_Course C ON U.UserID = C.UserId
	JOIN
		PAW_User_Course UC ON C.CourseID = UC.CourseID
	WHERE
		U.RoleID = 2 -- Filtrar por el rol de profesor
		AND C.Estado = 1 -- Asegurarse de que el curso esté activo
	GROUP BY
		U.UserID,
		U.FirstNameUser,
		U.LastNameUser,
		U.PictureUrl
	ORDER BY
		Subscripciones DESC
END
GO
/****** Object:  StoredProcedure [dbo].[RecoverAccess]    Script Date: 4/27/2024 6:49:09 AM ******/
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
/****** Object:  StoredProcedure [dbo].[RegisterCourse]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[RegisterCourse]
	@UserId INT,
	@CourseTitle VARCHAR(100),
	@CourseDescription VARCHAR(250),
	@StartDate DATE,
	@EndDate Date,
	@PictureUrl VARCHAR(1000)
AS
BEGIN
	IF NOT EXISTS(SELECT 1 FROM [dbo].Paw_Course WHERE CourseTitle = UPPER(@CourseTitle))
	BEGIN
		INSERT INTO Paw_Course(CourseTitle, CourseDescription, Estado, StartDate, EndDate, PictureUrl, UserId) VALUES
		(@CourseTitle, @CourseDescription, 1, @StartDate, @EndDate, @PictureUrl, @UserId);
	END
END
GO
/****** Object:  StoredProcedure [dbo].[RegisterLesson]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[RegisterLesson](
	@LessonTitle VARCHAR(100),
	@LessonDescription VARCHAR(250),
	@CourseID int
) AS
BEGIN
	IF NOT EXISTS(SELECT 1 FROM [dbo].PAW_Lesson WHERE LessonTitle = UPPER(@LessonTitle))
	BEGIN
		INSERT INTO PAW_Lesson(LessonTitle, LessonDescription, Estado, CourseID) VALUES
		(@LessonTitle, @LessonDescription, 1, @CourseID);
	END
END
GO
/****** Object:  StoredProcedure [dbo].[RegisterSuscription]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegisterSuscription](
	@Type VARCHAR(25),
	@Price DECIMAL(6,2)
) AS
BEGIN
	IF NOT EXISTS(SELECT 1 FROM [dbo].Paw_Subscription WHERE SubscriptionType = UPPER(@TYPE))
	BEGIN
		INSERT INTO Paw_Subscription (SubscriptionType, SubscriptionPrice, Estado) VALUES
		(@TYPE, @PRICE, 1);
	END
END
GO
/****** Object:  StoredProcedure [dbo].[RegisterUser]    Script Date: 4/27/2024 6:49:09 AM ******/
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
/****** Object:  StoredProcedure [dbo].[SearchSuscription]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SearchSuscription](
	@ID int
)  AS

BEGIN
	SELECT * FROM Paw_Subscription WHERE SubscriptionID =  @ID
END
GO
/****** Object:  StoredProcedure [dbo].[SearchUser]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SearchUser]
	@UserId INT
AS
BEGIN
	SELECT * 
	FROM Paw_User U
	INNER JOIN Paw_Role r ON r.RoleID = u.RoleID 
	WHERE UserId = @UserId
END
GO
/****** Object:  StoredProcedure [dbo].[SeeAssesments]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SeeAssesments]
    @CourseID int
AS
BEGIN
    SELECT * 
    FROM PAW_Assesment 
    WHERE Estado = 1 AND CourseID = @CourseID;
END
GO
/****** Object:  StoredProcedure [dbo].[SeeContentLesson]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE     PROCEDURE [dbo].[SeeContentLesson](
	@LessonID INT
)
AS
BEGIN 
	SELECT B.LessonID, B.LessonTitle, B.LessonDescription, C.VideoUrl, C.MiniPictureUrl
	FROM PAW_Lesson B
	INNER JOIN PAW_Video C 
	ON B.LessonID = C.LessonID
	WHERE B.LessonID = @LessonID
END
GO
/****** Object:  StoredProcedure [dbo].[SeeLessonCourse]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SeeLessonCourse](
	@CourseID INT
)
AS
BEGIN 
	SELECT B.LessonID, A.CourseID, B.LessonDescription, C.VideoUrl, C.MiniPictureUrl
	FROM PAW_Course A 
	INNER JOIN PAW_Lesson B
	ON A.CourseID = B.CourseID
	INNER JOIN PAW_Video C 
	ON B.LessonID = C.LessonID
	WHERE A.CourseID = @CourseID
END
GO
/****** Object:  StoredProcedure [dbo].[SeeProfesorCourse]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SeeProfesorCourse](
	@CourseID INT
)
AS
BEGIN 
	SELECT A.UserID, A.CourseID, B.FirstNameUser, B.LastNameUser
	From PAW_User_Course A 
	INNER JOIN  Paw_User B
	ON A.UserID = B.UserID
	INNER JOIN Paw_Course C
	ON A.CourseID = C.CourseID
	WHERE B.IsTeacher = 3 ---IDPROFESOR
	AND A.CourseID = @CourseID
END
GO
/****** Object:  StoredProcedure [dbo].[SeeQuestionsStudent]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SeeQuestionsStudent]
(
	@AssesmentID INT
)AS

BEGIN
	SELECT QuestionID, AssesmentID, QuestionDesc, Estado
	FROM PAW_Question 
	WHERE AssesmentID = @AssesmentID;
END
GO
/****** Object:  StoredProcedure [dbo].[SeeQuestionsTeacher]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[SeeQuestionsTeacher]
(
	@AssesmentID INT
)AS

BEGIN
	SELECT QuestionID, AssesmentID, QuestionDesc, Correct, Estado
	FROM PAW_Question 
	WHERE AssesmentID = @AssesmentID;
END
GO
/****** Object:  StoredProcedure [dbo].[SeeStudentsCourse]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[SeeStudentsCourse](
	@CourseID INT
)
AS
BEGIN 
	SELECT A.UserID, A.CourseID, B.FirstNameUser, B.LastNameUser
	From PAW_User_Course A 
	INNER JOIN  Paw_User B
	ON A.UserID = B.UserID
	INNER JOIN Paw_Course C
	ON A.CourseID = C.CourseID
	WHERE B.IsTeacher = 0 ---IDPROFESOR
	AND A.CourseID = @CourseID
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateCourse]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateCourse]
	@CourseID int,
	@CourseTitle VARCHAR(100),
	@CourseDescription VARCHAR(250),
	@StartDate date,
	@EndDate date, 
	@PictureUrl VARCHAR(1000)

AS
BEGIN

	UPDATE Paw_Course
	   SET CourseTitle = @CourseTitle,		   
		   CourseDescription = @CourseDescription,
		   StartDate = @StartDate,
		   EndDate = @EndDate, 
		   @PictureUrl = @PictureUrl
	 WHERE CourseID = @CourseID

END
GO
/****** Object:  StoredProcedure [dbo].[UpdateLesson]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[UpdateLesson]
	@LessonID int,
	@LessonTitle VARCHAR(100),
	@LessonDescription varchar(1000)
AS
BEGIN

	UPDATE PAW_Lesson
	   SET LessonTitle = @LessonTitle,		   
		   LessonDescription = @LessonDescription
	 WHERE LessonID = @LessonID

END
GO
/****** Object:  StoredProcedure [dbo].[UpdateSuscription]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UpdateSuscription](
	@Id INT,
	@Type VARCHAR(25),
	@Price DECIMAL(6,2),
	@Estado BIT
) AS
BEGIN
	UPDATE Paw_Subscription
	SET 
	SubscriptionType = @Type,
	SubscriptionPrice = @Price,
	Estado = @Estado
	WHERE SubscriptionID = @Id
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[UpdateUser]
	@UserId INT,
	@FirstNameUser	VARCHAR(45),
    @LastNameUser	VARCHAR(45),
    @EmailUser	VARCHAR(45),
	@PasswordUser	VARCHAR(45)
AS
BEGIN
	BEGIN
	    UPDATE PAW_USER
        SET FirstNameUser = @FirstNameUser,
            LastNameUser = @LastNameUser,
            EmailUser = @EmailUser,
            PasswordUser = @PasswordUser
        WHERE UserId = @UserId;
	END
END
GO
/****** Object:  StoredProcedure [dbo].[UploadVideo]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UploadVideo]
	@VideoUrl VARCHAR(500), 
	@MiniPictureUrl VARCHAR(500),
	@LessonID INT
AS
BEGIN
	INSERT INTO dbo.PAW_Video(VideoUrl, MiniPictureUrl, LessonID) 
	VALUES (@VideoUrl, @MiniPictureUrl, @LessonID);

END
GO
/****** Object:  StoredProcedure [dbo].[ViewProfessorApplicants]    Script Date: 4/27/2024 6:49:09 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[ViewProfessorApplicants]
AS
BEGIN
	SELECT UserID, FirstNameUser, LastNameUser , EmailUser, PictureUrl
	FROM Paw_User
	WHERE IsTeacher = 2 AND PictureUrl IS NOT NULL
END
GO
USE [master]
GO
ALTER DATABASE [Proyecto_Educacion] SET  READ_WRITE 
GO
