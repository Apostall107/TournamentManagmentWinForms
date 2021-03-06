USE [TournamentDB]
GO
/****** Object:  StoredProcedure [dbo].[spMatchups_Insert]    Script Date: 07.08.2021 15:28:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spMatchups_Insert]
	@TournamentID int,
	@MatchupRound int,
	@ID int = 0 output
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Matchups] (TournamentID, MatchupRound)
	VALUES(@TournamentID, @MatchupRound);

	SELECT @ID = SCOPE_IDENTITY();

END
GO
