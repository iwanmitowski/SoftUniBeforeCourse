 DECLARE @UserName VARCHAR(50) = 'Stamat'
 DECLARE @GameName VARCHAR(50) = 'Safflower'
 DECLARE @UserID int = (SELECT Id FROM Users WHERE Username = @UserName)
 DECLARE @GameID int = (SELECT Id FROM Games WHERE Name = @GameName)
 DECLARE @StamatBudget money = (SELECT Cash FROM UsersGames WHERE UserId = @UserID AND GameId = @GameID)
 DECLARE @ItemsTotalPrice money
 DECLARE @UserGameID int = (SELECT Id FROM UsersGames WHERE UserId = @UserID AND GameId = @GameID)

 BEGIN TRANSACTION
	   DECLARE @Price11to12 DECIMAL(15,2) = 
			   (SELECT SUM(Price)
		          FROM Items
		         WHERE (MinLevel BETWEEN 11 AND 12))
	
	   IF(@StamatBudget - @Price11to12 >= 0)
	   BEGIN
			 INSERT 
			   INTO UserGameItems
			 SELECT Id, @UserGameID
			   FROM Items
			  WHERE Id IN (SELECT Id
							FROM Items
						   WHERE MinLevel BETWEEN 11 AND 12)

		     UPDATE UsersGames
			    SET Cash -= @Price11to12
			  WHERE GameId = @GameID 
			    AND UserId = UserId
			  COMMIT
	   END
	   ELSE
	       ROLLBACK;				

BEGIN TRANSACTION
	   DECLARE @Price19to21 DECIMAL(15,2) = 
			   (SELECT SUM(Price)
		          FROM Items
		         WHERE (MinLevel BETWEEN 19 AND 21))
	
	   IF(@StamatBudget - @Price19to21 >= 0)
	   BEGIN
			 INSERT 
			   INTO UserGameItems
			 SELECT Id, @UserGameID
			   FROM Items
			  WHERE Id IN (SELECT Id
							FROM Items
						   WHERE MinLevel BETWEEN 19 AND 21)

		     UPDATE UsersGames
			    SET Cash -= @Price19to21
			  WHERE GameId = @GameID 
			    AND UserId = UserId
			  COMMIT
	   END
	   ELSE
	       ROLLBACK;	

  SELECT [Name] AS [Item Name]
    FROM Items
   WHERE Id IN (
		 SELECT ItemId 
		   FROM UserGameItems
		  WHERE UserGameId = @UserGameID)
ORDER BY [Item Name]