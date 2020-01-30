USE SoftUni

--01. Employee Address--
SELECT TOP(5) e.EmployeeID, e.JobTitle, a.AddressID, a.AddressText
	FROM [Employees] AS e
	JOIN [Addresses] AS a ON a.AddressID = e.AddressID
	ORDER BY a.AddressID;

--02. Addresses with Towns--
SELECT TOP(50) e.FirstName, e.LastName, t.[Name], a.AddressText
	FROM [Employees] AS e
	JOIN [Addresses] AS a ON a.AddressID = e.AddressID
	JOIN [Towns] AS t ON t.TownID = a.TownID
	ORDER BY e.FirstName, e.LastName;

--03. Sales Employees--
SELECT e.EmployeeID, e.FirstName, e.LastName, d.[Name]
	FROM [Employees] AS e
	JOIN [Departments] AS d ON d.DepartmentID = e.DepartmentID
	WHERE d.[Name] = 'Sales'
	ORDER BY e.EmployeeID;

--04. Employee Departments--
SELECT TOP(5) e.EmployeeID, e.FirstName, e.Salary, d.[Name]
	FROM [Employees] AS e
	JOIN [Departments] AS d ON d.DepartmentID = e.DepartmentID
	WHERE e.Salary > 15000
	ORDER BY e.DepartmentID;

--05. Employees Without Projects--
SELECT TOP(3) e.EmployeeID, e.FirstName
	FROM [Employees] AS e
	FULL JOIN [EmployeesProjects] AS ep ON ep.EmployeeID = e.EmployeeID
	WHERE ep.ProjectID IS NULL
	ORDER BY e.EmployeeID;

--06. Employees Hired After--
SELECT e.FirstName, e.LastName, e.HireDate, d.[Name]
	FROM [Employees] AS e
	JOIN [Departments] AS d ON d.DepartmentID = e.DepartmentID
	WHERE e.HireDate > '1.1.1999' AND d.[Name] IN ('Sales', 'Finance')
	ORDER BY e.HireDate;

--07. Employees With Project--
SELECT TOP(5) e.EmployeeID, e.FirstName, p.[Name]
	FROM [Employees] AS e
	JOIN [EmployeesProjects] AS ep ON ep.EmployeeID = e.EmployeeID
	JOIN [Projects] AS p ON p.ProjectID = ep.ProjectID
	WHERE p.StartDate > '2002.08.13' AND p.EndDate IS NULL
	ORDER BY e.EmployeeID;

--08. Employee 24--
SELECT e.EmployeeID, e.FirstName, IIF(Year(p.StartDate) >= 2005, NULL, p.[Name])
	FROM [Employees] AS e
	JOIN [EmployeesProjects] AS ep ON ep.EmployeeID = e.EmployeeID
	JOIN [Projects] AS p ON p.ProjectID = ep.ProjectID
	WHERE e.EmployeeID = 24;

--09. Employee Manager--
SELECT e.EmployeeID, e.FirstName, e.ManagerID, mg.FirstName AS [ManagerName]
	FROM [Employees] AS e
	JOIN [Employees] AS mg ON mg.EmployeeID = e.ManagerID
	WHERE mg.EmployeeID IN (3, 7)
	ORDER BY e.EmployeeID;

--10. Employees Summary--
SELECT TOP(50) e.EmployeeID, e.FirstName + ' ' + e.LastName AS [EmployeeName],
		mg.FirstName + ' ' + mg.LastName AS [ManagerName],
			d.[Name] AS [DepartmentName]
	FROM [Employees] AS e
	JOIN [Employees] AS mg ON mg.EmployeeID = e.ManagerID
	JOIN [Departments] as d ON d.DepartmentID = e.DepartmentID
	ORDER BY e.EmployeeID;

--11. Min Average Salary--
SELECT TOP(1) AVG(e.Salary) AS [MinAverageSalary]
	FROM [Departments] AS d
	JOIN [Employees] AS e ON e.DepartmentID = d.DepartmentID
	GROUP BY d.[Name]
	ORDER BY [MinAverageSalary];

USE [Geography];

--12. Highest Peaks in Bulgaria--
SELECT c.CountryCode, m.MountainRange, p.[PeakName], p.Elevation
	FROM [Countries] AS c
	JOIN [MountainsCountries] AS mc ON mc.CountryCode = c.CountryCode
	JOIN [Mountains] AS m ON m.Id = mc.MountainId
	JOIN [Peaks] AS p ON p.MountainId = m.Id
	WHERE c.CountryName = 'Bulgaria' AND p.Elevation > 2835
	ORDER BY p.Elevation DESC;

--13. Count Mountain Ranges--
SELECT c.CountryCode, COUNT(m.MountainRange) AS [MountainRanges]
	FROM [Countries] AS c
	JOIN [MountainsCountries] AS mc ON mc.CountryCode = c.CountryCode
	JOIN [Mountains] AS m ON m.Id = mc.MountainId
	WHERE c.CountryName IN ('United States', 'Russia', 'Bulgaria')
	GROUP BY c.CountryCode;

--14. Countries With or Without Rivers--
SELECT TOP(5) c.CountryName, r.RiverName
	FROM [Countries] AS c
	FULL JOIN [CountriesRivers] AS cr ON cr.CountryCode = c.CountryCode
	FULL JOIN [Rivers] AS r ON r.Id = cr.RiverId
	WHERE c.ContinentCode = 'AF'
	ORDER BY c.CountryName;

--15. Continents and Currencies--
SELECT k.ContinentCode, k.CurrencyCode, k.CurrencyUsage
	FROM (
	SELECT c.ContinentCode,
			c.CurrencyCode,
				COUNT(c.CurrencyCode) AS [CurrencyUsage],
				DENSE_RANK() OVER(PARTITION BY c.ContinentCode ORDER BY COUNT(c.CurrencyCode) DESC) AS [RANK]
	FROM [Countries] AS c
	JOIN [Currencies] AS cu ON cu.CurrencyCode = c.CurrencyCode
	GROUP BY c.ContinentCode, c.CurrencyCode
	HAVING COUNT(c.CurrencyCode) != 1) AS k
	WHERE k.[RANK] = 1
	ORDER BY k.ContinentCode;

--16. Countries Without any Mountains--
SELECT COUNT(*) AS [CountryCode]
	FROM [Countries] AS c
	FULL JOIN [MountainsCountries] AS mc ON mc.CountryCode = c.CountryCode
	WHERE mc.MountainId IS NULL;

--17. Highest Peak and Longest River by Country--
SELECT TOP(5) c.CountryName,
		MAX(p.Elevation) AS [HighestPeakElevation],
			MAX(r.[Length]) AS [LongestRiverLength]
	FROM [Countries] AS c
	JOIN [MountainsCountries] AS MC ON mc.CountryCode = c.CountryCode
	JOIN [Mountains] AS m ON m.Id = mc.MountainId
	JOIN [Peaks] AS p ON p.MountainId = mc.MountainId
	JOIN [CountriesRivers] AS cr ON cr.CountryCode = c.CountryCode
	JOIN [Rivers] AS r ON r.Id = cr.RiverId
GROUP BY c.CountryName
ORDER BY [HighestPeakElevation] DESC, [LongestRiverLength] DESC, c.CountryName;


--17. Highest Peak and Longest River by Country--
SELECT TOP(5) k.CountryName,
		ISNULL(k.PeakName, '(no highest peak)'),
			ISNULL(k.[Highest Peak Elevation], 0),
			ISNULL(k.MountainRange, '(no mountain)')
	FROM (
	SELECT c.CountryName,
			p.PeakName,
				MAX(p.Elevation) AS [Highest Peak Elevation],
				m.MountainRange,
				DENSE_RANK() OVER(PARTITION BY c.CountryName ORDER BY MAX(p.Elevation) DESC) AS [RANK]
	FROM [Countries] AS c
	LEFT JOIN [MountainsCountries] AS mc ON mc.CountryCode = c.CountryCode
	LEFT JOIN [Mountains] AS m ON m.Id = mc.MountainId
	LEFT JOIN [Peaks] AS p ON p.MountainId = mc.MountainId
GROUP BY c.CountryName, p.PeakName, m.MountainRange) AS k
WHERE k.[RANK] = 1
ORDER BY k.CountryName, k.PeakName;