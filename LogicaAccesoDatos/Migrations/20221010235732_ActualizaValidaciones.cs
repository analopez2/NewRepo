using Microsoft.EntityFrameworkCore.Migrations;

namespace LogicaAccesoDatos.Migrations
{
    public partial class ActualizaValidaciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Telefono",
                table: "Selecciones",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Selecciones",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Grupos",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Selecciones_Email",
                table: "Selecciones",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Selecciones_Telefono",
                table: "Selecciones",
                column: "Telefono",
                unique: true,
                filter: "[Telefono] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Paises_Codigo",
                table: "Paises",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Paises_Nombre",
                table: "Paises",
                column: "Nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grupos_Nombre",
                table: "Grupos",
                column: "Nombre",
                unique: true,
                filter: "[Nombre] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Selecciones_Email",
                table: "Selecciones");

            migrationBuilder.DropIndex(
                name: "IX_Selecciones_Telefono",
                table: "Selecciones");

            migrationBuilder.DropIndex(
                name: "IX_Paises_Codigo",
                table: "Paises");

            migrationBuilder.DropIndex(
                name: "IX_Paises_Nombre",
                table: "Paises");

            migrationBuilder.DropIndex(
                name: "IX_Grupos_Nombre",
                table: "Grupos");

            migrationBuilder.AlterColumn<string>(
                name: "Telefono",
                table: "Selecciones",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Selecciones",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "Grupos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
