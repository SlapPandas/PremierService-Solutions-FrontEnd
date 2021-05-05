using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PremiereSolutionProject.DAL;
using PremiereSolutionProject.BLL.Interfaces;

namespace PremiereSolutionProject.BLL
{
    public abstract class FactoryClass
    {
        public abstract IEntity GetEntity(string needed);
    }
}
