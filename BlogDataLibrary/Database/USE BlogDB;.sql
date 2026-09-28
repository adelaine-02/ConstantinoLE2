USE BlogDB;
GO

-- 1. Authenticate User
CREATE PROCEDURE dbo.spUsers_Authenticate
    @username NVARCHAR(16),
    @password NVARCHAR(16)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT [Id], [UserName], [FirstName], [LastName], [Password]
    FROM dbo.Users
    WHERE UserName = @username AND Password = @password;
END;
GO

-- 2. Register User
CREATE PROCEDURE dbo.spUsers_Register
    @username NVARCHAR(16),
    @firstName NVARCHAR(50),
    @lastName NVARCHAR(50),
    @password NVARCHAR(16)
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.Users (UserName, FirstName, LastName, Password)
    VALUES (@username, @firstName, @lastName, @password);
END;
GO

-- 3. List Posts
CREATE PROCEDURE dbo.spPosts_List
AS
BEGIN
    SET NOCOUNT ON;
    SELECT p.[Id], p.[Title], p.[Body], p.[DateCreated], u.[UserName], u.[FirstName], u.[LastName]
    FROM dbo.Posts p
    INNER JOIN dbo.Users u ON p.UserId = u.Id;
END;
GO

-- 4. Insert Post
CREATE PROCEDURE dbo.spPosts_Insert
    @userId INT,
    @title NVARCHAR(150),
    @body TEXT,
    @dateCreated DATETIME2
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO dbo.Posts (UserId, Title, Body, DateCreated)
    VALUES (@userId, @title, @body, @dateCreated);
END;
GO