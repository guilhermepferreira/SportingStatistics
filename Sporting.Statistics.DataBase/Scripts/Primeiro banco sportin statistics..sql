USE FOOTEBALLSTATISTICS;
GO

CREATE TABLE Country(
Identificador Uniqueidentifier default newsequentialid() primary key NONCLUSTERED,
Nome varchar(MAX) NOT NULL,
Codigo varchar(MAX) NULL,
Bandeira varchar(MAX) NULL
)
GO

CREATE TABLE Tipo(
Identificador Uniqueidentifier default newsequentialid() primary key CLUSTERED,
Type varchar(MAX) NOT NULL,
);
GO

CREATE TABLE Coverage(
Identificador Uniqueidentifier default newsequentialid() primary key CLUSTERED,
Events bit NOT NULL,
Lineups bit NOT NULL,
StatisticsFixtures bit NOT NULL,
StatisticsPlayers bit NOT NULL,
Standings bit NOT NULL,
Players bit NOT NULL,
TopScorers bit NOT NULL,
TopAssists bit NOT NULL,
TopCards bit NOT NULL,
Injuries bit NOT NULL,
Predictions bit NOT NULL,
Odds bit NOT NULL,
);
GO

CREATE TABLE Leagues(
Identificador Uniqueidentifier default newsequentialid() primary key NONCLUSTERED,
IdLigaFornecedor INT NOT NULL,
Nome VARCHAR(MAX) NOT NULL,
Logo VARCHAR(MAX) NOT NULL,
Season INT NOT NULL,
Inicio DATETIME NOT NULL,
Fim DATETIME NOT NULL,
Atual BIT NOT NULL,
IdentificadorType Uniqueidentifier not null,
IdentificadorPais Uniqueidentifier not null,
IdentificadorCoverage Uniqueidentifier not null,
CONSTRAINT UC_League UNIQUE (IdLigaFornecedor)
);
GO

CREATE CLUSTERED INDEX IX_LIGA
ON [Leagues]([IdLigaFornecedor],[Identificador],[IdentificadorType],[IdentificadorPais]);
GO

ALTER TABLE Leagues  WITH CHECK ADD FOREIGN KEY([IdentificadorType])
REFERENCES [Tipo] ([Identificador])
GO

ALTER TABLE Leagues  WITH CHECK ADD FOREIGN KEY([IdentificadorPais])
REFERENCES [Country] ([Identificador])
GO

ALTER TABLE Leagues  WITH CHECK ADD FOREIGN KEY([IdentificadorCoverage])
REFERENCES [Coverage] ([Identificador])
GO


/****** Object:  Table [dbo].[Seasons]    Script Date: 06/07/2021 20:38:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Seasons](
	[Identificador] [uniqueidentifier] NOT NULL,
	[Ano] [int] NOT NULL,
 CONSTRAINT [PK_Seasons] PRIMARY KEY NONCLUSTERED 
(
	[Identificador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Seasons] ADD  DEFAULT (newsequentialid()) FOR [Identificador]
GO



