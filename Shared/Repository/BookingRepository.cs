using Data;
using Microsoft.EntityFrameworkCore;
using Shared.Models;

namespace Shared
{
    public class BookingRepository : GenericRepository<Booking>,IBookingRepository
    {
        public BookingRepository(HotelDBContext context) : base(context)
        {
        }

        public async Task<Booking> ReserveRoom(BookingRequestParams rq)
        {
            Booking currentBooking = null;
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var hotelToBook = await _context.Hotels.Include(x => x.Rooms).FirstOrDefaultAsync(y => y.Id == rq.HotelId);
                    if (hotelToBook != null)
                    {
                        var roomTypeToBook = hotelToBook.Rooms.FirstOrDefault(x => x.RoomTypeVariantId == rq.Variant);
                        if (roomTypeToBook != null)
                        {
                            roomTypeToBook.NumberOfRoomsAvailable -= rq.RoomCount;
                            _context.SaveChanges();
                            currentBooking = new Booking
                            {
                                EndTime = rq.EndDate,
                                StartTime = rq.StartDate,
                                HotelId = rq.HotelId,
                                RoomsAllotted = rq.RoomCount,
                                RoomId = roomTypeToBook.Id,
                                UserId = rq.UserId
                            };
                            _context.Bookings.Add(currentBooking);
                            _context.SaveChanges();
                            transaction.Commit();
                        }
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }
                finally
                {

                }
            }
            return currentBooking;
        }
    }
}
