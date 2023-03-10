CREATE DATABASE Desarrollo3
GO

USE Desarrollo3
GO

CREATE TABLE tblIncidentes
(
  Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
  Descripcion VARCHAR(100) NOT NULL,
  Localidad VARCHAR(30) NOT NULL,
  Sector VARCHAR(30) NOT NULL,
  Ciudad VARCHAR(30) NOT NULL,
  Direccion VARCHAR(100) NOT NULL,
  Telefono VARCHAR(13) NOT NULL,
  TipoIncidente INT NOT NULL,
  EstadoIncidente BIT NOT NULL,
  FechaIngreso DATETIME NOT NULL
)
GO

CREATE TABLE tblAcciones
(
  Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
  CodigoIncidente INT NOT NULL,
  Descripcion VARCHAR(100) NOT NULL,
  TipoAccion INT NOT NULL,
  FechaIngreso DATETIME NOT NULL,
  Nombres VARCHAR(30) NOT NULL,
  Apellidos VARCHAR(30) NOT NULL,
  EstadoAccion BIT NOT NULL
)

CREATE PROCEDURE insertIncidentes
  @Descripcion VARCHAR(100),
  @Localidad VARCHAR(30),
  @Sector VARCHAR(30),
  @Ciudad VARCHAR(30),
  @Direccion VARCHAR(100),
  @Telefono VARCHAR(13),
  @TipoIncidente INT,
  @EstadoIncidente BIT,
  @FechaIngreso DATETIME

AS
BEGIN
  INSERT INTO tblFeligreses(Nombre, Apellido, TipoDocumento, Documento, FechaNacimiento,
  FechaIngreso, Sexo, Bautizado, EstadoCivil, Confirmacion)
END