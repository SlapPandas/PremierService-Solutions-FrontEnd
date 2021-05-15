INSERT INTO Address (streetName, suburb, province, postalcode,city) VALUES ('21 Foxhound','Midrand','1','1684','johannesburg')
INSERT INTO Address (streetName, suburb, province, postalcode,city) VALUES ('32 Maple','Hatfield','3','1932','Pretoria')
INSERT INTO Address (streetName, suburb, province, postalcode,city) VALUES ('63 Main','Fourways','2','1029','capetown')
INSERT INTO Address (streetName, suburb, province, postalcode,city) VALUES ('92 Maxwell','Lonehill','1','7102','Pretoria')
INSERT INTO Address (streetName, suburb, province, postalcode,city) VALUES ('55 Church','Brooklyn','3','1984','Pretoria')

INSERT INTO Employee(firstName,surname,addressId,contactNumber,email,nationalIdNumber,employmentDate,employed,department) VALUES ('Jayden','Hardman','1','0817622651','myname@gmail.com','9861237651092','2000-12-01','1','Call Center')
INSERT INTO Employee(firstName,surname,addressId,contactNumber,email,nationalIdNumber,employmentDate,employed,department) VALUES ('Matin','De wet','2','0848766219','yourname@hotmail.com','1348302832952','1990-02-01','1','Call Center')
INSERT INTO Employee(firstName,surname,addressId,contactNumber,email,nationalIdNumber,employmentDate,employed,department) VALUES ('Lijani','John','3','0724877534','lolmemes@gmail.com','8305283029467','1980-06-02','1','Service Manager')
INSERT INTO Employee(firstName,surname,addressId,contactNumber,email,nationalIdNumber,employmentDate,employed,department) VALUES ('Duncan','Joe','4','0818477924','himatin@yahoo.com','7502837592035','1999-10-02','1','Maintenance')
INSERT INTO Employee(firstName,surname,addressId,contactNumber,email,nationalIdNumber,employmentDate,employed,department) VALUES ('Dylan','Zeus','5','0617349561','mrdoge@gmail.com','9305832739295','2002-02-03','1','Maintenance')
INSERT INTO Employee(firstName,surname,addressId,contactNumber,email,nationalIdNumber,employmentDate,employed,department) VALUES ('Alex','Davidson','3','0812377924','alex@yahoo.com','7502349562035','1999-01-01','1','Maintenance')
INSERT INTO Employee(firstName,surname,addressId,contactNumber,email,nationalIdNumber,employmentDate,employed,department) VALUES ('Blessed','Rapudi','5','1234543212','bless@gmail.com','9323152739295','2000-01-01','1','Maintenance')

INSERT INTO Specialisation([name],[description]) VALUES ('Fix Printers','fix printers of all types')
INSERT INTO Specialisation([name],[description]) VALUES ('Pumber','Fix pipes and toilets')
INSERT INTO Specialisation([name],[description]) VALUES ('Electricial','Fix electrical things')
INSERT INTO Specialisation([name],[description]) VALUES ('Painter','Paint walls ')
INSERT INTO Specialisation([name],[description]) VALUES ('Gardener','Maintain garden')

INSERT INTO ClientIndividual(firstName, surname, addressId, contactNumber, email, nationalIdNumber, RegistrationDate,[active]) VALUES ('John','Mike','1','09728411356','john@gmail.com','3839293456921','1990-12-01','1')
INSERT INTO ClientIndividual(firstName, surname, addressId, contactNumber, email, nationalIdNumber, RegistrationDate,[active]) VALUES ('Joe','Mitch','1','09813455135','joe@gmail.com','8394032019234','2000-01-01','1')
INSERT INTO ClientIndividual(firstName, surname, addressId, contactNumber, email, nationalIdNumber, RegistrationDate,[active]) VALUES ('Jane','Soft','2','06632122356','jane@gmail.com','9384717283912','2002-02-20','1')
INSERT INTO ClientIndividual(firstName, surname, addressId, contactNumber, email, nationalIdNumber, RegistrationDate,[active]) VALUES ('Peter','Small','4','07434566723','peter@gmail.com','9384581284912','2004-03-04','1')
INSERT INTO ClientIndividual(firstName, surname, addressId, contactNumber, email, nationalIdNumber, RegistrationDate,[active]) VALUES ('Jaco','Musk','5','02345667522','jaco@gmail.com','9283492918721','2012-09-21','1')
INSERT INTO ClientIndividual(firstName, surname, addressId, contactNumber, email, nationalIdNumber, RegistrationDate,[active]) VALUES ('Liezle','Musk','5','02345667522','jaco@gmail.com','9283492918721','2012-09-21','1')

INSERT INTO ClientBusiness([busuinessName],[addressId],[contactNumber],[taxNumber],[RegistrationDate],[active])VALUES ('WeSellThings','5','7394599123','8729293812','2000-03-21','1')
INSERT INTO ClientBusiness([busuinessName],[addressId],[contactNumber],[taxNumber],[RegistrationDate],[active])VALUES ('takealittle','4','8762833485','8762128491','1999-03-19','1')
INSERT INTO ClientBusiness([busuinessName],[addressId],[contactNumber],[taxNumber],[RegistrationDate],[active])VALUES ('amagone','5','8124955871','7263749182','1980-12-21','1')
INSERT INTO ClientBusiness([busuinessName],[addressId],[contactNumber],[taxNumber],[RegistrationDate],[active])VALUES ('largemilkers','3','8264822814','7462919202','1892-12-01','1')
INSERT INTO ClientBusiness([busuinessName],[addressId],[contactNumber],[taxNumber],[RegistrationDate],[active])VALUES ('boredathome','1','9193455812','6273819283','2020-03-21','1')
INSERT INTO ClientBusiness([busuinessName],[addressId],[contactNumber],[taxNumber],[RegistrationDate],[active])VALUES ('Panda Slapping','1','9193455812','6273819283','2020-03-21','1')

INSERT INTO ServicePackage([name],[onPromotion],[promotionStartDate],[promotionEndDate],[price],[promotionPercentAmount]) VALUES ('Samsung','0','2021-03-03','2021-06-03','1000','0')
INSERT INTO ServicePackage([name],[onPromotion],[promotionStartDate],[promotionEndDate],[price],[promotionPercentAmount]) VALUES ('Printers','0','2021-03-02','2021-06-02','5000','0')
INSERT INTO ServicePackage([name],[onPromotion],[promotionStartDate],[promotionEndDate],[price],[promotionPercentAmount]) VALUES ('Cars','0','2021-03-01','2021-06-01','30000','0')
INSERT INTO ServicePackage([name],[onPromotion],[promotionStartDate],[promotionEndDate],[price],[promotionPercentAmount]) VALUES ('Planes','0','2021-03-01','2021-06-01','15000','0')
INSERT INTO ServicePackage([name],[onPromotion],[promotionStartDate],[promotionEndDate],[price],[promotionPercentAmount]) VALUES ('Gardening','1','2021-03-01','2021-06-01','20000','15')

INSERT INTO [Service]([name],[description]) VALUES('fixInkjetPrinter','Fix all types of ink jet printers')
INSERT INTO [Service]([name],[description]) VALUES('fixToilet','fix toilets')
INSERT INTO [Service]([name],[description]) VALUES('removeWeeds','remove weeds from gardens and other areas')
INSERT INTO [Service]([name],[description]) VALUES('replacePlug','replace a broken or defective plug point')
INSERT INTO [Service]([name],[description]) VALUES('removeWasps','remove wasps from areas ')

INSERT INTO [Call](startTime, endTime, ClientIndividualID, employeeID, callNotes) VALUES ('2000/01/01','2000/01/02','1','1','Broken pipes')
INSERT INTO [Call](startTime, endTime, ClientBusinessID, employeeID, callNotes) VALUES ('2000/01/02','2000/01/03','2','2','Garden needs weeds removed')
INSERT INTO [Call](startTime, endTime, ClientIndividualID, employeeID, callNotes) VALUES ('2000/01/03','2000/01/04','3','1','Light switch wont work')
INSERT INTO [Call](startTime, endTime, ClientBusinessID, employeeID, callNotes) VALUES ('2000/01/04','2000/01/05','3','2','Printer jammed')
INSERT INTO [Call](startTime, endTime, ClientIndividualID, employeeID, callNotes) VALUES ('2021/05/06','2021/05/07','5','1','Wall has paint chips')

INSERT INTO ServiceRequest(callID,closed,description,priorityLevel) VALUES ('1','1','Broken pipes','PLA1')
INSERT INTO ServiceRequest(callID,closed,description,priorityLevel) VALUES ('2','1','Garden needs weeds removed','GOL2')
INSERT INTO ServiceRequest(callID,closed,description,priorityLevel) VALUES ('3','1','Light switch wont work','SIL3')
INSERT INTO ServiceRequest(callID,closed,description,priorityLevel) VALUES ('4','0','Printer jammed','BRO4')
INSERT INTO ServiceRequest(callID,closed,description,priorityLevel) VALUES ('5','0','Wall has paint chips','PLA1')

INSERT INTO [Job](addressId,ServiceRequestID,notes,currentState,specialisationId,amountOfEmployeesNeeded) VALUES ('1','1', 'Broken pipes','0','3','1')
INSERT INTO [Job](addressId,ServiceRequestID,notes,currentState,specialisationId,amountOfEmployeesNeeded) VALUES ('2','2', 'Garden needs weeds removed','0','1','2')
INSERT INTO [Job](addressId,ServiceRequestID,notes,currentState,specialisationId,amountOfEmployeesNeeded) VALUES ('3','3', 'Light switch wont work','1','2','3')
INSERT INTO [Job](addressId,ServiceRequestID,notes,currentState,specialisationId,amountOfEmployeesNeeded) VALUES ('4','4', 'Printer jammed','0','5','2')
INSERT INTO [Job](addressId,ServiceRequestID,notes,currentState,specialisationId,amountOfEmployeesNeeded) VALUES ('5','5', 'Wall has paint chips','1','4','2')

INSERT INTO [Contract]([startDate],[endDate],[activeContract],priorityLevel,price,contractType) VALUES('1/1/2010','1/1/2022','1','PLA1','12000','type1')
INSERT INTO [Contract]([startDate],[endDate],[activeContract],priorityLevel,price,contractType) VALUES('1/2/2011','1/5/2023','1','GOL3','13000','type2')
INSERT INTO [Contract]([startDate],[endDate],[activeContract],priorityLevel,price,contractType) VALUES('1/3/2012','1/3/2024','1','SIL6','19000','type3')
INSERT INTO [Contract]([startDate],[endDate],[activeContract],priorityLevel,price,contractType) VALUES('1/1/2013','1/1/2019','0','BRO7','11000','type4')
INSERT INTO [Contract]([startDate],[endDate],[activeContract],priorityLevel,price,contractType) VALUES('1/1/2013','1/1/2026','1','BRO8','11000','type4')
INSERT INTO [Contract]([startDate],[endDate],[activeContract],priorityLevel,price,contractType) VALUES('1/2/2014','1/1/2018','0','PLA1','10000','type5')

INSERT INTO [ContractState]([startDate],[endDate],[activeContract],priorityLevel,price,contractType,oldContractId) VALUES('1/1/2010','1/1/2022','1','PLA1','12000','type1','C2021ZP000001')
INSERT INTO [ContractState]([startDate],[endDate],[activeContract],priorityLevel,price,contractType,oldContractId) VALUES('1/2/2011','1/5/2023','1','GOL3','13000','type2','C2021ZP000002')
INSERT INTO [ContractState]([startDate],[endDate],[activeContract],priorityLevel,price,contractType,oldContractId) VALUES('1/3/2012','1/3/2024','1','SIL6','19000','type3','C2021ZP000003')
INSERT INTO [ContractState]([startDate],[endDate],[activeContract],priorityLevel,price,contractType,oldContractId) VALUES('1/1/2013','1/1/2019','0','BRO7','11000','type4','C2021ZP000004')
INSERT INTO [ContractState]([startDate],[endDate],[activeContract],priorityLevel,price,contractType,oldContractId) VALUES('1/1/2013','1/1/2026','1','BRO8','11000','type4','C2021ZP000005')
INSERT INTO [ContractState]([startDate],[endDate],[activeContract],priorityLevel,price,contractType,oldContractId) VALUES('1/2/2014','1/1/2018','0','PLA1','10000','type5','C2021ZP000006')
INSERT INTO [ContractState]([startDate],[endDate],[activeContract],priorityLevel,price,contractType,oldContractId) VALUES('1/2/2014','1/1/2018','0','PLA1','10000','type5','C2021ZP000006')
INSERT INTO [ContractState]([startDate],[endDate],[activeContract],priorityLevel,price,contractType,oldContractId) VALUES('1/2/2014','1/1/2018','0','PLA1','10000','type5','C2021ZP000006')

INSERT INTO ClientContractLink(ContractID,ClientBusinessID) VALUES('1','1')
INSERT INTO ClientContractLink(ContractID,ClientIndividualID) VALUES('1','1')
INSERT INTO ClientContractLink(ContractID,ClientBusinessID) VALUES('2','2')
INSERT INTO ClientContractLink(ContractID,ClientIndividualID) VALUES('2','2')
INSERT INTO ClientContractLink(ContractID,ClientBusinessID) VALUES('3','3')
INSERT INTO ClientContractLink(ContractID,ClientIndividualID) VALUES('3','3')
INSERT INTO ClientContractLink(ContractID,ClientBusinessID) VALUES('4','4')
INSERT INTO ClientContractLink(ContractID,ClientIndividualID) VALUES('4','4')
INSERT INTO ClientContractLink(ContractID,ClientBusinessID) VALUES('5','5')
INSERT INTO ClientContractLink(ContractID,ClientIndividualID) VALUES('5','5')
INSERT INTO ClientContractLink(ContractID,ClientBusinessID) VALUES('6','5')
INSERT INTO ClientContractLink(ContractID,ClientIndividualID) VALUES('6','5')

INSERT INTO ServicePackageLink ([servicepackageID],[serviceID]) VALUES ('1','2')
INSERT INTO ServicePackageLink ([servicepackageID],[serviceID]) VALUES ('1','1')
INSERT INTO ServicePackageLink ([servicepackageID],[serviceID]) VALUES ('2','3')
INSERT INTO ServicePackageLink ([servicepackageID],[serviceID]) VALUES ('2','2')
INSERT INTO ServicePackageLink ([servicepackageID],[serviceID]) VALUES ('3','4')
INSERT INTO ServicePackageLink ([servicepackageID],[serviceID]) VALUES ('3','1')
INSERT INTO ServicePackageLink ([servicepackageID],[serviceID]) VALUES ('4','1')
INSERT INTO ServicePackageLink ([servicepackageID],[serviceID]) VALUES ('4','3')
INSERT INTO ServicePackageLink ([servicepackageID],[serviceID]) VALUES ('5','4')
INSERT INTO ServicePackageLink ([servicepackageID],[serviceID]) VALUES ('5','2')

INSERT INTO ServiceContractLink([contractID],[ServicePackedgeID]) VALUES ('1','1')
INSERT INTO ServiceContractLink([contractID],[ServicePackedgeID]) VALUES ('1','3')
INSERT INTO ServiceContractLink([contractID],[ServicePackedgeID]) VALUES ('3','2')
INSERT INTO ServiceContractLink([contractID],[ServicePackedgeID]) VALUES ('3','5')
INSERT INTO ServiceContractLink([contractID],[ServicePackedgeID]) VALUES ('3','1')
INSERT INTO ServiceContractLink([contractID],[ServicePackedgeID]) VALUES ('4','2')
INSERT INTO ServiceContractLink([contractID],[ServicePackedgeID]) VALUES ('4','3')
INSERT INTO ServiceContractLink([contractID],[ServicePackedgeID]) VALUES ('5','4')
INSERT INTO ServiceContractLink([contractID],[ServicePackedgeID]) VALUES ('5','2')
INSERT INTO ServiceContractLink([contractID],[ServicePackedgeID]) VALUES ('6','4')
INSERT INTO ServiceContractLink([contractID],[ServicePackedgeID]) VALUES ('6','2')
INSERT INTO ServiceContractLink([contractID],[ServicePackedgeID]) VALUES ('2','2')
INSERT INTO ServiceContractLink([contractID],[ServicePackedgeID]) VALUES ('2','3')
INSERT INTO ServiceContractLink([contractID],[ServicePackedgeID]) VALUES ('2','4')
INSERT INTO ServiceContractLink([contractID],[ServicePackedgeID]) VALUES ('2','2')
INSERT INTO ServiceContractLink([contractID],[ServicePackedgeID]) VALUES ('2','4')
INSERT INTO ServiceContractLink([contractID],[ServicePackedgeID]) VALUES ('2','2')

INSERT INTO JobEmployeeLink(jobID,employeeID) VALUES ('1','4')
INSERT INTO JobEmployeeLink(jobID,employeeID) VALUES ('1','5')
INSERT INTO JobEmployeeLink(jobID,employeeID) VALUES ('2','4')
INSERT INTO JobEmployeeLink(jobID,employeeID) VALUES ('2','5')
INSERT INTO JobEmployeeLink(jobID,employeeID) VALUES ('3','5')
INSERT INTO JobEmployeeLink(jobID,employeeID) VALUES ('3','4')
INSERT INTO JobEmployeeLink(jobID,employeeID) VALUES ('4','5')
INSERT INTO JobEmployeeLink(jobID,employeeID) VALUES ('4','4')
INSERT INTO JobEmployeeLink(jobID,employeeID) VALUES ('4','4')
INSERT INTO JobEmployeeLink(jobID,employeeID) VALUES ('5','5')
INSERT INTO JobEmployeeLink(jobID,employeeID) VALUES ('5','4')

INSERT INTO ServiceRequestSpecialisationLink(ServiceRequestID,specialisationRequiredID) VALUES ('1','1')
INSERT INTO ServiceRequestSpecialisationLink(ServiceRequestID,specialisationRequiredID) VALUES ('1','4')
INSERT INTO ServiceRequestSpecialisationLink(ServiceRequestID,specialisationRequiredID) VALUES ('2','1')
INSERT INTO ServiceRequestSpecialisationLink(ServiceRequestID,specialisationRequiredID) VALUES ('2','2')
INSERT INTO ServiceRequestSpecialisationLink(ServiceRequestID,specialisationRequiredID) VALUES ('3','5')
INSERT INTO ServiceRequestSpecialisationLink(ServiceRequestID,specialisationRequiredID) VALUES ('3','4')
INSERT INTO ServiceRequestSpecialisationLink(ServiceRequestID,specialisationRequiredID) VALUES ('4','2')
INSERT INTO ServiceRequestSpecialisationLink(ServiceRequestID,specialisationRequiredID) VALUES ('5','3')
INSERT INTO ServiceRequestSpecialisationLink(ServiceRequestID,specialisationRequiredID) VALUES ('4','2')
INSERT INTO ServiceRequestSpecialisationLink(ServiceRequestID,specialisationRequiredID) VALUES ('5','1')

INSERT INTO SpecialisationEmployeeLink(employeeID,specialisationID) VALUES ('4','3')
INSERT INTO SpecialisationEmployeeLink(employeeID,specialisationID) VALUES ('5','2')
INSERT INTO SpecialisationEmployeeLink(employeeID,specialisationID) VALUES ('4','1')
INSERT INTO SpecialisationEmployeeLink(employeeID,specialisationID) VALUES ('5','4')
INSERT INTO SpecialisationEmployeeLink(employeeID,specialisationID) VALUES ('4','5')
INSERT INTO SpecialisationEmployeeLink(employeeID,specialisationID) VALUES ('5','1')
INSERT INTO SpecialisationEmployeeLink(employeeID,specialisationID) VALUES ('4','2')
INSERT INTO SpecialisationEmployeeLink(employeeID,specialisationID) VALUES ('5','3')
INSERT INTO SpecialisationEmployeeLink(employeeID,specialisationID) VALUES ('5','4')
INSERT INTO SpecialisationEmployeeLink(employeeID,specialisationID) VALUES ('4','5')
INSERT INTO SpecialisationEmployeeLink(employeeID,specialisationID) VALUES ('7','1')
INSERT INTO SpecialisationEmployeeLink(employeeID,specialisationID) VALUES ('7','5')
INSERT INTO SpecialisationEmployeeLink(employeeID,specialisationID) VALUES ('8','2')
INSERT INTO SpecialisationEmployeeLink(employeeID,specialisationID) VALUES ('8','3')
INSERT INTO SpecialisationEmployeeLink(employeeID,specialisationID) VALUES ('8','1')
INSERT INTO SpecialisationEmployeeLink(employeeID,specialisationID) VALUES ('8','5')