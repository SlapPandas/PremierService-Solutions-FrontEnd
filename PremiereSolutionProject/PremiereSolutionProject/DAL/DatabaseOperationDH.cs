using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PremiereSolutionProject.DAL
{
    class DatabaseOperationDH : DatabaseConnection
    {
        #region Insert
        public void CreateOperationLog(DatabaseOperation operation)
        {
            DateTime time = DateTime.Now;
            CreateConnection();
            commandString = $"EXEC CreateDatabaseOperationLog @dateAndTime = '{time.ToString("yyyy-MM-dd HH:mm:ss")}', @description = '{operation.Description}', @success = '{GetIntFromBool(operation.Success)}'";
            Command = new SqlCommand(commandString, Connection);

            try
            {
                OpenConnection();
                Command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show("If you see this error, the exception logger failed and needs to ternimate the application forcefully, all unsaved progress will be lost");
                MessageBox.Show("The Error will not be able to be logged, the error is: \n\n\n" + e);
                Environment.Exit(1);
            }
            finally { CloseConnection(); }
        }
        #endregion

        public List<DatabaseOperation> SelectAllErrors()
        {
            CreateConnection();
            commandString = $"EXEC GetAllErrors";
            Command = new SqlCommand(commandString, Connection);
            List<DatabaseOperation> errorList = new List<DatabaseOperation>();

            try
            {
                OpenConnection();
                Reader = Command.ExecuteReader();
                while (Reader.Read())
                {
                    errorList.Add(new DatabaseOperation((int)Reader["errorID"], (DateTime)Reader["dateAndTime"], GetTrueFalseFromBit((int)Reader["success"]), (string)Reader["description"]));
                }
            }
            catch (Exception e)
            {
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                CreateOperationLog(databaseOperation);
            }
            finally { CloseConnection(); }

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
