USE [TournamentDB]
GO
/****** Object:  StoredProcedure [dbo].[spTournamentEntries_Insert]    Script Date: 07.08.2021 15:28:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spTournamentEntries_Insert]
	@TournamentID int,
	@TeamID int,
	@ID int = 0 output
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [dbo].[TournamentEntries] (TournamentID, TeamID)
	VALUES (@TournamentID, @TeamID)

	SELECT @ID = SCOPE_IDENTITY();

END
GO
