USE [TournamentDB]
GO
/****** Object:  StoredProcedure [dbo].[spTournaments_GetAll]    Script Date: 07.08.2021 15:28:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spTournaments_GetAll]
AS
BEGIN

	SET NOCOUNT ON;
	
	SELECT	Tournaments.ID, 
			Tournaments.TournamentName, 
			Tournaments.EntryFee, 
			Tournaments.Active
	FROM	[dbo].[Tournaments]
	WHERE	Active = 1;

END
GO
