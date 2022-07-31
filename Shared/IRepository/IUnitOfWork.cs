using Data;

namespace Shared
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Hotel> Hotels { get; }
        IBookingRepository Bookings{ get; }
        Task Save();
    }
}
