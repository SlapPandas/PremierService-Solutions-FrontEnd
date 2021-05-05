using PremiereSolutionProject.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiereSolutionProject.DAL
{
    class IndividualClientDH : DatabaseConnection
    {
        #region Update
        public void Update(IndividualClient individualClient)
        {
            UpdateCommand($"EXEC UpdateClientIndividual @id = '{individualClient.Id}', @firstname = '{individualClient.FirstName}', @surname = '{individualClient.Surname}', @contact = '{individualClient.ContactNumber}', @email = '{individualClient.Email}', @nationalid = '{individualClient.NationalIDnumber}', @registrationdate = '{individualClient.RegistrationDate}', @active = '{GetIntFromBool(individualClient.Active)}', @adressid = '{individualClient.Address.AddressID}', @streetName = '{individualClient.Address.StreetName}', @suburb = '{individualClient.Address.Suburb}', @province = '{((int)individualClient.Address.Province).ToString()}', @postalcode = '{individualClient.Address.Postalcode}',@city = '{individualClient.Address.City}'");
        }
        public void ChangeClientState(string clientId,bool active)
        {
            UpdateCommand($"EXEC UpdateClientIndividualCurrentState @id ='{clientId}', @active ='{GetIntFromBool(active)}'");
        }
        #endregion

        #region Insert
        public void Insert(IndividualClient individualClient)
        {
            InsertCommand($"EXEC InsertClientIndividual @firstName = '{individualClient.FirstName}', @surname = '{individualClient.Surname}', @contactNumber = '{individualClient.ContactNumber}', @email = '{individualClient.Email}', @nationalIdNumber = '{individualClient.NationalIDnumber}', @registrationDate = '{individualClient.RegistrationDate.ToString("yyyy-MM-dd")}', @active = '{GetIntFromBool(individualClient.Active)}',@streetname = '{individualClient.Address.StreetName}',@suburb = '{individualClient.Address.Suburb}',@province = '{((int)individualClient.Address.Province).ToString()}',@postalcode= '{individualClient.Address.Postalcode}', @city = '{individualClient.Address.City}'");
        }
        #endregion

        #region Select
        public List<IndividualClient> SelectAllIndividualClients()
        {
            List<IndividualClient> IndividualClientList = new List<IndividualClient>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAllIndividualClients";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        IndividualClientList.Add(new IndividualClient((string)reader["clientIndividualClientNumber"], (string)reader["firstName"], (string)reader["surname"], new Address((int)reader["addressID"], (string)reader["streetName"], (string)reader["suburb"], (string)reader["city"], GetProvince((string)reader["province"]), (string)reader["postalcode"]), (string)reader["contactNumber"], (string)reader["email"], (string)reader["nationalIdNumber"], (DateTime)reader["RegistrationDate"], GetTrueFalseFromBit((int)reader["active"])));
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

            return IndividualClientList;
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
