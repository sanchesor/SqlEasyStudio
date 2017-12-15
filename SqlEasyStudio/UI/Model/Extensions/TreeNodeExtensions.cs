using SqlEasyStudio.Domain;

namespace SqlEasyStudio.UI.Model.Extensions
{
    public static class TreeNodeExtensions
    {
        public static ITreeNode ToUITreeNode(this ObjectExplorerItem item, ITreeNodeFactory factory)
        {
            ITreeNode uinode = factory.Create();
            uinode.Text = item.Name;
            uinode.Data = item.Data;
            foreach (var explorerItem in item.Items)
            {
                uinode.Nodes.Add(explorerItem.ToUITreeNode(factory));
            }

            return uinode;
        }
    }
}
