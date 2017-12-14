using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlEasyStudio.UI.Model
{
    public interface ITreeNode
    {      
        string Text { get; set; }
        object Data { get; set; }
        ITreeNodeCollection<ITreeNode> Nodes { get; }
    }
}
