using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DentalManager.Web.Data.Migrations
{
    public partial class Added_RegistrarionDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "RegistrationDate",
                table: "Patients",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistrationDate",
                table: "Patients");
        }
    }
}
