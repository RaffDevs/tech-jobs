using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TecJobsAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCompanyField : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AboutUs",
                table: "company",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AboutUs",
                table: "company");
        }
    }
}
