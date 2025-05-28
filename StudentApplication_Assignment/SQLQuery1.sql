USE TestAPP;
GO

CREATE TABLE StudentData (
    StudentId INT IDENTITY(1,1) PRIMARY KEY,
    StudentName VARCHAR(200),
    StudentEmail VARCHAR(200),
    StudentAge INT,
    StudentAddress VARCHAR(200),
    AddmissionDate DATETIME,
	DOB DATE,
    Gender VARCHAR(200)
);
GO

CREATE OR ALTER PROCEDURE Proc_Insert_into_StudentData
    @StudentName VARCHAR(200),
    @StudentEmail VARCHAR(200),
    @StudentAge INT,
    @StudentAddress VARCHAR(200),
	@DOB DATE,
    @Gender VARCHAR(200)
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM StudentData WHERE StudentEmail = @StudentEmail)
    BEGIN
        UPDATE StudentData 
        SET StudentName = @StudentName, 
            StudentAge = @StudentAge, 
            StudentAddress = @StudentAddress, 
            AddmissionDate = getdate(),
			DOB  = @DOB,
            Gender = @Gender
        WHERE StudentEmail = @StudentEmail;
    END
    ELSE
    BEGIN
        INSERT INTO StudentData (StudentName, StudentEmail, StudentAge, StudentAddress, AddmissionDate,DOB ,Gender) 
        VALUES (@StudentName, @StudentEmail, @StudentAge, @StudentAddress, GetDAte(),@DOB, @Gender);
    END
END;
GO

EXEC Proc_Insert_into_StudentData 
    @StudentName = 'Nitish Kumar',
    @StudentEmail = 'nitish@example.com',
    @StudentAge = 22,
    @StudentAddress = 'BBSR, Odisha',
	@DOB = '2002-10-13',
    @Gender = 'Male';

	-- Record 1
EXEC Proc_Insert_into_StudentData 
    @StudentName = 'Anjali Mehta',
    @StudentEmail = 'anjali.mehta@example.com',
    @StudentAge = 20,
    @StudentAddress = 'Mumbai, Maharashtra',
    @DOB = '2004-06-15',
    @Gender = 'Female';

-- Record 2
EXEC Proc_Insert_into_StudentData 
    @StudentName = 'Rahul Verma',
    @StudentEmail = 'rahul.verma@example.com',
    @StudentAge = 23,
    @StudentAddress = 'Patna, Bihar',
    @DOB = '2001-03-25',
    @Gender = 'Male';

-- Record 3
EXEC Proc_Insert_into_StudentData 
    @StudentName = 'Sneha Das',
    @StudentEmail = 'sneha.das@example.com',
    @StudentAge = 21,
    @StudentAddress = 'Kolkata, West Bengal',
    @DOB = '2003-08-09',
    @Gender = 'Female';

-- Record 4
EXEC Proc_Insert_into_StudentData 
    @StudentName = 'Vikram Singh',
    @StudentEmail = 'vikram.singh@example.com',
    @StudentAge = 24,
    @StudentAddress = 'Delhi',
    @DOB = '2000-12-01',
    @Gender = 'Male';

	select * FROM StudentData

	go;

CREATE PROCEDURE Proc_Delete_StudentById
    @StudentId INT
AS
BEGIN
    DELETE FROM StudentData WHERE StudentId = @StudentId
END
