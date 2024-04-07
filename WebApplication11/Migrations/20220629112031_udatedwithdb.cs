using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication11.Migrations
{
    public partial class udatedwithdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Stadium",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Gate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    numberOfPeople = table.Column<long>(type: "bigint", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stadium", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stadium");
        }
    }
}
