using Microsoft.EntityFrameworkCore.Migrations;
using Newtonsoft.Json.Converters;
using System;

namespace WebApplication2.Migrations
{
    public partial class Migration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "t_Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Patronymic = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Snails = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Burthday = table.Column<string>(nullable: true),
                    Photo = table.Column<byte[]>(nullable: true),
                    Avatar = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_t_Users", x => x.Id);
                }); ;

                migrationBuilder.CreateTable(
                name: "Child",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Patronymic = table.Column<string>(nullable: true),
                    Age = table.Column<int>(nullable: false),
                    Snails = table.Column<string>(nullable: true),
                    Phone = table.Column<string>(nullable: true),
                    Burthday = table.Column<string>(nullable: true),
                    Photo = table.Column<byte[]>(nullable: true),
                    Avatar = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Child", x => x.Id);
                }); ;
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "t_Users");

            migrationBuilder.DropTable(
              name: "Child");
        }
    }
}
