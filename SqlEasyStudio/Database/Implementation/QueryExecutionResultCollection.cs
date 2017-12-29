using SqlEasyStudio.Application.QueryExecution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlEasyStudio.Database.Implementation
{
    public class QueryExecutionResultCollection : IQueryExecutionResultCollection
    {
        public List<QueryExecutionResult> ResultList { get; set; }
        public IEnumerable<IQueryExecutionResult> Results { get => ResultList; }
    }
}
