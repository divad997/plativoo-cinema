using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CinemaInfrastructure.Migrations
{
    public partial class CardinalityUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Directors_DirectorId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_GenreId",
                table: "Movies");

            migrationBuilder.AlterColumn<Guid>(
                name: "GenreId",
                table: "Movies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "DirectorId",
                table: "Movies",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Directors_DirectorId",
                table: "Movies",
                column: "DirectorId",
                principalTable: "Directors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_GenreId",
                table: "Movies",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Directors_DirectorId",
                table: "Movies");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_GenreId",
                table: "Movies");

            migrationBuilder.AlterColumn<Guid>(
                name: "GenreId",
                table: "Movies",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "DirectorId",
                table: "Movies",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Directors_DirectorId",
                table: "Movies",
                column: "DirectorId",
                principalTable: "Directors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_GenreId",
                table: "Movies",
                column: "GenreId",
                principalTable: "Genres",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
