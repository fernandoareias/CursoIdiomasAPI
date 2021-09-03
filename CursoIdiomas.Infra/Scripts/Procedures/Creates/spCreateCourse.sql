-- Procedure responsável por criar o Curso no BD
CREATE PROCEDURE spCreateCourse
    @Id UNIQUEIDENTIFIER,
    @Name VARCHAR(80),
    @Level TINYINT,
    @Workload INT
AS
INSERT INTO [Courses]
    (
    [Id],
    [Name],
    [Level],
    [Workload]
    )
VALUES(
        @Id,
        @Name,
        @Level,
        @Workload
    )