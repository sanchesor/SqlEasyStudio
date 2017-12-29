using SqlEasyStudio.Domain;
using SqlEasyStudio.Infrastructure.IoC;
using System;
using System.Collections.Generic;

namespace SqlEasyStudio.Application.Connections
{
    public static class DocumentConnector
    {
        public static Dictionary<IDocument, ConnectionLink> ConnectedDocuments = new Dictionary<IDocument, ConnectionLink>();

        public static void Connect(IDocument document, ObjectExplorerItem connectionItem)
        {
            if (ConnectedDocuments.ContainsKey(document))
                throw new Exception("Document already connected");

            IConnectionFactory connectionFactory = ContainerDelivery.GetContainer().Resolve<IConnectionFactory>();
            // todo: make async, connectionFactory.ConnectionCreated += .. (document, connectionLink)
            IConnection connection = connectionFactory.Create(connectionItem.Data as string);

            ConnectedDocuments.Add(document, new ConnectionLink(connectionItem, connection));
        }
    }
}
