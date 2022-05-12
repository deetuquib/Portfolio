# Your Name: Diana Jean
# Your course section: 300/301


# Question 1
# Table pf: Write a SQL query that extracts the PFdate, destIP and sourceIP of the machines trying to access destination port  31337.
select PFDate, DestIP, SourceIP from pf where DestPort=31337;

# Question 2:
# Table pf: Write a SQL query that extracts the PFdate, destIP and sourceIP of the machines trying to access destination port  6699 or port 137 or port 53. Execute your query then save it in the text file called lab5.txt .
select PFDate, DestIP, SourceIP, DestPort from pf where DestPort=6699 or (DestPort=137) or (DestPort=53);

# Question 3
# Table pf: Rewrite Question 2 using one SELECT statement only and the IN operator.
select PFDate, DestIP, SourceIP, DestPort from pf where DestPort in (6699, 137, 53);

# Question 4
# Table pf: Write a query that lists all unique/distinct SourceIP.
select unique SourceIP FROM pf;
select distinct SourceIP FROM pf;

# Question 5
# Table pf: Write a SQL query that extracts the number of times DestPort 139 was accessed.
select count(*) from pf where DestPort=139;


# Question 6
# Table pf: Write a SQL query that extracts the number of TCP (protocol field) entries.
select count(*) Protocol from pf where Protocol='tcp';

# Question 7
# Table pf: Write a SQL query that extracts the number of UDP (protocol field) entries .
select count(*) Protocol from pf where Protocol='udp';


# Questions 8
# Table pf: Write a SQL query that displays a listing of all distinct sourceIP starting with '24.' .
select distinct SourceIP from pf where SourceIP like '24.%';

