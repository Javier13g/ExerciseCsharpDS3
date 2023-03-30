CREATE TABLE Feminicidios
(
    Id INT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    tipoDocumento INT NOT NULL,
    documento VARCHAR(13) NOT NULL,
    Nombres VARCHAR(30) NOT NULL,
    Apellidos VARCHAR(30) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    FechaEvento DATE NOT NULL,
    FechaRegistro DATETIME NOT NULL,
    CantidadHijos INT NOT NULL,
    Nacionalidad VARCHAR(13) NOT NULL,
    LugarHecho VARCHAR(20) NOT NULL,
    DigitadoPor VARCHAR(20) NOT NULL
)
GO
CREATE PROCEDURE RegistrarFeminicidio
    @tipoDocumento INT,
    @documento VARCHAR(13),
    @nombres VARCHAR(30),
    @apellidos VARCHAR(30),
    @fechaNacimiento DATE,
    @fechaEvento DATE,
    @fechaRegistro DATETIME,
    @cantidadHijos INT,
    @nacionalidad VARCHAR(13),
    @lugarHecho VARCHAR(20),
    @digitadoPor VARCHAR(20)
AS
BEGIN
    INSERT INTO Feminicidios (tipoDocumento, documento, Nombres, Apellidos, FechaNacimiento, FechaEvento, FechaRegistro, CantidadHijos, Nacionalidad, LugarHecho, DigitadoPor)
    VALUES (@tipoDocumento, @documento, @nombres, @apellidos, @fechaNacimiento, @fechaEvento, @fechaRegistro, @cantidadHijos, @nacionalidad, @lugarHecho, @digitadoPor)
END

select * from Feminicidios