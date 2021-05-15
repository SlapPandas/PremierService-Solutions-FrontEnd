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
    public class BusinessClientDH : DatabaseConnection, IDataconnection
    {
        AddressDH AddressDH = new AddressDH();
        #region Update
        public void Update(BusinessClient businessClient)
        {
            UpdateCommand($"EXEC UpdateClientBusiness @id = '{businessClient.Id}', @businessName = '{businessClient.BusinessName}', @contact = '{businessClient.ContactNumber}', @taxnumber = '{businessClient.TaxNumber}', @registrationDate = '{businessClient.RegistrationDate.ToString("yyyy-MM-dd HH:mm:ss")}', @active = '{GetIntFromBool(businessClient.Active)}', @adressid = '{businessClient.Address.AddressID}', @streetName = '{businessClient.Address.StreetName}', @suburb = '{businessClient.Address.Suburb}', @province = '{((int)businessClient.Address.Province)}', @postalcode = '{businessClient.Address.Postalcode}',@city = '{businessClient.Address.City}'");
        }
        public void UpdateState(string id, bool active)
        {
            UpdateCommand($"EXEC UpdateBusinessClientState @id = '{id}', @active = '{GetIntFromBool(active)}'");
        }
        #endregion

        #region Insert
        public void Insert(BusinessClient businessClient)
        {
            InsertCommand($"EXEC InsertClientBusiness @busuinessName ='{businessClient.BusinessName}', @contactNumber ='{businessClient.ContactNumber}', @taxNumber ='{businessClient.TaxNumber}', @RegistrationDate ='{businessClient.RegistrationDate.ToString("yyyy-MM-dd")}',@active ='{GetIntFromBool(businessClient.Active)}',@streetname ='{businessClient.Address.StreetName}',@suburb ='{businessClient.Address.Suburb}',@province ='{((int)businessClient.Address.Province).ToString()}',@postalcode ='{businessClient.Address.Postalcode}',@city ='{businessClient.Address.City}'");
        }
        #endregion

        #region Select
        public List<BusinessClient> SelectAllBusinessClients()
        {
            List<BusinessClient> businessClientList = new List<BusinessClient>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAllBusinessClients";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        businessClientList.Add(new BusinessClient((string)reader["clientBusinessClientNumber"], new Address((int)reader["addressID"], (string)reader["streetName"], (string)reader["suburb"], (string)reader["city"], AddressDH.GetProvince((string)reader["province"]), (string)reader["postalcode"]), (string)reader["contactNumber"], (DateTime)reader["RegistrationDate"], (string)reader["taxNumber"], (string)reader["busuinessName"], GetTrueFalseFromBit((int)reader["active"])));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally { }         

            return businessClientList;

        }
        public BusinessClient SelectAllBusinessClientsById(string id)
        {
            BusinessClient businessClient = new BusinessClient();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAllBusinessClientById @id = '{id}'";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        businessClient = new BusinessClient((string)reader["clientBusinessClientNumber"], new Address((int)reader["addressID"], (string)reader["streetName"], (string)reader["suburb"], (string)reader["city"], AddressDH.GetProvince((string)reader["province"]), (string)reader["postalcode"]), (string)reader["contactNumber"], (DateTime)reader["RegistrationDate"], (string)reader["taxNumber"], (string)reader["busuinessName"], GetTrueFalseFromBit((int)reader["active"]));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally { }

            return businessClient;

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
