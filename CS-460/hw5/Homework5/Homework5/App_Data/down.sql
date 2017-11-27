IF EXISTS
(
    SELECT *
    FROM sys.tables
)
BEGIN
    DROP TABLE dbo.forms
END