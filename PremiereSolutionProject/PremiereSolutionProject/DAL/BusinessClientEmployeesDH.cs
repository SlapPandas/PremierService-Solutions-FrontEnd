using PremiereSolutionProject.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiereSolutionProject.DAL
{
    class BusinessClientEmployeesDH : DatabaseConnection, IDataconnection
    {
        #region Delete
        public bool Delete(BusinessClientEmployees businessClientEmployees)
        {
            CreateConnection();
            commandString = $"EXEC DeleteBusinessClientEmployees @id = '{businessClientEmployees.Id}'";
            Command = new SqlCommand(commandString, Connection);

            try
            {
                OpenConnection();
                Command.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }
        #endregion

        #region Update
        public void Update(BusinessClientEmployees businessClientEmployees)
        {
            CreateConnection();
            commandString = $"EXEC UpdateBusinessClientEmployees @id = '{businessClientEmployees.Id}',  @firstName = '{businessClientEmployees.FirstName}',  @surname = '{businessClientEmployees.Surname}',  @department = '{businessClientEmployees.Department}',  @contactNumber = '{businessClientEmployees.Contactnumber}',  @email = '{businessClientEmployees.Email}',  @businessName = '{businessClientEmployees.BusinessName}'";
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
        public void Insert(BusinessClientEmployees businessClientEmployees)
        {
            CreateConnection();
            commandString = $"EXEC InsertBusinessClientEmployees @id = '{businessClientEmployees.Id}',  @firstName = '{businessClientEmployees.FirstName}',  @surname = '{businessClientEmployees.Surname}',  @department = '{businessClientEmployees.Department}',  @contactNumber = '{businessClientEmployees.Contactnumber}',  @email = '{businessClientEmployees.Email}',  @businessName = '{businessClientEmployees.BusinessName}'";
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
        public List<BusinessClientEmployees> SelectAllBusinessClientEmployeesByBusinessId(string businessId)
        {
            CreateConnection();
            commandString = $"EXEC SelectAllBusinessClientEmployeesByBusinessId @businessid = '{businessId}'";
            Command = new SqlCommand(commandString, Connection);
            List<BusinessClientEmployees> businessClientemployeeList = new List<BusinessClientEmployees>();
            try
            {
                OpenConnection();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    businessClientemployeeList.Add(new BusinessClientEmployees((int)Reader["clientBusinessEmployeeID"], (string)Reader["firstName"], (string)Reader["surname"], (string)Reader["department"], (string)Reader["contactNumber"], (string)Reader["email"], (string)Reader["busuinessName"]));
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }

            return businessClientemployeeList;

        }

        public List<BusinessClientEmployees> SelectAllBusinessClientEmployees()
        {
            CreateConnection();
            commandString = $"EXEC SelectAllBusinessClientEmployees";
            Command = new SqlCommand(commandString, Connection);
            List<BusinessClientEmployees> businessClientemployeeList = new List<BusinessClientEmployees>();
            try
            {
                OpenConnection();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    businessClientemployeeList.Add(new BusinessClientEmployees((int)Reader["clientBusinessEmployeeID"], (string)Reader["firstName"], (string)Reader["surname"], (string)Reader["department"], (string)Reader["contactNumber"], (string)Reader["email"], (string)Reader["busuinessName"]));
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }

            return businessClientemployeeList;
        }
        #endregion

        #region SeperateMethods
        private Address GetAddressById(int addressId)
        {
            commandString = $"EXEC SelectAddress = '{addressId}'";
            Command = new SqlCommand(commandString, Connection);
            Address myAddress = null;

            try
            {
                OpenConnection();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    myAddress = new Address((int)Reader["ID"], (string)Reader["streetName"], (string)Reader["suburb"], (Province)Reader["province"], (string)Reader["postalcode"]);
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }
            return myAddress;

        }
        #endregion
    }
}
