using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Data.Core.Domain
{
    public class Book 
    {
        public int Id { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
        public int RoomId { get; set; }
        public Room Room { get; set; }
         public Room CurrentRoom { get; set; }
        public int GuestNumber { get; set; }
        public decimal RoomRate { get; set; }
        public decimal? TotalBill { get; set; }
        public bool FlCheckOut { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; } 
        public ICollection<GuestBook> Guests { get; set; }
        public ICollection<DayRoom> DayRooms { get; set; }
        
        public Book()
        {
            Guests = new Collection<GuestBook>();
            DayRooms = new Collection<DayRoom>();
        }

    }
}