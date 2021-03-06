USE [TournamentDB]
GO
/****** Object:  StoredProcedure [dbo].[spMatchupEntries_GetByMatchup]    Script Date: 07.08.2021 15:28:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[spMatchupEntries_GetByMatchup]
	@MatchupID int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT	[MatchupEntries].[ID], 
			[MatchupEntries].[MatchupID], 
			[MatchupEntries].[ParentMatchupID], 
			[MatchupEntries].[TeamCompetingID], 
			[MatchupEntries].[Score]
	FROM	[dbo].[MatchupEntries]
	WHERE	[MatchupEntries].[MatchupID] = @MatchupID;

END
GO
