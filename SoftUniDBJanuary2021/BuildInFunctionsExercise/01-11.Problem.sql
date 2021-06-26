SELECT FirstName, LastName FROM Employees
    WHERE FirstName LIKE 'SA%'

SELECT FirstName, LastName FROM Employees
    WHERE LastName LIKE '%ei%'

SELECT FirstName FROM Employees
    WHERE (DepartmentID = 3 OR DepartmentID = 10)  
        AND (DATEPART(YEAR, HireDate) >= 1995 OR  DATEPART(YEAR, HireDate) <= 2005)

SELECT FirstName, LastName FROM Employees
    WHERE JobTitle NOT LIKE '%engineer%'

SELECT [Name] FROM Towns
    WHERE LEN([Name]) = 5 OR LEN([Name])=6
        ORDER BY [Name] ASC

SELECT * FROM  Towns
    WHERE LEFT([Name],1) IN ('M','K','B','E')
        ORDER BY [Name] ASC

SELECT * FROM  Towns
    WHERE LEFT([Name],1) NOT IN ('R','B','D')
        ORDER BY [Name] ASC

CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT FirstName, LastName FROM Employees
    WHERE DATEPART(YEAR,HireDate) > 2000

SELECT FirstName, LastName FROM Employees
    WHERE LEN(LastName) = 5

SELECT EmployeeID, FirstName, LastName, Salary,
    DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID)  AS [Rank]
        FROM Employees
            WHERE Salary BETWEEN 10000 AND 50000
                ORDER BY Salary DESC


SELECT * FROM
(
SELECT EmployeeID, FirstName, LastName, Salary,
    DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
        FROM Employees
            WHERE Salary BETWEEN 10000 AND 50000) AS t
    WHERE t.[Rank] = 2
        ORDER BY Salary DESC

