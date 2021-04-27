USE PremierServiceSolutionsDatabase
GO

CREATE FUNCTION CountSpecializationUses (@id INT) 
returns INT 
AS 
BEGIN 
RETURN (SELECT COUNT(specialisationID) FROM SpecialisationEmployeeLink WHERE specialisationID = @id) + (SELECT COUNT(specialisationRequiredID) FROM ServiceRequestSpecialisationLink WHERE specialisationRequiredID = @id)
END
GO

CREATE PROCEDURE SpecialisationUses @id INT
AS
	SELECT dbo.CountSpecializationUses(@id) AS NumberOfUses 
	FROM Specialisation
	WHERE specialisationID = @id
GO

CREATE PROCEDURE DeleteSpecialisation @id INT
AS
	BEGIN TRAN
		DELETE FROM Specialisation
		WHERE specialisationID = @id
	COMMIT
GO
