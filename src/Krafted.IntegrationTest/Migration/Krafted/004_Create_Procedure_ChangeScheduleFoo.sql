CREATE PROCEDURE [dbo].[ChangeScheduleFoo]
	@Id UNIQUEIDENTIFIER,
	@StartDate DATE,
    @EndDate DATE
AS
BEGIN
	SET NOCOUNT ON;
    UPDATE [dbo].[Foo] SET 
		[StartDate] = @StartDate,
		[EndDate] = @EndDate
	WHERE [Id] = @Id
END