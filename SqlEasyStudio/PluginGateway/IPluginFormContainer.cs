using System.Collections.Generic;
using System.Windows.Forms;
using Kbg.NppPluginNET.PluginInfrastructure;
using SqlEasyStudio.PluginGateway;

namespace SqlEasyStudio.PlaginGateway
{
    public interface IPluginFormContainer
    {
        Dictionary<string, IPluginForm> Forms { get; }

        void Register(string formName, Form form, string title, int index, NppTbMsg flags);
    }
}