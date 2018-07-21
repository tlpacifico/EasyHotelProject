using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Data.Core.Domain
{
    public class Room
    {
        public int Id { get; set; }
        public int DoorNumber { get; set; }
        public int FloorNumber { get; set; }
        public string RoomDescription { get; set; }
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; }
        public int RoomStateId { get; set; }
        public RoomState RoomState { get; set; }
        public int? CurrentBookId { get; set; }
        public Book CurrentBook { get; set; }
        public ICollection<Book> Books { get; set; }
        public ICollection<RoomBed> Beds { get; set; }

        public Room()
        {
            Beds = new Collection<RoomBed>();
            Books = new Collection<Book>();
        }
    }
}