using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Core.Domain;

namespace Data.Core.Repositories
{
    public interface IRoomRepository : IRepository<Room>
    {
        Task<Room> GetRoom(int id, bool includeRelated = true);
        Task<IEnumerable<Room>> GetRooms(bool includeRelated = true);
    }
}