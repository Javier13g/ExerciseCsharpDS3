CREATE DATABASE Desarrollo3

USE Desarrollo3

CREATE TABLE TEMBLOR(
IdTemblor INT PRIMARY KEY IDENTITY(1,1),
Intensidad DECIMAL(3,1),
Localidad VARCHAR(50),
FechaEvento DATE,
FechaRegistro DATE,
Pais VARCHAR(50),
Ciudad VARCHAR(50),
CantidadMuerto INT,
CantidadHeridos INT,
PerdidasFinancieras DECIMAL(10,1),
Tsunami VARCHAR(3) 
)
SELECT * FROM TEMBLOR
