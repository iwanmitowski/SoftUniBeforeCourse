SELECT * FROM Departments

SELECT [Name] FROM Departments

SELECT FirstName, LastName, Salary FROM Employees

SELECT FirstName, MiddleName, LastName FROM Employees

SELECT [FirstName] + '.' + [LastName] + '@softuni.bg' AS [Full Email Address] FROM Employees

SELECT *  FROM Employees
    WHERE JobTitle = 'Sales Representative'

SELECT FirstName, LastName, JobTitle FROM Employees
    WHERE Salary >= 20000 AND Salary <= 30000

SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS [Full Name] FROM Employees
    WHERE Salary IN (25000,14000,12500,23600)

SELECT FirstName, LastName FROM Employees
    WHERE [ManagerID] IS NULL

SELECT FirstName, LastName, Salary FROM Employees
    WHERE Salary > 50000
    ORDER BY Salary DESC

SELECT TOP(5) FirstName, LastName FROM Employees
    ORDER BY Salary DESC

SELECT FirstName,LastName FROM Employees
    WHERE DepartmentId != 4

SELECT *
    FROM Employees
    ORDER BY 
        Salary DESC,
        FirstName ASC,
        LastName DESC,
        MiddleName ASC
 