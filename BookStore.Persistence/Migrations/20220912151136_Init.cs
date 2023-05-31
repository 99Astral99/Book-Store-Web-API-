using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Persistence.Migrations
{
	public partial class Init : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.CreateTable(
				name: "Books",
				columns: table => new
				{
					Id = table.Column<int>(type: "int", nullable: false)
						.Annotation("SqlServer:Identity", "1, 1"),
					Title = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
					Genre = table.Column<string>(type: "nvarchar(max)", nullable: true),
					Author = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
					Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
					Amount = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
					CreationYear = table.Column<string>(type: "nvarchar(max)", nullable: true)
				},
				constraints: table =>
				{
					table.PrimaryKey("PK_Books", x => x.Id);
				});

			migrationBuilder.InsertData(
				table: "Books",
				columns: new[] { "Id", "Amount", "Author", "CreationYear", "Genre", "Price", "Title" },
				values: new object[,]
				{
					{ 1, 30, "Martin Gilbert", "2004", "History", 25.55m, "The First World War: A Complete History" },
					{ 2, 100, "Plato", "2021", "Philosophy", 5m, "The Republic" },
					{ 3, 45, "Andrew Lock", "2021", "Programming", 36.39m, "ASP.NET Core in Action, Second Edition" },
					{ 4, 115, "Marcus Aurelius", "2018", "Philosophy", 12.83m, "Meditations" }
				});

			migrationBuilder.CreateIndex(
				name: "IX_Books_Id",
				table: "Books",
				column: "Id");
		}

		protected override void Down(MigrationBuilder migrationBuilder)
		{
			migrationBuilder.DropTable(
				name: "Books");
		}
	}
}
