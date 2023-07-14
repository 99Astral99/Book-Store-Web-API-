using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UserFieldsRemoved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "MiddleName",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("12539b7b-b1e6-4a04-be98-6921487caef3"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7447c3fb-10c0-4023-946b-64145eed6dae", "AQAAAAIAAYagAAAAEGJDzgFzjawVt8m1e35OGRqLYrRulqTcJqP6dyUfJ5R/uRqFotGn9QBCM7zcwuU+kg==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a4a67768-deda-43bc-a545-a67d1abda650"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d2107625-a568-44e3-ae3c-b2edc239c547", "AQAAAAIAAYagAAAAEDi5vYd6CeCi86x4poe9BQRsPU5fg8lfiEPpvoVqilY0SqK3UhCkY9zjNMFitRuakA==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MiddleName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("12539b7b-b1e6-4a04-be98-6921487caef3"),
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "MiddleName", "PasswordHash" },
                values: new object[] { "e7cda3b1-274c-4749-bae3-7946fcc3b41e", "Vergil", "Sparda", "Spardovich", "AQAAAAIAAYagAAAAEOugSusyGPy273cXLvfhvqOXgTCCIuTEokak5LAvQDY1oSr4k3xMBUiBRQL9Kjs+Ig==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("a4a67768-deda-43bc-a545-a67d1abda650"),
                columns: new[] { "ConcurrencyStamp", "FirstName", "LastName", "MiddleName", "PasswordHash" },
                values: new object[] { "6f65bb8d-cec3-455c-82c1-46c8e88bda38", "Dante", "Sparda", "Spardovich", "AQAAAAIAAYagAAAAEKBwipNxUdb74i1p1RegITUu5utqdu5pOkhWHrJPUsDFdVZ2nec0XKDJzQyFv36fFg==" });
        }
    }
}
