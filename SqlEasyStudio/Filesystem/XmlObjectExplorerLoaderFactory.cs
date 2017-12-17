using SqlEasyStudio.Application.Interfaces;
using SqlEasyStudio.Infrastructure.IoC.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlEasyStudio.Filesystem
{
    [Component]
    public class XmlObjectExplorerLoaderFactory : IObjectExplorerLoaderFactory
    {
        private string sourceFile = @"C:\Users\pasawick\AppData\Roaming\Notepad++\plugins\Config\cons.xml";
        public IObjectExplorerLoader Create()
        {
            return new XmlObjectExplorerLoader(sourceFile);
        }
    }
}
