GO

Use master

GO 

CREATE DATABASE UsersDB

GO

USE UsersDB

GO

CREATE TABLE Users(
ID int IDENTITY(1,1) PRIMARY KEY,
FirstName nvarchar(50) NOT NULL,
LastName nvarchar(50) NOT NULL,
Age int NOT NULL,
Email nvarchar(50) NOT NULL,
[Password] nvarchar(50) NOT NULL

)