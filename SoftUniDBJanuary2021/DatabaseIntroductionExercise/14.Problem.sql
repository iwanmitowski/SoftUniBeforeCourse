CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(30) UNIQUE NOT NULL,
	DailyRate DECIMAL(4,1) NOT NULL,
	WeeklyRate DECIMAL(4,1) NOT NULL,
	MonthlyRate DECIMAL(4,1) NOT NULL,
	WeekendRate DECIMAL(4,2) NOT NULL
)

INSERT INTO Categories VALUES
('Category1', 1.0, 1.1, 1.1, 1.1),
('Category2', 1.0, 1.2, 1.2, 1.2),
('Category3', 1.0, 1.3, 1.3, 1.3)

CREATE TABLE Cars
(
	Id INT PRIMARY KEY IDENTITY,
	PlateNumber VARCHAR(8) NOT NULL,
	Manufacturer VARCHAR(30) NOT NULL,
	Model VARCHAR(30) NOT NULL,
	CarYear DATE,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Doors INT NOT NULL,
	Picture VARCHAR(MAX),
	Condition VARCHAR(20) NOT NULL,
	Available BIT NOT NULL
)

INSERT INTO Cars VALUES
('12345','Mercedes','C180','01-01-1997',1,4,'Pic','Excellent',1),
('1236','Mercedes','C220','01-01-1998',2,4,'Pic2','Excellent',1),
('12344','Mercedes','AMG','01-01-1999',3,4,'Pic3','Good',0)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Title VARCHAR(10),
	Notes VARCHAR(MAX)
)

INSERT INTO Employees VALUES
('I','M','CEO',NULL),
('B','B','Invest',NULL),
('B','G',NULL,NULL)

CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY,
	DriverLicenceNumber VARCHAR(10) UNIQUE NOT NULL,
	FullName VARCHAR(100) NOT NULL,
	Address VARCHAR(100) NOT NULL,
	City VARCHAR(30) NOT NULL,
	ZIPCode VARCHAR(4),
	Notes VARCHAR(MAX)
)

INSERT INTO Customers VALUES
('1234567890','I C M', 'Pld', 'Plovdiv','4004', NULL),
('1234567891','B M B', 'Sofia', 'Sofia','1000', NULL),
('1234567892','I C C', 'Varna', 'Varna','2500', NULL)

CREATE TABLE RentalOrders
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT FOREIGN KEY REFERENCES Employees(Id),
	CustomerId INT FOREIGN KEY REFERENCES Customers(Id),
	CarId INT FOREIGN KEY REFERENCES Cars(Id),
	TankLevel DECIMAL(4,2) NOT NULL,
	KilometrageStart BIGINT,
	KilometrageEnd BIGINT,
	TotalKilometrage BIGINT,
	StartDate DATE NOT NULL,
	EndDate DATE NOT NULL,
	TotalDays INT,
	RateApplied DECIMAL(4,1),
	TaxRate DECIMAL(4,1),
	OrderStatus BIT,
	Notes VARCHAR(MAX)
)

INSERT INTO RentalOrders VALUES
(1,1,1,50,0,320,18000,'05-10-2020','05-11-2020',6, NULL, NULL, NULL, NULL),
(2,2,2,50,0,420,18000,'05-10-2020','05-10-2020',5, NULL, NULL, NULL, NULL),
(3,3,3,50,0,520,18000,'05-10-2020','05-12-2020',7, NULL, NULL, NULL, NULL)