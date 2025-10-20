using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyHospital.Migrations
{
    /// <inheritdoc />
    public partial class addUid20102025 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Uid",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Uid",
                table: "Nationalities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Uid",
                table: "Jobs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Uid",
                table: "Faqs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Uid",
                table: "Departments",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Uid",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uid",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "Uid",
                table: "Nationalities");

            migrationBuilder.DropColumn(
                name: "Uid",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "Uid",
                table: "Faqs");

            migrationBuilder.DropColumn(
                name: "Uid",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "Uid",
                table: "Categories");
        }
    }
}
