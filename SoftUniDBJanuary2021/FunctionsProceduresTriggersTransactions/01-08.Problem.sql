CREATE
  PROC usp_GetEmployeesSalaryAbove35000
    AS
 BEGIN
      SELECT FirstName,
			 LastName 
        FROM Employees
       WHERE Salary>35000
   END
   
    GO

CREATE 
  PROC usp_GetEmployeesSalaryAboveNumber(@Number DECIMAL(18,4))
    AS
 BEGIN
      SELECT FirstName,
			 LastName 
        FROM Employees
       WHERE Salary>=@Number
   END

  EXEC usp_GetEmployeesSalaryAboveNumber 48100
  
    GO

CREATE
  PROC usp_GetTownsStartingWith (@Letter VARCHAR(MAX))
    AS
 BEGIN
      SELECT [Name]
        FROM Towns
       WHERE LEFT([Name], LEN(@Letter)) LIKE @Letter
   END

  EXEC usp_GetTownsStartingWith be

	GO

   CREATE
     PROC usp_GetEmployeesFromTown (@TownName VARCHAR(30))
       AS
    BEGIN
		    SELECT FirstName,
				   LastName
		      FROM Employees AS e
		 LEFT JOIN Addresses AS a
		        ON a.AddressID = e.AddressID
		 LEFT JOIN Towns AS t
		 	    ON a.TownID = t.TownID
		 	 WHERE t.Name = @TownName
	  END

	 EXEC usp_GetEmployeesFromTown Sofia
	 	 
	GO

  CREATE 
FUNCTION ufn_GetSalaryLevel(@Salary DECIMAL(18,4))
 RETURNS VARCHAR(30)
      AS
   BEGIN
		DECLARE @SalaryLevel NVARCHAR(10)

	    IF @Salary < 30000
		BEGIN
			   SET @SalaryLevel = 'Low';
		END
		ELSE IF @Salary BETWEEN 30000 AND 50000
		BEGIN
			   SET @SalaryLevel = 'Average'
		END
		ELSE
		BEGIN
		       SET @SalaryLevel = 'High'
		END

		RETURN @SalaryLevel
     END

	 GO

CREATE
  PROC usp_EmployeesBySalaryLevel(@SalaryLevel NVARCHAR(10))
    AS
 BEGIN
	  SELECT FirstName,
			 LastName
		FROM Employees
	   WHERE dbo.ufn_GetSalaryLevel(Salary) = @SalaryLevel
   END

    GO

  CREATE 
FUNCTION ufn_IsWordComprised(@SetOfLetters nVARCHAR(MAX), @Word nVARCHAR(MAX))
 RETURNS BIT
      AS
   BEGIN
	    DECLARE @LetterCount INT = LEN(@Word)
		DECLARE @CurrentLetter CHAR
		DECLARE @Counter INT = 1

		WHILE(@Counter <= @LetterCount)
		BEGIN
			 SET @CurrentLetter = SUBSTRING(@Word, @Counter, 1)

			 IF CHARINDEX(@CurrentLetter, @SetOfLetters) <= 0
			 BEGIN
				  RETURN 0
			 END
			 			 
			 SET @Counter += 1
		END
			 
		RETURN 1
     END
	 	 
	  GO

CREATE
  PROC usp_DeleteEmployeesFromDepartment(@DepartmentId INT)
    AS
 BEGIN
	   ALTER 
	   TABLE Departments
	   ALTER 
	  COLUMN ManagerId INT NULL

	  DELETE  
		FROM EmployeesProjects
	   WHERE EmployeeID IN (
		     SELECT EmployeeID
			   FROM Employees
			  WHERE DepartmentID = @DepartmentId)

	  UPDATE Employees
		 SET ManagerID = NULL
	   WHERE ManagerID IN (
		     SELECT EmployeeID
			   FROM Employees
			  WHERE DepartmentID = @DepartmentId)

	  UPDATE Departments
		 SET ManagerID = NULL
	   WHERE DepartmentID = @DepartmentId
	
	  DELETE 
		FROM Employees
	   WHERE DepartmentID = @DepartmentId

	  DELETE 
		FROM Departments
	   WHERE DepartmentID = @DepartmentId

	  SELECT COUNT(*)
	    FROM Employees
       WHERE DepartmentID = @DepartmentId
   END

	GO
    
