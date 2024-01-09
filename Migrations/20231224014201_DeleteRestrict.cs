using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmeAPI.Migrations;

/// <inheritdoc />
public partial class DeleteRestrict : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropForeignKey(
            name: "FK_Cinemas_Enderecos_EnderecoId",
            table: "Cinemas");

        _ = migrationBuilder.AddForeignKey(
            name: "FK_Cinemas_Enderecos_EnderecoId",
            table: "Cinemas",
            column: "EnderecoId",
            principalTable: "Enderecos",
            principalColumn: "Id",
            onDelete: ReferentialAction.Restrict);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropForeignKey(
            name: "FK_Cinemas_Enderecos_EnderecoId",
            table: "Cinemas");

        _ = migrationBuilder.AddForeignKey(
            name: "FK_Cinemas_Enderecos_EnderecoId",
            table: "Cinemas",
            column: "EnderecoId",
            principalTable: "Enderecos",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }
}
