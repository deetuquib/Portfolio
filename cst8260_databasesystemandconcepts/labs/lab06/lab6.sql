USE world;

#1 Create a report that displays the Code of a country along with the number of cities of that country. (GROUP BY, COUNT)
SELECT
    CountryCode AS country_code,
    COUNT(*) AS total_cities
FROM
    city
GROUP BY
    country_code
;


#2 Restrict the previous query to the countries with more than 200 cities. (GROUP BY, HAVING)
SELECT
    CountryCode AS country_code,
    COUNT(*) AS total_cities
FROM
    city
GROUP BY
    country_code
    HAVING total_cities > 200
;


#3 Run the next query and explain what happens
# SELECT countrycode,COUNT(*)
# FROM city
# GROUP BY countrycode
# WHERE COUNT(*) > 200
# ;
# ***it does not work:
# WHERE clause should be before GROUP BY.
# COUNT(*) is an aggregate function and returns a singular value. Thus, it cannot be used in a WHERE clause.
# A HAVING clause is like a WHERE clause, but applies only to groups as a whole (that is, to the rows in the result set representing groups), whereas the WHERE clause applies to individual rows


#4 Create a report that displays the Code of a country along with the number of cities of that country and the total population of these cities. (GROUP BY, COUNT,SUM)
SELECT
    CountryCode AS country_code,
    COUNT(*) AS total_cities,
    SUM(Population) AS total_population
FROM
    city
GROUP BY
    country_code
;


#5 Create a report that displays the district, the code of a country along with the number of cities of that district. (GROUP BY on two fields, COUNT)
SELECT
    CountryCode AS country_code,
    District AS district,
    COUNT(*) AS total_cities
FROM
    city
GROUP BY
    country_code,
    district
;


#6 Create a report that displays the the code of a country along with the number of cities of that country, the total population of these cities and the average population (GROUP BY, COUNT, SUM, AVG)
SELECT
    CountryCode AS country_code,
    COUNT(*) AS total_cities,
    SUM(population) AS total_population,
    AVG(population) AS average_population
FROM
    city
GROUP BY
    country_code
;


#7 Create a report that displays the district, the code of a country along with the number of cities of that district, the total population of these cities and the average population.
# Select only the district starting with 'a' (GROUP BY on two fields, COUNT, SUM, AVG, HAVING)
SELECT
    District AS district,
    CountryCode AS country_code,
    SUM(Population) AS total_population,
    AVG(Population) AS average_population,
    COUNT(*) AS total_cities
FROM
    city
GROUP BY
    district,
    country_code
HAVING
    district LIKE 'a%'
;


#8 Restrict the previous query to the districts with more than 10 cities. (HAVING, AND)
SELECT
    District AS district,
    CountryCode AS country_code,
    SUM(population) AS total_population,
    AVG(population) AS average_population,
    COUNT(*) AS total_cities
FROM
    city
GROUP BY
    district,
    country_code
HAVING
    district LIKE 'a%'
    AND COUNT(*) > 10
;


#9 Create a report that displays the number of cities in the table, the total population, the average population, the minimal population value and the maximal population value.
SELECT
    COUNT(*) AS total_cities,
    SUM(Population) AS total_population,
    AVG(Population) AS average_population,
    MIN(Population) AS minimum_population,
    MAX(Population) AS maximum_population
FROM
    city
;
