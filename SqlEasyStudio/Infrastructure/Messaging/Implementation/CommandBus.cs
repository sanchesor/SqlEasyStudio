using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlEasyStudio.Infrastructure.Messaging.Implementation
{
    public class CommandBus : ICommandBus
    {
        public void Send(ICommand command)
        {
            throw new NotImplementedException();
        }
    }
}
