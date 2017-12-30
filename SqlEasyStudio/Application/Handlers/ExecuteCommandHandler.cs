using SqlEasyStudio.Application.Commands;
using SqlEasyStudio.Application.Connections;
using SqlEasyStudio.Application.QueryExecution;
using SqlEasyStudio.Infrastructure.IoC;
using SqlEasyStudio.Infrastructure.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlEasyStudio.Application.Handlers
{

    public class ExecuteCommandHandler : ICommandHandler<ExecuteCommand>
    {
        public void Handle(ExecuteCommand command)
        {
            var documentsController = ContainerDelivery.GetContainer().Resolve<IDocumentsController>();
            var currentDocument = documentsController.CurrentDocument;
            var connection = DocumentConnector.ConnectedDocuments[currentDocument].Connection;
            var query = currentDocument.SelectedText.Length > 0 ? currentDocument.SelectedText : currentDocument.Text;

            var queryExecutionFactory = ContainerDelivery.GetContainer().Resolve<IQueryExecutionFactory>();
            var queryExecution = queryExecutionFactory.Create();

            var resultsConsumer = ContainerDelivery.GetContainer().Resolve<IQueryExecutionResultsConsumer>();

            var results = queryExecution.Execute(connection, query);

            resultsConsumer.ConsumeResults(results, currentDocument);            
        }
    }
}
