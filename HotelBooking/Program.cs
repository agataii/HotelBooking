using HotelBooking.Data;
using HotelBooking.Data.HotelData;
using HotelBooking.Data.RestaurantData;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Это добавляет наш контекст БД в проект
builder.Services.AddDbContext<ApplicationContext>(options => options.UseSqlServer("workstation id=HotelBookingDB.mssql.somee.com;packet size=4096;user id=agataii_SQLLogin_1;pwd=4lhau2najl;data source=HotelBookingDB.mssql.somee.com;persist security info=False; Encrypt=False;initial catalog=HotelBookingDB"));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<IRestaurantService, RestaurantService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.MapGet("/", (HttpContext context) =>
{
    context.Response.Redirect("/swagger/index.html");
});
app.Run();
