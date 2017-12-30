using SqlEasyStudio.Application.QueryExecution;
using SqlEasyStudio.Infrastructure.IoC.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlEasyStudio.Database.Implementation
{
    [Component]
    public class QueryExecutionFactory : IQueryExecutionFactory
    {
        public IQueryExecution Create()
        {
            return new QueryExecution();
        }
    }
}
