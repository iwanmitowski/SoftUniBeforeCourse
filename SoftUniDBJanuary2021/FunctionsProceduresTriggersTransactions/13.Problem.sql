  CREATE 
FUNCTION ufn_CashInUsersGames (@GameName NVARCHAR(50))
 RETURNS TABLE
	  AS
	  RETURN
	  SELECT SUM(r.Cash) AS SumCash
		FROM (SELECT ug.Cash AS Cash,
					 ROW_NUMBER() OVER(PARTITION BY @GameName ORDER BY ug.Cash DESC) AS RowNum
			    FROM UsersGames AS ug
			    JOIN Games AS g
				  ON ug.GameId = g.Id
			   WHERE g.Name = @GameName) as r
	   WHERE r.RowNum % 2 != 0
