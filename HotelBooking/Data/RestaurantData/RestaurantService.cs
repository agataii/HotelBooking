using HotelBooking.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Data.RestaurantData
{
    public class RestaurantService : IRestaurantService
    {
        private ApplicationContext _restaurantDbContext;
        public List<RestaurantModel> Restaurants => _restaurantDbContext.Restaurants.ToList();
        public RestaurantService(ApplicationContext restaurantDbContext) 
        {
            _restaurantDbContext= restaurantDbContext;
        }

        public async void TryAddAsync(RestaurantModel restaurant)
        {
            await _restaurantDbContext.Restaurants.AddAsync(restaurant);
            await _restaurantDbContext.SaveChangesAsync();
        }

        public async Task<bool> TryUpdateAsync(RestaurantModel restaurant)
        {
            RestaurantModel findRestaurant = await _restaurantDbContext.Restaurants.FirstOrDefaultAsync(r => r.Name.ToLower() == restaurant.Name.ToLower());
            if (findRestaurant == null)
            {
                return false;
            }
            else
            {
                findRestaurant = new RestaurantModel()
                {
                    Name = restaurant.Name,
                    Rating = restaurant.Rating,
                    IsFavorite = restaurant.IsFavorite,
                    Photos = restaurant.Photos,
                    Food = restaurant.Food,
                    AvgPrice = restaurant.AvgPrice,
                    Seats= restaurant.Seats,
                    Information = restaurant.Information,
                    Comfort = restaurant.Comfort,
                    InHotelName = restaurant.InHotelName,
                    Location = restaurant.Location,
                };
                await _restaurantDbContext.SaveChangesAsync();
                return true;
            }
        }

        public async Task<bool> TryDeleteAsync(string name)
        {
            RestaurantModel findRestaurant = await _restaurantDbContext.Restaurants.FirstOrDefaultAsync(r => r.Name.ToLower() == name.ToLower());
            if (findRestaurant == null)
            {
                return false;
            }
            else
            {
                _restaurantDbContext.Restaurants.Remove(findRestaurant);
                await _restaurantDbContext.SaveChangesAsync();
                return true;
            }
        }
    }
}
