USE [TournamentDB]
GO
/****** Object:  StoredProcedure [dbo].[spMatchupEntries_Update]    Script Date: 07.08.2021 15:28:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spMatchupEntries_Update]
	@ID int,
	@TeamCompetingID int = null,
	@Score float = null
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE	[dbo].[MatchupEntries]
	SET		TeamCompetingID = @TeamCompetingID,
			Score = @Score 
	WHERE	ID = @ID;

END
GO
