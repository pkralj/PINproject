using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp1.Migrations
{
    /// <inheritdoc />
    public partial class Addedscheduletouseraccount : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserAccountId",
                table: "schedule_items",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_schedule_items_UserAccountId",
                table: "schedule_items",
                column: "UserAccountId");

            migrationBuilder.AddForeignKey(
                name: "FK_schedule_items_user_accounts_UserAccountId",
                table: "schedule_items",
                column: "UserAccountId",
                principalTable: "user_accounts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_schedule_items_user_accounts_UserAccountId",
                table: "schedule_items");

            migrationBuilder.DropIndex(
                name: "IX_schedule_items_UserAccountId",
                table: "schedule_items");

            migrationBuilder.DropColumn(
                name: "UserAccountId",
                table: "schedule_items");
        }
    }
}
