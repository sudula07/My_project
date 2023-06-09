USE [student]
GO
/****** Object:  StoredProcedure [dbo].[USP_STUDENT_REGISTRATION]    Script Date: 29-05-2023 10:36:36 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Mohana
-- Create date: 21-05-2023
-- Description:	Save student Info
-- =============================================
ALTER PROCEDURE [dbo].[USP_STUDENT_REGISTRATION]
(
	@FNAME VARCHAR(50) = null,
	@LNAME VARCHAR(50)=null,
	@DOB DATE =null,
	@FATHERNAME VARCHAR(50)=null,
	@MOTHERNAME VARCHAR(50)=null,
	@BRANCH VARCHAR(10)=null,
	@GENDER CHAR(1)=null,
	@EMAIL VARCHAR(100)=null,
	@PHNO VARCHAR(10)=null,
	@HOBBIES VARCHAR(100)=null,
	@MODE VARCHAR(10),
	@STUDENTID INT = null
	

)
AS
	BEGIN
		IF(@MODE = 'INSERT')
			BEGIN
				INSERT INTO [dbo].[std_info] ( fname,lname, dob , father_name , mother_name,branch,gender,email,phno,hobbies,createddate)
				VALUES
				(
				  @FNAME,@LNAME,@DOB,@FATHERNAME,@MOTHERNAME,@BRANCH,@GENDER,@EMAIL,@PHNO,@HOBBIES,GETDATE()
				)
			END
		IF(@MODE ='UPDATE')
			BEGIN
			  UPDATE [dbo].[std_info] SET fname = @FNAME,lname = @LNAME,dob = @DOB, father_name = @FATHERNAME ,  mother_name = @MOTHERNAME , branch = @BRANCH ,
			  gender = @GENDER , email= @EMAIL,phno = @PHNO , hobbies = @HOBBIES
			      WHERE sno = @STUDENTID
			END
		IF (@MODE = 'DELETE')
			BEGIN 
			    UPDATE [dbo].[std_info] SET active = 0 WHERE sno = @STUDENTID;
			END 
		if (@MODE = 'ALL')
		  BEGIN 
		      SELECT * FROM STD_INFO WHERE active = 1;

		    END
		IF (@MODE = 'SINGLE')
		   BEGIN 
		       SELECT * FROM STD_INFO WHERE sno = @STUDENTID;
			END 
	END
