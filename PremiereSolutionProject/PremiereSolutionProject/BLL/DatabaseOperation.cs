using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PremiereSolutionProject.DAL;
using PremiereSolutionProject.BLL.Interfaces;

namespace PremiereSolutionProject.BLL
{
    public class DatabaseOperation
    {
        #region Properties
        public int Id { get; set; }
        public DateTime DateAndTime { get; set; }
        public bool Success { get; set; }
        public string Description { get; set; }
        #endregion

        #region Constructor
        public DatabaseOperation()
        {
        }
        public DatabaseOperation(int errorId, DateTime errorDateTime, bool success, string errorMessage)
        {
            this.Id = errorId;
            this.DateAndTime = errorDateTime;
            this.Success = success;
            this.Description = errorMessage;

        }
        public DatabaseOperation(DateTime errorDateTime, bool success, string errorMessage)
        {
            DateAndTime = errorDateTime;
            Description = errorMessage;
        }

        //constructor to set the Description of an error
        public DatabaseOperation(bool success, string errorMessage)
        {
            Description = errorMessage;
        }
        #endregion

        #region Methods

        public List<DatabaseOperation> SelectAllErrors()
        {
            DatabaseOperationDH errorDH = new DatabaseOperationDH();
            return errorDH.SelectAllErrors();
        }

        #endregion
    }
}
