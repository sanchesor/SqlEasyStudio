using Kbg.NppPluginNET.PluginInfrastructure;
using SqlEasyStudio.Application;
using SqlEasyStudio.Infrastructure.IoC.Attributes;
using SqlEasyStudio.Infrastructure.IoC.Container;
using System;
using System.Collections.Generic;
using SqlEasyStudio.Application.Documents;

namespace SqlEasyStudio.PluginGateway.Implementation
{
    [Component (LifeCycle = LifeCycle.Singleton)]
    public class NppDocumentsController : IDocumentsController
    {
        private Dictionary<IntPtr, IDocument> _docs = new Dictionary<IntPtr, IDocument>();

        public IDocument CurrentDocument
        {
            get { return GetDocumentById(PluginBase.GetCurrentBufferId()); }
        }

        private IDocument previouslyActiveDocument;

        // probably should not be here
        public event EventHandler<DocumentActivationChangedEvent> DocumentActivationChanged;

        public void ActivateDocument(IDocument document)
        {
            if (previouslyActiveDocument != null)
            {
                DocumentActivationChanged?.Invoke(null, new DocumentActivationChangedEvent {
                    Document = previouslyActiveDocument, IsActive = false });
            }

            DocumentActivationChanged?.Invoke(null, new DocumentActivationChangedEvent {
                Document = document, IsActive = true });

            previouslyActiveDocument = document;
        }

        public IDocument GetDocumentById(object docId)
        {
            IntPtr id = (IntPtr)docId;
            if (!_docs.ContainsKey(id))
            {
                _docs.Add(id, new NppDocument(id));
            }
            return _docs[id];
        }
    }
}
