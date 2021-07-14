  CREATE 
FUNCTION udf_AllUserCommits(@username VARCHAR(MAX)) 
 RETURNS INT
   BEGIN
		 DECLARE @Count INT = (
				 SELECT COUNT(*)
				   FROM Commits
				  WHERE ContributorId = ( 
						SELECT Id
						  FROM Users 
						 WHERE Username LIKE @username))

		 RETURN @Count
     END

GO

CREATE
  PROC usp_SearchForFiles(@fileExtension VARCHAR(10))
    AS
 BEGIN
	      SELECT Id,
			     Name,
			     CONCAT(Size,'KB')
	        FROM Files
		   WHERE Name LIKE ('%' + @fileExtension)
		ORDER BY Id ASC,
				 Name ASC,
				 Size DESC
   END
    GO 