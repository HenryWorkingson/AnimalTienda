using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class AllTableV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ordenar_Pedido");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.RenameColumn(
                name: "Id_Producto",
                table: "Pedido",
                newName: "Id_Tarjeta");

            migrationBuilder.RenameColumn(
                name: "Cantidad",
                table: "Pedido",
                newName: "Id_Direccion");

            migrationBuilder.AddColumn<int>(
                name: "Id_Cliente",
                table: "Pedido",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Precio_Total",
                table: "Pedido",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "precio",
                table: "Juguete",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "precio",
                table: "Comida",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<float>(
                name: "precio",
                table: "Animal",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "Clase_Producto",
                columns: table => new
                {
                    id_Producto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo_Producto = table.Column<string>(type: "varchar(50)", nullable: false),
                    Descripcion_Producto = table.Column<string>(type: "varchar(200)", nullable: false),
                    Id_Asignado = table.Column<int>(type: "int", nullable: false),
                    Precio_Producto = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clase_Producto", x => x.id_Producto);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    id_Cliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Cliente = table.Column<string>(type: "varchar(50)", nullable: false),
                    Apellido_Cliente = table.Column<string>(type: "varchar(50)", nullable: false),
                    cuenta_Cliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    password_Cliente = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    correo_Cliente = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.id_Cliente);
                });

            migrationBuilder.CreateTable(
                name: "Direccion_Envio",
                columns: table => new
                {
                    id_DireccionEnvio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Direccion = table.Column<string>(type: "varchar(200)", nullable: false),
                    Provincia = table.Column<string>(type: "varchar(50)", nullable: false),
                    Municipal = table.Column<string>(type: "varchar(50)", nullable: false),
                    DNI_Cliente_Rceiv = table.Column<string>(type: "varchar(50)", nullable: false),
                    Nombre_Cliente_Rec = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Direccion_Envio", x => x.id_DireccionEnvio);
                });

            migrationBuilder.CreateTable(
                name: "Linea_Pedido",
                columns: table => new
                {
                    id_LineaPedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_Producto = table.Column<int>(type: "int", nullable: false),
                    id_Pedido = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioProductoUnitario = table.Column<float>(type: "real", nullable: false),
                    PrecioTotal = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Linea_Pedido", x => x.id_LineaPedido);
                });

            migrationBuilder.CreateTable(
                name: "LineaDireccionCliente",
                columns: table => new
                {
                    id_DireccionCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Cliente = table.Column<int>(type: "int", nullable: false),
                    Id_Direccion = table.Column<int>(type: "int", nullable: false),
                    Ultima_Dir_Env = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineaDireccionCliente", x => x.id_DireccionCliente);
                });

            migrationBuilder.CreateTable(
                name: "TarjetaPago",
                columns: table => new
                {
                    id_TarjetaPago = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero_Tarjeta = table.Column<string>(type: "varchar(200)", nullable: false),
                    FechaCadu_Tarjeta = table.Column<string>(type: "varchar(200)", nullable: false),
                    Nom_Propietario = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TarjetaPago", x => x.id_TarjetaPago);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clase_Producto");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Direccion_Envio");

            migrationBuilder.DropTable(
                name: "Linea_Pedido");

            migrationBuilder.DropTable(
                name: "LineaDireccionCliente");

            migrationBuilder.DropTable(
                name: "TarjetaPago");

            migrationBuilder.DropColumn(
                name: "Id_Cliente",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "Precio_Total",
                table: "Pedido");

            migrationBuilder.DropColumn(
                name: "precio",
                table: "Juguete");

            migrationBuilder.DropColumn(
                name: "precio",
                table: "Comida");

            migrationBuilder.DropColumn(
                name: "precio",
                table: "Animal");

            migrationBuilder.RenameColumn(
                name: "Id_Tarjeta",
                table: "Pedido",
                newName: "Id_Producto");

            migrationBuilder.RenameColumn(
                name: "Id_Direccion",
                table: "Pedido",
                newName: "Cantidad");

            migrationBuilder.CreateTable(
                name: "Ordenar_Pedido",
                columns: table => new
                {
                    id_Ordernar = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_Producto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ordenar_Pedido", x => x.id_Ordernar);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    id_Producto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion_Producto = table.Column<string>(type: "varchar(200)", nullable: false),
                    Id_Asignado = table.Column<int>(type: "int", nullable: false),
                    Tipo_Producto = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.id_Producto);
                });
        }
    }
}
