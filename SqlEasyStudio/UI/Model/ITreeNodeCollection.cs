using System.Collections.Generic;

namespace SqlEasyStudio.UI.Model
{
    public interface ITreeNodeCollection<T> : ICollection<T> where T : ITreeNode
    {        
    }
}
