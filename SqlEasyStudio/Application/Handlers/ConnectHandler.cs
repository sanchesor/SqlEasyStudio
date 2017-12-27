using SqlEasyStudio.Application.Commands;
using SqlEasyStudio.Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlEasyStudio.Application.Handlers
{
    public class ConnectHandler : ICommandHandler<ConnectCommand>
    {
        public void Handle(ConnectCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
