using Microsoft.EntityFrameworkCore.Migrations;

namespace LogicaAccesoDatos.Migrations
{
    public partial class initPrueba : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incidencias_Selecciones_SeleccionId",
                table: "Incidencias");

            migrationBuilder.AlterColumn<int>(
                name: "SeleccionId",
                table: "Incidencias",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Goles",
                table: "Incidencias",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidencias_Selecciones_SeleccionId",
                table: "Incidencias",
                column: "SeleccionId",
                principalTable: "Selecciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incidencias_Selecciones_SeleccionId",
                table: "Incidencias");

            migrationBuilder.DropColumn(
                name: "Goles",
                table: "Incidencias");

            migrationBuilder.AlterColumn<int>(
                name: "SeleccionId",
                table: "Incidencias",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Incidencias_Selecciones_SeleccionId",
                table: "Incidencias",
                column: "SeleccionId",
                principalTable: "Selecciones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
