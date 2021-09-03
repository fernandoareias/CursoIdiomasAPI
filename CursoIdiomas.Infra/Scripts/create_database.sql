
-- Cria o Banco de Dados
CREATE DATABASE [CursoIdiomas]

-- Seta o Banco para efetuar as querys
USE [CursoIdiomas]

-- Cria tabela Course

CREATE TABLE [Courses]
(
    [Id] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
    [Name] VARCHAR(80) NOT NULL,
    [Level] TINYINT NOT NULL,
    [Workload] INT NOT NULL
);
GO

-- Cria tabela Professores

CREATE TABLE [Teachers]
(
    [Id] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL ,
    [FirstName] VARCHAR(80) NOT NULL,
    [LastName] VARCHAR(80) NOT NULL,
    [Email] VARCHAR(120) NOT NULL
);
GO

-- Cria Tabela das Turmas

CREATE TABLE [Classes]
(
    [Id] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
    [CourseId] UNIQUEIDENTIFIER NOT NULL,
    [TeacherId] UNIQUEIDENTIFIER NOT NULL,
    [InitialDate] DATETIME NOT NULL,
    [FinalDate] DATETIME NOT NULL,

    CONSTRAINT [FK_Classes_Course_Id] FOREIGN KEY ([CourseId]) REFERENCES [Courses]([Id]),
    CONSTRAINT [FK_Classes_Teacher_Id] FOREIGN KEY ([TeacherId]) REFERENCES [Teachers]([Id])
);
GO


-- Cria tabela Alunos

CREATE TABLE [Students]
(
    [Id] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
    [FirstName] VARCHAR(80) NOT NULL,
    [LastName] VARCHAR(80) NOT NULL,
    [Email] VARCHAR(120) NOT NULL
);
GO


-- Cria tabela Matricula

CREATE TABLE [Enrolls]
(
    [Id] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
    [ClassesId] UNIQUEIDENTIFIER NOT NULL,
    [StudentsId] UNIQUEIDENTIFIER NOT NULL,
    [Status] TINYINT NOT NULL DEFAULT(1)

        CONSTRAINT [FK_Enroll_Classes_Id] FOREIGN KEY ([ClassesId]) REFERENCES [Classes]([Id]),
    CONSTRAINT [FK_Enroll_Students_Id] FOREIGN KEY ([StudentsId]) REFERENCES [Students]([Id])
);
GO

-- Cria tabela dos Boletins

CREATE TABLE [ReportCards]
(
    [Id] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
    [EnrollId] UNIQUEIDENTIFIER NOT NULL,
    [CreateDate] DATETIME NOT NULL DEFAULT(GETDATE()),
    [LastUpdateDate] DATETIME NOT NULL,
    [Note] FLOAT NOT NULL,
    CONSTRAINT [FK_ReportCard_Enroll_Id] FOREIGN KEY ([EnrollId]) REFERENCES [Enrolls]([Id])
);
GO

-- Cria tabela das mensalidades

CREATE TABLE [MonthlyPayments]
(
    [Id] UNIQUEIDENTIFIER PRIMARY KEY NOT NULL,
    [EnrollId] UNIQUEIDENTIFIER NOT NULL,
    [DueDate] DATETIME NOT NULL,
    [Price] MONEY NOT NULL
        CONSTRAINT [FK_MonthlyPayment_Enroll_Id] FOREIGN KEY ([EnrollId]) REFERENCES [Enrolls]([Id])
);
GO