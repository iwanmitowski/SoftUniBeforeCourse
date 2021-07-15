SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic,
	   j.Status,
	   j.IssueDate
  FROM Mechanics AS m
  JOIN Jobs AS j ON j.MechanicId = m.MechanicId
ORDER BY m.MechanicId,
		 j.IssueDate,
		 j.JobId

  SELECT CONCAT(c.FirstName, ' ', c.LastName) AS Client,
         DATEDIFF(DAY, j.IssueDate, '2017-04-24') AS [Days going],
		 j.Status
    FROM Clients AS c
    JOIN Jobs AS j ON j.ClientId = c.ClientId
   WHERE j.FinishDate IS NULL
ORDER BY [Days going] DESC,
		 c.ClientId

  SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic,
         CAST(AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)) AS INT) AS [Average Days]
    FROM Mechanics AS m
    JOIN Jobs AS j ON j.MechanicId = m.MechanicId
GROUP BY m.MechanicId,
		 CONCAT(m.FirstName, ' ', m.LastName)
ORDER BY m.MechanicId

  SELECT CONCAT(m.FirstName, ' ', m.LastName) AS Available
    FROM Mechanics AS m
    LEFT JOIN Jobs AS j ON j.MechanicId = m.MechanicId
   WHERE j.Status = 'Finished' OR j.MechanicId IS NULL
ORDER BY m.MechanicId

  SELECT j.JobId,
		 ISNULL(SUM(p.Price * op.Quantity),0.00) AS Total
    FROM Jobs AS j
	LEFT JOIN Orders AS o ON j.JobId = o.JobId
	LEFT JOIN OrderParts AS op ON o.OrderId = op.OrderId
	LEFT JOIN Parts AS p ON p.PartId = op.PartId
   WHERE j.Status = 'Finished'
GROUP BY j.JobId
ORDER BY Total DESC,
         j.JobId
  
  SELECT p.PartId,
		 p.Description,
		 pn.Quantity AS Required,
		 p.StockQty AS [In Stock],
		 IIF(o.Delivered = 0, op.Quantity, 0) AS Ordered
    FROM Parts AS p
	LEFT JOIN PartsNeeded AS pn ON p.PartId = pn.PartId
	LEFT JOIN Jobs AS j ON j.JobId = pn.JobId
	LEFT JOIN Orders AS o ON o.JobId = j.JobId
	LEFT JOIN OrderParts AS op ON op.OrderId = o.OrderId
   WHERE j.Status != 'Finished'
     AND (p.StockQty + IIF(o.Delivered = 0, op.Quantity, 0)) < pn.Quantity
ORDER BY p.PartId 