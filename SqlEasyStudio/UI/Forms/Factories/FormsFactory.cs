using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SqlEasyStudio.UI.Forms;
using SqlEasyStudio.Infrastructure.IoC.Attributes;

namespace SqlEasyStudio.UI.Forms.Factories
{
    [Component]
    public class FormsFactory : IFormsFactory
    {
        public Form Create(string name)
        {
            switch(name)
            {
                case "object_explorer": return new ObjectExplorerForm();
                case "output": return new OutputDlg();
            }

            throw new Exception("Unknown form name");
        }
    }
}
