using SqlEasyStudio.Domain;
using SqlEasyStudio.Infrastructure.IoC;
using System;
using System.Collections.Generic;

namespace SqlEasyStudio.Application.Connections
{
    public static class DocumentConnector
    {
        public static Dictionary<IDocument, ConnectionLink> ConnectedDocuments = new Dictionary<IDocument, ConnectionLink>();
        public static event EventHandler<DocumentConnectedEvent> DocumentConnected;

        public static void Connect(IDocument document, ObjectExplorerItem connectionItem)
        {
            if (ConnectedDocuments.ContainsKey(document))
                throw new Exception("Document already connected");

            IConnectionFactory connectionFactory = ContainerDelivery.GetContainer().Resolve<IConnectionFactory>();
            // todo: make async, connectionFactory.ConnectionCreated += .. (document, connectionLink)
            IConnection connection = connectionFactory.Create(connectionItem.Data as string);

            var connectionLink = new ConnectionLink(connectionItem, connection);
            ConnectedDocuments.Add(document, connectionLink);

            DocumentConnected.Invoke(null, new DocumentConnectedEvent(document, connectionLink));
        }
    }
}
