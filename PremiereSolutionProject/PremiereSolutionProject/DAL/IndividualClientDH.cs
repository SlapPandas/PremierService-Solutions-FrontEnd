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
            CreateConnection();
            commandString = $"EXEC UpdateClientIndividual @id = '{individualClient.Id}', @firstname = '{individualClient.FirstName}', @surname = '{individualClient.Surname}', @contact = '{individualClient.ContactNumber}', @email = '{individualClient.Email}', @nationalid = '{individualClient.NationalIDnumber}', @registrationdate = '{individualClient.RegistrationDate}', @active = '{GetIntFromBool(individualClient.Active)}', @adressid = '{individualClient.Address.AddressID}', @streetName = '{individualClient.Address.StreetName}', @suburb = '{individualClient.Address.Suburb}', @province = '{((int)individualClient.Address.Province).ToString()}', @postalcode = '{individualClient.Address.Postalcode}'";
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
        public void Insert(IndividualClient individualClient)
        {
            CreateConnection();
            commandString = $"EXEC InsertClientIndividual @id = '{individualClient.Id}', @firstName = '{individualClient.FirstName}', @surname = '{individualClient.Surname}', @addressId = '{individualClient.Address.AddressID}', @contactNumber = '{individualClient.ContactNumber}', @email = '{individualClient.Email}', @nationalIdNumber = '{individualClient.NationalIDnumber}', @registrationDate = '{individualClient.RegistrationDate.ToString("yyyy-MM-dd")}'";
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
        public List<IndividualClient> SelectAllIndividualClients()
        {
            CreateConnection();
            commandString = $"EXEC SelectAllIndividualClients";
            Command = new SqlCommand(commandString, Connection);
            List<IndividualClient> IndividualClientList = new List<IndividualClient>();
            try
            {
                OpenConnection();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {

                    IndividualClientList.Add(new IndividualClient((string)Reader["clientIndividualClientNumber"], (string)Reader["firstName"], (string)Reader["surname"], new Address((int)Reader["addressID"], (string)Reader["streetName"], (string)Reader["suburb"], GetProvince((string)Reader["province"]), (string)Reader["postalcode"]), (string)Reader["contactNumber"], (string)Reader["email"], (string)Reader["nationalIdNumber"], (DateTime)Reader["RegistrationDate"], GetTrueFalseFromBit((int)Reader["active"])));
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }

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
