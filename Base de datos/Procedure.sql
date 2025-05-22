-----------------------------------------------login---------------------------------------------------------------------------
ALTER PROCEDURE [dbo].[Sp_LoginUsuario]
	@UsName VARCHAR(50) = NULL,
	@UsPassword VARCHAR(150) = NULL,
    @result BIT OUTPUT
AS
BEGIN
    -- Initialize all output variable
    SET @result = 0;

    --Validate if the username and password exist
    IF EXISTS (SELECT 1 FROM UserTbl WHERE UsName = @UsName AND UsPassword = @UsPassword)
    BEGIN
        SET @result = 1; -- Usuario encontrado
    END
END

--run everything together
DECLARE @result BIT; -- We declare the output variable

-- We execute the stored procedure
EXEC Sp_LoginUsuario 
    @UsName = 'Admin', 
    @UsPassword = 'c1c224b03cd9bc7b6a86d77f5dace40191766c485cd55dc48caf9ac873335d6f', 
    @result = @result OUTPUT;

-- We show the result
SELECT @result AS Resultado;



-------------------------------------Usuario-----------------------------------------
ALTER procedure [dbo].[SP_UserTbl] (
@OP tinyint = 0,
@UsId INT = 0, 
@UsName VARCHAR(50) = NULL,
@UsPassword VARCHAR(150) = NULL,
@UsRange VARCHAR(50) = NULL
)

AS
BEGIN
	IF @OP = 1
	BEGIN
		IF NOT EXISTS (SELECT * FROM UserTbl WHERE UsId = @UsId)
		BEGIN
			INSERT INTO UserTbl( UsName, UsPassword, UsRange) 
			VALUES( @UsName, @UsPassword, @UsRange)
		END
		ELSE
		BEGIN
			UPDATE UserTbl SET UsName = @UsName, UsPassword = @UsPassword, UsRange = @UsRange
			WHERE UsId = @UsId
		END
	END
	IF @OP = 2
	BEGIN
		DELETE FROM UserTbl WHERE UsId = @UsId
	END
END



--------------------------Miembro-----------------------------------------------------------------------
ALTER PROCEDURE [dbo].[SP_MemberTbl] (
    @OP TINYINT = 0,
    @MId INT = 0,   
    @MName VARCHAR(50) = NULL,     
    @MPhone VARCHAR(50) = NULL,    
    @MGen VARCHAR(50) = NULL,		
    @MAge INT = 0,				         
    @IdUser INT = 0
)
AS
BEGIN
    IF @OP = 1 -- INSERT or UPDATE
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM MemberTbl WHERE MId = @MId)
        BEGIN
            INSERT INTO MemberTbl (MName, MPhone, MGen, MAge, IdUser)
            VALUES (@MName, @MPhone, @MGen, @MAge, @IdUser)
        END
        ELSE
        BEGIN
            UPDATE MemberTbl
            SET MName = @MName, MPhone = @MPhone, MGen = @MGen,
                MAge = @MAge, IdUser = @IdUser
            WHERE MId = @MId
        END
    END

    ELSE IF @OP = 2 -- DELETE
    BEGIN
        DELETE FROM MemberTbl WHERE MId = @MId
    END

    ELSE IF @OP = 3 -- CONSULTAR SI EXISTE
    BEGIN
        SELECT COUNT(*) AS Existe
        FROM MemberTbl
        WHERE MName = @MName AND MPhone = @MPhone
    END
    ELSE IF @OP = 4 -- CONSULTA GENERAL
    BEGIN
        SELECT * FROM MemberTbl
    END
	ELSE IF @OP = 5 -- Búsqueda por palabras clave
    BEGIN
        SELECT * FROM MemberTbl WHERE MName LIKE '%' + @MName + '%';
    END
END



--------------------------Planes-----------------------------------------------------------------------
ALTER PROCEDURE [dbo].[SP_PlansTbl](
@OP TINYINT = 0,
@PLId INT = 0,
@PLName VARCHAR(50) = NULL,
@PLPrice NUMERIC = 0,
@PLDaysCovered INT = 0
)
AS
BEGIN
    IF @OP = 1
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM PlansTbl WHERE PLId = @PLId)
        BEGIN
            INSERT INTO PlansTbl (PLName, PLPrice, PLDaysCovered)
            VALUES (@PLName, @PLPrice, @PLDaysCovered);
        END
        ELSE
        BEGIN
            UPDATE PlansTbl 
            SET PLName = @PLName, PLPrice = @PLPrice, PLDaysCovered = @PLDaysCovered
            WHERE PLId = @PLId;
        END
    END
    ELSE IF @OP = 2
    BEGIN
        DELETE FROM PlansTbl WHERE PLId = @PLId;
    END
	ELSE IF @OP = 3
    BEGIN
        SELECT * FROM PlansTbl;
    END
    --ELSE IF @OP = 4 -- Búsqueda por palabras clave
    --BEGIN
     --   SELECT * FROM PlansTbl WHERE PLName LIKE '%' + @PLName + '%';
   -- END
	ELSE IF @OP = 5
    BEGIN
        SELECT COUNT(*) AS Existe FROM PlansTbl WHERE PLName = @PLName
    END
END


-----------------------------------------------pago---------------------------------------------------------------------------
ALTER procedure [dbo].[SP_Paytbl] (
    @OP TINYINT = 0,
    @PId INT = 0,
    @PPlanId INT = 0,
    @PMembermId INT = 0,
    @PStatus BIT = 1,
    @PEndData DATETIME = NULL,
    @PAmount NUMERIC(10,2) = 0,
    @Keyword VARCHAR(50) = NULL
)
AS
BEGIN
    -- Insertar o actualizar
    IF @OP = 1
    BEGIN
        IF NOT EXISTS (SELECT 1 FROM Paytbl WHERE PId = @PId)
        BEGIN
            INSERT INTO Paytbl (PPlanId, PMembermId, PStatus, PEndData, PAmount)
            VALUES (@PPlanId, @PMembermId, @PStatus, @PEndData, @PAmount)
        END
        ELSE
        BEGIN
            UPDATE Paytbl
            SET PPlanId = @PPlanId,
                PMembermId = @PMembermId,
                PStatus = @PStatus,
                PEndData = @PEndData,
                PAmount = @PAmount
            WHERE PId = @PId
        END
    END

    -- Eliminar
    ELSE IF @OP = 2
    BEGIN
        DELETE FROM Paytbl WHERE PId = @PId
    END

    -- Seleccionar todo
    ELSE IF @OP = 3
    BEGIN
        SELECT * FROM Paytbl
    END

    -- Seleccionar solo los pagos NO realizados
    ELSE IF @OP = 4
    BEGIN
        SELECT 
            P.PId,
            P.PAmount,
            --P.PStatus,
            M.MName,
            PL.PLName,
            P.PStartDate,
            P.PEndData
        FROM Paytbl P
        INNER JOIN MemberTbl M ON P.PMembermId = M.MId
        INNER JOIN PlansTbl PL ON P.PPlanId = PL.PLId
        WHERE P.PStatus = 0
    END

    -- Búsqueda por palabra clave
    ELSE IF @OP = 5
    BEGIN
        SELECT 
            P.PId,
            P.PAmount,
            --P.PStatus,
            M.MName,
            PL.PLName,
            P.PStartDate,
            P.PEndData
        FROM Paytbl P
        INNER JOIN MemberTbl M ON P.PMembermId = M.MId
        INNER JOIN PlansTbl PL ON P.PPlanId = PL.PLId
        WHERE M.MName LIKE '%' + @Keyword + '%'
           OR PL.PLName LIKE '%' + @Keyword + '%'
    END

    -- Seleccionar solo los pagos REALIZADOS (PStatus = 1)
    ELSE IF @OP = 6
    BEGIN
        SELECT 
            P.PId,
            P.PAmount,
           -- P.PStatus,
            M.MName,
            PL.PLName,
            P.PStartDate,
            P.PEndData
        FROM Paytbl P
        INNER JOIN MemberTbl M ON P.PMembermId = M.MId
        INNER JOIN PlansTbl PL ON P.PPlanId = PL.PLId
        WHERE P.PStatus = 1
    END

	ELSE IF @OP = 7
    BEGIN
        SELECT 
            P.PId,
            P.PAmount,
           -- P.PStatus,
            M.MName,
            PL.PLName,
            P.PStartDate,
            P.PEndData
        FROM Paytbl P
        INNER JOIN MemberTbl M ON P.PMembermId = M.MId
        INNER JOIN PlansTbl PL ON P.PPlanId = PL.PLId
    END
END
