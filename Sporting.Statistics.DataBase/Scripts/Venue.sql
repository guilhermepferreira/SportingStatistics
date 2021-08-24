USE FOOTEBALLSTATISTICS;
GO

CREATE TABLE [dbo].[Venue](
	[Identificador] [uniqueidentifier] NOT NULL,
	[IdentificadorFornecedor] [int] unique NOT NULL,
	[Nome] [VARCHAR](MAX) NULL,
	[Endereco] [VARCHAR](MAX) NULL,
	[Cidade] [VARCHAR](MAX) NULL,
	[Capacidade] [int] NULL,
	[Surface] [VARCHAR](50) NULL,
	[Imagem] [VARCHAR](MAX) NULL
 CONSTRAINT [PK_Venue] PRIMARY KEY NONCLUSTERED 
(
	[Identificador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Venue] ADD  DEFAULT (newsequentialid()) FOR [Identificador]
GO

CREATE CLUSTERED INDEX IX_VENUE
ON [Venue]([IdentificadorFornecedor],[Identificador]);
GO