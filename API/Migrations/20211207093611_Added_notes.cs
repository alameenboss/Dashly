using Microsoft.EntityFrameworkCore.Migrations;

namespace Dashly.API.Migrations
{
    public partial class Added_notes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NoteCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    NoteCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NoteCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NoteCategory_NoteCategory_NoteCategoryId",
                        column: x => x.NoteCategoryId,
                        principalTable: "NoteCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Note",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Notes = table.Column<string>(nullable: true),
                    NoteCategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Note_NoteCategory_NoteCategoryId",
                        column: x => x.NoteCategoryId,
                        principalTable: "NoteCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Note_NoteCategoryId",
                table: "Note",
                column: "NoteCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_NoteCategory_NoteCategoryId",
                table: "NoteCategory",
                column: "NoteCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Note");

            migrationBuilder.DropTable(
                name: "NoteCategory");
        }
    }
}
