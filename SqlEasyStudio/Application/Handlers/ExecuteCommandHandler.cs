using SqlEasyStudio.Application.Commands;
using SqlEasyStudio.Application.Connections;
using SqlEasyStudio.Application.QueryExecution;
using SqlEasyStudio.Infrastructure.IoC;
using SqlEasyStudio.Infrastructure.IoC.Container;
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
        IContainer container;

        public ExecuteCommandHandler()
        {
            container = ContainerDelivery.GetContainer();
        }

        public void Handle(ExecuteCommand command)
        {
            var currentDocument = GetCurrentDocument();            
            var connection = GetDocumentConnection(currentDocument);
            var query = GetDocumentTextForExecution(currentDocument);
                        
            var results = GetQueryExecutor().Execute(connection, query);

            var resultsConsumer = container.Resolve<IQueryExecutionResultsConsumer>();
            resultsConsumer.ConsumeResults(results, currentDocument);            
        }

        private IDocument GetCurrentDocument()
        {
            var documentsController = container.Resolve<IDocumentsController>();
            return documentsController.CurrentDocument;
        }

        private IQueryExecutor GetQueryExecutor()
        {
            var queryExecutionFactory = container.Resolve<IQueryExecutionFactory>();
            return queryExecutionFactory.Create();
        }

        private string GetDocumentTextForExecution(IDocument document)
        {
            return document.SelectedText.Length > 0 ? document.SelectedText : document.Text;
        }

        private IConnection GetDocumentConnection(IDocument document)
        {
            return DocumentConnector.ConnectedDocuments[document].Connection;
        }
    }
}
