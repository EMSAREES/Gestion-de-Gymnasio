CREATE DATABASE GymDb
GO

USE GymDb
GO

CREATE TABLE UserTbl(
UsId INT NOT NULL PRIMARY KEY IDENTITY, 
UsName VARCHAR(50) NOT NULL,
UsPassword VARCHAR(150) NOT NULL,
UsRange VARCHAR(50) NOT NULL
);
Go

insert into UserTbl (UsName, UsPassword, UsRange) 
VALUES ('Admin', 'c1c224b03cd9bc7b6a86d77f5dace40191766c485cd55dc48caf9ac873335d6f', 'Admin');

select * from UserTbl
DELETE FROM UserTbl WHERE UsId = 1

CREATE TABLE MemberTbl(
MId INT NOT NULL PRIMARY KEY IDENTITY,   
MName VARCHAR(50) NOT NULL,     --Nombre
MPhone VARCHAR(50) NOT NULL,    --Telefono
MGen VARCHAR(50) NOT NULL,		--Genero
MAge INT NOT NULL,				--Edad
MAmount INT NOT NULL,           --Cantidad
MTiming	VARCHAR(50) NOT NULL,	--Hora o Tiempo
IdUser INT FOREIGN KEY REFERENCES UserTbl(UsId)
)
GO

CREATE TABLE PaymentTbl(
PId INT NOT NULL PRIMARY KEY IDENTITY,   
PMonth VARCHAR(50) NOT NULL,        --Mes
IdMember INT FOREIGN KEY REFERENCES MemberTbl(MId),
PAmount INT NOT NULL				--Cantidad
)
GO

