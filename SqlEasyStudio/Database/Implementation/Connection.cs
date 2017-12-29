using SqlEasyStudio.Application.Connections;
using SqlEasyStudio.Infrastructure.IoC.Attributes;
using System.Data.SqlClient;

namespace SqlEasyStudio.Database.Implementation
{
    [Component]
    public class Connection : IConnection
    {
        public SqlConnection SourceConnection { get; private set; }

        public Connection(SqlConnection conn)
        {
            SourceConnection = conn;
        }

        public void Open()
        {
            SourceConnection.Open();
        }

        public void Close()
        {
            SourceConnection.Close();
        }
    }
}
