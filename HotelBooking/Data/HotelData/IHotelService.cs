using HotelBooking.Models;

namespace HotelBooking.Data.HotelData
{
    public interface IHotelService
    {
        List<HotelModel> Hotels { get; }

        public void TryAddAsync(HotelModel hotel);
        public Task<bool> TryUpdateAsync(HotelModel hotel);
        public Task<bool> TryDeleteAsync(string name);
    }
}
