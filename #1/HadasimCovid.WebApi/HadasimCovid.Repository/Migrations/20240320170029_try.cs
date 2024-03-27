using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HadasimCovid.Repository.Migrations
{
    /// <inheritdoc />
    public partial class @try : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CovidDetails_Members_MemberId",
                table: "CovidDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaccinations_Members_MemberId",
                table: "Vaccinations");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "Vaccinations",
                newName: "IdMember");

            migrationBuilder.RenameIndex(
                name: "IX_Vaccinations_MemberId",
                table: "Vaccinations",
                newName: "IX_Vaccinations_IdMember");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Members",
                newName: "IdMember");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "CovidDetails",
                newName: "IdMember");

            migrationBuilder.RenameIndex(
                name: "IX_CovidDetails_MemberId",
                table: "CovidDetails",
                newName: "IX_CovidDetails_IdMember");

            migrationBuilder.AddForeignKey(
                name: "FK_CovidDetails_Members_IdMember",
                table: "CovidDetails",
                column: "IdMember",
                principalTable: "Members",
                principalColumn: "IdMember");

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccinations_Members_IdMember",
                table: "Vaccinations",
                column: "IdMember",
                principalTable: "Members",
                principalColumn: "IdMember");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CovidDetails_Members_IdMember",
                table: "CovidDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaccinations_Members_IdMember",
                table: "Vaccinations");

            migrationBuilder.RenameColumn(
                name: "IdMember",
                table: "Vaccinations",
                newName: "MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Vaccinations_IdMember",
                table: "Vaccinations",
                newName: "IX_Vaccinations_MemberId");

            migrationBuilder.RenameColumn(
                name: "IdMember",
                table: "Members",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "IdMember",
                table: "CovidDetails",
                newName: "MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_CovidDetails_IdMember",
                table: "CovidDetails",
                newName: "IX_CovidDetails_MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_CovidDetails_Members_MemberId",
                table: "CovidDetails",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vaccinations_Members_MemberId",
                table: "Vaccinations",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "Id");
        }
    }
}
