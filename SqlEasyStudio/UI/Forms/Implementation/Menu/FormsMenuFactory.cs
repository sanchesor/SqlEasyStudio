using SqlEasyStudio.Infrastructure.IoC.Attributes;
using SqlEasyStudio.UI.Model;
using System.Windows.Forms;
using SqlEasyStudio.Infrastructure.Messaging;
using System;

namespace SqlEasyStudio.UI.Forms.Implementation
{
    [Component]
    public class FormsMenuFactory : IMenuFactory
    {
        public IMenuItem CreateMenuItem()
        {
            return new FormsMenuItem(new MenuItem());
        }
        public IMenuItem CreateMenuItem(string text, Action commandHandler)
        {
            return new FormsMenuItem(new MenuItem()) { Text = text, CommandHandler = commandHandler };
        }

        public IContextMenu CreateContextMenu()
        {
            return new FormsContextMenu();
        }

    }
}
