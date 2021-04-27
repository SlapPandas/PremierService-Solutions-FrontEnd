using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PremiereSolutionProject.DAL;
using PremiereSolutionProject.BLL.Interfaces;

namespace PremiereSolutionProject.BLL
{
    class ClientFactory : FactoryClass
    {

        public override IEntity GetEntity(string clientNeeded)
        {
            switch (clientNeeded)
            {
                case "I":
                    return new IndividualClient();

                case "B":
                    return new BusinessClient();

                default:
                    return null;
            }

        }

    }
}
