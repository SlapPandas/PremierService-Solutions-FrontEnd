using PremiereSolutionProject.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiereSolutionProject.DAL
{
    public class SpecializationDH : DatabaseConnection
    {
        #region Update
        public void Update(Specialisation specialisation)
        {
            UpdateCommand($"EXEC UpdateSpecialization @id = '{specialisation.SpecialisationID}', @name = '{specialisation.SpecialisationName}',@description = '{specialisation.Description}'");
        }
        #endregion

        #region Delete
        public void Delete(Specialisation specialisation)
        {
            DeleteCommand($"EXEC DeleteSpecialisation @id = '{specialisation.SpecialisationID}'");
        }
        #endregion

        #region Insert
        public void Insert(Specialisation specialisation)
        {
            InsertCommand($"EXEC InsertSpecialisation @name = '{specialisation.SpecialisationName}', @description = '{specialisation.Description}'");
        }
        public void InsertAllSpeciliozationOfServiceRequest(ServiceRequest serviceRequest)
        {
            for (int i = 0; i < serviceRequest.SpecialisationRequiredList.Count; i++)
            {
                InsertCommand($"EXEC InsertIntoTVPServiceRequestSpecilization @serviceRequestId = '{serviceRequest.ServiceRequestID}', @SpecilizationId = '{serviceRequest.SpecialisationRequiredList[i].SpecialisationID}'");
            }
        }
        public void InsertAllSpeciliozationOfNewServiceRequest(ServiceRequest serviceRequest)
        {
            for (int i = 0; i < serviceRequest.SpecialisationRequiredList.Count; i++)
            {
                InsertCommand($"EXEC InsertIntoTVPNewServiceRequestSpecilization @SpecilizationId = '{serviceRequest.SpecialisationRequiredList[i].SpecialisationID}'");
            }
        }
        public void InsertAllSpeciliozationOfMaintenanceEmployee(MaintenanceEmployee employee)
        {
            for (int i = 0; i < employee.Specialisations.Count; i++)
            {
                InsertCommand($"EXEC InsertIntoTVPMaintenanceEmployeeSpecilization @employeeId = '{employee.Id}', @SpecilizationId = '{employee.Specialisations[i].SpecialisationID}'");
            }
        }
        public void InsertAllSpeciliozationOfNewMaintenanceEmployee(MaintenanceEmployee employee)
        {
            for (int i = 0; i < employee.Specialisations.Count; i++)
            {
                InsertCommand($"EXEC InsertIntoTVPNewMaintenanceEmployeeSpecilization @SpecilizationId = '{employee.Specialisations[i].SpecialisationID}'");
            }
        }
        #endregion

        #region Select
        public List<Specialisation> SelectAllSpecialisations()
        {
            List<Specialisation> specialisation = new List<Specialisation>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAllSpecialisations";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        specialisation.Add(new Specialisation((int)reader["specialisationID"], (string)reader["name"], (string)reader["description"]));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally {}

            return specialisation;
        }
        public List<Specialisation> SelectAllSpecialisationNames()
        {
            List<Specialisation> specialisation = new List<Specialisation>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAllSpecialisationName";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        specialisation.Add(new Specialisation((string)reader["name"]));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally {}

            return specialisation;
        }
        public List<Specialisation> GetSpecialisationByIdForServiceRequest(int serviceRequestID)
        {
            List<Specialisation> specialisationList = new List<Specialisation>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectAllSpecilisationbyServiceRequest @id = '{serviceRequestID}'";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        specialisationList.Add(new Specialisation((int)reader["specialisationID"], (string)reader["name"], (string)reader["description"]));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally
            { }

            return specialisationList;
        }
        public List<Specialisation> GetSpecialisationByEmployeeId(int employeeId)
        {

            SqlConnection specialisationConnection = new SqlConnection(connectionSring);
            SqlDataReader specialisationReader;
            List<Specialisation> specialisationList = new List<Specialisation>();
            commandString = $"EXEC SelectSpecialisationByEmployeeId @id = '{employeeId}'";
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
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally
            {
                specialisationConnection.Close();
            }
            return specialisationList;
        }
        public Specialisation GetSpecialisationById(int specialisationID)
        {
            Specialisation specialisation = new Specialisation();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SelectSpecialisationById @id = '{specialisationID}'";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        specialisation = new Specialisation((int)reader["specialisationID"], (string)reader["name"], (string)reader["description"]);
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, connectionSring));
            }
            finally { }
            return specialisation;
        }
        #endregion
    }
}
