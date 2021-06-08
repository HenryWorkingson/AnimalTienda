using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class floatToDouble : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Linea_Pedido_Pedido_Pedidoid_Pedido",
                table: "Linea_Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Linea_Pedido_Pedidoid_Pedido",
                table: "Linea_Pedido");

            migrationBuilder.DropColumn(
                name: "Pedidoid_Pedido",
                table: "Linea_Pedido");

            migrationBuilder.AlterColumn<double>(
                name: "Precio_Total",
                table: "Pedido",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "PrecioTotal",
                table: "Linea_Pedido",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AlterColumn<double>(
                name: "PrecioProductoUnitario",
                table: "Linea_Pedido",
                type: "float",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.CreateTable(
                name: "Linea_PedidoPedido",
                columns: table => new
                {
                    Lista_Pedidosid_Pedido = table.Column<int>(type: "int", nullable: false),
                    lineasid_LineaPedido = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Linea_PedidoPedido", x => new { x.Lista_Pedidosid_Pedido, x.lineasid_LineaPedido });
                    table.ForeignKey(
                        name: "FK_Linea_PedidoPedido_Linea_Pedido_lineasid_LineaPedido",
                        column: x => x.lineasid_LineaPedido,
                        principalTable: "Linea_Pedido",
                        principalColumn: "id_LineaPedido",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Linea_PedidoPedido_Pedido_Lista_Pedidosid_Pedido",
                        column: x => x.Lista_Pedidosid_Pedido,
                        principalTable: "Pedido",
                        principalColumn: "id_Pedido",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Linea_PedidoPedido_lineasid_LineaPedido",
                table: "Linea_PedidoPedido",
                column: "lineasid_LineaPedido");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Linea_PedidoPedido");

            migrationBuilder.AlterColumn<float>(
                name: "Precio_Total",
                table: "Pedido",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<float>(
                name: "PrecioTotal",
                table: "Linea_Pedido",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<float>(
                name: "PrecioProductoUnitario",
                table: "Linea_Pedido",
                type: "real",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AddColumn<int>(
                name: "Pedidoid_Pedido",
                table: "Linea_Pedido",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Linea_Pedido_Pedidoid_Pedido",
                table: "Linea_Pedido",
                column: "Pedidoid_Pedido");

            migrationBuilder.AddForeignKey(
                name: "FK_Linea_Pedido_Pedido_Pedidoid_Pedido",
                table: "Linea_Pedido",
                column: "Pedidoid_Pedido",
                principalTable: "Pedido",
                principalColumn: "id_Pedido",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
