using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mc2.CrudTest.Infra.Migrations
{
    /// <inheritdoc />
    public partial class indexonfirsrnamelastnameandbirthdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Customers_FirstName_LastName_BirthDate",
                table: "Customers",
                columns: new[] { "FirstName", "LastName", "BirthDate" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_FirstName_LastName_BirthDate",
                table: "Customers");
        }
    }
}
