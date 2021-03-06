USE [TournamentDB]
GO
/****** Object:  StoredProcedure [dbo].[spTeamMembers_GetByTeam]    Script Date: 07.08.2021 15:28:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[spTeamMembers_GetByTeam]
	@TeamID int
AS
BEGIN
	SET NOCOUNT ON;

	SELECT		[People].[ID], 
				[People].[FirstName], 
				[People].[LastName], 
				[People].[Email], 
				[People].[PhoneNumber]
	FROM		[dbo].[TeamMembers]
	INNER JOIN	[dbo].[People]
	ON			[People].[ID] = [TeamMembers].[PersonID]
	WHERE		[TeamMembers].[TeamID] = @TeamID;

END
GO
