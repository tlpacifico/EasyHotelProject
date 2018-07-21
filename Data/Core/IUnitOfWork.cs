using System;
using System.Threading.Tasks;
using Data.Core.Repositories;

namespace Data.Core
{
  public interface IUnitOfWork : IDisposable
  {
    IBedRepository Beds {get;}
    IRoomRepository Rooms {get;}
    IRoomStateRepository RoomStates {get;}
    IRoomTypeRepository RoomTypes {get;}
    IGuestRepository Guests {get;}
    IBookRepository Books {get;}
    Task CompleteAsync();
  }
}