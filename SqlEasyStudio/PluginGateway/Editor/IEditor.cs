using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlEasyStudio.PluginEntryPoint.Editor
{
    public interface IEditor
    {
        IDocument CurrentDocument { get; }
    }
}
