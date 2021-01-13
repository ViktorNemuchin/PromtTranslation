using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PromtTranslation.Api.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RouteModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    RouteName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StatusModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StatusValue = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LanguageRouteStepsModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Language = table.Column<string>(type: "text", nullable: true),
                    RouteSteps = table.Column<string>(type: "text", nullable: true),
                    RouteModelId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LanguageRouteStepsModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LanguageRouteStepsModel_RouteModel_RouteModelId",
                        column: x => x.RouteModelId,
                        principalTable: "RouteModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TranslationModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StatusId = table.Column<Guid>(type: "uuid", nullable: false),
                    RouteModelId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslationModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TranslationModel_RouteModel_RouteModelId",
                        column: x => x.RouteModelId,
                        principalTable: "RouteModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TranslationModel_StatusModel_StatusId",
                        column: x => x.StatusId,
                        principalTable: "StatusModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TranslationTextModel",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Text = table.Column<string>(type: "text", nullable: true),
                    Language = table.Column<string>(type: "text", nullable: true),
                    TranslationModelId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TranslationTextModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TranslationTextModel_TranslationModel_TranslationModelId",
                        column: x => x.TranslationModelId,
                        principalTable: "TranslationModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LanguageRouteStepsModel_RouteModelId",
                table: "LanguageRouteStepsModel",
                column: "RouteModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslationModel_RouteModelId",
                table: "TranslationModel",
                column: "RouteModelId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslationModel_StatusId",
                table: "TranslationModel",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_TranslationTextModel_TranslationModelId",
                table: "TranslationTextModel",
                column: "TranslationModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LanguageRouteStepsModel");

            migrationBuilder.DropTable(
                name: "TranslationTextModel");

            migrationBuilder.DropTable(
                name: "TranslationModel");

            migrationBuilder.DropTable(
                name: "RouteModel");

            migrationBuilder.DropTable(
                name: "StatusModel");
        }
    }
}
