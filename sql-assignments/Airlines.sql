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





