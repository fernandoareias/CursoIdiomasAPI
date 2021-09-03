-- Procedure responsável por criar o Curso no BD
CREATE PROCEDURE spCreateCourse
    @Id UNIQUEIDENTIFIER,
    @Name VARCHAR(80),
    @Workload INT
AS
INSERT INTO [Courses]
    (
    [Id],
    [Name],
    [Workload]
    )
VALUES(
        @Id,
        @Name,
        @Workload
    )