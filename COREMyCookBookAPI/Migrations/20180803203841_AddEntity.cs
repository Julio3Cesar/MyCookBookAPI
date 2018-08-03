using Microsoft.EntityFrameworkCore.Migrations;

namespace COREMyCookBookAPI.Migrations
{
    public partial class AddEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Recipes",
                table: "Recipes");

            migrationBuilder.RenameTable(
                name: "Recipes",
                newName: "Entitys");

            migrationBuilder.AlterColumn<double>(
                name: "PreparationTime",
                table: "Entitys",
                nullable: true,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Entitys",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Ingredients",
                table: "Entitys",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Preparation",
                table: "Entitys",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Entitys",
                table: "Entitys",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Entitys",
                table: "Entitys");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Entitys");

            migrationBuilder.DropColumn(
                name: "Ingredients",
                table: "Entitys");

            migrationBuilder.DropColumn(
                name: "Preparation",
                table: "Entitys");

            migrationBuilder.RenameTable(
                name: "Entitys",
                newName: "Recipes");

            migrationBuilder.AlterColumn<double>(
                name: "PreparationTime",
                table: "Recipes",
                nullable: false,
                oldClrType: typeof(double),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Recipes",
                table: "Recipes",
                column: "Id");
        }
    }
}
