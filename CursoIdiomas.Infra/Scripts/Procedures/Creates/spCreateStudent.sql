-- Procedure responsável por criar o Aluno no BD
CREATE PROCEDURE spCreateStudent
    @Id UNIQUEIDENTIFIER,
    @Name VARCHAR(80),
    @Email VARCHAR(120)
AS
INSERT INTO [Students]
    (
    [Id],
    [Name],
    [Email]
    )
VALUES(
        @Id,
        @Name,
        @Email
    )