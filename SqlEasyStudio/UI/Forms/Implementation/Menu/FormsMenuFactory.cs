using SqlEasyStudio.Infrastructure.IoC.Attributes;
using SqlEasyStudio.UI.Model;
using System.Windows.Forms;

namespace SqlEasyStudio.UI.Forms.Implementation
{
    [Component]
    public class FormsMenuFactory : IMenuFactory
    {
        public IMenuItem CreateMenuItem()
        {
            return new FormsMenuItem(new MenuItem());
        }
        public IContextMenu CreateContextMenu()
        {
            return new FormsContextMenu();
        }
    }
}
