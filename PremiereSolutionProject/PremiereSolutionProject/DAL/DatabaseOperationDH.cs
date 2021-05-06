using PremiereSolutionProject.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PremiereSolutionProject.DAL
{
    public class DatabaseOperationDH : DatabaseConnection
    {
        #region Insert
        public void CreateOperationLog(DatabaseOperation operation)
        {
            try
            {
                DateTime time = DateTime.Now;
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    
                    connection.Open();
                    commandString = $"EXEC CreateDatabaseOperationLog @dateTime = '{time}', @description = '{operation.Description}', @success = '{GetIntFromBool(operation.Success)}'";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("If you see this error, the exception logger failed and needs to ternimate the application forcefully, all unsaved progress will be lost");
                MessageBox.Show("The Error will not be able to be logged, the error is: \n\n\n" + e);
                Environment.Exit(1);
            }
        }
        #endregion

        public List<DatabaseOperation> SelectAllErrors()
        {
            List<DatabaseOperation> errorList = new List<DatabaseOperation>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = $"EXEC GetAllErrors";
                    SqlCommand command = new SqlCommand(commandString, connection);
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        errorList.Add(new DatabaseOperation((int)reader["errorID"], (DateTime)reader["dateAndTime"], GetTrueFalseFromBit((int)reader["success"]), (string)reader["description"]));
                    }
                }
            }
            catch (Exception)
            {
                DatabaseOperation databaseOperation = new DatabaseOperation(false, "EXEC GetAllErrors");
                CreateOperationLog(databaseOperation);
            }
            return errorList;
        }
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
