using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PostManagement.Migrations
{
    public partial class changePost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AppUsers_appUserUserId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_PostCategories_postCategoryCategoryId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "postCategoryCategoryId",
                table: "Posts",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "appUserUserId",
                table: "Posts",
                newName: "AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_postCategoryCategoryId",
                table: "Posts",
                newName: "IX_Posts_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_appUserUserId",
                table: "Posts",
                newName: "IX_Posts_AuthorId");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "PostCategories",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "AppUsers",
                newName: "Id");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 12, 17, 8, 16, 166, DateTimeKind.Local).AddTicks(1527),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 12, 16, 49, 33, 785, DateTimeKind.Local).AddTicks(9300));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 12, 17, 8, 16, 166, DateTimeKind.Local).AddTicks(1211),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 12, 16, 49, 33, 785, DateTimeKind.Local).AddTicks(8980));

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AppUsers_AuthorId",
                table: "Posts",
                column: "AuthorId",
                principalTable: "AppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_PostCategories_CategoryId",
                table: "Posts",
                column: "CategoryId",
                principalTable: "PostCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_AppUsers_AuthorId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_PostCategories_CategoryId",
                table: "Posts");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Posts",
                newName: "postCategoryCategoryId");

            migrationBuilder.RenameColumn(
                name: "AuthorId",
                table: "Posts",
                newName: "appUserUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                newName: "IX_Posts_postCategoryCategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_AuthorId",
                table: "Posts",
                newName: "IX_Posts_appUserUserId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PostCategories",
                newName: "CategoryId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "AppUsers",
                newName: "UserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 12, 16, 49, 33, 785, DateTimeKind.Local).AddTicks(9300),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 12, 17, 8, 16, 166, DateTimeKind.Local).AddTicks(1527));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Posts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 3, 12, 16, 49, 33, 785, DateTimeKind.Local).AddTicks(8980),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 3, 12, 17, 8, 16, 166, DateTimeKind.Local).AddTicks(1211));

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_AppUsers_appUserUserId",
                table: "Posts",
                column: "appUserUserId",
                principalTable: "AppUsers",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_PostCategories_postCategoryCategoryId",
                table: "Posts",
                column: "postCategoryCategoryId",
                principalTable: "PostCategories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
