using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlEasyStudio.PluginGateway.PluginForm
{
    public interface IPluginForm
    {
        string Name { get; }

        bool Visible { get; }

        void Show();
        void Hide();
        void ToggleVisible();
    }
}
