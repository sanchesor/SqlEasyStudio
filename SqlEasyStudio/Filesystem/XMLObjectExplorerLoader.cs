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
                var node = new ObjectExplorerTreeNode() { Name = n.Attributes["name"].Value };
                node.Nodes.Add(new ObjectExplorerTreeNode() { Name = "test" });

                tree.Nodes.Add(node);
                //cons.Add(new ConnectionInfo() { Name = n.Attributes["name"].Value, ConnectionString = n.Attributes["connectionstring"].Value });
            }
            tree.Nodes[0].Nodes[0].Nodes.Add(new ObjectExplorerTreeNode() { Name = "One more" });
            tree.Nodes[0].Nodes[0].Nodes.Add(new ObjectExplorerTreeNode() { Name = "two more" });

            return tree;
        }
    }
}
