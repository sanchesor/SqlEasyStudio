using SqlEasyStudio.Application.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlEasyStudio.Application.Models
{
    public class ObjectExplorerTreeNode
    {
        public ObjectExplorerNodeType NodeType { get; set; }
        public string Name { get; set; }
        public object Info { get; set; }
        public List<ObjectExplorerTreeNode> Nodes { get; set; }

        public ObjectExplorerTreeNode()
        {
            Nodes = new List<ObjectExplorerTreeNode>();
        }
    }
}
