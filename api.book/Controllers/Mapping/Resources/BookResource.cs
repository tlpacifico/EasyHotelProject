using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace book.api.Controllers.Mapping.Resources
{
    public class BookResource
    {
        public int Id { get; set; }
      
        public DateTime CheckIn { get; set; }
     
        public DateTime? CheckOut { get; set; }
        [Required]
        public RoomResource Room { get; set; }
        [Required]
        public int GuestNumber { get; set; }
        [Required]
        public decimal RoomRate { get; set; }
        public decimal? TotalBill { get; set; }
        public ICollection<GuestResource> Guests { get; set; }

        public ICollection<DayRoomResource> DayRooms { get; set; }
        public BookResource()
        {
            Guests = new Collection<GuestResource>();
            DayRooms = new Collection<DayRoomResource>();
            
           
        }
    }
}