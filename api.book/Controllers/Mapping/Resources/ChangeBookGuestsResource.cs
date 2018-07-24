using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace book.api.Controllers.Mapping.Resources
{
    public class ChangeBookGuestsResource
    {
        public ICollection<int> Guests { get; set; }
        public ICollection<GuestResource> NewGuests { get; set; }


        public ChangeBookGuestsResource()
        {
            Guests = new Collection<int>();
            NewGuests = new Collection<GuestResource>();           
        }
    }
}