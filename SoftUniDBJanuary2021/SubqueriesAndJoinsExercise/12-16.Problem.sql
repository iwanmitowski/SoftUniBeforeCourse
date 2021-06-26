SELECT mc.CountryCode, m.MountainRange, p.PeakName, p.Elevation FROM Peaks AS p
JOIN MountainsCountries AS mc ON p.MountainId= mc.MountainId
JOIN Mountains AS m ON mc.MountainId = m.Id
    WHERE mc.CountryCode LIKE 'BG'
    AND p.Elevation > 2835
        ORDER BY p.Elevation DESC

SELECT c.CountryCode, COUNT(c.CountryCode) AS [MountainRanges] FROM Countries AS c
JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	WHERE c.CountryCode IN ('US','RU','BG')
		GROUP BY c.CountryCode

SELECT TOP(5) c.CountryName,r.RiverName FROM Countries AS c
LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
	WHERE c.ContinentCode LIKE 'AF'
		ORDER BY c.CountryName

		
SELECT ContinentCode, CurrencyCode, CurrencyUsage FROM(
SELECT ContinentCode, CurrencyCode,
	COUNT(CurrencyCode) AS CurrencyUsage,
	DENSE_RANK() OVER(PARTITION BY ContinentCode ORDER BY COUNT(CurrencyCode) DESC) AS Ranking  
	FROM Countries
		GROUP BY ContinentCode, CurrencyCode) AS k
			WHERE Ranking = 1 AND CurrencyUsage > 1

SELECT COUNT(*) AS [Count] FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
		WHERE MountainId IS NULL

SELECT TOP(5) CountryName, MAX(p.Elevation) AS [HighestPeakElevation], MAX(r.Length) AS [LongestRiverLength] FROM Countries AS c
	LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
	LEFT JOIN Peaks AS p ON m.Id = p.MountainId
	LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
	LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
		GROUP BY CountryName
			ORDER BY [HighestPeakElevation] DESC, [LongestRiverLength] DESC, CountryName

SELECT TOP(5)
[Country],
ISNULL([Highest Peak Name],'(no highest peak)'),
ISNULL([Highest Peak Elevation],0),
ISNULL(k.MountainRange,'(no mountain)')
FROM
(
SELECT
c.CountryName AS [Country],
p.PeakName AS [Highest Peak Name],
MAX(p.Elevation) AS [Highest Peak Elevation],
m.MountainRange,
DENSE_RANK() OVER (PARTITION BY c.CountryName ORDER BY MAX(p.Elevation) DESC) AS Ranking
FROM
Countries AS c
	LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains AS m ON m.Id = mc.MountainId
	LEFT JOIN Peaks AS p ON m.Id = p.MountainId	
	GROUP BY c.CountryName, p.PeakName, m.MountainRange) AS k
	WHERE Ranking = 1
		ORDER BY [Country], [Highest Peak Name]