using SqlEasyStudio.Application.QueryExecution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlEasyStudio.Application;
using SqlEasyStudio.Infrastructure.IoC.Attributes;
using SqlEasyStudio.Infrastructure.IoC;
using SqlEasyStudio.UI.Forms;
using SqlEasyStudio.Database.Implementation;

namespace SqlEasyStudio.PluginGateway.Implementation
{
    [Component]
    public class QueryExecutionResultsConsumer : IQueryExecutionResultsConsumer
    {
        private IPluginFormProvider pluginFormProvider;

        public QueryExecutionResultsConsumer()
        {
            pluginFormProvider = ContainerDelivery.GetContainer().Resolve<IPluginFormProvider>();
        }
        public void ConsumeResults(IQueryExecutionResultCollection results, IDocument document)
        {            
            pluginFormProvider.Show("output");

            PluginForm f = pluginFormProvider.FormContainer.Forms["output"] as PluginForm;
            OutputDlg dlg = (f.InternalForm as OutputDlg);
            foreach(var res in (results as QueryExecutionResultCollection).ResultList)
            {
                if (res.Data != null)
                    dlg.AddDataGrid(res.Data);
                else
                    dlg.AddMessage(res.Message);
            }
            
        }
    }
}
