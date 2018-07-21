using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Core.Domain;
using Data.Persistence.Repositories;

namespace Data.Core.Repositories
{
    public interface IBookRepository : IRepository<Book>
    {
         Task<Book> GetBook(int id);
         Task<IEnumerable<Book>> GetBooks();
    }

    
}