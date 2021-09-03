-- Verifica se o Email do professor ja está registrado.
CREATE PROCEDURE spCheckTeacherEmail
    @Email VARCHAR(60)
AS
SELECT CASE WHEN EXISTS (
        SELECT [Id]
    FROM [Teachers]
    WHERe [Email] = @Email
    )
    THEN CAST(1 AS BIT)
    ELSE CAST(0 AS BIT) END