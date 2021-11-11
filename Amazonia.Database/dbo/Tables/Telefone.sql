CREATE TABLE [dbo].[Telefone] (
    [Id]             INT          IDENTITY (1, 1) NOT NULL,
    [NumeroTelefone] VARCHAR (20) NULL,
    [AlunoId]        INT          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([AlunoId]) REFERENCES [dbo].[Aluno] ([Id])
);

