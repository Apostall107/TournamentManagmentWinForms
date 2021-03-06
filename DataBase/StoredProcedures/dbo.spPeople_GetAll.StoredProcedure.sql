USE [TournamentDB]
GO
/****** Object:  StoredProcedure [dbo].[spPeople_GetAll]    Script Date: 07.08.2021 15:28:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
  
CREATE PROCEDURE [dbo].[spPeople_GetAll]
AS
BEGIN
	SET NOCOUNT ON;

	SELECT	[People].[ID], 
			[People].[FirstName], 
			[People].[LastName], 
			[People].[Email], 
			[People].[PhoneNumber]
	FROM	[dbo].[People];
END
GO
