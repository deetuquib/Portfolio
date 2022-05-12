USE world;

--------------------------------------
-- A. Querying tables city and country
--------------------------------------

-- 1.
-- Using INNER JOIN ..ON, write a query that displays the name of cities, the
-- cities' population and cities' continent.
-- Sort the result by continent, then by city population, then by city name.
-- Note that the field called 'name' is present in the two tables, use a table
-- alias to resolve the conflict.
SELECT
    city.Name AS City,
    city.Population,
    country.Continent
FROM
    city
INNER JOIN
    country
    ON city.CountryCode = country.Code
ORDER BY
    country.Continent ASC,
    city.Population ASC,
    city.Name ASC
;

-- 2.
-- Rewrite the previous query using WHERE/FROM.
SELECT
    city.Name AS City,
    city.Population,
    country.Continent
FROM
    city
INNER JOIN
    country
WHERE
    city.CountryCode = country.Code
ORDER BY
    country.Continent ASC,
    city.Population ASC,
    city.Name ASC
;

-- 3.
-- Rewrite the query in question 1 to countries that became independent in 1960.
SELECT
    city.Name AS City,
    city.Population,
    country.Continent,
    country.IndepYear
FROM
    city
INNER JOIN
    country
    ON
        city.CountryCode = country.Code
        AND country.IndepYear = 1960
ORDER BY
    country.Continent ASC,
    city.Population ASC,
    city.Name ASC
;

-- 4.
-- Rewrite the previous query using WHERE/FROM.
SELECT
    city.Name AS City,
    city.Population,
    country.Continent,
    country.IndepYear
FROM
    city
INNER JOIN
    country
WHERE
    city.CountryCode = country.Code
    AND country.IndepYear = 1960
ORDER BY
    country.Continent ASC,
    city.Population ASC,
    city.Name ASC
;

-- 5.
-- Using INNER JOIN ..ON, write a query that displays, for the city of Ottawa,
-- the name of the city and the head of state of its country.
SELECT
    city.Name AS City,
    country.HeadOfState
FROM
    city
INNER JOIN
    country
    ON
        city.CountryCode = country.Code
        AND city.Name = 'Ottawa'
;

-- 6.
-- Using INNER JOIN ..ON, write a query that displays the name of the city, the
-- city population, the continent, and the country population of the city of
-- Toronto.
SELECT
    city.Name AS City,
    city.Population AS CityPopulation,
    country.Continent AS Continent,
    country.Population AS CountryPopulation
FROM
    city
INNER JOIN
    country
    ON
        city.CountryCode = country.Code
        AND city.Name = 'Toronto'
;

----------------------------------------------
-- B. Querying tables city and countrylanguage
----------------------------------------------

-- 1.
-- Using INNER JOIN ..ON, write a query that answers the following question.
-- What languages along with their percentage are spoken in the city of Ottawa?
SELECT
    countrylanguage.Language,
    countrylanguage.Percentage
FROM
    countrylanguage
INNER JOIN
    city
    ON
        city.CountryCode = countrylanguage.CountryCode
        AND city.Name = 'Ottawa'
ORDER BY
    countrylanguage.Percentage DESC,
    countrylanguage.Language ASC
;

-- 2.
-- Using WHERE/FROM, write a query that answers the following question.
-- What official languages along with their percentage are spoken in the city of
-- Ottawa?
SELECT
    countrylanguage.Language,
    countrylanguage.Percentage
FROM
    countrylanguage
INNER JOIN
    city
WHERE
    city.CountryCode = countrylanguage.CountryCode
    AND city.Name = 'Ottawa'
    AND countrylanguage.IsOfficial = 'T'
ORDER BY
    countrylanguage.Percentage DESC,
    countrylanguage.Language ASC
;

-- 3.
-- Using INNER JOIN ..ON, write a query that reports the percentage of people
-- speaking an official language in the city of Ottawa as well as the number of
-- people speaking Polish in the city of Ottawa?
SELECT
    countrylanguage.Language,
    countrylanguage.IsOfficial,
    countrylanguage.Percentage
FROM
    city
INNER JOIN
    countrylanguage
    ON
        city.CountryCode = countrylanguage.CountryCode
        AND city.Name = 'Ottawa'
        AND (
            countrylanguage.IsOfficial = 'T'
            OR countrylanguage.Language = 'Polish'
        )
;

-- 4.
-- Using INNER JOIN ..ON and SUM, write a query that reports the total
-- percentage of people speaking an official language or speaking Italian in the
-- city of Ottawa?
SELECT
    SUM(IF(
        countrylanguage.IsOfficial = 'T',
        countrylanguage.Percentage,
        0)) AS SpeakingOfficialLanguage,
    SUM(IF(
        countrylanguage.Language = 'Italian',
        countrylanguage.Percentage,
        0)) AS SpeakingItalianLanguage
FROM
    city
INNER JOIN
    countrylanguage
    ON
        city.CountryCode = countrylanguage.CountryCode
        AND city.Name = 'Ottawa'
        AND (
            countrylanguage.IsOfficial = 'T'
            OR countrylanguage.Language = 'Italian'
        )
;

-------------------------------------------------------
-- C. Querying tables city, country and countrylanguage
-------------------------------------------------------

-- 1.
-- Using INNER JOIN ..ON the three tables, write a query that displays the name
-- of the city, the city continent, the city head of state, the year of
-- independence and the total number of people who speak Italian in the city of
-- Toronto.
SELECT
    city.Name AS City,
    country.Continent,
    country.HeadOfState,
    country.IndepYear,
    countrylanguage.Percentage AS SpeakingItalianLanguage
FROM
    country
INNER JOIN
    city
    ON
        city.CountryCode = country.Code
        AND city.Name = 'Toronto'
INNER JOIN
    countrylanguage
    ON
        countrylanguage.CountryCode = country.Code
        AND countrylanguage.Language = 'Italian'
;

-- 2.
-- Rewrite the previous query using WHERE/FROM.
SELECT
    city.Name AS City,
    country.Continent,
    country.HeadOfState,
    country.IndepYear,
    countrylanguage.Percentage AS SpeakingItalianLanguage
FROM
    country
INNER JOIN
    city
INNER JOIN
    countrylanguage
WHERE
    city.CountryCode = country.Code
    AND countrylanguage.CountryCode = country.Code
    AND city.Name = 'Toronto'
    AND countrylanguage.Language = 'Italian'
;

-- 3.
-- Using LEFT JOIN ..ON the three tables, write a query that displays the city
-- continent, the country the city is in, the city name and the language spoken
-- in that city.
SELECT
    country.Continent,
    country.Name AS Country,
    city.Name AS City,
    countrylanguage.Language
FROM
    city
LEFT JOIN
    country
    ON city.CountryCode = country.Code
LEFT JOIN
    countrylanguage
    ON countrylanguage.CountryCode = country.Code
ORDER BY
    country.Continent ASC,
    country.Name ASC,
    city.Name ASC,
    countrylanguage.Language ASC
;
