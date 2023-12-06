using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UserApi.Migrations
{
    /// <inheritdoc />
    public partial class ChatroomDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Chatrooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    Title = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "bytea", maxLength: 255, nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: true, defaultValueSql: "0"),
                    TotalUsers = table.Column<int>(type: "integer", nullable: true, defaultValueSql: "0"),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: true, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("Chatrooms_pkey", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "Chatrooms_Title_key",
                table: "Chatrooms",
                column: "Title",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chatrooms");
        }
    }
}
