using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ORT_PNT1_Proyecto_2022_2C_I_ReservaEspectaculo.Data.Migrations
{
    public partial class AgregadoSecuenciaLegajo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateSequence<int>(
                name: "LegajosEmpleados",
                startValue: 110000L);

            migrationBuilder.AlterColumn<int>(
                name: "Legajo",
                table: "Usuarios",
                type: "int",
                nullable: true,
                defaultValueSql: "NEXT VALUE FOR LegajosEmpleados",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropSequence(
                name: "LegajosEmpleados");

            migrationBuilder.AlterColumn<string>(
                name: "Legajo",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true,
                oldDefaultValueSql: "NEXT VALUE FOR LegajosEmpleados");
        }
    }
}
