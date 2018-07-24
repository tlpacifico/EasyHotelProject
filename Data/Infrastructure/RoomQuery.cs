using Data.Infrastructure.Extensions;

namespace Data.Infrastructure
{
    public class RoomQuery: IQueryObject
    {        
        public int? FloorNumber { get; set; }
        public int? RoomTypeId { get; set; }
         public int? RoomStateId { get; set; }
         public int? DoorNumber { get; set; }
        public string SortBy { get; set; }
        public bool IsSortAscending { get; set; }
        public int Page { get; set; }
        public byte PageSize { get; set; }
    }
}