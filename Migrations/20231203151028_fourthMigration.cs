﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication2.Migrations
{
    /// <inheritdoc />
    public partial class fourthMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "MovieAdded",
                table: "Movies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("79e6f638-d7e7-4f63-8365-f172cb925385"), null },
                    { new Guid("84ca0bcd-082c-49cb-aa77-ea2f1f5f8286"), null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("79e6f638-d7e7-4f63-8365-f172cb925385"));

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "Id",
                keyValue: new Guid("84ca0bcd-082c-49cb-aa77-ea2f1f5f8286"));

            migrationBuilder.DropColumn(
                name: "MovieAdded",
                table: "Movies");
        }
    }
}
