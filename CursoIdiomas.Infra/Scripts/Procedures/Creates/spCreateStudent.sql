-- Procedure responsável por criar o Aluno no BD
CREATE PROCEDURE spCreateStudent
    @Id UNIQUEIDENTIFIER,
    @FirstName VARCHAR(80),
    @LastName VARCHAR(80),
    @Email VARCHAR(120)
AS
INSERT INTO [Students]
    (
    [Id],
    [FirstName],
    [LastName],
    [Email]
    )
VALUES(
        @Id,
        @FirstName,
        @LastName,
        @Email
    )