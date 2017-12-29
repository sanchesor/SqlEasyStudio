﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlEasyStudio.Application.Connections
{
    public interface IConnectionFactory
    {
        IConnection Create(string connectionString);
    }
}
