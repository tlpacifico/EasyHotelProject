using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Data.Core;
using Data.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using book.api.Controllers.Mapping.Resources;

namespace book.api.Controllers
{
    [Route("/api/guests")]
    public class GuestController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public GuestController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetGuests()
        {
            var guests = await unitOfWork.Guests.GetAll();
            return Ok(mapper.Map<IEnumerable<Guest>,IEnumerable<GuestResource>>(guests));
        }

         [HttpGet("{cpf}")]
        public async Task<IActionResult> GetGuest(string cpf)
        {
            var guest = await unitOfWork.Guests.SingleOrDefault(g => g.Cpf == cpf);
            return Ok(mapper.Map<Guest,GuestResource>(guest));
        }
       
        [HttpPost]
        public async Task<IActionResult> CreateGuest([FromBody] GuestResource guestRoomResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var guest = mapper.Map<GuestResource, Guest>(guestRoomResource);
            unitOfWork.Guests.Add(guest);

            await unitOfWork.CompleteAsync();
            var result = await unitOfWork.Guests.Get(guest.Id);
            return Ok(mapper.Map<Guest, GuestResource>(result));
        }
    }
}