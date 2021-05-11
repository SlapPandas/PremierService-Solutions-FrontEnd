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
        //Need assistance
        #region Update
        public void UpdateCallCenterEmployee(CallCenterEmployee employee)
        {
            UpdateCommand($"EXEC UpdateEmployee @id = '{employee.Id}', @firstName = '{employee.FirstName}', @surname ='{employee.Surname}', @contactNumber ='{employee.ContactNumber}', @email ='{employee.Email}', @nationalIdNumber ='{employee.NationalIDnumber}', @employmentdate ='{employee.RegistrationDate.ToString("yyyy-MM-dd")}', @employed ='{GetIntFromBool(employee.Employed)}', @department = '{employee.Department}', @adressId = '{employee.Address.AddressID}', @streetName = '{employee.Address.StreetName}', @suburb = '{employee.Address.Suburb}', @province = '{((int)employee.Address.Province).ToString()}', @postalcode = '{employee.Address.Postalcode}', @city = '{employee.Address.City}'");
        }

        public void UpdateMaintenanceEmployee(MaintenanceEmployee employee)
        {
            InsertAllSpeciliozationOfMaintenanceEmployee(employee);
            UpdateCommand($"EXEC UpdateEmployee @id = '{employee.Id}', @firstName = '{employee.FirstName}', @surname ='{employee.Surname}', @contactNumber ='{employee.ContactNumber}', @email ='{employee.Email}', @nationalIdNumber ='{employee.NationalIDnumber}', @employmentdate ='{employee.RegistrationDate.ToString("yyyy-MM-dd")}', @employed ='{GetIntFromBool(employee.Employed)}', @department = '{employee.Department}', @adressId = '{employee.Address.AddressID}', @streetName = '{employee.Address.StreetName}', @suburb = '{employee.Address.Suburb}', @province = '{((int)employee.Address.Province).ToString()}', @postalcode = '{employee.Address.Postalcode}', @city = '{employee.Address.City}'");
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

        //Done
        #region Insert

        public void InsertCallCenterEmployee(CallCenterEmployee employee)
        {
            InsertCommand($"EXEC InsertCallCenterEmployee @firstName = '{employee.FirstName}', @surname = '{employee.Surname}', @contactNumber = '{employee.ContactNumber}', @email = '{employee.Email}', @nationalIdNumber = '{employee.NationalIDnumber}', @employmentDate = '{employee.RegistrationDate.ToString("yyyy-MM-dd")}', @employed = '{GetIntFromBool(employee.Employed)}', @department = '{employee.Department}',@streetname = '{employee.Address.StreetName}',@suburb = '{employee.Address.Suburb}',@province = '{((int)employee.Address.Province).ToString()}',@postalcode = '{employee.Address.Postalcode}', @city = '{employee.Address.City}'");
        }

        public void InsertMaintenanceEmployee(MaintenanceEmployee employee)
        {
            InsertAllSpeciliozationOfNewMaintenanceEmployee(employee);
            InsertCommand($"EXEC InsertMaintenanceEmployee @firstName = '{employee.FirstName}', @surname = '{employee.Surname}', @contactNumber = '{employee.ContactNumber}', @email = '{employee.Email}', @nationalIdNumber = '{employee.NationalIDnumber}', @employmentDate = '{employee.RegistrationDate.ToString("yyyy-MM-dd")}',@employed = '{GetIntFromBool(employee.Employed)}', @department = '{employee.Department}',@streetname = '{employee.Address.StreetName}',@suburb = '{employee.Address.Suburb}',@province = '{((int)employee.Address.Province).ToString()}',@postalcode = '{employee.Address.Postalcode}', @city = '{employee.Address.City}'");
        }

        public void InsertServiceManager(ServiceManager employee)
        {
            InsertCommand($"EXEC InsertServiceManager @firstName = '{employee.FirstName}', @surname = '{employee.Surname}', @contactNumber = '{employee.ContactNumber}', @email = '{employee.Email}', @nationalIdNumber = '{employee.NationalIDnumber}', @employmentDate = '{employee.RegistrationDate.ToString("yyyy-MM-dd")}', @employed = '{GetIntFromBool(employee.Employed)}', @department = '{employee.Department}',@streetname = '{employee.Address.StreetName}',@suburb = '{employee.Address.Suburb}',@province = '{((int)employee.Address.Province).ToString()}',@postalcode = '{employee.Address.Postalcode}', @city = '{employee.Address.City}'");
        }

        #endregion

        //Done
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
                        callCenterEmployeeList.Add(new CallCenterEmployee((string)reader["employeeNumber"], (string)reader["firstName"], (string)reader["surname"], new Address((int)reader["addressID"], (string)reader["streetName"], (string)reader["suburb"], (string)reader["city"], GetProvince((string)reader["province"]), (string)reader["postalcode"]), (string)reader["contactNumber"], (string)reader["email"], (string)reader["nationalIdNumber"], (DateTime)reader["employmentDate"], GetTrueFalseFromBit((int)reader["employed"]), (string)reader["department"]));
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
                        maintenanceEmployeeList.Add(new MaintenanceEmployee((string)reader["employeeNumber"], (string)reader["firstName"], (string)reader["surname"], new Address((int)reader["addressID"], (string)reader["streetName"], (string)reader["suburb"], (string)reader["city"], GetProvince((string)reader["province"]), (string)reader["postalcode"]), (string)reader["contactNumber"], (string)reader["email"], (string)reader["nationalIdNumber"], (DateTime)reader["employmentDate"], GetSpecialisationByEmployeeId((int)reader["employeeID"]), GetTrueFalseFromBit((int)reader["employed"]), (string)reader["department"]));
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
                        maintenanceEmployeeList.Add(new MaintenanceEmployee((string)reader["employeeNumber"], (string)reader["firstName"], (string)reader["surname"], new Address((int)reader["addressID"], (string)reader["streetName"], (string)reader["suburb"], (string)reader["city"], GetProvince((string)reader["province"]), (string)reader["postalcode"]), (string)reader["contactNumber"], (string)reader["email"], (string)reader["nationalIdNumber"], (DateTime)reader["employmentDate"], GetSpecialisationByEmployeeId((int)reader["employeeID"]), GetTrueFalseFromBit((int)reader["employed"]), (string)reader["department"]));
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
                        maintenanceEmployeeList.Add(new MaintenanceEmployee((string)reader["employeeNumber"], (string)reader["firstName"], (string)reader["surname"], new Address((int)reader["addressID"], (string)reader["streetName"], (string)reader["suburb"], (string)reader["city"], GetProvince((string)reader["province"]), (string)reader["postalcode"]), (string)reader["contactNumber"], (string)reader["email"], (string)reader["nationalIdNumber"], (DateTime)reader["employmentDate"], GetSpecialisationByEmployeeId((int)reader["employeeID"]), GetTrueFalseFromBit((int)reader["employed"]), (string)reader["department"]));
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
                        serviceManagerList.Add(new ServiceManager((string)reader["employeeNumber"], (string)reader["firstName"], (string)reader["surname"], new Address((int)reader["addressID"], (string)reader["streetName"], (string)reader["suburb"], (string)reader["city"], GetProvince((string)reader["province"]), (string)reader["postalcode"]), (string)reader["contactNumber"], (string)reader["email"], (string)reader["nationalIdNumber"], (DateTime)reader["employmentDate"], GetTrueFalseFromBit((int)reader["employed"]), (string)reader["department"]));
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

        private void InsertAllSpeciliozationOfMaintenanceEmployee(MaintenanceEmployee employee)
        {
            for (int i = 0; i < employee.Specialisations.Count; i++)
            {
                InsertCommand($"EXEC InsertIntoTVPMaintenanceEmployeeSpecilization @employeeId = '{employee.Id}', @SpecilizationId = '{employee.Specialisations[i].SpecialisationID}'");
            }
        }

        private void InsertAllSpeciliozationOfNewMaintenanceEmployee(MaintenanceEmployee employee)
        {
            for (int i = 0; i < employee.Specialisations.Count; i++)
            {
                InsertCommand($"EXEC InsertIntoTVPNewMaintenanceEmployeeSpecilization @SpecilizationId = '{employee.Specialisations[i].SpecialisationID}'");
            }
        }

        private Province GetProvince(string input)
        {
            Province province = (Province)1;

            switch (input)
            {
                case "0":
                    province = (Province)0;
                    break;
                case "1":
                    province = (Province)1;
                    break;
                case "2":
                    province = (Province)2;
                    break;
                case "3":
                    province = (Province)3;
                    break;
                case "4":
                    province = (Province)4;
                    break;
                case "5":
                    province = (Province)5;
                    break;
                case "6":
                    province = (Province)6;
                    break;
                case "7":
                    province = (Province)7;
                    break;
                case "8":
                    province = (Province)8;
                    break;
                default:
                    province = (Province)1;
                    break;
            }
            return province;
        }
        private List<Specialisation> GetSpecialisationByEmployeeId(int employeeId)
        {

            SqlConnection specialisationConnection = new SqlConnection(connectionSring);
            SqlDataReader specialisationReader;
            List<Specialisation> specialisationList = new List<Specialisation>();
            commandString = $"EXEC SelectSpecialisationByEmployeeId @id = '{employeeId}'";
            SqlCommand specialisationCommand = new SqlCommand(commandString, specialisationConnection);

            try
            {
                specialisationConnection.Open();
                specialisationReader = specialisationCommand.ExecuteReader();
                while (specialisationReader.Read())
                {
                    specialisationList.Add(new Specialisation((int)specialisationReader["specialisationID"], (string)specialisationReader["name"], (string)specialisationReader["description"]));
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally
            {
                specialisationConnection.Close();
            }
            return specialisationList;
        }
        #endregion
    }
}
