using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace asp_homework.Migrations
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
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    From = table.Column<byte>(nullable: false),
                    To = table.Column<byte>(nullable: false)
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
                    Date = table.Column<DateTime>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
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
                values: new object[] { 1, "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Vivamus ac leo pretium faucibus. Nulla turpis magna, cursus sit amet, suscipit a, interdum id, felis. Pellentesque pretium lectus id turpis. Nullam faucibus mi quis velit. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Fusce tellus. Nam quis nulla. Phasellus faucibus molestie nisl. Duis sapien nunc, commodo et, interdum suscipit, sollicitudin et, dolor. Etiam sapien elit, consequat eget, tristique non, venenatis quis, ante.", (byte)9, "Alchemist's Chamber", (byte)18 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "Description", "From", "Name", "To" },
                values: new object[] { 2, "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Vivamus ac leo pretium faucibus. Nulla turpis magna, cursus sit amet, suscipit a, interdum id, felis. Pellentesque pretium lectus id turpis. Nullam faucibus mi quis velit. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Fusce tellus. Nam quis nulla. Phasellus faucibus molestie nisl. Duis sapien nunc, commodo et, interdum suscipit, sollicitudin et, dolor. Etiam sapien elit, consequat eget, tristique non, venenatis quis, ante.", (byte)8, "Path to Eternity", (byte)20 });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "Description", "From", "Name", "To" },
                values: new object[] { 3, null, (byte)8, "Legacy of Ancestors", (byte)19 });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "Date", "Description", "Email", "FirstName", "LastName", "PhoneNumber", "RoomId" },
                values: new object[,]
                {
                    { 1, new DateTime(2019, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, "josef.novy@email.cz", "Josef", "Nový", "+420 724 393 339", 1 },
                    { 2, new DateTime(2019, 1, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), null, "karel.stary@email.cz", "Karel", "Starý", "+420 602 968 359", 1 },
                    { 3, new DateTime(2019, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), null, "jindrich.novotny@email.cz", "Jindřich", "Novotný", "+420 724 013 313", 2 },
                    { 4, new DateTime(2019, 1, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), null, "david.capka@email.cz", "David", "Čapka", "+420 724 676 776", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_RoomId_Date",
                table: "Reservations",
                columns: new[] { "RoomId", "Date" },
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
