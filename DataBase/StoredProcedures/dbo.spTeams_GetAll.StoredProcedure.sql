USE [TournamentDB]
GO
/****** Object:  StoredProcedure [dbo].[spTeams_GetAll]    Script Date: 07.08.2021 15:28:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

  CREATE PROCEDURE [dbo].[spTeams_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT	[Teams].[ID], 
			[Teams].[TeamName]
	FROM	[dbo].[Teams];

END
GO
