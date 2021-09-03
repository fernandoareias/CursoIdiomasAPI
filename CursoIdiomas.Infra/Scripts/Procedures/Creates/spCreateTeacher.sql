-- Procedure responsavel por registrar o professor
CREATE PROCEDURE spCreateTeacher
    @Id UNIQUEIDENTIFIER,
    @Name VARCHAR(80),
    @Email VARCHAR(120)
AS
INSERT INTO [Teachers]
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