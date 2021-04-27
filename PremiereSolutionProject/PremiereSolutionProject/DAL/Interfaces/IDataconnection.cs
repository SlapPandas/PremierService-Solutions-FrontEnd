﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PremiereSolutionProject.DAL.Interfaces
{
    interface IDataconnection
    {
        void CreateConnection();
        void OpenConnection();
        void CloseConnection();
    }
}