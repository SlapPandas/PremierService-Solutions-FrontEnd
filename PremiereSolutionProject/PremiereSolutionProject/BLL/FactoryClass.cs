﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiereSolutionProject.BLL
{
    abstract class FactoryClass
    {
        public abstract IEntity GetEntity(string needed);
    }
}
