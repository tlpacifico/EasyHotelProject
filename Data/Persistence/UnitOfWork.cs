using System.Threading.Tasks;
using Data.Core;
using Data.Core.Repositories;
using Data.Persistence.Repositories;

namespace Data.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EasyHotelDbContext context;

        public UnitOfWork(EasyHotelDbContext context)
        {
            this.context = context;
            Beds = new BedRepository(context);
            Rooms = new RoomRepository(context);
            RoomStates = new RoomStateRepository(context);
            RoomTypes = new RoomTypeRepository(context);
            Guests = new GuestRepository(context);
            Books = new BookRepository(context);
        }
        public IBedRepository Beds { get; private set; }
        public IRoomRepository Rooms { get; private set; }
        public IRoomStateRepository RoomStates { get; private set; }
        public IRoomTypeRepository RoomTypes { get; private set; }
        public IGuestRepository Guests { get; private set; }

        public IBookRepository Books { get; private set; }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }
    }
}