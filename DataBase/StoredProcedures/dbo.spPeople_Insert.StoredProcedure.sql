USE [TournamentDB]
GO
/****** Object:  StoredProcedure [dbo].[spPeople_Insert]    Script Date: 07.08.2021 15:28:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spPeople_Insert]
	@FirstName nvarchar(100),
	@LastName nvarchar(100),
	@Email nvarchar(100),
	@PhoneNumber nvarchar(20),
	@ID int = 0 output
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [dbo].[People] (FirstName, LastName, Email, PhoneNumber)
	VALUES (@FirstName, @LastName, @Email, @PhoneNumber);

	SELECT @ID = SCOPE_IDENTITY();
END
GO
