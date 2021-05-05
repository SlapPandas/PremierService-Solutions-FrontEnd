using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiereSolutionProject.BLL.Interfaces
{
    public interface IEntity
    {
        #region Properties
        //properties that all the inheriting classes will have
        string Id
        {
            get;
            set;
        }

        Address Address
        {
            get;
            set;
        }
        string ContactNumber
        {
            get;
            set;
        }
        DateTime RegistrationDate
        {
            get;
            set;
        }
        #endregion

        ////creating a list of respective objects
        //List<IEntity> CreateList();

        ////registering a new object, (i.e. new IndividualClient, new MaintenanceEmployee)
        //IEntity RegisterEntity();
    }
}
