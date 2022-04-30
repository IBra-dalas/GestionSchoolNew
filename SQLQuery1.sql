CREATE TABLE [dbo].[Tranches] (
    [IdTranche]                    INT            IDENTITY (1, 1) NOT NULL,
    [LibelleTranche]               NVARCHAR (MAX) NOT NULL,
    [DatePayement]                 DATETIME       NOT NULL DEFAULT 0001-01-01,
    CONSTRAINT [PK_dbo.Tranches] PRIMARY KEY CLUSTERED ([IdTranche] ASC)
);



