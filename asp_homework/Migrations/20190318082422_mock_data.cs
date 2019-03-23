using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace asp_homework.Migrations
{
    public partial class mock_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "Description", "From", "Name", "To" },
                values: new object[] { 1, "Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Vivamus ac leo pretium faucibus. Nulla turpis magna, cursus sit amet, suscipit a, interdum id, felis. Pellentesque pretium lectus id turpis. Nullam faucibus mi quis velit. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Fusce tellus. Nam quis nulla. Phasellus faucibus molestie nisl. Duis sapien nunc, commodo et, interdum suscipit, sollicitudin et, dolor. Etiam sapien elit, consequat eget, tristique non, venenatis quis, ante.", (byte)10, "Alchemist's Chamber", (byte)12 });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "Date", "Description", "Email", "FirstName", "LastName", "PhoneNumber", "RoomId" },
                values: new object[] { 1, new DateTime(2019, 3, 18, 9, 24, 21, 981, DateTimeKind.Local).AddTicks(8650), null, "josef.novy@email.cz", "Josef", "Nový", "+420 724 393 339", 1 });

            migrationBuilder.InsertData(
                table: "Reservations",
                columns: new[] { "ReservationId", "Date", "Description", "Email", "FirstName", "LastName", "PhoneNumber", "RoomId" },
                values: new object[] { 2, new DateTime(2019, 3, 18, 9, 24, 21, 989, DateTimeKind.Local).AddTicks(2450), null, "karel.stary@email.cz", "Karel", "Starý", "+420 602 968 359", 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reservations",
                keyColumn: "ReservationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 1);
        }
    }
}
