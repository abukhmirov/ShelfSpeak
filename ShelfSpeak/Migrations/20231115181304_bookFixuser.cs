using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShelfSpeak.Migrations
{
    /// <inheritdoc />
    public partial class bookFixuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_books_users_application_user_id",
                table: "books");

            migrationBuilder.RenameColumn(
                name: "application_user_id",
                table: "books",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "ix_books_application_user_id",
                table: "books",
                newName: "ix_books_user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_books_users_user_id",
                table: "books",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_books_users_user_id",
                table: "books");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "books",
                newName: "application_user_id");

            migrationBuilder.RenameIndex(
                name: "ix_books_user_id",
                table: "books",
                newName: "ix_books_application_user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_books_users_application_user_id",
                table: "books",
                column: "application_user_id",
                principalTable: "AspNetUsers",
                principalColumn: "id");
        }
    }
}
