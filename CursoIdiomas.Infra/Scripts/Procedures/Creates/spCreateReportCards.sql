-- Procedure responsável por criar as Notas dos Alunos no BD
CREATE PROCEDURE spCreateReportCards
    @Id UNIQUEIDENTIFIER,
    @EnrollId UNIQUEIDENTIFIER,
    @CreateDate DATETIME,
    @LastUpdateDate DATETIME,
    @Note FLOAT
AS
INSERT INTO [ReportCards]
    (
    [Id],
    [EnrollId],
    [CreateDate],
    [LastUpdateDate],
    [Note]
    )
VALUES(
        @Id,
        @EnrollId,
        @CreateDate,
        @LastUpdateDate,
        @Note
)