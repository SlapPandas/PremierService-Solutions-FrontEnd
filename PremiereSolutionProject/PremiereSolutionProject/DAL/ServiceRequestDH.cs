using PremiereSolutionProject.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiereSolutionProject.DAL
{
    class ServiceRequestDH : DatabaseConnection, IDataconnection
    {
        #region Delete
        public void Delete(ServiceRequest serviceRequest)
        {
            CreateConnection();
            commandString = $"EXEC DeleteServiceRequest @id = '{serviceRequest.ServiceRequestID}'";
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

        #region Update
        public void Update(ServiceRequest serviceRequest)
        {
            CreateConnection();
            commandString = $"EXEC UpdateServiceRequest @id = '{serviceRequest.ServiceRequestID}', @description = '{serviceRequest.Description}', @priorityLevel = '{serviceRequest.PriorityLevel}'";
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
        public void UpdateState(ServiceRequest serviceRequest)
        {
            CreateConnection();
            commandString = $"EXEC UpdateServiceRequestCurrentState @id = '{serviceRequest.ServiceRequestID}', @closed = '{GetIntFromBool(serviceRequest.Closed)}'";
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
        public void UpdateSpecializationList(ServiceRequest serviceRequest)
        {
            InsertAllSpeciliozationOfServiceRequest(serviceRequest);
            CreateConnection();
            commandString = $"EXEC UpdateServiceRequestSpecializationList @id = '{serviceRequest.ServiceRequestID}'";
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
        public void Insert(ServiceRequest serviceRequest)
        {
            CreateConnection();
            int closed = 0;
            if (serviceRequest.Closed == true)
            {
                closed = 1;
            }
            commandString = $"EXEC InsertServiceRequest @id = '{serviceRequest.CallID}', @callId = '{serviceRequest.CallID}', @closed = '{closed}', @description = '{serviceRequest.Description}'";
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
        public List<ServiceRequest> SelectAllServiceRequests()
        {
            CreateConnection();
            commandString = $"EXEC SelectAllServiceRequests";
            Command = new SqlCommand(commandString, Connection);
            List<ServiceRequest> ServiceRequestList = new List<ServiceRequest>();
            try
            {
                OpenConnection();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    ServiceRequestList.Add(new ServiceRequest((int)Reader["serviceRequestID"], GetTrueFalseFromBit((int)Reader["closed"]), (string)Reader["description"], (int)Reader["callID"], GetSpecialisationById((int)Reader["serviceRequestID"]), (string)Reader["priorityLevel"]));
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }


            return ServiceRequestList;
        }
        public List<ServiceRequest> SelectAllServiceRequestsByBusinessClient(string id)
        {
            CreateConnection();
            commandString = $"EXEC SelectAllServiceRequestsByBusinessClient @id = '{id}'";
            Command = new SqlCommand(commandString, Connection);
            List<ServiceRequest> ServiceRequestList = new List<ServiceRequest>();
            try
            {
                OpenConnection();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    ServiceRequestList.Add(new ServiceRequest((int)Reader["serviceRequestID"], GetTrueFalseFromBit((int)Reader["closed"]), (string)Reader["description"], (int)Reader["callID"], GetSpecialisationById((int)Reader["serviceRequestID"]), (string)Reader["priorityLevel"]));
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }


            return ServiceRequestList;
        }
        public List<ServiceRequest> SelectAllServiceRequestsByIndividualClient(string id)
        {
            CreateConnection();
            commandString = $"EXEC SelectAllServiceRequestsByIndividualClient @id= '{id}'";
            Command = new SqlCommand(commandString, Connection);
            List<ServiceRequest> ServiceRequestList = new List<ServiceRequest>();
            try
            {
                OpenConnection();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    ServiceRequestList.Add(new ServiceRequest((int)Reader["serviceRequestID"], GetTrueFalseFromBit((int)Reader["closed"]), (string)Reader["description"], (int)Reader["callID"], GetSpecialisationById((int)Reader["serviceRequestID"]), (string)Reader["priorityLevel"]));
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }
            return ServiceRequestList;
        }
        #endregion

        #region SeperateMethods
        private List<Specialisation> GetSpecialisationById(int serviceRequestID)
        {

            SqlConnection specialisationConnection = new SqlConnection(connectionSring);
            SqlDataReader specialisationReader;
            List<Specialisation> specialisationList = new List<Specialisation>();
            commandString = $"EXEC SelectAllSpecilisationbyServiceRequest @id = '{serviceRequestID}'";
            SqlCommand specialisationCommand = new SqlCommand(commandString, specialisationConnection);

            try
            {
                specialisationConnection.Open();
                specialisationReader = specialisationCommand.ExecuteReader();
                while (specialisationReader.Read())
                {
                    specialisationList.Add(new Specialisation((int)specialisationReader["specialisationID"], (string)specialisationReader["name"], (string)specialisationReader["description"]));
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
                specialisationConnection.Close();
            }
            return specialisationList;
        }
        private void InsertAllSpeciliozationOfServiceRequest(ServiceRequest serviceRequest)
        {
            SqlConnection specialisationConnection = new SqlConnection(connectionSring);

            try
            {
                specialisationConnection.Open();
                for (int i = 0; i < serviceRequest.SpecialisationRequiredList.Count; i++)
                {
                    commandString = $"EXEC InsertIntoTVPServiceRequestSpecilization @serviceRequestId = '{serviceRequest.ServiceRequestID}', @SpecilizationId = '{serviceRequest.SpecialisationRequiredList[i].SpecialisationID}'";
                    SqlCommand specialisationCommand = new SqlCommand(commandString, specialisationConnection);
                    specialisationCommand.ExecuteNonQuery();
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
                specialisationConnection.Close();
            }
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
