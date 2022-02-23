using Microsoft.EntityFrameworkCore.Migrations;

namespace dotnet_bakery.Migrations
{
    public partial class CreatePetOwnersTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "email",
                table: "petOwners",
                newName: "emailAddress");

            migrationBuilder.AddColumn<int>(
                name: "petCount",
                table: "petOwners",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "petCount",
                table: "petOwners");

            migrationBuilder.RenameColumn(
                name: "emailAddress",
                table: "petOwners",
                newName: "email");
        }
    }
}
