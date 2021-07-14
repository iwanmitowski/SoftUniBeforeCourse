  SELECT Id,
	     Message,
	     RepositoryId,
	     ContributorId
    FROM Commits
ORDER BY Id,
		 Message,
		 RepositoryId,
		 ContributorId

  SELECT Id,
	     Name,
	     Size
    FROM Files
   WHERE Size > 1000 AND
         Name LIKE '%html%'
ORDER BY Size DESC,
		 Id ASC,
		 Name ASC

  SELECT i.Id,
         CONCAT(u.Username,' : ',i.Title) AS IssueAssignee
    FROM Issues AS i
	JOIN Users AS u ON i.AssigneeId = u.Id 
ORDER BY i.Id DESC,
		 u.Id ASC

  SELECT f2.Id,
		 f2.Name,
		 CONCAT(f2.Size,'KB') AS Size
    FROM Files AS f1
   RIGHT JOIN Files AS f2 ON f1.ParentId = f2.Id
   WHERE f1.ParentId IS NULL
ORDER BY f1.Id,
		 f1.Name,
		 f1.Size DESC

  SELECT TOP 5
		 r.Id,
         r.Name,
		 COUNT(c.Id) AS Count
    FROM Repositories AS r
	JOIN Commits AS c ON c.RepositoryId = r.Id
	JOIN RepositoriesContributors AS rc ON rc.RepositoryId = r.Id
GROUP BY r.Id,
         r.Name
ORDER BY Count DESC,
		 r.Id ASC,
		 r.Name ASC

SELECT u.Username,
       AVG(f.Size) AS Size
  FROM Users AS u
  JOIN Commits AS c ON u.Id = c.ContributorId
  JOIN Files AS f ON f.CommitId = c.Id
GROUP BY u.Username
ORDER BY Size DESC,
		 u.Username ASC
  