  SELECT Id, 
 		 FORMAT(JourneyStart, 'dd/MM/yyyy'),
 		 FORMAT(JourneyEnd, 'dd/MM/yyyy')
    FROM Journeys
   WHERE Purpose LIKE 'Military'
ORDER BY JourneyStart 

   SELECT c.Id, 
  		  c.FirstName + ' ' + c.LastName AS [full_name] 
     FROM Colonists AS c
LEFT JOIN TravelCards AS t 
		 ON c.Id = t.ColonistId
    WHERE t.JobDuringJourney  LIKE 'Pilot'
 ORDER BY c.Id

  SELECT COUNT(*) AS [count]
    FROM TravelCards  AS tc
    JOIN Colonists AS c
 		 ON tc.ColonistId = c.Id
    JOIN Journeys AS j
		 ON tc.JourneyId = j.Id
GROUP BY j.Purpose
  HAVING j.Purpose LIKE 'Technical'

  SELECT s.[Name],
		 s.Manufacturer
    FROM TravelCards  AS tc
    JOIN Colonists AS c
 		 ON tc.ColonistId = c.Id
    JOIN Journeys AS j
		 ON tc.JourneyId = j.Id
	JOIN Spaceships AS s
		 ON j.SpaceshipId = s.Id
   WHERE DATEDIFF(YEAR, c.BirthDate, '01/01/2019') < 30
     AND tc.JobDuringJourney LIKE 'Pilot'
ORDER BY s.[Name]

  SELECT p.Name,
	     COUNT(*) AS JourneysCount
    FROM Journeys AS j
    JOIN Spaceports AS ds
		 ON j.DestinationSpaceportId = ds.Id
	JOIN Planets AS p
		 ON ds.PlanetId = p.Id
GROUP BY p.Name
ORDER BY JourneysCount DESC,
		 p.Name ASC
	
  SELECT *
    FROM (
  SELECT tc.JobDuringJourney AS JobDuringJourney,
		 c.FirstName + ' ' + c.LastName AS [FullName],
		 DENSE_RANK() OVER (
			 PARTITION BY tc.JobDuringJourney 
			 ORDER BY c.BirthDate) AS [JobRank]
    FROM TravelCards  AS tc
    JOIN Colonists AS c
 		 ON tc.ColonistId = c.Id
    JOIN Journeys AS j
		 ON tc.JourneyId = j.Id) AS r
   WHERE r.JobRank = 2