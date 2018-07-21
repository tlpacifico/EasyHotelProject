using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Data.Core;
using Data.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using book.api.Controllers.Mapping.Resources;

namespace book.api.Controllers
{
    [Route("/api/config")]
    public class ConfigController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public ConfigController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        [Route("beds")]
        [HttpGet]
        public async Task<IActionResult> GetBeds()
        {
            var beds = await unitOfWork.Beds.GetAll();
            return Ok(mapper.Map<IEnumerable<Bed>,IEnumerable<KeyValuePairResource>>(beds));
        }

        [Route("roomtypes")]
        [HttpGet]
        public async Task<IActionResult> GetRoomTypes()
        {
            var roomTypes = await unitOfWork.RoomTypes.GetAll();
            return Ok(mapper.Map<IEnumerable<RoomType>,IEnumerable<KeyValuePairResource>>(roomTypes));
        }

        [Route("roomstates")]
        [HttpGet]
        public async Task<IActionResult> GetRoomStates()
        {
            var roomStates = await unitOfWork.RoomStates.GetAll();
            return Ok(mapper.Map<IEnumerable<RoomState>,IEnumerable<KeyValuePairResource>>(roomStates));
        }
    }
}