--01.Create and Use--
CREATE DATABASE Minions

USE Minions

--02.Create Minions and Town tables with PKs--
CREATE TABLE Minions(
	Id INT NOT NULL, 
	[Name] NVARCHAR(30) NOT NULL, 
	Age INT
)

CREATE TABLE Towns(
	Id INT NOT NULL,
	[Name] NVARCHAR(30) NOT NULL
)

ALTER TABLE Minions
ADD CONSTRAINT PK_Id
PRIMARY KEY(Id)

ALTER TABLE Towns
ADD CONSTRAINT PK_TownId
PRIMARY KEY (Id)

--03.Alter Minions Table with new column--
ALTER TABLE Minions
Add TownId INT

ALTER TABLE Minions
ADD CONSTRAINT FK_MinionTownID
FOREIGN KEY (TownId) REFERENCES Towns(Id)

--04.Populate both tables--
INSERT INTO Towns(Id, [Name]) VALUES
	(1, 'Sofia'),
	(2, 'Plovdiv'),
	(3, 'Varna')

INSERT INTO Minions(Id, [Name], Age, TownId) VALUES
	(1, 'Kevin', 22, 1),
	(2, 'Bob', 15, 3),
	(3, 'Steward', NULL, 2)

SELECT * FROM Minions

--06.Drop the tables--
DROP TABLE Minions

DROP TABLE Towns

--07.Create table People--
CREATE TABLE People(
	Id INT PRIMARY KEY IDENTITY(1,1),
	[Name] NVARCHAR(30) NOT NULL,
	Picture IMAGE,
	Height DECIMAL(10,2),
	[Weight] DECIMAL(10,2),
	Gender VARCHAR(1) NOT NULL CHECK (Gender = 'm' OR Gender = 'f'),
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX)
);

--ALTER TABLE People
--ADD CONSTRAINT PK_PeopleIds
--PRIMARY KEY (Id)

--SELECT * FROM People

--drop table People

INSERT INTO People([Name], Picture, Height, [Weight], Gender, Birthdate, Biography) VALUES
('Ivan', NULL, 1.239, 69.236, 'm', '1987-10-22', NULL),
('Pesho', NULL, 1.596, 56.231, 'm', '1996/09/15', 'Az sam Pesho'),
('Gosho', NULL, 2.102, 105.36, 'm', '2001/02/23', NULL),
('Penka', NULL, 2.012, 68.236, 'f', '1996/02/11', NULL),
('Stanka', NULL, 1.369, 12.2365, 'f', '1996/06/03', 'Idem s Tanka!');

--08.Create table Users--
CREATE TABLE Users(
Id INT PRIMARY KEY IDENTITY(1, 1),
Username VARCHAR(30) NOT NULL,
[Password] VARCHAR(26) NOT NULL,
ProfilePicture IMAGE,
LastLoginTime SMALLDATETIME,
IsDeleted VARCHAR(5) NOT NULL CHECK(IsDeleted = 'true' OR IsDeleted = 'false')
);

INSERT INTO Users(Username, [Password], ProfilePicture, LastLoginTime, IsDeleted) VALUES
('Pesho', '12345', NULL, GETDATE(), 'false'),
('Gosho', '12345', NULL, GETDATE(), 'false'),
('Ivan', '12345', NULL, GETDATE(), 'false'),
('Panka', '12345', NULL, GETDATE(), 'false'),
('Stanka', '12345', NULL, GETDATE(), 'true');

SELECT * FROM Users

--13.Create Movies Database--
CREATE DATABASE Movies

USE Movies

CREATE TABLE Directors(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	DirectorName NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX)
);

CREATE TABLE Genres(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	GenreName NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX)
);

CREATE TABLE Categories(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	CategoryName NVARCHAR(30) NOT NULL,
	Notes NVARCHAR(MAX)
);

CREATE TABLE Movies(
	Id INT PRIMARY KEY IDENTITY(1, 1),
	Title NVARCHAR(50),
	DirectorId INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL,
	CopyrightYear INT NOT NULL,
	[Length] INT NOT NULL,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
	CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
	Rating INT,
	NOTES NVARCHAR(MAX)
);

INSERT INTO Directors(DirectorName, Notes) VALUES
	('Pesho', 'Pesho e pesho'),
	('Gosho', 'Pesho e Gosho'),
	('Ivan', NULL),
	('Stanka', 'Stanka e s tanka'),
	('Penka', 'Penka ne e pesho');

INSERT INTO Genres(GenreName, Notes) VALUES
	('Strah', 'Strah'),
	('Fun', 'Fun'),
	('Action', 'Action'),
	('Sci-Fi', 'Cosmos'),
	('Drama', NULL);

INSERT INTO Categories(CategoryName, Notes) VALUES
	('Strah', 'Strah'),
	('Fun', 'Fun'),
	('Action', 'Action'),
	('Sci-Fi', 'Cosmos'),
	('Drama', NULL);

INSERT INTO Movies(Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, NOTES) VALUES
	('Muhata', 1, 1997, 79, 1, 1, 4, 'Muhata'),
	('Ledena Epoha', 2, 2011, 79, 1, 1, 4, 'Studeno'),
	('Stealth', 3, 1987, 79, 1, 1, 4, 'Samoleti'),
	('FastAndFurious111', 5, 1994, 79, 1, 1, 4, 'Smenqt po 20 skorosti'),
	('StarWars', 4, 1970, 119, 4, 4, 10, 'Muhata');

--SELECT * FROM Movies

--14.Create Car Rental Database--
CREATE DATABASE CarRental

USE CarRental

CREATE TABLE Categories(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL, 
	[CategoryName] VARCHAR(20) NOT NULL,
	[DailyRate] INT,
	[WeeklyRate] INT,
	[MonthlyRate] INT,
	[WeekendRate] INT
);

INSERT INTO Categories([CategoryName]) VALUES
	('OFF-Road'),
	('Street'),
	('Drag Race');

CREATE TABLE Cars(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL, 
	[PlateNumber] INT NOT NULL,
	[Manufacturer] VARCHAR(20) NOT NULL, 
	[Model] VARCHAR(20), 
	[CarYear] INT NOT NULL,
	[CategoryId] INT FOREIGN KEY REFERENCES Categories([Id]) NOT NULL,
	[Doors] INT NOT NULL,
	[Picture] IMAGE,
	[Condition] VARCHAR(100),
	[Available] VARCHAR(5) NOT NULL CHECK([Available] = 'Yes' Or [Available] = 'No')
);

INSERT INTO Cars([PlateNumber], [Manufacturer], [CarYear], [CategoryId], [Doors], [Available]) VALUES
	(1991, 'BMW', 1999, 2, 5, 'Yes'),
	(7887, 'Nissan', 2001, 1, 3, 'No'),
	(8778, 'Benz', 2018, 3, 2, 'Yes');

CREATE TABLE Employees(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[FirstName] VARCHAR(20) NOT NULL,
	[LastName] VARCHAR(20) NOT NULL,
	[Title] VARCHAR(20), 
	[Notes] VARCHAR(MAX)
);

INSERT INTO Employees([FirstName], [LastName]) VALUES
	('Pesho', 'Peshov'),
	('Gosho', 'Goshev'),
	('Valyo', 'Karamanchev');

CREATE TABLE Customers(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[DriverLicenceNumber] INT NOT NULL,
	[FullName] VARCHAR(100) NOT NULL, 
	[Address] VARCHAR(30),
	[City] VARCHAR(20), 
	[ZIPCode] INT,
	[Notes] VARCHAR(MAX)
);

INSERT INTO Customers([DriverLicenceNumber], [FullName]) VALUES
	(1991, 'Ivan Ivanov'),
	(2065, 'Pesho Peshev'),
	(3456, 'Miro Stoyanov');

CREATE TABLE RentalOrders(
	[Id]INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[EmployeeId] INT FOREIGN KEY REFERENCES Employees([Id]) NOT NULL,
	[CustomerId]  INT FOREIGN KEY REFERENCES Customers([Id]) NOT NULL,
	[CarId]  INT FOREIGN KEY REFERENCES Cars([Id]) NOT NULL, 
	[TankLevel] INT, 
	[KilometrageStart] INT NOT NULL, 
	[KilometrageEnd] INT, 
	[TotalKilometrage] INT,
	[StartDate] SMALLDATETIME,
	[EndDate] SMALLDATETIME, 
	[TotalDays] INT, 
	[RateApplied] INT, 
	[TaxRate] INT, 
	[OrderStatus] VARCHAR(20), 
	[Notes] VARCHAR(MAX)
);

INSERT INTO RentalOrders([EmployeeId], [CustomerId], [CarId], [KilometrageStart]) VALUES
	(2, 1, 3, 1253620),
	(1, 2, 3, 1236322036),
	(3, 3, 1, 1523692);


--15.Create Hotel Database--
--CREATE DATABASE HOTEL

--USE HOTEL

CREATE TABLE Employees(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL, 
	[FirstName] VARCHAR(20) NOT NULL, 
	[LastName] VARCHAR(20) NOT NULL, 
	[Title] VARCHAR(20), 
	[Notes] VARCHAR(MAX)
);

INSERT INTO Employees([FirstName], [LastName]) VALUES
 ('Peshp', 'Penev'),
 ('Milen', 'Markov'),
 ('Filip', 'Maskov');

CREATE TABLE Customers(
	[AccountNumber] INT PRIMARY KEY NOT NULL, 
	[FirstName] VARCHAR(20) NOT NULL,
	[LastName] VARCHAR(20) NOT NULL, 
	[PhoneNumber] VARCHAR(12), 
	[EmergencyName] VARCHAR(20), 
	[EmergencyNumber] VARCHAR(12), 
	[Notes] VARCHAR(MAX)
);

INSERT INTO Customers([AccountNumber], [FirstName], [LastName]) VALUES
	(12, 'Peshp', 'Penev'),
	(13, 'Milen', 'Markov'),
	(14, 'Filip', 'Maskov');

CREATE TABLE RoomStatus(
	[RoomStatus] VARCHAR(20) PRIMARY KEY NOT NULL CHECK(RoomStatus = 'Free' OR RoomStatus = 'Full' OR RoomStatus = 'Half'),
	[Notes] VARCHAR(MAX)
);

INSERT INTO RoomStatus([RoomStatus]) VALUES
	('Free'),
	('Half'),
	('Full');

CREATE TABLE RoomTypes(
	[RoomType] VARCHAR(20) PRIMARY KEY NOT NULL,
	[Notes]VARCHAR(MAX)
);

INSERT INTO RoomTypes([RoomType]) VALUES
	('Tripple'),
	('Double'),
	('Mezonet');

CREATE TABLE BedTypes(
	[BedType]  VARCHAR(20) PRIMARY KEY NOT NULL,
	[Notes]VARCHAR(MAX)
);

INSERT INTO BedTypes([BedType]) VALUES
	('Single'),
	('Double'),
	('Tripple');

CREATE TABLE Rooms(
	[RoomNumber] INT PRIMARY KEY NOT NULL, 
	[RoomType] VARCHAR(20) FOREIGN KEY REFERENCES RoomTypes([RoomType]) NOT NULL,
	[BedType] VARCHAR(20) FOREIGN KEY REFERENCES BedTypes([BedType]) NOT NULL,
	[Rate] INT,
	[RoomStatus] VARCHAR(20) FOREIGN KEY REFERENCES RoomStatus([RoomStatus]) NOT NULL, 
	[Notes] VARCHAR(MAX)
);

INSERT INTO Rooms([RoomNumber], [RoomType], [BedType], [RoomStatus]) VALUES
	(123, 'Tripple', 'Tripple', 'Free'),
	(1254, 'Mezonet', 'Single', 'Full'),
	(2563, 'Double', 'Single', 'Half');

CREATE TABLE Payments(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[EmployeeId] INT FOREIGN KEY REFERENCES Employees([Id]) NOT NULL,
	[PaymentDate] DATETIME,
	[AccountNumber] INT,
	[FirstDateOccupied] DATETIME,
	[LastDateOccupied] DATETIME,
	[TotalDays] INT,
	[AmountCharged] DECIMAL(15, 2),
	[TaxRate] INT, 
	[TaxAmount] DECIMAL(15, 2),
	[PaymentTotal] DECIMAL(15, 2), 
	[Notes] VARCHAR(MAX)
);

INSERT INTO Payments([EmployeeId]) VALUES
	(2),
	(3),
	(1);

CREATE TABLE Occupancies(
	[Id] INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
	[EmployeeId] INT FOREIGN KEY REFERENCES Employees([Id]) NOT NULL, 
	[DateOccupied] DATETIME, 
	[AccountNumber] INT, 
	[RoomNumber] INT, 
	[RateApplied] INT, 
	[PhoneCharge] INT, 
	[Notes] VARCHAR(MAX)
);

INSERT INTO Occupancies([EmployeeId]) VALUES
	(2),
	(1),
	(3);

--19.Select All Fields--
SELECT * FROM Towns;
SELECT * FROM Departments;
SELECT * FROM Employees;

--20.Select All Fields and Order them--
SELECT * FROM Towns ORDER BY Name;
SELECT * FROM Departments ORDER BY Name;
SELECT * FROM Employees ORDER BY Salary DESC;

--21.Basic Select Some Fields--
SELECT [Name] FROM Towns
ORDER BY Name;

SELECT [Name] FROM Departments
ORDER BY Name;

SELECT [FirstName], [LastName], [JobTitle], [Salary] FROM Employees
ORDER BY Salary DESC;

--22. Increase Employees Salary--
UPDATE Employees
SET [Salary] = [Salary] + [Salary] * 0.10;
SELECT [Salary] FROM Employees;

--23. Decrease Tax Rate--
UPDATE Payments
SET [TaxRate] -= [TaxRate] * 0.03;
SELECT [TaxRate] FROM Payments;

--24. Delete All Records--
TRUNCATE Table Occupancies; 