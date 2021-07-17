  SELECT Description,
	     FORMAT(OpenDate, 'dd-MM-yyyy')
    FROM Reports
   WHERE EmployeeId IS NULL
ORDER BY OpenDate ASC,
		 Description ASC

  SELECT r.Description,
		 c.Name AS CategoryName
    FROM Reports AS r
	JOIN Categories AS c ON r.CategoryId = c.Id
ORDER BY r.Description,
		 c.Name

  SELECT TOP 5
		 c.Name,
		 COUNT(*) AS ReportsNumber
    FROM Categories AS c
	JOIN Reports AS r ON r.CategoryId = c.Id
GROUP BY c.Name
ORDER BY ReportsNumber DESC,
		 C.Name
	
  SELECT CONCAT(e.FirstName, ' ', e.LastName) AS FullName,
		 COUNT(e.Id) AS UsersCount
    FROM Employees AS e
	LEFT JOIN Reports AS r ON e.Id = r.EmployeeId
	LEFT JOIN Users AS u ON r.UserId = u.Id
GROUP BY CONCAT(e.FirstName, ' ', e.LastName)
ORDER BY UsersCount DESC,
		 FullName ASC

  SELECT CASE
			  WHEN CONCAT(e.FirstName, ' ', e.LastName) = '' THEN 'None'
			  ELSE CONCAT(e.FirstName, ' ', e.LastName)
		 END AS Employee,
		 CASE
			  WHEN d.Name IS NULL THEN 'None'
			  ELSE d.Name
		 END AS Department,
		 c.Name AS Category,
		 r.Description,
		 FORMAT(r.OpenDate, 'dd.MM.yyyy') AS OpenDate,
		 s.Label AS Status,
		 u.Name AS [User]
    FROM Reports AS r
	LEFT JOIN Categories AS c ON r.CategoryId = c.Id
	LEFT JOIN Status AS s ON r.StatusId = s.Id
	LEFT JOIN Employees AS e ON r.EmployeeId = e.Id
	LEFT JOIN Departments AS d ON d.Id = e.DepartmentId
	LEFT JOIN Users AS u ON r.UserId = u.Id
ORDER BY e.FirstName DESC,
		 e.LastName DESC,
		 Department ASC,
		 Category ASC,
		 Description ASC,
		 OpenDate ASC,
		 Status ASC,
		 User ASC
		 
	

