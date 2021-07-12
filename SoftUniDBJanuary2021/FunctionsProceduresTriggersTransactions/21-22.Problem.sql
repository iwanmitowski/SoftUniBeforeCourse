CREATE 
  PROC usp_AssignProject(@emloyeeId INT, @projectID INT)
    AS
 BEGIN TRANSACTION
	   DECLARE @ProjectsCount INT = (
			   SELECT COUNT(*)
			     FROM EmployeesProjects
				WHERE EmployeeID = @emloyeeId)

	   IF(@ProjectsCount >= 3)
	   BEGIN
			 ROLLBACK;
			 RAISERROR('The employee has too many projects!', 16, 1);
	   END
	   ELSE
	   INSERT
		 INTO EmployeesProjects VALUES
			  (@emloyeeId, @projectID)
COMMIT

GO

EXEC usp_AssignProject 2,1
EXEC usp_AssignProject 2,2
EXEC usp_AssignProject 2,3
BEGIN TRY  
 EXEC usp_AssignProject 2,4
END TRY  
BEGIN CATCH  
   SELECT error_message()
END CATCH;

CREATE TABLE Deleted_Employees
(
	EmployeeId INT PRIMARY KEY,
	FirstName VARCHAR(MAX),
	LastName VARCHAR(MAX),
	MiddleName VARCHAR(MAX),
	JobTitle VARCHAR(MAX),
	DepartmentId INT,
	Salary DECIMAL(15,2)
)

GO

 CREATE
TRIGGER tr_InsertingDeletedEmps
     ON Employees
    FOR DELETE 
     AS
  BEGIN
	    INSERT 
		  INTO Deleted_Employees(
					FirstName,
					LastName, 
					MiddleName,
					JobTitle,
					DepartmentId,
					Salary)
		SELECT 
			   d.FirstName,
			   d.LastName,
			   d.MiddleName,
			   d.JobTitle,
			   d.DepartmentID,
			   d.Salary
		  FROM deleted AS d
    END
