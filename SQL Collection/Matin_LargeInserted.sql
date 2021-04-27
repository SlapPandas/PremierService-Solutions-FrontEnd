CREATE PROCEDURE InsertClientBusinessWithAddress @busuinessName VARCHAR(50), @contactNumber VARCHAR(10), @taxNumber VARCHAR(10), @RegistrationDate DATE,@streetname VARCHAR(100),@suburb VARCHAR(100),@province VARCHAR(20),@postalcode VARCHAR(20)
AS
	BEGIN TRAN
		DECLARE @LASTID INT
		INSERT INTO [Address] ([streetName], [suburb], [province], [postalcode])
		VALUES (@streetname, @suburb,@province ,@postalcode)
		SET @LASTID = SCOPE_IDENTITY()

		INSERT INTO [ClientBusiness] ([busuinessName], [addressId], [contactNumber], [taxNumber], [RegistrationDate])
		VALUES (@busuinessName, @LASTID, @contactNumber, @taxNumber, @RegistrationDate)
	COMMIT
GO
CREATE PROCEDURE InsertEmployeeWithAddress @id INT, @firstName VARCHAR(100), @surname VARCHAR(100), @contactNumber INT, @email VARCHAR(100), @nationalIdNumber INT, @employmentDate DATE, @employed BIT, @department VARCHAR (20),@streetname VARCHAR(100),@suburb VARCHAR(100),@province VARCHAR(20),@postalcode VARCHAR(20)
AS
	BEGIN TRAN
		DECLARE @LASTID INT
		INSERT INTO [Address] ([streetName], [suburb], [province], [postalcode])
		VALUES (@streetname, @suburb,@province ,@postalcode)
		SET @LASTID = SCOPE_IDENTITY()

	INSERT INTO [Employee] ([firstName], [surname], [addressId], [contactNumber], [email], [nationalIdNumber], [employmentDate], [employed], [department])
	VALUES (@firstName, @surname, @LASTID, @contactNumber, @email, @nationalIdNumber, @employmentDate, @employed, @department)
	COMMIT
GO
CREATE PROCEDURE LinkContractAndServicePackage @contractId INT, @ServicePakageId INT
AS
	BEGIN TRAN
		INSERT INTO ServiceContractLink(ContractID,ServicePackedgeID) VALUES (@contractId,@ServicePakageId)
	COMMIT
GO
CREATE PROCEDURE LinkContractStateAndServicePackageState @contractId INT, @ServicePakageId INT
AS
	BEGIN TRAN
		INSERT INTO ServiceContractStateLink(contractStateID,ServicePackageStateID) VALUES (@contractId,@ServicePakageId)
	COMMIT
GO
CREATE PROCEDURE LinkServicePackageAndService @servicePackageId INT, @ServiceId INT
AS
	BEGIN TRAN
		INSERT INTO ServicePackageLink(ServicePackageID,ServiceID) VALUES (@servicePackageId,@ServiceId)
	COMMIT
GO
CREATE PROCEDURE LinkServicePackageAndServiceState @servicePackageId INT, @ServiceId INT
AS
	BEGIN TRAN
		INSERT INTO ServicePackageStateLink(ServicePackageStateID,ServiceStateID) VALUES (@servicePackageId,@ServiceId)
	COMMIT
GO
CREATE PROCEDURE LinkSpecialisationAndEmployee @employeeId INT, @specialisationId INT
AS
	BEGIN TRAN
		INSERT INTO SpecialisationEmployeeLink(employeeID,specialisationID) VALUES (@employeeId,@specialisationId)
	COMMIT
GO
CREATE PROCEDURE LinkEmployeeAndJob @employeeId INT, @jobId INT
AS
	BEGIN TRAN
		INSERT INTO JobEmployeeLink(employeeID,jobID) VALUES (@employeeId,@jobId)
	COMMIT
GO

<<<<<<< Updated upstream

--custom Selects
CREATE PROCEDURE SelectAllServiceRequestsByBusinessClient @id INT
AS
	SELECT * FROM ServiceRequest
	INNER JOIN [Call] ON ServiceRequest.callID = [call].ID
	INNER JOIN ClientBusiness ON [Call].ClientBusinessID = ClientBusiness.ID
	WHERE ClientBusiness.ID = @id
GO
CREATE PROCEDURE SelectAllServiceRequestsByIndividualClient @id INT
AS
	SELECT * FROM ServiceRequest
	INNER JOIN [Call] ON ServiceRequest.callID = [call].ID
	INNER JOIN ClientIndividual ON [Call].ClientIndividualID = ClientIndividual.ID
	WHERE ClientIndividual.ID = @id
GO
=======
>>>>>>> Stashed changes
