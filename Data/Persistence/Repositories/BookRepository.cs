using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Data.Core.Domain;
using Data.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistence.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(EasyHotelDbContext context)
           : base(context)
        {
        }

        public async Task<IEnumerable<Book>> GetBooks()
        {

            return await Context.Books
                        .Include(r => r.Room)
                            .ThenInclude(rt => rt.RoomType)
                        .Include(r => r.Room)
                            .ThenInclude(rs => rs.RoomState)          
                        .Include(r => r.Room)
                            .ThenInclude(rb => rb.Beds)
                                .ThenInclude(b => b.Bed)
                        .Include(gb => gb.Guests)
                        .ThenInclude(g => g.Guest)
                        .ToListAsync();
        }

        public async Task<Book> GetBook(int id)
        {

            return await Context.Books
                       .Include(r => r.Room)
                            .ThenInclude(rt => rt.RoomType)
                        .Include(r => r.Room)
                            .ThenInclude(rs => rs.RoomState)          
                        .Include(r => r.Room)
                            .ThenInclude(rb => rb.Beds)
                                .ThenInclude(b => b.Bed)
                        .Include(gb => gb.Guests)
                        .ThenInclude(g => g.Guest)
                        .Include(dr => dr.DayRooms)
                        .SingleOrDefaultAsync(v => v.Id == id);
        }
    }
}