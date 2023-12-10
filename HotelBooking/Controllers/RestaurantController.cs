using HotelBooking.Data.RestaurantData;
using HotelBooking.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers
{
    [ApiController]
    public class RestaurantController : Controller
    {
        private IRestaurantService _restaurantService;
        public RestaurantController(IRestaurantService restaurantRepository)
        {
            _restaurantService = restaurantRepository;
        }

        [HttpGet("api/restaurants")]
        public IActionResult GetRestaurants()
        {
            if (_restaurantService == null)
            {
                return Content("Ни одного ресторана не найдено");
            }
            else
            {
                return Json(_restaurantService.Restaurants);
            }
        }

        [HttpPost("api/postRestaurant")]
        public IActionResult PostRestaurant([FromBody] RestaurantModel restaurant)
        {
            if (_restaurantService.Restaurants.Any(r => r.Name.ToLower() == restaurant.Name.ToLower()))
            {
                return BadRequest("Ресторан с таким названием существует!");
            }
            _restaurantService.TryAddAsync(restaurant);
            return Content($"Ресторан под названием \"{restaurant.Name}\" успешно зарегистрирован");
        }

        [HttpPut("api/putRestaurant")]
        public async Task<IActionResult> PutRestaurantAsync([FromBody] RestaurantModel restaurant)
        {
            if (await _restaurantService.TryUpdateAsync(restaurant))
            {
                return Content($"Ресторан \"{restaurant.Name}\" был обновлен");
            }
            else
            {
                return BadRequest("Ресторан с таким названием не существует");
            }
        }

        [HttpDelete("api/deleteRestaurant")]
        public async Task<IActionResult> DeleteRestaurantAsync([FromQuery] string name)
        {
            if (await _restaurantService.TryDeleteAsync(name))
            {
                return Content("Ресторан удален");
            }
            else
            {
                return BadRequest("Ресторан с таким названием не существует");
            }
        }
    }
}
