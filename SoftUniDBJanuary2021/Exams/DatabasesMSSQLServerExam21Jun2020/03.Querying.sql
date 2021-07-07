  SELECT a.FirstName,
  	     a.LastName,
  	     FORMAT(a.BirthDate,'MM-dd-yyyy'),
  	     c.[Name],
  	     a.Email
    FROM Accounts as a
    JOIN Cities AS c
      ON a.CityId = c.Id
   WHERE Email LIKE 'e%'
ORDER BY c.Name

SELECT c.[Name] AS City,
	   Count(*) AS Hotels
  FROM Cities AS c
  JOIN Hotels AS h 
    ON c.Id = h.CityId
GROUP BY c.[Name]
ORDER BY Hotels DESC,
		 City
		 
  SELECT AccountId,
  	     FirstName + ' '+ LastName AS FullName,
  	     MAX(DATEDIFF(DAY, ArrivalDate, ReturnDate)) AS LongestTrip,
  	     MIN(DATEDIFF(DAY, ArrivalDate, ReturnDate)) AS ShortestTrip
    FROM AccountsTrips AS atr
    JOIN Accounts AS a
      ON atr.AccountId = a.Id 
    JOIN Trips AS t
      ON atr.TripId = t.Id
   WHERE a.MiddleName IS NOT NULL 
  	     AND
  	     t.CancelDate IS NULL
GROUP BY AccountId,
		 FirstName,
		 LastName
ORDER BY LongestTrip DESC,
		 ShortestTrip

 SELECT TOP(10)
	    c.Id,
		c.[Name],
	    c.CountryCode,
	    COUNT(*) AS Accounts
    FROM Accounts AS a
    JOIN Cities AS c
      ON a.CityId = c.Id
GROUP BY c.Id,
		 c.[Name],
		 c.CountryCode
ORDER BY Accounts DESC

	  SELECT a.Id,
			 a.Email,
			 ac.[Name] AS City,
			 COUNT(*) AS Trips
		FROM AccountsTrips AS atr
		JOIN Accounts AS a ON atr.AccountId = a.Id
		JOIN Cities AS ac ON a.CityId = ac.Id
		JOIN Trips AS t ON atr.TripId = t.Id
		JOIN Rooms AS r ON t.RoomId = r.Id
		JOIN Hotels AS h ON r.HotelId = h.Id
		JOIN Cities AS hc ON h.CityId = hc.Id
	   WHERE ac.Id = hc.Id
	GROUP BY a.Id,
			 a.Email,
			 ac.[Name]
	ORDER BY Trips DESC,
			 a.Id

 SELECT t.Id,
		a.FirstName + ' ' + ISNULL(a.MiddleName + ' ','') + a.LastName AS [Full Name],
		ac.Name AS [From],
		hc.Name AS [To],
		CASE
			WHEN t.CancelDate IS NOT NULL THEN 'Canceled'
			ELSE CONVERT(VARCHAR, DATEDIFF(DAY, ArrivalDate, ReturnDate))  + ' days'
		 END AS Duration
   FROM AccountsTrips AS act
   JOIN Accounts AS a ON act.AccountId= a.Id
   JOIN Cities AS ac ON a.CityId = ac.Id
   JOIN Trips AS t ON act.TripId = t.Id
   JOIN Rooms AS r ON t.RoomId= r.Id
   JOIN Hotels AS h ON r.HotelId = h.Id
   JOIN Cities AS hc ON h.CityId = hc.Id
ORDER BY [Full Name],
		 t.Id
