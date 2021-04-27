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
    class DatabaseConnection : IDataconnection
    {
        #region Fields
        public string connectionSring = @"Data Source =.; Initial Catalog = PremierServiceSolutionsDatabase; Integrated Security = SSPI";
        public SqlConnection Connection;

        public string commandString = "";
        public SqlCommand Command;

        public SqlDataReader Reader;
        #endregion

        #region Methods
        public void CreateConnection()
        {
            Connection = new SqlConnection(connectionSring);
        }
        public void OpenConnection()
        {
            try
            {
                Connection.Open();
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }

        }
        public void CloseConnection()
        {
            try
            {
                Connection.Close();
            }
            catch (Exception e)
            {
                DatabaseOperationDH databaseOperationDH = new DatabaseOperationDH();
                DatabaseOperation databaseOperation = new DatabaseOperation(false, e.ToString());
                databaseOperationDH.CreateOperationLog(databaseOperation);
            }

        }
        #endregion
    }
}
