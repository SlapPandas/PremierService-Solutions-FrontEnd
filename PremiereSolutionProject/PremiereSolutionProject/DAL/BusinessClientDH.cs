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
        //Done
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

        //Done
        #region Insert
        public void Insert(BusinessClient businessClient)
        {
            InsertCommand($"EXEC InsertClientBusiness @busuinessName ='{businessClient.BusinessName}', @contactNumber ='{businessClient.ContactNumber}', @taxNumber ='{businessClient.TaxNumber}', @RegistrationDate ='{businessClient.RegistrationDate.ToString("yyyy-MM-dd")}',@active ='{GetIntFromBool(businessClient.Active)}',@streetname ='{businessClient.Address.StreetName}',@suburb ='{businessClient.Address.Suburb}',@province ='{((int)businessClient.Address.Province).ToString()}',@postalcode ='{businessClient.Address.Postalcode}',@city ='{businessClient.Address.City}'");
        }
        #endregion

        //Done
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
                        businessClientList.Add(new BusinessClient((string)reader["clientBusinessClientNumber"], new Address((int)reader["addressID"], (string)reader["streetName"], (string)reader["suburb"], (string)reader["city"], GetProvince((string)reader["province"]), (string)reader["postalcode"]), (string)reader["contactNumber"], (DateTime)reader["RegistrationDate"], (string)reader["taxNumber"], (string)reader["busuinessName"], GetTrueFalseFromBit((int)reader["active"])));
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
                        businessClient = new BusinessClient((string)reader["clientBusinessClientNumber"], new Address((int)reader["addressID"], (string)reader["streetName"], (string)reader["suburb"], (string)reader["city"], GetProvince((string)reader["province"]), (string)reader["postalcode"]), (string)reader["contactNumber"], (DateTime)reader["RegistrationDate"], (string)reader["taxNumber"], (string)reader["busuinessName"], GetTrueFalseFromBit((int)reader["active"]));
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
