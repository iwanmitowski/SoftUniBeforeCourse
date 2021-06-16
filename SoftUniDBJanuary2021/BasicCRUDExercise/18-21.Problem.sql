SELECT DISTINCT JobTitle FROM Employees

SELECT TOP(10) ProjectID, [Name], [Description], StartDate, EndDate FROM Projects
    ORDER BY
    StartDate ASC, 
    [Name]

SELECT TOP(7) FirstName, LastName, HireDate FROM Employees
    ORDER BY
    HireDate DESC

SELECT * FROM Departments

UPDATE Employees
    SET Salary *=1.12
    WHERE DepartmentID IN (1,2,4,11)

SELECT Salary FROM Employees
