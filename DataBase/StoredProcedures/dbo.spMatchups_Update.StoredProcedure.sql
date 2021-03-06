USE [TournamentDB]
GO
/****** Object:  StoredProcedure [dbo].[spMatchups_Update]    Script Date: 07.08.2021 15:28:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spMatchups_Update]
	@ID int,
	@WinnerID int
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].[Matchups]
	SET WinnerID = @WinnerID
	WHERE ID = @ID;

END
GO
