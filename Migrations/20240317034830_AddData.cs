using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DemokrataTT.Migrations
{
    /// <inheritdoc />
    public partial class AddData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "BirdDate", "CreationDate", "FirstName", "LastName", "ModificationDate", "Salary", "SecondName", "SecondSurName" },
                values: new object[,]
                {
                    { 1, new DateTime(1922, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 16, 22, 48, 29, 610, DateTimeKind.Local).AddTicks(9185), "Orfelina", "Sanchez", new DateTime(2024, 3, 16, 22, 48, 29, 610, DateTimeKind.Local).AddTicks(9194), 100, "Maria", "Rueda" },
                    { 2, new DateTime(1910, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2024, 3, 16, 22, 48, 29, 610, DateTimeKind.Local).AddTicks(9197), "Olegario", "Ceron", new DateTime(2024, 3, 16, 22, 48, 29, 610, DateTimeKind.Local).AddTicks(9197), 100, "Jose", "Camacho" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
