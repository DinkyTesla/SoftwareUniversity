--01. Employees with Salary Above 35000--
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
	AS
	SELECT [e].[FirstName], [e].[LastName]
	FROM [dbo].[Employees] AS e
	WHERE [e].[Salary] > 35000;

--02. Employees with Salary Above Number--
CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber(@Money DECIMAL(18, 4))
	AS
	SELECT e.FirstName, e.LastName
	FROM dbo.Employees AS e
	WHERE e.Salary >= @Money;

--03. Town Names Starting With--
CREATE PROCEDURE usp_GetTownsStartingWith (@Identity VARCHAR(20))
	AS
	SELECT t.[Name] AS [Town]
	FROM dbo.Towns AS t
	WHERE t.[Name] LIKE @Identity + '%';

--04. Employees from Town--
CREATE PROCEDURE usp_GetEmployeesFromTown (@Town VARCHAR(50))
	AS
	SELECT e.FirstName, e.LastName
	FROM dbo.Employees AS e
	JOIN dbo.Addresses AS a ON e.AddressID = a.AddressID
	JOIN dbo.Towns AS t ON a.TownID = t.TownID
	WHERE t.Name = @Town;

--05. Salary Level Function--
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
	RETURNS VARCHAR(50)
	AS
	BEGIN
		DECLARE @result VARCHAR(20)
		IF(@salary < 30000)
			SET @result = 'Low'
		IF(@salary BETWEEN 30000 AND 50000)
			SET @result = 'Average'
		IF(@salary > 50000)
			SET @result = 'High'

		RETURN @result
	END;

--06. Employees by Salary Level--
CREATE PROCEDURE usp_EmployeesBySalaryLevel(@Level VARCHAR(50))
	AS
	SELECT e.FirstName, e.LastName
	FROM dbo.Employees AS e
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @Level;

--07. Define Function--
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(50), @word VARCHAR(100))
	RETURNS BIT
	AS
	BEGIN
		DECLARE @result BIT
		DECLARE @count INT = 1
	
		WHILE @count <= LEN(@Word)
		BEGIN
			DECLARE @currentSymbol VARCHAR(2) = SUBSTRING(@Word, @count, 1)
	
			IF(CHARINDEX(@currentSymbol, @SetOfLetters)) > 0
				BEGIN
					SET @result = 1
					SET @count+=1
				END
			ELSE
				BEGIN
					SET @result = 0
					BREAK
				END
		END
		RETURN @result
	END;

--08. Delete Employees and Departments--
CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN
	ALTER TABLE [dbo].[Departments]
	ALTER COLUMN [ManagerID] INT

	DELETE
	  FROM [dbo].[EmployeesProjects]
	 WHERE [dbo].[EmployeesProjects].[EmployeeID] IN (SELECT [e].[EmployeeID]
	                                                    FROM [dbo].[Employees] AS e
													   WHERE [e].[DepartmentID] = @departmentId);
	UPDATE [dbo].[Departments]
	   SET
	       [dbo].[Departments].[ManagerID] = NULL
	 WHERE [dbo].[Departments].[DepartmentID] = @departmentId;

	 UPDATE [dbo].[Employees]
	    SET
	        [dbo].[Employees].[ManagerID] = NULL
	  WHERE [dbo].[Employees].[ManagerID] IN (SELECT [e].[EmployeeID]
	                                            FROM [dbo].[Employees] AS e
											   WHERE [e].[DepartmentID] = @departmentId);

	DELETE
	  FROM [dbo].[Employees]
	 WHERE [dbo].[Employees].[DepartmentID] = @departmentId;

	DELETE
	  FROM [dbo].[Departments]
	 WHERE [dbo].[Departments].[DepartmentID] = @departmentId;

	 SELECT COUNT(*)
       FROM Employees
      WHERE DepartmentID = @DepartmentId
END;

USE Bank

--09. Find Full Name--
CREATE PROCEDURE usp_GetHoldersFullName
	AS
	SELECT FirstName + ' ' + LastName AS [Full Name]
	FROM AccountHolders;

--10. People with Balance Higher Than--
CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan(@Amount DECIMAL(15, 2))
	AS
	SELECT ah.FirstName, ah.LastName
	FROM dbo.AccountHolders AS ah
	JOIN dbo.Accounts AS a ON ah.Id = a.AccountHolderId
	GROUP BY ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > @Amount
	ORDER BY ah.FirstName, ah.LastName;

--11. Future Value Function--
CREATE FUNCTION ufn_CalculateFutureValue(@Sum DECIMAL(15, 2), @Rate FLOAT, @Years INT)
	RETURNS DECIMAL(15, 4)
	AS
	BEGIN
		RETURN @sum * (POWER(1 + @Rate, @Years))
	END;

--12. Calculating Interest--
CREATE PROCEDURE usp_CalculateFutureValueForAccount(@AccountId INT, @Rate FLOAT)
	AS
	BEGIN
		SELECT a.Id as [Account Id],
				ah.FirstName AS [First Name],
				ah.LastName AS [Last Name],
				a.Balance as [Current Balance],
				dbo.ufn_CalculateFutureValue(a.Balance, @Rate, 5) AS [Balance in 5 years]
		FROM dbo.Accounts AS a
		JOIN dbo.AccountHolders AS ah ON a.AccountHolderId = ah.Id
		WHERE a.Id = @AccountId
	END;

USE Diablo

--13. *Cash in User Games Odd Rows--
CREATE FUNCTION ufn_CashInUsersGames(@Game VARCHAR(50))
	RETURNS TABLE
	AS
	RETURN
	SELECT SUM(k.Cash) AS [SumCash]
	FROM(
		SELECT ug.Cash as [Cash],
		ROW_NUMBER() OVER (PARTITION BY g.[Name] ORDER BY ug.[Cash]	DESC) AS [Row]
		FROM dbo.Games AS g
		JOIN dbo.UsersGames AS ug ON g.Id = ug.GameId
		WHERE g.[Name] = @Game) AS k
	WHERE k.[Row] % 2 = 1;

USE Bank

--14. Create Table Logs--
CREATE TABLE [Logs]
(
	[LogId] INT PRIMARY KEY IDENTITY,
	[AccountId] INT,
	[OldSum] DECIMAL (15, 2),
	[NewSum] DECIMAL (15, 2)
);

CREATE TRIGGER tr_UpdateBalance ON dbo.Accounts FOR UPDATE
	AS
	BEGIN
		DECLARE @newSum DECIMAL(15, 2) = (SELECT i.Balance FROM [inserted] AS i)
		DECLARE @oldSum DECIMAL(15, 2) = (SELECT d.Balance FROM [deleted] AS d)
		DECLARE @accountId INT = (SELECT i.Id FROM [inserted] AS i)

		INSERT INTO dbo.[Logs]([AccountId], [OldSum], [NewSum]) VALUES
		(
			@accountId,
			@oldSum,
			@newSum
		)
	END;

--15. Create Table Emails--
CREATE TABLE [NotificationEmails]
(
	[Id] INT PRIMARY KEY IDENTITY NOT NULL,
	[Recipient] INT,
	[Subject] VARCHAR(500),
	[Body] VARCHAR(500)
);

CREATE TRIGGER tr_AddNewEmail ON dbo.[Logs] FOR INSERT
	AS
	BEGIN
		DECLARE @recipient INT = (SELECT i.[AccountId] FROM [INSERTED] AS i)
		DECLARE @oldSum DECIMAL(15, 2) = (SELECT i.[OldSum] FROM [INSERTED] AS i)
		DECLARE @newSum DECIMAL(15, 2) = (SELECT i.[NewSum] FROM [INSERTED] AS i)

		INSERT INTO dbo.NotificationEmails([Recipient], [Subject], [Body]) VALUES
		(
		    @recipient,
		    'Balance change for account: ' + CAST(@recipient AS VARCHAR(15)),
		    'On ' + CAST(GETDATE() AS VARCHAR(50)) + ' your balance was changed from ' +
		    CAST(@oldSum AS VARCHAR(30)) + ' to ' +
		    CAST(@newSum AS VARCHAR(50)) + '.'
		)
	END;

--16. Deposit Money--
CREATE PROCEDURE usp_DepositMoney (@AccountId INT, @MoneyAmount DECIMAL(15, 4))
	AS
	BEGIN
		DECLARE @targetAccountId INT = (SELECT a.Id FROM dbo.Accounts a WHERE a.Id = @AccountId)

		IF(@MoneyAmount < 0 OR @MoneyAmount IS NULL)
		BEGIN
			ROLLBACK
			RAISERROR('Invalid amount of money', 16, 1)
			RETURN
		END

		IF(@targetAccountId IS NULL)
		BEGIN
			ROLLBACK
			RAISERROR('Invalid Id Parameter', 16, 2)
			RETURN
		END

		UPDATE dbo.Accounts
		SET dbo.Accounts.Balance += @MoneyAmount
		WHERE dbo.Accounts.Id = @AccountId
	END;
	
--17. Withdraw Money Procedure--
CREATE PROCEDURE usp_WithdrawMoney (@AccountId INT, @MoneyAmount DECIMAL(15, 4))
	AS
	BEGIN
		DECLARE @targetAccountId INT = (SELECT Id FROM dbo.Accounts AS a WHERE a.Id = @AccountId)

		IF(@targetAccountId IS NULL)
		BEGIN
			ROLLBACK
			RAISERROR('Invalid Id Parameter', 16, 1)
			RETURN
		END

		DECLARE @targetBalance DECIMAL(15, 4) = (SELECT [Balance] FROM dbo.Accounts AS a WHERE a.Id = @targetAccountId)

		IF(@MoneyAmount < 0)
		BEGIN
			ROLLBACK
			RAISERROR('Invalid amount of money', 16, 2)
			RETURN
		END

		IF(@targetBalance - @MoneyAmount < 0)
			BEGIN
			ROLLBACK
			RAISERROR('Invalid amount of money left', 16, 3)
			RETURN
		END

		UPDATE dbo.Accounts
		SET
			[Balance] -= @MoneyAmount
		WHERE Id = @AccountId
	END;

--18. Money Transfer--
CREATE PROCEDURE usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(15, 4))
	AS
	BEGIN
		DECLARE @targetSender INT = (SELECT Id FROM dbo.Accounts AS a WHERE a.Id = @SenderId)
		DECLARE @targetReceiver INT = (SELECT Id FROM dbo.Accounts AS a WHERE a.Id = @ReceiverId)

		IF(@targetReceiver IS NULL OR @targetSender IS NULL)
		BEGIN
			ROLLBACK
			RAISERROR('Invalid Id Parameter', 16, 1)
			RETURN
		END
		
		IF(@Amount < 0)
		BEGIN
			ROLLBACK
			RAISERROR('Invalid amount of money', 16, 2)
			RETURN
		END

		EXEC dbo.usp_WithdrawMoney @targetSender, @Amount
		EXEC dbo.usp_DepositMoney @targetReceiver, @Amount
	END;

USE SoftUni

--21. Employees with Three Projects--
CREATE PROCEDURE usp_AssignProject(@EmoloyeeId INT, @ProjectId INT)
	AS
	BEGIN TRANSACTION
		DECLARE @projects INT = 
		(
		SELECT COUNT(ep.ProjectId)
		FROM dbo.Employees AS e
		JOIN dbo.EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
		WHERE e.EmployeeID = @EmoloyeeId
		)

		IF(@projects >= 3)
		BEGIN
			ROLLBACK
			RAISERROR('The employee has too many projects!', 16, 1)
			RETURN
		END

		INSERT INTO dbo.EmployeesProjects([EmployeeID], [ProjectID]) VALUES
		(
		@EmoloyeeId,
		@ProjectId
		)

	COMMIT;

--22. Delete Employees--
CREATE TABLE Deleted_Employees
(
	[EmployeeId] INT PRIMARY KEY,
	[FirstName] VARCHAR(50),
	[LastName] VARCHAR(50),
	[MiddleName] VARCHAR(50),
	[JobTitle] VARCHAR(50),
	[DepartmentId] INT,
	[Salary] DECIMAL(15, 2)
)

CREATE TRIGGER tr_DeletedEmployees ON dbo.Employees FOR DELETE
	AS
	BEGIN
		INSERT INTO dbo.[Deleted_Employees]([FirstName], [LastName], [MiddleName], [JobTitle], [DepartmentId], [Salary])
	SELECT d.[FirstName], d.[LastName], d.[MiddleName], d.[JobTitle], d.[DepartmentId], d.[Salary]
	FROM [DELETED] AS d
	END;