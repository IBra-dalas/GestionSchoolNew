CREATE TABLE [dbo].[Inscriptions](
[IdInscription]                  INT      IDENTITY (1, 1) NOT NULL,
    [EtatEleve]                      BIT      NOT NULL,
    [DateInscription]                DATETIME DEFAULT (((1)-(1))-(1)) NOT NULL,
    [_AnneeScolaire_IdAnneeScolaire] INT      NOT NULL,
    [_Classe_IdClasse]               INT      NOT NULL,
    [_Eleve_IdEleve]                 INT      NOT NULL,
    [_Tranche_IdTranche]             INT      NOT NULL,
    [_ModePayement_IdModePayement]   INT      NOT NULL,
    CONSTRAINT [PK_dbo.Inscriptions] PRIMARY KEY CLUSTERED ([IdInscription] ASC),
    CONSTRAINT [FK_dbo.Inscriptions_dbo.AnneeScolaires__AnneeScolaire_IdAnneeScolaire] FOREIGN KEY ([_AnneeScolaire_IdAnneeScolaire]) REFERENCES [dbo].[AnneeScolaires] ([IdAnneeScolaire]),
    CONSTRAINT [FK_dbo.Inscriptions_dbo.Classes__Classe_IdClasse] FOREIGN KEY ([_Classe_IdClasse]) REFERENCES [dbo].[Classes] ([IdClasse]),
    CONSTRAINT [FK_dbo.Inscriptions_dbo.Eleves__Eleve_IdEleve] FOREIGN KEY ([_Eleve_IdEleve]) REFERENCES [dbo].[Eleves] ([IdEleve]),
    CONSTRAINT [FK_dbo.Inscriptions_dbo.Tranches__Tranche_IdTranche] FOREIGN KEY ([_Tranche_IdTranche]) REFERENCES [dbo].[Tranches] ([IdTranche]),
    CONSTRAINT [FK_dbo.Inscriptions_dbo.ModePayements__ModePayement_IdModePayement] FOREIGN KEY ([_ModePayement_IdModePayement]) REFERENCES [dbo].[ModePayements] ([IdModePayement])
);


GO
CREATE NONCLUSTERED INDEX [IX__AnneeScolaire_IdAnneeScolaire]
    ON [dbo].[Inscriptions]([_AnneeScolaire_IdAnneeScolaire] ASC);


GO
CREATE NONCLUSTERED INDEX [IX__Classe_IdClasse]
    ON [dbo].[Inscriptions]([_Classe_IdClasse] ASC);


GO
CREATE NONCLUSTERED INDEX [IX__Eleve_IdEleve]
    ON [dbo].[Inscriptions]([_Eleve_IdEleve] ASC);


GO
CREATE NONCLUSTERED INDEX [IX__ModePayement_IdModePayement]
    ON [dbo].[Inscriptions]([_ModePayement_IdModePayement] ASC);


GO
CREATE NONCLUSTERED INDEX [IX__Tranche_IdTranche]
    ON [dbo].[Inscriptions]([_Tranche_IdTranche] ASC);

