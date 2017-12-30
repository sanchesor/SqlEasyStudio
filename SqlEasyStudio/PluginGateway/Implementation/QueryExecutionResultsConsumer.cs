using SqlEasyStudio.Application.QueryExecution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlEasyStudio.Application;
using SqlEasyStudio.Infrastructure.IoC.Attributes;
using SqlEasyStudio.Infrastructure.IoC;

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
            pluginFormProvider.FormContainer.Forms["output"].Show();
        }
    }
}
