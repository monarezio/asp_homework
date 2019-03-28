using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace reservations_data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: false),
                    From = table.Column<int>(maxLength: 2, nullable: false),
                    To = table.Column<int>(maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReservationId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    From = table.Column<DateTime>(nullable: false),
                    To = table.Column<DateTime>(nullable: false),
                    FristName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: false),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    RoomId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReservationId);
                    table.ForeignKey(
                        name: "FK_Reservations_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "RoomId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "Description", "From", "Name", "To" },
                values: new object[] { 1, "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Vivamus ac leo pretium faucibus. Nulla turpis magna, cursus sit amet, suscipit a, interdum id, felis. Pellentesque pretium lectus id turpis. Nullam faucibus mi quis velit. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Fusce tellus. Nam quis nulla. Phasellus faucibus molestie nisl. Duis sapien nunc, commodo et, interdum suscipit, sollicitudin et, dolor. Etiam sapien elit, consequat eget, tristique non, venenatis quis, ante.", 9, "Alchemist's Chamber", 18 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "Description", "From", "Name", "To" },
                values: new object[] { 2, "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Vivamus ac leo pretium faucibus. Nulla turpis magna, cursus sit amet, suscipit a, interdum id, felis. Pellentesque pretium lectus id turpis. Nullam faucibus mi quis velit. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Fusce tellus. Nam quis nulla. Phasellus faucibus molestie nisl. Duis sapien nunc, commodo et, interdum suscipit, sollicitudin et, dolor. Etiam sapien elit, consequat eget, tristique non, venenatis quis, ante.", 8, "Path to Eternity", 20 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "Description", "From", "Name", "To" },
                values: new object[] { 3, "Lorem Ipsum dolor sit amet, consectetuer adipiscing elit. Vivamus ac leo pretium faucibus. Nulla turpis magna, cursus sit amet, suscipit a, interdum id, felis. Pellentesque pretium lectus id turpis. Nullam faucibus mi quis velit. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Fusce tellus. Nam quis nulla. Phasellus faucibus molestie nisl. Duis sapien nunc, commodo et, interdum suscipit, sollicitudin et, dolor. Etiam sapien elit, consequat eget, tristique non, venenatis quis, ante.", 8, "Legacy of Ancestors", 19 });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "Description", "Email", "FristName", "From", "LastName", "PhoneNumber", "RoomId", "To" },
                values: new object[,]
                {
                    { 1, null, "josef.novy@email.cz", "Josef", new DateTime(2019, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), "Nový", "+420 724 393 339", 1, new DateTime(2019, 1, 1, 11, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, null, "karel.stary@email.cz", "Karel", new DateTime(2019, 1, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), "Satrý", "+420 602 968 359", 1, new DateTime(2019, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, null, "jindrich.novotny@email.cz", "Jindřich", new DateTime(2019, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), "Novotný", "+420 724 013 313", 2, new DateTime(2019, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, null, "david.capka@email.cz", "David", new DateTime(2019, 1, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), "Čapka", "+420 724 676 776", 2, new DateTime(2019, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RoomId_From_To",
                table: "Reservations",
                columns: new[] { "RoomId", "From", "To" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
