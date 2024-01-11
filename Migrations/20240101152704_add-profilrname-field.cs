using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarriageAPi.Migrations
{
    /// <inheritdoc />
    public partial class addprofilrnamefield : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IntrestedProfileName",
                table: "Enquiry",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IntrestedProfileName",
                table: "Enquiry");
        }
    }
}
