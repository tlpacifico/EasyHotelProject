using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace book.api.Controllers.Mapping.Resources
{
    public class RoomResource
    {
        public int Id { get; set; }
        public int DoorNumber { get; set; }
        public int FloorNumber { get; set; }
        public string RoomDescription { get; set; }      
        public KeyValuePairResource RoomType { get; set; }       
        public KeyValuePairResource RoomState { get; set; }
        public BookResource CurrentBook { get; set; }        
        public ICollection<RoomBedResource> Beds { get; set; }

        public RoomResource()
        {
            Beds = new Collection<RoomBedResource>();
            CurrentBook = new BookResource();
        }
    }
}