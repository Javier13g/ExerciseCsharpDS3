USE Desarrollo3;

CREATE TABLE tblRegistroPersonas
(
  Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
  TipoDocumento INT NOT NULL,
  Documento VARCHAR(13) UNIQUE,
  Nombres VARCHAR (25) NOT NULL,
  Apellidos VARCHAR(25) NOT NULL,
  FechaNacimiento VARCHAR(13) NOT NULL,
  FechaIngreso DATETIME NOT NULL,
  Sexo VARCHAR(1) NOT NULL,
  TiempoFelicidad INT
)

ALTER PROCEDURE insertarRegistroPersonass

  @TipoDocumento INT,
  @Documento VARCHAR(13),
  @Nombres VARCHAR (25),
  @Apellidos VARCHAR(25),
  @FechaNacimiento VARCHAR(10),
  @FechaIngreso DATETIME,
  @Sexo VARCHAR(1)

AS
BEGIN
  /*IF(@Documento != (SELECT TOP 1
    Documento
  FROM tblRegistroPersonas
  WHERE Documento = @Documento))*/
    INSERT INTO tblRegistroPersonas
    (TipoDocumento, Documento, Nombres, Apellidos, FechaNacimiento,
    FechaIngreso, Sexo/*, TiempoFelicidad*/)
  VALUES
    (@TipoDocumento, @Documento, @Nombres, @Apellidos, @FechaNacimiento, @FechaIngreso,
      @Sexo /*, @TiempoFelicidad*/)
END

CREATE TABLE tblMomentosFelicidad
(
  Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
  TipoEvento INT NOT NULL,
  Descripcion VARCHAR(MAX) NOT NULL,
  TiempoFelicidad INT NOT NULL,
  TipoDocumento INT NOT NULL,
  Documento VARCHAR(13),
  FechaIngreso DATETIME not null
)

ALTER PROCEDURE insertarMomentos

  @TipoEvento INT,
  @Descripcion VARCHAR(MAX),
  @TiempoFelicidad INT,
  @TipoDocumento INT,
  @Documento VARCHAR(13),
  @FechaIngreso DATETIME

AS
BEGIN
  BEGIN TRANSACTION;
  SAVE TRANSACTION MySavePoint;
  INSERT tblMomentosFelicidad
    (TipoEvento, Descripcion, TiempoFelicidad, TipoDocumento, Documento,FechaIngreso)
  VALUES
    (@TipoEvento, @Descripcion, @TiempoFelicidad, @TipoDocumento, @Documento, @FechaIngreso)
  COMMIT TRANSACTION
END
BEGIN
  UPDATE tblRegistroPersonas
set TiempoFelicidad = (SELECT SUM(TiempoFelicidad)
  FROM tblMomentosFelicidad
  WHERE Documento = tblRegistroPersonas.Documento)
END

No

SELECT *
FROM tblMomentosFelicidad

SELECT *
FROM tblRegistroPersonas