using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmeAPI.Migrations;

/// <inheritdoc />
public partial class CinemaEFilme : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropForeignKey(
            name: "FK_Sessaos_Cinemas_CinemaId",
            table: "Sessaos");

        _ = migrationBuilder.DropPrimaryKey(
            name: "PK_Sessaos",
            table: "Sessaos");

        // migrationBuilder.DropIndex(
        //     name: "IX_Sessaos_FilmeId",
        //     table: "Sessaos");

        _ = migrationBuilder.DropColumn(
            name: "Id",
            table: "Sessaos");

        _ = migrationBuilder.AlterColumn<int>(
            name: "CinemaId",
            table: "Sessaos",
            type: "int",
            nullable: false,
            defaultValue: 0,
            oldClrType: typeof(int),
            oldType: "int",
            oldNullable: true);

        _ = migrationBuilder.AddPrimaryKey(
            name: "PK_Sessaos",
            table: "Sessaos",
            columns: new[] { "FilmeId", "CinemaId" });

        _ = migrationBuilder.AddForeignKey(
            name: "FK_Sessaos_Cinemas_CinemaId",
            table: "Sessaos",
            column: "CinemaId",
            principalTable: "Cinemas",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropForeignKey(
            name: "FK_Sessaos_Cinemas_CinemaId",
            table: "Sessaos");

        _ = migrationBuilder.DropPrimaryKey(
            name: "PK_Sessaos",
            table: "Sessaos");

        _ = migrationBuilder.AlterColumn<int>(
            name: "CinemaId",
            table: "Sessaos",
            type: "int",
            nullable: true,
            oldClrType: typeof(int),
            oldType: "int");

        _ = migrationBuilder.AddColumn<int>(
            name: "Id",
            table: "Sessaos",
            type: "int",
            nullable: false,
            defaultValue: 0)
            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

        _ = migrationBuilder.AddPrimaryKey(
            name: "PK_Sessaos",
            table: "Sessaos",
            column: "Id");

        _ = migrationBuilder.CreateIndex(
            name: "IX_Sessaos_FilmeId",
            table: "Sessaos",
            column: "FilmeId");

        _ = migrationBuilder.AddForeignKey(
            name: "FK_Sessaos_Cinemas_CinemaId",
            table: "Sessaos",
            column: "CinemaId",
            principalTable: "Cinemas",
            principalColumn: "Id");
    }
}
