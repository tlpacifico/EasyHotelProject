using Data.Core.Domain;
using Data.Core.Repositories;

namespace Data.Persistence.Repositories
{
    public class RoomTypeRepository: Repository<RoomType>, IRoomTypeRepository
    {
        public RoomTypeRepository(EasyHotelDbContext context) : base(context)
        {
            
        }
        
    }
}