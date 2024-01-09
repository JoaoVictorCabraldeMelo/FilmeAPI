using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmeAPI.Migrations;

/// <inheritdoc />
public partial class RenameMigrations : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder) => _ = migrationBuilder.DropColumn(
            name: "FilmId",
            table: "Sessaos");

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder) => _ = migrationBuilder.AddColumn<int>(
            name: "FilmId",
            table: "Sessaos",
            type: "int",
            nullable: false,
            defaultValue: 0);
}
