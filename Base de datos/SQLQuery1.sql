CREATE DATABASE GymDb
GO

USE GymDb
GO

CREATE TABLE UserTbl(
UsId INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
UsName VARCHAR(50) NOT NULL,
UsPassword VARCHAR(150) NOT NULL,
UsRange VARCHAR(50) NOT NULL
);
Go

insert into UserTbl (UsName, UsPassword, UsRange) 
VALUES ('Admin', 'c1c224b03cd9bc7b6a86d77f5dace40191766c485cd55dc48caf9ac873335d6f', 'Admin');

select * from UserTbl
DELETE FROM UserTbl WHERE UsId = 1

CREATE TABLE PlansTbl(
PLId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
PLName VARCHAR(50) NOT NULL,   -- Nombre
PLPrice NUMERIC(10,2) NOT NULL, -- Precio con dos decimales
PLTiming DATETIME DEFAULT GETDATE(),
PLDaysCovered INT  --Dias que avarcan
)
GO

CREATE TABLE MemberTbl(
MId INT NOT NULL PRIMARY KEY IDENTITY(1,1),   
MName VARCHAR(50) NOT NULL,     --Nombre
MPhone VARCHAR(50) NOT NULL,    --Telefono
MGen VARCHAR(50) NOT NULL,		--Genero
MAge INT NOT NULL,				--Edad
MTiming	DATETIME DEFAULT GETDATE(),	--Hora o Tiempo
IdUser INT,
FOREIGN KEY (IdUser)  REFERENCES UserTbl(UsId)
)
GO



CREATE TABLE Paytbl (
    pId INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    PPlanId INT,
	PMembermId INT,
    PStatus BIT,
    PStartDate DATETIME DEFAULT GETDATE(),
	PEndData DATETIME,
    PAmount NUMERIC(10,2),
    FOREIGN KEY (PPlanId) REFERENCES PlansTbl(PLId),
    FOREIGN KEY (PMembermId) REFERENCES MemberTbl(MId)
);
GO
select * from UserTbl
