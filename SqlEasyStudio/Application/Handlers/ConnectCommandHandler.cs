using SqlEasyStudio.Application.Commands;
using SqlEasyStudio.Application.Connections;
using SqlEasyStudio.Infrastructure.IoC;
using SqlEasyStudio.Infrastructure.Messaging;

namespace SqlEasyStudio.Application.Handlers
{
    public class ConnectCommandHandler : ICommandHandler<ConnectCommand>
    {
        IDocumentsController documentsController;
        IDocumentConnector documentConnector;

        public ConnectCommandHandler()
        {
            var container = ContainerDelivery.GetContainer();
            documentsController = container.Resolve<IDocumentsController>();
            documentConnector = container.Resolve<IDocumentConnector>();
        }        

        public void Handle(ConnectCommand command)
        {
            documentConnector.Connect(documentsController.CurrentDocument, command.ConnectionItem);
        }
    }
}
