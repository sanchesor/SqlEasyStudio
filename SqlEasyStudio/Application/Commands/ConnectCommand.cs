using SqlEasyStudio.Domain;
using SqlEasyStudio.Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlEasyStudio.Application.Commands
{
    public class ConnectCommand
    {
        public ObjectExplorerItem ConnectionItem { get; private set; }

        public ConnectCommand(ObjectExplorerItem connectionItem)
        {
            ConnectionItem = connectionItem;
        }
    }
}
