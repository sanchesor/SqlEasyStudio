using SqlEasyStudio.Interfaces.Models;
using System;
using System.Collections.Generic;

namespace SqlEasyStudio.Interfaces.Views
{
    public interface IObjectExplorerView
    {
        event EventHandler Loaded;
        event EventHandler TreeMouseClick;

        ICollection<TreeNode> Nodes { get; }
    }
}
