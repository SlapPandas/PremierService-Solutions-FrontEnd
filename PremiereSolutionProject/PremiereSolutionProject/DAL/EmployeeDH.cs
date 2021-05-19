using PremiereSolutionProject.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiereSolutionProject.DAL
{
    public class EmployeeDH : DatabaseConnection
    {
        SpecializationDH specializationDH = new SpecializationDH();
        AddressDH addressDH = new AddressDH();
        #region Update
        public void UpdateCallCenterEmployee(CallCenterEmployee employee)
        {
            UpdateCommand($"EXEC UpdateEmployee @id = '{employee.Id}', @firstName = '{employee.FirstName}', @surname ='{employee.Surname}', @contactNumber ='{employee.ContactNumber}', @email ='{employee.Email}', @nationalIdNumber ='{employee.NationalIDnumber}', @employmentdate ='{employee.RegistrationDate.ToString("yyyy-MM-dd")}', @employed ='{GetIntFromBool(employee.Employed)}', @department = '{employee.Department}', @adressId = '{employee.Address.AddressID}', @streetName = '{employee.Address.StreetName}', @suburb = '{employee.Address.Suburb}', @province = '{((int)employee.Address.Province).ToString()}', @postalcode = '{employee.Address.Postalcode}', @city = '{employee.Address.City}'");
        }
        public void UpdateMaintenanceEmployee(MaintenanceEmployee employee)
        {
            UpdateCommand($"EXEC UpdateEmployee @id = '{employee.Id}', @firstName = '{employee.FirstName}', @surname ='{employee.Surname}', @contactNumber ='{employee.ContactNumber}', @email ='{employee.Email}', @nationalIdNumber ='{employee.NationalIDnumber}', @employmentdate ='{employee.RegistrationDate.ToString("yyyy-MM-dd")}', @employed ='{GetIntFromBool(employee.Employed)}', @department = '{employee.Department}', @adressId = '{employee.Address.AddressID}', @streetName = '{employee.Address.StreetName}', @suburb = '{employee.Address.Suburb}', @province = '{((int)employee.Address.Province).ToString()}', @postalcode = '{employee.Address.Postalcode}', @city = '{employee.Address.City}'");
        }
        public void UpdateMaintenanceEmployeeSpecilizaitonList(MaintenanceEmployee employee)
        {
            specializationDH.InsertAllSpeciliozationOfMaintenanceEmployee(employee);
            UpdateCommand($"EXEC UpdateEmployeeWithSpecilizationList @id = '{employee.Id}'");
        }
        public void UpdateServiceManager(ServiceManager employee)
        {
            UpdateCommand($"EXEC UpdateEmployee @id = '{employee.Id}', @firstName = '{employee.FirstName}', @surname ='{employee.Surname}', @contactNumber ='{employee.ContactNumber}', @email ='{employee.Email}', @nationalIdNumber ='{employee.NationalIDnumber}', @employmentdate ='{employee.RegistrationDate.ToString("yyyy-MM-dd")}', @employed ='{GetIntFromBool(employee.Employed)}', @department = '{employee.Department}', @adressId = '{employee.Address.AddressID}', @streetName = '{employee.Address.StreetName}', @suburb = '{employee.Address.Suburb}', @province = '{((int)employee.Address.Province).ToString()}', @postalcode = '{employee.Address.Postalcode}', @city = '{employee.Address.City}'");
        }
        public void UpdateEmployeeState(string id, bool employed)
        {
            UpdateCommand($"EXEC UpdateEmployeeState @id = '{id}', @employed = '{GetIntFromBool(employed)}'");
        }

        #endregion

        #region Insert

        public void InsertCallCenterEmployee(CallCenterEmployee employee)
        {
            InsertCommand($"EXEC InsertCallCenterEmployee @firstName = '{employee.FirstName}', @surname = '{employee.Surname}', @contactNumber = '{employee.ContactNumber}', @email = '{employee.Email}', @nationalIdNumber = '{employee.NationalIDnumber}', @employmentDate = '{employee.RegistrationDate.ToString("yyyy-MM-dd")}', @employed = '{GetIntFromBool(employee.Employed)}', @department = '{employee.Department}',@streetname = '{employee.Address.StreetName}',@suburb = '{employee.Address.Suburb}',@province = '{((int)employee.Address.Province).ToString()}',@postalcode = '{employee.Address.Postalcode}', @city = '{employee.Address.City}'");
        }
        public void InsertMaintenanceEmployee(MaintenanceEmployee employee)
        {
            specializationDH.InsertAllSpeciliozationOfNewMaintenanceEmployee(employee);
            InsertCommand($"EXEC InsertMaintenanceEmployee @firstName = '{employee.FirstName}', @surname = '{employee.Surname}', @contactNumber = '{employee.ContactNumber}', @email = '{employee.Email}', @nationalIdNumber = '{employee.NationalIDnumber}', @employmentDate = '{employee.RegistrationDate.ToString("yyyy-MM-dd")}',@employed = '{GetIntFromBool(employee.Employed)}', @department = '{employee.Department}',@streetname = '{employee.Address.StreetName}',@suburb = '{employee.Address.Suburb}',@province = '{((int)employee.Address.Province).ToString()}',@postalcode = '{employee.Address.Postalcode}', @city = '{employee.Address.City}'");
        }
        public void InsertMaintenanceEmployeeWithOutSpecilizationList(MaintenanceEmployee employee)
        {
            InsertCommand($"EXEC InsertMaintenanceEmployee @firstName = '{employee.FirstName}', @surname = '{employee.Surname}', @contactNumber = '{employee.ContactNumber}', @email = '{employee.Email}', @nationalIdNumber = '{employee.NationalIDnumber}', @employmentDate = '{employee.RegistrationDate.ToString("yyyy-MM-dd")}',@employed = '{GetIntFromBool(employee.Employed)}', @department = '{employee.Department}',@streetname = '{employee.Address.StreetName}',@suburb = '{employee.Address.Suburb}',@province = '{((int)employee.Address.Province).ToString()}',@postalcode = '{employee.Address.Postalcode}', @city = '{employee.Address.City}'");
        }
        public void InsertServiceManager(ServiceManager employee)
        {
            InsertCommand($"EXEC InsertServiceManager @firstName = '{employee.FirstName}', @surname = '{employee.Surname}', @contactNumber = '{employee.ContactNumber}', @email = '{employee.Email}', @nationalIdNumber = '{employee.NationalIDnumber}', @employmentDate = '{employee.RegistrationDate.ToString("yyyy-MM-dd")}', @employed = '{GetIntFromBool(employee.Employed)}', @department = '{employee.Department}',@streetname = '{employee.Address.StreetName}',@suburb = '{employee.Address.Suburb}',@province = '{((int)employee.Address.Province).ToString()}',@postalcode = '{employee.Address.Postalcode}', @city = '{employee.Address.City}'");
        }
        public void InsertAllEmployeesOfJob(Job job)
        {
            for (int i = 0; i < job.Employee.Count; i++)
            {
                InsertCommand($"EXEC InsertIntoTVPJobEmployee @jobId = '{job.JobID}', @employeeId = '{job.Employee[i].Id}'");
            }
        }
        public void InsertAllEmployeesOfNewJob(Job job)
        {
            for (int i = 0; i < job.Employee.Count; i++)
            {
                InsertCommand($"EXEC InsertIntoTVPNewJobEmployee @employeeId = '{job.Employee[i].Id}'");
            }

        }
        #endregion

        #region Select
        public List<CallCenterEmployee> SelectAllCallCenterEmployees()
        {
            List<CallCenterEmployee> callCenterEmployeeList = new List<CallCenterEmployee>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectCallCenterEmployees";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        callCenterEmployeeList.Add(new CallCenterEmployee((string)reader["employeeNumber"], (string)reader["firstName"], (string)reader["surname"], new Address((int)reader["addressID"], (string)reader["streetName"], (string)reader["suburb"], (string)reader["city"], addressDH.GetProvince((string)reader["province"]), (string)reader["postalcode"]), (string)reader["contactNumber"], (string)reader["email"], (string)reader["nationalIdNumber"], (DateTime)reader["employmentDate"], GetTrueFalseFromBit((int)reader["employed"]), (string)reader["department"]));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally { }

            return callCenterEmployeeList;
        }
        public List<CallCenterEmployee> SelectAllCallCenterEmployeesForCall()
        {
            List<CallCenterEmployee> callCenterEmployeeList = new List<CallCenterEmployee>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectCallCenterEmployees";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        callCenterEmployeeList.Add(new CallCenterEmployee((string)reader["employeeNumber"], (string)reader["firstName"], (string)reader["surname"]));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally { }

            return callCenterEmployeeList;
        }
        public List<MaintenanceEmployee> SelectAllMaintenanceEmployees()
        {
            List<MaintenanceEmployee> maintenanceEmployeeList = new List<MaintenanceEmployee>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectMaintenanceEmployees";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        maintenanceEmployeeList.Add(new MaintenanceEmployee((string)reader["employeeNumber"], (string)reader["firstName"], (string)reader["surname"], new Address((int)reader["addressID"], (string)reader["streetName"], (string)reader["suburb"], (string)reader["city"], addressDH.GetProvince((string)reader["province"]), (string)reader["postalcode"]), (string)reader["contactNumber"], (string)reader["email"], (string)reader["nationalIdNumber"], (DateTime)reader["employmentDate"], specializationDH.GetSpecialisationByEmployeeId((int)reader["employeeID"]), GetTrueFalseFromBit((int)reader["employed"]), (string)reader["department"]));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally { }

            return maintenanceEmployeeList;
        }
        public List<MaintenanceEmployee> SelectAllMaintenanceEmployeesWithGivenSpecilization(int specilizationId)
        {
            List<MaintenanceEmployee> maintenanceEmployeeList = new List<MaintenanceEmployee>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectMaintenanceEmployeesAccordingToSpecinization @specilization = '{specilizationId}'";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        maintenanceEmployeeList.Add(new MaintenanceEmployee((string)reader["employeeNumber"], (string)reader["firstName"], (string)reader["surname"], new Address((int)reader["addressID"], (string)reader["streetName"], (string)reader["suburb"], (string)reader["city"], addressDH.GetProvince((string)reader["province"]), (string)reader["postalcode"]), (string)reader["contactNumber"], (string)reader["email"], (string)reader["nationalIdNumber"], (DateTime)reader["employmentDate"], specializationDH.GetSpecialisationByEmployeeId((int)reader["employeeID"]), GetTrueFalseFromBit((int)reader["employed"]), (string)reader["department"]));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally { }

            return maintenanceEmployeeList;
        }
        public List<MaintenanceEmployee> SelectAllAvailableMaintenanceEmployees()
        {
            List<MaintenanceEmployee> maintenanceEmployeeList = new List<MaintenanceEmployee>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAvailableMaintenanceEmployees";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        maintenanceEmployeeList.Add(new MaintenanceEmployee((string)reader["employeeNumber"], (string)reader["firstName"], (string)reader["surname"], new Address((int)reader["addressID"], (string)reader["streetName"], (string)reader["suburb"], (string)reader["city"], addressDH.GetProvince((string)reader["province"]), (string)reader["postalcode"]), (string)reader["contactNumber"], (string)reader["email"], (string)reader["nationalIdNumber"], (DateTime)reader["employmentDate"], specializationDH.GetSpecialisationByEmployeeId((int)reader["employeeID"]), GetTrueFalseFromBit((int)reader["employed"]), (string)reader["department"]));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally { }

            return maintenanceEmployeeList;
        }
        public List<ServiceManager> SelectAllServiceManagers()
        {
            List<ServiceManager> serviceManagerList = new List<ServiceManager>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectServiceManagers";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        serviceManagerList.Add(new ServiceManager((string)reader["employeeNumber"], (string)reader["firstName"], (string)reader["surname"], new Address((int)reader["addressID"], (string)reader["streetName"], (string)reader["suburb"], (string)reader["city"], addressDH.GetProvince((string)reader["province"]), (string)reader["postalcode"]), (string)reader["contactNumber"], (string)reader["email"], (string)reader["nationalIdNumber"], (DateTime)reader["employmentDate"], GetTrueFalseFromBit((int)reader["employed"]), (string)reader["department"]));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally { }          

            return serviceManagerList;

        }
        public CallCenterEmployee GetCallCenterEmployeeByCallId(int callId)
        {
            CallCenterEmployee callCenterEmployee = new CallCenterEmployee();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectCallCenterEmployeeByCallId @id = '{callId}'";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        callCenterEmployee = new CallCenterEmployee((string)reader["employeeNumber"], (string)reader["firstName"], (string)reader["surname"], new Address((int)reader["addressId"], (string)reader["streetName"], (string)reader["suburb"], (string)reader["city"], addressDH.GetProvince((string)reader["province"]), (string)reader["postalcode"]), (string)reader["contactNumber"], (string)reader["email"], (string)reader["nationalIdNumber"], (DateTime)reader["employmentDate"], GetTrueFalseFromBit((int)reader["employed"]), (string)reader["department"]);

                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally
            {

            }
            return callCenterEmployee;
        }
        public List<MaintenanceEmployee> GetMaintenanceEmployeeByJobId(int jobId)
        {
            List<MaintenanceEmployee> maintenanceEmployeeList = new List<MaintenanceEmployee>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC GetMaintenanceEmployeeByJobId @id = '{jobId}'";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        maintenanceEmployeeList.Add(new MaintenanceEmployee((string)reader["employeeNumber"], (string)reader["firstName"], (string)reader["surname"], addressDH.GetAddressById((int)reader["addressId"]), (string)reader["contactNumber"], (string)reader["email"], (string)reader["nationalIdNumber"], (DateTime)reader["employmentDate"], specializationDH.GetSpecialisationByEmployeeId((int)reader["employeeID"]), GetTrueFalseFromBit((int)reader["employed"]), (string)reader["department"]));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally { }
            return maintenanceEmployeeList;
        }
        #endregion

        #region Seperate Methods
        private bool GetTrueFalseFromBit(int bit)
        {
            bool output = bit == 1 ? true : false;
            return output;
        }
        private int GetIntFromBool(bool input)
        {
            if (input == true)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        #endregion
    }
}
