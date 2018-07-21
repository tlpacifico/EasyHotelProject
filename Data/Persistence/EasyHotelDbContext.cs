using Data.Core.Domain;
using Microsoft.EntityFrameworkCore;


namespace Data.Persistence
{
    public class EasyHotelDbContext : DbContext
    {
        public DbSet<Guest> Guests { get; set; }
        public DbSet<GuestBook> GuestBooks { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<DayRoom> DayRoom { get; set; }
        public DbSet<Bed> Beds { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomState> RoomStates { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }


        public EasyHotelDbContext(DbContextOptions<EasyHotelDbContext> options)
          : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            //Accomodation   
            mb.Entity<Book>().Property(p => p.CheckIn).IsRequired();          
            mb.Entity<Book>().Property(p => p.RoomId).IsRequired();
            mb.Entity<Book>().Property(p => p.RoomRate).IsRequired();
            mb.Entity<Book>().Property(p => p.GuestNumber).IsRequired();
             mb.Entity<Book>().Property(p => p.FlCheckOut).IsRequired().HasDefaultValue(false);
            mb.Entity<Book>().HasOne(r => r.Room)
                             .WithMany(r=> r.Books)
                                      .HasForeignKey(b => b.RoomId);

            mb.Entity<Book>().HasMany(dr => dr.DayRooms)
                                      .WithOne(a => a.Book)
                                            .HasForeignKey(dr => dr.BookId)
                                            .OnDelete(DeleteBehavior.Restrict);

            //Bed
            mb.Entity<Bed>().Property(p => p.Description).IsRequired().HasMaxLength(30);

            //DayRoom
            mb.Entity<DayRoom>().Property(p => p.BookId).IsRequired();
            mb.Entity<DayRoom>().Property(p => p.RoomId).IsRequired();
            mb.Entity<DayRoom>().Property(p => p.GuestsQty).IsRequired();
            mb.Entity<DayRoom>().Property(p => p.DayRoomDate).IsRequired();
            mb.Entity<DayRoom>().Property(p => p.DayRoomPrice).IsRequired();
            mb.Entity<DayRoom>().Property(p => p.PaymentFlag).IsRequired();
            

          

            //Guest
            mb.Entity<Guest>().Property(p => p.Nome).HasMaxLength(120).IsRequired();
            mb.Entity<Guest>().Property(p => p.Cpf).HasMaxLength(11).IsRequired();
            mb.Entity<Guest>().Property(p => p.Uf).HasMaxLength(2).IsRequired();
            mb.Entity<Guest>().Property(p => p.Cidade).HasMaxLength(20).IsRequired();
            mb.Entity<Guest>().Property(p => p.Prefixo).HasMaxLength(10).IsRequired();
            mb.Entity<Guest>().Property(p => p.Logradouro).HasMaxLength(40).IsRequired();
            mb.Entity<Guest>().Property(p => p.Bairro).HasMaxLength(20).IsRequired();
            mb.Entity<Guest>().Property(p => p.Cep).HasMaxLength(8).IsRequired();
            mb.Entity<Guest>().Property(p => p.Fone).HasMaxLength(12).IsRequired();
            mb.Entity<Guest>().Property(p => p.Email).HasMaxLength(30);

            mb.Entity<GuestBook>().HasKey(ga => new { ga.BookId, ga.GuestId });

            //Room
            mb.Entity<Room>().Property(p => p.DoorNumber).IsRequired();
            mb.Entity<Room>().Property(p => p.RoomStateId).IsRequired();
            mb.Entity<Room>().Property(p => p.RoomTypeId).IsRequired();
            mb.Entity<Room>().Property(p => p.RoomDescription).IsRequired().HasMaxLength(120);
            mb.Entity<Room>().HasMany(a => a.Books)
                                      .WithOne(r => r.Room).HasForeignKey(x => x.RoomId);
            mb.Entity<Room>().HasOne(b => b.CurrentBook)
                              .WithOne(r=> r.CurrentRoom).HasForeignKey<Room>(q => q.CurrentBookId);;

            //RoomBeds
            mb.Entity<RoomBed>().HasKey(rb => new { rb.RoomId, rb.BedId });
            mb.Entity<RoomBed>().Property(rb => rb.NumberBeds).IsRequired();

            //RoomState
            mb.Entity<RoomState>().Property(p => p.State).IsRequired().HasMaxLength(30);

            //RoomType            
            mb.Entity<RoomType>().Property(p => p.Description).IsRequired().HasMaxLength(30);


        }
    }
}