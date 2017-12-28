using SqlEasyStudio.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlEasyStudio.Application.Services
{
    public class ConnectionMapper
    {
        public static Dictionary<IDocument, ObjectExplorerItem> Connections => new Dictionary<IDocument, ObjectExplorerItem>();

        public static void Connect(IDocument document, ObjectExplorerItem connectionItem)
        {

        }
    }
}
