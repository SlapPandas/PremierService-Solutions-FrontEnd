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
    public class DatabaseConnection : IDataconnection
    {
        #region Fields
        //public string connectionSring = @"Data Source =.; Initial Catalog = PremierServiceSolutionsDatabase; Integrated Security = SSPI";
        public string connectionSring = @"Data Source =localhost,11433; Initial Catalog = PremierServiceSolutionsDatabase; User ID=sa;Password=GrantedPeople1209!";
        public string commandString = "";
        #endregion

        #region Methods
        public void UpdateCommand(string input) {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = input;
                    SqlCommand command = new SqlCommand(commandString, connection);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, input));
            }

        }
        public void DeleteCommand(string input) {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = input;
                    SqlCommand command = new SqlCommand(commandString, connection);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, input));
            }
        }
        public void InsertCommand(string input)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = input;
                    SqlCommand command = new SqlCommand(commandString, connection);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, input));
            }
        }
        public int InsertCommandWithReturnedId(string input)
        {
            int id = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionSring))
                {
                    connection.Open();
                    commandString = input;
                    SqlCommand command = new SqlCommand(commandString, connection);
                    id = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            catch (Exception)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                databaseOperationDH.CreateOperationLog(new DatabaseOperation(false, input));
            }
            return id;
        }
        #endregion
    }
}
