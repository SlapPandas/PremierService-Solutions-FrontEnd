USE PremierServiceSolutionsDatabase
GO

CREATE PROCEDURE SelectAllAddresses AS
BEGIN
	SELECT * FROM Address
END
GO

CREATE PROCEDURE SelectAllCalls AS
BEGIN
	SELECT * FROM Call
END
GO

CREATE PROCEDURE SelectBusinessClients AS
BEGIN
	SELECT * FROM ClientBusiness
END
GO

CREATE PROCEDURE SelectAllBusinessClientEmployee @businessName VARCHAR(100) AS
BEGIN
	SELECT * FROM ClientBusinessEmployee
	INNER JOIN ClientBusiness as CB
	ON CB.ID = ClientBusinessEmployee.businessID
	WHERE CB.busuinessName = @businessName
END
GO

CREATE PROCEDURE SelectAllIndividualClients AS
BEGIN
	SELECT * FROM ClientIndividual
END
GO


CREATE PROCEDURE SelectAllContract AS
BEGIN
	SELECT * FROM Contract
END
GO

CREATE PROC SelectAllContractsByIndividualClientId @id INT
AS
    SELECT * FROM ContractState
    INNER JOIN ClientContractLink ON ContractState.ID = ClientContractLink.ContractID
    INNER JOIN ClientIndividual ON ClientContractLink.ClientIndividualID = ClientIndividual.ID
    WHERE ClientIndividual.ID = @id
GO

CREATE PROC SelectAllContractsByBusinessClientId @id INT
AS
    SELECT ContractState.ID FROM ContractState
    INNER JOIN ClientContractLink ON ContractState.ID = ClientContractLink.ContractID
    INNER JOIN ClientBusiness ON ClientContractLink.ClientIndividualID = ClientBusiness.ID
    WHERE ClientBusiness.ID = @id
GO


CREATE PROCEDURE Employee AS
BEGIN
	SELECT * FROM Employee
END
GO


CREATE PROCEDURE SelectAllJobs AS
BEGIN
	SELECT * FROM Job
END
GO

CREATE PROCEDURE SelectAllPendingJobs AS
BEGIN
	SELECT * FROM Job
	WHERE currentState = 'Pending'
END
GO

CREATE PROCEDURE SelectAllInProgressJobs AS
BEGIN
	SELECT * FROM Job
	WHERE currentState = 'In Progress'
END
GO

CREATE PROCEDURE SelectAllFinishedJobs AS
BEGIN
	SELECT * FROM Job
	WHERE currentState = 'Finished'
END
GO

CREATE PROCEDURE SelectAllFinishedJobsByIndividualClientID @id INT AS
BEGIN
	SELECT * FROM Job as j
	INNER JOIN ServiceRequestJobLink as srjl ON j.ID = srjl.jobID
	INNER JOIN ServiceRequest as serReq ON srjl.serviceRequestID = serReq.ID
	INNER JOIN Call ON serReq.callID = Call.ID
	WHERE currentState = 'Finished' AND Call.ClientIndividualID = @id
END
GO

CREATE PROCEDURE SelectAllFinishedJobsByBusinessClientID @id INT AS
BEGIN
	SELECT * FROM Job as j
	INNER JOIN ServiceRequestJobLink as srjl ON j.ID = srjl.jobID
	INNER JOIN ServiceRequest as serReq ON srjl.serviceRequestID = serReq.ID
	INNER JOIN Call ON serReq.callID = Call.ID
	WHERE currentState = 'Finished' AND Call.ClientBusinessID = @id
END
GO

CREATE PROCEDURE SelectAllServices AS
BEGIN
	SELECT * FROM Service
END
GO

CREATE PROCEDURE SelectAllServiceInPackage AS
BEGIN
	SELECT * FROM Service as s
	INNER JOIN ServicePackageLink as spLink ON s.ID = spLink.ServiceID
	INNER JOIN ServicePackage as sp ON spLink.ServicePackageID = sp.ID
	GROUP BY sp.name
END
GO

CREATE PROCEDURE SelectAllServiceInPackageState AS
BEGIN
	SELECT * FROM ServiceState as s
	INNER JOIN ServicePackageStateLink as spLink ON s.ID = spLink.ServicePackageStateID
	INNER JOIN ServicePackageState as sp ON spLink.ServicePackageStateID = sp.ID
	GROUP BY sp.name
END
GO

CREATE PROCEDURE SelectAllServicePackagesInContract AS
BEGIN
	SELECT * FROM ServicePackage as s
	INNER JOIN ServiceContractLink as scLink ON s.ID = scLink.ServicePackedgeID
	INNER JOIN Contract as c ON scLink.ContractID = c.ID
	GROUP BY c.ID
END
GO

CREATE PROCEDURE SelectAllServicePackagesInContractState AS
BEGIN
	SELECT * FROM ServicePackageState as s
	INNER JOIN ServiceContractStateLink as scLink ON s.ID = scLink.ServicePackageStateID
	INNER JOIN ContractState as c ON scLink.contractStateID = c.ID
	GROUP BY c.ID
END
GO

CREATE PROCEDURE SelectAllServicesAndPackagesInContract AS
BEGIN
	SELECT * FROM Service as s
	INNER JOIN ServicePackageLink as spLink ON s.ID = spLink.ServiceID
	INNER JOIN ServicePackage as sp ON spLink.ServicePackageID = sp.ID
	INNER JOIN ServiceContractLink as scLink ON scLink.ServicePackedgeID = sp.ID
	INNER JOIN Contract as c ON scLink.ContractID = c.ID
	GROUP BY c.ID
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

