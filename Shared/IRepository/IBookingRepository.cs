using Microsoft.EntityFrameworkCore.Query;
using Shared.Models;
using System.Linq.Expressions;
using X.PagedList;
using Data;

namespace Shared
{
    public interface IBookingRepository  : IGenericRepository<Booking>
    {
        Task<Booking> ReserveRoom(BookingRequestParams rq);
    }
}
