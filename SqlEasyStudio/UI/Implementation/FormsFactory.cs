using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SqlEasyStudio.UI.Forms;

namespace SqlEasyStudio.UI.Implementation
{
    public class FormsFactory : IFormsFactory
    {
        public Form Create(string name)
        {
            switch(name)
            {
                case "object_explorer": return new ObjectExplorerForm(); break;
            }

            throw new Exception("Unknown form name");
        }
    }
}
