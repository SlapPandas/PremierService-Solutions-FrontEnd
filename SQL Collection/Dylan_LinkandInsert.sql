CREATE PROCEDURE LinkContractAndClientBusinessAndIndividualBusiness @contractID INT, @clientBusinessID INT, @individualBusinessID INT
AS
	BEGIN TRAN
		INSERT INTO ClientContractLink(contractID,clientBusinessID,individualBusinessID) VALUES (@contractID,@clientBusinessID,@individualBusinessID)
	COMMIT
GO

CREATE PROCEDURE InsertIndividualClientWithAddress @firstName VARCHAR(100), @surname VARCHAR(100), @contactNumber INT, @email VARCHAR(100), @nationalIdNumber INT, @registrationDate DATE, @streetname VARCHAR(100),@suburb VARCHAR(100),@province VARCHAR(20),@postalcode VARCHAR(20)
AS 
	BEGIN TRAN
		DECLARE @LastID INT
		INSERT INTO [Address] ([streetName], [suburb], [province], [postalcode])
		VALUES (@streetname, @suburb,@province ,@postalcode)
		SET @LastID = SCOPE_IDENTITY()

		INSERT INTO [ClientIndividual] ([firstName], [surname], [contactNumber], [email], [nationalIdNumber], [RegistrationDate])
		VALUES (@firstName, @surname, @contactNumber, @email, @nationalIdNumber, @registrationDate)
	COMMIT
GO


SELECT * FROM ClientBusiness
SELECT * FROM [Address]