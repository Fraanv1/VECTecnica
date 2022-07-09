using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VEC.Infrastructure.Migrations
{
    public partial class InitDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehiculo",
                columns: table => new
                {
                    VehiculoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoVehiculo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CantidadRuedas = table.Column<int>(type: "int", nullable: false),
                    Marca = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modelo = table.Column<int>(type: "int", nullable: false),
                    Patente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Chasis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KmRecorridos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KmMantenimiento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehiculo", x => x.VehiculoId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehiculo");
        }
    }
}
