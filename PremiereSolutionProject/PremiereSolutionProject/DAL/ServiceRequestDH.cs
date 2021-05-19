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
    public class ServiceRequestDH : DatabaseConnection, IDataconnection
    {
        SpecializationDH SpecializationDH = new SpecializationDH();
        #region Delete
        public void Delete(ServiceRequest serviceRequest)
        {
            DeleteCommand($"EXEC DeleteServiceRequest @id = '{serviceRequest.ServiceRequestID}'");
        }
        #endregion

        #region Update
        public void Update(ServiceRequest serviceRequest)
        {
            UpdateCommand($"EXEC UpdateServiceRequest @id = '{serviceRequest.ServiceRequestID}', @description = '{serviceRequest.Description}', @priorityLevel = '{serviceRequest.PriorityLevel}'");
        }
        public void UpdateState(ServiceRequest serviceRequest)
        {
            UpdateCommand($"EXEC UpdateServiceRequestCurrentState @id = '{serviceRequest.ServiceRequestID}', @closed = '{GetIntFromBool(serviceRequest.Closed)}'");
        }
        public void UpdateSpecializationList(ServiceRequest serviceRequest)
        {
            SpecializationDH.InsertAllSpeciliozationOfServiceRequest(serviceRequest);
            UpdateCommand($"EXEC UpdateServiceRequestSpecializationList @id = '{serviceRequest.ServiceRequestID}'");
        }
        #endregion

        #region Insert
        public void Insert(ServiceRequest serviceRequest)
        {
            InsertCommand($"EXEC InsertServiceRequest @callId ='{serviceRequest.CallID}', @closed ='{GetIntFromBool(serviceRequest.Closed)}', @description ='{serviceRequest.Description}',@priorityLevel ='{serviceRequest.PriorityLevel}'");
        }
        public void InsertWithSpecilizationList(ServiceRequest serviceRequest)
        {
            SpecializationDH.InsertAllSpeciliozationOfNewServiceRequest(serviceRequest);
            InsertCommand($"EXEC InsertServiceRequestWithSpecializationList @callId ='{serviceRequest.CallID}', @closed ='{GetIntFromBool(serviceRequest.Closed)}', @description ='{serviceRequest.Description}',@priorityLevel ='{serviceRequest.PriorityLevel}'");
        }
        public int InsertWithSpecilizationListWithReturnedId(ServiceRequest serviceRequest)
        {
            SpecializationDH.InsertAllSpeciliozationOfNewServiceRequest(serviceRequest);
            return InsertCommandWithReturnedId($"EXEC InsertServiceRequestWithSpecializationListWithReturnedId @callId ='{serviceRequest.CallID}', @closed ='{GetIntFromBool(serviceRequest.Closed)}', @description ='{serviceRequest.Description}',@priorityLevel ='{serviceRequest.PriorityLevel}'");
        }
        #endregion

        #region Select
        public List<ServiceRequest> SelectAllServiceRequests()
        {
            List<ServiceRequest> ServiceRequestList = new List<ServiceRequest>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAllServiceRequests";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ServiceRequestList.Add(new ServiceRequest((int)reader["serviceRequestID"], GetTrueFalseFromBit((int)reader["closed"]), (string)reader["description"], (int)reader["callID"], SpecializationDH.GetSpecialisationByIdForServiceRequest((int)reader["serviceRequestID"]), (string)reader["priorityLevel"]));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally {}

            return ServiceRequestList;
        }
        public List<ServiceRequest> SelectAllServiceRequestsByBusinessClient(string id)
        {
            List<ServiceRequest> ServiceRequestList = new List<ServiceRequest>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAllServiceRequestsByBusinessClient @id = '{id}'";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                    ServiceRequestList.Add(new ServiceRequest((int)reader["serviceRequestID"], GetTrueFalseFromBit((int)reader["closed"]), (string)reader["description"], (int)reader["callID"], SpecializationDH.GetSpecialisationByIdForServiceRequest((int)reader["serviceRequestID"]), (string)reader["priorityLevel"]));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally {}


            return ServiceRequestList;
        }
        public List<ServiceRequest> SelectAllServiceRequestsByIndividualClient(string id)
        {
            List<ServiceRequest> ServiceRequestList = new List<ServiceRequest>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAllServiceRequestsByIndividualClient @id= '{id}'";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        ServiceRequestList.Add(new ServiceRequest((int)reader["serviceRequestID"], GetTrueFalseFromBit((int)reader["closed"]), (string)reader["description"], (int)reader["callID"], SpecializationDH.GetSpecialisationByIdForServiceRequest((int)reader["serviceRequestID"]), (string)reader["priorityLevel"]));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally {}

            return ServiceRequestList;
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
