using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlEasyStudio.UI.Models
{
    public class UITreeNode
    {
        public NodeInfo NodeInfo { get; set; }
        public string Text { get; set; }
        public List<UITreeNode> Nodes { get; }

        public UITreeNode()
        {
            Nodes = new List<UITreeNode>();
        }
    }
}
