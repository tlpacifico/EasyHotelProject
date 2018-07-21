using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.Core;
using Data.Core.Domain;
using Microsoft.AspNetCore.Mvc;
using book.api.Controllers.Mapping.Resources;
using Microsoft.AspNetCore.Cors;
using Data.Enum;

namespace book.api.Controllers
{
    
    [Route("/api/books")]
    public class BookController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public BookController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.mapper = mapper;
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            var books = await unitOfWork.Books.GetBooks();
            return Ok(mapper.Map<IEnumerable<Book>, IEnumerable<BookResource>>(books));
        }

        [HttpGet("{idBook}")]
        public async Task<IActionResult> GetBook(int idBook)
        {
            var book = await unitOfWork.Books.GetBook(idBook);
            return Ok(mapper.Map<Book, BookResource>(book));
        }

       
        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] SaveBookResource bookResource)
        {
            if (!ModelState.IsValid && 
                    ( bookResource.Guests.Count <= 0|| bookResource.NewGuests.Count <=0))
                return BadRequest(ModelState);

          
            if (bookResource.NewGuests != null && bookResource.NewGuests.Count > 0)
            {
                var newGuest = mapper.Map<IEnumerable<GuestResource>, IEnumerable<Guest>>(bookResource.NewGuests);
                unitOfWork.Guests.AddRange(newGuest);

                foreach (var item in newGuest)
                {
                    bookResource.Guests.Add(item.Id);
                }
            }

            var book = mapper.Map<SaveBookResource, Book>(bookResource);
          

            book.DayRooms.Add(new DayRoom
            {
                RoomId = book.RoomId,
                GuestsQty = book.GuestNumber,
                DayRoomDate = book.CheckIn,
                DayRoomPrice = book.RoomRate,
                PaymentFlag = false
            });
            unitOfWork.Books.Add(book);
            
            var room = await unitOfWork.Rooms.Get(book.RoomId);
            room.CurrentBookId = book.Id;
            room.RoomStateId = (int)RoomStateEnum.Occupied;

            await unitOfWork.CompleteAsync();
            var result = await unitOfWork.Books.GetBook(book.Id);
            return Ok(mapper.Map<Book, BookResource>(result));
        }

        [HttpGet("{bookId}/dayroom")]
        public async Task<IActionResult> CreateDayRoom(int bookId)
        {
            var book = await unitOfWork.Books.GetBook(bookId);
            if (book == null)
                return NotFound();

            var lastDayRoom = book.DayRooms
                            .Where(dr => dr.DayRoomDate == (book.DayRooms
                                                        .Select(x => x.DayRoomDate).Max())).SingleOrDefault();

            var newDayRoom = new DayRoom()
            {
                BookId = book.Id,
                RoomId = book.RoomId,
                GuestsQty = book.GuestNumber,
                DayRoomDate = lastDayRoom.DayRoomDate.AddDays(1),
                DayRoomPrice = book.RoomRate,
                PaymentFlag = false
            };

            book.DayRooms.Add(newDayRoom);
            Room room = await unitOfWork.Rooms.Get(book.RoomId);
            room.RoomStateId = 2;
            await unitOfWork.CompleteAsync();
            return Ok(mapper.Map<Book, BookResource>(book));
        }
    }
}