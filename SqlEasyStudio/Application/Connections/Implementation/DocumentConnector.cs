﻿using SqlEasyStudio.Domain;
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
        public event EventHandler<DocumentConnectedEvent> DocumentConnected;

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

            DocumentConnected.Invoke(null, new DocumentConnectedEvent(document, connectionLink));
        }

        private void AssertNotConnected(IDocument document)
        {
            if (ConnectedDocuments.ContainsKey(document))
                throw new Exception("Document already connected");
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