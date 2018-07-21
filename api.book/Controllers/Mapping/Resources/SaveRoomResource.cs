using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace book.api.Controllers.Mapping.Resources
{
    public class SaveRoomResource
    {
        public int Id { get; set; }
        [Required]
        public int DoorNumber { get; set; }
        [Required]
        public int FloorNumber { get; set; }
        public string RoomDescription { get; set; }
        [Required]
        public int RoomTypeId { get; set; }  
        [Required]    
        public int RoomStateId { get; set; } 
        public ICollection<RoomBedResource> Beds { get; set; }

        public SaveRoomResource()
        {
            Beds = new Collection<RoomBedResource>();
        }
    }
}