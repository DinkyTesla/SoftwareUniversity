USE SoftUni;

--01. Find Names of All Employees by First Name--
SELECT [FirstName], [LastName]
	FROM Employees
	WHERE [FirstName] LIKE 'SA%';

--02. Find Names of All employees by Last Name--
SELECT [FirstName], [LastName]
	FROM Employees
	WHERE [LastName] LIKE '%ei%';

--03. Find First Names of All Employees--
SELECT [FirstName]
	FROM Employees
	WHERE [DepartmentID] IN (3, 10)
	 AND DATEPART(Year, [HireDate]) BETWEEN 1995 AND 2005;	
	 
--04. Find Names of All Employees by First Name--
SELECT [FirstName], [LastName]
	FROM Employees
	WHERE [JobTitle] NOT LIKE '%engineer%';

	--05. Find Towns with Name Length--
	SELECT [Name]
		FROM Towns
		WHERE LEN([Name]) IN(5, 6)
		ORDER BY [Name];
	
--06. Find Towns Starting With--
SELECT [TownID], [Name]
	FROM Towns
	WHERE [Name] LIKE 'M%' OR [Name] LIKE 'K%' OR [Name] LIKE 'B%' OR [Name] LIKE 'E%'
	ORDER BY [Name];

--07. Find Towns Not Starting With--
SELECT *
	FROM Towns
	WHERE [Name] NOT LIKE 'R%' AND [Name] NOT LIKE 'B%' AND [Name] NOT LIKE 'D%'
	ORDER BY [Name];
	
--08. Create View Employees Hired After 2000 Year--
CREATE VIEW V_EmployeesHiredAfter2000 AS
	SELECT [FirstName], [LastName]
	FROM Employees
	WHERE DATEPART(YEAR, [HireDate]) > 2000;

--09. Length of Last Name--
SELECT [FirstName], [LastName]
	FROM Employees
	WHERE LEN([LastName]) = 5;

--10. Rank Employees by Salary--
SELECT [EmployeeID], [FirstName], [LastName], [Salary],
	DENSE_RANK() OVER (PARTITION  by [Salary] order by [EmployeeID]) AS [Rank]
	FROM Employees
	WHERE [Salary] BETWEEN 10000 AND 50000
	ORDER BY [Salary] DESC;

--11. Find All Employees with Rank 2--
SELECT *
	FROM ( SELECT [EmployeeID], [FirstName], [LastName], [Salary],
			DENSE_RANK() OVER (PARTITION  by [Salary] order by [EmployeeID]) AS [Rank]
			FROM Employees
			WHERE [Salary] BETWEEN 10000 AND 50000
		) AS MyRanking
	WHERE MyRanking.[Rank] = 2
	ORDER BY MyRanking.Salary DESC;


USE Geography

--12. Countries Holding ‘A’ 3 or More Times--
SELECT [CountryName], [IsoCode]
	FROM Countries
	WHERE [CountryName] LIKE '%A%A%A%'
	ORDER BY [IsoCode];

--13. Mix of Peak and River Names--
SELECT [PeakName], [RiverName], LOWER(LEFT([PeakName], LEN([PeakName]) -1) + [RiverName]) AS Mix
	FROM Peaks, Rivers
	WHERE RIGHT([PeakName], 1) = LEFT([RiverName], 1)
	ORDER BY [Mix];

USE Diablo

--14. Games From 2011 and 2012 Year--
SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start]
	FROM Games
	WHERE DATEPART(Year, [Start]) BETWEEN 2011 AND 2012
	ORDER BY [Start], [Name];

--15. User Email Providers--
SELECT [Username], SUBSTRING([Email], CHARINDEX('@', [Email]) + 1, LEN([Email])) AS [Email Provider]
	FROM USERS
	ORDER BY [Email Provider], [Username];

--16. Get Users with IPAddress Like Pattern--
SELECT [Username], [IpAddress]
	FROM Users
	WHERE [IpAddress] LIKE  '___.1_%._%.___'
	ORDER BY [Username];

--17. Show All Games with Duration--
SELECT [Name],
	CASE
		WHEN DATEPART(HOUR, [Start]) >= 0 AND DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
		WHEN DATEPART(HOUR, [Start]) >= 12 AND DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
		ELSE 'Evening'
	END AS [Part of the Day],
	CASE
		WHEN [Duration] <= 3 THEN 'Extra Short'
		WHEN [Duration] >= 4 AND [Duration] <= 6 THEN 'Short'
		WHEN [Duration] > 6 THEN 'Long'
		ELSE 'Extra Long'
	END AS [DurationName]
	FROM Games
ORDER BY [Name], [DurationName], [Part of the Day];

USE SoftUni

--18. Orders Table--
SELECT [ProductName], [OrderDate], DATEADD(DAY, 3, [OrderDate]) 
	AS [Pay Due], DATEADD(MONTH, 1, [OrderDate]) AS [Delivery Due]
	FROM Orders;