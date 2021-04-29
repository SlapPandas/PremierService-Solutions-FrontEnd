using PremiereSolutionProject.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiereSolutionProject.DAL
{
    class ServicePackadgeDH : DatabaseConnection
    {
        #region Delete
        public void Delete(ServicePackage servicePackage)
        {
            CreateConnection();
            commandString = $"EXEC DeleteServicePackage @id = '{servicePackage.PackageID}'";
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

        #region Update
        public void Update(ServicePackage servicePackage)
        {
            CreateConnection();
            commandString = $"EXEC UpdateServicePackage @id = '{servicePackage.PackageID}', @name = '{servicePackage.PackageName}', @price = '{servicePackage.ServicePrice}'";
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
        public void UpdatePromotionState(int id, bool state)
        {
            CreateConnection();
            commandString = $"EXEC UpdateServicePackageState @id = '{id}', @onPromotion = '{GetIntFromBool(state)}'";
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
        public void UpdateServicePackedgeServiceList(ServicePackage servicePackage)
        {
            InsertAllServicesOfServicePackedge(servicePackage);
            CreateConnection();
            commandString = $"EXEC UpdateServicePackedgeServiceList @id = '{servicePackage.PackageID}'";
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
        public void InsertSingleServiceToServicePackadge(int ServicePackedgeId, int Service)
        {
            CreateConnection();
            commandString = $"EXEC InsertServicePackageLink @ServicePackageID = '{ServicePackedgeId}', @ServiceID = '{Service}'";
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
        public void Insert(ServicePackage servicePackage)
        {
            CreateConnection();
            commandString = $"EXEC InsertServicePackage @name = '{servicePackage.PackageName}', @onpromotion = '{GetIntFromBool(servicePackage.OnPromotion)}', @promationStartDate = '{servicePackage.PromotionStartDate}', @promotionEndDate = '{servicePackage.PromotionEndDate}', @price = '{servicePackage.ServicePrice}',@percintage = '{servicePackage.PromotionPercentage}'";
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
        public void InsertPromotion(ServicePackage servicePackage)
        {
            CreateConnection();
            commandString = $"EXEC UpdateServicePackagePropotion @id = '{servicePackage.PackageID}', @onPromotion = '{GetIntFromBool(servicePackage.OnPromotion)}', @promotionStartDate = '{servicePackage.PromotionStartDate.ToString("yyyy-MM-dd HH:mm:ss")}', @promotionEndDate = '{servicePackage.PromotionEndDate.ToString("yyyy-MM-dd HH:mm:ss")}', @percentage = '{servicePackage.PromotionPercentage}'";
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
        public List<ServicePackage> SelectAllServicePackedges()
        {
            CreateConnection();
            commandString = $"EXEC SelectAllServicePackages";
            Command = new SqlCommand(commandString, Connection);
            List<ServicePackage> servicePackedgeList = new List<ServicePackage>();
            try
            {
                OpenConnection();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    servicePackedgeList.Add(new ServicePackage((int)Reader["servicePackageID"], (string)Reader["name"], SelectAllServicesLinkedToPackedge((int)Reader["servicePackageID"]), GetTrueFalseFromBit((int)Reader["onPromotion"]), (DateTime)Reader["promotionStartDate"], (DateTime)Reader["promotionEndDate"], Reader.GetDouble(Reader.GetOrdinal("promotionPercentAmount")), Reader.GetDouble(Reader.GetOrdinal("price"))));
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }

            return servicePackedgeList;
        }
        public List<ServicePackage> SelectAllServicePackedgesWithState()
        {
            CreateConnection();
            commandString = $"EXEC SelectAllServicePackageStates";
            Command = new SqlCommand(commandString, Connection);
            List<ServicePackage> servicePackedgeList = new List<ServicePackage>();
            try
            {
                OpenConnection();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    servicePackedgeList.Add(new ServicePackage((int)Reader["servicePackageStateID"], (string)Reader["name"], SelectAllServicesLinkedToPackedgeWithState((int)Reader["servicePackageStateID"]), GetTrueFalseFromBit((int)Reader["onPromotion"]), (DateTime)Reader["promotionStartDate"], (DateTime)Reader["promotionEndDate"], Reader.GetDouble(Reader.GetOrdinal("promotionPercentAmount")), Reader.GetDouble(Reader.GetOrdinal("price"))));
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }

            return servicePackedgeList;
        }
        #endregion

        #region SeperateMethods
        private void InsertAllServicesOfServicePackedge(ServicePackage servicePackage)
        {
            SqlConnection servicePackagejobConnection = new SqlConnection(connectionSring);

            try
            {
                servicePackagejobConnection.Open();
                for (int i = 0; i < servicePackage.ServiceList.Count; i++)
                {
                    commandString = $"EXEC InsertIntoTVPPackedgeService @packedgeId = '{servicePackage.PackageID}',@serviceId = '{servicePackage.ServiceList[i].ServiceID}'";
                    SqlCommand servicePackageCommand = new SqlCommand(commandString, servicePackagejobConnection);
                    servicePackageCommand.ExecuteNonQuery();
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
                servicePackagejobConnection.Close();
            }
        }
        private List<Service> SelectAllServicesLinkedToPackedge(int id)
        {
            SqlConnection serviceConnection = new SqlConnection(connectionSring);
            SqlDataReader serviceReader;
            List<Service> serivceList = new List<Service>();
            commandString = $"EXEC SelectAllServicesByServicePackedge @id = '{id}'";
            SqlCommand serviceCommand = new SqlCommand(commandString, serviceConnection);

            try
            {
                serviceConnection.Open();
                serviceReader = serviceCommand.ExecuteReader();
                while (serviceReader.Read())
                {
                    serivceList.Add(new Service((int)serviceReader["serviceID"], (string)serviceReader["name"], (string)serviceReader["description"]));

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
                serviceConnection.Close();
            }
            return serivceList;
        }
        private List<Service> SelectAllServicesLinkedToPackedgeWithState(int id)
        {
            SqlConnection serviceConnection = new SqlConnection(connectionSring);
            SqlDataReader serviceReader;
            List<Service> serivceList = new List<Service>();
            commandString = $"EXEC SelectAllServicesByServicePackedgeWithState @id = '{id}'";
            SqlCommand serviceCommand = new SqlCommand(commandString, serviceConnection);

            try
            {
                serviceConnection.Open();
                serviceReader = serviceCommand.ExecuteReader();
                while (serviceReader.Read())
                {
                    serivceList.Add(new Service((int)serviceReader["serviceID"], (string)serviceReader["name"], (string)serviceReader["description"]));

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
                serviceConnection.Close();
            }
            return serivceList;
        }
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
