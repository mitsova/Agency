/*USE [Agency]*/
USE master
GO

CREATE DATABASE Agency
GO

USE Agency
GO

CREATE TABLE Categories (
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
);

INSERT INTO Categories ([Name])
VALUES ('Vehicles')

INSERT INTO Categories ([Name])
VALUES ('Journeys')

INSERT INTO Categories ([Name])
VALUES ('Tickets')

CREATE TABLE VehicleType (
	Id INT PRIMARY KEY IDENTITY,
	[Type] VARCHAR(50) NOT NULL,
);

INSERT INTO VehicleType ([Type]) 
VALUES ('Land')

INSERT INTO VehicleType ([Type]) 
VALUES ('Air')

INSERT INTO VehicleType ([Type]) 
VALUES ('Sea')

CREATE TABLE Vehicles (
	Id INT PRIMARY KEY IDENTITY,
	PassangerCapacity INT NOT NULL,
	PricePerKilometer DECIMAL(10, 2) NOT NULL,
	TypeId INT NOT NULL,
	CategoryId INT NOT NULL,
	CONSTRAINT FK_Vehicles_Categories FOREIGN KEY (CategoryId) REFERENCES Categories(Id),
	CONSTRAINT FK_Vehicles_VehicleType FOREIGN KEY (TypeId) REFERENCES VehicleType(Id)
);

INSERT INTO Vehicles (PassangerCapacity, PricePerKilometer, TypeId, CategoryId)
VALUES (200, 10.5, 2, 1)

INSERT INTO Vehicles (PassangerCapacity, PricePerKilometer, TypeId, CategoryId)
VALUES (150, 8.75, 1, 1)

INSERT INTO Vehicles (PassangerCapacity, PricePerKilometer, TypeId, CategoryId)
VALUES (50, 5.25, 1, 1)

CREATE TABLE Airplanes (
	Id INT PRIMARY KEY IDENTITY,
	VehicleId INT NOT NULL,
	HasFreeFood BIT NOT NULL,
	CONSTRAINT FK_Airplanes_Vehicles FOREIGN KEY (VehicleId) REFERENCES Vehicles(Id) ON DELETE CASCADE
);

INSERT INTO Airplanes (VehicleId, HasFreeFood)
VALUES (1, 1)

CREATE TABLE Trains (
	Id INT PRIMARY KEY IDENTITY,
	VehicleId INT NOT NULL,
	CartsAmount INT NOT NULL,
	CONSTRAINT FK_Trains_Vehicles FOREIGN KEY (VehicleId) REFERENCES Vehicles(Id) ON DELETE CASCADE
);

INSERT INTO Trains (VehicleId, CartsAmount)
VALUES (2, 3)

CREATE TABLE Buses (
	Id INT PRIMARY KEY IDENTITY,
	VehicleId INT NOT NULL,
	CONSTRAINT FK_Buses_Vehicles FOREIGN KEY (VehicleId) REFERENCES Vehicles(Id) ON DELETE CASCADE
);

INSERT INTO Buses (VehicleId)
VALUES (3)

CREATE TABLE Journeys (
	Id INT PRIMARY KEY IDENTITY,
	StartLocation VARCHAR(75) NOT NULL,
	Destination VARCHAR(75) NOT NULL,
	Distance FLOAT NOT NULL,
	TravelCosts DECIMAL(10,2) NOT NULL,
	VehicleId INT,
	CategoryId INT NOT NULL,
	CONSTRAINT FK_Journeys_Categories FOREIGN KEY (CategoryId) REFERENCES Categories(Id),
	CONSTRAINT FK_Journeys_Vehicles FOREIGN KEY (VehicleId) REFERENCES Vehicles(Id)
);

INSERT INTO Journeys (StartLocation, Destination, Distance, TravelCosts, VehicleId, CategoryId)
VALUES ('Ruse', 'Sofia', 360.78, 1894.10, 3, 2)

INSERT INTO Journeys (StartLocation, Destination, Distance, TravelCosts, VehicleId, CategoryId)
VALUES ('Bucharest', 'London', 2007, 21073.50, 1, 2)

INSERT INTO Journeys (StartLocation, Destination, Distance, TravelCosts, VehicleId, CategoryId)
VALUES ('Ruse', 'Varna', 185.33, 1621.64, 2, 2)

CREATE TABLE Tickets (
	Id INT PRIMARY KEY IDENTITY,
	JourneyId INT NOT NULL,
	AdministrativeCosts DECIMAL(10,2) NOT NULL,
	Price DECIMAL(10, 2) NOT NULL,
	CategoryId INT NOT NULL,
	CONSTRAINT FK_Tickets_Categories FOREIGN KEY (CategoryId) REFERENCES  Categories(Id),
	CONSTRAINT FK_Tickets_Journeys FOREIGN KEY (JourneyId) REFERENCES Journeys(Id) ON DELETE CASCADE
);

INSERT INTO Tickets (JourneyId, AdministrativeCosts, Price, CategoryId)
VALUES (1, 5.75, 1899.85, 3)

INSERT INTO Tickets (JourneyId, AdministrativeCosts, Price, CategoryId)
VALUES (1, 5.75, 1899.85, 3)

INSERT INTO Tickets (JourneyId, AdministrativeCosts, Price, CategoryId)
VALUES (1, 5.75, 1899.85, 3)

INSERT INTO Tickets (JourneyId, AdministrativeCosts, Price, CategoryId)
VALUES (1, 5.75, 1899.85, 3)

INSERT INTO Tickets (JourneyId, AdministrativeCosts, Price, CategoryId)
VALUES (1, 5.75, 1899.85, 3)

INSERT INTO Tickets (JourneyId, AdministrativeCosts, Price, CategoryId)
VALUES (2, 15.67, 21089.17, 3)

INSERT INTO Tickets (JourneyId, AdministrativeCosts, Price, CategoryId)
VALUES (2, 15.67, 21089.17, 3)

INSERT INTO Tickets (JourneyId, AdministrativeCosts, Price, CategoryId)
VALUES (2, 15.67, 21089.17, 3)

INSERT INTO Tickets (JourneyId, AdministrativeCosts, Price, CategoryId)
VALUES (2, 15.67, 21089.17, 3)

INSERT INTO Tickets (JourneyId, AdministrativeCosts, Price, CategoryId)
VALUES (2, 15.67, 21089.17, 3)

INSERT INTO Tickets (JourneyId, AdministrativeCosts, Price, CategoryId)
VALUES (2, 15.67, 21089.17, 3)

INSERT INTO Tickets (JourneyId, AdministrativeCosts, Price, CategoryId)
VALUES (2, 15.67, 21089.17, 3)

INSERT INTO Tickets (JourneyId, AdministrativeCosts, Price, CategoryId)
VALUES (3, 4.88, 1626.52, 3)

INSERT INTO Tickets (JourneyId, AdministrativeCosts, Price, CategoryId)
VALUES (3, 4.88, 1626.52, 3)

INSERT INTO Tickets (JourneyId, AdministrativeCosts, Price, CategoryId)
VALUES (3, 4.88, 1626.52, 3)

INSERT INTO Tickets (JourneyId, AdministrativeCosts, Price, CategoryId)
VALUES (3, 4.88, 1626.52, 3)

INSERT INTO Tickets (JourneyId, AdministrativeCosts, Price, CategoryId)
VALUES (3, 4.88, 1626.52, 3)

INSERT INTO Tickets (JourneyId, AdministrativeCosts, Price, CategoryId)
VALUES (3, 4.88, 1626.52, 3)

INSERT INTO Tickets (JourneyId, AdministrativeCosts, Price, CategoryId)
VALUES (3, 4.88, 1626.52, 3)

INSERT INTO Tickets (JourneyId, AdministrativeCosts, Price, CategoryId)
VALUES (3, 4.88, 1626.52, 3)

INSERT INTO Tickets (JourneyId, AdministrativeCosts, Price, CategoryId)
VALUES (3, 4.88, 1626.52, 3)

INSERT INTO Tickets (JourneyId, AdministrativeCosts, Price, CategoryId)
VALUES (3, 4.88, 1626.52, 3)
