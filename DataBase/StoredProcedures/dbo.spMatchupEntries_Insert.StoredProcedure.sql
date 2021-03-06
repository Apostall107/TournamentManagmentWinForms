USE [TournamentDB]
GO
/****** Object:  StoredProcedure [dbo].[spMatchupEntries_Insert]    Script Date: 07.08.2021 15:28:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spMatchupEntries_Insert]
	@MatchupID int,
	@ParentMatchupID int,
	@TeamCompetingID int,
	@ID int = 0 output
AS
BEGIN

	SET NOCOUNT ON;

	INSERT INTO [dbo].[MatchupEntries] (MatchupID, ParentMatchupID, TeamCompetingID)
	VALUES (@MatchupID, @ParentMatchupID, @TeamCompetingID);

	SELECT @ID = SCOPE_IDENTITY();

END
GO
