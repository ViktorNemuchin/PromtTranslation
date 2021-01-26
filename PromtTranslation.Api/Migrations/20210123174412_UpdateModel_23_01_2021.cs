using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PromtTranslation.Api.Migrations
{
    public partial class UpdateModel_23_01_2021 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LanguageRouteStepsModel_RouteModel_RouteModelId",
                table: "LanguageRouteStepsModel");

            migrationBuilder.DropIndex(
                name: "IX_LanguageRouteStepsModel_RouteModelId",
                table: "LanguageRouteStepsModel");

            migrationBuilder.DropColumn(
                name: "RouteModelId",
                table: "LanguageRouteStepsModel");

            migrationBuilder.RenameColumn(
                name: "RouteSteps",
                table: "LanguageRouteStepsModel",
                newName: "LanguageTo");

            migrationBuilder.RenameColumn(
                name: "Language",
                table: "LanguageRouteStepsModel",
                newName: "LanguageFrom");

            migrationBuilder.AddColumn<Guid>(
                name: "RouteId",
                table: "LanguageRouteStepsModel",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_LanguageRouteStepsModel_RouteId",
                table: "LanguageRouteStepsModel",
                column: "RouteId");

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageRouteStepsModel_RouteModel_RouteId",
                table: "LanguageRouteStepsModel",
                column: "RouteId",
                principalTable: "RouteModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LanguageRouteStepsModel_RouteModel_RouteId",
                table: "LanguageRouteStepsModel");

            migrationBuilder.DropIndex(
                name: "IX_LanguageRouteStepsModel_RouteId",
                table: "LanguageRouteStepsModel");

            migrationBuilder.DropColumn(
                name: "RouteId",
                table: "LanguageRouteStepsModel");

            migrationBuilder.RenameColumn(
                name: "LanguageTo",
                table: "LanguageRouteStepsModel",
                newName: "RouteSteps");

            migrationBuilder.RenameColumn(
                name: "LanguageFrom",
                table: "LanguageRouteStepsModel",
                newName: "Language");

            migrationBuilder.AddColumn<Guid>(
                name: "RouteModelId",
                table: "LanguageRouteStepsModel",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LanguageRouteStepsModel_RouteModelId",
                table: "LanguageRouteStepsModel",
                column: "RouteModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_LanguageRouteStepsModel_RouteModel_RouteModelId",
                table: "LanguageRouteStepsModel",
                column: "RouteModelId",
                principalTable: "RouteModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
