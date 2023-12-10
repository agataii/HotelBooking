namespace HotelBooking.Models
{
    public class RestaurantModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Rating { get; set; }
        public bool IsFavorite { get; set; }
        public List<string>? Photos { get; set; }
        public List<string> Food { get; set; }
        public float AvgPrice { get; set; }
        public int Seats { get; set; }
        public string? Information { get; set; }
        public List<string>? Comfort { get; set; }
        public string InHotelName { get; set; }
        public LocationModel Location { get; set; }
    }
}
