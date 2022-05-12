USE flights;

-- 1.
-- Prepare a report where you will show the departure airport, arrival airport,
-- the flight number, the airline, the days it operates, the name of the
-- departure airport as well as the departure country.
-- Sort the result by departure airport code, then by flight number.
SELECT
    F.departure,
    F.arrival,
    F.flightnum,
    F.airline,
    F.day_op,
    AP.name AS departure_airport,
    C.name AS departure_country
FROM
    flights AS F
LEFT JOIN
    airports AS AP
    ON AP.code = F.departure
LEFT JOIN
    countries AS C
    ON C.code = AP.country
ORDER BY
    F.departure ASC,
    F.flightnum ASC
;

-- 2.
-- Prepare a report where you will show the departure airport, arrival airport,
-- the flight number, the airline, the days it operates, the name of the
-- arriving airport as well as the arriving country.
-- Sort the result by departure airport code, then by flight number.
SELECT
    F.departure,
    F.arrival,
    F.flightnum,
    F.airline,
    F.day_op,
    AP.name AS arrival_airport,
    C.name AS arrival_country
FROM
    flights AS F
LEFT JOIN
    airports AS AP
    ON AP.code = F.arrival
LEFT JOIN
    countries AS C
    ON C.code = AP.country
ORDER BY
    F.departure ASC,
    F.flightnum ASC
;

-- 3.
-- Prepare a table/report which will show both the departure airport country and
-- the arrival airport country in the same view.
-- See example.
-- Order the result by departure airport then flight number.
-- This will not work without correct join conditions.
-- HINT: Look at the primary key in the flights table
WITH
    AIRPORT_COUNTRIES AS (
        SELECT
            AP.code AS airport_code,
            C.name AS country
        FROM
            airports AS AP
        LEFT JOIN
            countries AS C
            ON AP.country = C.code
    )
SELECT
    F.departure,
    D.country AS departure_country,
    F.arrival,
    A.country AS arrival_country,
    F.flightnum,
    F.airline,
    F.day_op
FROM
    flights AS F
LEFT JOIN
    AIRPORT_COUNTRIES AS A
    ON F.arrival = A.airport_code
LEFT JOIN
    AIRPORT_COUNTRIES AS D
    ON F.departure = D.airport_code
ORDER BY
    F.departure ASC,
    F.flightnum ASC
;

-- 4.
-- Prepare a report which will show the top aircraft for each airline based on
-- the number of flights serviced.
-- See example.
-- Order the result by airline and then by the total number of flights serviced.
SELECT
    AL.code AS airline,
    AC.name AS aircraft_name,
    COUNT(*) AS total_flights_serviced
FROM
    airlines AS AL
INNER JOIN
    flights AS F
    ON AL.code = F.airline
INNER JOIN
    aircrafts AS AC
    ON F.aircraft = AC.code
GROUP BY
    airline,
    aircraft_name
ORDER BY
    airline ASC,
    total_flights_serviced DESC,
    aircraft_name DESC
;

-- 5.
-- Create a report of the airlines sorted by the most flights per airline in
-- descending order.
-- Make sure to include the airline name.
SELECT
    AL.code AS airline,
    AL.name AS airline_name,
    COUNT(*) AS total_flights_serviced
FROM
    airlines AS AL
INNER JOIN
    flights AS F
    ON AL.code = F.airline
GROUP BY
    airline_name
ORDER BY
    total_flights_serviced DESC
;

-- TODO: Still not the same count.
-- 6.
-- Find which day of the week has the most flights in total, regardless of
-- arrivals or departures.
WITH
    MONDAY AS (
        SELECT
            1 AS Weekday,
            COUNT(*) AS TotalFlights
        FROM
            flights
        WHERE
            day_op LIKE "%1%"
    ),
    TUESDAY AS (
        SELECT
            2 AS Weekday,
            COUNT(*) AS TotalFlights
        FROM
            flights
        WHERE
            day_op LIKE "%2%"
    ),
    WEDNESDAY AS (
        SELECT
            3 AS Weekday,
            COUNT(*) AS TotalFlights
        FROM
            flights
        WHERE
            day_op LIKE "%3%"
    ),
    THURSDAY AS (
        SELECT
            4 AS Weekday,
            COUNT(*) AS TotalFlights
        FROM
            flights
        WHERE
            day_op LIKE "%4%"
    ),
    FRIDAY AS (
        SELECT
            5 AS Weekday,
            COUNT(*) AS TotalFlights
        FROM
            flights
        WHERE
            day_op LIKE "%5%"
    ),
    SATURDAY AS (
        SELECT
            6 AS Weekday,
            COUNT(*) AS TotalFlights
        FROM
            flights
        WHERE
            day_op LIKE "%6%"
    ),
    SUNDAY AS (
        SELECT
            7 AS Weekday,
            COUNT(*) AS TotalFlights
        FROM
            flights
        WHERE
            day_op LIKE "%7%"
    ),
    WEEK AS (
        SELECT * FROM MONDAY
        UNION ALL
        SELECT * FROM TUESDAY
        UNION ALL
        SELECT * FROM WEDNESDAY
        UNION ALL
        SELECT * FROM THURSDAY
        UNION ALL
        SELECT * FROM FRIDAY
        UNION ALL
        SELECT * FROM SATURDAY
        UNION ALL
        SELECT * FROM SUNDAY
    )
SELECT
    Weekday,
    TotalFlights
FROM
    WEEK
ORDER BY
    TotalFlights DESC
;

-- TODO: Still not the same count.
-- 7.
-- Find out which country has the most arriving flights.
SELECT
    C.name AS country,
    COUNT(*) AS total_flights
FROM
    flights AS F
LEFT JOIN
    airports AS AP
    ON F.arrival = AP.code
LEFT JOIN
    countries AS C
    ON AP.country = C.code
GROUP BY
    C.name
ORDER BY
    total_flights DESC
;

-- NOTE: Ghana is in Africa not in America.
-- 8.
-- Create a view which shows the flights departing from North America and
-- arriving in Europe.
WITH
    AIRPORT_COUNTRIES AS (
        SELECT
            AP.code AS airport_code,
            C.name AS country,
            C.continent AS continent
        FROM
            airports AS AP
        LEFT JOIN
            countries AS C
            ON AP.country = C.code
    )
SELECT
    F.departure,
    D.country AS departure_country,
    F.arrival,
    A.country AS arrival_country,
    F.flightnum,
    F.airline,
    F.day_op
FROM
    flights AS F
LEFT JOIN
    AIRPORT_COUNTRIES AS A
    ON F.arrival = A.airport_code
LEFT JOIN
    AIRPORT_COUNTRIES AS D
    ON F.departure = D.airport_code
WHERE
    D.continent = "Africa"
    AND A.continent = "Europe"
ORDER BY
    F.departure ASC,
    F.flightnum ASC
;

-- 9.
-- Return the flight data from flights table where the flight duration is
-- greater than the average flight duration.
-- Also return as a column added to the end of the table, the average flight
-- duration so every row has the duration showing.
SELECT
    departure,
    arrival,
    day_op,
    dep_time,
    carrier,
    airline,
    flightnum,
    duration,
    aircraft,
    (SELECT AVG(duration) FROM flights) AS avg_flight_duration
FROM
    flights
WHERE
    duration > (SELECT AVG(duration) FROM flights)
ORDER BY
    duration ASC
;
