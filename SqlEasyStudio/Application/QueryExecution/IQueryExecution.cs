using SqlEasyStudio.Application.Connections;

namespace SqlEasyStudio.Application.QueryExecution
{
    public interface IQueryExecution
    {
        IQueryExecutionResultCollection Execute(IConnection connection, string query);        
    }
}
