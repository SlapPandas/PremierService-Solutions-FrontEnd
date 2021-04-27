--===
CREATE PROCEDURE SelectAllServiceRequestsByBusinessClient @id INT
AS
	SELECT * FROM ServiceRequest
	INNER JOIN [Call] ON ServiceRequest.callID = [call].ID
	INNER JOIN ClientBusiness ON [Call].ClientBusinessID = ClientBusiness.ID
	WHERE ClientBusiness.ID = @id
GO

--===
---new
CREATE PROCEDURE SelectAllSpecilisationbyServiceRequest @id INT
AS
	SELECT * FROM Specialisation
	INNER JOIN ServiceRequestSpecialisationLink ON Specialisation.ID = ServiceRequestSpecialisationLink.specialisationRequiredID
	INNER JOIN ServiceRequest ON ServiceRequestSpecialisationLink.ServiceRequestID = ServiceRequest.ID
	WHERE ServiceRequest.ID = @id
GO

--===
---new
CREATE PROCEDURE SelectAddress @id INT
AS
	SELECT * FROM [Address]
	WHERE [Address].ID = @id
GO

--===
CREATE PROCEDURE SelectAllServiceRequestsByIndividualClient @id INT
AS
	SELECT * FROM ServiceRequest
	INNER JOIN [Call] ON ServiceRequest.callID = [call].ID
	INNER JOIN ClientIndividual ON [Call].ClientIndividualID = ClientIndividual.ID
	WHERE ClientIndividual.ID = @id
GO

--===
CREATE PROCEDURE SelectAllIndividualClients AS
BEGIN
	SELECT * FROM ClientIndividual
END
GO

--===
---new
CREATE PROCEDURE GetMaintenanceEmployeeByJobId @id INT
AS
	SELECT * FROM Employee
	INNER JOIN JobEmployeeLink ON Employee.ID = JobEmployeeLink.employeeID
	INNER JOIN Job ON JobEmployeeLink.jobID = Job.ID
	WHERE Job.ID = @id AND department = 'Maintenance'
GO

--===
CREATE PROCEDURE SelectAllJobs AS
BEGIN
	SELECT * FROM Job
END
GO

--===
CREATE PROCEDURE SelectAllPendingJobs AS
BEGIN
	SELECT * FROM Job
	WHERE currentState = 'Pending'
END
GO

--===
CREATE PROCEDURE SelectAllInProgressJobs AS
BEGIN
	SELECT * FROM Job
	WHERE currentState = 'In Progress'
END
GO

--===
CREATE PROCEDURE SelectAllFinishedJobs AS
BEGIN
	SELECT * FROM Job
	WHERE currentState = 'Finished'
END
GO

--===
CREATE PROCEDURE SelectAllFinishedJobsByIndividualClientID @id INT AS
BEGIN
	SELECT * FROM Job as j
	INNER JOIN ServiceRequestJobLink as srjl ON j.ID = srjl.jobID
	INNER JOIN ServiceRequest as serReq ON srjl.serviceRequestID = serReq.ID
	INNER JOIN Call ON serReq.callID = Call.ID
	WHERE currentState = 'Finished' AND Call.ClientIndividualID = @id
END
GO

--===
CREATE PROCEDURE SelectAllFinishedJobsByBusinessClientID @id INT AS
BEGIN
	SELECT * FROM Job as j
	INNER JOIN ServiceRequestJobLink as srjl ON j.ID = srjl.jobID
	INNER JOIN ServiceRequest as serReq ON srjl.serviceRequestID = serReq.ID
	INNER JOIN Call ON serReq.callID = Call.ID
	WHERE currentState = 'Finished' AND Call.ClientBusinessID = @id
END
GO

--===
CREATE PROCEDURE SelectAllServices AS
BEGIN
	SELECT * FROM Service
END
GO

--===
CREATE PROCEDURE SelectAllServiceState AS
BEGIN
	SELECT * FROM ServiceState
END
GO

--new
--===
CREATE PROCEDURE SelectAllServicesByServicePackedge @id INT
AS
BEGIN TRAN
	SELECT * FROM [Service]
	INNER JOIN ServicePackageLink ON [Service].ID = ServicePackageLink.ServiceID
	INNER JOIN ServicePackage ON ServicePackageLink.ServicePackageID = ServicePackage.ID
	WHERE ServicePackage.ID = @id
COMMIT
GO

--new
--===
CREATE PROCEDURE SelectAllServicesByServicePackedgeWithState @id INT
AS
BEGIN TRAN
	SELECT * FROM [Service]
	INNER JOIN ServicePackageLink ON [Service].ID = ServicePackageLink.ServiceID
	INNER JOIN ServicePackage ON ServicePackageLink.ServicePackageID = ServicePackage.ID
	WHERE ServicePackage.ID = @id
COMMIT
GO

--===
CREATE PROCEDURE SelectAllServicePackages AS
BEGIN
	SELECT * FROM ServicePackage
END
GO

--===
CREATE PROCEDURE SelectAllServicePackageStates AS
BEGIN
	SELECT * FROM ServicePackageState
END
GO

--===
CREATE PROCEDURE SelectAllServiceRequest AS
BEGIN
	SELECT * FROM ServiceRequest
END
GO

--===
CREATE PROCEDURE SelectAllSpecialisations AS
BEGIN
	SELECT * FROM Specialisation
END
GO

--===
CREATE PROCEDURE SelectAllSpecialisationName AS
BEGIN
	SELECT [name] FROM Specialisation
END
GO

--===
CREATE PROCEDURE SelectAllServiceInPackage @id INT AS
BEGIN
    SELECT * FROM Service as s
    INNER JOIN ServicePackageLink as spLink ON s.ID = spLink.ServiceID
    INNER JOIN ServicePackage as sp ON spLink.ServicePackageID = sp.ID
    WHERE sp.ID = @id
END
GO

--===
CREATE PROCEDURE SelectAllServiceInPackageState @id INT AS
BEGIN
    SELECT * FROM ServiceState as s
    INNER JOIN ServicePackageStateLink as spLink ON s.ID = spLink.ServicePackageStateID
    INNER JOIN ServicePackageState as sp ON spLink.ServicePackageStateID = sp.ID
    WHERE sp.ID = @id
END
GO