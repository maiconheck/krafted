CREATE DATABASE KeepMoneyTest ON (Name='KeepMoneyTest', filename='C:\KeepMoney\KeepMoneyTest.mdf')
GO

USE KeepMoneyTest
GO

IF NOT EXISTS (SELECT * FROM sys.tables WHERE object_id = OBJECT_ID(N'[Foo]'))
BEGIN
	CREATE TABLE [dbo].[Foo](
		[Id] [uniqueidentifier] NOT NULL,
		[Name] [varchar](100) NOT NULL,
		[StartDate] [date] NOT NULL,
		[EndDate] [date] NOT NULL,
		[Canceled] BIT NOT NULL DEFAULT ((0))
	 CONSTRAINT [PK_Id] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
	) ON [PRIMARY]
END

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[DeleteFoo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[DeleteFoo]
END
GO

CREATE PROCEDURE [dbo].[DeleteFoo]
	@Id UNIQUEIDENTIFIER
AS
BEGIN
	SET NOCOUNT ON;
    DELETE [dbo].[Foo] WHERE Id = @Id
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE  id = object_id(N'[dbo].[CreateFoo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[CreateFoo]
END
GO

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
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[ChangeScheduleFoo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[ChangeScheduleFoo]
END
GO

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
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[GetAllFoo]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[GetAllFoo]
END
GO

CREATE PROCEDURE [dbo].[GetAllFoo]
AS
BEGIN
	SET NOCOUNT ON;
    SELECT [Id], [Name], [StartDate], [EndDate], [Canceled] FROM [dbo].[Foo]
END
GO

IF EXISTS (SELECT * FROM sysobjects WHERE id = object_id(N'[dbo].[GetFooById]') and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [dbo].[GetFooById]
END
GO

CREATE PROCEDURE [dbo].[GetFooById]
	@Id UNIQUEIDENTIFIER	
AS
BEGIN
	SET NOCOUNT ON;
    SELECT [Id], [Name], [StartDate], [EndDate], [Canceled] FROM [dbo].[Foo] WHERE [Id] = @Id
END
GO