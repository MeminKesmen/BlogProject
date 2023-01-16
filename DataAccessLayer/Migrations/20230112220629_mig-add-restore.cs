using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class migaddrestore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BlogThumbnailImage",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "AboutDetails1",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "AboutDetails2",
                table: "Abouts");

            migrationBuilder.DropColumn(
                name: "AboutImage1",
                table: "Abouts");

            migrationBuilder.RenameColumn(
                name: "AboutMapLocation",
                table: "Abouts",
                newName: "AboutImage");

            migrationBuilder.RenameColumn(
                name: "AboutImage2",
                table: "Abouts",
                newName: "AboutDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "AboutImage",
                table: "Abouts",
                newName: "AboutMapLocation");

            migrationBuilder.RenameColumn(
                name: "AboutDetails",
                table: "Abouts",
                newName: "AboutImage2");

            migrationBuilder.AddColumn<string>(
                name: "BlogThumbnailImage",
                table: "Blogs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AboutDetails1",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AboutDetails2",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AboutImage1",
                table: "Abouts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
