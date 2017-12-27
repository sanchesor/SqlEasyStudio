using SqlEasyStudio.Infrastructure.IoC;
using SqlEasyStudio.Infrastructure.IoC.Attributes;
using System;

namespace SqlEasyStudio.Infrastructure.Messaging.Implementation
{
    [Component]
    public class CommandBus : ICommandBus
    {
        ICommandHandlerFactory _handlerFactory;
        public CommandBus()
        {
            _handlerFactory = ContainerDelivery.GetContainer().Resolve<ICommandHandlerFactory>();
        }

        public void Send<T>(T command)
        {
            var commandHandler = _handlerFactory.Create<T>();
            commandHandler.Handle(command);
        }
    }
}
