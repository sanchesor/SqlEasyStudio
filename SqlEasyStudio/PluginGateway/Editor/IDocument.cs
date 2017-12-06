using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlEasyStudio.PluginEntryPoint.Editor
{
    public interface IDocument
    {
        string Text { get;}
        string SelectedText { get; }
    }
}
