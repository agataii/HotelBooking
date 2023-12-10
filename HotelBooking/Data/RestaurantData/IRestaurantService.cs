using HotelBooking.Models;

namespace HotelBooking.Data.RestaurantData
{
    public interface IRestaurantService
    {
        List<RestaurantModel> Restaurants { get; }

        public void TryAddAsync(RestaurantModel restaurant);
        public Task<bool> TryUpdateAsync(RestaurantModel restaurant);
        public Task<bool> TryDeleteAsync(string name);
    }
}
