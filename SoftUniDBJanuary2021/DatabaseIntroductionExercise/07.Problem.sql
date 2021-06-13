CREATE TABLE People
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(200) NOT NULL,
	Picture VARCHAR(MAX),
	Height DECIMAL(3,2),
	[Weight] DECIMAL(5,2),
	Gender CHAR(1) NOT NULL,
	Birthdate DATE NOT NULL,
	Biography VARCHAR(MAX)
)

INSERT INTO People ([Name], Picture, Height, [Weight], Gender, Birthdate, Biography) VALUES
('I','Pic','1.78','70.2','m','1989-05-20','Bio1'),
('B','Pic','1.79','71.2','m','1989-05-20','Bio1'),
('V',NULL ,'1.77','72.3','f','1989-05-20','Bio2'),
('G','Pic','1.75','73.4','m','1989-05-20','Bio3'),
('D','Pic','1.74','74.5','f','1989-05-20','Bio4')
