using SqlEasyStudio.Application.QueryExecution;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlEasyStudio.Database.Implementation
{
    public class QueryExecutionResult : IQueryExecutionResult
    {
        public DataTable Data { get; set; }
        public string Message { get; set; }

    }
}
