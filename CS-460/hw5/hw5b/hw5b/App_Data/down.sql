IF EXISTS
(
    SELECT *
    FROM sys.tables
)
BEGIN
    DROP TABLE dbo.DMVForms
END