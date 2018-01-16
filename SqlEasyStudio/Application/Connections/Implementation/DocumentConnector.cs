using SqlEasyStudio.Domain;
using SqlEasyStudio.Domain.Enums;
using SqlEasyStudio.Infrastructure.IoC;
using SqlEasyStudio.Infrastructure.IoC.Attributes;
using SqlEasyStudio.Infrastructure.IoC.Container;
using SqlEasyStudio.Infrastructure.Validation;
using System;
using System.Collections.Generic;

namespace SqlEasyStudio.Application.Connections.Implementation
{
    [Component (LifeCycle = LifeCycle.Singleton)]
    public class DocumentConnector : IDocumentConnector
    {
        public Dictionary<IDocument, ConnectionLink> ConnectedDocuments { get; }

        public event EventHandler<DocumentConnectionEvent> DocumentConnected;
        public event EventHandler<DocumentConnectionEvent> DocumentDisconnected;

        public DocumentConnector()
        {
            ConnectedDocuments = new Dictionary<IDocument, ConnectionLink>();
        }

        public void Connect(IDocument document, ObjectExplorerItem connectionItem)
        {
            AssertNotConnected(document);

            var connection = CreateConnectionFromItem(connectionItem);

            var connectionLink = new ConnectionLink(connectionItem, connection);
            ConnectedDocuments.Add(document, connectionLink);

            DocumentConnected.Invoke(null, new DocumentConnectionEvent(document, connectionLink));
        }

        public void Disconnect(IDocument document)
        {
            AssertConnected(document);

            var connectionLink = ConnectedDocuments[document];
            var connection = connectionLink.Connection;
            connection.Close();
            ConnectedDocuments.Remove(document);

            DocumentDisconnected?.Invoke(null, new DocumentConnectionEvent(document, connectionLink));
        }

        private void AssertNotConnected(IDocument document)
        {
            if (ConnectedDocuments.ContainsKey(document))
                throw new Exception("Document already connected.");
        }

        private void AssertConnected(IDocument document)
        {
            if (!ConnectedDocuments.ContainsKey(document))
                throw new Exception("Document not connected.");
        }

        private IConnection CreateConnectionFromItem(ObjectExplorerItem item)
        {
            Validate.IsTrue(item.ItemType == ObjectExplorerItemType.Connection);

            IConnectionFactory connectionFactory = ContainerDelivery.GetContainer().Resolve<IConnectionFactory>();
            // todo: make async, connectionFactory.ConnectionCreated += .. (document, connectionLink)
            return connectionFactory.Create(item.Data as string);

        }

    }
}
