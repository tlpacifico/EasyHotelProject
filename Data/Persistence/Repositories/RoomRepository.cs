using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Core.Domain;
using Data.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistence.Repositories
{
    public class RoomRepository : Repository<Room>, IRoomRepository
    {
        private readonly EasyHotelDbContext context;
        public RoomRepository(EasyHotelDbContext context) : base(context)
        {
            this.context = context;

        }

        public async Task<Room> GetRoom(int id, bool includeRelated = true)
        {
            if (!includeRelated)
                return await this.context.Rooms.FindAsync(id);

            return await context.Rooms
              .Include(rt => rt.RoomType)              
              .Include(rs => rs.RoomState)                       
              .Include(rb => rb.Beds)
                    .ThenInclude(b => b.Bed)             
              .SingleOrDefaultAsync(v => v.Id == id);
        }

         public async Task<IEnumerable<Room>> GetRooms(bool includeRelated = true)
        {
            if (!includeRelated)
                return await this.context.Rooms.ToListAsync();

            return await context.Rooms
              .Include(rt => rt.RoomType)              
              .Include(rs => rs.RoomState)
              .Include(b => b.CurrentBook)                    
                    .ThenInclude(b => b.Guests)
                        .ThenInclude(g => g.Guest)              
              .Include(rb => rb.Beds)            
                    .ThenInclude(b => b.Bed)
                    .ToListAsync();
        }

    }
}