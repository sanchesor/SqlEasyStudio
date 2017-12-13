using SqlEasyStudio.Infrastructure.IoC.Attributes;
using SqlEasyStudio.UI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlEasyStudio.UI.Forms.Implementation
{
    [Component]
    public class FormsTreeNodeFactory : ITreeNodeFactory
    {
        public ITreeNode Create()
        {
            return new FormsTreeNode(new TreeNode());
        }
    }
}
