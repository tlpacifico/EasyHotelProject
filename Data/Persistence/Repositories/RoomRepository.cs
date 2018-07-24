using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Data.Core.Domain;
using Data.Core.Repositories;
using Data.Infrastructure;
using Data.Infrastructure.Extensions;
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

        public async Task<QueryResult<Room>> GetRooms(RoomQuery queryObj)
        {
            var result = new QueryResult<Room>();

            var query = context.Rooms
             .Include(rt => rt.RoomType)
             .Include(rs => rs.RoomState)
             .Include(b => b.CurrentBook)
                   .ThenInclude(b => b.Guests)
                       .ThenInclude(g => g.Guest)
             .Include(rb => rb.Beds)
                   .ThenInclude(b => b.Bed)
                   .AsQueryable();

            if (queryObj.RoomTypeId.HasValue)
                query = query.Where(v => v.RoomType.Id == queryObj.RoomTypeId.Value);

            if (queryObj.RoomStateId.HasValue)
                query = query.Where(v => v.RoomState.Id == queryObj.RoomStateId.Value);

            if (queryObj.FloorNumber.HasValue)
                query = query.Where(v => v.FloorNumber == queryObj.FloorNumber.Value);

            var columnsMap = new Dictionary<string, Expression<Func<Room, object>>>()
            {
                ["roomType"] = v => v.RoomType.Id,
                ["roomState"] = v => v.RoomState.Id,
                ["floorNumber"] = v => v.FloorNumber,
                 ["doorNumber"] = v => v.DoorNumber

            };

            query = query.ApplyOrdering(queryObj, columnsMap);

            result.TotalItems = await query.CountAsync();

            query = query.ApplyPaging(queryObj);

            result.Items = await query.ToListAsync();

            return result;
        }

    }
}