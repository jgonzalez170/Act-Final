using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Segunda4F.Migrations
{
    /// <inheritdoc />
    public partial class NullableTipoCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_TipoClientes_TipoClienteId",
                table: "Clientes");

            migrationBuilder.AlterColumn<int>(
                name: "TipoClienteId",
                table: "Clientes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_TipoClientes_TipoClienteId",
                table: "Clientes",
                column: "TipoClienteId",
                principalTable: "TipoClientes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_TipoClientes_TipoClienteId",
                table: "Clientes");

            migrationBuilder.AlterColumn<int>(
                name: "TipoClienteId",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_TipoClientes_TipoClienteId",
                table: "Clientes",
                column: "TipoClienteId",
                principalTable: "TipoClientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
