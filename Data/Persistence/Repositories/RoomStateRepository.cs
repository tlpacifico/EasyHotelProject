using Data.Core.Domain;
using Data.Core.Repositories;

namespace Data.Persistence.Repositories
{
    public class RoomStateRepository : Repository<RoomState>, IRoomStateRepository
    {      
        public RoomStateRepository(EasyHotelDbContext context) : base(context) { 
        }
    }
}