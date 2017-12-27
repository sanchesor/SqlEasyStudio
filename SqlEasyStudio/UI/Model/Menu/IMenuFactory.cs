using SqlEasyStudio.Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlEasyStudio.UI.Model
{
    public interface IMenuFactory
    {
        IMenuItem CreateMenuItem();
        IMenuItem CreateMenuItem(string text, Action commandHandler);
        IContextMenu CreateContextMenu();
    }
}
