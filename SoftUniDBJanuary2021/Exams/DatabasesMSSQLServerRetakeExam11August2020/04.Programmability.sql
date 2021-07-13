CREATE 
  VIEW v_UserWithCountries 
    AS
SELECT CONCAT(c.FirstName,' ',c.LastName) AS CustomerName,
	   c.Age,
	   c.Gender,
	   co.[Name]
FROM Customers AS c
JOIN Countries AS co ON c.CountryId = co.Id

GO

 CREATE 
TRIGGER tr_DeleteProducts
     ON Products
INSTEAD OF DELETE
     AS
  BEGIN

		DECLARE @DeletedProductId INT = (
				SELECT p.Id
				  FROM Products AS p
				  JOIN deleted AS d ON p.Id = d.Id)

		 DELETE
		   FROM Feedbacks
		  WHERE ProductId = @DeletedProductId

		 DELETE
		   FROM ProductsIngredients
		  WHERE ProductId = @DeletedProductId

		 DELETE
		   FROM Products
		  WHERE Id = @DeletedProductId
END
