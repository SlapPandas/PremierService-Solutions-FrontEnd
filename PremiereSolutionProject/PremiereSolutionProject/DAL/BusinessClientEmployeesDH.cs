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
        #region Delete
        public void Delete(BusinessClientEmployees businessClientEmployees)
        {
            DeleteCommand($"EXEC DeleteClientBusinessEmployee @id = '{businessClientEmployees.Id}'");
        }
        #endregion

        #region Update
        public void Update(BusinessClientEmployees businessClientEmployees)
        {
            UpdateCommand($"EXEC UpdateBusinessClientEmployee @id = '{businessClientEmployees.Id}',  @firstName = '{businessClientEmployees.FirstName}',  @surname = '{businessClientEmployees.Surname}',  @department = '{businessClientEmployees.Department}',  @contactNumber = '{businessClientEmployees.Contactnumber}',  @email = '{businessClientEmployees.Email}'");
        }
        #endregion

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
                        businessClientemployeeList.Add(new BusinessClientEmployees((int)reader["clientBusinessEmployeeID"], (string)reader["firstName"], (string)reader["surname"], (string)reader["department"], (string)reader["contactNumber"], (string)reader["email"], (string)reader["busuinessName"]));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
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
                        businessClientemployeeList.Add(new BusinessClientEmployees((int)reader["clientBusinessEmployeeID"], (string)reader["firstName"], (string)reader["surname"], (string)reader["department"], (string)reader["contactNumber"], (string)reader["email"], (string)reader["busuinessName"]));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally { }

            return businessClientemployeeList;
        }
        #endregion

        #region SeperateMethods
        #endregion
    }
}
