USE Desarrollo3

CREATE TABLE tblFeligreses
(
    Id INT IDENTITY(1,1) NOT NULL,
    Nombre VARCHAR(30) NOT NULL,
    Apellido VARCHAR(30) NOT NULL,
    TipoDocumento INT NOT NULL,
    Documento VARCHAR(20) NOT NULL,
    FechaNacimiento VARCHAR(10) NOT NULL,
    FechaIngreso DATETIME NULL,
    Sexo CHAR(1) NOT NULL,
    Bautizado BIT NOT NULL,
    EstadoCivil VARCHAR(8) NOT NULL,
    Confirmacion BIT NOT NULL,
    CantidadComunion INT NULL,
    CantidadCeniza INT NULL,
    CantidadAsistencia INT NULL
)

CREATE PROCEDURE insertFeligreses
    @Nombre VARCHAR(30) NOT NULL,
    @Apellido VARCHAR(30),
    @TipoDocumento INT,
    @Documento VARCHAR(20),
    @FechaNacimiento VARCHAR(10),
    @FechaIngreso DATETIME,
    @Sexo CHAR(1),
    @Bautizado BIT,
    @EstadoCivil VARCHAR(8) ,
    @Confirmacion BIT

AS
BEGIN
  INSERT INTO tblFeligreses(Nombre, Apellido, TipoDocumento, Documento, FechaNacimiento,
  FechaIngreso, Sexo, Bautizado, EstadoCivil, Confirmacion)
END