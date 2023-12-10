using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.Migrations
{
    /// <inheritdoc />
    public partial class DbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hotels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    IsFavorite = table.Column<bool>(type: "bit", nullable: false),
                    Photos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<int>(type: "int", nullable: false),
                    RoomArea = table.Column<float>(type: "real", nullable: false),
                    Information = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comfort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hotels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Restaurants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: false),
                    IsFavorite = table.Column<bool>(type: "bit", nullable: false),
                    Photos = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Food = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvgPrice = table.Column<float>(type: "real", nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    Information = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comfort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InHotelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurants", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hotels");

            migrationBuilder.DropTable(
                name: "Restaurants");
        }
    }
}
