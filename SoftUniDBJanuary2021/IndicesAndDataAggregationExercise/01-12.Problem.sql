SELECT *
  FROM WizzardDeposits

  SELECT TOP(1) MAX(MagicWandSize) AS LongestMagicWand
    FROM WizzardDeposits
GROUP BY MagicWandSize
ORDER BY LongestMagicWand DESC

  SELECT DepositGroup,
		 MAX(MagicWandSize) AS LongestMagicWand
    FROM WizzardDeposits
GROUP BY DepositGroup

  SELECT TOP(2) DepositGroup
    FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)

  SELECT DepositGroup,
		 SUM(DepositAmount) AS TotalSum
    FROM WizzardDeposits
GROUP BY DepositGroup

  SELECT DepositGroup,
		 SUM(DepositAmount) AS TotalSum
    FROM WizzardDeposits
   WHERE MagicWandCreator LIKE 'Ollivander family'
GROUP BY DepositGroup

  SELECT DepositGroup,
		 SUM(DepositAmount) AS TotalSum
    FROM WizzardDeposits
   WHERE MagicWandCreator LIKE 'Ollivander family'
GROUP BY DepositGroup
  HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC

  SELECT DepositGroup,
		 MagicWandCreator AS TotalSum,
		 MIN(DepositCharge) AS MinDepositCharge
    FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup

SELECT Age FROM WizzardDeposits
	ORDER BY Age


  SELECT ag.AgeGroup, COUNT(ag.AgeGroup)
	FROM (
  SELECT CASE	
	     	  WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
	     	  WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
	     	  WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
	     	  WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
	     	  WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
	     	  WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
	     	  WHEN Age >= 61 THEN '[61+]'
	      END AS AgeGroup
    FROM WizzardDeposits) AS ag
GROUP BY ag.AgeGroup

  SELECT LEFT(FirstName,1) AS FirstLetter
    FROM WizzardDeposits
   WHERE DepositGroup LIKE 'Troll Chest'
GROUP BY LEFT(FirstName,1)
ORDER BY FirstLetter

  SELECT DepositGroup,
		 IsDepositExpired,
		 AVG(DepositInterest) AS AverageInterest
    FROM WizzardDeposits
   WHERE DepositStartDate >= '1985-01-01'
GROUP BY DepositGroup,
		 IsDepositExpired
ORDER BY DepositGroup DESC,
		 IsDepositExpired ASC

--Вариант 1
  SELECT SUM(Host.DepositAmount - Guest.DepositAmount) AS Difference
    FROM WizzardDeposits AS Host
	JOIN WizzardDeposits AS Guest ON Host.Id + 1 = Guest.Id

--Вариант 2
  SELECT SUM(Result.[Difference])
    FROM (
  SELECT Host.DepositAmount - LEAD(Host.DepositAmount) OVER(ORDER BY Id) AS [Difference]
    FROM WizzardDeposits AS Host) AS Result
	