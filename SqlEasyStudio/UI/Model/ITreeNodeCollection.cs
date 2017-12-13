using SqlEasyStudio.Application.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlEasyStudio.UI.Model
{
    public interface ITreeNodeCollection<T> : ICollection<T> where T : ITreeNode
    {        
    }
}
