USE world;

# TASK A

#A1 display everything that is know about the city with the ID of 31
select * from city where id=31;

#A2 List the names of all cities in Holland (code of NLD)
select Name from city where CountryCode='NLD';

#A3 List the name and the code off all the cities with a population larger than 20000. Sort the output by Population in descending order
select Name, CountryCode from city where Population >= 20000 order by Population desc;


# TASK B

#B1 List the names, the region, the year of Independence and the population of the countries that became independent in 1975 as well as the countries that became independent before 1991 (exclusively) and whose population is less than 22000000.
select Name, region, IndepYear, POPULATION from country where IndepYear=1975 and (IndepYear<1991 and Population<22000000);

#B2 List the names and the IndepYear of all the countries that became independent between 1960 and 1980 (both exclusively). Sort the output by independence year.
select Name, IndepYear from country where IndepYear>1960 and IndepYear<1980 order by IndepYear;

#B3 List the names and the continent of all the countries that became independent between 1960 and 1980 (both exclusively). Sort the output by independence year.
select Name, Continent from country where IndepYear>1960 and IndepYear<1980 order by IndepYear;

#B4 Using OR, list the names and the continent of all the countries in Europe and North America. Sort the output by continent then by name.
select Name, Continent from country where Continent = 'Europe' or Continent = 'North America' order by Continent and name;

#B5 Using NOT IN, list the names and the continent of all the countries not in Europe nor North America. Sort the output by continent then by name.
select Name, Continent from country where Continent not in ('Europe', 'North America') order by Continent and name;

#B6 List the names and the continent of all the countries whose continent's name contains the string America. Sort the output by continent then by name
select Name, Continent from country where Continent like '%America' order by Continent and name;

#B7 Using LIKE, list the names and the continent of all the countries whose name contains exactly 5 characters. Sort the output by continent then by name. (hint: _)
select Name, Continent from country where name like '_____' order by Continent and name;

#B8 Using LIKE, list the names and the continent of all the countries whose name contains exactly 5 characters and whose third character in the name is a y. Sort the output by continent then by name. (hint: _)
select Name, Continent from country where name like '__y__' order by Continent and name;

#B9 List the names, the continent and the IndepYear of all the countries whose IndepYear field is not defined. Sort the output by continent then by name.
select Name, Continent, IndepYear from country where IndepYear is null order by Continent and Name;

#B10 List the names, the continent and the IndepYear of all the countries whose IndepYear field is defined. Sort the output by continent then by name.
select Name, Continent, IndepYear from country where IndepYear is not null order by Continent and Name;

#B11 Using LIMIT, extract the first 5 records of the previous query.
select Name, Continent, IndepYear from country where IndepYear is not null order by Continent and Name limit 5;

# yayy! :-)


select region, IndepYear from country order by 2, 1;

# Eliminate duplicate
# Distinct - extract only unique records
# The line will be unique
select distinct region, IndepYear from country order by 1, 2;


#compute number of records inside
select count(*) from city where CountryCode = 'afg';

#aggregate
select CountryCode, count(*) from city group by CountryCode;

select CountryCode, count(*) from city where CountryCode having count(*) >= 28;

#country code starting with 'U'
select CountryCode, count(*) from city where CountryCode like 'u%' group by countryCode having count(*)


SELECT CountryCode, count() from city WHERE CountryCode LIKE 'u%' GROUP BY CountryCode HAVING count() >= 28 ORDER BY count(*);


#bad bad bad query
select CountryCode, count(*) from city;

#extracted every distinct countrycode
select distinct CountryCode from city order by CountryCode;

# https://www.geeksforgeeks.org/difference-between-order-by-and-group-by-clause-in-sql/

# list of distinct countrycode , for each country code with number of languages spoken inside this specific countrycode
select countrycode, count(*) from countrylanguage group by countrycode;

# more than 5 languages
select countrycode, count(*) from countrylanguage group by countrycode having count(*) >=5;

# more than 5 languages
select countrycode, count(*) from countrylanguage group by countrycode having count(*) >=5 order by count(*) desc;

select CountryCode, count(*) from countrylanguage where CountryCode like 'c%' group by CountryCode;

# Number table: country
SELECT continent, indepyear, count(*) FROM country WHERE indepyear is not null GROUP BY continent HAVING count(*) > 15 ORDER BY indepyear desc LIMIT 2;


# covered this week
# distinct - extract distinct records - value of the row/line is unique
# group by - one field + 1 aggregate
# order by
# having
# limit


# end of part I
# query on 1 table only


# multiple choice - brightspace lecture class
# lab - database ask questions and provide queries
# convert question into mysql
# when to answer and / or
# if you wnt to order more than . use commma , not and
# open book?
