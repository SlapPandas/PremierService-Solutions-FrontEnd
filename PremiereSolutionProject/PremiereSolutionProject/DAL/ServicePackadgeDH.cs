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
    public class ServicePackadgeDH : DatabaseConnection
    {
        ServiceDH serviceDH= new ServiceDH();
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
            serviceDH.InsertAllServicesOfServicePackedge(servicePackage);
            UpdateCommand($"EXEC UpdateServicePackedgeServiceList @id = '{servicePackage.PackageID}'");
        }
        public void UpdateServicePackedgePromotion(ServicePackage servicePackage)
        {
            UpdateCommand($"EXEC UpdateServicePackedgePromotion @id ='{servicePackage.PackageID}', @startDate ='{servicePackage.PromotionStartDate.ToString("yyyy-MM-dd HH:mm:ss")}',@endDate ='{servicePackage.PromotionEndDate.ToString("yyyy-MM-dd HH:mm:ss")}',@state ='{GetIntFromBool(servicePackage.OnPromotion)}',@percentage ='{servicePackage.PromotionPercentage.ToString(CultureInfo.CreateSpecificCulture("en-GB"))}'");
        }

        #endregion

        #region Insert
        public void InsertSingleServiceToServicePackadge(int ServicePackageId, int ServiceId)
        {
            InsertCommand($"EXEC InsertServicePackageLink @ServicePackageID = '{ServicePackageId}', @ServiceID = '{ServiceId}'");
        }
        public void Insert(ServicePackage servicePackage)
        {
            InsertCommand($"EXEC InsertServicePackage @name = '{servicePackage.PackageName}', @onpromotion = '{GetIntFromBool(servicePackage.OnPromotion)}', @promationStartDate = '{servicePackage.PromotionStartDate.ToString("yyyy-MM-dd HH:mm:ss")}', @promotionEndDate = '{servicePackage.PromotionEndDate.ToString("yyyy-MM-dd HH:mm:ss")}', @price = '{servicePackage.ServicePrice.ToString(CultureInfo.CreateSpecificCulture("en-GB"))}',@percintage = '{servicePackage.PromotionPercentage.ToString(CultureInfo.CreateSpecificCulture("en-GB"))}'");
        }
        public void InsertPromotion(ServicePackage servicePackage)
        {
            UpdateCommand($"EXEC UpdateServicePackagePropotion @id = '{servicePackage.PackageID}', @onPromotion = '{GetIntFromBool(servicePackage.OnPromotion)}', @promotionStartDate = '{servicePackage.PromotionStartDate.ToString("yyyy-MM-dd HH:mm:ss")}', @promotionEndDate = '{servicePackage.PromotionEndDate.ToString("yyyy-MM-dd HH:mm:ss")}', @percentage = '{servicePackage.PromotionPercentage.ToString(CultureInfo.CreateSpecificCulture("en-GB"))}'");
        }
        public void InsertAllServicesPackedgesOfContract(Contract contract)
        {
            for (int i = 0; i < contract.PackageList.Count; i++)
            {
                InsertCommand($"EXEC InsertIntoTVPContractServicePackage @contractId ='{contract.ContractID}',@servicePackageId ='{contract.PackageList[i].PackageID}'");
            }
        }
        public void InsertAllServicePackedgesOfNewContract(Contract contract)
        {
            for (int i = 0; i < contract.PackageList.Count; i++)
            {
                InsertCommand($"EXEC InsertIntoTVPNewContractServicePackedge @packedgeId = '{contract.PackageList[i].PackageID}'");
            }

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
                        servicePackedgeList.Add(new ServicePackage((int)reader["servicePackageID"], (string)reader["name"], serviceDH.SelectAllServiceInPackage((int)reader["servicePackageID"]), GetTrueFalseFromBit((int)reader["onPromotion"]), (DateTime)reader["promotionStartDate"], (DateTime)reader["promotionEndDate"], reader.GetDouble(reader.GetOrdinal("promotionPercentAmount")), reader.GetDouble(reader.GetOrdinal("price"))));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
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
                        servicePackedgeList.Add(new ServicePackage((int)reader["servicePackageStateID"], (string)reader["name"], serviceDH.SelectAllServiceInPackageState((int)reader["servicePackageStateID"]), GetTrueFalseFromBit((int)reader["onPromotion"]), (DateTime)reader["promotionStartDate"], (DateTime)reader["promotionEndDate"], reader.GetDouble(reader.GetOrdinal("promotionPercentAmount")), reader.GetDouble(reader.GetOrdinal("price"))));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally {}

            return servicePackedgeList;
        }
        public List<ServicePackage> SelectAllServicePackedgesLinkedToContract(int contractid)
        {
            List<ServicePackage> servicePackedgeList = new List<ServicePackage>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAllServicePackedgesLinkedToContract @id = '{contractid}'";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        servicePackedgeList.Add(new ServicePackage((int)reader["servicePackageID"], (string)reader["name"], serviceDH.SelectAllServiceInPackage((int)reader["servicePackageID"]), GetTrueFalseFromBit((int)reader["onPromotion"]), (DateTime)reader["promotionStartDate"], (DateTime)reader["promotionEndDate"], reader.GetDouble(reader.GetOrdinal("promotionPercentAmount")), reader.GetDouble(reader.GetOrdinal("price"))));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally { }
            return servicePackedgeList;
        }
        public List<ServicePackage> SelectAllServicePackedgesLinkedToContractState(int contractid)
        {
            List<ServicePackage> servicePackedgeList = new List<ServicePackage>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAllServicePackedgesLinkedToContractState @id = '{contractid}'";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        servicePackedgeList.Add(new ServicePackage((int)reader["servicePackageStateID"], (string)reader["name"], serviceDH.SelectAllServiceInPackageState((int)reader["servicePackageStateID"]), GetTrueFalseFromBit((int)reader["onPromotion"]), (DateTime)reader["promotionStartDate"], (DateTime)reader["promotionEndDate"], reader.GetDouble(reader.GetOrdinal("promotionPercentAmount")), reader.GetDouble(reader.GetOrdinal("price"))));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally { }
            return servicePackedgeList;
        }

        #endregion

        #region SeperateMethods
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
