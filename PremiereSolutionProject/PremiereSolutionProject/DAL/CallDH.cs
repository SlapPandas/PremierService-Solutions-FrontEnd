using PremiereSolutionProject.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiereSolutionProject.DAL
{
    public class CallDH : DatabaseConnection
    {
        //Done
        #region Update
        public void UpdateNotes(int id, string notes)
        {
            UpdateCommand($"EXEC UpdateCallNotes @id ='{id}', @callnotes ='{notes}'");
        }

        #endregion

        //Done
        #region Insert
        public void InsertEndTime(int id, DateTime dateTime)
        {
            InsertCommand($"EXEC UpdateEndTime @id ='{id}', @endTime ='{dateTime}'");
          
        }
        public void InsertIndividualClientToCall(int Callid, string ClientId)
        {
            InsertCommand($"EXEC UpdateCallClientIndividual @id ='{Callid}', @ClientIndividual ='{ClientId}'");

        }
        public void InsertBusinessClientToCall(int Callid, string ClientId)
        {
            InsertCommand($"EXEC UpdateCallClientBusiness @id ='{Callid}', @ClientBusiness ='{ClientId}'");
        }
        public int Insert(DateTime dateTime, string empId)
        {
            return InsertCommandWithReturnedId($"EXEC InsertCall @startTime ='{dateTime}', @employeeID = '{empId}'");
        }

        #endregion

        //Not sure if TODO was solved?
        #region Select
        public List<Call> SelectAllCallByIndividualClientById(string id)
        {
            List<Call> callList = new List<Call>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAllCallsByIndividualClientId @id = '{id}'";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        CallCenterEmployee callcenterEnptyEmployee = new CallCenterEmployee();
                        //TODO: call center employee is currently emply as geting there information is not working, fields like there number "C00000001" is not populating, dont know why.
                        callList.Add(new Call((int)reader["callID"], (DateTime)reader["startTime"], (DateTime)reader["endTime"], new IndividualClient((string)reader["clientIndividualClientNumber"], (string)reader["firstName"], (string)reader["surname"], new Address((int)reader["addressID"], (string)reader["streetName"], (string)reader["suburb"], (string)reader["city"], GetProvince((string)reader["province"]), (string)reader["postalcode"]), (string)reader["contactNumber"], (string)reader["email"], (string)reader["nationalIdNumber"], (DateTime)reader["RegistrationDate"], GetTrueFalseFromBit((int)reader["active"])), GetCallCenterEmployeeByCallId((int)reader["callID"]), (string)reader["callNotes"]));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally { }       

            return callList;
        }
        public List<Call> SelectAllCallByBusinessClientById(string id)
        {
            List<Call> callList = new List<Call>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAllCallsByBusinessClientId @id = '{id}'";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        CallCenterEmployee callcenterEnptyEmployee = new CallCenterEmployee();
                        //TODO: call center employee is currently emply as geting there information is not working, fields like there number "C00000001" is not populating, dont know why.
                        callList.Add(new Call((int)reader["callID"], (DateTime)reader["startTime"], (DateTime)reader["endTime"], new BusinessClient((string)reader["clientBusinessClientNumber"], new Address((int)reader["addressID"], (string)reader["streetName"], (string)reader["suburb"], (string)reader["city"], GetProvince((string)reader["province"]), (string)reader["postalcode"]), (string)reader["contactNumber"], (DateTime)reader["RegistrationDate"], (string)reader["taxNumber"], (string)reader["busuinessName"], GetTrueFalseFromBit((int)reader["active"])), callcenterEnptyEmployee, (string)reader["callNotes"]));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally { }          

            return callList;
        }
        public Call SelectCallByJobId(int id)
        {
            Call call = new Call();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectCallByJobId @id = '{id}'";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        CallCenterEmployee callcenterEnptyEmployee = new CallCenterEmployee();
                        //TODO: call center employee is currently emply as geting there information is not working, fields like there number "C00000001" is not populating, dont know why.
                        call = new Call((int)reader["callID"], (DateTime)reader["startTime"], (DateTime)reader["endTime"], callcenterEnptyEmployee, (string)reader["callNotes"]);
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally { }           

            return call;
        }
        public Call SelectCallByIdIndividualClient(int id)
        {
            Call call = new Call();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectCallbyIdClientIndividual @id = '{id}'";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        CallCenterEmployee callcenterEnptyEmployee = new CallCenterEmployee();
                        //TODO: call center employee is currently emply as geting there information is not working, fields like there number "C00000001" is not populating, dont know why.
                        call = new Call((int)reader["callID"], (DateTime)reader["startTime"], (DateTime)reader["endTime"], new IndividualClient((string)reader["clientIndividualClientNumber"], (string)reader["firstName"], (string)reader["surname"], new Address((int)reader["addressID"], (string)reader["streetName"], (string)reader["suburb"], (string)reader["city"], GetProvince((string)reader["province"]), (string)reader["postalcode"]), (string)reader["contactNumber"], (string)reader["email"], (string)reader["nationalIdNumber"], (DateTime)reader["RegistrationDate"], GetTrueFalseFromBit((int)reader["active"])), callcenterEnptyEmployee, (string)reader["callNotes"]);
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally { }

            return call;
        }
        public Call SelectCallByIdBusinessClient(int id)
        {
            Call call = new Call();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectCallbyIdClientBusiness @id = '{id}'";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        CallCenterEmployee callcenterEnptyEmployee = new CallCenterEmployee();
                        //TODO: call center employee is currently emply as geting there information is not working, fields like there number "C00000001" is not populating, dont know why.
                        call = new Call((int)reader["callID"], (DateTime)reader["startTime"], (DateTime)reader["endTime"], new BusinessClient((string)reader["clientBusinessClientNumber"], new Address((int)reader["addressID"], (string)reader["streetName"], (string)reader["suburb"], (string)reader["city"], GetProvince((string)reader["province"]), (string)reader["postalcode"]), (string)reader["contactNumber"], (DateTime)reader["RegistrationDate"], (string)reader["taxNumber"], (string)reader["busuinessName"], GetTrueFalseFromBit((int)reader["active"])), callcenterEnptyEmployee, (string)reader["callNotes"]);
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally { }

            return call;
        }
        #endregion

        //Not 100% sure
        #region SeperateMethods
        private bool GetTrueFalseFromBit(int bit)
        {
            bool output = bit == 1 ? true : false;
            return output;
        }
        public CallCenterEmployee GetCallCenterEmployeeByCallId(int callId)
        {
            CallCenterEmployee callCenterEmployee = new CallCenterEmployee();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectCallCenterEmployeeByCallId @id = '{callId}'";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        CallCenterEmployee callcenterEnptyEmployee = new CallCenterEmployee();
                        //TODO: call center employee is currently emply as geting there information is not working, fields like there number "C00000001" is not populating, dont know why.
                        callCenterEmployee = new CallCenterEmployee((string)reader["employeeNumber"], (string)reader["firstName"], (string)reader["surname"], new Address((int)reader["addressId"], (string)reader["streetName"], (string)reader["suburb"], (string)reader["city"], GetProvince((string)reader["province"]), (string)reader["postalcode"]), (string)reader["contactNumber"], (string)reader["email"], (string)reader["nationalIdNumber"], (DateTime)reader["employmentDate"], GetTrueFalseFromBit((int)reader["employed"]), (string)reader["department"]);

                    }
                }                
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally
            {

            }
            return callCenterEmployee;
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
