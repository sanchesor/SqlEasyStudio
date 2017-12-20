using SqlEasyStudio.Domain.Repositories;
using SqlEasyStudio.Infrastructure.IoC.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlEasyStudio.Persistance
{
    [Component]
    public class XmlObjectExplorerRepositoryFactory : IObjectExplorerRepositoryFactory
    {
        private string sourceFile = @"C:\Users\pasawick\AppData\Roaming\Notepad++\plugins\Config\cons.xml";
        public IObjectExplorerRepository Create()
        {
            return new XmlObjectExplorerRepository(sourceFile);
        }
    }
}
