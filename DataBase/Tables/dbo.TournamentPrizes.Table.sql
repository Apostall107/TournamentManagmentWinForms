USE [TournamentDB]
GO
/****** Object:  Table [dbo].[TournamentPrizes]    Script Date: 07.08.2021 15:28:31 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TournamentPrizes](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TournamentID] [int] NOT NULL,
	[PrizeID] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TournamentPrizes]  WITH CHECK ADD  CONSTRAINT [FK_TournamentPrizes_ToPrizes] FOREIGN KEY([PrizeID])
REFERENCES [dbo].[Prizes] ([ID])
GO
ALTER TABLE [dbo].[TournamentPrizes] CHECK CONSTRAINT [FK_TournamentPrizes_ToPrizes]
GO
ALTER TABLE [dbo].[TournamentPrizes]  WITH CHECK ADD  CONSTRAINT [FK_TournamentPrizes_ToTournaments] FOREIGN KEY([TournamentID])
REFERENCES [dbo].[Tournaments] ([ID])
GO
ALTER TABLE [dbo].[TournamentPrizes] CHECK CONSTRAINT [FK_TournamentPrizes_ToTournaments]
GO
