using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Insfrastructure.BisleriumBloggingSystem.Migrations
{
    /// <inheritdoc />
    public partial class AddImageFile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogLike_Blogs_Blog",
                table: "BlogLike");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentLike_Comments_Comment",
                table: "CommentLike");

            migrationBuilder.RenameColumn(
                name: "Comment",
                table: "CommentLike",
                newName: "CommentId");

            migrationBuilder.RenameIndex(
                name: "IX_CommentLike_Comment",
                table: "CommentLike",
                newName: "IX_CommentLike_CommentId");

            migrationBuilder.RenameColumn(
                name: "Created_At",
                table: "Blogs",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "Blog",
                table: "BlogLike",
                newName: "BlogId");

            migrationBuilder.RenameIndex(
                name: "IX_BlogLike_Blog",
                table: "BlogLike",
                newName: "IX_BlogLike_BlogId");

            migrationBuilder.AddColumn<int>(
                name: "Total_Comment",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogLike_Blogs_BlogId",
                table: "BlogLike",
                column: "BlogId",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentLike_Comments_CommentId",
                table: "CommentLike",
                column: "CommentId",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogLike_Blogs_BlogId",
                table: "BlogLike");

            migrationBuilder.DropForeignKey(
                name: "FK_CommentLike_Comments_CommentId",
                table: "CommentLike");

            migrationBuilder.DropColumn(
                name: "Total_Comment",
                table: "Blogs");

            migrationBuilder.RenameColumn(
                name: "CommentId",
                table: "CommentLike",
                newName: "Comment");

            migrationBuilder.RenameIndex(
                name: "IX_CommentLike_CommentId",
                table: "CommentLike",
                newName: "IX_CommentLike_Comment");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Blogs",
                newName: "Created_At");

            migrationBuilder.RenameColumn(
                name: "BlogId",
                table: "BlogLike",
                newName: "Blog");

            migrationBuilder.RenameIndex(
                name: "IX_BlogLike_BlogId",
                table: "BlogLike",
                newName: "IX_BlogLike_Blog");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogLike_Blogs_Blog",
                table: "BlogLike",
                column: "Blog",
                principalTable: "Blogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CommentLike_Comments_Comment",
                table: "CommentLike",
                column: "Comment",
                principalTable: "Comments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
