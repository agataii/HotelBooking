using HotelBooking.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Text.Json;

namespace HotelBooking.Data
{
    public class ApplicationContext : DbContext
    {
        public DbSet<HotelModel> Hotels { get; set; }
        public DbSet<RestaurantModel> Restaurants { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var LocationModelConvertor = new ValueConverter<LocationModel, string>(
                v => JsonSerializer.Serialize(v, JsonSerializerOptions.Default),
                v => JsonSerializer.Deserialize<LocationModel>(v, JsonSerializerOptions.Default)
                );

            var ListConvertor = new ValueConverter<List<string>, string>(
                v => JsonSerializer.Serialize(v, JsonSerializerOptions.Default),
                v => JsonSerializer.Deserialize<List<string>>(v, JsonSerializerOptions.Default)
                );

            modelBuilder.Entity<HotelModel>().Property(l => l.Location).HasConversion(LocationModelConvertor);
            modelBuilder.Entity<HotelModel>().Property(p => p.Photos).HasConversion(ListConvertor);
            modelBuilder.Entity<HotelModel>().Property(c => c.Comfort).HasConversion(ListConvertor);
            modelBuilder.Entity<RestaurantModel>().Property(l => l.Location).HasConversion(LocationModelConvertor);
            modelBuilder.Entity<RestaurantModel>().Property(p => p.Photos).HasConversion(ListConvertor);
            modelBuilder.Entity<RestaurantModel>().Property(f => f.Food).HasConversion(ListConvertor);
            modelBuilder.Entity<RestaurantModel>().Property(c => c.Comfort).HasConversion(ListConvertor);
        }
    }
}
