using SqlEasyStudio.Application.Interfaces;
using System;
using SqlEasyStudio.Application.Models;
using SqlEasyStudio.Infrastructure.IoC.Attributes;
using System.Xml;

namespace SqlEasyStudio.Filesystem
{
    [Component]
    class XMLObjectExplorerLoader : IObjectExplorerLoader
    {
        public ObjectExplorerTree Load()
        {
            var tree = new ObjectExplorerTree();

            XmlDocument doc = new XmlDocument();
            doc.Load(@"C:\Users\pasawick\AppData\Roaming\Notepad++\plugins\Config\cons.xml");
            foreach (XmlNode n in doc.DocumentElement.GetElementsByTagName("connection"))
            {
                tree.Nodes.Add(new ObjectExplorerTreeNode() { Name = n.Attributes["name"].Value });
                //cons.Add(new ConnectionInfo() { Name = n.Attributes["name"].Value, ConnectionString = n.Attributes["connectionstring"].Value });
            }

            return tree;
        }
    }
}
