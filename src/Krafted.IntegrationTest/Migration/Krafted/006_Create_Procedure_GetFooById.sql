CREATE PROCEDURE [dbo].[GetFooById]
	@Id UNIQUEIDENTIFIER	
AS
BEGIN
	SET NOCOUNT ON;
    SELECT [Id], [Name], [StartDate], [EndDate], [Canceled] FROM [dbo].[Foo] WHERE [Id] = @Id
END