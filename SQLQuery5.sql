CREATE TABLE [dbo].[Absences] (
    [IdAbsence]          INT            IDENTITY (1, 1) NOT NULL,
    [MotifAbsence]       NVARCHAR (MAX) NULL,
    [DateAbsence]        DATETIME2 (7)  NOT NULL,
    [_Eleve_IdEleve]     INT            NULL,
    [_Inclure_IdInclure] INT            NULL,
    [_Matiere_IdMatiere] INT            NULL,
    CONSTRAINT [PK_dbo.Absences] PRIMARY KEY CLUSTERED ([IdAbsence] ASC),
    CONSTRAINT [FK_dbo.Absences_dbo.Eleves__Eleve_IdEleve] FOREIGN KEY ([_Eleve_IdEleve]) REFERENCES [dbo].[Eleves] ([IdEleve]),
    CONSTRAINT [FK_dbo.Absences_dbo.Inclures__Inclure_IdInclure] FOREIGN KEY ([_Inclure_IdInclure]) REFERENCES [dbo].[Inclures] ([IdInclure]),
    CONSTRAINT [FK_dbo.Absences_dbo.Matieres__Matiere_IdMatiere] FOREIGN KEY ([_Matiere_IdMatiere]) REFERENCES [dbo].[Matieres] ([IdMatiere])
);


GO
CREATE NONCLUSTERED INDEX [IX__Eleve_IdEleve]
    ON [dbo].[Absences]([_Eleve_IdEleve] ASC);


GO
CREATE NONCLUSTERED INDEX [IX__Inclure_IdInclure]
    ON [dbo].[Absences]([_Inclure_IdInclure] ASC);


GO
CREATE NONCLUSTERED INDEX [IX__Matiere_IdMatiere]
    ON [dbo].[Absences]([_Matiere_IdMatiere] ASC);

