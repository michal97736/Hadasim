using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HadasimCovid.Repository.Migrations
{
    /// <inheritdoc />
    public partial class tamar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CovidDetails_Members_IdMember",
                table: "CovidDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Vaccinations_Members_IdMember",
                table: "Vaccinations");

            migrationBuilder.DropIndex(
                name: "IX_Vaccinations_IdMember",
                table: "Vaccinations");

            migrationBuilder.DropIndex(
                name: "IX_CovidDetails_IdMember",
                table: "CovidDetails");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Vaccinations_IdMember",
                table: "Vaccinations",
                column: "IdMember");

            migrationBuilder.CreateIndex(
                name: "IX_CovidDetails_IdMember",
                table: "CovidDetails",
                column: "IdMember");

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
    }
}
