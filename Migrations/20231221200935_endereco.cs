using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FilmeAPI.Migrations;

/// <inheritdoc />
public partial class Endereco : Migration
{
    /// <inheritdoc />
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropForeignKey(
            name: "FK_Cinemas_Endereco_EnderecoId",
            table: "Cinemas");

        _ = migrationBuilder.DropPrimaryKey(
            name: "PK_Endereco",
            table: "Endereco");

        _ = migrationBuilder.RenameTable(
            name: "Endereco",
            newName: "Enderecos");

        _ = migrationBuilder.AlterColumn<string>(
            name: "Logradouro",
            table: "Enderecos",
            type: "varchar(100)",
            maxLength: 100,
            nullable: false,
            oldClrType: typeof(string),
            oldType: "longtext")
            .Annotation("MySql:CharSet", "utf8mb4")
            .OldAnnotation("MySql:CharSet", "utf8mb4");

        _ = migrationBuilder.AddPrimaryKey(
            name: "PK_Enderecos",
            table: "Enderecos",
            column: "Id");

        _ = migrationBuilder.AddForeignKey(
            name: "FK_Cinemas_Enderecos_EnderecoId",
            table: "Cinemas",
            column: "EnderecoId",
            principalTable: "Enderecos",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }

    /// <inheritdoc />
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        _ = migrationBuilder.DropForeignKey(
            name: "FK_Cinemas_Enderecos_EnderecoId",
            table: "Cinemas");

        _ = migrationBuilder.DropPrimaryKey(
            name: "PK_Enderecos",
            table: "Enderecos");

        _ = migrationBuilder.RenameTable(
            name: "Enderecos",
            newName: "Endereco");

        _ = migrationBuilder.AlterColumn<string>(
            name: "Logradouro",
            table: "Endereco",
            type: "longtext",
            nullable: false,
            oldClrType: typeof(string),
            oldType: "varchar(100)",
            oldMaxLength: 100)
            .Annotation("MySql:CharSet", "utf8mb4")
            .OldAnnotation("MySql:CharSet", "utf8mb4");

        _ = migrationBuilder.AddPrimaryKey(
            name: "PK_Endereco",
            table: "Endereco",
            column: "Id");

        _ = migrationBuilder.AddForeignKey(
            name: "FK_Cinemas_Endereco_EnderecoId",
            table: "Cinemas",
            column: "EnderecoId",
            principalTable: "Endereco",
            principalColumn: "Id",
            onDelete: ReferentialAction.Cascade);
    }
}
