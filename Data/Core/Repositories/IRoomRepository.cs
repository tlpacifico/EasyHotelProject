using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Core.Domain;
using Data.Infrastructure;
using Data.Infrastructure.Extensions;

namespace Data.Core.Repositories
{
    public interface IRoomRepository : IRepository<Room>
    {
        Task<Room> GetRoom(int id, bool includeRelated = true);
        Task<QueryResult<Room>> GetRooms(RoomQuery queryObj);
    }
}