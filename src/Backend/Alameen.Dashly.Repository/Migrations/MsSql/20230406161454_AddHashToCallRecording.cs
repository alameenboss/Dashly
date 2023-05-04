using Microsoft.EntityFrameworkCore.Migrations;

namespace Alameen.Dashly.Repository.Migrations.MsSql
{
    public partial class AddHashToCallRecording : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HashValue",
                table: "CallRecordings",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HashValue",
                table: "CallRecordings");
        }
    }
}
