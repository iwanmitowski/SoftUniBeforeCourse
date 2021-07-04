CREATE 
  PROC usp_GetHoldersFullName
    AS 
 BEGIN
	  SELECT FirstName + ' ' + LastName AS [Full Name]
		FROM AccountHolders
   END

  EXEC usp_GetHoldersFullName

    GO

CREATE
  PROC usp_GetHoldersWithBalanceHigherThan(@Money DECIMAL(15, 2))
    AS
 BEGIN
		  SELECT ah.FirstName,
			     ah.LastName
		    FROM AccountHolders as ah
	   LEFT JOIN Accounts AS a
			  ON ah.Id = a.AccountHolderId
		GROUP BY ah.FirstName,
			     ah.LastName
		  HAVING SUM(a.Balance) > @Money
		ORDER BY FirstName,
				 LastName
   END

	GO

  CREATE
FUNCTION ufn_CalculateFutureValue(@I DECIMAL(15,2),
								  @R FLOAT,
								  @T INT)
 RETURNS DECIMAL(15,4)
  BEGIN
		DECLARE @Result DECIMAL(15,4) = 0;
		SET @Result = @I * POWER(1+@R,@T);
		RETURN @Result
    END
	 
	 GO

CREATE
  PROC usp_CalculateFutureValueForAccount (@AccId INt, @Interest FLOAT)
    AS
 BEGIN
		  SELECT ah.Id AS [Account Id],
				 ah.FirstName AS [First Name],
			     ah.LastName AS [Last Name],
				 a.Balance AS [Current Balance],
				 dbo.ufn_CalculateFutureValue(a.Balance, @Interest, 5) AS [Balance in 5 years]
		    FROM AccountHolders AS ah
	   LEFT JOIN Accounts AS a
			  ON ah.Id = a.AccountHolderId
		   WHERE a.Id = @AccId
   END

    GO

  EXEC dbo.usp_CalculateFutureValueForAccount 1, 0.1

	GO
