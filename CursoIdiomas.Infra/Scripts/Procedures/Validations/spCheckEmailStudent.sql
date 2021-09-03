-- Verifica se o Email do estudante já está registrado.
CREATE PROCEDURE spCheckStudentEmail
    @Email VARCHAR(60)
AS
SELECT CASE WHEN EXISTS (
        SELECT [Id]
    FROM [Students]
    WHERe [Email] = @Email
    )
    THEN CAST(1 AS BIT)
    ELSE CAST(0 AS BIT) END