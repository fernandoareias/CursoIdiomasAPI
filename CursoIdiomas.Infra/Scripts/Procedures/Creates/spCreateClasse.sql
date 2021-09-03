-- Procedure responsável por criar a Turma no BD
CREATE PROCEDURE spCreateClasse
    @Id UNIQUEIDENTIFIER,
    @CourseId UNIQUEIDENTIFIER,
    @TeacherId UNIQUEIDENTIFIER,
    @InitialDate DATETIME,
    @FinalDate DATETIME
AS
INSERT INTO [Classes]
    (
    [Id],
    [CourseId],
    [TeacherId],
    [InitialDate],
    [FinalDate]
    )
VALUES(
        @Id,
        @CourseId,
        @TeacherId,
        @InitialDate,
        @FinalDate
    )