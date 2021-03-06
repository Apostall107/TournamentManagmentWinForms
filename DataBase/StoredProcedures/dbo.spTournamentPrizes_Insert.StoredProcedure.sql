USE [TournamentDB]
GO
/****** Object:  StoredProcedure [dbo].[spTournamentPrizes_Insert]    Script Date: 07.08.2021 15:28:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spTournamentPrizes_Insert]
	@TournamentID int,
	@PrizeID int,
	@ID int = 0 output
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [dbo].[TournamentPrizes] (TournamentID, PrizeID)
	VALUES (@TournamentID, @PrizeID);

	SELECT @ID = SCOPE_IDENTITY();
END
GO
