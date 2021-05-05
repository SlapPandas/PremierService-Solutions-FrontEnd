using PremiereSolutionProject.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
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
            DeleteCommand($"EXEC DeleteServicePackage @id = '{servicePackage.PackageID}'");
        }
        #endregion

        #region Update
        public void Update(ServicePackage servicePackage)
        {
            UpdateCommand($"EXEC UpdateServicePackage @id = '{servicePackage.PackageID}', @name = '{servicePackage.PackageName}', @price = '{servicePackage.ServicePrice.ToString(CultureInfo.CreateSpecificCulture("en-GB"))}'");
        }
        public void UpdatePromotionState(int id, bool state)
        {
            UpdateCommand($"EXEC UpdateServicePackageState @id = '{id}', @onPromotion = '{GetIntFromBool(state)}'");
        }
        public void UpdateServicePackedgeServiceList(ServicePackage servicePackage)
        {
            InsertAllServicesOfServicePackedge(servicePackage);
            UpdateCommand($"EXEC UpdateServicePackedgeServiceList @id = '{servicePackage.PackageID}'");
        }

        #endregion

        #region Insert
        public void InsertSingleServiceToServicePackadge(int ServicePackageId, int ServiceId)
        {
            InsertCommand($"EXEC InsertServicePackageLink @ServicePackageID = '{ServicePackageId}', @ServiceID = '{ServiceId}'");
        }
        public void Insert(ServicePackage servicePackage)
        {
            InsertCommand($"EXEC InsertServicePackage @name = '{servicePackage.PackageName}', @onpromotion = '{GetIntFromBool(servicePackage.OnPromotion)}', @promationStartDate = '{servicePackage.PromotionStartDate}', @promotionEndDate = '{servicePackage.PromotionEndDate}', @price = '{servicePackage.ServicePrice.ToString(CultureInfo.CreateSpecificCulture("en-GB"))}',@percintage = '{servicePackage.PromotionPercentage.ToString(CultureInfo.CreateSpecificCulture("en-GB"))}'");
        }
        public void InsertPromotion(ServicePackage servicePackage)
        {
            UpdateCommand($"EXEC UpdateServicePackagePropotion @id = '{servicePackage.PackageID}', @onPromotion = '{GetIntFromBool(servicePackage.OnPromotion)}', @promotionStartDate = '{servicePackage.PromotionStartDate.ToString("yyyy-MM-dd HH:mm:ss")}', @promotionEndDate = '{servicePackage.PromotionEndDate.ToString("yyyy-MM-dd HH:mm:ss")}', @percentage = '{servicePackage.PromotionPercentage.ToString(CultureInfo.CreateSpecificCulture("en-GB"))}'");
        }
        #endregion

        #region Select
        public List<ServicePackage> SelectAllServicePackedges()
        {
            List<ServicePackage> servicePackedgeList = new List<ServicePackage>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAllServicePackages";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        servicePackedgeList.Add(new ServicePackage((int)reader["servicePackageID"], (string)reader["name"], SelectAllServicesLinkedToPackedge((int)reader["servicePackageID"]), GetTrueFalseFromBit((int)reader["onPromotion"]), (DateTime)reader["promotionStartDate"], (DateTime)reader["promotionEndDate"], reader.GetDouble(reader.GetOrdinal("promotionPercentAmount")), reader.GetDouble(reader.GetOrdinal("price"))));
                    }
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally {}

            return servicePackedgeList;
        }
        public List<ServicePackage> SelectAllServicePackedgesWithState()
        {
            List<ServicePackage> servicePackedgeList = new List<ServicePackage>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAllServicePackageStates";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        servicePackedgeList.Add(new ServicePackage((int)reader["servicePackageStateID"], (string)reader["name"], SelectAllServicesLinkedToPackedgeWithState((int)reader["servicePackageStateID"]), GetTrueFalseFromBit((int)reader["onPromotion"]), (DateTime)reader["promotionStartDate"], (DateTime)reader["promotionEndDate"], reader.GetDouble(reader.GetOrdinal("promotionPercentAmount")), reader.GetDouble(reader.GetOrdinal("price"))));
                    }
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally {}

            return servicePackedgeList;
        }
        #endregion

        #region SeperateMethods
        private void InsertAllServicesOfServicePackedge(ServicePackage servicePackage)
        {
            for (int i = 0; i < servicePackage.ServiceList.Count; i++)
            {
                InsertCommand($"EXEC InsertIntoTVPPackedgeService @packedgeId = '{servicePackage.PackageID}',@serviceId = '{servicePackage.ServiceList[i].ServiceID}'");
            }
        }
        private List<Service> SelectAllServicesLinkedToPackedge(int id)
        {
            List<Service> serivceList = new List<Service>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAllServicesByServicePackedge @id = '{id}'";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        serivceList.Add(new Service((int)reader["serviceID"], (string)reader["name"], (string)reader["description"]));
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
            return serivceList;
        }
        private List<Service> SelectAllServicesLinkedToPackedgeWithState(int id)
        {
            List<Service> serivceList = new List<Service>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAllServicesByServicePackedgeWithState @id = '{id}'";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        serivceList.Add(new Service((int)reader["serviceStateID"], (string)reader["name"], (string)reader["description"]));
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
