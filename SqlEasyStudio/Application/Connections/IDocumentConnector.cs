using SqlEasyStudio.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlEasyStudio.Application.Connections
{
    public interface IDocumentConnector
    {
        bool HasConnectedDocument(IDocument document);
        bool HasActiveConnectionForDocument(IDocument document);
        ConnectionLink GetConnectionForDocument(IDocument document);

        event EventHandler<DocumentConnectionEvent> ConnectingStarted;
        event EventHandler<DocumentConnectionEvent> ConnectingFinished;
        event EventHandler<DocumentConnectionEvent> Disconnected;

        void Connect(IDocument document, ConnectionItem connectionItem);
        void StartConnect(IDocument document, ConnectionItem connectionItem);
        void Disconnect(IDocument document);
    }
}
