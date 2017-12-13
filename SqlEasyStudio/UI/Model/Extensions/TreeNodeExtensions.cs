using SqlEasyStudio.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlEasyStudio.UI.Model.Extensions
{
    public static class TreeNodeExtensions
    {
        public static ITreeNode ToUITreeNode(this ObjectExplorerTreeNode node, ITreeNodeFactory factory)
        {
            ITreeNode uinode = factory.Create();
            uinode.Text = node.Name;
            foreach (var explorerNode in node.Nodes)
            {
                uinode.Nodes.Add(explorerNode.ToUITreeNode(factory));
            }

            return uinode;
        }
    }
}
