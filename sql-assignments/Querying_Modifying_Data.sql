-- 1. Create Database command.

CREATE DATABASE Insurance;

USE Insurance;

-- 2. Create table commands for all the tables with constraints, relationships etc.
CREATE TABLE Policies
(
    PolicyID INT IDENTITY PRIMARY KEY,
    PolicyName VARCHAR(50), 
    PolicyType VARCHAR(50),
    PremiumAmount Decimal(10,2),
    DurationYears INT
)

CREATE TABLE Customers
(
    CustomerID INT IDENTITY PRIMARY KEY,
    FirstName VARCHAR(50),
    LastName VARCHAR(50),
    DateOFBirth DATE, 
    Phone VARCHAR(10),
    Email VARCHAR(50) UNIQUE
)

CREATE TABLE Agents
(
    AgentID INT IDENTITY PRIMARY KEY,
    AgentName VARCHAR(50),
    Phone VARCHAR(20),
    City VARCHAR(50)
)

CREATE TABLE PolicyAssignments
(
    AssignmentID INT IDENTITY PRIMARY KEY,
    CustomerID INT,
    PolicyID INT,
    AgentID INT,
    StartDate DATE,
    EndDate DATE,
    CONSTRAINT FK_Customers FOREIGN KEY(CustomerID)
    REFERENCES Customers(CustomerID),
    CONSTRAINT FK_Policies FOREIGN KEY (PolicyID)
    REFERENCES Policies(PolicyID),
    CONSTRAINT FK_Agents FOREIGN KEY (AgentID)
    REFERENCES Agents(AgentID)
)

CREATE TABLE Claims
(
    ClaimID INT IDENTITY PRIMARY KEY,
    AssignmentID INT,
    ClaimDate DATE,
    ClaimAmount Decimal(10,2),
    ClaimStatus VARCHAR(50),
    CONSTRAINT FK_Assignments FOREIGN KEY(AssignmentID)
    REFERENCES PolicyAssignments(AssignmentID)
)

-- 3. Insert commands for all tables.

INSERT INTO Policies(PolicyName,PolicyType,PremiumAmount,DurationYears)
VALUES
('Aarogya Bharathi','Insurance',2299.50,5),
('Suraksha','Loan',5000.00,2);

INSERT INTO Customers(FirstName,LastName,DateOFBirth,Phone,Email)
VALUES
('Goutham','P','2025-12-12','9160804126','goutham4126@gmail.com'),
('Yogi','P','2025-07-06','9010454788','yogi122@gmail.com');

INSERT INTO Agents(AgentName,Phone,City)
VALUES
('RN verma','9210234526','Hyderabad'),
('Suresh Sharma','9982323436','Mumbai');

INSERT INTO PolicyAssignments(CustomerID,PolicyID,AgentID,StartDate,EndDate)
VALUES
(1,2,1,'2025-06-12','2027-06-11'),
(2,1,2,'2025-12-10','2030-12-09');

INSERT INTO Claims(AssignmentID,ClaimDate,ClaimAmount,ClaimStatus)
VALUES(2,'2028-01-20',234000.00,'Success');



 -- 4.1. View all records Customers table.
 select * from Customers;

-- 4.2.View all records of PolicyAssignment table with CustomerId, PolicyId, StartDate and EndDate columns only.
select CustomerID,PolicyID,StartDate,EndDate from PolicyAssignments;

-- 4.3.Display all policies of Health type.
select * from Policies
where PolicyType='Health';

--4.4.Display policies having premium amount more than 10000 and DurationYears is 1.
select * from Policies
where PremiumAmount>10000 AND DurationYears=1;

--4.5.Display unique city names from where agents belong to.
select DISTINCT(City) from Agents;

--4.6.List policies of type Life, Health, Motor use OR clause.
select * from Policies
where PolicyType='Life' OR PolicyType='Health' OR PolicyType='Motor';

--4.7.List policies of type Life, Health, Motor use IN operator.
select * from Policies
where PolicyType in ('Life','Health','Motor');

--4.8.Display list of customers born after January 1 st , 2001 and before December 31 st , 2020 using >= and <= operators.
select * from Customers
where DateOFBirth>='2001-01-01' AND DateOFBirth<='2020-12-31';

--4.9.Display list of customers born after January 1 st , 2001 and before December 31 st , 2020 using between operator.
select * from Customers
where DateOFBirth BETWEEN '2001-01-01' AND '2020-12-31';

--4.10.Display claims data where claim status is Rejected.
select * from Claims
where ClaimStatus='Rejected';

--4.11.Display records of Agents who stay in a city whose second letter is "a".
select * from Agents
where City LIKE '_a%';

--4.12.Display highest and lowest claimAmount from Claims table.
select MIN(ClaimAmount) as Lowest, MAX(ClaimAmount) as Highest from Claims;

--4.13.Display latest claim record.
select TOP(1) * from Claims
ORDER BY ClaimDate DESC;

--4.14.Increase premium amount to 10% for all health insurance policies.
UPDATE Policies
SET PremiumAmount=PremiumAmount*1.10
where PolicyType='Health';

--4.15.Delete the record of PolicyAssignments whose EndDate is before today's date.
DELETE FROM PolicyAssignments
where EndDate<CONVERT (DATE, SYSDATETIME());

--4.16.Display no of claims rejected.
select count(*) from Claims
where ClaimStatus='Rejected';

--4.17.Display PolicyId, PolicyName, PremiumAmount along with computed fields not in 
-- table à 6% LocalTaxes, PremiumAmountWithTax and MonthlyPremiumAmount considering PremiumAmount is Annual.
select PolicyID,PolicyName,PremiumAmount,PremiumAmount * 0.06 as LocalTaxes,
    PremiumAmount + (PremiumAmount * 0.06) as PremiumAmountWithTax,
    PremiumAmount/12 as MonthlyPremiumAmount
from Policies;


--4.18.Write a command to add Address and City Columns in the Customers table.
ALTER TABLE Customers
ADD Address VARCHAR(50);

ALTER TABLE Customers
ADD City VARCHAR(20);

--4.19.Write a command to add a new column named DevOfId (DevelopmentOfficerId) in an existing Agents table.
ALTER TABLE Agents
ADD DevOfId INT;

--4.20.Write command to make the above DevOfId as a recursive foreign key to AgentId as Parent.
ALTER TABLE Agents
ADD CONSTRAINT FK_Agents_DevOf
FOREIGN KEY(DevOfId)
REFERENCES Agents(AgentID);

--5.1.List all Policies for a CustomerId 5.
select p.PolicyID,p.PolicyName,cus.FirstName from Policies as p
join PolicyAssignments as pa
on p.PolicyID=pa.PolicyID
join Customers as cus 
on cus.CustomerID=pa.CustomerID
where cus.CustomerID=5;

--5.2.View all customers with their policies.
select cus.LastName+'.'+cus.FirstName as Customer,p.PolicyID,p.PolicyName from Policies as p
join PolicyAssignments as pa
on p.PolicyID=pa.PolicyID
join Customers as cus 
on cus.CustomerID=pa.CustomerID;

--5.3.View claims with customer name.
select cus.LastName+'.'+cus.FirstName as Customer,c.ClaimStatus,c.ClaimAmount from Claims as c
join PolicyAssignments as pa
on c.AssignmentID=pa.AssignmentID
join Customers as cus 
on cus.CustomerID=pa.CustomerID;

--5.4.Display FirstName, PolicyName, AgentName, StartDate and EndDate from their respective tables.
select cus.FirstName,pol.PolicyName,a.AgentName,pa.StartDate,pa.EndDate from PolicyAssignments as pa
join Customers as cus 
on cus.CustomerID=pa.CustomerID
join Policies as pol
on pol.PolicyID=pa.PolicyID
join Agents as a
on a.AgentID=pa.AgentID;

--5.5.Display claims report with FirstName, PolicyName, ClaimAmount, ClaimStatus, and ClaimDate from their respective tables.
select cus.FirstName as CustomerName,pol.PolicyName,c.ClaimAmount,c.ClaimStatus,c.ClaimDate from Claims as c
join PolicyAssignments as pa
on c.AssignmentID=pa.AssignmentID
join Customers as cus 
on cus.CustomerID=pa.CustomerID
join Policies as pol
on pol.PolicyID=pa.PolicyID;

--5.6.Display records of Customers with or without Policies.
select c.CustomerID,c.FirstName,p.PolicyName from Customers as c
left join PolicyAssignments as pa
on c.CustomerID=pa.CustomerID
left join Policies as p 
on p.PolicyID=pa.PolicyID;

--5.7.Display all Customers with NO Claims.
select cus.CustomerID,cus.FirstName,cus.LastName from Customers cus
left join PolicyAssignments pa
on cus.CustomerID = pa.CustomerID
left join Claims c
on pa.AssignmentID = c.AssignmentID
where c.ClaimID is NULL;



--5.8.Show CustomerName with Total Claim Amount per Customer.
select cus.FirstName,sum(c.ClaimAmount) as Total_Claim_Amount  from Claims as c
join PolicyAssignments as pa
on c.AssignmentID=pa.AssignmentID
join Customers as cus 
on cus.CustomerID=pa.CustomerID
group by cus.FirstName;


--5.9.Show names and total claim amount of Customers With Claim Amount>50000 (Use HAVING Clause).
select cus.FirstName,sum(c.ClaimAmount) as Total_Claim_Amount from Claims as c
join PolicyAssignments as pa
on c.AssignmentID=pa.AssignmentID
join Customers as cus 
on cus.CustomerID=pa.CustomerID
group by cus.FirstName
having sum(c.ClaimAmount)>50000;


--5.10.Display list with Agent Wise Policy Count.
select a.AgentID,a.AgentName,COUNT(pa.PolicyID) as Policy_Count from PolicyAssignments as pa
join Agents as a 
on a.AgentID = pa.AgentID
join Policies as pol 
on pol.PolicyID = pa.PolicyID
group by a.AgentID,a.AgentName;

