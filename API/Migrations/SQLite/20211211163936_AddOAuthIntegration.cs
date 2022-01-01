using Microsoft.EntityFrameworkCore.Migrations;

namespace Dashly.API.Migrations
{
    public partial class AddOAuthIntegration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OAuthIntegrations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(nullable: true),
                    TokenUrl = table.Column<string>(nullable: true),
                    AppId = table.Column<string>(nullable: true),
                    ClientId = table.Column<string>(nullable: true),
                    Secret = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OAuthIntegrations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OAuthIntegrations");
        }
    }
}