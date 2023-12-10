using HotelBooking.Data.HotelData;
using HotelBooking.Models;
using Microsoft.AspNetCore.Mvc;

namespace HotelBooking.Controllers
{
    [ApiController]
    public class HotelController : Controller
    {
        private IHotelService _hotelService;
        public HotelController(IHotelService hotelRepository) 
        {
            _hotelService = hotelRepository;
        }

        [HttpGet("api/hotels")]
        public IActionResult GetHotels()
        {
            if (_hotelService == null)
            {
                return Content("Ни одного отеля не найдено");
            }
            else
            {
                return Json(_hotelService.Hotels);
            }
        }

        [HttpGet("api/ratedHotels")]
        public IActionResult GetRatedHotels()
        {
            if (_hotelService.Hotels.Any(h => h.Rating > 1.0))
            {
                return Json(_hotelService.Hotels.Where(h => h.Rating > 1.0).ToList());
            }
            else
            {
                return Content("Не найдено ни одного звездного отеля");
            }
        }

        [HttpGet("api/favoriteHotels")]
        public IActionResult GetFavoriteHotels()
        {
            if(_hotelService.Hotels.Any(h => h.IsFavorite))
            {
                return Json(_hotelService.Hotels.Where(h => h.IsFavorite).ToList());
            }
            else
            {
                return Content("Не найдено ни одного избранного отеля");
            }
        }

        [HttpPost("api/postHotel")]
        public async Task<IActionResult> PostHotelAsync([FromBody] HotelModel hotel)
        {
            if(_hotelService.Hotels.Any(h => h.Name.ToLower() == hotel.Name.ToLower()))
            {
                return BadRequest("Отель с таким названием существует!");
            }
            _hotelService.TryAddAsync(hotel);
            return Content($"Отель под названием \"{hotel.Name}\" успешно зарегистрирован");
        }

        [HttpPut("api/putHotel")]
        public async Task<IActionResult> PutHotel([FromBody]HotelModel hotel)
        {
            if(await _hotelService.TryUpdateAsync(hotel))
            {
                return Content($"Отель \"{hotel.Name}\" была обновлена");
            }
            else
            {
                return BadRequest("Отель с таким названием не существует");
            }
        }

        [HttpDelete("api/deleteHotel")]
        public async Task<IActionResult> DeleteHotel([FromQuery]string name)
        {
            if(await _hotelService.TryDeleteAsync(name))
            {
                return Content("Отель удален");
            }
            else
            {
                return BadRequest("Отель с таким названием не существует");
            }
        }
    }
}
