namespace HotelBooking.Models
{
    public class HotelModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Rating { get; set; }
        public bool IsFavorite { get; set; }
        public List<string>? Photos { get; set; }
        public int Price { get; set; }
        public float RoomArea { get; set; }
        public string? Information { get; set; }
        public List<string>? Comfort { get; set; }
        //public virtual LocationModel Location { get; set; }
        public LocationModel Location { get; set; }
    }
}
