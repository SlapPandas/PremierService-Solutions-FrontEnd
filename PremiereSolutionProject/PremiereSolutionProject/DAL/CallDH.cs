using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiereSolutionProject.DAL
{
    class CallDH : DatabaseConnection
    {
        #region Update
        public void Update(Call call)
        {
            CreateConnection();
            commandString = $"EXEC UpdateCall @id = '{call.CallID}', @start = '{call.StartTime.ToString("yyyy-MM-dd HH:mm:ss")}', @end = '{call.EndTime.ToString("yyyy-MM-dd HH:mm:ss")}', @client = '{call.Client}', @callCenterEmployee = '{call.Employee}', @notes = '{call.CallNotes}'";
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
        public void Insert(Call call)
        {
            CreateConnection();
            commandString = $"EXEC InsertCall @id = '{call.CallID}', @start = '{call.StartTime.ToString("yyyy-MM-dd HH:mm:ss")}', @end = '{call.EndTime.ToString("yyyy-MM-dd HH:mm:ss")}', @client = '{call.Client}', @callCenterEmployee = '{call.Employee}', @notes = '{call.CallNotes}'";
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
        public List<Call> SelectAllCallByIndividualClientById(string id)
        {
            CreateConnection();
            commandString = $"EXEC SelectAllCallsByIndividualClientId @id = '{id}'";
            Command = new SqlCommand(commandString, Connection);
            List<Call> callList = new List<Call>();
            try
            {
                OpenConnection();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    CallCenterEmployee callcenterEnptyEmployee = new CallCenterEmployee();
                    //TODO
                    //call center employee is currently empty as getting the information is not working,
                    //fields like the number "C00000001" is not populating, dont know why.
                    callList.Add(new Call((int)Reader["callID"], (DateTime)Reader["startTime"], (DateTime)Reader["endTime"], new IndividualClient((string)Reader["clientIndividualClientNumber"], (string)Reader["firstName"], (string)Reader["surname"], new Address((int)Reader["addressID"], (string)Reader["streetName"], (string)Reader["suburb"], GetProvince((string)Reader["province"]), (string)Reader["postalcode"]), (string)Reader["contactNumber"], (string)Reader["email"], (string)Reader["nationalIdNumber"], (DateTime)Reader["RegistrationDate"], GetTrueFalseFromBit((int)Reader["active"])), callcenterEnptyEmployee, (string)Reader["callNotes"]));
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }

            return callList;
        }
        public List<Call> SelectAllCallByBusinessClientById(string id)
        {
            CreateConnection();
            commandString = $"EXEC SelectAllCallsByBusinessClientId @id = '{id}'";
            Command = new SqlCommand(commandString, Connection);
            List<Call> callList = new List<Call>();
            try
            {
                OpenConnection();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    CallCenterEmployee callcenterEnptyEmployee = new CallCenterEmployee();
                    //TODO
                    //call center employee is currently emply as geting there information is not working,
                    //fields like there number "C00000001" is not populating, dont know why.
                    callList.Add(new Call((int)Reader["callID"], (DateTime)Reader["startTime"], (DateTime)Reader["endTime"], new BusinessClient((string)Reader["clientBusinessClientNumber"], new Address((int)Reader["addressID"], (string)Reader["streetName"], (string)Reader["suburb"], GetProvince((string)Reader["province"]), (string)Reader["postalcode"]), (string)Reader["contactNumber"], (DateTime)Reader["RegistrationDate"], (string)Reader["taxNumber"], (string)Reader["busuinessName"], GetTrueFalseFromBit((int)Reader["active"])), callcenterEnptyEmployee, (string)Reader["callNotes"]));
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }

            return callList;
        }
        public Call SelectCallByJobId(int id)
        {
            CreateConnection();
            commandString = $"EXEC SelectCallByJobId @id = '{id}'";
            Command = new SqlCommand(commandString, Connection);
            Call call = new Call();
            try
            {
                OpenConnection();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    CallCenterEmployee callcenterEnptyEmployee = new CallCenterEmployee();
                    //TODO
                    //call center employee is currently emply as geting there information is not working,
                    //fields like there number "C00000001" is not populating, dont know why.
                    call = new Call((int)Reader["callID"], (DateTime)Reader["startTime"], (DateTime)Reader["endTime"], callcenterEnptyEmployee, (string)Reader["callNotes"]);
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }

            return call;
        }
        #endregion

        #region SeperateMethods
        private bool GetTrueFalseFromBit(int bit)
        {
            bool output = bit == 1 ? true : false;
            return output;
        }
        private CallCenterEmployee GetCallCenterEmployeeByCallId(int callId)
        {
            SqlConnection callCenterEmployeeConnection = new SqlConnection(connectionSring);
            SqlDataReader callCenterEmployeeReader;
            CallCenterEmployee callCenterEmployee = new CallCenterEmployee();
            commandString = $"EXEC SelectCallCenterEmployeeByCallId @id = '{callId}'";
            SqlCommand maintenanceEmployeeCommand = new SqlCommand(commandString, callCenterEmployeeConnection);

            try
            {
                callCenterEmployeeConnection.Open();
                callCenterEmployeeReader = maintenanceEmployeeCommand.ExecuteReader();
                while (callCenterEmployeeReader.Read())
                {
                    int emptid = (int)Reader["employeeID"];
                    string empid = (string)Reader["employeeNumber"];
                    string fname = (string)Reader["firstName"];
                    string sname = (string)Reader["surname"];
                    Address address = new Address((int)Reader["addressID"], (string)Reader["streetName"], (string)Reader["suburb"], GetProvince((string)Reader["province"]), (string)Reader["postalcode"]);
                    string contactnr = (string)Reader["contactNumber"];
                    string email = (string)Reader["email"];
                    string natID = (string)Reader["nationalIdNumber"];
                    DateTime date = (DateTime)Reader["employmentDate"];
                    bool employed = GetTrueFalseFromBit((int)Reader["employed"]);
                    string department = (string)Reader["department"];
                    callCenterEmployee = new CallCenterEmployee((string)Reader["employeeNumber"], (string)Reader["firstName"], (string)Reader["surname"], new Address((int)Reader["addressID"], (string)Reader["streetName"], (string)Reader["suburb"], GetProvince((string)Reader["province"]), (string)Reader["postalcode"]), (string)Reader["contactNumber"], (string)Reader["email"], (string)Reader["nationalIdNumber"], (DateTime)Reader["employmentDate"], GetTrueFalseFromBit((int)Reader["employed"]), (string)Reader["department"]);

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
                callCenterEmployeeConnection.Close();
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
