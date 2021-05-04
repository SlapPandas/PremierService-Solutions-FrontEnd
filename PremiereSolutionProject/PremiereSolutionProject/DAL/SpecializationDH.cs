using PremiereSolutionProject.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiereSolutionProject.DAL
{
    class SpecializationDH : DatabaseConnection
    {
        #region Update
        public void Update(Specialisation specialisation)
        {
            UpdateCommand($"EXEC UpdateSpecialization @i = '{specialisation.SpecialisationID}', @name = '{specialisation.SpecialisationName}',@description = '{specialisation.Description}'");
        }
        #endregion

        #region Delete
        public bool Delete(Specialisation specialisation)
        {
            if (GetNumberOfSpecializationUses(specialisation.SpecialisationID) > 0)
            {
                return false;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC DeleteSpecialisation @id = '{specialisation.SpecialisationID}'";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    command.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
                return false;
            }
            finally {}
        }
        #endregion

        #region Insert
        public void Insert(Specialisation specialisation)
        {
            CreateConnection();
            commandString = $"EXEC InsertSpecialisation @name = '{specialisation.SpecialisationName}', @description = '{specialisation.Description}'";
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
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
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
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally {}

            return specialisation;
        }
        #endregion

        #region Seperate Methods
        private int GetNumberOfSpecializationUses(int specializationId)
        {
            int output = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC SpecialisationUses @id = '{specializationId}'";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        output = (int)reader["uses"];
                    }
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally{}
            return output;
        }
        #endregion
    }
}
