using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace tester_final.Migrations
{
    /// <inheritdoc />
    public partial class UploadDocs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UploadDocuments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LecturerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClaimMonth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentData = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UploadDocuments", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UploadDocuments");
        }
    }
}
