using SqlEasyStudio.UI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Windows.Forms;
using SqlEasyStudio.UI.Models;

namespace SqlEasyStudio.UI.Forms.Implementation
{
    public class UITreeNodeCollection : IUITreeNodeCollection<UITreeNode>
    {
        TreeNodeCollection nodes;

        public UITreeNodeCollection(TreeNodeCollection nodes)
        {
            this.nodes = nodes;
        }

        public int Count => nodes.Count;

        public bool IsReadOnly => nodes.IsReadOnly;

        public void Add(UITreeNode item)
        {
            nodes.Add(new TreeNode() {Text = item.Text, Tag = item});
        }

        public void Clear()
        {
            nodes.Clear();
        }

        public bool Contains(UITreeNode item)
        {
            return nodes.Cast<TreeNode>().Any(tn => tn.Tag == item);
        }

        public void CopyTo(UITreeNode[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<UITreeNode> GetEnumerator()
        {
            return nodes.Cast<TreeNode>().Select(tn => tn.Tag as UITreeNode).GetEnumerator();
        }

        public bool Remove(UITreeNode item)
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
