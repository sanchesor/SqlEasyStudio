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
        Dictionary<IDocument, ConnectionLink> ConnectedDocuments { get; }

        event EventHandler<DocumentConnectionEvent> DocumentConnected;
        event EventHandler<DocumentConnectionEvent> DocumentDisconnected;

        void Connect(IDocument document, ObjectExplorerItem connectionItem);
        void Disconnect(IDocument document);
    }
}
