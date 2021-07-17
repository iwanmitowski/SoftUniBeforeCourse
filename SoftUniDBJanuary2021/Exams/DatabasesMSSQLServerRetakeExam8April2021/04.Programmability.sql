  CREATE 
FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME)
 RETURNS INT
   BEGIN
	     IF(@StartDate IS NULL OR @EndDate IS NULL)
		 RETURN 0

		 RETURN DATEDIFF(HOUR, @StartDate, @EndDate);
     END

	  GO

CREATE
  PROC usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
    AS
 BEGIN
	   DECLARE @EmployeeDepartmentId INT = (
			   SELECT DepartmentId
			     FROM Employees
				WHERE Id = @EmployeeId)

	   DECLARE @ReportDepartmentId INT = (
			   SELECT c.DepartmentId
			     FROM Reports AS r
				 JOIN Categories AS c ON r.CategoryId = c.Id
				WHERE r.Id = @ReportId)

	   IF(@EmployeeDepartmentId != @ReportDepartmentId)
	   THROW 50001, 'Employee doesn''t belong to the appropriate department!', 1;

	   DECLARE @ReportCategoryId INT = (
			   SELECT r.CategoryId
			     FROM Reports AS r
				 WHERE r.Id = @ReportId)
				  
	   UPDATE Reports
	      SET  EmployeeId = @EmployeeId
   END
