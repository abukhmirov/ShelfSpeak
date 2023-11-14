using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ShelfSpeak.Migrations
{
    /// <inheritdoc />
    public partial class DeleteUserandMessage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_books_user_user_id",
                table: "books");

            migrationBuilder.DropTable(
                name: "messages");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropIndex(
                name: "ix_books_user_id",
                table: "books");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "books");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "books",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    user_name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "messages",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: false),
                    application_user_id = table.Column<string>(type: "text", nullable: true),
                    content = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    upvotes = table.Column<List<int>>(type: "integer[]", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_messages", x => x.id);
                    table.ForeignKey(
                        name: "fk_messages_user_user_id",
                        column: x => x.user_id,
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_messages_users_application_user_id",
                        column: x => x.application_user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_books_user_id",
                table: "books",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_messages_application_user_id",
                table: "messages",
                column: "application_user_id");

            migrationBuilder.CreateIndex(
                name: "ix_messages_user_id",
                table: "messages",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_books_user_user_id",
                table: "books",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id");
        }
    }
}
