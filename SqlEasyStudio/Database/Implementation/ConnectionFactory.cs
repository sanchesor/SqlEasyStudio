using SqlEasyStudio.Application.Connections;
using SqlEasyStudio.Infrastructure.IoC.Attributes;
using System.Data.SqlClient;

namespace SqlEasyStudio.Database.Implementation
{
    [Component]
    public class ConnectionFactory : IConnectionFactory
    {
        public IConnection Create(string connectionString)
        {
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            return new Connection(sqlConnection);
        }
    }
}
