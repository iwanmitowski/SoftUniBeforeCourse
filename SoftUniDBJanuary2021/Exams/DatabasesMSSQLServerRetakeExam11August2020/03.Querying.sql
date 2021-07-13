SELECT [Name], Price, Description
  FROM Products
ORDER BY Price DESC,
		 [Name] ASC

  SELECT f.ProductId,
	     f.Rate,
	     f.[Description],
	     f.CustomerId,
	     c.Age,
	     c.Gender
    FROM Feedbacks AS f
    JOIN Customers AS c ON f.CustomerId = c.Id
   WHERE f.Rate < 5
ORDER BY f.ProductId DESC,
		 f.Rate ASC

  SELECT CONCAT(c.FirstName, ' ', c.LastName) AS CustomerName,
	     c.PhoneNumber,
	     c.Gender
    FROM Customers AS c
   WHERE c.Id NOT IN (
		 SELECT f.CustomerId
		   FROM Feedbacks AS f)
ORDER BY c.Id

SELECT FirstName,
	   Age,
	   PhoneNumber
  FROM Customers AS c
  JOIN Countries AS co ON c.CountryId = co.Id
 WHERE (Age >= 21 AND
        FirstName LIKE '%an%') OR
	   (PhoneNumber LIKE '%38') AND
	   co.Name NOT LIKE 'Greece'
ORDER BY FirstName,
		 Age DESC
 
  SELECT d.Name,
	     i.Name,
	     p.Name,
	     AVG(f.Rate) AS AvgRate
    FROM Distributors AS d 
    JOIN Ingredients AS i ON i.DistributorId = d.Id
    JOIN ProductsIngredients AS pin ON pin.IngredientId = i.Id
    JOIN Products AS p on p.Id = pin.ProductId
    JOIN Feedbacks AS f on f.ProductId = p.Id
GROUP BY d.Name,
		 i.Name,
		 p.Name
   HAVING AVG(f.Rate) BETWEEN 5 AND 8
ORDER BY d.Name,
		 i.Name,
		 p.Name

  SELECT r.CountryName,
	     r.DistributorName
    FROM (
  SELECT c.[Name] AS CountryName,
	     d.[Name] AS DistributorName,
	     DENSE_RANK() OVER (PARTITION BY c.Name ORDER BY COUNT(i.id) DESC) as Ranking
    FROM Countries AS c
    JOIN Distributors AS d ON d.CountryId = c.Id
    LEFT JOIN Ingredients AS i ON d.Id = i.DistributorId
GROUP BY c.[Name],
	     d.[Name]) AS r
   WHERE r.Ranking = 1
ORDER BY r.CountryName,
		 r.DistributorName
