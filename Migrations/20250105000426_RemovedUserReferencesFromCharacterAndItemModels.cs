using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ARPGTradeBeta.Migrations
{
    /// <inheritdoc />
    public partial class RemovedUserReferencesFromCharacterAndItemModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_AspNetUsers_PlayerId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_AspNetUsers_PlayerId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_PlayerId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Characters_PlayerId",
                table: "Characters");

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ApplicationUserId",
                table: "Characters",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_ApplicationUserId",
                table: "Items",
                column: "ApplicationUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_ApplicationUserId",
                table: "Characters",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_AspNetUsers_ApplicationUserId",
                table: "Characters",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_AspNetUsers_ApplicationUserId",
                table: "Items",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_AspNetUsers_ApplicationUserId",
                table: "Characters");

            migrationBuilder.DropForeignKey(
                name: "FK_Items_AspNetUsers_ApplicationUserId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_ApplicationUserId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Characters_ApplicationUserId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "ApplicationUserId",
                table: "Characters");

            migrationBuilder.CreateIndex(
                name: "IX_Items_PlayerId",
                table: "Items",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_PlayerId",
                table: "Characters",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_AspNetUsers_PlayerId",
                table: "Characters",
                column: "PlayerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_AspNetUsers_PlayerId",
                table: "Items",
                column: "PlayerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
