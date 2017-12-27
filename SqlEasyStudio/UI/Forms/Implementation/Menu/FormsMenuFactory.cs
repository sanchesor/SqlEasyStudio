using SqlEasyStudio.Infrastructure.IoC.Attributes;
using SqlEasyStudio.UI.Model;
using System.Windows.Forms;
using SqlEasyStudio.Infrastructure.Messaging;

namespace SqlEasyStudio.UI.Forms.Implementation
{
    [Component]
    public class FormsMenuFactory : IMenuFactory
    {
        public IMenuItem CreateMenuItem()
        {
            return new FormsMenuItem(new MenuItem());
        }
        public IMenuItem CreateMenuItem(string text, ICommand command)
        {
            return new FormsMenuItem(new MenuItem()) { Text = text, Command = command };
        }

        public IContextMenu CreateContextMenu()
        {
            return new FormsContextMenu();
        }

    }
}
