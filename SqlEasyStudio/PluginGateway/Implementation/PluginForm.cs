using Kbg.NppPluginNET.PluginInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SqlEasyStudio.PluginGateway.Implementation
{
    public class PluginForm : IPluginForm
    {
        public string Name => InternalForm.Name;

        public bool Visible { get { return InternalForm.Visible; } }

        public void Hide()
        {
            Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_DMMHIDE, 0, InternalForm.Handle);
        }

        public void Show()
        {
            Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_DMMSHOW, 0, InternalForm.Handle);
        }

        public void ToggleVisible()
        {
            if (Visible)
                Hide();
            else
                Show();
        }

        public Form InternalForm { get; private set; }

        public PluginForm(Form form)
        {
            InternalForm = form;
        }
    }
}
