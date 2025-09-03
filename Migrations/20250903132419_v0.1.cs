using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChurchApi.Migrations
{
    /// <inheritdoc />
    public partial class v01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departaments_Members_MemberModelId",
                table: "Departaments");

            migrationBuilder.DropIndex(
                name: "IX_Departaments_MemberModelId",
                table: "Departaments");

            migrationBuilder.DropColumn(
                name: "MemberModelId",
                table: "Departaments");

            migrationBuilder.CreateTable(
                name: "DepartamentModelMemberModel",
                columns: table => new
                {
                    DepartamentsId = table.Column<int>(type: "int", nullable: false),
                    MembersId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartamentModelMemberModel", x => new { x.DepartamentsId, x.MembersId });
                    table.ForeignKey(
                        name: "FK_DepartamentModelMemberModel_Departaments_DepartamentsId",
                        column: x => x.DepartamentsId,
                        principalTable: "Departaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DepartamentModelMemberModel_Members_MembersId",
                        column: x => x.MembersId,
                        principalTable: "Members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DepartamentModelMemberModel_MembersId",
                table: "DepartamentModelMemberModel",
                column: "MembersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartamentModelMemberModel");

            migrationBuilder.AddColumn<int>(
                name: "MemberModelId",
                table: "Departaments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departaments_MemberModelId",
                table: "Departaments",
                column: "MemberModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departaments_Members_MemberModelId",
                table: "Departaments",
                column: "MemberModelId",
                principalTable: "Members",
                principalColumn: "Id");
        }
    }
}
