using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmeAPI.Migrations;

/// <inheritdoc />
public partial class AddSessaoToCinema : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.AddColumn<int>(
            name: "CinemaId",
            table: "Sessaos",
            type: "int",
            nullable: true);

        _ = migrationBuilder.CreateIndex(
            name: "IX_Sessaos_CinemaId",
            table: "Sessaos",
            column: "CinemaId");

        _ = migrationBuilder.AddForeignKey(
            name: "FK_Sessaos_Cinemas_CinemaId",
            table: "Sessaos",
            column: "CinemaId",
            principalTable: "Cinemas",
            principalColumn: "Id");
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropForeignKey(
            name: "FK_Sessaos_Cinemas_CinemaId",
            table: "Sessaos");

        _ = migrationBuilder.DropIndex(
            name: "IX_Sessaos_CinemaId",
            table: "Sessaos");

        _ = migrationBuilder.DropColumn(
            name: "CinemaId",
            table: "Sessaos");
    }
}
