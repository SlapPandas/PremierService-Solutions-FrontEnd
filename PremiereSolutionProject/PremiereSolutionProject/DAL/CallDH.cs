﻿using PremiereSolutionProject.BLL;
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

        //Done, but question with Insert method
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
                        callList.Add(new Call((int)Reader["callID"], (DateTime)Reader["startTime"], (DateTime)Reader["endTime"], new IndividualClient((string)Reader["clientIndividualClientNumber"], (string)Reader["firstName"], (string)Reader["surname"], new Address((int)Reader["addressID"], (string)Reader["streetName"], (string)Reader["suburb"], (string)Reader["city"], GetProvince((string)Reader["province"]), (string)Reader["postalcode"]), (string)Reader["contactNumber"], (string)Reader["email"], (string)Reader["nationalIdNumber"], (DateTime)Reader["RegistrationDate"], GetTrueFalseFromBit((int)Reader["active"])), callcenterEnptyEmployee, (string)Reader["callNotes"]));
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
                        callList.Add(new Call((int)Reader["callID"], (DateTime)Reader["startTime"], (DateTime)Reader["endTime"], new BusinessClient((string)Reader["clientBusinessClientNumber"], new Address((int)Reader["addressID"], (string)Reader["streetName"], (string)Reader["suburb"], (string)Reader["city"], GetProvince((string)Reader["province"]), (string)Reader["postalcode"]), (string)Reader["contactNumber"], (DateTime)Reader["RegistrationDate"], (string)Reader["taxNumber"], (string)Reader["busuinessName"], GetTrueFalseFromBit((int)Reader["active"])), callcenterEnptyEmployee, (string)Reader["callNotes"]));
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
                        call = new Call((int)Reader["callID"], (DateTime)Reader["startTime"], (DateTime)Reader["endTime"], callcenterEnptyEmployee, (string)Reader["callNotes"]);
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
                    Address address = new Address((int)Reader["addressID"], (string)Reader["streetName"], (string)Reader["suburb"], (string)Reader["city"], GetProvince((string)Reader["province"]), (string)Reader["postalcode"]);
                    string contactnr = (string)Reader["contactNumber"];
                    string email = (string)Reader["email"];
                    string natID = (string)Reader["nationalIdNumber"];
                    DateTime date = (DateTime)Reader["employmentDate"];
                    bool employed = GetTrueFalseFromBit((int)Reader["employed"]);
                    string department = (string)Reader["department"];
                    callCenterEmployee = new CallCenterEmployee((string)Reader["employeeNumber"], (string)Reader["firstName"], (string)Reader["surname"], new Address((int)Reader["addressID"], (string)Reader["streetName"], (string)Reader["suburb"], (string)Reader["city"], GetProvince((string)Reader["province"]), (string)Reader["postalcode"]), (string)Reader["contactNumber"], (string)Reader["email"], (string)Reader["nationalIdNumber"], (DateTime)Reader["employmentDate"], GetTrueFalseFromBit((int)Reader["employed"]), (string)Reader["department"]);

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
