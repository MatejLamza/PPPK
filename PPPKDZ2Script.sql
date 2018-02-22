CREATE DATABASE PPPKDZ2MatejLamza
GO
USE 
PPPKDZ2MatejLamza
GO


CREATE TABLE Student(
IDStudent	int identity primary key,
Ime			nvarchar(50),
Prezime		nvarchar(50),
JMBAG		nvarchar(50),
Email		nvarchar(100)
)
GO

INSERT INTO Student VALUES ('Milica','Milic','1231231','milica@gmail.com')
INSERT INTO Student VALUES ('Dalibor','Horvat','1321321','dalibor@gmail.com')
INSERT INTO Student VALUES ('Pero','Peric','3332221','pero@mail.com')
INSERT INTO Student VALUES ('Ivan','Ivic','7239923','ivan@gmail.com')
INSERT INTO Student VALUES ('Ana','Anic','993231','ana@gmail.com')
GO

CREATE PROC GetAllStudents
AS
SELECT * FROM Student
GO

CREATE PROC InsertStudent
@Ime		nvarchar(50),
@Prezime	nvarchar(50),
@JMBAG		nvarchar(50),
@Email		nvarchar(100)
AS
	IF NOT EXISTS(SELECT * FROM Student WHERE JMBAG=@JMBAG AND Email=@Email)
	BEGIN
		INSERT INTO Student VALUES(@Ime,@Prezime,@JMBAG,@Email)
	END
GO

CREATE PROC UpdateStudent
@IDStudent		int,
@Ime			nvarchar(50),
@Prezime		nvarchar(50),
@JMBAG			nvarchar(50),
@Email			nvarchar(100)
AS
	UPDATE Student SET Ime=@Ime, Prezime=@Prezime, JMBAG=@JMBAG, Email=@Email WHERE IDStudent=@IDStudent
GO

CREATE PROC DeleteStudent
@IDstudent int
AS
	DELETE FROM Student WHERE IDStudent=@IDstudent
GO

CREATE PROC SelectStudent
@IDStudent int
AS
	SELECT * FROM Student WHERE IDStudent=@IDStudent
GO











