using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlEasyStudio.Application.Models
{
    public class ObjectExplorerTree
    {
        public List<ObjectExplorerTreeNode> Nodes { get; set; }
        public ObjectExplorerTree()
        {
            Nodes = new List<ObjectExplorerTreeNode>();
        }

    }
}
