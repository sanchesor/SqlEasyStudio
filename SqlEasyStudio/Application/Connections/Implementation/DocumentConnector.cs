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
        // todo: refactor, get rid of connectionlink
        private Dictionary<IDocument, ConnectionLink> Connections { get; }

        public bool HasConnectedDocument(IDocument document)
        {
            return Connections.ContainsKey(document);
        }

        public bool HasActiveConnectionForDocument(IDocument document)
        {
            return Connections.ContainsKey(document) && Connections[document].Connection.Status != ConnectionStatus.Closed;
        }

        public ConnectionLink GetConnectionForDocument(IDocument document)
        {
            return Connections[document];
        }

        public event EventHandler<DocumentConnectionEvent> ConnectingStarted;
        public event EventHandler<DocumentConnectionEvent> ConnectingFinished;
        public event EventHandler<DocumentConnectionEvent> Disconnected;

        public DocumentConnector()
        {
            Connections = new Dictionary<IDocument, ConnectionLink>();
        }

        public void Connect(IDocument document, ConnectionItem connectionItem)
        {
            var connection = PrepareConnection(document, connectionItem);
            connection.Open();            
        }


        public void StartConnect(IDocument document, ConnectionItem connectionItem)
        {
            var connection = PrepareConnection(document, connectionItem);
            ConnectingStarted.Invoke(null, new DocumentConnectionEvent(document, Connections[document]));
            connection.StartOpen();
            
        }

        public void Disconnect(IDocument document)
        {
            AssertIsActiveConnection(document);

            var connectionLink = Connections[document];
            var connection = connectionLink.Connection;

            connection.Close();
            Disconnected?.Invoke(null, new DocumentConnectionEvent(document, connectionLink));
        }


        public IConnection PrepareConnection(IDocument document, ConnectionItem connectionItem)
        {
            AssertNoActiveConnection(document);

            var connection = CreateConnectionFromItem(connectionItem);
            var connectionLink = new ConnectionLink(connectionItem, connection);
            if (!Connections.ContainsKey(document))
                Connections.Add(document, null);
            Connections[document] = connectionLink;

            connection.Opened += Connection_Opened;
            connection.OpenFailed += Connection_OpenFailed;

            return connection;
        }

        private void Connection_Opened(object sender, EventArgs e)
        {
            HandleConnectionEvent(sender as IConnection,
                (doc, conn) => ConnectingFinished.Invoke(null, new DocumentConnectionEvent(doc, conn)));
        }

        private void Connection_OpenFailed(object sender, EventArgs e)
        {
            HandleConnectionEvent(sender as IConnection,
                (doc, conn) => ConnectingFinished.Invoke(null, new DocumentConnectionEvent(doc, conn)));
        }

        private void HandleConnectionEvent(IConnection connection, Action<IDocument, ConnectionLink> handler)
        {
            foreach (var doc in Connections.Keys)
            {
                if (Connections[doc].Connection == connection)
                    handler.Invoke(doc, Connections[doc]);
            }
        }

        private void AssertNoActiveConnection(IDocument document)
        {
            if(HasActiveConnectionForDocument(document))
                throw new Exception("Document already connected.");
        }

        private void AssertIsActiveConnection(IDocument document)
        {
            if (!HasActiveConnectionForDocument(document))
                throw new Exception("Document not connected.");
        }

        private IConnection CreateConnectionFromItem(ConnectionItem item)
        {            
            IConnectionFactory connectionFactory = ContainerDelivery.GetContainer().Resolve<IConnectionFactory>();            
            return connectionFactory.Create(item.ConnectionString);
        }

    }
}
