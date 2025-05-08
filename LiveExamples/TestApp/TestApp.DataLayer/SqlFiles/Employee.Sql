create database TestAPP
go

use TestApp
go

CREATE TABLE Employee (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name VARCHAR(255) NOT NULL,
    Age INT CHECK (Age BETWEEN 18 AND 60),
    Gender INT
);

CREATE PROCEDURE AddEmployee
    @Name VARCHAR(255),
    @Age INT,
    @Gender INT
AS
BEGIN
    SET NOCOUNT ON;


    INSERT INTO Employee (Name, Age, Gender) 
    VALUES (@Name, @Age, @Gender);
END
