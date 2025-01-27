-------------------------------------Usuario-----------------------------------------
create procedure SP_UserTbl (
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
create procedure SP_MemberTbl (
@OP tinyint = 0,
@MId INT = 0,   
@MName VARCHAR(50) = NULL,     
@MPhone VARCHAR(50) = NULL,    
@MGen VARCHAR(50) = NULL,		
@MAge INT = 0,				
@MAmount INT = 0,          
@MTiming	VARCHAR(50) = NULL,	
@IdUser INT = 0
)

AS
BEGIN
	IF @OP = 1
	BEGIN
		IF NOT EXISTS (SELECT * FROM MemberTbl WHERE MId = @MId)
		BEGIN
			INSERT INTO MemberTbl(MId, MName, MPhone, MGen, MAge, MAmount, MTiming, IdUser) 
			VALUES(@MId, @MName, @MPhone, @MGen, @MAge, @MAmount, @MTiming, @IdUser)
		END
		ELSE
		BEGIN
			UPDATE MemberTbl SET MName = @MName, MPhone = @MPhone, MGen = @MGen, MAge = @MAge, MAmount = @MAmount, MTiming = @MTiming, IdUser = @IdUser
			WHERE MId = @MId
		END
	END
	IF @OP = 2
	BEGIN
		DELETE FROM MemberTbl WHERE MId = @MId
	END
END

-----------------------------------------------pago---------------------------------------------------------------------------
create procedure SP_PaymentTbl (
@OP tinyint = 0,
@PId INT = 0,   
@PMonth VARCHAR(50) = NULL,       
@IdMember INT = 0,
@PAmount INT = 0			
)

AS
BEGIN
	IF @OP = 1
	BEGIN
		IF NOT EXISTS (SELECT * FROM PaymentTbl WHERE PId = @PId)
		BEGIN
			INSERT INTO PaymentTbl(PId, PMonth, IdMember, PAmount) 
			VALUES(@PId, @PMonth, @IdMember, @PAmount)
		END
		ELSE
		BEGIN
			UPDATE PaymentTbl SET PMonth = @PMonth, IdMember = @IdMember, PAmount = @PAmount
			WHERE PId = @PId
		END
	END
	IF @OP = 2
	BEGIN
		DELETE FROM PaymentTbl WHERE PId = @PId
	END
END

-----------------------------------------------login---------------------------------------------------------------------------
CREATE PROCEDURE Sp_LoginUsuario
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
GO

--run everything together
DECLARE @result BIT; -- We declare the output variable

-- We execute the stored procedure
EXEC Sp_LoginUsuario 
    @UsName = 'Admin', 
    @UsPassword = 'c1c224b03cd9bc7b6a86d77f5dace40191766c485cd55dc48caf9ac873335d6f', 
    @result = @result OUTPUT;

-- We show the result
SELECT @result AS Resultado;

