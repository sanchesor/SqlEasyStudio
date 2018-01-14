using SqlEasyStudio.Application.Connections;

namespace SqlEasyStudio.Application.QueryExecution
{
    public interface IQueryExecutor
    {
        IQueryExecutionResultCollection Execute(IConnection connection, string query);        
    }
}
