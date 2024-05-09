using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Insfrastructure.BisleriumBloggingSystem.Migrations
{
    /// <inheritdoc />
    public partial class addhistory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PreviousBlogTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreviousBlogContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PreviousBlogImage = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogCreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    BlogModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Blog = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogHistories_Blogs_Blog",
                        column: x => x.Blog,
                        principalTable: "Blogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentHistories",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PreviousCommentContent = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommentCreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CommentModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Comments = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentHistories_Comments_Comments",
                        column: x => x.Comments,
                        principalTable: "Comments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogHistories_Blog",
                table: "BlogHistories",
                column: "Blog");

            migrationBuilder.CreateIndex(
                name: "IX_CommentHistories_Comments",
                table: "CommentHistories",
                column: "Comments");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogHistories");

            migrationBuilder.DropTable(
                name: "CommentHistories");
        }
    }
}
