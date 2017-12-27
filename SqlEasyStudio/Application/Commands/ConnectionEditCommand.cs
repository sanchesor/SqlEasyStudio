using SqlEasyStudio.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlEasyStudio.Application.Commands
{
    public class ConnectionEditCommand
    {
        public ObjectExplorerItem Item { get; private set; }

        public ConnectionEditCommand(ObjectExplorerItem item)
        {
            Item = item;
        }
    }
}
