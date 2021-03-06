USE [TournamentDB]
GO
/****** Object:  StoredProcedure [dbo].[spPrizes_GetByTournament]    Script Date: 07.08.2021 15:28:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spPrizes_GetByTournament]
	@TournamentID int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT		[Prizes].[ID], 
				[Prizes].[PlaceNumber], 
				[Prizes].[PlaceName], 
				[Prizes].[PrizeAmount], 
				[Prizes].[PrizePercentage]
	FROM		[dbo].[Prizes]
	INNER JOIN	[dbo].[TournamentPrizes]
	ON			TournamentPrizes.PrizeID = Prizes.ID
	WHERE		TournamentPrizes.TournamentID = @TournamentID;

END
GO
