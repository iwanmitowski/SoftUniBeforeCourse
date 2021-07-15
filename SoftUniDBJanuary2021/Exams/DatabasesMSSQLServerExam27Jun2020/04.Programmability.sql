CREATE
  PROC usp_PlaceOrder(@JobId INT, @SerialNumber VARCHAR(50), @Quantity INT)
    AS
 BEGIN
	   DECLARE @JobStatus VARCHAR(50) = (
			   SELECT Status
			     FROM Jobs
				WHERE JobId = @JobId)

	   IF(@JobStatus = 'Finished')
	   THROW 50011, 'This job is not active!', 1;

	   IF(@Quantity <= 0)
	   THROW 50012, 'Part quantity must be more than zero!', 1;

	   IF(@JobStatus IS NULL)
	   THROW 50013, 'Job not found!', 1;

	   DECLARE @PartId INT = (
			   SELECT PartId
			     FROM Parts
				WHERE SerialNumber = @SerialNumber)

	   IF(@PartId IS NULL)
	   THROW 50014, 'Part not found!', 1; 
	   
	   DECLARE @OrderId INT = (
			   SELECT OrderId
			     FROM Orders
				WHERE JobId = @JobId
			      AND IssueDate IS NULL)

	   DECLARE @OrderPartsQty INT = (
			   SELECT Quantity
			     FROM OrderParts
				WHERE PartId = @PartId AND
					  OrderId = @OrderId)

	   IF (@OrderPartsQty IS NULL)
	   BEGIN
			 INSERT INTO OrderParts(OrderId, PartId, Quantity) VALUES
			 (@OrderId, @PartId, @Quantity)
	   END
	   ELSE
	   BEGIN
			 UPDATE OrderParts
			    SET Quantity += @Quantity
			  WHERE PartId = @PartId
			    AND OrderId = @OrderId
	   END

   END

   GO

  CREATE 
FUNCTION udf_GetCost(@JobId INT)
 RETURNS DECIMAL(15,2)
   BEGIN
		 DECLARE @Sum  DECIMAL(15,2) = (
			     SELECT SUM(p.Price)
				   FROM Parts AS p
				   JOIN OrderParts AS op ON p.PartId = op.PartId
				   JOIN Orders AS o ON o.OrderId = op.OrderId
				   JOIN Jobs AS j on j.JobId = o.JobId
				  WHERE j.JobId = @JobId)

		 IF @Sum IS NULL
		 RETURN 0

	     RETURN @Sum 
     END