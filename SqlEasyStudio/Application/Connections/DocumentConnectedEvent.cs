using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlEasyStudio.Application.Connections
{
    public class DocumentConnectedEvent
    {
        public IDocument Document { get; }
        public ConnectionLink ConnectionLink { get; }

        public DocumentConnectedEvent(IDocument document, ConnectionLink link)
        {
            Document = document;
            ConnectionLink = link;
        }
        
    }
}
