using SqlEasyStudio.UI.Model;
using System;
using System.Collections.Generic;

namespace SqlEasyStudio.UI.Views
{
    public interface IObjectExplorerView
    {
        event EventHandler Loaded;        
        event EventHandler<NodeMouseClickArgs> NodeMouseClick;
        event EventHandler NodeAfterSelect;
        
        ITreeNode SelectedNode { get; set; }
        ITreeNodeCollection<ITreeNode> Nodes { get; }        

    }
}
