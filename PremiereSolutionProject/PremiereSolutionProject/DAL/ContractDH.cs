using PremiereSolutionProject.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiereSolutionProject.DAL
{
    class ContractDH : DatabaseConnection
    {
        #region Delete
        public bool Delete(Contract contract)
        {
            CreateConnection();
            commandString = $"EXEC DeleteContract @id = '{contract.ContractID}'";
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
        public void Update(Contract contract)
        {
            CreateConnection();
            commandString = $"EXEC UpdateContract @id = '{contract.ContractID}', @start = '{contract.StartTime.ToString("yyyy-MM-dd HH:mm:ss")}', @end = '{contract.EndTime.ToString("yyyy-MM-dd HH:mm:ss")}', @Client = '{contract.Client}', @packageList = '{contract.PackageList}', @active = '{contract.Active}'";
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
        public void Insert(Contract contract)
        {
            CreateConnection();
            commandString = $"EXEC InsertContract @id = '{contract.ContractID}', @start = '{contract.StartTime.ToString("yyyy-MM-dd HH:mm:ss")}', @end = '{contract.EndTime.ToString("yyyy-MM-dd HH:mm:ss")}', @Client = '{contract.Client}', @packageList = '{contract.PackageList}', @active = '{contract.Active}'";
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
        public List<Contract> SelectAllContracts()
        {
            CreateConnection();
            commandString = $"EXEC SelectAllContracts";
            Command = new SqlCommand(commandString, Connection);
            List<Contract> contractList = new List<Contract>();
            try
            {
                OpenConnection();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    contractList.Add(new Contract((string)Reader["contractNumber"], (DateTime)Reader["startDate"], (DateTime)Reader["endDate"], SelectAllServicePackedgesLinkedToContract((int)Reader["contractID"]), (string)Reader["priorityLevel"], Reader.GetDouble(Reader.GetOrdinal("price")), (string)Reader["contractType"]));
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }

            return contractList;
        }

        public List<Contract> SelectAllContractsByIndividualClientId(string id)
        {
            CreateConnection();
            commandString = $"EXEC SelectAllContractsByIndividualClientId @id = '{id}'";
            Command = new SqlCommand(commandString, Connection);
            List<Contract> contractList = new List<Contract>();
            try
            {
                OpenConnection();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    contractList.Add(new Contract((string)Reader["contractNumber"], (DateTime)Reader["startDate"], (DateTime)Reader["endDate"], new IndividualClient((string)Reader["clientIndividualClientNumber"], (string)Reader["firstName"], (string)Reader["surname"], new Address((int)Reader["addressID"], (string)Reader["streetName"], (string)Reader["suburb"], (string)Reader["city"], GetProvince((string)Reader["province"]), (string)Reader["postalcode"]), (string)Reader["contactNumber"], (string)Reader["email"], (string)Reader["nationalIdNumber"], (DateTime)Reader["RegistrationDate"], GetTrueFalseFromBit((int)Reader["active"])), SelectAllServicePackedgesLinkedToContract((int)Reader["contractID"]), GetTrueFalseFromBit((int)Reader["active"]), (string)Reader["priorityLevel"], Reader.GetDouble(Reader.GetOrdinal("price")), (string)Reader["contractType"]));
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }

            return contractList;
        }

        public List<Contract> SelectAllContractsByBusinessClientId(string id)
        {
            CreateConnection();
            commandString = $"EXEC SelectAllContractsByBusinessClientId @id = '{id}'";
            Command = new SqlCommand(commandString, Connection);
            List<Contract> contractList = new List<Contract>();
            try
            {
                OpenConnection();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    contractList.Add(new Contract((string)Reader["contractNumber"], (DateTime)Reader["startDate"], (DateTime)Reader["endDate"], new BusinessClient((string)Reader["clientBusinessClientNumber"], new Address((int)Reader["addressID"], (string)Reader["streetName"], (string)Reader["suburb"], (string)Reader["city"], GetProvince((string)Reader["province"]), (string)Reader["postalcode"]), (string)Reader["contactNumber"], (DateTime)Reader["RegistrationDate"], (string)Reader["taxNumber"], (string)Reader["busuinessName"], GetTrueFalseFromBit((int)Reader["active"])), SelectAllServicePackedgesLinkedToContract((int)Reader["contractID"]), GetTrueFalseFromBit((int)Reader["active"]), (string)Reader["priorityLevel"], Reader.GetDouble(Reader.GetOrdinal("price")), (string)Reader["contractType"]));
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }

            return contractList;
        }

        #endregion

        #region SeperateMethods

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
        private List<ServicePackage> SelectAllServicePackedgesLinkedToContract(int contractid)
        {
            SqlConnection servicePackedgeConnection = new SqlConnection(connectionSring);
            SqlDataReader servicePackedgeReader;
            List<ServicePackage> servicePackedgeList = new List<ServicePackage>();
            commandString = $"EXEC SelectAllServicePackedgesLinkedToContract @id = '{contractid}'";
            SqlCommand servicePackedgeCommand = new SqlCommand(commandString, servicePackedgeConnection);

            try
            {
                servicePackedgeConnection.Open();
                servicePackedgeReader = servicePackedgeCommand.ExecuteReader();
                while (servicePackedgeReader.Read())
                {
                    servicePackedgeList.Add(new ServicePackage((int)servicePackedgeReader["servicePackageID"], (string)servicePackedgeReader["name"], SelectAllServicesLinkedToPackedge((int)servicePackedgeReader["servicePackageID"]), GetTrueFalseFromBit((int)servicePackedgeReader["onPromotion"]), (DateTime)servicePackedgeReader["promotionStartDate"], (DateTime)servicePackedgeReader["promotionEndDate"], servicePackedgeReader.GetDouble(servicePackedgeReader.GetOrdinal("promotionPercentAmount")), servicePackedgeReader.GetDouble(servicePackedgeReader.GetOrdinal("price"))));

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
                servicePackedgeConnection.Close();
            }
            return servicePackedgeList;
        }
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
        #endregion
    }
}
