using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlEasyStudio.UI.Model;
using System.Windows.Forms;

namespace SqlEasyStudio.UI.Forms.Implementation
{
    public class FormsMenuItem : IMenuItem
    {
        public MenuItem SourceMenuItem;
        public FormsMenuItem(MenuItem menuItem)
        {
            SourceMenuItem = menuItem;
            SourceMenuItem.Tag = this;
        }
        public string Name { get { return SourceMenuItem.Name; } set { SourceMenuItem.Name = value; SourceMenuItem.Text = value; } }

    }
}
