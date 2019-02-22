CREATE PROCEDURE [dbo].[GetAllFoo]
AS
BEGIN
	SET NOCOUNT ON;
    SELECT [Id], [Name], [StartDate], [EndDate], [Canceled] FROM [dbo].[Foo]
END