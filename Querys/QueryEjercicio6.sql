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
GO

CREATE PROCEDURE insertAcciones
@CodigoIncidente INT,
@Descripcion VARCHAR(100),
@TipoAccion INT,
@FechaIngreso DATETIME,
@Nombres VARCHAR(30),
@Apellidos VARCHAR(30),
@EstadoAccion BIT
AS
BEGIN
IF(@CodigoIncidente = (SELECT TOP 1 Id FROM tblIncidentes WHERE Id = @CodigoIncidente))
BEGIN
  INSERT INTO tblAcciones(CodigoIncidente, Descripcion, TipoAccion, FechaIngreso, Nombres, Apellidos, EstadoAccion)
  VALUES(@CodigoIncidente, @Descripcion, @TipoAccion, @FechaIngreso, @Nombres, @Apellidos, @EstadoAccion)
END
END
GO

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
  INSERT INTO tblIncidentes(Descripcion, Localidad, Sector, Ciudad, Direccion,
  Telefono, TipoIncidente, EstadoIncidente, FechaIngreso)
  VALUES(@Descripcion,
  @Localidad,
  @Sector,
  @Ciudad,
  @Direccion,
  @Telefono,
  @TipoIncidente,
  @EstadoIncidente,
  @FechaIngreso)
END

SELECT * FROM tblIncidentes