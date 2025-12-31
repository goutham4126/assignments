CREATE DATABASE Airlines;

USE Airlines;


CREATE TABLE air_passenger_profile
(
    profile_id VARCHAR(10) PRIMARY KEY,
    password VARCHAR(10),
    first_name VARCHAR(10),
    last_name VARCHAR(10),
    address VARCHAR(100),
    mobile_number VARCHAR(15),
    email_id VARCHAR(30) UNIQUE
);

CREATE TABLE air_flight
(
    flight_id VARCHAR(10) PRIMARY KEY,
    airline_id VARCHAR(10),
    airline_name VARCHAR(20),
    from_location VARCHAR(20),
    to_location VARCHAR(20),
    departure_time TIME,
    arrival_time TIME,
    duration TIME,
    total_seats INT
);

CREATE TABLE air_flight_details
(
    flight_id VARCHAR(10),
    flight_departure_date DATE,
    price DECIMAL(10,2),
    available_seats INT,
    PRIMARY KEY(flight_id,flight_departure_date),
    CONSTRAINT FK_flight_details
    FOREIGN KEY(flight_id)
    REFERENCES air_flight(flight_id)
);


CREATE TABLE air_ticket_info
(
    ticket_id VARCHAR(10) PRIMARY KEY,
    profile_id VARCHAR(10),
    flight_id VARCHAR(10),
    flight_departure_date DATE,
    status VARCHAR(10),
    CONSTRAINT FK_ticket_profile
    FOREIGN KEY(profile_id)
    REFERENCES air_passenger_profile(profile_id),
    CONSTRAINT FK_ticket_flight
    FOREIGN KEY (flight_id,flight_departure_date)
    REFERENCES air_flight_details(flight_id,flight_departure_date)
);

CREATE TABLE air_credit_card_details
(
    card_number BIGINT PRIMARY KEY,
    profile_id VARCHAR(10),
    card_type VARCHAR(10),
    expiration_month INT,
    expiration_year INT,
    CONSTRAINT FK_prof_cc_details
    FOREIGN KEY(profile_id)
    REFERENCES air_passenger_profile(profile_id)
);



INSERT INTO air_passenger_profile 
(profile_id, password, first_name, last_name, address, mobile_number, email_id)
VALUES
('P001', 'pass123', 'Rahul', 'Sharma', 'Bangalore', '9876543210', 'rahul@gmail.com'),
('P002', 'pass456', 'Anita', 'Verma', 'Hyderabad', '9123456780', 'anita@gmail.com');


INSERT INTO air_flight
(flight_id, airline_id, airline_name, from_location, to_location, departure_time, arrival_time, duration, total_seats)
VALUES
('F101', 'A001', 'IndiGo', 'Bangalore', 'Delhi', '06:00:00', '08:30:00', '02:30:00', 180),
('F102', 'A002', 'AirIndia', 'Hyderabad', 'Mumbai', '09:00:00', '10:45:00', '01:45:00', 150),
('F103', 'A003', 'ABC', 'Guwahati', 'Chennai', '06:00:00', '10:00:00', '04:00:00', 130),
('F104', 'A003', 'ABC', 'Hyderabad', 'Bangalore', '09:00:00', '10:45:00', '01:45:00', 150),
('F105', 'A003', 'ABC', 'Hyderabad', 'Bangalore', '10:00:00', '11:45:00', '01:45:00', 150);


INSERT INTO air_flight_details
(flight_id, flight_departure_date, price, available_seats)
VALUES
('F101', '2024-10-01', 5500.00, 120),
('F101', '2024-10-02', 5800.00, 100),
('F102', '2024-10-01', 4500.00, 90),
('F103', '2024-09-01', 5500.00, 120),
('F104', '2024-12-02', 5800.00, 100),
('F103', '2024-09-10', 4500.00, 90),
('F105', '2024-04-21', 6000.00, 90);


INSERT INTO air_ticket_info
(ticket_id, profile_id, flight_id, flight_departure_date, status)
VALUES
('T001', 'P001', 'F101', '2024-10-01', 'BOOKED'),
('T002', 'P002', 'F102', '2024-10-01', 'BOOKED');

INSERT INTO air_credit_card_details
(card_number, profile_id, card_type, expiration_month, expiration_year)
VALUES
(4111111111111111, 'P001', 'VISA', 10, 2026),
(5500000000000004, 'P002', 'MASTERCARD', 8, 2025);


-- 1.

select afd.flight_id,af.from_location,af.to_location,DATENAME(month,afd.flight_departure_date) as month_name,
AVG(afd.price) as Average_Price from air_flight_details as afd
join air_flight as af
on afd.flight_id=af.flight_id
where airline_name='ABC'
group by afd.flight_id,af.from_location,af.to_location,DATENAME(month,afd.flight_departure_date)
order by flight_id,month_name;

-- 2.

select app.profile_id,app.first_name,app.address,COUNT(ati.ticket_id) as No_of_Tickets from air_ticket_info as ati 
join air_passenger_profile as app 
on app.profile_id=ati.profile_id 
join air_flight_details as afd 
on afd.flight_id=ati.flight_id 
join air_flight as af 
on af.flight_id=afd.flight_id
group by app.profile_id,app.first_name,app.address
having COUNT(ati.ticket_id)= (
    select MIN(ticket_count) FROM
    (
        select COUNT(ati.ticket_id) as ticket_count from air_ticket_info as ati 
        join air_passenger_profile as app 
        on app.profile_id=ati.profile_id 
        join air_flight_details as afd 
        on afd.flight_id=ati.flight_id 
        join air_flight as af 
        on af.flight_id=afd.flight_id
        group by app.profile_id
    )
    as min_ticket_count
)
order by app.first_name;

-- 3.

select af.from_location,af.to_location,DATENAME(month,afd.flight_departure_date) as month_name,COUNT(af.flight_id) from air_flight_details as afd
join air_flight as af
on afd.flight_id=af.flight_id
group by af.from_location,af.to_location,DATENAME(month,afd.flight_departure_date)
order by af.from_location,af.to_location,month_name;

-- 4.

select app.profile_id,app.first_name,app.address,COUNT(ati.ticket_id) as No_of_Tickets from air_ticket_info as ati 
join air_passenger_profile as app 
on app.profile_id=ati.profile_id 
join air_flight_details as afd 
on afd.flight_id=ati.flight_id 
join air_flight as af 
on af.flight_id=afd.flight_id
group by app.profile_id,app.first_name,app.address
having COUNT(ati.ticket_id)= (
    select MAX(ticket_count) FROM
    (
        select COUNT(ati.ticket_id) as ticket_count from air_ticket_info as ati 
        join air_passenger_profile as app 
        on app.profile_id=ati.profile_id 
        join air_flight_details as afd 
        on afd.flight_id=ati.flight_id 
        join air_flight as af 
        on af.flight_id=afd.flight_id
        group by app.profile_id
    )
    as max_ticket_count
)
order by app.first_name;

-- 5.

select app.profile_id,app.first_name,app.last_name,af.flight_id,app.address,afd.flight_departure_date,COUNT(ati.ticket_id) as No_of_Tickets from air_ticket_info as ati
join air_flight_details as afd
on ati.flight_id=afd.flight_id and ati.flight_departure_date=afd.flight_departure_date
join air_flight as af 
on ati.flight_id=af.flight_id
join air_passenger_profile as app 
on app.profile_id=ati.profile_id
where af.from_location='Chennai' and af.to_location='Hyderabad'
group by app.profile_id,app.first_name,app.last_name,af.flight_id,app.address,afd.flight_departure_date
order by profile_id,flight_id,flight_departure_date;


-- 6.

select afd.flight_id,af.from_location,af.to_location,afd.price from air_flight_details as afd
join air_flight as af
on afd.flight_id=af.flight_id
where MONTH(afd.flight_departure_date)=9;


-- 7.

select afd.flight_id,af.from_location,af.to_location,AVG(afd.price) as Price from air_flight_details as afd
join air_flight as af
on afd.flight_id=af.flight_id
group by afd.flight_id,af.from_location,af.to_location
order by afd.flight_id,af.from_location,af.to_location;


-- 8.

select app.profile_id,CONCAT(app.first_name,',',app.last_name) as customer_name,app.address from air_ticket_info as ati
join air_flight_details as afd
on ati.flight_id=afd.flight_id and ati.flight_departure_date=afd.flight_departure_date
join air_flight as af 
on ati.flight_id=af.flight_id
join air_passenger_profile as app 
on app.profile_id=ati.profile_id
where af.from_location='Chennai' and af.to_location='Hyderabad';


-- 9.

select app.profile_id,COUNT(ati.ticket_id) from air_ticket_info as ati 
join air_passenger_profile as app 
on ati.profile_id=app.profile_id
group by app.profile_id
order by app.profile_id asc;

-- 10.

select af.flight_id,af.from_location,af.to_location,COUNT(ticket_id) as No_of_Tickets from air_ticket_info as ati 
join air_flight_details as afd 
on ati.flight_id=afd.flight_id and ati.flight_departure_date=afd.flight_departure_date
join air_flight as af 
on afd.flight_id=af.flight_id
where airline_name='ABC'
group by af.flight_id,af.from_location,af.to_location;



