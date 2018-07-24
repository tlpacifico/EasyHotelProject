using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.Core;
using Data.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using book.api.Controllers.Mapping.Resources;
using Microsoft.AspNetCore.Cors;
using Data.Infrastructure;
using Data.Infrastructure.Extensions;

namespace book.api.Controllers
{
    
    [Route("/api/rooms")]
    public class RoomController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public RoomController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetRooms(RoomQuery query)
        {
            var rooms = await unitOfWork.Rooms.GetRooms(query);
            return Ok(mapper.Map<QueryResult<Room>, QueryResult<RoomResource>>(rooms));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom([FromBody] SaveRoomResource saveRoomResource)
        {
            if (!ModelState.IsValid || (saveRoomResource.Beds == null || saveRoomResource.Beds.Count() <= 0))
                return BadRequest(ModelState);

            var room = mapper.Map<SaveRoomResource, Room>(saveRoomResource);
            unitOfWork.Rooms.Add(room);

            await unitOfWork.CompleteAsync();
            var result = await unitOfWork.Rooms.GetRoom(room.Id);
            return Ok(mapper.Map<Room, RoomResource>(result));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(int id, [FromBody] SaveRoomResource saveRoomResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var room = await unitOfWork.Rooms.GetRoom(id);

            if (room == null)
                return NotFound();

            mapper.Map<SaveRoomResource, Room>(saveRoomResource, room);
            await unitOfWork.CompleteAsync();

            room = await unitOfWork.Rooms.GetRoom(room.Id);
            var result = mapper.Map<Room, RoomResource>(room);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoom(int id)
        {
            var room = await unitOfWork.Rooms.GetRoom(id);

            if (room == null)
                return NotFound();

            var roomResource = mapper.Map<Room, RoomResource>(room);

            return Ok(roomResource);
        }
    }


}