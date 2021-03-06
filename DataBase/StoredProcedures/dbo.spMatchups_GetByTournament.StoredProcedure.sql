USE [TournamentDB]
GO
/****** Object:  StoredProcedure [dbo].[spMatchups_GetByTournament]    Script Date: 07.08.2021 15:28:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spMatchups_GetByTournament]
	@TournamentID int
AS
BEGIN 

	SET NOCOUNT ON;

	SELECT		[Matchups].[ID], 
				[Matchups].[TournamentID], 
				[Matchups].[WinnerID], 
				[Matchups].[MatchupRound]
	FROM		[dbo].[Matchups]
	WHERE		Matchups.TournamentID = @TournamentID
	ORDER BY	Matchups.MatchupRound;

END
GO
