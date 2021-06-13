CREATE TABLE Employees
(
    Id INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(30) NOT NULL,
    LastName VARCHAR(30) NOT NULL,
    Title VARCHAR(15),
    Notes VARCHAR(MAX)
)

INSERT INTO Employees VALUES
('Ivan','Ivanov','CEO',NULL),
('Boiko','Borisov','DIRECTOR',NULL),
('Ivan','Ivanov','CEO',NULL)

CREATE TABLE Customers
(
    AccountNumbeer INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(30) NOT NULL,
    LastName VARCHAR(30) NOT NULL,
    PhoneNumber VARCHAR(10) NOT NULL,
    EmergencyName VARCHAR(30) NOT NULL,
    EmergencyNumber VARCHAR(10) NOT NULL,
    Notes VARCHAR(MAX)
)

INSERT INTO Customers VALUES
('Ivancho','Ivanchov','1234567890','Spas','0987654321',NULL),
('Boiko','Borisov','1234567891','Spas','0987654321',NULL),
('Pencho','Penchev','1234567892','Spas','0987654321',NULL)

CREATE TABLE RoomStatus
(
    RoomStatus VARCHAR(30) PRIMARY KEY,
    Notes VARCHAR(MAX) 
)

INSERT INTO RoomStatus VALUES
('Taken',NULL),
('Free',NULL),
('Cleaning',NULL)

CREATE TABLE RoomTypes
(
    RoomType VARCHAR(30) PRIMARY KEY,
    Notes VARCHAR(MAX) 
)

INSERT INTO RoomTypes VALUES
('Apartment',NULL),
('President-apartment',NULL),
('Family',NULL)

CREATE TABLE BedTypes
(
    BedType VARCHAR(30) PRIMARY KEY,
    Notes VARCHAR(MAX) 
)

INSERT INTO BedTypes VALUES
('1 Bed',NULL),
('2 Beds',NULL),
('Mix',NULL)

CREATE TABLE Rooms
(
    RoomNumber INT PRIMARY KEY IDENTITY,
    RoomType VARCHAR(30) FOREIGN KEY REFERENCES RoomTypes(RoomType),
    BedType VARCHAR(30) FOREIGN KEY REFERENCES BedTypes(BedType),
    Rate DECIMAL(3,2),
    RoomStatus VARCHAR(30)  FOREIGN KEY REFERENCES RoomStatus(RoomStatus),
    Notes VARCHAR(MAX) 
)

INSERT INTO Rooms (RoomType,BedType,Rate,RoomStatus,Notes) VALUES
('Apartment','1 Bed',2.4,'Taken',NULL),
('President-apartment','2 Beds',5.4,'Free',NULL),
('Family','Mix',3.3,'Cleaning',NULL)

CREATE TABLE Payments
(
    Id INT PRIMARY KEY IDENTITY,
    EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
    PaymentDate DATE NOT NULL,
    AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumbeer),
    FirstDateOcupied DATE NOT NULL,
    LastDateOcupied DATE NOT NULL,
    TotalDays INT NOT NULL,
    AmountCharged DECIMAL(15,2),
    TaxRate DECIMAL(3,2),
    TaxAmount DECIMAL(15,2) NOT NULL,
    PaymentTotal DECIMAL(15,2) NOT NULL,
    Notes VARCHAR(MAX) 
)

INSERT INTO Payments 
            (EmployeeId, PaymentDate, AccountNumber,
            FirstDateOcupied, LastDateOcupied, TotalDays,
            AmountCharged, TaxRate, TaxAmount,
            PaymentTotal, Notes)
VALUES
(1,'03-20-2000',1,'03-20-2000','03-20-2000',5,300,5.5,35.5,340.22,NULL),   
(2,'03-30-2000',2,'03-25-2000','03-30-2000',5,400,6.5,40.5,360.22,NULL),
(3,'03-10-2000',1,'03-05-2000','03-10-2000',5,500,5.5,50.5,440.22,NULL)

CREATE TABLE Occupancies
(
    Id INT PRIMARY KEY IDENTITY,
    EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
    DateOccupied DATE NOT NULL,
    AccountNumber INT FOREIGN KEY REFERENCES Customers(AccountNumbeer),
    RoomNumber INT FOREIGN KEY REFERENCES Rooms(RoomNumber),
    RateApplied DECIMAL(3,2),
    PhoneCharge  DECIMAL(3,2),
    Notes VARCHAR(MAX) 
)

INSERT INTO Occupancies 
            (
                EmployeeId,DateOccupied,AccountNumber,
                RoomNumber, RateApplied, PhoneCharge,
                Notes)
VALUES
(1,'03-20-2000',1,1,3.2,4.2,NULL),
(2,'03-25-2000',2,2,3.5,4.2,NULL),
(3,'03-10-2000',3,3,NULL,NULL,NULL)
