using Data;

namespace Shared
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HotelDBContext _context;
        private IGenericRepository<Hotel> _hotels;
        private IBookingRepository _bookings;
        private IGenericRepository<Rooms> _rooms;
        private IGenericRepository<User> _users;

        private IGenericRepository<RoomTypeVariant> _roomTypeVariant;

        public UnitOfWork(HotelDBContext context)
        {
            _context = context;
        }
       public IGenericRepository<Hotel> Hotels => _hotels ??= new GenericRepository<Hotel>(_context);
        public IGenericRepository<User> Users => _users ??= new GenericRepository<User>(_context);
        public IGenericRepository<RoomTypeVariant> RoomTypeVariant => _roomTypeVariant ??= new GenericRepository<RoomTypeVariant>(_context);
         public IGenericRepository<Rooms> Rooms => _rooms ??= new GenericRepository<Rooms>(_context);

        public IBookingRepository Bookings => _bookings ??= new BookingRepository(_context);

        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }
    }
}
