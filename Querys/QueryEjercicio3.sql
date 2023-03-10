CREATE TABLE tblViviendas
(
   Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
   CodigoCasa VARCHAR(100) NOT NULL UNIQUE,
   Direccion VARCHAR(100) NOT NULL,
   Ciudad VARCHAR(20) NOT NULL,
   Pais VARCHAR(30) NOT NULL,
   Tipo INT NOT NULL,
   Cantidad INT,
   FechaIngreso DATE NOT NULL
)

SELECT * FROM tblViviendas

CREATE PROCEDURE insertViviendas

@CodigoCasa VARCHAR(100),
@Direccion VARCHAR(100),
@Ciudad VARCHAR(20),
@Pais VARCHAR(30),
@Tipo INT,
@FechaIngreso DATE

AS
BEGIN
INSERT INTO tblViviendas(CodigoCasa, Direccion, Ciudad, Pais, Tipo, FechaIngreso, Cantidad)
   VALUES (@CodigoCasa, @Direccion, @Ciudad, @Pais, @Tipo, @FechaIngreso)
END


CREATE TABLE tblPersonas
(
  Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
  Nombres VARCHAR(30) NOT NULL,
  Apellidos VARCHAR(30) NOT NULL,
  Sexo VARCHAR(1) NOT NULL,
  Edad INT NOT NULL,
  Estado INT NOT NULL,
  CodigoCasa VARCHAR(100) NOT NULL,
  FechaIngreso DATE NOT NULL
)

ALTER PROCEDURE insertPersonas

@Nombres VARCHAR(30),
@Apellidos VARCHAR(30),
@Sexo VARCHAR(1),
@Edad INT,
@Estado INT,
@CodigoCasa VARCHAR(100),
@FechaIngreso DATE

AS
BEGIN
IF(@CodigoCasa = (SELECT TOP 1 CodigoCasa FROM tblViviendas WHERE CodigoCasa = @CodigoCasa))
  BEGIN
    INSERT  tblpersonas(Nombres, Apellidos,Sexo, Edad, Estado, CodigoCasa, FechaIngreso)
     VALUES (@Nombres, @Apellidos, @Sexo, @Edad, @Estado, @CodigoCasa, @FechaIngreso)
  END
ELSE
   BEGIN
     SELECT 'NO EXISTE VIVIENDA CON EL CODIGO ' + @CodigoCasa
   END
    UPDATE tblViviendas
	 set Cantidad = (SELECT COUNT(*) FROM tblPersonas WHERE CodigoCasa = tblViviendas.CodigoCasa)
END

SELECT * FROM tblPersonas
SELECT * FROM tblViviendas

SELECT * FROM tblRegistroPersonas
