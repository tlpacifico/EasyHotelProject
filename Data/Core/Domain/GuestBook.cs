namespace Data.Core.Domain
{
    public class GuestBook
    {
        public int GuestId { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public Guest Guest { get; set; }
    }
}