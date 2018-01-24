using SqlEasyStudio.Application.Documents;
using System;

namespace SqlEasyStudio.Application
{
    public interface IDocumentsController
    {
        IDocument CurrentDocument { get; }
        IDocument GetDocumentById(object docId);
        // probably should not be here
        event EventHandler<DocumentActivationChangedEvent> DocumentActivationChanged;        
        void ActivateDocument(IDocument document);
    }
}
