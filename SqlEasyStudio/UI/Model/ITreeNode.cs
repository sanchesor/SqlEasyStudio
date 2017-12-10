using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlEasyStudio.UI.Model
{
    public interface ITreeNode
    {
        NodeInfo NodeInfo { get; set; }
        string Text { get; set; }
        ITreeNodeCollection<ITreeNode> Nodes { get; }
    }
}
