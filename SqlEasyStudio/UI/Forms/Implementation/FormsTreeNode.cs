using SqlEasyStudio.UI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlEasyStudio.UI.Forms.Implementation
{
    public class FormsTreeNode : ITreeNode
    {
        public TreeNode Node { get; }
        FormsTreeNodeCollection nodes;

        public FormsTreeNode(TreeNode node)
        {
            Node = node;
            Node.Tag = this;
            nodes = new FormsTreeNodeCollection(node.Nodes);
        }

        public string Text { get { return Node.Text; } set { Node.Text = value; } }
        public object Data { get; set; }

        public ITreeNodeCollection<ITreeNode> Nodes { get { return nodes; } }

        public bool Expanded
        {
            get { return Node.IsExpanded; }
            set
            {
                if (value)
                    Node.Expand();
                else
                    Node.Collapse();
            }
        }

    }
}
