using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlEasyStudio.Application.Connections
{
    public class DocumentConnectionEvent
    {
        public IDocument Document { get; }
        public ConnectionLink ConnectionLink { get; }

        public DocumentConnectionEvent(IDocument document, ConnectionLink link)
        {
            Document = document;
            ConnectionLink = link;
        }
        
    }
}
