using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Models
{
    [Keyless]
    //[Owned]
    public class LocationModel
    {
        public string Country { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int Floor { get; set; }
        public int Number { get; set; }
    }
}
