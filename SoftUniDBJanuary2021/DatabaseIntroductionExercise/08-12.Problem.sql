CREATE TABLE Users
(
	Id INT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARCHAR(MAX),
	LastLoginTime DATETIME,
	IsDeleted BIT
)

INSERT INTO Users (Username, [Password], ProfilePicture, LastLoginTime, IsDeleted) VALUES
	('Ivan Ivanov', '12345', 'Pic', '1989-05-20', 0),
	('Boiko Borisov', '12345', 'Pic', GETDATE(), 0),
	('Ilko Ilkov', '12345', 'Pic', '1989-05-20', 0),
	('Vanko Vankov', '12345', 'Pic', GETDATE(), 0),
	('Boris Boriskov', '12345', 'Pic', GETDATE(), 0)

--SELECT * FROM INFORMATION_SCHEMA.TABLE_CONSTRAINTS

ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07EEC02554

ALTER TABLE Users
ADD CONSTRAINT PK_IdUserName
PRIMARY KEY (Id,UserName)

ALTER TABLE Users
ADD CONSTRAINT CH_PasswordAtlesat5Symbols 
CHECK (LEN(Password)>4)

ALTER TABLE Users
ADD CONSTRAINT DF_DateTimeInput
DEFAULT GETDATE() FOR LastLoginTime;

ALTER TABLE Users
DROP CONSTRAINT PK_IdUserName

ALTER TABLE Users
ADD CONSTRAINT PK_Id
PRIMARY KEY (Id)

ALTER TABLE Users
ADD CONSTRAINT CH_NameLengthAtleast3Symbols
CHECK (LEN(Username)>2)