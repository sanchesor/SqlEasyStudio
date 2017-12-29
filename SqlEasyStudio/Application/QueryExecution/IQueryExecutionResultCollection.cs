using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SqlEasyStudio.Application.QueryExecution
{
    public interface IQueryExecutionResultCollection
    {
        IEnumerable<IQueryExecutionResult> Results { get; }
    }
}
