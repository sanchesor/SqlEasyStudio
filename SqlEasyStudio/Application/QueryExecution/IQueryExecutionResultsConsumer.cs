namespace SqlEasyStudio.Application.QueryExecution
{
    public interface IQueryExecutionResultsConsumer
    {
        void ConsumeResults(IQueryExecutionResultCollection results, IDocument document);
    }
}
