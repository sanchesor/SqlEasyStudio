using SqlEasyStudio.Domain.Repositories;
using SqlEasyStudio.Infrastructure.IoC.Attributes;
using SqlEasyStudio.PluginGateway;

namespace SqlEasyStudio.Persistance
{
    [Component]
    public class XmlObjectExplorerRepositoryFactory : IObjectExplorerRepositoryFactory
    {
        private string sourceFile = PluginEnvironment.ConfigDir + "\\cons.xml";
        public IObjectExplorerRepository Create()
        {
            return new XmlObjectExplorerRepository(sourceFile);
        }
    }
}
