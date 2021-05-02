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
    class BusinessClientDH : DatabaseConnection, IDataconnection
    {
        #region Update
        public void Update(BusinessClient businessClient)
        {
            CreateConnection();
            commandString = $"EXEC UpdateClientBusiness @id = '{businessClient.Id}', @businessName = '{businessClient.BusinessName}', @contact = '{businessClient.ContactNumber}', @taxnumber = '{businessClient.TaxNumber}', @registrationdate = '{businessClient.RegistrationDate}', @active = '{GetIntFromBool(businessClient.Active)}', @addressid = '{businessClient.Address.AddressID}', @streetName = '{businessClient.Address.StreetName}', @province '{((int)businessClient.Address.Province).ToString()}', @postalcode = '{businessClient.Address.Postalcode}', @city = '{businessClient.Address.City}'";                                                      
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
        public void Insert(BusinessClient businessClient)
        {
            CreateConnection();
            commandString = $"EXEC UpdateBusinessClient @id = '{businessClient.Id}', @address = '{businessClient.Address.AddressID}', @contactnr = '{businessClient.ContactNumber}', @RegistrationDate = '{businessClient.RegistrationDate.ToString("yyyy-MM-dd")}', @taxNumber = '{businessClient.TaxNumber}', @businessName = '{businessClient.BusinessName}'";
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
        public List<BusinessClient> SelectAllBusinessClients()
        {
            CreateConnection();
            commandString = $"EXEC SelectAllBusinessClients";
            Command = new SqlCommand(commandString, Connection);
            List<BusinessClient> businessClientList = new List<BusinessClient>();
            try
            {
                OpenConnection();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    businessClientList.Add(new BusinessClient((string)Reader["clientBusinessClientNumber"], new Address((int)Reader["addressID"], (string)Reader["streetName"], (string)Reader["suburb"], (string)Reader["city"], GetProvince((string)Reader["province"]), (string)Reader["postalcode"]), (string)Reader["contactNumber"], (DateTime)Reader["RegistrationDate"], (string)Reader["taxNumber"], (string)Reader["busuinessName"], GetTrueFalseFromBit((int)Reader["active"])));
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }

            return businessClientList;

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
