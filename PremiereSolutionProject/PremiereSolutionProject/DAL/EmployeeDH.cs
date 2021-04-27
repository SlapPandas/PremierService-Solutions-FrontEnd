using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiereSolutionProject.DAL
{
    class EmployeeDH : DatabaseConnection
    {
        #region Update
        public void Update(Employee employee)
        {
            CreateConnection();
            commandString = $"EXEC UpdateEmployee @id = '{employee.Id}', @firstName = '{employee.FirstName}', @surname = '{employee.Surname}', @address = '{employee.Address}', @contactNumber = '{employee.ContactNumber}', @email = '{employee.Email}', @nationalID = '{employee.NationalIDnumber}', @registrationDate = '{employee.RegistrationDate.ToString("yyyy-MM-dd HH:mm:ss")}', @employed = '{employee.Employed}', @department = '{employee.Department}'";
            Command = new SqlCommand(commandString, Connection);

            try
            {
                OpenConnection();
                Command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally
            {
                CloseConnection();
            }
        }

        #endregion

        #region Insert
        public void Insert(Employee employee)
        {
            CreateConnection();
            commandString = $"EXEC InsertEmployee @id = '{employee.Id}', @firstName = '{employee.FirstName}', @surname = '{employee.Surname}', @address = '{employee.Address}', @contactNumber = '{employee.ContactNumber}', @email = '{employee.Email}', @nationalID = '{employee.NationalIDnumber}', @registrationDate = '{employee.RegistrationDate.ToString("yyyy-MM-dd HH:mm:ss")}', @employed = '{employee.Employed}'";
            Command = new SqlCommand(commandString, Connection);

            try
            {
                OpenConnection();
                Command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally
            {
                CloseConnection();
            }
        }

        #endregion

        #region Select
        public List<CallCenterEmployee> SelectAllCallCenterEmployees()
        {
            CreateConnection();
            commandString = $"EXEC SelectCallCenterEmployees";
            Command = new SqlCommand(commandString, Connection);
            List<CallCenterEmployee> callCenterEmployeeList = new List<CallCenterEmployee>();
            try
            {
                OpenConnection();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    callCenterEmployeeList.Add(new CallCenterEmployee((string)Reader["employeeNumber"], (string)Reader["firstName"], (string)Reader["surname"], new Address((int)Reader["addressID"], (string)Reader["streetName"], (string)Reader["suburb"], GetProvince((string)Reader["province"]), (string)Reader["postalcode"]), (string)Reader["contactNumber"], (string)Reader["email"], (string)Reader["nationalIdNumber"], (DateTime)Reader["employmentDate"], GetTrueFalseFromBit((int)Reader["employed"]), (string)Reader["department"]));
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }

            return callCenterEmployeeList;
        }

        public List<MaintenanceEmployee> SelectAllMaintenanceEmployees()
        {
            CreateConnection();
            commandString = $"EXEC SelectMaintenanceEmployees";
            Command = new SqlCommand(commandString, Connection);
            List<MaintenanceEmployee> maintenanceEmployeeList = new List<MaintenanceEmployee>();
            try
            {
                OpenConnection();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {

                    maintenanceEmployeeList.Add(new MaintenanceEmployee((string)Reader["employeeNumber"], (string)Reader["firstName"], (string)Reader["surname"], new Address((int)Reader["addressID"], (string)Reader["streetName"], (string)Reader["suburb"], GetProvince((string)Reader["province"]), (string)Reader["postalcode"]), (string)Reader["contactNumber"], (string)Reader["email"], (string)Reader["nationalIdNumber"], (DateTime)Reader["employmentDate"], GetSpecialisationByEmployeeId((int)Reader["employeeID"]), GetTrueFalseFromBit((int)Reader["employed"]), (string)Reader["department"]));
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }

            return maintenanceEmployeeList;
        }
        public List<MaintenanceEmployee> SelectAllAvailableMaintenanceEmployees()
        {
            CreateConnection();
            commandString = $"EXEC SelectAvailableMaintenanceEmployees";
            Command = new SqlCommand(commandString, Connection);
            List<MaintenanceEmployee> maintenanceEmployeeList = new List<MaintenanceEmployee>();
            try
            {
                OpenConnection();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {

                    maintenanceEmployeeList.Add(new MaintenanceEmployee((string)Reader["employeeNumber"], (string)Reader["firstName"], (string)Reader["surname"], new Address(-1, (string)Reader["streetName"], (string)Reader["suburb"], GetProvince((string)Reader["province"]), (string)Reader["postalcode"]), (string)Reader["contactNumber"], (string)Reader["email"], (string)Reader["nationalIdNumber"], (DateTime)Reader["employmentDate"], GetSpecialisationByEmployeeId((int)Reader["employeeID"]), GetTrueFalseFromBit((int)Reader["employed"]), (string)Reader["department"]));
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }

            return maintenanceEmployeeList;
        }
        public List<ServiceManager> SelectAllServiceManagers()
        {
            CreateConnection();
            commandString = $"EXEC SelectServiceManagers";
            Command = new SqlCommand(commandString, Connection);
            List<ServiceManager> serviceManagerList = new List<ServiceManager>();
            try
            {
                OpenConnection();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {

                    serviceManagerList.Add(new ServiceManager((string)Reader["employeeNumber"], (string)Reader["firstName"], (string)Reader["surname"], new Address((int)Reader["addressID"], (string)Reader["streetName"], (string)Reader["suburb"], GetProvince((string)Reader["province"]), (string)Reader["postalcode"]), (string)Reader["contactNumber"], (string)Reader["email"], (string)Reader["nationalIdNumber"], (DateTime)Reader["employmentDate"], GetTrueFalseFromBit((int)Reader["employed"]), (string)Reader["department"]));
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }

            return serviceManagerList;

        }
        #endregion

        #region Seperate Methods
        private bool GetTrueFalseFromBit(int bit)
        {
            bool output = bit == 1 ? true : false;
            return output;
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
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
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
