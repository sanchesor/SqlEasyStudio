using SqlEasyStudio.Domain;
using System;

namespace SqlEasyStudio.UI.Model.Extensions
{
    public static class TreeNodeExtensions
    {
        public static ITreeNode ToUITreeNode(this ObjectExplorerItem item, ITreeNodeFactory factory, Action<ITreeNode, ObjectExplorerItem> action)
        {
            ITreeNode uinode = factory.Create();
            uinode.Text = item.Name;
            uinode.Data = item;
            action?.Invoke(uinode, item);
            foreach (var explorerItem in item.Items)
            {
                uinode.Nodes.Add(explorerItem.ToUITreeNode(factory, action));
            }

            return uinode;
        }
    }
}
