using SqlEasyStudio.Application.Commands;
using SqlEasyStudio.Application.Connections;
using SqlEasyStudio.Application.QueryExecution;
using SqlEasyStudio.Infrastructure.IoC;
using SqlEasyStudio.Infrastructure.IoC.Container;
using SqlEasyStudio.Infrastructure.Messaging;

namespace SqlEasyStudio.Application.Handlers
{

    public class ExecuteCommandHandler : ICommandHandler<ExecuteCommand>
    {
        IContainer container;
        IDocumentConnector documentConnector;

        public ExecuteCommandHandler()
        {
            container = ContainerDelivery.GetContainer();
            documentConnector = container.Resolve<IDocumentConnector>();
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
            return documentConnector.ConnectedDocuments[document].Connection;
        }
    }
}
