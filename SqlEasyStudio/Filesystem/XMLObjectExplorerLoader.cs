using SqlEasyStudio.Application.Interfaces;
using System;
using SqlEasyStudio.Application.Models;
using SqlEasyStudio.Infrastructure.IoC.Attributes;
using System.Xml;
using SqlEasyStudio.Application.Models.Enums;

namespace SqlEasyStudio.Filesystem
{
    [Component]
    class XMLObjectExplorerLoader : IObjectExplorerLoader
    {
        public ObjectExplorerTree Load()
        {
            var tree = new ObjectExplorerTree();

            var connectionsItem = new ObjectExplorerItem() { Name = "Connections", ItemType = ObjectExplorerItemType.Folder };
            tree.Items.Add(connectionsItem);

            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Users\pasawick\AppData\Roaming\Notepad++\plugins\Config\cons.xml");
            foreach (XmlNode n in doc.DocumentElement.GetElementsByTagName("connection"))
            {
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
