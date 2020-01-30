USE [master]

DROP DATABASE [Service]

CREATE DATABASE [Service]

USE [Service]

--01. DDL--

CREATE TABLE [Users]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Username] VARCHAR(30) UNIQUE NOT NULL, --Check this--
	[Password] VARCHAR(50) NOT NULL,
	[Name] VARCHAR(50) NOT NULL,
	[Birthdate] SMALLDATETIME,
	[Age] INT CHECK([Age] BETWEEN 14 AND 110),
	[Email] VARCHAR(50) NOT NULL
);

CREATE TABLE [Departments]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
);

CREATE TABLE [Employees]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[FirstName] VARCHAR(25) NOT NULL,
	[LastName] VARCHAR(25) NOT NULL,
	[Birthdate] SMALLDATETIME,
	[Age] INT CHECK([Age] BETWEEN 18 AND 110),
	[DepartmentId] INT FOREIGN KEY REFERENCES [Departments]([Id]) --No "Not Null" constraint???
);

CREATE TABLE [Categories]
(
	[Id] INT PRIMARY KEY IDENTITY,	
	[Name] VARCHAR(50) NOT NULL,
	[DepartmentId] INT FOREIGN KEY REFERENCES [Departments]([Id]) NOT NULL
);

CREATE TABLE [Status]
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Label] VARCHAR(30) NOT NULL
);

CREATE TABLE [Reports]
(
	[Id] INT PRIMARY KEY IDENTITY,	
	[CategoryId] INT FOREIGN KEY REFERENCES [Categories]([Id]) NOT NULL,
	[StatusId] INT FOREIGN KEY REFERENCES [Status]([Id]) NOT NULL,
	[OpenDate] SMALLDATETIME NOT NULL,
	[CloseDate] SMALLDATETIME,
	[Description] VARCHAR(200) NOT NULL,
	[UserId] INT FOREIGN KEY REFERENCES [Users]([Id]) NOT NULL,
	[EmployeeId] INT FOREIGN KEY REFERENCES [Employees]([Id])
);	

--02. Insert--

INSERT INTO [Employees]([FirstName], [LastName], [Birthdate], [DepartmentId]) VALUES
('Marlo', 'O''Malley', '1958-9-21', 1),
('Niki', 'Stanaghan', '1969-11-26', 4),
('Ayrton', 'Senna', '1960-03-21', 9),
('Ronnie', 'Peterson', '1944-02-14', 9),
('Giovanna', 'Amati', '1959-07-20', 5);

INSERT INTO [Reports]([CategoryId], [StatusId], [OpenDate], [CloseDate], [Description], [UserId], [EmployeeId]) VALUES
(1, 1, '2017-04-13', NULL, 'Stuck Road on Str.133', 6, 2),
(6, 3, '2015-09-05', '2015-12-06', 'Charity trail running', 3, 5),
(14, 2, '2015-09-07', NULL, 'Falling bricks on Str.58', 5, 2),
(4, 3, '2017-07-03', '2017-07-06', 'Cut off streetlight on Str.11', 1, 1);

--03. Update--

UPDATE [Reports]
SET [CloseDate] = GETDATE()
WHERE [CloseDate] IS NULL;

--04. Delete--

DELETE FROM [Reports]
WHERE [StatusId] IN(SELECT [Id] FROM [Status] WHERE [Id] = '4');

--05. Unassigned Reports--

SELECT [Description], FORMAT([OpenDate],'dd-MM-yyyy')
FROM [Reports]
WHERE [EmployeeId] IS NULL
ORDER BY [OpenDate], [Description];

--06. Reports & Categories--

SELECT r.[Description], c.[Name] AS [CategoryName]
FROM [Reports] AS r
JOIN [Categories] AS c ON c.Id = r.CategoryId
ORDER BY r.[Description], [CategoryName];

--07. Most Reported Category--

SELECT TOP(5) ca.[Name] AS [CategoryName], COUNT(ca.Id) AS [ReportsNumber]
FROM [Categories] AS ca
LEFT OUTER JOIN [Reports] AS r ON ca.Id = r.CategoryId
GROUP BY r.CategoryId, ca.[Name]
ORDER BY [ReportsNumber] DESC, [CategoryName];

--08. Birthday Report--

SELECT u.Username, c.[Name] AS [CategoryName]
FROM [Reports] AS r
JOIN [Users] AS u ON u.Id = r.UserId
JOIN [Categories] AS c ON c.Id = r.CategoryId
WHERE FORMAT(r.OpenDate, 'dd-MM') = FORMAT(u.Birthdate, 'dd-MM')
ORDER BY u.Username, [CategoryName];

--09. User per Employee--

SELECT CONCAT(e.FirstName, ' ', e.LastName) AS [FullName], COUNT(r.Id) AS [UsersCount]
FROM [Reports] AS r
RIGHT OUTER JOIN [Employees] AS e ON r.EmployeeId = e.Id
GROUP BY CONCAT(e.FirstName, ' ', e.LastName)
ORDER BY [UsersCount] DESC, [FullName];

--10. Full Info--

SELECT ISNULL(e.FirstName + ' ' + e.LastName, 'None') AS [Employee], ISNULL(d.[Name], 'None') AS [Department], ISNULL(c.[Name], 'None') AS Category,
	ISNULL(r.[Description], 'None') AS [Description], ISNULL(FORMAT(r.OpenDate, 'dd.MM.yyyy'), 'None') AS [OpenDate], ISNULL(s.Label, 'None') AS [Status], ISNULL(u.[Name], 'None') AS [User]
FROM [Reports] AS r
LEFT OUTER JOIN [Employees] AS e ON e.Id = r.EmployeeId
LEFT OUTER JOIN [Departments] AS d ON d.Id = e.DepartmentId
LEFT OUTER JOIN [Categories] AS c ON r.CategoryId = c.Id
LEFT OUTER JOIN [Status] AS s ON s.Id = r.StatusId
LEFT OUTER JOIN [Users] AS u ON u.Id = r.UserId
ORDER BY e.FirstName DESC, e.LastName DESC, [Department], [Category], [Description], [OpenDate], [Status], [User];

--11. Hours To Complete--
CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
RETURNS INT
AS
BEGIN
	IF(@StartDate IS NULL)
	BEGIN
		RETURN 0;
	END

	IF(@EndDate IS NULL)
	BEGIN
		RETURN 0;
	END

	DECLARE @result INT = DATEDIFF(HOUR, @StartDate, @EndDate)

	RETURN @result
END;

SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
   FROM Reports


 --12. Assign Employee--

 CREATE PROCEDURE usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
 AS
 BEGIN

		DECLARE @employeeDep INT = (SELECT * FROM [Employees] AS e 
									JOIN [Departments] AS d ON e.DepartmentId = d.Id
									WHERE e.Id = @EmployeeId)

		DECLARE @reportDep INT = (SELECT * FROM [Reports] AS r 
									JOIN [Categories] AS c ON r.CategoryId = c.Id
									JOIN [Departments] AS d ON d.Id = c.DepartmentId
									WHERE r.Id = @ReportId)


		DECLARE @sameDepartments BIT = IF(@employeeDep === @reportDep);
 END;