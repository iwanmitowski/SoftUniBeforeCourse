CREATE DATABASE WMS
USE WMS

CREATE TABLE Clients
(
	ClientId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Phone CHAR(12) NOT NULL
)

CREATE TABLE Mechanics
(
	MechanicId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Address VARCHAR(255) NOT NULL
)

CREATE TABLE Models 
(
	ModelId INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Jobs
(
	JobId INT PRIMARY KEY IDENTITY,
	ModelId INT FOREIGN KEY REFERENCES Models(ModelId),
	Status VARCHAR(11) DEFAULT 'Pending' NOT NULL,
	CONSTRAINT CHK_Status CHECK (Status IN ('Pending', 'In Progress', 'Finished')),
	ClientId INT FOREIGN KEY REFERENCES Clients(ClientId) NOT NULL,
	MechanicId INT FOREIGN KEY REFERENCES Mechanics(MechanicId) NOT NULL,
	IssueDate DATE NOT NULL,
	FinishDate DATE
)

CREATE TABLE Orders
(
	OrderId INT PRIMARY KEY IDENTITY,
	JobId INT FOREIGN KEY REFERENCES Jobs(JobId),
	IssueDate DATE,
	Delivered BIT DEFAULT 0 NOT NULL
)

CREATE TABLE Vendors
(
	VendorId INT PRIMARY KEY IDENTITY,
	Name VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Parts
(
	PartId INT PRIMARY KEY IDENTITY,
	SerialNumber VARCHAR(50) UNIQUE NOT NULL,
	Description VARCHAR(255),
	Price DECIMAL(15,2) NOT NULL,
	CONSTRAINT CHK_Price CHECK (Price>0),
	VendorId INT FOREIGN KEY REFERENCES Vendors(VendorId) NOT NULL,
	StockQty INT DEFAULT 0 NOT NULL,
	CONSTRAINT CHK_StockQty CHECK (StockQty>=0),
)

CREATE TABLE OrderParts
(
	OrderId INT FOREIGN KEY REFERENCES Orders(OrderId),
	PartId INT FOREIGN KEY REFERENCES Parts(PartId),
	Quantity INT DEFAULT 1 NOT NULL,
	CONSTRAINT CHK_QuantityOrderParts CHECK (Quantity>0),
	CONSTRAINT PK_OrderParts PRIMARY KEY (OrderId, PartId)
)

	CREATE TABLE PartsNeeded
	(
		JobId INT FOREIGN KEY REFERENCES Jobs(JobId),
		PartId INT FOREIGN KEY REFERENCES Parts(PartId),
		Quantity INT DEFAULT 1 NOT NULL,
		CONSTRAINT CHK_QuantityPartsNeeded CHECK (Quantity>0),
		CONSTRAINT PK_PartsNeeded PRIMARY KEY (JobId, PartId)
	)