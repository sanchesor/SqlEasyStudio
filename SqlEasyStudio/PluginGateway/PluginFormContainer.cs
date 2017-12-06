using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using Kbg.NppPluginNET.PluginInfrastructure;
using SqlEasyStudio.Infrastructure.Validation;
using SqlEasyStudio.PluginGateway.PluginForm;
using SqlEasyStudio.PluginGateway.PluginForm.Implementation;

namespace SqlEasyStudio.PlaginGateway
{
    public class PluginFormContainer
    {        
        public Dictionary<string, IPluginForm> Forms { get; private set; }

        public PluginFormContainer()
        {
            Forms = new Dictionary<string, IPluginForm>();
        }

        public void Register(string formName, Form form, string title, int index, NppTbMsg flags)
        {
            Validate.IsTrue(!Forms.ContainsKey(formName));

            NppTbData data = new NppTbData
            {
                hClient = form.Handle,
                pszName = title,
                uMask = flags,
                dlgID = index,
                pszModuleName = "Sql Easy Studio"
            };
            IntPtr hwnd = Marshal.AllocHGlobal(Marshal.SizeOf(data));
            Marshal.StructureToPtr(data, hwnd, false);

            Win32.SendMessage(PluginBase.nppData._nppHandle, (uint) NppMsg.NPPM_DMMREGASDCKDLG, 0, hwnd);

            Forms.Add(formName, new PluginForm(form));
        }


    }
}
