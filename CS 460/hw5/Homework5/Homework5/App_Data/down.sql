IF EXISTS
(
    SELECT *
    FROM sys.tables
    WHERE tables.name = 'forms'
)
BEGIN
    DROP TABLE dbo.forms
END