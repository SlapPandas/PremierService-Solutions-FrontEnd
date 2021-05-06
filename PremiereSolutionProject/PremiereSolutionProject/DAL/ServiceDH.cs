using PremiereSolutionProject.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiereSolutionProject.DAL
{
    public class ServiceDH : DatabaseConnection
    {
        #region Delete
        public void Delete(Service service)
        {
            DeleteCommand($"EXEC DeleteService @id = '{service.ServiceID}'");
        }
        #endregion

        #region Update
        public void Update(Service service)
        {
            UpdateCommand($"EXEC UpdateService @id = '{service.ServiceID}', @name = '{service.ServiceName}', @description = '{service.ServiceDescription}'");
        }
        #endregion

        #region Insert
        public void Insert(Service service)
        {
            InsertCommand($"EXEC InsertService @name = '{service.ServiceName}', @description = '{service.ServiceDescription}'");
        }
        #endregion

        #region Select
        public List<Service> SelectAllServices()
        {
            List<Service> serviceList = new List<Service>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAllServices";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        serviceList.Add(new Service((int)reader["serviceID"], (string)reader["name"], (string)reader["description"]));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally {}
            return serviceList;
        }
        public List<Service> SelectAllServicesWithState()
        {
            List<Service> serviceList = new List<Service>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAllServiceState";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        serviceList.Add(new Service((int)reader["serviceStateID"], (string)reader["name"], (string)reader["description"]));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally {}
            return serviceList;
        }
        public List<Service> SelectAllServiceInPackage(int id)
        {
            List<Service> serviceList = new List<Service>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAllServiceInPackage @id = '{id}'";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        serviceList.Add(new Service((int)reader["serviceID"], (string)reader["name"], (string)reader["description"]));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally {}
            return serviceList;
        }
        public List<Service> SelectAllServiceInPackageState(int id)
        {
            List<Service> serviceList = new List<Service>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAllServiceInPackageState @id = '{id}'";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        serviceList.Add(new Service((int)reader["serviceStateID"], (string)reader["name"], (string)reader["description"]));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally {}
            return serviceList;
        }
        #endregion
    }
}
