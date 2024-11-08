using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Migrations
{
    /// <inheritdoc />
    public partial class EditedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookAuthors_BookAuhorId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookAuhorId",
                table: "Books");

            migrationBuilder.DropColumn(
                name: "BookAuhorId",
                table: "Books");

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookAuthorId",
                table: "Books",
                column: "BookAuthorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookAuthors_BookAuthorId",
                table: "Books",
                column: "BookAuthorId",
                principalTable: "BookAuthors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Books_BookAuthors_BookAuthorId",
                table: "Books");

            migrationBuilder.DropIndex(
                name: "IX_Books_BookAuthorId",
                table: "Books");

            migrationBuilder.AddColumn<int>(
                name: "BookAuhorId",
                table: "Books",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Books_BookAuhorId",
                table: "Books",
                column: "BookAuhorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Books_BookAuthors_BookAuhorId",
                table: "Books",
                column: "BookAuhorId",
                principalTable: "BookAuthors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
