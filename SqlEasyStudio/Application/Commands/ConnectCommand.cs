using SqlEasyStudio.Domain;
using SqlEasyStudio.Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlEasyStudio.Application.Commands
{
    // to think about: should ConnectCommand have just connectionstring or depend on connectionItem
    public class ConnectCommand
    {
        public ConnectionItem ConnectionItem { get; private set; }

        public ConnectCommand(ConnectionItem connectionItem)
        {
            ConnectionItem = connectionItem;
        }
    }
}
