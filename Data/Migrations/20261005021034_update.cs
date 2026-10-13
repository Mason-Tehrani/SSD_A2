using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Drawing;
using System.Security.Policy;
using System.Text;

#nullable disable

namespace SSD_A1.Data.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropColumn(
            //    name: "City",
            //    table: "AspNetUsers");

            //migrationBuilder.DropColumn(
            //    name: "FirstName",
            //    table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");
        }
    }


}

