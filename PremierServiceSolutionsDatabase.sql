USE MASTER
GO
if exists (SELECT * FROM sysdatabases WHERE NAME='PremierServiceSolutionsDatabase') --- Uses sysdatabases And master to check if PSSDatabase already exists and drops it if it does.
		drop database PremierServiceSolutionsDatabase
GO

--- Creates Database PSSDatabase
DECLARE @device_directory NVARCHAR(520)
SELECT @device_directory = SUBSTRING(FILENAME, 1, CHARINDEX(N'master.mdf', LOWER(FILENAME)) - 1)
FROM MASTER.dbo.sysaltfiles WHERE DBID = 1 AND fileid = 1

EXECUTE (N'CREATE DATABASE PremierServiceSolutionsDatabase
  ON PRIMARY (NAME = N''PremierServiceSolutionsDatabase'', FILENAME = N''' + @device_directory + N'PremierServiceSolutionsDatabase.mdf''),
  FILEGROUP SECONDARY(NAME = N''PremierServiceSolutionsDatabase_Backup'', FILENAME = N''' + @device_directory + N'PremierServiceSolutionsDatabase_Backup.ndf'')
  LOG ON (NAME = N''PremierServiceSolutionsDatabase_log'',  FILENAME = N''' + @device_directory + N'PremierServiceSolutionsDatabase.ldf'')')
GO	
ALTER DATABASE PremierServiceSolutionsDatabase SET AUTO_SHRINK ON 
ALTER DATABASE PremierServiceSolutionsDatabase SET RECOVERY SIMPLE
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

USE PremierServiceSolutionsDatabase
GO

----Tables----
CREATE TABLE DatabaseOperation
	(
	errorID INT NOT NULL IDENTITY(1,1)  PRIMARY KEY,
	dateAndTime DATETIME NOT NULL,
	success INT NOT NULL,
	"description" VARCHAR(2000) NOT NULL
	);
	GO
CREATE TABLE TVP
	(
	idIntOne INT NULL,
	idIntTwo INT NULL,
	idIntThree INT NULL
	);
GO
CREATE TABLE "Address"
	(
	addressID INT NOT NULL IDENTITY(1,1)  PRIMARY KEY,
	streetName VARCHAR(100) NOT NULL,
	suburb VARCHAR(100) NOT NULL,
	city VARCHAR(100) NOT NULL,
	province CHAR(1) NOT NULL,
	postalcode CHAR(4) NOT NULL
	);
	GO

CREATE TABLE Employee
	(
	employeeID INT NOT NULL IDENTITY(1,1)  PRIMARY KEY,
	employeeNumber VARCHAR(100),
	firstName VARCHAR(50) NOT NULL,
	surname VARCHAR(50) NOT NULL,
	addressId INT NOT NULL FOREIGN KEY (addressId) REFERENCES "Address" (addressID),
	contactNumber VARCHAR(10) NULL,
	email VARCHAR(100) NULL,
	nationalIdNumber VARCHAR(13) NOT NULL,
	employmentDate DATE NOT NULL,
	employed INT NOT NULL,
	department VARCHAR(25) NOT NULL
	);
	GO
CREATE TABLE Specialisation
	(
	specialisationID INT NOT NULL IDENTITY(1,1)  PRIMARY KEY,
	"name" VARCHAR(25) NOT NULL,
	"description" VARCHAR(250) NULL
	);
	GO
CREATE TABLE ClientIndividual
	(
	clientIndividualID INT NOT NULL IDENTITY(1,1)  PRIMARY KEY,
	clientIndividualClientNumber VARCHAR(100),
	firstName VARCHAR(50) NOT NULL,
	surname VARCHAR(50) NOT NULL,
	addressId INT NOT NULL FOREIGN KEY (addressId) REFERENCES "Address" (addressID),
	contactNumber VARCHAR(100) NULL,
	email VARCHAR(100) NULL,
	nationalIdNumber VARCHAR(13) NOT NULL,
	RegistrationDate DATE NOT NULL,
	active INT NOT NULL,
	);
	GO
CREATE TABLE ClientBusiness
	(
	clientBusinessID INT NOT NULL identity(1,1)  PRIMARY KEY,
	clientBusinessClientNumber VARCHAR(100),
	busuinessName VARCHAR(50) NOT NULL,
	addressId INT NOT NULL FOREIGN KEY (addressId) REFERENCES "Address" (addressID),
	contactNumber VARCHAR(10) NOT NULL,
	taxNumber VARCHAR(10) NOT NULL,
	RegistrationDate DATE NOT NULL,
	active INT NOT NULL,
	);
	GO
CREATE TABLE ServicePackageState
	(
	servicePackageStateID INT NOT NULL IDENTITY(1,1)  PRIMARY KEY,
	"name" VARCHAR(50) NOT NULL,
	onPromotion INT NOT NULL,
	promotionPercentAmount FLOAT NOT NULL,
	promotionStartDate DATETIME NOT NULL,
	promotionEndDate DATETIME NULL,
	price FLOAT NOT NULL
	);
	GO
CREATE TABLE ServicePackage
	(
	servicePackageID INT NOT NULL IDENTITY(1,1)  PRIMARY KEY,
	"name" VARCHAR(50) NOT NULL,
	onPromotion INT NOT NULL,
	promotionPercentAmount FLOAT NOT NULL,
	promotionStartDate DATETIME NOT NULL,
	promotionEndDate DATETIME NULL,
	price FLOAT NOT NULL
	);
	GO
CREATE TABLE "Service"
	(
	serviceID INT NOT NULL IDENTITY(1,1)  PRIMARY KEY,
	"name" VARCHAR(50) NOT NULL,
	"description" VARCHAR(255) NULL
	);
	GO
CREATE TABLE "ServiceState"
	(
	serviceStateID INT NOT NULL IDENTITY(1,1)  PRIMARY KEY,
	"name" VARCHAR(50) NOT NULL,
	"description" VARCHAR(255) NULL
	);
	GO
CREATE TABLE SpecialisationEmployeeLink
	(
	employeeID INT NOT NULL FOREIGN KEY(employeeID) REFERENCES Employee (employeeID),
	specialisationID INT NOT NULL FOREIGN KEY (specialisationID) REFERENCES Specialisation (specialisationID),
	);
	GO
CREATE TABLE "Call"
	(
	callID INT NOT NULL IDENTITY(1,1)  PRIMARY KEY,
	startTime DATETIME NOT NULL,
	endTime DATETIME NULL,
	ClientIndividualID INT NULL FOREIGN KEY (ClientIndividualID) REFERENCES ClientIndividual (clientIndividualID),
	ClientBusinessID INT NULL FOREIGN KEY (ClientBusinessID) REFERENCES ClientBusiness (clientBusinessID),
	employeeID INT NOT NULL FOREIGN KEY (employeeID) REFERENCES Employee (employeeID),
	callNotes VARCHAR(255) NULL
	);
	GO
CREATE TABLE ServiceRequest
	(
	serviceRequestID INT NOT NULL IDENTITY(1,1)  PRIMARY KEY,
	callID INT NOT NULL FOREIGN KEY (callID) REFERENCES [Call] (callID),
	closed INT NOT NULL,
	"description" VARCHAR(255) NULL,
	priorityLevel VARCHAR (20) NOT NULL

	);
GO
CREATE TABLE ServiceRequestSpecialisationLink
(
specialisationRequiredID INT NOT NULL FOREIGN KEY (specialisationRequiredID) REFERENCES Specialisation (specialisationID),
ServiceRequestID INT NOT NULL FOREIGN KEY (ServiceRequestID) REFERENCES ServiceRequest (serviceRequestID)

);
GO
CREATE TABLE Job
	(
	jobID int NOT NULL IDENTITY(1,1)  PRIMARY KEY,
	addressId INT NOT NULL FOREIGN KEY (addressId) REFERENCES "Address" (addressID),
	ServiceRequestID INT NOT NULL FOREIGN KEY (ServiceRequestID) REFERENCES ServiceRequest (serviceRequestID),
	notes VARCHAR(255) NULL,
	currentState VARCHAR(20) NOT NULL,
	specialisationId INT NOT NULL FOREIGN KEY (specialisationId) REFERENCES Specialisation (specialisationID),
	amountOfEmployeesNeeded INT NOT NULL,
	);
	GO
CREATE TABLE ServiceRequestJobLink
	(
	serviceRequestID INT NOT NULL FOREIGN KEY(serviceRequestID) REFERENCES ServiceRequest (serviceRequestID),
	jobID INT NOT NULL FOREIGN KEY (jobID) REFERENCES Job (jobID)
	);
	GO
CREATE TABLE JobEmployeeLink
	(
	employeeID INT NOT NULL FOREIGN KEY (employeeID) REFERENCES Employee (employeeID),
	jobID INT NOT NULL FOREIGN KEY (jobID) REFERENCES Job (jobID)
	);
	GO
CREATE TABLE "Contract"
	(
	contractID INT NOT NULL IDENTITY(1,1)  PRIMARY KEY,
	contractNumber VARCHAR(100),
	startDate DATETIME NOT NULL,
	endDate DATETIME NULL,
	activeContract INT NOT NULL,
	priorityLevel VARCHAR (20) NOT NULL,
	price FLOAT NOT NULL,
	contractType VARCHAR(15) NOT NULL
	);
	GO
CREATE TABLE "ContractState"
	(
	contractStateID INT NOT NULL IDENTITY(1,1)  PRIMARY KEY,
	contractNumber VARCHAR(100),
	startDate DATETIME NOT Null,
	endDate DATETIME NULL,
	activeContract INT NOT NULL,
	priorityLevel VARCHAR (20) NOT NULL,
	price FLOAT NOT NULL,
	contractType VARCHAR(15) NOT NULL
	);
	GO
CREATE TABLE ClientBusinessEmployee
	(
	clientBusinessEmployeeID INT NOT NULL identity(1,1)  PRIMARY KEY,
	businessID INT NOT NULL FOREIGN KEY (businessID) REFERENCES ClientBusiness (clientBusinessID),
	firstName VARCHAR(50) NOT NULL,
	surname VARCHAR(50) NOT NULL,
	department VARCHAR(50) NOT NULL,
	contactNumber VARCHAR(10) NULL,
	email VARCHAR(100) NULL
	);
	GO
CREATE TABLE ServiceContractStateLink
	(
	contractStateID INT NOT NULL FOREIGN KEY (contractStateID) REFERENCES ContractState (contractStateID),
	ServicePackageStateID INT NOT NULL FOREIGN KEY (ServicePackageStateID) REFERENCES ServicePackageState (servicePackageStateID)
	);
	GO
CREATE TABLE ServiceContractLink
	(
	ContractID INT NOT NULL FOREIGN KEY (ContractID) REFERENCES [Contract] (contractID),
	ServicePackedgeID INT NOT NULL FOREIGN KEY (ServicePackedgeID) REFERENCES ServicePackage(servicePackageID)
	);
	GO
CREATE TABLE ServicePackageStateLink
	(
	ServicePackageStateID INT NOT NULL FOREIGN KEY (ServicePackageStateID) REFERENCES ServicePackageState (servicePackageStateID),
	ServiceStateID INT NOT NULL FOREIGN KEY (ServiceStateID) REFERENCES ServiceState (serviceStateID)
	);
	GO
CREATE TABLE ServicePackageLink
	(
	ServicePackageID INT NOT NULL FOREIGN KEY (ServicePackageID) REFERENCES ServicePackage (servicePackageID),
	ServiceID INT NOT NULL FOREIGN KEY (ServiceID) REFERENCES [Service] (serviceID)
	);
	GO
CREATE TABLE ClientContractLink
	(
	ContractID INT NOT NULL FOREIGN KEY (ContractID) REFERENCES [ContractState] (contractStateID),
	ClientBusinessID INT NULL FOREIGN KEY (ClientBusinessID) REFERENCES ClientBusiness (clientBusinessID),
	ClientIndividualID INT NULL FOREIGN KEY (ClientIndividualID) REFERENCES ClientIndividual (clientIndividualID)
	);
	GO

---CREATE FUNCTIONS
CREATE FUNCTION IndividualClientNumber (@id INT) 
returns char(9) 
AS 
BEGIN 
RETURN 'A' + RIGHT('00000000' + CONVERT(VARCHAR(10), @id), 8) 
END
GO

CREATE FUNCTION EmployeeNumber (@id INT) 
returns char(9) 
AS 
BEGIN 
RETURN 'E' + RIGHT('00000000' + CONVERT(VARCHAR(10), @id), 8) 
END
GO

CREATE FUNCTION BusinessClientNumber (@id INT) 
returns char(9) 
AS 
BEGIN 
RETURN 'B' + RIGHT('00000000' + CONVERT(VARCHAR(10), @id), 8) 
END
GO
CREATE FUNCTION ContractNumber (@id INT,@priority VARCHAR(20)) 
returns char(13) 
AS 
BEGIN 
RETURN 'C' + CAST(YEAR(GETDATE()) AS VARCHAR) + 'Z' + LEFT(@priority,1) + RIGHT('000000' + CONVERT(VARCHAR(10), @id), 6) 
END
GO
---CREATE TRIGGER
CREATE TRIGGER IndividualClient_insert ON ClientIndividual
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

CREATE TRIGGER Employee_insert ON Employee
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

CREATE TRIGGER BusinessClient_insert ON ClientBusiness 
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
CREATE TRIGGER Contract_insert ON [Contract] 
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
CREATE TRIGGER ContractState_insert ON ContractState 
AFTER INSERT AS 
UPDATE 
    ContractState 
set 
    ContractState.contractNumber = dbo.ContractNumber(ContractState.contractStateID,ContractState.priorityLevel) 
from 
    [Contract] 
INNER JOIN 
    inserted ON [Contract].contractID= inserted.contractStateID
GO

GO
--Create ErorLog
CREATE PROC CreateDatabaseOperationLog @dateTime DATETIME, @description VARCHAR(2000), @success INT
AS
	BEGIN TRAN
		INSERT INTO DatabaseOperation ([dateAndTime],[description],[success]) VALUES (@dateTime,@description,@success)
	COMMIT
GO
CREATE PROC GetAllDatabaseOperations
AS
	BEGIN TRAN
		SELECT * FROM DatabaseOperation
	COMMIT
GO

--DELETE Procedures
CREATE PROC DeleteServiceRequest @id INT
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
CREATE PROC InsertIntoTVPServiceRequestSpecilization @serviceRequestId INT,@SpecilizationId INT
AS
	BEGIN TRAN
		INSERT INTO TVP(idIntOne,idIntTwo)
		VALUES (@serviceRequestId,@SpecilizationId)
	COMMIT
GO
CREATE PROC InsertIntoTVPNewServiceRequestSpecilization @SpecilizationId INT
AS
	BEGIN TRAN
		INSERT INTO TVP(idIntOne)
		VALUES (@SpecilizationId)
	COMMIT
GO
CREATE PROC InsertIntoTVPJobEmployee @jobId INT,@employeeId VARCHAR(50)
AS
	BEGIN TRAN
		INSERT INTO TVP(idIntOne,idIntTwo)
		VALUES (@jobId,(SELECT Employee.employeeID FROM Employee WHERE Employee.employeeNumber = @employeeId))
	COMMIT
GO
CREATE PROC InsertIntoTVPNewJobEmployee @employeeId VARCHAR(50)
AS
	BEGIN TRAN
		INSERT INTO TVP(idIntOne)
		VALUES ((SELECT Employee.employeeID FROM Employee WHERE Employee.employeeNumber = @employeeId))
	COMMIT
GO
CREATE PROC InsertIntoTVPNewContractServicePackedge @packedgeId VARCHAR(50)
AS
	BEGIN TRAN
		INSERT INTO TVP(idIntOne)
		VALUES (@packedgeId)
	COMMIT
GO
CREATE PROC InsertIntoTVPPackedgeService @packedgeId INT,@serviceId INT
AS
	BEGIN TRAN
		INSERT INTO TVP(idIntOne,idIntTwo)
		VALUES (@packedgeId,@serviceId)
	COMMIT
GO
CREATE PROC InsertIntoTVPContractServicePackage @contractId VARCHAR(50),@servicePackageId INT
AS
	BEGIN TRAN
		INSERT INTO TVP(idIntOne,idIntTwo)
		VALUES ((SELECT contractID FROM [Contract] WHERE contractNumber = @contractId),@servicePackageId)
	COMMIT
GO

--DELETE Procedures
CREATE PROC DeleteJob @id INT
AS
	BEGIN TRAN
		DELETE FROM JobEmployeeLink
		WHERE jobID IN (SELECT Job.jobID FROM Job WHERE Job.jobID = @id)

		DELETE FROM Job
		WHERE jobID = @id
	COMMIT
GO
CREATE PROC DeleteClientBusinessEmployee @id INT 
AS
	BEGIN TRAN
		DELETE FROM ClientBusinessEmployee
		WHERE clientBusinessEmployeeID = @id
	COMMIT
GO
CREATE PROC DeleteService @id INT
AS
	BEGIN TRAN
		DELETE FROM ServicePackageLink
		WHERE serviceID IN (SELECT serviceID FROM [Service] WHERE serviceID = @id)

		DELETE FROM [Service]
		WHERE serviceID = @id
	COMMIT
GO
CREATE PROC DeleteServicePackage @id INT
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
CREATE PROC DeleteContract @id VARCHAR(50)
AS
	BEGIN TRAN
		DELETE FROM ServiceContractLink
		WHERE ContractID IN (SELECT contractID FROM [Contract] WHERE contractNumber = @id)

		DELETE FROM [Contract]
		WHERE contractID = (SELECT contractID FROM [Contract] WHERE contractNumber = @id)
	COMMIT
GO
CREATE PROC DeleteSpecialisation @id INT 
AS
	BEGIN TRAN
		DELETE FROM Specialisation
		WHERE specialisationID = @id
	COMMIT
GO
CREATE PROC DeleteAddress @id INT 
AS
	BEGIN TRAN
		DELETE FROM Address
		WHERE addressID = @id
	COMMIT
GO

--UPDATE Procedures
CREATE PROCEDURE UpdateAddress @id INT, @streetName VARCHAR(100), @suburb VARCHAR(100), @province VARCHAR(20), @postalcode VARCHAR(10),@city VARCHAR(40)
AS
BEGIN
	BEGIN TRAN
	UPDATE Address
	SET streetName = @streetName, suburb = @suburb, province = @province, postalcode = @postalcode, city = @city
	WHERE addressID = @id

	COMMIT
END
GO
CREATE PROCEDURE UpdateCallNotes @id INT, @callnotes VARCHAR(255)
AS
BEGIN
	BEGIN TRAN

	UPDATE Call
	SET callNotes = @callnotes
	WHERE callID = @id

	COMMIT
END
GO 
CREATE PROCEDURE UpdateEndTime @id INT, @endTime DATETIME
AS
BEGIN
	BEGIN TRAN

	UPDATE Call
	SET endTime = @endTime
	WHERE callID = @id

	COMMIT
END
GO 
CREATE PROCEDURE UpdateCallClientIndividual @id INT, @ClientIndividual VARCHAR(50)
AS
BEGIN
	BEGIN TRAN
		UPDATE Call
		SET ClientIndividualID = (SELECT clientIndividualID FROM ClientIndividual WHERE clientIndividualClientNumber = @ClientIndividual)
		WHERE callID = @id
	COMMIT
END
GO
CREATE PROCEDURE UpdateCallClientBusiness @id INT, @ClientBusiness VARCHAR(50)
AS
BEGIN
	BEGIN TRAN
		UPDATE Call
		SET ClientBusinessID = (SELECT clientIndividualID FROM ClientIndividual WHERE clientIndividualClientNumber = @ClientBusiness)
		WHERE callID = @id
	COMMIT
END
GO
CREATE PROCEDURE UpdateBusinessClientEmployee @id Int, @firstName  VARCHAR(50), @surname VARCHAR(50), @department VARCHAR(50), @contactNumber VARCHAR(10), @email VARCHAR(100)
AS
BEGIN
	BEGIN TRAN
	UPDATE ClientBusinessEmployee
	SET firstName = @firstName, surname = @surname, department = @department, contactNumber = @contactNumber, email = @email
	WHERE clientBusinessEmployeeID = @id
	COMMIT
END
GO

CREATE PROCEDURE UpdateBusinessClientState @id VARCHAR(20), @active INT
AS
BEGIN
	BEGIN TRAN
	UPDATE ClientBusiness
	SET active = @active
	WHERE clientBusinessClientNumber = @id
	COMMIT
END
GO

CREATE PROCEDURE UpdateClientBusiness @id VARCHAR(100), @businessName VARCHAR(50), @contact VARCHAR(10), @taxnumber VARCHAR(10), @registrationDate DATE, @active INT, @adressid INT, @streetName VARCHAR(100), @suburb VARCHAR(100), @province VARCHAR(20), @postalcode VARCHAR(10),@city VARCHAR(100)
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

CREATE PROCEDURE UpdateClientIndividual @id VARCHAR(100), @firstname VARCHAR(100), @surname VARCHAR(100), @contact VARCHAR(10), @email VARCHAR(100), @nationalid VARCHAR(13), @registrationdate DATE, @active INT, @adressid INT, @streetName VARCHAR(100), @suburb VARCHAR(100), @province VARCHAR(20), @postalcode VARCHAR(10),@city VARCHAR(100)
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
CREATE PROCEDURE UpdateClientIndividualCurrentState @id VARCHAR(100), @active INT
AS
BEGIN
	BEGIN TRAN

	UPDATE ClientIndividual
	SET active = @active
	WHERE clientIndividualClientNumber = @id
	COMMIT
END
GO
CREATE PROCEDURE UpdateContract @id VARCHAR(50), @startdate DATE, @endtime DATE, @active INT, @priorityLevel VARCHAR(20), @price FLOAT, @contractType VARCHAR(15)
AS
BEGIN

	BEGIN TRAN

	UPDATE Contract
	SET startDate = @startdate, endDate = @endtime, [activeContract] = @active, priorityLevel = @priorityLevel, price = @price, contractType = @contractType
	WHERE contractID = (SELECT contractID FROM [Contract] WHERE contractNumber = @id)

	COMMIT

END
GO
CREATE PROCEDURE UpdateOfferedContractActive @id VARCHAR(50), @active INT
AS
BEGIN

	BEGIN TRAN

	UPDATE Contract
	SET [activeContract] = @active
	WHERE contractID = (SELECT contractID FROM [Contract] WHERE contractNumber = @id)

	COMMIT

END
GO
CREATE PROCEDURE UpdateClientContractActive @id VARCHAR(50), @active INT
AS
BEGIN

	BEGIN TRAN

	UPDATE [ContractState]
	SET [activeContract] = @active
	WHERE contractStateID = (SELECT contractID FROM [Contract] WHERE contractNumber = @id)

	COMMIT

END
GO
CREATE PROCEDURE UpdateOfferedContractActiveAndDateRange @id VARCHAR(50), @active INT,@dateStart DATETIME,@dateEnd DATETIME
AS
BEGIN

	BEGIN TRAN

	UPDATE [Contract]
	SET [activeContract] = @active,startDate = @dateStart, endDate = @dateEnd
	WHERE contractID = (SELECT contractID FROM [Contract] WHERE contractNumber = @id)

	COMMIT

END
GO
CREATE PROCEDURE UpdateCallCenterEmployee @id VARCHAR(50), @firstName VARCHAR(50), @surname VARCHAR(100), @contactNumber VARCHAR(10), @email VARCHAR(100), @nationalIdNumber VARCHAR(13), @employmentdate DATE, @employed BIT, @department VARCHAR(25), @adressid INT, @streetName VARCHAR(100), @suburb VARCHAR(100), @province VARCHAR(20), @postalcode VARCHAR(10), @city VARCHAR(100)
AS
BEGIN
	BEGIN TRAN

	UPDATE Employee
	SET firstName = @firstName, surname = @surname, addressId = @adressid, contactNumber = @contactNumber, email = @email, nationalIdNumber = @nationalIdNumber,  employmentDate = @employmentdate, employed = @employed, department = @department
	WHERE employeeID = @id

	UPDATE [Address]
	SET streetName = @streetName, suburb = @suburb, province = @province, postalcode = @postalcode,city = @city
	WHERE addressID = @adressid

	COMMIT
END
GO
CREATE PROCEDURE UpdateJob @id INT, @notes VARCHAR(255), @specialisationId INT, @adressid INT, @streetName VARCHAR(100), @suburb VARCHAR(100), @province VARCHAR(20), @postalcode VARCHAR(10),@city VARCHAR(100)
AS
BEGIN
	BEGIN TRAN
		UPDATE Job
		SET addressId = @adressid, notes = @notes, specialisationId = @specialisationId
		WHERE jobID = @id

		UPDATE [Address]
		SET streetName = @streetName, suburb = @suburb, province = @province, postalcode = @postalcode,city = @city
		WHERE addressID = @adressid
	COMMIT
END
GO
CREATE PROC UpdateJobEmployeeList @id INT
AS
	BEGIN TRAN
		DELETE FROM JobEmployeeLink
		WHERE JobEmployeeLink.jobID = @id

		INSERT INTO JobEmployeeLink(jobID,employeeID)
		SELECT idIntOne,idIntTwo FROM TVP

		DELETE FROM TVP
	COMMIT
GO
CREATE PROCEDURE UpdateJobState @id INT, @currentstate VARCHAR(50)
AS
BEGIN
	BEGIN TRAN
		UPDATE Job
		SET currentState = @currentstate
		WHERE jobID = @id
	COMMIT
END
GO
CREATE PROCEDURE UpdateJobEmployeesRequired @id INT, @amount INT
AS
BEGIN
	BEGIN TRAN
		UPDATE Job
		SET amountOfEmployeesNeeded = @amount
		WHERE jobID = @id
	COMMIT
END
GO
CREATE PROC UpdateServicePackage @id INT, @name VARCHAR(100), @price FLOAT
AS
	BEGIN TRAN
		UPDATE ServicePackage
		SET [name] = @name, price = @price
		WHERE servicePackageID = @id
	COMMIT
GO
CREATE PROC UpdateServicePackagePropotion @id INT, @onPromotion INT, @promotionStartDate DATETIME, @promotionEndDate DATETIME, @percentage FLOAT
AS
	BEGIN TRAN
		UPDATE ServicePackage
		SET onPromotion = @onPromotion, promotionStartDate = @promotionStartDate, promotionEndDate = @promotionEndDate, promotionPercentAmount = @percentage
		WHERE servicePackageID = @id
	COMMIT
GO
CREATE PROC UpdateServicePackageState @id INT, @onPromotion INT
AS
	BEGIN TRAN
		UPDATE ServicePackage
		SET onPromotion = @onPromotion
		WHERE servicePackageID = @id
	COMMIT
GO
CREATE PROC UpdateServicePackedgeServiceList @id INT
AS
	BEGIN TRAN
		DELETE FROM ServicePackageLink
		WHERE ServicePackageLink.ServicePackageID = @id

		INSERT INTO ServicePackageLink(ServicePackageID,ServiceID)
		SELECT idIntOne,idIntTwo FROM TVP

		DELETE FROM TVP
	COMMIT
GO
CREATE PROC UpdateContractPackageList @id VARCHAR(50)
AS
	BEGIN TRAN
		DELETE FROM ServiceContractLink
		WHERE ServiceContractLink.ContractID = (SELECT contractID FROM [Contract] WHERE contractNumber = @id)

		INSERT INTO ServiceContractLink(ContractID,ServicePackedgeID)
		SELECT idIntOne,idIntTwo FROM TVP

		DELETE FROM TVP
	COMMIT
GO
CREATE PROC UpdateService @id INT, @name VARCHAR(100),@description VARCHAR(255)
AS
	BEGIN TRAN
		UPDATE [Service]
		SET [name] = @name, [description] = @description
		WHERE serviceID = @id
	COMMIT
GO
CREATE PROC UpdateServiceRequest @id INT,@description VARCHAR(255), @priorityLevel VARCHAR(20)
AS
	BEGIN TRAN
		UPDATE ServiceRequest
		SET [description] = @description, priorityLevel = @priorityLevel
		WHERE serviceRequestID = @id
	COMMIT
GO
CREATE PROC UpdateServiceRequestCurrentState @id INT, @closed INT
AS
	BEGIN TRAN
		UPDATE ServiceRequest
		SET closed = @closed
		WHERE serviceRequestID = @id
	COMMIT
GO
CREATE PROC UpdateServiceRequestSpecializationList @id INT
AS
	BEGIN TRAN
		DELETE FROM ServiceRequestSpecialisationLink
		WHERE ServiceRequestSpecialisationLink.ServiceRequestID = @id

		INSERT INTO ServiceRequestSpecialisationLink(ServiceRequestID,specialisationRequiredID)
		SELECT idIntOne,idIntTwo FROM TVP

		DELETE FROM TVP
	COMMIT
GO
CREATE PROC InsertServiceRequestWithSpecializationList @callId INT, @closed INT, @description VARCHAR(255),@priorityLevel VARCHAR(255)
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
CREATE PROC UpdateSpecialization @id INT, @name VARCHAR(100),@description VARCHAR(255)
AS
	BEGIN TRAN
		UPDATE Specialisation
		SET [name] = @name, [description] = @description
		WHERE specialisationID = @id
	COMMIT
GO

-- INSERT Procedures
CREATE PROCEDURE InsertAddress @streetname VARCHAR(100),@suburb VARCHAR(100),@province VARCHAR(20),@postalcode VARCHAR(4), @city VARCHAR(40)
AS
BEGIN 
	INSERT INTO [Address] ([streetName], [suburb], [province], [postalcode],[city])
	VALUES (@streetname, @suburb,@province ,@postalcode,@city)
END
GO


CREATE PROCEDURE InsertEmployee @firstName VARCHAR(50), @surname VARCHAR(50), @contactNumber VARCHAR(10), @email VARCHAR(100), @nationalIdNumber VARCHAR(13), @employmentDate DATE, @employed INT, @department VARCHAR(25), @streetname VARCHAR(100),@suburb VARCHAR(100),@province VARCHAR(20),@postalcode VARCHAR(20),@city VARCHAR(50)
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

CREATE PROCEDURE InsertSpecialisation @name VARCHAR(25), @description VARCHAR(250)
AS
BEGIN
	INSERT INTO [Specialisation] ([name], [description])
	VALUES (@name, @description)
END 
GO

CREATE PROCEDURE InsertCallCenterEmployee @firstName VARCHAR(50), @surname VARCHAR(50), @contactNumber VARCHAR(10), @email VARCHAR(100), @nationalIdNumber VARCHAR(13), @employmentDate DATE, @employed INT, @department VARCHAR(25) ,@streetname VARCHAR(100),@suburb VARCHAR(100),@province VARCHAR(20),@postalcode VARCHAR(20),@city VARCHAR(50)
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

CREATE PROCEDURE InsertMaintenanceEmployee @firstName VARCHAR(50), @surname VARCHAR(50), @contactNumber VARCHAR(10), @email VARCHAR(100), @nationalIdNumber VARCHAR(13), @employmentDate DATE, @employed INT, @department VARCHAR(25) ,@streetname VARCHAR(100),@suburb VARCHAR(100),@province VARCHAR(20),@postalcode VARCHAR(20),@city VARCHAR(50)
AS
		BEGIN TRAN
		DECLARE @LASTID INT
		INSERT INTO [Address] ([streetName], [suburb], [province], [postalcode],[city])
		VALUES (@streetname, @suburb,@province ,@postalcode,@city)
		SET @LASTID = SCOPE_IDENTITY()

		INSERT INTO [Employee] ([firstName], [surname], [addressId], [contactNumber], [email], [nationalIdNumber], [employmentDate],[employed], [department])
		VALUES (@firstName, @surname, @LASTID, @contactNumber, @email, @nationalIdNumber, @employmentDate,@employed, @department)
COMMIT 
GO

CREATE PROCEDURE InsertServiceManager @firstName VARCHAR(50), @surname VARCHAR(50), @contactNumber VARCHAR(10), @email VARCHAR(100), @nationalIdNumber VARCHAR(13), @employmentDate DATE, @employed INT, @department VARCHAR(25) ,@streetname VARCHAR(100),@suburb VARCHAR(100),@province VARCHAR(20),@postalcode VARCHAR(20),@city VARCHAR(50)
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

CREATE PROCEDURE InsertClientIndividual @firstName VARCHAR(50), @surname VARCHAR(50), @contactNumber VARCHAR(10), @email VARCHAR(100), @nationalIdNumber VARCHAR(13), @registrationDate DATE, @active INT,@streetname VARCHAR(100),@suburb VARCHAR(100),@province VARCHAR(20),@postalcode VARCHAR(20),@city VARCHAR(50)
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
CREATE PROCEDURE InsertClientBusiness @busuinessName VARCHAR(50), @contactNumber VARCHAR(10), @taxNumber VARCHAR(10), @RegistrationDate DATE, @active INT,@streetname VARCHAR(100),@suburb VARCHAR(100),@province VARCHAR(20),@postalcode VARCHAR(20),@city VARCHAR(50)
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

CREATE PROCEDURE InsertServicePackageState @id INT
AS
BEGIN
	INSERT INTO [ServicePackageState] ([name], [onPromotion], [promotionStartDate], [promotionEndDate], [price],[promotionPercentAmount])
	SELECT [name], [onPromotion], [promotionStartDate], [promotionEndDate], [price],[promotionPercentAmount] FROM [ServicePackage] WHERE [ServicePackage].servicePackageID = @id
	SELECT SCOPE_IDENTITY()
END 
GO

CREATE PROCEDURE InsertServicePackage @name VARCHAR(50), @onpromotion INT, @promationStartDate DATETIME, @promotionEndDate DATETIME, @price FLOAT,@percintage FLOAT
AS
BEGIN
	INSERT INTO [ServicePackage] ([name], [onPromotion], [promotionStartDate], [promotionEndDate], [price],[promotionPercentAmount])
	VALUES (@name, @onpromotion, @promationStartDate, @promotionEndDate, @price,@percintage)
END 
GO

CREATE PROCEDURE InsertService @name VARCHAR(50), @description VARCHAR(255)
AS
BEGIN
	INSERT INTO [Service] ([name], [description])
	VALUES (@name, @description)
END 
GO

CREATE PROCEDURE InsertServiceState @id INT
AS
BEGIN
	INSERT INTO [ServiceState] ([name], [description])
	SELECT [name], [description] FROM [Service] WHERE [Service].serviceID = @id
	SELECT SCOPE_IDENTITY()
END 
GO
CREATE PROCEDURE InsertSpecialisationEmployeeLink @employeeID INT, @specialisationID INT
AS
BEGIN
	INSERT INTO [SpecialisationEmployeeLink] ([employeeID], [specialisationID])
	VALUES (@employeeID, @specialisationID)
END 
GO

CREATE PROCEDURE InsertCall @startTime DATETIME, @employeeID VARCHAR(50)
AS
BEGIN
	INSERT INTO [Call] ([startTime], [employeeID])
	VALUES (@startTime, (SELECT employeeID FROM Employee WHERE employeeNumber = @employeeID))
	SELECT SCOPE_IDENTITY()
END 
GO
CREATE PROCEDURE InsertServiceRequest @callId INT, @closed INT, @description VARCHAR(255),@priorityLevel VARCHAR(255)
AS
BEGIN
	INSERT INTO [ServiceRequest] ([callID], [closed], [description],[priorityLevel])
	VALUES (@callId, @closed, @description,@priorityLevel)
END 
GO
CREATE PROCEDURE InsertServiceRequestSpecialisationLink @specialisationRequiredID INT, @ServiceRequestID INT
AS
BEGIN
	INSERT INTO [ServiceRequestSpecialisationLink] ([specialisationRequiredID], [ServiceRequestID])
	VALUES (@specialisationRequiredID, @ServiceRequestID)
END 
GO

CREATE PROCEDURE InsertBusinessClientEmployees @firstName VARCHAR(50),@surname VARCHAR(50),@department VARCHAR(50), @contactNumber VARCHAR(10), @email VARCHAR(100), @businessID VARCHAR(50)
AS
BEGIN 
	INSERT INTO [ClientBusinessEmployee] ([firstName], [surname], [department], [contactNumber], [email], [businessID])
	VALUES (@firstName, @surname, @department, @contactNumber, @email, (SELECT clientBusinessID FROM ClientBusiness WHERE clientBusinessClientNumber = @businessID))
END
GO

CREATE PROCEDURE InsertJob @addressId INT, @ServiceRequestID INT, @notes VARCHAR(255), @currentState VARCHAR(20), @specialization INT, @amountOfEmployees INT
AS
	BEGIN TRAN
		INSERT INTO [Job] ([addressId], [ServiceRequestID], [notes], [currentState],[specialisationId],[amountOfEmployeesNeeded])
		VALUES (@addressId, @ServiceRequestID, @notes, @currentState,@specialization,@amountOfEmployees)
	COMMIT 
GO
CREATE PROCEDURE InsertJobWithEmployeeList @addressId INT, @ServiceRequestID INT, @notes VARCHAR(255), @currentState VARCHAR(20), @specialization INT, @amountOfEmployees INT
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
CREATE PROCEDURE InsertServiceRequestJobLink @serviceRequestID INT, @jobID INT
AS
BEGIN
	INSERT INTO [ServiceRequestJobLink] ([serviceRequestID], [jobID])
	VALUES (@serviceRequestID, @jobID)
END 
GO
CREATE PROCEDURE InsertJobEmployeeLink @employeeID VARCHAR(50), @jobID INT
AS
BEGIN
	INSERT INTO [JobEmployeeLink] ([employeeID], [jobID])
	VALUES ((SELECT Employee.employeeID FROM Employee WHERE employeeNumber = @employeeID), @jobID)
END 
GO
CREATE PROCEDURE InsertContractWithPackadgeList @startDate DATETIME, @endDate DATETIME, @active INT,@priorityLevel VARCHAR(20), @price FLOAT, @contractType VARCHAR(15)
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
CREATE PROCEDURE InsertContractOfClient @contractId VARCHAR(50),@startDate DATETIME, @endDate DATETIME, @active INT
AS
BEGIN TRAN
	INSERT INTO ContractState(startDate,endDate,activeContract,priorityLevel,price,contractType)
	SELECT @startDate,@endDate,@active,priorityLevel,price,contractType FROM [Contract] WHERE [Contract].contractNumber =  @contractId
	SELECT SCOPE_IDENTITY()
COMMIT 
GO

CREATE PROCEDURE InsertClientBusinessEmployee @id INT, @businessID INT, @firstName VARCHAR(50), @surname VARCHAR(50), @department VARCHAR(50), @contactNumber VARCHAR(10), @email VARCHAR(100)
AS
BEGIN
	INSERT INTO [ClientBusinessEmployee] ([businessID], [firstName], [surname], [department], [contactNumber], [email])
	VALUES (@businessID, @firstName, @surname, @department, @contactNumber, @email)
END 
GO
CREATE PROCEDURE InsertServiceContractStateLink @contractStateID INT, @ServicePackageStateID INT
AS
BEGIN
	INSERT INTO [ServiceContractStateLink] ([contractStateID], [ServicePackageStateID])
	VALUES (@contractStateID, @ServicePackageStateID)
END 
GO
CREATE PROCEDURE InsertServiceContractLink @ContractID VARCHAR(40), @ServicePackageID INT
AS
BEGIN
	INSERT INTO [ServiceContractLink] ([ContractID], [ServicePackedgeID])
	VALUES ((SELECT contractID FROM [Contract] WHERE contractNumber = @ContractID), @ServicePackageID)
END 
GO
CREATE PROCEDURE InsertServicePackageStateLink @ServicePackageStateID INT, @ServiceStateID INT
AS
BEGIN
	INSERT INTO [ServicePackageStateLink] ([ServicePackageStateID], [ServiceStateID])
	VALUES (@ServicePackageStateID, @ServiceStateID)
END 
GO
CREATE PROCEDURE InsertServicePackageLink @ServicePackageID INT, @ServiceID INT
AS
BEGIN
	INSERT INTO [ServicePackageLink] ([ServicePackageID], [ServiceID])
	VALUES (@ServicePackageID, @ServiceID)
END 
GO
CREATE PROCEDURE InsertClientContractLinkIndividualClient @ContractID INT, @ClientIndividualID VARCHAR(50)
AS
BEGIN
	INSERT INTO [ClientContractLink] ([ContractID], [ClientIndividualID])
	VALUES (@ContractID,(SELECT clientIndividualID FROM ClientIndividual WHERE clientIndividualClientNumber = @ClientIndividualID))
END 
GO
CREATE PROCEDURE InsertClientContractLinkBusinessClient @ContractID INT, @ClientBusinessID VARCHAR(50)
AS
BEGIN
	INSERT INTO [ClientContractLink] ([ContractID], [ClientBusinessID])
	VALUES (@ContractID, (SELECT clientBusinessID FROM ClientBusiness WHERE clientBusinessClientNumber = @ClientBusinessID))
END 
GO
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

--custom Selects
CREATE PROCEDURE SelectAllServiceRequests
AS
	SELECT * FROM ServiceRequest
GO

CREATE PROCEDURE SelectAllServiceRequestsByBusinessClient @id VARCHAR(20)
AS
	SELECT * FROM ServiceRequest
	INNER JOIN [Call] ON ServiceRequest.callID = [call].callID
	INNER JOIN ClientBusiness ON [Call].ClientBusinessID = ClientBusiness.clientBusinessID
	WHERE ClientBusiness.clientBusinessClientNumber = @id
GO
CREATE PROCEDURE SelectAllServiceRequestsByIndividualClient @id VARCHAR(20)
AS
	SELECT * FROM ServiceRequest
	INNER JOIN [Call] ON ServiceRequest.callID = [call].callID
	INNER JOIN ClientIndividual ON [Call].ClientIndividualID = ClientIndividual.clientIndividualID
	WHERE ClientIndividual.clientIndividualClientNumber = @id
GO
CREATE PROCEDURE SelectAllAddresses AS
BEGIN
	SELECT * FROM Address
END
GO
CREATE PROCEDURE SelectCallByJobId @id INT AS
BEGIN
	SELECT * FROM [Call]
	INNER JOIN ServiceRequest ON [Call].callID = ServiceRequest.callID
	INNER JOIN Job ON ServiceRequest.serviceRequestID = Job.ServiceRequestID
	WHERE Job.jobID = @id
END
GO
CREATE PROCEDURE SelectAllCallsByIndividualClientId @id VARCHAR(100) AS
BEGIN
	SELECT * FROM [Call]
	INNER JOIN ClientIndividual ON [Call].ClientIndividualID = ClientIndividual.clientIndividualID
	INNER JOIN [Address] ON ClientIndividual.addressId = [Address].addressID
	WHERE ClientIndividual.clientIndividualClientNumber = @id
END
GO
CREATE PROCEDURE SelectAllCallsByBusinessClientId @id VARCHAR(100) AS
BEGIN
	SELECT * FROM [Call]
	INNER JOIN ClientBusiness ON [Call].ClientBusinessID = ClientBusiness.clientBusinessID
	INNER JOIN [Address] ON ClientBusiness.addressId = [Address].addressID
	WHERE ClientBusiness.clientBusinessClientNumber = @id
END
GO

CREATE PROCEDURE SelectBusinessClientById @id INT AS
BEGIN
	SELECT * FROM ClientBusiness
	INNER JOIN [Address] ON ClientBusiness.addressId = [Address].addressID
	WHERE ClientBusiness.clientBusinessID = @id
END
GO
CREATE PROCEDURE SelectAllBusinessClientEmployeesByBusinessId @businessid VARCHAR(100) AS
BEGIN
	SELECT * FROM ClientBusinessEmployee
	INNER JOIN ClientBusiness ON ClientBusinessEmployee.businessID = ClientBusiness.clientBusinessID
	WHERE ClientBusiness.clientBusinessClientNumber = @businessid
END
GO
CREATE PROCEDURE SelectAllBusinessClientEmployees AS
BEGIN
	SELECT * FROM ClientBusinessEmployee
	INNER JOIN ClientBusiness ON ClientBusinessEmployee.businessID = ClientBusiness.clientBusinessID
END
GO
CREATE PROCEDURE SelectAllIndividualClients AS
BEGIN
	SELECT * FROM ClientIndividual
	INNER JOIN [Address] ON ClientIndividual.addressId = [Address].addressID
END
GO
CREATE PROCEDURE SelectAllBusinessClients AS
BEGIN
	SELECT * FROM ClientBusiness
	INNER JOIN [Address] ON ClientBusiness.addressId = [Address].addressID
END
GO
CREATE PROCEDURE SelectIndividualClientById @id INT AS
BEGIN
	SELECT * FROM ClientIndividual
	INNER JOIN [Address] ON ClientIndividual.addressId = [Address].addressID
	WHERE ClientIndividual.clientIndividualID = @id
END
GO

CREATE PROCEDURE SelectAllContract AS
BEGIN
	SELECT * FROM [Contract]
END
GO
CREATE PROCEDURE SelectAllActiveContract AS
BEGIN
	SELECT * FROM [Contract]
	WHERE [activeContract] = '1'
END 
GO
CREATE PROCEDURE SelectAllServicePackedgesLinkedToContract @id INT AS
BEGIN
	SELECT * FROM ServicePackage
	INNER JOIN ServiceContractLink ON ServicePackage.servicePackageID = ServiceContractLink.ServicePackedgeID
	INNER JOIN [Contract] ON ServiceContractLink.ContractID = ServiceContractLink.ContractID
	WHERE [Contract].contractID = @id
END
GO
CREATE PROCEDURE SelectAllServicePackedgesLinkedToContractState @id INT AS
BEGIN
	SELECT * FROM ServicePackageState
	INNER JOIN ServiceContractStateLink ON ServicePackageState.servicePackageStateID = ServiceContractStateLink.servicePackageStateID
	INNER JOIN [ContractState] ON ServiceContractStateLink.contractStateID = [ContractState].contractStateID
	WHERE [ContractState].contractStateID = @id
END
GO
CREATE PROC SelectAllContractsByIndividualClientId @id VARCHAR(100)
AS
    SELECT * FROM ContractState
    INNER JOIN ClientContractLink ON ContractState.contractStateID = ClientContractLink.ContractID
    INNER JOIN ClientIndividual ON ClientContractLink.ClientIndividualID = ClientIndividual.clientIndividualID
	INNER JOIN [Address] ON ClientIndividual.addressId = [Address].addressID
    WHERE ClientIndividual.clientIndividualClientNumber = @id
GO
CREATE PROC SelectContractByIndividualClientIdAndContractId @clientId VARCHAR(50),@contractId VARCHAR(50)
AS
    SELECT * FROM ContractState
    INNER JOIN ClientContractLink ON ContractState.contractStateID = ClientContractLink.ContractID
    INNER JOIN ClientIndividual ON ClientContractLink.ClientIndividualID = ClientIndividual.clientIndividualID
	INNER JOIN [Address] ON ClientIndividual.addressId = [Address].addressID
    WHERE ClientIndividual.clientIndividualClientNumber = @clientId AND ContractState.contractNumber = @contractId
GO
CREATE PROC SelectAllContractsByBusinessClientId @id VARCHAR(100)
AS
    SELECT * FROM ContractState
    INNER JOIN ClientContractLink ON ContractState.contractStateID = ClientContractLink.ContractID
    INNER JOIN ClientBusiness ON ClientContractLink.clientBusinessID = ClientBusiness.clientBusinessID
	INNER JOIN [Address] ON ClientBusiness.addressId = [Address].addressID
    WHERE ClientBusiness.clientBusinessClientNumber = @id
GO
CREATE PROC SelectAllContractsByBusinessClientIdAndContractId @clientId VARCHAR(50),@contractId VARCHAR(50)
AS
    SELECT * FROM ContractState
    INNER JOIN ClientContractLink ON ContractState.contractStateID = ClientContractLink.ContractID
    INNER JOIN ClientBusiness ON ClientContractLink.clientBusinessID = ClientBusiness.clientBusinessID
	INNER JOIN [Address] ON ClientBusiness.addressId = [Address].addressID
    WHERE ClientBusiness.clientBusinessClientNumber = @clientId AND ContractState.contractNumber = @contractId
GO
CREATE PROCEDURE SelectEmployees AS
BEGIN
	SELECT * FROM Employee
END
GO
CREATE PROCEDURE SelectAllJobs AS
BEGIN
	SELECT * FROM Job
END
GO
CREATE PROCEDURE SelectJobByJobId @id INT AS
BEGIN
	SELECT * FROM Job
	WHERE Job.jobID = @id
END
GO

CREATE PROCEDURE SelectAllPendingJobs AS
BEGIN
	SELECT * FROM Job
	WHERE currentState = '0'
END
GO
CREATE PROCEDURE SelectAllPendingJobsWithPriority AS
BEGIN
	SELECT * FROM Job
	INNER JOIN ServiceRequest ON Job.ServiceRequestID = ServiceRequest.serviceRequestID
	WHERE currentState = '0'
END
GO
CREATE PROCEDURE SelectAllJobsWithPriority AS
BEGIN
	SELECT * FROM Job
	INNER JOIN ServiceRequest ON Job.ServiceRequestID = ServiceRequest.serviceRequestID
END
GO
CREATE PROCEDURE SelectAllInProgressJobs AS
BEGIN
	SELECT * FROM Job
	WHERE currentState = '1'
END
GO
CREATE PROCEDURE SelectAllFinishedJobs AS
BEGIN
	SELECT * FROM Job
	WHERE currentState = '2'
END
GO
CREATE PROCEDURE SelectAllFinishedJobsByIndividualClientID @id VARCHAR(100) AS
BEGIN
	SELECT * FROM Job
	INNER JOIN ServiceRequest ON Job.ServiceRequestID = ServiceRequest.serviceRequestID
	INNER JOIN [Call] ON ServiceRequest.callID = [Call].callID
	INNER JOIN ClientIndividual ON [Call].ClientIndividualID = ClientIndividual.clientIndividualID
	WHERE ClientIndividual.clientIndividualClientNumber = @id AND Job.currentState = '2'
END
GO
CREATE PROCEDURE SelectAllFinishedJobsByBusinessClientID @id VARCHAR(100) AS
BEGIN
SELECT * FROM Job
INNER JOIN ServiceRequest ON Job.ServiceRequestID = ServiceRequest.serviceRequestID
INNER JOIN [Call] ON ServiceRequest.callID = [Call].callID
INNER JOIN ClientBusiness ON [Call].ClientIndividualID = ClientBusiness.clientBusinessID
WHERE ClientBusiness.clientBusinessClientNumber = @id AND Job.currentState = '2'
END
GO
CREATE PROCEDURE SelectAllServices AS
BEGIN
	SELECT * FROM Service
END
GO
CREATE PROCEDURE SelectAllServiceState AS
BEGIN
	SELECT * FROM ServiceState
END
GO
CREATE PROCEDURE SelectAllServicePackages AS
BEGIN
	SELECT * FROM ServicePackage
END
GO
CREATE PROCEDURE SelectAllServicePackageStates AS
BEGIN
	SELECT * FROM ServicePackageState
END
GO
CREATE PROCEDURE SelectAllServiceRequest AS
BEGIN
	SELECT * FROM ServiceRequest
END
GO
CREATE PROCEDURE SelectAllSpecialisations AS
BEGIN
	SELECT * FROM Specialisation
END
GO
CREATE PROCEDURE SelectAllSpecialisationName AS
BEGIN
	SELECT [name] FROM Specialisation
END
GO
CREATE PROCEDURE LinkContractAndClientBusinessAndIndividualBusiness @contractID INT, @clientBusinessID INT, @individualBusinessID INT
AS
	BEGIN TRAN
		INSERT INTO ClientContractLink(contractID,clientBusinessID,ClientIndividualID) VALUES (@contractID,@clientBusinessID,@individualBusinessID)
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
CREATE PROCEDURE SelectAllServiceInPackage @id INT AS
BEGIN
    SELECT * FROM Service as s
    INNER JOIN ServicePackageLink as spLink ON s.serviceID = spLink.ServiceID
    INNER JOIN ServicePackage as sp ON spLink.ServicePackageID = sp.servicePackageID
    WHERE sp.servicePackageID = @id
END
GO
CREATE PROCEDURE SelectAllServiceInPackageState @id INT AS
BEGIN
    SELECT * FROM ServiceState as s
    INNER JOIN ServicePackageStateLink as spLink ON s.serviceStateID = spLink.ServicePackageStateID
    INNER JOIN ServicePackageState as sp ON spLink.ServicePackageStateID = sp.servicePackageStateID
    WHERE sp.servicePackageStateID = @id
END
GO
CREATE PROCEDURE SelectAllServicePackagesInContract @id INT AS
BEGIN
    SELECT * FROM ServicePackage as s
    INNER JOIN ServiceContractLink as scLink ON s.servicePackageID = scLink.ServicePackedgeID
    INNER JOIN Contract as c ON scLink.ContractID = c.contractID
    WHERE c.contractID = @id
END
GO
CREATE PROCEDURE SelectAllServicePackagesInContractState @id INT AS
BEGIN
    SELECT * FROM ServicePackageState as s
    INNER JOIN ServiceContractStateLink as scLink ON s.servicePackageStateID = scLink.ServicePackageStateID
    INNER JOIN ContractState as c ON scLink.contractStateID = c.contractStateID
    WHERE c.contractStateID = @id
END
GO
CREATE PROCEDURE SelectAllServicesAndPackagesInContract @id INT AS
BEGIN
    SELECT * FROM Service as s
    INNER JOIN ServicePackageLink as spLink ON s.serviceID = spLink.ServiceID
    INNER JOIN ServicePackage as sp ON spLink.ServicePackageID = sp.servicePackageID
    INNER JOIN ServiceContractLink as scLink ON scLink.ServicePackedgeID = sp.servicePackageID
    INNER JOIN Contract as c ON scLink.ContractID = c.contractID
    WHERE c.contractID = @id
END
GO

CREATE PROCEDURE SelectBusinessClientEmployees AS
BEGIN
	SELECT * FROM ClientBusinessEmployee
END
GO

CREATE PROCEDURE SelectAllContracts AS
BEGIN
	SELECT * FROM "Contract"
END
GO
CREATE PROCEDURE SelectContractByID @id VARCHAR(50) AS
BEGIN
	SELECT * FROM "Contract" WHERE contractID = (SELECT contractID FROM [Contract] WHERE contractNumber = @id)
END
GO
CREATE PROCEDURE SelectAllActiveContracts AS
BEGIN
	SELECT * FROM "Contract" WHERE [activeContract] = '1'
END
GO
CREATE PROCEDURE SelectCallCenterEmployees AS
BEGIN
	SELECT * FROM Employee
	INNER JOIN [Address] ON Employee.addressId = [Address].addressID
	WHERE department = 'Call Center'
END
GO
CREATE PROCEDURE SelectCallCenterEmployeeByCallId @id INT AS
BEGIN
	SELECT Employee.employeeID,Employee.employeeNumber FROM Employee
	INNER JOIN [Address] ON Employee.addressId = [Address].addressID
	INNER JOIN [Call] ON Employee.employeeID = [Call].employeeID
	WHERE [Call].callID = @id
END
GO

CREATE PROCEDURE SelectServiceManagers AS
BEGIN
	SELECT * FROM Employee
	INNER JOIN [Address] ON Employee.addressId = [Address].addressID
	WHERE department = 'Service Manager'
END
GO

CREATE PROCEDURE SelectMaintenanceEmployees AS
BEGIN
	SELECT * FROM Employee
	INNER JOIN [Address] ON Employee.addressId = [Address].addressID
	WHERE department = 'Maintenance'
END
GO
CREATE PROCEDURE SelectMaintenanceEmployeesAccordingToSpecinization @specilization INT
AS
BEGIN
	SELECT * FROM Employee
	INNER JOIN [Address] ON Employee.addressId = [Address].addressID
	INNER JOIN SpecialisationEmployeeLink ON Employee.employeeID = SpecialisationEmployeeLink.employeeID
	INNER JOIN Specialisation ON SpecialisationEmployeeLink.specialisationID = Specialisation.specialisationID
	WHERE department = 'Maintenance' AND Specialisation.specialisationID = @specilization
END
GO
CREATE PROCEDURE SelectAvailableMaintenanceEmployees AS
BEGIN
	SELECT * FROM Employee
	LEFT JOIN JobEmployeeLink ON Employee.employeeID = JobEmployeeLink.employeeID
	LEFT JOIN Job ON JobEmployeeLink.jobID = Job.jobID
	INNER JOIN [Address] ON Employee.addressId = [Address].addressID
	WHERE Employee.department = 'Maintenance' AND (Job.currentState = 2 OR Job.currentState IS NULL)
END
GO


CREATE PROCEDURE SelectAllBusinessClientEmployeeWithBusinessName @businessName VARCHAR(100) AS
BEGIN
	SELECT * FROM ClientBusinessEmployee
	INNER JOIN ClientBusiness as CB
	ON CB.clientBusinessID = ClientBusinessEmployee.businessID
	WHERE CB.busuinessName = @businessName
END
GO

CREATE PROCEDURE SelectAvailableEmployeesOfMaintenance AS
BEGIN

    SELECT * FROM Employee 
    WHERE Employee.employeeID NOT IN (SELECT employeeID FROM JobEmployeeLink) AND Employee.department = 'Maintenance'
END
GO

CREATE PROCEDURE SelectAvailableEmployeesOfCallCenter AS
BEGIN

    SELECT * FROM Employee 
    WHERE Employee.employeeID NOT IN (SELECT employeeID FROM JobEmployeeLink) AND Employee.department = 'Call Center'
END
GO

CREATE PROCEDURE SelectAvailableEmployeesOfServiceManager AS
BEGIN

    SELECT * FROM Employee 
    WHERE Employee.employeeID NOT IN (SELECT employeeID FROM JobEmployeeLink) AND Employee.department = 'Service Manager'
END
GO

--===
---new

CREATE PROCEDURE SelectAllSpecilisationbyServiceRequest @id INT
AS
	SELECT * FROM Specialisation
	INNER JOIN ServiceRequestSpecialisationLink ON Specialisation.specialisationID = ServiceRequestSpecialisationLink.specialisationRequiredID
	INNER JOIN ServiceRequest ON ServiceRequestSpecialisationLink.ServiceRequestID = ServiceRequest.serviceRequestID
	WHERE ServiceRequest.serviceRequestID = @id
GO

--===
---new
CREATE PROCEDURE SelectAddressById @id INT
AS
	SELECT * FROM [Address]
	WHERE [Address].addressID = @id
GO
--===
---new
CREATE PROCEDURE GetMaintenanceEmployeeByJobId @id INT
AS
	SELECT * FROM Employee
	INNER JOIN JobEmployeeLink ON Employee.employeeID = JobEmployeeLink.employeeID
	INNER JOIN Job ON JobEmployeeLink.jobID = Job.jobID
	WHERE Job.jobID = @id AND department = 'Maintenance'
GO

--new
--===
CREATE PROCEDURE SelectAllServicesByServicePackedge @id INT
AS
BEGIN TRAN
	SELECT * FROM [Service]
	INNER JOIN ServicePackageLink ON [Service].serviceID = ServicePackageLink.ServiceID
	INNER JOIN ServicePackage ON ServicePackageLink.ServicePackageID = ServicePackage.servicePackageID
	WHERE ServicePackage.servicePackageID = @id
COMMIT
GO

--new
--===
CREATE PROCEDURE SelectAllServicesByServicePackedgeWithState @id INT
AS
BEGIN TRAN
	SELECT * FROM [ServiceState]
	INNER JOIN ServicePackageStateLink ON [ServiceState].serviceStateID = ServicePackageStateLink.ServiceStateID
	INNER JOIN ServicePackageState ON ServicePackageStateLink.ServicePackageStateID = ServicePackageState.servicePackageStateID
	WHERE ServicePackageState.servicePackageStateID = @id
COMMIT
GO
CREATE PROCEDURE SelectSpecialisationById @id INT
AS
BEGIN TRAN
	SELECT * FROM [Specialisation]
	WHERE [Specialisation].specialisationID = @id
COMMIT
GO
CREATE PROCEDURE SelectSpecialisationByEmployeeId @id INT
AS
BEGIN TRAN
	SELECT * FROM [Specialisation]
	INNER JOIN SpecialisationEmployeeLink ON Specialisation.specialisationID = SpecialisationEmployeeLink.specialisationID
	INNER JOIN Employee ON SpecialisationEmployeeLink.employeeID = Employee.employeeID
	WHERE Employee.employeeID = @id
COMMIT
GO

CREATE PROCEDURE GetSpecialisationOfEmployeeByEmployeeId @id INT
AS
BEGIN TRAN
	SELECT * FROM [Specialisation]
	INNER JOIN [SpecialisationEmployeeLink] ON [Specialisation].specialisationID = [SpecialisationEmployeeLink].specialisationID
	INNER JOIN [Employee] ON [SpecialisationEmployeeLink].employeeID = [Employee].employeeID
	WHERE [Employee].employeeID = @id
COMMIT
GO

CREATE PROCEDURE CountClients
AS
BEGIN TRAN
	SELECT COUNT(clientIndividualID) FROM ClientIndividual
COMMIT
GO

CREATE PROCEDURE SelectCallsForClientIndividual @id INT
AS
BEGIN TRAN
	SELECT * FROM [Call]
	WHERE [Call].ClientIndividualID = @id
COMMIT
GO

CREATE PROCEDURE SelectCallsForClientBusiness @id INT
AS
BEGIN TRAN
	SELECT * FROM [Call]
	WHERE [Call].ClientBusinessID = @id
COMMIT
GO

--CountUses
CREATE PROCEDURE SpecialisationUses @id INT
AS
BEGIN TRAN
	DECLARE @count INT
	SET @count = (SELECT COUNT(specialisationID) FROM Job WHERE specialisationID = @id) + (SELECT COUNT(specialisationID) FROM SpecialisationEmployeeLink WHERE specialisationID = @id) + (SELECT COUNT(specialisationRequiredID) FROM ServiceRequestSpecialisationLink WHERE specialisationRequiredID = @id)
	SELECT @count AS uses
COMMIT
GO
CREATE PROCEDURE AddressUses @id INT
AS
BEGIN TRAN
	DECLARE @count INT
	SET @count = (SELECT COUNT(addressId) FROM Job WHERE addressId = @id) + (SELECT COUNT(addressId) FROM Employee WHERE addressId = @id) + (SELECT COUNT(addressId) FROM ClientBusiness WHERE addressId = @id) + (SELECT COUNT(addressId) FROM ClientIndividual WHERE addressId = @id)
	SELECT @count AS uses
COMMIT
GO