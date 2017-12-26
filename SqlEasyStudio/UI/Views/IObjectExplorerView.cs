using SqlEasyStudio.UI.Model;
using System;
using System.Collections.Generic;

namespace SqlEasyStudio.UI.Views
{
    public interface IObjectExplorerView
    {
        event EventHandler Loaded;
        event EventHandler TreeMouseClick;
        event EventHandler<NodeMouseClickArgs> NodeMouseClick;        

        ITreeNodeCollection<ITreeNode> Nodes { get; }        

    }
}
