using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetGuard_Project.Migrations
{
    public partial class PrimeraMigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    IdDepartamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionDepartamento = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    EstadoDepartamento = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Departam__787A433DF01BE3B3", x => x.IdDepartamento);
                });

            migrationBuilder.CreateTable(
                name: "TiposActivos",
                columns: table => new
                {
                    IdTA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionTA = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CuentaContableCompraTA = table.Column<int>(type: "int", nullable: true),
                    CuentaContableDepreciacionTA = table.Column<int>(type: "int", nullable: true),
                    EstadoTA = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TiposAct__B7701AB7A654C049", x => x.IdTA);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    IdEmpleado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEmpleado = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    CedulaEmpleado = table.Column<string>(type: "varchar(11)", unicode: false, maxLength: 11, nullable: true),
                    DepartamentoEmpleado = table.Column<int>(type: "int", nullable: true),
                    TipoPersonaEmpleado = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true),
                    FechaIngresoEmpleado = table.Column<DateTime>(type: "date", nullable: true),
                    EstadoEmpleado = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Empleado__CE6D8B9E7C1BBA10", x => x.IdEmpleado);
                    table.ForeignKey(
                        name: "FK__Empleado__Depart__3B75D760",
                        column: x => x.DepartamentoEmpleado,
                        principalTable: "Departamentos",
                        principalColumn: "IdDepartamento");
                });

            migrationBuilder.CreateTable(
                name: "ActivosFijos",
                columns: table => new
                {
                    IdAF = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionAF = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    DepartamentoAF = table.Column<int>(type: "int", nullable: true),
                    TipoActivoAF = table.Column<int>(type: "int", nullable: true),
                    FechaRegistroAF = table.Column<DateTime>(type: "date", nullable: true),
                    ValorCompraAF = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DepreciacionAcumuladaAF = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__ActivosF__B773A0C2A38A4F45", x => x.IdAF);
                    table.ForeignKey(
                        name: "FK__ActivosFi__Depar__3E52440B",
                        column: x => x.DepartamentoAF,
                        principalTable: "Departamentos",
                        principalColumn: "IdDepartamento");
                    table.ForeignKey(
                        name: "FK__ActivosFi__TipoA__3F466844",
                        column: x => x.TipoActivoAF,
                        principalTable: "TiposActivos",
                        principalColumn: "IdTA");
                });

            migrationBuilder.CreateTable(
                name: "CalculoDepreciacion",
                columns: table => new
                {
                    IdCD = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnoProcesoCD = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: true),
                    MesProcesoCD = table.Column<string>(type: "varchar(2)", unicode: false, maxLength: 2, nullable: true),
                    ActivoFijoCD = table.Column<int>(type: "int", nullable: true),
                    FechaProcesoCD = table.Column<DateTime>(type: "date", nullable: true),
                    MontoDepreciadoCD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DepreciacionAcumuladaCD = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CuentaCompra = table.Column<int>(type: "int", nullable: true),
                    CuentaDepreciacion = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__CalculoD__B773908796FD6285", x => x.IdCD);
                    table.ForeignKey(
                        name: "FK__CalculoDe__Activ__4222D4EF",
                        column: x => x.ActivoFijoCD,
                        principalTable: "ActivosFijos",
                        principalColumn: "IdAF");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivosFijos_DepartamentoAF",
                table: "ActivosFijos",
                column: "DepartamentoAF");

            migrationBuilder.CreateIndex(
                name: "IX_ActivosFijos_TipoActivoAF",
                table: "ActivosFijos",
                column: "TipoActivoAF");

            migrationBuilder.CreateIndex(
                name: "IX_CalculoDepreciacion_ActivoFijoCD",
                table: "CalculoDepreciacion",
                column: "ActivoFijoCD");

            migrationBuilder.CreateIndex(
                name: "IX_Empleado_DepartamentoEmpleado",
                table: "Empleado",
                column: "DepartamentoEmpleado");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculoDepreciacion");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "ActivosFijos");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "TiposActivos");
        }
    }
}
