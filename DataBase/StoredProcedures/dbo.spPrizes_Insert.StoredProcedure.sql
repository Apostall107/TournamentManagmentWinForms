USE [TournamentDB]
GO
/****** Object:  StoredProcedure [dbo].[spPrizes_Insert]    Script Date: 07.08.2021 15:28:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 
CREATE PROCEDURE [dbo].[spPrizes_Insert]
	@PlaceNumber int, 
	@PlaceName nvarchar(50), 
	@PrizeAmount money, 
	@PrizePercentage float,
	@ID int = 0 output
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO [dbo].[Prizes] (PlaceNumber, PlaceName, PrizeAmount, PrizePercentage)
	VALUES (@PlaceNumber, @PlaceName, @PrizeAmount, @PrizePercentage);

	SELECT @ID = SCOPE_IDENTITY();

END
GO
