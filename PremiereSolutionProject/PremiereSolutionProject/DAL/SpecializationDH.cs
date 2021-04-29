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
            CreateConnection();
            commandString = $"EXEC UpdateSpecialization @id = '{specialisation.SpecialisationID}', @name = '{specialisation.SpecialisationName}',@description = '{specialisation.Description}'";
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

        #region Delete
        public bool Delete(Specialisation specialisation)
        {
            if (GetNumberOfSpecializationUses(specialisation.SpecialisationID) > 0)
            {
                return false;
            }

            CreateConnection();
            commandString = $"EXEC DeleteSpecialisation @id = '{specialisation.SpecialisationID}'";
            Command = new SqlCommand(commandString, Connection);

            try
            {
                OpenConnection();
                Command.ExecuteNonQuery();
                return true;
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
                return false;
            }
            finally { CloseConnection(); }
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
            CreateConnection();
            commandString = $"EXEC SelectAllSpecialisations";
            Command = new SqlCommand(commandString, Connection);
            List<Specialisation> specialisation = new List<Specialisation>();
            try
            {
                OpenConnection();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    specialisation.Add(new Specialisation((int)Reader["specialisationID"], (string)Reader["name"], (string)Reader["description"]));
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }

            return specialisation;
        }
        public List<Specialisation> SelectAllSpecialisationNames()
        {
            CreateConnection();
            commandString = $"EXEC SelectAllSpecialisationName";
            Command = new SqlCommand(commandString, Connection);
            List<Specialisation> specialisation = new List<Specialisation>();
            try
            {
                OpenConnection();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    specialisation.Add(new Specialisation((string)Reader["name"]));
                }
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }

            return specialisation;
        }
        #endregion

        #region Seperate Methods
        private int GetNumberOfSpecializationUses(int specializationId)
        {

            SqlConnection specialisationConnection = new SqlConnection(connectionSring);
            SqlDataReader specialisationReader;
            int output = -1;
            commandString = $"EXEC SpecialisationUses @id = '{specializationId}'";
            SqlCommand specialisationCommand = new SqlCommand(commandString, specialisationConnection);

            try
            {
                specialisationConnection.Open();
                specialisationReader = specialisationCommand.ExecuteReader();
                while (specialisationReader.Read())
                {
                    output = (int)specialisationReader["uses"];
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
            return output;
        }
        #endregion
    }
}
