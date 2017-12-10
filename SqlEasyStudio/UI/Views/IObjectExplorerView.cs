using SqlEasyStudio.UI.Model;
using System;
using System.Collections.Generic;

namespace SqlEasyStudio.UI.Views
{
    public interface IObjectExplorerView
    {
        event EventHandler Loaded;
        event EventHandler TreeMouseClick;        

        ITreeNodeCollection<ITreeNode> Nodes { get; }        

    }
}
