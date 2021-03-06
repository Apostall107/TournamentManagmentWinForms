USE [TournamentDB]
GO
/****** Object:  StoredProcedure [dbo].[spTeamMembers_Insert]    Script Date: 07.08.2021 15:28:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spTeamMembers_Insert]
	@TeamID int,
	@PersonID int,
	@ID int = 0 output
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [dbo].[TeamMembers] (TeamID, PersonID)
	VALUES (@TeamID, @PersonID)

	SELECT @ID = SCOPE_IDENTITY();
END
GO
