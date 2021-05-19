using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PremiereSolutionProject.DAL;
using PremiereSolutionProject.BLL.Interfaces;

namespace PremiereSolutionProject.BLL
{
    public class EmployeeFactory : FactoryClass
    {
        public override IEntity GetEntity(string employeeNeeded)
        {
            switch (employeeNeeded.ToUpper())
            {
                case "M":
                    return new MaintenanceEmployee();

                case "S":
                    return new ServiceManager();

                case "C":
                    return new CallCenterEmployee();

                default:
                    return null;
            }
        }
    }
}
