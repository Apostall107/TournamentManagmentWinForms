USE [TournamentDB]
GO
/****** Object:  StoredProcedure [dbo].[spTeams_Insert]    Script Date: 07.08.2021 15:28:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
CREATE PROCEDURE [dbo].[spTeams_Insert]
	@TeamName nvarchar(100),
	@ID int = 0 output
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Teams] (TeamName)
	VALUES (@TeamName)

	SELECT @ID = SCOPE_IDENTITY();
END
GO
