-- 2
-- Using a UNION query, create a report that lists the name and the district of
-- the cities in Canada (code CAN) and the Netherlands (code NLD). Note that
-- this query can be written without using a UNION. The purpose of this question
-- is to use UNION. (city table)
(
    SELECT
        Name, District
    FROM
        city
    WHERE
        CountryCode = 'CAN'
)
UNION
(
    SELECT
        Name, District
    FROM
        city
    WHERE
        CountryCode = 'NLD'
)
;


-- 3
-- Using an INNER JOIN..ON, create a report that list the name of cities, the
-- country and the indepyear of all countries whose indepYear field is not null.
-- (city and country tables).
SELECT
    city.Name,
    country.Name,
    country.IndepYear
FROM
    country
INNER JOIN
    city
    ON
        country.Code = city.CountryCode
        AND country.IndepYear IS NOT NULL
;


-- 4
-- Rewrite the previous query using WHERE/FROM.
SELECT
    city.Name,
    country.Name,
    country.IndepYear
FROM
    country
INNER JOIN
    city
WHERE
    AND country.Code = city.CountryCode
    country.IndepYear IS NOT NULL
;


-- 5
-- list the name of the city, the country code, and the population of a city
-- where the city population is less than the average population of all
-- countries in the world
SELECT
    Name,
    CountryCode,
    Population
FROM
    city
WHERE
    Population < (
        SELECT
            AVG(Population)
        FROM
            city
    )
;


-- 6
-- Using INNER JOIN ..ON, write a query that displays, for the city of
-- Toronto, the name of the city and the head of state of its country.
-- (city and country tables)
SELECT
    city.Name,
    country.HeadOfState
FROM
    city
INNER JOIN
    country
    ON
        city.CountryCode = country.Code
        AND city.Name = "Toronto"
;


-- 7
-- Using INNER JOIN ..ON the three tables, write a query that displays the
-- name of the city, the city continent, the city head of state, the year of
-- independance and the percentage of people who speaks English in the city of
-- Toronto. (city, countrylanguage and country tables)
SELECT
    city.Name AS CityName,
    country.Continent,
    country.HeadOfState,
    country.IndepYear,
    countrylanguage.Percentage
FROM
    city
INNER JOIN
    country
    ON city.CountryCode = country.Code
INNER JOIN
    countrylanguage
    ON
        country.Code = countrylanguage.CountryCode
        AND countrylanguage.Language = "English"
        AND city.Name = "Toronto"
;

-- 8
-- Rewrite the previous query using WHERE/FROM.
SELECT
    city.Name AS CityName,
    country.Continent,
    country.HeadOfState,
    country.IndepYear,
    countrylanguage.Percentage
FROM
    city
INNER JOIN
    country
INNER JOIN
    countrylanguage
WHERE
    city.CountryCode = country.Code
    AND country.Code = countrylanguage.CountryCode
    AND countrylanguage.Language = "English"
    AND city.Name = "Toronto"
;


-- 9
-- Using a subquery, list the name of the city, the countrycode and the
-- population of the city with the largest population. (city table)

-- Using subquery:
SELECT
    Name,
    CountryCode,
    Population
FROM
    city
WHERE
    Population = (
        SELECT
            MAX(Population)
        FROM
            city
    )
;

-- Using ORDER BY and LIMIT:
SELECT
    Name,
    CountryCode,
    Population
FROM
    city
ORDER BY
    Population DESC
LIMIT 1
;

-- 10
-- Using a subquery, list the name of the city, the countrycode and the
-- population of all the cities whose population is larger than the average
-- population. (city table)
SELECT
    Name,
    CountryCode,
    Population
FROM
    city
WHERE
    Population > (
        SELECT
            AVG(Population)
        FROM
            city
    )
;

-- 11
-- What is wrong with the following subquery?
-- SELECT name,countrycode,population,avg(population)
-- FROM city
-- WHERE population > (SELECT avg(population) FROM city)

SELECT
    Name,
    CountryCode,
    Population,
    AVG(Population)
FROM
    city
WHERE
    Population > (
        SELECT
            AVG(Population)
        FROM
            city
    )
;

-- AVG() is an aggregate function, and it returns only one row.
-- In this case, the Name, CountryCode, and Population that was returned
-- was the first row's result.

-- 12
-- Replace the first avg(population) with (SELECT AVG(population) from city)
-- What happens? Why?

SELECT
    Name,
    CountryCode,
    Population,
    (SELECT AVG(Population) FROM city) AS AveragePerCity
FROM
    city
WHERE
    Population > (
        SELECT
            AVG(Population)
        FROM
            city
    )
;

-- It first evaluated the `(SELECT AVG(Population) FROM city)` subquery (the
-- result is 350468.2236). Then the result was used as the same value for
-- all rows.

-- 13
-- Using a subquery, list the name of the country, the continent and the life
-- expectancy of all countries whose life expectancy is less than the average
-- life expectancy. (country table)
SELECT
    Name,
    Continent,
    LifeExpectancy
FROM
    country
WHERE
    LifeExpectancy < (
        SELECT
            AVG(LifeExpectancy)
        FROM
            country
    )
;
