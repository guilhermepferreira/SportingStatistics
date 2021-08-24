USE FOOTEBALLSTATISTICS;
GO

CREATE TABLE [dbo].[Teams](
	[Identificador] [uniqueidentifier] NOT NULL,
	[IdentificadorPais] [uniqueidentifier] NOT NULL,
	[IdentificadorVenue] [uniqueidentifier] NULL,
	[IdentificadorFornecedor] [int] unique NOT NULL,
	[Nome] [VARCHAR](MAX) NOT NULL,
	[Ano] [int] NULL,
	[Nacional] [bit] NOT NULL DEFAULT 0,
	[Logo] [VARCHAR](MAX) NULL
 CONSTRAINT [PK_Teams] PRIMARY KEY NONCLUSTERED 
(
	[Identificador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Teams] ADD  DEFAULT (newsequentialid()) FOR [Identificador]
GO

CREATE CLUSTERED INDEX IX_TEAM
ON [Teams]([IdentificadorFornecedor],[Identificador],[IdentificadorPais]);
GO

ALTER TABLE Teams  WITH CHECK ADD FOREIGN KEY([IdentificadorPais])
REFERENCES [Country] ([Identificador])
GO

ALTER TABLE Teams  WITH CHECK ADD FOREIGN KEY([IdentificadorVenue])
REFERENCES [Venue] ([Identificador])
GO