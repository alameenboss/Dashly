using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dashly.API.Migrations
{
    public partial class addedgithubrepo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GitHubRepo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GitId = table.Column<string>(nullable: true),
                    NodeId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    IsPrivate = table.Column<bool>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Fork = table.Column<bool>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    CloneUrl = table.Column<string>(nullable: true),
                    DownloadsUrl = table.Column<string>(nullable: true),
                    HtmlUrl = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GitHubRepo", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GitHubRepo");
        }
    }
}
