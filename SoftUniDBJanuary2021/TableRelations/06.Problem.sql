CREATE TABLE Majors
(
    MajorID INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(30) NOT NULL
)

CREATE TABLE Students
(
    StudentID INT PRIMARY KEY IDENTITY,
    StudentNumber CHAR(10) NOT NULL,
    StudentName VARCHAR(30) NOT NULL,
    MajorID INT FOREIGN KEY REFERENCES Majors(MajorID)
)

CREATE TABLE Payments
(
    PaymentID INT PRIMARY KEY IDENTITY,
    PaymentDate DATE NOT NULL,
    PaymentAmount DECIMAL(15,2),
    StudentID INT FOREIGN KEY REFERENCES Students(StudentID)
)

CREATE TABLE Subjects
(
    SubjectID INT PRIMARY KEY IDENTITY,
    SubjectName VARCHAR(30) NOT NULL
)

CREATE TABLE Agenda
(
    StudentID INT FOREIGN KEY REFERENCES Students(StudentID),
    SubjectID INT FOREIGN KEY REFERENCES Subjects(SubjectID)

    CONSTRAINT PK_Student_Subject PRIMARY KEY (StudentID,SubjectID)
)