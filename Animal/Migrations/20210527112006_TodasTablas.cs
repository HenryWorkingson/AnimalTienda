using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class TodasTablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "descripcion",
                table: "Animal",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Comida",
                columns: table => new
                {
                    id_Comida = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Comida = table.Column<string>(type: "varchar(50)", nullable: true),
                    Descripcion_Comida = table.Column<string>(type: "varchar(200)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comida", x => x.id_Comida);
                });

            migrationBuilder.CreateTable(
                name: "Juguete",
                columns: table => new
                {
                    id_Juguete = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Juguete = table.Column<string>(type: "varchar(50)", nullable: false),
                    Descripcion_Juguete = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Juguete", x => x.id_Juguete);
                });

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
                name: "Pedido",
                columns: table => new
                {
                    id_Pedido = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion_Pedido = table.Column<string>(type: "varchar(200)", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    Id_Producto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedido", x => x.id_Pedido);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    id_Producto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo_Producto = table.Column<string>(type: "varchar(50)", nullable: false),
                    Descripcion_Producto = table.Column<string>(type: "varchar(200)", nullable: false),
                    Id_Asignado = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.id_Producto);
                });

            migrationBuilder.CreateTable(
                name: "Raza",
                columns: table => new
                {
                    id_Raza = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre_Raza = table.Column<string>(type: "varchar(50)", nullable: false),
                    Descripcion_Raza = table.Column<string>(type: "varchar(200)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raza", x => x.id_Raza);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comida");

            migrationBuilder.DropTable(
                name: "Juguete");

            migrationBuilder.DropTable(
                name: "Ordenar_Pedido");

            migrationBuilder.DropTable(
                name: "Pedido");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Raza");

            migrationBuilder.DropColumn(
                name: "descripcion",
                table: "Animal");
        }
    }
}
