using SqlEasyStudio.UI.Model;
using System.Windows.Forms;
using SqlEasyStudio.Infrastructure.Messaging;
using SqlEasyStudio.Infrastructure.IoC;
using System;

namespace SqlEasyStudio.UI.Forms.Implementation
{
    public class FormsMenuItem : IMenuItem
    {
        public MenuItem SourceMenuItem;        
        public string Text { get { return SourceMenuItem.Text; } set { SourceMenuItem.Text = value; } }

        public Action CommandHandler { get; set; }

        public FormsMenuItem(MenuItem menuItem)
        {
            SourceMenuItem = menuItem;
            SourceMenuItem.Tag = this;
            SourceMenuItem.Click += SourceMenuItem_Click;
        }

        private void SourceMenuItem_Click(object sender, EventArgs e)
        {
            CommandHandler.Invoke();
        }
    }
}
