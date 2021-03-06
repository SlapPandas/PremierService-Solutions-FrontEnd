---CREATE FUNCTIONS
ALTER FUNCTION IndividualClientNumber (@id INT) 
returns char(9) 
AS 
BEGIN 
RETURN 'A' + RIGHT('00000000' + CONVERT(VARCHAR(10), @id), 8) 
END
GO

ALTER FUNCTION EmployeeNumber (@id INT) 
returns char(9) 
AS 
BEGIN 
RETURN 'E' + RIGHT('00000000' + CONVERT(VARCHAR(10), @id), 8) 
END
GO

ALTER FUNCTION BusinessClientNumber (@id INT) 
returns char(9) 
AS 
BEGIN 
RETURN 'B' + RIGHT('00000000' + CONVERT(VARCHAR(10), @id), 8) 
END
GO
ALTER FUNCTION ContractNumber (@id INT,@priority VARCHAR(20)) 
returns char(13) 
AS 
BEGIN 
RETURN 'C' + CAST(YEAR(GETDATE()) AS VARCHAR) + 'Z' + LEFT(@priority,1) + RIGHT('000000' + CONVERT(VARCHAR(10), @id), 6) 
END
GO
---CREATE TRIGGER
ALTER TRIGGER IndividualClient_insert ON ClientIndividual
AFTER INSERT AS 
UPDATE 
    ClientIndividual 
set 
    ClientIndividual.clientIndividualClientNumber = dbo.IndividualClientNumber(ClientIndividual.clientIndividualID) 
from 
    ClientIndividual 
INNER JOIN 
    inserted ON ClientIndividual.clientIndividualID= inserted.clientIndividualID
GO

ALTER TRIGGER Employee_insert ON Employee
AFTER INSERT AS 
UPDATE 
    Employee 
set 
    Employee.employeeNumber = dbo.EmployeeNumber(Employee.employeeID) 
from 
    Employee 
INNER JOIN 
    inserted ON Employee.employeeID= inserted.employeeID
GO

ALTER TRIGGER BusinessClient_insert ON ClientBusiness 
AFTER INSERT AS 
UPDATE 
    ClientBusiness 
set 
    ClientBusiness.clientBusinessClientNumber = dbo.BusinessClientNumber(ClientBusiness.clientBusinessID) 
from 
    ClientBusiness 
INNER JOIN 
    inserted ON ClientBusiness.clientBusinessID= inserted.clientBusinessID
GO

ALTER TRIGGER Contract_insert ON [Contract] 
AFTER INSERT AS 
UPDATE 
    [Contract] 
set 
    [Contract].contractNumber = dbo.ContractNumber([Contract].contractID,[Contract].priorityLevel) 
from 
    [Contract] 
INNER JOIN 
    inserted ON [Contract].contractID= inserted.contractID
GO

ALTER TRIGGER ContractState_insert ON ContractState 
AFTER INSERT AS 
UPDATE 
    ContractState 
set 
    ContractState.contractNumber = dbo.ContractNumber(ContractState.contractStateID,ContractState.priorityLevel)
from 
    ContractState 
INNER JOIN 
    inserted ON ContractState.contractStateID= inserted.contractStateID
GO

GO

--Create ErorLog
ALTER PROC CreateDatabaseOperationLog @dateTime DATETIME, @description VARCHAR(2000), @success INT
AS
	BEGIN TRAN
		INSERT INTO DatabaseOperation ([dateAndTime],[description],[success]) VALUES (@dateTime,@description,@success)
	COMMIT
GO

ALTER PROC GetAllDatabaseOperations
AS
	BEGIN TRAN
		SELECT * FROM DatabaseOperation
	COMMIT
GO

--DELETE Procedures
ALTER PROC DeleteServiceRequest @id INT
AS
	BEGIN TRAN
		DELETE FROM JobEmployeeLink
		WHERE jobID IN (SELECT Job.jobID FROM Job WHERE ServiceRequestID = @id)

		DELETE FROM Job
		WHERE ServiceRequestID = @id

		DELETE FROM ServiceRequestSpecialisationLink
		WHERE ServiceRequestID IN (SELECT ServiceRequest.serviceRequestID FROM ServiceRequest WHERE ServiceRequestID = @id)

		DELETE FROM ServiceRequest
		WHERE serviceRequestID = @id
	COMMIT
GO
--INSERT INTO TVP TABLES
ALTER PROC InsertIntoTVPServiceRequestSpecilization @serviceRequestId INT,@SpecilizationId INT
AS
	BEGIN TRAN
		INSERT INTO TVP(idIntOne,idIntTwo)
		VALUES (@serviceRequestId,@SpecilizationId)
	COMMIT
GO
ALTER PROC InsertIntoTVPMaintenanceEmployeeSpecilization @employeeId VARCHAR(50),@SpecilizationId INT
AS
	BEGIN TRAN
		INSERT INTO TVP(idIntOne,idIntTwo)
		VALUES ((SELECT employeeID FROM Employee WHERE employeeNumber = @employeeId),@SpecilizationId)
	COMMIT
GO
ALTER PROC InsertIntoTVPNewServiceRequestSpecilization @SpecilizationId INT
AS
	BEGIN TRAN
		INSERT INTO TVP(idIntOne)
		VALUES (@SpecilizationId)
	COMMIT
GO
ALTER PROC InsertIntoTVPNewMaintenanceEmployeeSpecilization @SpecilizationId INT
AS
	BEGIN TRAN
		INSERT INTO TVP(idIntOne)
		VALUES (@SpecilizationId)
	COMMIT
GO
ALTER PROC InsertIntoTVPJobEmployee @jobId INT,@employeeId VARCHAR(50)
AS
	BEGIN TRAN
		INSERT INTO TVP(idIntOne,idIntTwo)
		VALUES (@jobId,(SELECT Employee.employeeID FROM Employee WHERE Employee.employeeNumber = @employeeId))
	COMMIT
GO
ALTER PROC InsertIntoTVPNewJobEmployee @employeeId VARCHAR(50)
AS
	BEGIN TRAN
		INSERT INTO TVP(idIntOne)
		VALUES ((SELECT Employee.employeeID FROM Employee WHERE Employee.employeeNumber = @employeeId))
	COMMIT
GO
ALTER PROC InsertIntoTVPNewContractServicePackedge @packedgeId VARCHAR(50)
AS
	BEGIN TRAN
		INSERT INTO TVP(idIntOne)
		VALUES (@packedgeId)
	COMMIT
GO
ALTER PROC InsertIntoTVPPackedgeService @packedgeId INT,@serviceId INT
AS
	BEGIN TRAN
		INSERT INTO TVP(idIntOne,idIntTwo)
		VALUES (@packedgeId,@serviceId)
	COMMIT
GO
ALTER PROC InsertIntoTVPContractServicePackage @contractId VARCHAR(50),@servicePackageId INT
AS
	BEGIN TRAN
		INSERT INTO TVP(idIntOne,idIntTwo)
		VALUES ((SELECT contractID FROM [Contract] WHERE contractNumber = @contractId),@servicePackageId)
	COMMIT
GO
ALTER PROC DeleteJob @id INT
AS
	BEGIN TRAN
		DELETE FROM JobEmployeeLink
		WHERE jobID IN (SELECT Job.jobID FROM Job WHERE Job.jobID = @id)

		DELETE FROM Job
		WHERE jobID = @id
	COMMIT
GO
ALTER PROC DeleteClientBusinessEmployee @id INT 
AS
	BEGIN TRAN
		DELETE FROM ClientBusinessEmployee
		WHERE clientBusinessEmployeeID = @id
	COMMIT
GO
ALTER PROC DeleteService @id INT
AS
	BEGIN TRAN
		DELETE FROM ServicePackageLink
		WHERE serviceID IN (SELECT serviceID FROM [Service] WHERE serviceID = @id)

		DELETE FROM [Service]
		WHERE serviceID = @id
	COMMIT
GO
ALTER PROC DeleteServicePackage @id INT
AS
	BEGIN TRAN
		DELETE FROM ServicePackageLink
		WHERE ServicePackageID IN (SELECT servicePackageID FROM ServicePackage WHERE servicePackageID = @id)

		DELETE FROM ServiceContractLink
		WHERE ServicePackedgeID IN (SELECT servicePackageID FROM ServicePackage WHERE servicePackageID = @id)

		DELETE FROM ServicePackage
		WHERE servicePackageID = @id
	COMMIT
GO
ALTER PROC DeleteContract @id VARCHAR(50)
AS
	BEGIN TRAN
		DELETE FROM ServiceContractLink
		WHERE ContractID IN (SELECT contractID FROM [Contract] WHERE contractNumber = @id)

		DELETE FROM [Contract]
		WHERE contractID = (SELECT contractID FROM [Contract] WHERE contractNumber = @id)
	COMMIT
GO
ALTER PROC DeleteSpecialisation @id INT 
AS
	BEGIN TRAN
		DELETE FROM SpecialisationEmployeeLink
		WHERE specialisationID = @id

		DELETE FROM ServiceRequestSpecialisationLink
		WHERE specialisationRequiredID = @id

		DELETE FROM Specialisation
		WHERE specialisationID = @id
	COMMIT
GO
ALTER PROC DeleteAddress @id INT 
AS
	BEGIN TRAN
		DELETE FROM Address
		WHERE addressID = @id
	COMMIT
GO

--UPDATE Procedures
ALTER PROCEDURE UpdateAddress @id INT, @streetName VARCHAR(100), @suburb VARCHAR(100), @province VARCHAR(20), @postalcode VARCHAR(10),@city VARCHAR(40)
AS
BEGIN
	BEGIN TRAN
	UPDATE Address
	SET streetName = @streetName, suburb = @suburb, province = @province, postalcode = @postalcode, city = @city
	WHERE addressID = @id

	COMMIT
END
GO
ALTER PROCEDURE UpdateCallNotes @id INT, @callnotes VARCHAR(255)
AS
BEGIN
	BEGIN TRAN

	UPDATE Call
	SET callNotes = @callnotes
	WHERE callID = @id

	COMMIT
END
GO 
ALTER PROCEDURE UpdateEndTime @id INT, @endTime DATETIME
AS
BEGIN
	BEGIN TRAN

	UPDATE Call
	SET endTime = @endTime
	WHERE callID = @id

	COMMIT
END
GO 
ALTER PROCEDURE UpdateCallClientIndividual @id INT, @ClientIndividual VARCHAR(50)
AS
BEGIN
	BEGIN TRAN
		UPDATE Call
		SET ClientIndividualID = (SELECT clientIndividualID FROM ClientIndividual WHERE clientIndividualClientNumber = @ClientIndividual)
		WHERE callID = @id
	COMMIT
END
GO
ALTER PROCEDURE UpdateCallClientBusiness @id INT, @ClientBusiness VARCHAR(50)
AS
BEGIN
	BEGIN TRAN
		UPDATE Call
		SET ClientBusinessID = (SELECT clientBusinessID FROM ClientBusiness WHERE clientBusinessClientNumber = @ClientBusiness)
		WHERE callID = @id
	COMMIT
END
GO
ALTER PROCEDURE UpdateBusinessClientEmployee @id Int, @firstName  VARCHAR(50), @surname VARCHAR(50), @department VARCHAR(50), @contactNumber VARCHAR(10), @email VARCHAR(100)
AS
BEGIN
	BEGIN TRAN
	UPDATE ClientBusinessEmployee
	SET firstName = @firstName, surname = @surname, department = @department, contactNumber = @contactNumber, email = @email
	WHERE clientBusinessEmployeeID = @id
	COMMIT
END
GO
ALTER PROCEDURE UpdateBusinessClientState @id VARCHAR(20), @active INT
AS
BEGIN
	BEGIN TRAN
	UPDATE ClientBusiness
	SET active = @active
	WHERE clientBusinessClientNumber = @id
	COMMIT
END
GO
ALTER PROCEDURE UpdateClientBusiness @id VARCHAR(100), @businessName VARCHAR(50), @contact VARCHAR(10), @taxnumber VARCHAR(10), @registrationDate DATE, @active INT, @adressid INT, @streetName VARCHAR(100), @suburb VARCHAR(100), @province VARCHAR(20), @postalcode VARCHAR(10),@city VARCHAR(100)
AS
BEGIN
	BEGIN TRAN

	UPDATE ClientBusiness
	SET busuinessName = @businessName, addressId = @adressid, contactNumber = @contact, taxNumber = @taxnumber, RegistrationDate = @registrationDate, active = @active
	WHERE clientBusinessClientNumber = @id

	UPDATE [Address]
	SET streetName = @streetName, suburb = @suburb, province = @province, postalcode = @postalcode, city = @city
	WHERE addressID = @adressid

	COMMIT
END
GO
ALTER PROCEDURE UpdateClientIndividual @id VARCHAR(100), @firstname VARCHAR(100), @surname VARCHAR(100), @contact VARCHAR(10), @email VARCHAR(100), @nationalid VARCHAR(13), @registrationdate DATE, @active INT, @adressid INT, @streetName VARCHAR(100), @suburb VARCHAR(100), @province VARCHAR(20), @postalcode VARCHAR(10),@city VARCHAR(100)
AS
BEGIN
	BEGIN TRAN

	UPDATE ClientIndividual
	SET firstName = @firstname, surname = @surname, addressId = @adressid, contactNumber = @contact, email = @email, nationalIdNumber = @nationalid,  RegistrationDate = @registrationdate, active = @active
	WHERE clientIndividualClientNumber = @id

	UPDATE [Address]
	SET streetName = @streetName, suburb = @suburb, province = @province, postalcode = @postalcode, city = @city
	WHERE addressID = @adressid

	COMMIT
END
GO
ALTER PROCEDURE UpdateClientIndividualCurrentState @id VARCHAR(100), @active INT
AS
BEGIN
	BEGIN TRAN

	UPDATE ClientIndividual
	SET active = @active
	WHERE clientIndividualClientNumber = @id
	COMMIT
END
GO
ALTER PROCEDURE UpdateContract @id VARCHAR(50), @startdate DATE, @endtime DATE, @active INT, @priorityLevel VARCHAR(20), @price FLOAT, @contractType VARCHAR(15)
AS
BEGIN

	BEGIN TRAN

	UPDATE Contract
	SET startDate = @startdate, endDate = @endtime, [activeContract] = @active, priorityLevel = @priorityLevel, price = @price, contractType = @contractType
	WHERE contractID = (SELECT contractID FROM [Contract] WHERE contractNumber = @id)

	COMMIT

END
GO
ALTER PROCEDURE UpdateOfferedContractActive @id VARCHAR(50), @active INT
AS
BEGIN

	BEGIN TRAN

	UPDATE Contract
	SET [activeContract] = @active
	WHERE contractID = (SELECT contractID FROM [Contract] WHERE contractNumber = @id)

	COMMIT

END
GO
ALTER PROCEDURE UpdateClientContractActive @id VARCHAR(50), @active INT
AS
BEGIN

	BEGIN TRAN

	UPDATE [ContractState]
	SET [activeContract] = @active
	WHERE contractStateID = (SELECT contractID FROM [Contract] WHERE contractNumber = @id)

	COMMIT

END
GO
ALTER PROCEDURE UpdateOfferedContractActiveAndDateRange @id VARCHAR(50), @active INT,@dateStart DATETIME,@dateEnd DATETIME
AS
BEGIN

	BEGIN TRAN

	UPDATE [Contract]
	SET [activeContract] = @active,startDate = @dateStart, endDate = @dateEnd
	WHERE contractID = (SELECT contractID FROM [Contract] WHERE contractNumber = @id)

	COMMIT

END
GO
ALTER PROCEDURE UpdateEmployee @id VARCHAR(50), @firstName VARCHAR(50), @surname VARCHAR(100), @contactNumber VARCHAR(10), @email VARCHAR(100), @nationalIdNumber VARCHAR(13), @employmentdate DATE, @employed INT, @department VARCHAR(25), @adressId INT, @streetName VARCHAR(100), @suburb VARCHAR(100), @province VARCHAR(20), @postalcode VARCHAR(10), @city VARCHAR(100)
AS
BEGIN
	BEGIN TRAN

	UPDATE Employee
	SET firstName = @firstName, surname = @surname, addressId = @adressId, contactNumber = @contactNumber, email = @email, nationalIdNumber = @nationalIdNumber,  employmentDate = @employmentdate, employed = @employed, department = @department
	WHERE employeeID = (SELECT employeeID FROM Employee WHERE employeeNumber = @id)

	UPDATE [Address]
	SET streetName = @streetName, suburb = @suburb, province = @province, postalcode = @postalcode,city = @city
	WHERE addressID = @adressid

	COMMIT
END
GO
ALTER PROCEDURE UpdateJob @id INT, @notes VARCHAR(255),@state INT, @needed INT
AS
BEGIN
	BEGIN TRAN
		UPDATE Job
		SET notes = @notes, currentState = @state, amountOfEmployeesNeeded = @needed
		WHERE jobID = @id
	COMMIT
END
GO
ALTER PROC UpdateJobEmployeeList @id INT
AS
	BEGIN TRAN
		DELETE FROM JobEmployeeLink
		WHERE JobEmployeeLink.jobID = @id

		INSERT INTO JobEmployeeLink(jobID,employeeID)
		SELECT idIntOne,idIntTwo FROM TVP

		DELETE FROM TVP
	COMMIT
GO
ALTER PROCEDURE UpdateJobState @id INT, @currentstate VARCHAR(50)
AS
BEGIN
	BEGIN TRAN
		UPDATE Job
		SET currentState = @currentstate
		WHERE jobID = @id
	COMMIT
END
GO
ALTER PROCEDURE UpdateEmployeeState @id VARCHAR(50), @employed INT
AS
BEGIN
	BEGIN TRAN
		UPDATE Employee
		SET employed = @employed
		WHERE employeeID = (SELECT employeeID FROM Employee WHERE employeeNumber= @id)
	COMMIT
END
GO
GO
ALTER PROCEDURE UpdateJobEmployeesRequired @id INT, @amount INT
AS
BEGIN
	BEGIN TRAN
		UPDATE Job
		SET amountOfEmployeesNeeded = @amount
		WHERE jobID = @id
	COMMIT
END
GO
ALTER PROC UpdateServicePackage @id INT, @name VARCHAR(100), @price FLOAT
AS
	BEGIN TRAN
		UPDATE ServicePackage
		SET [name] = @name, price = @price
		WHERE servicePackageID = @id
	COMMIT
GO
ALTER PROC UpdateServicePackagePropotion @id INT, @onPromotion INT, @promotionStartDate DATETIME, @promotionEndDate DATETIME, @percentage FLOAT
AS
	BEGIN TRAN
		UPDATE ServicePackage
		SET onPromotion = @onPromotion, promotionStartDate = @promotionStartDate, promotionEndDate = @promotionEndDate, promotionPercentAmount = @percentage
		WHERE servicePackageID = @id
	COMMIT
GO
ALTER PROC UpdateServicePackageState @id INT, @onPromotion INT
AS
	BEGIN TRAN
		UPDATE ServicePackage
		SET onPromotion = @onPromotion
		WHERE servicePackageID = @id
	COMMIT
GO
ALTER PROC UpdateServicePackedgeServiceList @id INT
AS
	BEGIN TRAN
		DELETE FROM ServicePackageLink
		WHERE ServicePackageLink.ServicePackageID = @id

		INSERT INTO ServicePackageLink(ServicePackageID,ServiceID)
		SELECT idIntOne,idIntTwo FROM TVP

		DELETE FROM TVP
	COMMIT
GO
ALTER PROC UpdateContractPackageList @id VARCHAR(50)
AS
	BEGIN TRAN
		DELETE FROM ServiceContractLink
		WHERE ServiceContractLink.ContractID = (SELECT contractID FROM [Contract] WHERE contractNumber = @id)

		INSERT INTO ServiceContractLink(ContractID,ServicePackedgeID)
		SELECT idIntOne,idIntTwo FROM TVP

		DELETE FROM TVP
	COMMIT
GO
ALTER PROC UpdateService @id INT, @name VARCHAR(100),@description VARCHAR(255)
AS
	BEGIN TRAN
		UPDATE [Service]
		SET [name] = @name, [description] = @description
		WHERE serviceID = @id
	COMMIT
GO
ALTER PROC UpdateServiceRequest @id INT,@description VARCHAR(255), @priorityLevel VARCHAR(20)
AS
	BEGIN TRAN
		UPDATE ServiceRequest
		SET [description] = @description, priorityLevel = @priorityLevel
		WHERE serviceRequestID = @id
	COMMIT
GO
ALTER PROC UpdateServiceRequestCurrentState @id INT, @closed INT
AS
	BEGIN TRAN
		UPDATE ServiceRequest
		SET closed = @closed
		WHERE serviceRequestID = @id
	COMMIT
GO
ALTER PROC UpdateServiceRequestSpecializationList @id INT
AS
	BEGIN TRAN
		DELETE FROM ServiceRequestSpecialisationLink
		WHERE ServiceRequestSpecialisationLink.ServiceRequestID = @id

		INSERT INTO ServiceRequestSpecialisationLink(ServiceRequestID,specialisationRequiredID)
		SELECT idIntOne,idIntTwo FROM TVP

		DELETE FROM TVP
	COMMIT
GO
ALTER PROC UpdateMaintenanceEmployeeSpecializationList @id INT
AS
	BEGIN TRAN
		DELETE FROM SpecialisationEmployeeLink
		WHERE SpecialisationEmployeeLink.employeeID = @id

		INSERT INTO SpecialisationEmployeeLink(employeeID,specialisationID)
		SELECT idIntOne,idIntTwo FROM TVP

		DELETE FROM TVP
	COMMIT
GO
ALTER PROC InsertServiceRequestWithSpecializationList @callId INT, @closed INT, @description VARCHAR(255),@priorityLevel VARCHAR(255)
AS
	BEGIN TRAN
		DECLARE @serviceRequestId INT
		INSERT INTO [ServiceRequest] ([callID], [closed], [description],[priorityLevel])
		VALUES (@callId, @closed, @description,@priorityLevel)
		SET @serviceRequestId = SCOPE_IDENTITY()

		INSERT INTO ServiceRequestSpecialisationLink(ServiceRequestID,specialisationRequiredID)
		SELECT @serviceRequestId,idIntOne FROM TVP

		DELETE FROM TVP
	COMMIT
GO
ALTER PROC InsertServiceRequestWithSpecializationListWithReturnedId @callId INT, @closed INT, @description VARCHAR(255),@priorityLevel VARCHAR(255)
AS
	DECLARE @serviceRequestId INT
	INSERT INTO [ServiceRequest] ([callID], [closed], [description],[priorityLevel])
	VALUES (@callId, @closed, @description,@priorityLevel)
	SET @serviceRequestId = SCOPE_IDENTITY()

	INSERT INTO ServiceRequestSpecialisationLink(ServiceRequestID,specialisationRequiredID)
	SELECT @serviceRequestId,idIntOne FROM TVP

	DELETE FROM TVP

	SELECT IDENT_CURRENT('ServiceRequest')
GO
ALTER PROC UpdateSpecialization @id INT, @name VARCHAR(100),@description VARCHAR(255)
AS
	BEGIN TRAN
		UPDATE Specialisation
		SET [name] = @name, [description] = @description
		WHERE specialisationID = @id
	COMMIT
GO
ALTER PROC UpdateServicePackedgePromotion @id INT, @startDate DATE,@endDate DATE,@state INT,@percentage FLOAT
AS
	BEGIN TRAN
		UPDATE ServicePackage
		SET promotionStartDate = @startDate, promotionEndDate = @endDate, onPromotion = @state,promotionPercentAmount = @percentage
		WHERE servicePackageID = @id
	COMMIT
GO

-- INSERT Procedures
ALTER PROCEDURE InsertAddress @streetname VARCHAR(100),@suburb VARCHAR(100),@province VARCHAR(20),@postalcode VARCHAR(4), @city VARCHAR(40)
AS
BEGIN 
	INSERT INTO [Address] ([streetName], [suburb], [province], [postalcode],[city])
	VALUES (@streetname, @suburb,@province ,@postalcode,@city)
END
GO
ALTER PROCEDURE InsertEmployee @firstName VARCHAR(50), @surname VARCHAR(50), @contactNumber VARCHAR(10), @email VARCHAR(100), @nationalIdNumber VARCHAR(13), @employmentDate DATE, @employed INT, @department VARCHAR(25), @streetname VARCHAR(100),@suburb VARCHAR(100),@province VARCHAR(20),@postalcode VARCHAR(20),@city VARCHAR(50)
AS
		BEGIN TRAN
		DECLARE @LASTID INT
		INSERT INTO [Address] ([streetName], [suburb], [province], [postalcode],[city])
		VALUES (@streetname, @suburb,@province ,@postalcode,@city)
		SET @LASTID = SCOPE_IDENTITY()

		INSERT INTO [Employee] ([firstName], [surname], [addressId], [contactNumber], [email], [nationalIdNumber], [employmentDate],[employed])
		VALUES (@firstName, @surname, @LASTID, @contactNumber, @email, @nationalIdNumber, @employmentDate,@employed)
COMMIT 
GO
ALTER PROCEDURE InsertSpecialisation @name VARCHAR(25), @description VARCHAR(250)
AS
BEGIN
	INSERT INTO [Specialisation] ([name], [description])
	VALUES (@name, @description)
END 
GO
ALTER PROCEDURE InsertCallCenterEmployee @firstName VARCHAR(50), @surname VARCHAR(50), @contactNumber VARCHAR(10), @email VARCHAR(100), @nationalIdNumber VARCHAR(13), @employmentDate DATE, @employed INT, @department VARCHAR(25) ,@streetname VARCHAR(100),@suburb VARCHAR(100),@province VARCHAR(20),@postalcode VARCHAR(20),@city VARCHAR(50)
AS
		BEGIN TRAN
		DECLARE @LASTID INT
		INSERT INTO [Address] ([streetName], [suburb], [province], [postalcode],[city])
		VALUES (@streetname, @suburb,@province ,@postalcode,@city)
		SET @LASTID = SCOPE_IDENTITY()

		INSERT INTO [Employee] (firstName, surname, [addressId], [contactNumber], [email], [nationalIdNumber], [employmentDate],[employed], [department])
		VALUES (@firstName, @surname, @LASTID, @contactNumber, @email, @nationalIdNumber, @employmentDate,@employed, @department)
COMMIT 
GO
ALTER PROCEDURE InsertMaintenanceEmployee @firstName VARCHAR(50), @surname VARCHAR(50), @contactNumber VARCHAR(10), @email VARCHAR(100), @nationalIdNumber VARCHAR(13), @employmentDate DATE, @employed INT, @department VARCHAR(25) ,@streetname VARCHAR(100),@suburb VARCHAR(100),@province VARCHAR(20),@postalcode VARCHAR(20),@city VARCHAR(50)
AS
		BEGIN TRAN
		DECLARE @LASTADDRESSID INT
		DECLARE @LASTEMPLOYEEID INT
		INSERT INTO [Address] ([streetName], [suburb], [province], [postalcode],[city])
		VALUES (@streetname, @suburb,@province ,@postalcode,@city)
		SET @LASTADDRESSID = IDENT_CURRENT('Address')

		INSERT INTO [Employee] ([firstName], [surname], [addressId], [contactNumber], [email], [nationalIdNumber], [employmentDate],[employed], [department])
		VALUES (@firstName, @surname, @LASTADDRESSID, @contactNumber, @email, @nationalIdNumber, @employmentDate,@employed, @department)
		SET @LASTEMPLOYEEID = IDENT_CURRENT('Employee')

		INSERT INTO SpecialisationEmployeeLink(employeeID,specialisationID)
		SELECT @LASTEMPLOYEEID,idIntOne FROM TVP

		DELETE FROM TVP
COMMIT 
GO
ALTER PROCEDURE InsertServiceManager @firstName VARCHAR(50), @surname VARCHAR(50), @contactNumber VARCHAR(10), @email VARCHAR(100), @nationalIdNumber VARCHAR(13), @employmentDate DATE, @employed INT, @department VARCHAR(25) ,@streetname VARCHAR(100),@suburb VARCHAR(100),@province VARCHAR(20),@postalcode VARCHAR(20),@city VARCHAR(50)
AS
		BEGIN TRAN
		DECLARE @LASTID INT
		INSERT INTO [Address] ([streetName], [suburb], [province], [postalcode],[city])
		VALUES (@streetname, @suburb,@province ,@postalcode,@city)
		SET @LASTID = SCOPE_IDENTITY()

		INSERT INTO [Employee] (firstName, surname, [addressId], [contactNumber], [email], [nationalIdNumber], [employmentDate],[employed], [department])
		VALUES (@firstName, @surname, @LASTID, @contactNumber, @email, @nationalIdNumber, @employmentDate,@employed, @department)
COMMIT 
GO
ALTER PROCEDURE InsertClientIndividual @firstName VARCHAR(50), @surname VARCHAR(50), @contactNumber VARCHAR(10), @email VARCHAR(100), @nationalIdNumber VARCHAR(13), @registrationDate DATE, @active INT,@streetname VARCHAR(100),@suburb VARCHAR(100),@province VARCHAR(20),@postalcode VARCHAR(20),@city VARCHAR(50)
AS
		BEGIN TRAN
		DECLARE @LASTID INT
		INSERT INTO [Address] ([streetName], [suburb], [province], [postalcode],[city])
		VALUES (@streetname, @suburb,@province ,@postalcode,@city)
		SET @LASTID = SCOPE_IDENTITY()

		INSERT INTO [ClientIndividual] ([firstName], [surname], [addressId], [contactNumber], [email], [nationalIdNumber], [RegistrationDate],[active])
		VALUES (@firstName, @surname, @LASTID, @contactNumber, @email, @nationalIdNumber, @registrationDate,@active)
COMMIT 
GO
ALTER PROCEDURE InsertClientBusiness @busuinessName VARCHAR(50), @contactNumber VARCHAR(10), @taxNumber VARCHAR(10), @RegistrationDate DATE, @active INT,@streetname VARCHAR(100),@suburb VARCHAR(100),@province VARCHAR(20),@postalcode VARCHAR(20),@city VARCHAR(50)
AS
	BEGIN TRAN
	DECLARE @LASTID INT
	INSERT INTO [Address] ([streetName], [suburb], [province], [postalcode],[city])
	VALUES (@streetname, @suburb,@province ,@postalcode,@city)
	SET @LASTID = SCOPE_IDENTITY()

	INSERT INTO [ClientBusiness] ([busuinessName], [addressId], [contactNumber], [taxNumber], [RegistrationDate], [active])
	VALUES (@busuinessName, @LASTID, @contactNumber, @taxNumber, @RegistrationDate, @active)
COMMIT
GO
ALTER PROCEDURE InsertServicePackageState @id INT
AS
BEGIN
	INSERT INTO [ServicePackageState] ([name], [onPromotion], [promotionStartDate], [promotionEndDate], [price],[promotionPercentAmount])
	SELECT [name], [onPromotion], [promotionStartDate], [promotionEndDate], [price],[promotionPercentAmount] FROM [ServicePackage] WHERE [ServicePackage].servicePackageID = @id
	SELECT SCOPE_IDENTITY()
END 
GO
ALTER PROCEDURE InsertServicePackage @name VARCHAR(50), @onpromotion INT, @promationStartDate DATETIME, @promotionEndDate DATETIME, @price FLOAT,@percintage FLOAT
AS
BEGIN
	INSERT INTO [ServicePackage] ([name], [onPromotion], [promotionStartDate], [promotionEndDate], [price],[promotionPercentAmount])
	VALUES (@name, @onpromotion, @promationStartDate, @promotionEndDate, @price,@percintage)
END 
GO
ALTER PROCEDURE InsertService @name VARCHAR(50), @description VARCHAR(255)
AS
BEGIN
	INSERT INTO [Service] ([name], [description])
	VALUES (@name, @description)
END 
GO
ALTER PROCEDURE InsertServiceState @id INT
AS
BEGIN
	INSERT INTO [ServiceState] ([name], [description])
	SELECT [name], [description] FROM [Service] WHERE [Service].serviceID = @id
	SELECT SCOPE_IDENTITY()
END 
GO
ALTER PROCEDURE InsertSpecialisationEmployeeLink @employeeID INT, @specialisationID INT
AS
BEGIN
	INSERT INTO [SpecialisationEmployeeLink] ([employeeID], [specialisationID])
	VALUES (@employeeID, @specialisationID)
END 
GO
ALTER PROCEDURE InsertCall @startTime DATETIME, @employeeID VARCHAR(50)
AS
BEGIN
	INSERT INTO [Call] ([startTime], [employeeID])
	VALUES (@startTime, (SELECT employeeID FROM Employee WHERE employeeNumber = @employeeID))
	SELECT SCOPE_IDENTITY()
END 
GO
ALTER PROCEDURE InsertServiceRequest @callId INT, @closed INT, @description VARCHAR(255),@priorityLevel VARCHAR(255)
AS
BEGIN
	INSERT INTO [ServiceRequest] ([callID], [closed], [description],[priorityLevel])
	VALUES (@callId, @closed, @description,@priorityLevel)
END 
GO
ALTER PROCEDURE InsertServiceRequestSpecialisationLink @specialisationRequiredID INT, @ServiceRequestID INT
AS
BEGIN
	INSERT INTO [ServiceRequestSpecialisationLink] ([specialisationRequiredID], [ServiceRequestID])
	VALUES (@specialisationRequiredID, @ServiceRequestID)
END 
GO
ALTER PROCEDURE InsertBusinessClientEmployees @firstName VARCHAR(50),@surname VARCHAR(50),@department VARCHAR(50), @contactNumber VARCHAR(10), @email VARCHAR(100), @businessID VARCHAR(50)
AS
BEGIN 
	INSERT INTO [ClientBusinessEmployee] ([firstName], [surname], [department], [contactNumber], [email], [businessID])
	VALUES (@firstName, @surname, @department, @contactNumber, @email, (SELECT clientBusinessID FROM ClientBusiness WHERE clientBusinessClientNumber = @businessID))
END
GO
ALTER PROCEDURE InsertJob @addressId INT, @ServiceRequestID INT, @notes VARCHAR(255), @currentState VARCHAR(20), @specialization INT, @amountOfEmployees INT
AS
	BEGIN TRAN
		INSERT INTO [Job] ([addressId], [ServiceRequestID], [notes], [currentState],[specialisationId],[amountOfEmployeesNeeded])
		VALUES (@addressId, @ServiceRequestID, @notes, @currentState,@specialization,@amountOfEmployees)
	COMMIT 
GO
ALTER PROCEDURE InsertJobWithEmployeeList @addressId INT, @ServiceRequestID INT, @notes VARCHAR(255), @currentState VARCHAR(20), @specialization INT, @amountOfEmployees INT
AS
	BEGIN TRAN
		DECLARE @jobId INT
		INSERT INTO [Job] ([addressId], [ServiceRequestID], [notes], [currentState],[specialisationId],[amountOfEmployeesNeeded])
		VALUES (@addressId, @ServiceRequestID, @notes, @currentState,@specialization,@amountOfEmployees)
		SET @jobId = SCOPE_IDENTITY()

		INSERT INTO JobEmployeeLink(jobID,employeeID)
		SELECT @jobId,idIntOne FROM TVP

		DELETE FROM TVP



	COMMIT 
GO
ALTER PROCEDURE InsertServiceRequestJobLink @serviceRequestID INT, @jobID INT
AS
BEGIN
	INSERT INTO [ServiceRequestJobLink] ([serviceRequestID], [jobID])
	VALUES (@serviceRequestID, @jobID)
END 
GO
ALTER PROCEDURE InsertJobEmployeeLink @employeeID VARCHAR(50), @jobID INT
AS
BEGIN
	INSERT INTO [JobEmployeeLink] ([employeeID], [jobID])
	VALUES ((SELECT Employee.employeeID FROM Employee WHERE employeeNumber = @employeeID), @jobID)
END 
GO
ALTER PROCEDURE InsertContractWithPackadgeList @startDate DATETIME, @endDate DATETIME, @active INT,@priorityLevel VARCHAR(20), @price FLOAT, @contractType VARCHAR(15)
AS
BEGIN
	DECLARE @contractId INT
	INSERT INTO [Contract] ([startDate], [endDate], [activeContract],[priorityLevel],[price],[contractType])
	VALUES (@startDate, @endDate, @active,@priorityLevel,@price,@contractType)
	SET @contractId = SCOPE_IDENTITY()

	INSERT INTO ServiceContractLink(ContractID,ServicePackedgeID)
	SELECT @contractId,idIntOne FROM TVP
END 
GO
ALTER PROCEDURE InsertContractOfClient @contractId VARCHAR(50),@startDate DATETIME, @endDate DATETIME, @active INT
AS
BEGIN TRAN
	INSERT INTO ContractState(startDate,endDate,activeContract,priorityLevel,price,contractType,oldContractId)
	SELECT @startDate,@endDate,@active,priorityLevel,price,contractType,contractID FROM [Contract] WHERE [Contract].contractNumber =  @contractId
	SELECT SCOPE_IDENTITY()
COMMIT 
GO
ALTER PROCEDURE InsertClientBusinessEmployee @id INT, @businessID INT, @firstName VARCHAR(50), @surname VARCHAR(50), @department VARCHAR(50), @contactNumber VARCHAR(10), @email VARCHAR(100)
AS
BEGIN
	INSERT INTO [ClientBusinessEmployee] ([businessID], [firstName], [surname], [department], [contactNumber], [email])
	VALUES (@businessID, @firstName, @surname, @department, @contactNumber, @email)
END 
GO
ALTER PROCEDURE InsertServiceContractStateLink @contractStateID INT, @ServicePackageStateID INT
AS
BEGIN
	INSERT INTO [ServiceContractStateLink] ([contractStateID], [ServicePackageStateID])
	VALUES (@contractStateID, @ServicePackageStateID)
END 
GO
ALTER PROCEDURE InsertServiceContractLink @ContractID VARCHAR(40), @ServicePackageID INT
AS
BEGIN
	INSERT INTO [ServiceContractLink] ([ContractID], [ServicePackedgeID])
	VALUES ((SELECT contractID FROM [Contract] WHERE contractNumber = @ContractID), @ServicePackageID)
END 
GO
ALTER PROCEDURE InsertServicePackageStateLink @ServicePackageStateID INT, @ServiceStateID INT
AS
BEGIN
	INSERT INTO [ServicePackageStateLink] ([ServicePackageStateID], [ServiceStateID])
	VALUES (@ServicePackageStateID, @ServiceStateID)
END 
GO
ALTER PROCEDURE InsertServicePackageLink @ServicePackageID INT, @ServiceID INT
AS
BEGIN
	INSERT INTO [ServicePackageLink] ([ServicePackageID], [ServiceID])
	VALUES (@ServicePackageID, @ServiceID)
END 
GO
ALTER PROCEDURE InsertClientContractLinkIndividualClient @ContractID INT, @ClientIndividualID VARCHAR(50)
AS
BEGIN
	INSERT INTO [ClientContractLink] ([ContractID], [ClientIndividualID])
	VALUES (@ContractID,(SELECT clientIndividualID FROM ClientIndividual WHERE clientIndividualClientNumber = @ClientIndividualID))
END 
GO
ALTER PROCEDURE InsertClientContractLinkBusinessClient @ContractID INT, @ClientBusinessID VARCHAR(50)
AS
BEGIN
	INSERT INTO [ClientContractLink] ([ContractID], [ClientBusinessID])
	VALUES (@ContractID, (SELECT clientBusinessID FROM ClientBusiness WHERE clientBusinessClientNumber = @ClientBusinessID))
END 
GO
ALTER PROCEDURE InsertClientBusinessWithAddress @busuinessName VARCHAR(50), @contactNumber VARCHAR(10), @taxNumber VARCHAR(10), @RegistrationDate DATE,@streetname VARCHAR(100),@suburb VARCHAR(100),@province VARCHAR(20),@postalcode VARCHAR(20)
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
ALTER PROCEDURE InsertEmployeeWithAddress @id INT, @firstName VARCHAR(100), @surname VARCHAR(100), @contactNumber INT, @email VARCHAR(100), @nationalIdNumber INT, @employmentDate DATE, @employed BIT, @department VARCHAR (20),@streetname VARCHAR(100),@suburb VARCHAR(100),@province VARCHAR(20),@postalcode VARCHAR(20)
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
ALTER PROCEDURE LinkContractAndServicePackage @contractId INT, @ServicePakageId INT
AS
	BEGIN TRAN
		INSERT INTO ServiceContractLink(ContractID,ServicePackedgeID) VALUES (@contractId,@ServicePakageId)
	COMMIT
GO
ALTER PROCEDURE LinkContractStateAndServicePackageState @contractId INT, @ServicePakageId INT
AS
	BEGIN TRAN
		INSERT INTO ServiceContractStateLink(contractStateID,ServicePackageStateID) VALUES (@contractId,@ServicePakageId)
	COMMIT
GO
ALTER PROCEDURE LinkServicePackageAndService @servicePackageId INT, @ServiceId INT
AS
	BEGIN TRAN
		INSERT INTO ServicePackageLink(ServicePackageID,ServiceID) VALUES (@servicePackageId,@ServiceId)
	COMMIT
GO
ALTER PROCEDURE LinkServicePackageAndServiceState @servicePackageId INT, @ServiceId INT
AS
	BEGIN TRAN
		INSERT INTO ServicePackageStateLink(ServicePackageStateID,ServiceStateID) VALUES (@servicePackageId,@ServiceId)
	COMMIT
GO
ALTER PROCEDURE LinkSpecialisationAndEmployee @employeeId INT, @specialisationId INT
AS
	BEGIN TRAN
		INSERT INTO SpecialisationEmployeeLink(employeeID,specialisationID) VALUES (@employeeId,@specialisationId)
	COMMIT
GO
ALTER PROCEDURE LinkEmployeeAndJob @employeeId INT, @jobId INT
AS
	BEGIN TRAN
		INSERT INTO JobEmployeeLink(employeeID,jobID) VALUES (@employeeId,@jobId)
	COMMIT
GO

--custom Selects
ALTER PROCEDURE SelectAllServiceRequests
AS
	SELECT * FROM ServiceRequest
GO

ALTER PROCEDURE SelectAllServiceRequestsByBusinessClient @id VARCHAR(20)
AS
	SELECT * FROM ServiceRequest
	INNER JOIN [Call] ON ServiceRequest.callID = [call].callID
	INNER JOIN ClientBusiness ON [Call].ClientBusinessID = ClientBusiness.clientBusinessID
	WHERE ClientBusiness.clientBusinessClientNumber = @id
GO
ALTER PROCEDURE SelectAllServiceRequestsByIndividualClient @id VARCHAR(20)
AS
	SELECT * FROM ServiceRequest
	INNER JOIN [Call] ON ServiceRequest.callID = [call].callID
	INNER JOIN ClientIndividual ON [Call].ClientIndividualID = ClientIndividual.clientIndividualID
	WHERE ClientIndividual.clientIndividualClientNumber = @id
GO
ALTER PROCEDURE SelectAllAddresses AS
BEGIN
	SELECT * FROM Address
END
GO
ALTER PROCEDURE SelectCallByJobId @id INT AS
BEGIN
	SELECT * FROM [Call]
	INNER JOIN ServiceRequest ON [Call].callID = ServiceRequest.callID
	INNER JOIN Job ON ServiceRequest.serviceRequestID = Job.ServiceRequestID
	WHERE Job.jobID = @id
END
GO
ALTER PROCEDURE SelectCallbyId @id INT AS
BEGIN
	SELECT * FROM [Call]
	WHERE [Call].callID = @id
END
GO
ALTER PROCEDURE SelectCallbyIdClientIndividual @id INT AS
BEGIN
	SELECT * FROM [Call]
	INNER JOIN ClientIndividual ON [Call].ClientIndividualID = ClientIndividual.clientIndividualID
	INNER JOIN [Address] ON ClientIndividual.addressId = [Address].addressID
	WHERE [Call].callID = @id
END
GO
ALTER PROCEDURE SelectCallbyIdClientBusiness @id INT AS
BEGIN
	SELECT * FROM [Call]
	INNER JOIN ClientBusiness ON [Call].ClientBusinessID = ClientBusiness.clientBusinessID
	INNER JOIN [Address] ON ClientBusiness.addressId = [Address].addressID
	WHERE [Call].callID = @id
END
GO
ALTER PROCEDURE SelectAllCallsByIndividualClientId @id VARCHAR(100) AS
BEGIN
	SELECT * FROM [Call]
	INNER JOIN ClientIndividual ON [Call].ClientIndividualID = ClientIndividual.clientIndividualID
	INNER JOIN [Address] ON ClientIndividual.addressId = [Address].addressID
	WHERE ClientIndividual.clientIndividualClientNumber = @id
END
GO
ALTER PROCEDURE SelectAllCallsByBusinessClientId @id VARCHAR(100) AS
BEGIN
	SELECT * FROM [Call]
	INNER JOIN ClientBusiness ON [Call].ClientBusinessID = ClientBusiness.clientBusinessID
	INNER JOIN [Address] ON ClientBusiness.addressId = [Address].addressID
	WHERE ClientBusiness.clientBusinessClientNumber = @id
END
GO
ALTER PROCEDURE SelectBusinessClientById @id INT AS
BEGIN
	SELECT * FROM ClientBusiness
	INNER JOIN [Address] ON ClientBusiness.addressId = [Address].addressID
	WHERE ClientBusiness.clientBusinessID = @id
END
GO
ALTER PROCEDURE SelectAllBusinessClientEmployeesByBusinessId @businessid VARCHAR(100) AS
BEGIN
	SELECT * FROM ClientBusinessEmployee
	INNER JOIN ClientBusiness ON ClientBusinessEmployee.businessID = ClientBusiness.clientBusinessID
	WHERE ClientBusiness.clientBusinessClientNumber = @businessid
END
GO
ALTER PROCEDURE SelectAllBusinessClientEmployees AS
BEGIN
	SELECT * FROM ClientBusinessEmployee
	INNER JOIN ClientBusiness ON ClientBusinessEmployee.businessID = ClientBusiness.clientBusinessID
END
GO
ALTER PROCEDURE SelectAllIndividualClients AS
BEGIN
	SELECT * FROM ClientIndividual
	INNER JOIN [Address] ON ClientIndividual.addressId = [Address].addressID
END
GO
ALTER PROCEDURE SelectAllBusinessClients AS
BEGIN
	SELECT * FROM ClientBusiness
	INNER JOIN [Address] ON ClientBusiness.addressId = [Address].addressID
END
GO
ALTER PROCEDURE SelectIndividualClientById @id INT AS
BEGIN
	SELECT * FROM ClientIndividual
	INNER JOIN [Address] ON ClientIndividual.addressId = [Address].addressID
	WHERE ClientIndividual.clientIndividualID = @id
END
GO
ALTER PROCEDURE SelectAllContract AS
BEGIN
	SELECT * FROM [Contract]
END
GO
ALTER PROCEDURE SelectAllActiveContract AS
BEGIN
	SELECT * FROM [Contract]
	WHERE [activeContract] = '1'
END 
GO
ALTER PROCEDURE SelectAllServicePackedgesLinkedToContract @id INT AS
BEGIN
	SELECT * FROM ServicePackage
	INNER JOIN ServiceContractLink ON ServicePackage.servicePackageID = ServiceContractLink.ServicePackedgeID
	WHERE ServiceContractLink.contractID = @id
END
GO
ALTER PROCEDURE SelectAllServicePackedgesLinkedToContractState @id INT AS
BEGIN
	SELECT * FROM ServicePackageState
	INNER JOIN ServiceContractStateLink ON ServicePackageState.servicePackageStateID = ServiceContractStateLink.servicePackageStateID
	INNER JOIN [ContractState] ON ServiceContractStateLink.contractStateID = [ContractState].contractStateID
	WHERE [ContractState].contractStateID = @id
END
GO
ALTER PROC SelectAllContractsByIndividualClientId @id VARCHAR(100)
AS
    SELECT * FROM ContractState
    INNER JOIN ClientContractLink ON ContractState.contractStateID = ClientContractLink.ContractID
    INNER JOIN ClientIndividual ON ClientContractLink.ClientIndividualID = ClientIndividual.clientIndividualID
	INNER JOIN [Address] ON ClientIndividual.addressId = [Address].addressID
    WHERE ClientIndividual.clientIndividualClientNumber = @id
GO
ALTER PROC SelectContractByIndividualClientIdActive @id VARCHAR(100)
AS
    SELECT * FROM ContractState
    INNER JOIN ClientContractLink ON ContractState.contractStateID = ClientContractLink.ContractID
    INNER JOIN ClientIndividual ON ClientContractLink.ClientIndividualID = ClientIndividual.clientIndividualID
	INNER JOIN [Address] ON ClientIndividual.addressId = [Address].addressID
    WHERE ClientContractLink.ClientIndividualID = (SELECT clientIndividualID FROM ClientIndividual WHERE clientIndividualClientNumber = @id) AND ContractState.activeContract = '1'
GO
ALTER PROC SelectContractByIndividualClientIdAndContractId @clientId VARCHAR(50),@contractId VARCHAR(50)
AS
    SELECT * FROM ContractState
    INNER JOIN ClientContractLink ON ContractState.contractStateID = ClientContractLink.ContractID
    INNER JOIN ClientIndividual ON ClientContractLink.ClientIndividualID = ClientIndividual.clientIndividualID
	INNER JOIN [Address] ON ClientIndividual.addressId = [Address].addressID
    WHERE ClientIndividual.clientIndividualClientNumber = @clientId AND ContractState.contractNumber = @contractId
GO
ALTER PROC SelectAllContractsByBusinessClientId @id VARCHAR(100)
AS
    SELECT * FROM ContractState
    INNER JOIN ClientContractLink ON ContractState.contractStateID = ClientContractLink.ContractID
    INNER JOIN ClientBusiness ON ClientContractLink.clientBusinessID = ClientBusiness.clientBusinessID
	INNER JOIN [Address] ON ClientBusiness.addressId = [Address].addressID
    WHERE ClientBusiness.clientBusinessClientNumber = @id
GO
ALTER PROC SelectContractByBusinessClientIdActive @id VARCHAR(100)
AS
    SELECT * FROM ContractState
    INNER JOIN ClientContractLink ON ContractState.contractStateID = ClientContractLink.ContractID
    INNER JOIN ClientBusiness ON ClientContractLink.ClientBusinessID = ClientBusiness.clientBusinessID
	INNER JOIN [Address] ON ClientBusiness.addressId = [Address].addressID
    WHERE ClientContractLink.ClientBusinessID = (SELECT clientBusinessID FROM ClientBusiness WHERE clientBusinessClientNumber = @id) AND ContractState.activeContract = '1'
GO
ALTER PROC SelectAllContractsByBusinessClientIdAndContractId @clientId VARCHAR(50),@contractId VARCHAR(50)
AS
    SELECT * FROM ContractState
    INNER JOIN ClientContractLink ON ContractState.contractStateID = ClientContractLink.ContractID
    INNER JOIN ClientBusiness ON ClientContractLink.clientBusinessID = ClientBusiness.clientBusinessID
	INNER JOIN [Address] ON ClientBusiness.addressId = [Address].addressID
    WHERE ClientBusiness.clientBusinessClientNumber = @clientId AND ContractState.contractNumber = @contractId
GO
ALTER PROCEDURE SelectEmployees AS
BEGIN
	SELECT * FROM Employee
END
GO
ALTER PROCEDURE SelectAllJobs AS
BEGIN
	SELECT * FROM Job
END
GO
ALTER PROCEDURE SelectJobByJobId @id INT AS
BEGIN
	SELECT * FROM Job
	WHERE Job.jobID = @id
END
GO
ALTER PROCEDURE SelectAllPendingJobs AS
BEGIN
	SELECT * FROM Job
	WHERE currentState = '0'
END
GO
ALTER PROCEDURE SelectAllPendingJobsWithPriority AS
BEGIN
	SELECT * FROM Job
	INNER JOIN ServiceRequest ON Job.ServiceRequestID = ServiceRequest.serviceRequestID
	WHERE currentState = '0'
END
GO
ALTER PROCEDURE SelectAllJobsWithPriority AS
BEGIN
	SELECT * FROM Job
	INNER JOIN ServiceRequest ON Job.ServiceRequestID = ServiceRequest.serviceRequestID
END
GO
ALTER PROCEDURE SelectAllInProgressJobs AS
BEGIN
	SELECT * FROM Job
	WHERE currentState = '1'
END
GO
ALTER PROCEDURE SelectAllFinishedJobs AS
BEGIN
	SELECT * FROM Job
	WHERE currentState = '2'
END
GO
ALTER PROCEDURE SelectAllFinishedJobsByIndividualClientID @id VARCHAR(100) AS
BEGIN
	SELECT * FROM Job
	INNER JOIN ServiceRequest ON Job.ServiceRequestID = ServiceRequest.serviceRequestID
	INNER JOIN [Call] ON ServiceRequest.callID = [Call].callID
	INNER JOIN ClientIndividual ON [Call].ClientIndividualID = ClientIndividual.clientIndividualID
	WHERE ClientIndividual.clientIndividualClientNumber = @id AND Job.currentState = '2'
END
GO
ALTER PROCEDURE SelectAllFinishedJobsByBusinessClientID @id VARCHAR(100) AS
BEGIN
SELECT * FROM Job
INNER JOIN ServiceRequest ON Job.ServiceRequestID = ServiceRequest.serviceRequestID
INNER JOIN [Call] ON ServiceRequest.callID = [Call].callID
INNER JOIN ClientBusiness ON [Call].ClientIndividualID = ClientBusiness.clientBusinessID
WHERE ClientBusiness.clientBusinessClientNumber = @id AND Job.currentState = '2'
END
GO
ALTER PROCEDURE SelectAllServices AS
BEGIN
	SELECT * FROM Service
END
GO
ALTER PROCEDURE SelectAllServiceState AS
BEGIN
	SELECT * FROM ServiceState
END
GO
ALTER PROCEDURE SelectAllServicePackages AS
BEGIN
	SELECT * FROM ServicePackage
END
GO
ALTER PROCEDURE SelectAllServicePackageStates AS
BEGIN
	SELECT * FROM ServicePackageState
END
GO
ALTER PROCEDURE SelectAllServiceRequest AS
BEGIN
	SELECT * FROM ServiceRequest
END
GO
ALTER PROCEDURE SelectAllSpecialisations AS
BEGIN
	SELECT * FROM Specialisation
END
GO
ALTER PROCEDURE SelectAllSpecialisationName AS
BEGIN
	SELECT [name] FROM Specialisation
END
GO
ALTER PROCEDURE LinkContractAndClientBusinessAndIndividualBusiness @contractID INT, @clientBusinessID INT, @individualBusinessID INT
AS
	BEGIN TRAN
		INSERT INTO ClientContractLink(contractID,clientBusinessID,ClientIndividualID) VALUES (@contractID,@clientBusinessID,@individualBusinessID)
	COMMIT
GO
ALTER PROCEDURE InsertIndividualClientWithAddress @firstName VARCHAR(100), @surname VARCHAR(100), @contactNumber INT, @email VARCHAR(100), @nationalIdNumber INT, @registrationDate DATE, @streetname VARCHAR(100),@suburb VARCHAR(100),@province VARCHAR(20),@postalcode VARCHAR(20)
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
ALTER PROCEDURE SelectAllServiceInPackage @id INT AS
BEGIN
    SELECT * FROM Service as s
    INNER JOIN ServicePackageLink as spLink ON s.serviceID = spLink.ServiceID
    INNER JOIN ServicePackage as sp ON spLink.ServicePackageID = sp.servicePackageID
    WHERE sp.servicePackageID = @id
END
GO
ALTER PROCEDURE SelectAllServiceInPackageState @id INT AS
BEGIN
    SELECT * FROM ServiceState as s
    INNER JOIN ServicePackageStateLink as spLink ON s.serviceStateID = spLink.ServicePackageStateID
    INNER JOIN ServicePackageState as sp ON spLink.ServicePackageStateID = sp.servicePackageStateID
    WHERE sp.servicePackageStateID = @id
END
GO
ALTER PROCEDURE SelectAllServicePackagesInContract @id INT AS
BEGIN
    SELECT * FROM ServicePackage as s
    INNER JOIN ServiceContractLink as scLink ON s.servicePackageID = scLink.ServicePackedgeID
    INNER JOIN Contract as c ON scLink.ContractID = c.contractID
    WHERE c.contractID = @id
END
GO
ALTER PROCEDURE SelectAllServicePackagesInContractState @id INT AS
BEGIN
    SELECT * FROM ServicePackageState as s
    INNER JOIN ServiceContractStateLink as scLink ON s.servicePackageStateID = scLink.ServicePackageStateID
    INNER JOIN ContractState as c ON scLink.contractStateID = c.contractStateID
    WHERE c.contractStateID = @id
END
GO
ALTER PROCEDURE SelectAllServicesAndPackagesInContract @id INT AS
BEGIN
    SELECT * FROM Service as s
    INNER JOIN ServicePackageLink as spLink ON s.serviceID = spLink.ServiceID
    INNER JOIN ServicePackage as sp ON spLink.ServicePackageID = sp.servicePackageID
    INNER JOIN ServiceContractLink as scLink ON scLink.ServicePackedgeID = sp.servicePackageID
    INNER JOIN Contract as c ON scLink.ContractID = c.contractID
    WHERE c.contractID = @id
END
GO
ALTER PROCEDURE SelectBusinessClientEmployees AS
BEGIN
	SELECT * FROM ClientBusinessEmployee
END
GO
ALTER PROCEDURE SelectAllContracts AS
BEGIN
	SELECT * FROM "Contract"
END
GO
ALTER PROCEDURE SelectContractByID @id VARCHAR(50) AS
BEGIN
	SELECT * FROM "Contract" WHERE contractID = (SELECT contractID FROM [Contract] WHERE contractNumber = @id)
END
GO
ALTER PROCEDURE SelectAllActiveContracts AS
BEGIN
	SELECT * FROM "Contract" WHERE [activeContract] = '1'
END
GO
ALTER PROCEDURE SelectCallCenterEmployees AS
BEGIN
	SELECT * FROM Employee
	INNER JOIN [Address] ON Employee.addressId = [Address].addressID
	WHERE department = 'Call Center'
END
GO
ALTER PROCEDURE SelectCallCenterEmployeeByCallId @id INT AS
BEGIN
	SELECT * FROM Employee
	INNER JOIN [Address] ON Employee.addressId = [Address].addressID
	INNER JOIN [Call] ON Employee.employeeID = [Call].employeeID
	WHERE [Call].callID = @id
END
GO
ALTER PROCEDURE SelectServiceManagers AS
BEGIN
	SELECT * FROM Employee
	INNER JOIN [Address] ON Employee.addressId = [Address].addressID
	WHERE department = 'Service Manager'
END
GO
ALTER PROCEDURE SelectMaintenanceEmployees AS
BEGIN
	SELECT * FROM Employee
	INNER JOIN [Address] ON Employee.addressId = [Address].addressID
	WHERE department = 'Maintenance'
END
GO
ALTER PROCEDURE SelectMaintenanceEmployeesAccordingToSpecinization @specilization INT
AS
BEGIN
	SELECT * FROM Employee
	INNER JOIN [Address] ON Employee.addressId = [Address].addressID
	INNER JOIN SpecialisationEmployeeLink ON Employee.employeeID = SpecialisationEmployeeLink.employeeID
	INNER JOIN Specialisation ON SpecialisationEmployeeLink.specialisationID = Specialisation.specialisationID
	WHERE department = 'Maintenance' AND Specialisation.specialisationID = @specilization
END
GO
ALTER PROCEDURE SelectAvailableMaintenanceEmployees AS
BEGIN
	SELECT * FROM Employee
	LEFT JOIN JobEmployeeLink ON Employee.employeeID = JobEmployeeLink.employeeID
	LEFT JOIN Job ON JobEmployeeLink.jobID = Job.jobID
	INNER JOIN [Address] ON Employee.addressId = [Address].addressID
	WHERE Employee.department = 'Maintenance' AND (Job.currentState = 2 OR Job.currentState IS NULL)
END
GO
ALTER PROCEDURE SelectAllBusinessClientEmployeeWithBusinessName @businessName VARCHAR(100) AS
BEGIN
	SELECT * FROM ClientBusinessEmployee
	INNER JOIN ClientBusiness as CB
	ON CB.clientBusinessID = ClientBusinessEmployee.businessID
	WHERE CB.busuinessName = @businessName
END
GO
ALTER PROCEDURE SelectAvailableEmployeesOfMaintenance AS
BEGIN

    SELECT * FROM Employee 
    WHERE Employee.employeeID NOT IN (SELECT employeeID FROM JobEmployeeLink) AND Employee.department = 'Maintenance'
END
GO
ALTER PROCEDURE SelectAvailableEmployeesOfCallCenter AS
BEGIN

    SELECT * FROM Employee 
    WHERE Employee.employeeID NOT IN (SELECT employeeID FROM JobEmployeeLink) AND Employee.department = 'Call Center'
END
GO
ALTER PROCEDURE SelectAvailableEmployeesOfServiceManager AS
BEGIN

    SELECT * FROM Employee 
    WHERE Employee.employeeID NOT IN (SELECT employeeID FROM JobEmployeeLink) AND Employee.department = 'Service Manager'
END
GO
ALTER PROCEDURE SelectAllSpecilisationbyServiceRequest @id INT
AS
	SELECT * FROM Specialisation
	INNER JOIN ServiceRequestSpecialisationLink ON Specialisation.specialisationID = ServiceRequestSpecialisationLink.specialisationRequiredID
	INNER JOIN ServiceRequest ON ServiceRequestSpecialisationLink.ServiceRequestID = ServiceRequest.serviceRequestID
	WHERE ServiceRequest.serviceRequestID = @id
GO
ALTER PROCEDURE SelectAddressById @id INT
AS
	SELECT * FROM [Address]
	WHERE [Address].addressID = @id
GO
ALTER PROCEDURE GetMaintenanceEmployeeByJobId @id INT
AS
	SELECT * FROM Employee
	INNER JOIN JobEmployeeLink ON Employee.employeeID = JobEmployeeLink.employeeID
	INNER JOIN Job ON JobEmployeeLink.jobID = Job.jobID
	WHERE Job.jobID = @id AND department = 'Maintenance'
GO
ALTER PROCEDURE SelectAllServicesByServicePackedge @id INT
AS
BEGIN TRAN
	SELECT * FROM [Service]
	INNER JOIN ServicePackageLink ON [Service].serviceID = ServicePackageLink.ServiceID
	INNER JOIN ServicePackage ON ServicePackageLink.ServicePackageID = ServicePackage.servicePackageID
	WHERE ServicePackage.servicePackageID = @id
COMMIT
GO
ALTER PROCEDURE SelectAllServicesByServicePackedgeWithState @id INT
AS
BEGIN TRAN
	SELECT * FROM [ServiceState]
	INNER JOIN ServicePackageStateLink ON [ServiceState].serviceStateID = ServicePackageStateLink.ServiceStateID
	INNER JOIN ServicePackageState ON ServicePackageStateLink.ServicePackageStateID = ServicePackageState.servicePackageStateID
	WHERE ServicePackageState.servicePackageStateID = @id
COMMIT
GO
ALTER PROCEDURE SelectSpecialisationById @id INT
AS
BEGIN TRAN
	SELECT * FROM [Specialisation]
	WHERE [Specialisation].specialisationID = @id
COMMIT
GO
ALTER PROCEDURE SelectSpecialisationByEmployeeId @id INT
AS
BEGIN TRAN
	SELECT * FROM [Specialisation]
	INNER JOIN SpecialisationEmployeeLink ON Specialisation.specialisationID = SpecialisationEmployeeLink.specialisationID
	INNER JOIN Employee ON SpecialisationEmployeeLink.employeeID = Employee.employeeID
	WHERE Employee.employeeID = @id
COMMIT
GO
ALTER PROCEDURE GetSpecialisationOfEmployeeByEmployeeId @id INT
AS
BEGIN TRAN
	SELECT * FROM [Specialisation]
	INNER JOIN [SpecialisationEmployeeLink] ON [Specialisation].specialisationID = [SpecialisationEmployeeLink].specialisationID
	INNER JOIN [Employee] ON [SpecialisationEmployeeLink].employeeID = [Employee].employeeID
	WHERE [Employee].employeeID = @id
COMMIT
GO
ALTER PROCEDURE CountClients
AS
BEGIN TRAN
	SELECT COUNT(clientIndividualID) FROM ClientIndividual
COMMIT
GO
ALTER PROCEDURE SelectCallsForClientIndividual @id INT
AS
BEGIN TRAN
	SELECT * FROM [Call]
	WHERE [Call].ClientIndividualID = @id
COMMIT
GO
ALTER PROCEDURE SelectCallsForClientBusiness @id INT
AS
BEGIN TRAN
	SELECT * FROM [Call]
	WHERE [Call].ClientBusinessID = @id
COMMIT
GO

--CountUses
ALTER PROCEDURE SpecialisationUses @id INT
AS
BEGIN TRAN
	DECLARE @count INT
	SET @count = (SELECT COUNT(specialisationID) FROM Job WHERE specialisationID = @id) + (SELECT COUNT(specialisationID) FROM SpecialisationEmployeeLink WHERE specialisationID = @id) + (SELECT COUNT(specialisationRequiredID) FROM ServiceRequestSpecialisationLink WHERE specialisationRequiredID = @id)
	SELECT @count AS uses
COMMIT
GO
ALTER PROCEDURE AddressUses @id INT
AS
BEGIN TRAN
	DECLARE @count INT
	SET @count = (SELECT COUNT(addressId) FROM Job WHERE addressId = @id) + (SELECT COUNT(addressId) FROM Employee WHERE addressId = @id) + (SELECT COUNT(addressId) FROM ClientBusiness WHERE addressId = @id) + (SELECT COUNT(addressId) FROM ClientIndividual WHERE addressId = @id)
	SELECT @count AS uses
COMMIT
GO
ALTER PROCEDURE AllContractUses
AS
BEGIN TRAN
	SELECT oldContractId AS id,COUNT(contractStateID) AS uses FROM ContractState
	GROUP BY oldContractId
	ORDER BY uses DESC
COMMIT
GO
ALTER PROCEDURE UpdateEmployeeWithSpecilizationList @id VARCHAR(50)
AS
BEGIN
	BEGIN TRAN

		DELETE FROM SpecialisationEmployeeLink
		WHERE SpecialisationEmployeeLink.employeeID = (SELECT employeeID FROM Employee WHERE employeeNumber= @id)

		INSERT INTO SpecialisationEmployeeLink(employeeID,specialisationID)
		SELECT idIntOne,idIntTwo FROM TVP

		DELETE FROM TVP

	COMMIT
END
GO
ALTER PROCEDURE GetAllErrors
AS
BEGIN TRAN
	SELECT * FROM DatabaseOperation
COMMIT
GO
ALTER PROCEDURE SelectAllIndividualClientById @id VARCHAR(50) AS 
BEGIN
	SELECT * FROM ClientIndividual
	INNER JOIN [Address] ON ClientIndividual.addressId = [Address].addressID
	WHERE clientIndividualClientNumber = @id
END
GO
ALTER PROCEDURE SelectAllBusinessClientById @id VARCHAR(50) AS
BEGIN
	SELECT * FROM ClientBusiness
	INNER JOIN [Address] ON ClientBusiness.addressId = [Address].addressID
	WHERE clientBusinessClientNumber = @id
END
GO
ALTER PROC CountActiveContractsOfIndividualClientId @id VARCHAR(100)
AS
    SELECT COUNT(ContractID) FROM ClientContractLink
    INNER JOIN ClientIndividual ON ClientContractLink.ClientIndividualID = ClientIndividual.clientIndividualID
    WHERE ClientIndividual.clientIndividualClientNumber = @id AND active = '1'
GO
ALTER PROC CountActiveContractsOfBusinessClientId @id VARCHAR(100)
AS
    SELECT COUNT(ContractID) FROM ClientContractLink
    INNER JOIN ClientBusiness ON ClientContractLink.ClientBusinessID = ClientBusiness.clientBusinessID
    WHERE ClientBusiness.clientBusinessClientNumber = @id AND active = '1'
GO
ALTER PROC SelectJobsNotFinished
AS
SELECT * FROM Job
WHERE Job.currentState = 0 OR Job.currentState = 1
GO