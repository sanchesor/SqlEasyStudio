using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlEasyStudio.UI.Model
{
    public interface IContextMenu
    {
        IMenuItemCollection<IMenuItem> MenuItems { get; }
    }
}
