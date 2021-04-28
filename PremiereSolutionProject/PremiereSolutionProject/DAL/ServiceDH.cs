using PremiereSolutionProject.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiereSolutionProject.DAL
{
    class ServiceDH : DatabaseConnection
    {
        #region Delete
        public bool Delete(Service service)
        {
            CreateConnection();
            commandString = $"EXEC DeleteService @id = '{service.ServiceID}'";
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
            finally { CloseConnection(); }
        }
        #endregion

        #region Update
        public void Update(Service service)
        {
            CreateConnection();
            commandString = $"EXEC UpdateService @id = '{service.ServiceID}', @name = '{service.ServiceName}', @description = '{service.ServiceDescription}'";
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
            finally { CloseConnection(); }
        }
        #endregion

        #region Insert
        public void Insert(Service service)
        {
            CreateConnection();
            commandString = $"EXEC InsertService @name = '{service.ServiceName}', @description = '{service.ServiceDescription}'";
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
            finally { CloseConnection(); }
        }
        #endregion

        #region Select
        public List<Service> SelectAllServices()
        {
            CreateConnection();
            commandString = $"EXEC SelectAllServices";
            Command = new SqlCommand(commandString, Connection);
            List<Service> ServiceList = new List<Service>();
            try
            {
                OpenConnection();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    ServiceList.Add(new Service((int)Reader["serviceID"], (string)Reader["name"], (string)Reader["description"]));
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }
            return ServiceList;
        }
        public List<Service> SelectAllServicesWithState()
        {
            CreateConnection();
            commandString = $"EXEC SelectAllServiceState";
            Command = new SqlCommand(commandString, Connection);
            List<Service> ServiceList = new List<Service>();
            try
            {
                OpenConnection();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    ServiceList.Add(new Service((int)Reader["serviceStateID"], (string)Reader["name"], (string)Reader["description"]));
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }
            return ServiceList;
        }
        public List<Service> SelectAllServiceInPackage(int id)
        {
            CreateConnection();
            commandString = $"EXEC SelectAllServiceInPackage @id = '{id}'";
            Command = new SqlCommand(commandString, Connection);
            List<Service> ServiceList = new List<Service>();
            try
            {
                OpenConnection();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    ServiceList.Add(new Service((int)Reader["servicePackageID"], (string)Reader["name"], (string)Reader["description"]));
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }
            return ServiceList;
        }
        public List<Service> SelectAllServiceInPackageState(int id)
        {
            CreateConnection();
            commandString = $"EXEC SelectAllServiceInPackageState @id = '{id}'";
            Command = new SqlCommand(commandString, Connection);
            List<Service> ServiceList = new List<Service>();
            try
            {
                OpenConnection();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    ServiceList.Add(new Service((int)Reader["servicePackageStateID"], (string)Reader["name"], (string)Reader["description"]));
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }
            return ServiceList;
        }
        #endregion
    }
}
