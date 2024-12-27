CREATE TABLE [dbo].[Contactos]
(
	RUT VARCHAR(12) NOT NULL PRIMARY KEY,
	Nombre VARCHAR(50) NOT NULL,
	Edad INT NOT NULL,
	Mail VARCHAR(50) NOT NULL,
)

DROP TABLE [dbo].[Contactos];

INSERT INTO [dbo].[Contactos] (RUT, Nombre, Edad, Mail) 
values ('1234678-2', 'puta ', 38, 'puta@GMAIL.COM');


SELECT NEWID() AS UniqueIdentifier;
SELECT * FROM Contactos;