CREATE TABLE Directors
(
	Id INT PRIMARY KEY IDENTITY,
	DirectorName VARCHAR(30) NOT NULL,
	Notes VARCHAR(300)
)

INSERT INTO Directors (DirectorName, Notes) VALUES
('Dimitar', 'Pod Prikritie'),
('Vankov', 'Sudbi'),
('Ivanov', 'Nad Prikritie'),
('Dimitrov', 'Do Prikritie'),
('Ivanov', 'Zad Prikritie')


CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY,
	GenreName VARCHAR(30) NOT NULL,
	Notes VARCHAR(300)
)

INSERT INTO Genres VALUES
('Action','Action movies...'),
('Comedy','Comedy movies...'),
('Horror','Horror movies...'),
('Thriller','Thriller movies...'),
('Romantic','Romantic movies...')

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(30) NOT NULL,
	Notes VARCHAR(300)
)

INSERT INTO Categories VALUES
('Funny',NULL),
('Scarry',NULL),
('Interesting',NULL),
('Boring',NULL),
('Kids',NULL)

CREATE TABLE Movies
(
	Id INT PRIMARY KEY IDENTITY,
	Title VARCHAR(40) UNIQUE NOT NULL,
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id),
	CopyRightYear DATE,
	Length TIME NOT NULL,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id),
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id),
	Rating DECIMAL NOT NULL,
	Notes VARCHAR(300)
)

INSERT INTO Movies VALUES
('Pod Prikritie',1,'2011','00:45:00',1,1,10,NULL),
('Nad Prikritie',2,'2012','00:45:00',2,2,9.5,NULL),
('Zad Prikritie',3,'2015','00:50:00',4,4,8,NULL),
('Do Prikritie',4,'2014','00:44:00',3,3,4,NULL),
('Vuv Prikritie',5,'2016','00:48:00',5,5,5,NULL)
