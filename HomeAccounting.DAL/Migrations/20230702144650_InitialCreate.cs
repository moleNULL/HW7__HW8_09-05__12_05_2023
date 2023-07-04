using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HomeAccounting.DAL.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(75)", maxLength: 75, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Expenses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cost = table.Column<decimal>(type: "money", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Comment = table.Column<string>(type: "varchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expenses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expenses_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Food" },
                    { 2, "Transportation" },
                    { 3, "Cellular Service" },
                    { 4, "Internet" },
                    { 5, "Entertainment" }
                });

            migrationBuilder.InsertData(
                table: "Expenses",
                columns: new[] { "Id", "CategoryId", "Comment", "Cost", "Date", "Name" },
                values: new object[,]
                {
                    { 1, 1, "Ate 3 hamburgers with friends", 120m, new DateTime(2023, 4, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "McDonalds" },
                    { 2, 3, null, 200m, new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "lifecell" },
                    { 3, 2, "Took Uklon taxi for home", 185m, new DateTime(2023, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Taxi" },
                    { 4, 1, null, 320m, new DateTime(2023, 4, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Cafe" },
                    { 5, 4, "Shevchenko street", 244m, new DateTime(2023, 4, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Triolan" },
                    { 6, 4, "Parent's house", 150m, new DateTime(2023, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "Maxnet" },
                    { 7, 5, "Bought yet another CSGO copy in Steam", 550m, new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "CSGO" },
                    { 8, 1, null, 59m, new DateTime(2023, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lays Crisps" },
                    { 9, 5, null, 139m, new DateTime(2023, 5, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spotify subscription" },
                    { 10, 5, null, 229m, new DateTime(2023, 5, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "MEGOGO subscription" },
                    { 11, 3, "Year prepaid for mom", 2285m, new DateTime(2023, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vodafone" },
                    { 12, 2, null, 20m, new DateTime(2023, 5, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bus" },
                    { 13, 1, null, 150m, new DateTime(2023, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Salami" },
                    { 14, 5, "Zoo near the forest", 450m, new DateTime(2023, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Zoo" },
                    { 15, 2, null, 16m, new DateTime(2023, 4, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Tram" },
                    { 16, 1, "Bought food for the holiday", 690m, new DateTime(2023, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ekomarket" },
                    { 17, 2, "247e", 24m, new DateTime(2023, 5, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Bus" },
                    { 18, 1, null, 14.8m, new DateTime(2023, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ice cream" },
                    { 19, 5, null, 1350m, new DateTime(2023, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Metallica concert tickets" },
                    { 20, 5, "Bought in Origin", 160m, new DateTime(2023, 5, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "PES2009" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_CategoryId",
                table: "Expenses",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expenses");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
