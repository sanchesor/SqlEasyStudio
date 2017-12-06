using Kbg.NppPluginNET.PluginInfrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SqlEasyStudio.PluginGateway.PluginForm.Implementation
{
    public class PluginForm : IPluginForm
    {
        public string Name => internalForm.Name;

        public bool Visible { get { return internalForm.Visible; } }

        public void Hide()
        {
            Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_DMMHIDE, 0, internalForm.Handle);
        }

        public void Show()
        {
            Win32.SendMessage(PluginBase.nppData._nppHandle, (uint)NppMsg.NPPM_DMMSHOW, 0, internalForm.Handle);
        }

        public void ToggleVisible()
        {
            if (Visible)
                Hide();
            else
                Show();
        }

        private Form internalForm;

        public PluginForm(Form form)
        {
            internalForm = form;
        }
    }
}
