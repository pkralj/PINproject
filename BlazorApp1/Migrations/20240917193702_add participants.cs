using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp1.Migrations
{
    /// <inheritdoc />
    public partial class addparticipants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "ScheduleItemUserAccount",
                columns: table => new
                {
                    ParticipantsId = table.Column<int>(type: "int", nullable: false),
                    myScheduleItemsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleItemUserAccount", x => new { x.ParticipantsId, x.myScheduleItemsId });
                    table.ForeignKey(
                        name: "FK_ScheduleItemUserAccount_schedule_items_myScheduleItemsId",
                        column: x => x.myScheduleItemsId,
                        principalTable: "schedule_items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ScheduleItemUserAccount_user_accounts_ParticipantsId",
                        column: x => x.ParticipantsId,
                        principalTable: "user_accounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleItemUserAccount_myScheduleItemsId",
                table: "ScheduleItemUserAccount",
                column: "myScheduleItemsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ScheduleItemUserAccount");

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
    }
}
