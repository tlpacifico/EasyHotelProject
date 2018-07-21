using Data.Core.Domain;
using Data.Core.Repositories;

namespace Data.Persistence.Repositories
{
    public class GuestRepository: Repository<Guest>, IGuestRepository
    {
         public GuestRepository(EasyHotelDbContext context) 
            : base(context)
        {
        }
    
         
    }
}