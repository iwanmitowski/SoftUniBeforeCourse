 CREATE TABLE Logs
 (
	Id INT PRIMARY KEY IDENTITY,
	AccountId INT NOT NULL,
	OldSum DECIMAL(15,2) NOT NULL,
	NewSum DECIMAL(15,2) NOT NULL,
 )
 
 GO

 CREATE 
TRIGGER tr_TableLogs
     ON Accounts 
	FOR UPDATE
	 AS
  BEGIN
		DECLARE @accountId INT;
		DECLARE @oldSum DECIMAL(15,2);
		DECLARE @newSum DECIMAL(15,2);

		SET @accountId = (
			SELECT i.Id
			FROM inserted AS i)

		SET @oldSum = (
			SELECT d.Balance
			FROM deleted AS d)

		SET @newSum = (
			SELECT i.Balance
			FROM inserted AS i)

		INSERT INTO Logs(AccountId, OldSum, NewSum) VALUES
		(@accountId, @oldSum, @newSum)
	END

 CREATE TABLE NotificationEmails
 (
	Id INT PRIMARY KEY IDENTITY,
	Recipient INT NOT NULL,
	[Subject] VARCHAR(MAX) NOT NULL,
	Body VARCHAR(MAX) NOT NULL
 )

 GO

 CREATE 
TRIGGER tr_CreateEmail
     ON Logs
    FOR INSERT
	 AS 
  BEGIN
	    DECLARE @recipient INT
	    DECLARE @subject VARCHAR(MAX)
		DECLARE @oldBalance DECIMAL(15,2);
		DECLARE @newBalance DECIMAL(15,2);
	    DECLARE @body VARCHAR(MAX)

		SET @recipient = (SELECT i.AccountId FROM inserted AS i)
		SET @subject = 'Balance change for account: ' + CAST(@recipient AS VARCHAR(MAX))
		SET @oldBalance = (SELECT i.OldSum FROM inserted AS i)
		SET @oldBalance = (SELECT i.NewSum FROM inserted AS i)
		SET @body = 'On ' + CAST(GETDATE() AS VARCHAR(MAX)) +
				    ' your balance was changed from ' + CAST(@oldBalance AS VARCHAR(MAX)) +
					' to ' + CAST(@newBalance AS VARCHAR(MAX))

		INSERT INTO NotificationEmails(Recipient, [Subject], Body) VALUES
		(@recipient, @subject, @body)
	END

	 GO

CREATE
  PROC usp_DepositMoney (@AccountId INT, @MoneyAmount DECIMAL(15,4))
    AS
 BEGIN TRANSACTION Deposit
	   IF(@MoneyAmount < 0 OR @MoneyAmount IS NULL)
	   BEGIN
	         ROLLBACK;
	         THROW 50001, 'Invalid amount of money', 1;
	   END
	   
	   IF NOT EXISTS( SELECT Id
					    FROM Accounts
					   WHERE Id = @AccountId OR @AccountId IS NULL)
	   BEGIN
			 ROLLBACK;
	         THROW 50002, 'Invalid account Id', 1;
	   END

	   UPDATE Accounts
	      SET Balance+=@MoneyAmount
	    WHERE Id = @AccountId
COMMIT

	GO

CREATE
  PROC usp_WithdrawMoney (@AccountId INT , @MoneyAmount DECIMAL(15,4))
    AS
 BEGIN TRANSACTION 
	   IF(@MoneyAmount < 0 OR @MoneyAmount IS NULL)
	   BEGIN
			 ROLLBACK;
			 THROW 50001, 'Invalid amount of money', 1;
	   END

	   IF NOT EXISTS(SELECT Id
					   FROM Accounts
					  WHERE Id = @AccountId OR @AccountId IS NULL)
	   BEGIN
			 ROLLBACK;
			 THROW 50002, 'Invalid account Id', 1;
	   END

	   UPDATE Accounts
		  SET Balance -= @MoneyAmount
		WHERE Id = @AccountId
COMMIT

	GO

CREATE
  PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(15,4))
    AS
 BEGIN TRANSACTION 
	   
	   EXEC usp_WithdrawMoney @SenderId, @Amount
	   EXEC usp_DepositMoney @ReceiverId, @Amount
COMMIT