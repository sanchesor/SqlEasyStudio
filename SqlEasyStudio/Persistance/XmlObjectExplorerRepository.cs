using SqlEasyStudio.Domain.Repositories;
using SqlEasyStudio.Infrastructure.IoC.Attributes;
using System.Xml;
using SqlEasyStudio.Domain;
using SqlEasyStudio.Domain.Enums;
using System;
using SqlEasyStudio.Persistance.Exceptions;
using SqlEasyStudio.Domain.Factories;

namespace SqlEasyStudio.Persistance
{
    [Component]
    public class XmlObjectExplorerRepository : IObjectExplorerRepository
    {
        public string SourceFile { get; private set; }

        private ObjectExplorerItemFactory itemFactory;

        public XmlObjectExplorerRepository(string xmlFile)
        {
            SourceFile = xmlFile;
            itemFactory = new ObjectExplorerItemFactory();
        }

        public ObjectExplorerTree Load()
        {
            var tree = new ObjectExplorerTree();

            var connectionsItem = itemFactory.Create(ObjectExplorerItemType.Connections);
            connectionsItem.Name = "Connections";            

            tree.Items.Add(connectionsItem);

            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load(SourceFile);
            }
            catch(Exception e)
            {
                throw new InvalidConfigurationException(string.Format("Invalid configuration file: {0}.", SourceFile), e);
            }

            foreach (XmlNode n in doc.DocumentElement.GetElementsByTagName("connection"))
            {
                if (n.Attributes["name"].Value == null || n.Attributes["connectionstring"].Value == null)
                {
                    throw new InvalidConfigurationException(string.Format("Invalid configuration file: {0}.", SourceFile), null);
                }

                var connectionItem = itemFactory.Create(ObjectExplorerItemType.Connection) as ConnectionItem;
                connectionItem.Name = n.Attributes["name"].Value;
                connectionItem.ConnectionString = n.Attributes["connectionstring"].Value;
                connectionsItem.Items.Add(connectionItem);
            }

            return tree;
        }
    }
}
