SELECT TOP(5) [EmployeeID], JobTitle, e.AddressID, a.AddressText FROM Employees AS e    
JOIN Addresses AS a ON e.AddressID = a.AddressID
    ORDER BY E.AddressID ASC

SELECT TOP(50) FirstName, LastName, t.Name AS [Town] ,a.AddressText FROM Employees AS e
JOIN Addresses AS a ON e.AddressID = a.AddressID
JOIN Towns AS t ON t.TownID = a.TownID
    ORDER BY FirstName, LastName ASC

SELECT EmployeeID, FirstName, LastName, d.Name AS [DepartmentName] FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
    WHERE d.Name LIKE 'Sales'

SELECT TOP(5) EmployeeID, FirstName, Salary, d.Name AS [DepartmentName] FROM Employees AS e
JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
    WHERE e.Salary > 15000
        ORDER BY d.DepartmentID

SELECT * FROM EmployeesProjects

SELECT TOP(3) E.EmployeeID, e.FirstName FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep ON ep.EmployeeID = e.EmployeeID
LEFT JOIN Projects AS p ON ep.ProjectID = p.ProjectID
    WHERE ep.ProjectID IS NULL
        ORDER BY e.EmployeeID

SELECT FirstName, LastName, HireDate, d.Name AS [DeptName]  FROM Employees AS e
LEFT JOIN Departments AS d ON e.DepartmentID = d.DepartmentID 
        WHERE HireDate > '1999-01-01' AND d.Name IN ('Sales', 'Finance')
            ORDER BY HireDate

SELECT TOP(5) e.EmployeeID, FirstName, p.Name FROM Employees AS e
JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON ep.ProjectID = p.ProjectID
    WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
        ORDER BY e.EmployeeID

SELECT e.EmployeeID, FirstName, 
    CASE
        WHEN p.StartDate>'2005-01-01' THEN NULL
        ELSE p.Name
    END AS ProjectName
FROM Employees AS e
JOIN EmployeesProjects AS ep ON e.EmployeeID = ep.EmployeeID
JOIN Projects AS p ON ep.ProjectID = p.ProjectID
    WHERE e.EmployeeID = 24

SELECT e.EmployeeID,  e.FirstName, e.ManagerID, m.FirstName AS [ManagerName] FROM Employees AS e
JOIN Employees AS m ON e.ManagerID = m.EmployeeID
    WHERE e.ManagerID IN (3,7)
        ORDER BY e.EmployeeID 

SELECT 
    TOP(50)
    e.EmployeeID,
    e.FirstName + ' ' + e.LastName AS [EmployeeName],
    m.FirstName + ' ' + m.LastName AS [ManagerName],
    d.Name AS [DepartmentName]
    FROM Employees AS e
LEFT JOIN Employees AS m ON e.ManagerID = m.EmployeeID
LEFT JOIN Departments AS d ON e.DepartmentID = d.DepartmentID
    ORDER BY e.EmployeeID

SELECT MIN(a.AverageSalary)
FROM
(
    SELECT AVG(Salary) AS AverageSalary
    FROM Employees
    GROUP BY DepartmentID
) AS a
  