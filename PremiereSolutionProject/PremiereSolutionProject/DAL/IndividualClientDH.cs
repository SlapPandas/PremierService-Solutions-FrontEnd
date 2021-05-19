using PremiereSolutionProject.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiereSolutionProject.DAL
{
    public class IndividualClientDH : DatabaseConnection
    {
        AddressDH addressDH = new AddressDH();
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
                        IndividualClientList.Add(new IndividualClient((string)reader["clientIndividualClientNumber"], (string)reader["firstName"], (string)reader["surname"], new Address((int)reader["addressID"], (string)reader["streetName"], (string)reader["suburb"], (string)reader["city"], addressDH.GetProvince((string)reader["province"]), (string)reader["postalcode"]), (string)reader["contactNumber"], (string)reader["email"], (string)reader["nationalIdNumber"], (DateTime)reader["RegistrationDate"], GetTrueFalseFromBit((int)reader["active"])));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally {}

            return IndividualClientList;
        }
        public IndividualClient SelectAllIndividualClientByID(string id)
        {
            IndividualClient IndividualClient = new IndividualClient();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAllIndividualClientById @id = '{id}'";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        IndividualClient = new IndividualClient((string)reader["clientIndividualClientNumber"], (string)reader["firstName"], (string)reader["surname"], new Address((int)reader["addressID"], (string)reader["streetName"], (string)reader["suburb"], (string)reader["city"], addressDH.GetProvince((string)reader["province"]), (string)reader["postalcode"]), (string)reader["contactNumber"], (string)reader["email"], (string)reader["nationalIdNumber"], (DateTime)reader["RegistrationDate"], GetTrueFalseFromBit((int)reader["active"]));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally { }

            return IndividualClient;
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
