using SqlEasyStudio.UI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using System.Windows.Forms;
using SqlEasyStudio.Application.Models;

namespace SqlEasyStudio.UI.Forms.Implementation
{
    public class FormsTreeNodeCollection : ITreeNodeCollection<ITreeNode>
    {
        TreeNodeCollection nodes;

        public FormsTreeNodeCollection(TreeNodeCollection nodes)
        {
            this.nodes = nodes;
        }
        
        public int Count => nodes.Count;

        public bool IsReadOnly => nodes.IsReadOnly;

        public void Add(ITreeNode item)
        {
            Add(item, nodes);
        }

        public void Add(ITreeNode item, TreeNodeCollection sourceNodes)
        {
            TreeNode tn = new TreeNode() { Text = item.Text, Tag = item };
            foreach (ITreeNode n in item.Nodes)
            {
                Add(n, tn.Nodes);
            }
            sourceNodes.Add(tn);
        }

        public void Clear()
        {
            nodes.Clear();
        }

        public bool Contains(ITreeNode item)
        {
            return nodes.Cast<TreeNode>().Any(tn => tn.Tag == item);
        }

        public void CopyTo(ITreeNode[] array, int arrayIndex)
        {
            nodes.CopyTo(array, arrayIndex);
        }

        public IEnumerator<ITreeNode> GetEnumerator()
        {
            return nodes.Cast<TreeNode>().Select(tn => tn.Tag as FormsTreeNode).GetEnumerator();
        }

        public bool Remove(ITreeNode item)
        {
            TreeNode treeNode = nodes.Cast<TreeNode>().First(tn => tn.Tag == item);
            if(!nodes.Contains(treeNode))
                return false;

            nodes.Remove(treeNode);
            return true;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return nodes.GetEnumerator();
        }        
    }
}
