using SqlEasyStudio.Application.Commands;
using SqlEasyStudio.Application.Connections;
using SqlEasyStudio.Infrastructure.IoC;
using SqlEasyStudio.Infrastructure.Messaging;

namespace SqlEasyStudio.Application.Handlers
{
    public class ConnectCommandHandler : ICommandHandler<ConnectCommand>
    {
        IDocumentsController documentsController;

        public ConnectCommandHandler()
        {
            documentsController = ContainerDelivery.GetContainer().Resolve<IDocumentsController>();
        }        

        public void Handle(ConnectCommand command)
        {
            DocumentConnector.Connect(documentsController.CurrentDocument, command.ConnectionItem);
        }
    }
}
