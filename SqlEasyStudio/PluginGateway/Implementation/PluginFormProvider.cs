using Kbg.NppPluginNET.PluginInfrastructure;
using SqlEasyStudio.Infrastructure.IoC;
using SqlEasyStudio.Infrastructure.IoC.Attributes;
using SqlEasyStudio.PlaginGateway;
using SqlEasyStudio.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlEasyStudio.PluginGateway.Implementation
{
    [Component]
    public class PluginFormProvider : IPluginFormProvider
    {
        private IFormsFactory formsFactory;
        private IPluginFormContainer pluginFormContainer;

        private Dictionary<string, int> formIndex = new Dictionary<string, int>()
        {
            { "object_explorer", 0 },
            { "output", 1 }
        };

        private Dictionary<string, NppTbMsg> formFlags = new Dictionary<string, NppTbMsg>()
        {
            { "object_explorer", NppTbMsg.DWS_DF_CONT_LEFT },
            { "output", NppTbMsg.DWS_DF_CONT_BOTTOM }
        };

        public IPluginFormContainer FormContainer => pluginFormContainer;

        public PluginFormProvider()
        {
            formsFactory = ContainerDelivery.GetContainer().Resolve<IFormsFactory>();
            pluginFormContainer = ContainerDelivery.GetContainer().Resolve<IPluginFormContainer>();
        }
        public void Show(string formName)
        {
            if (!pluginFormContainer.Forms.ContainsKey(formName))
                EnsureRegistered(formName);

            pluginFormContainer.Forms[formName].Show();
        }

        public void Hide(string formName)
        {
            if (!pluginFormContainer.Forms.ContainsKey(formName))
                EnsureRegistered(formName);

            pluginFormContainer.Forms[formName].Hide();
        }

        public void ToggleVisible(string formName)
        {
            if (!pluginFormContainer.Forms.ContainsKey(formName))
                EnsureRegistered(formName);
            else
                pluginFormContainer.Forms[formName].ToggleVisible();            
        }

        private void EnsureRegistered(string formName)
        {
            if (!pluginFormContainer.Forms.ContainsKey(formName))
            {
                Form form = formsFactory.Create(formName);
                pluginFormContainer.Register(formName, form, formName, formIndex[formName], formFlags[formName]);
            }
        }

    }
}
