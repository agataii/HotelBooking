using HotelBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Data.HotelData
{
    public class HotelService : IHotelService
    {
        private ApplicationContext _hotelDbContext;
        public List<HotelModel> Hotels => _hotelDbContext.Hotels.ToList();
        public HotelService(ApplicationContext hotelDbContext)
        {
            _hotelDbContext = hotelDbContext;
        }

        public async void TryAddAsync(HotelModel hotel)
        {
            await _hotelDbContext.Hotels.AddAsync(hotel);
            await _hotelDbContext.SaveChangesAsync();
        }

        public async Task<bool> TryUpdateAsync(HotelModel hotel)
        {
            HotelModel findHotel = await _hotelDbContext.Hotels.FirstOrDefaultAsync(h => h.Name.ToLower() == hotel.Name.ToLower());
            if (findHotel == null)
            {
                return false;
            }
            else
            {
                findHotel = new HotelModel()
                {
                    Name = hotel.Name,
                    Rating= hotel.Rating,
                    IsFavorite= hotel.IsFavorite,
                    Photos= hotel.Photos,
                    Price= hotel.Price,
                    RoomArea= hotel.RoomArea,
                    Information= hotel.Information,
                    Comfort= hotel.Comfort,
                    Location= hotel.Location,
                };
                await _hotelDbContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> TryDeleteAsync(string name)
        {
            HotelModel findHotel = await _hotelDbContext.Hotels.FirstOrDefaultAsync(h => h.Name.ToLower() == name.ToLower());
            if (findHotel == null)
            {
                return false;
            }
            else
            {
                _hotelDbContext.Hotels.Remove(findHotel);
                await _hotelDbContext.SaveChangesAsync();
                return true;
            }
        }
    }
}
