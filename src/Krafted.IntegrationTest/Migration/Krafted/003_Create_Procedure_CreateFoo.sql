CREATE PROCEDURE [dbo].[CreateFoo]
	@Id UNIQUEIDENTIFIER,
	@Name VARCHAR(50),
	@StartDate DATE,
    @EndDate DATE
AS
BEGIN
	SET NOCOUNT ON;
    INSERT INTO [dbo].[Foo] ([Id], [Name], [StartDate], [EndDate]) 
	VALUES (@Id, @Name, @StartDate, @EndDate)
END