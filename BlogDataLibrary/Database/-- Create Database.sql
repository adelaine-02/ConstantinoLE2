-- Create Database
CREATE DATABASE BlogDB;
GO

USE BlogDB;
GO

-- Create Users Table 
CREATE TABLE dbo.Users (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    UserName NVARCHAR(16) NOT NULL,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Password NVARCHAR(16) NOT NULL
);
GO

-- Create Posts Table 
CREATE TABLE dbo.Posts (
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    UserId INT NOT NULL,
    Title NVARCHAR(150) NOT NULL,
    Body TEXT NOT NULL,
    DateCreated DATETIME2 NOT NULL,
    CONSTRAINT FK_Posts_Users FOREIGN KEY (UserId) REFERENCES dbo.Users(Id)
);
GO