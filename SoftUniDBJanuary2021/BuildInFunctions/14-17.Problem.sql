SELECT TOP(50) [Name], Format([Start],'yyyy-MM-dd') AS [Start] FROM Games
    WHERE DATEPART(YEAR,[Start])>=2011 AND DATEPART(YEAR,[Start])<=2012
        ORDER BY [Start], [NAME] ASC

SELECT Username, RIGHT(Email,LEN(EMAIL)-CHARINDEX('@',Email)) AS [Email Provider]  FROM Users
    ORDER BY [Email Provider], Username

SELECT Username, IpAddress FROM Users
    WHERE IpAddress LIKE '___.1%.%.___'
        Order by Username

SELECT [Name],
    CASE
        WHEN DATEPART(HOUR, [Start]) >=0 AND DATEPART(HOUR, [Start]) <12 THEN 'Morning'
        WHEN DATEPART(HOUR, [Start]) >=12 AND DATEPART(HOUR, [Start]) <18 THEN 'Afternoon'
        WHEN DATEPART(HOUR, [Start]) >=18 AND DATEPART(HOUR, [Start]) <24 THEN 'Evening'
    END  AS [Part of the Day],
    CASE
        WHEN Duration <=3 THEN 'Extra Short'
        WHEN Duration > 3 AND Duration <= 6 THEN 'Short'
        WHEN Duration > 6 THEN 'Long'
        WHEN Duration IS NULL THEN 'Extra Long'
    END
    Duration FROM Games
    ORDER BY [Name], Duration


