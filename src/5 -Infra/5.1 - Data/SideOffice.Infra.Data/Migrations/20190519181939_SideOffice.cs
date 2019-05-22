using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SideOffice.Infra.Data.Migrations
{
    public partial class SideOffice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Room_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Description = table.Column<string>(type: "varchar(250)", nullable: false),
                    Seats = table.Column<int>(type: "int", nullable: false),
                    Square_meters = table.Column<decimal>(type: "numeric(10, 2)", nullable: false),
                    Hour_price = table.Column<decimal>(type: "decimal(10, 2)", nullable: false),
                    Has_wifi = table.Column<bool>(type: "bit", nullable: false),
                    Has_ethernet = table.Column<bool>(type: "bit", nullable: false),
                    Has_tv = table.Column<bool>(type: "bit", nullable: false),
                    Has_webcam = table.Column<bool>(type: "bit", nullable: false),
                    Has_air_conditioning = table.Column<bool>(type: "bit", nullable: false),
                    Status = table.Column<string>(type: "char(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Room_id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    User_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Last_name = table.Column<string>(type: "varchar(50)", nullable: false),
                    Email = table.Column<string>(type: "varchar(150)", nullable: false),
                    Document = table.Column<string>(type: "varchar(50)", nullable: false),
                    Password = table.Column<byte[]>(type: "varbinary(MAX)", nullable: false),
                    Registration_datetime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Country_code = table.Column<string>(type: "varchar(3)", nullable: false),
                    Last_login_datetime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<string>(type: "char(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.User_id);
                });

            migrationBuilder.CreateTable(
                name: "Rents",
                columns: table => new
                {
                    Rent_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Room_id = table.Column<Guid>(nullable: false),
                    User_id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "varchar(50)", nullable: false),
                    Description = table.Column<string>(type: "varchar(250)", nullable: false),
                    Start_datetime = table.Column<DateTime>(type: "datetime", nullable: false),
                    End_datetime = table.Column<DateTime>(type: "datetime", nullable: false),
                    Status = table.Column<string>(type: "char(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rents", x => x.Rent_id);
                    table.ForeignKey(
                        name: "FK_Rents_Rooms_Room_id",
                        column: x => x.Room_id,
                        principalTable: "Rooms",
                        principalColumn: "Room_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rents_Users_User_id",
                        column: x => x.User_id,
                        principalTable: "Users",
                        principalColumn: "User_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rents_Room_id",
                table: "Rents",
                column: "Room_id");

            migrationBuilder.CreateIndex(
                name: "IX_Rents_User_id",
                table: "Rents",
                column: "User_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rents");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
