using SqlEasyStudio.Domain.Repositories;
using SqlEasyStudio.Infrastructure.IoC.Attributes;
using System.Xml;
using SqlEasyStudio.Domain;
using SqlEasyStudio.Domain.Enums;
using System;
using SqlEasyStudio.Persistance.Exceptions;

namespace SqlEasyStudio.Persistance
{
    [Component]
    public class XmlObjectExplorerRepository : IObjectExplorerRepository
    {
        public string SourceFile { get; private set; }

        public XmlObjectExplorerRepository(string xmlFile)
        {
            SourceFile = xmlFile;
        }

        public ObjectExplorerTree Load()
        {
            var tree = new ObjectExplorerTree();

            var connectionsItem = new ObjectExplorerItem() { Name = "Connections", ItemType = ObjectExplorerItemType.Folder };
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

                connectionsItem.Items.Add(
                    new ObjectExplorerItem()
                    {
                        Name = n.Attributes["name"].Value,
                        ItemType = ObjectExplorerItemType.Connection,
                        Data = n.Attributes["connectionstring"].Value
                    });                                        
            }

            return tree;
        }
    }
}
