using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FileType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FileTypeFormat = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InputOutputResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InputList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutputList = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InputTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OutputTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FileTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InputOutputResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InputOutputResult_FileType_FileTypeId",
                        column: x => x.FileTypeId,
                        principalTable: "FileType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "FileType",
                columns: new[] { "Id", "FileTypeFormat" },
                values: new object[] { 1, "TEXT" });

            migrationBuilder.InsertData(
                table: "FileType",
                columns: new[] { "Id", "FileTypeFormat" },
                values: new object[] { 2, "XML" });

            migrationBuilder.InsertData(
                table: "FileType",
                columns: new[] { "Id", "FileTypeFormat" },
                values: new object[] { 3, "JSON" });

            migrationBuilder.CreateIndex(
                name: "IX_InputOutputResult_FileTypeId",
                table: "InputOutputResult",
                column: "FileTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InputOutputResult");

            migrationBuilder.DropTable(
                name: "FileType");
        }
    }
}
