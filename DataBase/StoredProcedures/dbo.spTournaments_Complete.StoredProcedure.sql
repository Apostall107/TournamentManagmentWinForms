USE [TournamentDB]
GO
/****** Object:  StoredProcedure [dbo].[spTournaments_Complete]    Script Date: 07.08.2021 15:28:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spTournaments_Complete]
	@ID int
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE [dbo].[Tournaments]
	SET Active = 0
	WHERE ID = @ID;

END
GO
