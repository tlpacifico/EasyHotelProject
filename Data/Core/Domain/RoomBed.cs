using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Core.Domain
{
    [Table("RoomBeds")]
    public class RoomBed
    {
        public int RoomId { get; set; }
        public int BedId { get; set; }
        public int NumberBeds { get; set; }
        public Room Room  { get; set; }
        public Bed Bed { get; set; }
    }
}