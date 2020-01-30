USE Gringotts

--01. Records’ Count--
SELECT COUNT(*) AS [Count]
	FROM WizzardDeposits;

--02. Longest Magic Wand--
SELECT MAX(MagicWandSize) AS [LongestMagicWand]
	FROM WizzardDeposits;

--03. Longest Magic Wand per Deposit Groups--
SELECT [DepositGroup], MAX(MagicWandSize)
	FROM WizzardDeposits
	GROUP BY DepositGroup;

--04. Smallest Deposit Group per Magic Wand Size--
SELECT TOP(2) [DepositGroup]
	FROM WizzardDeposits
	GROUP BY DepositGroup
	ORDER BY AVG(MagicWandSize);

--05. Deposits Sum--
SELECT [DepositGroup], SUM(DepositAmount)
	FROM WizzardDeposits
	GROUP BY DepositGroup;

--06. Deposits Sum for Ollivander Family--
SELECT [DepositGroup], SUM(DepositAmount)
	FROM WizzardDeposits
	WHERE [MagicWandCreator] = 'Ollivander family' 
	GROUP BY DepositGroup;

--07. Deposits Filter--
SELECT [DepositGroup], SUM(DepositAmount) AS [TotalSum]
	FROM WizzardDeposits
	WHERE [MagicWandCreator] = 'Ollivander family' 
	GROUP BY DepositGroup 
	HAVING SUM(DepositAmount) < 150000
	ORDER BY [TotalSum] DESC;

--08. Deposit Charge--
SELECT [DepositGroup], [MagicWandCreator], MIN(DepositCharge) AS [MinDepositCharge]
	FROM WizzardDeposits
	GROUP BY [DepositGroup], [MagicWandCreator]
	ORDER BY [MagicWandCreator], [DepositGroup];

--09. Age Groups--
SELECT [Ages].[AgeGroup], COUNT([Ages].[AgeGroup]) AS [WizardCount]
	FROM 
(
	SELECT
		CASE
			WHEN [Age] BETWEEN 0 AND 10 THEN '[0-10]'
			WHEN [Age] BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN [Age] BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN [Age] BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN [Age] BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN [Age] BETWEEN 51 AND 60 THEN '[51-60]'
		ELSE '[61+]'
	END AS [AgeGroup]
FROM [WizzardDeposits]) AS [Ages]
	GROUP BY [Ages].[AgeGroup];
	
--10. First Letter--
SELECT LEFT([FirstName], 1) AS [FirstLetter]
	FROM WizzardDeposits
	WHERE [DepositGroup] = 'Troll Chest'
	GROUP BY LEFT([FirstName], 1)
	ORDER BY [FirstLetter];

--11. Average Interest--
SELECT [DepositGroup], [IsDepositExpired], AVG(DepositInterest) AS AverageInterest
	FROM WizzardDeposits
	WHERE [DepositStartDate] > '01/01/1985'
	GROUP BY [DepositGroup], [IsDepositExpired]
	ORDER BY [DepositGroup] DESC, [IsDepositExpired];

--12. Rich Wizard, Poor Wizard--
SELECT SUM(k.Diff)
	FROM
(
	SELECT wd.DepositAmount - (
		SELECT w.DepositAmount 
			FROM [WizzardDeposits] AS w 
			WHERE w.Id = wd.Id + 1) AS Diff
		FROM [WizzardDeposits] AS wd
	) AS k;

USE SoftUni

--13. Departments Total Salaries--
SELECT [DepartmentId], SUM(Salary)
	FROM [Employees]
GROUP BY [DepartmentID]
ORDER BY [DepartmentID];

--14. Employees Minimum Salaries--
SELECT [DepartmentId], MIN(Salary)
	FROM [Employees]
	WHERE [DepartmentID] IN (2, 5, 7) AND [HireDate] > '01/01/2000'
GROUP BY [DepartmentID];

--15. Employees Average Salaries--
SELECT * INTO [NewEmployeesTable]
	FROM [Employees]
	WHERE [Salary] > 30000;
		DELETE FROM [NewEmployeesTable]
		WHERE [ManagerID] = 42;
	UPDATE [NewEmployeesTable]
		SET [Salary] += 5000
		WHERE [DepartmentID] = 1;
	SELECT [DepartmentId], AVG([Salary]) AS [AverageSalary]
	FROM [NewEmployeesTable]
	GROUP BY [DepartmentID];

--16. Employees Maximum Salaries--
SELECT [DepartmentId], MAX([Salary]) AS [MaxSalary]
	FROM [Employees]
	GROUP BY [DepartmentID]
	HAVING MAX([Salary]) NOT BETWEEN 30000 AND 70000;

--17. Employees Count Salaries--
SELECT COUNT(*) AS [Count]
	FROM [Employees]
	WHERE [ManagerID] IS NULL;

--18. 3rd Highest Salary--
SELECT [RankedTable].[DepartmentId], [RankedTable].[Salary]
	FROM (
		SELECT [DepartmentId], [Salary], 
		DENSE_RANK() OVER(
			PARTITION BY [DepartmentId]
			ORDER BY [Salary] DESC) AS [RANK]
	FROM [Employees]
	GROUP BY [DepartmentID], [Salary]) AS [RankedTable]
	WHERE [Rank] = 3;

--19. Salary Challenge--
SELECT TOP(10) [FirstName], [LastName], [DepartmentId]
	FROM [Employees] AS e
	WHERE [Salary] > 
		(
		SELECT AVG([Salary])
		FROM [Employees] AS em
		WHERE em.DepartmentID = e.DepartmentID
		)
	ORDER BY [DepartmentID];
