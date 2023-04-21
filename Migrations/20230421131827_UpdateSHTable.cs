using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace net_ef_videogame.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSHTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_videogames_software_houses_Software_HouseId",
                table: "videogames");

            migrationBuilder.DropColumn(
                name: "Software_house_id",
                table: "videogames");

            migrationBuilder.RenameColumn(
                name: "Software_HouseId",
                table: "videogames",
                newName: "Software_houseID");

            migrationBuilder.RenameIndex(
                name: "IX_videogames_Software_HouseId",
                table: "videogames",
                newName: "IX_videogames_Software_houseID");

            migrationBuilder.AddForeignKey(
                name: "FK_videogames_software_houses_Software_houseID",
                table: "videogames",
                column: "Software_houseID",
                principalTable: "software_houses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_videogames_software_houses_Software_houseID",
                table: "videogames");

            migrationBuilder.RenameColumn(
                name: "Software_houseID",
                table: "videogames",
                newName: "Software_HouseId");

            migrationBuilder.RenameIndex(
                name: "IX_videogames_Software_houseID",
                table: "videogames",
                newName: "IX_videogames_Software_HouseId");

            migrationBuilder.AddColumn<long>(
                name: "Software_house_id",
                table: "videogames",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddForeignKey(
                name: "FK_videogames_software_houses_Software_HouseId",
                table: "videogames",
                column: "Software_HouseId",
                principalTable: "software_houses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
