using SqlEasyStudio.Application.Connections;
using SqlEasyStudio.Application.QueryExecution;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace SqlEasyStudio.Database.Implementation
{
    public class QueryExecution : IQueryExecution
    {
        public IQueryExecutionResultCollection Execute(IConnection connection, string query)
        {
            QueryExecutionResultCollection resultCollection = new QueryExecutionResultCollection();

            Connection conn = connection as Connection;
            using (SqlConnection sqlConnection = conn.SourceConnection)
            {
                if(sqlConnection.State != ConnectionState.Open)
                    sqlConnection.Open();

                resultCollection = ExecuteQuery(sqlConnection, query);
            }

            return resultCollection;
        }

        private QueryExecutionResultCollection ExecuteQuery(SqlConnection conn, string query)
        {
            QueryExecutionResultCollection resultCollection = new QueryExecutionResultCollection();

            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.HasRows)
                    {
                        resultCollection.ResultList.Add(new QueryExecutionResult() { Data = ReadDataTable(reader) });
                        reader.NextResult();
                    }
                }
            }
            return resultCollection;
        }

        private DataTable ReadDataTable(SqlDataReader reader)
        {

            DataTable dt = new DataTable();
            foreach (DataRow col in reader.GetSchemaTable().Rows)
            {
                dt.Columns.Add(col[0].ToString());
            }

            while (reader.Read())
            {
                DataRow row = dt.NewRow();
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    row[i] = reader.GetValue(i);
                }
                dt.Rows.Add(row);
            }

            return dt;
        }
    }
}
