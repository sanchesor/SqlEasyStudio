using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlEasyStudio.Infrastructure.Messaging
{
    public interface ICommandHandlerFactory
    {
        ICommandHandler<T> Create<T>();        
    }
}
