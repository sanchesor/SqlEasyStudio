using SqlEasyStudio.Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlEasyStudio.Application.Commands
{
    public class ConnectCommand : ICommand
    {
        public string ConnectionString { get; private set; }

        public ConnectCommand(string connectionString)
        {
            ConnectionString = connectionString;
        }
    }
}
