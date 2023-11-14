using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShelfSpeak.Migrations
{
    /// <inheritdoc />
    public partial class DeleteLibrarians : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_books_librarians_user_id",
                table: "books");

            migrationBuilder.DropForeignKey(
                name: "fk_messages_librarians_user_id",
                table: "messages");

            migrationBuilder.DropPrimaryKey(
                name: "pk_librarians",
                table: "librarians");

            migrationBuilder.RenameTable(
                name: "librarians",
                newName: "user");

            migrationBuilder.AddPrimaryKey(
                name: "pk_user",
                table: "user",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_books_user_user_id",
                table: "books",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_messages_user_user_id",
                table: "messages",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_books_user_user_id",
                table: "books");

            migrationBuilder.DropForeignKey(
                name: "fk_messages_user_user_id",
                table: "messages");

            migrationBuilder.DropPrimaryKey(
                name: "pk_user",
                table: "user");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "librarians");

            migrationBuilder.AddPrimaryKey(
                name: "pk_librarians",
                table: "librarians",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_books_librarians_user_id",
                table: "books",
                column: "user_id",
                principalTable: "librarians",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_messages_librarians_user_id",
                table: "messages",
                column: "user_id",
                principalTable: "librarians",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
