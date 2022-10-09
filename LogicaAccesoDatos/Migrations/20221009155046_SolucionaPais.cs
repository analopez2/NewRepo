using Microsoft.EntityFrameworkCore.Migrations;

namespace LogicaAccesoDatos.Migrations
{
    public partial class SolucionaPais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paises_Regiones_RegionId",
                table: "Paises");

            migrationBuilder.DropColumn(
                name: "RegionInd",
                table: "Paises");

            migrationBuilder.AlterColumn<int>(
                name: "RegionId",
                table: "Paises",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Paises_Regiones_RegionId",
                table: "Paises",
                column: "RegionId",
                principalTable: "Regiones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Paises_Regiones_RegionId",
                table: "Paises");

            migrationBuilder.AlterColumn<int>(
                name: "RegionId",
                table: "Paises",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "RegionInd",
                table: "Paises",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Paises_Regiones_RegionId",
                table: "Paises",
                column: "RegionId",
                principalTable: "Regiones",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
