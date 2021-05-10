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
    class ContractDH : DatabaseConnection
    {
        #region Delete
        public void Delete(Contract contract)
        {
            DeleteCommand($"EXEC DeleteContract @id = '{contract.ContractID}'");
        }
        #endregion

        #region Update

        public void Update(Contract contract)
        {
            UpdateCommand($"EXEC UpdateContract @id ='{contract.ContractID}', @startdate ='{contract.StartTime}', @endtime ='{contract.EndTime}', @active ='{GetIntFromBool(contract.Active)}', @priorityLevel ='{contract.PriorityLevel}', @price ='{contract.Price.ToString(CultureInfo.CreateSpecificCulture("en-GB"))}', @contractType ='{contract.ContractType}'");
        }
        public void UpdateOfferedContractIfActive(string contractId, bool active)
        {
            UpdateCommand($"EXEC UpdateOfferedContractActive @id ='{contractId}', @active ='{GetIntFromBool(active)}'");
        }
        public void UpdateClientContractIfActive(string contractId, bool active)
        {
            UpdateCommand($"EXEC UpdateClientContractActive @id ='{contractId}', @active ='{GetIntFromBool(active)}'");
        }
        public void UpdateActiveAndDateRangeOfOfferedContract(string contractId,DateTime startDate,DateTime endDate, bool active)
        {
            UpdateCommand($"EXEC UpdateOfferedContractActiveAndDateRange @id ='{contractId}', @active ='{GetIntFromBool(active)}',@dateStart ='{startDate}',@dateEnd ='{endDate}'");
        }
        public void UpdateContractPackageList(Contract contract)
        {
            InsertAllServicesPackedgesOfContract(contract);
            UpdateCommand($"EXEC UpdateContractPackageList @id = '{contract.ContractID}'");
        }
        #endregion

        #region Insert
        public void InsertWithPackedge(Contract contract)
        {
            InsertAllServicePackedgesOfNewContract(contract);
            InsertCommand($"EXEC InsertContractWithPackadgeList @startDate = '{contract.StartTime.ToString("yyyy-MM-dd HH:mm:ss")}', @endDate = '{contract.EndTime.ToString("yyyy-MM-dd HH:mm:ss")}', @active ='{GetIntFromBool(contract.Active)}', @priorityLevel = '{contract.PriorityLevel}', @price = '{contract.Price.ToString(CultureInfo.CreateSpecificCulture("en-GB"))}', @contractType = '{contract.ContractType}'");
        }
        public void InsertSingleServicePackedgeToContract(string contractId, int ServicePackageId)
        {
            InsertCommand($"EXEC InsertServiceContractLink @ContractID ='{contractId}', @ServicePackageID ='{ServicePackageId}'"); 
        }
        public void InsertNewlyAssignedContractToIndividualClient(Contract contract) 
        {
            int contractGenetatedId = InsertCommandWithReturnedId($"EXEC InsertContractOfClient @contractId ='{contract.ContractID}', @startDate ='{contract.StartTime}', @endDate ='{contract.EndTime}', @active ='{GetIntFromBool(contract.Active)}'");
            InsertCommand($"InsertClientContractLinkIndividualClient @ContractID ='{contractGenetatedId}', @ClientIndividualID ='{contract.Indclient.Id}'");
            for (int i = 0; i < contract.PackageList.Count; i++)
            {
                int packedgeId = InsertCommandWithReturnedId($"EXEC InsertServicePackageState @id ='{contract.PackageList[i].PackageID}'");
                InsertCommand($"InsertServiceContractStateLink @contractStateID ='{contractGenetatedId}', @ServicePackageStateID ='{packedgeId}'");
                for (int j = 0; j < contract.PackageList[i].ServiceList.Count; j++)
                {
                    int serviceId = InsertCommandWithReturnedId($"EXEC InsertServiceState @id ='{contract.PackageList[i].ServiceList[j].ServiceID}'");
                    InsertCommand($"InsertServicePackageStateLink @ServicePackageStateID ='{packedgeId}', @ServiceStateID ='{serviceId}'");
                }
            }
        }
        public void InsertNewlyAssignedContractToBusinessClient(Contract contract)
        {
            int contractGenetatedId = -1;
            contractGenetatedId = InsertCommandWithReturnedId($"EXEC InsertContractOfClient @contractId ='{contract.ContractID}', @startDate ='{contract.StartTime}', @endDate ='{contract.EndTime}', @active ='{GetIntFromBool(contract.Active)}'");
            InsertCommand($"InsertClientContractLinkBusinessClient @ContractID ='{contractGenetatedId}', @ClientBusinessID ='{contract.Indclient.Id}'");
            for (int i = 0; i < contract.PackageList.Count; i++)
            {
                int packedgeId = InsertCommandWithReturnedId($"EXEC InsertServicePackageState @id ='{contract.PackageList[i].PackageID}'");
                InsertCommand($"InsertServiceContractStateLink @contractStateID ='{contractGenetatedId}', @ServicePackageStateID ='{packedgeId}'");
                for (int j = 0; j < contract.PackageList[i].ServiceList.Count; j++)
                {
                    int serviceId = InsertCommandWithReturnedId($"EXEC InsertServiceState @id ='{contract.PackageList[i].ServiceList[j].ServiceID}'");
                    InsertCommand($"InsertServicePackageStateLink @ServicePackageStateID ='{packedgeId}', @ServiceStateID ='{serviceId}'");
                }
            }
        }
        #endregion


        #region Select
        public List<Contract> SelectAllContracts()
        {
            List<Contract> contractList = new List<Contract>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAllContracts";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        contractList.Add(new Contract((string)reader["contractNumber"],GetTrueFalseFromBit((int)reader["activeContract"]), (DateTime)reader["startDate"], (DateTime)reader["endDate"], SelectAllServicePackedgesLinkedToContract((int)reader["contractID"]), (string)reader["priorityLevel"], reader.GetDouble(reader.GetOrdinal("price")), (string)reader["contractType"]));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally {}

            return contractList;
        }
        public Contract SelectOfferedContractById(string input)
        {
            Contract contract = new Contract();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectContractByID @id ='{input}'";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        contract = new Contract((string)reader["contractNumber"], GetTrueFalseFromBit((int)reader["activeContract"]), (DateTime)reader["startDate"], (DateTime)reader["endDate"], SelectAllServicePackedgesLinkedToContract((int)reader["contractID"]), (string)reader["priorityLevel"], reader.GetDouble(reader.GetOrdinal("price")), (string)reader["contractType"]);
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally { }

            return contract;
        }
        public Contract SelectAssignedContractByIdAndIndividualClientId(string contractId,string clientId)
        {
            Contract contract = new Contract();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectContractByIndividualClientIdAndContractId @clientId ='{clientId}',@contractId ='{contractId}'";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        contract = new Contract((string)reader["contractNumber"], GetTrueFalseFromBit((int)reader["activeContract"]), (DateTime)reader["startDate"], (DateTime)reader["endDate"], SelectAllServicePackedgesLinkedToContract((int)reader["contractID"]), (string)reader["priorityLevel"], reader.GetDouble(reader.GetOrdinal("price")), (string)reader["contractType"]);
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally { }

            return contract;
        }
        public Contract SelectAssignedContractByIdAndBusinessClientId(string contractId, string clientId)
        {
            Contract contract = new Contract();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAllContractsByBusinessClientIdAndContractId @clientId ='{clientId}',@contractId ='{contractId}'";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        contract = new Contract((string)reader["contractNumber"], GetTrueFalseFromBit((int)reader["activeContract"]), (DateTime)reader["startDate"], (DateTime)reader["endDate"], SelectAllServicePackedgesLinkedToContract((int)reader["contractID"]), (string)reader["priorityLevel"], reader.GetDouble(reader.GetOrdinal("price")), (string)reader["contractType"]);
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally { }

            return contract;
        }
        public List<Contract> SelectAllActiveContracts()
        {
            List<Contract> contractList = new List<Contract>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAllActiveContracts";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        contractList.Add(new Contract((string)reader["contractNumber"], GetTrueFalseFromBit((int)reader["activeContract"]), (DateTime)reader["startDate"], (DateTime)reader["endDate"], SelectAllServicePackedgesLinkedToContract((int)reader["contractID"]), (string)reader["priorityLevel"], reader.GetDouble(reader.GetOrdinal("price")), (string)reader["contractType"]));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally {}

            return contractList;
        }
        public List<Contract> SelectAllContractsByIndividualClientId(string id)
        {
            List<Contract> contractList = new List<Contract>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAllContractsByIndividualClientId @id = '{id}'";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        contractList.Add(new Contract((string)reader["contractNumber"], (DateTime)reader["startDate"], (DateTime)reader["endDate"], new IndividualClient((string)reader["clientIndividualClientNumber"], (string)reader["firstName"], (string)reader["surname"], new Address((int)reader["addressID"], (string)reader["streetName"], (string)reader["suburb"], (string)reader["city"], GetProvince((string)reader["province"]), (string)reader["postalcode"]), (string)reader["contactNumber"], (string)reader["email"], (string)reader["nationalIdNumber"], (DateTime)reader["RegistrationDate"], GetTrueFalseFromBit((int)reader["active"])), SelectAllServicePackedgesLinkedToContractState((int)reader["contractID"]), GetTrueFalseFromBit((int)reader["activeContract"]), (string)reader["priorityLevel"], reader.GetDouble(reader.GetOrdinal("price")), (string)reader["contractType"]));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally {}

            return contractList;
        }
        public List<Contract> SelectAllContractsByBusinessClientId(string id)
        {
            List<Contract> contractList = new List<Contract>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAllContractsByBusinessClientId @id = '{id}'";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        contractList.Add(new Contract((string)reader["contractNumber"], (DateTime)reader["startDate"], (DateTime)reader["endDate"], new BusinessClient((string)reader["clientBusinessClientNumber"], new Address((int)reader["addressID"], (string)reader["streetName"], (string)reader["suburb"], (string)reader["city"], GetProvince((string)reader["province"]), (string)reader["postalcode"]), (string)reader["contactNumber"], (DateTime)reader["RegistrationDate"], (string)reader["taxNumber"], (string)reader["busuinessName"], GetTrueFalseFromBit((int)reader["active"])), SelectAllServicePackedgesLinkedToContractState((int)reader["contractID"]), GetTrueFalseFromBit((int)reader["activeContract"]), (string)reader["priorityLevel"], reader.GetDouble(reader.GetOrdinal("price")), (string)reader["contractType"]));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally {}

            return contractList;
        }
        public List<Contract> SelectAllContractsAssignedToClientWithThereUses()
        {
            List<Contract> contractList = new List<Contract>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC AllContractUses";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        contractList.Add(new Contract((string)reader["id"],(int)reader["uses"]));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally { }

            return contractList;
        }
        #endregion


        #region SeperateMethods
        private void InsertAllServicesPackedgesOfContract(Contract contract)
        {
            for (int i = 0; i < contract.PackageList.Count; i++)
            {
                InsertCommand($"EXEC InsertIntoTVPContractServicePackage @contractId ='{contract.ContractID}',@servicePackageId ='{contract.PackageList[i].PackageID}'");
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
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally { }
            return serivceList;
        }
        private List<Service> SelectAllServicesLinkedToPackedgeState(int id)
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
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally { }
            return serivceList;
        }
        private List<ServicePackage> SelectAllServicePackedgesLinkedToContract(int contractid)
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
                        servicePackedgeList.Add(new ServicePackage((int)reader["servicePackageID"], (string)reader["name"], SelectAllServicesLinkedToPackedge((int)reader["servicePackageID"]), GetTrueFalseFromBit((int)reader["onPromotion"]), (DateTime)reader["promotionStartDate"], (DateTime)reader["promotionEndDate"], reader.GetDouble(reader.GetOrdinal("promotionPercentAmount")), reader.GetDouble(reader.GetOrdinal("price"))));
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
        private List<ServicePackage> SelectAllServicePackedgesLinkedToContractState(int contractid)
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
                        servicePackedgeList.Add(new ServicePackage((int)reader["servicePackageStateID"], (string)reader["name"], SelectAllServicesLinkedToPackedgeState((int)reader["servicePackageStateID"]), GetTrueFalseFromBit((int)reader["onPromotion"]), (DateTime)reader["promotionStartDate"], (DateTime)reader["promotionEndDate"], reader.GetDouble(reader.GetOrdinal("promotionPercentAmount")), reader.GetDouble(reader.GetOrdinal("price"))));
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
        private void InsertAllServicePackedgesOfNewContract(Contract contract)
        {
            for (int i = 0; i < contract.PackageList.Count; i++)
            {
                InsertCommand($"EXEC InsertIntoTVPNewContractServicePackedge @packedgeId = '{contract.PackageList[i].PackageID}'");
            }

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
