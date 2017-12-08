using SqlEasyStudio.UI.Model;
using SqlEasyStudio.UI.Models;
using System;
using System.Collections.Generic;

namespace SqlEasyStudio.UI.Views
{
    public interface IObjectExplorerView
    {
        event EventHandler Loaded;
        event EventHandler TreeMouseClick;        

        IUITreeNodeCollection<UITreeNode> Nodes { get; }
    }
}
