USE [TournamentDB]
GO
/****** Object:  Table [dbo].[MatchupEntries]    Script Date: 07.08.2021 15:28:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MatchupEntries](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[MatchupID] [int] NOT NULL,
	[ParentMatchupID] [int] NULL,
	[TeamCompetingID] [int] NULL,
	[Score] [decimal](18, 0) NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[MatchupEntries]  WITH CHECK ADD  CONSTRAINT [FK_MatchupEntries_ToMatchups] FOREIGN KEY([MatchupID])
REFERENCES [dbo].[Matchups] ([ID])
GO
ALTER TABLE [dbo].[MatchupEntries] CHECK CONSTRAINT [FK_MatchupEntries_ToMatchups]
GO
ALTER TABLE [dbo].[MatchupEntries]  WITH CHECK ADD  CONSTRAINT [FK_MatchupEntries_ToParentMatchups] FOREIGN KEY([ParentMatchupID])
REFERENCES [dbo].[Matchups] ([ID])
GO
ALTER TABLE [dbo].[MatchupEntries] CHECK CONSTRAINT [FK_MatchupEntries_ToParentMatchups]
GO
ALTER TABLE [dbo].[MatchupEntries]  WITH CHECK ADD  CONSTRAINT [FK_MatchupEntries_ToTeams] FOREIGN KEY([TeamCompetingID])
REFERENCES [dbo].[Teams] ([ID])
GO
ALTER TABLE [dbo].[MatchupEntries] CHECK CONSTRAINT [FK_MatchupEntries_ToTeams]
GO
