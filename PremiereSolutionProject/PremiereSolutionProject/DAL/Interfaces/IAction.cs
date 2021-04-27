using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiereSolutionProject.DAL.Interfaces
{
    interface IAction
    {
        //bool Add(object myobject);
        //bool Update(int myidentifier, object myobject);
        void Delete(int myidentifier);
    }
}
