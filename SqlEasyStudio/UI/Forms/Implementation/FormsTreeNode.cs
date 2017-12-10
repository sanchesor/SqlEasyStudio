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
        TreeNode node;
        FormsTreeNodeCollection nodes;

        public FormsTreeNode(TreeNode node)
        {
            this.node = node;
            this.node.Tag = this;
            nodes = new FormsTreeNodeCollection(node.Nodes);

            NodeInfo = new NodeInfo();
        }

        public NodeInfo NodeInfo { get; set; }
        public string Text { get; set; }
        public ITreeNodeCollection<ITreeNode> Nodes => nodes;
    }
}
