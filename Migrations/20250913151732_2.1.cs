using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChurchApi.Migrations
{
    /// <inheritdoc />
    public partial class _21 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Departaments_DepartamentIdId",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "DepartamentIdId",
                table: "Members",
                newName: "DepartamentId");

            migrationBuilder.RenameIndex(
                name: "IX_Members_DepartamentIdId",
                table: "Members",
                newName: "IX_Members_DepartamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Departaments_DepartamentId",
                table: "Members",
                column: "DepartamentId",
                principalTable: "Departaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Members_Departaments_DepartamentId",
                table: "Members");

            migrationBuilder.RenameColumn(
                name: "DepartamentId",
                table: "Members",
                newName: "DepartamentIdId");

            migrationBuilder.RenameIndex(
                name: "IX_Members_DepartamentId",
                table: "Members",
                newName: "IX_Members_DepartamentIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_Members_Departaments_DepartamentIdId",
                table: "Members",
                column: "DepartamentIdId",
                principalTable: "Departaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
