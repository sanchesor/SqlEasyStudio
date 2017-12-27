using SqlEasyStudio.Infrastructure.IoC;
using SqlEasyStudio.Infrastructure.IoC.Attributes;
using SqlEasyStudio.Infrastructure.IoC.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlEasyStudio.Infrastructure.Messaging.Implementation
{
    [Component]
    public class CommandHandlerFactory : ICommandHandlerFactory
    {
        IContainer _container;
        public CommandHandlerFactory()
        {
            _container = ContainerDelivery.GetContainer();
        }
        public ICommandHandler<T> Create<T>()
        {
            return _container.Resolve<ICommandHandler<T>>();
        }
    }
}
