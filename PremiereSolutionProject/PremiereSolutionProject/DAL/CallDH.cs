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
        EmployeeDH employeeDH = new EmployeeDH();
        AddressDH addressDH = new AddressDH();
        #region Update
        public void UpdateNotes(int id, string notes)
        {
            UpdateCommand($"EXEC UpdateCallNotes @id ='{id}', @callnotes ='{notes}'");
        }

        #endregion

        #region Insert
        public void InsertEndTime(int id, DateTime dateTime)
        {
            InsertCommand($"EXEC UpdateEndTime @id ='{id}', @endTime ='{dateTime.ToString("yyyy-MM-dd hh:mm:ss")}'");
          
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
            return InsertCommandWithReturnedId($"EXEC InsertCall @startTime ='{dateTime.ToString("yyyy-MM-dd hh:mm:ss")}', @employeeID = '{empId}'");
        }

        #endregion

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
                        callList.Add(new Call((int)reader["callID"], (DateTime)reader["startTime"], reader.IsDBNull(reader.GetOrdinal("endTime")) ? new DateTime(1111, 11, 11) : Convert.ToDateTime(reader["endTime"]), new IndividualClient((string)reader["clientIndividualClientNumber"], (string)reader["firstName"], (string)reader["surname"], new Address((int)reader["addressID"], (string)reader["streetName"], (string)reader["suburb"], (string)reader["city"], addressDH.GetProvince((string)reader["province"]), (string)reader["postalcode"]), (string)reader["contactNumber"], (string)reader["email"], (string)reader["nationalIdNumber"], (DateTime)reader["RegistrationDate"], GetTrueFalseFromBit((int)reader["active"])), employeeDH.GetCallCenterEmployeeByCallId((int)reader["callID"]), (string)reader["callNotes"]));
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
                        callList.Add(new Call((int)reader["callID"], (DateTime)reader["startTime"], reader.IsDBNull(reader.GetOrdinal("endTime")) ? new DateTime(1111, 11, 11) : Convert.ToDateTime(reader["endTime"]), new BusinessClient((string)reader["clientBusinessClientNumber"], new Address((int)reader["addressID"], (string)reader["streetName"], (string)reader["suburb"], (string)reader["city"], addressDH.GetProvince((string)reader["province"]), (string)reader["postalcode"]), (string)reader["contactNumber"], (DateTime)reader["RegistrationDate"], (string)reader["taxNumber"], (string)reader["busuinessName"], GetTrueFalseFromBit((int)reader["active"])), callcenterEnptyEmployee, (string)reader["callNotes"]));
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
                        call = new Call((int)reader["callID"], (DateTime)reader["startTime"], reader.IsDBNull(reader.GetOrdinal("endTime")) ? new DateTime(1111, 11, 11) : Convert.ToDateTime(reader["endTime"]), callcenterEnptyEmployee, (string)reader["callNotes"]);
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
                        call = new Call((int)reader["callID"], (DateTime)reader["startTime"], reader.IsDBNull(reader.GetOrdinal("endTime")) ? new DateTime(1111, 11, 11) : Convert.ToDateTime(reader["endTime"]), new IndividualClient((string)reader["clientIndividualClientNumber"], (string)reader["firstName"], (string)reader["surname"], new Address((int)reader["addressID"], (string)reader["streetName"], (string)reader["suburb"], (string)reader["city"], addressDH.GetProvince((string)reader["province"]), (string)reader["postalcode"]), (string)reader["contactNumber"], (string)reader["email"], (string)reader["nationalIdNumber"], (DateTime)reader["RegistrationDate"], GetTrueFalseFromBit((int)reader["active"])), callcenterEnptyEmployee, (string)reader["callNotes"]);
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
                        call = new Call((int)reader["callID"], (DateTime)reader["startTime"], reader.IsDBNull(reader.GetOrdinal("endTime")) ? new DateTime(1111, 11, 11) : Convert.ToDateTime(reader["endTime"]), new BusinessClient((string)reader["clientBusinessClientNumber"], new Address((int)reader["addressID"], (string)reader["streetName"], (string)reader["suburb"], (string)reader["city"], addressDH.GetProvince((string)reader["province"]), (string)reader["postalcode"]), (string)reader["contactNumber"], (DateTime)reader["RegistrationDate"], (string)reader["taxNumber"], (string)reader["busuinessName"], GetTrueFalseFromBit((int)reader["active"])), callcenterEnptyEmployee, (string)reader["callNotes"]);
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
        public Call SelectCallById(int id)
        {
            Call call = new Call();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectCallbyId @id = '{id}'";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Call checkClientOfCall = new Call((int)reader["callID"], reader.IsDBNull(reader.GetOrdinal("ClientIndividualID")) ? -1 : Convert.ToInt32(reader["ClientIndividualID"]), reader.IsDBNull(reader.GetOrdinal("ClientBusinessID")) ? -1 : Convert.ToInt32(reader["ClientBusinessID"]));
                        if (checkClientOfCall.IndclientID == -1)
                        {
                            call = SelectCallByIdBusinessClient((int)checkClientOfCall.CallID);
                        }
                        if (checkClientOfCall.BusclientID == -1)
                        {
                            call = SelectCallByIdIndividualClient((int)checkClientOfCall.CallID);
                        }
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

        #region SeperateMethods
        private bool GetTrueFalseFromBit(int bit)
        {
            bool output = bit == 1 ? true : false;
            return output;
        }    
        #endregion
    }
}
