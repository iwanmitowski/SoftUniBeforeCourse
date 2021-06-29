  SELECT DepartmentID,
		 SUM(Salary) as TotalSalary
    FROM Employees
GROUP BY DepartmentID

  SELECT DepartmentID,
		 MIN(Salary) as MinimumSalary
    FROM Employees
   WHERE DepartmentID IN (2,5,7) AND HireDate > 2000
GROUP BY DepartmentID

  SELECT *
    INTO #NewTable
    FROM Employees
   WHERE Salary > 30000
   
  DELETE 
    FROM #NewTable 
   WHERE ManagerID = 42

  UPDATE #NewTable 
     SET Salary+=5000
   WHERE DepartmentID = 1;  

  SELECT DepartmentID,
		 AVG(Salary)
    FROM #NewTable
GROUP BY DepartmentID

  SELECT DepartmentID,
		 MAX(Salary) as MaxSalary
    FROM Employees
GROUP BY DepartmentID
  HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000 

  SELECT DepartmentID, Result.Salary
	FROM (
  SELECT
		 DepartmentID,
		 Salary,
		 DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) AS [Ranking]
    FROM Employees) AS Result
   WHERE Ranking = 3 
GROUP BY DepartmentID, Result.Salary

  SELECT TOP(10)
		 e.FirstName,
		 e.LastName,
		 e.DepartmentID
    FROM Employees AS e
	JOIN (
  SELECT DepartmentID,
		 AVG(Salary) AS AverageSalary
    FROM Employees
GROUP BY DepartmentID) AS res 
	  ON e.DepartmentID = res.DepartmentID
   WHERE e.Salary > res.AverageSalary
ORDER BY DepartmentID

