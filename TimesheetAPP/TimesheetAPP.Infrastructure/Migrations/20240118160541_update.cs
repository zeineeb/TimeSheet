﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TimesheetAPP.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Intervenants_Consomations_ConsomationId",
                table: "Intervenants");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Intervenants",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeNaissnace",
                table: "Intervenants",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "ConsomationId",
                table: "Intervenants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "ClientExistance",
                table: "Intervenants",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddForeignKey(
                name: "FK_Intervenants_Consomations_ConsomationId",
                table: "Intervenants",
                column: "ConsomationId",
                principalTable: "Consomations",
                principalColumn: "ConsomationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Intervenants_Consomations_ConsomationId",
                table: "Intervenants");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Intervenants",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateDeNaissnace",
                table: "Intervenants",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ConsomationId",
                table: "Intervenants",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "ClientExistance",
                table: "Intervenants",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Intervenants_Consomations_ConsomationId",
                table: "Intervenants",
                column: "ConsomationId",
                principalTable: "Consomations",
                principalColumn: "ConsomationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
