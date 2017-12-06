using Kbg.NppPluginNET.PluginInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlEasyStudio.PluginEntryPoint.Editor.Implementation
{
    public class NppEditor : IEditor
    {
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

        private Dictionary<IntPtr, IDocument> _docs = new Dictionary<IntPtr, IDocument>();
    }
}
