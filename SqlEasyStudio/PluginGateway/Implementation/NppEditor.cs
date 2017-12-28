using Kbg.NppPluginNET.PluginInfrastructure;
using SqlEasyStudio.Application;
using SqlEasyStudio.Infrastructure.IoC.Attributes;
using SqlEasyStudio.Infrastructure.IoC.Container;
using System;
using System.Collections.Generic;

namespace SqlEasyStudio.PluginGateway.Implementation
{
    [Component (LifeCycle = LifeCycle.Singleton)]
    public class NppDocumentsController : IDocumentsController
    {
        private Dictionary<IntPtr, IDocument> _docs = new Dictionary<IntPtr, IDocument>();

        public IDocument CurrentDocument
        {
            get
            {
                IntPtr doc = PluginBase.GetCurrentScintilla();
                if(!_docs.ContainsKey(doc))
                {
                    _docs.Add(doc, new NppDocument(doc));
                }
                return _docs[doc];
            }
        }        
    }
}
