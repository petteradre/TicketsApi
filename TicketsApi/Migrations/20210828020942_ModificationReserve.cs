using Microsoft.EntityFrameworkCore.Migrations;

namespace TicketsApi.Migrations
{
    public partial class ModificationReserve : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserves_Tickets_UserId",
                table: "Reserves");

            migrationBuilder.AddColumn<int>(
                name: "TicketId",
                table: "Reserves",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reserves_TicketId",
                table: "Reserves",
                column: "TicketId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserves_Tickets_TicketId",
                table: "Reserves",
                column: "TicketId",
                principalTable: "Tickets",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserves_Tickets_TicketId",
                table: "Reserves");

            migrationBuilder.DropIndex(
                name: "IX_Reserves_TicketId",
                table: "Reserves");

            migrationBuilder.DropColumn(
                name: "TicketId",
                table: "Reserves");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserves_Tickets_UserId",
                table: "Reserves",
                column: "UserId",
                principalTable: "Tickets",
                principalColumn: "TicketId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
