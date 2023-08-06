using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetGuard_Project.Migrations
{
    public partial class Enviocontabilidadagregado : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__ActivosFi__Depar__3E52440B",
                table: "ActivosFijos");

            migrationBuilder.DropForeignKey(
                name: "FK__ActivosFi__TipoA__3F466844",
                table: "ActivosFijos");

            migrationBuilder.AlterColumn<string>(
                name: "DescripcionTA",
                table: "TiposActivos",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NombreEmpleado",
                table: "Empleado",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaIngresoEmpleado",
                table: "Empleado",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CedulaEmpleado",
                table: "Empleado",
                type: "varchar(11)",
                unicode: false,
                maxLength: 11,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldUnicode: false,
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DescripcionDepartamento",
                table: "Departamentos",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "MontoDepreciadoCD",
                table: "CalculoDepreciacion",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MesProcesoCD",
                table: "CalculoDepreciacion",
                type: "varchar(2)",
                unicode: false,
                maxLength: 2,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(2)",
                oldUnicode: false,
                oldMaxLength: 2,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaProcesoCD",
                table: "CalculoDepreciacion",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DepreciacionAcumuladaCD",
                table: "CalculoDepreciacion",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CuentaDepreciacion",
                table: "CalculoDepreciacion",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CuentaCompra",
                table: "CalculoDepreciacion",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AnoProcesoCD",
                table: "CalculoDepreciacion",
                type: "varchar(4)",
                unicode: false,
                maxLength: 4,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(4)",
                oldUnicode: false,
                oldMaxLength: 4,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorCompraAF",
                table: "ActivosFijos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TipoActivoAF",
                table: "ActivosFijos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaRegistroAF",
                table: "ActivosFijos",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "date",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DescripcionAF",
                table: "ActivosFijos",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "DepreciacionAcumuladaAF",
                table: "ActivosFijos",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoAF",
                table: "ActivosFijos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "EnvioContabilidad",
                columns: table => new
                {
                    IdEC = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionEC = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Auxiliar = table.Column<int>(type: "int", nullable: true),
                    CuentaDB = table.Column<int>(type: "int", nullable: true),
                    CuentaCR = table.Column<int>(type: "int", nullable: true),
                    MontoEnvioContabilidad = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnvioContabilidad", x => x.IdEC);
                });

            migrationBuilder.AddForeignKey(
                name: "FK__ActivosFi__Depar__3E52440B",
                table: "ActivosFijos",
                column: "DepartamentoAF",
                principalTable: "Departamentos",
                principalColumn: "IdDepartamento",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK__ActivosFi__TipoA__3F466844",
                table: "ActivosFijos",
                column: "TipoActivoAF",
                principalTable: "TiposActivos",
                principalColumn: "IdTA",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK__ActivosFi__Depar__3E52440B",
                table: "ActivosFijos");

            migrationBuilder.DropForeignKey(
                name: "FK__ActivosFi__TipoA__3F466844",
                table: "ActivosFijos");

            migrationBuilder.DropTable(
                name: "EnvioContabilidad");

            migrationBuilder.AlterColumn<string>(
                name: "DescripcionTA",
                table: "TiposActivos",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "NombreEmpleado",
                table: "Empleado",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaIngresoEmpleado",
                table: "Empleado",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "CedulaEmpleado",
                table: "Empleado",
                type: "varchar(11)",
                unicode: false,
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(11)",
                oldUnicode: false,
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<string>(
                name: "DescripcionDepartamento",
                table: "Departamentos",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<decimal>(
                name: "MontoDepreciadoCD",
                table: "CalculoDepreciacion",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "MesProcesoCD",
                table: "CalculoDepreciacion",
                type: "varchar(2)",
                unicode: false,
                maxLength: 2,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(2)",
                oldUnicode: false,
                oldMaxLength: 2);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaProcesoCD",
                table: "CalculoDepreciacion",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<decimal>(
                name: "DepreciacionAcumuladaCD",
                table: "CalculoDepreciacion",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "CuentaDepreciacion",
                table: "CalculoDepreciacion",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CuentaCompra",
                table: "CalculoDepreciacion",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "AnoProcesoCD",
                table: "CalculoDepreciacion",
                type: "varchar(4)",
                unicode: false,
                maxLength: 4,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(4)",
                oldUnicode: false,
                oldMaxLength: 4);

            migrationBuilder.AlterColumn<decimal>(
                name: "ValorCompraAF",
                table: "ActivosFijos",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "TipoActivoAF",
                table: "ActivosFijos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaRegistroAF",
                table: "ActivosFijos",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "date");

            migrationBuilder.AlterColumn<string>(
                name: "DescripcionAF",
                table: "ActivosFijos",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<decimal>(
                name: "DepreciacionAcumuladaAF",
                table: "ActivosFijos",
                type: "decimal(18,2)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoAF",
                table: "ActivosFijos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK__ActivosFi__Depar__3E52440B",
                table: "ActivosFijos",
                column: "DepartamentoAF",
                principalTable: "Departamentos",
                principalColumn: "IdDepartamento");

            migrationBuilder.AddForeignKey(
                name: "FK__ActivosFi__TipoA__3F466844",
                table: "ActivosFijos",
                column: "TipoActivoAF",
                principalTable: "TiposActivos",
                principalColumn: "IdTA");
        }
    }
}
