  CREATE
FUNCTION udf_GetColonistsCount(@PlanetName VARCHAR (30))
 RETURNS INT
   BEGIN
		RETURN (SELECT COUNT(*)    	 
    FROM TravelCards  AS tc
    JOIN Colonists AS c
 		 ON tc.ColonistId = c.Id
    JOIN Journeys AS j
		 ON tc.JourneyId = j.Id
	JOIN Spaceports AS sp 
		 ON j.DestinationSpaceportId = sp.Id
	JOIN Planets AS p
		 ON sp.PlanetId = p.Id
   WHERE p.Name = @PlanetName)
     END

	  GO

CREATE
  PROC usp_ChangeJourneyPurpose(@JourneyId INT , @NewPurpose VARCHAR(MAX))
	AS
	  	 IF(@JourneyId NOT IN (SELECT j.Id
                               FROM Journeys AS j))
            THROW 50001,'The journey does not exist!', 1
			
		 IF((SELECT j.Purpose
             FROM Journeys AS j
             WHERE j.Id = @JourneyId) = @NewPurpose)
             THROW 50002,'You cannot change the purpose!', 1
			 
	  UPDATE Journeys
	     SET Purpose = @NewPurpose
       WHERE Id = @JourneyId
    GO
  