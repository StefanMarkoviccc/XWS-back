using Microsoft.EntityFrameworkCore.Migrations;

namespace PostService.Migrations
{
    public partial class postId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PostId",
                table: "Posts");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PostId",
                table: "Posts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
