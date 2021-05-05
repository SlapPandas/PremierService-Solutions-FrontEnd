using PremiereSolutionProject.BLL;
using PremiereSolutionProject.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiereSolutionProject.DAL
{
    public class BusinessClientEmployeesDH : DatabaseConnection, IDataconnection
    {
        //Done
        #region Delete
        public void Delete(BusinessClientEmployees businessClientEmployees)
        {
            DeleteCommand($"EXEC DeleteClientBusinessEmployee @id = '{businessClientEmployees.Id}'");
        }
        #endregion

        //Done
        #region Update
        public void Update(BusinessClientEmployees businessClientEmployees)
        {
            UpdateCommand($"EXEC UpdateBusinessClientEmployee @id = '{businessClientEmployees.Id}',  @firstName = '{businessClientEmployees.FirstName}',  @surname = '{businessClientEmployees.Surname}',  @department = '{businessClientEmployees.Department}',  @contactNumber = '{businessClientEmployees.Contactnumber}',  @email = '{businessClientEmployees.Email}'");
        }
        #endregion

        //Done
        #region Insert
        public void Insert(BusinessClientEmployees businessClientEmployees)
        {
            InsertCommand($"EXEC InsertBusinessClientEmployees @firstName = '{businessClientEmployees.FirstName}',  @surname = '{businessClientEmployees.Surname}',  @department = '{businessClientEmployees.Department}',  @contactNumber = '{businessClientEmployees.Contactnumber}',  @email = '{businessClientEmployees.Email}', @businessID = '{businessClientEmployees.BusinessID}'");
        }
        #endregion


        #region Select
        public List<BusinessClientEmployees> SelectAllBusinessClientEmployeesByBusinessId(string businessId)
        {
            List<BusinessClientEmployees> businessClientemployeeList = new List<BusinessClientEmployees>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAllBusinessClientEmployeesByBusinessId @businessid = '{businessId}'";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        businessClientemployeeList.Add(new BusinessClientEmployees((int)Reader["clientBusinessEmployeeID"], (string)Reader["firstName"], (string)Reader["surname"], (string)Reader["department"], (string)Reader["contactNumber"], (string)Reader["email"], (string)Reader["busuinessName"]));
                    }
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { }

            return businessClientemployeeList;

        }

        public List<BusinessClientEmployees> SelectAllBusinessClientEmployees()
        {
            List<BusinessClientEmployees> businessClientemployeeList = new List<BusinessClientEmployees>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAllBusinessClientEmployees";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        businessClientemployeeList.Add(new BusinessClientEmployees((int)Reader["clientBusinessEmployeeID"], (string)Reader["firstName"], (string)Reader["surname"], (string)Reader["department"], (string)Reader["contactNumber"], (string)Reader["email"], (string)Reader["busuinessName"]));
                    }
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { }

            return businessClientemployeeList;
        }
        #endregion


        #region SeperateMethods
        private Address GetAddressById(int addressId)
        {
            Address myAddress = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAddress = '{addressId}'";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        myAddress = new Address((int)Reader["addressID"], (string)Reader["streetName"], (string)Reader["suburb"], (string)Reader["city"], GetProvince((string)Reader["province"]), (string)Reader["postalcode"]);
                    }
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { }
           
            return myAddress;

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
        #endregion
    }
}
