using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShelfSpeak.Migrations
{
    /// <inheritdoc />
    public partial class booksInUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "application_user_id",
                table: "books",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_books_application_user_id",
                table: "books",
                column: "application_user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_books_users_application_user_id",
                table: "books",
                column: "application_user_id",
                principalTable: "AspNetUsers",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_books_users_application_user_id",
                table: "books");

            migrationBuilder.DropIndex(
                name: "ix_books_application_user_id",
                table: "books");

            migrationBuilder.DropColumn(
                name: "application_user_id",
                table: "books");
        }
    }
}
