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
    public class AddressDH : DatabaseConnection, IDataconnection
    {
        //Done
        #region Update
        public void Update(Address address)
        {      
            UpdateCommand($"EXEC UpdateAddress @id ='{address.AddressID}', @streetName ='{address.StreetName}', @suburb ='{address.Suburb}', @province ='{((int)address.Province).ToString()}', @postalcode ='{address.Postalcode}',@city ='{address.City}'");
        }
        #endregion

        //Done
        #region Insert
        public void Insert(Address address)
        {
            InsertCommand($"EXEC InsertAddress @streetname ='{address.StreetName}',@suburb ='{address.Suburb}',@province ='{((int)address.Province).ToString()}',@postalcode ='{address.Postalcode}', @city ='{address.City}'");
        }

        #endregion


        #region Select
        public List<Address> SelectAllAddresses()
        {
            List<Address> addressList = new List<Address>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAllAddresses";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        addressList.Add(new Address((int)reader["addressID"], (string)reader["streetName"], (string)reader["suburb"], (string)reader["city"], GetProvince((string)reader["province"]), (string)reader["postalcode"]));
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

            return addressList;
        }
        #endregion

        //Done
        #region Delete
        public bool Delete(Address address)
        {
            if (GetNumberOfAddessUses(address.AddressID) > 0)
            {
                return false;
            }
            else
            {
                DeleteCommand($"EXEC DeleteAddress @id = '{address.AddressID}'");
                return true;
            }
        }
        #endregion


        #region SeperateMethods
        private int GetNumberOfAddessUses(int addressId)
        {

            SqlConnection addressConnection = new SqlConnection(connectionSring);
            SqlDataReader addressReader;
            int output = -1;
            commandString = $"EXEC AddressUses @id = '{addressId}'";
            SqlCommand addressCommand = new SqlCommand(commandString, addressConnection);

            try
            {
                addressConnection.Open();
                addressReader = addressCommand.ExecuteReader();
                while (addressReader.Read())
                {
                    output = (int)addressReader["uses"];
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
                addressConnection.Close();
            }
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
