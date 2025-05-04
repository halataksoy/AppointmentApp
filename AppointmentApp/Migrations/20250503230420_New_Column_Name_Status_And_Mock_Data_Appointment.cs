using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AppointmentApp.Migrations
{
    /// <inheritdoc />
    public partial class New_Column_Name_Status_And_Mock_Data_Appointment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Appointments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Appointments",
                columns: new[] { "Id", "DateTime", "DepartmentId", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 4, 10, 10, 0, 0, 0, DateTimeKind.Unspecified), 1, 1, 2 },
                    { 2, new DateTime(2025, 4, 28, 11, 0, 0, 0, DateTimeKind.Unspecified), 2, 2, 2 },
                    { 3, new DateTime(2025, 5, 5, 14, 0, 0, 0, DateTimeKind.Unspecified), 3, 1, 2 },
                    { 4, new DateTime(2025, 5, 10, 16, 0, 0, 0, DateTimeKind.Unspecified), 4, 3, 2 },
                    { 5, new DateTime(2025, 6, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, 2 },
                    { 6, new DateTime(2025, 6, 3, 13, 30, 0, 0, DateTimeKind.Unspecified), 6, 2, 2 },
                    { 7, new DateTime(2025, 6, 5, 15, 45, 0, 0, DateTimeKind.Unspecified), 7, 3, 2 },
                    { 8, new DateTime(2025, 4, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), 1, 3, 3 },
                    { 9, new DateTime(2025, 5, 3, 10, 30, 0, 0, DateTimeKind.Unspecified), 2, 1, 3 },
                    { 10, new DateTime(2025, 5, 7, 12, 0, 0, 0, DateTimeKind.Unspecified), 3, 2, 3 },
                    { 11, new DateTime(2025, 5, 14, 14, 30, 0, 0, DateTimeKind.Unspecified), 4, 1, 3 },
                    { 12, new DateTime(2025, 6, 6, 10, 15, 0, 0, DateTimeKind.Unspecified), 5, 1, 3 },
                    { 13, new DateTime(2025, 6, 10, 11, 45, 0, 0, DateTimeKind.Unspecified), 6, 3, 3 },
                    { 14, new DateTime(2025, 6, 12, 13, 0, 0, 0, DateTimeKind.Unspecified), 7, 2, 3 },
                    { 15, new DateTime(2025, 4, 18, 10, 30, 0, 0, DateTimeKind.Unspecified), 1, 2, 4 },
                    { 16, new DateTime(2025, 5, 2, 14, 15, 0, 0, DateTimeKind.Unspecified), 2, 1, 4 },
                    { 17, new DateTime(2025, 5, 8, 15, 30, 0, 0, DateTimeKind.Unspecified), 3, 3, 4 },
                    { 18, new DateTime(2025, 5, 16, 9, 45, 0, 0, DateTimeKind.Unspecified), 4, 1, 4 },
                    { 19, new DateTime(2025, 6, 2, 10, 0, 0, 0, DateTimeKind.Unspecified), 5, 1, 4 },
                    { 20, new DateTime(2025, 6, 4, 12, 30, 0, 0, DateTimeKind.Unspecified), 6, 2, 4 },
                    { 21, new DateTime(2025, 6, 8, 14, 0, 0, 0, DateTimeKind.Unspecified), 7, 3, 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Appointments",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Appointments");
        }
    }
}
