using System;

namespace Data.Core.Domain
{
    public class DayRoom
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int RoomId { get; set; }
        public int GuestsQty { get; set; }
        public DateTime DayRoomDate { get; set; }
        public decimal DayRoomPrice { get; set; }
        public bool PaymentFlag { get; set; }
        public Book Book { get; set; }
        public Room Room { get; set; }
    }
}