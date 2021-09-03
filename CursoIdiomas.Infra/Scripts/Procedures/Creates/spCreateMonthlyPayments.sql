-- Procedure responsável por criar as Mensalidades dos Alunos no BD
CREATE PROCEDURE spCreateMonthlyPayments
    @Id UNIQUEIDENTIFIER,
    @EnrollId UNIQUEIDENTIFIER,
    @DueDate DATETIME,
    @Price MONEY
AS
INSERT INTO [MonthlyPayments]
    (
    [Id],
    [EnrollId],
    [DueDate],
    [Price]
    )
VALUES(
        @Id,
        @EnrollId,
        @DueDate,
        @Price
)