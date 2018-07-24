using System.Collections.Generic;

namespace Data.Infrastructure.Extensions
{
    public class QueryResult<T>
    {        
        public int TotalItems { get; set; }
        public IEnumerable<T> Items { get; set; }
    
    }
}