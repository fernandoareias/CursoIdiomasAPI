-- Procedure responsável por criar a Matricula no BD
CREATE PROCEDURE spCreateEnrolls
    @Id UNIQUEIDENTIFIER,
    @ClassesId UNIQUEIDENTIFIER,
    @StudentsId UNIQUEIDENTIFIER,
    @Status TINYINT
AS
INSERT INTO [Enrolls]
    (
    [Id],
    [ClassesId],
    [StudentsId],
    [Status]
    )
VALUES(
        @Id,
        @ClassesId,
        @StudentsId,
        @Status

    )
