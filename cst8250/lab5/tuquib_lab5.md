```
NAME: DIANA JEAN C. TUQUIB
LAB: 5
```



1. Write a query that displays all that is known about Canadian cities.

   ```mysql
   SELECT id,
          name AS 'city_name',
          countrycode,
          district,
          population
   FROM city
   WHERE countrycode = 'CAN'
   ORDER BY city_name;
   ```

   

2. Create a view vw_Canadian_cities based on the above query. 

   ```mysql
   CREATE VIEW vw_Canadian_cities AS
       SELECT ID,
              name AS 'city_name',
              countrycode,
              district,
              population
       FROM city
       WHERE CountryCode = 'CAN'
       ORDER BY city_name;
   ```

   

3. In the top left panel of MySQL Workbench, expand the View menu item of the world database. In the menu bar, click on Query then Refresh to refresh the view and verify that the view vw_Canadian_cities is now listed.

   ![vw_canadian_cities](C:\Users\deetu\My Files\Projects\github.com\deetuquib\wdia-notes\2022w\cst8250_database_design_and_administration\lab5\vw_canadian_cities.jpg)

   

4. Using the view from step 2, write a query that displays all that is known about Ottawa.

   ```mysql
   SELECT city_name,
          countrycode,
          district,
          population
   FROM vw_canadian_cities
   WHERE city_name = 'ottawa';
   ```

   

5. Write an update query on the view from step 2 to update the population of Ottawa to 883391.

   ```mysql
   UPDATE vw_canadian_cities
   SET population = '883391'
   WHERE city_name = 'ottawa';
   ```

   

6. Rerun the query from Step 4. Is the Population updated?

   ```
   Yes
   ```

   ![6_yes_population_updated](C:\Users\deetu\My Files\Projects\github.com\deetuquib\wdia-notes\2022w\cst8250_database_design_and_administration\lab5\6_yes_population_updated.jpg)

   

7. Create a view called vw_L5 that displays country codes, city names, country names and independence year of every country whose IndepYear field is not null. Rename the country name field "CountryName". (CREATE VIEW, INNER JOIN..ON, tables name and country). In the top left panel of MySQL Workbench, expand the View menu item of the world database. In the menu bar, click on Query then Refresh to refresh the view and verify that the view vw_L5 is now listed.

   ```mysql
   CREATE VIEW vw_l5 AS
       SELECT country.code,
              city.name AS city_name,
              country.name AS country_name,
              country.indepyear
       FROM city
       INNER JOIN country
       ON city.CountryCode = country.code
           WHERE IndepYear IS NOT NULL;
   ```

   <screenshot here>

8. Using the view vw_L5, write a query that lists all distinct CountryNames.

   ```mysql
   SELECT DISTINCT country_name
   FROM vw_l5;
   ```

   

9. Create a view vw_L5_1 based on the above query. 

   ```mysql
   CREATE VIEW vw_l5_1 AS
       SELECT DISTINCT country_name
       FROM vw_l5;
   ```

   

10. Using view vw_L5, write a query that reports the number of countries that became independent per year. Rename the number of countries as nCount (GROUP BY)

    ```mysql
    SELECT
        indepyear,
        COUNT(DISTINCT (country_name)) AS nCount
    FROM
        vw_l5
    GROUP BY indepyear;
    ```

    

11. Create a view vw_L5_2 based on the above query. 

    ```mysql
    CREATE VIEW vw_l5_2 AS
        SELECT indepyear,
               COUNT(DISTINCT (country_name)) AS 'nCount'
        FROM vw_l5
        GROUP BY indepyear;
    ```
    
    
    
12. Write an update query that updates the view vw_L5_2 and sets nCount to 21 for Indepyear 1066. Is the query succesful? Why or why not?

    ```mysql
    UPDATE vw_l5_2
    SET nCount = '21'
    WHERE indepyear = '1066';
    
    ## unsuccessful, target table is not updatable. We can only edit records, not results.
    ```

    

13. Joining vw_L5 and CountryLanguage, write a query that lists the countryName along with the languages spoken in each country and their respective percentages. Sort the list by CountryName then by language. Make sure each record occurs only once.

    ```mysql
    SELECT vw_l5.country_name,
           countrylanguage.language,
           countrylanguage.percentage
    FROM vw_l5
    INNER JOIN countrylanguage
        ON vw_l5.code = countrylanguage.CountryCode
    ORDER BY vw_l5.country_name,
             countrylanguage.Language;
    ```

    

14. Drop the view vw_L5;

    ```mysql
    DROP VIEW vw_L5;
    ```

    

15. Drop the view vw_L5_1;

    ```mysql
    DROP VIEW vw_L5_1;
    ```

    

16. Drop the view vw_L5_2;

    ```mysql
    DROP VIEW vw_L5_2;
    ```

    

17. Drop the view vw_Canadian_cities;

    ```mysql
    DROP VIEW vw_Canadian_cities;
    ```

    



