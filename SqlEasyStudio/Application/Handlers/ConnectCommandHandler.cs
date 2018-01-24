using SqlEasyStudio.Application.Commands;
using SqlEasyStudio.Application.Connections;
using SqlEasyStudio.Domain;
using SqlEasyStudio.Infrastructure.Exceptions;
using SqlEasyStudio.Infrastructure.IoC;
using SqlEasyStudio.Infrastructure.IoC.Container;
using SqlEasyStudio.Infrastructure.Messaging;
using System;

namespace SqlEasyStudio.Application.Handlers
{
    public class ConnectCommandHandler : ICommandHandler<ConnectCommand>
    {
        IDocumentsController documentsController;
        IDocumentConnector documentConnector;
        IContainer container;

        public ConnectCommandHandler()
        {
            container = ContainerDelivery.GetContainer();
            documentsController = container.Resolve<IDocumentsController>();
            documentConnector = container.Resolve<IDocumentConnector>();
        }        

        public void Handle(ConnectCommand command)
        {
            try
            {
                Connect(command.ConnectionItem, documentsController.CurrentDocument);
            }
            catch(Exception ex)
            {
                var exceptionHandler = container.Resolve<IExceptionHandler>();
                exceptionHandler.Handle(ex.Message);
            }
        }

        private void Connect(ConnectionItem item, IDocument document)
        {            
            DisconnectForDocument(document);
            documentConnector.StartConnect(document, item);
        }

        private void DisconnectForDocument(IDocument document)
        {
            if(documentConnector.HasActiveConnectionForDocument(document))
            {
                documentConnector.Disconnect(document);
            }
        }
    }
}
