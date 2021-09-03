-- Verfica a quantidade de estudantes que uma turma possui
CREATE PROCEDURE spCountStudentsInClasses
    @ClasseId UNIQUEIDENTIFIER
AS
SELECT
    COUNT([Id])
FROM [Enrolls]
WHERe [ClassesId] = @ClasseId

