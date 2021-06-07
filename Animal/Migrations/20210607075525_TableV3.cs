using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class TableV3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Clienteid_Cliente",
                table: "TarjetaPago",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Clienteid_Cliente",
                table: "Pedido",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Pedidoid_Pedido",
                table: "Linea_Pedido",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Clienteid_Cliente",
                table: "Direccion_Envio",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Atributo",
                columns: table => new
                {
                    IdAtributo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atributo", x => x.IdAtributo);
                });

            migrationBuilder.CreateTable(
                name: "Caracteristica",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Caracteristica", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PrecioProducto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    PVP = table.Column<double>(type: "float", nullable: false),
                    FechaFin = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrecioProducto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreProducto = table.Column<string>(type: "varchar(200)", nullable: false),
                    DescripcionProducto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrecioBase = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.IdProducto);
                });

            migrationBuilder.CreateTable(
                name: "Atributo_Valor",
                columns: table => new
                {
                    IdAtributoValor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdAtributo = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AtributoIdAtributo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atributo_Valor", x => x.IdAtributoValor);
                    table.ForeignKey(
                        name: "FK_Atributo_Valor_Atributo_AtributoIdAtributo",
                        column: x => x.AtributoIdAtributo,
                        principalTable: "Atributo",
                        principalColumn: "IdAtributo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AtributoProducto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    IdAtributo = table.Column<int>(type: "int", nullable: false),
                    IdAtributoValor = table.Column<int>(type: "int", nullable: false),
                    ProductoIdProducto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtributoProducto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AtributoProducto_Producto_ProductoIdProducto",
                        column: x => x.ProductoIdProducto,
                        principalTable: "Producto",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CaracteristicaProducto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    IdCaracteristica = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<int>(type: "int", nullable: false),
                    ProductoIdProducto = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaracteristicaProducto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CaracteristicaProducto_Producto_ProductoIdProducto",
                        column: x => x.ProductoIdProducto,
                        principalTable: "Producto",
                        principalColumn: "IdProducto",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TarjetaPago_Clienteid_Cliente",
                table: "TarjetaPago",
                column: "Clienteid_Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Pedido_Clienteid_Cliente",
                table: "Pedido",
                column: "Clienteid_Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Linea_Pedido_Pedidoid_Pedido",
                table: "Linea_Pedido",
                column: "Pedidoid_Pedido");

            migrationBuilder.CreateIndex(
                name: "IX_Direccion_Envio_Clienteid_Cliente",
                table: "Direccion_Envio",
                column: "Clienteid_Cliente");

            migrationBuilder.CreateIndex(
                name: "IX_Atributo_Valor_AtributoIdAtributo",
                table: "Atributo_Valor",
                column: "AtributoIdAtributo");

            migrationBuilder.CreateIndex(
                name: "IX_AtributoProducto_ProductoIdProducto",
                table: "AtributoProducto",
                column: "ProductoIdProducto");

            migrationBuilder.CreateIndex(
                name: "IX_CaracteristicaProducto_ProductoIdProducto",
                table: "CaracteristicaProducto",
                column: "ProductoIdProducto");

            migrationBuilder.AddForeignKey(
                name: "FK_Direccion_Envio_Cliente_Clienteid_Cliente",
                table: "Direccion_Envio",
                column: "Clienteid_Cliente",
                principalTable: "Cliente",
                principalColumn: "id_Cliente",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Linea_Pedido_Pedido_Pedidoid_Pedido",
                table: "Linea_Pedido",
                column: "Pedidoid_Pedido",
                principalTable: "Pedido",
                principalColumn: "id_Pedido",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Pedido_Cliente_Clienteid_Cliente",
                table: "Pedido",
                column: "Clienteid_Cliente",
                principalTable: "Cliente",
                principalColumn: "id_Cliente",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TarjetaPago_Cliente_Clienteid_Cliente",
                table: "TarjetaPago",
                column: "Clienteid_Cliente",
                principalTable: "Cliente",
                principalColumn: "id_Cliente",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Direccion_Envio_Cliente_Clienteid_Cliente",
                table: "Direccion_Envio");

            migrationBuilder.DropForeignKey(
                name: "FK_Linea_Pedido_Pedido_Pedidoid_Pedido",
                table: "Linea_Pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_Pedido_Cliente_Clienteid_Cliente",
                table: "Pedido");

            migrationBuilder.DropForeignKey(
                name: "FK_TarjetaPago_Cliente_Clienteid_Cliente",
                table: "TarjetaPago");

            migrationBuilder.DropTable(
                name: "Atributo_Valor");

            migrationBuilder.DropTable(
                name: "AtributoProducto");

            migrationBuilder.DropTable(
                name: "Caracteristica");

            migrationBuilder.DropTable(
                name: "CaracteristicaProducto");

            migrationBuilder.DropTable(
                name: "PrecioProducto");

            migrationBuilder.DropTable(
                name: "Atributo");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_TarjetaPago_Clienteid_Cliente",
                table: "TarjetaPago");

            migrationBuilder.DropIndex(
                name: "IX_Pedido_Clienteid_Cliente",
                table: "Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Linea_Pedido_Pedidoid_Pedido",
                table: "Linea_Pedido");

            migrationBuilder.DropIndex(
                name: "IX_Direccion_Envio_Clienteid_Cliente",
                table: "Direccion_Envio");

            migrationBuilder.DropColumn(
                name: "Clienteid_Cliente",
                table: "TarjetaPago");

            migrationBuilder.DropColumn(
                name: "Clienteid_Cliente",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "Pedidoid_Pedido",
                table: "Linea_Pedido");

            migrationBuilder.DropColumn(
                name: "Clienteid_Cliente",
                table: "Direccion_Envio");
        }
    }
}
