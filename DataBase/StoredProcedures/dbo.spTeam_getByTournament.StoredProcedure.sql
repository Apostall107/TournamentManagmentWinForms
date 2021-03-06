USE [TournamentDB]
GO
/****** Object:  StoredProcedure [dbo].[spTeam_getByTournament]    Script Date: 07.08.2021 15:28:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spTeam_getByTournament]
	@TournamentID int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT		[Teams].[ID], 
				[Teams].[TeamName]
	FROM		[dbo].[Teams]
	INNER JOIN	[dbo].[TournamentEntries]
	ON			TournamentEntries.TeamID = Teams.ID
	WHERE		[TournamentEntries].[TournamentID] = @TournamentID;

END
GO
