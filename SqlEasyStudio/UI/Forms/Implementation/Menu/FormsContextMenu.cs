using SqlEasyStudio.UI.Model;
using System.Windows.Forms;

namespace SqlEasyStudio.UI.Forms.Implementation
{
    public class FormsContextMenu : IContextMenu
    {
        public ContextMenu SourceContextMenu;
        FormsMenuItemCollection _menuItemCollection;

        public FormsContextMenu()
        {
            SourceContextMenu = new ContextMenu();
            _menuItemCollection = new FormsMenuItemCollection(SourceContextMenu.MenuItems);
        }

        public IMenuItemCollection<IMenuItem> MenuItems { get { return _menuItemCollection; } }

    }
}
