using System;

namespace book.api.Controllers.Mapping.Resources
{
    public class DayRoomResource
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int RoomId { get; set; }
        public int GuestsQty { get; set; }
        public DateTime DayRoomDate { get; set; }
        public decimal DayRoomPrice { get; set; }
        public bool PaymentFlag { get; set; }
        public RoomResource Room {get; set;}
    }
}