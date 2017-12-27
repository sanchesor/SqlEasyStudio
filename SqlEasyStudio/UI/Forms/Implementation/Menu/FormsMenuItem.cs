using SqlEasyStudio.UI.Model;
using System.Windows.Forms;
using SqlEasyStudio.Infrastructure.Messaging;

namespace SqlEasyStudio.UI.Forms.Implementation
{
    public class FormsMenuItem : IMenuItem
    {
        public MenuItem SourceMenuItem;
        public ICommand Command { get; set; }
        public string Text { get { return SourceMenuItem.Text; } set { SourceMenuItem.Text = value; } }

        public FormsMenuItem(MenuItem menuItem)
        {
            SourceMenuItem = menuItem;
            SourceMenuItem.Tag = this;
        }
    }
}
