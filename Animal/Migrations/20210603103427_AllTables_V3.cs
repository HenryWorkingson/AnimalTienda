using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal.Migrations
{
    public partial class AllTables_V3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LineaTarjetaCliente",
                columns: table => new
                {
                    id_TarjetaCliente = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Cliente = table.Column<int>(type: "int", nullable: false),
                    Id_Tarjeta = table.Column<int>(type: "int", nullable: false),
                    Ultima_Tarjeta = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineaTarjetaCliente", x => x.id_TarjetaCliente);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LineaTarjetaCliente");
        }
    }
}
