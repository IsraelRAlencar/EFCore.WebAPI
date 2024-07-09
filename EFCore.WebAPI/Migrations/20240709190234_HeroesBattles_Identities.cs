using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class HeroesBattles_Identities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Heroes_Battles_BattleId",
                table: "Heroes");

            migrationBuilder.DropIndex(
                name: "IX_Heroes_BattleId",
                table: "Heroes");

            migrationBuilder.DropColumn(
                name: "BattleId",
                table: "Heroes");

            migrationBuilder.CreateTable(
                name: "HeroesBattles",
                columns: table => new
                {
                    HeroId = table.Column<int>(type: "int", nullable: false),
                    BattleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeroesBattles", x => new { x.BattleId, x.HeroId });
                    table.ForeignKey(
                        name: "FK_HeroesBattles_Battles_BattleId",
                        column: x => x.BattleId,
                        principalTable: "Battles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HeroesBattles_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SecretIdentities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RealName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SecretIdentities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SecretIdentities_Heroes_HeroId",
                        column: x => x.HeroId,
                        principalTable: "Heroes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_HeroesBattles_HeroId",
                table: "HeroesBattles",
                column: "HeroId");

            migrationBuilder.CreateIndex(
                name: "IX_SecretIdentities_HeroId",
                table: "SecretIdentities",
                column: "HeroId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HeroesBattles");

            migrationBuilder.DropTable(
                name: "SecretIdentities");

            migrationBuilder.AddColumn<int>(
                name: "BattleId",
                table: "Heroes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Heroes_BattleId",
                table: "Heroes",
                column: "BattleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Heroes_Battles_BattleId",
                table: "Heroes",
                column: "BattleId",
                principalTable: "Battles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
