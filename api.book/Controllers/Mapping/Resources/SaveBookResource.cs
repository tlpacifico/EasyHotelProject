using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace book.api.Controllers.Mapping.Resources
{
    public class SaveBookResource
    {
       
     
        [StringLength(12)]
        public string CheckOut { get; set; }
        [Required]
        public int RoomId { get; set; }
        [Required]
        public int GuestNumber { get; set; }
        [Required]
        public decimal RoomRate { get; set; }
        public decimal? TotalBill { get; set; }
        public ICollection<int> Guests { get; set; }
        public ICollection<GuestResource> NewGuests { get; set; }


        public SaveBookResource()
        {
            Guests = new Collection<int>();
            NewGuests = new Collection<GuestResource>();           
        }
    }
}